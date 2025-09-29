using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Interfaces
{
    public interface ITriActionImmediateGlobaleServices
    {
        Task<TriActionImmediateGlobaleDto> GetByIdAsync(int id);
        Task<IEnumerable<TriActionImmediateGlobaleDto>> GetAllAsync();
        Task<TriActionImmediateGlobaleDto> CreateAsync(CreateTriActionImmediateGlobaleDto dto);
        Task<bool> UpdateAsync(int id, CreateTriActionImmediateGlobaleDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
