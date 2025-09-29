using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Fnc.Dtos;
using PFE_Etudiant_Asteelflash.Application.Fnc.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Enums;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.Upload_File;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.External;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Services
{
    public class FncServices : IFncServices
    {
        private readonly IFncRepository _fncRepository;
        private readonly IMapper _mapper;
        private readonly IFileHelper _fileHelper;
        private readonly INotificationService _notificationService;
        private readonly UserManager<ApplicationUser> _users;

        public FncServices(IFncRepository fncRepository, IMapper mapper, IFileHelper fileHelper, INotificationService notificationService, UserManager<ApplicationUser> users)
        {
            _fncRepository = fncRepository ?? throw new ArgumentNullException(nameof(fncRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _fileHelper = fileHelper ?? throw new ArgumentNullException(nameof(fileHelper));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _users = users ?? throw new ArgumentNullException(nameof(users));
        }

        public async Task<FncDto> CreateFncAsync(CreateFncDto createFncDto)
        {
            if (createFncDto == null)
                throw new ArgumentNullException(nameof(createFncDto));

            // Gérer l'upload des fichiers images (tous optionnels)
            if (createFncDto.ImageFile_Piece_bonne != null && createFncDto.ImageFile_Piece_bonne.Length > 0)
            {
                createFncDto.ImageUrl_Piece_bonne = _fileHelper.UploadFile(createFncDto.ImageFile_Piece_bonne, "uploads/fnc");
            }
            if (createFncDto.ImageFile_Piece_Mauvaise != null && createFncDto.ImageFile_Piece_Mauvaise.Length > 0)
            {
                createFncDto.ImageUrl_Piece_Mauvaise = _fileHelper.UploadFile(createFncDto.ImageFile_Piece_Mauvaise, "uploads/fnc");
            }
            if (createFncDto.ImageFile_3 != null && createFncDto.ImageFile_3.Length > 0)
            {
                createFncDto.ImageUrl_3 = _fileHelper.UploadFile(createFncDto.ImageFile_3, "uploads/fnc");
            }
            if (createFncDto.ImageFile_4 != null && createFncDto.ImageFile_4.Length > 0)
            {
                createFncDto.ImageUrl_4 = _fileHelper.UploadFile(createFncDto.ImageFile_4, "uploads/fnc");
            }
            if (createFncDto.ImageFile_5 != null && createFncDto.ImageFile_5.Length > 0)
            {
                createFncDto.ImageUrl_5 = _fileHelper.UploadFile(createFncDto.ImageFile_5, "uploads/fnc");
            }

            // Mapper le DTO vers l'entité
            var fncEntity = _mapper.Map<Domain.Entities.Fnc>(createFncDto);



            // Enregistrer dans la base de données
            var createdFnc = await _fncRepository.AddAsync(fncEntity);

            // Recharger la FNC avec ses relations nécessaires (e.g., Zap) avant d'envoyer la notification
            var fncWithDetails = await _fncRepository.GetFncByIdWithDetailsAsync(createdFnc.Id);

            // Gérer les notifications selon le rôle de l'émetteur
            await HandleNotificationsAsync(fncWithDetails ?? createdFnc, createFncDto.ConducteurId);
            
            // Retourner le DTO
            return _mapper.Map<FncDto>(createdFnc);
        }

        public async Task<bool> DeleteFncAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("L'ID doit être un nombre positif", nameof(id));

            return await _fncRepository.DeleteFncAsync(id);
        }

        public async Task<IEnumerable<FncListItemDto>> GetAllFncsAsync()
        {
            // Utiliser la méthode détaillée afin d'éviter les problèmes de chargement paresseux ou d'exceptions de casting
            var fncs = await _fncRepository.GetAllFncsWithDetailsAsync();
            return _mapper.Map<IEnumerable<FncListItemDto>>(fncs);
        }

        public async Task<IEnumerable<FncListItemDto>> GetAllFncsWithDetailsAsync()
        {
            var fncs = await _fncRepository.GetAllFncsWithDetailsAsync();
            return _mapper.Map<IEnumerable<FncListItemDto>>(fncs);
        }

        public async Task<FncDto> GetFncByIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("L'ID doit être un nombre positif", nameof(id));

            var fnc = await _fncRepository.GetByIdAsync(id);
            if (fnc == null)
                throw new KeyNotFoundException($"Aucune FNC trouvée avec l'ID {id}");

            return _mapper.Map<FncDto>(fnc);
        }

        public async Task<FncDetailDto> GetFncByIdWithDetailsAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("L'ID doit être un nombre positif", nameof(id));

            var fnc = await _fncRepository.GetFncByIdWithDetailsAsync(id);
            if (fnc == null)
                throw new KeyNotFoundException($"Aucune FNC trouvée avec l'ID {id}");

            return _mapper.Map<FncDetailDto>(fnc);
        }

        public async Task<IEnumerable<FncListItemDto>> GetFncsByDateAsync(DateTime date)
        {
            var fncs = await _fncRepository.GetFncsByDateAsync(date);
            return _mapper.Map<IEnumerable<FncListItemDto>>(fncs);
        }

        public async Task<IEnumerable<FncListItemDto>> GetFncsByStatusAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Le status ne peut pas être vide", nameof(status));

            // Vérifier si le status est valide en essayant de le convertir en enum
            if (Enum.TryParse<StatusFNC>(status, out var parsedStatus))
            {
                var fncs = await _fncRepository.GetFncsByStatusAsync(status);
                return _mapper.Map<IEnumerable<FncListItemDto>>(fncs);
            }
            
            // Si le status n'est pas valide, retourner une liste vide
            return new List<FncListItemDto>();
        }

        public async Task<IEnumerable<FncListItemDto>> SearchFncsAsync(string searchTerm)
        {
            var fncs = await _fncRepository.SearchFncsAsync(searchTerm);
            return _mapper.Map<IEnumerable<FncListItemDto>>(fncs);
        }

        public async Task<FncDto> UpdateFncAsync(int id, UpdateFncDto updateFncDto)
        {
            if (updateFncDto == null)
                throw new ArgumentNullException(nameof(updateFncDto));

            if (id <= 0)
                throw new ArgumentException("L'ID doit être un nombre positif", nameof(id));

            var existingFnc = await _fncRepository.GetByIdAsync(id);
            if (existingFnc == null)
                throw new KeyNotFoundException($"Aucune FNC trouvée avec l'ID {id}");

            // Les images ne sont pas mises à jour, on conserve les valeurs existantes
            var oldImage_Piece_bonne = existingFnc.ImageUrl_Piece_bonne;
            var oldImage_Piece_Mauvaise = existingFnc.ImageUrl_Piece_Mauvaise;
            var oldImage_3 = existingFnc.ImageUrl_3;
            var oldImage_4 = existingFnc.ImageUrl_4;
            var oldImage_5 = existingFnc.ImageUrl_5;











            // Mapper le DTO vers l'entité existante
            _mapper.Map(updateFncDto, existingFnc);

            // Restaurer les URLs des images après le mapping
            existingFnc.ImageUrl_Piece_bonne = oldImage_Piece_bonne;
            existingFnc.ImageUrl_Piece_Mauvaise = oldImage_Piece_Mauvaise;
            existingFnc.ImageUrl_3 = oldImage_3;
            existingFnc.ImageUrl_4 = oldImage_4;
            existingFnc.ImageUrl_5 = oldImage_5;

            // Enregistrer les modifications
            await _fncRepository.AddAsync(existingFnc); // Utiliser AddAsync qui doit gérer à la fois ajout et mise à jour

            // Retourner le DTO mis à jour
            return _mapper.Map<FncDto>(existingFnc);
        }
        
        // Méthode qui respecte l'interface
        public async Task<bool> UpdateFncAsync(UpdateFncDto updateFncDto)
        {
            if (updateFncDto == null)
                throw new ArgumentNullException(nameof(updateFncDto));

            if (updateFncDto.Id <= 0)
                throw new ArgumentException("L'ID doit être un nombre positif", nameof(updateFncDto.Id));
                
            try
            {
                var existingFnc = await _fncRepository.GetByIdAsync(updateFncDto.Id);
                if (existingFnc == null)
                    return false;

                // Mapper le DTO vers l'entité existante
                _mapper.Map(updateFncDto, existingFnc);

                // Enregistrer les modifications - utiliser une méthode d'enregistrement simple
                await _fncRepository.AddAsync(existingFnc); // Réutilisation d'AddAsync qui met à jour l'entité si elle existe déjà
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<int> CountFncsByStatusAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Le status ne peut pas être vide", nameof(status));

            // Vérifier si le status est valide en essayant de le convertir en enum
            if (Enum.TryParse<StatusFNC>(status, out var parsedStatus))
            {
                return await _fncRepository.CountFncsByStatusAsync(status);
            }
            
            // Si le status n'est pas valide, retourner 0
            return 0;
        }

        // La pagination a été supprimée

        public async Task<bool> IsUserRecipientAsync(int fncId, string userId)
        {
            if (string.IsNullOrEmpty(userId) || fncId <= 0) return false;
            return await _notificationService.IsUserRecipientAsync(fncId, userId);
        }

        private bool IsControleur(Domain.Entities.Fnc fnc)
        {
            // Un contrôleur existe uniquement dans la ZAP CMS, il suffit donc de vérifier la fonction.
            return fnc?.Transmitter?.Fonction == Fonction.Controleur;
        }

        private async Task HandleNotificationsAsync(Domain.Entities.Fnc fnc, string? conducteurId)
        {
            if (IsControleur(fnc))
            {
                var targetConducteurId = !string.IsNullOrWhiteSpace(conducteurId)
                    ? conducteurId
                    : await GetConducteurCmsIdAsync();

                if (!string.IsNullOrWhiteSpace(targetConducteurId))
                {
                    await _notificationService.SendApprobationConducteurAsync(fnc, targetConducteurId);
                }
            }
            else
            {
                await _notificationService.SendFncCreatedAsync(fnc);
            }
        }

        // Méthode temporaire pour récupérer l'ID d'un conducteur (à améliorer selon vos règles métier)
        private async Task<string?> GetConducteurCmsIdAsync()
        {
            // Cette implémentation est simplifiée : on cherche simplement le premier utilisateur ayant la fonction Conducteur.
            // Idéalement, vous ajouteriez un service dédié ou un paramètre venant du contrôleur.
            var conducteur = await _users.Users
                                         .Where(u => u.Fonction == Fonction.Conducteur)
                                         .FirstOrDefaultAsync();
            return conducteur?.Id;
        }

        public async Task<bool> AcceptFncAsync(int fncId, string userId)
        {
            // Vérifier l'autorisation via notification
            var isRecipient = await IsUserRecipientAsync(fncId, userId);
            if (!isRecipient) return false;

            var fnc = await _fncRepository.GetByIdAsync(fncId);
            if (fnc == null) return false;

            // Mettre à jour l'état et l'approbation conducteur
            fnc.Etat = Etat.accepter;
            fnc.Approbation_conducteur = true;

            var updated = await _fncRepository.UpdateFncAsync(fnc);

            // Si la mise à jour a réussi, recharger les données nécessaires et notifier les approbateurs suivants
            if (updated)
            {
                var fncWithDetails = await _fncRepository.GetFncByIdWithDetailsAsync(fnc.Id);
                await _notificationService.SendFncCreatedAsync(fncWithDetails);
            }

            return updated;
        }

        public async Task<bool> RejectFncAsync(int fncId, string userId)
        {
            // Vérifier l'autorisation via notification
            var isRecipient = await IsUserRecipientAsync(fncId, userId);
            if (!isRecipient) return false;

            var fnc = await _fncRepository.GetByIdAsync(fncId);
            if (fnc == null) return false;

            // Mettre à jour le statut et le processeur
            fnc.Etat = Etat.rejeter;
            fnc.Status = StatusFNC.annulé;
            fnc.ProcessorID = userId;
            return await _fncRepository.UpdateFncAsync(fnc);
        }

        public async Task<FncStatisticsDto> GetFncStatisticsAsync()
        {
            var fncs = await _fncRepository.GetAllFncsWithDetailsAsync();
            var fncsList = fncs.ToList();

            var now = DateTime.Now;
            var currentMonth = new DateTime(now.Year, now.Month, 1);
            var lastMonth = currentMonth.AddMonths(-1);

            var stats = new FncStatisticsDto
            {
                TotalFncs = fncsList.Count,
                FncsThisMonth = fncsList.Count(f => f.Date >= currentMonth),
                FncsLastMonth = fncsList.Count(f => f.Date >= lastMonth && f.Date < currentMonth)
            };

            // Calculer le changement en pourcentage
            if (stats.FncsLastMonth > 0)
            {
                stats.MonthlyChangePercentage = ((double)stats.FncsThisMonth - stats.FncsLastMonth) / stats.FncsLastMonth * 100;
            }

            // Statistiques par statut
            var statusGroups = fncsList.GroupBy(f => f.Status)
                .Select(g => new { Status = g.Key.ToString(), Count = g.Count() });

            foreach (var group in statusGroups)
            {
                stats.CountByStatus[group.Status] = group.Count;
            }

            // Statistiques par type
            var typeGroups = fncsList.GroupBy(f => f.TypeFnc)
                .Select(g => new { Type = g.Key.ToString(), Count = g.Count() });

            foreach (var group in typeGroups)
            {
                stats.CountByTypeFnc[group.Type] = group.Count;
            }

            // Statistiques par impact
            var impactGroups = fncsList.GroupBy(f => f.NcImpact)
                .Select(g => new { Impact = g.Key.ToString(), Count = g.Count() });

            foreach (var group in impactGroups)
            {
                stats.CountByNcImpact[group.Impact] = group.Count;
            }

            // Statistiques par mois (sur les 12 derniers mois)
            for (int i = 11; i >= 0; i--)
            {
                var monthDate = now.AddMonths(-i);
                var monthName = monthDate.ToString("MMM yyyy");
                var count = fncsList.Count(f => f.Date.Year == monthDate.Year && f.Date.Month == monthDate.Month);
                stats.CountByMonth[monthName] = count;
            }

            // Statistiques par client
            var clientGroups = fncsList.GroupBy(f => f.Client_name)
                .Select(g => new { Client = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .Take(10);

            foreach (var group in clientGroups)
            {
                stats.CountByClientName[group.Client] = group.Count;
            }

            // Statistiques par ZAP
            var zapGroups = fncsList.Where(f => f.ZapEmettrice != null)
                .GroupBy(f => f.ZapEmettrice.Name)
                .Select(g => new { Zap = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .Take(10);

            foreach (var group in zapGroups)
            {
                // Convertir l'enum zapName en string pour l'utiliser comme clé
                string zapNameAsString = group.Zap.ToString();
                stats.CountByZap[zapNameAsString] = group.Count;
            }

            // Statistiques par ZAP réceptrice (fusionne avec les émettrices)
            var zapRecepGroups = fncsList.Where(f => f.ZapReceptrice != null)
                .GroupBy(f => f.ZapReceptrice.Name)
                .Select(g => new { Zap = g.Key, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .Take(10);

            foreach (var group in zapRecepGroups)
            {
                string zapNameAsString = group.Zap.ToString();
                if (stats.CountByZap.ContainsKey(zapNameAsString))
                {
                    stats.CountByZap[zapNameAsString] += group.Count; // additionne si déjà présent
                }
                else
                {
                    stats.CountByZap[zapNameAsString] = group.Count;
                }
            }

            // Top transmetteurs
            var transmitterGroups = fncsList.Where(f => f.Transmitter != null)
                .GroupBy(f => new { Id = f.TransmitterID, Name = f.Transmitter.UserName })
                .Select(g => new UserStatItem { UserId = g.Key.Id, UserName = g.Key.Name, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .Take(5)
                .ToList();

            stats.TopTransmitters = transmitterGroups;

            // Top processeurs
            var processorGroups = fncsList.Where(f => f.Processor != null)
                .GroupBy(f => new { Id = f.ProcessorID, Name = f.Processor.UserName })
                .Select(g => new UserStatItem { UserId = g.Key.Id, UserName = g.Key.Name, Count = g.Count() })
                .OrderByDescending(g => g.Count)
                .Take(5)
                .ToList();

            stats.TopProcessors = processorGroups;

            return stats;
        }

        // Implémentation de la méthode de filtrage combiné
        public async Task<IEnumerable<FncListItemDto>> FilterFncsAsync(FncFilterDto filterDto)
        {
            if (filterDto == null)
                throw new ArgumentNullException(nameof(filterDto));

            try
            {
                // Récupérer toutes les FNCs pour appliquer les filtres
                var fncs = await _fncRepository.GetAllFncsWithDetailsAsync();
                var filteredFncs = fncs.AsQueryable();
                
                // Vérifier si nous avons bien des données à filtrer
                if (!filteredFncs.Any())
                {
                    // Retourner une liste vide si aucune FNC n'a été trouvée
                    return new List<FncListItemDto>();
                }

                // Appliquer le filtre de statut si spécifié
                if (!string.IsNullOrWhiteSpace(filterDto.Status))
                {
                    // Essayer de parser le status comme enum
                    if (Enum.TryParse<StatusFNC>(filterDto.Status, ignoreCase: true, out var parsedStatus))
                    {
                        filteredFncs = filteredFncs.Where(f => f.Status == parsedStatus);
                    }
                    // Si le parsing échoue, ne pas appliquer de filtre sur le status
                }

                // Appliquer d'autres filtres au besoin
                if (filterDto.TypeFnc.HasValue)
                {
                    filteredFncs = filteredFncs.Where(f => f.TypeFnc == filterDto.TypeFnc.Value);
                }

                if (filterDto.TypeDefaut.HasValue)
                {
                    filteredFncs = filteredFncs.Where(f => f.TypeDefaut == filterDto.TypeDefaut.Value);
                }

                if (filterDto.NcImpact.HasValue)
                {
                    filteredFncs = filteredFncs.Where(f => f.NcImpact == filterDto.NcImpact.Value);
                }

                if (filterDto.ActionImm.HasValue)
                {
                    filteredFncs = filteredFncs.Where(f => f.actionImmediate == filterDto.ActionImm.Value);
                }

                // Filtre texte simple
                if (!string.IsNullOrWhiteSpace(filterDto.SearchText))
                {
                    string searchTerm = filterDto.SearchText.ToLowerInvariant();
                    filteredFncs = filteredFncs.Where(f => 
                        (f.Description != null && f.Description.ToLowerInvariant().Contains(searchTerm)) ||
                        (f.Ref != null && f.Ref.ToLowerInvariant().Contains(searchTerm)) 
                    );
                }

                // Appliquer d'autres filtres de date si nécessaire
                if (filterDto.StartDate.HasValue)
                {
                    filteredFncs = filteredFncs.Where(f => f.Date >= filterDto.StartDate.Value);
                }

                if (filterDto.EndDate.HasValue)
                {
                    filteredFncs = filteredFncs.Where(f => f.Date <= filterDto.EndDate.Value);
                }

                // Retourner les résultats filtrés
                return _mapper.Map<IEnumerable<FncListItemDto>>(filteredFncs.ToList());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors du filtrage des FNCs: {ex.Message}");
                return new List<FncListItemDto>();
            }
        }
    }
}
