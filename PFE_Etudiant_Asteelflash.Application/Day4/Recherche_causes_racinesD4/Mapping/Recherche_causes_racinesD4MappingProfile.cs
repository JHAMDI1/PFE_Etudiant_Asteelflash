using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day4.Recherche_causes_racinesD4.Mapping
{
    public class Recherche_causes_racinesD4MappingProfile : Profile
    {
        public Recherche_causes_racinesD4MappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.Recherche_causes_racinesD4, Recherche_causes_racinesD4Dto>();
            CreateMap<Recherche_causes_racinesD4Dto, PFE_Etudiant_Asteelflash.Domain.Entities.Recherche_causes_racinesD4>();
        }
    }
}
