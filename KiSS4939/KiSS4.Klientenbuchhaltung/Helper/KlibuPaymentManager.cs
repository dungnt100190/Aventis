using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Schnittstellen;
using KiSS4.Schnittstellen.DTA_EZAG;

namespace KiSS4.Klientenbuchhaltung
{
    /// <summary>
    /// Diese Klasse stellt Funktionen zur Verfügung, um Dateien für den
    /// elektronischen Zahlverkehr zu erstellen.
    /// </summary>
    public class KlibuPaymentManager
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// Das Zahlungskonto welches für die Zahlungen verwendet wird.
        /// Ein real existierendes Konto also!
        /// </summary>
        private KbZahlungskonto _account;

        /// <summary>
        /// Der Zahlungsauftrag für Banken.
        /// </summary>
        private DtaOrder _dtaOrder;

        /// <summary>
        /// Der Zahlungsauftrag für die Post (i.e. Postfinance)
        /// </summary>
        private EzagOrder _ezagOrder;

        /// <summary>
        /// Datum wann die Zahlung ausgeführt werden soll.
        /// Das Datum wird auf einen Werktag gelegt.
        /// </summary>
        private DateTime _faelligkeitsDatum;

        /// <summary>
        /// Der Zahlungsauftrag im ISO 20022 Format.
        /// </summary>
        private Iso20022Order _isoOrder;

        /// <summary>
        /// The query for displaying journal results.
        /// </summary>
        private SqlQuery _qryBuchung;

