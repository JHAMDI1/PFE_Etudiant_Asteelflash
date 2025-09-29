using PFE_Etudiant_Asteelflash.Application.Fnc.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Interfaces
{
    public interface IFncServices
    {
        // Méthodes CRUD
        Task<FncDto> GetFncByIdAsync(int id);
        Task<IEnumerable<FncListItemDto>> GetAllFncsAsync();
        Task<FncDto> CreateFncAsync(CreateFncDto createFncDto);
        Task<bool> UpdateFncAsync(UpdateFncDto updateFncDto);
        Task<bool> DeleteFncAsync(int id);
        
        // Méthodes spécifiques
        Task<FncDetailDto> GetFncByIdWithDetailsAsync(int id);
        Task<IEnumerable<FncListItemDto>> GetAllFncsWithDetailsAsync();
        Task<IEnumerable<FncListItemDto>> GetFncsByDateAsync(DateTime date);
        Task<IEnumerable<FncListItemDto>> GetFncsByStatusAsync(string status);
        Task<IEnumerable<FncListItemDto>> SearchFncsAsync(string searchTerm);
        Task<int> CountFncsByStatusAsync(string status);
        
        // Méthode pour les statistiques
        Task<FncStatisticsDto> GetFncStatisticsAsync();
        
        // Méthode pour filtrer les FNCs par statut et type
        Task<IEnumerable<FncListItemDto>> FilterFncsAsync(FncFilterDto filterDto);

        // Vérifie si un utilisateur est destinataire de la notification liée à une FNC
        Task<bool> IsUserRecipientAsync(int fncId, string userId);

        // Approuve une FNC (modifie son état) si l'utilisateur est autorisé
        Task<bool> AcceptFncAsync(int fncId, string userId);

        // Rejette une FNC (modifie son état) si l'utilisateur est autorisé
        Task<bool> RejectFncAsync(int fncId, string userId);
    }
}
