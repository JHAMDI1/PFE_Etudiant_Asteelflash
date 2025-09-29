using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using DomainCauseOccurenceD4 = PFE_Etudiant_Asteelflash.Domain.Entities.CauseOccurenceD4;

namespace PFE_Etudiant_Asteelflash.Application.Day4.CauseOccurenceD4.Mapping
{
    public class CauseOccurenceD4MappingProfile : Profile
    {
        public CauseOccurenceD4MappingProfile()
        {
            CreateMap<DomainCauseOccurenceD4, CauseOccurenceD4Dto>();
            CreateMap<CreateCauseOccurenceD4Dto, DomainCauseOccurenceD4>();
        }
    }
}
