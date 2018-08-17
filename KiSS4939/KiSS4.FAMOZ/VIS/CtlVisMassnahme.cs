using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.Common.Report;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.FAMOZ.VIS
{
    public partial class CtlVISMassnahme : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private DateTime _datumAusgangSds;
        private DateTime _datumEingangSds;
        private bool _documentExistsAlready = false;
        private int _faLeistungID = 0;

        #endregion

        #endregion

        #region Constructors

        public CtlVISMassnahme()
        {
            InitializeComponent();
        }

        #endregion

        #region EventHandlers

        private void CtlVISMassnahme_Load(object sender, EventArgs e)
        {
            try
            {
                // Synchronisiere KiSS und VIS
                UtilsVIS.SyncVISToKiSS(_faLeistungID);
                // Daten anzeigen:
                qryVmMassnahme.Fill(_faLeistungID);
                qryVmMassnahmeHistory.Fill(_faLeistungID);
                qryVmBerichtsperioden.Fill(_faLeistungID);
                EnableBerichtFelder(false);
            }
            catch
            {
                // Falls ein Fehler beim Füllen der Abfrage auftritt die Felder schreibgeschützt halten.
                EnableBerichtFelder(true);
                throw;
            }
        }

        private void docVermoegensabrechnung_DocumentCreating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true; // We create the file directly, so there is no need to proceed.
            if (!OnSaveData())
            {
                KissMsg.ShowInfo("Fehler beim Speichern");
                return;
            }

            if (docVermoegensabrechnung.InUse)
            {
                KissMsg.ShowInfo("XDokument", "DocumentInUseCannotImport", "Das Dokument ist zurzeit vom Prozess gesperrt und kann daher nicht ersetzt werden.");
                return;
            }

            if (DBUtil.IsEmpty(edtBerichtsperiodeVon.EditValue) && DBUtil.IsEmpty(edtBerichtsperiodeBis.EditValue))
            {
                KissMsg.ShowInfo("Mindestens eines der beiden Felder 'Berichtsperiode von' und 'Berichtsperiode bis' muss ausgefüllt sein um eine Vermögensabrechnung zu erstellen.");
                return;
            }

            if (DBUtil.IsEmpty(edtBerichtsart.EditValue))
            {
                KissMsg.ShowInfo("Das Feld Berichtsart darf nicht leer sein");
                return;
            }

            string tempFilePath = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Vorgehen: Dokument abspeichern, danach importieren, öffnen und Excel anpassen Angabe Seitenzahlen und Formatierung.
                tempFilePath = CreateReport();
                if (tempFilePath == null)
                {
                    return;
                }

                docVermoegensabrechnung.CanImportDocument = true;
                docVermoegensabrechnung.ImportFile(tempFilePath);

                // Erstelle den Eintrag in FaDokumente
                object faDokumenteID = DBUtil.ExecuteScalarSQLThrowingException(@"
                    SET NOCOUNT ON
                    DECLARE @BaPersonID int
                    DECLARE @UserID int

                    SELECT @BaPersonID = BaPersonID FROM FaLeistung WHERE FaLeistungID = {0}
                    SELECT @UserID = {3}

                    INSERT INTO FaDokumente
                        (FaLeistungID, Stichwort, FaDokVerwendungCode, DocumentID, FaDokThemaCode, BaPersonID, Absender, StatusLetztUserID, StatusLetztDatum, ErstelltUserID, ErstelltDatum)
                        VALUES
                        ({0}, {1}, 3 /*intern*/, {2}, 7 /*vormundschaftliche Massnahme*/, @BaPersonID, -@UserID/*negativ für userid, positiv für bapersonid*/, {3}, GetDate(), {3}, GetDate())
                    SELECT SCOPE_IDENTITY()",
                    _faLeistungID,
                    edtBerichtsart.EditValue + " " + (!DBUtil.IsEmpty(edtBerichtsperiodeVon.EditValue) ? ((DateTime)edtBerichtsperiodeVon.EditValue).ToString("dd.MM.yyyy") : "") + "-" + ((DateTime)edtBerichtsperiodeBis.EditValue).ToString("dd.MM.yyyy"),
                    docVermoegensabrechnung.DocumentID,
                    Session.User.UserID);
                docVermoegensabrechnung.OpenDoc();
                docVermoegensabrechnung.SetExcelPageNumberInPageFooter();
                docVermoegensabrechnung.SetExcelNumberFromatOnColumns("N:Z", "#'##0.00");
                docVermoegensabrechnung.SaveExcelDoc();
                qryBericht["VermoegensabrechnungsDokumenteID"] = faDokumenteID;
                qryBericht.Post();
            }
            finally
            {
                docVermoegensabrechnung.CanImportDocument = false;
                if (tempFilePath != null && !tempFilePath.Equals(string.Empty) && File.Exists(tempFilePath))
                {
                    File.Delete(tempFilePath);
                }

                Cursor.Current = Cursors.Default;
            }
        }

        private void docVermoegensabrechnung_DocumentDeleted(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryBericht["VermoegensabrechnungsDokumenteID"]))
            {
                DBUtil.ExecSQLThrowingException("DELETE FROM FaDokumente WHERE FaDokumenteID = {0}", (int)qryBericht["VermoegensabrechnungsDokumenteID"]);
                qryBericht["VermoegensabrechnungsDokumenteID"] = DBNull.Value;
                qryBericht["VermoegensabrechnungDocumentID"] = DBNull.Value;
                qryBericht.Post();
            }
        }

        private void edtMaKlibuUser_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtMaKlibuUser.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtMaKlibuUser.EditValue = DBNull.Value;
                    qryBericht["MaKlibuUser"] = DBNull.Value;
                    qryBericht["MaKlibuUserID"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID$ = UserID,
                  [Kürzel] = LogonName,
                  [Mitarbeiter/in] = NameVorname,
                  [Org.Einheit] = OrgUnit,
                  DisplayText$ = DisplayText
                FROM   vwUser
                WHERE  DisplayText LIKE '%' + {0} + '%'
                ORDER BY NameVorname",
                searchString,
                e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtMaKlibuUser.EditValue = dlg["DisplayText$"].ToString();
                qryBericht["MaKlibuUser"] = dlg["DisplayText$"].ToString();
                qryBericht["MaKlibuUserID"] = dlg["ID$"];
            }
        }

        private void qryBericht_AfterFill(object sender, EventArgs e)
        {
            EnableBerichtFelder(false);

            docBericht.ToolTip = (string)qryBericht["DokumentTooltip"];

            _documentExistsAlready = !DBUtil.IsEmpty(qryBericht["DocumentID"]);

            if (_documentExistsAlready)
            {
                docBericht.CanCreateDocument = false;
            }
            else
            {
                if (docBericht.EditMode != EditModeType.ReadOnly)
                {
                    docBericht.CanCreateDocument = true;
                }
            }

            _datumEingangSds = DBUtil.IsEmpty(qryBericht["DatumEingangSDS"]) ? DateTime.MinValue : (DateTime)qryBericht["DatumEingangSDS"];
            _datumAusgangSds = DBUtil.IsEmpty(qryBericht["DatumAusgangSDS"]) ? DateTime.MinValue : (DateTime)qryBericht["DatumAusgangSDS"];

            qryBerichtHistory.Fill(qryVmBerichtsperioden["VmMassnahmeID"], qryVmBerichtsperioden["MandateId"]);
        }

        private void qryBericht_AfterPost(object sender, EventArgs e)
        {
            if (!_documentExistsAlready && !DBUtil.IsEmpty(qryBericht["DocumentID"]))
            {
                // Der Benutzer hat ein Berichts-Dokument erstellt => Wir müssen einen entsprechenden Eintrag in FaDokumente machen, damit das Dokument korrekt abgelegt wird im Fall
                try
                {
                    Session.BeginTransaction();

                    // Erstelle den Eintrag in FaDokumente
                    DBUtil.ExecSQLThrowingException(@"
                        DECLARE @BaPersonID int
                        DECLARE @UserID int

                        SELECT @BaPersonID = BaPersonID, @UserID = UserID FROM FaLeistung WHERE FaLeistungID = {0}

                        INSERT INTO FaDokumente
                            (FaLeistungID, Stichwort, FaDokVerwendungCode, DocumentID, FaDokThemaCode, BaPersonID, Absender, StatusLetztUserID, StatusLetztDatum, ErstelltUserID, ErstelltDatum)
                            VALUES
                            ({0}, {1}, 2, {2}, 7, @BaPersonID, -@UserID, {3}, GetDate(), {3}, GetDate())",
                        _faLeistungID,
                        string.Format("{0} von {1:dd.MM.yy}{2}", qryBericht["Berichtsart"], qryBericht["DatumVon"], DBUtil.IsEmpty(qryBericht["DatumBis"]) ? "" : " bis " + ((DateTime)qryBericht["DatumBis"]).ToString("dd.MM.yy")),
                        qryBericht["DocumentID"],
                        Session.User.UserID);

                    _documentExistsAlready = true;
                    Session.Commit();
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    throw new KissCancelException("Das Berichts-Dokument konnte nicht in der Berichtsperiode gespeichert werden", ex, this);
                }
            }

            var neuDatumEingangSds = DBUtil.IsEmpty(qryBericht["DatumEingangSDS"]) ? DateTime.MinValue : (DateTime)qryBericht["DatumEingangSDS"];
            var neuDatumAusgangSds = DBUtil.IsEmpty(qryBericht["DatumAusgangSDS"]) ? DateTime.MinValue : (DateTime)qryBericht["DatumAusgangSDS"];

            if (!_datumEingangSds.Equals(neuDatumEingangSds) || !_datumAusgangSds.Equals(neuDatumAusgangSds))
            {
                // Daten, die ins VIS synchronisiert werden müssen, haben geändert

                // Synchronisiere KiSS und VIS
                UtilsVIS.SyncKiSSToVIS((int)qryBericht["VmBerichtID"]);
            }
        }

        private void qryBericht_BeforePost(object sender, EventArgs e)
        {
        }

        private void qryVmBerichtsperioden_AfterFill(object sender, EventArgs e)
        {
            if (qryVmBerichtsperioden.Count == 0)
            {
                // Es gibt keine Berichtsperioden => Verstecke Berichts-Tab
                tabBerichte.TabPages.RemoveAt(0);

                // Fülle Berichtshistory (ohne Berichte aus VIS)
                qryBerichtHistory.Fill(qryVmMassnahme["VmMassnahmeID"], null);
            }
            else
            {
                // Selektiere Berichts-Tab
                tabBerichte.SelectTab(tabBerichte.TabPages[0]);

                qryVmBerichtsperioden.First();
            }
        }

        private void qryVmBerichtsperioden_PositionChanged(object sender, EventArgs e)
        {
            qryBericht.Fill(qryVmBerichtsperioden["VIS_BK_ID"]);
        }

        private void qryVmBerichtsperioden_PositionChanging(object sender, EventArgs e)
        {
            // Schliesse vorher allfällig hängige Änderungen an dem Bericht ab (inkl. Synchronisation ins VIS)
            //qryBericht.Post();
        }

        private void qryVmMassnahmeHistory_AfterFill(object sender, EventArgs e)
        {
            if (qryVmMassnahmeHistory.Count == 0)
            {
                // Es gibt keine Massnahmen-History => Verstecke Massnahmen-History-Tab
                tabMassnahmen.TabPages.RemoveAt(1);
            }
            else
            {
                // Selektiere Massnahmen-Übersicht
                tabMassnahmen.SelectTab(tabMassnahmen.TabPages[0]);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BETRPERSONID": return DBUtil.ExecuteScalarSQL(@"select BaPersonID from FaLeistung where FaLeistungID = {0}", _faLeistungID);
                case "FALEISTUNGID": return _faLeistungID;
                case "ABSENDER": return DBUtil.ExecuteScalarSQL(@"select -UserID from FaLeistung where FaLeistungID = {0}", _faLeistungID);
                case "VMVISMANDID": return DBUtil.ExecuteScalarSQL(@"Select MAND_ID FROM vwVIS_BERICHT where BK_ID = {0}", qryBericht["VIS_BK_ID"]);
                case "VMVISMANDATEID": return DBUtil.ExecuteScalarSQL(@"Select MandateId FROM vwVIS_BERICHT where BK_ID = {0}", qryBericht["VIS_BK_ID"]);
                case "ADRESSAT": return DBUtil.ExecuteScalarSQL("Select Addressat FROM FaDokumente where DocumentID = {0}", qryBericht["DocumentID"]);
                case "LEISTUNGUSERID": return DBUtil.ExecuteScalarSQL(@"select UserID from FaLeistung where FaLeistungID = {0}", _faLeistungID);
                case "FAFALLID": return DBUtil.ExecuteScalarSQL(@"select FaFallID from FaLeistung where FaLeistungID = {0}", _faLeistungID);
                case "FALLUSERID": return DBUtil.ExecuteScalarSQL(@"select FAL.UserID from dbo.FaFall FAL
                                                                    inner join dbo.FaLeistung LEI on LEI.FaFallID = FAL.FaFallID
                                                                    where LEI.FaLeistungID = {0}", _faLeistungID);
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string name, Image titleImage, int faLeistungID)
        {
            lblTitel.Text = name;
            picTitel.Image = titleImage;
            _faLeistungID = faLeistungID;
        }

        #endregion

        #region Private Methods

        private static void StreamCopy(Stream inputStream, Stream outputStream)
        {
            const int bufferSize = 4096;
            byte[] buffer = new byte[4096];
            int bytesCopied;
            while ((bytesCopied = inputStream.Read(buffer, 0, bufferSize)) > 0)
            {
                outputStream.Write(buffer, 0, bytesCopied);
            }
        }

        private string CreateReport()
        {
            // Finde KgPeriode zum gleichen Fall, zur gleichen Person und zum gleichen Zeitabschnitt.
            // Vorbedingung: entweder qryBericht["DatumVon"] oder qryBericht["DatumBis"]) ist nicht NULL
            int? kgPeriodeID = null;
            var qry = DBUtil.OpenSQL(@"
                SELECT DISTINCT PER.KgPeriodeID, Stand = CASE WHEN PER.PeriodeBis = ISNULL({2}, PER.PeriodeBis) THEN 'genau' ELSE 'ungenau' END
                FROM FaLeistung LEI
                    INNER JOIN FaLeistung LEI2 ON LEI2.FaFallID = LEI.FaFallID AND LEI2.FaProzessCode = 500
                    INNER JOIN KgPeriode PER ON PER.FaLeistungID = LEI2.FaLeistungID
                WHERE LEI.FaLeistungID = {0} AND (PER.PeriodeVon = {1} OR {1} IS NULL AND PER.PeriodeBis = {2})",
                    _faLeistungID, qryBericht["DatumVon"], qryBericht["DatumBis"]);

            if (qry.DataTable.Select("Stand = 'genau'").Length == 1) // einen genauen Treffer
            {
                kgPeriodeID = (int)qry.DataTable.Select("Stand = 'genau'")[0]["KgPeriodeID"];
            }
            else if (qry.Count == 1) // einen ungenauen Treffer: Warnung ausgeben
            {
                kgPeriodeID = (int)qry["KgPeriodeID"];
                KissMsg.ShowInfo("Warnung: Das Bis-Datum stimmt zwischen V-Periode und K-Periode nicht überein.");
            }
            else if (qry.Count <= 0)
            {
                KissMsg.ShowInfo("Es konnte keine passende Periode für den Rechenschaftsbericht gefunden.");
                return null;
            }
            else // zu viele Lösungen
            {
                KissMsg.ShowInfo("Es wurde mehr als eine passende Periode für den Rechenschaftsbericht gefunden.");
                return null;
            }

            var prms = new NamedPrm[3];
            //prms[0] = new NamedPrm("KgPeriodeID", 8394); // Test
            prms[0] = new NamedPrm("KgPeriodeID", qry["KgPeriodeID"]);
            prms[1] = new NamedPrm("UserID", Session.User.UserID);
            prms[2] = new NamedPrm("VmBerichtID", qryBericht["VmBerichtID"]);

            var pdfStream = RepUtil.ExecuteReport("K_Vermoegensabrechnung", KissReportDestination.ExportToExcel, prms);
            //For test purposes: Show report
            //RepUtil.ExecuteReport("K_Vermoegensabrechnung", KissReportDestination.Viewer, prms);

            if (pdfStream == null)
            {
                KissMsg.ShowInfo("Datei erzeugen fehlgeschlagen.");
                return null;
            }

            string tempFilePath = Path.GetTempPath() + Guid.NewGuid().ToString() + ".xls";

            Stream fileStream = new FileStream(tempFilePath, FileMode.Create);
            StreamCopy(pdfStream, fileStream);
            fileStream.Close();
            return tempFilePath;
        }

        private void EnableBerichtFelder(bool setReadOnly)
        {
            EditModeType editmode = setReadOnly ? EditModeType.ReadOnly : EditModeType.Normal;

            if (DBUtil.IsEmpty(qryVmBerichtsperioden["BERICHTSTERMIN"]) || !DBUtil.IsEmpty(qryVmBerichtsperioden["Aufhebung"]))
            {
                // Die gewählte Berichtsperiode ist entweder eine migrierter VIS-Ernennung (Berichtstermin ist leer) oder der Bericht ist bereits aufgehoben
                // In beiden Fällen ist der Bericht Readonly
                editmode = EditModeType.ReadOnly;
            }

            if (!DBUtil.IsEmpty(qryBericht["DatumGenehmigung1"]))
            {
                // Genemigung VB ist gesetzt, d.h. der Benutzer kann diesen Bericht nicht mehr bearbeiten
                editmode = EditModeType.ReadOnly;
            }

            if (!qryBericht.CanUpdate)
            {
                // Das Query ist nocht updatable, daher übersteuern wir hier den EditMode mit ReadOnly
                editmode = EditModeType.ReadOnly;
            }

            docBericht.EditMode = editmode;
            docVermoegensabrechnung.EditMode = editmode;
            edtDatumBerichtMT.EditMode = editmode;
            edtDatumVersandAnVB.EditMode = editmode;
            edtDatumEingangSDS.EditMode = editmode;
            edtDatumAusgangSDS.EditMode = editmode;
            edtMaKlibuUser.EditMode = editmode;

            if (qryBericht.CanUpdate && !DBUtil.IsEmpty(qryBericht["DatumGenehmigung1"]) && DBUtil.IsEmpty(qryBericht["DatumGenehmigung2"]))
            {
                // Die Massnahme ist vom VB genemigt, aber noch nicht vom BRZ, daher kann das Bemerkungsfeld noch editiert werden
            }
            else
            {
                edtBemerkung.EditMode = editmode;
            }

            //// #5428: Nach dem 1.1.2010 darf das Feld "Spesen" nicht mehr bearbeitbar sein
            //// TODO: Das Feld "Spesen" kann im nächsten Release konstant als Readonly gesetzt werden
            //DateTime deadline = new DateTime(2010,1,1);
            //if (DateTime.Now >= deadline)
            //{
            //    // Nach dem 1.1.2010 => Immer Readonly
            //    edtBetragSpesen.EditMode = EditModeType.ReadOnly;
            //}
            //else
            //{
            //    edtBetragSpesen.EditMode = editmode;
            //}

            if (!DBUtil.IsEmpty(qryBericht["FaDokStatusCode"]) && (int)qryBericht["FaDokStatusCode"] == 3) // 3 = Historisiertes Dokument
            {
                // Das Dokument ist historisiert, d.h. es kann nicht bearbeitet werden
                docBericht.EditMode = EditModeType.ReadOnly;
            }

            if (!DBUtil.IsEmpty(qryBericht["VermoegensAbrechnungFaDokStatusCode"]) && (int)qryBericht["VermoegensAbrechnungFaDokStatusCode"] == 3) // 3 = Historisiertes Dokument
            {
                // Das Dokument ist historisiert, d.h. es kann nicht bearbeitet werden
                docVermoegensabrechnung.EditMode = EditModeType.ReadOnly;
            }

            if (!DBUtil.UserHasRight("CtlVISMassnahme_Vermoegensabrechnung")) // Spezialrecht für Klibu
            {
                docVermoegensabrechnung.EditMode = EditModeType.ReadOnly;
            }
        }

        #endregion

        #endregion
    }
}