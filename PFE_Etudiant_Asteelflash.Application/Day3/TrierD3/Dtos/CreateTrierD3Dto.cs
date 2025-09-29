using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Dtos
{
    public class CreateTrierD3Dto
    {
        public string PiloteID { get; set; }
        public Enum_Action_Immediate? TrierEdition { get; set; }
        public Enum_Action_Immediate? TrierFormation { get; set; }
        public Enum_Action_Immediate? TrierDefinition { get; set; }
        public Enum_Action_Immediate? TrierDeclenchement { get; set; }
        public Enum_Action_Immediate? TrierEnCours { get; set; }
        public Enum_Action_Immediate? TrierExpedition { get; set; }
        [Required]
        public int ActionDeSecurisationD3ID { get; set; }
    }
}
