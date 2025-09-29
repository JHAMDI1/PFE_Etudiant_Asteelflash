using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class TriActionImmediateGlobaleRepository : Repository<TriActionImmediateGlobale>, ITriActionImmediateGlobaleRepository
    {
        private readonly ApplicationDbContext _context;

        public TriActionImmediateGlobaleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<TriActionImmediateGlobale> AddAsync(TriActionImmediateGlobale entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.TrieActionImmediateGlobale.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(TriActionImmediateGlobale entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.TrieActionImmediateGlobale.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TriActionImmediateGlobale entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.TrieActionImmediateGlobale.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<TriActionImmediateGlobale> GetByIdAsync(int id)
        {
            return await _context.TrieActionImmediateGlobale
                .Include(t => t.ActionImmediateGlobale)
                .Include(t => t.QuantitéTriéeParJour)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<TriActionImmediateGlobale>> GetAllAsync()
        {
            return await _context.TrieActionImmediateGlobale
                .Include(t => t.ActionImmediateGlobale)
                .Include(t => t.QuantitéTriéeParJour)
                .ToListAsync();
        }
    }
}
