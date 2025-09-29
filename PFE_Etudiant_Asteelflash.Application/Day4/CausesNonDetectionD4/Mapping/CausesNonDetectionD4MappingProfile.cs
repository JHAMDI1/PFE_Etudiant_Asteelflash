using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day4.CausesNonDetectionD4.Mapping
{
    public class CausesNonDetectionD4MappingProfile : Profile
    {
        public CausesNonDetectionD4MappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.CausesNonDetectionD4, CausesNonDetectionD4Dto>();
            CreateMap<CreateCausesNonDetectionD4Dto, PFE_Etudiant_Asteelflash.Domain.Entities.CausesNonDetectionD4>();
        }
    }
}
