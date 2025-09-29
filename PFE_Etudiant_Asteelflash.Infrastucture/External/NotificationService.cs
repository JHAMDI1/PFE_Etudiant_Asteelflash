using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Enums;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.External;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PFE_Etudiant_Asteelflash.Infrastucture.Hubs;
using System.Linq;

namespace PFE_Etudiant_Asteelflash.Infrastucture.External
{
    public class NotificationService : INotificationService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly IHubContext<NotificationHub, INotificationClient> _hub;
        private readonly UserManager<ApplicationUser> _users;

        public NotificationService(
            ApplicationDbContext ctx,
            IHubContext<NotificationHub, INotificationClient> hub,
            UserManager<ApplicationUser> users)
        {
            _ctx = ctx;
            _hub = hub;
            _users = users;
        }

        public async Task SendFncCreatedAsync(Fnc fnc, CancellationToken ct = default)
        {
            Console.WriteLine($"SendFncCreatedAsync appelé pour FNC ID: {fnc.Id}, Ref: {fnc.Ref}, ZapEmettriceId: {fnc.ZapEmettriceId}, ZapReceptriceId: {fnc.ZapReceptriceId}, Status: {fnc.Status}");
            
            // Règle métier : seules les FNC de type CMS, VAGUE, INTEGRATION ou PREPARATION 
            // et ayant le statut Ouverte déclenchent la notification
            if (fnc.Status != StatusFNC.ouvert)
            {
                Console.WriteLine($"Notification non envoyée: la FNC n'est pas en statut 'ouvert' mais '{fnc.Status}'");
                return;
            }

            // Notifier uniquement si la FNC appartient à l'un des ZAP autorisés
            var allowedZaps = new[] { zapName.CMS, zapName.VAGUE, zapName.INTEGRATION, zapName.PREPARATION };

            // Vérifier que la ZAP réceptrice est chargée et autorisée
            if (fnc.ZapReceptrice == null)
            {
                Console.WriteLine($"Notification non envoyée: la propriété ZapReceptrice n'est pas chargée pour la FNC {fnc.Id}");
                return;
            }
            
            if (!allowedZaps.Contains(fnc.ZapReceptrice.Name))
            {
                Console.WriteLine($"Notification non envoyée: le ZAP '{fnc.ZapReceptrice.Name}' n'est pas dans la liste des ZAPs autorisés");
                return;
            }
            
            Console.WriteLine($"La FNC {fnc.Id} a un ZAP valide: {fnc.ZapReceptrice.Name}");

            // Récupérer tous les utilisateurs qui doivent recevoir la notification:
            // Chef Équipe, Responsable et Ingénieur du même ZAP
            Console.WriteLine($"Recherche d'utilisateurs pour les ZAPs Émettrice: {fnc.ZapEmettriceId} et Réceptrice: {fnc.ZapReceptriceId}");
            
            var fonctions = new[] { Fonction.Chef_Equipe, Fonction.Responsable, Fonction.Ingenieur };
            Console.WriteLine($"Fonctions recherchées: {string.Join(", ", fonctions)}");
            
            List<string> recipientIds;
            try
            {
                // D'abord, vérifions tous les utilisateurs de ce ZAP
                var allUsersInZap = await _users.Users
                    .Where(u => u.UsersZaps.Any(uz => uz.ZapId == fnc.ZapReceptriceId || uz.ZapId == fnc.ZapEmettriceId))
                    .Select(u => new { u.Id, u.UserName, u.Fonction })
                    .ToListAsync(ct);
                
                Console.WriteLine($"Nombre total d'utilisateurs dans ce ZAP: {allUsersInZap.Count}");
                foreach (var user in allUsersInZap)
                {
                    Console.WriteLine($"Utilisateur trouvé dans ZAP - ID: {user.Id}, Nom: {user.UserName}, Fonction: {user.Fonction}");
                }
                
                // Maintenant filtrons par fonction
                recipientIds = await _users.Users
                    .Where(u => (u.UsersZaps.Any(uz => uz.ZapId == fnc.ZapReceptriceId || uz.ZapId == fnc.ZapEmettriceId)) && fonctions.Contains(u.Fonction))
                    .Select(u => u.Id)
                    .ToListAsync(ct);

                // Inclure également l'émetteur afin qu'il reçoive une notification et puisse gérer la FNC
                if (!string.IsNullOrWhiteSpace(fnc.TransmitterID) && !recipientIds.Contains(fnc.TransmitterID))
                {
                    recipientIds.Add(fnc.TransmitterID);
                }
                
                Console.WriteLine($"Nombre de destinataires éligibles: {recipientIds.Count}");
                foreach (var id in recipientIds)
                {
                    Console.WriteLine($"Destinataire éligible: {id}");
                }
                
                // Si aucun destinataire trouvé, ne pas créer de notification
                if (!recipientIds.Any())
                {
                    Console.WriteLine("Aucun destinataire trouvé, aucune notification ne sera créée");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la recherche des destinataires: {ex.Message}");
                return;
            }

            // Créer une notification pour chaque destinataire
            foreach (var userId in recipientIds)
            {
                var entity = new Notification
                {
                    UserId = userId,
                    Message = $"Nouvelle FNC {fnc.Ref} ouverte",
                    Type = "Nouvelle FNC",
                    Link = $"/Fnc/Details/{fnc.Id}",
                    FncId = fnc.Id,
                    TypeFnc = fnc.TypeFnc,
                    IsRead = false,
                    CreatedAt = DateTime.UtcNow
                };

                _ctx.Notification.Add(entity);
            }

            await _ctx.SaveChangesAsync(ct);

            // Créer une notification pour chaque destinataire dans la base de données
            Console.WriteLine($"Création de {recipientIds.Count} notifications en base de données");
            
            // Pour chaque destinataire, envoyer la notification via SignalR
            foreach (var userId in recipientIds)
            {
                try 
                {
                    Console.WriteLine($"Recherche de notification pour l'utilisateur {userId} et la FNC {fnc.Id}");
                    var notif = await _ctx.Notification
                        .Where(n => n.UserId == userId && n.FncId == fnc.Id)
                        .OrderByDescending(n => n.CreatedAt)
                        .FirstOrDefaultAsync(ct);

                    if (notif != null)
                    {
                        Console.WriteLine($"Notification trouvée: ID={notif.Id}, Message={notif.Message}");
                        var dto = new
                        {
                            notif.Id,
                            notif.Message,
                            notif.Type,
                            notif.Link,
                            notif.CreatedAt,
                            FncRef = fnc.Ref
                        };

                        Console.WriteLine($"Envoi de notification SignalR à l'utilisateur {userId}");
                        await _hub.Clients.User(userId).ReceiveNotification(dto);
                        Console.WriteLine($"Notification SignalR envoyée avec succès à l'utilisateur {userId}");
                    }
                    else
                    {
                        Console.WriteLine($"Aucune notification trouvée pour l'utilisateur {userId} et la FNC {fnc.Id}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erreur lors de l'envoi de la notification à l'utilisateur {userId}: {ex.Message}");
                }
            }
        }

        public async Task SendApprobationConducteurAsync(Fnc fnc, string conducteurId, CancellationToken ct = default)
        {
            if (fnc == null || string.IsNullOrWhiteSpace(conducteurId))
                return;

            try
            {
                // Vérifier que le conducteur existe
                var conducteur = await _users.FindByIdAsync(conducteurId);
                if (conducteur == null)
                    return;

                // Créer la notification unique pour le conducteur CMS
                var entity = new Notification
                {
                    UserId = conducteurId,
                    Message = $"Approbation requise pour la FNC {fnc.Ref}",
                    Type = "Approbation FNC",
                    Link = $"/Fnc/Details/{fnc.Id}",
                    FncId = fnc.Id,
                    TypeFnc = fnc.TypeFnc,
                    IsRead = false,
                    CreatedAt = DateTime.UtcNow
                };

                _ctx.Notification.Add(entity);
                await _ctx.SaveChangesAsync(ct);

                // Pousser via SignalR
                var dto = new
                {
                    entity.Id,
                    entity.Message,
                    entity.Type,
                    entity.Link,
                    entity.CreatedAt,
                    FncRef = fnc.Ref
                };

                await _hub.Clients.User(conducteurId).ReceiveNotification(dto);
            }
            catch
            {
                // logging simplifié pour l'instant
            }
        }

        // Réclamation créée
        public async Task SendReclamationCreatedAsync(int reclamationId, CancellationToken ct = default)
        {
            var reclamation = await _ctx.Réclamation
                .Include(r => r.User)
                    .ThenInclude(u => u.UsersZaps)
                .FirstOrDefaultAsync(r => r.Id == reclamationId, ct);

            if (reclamation == null || reclamation.User == null)
                return;

            var userZapIds = reclamation.User.UsersZaps.Select(uz => uz.ZapId).ToList();
            if (!userZapIds.Any())
                return;

            var fonctions = new[] { Fonction.Chef_Equipe, Fonction.Responsable };

            var recipients = await _users.Users
                .Where(u => u.Id != reclamation.UserId
                            && fonctions.Contains(u.Fonction)
                            && u.UsersZaps.Any(uz => userZapIds.Contains(uz.ZapId)))
                .ToListAsync(ct);

            if (!recipients.Any())
                return;

            string message = $"Nouvelle réclamation de {reclamation.User.FirstName} {reclamation.User.LastName}";
            string link = $"/Reclamation/Details/{reclamation.Id}";

            foreach (var recipient in recipients)
            {
                _ctx.Notification.Add(new Notification
                {
                    UserId = recipient.Id,
                    Message = message,
                    Type = "Réclamation",
                    Link = link,
                    IsRead = false,
                    CreatedAt = DateTime.UtcNow
                });
            }
            await _ctx.SaveChangesAsync(ct);

            var dto = new { Message = message, Type = "Réclamation", Link = link, CreatedAt = DateTime.UtcNow, reclamation.Id };
            foreach (var recipient in recipients)
            {
                await _hub.Clients.User(recipient.Id).ReceiveNotification(dto);
            }
        }

        public async Task<bool> IsUserRecipientAsync(int fncId, string userId, CancellationToken ct = default)
        {
            if (string.IsNullOrEmpty(userId)) return false;
            return await _ctx.Notification.AnyAsync(n => n.FncId == fncId && n.UserId == userId, ct);
        }

        public async Task SendAsync(IEnumerable<string> userIds, string message, string type, string link, CancellationToken ct = default)
        {
            if (userIds == null) return;
            var now = DateTime.UtcNow;
            foreach (var uid in userIds.Distinct())
            {
                _ctx.Notification.Add(new Notification
                {
                    UserId = uid,
                    Message = message,
                    Type = type,
                    Link = link,
                    IsRead = false,
                    CreatedAt = now
                });
            }
            await _ctx.SaveChangesAsync(ct);

            var dto = new { Message = message, Type = type, Link = link, CreatedAt = now };
            foreach (var uid in userIds.Distinct())
            {
                await _hub.Clients.User(uid).ReceiveNotification(dto);
            }
        }

        public async Task MarkAsReadAsync(int id, CancellationToken ct = default)
        {
            var notification = await _ctx.Notification.FindAsync(new object[] { id }, ct);
            if (notification == null)
                return;

            notification.IsRead = true;
            await _ctx.SaveChangesAsync(ct);
        }
    }
}
