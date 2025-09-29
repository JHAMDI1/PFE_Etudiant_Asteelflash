using System;

namespace PFE_Etudiant_Asteelflash.Application.Day5.Dtos
{
    public class PlanActionsCorrectivesD5Dto
    {
        public int Id { get; set; }
        public string ActionEliminationProbleme { get; set; }
        public string PiloteID { get; set; }
        public DateTime DatePlanifiee { get; set; }
        public int QrqcId { get; set; }
    }
}
