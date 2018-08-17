using System;
using System.Windows.Forms;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Schnittstellen.Newod
{
    public class CtlKiSSNewodMapping : KiSS4.Gui.KissUserControl
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private System.Windows.Forms.Panel panelGrid;
        private KiSS4.Gui.KissGrid grdBaPerson;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissGrid grdNewodPerson;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private KiSS4.DB.SqlQuery qryNewodPerson;
        private KiSS4.Gui.KissLabel lblAHVNummer;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblVorname;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel lblVersichertennummer;
        private KiSS4.Gui.KissLabel lblVersichertennummerNewodPerson;
        private KiSS4.Gui.KissLabel lblAHVNummerNewodPerson;
        private KiSS4.Gui.KissLabel lblGeburtsdatumNewodPerson;
        private KiSS4.Gui.KissLabel lblVornameNewodPerson;
        private KiSS4.Gui.KissLabel lblNameNewodPerson;
        private KiSS4.Gui.KissTextEdit edtVersichertennummerBaPerson;
        private KiSS4.Gui.KissTextEdit edtAHVNummerBaPerson;
        private KiSS4.Gui.KissTextEdit edtVornameBaPerson;
        private KiSS4.Gui.KissTextEdit edtNameBaPerson;
        private KiSS4.Gui.KissTextEdit edtVersichertennummerNewodPerson;
        private KiSS4.Gui.KissTextEdit edtAHVNummerNewodPerson;
        private KiSS4.Gui.KissTextEdit edtVornameNewodPerson;
        private KiSS4.Gui.KissTextEdit edtNameNewodPerson;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatumBaPerson;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatumNewodPerson;
        private KiSS4.Gui.KissCheckedLookupEdit edtMappingKriterien;
        private DevExpress.XtraGrid.Views.Grid.GridView grdVwNewodPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBaPerson;
        private DevExpress.XtraGrid.Columns.GridColumn Vorname2;
        private DevExpress.XtraGrid.Columns.GridColumn Nachname;
        private DevExpress.XtraGrid.Columns.GridColumn AHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn Geburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn Strasse;
        private DevExpress.XtraGrid.Columns.GridColumn PLZ;
        private DevExpress.XtraGrid.Columns.GridColumn Ort;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonNachname;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonVorname;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonGeburtsdatum;
        private KissTextEdit edtOrtNewodPerson;
        private KissTextEdit edtOrtBaPerson;
        private KissTextEdit edtPLZNewodPerson;
        private KissTextEdit edtPLZBaPerson;
        private KissTextEdit edtStrasseNewodPerson;
        private KissTextEdit edtStrasseBaPerson;
        private KissLabel kissLabel2;
        private KissLabel lblPLZOrt;
        private KissLabel lblStrasseNewodPerson;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonVersichertennummer;
        private KissButton btnDoMapping;
        private DevExpress.XtraGrid.Columns.GridColumn isMapped;
        private System.Windows.Forms.CheckBox edtConfirm;
        private KissLabel kissLabel1;
        private KissLabel kissLabel3;
        private Label lblCount;
        private System.Windows.Forms.Panel panelAction;

        public CtlKiSSNewodMapping()
        {
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKiSSNewodMapping));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.grdNewodPerson = new KiSS4.Gui.KissGrid();
            this.qryNewodPerson = new KiSS4.DB.SqlQuery(this.components);
            this.grdVwNewodPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Vorname2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Nachname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.AHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Geburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Strasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Ort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBaPerson = new KiSS4.Gui.KissGrid();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.gridViewBaPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.isMapped = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonNachname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtMappingKriterien = new KiSS4.Gui.KissCheckedLookupEdit();
            this.panelAction = new System.Windows.Forms.Panel();
            this.edtConfirm = new System.Windows.Forms.CheckBox();
            this.btnDoMapping = new KiSS4.Gui.KissButton();
            this.edtVersichertennummerNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtOrtNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtOrtBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtPLZNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtPLZBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtStrasseNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtStrasseBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtVersichertennummerBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtAHVNummerNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtAHVNummerBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtVornameNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtVornameBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtNameNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtNameBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtGeburtsdatumBaPerson = new KiSS4.Gui.KissDateEdit();
            this.edtGeburtsdatumNewodPerson = new KiSS4.Gui.KissDateEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.lblPLZOrt = new KiSS4.Gui.KissLabel();
            this.lblStrasseNewodPerson = new KiSS4.Gui.KissLabel();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.lblVersichertennummerNewodPerson = new KiSS4.Gui.KissLabel();
            this.lblVersichertennummer = new KiSS4.Gui.KissLabel();
            this.lblAHVNummerNewodPerson = new KiSS4.Gui.KissLabel();
            this.lblAHVNummer = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatumNewodPerson = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.lblVornameNewodPerson = new KiSS4.Gui.KissLabel();
            this.lblVorname = new KiSS4.Gui.KissLabel();
            this.lblNameNewodPerson = new KiSS4.Gui.KissLabel();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMappingKriterien)).BeginInit();
            this.panelAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummerNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummerBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummerNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummerBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertennummerNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertennummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummerNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatumNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornameNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.lblCount);
            this.panelGrid.Controls.Add(this.kissLabel3);
            this.panelGrid.Controls.Add(this.kissLabel1);
            this.panelGrid.Controls.Add(this.grdNewodPerson);
            this.panelGrid.Controls.Add(this.grdBaPerson);
            this.panelGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1000, 367);
            this.panelGrid.TabIndex = 0;
            this.panelGrid.Tag = "";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(312, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(99, 13);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Anzahl Datensätze:";
            // 
            // kissLabel3
            // 
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel3.Location = new System.Drawing.Point(547, 10);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(165, 23);
            this.kissLabel3.TabIndex = 1;
            this.kissLabel3.Text = "NEWOD Person";
            // 
            // kissLabel1
            // 
            this.kissLabel1.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel1.Location = new System.Drawing.Point(8, 10);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(100, 23);
            this.kissLabel1.TabIndex = 1;
            this.kissLabel1.Text = "KiSS Person";
            // 
            // grdNewodPerson
            // 
            this.grdNewodPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdNewodPerson.DataSource = this.qryNewodPerson;
            this.grdNewodPerson.EmbeddedNavigator.Name = "";
            this.grdNewodPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdNewodPerson.Location = new System.Drawing.Point(550, 40);
            this.grdNewodPerson.MainView = this.grdVwNewodPerson;
            this.grdNewodPerson.Name = "grdNewodPerson";
            this.grdNewodPerson.Size = new System.Drawing.Size(447, 321);
            this.grdNewodPerson.TabIndex = 0;
            this.grdNewodPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdVwNewodPerson});
            // 
            // qryNewodPerson
            // 
            this.qryNewodPerson.HostControl = this;
            this.qryNewodPerson.SelectStatement = resources.GetString("qryNewodPerson.SelectStatement");
            this.qryNewodPerson.TableName = "NewodPerson";
            this.qryNewodPerson.PositionChanged += new System.EventHandler(this.qryNewodPerson_PositionChanged);
            // 
            // grdVwNewodPerson
            // 
            this.grdVwNewodPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grdVwNewodPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdVwNewodPerson.Appearance.Empty.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.Empty.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grdVwNewodPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdVwNewodPerson.Appearance.EvenRow.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.EvenRow.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grdVwNewodPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdVwNewodPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grdVwNewodPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grdVwNewodPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grdVwNewodPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdVwNewodPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grdVwNewodPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grdVwNewodPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grdVwNewodPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grdVwNewodPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grdVwNewodPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grdVwNewodPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.GroupRow.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.grdVwNewodPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grdVwNewodPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grdVwNewodPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grdVwNewodPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grdVwNewodPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grdVwNewodPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdVwNewodPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grdVwNewodPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grdVwNewodPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grdVwNewodPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdVwNewodPerson.Appearance.OddRow.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grdVwNewodPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdVwNewodPerson.Appearance.Row.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.Row.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grdVwNewodPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grdVwNewodPerson.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grdVwNewodPerson.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grdVwNewodPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.grdVwNewodPerson.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grdVwNewodPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grdVwNewodPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.grdVwNewodPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grdVwNewodPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Vorname2,
            this.Nachname,
            this.AHVNummer,
            this.Geburtsdatum,
            this.Strasse,
            this.PLZ,
            this.Ort,
            this.NewodPersonVersichertennummer});
            this.grdVwNewodPerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grdVwNewodPerson.GridControl = this.grdNewodPerson;
            this.grdVwNewodPerson.Name = "grdVwNewodPerson";
            this.grdVwNewodPerson.OptionsBehavior.Editable = false;
            this.grdVwNewodPerson.OptionsCustomization.AllowFilter = false;
            this.grdVwNewodPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grdVwNewodPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.grdVwNewodPerson.OptionsNavigation.UseTabKey = false;
            this.grdVwNewodPerson.OptionsView.ColumnAutoWidth = false;
            this.grdVwNewodPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grdVwNewodPerson.OptionsView.ShowGroupPanel = false;
            this.grdVwNewodPerson.OptionsView.ShowIndicator = false;
            // 
            // Vorname2
            // 
            this.Vorname2.Caption = "Vorname";
            this.Vorname2.FieldName = "Vorname";
            this.Vorname2.Name = "Vorname2";
            this.Vorname2.Visible = true;
            this.Vorname2.VisibleIndex = 1;
            // 
            // Nachname
            // 
            this.Nachname.Caption = "Nachname";
            this.Nachname.FieldName = "Name";
            this.Nachname.Name = "Nachname";
            this.Nachname.Visible = true;
            this.Nachname.VisibleIndex = 0;
            // 
            // AHVNummer
            // 
            this.AHVNummer.Caption = "AHVNummer";
            this.AHVNummer.FieldName = "AHVNummer";
            this.AHVNummer.Name = "AHVNummer";
            this.AHVNummer.Visible = true;
            this.AHVNummer.VisibleIndex = 2;
            // 
            // Geburtsdatum
            // 
            this.Geburtsdatum.Caption = "Geburtsdatum";
            this.Geburtsdatum.FieldName = "Geburtsdatum";
            this.Geburtsdatum.Name = "Geburtsdatum";
            this.Geburtsdatum.Visible = true;
            this.Geburtsdatum.VisibleIndex = 3;
            // 
            // Strasse
            // 
            this.Strasse.Caption = "Strasse";
            this.Strasse.Name = "Strasse";
            this.Strasse.Visible = true;
            this.Strasse.VisibleIndex = 4;
            // 
            // PLZ
            // 
            this.PLZ.Caption = "PLZ";
            this.PLZ.FieldName = "PLZ";
            this.PLZ.Name = "PLZ";
            this.PLZ.Visible = true;
            this.PLZ.VisibleIndex = 5;
            // 
            // Ort
            // 
            this.Ort.Caption = "Ort";
            this.Ort.FieldName = "Ort";
            this.Ort.Name = "Ort";
            this.Ort.Visible = true;
            this.Ort.VisibleIndex = 6;
            // 
            // NewodPersonVersichertennummer
            // 
            this.NewodPersonVersichertennummer.Caption = "Versichertennummer";
            this.NewodPersonVersichertennummer.FieldName = "Versichertennummer";
            this.NewodPersonVersichertennummer.Name = "NewodPersonVersichertennummer";
            this.NewodPersonVersichertennummer.Visible = true;
            this.NewodPersonVersichertennummer.VisibleIndex = 7;
            // 
            // grdBaPerson
            // 
            this.grdBaPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBaPerson.DataSource = this.qryBaPerson;
            this.grdBaPerson.EmbeddedNavigator.Name = "";
            this.grdBaPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaPerson.Location = new System.Drawing.Point(3, 40);
            this.grdBaPerson.MainView = this.gridViewBaPerson;
            this.grdBaPerson.Name = "grdBaPerson";
            this.grdBaPerson.Size = new System.Drawing.Size(518, 327);
            this.grdBaPerson.TabIndex = 0;
            this.grdBaPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBaPerson});
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.BatchUpdate = true;
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.SelectStatement = resources.GetString("qryBaPerson.SelectStatement");
            this.qryBaPerson.TableName = "BaPerson";
            this.qryBaPerson.BeforePost += new System.EventHandler(this.qryBaPerson_BeforePost);
            this.qryBaPerson.PositionChanged += new System.EventHandler(this.qryBaPerson_PositionChanged);
            this.qryBaPerson.AfterFill += new System.EventHandler(this.qryBaPerson_AfterFill);
            // 
            // gridViewBaPerson
            // 
            this.gridViewBaPerson.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridViewBaPerson.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewBaPerson.Appearance.Empty.Options.UseBackColor = true;
            this.gridViewBaPerson.Appearance.Empty.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewBaPerson.Appearance.EvenRow.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridViewBaPerson.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewBaPerson.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridViewBaPerson.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridViewBaPerson.Appearance.FocusedCell.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridViewBaPerson.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridViewBaPerson.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewBaPerson.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridViewBaPerson.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridViewBaPerson.Appearance.FocusedRow.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridViewBaPerson.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridViewBaPerson.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridViewBaPerson.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridViewBaPerson.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridViewBaPerson.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridViewBaPerson.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridViewBaPerson.Appearance.GroupRow.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridViewBaPerson.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridViewBaPerson.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridViewBaPerson.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridViewBaPerson.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridViewBaPerson.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridViewBaPerson.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridViewBaPerson.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewBaPerson.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridViewBaPerson.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridViewBaPerson.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridViewBaPerson.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridViewBaPerson.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridViewBaPerson.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewBaPerson.Appearance.OddRow.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridViewBaPerson.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewBaPerson.Appearance.Row.Options.UseBackColor = true;
            this.gridViewBaPerson.Appearance.Row.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridViewBaPerson.Appearance.SelectedRow.Options.UseFont = true;
            this.gridViewBaPerson.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridViewBaPerson.Appearance.VertLine.Options.UseBackColor = true;
            this.gridViewBaPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridViewBaPerson.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.isMapped,
            this.BaPersonVorname,
            this.BaPersonNachname,
            this.BaPersonAHVNummer,
            this.BaPersonGeburtsdatum,
            this.BaPersonVersichertennummer});
            this.gridViewBaPerson.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridViewBaPerson.GridControl = this.grdBaPerson;
            this.gridViewBaPerson.Name = "gridViewBaPerson";
            this.gridViewBaPerson.OptionsBehavior.Editable = false;
            this.gridViewBaPerson.OptionsCustomization.AllowFilter = false;
            this.gridViewBaPerson.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridViewBaPerson.OptionsNavigation.AutoFocusNewRow = true;
            this.gridViewBaPerson.OptionsNavigation.UseTabKey = false;
            this.gridViewBaPerson.OptionsView.ColumnAutoWidth = false;
            this.gridViewBaPerson.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridViewBaPerson.OptionsView.ShowGroupPanel = false;
            this.gridViewBaPerson.OptionsView.ShowIndicator = false;
            this.gridViewBaPerson.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.gridViewBaPerson_CustomDrawCell);
            // 
            // isMapped
            // 
            this.isMapped.Caption = "isMapped";
            this.isMapped.FieldName = "isMapped";
            this.isMapped.Name = "isMapped";
            // 
            // BaPersonVorname
            // 
            this.BaPersonVorname.Caption = "Vorname";
            this.BaPersonVorname.FieldName = "Vorname";
            this.BaPersonVorname.Name = "BaPersonVorname";
            this.BaPersonVorname.Visible = true;
            this.BaPersonVorname.VisibleIndex = 1;
            // 
            // BaPersonNachname
            // 
            this.BaPersonNachname.Caption = "Nachname";
            this.BaPersonNachname.FieldName = "Name";
            this.BaPersonNachname.Name = "BaPersonNachname";
            this.BaPersonNachname.Visible = true;
            this.BaPersonNachname.VisibleIndex = 0;
            // 
            // BaPersonAHVNummer
            // 
            this.BaPersonAHVNummer.Caption = "AHVNummer";
            this.BaPersonAHVNummer.FieldName = "AHVNummer";
            this.BaPersonAHVNummer.Name = "BaPersonAHVNummer";
            this.BaPersonAHVNummer.Visible = true;
            this.BaPersonAHVNummer.VisibleIndex = 2;
            // 
            // BaPersonGeburtsdatum
            // 
            this.BaPersonGeburtsdatum.Caption = "Geburtsdatum";
            this.BaPersonGeburtsdatum.FieldName = "Geburtsdatum";
            this.BaPersonGeburtsdatum.Name = "BaPersonGeburtsdatum";
            this.BaPersonGeburtsdatum.Visible = true;
            this.BaPersonGeburtsdatum.VisibleIndex = 4;
            // 
            // BaPersonVersichertennummer
            // 
            this.BaPersonVersichertennummer.Caption = "Versichertennummer";
            this.BaPersonVersichertennummer.FieldName = "Versichertennummer";
            this.BaPersonVersichertennummer.Name = "BaPersonVersichertennummer";
            this.BaPersonVersichertennummer.Visible = true;
            this.BaPersonVersichertennummer.VisibleIndex = 3;
            // 
            // edtMappingKriterien
            // 
            this.edtMappingKriterien.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtMappingKriterien.Appearance.Options.UseBackColor = true;
            this.edtMappingKriterien.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtMappingKriterien.CheckOnClick = true;
            this.edtMappingKriterien.Location = new System.Drawing.Point(395, 13);
            this.edtMappingKriterien.LOVName = "NewodMappingKriterien";
            this.edtMappingKriterien.Name = "edtMappingKriterien";
            this.edtMappingKriterien.Size = new System.Drawing.Size(143, 178);
            this.edtMappingKriterien.TabIndex = 1;
            this.edtMappingKriterien.EditValueChanged += new System.EventHandler(this.ChkMappingKriterien_EditValueChanged);
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.edtMappingKriterien);
            this.panelAction.Controls.Add(this.edtConfirm);
            this.panelAction.Controls.Add(this.btnDoMapping);
            this.panelAction.Controls.Add(this.edtVersichertennummerNewodPerson);
            this.panelAction.Controls.Add(this.edtOrtNewodPerson);
            this.panelAction.Controls.Add(this.edtOrtBaPerson);
            this.panelAction.Controls.Add(this.edtPLZNewodPerson);
            this.panelAction.Controls.Add(this.edtPLZBaPerson);
            this.panelAction.Controls.Add(this.edtStrasseNewodPerson);
            this.panelAction.Controls.Add(this.edtStrasseBaPerson);
            this.panelAction.Controls.Add(this.edtVersichertennummerBaPerson);
            this.panelAction.Controls.Add(this.edtAHVNummerNewodPerson);
            this.panelAction.Controls.Add(this.edtAHVNummerBaPerson);
            this.panelAction.Controls.Add(this.edtVornameNewodPerson);
            this.panelAction.Controls.Add(this.edtVornameBaPerson);
            this.panelAction.Controls.Add(this.edtNameNewodPerson);
            this.panelAction.Controls.Add(this.edtNameBaPerson);
            this.panelAction.Controls.Add(this.edtGeburtsdatumBaPerson);
            this.panelAction.Controls.Add(this.edtGeburtsdatumNewodPerson);
            this.panelAction.Controls.Add(this.kissLabel2);
            this.panelAction.Controls.Add(this.lblPLZOrt);
            this.panelAction.Controls.Add(this.lblStrasseNewodPerson);
            this.panelAction.Controls.Add(this.lblStrasse);
            this.panelAction.Controls.Add(this.lblVersichertennummerNewodPerson);
            this.panelAction.Controls.Add(this.lblVersichertennummer);
            this.panelAction.Controls.Add(this.lblAHVNummerNewodPerson);
            this.panelAction.Controls.Add(this.lblAHVNummer);
            this.panelAction.Controls.Add(this.lblGeburtsdatumNewodPerson);
            this.panelAction.Controls.Add(this.lblGeburtsdatum);
            this.panelAction.Controls.Add(this.lblVornameNewodPerson);
            this.panelAction.Controls.Add(this.lblVorname);
            this.panelAction.Controls.Add(this.lblNameNewodPerson);
            this.panelAction.Controls.Add(this.lblName);
            this.panelAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelAction.Location = new System.Drawing.Point(0, 367);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(1000, 306);
            this.panelAction.TabIndex = 1;
            // 
            // edtConfirm
            // 
            this.edtConfirm.AutoSize = true;
            this.edtConfirm.Checked = true;
            this.edtConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.edtConfirm.Location = new System.Drawing.Point(408, 242);
            this.edtConfirm.Name = "edtConfirm";
            this.edtConfirm.Size = new System.Drawing.Size(130, 17);
            this.edtConfirm.TabIndex = 4;
            this.edtConfirm.Text = "Zuweisung bestätigen";
            this.edtConfirm.UseVisualStyleBackColor = true;
            // 
            // btnDoMapping
            // 
            this.btnDoMapping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoMapping.Location = new System.Drawing.Point(408, 211);
            this.btnDoMapping.Name = "btnDoMapping";
            this.btnDoMapping.Size = new System.Drawing.Size(90, 24);
            this.btnDoMapping.TabIndex = 3;
            this.btnDoMapping.Text = "Zuweisen";
            this.btnDoMapping.UseVisualStyleBackColor = true;
            this.btnDoMapping.Click += new System.EventHandler(this.btnDoMapping_Click);
            // 
            // edtVersichertennummerNewodPerson
            // 
            this.edtVersichertennummerNewodPerson.DataMember = "Versichertennummer";
            this.edtVersichertennummerNewodPerson.DataSource = this.qryNewodPerson;
            this.edtVersichertennummerNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersichertennummerNewodPerson.Location = new System.Drawing.Point(693, 138);
            this.edtVersichertennummerNewodPerson.Name = "edtVersichertennummerNewodPerson";
            this.edtVersichertennummerNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersichertennummerNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummerNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummerNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummerNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummerNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummerNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummerNewodPerson.Properties.ReadOnly = true;
            this.edtVersichertennummerNewodPerson.Size = new System.Drawing.Size(204, 24);
            this.edtVersichertennummerNewodPerson.TabIndex = 2;
            // 
            // edtOrtNewodPerson
            // 
            this.edtOrtNewodPerson.DataMember = "Ort";
            this.edtOrtNewodPerson.DataSource = this.qryNewodPerson;
            this.edtOrtNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOrtNewodPerson.Location = new System.Drawing.Point(767, 198);
            this.edtOrtNewodPerson.Name = "edtOrtNewodPerson";
            this.edtOrtNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOrtNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrtNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrtNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrtNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrtNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtOrtNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrtNewodPerson.Properties.ReadOnly = true;
            this.edtOrtNewodPerson.Size = new System.Drawing.Size(130, 24);
            this.edtOrtNewodPerson.TabIndex = 2;
            // 
            // edtOrtBaPerson
            // 
            this.edtOrtBaPerson.DataMember = "WohnsitzOrt";
            this.edtOrtBaPerson.DataSource = this.qryBaPerson;
            this.edtOrtBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOrtBaPerson.Location = new System.Drawing.Point(215, 197);
            this.edtOrtBaPerson.Name = "edtOrtBaPerson";
            this.edtOrtBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOrtBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrtBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrtBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrtBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrtBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtOrtBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrtBaPerson.Properties.ReadOnly = true;
            this.edtOrtBaPerson.Size = new System.Drawing.Size(130, 24);
            this.edtOrtBaPerson.TabIndex = 2;
            // 
            // edtPLZNewodPerson
            // 
            this.edtPLZNewodPerson.DataMember = "PLZ";
            this.edtPLZNewodPerson.DataSource = this.qryNewodPerson;
            this.edtPLZNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPLZNewodPerson.Location = new System.Drawing.Point(693, 198);
            this.edtPLZNewodPerson.Name = "edtPLZNewodPerson";
            this.edtPLZNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtPLZNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZNewodPerson.Properties.ReadOnly = true;
            this.edtPLZNewodPerson.Size = new System.Drawing.Size(68, 24);
            this.edtPLZNewodPerson.TabIndex = 2;
            // 
            // edtPLZBaPerson
            // 
            this.edtPLZBaPerson.DataMember = "WohnsitzPLZ";
            this.edtPLZBaPerson.DataSource = this.qryBaPerson;
            this.edtPLZBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPLZBaPerson.Location = new System.Drawing.Point(141, 197);
            this.edtPLZBaPerson.Name = "edtPLZBaPerson";
            this.edtPLZBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtPLZBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZBaPerson.Properties.ReadOnly = true;
            this.edtPLZBaPerson.Size = new System.Drawing.Size(68, 24);
            this.edtPLZBaPerson.TabIndex = 2;
            // 
            // edtStrasseNewodPerson
            // 
            this.edtStrasseNewodPerson.DataMember = "Strasse";
            this.edtStrasseNewodPerson.DataSource = this.qryNewodPerson;
            this.edtStrasseNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseNewodPerson.Location = new System.Drawing.Point(693, 168);
            this.edtStrasseNewodPerson.Name = "edtStrasseNewodPerson";
            this.edtStrasseNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasseNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseNewodPerson.Properties.ReadOnly = true;
            this.edtStrasseNewodPerson.Size = new System.Drawing.Size(204, 24);
            this.edtStrasseNewodPerson.TabIndex = 2;
            // 
            // edtStrasseBaPerson
            // 
            this.edtStrasseBaPerson.DataMember = "WohnsitzStrasse";
            this.edtStrasseBaPerson.DataSource = this.qryBaPerson;
            this.edtStrasseBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseBaPerson.Location = new System.Drawing.Point(141, 167);
            this.edtStrasseBaPerson.Name = "edtStrasseBaPerson";
            this.edtStrasseBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasseBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseBaPerson.Properties.ReadOnly = true;
            this.edtStrasseBaPerson.Size = new System.Drawing.Size(204, 24);
            this.edtStrasseBaPerson.TabIndex = 2;
            // 
            // edtVersichertennummerBaPerson
            // 
            this.edtVersichertennummerBaPerson.DataMember = "Versichertennummer";
            this.edtVersichertennummerBaPerson.DataSource = this.qryBaPerson;
            this.edtVersichertennummerBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersichertennummerBaPerson.Location = new System.Drawing.Point(141, 137);
            this.edtVersichertennummerBaPerson.Name = "edtVersichertennummerBaPerson";
            this.edtVersichertennummerBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersichertennummerBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummerBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummerBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummerBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummerBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummerBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummerBaPerson.Properties.ReadOnly = true;
            this.edtVersichertennummerBaPerson.Size = new System.Drawing.Size(204, 24);
            this.edtVersichertennummerBaPerson.TabIndex = 2;
            // 
            // edtAHVNummerNewodPerson
            // 
            this.edtAHVNummerNewodPerson.DataMember = "AHVNummer";
            this.edtAHVNummerNewodPerson.DataSource = this.qryNewodPerson;
            this.edtAHVNummerNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAHVNummerNewodPerson.Location = new System.Drawing.Point(693, 108);
            this.edtAHVNummerNewodPerson.Name = "edtAHVNummerNewodPerson";
            this.edtAHVNummerNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAHVNummerNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummerNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummerNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummerNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummerNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummerNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummerNewodPerson.Properties.ReadOnly = true;
            this.edtAHVNummerNewodPerson.Size = new System.Drawing.Size(204, 24);
            this.edtAHVNummerNewodPerson.TabIndex = 2;
            // 
            // edtAHVNummerBaPerson
            // 
            this.edtAHVNummerBaPerson.DataMember = "AHVNummer";
            this.edtAHVNummerBaPerson.DataSource = this.qryBaPerson;
            this.edtAHVNummerBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAHVNummerBaPerson.Location = new System.Drawing.Point(141, 107);
            this.edtAHVNummerBaPerson.Name = "edtAHVNummerBaPerson";
            this.edtAHVNummerBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAHVNummerBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummerBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummerBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummerBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummerBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummerBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummerBaPerson.Properties.ReadOnly = true;
            this.edtAHVNummerBaPerson.Size = new System.Drawing.Size(204, 24);
            this.edtAHVNummerBaPerson.TabIndex = 2;
            // 
            // edtVornameNewodPerson
            // 
            this.edtVornameNewodPerson.DataMember = "Vorname";
            this.edtVornameNewodPerson.DataSource = this.qryNewodPerson;
            this.edtVornameNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVornameNewodPerson.Location = new System.Drawing.Point(693, 48);
            this.edtVornameNewodPerson.Name = "edtVornameNewodPerson";
            this.edtVornameNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVornameNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVornameNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVornameNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtVornameNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVornameNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtVornameNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVornameNewodPerson.Properties.ReadOnly = true;
            this.edtVornameNewodPerson.Size = new System.Drawing.Size(204, 24);
            this.edtVornameNewodPerson.TabIndex = 2;
            // 
            // edtVornameBaPerson
            // 
            this.edtVornameBaPerson.DataMember = "Vorname";
            this.edtVornameBaPerson.DataSource = this.qryBaPerson;
            this.edtVornameBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVornameBaPerson.Location = new System.Drawing.Point(141, 47);
            this.edtVornameBaPerson.Name = "edtVornameBaPerson";
            this.edtVornameBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVornameBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVornameBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVornameBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtVornameBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVornameBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtVornameBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVornameBaPerson.Properties.ReadOnly = true;
            this.edtVornameBaPerson.Size = new System.Drawing.Size(204, 24);
            this.edtVornameBaPerson.TabIndex = 2;
            // 
            // edtNameNewodPerson
            // 
            this.edtNameNewodPerson.DataMember = "Name";
            this.edtNameNewodPerson.DataSource = this.qryNewodPerson;
            this.edtNameNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameNewodPerson.Location = new System.Drawing.Point(693, 18);
            this.edtNameNewodPerson.Name = "edtNameNewodPerson";
            this.edtNameNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtNameNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameNewodPerson.Properties.ReadOnly = true;
            this.edtNameNewodPerson.Size = new System.Drawing.Size(204, 24);
            this.edtNameNewodPerson.TabIndex = 2;
            // 
            // edtNameBaPerson
            // 
            this.edtNameBaPerson.DataMember = "Name";
            this.edtNameBaPerson.DataSource = this.qryBaPerson;
            this.edtNameBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameBaPerson.Location = new System.Drawing.Point(141, 17);
            this.edtNameBaPerson.Name = "edtNameBaPerson";
            this.edtNameBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNameBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtNameBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNameBaPerson.Properties.ReadOnly = true;
            this.edtNameBaPerson.Size = new System.Drawing.Size(204, 24);
            this.edtNameBaPerson.TabIndex = 2;
            // 
            // edtGeburtsdatumBaPerson
            // 
            this.edtGeburtsdatumBaPerson.DataMember = "Geburtsdatum";
            this.edtGeburtsdatumBaPerson.DataSource = this.qryBaPerson;
            this.edtGeburtsdatumBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtsdatumBaPerson.EditValue = null;
            this.edtGeburtsdatumBaPerson.Location = new System.Drawing.Point(141, 77);
            this.edtGeburtsdatumBaPerson.Name = "edtGeburtsdatumBaPerson";
            this.edtGeburtsdatumBaPerson.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatumBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtsdatumBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatumBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatumBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatumBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatumBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatumBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeburtsdatumBaPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatumBaPerson.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeburtsdatumBaPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatumBaPerson.Properties.ReadOnly = true;
            this.edtGeburtsdatumBaPerson.Properties.ShowToday = false;
            this.edtGeburtsdatumBaPerson.Size = new System.Drawing.Size(89, 24);
            this.edtGeburtsdatumBaPerson.TabIndex = 1;
            // 
            // edtGeburtsdatumNewodPerson
            // 
            this.edtGeburtsdatumNewodPerson.DataMember = "Geburtsdatum";
            this.edtGeburtsdatumNewodPerson.DataSource = this.qryNewodPerson;
            this.edtGeburtsdatumNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtsdatumNewodPerson.EditValue = null;
            this.edtGeburtsdatumNewodPerson.Location = new System.Drawing.Point(693, 77);
            this.edtGeburtsdatumNewodPerson.Name = "edtGeburtsdatumNewodPerson";
            this.edtGeburtsdatumNewodPerson.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatumNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGeburtsdatumNewodPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatumNewodPerson.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGeburtsdatumNewodPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatumNewodPerson.Properties.ReadOnly = true;
            this.edtGeburtsdatumNewodPerson.Properties.ShowToday = false;
            this.edtGeburtsdatumNewodPerson.Size = new System.Drawing.Size(92, 24);
            this.edtGeburtsdatumNewodPerson.TabIndex = 1;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(563, 198);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(116, 24);
            this.kissLabel2.TabIndex = 0;
            this.kissLabel2.Text = "PLZ / Ort";
            // 
            // lblPLZOrt
            // 
            this.lblPLZOrt.Location = new System.Drawing.Point(19, 197);
            this.lblPLZOrt.Name = "lblPLZOrt";
            this.lblPLZOrt.Size = new System.Drawing.Size(116, 24);
            this.lblPLZOrt.TabIndex = 0;
            this.lblPLZOrt.Text = "PLZ / Ort";
            // 
            // lblStrasseNewodPerson
            // 
            this.lblStrasseNewodPerson.Location = new System.Drawing.Point(563, 168);
            this.lblStrasseNewodPerson.Name = "lblStrasseNewodPerson";
            this.lblStrasseNewodPerson.Size = new System.Drawing.Size(116, 24);
            this.lblStrasseNewodPerson.TabIndex = 0;
            this.lblStrasseNewodPerson.Text = "Strasse";
            // 
            // lblStrasse
            // 
            this.lblStrasse.Location = new System.Drawing.Point(19, 164);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(116, 24);
            this.lblStrasse.TabIndex = 0;
            this.lblStrasse.Text = "Strasse";
            // 
            // lblVersichertennummerNewodPerson
            // 
            this.lblVersichertennummerNewodPerson.Location = new System.Drawing.Point(563, 134);
            this.lblVersichertennummerNewodPerson.Name = "lblVersichertennummerNewodPerson";
            this.lblVersichertennummerNewodPerson.Size = new System.Drawing.Size(124, 24);
            this.lblVersichertennummerNewodPerson.TabIndex = 0;
            this.lblVersichertennummerNewodPerson.Text = "Versichertennummer";
            // 
            // lblVersichertennummer
            // 
            this.lblVersichertennummer.Location = new System.Drawing.Point(18, 134);
            this.lblVersichertennummer.Name = "lblVersichertennummer";
            this.lblVersichertennummer.Size = new System.Drawing.Size(117, 24);
            this.lblVersichertennummer.TabIndex = 0;
            this.lblVersichertennummer.Text = "Versichertennummer";
            // 
            // lblAHVNummerNewodPerson
            // 
            this.lblAHVNummerNewodPerson.Location = new System.Drawing.Point(563, 107);
            this.lblAHVNummerNewodPerson.Name = "lblAHVNummerNewodPerson";
            this.lblAHVNummerNewodPerson.Size = new System.Drawing.Size(149, 24);
            this.lblAHVNummerNewodPerson.TabIndex = 0;
            this.lblAHVNummerNewodPerson.Text = "AHVNummer";
            // 
            // lblAHVNummer
            // 
            this.lblAHVNummer.Location = new System.Drawing.Point(18, 107);
            this.lblAHVNummer.Name = "lblAHVNummer";
            this.lblAHVNummer.Size = new System.Drawing.Size(149, 24);
            this.lblAHVNummer.TabIndex = 0;
            this.lblAHVNummer.Text = "AHVNummer";
            // 
            // lblGeburtsdatumNewodPerson
            // 
            this.lblGeburtsdatumNewodPerson.Location = new System.Drawing.Point(563, 77);
            this.lblGeburtsdatumNewodPerson.Name = "lblGeburtsdatumNewodPerson";
            this.lblGeburtsdatumNewodPerson.Size = new System.Drawing.Size(165, 24);
            this.lblGeburtsdatumNewodPerson.TabIndex = 0;
            this.lblGeburtsdatumNewodPerson.Text = "Geburtsdatum";
            // 
            // lblGeburtsdatum
            // 
            this.lblGeburtsdatum.Location = new System.Drawing.Point(19, 77);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(110, 24);
            this.lblGeburtsdatum.TabIndex = 0;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            // 
            // lblVornameNewodPerson
            // 
            this.lblVornameNewodPerson.Location = new System.Drawing.Point(563, 48);
            this.lblVornameNewodPerson.Name = "lblVornameNewodPerson";
            this.lblVornameNewodPerson.Size = new System.Drawing.Size(100, 23);
            this.lblVornameNewodPerson.TabIndex = 0;
            this.lblVornameNewodPerson.Text = "Vorname";
            // 
            // lblVorname
            // 
            this.lblVorname.Location = new System.Drawing.Point(19, 48);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(100, 23);
            this.lblVorname.TabIndex = 0;
            this.lblVorname.Text = "Vorname";
            // 
            // lblNameNewodPerson
            // 
            this.lblNameNewodPerson.Location = new System.Drawing.Point(563, 17);
            this.lblNameNewodPerson.Name = "lblNameNewodPerson";
            this.lblNameNewodPerson.Size = new System.Drawing.Size(100, 23);
            this.lblNameNewodPerson.TabIndex = 0;
            this.lblNameNewodPerson.Text = "Name";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(19, 17);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // CtlKiSSNewodMapping
            // 
            this.ActiveSQLQuery = this.qryNewodPerson;
            this.AllowDrop = true;
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelAction);
            this.Name = "CtlKiSSNewodMapping";
            this.Size = new System.Drawing.Size(1000, 673);
            this.Enter += new System.EventHandler(this.CtlKiSSNewodMapping_Enter);
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMappingKriterien)).EndInit();
            this.panelAction.ResumeLayout(false);
            this.panelAction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummerNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummerBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummerNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummerBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatumNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasseNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertennummerNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersichertennummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummerNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatumNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornameNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            this.ResumeLayout(false);

        }

        private int BaPersonRowCount;

        public void Init()
        {
            Cursor.Current = Cursors.WaitCursor;
            edtMappingKriterien.EditValue = "1";
            qryNewodPerson.Fill();
            qryBaPerson.Fill();
            BaPersonRowCount = qryBaPerson.Count;
            Cursor.Current = Cursors.Default;

        }

        private void qryBaPerson_PositionChanged(object sender, EventArgs e)
        {
            if (this.CheckMatchingKriterien())
            {
                this.LookupNewodPersons();
                this.CompareFieldValues();
            }
        }

        private void qryNewodPerson_PositionChanged(object sender, EventArgs e)
        {
            this.CompareFieldValues();
        }

        private void CompareFieldValues()
        {

            edtNameBaPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtNameNewodPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtVornameBaPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtVornameNewodPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtVornameBaPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtVornameNewodPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtGeburtsdatumBaPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtGeburtsdatumNewodPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtAHVNummerBaPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtAHVNummerNewodPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtVersichertennummerBaPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtVersichertennummerNewodPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtStrasseBaPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231); 
            edtStrasseNewodPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtPLZBaPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231); 
            edtPLZNewodPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);
            edtOrtBaPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231); 
            edtOrtNewodPerson.BackColor = System.Drawing.Color.FromArgb(247, 239, 231);

            if (qryNewodPerson.Count != 0 && qryBaPerson.Count != 0)
            {
                if (!edtNameBaPerson.EditValue.Equals(edtNameNewodPerson.EditValue))
                {
                    edtNameBaPerson.BackColor = System.Drawing.Color.Red;
                    edtNameNewodPerson.BackColor = System.Drawing.Color.Red;
                }

                if (!edtVornameBaPerson.EditValue.Equals(edtVornameNewodPerson.EditValue))
                {
                    edtVornameBaPerson.BackColor = System.Drawing.Color.Red;
                    edtVornameNewodPerson.BackColor = System.Drawing.Color.Red;
                }

                if (!edtGeburtsdatumBaPerson.EditValue.Equals(edtGeburtsdatumNewodPerson.EditValue))
                {
                    edtGeburtsdatumBaPerson.BackColor = System.Drawing.Color.Red;
                    edtGeburtsdatumNewodPerson.BackColor = System.Drawing.Color.Red;
                }

                if (!edtAHVNummerBaPerson.EditValue.Equals(edtAHVNummerNewodPerson.EditValue))
                {
                    edtAHVNummerBaPerson.BackColor = System.Drawing.Color.Red;
                    edtAHVNummerNewodPerson.BackColor = System.Drawing.Color.Red;
                }

                if (!edtVersichertennummerBaPerson.EditValue.Equals(edtVersichertennummerNewodPerson.EditValue))
                {
                    edtVersichertennummerBaPerson.BackColor = System.Drawing.Color.Red;
                    edtVersichertennummerNewodPerson.BackColor = System.Drawing.Color.Red;
                }

                if (!edtStrasseBaPerson.EditValue.Equals(edtStrasseNewodPerson.EditValue))
                {
                    edtStrasseBaPerson.BackColor = System.Drawing.Color.Red;
                    edtStrasseNewodPerson.BackColor = System.Drawing.Color.Red;
                }

                if (!edtPLZBaPerson.EditValue.Equals(edtPLZNewodPerson.EditValue))
                {
                    edtPLZBaPerson.BackColor = System.Drawing.Color.Red;
                    edtPLZNewodPerson.BackColor = System.Drawing.Color.Red;
                }

                if (!edtOrtBaPerson.EditValue.Equals(edtOrtNewodPerson.EditValue))
                {
                    edtOrtBaPerson.BackColor = System.Drawing.Color.Red;
                    edtOrtNewodPerson.BackColor = System.Drawing.Color.Red;
                }
            }
        }

        private bool CheckMatchingKriterien()
        {

            if (edtMappingKriterien.EditValue == null || edtMappingKriterien.EditValue.Equals(""))
            {
                KissMsg.ShowInfo("Wählen Sie mindestens ein Kriterium aus.");
                return false;
            }

            return true;
        }

        private void LookupNewodPersons()
        {
            String sqlNewodPerson = String.Format(@"
            SELECT 
	            NewodPersonID,
	            Vorname,
	            Name,
	            AHVNummer,
	            Versichertennummer,
	            Geburtsdatum,
	            Strasse,
	            HausNr,
	            HausNrZusatz,
	            PLZ,
	            Ort 
            FROM  
                dbo.NewodPerson 
            WHERE 
                NewodPersonID NOT IN 
                    (SELECT NewodPersonID FROM dbo.BaPerson_NewodPerson) ");

            String selectedItems = edtMappingKriterien.EditValue;
            
            if (selectedItems != null && !selectedItems.Equals(""))
            {
                // file pattern is defined, try to split if multiple patterns are given
                String[] checkedValues = selectedItems.Split(',');

                // loop foreach single search pattern
                foreach (String val in checkedValues)
                {
                    switch (val)
                    {
                        case "1":
                            sqlNewodPerson += " AND AHVNummer = " + DBUtil.SqlLiteral(qryBaPerson["AHVNummer"]);
                            break;
                        case "2":

                            String PartAHVNummer = qryBaPerson["PartAHVNummer"].ToString();

                            if (PartAHVNummer == null || PartAHVNummer.Equals(""))
                            {
                                PartAHVNummer = "---";
                            }

                            sqlNewodPerson += " AND AHVNummer like '" + PartAHVNummer + "%'";
                            break;
                        case "3":
                            sqlNewodPerson += " AND Name = " + DBUtil.SqlLiteral(qryBaPerson["Name"]);
                            break;
                        case "4":
                            sqlNewodPerson += " AND Vorname = " + DBUtil.SqlLiteral(qryBaPerson["Vorname"]);
                            break;
                        case "5":
                            sqlNewodPerson += " AND Versichertennummer = '" + qryBaPerson["Versichertennummer"] + "'";
                            break;
                        case "6":
                            sqlNewodPerson += " AND Strasse = " + DBUtil.SqlLiteral(qryBaPerson["WohnsitzStrasse"]);
                            break;
                        case "7":
                            sqlNewodPerson += " AND Geburtsdatum = convert(datetime,'" + qryBaPerson["Geburtsdatum"] + "',104)";
                            break;
                        case "8":
                            sqlNewodPerson += " AND PLZ = " + DBUtil.SqlLiteral(qryBaPerson["WohnsitzPLZ"]);
                            break;
                        case "9":
                            sqlNewodPerson += " AND Ort = " + DBUtil.SqlLiteral(qryBaPerson["WohnsitzOrt"]);
                            break;
                    }
                }
            }

            String sqlOrderBy = " ORDER BY Name asc, Vorname asc";
            qryNewodPerson.Fill(sqlNewodPerson + sqlOrderBy);
        }

        private void ChkMappingKriterien_EditValueChanged(object sender, EventArgs e)
        {
            if (this.CheckMatchingKriterien())
            {
                this.LookupNewodPersons();
            }

        }

        private void btnDoMapping_Click(object sender, EventArgs e)
        {
            if (qryBaPerson["BaPersonID"] != null && qryNewodPerson["NewodPersonID"] != null)
            {

                String sqlMapping = String.Format(@"
                INSERT INTO 
                    BaPerson_NewodPerson (BaPersonID,NewodPersonID) 
                VALUES ({0},{1})", qryBaPerson["BaPersonID"], qryNewodPerson["NewodPersonID"]);

                bool continueAction = true;

                if (edtConfirm.Checked) 
                {
                    continueAction = KissMsg.ShowQuestion("Wollen Sie das Mapping herstellen?");
                }

                if (continueAction)
                {
                    try
                    {
                        DB.DBUtil.ExecSQLThrowingException(sqlMapping);
                        qryBaPerson["isMapped"] = true;
                        qryBaPerson.RowModified = false;
                        qryBaPerson.Row.AcceptChanges();
                        qryBaPerson.Next();
                    }
                    catch (Exception ex)
                    {
                        // Eintrag ins Log.
                        LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                        // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                        XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                        KissMsg.ShowInfo("Fehler beim Erstellen des Mappings");
                    }
                    finally
                    {
                        qryNewodPerson.Refresh();

                    }
                }
            }
            else
            {
                KissMsg.ShowInfo("Bitte wählen auf beiden Seiten eine Person aus.");
            }

            grdBaPerson.Select();
        }



        private void gridViewBaPerson_CustomDrawCell(Object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            try
            {
                int isMapped = (int)gridViewBaPerson.GetRowCellValue(e.RowHandle, gridViewBaPerson.Columns["isMapped"]);

                if (isMapped == 1) {   
                    e.Appearance.BackColor = System.Drawing.Color.Red;
                }
                   
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);
            }
        }

        private void qryBaPerson_BeforePost(object sender, EventArgs e)
        {

        }

        private void CtlKiSSNewodMapping_Enter(object sender, EventArgs e)
        {
            Init();
        }

        private void InitEnd()
        {
        }

        private void qryBaPerson_AfterFill(object sender, EventArgs e)
        {
            lblCount.Text = "Anzahl Datensätze: " + qryBaPerson.Count;
        }


    }
}
