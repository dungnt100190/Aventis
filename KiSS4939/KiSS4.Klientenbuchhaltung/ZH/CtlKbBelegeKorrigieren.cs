using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;
using SharpLibrary.WinControls;

namespace KiSS4.Klientenbuchhaltung.ZH
{
    public partial class CtlKbBelegeKorrigieren : KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        private readonly SqlQuery _qryKbBuchungBrutto;
        private readonly SqlQuery _qryKbBuchungBruttoPerson;
        private BelegeKorrigierenHelper _belegeKorrigierenHelper;

        #endregion Private Fields

        #endregion Fields

        #region Constructors

        public CtlKbBelegeKorrigieren()
        {
            _qryKbBuchungBrutto = BelegeKorrigierenHelper.GetQryKbBuchungBrutto();
            _qryKbBuchungBrutto.HostControl = this;
            _qryKbBuchungBrutto.TableName = "KbBuchungBruttoPerson";
            _qryKbBuchungBrutto.AfterDelete += qryKbBuchungBrutto_AfterDelete;
            _qryKbBuchungBrutto.BeforeDeleteQuestion += qryKbBuchungBrutto_BeforeDeleteQuestion;
            _qryKbBuchungBrutto.PositionChanged += qryKbBuchungBrutto_PositionChanged;
            _qryKbBuchungBrutto.PositionChanging += qryKbBuchungBrutto_PositionChanging;

            _qryKbBuchungBruttoPerson = BelegeKorrigierenHelper.GetQryKbBuchungBruttoPerson();
            _qryKbBuchungBruttoPerson.HostControl = this;

            InitializeComponent();

            SetDataSource();
        }

        #endregion Constructors

        #region EventHandlers

        private void btnAusführen_Click(object sender, EventArgs e)
        {
            if (!_belegeKorrigierenHelper.ValidateBeforeProcessStart())
            {
                return;
            }

            // Fortschrittsanzeige (ohne Cancel-Möglichkeit)
            DlgProgressLog.Show("Beleg stornieren", false, 700, 500, ProgressStart, ProgressEnd, Session.MainForm);
        }

        private void btnHaushalt_Click(object sender, EventArgs e)
        {
            if (_belegeKorrigierenHelper.SelectHaushalt() < 0)
            {
                return;
            }

            _belegeKorrigierenHelper.RecreateDetailBuchungen(true);
        }

