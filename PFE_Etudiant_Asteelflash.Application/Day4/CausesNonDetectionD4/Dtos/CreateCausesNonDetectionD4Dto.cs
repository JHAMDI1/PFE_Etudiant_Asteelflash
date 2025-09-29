using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos
{
    public class CreateCausesNonDetectionD4Dto
    {
        [Required]
        public EnumCause Cause { get; set; }
        [Required]
        public string Pourquoi { get; set; }
        [Required]
        public int QrqcId { get; set; }
    }
}
