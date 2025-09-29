using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos
{
    public class EquipeDto
    {
        public int Id { get; set; }
        
        [Required]
        public int QrqcId { get; set; }
        
        [Required]
        public string UserId { get; set; }
        
        public Fonction Fonction { get; set; }
        
        public bool IsAbsent { get; set; }
    }
}
