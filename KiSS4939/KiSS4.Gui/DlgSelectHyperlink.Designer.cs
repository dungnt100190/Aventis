namespace KiSS4.Gui
{
    partial class DlgSelectHyperlink
    {
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgSelectHyperlink));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryXHyperLink = new KiSS4.DB.SqlQuery(this.components);
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnCreate = new KiSS4.Gui.KissButton();
            this.treXHyperLink = new KiSS4.Gui.KissTree();
            this.colItemName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUserProfileCode = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.edtUserProfileCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblUserProfileCode = new KiSS4.Gui.KissLabel();
            this.chkFoldersExpanded = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXHyperLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treXHyperLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfileCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfileCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfileCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFoldersExpanded.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryXHyperLink
            // 
            this.qryXHyperLink.HostControl = this;
            this.qryXHyperLink.SelectStatement = resources.GetString("qryXHyperLink.SelectStatement");
            this.qryXHyperLink.TableName = "XHyperlink";
            this.qryXHyperLink.PositionChanged += new System.EventHandler(this.qryXHyperLink_PositionChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(308, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreate.Enabled = false;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(205, 393);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(95, 24);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Link öffnen";
            this.btnCreate.UseVisualStyleBackColor = false;
            // 
            // treXHyperLink
            // 
            this.treXHyperLink.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treXHyperLink.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treXHyperLink.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treXHyperLink.Appearance.Empty.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.Empty.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treXHyperLink.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXHyperLink.Appearance.EvenRow.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.EvenRow.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treXHyperLink.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treXHyperLink.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treXHyperLink.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treXHyperLink.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXHyperLink.Appearance.FooterPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXHyperLink.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.FooterPanel.Options.UseFont = true;
            this.treXHyperLink.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treXHyperLink.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treXHyperLink.Appearance.GroupButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXHyperLink.Appearance.GroupButton.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.GroupButton.Options.UseFont = true;
            this.treXHyperLink.Appearance.GroupButton.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.treXHyperLink.Appearance.GroupFooter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXHyperLink.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treXHyperLink.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treXHyperLink.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXHyperLink.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.HeaderPanel.Options.UseFont = true;
            this.treXHyperLink.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treXHyperLink.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXHyperLink.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treXHyperLink.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treXHyperLink.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treXHyperLink.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treXHyperLink.Appearance.HorzLine.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.HorzLine.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.treXHyperLink.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXHyperLink.Appearance.OddRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXHyperLink.Appearance.OddRow.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.OddRow.Options.UseFont = true;
            this.treXHyperLink.Appearance.OddRow.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.treXHyperLink.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXHyperLink.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXHyperLink.Appearance.Preview.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.Preview.Options.UseFont = true;
            this.treXHyperLink.Appearance.Preview.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treXHyperLink.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treXHyperLink.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.treXHyperLink.Appearance.Row.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.Row.Options.UseFont = true;
            this.treXHyperLink.Appearance.Row.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treXHyperLink.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treXHyperLink.Appearance.TreeLine.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treXHyperLink.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treXHyperLink.Appearance.VertLine.Options.UseBackColor = true;
            this.treXHyperLink.Appearance.VertLine.Options.UseForeColor = true;
            this.treXHyperLink.Appearance.VertLine.Options.UseTextOptions = true;
            this.treXHyperLink.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treXHyperLink.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colItemName,
            this.colUserProfileCode});
            this.treXHyperLink.DataSource = this.qryXHyperLink;
            this.treXHyperLink.ImageIndexFieldName = "IconID";
            this.treXHyperLink.KeyFieldName = "XHyperlinkContext_HyperlinkID";
            this.treXHyperLink.Location = new System.Drawing.Point(8, 40);
            this.treXHyperLink.Name = "treXHyperLink";
            this.treXHyperLink.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treXHyperLink.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treXHyperLink.OptionsBehavior.Editable = false;
            this.treXHyperLink.OptionsBehavior.KeepSelectedOnClick = false;
            this.treXHyperLink.OptionsBehavior.MoveOnEdit = false;
            this.treXHyperLink.OptionsBehavior.ShowToolTips = false;
            this.treXHyperLink.OptionsBehavior.SmartMouseHover = false;
            this.treXHyperLink.OptionsMenu.EnableColumnMenu = false;
            this.treXHyperLink.OptionsMenu.EnableFooterMenu = false;
            this.treXHyperLink.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treXHyperLink.OptionsView.AutoWidth = false;
            this.treXHyperLink.OptionsView.EnableAppearanceEvenRow = true;
            this.treXHyperLink.OptionsView.EnableAppearanceOddRow = true;
            this.treXHyperLink.OptionsView.ShowIndicator = false;
            this.treXHyperLink.OptionsView.ShowVertLines = false;
            this.treXHyperLink.SelectImageList = this.imgList;
            this.treXHyperLink.Size = new System.Drawing.Size(396, 322);
            this.treXHyperLink.Styles.AddReplace("PressedColumn", new DevExpress.Utils.ViewStyle("PressedColumn", "TreeList", new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), "HeaderPanel", ((DevExpress.Utils.StyleOptions)(((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                                | DevExpress.Utils.StyleOptions.UseForeColor))), true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))));
            this.treXHyperLink.TabIndex = 0;
            this.treXHyperLink.DoubleClick += new System.EventHandler(this.treXHyperLink_DoubleClick);
            // 
            // colItemName
            // 
            this.colItemName.Caption = "Link";
            this.colItemName.FieldName = "ItemName";
            this.colItemName.MinWidth = 27;
            this.colItemName.Name = "colItemName";
            this.colItemName.OptionsColumn.AllowEdit = false;
            this.colItemName.OptionsColumn.AllowMove = false;
            this.colItemName.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colItemName.OptionsColumn.AllowSort = false;
            this.colItemName.OptionsColumn.ReadOnly = true;
            this.colItemName.VisibleIndex = 0;
            this.colItemName.Width = 280;
            // 
            // colUserProfileCode
            // 
            this.colUserProfileCode.Caption = "Benutzerprofil";
            this.colUserProfileCode.FieldName = "UserProfileCode";
            this.colUserProfileCode.Name = "colUserProfileCode";
            this.colUserProfileCode.OptionsColumn.AllowEdit = false;
            this.colUserProfileCode.OptionsColumn.AllowMove = false;
            this.colUserProfileCode.OptionsColumn.AllowMoveToCustomizationForm = false;
            this.colUserProfileCode.OptionsColumn.AllowSort = false;
            this.colUserProfileCode.OptionsColumn.ReadOnly = true;
            this.colUserProfileCode.VisibleIndex = 1;
            this.colUserProfileCode.Width = 95;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "");
            this.imgList.Images.SetKeyName(1, "0026_TeilPhase.ICO");
            // 
            // edtUserProfileCode
            // 
            this.edtUserProfileCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUserProfileCode.Location = new System.Drawing.Point(114, 8);
            this.edtUserProfileCode.LOVName = "UserProfile";
            this.edtUserProfileCode.Name = "edtUserProfileCode";
            this.edtUserProfileCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserProfileCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserProfileCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfileCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserProfileCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserProfileCode.Properties.Appearance.Options.UseFont = true;
            this.edtUserProfileCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtUserProfileCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserProfileCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtUserProfileCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtUserProfileCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUserProfileCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUserProfileCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserProfileCode.Properties.NullText = "";
            this.edtUserProfileCode.Properties.ShowFooter = false;
            this.edtUserProfileCode.Properties.ShowHeader = false;
            this.edtUserProfileCode.Size = new System.Drawing.Size(290, 24);
            this.edtUserProfileCode.TabIndex = 3;
            this.edtUserProfileCode.EditValueChanged += new System.EventHandler(this.edtUserProfileCode_EditValueChanged);
            // 
            // lblUserProfileCode
            // 
            this.lblUserProfileCode.Location = new System.Drawing.Point(8, 8);
            this.lblUserProfileCode.Name = "lblUserProfileCode";
            this.lblUserProfileCode.Size = new System.Drawing.Size(100, 24);
            this.lblUserProfileCode.TabIndex = 14;
            this.lblUserProfileCode.Text = "Benutzerprofil";
            // 
            // chkFoldersExpanded
            // 
            this.chkFoldersExpanded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFoldersExpanded.EditValue = true;
            this.chkFoldersExpanded.Location = new System.Drawing.Point(8, 368);
            this.chkFoldersExpanded.Name = "chkFoldersExpanded";
            this.chkFoldersExpanded.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkFoldersExpanded.Properties.Appearance.Options.UseBackColor = true;
            this.chkFoldersExpanded.Properties.Caption = "alle Ordner geöffnet";
            this.chkFoldersExpanded.Size = new System.Drawing.Size(284, 19);
            this.chkFoldersExpanded.TabIndex = 16;
            this.chkFoldersExpanded.CheckedChanged += new System.EventHandler(this.chkFoldersExpanded_CheckedChanged);
            // 
            // DlgSelectHyperlink
            // 
            this.AcceptButton = this.btnCreate;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(412, 426);
            this.Controls.Add(this.chkFoldersExpanded);
            this.Controls.Add(this.lblUserProfileCode);
            this.Controls.Add(this.edtUserProfileCode);
            this.Controls.Add(this.treXHyperLink);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgSelectHyperlink";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Link wählen";
            ((System.ComponentModel.ISupportInitialize)(this.qryXHyperLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treXHyperLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfileCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserProfileCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserProfileCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkFoldersExpanded.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private KiSS4.DB.SqlQuery qryXHyperLink;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnCreate;
        private KiSS4.Gui.KissTree treXHyperLink;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colItemName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUserProfileCode;
        private System.Windows.Forms.ImageList imgList;
        private KiSS4.Gui.KissLookUpEdit edtUserProfileCode;
        private KiSS4.Gui.KissLabel lblUserProfileCode;
        private KiSS4.Gui.KissCheckEdit chkFoldersExpanded;
    }
}
