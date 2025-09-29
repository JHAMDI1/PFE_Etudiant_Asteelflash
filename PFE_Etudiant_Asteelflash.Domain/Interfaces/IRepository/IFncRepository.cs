using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository
{
    public interface IFncRepository : IRepository<Fnc>
    {
        // Méthodes CRUD spécifiques
        Task<Fnc> GetFncByIdWithDetailsAsync(int id);
        Task<IEnumerable<Fnc>> GetAllFncsWithDetailsAsync();
        Task<bool> DeleteFncAsync(int id);
        Task<bool> UpdateFncAsync(Fnc fnc);
       
        // Méthodes spécifiques existantes
        Task<IEnumerable<Fnc>> GetFncsByDateAsync(DateTime date);
        Task<IEnumerable<Fnc>> GetFncsByStatusAsync(string status);
        
        // Nouvelles méthodes de recherche
        Task<IEnumerable<Fnc>> SearchFncsAsync(string searchTerm);
        Task<int> CountFncsByStatusAsync(string status);
    }
}
