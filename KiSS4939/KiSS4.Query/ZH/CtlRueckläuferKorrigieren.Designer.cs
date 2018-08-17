namespace KiSS4.Query.ZH
{
    public partial class CtlRueckläuferKorrigieren
    {
        private KiSS4.Gui.KissButton btnJumpZahlungsweg;
        private KiSS4.Gui.KissButton btnKorrigiert;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetID;
        private DevExpress.XtraGrid.Columns.GridColumn colFallID;
        private DevExpress.XtraGrid.Columns.GridColumn colRuecklaeuferDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.ZH.CtlOrgUnitTeamUser ctlOrgUnitTeamUser;
        private KiSS4.Common.KissReferenzNrEdit edtESR;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtZahlungsweg;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.DB.SqlQuery qryZahlungsweg;
        private DevExpress.XtraGrid.Columns.GridColumn colDone;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private KiSS4.Gui.KissCheckEdit edtErledigteAnzeigen;
        private DevExpress.XtraGrid.Columns.GridColumn colRuecklaeuferBemerkung;
        private KiSS4.Gui.KissMemoEdit edtZusatzinfo;
        private KiSS4.Gui.KissButtonEdit edtKreditor;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlRueckläuferKorrigieren));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnKorrigiert = new KiSS4.Gui.KissButton();
            this.btnJumpZahlungsweg = new KiSS4.Gui.KissButton();
            this.edtZahlungsweg = new KiSS4.Gui.KissLookUpEdit();
            this.qryZahlungsweg = new KiSS4.DB.SqlQuery(this.components);
            this.edtESR = new KiSS4.Common.KissReferenzNrEdit(this.components);
            this.ctlOrgUnitTeamUser = new KiSS4.Common.ZH.CtlOrgUnitTeamUser();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBudgetID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFallID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRuecklaeuferDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colRuecklaeuferBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtErledigteAnzeigen = new KiSS4.Gui.KissCheckEdit();
            this.edtZusatzinfo = new KiSS4.Gui.KissMemoEdit();
            this.edtKreditor = new KiSS4.Gui.KissButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsweg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtESR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErledigteAnzeigen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzinfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.CanUpdate = true;
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            this.qryQuery.TableName = "KbBuchung";
            this.qryQuery.BeforePost += new System.EventHandler(this.qryQuery_BeforePost);
            this.qryQuery.PositionChanged += new System.EventHandler(this.qryQuery_PositionChanged);
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
            this.grdQuery1.GridStyle = KiSS4.Gui.GridStyleType.Default;
            this.grdQuery1.Location = new System.Drawing.Point(3, 3);
            this.grdQuery1.MainView = this.gridView2;
            this.grdQuery1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemCheckEdit1});
            this.grdQuery1.Size = new System.Drawing.Size(766, 299);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(649, 512);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "Falltraeger";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 397);
            this.ctlGotoFall.Size = new System.Drawing.Size(157, 27);
            // 
            // searchTitle
            // 
            this.searchTitle.Location = new System.Drawing.Point(8, 28);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Location = new System.Drawing.Point(9, 34);
            this.tabControlSearch.Size = new System.Drawing.Size(784, 464);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.edtZusatzinfo);
            this.tpgListe.Controls.Add(this.edtKreditor);
            this.tpgListe.Controls.Add(this.edtESR);
            this.tpgListe.Controls.Add(this.edtZahlungsweg);
            this.tpgListe.Controls.Add(this.btnJumpZahlungsweg);
            this.tpgListe.Controls.Add(this.btnKorrigiert);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(772, 426);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnKorrigiert, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnJumpZahlungsweg, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.edtZahlungsweg, 0);
            this.tpgListe.Controls.SetChildIndex(this.edtESR, 0);
            this.tpgListe.Controls.SetChildIndex(this.edtKreditor, 0);
            this.tpgListe.Controls.SetChildIndex(this.edtZusatzinfo, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tpgSuchen.Controls.Add(this.edtErledigteAnzeigen);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.ctlOrgUnitTeamUser);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(772, 426);
            this.tpgSuchen.TabIndex = 1;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.ctlOrgUnitTeamUser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtErledigteAnzeigen, 0);
            // 
            // btnKorrigiert
            // 
            this.btnKorrigiert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKorrigiert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKorrigiert.Location = new System.Drawing.Point(222, 397);
            this.btnKorrigiert.Name = "btnKorrigiert";
            this.btnKorrigiert.Size = new System.Drawing.Size(100, 24);
            this.btnKorrigiert.TabIndex = 1;
            this.btnKorrigiert.Text = "Status ändern";
            this.btnKorrigiert.UseCompatibleTextRendering = true;
            this.btnKorrigiert.UseVisualStyleBackColor = false;
            this.btnKorrigiert.Click += new System.EventHandler(this.btnKorrigiert_Click);
            // 
            // btnJumpZahlungsweg
            // 
            this.btnJumpZahlungsweg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnJumpZahlungsweg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnJumpZahlungsweg.Location = new System.Drawing.Point(116, 397);
            this.btnJumpZahlungsweg.Name = "btnJumpZahlungsweg";
            this.btnJumpZahlungsweg.Size = new System.Drawing.Size(100, 24);
            this.btnJumpZahlungsweg.TabIndex = 2;
            this.btnJumpZahlungsweg.Text = "> Zahlungsinfo";
            this.btnJumpZahlungsweg.UseCompatibleTextRendering = true;
            this.btnJumpZahlungsweg.UseVisualStyleBackColor = false;
            this.btnJumpZahlungsweg.Click += new System.EventHandler(this.btnJumpZahlungsweg_Click);
            // 
            // edtZahlungsweg
            // 
            this.edtZahlungsweg.AllowNull = false;
            this.edtZahlungsweg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZahlungsweg.DataMember = "BaZahlungswegID";
            this.edtZahlungsweg.DataSource = this.qryQuery;
            this.edtZahlungsweg.Location = new System.Drawing.Point(3, 336);
            this.edtZahlungsweg.Name = "edtZahlungsweg";
            this.edtZahlungsweg.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZahlungsweg.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZahlungsweg.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsweg.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsweg.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZahlungsweg.Properties.Appearance.Options.UseFont = true;
            this.edtZahlungsweg.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtZahlungsweg.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtZahlungsweg.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtZahlungsweg.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtZahlungsweg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtZahlungsweg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtZahlungsweg.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZahlungsweg.Properties.DisplayMember = "Text";
            this.edtZahlungsweg.Properties.NullText = "";
            this.edtZahlungsweg.Properties.ShowFooter = false;
            this.edtZahlungsweg.Properties.ShowHeader = false;
            this.edtZahlungsweg.Properties.ValueMember = "Code";
            this.edtZahlungsweg.Size = new System.Drawing.Size(319, 24);
            this.edtZahlungsweg.TabIndex = 416;
            this.edtZahlungsweg.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZahlungsweg_UserModifiedFld);
            this.edtZahlungsweg.EditValueChanged += new System.EventHandler(this.edtZahlungsweg_EditValueChanged);
            // 
            // qryZahlungsweg
            // 
            this.qryZahlungsweg.DeleteQuestion = "";
            this.qryZahlungsweg.SelectStatement = resources.GetString("qryZahlungsweg.SelectStatement");
            this.qryZahlungsweg.TableName = "vwKreditor";
            // 
            // edtESR
            // 
            this.edtESR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtESR.DataMember = "Referenznummer";
            this.edtESR.DataSource = this.qryQuery;
            this.edtESR.Location = new System.Drawing.Point(3, 366);
            this.edtESR.Name = "edtESR";
            this.edtESR.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtESR.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtESR.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtESR.Properties.Appearance.Options.UseBackColor = true;
            this.edtESR.Properties.Appearance.Options.UseBorderColor = true;
            this.edtESR.Properties.Appearance.Options.UseFont = true;
            this.edtESR.Properties.Appearance.Options.UseTextOptions = true;
            this.edtESR.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtESR.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtESR.Size = new System.Drawing.Size(319, 24);
            this.edtESR.TabIndex = 418;
            // 
            // ctlOrgUnitTeamUser
            // 
            this.ctlOrgUnitTeamUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlOrgUnitTeamUser.LableWidth = 113;
            this.ctlOrgUnitTeamUser.Location = new System.Drawing.Point(20, 123);
            this.ctlOrgUnitTeamUser.Name = "ctlOrgUnitTeamUser";
            this.ctlOrgUnitTeamUser.SetUserOnNewSearch = false;
            this.ctlOrgUnitTeamUser.ShowUser = true;
            this.ctlOrgUnitTeamUser.Size = new System.Drawing.Size(373, 84);
            this.ctlOrgUnitTeamUser.TabIndex = 6;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(133, 93);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 7;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(20, 94);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(100, 23);
            this.kissLabel1.TabIndex = 8;
            this.kissLabel1.Text = "Datum Von";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colBelegNr
            // 
            this.colBelegNr.Caption = "BelegNr";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.OptionsColumn.AllowEdit = false;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 0;
            this.colBelegNr.Width = 99;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.GroupFormat.FormatString = "n2";
            this.colBetrag.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 1;
            this.colBetrag.Width = 91;
            // 
            // colBudgetID
            // 
            this.colBudgetID.Caption = "BudgetID";
            this.colBudgetID.FieldName = "BgBudgetID";
            this.colBudgetID.Name = "colBudgetID";
            this.colBudgetID.OptionsColumn.AllowEdit = false;
            this.colBudgetID.Visible = true;
            this.colBudgetID.VisibleIndex = 3;
            this.colBudgetID.Width = 81;
            // 
            // colFallID
            // 
            this.colFallID.Caption = "FallID";
            this.colFallID.FieldName = "FaFallID";
            this.colFallID.Name = "colFallID";
            this.colFallID.OptionsColumn.AllowEdit = false;
            this.colFallID.Visible = true;
            this.colFallID.VisibleIndex = 4;
            // 
            // colRuecklaeuferDatum
            // 
            this.colRuecklaeuferDatum.Caption = "Rückläufer";
            this.colRuecklaeuferDatum.FieldName = "BelegDatum";
            this.colRuecklaeuferDatum.Name = "colRuecklaeuferDatum";
            this.colRuecklaeuferDatum.OptionsColumn.AllowEdit = false;
            this.colRuecklaeuferDatum.Visible = true;
            this.colRuecklaeuferDatum.VisibleIndex = 6;
            this.colRuecklaeuferDatum.Width = 79;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "KbBuchungStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            this.colStatus.Width = 59;
            // 
            // colText
            // 
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.OptionsColumn.AllowEdit = false;
            this.colText.Visible = true;
            this.colText.VisibleIndex = 2;
            this.colText.Width = 273;
            // 
            // gridView2
            // 
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView2.Appearance.EvenRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView2.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView2.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView2.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView2.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView2.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView2.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView2.Appearance.GroupRow.Options.UseFont = true;
            this.gridView2.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView2.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView2.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView2.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView2.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView2.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView2.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView2.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView2.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.OddRow.Options.UseFont = true;
            this.gridView2.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView2.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Row.Options.UseBackColor = true;
            this.gridView2.Appearance.Row.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gridView2.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBelegNr,
            this.colBetrag,
            this.colText,
            this.colBudgetID,
            this.colFallID,
            this.colStatus,
            this.colRuecklaeuferDatum,
            this.colDone,
            this.colRuecklaeuferBemerkung});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.grdQuery1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            // 
            // colDone
            // 
            this.colDone.Caption = "erl";
            this.colDone.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colDone.FieldName = "RuecklaeuferErledigt";
            this.colDone.Name = "colDone";
            this.colDone.ToolTip = "erledigt";
            this.colDone.Visible = true;
            this.colDone.VisibleIndex = 7;
            this.colDone.Width = 35;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // colRuecklaeuferBemerkung
            // 
            this.colRuecklaeuferBemerkung.Caption = "Bemerkung";
            this.colRuecklaeuferBemerkung.FieldName = "RuecklaeuferBemerkung";
            this.colRuecklaeuferBemerkung.Name = "colRuecklaeuferBemerkung";
            this.colRuecklaeuferBemerkung.Visible = true;
            this.colRuecklaeuferBemerkung.VisibleIndex = 8;
            this.colRuecklaeuferBemerkung.Width = 200;
            // 
            // edtErledigteAnzeigen
            // 
            this.edtErledigteAnzeigen.EditValue = false;
            this.edtErledigteAnzeigen.Location = new System.Drawing.Point(133, 225);
            this.edtErledigteAnzeigen.Name = "edtErledigteAnzeigen";
            this.edtErledigteAnzeigen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErledigteAnzeigen.Properties.Appearance.Options.UseBackColor = true;
            this.edtErledigteAnzeigen.Properties.Caption = "Auch erledigte anzeigen";
            this.edtErledigteAnzeigen.Size = new System.Drawing.Size(145, 19);
            this.edtErledigteAnzeigen.TabIndex = 9;
            // 
            // edtZusatzinfo
            // 
            this.edtZusatzinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZusatzinfo.DataMember = "ZusatzInfo";
            this.edtZusatzinfo.DataSource = this.qryZahlungsweg;
            this.edtZusatzinfo.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZusatzinfo.Location = new System.Drawing.Point(328, 306);
            this.edtZusatzinfo.Name = "edtZusatzinfo";
            this.edtZusatzinfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtZusatzinfo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatzinfo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatzinfo.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatzinfo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatzinfo.Properties.Appearance.Options.UseFont = true;
            this.edtZusatzinfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatzinfo.Properties.ReadOnly = true;
            this.edtZusatzinfo.Size = new System.Drawing.Size(441, 115);
            this.edtZusatzinfo.TabIndex = 420;
            // 
            // edtKreditor
            // 
            this.edtKreditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKreditor.DataMember = "Kreditor";
            this.edtKreditor.DataSource = this.qryQuery;
            this.edtKreditor.Location = new System.Drawing.Point(3, 306);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKreditor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKreditor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKreditor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKreditor.Size = new System.Drawing.Size(319, 24);
            this.edtKreditor.TabIndex = 419;
            this.edtKreditor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKreditor_UserModifiedFld);
            // 
            // CtlRueckläuferKorrigieren
            // 
            this.Name = "CtlRueckläuferKorrigieren";
            this.Size = new System.Drawing.Size(800, 502);
            this.Load += new System.EventHandler(this.CtlRueckläuferKorrigieren_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsweg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtESR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErledigteAnzeigen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatzinfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}