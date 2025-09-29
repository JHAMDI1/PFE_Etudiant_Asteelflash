using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class EquipeRepository : Repository<Equipe>, IEquipeRepository
    {
        private readonly ApplicationDbContext _context;

        public EquipeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Equipe> AddAsync(Equipe entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.Equipe.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Equipe entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Equipe.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Equipe entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Equipe.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Equipe> GetByIdAsync(int id)
        {
            return await _context.Equipe
                .Include(e => e.Qrqc)
                .Include(e => e.applicationUser)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Equipe>> GetAllAsync()
        {
            return await _context.Equipe
                .Include(e => e.Qrqc)
                .Include(e => e.applicationUser)
                .ToListAsync();
        }
    }
}
