using AutoMapper;
using PFE_Etudiant_Asteelflash.Models.Qrqc;
using PFE_Etudiant_Asteelflash.Application.Qrqc.Dtos;

namespace PFE_Etudiant_Asteelflash.Mapping.Qrqc
{
    public class QrqcUiMappingProfile : Profile
    {
        public QrqcUiMappingProfile()
        {
            // Comme QrqcCreateViewModel dérive de CreateGlobalQrqcDto, il est déjà compatible.
            // Si vous préférez ne pas hériter, vous pouvez définir la correspondance champ par champ ici.
            CreateMap<QrqcCreateViewModel, CreateGlobalQrqcDto>().ReverseMap();
        }
    }
}
