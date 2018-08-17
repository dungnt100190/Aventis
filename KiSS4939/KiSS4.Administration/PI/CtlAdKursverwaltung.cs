using System;
using KiSS4.DB;

namespace KiSS4.Administration.PI
{
    public class CtlAdKursverwaltung : KiSS4.Common.KissSearchUserControl
    {
        #region Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Fields

        private KiSS4.Gui.KissCheckEdit chkAktiv;
        private KiSS4.Gui.KissCheckEdit chkSucheAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colKGS;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissMemoEdit edtBemerkungen;
        private KiSS4.Gui.KissTextEditML edtBezeichnung;
        private KiSS4.Gui.KissLookUpEdit edtKGS;
        private KiSS4.Gui.KissTextEdit edtSucheBemerkungen;
        private KiSS4.Gui.KissTextEdit edtSucheBezeichnung;
        private KiSS4.Gui.KissLookUpEdit edtSucheKGS;
        private KiSS4.Gui.KissGrid grdEdKurs;
        private DevExpress.XtraGrid.Views.Grid.GridView grvEdKurs;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBezeichnung;
        private KiSS4.Gui.KissLabel lblKGS;
        private KiSS4.Gui.KissLabel lblSucheBemerkungen;
        private KiSS4.Gui.KissLabel lblSucheBezeichnung;
        private KiSS4.Gui.KissLabel lblSucheKGS;
        private System.Windows.Forms.Panel panDetails;
        private KiSS4.DB.SqlQuery qryEdKurs;

        #endregion

        #region Constructors

