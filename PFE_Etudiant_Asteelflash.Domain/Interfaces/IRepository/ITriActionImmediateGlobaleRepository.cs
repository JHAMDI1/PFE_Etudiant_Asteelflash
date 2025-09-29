using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface ITriActionImmediateGlobaleRepository : IRepository<TriActionImmediateGlobale>
    {
        Task<TriActionImmediateGlobale> AddAsync(TriActionImmediateGlobale entity);
        Task UpdateAsync(TriActionImmediateGlobale entity);
        Task DeleteAsync(TriActionImmediateGlobale entity);
        Task<TriActionImmediateGlobale> GetByIdAsync(int id);
        Task<IEnumerable<TriActionImmediateGlobale>> GetAllAsync();
    }
}
