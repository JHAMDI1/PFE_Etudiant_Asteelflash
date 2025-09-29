using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class DescriptionDuProblemeD2Repository : Repository<DescriptionDuProblemeD2>, IDescriptionDuProblemeD2Repository
    {
        private readonly ApplicationDbContext _context;

        public DescriptionDuProblemeD2Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<DescriptionDuProblemeD2> AddAsync(DescriptionDuProblemeD2 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.DescriptionDuProblemeD2.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(DescriptionDuProblemeD2 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.DescriptionDuProblemeD2.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(DescriptionDuProblemeD2 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.DescriptionDuProblemeD2.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<DescriptionDuProblemeD2> GetByIdAsync(int id)
        {
            return await _context.DescriptionDuProblemeD2
                .Include(d => d.QRQC)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<DescriptionDuProblemeD2>> GetAllAsync()
        {
            return await _context.DescriptionDuProblemeD2
                .Include(d => d.QRQC)
                .ToListAsync();
        }
    }
}
