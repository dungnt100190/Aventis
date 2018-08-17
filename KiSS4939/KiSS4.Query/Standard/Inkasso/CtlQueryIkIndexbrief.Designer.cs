namespace KiSS4.Query
{
    public partial class CtlQueryIkIndexbrief
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryIkIndexbrief));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnCreate = new KiSS4.Gui.KissButton();
            this.btnUndo = new KiSS4.Gui.KissButton();
            this.lblCount = new KiSS4.Gui.KissLabel();
            this.edtSachbearbeiter = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtUser = new KiSS4.Gui.KissButtonEdit();
            this.edtIndexart = new KiSS4.Gui.KissLookUpEdit();
            this.edtDatumPer = new KiSS4.Gui.KissDateEdit();
            this.edtchkDelete = new KiSS4.Gui.KissCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSachbearbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumPer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtchkDelete.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.AfterFill += new System.EventHandler(this.qryQuery_AfterFill);
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
            this.grvQuery1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.ctlGotoFall.DataMember = "Falltraeger_PersonenNummer";
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.lblCount);
            this.tpgListe.Controls.Add(this.btnUndo);
            this.tpgListe.Controls.Add(this.btnCreate);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblSuchkriterienInfo, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnCreate, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnUndo, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblCount, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtchkDelete);
            this.tpgSuchen.Controls.Add(this.edtDatumPer);
            this.tpgSuchen.Controls.Add(this.edtIndexart);
            this.tpgSuchen.Controls.Add(this.edtUser);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtSachbearbeiter);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSachbearbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtIndexart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumPer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtchkDelete, 0);
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(319, 398);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(190, 24);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Neue Forderungen erstellen";
            this.btnCreate.UseCompatibleTextRendering = true;
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUndo.Location = new System.Drawing.Point(515, 398);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(90, 24);
            this.btnUndo.TabIndex = 4;
            this.btnUndo.Text = "Alle löschen";
            this.btnUndo.UseCompatibleTextRendering = true;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Visible = false;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // lblCount
            // 
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCount.Location = new System.Drawing.Point(611, 398);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(158, 24);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "kissLabel4";
            this.lblCount.UseCompatibleTextRendering = true;
            // 
            // edtSachbearbeiter
            // 
            this.edtSachbearbeiter.Location = new System.Drawing.Point(30, 40);
            this.edtSachbearbeiter.Name = "edtSachbearbeiter";
            this.edtSachbearbeiter.Size = new System.Drawing.Size(130, 24);
            this.edtSachbearbeiter.TabIndex = 1;
            this.edtSachbearbeiter.Text = "Sachbearbeiter/in";
            this.edtSachbearbeiter.UseCompatibleTextRendering = true;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(30, 70);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(130, 24);
            this.kissLabel1.TabIndex = 3;
            this.kissLabel1.Text = "Indexart";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(30, 101);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(130, 24);
            this.kissLabel3.TabIndex = 5;
            this.kissLabel3.Text = "Neue Forderung per";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // edtUser
            // 
            this.edtUser.Location = new System.Drawing.Point(166, 40);
            this.edtUser.Name = "edtUser";
            this.edtUser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.Properties.Appearance.Options.UseBackColor = true;
            this.edtUser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUser.Properties.Appearance.Options.UseFont = true;
            this.edtUser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtUser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtUser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUser.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUser.Size = new System.Drawing.Size(559, 24);
            this.edtUser.TabIndex = 2;
            this.edtUser.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUser_UserModifiedFld);
            // 
            // edtIndexart
            // 
            this.edtIndexart.Location = new System.Drawing.Point(166, 70);
            this.edtIndexart.LOVFilter = "code in (1,2,4,5,6,7)";
            this.edtIndexart.LOVFilterWhereAppend = true;
            this.edtIndexart.LOVName = "IkAnpassungsRegel";
            this.edtIndexart.Name = "edtIndexart";
            this.edtIndexart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIndexart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIndexart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexart.Properties.Appearance.Options.UseBackColor = true;
            this.edtIndexart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIndexart.Properties.Appearance.Options.UseFont = true;
            this.edtIndexart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIndexart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIndexart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIndexart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIndexart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtIndexart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtIndexart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIndexart.Properties.NullText = "";
            this.edtIndexart.Properties.ShowFooter = false;
            this.edtIndexart.Properties.ShowHeader = false;
            this.edtIndexart.Size = new System.Drawing.Size(559, 24);
            this.edtIndexart.TabIndex = 4;
            // 
            // edtDatumPer
            // 
            this.edtDatumPer.EditValue = null;
            this.edtDatumPer.Location = new System.Drawing.Point(166, 100);
            this.edtDatumPer.Name = "edtDatumPer";
            this.edtDatumPer.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumPer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumPer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumPer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumPer.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumPer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumPer.Properties.Appearance.Options.UseFont = true;
            this.edtDatumPer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumPer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumPer.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumPer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumPer.Properties.ShowToday = false;
            this.edtDatumPer.Size = new System.Drawing.Size(100, 24);
            this.edtDatumPer.TabIndex = 6;
            // 
            // edtchkDelete
            // 
            this.edtchkDelete.EditValue = false;
            this.edtchkDelete.Location = new System.Drawing.Point(166, 139);
            this.edtchkDelete.Name = "edtchkDelete";
            this.edtchkDelete.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtchkDelete.Properties.Appearance.Options.UseBackColor = true;
            this.edtchkDelete.Properties.Caption = "Forderungen löschen";
            this.edtchkDelete.Size = new System.Drawing.Size(228, 19);
            this.edtchkDelete.TabIndex = 7;
            // 
            // CtlQueryIkIndexbrief
            // 
            this.Name = "CtlQueryIkIndexbrief";
            this.Load += new System.EventHandler(this.CtlQueryIkIndexbrief_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSachbearbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIndexart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumPer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtchkDelete.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KiSS4.Gui.KissButton btnCreate;
        private KiSS4.Gui.KissButton btnUndo;
        private KiSS4.Gui.KissDateEdit edtDatumPer;
        private KiSS4.Gui.KissLookUpEdit edtIndexart;
        private KiSS4.Gui.KissLabel edtSachbearbeiter;
        private KiSS4.Gui.KissButtonEdit edtUser;
        private KiSS4.Gui.KissCheckEdit edtchkDelete;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel lblCount;
    }
}