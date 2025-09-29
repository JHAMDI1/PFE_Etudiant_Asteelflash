using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Qrqc.Interfaces
{
    public interface IQrqcServices
    {
        Task<QrqcDto> GetQrqcByIdAsync(int id);
        Task<IEnumerable<QrqcDto>> GetAllQrqcAsync();
        Task<QrqcDto> CreateQrqcAsync(CreateGlobalQrqcDto dto);
        Task<bool> UpdateQrqcAsync(int id, CreateQrqcDto dto);
        Task<bool> DeleteQrqcAsync(int id);
        Task<GlobalQrqcDto> GetGlobalQrqcByIdAsync(int id);
    }
}
