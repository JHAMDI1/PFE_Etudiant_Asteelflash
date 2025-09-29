using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Fnc.Interfaces;
using PFE_Etudiant_Asteelflash.Models.Qrqc;
using PFE_Etudiant_Asteelflash.Application.Fnc.Dtos;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.External;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Dtos;

namespace PFE_Etudiant_Asteelflash.Controllers
{
    public class QrqcController : Controller
    {
        private readonly IQrqcServices _qrqcServices;
        private readonly IMapper _mapper;
        private readonly IFncServices _fncServices;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IQuantitéTriéeParJourServices _quantiteServices;
        private readonly IEquipeServices _equipeServices;
        private readonly INotificationService _notificationService;

        public QrqcController(IQrqcServices qrqcServices,
            IMapper mapper,
            IFncServices fncServices,
            UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            IQuantitéTriéeParJourServices quantiteServices,
            IEquipeServices equipeServices,
            INotificationService notificationService)
        {
            _qrqcServices = qrqcServices;
            _mapper = mapper;
            _fncServices = fncServices;
            _userManager = userManager;
            _context = context;
            _quantiteServices = quantiteServices;
            _equipeServices = equipeServices;
            _notificationService = notificationService;
        }
        // GET: QrqcController
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var qrqcs = await _qrqcServices.GetAllQrqcAsync();
            return View(qrqcs);
        }

        // POST: QrqcController/RequestCloture/5
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RequestCloture(int id)
        {
            var qrqc = await _context.Qrqc.Include(q => q.FNC).FirstOrDefaultAsync(q => q.Id == id);
            if (qrqc == null) return NotFound();

            // Générer token unique valable 7 jours
            qrqc.Status = PFE_Etudiant_Asteelflash.Domain.Enums.QrqcStatus.ClotureDemandee;
            qrqc.ClotureToken = Guid.NewGuid();
            qrqc.ClotureTokenExpiry = DateTime.UtcNow.AddDays(7);
            await _context.SaveChangesAsync();

            // Résoudre destinataires (Responsable & Chef d'équipe du même ZAP que FNC)
            var zapIds = new List<int>();
            if (qrqc.FNC != null)
            {
                if (qrqc.FNC.ZapReceptriceId.HasValue)
                    zapIds.Add(qrqc.FNC.ZapReceptriceId.Value);
                if (qrqc.FNC.ZapEmettriceId.HasValue)
                    zapIds.Add(qrqc.FNC.ZapEmettriceId.Value);
            }
            var recipients = await _userManager.Users
                .Where(u => u.UsersZaps.Any(uz => zapIds.Contains(uz.ZapId)))
                .Where(u => (u.Fonction == PFE_Etudiant_Asteelflash.Domain.Enums.Fonction.Responsable || u.Fonction == PFE_Etudiant_Asteelflash.Domain.Enums.Fonction.Chef_Equipe))
                .Where(u => u.Id != _userManager.GetUserId(User)) // exclure le demandeur
                .Select(u => u.Id)
                .ToListAsync();

            var link = Url.Action("Cloture", "Qrqc", new { id = qrqc.Id, token = qrqc.ClotureToken }, Request.Scheme);
            await _notificationService.SendAsync(recipients, $"Demande de clôture QRQC n°{qrqc.Id}", "DemandeCloture", link);

            TempData["Success"] = "Demande de clôture envoyée.";
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: QrqcController/Cloture/5
        [Authorize]
        public async Task<IActionResult> Cloture(int id, Guid token)
        {
            var qrqc = await _context.Qrqc
                .Include(q => q.FNC)
                .FirstOrDefaultAsync(q => q.Id == id);
            if (qrqc == null) return NotFound();
            if (qrqc.ClotureToken == null || qrqc.ClotureToken != token || qrqc.ClotureTokenExpiry < DateTime.UtcNow)
            {
                return BadRequest("Lien expiré ou invalide.");
            }
            // Autorisation simplifiée: rôle Responsable_ZAP ou ChefEquipe_ZAP
            if (!User.IsInRole("Responsable_ZAP") && !User.IsInRole("ChefEquipe_ZAP"))
                return Forbid();

            return View("ClotureDetails", qrqc); // vue lecture seule
        }

        // GET: QrqcController/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            var qrqcDto = await _qrqcServices.GetGlobalQrqcByIdAsync(id);
            if (qrqcDto == null)
            {
                return NotFound();
            }
            return View(qrqcDto);
        }

