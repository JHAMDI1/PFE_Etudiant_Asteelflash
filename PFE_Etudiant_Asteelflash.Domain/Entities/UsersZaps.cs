using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    // Table de jointure many-to-many entre ApplicationUser et Zap
    public class UsersZaps
    {
        [ForeignKey("User")] public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        [ForeignKey("Zap")] public int ZapId { get; set; }
        public Zap Zap { get; set; }
    }
}
