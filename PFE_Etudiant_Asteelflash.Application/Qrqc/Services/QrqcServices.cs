using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day2.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day2.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day5.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day5.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day6.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day6.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day7.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day7.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Interfaces;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence;
using Microsoft.EntityFrameworkCore;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Interfaces;

namespace PFE_Etudiant_Asteelflash.Application.Qrqc.Services
{
    public class QrqcServices : IQrqcServices
    {
        private readonly IQrqcRepository _qrqcRepository;
        private readonly IDescriptionDuProblemeD2Services _descriptionDuProblemeD2Services;
        private readonly IActionDeSecurisationD3Services _actionDeSecurisationD3Services;
        private readonly IActionImmediateGlobaleServices _actionImmediateGlobaleServices;
        private readonly IAssurerD3Services _assurerD3Services;
        private readonly IContenirD3Services _contenirD3Services;
        private readonly IListeDesActionsD3Services _listeDesActionsD3Services;
        private readonly IQuantitéTriéeParJourServices _quantiteTrieeParJourServices;
        private readonly IReparerD3Services _reparerD3Services;
        private readonly ITriActionImmediateGlobaleServices _triActionImmediateGlobaleServices;
        private readonly ITrierD3Services _trierD3Services;
        private readonly IEquipeServices _equipeServices;
        private readonly ICauseOccurenceD4Services _causeOccurenceD4Services;
        private readonly ICausesNonDetectionD4Services _causesNonDetectionD4Services;
        private readonly IRecherche_causes_racinesD4Services _rechercheCausesRacinesD4Services;
        private readonly IPlanActionsCorrectivesD5Services _planActionsCorrectivesD5Services;
        private readonly ISuiviD6Services _suiviD6Services;
        private readonly IActD7Services _actD7Services;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _dbContext;

