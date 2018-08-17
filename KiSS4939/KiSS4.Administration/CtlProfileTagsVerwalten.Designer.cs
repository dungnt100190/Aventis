namespace KiSS4.Administration
{
    partial class CtlProfileTagsVerwalten
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlProfileTagsVerwalten));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.edtProfileTagDescription = new KiSS4.Gui.KissMemoEdit();
            this.qryXProfileTag = new KiSS4.DB.SqlQuery(this.components);
            this.lblDescription = new KiSS4.Gui.KissLabel();
            this.edtProfileTagText = new KiSS4.Gui.KissTextEditML();
            this.lblProfileTagText = new KiSS4.Gui.KissLabel();
            this.lblProfileTagNameSuche = new KiSS4.Gui.KissLabel();
            this.edtMerkmalSuchen = new KiSS4.Gui.KissTextEdit();
            this.grdProfileTag = new KiSS4.Gui.KissGrid();
            this.grvProfileTag = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colXProfileTagID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMerkmal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panelDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileTagDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXProfileTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileTagText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileTagText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileTagNameSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMerkmalSuchen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProfileTag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProfileTag)).BeginInit();
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
            this.tabControlSearch.Size = new System.Drawing.Size(800, 362);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.grdProfileTag);
            this.tpgListe.Size = new System.Drawing.Size(788, 324);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.lblProfileTagNameSuche);
            this.tpgSuchen.Controls.Add(this.edtMerkmalSuchen);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 324);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtMerkmalSuchen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblProfileTagNameSuche, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            // 
            // panelDetail
            // 
            this.panelDetail.Controls.Add(this.edtProfileTagDescription);
            this.panelDetail.Controls.Add(this.lblDescription);
            this.panelDetail.Controls.Add(this.edtProfileTagText);
            this.panelDetail.Controls.Add(this.lblProfileTagText);
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDetail.Location = new System.Drawing.Point(0, 362);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(800, 138);
            this.panelDetail.TabIndex = 1;
            // 
            // edtProfileTagDescription
            // 
            this.edtProfileTagDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtProfileTagDescription.DataSource = this.qryXProfileTag;
            this.edtProfileTagDescription.Location = new System.Drawing.Point(113, 39);
            this.edtProfileTagDescription.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.edtProfileTagDescription.Name = "edtProfileTagDescription";
            this.edtProfileTagDescription.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProfileTagDescription.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProfileTagDescription.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProfileTagDescription.Properties.Appearance.Options.UseBackColor = true;
            this.edtProfileTagDescription.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProfileTagDescription.Properties.Appearance.Options.UseFont = true;
            this.edtProfileTagDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtProfileTagDescription.Size = new System.Drawing.Size(678, 90);
            this.edtProfileTagDescription.TabIndex = 3;
            // 
            // qryXProfileTag
            // 
            this.qryXProfileTag.CanDelete = true;
            this.qryXProfileTag.CanInsert = true;
            this.qryXProfileTag.CanUpdate = true;
            this.qryXProfileTag.HostControl = this;
            this.qryXProfileTag.SelectStatement = resources.GetString("qryXProfileTag.SelectStatement");
            this.qryXProfileTag.TableName = "XProfileTag";
            this.qryXProfileTag.AfterInsert += new System.EventHandler(this.qryXProfileTag_AfterInsert);
            this.qryXProfileTag.BeforePost += new System.EventHandler(this.qryXProfileTag_BeforePost);
            this.qryXProfileTag.AfterPost += new System.EventHandler(this.qryXProfileTag_AfterPost);
            this.qryXProfileTag.PositionChanged += new System.EventHandler(this.qryXProfileTag_PositionChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(9, 39);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(98, 24);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Beschreibung";
            // 
            // edtProfileTagText
            // 
            this.edtProfileTagText.DataMember = null;
            this.edtProfileTagText.DataMemberDefaultText = "";
            this.edtProfileTagText.DataMemberTID = "";
            this.edtProfileTagText.DataSource = this.qryXProfileTag;
            this.edtProfileTagText.Location = new System.Drawing.Point(113, 9);
            this.edtProfileTagText.Name = "edtProfileTagText";
            this.edtProfileTagText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProfileTagText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProfileTagText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProfileTagText.Properties.Appearance.Options.UseBackColor = true;
            this.edtProfileTagText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProfileTagText.Properties.Appearance.Options.UseFont = true;
            this.edtProfileTagText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtProfileTagText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtProfileTagText.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtProfileTagText.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtProfileTagText.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtProfileTagText.Size = new System.Drawing.Size(334, 24);
            this.edtProfileTagText.TabIndex = 1;
            // 
            // lblProfileTagText
            // 
            this.lblProfileTagText.Location = new System.Drawing.Point(9, 9);
            this.lblProfileTagText.Name = "lblProfileTagText";
            this.lblProfileTagText.Size = new System.Drawing.Size(98, 24);
            this.lblProfileTagText.TabIndex = 0;
            this.lblProfileTagText.Text = "Merkmal";
            // 
            // lblProfileTagNameSuche
            // 
            this.lblProfileTagNameSuche.Location = new System.Drawing.Point(30, 40);
            this.lblProfileTagNameSuche.Name = "lblProfileTagNameSuche";
            this.lblProfileTagNameSuche.Size = new System.Drawing.Size(71, 24);
            this.lblProfileTagNameSuche.TabIndex = 1;
            this.lblProfileTagNameSuche.Text = "Merkmal";
            // 
            // edtMerkmalSuchen
            // 
            this.edtMerkmalSuchen.Location = new System.Drawing.Point(107, 40);
            this.edtMerkmalSuchen.Name = "edtMerkmalSuchen";
            this.edtMerkmalSuchen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMerkmalSuchen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMerkmalSuchen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMerkmalSuchen.Properties.Appearance.Options.UseBackColor = true;
            this.edtMerkmalSuchen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMerkmalSuchen.Properties.Appearance.Options.UseFont = true;
            this.edtMerkmalSuchen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMerkmalSuchen.Size = new System.Drawing.Size(334, 24);
            this.edtMerkmalSuchen.TabIndex = 2;
            // 
            // grdProfileTag
            // 
            this.grdProfileTag.DataSource = this.qryXProfileTag;
            this.grdProfileTag.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdProfileTag.EmbeddedNavigator.Name = "";
            this.grdProfileTag.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdProfileTag.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdProfileTag.Location = new System.Drawing.Point(0, 0);
            this.grdProfileTag.MainView = this.grvProfileTag;
            this.grdProfileTag.Name = "grdProfileTag";
            this.grdProfileTag.Size = new System.Drawing.Size(788, 324);
            this.grdProfileTag.TabIndex = 0;
            this.grdProfileTag.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvProfileTag});
            // 
            // grvProfileTag
            // 
            this.grvProfileTag.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvProfileTag.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfileTag.Appearance.Empty.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.Empty.Options.UseFont = true;
            this.grvProfileTag.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvProfileTag.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfileTag.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.EvenRow.Options.UseFont = true;
            this.grvProfileTag.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProfileTag.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfileTag.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvProfileTag.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.FocusedCell.Options.UseFont = true;
            this.grvProfileTag.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvProfileTag.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvProfileTag.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfileTag.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvProfileTag.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.FocusedRow.Options.UseFont = true;
            this.grvProfileTag.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvProfileTag.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProfileTag.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvProfileTag.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProfileTag.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProfileTag.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.GroupRow.Options.UseFont = true;
            this.grvProfileTag.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvProfileTag.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvProfileTag.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvProfileTag.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvProfileTag.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvProfileTag.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvProfileTag.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvProfileTag.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfileTag.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvProfileTag.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvProfileTag.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvProfileTag.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvProfileTag.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvProfileTag.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfileTag.Appearance.OddRow.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.OddRow.Options.UseFont = true;
            this.grvProfileTag.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvProfileTag.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfileTag.Appearance.Row.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.Row.Options.UseFont = true;
            this.grvProfileTag.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvProfileTag.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvProfileTag.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvProfileTag.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvProfileTag.Appearance.SelectedRow.Options.UseFont = true;
            this.grvProfileTag.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvProfileTag.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvProfileTag.Appearance.VertLine.Options.UseBackColor = true;
            this.grvProfileTag.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvProfileTag.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colXProfileTagID,
            this.colMerkmal});
            this.grvProfileTag.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvProfileTag.GridControl = this.grdProfileTag;
            this.grvProfileTag.Name = "grvProfileTag";
            this.grvProfileTag.OptionsBehavior.AutoSelectAllInEditor = false;
            this.grvProfileTag.OptionsBehavior.Editable = false;
            this.grvProfileTag.OptionsCustomization.AllowFilter = false;
            this.grvProfileTag.OptionsCustomization.AllowGroup = false;
            this.grvProfileTag.OptionsFilter.AllowFilterEditor = false;
            this.grvProfileTag.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvProfileTag.OptionsMenu.EnableColumnMenu = false;
            this.grvProfileTag.OptionsNavigation.AutoFocusNewRow = true;
            this.grvProfileTag.OptionsNavigation.AutoMoveRowFocus = false;
            this.grvProfileTag.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvProfileTag.OptionsNavigation.UseTabKey = false;
            this.grvProfileTag.OptionsPrint.AutoWidth = false;
            this.grvProfileTag.OptionsPrint.UsePrintStyles = true;
            this.grvProfileTag.OptionsView.ColumnAutoWidth = false;
            this.grvProfileTag.OptionsView.ShowDetailButtons = false;
            this.grvProfileTag.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvProfileTag.OptionsView.ShowGroupPanel = false;
            this.grvProfileTag.OptionsView.ShowIndicator = false;
            // 
            // colXProfileTagID
            // 
            this.colXProfileTagID.Caption = "ID";
            this.colXProfileTagID.Name = "colXProfileTagID";
            this.colXProfileTagID.Visible = true;
            this.colXProfileTagID.VisibleIndex = 0;
            // 
            // colMerkmal
            // 
            this.colMerkmal.Caption = "Merkmal";
            this.colMerkmal.FieldName = "XProfileTagID";
            this.colMerkmal.Name = "colMerkmal";
            this.colMerkmal.Visible = true;
            this.colMerkmal.VisibleIndex = 1;
            this.colMerkmal.Width = 518;
            // 
            // CtlProfileTagsVerwalten
            // 
            this.ActiveSQLQuery = this.qryXProfileTag;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelDetail);
            this.Name = "CtlProfileTagsVerwalten";
            this.Controls.SetChildIndex(this.panelDetail, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panelDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileTagDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXProfileTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileTagText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileTagText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProfileTagNameSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMerkmalSuchen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdProfileTag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvProfileTag)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDetail;
        private Gui.KissLabel lblProfileTagNameSuche;
        private Gui.KissTextEdit edtMerkmalSuchen;
        private DB.SqlQuery qryXProfileTag;
        private Gui.KissLabel lblProfileTagText;
        private Gui.KissGrid grdProfileTag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvProfileTag;
        private DevExpress.XtraGrid.Columns.GridColumn colMerkmal;
        private Gui.KissTextEditML edtProfileTagText;
        private DevExpress.XtraGrid.Columns.GridColumn colXProfileTagID;
        private Gui.KissMemoEdit edtProfileTagDescription;
        private Gui.KissLabel lblDescription;
    }
}
