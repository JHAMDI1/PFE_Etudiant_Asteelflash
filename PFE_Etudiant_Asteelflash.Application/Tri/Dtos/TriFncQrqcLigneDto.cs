namespace PFE_Etudiant_Asteelflash.Application.Tri.Dtos
{
    public class TriFncQrqcLigneDto
    {
        public int Id { get; set; }
        public string Zone { get; set; } = string.Empty;
        public int QuantiteTriee { get; set; }
        public int QuantiteNonConforme { get; set; }

        public string? MatriculeOperateur { get; set; }
        public string? DefautsDetectes { get; set; }
    }
}
