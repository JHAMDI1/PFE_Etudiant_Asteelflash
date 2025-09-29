using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Interfaces
{
    public interface IListeDesActionsD3Services
    {
        Task<ListeDesActionsD3Dto> GetByIdAsync(int id);
        Task<IEnumerable<ListeDesActionsD3Dto>> GetAllAsync();
        Task<ListeDesActionsD3Dto> CreateAsync(CreateListeDesActionsD3Dto dto);
        Task<bool> UpdateAsync(int id, CreateListeDesActionsD3Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
