using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class ActionDeSecurisationD3Repository : Repository<ActionDeSecurisationD3>, IActionDeSecurisationD3Repository
    {
        private readonly ApplicationDbContext _context;

        public ActionDeSecurisationD3Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActionDeSecurisationD3> AddAsync(ActionDeSecurisationD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.ActionDeSecurisationD3.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ActionDeSecurisationD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ActionDeSecurisationD3.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ActionDeSecurisationD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ActionDeSecurisationD3.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ActionDeSecurisationD3> GetByIdAsync(int id)
        {
            return await _context.ActionDeSecurisationD3.FindAsync(id);
        }

        public async Task<IEnumerable<ActionDeSecurisationD3>> GetAllAsync()
        {
            return await _context.ActionDeSecurisationD3
                .Include(a => a.QRQC)
                .ToListAsync();
        }
    }
}
