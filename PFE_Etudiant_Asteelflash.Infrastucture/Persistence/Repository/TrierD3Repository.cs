using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class TrierD3Repository : Repository<TrierD3>, ITrierD3Repository
    {
        private readonly ApplicationDbContext _context;

        public TrierD3Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TrierD3> AddAsync(TrierD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.TrierD3.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TrierD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.TrierD3.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TrierD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.TrierD3.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TrierD3> GetByIdAsync(int id)
        {
            return await _context.TrierD3
                .Include(t => t.Pilote)
                .Include(t => t.ActionDeSecurisationD3)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TrierD3>> GetAllAsync()
        {
            return await _context.TrierD3
                .Include(t => t.Pilote)
                .Include(t => t.ActionDeSecurisationD3)
                .ToListAsync();
        }
    }
}
