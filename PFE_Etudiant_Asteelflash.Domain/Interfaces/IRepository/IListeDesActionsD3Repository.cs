using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IListeDesActionsD3Repository : IRepository<ListeDesActionsD3>
    {
        Task<ListeDesActionsD3> AddAsync(ListeDesActionsD3 entity);
        Task UpdateAsync(ListeDesActionsD3 entity);
        Task DeleteAsync(ListeDesActionsD3 entity);
        Task<ListeDesActionsD3> GetByIdAsync(int id);
        Task<IEnumerable<ListeDesActionsD3>> GetAllAsync();
    }
}
