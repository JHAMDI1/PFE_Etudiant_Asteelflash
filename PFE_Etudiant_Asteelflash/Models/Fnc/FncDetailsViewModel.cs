using PFE_Etudiant_Asteelflash.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Models.Fnc
{
    public class FncDetailsViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Référence")]
        [Required]
        public string Ref { get; set; } = string.Empty;
        
        [Display(Name = "Numéro")]
        public string Num { get; set; }
        
        [Display(Name = "ZAP ID")]
        public int ZapId { get; set; }
        
        [Display(Name = "ZAP")]
        public string ZapName { get; set; }
        
        [Display(Name = "ID Émetteur")]
        public string TransmitterId { get; set; }
        
        [Display(Name = "Émetteur")]
        public string TransmitterName { get; set; }
        
        [Display(Name = "ID Traiteur")]
        public string ProcessorId { get; set; }
        
        [Display(Name = "Traiteur")]
        public string ProcessorName { get; set; }
        
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
        [Display(Name = "Heure")]
        [DataType(DataType.Time)]
        public TimeSpan Hour { get; set; }
        
        [Display(Name = "Client")]
        public string Client_name { get; set; }
        
        [Display(Name = "Statut")]
        public string Status { get; set; }
        
        [Display(Name = "Lieu de détection")]
        public string? Detection_loc { get; set; }
        
        [Display(Name = "Quantité NOK")]
        public int Quantity_NOK { get; set; }
        
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Énoncé de la réclamation")]
        public string Enonce_de_la_reclamaion { get; set; }

        [Display(Name = "Pourquoi")]
        public string pour_quoi { get; set; }
        
        [Display(Name = "Bilan de tri")]
        public bool Bilan_de_tri { get; set; }
        
        [Display(Name = "Type de défaut")]
        public TypeDefaut TypeDefaut { get; set; }
        
        [Display(Name = "Image pièce bonne")]
        public string? ImageUrl_Piece_bonne { get; set; }
        [Display(Name = "Image pièce mauvaise")]
        public string? ImageUrl_Piece_Mauvaise { get; set; }
        [Display(Name = "Image 3")]
        public string? ImageUrl_3 { get; set; }
        [Display(Name = "Image 4")]
        public string? ImageUrl_4 { get; set; }
        [Display(Name = "Image 5")]
        public string? ImageUrl_5 { get; set; }
        
        [Display(Name = "Type de FNC")]
        public TypeFnc TypeFnc { get; set; }
        
        [Display(Name = "Impact NC")]
        public NcImpact NcImpact { get; set; }
        
        [Display(Name = "Action immédiate")]
        public ActionImm ActionImmediate { get; set; }

        [Display(Name = "Approbation conducteur")]
        public bool Approbation_conducteur { get; set; }
        
        [Display(Name = "Possède QRQC")]
        public bool HasQrqc { get; set; }

        // Résumé du QRQC associé (null si aucun)
        public PFE_Etudiant_Asteelflash.Application.Fnc.Dtos.QrqcSummaryDto? Qrqc { get; set; }

        // Type de traitement choisi (QRQC, Tri ou Plan). Null si aucun.
        public TypeTraitement? TraitementChoisi { get; set; }

        // Indique si l'utilisateur connecté fait partie des destinataires de la notification FNC
        public bool IsRecipient { get; set; }

        // Indique si l'utilisateur connecté est Conducteur
        public bool IsConducteur { get; set; }
    }
}
