using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IQuantitéTriéeParJourRepository : IRepository<QuantitéTriéeParJour>
    {
        Task<QuantitéTriéeParJour> AddAsync(QuantitéTriéeParJour entity);
        Task UpdateAsync(QuantitéTriéeParJour entity);
        Task DeleteAsync(QuantitéTriéeParJour entity);
        Task<QuantitéTriéeParJour> GetByIdAsync(int id);
        Task<IEnumerable<QuantitéTriéeParJour>> GetAllAsync();
    }
}