        private void btnSprungMonatsbudget_Click(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryKbBuchungBruttoSuche["BgBudgetID"]))
            {
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT FAL.BaPersonID, FLE.ModulID, NodeID = 'CtlWhFinanzplan' + CONVERT(varchar, BFP.BgFinanzplanID) + '\BBG' + CONVERT(varchar, BBG.BgBudgetID)
                    FROM BgBudget              BBG
                      INNER JOIN BgFinanzplan  BFP ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
                      INNER JOIN FaLeistung    FLE ON FLE.FaLeistungID = BFP.FaLeistungID
                      INNER JOIN FaFall        FAL ON FAL.FaFallID = FLE.FaFallID
                    WHERE BBG.BgBudgetID = {0}",
                    qryKbBuchungBruttoSuche["BgBudgetID"]);

                if (qry.Count == 1)
                {
                    FormController.OpenForm(
                        "FrmFall",
                        "Action",
                        "JumpToPath",
                        "BaPersonID",
                        qry["BaPersonID"],
                        "ModulID",
                        qry["ModulID"],
                        "NodeID",
                        qry["NodeID"]);
                }
            }
        }

        private void CtlKbBelegeKorrigieren_Load(object sender, EventArgs e)
        {
            _belegeKorrigierenHelper = new BelegeKorrigierenHelper(
                this,
                qryKbBuchungBruttoSuche,
                _qryKbBuchungBrutto,
                _qryKbBuchungBruttoPerson,
                edtValutaDatum,
                edtBetrag,
                edtAbtretung,
                edtVerwPeriodeVon,
                edtVerwPeriodeBis,
                edtBgKostenartID,
                edtLT,
                edtBetrifftPerson,
                edtTextVariabel,
                EnableControls,
                false);

            //Buchungsstati laden
            KbBuchungStatusHelper.AddBuchungStatusToRepositoryItems(
                new List<RepositoryItemImageComboBox> { repositoryItemImageComboBox1, repositoryItemImageComboBox2, repositoryItemImageComboBox3 });

            tabControlSearch.SelectTab(tpgSuchen);
        }

        private void edtAbretung_EditValueChanged(object sender, EventArgs e)
        {
            if (edtAbtretung.UserModified)
            {
                _belegeKorrigierenHelper.Abtretung_ValueChanged();
            }
        }

        private void edtBetrag_Leave(object sender, EventArgs e)
        {
            _belegeKorrigierenHelper.CheckBetrag();
        }

        private void edtBetrifftPerson_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            var isSiLei = qryKbBuchungBruttoSuche["PscdKennzeichen"] as string == "S";
            _belegeKorrigierenHelper.BetrifftPersonUserModifiedField(e, isSiLei);
        }

        private void edtBgKostenartID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            _belegeKorrigierenHelper.KostenartUserModifiedField(e, btnHaushalt, true);
        }

        private void edtLT_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            _belegeKorrigierenHelper.LeistungstraegerUserModifiedField(e);
        }

        private void edtSucheBetrifftPerson_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheBetrifftPerson.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheBetrifftPerson.EditValue = DBNull.Value;
                    edtSucheBetrifftPerson.LookupID = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT
                  ID = PRS.BaPersonID,
                  PRS.Name,
                  PRS.Vorname,
                  BaPersonID$ = PRS.BaPersonID,
                  NameVorname$ = PRS.NameVorname + ' (' + CONVERT(VARCHAR, PRS.BaPersonID) + ')'
                FROM dbo.vwPerson PRS
                WHERE (PRS.NameVorname LIKE '%' + {0} + '%' OR CAST(PRS.BaPersonID AS VARCHAR) = {0})
                  AND BaPersonID IN (SELECT FPP.BaPersonID
                                     FROM dbo.BgFinanzplan_BaPerson FPP
                                       INNER JOIN dbo.BgFinanzplan  FPL ON FPL.BgFinanzplanID = FPP.BgFinanzplanID
                                       INNER JOIN dbo.FaLeistung    LEI ON LEI.FaLeistungID = FPL.FaLeistungID
                                     WHERE LEI.FaProzessCode = 300 AND /*FPP.BaPersonID = PRS.BaPersonID AND*/ IstUnterstuetzt = 1
                                       AND ({1} IS NULL OR LEI.BaPersonID = {1}))
                ORDER BY PRS.Name, PRS.Vorname",
                searchString,
                e.ButtonClicked,
                edtSucheLT.LookupID);

            if (!e.Cancel)
            {
                edtSucheBetrifftPerson.EditValue = dlg["NameVorname$"];
                edtSucheBetrifftPerson.LookupID = dlg["BaPersonID$"];
            }
        }

        private void edtSucheBgKostenartID_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheBgKostenartID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheBgKostenartID.EditValue = DBNull.Value;
                    edtSucheBgKostenartID.LookupID = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT
                  KontoNr,
                  Name,
                  BgKostenartID$ = BgKostenartID,
                  KontoNrName$   = KontoNr + ' ' + Name
                FROM BgKostenart
                WHERE ModulID = 3 AND (KontoNr LIKE '%' + {0} + '%' OR Name LIKE '%' + {0} + '%')
                ORDER BY KontoNr, Name",
                searchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSucheBgKostenartID.EditValue = dlg["KontoNrName$"];
                edtSucheBgKostenartID.LookupID = dlg["BgKostenartID$"];
            }
        }

        private void edtSucheLT_UserModifiedFld(object sender, UserModifiedFldEventArgs e)
        {
            string searchString = edtSucheLT.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    edtSucheLT.EditValue = DBNull.Value;
                    edtSucheLT.LookupID = DBNull.Value;
                    return;
                }
            }

            var dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT
                  ID = PRS.BaPersonID,
                  PRS.DisplayText,
                  BaPersonID$ = PRS.BaPersonID,
                  NameVorname$ = PRS.NameVorname
                FROM dbo.vwPerson PRS
                WHERE (PRS.NameVorname LIKE '%' + {0} + '%' OR CAST(PRS.BaPersonID as varchar) = {0})
                  AND EXISTS (SELECT BaPersonID
                              FROM dbo.FaLeistung           LEI
                                INNER JOIN dbo.BgFinanzplan BFP ON BFP.FaLeistungID = LEI.FaLeistungID
                              WHERE BaPersonID = PRS.BaPersonID AND FaProzessCode = 300)
                ORDER BY PRS.Name, PRS.Vorname",
                searchString,
                e.ButtonClicked);

            if (!e.Cancel)
            {
                edtSucheLT.EditValue = dlg["NameVorname$"];
                edtSucheLT.LookupID = dlg["BaPersonID$"];
                edtSucheBetrifftPerson.EditValue = DBNull.Value;
                edtSucheBetrifftPerson.LookupID = DBNull.Value;
            }
        }

        private void edtTextVariabel_Leave(object sender, EventArgs e)
        {
            _belegeKorrigierenHelper.CheckTextVariabel();
        }

        private void edtVerwPeriodeBis_Leave(object sender, EventArgs e)
        {
            _belegeKorrigierenHelper.CheckVerwPeriodeBis();
        }

        private void edtVerwPeriodeVon_Leave(object sender, EventArgs e)
        {
            _belegeKorrigierenHelper.CheckVerwPeriodeVon();
        }

        private void qryKbBuchungBrutto_AfterDelete(object sender, EventArgs e)
        {
            _qryKbBuchungBrutto.DataTable.AcceptChanges();
        }

        private void qryKbBuchungBrutto_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            if ((int)_qryKbBuchungBrutto["KbBuchungStatusCode"] != 1 || (bool)_qryKbBuchungBrutto["Storno"])
            {
                // Nur graue NEU-Belege können gelöscht werden. Dies ist entweder ein Status <> 1 oder ein Storno-Beleg
                throw new KissInfoException("Nur graue NEU-Belege können gelöscht werden.");
            }
        }

        private void qryKbBuchungBrutto_PositionChanged(object sender, EventArgs e)
        {
            if (_belegeKorrigierenHelper.Inserting)
            {
                return;
            }

            if (_qryKbBuchungBrutto.DataTable.Rows.Count == 0)
            {
                return;
            }

            if (DBUtil.IsEmpty(_qryKbBuchungBrutto["KbBuchungBruttoID"]))
            {
                return;
            }

            _qryKbBuchungBruttoPerson.Fill((int)_qryKbBuchungBrutto["KbBuchungBruttoID"]);

            if ((bool)_qryKbBuchungBrutto["Storno"])
            {
                tabKorrekturKopf.Title = "STO Belegkopf";
                tabKorrekturDetailBuchungen.Title = "STO Belegpositionen";
            }
            else
            {
                tabKorrekturKopf.Title = "NEU Belegkopf";
                tabKorrekturDetailBuchungen.Title = "NEU Belegpositionen";
            }

            EnableControls();
        }

        private void qryKbBuchungBrutto_PositionChanging(object sender, EventArgs e)
        {
            if (_qryKbBuchungBrutto.DataTable.Rows.Count == 0)
            {
                return;
            }

            bool checkSuccessfull;

            try
            {
                checkSuccessfull = _belegeKorrigierenHelper.CheckRow();
            }
            catch (KissCancelException ex)
            {
                ex.ShowMessage();
                throw new Exception();
            }

            if (!checkSuccessfull)
            {
                throw new Exception();
            }
        }

        private void qryKbBuchungBruttoSuche_PositionChanged(object sender, EventArgs e)
        {
            try
            {
                _belegeKorrigierenHelper.ChangingData = true;
                btnSprungMonatsbudget.Enabled = qryKbBuchungBruttoSuche.Count > 0 && !DBUtil.IsEmpty(qryKbBuchungBruttoSuche["BgBudgetID"]);

                grdKbBuchungBruttoPerson.DataSource = null;
                _qryKbBuchungBrutto.Fill(qryKbBuchungBruttoSuche["KbBuchungBruttoID"], 0);
                grdKbBuchungBruttoPerson.DataSource = _qryKbBuchungBrutto;

                _belegeKorrigierenHelper.KbBuchungBruttoIDsWithExistingDetailPositions = new List<int>();

                bool detailDataLoaded = false;
                foreach (DataRow row in _qryKbBuchungBrutto.DataTable.Rows)
                {
                    if (!DBUtil.IsEmpty(row["KbBuchungBruttoID"]))
                    {
                        int id = (int)row["KbBuchungBruttoID"];
                        if (BelegeKorrigierenTemporaryTableHelper.LoadDetailsIntoTemporaryKbBuchungBruttoPersonTable(id) > 0)
                        {
                            // Es wurde mind. eine Detailposition geladen, d.h. es gibt OriginalPositionen. Füge die ID in die Liste der noch nicht geänderten Belege ein
                            detailDataLoaded = true;
                            _belegeKorrigierenHelper.KbBuchungBruttoIDsWithExistingDetailPositions.Add(id);
                        }
                    }
                }

                if (!detailDataLoaded)
                {
                    _qryKbBuchungBruttoPerson.DataTable.Clear();
                }
                else
                {
                    _qryKbBuchungBruttoPerson.Fill((int)_qryKbBuchungBrutto["KbBuchungBruttoID"]);
                }
            }
            finally
            {
                _belegeKorrigierenHelper.ChangingData = false;
            }

            bool isSiLei = qryKbBuchungBruttoSuche["PscdKennzeichen"] as string == "S";
            edtLT.Visible = !isSiLei;
            lblKlient.Visible = !isSiLei;
        }

        private void qryKbBuchungBruttoSuche_PositionChanging(object sender, EventArgs e)
        {
            bool buchungBereitsStorniert = (int)qryKbBuchungBruttoSuche["KbBuchungstatusCode"] == 8; // Storno

            if (!buchungBereitsStorniert && _qryKbBuchungBrutto.DataTable.Rows.Count > 0 &&
                !KissMsg.ShowQuestion("CtlKbBelegeKorrigieren", "DatensatzWechseln", "Wollen Sie die gemachten Änderungen verwerfen?"))
            {
                throw new Exception();
            }
        }

        private void tabControlSearch_SelectedTabChanged(TabPageEx page)
        {
            if (page == tpgListe)
            {
                try
                {
                    DataSet ds = qryKbBuchungBruttoSuche.DataSet;
                    ds.Relations.Add(
                        "BelegDetail",
                        ds.Tables[0].Columns["KbBuchungBruttoID"],
                        ds.Tables[1].Columns["KbBuchungBruttoID"]);
                    grvKbBuchungBruttoSuche.CollapseAllDetails();
                }
                catch (Exception ex)
                {
                    // Wir ignorieren diese Exception
                    Trace.WriteLine("CtlKbBelegeKorrigieren.tabControlSearch_SelectedTabChanged: Exception abgefangen: " + ex.Message);
                }
            }
        }

        private void tabControlSearch_SelectedTabChanging(object sender, CancelEventArgs e)
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                // Wir wechseln von Suchen zur Liste => Validiere Suchkriterien

                // Prüfe, ob mind. ein genügendes Suchkriterium eingegeben wurde
                if (DBUtil.IsEmpty(edtSucheFallNr.EditValue) &&
                    DBUtil.IsEmpty(edtSucheBelegNr.EditValue) &&
                    DBUtil.IsEmpty(edtSucheBetrifftPerson.EditValue) &&
                    DBUtil.IsEmpty(edtSucheLT.EditValue) &&
                    DBUtil.IsEmpty(edtSucheBgKostenartID.EditValue) &&
                    DBUtil.IsEmpty(edtSucheBetrag.EditValue))
                {
                    KissMsg.ShowInfo("Um die Suche genügend einzuschränken, müssen Sie mind. den Fall, den Beleg, die Person oder den Betrag angeben");
                    throw new KissCancelException();
                }

                try
                {
                    _belegeKorrigierenHelper.ChangingData = true;
                }
                finally
                {
                    _belegeKorrigierenHelper.ChangingData = false;
                }

                tabKorrekturKopf.Title = "STO/NEU Belegkopf";
                tabKorrekturDetailBuchungen.Title = "STO/NEU Positionen";
            }
        }

        #endregion EventHandlers

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            if (!_belegeKorrigierenHelper.OnAddData())
            {
                return false;
            }

            qryKbBuchungBrutto_PositionChanged(null, EventArgs.Empty);
            edtValutaDatum.Focus();

            return true;
        }

        public override bool OnDeleteData()
        {
            if (_qryKbBuchungBrutto.Row.RowState == DataRowState.Added)
            {
                if (_qryKbBuchungBrutto["textFix"].ToString().StartsWith("STO"))
                {
                    KissMsg.ShowInfo("Der STO-Beleg kann nicht gelöscht werden.");
                    return false;
                }
            }

            if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["TransferDatum"]))
            {
                KissMsg.ShowInfo("Dieser Korrekturbeleg kann nicht mehr gelöscht werden, da er bereits ins PSCD transferiert wurde.");
                return false;
            }

            return _qryKbBuchungBrutto.Delete();
        }

        public override bool OnSaveData()
        {
            return _belegeKorrigierenHelper.CheckAndSaveUmbuchungBuchung();
        }

        #endregion Public Methods

        #region Private Methods

        private void EnableControls()
        {
            bool storno = (bool)_qryKbBuchungBrutto["Storno"];

            bool quoting = (bool)_qryKbBuchungBrutto["Quoting"];

            bool buchungReadonly = _belegeKorrigierenHelper.IsBuchungBruttoReadonly;
            var mode = _belegeKorrigierenHelper.IsBuchungBruttoEditable ? EditModeType.Normal : EditModeType.ReadOnly;

            foreach (Control ctrl in UtilsGui.AllControls(this))
            {
                if (ctrl is IKissEditable &&
                    (ctrl.Parent == tabKorrekturKopf || ctrl.Parent == tabKorrekturDetailBuchungen) &&
                    ctrl != edtHauptvorgang &&
                    ctrl != edtTeilvorgang &&
                    ctrl != edtAbtretung &&
                    ctrl != edtValutaDatum &&
                    ctrl != edtSplittingart &&
                    ctrl != edtTextFix &&
                    ctrl != edtFaFallID &&
                    ctrl != edtFaLeistungID)
                {
                    ((IKissEditable)ctrl).EditMode = mode;
                }
            }

            edtTextVariabel.EditMode = mode;

            btnAusführen.Enabled = !buchungReadonly;

            if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["BgSplittingartCode"]))
            {
                int art = (int)_qryKbBuchungBrutto["BgSplittingartCode"];
                int originalArt = 0;
                if (!DBUtil.IsEmpty(qryKbBuchungBruttoSuche["BgSplittingArtCode"]))
                {
                    originalArt = (int)qryKbBuchungBruttoSuche["BgSplittingArtCode"];
                }

                bool editableLAs = false;
                if (!DBUtil.IsEmpty(_qryKbBuchungBrutto["KontoNr"]))
                {
                    int konto = int.Parse((string)_qryKbBuchungBrutto["KontoNr"]);

                    if (art == 3 && (konto == 751 || konto == 752)) // art 3 = Splittingart V Valuta
                    {
                        editableLAs = true; // Spezialfalls #6526: Trotz Splittingart V dürfen die Verwendungsperioden der beiden LAs 751 oder 752 verändert werden
                    }
                }

                edtVerwPeriodeVon.EditMode = storno || buchungReadonly || (art == 3 && originalArt == 3 && !editableLAs) ? EditModeType.ReadOnly : EditModeType.Normal;
                edtVerwPeriodeBis.EditMode = storno || buchungReadonly || (art == 3 && !editableLAs) || (art == 4) ? EditModeType.ReadOnly : EditModeType.Normal;
            }

            // Spezialfall Quoting
            edtBetrifftPerson.EditMode = storno || buchungReadonly || quoting ? EditModeType.ReadOnly : EditModeType.Normal;
            edtValutaDatum.EditMode = buchungReadonly ? EditModeType.ReadOnly : EditModeType.Normal;

            edtTextFix.Visible = !buchungReadonly;

            if (buchungReadonly)
            {
                edtValutaDatum.EditValue = _qryKbBuchungBrutto["ValutaDatum"];
            }

            _belegeKorrigierenHelper.EnableHaushaltButton(btnHaushalt);

            //edtAbtretung.EditMode analog edtBetrag aber nie Editierbar für Storno-Buchungen
            edtAbtretung.EditMode = storno ? EditModeType.ReadOnly : mode;
        }

        private void ProgressEnd()
        {
            if (_belegeKorrigierenHelper.UpdateWasSuccessfull)
            {
                qryKbBuchungBruttoSuche.Refresh();

                try
                {
                    DataSet ds = qryKbBuchungBruttoSuche.DataSet;
                    ds.Relations.Clear();
                    ds.Relations.Add(
                        "BelegDetail",
                        ds.Tables[0].Columns["KbBuchungBruttoID"],
                        ds.Tables[1].Columns["KbBuchungBruttoID"]);
                    grvKbBuchungBruttoSuche.CollapseAllDetails();
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("CtlKbBelegeKorrigieren.ProgressEnd: Exception abgefangen: " + ex.Message);
                }

                qryKbBuchungBruttoSuche_PositionChanged(null, EventArgs.Empty);
            }
        }

        private void ProgressStart()
        {
            _belegeKorrigierenHelper.ProgressStart();
        }

        private void SetDataSource()
        {
            edtTextVariabel.DataSource = _qryKbBuchungBrutto;
            edtTextFix.DataSource = _qryKbBuchungBrutto;
            edtSplittingart.DataSource = _qryKbBuchungBrutto;
            edtFaFallID.DataSource = _qryKbBuchungBrutto;
            edtBetrag.DataSource = _qryKbBuchungBrutto;
            edtVerwPeriodeBis.DataSource = _qryKbBuchungBrutto;
            edtVerwPeriodeVon.DataSource = _qryKbBuchungBrutto;
            edtAbtretung.DataSource = _qryKbBuchungBrutto;
            edtTeilvorgang.DataSource = _qryKbBuchungBrutto;
            edtHauptvorgang.DataSource = _qryKbBuchungBrutto;
            edtBgKostenartID.DataSource = _qryKbBuchungBrutto;
            edtBetrifftPerson.DataSource = _qryKbBuchungBrutto;
            edtLT.DataSource = _qryKbBuchungBrutto;
            grdKbBuchungBruttoPerson.DataSource = _qryKbBuchungBrutto;
            edtFaLeistungID.DataSource = _qryKbBuchungBrutto;
            kissGrid1.DataSource = _qryKbBuchungBruttoPerson;
        }

        #endregion Private Methods

        #endregion Methods
    }
}