using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day8.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day8.Mapping
{
    public class ClotureD8MappingProfile : Profile
    {
        public ClotureD8MappingProfile()
        {
            CreateMap<ClotureD8, ClotureD8Dto>();
            CreateMap<CreateClotureD8Dto, ClotureD8>();
        }
    }
}
