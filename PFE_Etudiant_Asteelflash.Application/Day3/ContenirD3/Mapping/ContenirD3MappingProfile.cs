using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ContenirD3.Mapping
{
    public class ContenirD3MappingProfile : Profile
    {
        public ContenirD3MappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.ContenirD3, ContenirD3Dto>()
                .ForMember(dest => dest.ContenirStopper, opt => opt.MapFrom(src => src.Contenir_Stopper))
                .ForMember(dest => dest.ContenirDeroulement, opt => opt.MapFrom(src => src.Contenir_Déroulement))
                .ForMember(dest => dest.ContenirAjout, opt => opt.MapFrom(src => src.Contenir_Ajout));

            CreateMap<CreateContenirD3Dto, PFE_Etudiant_Asteelflash.Domain.Entities.ContenirD3>()
                .ForMember(dest => dest.Contenir_Stopper, opt => opt.MapFrom(src => src.ContenirStopper))
                .ForMember(dest => dest.Contenir_Déroulement, opt => opt.MapFrom(src => src.ContenirDeroulement))
                .ForMember(dest => dest.Contenir_Ajout, opt => opt.MapFrom(src => src.ContenirAjout));
        }
    }
}
