using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Mapping
{
    public class EquipeMappingProfile : Profile
    {
        public EquipeMappingProfile()
        {
            // Mapping pour la création
            CreateMap<CreateEquipeDto, Domain.Entities.Equipe>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Qrqc, opt => opt.Ignore())
                .ForMember(dest => dest.applicationUser, opt => opt.Ignore());

            // Mapping pour la lecture
            CreateMap<Domain.Entities.Equipe, CreateEquipeDto>();
            CreateMap<Domain.Entities.Equipe, EquipeDto>();
        }
    }
}
