using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IRecherche_causes_racinesD4Repository : IRepository<Recherche_causes_racinesD4>
    {
        Task<Recherche_causes_racinesD4> AddAsync(Recherche_causes_racinesD4 entity);
        Task UpdateAsync(Recherche_causes_racinesD4 entity);
        Task DeleteAsync(Recherche_causes_racinesD4 entity);
        Task<Recherche_causes_racinesD4> GetByIdAsync(int id);
        Task<IEnumerable<Recherche_causes_racinesD4>> GetAllAsync();
    }
}
