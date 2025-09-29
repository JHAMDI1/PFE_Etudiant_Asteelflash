using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Interfaces
{
    public interface IAssurerD3Services
    {
        Task<AssurerD3Dto> GetByIdAsync(int id);
        Task<IEnumerable<AssurerD3Dto>> GetAllAsync();
        Task<AssurerD3Dto> CreateAsync(CreateAssurerD3Dto dto);
        Task<bool> UpdateAsync(int id, CreateAssurerD3Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
