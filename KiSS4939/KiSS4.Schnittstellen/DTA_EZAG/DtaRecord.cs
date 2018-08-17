using System;
using System.Globalization;
using System.IO;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Generic DTA Record.
    /// </summary>
    public class DtaRecord : BuchungsRecord
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// Monetary compensation.
        /// </summary>
        private Decimal _verguetungsbetrag;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DtaRecord" /> class.
        /// </summary>
        public DtaRecord()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DtaRecord" /> class.
        /// </summary>
        /// <param name="bankClearingNummerBeguenstigten">The bank clearing nummer beguenstigten.</param>
        /// <param name="zubelastendendesKonto">The zubelastendendes konto.</param>
        /// <param name="verguetungsbetragParam">The verguetungsbetrag param.</param>
        /// <param name="valutaDatum">The valuta datum.</param>
        public DtaRecord(
            string bankClearingNummerBeguenstigten,
            string zubelastendendesKonto,
            Decimal verguetungsbetragParam,
            DateTime valutaDatum)
        {
            RecordHeader = new DtaHeader(bankClearingNummerBeguenstigten);

            // ZubelastendesKonto
            ZubelastendesKonto = zubelastendendesKonto;

            Verguetungsbetrag = verguetungsbetragParam;
            ValutaDatum = valutaDatum;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the 'BankClearingNummerAuftragsgebber' as a string.
        /// </summary>
        /// <remarks>The value is padded at the end with '0' if necessary.</remarks>
        public String BankClearingNummerAuftragsgebberToDTA
        {
            get
            {
                return Utilities.FillBlanks(RecordHeader.BankClearingNummerAuftragsgeber, 7, " ", true);
            }
        }

        /// <summary>
        /// Gets the bit flag 'BearbeitungsFlag' as a string.
        /// </summary>
        public String BearbeitungsFlagToDTA
        {
            get
            {
                return Convert.ToInt32(RecordHeader.BearbeitungsFlag).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Gets the 'DatenfileAbsenderIdentifikation' as a string.
        /// </summary>
        /// <remarks>The value is padded at the end with '0' if necessary.</remarks>
        public String DatenfileAbsenderIdentifikationToDTA
        {
            get
            {
                return Utilities.FillBlanks(RecordHeader.DatenfileAbsenderIdentifikation, 5, "0", true);
            }
        }

        /// <summary>
        /// Gets the 'EingabeSequenznummer' as a string.
        /// </summary>
        /// <remarks>The value is padded at the end with '0' if necessary.</remarks>
        public String EingabeSequenzNummerToDTA
        {
            get
            {
                return Utilities.FillBlanks(RecordHeader.EingabeSequenznummer.ToString(CultureInfo.InvariantCulture), 5, "0", false);
            }
        }

        /// <summary>
        /// Gets the 'ErstellungsDatum' as DTA string.
        /// </summary>
        public String ErstellungsDatumToDTA
        {
            get
            {
                return Utilities.DateTimeToDTAString(RecordHeader.ErstellungsDatum);
            }
        }

        /// <summary>
        /// Gets or sets the record header.
        /// </summary>
        /// <value>The record header.</value>
        public DtaHeader RecordHeader
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the referenznummer.
        /// </summary>
        /// <value>The referenznummer.</value>
        public string Referenznummer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the 'Referenznummer' as a string.
        /// </summary>
        /// <remarks>The value is padded at the end with '0' if necessary.</remarks>
        public String ReferenznummerToDTA
        {
            get
            {
                return DatenfileAbsenderIdentifikationToDTA +
                    Utilities.FillBlanks(RecordHeader.EingabeSequenznummer.ToString(CultureInfo.InvariantCulture), 11, "0", false);
            }
        }

        /// <summary>
        /// Gets the the 'TransaktionsArt' as a string.
        /// </summary>
        /// <value>The transaktions art to DTA.</value>
        public String TransaktionsArtToDTA
        {
            get
            {
                switch (RecordHeader.Transaktionsart)
                {
                    case (TransaktionsArt.GT827Bank):
                    case (TransaktionsArt.GT827Post):
                        return "827";

                    case (TransaktionsArt.GT826):
                        return "826";

                    case (TransaktionsArt.GT890):
                        return "890";

                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Setzt oder liest das Valuta Datum.
        /// </summary>
        /// <value>The valuta datum.</value>
        public DateTime ValutaDatum
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the 'VerarbeitungsTag' as a string.
        /// </summary>
        public DateTime VerarbeitungsTag
        {
            get { return RecordHeader.VerarbeitungsTag; }
        }

        /// <summary>
        /// Gets or sets the verguetungsbetrag.
        /// </summary>
        /// <value>The verguetungsbetrag.</value>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Decimal Verguetungsbetrag
        {
            get
            {
                return _verguetungsbetrag;
            }
            set
            {
                String betrag = value.ToString("0.00", CultureInfo.InvariantCulture);

                if (betrag.Length > 12)
                {
                    throw new ArgumentOutOfRangeException(
                        "Verguetungsbetrag",
                        "Der Betrag (inkl. Komma) ist länger als 12 Stellen.");
                }

                if (betrag.Length <= 3)
                {
                    throw new ArgumentOutOfRangeException(
                        "Verguetungsbetrag",
                        "Der Betrag (inkl. Komma) ist kürzer als 3 Stellen.");
                }

                if ((betrag.IndexOf(".") < betrag.Length - 3) && (betrag.IndexOf(".") != -1))
                {
                    throw new ArgumentOutOfRangeException(
                        "Verguetungsbetrag",
                        "Die Anzahl der Nachkommastellen ist ungültig.");
                }

                _verguetungsbetrag = value;
            }
        }

        /// <summary>
        /// Converts the payable amount to DTA format.
        /// </summary>
        /// <value>The payable amount.</value>
        public String VerguetungsbetragToDTA
        {
            get
            {
                string valuta = string.Empty;
                string currencyCode = "CHF";
                string betrag = string.Empty;

                if (GetType() == typeof(DtaRecord826) || GetType() == typeof(DtaRecord827))
                {
                    valuta = Utilities.FillBlanks("", 6, " ", true);
                    betrag = FormatBetragToDTA();
                    betrag = Utilities.FillBlanks(betrag, 12, " ", true);
                }
                else if (GetType() == typeof(DtaRecord836))
                {
                    valuta = Utilities.DateTimeToDTAString(ValutaDatum);
                    betrag = FormatBetragToDTA();
                    betrag = Utilities.FillBlanks(betrag, 15, " ", true);
                }

                return valuta + currencyCode + betrag;
            }
        }

        /// <summary>
        /// Converts the payment method to DTA.
        /// </summary>
        /// <value>The payment method.</value>
        public String ZahlungsArtToDTA
        {
            get
            {
                return Convert.ToInt32(RecordHeader.ZahlungsArt).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Setzt oder liest das zu belastende Konto.
        /// </summary>
        /// <value>The zubelastendes konto.</value>
        public string ZubelastendesKonto
        {
            get;
            protected set;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Writes to DTA file.
        /// </summary>
        /// <param name="file">The file.</param>
        public virtual void WriteToDTAFile(FileInfo file)
        {
            //do nothing
        }

        #endregion

        #region Private Methods

        private string FormatBetragToDTA()
        {
            string betrag = _verguetungsbetrag.ToString("0.00", CultureInfo.InvariantCulture);
            if ((betrag.IndexOf(".") != -1) && (betrag.IndexOf(".") == betrag.Length - 2))
            {
                betrag += "0";
            }
            else if (betrag.IndexOf(".") == -1)
            {
                betrag += ".00";
            }
            return betrag.Replace(".", ",");
        }

        #endregion

        #endregion
    }
}