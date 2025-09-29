using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository.Base;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence.Repository;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.IRepository;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.External;
using PFE_Etudiant_Asteelflash.Infrastucture.External;
using PFE_Etudiant_Asteelflash.Domain.Interfaces.Upload_File;
using PFE_Etudiant_Asteelflash.Infrastucture.Persistence;

namespace PFE_Etudiant_Asteelflash.Infrastucture.Extension
{
    public static class InfrastructureRegistration
    {

        public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            //Register generic repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            //Register repositories
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IFncRepository, FncRepository>();
            services.AddScoped<IZapRepository, ZapRepository>();
            services.AddScoped<IDescriptionDuProblemeD2Repository, DescriptionDuProblemeD2Repository>();
            // Day3 repositories
            services.AddScoped<IActionDeSecurisationD3Repository, ActionDeSecurisationD3Repository>();
            services.AddScoped<IActionImmediateGlobaleRepository, ActionImmediateGlobaleRepository>();
            services.AddScoped<IAssurerD3Repository, AssurerD3Repository>();
            services.AddScoped<IContenirD3Repository, ContenirD3Repository>();
            services.AddScoped<IListeDesActionsD3Repository, ListeDesActionsD3Repository>();
            services.AddScoped<IQuantitéTriéeParJourRepository, QuantitéTriéeParJourRepository>();
            services.AddScoped<IReparerD3Repository, ReparerD3Repository>();
            services.AddScoped<ITriActionImmediateGlobaleRepository, TriActionImmediateGlobaleRepository>();
            services.AddScoped<ITrierD3Repository, TrierD3Repository>();
            services.AddScoped<IEquipeRepository, EquipeRepository>();
            // Day4 repositories
            services.AddScoped<ICauseOccurenceD4Repository, CauseOccurenceD4Repository>();
            services.AddScoped<ICausesNonDetectionD4Repository, CausesNonDetectionD4Repository>();
            services.AddScoped<IRecherche_causes_racinesD4Repository, Recherche_causes_racinesD4Repository>();
            services.AddScoped<IPlanActionsCorrectivesD5Repository, PlanActionsCorrectivesD5Repository>();
            services.AddScoped<ISuiviD6Repository, SuiviD6Repository>();
            services.AddScoped<IActD7Repository, ActD7Repository>();
            services.AddScoped<IQrqcRepository, QrqcRepository>();
            services.AddScoped<IRéclamationRepository, RéclamationRepository>();
            services.AddScoped<IClotureD8Repository, ClotureD8Repository>();

            //Register EmailSender 
            services.AddScoped<IEmailSender, EmailSender>();

            //Register FileHelper
            services.AddScoped<IFileHelper, FileHelper>();

            // Enregistrement du service de notification
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }


    }
}
