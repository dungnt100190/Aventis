using System;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    public class DlgAuswahlBaZahlungsweg : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnAbbruch;
        private KiSS4.Gui.KissButton btnOK;
        private KiSS4.Gui.KissLookUpEdit cboLand;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresse;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colZahlungsweg;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAdressZusatz;
        private KiSS4.Gui.KissTextEdit edtBankkontoNr;
        private KiSS4.Gui.KissTextEdit edtClearingNummer;
        private KiSS4.Gui.KissLookUpEdit edtEinzahlungsschein;
        private KiSS4.Gui.KissTextEdit edtFilter;
        private KiSS4.Gui.KissTextEdit edtHausNr;
        private KiSS4.Gui.KissTextEdit edtIBAN;
        private KiSS4.Gui.KissTextEdit edtInstitutionTypen;
        private KiSS4.Gui.KissTextEdit edtKanton;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtPLZ;
        private KiSS4.Gui.KissTextEdit edtPostfach;
        private KiSS4.Gui.KissTextEdit edtPostkontoNr;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private bool firsttime = true;
        private KiSS4.Gui.KissGrid grdKreditor;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKreditor;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel18;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissLabel lblBankkontoNr;
        private KiSS4.Gui.KissLabel lblBankPost;
        private KiSS4.Gui.KissLabel lblEinzahlungsschein;
        private KiSS4.Gui.KissLabel lblIBAN;
        private KiSS4.Gui.KissLabel lblInstitutionTypen;
        private KiSS4.Gui.KissLabel lblPostKonto;
        private KiSS4.DB.SqlQuery qryBaZahlungsweg;

        #endregion

        #endregion

        #region Constructors

        public DlgAuswahlBaZahlungsweg()
        {
            this.InitializeComponent();

            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(DlgAuswahlBaZahlungsweg_KeyPress);
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgAuswahlBaZahlungsweg));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdKreditor = new KiSS4.Gui.KissGrid();
            this.qryBaZahlungsweg = new KiSS4.DB.SqlQuery(this.components);
            this.grvKreditor = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZahlungsweg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtAdressZusatz = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtHausNr = new KiSS4.Gui.KissTextEdit();
            this.edtPostfach = new KiSS4.Gui.KissTextEdit();
            this.edtPLZ = new KiSS4.Gui.KissTextEdit();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.cboLand = new KiSS4.Gui.KissLookUpEdit();
            this.edtKanton = new KiSS4.Gui.KissTextEdit();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.lblInstitutionTypen = new KiSS4.Gui.KissLabel();
            this.edtEinzahlungsschein = new KiSS4.Gui.KissLookUpEdit();
            this.edtPostkontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtBankkontoNr = new KiSS4.Gui.KissTextEdit();
            this.edtIBAN = new KiSS4.Gui.KissTextEdit();
            this.edtClearingNummer = new KiSS4.Gui.KissTextEdit();
            this.lblEinzahlungsschein = new KiSS4.Gui.KissLabel();
            this.lblBankPost = new KiSS4.Gui.KissLabel();
            this.lblBankkontoNr = new KiSS4.Gui.KissLabel();
            this.lblPostKonto = new KiSS4.Gui.KissLabel();
            this.lblIBAN = new KiSS4.Gui.KissLabel();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.btnOK = new KiSS4.Gui.KissButton();
            this.btnAbbruch = new KiSS4.Gui.KissButton();
            this.edtInstitutionTypen = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungsweg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKreditor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionTypen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostkontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankkontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungsschein)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankkontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionTypen.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // grdKreditor
            //
            this.grdKreditor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdKreditor.DataSource = this.qryBaZahlungsweg;
            this.grdKreditor.EmbeddedNavigator.Name = "";
            this.grdKreditor.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKreditor.Location = new System.Drawing.Point(5, 5);
            this.grdKreditor.MainView = this.grvKreditor;
            this.grdKreditor.Name = "grdKreditor";
            this.grdKreditor.Size = new System.Drawing.Size(766, 257);
            this.grdKreditor.TabIndex = 0;
            this.grdKreditor.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKreditor});
            this.grdKreditor.DoubleClick += new System.EventHandler(this.grdKreditor_DoubleClick);
            //
            // qryBaZahlungsweg
            //
            this.qryBaZahlungsweg.HostControl = this;
            this.qryBaZahlungsweg.SelectStatement = resources.GetString("qryBaZahlungsweg.SelectStatement");
            //
            // grvKreditor
            //
            this.grvKreditor.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKreditor.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKreditor.Appearance.Empty.Options.UseBackColor = true;
            this.grvKreditor.Appearance.Empty.Options.UseFont = true;
            this.grvKreditor.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKreditor.Appearance.EvenRow.Options.UseFont = true;
            this.grvKreditor.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKreditor.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKreditor.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKreditor.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKreditor.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKreditor.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKreditor.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKreditor.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKreditor.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKreditor.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKreditor.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKreditor.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKreditor.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKreditor.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKreditor.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKreditor.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKreditor.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKreditor.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKreditor.Appearance.GroupRow.Options.UseFont = true;
            this.grvKreditor.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKreditor.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKreditor.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKreditor.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKreditor.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKreditor.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKreditor.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKreditor.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKreditor.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKreditor.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKreditor.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKreditor.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKreditor.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKreditor.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKreditor.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKreditor.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKreditor.Appearance.OddRow.Options.UseFont = true;
            this.grvKreditor.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKreditor.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKreditor.Appearance.Row.Options.UseBackColor = true;
            this.grvKreditor.Appearance.Row.Options.UseFont = true;
            this.grvKreditor.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKreditor.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKreditor.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKreditor.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKreditor.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKreditor.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKreditor,
            this.colAdresse,
            this.colZahlungsweg});
            this.grvKreditor.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKreditor.GridControl = this.grdKreditor;
            this.grvKreditor.Name = "grvKreditor";
            this.grvKreditor.OptionsBehavior.Editable = false;
            this.grvKreditor.OptionsCustomization.AllowFilter = false;
            this.grvKreditor.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKreditor.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKreditor.OptionsNavigation.UseTabKey = false;
            this.grvKreditor.OptionsView.ColumnAutoWidth = false;
            this.grvKreditor.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKreditor.OptionsView.ShowGroupPanel = false;
            this.grvKreditor.OptionsView.ShowIndicator = false;
            //
            // colKreditor
            //
            this.colKreditor.Caption = "Name";
            this.colKreditor.FieldName = "Kreditor";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 0;
            this.colKreditor.Width = 181;
            //
            // colAdresse
            //
            this.colAdresse.Caption = "Adresse";
            this.colAdresse.FieldName = "Adresse";
            this.colAdresse.Name = "colAdresse";
            this.colAdresse.Visible = true;
            this.colAdresse.VisibleIndex = 1;
            this.colAdresse.Width = 198;
            //
            // colZahlungsweg
            //
            this.colZahlungsweg.Caption = "Zahlungsweg";
            this.colZahlungsweg.FieldName = "Zahlungsweg";
            this.colZahlungsweg.Name = "colZahlungsweg";
            this.colZahlungsweg.Visible = true;
            this.colZahlungsweg.VisibleIndex = 2;
            this.colZahlungsweg.Width = 364;
            //
            // edtName
            //
            this.edtName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtName.DataMember = "Kreditor";
            this.edtName.DataSource = this.qryBaZahlungsweg;
            this.edtName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtName.Location = new System.Drawing.Point(90, 294);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Properties.MaxLength = 100;
            this.edtName.Properties.Name = "editName.Properties";
            this.edtName.Properties.ReadOnly = true;
            this.edtName.Size = new System.Drawing.Size(270, 24);
            this.edtName.TabIndex = 3;
            //
            // edtAdressZusatz
            //
            this.edtAdressZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAdressZusatz.DataMember = "AdressZusatz";
            this.edtAdressZusatz.DataSource = this.qryBaZahlungsweg;
            this.edtAdressZusatz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAdressZusatz.Location = new System.Drawing.Point(90, 317);
            this.edtAdressZusatz.Name = "edtAdressZusatz";
            this.edtAdressZusatz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAdressZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAdressZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAdressZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAdressZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtAdressZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAdressZusatz.Properties.MaxLength = 200;
            this.edtAdressZusatz.Properties.Name = "kissTextEdit12.Properties";
            this.edtAdressZusatz.Properties.ReadOnly = true;
            this.edtAdressZusatz.Size = new System.Drawing.Size(270, 24);
            this.edtAdressZusatz.TabIndex = 5;
            //
            // edtStrasse
            //
            this.edtStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStrasse.DataMember = "Strasse";
            this.edtStrasse.DataSource = this.qryBaZahlungsweg;
            this.edtStrasse.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStrasse.Location = new System.Drawing.Point(90, 340);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Properties.MaxLength = 100;
            this.edtStrasse.Properties.Name = "kissTextEdit17.Properties";
            this.edtStrasse.Properties.ReadOnly = true;
            this.edtStrasse.Size = new System.Drawing.Size(222, 24);
            this.edtStrasse.TabIndex = 7;
            //
            // edtHausNr
            //
            this.edtHausNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtHausNr.DataMember = "HausNr";
            this.edtHausNr.DataSource = this.qryBaZahlungsweg;
            this.edtHausNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtHausNr.Location = new System.Drawing.Point(311, 340);
            this.edtHausNr.Name = "edtHausNr";
            this.edtHausNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtHausNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHausNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHausNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHausNr.Properties.Appearance.Options.UseFont = true;
            this.edtHausNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHausNr.Properties.MaxLength = 10;
            this.edtHausNr.Properties.Name = "kissTextEdit11.Properties";
            this.edtHausNr.Properties.ReadOnly = true;
            this.edtHausNr.Size = new System.Drawing.Size(49, 24);
            this.edtHausNr.TabIndex = 8;
            //
            // edtPostfach
            //
            this.edtPostfach.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPostfach.DataMember = "Postfach";
            this.edtPostfach.DataSource = this.qryBaZahlungsweg;
            this.edtPostfach.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPostfach.Location = new System.Drawing.Point(90, 363);
            this.edtPostfach.Name = "edtPostfach";
            this.edtPostfach.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPostfach.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostfach.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostfach.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostfach.Properties.Appearance.Options.UseFont = true;
            this.edtPostfach.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostfach.Properties.MaxLength = 100;
            this.edtPostfach.Properties.Name = "kissTextEdit10.Properties";
            this.edtPostfach.Properties.ReadOnly = true;
            this.edtPostfach.Size = new System.Drawing.Size(270, 24);
            this.edtPostfach.TabIndex = 10;
            //
            // edtPLZ
            //
            this.edtPLZ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPLZ.DataMember = "PLZ";
            this.edtPLZ.DataSource = this.qryBaZahlungsweg;
            this.edtPLZ.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPLZ.Location = new System.Drawing.Point(90, 386);
            this.edtPLZ.Name = "edtPLZ";
            this.edtPLZ.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPLZ.Properties.Appearance.Options.UseFont = true;
            this.edtPLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPLZ.Properties.MaxLength = 10;
            this.edtPLZ.Properties.Name = "editPLZ.Properties";
            this.edtPLZ.Properties.ReadOnly = true;
            this.edtPLZ.Size = new System.Drawing.Size(45, 24);
            this.edtPLZ.TabIndex = 12;
            //
            // edtOrt
            //
            this.edtOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtOrt.DataMember = "Ort";
            this.edtOrt.DataSource = this.qryBaZahlungsweg;
            this.edtOrt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtOrt.Location = new System.Drawing.Point(134, 386);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Properties.MaxLength = 50;
            this.edtOrt.Properties.Name = "editOrt.Properties";
            this.edtOrt.Properties.ReadOnly = true;
            this.edtOrt.Size = new System.Drawing.Size(196, 24);
            this.edtOrt.TabIndex = 13;
            //
            // cboLand
            //
            this.cboLand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboLand.DataMember = "BaLandID";
            this.cboLand.DataSource = this.qryBaZahlungsweg;
            this.cboLand.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.cboLand.Location = new System.Drawing.Point(90, 409);
            this.cboLand.LOVName = "BaLand";
            this.cboLand.Name = "cboLand";
            this.cboLand.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.cboLand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.cboLand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.cboLand.Properties.Appearance.Options.UseBackColor = true;
            this.cboLand.Properties.Appearance.Options.UseBorderColor = true;
            this.cboLand.Properties.Appearance.Options.UseFont = true;
            this.cboLand.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.cboLand.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.cboLand.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cboLand.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cboLand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.cboLand.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.cboLand.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cboLand.Properties.Name = "kissLookUpEdit4.Properties";
            this.cboLand.Properties.NullText = "";
            this.cboLand.Properties.ReadOnly = true;
            this.cboLand.Properties.ShowFooter = false;
            this.cboLand.Properties.ShowHeader = false;
            this.cboLand.Size = new System.Drawing.Size(270, 24);
            this.cboLand.TabIndex = 16;
            //
            // edtKanton
            //
            this.edtKanton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKanton.DataMember = "Kanton";
            this.edtKanton.DataSource = this.qryBaZahlungsweg;
            this.edtKanton.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKanton.Location = new System.Drawing.Point(329, 386);
            this.edtKanton.Name = "edtKanton";
            this.edtKanton.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKanton.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKanton.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKanton.Properties.Appearance.Options.UseBackColor = true;
            this.edtKanton.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKanton.Properties.Appearance.Options.UseFont = true;
            this.edtKanton.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKanton.Properties.Name = "editKanton.Properties";
            this.edtKanton.Properties.ReadOnly = true;
            this.edtKanton.Size = new System.Drawing.Size(31, 24);
            this.edtKanton.TabIndex = 14;
            //
            // kissLabel18
            //
            this.kissLabel18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel18.Location = new System.Drawing.Point(5, 340);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(83, 24);
            this.kissLabel18.TabIndex = 6;
            this.kissLabel18.Text = "Strasse / Nr";
            this.kissLabel18.UseCompatibleTextRendering = true;
            //
            // kissLabel12
            //
            this.kissLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel12.Location = new System.Drawing.Point(5, 409);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(75, 24);
            this.kissLabel12.TabIndex = 15;
            this.kissLabel12.Text = "Land";
            this.kissLabel12.UseCompatibleTextRendering = true;
            //
            // kissLabel14
            //
            this.kissLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel14.Location = new System.Drawing.Point(5, 386);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(70, 24);
            this.kissLabel14.TabIndex = 11;
            this.kissLabel14.Text = "PLZ / Ort / Kt";
            this.kissLabel14.UseCompatibleTextRendering = true;
            //
            // kissLabel11
            //
            this.kissLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel11.Location = new System.Drawing.Point(5, 363);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(80, 24);
            this.kissLabel11.TabIndex = 9;
            this.kissLabel11.Text = "Postfach";
            this.kissLabel11.UseCompatibleTextRendering = true;
            //
            // kissLabel13
            //
            this.kissLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel13.Location = new System.Drawing.Point(5, 317);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(80, 24);
            this.kissLabel13.TabIndex = 4;
            this.kissLabel13.Text = "Zusatz";
            this.kissLabel13.UseCompatibleTextRendering = true;
            //
            // kissLabel1
            //
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel1.Location = new System.Drawing.Point(5, 294);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(80, 24);
            this.kissLabel1.TabIndex = 2;
            this.kissLabel1.Text = "Name";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // lblInstitutionTypen
            //
            this.lblInstitutionTypen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInstitutionTypen.Location = new System.Drawing.Point(5, 439);
            this.lblInstitutionTypen.Name = "lblInstitutionTypen";
            this.lblInstitutionTypen.Size = new System.Drawing.Size(79, 24);
            this.lblInstitutionTypen.TabIndex = 17;
            this.lblInstitutionTypen.Text = "Typen";
            this.lblInstitutionTypen.UseCompatibleTextRendering = true;
            //
            // edtEinzahlungsschein
            //
            this.edtEinzahlungsschein.AllowNull = false;
            this.edtEinzahlungsschein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtEinzahlungsschein.DataMember = "EinzahlungsscheinCode";
            this.edtEinzahlungsschein.DataSource = this.qryBaZahlungsweg;
            this.edtEinzahlungsschein.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtEinzahlungsschein.Location = new System.Drawing.Point(481, 294);
            this.edtEinzahlungsschein.LOVName = "BgEinzahlungsschein";
            this.edtEinzahlungsschein.Name = "edtEinzahlungsschein";
            this.edtEinzahlungsschein.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtEinzahlungsschein.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinzahlungsschein.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzahlungsschein.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinzahlungsschein.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinzahlungsschein.Properties.Appearance.Options.UseFont = true;
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinzahlungsschein.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinzahlungsschein.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtEinzahlungsschein.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtEinzahlungsschein.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinzahlungsschein.Properties.Name = "kissLookUpEdit6.Properties";
            this.edtEinzahlungsschein.Properties.NullText = "";
            this.edtEinzahlungsschein.Properties.ReadOnly = true;
            this.edtEinzahlungsschein.Properties.ShowFooter = false;
            this.edtEinzahlungsschein.Properties.ShowHeader = false;
            this.edtEinzahlungsschein.Size = new System.Drawing.Size(290, 24);
            this.edtEinzahlungsschein.TabIndex = 21;
            //
            // edtPostkontoNr
            //
            this.edtPostkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtPostkontoNr.DataMember = "PC";
            this.edtPostkontoNr.DataSource = this.qryBaZahlungsweg;
            this.edtPostkontoNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtPostkontoNr.Location = new System.Drawing.Point(481, 317);
            this.edtPostkontoNr.Name = "edtPostkontoNr";
            this.edtPostkontoNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtPostkontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtPostkontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtPostkontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtPostkontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtPostkontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtPostkontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtPostkontoNr.Properties.MaxLength = 20;
            this.edtPostkontoNr.Properties.Name = "kissTextEdit14.Properties";
            this.edtPostkontoNr.Properties.ReadOnly = true;
            this.edtPostkontoNr.Size = new System.Drawing.Size(290, 24);
            this.edtPostkontoNr.TabIndex = 23;
            //
            // edtBankkontoNr
            //
            this.edtBankkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBankkontoNr.DataMember = "BankKontoNummer";
            this.edtBankkontoNr.DataSource = this.qryBaZahlungsweg;
            this.edtBankkontoNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBankkontoNr.Location = new System.Drawing.Point(481, 340);
            this.edtBankkontoNr.Name = "edtBankkontoNr";
            this.edtBankkontoNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBankkontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBankkontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBankkontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtBankkontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBankkontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtBankkontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBankkontoNr.Properties.MaxLength = 50;
            this.edtBankkontoNr.Properties.Name = "kissTextEdit13.Properties";
            this.edtBankkontoNr.Properties.ReadOnly = true;
            this.edtBankkontoNr.Size = new System.Drawing.Size(208, 24);
            this.edtBankkontoNr.TabIndex = 25;
            //
            // edtIBAN
            //
            this.edtIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtIBAN.DataMember = "IBANNummer";
            this.edtIBAN.DataSource = this.qryBaZahlungsweg;
            this.edtIBAN.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtIBAN.Location = new System.Drawing.Point(481, 386);
            this.edtIBAN.Name = "edtIBAN";
            this.edtIBAN.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtIBAN.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIBAN.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIBAN.Properties.Appearance.Options.UseBackColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIBAN.Properties.Appearance.Options.UseFont = true;
            this.edtIBAN.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtIBAN.Properties.MaxLength = 50;
            this.edtIBAN.Properties.Name = "kissTextEdit16.Properties";
            this.edtIBAN.Properties.ReadOnly = true;
            this.edtIBAN.Size = new System.Drawing.Size(290, 24);
            this.edtIBAN.TabIndex = 30;
            this.edtIBAN.TabStop = false;
            //
            // edtClearingNummer
            //
            this.edtClearingNummer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtClearingNummer.DataMember = "BankClearingNr";
            this.edtClearingNummer.DataSource = this.qryBaZahlungsweg;
            this.edtClearingNummer.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtClearingNummer.Location = new System.Drawing.Point(687, 340);
            this.edtClearingNummer.Name = "edtClearingNummer";
            this.edtClearingNummer.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtClearingNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtClearingNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtClearingNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtClearingNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtClearingNummer.Properties.Appearance.Options.UseFont = true;
            this.edtClearingNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtClearingNummer.Properties.ReadOnly = true;
            this.edtClearingNummer.Size = new System.Drawing.Size(84, 24);
            this.edtClearingNummer.TabIndex = 26;
            this.edtClearingNummer.TabStop = false;
            //
            // lblEinzahlungsschein
            //
            this.lblEinzahlungsschein.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEinzahlungsschein.Location = new System.Drawing.Point(379, 294);
            this.lblEinzahlungsschein.Name = "lblEinzahlungsschein";
            this.lblEinzahlungsschein.Size = new System.Drawing.Size(100, 23);
            this.lblEinzahlungsschein.TabIndex = 20;
            this.lblEinzahlungsschein.Text = "Einzahlungsschein";
            this.lblEinzahlungsschein.UseCompatibleTextRendering = true;
            //
            // lblBankPost
            //
            this.lblBankPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBankPost.Location = new System.Drawing.Point(379, 363);
            this.lblBankPost.Name = "lblBankPost";
            this.lblBankPost.Size = new System.Drawing.Size(100, 24);
            this.lblBankPost.TabIndex = 27;
            this.lblBankPost.Text = "Bank/Post";
            this.lblBankPost.UseCompatibleTextRendering = true;
            //
            // lblBankkontoNr
            //
            this.lblBankkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBankkontoNr.Location = new System.Drawing.Point(379, 340);
            this.lblBankkontoNr.Name = "lblBankkontoNr";
            this.lblBankkontoNr.Size = new System.Drawing.Size(100, 23);
            this.lblBankkontoNr.TabIndex = 24;
            this.lblBankkontoNr.Text = "Bank Konto-Nr.";
            this.lblBankkontoNr.UseCompatibleTextRendering = true;
            //
            // lblPostKonto
            //
            this.lblPostKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblPostKonto.Location = new System.Drawing.Point(379, 317);
            this.lblPostKonto.Name = "lblPostKonto";
            this.lblPostKonto.Size = new System.Drawing.Size(100, 23);
            this.lblPostKonto.TabIndex = 22;
            this.lblPostKonto.Text = "Postkonto-Nr.";
            this.lblPostKonto.UseCompatibleTextRendering = true;
            //
            // lblIBAN
            //
            this.lblIBAN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblIBAN.Location = new System.Drawing.Point(379, 386);
            this.lblIBAN.Name = "lblIBAN";
            this.lblIBAN.Size = new System.Drawing.Size(60, 24);
            this.lblIBAN.TabIndex = 29;
            this.lblIBAN.Text = "IBAN";
            this.lblIBAN.UseCompatibleTextRendering = true;
            //
            // kissTextEdit1
            //
            this.kissTextEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit1.DataMember = "Bankname";
            this.kissTextEdit1.DataSource = this.qryBaZahlungsweg;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(481, 363);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.MaxLength = 50;
            this.kissTextEdit1.Properties.Name = "kissTextEdit16.Properties";
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(290, 24);
            this.kissTextEdit1.TabIndex = 28;
            this.kissTextEdit1.TabStop = false;
            //
            // kissLabel2
            //
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel2.Location = new System.Drawing.Point(90, 269);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(100, 16);
            this.kissLabel2.TabIndex = 1;
            this.kissLabel2.Text = "Institution";
            this.kissLabel2.UseCompatibleTextRendering = true;
            //
            // kissLabel3
            //
            this.kissLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.kissLabel3.Location = new System.Drawing.Point(481, 269);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(100, 16);
            this.kissLabel3.TabIndex = 19;
            this.kissLabel3.Text = "Zahlinfo";
            this.kissLabel3.UseCompatibleTextRendering = true;
            //
            // edtFilter
            //
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFilter.Location = new System.Drawing.Point(481, 439);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Properties.MaxLength = 50;
            this.edtFilter.Properties.Name = "kissTextEdit16.Properties";
            this.edtFilter.Size = new System.Drawing.Size(290, 24);
            this.edtFilter.TabIndex = 32;
            this.edtFilter.TabStop = false;
            this.edtFilter.EditValueChanged += new System.EventHandler(this.edtFilter_EditValueChanged);
            this.edtFilter.Click += new System.EventHandler(this.edtFilter_Click);
            //
            // kissLabel4
            //
            this.kissLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel4.Location = new System.Drawing.Point(379, 439);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(100, 24);
            this.kissLabel4.TabIndex = 31;
            this.kissLabel4.Text = "Filter (Name,Strasse,Ort)";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // btnOK
            //
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(585, 478);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 24);
            this.btnOK.TabIndex = 33;
            this.btnOK.Text = "OK";
            this.btnOK.UseCompatibleTextRendering = true;
            this.btnOK.UseVisualStyleBackColor = true;
            //
            // btnAbbruch
            //
            this.btnAbbruch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbruch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbruch.Location = new System.Drawing.Point(681, 478);
            this.btnAbbruch.Name = "btnAbbruch";
            this.btnAbbruch.Size = new System.Drawing.Size(90, 24);
            this.btnAbbruch.TabIndex = 34;
            this.btnAbbruch.Text = "Abbruch";
            this.btnAbbruch.UseCompatibleTextRendering = true;
            this.btnAbbruch.UseVisualStyleBackColor = true;
            //
            // edtInstitutionTypen
            //
            this.edtInstitutionTypen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtInstitutionTypen.DataMember = "InstitutionTypenD";
            this.edtInstitutionTypen.DataSource = this.qryBaZahlungsweg;
            this.edtInstitutionTypen.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtInstitutionTypen.Location = new System.Drawing.Point(90, 439);
            this.edtInstitutionTypen.Name = "edtInstitutionTypen";
            this.edtInstitutionTypen.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtInstitutionTypen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitutionTypen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitutionTypen.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitutionTypen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitutionTypen.Properties.Appearance.Options.UseFont = true;
            this.edtInstitutionTypen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInstitutionTypen.Properties.ReadOnly = true;
            this.edtInstitutionTypen.Size = new System.Drawing.Size(270, 24);
            this.edtInstitutionTypen.TabIndex = 18;
            //
            // DlgAuswahlBaZahlungsweg
            //
            this.AcceptButton = this.btnOK;
            this.ActiveSQLQuery = this.qryBaZahlungsweg;
            this.CancelButton = this.btnAbbruch;
            this.ClientSize = new System.Drawing.Size(778, 507);
            this.Controls.Add(this.edtInstitutionTypen);
            this.Controls.Add(this.btnAbbruch);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.kissLabel4);
            this.Controls.Add(this.edtFilter);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.kissTextEdit1);
            this.Controls.Add(this.lblIBAN);
            this.Controls.Add(this.lblPostKonto);
            this.Controls.Add(this.lblBankkontoNr);
            this.Controls.Add(this.lblBankPost);
            this.Controls.Add(this.lblEinzahlungsschein);
            this.Controls.Add(this.edtClearingNummer);
            this.Controls.Add(this.edtIBAN);
            this.Controls.Add(this.edtBankkontoNr);
            this.Controls.Add(this.edtPostkontoNr);
            this.Controls.Add(this.edtEinzahlungsschein);
            this.Controls.Add(this.lblInstitutionTypen);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.kissLabel13);
            this.Controls.Add(this.kissLabel11);
            this.Controls.Add(this.kissLabel14);
            this.Controls.Add(this.kissLabel12);
            this.Controls.Add(this.kissLabel18);
            this.Controls.Add(this.edtKanton);
            this.Controls.Add(this.cboLand);
            this.Controls.Add(this.edtOrt);
            this.Controls.Add(this.edtPLZ);
            this.Controls.Add(this.edtPostfach);
            this.Controls.Add(this.edtHausNr);
            this.Controls.Add(this.edtStrasse);
            this.Controls.Add(this.edtAdressZusatz);
            this.Controls.Add(this.edtName);
            this.Controls.Add(this.grdKreditor);
            this.Name = "DlgAuswahlBaZahlungsweg";
            this.Text = "Auswahl Zahlungsweg";
            ((System.ComponentModel.ISupportInitialize)(this.grdKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaZahlungsweg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKreditor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAdressZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHausNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostfach.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKanton.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInstitutionTypen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinzahlungsschein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPostkontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBankkontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIBAN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtClearingNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinzahlungsschein)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBankkontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblPostKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblIBAN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitutionTypen.Properties)).EndInit();
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

        #region Properties

        public object BaZahlungswegID
        {
            get { return this["BaZahlungswegID"]; }
        }

        public int Count
        {
            get { return qryBaZahlungsweg.Count; }
        }

        #endregion

        #region Indexers

        public object this[string ColumnName]
        {
            get
            {
                System.Diagnostics.Debug.WriteLine("Get Value for " + ColumnName);
                System.Diagnostics.Debug.WriteLine(qryBaZahlungsweg[ColumnName].ToString());
                return qryBaZahlungsweg[ColumnName];
            }
        }

        #endregion

        #region EventHandlers

        private void DlgAuswahlBaZahlungsweg_KeyPress(
            object sender,
            System.Windows.Forms.KeyPressEventArgs e)
        {
            if (firsttime && String.IsNullOrEmpty(edtFilter.Text))
            {
                //System.Diagnostics.Debug.WriteLine("DlgKgAuswahlZahlungsweg_KeypPress: " + e.KeyChar.ToString());
                firsttime = false;
                edtFilter.Text = e.KeyChar.ToString();
                edtFilter.Focus();
                edtFilter.SelectionStart = 1;
            }
        }

        private void edtFilter_Click(object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("edtFiler.Click");
            firsttime = false;
        }

        private void edtFilter_EditValueChanged(object sender, System.EventArgs e)
        {
            string Value = edtFilter.EditValue.ToString();
            qryBaZahlungsweg.DataTable.DefaultView.RowFilter = "Kreditor like '%" + Value + "%' or Strasse like '%" + Value + "%' or Ort like '%" + Value + "%'";
        }

        private void grdKreditor_DoubleClick(object sender, System.EventArgs e)
        {
            if (qryBaZahlungsweg.Count > 1)
            {
                btnOK.PerformClick();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void SucheBaZahlungsweg(Belegleser beleg)
        {
            qryBaZahlungsweg.Fill(qryBaZahlungsweg.SelectStatement, beleg.KontoNummer.Replace('-', '%'), Session.User.UserID, Session.User.LanguageCode);
        }

        public void SucheBaZahlungsweg(string searchValue)
        {
            qryBaZahlungsweg.Fill(qryBaZahlungsweg.SelectStatement, "%" + searchValue.Replace(' ', '%') + "%", Session.User.UserID, Session.User.LanguageCode);
        }

        #endregion

        #endregion
    }
}