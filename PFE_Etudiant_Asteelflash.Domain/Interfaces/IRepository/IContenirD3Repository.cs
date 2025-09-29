using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IContenirD3Repository : IRepository<ContenirD3>
    {
        Task<ContenirD3> AddAsync(ContenirD3 entity);
        Task UpdateAsync(ContenirD3 entity);
        Task DeleteAsync(ContenirD3 entity);
        Task<ContenirD3> GetByIdAsync(int id);
        Task<IEnumerable<ContenirD3>> GetAllAsync();
    }
}
