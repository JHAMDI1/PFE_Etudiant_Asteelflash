using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Réclamation.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Réclamation.Mapping
{
    public class ReclamationMappingProfile : Profile
    {
        public ReclamationMappingProfile()
        {
            // Domain -> DTO
            CreateMap<PFE_Etudiant_Asteelflash.Domain.Entities.Réclamation, ReclamationDto>()
                .ForMember(d => d.UserFullName, o => o.MapFrom(s => s.User != null ? $"{s.User.FirstName} {s.User.LastName}" : string.Empty));

            // Create DTO -> Domain
            CreateMap<CreateReclamationDto, PFE_Etudiant_Asteelflash.Domain.Entities.Réclamation>();
        }
    }
}
