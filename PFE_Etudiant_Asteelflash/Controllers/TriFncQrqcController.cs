using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Tri.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace PFE_Etudiant_Asteelflash.Controllers
{
    /// <summary>
    /// Contrôleur CRUD pour le suivi de tri (TriFncQrqc).
    /// Implémentation simple via ApplicationDbContext + AutoMapper.
    /// </summary>
    public class TriFncQrqcController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TriFncQrqcController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: TriFncQrqc
        public async Task<IActionResult> Index()
        {
            var triList = await _context.TriFncQrqc
                                        .Include(t => t.Pilote)
                                        .Include(t => t.Lignes)
                                        .OrderByDescending(t => t.DateTri)
                                        .ToListAsync();
            var dtos = _mapper.Map<IEnumerable<TriFncQrqcDto>>(triList).ToList();
            // calcul totaux pour affichage liste
            foreach(var d in dtos){
                d.TotalTrie = d.Lignes.Sum(l => l.QuantiteTriee);
                d.TotalNonConforme = d.Lignes.Sum(l => l.QuantiteNonConforme);
                d.PourcentageDefaut = d.TotalTrie>0? decimal.Round((decimal)d.TotalNonConforme/d.TotalTrie,2) : 0;
            }
            return View(dtos);
        }

        // GET: TriFncQrqc/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var entity = await _context.TriFncQrqc
                                       .Include(t => t.Pilote)
                                       .Include(t => t.Lignes)
                                       .FirstOrDefaultAsync(t => t.Id == id);
            if (entity == null) return NotFound();
            var dto = _mapper.Map<TriFncQrqcDto>(entity);
            // Calcul dynamiques
            dto.TotalTrie = entity.Lignes.Sum(l => l.QuantiteTriee);
            dto.TotalNonConforme = entity.Lignes.Sum(l => l.QuantiteNonConforme);
            dto.PourcentageDefaut = dto.TotalTrie > 0 ? decimal.Round((decimal)dto.TotalNonConforme / dto.TotalTrie, 2) : 0;
            return View(dto);
        }

        // GET: TriFncQrqc/Create
        public IActionResult Create(int fncId)
        {
            var dto = new TriFncQrqcDto { FncId = fncId };
            return View(dto);
        }

        // POST: TriFncQrqc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TriFncQrqcDto dto)
        {
            if (!ModelState.IsValid) return View(dto);
            var entity = _mapper.Map<TriFncQrqc>(dto);
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TriFncQrqc/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var entity = await _context.TriFncQrqc.FindAsync(id);
            if (entity == null) return NotFound();
            var dto = _mapper.Map<TriFncQrqcDto>(entity);
            return View(dto);
        }

        // POST: TriFncQrqc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TriFncQrqcDto dto)
        {
            if (id != dto.Id) return NotFound();
            if (!ModelState.IsValid) return View(dto);
            var entity = await _context.TriFncQrqc.FindAsync(id);
            if (entity == null) return NotFound();
            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: TriFncQrqc/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _context.TriFncQrqc.FindAsync(id);
            if (entity == null) return NotFound();
            var dto = _mapper.Map<TriFncQrqcDto>(entity);
            return View(dto);
        }

        // POST: TriFncQrqc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.TriFncQrqc.FindAsync(id);
            if (entity != null)
            {
                // Supprimer d'abord les lignes associées pour respecter la contrainte FK
                var lignes = _context.TriFncQrqcLigne.Where(l => l.TriFncQrqcId == id);
                _context.TriFncQrqcLigne.RemoveRange(lignes);

                _context.TriFncQrqc.Remove(entity);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
