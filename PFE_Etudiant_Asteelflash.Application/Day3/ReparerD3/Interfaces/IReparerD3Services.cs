using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Interfaces
{
    public interface IReparerD3Services
    {
        Task<ReparerD3Dto> GetByIdAsync(int id);
        Task<IEnumerable<ReparerD3Dto>> GetAllAsync();
        Task<ReparerD3Dto> CreateAsync(CreateReparerD3Dto dto);
        Task<bool> UpdateAsync(int id, CreateReparerD3Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
