using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Interfaces
{
    public interface IActionDeSecurisationD3Services
    {
        Task<ActionDeSecurisationD3Dto> GetByIdAsync(int id);
        Task<IEnumerable<ActionDeSecurisationD3Dto>> GetAllAsync();
        Task<ActionDeSecurisationD3Dto> CreateAsync(CreateActionDeSecurisationD3Dto dto);
        Task<bool> UpdateAsync(int id, CreateActionDeSecurisationD3Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
