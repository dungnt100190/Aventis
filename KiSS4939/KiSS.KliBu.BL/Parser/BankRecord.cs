namespace KiSS.KliBu.BL.Parser
{
    /// <summary>
    /// Class containing the position of each <see cref="Record"/> in a bank record
    /// bank record definition: <see cref="http://www.six-interbank-clearing.com/de/dl_tkicch_bcbankenstamm.pdf"/>
    /// </summary>
    internal static class BankRecord
    {
        // Do NOT use NArrange !!!
        #region Static Fields

        /// <summary>
        /// Bankengruppe
        /// </summary>
        public static Record Gruppe = new Record(0, 2);

        /// <summary>
        /// Clearing Nummer
        /// </summary>
        public static Record ClearingNr = new Record(Gruppe.StartPosition + Gruppe.Length, 5);

        /// <summary>
        /// Filiale Nummer
        /// </summary>
        public static Record FilialeNr = new Record(ClearingNr.StartPosition + ClearingNr.Length, 4);

        /// <summary>
        /// Neue Clearing Nummer
        /// </summary>
        public static Record ClearingNr_NEU = new Record(FilialeNr.StartPosition + FilialeNr.Length, 5);

        /// <summary>
        /// SIC definierte Nummer
        /// </summary>
        public static Record SicNr = new Record(ClearingNr_NEU.StartPosition + ClearingNr_NEU.Length, 6);

        /// <summary>
        /// Clearing Nummer vom Hauptsitz
        /// </summary>
        public static Record HauptsitzBCL = new Record(SicNr.StartPosition + SicNr.Length, 5);

        /// <summary>
        /// Art von der Clearing Nummer
        /// 1 = Hauptsitz
        /// 2 = Kopfstelle
        /// 3 = Filiale
        /// </summary>
        public static Record BcArt = new Record(HauptsitzBCL.StartPosition + HauptsitzBCL.Length, 1);

        /// <summary>
        /// Datum seit welchem die Bank gültig ist
        /// </summary>
        public static Record GueltigAb = new Record(BcArt.StartPosition + BcArt.Length, 8);

        /// <summary>
        /// Teilnahmecode für CHF an SIC
        /// </summary>
        public static Record TeilnahmecodeCHF = new Record(GueltigAb.StartPosition + GueltigAb.Length, 1);

        /// <summary>
        /// Teilnahmecode für Euro an SIC
        /// </summary>
        public static Record TeilnahmecodeEuro = new Record(TeilnahmecodeCHF.StartPosition + TeilnahmecodeCHF.Length, 1);

        /// <summary>
        /// Sprachcode
        /// </summary>
        public static Record Sprachcode = new Record(TeilnahmecodeEuro.StartPosition + TeilnahmecodeEuro.Length, 1);

        /// <summary>
        /// Kurzbezeichnung der Bank
        /// </summary>
        public static Record Kurzbezeichnung = new Record(Sprachcode.StartPosition + Sprachcode.Length, 15);

        /// <summary>
        /// Name der Bank
        /// </summary>
        public static Record Name = new Record(Kurzbezeichnung.StartPosition + Kurzbezeichnung.Length, 60);

        /// <summary>
        /// Strasse
        /// </summary>
        public static Record Strasse = new Record(Name.StartPosition + Name.Length, 35);

        /// <summary>
        /// Postiche Adresse
        /// </summary>
        public static Record Postadresse = new Record(Strasse.StartPosition + Strasse.Length, 35);

        /// <summary>
        /// Postleitzahl
        /// </summary>
        public static Record PLZ = new Record(Postadresse.StartPosition + Postadresse.Length, 10);

        /// <summary>
        /// Ort
        /// </summary>
        public static Record Ort = new Record(PLZ.StartPosition + PLZ.Length, 35);

        /// <summary>
        /// Telefonnummer
        /// </summary>
        public static Record Telefon = new Record(Ort.StartPosition + Ort.Length, 18);

        /// <summary>
        /// Faxnummer
        /// </summary>
        public static Record Fax = new Record(Telefon.StartPosition + Telefon.Length, 18);

        /// <summary>
        /// Internationale Vorwahl für Telefon und Fax
        /// </summary>
        public static Record LandesVorwahl = new Record(Fax.StartPosition + Fax.Length, 5);

        /// <summary>
        /// alphabetischer Landcode
        /// </summary>
        public static Record Landcode = new Record(LandesVorwahl.StartPosition + LandesVorwahl.Length, 2);

        /// <summary>
        /// Postkonto-Nummer
        /// </summary>
        public static Record PCKontoNr = new Record(Landcode.StartPosition + Landcode.Length, 12);

        /// <summary>
        /// Swift-Adresse
        /// </summary>
        public static Record SwiftAdresse = new Record(PCKontoNr.StartPosition + PCKontoNr.Length, 14);

        #endregion

        #region Constructors

        // length for a bank record line including \r\n
        /// <summary>
        /// Länge von einen <see cref="BankRecord"/>, mit die \r\n Charakter
        /// </summary>
        public static int Length = SwiftAdresse.StartPosition + SwiftAdresse.Length + 2;

        #endregion
    }
}