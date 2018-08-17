using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Schnittstellen;
using KiSS4.Schnittstellen.DTA_EZAG;

namespace KiSS4.Fibu
{
    public class FibuPaymentManager
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Das Ausfuehrungsdatum für EZAG Aufträge. Ist nur gesetzt, wenn qryBuchung EZAG-Daten enthält.
        /// </summary>
        private readonly DateTime _ausfuehrungsDatumEZAG;

        private readonly List<DtaOrder> _dtaOrders = new List<DtaOrder>();
        private readonly List<EzagOrder> _ezagOrders = new List<EzagOrder>();
        private readonly List<Iso20022Order> _isoOrders = new List<Iso20022Order>();

        /// <summary>
        /// The query for displaying journal results.
        /// </summary>
        private readonly SqlQuery _qryBuchung;

        /// <summary>
        /// Der Auftraggeber für die Zahlungen.
        /// </summary>
        private readonly SozialDienst _sozialDienst;

        private bool _setAltesValutaDatumAufTagesDatum;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FibuPaymentManager"/> class.
        /// </summary>
        /// <param name="qryBuchung"></param>
        /// <param name="ausfuehrungsDatumEZAG"></param>
        public FibuPaymentManager(SqlQuery qryBuchung, DateTime ausfuehrungsDatumEZAG)
        {
            _qryBuchung = qryBuchung;
            _ausfuehrungsDatumEZAG = ausfuehrungsDatumEZAG;
            _sozialDienst = new SozialDienst();

            _setAltesValutaDatumAufTagesDatum = DBUtil.GetConfigBool(@"System\Fibu\AltesValutaDatumAufTagesDatumSetzen", false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Die DTA-Zahlungaufträge.
        /// </summary>
        public IList<DtaOrder> DtaOrders
        {
            get { return _dtaOrders; }
        }

        /// <summary>
        /// Die EZAG-Zahlungsaufträge.
        /// </summary>
        public IList<EzagOrder> EzagOrders
        {
            get { return _ezagOrders; }
        }

        /// <summary>
        /// Die DTA-Zahlungaufträge.
        /// </summary>
        public IList<Iso20022Order> Iso20022Orders
        {
            get { return _isoOrders; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool CreateFiles(DateTime dateTime)
        {
            FileInfo fileInfo;

            // Generate Files + Insert Into Database
            foreach (DtaOrder dtaO in _dtaOrders)
            {
                string dtaPath = Convert.ToString(DBUtil.GetConfigValue(@"System\Fibu\DTA\Verzeichnis", ""));

                if (dtaPath == "")
                {
                    throw new KissCancelException(KissMsg.GetMLMessage("CtlFibuDTAZahlungsLauf", "DTANichtInKonfig", "Das DTA-Verzeichnis ist noch nicht festgelegt in der Konfiguration!"));
                }

                if (!dtaPath.EndsWith(@"\"))
                {
                    dtaPath += @"\";
                }

                string filename = dtaO.CreateUniqueDTAFileName(dtaPath);
                fileInfo = new FileInfo(filename);

                dtaO.GenerateFile(fileInfo);

                Console.Write("DtaOrder " + fileInfo.FullName);

                // --- Erstelle den Eintrag im Journal (-> JournalID)
                dtaO.JournalId = ErstelleZahlungslaufEintrag(fileInfo, dtaO);

                foreach (DtaRecord dtaRecord in dtaO)
                {
                    ErstelleTransferEintrag(dtaRecord, dtaO);
                }
            }

            foreach (EzagOrder ezagO in _ezagOrders)
            {
                SaveFileDialog fd = new SaveFileDialog();

                if (fd.ShowDialog() == DialogResult.OK)
                {
                    fileInfo = new FileInfo(fd.FileName);
                }
                else
                {
                    throw new KissCancelException();
                    //Session.Rollback();
                    //this.gridErwartung.Focus();
                    //return;
                }

                ezagO.GenerateFile(fileInfo);

                // --- Erstelle den Eintrag im Journal (-> JournalID)
                ezagO.JournalId = ErstelleZahlungslaufEintrag(fileInfo, ezagO);

                foreach (EzagRecord ezagRecord in ezagO)
                {
                    ErstelleTransferEintrag(ezagRecord, ezagO);
                }
            }

            foreach (Iso20022Order isoO in _isoOrders)
            {
                string isoPath = Convert.ToString(DBUtil.GetConfigValue(@"System\Fibu\ISO20022\Verzeichnis", ""));

                if (isoPath == "")
                {
                    SaveFileDialog fd = new SaveFileDialog();
                    fd.Filter = KissMsg.GetMLMessage(
                        "FibuPaymentManager",
                        "Iso20022FileList",
                        "ISO20022 (*.xml)|*.xml|Alle Dateien (*.*)|*.*");

                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        fileInfo = new FileInfo(fd.FileName);
                    }
                    else
                    {
                        throw new KissCancelException();
                        //Session.Rollback();
                        //this.gridErwartung.Focus();
                        //return;
                    }
                }
                else
                {
                    if (!isoPath.EndsWith(@"\"))
                    {
                        isoPath += @"\";
                    }

                    string filename = isoO.CreateUniqueIso20022FileName(isoPath);
                    fileInfo = new FileInfo(filename);
                }

                isoO.GenerateFile(fileInfo);

                Console.Write("Iso20022 " + fileInfo.FullName);

                // --- Erstelle den Eintrag im Journal (-> JournalID)
                isoO.JournalId = ErstelleZahlungslaufEintrag(fileInfo, isoO);

                foreach (CreditTransferTransactionInformation10CH record in isoO.GetPaymentInstructions())
                {
                    ErstelleTransferEintrag(record, isoO);
                }
            }

            return true;
        }

        public string CreateOrders()
        {
            DateTime tempValutaDatum = DateTime.Today;
            int tempDTABankId = 0;
            string tempVertragNr = "";
            int tempFbDTAZugangId = 0;

            string fehlern = "";

            EzagOrder ezagOrder = null;
            DtaOrder dtaOrder = null;
            Iso20022Order isoOrder = null;
            PaymentInstructionInformation3CH paymentInstruction = null;

            foreach (DataRow row in
                _qryBuchung.DataTable.Select(
                    "Uebermitteln = 1", //WHERE
                    "KbFinanzInstitutCode, DTABankID, FbDTAZugangId, VertragNr, ValutaDatum")) //ORDER BY
            {
                try
                {
                    var tempKbFinanzInstitutCode = Utils.ConvertToInt(row["KbFinanzInstitutCode"]);
                    if (tempKbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Ezag)
                    {
                        #region EZAG, Gruppierung nach FbDTAZugangId, ValutaDatum

                        if (ezagOrder == null || Convert.ToInt32(row["FbDTAZugangId"]) != tempFbDTAZugangId ||
                            _ausfuehrungsDatumEZAG != tempValutaDatum)
                        {
                            tempFbDTAZugangId = Convert.ToInt32(row["FbDTAZugangId"]);
                            tempValutaDatum = Convert.ToDateTime(_ausfuehrungsDatumEZAG);

                            // Generate An OrderID (Must be unique per ValutaDatum)
                            int orderId = GenerateOrderId(tempFbDTAZugangId, tempValutaDatum);

                            ezagOrder = new EzagOrder(tempFbDTAZugangId,
                                orderId + _ezagOrders.Count,
                                _ausfuehrungsDatumEZAG,
                                row["DTAKontoNr"].ToString(),
                                row["DTAKontoNr"].ToString());
                            _ezagOrders.Add(ezagOrder);
                        }

                        // EZAG Records
                        ZahlungsArt zahlungsArtCode = Utilities.GetPaymentMethodMandatsbuchhaltung(row[DBO.viewDTAFbBuchungen.ZahlungsArtCode]);

                        string zahlungsgrund = row[DBO.viewDTAFbBuchungen.Zahlungsgrund].ToString().Replace("\r\n", "\n") + "\n\n\n\n";
                        string[] zgLines = zahlungsgrund.Split('\n');

                        EzagPaymentInformation paymentInformation = new EzagPaymentInformation(zahlungsArtCode,
                            row[DBO.viewDTAFbBuchungen.IBAN], //iban:,
                            row[DBO.viewDTAFbBuchungen.ClearingNr], //bankBcn:,
                            row[DBO.viewDTAFbBuchungen.BankName], //bankName:,
                            row[DBO.viewDTAFbBuchungen.BankStrasse], //bankStrasse:,
                            row[DBO.viewDTAFbBuchungen.BankPLZ], //bankPlz:,
                            row[DBO.viewDTAFbBuchungen.BankOrt], //bankOrt:,
                            row[DBO.viewDTAFbBuchungen.Betrag], //betrag:,
                            row[DBO.viewDTAFbBuchungen.KreditorName], //beguenstigtName:,
                            null, //beguenstigtName2:,
                            row[DBO.viewDTAFbBuchungen.KreditorZusatz],
                            row[DBO.viewDTAFbBuchungen.KreditorStrasse], //beguenstigtStrasse:,
                            null, //beguenstigtHausNr:, (gibt es aktuell nicht, wird in beguenstigtStrasse geliefert)
                            row[DBO.viewDTAFbBuchungen.KreditorPLZ], //beguenstigtPlz:,
                            row[DBO.viewDTAFbBuchungen.KreditorOrt], //beguenstigtOrt:,
                            zgLines[0], //mitteilungZeile1:,
                            zgLines[1], //mitteilungZeile2:,
                            zgLines[2], //mitteilungZeile3:,
                            zgLines[3], //mitteilungZeile4:,
                            row[DBO.viewDTAFbBuchungen.PCKontoNr], //pcKontoNr:,
                            row[DBO.viewDTAFbBuchungen.BankKontoNr], //bankKontoNr:,
                            row[DBO.viewDTAFbBuchungen.FbBuchungID], //kbBuchungID:,
                            null, //sollKtoNr:,
                            row[DBO.viewDTAFbBuchungen.KontoNr], //habenKtoNr:,
                            row[DBO.viewDTAFbBuchungen.Zahlungsgrund] //referenzNummer:
                        );

                        EzagRecord record = EzagRecordFactory.CreateEzagRecord(_sozialDienst, paymentInformation, BuchhaltungsTyp.Mandatsbuchhaltung);

                        ezagOrder.Add(record);

                        #endregion

                        if (record.ErrorMessage != "")
                        {
                            string belegNrWithErrorMessage = row["BelegNr"] + Environment.NewLine + record.ErrorMessage + Environment.NewLine;
                            fehlern += KissMsg.GetMLMessage("FibuPaymentManager", "FehlerInBuchung", "Fehler: Buchung mit BelegNr: {0}", belegNrWithErrorMessage);
                        }
                    }
                    else if (tempKbFinanzInstitutCode == (int)Utilities.KbFinanzInstitutCode.Dta)
                    {
                        #region DTA, Gruppierung nach DTABankID, VertragNr

                        var valutaDatum = Convert.ToDateTime(row["ValutaDatum"]);

                        if (_setAltesValutaDatumAufTagesDatum && valutaDatum < DateTime.Today)
                        {
                            valutaDatum = DateTime.Today;
                        }

                        if (dtaOrder == null || Convert.ToInt32(row["DTABankID"]) != tempDTABankId ||
                            row["VertragNr"].ToString() != tempVertragNr)
                        {
                            tempDTABankId = Convert.ToInt32(row["DTABankID"]);
                            tempVertragNr = row["VertragNr"].ToString();
                            tempFbDTAZugangId = Convert.ToInt32(row["FbDTAZugangId"]);

                            dtaOrder = new DtaOrder(
                                tempFbDTAZugangId,
                                row["VertragNr"].ToString(),
                                row["VertragNr"].ToString().PadRight(5).Substring(0, 5),
                                valutaDatum,
                                row["DTAClearingNr"].ToString(),
                                row["Mandant"].ToString());
                            _dtaOrders.Add(dtaOrder);
                        }
                        else
                        {
                            //hat der DTA-Zugang geändert? (werden mehrere DTA-Zugänge in einem Zahllauf zusammengeführt, damit sie via Mammut auseinander genommen werden können)
                            if (dtaOrder.FbDTAZugangID != Convert.ToInt32(row["FbDTAZugangId"]))
                            {
                                //dann muss dtaOrder.FbDTAZugangID gelöscht werden (da diese ID nicht mehr eindeutig ist)
                                dtaOrder.FbDTAZugangID = null;
                            }
                        }

                        // DTA Records

                        ZahlungsArt zahlungsArtCode = Utilities.GetPaymentMethodMandatsbuchhaltung(row[DBO.viewDTAFbBuchungen.ZahlungsArtCode]);

                        string zahlungsgrund = row[DBO.viewDTAFbBuchungen.Zahlungsgrund].ToString().Replace("\r\n", "\n") + "\n\n\n\n";
                        string[] zgLines = zahlungsgrund.Split('\n');

                        DtaPaymentInformation paymentInformation = new DtaPaymentInformation(zahlungsArtCode,
                            row[DBO.viewDTAFbBuchungen.IBAN], //iban:,
                            row[DBO.viewDTAFbBuchungen.ClearingNr], //bankBcn:,
                            row[DBO.viewDTAFbBuchungen.Betrag], //betrag:,
                            row[DBO.viewDTAFbBuchungen.KreditorName], //beguenstigtName:,
                            row[DBO.viewDTAFbBuchungen.KreditorStrasse], //beguenstigtStrasse:,
                            null, //beguenstigtHausNr:, (gibt es aktuell nicht, wird in beguenstigtStrasse geliefert)
                            row[DBO.viewDTAFbBuchungen.KreditorPLZ], //beguenstigtPlz:,
                            row[DBO.viewDTAFbBuchungen.KreditorOrt], //beguenstigtOrt:,
                            zgLines[0], //mitteilungZeile1:,
                            zgLines[1], //mitteilungZeile2:,
                            zgLines[2], //mitteilungZeile3:,
                            zgLines[3], //mitteilungZeile4:,
                            row[DBO.viewDTAFbBuchungen.PCKontoNr], //pcKontoNr:,
                            row[DBO.viewDTAFbBuchungen.BankKontoNr], //bankKontoNr:,
                            row[DBO.viewDTAFbBuchungen.FbBuchungID], //kbBuchungID:,
                            null, //sollKtoNr:,
                            row[DBO.viewDTAFbBuchungen.KontoNr], //habenKtoNr:,
                            row[DBO.viewDTAFbBuchungen.Zahlungsgrund], //referenzNummer:,
                            row[DBO.viewDTAFbBuchungen.DTAKontoNr], //dtaKontoNr:,
                            valutaDatum //valutaDatum:
                        );

                        DtaRecord record = DTARecordFactory.CreateDTARecord(_sozialDienst, paymentInformation, BuchhaltungsTyp.Mandatsbuchhaltung);

                        dtaOrder.Add(record);

                        // Set Status
                        row["Status"] = 1;

                        #endregion

                        if (record.ErrorMessage != "")
                        {
                            string belegNrWithErrorMessage = row["BelegNr"] + Environment.NewLine + record.ErrorMessage + Environment.NewLine;
                            fehlern += KissMsg.GetMLMessage("FibuPaymentManager", "FehlerInBuchung", "Fehler: Buchung mit BelegNr: {0}", belegNrWithErrorMessage);
                        }
                    }
                    else
                    {
                        //ISO 20022

                        #region ISO 20022, Gruppierung nach DTABankID, VertragNr, ValutaDatum

                        var valutaDatum = Convert.ToDateTime(row["ValutaDatum"]);

                        if (_setAltesValutaDatumAufTagesDatum && valutaDatum < DateTime.Today)
                        {
                            valutaDatum = DateTime.Today;
                        }

                        if (isoOrder == null ||
                            Convert.ToInt32(row["DTABankID"]) != tempDTABankId ||
                            row["VertragNr"].ToString() != tempVertragNr ||
                            valutaDatum != tempValutaDatum)
                        {
                            tempDTABankId = Convert.ToInt32(row["DTABankID"]);
                            tempVertragNr = row["VertragNr"].ToString();
                            tempValutaDatum = valutaDatum;

                            isoOrder = new Iso20022Order(
                                row[DBO.viewDTAFbBuchungen.VertragNr].ToString(),
                                row[DBO.viewDTAFbBuchungen.FbDTAZugangID].ToString(),
                                valutaDatum);

                            _isoOrders.Add(isoOrder);
                        }
                        else
                        {
                            //hat der Zugang geändert? (werden mehrere Zugänge in einem Zahllauf zusammengeführt, damit sie via Mammut auseinander genommen werden können)
                            if (isoOrder.AccessId != row[DBO.viewDTAFbBuchungen.FbDTAZugangID].ToString())
                            {
                                //dann muss isoOrder.AccessId gelöscht werden (da diese ID nicht mehr eindeutig ist)
                                isoOrder.AccessId = null;
                            }
                        }

                        // ISO Records

                        ZahlungsArt zahlungsArtCode = Utilities.GetPaymentMethodMandatsbuchhaltung(row[DBO.viewDTAFbBuchungen.ZahlungsArtCode]);

                        string zahlungsgrund = row[DBO.viewDTAFbBuchungen.Zahlungsgrund].ToString().Replace("\r\n", "\n") + "\n\n\n\n";
                        string[] zgLines = zahlungsgrund.Split('\n');

                        Iso20022PaymentInformation paymentInformation = new Iso20022PaymentInformation(zahlungsArtCode,
                            row[DBO.viewDTAFbBuchungen.IBAN], //iban:,
                            row[DBO.viewDTAFbBuchungen.ClearingNr], //bankBcn:,
                            row[DBO.viewDTAFbBuchungen.BankName], //bankBcn:,
                            row[DBO.viewDTAFbBuchungen.Betrag], //betrag:,
                            row[DBO.viewDTAFbBuchungen.KreditorName], //beguenstigtName:,
                            row[DBO.viewDTAFbBuchungen.KreditorStrasse], //beguenstigtStrasse:,
                            null, //beguenstigtHausNr:, (gibt es aktuell nicht, wird in beguenstigtStrasse geliefert)
                            row[DBO.viewDTAFbBuchungen.KreditorPLZ], //beguenstigtPlz:,
                            row[DBO.viewDTAFbBuchungen.KreditorOrt], //beguenstigtOrt:,
                            zgLines[0], //mitteilungZeile1:,
                            zgLines[1], //mitteilungZeile2:,
                            zgLines[2], //mitteilungZeile3:,
                            zgLines[3], //mitteilungZeile4:,
                            row[DBO.viewDTAFbBuchungen.PCKontoNr], //pcKontoNr:,
                            row[DBO.viewDTAFbBuchungen.BankKontoNr], //bankKontoNr:,
                            row[DBO.viewDTAFbBuchungen.FbBuchungID], //kbBuchungID:,
                            row[DBO.viewDTAFbBuchungen.Zahlungsgrund], //referenzNummer:,
                            row[DBO.viewDTAFbBuchungen.DTAKontoNr], //dtaKontoNr:,
                            valutaDatum //valutaDatum:
                        );

                        try
                        {
                            var record = Iso20022RecordFactory.CreateTransferTransactionRecord(_sozialDienst, paymentInformation, BuchhaltungsTyp.Mandatsbuchhaltung);

                            paymentInstruction = isoOrder.GetOrCreatePaymentInstruction(row[DBO.viewDTAFbBuchungen.DTAKontoNr].ToString(), row["DTAClearingNr"].ToString());

                            isoOrder.Add(paymentInstruction, record);

                            // Set Status
                            row["Status"] = 1;
                        }
                        catch (Exception e)
                        {
                            string belegNrWithErrorMessage = row["BelegNr"] + Environment.NewLine + e.Message + Environment.NewLine;
                            fehlern += KissMsg.GetMLMessage("FibuPaymentManager", "FehlerInBuchung", "Fehler: Buchung mit BelegNr: {0}", belegNrWithErrorMessage);
                        }

                        #endregion
                    }
                }
                catch (Exception g)
                {
                    string belegNrWithErrorMessage = row["BelegNr"] + Environment.NewLine + g.Message;
                    throw new PaymentFatalException(KissMsg.GetMLMessage("FibuPaymentManager", "FehlerInBuchung", "Fehler: Buchung mit BelegNr: {0}", belegNrWithErrorMessage));
                }
            }

            //sicherstellen, dass wir nur vollständige Aufträge haben (wenn ein Auftrag nur fehlerhafte Positionen erhalten hätte, ist der Auftrag leer).
            var emptyOrders = _isoOrders.Where(o => o.RecordCount == 0).ToList();
            foreach (var emptyOrder in emptyOrders)
            {
                _isoOrders.Remove(emptyOrder);
            }

            return fehlern;
        }

        #endregion

        #region Private Methods

        private void ErstelleTransferEintrag(BuchungsRecord record, IOrder order)
        {
            if (order.JobType == EzagOrder.JobTypeEzag)
            {
                // Ezag
                // If we are in Yellownet Mode, we need to udpate all Buchung with userdefined valutaDatum
                DBUtil.ExecSQL("UPDATE FbBuchung SET ValutaDatum = {1}, Modified = GETDATE(), Modifier = {2} WHERE FbBuchungID = {0} OR FbBuchungID_Kopf = {0}",
                    record.BuchungId, _ausfuehrungsDatumEZAG, DBUtil.GetDBRowCreatorModifier()); //dr["FbBuchungID"], dr["ValutaDatum"]);

                DBUtil.ExecSQL(@"INSERT INTO FbDTABuchung (FbBuchungID, FbDTAJournalID, Status)
                                 SELECT FbBuchungID, {1}, {2}
                                 FROM FbBuchung
                                 WHERE FbBuchungID = {0}
                                    OR FbBuchungID_Kopf = {0}",
                    record.BuchungId, order.JournalId, 2); //Uebermittelt         //dr["FbBuchungID"], ezagO.FbDTAJournalId, 2); //Uebermittelt
            }
            else
            {
                // Dta
                // ValutaDatum überschreiben falls es geändert hat
                if (_setAltesValutaDatumAufTagesDatum)
                {
                    var dtaRecord = record as DtaRecord;
                    if (dtaRecord != null)
                    {
                        DBUtil.ExecSQL("UPDATE FbBuchung SET ValutaDatum = {1}, Modified = GETDATE(), Modifier = {2} WHERE (FbBuchungID = {0} OR FbBuchungID_Kopf = {0}) AND ValutaDatum <> {1}",
                            dtaRecord.BuchungId, dtaRecord.ValutaDatum, DBUtil.GetDBRowCreatorModifier());
                    }
                }

                DBUtil.ExecSQL(@"INSERT INTO FbDTABuchung (FbBuchungID, FbDTAJournalID, Status)
                                 SELECT FbBuchungID, {1}, {2}
                                 FROM FbBuchung
                                 WHERE FbBuchungID = {0}
                                    OR FbBuchungID_Kopf = {0}",
                    record.BuchungId, order.JournalId, 2); //Uebermittelt    //dr["FbBuchungID"], dtaO.FbDTAJournalID, 2); //Uebermittelt
            }
        }

        private void ErstelleTransferEintrag(CreditTransferTransactionInformation10CH record, Iso20022Order order)
        {
            // ValutaDatum überschreiben falls es geändert hat
            if (_setAltesValutaDatumAufTagesDatum)
            {
                DBUtil.ExecSQL("UPDATE FbBuchung SET ValutaDatum = {1}, Modified = GETDATE(), Modifier = {2} WHERE (FbBuchungID = {0} OR FbBuchungID_Kopf = {0}) AND ValutaDatum <> {1}",
                    record.PmtId.InstrId, order.VerarbeitungsDatum, DBUtil.GetDBRowCreatorModifier());
            }

            DBUtil.ExecSQL("INSERT INTO dbo.FbDTABuchung (FbBuchungID, FbDTAJournalID, Status) VALUES ({0}, {1}, {2})",
                record.PmtId.InstrId, order.JournalId, 2); //Uebermittelt
        }

        private int ErstelleZahlungslaufEintrag(FileInfo fileInfo, IOrder order)
        {
            //Read content of file to copy it to database
            string content;

            using (StreamReader reader = new StreamReader(fileInfo.FullName, Encoding.Default))
            {
                content = reader.ReadToEnd();
            }

            //add a new row in DB
            object result =
                DBUtil.ExecuteScalarSQL(@"
                    INSERT INTO FbDTAJournal (
                        FilePath,
                        TotalBetrag,
                        TransferDatum,
                        FbDTAZugangID,
                        PaymentMessageID,
                        UserID,
                        Transferiert,
                        Zahlungsdaten)
                    VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7});
                    SELECT SCOPE_IDENTITY()",
                    fileInfo.FullName,
                    order.TotalBetrag,
                    DateTime.Today,
                    order.AccessId,
                    order.PaymentMessageId,
                    Session.User.UserID,
                    1,
                    content);

            decimal id = Utils.ConvertToDecimal(result);

            return (int)id;
        }

        private int GenerateOrderId(int tempFbDTAZugangId, DateTime tempValutaDatum)
        {
            object obj = DBUtil.ExecuteScalarSQL(@"
                                    SELECT COUNT(DISTINCT DTAJ.FbDTAJournalID) + 1
                                    FROM FbDTAJournal          DTAJ
                                      INNER JOIN FbDTABuchung  DTAB ON DTAJ.FbDTAJournalID = DTAB.FbDTAJournalID
                                      INNER JOIN FbBuchung     FBB  ON DTAB.FbBuchungID    = FBB.FbBuchungID
                                    WHERE DTAJ.FbDTAZugangID = {0} AND dbo.fnDateOf(FBB.ValutaDatum) = dbo.fnDateOf({1})",
                tempFbDTAZugangId, tempValutaDatum);
            Int32 orderId = Utils.ConvertToInt(obj);
            return orderId;
        }

        #endregion

        #endregion
    }
}