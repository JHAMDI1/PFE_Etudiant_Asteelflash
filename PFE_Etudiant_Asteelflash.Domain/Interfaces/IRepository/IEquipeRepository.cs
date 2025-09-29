using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IEquipeRepository : IRepository<Equipe>
    {
        Task<Equipe> AddAsync(Equipe entity);
        Task UpdateAsync(Equipe entity);
        Task DeleteAsync(Equipe entity);
        Task<Equipe> GetByIdAsync(int id);
        Task<IEnumerable<Equipe>> GetAllAsync();
    }
}
