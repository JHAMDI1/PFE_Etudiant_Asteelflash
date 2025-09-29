using System;
using System.Collections.Generic;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos
{
    public class GlobalQrqcDto : CreateGlobalQrqcDto
    {
        public int Id { get; set; }
        
        // Propriétés de base
        public string? ProcessorFullName { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Client_name { get; set; }
        public string? Part_number { get; set; }
        public string? NatureDefaut { get; set; }
        
        // D2: Description du problème
        public string? DescriptionProbleme { get; set; }
        public string? CauseProbleme { get; set; }
        public string? Probleme { get; set; }
        public string? LieuDeDetection { get; set; }
        public string? Detecteur { get; set; }
        
        // D3: Actions
        public string? DescriptionActionSecurisation { get; set; }
        public DateTime? DateMiseEnPlace { get; set; }
        public string? ActionImmediateGlobale { get; set; }
        public string? PiloteImmediateGlobale { get; set; }
        public int? Jour1 { get; set; }
        public int? Jour2 { get; set; }
        public int? Jour3 { get; set; }
        public int? Jour4 { get; set; }
        public int? Jour5 { get; set; }

        // Full names of pilots for D3 sections
        public string? PiloteContenirFullName { get; set; }
        public string? PiloteTrierFullName { get; set; }
        public string? PiloteReparerFullName { get; set; }
        public string? PiloteAssurerFullName { get; set; }
        
        // D3: Paramètres complémentaires
        public ActionD3? Action { get; set; }
        public TypeReclamation? TypeReclamation { get; set; }

        // Action immédiate globale
        public Enum_Action_Immediate? ContenirStopperGlobale { get; set; }
        public Enum_Action_Immediate? ContenirDeroulementGlobale { get; set; }
        public Enum_Action_Immediate? ReparerDeclenchementGlobale { get; set; }
        public string? ConclusionTri { get; set; }

        // Liste des tris actions immédiates globales
        public List<TriActionImmediateGlobaleDto>? TriActions { get; set; }

        // Liste des actions D3
        public List<ListeDesActionsD3Dto>? ListeDesActions { get; set; }
        
        // D4: Causes
        public string? PourquoiOccurence { get; set; }
        public string? CauseOccurence { get; set; }
        public string? CauseNonDetection { get; set; }
        public string? PourquoiNonDetection { get; set; }
        public string? ActionRechercheCausesRacines { get; set; }
        public string? OD { get; set; }
        public string? PiloteIDRechercheCausesRacines { get; set; }
        public DateTime? DatePrevueRechercheCauses { get; set; }
        public DateTime? DateReelleRechercheCauses { get; set; }
        public string? EvolutionRechercheCausesRacines { get; set; }
        
        // D5: Plan actions correctives
        public string? ActionEliminationProbleme { get; set; }
        public string? PiloteIDPlanActions { get; set; }
        public DateTime? DatePlanifiee { get; set; }
        
        // D6: Suivi
        public string? Equipe1 { get; set; }
        public DateTime? DateRealisation1 { get; set; }
        
        // D7: Act
        public string? ConnaissanceExperience { get; set; }
        
        // D8: Clôture
        public DateTime? DateCloture { get; set; }
        public string? StatutCloture { get; set; }
        
        // Équipe
        public List<EquipeMemberDto>? Equipes { get; set; }

        // D9: Révision
        public DateTime? DateRevision { get; set; }
        public string? ResultatRevision { get; set; }

        // D10: Vérification
        public DateTime? DateVerification { get; set; }
        public string? ResultatVerification { get; set; }

        // D11: Action corrective
        public string? ActionCorrective { get; set; }
        public DateTime? DatePlanifieeActionCorrective { get; set; }

        // D12: Suivi action corrective
        public string? EquipeSuiviActionCorrective { get; set; }
        public DateTime? DateRealisationSuiviActionCorrective { get; set; }

        // D13: Clôture action corrective
        public DateTime? DateClotureActionCorrective { get; set; }
        public string? StatutClotureActionCorrective { get; set; }

        // D14: Révision action corrective
        public DateTime? DateRevisionActionCorrective { get; set; }
        public string? ResultatRevisionActionCorrective { get; set; }

        // D15: Vérification action corrective
        public DateTime? DateVerificationActionCorrective { get; set; }
        public string? ResultatVerificationActionCorrective { get; set; }

        // D16: Action préventive
        public string? ActionPreventive { get; set; }
        public DateTime? DatePlanifieeActionPreventive { get; set; }

        // D17: Suivi action préventive
        public string? EquipeSuiviActionPreventive { get; set; }
        public DateTime? DateRealisationSuiviActionPreventive { get; set; }

        // D18: Clôture action préventive
        public DateTime? DateClotureActionPreventive { get; set; }
        public string? StatutClotureActionPreventive { get; set; }
    }

    public class EquipeMemberDto
    {
        public string? MemberName { get; set; }
        public string? Fonction { get; set; }
        public bool IsAbsent { get; set; }
    }
}
