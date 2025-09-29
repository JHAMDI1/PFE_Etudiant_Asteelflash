using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Zap.Dtos
{
    public class ZapDto
    {
        public int Id { get; set; }
        public zapName Name { get; set; }
        public int nbre_de_lignes { get; set; }
    }
}
