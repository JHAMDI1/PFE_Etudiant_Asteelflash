using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.QuantitéTriéeParJour.Mapping
{
    public class QuantitéTriéeParJourMappingProfile : Profile
    {
        public QuantitéTriéeParJourMappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.QuantitéTriéeParJour, QuantitéTriéeParJourDto>()
                .ForMember(dest => dest.TriActionImmediateGlobaleId, opt => opt.MapFrom(src => src.TriActionImmédiateGlobaleId));

            CreateMap<CreateQuantitéTriéeParJourDto, PFE_Etudiant_Asteelflash.Domain.Entities.QuantitéTriéeParJour>()
                .ForMember(dest => dest.TriActionImmédiateGlobaleId, opt => opt.MapFrom(src => src.TriActionImmediateGlobaleId));
        }
    }
}
