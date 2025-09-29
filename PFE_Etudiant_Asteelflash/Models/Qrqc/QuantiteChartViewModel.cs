using System;

namespace PFE_Etudiant_Asteelflash.Models.Qrqc
{
    /// <summary>
    /// ViewModel utilisé pour afficher un diagramme (Chart.js) représentant
    /// la quantité triée pour chaque jour (J1 → J5) d'un QRQC spécifique.
    /// </summary>
    public class QuantiteChartViewModel
    {
        public int QrqcId { get; set; }

        public int Jour1 { get; set; }
        public int Jour2 { get; set; }
        public int Jour3 { get; set; }
        public int Jour4 { get; set; }
        public int Jour5 { get; set; }

        /// <summary>
        /// Convertit les quantités en tableau pour itération côté vue.
        /// </summary>
        public int[] ToArray() => new[] { Jour1, Jour2, Jour3, Jour4, Jour5 };
    }
}
