using System;
using System.Data;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.Common.Report;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public partial class CtlQueryShPapierverfuegung : KiSS4.Common.KissQueryControl
    {
        private bool abbruch = false;

        public CtlQueryShPapierverfuegung()
        {
            InitializeComponent();

            SqlQuery qry = DBUtil.OpenSQL(@"
                select  Code = null, Text = null union all
				select  1, 'Jan' union all
				select  2, 'Feb' union all
				select  3, 'März' union all
				select  4, 'Apr' union all
				select  5, 'Mai' union all
				select  6, 'Juni' union all
				select  7, 'Juli' union all
				select  8, 'Aug' union all
				select  9, 'Sep' union all
				select 10, 'Okt' union all
				select 11, 'Nov' union all
				select 12, 'Dez' ");

            edtMonat.Properties.Columns.Clear();
            edtMonat.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtMonat.Properties.ShowFooter = false;
            edtMonat.Properties.ShowHeader = false;
            edtMonat.Properties.DisplayMember = "Text";
            edtMonat.Properties.ValueMember = "Code";
            edtMonat.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtMonat.Properties.DataSource = qry;
        }

        private void CtlQueryShPapierverfuegung_Load(object sender, EventArgs e)
        {
            lblAktion.Text = "";

            // update grid style
            this.UpdateGridStyle();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.OnPrint();
        }

        private void CtlQueryShPapierverfuegung_Print(object sender, EventArgs e)
        {
            qryQuery.EndCurrentEdit(true);

            abbruch = false;
            btnAbbruch.Enabled = true;
            btnAbbruch.Focus();

            int count = 0;
            foreach (DataRow R in qryQuery.DataTable.Rows)
            {
                if ((bool)R["SelPrint"])
                {
                    count++;
                    lblAktion.Text = "Verfügung " + count.ToString() + " wird gedruckt ...";
                    ApplicationFacade.DoEvents();

                    if (abbruch)
                    {
                        count--;
                        break;
                    }

                    NamedPrm[] prms = new NamedPrm[2];
                    prms[0] = new NamedPrm("BgBudgetID", R["BgBudgetID"]);
                    prms[1] = new NamedPrm("KbBuchungID", R["KbBuchungID"]);

                    if (chkPreview.Checked)
                    {
                        RepUtil.ExecuteReport("ShMassenPapierverfuegung", KissReportDestination.Viewer, prms);
                    }
                    else
                    {
                        RepUtil.ExecuteReport("ShMassenPapierverfuegung", KissReportDestination.Printer, prms);
                    }

                    ApplicationFacade.DoEvents();
                }
            }
            lblAktion.Text = "";
            abbruch = false;
            btnAbbruch.Enabled = false;

            if (count == 0)
            {
                KissMsg.ShowInfo("CtlQueryShPapierverfuegung", "KeinEintragSelektiert", "Es ist keine Papierverfügung für den Ausdruck selektiert!");
                return;
            }

            if (count == 1)
                KissMsg.ShowInfo("CtlQueryShPapierverfuegung", "EinEintragGedruckt", "Es wurde 1 Papierverfügung gedruckt.");
            else
                KissMsg.ShowInfo("CtlQueryShPapierverfuegung", "nEintraegeGedruckt", "Es wurden {0} Papierverfügungen gedruckt.", 0, 0, count.ToString());

            //this.Activate();
        }

        private void btnAbbruch_Click(object sender, EventArgs e)
        {
            abbruch = KissMsg.ShowQuestion("CtlQueryShPapierverfuegung", "MassendruckAbbruch", "Soll der Massendruck abgebrochen werden?");
        }

        private void qryQuery_BeforePost(object sender, EventArgs e)
        {
            qryQuery.Row.AcceptChanges();
            qryQuery.RowModified = false;
        }

        private void UpdateGridStyle()
        {
            // apply colors, they are fix defined in contructor of view and we need readonly behaviour in editable grid
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
        }

        private void qryQuery_AfterFill(object sender, EventArgs e)
        {
            // update grid style (because of some buggy behaviour, we do this here with every fill)
            this.UpdateGridStyle();

            this.btnGotoBudget.Enabled = qryQuery.Count > 0;
            this.btnPrint.Enabled = qryQuery.Count > 0;
            this.btnSelectAll.Enabled = qryQuery.Count > 0;
            this.btnSelectNone.Enabled = qryQuery.Count > 0;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                row["SelPrint"] = 1;
            }
        }

        private void btnSelectNone_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in qryQuery.DataTable.Rows)
            {
                row["SelPrint"] = 0;
            }
        }

        private void btnGotoBudget_Click(object sender, EventArgs e)
        {
            string jumpToPath = string.Format(
                "ClassName=FrmFall;" +
                "BaPersonID={0};" +
                "ModulID=3;" +
                "TreeNodeID=CtlWhFinanzplan{1}\\BBG{2};",
                qryQuery["BaPersonID"],
                qryQuery["BgFinanzplanID"],
                qryQuery["BgBudgetID"]);

            System.Collections.Specialized.HybridDictionary dic = FormController.ConvertToDictionary(jumpToPath);
            bool result = FormController.OpenForm((string)dic["ClassName"], "Action", "JumpToPath", dic);
        }

        private void grvQuery1_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == this.colSelPrint)
            {
                e.Column.Caption = "Drucken";
            }
            else if (e.Column == this.colBudgetID)
            {
                e.Column.Caption = "Budget";
            }
            else if (e.Column == this.colBudgetMonat)
            {
                e.Column.Caption = "Budget Monat";
            }
        }
    }
}