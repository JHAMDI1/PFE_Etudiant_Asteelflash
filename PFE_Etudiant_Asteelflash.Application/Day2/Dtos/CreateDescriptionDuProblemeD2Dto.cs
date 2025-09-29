using System;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Application.Day2.Dtos
{
    public class CreateDescriptionDuProblemeD2Dto
    {
        [Required, StringLength(500, MinimumLength = 10)]
        public string Probleme { get; set; }
        [Required, StringLength(100)]
        public string Detecteur { get; set; }
        [Required, StringLength(100)]
        public string LieuDeDetection { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Heure { get; set; }
        [Required, StringLength(200)]
        public string ManiereDeDetection { get; set; }
        [Range(0, int.MaxValue)]
        public int NbreDePiecesConcernes { get; set; }
        [Required, StringLength(300, MinimumLength = 5)]
        public string RaisonDuProbleme { get; set; }
        public bool ReccurenceDuProbleme { get; set; }
        public bool Risque { get; set; }
        [Required]
        public int QRQCId { get; set; }
    }
}
