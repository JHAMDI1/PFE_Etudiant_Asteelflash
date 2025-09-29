using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionImmediateGlobale.Mapping
{
    public class ActionImmediateGlobaleMappingProfile : Profile
    {
        public ActionImmediateGlobaleMappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.ActionImmediateGlobale, ActionImmediateGlobaleDto>()
                .ForMember(dest => dest.ContenirStopper, opt => opt.MapFrom(src => src.Contenir_Stopper))
                .ForMember(dest => dest.ContenirDeroulement, opt => opt.MapFrom(src => src.Contenir_Déroulement))
                .ForMember(dest => dest.ReparerDeclenchement, opt => opt.MapFrom(src => src.Réparer_Déclenchement));

            CreateMap<CreateActionImmediateGlobaleDto, PFE_Etudiant_Asteelflash.Domain.Entities.ActionImmediateGlobale>()
                .ForMember(dest => dest.Contenir_Stopper, opt => opt.MapFrom(src => src.ContenirStopper))
                .ForMember(dest => dest.Contenir_Déroulement, opt => opt.MapFrom(src => src.ContenirDeroulement))
                .ForMember(dest => dest.Réparer_Déclenchement, opt => opt.MapFrom(src => src.ReparerDeclenchement));
        }
    }
}
