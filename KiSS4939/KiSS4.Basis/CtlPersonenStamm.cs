using System;
using System.Drawing;
using System.Windows.Forms;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    public partial class CtlPersonenStamm : KissSearchUserControl
    {
        private const string CLASSNAME = "CtlPersonenStamm";

        #region Constructors

        public CtlPersonenStamm()
        {
            InitializeComponent();

            /*
            ctlBaPerson = new CtlBaPerson();
            pnlDemographie.Controls.Add(this.ctlBaPerson);
            */

            ctlBaPerson.tabWohnsituation.HideTab = true;

            tabControlSearch.SelectedTabIndex = tpgSuchen.TabIndex;

            //EditMode ctlBaPerson
            /*
            ctlBaPerson.ctlZahlungsweg.qryBaZahlungsweg.CanInsert = false;
            ctlBaPerson.ctlZahlungsweg.qryBaZahlungsweg.CanUpdate = false;
            ctlBaPerson.ctlZahlungsweg.qryBaZahlungsweg.CanDelete = false;
            ctlBaPerson.ctlZahlungsweg.edtDatumVon.EditMode = EditModeType.ReadOnly;
            ctlBaPerson.ctlZahlungsweg.edtDatumBis.EditMode = EditModeType.ReadOnly;
            ctlBaPerson.ctlZahlungsweg.edtEinzahlungsschein.EditMode = EditModeType.ReadOnly;
            ctlBaPerson.ctlZahlungsweg.edtPostkontoNr.EditMode = EditModeType.ReadOnly;
            ctlBaPerson.ctlZahlungsweg.edtBankkontoNr.EditMode = EditModeType.ReadOnly;
            ctlBaPerson.ctlZahlungsweg.edtBankPost.EditMode = EditModeType.ReadOnly;
            ctlBaPerson.ctlZahlungsweg.edtIBAN.EditMode = EditModeType.ReadOnly;
            ctlBaPerson.ctlZahlungsweg.edtReferenz.EditMode = EditModeType.ReadOnly;
            */

            colNationalitaet.ColumnEdit = grdBaPerson.GetLOVLookUpEdit("BaLand");

            FrmPersonenStamm_Shown(this, new EventArgs());
        }

        #endregion

        #region EventHandlers

        private void btnFallInfo_Click(object sender, EventArgs e)
        {
            FormController.ShowDialogOnMain("FrmFallInfo", qryBaPerson["BaPersonID"], true);
        }

        private void FrmPersonenStamm_Shown(object sender, EventArgs e)
        {
            edtName.Focus();
        }

        private void qryBaPerson_AfterDelete(object sender, EventArgs e)
        {
            Session.Commit();
        }

        private void qryBaPerson_AfterFill(object sender, EventArgs e)
        {
            lblRowCount.Text = qryBaPerson.Count.ToString();
        }

        private void qryBaPerson_BeforeDelete(object sender, EventArgs e)
        {
            DBUtil.NewHistoryVersion();

            Session.BeginTransaction();

            DeleteDependencies();
        }

        private void qryBaPerson_BeforeDeleteQuestion(object sender, EventArgs e)
        {
            CheckDependencies();
        }

        private void qryBaPerson_PositionChanged(object sender, EventArgs e)
        {
            ctlBaPerson.ActiveSQLQuery.Post();
            var baPersonID = qryBaPerson[DBO.BaPerson.BaPersonID] as int?;
            if (baPersonID.HasValue)
            {
                ctlBaPerson.BaPersonID = baPersonID.Value;
                ctlGotoFall.BaPersonID = baPersonID.Value;
            }
        }

        private void qryBaPerson_PositionChanging(object sender, EventArgs e)
        {
            //##4641: Datensatz nicht wechseln wenn nicht gespeichert werden kann
            if (!ctlBaPerson.ctlBaPersonWV.ActiveSQLQuery.Post())
            {
                throw new KissCancelException();
            }
            if (!ctlBaPerson.ctlZahlungsweg.ActiveSQLQuery.Post())
            {
                throw new KissCancelException();
            }
            if (!ctlBaPerson.ActiveSQLQuery.Post())
            {
                throw new KissCancelException();
            }
        }

        private void tabControlSearch_SizeChanged(object sender, EventArgs e)
        {
            RelocateInfoControls();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool ReceiveMessage(System.Collections.Specialized.HybridDictionary parameters)
        {
            // we need at least one parameter to know what to do
            if (parameters == null || parameters.Count < 1)
            {
                // by default, nothing to do
                return true;
            }

            if (!qryBaPerson.Post())
                return false;

            // action depending
            switch (parameters["Action"] as string)
            {
                case "ShowPerson":
                case "JumpToPath":
                    // Show Fall with person, modulcode and optional personname
                    NewSearch();
                    edtBaPersonID.EditValue = parameters["BaPersonID"];
                    RunSearch();
                    tabControlSearch.SelectTab(tpgListe);
                    return true;
            }

            // did not understand message
            return base.ReceiveMessage(parameters);
        }

        /// <summary>
        /// Handle messages from FormController
        /// </summary>
        /// <param name="param">Specific messages as key/value pair for current form</param>
        /// <returns>Specified object that has to be returned to sender</returns>
        public override object ReturnMessage(System.Collections.Specialized.HybridDictionary param)
        {
            // we need at least one parameter to know what to do
            if (param.Count < 1)
            {
                // by default, nothing to do
                return null;
            }

            // action depending
            switch (param["Action"] as string)
            {
                case "GetJumpToPath":
                    System.Collections.Specialized.HybridDictionary dic = new System.Collections.Specialized.HybridDictionary();
                    dic["ClassName"] = "FrmPersonenStamm";
                    dic["BaPersonID"] = qryBaPerson["BaPersonID"];
                    return dic;
            }

            // did not understand message
            return base.ReturnMessage(param);
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();
            edtName.Focus();
        }

        protected override void RunSearch()
        {
            Cursor.Current = Cursors.WaitCursor;
            qryBaPerson.Fill((Session.User.IsUserKA ? 0 : 1), Session.User.LanguageCode);
            Cursor.Current = Cursors.Default;
        }

        #endregion

        #region Private Methods

        private void CheckDependencies()
        {
            // Es können verschiedenste Abhängigkeiten existieren.
            // Wir prüfen zumindest diejenigen auf der gleichen Maske: Zahlungsverbindung + WV
            int count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.BaZahlungsweg WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}",
                qryBaPerson["BaPersonID"]);

            if (count > 0)
            {
                // Zurzeit werden in SqlQuery.OnBeforeDelete() sämtliche Exceptions geschluckt. Deshalb muss die Fehlermeldung hier
                // mittels KissMsg angezeigt werden. Sollte dies mal refactored werden, so dass auftretende KissCancelExceptions
                // nicht mehr geschluckt und angezeigt werden, muss dieses KissMsg.ShowInfo entfernt werden.
                var message = KissMsg.GetMLMessage(CLASSNAME, "QryBaPersonKannNichtLoeschenZahlungsverbindung", "Person kann nicht gelöscht werden. Es existieren noch Zahlungsverbindungen.", KissMsgCode.MsgInfo);
                KissMsg.ShowInfo(message);
                throw new KissCancelException(message);
            }

            count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.BaWVCode WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}",
                qryBaPerson["BaPersonID"]);

            if (count > 0)
            {
                var message = KissMsg.GetMLMessage(CLASSNAME, "QryBaPersonKannNichtLoeschenBaWVCode", "Person kann nicht gelöscht werden. Es existieren noch WVCodes.", KissMsgCode.MsgInfo);
                KissMsg.ShowInfo(message);
                throw new KissCancelException(message);
            }

            // Zusätzlich werden noch Leistungen und Pendenzen geprüft,
            // da die Wahrscheinlichkeit dieser Abhängigkeiten hoch ist
            count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.FaLeistung WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}",
                qryBaPerson["BaPersonID"]);

            if (count > 0)
            {
                var message = KissMsg.GetMLMessage(CLASSNAME, "QryBaPersonKannNichtLoeschenFaLeistung", "Person kann nicht gelöscht werden. Es existiert noch eine Leistung.", KissMsgCode.MsgInfo);
                KissMsg.ShowInfo(message);
                throw new KissCancelException(message);
            }

            count = (int)DBUtil.ExecuteScalarSQL(@"
                SELECT COUNT(*)
                FROM dbo.XTask WITH (READUNCOMMITTED)
                WHERE BaPersonID = {0}
                  AND NOT (TaskSenderCode = 4   -- Newod
                        OR TaskStatusCode = 3); -- Erledigt",
                qryBaPerson["BaPersonID"]);

            if (count > 0)
            {
                var message = KissMsg.GetMLMessage(CLASSNAME, "QryBaPersonKannNichtLoeschenPendenzen", "Person kann nicht gelöscht werden. Es existieren noch Pendenzen.", KissMsgCode.MsgInfo);
                KissMsg.ShowInfo(message);
                throw new KissCancelException(message);
            }
        }

        private void DeleteDependencies()
        {
            // Pendenzen löschen
            DBUtil.ExecuteScalarSQL(@"
                DELETE FROM dbo.XTask
                WHERE BaPersonID = {0}",
                qryBaPerson[DBO.BaPerson.BaPersonID]);

            // Verknüpfung mit Kostenstelle löschen
            DBUtil.ExecuteScalarSQL(@"
                DELETE FROM dbo.KbKostenstelle_BaPerson
                WHERE BaPersonID = {0}",
                qryBaPerson[DBO.BaPerson.BaPersonID]);

            // Verknüpfung mit Mietvertrag löschen
            DBUtil.ExecuteScalarSQL(@"
                DELETE FROM dbo.BaMietvertrag
                WHERE BaPersonID = {0}",
                qryBaPerson[DBO.BaPerson.BaPersonID]);
        }

        private void RelocateInfoControls()
        {
            btnFallInfo.Location = new Point(btnFallInfo.Location.X, tabControlSearch.Location.Y + tabControlSearch.Height - btnFallInfo.Height - 1);
            ctlGotoFall.Location = new Point(ctlGotoFall.Location.X, tabControlSearch.Location.Y + tabControlSearch.Height - ctlGotoFall.Height - 1);
            lblAnzahlDatensaetze.Location = new Point(lblAnzahlDatensaetze.Location.X, tabControlSearch.Location.Y + tabControlSearch.Height - lblAnzahlDatensaetze.Height - 2);
            lblRowCount.Location = new Point(lblRowCount.Location.X, tabControlSearch.Location.Y + tabControlSearch.Height - lblRowCount.Height - 2);
        }

        #endregion

        #endregion
    }
}