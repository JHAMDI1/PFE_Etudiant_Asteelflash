using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class QrqcRepository : Repository<Qrqc>, IQrqcRepository
    {
        private readonly ApplicationDbContext _context;

        public QrqcRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Qrqc> AddAsync(Qrqc entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _context.Qrqc.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(Qrqc entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Qrqc.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Qrqc entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _context.Qrqc.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<Qrqc> GetByIdAsync(int id)
        {
            return await _context.Qrqc
                .Include(q => q.FNC)
                .Include(q => q.Processor)
                .Include(q => q.DescriptionDuProbleme)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ActionImmediateGlobale)
                        .ThenInclude(ai => ai.TriActionImmediateGlobales)
                            .ThenInclude(t => t.QuantitéTriéeParJour)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ContenirD3)
                    .ThenInclude(c => c.Pilote)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.TrierD3)
                    .ThenInclude(t => t.Pilote)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ReparerD3)
                    .ThenInclude(r => r.Pilote)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.AssurerD3)
                    .ThenInclude(s => s.Pilote)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ListeDesActionsD3)
                .Include(q => q.planActionsCorrectives)
                .Include(q => q.Suivi)
                .Include(q => q.Act)
                .Include(q => q.cloture)
                .Include(q => q.Equipe)
                    .ThenInclude(e => e.applicationUser)
                .Include(q => q.CauseOccurenceD4)
                .Include(q => q.CausesNonDetectionD4)
                .Include(q => q.Recherche_causes_racinesD4)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public async Task<IEnumerable<Qrqc>> GetAllAsync()
        {
            return await _context.Qrqc
                .Include(q => q.FNC)
                .Include(q => q.Processor)
                .Include(q => q.DescriptionDuProbleme)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ActionImmediateGlobale)
                        .ThenInclude(ai => ai.TriActionImmediateGlobales)
                            .ThenInclude(t => t.QuantitéTriéeParJour)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ContenirD3)
                    .ThenInclude(c => c.Pilote)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.TrierD3)
                    .ThenInclude(t => t.Pilote)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ReparerD3)
                    .ThenInclude(r => r.Pilote)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.AssurerD3)
                    .ThenInclude(s => s.Pilote)
                .Include(q => q.actionDeSecurisation)
                    .ThenInclude(a => a.ListeDesActionsD3)
                .Include(q => q.planActionsCorrectives)
                .Include(q => q.Suivi)
                .Include(q => q.Act)
                .Include(q => q.cloture)
                .Include(q => q.Equipe)
                    .ThenInclude(e => e.applicationUser)
                .Include(q => q.CauseOccurenceD4)
                .Include(q => q.CausesNonDetectionD4)
                .Include(q => q.Recherche_causes_racinesD4)
                .ToListAsync();
        }
    }
}
