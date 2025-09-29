using PFE_Etudiant_Asteelflash.Application.Authentication.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Authentication.Services;
using PFE_Etudiant_Asteelflash.Application.Fnc.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Fnc.Mapping;
using PFE_Etudiant_Asteelflash.Application.Fnc.Services;
using PFE_Etudiant_Asteelflash.Application.Day2.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day2.Services;
using PFE_Etudiant_Asteelflash.Application.Day2.Mapping;
// Day3
using PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Services;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Mapping;
// Day5
using PFE_Etudiant_Asteelflash.Application.Day5.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day5.Services;
using PFE_Etudiant_Asteelflash.Application.Day5.Mapping;
// Day6
using PFE_Etudiant_Asteelflash.Application.Day6.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day6.Services;
using PFE_Etudiant_Asteelflash.Application.Day6.Mapping;
// Day7
using PFE_Etudiant_Asteelflash.Application.Day7.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day7.Services;
using PFE_Etudiant_Asteelflash.Application.Day7.Mapping;
// Day8
using PFE_Etudiant_Asteelflash.Application.Day8.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day8.Services;
using PFE_Etudiant_Asteelflash.Application.Day8.Mapping;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Services;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Mapping;
using PFE_Etudiant_Asteelflash.Application.Zap.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Zap.Services;

using Microsoft.Extensions.DependencyInjection;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Services;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Services;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Mapping;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Services;
using PFE_Etudiant_Asteelflash.Application.Réclamation.Interfaces;
using PFE_Etudiant_Asteelflash.Application.Réclamation.Services;
using PFE_Etudiant_Asteelflash.Application.Réclamation.Mapping;

namespace PFE_Etudiant_Asteelflash.Application.Common.Extension
{
    public static class ServicesRegistration
    {
        public static void AddServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IFncServices, FncServices>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IZapServices, ZapServices>();
            // QRQC
            services.AddScoped<IQrqcServices, QrqcServices>();
            services.AddScoped<IDescriptionDuProblemeD2Services, DescriptionDuProblemeD2Services>();
            services.AddScoped<ICauseOccurenceD4Services, CauseOccurenceD4Services>();
            services.AddScoped<ICausesNonDetectionD4Services, CausesNonDetectionD4Services>();
            services.AddScoped<IRecherche_causes_racinesD4Services, Recherche_causes_racinesD4Services>();

            // Réclamation
            services.AddScoped<IReclamationServices, ReclamationServices>();

            // Day3 services
            services.AddScoped<IActionDeSecurisationD3Services, ActionDeSecurisationD3Services>();
            services.AddScoped<IActionImmediateGlobaleServices, ActionImmediateGlobaleServices>();
            services.AddScoped<IAssurerD3Services, AssurerD3Services>();
            services.AddScoped<IContenirD3Services, ContenirD3Services>();
            services.AddScoped<IListeDesActionsD3Services, ListeDesActionsD3Services>();
            services.AddScoped<IQuantitéTriéeParJourServices, QuantitéTriéeParJourServices>();
            services.AddScoped<IReparerD3Services, ReparerD3Services>();
            services.AddScoped<ITriActionImmediateGlobaleServices, TriActionImmediateGlobaleServices>();
            services.AddScoped<ITrierD3Services, TrierD3Services>();
            services.AddScoped<IEquipeServices, EquipeServices>();
            // Day5
            services.AddScoped<IPlanActionsCorrectivesD5Services, PlanActionsCorrectivesD5Services>();
            // Day6
            services.AddScoped<ISuiviD6Services, SuiviD6Services>();
            // Day7
            services.AddScoped<IActD7Services, ActD7Services>();
            // Day8
            services.AddScoped<IClotureD8Services, ClotureD8Services>();


            services.AddAutoMapper(
                typeof(FncMappingProfile),
                // QRQC
                typeof(QrqcMappingProfile),
                // Day2
                typeof(DescriptionDuProblemeD2MappingProfile),
                // Day3
                typeof(ActionDeSecurisationD3MappingProfile),
                typeof(ActionImmediateGlobaleMappingProfile),
                typeof(AssurerD3MappingProfile),
                typeof(ContenirD3MappingProfile),
                typeof(ListeDesActionsD3MappingProfile),
                typeof(QuantitéTriéeParJourMappingProfile),
                typeof(ReparerD3MappingProfile),
                typeof(TriActionImmediateGlobaleMappingProfile),
                typeof(TrierD3MappingProfile),
                typeof(EquipeMappingProfile),
                // Day5
                typeof(PlanActionsCorrectivesD5MappingProfile),
                // Day6
                typeof(SuiviD6MappingProfile),
                // Day7
                typeof(ActD7MappingProfile),
                // Day8
                typeof(ClotureD8MappingProfile),
                // Réclamation
                typeof(ReclamationMappingProfile),
                // Day4
                typeof(CauseOccurenceD4MappingProfile),
                typeof(CausesNonDetectionD4MappingProfile),
                typeof(Recherche_causes_racinesD4MappingProfile)

            );

                   

        }
    }
}
