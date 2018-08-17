using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Infrastructure.Constant;

namespace Kiss.Model.DTO.Kbu
{
    /// <summary>
    /// DTO mit den Suchparamentern.
    /// Es geht um die Suche nach KbuKonto im Monats oder Grundbudget.
    /// </summary>
    public class KbuKontoSearchDTO
    {
        #region Properties

        /// <summary>
        /// Datum. Ist meistens Today. Dadurch wird das richtige WshKontoAttribut gewählt.        
        /// </summary>
        public DateTime Datum
        {
            get; set;
        }

        /// <summary>
        /// Ob Konto in Grundbudget aktiv sein muss
        /// (WshKontoAttribut).
        /// </summary>
        public bool Grundbudget
        {
            get; set;
        }

        /// <summary>
        /// Ob Konto in LeistungWsh aktiv sein muss.
        /// (WshKontoAttribut)
        /// </summary>
        public bool LeistungWsh
        {
            get; set;
        }

        /// <summary>
        /// Ob Konto in WshLeistungStationaer aktiv sein muss.
        /// (WshKontoAttribut)
        /// </summary>
        public bool LeistungWshStationaer
        {
            get; set;
        }

        /// <summary>
        /// Ob Konto in Monatsbudget aktiv sein muss.
        /// (WshKontoAttribut).
        /// </summary>
        public bool Monatsbudget
        {
            get; set;
        }

        /// <summary>
        /// Suchbegriff. Kann eine Nummer, ein KontoName oder der * sein.
        /// </summary>
        public string SearchString
        {
            get; set;
        }

        /// <summary>
        /// Die WSH Kategorie (Einname, Ausgabe, Sanktion ...).
        /// </summary>
        public LOVsGenerated.WshKategorie WshKategorie
        {
            get; set;
        }

        /// <summary>
        /// Ob Konto zwingend eine Zulage oder ein GBL-Konto sein muss.
        /// </summary>
        public bool ZulageOderGBL { get; set; }

        #endregion
    }
}