using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PFE_Etudiant_Asteelflash.Application.Authentication.Dtos
{
    public class LoginRequestDto
    {
        public string Matricule { get; set; }
        public string Password { get; set; }
    }
}
