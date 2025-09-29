using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Fnc.Dtos;
using PFE_Etudiant_Asteelflash.Application.Fnc.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Zap.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Enums;
using PFE_Etudiant_Asteelflash.Models.Fnc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using PFE_Etudiant_Asteelflash.Domain.Entities;

// ------------------------------------------------------------
// Contrôleur FncController
// Gère le cycle de vie complet des FNC (création, consultation, 
// modification, suppression) ainsi que le workflow d'approbation/
// rejet par les différents acteurs (conducteur, chef d'équipe,
// responsable, ingénieur).
// Chaque action revient à déléguer la logique métier à la couche
// Application (IFncServices) et à mapper les DTOs vers des
// ViewModels pour les vues Razor.
// ------------------------------------------------------------

namespace PFE_Etudiant_Asteelflash.Controllers
{
    public class FncController : Controller
    {
        private readonly IFncServices _fncServices; // Service applicatif principal manipulant les FNC
        private readonly IZapServices _zapServices; // Service pour récupérer les ZAPs (ateliers)
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager; // Gestion des utilisateurs
        private readonly SignInManager<ApplicationUser> _signInManager; // Gestion de la session de connexion

        public FncController(IFncServices fncServices, IMapper mapper,  
                             IZapServices zapServices, 
                             UserManager<ApplicationUser> userManager, 
                             SignInManager<ApplicationUser> signInManager)
        {
            _fncServices = fncServices;
            _mapper = mapper;
            _zapServices = zapServices;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        // GET: Fnc
        public async Task<IActionResult> Index(string searchTerm, string status, string defaut, string typeFnc, string impact, string action)
        {
            try
            {
                // Appliquer les filtres lorsque l'utilisateur en sélectionne au moins un
                if (!string.IsNullOrEmpty(status) ||
                    !string.IsNullOrEmpty(defaut) ||
                    !string.IsNullOrEmpty(typeFnc) ||
                    !string.IsNullOrEmpty(impact) ||
                    !string.IsNullOrEmpty(action))
                {
                    var filter = new FncFilterDto
                    {
                        Status = status
                    };

                    // Parse Type Défaut
                    if (!string.IsNullOrWhiteSpace(defaut))
                    {
                        if (int.TryParse(defaut, out var defautInt))
                            filter.TypeDefaut = (TypeDefaut)defautInt;
                        else if (Enum.TryParse<TypeDefaut>(defaut, true, out var defautEnum))
                            filter.TypeDefaut = defautEnum;
                    }

                    // Parse Type FNC
                    if (!string.IsNullOrWhiteSpace(typeFnc))
                    {
                        if (int.TryParse(typeFnc, out var typeFncInt))
                            filter.TypeFnc = (TypeFnc)typeFncInt;
                        else if (Enum.TryParse<TypeFnc>(typeFnc, true, out var typeFncEnum))
                            filter.TypeFnc = typeFncEnum;
                    }

                    // Parse Impact
                    if (!string.IsNullOrWhiteSpace(impact))
                    {
                        if (int.TryParse(impact, out var impactInt))
                            filter.NcImpact = (NcImpact)impactInt;
                        else if (Enum.TryParse<NcImpact>(impact, true, out var impactEnum))
                            filter.NcImpact = impactEnum;
                    }

                    // Parse Action Immédiate
                    if (!string.IsNullOrWhiteSpace(action))
                    {
                        if (int.TryParse(action, out var actionInt))
                            filter.ActionImm = (ActionImm)actionInt;
                        else if (Enum.TryParse<ActionImm>(action, true, out var actionEnum))
                            filter.ActionImm = actionEnum;
                    }

                    var filteredFncs = await _fncServices.FilterFncsAsync(filter);
                    var viewModels = _mapper.Map<IEnumerable<FncIndexViewModel>>(filteredFncs).ToList();

                    // S'assurer que chaque ViewModel contient les listes de filtres
                    foreach (var vm in viewModels)
                    {
                        InitializeFilterOptions(vm);
                    }

                    // Stocke les filtres dans ViewData pour la persistance
                    ViewData["Status"] = status;
                    ViewData["defaut"] = defaut;
                    ViewData["typeFnc"] = typeFnc;
                    ViewData["impact"] = impact;
                    ViewData["action"] = action;
                    
                    return View(viewModels);
                }
                
                // Get data based on search or full list
                IEnumerable<FncListItemDto> fncDtos;
                
                if (!string.IsNullOrEmpty(searchTerm))
                {
                    // Search functionality
                    fncDtos = await _fncServices.SearchFncsAsync(searchTerm);
                }
                else
                {
                    // Get all FNCs
                    fncDtos = await _fncServices.GetAllFncsAsync();
                }
                
                // Map DTOs to ViewModels
                var allViewModels = _mapper.Map<IEnumerable<FncIndexViewModel>>(fncDtos).ToList();
                
                // Initialize filter options for each view model
                foreach (var viewModel in allViewModels)
                {
                    InitializeFilterOptions(viewModel);
                }
                
                // Pass the search term to the view for form persistence
                ViewData["SearchTerm"] = searchTerm;
                
                return View(allViewModels);
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur interne s'est produite. Veuillez réessayer plus tard.";
                return View(Enumerable.Empty<FncIndexViewModel>());
            }
        }

        // GET: Fnc/ByStatus/{status}
        public async Task<IActionResult> ByStatus(string status)
        {
            try
            {
                var fncs = await _fncServices.GetFncsByStatusAsync(status);
                var viewModels = _mapper.Map<IEnumerable<FncIndexViewModel>>(fncs).ToList();
                ViewData["Status"] = status;
                return View("Index", viewModels);
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur s'est produite lors de la récupération des données";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Fnc/ByDate?date=yyyy-MM-dd
        public async Task<IActionResult> ByDate(DateTime date)
        {
            try
            {
                var fncs = await _fncServices.GetFncsByDateAsync(date);
                var viewModels = _mapper.Map<IEnumerable<FncIndexViewModel>>(fncs).ToList();
                ViewData["SelectedDate"] = date.ToString("yyyy-MM-dd");
                return View("Index", viewModels);
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur s'est produite lors de la récupération des données";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Fnc/Search?term=xxx
        public async Task<IActionResult> Search(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
            {
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var fncs = await _fncServices.SearchFncsAsync(term);
                var viewModels = _mapper.Map<IEnumerable<FncIndexViewModel>>(fncs).ToList();
                ViewData["SearchTerm"] = term;
                return View("Index", viewModels);
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur s'est produite lors de la recherche";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Fnc/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var fncDto = await _fncServices.GetFncByIdWithDetailsAsync(id);
                if (fncDto == null)
                {
                    return NotFound();
                }
                
                var viewModel = _mapper.Map<FncDetailsViewModel>(fncDto);

                // Déterminer si l'utilisateur connecté est destinataire
                var currentUserId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                if (!string.IsNullOrEmpty(currentUserId))
                {
                    viewModel.IsRecipient = await _fncServices.IsUserRecipientAsync(id, currentUserId);
                    var currentUser = await _signInManager.UserManager.GetUserAsync(User);
                    viewModel.IsConducteur = currentUser?.Fonction == Fonction.Conducteur;
                }

                return View(viewModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur interne s'est produite. Veuillez réessayer plus tard.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Fnc/Create
        public async Task<IActionResult> Create()
        {
            // Récupérer l'utilisateur actuellement connecté
            var currentUser = await _signInManager.UserManager.GetUserAsync(User);

            var viewModel = new FncCreateViewModel
            {
                Date = DateTime.Today,
                Hour = DateTime.Now.TimeOfDay,
                // Définir les informations de l'émetteur (utilisateur actuel)
                TransmitterId = currentUser?.Id,
                TransmitterFullName = currentUser != null ? $"{currentUser.FirstName} {currentUser.LastName}" : "Utilisateur inconnu"
            };
            
            // Load dropdown data
            await PopulateCreateFormDropdowns(viewModel);

            // Si l'utilisateur est Contrôleur, charger tous les conducteurs pour la liste déroulante
            if (currentUser?.Fonction == Fonction.Controleur)
            {
                var conducteurs = _userManager.Users
                    .Where(u => u.Fonction == Fonction.Conducteur)
                    .Select(u => new { u.Id, FullName = u.FirstName + " " + u.LastName })
                    .ToList();
                viewModel.ConducteurOptions = new SelectList(conducteurs, "Id", "FullName");
            }
            
            return View(viewModel);
        }

        // POST: Fnc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FncCreateViewModel viewModel)
        {
            if (!ModelState.IsValid)
            { // Récupérer l'utilisateur actuellement connecté
                var currentUser = await _signInManager.UserManager.GetUserAsync(User);

                var viewModelReloaded = new FncCreateViewModel
                {
                    Date = DateTime.Today,
                    Hour = DateTime.Now.TimeOfDay,
                    // Définir les informations de l'émetteur (utilisateur actuel)
                    TransmitterId = currentUser?.Id,
                    TransmitterFullName = currentUser != null ? $"{currentUser.FirstName} {currentUser.LastName}" : "Utilisateur inconnu"
                };
                // Reload dropdown data on error
                await PopulateCreateFormDropdowns(viewModelReloaded);

                var isControleur = currentUser?.Fonction == Fonction.Controleur;
                if (isControleur)
                {
                    var conducteurs = _userManager.Users
                        .Where(u => u.Fonction == Fonction.Conducteur)
                        .Select(u => new { u.Id, FullName = u.FirstName + " " + u.LastName })
                        .ToList();
                    viewModelReloaded.ConducteurOptions = new SelectList(conducteurs, "Id", "FullName");
                }
                return View(viewModelReloaded);
            }

            try
            {
                // Map view model to DTO
                var createFncDto = _mapper.Map<CreateFncDto>(viewModel);
                
                // Définir manuellement le TransmitterID car il est requis mais n'est pas dans le ViewModel
                // En utilisant l'utilisateur actuellement connecté comme transmetteur par défaut
                var userId = _userManager.GetUserId(User);
                createFncDto.TransmitterID = !string.IsNullOrEmpty(userId) ? userId : "default-user-id";
                

                
                var createdFnc = await _fncServices.CreateFncAsync(createFncDto);
                if (createdFnc != null)
                {
                    TempData["Success"] = "La FNC a été créée avec succès.";
                    // Rediriger vers les détails de la FNC nouvellement créée
                    return RedirectToAction(nameof(Details), new { id = createdFnc.Id });
                }

                // Si la création a échoué sans lever d'exception
                TempData["Error"] = "La création de la FNC a échoué.";
                await PopulateCreateFormDropdowns(viewModel);
                return View(viewModel);
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur s'est produite lors de la création de la FNC. Veuillez réessayer.";
                await PopulateCreateFormDropdowns(viewModel);
                return View(viewModel);
            }
        }

        // GET: Fnc/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var fncDto = await _fncServices.GetFncByIdAsync(id);
                if (fncDto == null)
                {
                    return NotFound();
                }
                
                var viewModel = _mapper.Map<FncEditViewModel>(fncDto);
                
                // Load dropdown data
                await PopulateEditFormDropdowns(viewModel);
                
                return View(viewModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Une erreur interne s'est produite. Veuillez réessayer plus tard.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Fnc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FncEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                // Reload dropdown data on error
                await PopulateEditFormDropdowns(viewModel);
                return View(viewModel);
            }

            try
            {
                // Map view model to DTO
                var updateFncDto = _mapper.Map<UpdateFncDto>(viewModel);
                

                
                var success = await _fncServices.UpdateFncAsync(updateFncDto);
                if (!success)
                {
                    TempData["Error"] = "La mise à jour a échoué. Veuillez réessayer.";
                    await PopulateEditFormDropdowns(viewModel);
                    return View(viewModel);
                }
                
                TempData["Success"] = "La FNC a été mise à jour avec succès.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur s'est produite lors de la mise à jour de la FNC. Veuillez réessayer.";
                await PopulateEditFormDropdowns(viewModel);
                return View(viewModel);
            }
        }
        
        // Helper method to populate dropdowns for Edit form
        private async Task PopulateEditFormDropdowns(FncEditViewModel viewModel)
        {
            try
            {
                // Get ZAP list for dropdown
                var zaps = await _zapServices.GetAllZapsAsync();
                viewModel.ZapOptions = zaps.Select(z => new SelectListItem
                {
                    Value = z.Id.ToString(),
                    Text = z.Name.ToString(),
                    Selected = z.Id == viewModel.ZapEmettriceId || z.Id == viewModel.ZapReceptriceId
                }).ToList();                            
                
                // User options using UserManager
                var users = _userManager.Users
                    .Select(u => new { u.Id, FullName = u.FirstName + " " + u.LastName })
                    .ToList();
                
                viewModel.UserOptions = users.Select(u => new SelectListItem
                {
                    Value = u.Id,
                    Text = u.FullName,
                    Selected = u.Id == viewModel.TransmitterId || u.Id == viewModel.ProcessorId
                }).ToList();
                
                // Initialisation des options pour les enums
                viewModel.TypeDefautOptions = Enum.GetValues(typeof(TypeDefaut))
                    .Cast<TypeDefaut>()
                    .Select(e => new SelectListItem
                    {
                        Value = ((int)e).ToString(),
                        Text = e.ToString().Replace("_", " "),
                        Selected = e == viewModel.TypeDefaut
                    })
                    .ToList();
                
                viewModel.TypeFncOptions = Enum.GetValues(typeof(TypeFnc))
                    .Cast<TypeFnc>()
                    .Select(e => new SelectListItem
                    {
                        Value = ((int)e).ToString(),
                        Text = e.ToString().Replace("_", " "),
                        Selected = e == viewModel.TypeFnc
                    })
                    .ToList();
                
                viewModel.NcImpactOptions = Enum.GetValues(typeof(NcImpact))
                    .Cast<NcImpact>()
                    .Select(e => new SelectListItem
                    {
                        Value = ((int)e).ToString(),
                        Text = e.ToString().Replace("_", " "),
                        Selected = e == viewModel.NcImpact
                    })
                    .ToList();
                
                viewModel.ActionImmediateOptions = Enum.GetValues(typeof(ActionImm))
                    .Cast<ActionImm>()
                    .Select(e => new SelectListItem
                    {
                        Value = ((int)e).ToString(),
                        Text = e.ToString().Replace("_", " "),
                        Selected = e == viewModel.ActionImmediate
                    })
                    .ToList();
            }
            catch (Exception)
            {
                // Handle error silently, let the controller action handle the response
            }
        }
        
        // Helper method to populate dropdowns for Create and Edit forms
        private async Task PopulateCreateFormDropdowns(FncCreateViewModel viewModel)
        {
            try
            {
                // Get ZAP list for dropdown
                var zaps = await _zapServices.GetAllZapsAsync();
                viewModel.ZapOptions = new SelectList(zaps, "Id", "Name");
                
                //// Statically defined lists for dropdowns using SelectList
                //var statusItems = new List<SelectListItem>
                //{
                //    new SelectListItem { Value = "ouvert", Text = "Ouvert" },
                //    new SelectListItem { Value = "en-cours", Text = "En cours" },
                //    new SelectListItem { Value = "ferme", Text = "Fermé" },
                //    new SelectListItem { Value = "annule", Text = "Annulé" }
                //};
                //viewModel.StatusOptions = new SelectList(statusItems, "Value", "Text");
                
                var typeItems = new List<SelectListItem>
                {
                    new SelectListItem { Value = "0", Text = "Client" },
                    new SelectListItem { Value = "1", Text = "Interne" },
                    new SelectListItem { Value = "2", Text = "Fournisseur" }
                };
                viewModel.TypeOptions = new SelectList(typeItems, "Value", "Text");
                
                // User options using UserManager
                var users = _userManager.Users
                    .Select(u => new { u.Id, FullName = u.FirstName + " " + u.LastName })
                    .ToList();
                viewModel.UserOptions = new SelectList(users, "Id", "FullName");
                
                // Initialisation des nouvelles propriétés SelectList pour les enums
                viewModel.TypeDefautOptions = new SelectList(
                    Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.TypeDefaut))
                        .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.TypeDefaut>()
                        .Select(e => new { Value = (int)e, Text = e.ToString().Replace("_", " ") }),
                    "Value", "Text"
                );
                
                viewModel.NcImpactOptions = new SelectList(
                    Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.NcImpact))
                        .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.NcImpact>()
                        .Select(e => new { Value = (int)e, Text = e.ToString().Replace("_", " ") }),
                    "Value", "Text"
                );
                
                viewModel.ActionImmediateOptions = new SelectList(
            Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.ActionImm))
                .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.ActionImm>()
                .Select(e => new { Value = (int)e, Text = e.ToString().Replace("_", " ") }),
            "Value", "Text"
        );

        // CMS, Vague & Préparation line dropdowns
        viewModel.CMSLineOptions = new SelectList(
            Enum.GetValues(typeof(CMS_Lignes))
                .Cast<CMS_Lignes>()
                .Select(e => new { Value = (int)e, Text = e.ToString().Replace("_", " ") }),
            "Value", "Text"
        );

        viewModel.VagueLineOptions = new SelectList(
            Enum.GetValues(typeof(Vague_Lignes))
                .Cast<Vague_Lignes>()
                .Select(e => new { Value = (int)e, Text = e.ToString().Replace("_", " ") }),
            "Value", "Text"
        );

        viewModel.PreparationLineOptions = new SelectList(
            Enum.GetValues(typeof(Preparaation_Lignes))
                .Cast<Preparaation_Lignes>()
                .Select(e => new { Value = (int)e, Text = e.ToString().Replace("_", " ") }),
            "Value", "Text"
        );
            }
            catch (Exception)
            {
                // Handle error silently, let the controller action handle the response
            }
        }

        // GET: Fnc/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var fncDto = await _fncServices.GetFncByIdAsync(id);
                if (fncDto == null)
                {
                    return NotFound();
                }
                
                var viewModel = _mapper.Map<FncDeleteViewModel>(fncDto);
                return View(viewModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur interne s'est produite. Veuillez réessayer plus tard.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Fnc/Accept
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Accept(int id)
        {
            var currentUserId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return Forbid();

            // Appel de la couche Application pour enregistrer l'approbation conducteur
            var success = await _fncServices.AcceptFncAsync(id, currentUserId);
            if (success)
            {
                TempData["Success"] = "La FNC a été approuvée avec succès.";
            }
            else
            {
                TempData["Error"] = "Vous n'êtes pas autorisé ou une erreur est survenue.";
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: Fnc/Reject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var currentUserId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(currentUserId))
                return Forbid();

            var success = await _fncServices.RejectFncAsync(id, currentUserId);
            if (success)
            {
                TempData["Success"] = "La FNC a été rejetée avec succès.";
            }
            else
            {
                TempData["Error"] = "Vous n'êtes pas autorisé ou une erreur est survenue.";
            }

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: Fnc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var result = await _fncServices.DeleteFncAsync(id);
                if (!result)
                {
                    return NotFound();
                }
                TempData["Success"] = "La FNC a été supprimée avec succès.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur s'est produite lors de la suppression. Veuillez réessayer.";
                return RedirectToAction(nameof(Index));
            }
        }
        
        // Helper method to initialize filter options for Index view
        private void InitializeFilterOptions(FncIndexViewModel viewModel)
        {
            // Initialize dictionary if null
            viewModel.FilterOptions = viewModel.FilterOptions ?? new Dictionary<string, List<SelectListItem>>();
            
            // Status filter options
            viewModel.FilterOptions["Status"] = new List<SelectListItem>
            {
                new SelectListItem { Value = "ouvert", Text = "Ouvert" },
                new SelectListItem { Value = "en-cours", Text = "En cours" },
                new SelectListItem { Value = "ferme", Text = "Fermé" },
                new SelectListItem { Value = "annule", Text = "Annulé" }
            };
            
            // Type FNC filter options
            viewModel.FilterOptions["typeFnc"] = Enum.GetValues(typeof(TypeFnc))
                .Cast<TypeFnc>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString().Replace("_", " ")
                })
                .ToList();
                
