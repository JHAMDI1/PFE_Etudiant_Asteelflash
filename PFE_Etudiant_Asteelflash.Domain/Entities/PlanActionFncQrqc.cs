using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    /// <summary>
    /// Plan d'actions (tableau Excel "rei2") – entité en-tête.
    /// Simplifié pour soutenance.
    /// </summary>
    [Table("PlanActionFnc")]
    public class PlanActionFncQrqc
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

        // KPIs du bandeau jaune
        [Column(TypeName = "decimal(5,2)")]
        public decimal? TauxClotureActions { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? TauxRespectDelais { get; set; }
        [Column(TypeName = "decimal(5,2)")]
        public decimal? TauxEfficacite { get; set; }

        public ICollection<PlanActionFncQrqcLigne> Lignes { get; set; } = new List<PlanActionFncQrqcLigne>();
    }
}
