using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    // Partial class adding navigation towards QuantitéTriéeParJour.
    // This ensures compile-time access from controllers and EF Include chains.
    public partial class TriActionImmediateGlobale
    {
        // Propriété de compatibilité conservant l'ancien nom pour les migrations existantes.
        [NotMapped]
        [Obsolete("Utilisez QuantitéTriéeParJour", false)]
        public QuantitéTriéeParJour? QuantitéTriéesParJours
        {
            get => QuantitéTriéeParJour;
            set => QuantitéTriéeParJour = value;
        }
    }
}
