using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Interfaces
{
    public interface IActionImmediateGlobaleServices
    {
        Task<ActionImmediateGlobaleDto> GetByIdAsync(int id);
        Task<IEnumerable<ActionImmediateGlobaleDto>> GetAllAsync();
        Task<ActionImmediateGlobaleDto> CreateAsync(CreateActionImmediateGlobaleDto dto);
        Task<bool> UpdateAsync(int id, CreateActionImmediateGlobaleDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
