
using DevExpress.XtraEditors.Controls;

namespace KiSS4.Fallfuehrung.ZH
{
    partial class CtlFaRessourcenkarte
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaRessourcenkarte));
            this.grdRessourcenkarte = new KiSS4.Gui.KissGrid();
            this.qryFaRessourcenkarte = new KiSS4.DB.SqlQuery(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterschrrift = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Team = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ShortName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtPerson = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtStatusCode = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtPersResKomp = new KiSS4.Gui.KissMemoEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.edtSozResKomp = new KiSS4.Gui.KissMemoEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtMatRes = new KiSS4.Gui.KissMemoEdit();
            this.edtInfraRes = new KiSS4.Gui.KissMemoEdit();
            this.edtDatumUnterschrift = new KiSS4.Gui.KissDateEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.btnDokument = new KiSS4.Dokument.KissDocumentButton();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.btnResCopy = new KiSS4.Gui.KissButton();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.lblUserErfasst = new KiSS4.Gui.KissLabel();
            this.lblUserMutiert = new KiSS4.Gui.KissLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.qryUser = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdRessourcenkarte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaRessourcenkarte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersResKomp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSozResKomp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMatRes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfraRes.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumUnterschrift.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserErfasst)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserMutiert)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).BeginInit();
            this.SuspendLayout();
            // 
            // grdRessourcenkarte
            // 
            this.grdRessourcenkarte.DataSource = this.qryFaRessourcenkarte;
            // 
            // 
            // 
            this.grdRessourcenkarte.EmbeddedNavigator.Name = "kissGrid1.EmbeddedNavigator";
            this.grdRessourcenkarte.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRessourcenkarte.Location = new System.Drawing.Point(5, 30);
            this.grdRessourcenkarte.MainView = this.gridView1;
            this.grdRessourcenkarte.Name = "grdRessourcenkarte";
            this.grdRessourcenkarte.Size = new System.Drawing.Size(699, 104);
            this.grdRessourcenkarte.TabIndex = 0;
            this.grdRessourcenkarte.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // qryFaRessourcenkarte
            // 
            this.qryFaRessourcenkarte.CanDelete = true;
            this.qryFaRessourcenkarte.CanInsert = true;
            this.qryFaRessourcenkarte.CanUpdate = true;
            this.qryFaRessourcenkarte.HostControl = this;
            this.qryFaRessourcenkarte.SelectStatement = resources.GetString("qryFaRessourcenkarte.SelectStatement");
            this.qryFaRessourcenkarte.TableName = "FaRessourcenkarte";
            this.qryFaRessourcenkarte.AfterFill += new System.EventHandler(this.qryFaRessourcenkarte_AfterFill);
            this.qryFaRessourcenkarte.AfterInsert += new System.EventHandler(this.qryFaRessourcenkarte_AfterInsert);
            this.qryFaRessourcenkarte.AfterPost += new System.EventHandler(this.qryFaRessourcenkarte_AfterPost);
            this.qryFaRessourcenkarte.BeforeDeleteQuestion += new System.EventHandler(this.qryFaRessourcenkarte_BeforeDeleteQuestion);
            this.qryFaRessourcenkarte.BeforePost += new System.EventHandler(this.qryFaRessourcenkarte_BeforePost);
            this.qryFaRessourcenkarte.PositionChanged += new System.EventHandler(this.qryFaRessourcenkarte_PositionChanged);
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
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colPerson,
            this.Geburtsdatum,
            this.colUnterschrrift,
            this.Team,
            this.ShortName});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdRessourcenkarte;
            this.gridView1.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.AllowFilterEditor = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "erstellt";
            this.colDatum.FieldName = "ErstelltDatum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 98;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "für Person";
            this.colPerson.FieldName = "BaPersonID";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 1;
            this.colPerson.Width = 177;
            // 
            // Geburtsdatum
            // 
            this.Geburtsdatum.Caption = "Geb.Dat.";
            this.Geburtsdatum.FieldName = "Geburtsdatum";
            this.Geburtsdatum.Name = "Geburtsdatum";
            this.Geburtsdatum.Visible = true;
            this.Geburtsdatum.VisibleIndex = 3;
            this.Geburtsdatum.Width = 112;
            // 
            // colUnterschrrift
            // 
            this.colUnterschrrift.Caption = "unterschrieben";
            this.colUnterschrrift.DisplayFormat.FormatString = "dd.MM.yyyy";
            this.colUnterschrrift.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colUnterschrrift.FieldName = "UnterschriebenDatum";
            this.colUnterschrrift.Name = "colUnterschrrift";
            this.colUnterschrrift.Visible = true;
            this.colUnterschrrift.VisibleIndex = 2;
            this.colUnterschrrift.Width = 110;
            // 
            // Team
            // 
            this.Team.Caption = "OE";
            this.Team.FieldName = "OrgUnit";
            this.Team.Name = "Team";
            this.Team.Visible = true;
            this.Team.VisibleIndex = 4;
            this.Team.Width = 104;
            // 
            // ShortName
            // 
            this.ShortName.Caption = "MA-Kürzel";
            this.ShortName.FieldName = "LogonName";
            this.ShortName.Name = "ShortName";
            this.ShortName.Visible = true;
            this.ShortName.VisibleIndex = 5;
            // 
            // edtPerson
            // 
            this.edtPerson.DataMember = "BaPersonID";
            this.edtPerson.DataSource = this.qryFaRessourcenkarte;
            this.edtPerson.Location = new System.Drawing.Point(3, 167);
            this.edtPerson.Name = "edtPerson";
            this.edtPerson.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPerson.Properties.Appearance.Options.UseFont = true;
            this.edtPerson.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtPerson.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtPerson.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtPerson.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtPerson.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Code", "", 10, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 30, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtPerson.Properties.DisplayMember = "Text";
            this.edtPerson.Properties.NullText = "";
            this.edtPerson.Properties.ShowFooter = false;
            this.edtPerson.Properties.ShowHeader = false;
            this.edtPerson.Properties.ValueMember = "Code";
            this.edtPerson.Size = new System.Drawing.Size(339, 24);
            this.edtPerson.TabIndex = 1;
            // 
            // kissLabel2
            // 
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel2.Location = new System.Drawing.Point(5, 194);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(288, 16);
            this.kissLabel2.TabIndex = 1;
            this.kissLabel2.Text = "Persönliche Ressourcen und Kompetenzen";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // edtStatusCode
            // 
            this.edtStatusCode.AllowNull = false;
            this.edtStatusCode.DataMember = "StatusCode";
            this.edtStatusCode.DataSource = this.qryFaRessourcenkarte;
            this.edtStatusCode.Location = new System.Drawing.Point(366, 167);
            this.edtStatusCode.LOVFilterWhereAppend = true;
            this.edtStatusCode.LOVName = "FaRessourcenkarteStatus";
            this.edtStatusCode.Name = "edtStatusCode";
            this.edtStatusCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatusCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatusCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatusCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatusCode.Properties.Appearance.Options.UseFont = true;
            this.edtStatusCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatusCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatusCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatusCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatusCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtStatusCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtStatusCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatusCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtStatusCode.Properties.DisplayMember = "Text";
            this.edtStatusCode.Properties.DropDownRows = 1;
            this.edtStatusCode.Properties.NullText = "";
            this.edtStatusCode.Properties.ShowFooter = false;
            this.edtStatusCode.Properties.ShowHeader = false;
            this.edtStatusCode.Properties.ValueMember = "Code";
            this.edtStatusCode.Size = new System.Drawing.Size(338, 24);
            this.edtStatusCode.TabIndex = 2;
            this.edtStatusCode.EditValueChanged += new System.EventHandler(this.edtStatusCode_EditValueChanged);
            // 
            // kissLabel3
            // 
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel3.Location = new System.Drawing.Point(367, 194);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(292, 16);
            this.kissLabel3.TabIndex = 2;
            this.kissLabel3.Text = "Soziale Ressourcen (Beziehungen)";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // edtPersResKomp
            // 
            this.edtPersResKomp.DataMember = "RessourcenPersoenlich";
            this.edtPersResKomp.DataSource = this.qryFaRessourcenkarte;
            this.edtPersResKomp.Location = new System.Drawing.Point(5, 234);
            this.edtPersResKomp.Name = "edtPersResKomp";
            this.edtPersResKomp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtPersResKomp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPersResKomp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPersResKomp.Properties.Appearance.Options.UseBackColor = true;
            this.edtPersResKomp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPersResKomp.Properties.Appearance.Options.UseFont = true;
            this.edtPersResKomp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPersResKomp.Size = new System.Drawing.Size(337, 90);
            this.edtPersResKomp.TabIndex = 3;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(5, 210);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(280, 24);
            this.kissLabel4.TabIndex = 3;
            this.kissLabel4.Text = "Über welche Fähigkeiten, Möglichkeiten verfügen Sie?";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // edtSozResKomp
            // 
            this.edtSozResKomp.DataMember = "RessourcenSozial";
            this.edtSozResKomp.DataSource = this.qryFaRessourcenkarte;
            this.edtSozResKomp.Location = new System.Drawing.Point(367, 234);
            this.edtSozResKomp.Name = "edtSozResKomp";
            this.edtSozResKomp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSozResKomp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSozResKomp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSozResKomp.Properties.Appearance.Options.UseBackColor = true;
            this.edtSozResKomp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSozResKomp.Properties.Appearance.Options.UseFont = true;
            this.edtSozResKomp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSozResKomp.Size = new System.Drawing.Size(337, 90);
            this.edtSozResKomp.TabIndex = 4;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(367, 210);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(357, 24);
            this.kissLabel5.TabIndex = 4;
            this.kissLabel5.Text = "Wie können Verwandte, Freunde, Bekannte Sie unterstützen?";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // edtMatRes
            // 
            this.edtMatRes.DataMember = "RessourcenMateriell";
            this.edtMatRes.DataSource = this.qryFaRessourcenkarte;
            this.edtMatRes.Location = new System.Drawing.Point(5, 405);
            this.edtMatRes.Name = "edtMatRes";
            this.edtMatRes.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMatRes.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMatRes.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMatRes.Properties.Appearance.Options.UseBackColor = true;
            this.edtMatRes.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMatRes.Properties.Appearance.Options.UseFont = true;
            this.edtMatRes.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMatRes.Size = new System.Drawing.Size(337, 90);
            this.edtMatRes.TabIndex = 5;
            // 
            // edtInfraRes
            // 
            this.edtInfraRes.DataMember = "RessourcenInfrastrukturell";
            this.edtInfraRes.DataSource = this.qryFaRessourcenkarte;
            this.edtInfraRes.Location = new System.Drawing.Point(367, 405);
            this.edtInfraRes.Name = "edtInfraRes";
            this.edtInfraRes.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInfraRes.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInfraRes.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInfraRes.Properties.Appearance.Options.UseBackColor = true;
            this.edtInfraRes.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInfraRes.Properties.Appearance.Options.UseFont = true;
            this.edtInfraRes.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInfraRes.Size = new System.Drawing.Size(337, 90);
            this.edtInfraRes.TabIndex = 6;
            // 
            // edtDatumUnterschrift
            // 
            this.edtDatumUnterschrift.DataMember = "UnterschriebenDatum";
            this.edtDatumUnterschrift.DataSource = this.qryFaRessourcenkarte;
            this.edtDatumUnterschrift.EditValue = ((object)(resources.GetObject("edtDatumUnterschrift.EditValue")));
            this.edtDatumUnterschrift.Location = new System.Drawing.Point(366, 501);
            this.edtDatumUnterschrift.Name = "edtDatumUnterschrift";
            this.edtDatumUnterschrift.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumUnterschrift.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumUnterschrift.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumUnterschrift.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumUnterschrift.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumUnterschrift.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumUnterschrift.Properties.Appearance.Options.UseFont = true;
            this.edtDatumUnterschrift.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumUnterschrift.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumUnterschrift.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumUnterschrift.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumUnterschrift.Properties.Name = "edtFaDokBesprDatum.Properties";
            this.edtDatumUnterschrift.Properties.ShowToday = false;
            this.edtDatumUnterschrift.Size = new System.Drawing.Size(108, 24);
            this.edtDatumUnterschrift.TabIndex = 7;
            // 
            // kissLabel6
            // 
            this.kissLabel6.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel6.Location = new System.Drawing.Point(5, 357);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(152, 16);
            this.kissLabel6.TabIndex = 7;
            this.kissLabel6.Text = "Materielle Ressourcen";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // btnDokument
            // 
            this.btnDokument.Context = "FaRessourcenkarte";
            this.btnDokument.DocumentFormat = KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All;
            this.btnDokument.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDokument.Image = ((System.Drawing.Image)(resources.GetObject("btnDokument.Image")));
            this.btnDokument.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDokument.Location = new System.Drawing.Point(5, 501);
            this.btnDokument.Name = "btnDokument";
            this.btnDokument.Size = new System.Drawing.Size(134, 24);
            this.btnDokument.TabIndex = 8;
            this.btnDokument.Text = "Ressourcenkarte";
            this.btnDokument.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDokument.UseCompatibleTextRendering = true;
            this.btnDokument.UseVisualStyleBackColor = false;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel7.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel7.Location = new System.Drawing.Point(5, 381);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(296, 23);
            this.kissLabel7.TabIndex = 8;
            this.kissLabel7.Text = "Über welche materiellen, finanziellen Mittel verfügen Sie?";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // btnResCopy
            // 
            this.btnResCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResCopy.Location = new System.Drawing.Point(528, 501);
            this.btnResCopy.Name = "btnResCopy";
            this.btnResCopy.Size = new System.Drawing.Size(176, 24);
            this.btnResCopy.TabIndex = 9;
            this.btnResCopy.Text = "Ressourcenkarte kopieren";
            this.btnResCopy.UseCompatibleTextRendering = true;
            this.btnResCopy.UseVisualStyleBackColor = false;
            this.btnResCopy.Click += new System.EventHandler(this.btnResCopy_Click);
            // 
            // kissLabel8
            // 
            this.kissLabel8.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel8.Location = new System.Drawing.Point(367, 327);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(357, 32);
            this.kissLabel8.TabIndex = 9;
            this.kissLabel8.Text = "Infrastrukturelle (sozialräumliche) Ressourcen und institutionelle Ressourcen";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel9.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel9.Location = new System.Drawing.Point(367, 359);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(357, 43);
            this.kissLabel9.TabIndex = 10;
            this.kissLabel9.Text = "Welche Organisation hat/kann Sie in Ihrem Quartier unterstützen? Welche Infrastru" +
    "kturen/Einrichtungen im Quartier, in der Region sind für Sie hilfreich?";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // kissLabel13
            // 
            this.kissLabel13.Location = new System.Drawing.Point(239, 501);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(103, 24);
            this.kissLabel13.TabIndex = 32;
            this.kissLabel13.Text = "unterschrieben am";
            this.kissLabel13.UseCompatibleTextRendering = true;
            // 
            // kissLabel12
            // 
            this.kissLabel12.Location = new System.Drawing.Point(5, 140);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(58, 24);
            this.kissLabel12.TabIndex = 33;
            this.kissLabel12.Text = "Für Person";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(367, 140);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(155, 24);
            this.kissLabel10.TabIndex = 40;
            this.kissLabel10.Text = "Status";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel11.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel11.Location = new System.Drawing.Point(5, 531);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(100, 18);
            this.kissLabel11.TabIndex = 41;
            this.kissLabel11.Text = "Erfassung";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // kissLabel14
            // 
            this.kissLabel14.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel14.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel14.Location = new System.Drawing.Point(5, 549);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(85, 18);
            this.kissLabel14.TabIndex = 42;
            this.kissLabel14.Text = "Letzte Mutation";
            this.kissLabel14.UseCompatibleTextRendering = true;
            // 
            // lblUserErfasst
            // 
            this.lblUserErfasst.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblUserErfasst.Location = new System.Drawing.Point(96, 529);
            this.lblUserErfasst.Name = "lblUserErfasst";
            this.lblUserErfasst.Size = new System.Drawing.Size(176, 18);
            this.lblUserErfasst.TabIndex = 43;
            this.lblUserErfasst.Text = "sozera, 23.08.2007";
            this.lblUserErfasst.UseCompatibleTextRendering = true;
            // 
            // lblUserMutiert
            // 
            this.lblUserMutiert.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblUserMutiert.Location = new System.Drawing.Point(96, 547);
            this.lblUserMutiert.Name = "lblUserMutiert";
            this.lblUserMutiert.Size = new System.Drawing.Size(176, 18);
            this.lblUserMutiert.TabIndex = 44;
            this.lblUserMutiert.Text = "kissLabel15";
            this.lblUserMutiert.UseCompatibleTextRendering = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 24);
            this.panel1.TabIndex = 115;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Ressourcenkarte";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // qryUser
            // 
            this.qryUser.HostControl = this;
            this.qryUser.SelectStatement = "select LogonName from XUser\r\nwhere UserID = {0}";
            // 
            // CtlFaRessourcenkarte
            // 
            this.ActiveSQLQuery = this.qryFaRessourcenkarte;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblUserMutiert);
            this.Controls.Add(this.lblUserErfasst);
            this.Controls.Add(this.kissLabel14);
            this.Controls.Add(this.kissLabel11);
            this.Controls.Add(this.kissLabel10);
            this.Controls.Add(this.kissLabel12);
            this.Controls.Add(this.kissLabel13);
            this.Controls.Add(this.kissLabel9);
            this.Controls.Add(this.kissLabel8);
            this.Controls.Add(this.btnResCopy);
            this.Controls.Add(this.kissLabel7);
            this.Controls.Add(this.btnDokument);
            this.Controls.Add(this.kissLabel6);
            this.Controls.Add(this.edtDatumUnterschrift);
            this.Controls.Add(this.edtInfraRes);
            this.Controls.Add(this.edtMatRes);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.edtSozResKomp);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.edtPersResKomp);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.edtStatusCode);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.edtPerson);
            this.Controls.Add(this.grdRessourcenkarte);
            this.Location = new System.Drawing.Point(8, 0);
            this.Name = "CtlFaRessourcenkarte";
            this.Size = new System.Drawing.Size(715, 576);
            ((System.ComponentModel.ISupportInitialize)(this.grdRessourcenkarte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaRessourcenkarte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatusCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPersResKomp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSozResKomp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMatRes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInfraRes.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumUnterschrift.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserErfasst)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserMutiert)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissGrid grdRessourcenkarte;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblUserErfasst;
        private KiSS4.Gui.KissLabel lblUserMutiert;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFaRessourcenkarte;
        private KiSS4.DB.SqlQuery qryUser;
        private DevExpress.XtraGrid.Columns.GridColumn Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn ShortName;
        private DevExpress.XtraGrid.Columns.GridColumn Team;
        private int baPersonID = -1;
        private KiSS4.Dokument.KissDocumentButton btnDokument;
        private KiSS4.Gui.KissButton btnResCopy;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterschrrift;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtDatumUnterschrift;
        private KiSS4.Gui.KissMemoEdit edtInfraRes;
        private KiSS4.Gui.KissMemoEdit edtMatRes;
        private KiSS4.Gui.KissMemoEdit edtPersResKomp;
        private KiSS4.Gui.KissLookUpEdit edtPerson;
        private KiSS4.Gui.KissMemoEdit edtSozResKomp;
        private KiSS4.Gui.KissLookUpEdit edtStatusCode;
    }
}