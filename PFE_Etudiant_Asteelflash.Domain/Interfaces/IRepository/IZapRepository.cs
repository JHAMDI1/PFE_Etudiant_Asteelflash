using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IZapRepository : IRepository<Zap>
    {
        Task<Zap> AddAsync(Zap entity);
        Task UpdateAsync(Zap entity);
        Task DeleteAsync(Zap entity);
        Task<Zap> GetByIdAsync(int id);
        Task<IEnumerable<Zap>> GetAllAsync();
    }
}
