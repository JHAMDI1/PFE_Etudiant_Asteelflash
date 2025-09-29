using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface ICausesNonDetectionD4Repository : IRepository<CausesNonDetectionD4>
    {
        Task<CausesNonDetectionD4> AddAsync(CausesNonDetectionD4 entity);
        Task UpdateAsync(CausesNonDetectionD4 entity);
        Task DeleteAsync(CausesNonDetectionD4 entity);
        Task<CausesNonDetectionD4> GetByIdAsync(int id);
        Task<IEnumerable<CausesNonDetectionD4>> GetAllAsync();
    }
}
