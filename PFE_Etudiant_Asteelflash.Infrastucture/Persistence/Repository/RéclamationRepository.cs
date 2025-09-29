using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class RéclamationRepository : Repository<Réclamation>, IRéclamationRepository
    {
        private readonly ApplicationDbContext _context;

        public RéclamationRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Réclamation> AddAsync(Réclamation entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.Réclamation.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Réclamation entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Réclamation.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Réclamation entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Réclamation.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Réclamation> GetByIdAsync(int id)
        {
            return await _context.Réclamation
                .Include(r => r.User)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Réclamation>> GetAllAsync()
        {
            return await _context.Réclamation
                .Include(r => r.User)
                .ToListAsync();
        }
    }
}
