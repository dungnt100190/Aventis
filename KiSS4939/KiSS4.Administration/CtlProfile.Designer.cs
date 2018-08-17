namespace KiSS4.Administration
{
    partial class CtlProfile
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlProfile));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdProfile = new KiSS4.Gui.KissGrid();
            this.qryXProfile = new KiSS4.DB.SqlQuery(this.components);
            this.grvProfile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTags = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblNameSuche = new KiSS4.Gui.KissLabel();
            this.edtProfileNameSuche = new KiSS4.Gui.KissTextEdit();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.edtProfileTags = new KiSS4.Common.CtlProfileTagsControl();
            this.edtDescription = new KiSS4.Gui.KissMemoEdit();
            this.lblProfileDescription = new KiSS4.Gui.KissLabel();
            this.edtProfileText = new KiSS4.Gui.KissTextEditML();
            this.lblProfileTags = new KiSS4.Gui.KissLabel();
            this.lblProfileName = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileNameSuche.Properties)).BeginInit();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileTags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileName)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(800, 243);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdProfile);
            this.tpgListe.Size = new System.Drawing.Size(788, 205);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblNameSuche);
            this.tpgSuchen.Controls.Add(this.edtProfileNameSuche);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 205);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtProfileNameSuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameSuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // grdProfile
            // 
            this.grdProfile.DataSource = this.qryXProfile;
            this.grdProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdProfile.EmbeddedNavigator.Name = "";
            this.grdProfile.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdProfile.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdProfile.Location = new System.Drawing.Point(0, 0);
            this.grdProfile.MainView = this.grvProfile;
            this.grdProfile.Name = "grdProfile";
            this.grdProfile.Size = new System.Drawing.Size(788, 205);
            this.grdProfile.TabIndex = 0;
            this.grdProfile.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProfile});
            // 
            // qryXProfile
            // 
            this.qryXProfile.CanDelete = true;
            this.qryXProfile.CanInsert = true;
            this.qryXProfile.CanUpdate = true;
            this.qryXProfile.HostControl = this;
            this.qryXProfile.SelectStatement = resources.GetString("qryXProfile.SelectStatement");
            this.qryXProfile.TableName = "XProfile";
            this.qryXProfile.AfterInsert += new System.EventHandler(this.qryXProfile_AfterInsert);
            this.qryXProfile.BeforePost += new System.EventHandler(this.qryXProfile_BeforePost);
            this.qryXProfile.AfterPost += new System.EventHandler(this.qryXProfile_AfterPost);
            this.qryXProfile.BeforeDelete += new System.EventHandler(this.qryXProfile_BeforeDelete);
            this.qryXProfile.AfterDelete += new System.EventHandler(this.qryXProfile_AfterDelete);
            this.qryXProfile.PositionChanged += new System.EventHandler(this.qryXProfile_PositionChanged);
            // 
            // grvProfile
            // 
            this.grvProfile.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvProfile.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfile.Appearance.Empty.Options.UseBackColor = true;
            this.grvProfile.Appearance.Empty.Options.UseFont = true;
            this.grvProfile.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvProfile.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfile.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvProfile.Appearance.EvenRow.Options.UseFont = true;
            this.grvProfile.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProfile.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfile.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvProfile.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvProfile.Appearance.FocusedCell.Options.UseFont = true;
            this.grvProfile.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvProfile.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProfile.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfile.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvProfile.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvProfile.Appearance.FocusedRow.Options.UseFont = true;
            this.grvProfile.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvProfile.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProfile.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvProfile.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProfile.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProfile.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProfile.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvProfile.Appearance.GroupRow.Options.UseFont = true;
            this.grvProfile.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvProfile.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvProfile.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvProfile.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProfile.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvProfile.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvProfile.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProfile.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvProfile.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfile.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProfile.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvProfile.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvProfile.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvProfile.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvProfile.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvProfile.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvProfile.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfile.Appearance.OddRow.Options.UseBackColor = true;
            this.grvProfile.Appearance.OddRow.Options.UseFont = true;
            this.grvProfile.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvProfile.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfile.Appearance.Row.Options.UseBackColor = true;
            this.grvProfile.Appearance.Row.Options.UseFont = true;
            this.grvProfile.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvProfile.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfile.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvProfile.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvProfile.Appearance.SelectedRow.Options.UseFont = true;
            this.grvProfile.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvProfile.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvProfile.Appearance.VertLine.Options.UseBackColor = true;
            this.grvProfile.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvProfile.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colName,
            this.colTags});
            this.grvProfile.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvProfile.GridControl = this.grdProfile;
            this.grvProfile.Name = "grvProfile";
            this.grvProfile.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvProfile.OptionsBehavior.Editable = false;
            this.grvProfile.OptionsCustomization.AllowFilter = false;
            this.grvProfile.OptionsCustomization.AllowGroup = false;
            this.grvProfile.OptionsFilter.AllowFilterEditor = false;
            this.grvProfile.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvProfile.OptionsMenu.EnableColumnMenu = false;
            this.grvProfile.OptionsNavigation.AutoFocusNewRow = true;
            this.grvProfile.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvProfile.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvProfile.OptionsNavigation.UseTabKey = false;
            this.grvProfile.OptionsPrint.AutoWidth = false;
            this.grvProfile.OptionsPrint.UsePrintStyles = true;
            this.grvProfile.OptionsView.ColumnAutoWidth = false;
            this.grvProfile.OptionsView.ShowDetailButtons = false;
            this.grvProfile.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvProfile.OptionsView.ShowGroupPanel = false;
            this.grvProfile.OptionsView.ShowIndicator = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Profilname";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 400;
            // 
            // colTags
            // 
            this.colTags.Caption = "Merkmale";
            this.colTags.Name = "colTags";
            this.colTags.Visible = true;
            this.colTags.VisibleIndex = 2;
            this.colTags.Width = 250;
            // 
            // lblNameSuche
            // 
            this.lblNameSuche.Location = new System.Drawing.Point(30, 40);
            this.lblNameSuche.Name = "lblNameSuche";
            this.lblNameSuche.Size = new System.Drawing.Size(90, 24);
            this.lblNameSuche.TabIndex = 1;
            this.lblNameSuche.Text = "Profilename";
            // 
            // edtProfileNameSuche
            // 
            this.edtProfileNameSuche.Location = new System.Drawing.Point(126, 40);
            this.edtProfileNameSuche.Name = "edtProfileNameSuche";
            this.edtProfileNameSuche.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProfileNameSuche.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProfileNameSuche.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProfileNameSuche.Properties.Appearance.Options.UseBackColor = true;
            this.edtProfileNameSuche.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProfileNameSuche.Properties.Appearance.Options.UseFont = true;
            this.edtProfileNameSuche.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtProfileNameSuche.Size = new System.Drawing.Size(326, 24);
            this.edtProfileNameSuche.TabIndex = 2;
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.edtProfileTags);
            this.panelDetail.Controls.Add(this.edtDescription);
            this.panelDetail.Controls.Add(this.lblProfileDescription);
            this.panelDetail.Controls.Add(this.edtProfileText);
            this.panelDetail.Controls.Add(this.lblProfileTags);
            this.panelDetail.Controls.Add(this.lblProfileName);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDetail.Location = new System.Drawing.Point(0, 243);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(800, 257);
            this.panelDetail.TabIndex = 1;
            // 
            // edtProfileTags
            // 
            this.edtProfileTags.ActiveSQLQuery = this.qryXProfile;
            this.edtProfileTags.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtProfileTags.DisplayMember = null;
            this.edtProfileTags.IsOnCtlProfile = true;
            this.edtProfileTags.Location = new System.Drawing.Point(115, 39);
            this.edtProfileTags.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtProfileTags.Name = "edtProfileTags";
            this.edtProfileTags.Padding = new System.Windows.Forms.Padding(1);
            this.edtProfileTags.Size = new System.Drawing.Size(675, 111);
            this.edtProfileTags.TabIndex = 3;
            // 
            // edtDescription
            // 
            this.edtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtDescription.Location = new System.Drawing.Point(115, 156);
            this.edtDescription.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtDescription.Name = "edtDescription";
            this.edtDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDescription.Properties.Appearance.Options.UseFont = true;
            this.edtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDescription.Size = new System.Drawing.Size(675, 92);
            this.edtDescription.TabIndex = 5;
            // 
            // lblProfileDescription
            // 
            this.lblProfileDescription.Location = new System.Drawing.Point(9, 156);
            this.lblProfileDescription.Name = "lblProfileDescription";
            this.lblProfileDescription.Size = new System.Drawing.Size(100, 23);
            this.lblProfileDescription.TabIndex = 4;
            this.lblProfileDescription.Text = "Beschreibung";
            // 
            // edtProfileText
            // 
            this.edtProfileText.ApplyChangesToDefaultText = false;
            this.edtProfileText.DataMember = null;
            this.edtProfileText.DataMemberDefaultText = "";
            this.edtProfileText.DataMemberTID = "TextID";
            this.edtProfileText.DataSource = this.qryXProfile;
            this.edtProfileText.Location = new System.Drawing.Point(115, 9);
            this.edtProfileText.Name = "edtProfileText";
            this.edtProfileText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProfileText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProfileText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProfileText.Properties.Appearance.Options.UseBackColor = true;
            this.edtProfileText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProfileText.Properties.Appearance.Options.UseFont = true;
            this.edtProfileText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtProfileText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtProfileText.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtProfileText.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtProfileText.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtProfileText.Size = new System.Drawing.Size(343, 24);
            this.edtProfileText.TabIndex = 1;
            // 
            // lblProfileTags
            // 
            this.lblProfileTags.Location = new System.Drawing.Point(9, 39);
            this.lblProfileTags.Name = "lblProfileTags";
            this.lblProfileTags.Size = new System.Drawing.Size(100, 23);
            this.lblProfileTags.TabIndex = 2;
            this.lblProfileTags.Text = "Merkmale";
            // 
            // lblProfileName
            // 
            this.lblProfileName.Location = new System.Drawing.Point(9, 9);
            this.lblProfileName.Name = "lblProfileName";
            this.lblProfileName.Size = new System.Drawing.Size(100, 23);
            this.lblProfileName.TabIndex = 0;
            this.lblProfileName.Text = "Profilname";
            // 
            // CtlProfile
            // 
            this.ActiveSQLQuery = this.qryXProfile;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.panelDetail);
            this.Name = "CtlProfile";
            this.Controls.SetChildIndex(this.panelDetail, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileNameSuche.Properties)).EndInit();
            this.panelDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileTags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileName)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissGrid grdProfile;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProfile;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DB.SqlQuery qryXProfile;
        private Gui.KissLabel lblNameSuche;
        private Gui.KissTextEdit edtProfileNameSuche;
        private System.Windows.Forms.Panel panelDetail;
        private Gui.KissLabel lblProfileName;
        private Gui.KissLabel lblProfileTags;
        private Common.CtlProfileTagsControl edtProfileTags;
        private Gui.KissTextEditML edtProfileText;
        private Gui.KissMemoEdit edtDescription;
        private Gui.KissLabel lblProfileDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colTags;


    }
}
