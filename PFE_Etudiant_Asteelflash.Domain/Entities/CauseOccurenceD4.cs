using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;
using PFE_Etudiant_Asteelflash.Domain;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class CauseOccurenceD4
    {
        [Key]
        public int id {  get; set; }
        public string Pourquoi { get; set; }

        public required int QrqcId { get; set; }
        [ForeignKey("QrqcId")]
        public Qrqc? Qrqc { get; set; }

        public EnumCause Cause { get; set; }
    }
}
