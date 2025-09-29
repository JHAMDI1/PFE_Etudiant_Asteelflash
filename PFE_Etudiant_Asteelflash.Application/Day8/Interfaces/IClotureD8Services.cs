using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day8.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day8.Interfaces
{
    public interface IClotureD8Services
    {
        Task<ClotureD8Dto> GetByIdAsync(int id);
        Task<IEnumerable<ClotureD8Dto>> GetAllAsync();
        Task<ClotureD8Dto> CreateAsync(CreateClotureD8Dto dto);
        Task<bool> UpdateAsync(int id, CreateClotureD8Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
