using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    /// <summary>
    /// Fiche de suivi de tri (tableau Excel "tri1") – entité en-tête.
    /// Champs simplifiés pour soutenance.
    /// </summary>
    [Table("TriFnc")]
    public class TriFncQrqc
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FncId { get; set; }
        public Fnc? Fnc { get; set; }

        public DateTime DateCreationDoc { get; set; } = DateTime.Now;
        public DateTime? DateMiseAJour { get; set; }

        [StringLength(10)]
        public string? VersionDoc { get; set; }

        public DateTime DateTri { get; set; }

        public string? PiloteId { get; set; }
        public ApplicationUser? Pilote { get; set; }
        public string? PiloteName { get; set; }

        public string? Client { get; set; }
        public string? ReferenceProduit { get; set; }
        public string? ObjetTri { get; set; }
        public string? NumeroAlerte { get; set; }

        // Champs calculés – pourront être mis à jour en code ou DB
        public int TotalTrie { get; set; }
        public int TotalNonConforme { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal PourcentageDefaut { get; set; }

        public ICollection<TriFncQrqcLigne> Lignes { get; set; } = new List<TriFncQrqcLigne>();
    }
}
