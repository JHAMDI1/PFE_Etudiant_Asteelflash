using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day6.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day6.Mapping
{
    public class SuiviD6MappingProfile : Profile
    {
        public SuiviD6MappingProfile()
        {
            CreateMap<SuiviD6, SuiviD6Dto>();
            CreateMap<CreateSuiviD6Dto, SuiviD6>();
        }
    }
}
