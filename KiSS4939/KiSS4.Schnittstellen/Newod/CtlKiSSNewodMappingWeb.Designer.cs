using System.Windows.Forms;
using KiSS4.Gui;
using KiSS4.Schnittstellen.Newod.DTO;
using KiSS4.Schnittstellen.Newod.Service;

namespace KiSS4.Schnittstellen.Newod
{
    public partial class CtlKiSSNewodMappingWeb
    {
        #region Windows Form Designer generated code
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonNachname;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonVorname;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonWohnsitzHausNr;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonWohnsitzOrt;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonWohnsitzPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn BaPersonWohnsitzStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonName;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonNewodNummer;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonOrt;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonVersichertennummer;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonVorname;
        private PersonSearchCriteria _criteria;
        private Person _selKissPerson;
        private Person _selNewodPerson;
        private KissButton btnDoMapping;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatumBaPerson;
        private KiSS4.Gui.KissDateEdit edtGeburtsdatumNewodPerson;
        private KissTextEdit edtHausNrBaPerson;
        private KissTextEdit edtHausNrNewodPerson;
        private KissTextEdit edtIDBaPerson;
        private KissTextEdit edtIDNewodPerson;
        private KiSS4.Gui.KissCheckedLookupEdit edtMappingKriterien;
        private KiSS4.Gui.KissTextEdit edtNameBaPerson;
        private KiSS4.Gui.KissTextEdit edtNameNewodPerson;
        private KissTextEdit edtOrtBaPerson;
        private KissTextEdit edtOrtNewodPerson;
        private KissTextEdit edtPLZBaPerson;
        private KissTextEdit edtPLZNewodPerson;
        private KissTextEdit edtStrasseBaPerson;
        private KissTextEdit edtStrasseNewodPerson;
        private KiSS4.Gui.KissTextEdit edtVornameBaPerson;
        private KiSS4.Gui.KissTextEdit edtVornameNewodPerson;
        private KiSS4.Gui.KissGrid grdBaPerson;
        private KiSS4.Gui.KissGrid grdNewodPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView grdVwNewodPerson;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBaPerson;
        private KissLabel kissLabel1;
        private KissLabel kissLabel2;
        private KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel lblAHVNummer;
        private KiSS4.Gui.KissLabel lblAHVNummerNewodPerson;
        private Label lblCount;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblGeburtsdatumNewodPerson;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblNameNewodPerson;
        private KissLabel lblPLZOrt;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KissLabel lblStrasseNewodPerson;
        private KiSS4.Gui.KissLabel lblVersichertennummer;
        private KiSS4.Gui.KissLabel lblVersichertennummerNewodPerson;
        private KiSS4.Gui.KissLabel lblVorname;
        private KiSS4.Gui.KissLabel lblVornameNewodPerson;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Panel panelGrid;
        private Panel panel1;
        private KissButton btnCancel;
        private PersonService _svcPerson = new PersonService();
        private BindingSource NewodPersonBindingSource;
        private BindingSource KissPersonBindingSource;
        private KissButton btnDoSearch;
        private KissVersichertenNrEdit edtVersichertennummerNewodPerson;
        private KissVersichertenNrEdit edtVersichertennummerBaPerson;
        private KissTextEdit kissTextEdit1;
        private KissAHVNrEdit edtAHVNummerBaPerson;
        private KissAHVNrEdit edtAHVNummerNewodPerson;
        private DevExpress.XtraGrid.Columns.GridColumn NewodPersonHausNr;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKiSSNewodMappingWeb));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelGrid = new System.Windows.Forms.Panel();
            this.lblCount = new System.Windows.Forms.Label();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.grdNewodPerson = new KiSS4.Gui.KissGrid();
            this.grdVwNewodPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.NewodPersonNewodNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.NewodPersonHausNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdBaPerson = new KiSS4.Gui.KissGrid();
            this.gridViewBaPerson = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.BaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonNachname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonVersichertennummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonWohnsitzStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonWohnsitzHausNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonWohnsitzPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.BaPersonWohnsitzOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtMappingKriterien = new KiSS4.Gui.KissCheckedLookupEdit();
            this.panelAction = new System.Windows.Forms.Panel();
            this.edtAHVNummerNewodPerson = new KiSS4.Gui.KissAHVNrEdit();
            this.edtAHVNummerBaPerson = new KiSS4.Gui.KissAHVNrEdit();
            this.edtVersichertennummerNewodPerson = new KiSS4.Gui.KissVersichertenNrEdit();
            this.edtVersichertennummerBaPerson = new KiSS4.Gui.KissVersichertenNrEdit();
            this.btnDoSearch = new KiSS4.Gui.KissButton();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.edtOrtNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.NewodPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.edtOrtBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtPLZNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtPLZBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtStrasseNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtHausNrNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtHausNrBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtStrasseBaPerson = new KiSS4.Gui.KissTextEdit();
            this.edtVornameNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtVornameBaPerson = new KiSS4.Gui.KissTextEdit();
            this.KissPersonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.edtNameNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtIDNewodPerson = new KiSS4.Gui.KissTextEdit();
            this.edtIDBaPerson = new KiSS4.Gui.KissTextEdit();
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
            this.btnDoMapping = new KiSS4.Gui.KissButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.panelGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwNewodPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMappingKriterien)).BeginInit();
            this.panelAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummerNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummerBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummerNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummerBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewodPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNrNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNrBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameBaPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KissPersonBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDNewodPerson.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDBaPerson.Properties)).BeginInit();
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGrid
            // 
            this.panelGrid.Controls.Add(this.lblCount);
            this.panelGrid.Controls.Add(this.kissLabel3);
            this.panelGrid.Controls.Add(this.kissLabel1);
            this.panelGrid.Controls.Add(this.grdNewodPerson);
            this.panelGrid.Controls.Add(this.grdBaPerson);
            this.panelGrid.Location = new System.Drawing.Point(0, 0);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(926, 293);
            this.panelGrid.TabIndex = 0;
            this.panelGrid.Tag = "";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(214, 18);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(99, 13);
            this.lblCount.TabIndex = 3;
            this.lblCount.Text = "Anzahl Datensätze:";
            // 
            // kissLabel3
            // 
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.kissLabel3.Location = new System.Drawing.Point(453, 10);
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
            this.grdNewodPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdNewodPerson.EmbeddedNavigator.Name = "";
            this.grdNewodPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdNewodPerson.Location = new System.Drawing.Point(468, 40);
            this.grdNewodPerson.MainView = this.grdVwNewodPerson;
            this.grdNewodPerson.Name = "grdNewodPerson";
            this.grdNewodPerson.Size = new System.Drawing.Size(442, 253);
            this.grdNewodPerson.TabIndex = 0;
            this.grdNewodPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdVwNewodPerson});
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
            this.NewodPersonNewodNummer,
            this.NewodPersonVorname,
            this.NewodPersonName,
            this.NewodPersonAHVNummer,
            this.NewodPersonVersichertennummer,
            this.NewodPersonGeburtsdatum,
            this.NewodPersonStrasse,
            this.NewodPersonPLZ,
            this.NewodPersonOrt,
            this.NewodPersonHausNr});
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
            this.grdVwNewodPerson.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdVwNewodPerson_FocusedRowChanged);
            // 
            // NewodPersonNewodNummer
            // 
            this.NewodPersonNewodNummer.Caption = "NewodNummer";
            this.NewodPersonNewodNummer.FieldName = "ID";
            this.NewodPersonNewodNummer.Name = "NewodPersonNewodNummer";
            this.NewodPersonNewodNummer.Visible = true;
            this.NewodPersonNewodNummer.VisibleIndex = 0;
            // 
            // NewodPersonVorname
            // 
            this.NewodPersonVorname.Caption = "Vorname";
            this.NewodPersonVorname.FieldName = "Vorname";
            this.NewodPersonVorname.Name = "NewodPersonVorname";
            this.NewodPersonVorname.Visible = true;
            this.NewodPersonVorname.VisibleIndex = 2;
            // 
            // NewodPersonName
            // 
            this.NewodPersonName.Caption = "Nachname";
            this.NewodPersonName.FieldName = "Name";
            this.NewodPersonName.Name = "NewodPersonName";
            this.NewodPersonName.Visible = true;
            this.NewodPersonName.VisibleIndex = 1;
            // 
            // NewodPersonAHVNummer
            // 
            this.NewodPersonAHVNummer.Caption = "AHVNummer";
            this.NewodPersonAHVNummer.FieldName = "AHVNummer";
            this.NewodPersonAHVNummer.Name = "NewodPersonAHVNummer";
            this.NewodPersonAHVNummer.Visible = true;
            this.NewodPersonAHVNummer.VisibleIndex = 3;
            // 
            // NewodPersonVersichertennummer
            // 
            this.NewodPersonVersichertennummer.Caption = "Versichertennummer";
            this.NewodPersonVersichertennummer.FieldName = "Versichertennummer";
            this.NewodPersonVersichertennummer.Name = "NewodPersonVersichertennummer";
            this.NewodPersonVersichertennummer.Visible = true;
            this.NewodPersonVersichertennummer.VisibleIndex = 4;
            // 
            // NewodPersonGeburtsdatum
            // 
            this.NewodPersonGeburtsdatum.Caption = "Geburtsdatum";
            this.NewodPersonGeburtsdatum.FieldName = "Geburtsdatum";
            this.NewodPersonGeburtsdatum.Name = "NewodPersonGeburtsdatum";
            this.NewodPersonGeburtsdatum.Visible = true;
            this.NewodPersonGeburtsdatum.VisibleIndex = 5;
            // 
            // NewodPersonStrasse
            // 
            this.NewodPersonStrasse.Caption = "Strasse";
            this.NewodPersonStrasse.FieldName = "Strasse";
            this.NewodPersonStrasse.Name = "NewodPersonStrasse";
            this.NewodPersonStrasse.Visible = true;
            this.NewodPersonStrasse.VisibleIndex = 6;
            // 
            // NewodPersonPLZ
            // 
            this.NewodPersonPLZ.Caption = "PLZ";
            this.NewodPersonPLZ.FieldName = "Plz";
            this.NewodPersonPLZ.Name = "NewodPersonPLZ";
            this.NewodPersonPLZ.Visible = true;
            this.NewodPersonPLZ.VisibleIndex = 7;
            // 
            // NewodPersonOrt
            // 
            this.NewodPersonOrt.Caption = "Ort";
            this.NewodPersonOrt.FieldName = "Ort";
            this.NewodPersonOrt.Name = "NewodPersonOrt";
            this.NewodPersonOrt.Visible = true;
            this.NewodPersonOrt.VisibleIndex = 8;
            // 
            // NewodPersonHausNr
            // 
            this.NewodPersonHausNr.Caption = "HausNr";
            this.NewodPersonHausNr.FieldName = "HausNr";
            this.NewodPersonHausNr.Name = "NewodPersonHausNr";
            this.NewodPersonHausNr.Visible = true;
            this.NewodPersonHausNr.VisibleIndex = 9;
            // 
            // grdBaPerson
            // 
            this.grdBaPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdBaPerson.EmbeddedNavigator.Name = "";
            this.grdBaPerson.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaPerson.Location = new System.Drawing.Point(11, 40);
            this.grdBaPerson.MainView = this.gridViewBaPerson;
            this.grdBaPerson.Name = "grdBaPerson";
            this.grdBaPerson.Size = new System.Drawing.Size(447, 253);
            this.grdBaPerson.TabIndex = 0;
            this.grdBaPerson.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBaPerson});
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
            this.BaPersonID,
            this.BaPersonVorname,
            this.BaPersonNachname,
            this.BaPersonAHVNummer,
            this.BaPersonGeburtsdatum,
            this.BaPersonVersichertennummer,
            this.BaPersonWohnsitzStrasse,
            this.BaPersonWohnsitzHausNr,
            this.BaPersonWohnsitzPLZ,
            this.BaPersonWohnsitzOrt});
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
            // 
            // BaPersonID
            // 
            this.BaPersonID.Caption = "BaPersonID";
            this.BaPersonID.FieldName = "ID";
            this.BaPersonID.Name = "BaPersonID";
            this.BaPersonID.Visible = true;
            this.BaPersonID.VisibleIndex = 0;
            // 
            // BaPersonVorname
            // 
            this.BaPersonVorname.Caption = "Vorname";
            this.BaPersonVorname.FieldName = "Vorname";
            this.BaPersonVorname.Name = "BaPersonVorname";
            this.BaPersonVorname.Visible = true;
            this.BaPersonVorname.VisibleIndex = 2;
            // 
            // BaPersonNachname
            // 
            this.BaPersonNachname.Caption = "Nachname";
            this.BaPersonNachname.FieldName = "Name";
            this.BaPersonNachname.Name = "BaPersonNachname";
            this.BaPersonNachname.Visible = true;
            this.BaPersonNachname.VisibleIndex = 1;
            // 
            // BaPersonAHVNummer
            // 
            this.BaPersonAHVNummer.Caption = "AHVNummer";
            this.BaPersonAHVNummer.FieldName = "AHVNummer";
            this.BaPersonAHVNummer.Name = "BaPersonAHVNummer";
            this.BaPersonAHVNummer.Visible = true;
            this.BaPersonAHVNummer.VisibleIndex = 3;
            this.BaPersonAHVNummer.Width = 92;
            // 
            // BaPersonGeburtsdatum
            // 
            this.BaPersonGeburtsdatum.Caption = "Geburtsdatum";
            this.BaPersonGeburtsdatum.FieldName = "Geburtsdatum";
            this.BaPersonGeburtsdatum.Name = "BaPersonGeburtsdatum";
            this.BaPersonGeburtsdatum.Visible = true;
            this.BaPersonGeburtsdatum.VisibleIndex = 5;
            // 
            // BaPersonVersichertennummer
            // 
            this.BaPersonVersichertennummer.Caption = "Versichertennummer";
            this.BaPersonVersichertennummer.FieldName = "Versichertennummer";
            this.BaPersonVersichertennummer.Name = "BaPersonVersichertennummer";
            this.BaPersonVersichertennummer.Visible = true;
            this.BaPersonVersichertennummer.VisibleIndex = 4;
            // 
            // BaPersonWohnsitzStrasse
            // 
            this.BaPersonWohnsitzStrasse.Caption = "Strasse";
            this.BaPersonWohnsitzStrasse.FieldName = "Strasse";
            this.BaPersonWohnsitzStrasse.Name = "BaPersonWohnsitzStrasse";
            this.BaPersonWohnsitzStrasse.Visible = true;
            this.BaPersonWohnsitzStrasse.VisibleIndex = 6;
            // 
            // BaPersonWohnsitzHausNr
            // 
            this.BaPersonWohnsitzHausNr.Caption = "WohnsitzHausNr";
            this.BaPersonWohnsitzHausNr.FieldName = "HausNr";
            this.BaPersonWohnsitzHausNr.Name = "BaPersonWohnsitzHausNr";
            this.BaPersonWohnsitzHausNr.Visible = true;
            this.BaPersonWohnsitzHausNr.VisibleIndex = 7;
            // 
            // BaPersonWohnsitzPLZ
            // 
            this.BaPersonWohnsitzPLZ.Caption = "PLZ";
            this.BaPersonWohnsitzPLZ.FieldName = "Plz";
            this.BaPersonWohnsitzPLZ.Name = "BaPersonWohnsitzPLZ";
            this.BaPersonWohnsitzPLZ.Visible = true;
            this.BaPersonWohnsitzPLZ.VisibleIndex = 8;
            // 
            // BaPersonWohnsitzOrt
            // 
            this.BaPersonWohnsitzOrt.Caption = "Ort";
            this.BaPersonWohnsitzOrt.FieldName = "Ort";
            this.BaPersonWohnsitzOrt.Name = "BaPersonWohnsitzOrt";
            this.BaPersonWohnsitzOrt.Visible = true;
            this.BaPersonWohnsitzOrt.VisibleIndex = 9;
            // 
            // edtMappingKriterien
            // 
            this.edtMappingKriterien.Appearance.BackColor = System.Drawing.Color.LightGray;
            this.edtMappingKriterien.Appearance.Options.UseBackColor = true;
            this.edtMappingKriterien.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtMappingKriterien.CheckOnClick = true;
            this.edtMappingKriterien.Location = new System.Drawing.Point(395, 3);
            this.edtMappingKriterien.LOVName = "NewodMappingKriterien";
            this.edtMappingKriterien.Name = "edtMappingKriterien";
            this.edtMappingKriterien.Size = new System.Drawing.Size(143, 216);
            this.edtMappingKriterien.TabIndex = 1;
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.edtAHVNummerNewodPerson);
            this.panelAction.Controls.Add(this.edtAHVNummerBaPerson);
            this.panelAction.Controls.Add(this.edtVersichertennummerNewodPerson);
            this.panelAction.Controls.Add(this.edtVersichertennummerBaPerson);
            this.panelAction.Controls.Add(this.edtMappingKriterien);
            this.panelAction.Controls.Add(this.btnDoSearch);
            this.panelAction.Controls.Add(this.kissTextEdit1);
            this.panelAction.Controls.Add(this.edtOrtNewodPerson);
            this.panelAction.Controls.Add(this.edtOrtBaPerson);
            this.panelAction.Controls.Add(this.edtPLZNewodPerson);
            this.panelAction.Controls.Add(this.edtPLZBaPerson);
            this.panelAction.Controls.Add(this.edtStrasseNewodPerson);
            this.panelAction.Controls.Add(this.edtHausNrNewodPerson);
            this.panelAction.Controls.Add(this.edtHausNrBaPerson);
            this.panelAction.Controls.Add(this.edtStrasseBaPerson);
            this.panelAction.Controls.Add(this.edtVornameNewodPerson);
            this.panelAction.Controls.Add(this.edtVornameBaPerson);
            this.panelAction.Controls.Add(this.edtNameNewodPerson);
            this.panelAction.Controls.Add(this.edtIDNewodPerson);
            this.panelAction.Controls.Add(this.edtIDBaPerson);
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
            this.panelAction.Location = new System.Drawing.Point(0, 299);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(926, 259);
            this.panelAction.TabIndex = 1;
            // 
            // edtAHVNummerNewodPerson
            // 
            this.edtAHVNummerNewodPerson.DataMember = "AHVnummer";
            this.edtAHVNummerNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAHVNummerNewodPerson.Location = new System.Drawing.Point(706, 112);
            this.edtAHVNummerNewodPerson.Name = "edtAHVNummerNewodPerson";
            this.edtAHVNummerNewodPerson.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAHVNummerNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAHVNummerNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummerNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummerNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummerNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummerNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummerNewodPerson.Properties.Appearance.Options.UseTextOptions = true;
            this.edtAHVNummerNewodPerson.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtAHVNummerNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummerNewodPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAHVNummerNewodPerson.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtAHVNummerNewodPerson.Properties.DisplayFormat.FormatString = "000\\.00\\.000\\.000";
            this.edtAHVNummerNewodPerson.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtAHVNummerNewodPerson.Properties.EditFormat.FormatString = "000\\.00\\.000\\.000";
            this.edtAHVNummerNewodPerson.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtAHVNummerNewodPerson.Properties.Mask.EditMask = "000\\.00\\.000\\.000";
            this.edtAHVNummerNewodPerson.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtAHVNummerNewodPerson.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtAHVNummerNewodPerson.Properties.MaxLength = 13;
            this.edtAHVNummerNewodPerson.Properties.Precision = 0;
            this.edtAHVNummerNewodPerson.Properties.ReadOnly = true;
            this.edtAHVNummerNewodPerson.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtAHVNummerNewodPerson.Size = new System.Drawing.Size(204, 24);
            this.edtAHVNummerNewodPerson.TabIndex = 5;
            // 
            // edtAHVNummerBaPerson
            // 
            this.edtAHVNummerBaPerson.DataMember = "AHVnummer";
            this.edtAHVNummerBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAHVNummerBaPerson.Location = new System.Drawing.Point(133, 112);
            this.edtAHVNummerBaPerson.Name = "edtAHVNummerBaPerson";
            this.edtAHVNummerBaPerson.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAHVNummerBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAHVNummerBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVNummerBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVNummerBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVNummerBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVNummerBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtAHVNummerBaPerson.Properties.Appearance.Options.UseTextOptions = true;
            this.edtAHVNummerBaPerson.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtAHVNummerBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVNummerBaPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAHVNummerBaPerson.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtAHVNummerBaPerson.Properties.DisplayFormat.FormatString = "000\\.00\\.000\\.000";
            this.edtAHVNummerBaPerson.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtAHVNummerBaPerson.Properties.EditFormat.FormatString = "000\\.00\\.000\\.000";
            this.edtAHVNummerBaPerson.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtAHVNummerBaPerson.Properties.Mask.EditMask = "000\\.00\\.000\\.000";
            this.edtAHVNummerBaPerson.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtAHVNummerBaPerson.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtAHVNummerBaPerson.Properties.MaxLength = 13;
            this.edtAHVNummerBaPerson.Properties.Precision = 0;
            this.edtAHVNummerBaPerson.Properties.ReadOnly = true;
            this.edtAHVNummerBaPerson.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtAHVNummerBaPerson.Size = new System.Drawing.Size(204, 24);
            this.edtAHVNummerBaPerson.TabIndex = 5;
            // 
            // edtVersichertennummerNewodPerson
            // 
            this.edtVersichertennummerNewodPerson.DataMember = "Versichertennummer";
            this.edtVersichertennummerNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersichertennummerNewodPerson.Location = new System.Drawing.Point(706, 137);
            this.edtVersichertennummerNewodPerson.Name = "edtVersichertennummerNewodPerson";
            this.edtVersichertennummerNewodPerson.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersichertennummerNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersichertennummerNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummerNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummerNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummerNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummerNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummerNewodPerson.Properties.Appearance.Options.UseTextOptions = true;
            this.edtVersichertennummerNewodPerson.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtVersichertennummerNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummerNewodPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersichertennummerNewodPerson.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtVersichertennummerNewodPerson.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummerNewodPerson.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummerNewodPerson.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummerNewodPerson.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummerNewodPerson.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummerNewodPerson.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtVersichertennummerNewodPerson.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtVersichertennummerNewodPerson.Properties.MaxLength = 13;
            this.edtVersichertennummerNewodPerson.Properties.Precision = 0;
            this.edtVersichertennummerNewodPerson.Properties.ReadOnly = true;
            this.edtVersichertennummerNewodPerson.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtVersichertennummerNewodPerson.Size = new System.Drawing.Size(204, 24);
            this.edtVersichertennummerNewodPerson.TabIndex = 4;
            // 
            // edtVersichertennummerBaPerson
            // 
            this.edtVersichertennummerBaPerson.DataMember = "Versichertennummer";
            this.edtVersichertennummerBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersichertennummerBaPerson.Location = new System.Drawing.Point(133, 137);
            this.edtVersichertennummerBaPerson.Name = "edtVersichertennummerBaPerson";
            this.edtVersichertennummerBaPerson.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVersichertennummerBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersichertennummerBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersichertennummerBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersichertennummerBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersichertennummerBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersichertennummerBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtVersichertennummerBaPerson.Properties.Appearance.Options.UseTextOptions = true;
            this.edtVersichertennummerBaPerson.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.edtVersichertennummerBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersichertennummerBaPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVersichertennummerBaPerson.Properties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None);
            this.edtVersichertennummerBaPerson.Properties.DisplayFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummerBaPerson.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummerBaPerson.Properties.EditFormat.FormatString = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummerBaPerson.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtVersichertennummerBaPerson.Properties.Mask.EditMask = "000\\.0000\\.0000\\.00";
            this.edtVersichertennummerBaPerson.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;
            this.edtVersichertennummerBaPerson.Properties.Mask.UseMaskAsDisplayFormat = true;
            this.edtVersichertennummerBaPerson.Properties.MaxLength = 13;
            this.edtVersichertennummerBaPerson.Properties.Precision = 0;
            this.edtVersichertennummerBaPerson.Properties.ReadOnly = true;
            this.edtVersichertennummerBaPerson.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.edtVersichertennummerBaPerson.Size = new System.Drawing.Size(204, 24);
            this.edtVersichertennummerBaPerson.TabIndex = 4;
            // 
            // btnDoSearch
            // 
            this.btnDoSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoSearch.Location = new System.Drawing.Point(395, 225);
            this.btnDoSearch.Name = "btnDoSearch";
            this.btnDoSearch.Size = new System.Drawing.Size(143, 24);
            this.btnDoSearch.TabIndex = 3;
            this.btnDoSearch.Text = "Suche starten";
            this.btnDoSearch.UseVisualStyleBackColor = false;
            this.btnDoSearch.Click += new System.EventHandler(this.btnDoSearch_Click);
            // 
            // kissTextEdit1
            // 
            this.kissTextEdit1.DataMember = "Versichertennummer";
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(942, 96);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(204, 24);
            this.kissTextEdit1.TabIndex = 2;
            // 
            // edtOrtNewodPerson
            // 
            this.edtOrtNewodPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.NewodPersonBindingSource, "Ort", true));
            this.edtOrtNewodPerson.DataMember = "Ort";
            this.edtOrtNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOrtNewodPerson.Location = new System.Drawing.Point(780, 189);
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
            // NewodPersonBindingSource
            // 
            this.NewodPersonBindingSource.DataSource = typeof(KiSS4.Schnittstellen.Newod.DTO.NewodPerson);
            // 
            // edtOrtBaPerson
            // 
            this.edtOrtBaPerson.DataMember = "Ort";
            this.edtOrtBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOrtBaPerson.Location = new System.Drawing.Point(207, 189);
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
            this.edtPLZNewodPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.NewodPersonBindingSource, "Plz", true));
            this.edtPLZNewodPerson.DataMember = "Plz";
            this.edtPLZNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPLZNewodPerson.Location = new System.Drawing.Point(706, 189);
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
            this.edtPLZBaPerson.DataMember = "Plz";
            this.edtPLZBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPLZBaPerson.Location = new System.Drawing.Point(133, 189);
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
            this.edtStrasseNewodPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.NewodPersonBindingSource, "Strasse", true));
            this.edtStrasseNewodPerson.DataMember = "Strasse";
            this.edtStrasseNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseNewodPerson.Location = new System.Drawing.Point(706, 163);
            this.edtStrasseNewodPerson.Name = "edtStrasseNewodPerson";
            this.edtStrasseNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasseNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseNewodPerson.Properties.ReadOnly = true;
            this.edtStrasseNewodPerson.Size = new System.Drawing.Size(126, 24);
            this.edtStrasseNewodPerson.TabIndex = 2;
            // 
            // edtHausNrNewodPerson
            // 
            this.edtHausNrNewodPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.NewodPersonBindingSource, "HausNr", true));
            this.edtHausNrNewodPerson.DataMember = "HausNr";
            this.edtHausNrNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHausNrNewodPerson.Location = new System.Drawing.Point(838, 163);
            this.edtHausNrNewodPerson.Name = "edtHausNrNewodPerson";
            this.edtHausNrNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHausNrNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHausNrNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHausNrNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtHausNrNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHausNrNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtHausNrNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHausNrNewodPerson.Properties.ReadOnly = true;
            this.edtHausNrNewodPerson.Size = new System.Drawing.Size(72, 24);
            this.edtHausNrNewodPerson.TabIndex = 2;
            // 
            // edtHausNrBaPerson
            // 
            this.edtHausNrBaPerson.DataMember = "HausNr";
            this.edtHausNrBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHausNrBaPerson.Location = new System.Drawing.Point(265, 163);
            this.edtHausNrBaPerson.Name = "edtHausNrBaPerson";
            this.edtHausNrBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHausNrBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHausNrBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHausNrBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtHausNrBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHausNrBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtHausNrBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHausNrBaPerson.Properties.ReadOnly = true;
            this.edtHausNrBaPerson.Size = new System.Drawing.Size(72, 24);
            this.edtHausNrBaPerson.TabIndex = 2;
            // 
            // edtStrasseBaPerson
            // 
            this.edtStrasseBaPerson.DataMember = "Strasse";
            this.edtStrasseBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasseBaPerson.Location = new System.Drawing.Point(133, 163);
            this.edtStrasseBaPerson.Name = "edtStrasseBaPerson";
            this.edtStrasseBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasseBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasseBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasseBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasseBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasseBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtStrasseBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasseBaPerson.Properties.ReadOnly = true;
            this.edtStrasseBaPerson.Size = new System.Drawing.Size(127, 24);
            this.edtStrasseBaPerson.TabIndex = 2;
            // 
            // edtVornameNewodPerson
            // 
            this.edtVornameNewodPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.NewodPersonBindingSource, "Vorname", true));
            this.edtVornameNewodPerson.DataMember = "Vorname";
            this.edtVornameNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVornameNewodPerson.Location = new System.Drawing.Point(706, 59);
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
            this.edtVornameBaPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.KissPersonBindingSource, "Vorname", true));
            this.edtVornameBaPerson.DataMember = "Vorname";
            this.edtVornameBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVornameBaPerson.Location = new System.Drawing.Point(133, 59);
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
            // KissPersonBindingSource
            // 
            this.KissPersonBindingSource.DataSource = typeof(KiSS4.Schnittstellen.Newod.DTO.BaPerson);
            // 
            // edtNameNewodPerson
            // 
            this.edtNameNewodPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.NewodPersonBindingSource, "Name", true));
            this.edtNameNewodPerson.DataMember = "Name";
            this.edtNameNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameNewodPerson.Location = new System.Drawing.Point(706, 33);
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
            // edtIDNewodPerson
            // 
            this.edtIDNewodPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.NewodPersonBindingSource, "ID", true));
            this.edtIDNewodPerson.DataMember = "ID";
            this.edtIDNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIDNewodPerson.Location = new System.Drawing.Point(814, 7);
            this.edtIDNewodPerson.Name = "edtIDNewodPerson";
            this.edtIDNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIDNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIDNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIDNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtIDNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIDNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtIDNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIDNewodPerson.Properties.ReadOnly = true;
            this.edtIDNewodPerson.Size = new System.Drawing.Size(96, 24);
            this.edtIDNewodPerson.TabIndex = 2;
            // 
            // edtIDBaPerson
            // 
            this.edtIDBaPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.KissPersonBindingSource, "ID", true));
            this.edtIDBaPerson.DataMember = "ID";
            this.edtIDBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIDBaPerson.Location = new System.Drawing.Point(241, 7);
            this.edtIDBaPerson.Name = "edtIDBaPerson";
            this.edtIDBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIDBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIDBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIDBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtIDBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIDBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtIDBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIDBaPerson.Properties.ReadOnly = true;
            this.edtIDBaPerson.Size = new System.Drawing.Size(96, 24);
            this.edtIDBaPerson.TabIndex = 2;
            // 
            // edtNameBaPerson
            // 
            this.edtNameBaPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.KissPersonBindingSource, "Name", true));
            this.edtNameBaPerson.DataMember = "Name";
            this.edtNameBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNameBaPerson.Location = new System.Drawing.Point(133, 33);
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
            this.edtGeburtsdatumBaPerson.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.KissPersonBindingSource, "Geburtsdatum", true));
            this.edtGeburtsdatumBaPerson.DataMember = "geburtsdatum";
            this.edtGeburtsdatumBaPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtsdatumBaPerson.EditValue = null;
            this.edtGeburtsdatumBaPerson.Location = new System.Drawing.Point(133, 85);
            this.edtGeburtsdatumBaPerson.Name = "edtGeburtsdatumBaPerson";
            this.edtGeburtsdatumBaPerson.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatumBaPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtsdatumBaPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatumBaPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatumBaPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatumBaPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatumBaPerson.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatumBaPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGeburtsdatumBaPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatumBaPerson.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGeburtsdatumBaPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatumBaPerson.Properties.ReadOnly = true;
            this.edtGeburtsdatumBaPerson.Properties.ShowToday = false;
            this.edtGeburtsdatumBaPerson.Size = new System.Drawing.Size(89, 24);
            this.edtGeburtsdatumBaPerson.TabIndex = 1;
            // 
            // edtGeburtsdatumNewodPerson
            // 
            this.edtGeburtsdatumNewodPerson.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.NewodPersonBindingSource, "Geburtsdatum", true));
            this.edtGeburtsdatumNewodPerson.DataMember = "Geburtsdatum";
            this.edtGeburtsdatumNewodPerson.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGeburtsdatumNewodPerson.EditValue = null;
            this.edtGeburtsdatumNewodPerson.Location = new System.Drawing.Point(706, 85);
            this.edtGeburtsdatumNewodPerson.Name = "edtGeburtsdatumNewodPerson";
            this.edtGeburtsdatumNewodPerson.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatumNewodPerson.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatumNewodPerson.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtGeburtsdatumNewodPerson.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtsdatumNewodPerson.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtGeburtsdatumNewodPerson.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtsdatumNewodPerson.Properties.ReadOnly = true;
            this.edtGeburtsdatumNewodPerson.Properties.ShowToday = false;
            this.edtGeburtsdatumNewodPerson.Size = new System.Drawing.Size(92, 24);
            this.edtGeburtsdatumNewodPerson.TabIndex = 1;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(576, 189);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(116, 24);
            this.kissLabel2.TabIndex = 0;
            this.kissLabel2.Text = "PLZ / Ort";
            // 
            // lblPLZOrt
            // 
            this.lblPLZOrt.Location = new System.Drawing.Point(10, 189);
            this.lblPLZOrt.Name = "lblPLZOrt";
            this.lblPLZOrt.Size = new System.Drawing.Size(116, 24);
            this.lblPLZOrt.TabIndex = 0;
            this.lblPLZOrt.Text = "PLZ / Ort";
            // 
            // lblStrasseNewodPerson
            // 
            this.lblStrasseNewodPerson.Location = new System.Drawing.Point(576, 161);
            this.lblStrasseNewodPerson.Name = "lblStrasseNewodPerson";
            this.lblStrasseNewodPerson.Size = new System.Drawing.Size(116, 24);
            this.lblStrasseNewodPerson.TabIndex = 0;
            this.lblStrasseNewodPerson.Text = "Strasse";
            // 
            // lblStrasse
            // 
            this.lblStrasse.Location = new System.Drawing.Point(11, 163);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(116, 24);
            this.lblStrasse.TabIndex = 0;
            this.lblStrasse.Text = "Strasse";
            // 
            // lblVersichertennummerNewodPerson
            // 
            this.lblVersichertennummerNewodPerson.Location = new System.Drawing.Point(576, 137);
            this.lblVersichertennummerNewodPerson.Name = "lblVersichertennummerNewodPerson";
            this.lblVersichertennummerNewodPerson.Size = new System.Drawing.Size(124, 24);
            this.lblVersichertennummerNewodPerson.TabIndex = 0;
            this.lblVersichertennummerNewodPerson.Text = "Versichertennummer";
            // 
            // lblVersichertennummer
            // 
            this.lblVersichertennummer.Location = new System.Drawing.Point(10, 137);
            this.lblVersichertennummer.Name = "lblVersichertennummer";
            this.lblVersichertennummer.Size = new System.Drawing.Size(117, 24);
            this.lblVersichertennummer.TabIndex = 0;
            this.lblVersichertennummer.Text = "Versichertennummer";
            // 
            // lblAHVNummerNewodPerson
            // 
            this.lblAHVNummerNewodPerson.Location = new System.Drawing.Point(576, 112);
            this.lblAHVNummerNewodPerson.Name = "lblAHVNummerNewodPerson";
            this.lblAHVNummerNewodPerson.Size = new System.Drawing.Size(149, 24);
            this.lblAHVNummerNewodPerson.TabIndex = 0;
            this.lblAHVNummerNewodPerson.Text = "AHVNummer";
            // 
            // lblAHVNummer
            // 
            this.lblAHVNummer.Location = new System.Drawing.Point(11, 112);
            this.lblAHVNummer.Name = "lblAHVNummer";
            this.lblAHVNummer.Size = new System.Drawing.Size(110, 24);
            this.lblAHVNummer.TabIndex = 0;
            this.lblAHVNummer.Text = "AHVNummer";
            // 
            // lblGeburtsdatumNewodPerson
            // 
            this.lblGeburtsdatumNewodPerson.Location = new System.Drawing.Point(576, 86);
            this.lblGeburtsdatumNewodPerson.Name = "lblGeburtsdatumNewodPerson";
            this.lblGeburtsdatumNewodPerson.Size = new System.Drawing.Size(165, 24);
            this.lblGeburtsdatumNewodPerson.TabIndex = 0;
            this.lblGeburtsdatumNewodPerson.Text = "Geburtsdatum";
            // 
            // lblGeburtsdatum
            // 
            this.lblGeburtsdatum.Location = new System.Drawing.Point(11, 85);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(110, 24);
            this.lblGeburtsdatum.TabIndex = 0;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            // 
            // lblVornameNewodPerson
            // 
            this.lblVornameNewodPerson.Location = new System.Drawing.Point(576, 60);
            this.lblVornameNewodPerson.Name = "lblVornameNewodPerson";
            this.lblVornameNewodPerson.Size = new System.Drawing.Size(100, 23);
            this.lblVornameNewodPerson.TabIndex = 0;
            this.lblVornameNewodPerson.Text = "Vorname";
            // 
            // lblVorname
            // 
            this.lblVorname.Location = new System.Drawing.Point(11, 60);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(100, 23);
            this.lblVorname.TabIndex = 0;
            this.lblVorname.Text = "Vorname";
            // 
            // lblNameNewodPerson
            // 
            this.lblNameNewodPerson.Location = new System.Drawing.Point(576, 33);
            this.lblNameNewodPerson.Name = "lblNameNewodPerson";
            this.lblNameNewodPerson.Size = new System.Drawing.Size(100, 23);
            this.lblNameNewodPerson.TabIndex = 0;
            this.lblNameNewodPerson.Text = "Name";
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(11, 33);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // btnDoMapping
            // 
            this.btnDoMapping.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoMapping.Location = new System.Drawing.Point(712, 15);
            this.btnDoMapping.Name = "btnDoMapping";
            this.btnDoMapping.Size = new System.Drawing.Size(90, 24);
            this.btnDoMapping.TabIndex = 3;
            this.btnDoMapping.Text = "Zuweisen";
            this.btnDoMapping.UseVisualStyleBackColor = true;
            this.btnDoMapping.Click += new System.EventHandler(this.btnDoMapping_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnDoMapping);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 564);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 51);
            this.panel1.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(808, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // CtlKiSSNewodMappingWeb
            // 
            this.AllowDrop = true;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.panelAction);
            this.Name = "CtlKiSSNewodMappingWeb";
            this.Size = new System.Drawing.Size(926, 615);
            this.panelGrid.ResumeLayout(false);
            this.panelGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVwNewodPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMappingKriterien)).EndInit();
            this.panelAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummerNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVNummerBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummerNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersichertennummerBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewodPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrtBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNrNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNrBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasseBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornameBaPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KissPersonBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDNewodPerson.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIDBaPerson.Properties)).EndInit();
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
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
