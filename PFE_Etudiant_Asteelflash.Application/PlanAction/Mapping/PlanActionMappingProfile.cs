using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.PlanAction.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.PlanAction.Mapping
{
    /// <summary>
    /// AutoMapper profile pour l'entité Plan d'action FNC/QRQC.
    /// </summary>
    public class PlanActionMappingProfile : Profile
    {
        public PlanActionMappingProfile()
        {
            CreateMap<PlanActionFncQrqc, PlanActionFncQrqcDto>();
            CreateMap<PlanActionFncQrqcLigne, PlanActionFncQrqcLigneDto>();
            CreateMap<PlanActionFncQrqcDto, PlanActionFncQrqc>();
            CreateMap<PlanActionFncQrqcLigneDto, PlanActionFncQrqcLigne>();
        }
    }
}
