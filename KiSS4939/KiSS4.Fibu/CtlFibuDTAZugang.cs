using System;
using System.Linq;

using DevExpress.XtraEditors.Controls;

using Kiss.Interfaces.UI;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Schnittstellen.DTA_EZAG;

namespace KiSS4.Fibu
{
    /// <summary>
    /// Summary description for CtlFibuDTAZugang.
    /// </summary>
    public class CtlFibuDTAZugang : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private bool _edtZahlungsformat_EditValueChanging;
        private int? _postfinanceBaBankID;
        private string _postfinanceBezeichnung;
        private DevExpress.XtraGrid.Columns.GridColumn colBank;
        private DevExpress.XtraGrid.Columns.GridColumn colKontoNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colVertragNr;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsformat;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit editKontoNr;
        private KiSS4.Gui.KissTextEdit editName;
        private KiSS4.Gui.KissTextEdit editVertragNr;
        private KiSS4.Gui.KissButtonEdit edtFinanzInstitut;
        private KiSS4.Gui.KissLookUpEdit edtTeam;
        private KiSS4.Gui.KissRadioGroup edtZahlungsformat;
        private KiSS4.Gui.KissGrid grdFbDTAZugang;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFbDTAZugang;
        private System.Windows.Forms.Label lblFinanzInstitut;
        private System.Windows.Forms.Label lblKontoNr;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTeam;
        private System.Windows.Forms.Label lblVertragNr;
        private System.Windows.Forms.Label lblZahlungsformat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private KiSS4.DB.SqlQuery qryFbDTAZugang;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlFibuDTAZugang"/> class.
        /// </summary>
        public CtlFibuDTAZugang()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            this.grdFbDTAZugang.View.Columns["KontoNr"].DisplayFormat.Format = new GridColumnPCKontoFormatter();

            this.edtTeam.Properties.DataSource = DBUtil.OpenSQL("SELECT FbTeamID, Name FROM FbTeam UNION SELECT null, '' ORDER BY Name");
            this.edtTeam.Properties.DisplayMember = "Name";
            this.edtTeam.Properties.ValueMember = "FbTeamID";

