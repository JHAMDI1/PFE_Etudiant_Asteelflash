using System;

namespace PFE_Etudiant_Asteelflash.Application.Zap.Dtos
{
    public class ZapFilterDto
    {
        // Pagination supprimée
        public string SearchTerm { get; set; }
        public string SortBy { get; set; }
        public bool SortDescending { get; set; }
    }
}
