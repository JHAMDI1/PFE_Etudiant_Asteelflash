using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class Réclamation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "La description doit contenir entre 10 et 500 caractères")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public DateTime DateCreation { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "L'identifiant de l'utilisateur est obligatoire")]
        [Display(Name = "Identifiant de l'utilisateur")]
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
