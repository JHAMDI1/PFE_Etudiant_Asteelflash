using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Fnc.Dtos;
using PFE_Etudiant_Asteelflash.Models.Fnc;

// ------------------------------------------------------------
// Profil AutoMapper FncViewModelMappingProfile
// Définit tous les mappings entre les DTOs FNC (couche Application)
// et les ViewModels utilisés par les vues Razor (Index, Details,
// Create/Edit). Permet de centraliser la configuration et de
// réduire le code dans les contrôleurs.
// ------------------------------------------------------------

namespace PFE_Etudiant_Asteelflash.Mapping.Fnc
{
    public class FncViewModelMappingProfile : Profile
    {
        public FncViewModelMappingProfile()
        {
            // DTO -> ViewModel (service -> UI)
            CreateMap<FncListItemDto, FncIndexViewModel>();
            CreateMap<FncDetailDto, FncDetailsViewModel>()
                .ForMember(dest => dest.ZapName, opt => opt.MapFrom(src => src.ZapEmettriceName));
            CreateMap<FncDto, FncEditViewModel>();
            CreateMap<FncDto, FncDeleteViewModel>();
            CreateMap<FncStatisticsDto, FncStatisticsViewModel>()
                .ForMember(dest => dest.FncsByStatus, opt => opt.MapFrom(src => src.CountByStatus))
                .ForMember(dest => dest.FncsByZap, opt => opt.MapFrom(src => src.CountByZap))
                .ForMember(dest => dest.FncsByMonth, opt => opt.MapFrom(src => src.CountByMonth));
                //.ForMember(dest => dest.FncsByTypeDefaut, opt => opt.MapFrom(src => src.CountByTypeDefaut));

            // ViewModel -> DTO (UI -> service)
            CreateMap<FncCreateViewModel, CreateFncDto>()
                .ForMember(dest => dest.ImageUrl_Piece_bonne, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl_Piece_Mauvaise, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl_3, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl_4, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl_5, opt => opt.Ignore()) // Handled separately with file upload
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => "ouvert")); // Définit le statut par défaut
            
            CreateMap<FncEditViewModel, UpdateFncDto>()
                .ForMember(dest => dest.ImageUrl_Piece_bonne, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl_Piece_Mauvaise, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl_3, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl_4, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl_5, opt => opt.Ignore()); // Handled separately with file upload
        }
    }
}
