#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#endregion

using System;
using System.Data;
using KiSS4.DB;

namespace KiSS4.Basis.ZH
{
    public class CtlBaPersonVermoegen : KiSS4.Gui.KissUserControl
    {
        #region Fields

        // ComponentName: qryBaVermoegen
        private int baPersonID = -1;
        private KiSS4.Gui.KissButton btnKopieren;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colLiquid;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuld;
        private DevExpress.XtraGrid.Columns.GridColumn colStandAm;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colVermoegen;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissDateEdit edtDatumStandAm;
        private KiSS4.Gui.KissCheckEdit edtLiquid;
        private KiSS4.Gui.KissCalcEdit edtNr;
        private KiSS4.Gui.KissCheckEdit edtNurAktive;
        private KiSS4.Gui.KissLookUpEdit edtTyp;
        private KiSS4.Gui.KissGrid grdBaErsatzeinkommen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBaErsatzeinkommen;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblCHF;
        private KiSS4.Gui.KissLabel lblNr;
        private KiSS4.Gui.KissLabel lblStandAm;
        private KiSS4.Gui.KissLabel lblTyp;
        private KiSS4.Gui.KissMemoEdit memBemerkungen;
        private KiSS4.DB.SqlQuery qryBaVermoegen;

        #endregion

        #region Constructors

