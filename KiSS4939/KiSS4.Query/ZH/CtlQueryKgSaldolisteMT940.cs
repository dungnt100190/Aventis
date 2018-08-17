using System;
using System.Collections.Specialized;
using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.Common.ZH;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public partial class CtlQueryKgSaldolisteMT940 : KissQueryControl
    {
        public CtlQueryKgSaldolisteMT940()
        {
            InitializeComponent();
        }

        public override void OnSearch()
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                foreach (Control ctl in UtilsGui.AllControls(tpgSuchen))
                {
                    if (ctl is KissButtonEdit)
                    {
                        KissButtonEdit edt = (KissButtonEdit)ctl;
                        edt.CheckPendingSearchValue();
                    }

                    if (ctl is CtlOrgUnitTeamUser)
                    {
                        ((CtlOrgUnitTeamUser)ctl).CheckPendingSearchValue();
                    }
                }
            }

            // Workaround um F3 weiter zu reichen, da das FrameWork das OrgUnitTeamUser UserControl nicht kennt
            try
            {
                if (((ContainerControl)ActiveControl).ActiveControl.Equals(ctlOrgUnitTeamUser))
                    edtSucheDatumBis.Focus();
            }
            catch
            {
            }

            base.OnSearch();
            if (qryQuery.Count == 0)
            {
                qryAbgleichBuc.Fill(-1, null);
                qryAbgleichMT940.Fill(-1, null);
            }
        }

        protected override void NewSearch()
        {
            base.NewSearch();
            ctlOrgUnitTeamUser.NewSearch();

            edtSucheDatumBis.Focus();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Kleiner Hack, damit KiSSQueryControl die Queries nicht automatisch und leider ohne Parameter füllt, was zu einer Fehlermeldung führt.
            grdBuc.DataSource = null;
            grdMT940.DataSource = null;
            base.OnLoad(e);
            grdBuc.DataSource = qryAbgleichBuc;
            grdMT940.DataSource = qryAbgleichMT940;
        }

        private void btnJumpToBuchungsmaske_Click(object sender, EventArgs e)
        {
            // HACK: PositionChanged funktioniert nicht...
            var selectedRowsHandle = grvMT940.GetSelectedRows();
            if (selectedRowsHandle.Length != 0)
            {
                var selectedRowHandle = selectedRowsHandle[0];
                qryAbgleichMT940.Position = selectedRowHandle;
            }

            //Es soll der absolute Betrag übernommen werden.
            //Je nachdem wird der User in der Buchungsmaske Soll und Haben Konto wählen.
            decimal? betrag = null;
            if (!DBUtil.IsEmpty(qryAbgleichMT940["Betrag"]))
            {
                betrag = Math.Abs((decimal)qryAbgleichMT940["Betrag"]);
            }

            FormController.OpenForm(
                "FrmKgKlientengelder",
                "Action", "JumpToNode",
                "ClassName", "CtlKgBuchung",
                "BaPersonID", qryQuery["BaPersonID"],
                "Datum", qryAbgleichMT940["Datum"],
                "Betrag", betrag);
        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            // Suche das Budget, die Position, etc... (Falls vorhanden)
            SqlQuery qryBudget = DBUtil.OpenSQL(@"
                DECLARE @KgBuchungID INT
                SET @KgBuchungID = {0}
                SELECT TOP 1 FallBaPersonID, FaLeistungID, KgMasterBudgetID, KgBudgetID, KgPositionID
                FROM
                (
                    -- Springe ins korrekte Budget
                    SELECT FallBaPersonID = FAL.BaPersonID, LEI.FaLeistungID, BUD.KgMasterBudgetID, BUD.KgBudgetID, BUC2.KgPositionID, BUC2.Buchungsdatum
                    FROM dbo.KgBuchung BUC
                      INNER JOIN dbo.KgOpAusgleich AUG ON AUG.AusgleichBuchungID = BUC.KgBuchungID
                      INNER JOIN dbo.KgBuchung BUC2 ON BUC2.KgBuchungID = OpBuchungID
                      INNER JOIN dbo.KgPosition POS ON POS.KgPositionID = BUC2.KgPositionID
                      INNER JOIN dbo.KgBudget BUD ON BUD.KgBudgetID = POS.KgBudgetID
                      INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = BUD.FaLeistungID
                      INNER JOIN dbo.FaFall FAL ON FAL.FaFallID = LEI.FaFallID
                    WHERE BUC.KgBuchungID = @KgBuchungID
                    UNION
                    -- Falls keine Budgetposition vorhanden ist, so springe in das Budget, dass dem Datum entspricht.
                    SELECT FallBaPersonID = FAL.BaPersonID, LEI.FaLeistungID, BUD.KgMasterBudgetID, BUD.KgBudgetID, KgPositionID = NULL, BUC.Buchungsdatum
                    FROM dbo.KgBuchung BUC
                      INNER JOIN dbo.KgPeriode PER ON PER.KgPeriodeID = BUC.KgPeriodeID
                      INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = PER.FaLeistungID
                      INNER JOIN dbo.FaFall FAL ON FAL.FaFallID = LEI.FaFallID
                      INNER JOIN dbo.KgBudget BUD ON BUD.FaLeistungID = LEI.FaLeistungID AND KgMasterBudgetID IS NOT NULL /*Monatsbudget*/
                        AND dbo.fnLastDayOf(dbo.fnDateSerial(BUD.Jahr, BUD.Monat, 1)) < BUC.Buchungsdatum
                    WHERE BUC.KgBuchungID = @KgBuchungID
                ) X
                ORDER BY CASE WHEN KgPositionID IS NULL THEN 0 ELSE 1 END DESC, Buchungsdatum DESC

            ", qryAbgleichBuc["KgBuchungID"]);

            if (!DBUtil.IsEmpty(qryBudget["FallBaPersonID"]))
            {
                var dic = new HybridDictionary
                {
                    { "ClassName", "FrmFall" },
                    { "Action", "JumpToPath" },
                    { "BaPersonID", qryBudget["FallBaPersonID"] },
                    { "ModulID", 5 },
                    {
                        "TreeNodeID", string.Format(
                            "CtlKgLeistung{0}\\Masterbudget{1}\\Monatsbudget{2}",
                            qryBudget["FaLeistungID"],
                            qryBudget["KgMasterBudgetID"],
                            qryBudget["KgBudgetID"])
                        },
                };

                if (!DBUtil.IsEmpty(qryBudget["KgPositionID"]))
                {
                    dic.Add("ActiveSQLQuery.Find", string.Format("KgPositionID = {0}", qryBudget["KgPositionID"]));
                }

                FormController.OpenForm("FrmFall", dic);
            }
        }

        private void qryQuery_PositionChanged(object sender, EventArgs e)
        {
            // Die Reihenfolge spielt eine Rolle, da das zweite Query eine Temporäre Tabelle des ersten Query benutzt
            if (DBUtil.IsEmpty(qryQuery["AbweichungCHF"]) || (decimal)qryQuery["AbweichungCHF"] == 0)
            {
                qryAbgleichBuc.Fill(-1, null);
            }
            else
            {
                qryAbgleichBuc.Fill(qryQuery["BaPersonID"], edtSucheDatumBis.EditValue);
            }

            qryAbgleichMT940.Fill();
            foreach (System.Data.DataRow row in qryAbgleichBuc.DataSet.Tables[1].Rows)
            {
                if (row.RowState != System.Data.DataRowState.Deleted)
                {
                    qryAbgleichMT940.DataTable.Rows.Add(row.ItemArray);

                    qryAbgleichMT940.DataTable.AcceptChanges();
                }

                row.Delete();
            }

            qryAbgleichBuc.DataSet.Tables[1].AcceptChanges();
        }
    }
}