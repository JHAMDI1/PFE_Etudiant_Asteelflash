using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day2.Dtos;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day2.Mapping
{
    public class DescriptionDuProblemeD2MappingProfile : Profile
    {
        public DescriptionDuProblemeD2MappingProfile()
        {
            // Map from creation DTO to entity (handle accent difference)
            CreateMap<CreateDescriptionDuProblemeD2Dto, DescriptionDuProblemeD2>()
                .ForMember(dest => dest.ManiéreDeDetection, opt => opt.MapFrom(src => src.ManiereDeDetection));
            // Map from entity to read DTO
            CreateMap<DescriptionDuProblemeD2, DescriptionDuProblemeD2Dto>();
        }
    }
}
