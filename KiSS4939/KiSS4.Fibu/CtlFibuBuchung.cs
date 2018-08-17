using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using SharpLibrary.WinControls;

namespace KiSS4.Fibu
{
    public partial class CtlFibuBuchung : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _baPersonId;
        private bool _filling;
        private bool _insertMode;
        private bool _mandantIsFixed;
        private DataRow _saveRow;

        #endregion

        #endregion

        #region Constructors

        public CtlFibuBuchung()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        public SqlQuery QryBuchung
        {
            get { return ActiveSQLQuery; }
        }

        #endregion

        #region EventHandlers

        private void ctlFibuBuchung_Load(object sender, EventArgs e)
        {
            ActiveSQLQuery = qryLetzteBelegNr;

            editDatumVonX.EditValue = DBNull.Value;
            editDatumBisX.EditValue = DBNull.Value;

            tabControlBuchung.TabPages[1].Show();

            _filling = true;
            qryLetzteBelegNr.Fill("EXEC spFBGetLastBookings {0}, {1};", Session.User.UserID, _baPersonId);
            qryFbBuchung.Fill("SELECT * FROM viewFbBuchungen WHERE FbBuchungID = -1;");

            //Team DropDown
            var qry = DBUtil.OpenSQL("SELECT FbTeamID Code, Name Text FROM FbTeam ORDER BY Name;");
            editTeamX.Properties.DataSource = qry;
            editTeamX.Properties.DropDownRows = Math.Min(qry.Count, 7);
            _filling = false;

            SetActiveQuery(qryLetzteBelegNr);
            if (QryBuchung.CanInsert)
            {
                //QryBuchung.Insert();
            }

            //Wenn Maske im Fall eines Klienten angezeigt wird, soll das "Suchen"-Register automatisch selektiert werden,
            //sonst (in Mandatsbuchhaltung) das "Eigene Buchungen" Register
            if (_mandantIsFixed)
            {
                tabControlListen.SelectedTabIndex = 2;
            }
            else
            {
                tabControlListen.SelectedTabIndex = 0;
                tabControlBuchung.SelectedTabIndex = 0;
            }

            if (!DBUtil.UserHasRight(GetType().Name, "u"))
            {
                qryLetzteBelegNr.EnableBoundFields(false);
                qryFbBuchung.EnableBoundFields(false);
            }
            if (DBUtil.UserHasRight("CtlFibuBuchung Mutation Buchungstext"))
            {
                qryLetzteBelegNr.CanUpdate = true;
                qryFbBuchung.CanUpdate = true;
            }

            //Wenn Maske im Fall dargestellt wird, erfolgt das ShowPeriodenX() im CallStack von Init(...) zu früh. Es wird dann noch nicht die letzte Periode selektiert.
            //Deshalb wird ShowPeriodenX() hier noch einmal aufgerufen.
            ShowPeriodenX();
        }

        private void CtlFibuBuchung_Search(object sender, EventArgs e)
        {
            if (tabControlListen.SelectedTabIndex == 2)
                Suchen();
            else
                if (QryBuchung.Post())
                {
                    tabControlListen.SelectedTabIndex = 2;
                    NeueSuche();
                }
        }

        private void editBetrag_EnterKey(object sender, KeyEventArgs e)
        {
            if (QryBuchung.Row.RowState == DataRowState.Added)
            {
                if (QryBuchung.Post()) QryBuchung.Insert();
            }
            else
            {
                if (QryBuchung.Post()) grdFbBuchung.Focus();
            }
            e.Handled = true;
        }

        private void editCode_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (DBUtil.IsEmpty(QryBuchung["BuchungsDatum"]))
            {
                KissMsg.ShowInfo("CtlFibuBuchung", "ZuerstDatum", "Bitte zuerst Datum ausfüllen");
                e.Cancel = true;
                return;
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.BuchungsCodeSuchen(editCode.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                QryBuchung["Code"] = dlg["Code"];
                ApplyBuchungsCode();
            }
        }

