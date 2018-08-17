using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    partial class CtlQueryWhVergleichKVGPraemie : Common.KissQueryControl
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CtlQueryWhVergleichKVGPraemie()
        {
            InitializeComponent();
        }

        public override void OnSearch()
        {
            // Workaround um F3 weiter zu reichen, da das FrameWork das OrgUnitTeamUser UserControl nicht kennt
            try
            {
                if (((ContainerControl)ActiveControl).ActiveControl.Equals(ctlOrgUnitTeamUser))
                {
                    edtKlient.Focus();
                }
            }
            catch
            {
            }

            base.OnSearch();
        }

        protected override void NewSearch()
        {
            base.NewSearch();
            ctlOrgUnitTeamUser.NewSearch();
        }

        protected override void RunSearch()
        {
            base.RunSearch();

            if (DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheGruppe.EditValue) &&
                DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheTeam.EditValue) &&
                DBUtil.IsEmpty(ctlOrgUnitTeamUser.SucheUserID.EditValue) &&
                DBUtil.IsEmpty(edtKlient.EditValue) &&
                DBUtil.IsEmpty(edtPersonenNr.EditValue) &&
                DBUtil.IsEmpty(edtFallNr.EditValue) &&
                DBUtil.IsEmpty(edtDatumVon.EditValue) &&
                DBUtil.IsEmpty(edtDatumBis.EditValue)
                )
            {
                KissMsg.ShowInfo("Mindestens eines der folgenden Felder muss ausgefüllt werden:\r\n\r\n" +
                    "- Organisationsgruppe\r\n" +
                    "- Team\r\n" +
                    "- Mitarbeiter/in\r\n" +
                    "- Klient\r\n" +
                    "- Pers.-Nr.\r\n" +
                    "- Fall-Nr.\r\n" +
                    "- Datum von, bis");
                throw new Exception();
            }

            if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumBis.EditValue)
                && (Convert.ToDateTime(edtDatumVon.EditValue) > Convert.ToDateTime(edtDatumBis.EditValue)))
            {
                KissMsg.ShowInfo("Datum von muss kleiner sein als Datum bis.");
                throw new Exception();
            }

            try
            {
                qryQuery.Fill(qryQuery.SelectStatement);
                grdQuery1.DataSource = qryQuery;

                grvMain.OptionsView.ShowFooter = !DBUtil.IsEmpty(edtKlient.EditValue) || !DBUtil.IsEmpty(edtPersonenNr.EditValue) || !DBUtil.IsEmpty(edtFallNr.EditValue);
                grvMain.BestFitColumns();
            }
            catch (Exception ex1)
            {
                KissMsg.ShowInfo("Fehler: " + ex1.Message);
            }
        }

        private void btnMonatsbudget_Click(object sender, EventArgs e)
        {
            try
            {
                string jumpToPath = string.Format(
                    "ClassName=FrmFall;" +
                    "BaPersonID={0};" +
                    "ModulID=3;",
                    qryQuery["BaPersonID"]);
                if (!DBUtil.IsEmpty(qryQuery["BgFinanzplanID"]))
                {
                    jumpToPath += string.Format("TreeNodeID=CtlWhFinanzplan{0}", qryQuery["BgFinanzplanID"]);
                    if (!DBUtil.IsEmpty(qryQuery["BgBudgetID"]))
                    {
                        jumpToPath += string.Format("\\BBG{0};", qryQuery["BgBudgetID"]);
                        if (!DBUtil.IsEmpty(qryQuery["BgPositionID"]))
                        {
                            jumpToPath += string.Format("ActiveSQLQuery.Find=BgPositionID = {0};", qryQuery["BgPositionID"]);
                        }
                    }
                    else
                    {
                        jumpToPath += ';';
                    }
                }

                var dic = FormController.ConvertToDictionary(jumpToPath);
                var result = FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);

                // resultat ist eigentlich immer true
                if (!result)
                {
                    KissMsg.ShowInfo("Das Budget befindet sich in einer beendeten Reg. WH oder in einem abgeschlossenen W. Deaktivieren Sie die Optionen 'Beendete Reg. WH ausblenden' und 'Abgeschlossene W ausblenden' um das Budget anzuzeigen.");
                    jumpToPath = string.Format(
                        "ClassName=FrmFall;" +
                        "BaPersonID={0};" +
                        "ModulID=3;" +
                        "TreeNodeID=CtlWhKontoauszug;"
                        , qryQuery["BaPersonID"]);
                    dic = FormController.ConvertToDictionary(jumpToPath);
                    FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
            }
        }

        private void edtDatumBis_Validated(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumVon.EditValue) && edtDatumVon.DateTime > edtDatumBis.DateTime)
            {
                edtDatumVon.EditValue = edtDatumBis.EditValue;
            }
        }

        private void edtDatumVon_Validated(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumVon.EditValue) && edtDatumVon.DateTime > edtDatumBis.DateTime)
            {
                edtDatumBis.EditValue = edtDatumVon.EditValue;
            }
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtPersonenNr.EditValue) && DBUtil.IsEmpty(edtKlient.EditValue))
            {
                // Keine Person ausgewählt => Gruppierung
                var ds = qryQuery.DataSet;
                ds.EnforceConstraints = false; // Workaround: das SqlQuery löscht die Constraints nur auf der zweiten Table, nicht jedoch auf der ersten

                try
                {
                    ds.Relations.Add("Level1",
                        new[] { ds.Tables[0].Columns["KbBuchungBruttoID"], ds.Tables[0].Columns["BgPositionID"] },
                        new[] { ds.Tables[1].Columns["KbBuchungBruttoID"], ds.Tables[1].Columns["BgPositionID"] });
                }
                catch (Exception ex)
                {
                    LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
                }
            }
        }

        private void qryQuery_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            edtFallNr.Enabled = !DBUtil.IsEmpty(qryQuery["BaPersonID"]);
        }
    }
}