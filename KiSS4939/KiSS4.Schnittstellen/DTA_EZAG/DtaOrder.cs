using System;
using System.Collections;
using System.IO;

using KiSS4.DB;

namespace KiSS4.Schnittstellen.DTA_EZAG
{
    /// <summary>
    /// DtaOrder is a collection of DTA records.
    /// </summary>
    public sealed class DtaOrder : ReadOnlyCollectionBase, IOrder
    {
        #region Fields

        #region Public Static Fields

        public static readonly string JobTypeDTA = "DTA";

        #endregion

        #region Public Constant/Read-Only Fields

        public int? FbDTAZugangID;
        public readonly string Mandant;
        public readonly DateTime VerarbeitungsDatum;
        public readonly string VertragNr;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly string _clearingNrAuftraggebber;
        private readonly String _datenfileAbsenderIdentifikation;

        #endregion

        #region Private Fields

        private int _fbDTAJournalID;
        private int _recordId = 1;
        private Decimal _total;
        private DtaRecord890 _totalRecord;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DtaOrder"/> class.
        /// </summary>
        /// <param name="zugangId">The DTA zugang ID.</param>
        /// <param name="vertragNr">The vertrag nr.</param>
        /// <param name="datenfileAbsenderIdentifikation">The datenfile absender identifikation.</param>
        /// <param name="verarbeitungsDatum">The verarbeitungs datum.</param>
        /// <param name="clearingNrAuftraggeber">The clearing nr auftraggeber.</param>
        /// <param name="mandant">The mandant.</param>
        public DtaOrder(
            int? zugangId,
            String vertragNr,
            String datenfileAbsenderIdentifikation,
            DateTime verarbeitungsDatum,
            String clearingNrAuftraggeber,
            String mandant)
        {
            FbDTAZugangID = zugangId;
            VertragNr = vertragNr;
            _datenfileAbsenderIdentifikation = datenfileAbsenderIdentifikation;
            VerarbeitungsDatum = verarbeitungsDatum;
            _clearingNrAuftraggebber = clearingNrAuftraggeber;
            Mandant = mandant;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the access id. (aka ZugangsId)
        /// </summary>
        /// <value>The access id.</value>
        public Object AccessId
        {
            get { return FbDTAZugangID; }
        }

        /// <summary>
        /// Identification string of the sender.
        /// </summary>
        public String DatenfileAbsenderIdentifikation
        {
            get
            {
                return _datenfileAbsenderIdentifikation;
            }
        }

        public int FbDTAJournalID
        {
            get { return _fbDTAJournalID; }
            set { _fbDTAJournalID = value; }
        }

        /// <summary>
        /// Gets the type of the job.
        /// </summary>
        /// <value>"DTA" or "EZAG"</value>
        public string JobType
        {
            get { return JobTypeDTA; }
        }

        /// <summary>
        /// Gets the journal id.
        /// </summary>
        /// <value>The journal id.</value>
        public int JournalId
        {
            get { return _fbDTAJournalID; }
            set { _fbDTAJournalID = value; }
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

        public int RecordCount
        {
            get
            {
                return _recordId;
            }
        }

        /// <summary>
        /// Gets the "TotalBetrag".
        /// </summary>
        /// <value>The total amount.</value>
        public Decimal TotalBetrag
        {
            get { return Convert.ToDecimal(_total); }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets an item by index.
        /// </summary>
        public DtaRecord this[int index]
        {
            get
            {
                return (DtaRecord)InnerList[index];
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds the specified dta record.
        /// </summary>
        /// <param name="dta">The dta.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(DtaRecord dta)
        {
            if (dta == null)
            {
                throw new ArgumentNullException("dta");
            }

            InnerList.Add(dta);
            dta.RecordHeader.EingabeSequenznummer = _recordId;

            // --- ReferenzNummer
            dta.Referenznummer = dta.RecordHeader.DatenfileAbsenderIdentifikation + dta.RecordHeader.EingabeSequenznummer;
            dta.RecordHeader.DatenfileAbsenderIdentifikation = DatenfileAbsenderIdentifikation;
            dta.RecordHeader.VerarbeitungsTag = VerarbeitungsDatum;
            dta.RecordHeader.ErstellungsDatum = DateTime.Today;
            dta.RecordHeader.BankClearingNummerAuftragsgeber = _clearingNrAuftraggebber;
            dta.RecordHeader.ZahlungsArt = false;
            dta.RecordHeader.EingabeSequenznummer = _recordId;

            _recordId++;
        }

        public string CreateUniqueDTAFileName(
            string directory)
        {
            string filename = String.Empty;

            for (int i = 1; i < 1000; i++)
            {
                filename = string.Format("{0}DTA_{1}_{2:dd.MM.yyyy}_{3}.{4}",
                    directory,
                    DatenfileAbsenderIdentifikation.Trim(),
                    DateTime.Today,
                    i,
                    DBUtil.GetConfigValue(@"System\Fibu\DTA\FileExtension", "txt"));

                if (!File.Exists(filename))
                {
                    break;
                }
            }

            return filename;
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
        /// Generate the DTA file.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        /// TODO: refactor this to write into a memory stream rather than a file.
        private void GenerateDta(FileInfo fileInfo)
        {
            foreach (DtaRecord dta in this)
            {
                dta.WriteToDTAFile(fileInfo);
                _total = _total + dta.Verguetungsbetrag;
            }

            _totalRecord = new DtaRecord890(DatenfileAbsenderIdentifikation, _total, _recordId);
            _totalRecord.WriteToDTAFile(fileInfo);
        }

        #endregion

        #endregion
    }
}