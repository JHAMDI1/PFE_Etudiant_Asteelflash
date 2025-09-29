using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class Recherche_causes_racinesD4Repository : Repository<Recherche_causes_racinesD4>, IRecherche_causes_racinesD4Repository
    {
        private readonly ApplicationDbContext _context;

        public Recherche_causes_racinesD4Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Recherche_causes_racinesD4> AddAsync(Recherche_causes_racinesD4 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.Recherche_causes_racinesD4.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Recherche_causes_racinesD4 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Recherche_causes_racinesD4.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Recherche_causes_racinesD4 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Recherche_causes_racinesD4.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Recherche_causes_racinesD4> GetByIdAsync(int id)
        {
            return await _context.Recherche_causes_racinesD4
                .Include(r => r.Pilote)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Recherche_causes_racinesD4>> GetAllAsync()
        {
            return await _context.Recherche_causes_racinesD4
                .Include(r => r.Pilote)
                .ToListAsync();
        }
    }
}
