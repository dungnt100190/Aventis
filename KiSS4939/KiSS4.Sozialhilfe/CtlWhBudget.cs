using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Klientenbuchhaltung.BL;
using KiSS4.Messages;

namespace KiSS4.Sozialhilfe
{
    public partial class CtlWhBudget : KissUserControl, IBelegleser
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CtlWhBudget";
        private readonly int _bgBudgetId;
        private readonly int _budgetJahr = 1900;
        private readonly int _budgetMonat = 1;
        private readonly BgEditMask _editMask = new BgEditMask();
        private readonly int _ezStandardAuszahlungsart = DBUtil.GetConfigInt(@"System\Sozialhilfe\EZStandardAuszahlungsart", Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.ElAuszahlung)); // default auszahlungsart (101=El.Ausz.||106=Papierverf.; 106=SIL-Antrag)
        private readonly int _faLeistungId;
        private readonly Hashtable _htBackColor = new Hashtable();
        private readonly bool _isMasterbudget = true;

        // the classname of the control

        #endregion

        #region Private Fields

        private int? _bgSpezkontoIdToUpdate;
        private bool _calendarFilling;
        private string _editMaskInfo;
        private bool _kreditorUpdated;
        private int _newBgKategorieCode;
        private bool _noRefresh;
        private bool _pendingZahlwegUpdate;
        private bool _refreshing;
        private bool _valutaUpdated;
        private bool _verfuegtVisible;

        #endregion

        #endregion

        #region Constructors

        public CtlWhBudget(int bgBudgetId)
            : this()
        {
            _bgBudgetId = bgBudgetId;

            qryBgBudget.Fill(_bgBudgetId);

            if (qryBgBudget.Count > 0)
            {
                _faLeistungId = (int)qryBgBudget["FaLeistungID"];
                _isMasterbudget = (bool)qryBgBudget["Masterbudget"];

                if (!_isMasterbudget)
                {
                    _budgetJahr = (int)qryBgBudget["Jahr"];
                    _budgetMonat = (int)qryBgBudget["Monat"];
                }
            }

            lblDebitor.Location = lblKreditor.Location;
            edtDebitor.Location = edtKreditor.Location;
            edtValutaTermine.Location = edtValutaDatum.Location;
            edtFaelligAm.Location = edtValutaDatum.Location;

            edtVerwaltungSD.Left = edtReferenzNummer.Left - 2;
            edtVerwaltungSD.Top = edtReferenzNummer.Top + 15;

            lblZahlbarAn.Location = lblMitteilung.Location;

            repositoryItemPictureEdit1.NullText = " ";

            lblBgPositionID.Visible = true;

            colBeleg_Hauptvorgang.Visible = false;
            colBeleg_Teilvorgang.Visible = false;

            btnPositionGrau.Location = btnPositionGruen.Location;
            btnBudgetGrau.Location = btnBudgetGruen.Location;

            edtReferenzNummer.RightToLeft = RightToLeft.No;

            pnlButtonsStatus.Visible = !_isMasterbudget;

            edtBaPersonID.LoadQuery(DBUtil.OpenSQL(@"
                select Code = FPP.BaPersonID, Text = PRS.NameVorname
                from   BgFinanzPlan_BaPerson FPP
                       inner join vwPerson PRS on PRS.BaPersonID = FPP.BaPersoNID
                where  BgFinanzplanID = {0} and
                       IstUnterstuetzt = 1
                order by PRS.NameVorname", qryBgBudget["BgFinanzplanID"]));

            qryBgAuszahlungPersonTermin.Fill("select top 0 * from BgAuszahlungPersonTermin");

            qryBgPosition.Fill(_bgBudgetId);
            SetPositionEditMode();
            SetBudgetEditMode();

            grdBgPosition.Focus();
            SetTexts();
        }

        public CtlWhBudget(Image titleImage, string titelText, int bgBudgetId)
            : this(bgBudgetId)
        {
            picTitel.Image = titleImage;
            lblTitel.Text = titelText;
        }

        public CtlWhBudget()
        {
            InitializeComponent();

            string[] colorCodes = DBUtil.GetConfigString(@"System\Sozialhilfe\BudgetFarben", "").Split(',');
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

        #endregion

        #region EventHandlers

        private void btnBudgetGrau_Click(object sender, EventArgs e)
        {
            //prüfen, ob grau stellen immer noch erlaubt
            qryBgPosition.Refresh();
            qryBgBudget.Refresh();
            SetBudgetEditMode();
            SetPositionEditMode();

            if (!btnBudgetGrau.Visible)
                return;

            int budgetStatus = (int)qryBgBudget["BgBewilligungStatusCode"];
            if (budgetStatus != 5)
                return;

            // Budget kann nicht grau gestellt werden wenn eine grüne Buchung mit einer BelegNr vorhanden ist
            if (HasGrueneBuchungMitBelegNr(null))
            {
                KissMsg.ShowInfo(
                    Name,
                    "BudgetHatGrueneBuchungMitBelegNrVorhanden",
                    "Das Budget kann nicht grau gestellt werden weil mindestens eine Position bereits eine Buchung mit BelegNr hat." + Environment.NewLine +
                        "Diese Positionen können in der Maske SH-Auszahlung graugestellt werden.");
                return;
            }

            // grünes Budget auf grau stellen
            Session.BeginTransaction();
            try
            {
                int cntBeleg = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                    -- NettoBuchungen
                    DELETE BUK
                    FROM KbBuchungKostenart BUK
                      INNER JOIN BgPosition POS ON POS.BgPositionID = BUK.BgPositionID
                    WHERE POS.BgBudgetID = {0}

                    DELETE KbBuchung
                    WHERE BgBudgetID = {0}

                    SELECT @@ROWCOUNT",
                    _bgBudgetId);

                // Eintrag Bewilligungsverlauf
                SqlQuery qry = ShUtil.GetBgBewilligung_Neu();
                qry["BgBudgetID"] = _bgBudgetId;
                qry["BgBewilligungCode"] = 102; // Monatsbudget zur Bearbeitung freigegeben
                qry["Bemerkung"] = string.Format("Es wurden alle {0} Belege gelöscht", cntBeleg);
                qry.Post();

                DBUtil.ExecSQLThrowingException(@"update BgBudget
                        set    BgBewilligungStatusCode = 1
                        where  BgBudgetID = {0}",
                        _bgBudgetId);

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

            qryBgBudget.Fill(_bgBudgetId);

            qryBgPosition.Refresh();
            SetBudgetEditMode();
            SetPositionEditMode();

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            KissMsg.ShowInfo("Das Monatsbudget ist in Vorbereitung\r\n - Es kann bearbeitet werden\r\n - Alle Auszahlungen sind gesperrt");
        }

        private void btnBudgetGruen_Click(object sender, EventArgs e)
        {
            // Sozialhilfe: Monatsbudget darf zur Zahlung freigegeben werden
            if (!(bool)DBUtil.GetUserPermission(Permission.Sh_Monatsbudget_Freigeben, (int)qryBgBudget["FaLeistungID"], false))
            {
                KissMsg.ShowInfo("CtlWhBudget", "KeineBefugnis", "Sie haben nicht die Befugnis, ein Monatsbudget zur Zahlung freizugeben");
                return;
            }

            if (!qryBgPosition.Post())
                return;

            Session.BeginTransaction();
            try
            {
                int budgetStatus = (int)qryBgBudget["BgBewilligungStatusCode"];

                // Eintrag Bewilligungsverlauf
                int cntBeleg;
                SqlQuery qry = ShUtil.GetBgBewilligung_Neu();
                qry["BgBudgetID"] = _bgBudgetId;
                qry["BgBewilligungCode"] = 103; // Monatsbudget zur Bearbeitung freigegeben

                if (budgetStatus == (int)BgBewilligungStatus.Gesperrt)
                {
                    // rot -> grün
                    // gesperrte Belege freigeben
                    cntBeleg = DBUtil.ExecSQLThrowingException(@"
                        UPDATE KbBuchung
                        SET    KbBuchungStatusCode = 2 /*freigegeben*/
                        WHERE  BgBudgetID = {0} AND KbBuchungTypCode IN (1,2) AND KbBuchungStatusCode = 7 /*gesperrt*/ AND BelegNr IS NULL", _bgBudgetId);
                    DBUtil.ExecuteScalarSQLThrowingException(@"UPDATE BgBudget SET BgBewilligungStatusCode = 5 /* ersteilt */ WHERE BgBudgetID = {0}", _bgBudgetId);
                    qry["Bemerkung"] = string.Format("Es wurden {0} gesperrte Belege zur Zahlung freigegeben", cntBeleg);
                }
                else if (budgetStatus == (int)BgBewilligungStatus.Erteilt)
                {
                    // nop;
                }
                else if (budgetStatus == (int)BgBewilligungStatus.InVorbereitung)
                {
                    // grau -> grün
                    // Budget auf grün stellen
                    DBUtil.ExecSQLThrowingException("EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0", _bgBudgetId, Session.User.UserID);

                    cntBeleg = (int)DBUtil.ExecuteScalarSQL(@"SELECT COUNT(1) FROM KbBuchung WHERE BgBudgetID = {0}", _bgBudgetId);
                    qry["Bemerkung"] = string.Format("Es wurden {0} Belege zur Zahlung freigegeben", cntBeleg);
                }

                //qryBgBudget["BgBewilligungStatusCode"] = BgBewilligungStatus.Erteilt;
                //qryBgBudget.Post();
                qryBgBudget.Fill(_bgBudgetId);

                qryBgPosition.Refresh();
                SetBudgetEditMode();
                SetPositionEditMode();

                // Eintrag Bewilligungsverlauf speichern
                qry.Post();

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

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");

            KissMsg.ShowInfo("Das Monatsbudget ist zur Zahlung freigegeben\r\n- Es kann nicht bearbeitet werden\r\n- Auszahlung sind möglich");
        }

        private void btnBudgetNeu_Click(object sender, EventArgs e)
        {
            if (!OnSaveData())
                return;

            Session.BeginTransaction();
            try
            {
                int bgFinanzplanId = (int)qryBgBudget["BgFinanzplanID"];
                object bgBudgetId = DBUtil.ExecuteScalarSQL(@"EXECUTE spWhBudget_Create {0}", bgFinanzplanId);

                if (DBUtil.IsEmpty(bgBudgetId))
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlWhBudget", "EnthaeltAlleBudgets",
                                                                     "Der Finanzplan enthält bereits sämtliche Monatsbudgets",
                                                                     KissMsgCode.MsgInfo));
                }

                // W-Navigator refresh und positionieren auf neuem Budget
                int fallBaPersonId = (int)qryBgBudget["FallBaPersonID"];

                FormController.SendMessage("FrmFall", "Action", "RefreshTree");

                FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                    "BaPersonID", fallBaPersonId,
                    "ModulID", 3,
                    "FieldValue", string.Format("CtlWhFinanzplan{0}\\BBG{1}", bgFinanzplanId, bgBudgetId));

                // Eintrag Bewilligungsverlauf
                SqlQuery qry = ShUtil.GetBgBewilligung_Neu();
                qry["BgBewilligungCode"] = 101;
                qry["BgBudgetID"] = (int)bgBudgetId;
                qry.Post();

                Session.Commit();
            }
            catch (KissCancelException ex0)
            {
                Session.Rollback();
                ex0.ShowMessage();
            }
            catch (Exception ex1)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex1.Message);
            }
        }

        private void btnBudgetReset_Click(object sender, EventArgs e)
        {
            bool masterBudget = (bool)qryBgBudget["MasterBudget"];
            int bgBewilligungStatusCode = (int)qryBgBudget["BgBewilligungStatusCode"];

            if (bgBewilligungStatusCode < (int)BgBewilligungStatus.Erteilt
                || (masterBudget && bgBewilligungStatusCode == (int)BgBewilligungStatus.Erteilt))
            {
                if (KissMsg.ShowQuestion("Soll dieses Monatsbudget an das Masterbudget angepasst werden?"))
                {
                    DBUtil.ExecSQL(120, "EXECUTE spWhBudget_Reset {0}, {1}"
                        , qryBgBudget["BgFinanzplanID"], _bgBudgetId);
                    qryBgPosition.Refresh();
                    SetPositionEditMode();
                }
            }
            else if (masterBudget)
            {
                KissMsg.ShowInfo("CtlWhBudget", "MasterbudgetGesperrt", "Ein Masterbudget kann nicht zurückgesetzt werden");
            }
            else
            {
                KissMsg.ShowInfo("CtlWhBudget", "MonatsbudgetGesperrt", "Ein grünes/rotes Monatsbudget kann nicht zurückgesetzt werden");
            }
        }

        private void btnBudgetRot_Click(object sender, EventArgs e)
        {
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

                if (bewilligungCode != 5)
                {
                    return;
                }

                // alle grünen Buchungen auf rot stellen
                int cntBeleg = DBUtil.ExecSQLThrowingException(@"
                UPDATE BUC
                  SET    KbBuchungStatusCode = 7
                FROM KbBuchung                  BUC
                  INNER JOIN KbBuchungKostenart BUK ON BUK.KbBuchungID = BUC.KbBuchungID
                  INNER JOIN BgPosition         BPO ON BPO.BgPositionID = BUK.BgPositionID
                                                   AND BPO.BgKategorieCode in (2,3,100,101)
                WHERE BUC.BgBudgetID = {0}
                  AND BUC.KbBuchungStatusCode = 2
                  AND BUC.KbBuchungTypCode in (1,2)
                  AND BUC.BelegNr is null",
                                                               qryBgBudget["BgBudgetID"]);

                qryBgPosition.Refresh();
                SetPositionEditMode();

                SqlQuery qry = ShUtil.GetBgBewilligung_Neu();
                qry["BgBudgetID"] = _bgBudgetId;
                qry["BgBewilligungCode"] = 105; // Monatsbudget per sofort blockiert
                qry["Bemerkung"] = string.Format("Es wurden {0} nicht verbuchte Belege gesperrt", cntBeleg);
                qry.Post();
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
            qryBgBudget.Fill(_bgBudgetId);

            qryBgPosition.Refresh();
            SetPositionEditMode();

            FormController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void btnBudgetVerlauf_Click(object sender, EventArgs e)
        {
            DlgWhBudgetVerlauf dlg = new DlgWhBudgetVerlauf(_bgBudgetId);
            dlg.ShowDialog(this);
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
            PositionBewilligung();
        }

        private void btnPositionGrau_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
                return;
            try
            {
                if (_isMasterbudget)
                    return;

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

                // Position kann nicht grau gestellt werden wenn eine grüne Buchung mit einer BelegNr vorhanden ist
                if (HasGrueneBuchungMitBelegNr(qryBgPosition[DBO.BgPosition.BgPositionID] as int?))
                {
                    KissMsg.ShowInfo(
                        Name,
                        "PositionHatGrueneBuchungMitBelegNrVorhanden",
                        "Die Position kann nicht grau gestellt werden weil diese Position bereits eine Buchung mit BelegNr hat." + Environment.NewLine +
                            "Diese Position kann in der Maske SH-Auszahlung graugestellt werden.");
                    return;
                }

                // grüne oder "Zahlauftrag fehlerhaft" Position auf grau stellen
                Session.BeginTransaction();
                try
                {
                    //Nettobuchungen löschen
                    DBUtil.ExecSQLThrowingException(@"
                    declare @KbBuchungIDList table (KbBuchungID int)

                    insert @KbBuchungIDList
                    select distinct BUK.KbBuchungID
                    from   KbBuchungKostenart BUK
                           inner join KbBuchung BUC on BUC.KbBuchungID = BUK.KbBuchungID
                    where  BUK.BgPositionID = {0} and
                           BUC.KbBuchungStatusCode in (2,5)

                    delete KbBuchungKostenart
                    where  KbBuchungID in (select KbBuchungID from @KbBuchungIDList)

                    delete KbBuchung
                    where  KbBuchungID in (select KbBuchungID from @KbBuchungIDList)",
                        qryBgPosition["BgPositionID"]);

                    Session.Commit();
                }
                catch (Exception)
                {
                    Session.Rollback();
                    throw;
                }

                qryBgPosition.Refresh();
                SetPositionEditMode();
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

        private void btnPositionGruen_Click(object sender, EventArgs e)
        {
            PositionGruenStellen();
        }

        private void btnPositionRot_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
                return;
            try
            {
                if (_isMasterbudget)
                    return;

                int bewilligungCode = (int)qryBgBudget["BgBewilligungStatusCode"];

                if (bewilligungCode != 5)
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
                    Update BUC
                    set    KbBuchungStatusCode = 7
                    from   KbBuchung BUC
                           inner join KbBuchungKostenart BUK on BUK.KbBuchungID = BUC.KbBuchungID
                    where  BUK.BgPositionID = {0} and
                           BUC.KbBuchungStatusCode = 2",
                    qryBgPosition["BgPositionID"]);

                    qryBgPosition.Refresh();
                    SetPositionEditMode();
                }
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
        }

        private void btnSpezialkonto_Click(object sender, EventArgs e)
        {
            return;

            /*
            KissLookupDialog dlg = new KissLookupDialog();
            bool cancel = !dlg.SearchData(@"
              SELECT Code$ = 1, Text = 'neues Ausgabekonto erstellen'
              UNION SELECT 3, 'neues Verrechnungskonto erstellen'
              UNION SELECT 2, 'neues Vorabzugkonto erstellen'",
              "",
              true,null,null,null);

            if (cancel) return;

            int Code = (int) dlg["Code$"];
            KiSS4.Sozialhilfe.BgSpezkontoTyp b = (KiSS4.Sozialhilfe.BgSpezkontoTyp) Code;

            CtlWhSpezialkonto ctlSpezialkonto = new CtlWhSpezialkonto(b,
                                                                        FaLeistungID,
                                                                        edtBuchungstext.EditValue,
                                                                        null,
                                                                        null);

            DlgKissUserControl dlg2 = new DlgKissUserControl(dlg["Text"].ToString(), ctlSpezialkonto);

            dlg2.ShowDialog();
            if (dlg2.UserCancel) return;

            LoadSpezialkonto(null);

            qryBgPosition["BgSpezkontoID"] = ctlSpezialkonto.ActiveSQLQuery["BgSpezkontoID"];
            SetSpezialkonto();
            SetPositionEditMode();
            */
        }

        private void btnWeitereZahlinfos_Click(object sender, EventArgs e)
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            bool canEdit = (Utils.ConvertToInt(qryBgPosition["Status"]) == 1 || Utils.ConvertToBool(qryBgBudget["MasterBudget"], false));
            DlgWhWeitereZahlinfo dlg = new DlgWhWeitereZahlinfo((int)qryBgPosition["BgPositionID"], !canEdit);
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                qryBgPosition.Refresh();
                SetPositionEditMode();
            }
        }

        private void btnZusatzleistung_Click(object sender, EventArgs e)
        {
            NeuePosition(100);
        }

        private void CtlWhBudget_Load(object sender, EventArgs e)
        {
            qryBgPosition.PostCompleted += qryBgPosition_PostCompleted;
            edtCalendar.DateChanged += edtCalendar_DateChanged;
            tmrTimer.Tick += tmrTimer_Tick;

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
            toolTip1.SetToolTip(lblBgBudgetID, KissMsg.GetMLMessage(Name, "ToolTipBudgetIDToClipboard", "Budget-ID, Doppelklick kopiert ID in den Zwischenspeicher"));
            toolTip1.SetToolTip(lblBgPositionID, KissMsg.GetMLMessage(Name, "ToolTipPositionIDToClipboard", "Position-ID, Doppelklick kopiert ID in den Zwischenspeicher"));

            tabBgPosition.SelectedTabIndex = 0;
            tabZahlinfo.SelectedTabIndex = 0;
        }

        private void edtBaPersonID_EditValueChanged(object sender, EventArgs e)
        {
            //#7508, Beim Löschen einer Einnahme ist unter Umständen der RowState
            //RowState.Detached. Dann kann man die Werte aus der Row nicht mehr auslesen.
            //qryBgPosition["BgKostenartID"] erzeugt eine Exception.
            if (!qryBgPosition.IsEmpty && qryBgPosition.Row.RowState != DataRowState.Detached)
            {
                LoadSpezialkonto(qryBgPosition["BgKostenartID"], edtBaPersonID.EditValue);
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
                return;
            if (!edtBgAuszahlungsTerminCode.Focused)
                return;

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
            if (kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen || kategorie == (int)LOV.BgKategorieCode.Ausgaben)
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
                return;
            if (!edtBgSpezkontoID.Focused)
                return;

            qryBgPosition["BgSpezKontoID"] = edtBgSpezkontoID.EditValue;
            if (DBUtil.IsEmpty(edtBgSpezkontoID.EditValue))
                qryBgPosition["Status"] = 1; //grau

            SetSpezialkonto();
            SetPositionEditMode();
        }

        private void edtBuchungstext_Enter(object sender, EventArgs e)
        {
            edtBuchungstext.SelectAll();
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
            tmrTimer.Enabled = true;
        }

        private void edtDebitor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = AuswahlDebitor(edtDebitor.EditValue.ToString(), e.ButtonClicked);
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
            if (kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen || kategorie == (int)LOV.BgKategorieCode.Ausgaben)
            {
                qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                qryBgPosition["Status"] = 1; //grau
            }

            SetPositionEditMode();

            SqlQuery qry = DBUtil.OpenSQL(@"
                select VornameName,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                from   vwPerson
                where  BaPersonID = {0}",
                qryBgBudget["LeistungBaPersonID"]);

            int auszahlungsArt = (int)qryBgPosition["KbAuszahlungsArtCode"];
            switch (auszahlungsArt)
            {
                case 101:
                    qryBgPosition["MitteilungZeile1"] = TruncateString(qry["VornameName"], 35);
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
                    qryBgPosition[DBO.BgPosition.BgPositionsartID] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    return;
                }
            }

            if (_editMask.GruppeFilter && e.ButtonClicked)
                searchString = "%";

            string oldBgPositionsArtId = qryBgPosition[DBO.BgPosition.BgPositionsartID].ToString();

            KissLookupDialog dlg = new KissLookupDialog();

            DateTime budgetMonatVon = new DateTime((int)qryBgBudget["Jahr"], (int)qryBgBudget["Monat"], 1);
            DateTime budgetMonatBis = new DateTime((int)qryBgBudget["Jahr"], (int)qryBgBudget["Monat"], 1).AddMonths(1).AddDays(-1);    // To get the last day of the month, Add one month and subtract one day

            string sql = string.Format(@"
                SELECT KOA                     = BKA.KontoNr,
                       Positionsart            = BPA.Name,
                       Gruppe                  = GRP.Text,
                       BgKostenartID$          = BKA.BgKostenartID,
                       BgPositionsartID$       = BPA.BgPositionsartID,
                       ProPerson$              = BPA.ProPerson,
                       ProUE$                  = BPA.ProUE,
                       KOAPositionsart$        = BKA.KontoNr + ' '+ BPA.Name,
                       Name$                   = BPA.Name,
                       BgSplittingArtCode$     = BKA.BgSplittingArtCode,
                       sqlRichtlinie$          = BPA.sqlRichtlinie,
                       GruppeFilter$           = convert(varchar(50),GRP.Value3),
                       KreditorEingeschraenkt$ = BPA.KreditorEingeschraenkt,
                       VerwaltungSD_Default$   = ISNULL(BPA.VerwaltungSD_Default, 0)
                FROM   WhPositionsart BPA
                       inner join BgKostenart BKA on BKA.BgKostenartID = BPA.BgKostenartID
                       left  join XLOVCode    GRP on GRP.LOVName = 'BgGruppe' AND GRP.Code = BPA.BgGruppeCode
                WHERE  BgKategorieCode = {1} AND
                        ISNULL(BPA.DatumVon, '1900-01-01') <= '{2}' AND ISNULL(BPA.DatumBis, '2999-12-31') >= '{3}' AND
                       (BPA.Name like '%{0}%' or
                        BKA.KontoNr like '{0}%') ",
                 searchString, qryBgPosition[DBO.BgPosition.BgKategorieCode], budgetMonatVon.ToString("yyyy-MM-dd"), budgetMonatBis.ToString("yyyy-MM-dd"));

            if (_editMask.GruppeFilter)
            {
                sql += " and convert(varchar(50),GRP.Value3) = '" + qryBgPosition["GruppeFilter"] + "' ";
            }
            else if (!_editMask.Gruppe)
            {
                sql += " AND BPA.BgGruppeCode = " + DBUtil.SqlLiteral(qryBgPosition["BgGruppeCode"]);
            }

            sql += " order by 1,2";

            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                qryBgPosition[DBO.BgPosition.BgPositionsartID] = dlg["BgPositionsartID$"];
                qryBgPosition["BgKostenartID"] = dlg["BgKostenartID$"];
                qryBgPosition["Kostenart"] = dlg["KOAPositionsart$"];
                qryBgPosition["Buchungstext"] = dlg["Name$"];
                qryBgPosition["BgSplittingArtCode"] = dlg["BgSplittingArtCode$"];
                qryBgPosition["ProPerson"] = dlg["ProPerson$"];
                qryBgPosition["ProUE"] = dlg["ProUE$"];
                qryBgPosition["GruppeFilter"] = dlg["GruppeFilter$"];
                qryBgPosition["KreditorEingeschraenkt"] = dlg["KreditorEingeschraenkt$"];
                qryBgPosition["VerwaltungSD"] = dlg["VerwaltungSD_Default$"];

                bool proPerson = (bool)qryBgPosition["ProPerson"];
                bool proUe = (bool)qryBgPosition["ProUE"];

                if (proUe && !proPerson)
                    qryBgPosition["BaPersonID"] = null;

                SetVerwendungsPeriode();

                SqlQuery qry = ShUtil.GetRichtlinie(dlg["sqlRichtlinie$"], _bgBudgetId);
                if (qry.Count == 1)
                {
                    if (DBUtil.IsEmpty(qryBgPosition["BaPersonID"]))
                        qryBgPosition["BetragBudget"] = DBUtil.IsEmpty(qry["UE_DEF"]) ? qry["UE_MIN"] : qry["UE_DEF"];
                    else
                        qryBgPosition["BetragBudget"] = DBUtil.IsEmpty(qry["PR_DEF"]) ? qry["PR_MIN"] : qry["PR_DEF"];
                }

                int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
                if (kategorie == (int)LOV.BgKategorieCode.Ausgaben || kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen)  //Ausgabe, Zusätzliche Leistung
                {
                    if (oldBgPositionsArtId != qryBgPosition[DBO.BgPosition.BgPositionsartID].ToString())
                    {
                        qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                    }

                    LoadSpezialkonto(dlg["BgKostenartID$"], qryBgPosition["BaPersonID"]);
                }
                SetPositionEditMode();
            }
        }

        private void edtKreditor_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            e.Cancel = AuswahlKreditor(edtKreditor.EditValue.ToString(), e.ButtonClicked);
        }

        private void edtOhneGruppen_Click(object sender, EventArgs e)
        {
            qryBgPosition.DataTable.DefaultView.RowFilter = edtOhneGruppen.Checked ? "" : "Style <> 2";
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

        private void lblBgBudgetID_DoubleClick(object sender, EventArgs e)
        {
            CopyIdToClipboard(ref qryBgBudget, DBO.BgBudget.BgBudgetID);
        }

        private void lblBgPositionID_DoubleClick(object sender, EventArgs e)
        {
            CopyIdToClipboard(ref qryBgPosition, DBO.BgPosition.BgPositionID);
        }

        private void qryBgDokumente_AfterInsert(object sender, EventArgs e)
        {
            qryBgDokumente["BgDokumentTypCode"] = 1;
            qryBgDokumente["Stichwort"] = qryBgPosition["Kostenart"];

            edtDokumentTyp.Focus();
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
            }

            if (DBUtil.IsEmpty(qryBgDokumente["Stichwort"]))
                qryBgDokumente["Stichwort"] = "-";
        }

        private void qryBgDokumente_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            qryBgPosition.RowModified = true;
        }

        private void qryBgPosition_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();

            qryBgPosition.Refresh();
            SetPositionEditMode();
        }

        private void qryBgPosition_AfterInsert(object sender, EventArgs e)
        {
            qryBgPosition["Kategorie"] = 0;
            qryBgPosition["Gruppe"] = 0;
            qryBgPosition["BgKategorieCode"] = _newBgKategorieCode;
            qryBgPosition["BgBudgetID"] = _bgBudgetId;
            qryBgPosition["Doc"] = false;
            qryBgPosition["Status"] = 1; //grau
            qryBgPosition["BgBewilligungStatusCode"] = 1; //grau
            qryBgPosition["Quoting"] = false;
            qryBgPosition["Style"] = _newBgKategorieCode * 10 + 1;
            qryBgPosition["ProPerson"] = false;
            qryBgPosition["ProUE"] = true;
            qryBgPosition["VerwaltungSD"] = false;

            KlibuEnvironment kliBuEnvironment = KlibuEnvironmentFactory.CreateKlibuEnvironment();

            int budgetStatus = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);

            switch (_newBgKategorieCode)
            {
                case (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen: //Zusatzleistung
                    if (_ezStandardAuszahlungsart == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.Papierverfuegung))
                    {
                        qryBgPosition["KbAuszahlungsArtCode"] = 102; //Kreditor, über Papierverfügung zur Buchhaltung
                    }
                    else
                    {
                        qryBgPosition["KbAuszahlungsArtCode"] = 101; //elektronisch
                    }

                    qryBgPosition["BgAuszahlungsTerminCode"] = 1; //1xmonatlich
                    LoadSpezialkonto(null, null); //keine Auswahl, solange keine KOA ausgewählt ist
                    LoadValutaTermine();
                    DisplayCalendarBoldDates();
                    break;

                case (int)LOV.BgKategorieCode.Einzelzahlungen: //Einzelzahlung
                    if (_ezStandardAuszahlungsart == Convert.ToInt32(CtlWhAuszahlungen.KbAuszahlungsArt.Papierverfuegung))
                    {
                        qryBgPosition["KbAuszahlungsArtCode"] = 102; //Kreditor, über Papierverfügung zur Buchhaltung
                    }
                    else
                    {
                        qryBgPosition["KbAuszahlungsArtCode"] = 101; //elektronisch
                    }

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

                case (int)LOV.BgKategorieCode.Einnahmen: //Einnahmen

                    qryBgPosition["BgAuszahlungsTerminCode"] = 4; //Valuta
                    LoadSpezialkonto(null, null);

                    if ((budgetStatus == 5) && !_isMasterbudget)
                    {
                        qryBgPosition["VerwaltungSD"] = true;  //nur noch abgetretene Einnahmen im grünen Monatsbudget
                    }
                    break;

                case (int)LOV.BgKategorieCode.Kuerzungen: // Sanktion (ZH) / Kürzung (BSS)
                    LoadSpezialkonto(null, null);
                    qryBgPosition["Kostenart"] = GetFieldFromSpezkonto(null, "KOAPositionsart"); //Grundbedarf
                    qryBgPosition["BgSplittingArtCode"] = GetFieldFromSpezkonto(null, "BgSplittingArtCode"); //Splitting des Grundbedarfs
                    if (!_isMasterbudget)
                    {
                        SetVerwendungsPeriode();
                    }
                    break;
            }

            _newBgKategorieCode = 0;
            tabBgPosition.SelectedTabIndex = 0;
            SetPositionEditMode();

            ctlErfassungMutation.ShowInfo();

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
            //Da weiter unten in dieser Methode ein Dialog angezeigt wird, müssen wir bereits hier committen
            if (Session.Transaction != null)
            {
                Session.Commit();
            }

            bool gruppierung = (bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"];
            if (!gruppierung)
            {
                //Valuta-Termine speichern
                SaveValutaTermine();

                // bewilligte, graue Zusatzleistung auf grün stellen im grünen Monatsbudget
                int budgetBewilligung = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);
                int positionBewilligung = ShUtil.GetCode(qryBgPosition["BgBewilligungStatusCode"]);
                int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

                if ((kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen || kategorie == (int)LOV.BgKategorieCode.Einzelzahlungen) && positionBewilligung == 5 && budgetBewilligung == 5)
                {
                    DBUtil.ExecSQL(@"
                        EXECUTE spWhBudget_CreateKbBuchung {0}, {1}, 0, null, {2}",
                        _bgBudgetId,
                        Session.User.UserID,
                        kategorie == (int)LOV.BgKategorieCode.Einzelzahlungen && !DBUtil.IsEmpty(qryBgPosition["BgPositionID_Parent"]) ? qryBgPosition["BgPositionID_Parent"] : qryBgPosition["BgPositionID"]);
                }
                else if (kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen && positionBewilligung == 1)
                {
                    DlgInfo.Show("Diese Einzelzahlung ist bewilligungspflichtig" +
                        "\r\n\r\nSie müssen deshalb die Einzelzahlung bewilligen lassen, bevor sie ausbezahlt werden kann!", 0, 0);
                }
                else if (_bgSpezkontoIdToUpdate.HasValue && (kategorie == (int)LOV.BgKategorieCode.Abzahlung || kategorie == (int)LOV.BgKategorieCode.Kuerzungen))
                {
                    DBUtil.ExecSQL("EXECUTE spWhSpezkonto_UpdateBudget {0}", _bgSpezkontoIdToUpdate.Value);
                    _bgSpezkontoIdToUpdate = null;
                }

                //Zahlinfo in KbBuchungung updaten, falls Status = ZahlungFehlerhaft und veränderter Zahlinfo
                if (_pendingZahlwegUpdate)
                {
                    DBUtil.ExecSQL(@"
                        EXECUTE spWhBudget_UpdateKbBuchungZahlInfo {0}, {1}",
                        qryBgPosition["BgPositionID"],
                        Session.User.UserID);

                    _pendingZahlwegUpdate = false;
                }

                // Zahlinfo in abhängigen Positionen updaten (z.B. Kreditor Miete geändert -> bei Nebenkosten nachtragen
                if ((_kreditorUpdated || _valutaUpdated) &&
                    //qryBgPosition["DetailPos"] as string == "*" && // Hauptposition
                    qryBgPosition["BgGruppeCode"] as int? == 3206) // Nur Infos von Miete auf Nebenkosten übertragen
                {
                    DBUtil.ExecSQL(@"EXEC spWhBudgetSyncDependentKreditorAndValuta {0}", qryBgPosition["BgPositionID"]);
                    _kreditorUpdated = false;
                    _valutaUpdated = false;
                }
            }

            if (!qryBgDokumente.Post())
            {
                tabBgPosition.SelectedTabIndex = 1;
                throw new KissCancelException();
            }
        }

        private void qryBgPosition_BeforeDelete(object sender, EventArgs e)
        {
            if (_isMasterbudget && DBUtil.IsEmpty(qryBgPosition["DatumVon"]))
            {
                //DatumBis auf '01.01.1900' setzen auf Finanzplan-Positionen (Parent+Child)
                DBUtil.ExecSQLThrowingException(@"
                        UPDATE BgPosition
                        SET DatumBis = {1}
                        WHERE BgPositionID = {0}
                          OR BgPositionID_Parent = {0};"
                    , qryBgPosition["BgPositionID"]
                    , new DateTime(1900, 1, 1));

                qryBgPosition.Refresh();
                SetPositionEditMode();

                throw new KissCancelException();
            }

            Session.BeginTransaction();

            DBUtil.ExecSQL(@"
                delete TRM
                from   BgAuszahlungPersonTermin TRM
                       inner join BgAuszahlungPerson AUS on AUS.BgAuszahlungPersonID = TRM.BgAuszahlungPersonID
                where AUS.BgPositionID = {0}

                delete BgAuszahlungPerson where BgPositionID = {0}

                delete BgPosition where BgPositionID_Parent = {0}

                delete BgDokument where BgPositionID = {0}
                delete BgBewilligung where BgPositionID = {0}"
                , qryBgPosition["BgPositionID"]);
        }

        private void qryBgPosition_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            bool gruppierung = (bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"];

            if (gruppierung)
                throw new KissInfoException("Gruppen-/Kategoriezeilen können nicht gelöscht werden!");

            // Seit dem Laden des Budgets könnte die Position bewilligt/grün gestellt worden sein, deshalb muss der Status aktualisiert werden
            int? positionStatusNeu = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT
                  Status                = CASE WHEN BDG.MasterBudget = 0
                                          THEN CASE WHEN STA.Status IS NULL
                                               THEN CASE
                                                    WHEN BPO.BgKategorieCode IN (2) AND KRE.BaZahlungswegID IS NULL AND BPO.BgSpezkontoID IS NOT NULL -- Auszahlung an Spezialkonto
                                                         THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                                    WHEN BPO.BgKategorieCode = 1 AND BPO.VerwaltungSD = 0 -- nicht abgetretene Einnahmen
                                                         THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                                    WHEN BPO.BgKategorieCode = 2 AND KRE.BaZahlungswegID IS NOT NULL AND KRE.BaPersonID IS NOT NULL -- Ausgaben an Klient (ohne tatsächliche Auszahlung)
                                                         THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                                    WHEN BPO.BgKategorieCode IN (3, 4, 6)  -- Abzahlung / Kürzung / Vorabzug
                                                         THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 2 ELSE 1 END
                                                    WHEN BPO.BgKategorieCode IN (101)   -- Einzelzahlungen
                                                         THEN CASE WHEN BDG.BgBewilligungStatusCode in (5,9) THEN 14 ELSE 1 END
                                                    ELSE CASE BPO.BgBewilligungStatusCode
                                                         WHEN 1 THEN 1   -- grau
                                                         WHEN 2 THEN 15  -- abgelehnt
                                                         WHEN 3 THEN 12  -- angefragt
                                                         WHEN 5 THEN 14  -- bewilligt
                                                         WHEN 9 THEN 7   -- gesperrt
                                                         END
                                                    END
                                               ELSE STA.Status
                                               END
                                          END
                FROM   vwBgPosition BPO
                       INNER JOIN BgBudget                 BDG  ON BDG.BgBudgetID = BPO.BgBudgetID
                       LEFT  JOIN BgAuszahlungPerson       BAP  ON BAP.BgPositionID = BPO.BgPositionID AND
                                                                   BAP.BgAuszahlungPersonID = (SELECT TOP 1 BgAuszahlungPersonID
                                                                                               FROM   BgAuszahlungPerson
                                                                                               WHERE  BgPositionID = BPO.BgPositionID
                                                                                               ORDER BY
                                                                                                 CASE WHEN BaPersonID IS NULL THEN 1
                                                                                                      WHEN BaPersonID = BPO.BaPersonID THEN 2
                                                                                                      ELSE 3
                                                                                                 END)
                       LEFT  JOIN vwKreditor               KRE  ON KRE.BaZahlungswegID = BAP.BaZahlungswegID
                       LEFT  JOIN   (SELECT BUC.BgBudgetID, BUK.BgPositionID,
                                            Status       = MAX(BUC.KbBuchungStatusCode),
                                            StatusMin    = MIN(BUC.KbBuchungStatusCode),
                                            AnzahlBelege = COUNT(DISTINCT BUC.KbBuchungID)
                                     FROM   KbBuchungKostenart BUK
                                            LEFT JOIN KbBuchung BUC ON BUC.KbBuchungID = BUK.KbBuchungID
                                     GROUP  BY BUC.BgBudgetID, BUK.BgPositionID) STA ON STA.BgBudgetID = BPO.BgBudgetID AND STA.BgPositionID = BPO.BgPositionID

                WHERE BPO.BgPositionID = {0}"
                , qryBgPosition["BgPositionID"]) as int?;

            //nicht löschbar, wenn EditMask.Loeschen = false
            //nicht löschbar, wenn Status <> (grau,angefragt,abgelehnt,bewilligt)
            //wenn in einem Masterbudget und DatumVon leer => inaktiv setzen durch DatumVon = 01.01.1900
            int positionStatus = _isMasterbudget || !positionStatusNeu.HasValue ? 0 : positionStatusNeu.Value;
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            bool hauptDetailPos = !DBUtil.IsEmpty(qryBgPosition["DetailPos"]);
            bool kuerzung = (kategorie == (int)LOV.BgKategorieCode.Kuerzungen /*Kürzung*/ && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]) && (int?)GetFieldFromSpezkonto((int)qryBgPosition["BgSpezkontoID"], "BgSpezkontoTypCode") == 4);

            if (!_isMasterbudget)
            {
                if (positionStatus != 1 && positionStatus != 12 && positionStatus != 14 && positionStatus != 15)
                {
                    throw new KissInfoException("nur graue, angefragte, abgelehnte oder bewilligte Positionen können gelöscht werden!");
                }

                if (hauptDetailPos)
                {
                    throw new KissInfoException("Zusammengesetzte Positionen mit einem * oder + Zeichen können im Monatsbudget nicht gelöscht werden!");
                }

                if (kuerzung)
                {
                    throw new KissInfoException("Kürzungen können nicht gelöscht werden, jedoch kann der Betrag auf 0.- heruntergesetzt werden.");
                }
                //	if (!DBUtil.IsEmpty(qryBgPosition["M"]))
                //		throw new KissInfoException("Positionen, die aus einem Masterbudget kopiert wurden, können nicht gelöscht werden!");
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
                _newBgKategorieCode = (int)LOV.BgKategorieCode.Einnahmen; //nur neue Einnahme möglich im Masterbudget
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
                throw new KissInfoException("Das Monatsbudget wurde bereits freigegeben. Einzelzahlungen vom Grundbedarf sind nicht mehr möglich (nur via Spezialkonto).");

            //Kostenart, Buchungstext, BetragBudget
            DBUtil.CheckNotNullField(edtKostenart, lblKostenart.Text);
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtBetragBudget, lblBetragBudget.Text);

            //BudgetBetrag >= 0, bei Einnahmen -betrag erlaubt
            if (kategorie == (int)LOV.BgKategorieCode.Einnahmen)
            {
                // Einnahmen alles möglich
            }
            else if (kategorie == (int)LOV.BgKategorieCode.Ausgaben || kategorie == (int)LOV.BgKategorieCode.Abzahlung || kategorie == (int)LOV.BgKategorieCode.Kuerzungen || kategorie == (int)LOV.BgKategorieCode.Vorabzuege)
            {
                if (Convert.ToDecimal(qryBgPosition["BetragBudget"]) < Decimal.Zero)
                {
                    // BudgetBetrag >= 0 - Ausgaben, Abzahlung, Vorabzug, Kürzung
                    tabBgPosition.SelectedTabIndex = 0;
                    throw new KissInfoException("Der Betrag darf nicht negativ sein!", edtBetragBudget);
                }
            }
            else if (Convert.ToDecimal(qryBgPosition["BetragBudget"]) <= Decimal.Zero)
            {
                // BudgetBetrag > 0 - Alle andern ( Zusätzliche Leistung, Einzelzahlung)
                tabBgPosition.SelectedTabIndex = 0;
                throw new KissInfoException("Der Betrag darf nicht 0.00 oder negativ sein!", edtBetragBudget);
            }

            //Falls Status = Zahlungfehlerhaft und Kreditor/RefNr/Mitteilung mutiert: Flag für ZahlwegUpdate setzen für AfterPost
            _pendingZahlwegUpdate = (positionStatus == 5) &&
                                    (qryBgPosition.ColumnModified("BaZahlungswegID") ||
                                     qryBgPosition.ColumnModified("Kreditor") ||
                                     qryBgPosition.ColumnModified("ReferenzNummer") ||
                                     qryBgPosition.ColumnModified("ZusatzInfo") ||

                                     qryBgPosition.ColumnModified("EinzahlungsscheinCode") ||
                                     qryBgPosition.ColumnModified("MitteilungZeile1") ||
                                     qryBgPosition.ColumnModified("MitteilungZeile2") ||
                                     qryBgPosition.ColumnModified("MitteilungZeile3"));

            //#6661: Bei neuen Positionen (z.B. Einzelzahlung, existiert noch keine DataRow mit Version.Original). In diesem Fall müssen
            //wir diesen check überspringen (und können auch weiterhin _valutaUpdated=false annehmen).
            if (qryBgPosition.Row.RowState != DataRowState.Added)
            {
                _valutaUpdated = !qryBgPosition["KbAuszahlungsArtCode"].Equals(qryBgPosition["KbAuszahlungsArtCode", DataRowVersion.Original]) ||
                                 !qryBgPosition["BgAuszahlungsTerminCode"].Equals(qryBgPosition["BgAuszahlungsTerminCode", DataRowVersion.Original]) ||
                                 !qryBgPosition["ValutaDatum"].Equals(qryBgPosition["ValutaDatum", DataRowVersion.Original]) ||
                                 !qryBgPosition["ValutaTermine"].Equals(qryBgPosition["ValutaTermine", DataRowVersion.Original]) ||
                                 !qryBgPosition["BgWochentagCodes"].Equals(qryBgPosition["BgWochentagCodes", DataRowVersion.Original]);
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
                        qryBgPosition["BetragRechnung"] = qryBgPosition["BetragBudget"];
                }
                else
                    qryBgPosition["BetragRechnung"] = qryBgPosition["BetragBudget"];
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
                    // #6347: Wurde die Positionsart gewechselt und ev. bereits gemäss BgPositionsart.sqlRichtlinie ein neuer BetragBudget gesetzt,
                    // entstehen falsche Werte, wenn vorher BetragBudget != Betrag war.
                    // Deshalb wird neu bei POA-Wechsel der Betrag direkt von BetragBudget übernommen
                    if (!qryBgPosition[DBO.BgPosition.BgPositionsartID].Equals(qryBgPosition[DBO.BgPosition.BgPositionsartID, DataRowVersion.Original]) &&
                        (decimal)qryBgPosition["Abzug"] == 0 && (decimal)qryBgPosition["Reduktion"] == 0)
                    {
                        qryBgPosition["Betrag"] = qryBgPosition["BetragBudget"];
                    }
                    else
                    {
                        qryBgPosition["Betrag"] = (decimal)qryBgPosition["Betrag", DataRowVersion.Original] - abzugMod;
                    }
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
                int bgPositionIdCopyOf = DBUtil.IsEmpty(qryBgPosition["BgPositionID_CopyOf"]) ? (int)qryBgPosition["BgPositionID"] : (int)qryBgPosition["BgPositionID_CopyOf"];
                betragBudget = GetBetragBudget(bgPositionIdCopyOf);
            }

            //check Richtlinie
            if (kategorie != (int)LOV.BgKategorieCode.Einzelzahlungen && !DBUtil.IsEmpty(qryBgPosition[DBO.BgPosition.BgPositionsartID]))
            {
                SqlQuery qry = ShUtil.GetRichtlinie((int)qryBgPosition[DBO.BgPosition.BgPositionsartID], _bgBudgetId);
                if (qry.Count == 1 && edtBetragBudget.EditMode != EditModeType.ReadOnly)
                {
                    object betragMin = DBUtil.IsEmpty(qryBgPosition["BaPersonID"]) ? qry["UE_MIN"] : qry["PR_MIN"];
                    object betragMax = DBUtil.IsEmpty(qryBgPosition["BaPersonID"]) ? qry["UE_MAX"] : qry["PR_MAX"];

                    decimal betragOffset = 0;
                    if (qryBgPosition.Row.HasVersion(DataRowVersion.Original))
                    {
                        betragOffset = (decimal)qryBgPosition["Betrag", DataRowVersion.Original] -
                                       (decimal)qryBgPosition["BetragBudget", DataRowVersion.Original];
                    }

                    if (!DBUtil.IsEmpty(betragMin) && (decimal)qryBgPosition["Betrag"] < (decimal)betragMin)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage("CtlWhBudget", "MinBetrag",
                                                 "Der Betrag muss mindestens Fr. {0:n2} betragen", KissMsgCode.MsgInfo,
                                                 (decimal)betragMin - betragOffset), edtBetragBudget);
                    }
                    if (!DBUtil.IsEmpty(betragMax) && (decimal)qryBgPosition["Betrag"] > (decimal)betragMax && (decimal)qryBgPosition["Betrag"] > betragBudget)
                    {
                        throw new KissInfoException(
                            KissMsg.GetMLMessage("CtlWhBudget", "MaxBetrag",
                                                 "Der Betrag kann maximal Fr. {0:n2} betragen", KissMsgCode.MsgInfo,
                                                 Math.Max(betragBudget, (decimal)betragMax) - betragOffset),
                            edtBetragBudget);
                    }
                }
            }

            //check Betragsveränderungen + - erlaubt
            if (qryBgPosition.Row.RowState != DataRowState.Added)
            {
                if (_editMask.BetragPlus && !_editMask.BetragMinus)
                {
                    if (Convert.ToDecimal(qryBgPosition["BetragBudget"]) < betragBudget)
                        throw new KissInfoException(KissMsg.GetMLMessage("DlgPosition", "BetragZuKlein", "Der Betrag muss grösser oder gleich dem bewilligten Betrag (Fr. {0:n2}) sein", KissMsgCode.MsgInfo, betragBudget));
                }
                else if (_editMask.BetragMinus && !_editMask.BetragPlus)
                {
                    if (Convert.ToDecimal(qryBgPosition["BetragBudget"]) > betragBudget)
                        throw new KissInfoException(KissMsg.GetMLMessage("DlgPosition", "BetragZuGross", "Der Betrag muss kleiner oder gleich dem bewilligten Betrag (Fr. {0:n2}) sein", KissMsgCode.MsgInfo, betragBudget));
                }
            }

            if (kategorie == (int)LOV.BgKategorieCode.Abzahlung && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]) && (int?)GetFieldFromSpezkonto((int)qryBgPosition["BgSpezkontoID"], "BgSpezkontoTypCode") == 3)
            {
                _bgSpezkontoIdToUpdate = (int?)qryBgPosition["BgSpezkontoID"];
            }
            else if (kategorie == (int)LOV.BgKategorieCode.Kuerzungen && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]) && (int?)GetFieldFromSpezkonto((int)qryBgPosition["BgSpezkontoID"], "BgSpezkontoTypCode") == 4)
            {
                // Bei Kürzungen darf der Betrag entweder 0.- sein oder der vollen angegebenen Kürzung entsprechen
                _bgSpezkontoIdToUpdate = null;

                SqlQuery qry = DBUtil.OpenSQL(@"
                  DECLARE @AnteilGBL money

                  SELECT @AnteilGBL = KuerzungAnteilGBL
                  FROM dbo.BgSpezkonto
                  WHERE BgSpezkontoID = {0}

                  SELECT BetragKuerzung = dbo.[fnShGetKuerzungBetrag]({1}, @AnteilGBL), AnteilGBL = @AnteilGBL", qryBgPosition["BgSpezkontoID"], qryBgBudget["BgFinanzplanID"]);

                decimal betragKuerzung = (decimal)qry["BetragKuerzung"];
                decimal anteilGBL = (decimal)qry["AnteilGBL"];
                decimal betragGui = (decimal)qryBgPosition["Betrag"];
                if (betragGui != 0 && betragGui != betragKuerzung)
                {
                    throw new KissInfoException(KissMsg.GetMLMessage("CtlWhBudget", "UngueltigerBetragKuerzung", "Der Betrag der Kürzung muss entweder 0.- oder den festgelegten {0:n0}%, also Fr. {1:n2}, entsprechen", KissMsgCode.MsgInfo, anteilGBL, betragKuerzung));
                }
                decimal betragBeforeEdit = (decimal)qryBgPosition["Betrag", DataRowVersion.Original];
                if (betragBeforeEdit != betragGui)
                {
                    _bgSpezkontoIdToUpdate = (int?)qryBgPosition["BgSpezkontoID"];
                }
            }

            //setzen des Bewilligungsstatus bei Einnahmen im bewilligten Masterbudget
            if (kategorie == (int)LOV.BgKategorieCode.Einnahmen)
            {
                if (_isMasterbudget && budgetBewilligung == (int)BgBewilligungStatus.Erteilt)
                {
                    qryBgPosition["BgBewilligungStatusCode"] = BgBewilligungStatus.Erteilt;
                }
            }

            //setzen des Bewilligungsstatus bei grauen Zusatzleistungen
            else if (kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen && (positionStatus == 1 || positionStatus == 5 || positionStatus == 12 || positionStatus == 14 || positionStatus == 15))
            {
                if (qryBgPosition.ColumnModified(DBO.BgPosition.BgPositionsartID) || qryBgPosition.ColumnModified("Betrag"))
                {
                    if (!GetUserPermission())
                    {
                        qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode] = BgBewilligungStatus.InVorbereitung;
                    }
                }
            }

            //prüfen der Verfügbarkeit des Spezialkonto-Saldos bei Einzelzahlungen
            else if (kategorie == (int)LOV.BgKategorieCode.Einzelzahlungen && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]))
            {
                // setzen des Bewilligungsstatus bei Einzelzahlungen im bewilligten Monatsbudget
                if (!_isMasterbudget && budgetBewilligung == (int)BgBewilligungStatus.Erteilt)
                {
                    qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode] = BgBewilligungStatus.Erteilt;
                }

                if (Convert.ToDecimal(qryBgPosition["Betrag"]) > Convert.ToDecimal(GetFieldFromSpezkonto(qryBgPosition["BgSpezkontoID"], "Saldo")))
                {
                    throw new KissInfoException("Die Einzelzahlung kann nicht von diesem Spezialkonto abgebucht werden, da die Deckung des Spezialkontos nicht ausreicht.");
                }
            }

            //Betrifft Person
            if (!DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && !DBUtil.IsEmpty(qryBgPosition["ProUE"]))
            {
                bool proPerson = (bool)qryBgPosition["ProPerson"];
                bool proUe = (bool)qryBgPosition["ProUE"];

                if (proPerson && !proUe && DBUtil.IsEmpty(qryBgPosition[DBO.BgPosition.BaPersonID]))
                {
                    throw new KissInfoException("Das Feld 'Betrifft Person' darf nicht leer bleiben für diese Kostenart/Positionsart!", edtBaPersonID);
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

            if (!DBUtil.IsEmpty(qryBgPosition["BgAuszahlungPersonID"]))
            {
                var qry = DBUtil.OpenSQL(@"
                    SELECT ZAH.*
                    FROM dbo.BaZahlungsweg  ZAH WITH (READUNCOMMITTED)
                    WHERE ZAH.BaZahlungswegID = {0}
                    AND {1} NOT BETWEEN ZAH.DatumVon AND ZAH.DatumBis;",
                 qryBgPosition[DBO.BaZahlungsweg.BaZahlungswegID],
                 qryBgPosition["ValutaDatum"]);

                if (!qry.IsEmpty)
                {
                    throw new KissInfoException("Ausgewählte Zahlungsverbindung ist zum Fälligkeitsdatum ungültig.", edtKreditor);
                }
            }

            if ((kategorie == (int)LOV.BgKategorieCode.Ausgaben || kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen || kategorie == (int)LOV.BgKategorieCode.Einzelzahlungen) && !(_isMasterbudget && budgetBewilligung == 1))
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
                }

                //Wochentag
                else if (auszahlungsTermin == 6)
                    CheckNotNullFieldOnTabPage(edtWochentagCodes, "Wochentage", tpgKalender);

                //individuell
                if (auszahlungsTermin == 99 && qryBgAuszahlungPersonTermin.Count == 0)
                {
                    throw new KissInfoException("Es sind noch keine individuellen Auszahltermine erfasst.");
                }
                // elektronische Auszahlung
                if (auszahlungsArt == 101)
                    CheckNotNullFieldOnTabPage(edtKreditor, lblKreditor.Text, tpgZahlinfo);

                // bar
                if (auszahlungsArt == 103)
                    CheckNotNullFieldOnTabPage(edtMitteilungZeile1, lblZahlbarAn.Text, tpgMitteilung);

                //oranger ES
                if (es == 1)
                {
                    CheckNotNullFieldOnTabPage(edtReferenzNummer, lblReferenzNummer.Text, tpgZahlinfo);

                    SqlQuery qry = DBUtil.OpenSQL("SELECT PostKontoNummer FROM BaZahlungsweg WHERE BaZahlungswegID = {0}", qryBgPosition["BaZahlungswegID"]);
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

            if (kategorie == (int)LOV.BgKategorieCode.Einnahmen)
            {
                //Einnahmen
                //keine nicht abgetretenen Einnahmen im grünen Budget
                if (!_isMasterbudget && budgetBewilligung >= 5 && positionBewilligung == 1 && (!(bool)qryBgPosition["VerwaltungSD"] || (decimal)qryBgPosition["Betrag"] < 0))
                {
                    throw new KissInfoException("In einem grünen/roten Budget können nur noch abgetretene, positive Einnahmen erfasst werden!");
                }
                if (_isMasterbudget && qryBgPosition.Row.RowState == DataRowState.Added)
                    //falls DatumVon leer bleiben würde: => Position des Finanzplans
                    qryBgPosition["DatumVon"] = new DateTime((int)qryBgBudget["Jahr"], (int)qryBgBudget["Monat"], 1);
            }

            ctlErfassungMutation.SetFields();

            try
            {
                if (Session.Transaction == null)
                {
                    Session.BeginTransaction();
                }

                //sicherstellen, dass Finanzplan-Positionen nicht nachträglich verändert werden --> ggf Position clonen
                if (_isMasterbudget && budgetBewilligung >= 5 && qryBgPosition["DatumVon"] == DBNull.Value)
                {
                    //prüfen, ob eine relevante Spalte editiert wurde
                    HashSet<string> relevanteColumns = new HashSet<string>
                                                           {
                                                               "Betrag",
                                                               "Reduktion",
                                                               "Abzug",
                                                               "BetragBudget",
                                                               "BaPersonID",
                                                               "BgPositionsartID",
                                                               "BgKostenartID",
                                                               "Kostenart",
                                                               "VerwaltungSD"
                                                           };

                    bool columnChanged = false;

                    foreach (DataColumn col in qryBgPosition.DataTable.Columns)
                    {
                        if (qryBgPosition.ColumnModified(col.ColumnName) && relevanteColumns.Contains(col.ColumnName))
                        {
                            columnChanged = true;
                            break;
                        }
                    }

                    if (columnChanged)
                    {
                        int bgPositionId = (int)qryBgPosition["BgPositionID"];
                        int? bgPositionIdParent = qryBgPosition["BgPositionID_Parent"] as int?;

                        //qryCopy zeigt auf die Nachfolge-Position (DatumVon=02.01.1900)
                        SqlQuery qryCopy = ParentChildCopy(bgPositionId, bgPositionIdParent);
                        HashSet<string> columnsToIgnore = new HashSet<string>
                                                              {
                                                                  "BgPositionID",
                                                                  "BgPositionTS",
                                                                  "DatumVon",
                                                                  "DatumBis",
                                                                  "BgPositionID_Parent",
                                                                  "BgPositionID_CopyOf"
                                                              };
                        foreach (DataColumn col in qryBgPosition.DataTable.Columns)
                        {
                            if (qryCopy.DataTable.Columns.Contains(col.ColumnName)
                                    && !columnsToIgnore.Contains(col.ColumnName))
                            {
                                qryCopy[col.ColumnName] = qryBgPosition[col.ColumnName];
                            }
                        }
                        qryCopy.Post("BgPosition");

                        //die relevanten Spalten der FinanzplanPosition dürfen nicht verändert werden (ausser DatumBis=01.01.1900)
                        foreach (string columnName in relevanteColumns)
                        {
                            qryBgPosition[columnName] = qryBgPosition[columnName, DataRowVersion.Original];
                        }

                        try
                        {
                            //BeforePost + AfterPost Eventhandlers sollen nicht getriggert werden, da wir Post() innerhalb dem BeforePost-Eventhandler aufrufen
                            //und die zusätzlichen Aufrufe auf die EventHandlers das Transactionhandling durcheinander bringen.
                            qryBgPosition.BeforePost -= qryBgPosition_BeforePost;
                            qryBgPosition.AfterPost -= qryBgPosition_AfterPost;

                            qryBgPosition.Post(true, true);
                        }
                        finally
                        {
                            //EventHandlers wieder anhängen
                            qryBgPosition.BeforePost += qryBgPosition_BeforePost;
                            qryBgPosition.AfterPost += qryBgPosition_AfterPost;
                        }

                        //DatumBis auf '01.01.1900' setzen auf Finanzplan-Positionen (Parent+Child)
                        DBUtil.ExecSQLThrowingException(@"
                        UPDATE BgPosition SET DatumBis = '19000101'
                        WHERE BgPositionID = IsNull({1}, {0}) OR BgPositionID_Parent = IsNull({1}, {0});",
                            bgPositionId,
                            bgPositionIdParent);

                        //ev. existierenden BgAuszahlungPerson Record umhängen von FP-Position auf MB-Position
                        DBUtil.ExecSQLThrowingException(@"
                        UPDATE BgAuszahlungPerson SET BgPositionID = {1}
                        WHERE BgPositionID = {0};",
                            bgPositionId,
                            qryCopy[DBO.BgPosition.BgPositionID]);

                        //qryBgPosition muss auf die neue/editierte Position zeigen)
                        qryBgPosition.Refresh();

                        string newSearchExpression = string.Format("BgPositionID={0}", qryCopy["BgPositionID"]);
                        qryBgPosition.Find(newSearchExpression);

                        qryBgPosition.Row.SetModified();
                    }
                }
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

        private void qryBgPosition_PositionChanged(object sender, EventArgs e)
        {
            if (qryBgPosition.IsEmpty)
                return;
            if (_refreshing)
                return;
            if (qryBgPosition.Row.RowState == DataRowState.Added)
                return;

            bool gruppierung = (bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"];
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

            SetPositionEditMode();
            LoadSpezialkonto(qryBgPosition["BgKostenartID"], qryBgPosition["BaPersonID"]);

            if (!gruppierung)
            {
                qryBgAuszahlungPersonTermin.Fill("SELECT * FROM BgAuszahlungPersonTermin WHERE BgAuszahlungPersonID = {0} ORDER BY Datum", qryBgPosition["BgAuszahlungPersonID"]);
                if (kategorie != 1)
                    DisplayCalendarBoldDates();
                qryBgDokumente.Fill(qryBgPosition["BgPositionID"]);
            }

            tabBgPosition_SelectedTabChanged(tabBgPosition.SelectedTab);
            ctlErfassungMutation.ShowInfo();

            if (qryBgPosition.Row.RowState != DataRowState.Added)
                grdBgPosition.Focus();
        }

        private void qryBgPosition_PostCompleted(object sender, EventArgs e)
        {
            if (_noRefresh)
            {
                return;
            }
            qryBgPosition.Refresh();
            SetPositionEditMode();
        }

        private void tabBgPosition_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (page == tpgBgUebersicht)
            {
                qryWhBudgetUebersicht.Fill(_bgBudgetId);
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
                        DBUtil.ExecSQLThrowingException("exec spWhBudget_CreateKbBuchung {0}, {1}, 1", _bgBudgetId, Session.User.UserID);
                        qry = DBUtil.OpenSQL("exec spWhBudget_CreateKbBuchung {0}, {1}, 1", _bgBudgetId, Session.User.UserID);
                    }
                    else
                    {
                        //grün/rotes Monatsbudget: tatsächliche KbBuchung/KbBuchungKostenart-Einträge
                        qryKbBuchung.Fill(_bgBudgetId);
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

            if (page == tpgBewilligung)
            {
                qryBgBewilligung.Fill(qryBgPosition["BgPositionID"]);
            }
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            ApplicationFacade.DoEvents();
            tmrTimer.Enabled = false;

            DateTime firstDate = new DateTime(Convert.ToInt32(qryBgBudget["Jahr"]), Convert.ToInt32(qryBgBudget["Monat"]), 1);
            _calendarFilling = true;
            edtCalendar.SelectionRange = new SelectionRange(firstDate, firstDate.AddDays(1));
            _calendarFilling = false;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string GetContextName()
        {
            string whGrundbedarfTyp = DBUtil.ExecuteScalarSQL(@"
                SELECT IsNull(',%' + XLC.ShortText, '')
                FROM BgPosition        BPO
                  INNER JOIN XLOVCode  XLC ON XLC.LOVName = 'WhGrundbedarfTyp' AND XLC.Code = BPO.BgPositionsartID
                WHERE BPO.BgBudgetID = {0}", _bgBudgetId) as string;

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

                case "GBL":
                    var whGrundbedarfTypCode = DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT WhGrundbedarfTypCode
                        FROM dbo.BgFinanzplan FPL WITH (READUNCOMMITTED)
                        WHERE BgFinanzplanID = {0}",
                        qryBgBudget[DBO.BgBudget.BgFinanzplanID]) as int?;

                    if (whGrundbedarfTypCode == 32015)
                    {
                        var qry = ShUtil.GetRichtlinie(32015, Convert.ToInt32(qryBgBudget["BgBudgetID"]));
                        return qry["UE_DEF"];
                    }

                    object retval = DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT POS.Betrag
                        FROM dbo.BgPosition POS WITH (READUNCOMMITTED)
                          INNER JOIN dbo.BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID
                        WHERE POS.BgBudgetID = {0}
                          AND POS.DatumVon IS NULL
                          AND POA.BgPositionsartCode IN (SELECT Code FROM XLOVCode WHERE LOVName = CONVERT(varchar(100), 'WhGrundbedarfTyp'));",
                        _bgBudgetId);
                    if (retval == null)
                    {
                        return 0;
                    }
                    return retval;
            }

            return base.GetContextValue(fieldName);
        }

        void IBelegleser.ProcessBelegleser(Belegleser beleg)
        {
            //Falls Gruppe/Kategorie: keine Aktion, ohne Meldung
            if ((bool)qryBgPosition["Gruppe"] || (bool)qryBgPosition["Kategorie"])
                return;

            //nicht editierbar, wenn
            //- qryBgPosition.CanUpdate == false
            //- in einem bewilligten/abgeschlossenen Masterbudget
            //- in einer nicht grauen Position eines Monatsbudgets

            bool editable = qryBgPosition.CanUpdate;
            int bewilligungCode = (int)qryBgBudget[DBO.BgPosition.BgBewilligungStatusCode];
            int positionStatus = _isMasterbudget ? 0 : (int)qryBgPosition["Status"];

            //int PositionStatusMin;
            //if (!_isMasterbudget && !DBUtil.IsEmpty(qryBgPosition["StatusMin"]))
            //    PositionStatusMin = (int)qryBgPosition["StatusMin"];

            if (_isMasterbudget)
            {
                editable &= (bewilligungCode != 5) && (bewilligungCode != 9);
            }
            else
            {
                editable &= (positionStatus == 1);
            }

            // #9175: Mangels layerung wird direkt auf GUI geprüft, ob die vom Belegleser geänderten Felder editierbar sind
            // Vorerst aber nur Betragsfeld. Es könnte sein, dass Belegleser auch funktionieren muss, wenn ein Feld readonly ist
            editable &= edtBetragBudget.EditMode != EditModeType.ReadOnly;
            //edtKreditor.EditMode != EditModeType.ReadOnly &&
            //edtReferenzNummer.EditMode != EditModeType.ReadOnly;

            if (!editable)
            {
                KissMsg.ShowInfo("Neue Daten vom Belegleser: Der Status der Position erlaubt keine Änderung der erfassten Daten");
                return;
            }

            DlgAuswahlBaZahlungsweg dlg = new DlgAuswahlBaZahlungsweg();
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
                    if (beleg.Betrag > 0)
                        qryBgPosition["Betrag"] = beleg.Betrag;
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
                if (beleg.Betrag > 0)
                    qryBgPosition["Betrag"] = beleg.Betrag;
            }

            qryBgPosition.RefreshDisplay();
            SetPositionEditMode();
        }

        public override bool OnAddData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
                qryBgDokumente.Insert();
            else
            {
                qryBgPosition.Insert();
                SetPositionEditMode();
            }

            return true;
        }

        public override bool OnDeleteData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                if (!qryBgDokumente.Delete())
                    return false;

                qryBgPosition["Doc"] = (qryBgDokumente.Count > 0) ? qryBgDokumente.Count.ToString() : "";
                qryBgPosition.RowModified = false;
                qryBgPosition.Row.AcceptChanges();
                return true;
            }

            if (qryBgPosition.Delete())
            {
                SetPositionEditMode();
                return true;
            }

            return false;
        }

        public override bool OnSaveData()
        {
            if (tabBgPosition.SelectedTab == tpgDokumente)
            {
                if (!qryBgDokumente.Post())
                    return false;

                qryBgPosition["Doc"] = qryBgDokumente.Count.ToString();

                _refreshing = true;
                qryBgPosition.Post();
                _refreshing = false;
                return true;
            }

            return qryBgPosition.Post();
        }

        #endregion

        #region Internal Methods

        internal void ResetBudget()
        {
            int bewilligungStatus = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);

            if ((bewilligungStatus != 5 && bewilligungStatus != 9) ||
                (_isMasterbudget && bewilligungStatus != 5))
            {
                DBUtil.ExecSQL(120, "EXECUTE spWhBudget_Reset {0}, {1}"
                    , qryBgBudget["BgFinanzplanID"], _bgBudgetId);
                qryBgPosition.Refresh();
                SetPositionEditMode();
            }
            else if (_isMasterbudget)
            {
                KissMsg.ShowInfo("CtlWhBudget", "MasterbudgetGesperrt", "Masterbudget kann nicht zurückgesetzt werden");
            }
            else
            {
                KissMsg.ShowInfo("CtlWhBudget", "MonatsbudgetGesperrt", "Monatsbudget kann nicht zurückgesetzt werden");
            }
        }

        #endregion

        #region Private Static Methods

        private static void CopyIdToClipboard(ref SqlQuery qry, string columnName)
        {
            // check if we have any content
            if (DBUtil.IsEmpty(qry[columnName]))
            {
                // do nothing
                return;
            }

            try
            {
                // get data
                string id = Convert.ToString(qry[columnName]);

                // copy data to clipboard
                Clipboard.Clear();
                Clipboard.SetText(id);

                // check content
                if (!Clipboard.ContainsText())
                {
                    throw new KissErrorException("Clipboard does not contain any data.");
                }

                // show info
                KissMsg.ShowInfo(CLASSNAME, "SuccessfullyCopiedAboutText_v01", "Die ID '{0}' wurde in den Zwischenspeicher kopiert.", id);
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(CLASSNAME, "ErrorCopyAboutText", "Es ist ein Fehler beim Kopieren der ID in den Zwischenspeicher aufgetreten.", ex);
            }
        }

        #endregion

        #region Private Methods

        private void ApplyAction(BewilligungAktion aktion)
        {
            ApplyAction(null, aktion);
        }

        private void ApplyAction(DlgBewilligung dlg)
        {
            ApplyAction(dlg, dlg.Aktion);
        }

        private void ApplyAction(DlgBewilligung dlg, BewilligungAktion aktion)
        {
            bool gruenStellen = false;

            Session.BeginTransaction();
            try
            {
                if (dlg != null && !dlg.ActiveSQLQuery.Post())
                {
                    throw new KissCancelException();
                }

                if (aktion == BewilligungAktion.Bewilligen)
                {
                    gruenStellen = true;
                }

                //Statusupdate auf BgPosition inkl Detailpositionen
                int bgPosIdParent = ShUtil.GetCode(qryBgPosition["BgPositionID_Parent"]);
                ShUtil.SetBewilligungStatusFromPosition(
                    bgPosIdParent != 0 ? bgPosIdParent : (int)qryBgPosition["BgPositionID"],
                    DlgBewilligung.GetNextBewilligungStatus(aktion),
                    true
                );

                qryBgPosition.Refresh();
                SetPositionEditMode();

                if (gruenStellen)
                {
                    PositionGruenStellen();
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                // rollback changes
                Session.Rollback();

                // show error message
                KissMsg.ShowError(Name, "ErrorPositionBewilligen", "Es ist ein Fehler beim Bewilligen der Position(en) aufgetreten.", ex);

                // refresh
                qryBgPosition_PositionChanged(null, null);
                qryBgPosition.RefreshDisplay();
            }
        }

        private bool AuswahlDebitor(string searchString, bool buttonClicked)
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
                    // Involvierte Stellen  - FaFallPerson / BaPerson_BaInstitution

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

                        -- Involvierte Institutionen
                        SELECT  Art               = 'Institutionen',
                                Name              = INS.Name,
                                Adresse           = INS.Adresse,
                                Typ               = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, ',', {1}, 1),
                                BaInstitutionID$  = INS.BaInstitutionID,
                                BaPersonID$       = NULL,
                                Adresse$          = INS.AdresseMehrzeilig,
                                SortKey$          = 2
                        FROM FaFallPerson                 FFP
                          INNER JOIN BaPerson_BaInstitution PIN ON PIN.BaPersonID = FFP.BaPersonID
                          INNER JOIN vwInstitution        INS ON INS.BaInstitutionID = PIN.BaInstitutionID
                        WHERE FaFallID = {0}

                        ORDER BY SortKey$, Name, Adresse
                        ",
                        qryBgBudget["FaFallID"].ToString(), buttonClicked, Session.User.UserID, null, null);
                    break;

                default:
                    cancel = !dlg.SearchData(@"
                        SELECT Institution      = INS.Name,
                               Adresse          = INS.Adresse,
                               Typ              = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, ',', {1}, 1),
                               BaInstitutionID$ = INS.BaInstitutionID,
                               BaPersonID$      = null,
                               Adresse$         = INS.AdresseMehrzeilig
                        FROM   vwInstitution INS
                        WHERE  INS.Name LIKE '%' + {0} + '%'
                               -- AND INS.Debitor = 1 -- Wird in Bern vielleicht später wieder hinzukommen
                        ORDER BY Institution",
                        searchString,
                        buttonClicked, Session.User.UserID, null, null);
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

        private bool AuswahlKreditor(string searchString, bool buttonClicked)
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
                    qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    SetPositionEditMode();
                    return false;
                }
            }

            int kategorie = (int)qryBgPosition["BgKategorieCode"];
            bool kreditorEingeschraenkt = Utils.ConvertToBool(qryBgPosition["KreditorEingeschraenkt"]);

            if (searchString == "." || kreditorEingeschraenkt)
            {
                // Auszahlung an
                // Klientensystem       	 - FaFallPerson
                // Involvierte Institutionen - FaFallPerson / BaPerson_BaInstitution
                // Institution aus SpezKonto
                DlgAuswahl dlg = new DlgAuswahl();

                int fallId = Utils.ConvertToInt(qryBgBudget["FaFallID"]);
                int? spezKontoId = qryBgPosition["BgSpezkontoID"] as int?;

                cancel = !dlg.SearchKreditor(fallId, spezKontoId, searchString, buttonClicked);

                if (!cancel)
                {
                    qryBgPosition["Kreditor"] = dlg["Kreditor$"];
                    qryBgPosition["ZusatzInfo"] = dlg["ZusatzInfo$"];
                    qryBgPosition["BaZahlungswegID"] = dlg["ID$"];
                    qryBgPosition["EinzahlungsscheinCode"] = dlg["ESCode$"];

                    if (kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen || kategorie == (int)LOV.BgKategorieCode.Ausgaben)
                    {
                        qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                    }

                    if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                    {
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    }
                    else
                    {
                        qryBgPosition["ReferenzNummer"] = dlg["Referenznummer$"];
                        qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile3"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile4"] = DBNull.Value;
                    }

                    _kreditorUpdated = true;

                    SetPositionEditMode();
                    return false;
                }
            }
            else // Auszahlung Dritte
            {
                DlgAuswahlBaZahlungsweg dlg2 = new DlgAuswahlBaZahlungsweg();
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
                        select VornameName,WohnsitzStrasseHausNr,WohnsitzPLZOrt
                        from   vwPerson
                        where  BaPersonID = {0}",
                        qryBgBudget["LeistungBaPersonID"]);

                    qryBgPosition["BaZahlungswegID"] = dlg2["BaZahlungswegID"];
                    qryBgPosition["Kreditor"] = dlg2["Kreditor"];
                    qryBgPosition["ZusatzInfo"] = dlg2["ZusatzInfo"];
                    qryBgPosition["EinzahlungsscheinCode"] = dlg2["EinzahlungsscheinCode"];
                    qryBgPosition["MitteilungZeile1"] = TruncateString(qry2["VornameName"], 35);

                    if (kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen || kategorie == (int)LOV.BgKategorieCode.Ausgaben)
                    {
                        qryBgPosition["BgSpezkontoID"] = DBNull.Value;
                    }

                    if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                    {
                        qryBgPosition["ReferenzNummer"] = DBNull.Value;
                    }
                    else
                    {
                        qryBgPosition["ReferenzNummer"] = dlg2["Referenznummer"];
                        qryBgPosition["MitteilungZeile1"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile2"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile3"] = DBNull.Value;
                        qryBgPosition["MitteilungZeile4"] = DBNull.Value;
                    }

                    _kreditorUpdated = true;
                }

                qryBgPosition.RefreshDisplay();
                SetPositionEditMode();
            }
            return cancel;
        }

        private void CheckNotNullFieldOnTabPage(IKissBindableEdit ctl, String text, SharpLibrary.WinControls.TabPageEx page)
        {
            try
            {
                ((KissTabControlEx)page.Parent).SelectTab(page);
            }
            finally
            {
                DBUtil.CheckNotNullField(ctl, text);
            }
        }

        private void DisablePositionElements()
        {
            qryBgPosition.EnableBoundFields(false);
            tabZahlinfo.Visible = false;
            tpgDokumente.HideTab = true;
            tpgBelege.HideTab = _isMasterbudget;
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
        }

        private void DisplayCalendarBoldDates()
        {
            _calendarFilling = true;

            edtCalendar.TodayDate = DateTime.Today;

            edtCalendar.BoldedDates = null;
            if (_isMasterbudget)
                return;

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
            finally
            {
                _calendarFilling = false;
            }
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

        private decimal GetBetragBudget(object bgPositionId)
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
                , bgPositionId);
        }

        private object GetFieldFromSpezkonto(object bgSpezkontoId, string fieldName)
        {
            DataRow[] rows;
            SqlQuery qry = (SqlQuery)edtBgSpezkontoID.Properties.DataSource;

            if (DBUtil.IsEmpty(bgSpezkontoId))
            {
                rows = qry.DataTable.Select("Code is null"); //Grundbedarf
            }
            else
            {
                rows = qry.DataTable.Select(string.Format("Code = {0}", bgSpezkontoId)); //Spezkonto
            }

            if (rows.Length == 1)
            {
                return rows[0][fieldName];
            }

            return null;
        }

        private bool GetUserPermission()
        {
            decimal betragBudget = (decimal)qryBgPosition["BetragBudget"];
            //int bgSpezkontoId = ShUtil.GetCode(qryBgPosition["BgSpezkontoID"]);
            int bgPositionsartId = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgPositionsartID]);

            return GetUserPermission(betragBudget, bgPositionsartId);
        }

        private bool GetUserPermission(decimal betrag, int bgPositionsartId)
        {
            return betrag <= Convert.ToDecimal(DBUtil.GetUserSilPermission(bgPositionsartId, _faLeistungId));
        }

        private bool HasGrueneBuchungMitBelegNr(int? bgPositionId)
        {
            return DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT TOP 1 CONVERT(BIT, 1)
                FROM dbo.KbBuchungKostenart BKO WITH (READUNCOMMITTED)
                  INNER JOIN dbo.KbBuchung  BUC WITH (READUNCOMMITTED) ON BUC.KbBuchungID = BKO.KbBuchungID
                WHERE BUC.BgBudgetID = {0}
                  AND ({1} IS NULL OR BKO.BgPositionID = {1})
                  AND BUC.BelegNr IS NOT NULL",
                _bgBudgetId,
                bgPositionId
            ) as bool? ?? false;
        }

        private void LoadSpezialkonto(object bgKostenartId, object baPersonId)
        {
            //#7508, Beim Löschen einer Einnahme ist unter Umständen der RowState
            //RowState.Detached. Dann kann man die Werte aus der Row nicht mehr auslesen.
            //qryBgPosition["BgBudgetID"] erzeugt eine Exception.
            if (qryBgPosition.Row.RowState == DataRowState.Detached)
            {
                return;
            }

            edtBgSpezkontoID.Properties.ShowHeader = true;
            edtBgSpezkontoID.Properties.DropDownRows = 7;
            edtBgSpezkontoID.Properties.DataSource = DBUtil.OpenSQL(@"
                SELECT Code                = SPK.BgSpezkontoID,
                       Typ                 = TYP.ShortText,
                       KOA_S               = BKA.KontoNr,
                       KOA_H               = BPKA.KontoNr,
                       Text                = SPK.NameSpezkonto,
                       Saldo               = CASE
                                               WHEN {3} = 101 THEN dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 4, {2}, {4})  -- Deckung
                                               ELSE                dbo.fnBgSpezkonto(SPK.BgSpezkontoID, 3, {2}, {4})  -- Saldo
                                             END,
                       SortKey             = TYP.Sortkey,
                       KOAName             = BKA.KontoNr + ' ' + BKA.Name,
                       BaPersonID          = SPK.BaPersonID,
                       BgPositionsartID    = SPK.BgPositionsartID,
                       KOAPositionsart     = ISNULL(BPKA.KontoNr, BKA.KontoNr) + ' ' + ISNULL(BPA.Name, BKA.Name),
                       BgSplittingArtCode  = BKA.BgSplittingArtCode,
                       ProPerson           = BPA.ProPerson,
                       ProUE               = BPA.ProUE,
                       BaInstitutionID     = SPK.BaInstitutionID,
                       BgSpezkontoTypCode  = SPK.BgSpezkontoTypCode,
                       KreditorEingeschraenkt = BPA.KreditorEingeschraenkt
                FROM BgSpezkonto             SPK
                  INNER JOIN XLOVCode        TYP ON TYP.LOVName = 'BgSpezkontoTyp' and TYP.Code = SPK.BgSpezkontoTypCode
                  LEFT  JOIN BgPositionsart  BPA ON BPA.BgPositionsartID = SPK.BgPositionsartID
                  LEFT  JOIN BgPositionsart  GBL ON GBL.BgPositionsartID = {1}
                  LEFT  JOIN BgKostenart     BKA ON BKA.BgKostenartID = ISNULL(SPK.BgKostenartID, GBL.BgKostenartID)
                  LEFT  JOIN BgKostenart     BPKA ON BPKA.BgKostenartID = BPA.BgKostenartID
                WHERE SPK.FaLeistungID = {0}
                  AND (    ({3} IN (2, 100) AND (SPK.BgSpezkontoTypCode = 1 AND SPK.BgKostenartID = {5} AND COALESCE(SPK.BaPersonID, {6}, 0) = IsNull({6}, 0) )) -- Ausgabekonto
                        OR ({3} IN (6)      AND (SPK.BgSpezkontoTypCode = 2))  -- Vorabzugskonto
                        OR ({3} IN (1, 3)   AND (SPK.BgSpezkontoTypCode = 3))  -- Abzahlungskonto
                        OR ({3} IN (4)      AND (SPK.BgSpezkontoTypCode = 4))  -- Kürzung
                        OR ({3} IN (101)    AND (SPK.BgSpezkontoTypCode <> 3 OR SPK.OhneEinzelzahlung = 0)))
                  -- AND (GETDATE() BETWEEN SPK.DatumVon AND IsNull(SPK.DatumBis, '99990101'))		                -- Mantis 3207 nur aktie Spezialkonti
                  AND (dbo.fnDateSerial({7},  {8} ,1) <= IsNull(SPK.DatumBis, '99990101'))                          -- Mantis 4374 Überarbeitung 'Abzahlungskonto'
                  AND SPK.AbschlussgrundCode IS NULL

                UNION ALL

                SELECT Code                = NULL,
                       Typ                 = NULL,
                       KOA_S               = NULL,
                       KOA_H               = NULL,
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
                       BgSpezkontoTypCode  = NULL,
                       KreditorEingeschraenkt = 0
                FROM BgKostenart             BKA
                  INNER JOIN BgPositionsart  BPA ON BPA.BgKostenartID = BKA.BgKostenartID
                WHERE BPA.BgPositionsartID = {1}

                ORDER BY SortKey, Text",
                qryBgBudget["FaLeistungID"],            //{0}
                qryBgBudget["WhGrundbedarfTypCode"],    //{1}

                qryBgPosition["BgBudgetID"],            //{2}
                qryBgPosition["BgKategorieCode"],       //{3}
                qryBgPosition["BgPositionID"],          //{4}

                bgKostenartId,                          //{5}
                baPersonId,                             //{6}

                qryBgBudget["Jahr"],                    //{7}
                qryBgBudget["Monat"]);                  //{8}
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
                return;
            if (!qryBgPosition.CanInsert)
                return;
            _newBgKategorieCode = bgKategorieCode;
            qryBgPosition.Insert();
            SetPositionEditMode();
        }

        private SqlQuery ParentChildCopy(int bgPositionId, int? bgPositionIdParent)
        {
            int nbrOfCopyPositions = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(1)
                FROM BgPosition BPO
                  INNER JOIN BgPosition BPC ON BPC.BgPositionID_CopyOf = BPO.BgPositionID AND BPC.BgBudgetID = BPO.BgBudgetID
                WHERE BPO.BgPositionID = {0};", bgPositionId);

            if (nbrOfCopyPositions > 0)
            {
                //we cannot easily clone this position. Cancel operation and ask user to Terminate Finanzplan and create a new one
                throw new KissInfoException(KissMsg.GetMLMessage("CtlWhBudget", "FPPositionMutiertNachfolgePosition", "Positionen aus dem Finanzplan können nur bearbeitet werden, wenn Sie keine Nachfolge-Position haben. Bitte erstellen Sie einen neuen Finanzplan."));
            }

            return DBUtil.OpenSQL(@"
                SELECT DISTINCT BgPositionID AS Pk, BgPositionID_Parent AS Parent, CONVERT(int, NULL) AS KeyNew
                INTO #BgPosition
                FROM BgPosition WHERE BgPositionID = IsNull({1}, {0}) OR BgPositionID_Parent = IsNull({1}, {0})

                EXECUTE spXParentChildCopy '#BgPosition',
                                           'BgPosition', 'BgPositionID', 'BgPositionID_Parent',
                                           'BgPositionID_CopyOf, DatumVon, DatumBis', 'BgPositionID, ''19000102'', DatumBis', 'DatumBis, OldID'

                SELECT BPO.*, TMP.Pk
                FROM #BgPosition           TMP
                  INNER JOIN vwBgPosition  BPO ON BPO.BgPositionID = TMP.KeyNew
                WHERE BgPositionID_CopyOf = {0}

                DROP TABLE #BgPosition"
                , bgPositionId, bgPositionIdParent);
        }

        private void PositionBewilligung()
        {
            _noRefresh = true;
            bool ok = qryBgPosition.Post();
            _noRefresh = false;

            if (!ok)
            {
                return;
            }

            if ((LOV.BgKategorieCode)qryBgPosition[DBO.BgPosition.BgKategorieCode] != LOV.BgKategorieCode.Zusaetzliche_Leistungen)
            {
                return;
            }

            BgBewilligungStatus bewilligungStatus = (BgBewilligungStatus)qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode];
            if (bewilligungStatus == BgBewilligungStatus.InVorbereitung && GetUserPermission())
            {
                ApplyAction(BewilligungAktion.Bewilligen);

                //User hat Kompetenz, also Bewilligungseintrag erstellen
                SqlQuery qry = ShUtil.GetBgBewilligung_Neu();
                qry[DBO.BgBewilligung.BgBudgetID] = _bgBudgetId;
                qry[DBO.BgBewilligung.BgBewilligungCode] = 2;
                qry[DBO.BgBewilligung.BgPositionID] = (int)qryBgPosition["BgPositionID"];
                qry[DBO.BgBewilligung.Bemerkung] = "Eigenkompetenz ausreichend";
                qry[DBO.BgBewilligung.UserID_An] = Session.User.UserID;
                qry.Post();
            }
            else
            {
                DlgBewilligung dlg = new DlgBewilligung(
                    BewilligungTyp.Einzelzahlung,
                    (int)qryBgPosition["BgPositionID"],
                    bewilligungStatus,
                    GetUserPermission
                );
                dlg.ShowDialog(this);

                if (!dlg.UserCancel)
                {
                    ApplyAction(dlg);
                }
                else
                {
                    // damit eine neue Zeile in der Ansicht korrekt eingeordnet wird
                    // bei dlg.UserYes wird dies in ApplyAction(dlg) gemacht
                    qryBgPosition.Refresh();
                    SetPositionEditMode();
                }
            }
        }

        private void PositionGruenStellen()
        {
            if (!qryBgPosition.Post())
            {
                return;
            }

            /*
            int AuszahlungsArt = ShUtil.GetCode(qryBgPosition["KbAuszahlungsArtCode"]);

            if (AuszahlungsArt == 101 && !DBUtil.UserHasRight("CtlBgBudget_PositionGruenStellen"))
            {
                KissMsg.ShowInfo("Fehlende Berechtigung!");
                return;
            }
            */

            try
            {
                if (_isMasterbudget)
                {
                    return;
                }

                int bewilligungCode = Convert.ToInt32(qryBgBudget["BgBewilligungStatusCode"]);

                if (bewilligungCode == 1) //1: In Vorbereitung
                {
                    return;
                }

                //Some values:
                // 1: grau
                // 7: gesperrt
                // 12: Angefragt
                // 14: bewilligt
                // 15: abgelehnt
                int positionStatus = Convert.ToInt32(qryBgPosition["Status"]);

                if (positionStatus == 1 || positionStatus == 14)
                {
                    // graue/bewilligte Position auf grün stellen
                    DBUtil.ExecSQLThrowingException(@"
                        EXECUTE dbo.spWhBudget_CreateKbBuchung {0}, {1}, 0, null, {2};",
                        _bgBudgetId,
                        Session.User.UserID,
                        qryBgPosition["BgPositionID"]);
                }
                else if (positionStatus == 7)
                {
                    // alle roten Belege im Zusammenhang mit dieser Position auf grün stellen
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE BUC
                        SET BUC.KbBuchungStatusCode = 2
                        FROM dbo.KbBuchung                  BUC
                            INNER JOIN dbo.KbBuchungKostenart BUK ON BUK.KbBuchungID = BUC.KbBuchungID
                        WHERE BUK.BgPositionID = {0}
                            AND BUC.KbBuchungStatusCode = 7;", qryBgPosition["BgPositionID"]);
                }
                else if (positionStatus == 5)
                {
                    // alle Belege mit "Zahlauftrag fehlerhaft" im Zusammenhang mit dieser Position auf grün stellen
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE BUC
                        SET BUC.KbBuchungStatusCode = 13
                        FROM dbo.KbBuchung                  BUC
                            INNER JOIN dbo.KbBuchungKostenart BUK ON BUK.KbBuchungID = BUC.KbBuchungID
                        WHERE BUK.BgPositionID = {0}
                            AND BUC.KbBuchungStatusCode = 5;", qryBgPosition["BgPositionID"]);
                }
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

            qryBgPosition.Refresh();
            SetPositionEditMode();
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

            //int AuszahlungsArt = 0;
            //if (!DBUtil.IsEmpty(qryBgPosition["KbAuszahlungsArtCode"]))
            //    AuszahlungsArt = (int)qryBgPosition["KbAuszahlungsArtCode"];

            Session.BeginTransaction();
            try
            {
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
                    Session.Commit();
                    return; 	//keine neuen Daten, falls kein gültiger Auszahltermin
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
                    throw new Exception("Fehler beim Speichern der Auszahlinformationen");

                //Neue Datensätze in BgAuszahlungPersonTermin
                String sql = "";
                if (auszahlungsTermin == 4) //Valuta
                {
                    sql += string.Format(@"
                        INSERT dbo.BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum) VALUES ({{0}}, {0}) ",
                        DBUtil.SqlLiteral(qryBgPosition["ValutaDatum"]));
                }
                else
                {
                    foreach (DataRow row in qryBgAuszahlungPersonTermin.DataTable.Rows)
                    {
                        sql += string.Format(@"
                            INSERT dbo.BgAuszahlungPersonTermin (BgAuszahlungPersonID, Datum) VALUES ({{0}}, {0}) ",
                            DBUtil.SqlLiteral(row["Datum"]));
                    }
                }
                if (sql.Length > 0)
                {
                    DBUtil.ExecSQLThrowingException(sql, qry["BgAuszahlungPersonID"]);
                }

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
                return;
            }
        }

        private void SetBudgetEditMode()
        {
            int bewilligungCode = (int)qryBgBudget["BgBewilligungStatusCode"];
            bool editable = (bewilligungCode != 5) && (bewilligungCode != 9);
            bool abgeschlossen = !DBUtil.IsEmpty(qryBgBudget["LeistungDatumBis"]);

            if ((bool)qryBgBudget["Masterbudget"])
            {
                btnBudgetNeu.Enabled = !editable && !abgeschlossen;
                btnEinzelzahlung.Enabled = false;
                btnZusatzleistung.Enabled = false;
                btnEinnahme.Enabled = !abgeschlossen && bewilligungCode == 5;
            }
            else
            {
                btnBudgetNeu.Enabled = !abgeschlossen;
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

                btnBudgetGrau.Visible = bewilligungCode == 5 && countUnveraenderbar == 0 && !abgeschlossen && (qryBgPosition.Count > 0);
                btnBudgetGruen.Visible = (bewilligungCode == 1 || bewilligungCode == 9) && !abgeschlossen && (qryBgPosition.Count > 0);
                btnBudgetRot.Visible = bewilligungCode == 5 && !abgeschlossen && (qryBgPosition.Count > 0);
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
            bool wohnkostenPosition = ShUtil.GetCode(qryBgPosition["BgGruppeCode"]) == 3206; //3206: Wohnkosten
            bool freigegeben = (positionStatus != 1 && positionStatus != 12 && positionStatus != 14 && positionStatus != 15);
            int mask;

            if (qryBgPosition.Row != null && qryBgPosition.Row.RowState == DataRowState.Added)
            {
                if (kategorie == 101)
                    //Einzelzahlung
                    mask = 0x3CF; // Löschen, Betrag +/-, Neu, Text, Betrifft Person, Bemerkung, Betrag Rechnung
                else
                    mask = 0x3FF; // Löschen, Betrag +/-, Neu, Gruppe, Art, Text, Betrifft Person, Bemerkung, Betrag Rechnung
            }
            else
            {
                if (_isMasterbudget || (masterPosition && !wohnkostenPosition)) //#8510 Wohnkosten Positionen sollen mit der Monatsbudget-EditMask behandelt werden
                {
                    switch (kategorie)
                    {
                        case (int)LOV.BgKategorieCode.Abzahlung: // Abzahlungen
                        case (int)LOV.BgKategorieCode.Vorabzuege: // Vorabzug
                            mask = 0x146000;
                            break;

                        case (int)LOV.BgKategorieCode.Kuerzungen: // Kürzung
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
                        case (int)LOV.BgKategorieCode.Einzelzahlungen: //Einzelzahlung
                            mask = 0x3CF;
                            break;

                        case (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen: //Zusätzliche Leistung
                            if (freigegeben && DBUtil.IsEmpty(qryBgPosition["KbAuszahlungsArtCode"])) // Zusätzl. Leistung ohne Auszahlung
                                mask = 0x3FF3FF;
                            else
                                mask = monatsbudgetEditMask;
                            break;

                        case (int)LOV.BgKategorieCode.Abzahlung: // Abzahlungen
                        case (int)LOV.BgKategorieCode.Vorabzuege: // Vorabzug
                            mask = 0x146;
                            break;

                        case (int)LOV.BgKategorieCode.Kuerzungen: // Kürzung
                            mask = 0x1CF;
                            break;

                        default:
                            mask = monatsbudgetEditMask;
                            break;
                    }
                }

                if (freigegeben || masterPosition)
                    mask = (mask & 0xFFF000) / 0x1000; // shift nach rechts
                else
                    mask = (mask & 0x000FFF);
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

            //BetragRechnung soll wirklich die Monatsbudget

            _editMask.BetragRechnung = (mask & 0x200) == 0x200;
            _editMask.GruppeFilter = (mask & 0x400) == 0x400;

            _verfuegtVisible = (masterbudgetEditMask & 0x200000) > 0 ||
                               (monatsbudgetEditMask & 0x200200) > 0;

            _editMaskInfo =
                "Kategorie = " + kategorie + "\r\n" +
                "BudgetStatus = " + budgetStatus + "\r\n" +
                "PositionStatus = " + positionStatus + "\r\n" +
                "freigegeben = " + freigegeben + "\r\n" +
                "GruppeFilter = " + qryBgPosition["GruppeFilter"] + "\r\n\r\n" +

                "MasterbudgetEditMask = 0x" + masterbudgetEditMask.ToString("x") + "\r\n" +
                "MonatsbudgetEditMask = 0x" + monatsbudgetEditMask.ToString("x") + "\r\n" +
                "Mask = 0x" + mask.ToString("x") + "\r\n\r\n" +

                "EditMask.Loeschen\t\t" + _editMask.Loeschen + "\r\n" +
                "EditMask.BetragMinus\t" + _editMask.BetragMinus + "\r\n" +
                "EditMask.BetragPlus\t" + _editMask.BetragPlus + "\r\n" +
                "EditMask.Neu\t\t" + _editMask.Neu + "\r\n" +
                "EditMask.Gruppe\t\t" + _editMask.Gruppe + "\r\n" +
                "EditMask.Art\t\t" + _editMask.Art + "\r\n" +
                "EditMask.Text\t\t" + _editMask.Text + "\r\n" +
                "EditMask.BetrifftPerson\t" + _editMask.BetrifftPerson + "\r\n" +
                "EditMask.Bemerkung\t" + _editMask.Bemerkung + "\r\n" +
                "EditMask.BetragRechnung\t" + _editMask.BetragRechnung + "\r\n" +
                "EditMask.GruppeFilter\t" + _editMask.GruppeFilter;
        }

        private void SetPositionEditMode()
        {
            if (qryBgPosition.Count == 0 ||
                qryBgPosition.Row == null ||
                qryBgPosition.Row.RowState == DataRowState.Detached)
            {
                // wenn das Quey leer ist, müssen die Felder und Schalter auch ein/ausgeschaltet werden:
                DisablePositionElements();
                return;
            }

            try
            {
                var gruppierung = Utils.ConvertToBool(qryBgPosition["Gruppe"]) || Utils.ConvertToBool(qryBgPosition["Kategorie"]);
                var kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);

                if (gruppierung)
                {
                    DisablePositionElements();
                    return;
                }

                SetEditMask();

                //Position Löschen
                qryBgPosition.CanDelete = _editMask.Loeschen ? qryBgPosition.CanUpdate : false;

                //nicht editierbar, wenn
                //- qryBgPosition.CanUpdate == false
                //- Leistung abgeschlossen
                //- in einer nicht grauen/angefragten Position eines Monatsbudgets

                int bewilligungCode = ShUtil.GetCode(qryBgBudget["BgBewilligungStatusCode"]);
                int positionStatus = ShUtil.GetCode(qryBgPosition["Status"]);
                int positionStatusMin = ShUtil.GetCode(qryBgPosition["StatusMin"]);
                bool hauptDetailPos = !DBUtil.IsEmpty(qryBgPosition["DetailPos"]);

                bool editable = qryBgPosition.CanUpdate && !hauptDetailPos;
                bool auszahlungEditable;
                bool auszahlungFehlerhaft = (positionStatus == 5);

                if (_isMasterbudget)
                {
                    editable = (bewilligungCode == 5); //Anpassungen nur möglich im bewilligten Budget
                    auszahlungEditable = (bewilligungCode == 5); //Auszahlwege vorerst nur im bewilligten Masterbudget
                }
                else
                {
                    if ((kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen) && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"])) // Zusätzl. Leistung auf Spezialkonto
                    {
                        auszahlungEditable = editable;
                    }
                    else
                    {
                        editable &= (positionStatus == 1) || //In Vorbereitung (grau)
                                              (positionStatus == 12) || //angefragt (hellblau)
                                              (positionStatus == 14) || //bewilligt(hellblau)
                                              (positionStatus == 15) || //abgelehnt(hellblau)
                                              ((kategorie == (int)LOV.BgKategorieCode.Abzahlung) && (bewilligungCode < 5)) || // Abzahlung
                                              ((kategorie == (int)LOV.BgKategorieCode.Vorabzuege) && (bewilligungCode < 5)) || // Vorabzug
                                              ((kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen) && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"])); // Zusätzl. Leistung auf Spezialkonto
                        editable &= kategorie != (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen || ((BgBewilligungStatus)bewilligungCode != BgBewilligungStatus.Erteilt || positionStatus != 14);
                        auszahlungEditable = editable;
                    }
                }

                qryBgPosition.EnableBoundFields(editable);

                //Register
                tabZahlinfo.Visible = true;
                tpgDokumente.HideTab = (qryBgPosition.Row.RowState == DataRowState.Added);
                tpgBelege.HideTab = _isMasterbudget;

                tpgBgUebersicht.HideTab = _isMasterbudget;

                //Positionsbuttons
                if (_isMasterbudget)
                {
                    btnPositionGruen.Visible = false;
                    btnPositionGrau.Visible = false;
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
                        case (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen: //Zusatzleistung
                            btnPositionGruen.Visible = (bewilligungCode != 1) &&
                                                       (positionStatus == 14 ||
                                                        positionStatus == 7 ||
                                                        positionStatusMin == 7 ||
                                                        positionStatus == 5);  //bewilligt, rot, Zahlauftrag fehlerhaft
                            break;

                        case (int)LOV.BgKategorieCode.Ausgaben:	//Ausgabe
                        case (int)LOV.BgKategorieCode.Einzelzahlungen: //Einzelzahlung
                            // TODO : es muss noch geklärt werden, ob PositionStatus == 1 hier auch nötig ist.
                            btnPositionGruen.Visible = (bewilligungCode != 1) &&
                                                       (positionStatus == 1 ||
                                                        positionStatus == 14 ||
                                                        positionStatus == 7 ||
                                                        positionStatusMin == 7 ||
                                                        positionStatus == 5);  //grau, rot, Zahlauftrag fehlerhaft
                            break;

                        case (int)LOV.BgKategorieCode.Einnahmen:	//Einnahme
                            btnPositionGruen.Visible = (bewilligungCode != 1) && (positionStatus == 1);  //grau
                            break;

                        case (int)LOV.BgKategorieCode.Kuerzungen: //Sanktion/Kürzung
                        case (int)LOV.BgKategorieCode.Abzahlung: //Abzahlung
                            btnPositionGruen.Visible = false;
                            break;
                    }
                }

                //Positionsbutton Grau
                switch (kategorie)
                {
                    case (int)LOV.BgKategorieCode.Einnahmen:	//Einnahme
                        btnPositionGrau.Visible = (positionStatus == 2) && qryBgPosition["VerwaltungSD"] as bool? == true;  //grün
                        break;

                    case (int)LOV.BgKategorieCode.Einzelzahlungen: //Einzelzahlung
                        btnPositionGrau.Visible = (positionStatus == 2 && !DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]));  //grün
                        break;

                    case (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen: //Zusatzleistung
                        btnPositionGrau.Visible = (positionStatus == 2) && DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]);  //grün
                        break;

                    case (int)LOV.BgKategorieCode.Ausgaben:	//Ausgabe
                        bool dritte = !DBUtil.IsEmpty(qryBgPosition["Dri"]);
                        btnPositionGrau.Visible = (positionStatus == 2) && dritte;  //grün, nur an Dritte
                        break;

                    case (int)LOV.BgKategorieCode.Kuerzungen: //Sanktion/Kürzung
                    case (int)LOV.BgKategorieCode.Abzahlung: //Abzahlung
                        btnPositionGrau.Visible = false;
                        break;
                }

                //Positionsbutton Rot
                switch (kategorie)
                {
                    case (int)LOV.BgKategorieCode.Einnahmen:	//Einnahme
                        btnPositionRot.Visible = false;
                        break;

                    case (int)LOV.BgKategorieCode.Einzelzahlungen: //Einzelzahlung
                    case (int)LOV.BgKategorieCode.Ausgaben:	//Ausgabe
                        btnPositionRot.Visible = (positionStatus == 2 || positionStatusMin == 2);  //grün
                        break;

                    case (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen: //Zusatzleistung
                        btnPositionRot.Visible = (positionStatus == 2 || positionStatusMin == 2) && DBUtil.IsEmpty(qryBgPosition["BgSpezkontoID"]);  //grün ohne Spezkonto
                        break;

                    case (int)LOV.BgKategorieCode.Kuerzungen: //Sanktion/Kürzung
                    case (int)LOV.BgKategorieCode.Abzahlung: //Abzahlung
                        btnPositionRot.Visible = false;
                        break;
                }

                //Positionsbutton Bewilligung,Verlauf,Spezialkonto (//graue/angefragte/abgelehnte Zusatzleistung)
                btnPositionBewilligung.Visible = (kategorie == (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen &&
                    (positionStatus == 1 ||  // grau
                     positionStatus == 12 || // angefragt
                     positionStatus == 15 || // abgelehnt
                     (positionStatus == 14)));

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

                //Felder Kostenart, Buchungstext,Betrag,Betrifft Person,Bemerkung
                edtKostenart.EditMode = editable && (_editMask.Gruppe || _editMask.Art || _editMask.GruppeFilter) ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBuchungstext.EditMode = editable && _editMask.Text ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBetragBudget.EditMode = editable && (_editMask.BetragMinus || _editMask.BetragPlus) ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBaPersonID.EditMode = editable && _editMask.BetrifftPerson ? EditModeType.Normal : EditModeType.ReadOnly;
                edtBemerkung.EditMode = editable && _editMask.Bemerkung ? EditModeType.Normal : EditModeType.ReadOnly;

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
                        lblValutaDatum2.Visible = false;
                        edtDebitor.Visible = false;
                        lblDebitor.Visible = false;
                        edtReferenzNummer.EditMode = (es == 1) && (auszahlungEditable || auszahlungFehlerhaft) ? EditModeType.Normal : EditModeType.ReadOnly;
                        edtReferenzNummer.Visible = true;
                        lblReferenzNummer.Visible = true;
                        edtVerwaltungSD.Visible = false;
                        btnWeitereZahlinfos.Visible = (qryBgPosition.Row.RowState != DataRowState.Added) && (bool)qryBgPosition["Quoting"];

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

                        edtBgSpezkontoID.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;

                        if (auszahlungsArt == 101 || auszahlungsArt == 102)  //elektronisch || Papierverfügung
                        {
                            //Kreditor, ReferenzNr, Mitteilung mutierbar, wenn  PositionStatus = 5 (Zahlauftrag fehlerhaft)
                            edtKreditor.EditMode = (auszahlungEditable || auszahlungFehlerhaft) ? EditModeType.Normal : EditModeType.ReadOnly;
                            tpgMitteilung.HideTab = (es != 2) && (es != 3) && (es != 5); //roter ES
                            lblMitteilung.Visible = true;
                            lblZahlbarAn.Visible = false;
                            tpgMitteilung.Title = lblMitteilung.Text;
                            edtMitteilungZeile1.EditMode = auszahlungEditable || auszahlungFehlerhaft ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtMitteilungZeile2.EditMode = auszahlungEditable || auszahlungFehlerhaft ? EditModeType.Normal : EditModeType.ReadOnly;
                            edtMitteilungZeile3.EditMode = auszahlungEditable || auszahlungFehlerhaft ? EditModeType.Normal : EditModeType.ReadOnly;
                        }
                        else if (auszahlungsArt == 103) //bar
                        {
                            edtKreditor.EditMode = EditModeType.ReadOnly;
                            tpgMitteilung.HideTab = false;
                            lblMitteilung.Visible = false;
                            lblZahlbarAn.Visible = true;
                            tpgMitteilung.Title = lblZahlbarAn.Text;
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

                    case 1:	//Einnahme
                        edtBgSpezkontoID.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
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
                        edtVerwaltungSD.EditMode = auszahlungEditable ? EditModeType.Normal : EditModeType.ReadOnly;
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
                        edtBgSpezkontoID.EditMode = EditModeType.ReadOnly;
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
                KissMsg.ShowError(Name, "FehlerSetEditMode", "Fehler in SetEditMode: " + ex.Message, null, ex, 0, 0, null);
            }
        }

        private void SetSpezialkonto()
        {
            object bgSpezKontoId = qryBgPosition["BgSpezKontoID"];

            int kategorie = (int)qryBgPosition["BgKategorieCode"];
            switch (kategorie)
            {
                case (int)LOV.BgKategorieCode.Ausgaben:   //Ausgabe
                case (int)LOV.BgKategorieCode.Zusaetzliche_Leistungen: //Zusatzleistung
                    if (!DBUtil.IsEmpty(bgSpezKontoId))
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

                case (int)LOV.BgKategorieCode.Einzelzahlungen:  //Einzelzahlung
                    qryBgPosition[DBO.BgPosition.BgPositionsartID] = GetFieldFromSpezkonto(bgSpezKontoId, DBO.BgPosition.BgPositionsartID);
                    qryBgPosition["Kostenart"] = GetFieldFromSpezkonto(bgSpezKontoId, "KOAPositionsart");
                    if (DBUtil.IsEmpty(qryBgPosition["Buchungstext"]))
                    {
                        qryBgPosition["Buchungstext"] = GetFieldFromSpezkonto(bgSpezKontoId, "Text");
                    }
                    qryBgPosition["BgSplittingArtCode"] = GetFieldFromSpezkonto(bgSpezKontoId, "BgSplittingArtCode");
                    qryBgPosition["ProPerson"] = GetFieldFromSpezkonto(bgSpezKontoId, "ProPerson");
                    qryBgPosition["ProUE"] = GetFieldFromSpezkonto(bgSpezKontoId, "ProUE");
                    SetVerwendungsPeriode();

                    qryBgPosition["KreditorEingeschraenkt"] = GetFieldFromSpezkonto(bgSpezKontoId, "KreditorEingeschraenkt");

                    object baPersonId = GetFieldFromSpezkonto(bgSpezKontoId, "BaPersonID");
                    if (!DBUtil.IsEmpty(baPersonId))
                        qryBgPosition["BaPersonID"] = baPersonId;

                    //falls Spezialkonto an eine Institution gebunden ist: Zahlweg einrichten
                    object baInstitutionId = GetFieldFromSpezkonto(bgSpezKontoId, "BaInstitutionID");
                    if (!DBUtil.IsEmpty(baInstitutionId))
                    {
                        SqlQuery qry = DBUtil.OpenSQL("SELECT * FROM vwKreditor WHERE BaInstitutionID = {0}", baInstitutionId);
                        if (qry.Count == 1)
                        {
                            qryBgPosition["Kreditor"] = qry["Kreditor"];
                            qryBgPosition["ZusatzInfo"] = qry["ZusatzInfo"];
                            qryBgPosition["BaZahlungswegID"] = qry["BaZahlungswegID"];
                            qryBgPosition["EinzahlungsscheinCode"] = qry["EinzahlungsscheinCode"];

                            if ((int)qryBgPosition["EinzahlungsscheinCode"] != 1) // != oranger ES
                                qryBgPosition["ReferenzNummer"] = DBNull.Value;
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
            qryBgPosition.RefreshDisplay();
        }

        private void SetTexts()
        {
            colKontoNr.Caption = "KoA";
            lblKostenart.Text = "KoA/Positionsart";
            edtVerwaltungSD.Text = "Verwaltung SD";
            colBeleg_PSCDBelegNummer.Caption = "BelegNr";
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
            if (DBUtil.IsEmpty(s) || !(s is String))
            {
                return s;
            }

            if (s.ToString().Length > maxLength)
            {
                return s.ToString().Substring(0, maxLength);
            }

            return s;
        }

        #endregion

        #endregion
    }
}