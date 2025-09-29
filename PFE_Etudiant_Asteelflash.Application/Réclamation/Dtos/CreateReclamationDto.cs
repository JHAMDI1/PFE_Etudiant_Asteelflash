using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Application.Réclamation.Dtos
{
    public class CreateReclamationDto
    {
        [Required, StringLength(500, MinimumLength = 10)]
        public string Description { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}
