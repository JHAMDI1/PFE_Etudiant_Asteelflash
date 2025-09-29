using System;

namespace PFE_Etudiant_Asteelflash.Application.Day2.Dtos
{
    public class DescriptionDuProblemeD2Dto
    {
        public int Id { get; set; }
        public string Probleme { get; set; }
        public string Detecteur { get; set; }
        public string LieuDeDetection { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Heure { get; set; }
        public string ManiereDeDetection { get; set; }
        public int NbreDePiecesConcernes { get; set; }
        public string RaisonDuProbleme { get; set; }
        public bool ReccurenceDuProbleme { get; set; }
        public bool Risque { get; set; }
        public int QRQCId { get; set; }
    }
}
