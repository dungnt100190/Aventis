using System;

using KiSS4.DB;
using KiSS4.Schnittstellen.DTA_EZAG;

namespace KiSS4.Schnittstellen
{
    /// <summary>
    /// Implementiert das Business Object für den Sozialdienst.
    /// Die Daten des Sozialdienstes werden in der Konfiguration vom Benutzer
    /// eingetragen.
    /// </summary>
    public class SozialDienst
    {
        #region Properties

        /// <summary>
        /// Liefert die Adresse.
        /// </summary>
        /// <value>The adresse.</value>
        public string Adresse { get; private set; }

        /// <summary>
        /// Liefert den Namen.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Liefert den Ort.
        /// </summary>
        /// <value>The ort.</value>
        public string Ort { get; private set; }

        /// <summary>
        /// Liferet die Postleitzahl.
        /// </summary>
        /// <value>The PLZ.</value>
        public string PLZ { get; private set; }

        #endregion

        #region Costructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SozialDienst"/> class.
        /// Der Sozialdient wird vom Benutzer in der Konfiguration angegeben.
        /// </summary>
        public SozialDienst()
        {
            Name = DBUtil.GetConfigString(@"System\Adresse\Allgemein\Organisation", string.Empty);
            Adresse = DBUtil.GetConfigString(@"System\Adresse\Allgemein\Adresse", string.Empty);
            PLZ = DBUtil.GetConfigString(@"System\Adresse\Allgemein\PLZ", string.Empty);
            Ort = DBUtil.GetConfigString(@"System\Adresse\Allgemein\Ort", string.Empty);
        }

        public SozialDienst(string name, string adresse, string plz, string ort)
        {
            Name = name;
            Adresse = adresse;
            PLZ = plz;
            Ort = ort;
        }

        #endregion

        #region Overrides

        /// <summary>
        /// Returns the fully qualified type name of this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> containing a textual representation of this element.
        /// </returns>
        public override string ToString()
        {
            return String.Format("{0}, {1}, {2} {3}",
                Name,
                Adresse,
                PLZ,
                Ort);
        }

        #endregion
    }
}