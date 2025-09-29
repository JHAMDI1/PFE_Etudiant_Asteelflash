using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos
{
    public class CreateQrqcDto
    {
        // Create Qrqc 
        [Required]
        public int FNCId { get; set; }
        [StringLength(100)]
        public string? Client_name { get; set; }
        [Required]
        public NatureDefaut NatureDefaut { get; set; }
        public bool AlerteQualite { get; set; } = false;
        public string ProcessorID { get; set; }
    }
}
