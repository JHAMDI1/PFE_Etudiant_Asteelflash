using System;

namespace PFE_Etudiant_Asteelflash.Application.Réclamation.Dtos
{
    public class ReclamationDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
