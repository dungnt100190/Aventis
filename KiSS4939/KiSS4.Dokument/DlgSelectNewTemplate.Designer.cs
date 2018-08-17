namespace KiSS4.Dokument
{
    partial class DlgSelectNewTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgSelectNewTemplate));
            this.grdAvailableTemplates = new KiSS4.Gui.KissGrid();
            this.grvAvailableTemplates = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDocFormat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repItemDocumentFormatImg = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panBottom = new System.Windows.Forms.Panel();
            this.btnUseTemplate = new KiSS4.Gui.KissButton();
            this.lblAvailableTemplatesCount = new KiSS4.Gui.KissLabel();
            this.btnCancel = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailableTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAvailableTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemDocumentFormatImg)).BeginInit();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAvailableTemplatesCount)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAvailableTemplates
            // 
            this.grdAvailableTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdAvailableTemplates.EmbeddedNavigator.Name = "";
            this.grdAvailableTemplates.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAvailableTemplates.Location = new System.Drawing.Point(0, 0);
            this.grdAvailableTemplates.MainView = this.grvAvailableTemplates;
            this.grdAvailableTemplates.Name = "grdAvailableTemplates";
            this.grdAvailableTemplates.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repItemDocumentFormatImg});
            this.grdAvailableTemplates.Size = new System.Drawing.Size(492, 279);
            this.grdAvailableTemplates.TabIndex = 0;
            this.grdAvailableTemplates.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAvailableTemplates});
            this.grdAvailableTemplates.DoubleClick += new System.EventHandler(this.grdAvailableTemplates_DoubleClick);
            // 
            // grvAvailableTemplates
            // 
            this.grvAvailableTemplates.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAvailableTemplates.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailableTemplates.Appearance.Empty.Options.UseBackColor = true;
            this.grvAvailableTemplates.Appearance.Empty.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailableTemplates.Appearance.EvenRow.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAvailableTemplates.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailableTemplates.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAvailableTemplates.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAvailableTemplates.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAvailableTemplates.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAvailableTemplates.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailableTemplates.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAvailableTemplates.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAvailableTemplates.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAvailableTemplates.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAvailableTemplates.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAvailableTemplates.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAvailableTemplates.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAvailableTemplates.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAvailableTemplates.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAvailableTemplates.Appearance.GroupRow.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAvailableTemplates.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAvailableTemplates.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAvailableTemplates.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAvailableTemplates.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAvailableTemplates.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAvailableTemplates.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAvailableTemplates.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailableTemplates.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAvailableTemplates.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAvailableTemplates.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAvailableTemplates.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAvailableTemplates.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAvailableTemplates.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailableTemplates.Appearance.OddRow.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAvailableTemplates.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailableTemplates.Appearance.Row.Options.UseBackColor = true;
            this.grvAvailableTemplates.Appearance.Row.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAvailableTemplates.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAvailableTemplates.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAvailableTemplates.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAvailableTemplates.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAvailableTemplates.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDocFormat,
            this.colName,
            this.colPath});
            this.grvAvailableTemplates.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAvailableTemplates.GridControl = this.grdAvailableTemplates;
            this.grvAvailableTemplates.Name = "grvAvailableTemplates";
            this.grvAvailableTemplates.OptionsBehavior.Editable = false;
            this.grvAvailableTemplates.OptionsCustomization.AllowFilter = false;
            this.grvAvailableTemplates.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAvailableTemplates.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAvailableTemplates.OptionsNavigation.UseTabKey = false;
            this.grvAvailableTemplates.OptionsView.ColumnAutoWidth = false;
            this.grvAvailableTemplates.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAvailableTemplates.OptionsView.ShowGroupPanel = false;
            this.grvAvailableTemplates.OptionsView.ShowIndicator = false;
            // 
            // colDocFormat
            // 
            this.colDocFormat.Caption = "Format";
            this.colDocFormat.ColumnEdit = this.repItemDocumentFormatImg;
            this.colDocFormat.FieldName = "DocFormatBinding";
            this.colDocFormat.Name = "colDocFormat";
            this.colDocFormat.Visible = true;
            this.colDocFormat.VisibleIndex = 0;
            this.colDocFormat.Width = 65;
            // 
            // repItemDocumentFormatImg
            // 
            this.repItemDocumentFormatImg.AutoHeight = false;
            this.repItemDocumentFormatImg.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repItemDocumentFormatImg.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Word", "word", 1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Excel", "excel", 2),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Other", "other", 3)});
            this.repItemDocumentFormatImg.Name = "repItemDocumentFormatImg";
            this.repItemDocumentFormatImg.SmallImages = this.imgList;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Magenta;
            this.imgList.Images.SetKeyName(0, "FolderImgList");
            this.imgList.Images.SetKeyName(1, "WordImgList");
            this.imgList.Images.SetKeyName(2, "ExcelImgList");
            this.imgList.Images.SetKeyName(3, "DocumentImgList");
            // 
            // colName
            // 
            this.colName.Caption = "Name der Vorlage";
            this.colName.FieldName = "DocTemplateName";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 200;
            // 
            // colPath
            // 
            this.colPath.Caption = "Pfad";
            this.colPath.FieldName = "DocTemplatePath";
            this.colPath.Name = "colPath";
            this.colPath.Visible = true;
            this.colPath.VisibleIndex = 2;
            this.colPath.Width = 200;
            // 
            // panBottom
            // 
            this.panBottom.Controls.Add(this.btnUseTemplate);
            this.panBottom.Controls.Add(this.lblAvailableTemplatesCount);
            this.panBottom.Controls.Add(this.btnCancel);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 279);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(492, 36);
            this.panBottom.TabIndex = 1;
            // 
            // btnUseTemplate
            // 
            this.btnUseTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUseTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUseTemplate.Location = new System.Drawing.Point(241, 6);
            this.btnUseTemplate.Name = "btnUseTemplate";
            this.btnUseTemplate.Size = new System.Drawing.Size(140, 24);
            this.btnUseTemplate.TabIndex = 0;
            this.btnUseTemplate.Text = "&Vorlage verwenden";
            this.btnUseTemplate.UseVisualStyleBackColor = false;
            this.btnUseTemplate.Click += new System.EventHandler(this.btnUseTemplate_Click);
            // 
            // lblAvailableTemplatesCount
            // 
            this.lblAvailableTemplatesCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAvailableTemplatesCount.Location = new System.Drawing.Point(9, 6);
            this.lblAvailableTemplatesCount.Name = "lblAvailableTemplatesCount";
            this.lblAvailableTemplatesCount.Size = new System.Drawing.Size(226, 24);
            this.lblAvailableTemplatesCount.TabIndex = 2;
            this.lblAvailableTemplatesCount.Text = "Anzahl Vorlagen: <Count>";
            this.lblAvailableTemplatesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(387, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DlgSelectNewTemplate
            // 
            this.AcceptButton = this.btnUseTemplate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(492, 315);
            this.Controls.Add(this.grdAvailableTemplates);
            this.Controls.Add(this.panBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgSelectNewTemplate";
            this.Text = "Neue Vorlage auswählen";
            ((System.ComponentModel.ISupportInitialize)(this.grdAvailableTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAvailableTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repItemDocumentFormatImg)).EndInit();
            this.panBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAvailableTemplatesCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissGrid grdAvailableTemplates;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAvailableTemplates;
        private DevExpress.XtraGrid.Columns.GridColumn colDocFormat;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colPath;
        private System.Windows.Forms.Panel panBottom;
        private KiSS4.Gui.KissButton btnUseTemplate;
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissLabel lblAvailableTemplatesCount;
        private System.Windows.Forms.ImageList imgList;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repItemDocumentFormatImg;

    }
}