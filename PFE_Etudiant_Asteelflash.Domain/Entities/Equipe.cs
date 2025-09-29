using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class Equipe
    {
        [Key]
        public int Id { get; set; }
        
        public required int QrqcId { get; set; }
        [ForeignKey("QrqcId")]
        public Qrqc? Qrqc { get; set; }

        public required string UserId { get; set; } 
        [ForeignKey("UserId")]
        public ApplicationUser? applicationUser { get; set; }
        public Fonction Fonction { get; set; }
        public bool IsAbsent { get; set; }
    }
}
