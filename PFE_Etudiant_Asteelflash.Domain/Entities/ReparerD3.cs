using PFE_Etudiant_Asteelflash.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class ReparerD3
    {
        [Key]
        public int Id { get; set; }
        public string PiloteID { get; set; }
        [ForeignKey("PiloteID")]
        public ApplicationUser? Pilote { get; set; }


        public Enum_Action_Immediate? Réparer_Edition { get; set; }
        public Enum_Action_Immediate? Réparer_Définition_Des_Flux { get; set; }
        public Enum_Action_Immediate? Réparer_Définition_Du_Point { get; set; }
        public Enum_Action_Immediate? Réparer_Formation { get; set; }
        public Enum_Action_Immediate? Réparer_Déclenchement { get; set; }

        public int ActionDeSecurisationD3ID { get; set; }
        [ForeignKey("ActionDeSecurisationD3ID")]
        public ActionDeSecurisationD3? ActionDeSecurisationD3 { get; set; }
    }
}
