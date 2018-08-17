namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Abstrakte Basisklasse für EZAG und DTA Records. Dient zum Speichern
    /// von buchungsrelevanten Daten.
    /// </summary>
    public class BuchungsRecord
    {
        #region Constructors

        public BuchungsRecord()
        {
            ErrorMessage = "";
        }

        #endregion

        #region Properties

        /// <summary>
        /// Liest oder setzt den Betrag.
        /// </summary>
        public decimal Betrag
        {
            get; set;
        }

        /// <summary>
        /// Liest oder setzt die BuchungsId.
        /// </summary>
        /// <value>Die BuchungsId.</value>
        public int BuchungId
        {
            get; set;
        }

        /// <summary>
        /// Liest oder settz die ErrorMessage.
        /// </summary>
        public string ErrorMessage
        {
            get; protected set;
        }

        /// <summary>
        /// Liest oder setzt die HABEN-Kontonummer.
        /// </summary>
        public string HabenKtoNr
        {
            get; set;
        }

        /// <summary>
        /// Liest oder setzt die SOLL-Kontonummer.
        /// </summary>
        public string SollKtoNr
        {
            get; set;
        }

        #endregion
    }
}