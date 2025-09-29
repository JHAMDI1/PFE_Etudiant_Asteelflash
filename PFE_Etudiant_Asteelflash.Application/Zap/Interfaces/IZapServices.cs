using PFE_Etudiant_Asteelflash.Application.Zap.Dtos;
using PFE_Etudiant_Asteelflash.Application.Fnc.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PFE_Etudiant_Asteelflash.Application.Zap.Interfaces
{
    public interface IZapServices
    {
        // CRUD operations
        Task<ZapDto> GetZapByIdAsync(int id);
        Task<IEnumerable<ZapListItemDto>> GetAllZapsAsync();
        Task<ZapDto> CreateZapAsync(CreateZapDto createZapDto);
        Task<bool> UpdateZapAsync(UpdateZapDto updateZapDto);
        Task<bool> DeleteZapAsync(int id);
        
        // Specific operations
        Task<ZapDetailDto> GetZapByIdWithDetailsAsync(int id);
        Task<IEnumerable<ZapListItemDto>> GetAllZapsWithDetailsAsync();
        Task<IEnumerable<ZapListItemDto>> SearchZapsAsync(string searchTerm);
        
        // La pagination a été supprimée
    }
}
