using System;

namespace PFE_Etudiant_Asteelflash.Application.PlanAction.Dtos
{
    public class PlanActionFncQrqcDto
    {
        public List<PlanActionFncQrqcLigneDto> Lignes { get; set; } = new();
        public int Id { get; set; }
        public int FncId { get; set; }
        public decimal? TauxClotureActions { get; set; }
        public decimal? TauxRespectDelais { get; set; }
        public decimal? TauxEfficacite { get; set; }
        public DateTime DateCreationDoc { get; set; }
        public int NombreActions { get; set; }
    }
}
