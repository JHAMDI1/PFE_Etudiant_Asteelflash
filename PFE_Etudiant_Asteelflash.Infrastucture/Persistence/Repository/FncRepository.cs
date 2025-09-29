using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository
{
    public class FncRepository : Repository<Fnc>, IFncRepository
    {
        private readonly ApplicationDbContext _context;
        public FncRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Fnc> GetFncByIdWithDetailsAsync(int id)
        {
            return await _context.Fnc
                .Include(f => f.ZapReceptrice)
                .Include(f => f.ZapEmettrice)
                .Include(f => f.Transmitter)
                .Include(f => f.Processor)
                .Include(f => f.Qrqc)
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Fnc>> GetAllFncsWithDetailsAsync()
        {
            try
            {
                return await _context.Fnc
                    .Include(f => f.ZapReceptrice)
                    .Include(f => f.ZapEmettrice)
                    .Include(f => f.Transmitter)
                    .Include(f => f.Processor)
                    .Include(f => f.Qrqc)
                    .ToListAsync();
            }
            catch (InvalidCastException ex)
            {
                // Log exception details
                Console.WriteLine($"Erreur de conversion lors de la récupération des FNCs: {ex.Message}");
                
                // Récupération manuelle avec vérification de type
                // Cette approche est un contournement temporaire
                var fncs = new List<Fnc>();
                
                // Récupérer les IDs uniquement
                var fncIds = await _context.Fnc.Select(f => f.Id).ToListAsync();
                
                // Récupérer chaque FNC individuellement pour isoler le problème
                foreach (var id in fncIds)
                {
                    try
                    {
                        var fnc = await _context.Fnc
                            .Include(f => f.ZapReceptrice)
                            .Include(f => f.ZapEmettrice)
                            .Include(f => f.Transmitter)
                            .Include(f => f.Processor)
                            .Include(f => f.Qrqc)
                            .FirstOrDefaultAsync(f => f.Id == id);
                            
                        if (fnc != null)
                        {
                            fncs.Add(fnc);
                        }
                    }
                    catch (Exception innerEx)
                    {
                        // Log l'erreur mais continue avec les autres enregistrements
                        Console.WriteLine($"Erreur avec FNC ID {id}: {innerEx.Message}");
                    }
                }
                
                return fncs;
            }
        }

        public async Task<bool> DeleteFncAsync(int id)
        {
            var fnc = await _context.Fnc.FindAsync(id);
            if (fnc == null)
                return false;

            _dbSet.Remove(fnc);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateFncAsync(Fnc fnc)
        {
            _context.Entry(fnc).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Fnc>> GetFncsByDateAsync(DateTime date)
        {
            return await _context.Fnc
                .Where(f => f.Date.Date == date.Date)
                .Include(f => f.ZapReceptrice)
                .Include(f => f.ZapEmettrice)
                .Include(f => f.Transmitter)
                .Include(f => f.Processor)
                .ToListAsync();
        }

        public async Task<IEnumerable<Fnc>> GetFncsByStatusAsync(string status)
        {
            // Essayer de parser le status comme enum
            if (Enum.TryParse<StatusFNC>(status, out var parsedStatus))
            {
                return await _context.Fnc
                    .Where(f => f.Status == parsedStatus)
                    .Include(f => f.ZapReceptrice)
                    .Include(f => f.ZapEmettrice)
                    .Include(f => f.Transmitter)
                    .Include(f => f.Processor)
                    .ToListAsync();
            }
            else
            {
                // Si le status n'est pas valide, retourner une liste vide
                return new List<Fnc>();
            }
        }

        public async Task<IEnumerable<Fnc>> SearchFncsAsync(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return await GetAllFncsWithDetailsAsync();

            return await _context.Fnc
                .Where(f => f.Ref.Contains(searchTerm) || 
                            f.Client_name.Contains(searchTerm) ||
                            f.Detection_loc.Contains(searchTerm) ||
                            f.Description.Contains(searchTerm))
                .Include(f => f.ZapReceptrice)
                .Include(f => f.ZapEmettrice)
                .Include(f => f.Transmitter)
                .Include(f => f.Processor)
                .ToListAsync();
        }

        public async Task<int> CountFncsByStatusAsync(string status)
        {
            // Essayer de parser le status comme enum
            if (Enum.TryParse<StatusFNC>(status, out var parsedStatus))
            {
                return await _context.Fnc
                    .Where(f => f.Status == parsedStatus)
                    .CountAsync();
            }
            else
            {
                // Si le status n'est pas valide, retourner 0
                return 0;
            }
        }
    }
}
