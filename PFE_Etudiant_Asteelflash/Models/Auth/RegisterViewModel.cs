using System.ComponentModel.DataAnnotations;
using PFE_Etudiant_Asteelflash.Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace PFE_Etudiant_Asteelflash.Models.Auth
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Le prénom est requis")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le nom est requis")]
        [Display(Name = "Nom")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "L'email est requis")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le numéro de téléphone est requis")]
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le matricule est requis")]
        [Display(Name = "Matricule")]
        public string Matricule { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le genre est requis")]
        [Display(Name = "Genre")]
        public Gender Gender { get; set; }
        
        [Required(ErrorMessage = "La fonction est requise")]
        [Display(Name = "Fonction")]
        public Fonction Fonction { get; set; }
        
        [Required(ErrorMessage = "Veuillez sélectionner au moins une ZAP")]
        [MinLength(1, ErrorMessage = "Veuillez sélectionner au moins une ZAP")] 
        [Display(Name = "ZAP")]
        public List<int> ZapIds { get; set; } = new();
        
        [Required(ErrorMessage = "Le mot de passe est requis")]
        [StringLength(100, ErrorMessage = "Le mot de passe doit contenir au moins {2} caractères.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z\d]).{8,}$", 
            ErrorMessage = "Le mot de passe doit contenir au moins une lettre minuscule, une lettre majuscule, un chiffre et un caractère spécial.")]
        public string Password { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "La confirmation du mot de passe est requise")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas.")]
        public string ConfirmPassword { get; set; } = string.Empty;
        
        // Pour la liste déroulante des ZAP
        // Pour la liste déroulante des ZAP
        public List<SelectListItem>? ZapList { get; set; }

        [Display(Name = "Image de profil")]
        public IFormFile? ProfileImage { get; set; }
    }
}
