using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Réclamation.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Réclamation.Interfaces
{
    public interface IReclamationServices
    {
        Task<ReclamationDto> GetByIdAsync(int id);
        Task<IEnumerable<ReclamationDto>> GetAllAsync();
        Task<ReclamationDto> CreateAsync(CreateReclamationDto dto);
        Task<bool> UpdateAsync(int id, CreateReclamationDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
