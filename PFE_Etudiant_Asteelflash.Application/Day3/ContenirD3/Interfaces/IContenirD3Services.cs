using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Interfaces
{
    public interface IContenirD3Services
    {
        Task<ContenirD3Dto> GetByIdAsync(int id);
        Task<IEnumerable<ContenirD3Dto>> GetAllAsync();
        Task<ContenirD3Dto> CreateAsync(CreateContenirD3Dto dto);
        Task<bool> UpdateAsync(int id, CreateContenirD3Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
