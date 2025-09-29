using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Dtos
{
    // DTO de création pour RechercheCausesRacinesD4
    public class CreateRechercheCausesRacinesD4Dto
    {
        [Required, StringLength(300, MinimumLength = 3)]
        public string Action { get; set; }

        [Required, StringLength(50)]
        public string OD { get; set; }

        [Required, StringLength(100)]
        public string PiloteID { get; set; }

        [Required]
        public DateOnly DatePrevue { get; set; }

        public DateOnly? DateReelle { get; set; }

        [StringLength(500)]
        public string Evolution { get; set; }

        [Required]
        public int QrqcId { get; set; }
    }
}
