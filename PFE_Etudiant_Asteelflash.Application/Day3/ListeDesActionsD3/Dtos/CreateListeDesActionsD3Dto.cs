using System;
using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos
{
    public class CreateListeDesActionsD3Dto
    {
        [Required, StringLength(200, MinimumLength = 3)]
        public string Action { get; set; }
        [Required]
        public StatusAction StatusAction { get; set; }
        [Required]
        public DateTime DatePrevue { get; set; }
        public DateTime DateReelle { get; set; }
        [StringLength(500)]
        public string Commentaire { get; set; }
        [Required]
        public string PiloteID { get; set; }
        [Required]
        public int ActionDeSecurisationD3Id { get; set; }
    }
}
