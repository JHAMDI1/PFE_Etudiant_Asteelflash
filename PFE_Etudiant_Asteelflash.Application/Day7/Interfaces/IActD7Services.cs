using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day7.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day7.Interfaces
{
    public interface IActD7Services
    {
        Task<ActD7Dto> GetByIdAsync(int id);
        Task<IEnumerable<ActD7Dto>> GetAllAsync();
        Task<ActD7Dto> CreateAsync(CreateActD7Dto dto);
        Task<bool> UpdateAsync(int id, CreateActD7Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
