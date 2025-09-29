using System;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Models.Fnc
{
    public class FncDeleteViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Référence")]
        public string Ref { get; set; }
        
        [Display(Name = "Numéro")]
        public string Num { get; set; }
        
        [Display(Name = "ZAP")]
        public string ZapName { get; set; }
        
        [Display(Name = "Émetteur")]
        public string TransmitterName { get; set; }
        
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Display(Name = "Client")]
        public string Client_name { get; set; }
        
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