        public CtlAdKursverwaltung()
        {
            this.InitializeComponent();

            // setup rights
            this.SetupRights();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAdKursverwaltung));
            this.grdEdKurs = new KiSS4.Gui.KissGrid();
            this.lblSucheBezeichnung = new KiSS4.Gui.KissLabel();
            this.edtSucheBezeichnung = new KiSS4.Gui.KissTextEdit();
            this.lblSucheKGS = new KiSS4.Gui.KissLabel();
            this.edtSucheKGS = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtSucheBemerkungen = new KiSS4.Gui.KissTextEdit();
            this.chkSucheAktiv = new KiSS4.Gui.KissCheckEdit();
            this.panDetails = new System.Windows.Forms.Panel();
            this.lblBezeichnung = new KiSS4.Gui.KissLabel();
            this.edtBezeichnung = new KiSS4.Gui.KissTextEditML();
            this.lblKGS = new KiSS4.Gui.KissLabel();
            this.edtKGS = new KiSS4.Gui.KissLookUpEdit();
            this.chkAktiv = new KiSS4.Gui.KissCheckEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBezeichnung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKGS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvEdKurs = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryEdKurs = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEdKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKGS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKGS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKGS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAktiv.Properties)).BeginInit();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKGS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKGS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKGS.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEdKurs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdKurs)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(768, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(792, 412);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdEdKurs);
            this.tpgListe.Size = new System.Drawing.Size(780, 374);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.chkSucheAktiv);
            this.tpgSuchen.Controls.Add(this.edtSucheBemerkungen);
            this.tpgSuchen.Controls.Add(this.lblSucheBemerkungen);
            this.tpgSuchen.Controls.Add(this.edtSucheKGS);
            this.tpgSuchen.Controls.Add(this.lblSucheKGS);
            this.tpgSuchen.Controls.Add(this.edtSucheBezeichnung);
            this.tpgSuchen.Controls.Add(this.lblSucheBezeichnung);
            this.tpgSuchen.Size = new System.Drawing.Size(780, 374);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBezeichnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBezeichnung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheKGS, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheKGS, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheAktiv, 0);
            //
            // grdEdKurs
            //
            this.grdEdKurs.DataSource = this.qryEdKurs;
            this.grdEdKurs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEdKurs.EmbeddedNavigator.Name = "";
            this.grdEdKurs.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdEdKurs.Location = new System.Drawing.Point(0, 0);
            this.grdEdKurs.MainView = this.grvEdKurs;
            this.grdEdKurs.Name = "grdEdKurs";
            this.grdEdKurs.Size = new System.Drawing.Size(780, 374);
            this.grdEdKurs.TabIndex = 0;
            this.grdEdKurs.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvEdKurs});
            //
            // lblSucheBezeichnung
            //
            this.lblSucheBezeichnung.Location = new System.Drawing.Point(31, 40);
            this.lblSucheBezeichnung.Name = "lblSucheBezeichnung";
            this.lblSucheBezeichnung.Size = new System.Drawing.Size(105, 24);
            this.lblSucheBezeichnung.TabIndex = 1;
            this.lblSucheBezeichnung.Text = "Bezeichnung";
            this.lblSucheBezeichnung.UseCompatibleTextRendering = true;
            //
            // edtSucheBezeichnung
            //
            this.edtSucheBezeichnung.Location = new System.Drawing.Point(142, 40);
            this.edtSucheBezeichnung.Name = "edtSucheBezeichnung";
            this.edtSucheBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBezeichnung.Size = new System.Drawing.Size(215, 24);
            this.edtSucheBezeichnung.TabIndex = 2;
            //
            // lblSucheKGS
            //
            this.lblSucheKGS.Location = new System.Drawing.Point(31, 70);
            this.lblSucheKGS.Name = "lblSucheKGS";
            this.lblSucheKGS.Size = new System.Drawing.Size(105, 24);
            this.lblSucheKGS.TabIndex = 3;
            this.lblSucheKGS.Text = "KGS";
            this.lblSucheKGS.UseCompatibleTextRendering = true;
            //
            // edtSucheKGS
            //
            this.edtSucheKGS.Location = new System.Drawing.Point(142, 70);
            this.edtSucheKGS.Name = "edtSucheKGS";
            this.edtSucheKGS.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheKGS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheKGS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheKGS.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheKGS.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheKGS.Properties.Appearance.Options.UseFont = true;
            this.edtSucheKGS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheKGS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheKGS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheKGS.Properties.NullText = "";
            this.edtSucheKGS.Properties.ShowFooter = false;
            this.edtSucheKGS.Properties.ShowHeader = false;
            this.edtSucheKGS.Size = new System.Drawing.Size(215, 24);
            this.edtSucheKGS.TabIndex = 4;
            //
            // lblSucheBemerkungen
            //
            this.lblSucheBemerkungen.Location = new System.Drawing.Point(31, 100);
            this.lblSucheBemerkungen.Name = "lblSucheBemerkungen";
            this.lblSucheBemerkungen.Size = new System.Drawing.Size(105, 24);
            this.lblSucheBemerkungen.TabIndex = 5;
            this.lblSucheBemerkungen.Text = "Bemerkungen";
            this.lblSucheBemerkungen.UseCompatibleTextRendering = true;
            //
            // edtSucheBemerkungen
            //
            this.edtSucheBemerkungen.Location = new System.Drawing.Point(142, 100);
            this.edtSucheBemerkungen.Name = "edtSucheBemerkungen";
            this.edtSucheBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBemerkungen.Size = new System.Drawing.Size(215, 24);
            this.edtSucheBemerkungen.TabIndex = 6;
            //
            // chkSucheAktiv
            //
            this.chkSucheAktiv.EditValue = false;
            this.chkSucheAktiv.Location = new System.Drawing.Point(142, 130);
            this.chkSucheAktiv.Name = "chkSucheAktiv";
            this.chkSucheAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheAktiv.Properties.Caption = "Nur aktive";
            this.chkSucheAktiv.Size = new System.Drawing.Size(215, 19);
            this.chkSucheAktiv.TabIndex = 7;
            //
            // panDetails
            //
            this.panDetails.Controls.Add(this.edtBemerkungen);
            this.panDetails.Controls.Add(this.lblBemerkungen);
            this.panDetails.Controls.Add(this.chkAktiv);
            this.panDetails.Controls.Add(this.edtKGS);
            this.panDetails.Controls.Add(this.lblKGS);
            this.panDetails.Controls.Add(this.edtBezeichnung);
            this.panDetails.Controls.Add(this.lblBezeichnung);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 412);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(792, 157);
            this.panDetails.TabIndex = 1;
            //
            // lblBezeichnung
            //
            this.lblBezeichnung.Location = new System.Drawing.Point(9, 9);
            this.lblBezeichnung.Name = "lblBezeichnung";
            this.lblBezeichnung.Size = new System.Drawing.Size(100, 23);
            this.lblBezeichnung.TabIndex = 0;
            this.lblBezeichnung.Text = "Bezeichnung";
            this.lblBezeichnung.UseCompatibleTextRendering = true;
            //
            // edtBezeichnung
            //
            this.edtBezeichnung.DataMember = null;
            this.edtBezeichnung.DataMemberDefaultText = "Bezeichnung";
            this.edtBezeichnung.DataMemberTID = "BezeichnungTID";
            this.edtBezeichnung.DataSource = this.qryEdKurs;
            this.edtBezeichnung.Location = new System.Drawing.Point(115, 9);
            this.edtBezeichnung.Name = "edtBezeichnung";
            this.edtBezeichnung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBezeichnung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBezeichnung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBezeichnung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBezeichnung.Properties.Appearance.Options.UseFont = true;
            this.edtBezeichnung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBezeichnung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtBezeichnung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBezeichnung.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered;
            this.edtBezeichnung.Size = new System.Drawing.Size(248, 24);
            this.edtBezeichnung.TabIndex = 1;
            //
            // lblKGS
            //
            this.lblKGS.Location = new System.Drawing.Point(9, 39);
            this.lblKGS.Name = "lblKGS";
            this.lblKGS.Size = new System.Drawing.Size(100, 24);
            this.lblKGS.TabIndex = 2;
            this.lblKGS.Text = "KGS";
            this.lblKGS.UseCompatibleTextRendering = true;
            //
            // edtKGS
            //
            this.edtKGS.AllowNull = false;
            this.edtKGS.DataMember = "OrgUnitID";
            this.edtKGS.DataSource = this.qryEdKurs;
            this.edtKGS.Location = new System.Drawing.Point(115, 39);
            this.edtKGS.Name = "edtKGS";
            this.edtKGS.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKGS.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKGS.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKGS.Properties.Appearance.Options.UseBackColor = true;
            this.edtKGS.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKGS.Properties.Appearance.Options.UseFont = true;
            this.edtKGS.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKGS.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKGS.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKGS.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKGS.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKGS.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKGS.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKGS.Properties.NullText = "";
            this.edtKGS.Properties.ShowFooter = false;
            this.edtKGS.Properties.ShowHeader = false;
            this.edtKGS.Size = new System.Drawing.Size(248, 24);
            this.edtKGS.TabIndex = 3;
            //
            // chkAktiv
            //
            this.chkAktiv.DataMember = "Aktiv";
            this.chkAktiv.DataSource = this.qryEdKurs;
            this.chkAktiv.Location = new System.Drawing.Point(115, 69);
            this.chkAktiv.Name = "chkAktiv";
            this.chkAktiv.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAktiv.Properties.Appearance.Options.UseBackColor = true;
            this.chkAktiv.Properties.Caption = "Aktiv";
            this.chkAktiv.Size = new System.Drawing.Size(248, 19);
            this.chkAktiv.TabIndex = 4;
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Location = new System.Drawing.Point(9, 94);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(100, 24);
            this.lblBemerkungen.TabIndex = 5;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            //
            // edtBemerkungen
            //
            this.edtBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkungen.DataMember = "Bemerkungen";
            this.edtBemerkungen.DataSource = this.qryEdKurs;
            this.edtBemerkungen.Location = new System.Drawing.Point(115, 94);
            this.edtBemerkungen.Name = "edtBemerkungen";
            this.edtBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkungen.Properties.MaxLength = 2000;
            this.edtBemerkungen.Size = new System.Drawing.Size(470, 54);
            this.edtBemerkungen.TabIndex = 6;
            //
            // colAktiv
            //
            this.colAktiv.Caption = "Aktiv";
            this.colAktiv.FieldName = "Aktiv";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 2;
            this.colAktiv.Width = 60;
            //
            // colBemerkungen
            //
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.FieldName = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 3;
            this.colBemerkungen.Width = 220;
            //
            // colBezeichnung
            //
            this.colBezeichnung.Caption = "Bezeichnung";
            this.colBezeichnung.FieldName = "MLBezeichnung";
            this.colBezeichnung.Name = "colBezeichnung";
            this.colBezeichnung.Visible = true;
            this.colBezeichnung.VisibleIndex = 0;
            this.colBezeichnung.Width = 250;
            //
            // colKGS
            //
            this.colKGS.Caption = "KGS";
            this.colKGS.FieldName = "KGS";
            this.colKGS.Name = "colKGS";
            this.colKGS.Visible = true;
            this.colKGS.VisibleIndex = 1;
            this.colKGS.Width = 200;
            //
            // grvEdKurs
            //
            this.grvEdKurs.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvEdKurs.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdKurs.Appearance.Empty.Options.UseBackColor = true;
            this.grvEdKurs.Appearance.Empty.Options.UseFont = true;
            this.grvEdKurs.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdKurs.Appearance.EvenRow.Options.UseFont = true;
            this.grvEdKurs.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEdKurs.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdKurs.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvEdKurs.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvEdKurs.Appearance.FocusedCell.Options.UseFont = true;
            this.grvEdKurs.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvEdKurs.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvEdKurs.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdKurs.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvEdKurs.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvEdKurs.Appearance.FocusedRow.Options.UseFont = true;
            this.grvEdKurs.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvEdKurs.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEdKurs.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvEdKurs.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvEdKurs.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEdKurs.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEdKurs.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvEdKurs.Appearance.GroupRow.Options.UseFont = true;
            this.grvEdKurs.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvEdKurs.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvEdKurs.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvEdKurs.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvEdKurs.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvEdKurs.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvEdKurs.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvEdKurs.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvEdKurs.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdKurs.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvEdKurs.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvEdKurs.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvEdKurs.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvEdKurs.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvEdKurs.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvEdKurs.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdKurs.Appearance.OddRow.Options.UseFont = true;
            this.grvEdKurs.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvEdKurs.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdKurs.Appearance.Row.Options.UseBackColor = true;
            this.grvEdKurs.Appearance.Row.Options.UseFont = true;
            this.grvEdKurs.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvEdKurs.Appearance.SelectedRow.Options.UseFont = true;
            this.grvEdKurs.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvEdKurs.Appearance.VertLine.Options.UseBackColor = true;
            this.grvEdKurs.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvEdKurs.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colBezeichnung,
                        this.colKGS,
                        this.colAktiv,
                        this.colBemerkungen});
            this.grvEdKurs.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvEdKurs.GridControl = this.grdEdKurs;
            this.grvEdKurs.Name = "grvEdKurs";
            this.grvEdKurs.OptionsBehavior.Editable = false;
            this.grvEdKurs.OptionsCustomization.AllowFilter = false;
            this.grvEdKurs.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvEdKurs.OptionsNavigation.AutoFocusNewRow = true;
            this.grvEdKurs.OptionsNavigation.UseTabKey = false;
            this.grvEdKurs.OptionsView.ColumnAutoWidth = false;
            this.grvEdKurs.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvEdKurs.OptionsView.ShowGroupPanel = false;
            this.grvEdKurs.OptionsView.ShowIndicator = false;
            //
            // qryEdKurs
            //
            this.qryEdKurs.HostControl = this;
            this.qryEdKurs.SelectStatement = resources.GetString("qryEdKurs.SelectStatement");
            this.qryEdKurs.TableName = "EdKurs";
            this.qryEdKurs.BeforePost += new System.EventHandler(this.qryEdKurs_BeforePost);
            this.qryEdKurs.AfterFill += new System.EventHandler(this.qryEdKurs_AfterFill);
            this.qryEdKurs.AfterInsert += new System.EventHandler(this.qryEdKurs_AfterInsert);
            this.qryEdKurs.BeforeDeleteQuestion += new System.EventHandler(this.qryEdKurs_BeforeDeleteQuestion);
            this.qryEdKurs.AfterPost += new System.EventHandler(this.qryEdKurs_AfterPost);
            //
            // CtlAdKursverwaltung
            //
            this.ActiveSQLQuery = this.qryEdKurs;
            this.Controls.Add(this.panDetails);
            this.Name = "CtlAdKursverwaltung";
            this.Size = new System.Drawing.Size(792, 569);
            this.Load += new System.EventHandler(this.CtlAdKursverwaltung_Load);
            this.Controls.SetChildIndex(this.panDetails, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEdKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheKGS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKGS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheKGS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheAktiv.Properties)).EndInit();
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblBezeichnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBezeichnung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKGS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKGS.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKGS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAktiv.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvEdKurs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryEdKurs)).EndInit();
            this.ResumeLayout(false);
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

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set default values and focus
            chkSucheAktiv.Checked = true;

            // set focus
            edtSucheBezeichnung.Focus();
        }

        protected override void RunSearch()
        {
            // replace search parameters
            Object[] parameters = new Object[] { Session.User.LanguageCode };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void ApplyKGSLookUps()
        {
            // logging
            logger.Debug("enter");

            // init controls
            this.edtKGS.Properties.DataSource = null;
            this.edtSucheKGS.Properties.DataSource = null;

            // get KS orgunits
            SqlQuery qryKGS = DBUtil.OpenSQL(@"
                    SELECT [Code]    = NULL,
                           [Text]    = ''

                    UNION

                    SELECT [Code]    = ORG.OrgUnitID,
                           [Text]    = ORG.ItemName
                    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                    WHERE ORG.OEItemTypCode = 4                      -- (OrganisationsEinheitTyp: 4=Kantonale Geschäftsstelle)
                    ORDER BY [Text], [Code]");

            // setup edtKGS
            this.edtKGS.LoadQuery(qryKGS);
            this.edtKGS.Properties.DropDownRows = Math.Min(qryKGS.Count, 7);

            // setup edtSucheKGS
            this.edtSucheKGS.LoadQuery(qryKGS);
            this.edtSucheKGS.Properties.DropDownRows = Math.Min(qryKGS.Count, 7);

            // logging
            logger.Debug("done");
        }

        private void CtlAdKursverwaltung_Load(object sender, System.EventArgs e)
        {
            // load dropdown-values
            this.ApplyKGSLookUps();

            // run search
            this.NewSearch();
            this.tabControlSearch.SelectTab(this.tpgListe);
        }

        private void SetupRights()
        {
            // VARS
            Boolean isAdmin = Session.User.IsUserAdmin;
            Boolean canReadData = false;
            Boolean canInsert = false;
            Boolean canUpdate = false;
            Boolean canDelete = false;

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canInsert, out canUpdate, out canDelete);
            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // BaKantonalerZuschuss
            qryEdKurs.CanInsert = isAdmin || canInsert;
            qryEdKurs.CanUpdate = isAdmin || canUpdate;
            qryEdKurs.CanDelete = isAdmin || canDelete;

            // FIELDS
            qryEdKurs.EnableBoundFields();
        }

        private void qryEdKurs_AfterFill(object sender, System.EventArgs e)
        {
            // select last row
            qryEdKurs.Last();
        }

        private void qryEdKurs_AfterInsert(object sender, System.EventArgs e)
        {
            // set default value
            qryEdKurs["Aktiv"] = 1;

            // creator of row (if changed)
            qryEdKurs["Creator"] = DBUtil.GetDBRowCreatorModifier();

            // set focus
            edtBezeichnung.Focus();
        }

        private void qryEdKurs_AfterPost(object sender, System.EventArgs e)
        {
            // apply new data
            qryEdKurs["MLBezeichnung"] = edtBezeichnung.Text;
            qryEdKurs["KGS"] = edtKGS.Text;
        }

        private void qryEdKurs_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            // check if entry is not in use already
            Int32 countUsage = Convert.ToInt32(DBUtil.ExecuteScalarSQLThrowingException(@"
                    SELECT COUNT(1)
                    FROM dbo.EdMitarbeiter_Kurs WITH (READUNCOMMITTED)
                    WHERE EdKursID = {0}", qryEdKurs["EdKursID"]));

            if (countUsage > 0)
            {
                // entry cannot be deleted because of usage
                KissMsg.ShowError("CtlAdKursverwaltung", "CannotDeleteEntry", "Dieser Eintrag ist zurzeit zu mindestens einem Mitarbeiter zugewiesen und kann daher nicht gelöscht werden.");

                // cancel
                throw new KissCancelException();
            }
        }

        private void qryEdKurs_BeforePost(object sender, System.EventArgs e)
        {
            // validate mustfields
            DBUtil.CheckNotNullField(edtBezeichnung, lblBezeichnung.Text);
        }

        #endregion
    }
}