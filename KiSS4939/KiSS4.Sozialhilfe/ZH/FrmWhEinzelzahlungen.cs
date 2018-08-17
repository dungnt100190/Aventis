using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;
using KiSS4.Messages;
using DlgAuswahlBaZahlungsweg = KiSS4.Common.ZH.DlgAuswahlBaZahlungsweg;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class FrmWhEinzelzahlungen : KissSearchForm, IBelegleser
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "FrmWhEinzelzahlungen";
        private const string KOA_TEXT = "LA";
        private const string TYPEFULLNAME = "KiSS4.Sozialhilfe.ZH.FrmWhEinzelzahlungen";

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        private int _baPersonId;
        private ShBuchungstext _buchungstext;
        private bool _filling;
        private bool _freigegebeneMutieren;
        private int? _kontrolleUserId;
        private int _kostenart;
        private int _newBgKategorieCode;
        private bool _newPosition;
        private object _origVerwPeriodeBis;
        private object _origVerwPeriodeVon;
        private List<Task> _tasks = new List<Task>();

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        public FrmWhEinzelzahlungen()
        {
            InitializeComponent();

            new Belegleser(this);
        }

        #endregion Constructors

        #region EventHandlers

        private void btnAlle_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            Cursor = Cursors.WaitCursor;
            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if ((int)row["Status"] == 1)
                {
                    row["Sel"] = true;
                    row.AcceptChanges();
                }
            }

            qryBgPosition.RowModified = false;
            Cursor = Cursors.Default;
        }

        private void btnDocument_Click(object sender, EventArgs e)
        {
            DocumentImport();
        }

        private void btnEinzelzahlungen_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            int totalcount = 0;
            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    totalcount++;
                }
            }

            if (totalcount == 0)
            {
                return;
            }

            if (totalcount == 1)
            {
                if (!KissMsg.ShowQuestion(string.Format("Soll 1 Einzelzahlung angefragt werden?")))
                {
                    return;
                }
            }
            else
            {
                if (!KissMsg.ShowQuestion(string.Format("Sollen {0} Einzelzahlungen angefragt werden?", totalcount)))
                {
                    return;
                }
            }

            Cursor = Cursors.WaitCursor;

            if (totalcount > 1)
            {
                lblFortschritt.Visible = true;
            }

            int count = 0;
            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if (!DBUtil.IsEmpty(row["Sel"]) && (bool)row["Sel"])
                {
                    count++;

                    lblFortschritt.Text = string.Format("{0}/{1}", count, totalcount);
                    ApplicationFacade.DoEvents();
                }
            }

            lblFortschritt.Visible = false;
            Cursor = Cursors.Default;

            qryBgPosition.Refresh();
        }

        private void btnKeine_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            Cursor = Cursors.WaitCursor;
            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if ((int)row["Status"] == 1)
                {
                    row["Sel"] = false;
                    row.AcceptChanges();
                }
            }

            qryBgPosition.RowModified = false;
            Cursor = Cursors.Default;
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            if (qryMonatsbudget.Count == 0)
            {
                return;
            }

            string pfad = String.Format(@"CtlWhFinanzplan{0}\BBG{1}", qryMonatsbudget["BgFinanzplanID"], qryMonatsbudget["BgBudgetID"]);

            FormController.OpenForm(
                "FrmFall",
                "Action",
                "JumpToNodeByFieldValue",
                "BaPersonID",
                qryMonatsbudget["FallBaPersonID"],
                "ModulID",
                3,
                "FieldValue",
                pfad);
        }

        private void btnPositionBewilligung_Click(object sender, EventArgs e)
        {
            if (qryBgPosition.Count == 0)
            {
                return;
            }

            if (!qryBgPosition.Post())
            {
                return;
            }

            if ((LOV.BgKategorieCode)qryBgPosition["BgKategorieCode"] != LOV.BgKategorieCode.Zusaetzliche_Leistungen)
            {
                return;
            }

            if ((BgBewilligungStatus)qryBgPosition["BgBewilligungStatusCode"] == BgBewilligungStatus.Erteilt)
            {
                var dlg = new DlgWhPositionVisieren((int)qryBgPosition["BgPositionID"], BewilligungAktionZH.Aufheben, Name);

                dlg.ShowDialog(this);
                if (dlg.UserCancel)
                {
                    return;
                }

                try
                {
                    DBUtil.ThrowExceptionOnOpenTransaction();
                    Session.BeginTransaction();
                    // Schreibe zuerst die Bewilligungs-History (via Bewilligungs-Dialog)
                    dlg.InsertBewilligungsHistory();

                    qryBgPosition["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.InVorbereitung;
                    qryBgPosition["Status"] = 1;

                    //Statusupdate Detailpositionen
                    DBUtil.ExecSQL(@"
                        update BgPosition
                        set    BgBewilligungStatusCode = {0}
                        where  BgPositionID_Parent = {1}",
                        qryBgPosition["BgBewilligungStatusCode"],
                        qryBgPosition["BgPositionID"]);

                    if (!qryBgPosition.Post())
                    {
                        throw new Exception("Ein Fehler ist beim Bewilligungsvorgang aufgetreten.");
                    }

                    WhUtil.DeleteVerrechnungsposition((int)qryBgPosition["BgPositionID"]);

                    Session.Commit();
                }
                catch (Exception ex)
                {
                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }

                    KissMsg.ShowInfo(ex.Message);
                }
            }
            else if (GetUserPermission())
            {
                var dlg = new DlgWhPositionVisieren((int)qryBgPosition["BgPositionID"], Name);

                dlg.ShowDialog(this);
                if (dlg.UserCancel)
                {
                    return;
                }

                try
                {
                    Session.BeginTransaction();
                    // Schreibe zuerst die Bewilligungs-History (via Bewilligungs-Dialog)
                    dlg.InsertBewilligungsHistory();

                    if (dlg.UserYes)
                    {
                        qryBgPosition["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Erteilt;
                        qryBgPosition["Status"] = 14;
                        WhUtil.InsertOrUpdateVerrechnungsposition(qryBgPosition);
                    }
                    else
                    {
                        qryBgPosition["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Abgelehnt;
                        qryBgPosition["Status"] = 15;
                    }

                    //Statusupdate Detailpositionen
                    DBUtil.ExecSQL(@"
                        update BgPosition
                        set    BgBewilligungStatusCode = {0}
                        where  BgPositionID_Parent = {1}",
                        qryBgPosition["BgBewilligungStatusCode"],
                        qryBgPosition["BgPositionID"]);

                    if (!qryBgPosition.Post())
                    {
                        throw new Exception("Ein Fehler ist beim Bewilligungsvorgang aufgetreten.");
                    }

                    Session.Commit();
                    XLog.Create(
                        TYPEFULLNAME,
                        0,
                        LogLevel.DEBUG,
                        "Position Bewilligt",
                        string.Format(
                            "Neue Netto-Buchung-ID: {0}, BudgetBgBewilligungstatuscode: {1}",
                            DBUtil.ExecuteScalarSQL(
                                "SELECT TOP 1 KbBuchungID FROM KbBuchungKostenart WHERE BgPositionID = {0}",
                                qryBgPosition["BgPositionID"]),
                            qryMonatsbudget["BgBewilligungStatusCode"]),
                        "BgPosition",
                        ShUtil.GetCode(qryBgPosition["BgPositionID"])
                        );
                }
                catch (Exception ex)
                {
                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }

                    KissMsg.ShowInfo(ex.Message);
                }
            }
            else
            {
                // Anfragebenutzer darf nicht Ersteller der Position sein
                if (!CheckKontrolleUser())
                {
                    KissMsg.ShowInfo("FrmWhEinzelzahlungen", "BewilligungKontrolleAndererBenutzer", "Anfrage nicht möglich. Die Position muss von einem anderen Benutzer kontrolliert werden.");
                    return;
                }

                //Wenn der Benutzer in DlgBewilligungAnfragen 'Anfragen' klickt, erstellt einen Bewilligungs-Record und öffnet dazu bereits eine Transaktion!
                var dlg = new DlgPositionBewilligungAnfragen(
                    (int)qryBgPosition["BgPositionID"],
                    (int)qryMonatsbudget["BgFinanzPlanID"],
                    (int)qryMonatsbudget["BgBudgetID"],
                    Name,
                    true);

                dlg.ShowDialog(this);
                if (dlg.UserCancel)
                    return;

                try
                {
                    qryBgPosition["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.Angefragt;
                    qryBgPosition["Status"] = 12;

                    //Statusupdate Detailpositionen
                    DBUtil.ExecSQL(@"
                        update BgPosition
                        set    BgBewilligungStatusCode = {0}
                        where  BgPositionID_Parent = {1}",
                        qryBgPosition["BgBewilligungStatusCode"],
                        qryBgPosition["BgPositionID"]);

                    if (!qryBgPosition.Post())
                    {
                        throw new Exception("Ein Fehler ist beim Bewilligungsvorgang aufgetreten.");
                    }

                    Session.Commit();
                }
                catch (Exception ex)
                {
                    if (Session.Transaction != null)
                    {
                        Session.Rollback();
                    }

                    KissMsg.ShowInfo(ex.Message);
                }
            }

            qryBgPosition_PositionChanged(null, null);
            qryBgPosition.RefreshDisplay();
        }

        private void btnPositionGrau_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            SetEditMode();

            if (!btnPositionGrau.Visible)
            {
                return;
            }

            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
                Session.BeginTransaction();
                var positionStatus = (int)qryBgPosition["Status"];
                if (positionStatus != 2)
                {
                    return;
                }

                // grüne Einzelzahlung auf grau stellen
                DBUtil.ExecSQLThrowingException(@"exec spWhBudget_DeleteKbBuchung {0}", qryBgPosition["BgPositionID"]);

                qryBgPosition["Status"] = (int)DBUtil.ExecuteScalarSQL(@"
                    SELECT CASE BgBewilligungStatusCode
                           WHEN 1 THEN 1   -- grau
                           WHEN 2 THEN 15  -- abgelehnt
                           WHEN 3 THEN 12  -- angefragt
                           WHEN 5 THEN 14  -- bewilligt
                           WHEN 9 THEN 7   -- gesperrt
                           END
                    FROM BgPosition
                    WHERE BgPositionID = {0}",
                        qryBgPosition["BgPositionID"]);

                qryBgPosition.Row.AcceptChanges();
                qryBgPosition.RowModified = false;
                SetEditMode();
                qryBgPosition.RefreshDisplay();

                // Da Position wieder grau ist, kann das Monatsbudget wieder ausgewählt werden
                qryBgPosition_PositionChanged(null, null);
                //alte Version: qryMonatsbudget.Fill(qryBgPosition["KlientID"], null);

                InsertPositionVerlaufEintrag(12, Utils.ConvertToInt(qryBgPosition["BgPositionID"]));

                Session.Commit();
                XLog.Create(
                    TYPEFULLNAME,
                    3,
                    LogLevel.DEBUG,
                    "Buchung gelöscht",
                    string.Empty,
                    "BgPosition",
                    ShUtil.GetCode(qryBgPosition["BgPositionID"]));

                qryBgPosition.Refresh();
            }
            catch (KissCancelException ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                KissMsg.ShowError(ex.Message);
            }
        }

        private void btnPositionGruen_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            //Inzwischen grün durch automatisches Grünstellen?
            if ((int)qryBgPosition["Status"] == 2)
            {
                return;
            }

            if (!btnPositionGruen.Visible)
            {
                return;
            }

            // Anfragebenutzer darf nicht Ersteller der Position sein
            if (!CheckKontrolleUser())
            {
                KissMsg.ShowInfo("FrmWhEinzelzahlungen", "GrünstellenKontrolleAndererBenutzer", "Grünstellen nicht möglich. Die Position muss von einem anderen Benutzer kontrolliert werden.");
                return;
            }

            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();

                Session.BeginTransaction();

                DBUtil.ExecSQLThrowingException(@"
                    EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0, null, {2}",
                    qryMonatsbudget["BgBudgetID"],
                    Session.User.UserID,
                    qryBgPosition["BgPositionID"]);

                qryBgPosition["Status"] = 2; // freigegeben
                qryBgPosition.Row.AcceptChanges();
                qryBgPosition.RowModified = false;
                SetEditMode();
                qryBgPosition.RefreshDisplay();

                //Verlauf-Eintrag erstellen
                InsertPositionVerlaufEintrag(11, Utils.ConvertToInt(qryBgPosition["BgPositionID"]));  //11: Position zur Zahlung freigegeben

                // Monatsbudgets einschränken, damit die Position nicht verschoben werden kann
                qryBgPosition_PositionChanged(null, null);
                //alte Version: qryMonatsbudget.Fill(qryBgPosition["KlientID"], qryBgPosition["BgBudgetID"]);
                LoadKontrolle(true);

                Session.Commit();
            }
            catch (KissCancelException ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                KissMsg.ShowError(ex.Message);
            }
        }

        private void btnWeitereKOA_Click(object sender, EventArgs e)
        {
            if (qryBgPosition.Count == 0)
            {
                return;
            }

            if (!qryBgPosition.Post())
            {
                return;
            }

            var dlg = new DlgWhWeitereKOA(
                (int)qryBgPosition["BgPositionID"],
                Name,
                (Decimal)qryBgPosition["BetragSpezial"]);

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                qryBgPosition.Refresh();
            }
        }

        private void btnZusatzleistung_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            if (!qryBgPosition.CanInsert)
            {
                return;
            }

            _newBgKategorieCode = 100;
            qryBgPosition.Insert();
        }

        private void edtBaPersonID_EditValueChanged(object sender, EventArgs e)
        {
            if (IsZahlwegFix())
            {
                FillPersonInfoIntoMitteilungZeile2();
            }
        }

        private void edtBgSpezkontoID_EditValueChanged(object sender, EventArgs e)
        {
            if (qryBgPosition.IsFilling)
            {
                return;
            }

            if (!edtBgSpezkontoID.Focused)
            {
                return;
            }

            qryBgPosition["BgSpezKontoID"] = edtBgSpezkontoID.EditValue;

            SetSpezialkonto();
            SetEditMode();
            _buchungstext.SelectAllText();
        }

        private void edtBuchungstext_TextChanged(object sender, EventArgs e)
        {
            if (edtBuchungstext.UserModified)
            {
                _buchungstext.FilterBuchungstext(edtBuchungstext.EditValue.ToString());
            }
        }

        private void edtDocument_DocumentImported(object sender, EventArgs e)
        {
        }

        private void edtDocument_DocumentImporting(object sender, CancelEventArgs e)
        {
        }

        private void edtKategorie_EditValueChanged(object sender, EventArgs e)
        {
            if (!edtKategorie.UserModified)
            {
                return;
            }

            qryBgPosition["BgKategorieCode"] = edtKategorie.EditValue;
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

            if (kategorie == 100)
            {
                //Zusatzleistung
                qryBgPosition["BgSpezKontoID"] = null;
                edtBgSpezkontoID.EditValue = null; //#7960: Doppelt moppeln ist notwendig, da sonst beim Post() der noch vorhandene EditValue ins SqlQuery übertragen wird

                //ZL mit gleicher Leistungsart suchen
                SqlQuery qry = DBUtil.OpenSQL(@"
                    select BPA.BgPositionsartID,
                           Kostenart = BKA.KontoNr + ' '+ BPA.Name,
                           Quoting = BKA.Quoting
                    from   BgPositionsart BPA
                           inner join BgKostenart BKA on BKA.BgKostenartID = BPA.BgKostenartID
                    where  BPA.BgKategorieCode = 100 and
                           BKA.KontoNr = {0}",
                        qryBgPosition["KOA"]);

                if (qry.Count == 1)
                {
                    qryBgPosition["BgPositionsartID"] = qry["BgPositionsartID"];
                    qryBgPosition["Kostenart"] = qry["Kostenart"];
                    qryBgPosition["Quoting"] = qry["Quoting"];
                }
                else
                {
                    qryBgPosition["Kostenart"] = null;
                    qryBgPosition["KOA"] = null;
                    qryBgPosition["Quoting"] = false;
                }
            }
            else
            {
                //Einzelzahlung
                qryBgPosition["BgPositionsartID"] = null;
                qryBgPosition["Kostenart"] = null;
                qryBgPosition["KOA"] = null;
                qryBgPosition["Quoting"] = false;
                LoadSpezialkonto(null);
            }

            SetEditMode();
        }

        private void edtKlient_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKlient.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["Klient"] = null;
                    qryBgPosition["KlientID"] = null;
                    qryBgPosition["Adresse"] = null;
                    qryBgPosition["FaFallID"] = null;
                    qryBgPosition["BaPersonID"] = null;
                    qryMonatsbudget.DataTable.Rows.Clear();
                    LoadSpezialkonto(-1);
                    return;
                }
            }

            int searchNr;
            int.TryParse(searchString, out searchNr);

            string sql = @"
              SELECT distinct
                     BaPersonID$      = PRS.BaPersonID,
                     [Pers.-Nr.]      = PRS.BaPersonID,
                     Name             = PRS.NameVorname +
                                        ' (' + isNull(convert(varchar,PRS.AlterMortal),'-') +
                                        isNull(',' + GES.ShortText,'') + ')',
                     Adresse          = PRS.Wohnsitz,
                     [Fall-Nr]        = LEI.FaFallID,
                     [MB grau]        = (select count(*)
                                         from   BgBudget B
                                                inner join BgFinanzplan F on F.BgFinanzplanID = B.BgFinanzplanID
                                                inner join FaLeistung   L on L.FaLeistungID = F.FaLeistungID
                                         where  L.FaFallID = LEI.FaFallID and
                                                L.BaPersonID = PRS.BaPersonID and
                                                B.Masterbudget = 0 and
                                                B.BgBewilligungStatusCode = 1),
                     [MB grün]        = (select count(*)
                                         from   BgBudget B
                                                inner join BgFinanzplan F on F.BgFinanzplanID = B.BgFinanzplanID
                                                inner join FaLeistung   L on L.FaLeistungID = F.FaLeistungID
                                         where  L.FaFallID = LEI.FaFallID and
                                                L.BaPersonID = LEI.BaPersonID and
                                                B.Masterbudget = 0 and
                                                B.BgBewilligungStatusCode = 5),
                     [MB rot]         = (select count(*)
                                          from   BgBudget B
                                                 inner join BgFinanzplan F on F.BgFinanzplanID = B.BgFinanzplanID
                                                 inner join FaLeistung   L on L.FaLeistungID = F.FaLeistungID
                                          where  L.FaFallID = LEI.FaFallID and
                                                 L.BaPersonID = LEI.BaPersonID and
                                                 B.Masterbudget = 0 and
                                                 B.BgBewilligungStatusCode = 9),
                     Name$            = PRS.NameVorname
              FROM   vwPerson PRS
                     INNER JOIN FaLeistung LEI ON LEI.BaPersonID = PRS.BaPersonID and
                                                  LEI.FaProzessCode = 300
                     LEFT  JOIN XLOVCode   GES ON GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode";

            if (searchNr != 0)
            {
                sql += " WHERE PRS.BaPersonID = {0} OR LEI.FaFallID = {0} ORDER BY Name";
            }
            else
            {
                sql += " WHERE PRS.NameVorname LIKE '%' + {0} + '%' ORDER BY Name";
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBgPosition["Klient"] = dlg["Name$"];
                qryBgPosition["KlientID"] = dlg["BaPersonID$"];
                qryBgPosition["Adresse"] = dlg["Adresse"];
                qryBgPosition["FaFallID"] = dlg["Fall-Nr"];
                qryBgPosition["BaPersonID"] = null;

                _filling = true;
                qryMonatsbudget.Fill(qryBgPosition["KlientID"], null);
                while (Convert.ToInt32(qryMonatsbudget["Jahr"]) != DateTime.Now.Year ||
                       Convert.ToInt32(qryMonatsbudget["Monat"]) != DateTime.Now.Month)
                {
                    if (!qryMonatsbudget.Next())
                    {
                        break;
                    }
                }
                _filling = false;
                qryBgPosition["TeamZustaendig"] = qryMonatsbudget["TeamZustaendig"];
                SetVerwendungsPeriode();
                LoadSpezialkonto(null);
                LoadPerson(true);

                if (!DBUtil.IsEmpty(qryBgPosition["EinzahlungsscheinCode"]) &&
                    ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) && // != oranger ES
                    (qryMonatsbudget.Count > 0))
                {
                    SqlQuery qry = DBUtil.OpenSQL(@"
                        select FallNrNameVorname = 'F' + convert(varchar,{1}) + ' ' + NameVorname,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                        from   vwPerson
                        where  BaPersonID = {0}",
                            qryMonatsbudget["LeistungBaPersonID"],
                            qryMonatsbudget["FaFallID"]);

                    qryBgPosition["MitteilungZeile1"] = TruncateString(qry["FallNrNameVorname"], 35);
                }

                // Den Kreditor bei einem Klientenwechsel auf Null setzten falls der Kreditor keine Institution ist oder falls der Kreditor nicht zu den Personen im Haushalt gehört
                if (!DBUtil.IsEmpty(qryBgPosition["KlientID"]) && !DBUtil.IsEmpty(qryBgPosition["BaZahlungswegID"]) &&
                    !DBUtil.IsEmpty(edtKreditor.EditValue))
                {
                    object kreditor = DBUtil.ExecuteScalarSQL(@"
                        SELECT KRE.BaZahlungswegID FROM vwKreditor KRE
                        WHERE KRE.BaZahlungswegID = {1} AND
                            KRE.BaInstitutionID > 500000
                        UNION
                        -- Personen im Haushalt
                        SELECT TOP 1 FAP.BaPersonID
                        FROM FaFallPerson FAP
                            INNER JOIN vwKreditor KRE ON KRE.BaPersonID = FAP.BaPersonID
                        WHERE KRE.BaZahlungswegID = {1} AND
                            FAP.BaPersonID = {0} AND
                                GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate())",
                        qryBgPosition["KlientID"],
                        qryBgPosition["BaZahlungswegID"]);
                    if (DBUtil.IsEmpty(kreditor))
                    {
                        AuswahlKreditorFamoz("", false); // ButtonClicked = false
                    }
                }
            }
        }

        private void edtKostenart_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtKostenart.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["BgPositionsArtID"] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    qryBgPosition["KOA"] = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();

            string sql =
                "select "
                       + KOA_TEXT + @"    = BKA.KontoNr,
                       Positionsart        = BPA.Name,
                       Quoting             = BKA.Quoting,
                       Gruppe              = GRP.Text,
                       BgPositionsartID$   = BPA.BgPositionsartID,
                       BgKostenartID$      = BPA.BgKostenartID,
                       KOAPositionsart$    = BKA.KontoNr + ' '+ BPA.Name,
                       KOA$                = BKA.KontoNr,
                       Name$               = BPA.Name,
                       BgSplittingArtCode$ = BKA.BgSplittingArtCode,
                       sqlRichtlinie$      = BPA.sqlRichtlinie,
                       GruppeFilter$       = convert(varchar(50),GRP.Value3),
                       BaZahlungswegIDFix$ = BKA.BaZahlungswegIDFix
                from   WhPositionsart BPA
                       inner join BgKostenart BKA on BKA.BgKostenartID = BPA.BgKostenartID
                       left  join XLOVCode    GRP on GRP.LOVName = 'BgGruppe' AND GRP.Code = BPA.BgGruppeCode
                       left join  XLOVCode    CIN ON CIN.LOVName = 'BgKategorie' AND CIN.Code >= 10000 AND CIN.Code = BPA.BgKategorieCode
                where  BgKategorieCode = " + qryBgPosition["BgKategorieCode"]
           + @" and   (BPA.Name like '%' + {0} + '%' or BKA.KontoNr like {0} + '%')
                and   CIN.Code IS NULL -- inaktiven BgKategorien zeigen wir nicht an";

            sql += " order by 1,2";

            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBgPosition["BgPositionsArtID"] = dlg["BgPositionsartID$"];
                qryBgPosition["Kostenart"] = dlg["KOAPositionsart$"];
                qryBgPosition["KOA"] = dlg["KOA$"];
                qryBgPosition["Buchungstext"] = dlg["Name$"];
                qryBgPosition["BgSplittingArtCode"] = dlg["BgSplittingArtCode$"];
                qryBgPosition["GruppeFilter"] = dlg["GruppeFilter$"];
                qryBgPosition["BaZahlungswegIDFix"] = dlg["BaZahlungswegIDFix$"];
                qryBgPosition["Quoting"] = dlg["Quoting"];

                if ((bool)dlg["Quoting"])
                {
                    qryBgPosition["BaPersonID"] = null;
                }
                else
                {
                    LoadPerson(true);
                }

                //Auszahlung an fixe Zahladresse
                SetKreditorIfZahlungswegFix();

                SetVerwendungsPeriode();
                _buchungstext.LoadBuchungstext(qryBgPosition["BgPositionsartID"] as int?, true);
                SetEditMode();
            }
        }

        private void edtKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            if (DBUtil.IsEmpty(qryBgPosition["KlientID"]))
            {
                KissMsg.ShowInfo("Es ist noch keine Klient/in erfasst");
                edtKreditor.EditValue = DBNull.Value;
                edtKlient.Focus();
            }

            e.Cancel = AuswahlKreditorFamoz(edtKreditor.EditValue.ToString(), e.ButtonClicked);
        }

        private void edtSucheMitarbeiter_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var ctl = (KissButtonEdit)sender;
            string searchString = ctl.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    ctl.EditValue = DBNull.Value;
                    ctl.LookupID = DBNull.Value;
                    ctl.ToolTip = "";
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel =
                !dlg.SearchData(
                    @"
                SELECT ID$              = UserID,
                       [Kürzel]         = LogonName,
                       [Mitarbeiter/in] = NameVorname,
                       [Org.Einheit]    = OrgUnit,
                       DisplayText$     = DisplayText
                FROM dbo.vwUser
                WHERE DisplayText LIKE '%' + {0} + '%'
                ORDER BY NameVorname;",
                    searchString,
                    e.ButtonClicked,
                    null,
                    null,
                    null);

            if (!e.Cancel)
            {
                ctl.EditValue = dlg["Kürzel"];
                ctl.LookupID = dlg["ID$"];
                ctl.ToolTip = dlg["DisplayText$"].ToString();
            }
        }

        private void FrmWhEinzelzahlungen_Load(object sender, EventArgs e)
        {
            btnDocument.Image = XDokument.BmpImportDoc;

            Text = "WH Einzelzahlungen";

            // Tooltips setzen
            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnZusatzleistung, "neue zusätzliche Leistung");
            toolTip1.SetToolTip(btnPositionBewilligung, "Bewilligung der Budgetposition");

            //Buchungsstati laden
            repositoryItemImageComboBox2.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KbBuchungsStatus' order by SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox2.Items.Add(
                    new ImageComboBoxItem(
                        row["Text"].ToString(),
                        (int)row["Code"],
                        KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            colStatus.ColumnEdit = repositoryItemImageComboBox2;

            // Dasselbe für edtSucheStatus
            edtSucheStatus.Properties.SmallImages = KissImageList.SmallImageList;
            edtSucheStatus.Properties.Items.Add(new ImageComboBoxItem("", null, -1));

            foreach (ImageComboBoxItem item in repositoryItemImageComboBox2.Items)
            {
                edtSucheStatus.Properties.Items.Add(item);
            }

            edtBgSplittingCode.LoadQuery(DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'BgSplittingart'"), "Code", "ShortText");

            colKat.ColumnEdit =
                grdEinzelzahlung.GetLOVLookUpEdit(
                    DBUtil.OpenSQL("select Code, Text = substring(Text,1,1) from XLOVCode where LOVName = 'BgKategorie'"));
            colDocTyp.ColumnEdit = grdDoc.GetLOVLookUpEdit("BgDokumentTyp");
            colBgBewilligungCode.ColumnEdit = grdBewilligung.GetLOVLookUpEdit("BgBewilligung");

            edtBetrag.Properties.DisplayFormat.FormatString = "N2";
            edtBetrag.Properties.EditFormat.FormatString = "N2";

            grvEinzelzahlung.CustomRowCellEdit += grvEinzelzahlung_CustomRowCellEdit;
            grvEinzelzahlung.CellValueChanging += grvEinzelzahlung_CellValueChanging;

            qryBgPosition.PostCompleted += qryBgPosition_PostCompleted;

            btnEinzelzahlungen.Enabled = DBUtil.UserHasRight("CtlBgEinzelzahlungen_EinzelzahlungenFreigeben");
            btnAlle.Enabled = btnEinzelzahlungen.Enabled;
            btnKeine.Enabled = btnEinzelzahlungen.Enabled;
            colSelektion.OptionsColumn.AllowEdit = btnEinzelzahlungen.Enabled;

            edtAutomAnfrage.Checked = false; //vorläufig während Einführungsphase

            tabBgPosition.SelectedTabIndex = 0;
            tabControlSearch.SelectedTabIndex = 1;

            _buchungstext = new ShBuchungstext(edtBuchungstext, qryBgPosition);

            _freigegebeneMutieren = DBUtil.UserHasRight("FrmWhEinzelzahlungen_FreigegebeneMutieren");

            PresetSearchFields();

            // Suche auslösen ohne Daten zu holen um Tabellenstriktur im Query zu haben und Felder readonly setzen
            kissSearch.SelectParameters = new object[] { 0, Name };
            OnSearch();
            NewSearch();
            kissSearch.SelectParameters = new object[] { 1, Name };
        }

        private void grvEinzelzahlung_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column != colSelektion)
            {
                return;
            }

            if (qryBgPosition.Post())
            {
                grvEinzelzahlung.SetRowCellValue(e.RowHandle, colSelektion, e.Value);
                qryBgPosition.Row.AcceptChanges();
                qryBgPosition.RowModified = false;
            }
            else
            {
                grvEinzelzahlung.SetRowCellValue(e.RowHandle, colSelektion, qryBgPosition["Sel"]);
            }
        }

        private void grvEinzelzahlung_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column == colSelektion)
            {
                if (DBUtil.IsEmpty(grvEinzelzahlung.GetRowCellValue(e.RowHandle, e.Column)))
                {
                    e.RepositoryItem = repositoryItemTextEdit1;
                }
                else
                {
                    e.RepositoryItem = repositoryItemCheckEdit1;
                }
            }
        }

        private void qryBgDokumente_AfterDelete(object sender, EventArgs e)
        {
            if (Session.Transaction == null)
            {
                return;
            }

            try
            {
                //Anzeige der Anzahl Dokumente im Grid updaten
                qryBgPosition["Doc"] = DBUtil.ExecuteScalarSQL(@"
                    SELECT CASE WHEN COUNT(*) > 0 THEN COUNT(*) END
                    FROM BgDokument
                    WHERE BgPositionID = {0}",
                    qryBgPosition["BgPositionID"]);

                var documentID = qryBgDokumente["DocumentID"] as int?;
                if (documentID.HasValue)
                {
                    DBUtil.ExecSQL("DELETE FROM dbo.XDocument WHERE DocumentID = {0}", documentID.Value);
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
            }
        }

        private void qryBgDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryBgDokumente["BgDokumentTypCode"] = 1;
            qryBgDokumente["Stichwort"] = qryBgPosition["Kostenart"];

            edtDokumentTyp.Focus();
        }

        private void qryBgDokumente_AfterPost(object sender, EventArgs e)
        {
            qryBgDokumente["DateCreation"] = edtDocument.DateCreation;
            qryBgDokumente["DateLastSave"] = edtDocument.DateLastSave;
        }

        private void qryBgDokumente_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();
        }

        private void qryBgDokumente_BeforePost(object sender, EventArgs e)
        {
            if (!qryBgDokumente.IsSilentPostingFromXDocument && DBUtil.IsEmpty(qryBgDokumente["DocumentID"]))
            {
                KissMsg.ShowInfo("Erfassen sie zuerst ein Dokument.");
                throw new KissCancelException();
            }

            qryBgDokumente["BgPositionID"] = DBNull.Value;
            qryBgDokumente["BgBudgetID"] = DBNull.Value;
            qryBgDokumente["BgFinanzplanID"] = DBNull.Value;

            switch ((int)qryBgDokumente["BgDokumentTypCode"])
            {
                case 1:
                    qryBgDokumente["BgPositionID"] = qryBgPosition["BgPositionID"];
                    break;

                case 2:
                    qryBgDokumente["BgBudgetID"] = qryMonatsbudget["BgBudgetID"];
                    break;

                case 3:
                    qryBgDokumente["BgFinanzplanID"] = qryMonatsbudget["BgFinanzPlanID"];
                    break;
            }

            if (DBUtil.IsEmpty(qryBgDokumente["Stichwort"]))
            {
                qryBgDokumente["Stichwort"] = "-";
            }
        }

        private void qryBgDokumente_PostCompleted(object sender, EventArgs e)
        {
            //Anzeige der Anzahl Dokumente im Grid updaten
            if (qryBgPosition.Post())
            {
                qryBgPosition["Doc"] = DBUtil.ExecuteScalarSQL(@"
                    SELECT CASE WHEN COUNT(*) > 0 THEN COUNT(*) END
                    FROM dbo.BgDokument
                    WHERE BgPositionID = {0}",
                    qryBgPosition["BgPositionID"]);
                qryBgPosition.Row.AcceptChanges();
                qryBgPosition.RowModified = false;
            }
        }

        private void qryBgPosition_AfterDelete(object sender, EventArgs e)
        {
            if (Session.Transaction == null)
            {
                return;
            }

            try
            {
                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
            }
        }

        private void qryBgPosition_AfterInsert(object sender, EventArgs e)
        {
            qryBgPosition["MA"] = Session.User.LogonName;
            qryBgPosition["BgKategorieCode"] = _newBgKategorieCode;
            qryBgPosition["Status"] = 1; //grau
            qryBgPosition["Quoting"] = true;

            _origVerwPeriodeVon = qryBgPosition["VerwPeriodeVon"];
            _origVerwPeriodeBis = qryBgPosition["VerwPeriodeBis"];

            switch (_newBgKategorieCode)
            {
                case 100: //Zusatzleistung
                    qryBgPosition["KbAuszahlungsArtCode"] = 101; //elektronisch
                    qryBgPosition["BgAuszahlungsTerminCode"] = 4; //Valuta
                    break;

                case 101: //Einzelzahlung
                    qryBgPosition["KbAuszahlungsArtCode"] = 101; //elektronisch
                    qryBgPosition["BgAuszahlungsTerminCode"] = 4; //Valuta
                    LoadSpezialkonto(-1); //keine Auswahl, solange kein Klient ausgewählt ist
                    break;
            }

            _buchungstext.LoadBuchungstext(qryBgPosition["BgPositionsartID"] as int?, false);
            _buchungstext.FilterBuchungstext(edtBuchungstext.EditValue.ToString());

            _newBgKategorieCode = 0;
            tabBgPosition.SelectedTabIndex = 0;
            SetEditMode();

            btnWeitereKOA.Visible = false;

            ctlErfassungMutation1.ShowInfo();

            edtKlient.Focus();
        }

        private void qryBgPosition_AfterPost(object sender, EventArgs e)
        {
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            bool hauptPos = !DBUtil.IsEmpty(qryBgPosition["HauptPos"]);

            bool newTransaction = false;
            try
            {
                if (Session.Transaction == null)
                {
                    newTransaction = true;
                    Session.BeginTransaction();
                }

                //Valuta-Termine speichern
                //Löschen der alten Daten und neuer Datensatz in BgAuszahlungPerson und BgAuszahlungPersonTermin
                DBUtil.ExecSQLThrowingException(@"
                    delete TRM
                    from   BgAuszahlungPersonTermin TRM
                           inner join BgAuszahlungPerson AUS on AUS.BgAuszahlungPersonID = TRM.BgAuszahlungPersonID
                    where AUS.BgPositionID = {0}

                    delete BgAuszahlungPerson where BgPositionID = {0}

                    insert BgAuszahlungPerson (BgPositionID, BaPersonID, KbAuszahlungsArtCode, BgAuszahlungsTerminCode, BgWochentagCodes,
                                               BaZahlungswegID, ReferenzNummer, MitteilungZeile1,MitteilungZeile2,MitteilungZeile3,MitteilungZeile4)
                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})

                    insert BgAuszahlungPersonTermin (BgAuszahlungPersonID,Datum)
                    values (@@identity,{11})",
                    qryBgPosition["BgPositionID"],
                    null,
                    qryBgPosition["KbAuszahlungsArtCode"],
                    qryBgPosition["BgAuszahlungsTerminCode"],
                    qryBgPosition["BgWochentagCodes"],
                    qryBgPosition["BaZahlungswegID"],
                    qryBgPosition["ReferenzNummer"],
                    qryBgPosition["MitteilungZeile1"],
                    qryBgPosition["MitteilungZeile2"],
                    qryBgPosition["MitteilungZeile3"],
                    qryBgPosition["MitteilungZeile4"],
                    qryBgPosition["ValutaDatum"]);

                if (hauptPos)
                {
                    //Update alle DetailPos inkl. Auszahlinfo
                    DBUtil.ExecSQLThrowingException(@"
                        declare @HauptBgPositionID int
                        declare @MainBgAuszahlungPersonID int
                        declare @DetailBgPositionID int
                        declare @WhereClause varchar(200)

                        set @HauptBgPositionID = {0}

                        UPDATE POS
                          SET  BgBudgetID = {1},
                               Bemerkung  = {2}
                        FROM dbo.BgPosition POS
                        WHERE BgPositionID_Parent = @HauptBgPositionID
                          AND POS.BgKategorieCode <> 3;

                        -- alte Auszahlinfo löschen
                        delete BAP
                        from   BgAuszahlungPerson BAP
                               inner join BgPosition BPO on BPO.BgPositionID = BAP.BgPositionID
                        where  BPO.BgPositionID_Parent = @HauptBgPositionID

                        declare cDetailPos cursor static for
                        SELECT BgPositionID
                        FROM dbo.BgPosition POS
                        WHERE BgPositionID_Parent = @HauptBgPositionID
                          AND POS.BgKategorieCode <> 3;

                        open cDetailPos
                        fetch next from cDetailPos into @DetailBgPositionID
                        while @@fetch_status = 0 begin

                            select @MainBgAuszahlungPersonID = BgAuszahlungPersonID from BgAuszahlungPerson where BgPositionID = @HauptBgPositionID

                            -- BgAuszahlungPerson
                            set @WhereClause = 'BgAuszahlungPersonID = ' + CONVERT(varchar,@MainBgAuszahlungPersonID)
                            exec spDuplicateRows 'BgAuszahlungPerson',@WhereClause,'BgPositionID',@DetailBgPositionID

                            -- BgAuszahlungPersonTermin
                            set @WhereClause = 'BgAuszahlungPersonID = ' + CONVERT(varchar,@MainBgAuszahlungPersonID)
                            exec spDuplicateRows 'BgAuszahlungPersonTermin',@WhereClause,'BgAuszahlungPersonID',@@identity

                            fetch next from cDetailPos into @DetailBgPositionID
                        end
                        close cDetailPos
                        deallocate cDetailPos",
                        qryBgPosition["BgPositionID"],
                        qryBgPosition["BgBudgetID"],
                        qryBgPosition["Bemerkung"]);
                }

                // Verrechnungsposition nur bei ZL erstellen erstellen
                int positonBewilligung = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);
                if (kategorie == 100 && positonBewilligung == (int)BgBewilligungStatus.Erteilt)
                {
                    WhUtil.InsertOrUpdateVerrechnungsposition(qryBgPosition);
                }
                else
                {
                    WhUtil.DeleteVerrechnungsposition((int)qryBgPosition["BgPositionID"]);
                }

                if (_newPosition)
                {
                    InsertPositionVerlaufEintrag(10, Utils.ConvertToInt(qryBgPosition["BgPositionID"]));
                }

                if (newTransaction)
                {
                    Session.Commit();
                }
            }
            catch (Exception ex)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                if (!newTransaction)
                {
                    throw;
                }

                KissMsg.ShowInfo(ex.Message);
                return;
            }

            LoadKontrolle(true);

            if (!qryBgDokumente.Post())
            {
                tabBgPosition.SelectedTabIndex = 1;
                throw new KissCancelException();
            }
        }

        private void qryBgPosition_BeforeDelete(object sender, EventArgs e)
        {
            Session.BeginTransaction();

            try
            {
                if (!DBUtil.IsEmpty(qryBgPosition["HauptPos"]))
                {
                    DBUtil.ExecSQL(@"
                        -- Verrechnungspositionen von Detailposten löschen
                        DELETE POSV
                        FROM dbo.BgPosition POS
                          INNER JOIN dbo.BgPosition POSV ON POSV.BgPositionID_Parent = POS.BgPositionID
                        WHERE POS.BgPositionID_Parent = {0}
                          AND POSV.BgKategorieCode = 3;

                        -- Detailposten löschen
                        DELETE POS
                        FROM dbo.BgPosition POS
                        WHERE POS.BgPositionID_Parent = {0}
                          AND POS.BgKategorieCode <> 3;",
                        qryBgPosition["BgPositionID"]);
                }

                DBUtil.ExecSQL(@"
                    DELETE TRM
                    FROM   dbo.BgAuszahlungPersonTermin TRM
                      INNER JOIN dbo.BgAuszahlungPerson AUS ON AUS.BgAuszahlungPersonID = TRM.BgAuszahlungPersonID
                    WHERE AUS.BgPositionID = {0};

                    DELETE dbo.BgAuszahlungPerson WHERE BgPositionID = {0};

                    DELETE DOC
                    FROM dbo.XDocument DOC
                      INNER JOIN dbo.BgDokument BDO ON BDO.DocumentID = DOC.DocumentID
                    WHERE BDO.BgPositionID = {0};

                    DELETE dbo.BgDokument WHERE BgPositionID = {0};
                    DELETE dbo.BgBewilligung WHERE BgPositionID = {0};",
                    qryBgPosition["BgPositionID"]);

                WhUtil.DeleteVerrechnungsposition((int)qryBgPosition["BgPositionID"]);
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
                throw new KissCancelException();
            }
        }

        private void qryBgPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            int status = ShUtil.GetCode(qryBgPosition["Status"]);

            if (status != 1 && status != 12 && status != 14 && status != 15)
            {
                throw new KissInfoException("nur graue/hellblaue Positionen können gelöscht werden!");
            }
        }

        private void qryBgPosition_BeforeInsert(object sender, EventArgs e)
        {
            if (_newBgKategorieCode != 0)
            {
                return;
            }

            //Einzelzahlungen (101) sind nicht mehr unterstützt
            _newBgKategorieCode = 100;
        }

        private void qryBgPosition_BeforePost(object sender, EventArgs e)
        {
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            bool hauptPos = !DBUtil.IsEmpty(qryBgPosition["HauptPos"]);
            bool leistungAktiv = DBUtil.IsEmpty(qryMonatsbudget["LeistungDatumBis"]);

            //check Leistung aktiv
            if (!leistungAktiv)
            {
                throw new KissInfoException("Die zum ausgewählten Monatsbudget gehörende Leistung ist inaktiv!");
            }

            // check must fields
            DBUtil.CheckNotNullField(edtKlient, lblKlient.Text);

            //LA/Positionsart darf nicht null sein
            DBUtil.CheckNotNullField(edtKostenart, lblKostenart.Text);

            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            if (Convert.ToDecimal(qryBgPosition["BetragSpezial"]) <= Decimal.Zero)
            {
                edtBetrag.Focus();
                throw new KissInfoException("Der Betrag darf nicht 0.00 oder negativ sein!");
            }

            if (!hauptPos)
            {
                qryBgPosition["Betrag"] = qryBgPosition["BetragSpezial"];
            }

            // nur bei ZL, prüfen ob Erstellung automatischen Verrechnungsposition erlaubt ist
            WhUtil.CheckIfInsertVerrechnungspositionIsAllowed(kategorie, (int)qryMonatsbudget["BgBewilligungStatusCode"], qryBgPosition["BgPositionsartID"] as int?);

            //Betrifft Person
            bool quoting = !DBUtil.IsEmpty(qryBgPosition["Quoting"]) && (bool)qryBgPosition["Quoting"];
            if (quoting)
            {
                int status = ShUtil.GetCode(qryBgPosition["Status"]);
                bool editable = (status <= 1 || status == 12 || status == 14 || status == 15);
                if (editable)
                {
                    qryBgPosition["BaPersonID"] = null;
                }
            }
            else
            {
                if (DBUtil.IsEmpty(qryBgPosition["BaPersonID"]))
                {
                    edtBaPersonID.Focus();
                    throw new KissInfoException("Das Feld 'Betrifft Person' darf nicht leer bleiben für diese Leistungsart!");
                }
            }

            //Spezialkonto bei Einzelzahlungen
            if (kategorie == 101)
            {
                DBUtil.CheckNotNullField(edtBgSpezkontoID, lblBgSpezkontoID.Text);
            }

            //Valutadatum
            qryBgPosition["ValutaDatum"] = edtValutaDatum.EditValue; //get pending edit changes
            DBUtil.CheckNotNullField(edtValutaDatum, lblValutaDatum.Text);
            //für FAMOZ: Valutadatum muss zwischen heute und heute + 2 Monate liegen
            if (qryBgPosition.ColumnModified("ValutaDatum") &&
                ((DateTime)qryBgPosition["ValutaDatum"]) < DateTime.Today)
            {
                edtValutaDatum.Focus();
                throw new KissInfoException("Das Valutadatum darf nicht in der Vergangenheit liegen!");
            }

            if (qryBgPosition.ColumnModified("ValutaDatum") &&
                ((DateTime)qryBgPosition["ValutaDatum"]) > DateTime.Today.AddMonths(2))
            {
                edtValutaDatum.Focus();
                throw new KissInfoException("Das Valutadatum darf nicht mehr als 2 Monate in der Zukunft liegen!");
            }

            //BSS: falls user recht zur auswahl kreditoren besitzt, muss einer gewählt werden
            if (DBUtil.UserHasRight("FrmWhEinzelzahlungen_KreditorAuswahl"))
            {
                DBUtil.CheckNotNullField(edtKreditor, lblKreditor.Text);
            }

            //Referenznummer
            if (edtReferenzNummer.EditMode == EditModeType.Normal)
            {
                DBUtil.CheckNotNullField(edtReferenzNummer, lblReferenzNummer.Text);

                SqlQuery qry = DBUtil.OpenSQL(
                    "select PostKontoNummer from BaZahlungsweg where BaZahlungswegID = {0}", qryBgPosition["BaZahlungswegID"]);

                if (qry.Count == 1 && !edtReferenzNummer.ValidateReferenzNummer(qry["PostKontoNummer"].ToString()))
                {
                    edtReferenzNummer.Focus();
                    throw new KissCancelException();
                }
            }

            if (kategorie == 101) //Einzelzahlung
            {
                DBUtil.CheckNotNullField(edtBgSpezkontoID, lblBgSpezkontoID.Text);
                //reicht Saldo?
                decimal betrag = Convert.ToDecimal(qryBgPosition["Betrag"]);
                decimal saldo = Convert.ToDecimal(GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "Saldo"));
                if (betrag > saldo)
                {
                    edtBetrag.Focus();
                    throw new KissInfoException(
                        string.Format(
                            "Die Einzelzahlung kann nicht von diesem Spezialkonto abgebucht werden, da die Deckung des Spezialkontos (CHF {0:0.00}) nicht ausreicht.",
                            saldo));
                }
                decimal saldoTotal = Convert.ToDecimal(GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "SaldoTotal"));
                if (betrag > saldoTotal)
                {
                    edtBetrag.Focus();
                    throw new KissInfoException(
                        string.Format(
                            "Die Einzelzahlung kann nicht von diesem Spezialkonto abgebucht werden. Die Deckung per Budgetmonat ist zwar genügend, der aktuelle Saldo (CHF {0:0.00}) reicht jedoch nicht aus. Durch das Verbuchen dieser Einzezahlung würde der aktuelle Saldo negativ werden.",
                            saldoTotal));
                }
            }

            if (qryMonatsbudget.Count == 0)
            {
                throw new KissInfoException("Es gibt keine verfügbaren Budgets für diesen Mandanten!");
            }

            //Verwendungsperiode
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
            switch (bgSplittingArtCode)
            {
                case 1: //Taggenau
                case 2: //Monat
                    DBUtil.CheckNotNullField(edtVerwPeriodeVon, "Verwendungsperiode von");
                    DBUtil.CheckNotNullField(edtVerwPeriodeBis, "Verwendungsperiode bis");
                    if ((DateTime)edtVerwPeriodeBis.EditValue < (DateTime)edtVerwPeriodeVon.EditValue)
                    {
                        throw new KissInfoException("'Verwendungsperiode von' muss kleiner sein als 'Verwendungsperiode bis'.");
                    }
                    break;

                case 3: //Valuta
                    qryBgPosition["VerwPeriodeVon"] = qryBgPosition["ValutaDatum"];
                    qryBgPosition["VerwPeriodeBis"] = qryBgPosition["ValutaDatum"];
                    break;

                case 4: //Entscheid
                    DBUtil.CheckNotNullField(edtVerwPeriodeVon, "Verwendungsperiode von");
                    break;
            }

            //Zusätzliche Leistung: Gibt es ein Ausgabekonto mit genügend Deckung?
            //Nur Prüfen, wenn Neuerfassung oder Leistungsart mutiert
            if (kategorie == 100 && (qryBgPosition.Row.RowState == DataRowState.Added || qryBgPosition.ColumnModified("BgPositionsArtID")))
            {
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT SPK.*,
                           Saldo = dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, {5}, null)
                    FROM   BgSpezkonto SPK
                           INNER JOIN XLOVCode        TYP ON TYP.LOVName = 'BgSpezkontoTyp' and TYP.Code = SPK.BgSpezkontoTypCode
                           LEFT  JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = SPK.BgPositionsartID
                           LEFT  JOIN BgPositionsart  GBL ON GBL.BgPositionsartID = {4}
                           LEFT  JOIN BgKostenart     BKA ON BKA.BgKostenartID = ISNULL(SPK.BgKostenartID, GBL.BgKostenartID)
                    WHERE  SPK.FaLeistungID = {0} AND
                           SPK.BgSpezkontoTypCode = 1 AND
                           BKA.KontoNr = {1} AND
                           -- Bei nicht-gequoteten LAs muss die Person übereinstimmen oder das Ausgabekonto muss nicht für eine
                           -- spezifische Person angelegt worden sein.
                           (BKA.Quoting = 1 OR SPK.BaPersonID = {2} OR SPK.BaPersonID IS NULL) AND
                           dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, {5}, null) >= {3}",
                        qryMonatsbudget["FaLeistungID"],
                        qryBgPosition["KOA"],
                        qryBgPosition["BaPersonID"],
                        qryBgPosition["Betrag"],
                        qryMonatsbudget["WhGrundbedarfTypCode"],
                        qryBgPosition["BgBudgetID"]);

                if (qry.Count > 0 && KissMsg.ShowQuestion(
                    "Es gibt mindestens ein Ausgabekonto mit genügend Deckung für diese Zusätzliche Leistung: " +
                    "Soll diese Position zu einer Einzelzahlung umgewandelt werden?"))
                {
                    qryBgPosition["BgKategorieCode"] = 101;
                    qryBgPosition["BgPositionsartID"] = null;
                    qryBgPosition["Kostenart"] = null;
                    qryBgPosition["KOA"] = null;
                    qryBgPosition["Quoting"] = false;
                    LoadSpezialkonto(null);
                    if (qry.Count == 1)
                    {
                        qryBgPosition["BgSpezKontoID"] = qry["BgSpezKontoID"];
                        SetSpezialkonto();
                    }
                    SetEditMode();
                    throw new KissCancelException();
                }
            }

            // Rechnungsnummer prüfen wenn sie geändert wurde
            if (!DBUtil.IsEmpty(qryBgPosition["Rechnungsnummer"])
                && ((qryBgPosition.Row.RowState == DataRowState.Modified && qryBgPosition["Rechnungsnummer", DataRowVersion.Original] != qryBgPosition["Rechnungsnummer"]))
                      || qryBgPosition.Row.RowState == DataRowState.Added)
            {
                var numberOfRechnungsNummern = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT COUNT(1)
                    FROM (
                      SELECT POS.BgPositionID
                      FROM dbo.BgPosition            POS  WITH (READUNCOMMITTED)
                        INNER JOIN dbo.BgBudget      BDG  WITH (READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
                        INNER JOIN dbo.BgFinanzplan  FPL  WITH (READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
                        INNER JOIN dbo.FaLeistung    LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
                        INNER JOIN dbo.FaLeistung    LEI1 WITH (READUNCOMMITTED) ON LEI1.FaFallID = LEI.FaFallID
                        INNER JOIN dbo.BgFinanzplan  FPL1 WITH (READUNCOMMITTED) ON FPL1.FaLeistungID = LEI1.FaLeistungID
                        INNER JOIN dbo.BgBudget      BDG1 WITH (READUNCOMMITTED) ON BDG1.BgFinanzplanID = FPL1.BgFinanzplanID
                      WHERE BDG1.BgBudgetID = {0}
                        AND POS.Rechnungsnummer = {2}
                        AND (POS.BgPositionID <> {3}  OR {3} IS NULL)

                      UNION ALL

                      SELECT POS.BgPositionID
                      FROM dbo.BaZahlungsweg              ZLW WITH (READUNCOMMITTED)
                        INNER JOIN dbo.BgAuszahlungPerson AZP WITH (READUNCOMMITTED) ON AZP.BaZahlungswegID = ZLW.BaZahlungswegID
                        INNER JOIN dbo.BgPosition         POS WITH (READUNCOMMITTED) ON POS.BgPositionID = AZP.BgPositionID
                      WHERE ZLW.BaZahlungswegID = {1}
                        AND POS.Rechnungsnummer = {2}
                        AND (POS.BgPositionID <> {3} OR {3} IS NULL)
                    ) AS T",
                    qryMonatsbudget["BgBudgetID"],
                    qryBgPosition["BaZahlungswegID"],
                    qryBgPosition["Rechnungsnummer"],
                    qryBgPosition["BgPositionID"]);

                // Gebe ich in der Maske eine Rechnungsnummer ein, die bereits bei einer anderen Position verwendet wird,
                //dann kommt die Meldung "Diese Rechnungsnummer be-steht bereits. Rechnungsnummer trotzdem speichern? Ja / Nein".
                // Drücke ich ja, dann wird die Rechnungsnummer mitgespeichert, obschon sie doppelt ist.
                //Drücke ich nein, dann wird die eingegebene Rechnungsnummer nicht mitgespei-chert (es wird null eingefüllt).
                if (numberOfRechnungsNummern > 0)
                {
                    string abbrechenDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "AbbrechenDlgBtn", "Abbrechen");
                    string jaDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "JaDlgBtn", "Ja");
                    string neinDlgBtn = KissMsg.GetMLMessage("CtlFaModulTree", "NeinDlgBtn", "Nein");
                    string frageRechnungsnummerBesteht = KissMsg.GetMLMessage("CtlFaModulTree",
                                                                              "FrageRechnungsnummerBesteht",
                                                                              "Diese Rechnungsnummer besteht bereits. Rechnungsnummer trotzdem speichern?");

                    switch (DlgButtons.ShowButtonDlg(frageRechnungsnummerBesteht,
                                                     new[] { jaDlgBtn, neinDlgBtn, abbrechenDlgBtn }, 1))
                    {
                        case 0: // JA
                            break;

                        case 1: // NEIN
                            qryBgPosition["Rechnungsnummer"] = null;
                            break;

                        case 2: // Abbrechen
                            throw new KissCancelException();
                    }
                }
            }

            if (!DBUtil.IsEmpty(qryBgPosition["BgKategorieCode"]) && (int)qryBgPosition["BgKategorieCode"] == 100 //Zusätzliche Leistung
                && qryBgPosition.Row.RowState == DataRowState.Modified
                && !DBUtil.IsEmpty(qryBgPosition["BgBewilligungStatusCode"]) && (int)qryBgPosition["BgBewilligungStatusCode"] == 5 // Bewilligt
                && (!qryBgPosition.Row["Betrag", DataRowVersion.Original].Equals(qryBgPosition.Row["Betrag"])
                    || !qryBgPosition.Row["BgBudgetID", DataRowVersion.Original].Equals(qryBgPosition.Row["BgBudgetID"])
                    || !qryBgPosition.Row["BaPersonID", DataRowVersion.Original].Equals(qryBgPosition.Row["BaPersonID"])
                    || !qryBgPosition.Row["BaInstitutionID", DataRowVersion.Original].Equals(qryBgPosition.Row["BaInstitutionID"])
                    || !qryBgPosition.Row["BgPositionsArtID", DataRowVersion.Original].Equals(qryBgPosition.Row["BgPositionsArtID"])
                    || !qryBgPosition.Row["VerwPeriodeVon", DataRowVersion.Original].Equals(qryBgPosition.Row["VerwPeriodeVon"])
                    || !qryBgPosition.Row["VerwPeriodeBis", DataRowVersion.Original].Equals(qryBgPosition.Row["VerwPeriodeBis"])))
            {
                // Eine Veränderung einer dieser Felder zwingt zu einer neuen Bewilligung
                qryBgPosition["BgBewilligungStatusCode"] = 1; // in Vorbereitung
                qryBgPosition["Status"] = 1;
            }

            qryBgPosition["KbAuszahlungsArtCode"] = 101; //elektronisch
            qryBgPosition["BgAuszahlungsTerminCode"] = 4; //Valuta
            qryBgPosition["BgBudgetID"] = qryMonatsbudget["BgBudgetID"];

            ctlErfassungMutation1.SetFields();

            _newPosition = qryBgPosition.CurrentRowState == DataRowState.Added;

            qryBgPosition.RefreshDisplay();
        }

        private void qryBgPosition_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Column.ColumnName == "KOA" || e.Column.ColumnName == "KlientID")
            {
                UpdateLetzte10Buchungen();
            }
        }

        private void qryBgPosition_PositionChanged(object sender, EventArgs e)
        {
            ctlErfassungMutation1.ShowInfo();

            _origVerwPeriodeVon = qryBgPosition["VerwPeriodeVon"];
            _origVerwPeriodeBis = qryBgPosition["VerwPeriodeBis"];

            int status = ShUtil.GetCode(qryBgPosition["Status"]);
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

            _filling = true;
            switch (status)
            {
                case 0:
                    qryMonatsbudget.Fill(qryBgPosition["KlientID"], null);
                    try
                    {
                        while (Convert.ToInt32(qryMonatsbudget["Jahr"]) != DateTime.Now.Year ||
                               Convert.ToInt32(qryMonatsbudget["Monat"]) != DateTime.Now.Month)
                        {
                            if (!qryMonatsbudget.Next())
                            {
                                break;
                            }
                        }
                    }
                    catch
                    {
                    }

                    break;

                case 1:
                case 12:
                case 14:
                case 15:
                    qryMonatsbudget.Fill(qryBgPosition["KlientID"], null);
                    while (!DBUtil.IsEmpty(qryBgPosition["BgBudgetID"]) && !DBUtil.IsEmpty(qryMonatsbudget["BgBudgetID"]) &&
                           (int)qryBgPosition["BgBudgetID"] != (int)qryMonatsbudget["BgBudgetID"])
                    {
                        if (!qryMonatsbudget.Next())
                        {
                            break;
                        }
                    }

                    break;

                default:
                    qryMonatsbudget.Fill(qryBgPosition["KlientID"], qryBgPosition["BgBudgetID"]);
                    break;
            }
            _filling = false;

            qryBgDokumente.Fill(qryBgPosition["BgPositionID"]);
            qryBgBewilligung.Fill(qryBgPosition["BgPositionID"]);

            if (kategorie == 101)
            {
                LoadSpezialkonto(null);
            }

            LoadPerson(false);
            _buchungstext.LoadBuchungstext(qryBgPosition["BgPositionsartID"] as int?, false);
            LoadKontrolle(false);

            UpdateLetzte10Buchungen();
            SetEditMode();
        }

        private void qryBgPosition_PostCompleted(object sender, EventArgs e)
        {
            int positonBewilligung = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);
            int budgetBewilligung = ShUtil.GetCode(qryMonatsbudget["BgBewilligungStatusCode"]);
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

            //Automatische Anfrage für graue ZL und fehlender Kompetenz
            if (edtAutomAnfrage.Checked && kategorie == 100 && positonBewilligung == 1 && !GetUserPermission())
            {
                try
                {
                    if (PositionAnfragen())
                    {
                        qryBgPosition["Status"] = 12; // angefragt
                        qryBgPosition.Row.AcceptChanges();
                        qryBgPosition.RowModified = false;
                        qryBgPosition.RefreshDisplay();
                        qryBgBewilligung.Fill(qryBgPosition["BgPositionID"]);
                    }
                }
                catch (Exception ex)
                {
                    KissMsg.ShowInfo("Fehler bei der Bewilligungsabfrage:\r\n\r\n" + ex.Message);
                }
            }

            // im grünen Monatsbudget: bewilligte, graue Zusatzleistung oder Einzelzahlung auf grün stellen
            if (budgetBewilligung == 5 && kategorie == 100 && positonBewilligung == 5)
            {
                try
                {
                    // Einfügen in Klibu
                    DBUtil.ExecSQLThrowingException(@"
                        EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0, null, {2}",
                        qryMonatsbudget["BgBudgetID"],
                        Session.User.UserID,
                        qryBgPosition["BgPositionID"]);

                    qryBgPosition["Status"] = 2; // freigegeben
                    qryBgPosition.Row.AcceptChanges();
                    qryBgPosition.RowModified = false;
                    SetEditMode();
                    qryBgPosition.RefreshDisplay();

                    // Monatsbudgets updaten (=> einschränken), damit die Position nicht verschoben werden kann
                    qryBgPosition_PositionChanged(null, null);
                    //alte Version: qryMonatsbudget.Fill(qryBgPosition["KlientID"], qryBgPosition["BgBudgetID"]);
                    XLog.Create(
                        TYPEFULLNAME,
                        1,
                        LogLevel.DEBUG,
                        "Buchung erstellt",
                        string.Format(
                            "KbBuchungID: {0}",
                            DBUtil.ExecuteScalarSQL(
                                "SELECT TOP 1 KbBuchungID FROM KbBuchungKostenart WHERE BgPositionID = {0}",
                                qryBgPosition["BgPositionID"])),
                        "BgPosition",
                        ShUtil.GetCode(qryBgPosition["BgPositionID"]));
                }
                catch (Exception ex)
                {
                    KissMsg.ShowInfo("Fehler beim Grünstellen der Position:\r\n\r\n" + ex.Message);
                    XLog.Create(
                        TYPEFULLNAME,
                        2,
                        LogLevel.DEBUG,
                        "Fehler beim Erstellen der Buchung",
                        ex.Message,
                        "BgPosition",
                        ShUtil.GetCode(qryBgPosition["BgPositionID"]));
                }
            }

            SetEditMode();
        }

        private void qryMonatsbudget_PositionChanged(object sender, EventArgs e)
        {
            if (_filling)
            {
                return;
            }

            qryBgPosition.RowModified = true;

            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            if (kategorie == 101)
            {
                LoadSpezialkonto(null);
            }

            if (_origVerwPeriodeVon.ToString() == qryBgPosition["VerwPeriodeVon"].ToString() &&
                _origVerwPeriodeBis.ToString() == qryBgPosition["VerwPeriodeBis"].ToString())
            {
                SetVerwendungsPeriode();
            }

            qryBgPosition["TeamZustaendig"] = qryMonatsbudget["TeamZustaendig"];

            LoadPerson(false);
        }

        private void UpdateLetzte10Buchungen()
        {
            _tasks.Add(Task.Factory.StartNew(
                () =>
                {
                    var kostenart = DBUtil.IsEmpty(qryBgPosition["KOA"]) ? 0 : Convert.ToInt32(qryBgPosition["KOA"]);
                    var baPersonId = DBUtil.IsEmpty(qryBgPosition["KlientID"]) ? 0 : Convert.ToInt32(qryBgPosition["KlientID"]);

                    if (kostenart != _kostenart || baPersonId != _baPersonId)
                    {
                        _kostenart = kostenart;
                        _baPersonId = baPersonId;
                        Task.WaitAll(_tasks.Where(x => x.Id != Task.CurrentId).ToArray());
                        qryLetzte10Buchungen.Fill(kostenart, baPersonId);
                    }

                    _tasks.RemoveAll(x => x.Id == Task.CurrentId || x.Status == TaskStatus.Canceled || x.Status == TaskStatus.Faulted || x.Status == TaskStatus.RanToCompletion);
                }));
        }

        #endregion EventHandlers

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                qryBgDokumente.Insert();
            }
            else
            {
                qryBgPosition.Insert();
            }

            return true;
        }

        public override bool OnDeleteData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                return qryBgDokumente.Delete();
            }

            return qryBgPosition.Delete();
        }

        public override bool OnKeyDownKiss(KeyEventArgs e)
        {
            var keys = DBUtil.GetConfigShortcut(@"System\Allgemein\NeuesDokumentShortcut", "Control+N");

            if (e.KeyData == keys.KeyData)
            {
                DocumentImport();
            }

            return base.OnKeyDownKiss(e);
        }

        public override bool OnSaveData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                return qryBgDokumente.Post();
            }

            var returnValue = qryBgPosition.Post();
            UpdateLetzte10Buchungen();

            return returnValue;
        }

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            if (qryBgPosition.Count == 0)
            {
                return;
            }

            int status = ShUtil.GetCode(qryBgPosition["Status"]);

            if (qryBgPosition.Row.RowState != DataRowState.Added && (status != 1 && status != 12 && status != 14 && status != 15))
            {
                KissMsg.ShowInfo("Neue Daten vom Belegleser: Der Status der Position erlaubt keine Änderung der erfassten Daten");
                return;
            }

            if (IsZahlwegFix())
            {
                KissMsg.ShowInfo("Neue Daten vom Belegleser: Der fixe Kreditor darf nicht geändert werden");
                return;
            }

            var dlg = new DlgAuswahlBaZahlungsweg();
            ApplicationFacade.DoEvents();

            bool transfer = false;
            dlg.SucheBaZahlungsweg(beleg);
            switch (dlg.Count)
            {
                case 0:
                    KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                    if (beleg.Betrag > 0)
                    {
                        qryBgPosition["BetragSpezial"] = beleg.Betrag;
                    }

                    qryBgPosition["ReferenzNummer"] = beleg.ReferenzNummer;
                    break;

                case 1:
                    transfer = true;
                    break;

                default:
                    transfer = dlg.ShowDialog(this) == DialogResult.OK;
                    break;
            }

            if (transfer)
            {
                qryBgPosition["BaZahlungswegID"] = dlg["BaZahlungswegID"];
                qryBgPosition["Kreditor"] = dlg["Kreditor"];
                qryBgPosition["ZusatzInfo"] = dlg["ZusatzInfo"];
                if (beleg.Betrag > 0)
                {
                    qryBgPosition["BetragSpezial"] = beleg.Betrag;
                }

                qryBgPosition["ReferenzNummer"] = beleg.ReferenzNummer;
                qryBgPosition["EinzahlungsscheinCode"] = dlg["EinzahlungsscheinCode"];

                if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                {
                    if (DBUtil.IsEmpty(qryMonatsbudget["FaFallID"]))
                    {
                        KissMsg.ShowInfo("Es ist kein Monatsbudget ausgewählt! Deshalb kann die 1. Mitteilungszeile nicht korrekt gebildet werden");
                    }

                    SqlQuery qry3 = DBUtil.OpenSQL(@"
                        select FallNrNameVorname = isnull('F' + convert(varchar,{1}) + ' ','') + NameVorname,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                        from   vwPerson
                        where  BaPersonID = {0}",
                            qryMonatsbudget["LeistungBaPersonID"],
                            qryMonatsbudget["FaFallID"]);

                    qryBgPosition["MitteilungZeile1"] = TruncateString(qry3["FallNrNameVorname"], 35);
                    qryBgPosition["ReferenzNummer"] = DBNull.Value;
                }
            }

            qryBgPosition.RefreshDisplay();
            SetEditMode();
        }

        #endregion Public Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            PresetSearchFields();

            edtSucheErfassungMA.Focus();
        }

        protected override void RunSearch()
        {
            base.RunSearch();

            if (qryBgPosition.Count == 0)
            {
                qryBgPosition_PositionChanged(null, null);
            }
            else
            {
                qryBgPosition.Last();
            }
        }

        #endregion Protected Methods

        #region Private Methods

        private bool AuswahlKreditorFamoz(string searchString, bool buttonClicked)
        {
            bool cancel = false;
            searchString = searchString.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else if (!IsZahlwegFix())
                {
                    qryBgPosition["Kreditor"] = DBNull.Value;
                    qryBgPosition["ZusatzInfo"] = DBNull.Value;
                    qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryBgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                    qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                    qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                    qryBgPosition["MitteilungZeile3"] = DBNull.Value;
                    SetEditMode();
                    return false;
                }
            }

            var kategorie = (int)qryBgPosition["BgKategorieCode"];

            //Auszahlung an fixe Zahladresse
            if (SetKreditorIfZahlungswegFix())
            {
                SetEditMode();
                return false;
            }

            if (kategorie == 101 && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"])
                && !DBUtil.UserHasRight("FrmWhEinzelzahlungen_KeineInstitutionsBindung")) //Einzelzahlung mit Spezialkonto
            {
                // Die Institutionen können beim Finanzplan bei einigen LAs angegeben werden, auf der Maske WhSpezialkonten können sie nicht
                // mehr geändert werden.
                // Es wird in ZH keine Benutzer mehr ohne obiges Spezial-Recht geben (Aufgrund von zu vielen Falscherfassungen bei den
                // Institutionen). Der Code bleibt für den Fall, dass sich die Meinung diesbezüglich wieder ändert.
                object baInstitutionID = GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "BaInstitutionID");
                if (!DBUtil.IsEmpty(baInstitutionID))
                {
                    //Zahlwegbindung an Institution
                    var dlg3 = new KissLookupDialog();
                    cancel = !dlg3.SearchData(@"
                        SELECT ID$          = KRE.BaZahlungswegID,
                               Institution  = KRE.InstitutionName,
                               Zahlungsweg  = KRE.Zahlungsweg,
                               ESCode$      = KRE.EinzahlungsscheinCode,
                               Kreditor$    = KRE.Kreditor,
                               ZusatzInfo$  = KRE.ZusatzInfo
                        FROM   vwKreditor KRE
                        WHERE  KRE.BaInstitutionID = " +
                            baInstitutionID +
                            @" AND
                               GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                               KRE.BaFreigabeStatusCode = 2 AND
                               KRE.InstitutionIstKreditor = 1",
                            "",
                            buttonClicked,
                            null,
                            null,
                            null);

                    if (!cancel)
                    {
                        qryBgPosition["Kreditor"] = dlg3["Kreditor$"];
                        qryBgPosition["ZusatzInfo"] = dlg3["ZusatzInfo$"];
                        qryBgPosition["BaZahlungswegID"] = dlg3["ID$"];
                        qryBgPosition["EinzahlungsscheinCode"] = dlg3["ESCode$"];

                        if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                        {
                            qryBgPosition["ReferenzNummer"] = DBNull.Value;
                        }
                        else
                        {
                            qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                            qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                            qryBgPosition["MitteilungZeile3"] = DBNull.Value;
                        }
                    }

                    SetEditMode();
                    return cancel;
                }
            }

            if (searchString == ".")
            // Auszahlung an
            // Klientensystem       - FaFallPerson
            // Involvierte Stellen  - FaInvolvierteInstitution
            // Krankenkasse         - BaKrankenversicherung
            // Vermieter            - BaWohnsituation
            // Arbeitgeber          - BaArbeit
            {
                if (DBUtil.IsEmpty(qryMonatsbudget["FaFallID"]))
                {
                    KissMsg.ShowInfo("Es ist kein Monatsbudget ausgewählt!");
                    qryBgPosition["Kreditor"] = DBNull.Value;
                    return false;
                }

                var dlg = new KissLookupDialog();
                cancel = !dlg.SearchData(@"
                    -- Personen im Haushalt
                    SELECT ID$          = KRE.BaZahlungswegID,
                           Typ          = 'Klientensystem',
                           Name         = KRE.PersonNameVorname,
                           Zahlungsweg  = KRE.Zahlungsweg,
                           ESCode$      = KRE.EinzahlungsscheinCode,
                           Kreditor$    = KRE.Kreditor,
                           ZusatzInfo$  = KRE.ZUsatzInfo,
                           SortKey$     = 1
                    FROM   FaFallPerson FAP
                           INNER JOIN vwKreditor KRE ON KRE.BaPersonID = FAP.BaPersonID
                    WHERE  FAP.FaFallID = {0}
                            AND GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate())
                            AND GetDate() BETWEEN ISNULL(FAP.DatumVon, CONVERT(DateTime, '1900-01-01')) AND ISNULL(FAP.DatumBis, CONVERT(DateTime, '2079-06-06'))

                    UNION

                    -- Involvierte Stellen
                    SELECT ID$          = KRE.BaZahlungswegID,
                           Typ          = 'involvierte Stelle',
                           Name         = KRE.InstitutionName,
                           Zahlungsweg  = KRE.Zahlungsweg,
                           ESCode$      = KRE.EinzahlungsscheinCode,
                           Kreditor$    = KRE.Kreditor,
                           ZusatzInfo$  = KRE.ZusatzInfo,
                           SortKey$     = 2
                    FROM   FaInvolvierteInstitution INV
                           INNER JOIN vwKreditor    KRE ON KRE.BaInstitutionID = INV.BaInstitutionID
                    WHERE  INV.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    UNION

                    -- Krankenkasse
                    SELECT ID$          = KRE.BaZahlungswegID,
                           Typ          = 'Krankenkasse',
                           Name         = KRE.InstitutionName,
                           Zahlungsweg  = KRE.Zahlungsweg,
                           ESCode$      = KRE.EinzahlungsscheinCode,
                           Kreditor$    = KRE.Kreditor,
                           ZusatzInfo$  = KRE.ZusatzInfo,
                           SortKey$     = 3
                    FROM   FaFallPerson FAP
                           INNER JOIN BaKrankenversicherung KKV ON KKV.BaPersonID = FAP.BaPersonID
                           INNER JOIN vwKreditor            KRE ON KRE.BaInstitutionID = KKV.BaInstitutionID
                    WHERE  FAP.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    UNION

                    -- Vermieter
                    SELECT ID$          = KRE.BaZahlungswegID,
                           Typ          = 'Vermieter',
                           Name         = KRE.InstitutionName,
                           Zahlungsweg  = KRE.Zahlungsweg,
                           ESCode$      = KRE.EinzahlungsscheinCode,
                           Kreditor$    = KRE.Kreditor,
                           ZusatzInfo$  = KRE.ZusatzInfo,
                           SortKey$     = 4
                    FROM   FaFallPerson FAP
                           INNER JOIN BaWohnsituationPerson WOP ON WOP.BaPersonID = FAP.BaPersonID
                           INNER JOIN BaWohnsituation       WOH ON WOH.BaWohnsituationID = WOP.BaWohnsituationID
                           INNER JOIN vwKreditor            KRE ON KRE.BaInstitutionID = WOH.BaInstitutionID
                    WHERE  FAP.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    UNION

                    -- Abeitgeber
                    SELECT ID$          = KRE.BaZahlungswegID,
                           Typ          = 'Arbeitbeger',
                           Name         = KRE.InstitutionName,
                           Zahlungsweg  = KRE.Zahlungsweg,
                           ESCode$      = KRE.EinzahlungsscheinCode,
                           Kreditor$    = KRE.Kreditor,
                           ZusatzInfo$  = KRE.ZusatzInfo,
                           SortKey$     = 5
                    FROM   FaFallPerson FAP
                           INNER JOIN BaArbeit   ARB ON ARB.BaPersonID = FAP.BaPersonID
                           INNER JOIN vwKreditor KRE ON KRE.BaInstitutionID = ARB.BaInstitutionID
                    WHERE  FAP.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    ORDER BY SortKey$,Name,Zahlungsweg",
                        qryMonatsbudget["FaFallID"].ToString(),
                        buttonClicked,
                        null,
                        null,
                        null);

                if (!cancel)
                {
                    qryBgPosition["Kreditor"] = dlg["Kreditor$"];
                    qryBgPosition["ZusatzInfo"] = dlg["ZusatzInfo$"];
                    qryBgPosition["BaZahlungswegID"] = dlg["ID$"];
                    qryBgPosition["EinzahlungsscheinCode"] = dlg["ESCode$"];

                    if (kategorie == 100)
                    {
                        qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                    }

                    if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                    {
                        SqlQuery qry3 =
                            DBUtil.OpenSQL(
                                @"
                            select FallNrNameVorname = 'F' + convert(varchar,{1}) + ' ' + NameVorname,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                            from   vwPerson
                            where  BaPersonID = {0}",
                                qryMonatsbudget["LeistungBaPersonID"],
                                qryMonatsbudget["FaFallID"]);

                        qryBgPosition["MitteilungZeile1"] = TruncateString(qry3["FallNrNameVorname"], 35);
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    }
                    else
                    {
                        qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile3"] = DBNull.Value;
                    }

                    SetEditMode();
                    return false;
                }
            }
            else // Auszahlung Dritte
            {
                var dlg2 = new DlgAuswahlBaZahlungsweg();
                ApplicationFacade.DoEvents();

                bool transfer = false;
                dlg2.SucheBaZahlungsweg(searchString);
                switch (dlg2.Count)
                {
                    case 0:
                        KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                        break;

                    case 1:
                        transfer = true;
                        break;

                    default:
                        transfer = dlg2.ShowDialog(this) == DialogResult.OK;
                        break;
                }

                if (transfer)
                {
                    qryBgPosition["BaZahlungswegID"] = dlg2["BaZahlungswegID"];
                    qryBgPosition["Kreditor"] = dlg2["Kreditor"];
                    qryBgPosition["ZusatzInfo"] = dlg2["ZusatzInfo"];
                    qryBgPosition["EinzahlungsscheinCode"] = dlg2["EinzahlungsscheinCode"];

                    kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

                    if (kategorie == 100 || kategorie == 2)
                    {
                        qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                    }

                    if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                    {
                        SqlQuery qry2 = DBUtil.OpenSQL(@"
                            select FallNrNameVorname = 'F' + convert(varchar,{1}) + ' ' + NameVorname,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                            from   vwPerson
                            where  BaPersonID = {0}",
                                qryMonatsbudget["LeistungBaPersonID"],
                                qryMonatsbudget["FaFallID"]);

                        qryBgPosition["MitteilungZeile1"] = TruncateString(qry2["FallNrNameVorname"], 35);
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    }
                    else
                    {
                        qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile3"] = DBNull.Value;
                    }
                }

                qryBgPosition.RefreshDisplay();
                SetEditMode();
            }

            return cancel;
        }

        private bool CheckKontrolleUser()
        {
            var creator = Convert.ToInt32(qryBgPosition["ErstelltUserID"]);
            return creator != Session.User.UserID;
        }

        private void DocumentImport()
        {
            if (qryBgPosition.Post())
            {
                tabBgPosition.SelectTab(tpgDokumente);
                qryBgDokumente.Insert();
                edtDocument.Focus();
                edtDocument.ImportDoc();
            }
        }

        private void FillPersonInfoIntoMitteilungZeile2()
        {
            // es könnte noch kein Klient ausgewählt sein, dann wäre auch die DataSource null
            if (edtBaPersonID.Properties.DataSource is SqlQuery && (edtBaPersonID.EditValue is int || qryBgPosition["BaPersonID"] is int))
            {
                int selectedBaPersonID;
                if (edtBaPersonID.EditValue is int)
                {
                    selectedBaPersonID = (int)edtBaPersonID.EditValue;
                }
                else
                {
                    selectedBaPersonID = (int)qryBgPosition["BaPersonID"];
                }

                var qryPersons = ((SqlQuery)edtBaPersonID.Properties.DataSource);

                foreach (DataRow person in qryPersons.DataTable.Rows)
                {
                    if ((int)person["Code"] == selectedBaPersonID)
                    {
                        string text = string.Format("P{0} {1}", person["Code"], person["NameVorname"]);
                        if (text.Length > 35)
                        {
                            text = text.Substring(0, 35);
                        }

                        if ((int)qryBgPosition["BgKategorieCode"] == 101 && qryBgPosition["MitteilungZeile2"] as string != text) // EZ
                        {
                            //					qryBgPosition["MitteilungZeile2"] = text;
                            edtMitteilungZeile2.EditValue = text;
                        }
                        else
                        {
                            edtMitteilungZeile2.EditValue = text;
                        }

                        break;
                    }
                }
            }
        }

        private object GetFieldFromSpezkonto(object bgSpezkontoID, string fieldName)
        {
            var qry = (SqlQuery)edtBgSpezkontoID.Properties.DataSource;

            var rows = qry.DataTable.Select(DBUtil.IsEmpty(bgSpezkontoID) ? "Code is null" : string.Format("Code = {0}", bgSpezkontoID));

            if (rows.Length == 1)
            {
                return rows[0][fieldName];
            }

            return null;
        }

        private bool GetUserPermission()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                select ok = dbo.fnWhPosition_Permission({0},{1})",
                qryBgPosition["BgPositionID"],
                Session.User.UserID);

            if (qry.Count > 0)
            {
                return (bool)qry["ok"];
            }

            return false;
        }

        private void InsertPositionVerlaufEintrag(int bgBewilligungCode, int bgPositionID)
        {
            WhUtil.InsertPositionVerlaufEintrag(bgPositionID, Session.User.UserID, Name, bgBewilligungCode);
            qryBgBewilligung.Fill(bgPositionID);
        }

        private bool IsZahlwegFix()
        {
            return !DBUtil.IsEmpty(qryBgPosition["BaZahlungswegIDFix"]);
        }

        /// <summary>
        /// Berechnet das Feld Kontrolle
        ///
        /// - Feld hat nur einen Inhalt, wenn Position in der Einzelmaske erstellt worden ist.
        /// - Feld enthält den User, welche die Position angefraget oder grüngesteltl hat.
        /// - Kommt die Position wieder in den Status grau, dann wird das Feld zurückgesetzet.
        /// </summary>
        /// <param name="doRefresh"><c>true</c> wenn die Daten neu aus der DB geladen werden müssen</param>
        private void LoadKontrolle(bool doRefresh)
        {
            bool kontrolleLoaded = qryBgPosition["Kontrolle_Loaded"] as bool? ?? true;

            if (doRefresh || !kontrolleLoaded)
            {
                // Kontrolle neu aus der DB laden
                var qry = DBUtil.OpenSQL(@"
                    SELECT ID,
                           UserID,
                           LogonName,
                           Datum,
                           DatumText,
                           BgBewilligungCode
                    FROM dbo.fnWhGetPositionKontrolle({0}, {1});",
                    qryBgPosition["BgPositionID"],
                    Name);

                var rowModified = qryBgPosition.RowModified;
                qryBgPosition["Kontrolle_UserID"] = qry["UserID"];
                qryBgPosition["Kontrolle_LogonName"] = qry["LogonName"];
                qryBgPosition["Kontrolle_Datum"] = qry["DatumText"];
                qryBgPosition["Kontrolle_Loaded"] = true;

                if (!rowModified)
                {
                    qryBgPosition.Row.AcceptChanges();
                    qryBgPosition.RowModified = false;
                }
            }

            if (DBUtil.IsEmpty(qryBgPosition["Kontrolle_UserID"]))
            {
                _kontrolleUserId = null;
                lblKontrolle.Text = "---";
            }
            else
            {
                _kontrolleUserId = (int)qryBgPosition["Kontrolle_UserID"];
                lblKontrolle.Text = string.Format("{0}, {1}", qryBgPosition["Kontrolle_LogonName"], qryBgPosition["Kontrolle_Datum"]);
            }
        }

        private void LoadPerson(bool autoSetSinglePerson)
        {
            edtBaPersonID.LoadQuery(
                DBUtil.OpenSQL(@"
                select Code = FPP.BaPersonID,
                       Text = PRS.NameVorname +
                              ' (' + isNull(convert(varchar,PRS.AlterMortal),'-') +
                              isNull(',' + GES.ShortText,'') + ')',
                       NameVorname = PRS.NameVorname
                from   BgFinanzPlan_BaPerson FPP
                       inner join vwPerson PRS on PRS.BaPersonID = FPP.BaPersoNID
                       left  join XLOVCode GES on GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode
                where  BgFinanzplanID = {0} and
                       IstUnterstuetzt = 1
                order by PRS.NameVorname",
                    qryMonatsbudget["BgFinanzplanID"]));

            var qry = (SqlQuery)edtBaPersonID.Properties.DataSource;

            if (autoSetSinglePerson && !(bool)qryBgPosition["Quoting"] && qry.Count == 1)
            {
                qryBgPosition["BaPersonID"] = qry["Code"];
            }
        }

        private void LoadSpezialkonto(object bgKostenartID)
        {
            edtBgSpezkontoID.Properties.ShowHeader = true;
            edtBgSpezkontoID.Properties.DropDownRows = 7;
            edtBgSpezkontoID.Properties.DataSource = DBUtil.OpenSQL(@"
                SELECT Code               = SPK.BgSpezkontoID,
                       Typ                = TYP.ShortText,
                       KOA                = BKA.KontoNr,
                       Text               = SPK.NameSpezkonto,
                       Saldo              = dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, {0}, {1}),
                       SortKey            = TYP.Sortkey,
                       KOAName            = BKA.KontoNr + ' ' + BKA.Name,
                       BaPersonID         = SPK.BaPersonID,
                       BgPositionsartID   = SPK.BgPositionsartID,
                       BgKostenartID      = BKA.BgKostenartID,
                       KOAPositionsart    = BKA.KontoNr + ' '+ ISNULL(BPA.Name,BKA.Name),
                       BgSplittingArtCode = BKA.BgSplittingArtCode,
                       Quoting            = BKA.Quoting,
                       BaInstitutionID    = SPK.BaInstitutionID,
                       BaZahlungswegIDFix = BKA.BaZahlungswegIDFix,
                       SaldoTotal         = dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, NULL, {1})
                FROM BgSpezkonto            SPK
                  INNER JOIN XLOVCode       TYP ON TYP.LOVName = 'BgSpezkontoTyp' and TYP.Code = SPK.BgSpezkontoTypCode
                  LEFT  JOIN BgPositionsart BPA ON BPA.BgPositionsartID = SPK.BgPositionsartID
                  LEFT  JOIN BgPositionsart GBL ON GBL.BgPositionsartID = {4}
                  LEFT  JOIN BgKostenart    BKA ON BKA.BgKostenartID = ISNULL(SPK.BgKostenartID,GBL.BgKostenartID)
                WHERE (FaLeistungID = {2}
                         AND isNull({3}, SPK.BgKostenartID) = SPK.BgKostenartID
                         AND NOT (SPK.BgSpezkontoTypCode = 3 AND SPK.OhneEinzelzahlung = 1) -- Verrechnung mit Einzelzahlung
                         AND SPK.BgSpezkontoTypCode in (1,3) -- Ausgabe- und Verrechnungskonti
                         AND EXISTS (SELECT TOP 1 1
                                     FROM BgPositionsart
                                     WHERE BgKostenartID = SPK.BgKostenartID AND BgKategorieCode IN (2,3,101))) --es muss eine aktive Ausgabe-, Verrechnungs- oder Einzelzahlungs-Positionsart geben
                     --Spezialkonto anzeigen, wenn der aktuelle Datensatz es bereits verwendet
                     OR EXISTS (SELECT TOP 1 1 FROM BgPosition WHERE BgPositionID = {1} AND BgSpezkontoID = SPK.BgSpezkontoID)

                UNION ALL

                SELECT Code               = NULL,
                       Typ                = NULL,
                       KOA                = NULL,
                       Text               = NULL,
                       Saldo              = NULL,
                       SortKey            = 0,
                       KOAName            = BKA.KontoNr + ' ' + BKA.Name,
                       BaPersonID         = NULL,
                       BgPositionsartID   = BPA.BgPositionsartID,
                       BgKostenartID      = BPA.BgKostenartID,
                       KOAPositionsart    = BKA.KontoNr + ' '+ BPA.Name,
                       BgSplittingArtCode = BKA.BgSplittingArtCode,
                       Quoting            = BKA.Quoting,
                       BaInstitutionID    = NULL,
                       BaZahlungswegIDFix = BKA.BaZahlungswegIDFix,
                       SaldoTotal         = NULL
                FROM BgKostenart            BKA
                  INNER JOIN BgPositionsart BPA ON BPA.BgKostenartID = BKA.BgKostenartID
                WHERE BPA.BgPositionsartID = {4}
                ORDER BY SortKey, Text",
                    qryMonatsbudget["BgBudgetID"],
                    qryBgPosition["BgPositionID"],
                    qryMonatsbudget["FaLeistungID"],
                    bgKostenartID,
                    qryMonatsbudget["WhGrundbedarfTypCode"]);
        }

        private bool PositionAnfragen()
        {
            try
            {
                Session.BeginTransaction();
                var stellenleiterID = (int)DBUtil.ExecuteScalarSQL(@"
                    select isnull(USR.StellenleiterID,{1})
                    from   FaLeistung LEI
                           inner join vwUser USR on USR.UserID = LEI.UserID
                    where  LEI.FaLeistungID = {0}",
                        qryMonatsbudget["FaLeistungID"],
                        Session.User.UserID);

                // Bewilligungs-Verlauf
                DBUtil.ExecSQLThrowingException(@"
                    INSERT BgBewilligung (BgFinanzplanID,BgBudgetID,BgPositionID,UserID,UserID_An,Datum,BgBewilligungCode)
                    VALUES ({0},{1},{2},{3},{4}, getdate(),1)",
                    qryMonatsbudget["BgFinanzplanID"],
                    qryMonatsbudget["BgBudgetID"],
                    qryBgPosition["BgPositionID"],
                    qryMonatsbudget["LT"],
                    stellenleiterID);

                // zusätzliche Leistung
                DBUtil.ExecSQLThrowingException(@"
                UPDATE BgPosition
                SET    BgBewilligungStatusCode = 3
                WHERE  BgPositionID = {0}",
                    qryBgPosition["BgPositionID"]);

                Session.Commit();
                return true;
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo("Fehler bei der Bewilligungsabfrage:\r\n\r\n" + ex.Message);
                return false;
            }
        }

        private void PresetSearchFields()
        {
            edtSucheErfassungMA.EditValue = Session.User.LogonName;
            edtSucheErfassungMA.LookupID = Session.User.UserID;
            edtSucheSelectTop.EditValue = 1000;
            edtSucheErfassungVon.EditValue = DateTime.Today;
            edtSucheErfassungBis.EditValue = DateTime.Today;
        }

        private void SetEditMode()
        {
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            int status = ShUtil.GetCode(qryBgPosition["Status"]);
            int es = ShUtil.GetCode(qryBgPosition["EinzahlungsscheinCode"]);
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
            bool hauptPos = !DBUtil.IsEmpty(qryBgPosition["HauptPos"]);
            bool kreditorFix = IsZahlwegFix();

            bool editable = (status <= 1 || status == 12 || status == 14 || status == 15);

            //Eine Mutation an einer Zusätzlichen Leistungen im Status „angefragt“ oder "freigegeben" kann nur derjenige MA vornehmen,
            // welcher die Position zur Bewilligung angefragt hat (= Eintrag User-ID im Feld „kontr.“) (ausser Spezialrecht)
            if (kategorie == 100 && status == 12 || status == 2) //Zus. Leistung im Status „angefragt“ oder "freigegeben"
            {
                if (_freigegebeneMutieren || _kontrolleUserId == null || Session.User.UserID == _kontrolleUserId)
                {
                    btnPositionBewilligung.Visible = true;
                }
                else
                {
                    btnPositionBewilligung.Visible = false;
                    editable = false;
                }
            }

            //Das Zurücksetzen einer Einzelzahlung vom Status „grün“ zu Status „grau“ kann nur derjenige MA vornehmen,
            //welcher die Position zur Bewilligung angefragt hat
            if (kategorie == 101 && status == 2) //Einzelzahlung im Status „grün“
            {
                if (_freigegebeneMutieren || _kontrolleUserId == null || Session.User.UserID == _kontrolleUserId)
                {
                    btnPositionGrau.Visible = true;
                }
                else
                {
                    btnPositionGrau.Visible = false;
                    editable = false;
                }
            }

            qryBgPosition.EnableBoundFields(editable);
            grdMonatsbudget.Enabled = editable;

            //Verwendungsperiode + Splitting
            switch (bgSplittingArtCode)
            {
                case 1: //Taggenau
                case 2: //monat
                    edtVerwPeriodeVon.EditMode = editable && !hauptPos ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = editable && !hauptPos ? EditModeType.Normal : EditModeType.ReadOnly;
                    break;

                case 4: //Entscheid
                    edtVerwPeriodeVon.EditMode = editable && !hauptPos ? EditModeType.Normal : EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;

                default:
                    edtVerwPeriodeVon.EditMode = EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;
            }

            //Positionsbuttons Bewilligung, Gruen, Grau
            btnPositionBewilligung.Visible = (kategorie == 100 && (status == 1 || status == 12 || status == 15)); //graue/angefragte/abgelehnte ZL
            btnPositionGruen.Visible = (kategorie == 101 && status == 1) || (kategorie == 100 && status == 14); //graue EZ oder bewilligte ZL
            btnPositionGrau.Visible = (status == 2); //grüne EZ/ZL
            // Position mit einer Verrechnungsposition darf nicht graugestellt werden
            if (!DBUtil.IsEmpty(qryBgPosition["BgPositionID"]) && WhUtil.HasVerrechnungsPosition((int)qryBgPosition["BgPositionID"]))
            {
                btnPositionGrau.Visible = false;
                btnPositionGruen.Visible = false;
            }

            // Positionsbuttons nebeneinander platzieren
            int buttonWidth = btnPositionBewilligung.Width;
            int leftMargin = edtBetrag.Left + edtBetrag.Width + 6;

            if (btnPositionBewilligung.Visible)
            {
                btnPositionBewilligung.Left = leftMargin;
                leftMargin += buttonWidth + 5;
            }

            if (btnPositionGrau.Visible)
            {
                btnPositionGrau.Left = leftMargin;
                leftMargin += buttonWidth + 5;
            }

            if (btnPositionGruen.Visible)
            {
                btnPositionGruen.Left = leftMargin;
                //leftMargin += buttonWidth + 5;
            }

            //set edit modes of edit fields
            edtKostenart.EditMode = editable && !hauptPos && (kategorie == 100) ? EditModeType.Normal : EditModeType.ReadOnly;
            edtBuchungstext.EditMode = editable && !hauptPos ? EditModeType.Normal : EditModeType.ReadOnly;
            edtBetrag.EditMode = editable && !hauptPos ? EditModeType.Normal : EditModeType.ReadOnly;
            edtBgSpezkontoID.EditMode = editable && !hauptPos && (kategorie == 101) ? EditModeType.Normal : EditModeType.ReadOnly;

            // Mit Spezialrecht "FrmWhEinzelzahlungen_KeineInstitutionsBindung" kann auch ein fixer Zahlungsweg verändert werden
            edtKreditor.EditMode = editable && !kreditorFix ? EditModeType.Normal : EditModeType.ReadOnly;
            edtReferenzNummer.EditMode = (es == 1) && editable && !kreditorFix ? EditModeType.Normal : EditModeType.ReadOnly;
            edtMitteilungZeile2.EditMode = ((es == 2) || (es == 3) || (es == 4) || (es == 5)) && editable
                                               ? EditModeType.Normal
                                               : EditModeType.ReadOnly;

            bool quoting = !DBUtil.IsEmpty(qryBgPosition["Quoting"]) && (bool)qryBgPosition["Quoting"];
            edtBaPersonID.EditMode = editable && !quoting ? EditModeType.Normal : EditModeType.ReadOnly;

            btnWeitereKOA.Text = string.Format("Weitere " + KOA_TEXT + " ({0})", qryBgPosition["WeitereKOA"]);
            btnWeitereKOA.Visible = qryBgPosition.Count > 0 &&
                                    qryBgPosition.Row.RowState != DataRowState.Added &&
                                    (editable || hauptPos);
        }

        private bool SetKreditorIfZahlungswegFix()
        {
            if (IsZahlwegFix())
            {
                SqlQuery qry = DBUtil.OpenSQL("SELECT * FROM vwKreditor WHERE BaZahlungswegID = {0}", qryBgPosition["BaZahlungswegIDFix"]);
                if (qry.Count == 1)
                {
                    qryBgPosition["Kreditor"] = qry["Kreditor"];
                    qryBgPosition["ZusatzInfo"] = qry["ZusatzInfo"];
                    qryBgPosition["BaZahlungswegID"] = qry["BaZahlungswegID"];
                    qryBgPosition["EinzahlungsscheinCode"] = qry["EinzahlungsscheinCode"];

                    if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                    {
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;

                        if (DBUtil.IsEmpty(qryMonatsbudget["FaFallID"]))
                        {
                            KissMsg.ShowInfo(
                                "Es ist kein Monatsbudget ausgewählt! Deshalb kann die 1. Mitteilungszeile nicht korrekt gebildet werden");
                        }

                        SqlQuery qryZeile1 =
                            DBUtil.OpenSQL(
                                @"
                            select FallNrNameVorname = isnull('F' + convert(varchar,{1}) + ' ','') + NameVorname,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                            from   vwPerson
                            where  BaPersonID = {0}",
                                qryMonatsbudget["LeistungBaPersonID"],
                                qryMonatsbudget["FaFallID"]);

                        qryBgPosition["MitteilungZeile1"] = TruncateString(qryZeile1["FallNrNameVorname"], 35);
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;

                        FillPersonInfoIntoMitteilungZeile2();
                    }

                    return true;
                }

                qryBgPosition["Kreditor"] = DBNull.Value;
                qryBgPosition["ZusatzInfo"] = DBNull.Value;
                qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                qryBgPosition["EinzahlungsscheinCode"] = DBNull.Value;
            }
            return false;
        }

        /// <summary>
        /// Wird aufgerufen, sobald sich das Spezialkonto ändert.
        /// </summary>
        private void SetSpezialkonto()
        {
            object bgSpezKontoID = qryBgPosition["BgSpezKontoID"];

            var kategorie = (int)qryBgPosition["BgKategorieCode"];
            switch (kategorie)
            {
                case 101: //Einzelzahlung
                    qryBgPosition["BgPositionsartID"] = GetFieldFromSpezkonto(bgSpezKontoID, "BgPositionsartID");
                    qryBgPosition["KOA"] = GetFieldFromSpezkonto(bgSpezKontoID, "KOA");
                    qryBgPosition["Kostenart"] = GetFieldFromSpezkonto(bgSpezKontoID, "KOAPositionsart");
                    qryBgPosition["Quoting"] = GetFieldFromSpezkonto(bgSpezKontoID, "Quoting");
                    qryBgPosition["Buchungstext"] = GetFieldFromSpezkonto(bgSpezKontoID, "Text");
                    qryBgPosition["BgSplittingArtCode"] = GetFieldFromSpezkonto(bgSpezKontoID, "BgSplittingArtCode");
                    qryBgPosition["BaZahlungswegIDFix"] = GetFieldFromSpezkonto(bgSpezKontoID, "BaZahlungswegIDFix");
                    SetVerwendungsPeriode();

                    object baPersonID = GetFieldFromSpezkonto(bgSpezKontoID, "BaPersonID");
                    if (!DBUtil.IsEmpty(baPersonID))
                    {
                        qryBgPosition["BaPersonID"] = baPersonID;
                    }

                    //Auszahlung an fixe Zahladresse
                    if (!SetKreditorIfZahlungswegFix() && !DBUtil.UserHasRight("FrmWhEinzelzahlungen_KeineInstitutionsBindung"))
                    {
                        //siehe Kommentar in Funktion AuswahlKreditorFAMOZ
                        //falls Spezialkonto an eine Institution gebunden ist: Zahlweg einrichten
                        object baInstitutionID = GetFieldFromSpezkonto(bgSpezKontoID, "BaInstitutionID");
                        if (!DBUtil.IsEmpty(baInstitutionID))
                        {
                            qryBgPosition["ReferenzNummer"] = DBNull.Value;
                            qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                            qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                            qryBgPosition["MitteilungZeile3"] = DBNull.Value;

                            SqlQuery qry = DBUtil.OpenSQL("SELECT * FROM vwKreditor WHERE BaInstitutionID = {0}", baInstitutionID);
                            if (qry.Count == 1)
                            {
                                qryBgPosition["Kreditor"] = qry["Kreditor"];
                                qryBgPosition["ZusatzInfo"] = qry["ZusatzInfo"];
                                qryBgPosition["BaZahlungswegID"] = qry["BaZahlungswegID"];
                                qryBgPosition["EinzahlungsscheinCode"] = qry["EinzahlungsscheinCode"];

                                if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                                {
                                    SqlQuery qry1 =
                                        DBUtil.OpenSQL(
                                            @"
                                        select VornameName,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                                        from   vwPerson
                                        where  BaPersonID = {0}",
                                            qryMonatsbudget["LeistungBaPersonID"]);

                                    qryBgPosition["MitteilungZeile1"] = TruncateString(qry1["VornameName"], 35);
                                }
                            }
                            else
                            {
                                qryBgPosition["Kreditor"] = DBNull.Value;
                                qryBgPosition["ZusatzInfo"] = DBNull.Value;
                                qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                                qryBgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                            }
                        }
                    }

                    var bgPositionsartID = qryBgPosition["BgPositionsartID"] as int?;
                    var kostenartID = GetFieldFromSpezkonto(bgSpezKontoID, "BgKostenartID") as int?;
                    _buchungstext.LoadBuchungstextForSpezkonto(bgPositionsartID, kostenartID);

                    SetEditMode();
                    break;
            }

            qryBgPosition.RefreshDisplay();
        }

        private void SetVerwendungsPeriode()
        {
            if (!DBUtil.IsEmpty(qryBgPosition["HauptPos"]))
            {
                return;
            }

            try
            {
                int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);

                switch (bgSplittingArtCode)
                {
                    case 1: //Taggenau
                    case 2: //Monat
                        var firstDate = new DateTime((int)qryMonatsbudget["Jahr"], (int)qryMonatsbudget["Monat"], 1);
                        qryBgPosition["VerwPeriodeVon"] = firstDate;
                        qryBgPosition["VerwPeriodeBis"] = firstDate.AddMonths(1).AddDays(-1);
                        qryBgPosition.RefreshDisplay();
                        break;

                    case 3: //Valuta
                    case 4: //Entscheid
                        qryBgPosition["VerwPeriodeVon"] = DBNull.Value;
                        qryBgPosition["VerwPeriodeBis"] = DBNull.Value;
                        qryBgPosition.RefreshDisplay();
                        break;
                }
            }
            catch
            {
            }

            _origVerwPeriodeVon = qryBgPosition["VerwPeriodeVon"];
            _origVerwPeriodeBis = qryBgPosition["VerwPeriodeBis"];
        }

        private object TruncateString(object s, int maxLength)
        {
            if (DBUtil.IsEmpty(s))
            {
                return s;
            }

            if (!(s is String))
            {
                return s;
            }

            if (s.ToString().Length > maxLength)
            {
                return s.ToString().Substring(0, maxLength);
            }

            return s;
        }

        #endregion Private Methods

        #endregion Methods
    }
}