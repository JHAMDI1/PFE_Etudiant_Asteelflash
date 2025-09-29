using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day5.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day5.Interfaces
{
    public interface IPlanActionsCorrectivesD5Services
    {
        Task<PlanActionsCorrectivesD5Dto> GetByIdAsync(int id);
        Task<IEnumerable<PlanActionsCorrectivesD5Dto>> GetAllAsync();
        Task<PlanActionsCorrectivesD5Dto> CreateAsync(CreatePlanActionsCorrectivesD5Dto dto);
        Task<bool> UpdateAsync(int id, CreatePlanActionsCorrectivesD5Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
