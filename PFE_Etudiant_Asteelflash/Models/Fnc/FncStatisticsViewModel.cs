using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Models.Fnc
{
    public class FncStatisticsViewModel
    {
        [Display(Name = "Total des FNCs")]
        public int TotalFncs { get; set; }
        
        [Display(Name = "FNCs en cours")]
        public int OngoingFncs { get; set; }
        
        [Display(Name = "FNCs complétées")]
        public int CompletedFncs { get; set; }
        
        [Display(Name = "FNCs par statut")]
        public Dictionary<string, int> FncsByStatus { get; set; }
        
        [Display(Name = "FNCs par ZAP")]
        public Dictionary<string, int> FncsByZap { get; set; }
        
        [Display(Name = "FNCs par mois")]
        public Dictionary<string, int> FncsByMonth { get; set; }
        
        [Display(Name = "FNCs par type de défaut")]
        public Dictionary<string, int> FncsByTypeDefaut { get; set; }
        
        [Display(Name = "Période de début")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        
        [Display(Name = "Période de fin")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
