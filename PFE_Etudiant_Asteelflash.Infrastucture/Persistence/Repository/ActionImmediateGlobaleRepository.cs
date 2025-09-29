using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class ActionImmediateGlobaleRepository : Repository<ActionImmediateGlobale>, IActionImmediateGlobaleRepository
    {
        private readonly ApplicationDbContext _context;

        public ActionImmediateGlobaleRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionImmediateGlobale> AddAsync(ActionImmediateGlobale entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.ActionImmediateGlobale.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ActionImmediateGlobale entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ActionImmediateGlobale.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ActionImmediateGlobale entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ActionImmediateGlobale.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionImmediateGlobale> GetByIdAsync(int id)
        {
            return await _context.ActionImmediateGlobale
                .Include(a => a.TriActionImmediateGlobales)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<ActionImmediateGlobale>> GetAllAsync()
        {
            return await _context.ActionImmediateGlobale
                .Include(a => a.TriActionImmediateGlobales)
                .ToListAsync();
        }
    }
}
