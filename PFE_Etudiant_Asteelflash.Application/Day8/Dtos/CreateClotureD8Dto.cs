using System;
using System.ComponentModel.DataAnnotations;

namespace PFE_Etudiant_Asteelflash.Application.Day8.Dtos
{
    public class CreateClotureD8Dto
    {
        [Required]
        public DateTime DateCloture { get; set; }
        [Required]
        public string ChefEquipeId { get; set; }
        public bool ApprobationChefEquipe { get; set; }
        [Required]
        public string RespZapId { get; set; }
        public bool ApprobationRespZap { get; set; }
        [Required]
        public string QualiteProdId { get; set; }
        public bool ApprobationQualiteProd { get; set; }
        [Required]
        public string RespQualiteId { get; set; }
        public bool ApprobationRespQualite { get; set; }
        [Required]
        public string RespProdId { get; set; }
        public bool ApprobationRespProd { get; set; }
        [Required]
        public int QrqcId { get; set; }
    }
}
