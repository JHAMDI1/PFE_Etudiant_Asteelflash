using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    /// <summary>
    /// Ligne du plan d'actions (rei2).
    /// </summary>
    [Table("PlanActionFncLigne")]
    public class PlanActionFncQrqcLigne
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int PlanActionFncQrqcId { get; set; }
        public PlanActionFncQrqc? PlanActionFncQrqc { get; set; }

        public int Numero { get; set; }
        public DateTime DateCreation { get; set; }
        public string? Origine { get; set; }
        public string? Sujet { get; set; }
        public string? Processus { get; set; }
        public string? DescriptionProbleme { get; set; }
        public string? CauseRacine { get; set; }
        public string? TypeAction { get; set; } // Q ou D
        public bool NC { get; set; }
        public string? Action { get; set; }
        public string? Responsable { get; set; }
        public DateTime DatePrevue { get; set; }
        public DateTime? DateRealise { get; set; }
        public DateTime? DateMesureEfficacite { get; set; }
        public string? RespMesureEfficacite { get; set; }
        public bool? EfficaciteOK { get; set; }
        public string? Avancement { get; set; }
        public int? Retard { get; set; }
        public string? Commentaire { get; set; }
        public string? PointCritique { get; set; }
    }
}
