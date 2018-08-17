namespace KiSS4.Main
{
    partial class KissSearchDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.qry = new KiSS4.DB.SqlQuery(this.components);
            this.btnOK = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.grd = new KiSS4.Gui.KissGrid();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Typ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.Beschreibung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblSuchbegriff = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchbegriff)).BeginInit();
            this.SuspendLayout();
            // 
            // qry
            // 
            this.qry.HostControl = this;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(242, 226);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(344, 226);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grd
            // 
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grd.EmbeddedNavigator.Name = "";
            this.grd.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grd.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grd.Location = new System.Drawing.Point(12, 12);
            this.grd.MainView = this.grv;
            this.grd.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.grd.Name = "grd";
            this.grd.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grd.Size = new System.Drawing.Size(428, 208);
            this.grd.TabIndex = 5;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            this.grd.DoubleClick += new System.EventHandler(this.grd_DoubleClick);
            // 
            // grv
            // 
            this.grv.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grv.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.Empty.Options.UseBackColor = true;
            this.grv.Appearance.Empty.Options.UseFont = true;
            this.grv.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.EvenRow.Options.UseFont = true;
            this.grv.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grv.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grv.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grv.Appearance.FocusedCell.Options.UseFont = true;
            this.grv.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grv.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grv.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grv.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grv.Appearance.FocusedRow.Options.UseFont = true;
            this.grv.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grv.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grv.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grv.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grv.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grv.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grv.Appearance.GroupRow.Options.UseBackColor = true;
            this.grv.Appearance.GroupRow.Options.UseFont = true;
            this.grv.Appearance.GroupRow.Options.UseForeColor = true;
            this.grv.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grv.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grv.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grv.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grv.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grv.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grv.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grv.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grv.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grv.Appearance.HorzLine.Options.UseBackColor = true;
            this.grv.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.OddRow.Options.UseFont = true;
            this.grv.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.Row.Options.UseBackColor = true;
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.SelectedRow.Options.UseFont = true;
            this.grv.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grv.Appearance.VertLine.Options.UseBackColor = true;
            this.grv.BestFitMaxRowCount = 1000;
            this.grv.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grv.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Typ,
            this.Beschreibung});
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grv.OptionsNavigation.AutoFocusNewRow = true;
            this.grv.OptionsNavigation.UseTabKey = false;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.OptionsView.ShowIndicator = false;
            // 
            // Typ
            // 
            this.Typ.ColumnEdit = this.repositoryItemImageComboBox1;
            this.Typ.FieldName = "Typ";
            this.Typ.Name = "Typ";
            this.Typ.Visible = true;
            this.Typ.VisibleIndex = 0;
            this.Typ.Width = 48;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // Beschreibung
            // 
            this.Beschreibung.Caption = "Beschreibung";
            this.Beschreibung.FieldName = "Beschreibung";
            this.Beschreibung.MinWidth = 100;
            this.Beschreibung.Name = "Beschreibung";
            this.Beschreibung.Visible = true;
            this.Beschreibung.VisibleIndex = 1;
            this.Beschreibung.Width = 355;
            // 
            // lblSuchbegriff
            // 
            this.lblSuchbegriff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSuchbegriff.AutoEllipsis = true;
            this.lblSuchbegriff.Location = new System.Drawing.Point(12, 226);
            this.lblSuchbegriff.Name = "lblSuchbegriff";
            this.lblSuchbegriff.Size = new System.Drawing.Size(224, 24);
            this.lblSuchbegriff.TabIndex = 10;
            this.lblSuchbegriff.Text = "";
            // 
            // KissSearchDialog
            // 
            this.AcceptButton = this.btnOK;
            this.ActiveSQLQuery = this.qry;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(451, 262);
            this.Controls.Add(this.lblSuchbegriff);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MinimizeBox = true;
            this.MinimumSize = new System.Drawing.Size(467, 300);
            this.Name = "KissSearchDialog";
            this.Text = "KiSS Suchergebnisse";
            this.Load += new System.EventHandler(this.KissSearchDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchbegriff)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DB.SqlQuery qry;
        protected Gui.KissButton btnOK;
        protected Gui.KissButton btnCancel;
        protected Gui.KissGrid grd;
        private DevExpress.XtraGrid.Views.Grid.GridView grv;
        private DevExpress.XtraGrid.Columns.GridColumn Typ;
        private DevExpress.XtraGrid.Columns.GridColumn Beschreibung;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private Gui.KissLabel lblSuchbegriff;
    }
}
