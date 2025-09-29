using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IQrqcRepository : IRepository<Qrqc>
    {
        Task<Qrqc> AddAsync(Qrqc entity);
        Task UpdateAsync(Qrqc entity);
        Task DeleteAsync(Qrqc entity);
        Task<Qrqc> GetByIdAsync(int id);
        Task<IEnumerable<Qrqc>> GetAllAsync();
    }
}
