using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day6.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day6.Interfaces
{
    public interface ISuiviD6Services
    {
        Task<SuiviD6Dto> GetByIdAsync(int id);
        Task<IEnumerable<SuiviD6Dto>> GetAllAsync();
        Task<SuiviD6Dto> CreateAsync(CreateSuiviD6Dto dto);
        Task<bool> UpdateAsync(int id, CreateSuiviD6Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
