using System;
using System.Collections;
using System.IO;
using System.Text;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// Summary description for EzagOrder.
    /// </summary>
    public class EzagOrder : ReadOnlyCollectionBase, IOrder
    {
        #region Fields

        #region Public Static Fields

        public static readonly string JobTypeEzag = "EZAG";

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly int _fbDTAZugangId;

        /// <summary>
        /// The EZAG Header.
        /// </summary>
        private readonly EzagHeader _header;

        #endregion

        #region Private Fields

        private int _auftragsnummer;
        private decimal _total;

        /// <summary>
        /// The record containing the total.
        /// </summary>
        private Ezag97 _totalRecord;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EzagOrder"/> class.
        /// </summary>
        /// <param name="zahlungskontoId">Die ID des Zahlungskontos.</param>
        /// <param name="auftragsnummer">Die Auftragsnummer.</param>
        /// <param name="faelligkeitsDatum">Datum wenn Zahlung fällig ist.</param>
        /// <param name="letzteKontoNummer">Die zu letzt verwendete Kontonummer.</param>
        /// <param name="gebuehrenKontoNummer">The gebuehrenkontonummer param value.</param>
        public EzagOrder(
            Int32 zahlungskontoId,
            Int32 auftragsnummer,
            DateTime faelligkeitsDatum,
            String letzteKontoNummer,
            String gebuehrenKontoNummer)
        {
            _fbDTAZugangId = zahlungskontoId;
            Auftragsnummer = auftragsnummer;
            _header = new EzagHeader(
                faelligkeitsDatum,
                letzteKontoNummer,
                gebuehrenKontoNummer,
                EzagHeader.TransaktionsArt.Control00);
            _header.Auftragsnummer = Auftragsnummer;
            _header.Transaktionslaufnummer = 0;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the access id. (aka ZugangsId)
        /// </summary>
        /// <value></value>
        public Object AccessId
        {
            get { return FbDTAZugangId; }
        }

        /// <summary>
        /// Gets or sets the Auftragsnummer.
        /// </summary>
        /// <value>The auftragsnummer.</value>
        /// <remarks>Valid range: [1..99]</remarks>
        public int Auftragsnummer
        {
            get { return _auftragsnummer; }
            set
            {
                if (value > 99)
                {
                    throw new Exception("Auftragsnummer muss zwischen 01 und 99 sein");
                }
                _auftragsnummer = value;
            }
        }

        /// <summary>
        /// Gets or sets the FbDTAJournalId.
        /// </summary>
        /// <value>.</value>
        public int FbDTAJournalId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the FbDTAZugangId.
        /// </summary>
        /// <value></value>
        public int FbDTAZugangId
        {
            get { return _fbDTAZugangId; }
        }

        /// <summary>
        /// Liefert "EZAG" als Job-Typ.
        /// </summary>
        /// <value>"DTA", "EZAG" or "ISO 20022"</value>
        public string JobType
        {
            get { return JobTypeEzag; }
        }

        /// <summary>
        /// Gets the journal id.
        /// </summary>
        /// <value></value>
        public int JournalId
        {
            get { return FbDTAJournalId; }
            set { FbDTAJournalId = value; }
        }

        /// <summary>
        /// Gets the "PaymentMessageID", an ID used to identify a payment in the ISO 20022 format.
        /// </summary>
        /// <value>The payment message id.</value>
        public string PaymentMessageId
        {
            get
            {
                //wird nur in ISO 20022 Format verwendet/unterstützt.
                return null;
            }
        }

        /// <summary>
        /// Gets the TotalBetrag.
        /// </summary>
        /// <value>The total betrag.</value>
        public decimal TotalBetrag
        {
            get { return _total; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds the specified record.
        /// </summary>
        /// <param name="r">The r.</param>
        public void Add(EzagRecord r)
        {
            if (r != null)
            {
                r.Header = new EzagHeader(
                    _header.Faelligskeitsdatum,
                    _header.Lastkontonummer,
                    _header.Gebuehrenkontonummer,
                    r.TransaktionsArt);

                // Transaktionslaufnummer unique, asc, 1st record = 0000001
                r.Header.Transaktionslaufnummer = InnerList.Count + 1;
                r.Header.Auftragsnummer = _auftragsnummer;
                InnerList.Add(r);
            }
            else
            {
                throw new PaymentFatalException("Ezag record null");
            }
        }

        /// <summary>
        /// Generates the appropriate file.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        public void GenerateFile(FileInfo fileInfo)
        {
            GenerateDta(fileInfo);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Generates the DTA file.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        private void GenerateDta(
            FileInfo fileInfo)
        {
            _total = 0;

            var sw = new StreamWriter(
                fileInfo.FullName,
                false,
                Encoding.Default,
                131072);

            _header.WriteHeaderToUzag(sw);

            try
            {
                foreach (EzagRecord r in this)
                {
                    r.WriteToUzagFile(sw);
                    sw.Write(Environment.NewLine);
                    _total = _total + r.Aufgabebetrag;
                }

                _totalRecord = new Ezag97(
                    _auftragsnummer,
                    _header.Faelligskeitsdatum,
                    _header.Lastkontonummer,
                    _header.Gebuehrenkontonummer,
                    EzagHeader.TransaktionsArt.Total97,
                    InnerList.Count,
                    _total);

                _totalRecord.WriteToUzagFile(sw);
                sw.Flush();
            }
            catch (Exception e)
            {
                throw new PaymentFatalException(e.Message);
            }
            finally
            {
                sw.Close();
            }
        }

        #endregion

        #endregion
    }
}