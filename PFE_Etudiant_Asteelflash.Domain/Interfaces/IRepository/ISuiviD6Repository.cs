using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface ISuiviD6Repository : IRepository<SuiviD6>
    {
        Task<SuiviD6> AddAsync(SuiviD6 entity);
        Task UpdateAsync(SuiviD6 entity);
        Task DeleteAsync(SuiviD6 entity);
        Task<SuiviD6> GetByIdAsync(int id);
        Task<IEnumerable<SuiviD6>> GetAllAsync();
    }
}
