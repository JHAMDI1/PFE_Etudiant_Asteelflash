using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class SuiviD6Repository : Repository<SuiviD6>, ISuiviD6Repository
    {
        private readonly ApplicationDbContext _context;

        public SuiviD6Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SuiviD6> AddAsync(SuiviD6 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.SuiviD6.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(SuiviD6 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.SuiviD6.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SuiviD6 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.SuiviD6.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<SuiviD6> GetByIdAsync(int id)
        {
            return await _context.SuiviD6
                .Include(s => s.Qrqc)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<SuiviD6>> GetAllAsync()
        {
            return await _context.SuiviD6
                .Include(s => s.Qrqc)
                .ToListAsync();
        }
    }
}
