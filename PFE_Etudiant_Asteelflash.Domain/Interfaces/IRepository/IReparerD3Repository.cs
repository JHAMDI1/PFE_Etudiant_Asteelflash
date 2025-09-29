using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IReparerD3Repository : IRepository<ReparerD3>
    {
        Task<ReparerD3> AddAsync(ReparerD3 entity);
        Task UpdateAsync(ReparerD3 entity);
        Task DeleteAsync(ReparerD3 entity);
        Task<ReparerD3> GetByIdAsync(int id);
        Task<IEnumerable<ReparerD3>> GetAllAsync();
    }
}
