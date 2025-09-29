using System;
using System.Collections.Generic;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Dtos
{
    /// <summary>
    /// DTO pour les statistiques des FNCs
    /// </summary>
    public class FncStatisticsDto
    {
        // Statistiques globales
        public int TotalFncs { get; set; }
        public int FncsThisMonth { get; set; }
        public int FncsLastMonth { get; set; }
        public double MonthlyChangePercentage { get; set; }
        
        // Statistiques par statut
        public Dictionary<string, int> CountByStatus { get; set; } = new Dictionary<string, int>();
        
        // Statistiques par type
        public Dictionary<string, int> CountByTypeFnc { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> CountByNcImpact { get; set; } = new Dictionary<string, int>();
        
        // Statistiques temporelles
        public Dictionary<string, int> CountByMonth { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> CountByClientName { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> CountByZap { get; set; } = new Dictionary<string, int>();
        
        // Top transmetteurs et processeurs
        public List<UserStatItem> TopTransmitters { get; set; } = new List<UserStatItem>();
        public List<UserStatItem> TopProcessors { get; set; } = new List<UserStatItem>();
    }
    
    public class UserStatItem
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Count { get; set; }
    }
}
