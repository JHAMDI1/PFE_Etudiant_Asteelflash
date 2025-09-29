using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    /// <summary>
    /// Ligne (ZONE) de la fiche de suivi de tri.
    /// </summary>
    [Table("TriFncLigne")]
    public class TriFncQrqcLigne
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TriFncQrqcId { get; set; }
        public TriFncQrqc? TriFncQrqc { get; set; }

        [Required, StringLength(50)]
        public string Zone { get; set; } = string.Empty;

        public int QuantiteTriee { get; set; }
        public int QuantiteNonConforme { get; set; }

        [StringLength(20)]
        public string? MatriculeOperateur { get; set; }

        public string? DefautsDetectes { get; set; }
    }
}
