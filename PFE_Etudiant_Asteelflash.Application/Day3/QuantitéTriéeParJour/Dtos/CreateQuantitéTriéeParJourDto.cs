using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Dtos
{
    public class CreateQuantitéTriéeParJourDto
    {
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
    }
}
