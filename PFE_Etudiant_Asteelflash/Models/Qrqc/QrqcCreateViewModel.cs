using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Dtos;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Dtos;

namespace PFE_Etudiant_Asteelflash.Models.Qrqc
{
    public class QrqcCreateViewModel : CreateGlobalQrqcDto
    {
        // Propriétés d'aide à la vue (listes déroulantes, etc.)
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> NatureDefautOptions { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> TypeReclamationOptions { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ActionImmediateOptions { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> StatusActionOptions { get; set; }

        // Liste dynamique pour Recherche Causes Racines D4
        public List<CreateRechercheCausesRacinesD4Dto> RechercheCausesRacines { get; set; } = new();

        public List<PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos.CreateListeDesActionsD3Dto> ListeActions { get; set; } = new();
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ActionD3Options { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> CauseOptions { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> CauseNonDetectionOptions { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> ConnaissanceExperienceOptions { get; set; }
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> FonctionOptions { get; set; }

        // Dropdown options for Pilote users (same workshop/AP as processor)
        [ScaffoldColumn(false)]
        public IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> PiloteOptions { get; set; }

        // Collection des tris Action Immédiate Globale à créer
        public List<CreateTriActionImmediateGlobaleDto> TriActions { get; set; } = new();

        // Collections dynamiques D4
        public List<CreateCauseOccurenceD4Dto> CausesOccurence { get; set; } = new();
        public List<CreateCausesNonDetectionD4Dto> CausesNonDetection { get; set; } = new();

        // Dynamic list for Plan Actions Correctives D5
        public List<PFE_Etudiant_Asteelflash.Application.Day5.Dtos.CreatePlanActionsCorrectivesD5Dto> PlanActionsCorrectives { get; set; } = new();

        // Collection des membres de l'équipe
        public List<PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos.CreateEquipeDto> Equipes { get; set; } = new();

        public QrqcCreateViewModel()
        {
            // Définir les dates initiales à la date du jour
            Date = DateTime.Today;               // D1 (Date du problème)
            DatePlanifiee = DateTime.Today;      // D5 (Date planifiée)
            DateRealisation1 = DateTime.Today;   // D6 (Date réalisation 1)

            // Préparer les listes d'options à partir des enums
            NatureDefautOptions = System.Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.NatureDefaut))
                .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.NatureDefaut>()
                .Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = ((int)e).ToString(), Text = e.ToString() });

            TypeReclamationOptions = System.Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.TypeReclamation))
                .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.TypeReclamation>()
                .Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = ((int)e).ToString(), Text = e.ToString() });

            ActionImmediateOptions = System.Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.Enum_Action_Immediate))
                .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.Enum_Action_Immediate>()
                .Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = ((int)e).ToString(), Text = e.ToString() });

            CauseOptions = System.Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.EnumCause))
                .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.EnumCause>()
                .Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = ((int)e).ToString(), Text = e.ToString() });

            // Même liste pour CauseNonDetection
            CauseNonDetectionOptions = CauseOptions;

            ConnaissanceExperienceOptions = System.Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.ConnaissanceExperience))
                .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.ConnaissanceExperience>()
                .Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = ((int)e).ToString(), Text = e.ToString() });

            FonctionOptions = System.Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.Fonction))
                .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.Fonction>()
                .Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = ((int)e).ToString(), Text = e.ToString() });

            StatusActionOptions = System.Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.StatusAction))
                .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.StatusAction>()
                .Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = ((int)e).ToString(), Text = e.ToString() });
            ActionD3Options = System.Enum.GetValues(typeof(PFE_Etudiant_Asteelflash.Domain.Enums.ActionD3))
                .Cast<PFE_Etudiant_Asteelflash.Domain.Enums.ActionD3>()
                .Select(e => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem { Value = ((int)e).ToString(), Text = e.ToString() });

            // Ajouter une entrée vide par défaut pour afficher le premier tableau
            TriActions.Add(new CreateTriActionImmediateGlobaleDto());

            // Ajouter un membre par défaut pour afficher le premier tableau Équipe
            Equipes.Add(new PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos.CreateEquipeDto());

            // Ajouter une entrée par défaut pour Plan Actions Correctives D5
            PlanActionsCorrectives.Add(new PFE_Etudiant_Asteelflash.Application.Day5.Dtos.CreatePlanActionsCorrectivesD5Dto { DatePlanifiee = DateTime.Today });

            // Ajouter les entrées par défaut pour causes D4
            CausesOccurence.Add(new PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Dtos.CreateCauseOccurenceD4Dto());
            CausesNonDetection.Add(new PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos.CreateCausesNonDetectionD4Dto());

            // Ajouter une entrée par défaut pour Recherche Causes Racines D4
            RechercheCausesRacines.Add(new PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Dtos.CreateRechercheCausesRacinesD4Dto());

            // Ajouter une action par défaut pour la liste des actions D3
            ListeActions.Add(new PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos.CreateListeDesActionsD3Dto());
        }
    }
}