        public CtlBaPersonVermoegen()
        {
            this.InitializeComponent();

            // In Design-Mode this throws an exception, and I couldn't fix it with checking for DesignMode (not sure why)
            try
            {
                this.colTyp.ColumnEdit = this.grdBaErsatzeinkommen.GetLOVLookUpEdit("BaVermoegenSchuld");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine("CtlBaPersonVermoegen.CtlBaPersonVermoegen(): " + ex.Message);
            }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaPersonVermoegen));
            this.grdBaErsatzeinkommen = new KiSS4.Gui.KissGrid();
            this.edtDatumStandAm = new KiSS4.Gui.KissDateEdit();
            this.lblTyp = new KiSS4.Gui.KissLabel();
            this.edtTyp = new KiSS4.Gui.KissLookUpEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtLiquid = new KiSS4.Gui.KissCheckEdit();
            this.memBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.btnKopieren = new KiSS4.Gui.KissButton();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.lblCHF = new KiSS4.Gui.KissLabel();
            this.lblStandAm = new KiSS4.Gui.KissLabel();
            this.edtNr = new KiSS4.Gui.KissCalcEdit();
            this.lblNr = new KiSS4.Gui.KissLabel();
            this.edtNurAktive = new KiSS4.Gui.KissCheckEdit();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLiquid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStandAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVermoegen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvBaErsatzeinkommen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryBaVermoegen = new KiSS4.DB.SqlQuery(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaErsatzeinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumStandAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLiquid.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandAm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaErsatzeinkommen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaVermoegen)).BeginInit();
            this.SuspendLayout();
            //
            // grdBaErsatzeinkommen
            //
            this.grdBaErsatzeinkommen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdBaErsatzeinkommen.DataSource = this.qryBaVermoegen;
            this.grdBaErsatzeinkommen.EmbeddedNavigator.Name = "gridCtlKiSS3UserMask_Vm_Massnahme_MF_Verwaltung_SozialVers.EmbeddedNavigator";
            this.grdBaErsatzeinkommen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBaErsatzeinkommen.Location = new System.Drawing.Point(5, 33);
            this.grdBaErsatzeinkommen.MainView = this.grvBaErsatzeinkommen;
            this.grdBaErsatzeinkommen.Name = "grdBaErsatzeinkommen";
            this.grdBaErsatzeinkommen.Size = new System.Drawing.Size(687, 316);
            this.grdBaErsatzeinkommen.TabIndex = 0;
            this.grdBaErsatzeinkommen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvBaErsatzeinkommen});
            //
            // edtDatumStandAm
            //
            this.edtDatumStandAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumStandAm.DataMember = "StandAm";
            this.edtDatumStandAm.DataSource = this.qryBaVermoegen;
            this.edtDatumStandAm.EditValue = null;
            this.edtDatumStandAm.Location = new System.Drawing.Point(80, 364);
            this.edtDatumStandAm.Name = "edtDatumStandAm";
            this.edtDatumStandAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtDatumStandAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumStandAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumStandAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumStandAm.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumStandAm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumStandAm.Properties.Appearance.Options.UseFont = true;
            this.edtDatumStandAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatumStandAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtDatumStandAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumStandAm.Properties.ShowToday = false;
            this.edtDatumStandAm.Size = new System.Drawing.Size(100, 24);
            this.edtDatumStandAm.TabIndex = 1;
            //
            // lblTyp
            //
            this.lblTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTyp.Location = new System.Drawing.Point(5, 394);
            this.lblTyp.Name = "lblTyp";
            this.lblTyp.Size = new System.Drawing.Size(69, 24);
            this.lblTyp.TabIndex = 1;
            this.lblTyp.Text = "Typ";
            this.lblTyp.UseCompatibleTextRendering = true;
            //
            // edtTyp
            //
            this.edtTyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTyp.DataMember = "BaVermoegenSchuldCode";
            this.edtTyp.DataSource = this.qryBaVermoegen;
            this.edtTyp.Location = new System.Drawing.Point(80, 394);
            this.edtTyp.LOVName = "BaVermoegenSchuld";
            this.edtTyp.Name = "edtTyp";
            this.edtTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTyp.Properties.Appearance.Options.UseFont = true;
            this.edtTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTyp.Properties.Name = "edtVmMfSozialversBezeichnung.Properties";
            this.edtTyp.Properties.NullText = "";
            this.edtTyp.Properties.ShowFooter = false;
            this.edtTyp.Properties.ShowHeader = false;
            this.edtTyp.Size = new System.Drawing.Size(282, 24);
            this.edtTyp.TabIndex = 2;
            //
            // edtBetrag
            //
            this.edtBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBaVermoegen;
            this.edtBetrag.Location = new System.Drawing.Point(80, 424);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.Mask.EditMask = "n2";
            this.edtBetrag.Properties.Name = "edtVmMfSozialversVerfügungsbetrag.Properties";
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 3;
            //
            // edtLiquid
            //
            this.edtLiquid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtLiquid.DataMember = "Liquid";
            this.edtLiquid.DataSource = this.qryBaVermoegen;
            this.edtLiquid.Location = new System.Drawing.Point(262, 428);
            this.edtLiquid.Name = "edtLiquid";
            this.edtLiquid.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtLiquid.Properties.Appearance.Options.UseBackColor = true;
            this.edtLiquid.Properties.Caption = "Liquid";
            this.edtLiquid.Size = new System.Drawing.Size(75, 19);
            this.edtLiquid.TabIndex = 4;
            //
            // memBemerkungen
            //
            this.memBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.memBemerkungen.DataMember = "Bemerkung";
            this.memBemerkungen.DataSource = this.qryBaVermoegen;
            this.memBemerkungen.Location = new System.Drawing.Point(80, 456);
            this.memBemerkungen.Name = "memBemerkungen";
            this.memBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungen.Properties.MaxLength = 300;
            this.memBemerkungen.Size = new System.Drawing.Size(612, 40);
            this.memBemerkungen.TabIndex = 5;
            //
            // btnKopieren
            //
            this.btnKopieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKopieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKopieren.Location = new System.Drawing.Point(391, 364);
            this.btnKopieren.Name = "btnKopieren";
            this.btnKopieren.Size = new System.Drawing.Size(125, 24);
            this.btnKopieren.TabIndex = 6;
            this.btnKopieren.Text = "Eintrag anpassen";
            this.btnKopieren.UseCompatibleTextRendering = true;
            this.btnKopieren.UseVisualStyleBackColor = false;
            this.btnKopieren.Click += new System.EventHandler(this.btnKopieren_Click);
            //
            // lblBetrag
            //
            this.lblBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetrag.Location = new System.Drawing.Point(5, 424);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(71, 24);
            this.lblBetrag.TabIndex = 7;
            this.lblBetrag.Text = "Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkungen.Location = new System.Drawing.Point(5, 456);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(71, 24);
            this.lblBemerkungen.TabIndex = 11;
            this.lblBemerkungen.Text = "Bemerkung";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            //
            // lblCHF
            //
            this.lblCHF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCHF.Location = new System.Drawing.Point(187, 424);
            this.lblCHF.Name = "lblCHF";
            this.lblCHF.Size = new System.Drawing.Size(28, 24);
            this.lblCHF.TabIndex = 103;
            this.lblCHF.Text = "CHF";
            this.lblCHF.UseCompatibleTextRendering = true;
            //
            // lblStandAm
            //
            this.lblStandAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStandAm.Location = new System.Drawing.Point(5, 364);
            this.lblStandAm.Name = "lblStandAm";
            this.lblStandAm.Size = new System.Drawing.Size(71, 24);
            this.lblStandAm.TabIndex = 105;
            this.lblStandAm.Text = "Stand am";
            this.lblStandAm.UseCompatibleTextRendering = true;
            //
            // edtNr
            //
            this.edtNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtNr.DataMember = "Nr";
            this.edtNr.DataSource = this.qryBaVermoegen;
            this.edtNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtNr.Location = new System.Drawing.Point(391, 394);
            this.edtNr.Name = "edtNr";
            this.edtNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNr.Properties.Appearance.Options.UseFont = true;
            this.edtNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNr.Properties.ReadOnly = true;
            this.edtNr.Size = new System.Drawing.Size(55, 24);
            this.edtNr.TabIndex = 107;
            //
            // lblNr
            //
            this.lblNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNr.Location = new System.Drawing.Point(368, 394);
            this.lblNr.Name = "lblNr";
            this.lblNr.Size = new System.Drawing.Size(17, 24);
            this.lblNr.TabIndex = 108;
            this.lblNr.Text = "Nr.";
            this.lblNr.UseCompatibleTextRendering = true;
            //
            // edtNurAktive
            //
            this.edtNurAktive.EditValue = true;
            this.edtNurAktive.Location = new System.Drawing.Point(5, 4);
            this.edtNurAktive.Name = "edtNurAktive";
            this.edtNurAktive.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurAktive.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAktive.Properties.Caption = "Nur Aktive anzeigen";
            this.edtNurAktive.Size = new System.Drawing.Size(129, 19);
            this.edtNurAktive.TabIndex = 110;
            this.edtNurAktive.EditValueChanged += new System.EventHandler(this.edtNurAktive_EditValueChanged);
            //
            // colBemerkung
            //
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.FieldName = "Bemerkung";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 6;
            this.colBemerkung.Width = 241;
            //
            // colLiquid
            //
            this.colLiquid.Caption = "Liquid";
            this.colLiquid.FieldName = "Liquid";
            this.colLiquid.Name = "colLiquid";
            this.colLiquid.Visible = true;
            this.colLiquid.VisibleIndex = 4;
            this.colLiquid.Width = 45;
            //
            // colNr
            //
            this.colNr.Caption = "Nr.";
            this.colNr.FieldName = "Nr";
            this.colNr.Name = "colNr";
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 2;
            this.colNr.Width = 46;
            //
            // colSchuld
            //
            this.colSchuld.Caption = "Schuld";
            this.colSchuld.DisplayFormat.FormatString = "n2";
            this.colSchuld.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSchuld.FieldName = "BetragSchuld";
            this.colSchuld.Name = "colSchuld";
            this.colSchuld.SummaryItem.DisplayFormat = "n2";
            this.colSchuld.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colSchuld.Visible = true;
            this.colSchuld.VisibleIndex = 5;
            this.colSchuld.Width = 100;
            //
            // colStandAm
            //
            this.colStandAm.Caption = "Stand am";
            this.colStandAm.FieldName = "StandAm";
            this.colStandAm.Name = "colStandAm";
            this.colStandAm.Visible = true;
            this.colStandAm.VisibleIndex = 0;
            //
            // colTyp
            //
            this.colTyp.Caption = "Typ";
            this.colTyp.FieldName = "BaVermoegenSchuldCode";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 1;
            this.colTyp.Width = 221;
            //
            // colVermoegen
            //
            this.colVermoegen.Caption = "Vermögen";
            this.colVermoegen.DisplayFormat.FormatString = "n2";
            this.colVermoegen.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVermoegen.FieldName = "BetragVermoegen";
            this.colVermoegen.Name = "colVermoegen";
            this.colVermoegen.Visible = true;
            this.colVermoegen.VisibleIndex = 3;
            this.colVermoegen.Width = 100;
            //
            // grvBaErsatzeinkommen
            //
            this.grvBaErsatzeinkommen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBaErsatzeinkommen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.Empty.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.Empty.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.EvenRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBaErsatzeinkommen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaErsatzeinkommen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBaErsatzeinkommen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBaErsatzeinkommen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaErsatzeinkommen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.OddRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBaErsatzeinkommen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.Row.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.Appearance.Row.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBaErsatzeinkommen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBaErsatzeinkommen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBaErsatzeinkommen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBaErsatzeinkommen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBaErsatzeinkommen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colStandAm,
                        this.colTyp,
                        this.colNr,
                        this.colVermoegen,
                        this.colLiquid,
                        this.colSchuld,
                        this.colBemerkung});
            this.grvBaErsatzeinkommen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBaErsatzeinkommen.GridControl = this.grdBaErsatzeinkommen;
            this.grvBaErsatzeinkommen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvBaErsatzeinkommen.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
                        new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragVermoegen", this.colVermoegen, "n2"),
                        new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "BetragSchuld", this.colSchuld, "n2")});
            this.grvBaErsatzeinkommen.Name = "grvBaErsatzeinkommen";
            this.grvBaErsatzeinkommen.OptionsBehavior.Editable = false;
            this.grvBaErsatzeinkommen.OptionsCustomization.AllowFilter = false;
            this.grvBaErsatzeinkommen.OptionsFilter.AllowFilterEditor = false;
            this.grvBaErsatzeinkommen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBaErsatzeinkommen.OptionsMenu.EnableColumnMenu = false;
            this.grvBaErsatzeinkommen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBaErsatzeinkommen.OptionsNavigation.UseTabKey = false;
            this.grvBaErsatzeinkommen.OptionsView.ColumnAutoWidth = false;
            this.grvBaErsatzeinkommen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBaErsatzeinkommen.OptionsView.ShowGroupPanel = false;
            this.grvBaErsatzeinkommen.OptionsView.ShowIndicator = false;
            //
            // qryBaVermoegen
            //
            this.qryBaVermoegen.CanDelete = true;
            this.qryBaVermoegen.CanInsert = true;
            this.qryBaVermoegen.HostControl = this;
            this.qryBaVermoegen.SelectStatement = resources.GetString("qryBaVermoegen.SelectStatement");
            this.qryBaVermoegen.TableName = "BaVermoegen";
            this.qryBaVermoegen.PositionChanged += new System.EventHandler(this.qryBaVermoegen_PositionChanged);
            this.qryBaVermoegen.BeforePost += new System.EventHandler(this.qryBaVermoegen_BeforePost);
            this.qryBaVermoegen.AfterInsert += new System.EventHandler(this.qryBaVermoegen_AfterInsert);
            //
            // CtlBaPersonVermoegen
            //
            this.ActiveSQLQuery = this.qryBaVermoegen;
            this.Controls.Add(this.edtNurAktive);
            this.Controls.Add(this.lblNr);
            this.Controls.Add(this.edtNr);
            this.Controls.Add(this.lblStandAm);
            this.Controls.Add(this.lblCHF);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.lblBetrag);
            this.Controls.Add(this.btnKopieren);
            this.Controls.Add(this.memBemerkungen);
            this.Controls.Add(this.edtLiquid);
            this.Controls.Add(this.edtBetrag);
            this.Controls.Add(this.edtTyp);
            this.Controls.Add(this.lblTyp);
            this.Controls.Add(this.edtDatumStandAm);
            this.Controls.Add(this.grdBaErsatzeinkommen);
            this.Name = "CtlBaPersonVermoegen";
            this.Size = new System.Drawing.Size(715, 507);
            ((System.ComponentModel.ISupportInitialize)(this.grdBaErsatzeinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumStandAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLiquid.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStandAm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAktive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBaErsatzeinkommen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaVermoegen)).EndInit();
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

        #region Public Properties

        [System.ComponentModel.DefaultValue(-1)]
        public int BaPersonID
        {
            get{ return baPersonID; }
            set{
                baPersonID = value;
                qryBaVermoegen.Fill(value, edtNurAktive.Checked);
            }
        }

        #endregion

        #region Private Methods

        private int GetNextNr(int baVermoegenSchuldCode)
        {
            return (int) DBUtil.ExecuteScalarSQL(@"
                        SELECT isNull(MAX(Nr), 0) + 1
                        FROM BaVermoegen
                        WHERE BaPersonID = {0}
                          AND BaVermoegenSchuldCode = {1}", this.BaPersonID, baVermoegenSchuldCode);
        }

        private void btnKopieren_Click(object sender, System.EventArgs e)
        {
            int nr  = (int)qryBaVermoegen["Nr"];
            int typ = (int)qryBaVermoegen["BaVermoegenSchuldCode"];

            qryBaVermoegen.Insert();

            qryBaVermoegen["Nr"] = nr;
            qryBaVermoegen["BaVermoegenSchuldCode"] = typ;
            qryBaVermoegen["StandAm"] = DateTime.Today;
        }

        private void edtNurAktive_EditValueChanged(object sender, System.EventArgs e)
        {
            qryBaVermoegen.Fill(this.BaPersonID, edtNurAktive.Checked);
        }

        private void qryBaVermoegen_AfterInsert(object sender, System.EventArgs e)
        {
            qryBaVermoegen["BaPersonID"] = BaPersonID;
            edtDatumStandAm.Focus();
        }

        private void qryBaVermoegen_BeforePost(object sender, System.EventArgs e)
        {
            // Control "edtTyp" can not be empty
            if (DBUtil.IsEmpty(qryBaVermoegen["BaVermoegenSchuldCode"]))
            {
              edtTyp.Focus();
              KissMsg.ShowInfo("CtlBaPersonVermoegen", "TypLeer", "Typ darf nicht leer sein.");
              throw new KissCancelException();
            }

            // Control "edtBetrag" can not be empty
            if (DBUtil.IsEmpty(qryBaVermoegen["Betrag"]))
            {
              edtBetrag.Focus();
              KissMsg.ShowInfo("CtlBaPersonVermoegen", "BetragLeer", "Betrag darf nicht leer sein.");
              throw new KissCancelException();
            }
            // Control "edtBetrag" has to be > 0
            else if ((decimal)(qryBaVermoegen["Betrag"]) <= 0)
            {
              edtBetrag.Focus();
              KissMsg.ShowInfo("CtlBaPersonVermoegen", "BetragKleinerNull", "Betrag muss grösser als 0 sein.");
              throw new KissCancelException();
            }

            if ((int)qryBaVermoegen["BaVermoegenSchuldCode"] < 100)
            {
                qryBaVermoegen["BetragVermoegen"] = qryBaVermoegen["Betrag"];
                qryBaVermoegen["BetragSchuld"] = null;
            }
            else
            {
                qryBaVermoegen["BetragSchuld"] = qryBaVermoegen["Betrag"];
                qryBaVermoegen["BetragVermoegen"] = null;
            }

            if(DBUtil.IsEmpty(qryBaVermoegen["Nr"]) || (int)qryBaVermoegen["Nr"] <= 0)
                qryBaVermoegen["Nr"] = this.GetNextNr((int)qryBaVermoegen["BaVermoegenSchuldCode"]);
        }

        private void qryBaVermoegen_PositionChanged(object sender, System.EventArgs e)
        {
            qryBaVermoegen.CanUpdate = qryBaVermoegen.Row.RowState == DataRowState.Added;
            qryBaVermoegen.EnableBoundFields(qryBaVermoegen.CanUpdate);
        }

        #endregion
    }
}