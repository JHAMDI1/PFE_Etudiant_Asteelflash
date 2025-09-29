using System;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Application.Day5.Dtos
{
    public class CreatePlanActionsCorrectivesD5Dto
    {
        [Required]
        public string ActionEliminationProbleme { get; set; }
        [Required]
        public string PiloteID { get; set; }
        [Required]
        public DateTime DatePlanifiee { get; set; }
        [Required]
        public int QrqcId { get; set; }
    }
}
