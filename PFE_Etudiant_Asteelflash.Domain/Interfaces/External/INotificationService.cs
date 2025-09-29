using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Domain.Interfaces.External
{
    public interface INotificationService
    {
        Task SendFncCreatedAsync(Fnc fnc, CancellationToken ct = default);
        Task MarkAsReadAsync(int id, CancellationToken ct = default);

        // Demande d'approbation conducteur spécifique (Conducteur CMS)
        Task SendApprobationConducteurAsync(Fnc fnc, string conducteurId, CancellationToken ct = default);
         
        // Vérifie si un utilisateur a reçu la notification pour une FNC donnée
        Task<bool> IsUserRecipientAsync(int fncId, string userId, CancellationToken ct = default);

        // Réclamation
        Task SendReclamationCreatedAsync(int reclamationId, CancellationToken ct = default);

        // Generic send (QRQC etc.)
        Task SendAsync(IEnumerable<string> userIds, string message, string type, string link, CancellationToken ct = default);
    }
}
