using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.TriActionImmediateGlobale.Mapping
{
    public class TriActionImmediateGlobaleMappingProfile : Profile
    {
        public TriActionImmediateGlobaleMappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.TriActionImmediateGlobale, TriActionImmediateGlobaleDto>()
                .ForMember(dest => dest.NombrePieceTrie, opt => opt.MapFrom(src => src.NombrePiéceTrié))
                .ForMember(dest => dest.NombrePieceTotale, opt => opt.MapFrom(src => src.NombrePiéceTotale));

            CreateMap<CreateTriActionImmediateGlobaleDto, PFE_Etudiant_Asteelflash.Domain.Entities.TriActionImmediateGlobale>()
                .ForMember(dest => dest.NombrePiéceTrié, opt => opt.MapFrom(src => src.NombrePieceTrie))
                .ForMember(dest => dest.NombrePiéceTotale, opt => opt.MapFrom(src => src.NombrePieceTotale));
        }
    }
}
