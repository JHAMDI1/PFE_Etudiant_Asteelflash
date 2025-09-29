using PFE_Etudiant_Asteelflash.Domain.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;

namespace PFE_Etudiant_Asteelflash.Models.Fnc
{
    public class FncCreateViewModel : IValidatableObject
    {        
        [Required(ErrorMessage = "La ZAP Emittrice est requise")]
        [Display(Name = "ZAP Emittrice")]
        public int? ZapEmettriceId { get; set; }

        [Required(ErrorMessage = "La ZAP Receptrice est requise")]
        [Display(Name = "ZAP Receptrice")]
        public int? ZapReceptriceId { get; set; }

        [Display(Name = "Émetteur")]
        public string? TransmitterFullName { get; set; }
        
        [Display(Name = "ID Émetteur")]
        public string? TransmitterId { get; set; }
        
        [Required(ErrorMessage = "La date est requise")]
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;
        
        [Required(ErrorMessage = "L'heure est requise")]
        [Display(Name = "Heure")]
        [DataType(DataType.Time)]
        public TimeSpan Hour { get; set; } = DateTime.Now.TimeOfDay;
        
        [Display(Name = "Client")]
        public string? Client_name { get; set; }
        
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

        // Nouveaux champs requis
        [Required(ErrorMessage = "L'énoncé de la réclamation est requis")]
        [Display(Name = "Énoncé de la réclamation")]
        public string Enonce_de_la_reclamaion { get; set; }

        [Required(ErrorMessage = "Le champ 'Pourquoi' est requis")]
        [Display(Name = "Pourquoi")]
        public string pour_quoi { get; set; }
        
        [Display(Name = "Bilan de tri")]
        public bool Bilan_de_tri { get; set; }
        
        [Required(ErrorMessage = "Le type de défaut est requis")]
        [Display(Name = "Type de défaut")]
        public TypeDefaut? TypeDefaut { get; set; }
        
        [Required(ErrorMessage = "La référence est requise")]
        [Display(Name = "Référence")]
        public string Ref { get; set; }
        
        // Images (toutes optionnelles)
        [Display(Name = "Image pièce bonne")]
        public IFormFile? ImageFile_Piece_bonne { get; set; }
        [Display(Name = "Image pièce mauvaise")]
        public IFormFile? ImageFile_Piece_Mauvaise { get; set; }
        [Display(Name = "Image 3")]
        public IFormFile? ImageFile_3 { get; set; }
        [Display(Name = "Image 4")]
        public IFormFile? ImageFile_4 { get; set; }
        [Display(Name = "Image 5")]
        public IFormFile? ImageFile_5 { get; set; }

        // URLs sauvegardées
        public string? ImageUrl_Piece_bonne { get; set; }
        public string? ImageUrl_Piece_Mauvaise { get; set; }
        public string? ImageUrl_3 { get; set; }
        public string? ImageUrl_4 { get; set; }
        public string? ImageUrl_5 { get; set; }
        
        [Required(ErrorMessage = "Le type de FNC est requis")]
        [Display(Name = "Type de FNC")]
        public TypeFnc? TypeFnc { get; set; }
        
        [Required(ErrorMessage = "L'impact NC est requis")]
        [Display(Name = "Impact NC")]
        public NcImpact? NcImpact { get; set; }
        
        [Required(ErrorMessage = "L'action immédiate est requise")]
        [Display(Name = "Action immédiate")]
        public ActionImm? ActionImmediate { get; set; }

        // Champs conditionnels selon l'action immédiate
        [Display(Name = "Tri OK")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être positive")]
        public int? Tri_Ok { get; set; }

        [Display(Name = "Tri NOK")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être positive")]
        public int? Tri_NOk { get; set; }

        [Display(Name = "Numéro dérogation")]
        [Range(0, int.MaxValue, ErrorMessage = "La valeur doit être positive")]
        public int? Numero_dérogation { get; set; }

        [Display(Name = "Action de réparation")]
        [StringLength(200, ErrorMessage = "Le texte est trop long")]
        public string? Action_de_reparation { get; set; }

        [Display(Name = "Quantité Rebut")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être positive")]
        public int? Quantite_Rebut { get; set; }

        [Display(Name = "Quantité Isolation de lot")]
        [Range(0, int.MaxValue, ErrorMessage = "La quantité doit être positive")]
        public int? Quantite_Isoloation_de_lot { get; set; }
        
        [Display(Name = "Possède QRQC")]
        public bool HasQrqc { get; set; }
        
        // Champs conditionnels liés à ZAP émettrice
        [Display(Name = "Ligne CMS")]
        public CMS_Lignes? SelectedCMSLine { get; set; }

        [Display(Name = "Ligne Vague")]
        public Vague_Lignes? SelectedVagueLine { get; set; }

        [Display(Name = "Ligne Préparation")]
        public Preparaation_Lignes? SelectedPreparationLine { get; set; }

        // Conducteur CMS (affiché uniquement si l'émetteur est Contrôleur CMS)
        [Display(Name = "Conducteur CMS")]
        public string? ConducteurId { get; set; }
        public SelectList ConducteurOptions { get; set; } = new SelectList(new List<string>());

        // Lists for dropdowns
        public SelectList ZapOptions { get; set; } = new SelectList(new List<string>());
        public SelectList UserOptions { get; set; } = new SelectList(new List<string>());

        //public SelectList StatusOptions { get; set; } = new SelectList(new List<string>());
        public SelectList TypeOptions { get; set; } = new SelectList(new List<string>());
        public SelectList TypeDefautOptions { get; set; } = new SelectList(new List<string>());
        public SelectList NcImpactOptions { get; set; } = new SelectList(new List<string>());
        public SelectList ActionImmediateOptions { get; set; } = new SelectList(new List<string>());
        public SelectList CMSLineOptions { get; set; } = new SelectList(new List<string>());
        public SelectList VagueLineOptions { get; set; } = new SelectList(new List<string>());
        public SelectList PreparationLineOptions { get; set; } = new SelectList(new List<string>());

        // Custom validation based on ZAP
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationErrors = new List<ValidationResult>();

            // Determine selected ZAP libellé via injected services optionally, but we only know ID in model
            // For simplicity, we assume ZAP ID mapping is handled elsewhere; here we validate based on available fields

            // If no client specified and user selected Integration ZAP (id to be 4? this logic may vary)
            // Front-end ensures client field visible only for Integration, but server validation replicates rule using heuristics
            if (IsIntegrationZap() && string.IsNullOrWhiteSpace(Client_name))
            {
                validationErrors.Add(new ValidationResult("Le nom du client est requis pour la ZAP Integration", new[] { nameof(Client_name) }));
            }

            return validationErrors;
        }

        private bool IsIntegrationZap()
        {
            // TODO: Adjust this logic: Replace 4 with the actual Integration ZAP ID or incorporate Zap name check
            const int integrationZapId = 4; // example id
            return ZapEmettriceId.HasValue && ZapEmettriceId.Value == integrationZapId;
        }
    }
}
