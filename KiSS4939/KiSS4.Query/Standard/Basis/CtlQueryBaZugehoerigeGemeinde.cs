
namespace KiSS4.Query
{
    public class CtlQueryBaZugehoerigeGemeinde : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBFSCode;
        private DevExpress.XtraGrid.Columns.GridColumn colKanton;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colZugehrigeGemeinde;
        private KiSS4.Gui.KissButtonEdit edtGemeindeID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblGemeinde;

        #endregion

        #region Constructors

        public CtlQueryBaZugehoerigeGemeinde()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaZugehoerigeGemeinde));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblGemeinde = new KiSS4.Gui.KissLabel();
            this.edtGemeindeID = new KiSS4.Gui.KissButtonEdit();
            this.colBFSCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKanton = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZugehrigeGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeinde)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtGemeindeID);
            this.tpgSuchen.Controls.Add(this.lblGemeinde);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGemeinde, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGemeindeID, 0);
            // 
            // lblGemeinde
            // 
            this.lblGemeinde.Location = new System.Drawing.Point(10, 40);
            this.lblGemeinde.Name = "lblGemeinde";
            this.lblGemeinde.Size = new System.Drawing.Size(130, 24);
            this.lblGemeinde.TabIndex = 0;
            this.lblGemeinde.Text = "Gemeinde";
            this.lblGemeinde.UseCompatibleTextRendering = true;
            // 
            // edtGemeindeID
            // 
            this.edtGemeindeID.Location = new System.Drawing.Point(150, 40);
            this.edtGemeindeID.LookupSQL = "SELECT BFSCode,\r\n       Name,\r\n       PLZ,\r\n       Kanton\r\nFROM BaPLZ\r\nWHERE Name" +
                " LIKE ISNULL({0}, \'\') + \'%\'\r\nORDER BY Name\r\n----";
            this.edtGemeindeID.Name = "edtGemeindeID";
            this.edtGemeindeID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGemeindeID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGemeindeID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGemeindeID.Properties.Appearance.Options.UseBackColor = true;
            this.edtGemeindeID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGemeindeID.Properties.Appearance.Options.UseFont = true;
            this.edtGemeindeID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGemeindeID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGemeindeID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGemeindeID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtGemeindeID.Size = new System.Drawing.Size(220, 24);
            this.edtGemeindeID.TabIndex = 20;
            // 
            // colBFSCode
            // 
            this.colBFSCode.Name = "colBFSCode";
            // 
            // colKanton
            // 
            this.colKanton.Name = "colKanton";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colZugehrigeGemeinde
            // 
            this.colZugehrigeGemeinde.Name = "colZugehrigeGemeinde";
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
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // CtlQueryBaZugehoerigeGemeinde
            // 
            this.Name = "CtlQueryBaZugehoerigeGemeinde";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblGemeinde)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGemeindeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}