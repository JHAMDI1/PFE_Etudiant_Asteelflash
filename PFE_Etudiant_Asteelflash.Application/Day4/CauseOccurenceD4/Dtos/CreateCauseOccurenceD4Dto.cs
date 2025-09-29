using System;
using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Dtos
{
    public class CreateCauseOccurenceD4Dto
    {
        [Required]
        public string Pourquoi { get; set; }
        [Required]
        public EnumCause Cause { get; set; }
        [Required]
        public int QrqcId { get; set; }
    }
}
