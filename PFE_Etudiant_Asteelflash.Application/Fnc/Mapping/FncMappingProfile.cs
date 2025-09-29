using AutoMapper;
using PFE_Etudiant_Asteelflash.Application.Fnc.Dtos;
using PFE_Etudiant_Asteelflash.Domain.Entities;
using PFE_Etudiant_Asteelflash.Domain.Enums;
using System;
using System.Linq;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Mapping
{
    public class FncMappingProfile : Profile
    {
        public FncMappingProfile()
        {
            // Entity -> DTO Mappings

            // Fnc -> FncDto (base DTO)
            CreateMap<Domain.Entities.Fnc, FncDto>()
                .ForMember(dest => dest.ZapEmettriceName,  opt => opt.MapFrom(src => src.ZapEmettrice  != null ? Enum.GetName(typeof(zapName), src.ZapEmettrice.Name)  : string.Empty))
                .ForMember(dest => dest.ZapReceptriceName, opt => opt.MapFrom(src => src.ZapReceptrice != null ? Enum.GetName(typeof(zapName), src.ZapReceptrice.Name) : string.Empty))
                .ForMember(dest => dest.TransmitterName, opt => opt.MapFrom(src => src.Transmitter != null ? $"{src.Transmitter.FirstName} {src.Transmitter.LastName}" : string.Empty))
                .ForMember(dest => dest.ProcessorName, opt => opt.MapFrom(src => src.Processor != null ? $"{src.Processor.FirstName} {src.Processor.LastName}" : string.Empty))
                .ForMember(dest => dest.ProcessorId, opt => opt.MapFrom(src => src.ProcessorID))
                .ForMember(dest => dest.TransmitterId, opt => opt.MapFrom(src => src.TransmitterID))
                .ForMember(dest => dest.HasQrqc, opt => opt.MapFrom(src => src.Qrqc != null))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.ActionImmediate, opt => opt.MapFrom(src => src.actionImmediate))
                .ForMember(dest => dest.Action_de_reparation, opt => opt.MapFrom(src => src.Action_de_reparation));

            // Fnc -> FncListItemDto (version allégée pour listes)
            CreateMap<Domain.Entities.Fnc, FncListItemDto>()
                .ForMember(dest => dest.Action_de_reparation, opt => opt.MapFrom(src => src.Action_de_reparation))
                .ForMember(dest => dest.ZapEmettriceName,  opt => opt.MapFrom(src => src.ZapEmettrice  != null ? Enum.GetName(typeof(zapName), src.ZapEmettrice.Name)  : string.Empty))
                .ForMember(dest => dest.TransmitterName, opt => opt.MapFrom(src => src.Transmitter != null ? $"{src.Transmitter.FirstName} {src.Transmitter.LastName}" : string.Empty))
                .ForMember(dest => dest.ProcessorName, opt => opt.MapFrom(src => src.Processor != null ? $"{src.Processor.FirstName} {src.Processor.LastName}" : string.Empty));

            // FncDto -> UpdateFncDto
            CreateMap<FncDto, UpdateFncDto>()
                .ForMember(dest => dest.Action_de_reparation, opt => opt.MapFrom(src => src.Action_de_reparation))
                .ForMember(dest => dest.ProcessorID, opt => opt.MapFrom(src => src.ProcessorId))
                .ForMember(dest => dest.TransmitterID, opt => opt.MapFrom(src => src.TransmitterId));

            // Fnc -> FncDetailDto (version détaillée avec relations)
            CreateMap<Domain.Entities.Fnc, FncDetailDto>()
                .ForMember(dest => dest.Action_de_reparation, opt => opt.MapFrom(src => src.Action_de_reparation))
                .ForMember(dest => dest.ZapEmettriceId,    opt => opt.MapFrom(src => src.ZapEmettriceId))
                .ForMember(dest => dest.ZapReceptriceId,   opt => opt.MapFrom(src => src.ZapReceptriceId))
                .ForMember(dest => dest.ZapEmettriceName,  opt => opt.MapFrom(src => src.ZapEmettrice  != null ? Enum.GetName(typeof(zapName), src.ZapEmettrice.Name)  : string.Empty))
                .ForMember(dest => dest.ZapReceptriceName, opt => opt.MapFrom(src => src.ZapReceptrice != null ? Enum.GetName(typeof(zapName), src.ZapReceptrice.Name) : string.Empty))
                .ForMember(dest => dest.TransmitterName, opt => opt.MapFrom(src => src.Transmitter != null ? $"{src.Transmitter.FirstName} {src.Transmitter.LastName}" : string.Empty))
                .ForMember(dest => dest.TransmitterId, opt => opt.MapFrom(src => src.TransmitterID))
                .ForMember(dest => dest.ProcessorName, opt => opt.MapFrom(src => src.Processor != null ? $"{src.Processor.FirstName} {src.Processor.LastName}" : string.Empty))
                .ForMember(dest => dest.ProcessorId, opt => opt.MapFrom(src => src.ProcessorID))
                .ForMember(dest => dest.HasQrqc, opt => opt.MapFrom(src => src.Qrqc != null))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.ActionImmediate, opt => opt.MapFrom(src => src.actionImmediate))
                .ForMember(dest => dest.Qrqc, opt => opt.Ignore())
                .ForMember(dest => dest.Historiques, opt => opt.Ignore());

            // DTO -> Entity Mappings

            // CreateFncDto -> Fnc
            CreateMap<CreateFncDto, Domain.Entities.Fnc>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TransmitterID, opt => opt.MapFrom(src => src.TransmitterID))
                .ForMember(dest => dest.ZapEmettriceId, opt => opt.MapFrom(src => src.ZapEmettriceId))
                .ForMember(dest => dest.ZapReceptriceId, opt => opt.MapFrom(src => src.ZapReceptriceId))
                .ForMember(dest => dest.actionImmediate, opt => opt.MapFrom(src => src.ActionImmediate))
                .ForMember(dest => dest.Action_de_reparation, opt => opt.MapFrom(src => src.Action_de_reparation));

            // UpdateFncDto -> Fnc
            CreateMap<UpdateFncDto, Domain.Entities.Fnc>()
                .ForMember(dest => dest.TransmitterID, opt => opt.MapFrom(src => src.TransmitterID))
                .ForMember(dest => dest.ProcessorID, opt => opt.MapFrom(src => src.ProcessorID))
                .ForMember(dest => dest.ZapEmettriceId, opt => opt.MapFrom(src => src.ZapEmettriceId))
                .ForMember(dest => dest.ZapReceptriceId, opt => opt.MapFrom(src => src.ZapReceptriceId))
                .ForMember(dest => dest.actionImmediate, opt => opt.MapFrom(src => src.ActionImmediate))
                .ForMember(dest => dest.Action_de_reparation, opt => opt.MapFrom(src => src.Action_de_reparation));
        }
    }
}
