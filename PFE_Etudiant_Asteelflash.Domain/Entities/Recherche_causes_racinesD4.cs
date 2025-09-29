using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class Recherche_causes_racinesD4
    {
        [Key]
        public int Id { get; set; }

        public string Action { get; set; }
        public string OD { get; set; }

        public required string PiloteID { get; set; }
        [ForeignKey("PiloteID")]
        public ApplicationUser? Pilote { get; set; }
        public DateOnly DatePrevue { get; set; }
        public DateOnly DateReelle { get; set; }
        public string Evolution { get; set; }

        // Foreign key to Qrqc
        public int? QrqcId { get; set; }
        [ForeignKey("QrqcId")] public Qrqc? Qrqc { get; set; }
    }
}
