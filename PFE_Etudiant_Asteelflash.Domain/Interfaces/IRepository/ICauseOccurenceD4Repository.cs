using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface ICauseOccurenceD4Repository : IRepository<CauseOccurenceD4>
    {
        Task<CauseOccurenceD4> AddAsync(CauseOccurenceD4 entity);
        Task UpdateAsync(CauseOccurenceD4 entity);
        Task DeleteAsync(CauseOccurenceD4 entity);
        Task<CauseOccurenceD4> GetByIdAsync(int id);
        Task<IEnumerable<CauseOccurenceD4>> GetAllAsync();
    }
}
