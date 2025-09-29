using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Zap.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using System.Linq;

namespace PFE_Etudiant_Asteelflash.Application.Zap.Mapping
{
    public class ZapMappingProfile : Profile
    {
        public ZapMappingProfile()
        {
            // Entity to DTO mappings
            CreateMap<Domain.Entities.Zap, ZapDto>();
            CreateMap<Domain.Entities.Zap, ZapListItemDto>();
            CreateMap<Domain.Entities.Zap, ZapDetailDto>()
                .ForMember(dest => dest.Users, opt => opt.MapFrom(src => src.UsersZaps.Select(uz => uz.User)));
            // DTO to Entity mappings
            CreateMap<CreateZapDto, Domain.Entities.Zap>();
            CreateMap<UpdateZapDto, Domain.Entities.Zap>();

            // Additional mappings for related entities
            CreateMap<ApplicationUser, UserDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