        public QrqcServices(IQrqcRepository qrqcRepository,
                            IMapper mapper,
                            IDescriptionDuProblemeD2Services descriptionDuProblemeD2Services,
                            IActionDeSecurisationD3Services actionDeSecurisationD3Services,
                            IActionImmediateGlobaleServices actionImmediateGlobaleServices,
                            IAssurerD3Services assurerD3Services,
                            IContenirD3Services contenirD3Services,
                            IListeDesActionsD3Services listeDesActionsD3Services,
                            IQuantitéTriéeParJourServices quantiteTrieeParJourServices,
                            IReparerD3Services reparerD3Services,
                            ITriActionImmediateGlobaleServices triActionImmediateGlobaleServices,
                            ITrierD3Services trierD3Services,
                             IEquipeServices equipeServices,
                            ICauseOccurenceD4Services causeOccurenceD4Services,
                            ICausesNonDetectionD4Services causesNonDetectionD4Services,
                            IRecherche_causes_racinesD4Services rechercheCausesRacinesD4Services,
                            IPlanActionsCorrectivesD5Services planActionsCorrectivesD5Services,
                            ISuiviD6Services suiviD6Services,
                            IActD7Services actD7Services,
                             ApplicationDbContext dbContext)
        {
            _qrqcRepository = qrqcRepository ?? throw new ArgumentNullException(nameof(qrqcRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _descriptionDuProblemeD2Services = descriptionDuProblemeD2Services ?? throw new ArgumentNullException(nameof(descriptionDuProblemeD2Services));
            _actionDeSecurisationD3Services = actionDeSecurisationD3Services ?? throw new ArgumentNullException(nameof(actionDeSecurisationD3Services));
            _actionImmediateGlobaleServices = actionImmediateGlobaleServices ?? throw new ArgumentNullException(nameof(actionImmediateGlobaleServices));
            _assurerD3Services = assurerD3Services ?? throw new ArgumentNullException(nameof(assurerD3Services));
            _contenirD3Services = contenirD3Services ?? throw new ArgumentNullException(nameof(contenirD3Services));
            _listeDesActionsD3Services = listeDesActionsD3Services ?? throw new ArgumentNullException(nameof(listeDesActionsD3Services));
            _quantiteTrieeParJourServices = quantiteTrieeParJourServices ?? throw new ArgumentNullException(nameof(quantiteTrieeParJourServices));
            _reparerD3Services = reparerD3Services ?? throw new ArgumentNullException(nameof(reparerD3Services));
            _triActionImmediateGlobaleServices = triActionImmediateGlobaleServices ?? throw new ArgumentNullException(nameof(triActionImmediateGlobaleServices));
            _trierD3Services = trierD3Services ?? throw new ArgumentNullException(nameof(trierD3Services));
            _equipeServices = equipeServices ?? throw new ArgumentNullException(nameof(equipeServices));
            _causeOccurenceD4Services = causeOccurenceD4Services ?? throw new ArgumentNullException(nameof(causeOccurenceD4Services));
            _causesNonDetectionD4Services = causesNonDetectionD4Services ?? throw new ArgumentNullException(nameof(causesNonDetectionD4Services));
            _rechercheCausesRacinesD4Services = rechercheCausesRacinesD4Services ?? throw new ArgumentNullException(nameof(rechercheCausesRacinesD4Services));
            _planActionsCorrectivesD5Services = planActionsCorrectivesD5Services ?? throw new ArgumentNullException(nameof(planActionsCorrectivesD5Services));
            _suiviD6Services = suiviD6Services ?? throw new ArgumentNullException(nameof(suiviD6Services));
            _actD7Services = actD7Services ?? throw new ArgumentNullException(nameof(actD7Services));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<QrqcDto> CreateQrqcAsync(CreateGlobalQrqcDto dto)
        {
            if (dto == null) throw new ArgumentNullException(nameof(dto));

            // Démarrage d'une transaction pour garantir l'atomicité de la création QRQC
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                // 1. Créer l'en-tête QRQC
                var qrqcEntity = _mapper.Map<PFE_Etudiant_Asteelflash.Domain.Entities.Qrqc>(dto);
                var createdQrqc = await _qrqcRepository.AddAsync(qrqcEntity);

                // 2. Créer la description du problème (D2)
                var d2Dto = _mapper.Map<CreateDescriptionDuProblemeD2Dto>(dto);
                d2Dto.QRQCId = createdQrqc.Id;
                await _descriptionDuProblemeD2Services.CreateAsync(d2Dto);

                // 3. Créer l'action de sécurisation D3
                var actionD3Dto = _mapper.Map<CreateActionDeSecurisationD3Dto>(dto);
                actionD3Dto.QRQCId = createdQrqc.Id;
                var createdActionD3 = await _actionDeSecurisationD3Services.CreateAsync(actionD3Dto);

                // 4. Créer l'action immédiate globale
                var immediateDto = _mapper.Map<CreateActionImmediateGlobaleDto>(dto);
                immediateDto.ActionDeSecurisationId = createdActionD3.Id;
                var createdImmediate = await _actionImmediateGlobaleServices.CreateAsync(immediateDto);

                // 5. Créer TriActionImmediateGlobale (boucle sur la collection si renseignée)
                List<int> triIds = new();
                if (dto.TriActions != null && dto.TriActions.Any())
                {
                    foreach (var triItem in dto.TriActions)
                    {
                        triItem.ActionImmediateGlobaleId = createdImmediate.Id;
                        var createdTri = await _triActionImmediateGlobaleServices.CreateAsync(triItem);
                        triIds.Add(createdTri.Id);
                    }
                }
                else
                {
                    var triDto = _mapper.Map<CreateTriActionImmediateGlobaleDto>(dto);
                    triDto.ActionImmediateGlobaleId = createdImmediate.Id;
                    var createdTri = await _triActionImmediateGlobaleServices.CreateAsync(triDto);
                    triIds.Add(createdTri.Id);
                }

                // 6. Créer Quantité triée par jour pour le premier tri (si applicable)
                if (triIds.Any())
                {
                    var quantiteDto = _mapper.Map<CreateQuantitéTriéeParJourDto>(dto);
                    quantiteDto.TriActionImmediateGlobaleId = triIds.First();
                    await _quantiteTrieeParJourServices.CreateAsync(quantiteDto);
                }

                // 7. Créer Contenir D3
                var contenirDto = _mapper.Map<CreateContenirD3Dto>(dto);
                contenirDto.ActionDeSecurisationD3ID = createdActionD3.Id;
                await _contenirD3Services.CreateAsync(contenirDto);

                // 8. Créer Trier D3
                var trierDto = _mapper.Map<CreateTrierD3Dto>(dto);
                trierDto.ActionDeSecurisationD3ID = createdActionD3.Id;
                await _trierD3Services.CreateAsync(trierDto);

                // 9. Créer Reparer D3
                var reparerDto = _mapper.Map<CreateReparerD3Dto>(dto);
                reparerDto.ActionDeSecurisationD3ID = createdActionD3.Id;
                await _reparerD3Services.CreateAsync(reparerDto);

                // 10. Créer Assurer D3
                var assurerDto = _mapper.Map<CreateAssurerD3Dto>(dto);
                assurerDto.ActionDeSecurisationD3ID = createdActionD3.Id;
                await _assurerD3Services.CreateAsync(assurerDto);

                // 11. Créer Liste des actions D3
                var listeDto = _mapper.Map<CreateListeDesActionsD3Dto>(dto);
                listeDto.ActionDeSecurisationD3Id = createdActionD3.Id;
                await _listeDesActionsD3Services.CreateAsync(listeDto);

                // 12. Créer Equipe
                var equipeDto = _mapper.Map<CreateEquipeDto>(dto);
                equipeDto.QrqcId = createdQrqc.Id;
                await _equipeServices.CreateEquipeAsync(equipeDto);

                // 13. Créer CauseOccurence D4
                var causeOccurDto = _mapper.Map<CreateCauseOccurenceD4Dto>(dto);
                causeOccurDto.QrqcId = createdQrqc.Id;
                await _causeOccurenceD4Services.CreateAsync(causeOccurDto);

                // 14. Créer CausesNonDetection D4
                var causesNonDetectionDto = _mapper.Map<CreateCausesNonDetectionD4Dto>(dto);
                causesNonDetectionDto.QrqcId = createdQrqc.Id;
                await _causesNonDetectionD4Services.CreateAsync(causesNonDetectionDto);

                // 15. Créer Recherche_causes_racines D4
                var causesRacinesDto = _mapper.Map<Recherche_causes_racinesD4Dto>(dto);
                causesRacinesDto.QrqcId = createdQrqc.Id;
                await _rechercheCausesRacinesD4Services.CreateAsync(causesRacinesDto);

                // 16. Créer PlanActionsCorrectives D5
                var planDto = _mapper.Map<CreatePlanActionsCorrectivesD5Dto>(dto);
                planDto.QrqcId = createdQrqc.Id;
                await _planActionsCorrectivesD5Services.CreateAsync(planDto);

                // 17. Créer Suivi D6
                var suiviDto = _mapper.Map<CreateSuiviD6Dto>(dto);
                suiviDto.QrqcId = createdQrqc.Id;
                await _suiviD6Services.CreateAsync(suiviDto);

                // 18. Créer Act D7
                var actDto = _mapper.Map<CreateActD7Dto>(dto);
                actDto.QrqcId = createdQrqc.Id;
                await _actD7Services.CreateAsync(actDto);

                // 19. Commit et retour du QRQC créé
                await transaction.CommitAsync();
                return _mapper.Map<QrqcDto>(createdQrqc);
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<bool> DeleteQrqcAsync(int id)
        {
            var entity = await _qrqcRepository.GetByIdAsync(id);
            if (entity == null) return false;
            await _qrqcRepository.DeleteAsync(entity);
            return true;
        }

        public async Task<IEnumerable<QrqcDto>> GetAllQrqcAsync()
        {
            var list = await _qrqcRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<QrqcDto>>(list);
        }

        public async Task<QrqcDto> GetQrqcByIdAsync(int id)
        {
            var entity = await _qrqcRepository.GetByIdAsync(id);
            return _mapper.Map<QrqcDto>(entity);
        }

        public async Task<GlobalQrqcDto> GetGlobalQrqcByIdAsync(int id)
        {
            var qrqc = await _qrqcRepository.GetByIdAsync(id);
            return _mapper.Map<GlobalQrqcDto>(qrqc);
        }

        public async Task<bool> UpdateQrqcAsync(int id, CreateQrqcDto dto)
        {
            var existing = await _qrqcRepository.GetByIdAsync(id);
            if (existing == null) return false;
            _mapper.Map(dto, existing);
            await _qrqcRepository.UpdateAsync(existing);
            return true;
        }
    }
}
