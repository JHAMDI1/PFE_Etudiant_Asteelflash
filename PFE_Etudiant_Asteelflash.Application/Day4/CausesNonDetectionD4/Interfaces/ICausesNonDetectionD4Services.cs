using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Interfaces
{
    public interface ICausesNonDetectionD4Services
    {
        Task<CausesNonDetectionD4Dto> GetByIdAsync(int id);
        Task<IEnumerable<CausesNonDetectionD4Dto>> GetAllAsync();
        Task<CausesNonDetectionD4Dto> CreateAsync(CreateCausesNonDetectionD4Dto dto);
        Task<bool> UpdateAsync(int id, CreateCausesNonDetectionD4Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
