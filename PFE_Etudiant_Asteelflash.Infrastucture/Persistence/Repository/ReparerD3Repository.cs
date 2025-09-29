using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class ReparerD3Repository : Repository<ReparerD3>, IReparerD3Repository
    {
        private readonly ApplicationDbContext _context;

        public ReparerD3Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ReparerD3> AddAsync(ReparerD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.ReparerD3.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ReparerD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ReparerD3.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ReparerD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ReparerD3.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ReparerD3> GetByIdAsync(int id)
        {
            return await _context.ReparerD3
                .Include(r => r.Pilote)
                .Include(r => r.ActionDeSecurisationD3)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<ReparerD3>> GetAllAsync()
        {
            return await _context.ReparerD3
                .Include(r => r.Pilote)
                .Include(r => r.ActionDeSecurisationD3)
                .ToListAsync();
        }
    }
}
