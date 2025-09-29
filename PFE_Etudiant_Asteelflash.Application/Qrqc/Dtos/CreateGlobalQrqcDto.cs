using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Enums;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos;

namespace PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos
{
    public class CreateGlobalQrqcDto
    {
        // 1 Create Qrqc 
        [Required]
        public int FNCId { get; set; }
        [StringLength(100)]
        public string? Client_name { get; set; }
        [Required]
        public NatureDefaut NatureDefaut { get; set; }
        public bool AlerteQualite { get; set; } = false;
        public string ProcessorID { get; set; }

        // 2 CreateDescriptionDuProblemeD2Dto
        [Required, StringLength(500, MinimumLength = 10)]
        public string Probleme { get; set; }
        [Required, StringLength(100)]
        public string Detecteur { get; set; }
        [Required, StringLength(100)]
        public string LieuDeDetection { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Heure { get; set; }
        [Required, StringLength(200)]
        public string ManiereDeDetection { get; set; }

        [Range(0, int.MaxValue)]
        public int NbreDePiecesConcernes { get; set; }
        [Required, StringLength(300, MinimumLength = 5)]
        public string RaisonDuProbleme { get; set; }
        public bool ReccurenceDuProbleme { get; set; }
        public bool Risque { get; set; }
        public int QRQCId { get; set; } // défini automatiquement dans le service après création du QRQC

        // 3 CreateActionDeSecurisationD3Dto
        public ActionD3 Action { get; set; }
        public TypeReclamation TypeReclamation { get; set; }

        // 4 CreateActionImmediateGlobaleDto
        public Enum_Action_Immediate? ContenirStopperGlobale { get; set; }
        public Enum_Action_Immediate? ContenirDeroulementGlobale { get; set; }
        public Enum_Action_Immediate? ReparerDeclenchementGlobale { get; set; }

        [Required, StringLength(500, MinimumLength = 5)]
        public string ConclusionTri { get; set; }
        public int? ActionDeSecurisationId { get; set; }

        // 5 Create TriActionImmediateGlobaleDto
        [ScaffoldColumn(false)]
        public List<CreateTriActionImmediateGlobaleDto> TriActions { get; set; } = new();

        // Les anciennes propriétés unitaires conservées pour compatibilité, mais non utilisées si TriActions est rempli.
        [Obsolete("Utiliser TriActions à la place.")]
        public string Zone { get; set; }

        [Obsolete("Utiliser TriActions à la place.")]
        public int? NombrePieceTrie { get; set; }

        [Obsolete("Utiliser TriActions à la place.")]
        public int? NombrePieceTotale { get; set; }

        [Obsolete("Utiliser TriActions à la place.")]
        public int? ActionImmediateGlobaleId { get; set; }


        // 6 Create QuantitéTriéeParJourDto
        [Range(0, int.MaxValue)]
        public int? Jour1 { get; set; }
        [Range(0, int.MaxValue)]
        public int? Jour2 { get; set; }
        [Range(0, int.MaxValue)]
        public int? Jour3 { get; set; }
        [Range(0, int.MaxValue)]
        public int? Jour4 { get; set; }
        [Range(0, int.MaxValue)]
        public int? Jour5 { get; set; }
        [Required]
        public int TriActionImmediateGlobaleId { get; set; }

        // 7 Create ContenirD3Dto
        public string PiloteIDContenir { get; set; }
        public Enum_Action_Immediate? ContenirStopper { get; set; }
        public Enum_Action_Immediate? ContenirDeroulement { get; set; }
        public Enum_Action_Immediate? ContenirAjout { get; set; }
        [Required]
        public int ActionDeSecurisationD3IDContenir { get; set; }

        // 8 Create TrierD3Dto
        public string PiloteIDTrier { get; set; } 
        public Enum_Action_Immediate? TrierEdition { get; set; }
        public Enum_Action_Immediate? TrierFormation { get; set; }
        public Enum_Action_Immediate? TrierDefinition { get; set; }
        public Enum_Action_Immediate? TrierDeclenchement { get; set; }
        public Enum_Action_Immediate? TrierEnCours { get; set; }
        public Enum_Action_Immediate? TrierExpedition { get; set; }
        [Required]
        public int ActionDeSecurisationD3IDTrier { get; set; }

        // 9 Create ReparerD3Dto
        public string PiloteID { get; set; }
        public Enum_Action_Immediate? ReparerEdition { get; set; }
        public Enum_Action_Immediate? ReparerDefinitionDesFlux { get; set; }
        public Enum_Action_Immediate? ReparerDefinitionDuPoint { get; set; }
        public Enum_Action_Immediate? ReparerFormation { get; set; }
        public Enum_Action_Immediate? ReparerDeclenchement { get; set; }
        [Required]
        public int ActionDeSecurisationD3ID { get; set; }

        // 10 Create AssurerD3Dto
        public string PiloteIDAssurer { get; set; }
        public Enum_Action_Immediate? AssurerReunion { get; set; }
        public Enum_Action_Immediate? AssurerAudit { get; set; }

        // 11 bis : liste des causes d'occurrence D4 dynamiques
        public List<CreateCauseOccurenceD4Dto> CausesOccurence { get; set; } = new();

        // 11 ter : liste des causes de non détection D4 dynamiques
        public List<CreateCausesNonDetectionD4Dto> CausesNonDetection { get; set; } = new();

        // 12 bis : liste des membres d'équipe
        public List<PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos.CreateEquipeDto> Equipes { get; set; } = new();
        [Required]
        public int ActionDeSecurisationD3IDAssurer { get; set; }

        // 11 Create ListeDesActionsD3Dto
        [Required, StringLength(200, MinimumLength = 3)]
        public string ActionListe { get; set; }
        [Required]
        public StatusAction StatusAction { get; set; }
        [Required]
        public DateTime DatePrevue { get; set; }
        public DateTime DateReelle { get; set; }
        [StringLength(500)]
        public string Commentaire { get; set; }
        [Required]
        public string PiloteIDListeDesActionsD3 { get; set; }
        [Required]
        public int ActionDeSecurisationD3Id { get; set; }

        // 12 Create EquipeDto

        [Required]
        public int QrqcId { get; set; }

        [Required]
        public string UserId { get; set; }

        public Fonction Fonction { get; set; }

        public bool IsAbsent { get; set; }

        // 13 Create CauseOccurenceD4Dto
        [Required]
        public string PourquoiOccurence { get; set; }
        [Required]
        public EnumCause CauseOccurence { get; set; }

        // 14 Create causesNonDetectionD4Dto
        [Required]
        public EnumCause CauseNonDetection { get; set; }
        [Required]
        public string PourquoiNonDetection { get; set; }

        // 15 Create RechercheCausesRacinesD4Dto
        [Required, StringLength(300, MinimumLength = 3)]
        public string ActionRechercheCausesRacines { get; set; }

        [Required, StringLength(50)]
        public string OD { get; set; }

        [Required, StringLength(100)]
        public string PiloteIDRechercheCausesRacines { get; set; }

        [Required]
        public DateOnly DatePrevueRechercheCauses { get; set; }
        public DateOnly? DateReelleRechercheCauses { get; set; }
        [StringLength(500)]
        public string EvolutionRechercheCausesRacines { get; set; }

        // 16 Create PlanActionsCorrectivesD5Dto
        [Required]
        public string ActionEliminationProbleme { get; set; }
        [Required]
        public string PiloteIDPlanActions { get; set; }
        [Required]
        public DateTime DatePlanifiee { get; set; }

        // 17 Create SuiviD6Dto
        [Required]
        public string Equipe1 { get; set; }
        [Required]
        public DateTime DateRealisation1 { get; set; }
        public string Equipe2 { get; set; }
        public DateTime? DateRealisation2 { get; set; }
        public string Equipe3 { get; set; }
        public DateTime? DateRealisation3 { get; set; }
        public string Equipe4 { get; set; }
        public DateTime? DateRealisation4 { get; set; }
        public string Equipe5 { get; set; }
        public DateTime? DateRealisation5 { get; set; }

        // 18 Create ActD7Dto
        [Required]
        public ConnaissanceExperience ConnaissanceExperience { get; set; }

    }
}
