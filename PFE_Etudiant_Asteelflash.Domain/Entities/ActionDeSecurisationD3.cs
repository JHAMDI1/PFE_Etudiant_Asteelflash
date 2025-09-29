using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PFE_Etudiant_Asteelflash.Domain.Enums;


namespace PFE_Etudiant_Asteelflash.Domain.Entities

{
    public class ActionDeSecurisationD3
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "L'action à réaliser est obligatoire")]
        [Display(Name = "Action")]
        public ActionD3 action {  get; set; }

        [Required(ErrorMessage = "Le type de réclamation est obligatoire")]
        [Display(Name = "Type de réclamation")]
        public  TypeReclamation  TypeReclamation { get; set; }

        [Required(ErrorMessage = "Le QRQC associé est obligatoire")]
        [Display(Name = "QRQC")]
        public int QRQCId { get; set; }

        [ForeignKey("QRQCId")]
        public Qrqc? QRQC { get; set; }

        public ActionImmediateGlobale? ActionImmediateGlobale { get; set; }
        public ContenirD3? ContenirD3 { get; set; }
        public TrierD3? TrierD3 { get; set; }
        public ReparerD3? ReparerD3 { get; set; }
        public AssurerD3? AssurerD3 { get; set; }
        public ListeDesActionsD3 ListeDesActionsD3 { get; set; }



    }
}
