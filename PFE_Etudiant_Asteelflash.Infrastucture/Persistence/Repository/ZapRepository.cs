using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class ZapRepository : Repository<Zap>, IZapRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ZapRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Zap> AddAsync(Zap entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await _dbContext.Set<Zap>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Zap entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Set<Zap>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Zap entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _dbContext.Set<Zap>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Zap> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Zap>().FindAsync(id);
        }

        public async Task<IEnumerable<Zap>> GetAllAsync()
        {
            return await _dbContext.Set<Zap>().ToListAsync();
        }
    }
}
