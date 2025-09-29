using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class PlanActionsCorrectivesD5Repository : Repository<PlanActionsCorrectivesD5>, IPlanActionsCorrectivesD5Repository
    {
        private readonly ApplicationDbContext _context;

        public PlanActionsCorrectivesD5Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PlanActionsCorrectivesD5> AddAsync(PlanActionsCorrectivesD5 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.PlanActionsCorrectivesD5.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(PlanActionsCorrectivesD5 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.PlanActionsCorrectivesD5.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(PlanActionsCorrectivesD5 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.PlanActionsCorrectivesD5.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<PlanActionsCorrectivesD5> GetByIdAsync(int id)
        {
            return await _context.PlanActionsCorrectivesD5
                .Include(p => p.Pilote)
                .Include(p => p.Qrqc)
                .FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<IEnumerable<PlanActionsCorrectivesD5>> GetAllAsync()
        {
            return await _context.PlanActionsCorrectivesD5
                .Include(p => p.Pilote)
                .Include(p => p.Qrqc)
                .ToListAsync();
        }
    }
}
