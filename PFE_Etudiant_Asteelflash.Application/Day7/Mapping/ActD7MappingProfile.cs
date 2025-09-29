using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day7.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day7.Mapping
{
    public class ActD7MappingProfile : Profile
    {
        public ActD7MappingProfile()
        {
            CreateMap<ActD7, ActD7Dto>();
            CreateMap<CreateActD7Dto, ActD7>();
        }
    }
}