        // POST: QrqcController/ApproveCloture
        [HttpPost]
        [Authorize(Roles = "Responsable_ZAP,ChefEquipe_ZAP")]
        public async Task<IActionResult> ApproveCloture(int id, Guid token)
        {
            var qrqc = await _context.Qrqc.Include(q => q.Processor).FirstOrDefaultAsync(q => q.Id == id);
            if (qrqc == null) return NotFound();
            if (qrqc.ClotureToken != token || qrqc.ClotureTokenExpiry < DateTime.UtcNow)
                return BadRequest("Lien expiré ou invalide.");

            qrqc.Status = PFE_Etudiant_Asteelflash.Domain.Enums.QrqcStatus.Cloturee;
            qrqc.ClotureDecisionById = _userManager.GetUserId(User);
            qrqc.ClotureDecisionAt = DateTime.UtcNow;
            qrqc.ClotureDecisionComment = null;
            qrqc.ClotureToken = null;
            qrqc.ClotureTokenExpiry = null;
            await _context.SaveChangesAsync();

            // notifier créateur/processor
            if (qrqc.ProcessorID != null)
            {
                var link = Url.Action("Details", "Qrqc", new { id = qrqc.Id }, Request.Scheme);
                await _notificationService.SendAsync(new[] { qrqc.ProcessorID }, $"QRQC n°{qrqc.Id} clôturé", "Cloturee", link);
            }
            TempData["Success"] = "QRQC clôturé avec succès.";
            return RedirectToAction(nameof(Index));
        }

        // POST: QrqcController/RejectCloture
        [HttpPost]
        [Authorize(Roles = "Responsable_ZAP,ChefEquipe_ZAP")]
        public async Task<IActionResult> RejectCloture(int id, Guid token, string reason)
        {
            var qrqc = await _context.Qrqc.Include(q => q.Processor).FirstOrDefaultAsync(q => q.Id == id);
            if (qrqc == null) return NotFound();
            if (qrqc.ClotureToken != token || qrqc.ClotureTokenExpiry < DateTime.UtcNow)
                return BadRequest("Lien expiré ou invalide.");

            qrqc.Status = PFE_Etudiant_Asteelflash.Domain.Enums.QrqcStatus.Rejetee;
            qrqc.ClotureDecisionById = _userManager.GetUserId(User);
            qrqc.ClotureDecisionAt = DateTime.UtcNow;
            qrqc.ClotureDecisionComment = reason;
            qrqc.ClotureToken = null;
            qrqc.ClotureTokenExpiry = null;
            await _context.SaveChangesAsync();

            // notifier créateur
            if (qrqc.ProcessorID != null)
            {
                var link = Url.Action("Details", "Qrqc", new { id = qrqc.Id }, Request.Scheme);
                var msg = $"QRQC n°{qrqc.Id} rejeté" + (!string.IsNullOrWhiteSpace(reason) ? $": {reason}" : string.Empty);
                await _notificationService.SendAsync(new[] { qrqc.ProcessorID }, msg, "Rejetee", link);
            }
            TempData["Success"] = "QRQC rejeté.";
            return RedirectToAction(nameof(Index));
        }

        // GET: QrqcController/QuantiteChart/5
        [Authorize]
        public async Task<IActionResult> QuantiteChart(int id)
        {
            var qrqc = await _context.Qrqc
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ActionImmediateGlobale)
                        .ThenInclude(ai => ai.TriActionImmediateGlobales!)
                            .ThenInclude(t => t.QuantitéTriéeParJour)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (qrqc == null)
            {
                return NotFound();
            }

            var quantite = qrqc.actionDeSecurisation?
                .ActionImmediateGlobale?
                .TriActionImmediateGlobales?
                .FirstOrDefault()?
                .QuantitéTriéeParJour;

            var vm = new QuantiteChartViewModel
            {
                QrqcId = id,
                Jour1 = quantite?.Jour1 ?? 0,
                Jour2 = quantite?.Jour2 ?? 0,
                Jour3 = quantite?.Jour3 ?? 0,
                Jour4 = quantite?.Jour4 ?? 0,
                Jour5 = quantite?.Jour5 ?? 0
            };

