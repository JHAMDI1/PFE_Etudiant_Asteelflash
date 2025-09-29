using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PFE_Etudiant_Asteelflash.Domain.Enums;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    public class Fnc
    {
        [Key]
        public int Id { get; set; }

        public required string Ref { get; set; }

        [Required(ErrorMessage = "La ZAP Emittrice est requise")]
        [Display(Name = "ZAP Emittrice")]
        public int? ZapEmettriceId { get; set; }

        [Required(ErrorMessage = "La ZAP Receptrice est requise")]
        [Display(Name = "ZAP Receptrice")]
        public int? ZapReceptriceId { get; set; }

        // Navigation properties to ZAPs
        [ForeignKey("ZapEmettriceId")]
        [InverseProperty(nameof(Zap.FncsEmettrices))]
        public Zap? ZapEmettrice { get; set; }

        [ForeignKey("ZapReceptriceId")]
        [InverseProperty(nameof(Zap.FncsReceptrices))]
        public Zap? ZapReceptrice { get; set; }


        public required string TransmitterID { get; set; }
        [ForeignKey("TransmitterID")]
        public ApplicationUser? Transmitter { get; set; }


        public string? ProcessorID { get; set; }
        [ForeignKey("ProcessorID")]
        public ApplicationUser? Processor { get; set; }


        public DateTime Date { get; set; }

        public TimeSpan Hour { get; set; }

        public string? Ligne { get; set; }

        public string? Client_name { get; set; }
        public StatusFNC Status { get; set; } = StatusFNC.ouvert;
        public required string Detection_loc { get; set; }

        public int Quantity_NOK { get; set; }

        public required string Description { get; set; }
        public required string Enonce_de_la_reclamaion { get; set; } = string.Empty;
        public required string pour_quoi { get; set; } = string.Empty;
        public bool Approbation_conducteur { get; set; }

        public bool Bilan_de_tri { get; set; }

        public TypeDefaut TypeDefaut { get; set; }

        public string ImageUrl_Piece_bonne { get; set; }
        public string ImageUrl_Piece_Mauvaise { get; set; }
        public string? ImageUrl_3 { get; set; }
        public string? ImageUrl_4 { get; set; }
        public string? ImageUrl_5 { get; set; }
        public TypeFnc TypeFnc { get; set; }
        public NcImpact NcImpact { get; set; }

        public ActionImm actionImmediate { get; set; }
        public Etat Etat { get; set; }
        public int? Quantite_Isoloation_de_lot { get; set; }
        public int? Quantite_Rebut { get; set; }
        public int? Numero_dérogation { get; set; }
        public int? Tri_Ok { get; set; }
        public int? Tri_NOk { get; set; }
        [StringLength(200)]
        public string? Action_de_reparation { get; set; }

        // Fnc a une relation one-to-one avec Qrqc, mais c'est Qrqc qui contient l'ID de Fnc
        public Qrqc? Qrqc { get; set; }

        // Navigation optionnelles vers les autres types de traitements
        public TriFncQrqc? TriFnc { get; set; }
        public PlanActionFncQrqc? PlanActionFnc { get; set; }

        // Indique quel type de traitement a été choisi (QRQC, Tri ou Plan)
        public TypeTraitement? TraitementChoisi { get; set; }
    }
}
