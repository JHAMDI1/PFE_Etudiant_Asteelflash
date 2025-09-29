#if false
using System.Collections.Generic;

namespace PFE_Etudiant_Asteelflash.Domain.Entities
{
    // Partial definition added to expose the missing navigation property so that
    // QrqcController can include and use it without compile errors.
    public partial class TriActionImmediateGlobale
    {
        // One-to-one relationship (QuantitéTriéeParJour holds the FK with a unique index)
        public QuantitéTriéeParJour? QuantitéTriéeParJour { get; set; }
    }
}
#endif
