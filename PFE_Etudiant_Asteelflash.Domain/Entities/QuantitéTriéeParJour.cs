using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class QuantitéTriéeParJour
    {
        [Key]
        public int Id { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être un nombre positif")]
        [Display(Name = "Jour 1")]
        public int? Jour1 { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être un nombre positif")]
        [Display(Name = "Jour 2")]
        public int? Jour2 { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être un nombre positif")]
        [Display(Name = "Jour 3")]
        public int? Jour3 { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être un nombre positif")]
        [Display(Name = "Jour 4")]
        public int? Jour4 { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être un nombre positif")]
        [Display(Name = "Jour 5")]
        public int? Jour5 { get; set; }

        // Relation avec Trie_ActionImmediateGlobale
        [Required(ErrorMessage = "Le tri d'action immédiate globale est obligatoire")]
        [Display(Name = "TriActionImmédiateGlobale")]
        public int TriActionImmédiateGlobaleId { get; set; }

        [ForeignKey("TriActionImmédiateGlobaleId")]
        public TriActionImmediateGlobale? trieActionImmediateGlobale { get; set; }
    }
}
