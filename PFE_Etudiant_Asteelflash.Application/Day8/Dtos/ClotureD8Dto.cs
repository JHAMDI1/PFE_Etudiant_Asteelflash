using System;

namespace PFE_Etudiant_Asteelflash.Application.Day8.Dtos
{
    public class ClotureD8Dto
    {
        public int Id { get; set; }
        public DateTime DateCloture { get; set; }
        public string ChefEquipeId { get; set; }
        public bool ApprobationChefEquipe { get; set; }
        public string RespZapId { get; set; }
        public bool ApprobationRespZap { get; set; }
        public string QualiteProdId { get; set; }
        public bool ApprobationQualiteProd { get; set; }
        public string RespQualiteId { get; set; }
        public bool ApprobationRespQualite { get; set; }
        public string RespProdId { get; set; }
        public bool ApprobationRespProd { get; set; }
        public int QrqcId { get; set; }
    }
}
