using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Dtos
{
    public class CreateActionDeSecurisationD3Dto
    {
        [Required]
        public ActionD3 Action { get; set; }
        [Required]
        public TypeReclamation TypeReclamation { get; set; }
        [Required, StringLength(300)]
        public int QRQCId { get; set; }
    }
}
