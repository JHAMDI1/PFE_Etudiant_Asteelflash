using PFE_Etudiant_Asteelflash.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class Qrqc
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La FNC associée est obligatoire")]
        [Display(Name = "FNC")]
        public int FNCId { get; set; }
        
        [ForeignKey("FNCId")]
        public Fnc? FNC { get; set; }

        // Date d'ouverture QRQC (migration: Date_Ouerture)
        [Column("Date_Ouerture")]
        public DateTime DateOuverture { get; set; }

        [Display(Name = "Responsable traitement")]

        public string ProcessorID { get; set; }
        [ForeignKey("ProcessorID")]
        public ApplicationUser? Processor { get; set; }


        [StringLength(100, MinimumLength = 2, ErrorMessage = "Le nom du client doit contenir entre 2 et 100 caractères")]
        [Display(Name = "Nom du client")]
        public string? client_name { get; set; }



        [Required(ErrorMessage = "La nature du défaut est obligatoire")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La nature du défaut doit contenir entre 5 et 200 caractères")]
        [Display(Name = "Nature du défaut")]
        public NatureDefaut nature_defaut { get; set; }

        [Display(Name = "Alerte qualité")]
        public bool Alerte_qualité { get; set; }


        [Display(Name = "Descriptions du problème")]

        public DescriptionDuProblemeD2 DescriptionDuProbleme { get; set; }


        [Display(Name = "ActionDeSecurisation")]

        public ActionDeSecurisationD3 actionDeSecurisation { get; set; }

        
       
        [Display(Name = "Suivi")]
        public SuiviD6 Suivi { get; set; }

        [Display(Name = "Act")]
        public ActD7 Act { get; set; }

        [Display(Name = "Cloture")]
        public ClotureD8 cloture { get; set; }
         
        [Display(Name = "planActionsCorrectives")]
        public PlanActionsCorrectivesD5 planActionsCorrectives{ get; set; }

        [Display(Name = "Équipes")]
        public ICollection<Equipe> Equipe { get; set; } = new List<Equipe>();

        [Display(Name = "Statut")]
        public PFE_Etudiant_Asteelflash.Domain.Enums.QrqcStatus Status { get; set; } = PFE_Etudiant_Asteelflash.Domain.Enums.QrqcStatus.EnCours;

        // Jeton de validation de clôture et expiration (7 jours)
        public Guid? ClotureToken { get; set; }
        public DateTime? ClotureTokenExpiry { get; set; }

        // Historique décision clôture
        public string? ClotureDecisionById { get; set; }
        [ForeignKey("ClotureDecisionById")] public ApplicationUser? ClotureDecisionBy { get; set; }
        public DateTime? ClotureDecisionAt { get; set; }
        public string? ClotureDecisionComment { get; set; }

        public CauseOccurenceD4 CauseOccurenceD4 { get; set; }
        public CausesNonDetectionD4 CausesNonDetectionD4 { get; set; }

        // Navigation property for D4 root cause research
        [System.ComponentModel.DataAnnotations.Schema.InverseProperty("Qrqc")]
        public Recherche_causes_racinesD4? Recherche_causes_racinesD4 { get; set; }
    }
}
