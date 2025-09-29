using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IActionDeSecurisationD3Repository : IRepository<ActionDeSecurisationD3>
    {
        Task<ActionDeSecurisationD3> AddAsync(ActionDeSecurisationD3 entity);
        Task UpdateAsync(ActionDeSecurisationD3 entity);
        Task DeleteAsync(ActionDeSecurisationD3 entity);
        Task<ActionDeSecurisationD3> GetByIdAsync(int id);
        Task<IEnumerable<ActionDeSecurisationD3>> GetAllAsync();
    }
}
