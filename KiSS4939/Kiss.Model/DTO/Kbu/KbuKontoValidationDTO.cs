using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Model.DTO.Kbu
{
    /// <summary>
    /// DTO für die Validierung der Kombination
    /// KbuKonto, WshKategorie für eine Position im Monats oder Grundbudget.
    /// </summary>
    public class KbuKontoValidationDTO
    {
        #region Properties

        /// <summary>
        /// DatumBis oder MonatBis der Position.
        /// </summary>
        public DateTime? DatumBis
        {
            get; set;
        }

        /// <summary>
        /// DatumVon oder MonatVon der Position.
        /// </summary>
        public DateTime DatumVon
        {
            get; set;
        }

        /// <summary>
        /// Ob Konto in Grundbudget aktiv sein muss
        /// (WshKontoAttribut).
        /// </summary>
        public bool Grundbudget
        {
            get;
            set;
        }

        /// <summary>
        /// Id des KbuKontos
        /// </summary>
        public int KbuKontoID
        {
            get; set;
        }

        /// <summary>
        /// Ob Konto in LeistungWsh aktiv sein muss.
        /// (WshKontoAttribut)
        /// </summary>
        public bool LeistungWsh
        {
            get;
            set;
        }

        /// <summary>
        /// Ob Konto in WshLeistungStationaer aktiv sein muss.
        /// (WshKontoAttribut)
        /// </summary>
        public bool LeistungWshStationaer
        {
            get;
            set;
        }

        /// <summary>
        /// Ob Konto in Monatsbudget aktiv sein muss.
        /// (WshKontoAttribut).
        /// </summary>
        public bool Monatsbudget
        {
            get;
            set;
        }

        /// <summary>
        /// True wenn für die Position eine Person ausgewählt worden ist.
        /// </summary>
        public bool PersonAusgewaehlt
        {
            get; set;
        }

        /// <summary>
        /// ID der WshKategorie.
        /// </summary>
        public int WshKategorieID
        {
            get; set;
        }

        #endregion
    }
}