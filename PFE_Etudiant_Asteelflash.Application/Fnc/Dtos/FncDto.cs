using PFE_Etudiant_Asteelflash.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Dtos
{
    public class FncDto
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Num { get; set; }
        public int ZapId { get; set; }
        public string ZapName { get; set; }
        public int ZapEmettriceId { get; set; }
        public int ZapReceptriceId { get; set; }
        public string ZapEmettriceName  { get; set; }
        public string ZapReceptriceName { get; set; }
        public string TransmitterId { get; set; }
        public string TransmitterName { get; set; }
        public string ProcessorId { get; set; }
        public string ProcessorName { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Hour { get; set; }
        public string Client_name { get; set; }
        public string Status { get; set; }
        public string Detection_loc { get; set; }
        public int Quantity_NOK { get; set; }
        public string Description { get; set; }
        public bool Bilan_de_tri { get; set; }
        public TypeDefaut TypeDefaut { get; set; }
        public string? ImageUrl_Piece_bonne { get; set; }
        public string? ImageUrl_Piece_Mauvaise { get; set; }
        public string? ImageUrl_3 { get; set; }
        public string? ImageUrl_4 { get; set; }
        public string? ImageUrl_5 { get; set; }
        public TypeFnc TypeFnc { get; set; }
        public NcImpact NcImpact { get; set; }
        public ActionImm ActionImmediate { get; set; }
        public bool HasQrqc { get; set; }

        // Action de réparation
        public string? Action_de_reparation { get; set; }
    }
}
