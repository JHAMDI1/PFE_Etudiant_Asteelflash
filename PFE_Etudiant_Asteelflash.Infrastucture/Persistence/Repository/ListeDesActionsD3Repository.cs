using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class ListeDesActionsD3Repository : Repository<ListeDesActionsD3>, IListeDesActionsD3Repository
    {
        private readonly ApplicationDbContext _context;

        public ListeDesActionsD3Repository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<ListeDesActionsD3> AddAsync(ListeDesActionsD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.ListeDesActionsD3.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(ListeDesActionsD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ListeDesActionsD3.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ListeDesActionsD3 entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.ListeDesActionsD3.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ListeDesActionsD3> GetByIdAsync(int id)
        {
            return await _context.ListeDesActionsD3
                .Include(l => l.Pilote)
                .Include(l => l.ActionDeSecurisationD3)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<ListeDesActionsD3>> GetAllAsync()
        {
            return await _context.ListeDesActionsD3
                .Include(l => l.Pilote)
                .Include(l => l.ActionDeSecurisationD3)
                .ToListAsync();
        }
    }
}
