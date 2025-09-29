using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class SuiviD6
    {
        [Key]
        public int Id { get; set; }
        
        public string Equipe1 { get; set; }
        public DateTime DateRealisation1 { get; set; }
        public string Equipe2 { get; set; }
        public DateTime DateRealisation2 { get; set; }

        public string Equipe3 { get; set; }
        public DateTime DateRealisation3 { get; set; }

        public string Equipe4 { get; set; }
        public DateTime DateRealisation4 { get; set; }

        public string Equipe5{ get; set; }
        public DateTime DateRealisation5 { get; set; }

        public int QrqcId { get; set; }
        [ForeignKey("QrqcId")]
        public Qrqc? Qrqc { get; set; }
    }
}
