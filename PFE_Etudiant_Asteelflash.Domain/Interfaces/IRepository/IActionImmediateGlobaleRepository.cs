using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IActionImmediateGlobaleRepository : IRepository<ActionImmediateGlobale>
    {
        Task<ActionImmediateGlobale> AddAsync(ActionImmediateGlobale entity);
        Task UpdateAsync(ActionImmediateGlobale entity);
        Task DeleteAsync(ActionImmediateGlobale entity);
        Task<ActionImmediateGlobale> GetByIdAsync(int id);
        Task<IEnumerable<ActionImmediateGlobale>> GetAllAsync();
    }
}
