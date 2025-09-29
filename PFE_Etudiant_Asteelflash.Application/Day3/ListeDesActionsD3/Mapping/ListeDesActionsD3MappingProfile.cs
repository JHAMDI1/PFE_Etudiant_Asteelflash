using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Mapping
{
    public class ListeDesActionsD3MappingProfile : Profile
    {
        public ListeDesActionsD3MappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.ListeDesActionsD3, ListeDesActionsD3Dto>();
            CreateMap<CreateListeDesActionsD3Dto, PFE_Etudiant_Asteelflash.Domain.Entities.ListeDesActionsD3>();
        }
    }
}
