using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Day5.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;

namespace PFE_Etudiant_Asteelflash.Application.Day5.Mapping
{
    public class PlanActionsCorrectivesD5MappingProfile : Profile
    {
        public PlanActionsCorrectivesD5MappingProfile()
        {
            CreateMap<PlanActionsCorrectivesD5, PlanActionsCorrectivesD5Dto>();
            CreateMap<CreatePlanActionsCorrectivesD5Dto, PlanActionsCorrectivesD5>();
        }
    }
}
