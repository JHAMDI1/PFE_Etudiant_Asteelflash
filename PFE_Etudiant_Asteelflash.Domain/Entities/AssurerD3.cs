using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class AssurerD3
    {
        [Key]
        public int Id { get; set; }
        public string PiloteID { get; set; }
        [ForeignKey("PiloteID")]
        public ApplicationUser? Pilote { get; set; }


        public Enum_Action_Immediate? Assurer_Réunion { get; set; }
        public Enum_Action_Immediate? Assurer_Audit { get; set; }

        public int ActionDeSecurisationD3ID { get; set; }
        [ForeignKey("ActionDeSecurisationD3ID")]
        public ActionDeSecurisationD3? ActionDeSecurisationD3 { get; set; }
    }
}
