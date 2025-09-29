using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Dtos
{
    public class ContenirD3Dto
    {
        public int Id { get; set; }
        public string PiloteID { get; set; }
        public Enum_Action_Immediate? ContenirStopper { get; set; }
        public Enum_Action_Immediate? ContenirDeroulement { get; set; }
        public Enum_Action_Immediate? ContenirAjout { get; set; }
        public int ActionDeSecurisationD3ID { get; set; }
    }
}
