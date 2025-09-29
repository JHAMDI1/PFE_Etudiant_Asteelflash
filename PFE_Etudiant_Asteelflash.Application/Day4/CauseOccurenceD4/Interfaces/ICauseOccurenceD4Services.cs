using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Interfaces
{
    public interface ICauseOccurenceD4Services
    {
        Task<CauseOccurenceD4Dto> GetByIdAsync(int id);
        Task<IEnumerable<CauseOccurenceD4Dto>> GetAllAsync();
        Task<CauseOccurenceD4Dto> CreateAsync(CreateCauseOccurenceD4Dto dto);
        Task<bool> UpdateAsync(int id, CreateCauseOccurenceD4Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
