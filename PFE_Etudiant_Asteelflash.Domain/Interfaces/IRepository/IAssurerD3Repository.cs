using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IAssurerD3Repository : IRepository<AssurerD3>
    {
        Task<AssurerD3> AddAsync(AssurerD3 entity);
        Task UpdateAsync(AssurerD3 entity);
        Task DeleteAsync(AssurerD3 entity);
        Task<AssurerD3> GetByIdAsync(int id);
        Task<IEnumerable<AssurerD3>> GetAllAsync();
    }
}
