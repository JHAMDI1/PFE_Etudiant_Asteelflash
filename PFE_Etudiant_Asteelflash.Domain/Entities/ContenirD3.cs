using PFE_Etudiant_Asteelflash.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{ 
    public class ContenirD3
    {
        [Key]
        public int id {  get; set; }

        public string PiloteID { get; set; }
        [ForeignKey("PiloteID")]
        public ApplicationUser? Pilote { get; set; }

        public Enum_Action_Immediate? Contenir_Stopper { get; set; }
        public Enum_Action_Immediate? Contenir_Déroulement { get; set; }
        public Enum_Action_Immediate? Contenir_Ajout { get; set; }


        public int ActionDeSecurisationD3ID { get; set; }
        [ForeignKey("ActionDeSecurisationD3ID")]
        public ActionDeSecurisationD3? ActionDeSecurisationD3 { get; set; }
    }
}
