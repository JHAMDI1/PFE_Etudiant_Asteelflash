using AutoMapper;
using PFE_Etudiant_Asteelflash.Models.Auth;
using PFE_Etudiant_Asteelflash.Application.Authentication.Dtos;
using PFE_Etudiant_Asteelflash.Application.Zap.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

// ------------------------------------------------------------
// Profil AutoMapper AuthMapingProfile
// Centralise les conversions entre :
//   • RegisterViewModel  <-->  RegistrationRequestDto
//   • ZapListItemDto     -->   SelectListItem (pour listes déroulantes)
// L'objectif est de garder les contrôleurs fins en délégant ici
// toute la configuration de mapping.
// ------------------------------------------------------------

namespace PFE_Etudiant_Asteelflash.Mapping
{
    public class AuthMapingProfile : Profile
    {
        public AuthMapingProfile()
        {
            // Mapping de RegisterViewModel vers RegistrationRequestDto (vue -> service)
            CreateMap<RegisterViewModel, RegistrationRequestDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Matricule, opt => opt.MapFrom(src => src.Matricule))
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Fonction, opt => opt.MapFrom(src => src.Fonction))
                .ForMember(dest => dest.ZapIds, opt => opt.MapFrom(src => src.ZapIds))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.ProfileImagePath, opt => opt.Ignore());

            // Mapping inverse (service -> vue)
            CreateMap<RegistrationRequestDto, RegisterViewModel>()
                .ForMember(dest => dest.ConfirmPassword, opt => opt.Ignore())
                .ForMember(dest => dest.ProfileImage, opt => opt.Ignore())
                .ForMember(dest => dest.ZapList, opt => opt.Ignore());

            // Mapping d'un Zap (dto) vers SelectListItem pour alimenter un <select>
            CreateMap<ZapListItemDto, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name.ToString()));
        }
    }
}
