using System;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos
{
    public class CausesNonDetectionD4Dto
    {
        public int Id { get; set; }
        public EnumCause Cause { get; set; }
        public string Pourquoi { get; set; }
        public int QrqcId { get; set; }
    }
}
