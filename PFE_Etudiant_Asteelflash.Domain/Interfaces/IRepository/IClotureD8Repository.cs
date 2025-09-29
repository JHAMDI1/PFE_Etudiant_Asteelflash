using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IClotureD8Repository : IRepository<ClotureD8>
    {
        Task<ClotureD8> AddAsync(ClotureD8 entity);
        Task UpdateAsync(ClotureD8 entity);
        Task DeleteAsync(ClotureD8 entity);
        Task<ClotureD8> GetByIdAsync(int id);
        Task<IEnumerable<ClotureD8>> GetAllAsync();
    }
}
