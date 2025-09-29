using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IRéclamationRepository : IRepository<Réclamation>
    {
        Task<Réclamation> AddAsync(Réclamation entity);
        Task UpdateAsync(Réclamation entity);
        Task DeleteAsync(Réclamation entity);
        Task<Réclamation> GetByIdAsync(int id);
        Task<IEnumerable<Réclamation>> GetAllAsync();
    }
}
