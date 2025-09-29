using PFE_Etudiant_Asteelflash.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Models.Fnc
{
    public class FncEditViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Référence")]
        public string Ref { get; set; }
        
        [Required(ErrorMessage = "Le numéro est requis")]
        [Display(Name = "Numéro")]
        public string Num { get; set; }
        
        [Required(ErrorMessage = "La ZAP Emittrice est requise")]
        [Display(Name = "ZAP Emittrice")]
        public int? ZapEmettriceId { get; set; }
        
        [Required(ErrorMessage = "La ZAP Receptrice est requise")]
        [Display(Name = "ZAP Receptrice")]
        public int? ZapReceptriceId { get; set; }
        
        [Display(Name = "ID Émetteur")]
        public string? TransmitterId { get; set; }
        
        [Display(Name = "ID Traiteur")]
        public string? ProcessorId { get; set; }
        
        [Required(ErrorMessage = "La date est requise")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Required(ErrorMessage = "L'heure est requise")]
        [Display(Name = "Heure")]
        [DataType(DataType.Time)]
        public TimeSpan Hour { get; set; }
        
        [Required(ErrorMessage = "Le nom du client est requis")]
        [Display(Name = "Client")]
        public string Client_name { get; set; }
        
        [Required(ErrorMessage = "Le statut est requis")]
        [Display(Name = "Statut")]
        public string Status { get; set; }
        
        [Required(ErrorMessage = "Le lieu de détection est requis")]
        [Display(Name = "Lieu de détection")]
        public string Detection_loc { get; set; }
        
        [Required(ErrorMessage = "La quantité NOK est requise")]
        [Display(Name = "Quantité NOK")]
        [Range(1, int.MaxValue, ErrorMessage = "La quantité doit être supérieure à 0")]
        public int Quantity_NOK { get; set; }
        
        [Required(ErrorMessage = "La description est requise")]
        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "La description ne peut pas dépasser 500 caractères")]
        public string Description { get; set; }
        
        [Display(Name = "Bilan de tri")]
        public bool Bilan_de_tri { get; set; }
        
        [Required(ErrorMessage = "Le type de défaut est requis")]
        [Display(Name = "Type de défaut")]
        public TypeDefaut TypeDefaut { get; set; }
        
        [Display(Name = "Image actuelle")]
        public string CurrentImageUrl { get; set; }
        
        [Required(ErrorMessage = "Le type de FNC est requis")]
        [Display(Name = "Type de FNC")]
        public TypeFnc TypeFnc { get; set; }
        
        [Required(ErrorMessage = "L'impact NC est requis")]
        [Display(Name = "Impact NC")]
        public NcImpact NcImpact { get; set; }
        
        [Required(ErrorMessage = "L'action immédiate est requise")]
        [Display(Name = "Action immédiate")]
        public ActionImm ActionImmediate { get; set; }

        [Display(Name = "Action de réparation")]
        [StringLength(200, ErrorMessage = "Le texte est trop long")]
        public string? Action_de_reparation { get; set; }
        
        [Display(Name = "Possède QRQC")]
        public bool HasQrqc { get; set; }
        
        // Options pour les listes déroulantes
        public List<SelectListItem> ZapOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> UserOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> StatusOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TypeDefautOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> TypeFncOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> NcImpactOptions { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> ActionImmediateOptions { get; set; } = new List<SelectListItem>();
    }
}
