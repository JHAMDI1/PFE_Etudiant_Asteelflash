using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Authentication.Dtos;
using PFE_Etudiant_Asteelflash.Application.Authentication.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Zap.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.External;
using PFE_Etudiant_Asteelflash.Models.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using AutoMapper.Configuration.Annotations;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.Upload_File;

// ------------------------------------------------------------
// Contrôleur AuthController
// Regroupe toutes les actions liées à l'authentification et la
// gestion du compte utilisateur :
//   • Register   : inscription et affectation des ZAPs
//   • Login      : connexion
//   • Logout     : déconnexion
//   • ForgotPwd  : demande de réinitialisation
//   • ResetPwd   : réinitialisation via token
//   • ConfirmEmail : validation de l'adresse mail
// Chaque action s'appuie sur IAuthService pour la logique métier
// et sur IEmailSender pour la communication email.
// ------------------------------------------------------------

namespace PFE_Etudiant_Asteelflash.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService; // Encapsule la logique d'authentification
        private readonly IZapServices _zapServices; // CRUD et listing des ZAPs
        private readonly IEmailSender _emailSender; // Service d'envoi d'emails (confirmation, reset)
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;

        public AuthController(IAuthService authService,
                              IEmailSender emailSender,
                              IZapServices zapServices,
                              IMapper mapper,
                              IFileHelper fileHelper)
        {
            _authService = authService;
            _emailSender = emailSender;
            _zapServices = zapServices;
            _mapper = mapper;
            _fileHelper = fileHelper;
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {
            // Récupération de tous les ZAPs
            var allZaps = await _zapServices.GetAllZapsAsync();

            // Mapping manuel vers SelectListItem
            var zapSelectList = allZaps.Select(z => new SelectListItem
            {
                Text = z.Name.ToString(),     // Adapter selon la propriété affichée
                Value = z.Id.ToString()
            }).ToList();

            // Initialiser le ViewModel
            var viewModel = new RegisterViewModel
            {
                ZapList = zapSelectList
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                // Récupération de tous les ZAPs
                var allZaps = await _zapServices.GetAllZapsAsync();

                // Mapping manuel vers SelectListItem
                var zapSelectList = allZaps.Select(z => new SelectListItem
                {
                    Text = z.Name.ToString(),     // Adapter selon la propriété affichée
                    Value = z.Id.ToString()
                }).ToList();

                // Initialiser le ViewModel
                var viewModel = new RegisterViewModel
                {
                    ZapList = zapSelectList
                };

                return View(viewModel);
            }
            
            // Vérifier si les ZAP sélectionnées existent
            if (registerViewModel.ZapIds == null || !registerViewModel.ZapIds.Any())
            {
                TempData["error"] = "Veuillez sélectionner au moins une ZAP.";
                return RedirectToAction("Register");
            }

            foreach (var zapId in registerViewModel.ZapIds)
            {
                if (await _zapServices.GetZapByIdAsync(zapId) == null)
                {
                    TempData["error"] = "Une des ZAP sélectionnées n'existe pas dans le système. Veuillez sélectionner des ZAP valides.";
                    return RedirectToAction("Register");
                }
            }
            try
            {
                // Gestion de l'upload de l'image de profil
                string? imagePath = null;
                if (registerViewModel.ProfileImage != null && registerViewModel.ProfileImage.Length > 0)
                {
                    var fileName = _fileHelper.UploadFile(registerViewModel.ProfileImage, "images/profiles");
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        imagePath = $"/images/profiles/{fileName}";
                    }
                }

                // Convertir RegisterViewModel en RegistrationRequestDto avec AutoMapper
                var registrationRequestDto = _mapper.Map<RegistrationRequestDto>(registerViewModel);
                registrationRequestDto.ProfileImagePath = imagePath;

                var result = await _authService.Register(registrationRequestDto);
                if (result == "Inscription réussie!")
                {
                    // Récupérer les informations nécessaires pour l'email de confirmation
                    var user = await _authService.GetUserByEmail(registrationRequestDto.Email);
                    var token = await _authService.GenerateEmailConfirmationToken(user.Id);

                    // Envoyer l'email de confirmation
                    await _emailSender.SendEmailConfirmationAsync(registrationRequestDto.Email, token, user.Id);

                    TempData["success"] = "Inscription réussie. Veuillez vérifier votre email pour confirmer votre compte.";
                    return RedirectToAction(nameof(Login));
                }

                TempData["error"] = "Erreur d'inscription";
                ModelState.AddModelError(string.Empty, result);

                return RedirectToAction("Register");
            }
            catch(Exception ex)
            {
                TempData["error"]=($"Erreur d'envoi d'email: {ex.Message}");
                return RedirectToAction("Register");
            }
            
        }


        [HttpGet]
        public IActionResult Login()
        {
            // Vérifier si l'utilisateur est déjà connecté
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginRequestDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return View(loginRequestDto);
            }

            var currentUser = await _authService.GetUserByMatriculeAsync(loginRequestDto.Matricule);
            if (currentUser == null || !currentUser.IsActive)
            {
                TempData["error"] = "Identifiants invalides";
                ModelState.AddModelError(string.Empty, "Matricule ou mot de passe incorrect.");
                return View(loginRequestDto);
            }

            var result = await _authService.CheckConfirmedEmail(currentUser.Email);
            if (result == null)
            {
                TempData["error"] = "Identifiants invalides";
                ModelState.AddModelError(string.Empty, "Matricule ou mot de passe incorrect.");
                return View(loginRequestDto);
            }

            if (result == false)
            {
                TempData["error"] = "Votre email est pas encore confirmé";
                ModelState.AddModelError(string.Empty, "Votre email est pas encore confirmé.");
                return View(loginRequestDto);
            }

            var user = await _authService.Login(loginRequestDto);
            if (user.IsSuccess)
            {
                TempData["success"] = "Connexion réussie";
                return RedirectToAction("Index", "Home");
            }

            TempData["error"] = "Identifiants invalides";
            ModelState.AddModelError(string.Empty, "Matricule ou mot de passe incorrect.");
            return View(loginRequestDto);
        }


        public async Task<IActionResult> Logout()
        {
            var result = await _authService.Logout();
            if (result)
            {
                TempData["success"] = "Déconnexion réussie";
                return RedirectToAction(nameof(Login));
            }
            TempData["error"] = "Erreur lors de la déconnexion";
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string token, string userId)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userId))
            {
                TempData["error"] = "Lien de confirmation invalide";
                return RedirectToAction("Index", "Home");
            }

            var result = await _authService.ConfirmEmail(userId, token);
            if (result)
            {
                // Récupérer l'utilisateur pour obtenir son email et son nom d'utilisateur
                var user = await _authService.GetUserById(userId);

                // Envoyer un email de bienvenue
                await _emailSender.SendWelcomeEmailAsync(user.Email, user.UserName);

                TempData["success"] = "Email confirmé avec succès. Vous pouvez maintenant vous connecter.";
                return RedirectToAction(nameof(Login));
            }

            TempData["error"] = "Échec de la confirmation de l'email";
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ModelState.AddModelError(string.Empty, "L'adresse email est requise");
                return View();
            }

            var user = await _authService.GetUserByEmail(email);
            if (user != null)
            {
                var token = await _authService.GeneratePasswordResetToken(user.Id);
                await _emailSender.SendPasswordResetEmailAsync(email, token, user.Id);
            }

            // Pour des raisons de sécurité, ne pas révéler si l'email existe ou non
            TempData["success"] = "Si votre email existe dans notre système, vous recevrez un lien de réinitialisation de mot de passe.";
            return RedirectToAction(nameof(Login));
        }



        [HttpGet]
        public IActionResult ResetPassword(string token, string userId)
        {
            if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(userId))
            {
                TempData["error"] = "Lien de réinitialisation invalide";
                return RedirectToAction("Index", "Home");
            }

            var model = new ResetPasswordDto { Token = token, UserId = userId };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _authService.ResetPassword(model.UserId, model.Token, model.NewPassword);
            if (result)
            {
                TempData["success"] = "Mot de passe réinitialisé avec succès. Vous pouvez maintenant vous connecter avec votre nouveau mot de passe.";
                return RedirectToAction(nameof(Login));
            }

            TempData["error"] = "Échec de la réinitialisation du mot de passe";
            ModelState.AddModelError(string.Empty, "Lien de réinitialisation invalide ou expiré");
            return View(model);
        }
    }
}
