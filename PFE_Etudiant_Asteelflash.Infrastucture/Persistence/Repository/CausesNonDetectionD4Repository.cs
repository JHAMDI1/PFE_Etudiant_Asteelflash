using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class CausesNonDetectionD4Repository : Repository<CausesNonDetectionD4>, ICausesNonDetectionD4Repository
    {
        private readonly ApplicationDbContext _context;

        public CausesNonDetectionD4Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CausesNonDetectionD4> AddAsync(CausesNonDetectionD4 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.CausesNonDetectionD4.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(CausesNonDetectionD4 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.CausesNonDetectionD4.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CausesNonDetectionD4 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.CausesNonDetectionD4.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CausesNonDetectionD4> GetByIdAsync(int id)
        {
            return await _context.CausesNonDetectionD4
                .Include(c => c.Qrqc)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CausesNonDetectionD4>> GetAllAsync()
        {
            return await _context.CausesNonDetectionD4
                .Include(c => c.Qrqc)
                .ToListAsync();
        }
    }
}
