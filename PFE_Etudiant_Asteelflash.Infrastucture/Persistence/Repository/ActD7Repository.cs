using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class ActD7Repository : Repository<ActD7>, IActD7Repository
    {
        private readonly ApplicationDbContext _context;

        public ActD7Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ActD7> AddAsync(ActD7 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.ActD7.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ActD7 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ActD7.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ActD7 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ActD7.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ActD7> GetByIdAsync(int id)
        {
            return await _context.ActD7.FindAsync(id);
        }

        public async Task<IEnumerable<ActD7>> GetAllAsync()
        {
            return await _context.ActD7.ToListAsync();
        }
    }
}
