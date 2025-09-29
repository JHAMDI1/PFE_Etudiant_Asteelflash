using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Dtos
{
    public class ActionImmediateGlobaleDto
    {
        public int Id { get; set; }
        public Enum_Action_Immediate? ContenirStopper { get; set; }
        public Enum_Action_Immediate? ContenirDeroulement { get; set; }
        public Enum_Action_Immediate? ReparerDeclenchement { get; set; }
        public string ConclusionTri { get; set; }
        public int? ActionDeSecurisationId { get; set; }
    }
}
