using KiSS4.DB;

namespace KiSS4.Query
{
    public class CtlQueryFaFallnavigator : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colA;
        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colB;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colF;
        private DevExpress.XtraGrid.Columns.GridColumn colGemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn colI;
        private DevExpress.XtraGrid.Columns.GridColumn colIconID;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNavigatorZusatz;
        private DevExpress.XtraGrid.Columns.GridColumn colNNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrgUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn colParentID;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonCount;
        private DevExpress.XtraGrid.Columns.GridColumn colS;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colUserID;
        private DevExpress.XtraGrid.Columns.GridColumn colV;
        private DevExpress.XtraGrid.Columns.GridColumn colZusatz;
        private KiSS4.Gui.KissCheckEdit edtActive;
        private KiSS4.Gui.KissCheckEdit edtArchived;
        private KiSS4.Gui.KissCheckEdit edtClosed;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblSAR;

        #endregion

        #region Constructors

        public CtlQueryFaFallnavigator()
        {
            this.InitializeComponent();

            edtActive.Checked = true;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryFaFallnavigator));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtActive = new KiSS4.Gui.KissCheckEdit();
            this.edtClosed = new KiSS4.Gui.KissCheckEdit();
            this.edtArchived = new KiSS4.Gui.KissCheckEdit();
            this.colA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colB = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIconID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNavigatorZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrgUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonCount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colV = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZusatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClosed.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArchived.Properties)).BeginInit();
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
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 397);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtArchived);
            this.tpgSuchen.Controls.Add(this.edtClosed);
            this.tpgSuchen.Controls.Add(this.edtActive);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtActive, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtClosed, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtArchived, 0);
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(10, 40);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 1;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(130, 40);
            this.edtUserID.LookupSQL = "select ID = UserID, \r\nSAR = LastName + isNull(\', \' + FirstName,\'\'), \r\n[Kuerzel] =" +
    " LogonName\r\nfrom   XUser \r\nwhere LastName + isNull(\', \' + FirstName,\'\') like isN" +
    "ull({0},\'\') + \'%\' \r\norder by SAR";
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(200, 24);
            this.edtUserID.TabIndex = 20;
            // 
            // edtActive
            // 
            this.edtActive.EditValue = false;
            this.edtActive.Location = new System.Drawing.Point(130, 80);
            this.edtActive.Name = "edtActive";
            this.edtActive.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtActive.Properties.Appearance.Options.UseBackColor = true;
            this.edtActive.Properties.Caption = "aktiv";
            this.edtActive.Size = new System.Drawing.Size(200, 19);
            this.edtActive.TabIndex = 21;
            // 
            // edtClosed
            // 
            this.edtClosed.EditValue = false;
            this.edtClosed.Location = new System.Drawing.Point(130, 110);
            this.edtClosed.Name = "edtClosed";
            this.edtClosed.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtClosed.Properties.Appearance.Options.UseBackColor = true;
            this.edtClosed.Properties.Caption = "abgeschlossen";
            this.edtClosed.Size = new System.Drawing.Size(200, 19);
            this.edtClosed.TabIndex = 22;
            // 
            // edtArchived
            // 
            this.edtArchived.EditValue = false;
            this.edtArchived.Location = new System.Drawing.Point(130, 140);
            this.edtArchived.Name = "edtArchived";
            this.edtArchived.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtArchived.Properties.Appearance.Options.UseBackColor = true;
            this.edtArchived.Properties.Caption = "archiviert";
            this.edtArchived.Size = new System.Drawing.Size(200, 19);
            this.edtArchived.TabIndex = 23;
            // 
            // colA
            // 
            this.colA.Name = "colA";
            // 
            // colAHVNummer
            // 
            this.colAHVNummer.Name = "colAHVNummer";
            // 
            // colB
            // 
            this.colB.Name = "colB";
            // 
            // colBaPersonID
            // 
            this.colBaPersonID.Name = "colBaPersonID";
            // 
            // colF
            // 
            this.colF.Name = "colF";
            // 
            // colGemeinde
            // 
            this.colGemeinde.Name = "colGemeinde";
            // 
            // colI
            // 
            this.colI.Name = "colI";
            // 
            // colIconID
            // 
            this.colIconID.Name = "colIconID";
            // 
            // colID
            // 
            this.colID.Name = "colID";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colNavigatorZusatz
            // 
            this.colNavigatorZusatz.Name = "colNavigatorZusatz";
            // 
            // colNNummer
            // 
            this.colNNummer.Name = "colNNummer";
            // 
            // colOrgUnitID
            // 
            this.colOrgUnitID.Name = "colOrgUnitID";
            // 
            // colParentID
            // 
            this.colParentID.Name = "colParentID";
            // 
            // colPersonCount
            // 
            this.colPersonCount.Name = "colPersonCount";
            // 
            // colS
            // 
            this.colS.Name = "colS";
            // 
            // colType
            // 
            this.colType.Name = "colType";
            // 
            // colUserID
            // 
            this.colUserID.Name = "colUserID";
            // 
            // colV
            // 
            this.colV.Name = "colV";
            // 
            // colZusatz
            // 
            this.colZusatz.Name = "colZusatz";
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
            // CtlQueryFaFallnavigator
            // 
            this.Name = "CtlQueryFaFallnavigator";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClosed.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArchived.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtActive.Checked = true;
        }

        protected override void RunSearch()
        {
            // replace search parameters
            object[] parameters = new object[] { Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;
            // let base do stuff
            base.RunSearch();
        }

        #endregion
    }
}