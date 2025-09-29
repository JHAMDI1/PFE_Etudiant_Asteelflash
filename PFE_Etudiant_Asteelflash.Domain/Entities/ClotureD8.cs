using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class ClotureD8

    {
        public int id { get; set; }

        public DateTime DateCloture { get; set; }
        public required string ChefEquipeId { get; set; }
        [ForeignKey("ChefEquipeId")]
        public ApplicationUser? ChefEquipe { get; set; }

        public bool ApprobationChefEquipe { get; set; }



        public required string RespZapId { get; set; }
        [ForeignKey("RespZapId")]
        public ApplicationUser? RespZap { get; set; }


        public bool ApprobationRespZap { get; set; }



        public required string QualitéProdId { get; set; }
        [ForeignKey("QualitéProdId")]
        public ApplicationUser? QualitéProd { get; set; }

        public bool ApprobationQualitéProd { get; set; }




        public required string RespQualiteId { get; set; }
        [ForeignKey("RespQualiteId")]
        public ApplicationUser? RespQualite { get; set; }

        public bool ApprobationRespQualite { get; set; }



        public required string RespProdId { get; set; }
        [ForeignKey("RespProdId")]
        public ApplicationUser? RespProd { get; set; }


        public bool ApprobationRespProd { get; set; }


        public required int QrqcId { get; set; }
        [ForeignKey("QrqcId")]
        public Qrqc? Qrqc { get; set; }

    }
}
