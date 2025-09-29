using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Interfaces
{
    public interface IQuantitéTriéeParJourServices
    {
        Task<QuantitéTriéeParJourDto> GetByIdAsync(int id);
        Task<IEnumerable<QuantitéTriéeParJourDto>> GetAllAsync();
        Task<QuantitéTriéeParJourDto> CreateAsync(CreateQuantitéTriéeParJourDto dto);
        Task<bool> UpdateAsync(int id, CreateQuantitéTriéeParJourDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
