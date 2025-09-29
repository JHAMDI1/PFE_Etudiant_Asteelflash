using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Dtos
{
    public class CreateActionImmediateGlobaleDto
    {
        public Enum_Action_Immediate? ContenirStopper { get; set; }
        public Enum_Action_Immediate? ContenirDeroulement { get; set; }
        public Enum_Action_Immediate? ReparerDeclenchement { get; set; }

        [Required, StringLength(500, MinimumLength = 5)]
        public string ConclusionTri { get; set; }
        public int? ActionDeSecurisationId { get; set; }
    }
}
