using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class DescriptionDuProblemeD2
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La description du problème est obligatoire")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "La description du problème doit contenir entre 10 et 500 caractères")]
        [Display(Name = "Problème")]
        public string Probleme { get; set; }

        [Required(ErrorMessage = "Le détecteur est obligatoire")]
        [StringLength(100, ErrorMessage = "Le nom du détecteur ne peut pas dépasser 100 caractères")]
        [Display(Name = "Détecteur")]
        public string Detecteur { get; set; }

        [Required(ErrorMessage = "Le lieu de détection est obligatoire")]
        [StringLength(100, ErrorMessage = "Le lieu de détection ne peut pas dépasser 100 caractères")]
        [Display(Name = "Lieu de détection")]
        public string LieuDeDetection { get; set; }

        [Required(ErrorMessage = "La date est obligatoire")]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "L'heure est obligatoire")]
        [DataType(DataType.Time)]
        [Display(Name = "Heure")]
        public TimeSpan Heure { get; set; }

        [Required(ErrorMessage = "La manière de détection est obligatoire")]
        [StringLength(200, ErrorMessage = "La manière de détection ne peut pas dépasser 200 caractères")]
        [Display(Name = "Manière de détection")]

        public string ManiéreDeDetection { get; set; }


        [Required(ErrorMessage = "Le nombre de pièces concernées est obligatoire")]
        [Range(0, int.MaxValue, ErrorMessage = "Le nombre de pièces doit être positif")]
        [Display(Name = "Nombre de pièces concernées")]

        public int NbreDePiecesConcernes { get; set; }

        [Required(ErrorMessage = "La raison du problème est obligatoire")]
        [StringLength(300, MinimumLength = 5, ErrorMessage = "La raison du problème doit contenir entre 5 et 300 caractères")]
        [Display(Name = "Raison du problème")]
        public string RaisonDuProbleme { get; set; }

        [Display(Name = "Problème récurrent")]
        public  bool ReccurenceDuProbleme { get; set; }


        [Range(0, 10, ErrorMessage = "Le niveau de risque doit être entre 0 et 10")]

        [Display(Name = "Risque Existant")]
        public bool Risque { get; set; }


        [Required(ErrorMessage = "Le QRQC associé est obligatoire")]
        [Display(Name = "QRQC")]
        public int QRQCId { get; set; }

        [ForeignKey("QRQCId")]
        public Qrqc? QRQC { get; set; }


    }
}
