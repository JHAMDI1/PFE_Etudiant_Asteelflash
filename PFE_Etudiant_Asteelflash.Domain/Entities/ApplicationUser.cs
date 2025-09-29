using System.ComponentModel.DataAnnotations.Schema;
using PFE_Etudiant_Asteelflash.Domain.Enums;
using PFE_Etudiant_Asteelflash.Domain;
using Microsoft.AspNetCore.Identity;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{

    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Matricule { get; set; }
        public Gender Gender { get; set; }
        public Fonction Fonction { get; set; }
        public string? ProfileImagePath { get; set; }
        // Indique si l'utilisateur est actif (soft delete)
        public bool IsActive { get; set; } = true;

        // Relation many-to-many avec Zap via table de jointure UsersZaps
        public ICollection<UsersZaps> UsersZaps { get; set; } = new List<UsersZaps>();

        public ICollection<Réclamation> Réclamations { get; set; } = new List<Réclamation>();
        public ICollection<Fnc> Fncs { get; set; } = new List<Fnc>();
        // Liée à la propriété Processor de Qrqc
        [InverseProperty("Processor")]
        public ICollection<Qrqc> Qrqcs { get; set; } = new List<Qrqc>();
        public ICollection<ContenirD3> ContenirD3 { get; set; } = new List<ContenirD3>();
        public ICollection<TrierD3> TrierD3 { get; set; } = new List<TrierD3>();
        public ICollection<ReparerD3> ReparerD3 { get; set; } = new List<ReparerD3>();
        public ICollection<AssurerD3> AssurerD3 { get; set; } = new List<AssurerD3>();
        public ICollection<ListeDesActionsD3> ListeDesActionsD3 { get; set; } = new List<ListeDesActionsD3>();
        public ICollection<ClotureD8> ClotureD8 { get; set; } = new List<ClotureD8>();
        public ICollection<Equipe> Equipe { get; set; } = new List<Equipe>();
    }
}
