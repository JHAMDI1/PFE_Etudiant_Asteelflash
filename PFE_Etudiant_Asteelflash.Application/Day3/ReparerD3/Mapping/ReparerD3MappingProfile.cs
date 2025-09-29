using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ReparerD3.Mapping
{
    public class ReparerD3MappingProfile : Profile
    {
        public ReparerD3MappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.ReparerD3, ReparerD3Dto>()
                .ForMember(dest => dest.ReparerEdition, opt => opt.MapFrom(src => src.Réparer_Edition))
                .ForMember(dest => dest.ReparerDefinitionDesFlux, opt => opt.MapFrom(src => src.Réparer_Définition_Des_Flux))
                .ForMember(dest => dest.ReparerDefinitionDuPoint, opt => opt.MapFrom(src => src.Réparer_Définition_Du_Point))
                .ForMember(dest => dest.ReparerFormation, opt => opt.MapFrom(src => src.Réparer_Formation))
                .ForMember(dest => dest.ReparerDeclenchement, opt => opt.MapFrom(src => src.Réparer_Déclenchement));

            CreateMap<CreateReparerD3Dto, PFE_Etudiant_Asteelflash.Domain.Entities.ReparerD3>()
                .ForMember(dest => dest.Réparer_Edition, opt => opt.MapFrom(src => src.ReparerEdition))
                .ForMember(dest => dest.Réparer_Définition_Des_Flux, opt => opt.MapFrom(src => src.ReparerDefinitionDesFlux))
                .ForMember(dest => dest.Réparer_Définition_Du_Point, opt => opt.MapFrom(src => src.ReparerDefinitionDuPoint))
                .ForMember(dest => dest.Réparer_Formation, opt => opt.MapFrom(src => src.ReparerFormation))
                .ForMember(dest => dest.Réparer_Déclenchement, opt => opt.MapFrom(src => src.ReparerDeclenchement));
        }
    }
}
