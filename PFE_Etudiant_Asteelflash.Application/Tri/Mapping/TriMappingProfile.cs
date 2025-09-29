using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Tri.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Tri.Mapping
{
    /// <summary>
    /// AutoMapper profile pour l'entité Suivi de tri.
    /// </summary>
    public class TriMappingProfile : Profile
    {
        public TriMappingProfile()
        {
            CreateMap<TriFncQrqc, TriFncQrqcDto>()
                .ForMember(dest => dest.PiloteName,
                           opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.PiloteName)
                               ? src.PiloteName
                               : (src.Pilote != null ? src.Pilote.FirstName + " " + src.Pilote.LastName : null)));

            CreateMap<TriFncQrqcLigne, TriFncQrqcLigneDto>();
            // Reverse map pour Create/Edit si besoin
            CreateMap<TriFncQrqcDto, TriFncQrqc>();
            CreateMap<TriFncQrqcLigneDto, TriFncQrqcLigne>();
        }
    }
}
