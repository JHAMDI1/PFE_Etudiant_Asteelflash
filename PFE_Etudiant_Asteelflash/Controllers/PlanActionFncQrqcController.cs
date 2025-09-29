using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.PlanAction.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Controllers
{
    /// <summary>
    /// Contrôleur CRUD pour le plan d'action (PlanActionFncQrqc).
    /// </summary>
    public class PlanActionFncQrqcController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PlanActionFncQrqcController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: PlanActionFncQrqc
        public async Task<IActionResult> Index()
        {
            var list = await _context.PlanActionFncQrqc.Include(p => p.Lignes)
                            .OrderByDescending(p => p.DateCreationDoc)
                            .ToListAsync();
            var dtos = _mapper.Map<IEnumerable<PlanActionFncQrqcDto>>(list);
            return View(dtos);
        }

        // GET: PlanActionFncQrqc/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var entity = await _context.PlanActionFncQrqc.Include(p => p.Lignes)
                                .FirstOrDefaultAsync(p => p.Id == id);
            if (entity == null) return NotFound();
            var dto = _mapper.Map<PlanActionFncQrqcDto>(entity);
            ViewBag.Lignes = _mapper.Map<IEnumerable<PlanActionFncQrqcLigneDto>>(entity.Lignes);
            return View(dto);
        }

        // GET: PlanActionFncQrqc/Create
        public async Task<IActionResult> Create(int fncId)
        {
            if (fncId == 0 || !await _context.Set<Fnc>().AnyAsync(f => f.Id == fncId))
            {
                TempData["Error"] = "Aucune FNC sélectionnée pour le plan d'action.";
                return RedirectToAction("Index", "Fnc");
            }
            var dto = new PlanActionFncQrqcDto { FncId = fncId, DateCreationDoc = DateTime.Today };
            return View(dto);
        }

        // POST: PlanActionFncQrqc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanActionFncQrqcDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            // Vérifier que la FNC associée existe toujours
            if (!await _context.Set<Fnc>().AnyAsync(f => f.Id == dto.FncId))
            {
                ModelState.AddModelError(string.Empty, "La FNC associée est introuvable.");
                return View(dto);
            }
            var entity = _mapper.Map<PlanActionFncQrqc>(dto);
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PlanActionFncQrqc/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _context.PlanActionFncQrqc.FindAsync(id);
            if (entity == null) return NotFound();
            var dto = _mapper.Map<PlanActionFncQrqcDto>(entity);
            return View(dto);
        }

        // POST: PlanActionFncQrqc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PlanActionFncQrqcDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);
            var entity = await _context.PlanActionFncQrqc.FindAsync(id);
            if (entity == null) return NotFound();
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: PlanActionFncQrqc/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.PlanActionFncQrqc.FindAsync(id);
            if (entity == null) return NotFound();
            var dto = _mapper.Map<PlanActionFncQrqcDto>(entity);
            return View(dto);
        }

        // POST: PlanActionFncQrqc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.PlanActionFncQrqc.FindAsync(id);
            if (entity != null)
            {
                _context.PlanActionFncQrqc.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
