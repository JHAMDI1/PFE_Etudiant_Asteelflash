using System;
using System.Security.Claims;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Réclamation.Dtos;
using PFE_Etudiant_Asteelflash.Application.Réclamation.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
namespace PFE_Etudiant_Asteelflash.Controllers
{
    [Authorize]
    public class ReclamationController : Controller
    {
        private readonly IReclamationServices _services;
        private readonly UserManager<ApplicationUser> _users;

        public ReclamationController(IReclamationServices services, UserManager<ApplicationUser> users)
        {
            _services = services;
            _users = users;
        }

        // GET: /Reclamation/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Reclamation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateReclamationDto dto)
        {
            // Attacher l'utilisateur courant AVANT la validation afin que UserId soit présent
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            dto.UserId = userId;

            // Retirer la clé UserId de ModelState (elle était null lors du binding) puis revalider
            ModelState.Remove(nameof(dto.UserId));
            if (!TryValidateModel(dto))
            {
                return View(dto);
            }

            if (!ModelState.IsValid)
            {
                return View(dto);
            }
         
            try
            {
                var created = await _services.CreateAsync(dto);
                if (created != null)
                {
                    TempData["Success"] = "Réclamation envoyée avec succès.";
                    return RedirectToAction("Index", "Home");
                }

                TempData["Error"] = "La réclamation n'a pas été envoyée.";
                return View(dto);
            }
            catch (Exception)
            {
                TempData["Error"] = "Une erreur est survenue lors de l'envoi de la réclamation.";
                return View(dto);
            }
        }

        // GET: /Reclamation/Index
        public async Task<IActionResult> Index()
        {
            var list = await _services.GetAllAsync();
            return View(list);
        }

        // GET: /Reclamation/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var reclamation = await _services.GetByIdAsync(id);
            if (reclamation == null)
            {
                return NotFound();
            }
            return View(reclamation);
        }
    }
}
