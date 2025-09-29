using PFE_Etudiant_Asteelflash.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class TrierD3
    {
        [Key]
        public int Id { get; set; }
        public string PiloteID { get; set; }
        [ForeignKey("PiloteID")]
        public ApplicationUser? Pilote { get; set; }


        public Enum_Action_Immediate? Trier_Edition { get; set; }
        public Enum_Action_Immediate? Trier_Formation { get; set; }
        public Enum_Action_Immediate? Trier_Définition { get; set; }
        public Enum_Action_Immediate? Trier_Déclenchement { get; set; }
        public Enum_Action_Immediate? Trier_En_Cours { get; set; }
        public Enum_Action_Immediate? Trier_Expédition { get; set; }

        public int ActionDeSecurisationD3ID { get; set; }
        [ForeignKey("ActionDeSecurisationD3ID")]
        public ActionDeSecurisationD3? ActionDeSecurisationD3 { get; set; }
    }
}
