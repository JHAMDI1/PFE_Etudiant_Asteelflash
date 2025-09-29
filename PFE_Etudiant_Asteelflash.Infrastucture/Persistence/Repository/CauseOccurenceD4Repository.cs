using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class CauseOccurenceD4Repository : Repository<CauseOccurenceD4>, ICauseOccurenceD4Repository
    {
        private readonly ApplicationDbContext _context;

        public CauseOccurenceD4Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CauseOccurenceD4> AddAsync(CauseOccurenceD4 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.CauseOccurenceD4.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(CauseOccurenceD4 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.CauseOccurenceD4.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(CauseOccurenceD4 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.CauseOccurenceD4.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CauseOccurenceD4> GetByIdAsync(int id)
        {
            return await _context.CauseOccurenceD4
                .Include(c => c.Qrqc)
                .FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<IEnumerable<CauseOccurenceD4>> GetAllAsync()
        {
            return await _context.CauseOccurenceD4
                .Include(c => c.Qrqc)
                .ToListAsync();
        }
    }
}
