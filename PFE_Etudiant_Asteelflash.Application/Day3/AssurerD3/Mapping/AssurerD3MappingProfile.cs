using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.AssurerD3.Mapping
{
    public class AssurerD3MappingProfile : Profile
    {
        public AssurerD3MappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.AssurerD3, AssurerD3Dto>()
                .ForMember(dest => dest.AssurerReunion, opt => opt.MapFrom(src => src.Assurer_Réunion))
                .ForMember(dest => dest.AssurerAudit, opt => opt.MapFrom(src => src.Assurer_Audit));

            CreateMap<CreateAssurerD3Dto, PFE_Etudiant_Asteelflash.Domain.Entities.AssurerD3>()
                .ForMember(dest => dest.Assurer_Réunion, opt => opt.MapFrom(src => src.AssurerReunion))
                .ForMember(dest => dest.Assurer_Audit, opt => opt.MapFrom(src => src.AssurerAudit));
        }
    }
}
