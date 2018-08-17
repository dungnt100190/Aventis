namespace KiSS4.Administration
{
    partial class CtlRenameBookmarks
    {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlRenameBookmarks));
            this.qryXDocTemplate = new KiSS4.DB.SqlQuery(this.components);
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.qryXBookmark = new KiSS4.DB.SqlQuery(this.components);
            this.sfdOutput = new System.Windows.Forms.SaveFileDialog();
            this.bgwLoadBookmarks = new System.ComponentModel.BackgroundWorker();
            this.bgwRenameBookmarks = new System.ComponentModel.BackgroundWorker();
            this.lblProgressText = new KiSS4.Gui.KissLabel();
            this.grpRenameBookmarks = new KiSS4.Gui.KissGroupBox();
            this.txtRenameTo = new KiSS4.Gui.KissTextEdit();
            this.btnRename = new KiSS4.Gui.KissButton();
            this.grpBookmarkFilter = new KiSS4.Gui.KissGroupBox();
            this.txtFilter = new KiSS4.Gui.KissTextEdit();
            this.chkStrict = new KiSS4.Gui.KissCheckEdit();
            this.chkValidate = new KiSS4.Gui.KissCheckEdit();
            this.chkRegex = new KiSS4.Gui.KissCheckEdit();
            this.btnSaveList = new KiSS4.Gui.KissButton();
            this.lblProgress = new KiSS4.Gui.KissLabel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.lblResult = new KiSS4.Gui.KissLabel();
            this.lvwResult = new System.Windows.Forms.ListView();
            this.chdBookmarkName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtTemplateFilter = new KiSS4.Gui.KissTextEdit();
            this.lblTemplateFilter = new KiSS4.Gui.KissLabel();
            this.btnRenameFromFile = new KiSS4.Gui.KissButton();
            this.ofdRenameFile = new System.Windows.Forms.OpenFileDialog();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryXDocTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXBookmark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgressText)).BeginInit();
            this.grpRenameBookmarks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRenameTo.Properties)).BeginInit();
            this.grpBookmarkFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStrict.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkValidate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRegex.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTemplateFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(720, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(750, 500);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnRenameFromFile);
            this.tpgListe.Controls.Add(this.lblProgressText);
            this.tpgListe.Controls.Add(this.grpRenameBookmarks);
            this.tpgListe.Controls.Add(this.grpBookmarkFilter);
            this.tpgListe.Controls.Add(this.btnSaveList);
            this.tpgListe.Controls.Add(this.lblProgress);
            this.tpgListe.Controls.Add(this.progressBar);
            this.tpgListe.Controls.Add(this.btnCancel);
            this.tpgListe.Controls.Add(this.lblResult);
            this.tpgListe.Controls.Add(this.lvwResult);
            this.tpgListe.Size = new System.Drawing.Size(738, 462);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.txtTemplateFilter);
            this.tpgSuchen.Controls.Add(this.lblTemplateFilter);
            this.tpgSuchen.Size = new System.Drawing.Size(738, 462);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTemplateFilter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.txtTemplateFilter, 0);
            // 
            // qryXDocTemplate
            // 
            this.qryXDocTemplate.HostControl = this;
            this.qryXDocTemplate.TableName = "XDocTemplate";
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "word");
            this.imgList.Images.SetKeyName(1, "excel");
            // 
            // qryXBookmark
            // 
            this.qryXBookmark.HostControl = this;
            this.qryXBookmark.TableName = "XBookmark";
            // 
            // sfdOutput
            // 
            this.sfdOutput.DefaultExt = "xml";
            this.sfdOutput.FileName = "Textmarken";
            this.sfdOutput.Filter = "Text files|*.txt|All files|*.*";
            this.sfdOutput.Title = "Liste speichern unter:";
            // 
            // bgwLoadBookmarks
            // 
            this.bgwLoadBookmarks.WorkerReportsProgress = true;
            this.bgwLoadBookmarks.WorkerSupportsCancellation = true;
            this.bgwLoadBookmarks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwLoadBookmarks_DoWork);
            this.bgwLoadBookmarks.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.bgwLoadBookmarks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwLoadBookmarks_RunWorkerCompleted);
            // 
            // bgwRenameBookmarks
            // 
            this.bgwRenameBookmarks.WorkerReportsProgress = true;
            this.bgwRenameBookmarks.WorkerSupportsCancellation = true;
            this.bgwRenameBookmarks.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwRenameBookmarks_DoWork);
            this.bgwRenameBookmarks.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ProgressChanged);
            this.bgwRenameBookmarks.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwRenameBookmarks_RunWorkerCompleted);
            // 
            // lblProgressText
            // 
            this.lblProgressText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProgressText.Location = new System.Drawing.Point(6, 429);
            this.lblProgressText.Name = "lblProgressText";
            this.lblProgressText.Size = new System.Drawing.Size(66, 24);
            this.lblProgressText.TabIndex = 7;
            this.lblProgressText.Text = "Fortschritt:";
            // 
            // grpRenameBookmarks
            // 
            this.grpRenameBookmarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRenameBookmarks.Controls.Add(this.txtRenameTo);
            this.grpRenameBookmarks.Controls.Add(this.btnRename);
            this.grpRenameBookmarks.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpRenameBookmarks.Location = new System.Drawing.Point(435, 348);
            this.grpRenameBookmarks.Name = "grpRenameBookmarks";
            this.grpRenameBookmarks.Size = new System.Drawing.Size(294, 75);
            this.grpRenameBookmarks.TabIndex = 6;
            this.grpRenameBookmarks.TabStop = false;
            this.grpRenameBookmarks.Text = "Markierte Textmarken umbenennen:";
            // 
            // txtRenameTo
            // 
            this.txtRenameTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRenameTo.Location = new System.Drawing.Point(6, 19);
            this.txtRenameTo.Name = "txtRenameTo";
            this.txtRenameTo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtRenameTo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtRenameTo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtRenameTo.Properties.Appearance.Options.UseBackColor = true;
            this.txtRenameTo.Properties.Appearance.Options.UseBorderColor = true;
            this.txtRenameTo.Properties.Appearance.Options.UseFont = true;
            this.txtRenameTo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtRenameTo.Size = new System.Drawing.Size(166, 24);
            this.txtRenameTo.TabIndex = 0;
            this.txtRenameTo.EditValueChanged += new System.EventHandler(this.txtRenameTo_EditValueChanged);
            // 
            // btnRename
            // 
            this.btnRename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRename.Location = new System.Drawing.Point(178, 19);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(110, 24);
            this.btnRename.TabIndex = 1;
            this.btnRename.Text = "Umbenennen";
            this.btnRename.UseVisualStyleBackColor = false;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // grpBookmarkFilter
            // 
            this.grpBookmarkFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpBookmarkFilter.Controls.Add(this.txtFilter);
            this.grpBookmarkFilter.Controls.Add(this.chkStrict);
            this.grpBookmarkFilter.Controls.Add(this.chkValidate);
            this.grpBookmarkFilter.Controls.Add(this.chkRegex);
            this.grpBookmarkFilter.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpBookmarkFilter.Location = new System.Drawing.Point(9, 348);
            this.grpBookmarkFilter.Name = "grpBookmarkFilter";
            this.grpBookmarkFilter.Size = new System.Drawing.Size(300, 75);
            this.grpBookmarkFilter.TabIndex = 5;
            this.grpBookmarkFilter.TabStop = false;
            this.grpBookmarkFilter.Text = "Textmarken filtern:";
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(6, 19);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.txtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.txtFilter.Properties.Appearance.Options.UseFont = true;
            this.txtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtFilter.Size = new System.Drawing.Size(288, 24);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.EditValueChanged += new System.EventHandler(this.txtFilter_EditValueChanged);
            // 
            // chkStrict
            // 
            this.chkStrict.EditValue = false;
            this.chkStrict.Location = new System.Drawing.Point(6, 49);
            this.chkStrict.Name = "chkStrict";
            this.chkStrict.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkStrict.Properties.Appearance.Options.UseBackColor = true;
            this.chkStrict.Properties.Caption = "Strikt";
            this.chkStrict.Size = new System.Drawing.Size(50, 19);
            this.chkStrict.TabIndex = 1;
            this.chkStrict.CheckedChanged += new System.EventHandler(this.chkStrict_CheckedChanged);
            // 
            // chkValidate
            // 
            this.chkValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkValidate.EditValue = false;
            this.chkValidate.Location = new System.Drawing.Point(206, 49);
            this.chkValidate.Name = "chkValidate";
            this.chkValidate.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkValidate.Properties.Appearance.Options.UseBackColor = true;
            this.chkValidate.Properties.Caption = "Nur ungültige";
            this.chkValidate.Size = new System.Drawing.Size(88, 19);
            this.chkValidate.TabIndex = 3;
            this.chkValidate.CheckedChanged += new System.EventHandler(this.chkValidate_CheckedChanged);
            // 
            // chkRegex
            // 
            this.chkRegex.EditValue = false;
            this.chkRegex.Location = new System.Drawing.Point(62, 49);
            this.chkRegex.Name = "chkRegex";
            this.chkRegex.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkRegex.Properties.Appearance.Options.UseBackColor = true;
            this.chkRegex.Properties.Caption = "Regex";
            this.chkRegex.Size = new System.Drawing.Size(60, 19);
            this.chkRegex.TabIndex = 2;
            this.chkRegex.CheckedChanged += new System.EventHandler(this.chkRegex_CheckedChanged);
            // 
            // btnSaveList
            // 
            this.btnSaveList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveList.Location = new System.Drawing.Point(423, 3);
            this.btnSaveList.Name = "btnSaveList";
            this.btnSaveList.Size = new System.Drawing.Size(150, 24);
            this.btnSaveList.TabIndex = 2;
            this.btnSaveList.Text = "Liste speichern";
            this.btnSaveList.UseVisualStyleBackColor = false;
            this.btnSaveList.Click += new System.EventHandler(this.btnSaveList_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblProgress.Location = new System.Drawing.Point(668, 429);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(61, 24);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "0/0";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(85, 435);
            this.progressBar.Margin = new System.Windows.Forms.Padding(9, 3, 3, 9);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(577, 18);
            this.progressBar.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(267, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(150, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Vorgang abbrechen";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(6, 3);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(250, 24);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Liste der Textmarken:";
            // 
            // lvwResult
            // 
            this.lvwResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chdBookmarkName});
            this.lvwResult.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwResult.Location = new System.Drawing.Point(9, 33);
            this.lvwResult.Margin = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.lvwResult.Name = "lvwResult";
            this.lvwResult.Size = new System.Drawing.Size(720, 309);
            this.lvwResult.SmallImageList = this.imgList;
            this.lvwResult.TabIndex = 4;
            this.lvwResult.UseCompatibleStateImageBehavior = false;
            this.lvwResult.View = System.Windows.Forms.View.Details;
            this.lvwResult.SelectedIndexChanged += new System.EventHandler(this.lvwResult_SelectedIndexChanged);
            this.lvwResult.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwResult_KeyDown);
            this.lvwResult.Resize += new System.EventHandler(this.lvwResult_Resize);
            // 
            // chdBookmarkName
            // 
            this.chdBookmarkName.Width = 755;
            // 
            // txtTemplateFilter
            // 
            this.txtTemplateFilter.Location = new System.Drawing.Point(114, 40);
            this.txtTemplateFilter.Name = "txtTemplateFilter";
            this.txtTemplateFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.txtTemplateFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.txtTemplateFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtTemplateFilter.Properties.Appearance.Options.UseBackColor = true;
            this.txtTemplateFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.txtTemplateFilter.Properties.Appearance.Options.UseFont = true;
            this.txtTemplateFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTemplateFilter.Size = new System.Drawing.Size(150, 24);
            this.txtTemplateFilter.TabIndex = 2;
            // 
            // lblTemplateFilter
            // 
            this.lblTemplateFilter.Location = new System.Drawing.Point(8, 40);
            this.lblTemplateFilter.Name = "lblTemplateFilter";
            this.lblTemplateFilter.Size = new System.Drawing.Size(100, 24);
            this.lblTemplateFilter.TabIndex = 1;
            this.lblTemplateFilter.Text = "Vorlagen-Name:";
            this.lblTemplateFilter.UseCompatibleTextRendering = true;
            // 
            // btnRenameFromFile
            // 
            this.btnRenameFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenameFromFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRenameFromFile.Location = new System.Drawing.Point(579, 3);
            this.btnRenameFromFile.Name = "btnRenameFromFile";
            this.btnRenameFromFile.Size = new System.Drawing.Size(150, 24);
            this.btnRenameFromFile.TabIndex = 3;
            this.btnRenameFromFile.Text = "Umbenennen aus Datei";
            this.btnRenameFromFile.UseVisualStyleBackColor = false;
            this.btnRenameFromFile.Click += new System.EventHandler(this.btnRenameFromFile_Click);
            // 
            // CtlRenameBookmarks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "CtlRenameBookmarks";
            this.Size = new System.Drawing.Size(750, 500);
            this.Load += new System.EventHandler(this.CtlRenameBookmarks_Load);
            this.Leave += new System.EventHandler(this.CtlRenameBookmarks_Leave);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryXDocTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXBookmark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgressText)).EndInit();
            this.grpRenameBookmarks.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRenameTo.Properties)).EndInit();
            this.grpBookmarkFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkStrict.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkValidate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRegex.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTemplateFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTemplateFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ImageList imgList;
        private KiSS4.DB.SqlQuery qryXBookmark;
        private KiSS4.DB.SqlQuery qryXDocTemplate;
        private System.Windows.Forms.SaveFileDialog sfdOutput;
        private System.ComponentModel.BackgroundWorker bgwLoadBookmarks;
        private System.ComponentModel.BackgroundWorker bgwRenameBookmarks;
        private Gui.KissLabel lblProgressText;
        private Gui.KissGroupBox grpRenameBookmarks;
        private Gui.KissTextEdit txtRenameTo;
        private Gui.KissButton btnRename;
        private Gui.KissGroupBox grpBookmarkFilter;
        private Gui.KissTextEdit txtFilter;
        private Gui.KissCheckEdit chkStrict;
        private Gui.KissCheckEdit chkValidate;
        private Gui.KissCheckEdit chkRegex;
        private Gui.KissButton btnSaveList;
        private Gui.KissLabel lblProgress;
        private System.Windows.Forms.ProgressBar progressBar;
        private Gui.KissButton btnCancel;
        private Gui.KissLabel lblResult;
        private System.Windows.Forms.ListView lvwResult;
        private System.Windows.Forms.ColumnHeader chdBookmarkName;
        private Gui.KissTextEdit txtTemplateFilter;
        private Gui.KissLabel lblTemplateFilter;
        private Gui.KissButton btnRenameFromFile;
        private System.Windows.Forms.OpenFileDialog ofdRenameFile;
    }
}
