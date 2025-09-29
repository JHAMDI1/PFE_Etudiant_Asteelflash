using System;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos
{
    public class QrqcDto
    {
        public int Id { get; set; }
        public int FNCId { get; set; }
        public string ClientName { get; set; }
        public NatureDefaut NatureDefaut { get; set; }
        public bool AlerteQualite { get; set; }
        public string ProcessorID { get; set; }
        public string ProcessorFullName { get; set; }
        public string Statut { get; set; }
        // Propriété conservée pour compatibilité avec l'ancien code
        public string StatutCloture { get => Statut; set => Statut = value; }
    }
}
