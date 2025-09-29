using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Dtos
{
    public class CreateReparerD3Dto
    {
        public string PiloteID { get; set; }
        public Enum_Action_Immediate? ReparerEdition { get; set; }
        public Enum_Action_Immediate? ReparerDefinitionDesFlux { get; set; }
        public Enum_Action_Immediate? ReparerDefinitionDuPoint { get; set; }
        public Enum_Action_Immediate? ReparerFormation { get; set; }
        public Enum_Action_Immediate? ReparerDeclenchement { get; set; }
        [Required]
        public int ActionDeSecurisationD3ID { get; set; }
    }
}
