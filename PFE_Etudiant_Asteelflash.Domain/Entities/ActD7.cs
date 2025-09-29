using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class ActD7
    {
        [Key]
        public int Id { get; set; }
        public ConnaissanceExperience ConnaissanceExperience { get; set; }

        public required int QrqcId { get; set; }
        [ForeignKey("QrqcId")]
        public Qrqc? Qrqc { get; set; }
    }
}
