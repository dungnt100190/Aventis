using System;
using System.Globalization;
using System.IO;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for Ezag97.
    /// </summary>
    public class Ezag97
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly EzagHeader _header;
        private readonly int _transaktionCount;
        private readonly decimal _transaktionTotal;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Ezag97"/> class.
        /// </summary>
        /// <param name="auftragsnummerParam">The auftragsnummer param.</param>
        /// <param name="faelligkeitsdatumParam">The faelligkeitsdatum param.</param>
        /// <param name="lastKontoNummerParam">The last konto nummer param.</param>
        /// <param name="gebuehrenkontonummerParam">The gebuehrenkontonummer param.</param>
        /// <param name="transaktionsArtValue">The transaktions art value.</param>
        /// <param name="transaktionCountParam">The transaktion count param.</param>
        /// <param name="transaktionTotalParam">The transaktion total param.</param>
        public Ezag97(
            int auftragsnummerParam,
            DateTime faelligkeitsdatumParam,
            string lastKontoNummerParam,
            string gebuehrenkontonummerParam,
            EzagHeader.TransaktionsArt transaktionsArtValue,
            int transaktionCountParam,
            decimal transaktionTotalParam)
        {
            _header = new EzagHeader(
                faelligkeitsdatumParam,
                lastKontoNummerParam,
                gebuehrenkontonummerParam,
                transaktionsArtValue);

            _header.Auftragsnummer = auftragsnummerParam;

            _transaktionTotal = transaktionTotalParam;
            _transaktionCount = transaktionCountParam;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void WriteToUzagFile(StreamWriter sw)
        {
            _header.Transaktionslaufnummer = _transaktionCount + 1;
            _header.WriteHeaderToUzag(sw);

            try
            {
                sw.Write("CHF");
                sw.Write(Utilities.FillBlanks(_transaktionCount.ToString(), 6, "0", false));
                sw.Write(Utilities.FormatDecimalToDTAMoney(_transaktionTotal.ToString(CultureInfo.InvariantCulture), 13));

                //Monnaie 2-15
                sw.Write(Utilities.FillBlanks("", 308, "0", true));
                //Reserve
                sw.Write(Utilities.FillBlanks("", 320, " ", true));
            }
            catch (Exception e)
            {
                throw new PaymentFatalException(e.Message);
            }
        }

        #endregion

        #endregion
    }
}