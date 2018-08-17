using System;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using System.Text;

namespace KiSS4.Query
{
    public class CtlQueryShZulagenBrutto : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KissLookUpEdit edtHaushaltmitglied;
        private KissLookUpEdit edtSektion;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KissDateEdit edtZeitraumBis;
        private KissDateEdit edtZeitraumVon;
        private KissLookUpEdit edtZulagen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KissLabel kissLabel5;
        private KissLabel lblHaushaltmitglied;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblSAR;
        private KissLabel lblSektion;
        private KissLabel lblZeitraumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colFall;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colZulage;
        private DevExpress.XtraGrid.Columns.GridColumn colBrutto;
        private DevExpress.XtraGrid.Columns.GridColumn colEffektiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBudget;
        private KissButton btnGotoBudget;
        private KissLabel lblZulagen;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryShZulagenBrutto()
        {
            this.InitializeComponent();
        }

        private void InitGrouping()
        {
            this.gridView1.GroupSummary.Clear();
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Brutto", this.colBrutto, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Effektiv", this.colEffektiv, "{0:N2}")});

            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFall, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPerson, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.GroupCount = 2;
        }

        private void InitEdtHaushaltmitglied(int? falltraeger, DateTime? datumVon, DateTime? datumBis)
        {
            StringBuilder sql = new StringBuilder(@"
                    SELECT  BaPersonID = -1,
                            NameVorname = 'Alle'");
            if (falltraeger.HasValue)
            {
                sql.AppendFormat(@"
                    UNION ALL
                    SELECT DISTINCT PER.BaPersonID, PER.NameVorname
                    FROM dbo.vwPerson PER
                      INNER JOIN BgPosition POS ON POS.BaPersonID = PER.BaPersonID
                      INNER JOIN BgPositionsart POA ON POA.BgPositionsartID = POS.BgPositionsartID 
                        AND POA.BgGruppeCode BETWEEN 39000 AND 39999
                        AND POA.BgGruppeCode <> 39000 
                      INNER JOIN BgBudget BDG ON BDG.BgBudgetID = POS.BgBudgetID AND BDG.MasterBudget = 0
                      INNER JOIN BgFinanzplan FPL ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
                      INNER JOIN FaLeistung LEI ON LEI.FaLeistungID = FPL.FaLeistungID
                    WHERE LEI.BaPersonID = {0}", falltraeger.Value);
                if (datumVon.HasValue)
                {
                    sql.AppendFormat(@"
                     AND dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) >= {0}", DBUtil.SqlLiteral(datumVon.Value));
                }
                if (datumBis.HasValue)
                {
                    sql.AppendFormat(@"
                     AND dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1) <= {0}", DBUtil.SqlLiteral(datumBis.Value));
                }

                edtHaushaltmitglied.EditMode = EditModeType.Normal;
            }
            else
            {
                edtHaushaltmitglied.EditMode = EditModeType.ReadOnly;
            }

            SqlQuery qry = DBUtil.OpenSQL(sql.ToString());

            //set the datasource
            edtHaushaltmitglied.LoadQuery(qry, "BaPersonID", "NameVorname");

            //select the first item if nothing was pre-selected
            if (edtHaushaltmitglied.ItemIndex == -1 || edtHaushaltmitglied.ItemIndex == 0)
            {
                edtHaushaltmitglied.EditValue = qry["BaPersonID"];
            }
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryShZulagenBrutto));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colFall = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZulage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBrutto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEffektiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudget = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSektion = new KiSS4.Gui.KissLabel();
            this.lblZeitraumVon = new KiSS4.Gui.KissLabel();
            this.lblHaushaltmitglied = new KiSS4.Gui.KissLabel();
            this.lblZulagen = new KiSS4.Gui.KissLabel();
            this.edtZeitraumVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtZeitraumBis = new KiSS4.Gui.KissDateEdit();
            this.edtSektion = new KiSS4.Gui.KissLookUpEdit();
            this.edtHaushaltmitglied = new KiSS4.Gui.KissLookUpEdit();
            this.edtZulagen = new KiSS4.Gui.KissLookUpEdit();
            this.btnGotoBudget = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushaltmitglied)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZulagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaushaltmitglied)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaushaltmitglied.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZulagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZulagen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            // 
            // grvQuery1
            // 
            this.grvQuery1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Empty.Options.UseFont = true;
            this.grvQuery1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery1.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery1.Appearance.Row.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery1.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery1.OptionsBehavior.Editable = false;
            this.grvQuery1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery1.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery1.OptionsNavigation.UseTabKey = false;
            this.grvQuery1.OptionsPrint.AutoWidth = false;
            this.grvQuery1.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery1.OptionsPrint.UsePrintStyles = true;
            this.grvQuery1.OptionsView.ColumnAutoWidth = false;
            this.grvQuery1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery1.OptionsView.ShowGroupPanel = false;
            this.grvQuery1.OptionsView.ShowIndicator = false;
            // 
            // grdQuery1
            // 
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnGotoBudget);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnGotoBudget, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtZulagen);
            this.tpgSuchen.Controls.Add(this.edtHaushaltmitglied);
            this.tpgSuchen.Controls.Add(this.edtSektion);
            this.tpgSuchen.Controls.Add(this.edtZeitraumBis);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Controls.Add(this.edtZeitraumVon);
            this.tpgSuchen.Controls.Add(this.lblZulagen);
            this.tpgSuchen.Controls.Add(this.lblHaushaltmitglied);
            this.tpgSuchen.Controls.Add(this.lblSektion);
            this.tpgSuchen.Controls.Add(this.lblZeitraumVon);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.lblKlient);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblHaushaltmitglied, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZulagen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel5, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZeitraumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSektion, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtHaushaltmitglied, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZulagen, 0);
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(8, 70);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 3;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // lblKlient
            // 
            this.lblKlient.Location = new System.Drawing.Point(8, 134);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(130, 24);
            this.lblKlient.TabIndex = 9;
            this.lblKlient.Text = "Klient";
            this.lblKlient.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(148, 70);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(235, 24);
            this.edtUserID.TabIndex = 4;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Location = new System.Drawing.Point(148, 134);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(235, 24);
            this.edtBaPersonID.TabIndex = 10;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFall,
            this.colPerson,
            this.colSektion,
            this.colSAR,
            this.colZulage,
            this.colBrutto,
            this.colEffektiv,
            this.colBudget});
            this.gridView1.CustomizationFormBounds = new System.Drawing.Rectangle(1177, 590, 216, 185);
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.GroupCount = 2;
            this.gridView1.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Brutto", this.colBrutto, "{0:N2}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Effektiv", this.colEffektiv, "{0:N2}")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colFall, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colPerson, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colFall
            // 
            this.colFall.Caption = "Fall";
            this.colFall.FieldName = "Fall";
            this.colFall.Name = "colFall";
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Person";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            // 
            // colSektion
            // 
            this.colSektion.Caption = "Sektion";
            this.colSektion.FieldName = "Sektion";
            this.colSektion.Name = "colSektion";
            this.colSektion.Visible = true;
            this.colSektion.VisibleIndex = 0;
            // 
            // colSAR
            // 
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 1;
            // 
            // colZulage
            // 
            this.colZulage.Caption = "Zulage";
            this.colZulage.FieldName = "Zulage";
            this.colZulage.Name = "colZulage";
            this.colZulage.Visible = true;
            this.colZulage.VisibleIndex = 2;
            // 
            // colBrutto
            // 
            this.colBrutto.Caption = "Brutto";
            this.colBrutto.DisplayFormat.FormatString = "N2";
            this.colBrutto.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBrutto.FieldName = "Brutto";
            this.colBrutto.GroupFormat.FormatString = "N2";
            this.colBrutto.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBrutto.Name = "colBrutto";
            this.colBrutto.SummaryItem.DisplayFormat = "{0:N2}";
            this.colBrutto.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBrutto.Visible = true;
            this.colBrutto.VisibleIndex = 3;
            // 
            // colEffektiv
            // 
            this.colEffektiv.Caption = "Effektiv";
            this.colEffektiv.DisplayFormat.FormatString = "{0:N2}";
            this.colEffektiv.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEffektiv.FieldName = "Effektiv";
            this.colEffektiv.GroupFormat.FormatString = "N2";
            this.colEffektiv.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colEffektiv.Name = "colEffektiv";
            this.colEffektiv.SummaryItem.DisplayFormat = "{0:N2}";
            this.colEffektiv.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colEffektiv.Visible = true;
            this.colEffektiv.VisibleIndex = 4;
            // 
            // colBudget
            // 
            this.colBudget.AppearanceCell.Options.UseTextOptions = true;
            this.colBudget.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colBudget.Caption = "Budget";
            this.colBudget.DisplayFormat.FormatString = "MMM yyyy";
            this.colBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colBudget.FieldName = "BudgetMonat";
            this.colBudget.Name = "colBudget";
            this.colBudget.Visible = true;
            this.colBudget.VisibleIndex = 5;
            // 
            // lblSektion
            // 
            this.lblSektion.Location = new System.Drawing.Point(8, 38);
            this.lblSektion.Name = "lblSektion";
            this.lblSektion.Size = new System.Drawing.Size(100, 23);
            this.lblSektion.TabIndex = 1;
            this.lblSektion.Text = "Sektion";
            // 
            // lblZeitraumVon
            // 
            this.lblZeitraumVon.Location = new System.Drawing.Point(8, 102);
            this.lblZeitraumVon.Name = "lblZeitraumVon";
            this.lblZeitraumVon.Size = new System.Drawing.Size(100, 23);
            this.lblZeitraumVon.TabIndex = 5;
            this.lblZeitraumVon.Text = "Zeitraum von";
            // 
            // lblHaushaltmitglied
            // 
            this.lblHaushaltmitglied.Location = new System.Drawing.Point(8, 166);
            this.lblHaushaltmitglied.Name = "lblHaushaltmitglied";
            this.lblHaushaltmitglied.Size = new System.Drawing.Size(100, 23);
            this.lblHaushaltmitglied.TabIndex = 11;
            this.lblHaushaltmitglied.Text = "Haushaltmitglied";
            // 
            // lblZulagen
            // 
            this.lblZulagen.Location = new System.Drawing.Point(8, 198);
            this.lblZulagen.Name = "lblZulagen";
            this.lblZulagen.Size = new System.Drawing.Size(100, 23);
            this.lblZulagen.TabIndex = 13;
            this.lblZulagen.Text = "Zulagen";
            // 
            // edtZeitraumVon
            // 
            this.edtZeitraumVon.EditValue = null;
            this.edtZeitraumVon.Location = new System.Drawing.Point(148, 102);
            this.edtZeitraumVon.Name = "edtZeitraumVon";
            this.edtZeitraumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitraumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraumVon.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtZeitraumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtZeitraumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumVon.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtZeitraumVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeitraumVon.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtZeitraumVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeitraumVon.Properties.Mask.EditMask = "MM.yyyy";
            this.edtZeitraumVon.Properties.ShowToday = false;
            this.edtZeitraumVon.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumVon.TabIndex = 6;
            this.edtZeitraumVon.EditValueChanged += new System.EventHandler(this.edtZeitraumVon_EditValueChanged);
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(254, 102);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(33, 24);
            this.kissLabel5.TabIndex = 7;
            this.kissLabel5.Text = "bis";
            // 
            // edtZeitraumBis
            // 
            this.edtZeitraumBis.EditValue = null;
            this.edtZeitraumBis.Location = new System.Drawing.Point(283, 102);
            this.edtZeitraumBis.Name = "edtZeitraumBis";
            this.edtZeitraumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtZeitraumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZeitraumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZeitraumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZeitraumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtZeitraumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZeitraumBis.Properties.Appearance.Options.UseFont = true;
            this.edtZeitraumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtZeitraumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtZeitraumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtZeitraumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZeitraumBis.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtZeitraumBis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeitraumBis.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtZeitraumBis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtZeitraumBis.Properties.Mask.EditMask = "MM.yyyy";
            this.edtZeitraumBis.Properties.ShowToday = false;
            this.edtZeitraumBis.Size = new System.Drawing.Size(100, 24);
            this.edtZeitraumBis.TabIndex = 8;
            this.edtZeitraumBis.EditValueChanged += new System.EventHandler(this.edtZeitraumBis_EditValueChanged);
            // 
            // edtSektion
            // 
            this.edtSektion.Location = new System.Drawing.Point(148, 36);
            this.edtSektion.Name = "edtSektion";
            this.edtSektion.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSektion.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSektion.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektion.Properties.Appearance.Options.UseBackColor = true;
            this.edtSektion.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSektion.Properties.Appearance.Options.UseFont = true;
            this.edtSektion.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSektion.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSektion.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSektion.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSektion.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSektion.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSektion.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSektion.Properties.NullText = "";
            this.edtSektion.Properties.ShowFooter = false;
            this.edtSektion.Properties.ShowHeader = false;
            this.edtSektion.Size = new System.Drawing.Size(235, 24);
            this.edtSektion.TabIndex = 2;
            // 
            // edtHaushaltmitglied
            // 
            this.edtHaushaltmitglied.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHaushaltmitglied.Location = new System.Drawing.Point(148, 164);
            this.edtHaushaltmitglied.Name = "edtHaushaltmitglied";
            this.edtHaushaltmitglied.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHaushaltmitglied.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHaushaltmitglied.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHaushaltmitglied.Properties.Appearance.Options.UseBackColor = true;
            this.edtHaushaltmitglied.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHaushaltmitglied.Properties.Appearance.Options.UseFont = true;
            this.edtHaushaltmitglied.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtHaushaltmitglied.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtHaushaltmitglied.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtHaushaltmitglied.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtHaushaltmitglied.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtHaushaltmitglied.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtHaushaltmitglied.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtHaushaltmitglied.Properties.NullText = "";
            this.edtHaushaltmitglied.Properties.ReadOnly = true;
            this.edtHaushaltmitglied.Properties.ShowFooter = false;
            this.edtHaushaltmitglied.Properties.ShowHeader = false;
            this.edtHaushaltmitglied.Size = new System.Drawing.Size(235, 24);
            this.edtHaushaltmitglied.TabIndex = 12;
            // 
            // edtZulagen
            // 
            this.edtZulagen.AllowNull = false;
            this.edtZulagen.Location = new System.Drawing.Point(148, 196);
            this.edtZulagen.Name = "edtZulagen";
            this.edtZulagen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZulagen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZulagen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZulagen.Properties.Appearance.Options.UseBackColor = true;
            this.edtZulagen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZulagen.Properties.Appearance.Options.UseFont = true;
            this.edtZulagen.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZulagen.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZulagen.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZulagen.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZulagen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZulagen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZulagen.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZulagen.Properties.NullText = "";
            this.edtZulagen.Properties.ShowFooter = false;
            this.edtZulagen.Properties.ShowHeader = false;
            this.edtZulagen.Size = new System.Drawing.Size(235, 24);
            this.edtZulagen.TabIndex = 14;
            // 
            // btnGotoBudget
            // 
            this.btnGotoBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGotoBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoBudget.Location = new System.Drawing.Point(190, 398);
            this.btnGotoBudget.Name = "btnGotoBudget";
            this.btnGotoBudget.Size = new System.Drawing.Size(119, 24);
            this.btnGotoBudget.TabIndex = 51;
            this.btnGotoBudget.Text = "> &Monatsbudget";
            this.btnGotoBudget.UseCompatibleTextRendering = true;
            this.btnGotoBudget.UseVisualStyleBackColor = false;
            this.btnGotoBudget.Click += new System.EventHandler(this.btnGotoBudget_Click);
            // 
            // CtlQueryShZulagenBrutto
            // 
            this.Name = "CtlQueryShZulagenBrutto";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushaltmitglied)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZulagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZeitraumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSektion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaushaltmitglied.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaushaltmitglied)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZulagen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZulagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region EventHandlers

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;

                    InitEdtHaushaltmitglied(edtBaPersonID.LookupID as int?, edtZeitraumVon.EditValue as DateTime?, edtZeitraumBis.EditValue as DateTime?);
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();

            e.Cancel = !dlg.ShFalltraegerSuchen(SearchString, false, edtUserID.LookupID as int?,  edtSektion.EditValue as int?, e.ButtonClicked);
            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg["Name"];
                edtBaPersonID.LookupID = dlg["BaPersonID"];

                InitEdtHaushaltmitglied(edtBaPersonID.LookupID as int?, edtZeitraumVon.EditValue as DateTime?, edtZeitraumBis.EditValue as DateTime?);
            }
        }

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void InitEdtSektion()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT  Code = OrgUnitID,
                        Text = ItemName
                FROM XOrgUnit
                WHERE ModulID = 3
                ORDER BY ItemName");

            //Include empty item
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();

            edtSektion.LoadQuery(qry);
        }

        private void InitEdtZulagen()
        {
            SqlQuery qryWithConc = DBUtil.OpenSQL(@"
                SELECT Code = dbo.ConcDistinct(Code),
                  Text = 'Alle Zulagen'
                FROM XLOVCode
                WHERE LOVName = 'BgGruppe'
                  AND Code BETWEEN 39000 AND 39999
                  AND Code <> 39000
                UNION ALL
                SELECT Code = dbo.ConcDistinct(Code),
                  Text = Text
                FROM XLOVCode
                WHERE LOVName = 'BgGruppe'
                  AND Code BETWEEN 39000 AND 39999
                  AND Code <> 39000
                GROUP BY Text");

            //set the datasource
            edtZulagen.LoadQuery(qryWithConc);

            //TODO: select the first item
            edtZulagen.EditValue = qryWithConc["Code"];
        }

        #endregion

        private void edtZeitraumVon_EditValueChanged(object sender, EventArgs e)
        {
            //filter edtHaushaltmitglied
            InitEdtHaushaltmitglied(edtBaPersonID.LookupID as int?, edtZeitraumVon.EditValue as DateTime?, edtZeitraumBis.EditValue as DateTime?);
        }


        #endregion

        private void edtZeitraumBis_EditValueChanged(object sender, EventArgs e)
        {
            //filter edtHaushaltmitglied
            InitEdtHaushaltmitglied(edtBaPersonID.LookupID as int?, edtZeitraumVon.EditValue as DateTime?, edtZeitraumBis.EditValue as DateTime?);
        }

        protected override void NewSearch()
        {
            base.NewSearch();

            InitEdtSektion();
            InitEdtZulagen();
            InitEdtHaushaltmitglied(null, null, null);
        }

        protected override void RunSearch()
        {
            base.RunSearch();
            InitGrouping();
        }

        private void btnGotoBudget_Click(object sender, EventArgs e)
        {
            bool result = FormController.OpenForm(
                "FrmFall", "Action", "JumpToPath",
                "BaPersonID", qryQuery["BaPersonID$"],
                "ModulID", 3,
                "TreeNodeID", string.Format("CtlWhFinanzplan{0}\\BBG{1}", qryQuery["BgFinanzplanID$"], qryQuery["BgBudgetID$"]),
                "ActiveSQLQuery.Find", string.Format("BgPositionID = {0}", qryQuery["BgPositionID$"]));
        }
    }
}