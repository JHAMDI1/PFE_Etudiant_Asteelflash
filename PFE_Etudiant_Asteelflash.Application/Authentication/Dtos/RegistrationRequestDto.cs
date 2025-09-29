using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Authentication.Dtos
{
    public class RegistrationRequestDto
    {     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Matricule { get; set; }
        public Gender Gender { get; set; }
        public Fonction Fonction { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<int> ZapIds { get; set; } = new();
        public string? ProfileImagePath { get; set; }
    }
}
