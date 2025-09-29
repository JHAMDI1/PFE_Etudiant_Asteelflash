using PFE_Etudiant_Asteelflash.Domain.Enums;
using System.Collections.Generic;

namespace PFE_Etudiant_Asteelflash.Application.Zap.Dtos
{
    public class ZapDetailDto
    {
        public int Id { get; set; }
        public zapName Name { get; set; }
        public int nbre_de_lignes { get; set; }
        
        // Lists to hold related entities
        public List<UserDto> Users { get; set; } = new List<UserDto>();
        public List<ZapLigneDto> ZapLignes { get; set; } = new List<ZapLigneDto>();
    }

    // Simple DTOs for related entities
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
    }

    public class ZapLigneDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