            return View(vm);
        }

        // GET: QrqcController/Create
        public async Task<IActionResult> Create(int fncId)
        {
            if (User.IsInRole("Controleur"))
            {
                return Forbid();
            }

            var viewModel = new QrqcCreateViewModel();

            // Populate Pilote dropdown options (users sharing same workshop/AP)
            // Charger l'utilisateur connecté avec ses liaisons ZAP
            var currentUserId = _userManager.GetUserId(User);
            var currentUser = await _userManager.Users
                .Include(u => u.UsersZaps)
                .FirstOrDefaultAsync(u => u.Id == currentUserId);

            var currentZapIds = currentUser?.UsersZaps.Select(uz => uz.ZapId).ToList() ?? new List<int>();

            var usersSameZap = await _userManager.Users
                .Include(u => u.UsersZaps)
                .Where(u => u.UsersZaps.Any(uz => currentZapIds.Contains(uz.ZapId)))
                .ToListAsync();

            viewModel.PiloteOptions = usersSameZap
                .Select(u => new SelectListItem { Value = u.Id, Text = $"{u.FirstName} {u.LastName}" });
            var fnc = await _fncServices.GetFncByIdAsync(fncId);

            if (fnc != null)
            {
                viewModel.FNCId = fncId;
                viewModel.ProcessorID = currentUserId; // utiliser l'ID (GUID) de l'utilisateur connecté
                fnc.ProcessorId = currentUserId; // Assigner l'ID GUID à la FNC
                if (fnc.Client_name != null)
                {
                    viewModel.Client_name = fnc.Client_name;
                }
                var fncDto = _mapper.Map<UpdateFncDto>(fnc); // Mapper la FNC pour l'afficher dans le formulaire
                _fncServices.UpdateFncAsync(fncDto); // Mettre à jour la FNC avec l'ID du processeur
            }
            return View(viewModel);
        }

        // POST: QrqcController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(QrqcCreateViewModel viewModel)
        {
            if (User.IsInRole("Controleur"))
            {
                return Forbid();
            }

            // Supprimer du ModelState toutes les entrées dont la valeur brute est null (non postées par le formulaire).
            // Cela évite de bloquer la validation sur des propriétés Required situées dans la couche Application mais non exposées à l'IU.
            // Supprime uniquement les clés ModelState non postées qui ne correspondent PAS aux champs du formulaire principal (ex : collections D3/D4 etc.)
            var d2CoreKeys = new HashSet<string>(new[]
            {
                nameof(viewModel.Probleme),
                nameof(viewModel.Detecteur),
                nameof(viewModel.LieuDeDetection),
                nameof(viewModel.Date),
                nameof(viewModel.Heure),
                nameof(viewModel.ManiereDeDetection),
                nameof(viewModel.NbreDePiecesConcernes),
                nameof(viewModel.RaisonDuProbleme),
                nameof(viewModel.ReccurenceDuProbleme),
                nameof(viewModel.Risque)
            });

            var notBoundKeys = ModelState.Where(kv => kv.Value?.RawValue == null && !d2CoreKeys.Contains(kv.Key)).Select(kv => kv.Key).ToList();
            foreach (var key in notBoundKeys)
            {
                ModelState.Remove(key);
            }

            if (!ModelState.IsValid)
            {
                // Réinitialiser les listes déroulantes car le model binder les met à null
                var optionSource = new QrqcCreateViewModel();
                // Re-populate Pilote options
                var currentUserId = _userManager.GetUserId(User);
                var currentUser = await _userManager.Users.Include(u => u.UsersZaps).FirstOrDefaultAsync(u => u.Id == currentUserId);
                var currentZapIds = currentUser?.UsersZaps.Select(uz => uz.ZapId).ToList() ?? new List<int>();

                var usersSameZap = await _userManager.Users.Include(u => u.UsersZaps)
                    .Where(u => u.UsersZaps.Any(uz => currentZapIds.Contains(uz.ZapId)))
                    .ToListAsync();
                viewModel.PiloteOptions = usersSameZap.Select(u => new SelectListItem { Value = u.Id, Text = $"{u.FirstName} {u.LastName}" });
                viewModel.NatureDefautOptions = optionSource.NatureDefautOptions;
                viewModel.TypeReclamationOptions = optionSource.TypeReclamationOptions;
                viewModel.ActionImmediateOptions = optionSource.ActionImmediateOptions;
                viewModel.CauseOptions = optionSource.CauseOptions;
                viewModel.CauseNonDetectionOptions = optionSource.CauseNonDetectionOptions;
                viewModel.ConnaissanceExperienceOptions = optionSource.ConnaissanceExperienceOptions;
                viewModel.StatusActionOptions = optionSource.StatusActionOptions;
                viewModel.FonctionOptions = optionSource.FonctionOptions;

                // Purger ModelState et ViewData pour les dropdowns Pilote afin d'éviter le conflit "string vs SelectList"
                foreach (var key in new[] {"PiloteIDContenir", "PiloteIDTrier", "PiloteIDAssurer", "PiloteID"})
                {
                    if (ModelState.ContainsKey(key))
                    {
                        ModelState.Remove(key);
                    }
                    ViewData[key] = viewModel.PiloteOptions;
                }
                // Récupérer les messages d'erreur détaillés
                var errors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .Where(m => !string.IsNullOrWhiteSpace(m) && !m.Contains("The value '' is invalid."))
                    .Distinct();
                var errorMsg = errors.Any() ? string.Join(" | ", errors) : "Le formulaire contient des erreurs. Veuillez les corriger.";
                System.Console.WriteLine($"ModelState errors: {errorMsg}");
                TempData["Error"] = errorMsg;
                return View(viewModel);
            }

            // Récupérer la première action D3 renseignée et la remonter dans les propriétés racines attendues par le mapping
            if (viewModel.ListeActions != null && viewModel.ListeActions.Count > 0)
            {
                var firstAction = viewModel.ListeActions[0];
                viewModel.ActionListe = firstAction.Action;
                viewModel.StatusAction = firstAction.StatusAction;
                viewModel.DatePrevue = firstAction.DatePrevue;
                viewModel.DateReelle = firstAction.DateReelle;
                viewModel.Commentaire = firstAction.Commentaire;
                viewModel.PiloteIDListeDesActionsD3 = firstAction.PiloteID;
            }

            // Faire de même pour la première équipe saisie
            if (viewModel.Equipes != null && viewModel.Equipes.Count > 0)
            {
                var firstEquipe = viewModel.Equipes[0];
                viewModel.UserId = firstEquipe.UserId;
                viewModel.Fonction = firstEquipe.Fonction;
                viewModel.IsAbsent = firstEquipe.IsAbsent;
            }

            // Première cause d'occurrence (D4)
            if (viewModel.CausesOccurence != null && viewModel.CausesOccurence.Count > 0)
            {
                var firstOcc = viewModel.CausesOccurence[0];
                viewModel.PourquoiOccurence = firstOcc.Pourquoi;
                viewModel.CauseOccurence = firstOcc.Cause;
            }

            // Première cause de non détection (D4)
            if (viewModel.CausesNonDetection != null && viewModel.CausesNonDetection.Count > 0)
            {
                var firstNonDet = viewModel.CausesNonDetection[0];
                viewModel.PourquoiNonDetection = firstNonDet.Pourquoi;
                viewModel.CauseNonDetection = firstNonDet.Cause;
            }

            // Première recherche causes racines (D4)
            if (viewModel.RechercheCausesRacines != null && viewModel.RechercheCausesRacines.Count > 0)
            {
                var firstRc = viewModel.RechercheCausesRacines[0];
                viewModel.ActionRechercheCausesRacines = firstRc.Action;
                viewModel.OD = firstRc.OD;
                viewModel.PiloteIDRechercheCausesRacines = firstRc.PiloteID;
                viewModel.DatePrevueRechercheCauses = firstRc.DatePrevue;
                viewModel.DateReelleRechercheCauses = firstRc.DateReelle;
                viewModel.EvolutionRechercheCausesRacines = firstRc.Evolution;
            }

            // Première action corrective D5
            if (viewModel.PlanActionsCorrectives != null && viewModel.PlanActionsCorrectives.Count > 0)
            {
                var firstPlan = viewModel.PlanActionsCorrectives[0];
                viewModel.ActionEliminationProbleme = firstPlan.ActionEliminationProbleme;
                viewModel.PiloteIDPlanActions = firstPlan.PiloteID;
                viewModel.DatePlanifiee = firstPlan.DatePlanifiee;
            }

            var dto = _mapper.Map<CreateGlobalQrqcDto>(viewModel);

            try
            {
                var createdQrqc = await _qrqcServices.CreateQrqcAsync(dto);
                TempData["Success"] = "QRQC créé avec succès.";
                return RedirectToAction(nameof(Details), new { id = createdQrqc.Id });
            }
            catch (System.Exception ex)
            {
                TempData["Error"] = "Une erreur est survenue lors de la création du QRQC.";
                ModelState.AddModelError(string.Empty, $"Erreur : {ex.Message}");
                return View(viewModel);
            }
        }

        // GET: QrqcController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (User.IsInRole("Controleur"))
            {
                return Forbid();
            }

            var qrqc = await _context.Qrqc
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ActionImmediateGlobale)
                        .ThenInclude(ai => ai.TriActionImmediateGlobales!)
                            .ThenInclude(t => t.QuantitéTriéeParJour)
                .Include(q => q.Equipe!)
                    .ThenInclude(e => e.applicationUser)
                .FirstOrDefaultAsync(q => q.Id == id);

            if (qrqc == null)
            {
                return NotFound();
            }

            var quantite = qrqc.actionDeSecurisation?
                .ActionImmediateGlobale?
                .TriActionImmediateGlobales?
                .FirstOrDefault()?
                .QuantitéTriéeParJour;

            var vm = new QrqcEditViewModel
            {
                QrqcId = id,
                QuantiteId = quantite?.Id,
                Jour1 = quantite?.Jour1,
                Jour2 = quantite?.Jour2,
                Jour3 = quantite?.Jour3,
                Jour4 = quantite?.Jour4,
                Jour5 = quantite?.Jour5,
                Equipes = qrqc.Equipe.Select(e => new EquipeEditViewModel
                {
                    Id = e.Id,
                    MemberName = e.applicationUser != null ? $"{e.applicationUser.FirstName} {e.applicationUser.LastName}" : string.Empty,
                    Fonction = e.Fonction.ToString(),
                    IsAbsent = e.IsAbsent
                }).ToList()
            };

            return View(vm);
        }

        // POST: QrqcController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, QrqcEditViewModel vm)
        {
            if (User.IsInRole("Controleur"))
            {
                return Forbid();
            }

            if (id != vm.QrqcId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            // Mise à jour des quantités triées
            if (vm.QuantiteId.HasValue)
            {
                var quantiteDto = await _quantiteServices.GetByIdAsync(vm.QuantiteId.Value);
                if (quantiteDto != null)
                {
                    var updateDto = new CreateQuantitéTriéeParJourDto
                    {
                        Jour1 = vm.Jour1,
                        Jour2 = vm.Jour2,
                        Jour3 = vm.Jour3,
                        Jour4 = vm.Jour4,
                        Jour5 = vm.Jour5,
                        TriActionImmediateGlobaleId = quantiteDto.TriActionImmediateGlobaleId
                    };
                    await _quantiteServices.UpdateAsync(vm.QuantiteId.Value, updateDto);
                }
            }

            // Mise à jour des équipiers
            if (vm.Equipes != null)
            {
                foreach (var eqVm in vm.Equipes)
                {
                    var equipeDto = await _equipeServices.GetEquipeByIdAsync(eqVm.Id);
                    if (equipeDto != null)
                    {
                        equipeDto.IsAbsent = eqVm.IsAbsent;
                        await _equipeServices.UpdateEquipeAsync(equipeDto);
                    }
                }
            }

            return RedirectToAction(nameof(Details), new { id = vm.QrqcId });
        }

        // GET: QrqcController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (User.IsInRole("Controleur"))
            {
                return Forbid();
            }
            var qrqc = await _qrqcServices.GetQrqcByIdAsync(id);
            if (qrqc == null)
            {
                return NotFound();
            }
            return View(qrqc);
        }

        // POST: QrqcController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (User.IsInRole("Controleur"))
            {
                return Forbid();
            }

            var success = await _qrqcServices.DeleteQrqcAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
