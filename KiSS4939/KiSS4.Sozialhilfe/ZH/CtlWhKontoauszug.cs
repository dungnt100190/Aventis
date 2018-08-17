using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public partial class CtlWhKontoauszug : KissSearchUserControl
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private readonly int _baPersonID;
        private List<string> _laListKlientenkontoAbrechnung;

        public CtlWhKontoauszug(Image titelImage, string titelText, int baPersonID)
            : this()
        {
            picTitel.Image = titelImage;
            lblTitel.Text = titelText;
            _baPersonID = baPersonID;

            colTyp.ColumnEdit = grdDoc.GetLOVLookUpEdit("BgDokumentTyp");

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

            edtPerson.LoadQuery(DBUtil.OpenSQL(@"
                SELECT DISTINCT
                  Code = PRS.BaPersonID,
                  Text = PRS.DisplayText
                FROM BgFinanzplan_BaPerson    BFB
                  INNER JOIN vwPerson         PRS ON PRS.BaPersonID = BFB.BaPersonID
                  INNER JOIN BgFinanzplan     BFP ON BFP.BgFinanzplanID = BFB.BgFinanzplanID
                  INNER JOIN FaLeistung       FLE ON FLE.FaLeistungID = BFP.FaLeistungID
                  INNER JOIN FaFall           FAL ON FAL.FaFallID = FLE.FaFallID
                WHERE FAL.BaPersonID = {0} AND BFB.IstUnterstuetzt = 1
                UNION
                SELECT DISTINCT -- Personen aus Proleist-Zeit
                Code = PRS.BaPersonID,
                Text = PRS.DisplayText
                FROM dbo.FaFall                    FAL
                  INNER JOIN dbo.FaLeistung        FLE ON FLE.FaFallID = FAL.FaFallID
                  INNER JOIN dbo.MigDetailBuchung  BUC ON BUC.FaLeistungID = FLE.FaLeistungID
                  INNER JOIN dbo.vwPerson          PRS ON PRS.BaPersonID = BUC.BaPersonID
                WHERE FAL.BaPersonID = {0} AND
                  BUC.BuchungsStatusCode = 1 AND /*Korrekt*/
                  BUC.LeistungsArtNrProLeist IS NOT NULL
                UNION ALL
                SELECT NULL,NULL
                ORDER BY 2",
                _baPersonID));

            InitMultiSelection(false);
        }

        public CtlWhKontoauszug()
        {
            InitializeComponent();

            InitMultiSelection(false);
        }

        public override object GetContextValue(string fieldName)
        {
            string laList = String.Join(",", multiSelectListboxes.GetSelectedHiddenCol("KontoNr"));

            switch (fieldName.ToUpper())
            {
                case "ABSENDER":
                    SqlQuery qryUser = DBUtil.OpenSQL("Select USR.UserID, USR.LogonName FROM FaFall FAL INNER JOIN XUser USR ON FAL.UserID = USR.UserID WHERE FAL.BaPersonID = {0}", _baPersonID);
                    int userid = (int)qryUser["UserID"];
                    return userid;

                case "FALLUSERID":
                    return _baPersonID;

                case "FAFALLID":
                    SqlQuery qryFall = DBUtil.OpenSQL("Select TOP 1 FaFallID FROM FaFall WHERE BaPersonID = {0}", _baPersonID);
                    int fallID = (int)qryFall["FaFallID"];
                    return fallID;

                case "FT":
                    return _baPersonID;

                case "FALLBAPERSONID":
                    return _baPersonID;

                case "BAPERSONID":
                    if (DBUtil.IsEmpty(edtPerson.EditValue))
                        return 0;
                    else
                        return edtPerson.EditValue;

                case "KBKONTOZEITRAUMCODE":
                    if (DBUtil.IsEmpty(edtZeitraum.EditValue))
                        return 0;
                    else
                        return edtZeitraum.EditValue;

                case "DATUMVON":
                    if (DBUtil.IsEmpty(edtDatumVon.EditValue))
                        return 0;
                    else
                        return edtDatumVon.EditValue;

                case "DATUMBIS":
                    if (DBUtil.IsEmpty(edtDatumBis.EditValue))
                        return 0;
                    else
                        return edtDatumBis.EditValue;

                case "BUCHUNGSTEXT":
                    if (DBUtil.IsEmpty(edtBuchungstext.EditValue))
                        return "-";
                    else
                        return edtBuchungstext.EditValue;

                case "LALIST":
                    if (DBUtil.IsEmpty(laList))
                        return "-";
                    else
                        return laList;

                case "VERDICHTET":
                    return (bool)edtVerdichtet.EditValue;

                case "INKLPROLEIST":
                    return (bool)edtInklProLeist.EditValue;

                case "INKLVERMITTLUNGSFALL":
                    return (bool)edtInklVermittlungsfall.EditValue;

                case "INKLGRUEN":
                    return (bool)edtInklGruen.EditValue;

                case "INKLROT":
                    return (bool)edtInklRot.EditValue;

                case "INKLSTORNO":
                    return (bool)edtInklStorno.EditValue;

                case "KLIENTENNAME":
                    if (edtPerson.EditValue == null || edtPerson.EditValue.Equals(string.Empty))
                        return 0;
                    else
                        return edtPerson.EditValue;

                case "SUCHPARAMETER":
                    string suchkriterien = "";
                    if (edtVerdichtet.Checked)
                        suchkriterien += "verdichtet";
                    else
                        suchkriterien += "unverdichtet";
                    if (edtInklProLeist.Checked)
                        suchkriterien += ", inkl. ProLeist";
                    else
                        suchkriterien += ", exkl. ProLeist";
                    if (edtInklVermittlungsfall.Checked)
                        suchkriterien += ", inkl. Vermittlungsfall";
                    else
                        suchkriterien += ", exkl. Vermittlungsfall";
                    if (edtInklGruen.Checked)
                        suchkriterien += ", inkl. grün";
                    else
                        suchkriterien += ", exkl. grün";
                    if (edtInklRot.Checked)
                        suchkriterien += ", inkl. rot";
                    else
                        suchkriterien += ", exkl. rot";
                    if (edtInklStorno.Checked)
                        suchkriterien += ", inkl. Storno";
                    else
                        suchkriterien += ", exkl. Storno";
                    if (!DBUtil.IsEmpty(edtBuchungstext.EditValue))
                        suchkriterien += ", Text:" + edtBuchungstext.Text;
                    if (DBUtil.IsEmpty(suchkriterien))
                        return "-";
                    else
                        return suchkriterien;

                case "LEISTUNGSARTEN":
                    if (laList == "" || laList == null)
                        return "alle LA";
                    else
                        return laList;

                case "SUCHPERIODE":
                    if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumBis.EditValue))
                        return edtDatumVon.Text + " - " + edtDatumBis.Text;
                    else if (!DBUtil.IsEmpty(edtDatumVon.EditValue))
                        return "ab " + edtDatumVon.Text;
                    else if (!DBUtil.IsEmpty(edtDatumBis.EditValue))
                        return "bis " + edtDatumBis.Text;
                    else
                        return "Keine Zeitbeschränkung";

                case "DATUMSSUCHART":
                    return edtZeitraum.Text;
                /*case "TEST":
                    return KissImageList.SmallImageList.Images[0];*/
            };
            return base.GetContextValue(fieldName);
        }

        public override void OnPrint()
        {
            btnWordDrucken.PerformClick();
        }

        protected override void NewSearch()
        {
            base.NewSearch();

            edtPerson.EditValue = null;
            edtZeitraum.EditValue = 3;  //Verwendungsperiode
            //	edtZeitraum.EditValue = 1;  //Valutadatum für WV-Gruppe
            edtVerdichtet.Checked = true;
            edtInklProLeist.Checked = true;
            edtInklVermittlungsfall.Checked = false;
            edtInklGruen.Checked = false;
            edtInklRot.Checked = false;
            edtInklStorno.Checked = false;
            edtExklWV.EditValue = true;
        }

        protected override void RunSearch()
        {
            if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumBis.EditValue) && edtDatumVon.DateTime > edtDatumBis.DateTime)
            {
                KissMsg.ShowInfo("Das Bis-Datum muss grösser als oder gleich gross wie das Von-Datum sein.");
                throw new KissCancelException("Das Bis-Datum muss grösser als oder gleich gross wie das Von-Datum sein..");
            }
            base.RunSearch();

            string laList = string.Join(",", multiSelectListboxes.GetSelectedHiddenCol("KontoNr"));

            string suchkriterien;

            if (DBUtil.IsEmpty(edtPerson.EditValue))
                suchkriterien = "ganze UE";
            else
                suchkriterien = edtPerson.Text;

            suchkriterien += ", " + edtZeitraum.Text;

            if (!DBUtil.IsEmpty(edtDatumVon.EditValue) && !DBUtil.IsEmpty(edtDatumBis.EditValue))
                suchkriterien += ", " + edtDatumVon.Text + " - " + edtDatumBis.Text;
            else if (!DBUtil.IsEmpty(edtDatumVon.EditValue))
                suchkriterien += ", ab" + edtDatumVon.Text;
            else if (!DBUtil.IsEmpty(edtDatumBis.EditValue))
                suchkriterien += ", bis" + edtDatumBis.Text;

            if (!DBUtil.IsEmpty(edtBuchungstext.EditValue))
                suchkriterien += ", Text:" + edtBuchungstext.Text;

            if (edtVerdichtet.Checked) suchkriterien += ", verdichtet";
            if (edtInklProLeist.Checked) suchkriterien += ", inkl. ProLeist";
            if (edtInklVermittlungsfall.Checked) suchkriterien += ", inkl. Vermittlungsfall";
            if (edtInklGruen.Checked) suchkriterien += ", inkl. grün";
            if (edtInklRot.Checked) suchkriterien += ", inkl. rot";
            if (edtInklStorno.Checked) suchkriterien += ", inkl. Storno";
            if (!edtExklWV.Checked) suchkriterien += ", inkl. WV, VU/UB";

            if (laList == "")
                suchkriterien += ", alle LA";
            else
                suchkriterien += ", LA " + laList;
            if (laList == "" && !edtExklWV.Checked)
            {
                laList = string.Join(",", multiSelectListboxes.GetAvailableHiddenCol("KontoNr"));
            }

            lblSuchkriterien.Text = suchkriterien;
            lblSuchkriterien.Visible = true;

            grdKontoauszug.DataSource = null;
            try
            {
                qryKontoauszug.Fill(
                    "exec spWhKontoauszug {0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}",
                    _baPersonID,
                    edtPerson.EditValue,
                    edtZeitraum.EditValue,
                    edtDatumVon.EditValue,
                    edtDatumBis.EditValue,
                    edtBuchungstext.EditValue,
                    laList,
                    edtVerdichtet.EditValue,
                    edtInklProLeist.EditValue,
                    edtInklVermittlungsfall.EditValue,
                    edtInklGruen.EditValue,
                    edtInklRot.EditValue,
                    edtInklStorno.EditValue);

                grdKontoauszug.DataSource = qryKontoauszug;
            }
            catch (Exception ex1)
            {
                KissMsg.ShowInfo("Fehler: " + ex1.Message);
            }

            //	qryKontoauszug.Last();
            //grvKbBuchungKostenartBrutto.MoveLast(); // Workaround: das Grid folgt bei der ersten Suche nicht automatisch
        }

        private void btnAuswahlKlientenkontoabrechnung_Click(object sender, EventArgs e)
        {
            edtPerson.EditValue = null;
            edtZeitraum.EditValue = 3; /* Verwendungsperiode */
            edtStichtag.Checked = false;
            edtDatumBis.Enabled = true;
            edtDatumVon.EditValue = null;
            edtDatumBis.EditValue = null;
            edtBuchungstext.Text = string.Empty;
            edtExklWV.Checked = true;
            edtVerdichtet.Checked = true;
            edtInklProLeist.Checked = true;
            edtInklVermittlungsfall.Checked = false;
            edtInklGruen.Checked = false;
            edtInklRot.Checked = false;
            edtInklStorno.Checked = false;
            InitMultiSelection(true);
        }

        private void btnBudgetPosition_Click(object sender, EventArgs e)
        {
            string jumpToPath = string.Format(
                "ClassName=FrmFall;" +
                "BaPersonID={0};" +
                "ModulID=3;" +
                "TreeNodeID=CtlWhFinanzplan{1}\\BBG{2};" +
                "ActiveSQLQuery.Find=BgPositionID = {3};",
                qryKontoauszug["FallBaPersonID"],
                qryKontoauszug["BgFinanzplanID"],
                qryKontoauszug["BgBudgetID"],
                qryKontoauszug["BgPositionID"]);

            System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(jumpToPath);
            bool result = FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
            // resultat ist eigentlich immer true
            if (!result)
            {
                KissMsg.ShowInfo("Die Position befindet sich in einer beendeten Reg. WH oder in einem abgeschlossenen W. Deaktivieren Sie die Optionen 'Beendete Reg. WH ausblenden' und 'Abgeschlossene W ausblenden' um die Position anzuzeigen.");
                jumpToPath = string.Format(
                    "ClassName=FrmFall;" +
                    "BaPersonID={0};" +
                    "ModulID=3;" +
                    "TreeNodeID=CtlWhKontoauszug;"
                    , qryKontoauszug["FallBaPersonID"]);
                dic = FormController.ConvertToDictionary(jumpToPath);
                FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
            }
        }

        private void CtlWhKontoauszug_Load(object sender, EventArgs e)
        {
            grvKbBuchungKostenartBrutto.EndSorting += grvKbBuchungKostenartBrutto_EndSorting;
            NewSearch();
        }

        private void edtDatumVon_EditValueChanged(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(edtStichtag.EditValue) && (bool)edtStichtag.EditValue)
            {
                edtDatumBis.EditValue = edtDatumVon.EditValue;
            }
        }

        private void edtExklWV_EditValueChanged(object sender, EventArgs e)
        {
            InitMultiSelection(false);
        }

        private void edtStichtag_Click(object sender, EventArgs e)
        {
            edtDatumBis.Enabled = edtStichtag.Checked;
            edtDatumBis.EditValue = edtDatumVon.EditValue;
        }

        private void grvKbBuchungKostenartBrutto_EndSorting(object sender, EventArgs e)
        {
            UpdateSaldo2();
        }

        private void InitMultiSelection(bool selectLAsKlientenkontoabrechnung)
        {
            string sql = @"SELECT
                                      KontoNr,
                                      Name = IsNull(KontoNr + ' ', '') + Name
                                    FROM BgKostenart
                                    WHERE ModulId = 3 AND KontoNr NOT LIKE '0%'"
                                + (edtExklWV.Checked ? @" AND
                                          (KontoNr NOT IN
                                            (
                                              SELECT SplitValue
                                              FROM [dbo].[fnSplitStringToValues]
                                              (
                                                (SELECT CONVERT(VARCHAR(500), [dbo].[fnXConfig] (
                                                    'System\WH\WV_VU_UB'
                                                    ,GetDate()))), ',', 0
                                              ))
                                            )" : "")
                                + " ORDER BY KontoNr ASC";

            multiSelectListboxes.Initialize(sql, "Name", " Verfügbare Leistungsart", "Zugeteilte Leistungsart");

            if (selectLAsKlientenkontoabrechnung)
            {
                if (_laListKlientenkontoAbrechnung == null)
                {
                    _laListKlientenkontoAbrechnung = new List<string>();

                    string las = DBUtil.GetConfigString(@"System\WH\Klientenkontoabrechnung_zusaetzliche_LAs", "");

                    _laListKlientenkontoAbrechnung.AddRange(las.Split(','));
                }

                multiSelectListboxes.SelectAll();
                multiSelectListboxes.Unselect(_laListKlientenkontoAbrechnung, "KontoNr");
            }
        }

        private void qryKontoauszug_AfterFill(object sender, EventArgs e)
        {
            UpdateSaldo1();
            if (edtVerdichtet.Checked)
            {
                DataSet ds = qryKontoauszug.DataSet;
                ds.EnforceConstraints = false; // Workaround: das SqlQuery löscht die Constraints nur auf der zweiten Table, nicht jedoch auf der ersten
                // Beim ersten Durchgang ohne die Option 'verdichtet' (mit vorgängigen Suchvorgängen mit verdichtet) gibt es dadurch eine exception.
                try
                {
                    ds.Relations.Add("BelegDetail",
                        new DataColumn[] { ds.Tables[0].Columns["BelegNr"], ds.Tables[0].Columns["LA"], ds.Tables[0].Columns["GroupBaPersonID"], ds.Tables[0].Columns["Buchungstext"], ds.Tables[0].Columns["VerwPeriodeVon"], ds.Tables[0].Columns["VerwPeriodeBis"] },
                        new DataColumn[] { ds.Tables[1].Columns["BelegNr"], ds.Tables[1].Columns["LA"], ds.Tables[1].Columns["GroupBaPersonID"], ds.Tables[1].Columns["Buchungstext"], ds.Tables[1].Columns["VerwPeriodeVon"], ds.Tables[1].Columns["VerwPeriodeBis"] });
                }
                catch (Exception ex)
                {
                    // Eintrag ins Log.
                    _log.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                    // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
                }
            }
        }

        private void qryKontoauszug_PositionChanged(object sender, EventArgs e)
        {
            if (qryKontoauszug["EA"].ToString() == "A")
                lblKreditor.Text = "Kreditor";
            else
                lblKreditor.Text = "Debitor";

            if (qryKontoauszug["PK"].ToString() == "K")
                qryBgDokumente.Fill(qryKontoauszug["BuchungID"], qryKontoauszug["BaPersonID"]);
            else //MigDetailBuchung/ProLeist
                qryBgDokumente.Fill(-1, -1);

            btnBudgetPosition.Visible = !DBUtil.IsEmpty(qryKontoauszug["BgPositionID"]) && !DBUtil.IsEmpty(qryKontoauszug["BgBudgetID"]) &&
                !DBUtil.IsEmpty(qryKontoauszug["BgFinanzplanID"]) && !DBUtil.IsEmpty(qryKontoauszug["FallBaPersonID"]);
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            // Neue Spez sagt: erste Zeile markieren (mal schauen ob es so bleibt)
            /*if (page == tpgListe)
            {
                grvKbBuchungKostenartBrutto.MoveLast(); // Workaround: das Grid folgt bei der ersten Suche nicht automatisch
            }*/
        }

        private void UpdateSaldo1()
        {
            decimal saldo = 0;

            try
            {
                //Da das Query (spWhKontoauszug) die Daten ORDER BY Verwendungsperiode DESC zurückgibt, müssen wir bei der Saldoberechnung die Zeilen rückwärts durchlaufen
                var rows = qryKontoauszug.DataTable.Rows;
                for (int i = rows.Count - 1; i >= 0; i--)
                {
                    var row = rows[i];

                    int? status = row["KbBuchungStatusCode"] as int?;

                    if (status.HasValue && (status.Value == 2 || status.Value == 3 || status.Value == 4 || status.Value == 5 || status.Value == 7
                        || status.Value == 9))
                    {
                        row["Saldo"] = DBNull.Value;
                    }
                    else
                    {
                        if (!DBUtil.IsEmpty(row["Einnahme"]))
                            saldo += (decimal)row["Einnahme"];

                        if (!DBUtil.IsEmpty(row["Ausgabe"]))
                            saldo -= (decimal)row["Ausgabe"];

                        row["Saldo"] = saldo;
                    }
                }
                qryKontoauszug.DataTable.AcceptChanges();
                qryKontoauszug.RowModified = false;
            }
            catch (Exception ex2)
            {
                KissMsg.ShowInfo(ex2.Message);
            }
        }

        private void UpdateSaldo2()
        {
            decimal saldo = 0;

            int dataRowCount = grdKontoauszug.View.DataRowCount;
            for (int i = 0; i < dataRowCount; i++)
            {
                int? status = grdKontoauszug.View.GetRowCellValue(i, colStatus) as int?;

                if (status.HasValue && (status.Value == 2 || status.Value == 3 || status.Value == 4 || status.Value == 5 || status.Value == 7
                    || status.Value == 9))
                {
                    grdKontoauszug.View.SetRowCellValue(i, colSaldo, DBNull.Value);
                }
                else
                {
                    if (!DBUtil.IsEmpty(grdKontoauszug.View.GetRowCellValue(i, colEinnahme)))
                        saldo += (decimal)grdKontoauszug.View.GetRowCellValue(i, colEinnahme);

                    if (!DBUtil.IsEmpty(grdKontoauszug.View.GetRowCellValue(i, colAusgabe)))
                        saldo -= (decimal)grdKontoauszug.View.GetRowCellValue(i, colAusgabe);

                    grdKontoauszug.View.SetRowCellValue(i, colSaldo, saldo);
                }
            }
            qryKontoauszug.DataTable.AcceptChanges();
            qryKontoauszug.RowModified = false;
        }
    }
}