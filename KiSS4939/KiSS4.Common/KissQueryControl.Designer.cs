namespace KiSS4.Common
{
    partial class KissQueryControl
    {
        #region Fields and Properties

        private System.Windows.Forms.ToolTip ttpSuchkriterienInfo;


        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblRowCount1;

        private System.Windows.Forms.Label lblAmount;

        /// <summary>
        /// The SQL query.
        /// </summary>
        protected KiSS4.DB.SqlQuery qryQuery;

        /// <summary>
        /// Gridview.
        /// </summary>
        protected DevExpress.XtraGrid.Views.Grid.GridView grvQuery1;

        /// <summary>
        /// Grid.
        /// </summary>
        protected KiSS4.Gui.KissGrid grdQuery1;

        /// <summary>
        /// Document.
        /// </summary>
        protected KiSS4.Dokument.XDokument xDocument;

        /// <summary>
        /// Control für fallverlauf.
        /// </summary>
        protected CtlGotoFall ctlGotoFall;

        private KiSS4.Gui.KissCheckEdit chkShowGroupPanel;

        private KiSS4.Gui.KissCheckEdit chkMultilineSelect;

        #endregion

        #region IDisposable Members

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KissQueryControl));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.xDocument = new KiSS4.Dokument.XDokument();
            this.qryQuery = new KiSS4.DB.SqlQuery(this.components);
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.grdQuery1 = new KiSS4.Gui.KissGrid();
            this.grvQuery1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblRowCount1 = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.chkShowGroupPanel = new KiSS4.Gui.KissCheckEdit();
            this.chkMultilineSelect = new KiSS4.Gui.KissCheckEdit();
            this.lblSuchkriterienInfo = new System.Windows.Forms.Label();
            this.ttpSuchkriterienInfo = new System.Windows.Forms.ToolTip(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowGroupPanel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMultilineSelect.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(760, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(8, 35);
            this.tabControlSearch.Size = new System.Drawing.Size(784, 462);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.lblSuchkriterienInfo);
            this.tpgListe.Controls.Add(this.xDocument);
            this.tpgListe.Controls.Add(this.ctlGotoFall);
            this.tpgListe.Controls.Add(this.grdQuery1);
            this.tpgListe.Size = new System.Drawing.Size(772, 424);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Size = new System.Drawing.Size(772, 424);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            // 
            // xDocument
            // 
            this.xDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.xDocument.Context = null;
            this.xDocument.DataSource = this.qryQuery;
            this.xDocument.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.xDocument.EditValue = "";
            this.xDocument.Location = new System.Drawing.Point(164, 398);
            this.xDocument.Name = "xDocument";
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.xDocument.Properties.ReadOnly = true;
            this.xDocument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.xDocument.Size = new System.Drawing.Size(136, 24);
            this.xDocument.TabIndex = 2;
            // 
            // qryQuery
            // 
            this.qryQuery.FillTimeOut = 300;
            this.qryQuery.HostControl = this;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall.AutoSize = true;
            this.ctlGotoFall.DataSource = this.qryQuery;
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 395);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 27);
            this.ctlGotoFall.TabIndex = 1;
            // 
            // grdQuery1
            // 
            this.grdQuery1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdQuery1.ColumnFilterActivated = true;
            this.grdQuery1.DataSource = this.qryQuery;
            // 
            // 
            // 
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdQuery1.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdQuery1.Location = new System.Drawing.Point(3, 0);
            this.grdQuery1.MainView = this.grvQuery1;
            this.grdQuery1.Name = "grdQuery1";
            this.grdQuery1.Size = new System.Drawing.Size(766, 392);
            this.grdQuery1.TabIndex = 0;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvQuery1});
            this.grdQuery1.DoubleClick += new System.EventHandler(this.grdQuery1_DoubleClick);
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
            this.grvQuery1.BestFitMaxRowCount = 50;
            this.grvQuery1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvQuery1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvQuery1.GridControl = this.grdQuery1;
            this.grvQuery1.Name = "grvQuery1";
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
            // lblRowCount1
            // 
            this.lblRowCount1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount1.AutoEllipsis = true;
            this.lblRowCount1.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblRowCount1.Location = new System.Drawing.Point(726, 11);
            this.lblRowCount1.Name = "lblRowCount1";
            this.lblRowCount1.Size = new System.Drawing.Size(67, 17);
            this.lblRowCount1.TabIndex = 4;
            this.lblRowCount1.Text = "0";
            this.lblRowCount1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.lblRowCount1.UseMnemonic = false;
            // 
            // lblAmount
            // 
            this.lblAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAmount.AutoSize = true;
            this.lblAmount.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAmount.Location = new System.Drawing.Point(618, 11);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(102, 14);
            this.lblAmount.TabIndex = 3;
            this.lblAmount.Text = "Anzahl Datensätze:";
            // 
            // chkShowGroupPanel
            // 
            this.chkShowGroupPanel.EditValue = false;
            this.chkShowGroupPanel.Location = new System.Drawing.Point(14, 9);
            this.chkShowGroupPanel.Name = "chkShowGroupPanel";
            this.chkShowGroupPanel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkShowGroupPanel.Properties.Appearance.Options.UseBackColor = true;
            this.chkShowGroupPanel.Properties.Caption = "Gruppierung";
            this.chkShowGroupPanel.Size = new System.Drawing.Size(113, 19);
            this.chkShowGroupPanel.TabIndex = 1;
            this.chkShowGroupPanel.CheckedChanged += new System.EventHandler(this.chkShowGroupPanel_CheckedChanged);
            // 
            // chkMultilineSelect
            // 
            this.chkMultilineSelect.EditValue = false;
            this.chkMultilineSelect.Location = new System.Drawing.Point(133, 9);
            this.chkMultilineSelect.Name = "chkMultilineSelect";
            this.chkMultilineSelect.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMultilineSelect.Properties.Appearance.Options.UseBackColor = true;
            this.chkMultilineSelect.Properties.Caption = "Mehrfachselektion";
            this.chkMultilineSelect.Size = new System.Drawing.Size(131, 19);
            this.chkMultilineSelect.TabIndex = 2;
            this.chkMultilineSelect.Visible = false;
            this.chkMultilineSelect.CheckedChanged += new System.EventHandler(this.chkMultilineSelect_CheckedChanged);
            // 
            // lblSuchkriterienInfo
            // 
            this.lblSuchkriterienInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchkriterienInfo.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblSuchkriterienInfo.Location = new System.Drawing.Point(306, 399);
            this.lblSuchkriterienInfo.Name = "lblSuchkriterienInfo";
            this.lblSuchkriterienInfo.Size = new System.Drawing.Size(463, 13);
            this.lblSuchkriterienInfo.TabIndex = 6;
            this.lblSuchkriterienInfo.Text = "Nam:aaaa, Vor:aaadflkjfs, Geb:01.01.2014, bis:01.12.2014, AHV:1122.323.3.34";
            // 
            // KissQueryControl
            // 
            this.ActiveSQLQuery = this.qryQuery;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.chkMultilineSelect);
            this.Controls.Add(this.chkShowGroupPanel);
            this.Controls.Add(this.lblRowCount1);
            this.Name = "KissQueryControl";
            this.Load += new System.EventHandler(this.KissQueryControl_Load);
            this.Controls.SetChildIndex(this.lblRowCount1, 0);
            this.Controls.SetChildIndex(this.chkShowGroupPanel, 0);
            this.Controls.SetChildIndex(this.chkMultilineSelect, 0);
            this.Controls.SetChildIndex(this.lblAmount, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowGroupPanel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMultilineSelect.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Label lblSuchkriterienInfo;


    }
}
