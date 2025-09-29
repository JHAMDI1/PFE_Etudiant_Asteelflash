using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Dtos
{
    public class ActionDeSecurisationD3Dto
    {
        public int Id { get; set; }
        public ActionD3 Action { get; set; }
        public TypeReclamation TypeReclamation { get; set; }
        public int QRQCId { get; set; }
    }
}
