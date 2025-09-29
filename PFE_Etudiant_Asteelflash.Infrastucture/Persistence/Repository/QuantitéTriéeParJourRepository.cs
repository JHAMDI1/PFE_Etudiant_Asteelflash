using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class QuantitéTriéeParJourRepository : Repository<QuantitéTriéeParJour>, IQuantitéTriéeParJourRepository
    {
        private readonly ApplicationDbContext _context;

        public QuantitéTriéeParJourRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<QuantitéTriéeParJour> AddAsync(QuantitéTriéeParJour entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.QuantitéTriéeParJour.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(QuantitéTriéeParJour entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.QuantitéTriéeParJour.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(QuantitéTriéeParJour entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.QuantitéTriéeParJour.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<QuantitéTriéeParJour> GetByIdAsync(int id)
        {
            return await _context.QuantitéTriéeParJour
                .Include(q => q.trieActionImmediateGlobale)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<QuantitéTriéeParJour>> GetAllAsync()
        {
            return await _context.QuantitéTriéeParJour
                .Include(q => q.trieActionImmediateGlobale)
                .ToListAsync();
        }
    }
}