        private void editCodeX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.BuchungsCodeSuchen(editCodeX.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                editCodeX.EditValue = dlg["Code"];
            }
        }

        private void editErfasstX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(editErfasstX.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                editErfasstX.EditValue = dlg["Name"];
            }
        }

        private void editHaben_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (DBUtil.IsEmpty(QryBuchung["FbPeriodeID"]))
            {
                KissMsg.ShowInfo("CtlFibuBuchung", "ZuerstMandant", "Bitte zuerst Mandant auswählen");
                e.Cancel = true;
                return;
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.KontoSuchen(editHaben.Text, (int)QryBuchung["FbPeriodeID"], e.ButtonClicked);
            if (!e.Cancel)
            {
                QryBuchung["HabenKtoNr"] = dlg["KontoNr"];
                QryBuchung["HabenKtoName"] = dlg["KontoName"];
                QryBuchung["HabenKontoTypCode"] = dlg["KontoTypCode"];
                DisplaySaldo(false);
            }
        }

        private void editMandant_EnterKey(object sender, KeyEventArgs e)
        {
            if (QryBuchung.Row.RowState == DataRowState.Added && !DBUtil.IsEmpty(QryBuchung["Code"]))
            {
                if (DBUtil.IsEmpty(QryBuchung["SollKtoNr"]))
                {
                    editSoll.Focus();
                }
                else if (DBUtil.IsEmpty(QryBuchung["HabenKtoNr"]))
                {
                    editHaben.Focus();
                }
                else if (DBUtil.IsEmpty(QryBuchung["Text"]) || (QryBuchung["Text"].ToString().IndexOf("#") != -1))
                {
                    editText.Focus();
                }
                else
                {
                    editBetrag.Focus();
                }
            }
            else
            {
                SendKeys.SendWait("{TAB}");
            }
        }

        private void editMandant_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (QryBuchung.Count > 0 && DBUtil.IsEmpty(QryBuchung["BuchungsDatum"]))
            {
                KissMsg.ShowInfo("CtlFibuBuchung", "ZuerstDatum", "Bitte zuerst Datum ausfüllen");
                e.Cancel = true;
                return;
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenA(editMandant.Text, editDatum.DateTime, CtlFibu.FbTeamIDList(), e.ButtonClicked);
            if (!e.Cancel)
            {
                UpdateQryBuchungAndRefreshKonti(dlg);
            }
        }

        private void editMandantX_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.MandantSuchenB(editMandantX.Text, e.ButtonClicked);
            if (!e.Cancel)
            {
                UpdateEditTextAndShowPerioden(dlg);
            }
        }

        private void editSoll_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (DBUtil.IsEmpty(QryBuchung["FbPeriodeID"]))
            {
                KissMsg.ShowInfo("CtlFibuBuchung", "ZuerstMandant", "Bitte zuerst Mandant auswählen");
                e.Cancel = true;
                return;
            }

            var dlg = new DlgAuswahl();
            e.Cancel = !dlg.KontoSuchen(editSoll.Text, (int)QryBuchung["FbPeriodeID"], e.ButtonClicked);
            if (!e.Cancel)
            {
                QryBuchung["SollKtoNr"] = dlg["KontoNr"];
                QryBuchung["SollKtoName"] = dlg["KontoName"];
                QryBuchung["SollKontoTypCode"] = dlg["KontoTypCode"];
                DisplaySaldo(true);
            }
        }

        private void editText_Enter(object sender, EventArgs e)
        {
            var p = QryBuchung["Text"].ToString().IndexOf("#");
            if (p > -1)
            {
                editText.SelectionStart = p;
                editText.SelectionLength = 1;
            }
        }

        private void editText_Leave(object sender, EventArgs e)
        {
            editText.SelectionStart = 0;
        }

        private void label_Click(object sender, EventArgs e)
        {
            if (!(sender is KissLabel)) return;

            var lbl = (KissLabel)sender;
            lbl.Font = new Font(GuiConfig.LabelFontName,
                                 GuiConfig.LabelFontSize,
                                 lbl.Font.Underline ? FontStyle.Regular : FontStyle.Underline,
                                 GuiConfig.LabelFontGraphicUnit);
        }

        private void qryBuchung_AfterInsert(object sender, EventArgs e)
        {
            var nextBelegNrText = "";
            try
            {
                var qry = DBUtil.OpenSQL(@"
                    SELECT Praefix, NaechsteBelegNr
                    FROM dbo.FbBelegNr
                    WHERE UserID = {0};", Session.User.UserID);

                if (qry.Count > 0)
                {
                    nextBelegNrText = qry["Praefix"] + qry["NaechsteBelegNr"].ToString();
                }

                if (editMandantX.EditMode == EditModeType.ReadOnly)
                {
                    var dlg = new DlgAuswahl();
                    var qryDatum = DBUtil.ExecuteScalarSQL(@"IF EXISTS(SELECT *
                                                                       FROM dbo.FbPeriode FBP WITH(READUNCOMMITTED)
                                                                       WHERE GETDATE() BETWEEN FBP.PeriodeVon AND FBP.PeriodeBis
                                                                         AND FBP.PeriodeStatusCode = 1
                                                                         AND FBP.BaPersonID = {0})
                                                             BEGIN
                                                               SELECT GETDATE()
                                                             END
                                                             ELSE
                                                             BEGIN
                                                               SELECT TOP 1 FBP.PeriodeVon
                                                               FROM dbo.FbPeriode FBP WITH(READUNCOMMITTED)
                                                               WHERE FBP.BaPersonID = {0}
                                                                 AND FBP.PeriodeStatusCode = 1
                                                               ORDER BY FBP.PeriodeVon DESC
                                                             END", _baPersonId);
                    if (!DBUtil.IsEmpty(qryDatum))
                    {
                        var result = !dlg.MandantSuchenA(Convert.ToString(_baPersonId), Convert.ToDateTime(qryDatum), GetFbTeams(), false);
                        QryBuchung["BuchungsDatum"] = Convert.ToDateTime(qryDatum);
                        UpdateQryBuchungAndRefreshKonti(dlg);
                    }
                    else
                    {
                        KissMsg.ShowInfo("CtlFibuBuchung", "MandantHatKeineAktivePerioden", "Der Mandant hat keine aktive Periode.");
                    }
                }
            }
            catch { }

            editSollSaldo.Text = "";
            editHabenSaldo.Text = "";
            editSollGrpSaldo.Text = "";
            editHabenGrpSaldo.Text = "";

            QryBuchung["BuchungTypCode"] = 0;
            QryBuchung["BelegNr"] = nextBelegNrText;
            QryBuchung["BelegNrPos"] = 0;

            if (lblDatum.Font.Underline) QryBuchung["BuchungsDatum"] = _saveRow["BuchungsDatum"];
            if (lblCode.Font.Underline) QryBuchung["Code"] = _saveRow["Code"];
            if (lblSoll.Font.Underline) QryBuchung["SollKtoNr"] = _saveRow["SollKtoNr"];
            if (lblHaben.Font.Underline) QryBuchung["HabenKtoNr"] = _saveRow["HabenKtoNr"];
            if (lblText.Font.Underline) QryBuchung["Text"] = _saveRow["Text"];

            if (lblMandant.Font.Underline)
            {
                QryBuchung["FbPeriodeID"] = _saveRow["FbPeriodeID"];
                QryBuchung["Mandant"] = _saveRow["Mandant"];
                QryBuchung["BaPersonID"] = _saveRow["BaPersonID"];
                QryBuchung["PLZOrt"] = _saveRow["PLZOrt"];

                if (!DBUtil.IsEmpty(QryBuchung["SollKtoNr"]))
                {
                    QryBuchung["SollKtoName"] = _saveRow["SollKtoName"];
                    DisplaySaldo(false);
                }

                if (!DBUtil.IsEmpty(QryBuchung["HabenKtoNr"]))
                {
                    QryBuchung["HabenKtoName"] = _saveRow["HabenKtoName"];
                    DisplaySaldo(false);
                }
            }

            QryBuchung["ErfLogon"] = Session.User.LogonName;
            QryBuchung["ErfName"] = Session.User.FirstName + ' ' + Session.User.LastName;
            QryBuchung["UserID"] = Session.User.UserID;

            if (QryBuchung["Code"] != DBNull.Value) ApplyBuchungsCode();

            QryBuchung.RefreshDisplay();

            editDatum.Focus();
        }

        private void qryBuchung_AfterPost(object sender, EventArgs e)
        {
            if (qryLetzteBelegNr == QryBuchung && _insertMode)
            {
                _saveRow = QryBuchung.Row;
            }
            DisplaySaldo(true);
            DisplaySaldo(false);
        }

        private void qryBuchung_BeforeDelete(object sender, EventArgs e)
        {
            if (QryBuchung.Row.RowState == DataRowState.Modified)
            {
                //check if Period is (still) active
                switch ((int)DBUtil.ExecuteScalarSQL(
                    " select PeriodeStatusCode from FbPeriode where  FbPeriodeID = {0}",
                    QryBuchung["FbPeriodeID"]))
                {
                    case 2:
                        KissMsg.ShowInfo("CtlFibuBuchung", "NichtGeloeschtPeriodeInaktiv", "Die Buchung kann nicht gelöscht werden, da die Periode auf inaktiv gesetzt wurde!");
                        throw new Exception();
                    case 3:
                        KissMsg.ShowInfo("CtlFibuBuchung", "NichtGeloeschtPeriodeAbgeschlossen", "Die Buchung kann nicht gelöscht werden, da die Periode abgeschlossen ist!");
                        throw new Exception();
                }
            }
        }

        private void qryBuchung_BeforePost(object sender, EventArgs e)
        {
            DBUtil.CheckNotNullField(editDatum, lblDatum.Text);
            DBUtil.CheckNotNullField(editMandant, lblMandant.Text);
            DBUtil.CheckNotNullField(editBelegNr, lblBelegNr.Text);
            DBUtil.CheckNotNullField(editSoll, lblSoll.Text);
            DBUtil.CheckNotNullField(editHaben, lblHaben.Text);
            DBUtil.CheckNotNullField(editText, lblText.Text);
            DBUtil.CheckNotNullField(editBetrag, lblBetrag.Text);

            QryBuchung["UserID"] = Session.User.UserID; //sicher ist sicher!

            if (DBUtil.IsEmpty(QryBuchung["ValutaDatum"]))
                QryBuchung["ValutaDatum"] = QryBuchung["BuchungsDatum"];

            if (!KontoErlaubnis(true))
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuBuchung", "BerechtigungSollFehlt", "Die Berechtigung für den KontoTyp des Soll-Kontos fehlt!", KissMsgCode.MsgInfo));

            if (!KontoErlaubnis(false))
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuBuchung", "BerechtigungHabenFehlt", "Die Berechtigung für den KontoTyp des Haben-Kontos fehlt!", KissMsgCode.MsgInfo));

            //check if there is (still) an active Period according to Buchungsdatum
            var qry = DBUtil.OpenSQL(@"
                SELECT FbPeriodeID, PeriodeStatusCode
                FROM FbPeriode
                WHERE BaPersonID = {0}
                    AND {1} BETWEEN PeriodeVon AND PeriodeBis",
                                          QryBuchung["BaPersonID"],
                                          QryBuchung["BuchungsDatum"]);

            if (qry.Count == 0)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuBuchung", "KeineAktivePeriode", "Keine aktive Periode gefunden für den {0}!", KissMsgCode.MsgInfo, editDatum.Text));

            switch ((int)qry["PeriodeStatusCode"])
            {
                case 1: // active
                    QryBuchung["FbPeriodeID"] = qry["FbPeriodeID"];
                    break;

                case 2: // inactive
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuBuchung", "PeriodeInaktiv", "Die zutreffende Periode für den {0} ist inaktiv!", KissMsgCode.MsgInfo, editDatum.Text));
                case 3: // closed
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuBuchung", "PeriodeAbgeschlossen", "Die zutreffende Periode für den {0} ist abgeschlossen!", KissMsgCode.MsgInfo, editDatum.Text));
            }

            // check Zahlungsweg: returns an Exception if data is not valid.
            // If an Exception has been thrown, highlight XTabIndex 1 and threw Exception further
            try
            {
                ctlFibuZahlungsWeg.SaveNewKreditorAndZahlungsWeg();
            }
            catch (Exception)
            {
                tabControlBuchung.SelectedTabIndex = 1;
                throw;
            }

            ZahlungsArt zahlungsArtCode;
            try
            {
                zahlungsArtCode = (ZahlungsArt)Enum.Parse(typeof(ZahlungsArt), QryBuchung["ZahlungsArtCode"].ToString(), true);
            }
            catch
            {
                zahlungsArtCode = ZahlungsArt.Unbekannt;
            }

            if (zahlungsArtCode == ZahlungsArt.OrangerEinzahlungsschein ||
                zahlungsArtCode == ZahlungsArt.Blau_Orange_ESR_ueber_Bank)
            {
                //keep referenznummer, remove zahlungsgrund
                QryBuchung["Zahlungsgrund"] = DBNull.Value;
            }
            else
            {
                //keep zahlungsgrund, remove referenznummer
                QryBuchung["Referenznummer"] = DBNull.Value;
            }

            //check Zahlungsgrund
            var zahlungsgrund = QryBuchung["Zahlungsgrund"].ToString().Replace("\r\n", "\n");
            var zgLines = zahlungsgrund.Split('\n');
            if (zgLines.Length > 4)
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuBuchung", "MaxVierLinien", "Der Zahlungsgrund darf maximal 4 Linien umfassen!", KissMsgCode.MsgInfo));

            foreach (var line in zgLines.Where(line => line.Length > 35))
            {
                throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuBuchung", "LinieZuLang", "Zahlungsgrund: Die Linie '{0}' ist länger als 35 Zeichen!\r\nEventuell Zeilenumbrüche einfügen mit der Enter-Taste", KissMsgCode.MsgInfo, line));
            }

            //Added Row - Check Habenkonto: If it's a DTA-Account and FbZahlungswegID is null, ask user
            if (QryBuchung.Row.RowState == DataRowState.Added &&
                DBUtil.IsEmpty(QryBuchung["FbZahlungswegID"]))
            {
                qry = DBUtil.OpenSQL(@"
                    SELECT FbDTAZugangID
                    FROM FbKonto
                    WHERE  FbPeriodeID = {0}
                        AND KontoNr = {1}",
                    QryBuchung["FbPeriodeID"],
                    QryBuchung["HabenKtoNr"]);

                if (qry.Count > 0 && !DBUtil.IsEmpty(qry["FbDTAZugangID"]))
                {
                    if (!KissMsg.ShowQuestion("FibuBuchung", "ZahlungswegNichtErfasst", "Im Haben steht ein Konto mit DTA-Zugang, ein Zahlungsweg ist aber nicht erfasst!\r\n\r\nTrotzdem speichern ?", false))
                    {
                        throw new KissCancelException();
                    }
                }
            }

            try
            {
                if (DBUtil.GetConfigBool(@"System\Fibu\Buchen\GenerateBelegNrProMandant", false))
                {
                    qry = DBUtil.OpenSQL("SELECT FbBelegNrID, Praefix, NaechsteBelegNr FROM FbBelegNr WHERE BaPersonID = {0}", QryBuchung["BaPersonID"]);
                }
                else
                {
                    qry = DBUtil.OpenSQL("SELECT FbBelegNrID, Praefix, NaechsteBelegNr FROM FbBelegNr WHERE UserID = {0}", Session.User.UserID);
                }

                if (qry.Count > 0)
                {
                    var nextBelegNrText = qry["Praefix"] + qry["NaechsteBelegNr"].ToString();
                    // Falls vorgeschlagene BelegNr unverändert: BelegNr hochzählen
                    if (nextBelegNrText == QryBuchung["BelegNr"].ToString())
                    {
                        DBUtil.ExecSQL("UPDATE FbBelegNr SET NaechsteBelegNr = NaechsteBelegNr + 1 WHERE FbBelegNrID = {0}", qry["FbBelegNrID"]);
                    }
                }
            }
            catch { }

            _insertMode = QryBuchung.Row.RowState == DataRowState.Added;
        }

        private void qryBuchung_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                QryBuchung.EnableBoundFields(false);
                if (QryBuchung.Count > 0)
                {
                    ctlFibuZahlungsWeg.UnlockControl();

                    if (!_filling)
                    {
                        ctlFibuZahlungsWeg.FbBuchungId = QryBuchung["FbBuchungID"];
                        ctlFibuZahlungsWeg.FbZahlungsWegId = QryBuchung["FbZahlungswegID"];

                        var status = BuchungDTAStatus.Unbekannt;

                        if (QryBuchung.Row.RowState != DataRowState.Added)
                        {
                            var sql = string.Format(@"
                                SELECT ISNULL(Status, 0)
                                FROM dbo.ViewFbBuchungen
                                WHERE FbBuchungID = {0};", QryBuchung["FbBuchungId"]);
                            status = (BuchungDTAStatus)Enum.Parse(typeof(BuchungDTAStatus), Convert.ToString(DBUtil.ExecuteScalarSQL(sql)));
                        }

                        if (DBUtil.IsEmpty(QryBuchung["PeriodeStatusCode"]) || (int)QryBuchung["PeriodeStatusCode"] == 1)
                        {
                            if (status != BuchungDTAStatus.Unbekannt)
                                QryBuchung["StatusText"] = status.ToString();
                            else
                                QryBuchung["StatusText"] = "";

                            QryBuchung.RowModified = false;
                        }

                        ctlFibuZahlungsWeg.BuchungStatus = status;

                        // enable/disable edit fields
                        if (DBUtil.IsEmpty(QryBuchung["PeriodeStatusCode"]) ||
                            (int)QryBuchung["PeriodeStatusCode"] == 1)
                        {
                            if (KontoErlaubnis(true) && KontoErlaubnis(false) && QryBuchung.CanUpdate)
                            {
                                if (DBUtil.UserHasRight(GetType().Name, "U") || QryBuchung.Row.RowState == DataRowState.Added && QryBuchung.CanInsert)
                                {
                                    switch (status)
                                    {
                                        case BuchungDTAStatus.Unbekannt:
                                            QryBuchung.EnableBoundFields(true);
                                            break;

                                        case BuchungDTAStatus.Fehlerhaft:
                                            QryBuchung.EnableBoundFields(true);
                                            break;

                                        case BuchungDTAStatus.Bezahlt:
                                        case BuchungDTAStatus.Übermittelt:
                                            QryBuchung.EnableBoundFields(false);

                                            // Datum, Mandant, SollKto und Buchungstext soll editierbar bleiben
                                            editDatum.EditMode = EditModeType.Normal;
                                            if (!_mandantIsFixed)
                                            {
                                                //Nur wenn Maske in Mandatsbuchhaltung angezeigt wird, soll Mandant editierbar sein (wenn in Fall: Mandant ist immer Readonly)
                                                editMandant.EditMode = EditModeType.Normal;
                                            }
                                            editText.EditMode = EditModeType.Normal;
                                            editSoll.EditMode = EditModeType.Normal;
                                            break;
                                    }
                                }
                                else // user has just the special right "CtlFibuBuchung Mutation Buchungstext"
                                {
                                    QryBuchung.EnableBoundFields(false);
                                    editText.EditMode = EditModeType.Normal;
                                }
                            }
                            else
                                QryBuchung.EnableBoundFields(false);
                        }
                        else
                            QryBuchung.EnableBoundFields(false);

                        DisplaySaldo(true);
                        DisplaySaldo(false);

                        QryBuchung.RowModified = false;

                        if (QryBuchung.Row.RowState == DataRowState.Modified)
                            QryBuchung.Row.AcceptChanges();
                    }
                }
                else
                {
                    ctlFibuZahlungsWeg.FbZahlungsWegId = 0;
                    ctlFibuZahlungsWeg.LockControl();
                }
            }
            catch (Exception g)
            {
                KissMsg.ShowError("CtlFibuBuchung", "AllgemeinerFehler", "Ein allgemeiner Fehler ist aufgetreten", g);
            }
        }

        private void qrySearchResult_BeforeInsert(object sender, EventArgs e)
        {
            throw new KissInfoException(KissMsg.GetMLMessage("CtlFibuBuchung", "NeueBuchungErfassen", "Bitte neue Buchungen im Register 'Eigene Buchungen' erfassen", KissMsgCode.MsgInfo));
        }

        private void tabControlBuchung_SelectedTabChanged(TabPageEx page)
        {
            var valutaOffset = DBUtil.GetConfigInt(@"System\Fibu\Buchen\ValutaDatumOffset", 0);
            if (!DBUtil.IsEmpty(QryBuchung["ValutaDatum"]) && tabControlBuchung.SelectedTab == tpgBuchung)//1: Buchung;)
            {
                if (DBUtil.IsEmpty(QryBuchung["BuchungsDatum"]) && DBUtil.IsEmpty(editDatum.EditValue))
                {
                    QryBuchung["BuchungsDatum"] = ((DateTime)QryBuchung["ValutaDatum"]).AddDays(-valutaOffset);
                    editDatum.EditValue = QryBuchung["BuchungsDatum"];
                }
            }
        }

        private void tabControlListen_SelectedTabChanged(TabPageEx page)
        {
            switch (tabControlListen.SelectedTabIndex)
            {
                case 0:
                    tabControlBuchung.Visible = true;
                    SetActiveQuery(qryLetzteBelegNr);
                    qryBuchung_PositionChanged(page, new EventArgs());
                    break;

                case 1:
                    tabControlBuchung.Visible = true;
                    SetActiveQuery(qryFbBuchung);
                    qryBuchung_PositionChanged(page, new EventArgs());
                    break;

                case 2:
                    tabControlBuchung.Visible = false;
                    break;

                case 3:
                    tabControlBuchung.Visible = true;
                    gridKontoSoll.DataSource = null;
                    gridKontoSoll.Height = tpgKontoSoll.Height - gridKontoSoll.Top;
                    lblKontoSoll.Text = "";
                    if (!DBUtil.IsEmpty(QryBuchung["FbPeriodeID"]) && !DBUtil.IsEmpty(QryBuchung["SollKtoNr"]))
                    {
                        lblKontoSoll.Text = QryBuchung["SollKtoNr"] + "  " + QryBuchung["SollKtoName"];
                        gridKontoSoll.DataSource = DBUtil.OpenSQL("exec spFbGetKontoblatt " +
                            QryBuchung["FbPeriodeID"] + ',' +
                            QryBuchung["SollKtoNr"]);
                        ((GridView)gridKontoSoll.MainView).MoveLast();
                    }
                    break;

                case 4:
                    tabControlBuchung.Visible = true;
                    gridKontoHaben.DataSource = null;
                    lblKontoHaben.Text = "";
                    if (!DBUtil.IsEmpty(QryBuchung["FbPeriodeID"]) && !DBUtil.IsEmpty(QryBuchung["HabenKtoNr"]))
                    {
                        lblKontoHaben.Text = QryBuchung["HabenKtoNr"] + "  " + QryBuchung["HabenKtoName"];
                        gridKontoHaben.DataSource = DBUtil.OpenSQL("exec spFbGetKontoblatt " +
                            QryBuchung["FbPeriodeID"] + ',' +
                            QryBuchung["HabenKtoNr"]);
                        ((GridView)gridKontoHaben.MainView).MoveLast();
                    }
                    break;
            }
        }

        private void tabControlListen_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (tabControlListen.SelectedTabIndex == 0)
            {
                e.Cancel = !QryBuchung.Post();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ChangeBuchungKreditorTab(int tabIndex)
        {
            tabControlBuchung.SelectedTabIndex = tabIndex;
        }

        public override string GetContextName()
        {
            return "VmFibu";
        }

        public void Init(string maskName, Image maskImage, int baPersonID)
        {
            CtlFibu.SetQryFbTeamMitgleid();

            _baPersonId = baPersonID;
            _mandantIsFixed = _baPersonId != 0;

            var qryMandantHatPerioden =
                DBUtil.ExecuteScalarSQL(
                    @"SELECT COUNT(*)
                      FROM FbPeriode
                      WHERE BaPersonID = {0}",
                    _baPersonId);

            if (Convert.ToInt32(qryMandantHatPerioden) == 0)
            {
                KissMsg.ShowInfo("CtlFibuBuchung", "MandantHatKeinePerioden", "Der Mandant hat keine Periode.");
            }
            else
            {
                var dlg = new DlgAuswahl();
                var result = !dlg.MandantSuchenB(Convert.ToString(_baPersonId), false);
                UpdateEditTextAndShowPerioden(dlg);
            }

            editMandantX.EditMode = EditModeType.ReadOnly;
            editMandant.EditMode = EditModeType.ReadOnly;
        }

        #endregion

        #region Private Static Methods

        private static string GetFbTeams()
        {
            var _qryFbTeamMitglied = DBUtil.OpenSQL(@"SELECT TMI.*,
                                                        TEA.Name
                                                 FROM   FbTeamMitglied TMI
                                                   INNER JOIN FbTeam   TEA ON TEA.FbTeamID = TMI.FbTeamID
                                                 WHERE  UserID = {0}", Session.User.UserID);
            var list = "";
            foreach (DataRow row in _qryFbTeamMitglied.DataTable.Rows)
            {
                if (list != "")
                {
                    list += ",";
                }

                list += row["FbTeamID"].ToString();
            }
            return list;
        }

        #endregion

        #region Private Methods

        private void ApplyBuchungsCode()
        {
            var qry1 = DBUtil.OpenSQL(@"
                            select * ,
                                [Buchungstext] = dbo.fnFbGetBuchungstext([Text], {1})
                            from FbBuchungCode
                            where Code LIKE {0}", QryBuchung["Code"], editDatum.DateTime.Date);
            if (qry1.Count > 0)
            {
                //Mandant
                SqlQuery qry2;
                if (!DBUtil.IsEmpty(qry1["BaPersonID"]))
                {
                    //Gibt es eine aktive Periode für den Mandanten ?
                    qry2 = DBUtil.OpenSQL(@"
                         SELECT PER.FbPeriodeID,
                                PRS.BaPersonID,
                                PRS.Name + isNull(', ' + PRS.Vorname,'') Mandant,
                                isNull(ADR.PLZ + ' ','') + isNull(ADR.Ort,'') PLZOrt,
                                USR.LogonName MTLogon,
                                isNull(USR.FirstName + ' ','') + isNull(USR.LastName,'') MTName
                         FROM FbPeriode PER
                           INNER JOIN BaPerson        PRS ON PRS.BaPersonID = PER.BaPersonID
                           LEFT  JOIN BaAdresse       ADR ON ADR.BaPersonID = PRS.BaPersonID
                                                         AND ADR.AdresseCode = 1
                           LEFT  JOIN FaLeistung      FAL ON FAL.FaLeistungID =
                                                                    (SELECT TOP 1 FaLeistungID
                                                                     FROM   FaLeistung
                                                                     WHERE  BaPersonID = PER.BaPersonID
                                                                        AND ModulID = 5
                                                                     ORDER BY FAL.DatumVon DESC)
                           LEFT  JOIN XUser            USR ON USR.UserId = FAL.UserID
                         WHERE  PER.BaPersonID = {0}
                            AND PER.PeriodeStatusCode = 1
                            AND {1} BETWEEN PER.PeriodeVon AND PER.PeriodeBis",
                        qry1["BaPersonID"],
                        QryBuchung["BuchungsDatum"]);

                    if (qry2.Count > 0)
                    {
                        QryBuchung["FbPeriodeID"] = qry2["FbPeriodeID"];
                        QryBuchung["BaPersonID"] = qry2["BaPersonID"];
                        QryBuchung["Mandant"] = qry2["Mandant"];
                        QryBuchung["PLZOrt"] = qry2["PLZOrt"];
                        QryBuchung["MTLogon"] = qry2["MTLogon"];
                        QryBuchung["MTName"] = qry2["MTName"];
                    }
                }

                //KontoSoll
                if (!DBUtil.IsEmpty(qry1["SollKtoNr"]))
                {
                    QryBuchung["SollKtoNr"] = qry1["SollKtoNr"];

                    if (DBUtil.IsEmpty(QryBuchung["FbPeriodeID"]))
                    {
                        QryBuchung["SollKtoName"] = DBNull.Value;
                    }
                    else
                    {
                        qry2 = DBUtil.OpenSQL(@"
                                SELECT KontoName
                                FROM dbo.FbKonto
                                WHERE FbPeriodeID = {0}
                                  AND KontoNr = {1}", QryBuchung["FbPeriodeID"], QryBuchung["SollKtoNr"]);

                        if (qry2.Count == 0)
                        {
                            QryBuchung["SollKtoName"] = DBNull.Value;
                        }
                        else
                        {
                            QryBuchung["SollKtoName"] = qry2["KontoName"];
                        }
                    }

                    DisplaySaldo(true);
                }

                //KontoHaben
                if (!DBUtil.IsEmpty(qry1["HabenKtoNr"]))
                {
                    QryBuchung["HabenKtoNr"] = qry1["HabenKtoNr"];

                    if (DBUtil.IsEmpty(QryBuchung["FbPeriodeID"]))
                    {
                        QryBuchung["HabenKtoName"] = DBNull.Value;
                    }
                    else
                    {
                        qry2 = DBUtil.OpenSQL(@"
                            SELECT KontoName
                            FROM dbo.FbKonto
                            WHERE FbPeriodeID = {0}
                              AND KontoNr = {1};", QryBuchung["FbPeriodeID"], QryBuchung["HabenKtoNr"]);

                        if (qry2.Count == 0)
                        {
                            QryBuchung["HabenKtoName"] = DBNull.Value;
                        }
                        else
                        {
                            QryBuchung["HabenKtoName"] = qry2["KontoName"];
                        }
                    }
                    DisplaySaldo(false);
                }

                //Text + Betrag
                QryBuchung["Betrag"] = qry1["Betrag"];
                QryBuchung["Text"] = qry1["Buchungstext"];

                QryBuchung.RefreshDisplay();
            }
        }

        private void DisplaySaldo(Boolean sollKto)
        {
            if (_filling) return;

            try
            {
                String fldName;
                Control ctlSaldo;
                Control ctlGrpSaldo;
                KissLabel lbl;

                if (sollKto)
                {
                    fldName = "SollKtoNr";
                    ctlSaldo = editSollSaldo;
                    ctlGrpSaldo = editSollGrpSaldo;
                    lbl = lblGrpSaldoS;
                }
                else
                {
                    fldName = "HabenKtoNr";
                    ctlSaldo = editHabenSaldo;
                    ctlGrpSaldo = editHabenGrpSaldo;
                    lbl = lblGrpSaldoH;
                }

                if (DBUtil.IsEmpty(QryBuchung[fldName]) || DBUtil.IsEmpty(QryBuchung["FbPeriodeID"]))
                {
                    ctlSaldo.Text = "";
                    ctlGrpSaldo.Visible = false;
                    lbl.Visible = false;
                }
                else
                {
                    var qry = DBUtil.OpenSQL(
                        "exec spFbGetSaldo " +
                        QryBuchung["FbPeriodeID"] + "," +
                        QryBuchung[fldName]);

                    ctlSaldo.Text = ((decimal)qry["Saldo"]).ToString("N2");

                    if (!String.IsNullOrEmpty(qry["SaldoGruppeName"].ToString()))
                    {
                        ctlGrpSaldo.Visible = true;
                        lbl.Visible = true;
                        ctlGrpSaldo.Text = ((decimal)qry["GrpSaldo"]).ToString("N2");
                        lbl.Text = qry["SaldoGruppeName"].ToString();
                    }
                    else
                    {
                        ctlGrpSaldo.Visible = false;
                        lbl.Visible = false;
                    }
                }
            }
            catch { }
        }

        private bool KontoErlaubnis(bool sollKto)
        {
            int kontoTypCode;
            if (sollKto)
            {
                if (DBUtil.IsEmpty(QryBuchung["SollKontoTypCode"]))
                {
                    return true;
                }
                kontoTypCode = (int)QryBuchung["SollKontoTypCode"];
            }
            else
            {
                if (DBUtil.IsEmpty(QryBuchung["HabenKontoTypCode"]))
                {
                    return true;
                }
                kontoTypCode = (int)QryBuchung["HabenKontoTypCode"];
            }

            if (DBUtil.IsEmpty(QryBuchung["FbTeamID"]))
            {
                return true;
            }

            var fbTeamId = (int)QryBuchung["FbTeamID"];

            switch (kontoTypCode)
            {
                case 4: // Depot
                case 5: // Wertschriften
                    return CtlFibu.DepotBereich(fbTeamId);
                case 7: // TransferKto
                    return (CtlFibu.StandardBereich(fbTeamId) || CtlFibu.DepotBereich(fbTeamId));
                default:
                    return CtlFibu.StandardBereich(fbTeamId);
            }
        }

        private void NeueSuche()
        {
            if (editMandantX.EditMode == EditModeType.ReadOnly)
            {
                return;
            }

            qryPeriodeX.DataTable.Rows.Clear();

            foreach (var ctl in tpgSuchen.Controls.OfType<BaseEdit>())
            {
                (ctl).EditValue = null;
            }

            editMandantX.Focus();
        }

        private void SetActiveQuery(SqlQuery qry)
        {
            ActiveSQLQuery = qry;

            foreach (IKissBindableEdit ctl in UtilsGui.AllControls(tabControlBuchung).OfType<IKissBindableEdit>())
            {
                (ctl).DataSource = qry;
            }
            ctlFibuZahlungsWeg.DataSource = qry;

            qry.BindControls();
            if (qry.Count == 0) qry.EnableBoundFields(false);
        }

        private void ShowPeriodenX()
        {
            qryPeriodeX.Fill(@"
                SELECT PER.*, STA.Text StatusText
                FROM   FbPeriode PER
                    INNER JOIN XLOVCode STA ON STA.Code = PER.PeriodeStatusCode AND
                                                  STA.LOVName = 'FbPeriodeStatus'
                WHERE BaPersonID = {0}
                ORDER BY PeriodeVon", _baPersonId);
            qryPeriodeX.Last();
        }

        private void Suchen()
        {
            if (qryPeriodeX.Count == 0 &&
                DBUtil.IsEmpty(editDatumVonX.EditValue) &&
                DBUtil.IsEmpty(editDatumBisX.EditValue) &&
                DBUtil.IsEmpty(editBelegNrVonX.EditValue) &&
                DBUtil.IsEmpty(editBelegNrBisX.EditValue) &&
                DBUtil.IsEmpty(editSollVonX.EditValue) &&
                DBUtil.IsEmpty(editSollBisX.EditValue) &&
                DBUtil.IsEmpty(editHabenVonX.EditValue) &&
                DBUtil.IsEmpty(editHabenBisX.EditValue) &&
                DBUtil.IsEmpty(editBetragVonX.EditValue) &&
                DBUtil.IsEmpty(editBetragBisX.EditValue) &&
                DBUtil.IsEmpty(editTextX.EditValue) &&
                DBUtil.IsEmpty(editCodeX.EditValue) &&
                DBUtil.IsEmpty(editErfasstX.EditValue) &&
                DBUtil.IsEmpty(editStatusX.EditValue) &&
                DBUtil.IsEmpty(cboBuchungTyp.EditValue) &&
                DBUtil.IsEmpty(editTeamX.EditValue))
            {
                KissMsg.ShowInfo("CtlFibuBuchung", "Min1Suchfeld", "Mindestens ein Suchfeld muss ausgefüllt sein");
                return;
            }

            Cursor.Current = Cursors.WaitCursor;

            var sql = "";

            // Mandan/Periode
            if (qryPeriodeX.Count > 0)
            {
                sql += FibuUtilities.AndOrWhere(sql) + " FbPeriodeID = " + DBUtil.SqlLiteral(qryPeriodeX["FbPeriodeID"]);
            }

            // Datum
            if (!DBUtil.IsEmpty(editDatumVonX.EditValue))
            {
                if (!DBUtil.IsEmpty(editDatumBisX.EditValue))
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " BuchungsDatum >= " + DBUtil.SqlLiteral(editDatumVonX.DateTime) +
                        "                   and BuchungsDatum < DATEADD(day, 1, " + DBUtil.SqlLiteral(editDatumBisX.DateTime) + ")";
                }
                else
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " BuchungsDatum >= " + DBUtil.SqlLiteral(editDatumVonX.DateTime) +
                        "                   and BuchungsDatum < DATEADD(day, 1, " + DBUtil.SqlLiteral(editDatumVonX.DateTime) + ")";
                }
            }

            // BelegNr
            if (!DBUtil.IsEmpty(editBelegNrVonX.EditValue))
            {
                if (editBelegNrBisX.Text != "")
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " BelegNr between " + DBUtil.SqlLiteral(editBelegNrVonX.EditValue) +
                        "                   and " + DBUtil.SqlLiteral(editBelegNrBisX.EditValue);
                }
                else
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " BelegNr = " + DBUtil.SqlLiteral(editBelegNrVonX.EditValue);
                }
            }

            // Konto Soll
            if (editSollVonX.Text != "")
            {
                if (editSollBisX.Text != "")
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " SollKtoNr between " + DBUtil.SqlLiteral(editSollVonX.Text) +
                        "               and " + DBUtil.SqlLiteral(editSollBisX.Text);
                }
                else
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " SollKtoNr = " + DBUtil.SqlLiteral(editSollVonX.Text);
                }
            }

            // Konto Haben
            if (editHabenVonX.Text != "")
            {
                if (editHabenBisX.Text != "")
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " HabenKtoNr between " + DBUtil.SqlLiteral(editHabenVonX.Text) +
                        "                and " + DBUtil.SqlLiteral(editHabenBisX.Text);
                }
                else
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " HabenKtoNr = " + DBUtil.SqlLiteral(editHabenVonX.Text);
                }
            }

            // Betrag
            if (editBetragVonX.Text != "")
            {
                if (editBetragBisX.Text != "")
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " Betrag between " + DBUtil.SqlLiteral(editBetragVonX.Value) +
                        "            and " + DBUtil.SqlLiteral(editBetragBisX.Value);
                }
                else
                {
                    sql += FibuUtilities.AndOrWhere(sql) + " Betrag = " + DBUtil.SqlLiteral(editBetragVonX.Value);
                }
            }

            // Text
            if (editTextX.Text != "")
            {
                var suchbegriff = editTextX.Text;

                suchbegriff = suchbegriff.Replace("*", "%");
                sql += FibuUtilities.AndOrWhere(sql) + " Text like " + DBUtil.SqlLiteral("%" + suchbegriff + "%");
            }

            // Code
            if (editCodeX.Text != "")
            {
                sql += FibuUtilities.AndOrWhere(sql) + " Code = " + DBUtil.SqlLiteral(editCodeX.Text);
            }

            // Erfasst
            if (!DBUtil.IsEmpty(editErfasstX.EditValue))
            {
                sql += FibuUtilities.AndOrWhere(sql) + " ErfName = " + DBUtil.SqlLiteral(editErfasstX.EditValue);
            }

            // Status
            if (!DBUtil.IsEmpty(editStatusX.EditValue))
            {
                sql += FibuUtilities.AndOrWhere(sql) + "Status = " + DBUtil.SqlLiteral(editStatusX.EditValue);
            }

            // Buchungtyp
            if (!DBUtil.IsEmpty(cboBuchungTyp.EditValue))
            {
                sql += FibuUtilities.AndOrWhere(sql) + "BuchungTypCode = " + DBUtil.SqlLiteral(cboBuchungTyp.EditValue);
            }

            //Team
            if (!DBUtil.IsEmpty(editTeamX.EditValue))
            {
                sql += FibuUtilities.AndOrWhere(sql) + " FbTeamID = " + DBUtil.SqlLiteral(editTeamX.EditValue);
            }

            sql = "select * from viewFbBuchungen " + sql + " order by BuchungsDatum";

            _filling = true;
            qryFbBuchung.Fill(sql);
            _filling = false;

            qryFbBuchung.Last();

            tabControlListen.SelectedTabIndex = 1;
            qryBuchung_PositionChanged(this, new EventArgs());

            Cursor.Current = Cursors.Default;
        }

        private void UpdateEditTextAndShowPerioden(DlgAuswahl dlg)
        {
            if (dlg == null)
            {
                return;
            }

            if (DBUtil.IsEmpty(dlg["BaPersonID"]))
            {
                _baPersonId = 0;
            }
            else
            {
                _baPersonId = (int)dlg["BaPersonID"];
            }

            editMandantNrX.Text = dlg["BaPersonID"].ToString();
            editMandantX.Text = dlg["Mandant"].ToString();
            editPlzOrtX.Text = dlg["PLZOrt"].ToString();
            editMTX.Text = dlg["MTName"].ToString();
            ShowPeriodenX();
        }

        private void UpdateQryBuchungAndRefreshKonti(DlgAuswahl dlg)
        {
            QryBuchung["FbPeriodeID"] = dlg["FbPeriodeID"];
            QryBuchung["FbTeamID"] = dlg["FbTeamID"];
            QryBuchung["BaPersonID"] = dlg["BaPersonID"];
            QryBuchung["Mandant"] = dlg["Mandant"];
            QryBuchung["PLZOrt"] = dlg["PLZOrt"];
            QryBuchung["MTLogon"] = dlg["MTLogon"];
            QryBuchung["MTName"] = dlg["MTName"];

            if (DBUtil.GetConfigBool(@"System\Fibu\Buchen\GenerateBelegNrProMandant", false))
            {
                //if there is no datarow for this person, insert it with default values, otherwise just get next BelegNr
                var qry = DBUtil.OpenSQL(@"
                        IF NOT EXISTS(SELECT 1 FROM FbBelegNr WHERE BaPersonID = {0})
                           BEGIN DECLARE @nextID INT
                              SET @nextID = (
                                SELECT MAX(BUC.BelegNr)+1
                                FROM       FbBuchung BUC
                          INNER JOIN FbPeriode PRD ON PRD.FbPeriodeID = BUC.FbPeriodeID
                          WHERE PRD.BaPersonID = {0}
                             AND ISNUMERIC(CONVERT(VARCHAR,BUC.BelegNr)) = 1
                          GROUP BY BaPersonID)
                              INSERT INTO FbBelegNr (BelegNrCode, UserID, NaechsteBelegNr, BelegNrVon, BelegNrBis, Praefix, BaPersonID)
                              VALUES (4, NULL, IsNull(@nextID, 1), 1, 2147483647, NULL, {0})
                            END
                        SELECT Praefix, NaechsteBelegNr
                        FROM FbBelegNr
                        WHERE BaPersonID = {0}",
                    dlg["BaPersonID"]);

                QryBuchung["BelegNr"] = qry["Praefix"].ToString() + qry["NaechsteBelegNr"];
            }

            //Mandantenwechsel => refresh Konti
            if (!DBUtil.IsEmpty(QryBuchung["SollKtoNr"]))
            {
                SqlQuery qry = DBUtil.OpenSQL(@"
                        select FbKontoID,KontoNr,KontoName
                        from   FbKonto
                        where  FbPeriodeID = {0} and
                               KontoNr = {1}",
                    QryBuchung["FbPeriodeID"],
                    QryBuchung["SollKtoNr"]);

                if (qry.Count == 0)
                {
                    QryBuchung["SollKtoNr"] = DBNull.Value;
                    QryBuchung["SollKtoName"] = DBNull.Value;
                }
                else
                {
                    QryBuchung["SollKtoNr"] = qry["KontoNr"];
                    QryBuchung["SollKtoName"] = qry["KontoName"];
                }
                DisplaySaldo(true);
            }

            if (!DBUtil.IsEmpty(QryBuchung["HabenKtoNr"]))
            {
                SqlQuery qry = DBUtil.OpenSQL(@"
                        select FbKontoID,KontoNr,KontoName
                        from   FbKonto
                        where  FbPeriodeID = {0} and
                               KontoNr = {1}",
                    QryBuchung["FbPeriodeID"],
                    QryBuchung["HabenKtoNr"]);

                if (qry.Count == 0)
                {
                    QryBuchung["HabenKtoNr"] = DBNull.Value;
                    QryBuchung["HabenKtoName"] = DBNull.Value;
                }
                else
                {
                    QryBuchung["HabenKtoNr"] = qry["KontoNr"];
                    QryBuchung["HabenKtoName"] = qry["KontoName"];
                }
                DisplaySaldo(false);
            }
            QryBuchung.RefreshDisplay();
        }

        #endregion

        #endregion
    }
}