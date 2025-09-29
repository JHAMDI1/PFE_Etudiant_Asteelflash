using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IActD7Repository : IRepository<ActD7>
    {
        Task<ActD7> AddAsync(ActD7 entity);
        Task UpdateAsync(ActD7 entity);
        Task DeleteAsync(ActD7 entity);
        Task<ActD7> GetByIdAsync(int id);
        Task<IEnumerable<ActD7>> GetAllAsync();
    }
}
