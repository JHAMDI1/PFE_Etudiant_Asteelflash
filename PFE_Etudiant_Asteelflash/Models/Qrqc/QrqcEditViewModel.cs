using System.Collections.Generic;
using PFE_Etudiant_Asteelflash.Application.Day3.Equipe.Dtos;

namespace PFE_Etudiant_Asteelflash.Models.Qrqc
{
    public class QrqcEditViewModel
    {
        public int QrqcId { get; set; }

        // Id de la table QuantitéTriéeParJour à mettre à jour
        public int? QuantiteId { get; set; }

        public int? Jour1 { get; set; }
        public int? Jour2 { get; set; }
        public int? Jour3 { get; set; }
        public int? Jour4 { get; set; }
        public int? Jour5 { get; set; }

        public List<EquipeEditViewModel> Equipes { get; set; } = new();
    }

    public class EquipeEditViewModel
    {
        public int Id { get; set; }
        public string MemberName { get; set; }
        public string Fonction { get; set; }
        public bool IsAbsent { get; set; }
    }
}
