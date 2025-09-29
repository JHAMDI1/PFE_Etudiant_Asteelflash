using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{ 
    public class ListeDesActionsD3
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'action est obligatoire")]
        [StringLength(200, MinimumLength = 3, ErrorMessage = "L'action doit contenir entre 3 et 200 caractères")]
        public string Action { get; set; }

        [Required(ErrorMessage = "Le statut de l'action est obligatoire")]
        public StatusAction StatusAction { get; set; }

        [Required(ErrorMessage = "La date prévue est obligatoire")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Prévue")]
        public DateTime DatePrévue { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date Réelle")]
        public DateTime DateRéelle { get; set; }

        [StringLength(500, ErrorMessage = "Le commentaire ne peut pas dépasser 500 caractères")]
        [Display(Name = "Commentaire")]
        public string Commentaire { get; set; }

        [Required(ErrorMessage = "Le pilote est obligatoire")]
        public string PiloteID { get; set; }

        [ForeignKey("PiloteID")]
        public ApplicationUser? Pilote { get; set; }

        // Relation avec D3_ActionsSecurisation (many-to-one)
        [Required(ErrorMessage = "L'action de sécurisation est obligatoire")]
        public int ActionDeSecurisationD3Id { get; set; }

        [ForeignKey("ActionDeSecurisationD3Id")]
        public ActionDeSecurisationD3? ActionDeSecurisationD3 { get; set; }
    }
}
