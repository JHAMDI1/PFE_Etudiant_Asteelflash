using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ActionDeSecurisationD3.Mapping
{
    public class ActionDeSecurisationD3MappingProfile : Profile
    {
        public ActionDeSecurisationD3MappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.ActionDeSecurisationD3, ActionDeSecurisationD3Dto>()
                .ForMember(dest => dest.Action, opt => opt.MapFrom(src => src.action));

            CreateMap<CreateActionDeSecurisationD3Dto, PFE_Etudiant_Asteelflash.Domain.Entities.ActionDeSecurisationD3>()
                .ForMember(dest => dest.action, opt => opt.MapFrom(src => src.Action));
        }
    }
}
