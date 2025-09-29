using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PFE_Etudiant_Asteelflash.Domain.Enums;




namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class ActionImmediateGlobale
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Contenir - Stopper")]
        public Enum_Action_Immediate? Contenir_Stopper { get; set; }


        [Display(Name = "Contenir - Déroulement")]
        public Enum_Action_Immediate? Contenir_Déroulement { get; set; }

        [Display(Name = "Réparer - Déclenchement")]
        public Enum_Action_Immediate? Réparer_Déclenchement { get; set; }

       
        [Required(ErrorMessage = "La conclusion du tri est obligatoire")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "La conclusion du tri doit contenir entre 5 et 500 caractères")]
        [Display(Name = "Conclusion du tri")]
        public string ConclusionTri { get; set; }

        
        [Display(Name = "ActionDeSecurisation")]
        public int? ActionDeSecurisationId { get; set; }

        [ForeignKey("ActionDeSecurisationId")]
        public ActionDeSecurisationD3? ActionDeSecurisation { get; set; }

      
        [Display(Name = "TriActionImmediateGlobale")]
        public ICollection<TriActionImmediateGlobale>? TriActionImmediateGlobales { get; set; } = new List<TriActionImmediateGlobale>();
    }
}

