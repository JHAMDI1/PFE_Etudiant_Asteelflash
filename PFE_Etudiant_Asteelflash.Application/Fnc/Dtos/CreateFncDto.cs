using PFE_Etudiant_Asteelflash.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Dtos
{
    public class CreateFncDto
    {
        [Required(ErrorMessage = "La référence est obligatoire")]
        public string Ref { get; set; }

        [Required(ErrorMessage = "Le numéro est obligatoire")]
        public string Num { get; set; }

        [Required(ErrorMessage = "L'ID de la ZAP émettrice est obligatoire")]
        public int? ZapEmettriceId { get; set; }

        [Required(ErrorMessage = "L'ID de la ZAP réceptrice est obligatoire")]
        public int? ZapReceptriceId { get; set; }

        [Required(ErrorMessage = "L'ID du transmetteur est obligatoire")]
        public string TransmitterID { get; set; }

        // ID du conducteur CMS (optionnel, requis si Transmitter est Contrôleur CMS)
        public string? ConducteurId { get; set; }

        // ProcessorID est maintenant optionnel 
        public string? ProcessorID { get; set; }

        [Required(ErrorMessage = "La date est obligatoire")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "L'heure est obligatoire")]
        public TimeSpan Hour { get; set; }

        // Client_name est requis uniquement pour la ZAP Intégration (validation côté ViewModel)
        public string? Client_name { get; set; }

        public StatusFNC Status { get; set; } = StatusFNC.ouvert;

        [Required(ErrorMessage = "Le lieu de détection est obligatoire")]
        public string Detection_loc { get; set; }

        [Required(ErrorMessage = "La quantité NOK est obligatoire")]
        public int Quantity_NOK { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        public string Description { get; set; }

        // Nouveaux champs requis ajoutés pour l'énoncé de la réclamation et le pourquoi
        [Required(ErrorMessage = "L'énoncé de la réclamation est obligatoire")]
        [Display(Name = "Énoncé de la réclamation")]
        public string Enonce_de_la_reclamaion { get; set; }

        [Required(ErrorMessage = "Le champ 'Pourquoi' est obligatoire")]
        [Display(Name = "Pourquoi")]
        public string pour_quoi { get; set; }

        public bool Bilan_de_tri { get; set; }

        [Required(ErrorMessage = "Le type de défaut est obligatoire")]
        public TypeDefaut TypeDefaut { get; set; }

        // URLs des images téléchargées
        public string? ImageUrl_Piece_bonne { get; set; }
        public string? ImageUrl_Piece_Mauvaise { get; set; }
        public string? ImageUrl_3 { get; set; }
        public string? ImageUrl_4 { get; set; }
        public string? ImageUrl_5 { get; set; }

        // Fichiers images à téléverser (tous optionnels)
        public IFormFile? ImageFile_Piece_bonne { get; set; }
        public IFormFile? ImageFile_Piece_Mauvaise { get; set; }
        public IFormFile? ImageFile_3 { get; set; }
        public IFormFile? ImageFile_4 { get; set; }
        public IFormFile? ImageFile_5 { get; set; }

        [Required(ErrorMessage = "Le type de FNC est obligatoire")]
        public TypeFnc TypeFnc { get; set; }

        [Required(ErrorMessage = "L'impact de la non-conformité est obligatoire")]
        public NcImpact NcImpact { get; set; }

        [Required(ErrorMessage = "L'action immédiate est obligatoire")]
        public ActionImm ActionImmediate { get; set; }

        // Action de réparation
        [StringLength(200, ErrorMessage = "Le texte est trop long")]
        public string? Action_de_reparation { get; set; }
    }
}
