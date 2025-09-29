using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IPlanActionsCorrectivesD5Repository : IRepository<PlanActionsCorrectivesD5>
    {
        Task<PlanActionsCorrectivesD5> AddAsync(PlanActionsCorrectivesD5 entity);
        Task UpdateAsync(PlanActionsCorrectivesD5 entity);
        Task DeleteAsync(PlanActionsCorrectivesD5 entity);
        Task<PlanActionsCorrectivesD5> GetByIdAsync(int id);
        Task<IEnumerable<PlanActionsCorrectivesD5>> GetAllAsync();
    }
}
