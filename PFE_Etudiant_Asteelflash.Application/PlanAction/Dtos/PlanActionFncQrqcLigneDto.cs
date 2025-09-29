namespace PFE_Etudiant_Asteelflash.Application.PlanAction.Dtos
{
    public class PlanActionFncQrqcLigneDto
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public DateTime DateCreation { get; set; }
        public string? Origine { get; set; }
        public string? Sujet { get; set; }
        public string? Processus { get; set; }
        public string? DescriptionProbleme { get; set; }
        public string? CauseRacine { get; set; }
        public string? TypeAction { get; set; }
        public bool NC { get; set; }
        public string? Action { get; set; }
        public string? Responsable { get; set; }
        public DateTime? DatePrevue { get; set; }
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
