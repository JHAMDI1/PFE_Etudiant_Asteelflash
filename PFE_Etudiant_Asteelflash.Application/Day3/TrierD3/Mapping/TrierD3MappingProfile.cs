using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.TrierD3.Mapping
{
    public class TrierD3MappingProfile : Profile
    {
        public TrierD3MappingProfile()
        {
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.TrierD3, TrierD3Dto>()
                .ForMember(dest => dest.TrierEdition, opt => opt.MapFrom(src => src.Trier_Edition))
                .ForMember(dest => dest.TrierFormation, opt => opt.MapFrom(src => src.Trier_Formation))
                .ForMember(dest => dest.TrierDefinition, opt => opt.MapFrom(src => src.Trier_Définition))
                .ForMember(dest => dest.TrierDeclenchement, opt => opt.MapFrom(src => src.Trier_Déclenchement))
                .ForMember(dest => dest.TrierEnCours, opt => opt.MapFrom(src => src.Trier_En_Cours))
                .ForMember(dest => dest.TrierExpedition, opt => opt.MapFrom(src => src.Trier_Expédition));

            CreateMap<CreateTrierD3Dto, PFE_Etudiant_Asteelflash.Domain.Entities.TrierD3>()
                .ForMember(dest => dest.Trier_Edition, opt => opt.MapFrom(src => src.TrierEdition))
                .ForMember(dest => dest.Trier_Formation, opt => opt.MapFrom(src => src.TrierFormation))
                .ForMember(dest => dest.Trier_Définition, opt => opt.MapFrom(src => src.TrierDefinition))
                .ForMember(dest => dest.Trier_Déclenchement, opt => opt.MapFrom(src => src.TrierDeclenchement))
                .ForMember(dest => dest.Trier_En_Cours, opt => opt.MapFrom(src => src.TrierEnCours))
                .ForMember(dest => dest.Trier_Expédition, opt => opt.MapFrom(src => src.TrierExpedition));
        }
    }
}