        /// <summary>
        /// Der Auftraggeber für die Zahlungen.
        /// </summary>
        private SozialDienst _sozialDienst;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KlibuPaymentManager"/> class.
        /// </summary>
        /// <param name="journalQuery">The journal query.</param>
        public KlibuPaymentManager(
            SqlQuery qryBuchung,
            KbZahlungskonto account,
            String aktivKonto,
            DateTime faelligkeitsDatum)
        {
            _qryBuchung = qryBuchung;
            _account = account;
            //this.aktivKonto = aktivKonto;

            if (faelligkeitsDatum < DateTime.Today)
            {
                _faelligkeitsDatum = Utils.GetNextWorkingDay(DateTime.Today);
            }
            else
            {
                _faelligkeitsDatum = Utils.GetNextWorkingDay(faelligkeitsDatum);
            }

            _sozialDienst = new SozialDienst();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Creates the EZAG and DTA files.
        /// </summary>
        /// <param name="queryJournal">The SQL query for journals.</param>
        /// <param name="dateTime"></param>
        /// <param name="sqlLiteral">The SQL literal.</param>
        /// <param name="fileInfo">The FileInfo (for EZAG)</param>
        /// <param name="directory">The directory (for DTA)</param>
        /// <returns></returns>
        public Boolean CreateFiles(
            SqlQuery queryJournal,
            DateTime dateTime,
            Object sqlLiteral,
            FileInfo fileInfo,
            string directory)
        {
            // --- create DTA file
            if (_account.KbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Dta)
            {
                String fileName = _dtaOrder.CreateUniqueDTAFileName(directory);
                fileInfo = new FileInfo(fileName);

                _dtaOrder.GenerateFile(fileInfo);
                System.Diagnostics.Debug.WriteLine("Created DTA Order in : " + fileInfo.FullName);

                // --- Erstelle den Eintrag im Journal (-> JournalID)
                _dtaOrder.JournalId = ErstelleZahlungslaufEintrag(fileInfo, _dtaOrder, _faelligkeitsDatum);

                foreach (BuchungsRecord record in _dtaOrder)
                {
                    ErstelleTransferEintrag(record, _dtaOrder);
                    AktualisiereBuchung(record.BuchungId, 3);
                }
            }
            else if (_account.KbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Ezag)
            {
                // --- Erstelle die EZAG Datei
                _ezagOrder.GenerateFile(fileInfo);

                System.Diagnostics.Debug.WriteLine("Created EZAG in : " + fileInfo.FullName);

                // --- Erstelle den Eintrag im Journal (-> JournalID)
                _ezagOrder.JournalId = ErstelleZahlungslaufEintrag(fileInfo, _ezagOrder, _faelligkeitsDatum);

                foreach (BuchungsRecord record in _ezagOrder)
                {
                    ErstelleTransferEintrag(record, _ezagOrder);
                    AktualisiereBuchung(record.BuchungId, 3);
                }
            }
            else
            {
                //ISO 20022
                if (!string.IsNullOrEmpty(directory))
                {
                    String fileName = _isoOrder.CreateUniqueIso20022FileName(directory);
                    fileInfo = new FileInfo(fileName);
                }

                _isoOrder.GenerateFile(fileInfo);

                System.Diagnostics.Debug.WriteLine("Created ISO 20022 in : " + fileInfo.FullName);

                // --- Erstelle den Eintrag im Journal (-> JournalID)
                _isoOrder.JournalId = ErstelleZahlungslaufEintrag(fileInfo, _isoOrder, _faelligkeitsDatum);

                foreach (CreditTransferTransactionInformation10CH record in _isoOrder.GetPaymentInstructions())
                {
                    ErstelleTransferEintrag(record, _isoOrder);
                    AktualisiereBuchung(record.PmtId.InstrId, 3);
                }
            }

            return true;
        }

        /// <summary>
        /// Erstellt die Zahlungsaufträge für das gewählte Konto. Falls es sich um
        /// ein Postkonto handelt werden EZAG Aufträge erstellt, im Falle einer
        /// Bank werden DTA Aufträge erstellt.
        /// </summary>
        public void CreateOrders()
        {
            if (_account.KbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Ezag)
            {
                _ezagOrder = CreatePostOrders();
            }
            else if (_account.KbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Dta)
            {
                _dtaOrder = CreateBankOrders();
            }
            else
            {
                _isoOrder = CreateIso20022Orders();
            }
        }

        public IDictionary<int, string> GetErrors()
        {
            if (_account.KbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Dta)
            {
                return new Dictionary<int, string>();
            }

            if (_account.KbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Ezag)
            {
                return new Dictionary<int, string>();
            }

            return _isoOrder?.Errors ?? new Dictionary<int, string>();
        }

        /// <summary>
        /// Returns a FileInfo for CreateFiles
        /// </summary>
        /// <param name="fileInfo">The <see cref="FileInfo"/> for Post</param>
        /// <param name="directory">The directory for Bank</param>
        /// <returns>Returns <c>true</c> if a FileInfo or directory could be found.
        /// <c>false</c> if:
        /// a) DTA-Directory is not defined OR
        /// b) SaveFileDialog returns something else than DialogResult.OK</returns>
        public bool GetFileInfo(out FileInfo fileInfo, out string directory)
        {
            fileInfo = null;
            directory = null;

            if (_account.KbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Dta)
            {
                directory = Utilities.GetDirectory(Utilities.KbFinanzInstitutCode.Dta);

                if (String.IsNullOrEmpty(directory))
                {
                    KissMsg.ShowInfo(
                        "CtlKbZahlungsLauf",
                        "DTANichtInKonfig",
                        "Das DTA-Verzeichnis ist noch nicht festgelegt in der Konfiguration!");

                    return false;
                }
            }
            else if (_account.KbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Ezag)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileInfo = new FileInfo(dialog.FileName);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                directory = Utilities.GetDirectory(Utilities.KbFinanzInstitutCode.Iso20022);

                if (String.IsNullOrEmpty(directory))
                {
                    SaveFileDialog dialog = new SaveFileDialog();
                    dialog.Filter = KissMsg.GetMLMessage(
                        "KlibuPaymentManager",
                        "Iso20022FileList",
                        "ISO20022 (*.xml)|*.xml|Alle Dateien (*.*)|*.*");

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        fileInfo = new FileInfo(dialog.FileName);
                        directory = null;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Erstellt den Eintrag in der Transfer Tabelle.
        /// </summary>
        /// <param name="record">The record.</param>
        /// <param name="order">The order.</param>
        private static void ErstelleTransferEintrag(
            BuchungsRecord record,
            IOrder order)
        {
            DBUtil.ExecuteScalarSQL(@"
                INSERT INTO dbo.KbTransfer (KbBuchungID, KbZahlungslaufID, KbTransferStatusCode)
                  VALUES ({0}, {1}, {2});
                SELECT SCOPE_IDENTITY();",
                record.BuchungId,
                order.JournalId,
                2);
        }

        private static void ErstelleTransferEintrag(CreditTransferTransactionInformation10CH record, Iso20022Order order)
        {
            DBUtil.ExecuteScalarSQL(@"
                INSERT INTO dbo.KbTransfer (KbBuchungID, KbZahlungslaufID, KbTransferStatusCode)
                  VALUES ({0}, {1}, {2});
                SELECT SCOPE_IDENTITY();",
                record.PmtId.InstrId,
                order.JournalId,
                2);
        }

        /// <summary>
        /// Inserts the journal into database.
        /// </summary>
        /// <param name="fileInfo">The file info.</param>
        /// <param name="order">The order.</param>
        /// <param name="faelligkeitsDatum">Das fälligkeitsdatum (Feld Bezahlen am auf Maske Zahlungslauf) </param>
        private static Int32 ErstelleZahlungslaufEintrag(
            FileInfo fileInfo,
            IOrder order,
            DateTime faelligkeitsDatum)
        {
            // --- Get the content of the EZAG/DTA file.
            String content;

            using (StreamReader reader = new StreamReader(
                fileInfo.FullName,
                System.Text.Encoding.Default))
            {
                content = reader.ReadToEnd();
            }

            // --- add  a new row in db.
            String result = DBUtil.ExecuteScalarSQL(@"
                INSERT INTO dbo.KbZahlungslauf (FilePath, TotalBetrag, TransferDatum, KbZahlungskontoID, PaymentMessageID, UserId, Transferiert, ZahlungsDaten, FaelligkeitDatum)
                  VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8});
                SELECT SCOPE_IDENTITY();",
                fileInfo.FullName,
                order.TotalBetrag,
                DateTime.Today,
                order.AccessId,
                order.PaymentMessageId,
                Session.User.UserID,
                1,
                content,
                faelligkeitsDatum).ToString();

            Int32 id = Int32.Parse(result);
            return id;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Modifiziert den BuchungsStatus in der Buchung Tabelle.
        /// </summary>
        /// <param name="kbBuchungId">The kb buchung id.</param>
        /// <param name="buchungStatus">The buchung status.</param>
        private void AktualisiereBuchung(
            Int32 kbBuchungId,
            Int32 buchungStatus)
        {
            AktualisiereBuchung(kbBuchungId.ToString(), buchungStatus);
        }

        /// <summary>
        /// Modifiziert den BuchungsStatus in der Buchung Tabelle.
        /// </summary>
        /// <param name="kbBuchungId">The kb buchung id.</param>
        /// <param name="buchungStatus">The buchung status.</param>
        private void AktualisiereBuchung(
            string kbBuchungId,
            int buchungStatus)
        {
            DBUtil.ExecuteScalarSQL(@"
                UPDATE dbo.KbBuchung
                  SET KbBuchungStatusCode = {0}
                WHERE KbBuchungID = {1};",
                buchungStatus,
                kbBuchungId);
        }

        /// <summary>
        /// Erstellt die Zahlungsaufträge für ein Bankkonto.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="KiSS4.Schnittstellen.DTA_EZAG.PaymentFatalException"></exception>
        private DtaOrder CreateBankOrders()
        {
            DtaOrder order = null;

            foreach (DataRow row in
                _qryBuchung.DataTable.Select(
                    "Uebermitteln = 1",      // WHERE
                    "ValutaDatum"))          // ORDER BY
            {
                try
                {
                    if (order == null)
                    {
                        order = new DtaOrder(
                            _account.KbZahlungskontoID, //Bank.BaBankId,
                            _account.VertragNr,
                            _account.VertragNr.PadRight(5).Substring(0, 5),
                            _faelligkeitsDatum,
                            _account.Bank.ClearingNr,
                            "Mandant");
                    }

                    // --- add DTA Records
                    //row["BankKontoNr"] = account.KontoNr;
                    //row["DTAKontoNr"] = account.KontoNr;
                    //row["BankName"] = account.Name;
                    //row["BankStrasse"] = account.Bank.Strasse;
                    //row["BankPlz"] = account.Bank.Plz;
                    //row["BankOrt"] = account.Bank.Ort;

                    Einzahlungsschein einzahlungsscheinCode = Utilities.GetPaymentMethodKlientenbuchhaltung(row[DBO.KbBuchung.EinzahlungsscheinCode]);

                    DtaPaymentInformation paymentInformation = new DtaPaymentInformation(
                        einzahlungsscheinCode,
                        row[DBO.KbBuchung.IBAN],
                        row[DBO.KbBuchung.BankBCN],
                        row[DBO.KbBuchung.Betrag],
                        row[DBO.KbBuchung.BeguenstigtName],
                        row[DBO.KbBuchung.BeguenstigtStrasse],
                        row[DBO.KbBuchung.BeguenstigtHausNr],
                        row[DBO.KbBuchung.BeguenstigtPLZ],
                        row[DBO.KbBuchung.BeguenstigtOrt],
                        row[DBO.KbBuchung.MitteilungZeile1],
                        row[DBO.KbBuchung.MitteilungZeile2],
                        row[DBO.KbBuchung.MitteilungZeile3],
                        row[DBO.KbBuchung.MitteilungZeile4],
                        row[DBO.KbBuchung.PCKontoNr],
                        row[DBO.KbBuchung.BankKontoNr],
                        row[DBO.KbBuchung.KbBuchungID],
                        row[DBO.KbBuchung.SollKtoNr],
                        row[DBO.KbBuchung.HabenKtoNr],
                        row[DBO.KbBuchung.ReferenzNummer],
                        _account.KontoNr,
                        row[DBO.KbBuchung.ValutaDatum]);

                    DtaRecord record = DTARecordFactory.CreateDTARecord(_sozialDienst, paymentInformation, BuchhaltungsTyp.Klientenbuchhaltung);
                    record.ValutaDatum = order.VerarbeitungsDatum;

                    order.Add(record);
                }
                catch (Exception e)
                {
                    Int32 belegNr = Utils.ConvertToInt(row[DBO.KbBuchung.BelegNr]);

                    string belegNrWithErrorMessage = belegNr + Environment.NewLine + e.Message;

                    throw new PaymentFatalException(KissMsg.GetMLMessage("KlibuPaymentManager", "FehlerInBuchung", "Fehler: Buchung mit BelegNr: {0}", belegNrWithErrorMessage),
                        e,
                        belegNr);
                }
            }

            return order;
        }

        /// <summary>
        /// Erstellt die Zahlungsaufträge für ein Bankkonto.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="KiSS4.Schnittstellen.DTA_EZAG.PaymentFatalException"></exception>
        private Iso20022Order CreateIso20022Orders()
        {
            Iso20022Order order = null;
            PaymentInstructionInformation3CH paymentInstruction = null;

            foreach (DataRow row in
                _qryBuchung.DataTable.Select(
                    "Uebermitteln = 1",      // WHERE
                    "ValutaDatum"))          // ORDER BY
            {
                try
                {
                    if (order == null)
                    {
                        order = new Iso20022Order(
                            _account.VertragNr,
                            _account.KbZahlungskontoID.ToString(),
                            _faelligkeitsDatum);

                        paymentInstruction = order.GetOrCreatePaymentInstruction(_account.KontoNr, _account.Bank.ClearingNr);
                    }

                    Einzahlungsschein einzahlungsscheinCode = Utilities.GetPaymentMethodKlientenbuchhaltung(row[DBO.KbBuchung.EinzahlungsscheinCode]);

                    Iso20022PaymentInformation paymentInformation = new Iso20022PaymentInformation(
                        einzahlungsscheinCode,
                        row[DBO.KbBuchung.IBAN],
                        row[DBO.KbBuchung.BankBCN],
                        row["BankName"],
                        row[DBO.KbBuchung.Betrag],
                        row[DBO.KbBuchung.BeguenstigtName],
                        row[DBO.KbBuchung.BeguenstigtStrasse],
                        row[DBO.KbBuchung.BeguenstigtHausNr],
                        row[DBO.KbBuchung.BeguenstigtPLZ],
                        row[DBO.KbBuchung.BeguenstigtOrt],
                        row[DBO.KbBuchung.MitteilungZeile1],
                        row[DBO.KbBuchung.MitteilungZeile2],
                        row[DBO.KbBuchung.MitteilungZeile3],
                        row[DBO.KbBuchung.MitteilungZeile4],
                        row[DBO.KbBuchung.PCKontoNr],
                        row[DBO.KbBuchung.BankKontoNr],
                        row[DBO.KbBuchung.KbBuchungID],
                        row[DBO.KbBuchung.ReferenzNummer],
                        _account.KontoNr,
                        row[DBO.KbBuchung.ValutaDatum]);

                    var record = Iso20022RecordFactory.CreateTransferTransactionRecord(_sozialDienst, paymentInformation, BuchhaltungsTyp.Klientenbuchhaltung);

                    order.Add(paymentInstruction, record);
                }
                catch (Exception e)
                {
                    var belegNr = Utils.ConvertToInt(row[DBO.KbBuchung.BelegNr]);
                    if (order != null)
                    {
                        order.Errors.Add(belegNr, e.Message);
                    }
                    else
                    {
                        var belegNrWithErrorMessage = belegNr + Environment.NewLine + e.Message;

                        throw new PaymentFatalException(KissMsg.GetMLMessage("KlibuPaymentManager", "FehlerInBuchung", "Fehler: Buchung mit BelegNr: {0}", belegNrWithErrorMessage),
                            e,
                            belegNr);
                    }
                }
            }

            return order;
        }

        /// <summary>
        /// Erstellt die Zahlungsaufträge für ein Postkonto.
        /// </summary>
        private EzagOrder CreatePostOrders()
        {
            EzagOrder order = null;

            foreach (DataRow row in
                _qryBuchung.DataTable.Select(
                    "Uebermitteln = 1",      // WHERE
                    "ValutaDatum"))          // ORDER BY
            {
                try
                {
                    if (order == null)
                    {
                        // --- Generate An OrderID (Must be unique per faelligkeitsDatum)
                        int orderId = GenerateOrderId(_faelligkeitsDatum);

                        // --- Create an EZAG order.
                        order = new EzagOrder(
                            _account.KbZahlungskontoID,
                            orderId,
                            _faelligkeitsDatum,
                            _account.KontoNr,
                            _account.KontoNr);
                    }

                    Einzahlungsschein einzahlungsscheinCode = Utilities.GetPaymentMethodKlientenbuchhaltung(row[DBO.KbBuchung.EinzahlungsscheinCode]);
                    EzagPaymentInformation paymentInformation = new EzagPaymentInformation(
                        einzahlungsscheinCode,
                        row[DBO.KbBuchung.IBAN],
                        row[DBO.KbBuchung.BankBCN],
                        row[DBO.KbBuchung.BankName],
                        row[DBO.KbBuchung.BankStrasse],
                        row[DBO.KbBuchung.BankPLZ],
                        row[DBO.KbBuchung.BankOrt],
                        row[DBO.KbBuchung.Betrag],
                        row[DBO.KbBuchung.BeguenstigtName],
                        row[DBO.KbBuchung.BeguenstigtName2],
                        "",
                        row[DBO.KbBuchung.BeguenstigtStrasse],
                        row[DBO.KbBuchung.BeguenstigtHausNr],
                        row[DBO.KbBuchung.BeguenstigtPLZ],
                        row[DBO.KbBuchung.BeguenstigtOrt],
                        row[DBO.KbBuchung.MitteilungZeile1],
                        row[DBO.KbBuchung.MitteilungZeile2],
                        row[DBO.KbBuchung.MitteilungZeile3],
                        row[DBO.KbBuchung.MitteilungZeile4],
                        row[DBO.KbBuchung.PCKontoNr],
                        row[DBO.KbBuchung.BankKontoNr],
                        row[DBO.KbBuchung.KbBuchungID],
                        row[DBO.KbBuchung.SollKtoNr],
                        row[DBO.KbBuchung.HabenKtoNr],
                        row[DBO.KbBuchung.ReferenzNummer]);

                    EzagRecord record = EzagRecordFactory.CreateEzagRecord(_sozialDienst, paymentInformation, BuchhaltungsTyp.Klientenbuchhaltung);

                    order.Add(record);
                }
                catch (Exception e)
                {
                    Int32 belegNr = Utils.ConvertToInt(row[DBO.KbBuchung.BelegNr]);

                    string belegNrWithErrorMessage = belegNr + Environment.NewLine + e.Message;

                    throw new PaymentFatalException(KissMsg.GetMLMessage("KlibuPaymentManager", "FehlerInBuchung", "Fehler: Buchung mit BelegNr: {0}", belegNrWithErrorMessage),
                        e,
                        belegNr);
                }
            }

            return order;
        }

        /// <summary>
        /// Generiert eine OrderID (Abrechnungsnummer) für Abrechnungen der Post.
        /// </summary>
        /// <param name="valutaDatum">The valuta datum.</param>
        /// <returns>0 on error.</returns>
        private Int32 GenerateOrderId(DateTime valutaDatum)
        {
            Object obj = DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(DISTINCT KBZ.KbZahlungslaufID) + 1
                FROM  KbZahlungslauf      KBZ
                  INNER JOIN KbTransfer   TRA  ON TRA.KbZahlungslaufID = KBZ.KbZahlungslaufID
                  INNER JOIN KbBuchung    BUC  ON BUC.KbBuchungID = TRA.KbBuchungID
                WHERE KBZ.KbZahlungslaufID = {0}
                  AND dbo.fnDateOf(BUC.ValutaDatum) = dbo.fnDateOf({1})",
                _account.KbZahlungskontoID,
                valutaDatum);

            Int32 orderId = Utils.ConvertToInt(obj);
            return orderId;
        }

        #endregion

        #endregion

        #region Other

        //private String aktivKonto;

        #endregion
    }
}