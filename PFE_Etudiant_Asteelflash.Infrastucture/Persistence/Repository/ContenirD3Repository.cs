using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class ContenirD3Repository : Repository<ContenirD3>, IContenirD3Repository
    {
        private readonly ApplicationDbContext _context;

        public ContenirD3Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ContenirD3> AddAsync(ContenirD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.ContenirD3.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ContenirD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ContenirD3.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ContenirD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ContenirD3.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ContenirD3> GetByIdAsync(int id)
        {
            return await _context.ContenirD3
                .Include(c => c.Pilote)
                .Include(c => c.ActionDeSecurisationD3)
                .FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<IEnumerable<ContenirD3>> GetAllAsync()
        {
            return await _context.ContenirD3
                .Include(c => c.Pilote)
                .Include(c => c.ActionDeSecurisationD3)
                .ToListAsync();
        }
    }
}
