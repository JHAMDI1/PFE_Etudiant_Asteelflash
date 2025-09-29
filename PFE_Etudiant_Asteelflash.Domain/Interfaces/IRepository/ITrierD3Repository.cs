using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface ITrierD3Repository : IRepository<TrierD3>
    {
        Task<TrierD3> AddAsync(TrierD3 entity);
        Task UpdateAsync(TrierD3 entity);
        Task DeleteAsync(TrierD3 entity);
        Task<TrierD3> GetByIdAsync(int id);
        Task<IEnumerable<TrierD3>> GetAllAsync();
    }
}
