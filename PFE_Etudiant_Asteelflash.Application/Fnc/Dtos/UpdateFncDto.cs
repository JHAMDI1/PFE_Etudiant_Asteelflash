using PFE_Etudiant_Asteelflash.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Dtos
{
    public class UpdateFncDto
    {
        [Required(ErrorMessage = "L'ID est obligatoire")]
        public required int Id { get; set; }

        [Required(ErrorMessage = "La référence est obligatoire")]
        public required string Ref { get; set; }

        [Required(ErrorMessage = "Le numéro est obligatoire")]
        public required string Num { get; set; }

        [Required(ErrorMessage = "L'ID de la ZAP émettrice est obligatoire")]
        public int? ZapEmettriceId { get; set; }

        [Required(ErrorMessage = "L'ID de la ZAP réceptrice est obligatoire")]
        public int? ZapReceptriceId { get; set; }

        [Required(ErrorMessage = "L'ID du transmetteur est obligatoire")]
        public required string TransmitterID { get; set; }

        [Required(ErrorMessage = "L'ID du processeur est obligatoire")]
        public required string ProcessorID { get; set; }

        [Required(ErrorMessage = "La date est obligatoire")]
        public required DateTime Date { get; set; }

        [Required(ErrorMessage = "L'heure est obligatoire")]
        public required TimeSpan Hour { get; set; }

        [Required(ErrorMessage = "Le nom du client est obligatoire")]
        public required string Client_name { get; set; }

        public string? Status { get; set; }

        [Required(ErrorMessage = "Le lieu de détection est obligatoire")]
        public required string Detection_loc { get; set; }

        [Required(ErrorMessage = "La quantité NOK est obligatoire")]
        public required int Quantity_NOK { get; set; }

        [Required(ErrorMessage = "La description est obligatoire")]
        public required string Description { get; set; }

        // Nouveaux champs requis
        [Required(ErrorMessage = "L'énoncé de la réclamation est obligatoire")]
        [Display(Name = "Énoncé de la réclamation")]
        public required string Enonce_de_la_reclamaion { get; set; }

        [Required(ErrorMessage = "Le champ 'Pourquoi' est obligatoire")]
        [Display(Name = "Pourquoi")]
        public required string pour_quoi { get; set; }

        public bool Bilan_de_tri { get; set; }

        [Required(ErrorMessage = "Le type de défaut est obligatoire")]
        public required TypeDefaut TypeDefaut { get; set; }

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
        public required TypeFnc TypeFnc { get; set; }

        [Required(ErrorMessage = "L'impact de la non-conformité est obligatoire")]
        public required NcImpact NcImpact { get; set; }

        [Required(ErrorMessage = "L'action immédiate est obligatoire")]
        public required ActionImm ActionImmediate { get; set; }

        // Action de réparation
        [StringLength(200, ErrorMessage = "Le texte est trop long")]
        public string? Action_de_reparation { get; set; }
    }
}
