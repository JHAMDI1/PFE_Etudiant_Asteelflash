namespace PFE_Etudiant_Asteelflash.Application.Tri.Dtos
{
    /// <summary>
    /// DTO léger pour l'entité TriFncQrqc destiné aux vues MVC.
    /// </summary>
    public class TriFncQrqcDto
    {
        public int Id { get; set; }
        public int FncId { get; set; }
        public DateTime DateTri { get; set; }
        public string? PiloteName { get; set; }
        public string? Client { get; set; }
        public string? ReferenceProduit { get; set; }
        public string? ObjetTri { get; set; }
        public string? NumeroAlerte { get; set; }
        public int TotalTrie { get; set; }
        public int TotalNonConforme { get; set; }
        public decimal PourcentageDefaut { get; set; }

        // Lignes de suivi de tri
        public List<TriFncQrqcLigneDto> Lignes { get; set; } = new();
    }
}
