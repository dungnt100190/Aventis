using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS.Lookup.BL.DTO
{
    /// <summary>
    /// Klasse um die Länder im LOVCode zu handeln
    /// </summary>
    public class Land
    {
        #region Constructors

        /// <summary>
        /// Initialierung einen <see cref="Postleitzahl"/> Objekt
        /// </summary>
        public Land()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// BFS Code vom Land
        /// </summary>
        public int? BFSCode
        {
            get;
            set;
        }

        /// <summary>
        /// ID vom Land
        /// </summary>
        public int BaLandID
        {
            get;
            set;
        }

        /// <summary>
        /// Datum bis wen das Land existiert
        /// </summary>
        public DateTime DatumBis
        {
            get;
            set;
        }

        /// <summary>
        /// Datum von wen das Land existiert
        /// </summary>
        public DateTime DatumVon
        {
            get;
            set;
        }

        /// <summary>
        /// 2-stellige ISO Code vom Land
        /// </summary>
        public string Iso2Code
        {
            get;
            set;
        }

        /// <summary>
        /// 3-stellige ISO Code vom Land
        /// </summary>
        public string Iso3Code
        {
            get;
            set;
        }

        /// <summary>
        /// Name vom Land
        /// </summary>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Name vom Land auf Englisch
        /// </summary>
        public string NameEN
        {
            get;
            set;
        }

        /// <summary>
        /// Name vom Land auf Französich
        /// </summary>
        public string NameFR
        {
            get;
            set;
        }

        /// <summary>
        /// Name vom Land auf Italienisch
        /// </summary>
        public string NameIT
        {
            get;
            set;
        }

        /// <summary>
        /// Ländercodes für die Schnittstelle zu SAP
        /// </summary>
        public string SAPCode
        {
            get;
            set;
        }

        #endregion
    }
}