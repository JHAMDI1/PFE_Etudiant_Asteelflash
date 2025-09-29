using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Dtos
{
    public class CreateTriActionImmediateGlobaleDto
    {
        [Required, StringLength(100)]
        public string Zone { get; set; }

        [Range(0, int.MaxValue)]
        public int NombrePieceTrie { get; set; }

        [Range(0, int.MaxValue)]
        public int NombrePieceTotale { get; set; }

        [Required]
        public int ActionImmediateGlobaleId { get; set; }
    }
}
