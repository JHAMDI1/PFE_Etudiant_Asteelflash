using PFE_Etudiant_Asteelflash.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Dtos
{
    /// <summary>
    /// DTO pour l'affichage détaillé d'une FNC, incluant toutes les informations associées
    /// </summary>
    public class FncDetailDto
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Num { get; set; }
        
        // Informations Zap
        public int ZapEmettriceId { get; set; }
        public string ZapEmettriceName { get; set; }
        public int ZapReceptriceId { get; set; }
        public string ZapReceptriceName { get; set; }
        
        // Informations utilisateurs
        public string TransmitterId { get; set; }
        public string TransmitterName { get; set; }
        public string ProcessorId { get; set; }
        public string ProcessorName { get; set; }
        
        // Informations temporelles
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string FormattedDateTime => $"{Date.ToShortDateString()} {Hour}";
        
        // Informations descriptives
        public string Client_name { get; set; }
        public string Status { get; set; }
        public string Detection_loc { get; set; }
        public int Quantity_NOK { get; set; }
        public string Description { get; set; }

        // Nouveaux champs
        public string Enonce_de_la_reclamaion { get; set; }
        public string pour_quoi { get; set; }
        
        // Informations techniques
        public bool Bilan_de_tri { get; set; }
        public TypeDefaut TypeDefaut { get; set; }
        public string TypeDefautName => TypeDefaut.ToString();
        public string? ImageUrl_Piece_bonne { get; set; }
        public string? ImageUrl_Piece_Mauvaise { get; set; }
        public string? ImageUrl_3 { get; set; }
        public string? ImageUrl_4 { get; set; }
        public string? ImageUrl_5 { get; set; }
        public TypeFnc TypeFnc { get; set; }
        public string TypeFncName => TypeFnc.ToString();
        public NcImpact NcImpact { get; set; }
        public string NcImpactName => NcImpact.ToString();
        public ActionImm ActionImmediate { get; set; }
        public string ActionImmediateName => ActionImmediate.ToString();

        // Action de réparation
        public string? Action_de_reparation { get; set; }

        // Indique si la FNC a été approuvée par le conducteur
        public bool Approbation_conducteur { get; set; }
        
        // QRQC associé
        public bool HasQrqc { get; set; }
        public QrqcSummaryDto Qrqc { get; set; }
        
        // Liste des historiques 
        public List<HistoriqueDto> Historiques { get; set; } = new List<HistoriqueDto>();
    }
    
    // DTOs simplifiés pour les relations
    public class HistoriqueDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
    
    public class QrqcSummaryDto
    {
        public int Id { get; set; }
        public string Titre { get; set; }
        public DateTime DateCreation { get; set; }
        public string Statut { get; set; }
    }
}
