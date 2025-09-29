using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class AssurerD3Repository : Repository<AssurerD3>, IAssurerD3Repository
    {
        private readonly ApplicationDbContext _context;

        public AssurerD3Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<AssurerD3> AddAsync(AssurerD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.AssurerD3.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(AssurerD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.AssurerD3.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(AssurerD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.AssurerD3.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<AssurerD3> GetByIdAsync(int id)
        {
            return await _context.AssurerD3
                .Include(a => a.Pilote)
                .Include(a => a.ActionDeSecurisationD3)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AssurerD3>> GetAllAsync()
        {
            return await _context.AssurerD3
                .Include(a => a.Pilote)
                .Include(a => a.ActionDeSecurisationD3)
                .ToListAsync();
        }
    }
}
