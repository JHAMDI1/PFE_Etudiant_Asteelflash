using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class CausesNonDetectionD4
    {
        [Key]
        public int Id { get; set; }
        public EnumCause Cause { get; set; }

        public string Pourquoi { get; set; }

        public int QrqcId { get; set; }
        [ForeignKey("QrqcId")]
        public Qrqc? Qrqc { get; set; }
    }
}
