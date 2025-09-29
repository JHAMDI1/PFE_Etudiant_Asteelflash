using PFE_Etudiant_Asteelflash.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Models.Fnc
{
    public class FncIndexViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Référence")]
        public string Ref { get; set; }
        
        [Display(Name = "Numéro")]
        public string Num { get; set; }
        
        [Display(Name = "ZAP")]
        public string ZapName { get; set; }
        
        [Display(Name = "Émetteur")]
        public string? TransmitterName { get; set; }
        
        [Display(Name = "Traiteur")]
        public string? ProcessorName { get; set; }
        
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Display(Name = "Client")]
        public string Client_name { get; set; }
        
        [Display(Name = "Statut")]
        public string Status { get; set; }
        
        [Display(Name = "Type de défaut")]
        public TypeDefaut TypeDefaut { get; set; }
        
        [Display(Name = "Type de FNC")]
        public TypeFnc TypeFnc { get; set; }
        public bool HasQrqc { get; set; }
        
        // Ajout des options de filtre pour la vue Index
        public Dictionary<string, List<SelectListItem>> FilterOptions { get; set; } = new Dictionary<string, List<SelectListItem>>();
    }
}