            // Type Défaut filter options
            viewModel.FilterOptions["defaut"] = Enum.GetValues(typeof(TypeDefaut))
                .Cast<TypeDefaut>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString().Replace("_", " ")
                })
                .ToList();

            // Action immédiate filter options
            viewModel.FilterOptions["action"] = Enum.GetValues(typeof(ActionImm))
                .Cast<ActionImm>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString().Replace("_", " ")
                })
                .ToList();

            // Impact filter options
            viewModel.FilterOptions["impact"] = Enum.GetValues(typeof(NcImpact))
                .Cast<NcImpact>()
                .Select(e => new SelectListItem
                {
                    Value = ((int)e).ToString(),
                    Text = e.ToString().Replace("_", " ")
                })
                .ToList();
        }
        
        // GET: Fnc/Statistics
        public async Task<IActionResult> Statistics(DateTime? startDate, DateTime? endDate)
        {
            try
            {
                // Set default date range if not provided
                startDate ??= DateTime.Today.AddMonths(-1);
                endDate ??= DateTime.Today;
                
                // Get statistics from service
                var statisticsDto = await _fncServices.GetFncStatisticsAsync();
                if (statisticsDto == null)
                {
                    TempData["Warning"] = "Aucune donnée statistique disponible.";
                    return View(new FncStatisticsViewModel
                    {
                        StartDate = startDate.Value,
                        EndDate = endDate.Value,
                        FncsByStatus = new Dictionary<string, int>(),
                        FncsByZap = new Dictionary<string, int>(),
                        FncsByMonth = new Dictionary<string, int>(),
                        FncsByTypeDefaut = new Dictionary<string, int>()
                    });
                }
                
                // Map DTO to view model
                var statisticsViewModel = _mapper.Map<FncStatisticsViewModel>(statisticsDto);
                statisticsViewModel.StartDate = startDate.Value;
                statisticsViewModel.EndDate = endDate.Value;
                
                return View(statisticsViewModel);
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur s'est produite lors de la récupération des statistiques. Veuillez réessayer plus tard.";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
