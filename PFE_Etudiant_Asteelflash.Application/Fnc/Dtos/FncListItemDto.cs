using PFE_Etudiant_Asteelflash.Domain.Enums;
using System;

namespace PFE_Etudiant_Asteelflash.Application.Fnc.Dtos
{
    /// <summary>
    /// DTO simplifié pour l'affichage des FNCs dans une liste
    /// </summary>
    public class FncListItemDto
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string Num { get; set; }
        public DateTime Date { get; set; }
        public string Client_name { get; set; }
        public string Status { get; set; }
        public string Detection_loc { get; set; }
        public int Quantity_NOK { get; set; }
        public TypeFnc TypeFnc { get; set; }
        public NcImpact NcImpact { get; set; }
        public string TransmitterName { get; set; }
        public string ProcessorName { get; set; }
        public bool HasQrqc { get; set; }
        public string? ZapEmettriceName  { get; set; }
        public string? ZapReceptriceName { get; set; }

        // Action de réparation
        public string? Action_de_reparation { get; set; }
    }
}
