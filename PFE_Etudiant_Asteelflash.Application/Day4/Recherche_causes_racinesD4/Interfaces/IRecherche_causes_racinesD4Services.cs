using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Interfaces
{
    public interface IRecherche_causes_racinesD4Services
    {
        Task<Recherche_causes_racinesD4Dto> GetByIdAsync(int id);
        Task<IEnumerable<Recherche_causes_racinesD4Dto>> GetAllAsync();
        Task<Recherche_causes_racinesD4Dto> CreateAsync(Recherche_causes_racinesD4Dto dto);
        Task<bool> UpdateAsync(int id, Recherche_causes_racinesD4Dto dto);
        Task<bool> DeleteAsync(int id);
    }
}
