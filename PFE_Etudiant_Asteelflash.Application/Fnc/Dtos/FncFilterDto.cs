using PFE_Etudiant_Asteelflash.Domain.Enums;
using System;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Dtos
{
    /// <summary>
    /// DTO pour les critères de filtrage des FNCs
    /// </summary>
    public class FncFilterDto
    {
        // Filtres de base
        public string SearchTerm { get; set; }
        public string SearchText { get; set; } // Ajouté pour compatibilité
        public string Status { get; set; }
        
        // Filtres par date
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        
        // Filtres par type
        public TypeFnc? TypeFnc { get; set; }
        // Propriété pour stocker le nom du type comme chaîne (pour les filtres de l'UI)
        public string TypeName { get; set; }
        
        // Filtres par impact
        public NcImpact? NcImpact { get; set; }
        // Propriété pour stocker le nom de l'impact comme chaîne (pour les filtres de l'UI)
        public string ImpactName { get; set; }
        
        // Filtre par action immédiate
        public ActionImm? ActionImm { get; set; } // Ajouté pour compatibilité
        public string ActionName { get; set; }
        
        public TypeDefaut? TypeDefaut { get; set; }
        
        // Filtres par utilisateur
        public string TransmitterId { get; set; }
        public string ProcessorId { get; set; }
        
        // Filtres par client/zone
        public string ClientName { get; set; }
        
        public string DetectionLocation { get; set; }
        public int? ZapId { get; set; }
        
        // Filtres QRQC
        public bool? HasQrqc { get; set; }
    }
}
