using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day2.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day2.Interfaces
{
    public interface IDescriptionDuProblemeD2Services
    {
        Task<DescriptionDuProblemeD2Dto> GetByIdAsync(int id);
        Task<IEnumerable<DescriptionDuProblemeD2Dto>> GetAllAsync();
        Task<DescriptionDuProblemeD2Dto> CreateAsync(CreateDescriptionDuProblemeD2Dto dto);
        Task<bool> UpdateAsync(int id, CreateDescriptionDuProblemeD2Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
