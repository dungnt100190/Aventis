using System;

namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class PersonAdressDaten
    {
        /// <summary>
        /// Get/Set Strasse
        /// </summary>
        public string Strasse { get; set; }

        /// <summary>
        /// Get/Set Zusatz
        /// </summary>
        public string Zusatz { get; set; }

        /// <summary>
        /// Get/Set Postfach
        /// </summary>
        public string Postfach { get; set; }

        /// <summary>
        /// Get/Set HausNr
        /// </summary>
        public string HausNr { get; set; }

        /// <summary>
        /// Get/Set Plz
        /// </summary>
        public string Plz { get; set; }

        /// <summary>
        /// Get/Set Ort
        /// </summary>
        public string Ort { get; set; }

        /// <summary>
        /// Get/Set Kanton
        /// </summary>
        public string Kanton { get; set; }

        /// <summary>
        /// Get Land (Newod Wert)
        /// </summary>
        public string Land { get; set; }

        /// <summary>
        /// Get LandCode (KiSSWert)
        /// </summary>
        public int? LandId { get; set; }

        /// <summary>
        /// Get DatumVon
        /// </summary>
        public DateTime? DatumVon { get; set; }

        /// <summary>
        /// Get DatumBis
        /// </summary>
        public DateTime? DatumBis { get; set; }
    }
}
