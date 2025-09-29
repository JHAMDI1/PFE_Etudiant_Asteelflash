using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        
        // L'utilisateur qui reçoit la notification
        public string UserId { get; set; }
        
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        
        // Contenu de la notification
        [Required]
        public string Message { get; set; }
        
        // Type de notification (FNC créée, mise à jour, etc.)
        [Required]
        public string Type { get; set; }
        
        // Lien vers l'élément concerné (ex: ID de la FNC)
        public string Link { get; set; }
        
        // Référence à la FNC associée
        public int? FncId { get; set; }
        
        // Type de la FNC concernée
        public TypeFnc TypeFnc { get; set; }
        
        // Statut de lecture
        public bool IsRead { get; set; }
        
        // Horodatage
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
