using System;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Application.Day3.ListeDesActionsD3.Dtos
{
    public class ListeDesActionsD3Dto
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public StatusAction StatusAction { get; set; }
        public DateTime DatePrevue { get; set; }
        public DateTime DateReelle { get; set; }
        public string Commentaire { get; set; }
        public string PiloteID { get; set; }
        public int ActionDeSecurisationD3Id { get; set; }
    }
}
