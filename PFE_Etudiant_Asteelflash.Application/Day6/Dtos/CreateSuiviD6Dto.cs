using System;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Application.Day6.Dtos
{
    public class CreateSuiviD6Dto
    {
        [Required]
        public string Equipe1 { get; set; }
        [Required]
        public DateTime DateRealisation1 { get; set; }
        public string Equipe2 { get; set; }
        public DateTime? DateRealisation2 { get; set; }
        public string Equipe3 { get; set; }
        public DateTime? DateRealisation3 { get; set; }
        public string Equipe4 { get; set; }
        public DateTime? DateRealisation4 { get; set; }
        public string Equipe5 { get; set; }
        public DateTime? DateRealisation5 { get; set; }
        [Required]
        public int QrqcId { get; set; }
    }
}
