using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class ClotureD8Repository : Repository<ClotureD8>, IClotureD8Repository
    {
        private readonly ApplicationDbContext _context;

        public ClotureD8Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ClotureD8> AddAsync(ClotureD8 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.ClotureD8.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ClotureD8 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ClotureD8.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ClotureD8 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ClotureD8.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ClotureD8> GetByIdAsync(int id)
        {
            return await _context.ClotureD8
                .Include(c => c.ChefEquipe)
                .Include(c => c.RespZap)
                .Include(c => c.QualitéProd)
                .Include(c => c.RespQualite)
                .Include(c => c.RespProd)
                .Include(c => c.Qrqc)
                .FirstOrDefaultAsync(c => c.id == id);
        }

        public async Task<IEnumerable<ClotureD8>> GetAllAsync()
        {
            return await _context.ClotureD8
                .Include(c => c.ChefEquipe)
                .Include(c => c.RespZap)
                .Include(c => c.QualitéProd)
                .Include(c => c.RespQualite)
                .Include(c => c.RespProd)
                .Include(c => c.Qrqc)
                .ToListAsync();
        }
    }
}
