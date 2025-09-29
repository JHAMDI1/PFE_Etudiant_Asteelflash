using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day2.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using System.Linq;
using System.Collections.Generic;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Qrqc.Mapping
{
    public class QrqcMappingProfile : Profile
    {
        public QrqcMappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.Qrqc, QrqcDto>()
                .ForMember(dest => dest.ProcessorFullName,
                           opt => opt.MapFrom(src => src.Processor != null ? src.Processor.FirstName + " " + src.Processor.LastName : string.Empty))
                .ForMember(dest => dest.Statut,
                           opt => opt.MapFrom(src => src.Status == QrqcStatus.Cloturee ? "Clôturé" :
                                                 src.Status == QrqcStatus.ClotureDemandee ? "Clôture demandée" :
                                                 src.Status == QrqcStatus.Rejetee ? "Rejeté" : "En cours"));
            CreateMap<CreateQrqcDto, PFE_Etudiant_Asteelflash.Domain.Entities.Qrqc>();

            CreateMap<CreateGlobalQrqcDto, DescriptionDuProblemeD2Dto>();
            CreateMap<DescriptionDuProblemeD2Dto, CreateGlobalQrqcDto>();

            // Nouveau mapping
            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Domain.Entities.Qrqc>();
            CreateMap<CreateGlobalQrqcDto, CreateDescriptionDuProblemeD2Dto>();
            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Dtos.CreateActionDeSecurisationD3Dto>();
            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Dtos.CreateActionImmediateGlobaleDto>();
            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Dtos.CreateAssurerD3Dto>();
            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Dtos.CreateContenirD3Dto>()
                .ForMember(dest => dest.PiloteID, opt => opt.MapFrom(src => src.PiloteIDContenir))
                .ForMember(dest => dest.ContenirStopper, opt => opt.MapFrom(src => src.ContenirStopper))
                .ForMember(dest => dest.ContenirDeroulement, opt => opt.MapFrom(src => src.ContenirDeroulement))
                .ForMember(dest => dest.ContenirAjout, opt => opt.MapFrom(src => src.ContenirAjout))
                .ForMember(dest => dest.ActionDeSecurisationD3ID, opt => opt.MapFrom(src => src.ActionDeSecurisationD3IDContenir));

            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos.CreateListeDesActionsD3Dto>()
                .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.ActionListe))
                .ForMember(dest => dest.StatusAction, opt => opt.MapFrom(src => src.StatusAction))
                .ForMember(dest => dest.DatePrevue, opt => opt.MapFrom(src => src.DatePrevue))
                .ForMember(dest => dest.DateReelle, opt => opt.MapFrom(src => src.DateReelle))
                .ForMember(dest => dest.Commentaire, opt => opt.MapFrom(src => src.Commentaire))
                .ForMember(dest => dest.PiloteID, opt => opt.MapFrom(src => src.PiloteIDListeDesActionsD3))
                .ForMember(dest => dest.ActionDeSecurisationD3Id, opt => opt.MapFrom(src => src.ActionDeSecurisationD3Id));

            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Dtos.CreateQuantitéTriéeParJourDto>()
                .ForMember(dest => dest.Jour1, opt => opt.MapFrom(src => src.Jour1))
                .ForMember(dest => dest.Jour2, opt => opt.MapFrom(src => src.Jour2))
                .ForMember(dest => dest.Jour3, opt => opt.MapFrom(src => src.Jour3))
                .ForMember(dest => dest.Jour4, opt => opt.MapFrom(src => src.Jour4))
                .ForMember(dest => dest.Jour5, opt => opt.MapFrom(src => src.Jour5))
                .ForMember(dest => dest.TriActionImmediateGlobaleId, opt => opt.MapFrom(src => src.TriActionImmediateGlobaleId));

            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Dtos.CreateReparerD3Dto>()
                .ForMember(dest => dest.PiloteID, opt => opt.MapFrom(src => src.PiloteID))
                .ForMember(dest => dest.ReparerEdition, opt => opt.MapFrom(src => src.ReparerEdition))
                .ForMember(dest => dest.ReparerDefinitionDesFlux, opt => opt.MapFrom(src => src.ReparerDefinitionDesFlux))
                .ForMember(dest => dest.ReparerDefinitionDuPoint, opt => opt.MapFrom(src => src.ReparerDefinitionDuPoint))
                .ForMember(dest => dest.ReparerFormation, opt => opt.MapFrom(src => src.ReparerFormation))
                .ForMember(dest => dest.ReparerDeclenchement, opt => opt.MapFrom(src => src.ReparerDeclenchement))
                .ForMember(dest => dest.ActionDeSecurisationD3ID, opt => opt.MapFrom(src => src.ActionDeSecurisationD3ID));

            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Dtos.CreateTriActionImmediateGlobaleDto>()
                .ForMember(dest => dest.Zone, opt => opt.MapFrom(src => src.Zone))
                .ForMember(dest => dest.NombrePieceTrie, opt => opt.MapFrom(src => src.NombrePieceTrie))
                .ForMember(dest => dest.NombrePieceTotale, opt => opt.MapFrom(src => src.NombrePieceTotale))
                .ForMember(dest => dest.ActionImmediateGlobaleId, opt => opt.MapFrom(src => src.ActionImmediateGlobaleId));

            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Dtos.CreateTrierD3Dto>()
                .ForMember(dest => dest.PiloteID, opt => opt.MapFrom(src => src.PiloteIDTrier))
                .ForMember(dest => dest.TrierEdition, opt => opt.MapFrom(src => src.TrierEdition))
                .ForMember(dest => dest.TrierFormation, opt => opt.MapFrom(src => src.TrierFormation))
                .ForMember(dest => dest.TrierDefinition, opt => opt.MapFrom(src => src.TrierDefinition))
                .ForMember(dest => dest.TrierDeclenchement, opt => opt.MapFrom(src => src.TrierDeclenchement))
                .ForMember(dest => dest.TrierEnCours, opt => opt.MapFrom(src => src.TrierEnCours))
                .ForMember(dest => dest.TrierExpedition, opt => opt.MapFrom(src => src.TrierExpedition))
                .ForMember(dest => dest.ActionDeSecurisationD3ID, opt => opt.MapFrom(src => src.ActionDeSecurisationD3IDTrier));

            CreateMap<CreateGlobalQrqcDto, CreateCauseOccurenceD4Dto>()
                .ForMember(dest => dest.Pourquoi, opt => opt.MapFrom(src => src.PourquoiOccurence))
                .ForMember(dest => dest.QrqcId, opt => opt.MapFrom(src => src.QrqcId));

            CreateMap<CreateGlobalQrqcDto, CreateCausesNonDetectionD4Dto>()
                .ForMember(dest => dest.Cause, opt => opt.MapFrom(src => src.CauseNonDetection))
                .ForMember(dest => dest.Pourquoi, opt => opt.MapFrom(src => src.PourquoiNonDetection));

            CreateMap<CreateGlobalQrqcDto, Recherche_causes_racinesD4Dto>()
                .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.ActionRechercheCausesRacines))
                .ForMember(dest => dest.OD, opt => opt.MapFrom(src => src.OD))
                .ForMember(dest => dest.PiloteID, opt => opt.MapFrom(src => src.PiloteIDRechercheCausesRacines))
                .ForMember(dest => dest.DatePrevue, opt => opt.MapFrom(src => src.DatePrevueRechercheCauses))
                .ForMember(dest => dest.DateReelle, opt => opt.MapFrom(src => src.DateReelleRechercheCauses))
                .ForMember(dest => dest.Evolution, opt => opt.MapFrom(src => src.EvolutionRechercheCausesRacines));

            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day5.Dtos.CreatePlanActionsCorrectivesD5Dto>()
                .ForMember(dest => dest.ActionEliminationProbleme, opt => opt.MapFrom(src => src.ActionEliminationProbleme))
                .ForMember(dest => dest.PiloteID, opt => opt.MapFrom(src => src.PiloteID))
                .ForMember(dest => dest.DatePlanifiee, opt => opt.MapFrom(src => src.DatePlanifiee))
                .ForMember(dest => dest.QrqcId, opt => opt.MapFrom(src => src.QrqcId));

            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day6.Dtos.CreateSuiviD6Dto>()
                .ForMember(dest => dest.Equipe1, opt => opt.MapFrom(src => src.Equipe1))
                .ForMember(dest => dest.DateRealisation1, opt => opt.MapFrom(src => src.DateRealisation1))
                .ForMember(dest => dest.Equipe2, opt => opt.MapFrom(src => src.Equipe2))
                .ForMember(dest => dest.DateRealisation2, opt => opt.MapFrom(src => src.DateRealisation2))
                .ForMember(dest => dest.Equipe3, opt => opt.MapFrom(src => src.Equipe3))
                .ForMember(dest => dest.DateRealisation3, opt => opt.MapFrom(src => src.DateRealisation3))
                .ForMember(dest => dest.Equipe4, opt => opt.MapFrom(src => src.Equipe4))
                .ForMember(dest => dest.DateRealisation4, opt => opt.MapFrom(src => src.DateRealisation4))
                .ForMember(dest => dest.Equipe5, opt => opt.MapFrom(src => src.Equipe5))
                .ForMember(dest => dest.DateRealisation5, opt => opt.MapFrom(src => src.DateRealisation5))
                .ForMember(dest => dest.QrqcId, opt => opt.Ignore());

            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos.CreateEquipeDto>();

            CreateMap<CreateGlobalQrqcDto, PFE_Etudiant_Asteelflash.Application.Day7.Dtos.CreateActD7Dto>()
                .ForMember(dest => dest.ConnaissanceExperience, opt => opt.MapFrom(src => src.ConnaissanceExperience))
                .ForMember(dest => dest.QrqcId, opt => opt.Ignore());

            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.Qrqc, GlobalQrqcDto>()
                .ForMember(dest => dest.ProcessorFullName, opt => opt.MapFrom(src => src.Processor.FirstName + " " + src.Processor.LastName))
                .ForMember(dest => dest.CreationDate, opt => opt.MapFrom(src => src.DateOuverture))
                .ForMember(dest => dest.Client_name, opt => opt.MapFrom(src => src.client_name))
                .ForMember(dest => dest.Part_number, opt => opt.Ignore())
                .ForMember(dest => dest.NatureDefaut, opt => opt.MapFrom(src => src.nature_defaut.ToString()))
                // Newly added flat mappings for missing fields
                .ForMember(dest => dest.AlerteQualite, opt => opt.MapFrom(src => src.Alerte_qualité))
                // D1 – Définition du problème
                .ForMember(dest => dest.Probleme, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.Probleme : null))
                .ForMember(dest => dest.LieuDeDetection, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.LieuDeDetection : null))
                .ForMember(dest => dest.Detecteur, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.Detecteur : null))
                .ForMember(dest => dest.DescriptionProbleme, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.Probleme : null))
                .ForMember(dest => dest.CauseProbleme, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.RaisonDuProbleme : null))
                // D2 – Description du problème
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.Date : default(DateTime)))
                .ForMember(dest => dest.Heure, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.Heure : default(TimeSpan)))
                .ForMember(dest => dest.ManiereDeDetection, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.ManiéreDeDetection : null))
                .ForMember(dest => dest.NbreDePiecesConcernes, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.NbreDePiecesConcernes : 0))
                .ForMember(dest => dest.RaisonDuProbleme, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null ? src.DescriptionDuProbleme.RaisonDuProbleme : null))
                .ForMember(dest => dest.ReccurenceDuProbleme, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null && src.DescriptionDuProbleme.ReccurenceDuProbleme))
                .ForMember(dest => dest.Risque, opt => opt.MapFrom(src => src.DescriptionDuProbleme != null && src.DescriptionDuProbleme.Risque))
                // D4 – Causes
                .ForMember(dest => dest.PourquoiOccurence, opt => opt.MapFrom(src => src.CauseOccurenceD4 != null ? src.CauseOccurenceD4.Pourquoi : null))
                .ForMember(dest => dest.CauseOccurence, opt => opt.MapFrom(src => src.CauseOccurenceD4 != null ? src.CauseOccurenceD4.Cause.ToString() : null))
                .ForMember(dest => dest.CauseNonDetection, opt => opt.MapFrom(src => src.CausesNonDetectionD4 != null ? src.CausesNonDetectionD4.Cause.ToString() : null))
                .ForMember(dest => dest.PourquoiNonDetection, opt => opt.MapFrom(src => src.CausesNonDetectionD4 != null ? src.CausesNonDetectionD4.Pourquoi : null))
                // D4 – Recherche causes racines
                .ForMember(dest => dest.ActionRechercheCausesRacines, opt => opt.MapFrom(src => src.Recherche_causes_racinesD4 != null ? src.Recherche_causes_racinesD4.Action : null))
                .ForMember(dest => dest.OD, opt => opt.MapFrom(src => src.Recherche_causes_racinesD4 != null ? src.Recherche_causes_racinesD4.OD : null))
                .ForMember(dest => dest.PiloteIDRechercheCausesRacines, opt => opt.MapFrom(src => src.Recherche_causes_racinesD4 != null ? src.Recherche_causes_racinesD4.PiloteID : null))
                .ForMember(dest => dest.DatePrevueRechercheCauses, opt => opt.MapFrom(src => src.Recherche_causes_racinesD4 != null ? src.Recherche_causes_racinesD4.DatePrevue.ToDateTime(new TimeOnly(0, 0)) : (DateTime?)null))
                .ForMember(dest => dest.DateReelleRechercheCauses, opt => opt.MapFrom(src => src.Recherche_causes_racinesD4 != null ? src.Recherche_causes_racinesD4.DateReelle.ToDateTime(new TimeOnly(0, 0)) : (DateTime?)null))
                .ForMember(dest => dest.EvolutionRechercheCausesRacines, opt => opt.MapFrom(src => src.Recherche_causes_racinesD4 != null ? src.Recherche_causes_racinesD4.Evolution : null))
                // D5 – Plan actions correctives
                .ForMember(dest => dest.ActionEliminationProbleme, opt => opt.MapFrom(src => src.planActionsCorrectives != null ? src.planActionsCorrectives.ActionEliminationProbleme : null))
                .ForMember(dest => dest.DatePlanifiee, opt => opt.MapFrom(src => src.planActionsCorrectives != null ? src.planActionsCorrectives.DatePlanifiee : (DateTime?)null))
                .ForMember(dest => dest.PiloteIDPlanActions, opt => opt.MapFrom(src => src.planActionsCorrectives != null ? src.planActionsCorrectives.PiloteID : null))
                // D3 – Champs complémentaires
                // D3 – Champs complémentaires
                .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.actionDeSecurisation != null ? (ActionD3?)src.actionDeSecurisation.action : null))
                .ForMember(dest => dest.TypeReclamation, opt => opt.MapFrom(src => src.actionDeSecurisation != null ? (TypeReclamation?)src.actionDeSecurisation.TypeReclamation : null))
                .ForMember(dest => dest.ContenirStopperGlobale, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null ? src.actionDeSecurisation.ActionImmediateGlobale.Contenir_Stopper : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.ContenirDeroulementGlobale, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null ? src.actionDeSecurisation.ActionImmediateGlobale.Contenir_Déroulement : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.ReparerDeclenchementGlobale, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null ? src.actionDeSecurisation.ActionImmediateGlobale.Réparer_Déclenchement : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.ConclusionTri, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null ? src.actionDeSecurisation.ActionImmediateGlobale.ConclusionTri : null))
                // Contenir D3 mappings
                .ForMember(dest => dest.PiloteIDContenir, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ContenirD3 != null ? src.actionDeSecurisation.ContenirD3.PiloteID : null))
                .ForMember(dest => dest.PiloteContenirFullName, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ContenirD3 != null && src.actionDeSecurisation.ContenirD3.Pilote != null ? src.actionDeSecurisation.ContenirD3.Pilote.FirstName + " " + src.actionDeSecurisation.ContenirD3.Pilote.LastName : null))
                .ForMember(dest => dest.ContenirStopper, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ContenirD3 != null ? src.actionDeSecurisation.ContenirD3.Contenir_Stopper : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.ContenirDeroulement, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ContenirD3 != null ? src.actionDeSecurisation.ContenirD3.Contenir_Déroulement : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.ContenirAjout, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ContenirD3 != null ? src.actionDeSecurisation.ContenirD3.Contenir_Ajout : (Enum_Action_Immediate?)null))
                // Trier D3 mappings
                .ForMember(dest => dest.PiloteIDTrier, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.TrierD3 != null ? src.actionDeSecurisation.TrierD3.PiloteID : null))
                .ForMember(dest => dest.PiloteTrierFullName, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.TrierD3 != null && src.actionDeSecurisation.TrierD3.Pilote != null ? src.actionDeSecurisation.TrierD3.Pilote.FirstName + " " + src.actionDeSecurisation.TrierD3.Pilote.LastName : null))
                .ForMember(dest => dest.TrierEdition, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.TrierD3 != null ? src.actionDeSecurisation.TrierD3.Trier_Edition : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.TrierFormation, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.TrierD3 != null ? src.actionDeSecurisation.TrierD3.Trier_Formation : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.TrierDefinition, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.TrierD3 != null ? src.actionDeSecurisation.TrierD3.Trier_Définition : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.TrierDeclenchement, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.TrierD3 != null ? src.actionDeSecurisation.TrierD3.Trier_Déclenchement : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.TrierEnCours, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.TrierD3 != null ? src.actionDeSecurisation.TrierD3.Trier_En_Cours : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.TrierExpedition, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.TrierD3 != null ? src.actionDeSecurisation.TrierD3.Trier_Expédition : (Enum_Action_Immediate?)null))
                // Reparer D3 mappings
                .ForMember(dest => dest.PiloteID, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ReparerD3 != null ? src.actionDeSecurisation.ReparerD3.PiloteID : null))
                .ForMember(dest => dest.PiloteReparerFullName, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ReparerD3 != null && src.actionDeSecurisation.ReparerD3.Pilote != null ? src.actionDeSecurisation.ReparerD3.Pilote.FirstName + " " + src.actionDeSecurisation.ReparerD3.Pilote.LastName : null))
                .ForMember(dest => dest.ReparerEdition, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ReparerD3 != null ? src.actionDeSecurisation.ReparerD3.Réparer_Edition : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.ReparerDefinitionDesFlux, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ReparerD3 != null ? src.actionDeSecurisation.ReparerD3.Réparer_Définition_Des_Flux : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.ReparerDefinitionDuPoint, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ReparerD3 != null ? src.actionDeSecurisation.ReparerD3.Réparer_Définition_Du_Point : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.ReparerFormation, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ReparerD3 != null ? src.actionDeSecurisation.ReparerD3.Réparer_Formation : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.ReparerDeclenchement, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ReparerD3 != null ? src.actionDeSecurisation.ReparerD3.Réparer_Déclenchement : (Enum_Action_Immediate?)null))
                // Assurer D3 mappings
                .ForMember(dest => dest.PiloteIDAssurer, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.AssurerD3 != null ? src.actionDeSecurisation.AssurerD3.PiloteID : null))
                .ForMember(dest => dest.PiloteAssurerFullName, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.AssurerD3 != null && src.actionDeSecurisation.AssurerD3.Pilote != null ? src.actionDeSecurisation.AssurerD3.Pilote.FirstName + " " + src.actionDeSecurisation.AssurerD3.Pilote.LastName : null))
                .ForMember(dest => dest.AssurerReunion, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.AssurerD3 != null ? src.actionDeSecurisation.AssurerD3.Assurer_Réunion : (Enum_Action_Immediate?)null))
                .ForMember(dest => dest.AssurerAudit, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.AssurerD3 != null ? src.actionDeSecurisation.AssurerD3.Assurer_Audit : (Enum_Action_Immediate?)null))
                // D3 – Quantité triée par jour (Jour1 à Jour5)
                .ForMember(dest => dest.Jour1, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.Any() && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour != null
                    ? src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour.Jour1
                    : (int?)null))
                .ForMember(dest => dest.Jour2, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.Any() && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour != null
                    ? src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour.Jour2
                    : (int?)null))
                .ForMember(dest => dest.Jour3, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.Any() && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour != null
                    ? src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour.Jour3
                    : (int?)null))
                .ForMember(dest => dest.Jour4, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.Any() && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour != null
                    ? src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour.Jour4
                    : (int?)null))
                .ForMember(dest => dest.Jour5, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales != null && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.Any() && src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour != null
                    ? src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales.First().QuantitéTriéeParJour.Jour5
                    : (int?)null))
                // D6 – Suivi (équipes supplémentaires)
                .ForMember(dest => dest.Equipe2, opt => opt.MapFrom(src => src.Suivi != null ? src.Suivi.Equipe2 : null))
                .ForMember(dest => dest.DateRealisation2, opt => opt.MapFrom(src => src.Suivi != null ? (DateTime?)src.Suivi.DateRealisation2 : null))
                .ForMember(dest => dest.Equipe3, opt => opt.MapFrom(src => src.Suivi != null ? src.Suivi.Equipe3 : null))
                .ForMember(dest => dest.DateRealisation3, opt => opt.MapFrom(src => src.Suivi != null ? (DateTime?)src.Suivi.DateRealisation3 : null))
                .ForMember(dest => dest.Equipe4, opt => opt.MapFrom(src => src.Suivi != null ? src.Suivi.Equipe4 : null))
                .ForMember(dest => dest.DateRealisation4, opt => opt.MapFrom(src => src.Suivi != null ? (DateTime?)src.Suivi.DateRealisation4 : null))
                .ForMember(dest => dest.Equipe5, opt => opt.MapFrom(src => src.Suivi != null ? src.Suivi.Equipe5 : null))
                .ForMember(dest => dest.DateRealisation5, opt => opt.MapFrom(src => src.Suivi != null ? (DateTime?)src.Suivi.DateRealisation5 : null))
                .ForMember(dest => dest.DateRealisation1, opt => opt.MapFrom(src => src.Suivi != null ? (DateTime?)src.Suivi.DateRealisation1 : null))
                .ForMember(dest => dest.ConnaissanceExperience, opt => opt.MapFrom(src => src.Act != null ? src.Act.ConnaissanceExperience.ToString() : null))
                .ForMember(dest => dest.Equipes, opt => opt.MapFrom(src => src.Equipe.Select(e => new EquipeMemberDto
                {
                    MemberName = e.applicationUser != null ? e.applicationUser.FirstName + " " + e.applicationUser.LastName : null,
                    Fonction = e.Fonction.ToString(),
                    IsAbsent = e.IsAbsent
                }).ToList()))
                // Tri actions immédiates globales
                .ForMember(dest => dest.TriActions, opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ActionImmediateGlobale != null ? src.actionDeSecurisation.ActionImmediateGlobale.TriActionImmediateGlobales : null))
                // Liste des actions D3 (convertir objet unique en liste)
                .ForMember(dest => dest.ListeDesActions,
                          opt => opt.MapFrom(src => src.actionDeSecurisation != null && src.actionDeSecurisation.ListeDesActionsD3 != null
                              ? new[] { src.actionDeSecurisation.ListeDesActionsD3 } // AutoMapper convertit chaque élément vers ListeDesActionsD3Dto
                              : null));
        }
    }
}
