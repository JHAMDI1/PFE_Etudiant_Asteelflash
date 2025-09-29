using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day7.Dtos
{
    public class CreateActD7Dto
    {
        [Required]
        public ConnaissanceExperience ConnaissanceExperience { get; set; }
        [Required]
        public int QrqcId { get; set; }
    }
}
