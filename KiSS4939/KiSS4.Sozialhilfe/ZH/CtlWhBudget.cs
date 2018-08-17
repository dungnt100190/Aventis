using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlWhBudget : KissUserControl, IBelegleser
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string TYPEFULLNAME = "KiSS4.Sozialhilfe.ZH.CtlWhBudget";
        private readonly int _bgBudgetID;
        private readonly int _budgetJahr = 1900;
        private readonly int _budgetMonat = 1;
        private readonly BgEditMask _editMask = new BgEditMask();
        private readonly int _faLeistungID;
        private readonly Hashtable _htBackColor = new Hashtable();
        private readonly bool _isMasterbudget = true;
        private readonly int _leistungBaPersonID;

        #endregion Private Constant/Read-Only Fields

        #region Private Fields

        private int? _bgSpezkontoIDToUpdate;
        private bool _calendarFilling;
        private string _editMaskInfo;
        private bool _isKliBuPosition;
        private int _newBgKategorieCode;
        private bool _newPosition;
        private bool _noRefresh;
        private bool _pendingZahlwegUpdate;
        private bool _refreshing;
        private int? _tageNachBudgetRotZuGruenMoeglich;
        private bool _verfuegtVisible;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        public CtlWhBudget(int bgBudgetID)
            : this()
        {
            _bgBudgetID = bgBudgetID;

            qryBgBudget.Fill(_bgBudgetID);

            if (qryBgBudget.Count > 0)
            {
                _leistungBaPersonID = (int)qryBgBudget["LeistungBaPersonID"];
                _faLeistungID = (int)qryBgBudget["FaLeistungID"];
                _isMasterbudget = (bool)qryBgBudget["Masterbudget"];

                if (!_isMasterbudget)
                {
                    _budgetJahr = (int)qryBgBudget["Jahr"];
                    _budgetMonat = (int)qryBgBudget["Monat"];
                }
            }

            qryBgDokumentTyp.Fill(_isMasterbudget);

            lblDebitor.Location = lblKreditor.Location;
            edtDebitor.Location = edtKreditor.Location;
            edtValutaTermine.Location = edtValutaDatum.Location;
            edtFaelligAm.Location = edtValutaDatum.Location;

            edtVerwaltungSD.Left = edtReferenzNummer.Left - 2;
            edtVerwaltungSD.Top = edtReferenzNummer.Top + 15;

            lblZahlbarAn.Location = lblMitteilung.Location;

            repositoryItemPictureEdit1.NullText = " ";

            btnPositionGrau.Location = btnPositionGruen.Location;
            btnBudgetGrau.Location = btnBudgetGruen.Location;

            edtReferenzNummer.RightToLeft = RightToLeft.No;

            pnlButtonsStatus.Visible = !_isMasterbudget;

            // Zeige zukünftige Leistungen im Master-Budget
            colDatumVon.Visible = _isMasterbudget;
            colDatumBis.Visible = _isMasterbudget;
            edtOhneZukuenftigeLeistungen.Visible = _isMasterbudget;

            edtBaPersonID.LoadQuery(DBUtil.OpenSQL(@"
                select Code = FPP.BaPersonID, Text = PRS.NameVorname
                from   BgFinanzPlan_BaPerson FPP
                       inner join vwPerson PRS on PRS.BaPersonID = FPP.BaPersoNID
                where  BgFinanzplanID = " + qryBgBudget["BgFinanzplanID"] + @" and
                       IstUnterstuetzt = 1
                order by PRS.NameVorname"));

            qryBgAuszahlungPersonTermin.Fill("select top 0 * from BgAuszahlungPersonTermin");

            if (_isMasterbudget)
            {
                qryBgPosition.CanInsert = false;
            }

            qryBgPosition.Fill(_bgBudgetID);
            SetPositionEditMode();
            SetBudgetEditMode();

            grdBgPosition.Focus();
            SetTexts();
        }

        public CtlWhBudget(Image titleImage, string titleText, int bgBudgetId)
            : this(bgBudgetId)
        {
            picTitel.Image = titleImage;
            lblTitel.Text = titleText;
        }

        public CtlWhBudget()
        {
            InitializeComponent();

            string rawColorString = DBUtil.GetConfigString(@"System\Sozialhilfe\BudgetFarben", "");

            if (rawColorString != string.Empty)
            {
                string[] colorCodes = rawColorString.Split(',');

                for (int i = 0; i < colorCodes.Length; i++)
                {
                    try
                    {
                        switch (i)
                        {
                            case 0:
                                _htBackColor[1] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 1:
                                _htBackColor[2] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 2:
                                _htBackColor[11] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 3:
                                _htBackColor[12] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 4:
                                _htBackColor[21] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 5:
                                _htBackColor[22] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 6:
                                _htBackColor[23] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 7:
                                _htBackColor[81] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 8:
                                _htBackColor[82] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 10:
                                _htBackColor[83] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 11:
                                _htBackColor[84] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 12:
                                _htBackColor[85] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 13:
                                _htBackColor[41] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;

                            case 14:
                                _htBackColor[31] = Color.FromArgb(int.Parse(colorCodes[i]));
                                _htBackColor[61] = Color.FromArgb(int.Parse(colorCodes[i]));
                                break;
                        }
                    }
                    catch { }
                }
            }
            _tageNachBudgetRotZuGruenMoeglich = DBUtil.GetConfigInt(@"System\Sozialhilfe\TageNachBudgetGruenstellbar", -1);

            if (_tageNachBudgetRotZuGruenMoeglich < 0)
            {
                _tageNachBudgetRotZuGruenMoeglich = null;
            }
        }

        #endregion Constructors

        #region Properties

        private decimal MaxBarBetrag
        {
            get
            {
                return (decimal)DBUtil.GetConfigValue(@"System\Sozialhilfe\MaxBarBezugBetrag", 0);
            }
        }

        #endregion Properties

        #region EventHandlers

        private void btnBudgetGrau_Click(object sender, EventArgs e)
        {
            if (!qryBgBudget.CanUpdate)
            {
                KissMsg.ShowInfo("Das Budget darf nicht verändert werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            //pendente Mutationen speichern
            _noRefresh = true;
            bool ok;

            try
            {
                ok = qryBgPosition.Post();
            }
            finally
            {
                _noRefresh = false;
            }

            if (!ok)
            {
                return;
            }

            //prüfen, ob grau stellen immer noch erlaubt
            qryBgPosition.Refresh();

            if (!btnBudgetGrau.Visible)
            {
                return;
            }

            try
            {
                int budgetStatus = (int)qryBgBudget["BgBewilligungStatusCode"];

                if (budgetStatus != 5)
                {
                    return;
                }

                // grünes Budget auf grau stellen
                Session.BeginTransaction();

                // Check: Besteht ein ausgedruckter Barbeleg? Dann dürfen die Belege nicht gelöscht werden
                int count = (int)DBUtil.ExecuteScalarSQL(@"
                  SELECT COUNT(*)
                  FROM dbo.KbBuchung
                  WHERE BgBudgetID = {0} AND BarbelegDatum IS NOT NULL",
                    _bgBudgetID);

                if (count > 0)
                {
                    throw new KissInfoException(
                        "Ein Barbeleg dieses Budget wurde bereits ausgedruckt, deshalb darf dieser Beleg nicht gelöscht werden");
                }

                DBUtil.ExecSQLThrowingException(@"
                    -- NettoBuchungen
                    delete BUK
                    from   KbBuchungKostenart BUK
                           inner join BgPosition POS on POS.BgPositionID = BUK.BgPositionID
                    where  POS.BgBudgetID = {0}

                    delete KbBuchung
                    where  BgBudgetID = {0}",
                    _bgBudgetID);

                DBUtil.ExecSQLThrowingException(@"
                        -- BruttoBuchungen
                        delete BUP
                        from   KbBuchungBruttoPerson BUP
                               inner join BgPosition POS on POS.BgPositionID = BUP.BgPositionID
                        where  POS.BgBudgetID = {0}

                        delete KbBuchungBrutto
                        where  BgBudgetID = {0}",
                    _bgBudgetID);

                // BetragGBLAufAusgabekonto wieder zurücksetzten, damit Saldoberechnung nicht verfälscht wird (siehe #9359)
                DBUtil.ExecSQLThrowingException(@"
                        UPDATE dbo.BgPosition
                        SET BetragGBLAufAusgabekonto = NULL
                        WHERE BgBudgetID = {0}
                          AND BetragGBLAufAusgabekonto IS NOT NULL",
                     _bgBudgetID);

                DBUtil.ExecSQLThrowingException(@"update BgBudget
                        set    BgBewilligungStatusCode = 1
                        where  BgBudgetID = {0}",
                        _bgBudgetID);

                Session.Commit();
            }
            catch (KissCancelException ex)
            {
                Session.Rollback();
                ex.ShowMessage();
                return;
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
                return;
            }

            qryBgBudget.Fill(_bgBudgetID);

            qryBgPosition.Refresh();
        }

        private void btnBudgetGruen_Click(object sender, EventArgs e)
        {
            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
                return;
            }

            //pendente Mutationen speichern
            _noRefresh = true;
            bool ok;
            try
            {
                ok = qryBgPosition.Post();
            }
            finally
            {
                _noRefresh = false;
            }
            if (!ok) return;

            /* alle dürfen grün stellen per 23.06.2008
            // Sozialhilfe: Monatsbudget darf zur Zahlung freigegeben werden
            if (!(bool)DBUtil.GetUserPermission(Permission.Sh_Monatsbudget_Freigeben, (int)qryBgBudget["FaLeistungID"], false))
            {
                KissMsg.ShowInfo("Fehlende Berechtigung, ein Monatsbudget zur Zahlung freizugeben");
                return;
            }
            */

            if (WhUtil.HasNichtbewilligteZusaetzlicheLeistungenMitAutoverrechnung(_bgBudgetID))
            {
                KissMsg.ShowInfo("Das Budget darf noch nicht freigegeben werden. Zuerst müssen alle Positionen mit automatischer Verrechnung bewilligt werden."); // Budgets mit nicht-bewilligten Auto-Verrechnungspositionen dürfen erst grüngestellt werden, wenn alle diese Positionen bewilligt wurden
                return;
            }

            if (!qryBgBudget.CanUpdate)
            {
                KissMsg.ShowInfo("Das Budget darf nicht verändert werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            try
            {
                // graues Budget auf grün stellen
                Session.BeginTransaction();

                int budgetStatus = (int)qryBgBudget["BgBewilligungStatusCode"];
                if (budgetStatus == (int)BgBewilligungStatus.Gesperrt)
                {
                    if (_tageNachBudgetRotZuGruenMoeglich.HasValue)
                    {
                        int? tageSeitBudget = DBUtil.ExecuteScalarSQLThrowingException(@"
                          SELECT MAX(DATEDIFF(d, dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), dbo.fnDateOf(GETDATE())))
                          FROM dbo.KbBuchung                  BUC
                            INNER JOIN dbo.BgBudget           BUD ON BUD.BgBudgetID = BUC.BgBudgetID
                          WHERE BUC.BgBudgetID = {0} AND BUC.KbBuchungStatusCode = 7", _bgBudgetID) as int?;
                        if (tageSeitBudget.HasValue && tageSeitBudget.Value > _tageNachBudgetRotZuGruenMoeglich.Value)
                        {
                            throw new KissErrorException(KissMsg.GetMLMessage("CtlWhBudget", "AltesRotesBudgetNichtGruenstellbar", "Der letzte Tag des Budgetmonats liegt mehr als {0} Tage zurück, deshalb darf dieses Budget nicht mehr freigegeben werden. Falls nötig müssen die Leistungen neu erfasst werden.", _tageNachBudgetRotZuGruenMoeglich.Value));
                        }
                    }

                    // rot -> grün
                    // gesperrte Belege freigeben
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE KbBuchungBrutto
                        SET    KbBuchungStatusCode = 2 /*freigegeben*/
                        WHERE  BgBudgetID = {0} AND KbBuchungTypCode IN (1,2) AND KbBuchungStatusCode = 7 /*gesperrt*/

                        UPDATE KbBuchung
                        SET    KbBuchungStatusCode = 2 /*freigegeben*/
                        WHERE  BgBudgetID = {0} AND KbBuchungTypCode IN (1,2) AND KbBuchungStatusCode = 7 /*gesperrt*/

                        UPDATE BgBudget SET BgBewilligungStatusCode = 5 /* erteilt */ WHERE BgBudgetID = {0}", _bgBudgetID);
                }
                else if (budgetStatus == (int)BgBewilligungStatus.Erteilt)
                {
                    return;
                }
                else if (budgetStatus == (int)BgBewilligungStatus.InVorbereitung)
                {
                    // grau -> grün
                    // Budget auf grün stellen
                    DBUtil.ExecSQLThrowingException("EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0", _bgBudgetID, Session.User.UserID);
                }

                Session.Commit();
            }
            catch (KissCancelException ex)
            {
                Session.Rollback();
                ex.ShowMessage();
                qryBgPosition.Refresh();
                return;
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
                return;
            }

            qryBgPosition.Refresh();
        }

        private void btnBudgetNeu_Click(object sender, EventArgs e)
        {
            if (!DBUtil.UserHasRight("CtlWhBudget", "I"))
            {
                KissMsg.ShowInfo("Es darf kein Budget erstellt werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            if (!OnSaveData())
            {
                return;
            }

            try
            {
                int bgFinanzplanID = (int)qryBgBudget["BgFinanzplanID"];
                object bgBudgetID = DBUtil.ExecuteScalarSQL(@"EXECUTE spWhBudget_Create {0}", bgFinanzplanID);

                if (DBUtil.IsEmpty(bgBudgetID))
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlWhBudget", "EnthaeltAlleBudgets", "Der Finanzplan enthält bereits sämtliche Monatsbudgets", KissMsgCode.MsgInfo));

                // W-Navigator refresh und positionieren auf neuem Budget
                int fallBaPersonID = (int)qryBgBudget["FallBaPersonID"];

                FormController.SendMessage("FrmFall", "Action", "RefreshTree");

                FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                    "BaPersonID", fallBaPersonID,
                    "ModulID", 3,
                    "FieldValue", string.Format("CtlWhFinanzplan{0}\\BBG{1}", bgFinanzplanID, bgBudgetID));
            }
            catch (KissInfoException ex0)
            {
                ex0.ShowMessage();
            }
            catch (Exception ex1)
            {
                KissMsg.ShowInfo(ex1.Message);
            }
        }

        private void btnBudgetReset_Click(object sender, EventArgs e)
        {
            ResetBudget();
        }

        private void btnBudgetRot_Click(object sender, EventArgs e)
        {
            if (!qryBgBudget.CanUpdate)
            {
                KissMsg.ShowInfo("Das Budget darf nicht verändert werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            //pendente Mutationen speichern
            _noRefresh = true;
            bool ok;
            try
            {
                ok = qryBgPosition.Post();
            }
            finally
            {
                _noRefresh = false;
            }

            if (!ok)
            {
                return;
            }

            try
            {
                if (_isMasterbudget)
                {
                    return;
                }

                int bewilligungCode = (int)qryBgBudget["BgBewilligungStatusCode"];

                if (bewilligungCode != 5)
                {
                    return;
                }

                // alle grünen Buchungen auf rot stellen
                DBUtil.ExecSQLThrowingException(@"
                Update BUC
                set    KbBuchungStatusCode = 7
                from   KbBuchung BUC
                       inner join KbBuchungKostenart BUK on BUK.KbBuchungID = BUC.KbBuchungID
                       inner join BgPosition         BPO on BPO.BgPositionID = BUK.BgPositionID and
                                                            BPO.BgKategorieCode in (2,100,101)
                where  BUC.BgBudgetID = {0} and
                       BUC.KbBuchungStatusCode IN (2,5) and
                       BUC.KbBuchungTypCode in (1,2)",
                qryBgBudget["BgBudgetID"]);

                qryBgPosition.Refresh();
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
                return;
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
                return;
            }

            qryBgBudget["BgBewilligungStatusCode"] = BgBewilligungStatus.Gesperrt;
            qryBgBudget.Post();
            qryBgPosition.Refresh();
        }

        private void btnEditMask_Click(object sender, EventArgs e)
        {
            KissMsg.ShowInfo(_editMaskInfo);
        }

        private void btnEinnahme_Click(object sender, EventArgs e)
        {
            NeuePosition(1);
        }

        private void btnEinzelzahlung_Click(object sender, EventArgs e)
        {
            NeuePosition(101);
        }

        private void btnPositionBewilligung_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.CanUpdate)
            {
                KissMsg.ShowInfo("Die Position darf nicht verändert werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
                return;
            }

            _noRefresh = true;
            bool ok;
            try
            {
                ok = qryBgPosition.Post();
            }
            finally
            {
                _noRefresh = false;
            }

            if (!ok)
            {
                return;
            }

            if ((LOV.BgKategorieCode)qryBgPosition["BgKategorieCode"] != LOV.BgKategorieCode.Zusaetzliche_Leistungen)
            {
                return;
            }

            int newBgBewilligungStatus;
            int bgPositionID = (int)qryBgPosition["BgPositionID"];
            int bgPositionIDParent = ShUtil.GetCode(qryBgPosition["BgPositionID_Parent"]);

            if ((BgBewilligungStatus)qryBgPosition["BgBewilligungStatusCode"] == BgBewilligungStatus.Erteilt)
            {
                DlgWhPositionVisieren dlg = new DlgWhPositionVisieren(bgPositionID, BewilligungAktionZH.Aufheben, Name);

                dlg.ShowDialog(this);

                if (dlg.UserCancel)
                {
                    return;
                }

                Session.BeginTransaction();

                try
                {
                    // Schreibe zuerst die Bewilligungs-History (via Bewilligungs-Dialog)
                    dlg.InsertBewilligungsHistory();

                    newBgBewilligungStatus = (int)BgBewilligungStatus.InVorbereitung;

                    //Statusupdate auf BgPosition inkl Detailpositionen
                    DBUtil.ExecSQL(@"
                        update BgPosition
                        set    BgBewilligungStatusCode = {0}
                        where  BgPositionID = {1} or
                               BgPositionID_Parent = {1}",
                          newBgBewilligungStatus,
                          bgPositionIDParent != 0 ? bgPositionIDParent : bgPositionID);

                    WhUtil.DeleteVerrechnungsposition((int)qryBgPosition["BgPositionID"]);

                    Session.Commit();
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    KissMsg.ShowInfo(ex.Message);
                }
            }
            else if (GetUserPermission())
            {
                DlgWhPositionVisieren dlg = new DlgWhPositionVisieren(bgPositionID, Name);

                dlg.ShowDialog(this);
                if (dlg.UserCancel)
                {
                    return;
                }

                Session.BeginTransaction();

                try
                {
                    // Schreibe zuerst die Bewilligungs-History (via Bewilligungs-Dialog)
                    dlg.InsertBewilligungsHistory();

                    newBgBewilligungStatus = (int)dlg.BgBewilligungStatusCode;

                    //Statusupdate auf BgPosition inkl Detailpositionen
                    DBUtil.ExecSQL(@"
                        update BgPosition
                        set    BgBewilligungStatusCode = {0}
                        where  BgPositionID = {1} or
                               BgPositionID_Parent = {1}",
                        newBgBewilligungStatus,
                        bgPositionIDParent != 0 ? bgPositionIDParent : bgPositionID);

                    //bewilligte Position automatisch grün stellen in einem grünen Budget
                    int bgBewilligungStatusCode = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);

                    if (newBgBewilligungStatus == (int)BgBewilligungStatus.Erteilt && bgBewilligungStatusCode >= (int)BgBewilligungStatus.Erteilt)
                    {
                        DBUtil.ExecSQL(@"
                            EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0, null, {2}",
                            _bgBudgetID,
                            Session.User.UserID,
                            bgPositionIDParent != 0 ? bgPositionIDParent : bgPositionID);
                    }

                    // Verrechnungsposition nur bei bewilligter ZL erstellen
                    int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
                    if (kategorie == 100)
                    {
                        WhUtil.InsertOrUpdateVerrechnungsposition(qryBgPosition);
                    }
                    else
                    {
                        WhUtil.DeleteVerrechnungsposition((int)qryBgPosition["BgPositionID"]);
                    }

                    Session.Commit();
                    XLog.Create(TYPEFULLNAME, 1, LogLevel.DEBUG,
                        "Position bewilligt und Buchung erstellt", string.Format("NeuerPositionsBgBewilligungStatusCode {0}, BudgetBewilligungStatusCode {1}, KbBuchungID: {2}",
                            newBgBewilligungStatus,
                            qryBgBudget["BgBewilligungStatusCode"],
                            DBUtil.ExecuteScalarSQL("SELECT TOP 1 KbBuchungID FROM KbBuchungKostenart WHERE BgPositionID = {0}",
                                bgPositionIDParent != 0 ? bgPositionIDParent : bgPositionID)),
                        "BgPosition", bgPositionIDParent != 0 ? bgPositionIDParent : bgPositionID);
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    KissMsg.ShowInfo(ex.Message);
                }
            }
            else
            {
                //Wenn der Benutzer in DlgBewilligungAnfragen 'Anfragen' klickt, erstellt einen Bewilligungs-Record und öffnet dazu bereits eine Transaktion!
                DlgBewilligungAnfragen dlg = new DlgPositionBewilligungAnfragen(bgPositionID, (int)qryBgBudget["BgFinanzPlanID"], _bgBudgetID, Name, true);

                dlg.ShowDialog(this);
                if (dlg.UserCancel)
                {
                    return;
                }

                newBgBewilligungStatus = (int)BgBewilligungStatus.Angefragt;

                try
                {
                    //Statusupdate auf BgPosition inkl Detailpositionen
                    DBUtil.ExecSQL(@"
                    update BgPosition
                    set    BgBewilligungStatusCode = {0}
                    where  BgPositionID = {1} or
                           BgPositionID_Parent = {1}",
                         newBgBewilligungStatus,
                         bgPositionIDParent != 0 ? bgPositionIDParent : bgPositionID);

                    Session.Commit();
                }
                catch (Exception ex)
                {
                    Session.Rollback();
                    KissMsg.ShowInfo(ex.Message);
                }
            }

            qryBgPosition.Refresh();
        }

        private void btnPositionGrau_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.CanUpdate)
            {
                KissMsg.ShowInfo("Die Position darf nicht verändert werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            if (!qryBgPosition.Post())
            {
                return;
            }

            try
            {
                if (_isMasterbudget)
                {
                    return;
                }

                int bewilligungCode = (int)qryBgBudget["BgBewilligungStatusCode"];
                if (bewilligungCode != 5 && bewilligungCode != 9)
                {
                    return;
                }

                int positionStatus = (int)qryBgPosition["Status"];
                if (positionStatus != 2 && positionStatus != 5)
                {
                    return;
                }

                // grüne oder "Zahlauftrag fehlerhaft" Position auf grau stellen
                Session.BeginTransaction();
                DBUtil.ExecSQLThrowingException(@"exec spWhBudget_DeleteKbBuchung {0}", qryBgPosition["BgPositionID"]);

                //Verlauf-Eintrag erstellen
                InsertPositionVerlaufEintrag(12, Utils.ConvertToInt(qryBgPosition["BgPositionID"]));  //9: 12 Freigabe der Zahlung aufgehoben

                Session.Commit();

                XLog.Create(TYPEFULLNAME, 2, LogLevel.DEBUG,
                        "Buchung gelöscht", string.Empty,
                        "BgPosition",
                        ShUtil.GetCode(qryBgPosition["BgPositionID"]));

                qryBgPosition.Refresh();
            }
            catch (KissCancelException ex)
            {
                Session.Rollback();
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
            }
        }

        private void btnPositionGruen_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.CanUpdate)
            {
                KissMsg.ShowInfo("Die Position darf nicht verändert werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
                return;
            }

            if (!qryBgPosition.Post())
            {
                return;
            }

            try
            {
                if (_isMasterbudget)
                {
                    return;
                }

                int bewilligungCode = (int)qryBgBudget["BgBewilligungStatusCode"];
                if (bewilligungCode == 1)
                {
                    return;
                }

                Session.BeginTransaction();

                int positionStatus = (int)qryBgPosition["Status"];

                if (positionStatus == 1 || positionStatus == 14)
                {
                    // graue/bewilligte Position auf grün stellen
                    DBUtil.ExecSQLThrowingException(@"
                        EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0, null, {2}",
                        _bgBudgetID,
                        Session.User.UserID,
                        qryBgPosition["BgPositionID"]);
                }

                if (positionStatus == 7)
                {
                    if (_tageNachBudgetRotZuGruenMoeglich.HasValue)
                    {
                        int? tageSeitBudget = DBUtil.ExecuteScalarSQLThrowingException(@"
                          SELECT MAX(DATEDIFF(d, dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)), dbo.fnDateOf(GETDATE())))
                          FROM dbo.KbBuchung                  BUC
                            INNER JOIN dbo.KbBuchungKostenart KBK ON KBK.KbBuchungID = BUC.KbBuchungID
                            INNER JOIN dbo.BgBudget           BUD ON BUD.BgBudgetID = BUC.BgBudgetID
                          WHERE BgPositionID = {0} AND BUC.KbBuchungStatusCode = 7", qryBgPosition["BgPositionID"]) as int?;
                        if (tageSeitBudget.HasValue && tageSeitBudget.Value > _tageNachBudgetRotZuGruenMoeglich.Value)
                        {
                            throw new KissErrorException(KissMsg.GetMLMessage("CtlWhBudget", "AlteRotePositionNichtGruenstellbar", "Der letzte Tag des Budgetmonats liegt mehr als {0} Tage zurück, deshalb darf diese rote Position nicht mehr freigegeben werden. Falls nötig müssen die Leistungen neu erfasst werden.", _tageNachBudgetRotZuGruenMoeglich));
                        }
                    }

                    // alle roten Belege im Zusammenhang mit dieser Position auf grün stellen
                    DBUtil.ExecSQLThrowingException(@"
                    UPDATE BUC
                    SET    KbBuchungStatusCode = CASE WHEN BarbelegDatum IS NULL THEN 2 ELSE 4 END -- Falls Barbeleg bereits ausgedruckt ist, darf der Status nicht auf 'freigegeben' geändert werden. Sonst könnte der Beleg gelöscht werden
                    FROM dbo.KbBuchungKostenart BKO
                       LEFT JOIN dbo.KbBuchungKostenart BKO2 ON BKO2.KbBuchungID = BKO.KbBuchungID
                                                            AND BKO2.KbBuchungKostenartID <> BKO.KbBuchungKostenartID       --weitere Positionen im rotzustellenen Beleg
                       LEFT JOIN dbo.BgPosition POS_VER ON POS_VER.BgPositionID = BKO2.BgPositionID                         --uns interessiert die Position nur, wenn es eine Verrechnung ist
                                                       AND POS_VER.BgKategorieCode = 3
                       LEFT JOIN dbo.BgPosition POS_PARENT ON POS_PARENT.BgPositionID = POS_VER.BgPositionID_Parent         --hat die Verrechnung-Position eine Parent-Position
                       LEFT JOIN dbo.KbBuchungKostenart bko_parent ON BKO_PARENT.BgPositionID = POS_PARENT.BgPositionID     --Buchung ermitteln der Position, welche zur Auto-Verrechnung geführt hat
                      INNER JOIN dbo.KbBuchung buc ON (BUC.KbBuchungID = BKO.KbBuchungID
                                                       OR BUC.KbBuchungID = BKO_PARENT.KbBuchungID)                         --Update soll bei der Buchung der selektierten Position erfolgen,
                                                  AND BUC.KbBuchungStatusCode = 7                                           --aber auch bei einer Position mit Auto-Verrechnung, wenn wegen des ersten Updates dessen Verrechnung rot geworden ist
                    WHERE BKO.BgPositionID = {0}",
                    qryBgPosition["BgPositionID"]);
                }

                if (positionStatus == 5)
                {
                    // alle Belege mit "Zahlauftrag fehlerhaft" im Zusammenhang mit dieser Position auf grün stellen
                    DBUtil.ExecSQLThrowingException(@"
                    Update BUC
                    set    KbBuchungStatusCode = CASE WHEN BarbelegDatum IS NULL THEN 2 ELSE 4 END -- Falls Barbeleg bereits ausgedruckt ist, darf der Status nicht auf 'freigegeben' geändert werden. Sonst könnte der Beleg gelöscht werden
                    from   KbBuchung BUC
                           inner join KbBuchungKostenart BUK on BUK.KbBuchungID = BUC.KbBuchungID
                    where  BUK.BgPositionID = {0} and
                           BUC.KbBuchungStatusCode = 5",
                    qryBgPosition["BgPositionID"]);
                }

                //Verlauf-Eintrag erstellen
                InsertPositionVerlaufEintrag(11, Utils.ConvertToInt(qryBgPosition["BgPositionID"]));  //11: Position zur Zahlung freigegeben

                Session.Commit();
            }
            catch (KissCancelException ex)
            {
                Session.Rollback();
                ex.ShowMessage();
                return;
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowError(ex.Message);
                return;
            }

            qryBgPosition.Refresh();
        }

        private void btnPositionRot_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.CanUpdate)
            {
                KissMsg.ShowInfo("Die Position darf nicht verändert werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            if (!qryBgPosition.Post())
            {
                return;
            }

            try
            {
                if (_isMasterbudget)
                {
                    return;
                }

                int bewilligungCode = (int)qryBgBudget["BgBewilligungStatusCode"];
                if (bewilligungCode != 5 && bewilligungCode != 9)
                {
                    return;
                }

                int positionStatus = (int)qryBgPosition["Status"];

                int positionStatusMin = 0;
                if (!_isMasterbudget && !DBUtil.IsEmpty(qryBgPosition["StatusMin"]))
                {
                    positionStatusMin = (int)qryBgPosition["StatusMin"];
                }

                if (positionStatus == 2 || positionStatusMin == 2)
                {
                    // grüne Position auf rot stellen
                    DBUtil.ExecSQLThrowingException(@"
                    UPDATE BUC
                    SET    KbBuchungStatusCode = 7
                    FROM dbo.KbBuchungKostenart BKO
                       LEFT JOIN dbo.KbBuchungKostenart BKO2 ON BKO2.KbBuchungID = BKO.KbBuchungID
                                                            AND BKO2.KbBuchungKostenartID <> BKO.KbBuchungKostenartID       --weitere Positionen im rotzustellenen Beleg
                       LEFT JOIN dbo.BgPosition POS_VER ON POS_VER.BgPositionID = BKO2.BgPositionID                         --uns interessiert die Position nur, wenn es eine Verrechnung ist
                                                       AND POS_VER.BgKategorieCode = 3
                       LEFT JOIN dbo.BgPosition POS_PARENT ON POS_PARENT.BgPositionID = POS_VER.BgPositionID_Parent         --hat die Verrechnung-Position eine Parent-Position
                       LEFT JOIN dbo.KbBuchungKostenart bko_parent ON BKO_PARENT.BgPositionID = POS_PARENT.BgPositionID     --Buchung ermitteln der Position, welche zur Auto-Verrechnung geführt hat
                      INNER JOIN dbo.KbBuchung buc ON (BUC.KbBuchungID = BKO.KbBuchungID
                                                       OR BUC.KbBuchungID = BKO_PARENT.KbBuchungID)                         --Update soll bei der Buchung der selektierten Position erfolgen,
                                                  AND BUC.KbBuchungStatusCode = 2                                           --aber auch bei einer Position mit Auto-Verrechnung, wenn wegen des ersten Updates dessen Verrechnung rot geworden ist
                    WHERE BKO.BgPositionID = {0}",
                    qryBgPosition["BgPositionID"]);

                    // Eintrag in BgGewilligung "Position rot gestellt"
                    InsertPositionVerlaufEintrag(13, (int)qryBgPosition["BgPositionID"]);

                    qryBgPosition.Refresh();
                }
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }
        }

        private void btnSpezialkonto_Click(object sender, EventArgs e)
        {
        }

        private void btnWeitereZahlinfos_Click(object sender, EventArgs e)
        {
            bool proPerson = (bool)qryBgPosition["ProPerson"];
            bool proUe = (bool)qryBgPosition["ProUE"];
            int ueCount = (int)qryBgBudget["UECount"];

            if ((proPerson && !proUe) || ueCount <= 1)
            {
                KissMsg.ShowInfo("Dieser Dialog kann nur geöffnet werden bei einer gequoteten Position und einem Mehrpersonenhaushalt");
                return;
            }

            int posStatus = ShUtil.GetCode(qryBgPosition["Status"]);
            bool editable = posStatus == 1 || posStatus == 12 || posStatus == 14 || posStatus == 15;

            DlgWhWeitereZahlinfo dlg = new DlgWhWeitereZahlinfo((int)qryBgPosition["BgPositionID"], !editable);

            Session.BeginTransaction();
            try
            {
                if (dlg.ShowDialog(this) == DialogResult.OK)
                {
                    Session.Commit();
                    qryBgPosition.Refresh();
                }
                else
                {
                    Session.Rollback();
                }
            }
            catch
            {
                Session.Rollback();
            }
        }

        private void btnZusatzleistung_Click(object sender, EventArgs e)
        {
            NeuePosition(100);
        }

        private void CtlWhBudget_Load(object sender, EventArgs e)
        {
            try
            {
                DBUtil.ThrowExceptionOnOpenTransaction();
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(ex.Message);
            }

            qryBgPosition.PostCompleted += qryBgPosition_PostCompleted;
            edtCalendar.DateChanged += edtCalendar_DateChanged;
            timer1.Tick += timer1_Tick;

            edtBetragBudget.EnterKey += edtBetragBudget_EnterKey;
            edtBgAuszahlungsTerminCode.EnterKey += edtKgAuszahlungsTerminCode_EnterKey;

            colDocTyp.ColumnEdit = grdDoc.GetLOVLookUpEdit("BgDokumentTyp");
            colBgBewilligungCode.ColumnEdit = grdBewilligung.GetLOVLookUpEdit("BgBewilligung");
            colBeleg_Auszahlungsart.ColumnEdit = grdDoc.GetLOVLookUpEdit("KbAuszahlungsArt");

            if (_isMasterbudget)
            {
                colBezeichnung.Width += colStatus.Width + colStatusMin.Width;
                colInfo.Width += colAnzahlBelege.Width + colMaster.Width;
                colStatus.Visible = false;
                colAnzahlBelege.Visible = false;
                colStatusMin.Visible = false;
                colMaster.Visible = false;
                colDetailPos.Visible = false;
                colEffektiv.Visible = false;
            }
            else
            {
                //Buchungsstati laden
                repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
                SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KbBuchungsStatus' order by SortKey");

                foreach (DataRow row in qryStati.DataTable.Rows)
                {
                    repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                        row["Text"].ToString(),
                        (int)row["Code"],
                        KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
                }

                colStatusMin.ColumnEdit = colStatus.ColumnEdit;
                colBeleg_BelegStatus.ColumnEdit = colStatus.ColumnEdit;
                colBelegBrutto_BelegStatus.ColumnEdit = colStatus.ColumnEdit;
                colBeleg_GedrucktStatus.ColumnEdit = colStatus.ColumnEdit;
            }

            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnEinzelzahlung, "neue Einzelzahlung");
            toolTip1.SetToolTip(btnZusatzleistung, "neue zusätzliche Leistung");
            toolTip1.SetToolTip(btnEinnahme, "Einnahme");

            toolTip1.SetToolTip(btnBudgetGrau, "Monatsbudget auf grau (in Vorbereitung) stellen");
            toolTip1.SetToolTip(btnBudgetGruen, "Monatsbudget auf grün (freigegeben) stellen");
            toolTip1.SetToolTip(btnBudgetRot, "Monatsbudget auf rot (gesperrt) stellen");
            toolTip1.SetToolTip(btnBudgetReset, "Monatsbudget zurückstellen (aufgrund des aktuellen Masterbudgets)");
            toolTip1.SetToolTip(btnBudgetNeu, "Neues Monatsbudget erzeugen");
            toolTip1.SetToolTip(btnBudgetVerlauf, "Bewilligungsverlauf des Masterbudgets");

            toolTip1.SetToolTip(btnPositionGrau, "Budgetposition auf grau (in Vorbereitung) stellen");
            toolTip1.SetToolTip(btnPositionGruen, "Budgetposition auf grün (freigegeben) stellen");
            toolTip1.SetToolTip(btnPositionRot, "Budgetposition auf rot (gesperrt) stellen");
            toolTip1.SetToolTip(btnPositionVerlauf, "Bewilligungsverlauf der Budgetposition");
            toolTip1.SetToolTip(btnPositionBewilligung, "Bewilligung der Budgetposition");

            tabBgPosition.SelectedTabIndex = 0;
            tabZahlinfo.SelectedTabIndex = 0;

            bool bruttoRight = DBUtil.UserHasRight("CtlBgBudget_AnzeigeBruttoBelegStatus");
            colBelegBrutto_BelegStatus.Visible = bruttoRight;
            colBelegBrutto_BetragEffektiv.Visible = bruttoRight;

            SetRowFilter();
        }

        private void docBudgetblatt_DocumentCreated(object sender, EventArgs e)
        {
            qryBgBudgetblatt["DateCreation"] = docBudgetblatt.DateCreation;
            qryBgBudgetblatt["DateLastSave"] = docBudgetblatt.DateLastSave;
        }

        private void docBudgetblatt_DocumentCreating(object sender, CancelEventArgs e)
        {
            try
            {
                if (qryBgBudgetblatt.Count > 0)
                {
                    if ((bool)qryBgBudgetblatt["Begleitbrief"])
                    {
                        docBudgetblatt.Context = "WhBudgetblattMitBegleitbrief";
                    }
                    else
                    {
                        docBudgetblatt.Context = "WhBudgetblatt";
                    }
                }
            }
            catch (Exception err)
            {
                // Der cast auf bool sollte nie fehlschlagen, aber zur Sicherheit die folgende Zeile
                KissMsg.ShowError(err.ToString());
            }
        }

        private void docBudgetblatt_DocumentDeleted(object sender, EventArgs e)
        {
            qryBgBudgetblatt["DateCreation"] = docBudgetblatt.DateCreation;
            qryBgBudgetblatt["DateLastSave"] = docBudgetblatt.DateLastSave;
        }

        private void docBudgetblatt_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            qryBgBudgetblatt.Post();
            qryBgBudgetblatt.Refresh();
            SetBudgetblattEditMode();
        }

        private void edtAdressat_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = null;

            if (edtAdressat.EditValue != null)
            {
                searchString = edtAdressat.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");
            }

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgBudgetblatt["AdressatID"] = DBNull.Value;
                    qryBgBudgetblatt.Refresh();
                    return;
                }
            }

            string sql;

            if (searchString == ".")
            {
                // Wenn nur ein Punkt eingegeben wurde,
                // dann soll nur in den FallPersonen und involvierten Institutionen gesucht werden:
                sql = @"
                DECLARE @faFallID int
                SELECT @faFallID = FaFallID FROM Faleistung WHERE FaLeistungID = {1}

                select ID$ = PRS.BaPersonID, Typ = 'Person', Name = PRS.VornameName, Strasse = PRS.WohnsitzStrasseHausNr, Ort = PRS.WohnsitzPLZOrt
                from dbo.FaFallPerson FPR
                  inner join dbo.vwPerson PRS on PRS.BaPersonID = FPR.BaPersonID
                where FPR.FaFallID = @faFallID

                UNION
                select ID$ = INS.BaInstitutionID, 'Institution', Name = INS.Name + IsNull(' (' + INS.AdressZusatz + ')',''), Strasse = INS.StrasseHausNr, Ort = INS.PLZOrt
                from dbo.FaInvolvierteInstitution INV
                  inner join dbo.vwInstitution INS on INS.BaInstitutionID = INV.BaInstitutionID
                where INV.FaFallID = @faFallID

                ORDER BY Name";
            }
            else
            {
                sql = @"
                SELECT ID$ = PRS.BaPersonID, Typ = 'Person', Name = PRS.VornameName, Strasse = PRS.WohnsitzStrasseHausNr, Ort = PRS.WohnsitzPLZOrt
                FROM dbo.vwPerson PRS
                WHERE PRS.NameVorname LIKE '%' + {0} + '%'

                UNION
                SELECT ID$ = INS.BaInstitutionID, 'Institution', Name = INS.Name + IsNull(' (' + INS.AdressZusatz + ')',''), Strasse = INS.StrasseHausNr, Ort = INS.PLZOrt
                FROM dbo.vwInstitution INS
                WHERE INS.Name LIKE '%' + {0} + '%' OR INS.AdressZusatz LIKE '%' + {0} + '%'

                ORDER BY Name";
            }
            // Dialog öfnen:
            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, _faLeistungID, null);

            if (!e.Cancel)
            {
                qryBgBudgetblatt["AdressatID"] = dlg[0];
                qryBgBudgetblatt.Refresh();
            }
        }

        private void edtBaPersonID_EditValueChanged(object sender, EventArgs e)
        {
            LoadSpezialkonto(qryBgPosition["BgKostenartID"], edtBaPersonID.EditValue);
        }

        private void edtBegleitbrief_EditValueChanged(object sender, EventArgs e)
        {
            if (qryBgBudgetblatt.IsInserting)
            {
                return;
            }

            qryBgBudgetblatt["Begleitbrief"] = edtBegleitbrief.EditValue;
            if (qryBgBudgetblatt.Position >= 0 && DBUtil.IsEmpty(qryBgBudgetblatt["DocumentID"]))
            {
                if (edtBegleitbrief.EditValue as bool? == true)
                {
                    edtAdressat.EditMode = EditModeType.Normal;
                }
                else
                {
                    qryBgBudgetblatt["Adressat"] = null;
                    qryBgBudgetblatt["AdressatID"] = null;
                    edtAdressat.EditMode = EditModeType.ReadOnly;
                }
            }
        }

        private void edtBetragBudget_EnterKey(object sender, KeyEventArgs e)
        {
            SendKeys.SendWait("{TAB}");
            /*
            TODO
            if (edtKgAuszahlungsArtCode.EditMode == EditModeType.Normal)
            {
                edtKgAuszahlungsArtCode.Focus();
            }
            else if (edtKgAuszahlungsTerminCode.EditMode == EditModeType.Normal)
            {
                edtKgAuszahlungsTerminCode.Focus();
            }
            else if (edtValutaDatum.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtValutaDatum.Focus();
            }
            else if (edtKreditor.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtKreditor.Focus();
            }
            else if (edtDebitor.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtKreditor.Focus();
            }
            else
            {
                SendKeys.SendWait("{TAB}");
            }
            */
        }

        private void edtBgAuszahlungsTerminCode_EditValueChanged(object sender, EventArgs e)
        {
            if (qryBgPosition.IsFilling)
            {
                return;
            }

            if (!edtBgAuszahlungsTerminCode.Focused)
            {
                return;
            }

            qryBgPosition["BgAuszahlungsTerminCode"] = edtBgAuszahlungsTerminCode.EditValue;
            int bgAuszahlungsTerminCode = (int)qryBgPosition["BgAuszahlungsTerminCode"];

            switch (bgAuszahlungsTerminCode)
            {
                case 6:  // Wochentage
                    qryBgPosition["BgWochentagCodes"] = DBNull.Value;
                    break;

                case 99: //individuell
                    qryBgAuszahlungPersonTermin.DataTable.Rows.Clear();
                    break;
            }

            LoadValutaTermine();
            DisplayValutaTermine();
            //KissMsg.ShowInfo("d: " + qryKgPositionValuta.Count.ToString());
            DisplayCalendarBoldDates();

            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            if (kategorie == 100 || kategorie == 2)
            {
                qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                qryBgPosition["Status"] = 1; //grau
                qryBgPosition.RefreshDisplay();
            }

            SetPositionEditMode();

            switch (bgAuszahlungsTerminCode)
            {
                case 1:  // 1x pro Monat
                case 2:  // 2x pro Monat
                case 3:  // wöchentlich
                case 5:  // 14-täglich
                    break;

                case 4:  // Valuta
                    tabZahlinfo.SelectTab(tpgZahlinfo);
                    break;

                case 6:  // Wochentage
                case 99: //Individuell
                    tabZahlinfo.SelectTab(tpgKalender);
                    break;
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
            if (DBUtil.IsEmpty(edtBgSpezkontoID.EditValue))
            {
                qryBgPosition["Status"] = 1; //grau
            }

            SetSpezialkonto();
            SetPositionEditMode();
        }

        private void edtCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (_calendarFilling)
            {
                return;
            }

            if (Array.IndexOf(edtCalendar.BoldedDates, e.Start) >= 0)
            {
                edtCalendar.RemoveBoldedDate(e.Start);
            }
            else
            {
                edtCalendar.AddBoldedDate(e.Start);
            }

            SaveCalendarBoldDates();
            DisplayValutaTermine();
            timer1.Enabled = true;
        }

        private void edtDebitor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = AuswahlDebitorFamoz(edtDebitor.EditValue.ToString(), e.ButtonClicked);
        }

        private void edtDocument_DocumentCreated(object sender, EventArgs e)
        {
            // damit DateCreation und DateLastSave im Gitter korrekt angezeigt werden
            qryBgDokumente["DateCreation"] = edtDocument.DateCreation;
            qryBgDokumente["DateLastSave"] = edtDocument.DateLastSave;
        }

        private void edtDocument_DocumentImported(object sender, EventArgs e)
        {
            // damit DateCreation und DateLastSave im Gitter korrekt angezeigt werden
            qryBgDokumente["DateCreation"] = edtDocument.DateCreation;
            qryBgDokumente["DateLastSave"] = edtDocument.DateLastSave;
        }

        private void edtDocument_DocumentSaved(object sender, EventArgs e)
        {
            qryBgDokumente.Refresh();
        }

        private void edtKbAuszahlungsArtCode_EditValueChanged(object sender, EventArgs e)
        {
            if (qryBgPosition.IsFilling)
            {
                return;
            }

            if (!edtKbAuszahlungsArtCode.Focused)
            {
                return;
            }

            qryBgPosition["KbAuszahlungsArtCode"] = edtKbAuszahlungsArtCode.EditValue;

            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            if (kategorie == 100 || kategorie == 2)
            {
                qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                qryBgPosition["Status"] = 1; //grau
            }

            SetPositionEditMode();

            SqlQuery qry = DBUtil.OpenSQL(@"
                select FallNrNameVorname = 'F' + convert(varchar,{1}) + ' ' + NameVorname,
                       VornameName,
                       WohnsitzStrasseHausNr,
                       WohnsitzPLZOrt
                from   vwPerson
                where  BaPersonID = {0}",
                qryBgBudget["LeistungBaPersonID"],
                qryBgBudget["FaFallID"]);

            int auszahlungsArt = (int)qryBgPosition["KbAuszahlungsArtCode"];
            switch (auszahlungsArt)
            {
                case 101:
                    qryBgPosition["MitteilungZeile1"] = TruncateString(qry["FallNrNameVorname"], 35);
                    qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                    qryBgPosition["MitteilungZeile3"] = DBNull.Value;

                    tabZahlinfo.SelectTab(tpgZahlinfo);
                    break;

                case 103:
                    qryBgPosition["MitteilungZeile1"] = TruncateString(qry["VornameName"], 35);
                    qryBgPosition["MitteilungZeile2"] = TruncateString(qry["WohnsitzStrasseHausNr"], 35);
                    qryBgPosition["MitteilungZeile3"] = TruncateString(qry["WohnsitzPLZOrt"], 35);

                    qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryBgPosition["Kreditor"] = DBNull.Value;
                    qryBgPosition["ZusatzInfo"] = DBNull.Value;
                    qryBgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                    qryBgPosition["ReferenzNummer"] = DBNull.Value;

                    tabZahlinfo.SelectTab(tpgMitteilung);
                    break;
            }
            qryBgPosition.RefreshDisplay();
        }

        private void edtKgAuszahlungsTerminCode_EnterKey(object sender, KeyEventArgs e)
        {
            /*
            TODO
            if (edtValutaDatum.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtValutaDatum.Focus();
            }
            else if (edtKreditor.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtKreditor.Focus();
            }
            else if (edtDebitor.EditMode == EditModeType.Normal)
            {
                tabZahlinfo.SelectTab(tpgZahlinfo);
                edtKreditor.Focus();
            }
            else
            {
                SendKeys.SendWait("{TAB}");
            }
            */
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
                    qryBgPosition["BgKostenArtID"] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    return;
                }
            }

            if (_editMask.GruppeFilter && e.ButtonClicked)
            {
                searchString = "%";
            }

            string oldBgPositionsArtID = qryBgPosition["BgPositionsArtID"].ToString();

            KissLookupDialog dlg = new KissLookupDialog();
            string sql = @"
                select LA                  = BKA.KontoNr,
                       Positionsart        = BPA.Name,
                       Gruppe              = GRP.Text,
                       BgKostenartID$      = BKA.BgKostenartID,
                       BgPositionsartID$   = BPA.BgPositionsartID,
                       ProPerson$          = BPA.ProPerson,
                       ProUE$              = BPA.ProUE,
                       KOAPositinsart$     = BKA.KontoNr + ' '+ BPA.Name,
                       Name$               = BPA.Name,
                       BgSplittingArtCode$ = BKA.BgSplittingArtCode,
                       sqlRichtlinie$      = BPA.sqlRichtlinie,
                       GruppeFilter$       = convert(varchar(50),GRP.Value3),
                       BaZahlungswegIDFix$ = BKA.BaZahlungswegIDFix,
                       SpezHauptvorgang$   = BPA.SpezHauptvorgang,
                       SpezTeilvorgang$    = BPA.SpezTeilvorgang
                from   WhPositionsart BPA
                       inner join BgKostenart BKA on BKA.BgKostenartID = BPA.BgKostenartID
                       left  join XLOVCode    GRP on GRP.LOVName = 'BgGruppe' AND GRP.Code = BPA.BgGruppeCode
                       left join  XLOVCode    CIN ON CIN.LOVName = 'BgKategorie' AND CIN.Code >= 10000 AND CIN.Code = BPA.BgKategorieCode
                where  BgKategorieCode = " + qryBgPosition["BgKategorieCode"]
              + @"and (    BPA.Name like '%' + {0} + '%'
                        or BKA.KontoNr like {0} + '%')
                  and   BKA.KontoNr not in (860, 861, 862) -- Ertrags-SiLei dürfen im Budget nicht ausgewählt werden (siehe auch #90)
                  and  (        BPA.SpezHauptvorgang IS NULL
                            AND BPA.SpezTeilvorgang IS NULL
                            OR 1 = {1})
                  and   CIN.Code IS NULL -- inaktiven BgKategorien zeigen wir nicht an";

            if (_editMask.GruppeFilter)
            {
                sql += " and convert(varchar(50),GRP.Value3) = '" + qryBgPosition["GruppeFilter"] + "' ";
            }
            else if (!_editMask.Gruppe)
            {
                sql += " AND BPA.BgGruppeCode = " + DBUtil.SqlLiteral(qryBgPosition["BgGruppeCode"]);
            }

            sql += " order by 1,2";

            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, DBUtil.UserHasRight("CtlWhBudget_MultifunktionalesVorzeichen"), null, null);

            if (!e.Cancel)
            {
                int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

                try
                {
                    WhUtil.CheckIfInsertVerrechnungspositionIsAllowed(kategorie, (int)qryBgBudget["BgBewilligungStatusCode"], (int)dlg["BgPositionsartID$"]);
                }
                catch (KissInfoException ex)
                {
                    qryBgPosition["BgPositionsArtID"] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    KissMsg.ShowInfo(ex.Message);
                    e.Cancel = true;
                    return;
                }

                qryBgPosition["BgPositionsArtID"] = dlg["BgPositionsartID$"];
                qryBgPosition["BgKostenArtID"] = dlg["BgKostenartID$"];
                qryBgPosition["Kostenart"] = dlg["KOAPositinsart$"];
                qryBgPosition["Buchungstext"] = dlg["Name$"];
                qryBgPosition["BgSplittingArtCode"] = dlg["BgSplittingArtCode$"];
                qryBgPosition["ProPerson"] = dlg["ProPerson$"];
                qryBgPosition["ProUE"] = dlg["ProUE$"];
                qryBgPosition["GruppeFilter"] = dlg["GruppeFilter$"];
                qryBgPosition["BaZahlungswegIDFix"] = dlg["BaZahlungswegIDFix$"];

                bool proPerson = (bool)qryBgPosition["ProPerson"];
                bool proUe = (bool)qryBgPosition["ProUE"];

                if (proUe && !proPerson)
                {
                    qryBgPosition["BaPersonID"] = null;
                }

                SetVerwendungsPeriode();

                SqlQuery qry = ShUtil.GetRichtlinie(dlg["sqlRichtlinie$"], _bgBudgetID);
                if (qry.Count == 1)
                {
                    if (DBUtil.IsEmpty(qryBgPosition["BaPersonID"]))
                    {
                        qryBgPosition["BetragBudget"] = DBUtil.IsEmpty(qry["UE_DEF"]) ? qry["UE_MIN"] : qry["UE_DEF"];
                    }
                    else
                    {
                        qryBgPosition["BetragBudget"] = DBUtil.IsEmpty(qry["PR_DEF"]) ? qry["PR_MIN"] : qry["PR_DEF"];
                    }
                }

                if (kategorie == 2 || kategorie == 100)  //Ausgabe, Zusätzliche Leistung
                {
                    if (oldBgPositionsArtID != qryBgPosition["BgPositionsArtID"].ToString())
                    {
                        qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                    }

                    LoadSpezialkonto(dlg["BgKostenartID$"], qryBgPosition["BaPersonID"]);
                }

                bool hvTvAufPositionsart = dlg["SpezHauptvorgang$"] != DBNull.Value || dlg["SpezTeilvorgang$"] != DBNull.Value;
                qryBgPosition["HVTVAufPositionsart"] = hvTvAufPositionsart;
                // Einnahmen auf "Ausgaben-LAs" müssen abgetreten sein
                if (hvTvAufPositionsart && kategorie == 1)
                {
                    qryBgPosition["VerwaltungSD"] = true;
                }

                if (!DBUtil.IsEmpty(qryBgPosition["BaZahlungswegIDFix"])) //Auszahlung an fixe Zahladresse
                {
                    SqlQuery qryKreditor = DBUtil.OpenSQL("SELECT * FROM vwKreditor WHERE BaZahlungswegID = {0}", qryBgPosition["BaZahlungswegIDFix"]);
                    if (qryKreditor.Count == 1)
                    {
                        qryBgPosition["Kreditor"] = qryKreditor["Kreditor"];
                        qryBgPosition["ZusatzInfo"] = qryKreditor["ZusatzInfo"];
                        qryBgPosition["BaZahlungswegID"] = qryKreditor["BaZahlungswegID"];
                        qryBgPosition["EinzahlungsscheinCode"] = qryKreditor["EinzahlungsscheinCode"];

                        if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                        {
                            qryBgPosition["ReferenzNummer"] = DBNull.Value;
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

                SetPositionEditMode();
            }
        }

        private void edtKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = AuswahlKreditorFamoz(edtKreditor.EditValue.ToString(), e.ButtonClicked);
        }

        private void edtOhneGruppen_EditValueChanged(object sender, EventArgs e)
        {
            SetRowFilter();

            // Speichere das Layout, was wiederum die Methode OnGettingLayout() triggert, was dann den Checkbox-Status speichert
            SaveLayout();
        }

        private void edtOhneZukuenftigeLeistungen_EditValueChanged(object sender, EventArgs e)
        {
            SetRowFilter();

            // Speichere das Layout, was wiederum die Methode OnGettingLayout() triggert, was dann den Checkbox-Status speichert
            SaveLayout();
        }

        private void edtWochentagCodes_EditValueChanged(object sender, EventArgs e)
        {
            if (edtWochentagCodes.EditMode == EditModeType.Normal)
            {
                qryBgPosition["BgWochentagCodes"] = edtWochentagCodes.EditValue;
                LoadValutaTermine();
                DisplayValutaTermine();
                DisplayCalendarBoldDates();
            }
        }

        private void grvBgPosition_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column == null)
            {
                return;
            }

            // no custom customization for selected rows
            if (grvBgPosition.GetSelectedRows() != null && grvBgPosition.GetSelectedRows()[0] == e.RowHandle)
            {
                return;
            }

            try
            {
                object styleNr = grvBgPosition.GetRowCellValue(e.RowHandle, colStyle);

                if (styleNr is int && _htBackColor.ContainsKey((int)styleNr))
                {
                    e.Appearance.BackColor = (Color)_htBackColor[(int)styleNr];
                }
            }
            catch { }
        }

        private void qryBgBudget_AfterFill(object sender, EventArgs e)
        {
            SetBudgetEditMode();
            // Update the tree-information
            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void qryBgBudgetblatt_AfterInsert(object sender, EventArgs e)
        {
            qryBgBudgetblatt["Begleitbrief"] = 1;
            qryBgBudgetblatt["BgBudgetID"] = _bgBudgetID;
            SqlQuery qryBaPersonID = DBUtil.OpenSQL("SELECT PRS.BaPersonID, PRS.NameVorname FROM BgBudget BBG " +
                "LEFT JOIN BgFinanzplan BFP ON BFP.BgFinanzplanID = BBG.BgFinanzplanID " +
                "LEFT JOIN FaLeistung BFL ON BFL.FaLeistungID = BFP.FaLeistungID " +
                "LEFT JOIN vwPerson PRS ON PRS.BaPersonID = BFL.BaPersonID " +
                "WHERE BgBudgetID = {0}", _bgBudgetID);
            qryBgBudgetblatt["Adressat"] = qryBaPersonID["NameVorname"];
            qryBgBudgetblatt["AdressatID"] = qryBaPersonID["BaPersonID"];
            //edtAdressat.EditValue = qryBaPersonID["NameVorname"];
            qryBgBudgetblatt.RowModified = true;
        }

        private void qryBgBudgetblatt_BeforePost(object sender, EventArgs e)
        {
            if (!qryBgBudgetblatt.IsSilentPostingFromXDocument && DBUtil.IsEmpty(qryBgBudgetblatt["DocumentID"]))
            {
                KissMsg.ShowInfo("Erfassen sie zuerst ein Dokument.");
                throw new KissCancelException();
            }
        }

        private void qryBgBudgetblatt_PositionChanged(object sender, EventArgs e)
        {
            SetBudgetblattEditMode();
        }

        private void qryBgDokumente_AfterDelete(object sender, EventArgs e)
        {
            var documentID = qryBgDokumente["DocumentID"] as int?;
            if (documentID.HasValue)
            {
                DBUtil.ExecSQL("DELETE FROM XDocument WHERE DocumentID = {0}", documentID.Value);
            }
        }

        private void qryBgDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryBgDokumente["BgDokumentTypCode"] = _isMasterbudget ? 4 : 1;
            qryBgDokumente["Stichwort"] = qryBgPosition["Kostenart"];

            edtDokumentTyp.Focus();
        }

        private void qryBgDokumente_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            //Regel :
            // - Dokumenten vom Typ (=4) Masterbudgetpostion darf man nur auf Masterbudget ändern
            // - Dokumenten vom Typ (=3) Finanzplan darf man nicht mehr ändern
            if (BgDokumentTypIsNotMutierbarLoeschbar((int)qryBgDokumente["BgDokumentTypCode"]))
            {
                throw new KissInfoException("Dieses Dokument darf nicht gelöscht werden!");
            }
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
                    qryBgDokumente["BgBudgetID"] = qryBgBudget["BgBudgetID"];
                    break;

                case 3:
                    qryBgDokumente["BgFinanzplanID"] = qryBgBudget["BgFinanzPlanID"];
                    break;

                case 4:
                    qryBgDokumente["BgPositionID"] = qryBgPosition["BgPositionID"];
                    break;
            }

            if (DBUtil.IsEmpty(qryBgDokumente["Stichwort"]))
            {
                qryBgDokumente["Stichwort"] = "-";
            }
        }

        private void qryBgDokumente_PositionChanged(object sender, EventArgs e)
        {
            //Regel :
            // - Dokumenten vom Typ (=4) Masterbudgetpostion darf man nur auf Masterbudget ändern
            // - Dokumenten vom Typ (=3) Finanzplan darf man nicht mehr ändern
            if (qryBgDokumente["BgDokumentTypCode"] == null || BgDokumentTypIsNotMutierbarLoeschbar((int)qryBgDokumente["BgDokumentTypCode"]))
            {
                edtDokumentTyp.EditMode = EditModeType.ReadOnly;
                edtStichwort.EditMode = EditModeType.ReadOnly;
                edtDocument.EditMode = EditModeType.ReadOnly;
            }
            else
            {
                edtDokumentTyp.EditMode = EditModeType.Normal;
                edtStichwort.EditMode = EditModeType.Normal;
                edtDocument.EditMode = EditModeType.Normal;
            }
        }

        private void qryBgDokumente_PostCompleted(object sender, EventArgs e)
        {
            gridView1.RefreshData();
        }

        private void qryBgPosition_AfterDelete(object sender, EventArgs e)
        {
            if (Session.Transaction != null)
            {
                Session.Commit();
            }

            qryBgPosition.Refresh();
        }

        private void qryBgPosition_AfterFill(object sender, EventArgs e)
        {
            qryBgBudget.Refresh();
        }

        private void qryBgPosition_AfterInsert(object sender, EventArgs e)
        {
            qryBgPosition["Kategorie"] = 0;
            qryBgPosition["Gruppe"] = 0;
            qryBgPosition["BgKategorieCode"] = _newBgKategorieCode;
            qryBgPosition["BgBudgetID"] = _bgBudgetID;
            qryBgPosition["Doc"] = false;
            qryBgPosition["Status"] = 1; //grau
            qryBgPosition["BgBewilligungStatusCode"] = BgBewilligungStatus.InVorbereitung; //grau
            qryBgPosition["Quoting"] = false;
            qryBgPosition["Style"] = _newBgKategorieCode * 10 + 1;
            qryBgPosition["ProPerson"] = false;
            qryBgPosition["ProUE"] = true;
            qryBgPosition["VerwaltungSD"] = false;

            int budgetStatus = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);

            switch (_newBgKategorieCode)
            {
                case 100: //Zusatzleistung
                    qryBgPosition["KbAuszahlungsArtCode"] = 101; //elektronisch
                    qryBgPosition["BgAuszahlungsTerminCode"] = 1; //1xmonatlich
                    LoadSpezialkonto(-1, null); //keine Auswahl, solange keine KOA ausgewählt ist
                    LoadValutaTermine();
                    DisplayCalendarBoldDates();
                    break;

                case 101: //Einzelzahlung
                    qryBgPosition["KbAuszahlungsArtCode"] = 101; //elektronisch
                    qryBgPosition["BgAuszahlungsTerminCode"] = 4; //Valuta
                    LoadSpezialkonto(null, null);
                    if (budgetStatus == 1) //graues Budget
                    {
                        qryBgPosition["Kostenart"] = GetFieldFromSpezkonto(null, "KOAPositionsart"); //Grundbedarf
                        qryBgPosition["BgSplittingArtCode"] = GetFieldFromSpezkonto(null, "BgSplittingArtCode"); //Splitting des Grundbedarfs
                        SetVerwendungsPeriode();
                    }

                    //TODO qryBgPosition["MitteilungZeile1"] = TruncateString(qry2["VornameName"],35);
                    break;

                case 1: //Einnahmen

                    qryBgPosition["BgAuszahlungsTerminCode"] = 4; //Valuta

                    if ((budgetStatus == 5) && !_isMasterbudget)
                    {
                        qryBgPosition["VerwaltungSD"] = true;  //nur noch abgetretene Einnahmen im grünen Monatsbudget
                    }

                    break;

                case 4: // Sanktion (ZH) / Kürzung (BSS)

                    LoadSpezialkonto(null, null);
                    if (budgetStatus == 1) //graues Budget
                    {
                        qryBgPosition["Kostenart"] = GetFieldFromSpezkonto(null, "KOAPositionsart"); //Grundbedarf
                        qryBgPosition["BgSplittingArtCode"] = GetFieldFromSpezkonto(null, "BgSplittingArtCode"); //Splitting des Grundbedarfs
                        SetVerwendungsPeriode();
                    }

                    break;
            }

            _newBgKategorieCode = 0;
            tabBgPosition.SelectedTabIndex = 0;
            SetPositionEditMode();

            ctlErfassungMutation1.ShowInfo();

            if ((int)qryBgPosition["BgKategorieCode"] == 101) //Einzelzahlung
            {
                edtBetragBudget.Focus();
            }
            else
            {
                edtKostenart.Focus();
            }
        }

        private void qryBgPosition_AfterPost(object sender, EventArgs e)
        {
            bool gruppierung = (bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"];
            // bewilligte, graue Zusatzleistung auf grün stellen im grünen Monatsbudget
            int positonBewilligung = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);
            int budgetBewilligung = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

            try
            {
                if (!gruppierung)
                {
                    // Verrechnungsposition nur bei bewilligter ZL erstellen
                    if (!_isMasterbudget)
                    {
                        if (kategorie == 100 && positonBewilligung == (int)BgBewilligungStatus.Erteilt || kategorie == 2)
                        {
                            WhUtil.InsertOrUpdateVerrechnungsposition(qryBgPosition);
                        }
                        else
                        {
                            WhUtil.DeleteVerrechnungsposition((int)qryBgPosition["BgPositionID"]);
                        }
                    }
                }

                if (_newPosition)
                {
                    InsertPositionVerlaufEintrag(10, Utils.ConvertToInt(qryBgPosition["BgPositionID"]));
                }

                Session.Commit();
            }
            catch
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }

            if (!gruppierung)
            {
                //Valuta-Termine speichern
                SaveValutaTermine();

                if (kategorie == 100 && positonBewilligung == 5 && budgetBewilligung >= 5)
                {
                    DBUtil.ExecSQL(
                        @"
                            EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0, null, {2}",
                        _bgBudgetID,
                        Session.User.UserID,
                        qryBgPosition["BgPositionID"]);
                    XLog.Create(
                        TYPEFULLNAME,
                        0,
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
                else if (_bgSpezkontoIDToUpdate.HasValue && kategorie == (int)LOV.BgKategorieCode.Abzahlung)
                {
                    DBUtil.ExecSQL("EXECUTE spWhSpezkonto_UpdateBudget {0}", _bgSpezkontoIDToUpdate.Value);
                    _bgSpezkontoIDToUpdate = null;
                }

                //Zahlinfo in KbBuchungung updaten, falls Status = ZahlungFehlerhaft und veränderter Zahlinfo
                if (_pendingZahlwegUpdate)
                {
                    DBUtil.ExecSQL(
                        @"
                            EXECUTE spWhBudget_UpdateKbBuchungZahlInfo {0}, {1}",
                        qryBgPosition["BgPositionID"],
                        Session.User.UserID);

                    _pendingZahlwegUpdate = false;
                }
            }

            if (!qryBgDokumente.Post())
            {
                tabBgPosition.SelectedTabIndex = 1;
                KissMsg.ShowInfo("Fehler beim Speichern des Dokuments.\r\nVerwerfen Sie die Änderung oder erfassen Sie die notwendigen Felder.");
                throw new KissCancelException();
            }

            qryBgBudgetblatt.Post();
        }

        private void qryBgPosition_BeforeDelete(object sender, EventArgs e)
        {
            // Ohne Commit wird die Transaktion von SqlQuery per Rollback abgebrochen.
            // Commit steht in qryBgPosition_AfterDelete
            Session.BeginTransaction();
            try
            {
                DBUtil.ExecSQL(@"
                delete TRM
                from   BgAuszahlungPersonTermin TRM
                       inner join BgAuszahlungPerson AUS on AUS.BgAuszahlungPersonID = TRM.BgAuszahlungPersonID
                where AUS.BgPositionID = {0}

                delete BgAuszahlungPerson where BgPositionID = {0}

                delete BgPosition where BgPositionID_Parent = {0}

                delete BgDokument where BgPositionID = {0}
                delete BgBewilligung where BgPositionID = {0}",
                qryBgPosition["BgPositionID"]);

                WhUtil.DeleteVerrechnungsposition((int)qryBgPosition["BgPositionID"]);
            }
            catch (Exception)
            {
                if (Session.Transaction != null)
                {
                    Session.Rollback();
                }

                throw;
            }
        }

        private void qryBgPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            bool gruppierung = (bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"];
            if (gruppierung)
            {
                throw new KissInfoException("Gruppen-/Kategoriezeilen können nicht gelöscht werden!");
            }

            // Seit dem Laden des Budgets könnte die Position bewilligt/grün gestellt worden sein, deshalb muss der Status aktualisiert werden
            SqlQuery qry = new SqlQuery();
            qry.Fill("EXEC spWhBudget_Get {0}", _bgBudgetID);
            if (!qry.Find(string.Format("BgPositionID = {0}", qryBgPosition["BgPositionID"])))
            {
                KissMsg.ShowInfo("Position konnte nicht gefunden werden");
                qryBgBudget.Refresh();
                return;
            }

            int? positionStatusNeu = qry["Status"] as int?;

            //nicht löschbar, wenn EditMask.Loeschen = false
            //nicht löschbar, wenn Status <> (grau,angefragt,abgelehnt,bewilligt)
            int positionStatus = _isMasterbudget || !positionStatusNeu.HasValue ? 0 : positionStatusNeu.Value;
            bool hauptDetailPos = !DBUtil.IsEmpty(qryBgPosition["DetailPos"]);

            if (_isMasterbudget)
            {
                throw new KissInfoException("In einem Masterbudget können keine Positionen gelöscht werden!");
            }

            if (positionStatus != 1 && positionStatus != 12 && positionStatus != 14 && positionStatus != 15)
            {
                throw new KissInfoException("nur graue, angefragte, abgelehnte oder bewilligte Positionen können gelöscht werden!");
            }

            if (hauptDetailPos)
            {
                throw new KissInfoException("Zusammengesetzte Positionen mit einem * oder + Zeichen können im Monatsbudget nicht gelöscht werden!");
            }
        }

        private void qryBgPosition_BeforeInsert(object sender, EventArgs e)
        {
            if (_newBgKategorieCode != 0)
            {
                return;
            }

            if (_isMasterbudget)
            {
                _newBgKategorieCode = 1; //nur neue Einnahme möglich im Masterbudget
            }
            else
            {
                KissLookupDialog dlg = new KissLookupDialog();

                bool cancel = !dlg.SearchData(@"
                    SELECT Code$ = 100, Text = 'neue zusätzliche Leistung'
                    UNION
                    SELECT 101, 'neue Einzelzahlung'
                    UNION
                    SELECT 1, 'neue Einnahme'", "", true, null, null, null);

                if (cancel)
                {
                    throw new KissCancelException();
                }

                _newBgKategorieCode = Convert.ToInt32(dlg["Code$"]);

                //es wird gleich eine neue Position erstellt.
                //falls noch das Dokument noch modified markiert ist, muss es jetzt mit der alten Position gespeichert werden,
                //sonst wird es die neue PositionID bekommen (Mantis#7789)
                if (!qryBgDokumente.Post())
                {
                    throw new KissCancelException();
                }
            }
        }

        private void qryBgPosition_BeforePost(object sender, EventArgs e)
        {
            //try
            //{
            bool gruppierung = (bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"];
            if (gruppierung)
            {
                //Gruppen- oder Kategoriezeilen
                qryBgPosition.RowModified = false;
                qryBgPosition.Row.AcceptChanges();
                return;
            }

            int budgetBewilligung = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);
            int positionBewilligung = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);
            int positionStatus = ShUtil.GetCode(qryBgPosition["Status"]);
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);

            //Einzelzahlungen ohne Spezialkonto-Finanzierung in einem nicht grauen Budget (Dieser Check noch vor dem Kostenart-Check)
            if (budgetBewilligung != 1 && kategorie == 101 && DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]))
            {
                throw new KissInfoException(
                    "Das Monatsbudget wurde bereits freigegeben. Einzelzahlungen vom Grundbedarf sind nicht mehr möglich.");
            }

            //Kostenart, Buchungstext, BetragBudget
            DBUtil.CheckNotNullField(edtKostenart, lblKostenart.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtBetragBudget, lblBetragBudget.Text);

            //BudgetBetrag >= 0, bei Einnahmen -betrag erlaubt
            if (Convert.ToDecimal(qryBgPosition["BetragBudget"]) <= Decimal.Zero &&
                (kategorie != (int)LOV.BgKategorieCode.Einnahmen || qryBgPosition["VerwaltungSD"] as bool? == true))
            {
                tabBgPosition.SelectedTabIndex = 0;
                edtBetragBudget.Focus();
                throw new KissInfoException("Der Betrag darf nicht 0.00 oder negativ sein!");
            }

            //Falls Status = Zahlungfehlerhaft und Kreditor/RefNr/Mitteilung mutiert: Flag für ZahlwegUpdate setzen für AfterPost
            _pendingZahlwegUpdate = (positionStatus == 5) &&
                                    (qryBgPosition.ColumnModified("Kreditor") ||
                                     qryBgPosition.ColumnModified("ReferenzNummer") ||
                                     qryBgPosition.ColumnModified("MitteilungZeile1") ||
                                     qryBgPosition.ColumnModified("MitteilungZeile2") ||
                                     qryBgPosition.ColumnModified("MitteilungZeile3"));

            //BetragRechnung an BetragBudget anpassen
            if (_verfuegtVisible && !qryBgPosition.ColumnModified("BetragRechnung"))
            {
                if (qryBgPosition.Row.HasVersion(DataRowVersion.Original))
                {
                    if (qryBgPosition["BetragBudget", DataRowVersion.Original].Equals(qryBgPosition["BetragRechnung", DataRowVersion.Original]))
                    {
                        qryBgPosition["BetragRechnung"] = qryBgPosition["BetragBudget"];
                    }
                }
                else
                {
                    qryBgPosition["BetragRechnung"] = qryBgPosition["BetragBudget"];
                }
            }

            //Bei Abzahlungskonti muss eine Betrag-Veränderung gleich gespeichert werden unabhängig ob das konto
            //eine BgPositionsArt konfiguriert hat oder nicht
            bool isAbzahlung = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]) == Convert.ToInt32(LOV.BgKategorieCode.Abzahlung);

            //BetragRechnung an BetragBudget anpassen
            if ((_verfuegtVisible || isAbzahlung) && !qryBgPosition.ColumnModified("BetragRechnung"))
            {
                if (qryBgPosition.Row.HasVersion(DataRowVersion.Original))
                {
                    if (qryBgPosition["BetragBudget", DataRowVersion.Original].Equals(qryBgPosition["BetragRechnung", DataRowVersion.Original]))
                    {
                        qryBgPosition["BetragRechnung"] = qryBgPosition["BetragBudget"];
                    }
                }
                else
                {
                    qryBgPosition["BetragRechnung"] = qryBgPosition["BetragBudget"];
                }
            }

            //Veränderungen von BetragRechnung/BetragBudget aufteilen auf Betrag,Reduktion und Abzug
            if (qryBgPosition.Row.HasVersion(DataRowVersion.Original))
            {
                decimal reduktionMod = (decimal)qryBgPosition["BetragRechnung", DataRowVersion.Original] - (decimal)qryBgPosition["BetragRechnung"];
                decimal abzugMod = (decimal)qryBgPosition["BetragBudget", DataRowVersion.Original] - (decimal)qryBgPosition["BetragBudget"];

                if (_verfuegtVisible || isAbzahlung)
                {
                    qryBgPosition["Reduktion"] = (decimal)qryBgPosition["Reduktion", DataRowVersion.Original] + reduktionMod;
                    qryBgPosition["Abzug"] = (decimal)qryBgPosition["Abzug", DataRowVersion.Original] - reduktionMod + abzugMod;
                }
                else
                {
                    qryBgPosition["Betrag"] = (decimal)qryBgPosition["Betrag", DataRowVersion.Original] - abzugMod;
                }
            }
            else
            {
                qryBgPosition["Betrag"] = qryBgPosition["BetragBudget"];
            }

            //bewilligten Betrag abrufen
            decimal betragBudget = 0;
            if (!DBUtil.IsEmpty(qryBgPosition["BgPositionID"]))
            {
                int bgPositionIDCopyOf = DBUtil.IsEmpty(qryBgPosition["BgPositionID_CopyOf"]) ? (int)qryBgPosition["BgPositionID"] : (int)qryBgPosition["BgPositionID_CopyOf"];
                betragBudget = GetBetragBudget(bgPositionIDCopyOf);
            }

            /*
            //vorläufig inaktiv für FAMOZ
            //check Richtlinie
            if (!DBUtil.IsEmpty(qryBgPosition["BgPositionsartID"]))
            {
                SqlQuery qry = ShUtil.GetRichtlinie((int)qryBgPosition["BgPositionsartID"], _bgBudgetID);
                if (qry.Count == 1 && edtBetragBudget.EditMode != EditModeType.ReadOnly)
                {
                    object Betrag_Min = DBUtil.IsEmpty(qryBgPosition["BaPersonID"]) ? qry["UE_MIN"] : qry["PR_MIN"];
                    object Betrag_Max = DBUtil.IsEmpty(qryBgPosition["BaPersonID"]) ? qry["UE_MAX"] : qry["PR_MAX"];

                    decimal betragOffset = 0;
                    if (qryBgPosition.Row.HasVersion(DataRowVersion.Original))
                        betragOffset = (decimal)qryBgPosition["Betrag", DataRowVersion.Original] - (decimal)qryBgPosition["BetragBudget", DataRowVersion.Original];

                    if (!DBUtil.IsEmpty(Betrag_Min) && (decimal)qryBgPosition["Betrag"] < (decimal)Betrag_Min)
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlWhBudget", "MinBetrag", "Der Betrag muss mindestens Fr. {0:n2} betragen", KissMsgCode.MsgInfo, (decimal)Betrag_Min - betragOffset), edtBetragBudget);
                    else if (!DBUtil.IsEmpty(Betrag_Max) && (decimal)qryBgPosition["Betrag"] > (decimal)Betrag_Max && (decimal)qryBgPosition["Betrag"] > betragBudget)
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlWhBudget", "MaxBetrag", "Der Betrag kann maximal Fr. {0:n2} betragen", KissMsgCode.MsgInfo, Math.Max(betragBudget, (decimal)Betrag_Max) - betragOffset), edtBetragBudget);
                }
            }
            */

            //check Betragsveränderungen + - erlaubt
            if (qryBgPosition.Row.RowState != DataRowState.Added)
            {
                if (_editMask.BetragPlus && !_editMask.BetragMinus)
                {
                    if (Convert.ToDecimal(qryBgPosition["BetragBudget"]) < betragBudget)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage("DlgPosition",
                            "BetragZuKlein",
                            "Der Betrag muss grösser oder gleich dem bewilligten Betrag (Fr. {0:n2}) sein",
                            KissMsgCode.MsgInfo,
                            betragBudget));
                    }
                }
                else if (_editMask.BetragMinus && !_editMask.BetragPlus)
                {
                    if (Convert.ToDecimal(qryBgPosition["BetragBudget"]) > betragBudget)
                    {
                        throw new KissInfoException(KissMsg.GetMLMessage("DlgPosition",
                            "BetragZuGross",
                            "Der Betrag muss kleiner oder gleich dem bewilligten Betrag (Fr. {0:n2}) sein",
                            KissMsgCode.MsgInfo,
                            betragBudget));
                    }
                }
            }

            if (kategorie == (int)LOV.BgKategorieCode.Abzahlung && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]))
            {
                _bgSpezkontoIDToUpdate = (int?)qryBgPosition["BgSpezkontoID"];
            }

            //prüfen der Verfügbarkeit des Spezialkonto-Saldos bei Einzelzahlungen
            if (kategorie == 101 && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]))
            {
                if (Convert.ToDecimal(qryBgPosition["Betrag"]) > Convert.ToDecimal(GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "Saldo")))
                {
                    throw new KissInfoException("Die Einzelzahlung kann nicht von diesem Spezialkonto abgebucht werden, da die Deckung des Spezialkontos nicht ausreicht.");
                }

                //Spezialkonto mit Institutionsbindung: check, ob ein Zahlungsweg der Institution verwendet wurde
                object baInstitutionID = GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "BaInstitutionID");
                if (!DBUtil.IsEmpty(baInstitutionID))
                {
                    /* TODO check auf alle Zahlungswege dieser Position
                    SqlQuery qryBaZahlunsweg = DBUtil.OpenSQL(@"
                                            SELECT INS.Name, ZLW.BaZahlungswegID
                                            FROM BaInstitution          INS
                                              LEFT  JOIN BaZahlungsweg  ZLW ON ZLW.BaInstitutionID = INS.BaInstitutionID
                                            WHERE INS.BaInstitutionID = {0}",
                        baInstitutionID);

                    foreach (DataRow r in qryBgAuszahlungPerson.DataTable.Rows)
                    {
                        if (!qryBaZahlunsweg.Find(string.Format("BaZahlungswegID = 0{0}", r["BaZahlungswegID"])))
                            throw new KissInfoException(KissMsg.GetMLMessage("CtlWhBudget", "FalscherZahlungsweg", "Die Auszahlung darf nur an {0} erfolgen", KissMsgCode.Nothing, qryBaZahlunsweg["Name"]));
                    }
                    if (!qryBaZahlunsweg.Find(string.Format("BaZahlungswegID = 0{0}", qryBgPosition["BaZahlungswegID"])))
                        throw new KissInfoException(KissMsg.GetMLMessage("CtlWhBudget", "FalscherZahlungsweg", "Die Auszahlung darf nur an {0} erfolgen", KissMsgCode.Nothing, qryBaZahlunsweg["Name"]));
                    */
                }

                qryBgPosition["BgPositionsartID"] = null;
            }

            //Betrifft Person
            if (!DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && !DBUtil.IsEmpty(qryBgPosition["ProUE"]))
            {
                bool proPerson = (bool)qryBgPosition["ProPerson"];
                bool proUe = (bool)qryBgPosition["ProUE"];

                if (proPerson && !proUe && DBUtil.IsEmpty(qryBgPosition["BaPersonID"]))
                {
                    edtBaPersonID.Focus();
                    throw new KissInfoException("Das Feld 'Betrifft Person' darf nicht leer bleiben für diese Leistungsart!");
                }
            }

            if (!_isMasterbudget)
            {
                switch (bgSplittingArtCode)
                {
                    case 1: //Taggenau
                    case 2: //Monat
                        DBUtil.CheckNotNullField(edtVerwPeriodeVon, "Verwendungsperiode von");
                        DBUtil.CheckNotNullField(edtVerwPeriodeBis, "Verwendungsperiode bis");
                        if ((DateTime)edtVerwPeriodeBis.EditValue < (DateTime)edtVerwPeriodeVon.EditValue)
                        {
                            edtVerwPeriodeBis.Focus();
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
            }

            if ((kategorie == 2 || kategorie == 100 || kategorie == 101) && !(_isMasterbudget && budgetBewilligung == 1))
            {
                //Ausgaben,Einzelzahlungen,Zusatzleistungen
                int auszahlungsTermin = ShUtil.GetCode(qryBgPosition["BgAuszahlungsTerminCode"]);
                int auszahlungsArt = ShUtil.GetCode(qryBgPosition["KbAuszahlungsArtCode"]);
                int es = ShUtil.GetCode(qryBgPosition["EinzahlungsscheinCode"]);

                //Ausgaben/Zusatzleistungen ohne Spezialkonto-Umleitung
                if ((kategorie == 2 || kategorie == 100) && DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]))
                {
                    DBUtil.CheckNotNullField(edtKbAuszahlungsArtCode, lblKbAuszahlungsArtCode.Text);
                    DBUtil.CheckNotNullField(edtBgAuszahlungsTerminCode, lblBgAuszahlungsTerminCode.Text);
                }

                //Valuta
                if (auszahlungsTermin == 4)
                {
                    CheckNotNullFieldOnTabPage(edtValutaDatum, lblValutaDatum.Text, tpgZahlinfo);

                    if (qryBgPosition.ColumnModified("ValutaDatum"))
                    {
                        //für FAMOZ: Valutadatum muss zwischen heute und heute + 2 Monate liegen
                        //#7198: Im Masterbudget darf das Valutadatum auch in der Vergangenheit liegen
                        if (!_isMasterbudget && ((DateTime)qryBgPosition["ValutaDatum"]) < DateTime.Today)
                        {
                            edtValutaDatum.Focus();
                            throw new KissInfoException("Das Valutadatum darf nicht in der Vergangenheit liegen!");
                        }
                        if ((DateTime)qryBgPosition["ValutaDatum"] > DateTime.Today.AddMonths(2))
                        {
                            edtValutaDatum.Focus();
                            throw new KissInfoException("Das Valutadatum darf nicht mehr als 2 Monate in der Zukunft liegen!");
                        }
                    }
                }

                //Wochentag
                if (auszahlungsTermin == 6)
                {
                    CheckNotNullFieldOnTabPage(edtWochentagCodes, "Wochentage", tpgKalender);
                }

                //individuell
                if (auszahlungsTermin == 99 && qryBgAuszahlungPersonTermin.Count == 0)
                {
                    throw new KissInfoException("Es sind noch keine individuellen Auszahltermine erfasst.");
                }

                // elektronische Auszahlung
                if (auszahlungsArt == 101)
                {
                    CheckNotNullFieldOnTabPage(edtKreditor, lblKreditor.Text, tpgZahlinfo);
                }

                // bar
                if (auszahlungsArt == 103)
                {
                    CheckNotNullFieldOnTabPage(edtMitteilungZeile1, lblZahlbarAn.Text, tpgMitteilung);
                }

                //oranger ES
                if (es == 1)
                {
                    CheckNotNullFieldOnTabPage(edtReferenzNummer, lblReferenzNummer.Text, tpgZahlinfo);

                    SqlQuery qry = DBUtil.OpenSQL("select PostKontoNummer from BaZahlungsweg where BaZahlungswegID = {0}", qryBgPosition["BaZahlungswegID"]);

                    if (qry.Count == 1 && !edtReferenzNummer.ValidateReferenzNummer(qry["PostKontoNummer"].ToString()))
                    {
                        edtReferenzNummer.Focus();
                        throw new KissCancelException();
                    }
                }

                //Mitteilungszeilen begrenzen auf 35 Zeichen
                qryBgPosition["MitteilungZeile1"] = TruncateString(qryBgPosition["MitteilungZeile1"], 35);
                qryBgPosition["MitteilungZeile2"] = TruncateString(qryBgPosition["MitteilungZeile2"], 35);
                qryBgPosition["MitteilungZeile3"] = TruncateString(qryBgPosition["MitteilungZeile3"], 35);
            }

            if (kategorie == 1)
            {
                //Einnahmen
                //Fällig am + Debitor sind Mussfelder für abgetretene Einnahmen
                if ((bool)qryBgPosition["VerwaltungSD"])
                {
                    DBUtil.CheckNotNullField(edtFaelligAm, lblValutaDatum.Text);
                    DBUtil.CheckNotNullField(edtDebitor, lblDebitor.Text);
                }

                if (!_isMasterbudget && budgetBewilligung >= 5 && positionBewilligung == 1 && !(bool)qryBgPosition["VerwaltungSD"])
                {
                    throw new KissInfoException("In einem grünen/roten Budget können nur noch abgetretene Einnahmen erfasst werden!");
                }

                if (_isMasterbudget && qryBgPosition.Row.RowState == DataRowState.Added)
                {
                    //falls DatumVon leer bleiben würde: => Position des Finanzplans
                    qryBgPosition["DatumVon"] = new DateTime((int)qryBgBudget["Jahr"], (int)qryBgBudget["Monat"], 1);
                }
            }

            ctlErfassungMutation1.SetFields();

            // für Barbelege: überprüfe die Ausgabenlimite
            if (!_isMasterbudget &&
                (kategorie == 2 || kategorie == 100 || kategorie == 101) // Ausgaben, zusätzliche Leistungen und Einzelzahlungen
                && !DBUtil.IsEmpty(qryBgPosition["KbAuszahlungsArtCode"]) // nur Ausgaben mit Auszahlung (vs. Ausgaben auf Ausgabekonto)
                && (int)qryBgPosition["KbAuszahlungsArtCode"] == 103) // nur Bar-Auszahlungen
            {
                int anzahlAuszahlungstermine = 1;
                if ((int)qryBgPosition["BgAuszahlungsTerminCode"] != 4) // Valuta hat nur einen Termin, unabhängig von qryBgAuszahlungPersonTermin
                {
                    anzahlAuszahlungstermine = qryBgAuszahlungPersonTermin.Count;
                }

                if (Math.Ceiling((decimal)qryBgPosition["BetragBudget"] / anzahlAuszahlungstermine * 20) / 20 > MaxBarBetrag)
                {
                    throw new KissInfoException(String.Format("Die Erstellung eines Barbeleges ist nicht möglich. Der Maximalbetrag pro Barbeleg beträgt CHF {0}.", MaxBarBetrag.ToString("0,000.00")));
                }
            }

            _newPosition = qryBgPosition.CurrentRowState == DataRowState.Added;

            //setzen des Bewilligungsstatus bei grauen Zusatzleistungen
            if (kategorie == 100 && (positionStatus == 1 || positionStatus == 5 || positionStatus == 12 || positionStatus == 14 || positionStatus == 15))
            {
                if (qryBgPosition.ColumnModified("BgPositionsartID") || qryBgPosition.ColumnModified("Betrag"))
                {
                    if (GetUserPermission())
                    {
                        qryBgPosition["BgBewilligungStatusCode"] = BgBewilligungStatus.Erteilt;
                    }
                    else
                    {
                        qryBgPosition["BgBewilligungStatusCode"] = BgBewilligungStatus.InVorbereitung;
                    }
                }
            }

            //setzen des Bewilligungsstatus bei Einnahmen im bewilligten Masterbudget
            if (kategorie == 1)
            {
                if (_isMasterbudget && budgetBewilligung == 5)
                {
                    qryBgPosition["BgBewilligungStatusCode"] = BgBewilligungStatus.Erteilt;
                }
            }

            Session.BeginTransaction();
        }

        private void qryBgPosition_PositionChanged(object sender, EventArgs e)
        {
            if (qryBgPosition.Count == 0)
            {
                return;
            }

            if (_refreshing)
            {
                return;
            }

            if (qryBgPosition.Row.RowState == DataRowState.Added)
            {
                return;
            }

            bool gruppierung = (bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"];
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

            // Wenn die Position von der KliBu erstellt wurde, darf ein W-Mitarbeiter nichts mutieren
            var qryBewilligung = DBUtil.ExecuteScalarSQL(@"
                SELECT TOP 1 1
                FROM dbo.BgBewilligung
                WHERE BgPositionID = {0}
                  AND BgBewilligungCode = 10 -- Erstellt
                  AND ClassName = {1};",
                qryBgPosition["BgPositionID"],
                typeof(FrmWhEinzelzahlungen).Name);
            _isKliBuPosition = !DBUtil.IsEmpty(qryBewilligung);

            SetPositionEditMode();
            LoadSpezialkonto(kategorie == 2 || kategorie == 100 ? qryBgPosition["BgKostenartID"] : null, qryBgPosition["BaPersonID"]);

            if (!gruppierung)
            {
                qryBgAuszahlungPersonTermin.Fill("SELECT * FROM BgAuszahlungPersonTermin WHERE BgAuszahlungPersonID = {0} ORDER BY Datum", qryBgPosition["BgAuszahlungPersonID"]);
                if (kategorie != 1)
                {
                    DisplayCalendarBoldDates();
                }

                qryBgDokumente.Fill(qryBgPosition["BgPositionID"]);
                edtDokumentTyp.LoadQuery(qryBgDokumentTyp);
            }

            tabBgPosition_SelectedTabChanged(tabBgPosition.SelectedTab);
            ctlErfassungMutation1.ShowInfo();

            if (qryBgPosition.Row.RowState != DataRowState.Added)
            {
                grdBgPosition.Focus();
            }
        }

        private void qryBgPosition_PositionChanging(object sender, EventArgs e)
        {
            if (!qryBgDokumente.Post())
            {
                throw new KissCancelException();
            }

            if (!qryBgBudgetblatt.Post())
            {
                throw new KissCancelException();
            }
        }

        private void qryBgPosition_PostCompleted(object sender, EventArgs e)
        {
            if (_noRefresh)
            {
                return;
            }

            qryBgPosition.Refresh();
        }

        private void tabBgPosition_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgBgUebersicht)
            {
                qryWhBudgetUebersicht.Fill(_bgBudgetID);
            }

            int budgetBewilligung = (int)qryBgBudget["BgBewilligungStatusCode"];
            SqlQuery qry;

            if (page == tpgBelege)
            {
                grdKbBuchung.DataSource = null;
                try
                {
                    if (budgetBewilligung == 1)
                    {
                        //graues Monatsbudget: Preview
                        DBUtil.ExecSQLThrowingException("exec spWhBudget_CreateKbBuchung {0}, {1}, 1", _bgBudgetID, Session.User.UserID);
                        qry = DBUtil.OpenSQL("exec spWhBudget_CreateKbBuchung {0}, {1}, 1", _bgBudgetID, Session.User.UserID);
                    }
                    else
                    {
                        //grün/rotes Monatsbudget: tatsächliche KbBuchung/KbBuchungKostenart-Einträge
                        qryKbBuchung.Fill(_bgBudgetID);
                        qry = qryKbBuchung;
                    }

                    DataSet ds = qry.DataSet;
                    ds.Relations.Add("BelegDetail",
                        ds.Tables[0].Columns["KbBuchungID"],
                        ds.Tables[1].Columns["KbBuchungID"]);

                    grdKbBuchung.DataSource = qry;
                }
                catch (Exception ex1)
                {
                    KissMsg.ShowInfo(ex1.Message);
                }
            }

            if (page == tpgBelegeBrutto)
            {
                grdKbBuchungBrutto.DataSource = null;
                try
                {
                    if (budgetBewilligung == 1)
                    {
                        //graues Monatsbudget: Preview
                        DBUtil.ExecSQLThrowingException("exec spWhBudget_CreateKbBuchung {0}, {1}, 2", _bgBudgetID, Session.User.UserID);
                        qry = DBUtil.OpenSQL("exec spWhBudget_CreateKbBuchung {0}, {1}, 2", _bgBudgetID, Session.User.UserID);
                    }
                    else
                    {
                        //grün/rotes Monatsbudget: tatsächliche KbBuchungBrutto/KbBuchungBruttoPerson-Einträge
                        qryKbBuchungBrutto.Fill(_bgBudgetID);
                        qry = qryKbBuchungBrutto;
                    }

                    DataSet ds = qry.DataSet;
                    ds.Relations.Add("BelegDetail",
                        ds.Tables[0].Columns["KbBuchungBruttoID"],
                        ds.Tables[1].Columns["KbBuchungBruttoID"]);

                    grdKbBuchungBrutto.DataSource = qry;
                }
                catch (Exception ex1)
                {
                    KissMsg.ShowInfo(ex1.Message);
                }
            }

            if (page == tpgVerlauf)
            {
                qryBgBewilligung.Fill(qryBgPosition["BgPositionID"]);
            }

            if (page == tpgBudgetblatt)
            {
                qryBgBudgetblatt.Fill(_bgBudgetID);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ApplicationFacade.DoEvents();
            timer1.Enabled = false;

            DateTime firstDate = new DateTime((int)qryBgBudget["Jahr"], (int)qryBgBudget["Monat"], 1);
            _calendarFilling = true;
            edtCalendar.SelectionRange = new SelectionRange(firstDate, firstDate.AddDays(1));
            _calendarFilling = false;
        }

        #endregion EventHandlers

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            string whGrundbedarfTyp = DBUtil.ExecuteScalarSQL(@"
                               SELECT IsNull(',%' + XLC.ShortText, '')
                                FROM BgPosition        BPO
                                  INNER JOIN XLOVCode  XLC ON XLC.LOVName = 'WhGrundbedarfTyp' AND XLC.Code = BPO.BgPositionsartID
                                WHERE BPO.BgBudgetID = {0}", _bgBudgetID) as string;

            //KissMsg.ShowInfo(WhGrundbedarfTyp + BgBudgetID.ToString());

            if ((bool)qryBgBudget["MasterBudget"])
            {
                return string.Format("WhMasterbudget{0}", whGrundbedarfTyp);
            }

            return string.Format("WhMonatsbudget{0}", whGrundbedarfTyp);
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BGBUDGETID":
                    return qryBgBudget["BgBudgetID"];

                case "ABSENDER":
                    return 0;

                case "FALLUSERID":
                    SqlQuery qryFallUser = DBUtil.OpenSQL("Select USR.UserID, USR.LogonName FROM FaLeistung LEI INNER JOIN FaFall FAL ON FAL.FaFallID = LEI.FaFallID INNER JOIN XUser USR ON FAL.UserID = USR.UserID WHERE LEI.BaPersonID = {0}", _leistungBaPersonID);
                    int fallUserID = (int)qryFallUser["UserID"];
                    return fallUserID;

                case "LEISTUNGUSERID":
                    return qryBgBudget["LeistungUserID"];

                case "ADRESSAT":
                    return qryBgBudgetblatt["AdressatID"];

                case "OHNEZUKUENFTIGELEISTUNGEN":
                    if (_isMasterbudget)
                    {
                        return edtOhneZukuenftigeLeistungen.EditValue;
                    }

                    return 0;
            }

            return base.GetContextValue(fieldName);
        }

        public override bool OnAddData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                qryBgDokumente.Insert();
                qryBgPosition["Doc"] = (qryBgDokumente.Count > 0) ? qryBgDokumente.Count.ToString() : "";
                qryBgPosition.RowModified = false;
                qryBgPosition.Row.AcceptChanges();
            }
            else if (tabBgPosition.SelectedTab == tpgBudgetblatt)
            {
                qryBgBudgetblatt.Insert();
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
                // #5898: Sobald eine Buchung an PSCD übertragen ist, dürfen zugehörige Dokumente nicht mehr gelöscht werden
                int? status = qryBgPosition["Status"] as int?;
                int? documentId = qryBgDokumente["DocumentID"] as int?;

                if (documentId.HasValue && status.HasValue && status.Value != 1 && status.Value != 2 && status.Value != 4 && status.Value != 7)
                {
                    throw new KissErrorException(KissMsg.GetMLMessage(
                        "SqlQuery",
                        "DatensatzLoeschenNichtErlaubt",
                        "Das Löschen dieses Datensatzes ist nicht erlaubt !",
                        KissMsgCode.MsgError),
                        "SqlQuery.CanDelete = false", null);
                }

                //Deutliche Warnung vor dem Löschen
                SqlQuery qry = DBUtil.OpenSQL(@"
                    select Erfassung  = isNull((select convert(varchar,{1},104) + ' ' + LogonNameVornameOrgUnit from vwUser where UserID = {0}),''),
                           Mutation   = isNull((select convert(varchar,{3},104) + ' ' + LogonNameVornameOrgUnit from vwUser where UserID = {2}),'')",
                    qryBgPosition["ErstelltUserID"],
                    qryBgPosition["ErstelltDatum"],
                    qryBgPosition["MutiertUserID"],
                    qryBgPosition["MutiertDatum"]);

                qryBgDokumente.DeleteQuestion = "Achtung: Nach der Löschung ist dieser Dokumenteintrag unwiderruflich verloren!\r\n\r\n" +
                                                "Zugehörige Budgetposition:\r\n" +
                                                "Erfassung\t" + qry["Erfassung"] + "\r\n" +
                                                "Mutation\t" + qry["Mutation"] + "\r\n\r\n" +
                                                "Soll dieser Dokumenteintrag wirklich gelöscht werden?";
                if (!qryBgDokumente.Delete())
                {
                    return false;
                }

                bool notModified = !qryBgPosition.RowModified && qryBgPosition.Row.RowState == DataRowState.Unchanged;
                qryBgPosition["Doc"] = (qryBgDokumente.Count > 0) ? qryBgDokumente.Count.ToString() : "";
                if (notModified)
                {
                    qryBgPosition.RowModified = false;
                    qryBgPosition.Row.AcceptChanges();
                }

                return true;
            }

            if (tabBgPosition.SelectedTab == tpgBudgetblatt)
            {
                return qryBgBudgetblatt.Delete();
            }

            return qryBgPosition.Delete();
        }

        public override bool OnSaveData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                if (qryBgDokumente.Row != null && (qryBgDokumente.Row.RowState != DataRowState.Unchanged ||
                    edtStichwort.EditValue != null && !edtStichwort.Equals(qryBgDokumente["Stichwort"])))
                {
                    if (!qryBgDokumente.Post())
                    {
                        return false;
                    }

                    bool notModified = !qryBgPosition.RowModified && qryBgPosition.Row.RowState == DataRowState.Unchanged;
                    qryBgPosition["Doc"] = qryBgDokumente.Count.ToString();
                    if (notModified)
                    {
                        qryBgPosition.RowModified = false;
                        qryBgPosition.Row.AcceptChanges();
                    }
                }

                _refreshing = true;
                qryBgPosition.Post();
                _refreshing = false;
                return true;
            }

            if (tabBgPosition.SelectedTab == tpgBudgetblatt)
            {
                return qryBgBudgetblatt.Post();
            }

            return qryBgPosition.Post();
        }

        public override void OnUndoDataChanges()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                qryBgDokumente.Cancel();
            }
            else if (tabBgPosition.SelectedTab == tpgBudgetblatt)
            {
                qryBgBudgetblatt.Cancel();
            }
            else
            {
                qryBgPosition.Cancel();
            }
        }

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            //Falls Gruppe/Kategorie: keine Aktion, ohne Meldung
            if ((bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"])
            {
                return;
            }

            //nicht editierbar, wenn
            //- qryBgPosition.CanUpdate == false
            //- in einem bewilligten/abgeschlossenen Masterbudget
            //- in einer nicht grauen Position eines Monatsbudgets

            bool editable = qryBgPosition.CanUpdate;
            int bewilligungCode = (int)qryBgBudget["BgBewilligungStatusCode"];
            int positionStatus = _isMasterbudget ? 0 : (int)qryBgPosition["Status"];

            if (!_isMasterbudget)
            {
                editable &= (positionStatus == 1 || positionStatus == 12 || positionStatus == 14 || positionStatus == 15);
            }

            if (!editable)
            {
                KissMsg.ShowInfo("Neue Daten vom Belegleser: Der Status der Position erlaubt keine Änderung der erfassten Daten");
                return;
            }

            // #9175: Mangels layerung wird direkt auf GUI geprüft, ob die vom Belegleser geänderten Felder editierbar sind
            // Vorerst aber nur Betragsfeld. Es könnte sein, dass Belegleser auch funktionieren muss, wenn ein Feld readonly ist
            var betragEditable = (edtBetragBudget.EditMode != EditModeType.ReadOnly || Utils.ConvertToDecimal(qryBgPosition["BetragBudget"]) == beleg.Betrag);
            //edtKreditor.EditMode != EditModeType.ReadOnly &&
            //edtReferenzNummer.EditMode != EditModeType.ReadOnly;

            if (!betragEditable && !_isMasterbudget)
            {
                KissMsg.ShowInfo("Neue Daten vom Belegleser: Der Betrag kann nicht geändert werden und gleicht nicht dem bewilliten Betrag");
                return;
            }

            Common.ZH.DlgAuswahlBaZahlungsweg dlg = new Common.ZH.DlgAuswahlBaZahlungsweg();
            ApplicationFacade.DoEvents();

            bool transfer = false;
            dlg.SucheBaZahlungsweg(beleg);
            switch (dlg.Count)
            {
                case 0:
                    KissMsg.ShowInfo("Keine zutreffenden Kreditor-Einträge im Institutionenstamm gefunden!");
                    qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryBgPosition["Kreditor"] = DBNull.Value;
                    qryBgPosition["ZusatzInfo"] = DBNull.Value;
                    if (beleg.Betrag > 0 && betragEditable)
                    {
                        qryBgPosition["BetragBudget"] = beleg.Betrag;
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
                qryBgPosition["ReferenzNummer"] = beleg.ReferenzNummer;
                qryBgPosition["EinzahlungsscheinCode"] = dlg["EinzahlungsscheinCode"];
                if (beleg.Betrag > 0 && betragEditable)
                {
                    qryBgPosition["BetragBudget"] = beleg.Betrag;
                }
            }

            qryBgPosition.RefreshDisplay();
            SetPositionEditMode();
        }

        #endregion Public Methods

        #region Internal Methods

        internal void ResetBudget()
        {
            if (!qryBgBudget.CanUpdate)
            {
                KissMsg.ShowInfo("Das Budget darf nicht verändert werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            //pendente Mutationen speichern
            _noRefresh = true;
            bool ok;
            try
            {
                ok = qryBgPosition.Post();
            }
            finally
            {
                _noRefresh = false;
            }

            if (!ok)
            {
                return;
            }

            int bgBewilligungStatusCode = (int)qryBgBudget["BgBewilligungStatusCode"];

            if (bgBewilligungStatusCode < (int)BgBewilligungStatus.Erteilt)
            {
                if (KissMsg.ShowQuestion("Soll dieses Monatsbudget an das Masterbudget angepasst werden?"))
                {
                    try
                    {
                        Session.BeginTransaction();
                        DBUtil.ExecSQLThrowingException(120, "EXECUTE spWhBudget_Reset {0}, {1}", qryBgBudget["BgFinanzplanID"], _bgBudgetID);
                        Session.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (Session.Transaction != null)
                        {
                            Session.Rollback();
                        }

                        KissMsg.ShowError("Fehler beim Zurückstellen des Budgets.", ex);
                    }

                    qryBgPosition.Refresh();
                }
            }
            else if (_isMasterbudget)
            {
                KissMsg.ShowInfo("CtlWhBudget", "MasterbudgetGesperrt", "Ein Masterbudget kann nicht zurückgesetzt werden");
            }
            else
            {
                KissMsg.ShowInfo("CtlWhBudget", "MonatsbudgetGesperrt", "Ein grünes/rotes Monatsbudget kann nicht zurückgesetzt werden");
            }
        }

        #endregion Internal Methods

        #region Protected Methods

        protected override void OnGettingLayout(KissLayoutEventArgs e)
        {
            base.OnGettingLayout(e);

            KissControlLayout.SaveSimpleProperty(e, edtOhneGruppen, "Checked");
            KissControlLayout.SaveSimpleProperty(e, edtOhneZukuenftigeLeistungen, "Checked");
        }

        protected override void OnSettingLayout(KissLayoutEventArgs e)
        {
            base.OnSettingLayout(e);

            KissControlLayout.ReadSimpleProperty(e, edtOhneGruppen, "Checked");
            KissControlLayout.ReadSimpleProperty(e, edtOhneZukuenftigeLeistungen, "Checked");

            SetRowFilter();
        }

        #endregion Protected Methods

        #region Private Methods

        private bool AuswahlDebitorFamoz(string searchString, bool buttonClicked)
        {
            bool cancel = false;
            searchString = searchString.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["BaInstitutionID"] = DBNull.Value;
                    qryBgPosition["DebitorBaPersonID"] = DBNull.Value;
                    qryBgPosition["Debitor"] = DBNull.Value;
                    qryBgPosition["ZusatzInfo"] = DBNull.Value;
                    return false;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();

            switch (searchString)
            {
                case "":
                    break;

                case ".":
                    // Debitor aus
                    // Klientensystem       - FaFallPerson
                    // Involvierte Stellen  - FaInvolvierteInstitution
                    // Krankenkasse         - BaKrankenversicherung
                    // Vermieter            - BaWohnsituation
                    // Arbeitgeber          - BaArbeit

                    cancel = !dlg.SearchData(@"
                        -- Klientensystem
                        SELECT  Art               = 'Klientensystem',
                                Name              = PRS.NameVorname,
                                Adresse           = PRS.Wohnsitz,
                                Typ               = null,
                                BaInstitutionID$  = null,
                                BaPersonID$       = PRS.BaPersonID,
                                Adresse$          = PRS.WohnsitzMehrzeilig,
                                SortKey$          = 1
                        FROM    FaFallPerson FAP
                                INNER JOIN vwPerson PRS ON PRS.BaPersonID = FAP.BaPersonID
                        WHERE   FAP.FaFallID = {0}

                        UNION

                        -- InvolvierteStelle
                        SELECT  Art              = 'involvierte Stelle',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 2
                        FROM    FaInvolvierteInstitution INV
                                INNER JOIN vwInstitution INS ON INS.BaInstitutionID = INV.BaInstitutionID
                        WHERE   INV.FaFallID = {0}

                        UNION

                        -- Krankenkasse
                        SELECT  Art              = 'Krankenkasse',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 3
                        FROM    FaFallPerson FAP
                                INNER JOIN BaKrankenversicherung KKV ON KKV.BaPersonID = FAP.BaPersonID
                                INNER JOIN vwInstitution         INS ON INS.BaInstitutionID = KKV.BaInstitutionID
                        WHERE   FAP.FaFallID = {0}

                        UNION

                        -- Vermieter
                        SELECT  Art              = 'Vermieter',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 4
                        FROM    FaFallPerson FAP
                                INNER JOIN BaWohnsituationPerson WOP ON WOP.BaPersonID = FAP.BaPersonID
                                INNER JOIN BaWohnsituation       WOH ON WOH.BaWohnsituationID = WOP.BaWohnsituationID
                                INNER JOIN vwInstitution         INS ON INS.BaInstitutionID = WOH.BaInstitutionID
                        WHERE   FAP.FaFallID = {0}

                        UNION

                        -- Arbeitgeber
                        SELECT  Art              = 'Arbeitgeber',
                                Name             = INS.Name,
                                Adresse          = INS.Adresse,
                                Typ              = INS.Typ,
                                BaInstitutionID$ = INS.BaInstitutionID,
                                BaPersonID$      = null,
                                Adresse$         = INS.AdresseMehrzeilig,
                                SortKey$         = 5
                        FROM    FaFallPerson FAP
                                INNER JOIN BaArbeit      ARB ON ARB.BaPersonID = FAP.BaPersonID
                                INNER JOIN vwInstitution INS ON INS.BaInstitutionID = ARB.BaInstitutionID
                        WHERE   FAP.FaFallID = {0}

                        ORDER BY SortKey$, Name, Adresse
                        ",
                        qryBgBudget["FaFallID"].ToString(), buttonClicked);
                    break;

                default:
                    cancel = !dlg.SearchData(@"
                        SELECT Institution      = INS.Name,
                               Adresse          = INS.Adresse,
                               Typ              = INS.Typ,
                               BaInstitutionID$ = INS.BaInstitutionID,
                               BaPersonID$      = null,
                               Adresse$         = INS.AdresseMehrzeilig
                        FROM   vwInstitution INS
                        WHERE  INS.BaFreigabeStatusCode = 2 AND
                               (INS.Name LIKE '%' + {0} + '%' OR
                                INS.AdressZusatz LIKE '%' + {0} + '%') AND
                               INS.Debitor = 1
                        ORDER BY Institution",
                        searchString,
                        buttonClicked, null, null, null);
                    break;
            }

            if (!cancel)
            {
                qryBgPosition["BaInstitutionID"] = dlg["BaInstitutionID$"];
                qryBgPosition["DebitorBaPersonID"] = dlg["BaPersonID$"];
                qryBgPosition["Debitor"] = DBUtil.IsEmpty(dlg["Name"]) ? dlg["Institution"] : dlg["Name"];
                qryBgPosition["ZusatzInfo"] = dlg["Adresse$"];
            }

            return cancel;
        }

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
                else
                {
                    qryBgPosition["Kreditor"] = DBNull.Value;
                    qryBgPosition["ZusatzInfo"] = DBNull.Value;
                    qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryBgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                    SetPositionEditMode();
                    return false;
                }
            }

            int kategorie = (int)qryBgPosition["BgKategorieCode"];

            if (!DBUtil.IsEmpty(qryBgPosition["BaZahlungswegIDFix"])) //Auszahlung an fixe Zahladresse
            {
                SqlQuery qryKreditor = DBUtil.OpenSQL("SELECT * FROM vwKreditor WHERE BaZahlungswegID = {0}", qryBgPosition["BaZahlungswegIDFix"]);
                if (qryKreditor.Count == 1)
                {
                    qryBgPosition["Kreditor"] = qryKreditor["Kreditor"];
                    qryBgPosition["ZusatzInfo"] = qryKreditor["ZusatzInfo"];
                    qryBgPosition["BaZahlungswegID"] = qryKreditor["BaZahlungswegID"];
                    qryBgPosition["EinzahlungsscheinCode"] = qryKreditor["EinzahlungsscheinCode"];

                    if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                    {
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    }
                }
                else
                {
                    qryBgPosition["Kreditor"] = DBNull.Value;
                    qryBgPosition["ZusatzInfo"] = DBNull.Value;
                    qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                    qryBgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                }

                SetPositionEditMode();
                return qryKreditor.Count != 1;
            }

            if (kategorie == 101 && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"])) //Einzelzahlung mit Spezialkonto
            {
                object baInstitutionID = GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "BaInstitutionID");
                if (!DBUtil.IsEmpty(baInstitutionID)) //Zahlwegbindung an Institution
                {
                    KissLookupDialog dlg3 = new KissLookupDialog();
                    cancel = !dlg3.SearchData(@"
                        SELECT ID$          = KRE.BaZahlungswegID,
                               Institution  = KRE.InstitutionName,
                               Zahlungsweg  = KRE.Zahlungsweg,
                               ESCode$      = KRE.EinzahlungsscheinCode,
                               Kreditor$    = KRE.Kreditor,
                               ZusatzInfo$  = KRE.ZusatzInfo
                        FROM   vwKreditor KRE
                        WHERE  KRE.BaInstitutionID = " + baInstitutionID,
                        "",
                        buttonClicked, null, null, null);

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
                    }

                    SetPositionEditMode();
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
                KissLookupDialog dlg = new KissLookupDialog();
                cancel = !dlg.SearchData(@"
                    -- Personen im Haushalt
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'Klientensystem',
                           Name             = KRE.PersonNameVorname,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZUsatzInfo,
                           SortKey$         = 1
                    FROM   FaFallPerson FAP
                           INNER JOIN vwKreditor KRE ON KRE.BaPersonID = FAP.BaPersonID
                    WHERE  FAP.FaFallID = {0}
                            AND GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate())
                            AND GetDate() BETWEEN ISNULL(FAP.DatumVon, CONVERT(DateTime, '1900-01-01')) AND ISNULL(FAP.DatumBis, CONVERT(DateTime, '2079-06-06'))

                    UNION

                    -- Involvierte Stellen
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'involvierte Stelle',
                           Name             = KRE.InstitutionName,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZusatzInfo,
                           SortKey$         = 2
                    FROM   FaInvolvierteInstitution INV
                           INNER JOIN vwKreditor    KRE ON KRE.BaInstitutionID = INV.BaInstitutionID
                    WHERE  INV.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.ZahlungswegBaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    UNION

                    -- Krankenkasse
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'Krankenkasse',
                           Name             = KRE.InstitutionName,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZusatzInfo,
                           SortKey$         = 3
                    FROM   FaFallPerson FAP
                           INNER JOIN BaKrankenversicherung KKV ON KKV.BaPersonID = FAP.BaPersonID
                           INNER JOIN vwKreditor            KRE ON KRE.BaInstitutionID = KKV.BaInstitutionID
                    WHERE  FAP.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.ZahlungswegBaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    UNION

                    -- Vermieter
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'Vermieter',
                           Name             = KRE.InstitutionName,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZusatzInfo,
                           SortKey$         = 4
                    FROM   FaFallPerson FAP
                           INNER JOIN BaWohnsituationPerson WOP ON WOP.BaPersonID = FAP.BaPersonID
                           INNER JOIN BaWohnsituation       WOH ON WOH.BaWohnsituationID = WOP.BaWohnsituationID
                           INNER JOIN vwKreditor            KRE ON KRE.BaInstitutionID = WOH.BaInstitutionID
                    WHERE  FAP.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.ZahlungswegBaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1

                    UNION

                    -- Abeitgeber
                    SELECT ID$              = KRE.BaZahlungswegID,
                           Typ              = 'Arbeitbeger',
                           Name             = KRE.InstitutionName,
                           Verwendungszweck = KRE.Verwendungszweck,
                           Zahlungsweg      = KRE.Zahlungsweg,
                           ESCode$          = KRE.EinzahlungsscheinCode,
                           Kreditor$        = KRE.Kreditor,
                           ZusatzInfo$      = KRE.ZusatzInfo,
                           SortKey$         = 5
                    FROM   FaFallPerson FAP
                           INNER JOIN BaArbeit   ARB ON ARB.BaPersonID = FAP.BaPersonID
                           INNER JOIN vwKreditor KRE ON KRE.BaInstitutionID = ARB.BaInstitutionID
                    WHERE  FAP.FaFallID = {0} AND
                           GetDate() BETWEEN ISNULL(KRE.ZahlungswegDatumVon, GetDate()) AND ISNULL(dateadd(d,1,KRE.ZahlungswegDatumBis), GetDate()) AND
                           KRE.BaFreigabeStatusCode = 2 AND
                           KRE.ZahlungswegBaFreigabeStatusCode = 2 AND
                           KRE.InstitutionIstKreditor = 1
                    ORDER BY SortKey$,Name,Zahlungsweg",
                    qryBgBudget["FaFallID"].ToString(),
                    buttonClicked, null, null, null);

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
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    }

                    SetPositionEditMode();
                    return false;
                }
            }
            else // Auszahlung Dritte
            {
                Common.ZH.DlgAuswahlBaZahlungsweg dlg2 = new Common.ZH.DlgAuswahlBaZahlungsweg();
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
                    SqlQuery qry2 = DBUtil.OpenSQL(@"
                        select FallNrNameVorname = 'F' + convert(varchar,{1}) + ' ' + NameVorname,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                        from   vwPerson
                        where  BaPersonID = {0}",
                        qryBgBudget["LeistungBaPersonID"],
                        qryBgBudget["FaFallID"]);

                    qryBgPosition["BaZahlungswegID"] = dlg2["BaZahlungswegID"];
                    qryBgPosition["Kreditor"] = dlg2["Kreditor"];
                    qryBgPosition["ZusatzInfo"] = dlg2["ZusatzInfo"];
                    qryBgPosition["EinzahlungsscheinCode"] = dlg2["EinzahlungsscheinCode"];
                    qryBgPosition["MitteilungZeile1"] = TruncateString(qry2["FallNrNameVorname"], 35);

                    kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
                    if (kategorie == 100 || kategorie == 2)
                    {
                        qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                        qryBgPosition["Status"] = 1;	//(grau
                    }

                    if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                    {
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    }
                }

                qryBgPosition.RefreshDisplay();
                SetPositionEditMode();
            }
            return cancel;
        }

        private bool BgDokumentTypIsNotMutierbarLoeschbar(int bgDokumentTypCode)
        {
            //Regel :
            // - Dokumenten vom Typ (=4) Masterbudgetpostion darf man nur auf Masterbudget ändern/löschen
            // - Dokumenten vom Typ (=3) Finanzplan darf man nie ändern/löschen

            return (!_isMasterbudget && bgDokumentTypCode == 4)
                        || bgDokumentTypCode == 3;
        }

        private void CheckNotNullFieldOnTabPage(IKissBindableEdit ctl, String text, SharpLibrary.WinControls.TabPageEx page)
        {
            try
            {
                ((KissTabControlEx)page.Parent).SelectTab(page);
            }
            catch { }

            DBUtil.CheckNotNullField(ctl, text);
        }

        private void DisplayCalendarBoldDates()
        {
            _calendarFilling = true;

            edtCalendar.TodayDate = DateTime.Today;

            edtCalendar.BoldedDates = null;
            if (_isMasterbudget)
            {
                return;
            }

            DateTime firstDate = new DateTime(_budgetJahr, _budgetMonat, 1);
            edtCalendar.MaxSelectionCount = 2;
            edtCalendar.SelectionRange = new SelectionRange(firstDate, firstDate.AddDays(1));

            _calendarFilling = true;
            try
            {
                foreach (DataRow row in qryBgAuszahlungPersonTermin.DataTable.Rows)
                {
                    edtCalendar.AddBoldedDate((DateTime)row["Datum"]);
                }
            }
            catch { }

            _calendarFilling = false;
        }

        private void DisplayValutaTermine()
        {
            string valutaTermine = "";
            foreach (DataRow row in qryBgAuszahlungPersonTermin.DataTable.Rows)
            {
                if (valutaTermine != "")
                {
                    valutaTermine += @"  ";
                }

                valutaTermine += ((DateTime)row["Datum"]).ToString("d.M");
            }

            qryBgPosition["ValutaTermine"] = valutaTermine;
            qryBgPosition.RefreshDisplay();
        }

        private decimal GetBetragBudget(object bgPositionID)
        {
            return (decimal)DBUtil.ExecuteScalarSQL(@"
                DECLARE @BgPositionID int,
                        @Betrag       money
                SET @BgPositionID = {0}

                WHILE ( @Betrag IS NULL AND EXISTS (SELECT * FROM BgPosition WHERE BgPositionID = @BgPositionID) ) BEGIN
                  SELECT @BgPositionID = BPO.BgPositionID_CopyOf,
                         @Betrag = CASE
                                     WHEN BBG.MasterBudget = 0       THEN NULL
                                     WHEN BPO.DatumVon < '19010101'  THEN NULL
                                     ELSE BPO.BetragBudget
                                   END
                  FROM vwBgPosition      BPO
                    INNER JOIN BgBudget  BBG ON BBG.BgBudgetID = BPO.BgBudgetID
                  WHERE BPO.BgPositionID = @BgPositionID
                END
                SELECT IsNull(@Betrag, $0.00)"
                , bgPositionID);
        }

        private object GetFieldFromSpezkonto(object bgSpezkontoID, string fieldName)
        {
            DataRow[] rows;
            SqlQuery qry = (SqlQuery)edtBgSpezkontoID.Properties.DataSource;

            if (DBUtil.IsEmpty(bgSpezkontoID))
            {
                rows = qry.DataTable.Select("Code is null"); //Grundbedarf
            }
            else
            {
                rows = qry.DataTable.Select(string.Format("Code = {0}", bgSpezkontoID)); //Spezkonto
            }

            if (rows.Length == 1)
            {
                return rows[0][fieldName].ToString();
            }

            return null;
        }

        private bool GetUserPermission()
        {
            decimal betragBudget = (decimal)qryBgPosition["BetragBudget"];
            int bgPositionsartID = ShUtil.GetCode(qryBgPosition["BgPositionsartID"]);

            /*
            int BgSpezkontoID = ShUtil.GetCode(qryBgPosition["BgSpezkontoID"]);
            if (BgSpezkontoID > 0)
            {
                BgPositionsartID = Convert.ToInt32(GetFieldFromSpezkonto(BgSpezkontoID,"BgPositionsartID"));
            }
            */

            return GetUserPermission(betragBudget, bgPositionsartID);
        }

        private bool GetUserPermission(decimal betrag, int bgPositionsartID)
        {
            return betrag <= Convert.ToDecimal(DBUtil.GetUserSilPermission(bgPositionsartID, _faLeistungID));
        }

        private void InsertPositionVerlaufEintrag(int bgBewilligungCode, int bgPositionID)
        {
            qryBgBewilligung.CanInsert = true;
            qryBgBewilligung.Fill(bgPositionID);

            qryBgBewilligung.Insert();
            qryBgBewilligung["BgPositionID"] = bgPositionID;
            qryBgBewilligung["UserID"] = Session.User.UserID;
            qryBgBewilligung["ClassName"] = Name;
            qryBgBewilligung["Datum"] = DateTime.Now;
            qryBgBewilligung["BgBewilligungCode"] = bgBewilligungCode;
            qryBgBewilligung.Post();
            qryBgBewilligung.CanInsert = false;
        }

        private void LoadSpezialkonto(object bgKostenartID, object baPersonID)
        {
            edtBgSpezkontoID.Properties.ShowHeader = true;
            edtBgSpezkontoID.Properties.DropDownRows = 7;
            edtBgSpezkontoID.Properties.DataSource = DBUtil.OpenSQL(@"
                SELECT Code                = SPK.BgSpezkontoID,
                       Typ                 = TYP.ShortText,
                       KOA                 = BKA.KontoNr,
                       Text                = SPK.NameSpezkonto,
                       Saldo               = dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, {2}, {4}),
                       SortKey             = TYP.Sortkey,
                       KOAName             = BKA.KontoNr + ' ' + BKA.Name,
                       BaPersonID          = SPK.BaPersonID,
                       BgPositionsartID    = SPK.BgPositionsartID,
                       KOAPositionsart     = BKA.KontoNr + ' ' + ISNULL(BPA.Name, BKA.Name),
                       BgSplittingArtCode  = BKA.BgSplittingArtCode,
                       ProPerson           = BPA.ProPerson,
                       ProUE               = BPA.ProUE,
                       BaInstitutionID     = SPK.BaInstitutionID,
                       BaZahlungswegIDFix  = BKA.BaZahlungswegIDFix
                FROM BgSpezkonto             SPK
                       INNER JOIN XLOVCode        TYP ON TYP.LOVName = 'BgSpezkontoTyp' and TYP.Code = SPK.BgSpezkontoTypCode
                       LEFT  JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = SPK.BgPositionsartID
                       LEFT  JOIN BgPositionsart  GBL ON GBL.BgPositionsartID = {1}
                       LEFT  JOIN BgKostenart     BKA ON BKA.BgKostenartID = ISNULL(SPK.BgKostenartID, GBL.BgKostenartID)
                WHERE SPK.FaLeistungID = {0}
                      AND SPK.BgSpezkontoTypCode <> 2
                      AND (    ({3} IN (2, 100) AND (SPK.BgSpezkontoTypCode = 1 AND SPK.BgKostenartID = {5} AND
                               (COALESCE(SPK.BaPersonID, {6}, 0) = IsNull({6}, 0) OR BKA.Quoting = 1)))
                            OR ({3} IN (6)      AND (SPK.BgSpezkontoTypCode = 2))
                            OR ({3} IN (3)      AND (SPK.BgSpezkontoTypCode = 3))
                            OR ({3} IN (101)    AND (SPK.BgSpezkontoTypCode <> 3 OR SPK.OhneEinzelzahlung = 0)
                                                AND EXISTS (SELECT TOP 1 1
                                                            FROM BgPositionsart
                                                            WHERE BgKostenartID = SPK.BgKostenartID AND BgKategorieCode IN (2,3,101))) --es muss eine aktive Ausgabe-, Verrechnungs- oder Einzelzahlungs-Positionsart geben
                            --Spezialkonto anzeigen, wenn der aktuelle Datensatz es bereits verwendet
                            OR EXISTS (SELECT TOP 1 1 FROM BgPosition WHERE BgPositionID = {4} AND BgSpezkontoID = SPK.BgSpezkontoID))

                UNION ALL

                SELECT Code                = NULL,
                       Typ                 = NULL,
                       KOA                 = NULL,
                       Text                = NULL,
                       Saldo               = NULL,
                       SortKey             = 0,
                       KOAName             = BKA.KontoNr + ' ' + BKA.Name,
                       BaPersonID          = NULL,
                       BgPositionsartID    = BPA.BgPositionsartID,
                       KOAPositionsart     = BKA.KontoNr + ' ' + BPA.Name,
                       BgSplittingArtCode  = BKA.BgSplittingArtCode,
                       ProPerson           = BPA.ProPerson,
                       ProUE               = BPA.ProUE,
                       BaInstitutionID     = NULL,
                       BaZahlungswegIDFix  = BKA.BaZahlungswegIDFix
                FROM BgKostenart             BKA
                       INNER JOIN BgPositionsart  BPA ON BPA.BgKostenartID = BKA.BgKostenartID
                WHERE BPA.BgPositionsartID = {1}
                ORDER BY SortKey, Text",
                qryBgBudget["FaLeistungID"],
                qryBgBudget["WhGrundbedarfTypCode"],
                qryBgPosition["BgBudgetID"],
                qryBgPosition["BgKategorieCode"],
                qryBgPosition["BgPositionID"],
                bgKostenartID,
                baPersonID);
        }

        private void LoadValutaTermine()
        {
            if (DBUtil.IsEmpty(qryBgPosition["BgAuszahlungsTerminCode"]))
            {
                qryBgAuszahlungPersonTermin.Fill("select top 0 * from BgAuszahlungPersonTermin");
                return;
            }

            int bgAuszahlungsTerminCode = (int)qryBgPosition["BgAuszahlungsTerminCode"];
            switch (bgAuszahlungsTerminCode)
            {
                case 1:  // 1x pro Monat
                case 2:  // 2x pro Monat
                case 3:  // wöchentlich
                case 5:  // 14-täglich

                    qryBgAuszahlungPersonTermin.Fill(@"
                        select T.Datum
                        from   fnKbAuszahlTermine({0},{1}) T
                        where  T.BgAuszahlungsTerminCode = {2}
                        order by T.Datum",
                       _budgetJahr,
                       _budgetMonat,
                       bgAuszahlungsTerminCode);
                    break;

                case 4:  // Valuta
                    break;

                case 6:  // Wochentage
                    qryBgAuszahlungPersonTermin.Fill(@"
                        select T.Datum
                        from   fnKbAuszahlTermine({0},{1}) T
                        where  T.BgAuszahlungsTerminCode = {2} and
                                   {3} like '%' + convert(varchar,T.BgWochentagCode) + '%'
                        order by T.Datum",
                       _budgetJahr,
                       _budgetMonat,
                       bgAuszahlungsTerminCode,
                       qryBgPosition["BgWochentagCodes"]);
                    break;

                case 99: //Individuell
                    break;
            }
        }

        private void NeuePosition(int bgKategorieCode)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            if (!qryBgDokumente.Post())
            {
                return;
            }

            if (!qryBgPosition.CanInsert)
            {
                KissMsg.ShowInfo("Es darf keine Position eingefügt werden."); // Benutzer hat zuwenig Rechte
                return;
            }

            _newBgKategorieCode = bgKategorieCode;
            qryBgPosition.Insert();
        }

        private void SaveCalendarBoldDates()
        {
            qryBgAuszahlungPersonTermin.DataTable.Rows.Clear();
            DateTime[] dates = (DateTime[])edtCalendar.BoldedDates.Clone();
            Array.Sort(dates);
            foreach (DateTime date in dates)
            {
                qryBgAuszahlungPersonTermin.Insert();
                qryBgAuszahlungPersonTermin["Datum"] = date;
                qryBgAuszahlungPersonTermin.RowModified = false;
                qryBgAuszahlungPersonTermin.Row.AcceptChanges();
            }
        }

        private void SaveValutaTermine()
        {
            int kategorie = (int)qryBgPosition["BgKategorieCode"];
            if (kategorie == 1)
            {
                return; //Einnahmen
            }

            int auszahlungsTermin = 0;
            if (!DBUtil.IsEmpty(qryBgPosition["BgAuszahlungsTerminCode"]))
            {
                auszahlungsTermin = (int)qryBgPosition["BgAuszahlungsTerminCode"];
            }

            //Löschen der alten Daten
            DBUtil.ExecSQLThrowingException(@"
                    delete TRM
                    from   BgAuszahlungPersonTermin TRM
                           inner join BgAuszahlungPerson AUS on AUS.BgAuszahlungPersonID = TRM.BgAuszahlungPersonID
                    where AUS.BgPositionID = {0}

                    delete BgAuszahlungPerson where BgPositionID = {0}",
                qryBgPosition["BgPositionID"]);

            if (auszahlungsTermin == 0)
            {
                return; //keine neuen Daten, falls kein gültiger Auszahltermin
            }

            //Neuer Datensatz BgAuszahlungPerson
            SqlQuery qry = DBUtil.OpenSQL(@"
                    insert BgAuszahlungPerson (BgPositionID, BaPersonID, KbAuszahlungsArtCode, BgAuszahlungsTerminCode, BgWochentagCodes,
                                               BaZahlungswegID, ReferenzNummer, MitteilungZeile1,MitteilungZeile2,MitteilungZeile3,MitteilungZeile4)
                    values({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10})
                    select BgAuszahlungPersonID = @@identity",
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
                qryBgPosition["MitteilungZeile4"]);

            if (qry.Count == 0)
            {
                throw new KissInfoException("Fehler beim Speichern der Auszahlinformationen");
            }

            //Neue Datensätze in BgAuszahlungPersonTermin
            String sql = "";
            if (auszahlungsTermin == 4) //Valuta
            {
                sql += @" insert BgAuszahlungPersonTermin (BgAuszahlungPersonID,Datum) values ({0}," +
                              DBUtil.SqlLiteral(qryBgPosition["ValutaDatum"]) + ") ";
            }
            else
            {
                foreach (DataRow row in qryBgAuszahlungPersonTermin.DataTable.Rows)
                {
                    sql += @" insert BgAuszahlungPersonTermin (BgAuszahlungPersonID,Datum) values ({0}," +
                                  DBUtil.SqlLiteral(row["Datum"]) + ") ";
                }
            }

            if (sql.Length > 0)
            {
                DBUtil.ExecSQLThrowingException(sql, qry["BgAuszahlungPersonID"]);
            }
        }

        private void SetBudgetblattEditMode()
        {
            bool enabled = DBUtil.IsEmpty(qryBgBudgetblatt["DocumentID"]);
            if (enabled)
            {
                edtBegleitbrief.EditMode = EditModeType.Normal;
                if (edtBegleitbrief.EditValue as bool? == true)
                {
                    edtAdressat.EditMode = EditModeType.Normal;
                }
                else
                {
                    edtAdressat.EditMode = EditModeType.ReadOnly;
                }
            }
            else
            {
                edtBegleitbrief.EditMode = EditModeType.ReadOnly;
                edtAdressat.EditMode = EditModeType.ReadOnly;
            }
        }

        private void SetBudgetEditMode()
        {
            int bewilligungCode = (int)qryBgBudget["BgBewilligungStatusCode"];
            bool editable = (bewilligungCode != 5) && (bewilligungCode != 9);
            bool leistungAktiv = DBUtil.IsEmpty(qryBgBudget["LeistungDatumBis"]);

            if ((bool)qryBgBudget["Masterbudget"])
            {
                btnBudgetNeu.Enabled = leistungAktiv && !editable;
                btnEinzelzahlung.Enabled = false;
                btnZusatzleistung.Enabled = false;
                btnEinnahme.Enabled = false;
            }
            else
            {
                btnBudgetNeu.Enabled = leistungAktiv;
                btnEinzelzahlung.Enabled = true;
                btnZusatzleistung.Enabled = true;
                btnEinnahme.Enabled = true;

                int countUnveraenderbar = 0;

                foreach (DataRow row in qryBgPosition.DataTable.Rows)
                {
                    if (!((bool)row["Gruppe"]) && !((bool)row["Kategorie"]) && ((int)row["Status"] != 1) && ((int)row["Status"] != 2) && ((int)row["Status"] != 12) && ((int)row["Status"] != 14) && ((int)row["Status"] != 15))
                    {
                        countUnveraenderbar++;
                    }
                }

                btnBudgetGrau.Visible = leistungAktiv && (bewilligungCode == 5) && (countUnveraenderbar == 0);
                btnBudgetGruen.Visible = leistungAktiv && (bewilligungCode == 1) || (bewilligungCode == 9);
                btnBudgetRot.Visible = leistungAktiv && (bewilligungCode == 5);
            }
        }

        private void SetEditMask()
        {
            int budgetStatus = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);
            int positionStatus = ShUtil.GetCode(qryBgPosition["Status"]);
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            int masterbudgetEditMask = ShUtil.GetCode(qryBgPosition["Masterbudget_EditMask"]);
            int monatsbudgetEditMask = ShUtil.GetCode(qryBgPosition["Monatsbudget_EditMask"]);
            bool masterPosition = !DBUtil.IsEmpty(qryBgPosition["M"]);
            bool freigegeben = (positionStatus != 1 && positionStatus != 12 && positionStatus != 14 && positionStatus != 15);
            int mask;

            if (qryBgPosition.Row != null && qryBgPosition.Row.RowState == DataRowState.Added)
            {
                if (kategorie == 101)
                {
                    //Einzelzahlung
                    mask = 0x3CF; // Löschen, Betrag +/-, Neu, Text, Betrifft Person, Bemerkung, Betrag Rechnung
                }
                else
                {
                    mask = 0x3FF; // Löschen, Betrag +/-, Neu, Gruppe, Art, Text, Betrifft Person, Bemerkung, Betrag Rechnung
                }
            }
            else
            {
                if (_isMasterbudget || masterPosition)
                {
                    switch (kategorie)
                    {
                        case 3: // Abzahlungen
                        case 6: // Vorabzug
                            mask = 0x146000;
                            break;

                        case 4: // Kürzung
                            mask = 0x1CF000;
                            break;

                        default:
                            mask = masterbudgetEditMask;
                            break;
                    }
                }
                else
                {
                    switch (kategorie)
                    {
                        case 101: //Einzelzahlung
                            mask = 0x3CF;
                            break;

                        case 100: //Zusätzliche Leistung
                            if (freigegeben && DBUtil.IsEmpty(qryBgPosition["KbAuszahlungsArtCode"])) // Zusätzl. Leistung ohne Auszahlung
                                mask = 0x3FF3FF;
                            else
                                mask = monatsbudgetEditMask;
                            break;

                        case 3: // Abzahlungen
                        case 6: // Vorabzug
                            mask = 0x146;
                            break;

                        case 4: // Kürzung
                            mask = 0x1CF;
                            break;

                        default:
                            mask = monatsbudgetEditMask;
                            break;
                    }
                }

                if (freigegeben || masterPosition)
                {
                    mask = (mask & 0xFFF000) / 0x1000; // shift nach rechts
                }
                else
                {
                    mask = (mask & 0x000FFF);
                }
            }

            _editMask.Loeschen = (mask & 0x001) == 0x001;
            _editMask.BetragMinus = (mask & 0x002) == 0x002;
            _editMask.BetragPlus = (mask & 0x004) == 0x004;
            _editMask.Neu = (mask & 0x008) == 0x008;
            _editMask.Gruppe = (mask & 0x010) == 0x010;
            _editMask.Art = (mask & 0x020) == 0x020;
            _editMask.Text = (mask & 0x040) == 0x040;
            _editMask.BetrifftPerson = (mask & 0x080) == 0x080;
            _editMask.Bemerkung = (mask & 0x100) == 0x100;
            _editMask.BetragRechnung = (mask & 0x200) == 0x200;
            _editMask.GruppeFilter = (mask & 0x400) == 0x400;

            _verfuegtVisible = (masterbudgetEditMask & 0x200000) > 0 || (monatsbudgetEditMask & 0x200200) > 0;

            _editMaskInfo =
                "Kategorie = " + kategorie.ToString() + "\r\n" +
                "BudgetStatus = " + budgetStatus.ToString() + "\r\n" +
                "PositionStatus = " + positionStatus.ToString() + "\r\n" +
                "freigegeben = " + freigegeben.ToString() + "\r\n" +
                "GruppeFilter = " + qryBgPosition["GruppeFilter"] + "\r\n\r\n" +

                "MasterbudgetEditMask = 0x" + masterbudgetEditMask.ToString("x") + "\r\n" +
                "MonatsbudgetEditMask = 0x" + monatsbudgetEditMask.ToString("x") + "\r\n" +
                "Mask = 0x" + mask.ToString("x") + "\r\n\r\n" +

                "EditMask.Loeschen\t\t" + _editMask.Loeschen.ToString() + "\r\n" +
                "EditMask.BetragMinus\t" + _editMask.BetragMinus.ToString() + "\r\n" +
                "EditMask.BetragPlus\t" + _editMask.BetragPlus.ToString() + "\r\n" +
                "EditMask.Neu\t\t" + _editMask.Neu.ToString() + "\r\n" +
                "EditMask.Gruppe\t\t" + _editMask.Gruppe.ToString() + "\r\n" +
                "EditMask.Art\t\t" + _editMask.Art.ToString() + "\r\n" +
                "EditMask.Text\t\t" + _editMask.Text.ToString() + "\r\n" +
                "EditMask.BetrifftPerson\t" + _editMask.BetrifftPerson.ToString() + "\r\n" +
                "EditMask.Bemerkung\t" + _editMask.Bemerkung.ToString() + "\r\n" +
                "EditMask.BetragRechnung\t" + _editMask.BetragRechnung.ToString() + "\r\n" +
                "EditMask.GruppeFilter\t" + _editMask.GruppeFilter.ToString();
        }

        private void SetPositionEditMode()
        {
            if (qryBgPosition.Count == 0)
            {
                return;
            }

            try
            {
                bool gruppierung = (bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"];

                int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

                if (gruppierung)
                {
                    qryBgPosition.EnableBoundFields(false);
                    tabZahlinfo.Visible = false;
                    tpgDokumente.HideTab = true;
                    tpgBelege.HideTab = _isMasterbudget;
                    tpgBelegeBrutto.HideTab = _isMasterbudget;
                    tpgBgUebersicht.HideTab = _isMasterbudget;
                    btnPositionGrau.Visible = false;
                    btnPositionGruen.Visible = false;
                    btnPositionRot.Visible = false;
                    btnPositionBewilligung.Visible = false;
                    btnPositionVerlauf.Visible = false;
                    btnSpezialkonto.Visible = false;
                    edtVerwPeriodeVon.Visible = false;
                    edtVerwPeriodeBis.Visible = false;
                    edtBgSplittingCode.Visible = false;
                    lblVerwPeriode.Visible = false;
                    lblVerwPeriodeStrich.Visible = false;
                    lblBgSplittingCode.Visible = false;
                    return;
                }

                SetEditMask();

                //Position Löschen
                qryBgPosition.CanDelete = !_isMasterbudget && _editMask.Loeschen && qryBgPosition.CanUpdate && (!_isKliBuPosition || Session.User.IsUserAdmin);

                //nicht editierbar, wenn
                //- qryBgPosition.CanUpdate == false
                //- Leistung abgeschlossen
                //- in einer nicht grauen/angefragten Position eines Monatsbudgets
                //- mit Spezialrecht Einnahmen erfassen erlauben in abgeschlossenem W und grünem Budget
                //- Position von KliBu erfasst und nicht von KliBu-SA betrachtet

                int bewilligungCode = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);
                int positionStatus = ShUtil.GetCode(qryBgPosition["Status"]);
                int positionStatusMin = ShUtil.GetCode(qryBgPosition["StatusMin"]);
                bool hauptDetailPos = !DBUtil.IsEmpty(qryBgPosition["DetailPos"]);

                bool editable = qryBgPosition.CanUpdate &&
                                !hauptDetailPos &&
                                (DBUtil.IsEmpty(qryBgBudget["LeistungDatumBis"]) ||
                                (DBUtil.UserHasRight("CtlWhBudget_EinnahmenInaktivesW") && (kategorie == 1) && (bewilligungCode == 5))) &&
                                (!_isKliBuPosition || Session.User.IsUserAdmin);

                bool auszahlungEditable;
                bool auszahlungFehlerhaft = (positionStatus == 5);
                bool hvtvAufPositionsart = qryBgPosition["HVTVAufPositionsart"] as bool? == true;

                if (_isMasterbudget)
                {
                    editable = (bewilligungCode == 5); //Anpassungen nur möglich im bewilligten Budget
                    auszahlungEditable = (bewilligungCode == 5); //Auszahlwege vorerst nur im bewilligten Masterbudget
                }
                else
                {
                    if ((kategorie == 100) && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"])) // Zusätzl. Leistung auf Spezialkonto
                    {
                        editable &= (positionStatus != 14);
                        auszahlungEditable = editable;
                    }
                    else
                    {
                        editable &= (positionStatus == 1) || //In Vorbereitung (grau)
                                              (positionStatus == 12) || //angefragt (hellblau)
                                              (positionStatus == 14) || //bewilligt(hellblau)
                                              (positionStatus == 15) || //abgelehnt(hellblau)
                                              ((kategorie == 3) && (bewilligungCode < 5)) || // Abzahlung
                                              ((kategorie == 6) && (bewilligungCode < 5)) || // Vorabzug
                                              ((kategorie == 100) && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"])); // Zusätzl. Leistung auf Spezialkonto
                        auszahlungEditable = editable;
                    }
                }

                // automatisch erstellte Verrechnungen dürfen nicht editiert werden
                if (kategorie == 3 && !DBUtil.IsEmpty(qryBgPosition["BgPositionID_Parent"]))
                {
                    editable = false;
                    auszahlungEditable = false;
                }

                qryBgPosition.EnableBoundFields(editable);

                //Register
                tabZahlinfo.Visible = true;
                tpgDokumente.HideTab = (qryBgPosition.Row.RowState == DataRowState.Added);
                tpgBelege.HideTab = _isMasterbudget;

                tpgBelegeBrutto.HideTab = _isMasterbudget;
                tpgBgUebersicht.HideTab = _isMasterbudget;

                //Positionsbuttons
                if (_isMasterbudget)
                {
                    btnPositionGruen.Visible = false;
                    btnPositionGruen.Visible = false;
                    btnPositionRot.Visible = false;
                    btnPositionBewilligung.Visible = false;
                    btnPositionVerlauf.Visible = false;
                    btnSpezialkonto.Visible = false;
                }
                else
                {
                    //Positionsbutton grün
                    switch (kategorie)
                    {
                        case 100: //Zusatzleistung
                            if (DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]))
                                btnPositionGruen.Visible = (bewilligungCode != 1) && // bewilligt
                                                           (positionStatus == 14 ||  // rot, Zahlauftrag fehlerhaft
                                                            positionStatus == 7 ||
                                                            positionStatusMin == 7 ||
                                                            positionStatus == 5) &&
                                                            (!_isKliBuPosition || positionStatus == 7 || positionStatusMin == 7 || Session.User.IsUserAdmin); // kommt aus klibu, ist rot
                            else
                                // Zusatzleistung auf Ausgabenkonto
                                btnPositionGruen.Visible = false;
                            break;

                        case 2: //Ausgabe
                        case 101: //Einzelzahlung

                            if (kategorie == 2 && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]))
                            { // Positionen aufs Ausgabekonto können nicht separat auf grün gestellt werden
                                btnPositionGruen.Visible = false;
                                break;
                            }

                            btnPositionGruen.Visible = (bewilligungCode != 1) &&
                                                       (positionStatus == 1 || // grau, rot, Zahlauftrag fehlerhaft
                                                        positionStatus == 7 ||
                                                        positionStatusMin == 7 ||
                                                        positionStatus == 5) &&
                                                        (!_isKliBuPosition || positionStatus == 7 || positionStatusMin == 7 || Session.User.IsUserAdmin); // kommt aus klibu, ist rot
                            break;

                        case 1: //Einnahme
                            btnPositionGruen.Visible = (bewilligungCode != 1) && (positionStatus == 1);  //grau
                            break;

                        case 4: //Sanktion/Kürzung
                            btnPositionGruen.Visible = false;
                            break;
                    }
                }

                //Positionsbutton Grau
                switch (kategorie)
                {
                    case 1: //Einnahme
                        btnPositionGrau.Visible = positionStatus == 2;  //grün
                        break;

                    case 101: //Einzelzahlung
                        btnPositionGrau.Visible = positionStatus == 2 && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]) && (!_isKliBuPosition || Session.User.IsUserAdmin);  //grün
                        break;

                    case 100: //Zusatzleistung
                        if (DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]))
                        {
                            btnPositionGrau.Visible = positionStatus == 2 && (!_isKliBuPosition || Session.User.IsUserAdmin); //grün, nicht KliBu-Position
                        }
                        else // Auf Ausgabekonto
                        {
                            btnPositionGrau.Visible = false;
                        }

                        break;

                    case 2: //Ausgabe
                        bool dritte = !DBUtil.IsEmpty(qryBgPosition["Dri"]);
                        btnPositionGrau.Visible = (positionStatus == 2) && dritte;  //grün, nur an Dritte
                        break;

                    case 4: //Sanktion/Kürzung
                        btnPositionGruen.Visible = false;
                        break;
                }

                //Positionsbutton Rot
                switch (kategorie)
                {
                    case 1: //Einnahme
                        btnPositionRot.Visible = false;
                        break;

                    case 101: //Einzelzahlung
                    case 2: //Ausgabe
                        if (DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]))
                        {
                            btnPositionRot.Visible = (positionStatus == 2 || positionStatusMin == 2); //grün
                        }
                        else
                        {
                            btnPositionRot.Visible = false; // Ausgaben auf das Ausgabenkonto können nicht rot gestellt werden.
                        }
                        break;

                    case 100: //Zusatzleistung
                        btnPositionRot.Visible = (positionStatus == 2 || positionStatusMin == 2) && DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]);  //grün, ohne Spezkonto
                        break;

                    case 4: //Sanktion/Kürzung
                        btnPositionRot.Visible = false;
                        break;
                }

                // Positionen mit Verrechnungen dürfen nicht grau, grün oder rot gestellt werden
                var hasVerrechnungsposition = WhUtil.HasVerrechnungsPosition(qryBgPosition["BgPositionID"] as int?);
                if (hasVerrechnungsposition)
                {
                    btnPositionGruen.Visible = false;
                    btnPositionGrau.Visible = false;
                    btnPositionRot.Visible = false;
                }

                //Positionsbutton Bewilligung,Verlauf,Spezialkonto
                btnPositionBewilligung.Visible = (kategorie == 100 && (positionStatus == 1 || positionStatus == 12 || positionStatus == 15) && (!_isKliBuPosition || Session.User.IsUserAdmin));  //graue/angefragte(abgelehnte Zusatzleistung

                btnPositionVerlauf.Visible = false; //TODO(kategorie == 100 && PositionStatus != 1);  //nicht graue Zusatzleistung

                btnSpezialkonto.Visible = false; // TODO (kategorie == 100 && (PositionStatus == 1 || PositionStatus == 12)) ||  //graue/angefragte Zusatzleistung
                // (kategorie == 101 && PositionStatus == 1);							 // oder graue Einzelzahlung

                // Positionsbuttons untereinander platzieren
                int buttonHeight = btnPositionGrau.Height;
                int topMargin = edtKategorie.Top;

                if (btnPositionGrau.Visible)
                {
                    btnPositionGrau.Top = topMargin;
                    topMargin += buttonHeight + 5;
                }

                if (btnPositionGruen.Visible)
                {
                    btnPositionGruen.Top = topMargin;
                    topMargin += buttonHeight + 5;
                }

                if (btnPositionRot.Visible)
                {
                    btnPositionRot.Top = topMargin;
                    topMargin += buttonHeight + 5;
                }

                if (btnPositionBewilligung.Visible)
                {
                    btnPositionBewilligung.Top = topMargin;
                    topMargin += buttonHeight + 5;
                }

                if (btnPositionVerlauf.Visible)
                {
                    btnPositionVerlauf.Top = topMargin;
                }

                int es = ShUtil.GetCode(qryBgPosition["EinzahlungsscheinCode"]);
                int auszahlungsTermin = ShUtil.GetCode(qryBgPosition["BgAuszahlungsTerminCode"]);
                int auszahlungsArt = ShUtil.GetCode(qryBgPosition["KbAuszahlungsArtCode"]);
                int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
                int ueCount = (int)qryBgBudget["UECount"];

                //Verwendungsperiode + Splitting
                edtVerwPeriodeVon.Visible = !_isMasterbudget;
                edtVerwPeriodeBis.Visible = !_isMasterbudget;
                edtBgSplittingCode.Visible = !_isMasterbudget;
                lblVerwPeriode.Visible = !_isMasterbudget;
                lblVerwPeriodeStrich.Visible = !_isMasterbudget;
                lblBgSplittingCode.Visible = !_isMasterbudget;

                if (!_isMasterbudget)
                {
                    switch (bgSplittingArtCode)
                    {
                        case 1: //Taggenau
                        case 2: //monat
                            edtVerwPeriodeVon.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtVerwPeriodeBis.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                            break;

                        case 4: //Entscheid
                            edtVerwPeriodeVon.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                            break;

                        default:
                            edtVerwPeriodeVon.EditMode = EditModeType.ReadOnly;
                            edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                            break;
                    }
                }

                //Felder Kostenart, Buchungstext,Betrag,Bemerkung
                edtKostenart.EditMode = editable && (_editMask.Gruppe || _editMask.Art || _editMask.GruppeFilter) ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBuchungstext.EditMode = editable && _editMask.Text ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBetragBudget.EditMode = editable && (_editMask.BetragMinus || _editMask.BetragPlus) ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBemerkung.EditMode = editable && _editMask.Bemerkung ? EditModeType.Normal : EditModeType.ReadOnly;

                //Betrifft Person
                try
                {
                    edtBaPersonID.EditMode = editable && _editMask.BetrifftPerson && kategorie != 3 /*Verrechnung*/
                        && !DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && (bool)qryBgPosition["ProPerson"] ? EditModeType.Normal : EditModeType.ReadOnly;
                }
                catch
                {
                    edtBaPersonID.EditMode = EditModeType.ReadOnly;
                }

                //Kategorienabhängige Einstellungen
                switch (kategorie)
                {
                    case 2: //Ausgaben
                    case 100: //Zusatzleistung
                    case 101: //Einzelzahlung
                        edtKbAuszahlungsArtCode.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtBgAuszahlungsTerminCode.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtWochentagCodes.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;

                        edtValutaDatum.EditMode = (auszahlungsTermin == 4) && auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtValutaDatum.Visible = (auszahlungsTermin == 4);
                        edtValutaTermine.Visible = (auszahlungsTermin != 4);
                        edtFaelligAm.Visible = false;
                        lblValutaDatum.Text = "Valuta";
                        lblValutaDatum2.Visible = _isMasterbudget;
                        edtDebitor.Visible = false;
                        lblDebitor.Visible = false;
                        edtReferenzNummer.EditMode = (es == 1) && (auszahlungEditable || auszahlungFehlerhaft) ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtReferenzNummer.Visible = true;
                        lblReferenzNummer.Visible = true;
                        edtVerwaltungSD.Visible = false;
                        btnWeitereZahlinfos.Visible = (qryBgPosition.Row.RowState != DataRowState.Added) && (bool)qryBgPosition["Quoting"] && ueCount > 1;

                        edtRechnungDatum.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtBetragRechnung.EditMode = auszahlungEditable && _editMask.BetragRechnung ? EditModeType.Normal : EditModeType.ReadOnly;

                        edtRechnungDatum.Visible = _verfuegtVisible;
                        edtBetragRechnung.Visible = _verfuegtVisible;
                        lblRechnungDatum.Visible = _verfuegtVisible;
                        lblBetragRechnung.Visible = _verfuegtVisible;
                        lblRechnungCHF.Visible = _verfuegtVisible;

                        edtKreditor.Visible = true;
                        lblKreditor.Visible = true;
                        tpgZahlinfo.Title = lblKreditor.Text;

                        if (auszahlungsArt == 101)  //elektronisch
                        {
                            //Kreditor, ReferenzNr, Mitteilung mutierbar, wenn  PositionStatus = 5 (Zahlauftrag fehlerhaft)
                            edtKreditor.EditMode = (auszahlungEditable || auszahlungFehlerhaft) ? EditModeType.Normal : EditModeType.ReadOnly;
                            tpgMitteilung.HideTab = (es != 2) && (es != 3) && (es != 4) && (es != 5); //roter ES
                            lblMitteilung.Visible = true;
                            lblZahlbarAn.Visible = false;
                            tpgMitteilung.Title = lblMitteilung.Text;
                            edtMitteilungZeile1.EditMode = EditModeType.ReadOnly;
                            edtMitteilungZeile2.EditMode = auszahlungEditable || auszahlungFehlerhaft ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtMitteilungZeile3.Visible = false;
                        }
                        else if (auszahlungsArt == 103) //bar
                        {
                            edtKreditor.EditMode = EditModeType.ReadOnly;
                            tpgMitteilung.HideTab = false;
                            lblMitteilung.Visible = false;
                            lblZahlbarAn.Visible = true;
                            tpgMitteilung.Title = lblZahlbarAn.Text;
                            edtMitteilungZeile1.EditMode = auszahlungEditable || auszahlungFehlerhaft ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtMitteilungZeile2.EditMode = auszahlungEditable || auszahlungFehlerhaft ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtMitteilungZeile3.EditMode = auszahlungEditable || auszahlungFehlerhaft ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtMitteilungZeile3.Visible = true;
                        }

                        tpgKalender.HideTab = (auszahlungsTermin == 4) || (_isMasterbudget && auszahlungsTermin != 6);

                        if (!tpgKalender.HideTab)
                        {
                            if (_isMasterbudget)
                            {
                                edtWochentagCodes.Visible = true;
                                edtCalendar.Visible = false;
                            }
                            else
                            {
                                DateTime firstDate = new DateTime(_budgetJahr, _budgetMonat, 1);
                                switch (auszahlungsTermin)
                                {
                                    case 6:  //Wochentage
                                        edtWochentagCodes.Visible = true;
                                        edtCalendar.Visible = !_isMasterbudget;
                                        edtCalendar.Enabled = false;
                                        edtCalendar.MinDate = firstDate;
                                        edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                        edtCalendar.CalendarDimensions = new Size(1, 1);
                                        edtCalendar.Left = tpgKalender.Width - edtCalendar.Width - 5;
                                        break;

                                    case 5:  //14-täglich
                                        edtWochentagCodes.Visible = false;
                                        edtCalendar.Visible = !_isMasterbudget;
                                        edtCalendar.Enabled = false;
                                        edtCalendar.MinDate = firstDate.AddMonths(-1);
                                        edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                        edtCalendar.CalendarDimensions = new Size(1, 1);
                                        edtCalendar.Left = (tpgKalender.Width - edtCalendar.Width) / 2;
                                        break;

                                    case 99: //individuell
                                        edtWochentagCodes.Visible = false;
                                        edtCalendar.Visible = !_isMasterbudget;
                                        edtCalendar.Enabled = auszahlungEditable;
                                        edtCalendar.MinDate = firstDate.AddMonths(-1);
                                        edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                        edtCalendar.CalendarDimensions = new Size(2, 1);
                                        edtCalendar.Left = (tpgKalender.Width - edtCalendar.Width) / 2;
                                        break;

                                    default:
                                        edtWochentagCodes.Visible = false;
                                        edtCalendar.Visible = !_isMasterbudget;
                                        edtCalendar.Enabled = false;
                                        edtCalendar.MinDate = firstDate.AddMonths(-1);
                                        edtCalendar.MaxDate = firstDate.AddMonths(1).AddDays(-1);
                                        edtCalendar.CalendarDimensions = new Size(2, 1);
                                        edtCalendar.Left = (tpgKalender.Width - edtCalendar.Width) / 2;
                                        break;
                                }
                            }
                        }

                        break;

                    case 1: //Einnahme
                        edtKbAuszahlungsArtCode.EditMode = EditModeType.ReadOnly;
                        edtBgAuszahlungsTerminCode.EditMode = EditModeType.ReadOnly;

                        edtValutaDatum.Visible = false;
                        edtFaelligAm.Visible = true;
                        edtFaelligAm.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtValutaTermine.Visible = false;
                        lblValutaDatum.Text = "Fällig am";
                        lblValutaDatum2.Visible = _isMasterbudget;
                        edtDebitor.Visible = true;
                        edtDebitor.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
                        lblDebitor.Visible = true;
                        edtKreditor.Visible = false;
                        lblKreditor.Visible = false;
                        tpgZahlinfo.Title = lblDebitor.Text;
                        tpgMitteilung.HideTab = true;
                        tpgKalender.HideTab = true;
                        edtReferenzNummer.Visible = false;
                        lblReferenzNummer.Visible = false;
                        edtVerwaltungSD.Visible = true;
                        edtVerwaltungSD.EditMode = auszahlungEditable && !hvtvAufPositionsart ? EditModeType.Normal : EditModeType.ReadOnly;
                        btnWeitereZahlinfos.Visible = false;

                        edtRechnungDatum.Visible = false;
                        lblRechnungDatum.Visible = false;
                        edtBetragRechnung.Visible = false;
                        lblBetragRechnung.Visible = false;
                        lblRechnungCHF.Visible = false;

                        break;

                    case 3: // Abzahlungen
                    case 6: // Vorabzug
                    case 4: //Sanktion/Kürzung
                        edtKostenart.EditMode = EditModeType.ReadOnly;
                        edtKbAuszahlungsArtCode.EditMode = EditModeType.ReadOnly;
                        edtBgAuszahlungsTerminCode.EditMode = EditModeType.ReadOnly;

                        tabZahlinfo.Visible = false;
                        edtRechnungDatum.Visible = false;
                        lblRechnungDatum.Visible = false;
                        edtBetragRechnung.Visible = false;
                        lblBetragRechnung.Visible = false;
                        break;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlWhBudget", "FehlerSetEditMode", "Fehler in SetEditMode: " + ex.Message, null, ex, 0, 0, null);
            }
        }

        private void SetRowFilter()
        {
            string rowFilter = "";

            // Filtere zukünftige Leistungen (nur im Masterbudget)
            if (edtOhneZukuenftigeLeistungen.Checked && _isMasterbudget)
            {
                rowFilter = rowFilter + ((rowFilter == "") ? "" : " AND ")
                                      + "ZukuenftigeLeistung = 0";
            }

            // Filtere Gruppen (aber nur, wenn wir mind. 1 Zeile selektiert haben, siehe auch #4800)
            if (edtOhneGruppen.Checked && qryBgPosition.DataTable.Rows.Count > 0)
            {
                rowFilter = rowFilter + ((rowFilter == "") ? "" : " AND ")
                                      + "Style <> 2";
            }

            qryBgPosition.DataTable.DefaultView.RowFilter = rowFilter;

            // Berechne die Totale der Kategorien und Gruppen neu, falls zukünftige Leistungen im Masterbudget vorhanden sind.
            DataRow kategorieRow = null;
            DataRow gruppeRow = null;
            decimal kategorieTotal = 0;
            decimal gruppeTotal = 0;
            bool modified = qryBgPosition.RowModified;		// Speichere den Zustand

            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if ((bool)row["Kategorie"])
                {
                    if (kategorieRow != null)
                    {
                        kategorieRow["Total"] = kategorieTotal;
                        kategorieRow.AcceptChanges();	// Mantis #4785: Diese Änderung soll nicht zu einem Post() führen (falls der User nur Readonly-Rechte hat)
                    }

                    kategorieRow = row;
                    kategorieTotal = 0;
                }
                else if ((bool)row["Gruppe"])
                {
                    if (gruppeRow != null)
                    {
                        gruppeRow["Total"] = gruppeTotal;
                        gruppeRow.AcceptChanges();	// Mantis #4785: Diese Änderung soll nicht zu einem Post() führen (falls der User nur Readonly-Rechte hat)
                    }

                    gruppeRow = row;
                    gruppeTotal = 0;
                }
                else
                {
                    if (!_isMasterbudget || !((bool)edtOhneZukuenftigeLeistungen.EditValue && (bool)row["ZukuenftigeLeistung"]))
                    {
                        // Dist ist entweder kein Masterbudget, oder zukünftige Leistungen sollen dargestellt werden und es ist eine zukünftige Leistung
                        decimal betrag = (decimal)row["Betrag"] - (decimal)row["Reduktion"];
                        kategorieTotal = kategorieTotal + betrag;
                        gruppeTotal = gruppeTotal + betrag;
                    }
                }
            }

            if (kategorieRow != null)
            {
                kategorieRow["Total"] = kategorieTotal;
                kategorieRow.AcceptChanges();	// Mantis #4785: Diese Änderung soll nicht zu einem Post() führen (falls der User nur Readonly-Rechte hat)
            }
            if (gruppeRow != null)
            {
                gruppeRow["Total"] = gruppeTotal;
                gruppeRow.AcceptChanges();		// Mantis #4785: Diese Änderung soll nicht zu einem Post() führen (falls der User nur Readonly-Rechte hat)
            }

            qryBgPosition.RowModified = modified;		// Mantis #4785: Reset Flag auf den ursprünglichen Zustand

            qryBgPosition.RefreshDisplay();
        }

        private void SetSpezialkonto()
        {
            object bgSpezKontoID = qryBgPosition["BgSpezKontoID"];
            int kategorie = (int)qryBgPosition["BgKategorieCode"];

            switch (kategorie)
            {
                case 2:   //Ausgabe
                case 100: //Zusatzleistung
                    if (!DBUtil.IsEmpty(bgSpezKontoID))
                    {
                        qryBgPosition["KbAuszahlungsartCode"] = DBNull.Value;
                        qryBgPosition["BgAuszahlungsTerminCode"] = DBNull.Value;
                        qryBgPosition["Kreditor"] = DBNull.Value;
                        qryBgPosition["ZusatzInfo"] = DBNull.Value;
                        qryBgPosition["BaZahlungswegID"] = DBNull.Value;
                        qryBgPosition["EinzahlungsscheinCode"] = DBNull.Value;
                        LoadValutaTermine();
                        DisplayValutaTermine();
                        DisplayCalendarBoldDates();
                    }

                    break;

                case 101:  //Einzelzahlung
                    qryBgPosition["BgPositionsartID"] = GetFieldFromSpezkonto(bgSpezKontoID, "BgPositionsartID");
                    qryBgPosition["Kostenart"] = GetFieldFromSpezkonto(bgSpezKontoID, "KOAPositionsart");
                    qryBgPosition["Buchungstext"] = GetFieldFromSpezkonto(bgSpezKontoID, "Text");
                    qryBgPosition["BgSplittingArtCode"] = GetFieldFromSpezkonto(bgSpezKontoID, "BgSplittingArtCode");
                    qryBgPosition["ProPerson"] = GetFieldFromSpezkonto(bgSpezKontoID, "ProPerson");
                    qryBgPosition["ProUE"] = GetFieldFromSpezkonto(bgSpezKontoID, "ProUE");
                    qryBgPosition["BaZahlungswegIDFix"] = GetFieldFromSpezkonto(bgSpezKontoID, "BaZahlungswegIDFix");
                    SetVerwendungsPeriode();

                    object baPersonID = GetFieldFromSpezkonto(bgSpezKontoID, "BaPersonID");
                    if (!DBUtil.IsEmpty(baPersonID))
                    {
                        qryBgPosition["BaPersonID"] = baPersonID;
                    }

                    if (!DBUtil.IsEmpty(qryBgPosition["BaZahlungswegIDFix"])) //Auszahlung an fixe Zahladresse
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

                    //falls Spezialkonto an eine Institution gebunden ist: Zahlweg einrichten
                    object baInstitutionID = GetFieldFromSpezkonto(bgSpezKontoID, "BaInstitutionID");
                    if (!DBUtil.IsEmpty(baInstitutionID))
                    {
                        SqlQuery qry = DBUtil.OpenSQL("SELECT * FROM vwKreditor WHERE BaInstitutionID = {0}", baInstitutionID);
                        if (qry.Count == 1)
                        {
                            qryBgPosition["Kreditor"] = qry["Kreditor"];
                            qryBgPosition["ZusatzInfo"] = qry["ZusatzInfo"];
                            qryBgPosition["BaZahlungswegID"] = qry["BaZahlungswegID"];
                            qryBgPosition["EinzahlungsscheinCode"] = qry["EinzahlungsscheinCode"];

                            if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                            {
                                qryBgPosition["ReferenzNummer"] = DBNull.Value;
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

                    break;
            }
        }

        private void SetTexts()
        {
            colKontoNr.Caption = "LA";
            lblKostenart.Text = "LA/Positionsart";
            edtVerwaltungSD.Text = "Ermächtigung - Einnahmen an SoD";
            colBeleg_PSCDBelegNummer.Caption = "PSCD BelegNr";
        }

        private void SetVerwendungsPeriode()
        {
            if (_isMasterbudget)
            {
                qryBgPosition["VerwPeriodeVon"] = DBNull.Value;
                qryBgPosition["VerwPeriodeBis"] = DBNull.Value;
            }
            else
            {
                int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);
                switch (bgSplittingArtCode)
                {
                    case 1: //Taggenau
                    case 2: //Monat
                        DateTime firstDate = new DateTime((int)qryBgBudget["Jahr"], (int)qryBgBudget["Monat"], 1);
                        qryBgPosition["VerwPeriodeVon"] = firstDate;
                        qryBgPosition["VerwPeriodeBis"] = firstDate.AddMonths(1).AddDays(-1);
                        break;

                    case 3: //Valuta
                    case 4: //Entscheid
                        qryBgPosition["VerwPeriodeVon"] = DBNull.Value;
                        qryBgPosition["VerwPeriodeBis"] = DBNull.Value;
                        break;
                }
            }
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

        #region Nested Types

        private class BgEditMask
        {
            #region Fields

            #region Public Fields

            public bool Art;
            public bool Bemerkung;
            public bool BetragMinus;
            public bool BetragPlus;
            public bool BetragRechnung;
            public bool BetrifftPerson;
            public bool Gruppe;
            public bool GruppeFilter;
            public bool Loeschen;
            public bool Neu;
            public bool Text;

            #endregion Public Fields

            #endregion Fields
        }

        #endregion Nested Types
    }
}