            GetPostfinanceData(out _postfinanceBaBankID, out _postfinanceBezeichnung);
            PrepareEdtZahlungsformat();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFibuDTAZugang));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFbDTAZugang = new KiSS4.DB.SqlQuery();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTeam = new System.Windows.Forms.Label();
            this.edtTeam = new KiSS4.Gui.KissLookUpEdit();
            this.edtZahlungsformat = new KiSS4.Gui.KissRadioGroup();
            this.editName = new KiSS4.Gui.KissTextEdit();
            this.lblZahlungsformat = new System.Windows.Forms.Label();
            this.edtFinanzInstitut = new KiSS4.Gui.KissButtonEdit();
            this.lblKontoNr = new System.Windows.Forms.Label();
            this.editVertragNr = new KiSS4.Gui.KissTextEdit();
            this.lblFinanzInstitut = new System.Windows.Forms.Label();
            this.editKontoNr = new KiSS4.Gui.KissTextEdit();
            this.lblVertragNr = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.grdFbDTAZugang = new KiSS4.Gui.KissGrid();
            this.grvFbDTAZugang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKontoNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVertragNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBank = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungsformat = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDTAZugang)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeam.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsformat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsformat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFinanzInstitut.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVertragNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKontoNr.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDTAZugang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDTAZugang)).BeginInit();
            this.SuspendLayout();
            //
            // qryFbDTAZugang
            //
            this.qryFbDTAZugang.AutoApplyUserRights = false;
            this.qryFbDTAZugang.CanDelete = true;
            this.qryFbDTAZugang.CanInsert = true;
            this.qryFbDTAZugang.CanUpdate = true;
            this.qryFbDTAZugang.HostControl = this;
            this.qryFbDTAZugang.IsIdentityInsert = false;
            this.qryFbDTAZugang.SelectStatement = resources.GetString("qryFbDTAZugang.SelectStatement");
            this.qryFbDTAZugang.TableName = "FbDTAZugang";
            this.qryFbDTAZugang.AfterInsert += new System.EventHandler(this.qryDTAZugang_AfterInsert);
            this.qryFbDTAZugang.BeforePost += new System.EventHandler(this.qryDTAZugang_BeforePost);
            //
            // panel1
            //
            this.panel1.Controls.Add(this.lblTeam);
            this.panel1.Controls.Add(this.edtTeam);
            this.panel1.Controls.Add(this.edtZahlungsformat);
            this.panel1.Controls.Add(this.editName);
            this.panel1.Controls.Add(this.lblZahlungsformat);
            this.panel1.Controls.Add(this.edtFinanzInstitut);
            this.panel1.Controls.Add(this.lblKontoNr);
            this.panel1.Controls.Add(this.editVertragNr);
            this.panel1.Controls.Add(this.lblFinanzInstitut);
            this.panel1.Controls.Add(this.editKontoNr);
            this.panel1.Controls.Add(this.lblVertragNr);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 340);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 195);
            this.panel1.TabIndex = 0;
            //
            // lblTeam
            //
            this.lblTeam.Location = new System.Drawing.Point(15, 150);
            this.lblTeam.Name = "lblTeam";
            this.lblTeam.Size = new System.Drawing.Size(100, 15);
            this.lblTeam.TabIndex = 13;
            this.lblTeam.Text = "Team";
            this.lblTeam.UseCompatibleTextRendering = true;
            //
            // edtTeam
            //
            this.edtTeam.DataMember = "FbTeamId";
            this.edtTeam.DataSource = this.qryFbDTAZugang;
            this.edtTeam.Location = new System.Drawing.Point(132, 146);
            this.edtTeam.Name = "edtTeam";
            this.edtTeam.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTeam.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTeam.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTeam.Properties.Appearance.Options.UseBackColor = true;
            this.edtTeam.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTeam.Properties.Appearance.Options.UseFont = true;
            this.edtTeam.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtTeam.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtTeam.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtTeam.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtTeam.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtTeam.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtTeam.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTeam.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name")});
            this.edtTeam.Properties.NullText = "";
            this.edtTeam.Properties.ShowFooter = false;
            this.edtTeam.Properties.ShowHeader = false;
            this.edtTeam.Size = new System.Drawing.Size(250, 24);
            this.edtTeam.TabIndex = 12;
            //
            // edtZahlungsformat
            //
            this.edtZahlungsformat.DataMember = "KbFinanzInstitutCode";
            this.edtZahlungsformat.DataSource = this.qryFbDTAZugang;
            this.edtZahlungsformat.EditValue = "";
            this.edtZahlungsformat.Location = new System.Drawing.Point(132, 35);
            this.edtZahlungsformat.LookupSQL = null;
            this.edtZahlungsformat.LOVFilter = null;
            this.edtZahlungsformat.LOVName = null;
            this.edtZahlungsformat.Name = "edtZahlungsformat";
            this.edtZahlungsformat.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtZahlungsformat.Properties.Appearance.Options.UseBackColor = true;
            this.edtZahlungsformat.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.edtZahlungsformat.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.edtZahlungsformat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtZahlungsformat.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "ISO 20022"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "EZAG"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "DTA")});
            this.edtZahlungsformat.Size = new System.Drawing.Size(250, 30);
            this.edtZahlungsformat.TabIndex = 2;
            this.edtZahlungsformat.EditValueChanged += new System.EventHandler(this.edtZahlungsformat_EditValueChanged);
            //
            // editName
            //
            this.editName.DataMember = "Name";
            this.editName.DataSource = this.qryFbDTAZugang;
            this.editName.Location = new System.Drawing.Point(132, 10);
            this.editName.Name = "editName";
            this.editName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editName.Properties.Appearance.Options.UseBackColor = true;
            this.editName.Properties.Appearance.Options.UseBorderColor = true;
            this.editName.Properties.Appearance.Options.UseFont = true;
            this.editName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editName.Size = new System.Drawing.Size(250, 24);
            this.editName.TabIndex = 1;
            //
            // lblZahlungsformat
            //
            this.lblZahlungsformat.Location = new System.Drawing.Point(15, 42);
            this.lblZahlungsformat.Name = "lblZahlungsformat";
            this.lblZahlungsformat.Size = new System.Drawing.Size(100, 15);
            this.lblZahlungsformat.TabIndex = 11;
            this.lblZahlungsformat.Text = "Zahlungsformat";
            this.lblZahlungsformat.UseCompatibleTextRendering = true;
            //
            // edtFinanzInstitut
            //
            this.edtFinanzInstitut.DataMember = "FinanzInstitut";
            this.edtFinanzInstitut.DataSource = this.qryFbDTAZugang;
            this.edtFinanzInstitut.Location = new System.Drawing.Point(132, 65);
            this.edtFinanzInstitut.Name = "edtFinanzInstitut";
            this.edtFinanzInstitut.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFinanzInstitut.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFinanzInstitut.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFinanzInstitut.Properties.Appearance.Options.UseBackColor = true;
            this.edtFinanzInstitut.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFinanzInstitut.Properties.Appearance.Options.UseFont = true;
            this.edtFinanzInstitut.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtFinanzInstitut.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtFinanzInstitut.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFinanzInstitut.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtFinanzInstitut.Size = new System.Drawing.Size(250, 24);
            this.edtFinanzInstitut.TabIndex = 3;
            this.edtFinanzInstitut.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnEditBank_ButtonPressed);
            this.edtFinanzInstitut.Leave += new System.EventHandler(this.btnEditBank_Leave);
            //
            // lblKontoNr
            //
            this.lblKontoNr.Location = new System.Drawing.Point(15, 97);
            this.lblKontoNr.Name = "lblKontoNr";
            this.lblKontoNr.Size = new System.Drawing.Size(100, 15);
            this.lblKontoNr.TabIndex = 10;
            this.lblKontoNr.Text = "Konto Nr";
            this.lblKontoNr.UseCompatibleTextRendering = true;
            //
            // editVertragNr
            //
            this.editVertragNr.DataMember = "VertragNr";
            this.editVertragNr.DataSource = this.qryFbDTAZugang;
            this.editVertragNr.Location = new System.Drawing.Point(132, 119);
            this.editVertragNr.Name = "editVertragNr";
            this.editVertragNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVertragNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVertragNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVertragNr.Properties.Appearance.Options.UseBackColor = true;
            this.editVertragNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editVertragNr.Properties.Appearance.Options.UseFont = true;
            this.editVertragNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editVertragNr.Size = new System.Drawing.Size(250, 24);
            this.editVertragNr.TabIndex = 5;
            //
            // lblFinanzInstitut
            //
            this.lblFinanzInstitut.Location = new System.Drawing.Point(15, 70);
            this.lblFinanzInstitut.Name = "lblFinanzInstitut";
            this.lblFinanzInstitut.Size = new System.Drawing.Size(100, 15);
            this.lblFinanzInstitut.TabIndex = 6;
            this.lblFinanzInstitut.Text = "Finanzinstitut";
            this.lblFinanzInstitut.UseCompatibleTextRendering = true;
            //
            // editKontoNr
            //
            this.editKontoNr.DataMember = "KontoNr";
            this.editKontoNr.DataSource = this.qryFbDTAZugang;
            this.editKontoNr.Location = new System.Drawing.Point(132, 92);
            this.editKontoNr.Name = "editKontoNr";
            this.editKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.editKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.editKontoNr.Properties.Appearance.Options.UseFont = true;
            this.editKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editKontoNr.Size = new System.Drawing.Size(250, 24);
            this.editKontoNr.TabIndex = 4;
            this.editKontoNr.ParseEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.editKontoNr_ParseEditValue);
            this.editKontoNr.FormatEditValue += new DevExpress.XtraEditors.Controls.ConvertEditValueEventHandler(this.editKontoNr_FormatEditValue);
            //
            // lblVertragNr
            //
            this.lblVertragNr.Location = new System.Drawing.Point(15, 124);
            this.lblVertragNr.Name = "lblVertragNr";
            this.lblVertragNr.Size = new System.Drawing.Size(100, 15);
            this.lblVertragNr.TabIndex = 2;
            this.lblVertragNr.Text = "Vertrag Nr";
            this.lblVertragNr.UseCompatibleTextRendering = true;
            //
            // lblName
            //
            this.lblName.Location = new System.Drawing.Point(15, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(100, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            //
            // panel2
            //
            this.panel2.Controls.Add(this.grdFbDTAZugang);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(825, 340);
            this.panel2.TabIndex = 1;
            //
            // grdFbDTAZugang
            //
            this.grdFbDTAZugang.DataSource = this.qryFbDTAZugang;
            this.grdFbDTAZugang.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdFbDTAZugang.EmbeddedNavigator.Name = "";
            this.grdFbDTAZugang.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFbDTAZugang.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdFbDTAZugang.Location = new System.Drawing.Point(0, 0);
            this.grdFbDTAZugang.MainView = this.grvFbDTAZugang;
            this.grdFbDTAZugang.Name = "grdFbDTAZugang";
            this.grdFbDTAZugang.Size = new System.Drawing.Size(825, 340);
            this.grdFbDTAZugang.TabIndex = 7;
            this.grdFbDTAZugang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFbDTAZugang});
            //
            // grvFbDTAZugang
            //
            this.grvFbDTAZugang.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFbDTAZugang.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAZugang.Appearance.Empty.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.Empty.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvFbDTAZugang.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAZugang.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.EvenRow.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbDTAZugang.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAZugang.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFbDTAZugang.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFbDTAZugang.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFbDTAZugang.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAZugang.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFbDTAZugang.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFbDTAZugang.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDTAZugang.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbDTAZugang.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFbDTAZugang.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDTAZugang.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFbDTAZugang.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbDTAZugang.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbDTAZugang.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.GroupRow.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFbDTAZugang.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFbDTAZugang.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFbDTAZugang.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFbDTAZugang.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFbDTAZugang.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFbDTAZugang.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAZugang.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFbDTAZugang.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFbDTAZugang.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbDTAZugang.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvFbDTAZugang.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAZugang.Appearance.OddRow.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.OddRow.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFbDTAZugang.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAZugang.Appearance.Row.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.Row.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvFbDTAZugang.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFbDTAZugang.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvFbDTAZugang.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFbDTAZugang.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFbDTAZugang.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvFbDTAZugang.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFbDTAZugang.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFbDTAZugang.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFbDTAZugang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKontoNr,
            this.colName,
            this.colVertragNr,
            this.colBank,
            this.colZahlungsformat});
            this.grvFbDTAZugang.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFbDTAZugang.GridControl = this.grdFbDTAZugang;
            this.grvFbDTAZugang.Name = "grvFbDTAZugang";
            this.grvFbDTAZugang.OptionsBehavior.Editable = false;
            this.grvFbDTAZugang.OptionsCustomization.AllowFilter = false;
            this.grvFbDTAZugang.OptionsCustomization.AllowGroup = false;
            this.grvFbDTAZugang.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFbDTAZugang.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFbDTAZugang.OptionsNavigation.EnterMoveNextColumn = true;
            this.grvFbDTAZugang.OptionsNavigation.UseTabKey = false;
            this.grvFbDTAZugang.OptionsView.ColumnAutoWidth = false;
            this.grvFbDTAZugang.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFbDTAZugang.OptionsView.ShowGroupPanel = false;
            this.grvFbDTAZugang.OptionsView.ShowIndicator = false;
            //
            // colKontoNr
            //
            this.colKontoNr.Caption = "Konto Nr";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.Visible = true;
            this.colKontoNr.VisibleIndex = 0;
            this.colKontoNr.Width = 200;
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 200;
            //
            // colVertragNr
            //
            this.colVertragNr.Caption = "Vertrag Nummer";
            this.colVertragNr.FieldName = "VertragNr";
            this.colVertragNr.Name = "colVertragNr";
            this.colVertragNr.Visible = true;
            this.colVertragNr.VisibleIndex = 3;
            this.colVertragNr.Width = 130;
            //
            // colBank
            //
            this.colBank.Caption = "Finanz Institut";
            this.colBank.FieldName = "FinanzInstitut";
            this.colBank.Name = "colBank";
            this.colBank.Visible = true;
            this.colBank.VisibleIndex = 2;
            this.colBank.Width = 150;
            //
            // colZahlungsformat
            //
            this.colZahlungsformat.Caption = "Zahlungsformat";
            this.colZahlungsformat.FieldName = "KbFinanzInstitutCode";
            this.colZahlungsformat.Name = "colZahlungsformat";
            this.colZahlungsformat.Visible = true;
            this.colZahlungsformat.VisibleIndex = 4;
            this.colZahlungsformat.Width = 115;
            //
            // CtlFibuDTAZugang
            //
            this.ActiveSQLQuery = this.qryFbDTAZugang;
            this.AutoRefresh = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CtlFibuDTAZugang";
            this.Size = new System.Drawing.Size(825, 535);
            this.Load += new System.EventHandler(this.CtlFibuDTAZugang_Load);
            this.Leave += new System.EventHandler(this.CtlFibuDTAZugang_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.qryFbDTAZugang)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtTeam.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTeam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsformat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZahlungsformat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFinanzInstitut.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVertragNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editKontoNr.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFbDTAZugang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFbDTAZugang)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Dispose

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

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the ButtonPressed event of the btnEditBank control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ButtonPressedEventArgs"/> instance containing the event data.</param>
        private void btnEditBank_ButtonPressed(
            object sender,
            ButtonPressedEventArgs e)
        {
            FibuUtilities.BankSuchen(edtFinanzInstitut.Text, true, this.qryFbDTAZugang);
            this.edtFinanzInstitut.CancelEdit();
        }

        /// <summary>
        /// Handles the Leave event of the btnEditBank control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnEditBank_Leave(
            object sender,
            System.EventArgs e)
        {
            if (edtFinanzInstitut.UserModified)
            {
                FibuUtilities.BankSuchen(edtFinanzInstitut.Text, false, this.qryFbDTAZugang);
            }
        }

        /// <summary>
        /// Handles the Leave event of the CtlFibuDTAZugang control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtlFibuDTAZugang_Leave(object sender, System.EventArgs e)
        {
            this.qryFbDTAZugang.Post();
        }

        /// <summary>
        /// Handles the Load event of the CtlFibuDTAZugang control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CtlFibuDTAZugang_Load(object sender, System.EventArgs e)
        {
            qryFbDTAZugang.Fill();
            colZahlungsformat.ColumnEdit = grdFbDTAZugang.GetLOVLookUpEdit("KbFinanzInstitut");
        }

        /// <summary>
        /// Handles the FormatEditValue event of the editKontoNr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs"/> instance containing the event data.</param>
        private void editKontoNr_FormatEditValue(
            object sender,
            ConvertEditValueEventArgs e)
        {
            try
            {
                e.Handled = true;

                var zahlungsformat = Utils.ConvertToInt(edtZahlungsformat.EditValue);
                if (zahlungsformat == (int)Utilities.KbFinanzInstitutCode.Ezag)
                {
                    // --- Check if user entered text to search for a Kreditor Name
                    if (Utils.IsAlpha(e.Value.ToString()) == false)
                    {
                        e.Value = Utils.FormatPCKontoNummerToUserFormat(e.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        /// <summary>
        /// Handles the ParseEditValue event of the editKontoNr control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs"/> instance containing the event data.</param>
        private void editKontoNr_ParseEditValue(
            object sender,
            ConvertEditValueEventArgs e)
        {
            try
            {
                e.Handled = true;
                var zahlungsformat = Utils.ConvertToInt(edtZahlungsformat.EditValue);
                if (zahlungsformat == (int)Utilities.KbFinanzInstitutCode.Ezag)
                {
                    e.Value = Utils.FormatPCKontoNummerToDBFormat(e.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        /// <summary>
        /// Handles the AfterInsert event of the qryDTAZugang control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryDTAZugang_AfterInsert(
            object sender,
            System.EventArgs e)
        {
            this.editName.Focus();
            qryFbDTAZugang["KbFinanzInstitutCode"] = (int)Utilities.KbFinanzInstitutCode.Iso20022;
        }

        /// <summary>
        /// Handles the BeforePost event of the qryDTAZugang control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void qryDTAZugang_BeforePost(
            object sender,
            System.EventArgs e)
        {
            DBUtil.CheckNotNullField(edtFinanzInstitut, lblFinanzInstitut.Text);

            DBUtil.CheckNotNullField(editName, lblName.Text);

            DBUtil.CheckNotNullField(editKontoNr, lblKontoNr.Text);

            try
            {
                var zahlungsformat = Utils.ConvertToInt(edtZahlungsformat.EditValue);
                if (zahlungsformat == (int)Utilities.KbFinanzInstitutCode.Ezag)
                {
                    // Check if user entered text to search for a Kreditor Name
                    if (Utils.IsAlpha(this.editKontoNr.EditValue.ToString()) == false)
                    {
                        this.editKontoNr.EditValue = Utils.FormatPCKontoNummerToUserFormat(this.editKontoNr.EditValue.ToString());
                        qryFbDTAZugang["KontoNr"] = Utils.FormatPCKontoNummerToDBFormat(this.editKontoNr.EditValue.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowInfo(ex.Message);
                this.editKontoNr.Focus();
                throw ex;
            }
        }

        #endregion

        #region Methods

        private void edtZahlungsformat_EditValueChanged(object sender, EventArgs e)
        {
            if (_edtZahlungsformat_EditValueChanging)
            {
                return;
            }

            _edtZahlungsformat_EditValueChanging = true;

            try
            {
                var newValue = Utils.ConvertToInt(edtZahlungsformat.EditValue);
                qryFbDTAZugang["KbFinanzInstitutCode"] = newValue;

                switch (newValue)
                {
                    case (int)Utilities.KbFinanzInstitutCode.Ezag:
                        this.edtFinanzInstitut.EditMode = EditModeType.ReadOnly;

                        //EZAG: Fix Postfinance auswählen, BaBankID leeren
                        qryFbDTAZugang["BaBankID"] = DBNull.Value;
                        this.edtFinanzInstitut.EditValue = _postfinanceBezeichnung;
                        break;

                    case (int)Utilities.KbFinanzInstitutCode.Dta:
                        this.edtFinanzInstitut.EditMode = EditModeType.Normal;

                        if (_postfinanceBezeichnung.Equals(edtFinanzInstitut.EditValue))
                        {
                            //Wechsel -> DTA: sicherstellen, dass nicht Postfinance ausgewählt ist
                            qryFbDTAZugang["BaBankID"] = DBNull.Value;
                            this.edtFinanzInstitut.EditValue = "";
                        }
                        break;

                    case (int)Utilities.KbFinanzInstitutCode.Iso20022:
                        this.edtFinanzInstitut.EditMode = EditModeType.Normal;

                        if (_postfinanceBezeichnung.Equals(edtFinanzInstitut.EditValue))
                        {
                            //Wechsel EZAG -> ISO20022, automatisch Postfinance in BaBankID auswählen
                            qryFbDTAZugang["BaBankID"] = _postfinanceBaBankID;
                            this.edtFinanzInstitut.EditValue = _postfinanceBezeichnung;
                        }
                        break;
                }
            }
            finally
            {
                _edtZahlungsformat_EditValueChanging = false;
            }
        }

        private void GetPostfinanceData(out int? postfinanceBaBankId, out string postfinanceBezeichnung)
        {
            var qry = DBUtil.OpenSQL(@"SELECT TOP 1 BaBankID, Name
                                       FROM BaBank
                                       WHERE ClearingNr = 9000
                                       ORDER BY GueltigAb DESC");
            if (qry.IsEmpty)
            {
                postfinanceBaBankId = null;
                postfinanceBezeichnung = null;
                return;
            }

            postfinanceBaBankId = Utils.ConvertToInt(qry["BaBankID"]);
            postfinanceBezeichnung = Utils.ConvertToString(qry["Name"]);
        }

        private void PrepareEdtZahlungsformat()
        {
            var query = DBUtil.GetLOVQuery("KbFinanzInstitut", false);
            var items = edtZahlungsformat.Properties.Items.Cast<RadioGroupItem>().ToDictionary(rgi => Convert.ToInt32(rgi.Value));
            RadioGroupItem item = null;

            if (!query.IsEmpty)
            {
                do
                {
                    bool isActive = Utils.ConvertToBool(query["IsActive"]);
                    int code = Utils.ConvertToInt(query["Code"]);
                    if (!isActive)
                    {
                        if (items.TryGetValue(code, out item))
                        {
                            edtZahlungsformat.Properties.Items.Remove(item);
                        }
                    }
                }
                while (query.Next());
            }
        }

        #region Public Methods

        /// <summary>
        /// Gets the name of the context.
        /// </summary>
        /// <returns></returns>
        /// <include file="KiSS4.Gui.XML" path="doc/members/member[@name=&quot;M:KiSS4.Gui.IKissContext.GetContextName&quot;]/*"/>
        public override string GetContextName()
        {
            return "VmFibu";
        }

        #endregion

        #endregion
    }
}