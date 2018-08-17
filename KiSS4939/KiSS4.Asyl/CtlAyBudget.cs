using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Asyl
{
    public partial class CtlAyBudget : KissUserControl
    {
        private const string MSG_BgBudget_11 = @"Das Monatsbudget ist in Vorbereitung
 - Es kann bearbeitet werden
 - Alle Auszahlungen sind gesperrt";

        private const string MSG_BgBudget_12 = @"Das Monatsbudget ist zur Zahlung freigegeben
 - Es kann nicht bearbeitet werden
 - Auszahlungen sind möglich";

        private const string MSG_BgBudget_13 = @"Das Monatsbudget ist abgeschlossen, rsp. gesperrt worden
 - Es kann jetzt nicht bearbeitet werden
 - Alle Auszahlungen sind gesperrt";

        private readonly BgBewilligungStatus _bgBewilligungStatus;
        private readonly int _bgBudgetID;
        private readonly int _bgFinanzplanID;
        private readonly Hashtable _htBackColor = new Hashtable();

        private bool _reloadTree;

        public CtlAyBudget()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent call
            grvBgPosition.OptionsCustomization.AllowFilter = false;
            grvBgPosition.OptionsCustomization.AllowGroup = false;
            grvBgPosition.OptionsCustomization.AllowSort = false;

            tbnButget.Pushed = true;
            grdKbBuchung.Visible = false;

            colKbBuchung_KbBuchungStatusCode.ColumnEdit = grdKbBuchung.GetLOVLookUpEdit("KbBuchungsStatus");
            colKbBuchung_KbAuszahlungsArtCode.ColumnEdit = grdKbBuchung.GetLOVLookUpEdit("KbAuszahlungsArt");

            colKbBuchungKostenart_BgKostenartID.ColumnEdit = grdKbBuchung.GetLOVLookUpEdit(AyUtil.GetSqlQueryKostenart(), "BgKostenartID", "Text");

            _htBackColor[21] = Color.LimeGreen;
            _htBackColor[22] = Color.Yellow;
            _htBackColor[23] = Color.DarkGray;

            _htBackColor[83] = Color.LightSalmon;
            _htBackColor[84] = Color.Khaki;
            _htBackColor[85] = Color.LightGreen;

            _htBackColor[41] = Color.Tomato;

            string[] colorCodes = DBUtil.GetConfigString(@"System\Asyl\BudgetFarben", "").Split(',');
            for (int i = 0; i < colorCodes.Length; i++)
            {
                try
                {
                    switch (i)
                    {
                        case 0: _htBackColor[1] = Color.FromArgb(int.Parse(colorCodes[i])); break;
                        case 1: _htBackColor[2] = Color.FromArgb(int.Parse(colorCodes[i])); break;

                        case 2: _htBackColor[11] = Color.FromArgb(int.Parse(colorCodes[i])); break;
                        case 3: _htBackColor[12] = Color.FromArgb(int.Parse(colorCodes[i])); break;

                        case 4: _htBackColor[21] = Color.FromArgb(int.Parse(colorCodes[i])); break;
                        case 5: _htBackColor[22] = Color.FromArgb(int.Parse(colorCodes[i])); break;
                        case 6: _htBackColor[23] = Color.FromArgb(int.Parse(colorCodes[i])); break;

                        case 7: _htBackColor[81] = Color.FromArgb(int.Parse(colorCodes[i])); break;
                        case 8: _htBackColor[82] = Color.FromArgb(int.Parse(colorCodes[i])); break;

                        case 10: _htBackColor[83] = Color.FromArgb(int.Parse(colorCodes[i])); break;
                        case 11: _htBackColor[84] = Color.FromArgb(int.Parse(colorCodes[i])); break;
                        case 12: _htBackColor[85] = Color.FromArgb(int.Parse(colorCodes[i])); break;

                        case 13: _htBackColor[41] = Color.FromArgb(int.Parse(colorCodes[i])); break;
                        case 14: _htBackColor[31] = Color.FromArgb(int.Parse(colorCodes[i]));
                            _htBackColor[61] = Color.FromArgb(int.Parse(colorCodes[i])); break;
                    }
                }
                catch { }
            }
        }

        public CtlAyBudget(Image titelImage, int bgBudgetID, int bgFinanzplanID)
            : this()
        {
            picTitel.Image = titelImage;
            _bgFinanzplanID = bgFinanzplanID;
            _bgBudgetID = bgBudgetID;

            _bgBewilligungStatus = (BgBewilligungStatus)DBUtil.ExecuteScalarSQL("SELECT BgBewilligungStatusCode FROM dbo.BgFinanzplan WHERE BgFinanzplanID = {0}", _bgFinanzplanID);

            qryBgBudget.Fill(_bgBudgetID);

            qryBgPosition.Fill(_bgBudgetID);
        }

        public override string GetContextName()
        {
            if ((bool)qryBgBudget["MasterBudget"])
            {
                return "AyMasterbudget";
            }

            return "AyMonatsbudget";
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BGBUDGETID":
                    return _bgBudgetID;

                case "BGFINANZPLANID":
                    return _bgFinanzplanID;
            }

            return base.GetContextValue(fieldName);
        }

        public override void OnRefreshData()
        {
            base.OnRefreshData();

            if (grdBgPosition.Visible)
                qryBgPosition.Refresh();
            else
                qryKbBuchung.Refresh();
        }

        public void ShowEinzelzahlung(int bgPositionID)
        {
            CtlAyEinzelzahlung sez = new CtlAyEinzelzahlung(_bgBudgetID, bgPositionID);

            KissDialog dlg = new DlgKissUserControl(string.Format("Einzelzahlung, #{0}", bgPositionID), sez);

            dlg.ShowDialog(this);
            if (!dlg.UserCancel)
                qryBgPosition.Refresh();
        }

        public void ShowPosition(int bgPositionID)
        {
            BgKategorie bgKategorieCode = (BgKategorie)DBUtil.ExecuteScalarSQL(
                "SELECT BgKategorieCode FROM dbo.BgPosition WHERE BgPositionID = {0}"
                , bgPositionID);

            ShowPosition(bgKategorieCode, bgPositionID);
        }

        internal void ResetBudget()
        {
            if ((bool)qryBgBudget["MasterBudget"] && (int)qryBgBudget["BgBewilligungStatusCode"] != (int)BgBewilligungStatus.Erteilt)
            {
                KissMsg.ShowInfo("CtlAyBudget", "MasterbudgetGesperrt", "Masterbudget kann nicht zurückgesetzt werden");
            }
            else if (!(bool)qryBgBudget["MasterBudget"] && (int)qryBgBudget["BgBewilligungStatusCode"] >= (int)BgBewilligungStatus.Erteilt)
            {
                KissMsg.ShowInfo("CtlAyBudget", "MonatsbudgetGesperrt", "Monatsbudget kann nicht zurückgesetzt werden");
            }
            else
            {
                DBUtil.ExecSQL(120,
                    "EXECUTE spAyBudget_Reset {0}, {1}"
                    , _bgFinanzplanID, _bgBudgetID);
                qryBgPosition.Refresh();
            }
        }

        private void grdBudget_DoubleClick(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryBgPosition["BgPositionID"])) return;

            BgKategorie bgKategorie = (BgKategorie)qryBgPosition["BgKategorieCode"];
            switch (bgKategorie)
            {
                case BgKategorie.Einzelzahlung:
                case BgKategorie.ZusaetzlicheLeistung:
                    ShowEinzelzahlung((int)qryBgPosition["BgPositionID"]);
                    break;

                default:
                    ShowPosition(bgKategorie, (int)qryBgPosition["BgPositionID"]);
                    break;
            }
        }

        private void grvBgPosition_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == null) return;

            // no custom customization for selected rows
            if (grvBgPosition.GetSelectedRows() != null && grvBgPosition.GetSelectedRows()[0] == e.RowHandle) return;

            try
            {
                object styleNr = grvBgPosition.GetRowCellValue(e.RowHandle, colStyle);

                if (styleNr is int && _htBackColor.ContainsKey((int)styleNr))
                    e.Appearance.BackColor = (Color)_htBackColor[(int)styleNr];
            }
            catch { }
        }

        private void mnuNeu_Click(object sender, EventArgs e)
        {
            DlgAyPosition dlg;

            if (_bgBewilligungStatus == BgBewilligungStatus.Gesperrt)
            {
                KissMsg.ShowInfo("CtlAyBudget", "MasterbudgetAbgelaufen", "Das Mastebudget ist bereits abgelaufen.");
                return;
            }

            if (sender == mnuNeu_Einnahme)
            {
                dlg = new DlgAyPosition(_bgBudgetID, BgKategorie.Einnahmen);
            }
            else if (sender == mnuNeu_Ausgaben)
            {
                if ((bool)qryBgBudget["MasterBudget"] == false)
                {
                    KissMsg.ShowInfo("CtlAyBudget", "AusgabenErfassenNichtMoeglich", "In einem Monatsbudget können keine Ausgaben erfasst werden.");
                    return;
                }
                dlg = new DlgAyPosition(_bgBudgetID, BgKategorie.Ausgaben);
            }
            else if (sender == mnuNeu_Vorabzug)
            {
                dlg = new DlgAyPosition(_bgBudgetID, BgKategorie.Vorabzug);
            }
            else if (sender == mnuNeu_Kuerzung)
            {
                dlg = new DlgAyPosition(_bgBudgetID, BgKategorie.Kuerzung);
            }
            else
            {
                return;
            }

            if (!((IKissDataNavigator)dlg).AddData()) return;

            dlg.ShowDialog(this);
            if (!dlg.UserCancel)
            {
                qryBgPosition.Refresh();
            }
        }

        private void mnuNeu_Einzelzahlung_Click(object sender, EventArgs e)
        {
            if ((bool)qryBgBudget["MasterBudget"])
            {
                KissMsg.ShowInfo("CtlAyBudget", "EinzelzahlErfassenNichtMoeglich", "In einem Masterbudget können keine Einzelzahlungen erfasst werden.");
                return;
            }
            else if ((int)qryBgBudget["BgBewilligungStatusCode"] == (int)BgBewilligungStatus.Gesperrt)
            {
                KissMsg.ShowInfo("CtlAyBudget", "NeueEinzelzahlNichtZulaessig", "Das Monatsbuget ist gesperrt. Neue Einzelzahlungen sind nicht zulässig.");
                return;
            }

            CtlAyEinzelzahlung sez = new CtlAyEinzelzahlung(_bgBudgetID);
            if (!((IKissDataNavigator)sez).AddData()) return;

            DlgKissUserControl dlg = new DlgKissUserControl("Einzelzahlung", sez);
            dlg.ShowDialog(this);
            if (!dlg.UserCancel)
                qryBgPosition.Refresh();
        }

        private void qryBgBudget_AfterPost(object sender, EventArgs e)
        {
            if (_reloadTree) FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryBgBudget_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            qryBgPosition.Delete();
            throw new KissCancelException();
        }

        private void qryBgBudget_BeforeInsert(object sender, EventArgs e)
        {
            BgBewilligungStatus status = (BgBewilligungStatus)DBUtil.ExecuteScalarSQL("SELECT BgBewilligungStatusCode FROM dbo.BgFinanzplan WHERE BgFinanzplanID = {0}", _bgFinanzplanID);

            switch (status)
            {
                case BgBewilligungStatus.InVorbereitung:
                case BgBewilligungStatus.Angefragt:
                case BgBewilligungStatus.Abgelehnt:
                    KissMsg.ShowInfo("CtlAyBudget", "MasterbudgetMussBewilligtWerden", "Bevor ein neues Monatsbudget erzeugt werden kann muss das Masterbudget bewilligt werden.");
                    return;

                case BgBewilligungStatus.Gesperrt:
                    KissMsg.ShowInfo("CtlAyBudget", "MonatsbudgetNichtErzeugt", "Ein neues Monatsbudget kann nicht erzeugt werden, da das Masterbudget abgelaufen ist.");
                    return;
            }

            object bgBudgetID = _bgBudgetID;
            Session.BeginTransaction();
            try
            {
                bgBudgetID = DBUtil.ExecuteScalarSQLThrowingException(
                    "EXECUTE spAyBudget_Create {0}"
                    , _bgFinanzplanID);

                if (DBUtil.IsEmpty(bgBudgetID))
                {
                    throw new KissInfoException(
                        KissMsg.GetMLMessage(
                            "CtlAyBudget",
                            "EnthaeltAlleBudgets",
                            "Es existieren bereits sämtliche Monatsbudgets.",
                            KissMsgCode.MsgInfo));
                }

                SqlQuery qry = AyUtil.GetBgBewilligung_Neu();
                qry["BgBewilligungCode"] = 101;
                qry["BgBudgetID"] = bgBudgetID;
                qry.Post();

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }
            finally
            {
                FormController.SendMessage("FrmFall", "Action", "RefreshTree");
                GetKissMainForm().ShowItem(ModulID.A, "BBG", ((int?)bgBudgetID) ?? _bgBudgetID);
                //TODO weshalb wird immer die CancelException geworfen???
                throw new KissCancelException();
            }
        }

        private void qryBgBudget_BeforePost(object sender, EventArgs e)
        {
            _reloadTree = qryBgBudget.ColumnModified("BgBewilligungStatusCode");
        }

        private void qryBgBudget_PositionChanged(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(qryBgBudget["MasterBudget"])) return;
            if (DBUtil.IsEmpty(qryBgBudget["BgBewilligungStatusCode"])) return;

            try
            {
                if ((bool)qryBgBudget["MasterBudget"])
                {
                    lblTitel.Text = "Masterbudget";

                    tbnVorbereitung.Enabled = false;
                    tbnBewilligt.Enabled = false;
                    tbnGesperrt.Enabled = false;

                    tbnBelege.Enabled = false;
                }
                else
                {
                    DateTime dateBudget = new DateTime(Convert.ToInt32(qryBgBudget["Jahr"]), Convert.ToInt32(qryBgBudget["Monat"]), 1);

                    SqlQuery qry = DBUtil.OpenSQL(@"
                        SELECT Dauer = ' (' + CONVERT(varchar, dbo.fnMAX(SFP.DatumVon, dbo.fnFirstDayOf({1})), 104) + ' bis ' + CONVERT(varchar, dbo.fnMIN(SFP.DatumBis, dbo.fnLastDayOf({1})), 104) + ')'
                        FROM dbo.BgBudget             BBG
                          INNER JOIN dbo.BgFinanzplan SFP ON SFP.BgFinanzplanID = BBG.BgFinanzplanID
                        WHERE BBG.BgBudgetID = {0}
                          AND (SFP.DatumVon > dbo.fnFirstDayOf({1}) OR SFP.DatumBis < dbo.fnLastDayOf({1}))"
                        , qryBgBudget["BgBudgetID"], dateBudget);

                    lblTitel.Text = String.Format("Monatsbudget {0:MMMM yyyy}{1}",
                        dateBudget, qry["Dauer"]);

                    tbnVorbereitung.Enabled = DBUtil.UserHasRight(Name, "U");
                    tbnBewilligt.Enabled = DBUtil.UserHasRight(Name, "U");
                    tbnGesperrt.Enabled = DBUtil.UserHasRight(Name, "U");

                    tbnBelege.Enabled = true;

                    tbnVorbereitung.Pushed = false;
                    tbnBewilligt.Pushed = false;
                    tbnGesperrt.Pushed = false;

                    switch ((BgBewilligungStatus)qryBgBudget["BgBewilligungStatusCode"])
                    {
                        case BgBewilligungStatus.InVorbereitung:
                        case BgBewilligungStatus.Angefragt:
                        case BgBewilligungStatus.Abgelehnt:
                            tbnVorbereitung.Enabled = true;
                            tbnVorbereitung.Pushed = true;
                            break;

                        case BgBewilligungStatus.Erteilt:
                            tbnBewilligt.Enabled = true;
                            tbnBewilligt.Pushed = true;
                            break;

                        case BgBewilligungStatus.Gesperrt:
                            tbnGesperrt.Enabled = true;
                            tbnGesperrt.Pushed = true;
                            break;
                    }
                }
            }
            catch { }
        }

        private void qryKbBuchung_AfterFill(object sender, EventArgs e)
        {
            System.Data.DataSet ds = qryKbBuchung.DataSet;

            ds.Relations.Add("BelegDetail",
                ds.Tables[0].Columns["KbBuchungID"],
                ds.Tables[1].Columns["KbBuchungID"]);
        }

        private void ShowPosition(BgKategorie bgKategorieCode, int bgPositionID)
        {
            if (bgKategorieCode == BgKategorie.Ausgaben)
            {
                int bgGruppeCode = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT BPT.BgGruppeCode
                    FROM dbo.BgPosition             BPO
                      INNER JOIN dbo.BgPositionsart BPT ON BPT.BgPositionsartID = BPO.BgPositionsartID
                    WHERE BPO.BgPositionID = {0}",
                    bgPositionID);
                if (bgGruppeCode == 6020)
                {
                    KissMsg.ShowInfo("CtlAyBudget", "ErwerbsunkostenViaNettolohnAendern", "Erwerbsunkosten können nur via 'Nettolohn'-Position verändert werden");
                    return;
                }
            }

            KissDialog dlg = new DlgAyPosition(_bgBudgetID, bgKategorieCode, bgPositionID);

            dlg.ShowDialog(this);
            if (!dlg.UserCancel)
                qryBgPosition.Refresh();
        }

        private void toolBarBudget_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Style == ToolBarButtonStyle.ToggleButton && !e.Button.Pushed)
            {
                e.Button.Pushed = true; return;
            }

            try
            {
                if (e.Button.Style == ToolBarButtonStyle.ToggleButton)
                    e.Button.Pushed = false;

                SqlQuery qry;
                int cntBeleg;

                switch (toolBarBudget.Buttons.IndexOf(e.Button))
                {
                    case 0: // neu
                        ((IKissDataNavigator)this).AddData();
                        return;

                    case 1: // Reset
                        if (!qryBgBudget.CanUpdate) return;

                        ResetBudget();
                        return;

                    case 3: // Vorbereitung
                        if (!qryBgBudget.CanUpdate) return;

                        if (0 < (int)DBUtil.ExecuteScalarSQL(@"
                            SELECT COUNT(*)
                            FROM dbo.KbBuchung BUC
                            WHERE BUC.BgBudgetID = {0} AND BUC.KbBuchungStatusCode NOT IN (1, 2, 7)"
                            , qryBgBudget["BgBudgetID"]))
                        {
                            KissMsg.ShowInfo("CtlAyBudget", "StatusAendernNichtMoeglich", "Der Status kann nicht zu 'In Vorbereitung' zurückgesetzt werden, da mindestens ein Beleg verbucht wurde. Informieren Sie Ihren Buchhalter, er kann die Belege des Monatsbudget zurücksetzen.");
                            return;
                        }

                        tbnBewilligt.Pushed = false;
                        tbnGesperrt.Pushed = false;
                        qryBgBudget["BgBewilligungStatusCode"] = BgBewilligungStatus.InVorbereitung;
                        qryBgBudget.Post();

                        cntBeleg = (int)DBUtil.ExecuteScalarSQL(@"
                            UPDATE KbBuchung
                              SET KbBuchungStatusCode = 1
                            WHERE BgBudgetID = {0}

                            SELECT @@RowCount"
                            , _bgBudgetID);

                        qry = AyUtil.GetBgBewilligung_Neu();
                        qry["BgBudgetID"] = _bgBudgetID;
                        qry["BgBewilligungCode"] = 102; // Monatsbudget zur Bearbeitung freigegeben
                        qry["Bemerkung"] = string.Format("Es wurden alle {0} Belege zur Bearbeitung freigegeben", cntBeleg);
                        qry.Post();

                        KissMsg.ShowInfo(MSG_BgBudget_11);

                        if (tbnBelege.Pushed) qryKbBuchung.Refresh();
                        break;

                    case 4: // Bewilligt
                        if (!qryBgBudget.CanUpdate) return;

                        //						if ( !(bool)DBUtil.GetUserPermission(Permission.Ay_Monatsbudget_Freigeben, false) ) {  // Sozialhilfe: Monatsbudget darf zur Zahlung freigegeben werden
                        //							KissMsg.ShowInfo("CtlAyBudget", "KeineBefugnisZahlung", "Sie haben nicht die Befugnis, ein Monatsbudget zur Zahlung freizugeben");
                        //							return;
                        //						}

                        qry = AyUtil.GetBgBewilligung_Neu();
                        qry["BgBudgetID"] = _bgBudgetID;
                        qry["BgBewilligungCode"] = 103; // Monatsbudget zur Zahlung freigegeben

                        Session.BeginTransaction();
                        try
                        {
                            if (0 < (int)DBUtil.ExecuteScalarSQL(@"
                            SELECT COUNT(*)
                            FROM dbo.KbBuchung BUC
                            WHERE BUC.BgBudgetID = {0} AND BUC.KbBuchungStatusCode NOT IN (1, 2, 7)"
                                , qryBgBudget["BgBudgetID"]))
                            {
                                cntBeleg = (int)DBUtil.ExecuteScalarSQL(@"
                                UPDATE KbBuchung
                                  SET KbBuchungStatusCode = 2
                                WHERE BgBudgetID = {0} AND KbBuchungStatusCode = 7

                                SELECT @@RowCount"
                                    , _bgBudgetID);

                                qry["Bemerkung"] = string.Format("Es wurden {0} gesperrte Belege zur Zahlung freigegeben", cntBeleg);
                            }
                            else
                            {
                                qryBgBudget["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.InVorbereitung;
                                qryBgBudget.Post();

                                DBUtil.ExecSQLThrowingException(120,
                                    "EXECUTE spAyBudget_CreateKbBuchung {0}, 2, {1}"
                                    , _bgBudgetID
                                    , Session.User.UserID);
                            }

                            qryBgBudget["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Erteilt;
                            qryBgBudget.Post();

                            qry.Post();
                            Session.Commit();
                        }
                        catch (Exception transEx)
                        {
                            Session.Rollback();
                            KissMsg.ShowError(null, null, transEx.Message, transEx);
                        }
                        tbnVorbereitung.Pushed = false;
                        tbnGesperrt.Pushed = false;

                        KissMsg.ShowInfo(MSG_BgBudget_12);

                        if (tbnBelege.Pushed) qryKbBuchung.Refresh();
                        break;

                    case 5: // Gesperrt
                        if (!qryBgBudget.CanUpdate) return;

                        tbnVorbereitung.Pushed = false;
                        tbnBewilligt.Pushed = false;
                        qryBgBudget["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Gesperrt;
                        qryBgBudget.Post();

                        cntBeleg = (int)DBUtil.ExecuteScalarSQL(@"
                            UPDATE KbBuchung
                              SET KbBuchungStatusCode = 7
                            WHERE BgBudgetID = {0} AND KbBuchungStatusCode IN (2)

                            SELECT @@RowCount"
                            , _bgBudgetID);

                        qry = AyUtil.GetBgBewilligung_Neu();
                        qry["BgBudgetID"] = _bgBudgetID;
                        qry["BgBewilligungCode"] = 105; // Monatsbudget per sofort blockiert
                        qry["Bemerkung"] = string.Format("Es wurden {0} nicht verbuchte Belege gesperrt", cntBeleg);
                        qry.Post();

                        KissMsg.ShowInfo(MSG_BgBudget_13);

                        if (tbnBelege.Pushed) qryKbBuchung.Refresh();
                        break;

                    case 7: // Budget
                        grdKbBuchung.Dock = DockStyle.None;
                        grdKbBuchung.Visible = false;
                        grdBgPosition.Dock = DockStyle.Fill;
                        grdBgPosition.Visible = true;

                        tbnBelege.Pushed = false;
                        break;

                    case 8: // Belege
                        if (!(bool)qryBgBudget["MasterBudget"] && (int)qryBgBudget["BgBewilligungStatusCode"] < (int)BgBewilligungStatus.Erteilt)
                            DBUtil.ExecSQLThrowingException(120,
                                "EXECUTE spAyBudget_CreateKbBuchung {0}, 1, {1}"
                                , _bgBudgetID
                                , Session.User.UserID);

                        qryKbBuchung.Fill(_bgBudgetID);

                        grdBgPosition.Dock = DockStyle.None;
                        grdKbBuchung.Visible = true;
                        grdKbBuchung.Dock = DockStyle.Fill;
                        grdBgPosition.Visible = false;

                        tbnButget.Pushed = false;
                        break;

                    case 12: // Bewilligung Info
                        DlgAyVerlaufBudget dlg = new DlgAyVerlaufBudget(_bgBudgetID);
                        dlg.ShowDialog(this);
                        break;
                }

                if (e.Button.Style == ToolBarButtonStyle.ToggleButton)
                    e.Button.Pushed = true;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(null, null, ex.Message, ex);
            }
        }
    }
}