using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class PlanActionsCorrectivesD5
    {
        [Key]
        public int id { get; set; }
        public string ActionEliminationProbleme { get; set; }
        public required string PiloteID { get; set; }
        [ForeignKey("PiloteID")]
        public ApplicationUser? Pilote { get; set; }
        public DateTime DatePlanifiee { get; set; }
        public int QrqcId { get; set; }
        [ForeignKey("QrqcId")]
        public Qrqc? Qrqc { get; set; }
    }
}
