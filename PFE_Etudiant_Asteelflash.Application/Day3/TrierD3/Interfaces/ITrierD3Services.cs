using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Interfaces
{
    public interface ITrierD3Services
    {
        Task<TrierD3Dto> GetByIdAsync(int id);
        Task<IEnumerable<TrierD3Dto>> GetAllAsync();
        Task<TrierD3Dto> CreateAsync(CreateTrierD3Dto dto);
        Task<bool> UpdateAsync(int id, CreateTrierD3Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
