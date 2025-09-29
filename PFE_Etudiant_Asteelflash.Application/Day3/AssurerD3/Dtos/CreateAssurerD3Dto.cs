using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Dtos
{
    public class CreateAssurerD3Dto
    {
        public string PiloteID { get; set; }
        public Enum_Action_Immediate? AssurerReunion { get; set; }
        public Enum_Action_Immediate? AssurerAudit { get; set; }
        [Required]
        public int ActionDeSecurisationD3ID { get; set; }
    }
}
