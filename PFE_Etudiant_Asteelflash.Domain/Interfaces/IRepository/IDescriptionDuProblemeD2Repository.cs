using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IDescriptionDuProblemeD2Repository : IRepository<DescriptionDuProblemeD2>
    {
        Task<DescriptionDuProblemeD2> AddAsync(DescriptionDuProblemeD2 entity);
        Task UpdateAsync(DescriptionDuProblemeD2 entity);
        Task DeleteAsync(DescriptionDuProblemeD2 entity);
        Task<DescriptionDuProblemeD2> GetByIdAsync(int id);
        Task<IEnumerable<DescriptionDuProblemeD2>> GetAllAsync();
    }
}
