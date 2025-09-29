using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PFE_Etudiant_Asteelflash.Domain.Entities
{ 
    public partial class TriActionImmediateGlobale
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La zone est obligatoire")]
        [StringLength(100, ErrorMessage = "La zone ne peut pas dépasser 100 caractères")]
        [Display(Name = "Zone")]
        public string Zone { get; set; }

        [Required(ErrorMessage = "Le nombre de pièces triées est obligatoire")]
        [Range(0, int.MaxValue, ErrorMessage = "Le nombre doit être positif")]
        [Display(Name = "Nombre de pièces triées")]
        public int NombrePiéceTrié { get; set; }

        [Required(ErrorMessage = "Le nombre total de pièces est obligatoire")]
        [Range(0, int.MaxValue, ErrorMessage = "Le nombre total doit être positif")]
        [Display(Name = "Nombre total de pièces")]
        public int NombrePiéceTotale { get; set; }

        // Relation avec ActionImmediateGlobale
        [Required(ErrorMessage = "L'action immédiate globale est obligatoire")]
        [Display(Name = "ActionImmediateGlobale")]
        public int ActionImmediateGlobaleId { get; set; }

        [ForeignKey("ActionImmediateGlobaleId")]
        public ActionImmediateGlobale? ActionImmediateGlobale { get; set; }

        // Relation one-to-one avec QuantitéTriéeParJour
        [Display(Name = "Quantité triée par jour")]
        public QuantitéTriéeParJour? QuantitéTriéeParJour { get; set; }
    }
}

