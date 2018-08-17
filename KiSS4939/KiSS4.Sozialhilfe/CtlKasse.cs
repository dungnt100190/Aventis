using System;
using System.Windows.Forms;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe
{
    public class CtlKasse : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _tageZuVerfalldatum;
        private KiSS4.Gui.KissButton btnAuszahlen;
        private KiSS4.Gui.KissButton btnFallInfo;
        private KiSS4.Gui.KissCheckEdit chkAusbezahltX;
        private KiSS4.Gui.KissCheckEdit chkGesperrtX;
        private KiSS4.Gui.KissCheckEdit chkNichtAusbezahltX;
        private DevExpress.XtraGrid.Columns.GridColumn colAusbezahlt;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colVerfalldatum;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit editDatumBisX;
        private KiSS4.Gui.KissDateEdit editDatumVonX;
        private KiSS4.Gui.KissButtonEdit editPersonX;
        private KiSS4.Gui.KissTextEdit edtMitteilung1;
        private KiSS4.Gui.KissTextEdit edtMitteilung2;
        private KiSS4.Gui.KissTextEdit edtMitteilung3;
        private KissTextEdit edtVersNr;
        private KiSS4.Gui.KissGrid gridBelege;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private KiSS4.Gui.KissDateEdit kissDateEdit1;
        private KiSS4.Gui.KissDateEdit kissDateEdit2;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel13;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel20;
        private KiSS4.Gui.KissLabel kissLabel21;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private KiSS4.Gui.KissTextEdit kissTextEdit3;
        private KiSS4.Gui.KissTextEdit kissTextEdit4;
        private KiSS4.Gui.KissTextEdit kissTextEdit5;
        private KiSS4.Gui.KissTextEdit kissTextEdit6;
        private KiSS4.Gui.KissTextEdit kissTextEdit7;
        private KiSS4.Gui.KissTextEdit kissTextEdit8;
        private SharpLibrary.WinControls.TabPageEx lastSelectedTab;
        private KiSS4.Gui.KissLabel lblAuszahlungAn;
        private KiSS4.Gui.KissLabel lblMonatsbudget;
        private KissLabel lblVersNr;
        private System.Windows.Forms.Panel panel3;
        private KiSS4.DB.SqlQuery qryBeleg;
        private KiSS4.Gui.KissTabControlEx tabControlSearch;
        private SharpLibrary.WinControls.TabPageEx tpgListe;
        private SharpLibrary.WinControls.TabPageEx tpgSuchen;

        #endregion

        #endregion

        #region Constructors

        public CtlKasse()
        {
            this.InitializeComponent();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKasse));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tabControlSearch = new KiSS4.Gui.KissTabControlEx();
            this.tpgSuchen = new SharpLibrary.WinControls.TabPageEx();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.chkGesperrtX = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.chkAusbezahltX = new KiSS4.Gui.KissCheckEdit();
            this.chkNichtAusbezahltX = new KiSS4.Gui.KissCheckEdit();
            this.editDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.editDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.editPersonX = new KiSS4.Gui.KissButtonEdit();
            this.tpgListe = new SharpLibrary.WinControls.TabPageEx();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gridBelege = new KiSS4.Gui.KissGrid();
            this.qryBeleg = new KiSS4.DB.SqlQuery(this.components);
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerfalldatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusbezahlt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit3 = new KiSS4.Gui.KissTextEdit();
            this.kissDateEdit1 = new KiSS4.Gui.KissDateEdit();
            this.kissTextEdit4 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit5 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit6 = new KiSS4.Gui.KissTextEdit();
            this.kissDateEdit2 = new KiSS4.Gui.KissDateEdit();
            this.kissTextEdit7 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit8 = new KiSS4.Gui.KissTextEdit();
            this.btnFallInfo = new KiSS4.Gui.KissButton();
            this.btnAuszahlen = new KiSS4.Gui.KissButton();
            this.lblMonatsbudget = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.kissLabel20 = new KiSS4.Gui.KissLabel();
            this.kissLabel21 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.edtMitteilung1 = new KiSS4.Gui.KissTextEdit();
            this.lblAuszahlungAn = new KiSS4.Gui.KissLabel();
            this.edtMitteilung2 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilung3 = new KiSS4.Gui.KissTextEdit();
            this.lblVersNr = new KiSS4.Gui.KissLabel();
            this.edtVersNr = new KiSS4.Gui.KissTextEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGesperrtX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAusbezahltX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNichtAusbezahltX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPersonX.Properties)).BeginInit();
            this.tpgListe.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBelege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeleg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit8.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungAn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Controls.Add(this.tpgSuchen);
            this.tabControlSearch.Controls.Add(this.tpgListe);
            this.tabControlSearch.Location = new System.Drawing.Point(4, 28);
            this.tabControlSearch.Name = "tabControlSearch";
            this.tabControlSearch.ShowFixedWidthTooltip = true;
            this.tabControlSearch.Size = new System.Drawing.Size(808, 240);
            this.tabControlSearch.TabIndex = 0;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe,
            this.tpgSuchen});
            this.tabControlSearch.TabsLineColor = System.Drawing.Color.Black;
            this.tabControlSearch.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabControlSearch.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabControlSearch_SelectedTabChanging);
            this.tabControlSearch.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabControlSearch_SelectedTabChanged);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.kissSearchTitel1);
            this.tpgSuchen.Controls.Add(this.kissLabel7);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Controls.Add(this.kissLabel6);
            this.tpgSuchen.Controls.Add(this.chkGesperrtX);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.chkAusbezahltX);
            this.tpgSuchen.Controls.Add(this.chkNichtAusbezahltX);
            this.tpgSuchen.Controls.Add(this.editDatumBisX);
            this.tpgSuchen.Controls.Add(this.editDatumVonX);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.editPersonX);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Name = "tpgSuchen";
            this.tpgSuchen.Size = new System.Drawing.Size(796, 202);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Title = "Suchen";
            //
            // kissSearchTitel1
            //
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(17, 4);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 15;
            //
            // kissLabel7
            //
            this.kissLabel7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel7.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel7.Location = new System.Drawing.Point(360, 38);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(156, 24);
            this.kissLabel7.TabIndex = 14;
            this.kissLabel7.Text = "Belegstatus";
            this.kissLabel7.UseCompatibleTextRendering = true;
            //
            // kissLabel4
            //
            this.kissLabel4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel4.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel4.Location = new System.Drawing.Point(12, 108);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(156, 24);
            this.kissLabel4.TabIndex = 9;
            this.kissLabel4.Text = "Verfalldatum";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(12, 162);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(66, 24);
            this.kissLabel5.TabIndex = 7;
            this.kissLabel5.Text = "bis";
            this.kissLabel5.UseCompatibleTextRendering = true;
            //
            // kissLabel6
            //
            this.kissLabel6.Location = new System.Drawing.Point(12, 132);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(66, 24);
            this.kissLabel6.TabIndex = 5;
            this.kissLabel6.Text = "von";
            this.kissLabel6.UseCompatibleTextRendering = true;
            //
            // chkGesperrtX
            //
            this.chkGesperrtX.EditValue = false;
            this.chkGesperrtX.Location = new System.Drawing.Point(360, 112);
            this.chkGesperrtX.Name = "chkGesperrtX";
            this.chkGesperrtX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkGesperrtX.Properties.Appearance.Options.UseBackColor = true;
            this.chkGesperrtX.Properties.Caption = "gesperrt";
            this.chkGesperrtX.Size = new System.Drawing.Size(150, 19);
            this.chkGesperrtX.TabIndex = 5;
            //
            // kissLabel3
            //
            this.kissLabel3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel3.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel3.Location = new System.Drawing.Point(12, 38);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(156, 24);
            this.kissLabel3.TabIndex = 4;
            this.kissLabel3.Text = "Fallträger";
            this.kissLabel3.UseCompatibleTextRendering = true;
            //
            // chkAusbezahltX
            //
            this.chkAusbezahltX.EditValue = false;
            this.chkAusbezahltX.Location = new System.Drawing.Point(360, 88);
            this.chkAusbezahltX.Name = "chkAusbezahltX";
            this.chkAusbezahltX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkAusbezahltX.Properties.Appearance.Options.UseBackColor = true;
            this.chkAusbezahltX.Properties.Caption = "ausgedruckt";
            this.chkAusbezahltX.Size = new System.Drawing.Size(222, 19);
            this.chkAusbezahltX.TabIndex = 4;
            //
            // chkNichtAusbezahltX
            //
            this.chkNichtAusbezahltX.EditValue = true;
            this.chkNichtAusbezahltX.Location = new System.Drawing.Point(360, 64);
            this.chkNichtAusbezahltX.Name = "chkNichtAusbezahltX";
            this.chkNichtAusbezahltX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkNichtAusbezahltX.Properties.Appearance.Options.UseBackColor = true;
            this.chkNichtAusbezahltX.Properties.Caption = "noch nicht ausgedruckt";
            this.chkNichtAusbezahltX.Size = new System.Drawing.Size(150, 19);
            this.chkNichtAusbezahltX.TabIndex = 3;
            //
            // editDatumBisX
            //
            this.editDatumBisX.EditValue = null;
            this.editDatumBisX.Location = new System.Drawing.Point(84, 162);
            this.editDatumBisX.Name = "editDatumBisX";
            this.editDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.editDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.editDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.editDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.editDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.editDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editDatumBisX.Properties.ShowToday = false;
            this.editDatumBisX.Size = new System.Drawing.Size(96, 24);
            this.editDatumBisX.TabIndex = 2;
            //
            // editDatumVonX
            //
            this.editDatumVonX.EditValue = null;
            this.editDatumVonX.Location = new System.Drawing.Point(84, 132);
            this.editDatumVonX.Name = "editDatumVonX";
            this.editDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.editDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.editDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.editDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.editDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.editDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editDatumVonX.Properties.ShowToday = false;
            this.editDatumVonX.Size = new System.Drawing.Size(96, 24);
            this.editDatumVonX.TabIndex = 1;
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(12, 63);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(66, 24);
            this.kissLabel1.TabIndex = 0;
            this.kissLabel1.Text = "Name";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // editPersonX
            //
            this.editPersonX.Location = new System.Drawing.Point(84, 63);
            this.editPersonX.Name = "editPersonX";
            this.editPersonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editPersonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editPersonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editPersonX.Properties.Appearance.Options.UseBackColor = true;
            this.editPersonX.Properties.Appearance.Options.UseBorderColor = true;
            this.editPersonX.Properties.Appearance.Options.UseFont = true;
            this.editPersonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.editPersonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.editPersonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editPersonX.Size = new System.Drawing.Size(225, 24);
            this.editPersonX.TabIndex = 0;
            this.editPersonX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editPersonX_UserModifiedFld);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.panel3);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Name = "tpgListe";
            this.tpgListe.Size = new System.Drawing.Size(796, 202);
            this.tpgListe.TabIndex = 1;
            this.tpgListe.Title = "Liste";
            //
            // panel3
            //
            this.panel3.Controls.Add(this.gridBelege);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(796, 202);
            this.panel3.TabIndex = 30;
            //
            // gridBelege
            //
            this.gridBelege.DataSource = this.qryBeleg;
            this.gridBelege.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridBelege.EmbeddedNavigator.Name = "";
            this.gridBelege.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.gridBelege.Location = new System.Drawing.Point(0, 0);
            this.gridBelege.MainView = this.gridView2;
            this.gridBelege.Name = "gridBelege";
            this.gridBelege.Size = new System.Drawing.Size(796, 202);
            this.gridBelege.TabIndex = 0;
            this.gridBelege.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            //
            // qryBeleg
            //
            this.qryBeleg.CanUpdate = true;
            this.qryBeleg.HostControl = this;
            this.qryBeleg.TableName = "KbBuchung";
            this.qryBeleg.PositionChanged += new System.EventHandler(this.qryBeleg_PositionChanged);
            //
            // gridView2
            //
            this.gridView2.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView2.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.Empty.Options.UseBackColor = true;
            this.gridView2.Appearance.Empty.Options.UseFont = true;
            this.gridView2.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
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
            this.gridView2.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView2.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView2.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView2.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBelegNr,
            this.colPerson,
            this.colVerfalldatum,
            this.colBuchungstext,
            this.colBetrag,
            this.colAusbezahlt,
            this.colBelegStatusCode,
            this.colBaPersonID});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView2.GridControl = this.gridBelege;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsCustomization.AllowFilter = false;
            this.gridView2.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView2.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView2.OptionsNavigation.UseTabKey = false;
            this.gridView2.OptionsView.ColumnAutoWidth = false;
            this.gridView2.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.OptionsView.ShowIndicator = false;
            //
            // colBelegNr
            //
            this.colBelegNr.Caption = "Beleg-Nr.";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 0;
            this.colBelegNr.Width = 65;
            //
            // colPerson
            //
            this.colPerson.Caption = "Person";
            this.colPerson.FieldName = "Person";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 1;
            this.colPerson.Width = 148;
            //
            // colVerfalldatum
            //
            this.colVerfalldatum.Caption = "Verfalldatum";
            this.colVerfalldatum.FieldName = "Verfalldatum";
            this.colVerfalldatum.Name = "colVerfalldatum";
            this.colVerfalldatum.Visible = true;
            this.colVerfalldatum.VisibleIndex = 2;
            this.colVerfalldatum.Width = 87;
            //
            // colBuchungstext
            //
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Text";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 3;
            this.colBuchungstext.Width = 163;
            //
            // colBetrag
            //
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "BetragGrid";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 4;
            this.colBetrag.Width = 74;
            //
            // colAusbezahlt
            //
            this.colAusbezahlt.Caption = "ausged.";
            this.colAusbezahlt.FieldName = "BarbelegDatum";
            this.colAusbezahlt.Name = "colAusbezahlt";
            this.colAusbezahlt.Visible = true;
            this.colAusbezahlt.VisibleIndex = 5;
            this.colAusbezahlt.Width = 70;
            //
            // colBelegStatusCode
            //
            this.colBelegStatusCode.Caption = "Status";
            this.colBelegStatusCode.FieldName = "KbBuchungStatusCode";
            this.colBelegStatusCode.Name = "colBelegStatusCode";
            this.colBelegStatusCode.Visible = true;
            this.colBelegStatusCode.VisibleIndex = 6;
            this.colBelegStatusCode.Width = 187;
            //
            // colBaPersonID
            //
            this.colBaPersonID.Caption = "gridColumn1";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            //
            // kissTextEdit1
            //
            this.kissTextEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit1.DataMember = "Person";
            this.kissTextEdit1.DataSource = this.qryBeleg;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(85, 296);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(203, 24);
            this.kissTextEdit1.TabIndex = 1;
            //
            // kissTextEdit2
            //
            this.kissTextEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit2.DataMember = "Strasse";
            this.kissTextEdit2.DataSource = this.qryBeleg;
            this.kissTextEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit2.Location = new System.Drawing.Point(85, 319);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Properties.ReadOnly = true;
            this.kissTextEdit2.Size = new System.Drawing.Size(203, 24);
            this.kissTextEdit2.TabIndex = 2;
            //
            // kissTextEdit3
            //
            this.kissTextEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit3.DataMember = "PLZOrt";
            this.kissTextEdit3.DataSource = this.qryBeleg;
            this.kissTextEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit3.Location = new System.Drawing.Point(85, 342);
            this.kissTextEdit3.Name = "kissTextEdit3";
            this.kissTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit3.Properties.ReadOnly = true;
            this.kissTextEdit3.Size = new System.Drawing.Size(203, 24);
            this.kissTextEdit3.TabIndex = 3;
            //
            // kissDateEdit1
            //
            this.kissDateEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissDateEdit1.DataMember = "Geburtsdatum";
            this.kissDateEdit1.DataSource = this.qryBeleg;
            this.kissDateEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit1.EditValue = null;
            this.kissDateEdit1.Location = new System.Drawing.Point(85, 372);
            this.kissDateEdit1.Name = "kissDateEdit1";
            this.kissDateEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.kissDateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit1.Properties.ReadOnly = true;
            this.kissDateEdit1.Properties.ShowToday = false;
            this.kissDateEdit1.Size = new System.Drawing.Size(103, 24);
            this.kissDateEdit1.TabIndex = 4;
            //
            // kissTextEdit4
            //
            this.kissTextEdit4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit4.DataMember = "AHVNummer";
            this.kissTextEdit4.DataSource = this.qryBeleg;
            this.kissTextEdit4.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit4.Location = new System.Drawing.Point(85, 402);
            this.kissTextEdit4.Name = "kissTextEdit4";
            this.kissTextEdit4.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit4.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit4.Properties.ReadOnly = true;
            this.kissTextEdit4.Size = new System.Drawing.Size(103, 24);
            this.kissTextEdit4.TabIndex = 5;
            //
            // kissTextEdit5
            //
            this.kissTextEdit5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit5.DataMember = "Text";
            this.kissTextEdit5.DataSource = this.qryBeleg;
            this.kissTextEdit5.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit5.Location = new System.Drawing.Point(404, 296);
            this.kissTextEdit5.Name = "kissTextEdit5";
            this.kissTextEdit5.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit5.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit5.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit5.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit5.Properties.ReadOnly = true;
            this.kissTextEdit5.Size = new System.Drawing.Size(408, 24);
            this.kissTextEdit5.TabIndex = 6;
            //
            // kissTextEdit6
            //
            this.kissTextEdit6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit6.DataMember = "Remark";
            this.kissTextEdit6.DataSource = this.qryBeleg;
            this.kissTextEdit6.Location = new System.Drawing.Point(404, 326);
            this.kissTextEdit6.Name = "kissTextEdit6";
            this.kissTextEdit6.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissTextEdit6.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit6.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit6.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit6.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit6.Size = new System.Drawing.Size(408, 24);
            this.kissTextEdit6.TabIndex = 7;
            //
            // kissDateEdit2
            //
            this.kissDateEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissDateEdit2.DataMember = "ValutaDatum";
            this.kissDateEdit2.DataSource = this.qryBeleg;
            this.kissDateEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissDateEdit2.EditValue = null;
            this.kissDateEdit2.Location = new System.Drawing.Point(404, 356);
            this.kissDateEdit2.Name = "kissDateEdit2";
            this.kissDateEdit2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissDateEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.kissDateEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit2.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.kissDateEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit2.Properties.ReadOnly = true;
            this.kissDateEdit2.Properties.ShowToday = false;
            this.kissDateEdit2.Size = new System.Drawing.Size(103, 24);
            this.kissDateEdit2.TabIndex = 8;
            //
            // kissTextEdit7
            //
            this.kissTextEdit7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit7.DataMember = "KasseUser";
            this.kissTextEdit7.DataSource = this.qryBeleg;
            this.kissTextEdit7.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit7.Location = new System.Drawing.Point(404, 386);
            this.kissTextEdit7.Name = "kissTextEdit7";
            this.kissTextEdit7.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit7.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit7.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit7.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit7.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit7.Properties.ReadOnly = true;
            this.kissTextEdit7.Size = new System.Drawing.Size(408, 24);
            this.kissTextEdit7.TabIndex = 9;
            //
            // kissTextEdit8
            //
            this.kissTextEdit8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit8.DataMember = "SAR";
            this.kissTextEdit8.DataSource = this.qryBeleg;
            this.kissTextEdit8.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit8.Location = new System.Drawing.Point(404, 416);
            this.kissTextEdit8.Name = "kissTextEdit8";
            this.kissTextEdit8.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit8.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit8.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit8.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit8.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit8.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit8.Properties.ReadOnly = true;
            this.kissTextEdit8.Size = new System.Drawing.Size(408, 24);
            this.kissTextEdit8.TabIndex = 10;
            //
            // btnFallInfo
            //
            this.btnFallInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFallInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFallInfo.Location = new System.Drawing.Point(636, 531);
            this.btnFallInfo.Name = "btnFallInfo";
            this.btnFallInfo.Size = new System.Drawing.Size(78, 24);
            this.btnFallInfo.TabIndex = 11;
            this.btnFallInfo.Text = "Fallinfo";
            this.btnFallInfo.UseCompatibleTextRendering = true;
            this.btnFallInfo.UseVisualStyleBackColor = false;
            this.btnFallInfo.Click += new System.EventHandler(this.btnFallInfo_Click);
            //
            // btnAuszahlen
            //
            this.btnAuszahlen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAuszahlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAuszahlen.Location = new System.Drawing.Point(721, 531);
            this.btnAuszahlen.Name = "btnAuszahlen";
            this.btnAuszahlen.Size = new System.Drawing.Size(94, 24);
            this.btnAuszahlen.TabIndex = 12;
            this.btnAuszahlen.Text = "Auszahlen";
            this.btnAuszahlen.UseCompatibleTextRendering = true;
            this.btnAuszahlen.UseVisualStyleBackColor = false;
            this.btnAuszahlen.Click += new System.EventHandler(this.btnAuszahlen_Click);
            //
            // lblMonatsbudget
            //
            this.lblMonatsbudget.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblMonatsbudget.Location = new System.Drawing.Point(4, 4);
            this.lblMonatsbudget.Name = "lblMonatsbudget";
            this.lblMonatsbudget.Size = new System.Drawing.Size(100, 16);
            this.lblMonatsbudget.TabIndex = 37;
            this.lblMonatsbudget.Text = "Kassenbelege";
            this.lblMonatsbudget.UseCompatibleTextRendering = true;
            //
            // kissLabel2
            //
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel2.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel2.Location = new System.Drawing.Point(5, 276);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(156, 20);
            this.kissLabel2.TabIndex = 38;
            this.kissLabel2.Text = "unterstützte Person";
            this.kissLabel2.UseCompatibleTextRendering = true;
            //
            // kissLabel8
            //
            this.kissLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel8.Location = new System.Drawing.Point(5, 296);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(66, 24);
            this.kissLabel8.TabIndex = 39;
            this.kissLabel8.Text = "Name";
            this.kissLabel8.UseCompatibleTextRendering = true;
            //
            // kissLabel9
            //
            this.kissLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel9.Location = new System.Drawing.Point(5, 372);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(74, 24);
            this.kissLabel9.TabIndex = 40;
            this.kissLabel9.Text = "Geburtsdatum";
            this.kissLabel9.UseCompatibleTextRendering = true;
            //
            // kissLabel10
            //
            this.kissLabel10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel10.Location = new System.Drawing.Point(5, 402);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(74, 24);
            this.kissLabel10.TabIndex = 41;
            this.kissLabel10.Text = "AHV-Nummer";
            this.kissLabel10.UseCompatibleTextRendering = true;
            //
            // kissLabel11
            //
            this.kissLabel11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel11.Location = new System.Drawing.Point(5, 319);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(66, 24);
            this.kissLabel11.TabIndex = 42;
            this.kissLabel11.Text = "Strasse";
            this.kissLabel11.UseCompatibleTextRendering = true;
            //
            // kissLabel12
            //
            this.kissLabel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel12.Location = new System.Drawing.Point(5, 342);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(66, 24);
            this.kissLabel12.TabIndex = 43;
            this.kissLabel12.Text = "PLZ / Ort";
            this.kissLabel12.UseCompatibleTextRendering = true;
            //
            // kissLabel13
            //
            this.kissLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel13.Location = new System.Drawing.Point(310, 326);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(88, 24);
            this.kissLabel13.TabIndex = 44;
            this.kissLabel13.Text = "Bemerkungen";
            this.kissLabel13.UseCompatibleTextRendering = true;
            //
            // kissLabel15
            //
            this.kissLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel15.Location = new System.Drawing.Point(310, 296);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(88, 24);
            this.kissLabel15.TabIndex = 46;
            this.kissLabel15.Text = "Buchungstext";
            this.kissLabel15.UseCompatibleTextRendering = true;
            //
            // kissLabel16
            //
            this.kissLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel16.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel16.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel16.Location = new System.Drawing.Point(310, 276);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(156, 17);
            this.kissLabel16.TabIndex = 47;
            this.kissLabel16.Text = "Beleg";
            this.kissLabel16.UseCompatibleTextRendering = true;
            //
            // kissLabel20
            //
            this.kissLabel20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel20.Location = new System.Drawing.Point(310, 386);
            this.kissLabel20.Name = "kissLabel20";
            this.kissLabel20.Size = new System.Drawing.Size(88, 24);
            this.kissLabel20.TabIndex = 51;
            this.kissLabel20.Text = "BelegerstellerIn";
            this.kissLabel20.UseCompatibleTextRendering = true;
            //
            // kissLabel21
            //
            this.kissLabel21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel21.Location = new System.Drawing.Point(310, 416);
            this.kissLabel21.Name = "kissLabel21";
            this.kissLabel21.Size = new System.Drawing.Size(66, 24);
            this.kissLabel21.TabIndex = 52;
            this.kissLabel21.Text = "zust. SA";
            this.kissLabel21.UseCompatibleTextRendering = true;
            //
            // kissLabel14
            //
            this.kissLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel14.Location = new System.Drawing.Point(311, 356);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(66, 24);
            this.kissLabel14.TabIndex = 55;
            this.kissLabel14.Text = "Auszahlung";
            this.kissLabel14.UseCompatibleTextRendering = true;
            //
            // edtMitteilung1
            //
            this.edtMitteilung1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMitteilung1.DataMember = "BeguenstigtName";
            this.edtMitteilung1.DataSource = this.qryBeleg;
            this.edtMitteilung1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMitteilung1.Location = new System.Drawing.Point(404, 447);
            this.edtMitteilung1.Name = "edtMitteilung1";
            this.edtMitteilung1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMitteilung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilung1.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilung1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilung1.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilung1.Properties.ReadOnly = true;
            this.edtMitteilung1.Size = new System.Drawing.Size(408, 24);
            this.edtMitteilung1.TabIndex = 56;
            //
            // lblAuszahlungAn
            //
            this.lblAuszahlungAn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAuszahlungAn.Location = new System.Drawing.Point(310, 447);
            this.lblAuszahlungAn.Name = "lblAuszahlungAn";
            this.lblAuszahlungAn.Size = new System.Drawing.Size(88, 24);
            this.lblAuszahlungAn.TabIndex = 57;
            this.lblAuszahlungAn.Text = "Auszahlung an";
            this.lblAuszahlungAn.UseCompatibleTextRendering = true;
            //
            // edtMitteilung2
            //
            this.edtMitteilung2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMitteilung2.DataMember = "BeguenstigtStrasse";
            this.edtMitteilung2.DataSource = this.qryBeleg;
            this.edtMitteilung2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMitteilung2.Location = new System.Drawing.Point(404, 470);
            this.edtMitteilung2.Name = "edtMitteilung2";
            this.edtMitteilung2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMitteilung2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilung2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilung2.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilung2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilung2.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilung2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilung2.Properties.ReadOnly = true;
            this.edtMitteilung2.Size = new System.Drawing.Size(408, 24);
            this.edtMitteilung2.TabIndex = 58;
            //
            // edtMitteilung3
            //
            this.edtMitteilung3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtMitteilung3.DataMember = "BeguenstigtOrt";
            this.edtMitteilung3.DataSource = this.qryBeleg;
            this.edtMitteilung3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMitteilung3.Location = new System.Drawing.Point(404, 493);
            this.edtMitteilung3.Name = "edtMitteilung3";
            this.edtMitteilung3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMitteilung3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilung3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilung3.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilung3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilung3.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilung3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilung3.Properties.ReadOnly = true;
            this.edtMitteilung3.Size = new System.Drawing.Size(408, 24);
            this.edtMitteilung3.TabIndex = 59;
            //
            // lblVersNr
            //
            this.lblVersNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersNr.Location = new System.Drawing.Point(5, 432);
            this.lblVersNr.Name = "lblVersNr";
            this.lblVersNr.Size = new System.Drawing.Size(74, 24);
            this.lblVersNr.TabIndex = 61;
            this.lblVersNr.Text = "Vers. - Nr.";
            this.lblVersNr.UseCompatibleTextRendering = true;
            //
            // edtVersNr
            //
            this.edtVersNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVersNr.DataMember = "Versichertennummer";
            this.edtVersNr.DataSource = this.qryBeleg;
            this.edtVersNr.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVersNr.Location = new System.Drawing.Point(85, 432);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNr.Properties.ReadOnly = true;
            this.edtVersNr.Size = new System.Drawing.Size(103, 24);
            this.edtVersNr.TabIndex = 60;
            //
            // CtlKasse
            //
            this.ClientSize = new System.Drawing.Size(820, 562);
            this.Controls.Add(this.lblVersNr);
            this.Controls.Add(this.edtVersNr);
            this.Controls.Add(this.edtMitteilung3);
            this.Controls.Add(this.edtMitteilung2);
            this.Controls.Add(this.lblAuszahlungAn);
            this.Controls.Add(this.edtMitteilung1);
            this.Controls.Add(this.kissLabel14);
            this.Controls.Add(this.kissLabel21);
            this.Controls.Add(this.kissLabel20);
            this.Controls.Add(this.kissLabel16);
            this.Controls.Add(this.kissLabel15);
            this.Controls.Add(this.kissLabel13);
            this.Controls.Add(this.kissLabel12);
            this.Controls.Add(this.kissLabel11);
            this.Controls.Add(this.kissLabel10);
            this.Controls.Add(this.kissLabel9);
            this.Controls.Add(this.kissLabel8);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.lblMonatsbudget);
            this.Controls.Add(this.btnAuszahlen);
            this.Controls.Add(this.btnFallInfo);
            this.Controls.Add(this.kissTextEdit8);
            this.Controls.Add(this.kissTextEdit7);
            this.Controls.Add(this.kissDateEdit2);
            this.Controls.Add(this.kissTextEdit6);
            this.Controls.Add(this.kissTextEdit5);
            this.Controls.Add(this.kissTextEdit4);
            this.Controls.Add(this.kissDateEdit1);
            this.Controls.Add(this.kissTextEdit3);
            this.Controls.Add(this.kissTextEdit2);
            this.Controls.Add(this.kissTextEdit1);
            this.Controls.Add(this.tabControlSearch);
            this.Name = "CtlKasse";
            this.Text = "SH Kasse";
            this.Search += new System.EventHandler(this.FrmKasse_Search);
            this.Load += new System.EventHandler(this.FrmKasse_Load);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkGesperrtX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAusbezahltX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNichtAusbezahltX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editPersonX.Properties)).EndInit();
            this.tpgListe.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBelege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBeleg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit8.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonatsbudget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAuszahlungAn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).EndInit();
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

        #region EventHandlers

        private void btnAuszahlen_Click(object sender, System.EventArgs e)
        {
            if (qryBeleg.Count == 0 || (int)qryBeleg["KbBuchungStatusCode"] != 2) return;

            if (!KissMsg.ShowQuestion("CtlKasse", "BetragAuszahlenStatusAendern", "Soll der Betrag von CHF {0} an {1} ausbezahlt werden und der Belegstatus entsprechend geändert werden ?", 0, 0, true, string.Format("{0:n2}", qryBeleg["Betrag"]), qryBeleg["Person"]))
                return;

            // Status ändern in KbBuchung
            qryBeleg["KbBuchungStatusCode"] = 4;
            qryBeleg["BarbelegDatum"] = DateTime.Now;
            qryBeleg["BarbelegUserID"] = Session.User.UserID;
            qryBeleg["KasseUser"] = string.Format("{0}, {1} ({2})", Session.User.LastName, Session.User.FirstName, Session.User.Phone);

            if (!qryBeleg.Post())
            {
                qryBeleg.Cancel();
                return;
            }

            // Drucken
            this.FrmKasse_Print(this, EventArgs.Empty);
        }

        private void btnFallInfo_Click(object sender, System.EventArgs e)
        {
            if (qryBeleg.Count == 0) return;

            FormController.ShowDialogOnMain("FrmFallInfo", qryBeleg["BaPersonID"], true);
        }

        private void editPersonX_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.ShUnterstuetztePersonSuchen(editPersonX.Text, e.ButtonClicked);

            if (!e.Cancel)
            {
                editPersonX.EditValue = dlg["Name"];
                editPersonX.LookupID = dlg["BaPersonID"];
            }
        }

        private void FrmKasse_Load(object sender, System.EventArgs e)
        {
            colBelegStatusCode.ColumnEdit = this.gridBelege.GetLOVLookUpEdit("KbBuchungsStatus");
            _tageZuVerfalldatum = DBUtil.GetConfigInt(@"System\Sozialhilfe\Kasse\TageZuVerfalldatum", 0);

            tabControlSearch.SelectedTabIndex = 0;
            tabControlSearch.SelectedTabIndex = 1;
        }

        private void FrmKasse_Print(object sender, System.EventArgs e)
        {
            if (qryBeleg.Count == 0) return;

            GetKissMainForm().ContextPrint(this, "ShKassenbeleg");

            //War nötig wann diese Maske einen Frm war und von KissForm erbte, als Kommentar gelassen falls ein Problem mit dieser Funktion kommt
            //this.Activate();
        }

        private void FrmKasse_Search(object sender, System.EventArgs e)
        {
            if (tabControlSearch.SelectedTabIndex == 1)
                Suchen();
            else
            {
                tabControlSearch.SelectedTabIndex = 1;
                NeueSuche();
            }
        }

        private void qryBeleg_PositionChanged(object sender, System.EventArgs e)
        {
            btnAuszahlen.Enabled = ((int)qryBeleg["KbBuchungStatusCode"] == 2);
        }

        private void tabControlSearch_SelectedTabChanged(SharpLibrary.WinControls.TabPageEx page)
        {
            if (UtilsGui.IsCalledFromAnyMethod("InitializeComponent"))
            {
                // During Initialization, we don't need to do anything here
                return;
            }

            if (page == this.tpgSuchen && !this.OnSaveData())
            {
                this.tabControlSearch.SelectTab(lastSelectedTab);
            }
            else if (lastSelectedTab == this.tpgSuchen)
            {
                this.Suchen();
            }
            else if (page == this.tpgSuchen)
            {
                tpgSuchen.Focus();
                tpgSuchen.SelectNextControl(null, true, true, true, false);
            }
        }

        private void tabControlSearch_SelectedTabChanging(object sender, System.ComponentModel.CancelEventArgs e)
        {
            lastSelectedTab = ((KissTabControlEx)sender).SelectedTab;
            e.Cancel = !this.OnSaveData();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BELEGNUMMER":
                case "KBBUCHUNGID":
                    return qryBeleg["KbBuchungID"];
            }

            return base.GetContextValue(FieldName);
        }

        #endregion

        #region Private Methods

        private void NeueSuche()
        {
            foreach (Control ctl in tpgSuchen.Controls)
            {
                if (ctl is DevExpress.XtraEditors.BaseEdit)
                    ((DevExpress.XtraEditors.BaseEdit)ctl).EditValue = null;
            }

            this.chkNichtAusbezahltX.Checked = true;
            this.chkGesperrtX.Checked = false;
            this.chkAusbezahltX.Checked = false;

            editPersonX.Focus();
        }

        private void Suchen()
        {
            if (DBUtil.IsEmpty(editPersonX.LookupID) &&
                DBUtil.IsEmpty(editDatumVonX.EditValue) &&
                DBUtil.IsEmpty(editDatumBisX.EditValue))
            {
                KissMsg.ShowInfo("CtlKasse", "Min1FeldAusgefuellt", "Mindestens eines der Felder 'Person', 'Verfalldatum von', 'Verfalldatum bis' muss ausgefüllt sein!");
                return;
            }

            string SqlWhere = " WHERE FAL.ModulID = 3 AND FLB.KbAuszahlungsartCode = 103 ";  //nur Kassenbelege

            if (!DBUtil.IsEmpty(editPersonX.LookupID))
                SqlWhere += " and SFD.BaPersonID = " + editPersonX.LookupID.ToString();

            if (!DBUtil.IsEmpty(editDatumVonX.EditValue))
                SqlWhere += " and FLB.ValutaDatum >= " + DBUtil.SqlLiteral(editDatumVonX.DateTime);

            if (!DBUtil.IsEmpty(editDatumBisX.EditValue))
                SqlWhere += " and FLB.ValutaDatum <= " + DBUtil.SqlLiteral(editDatumBisX.DateTime);

            if (chkNichtAusbezahltX.Checked || chkAusbezahltX.Checked || chkGesperrtX.Checked)
            {
                SqlWhere += " and FLB.KbBuchungStatusCode in (-1" +
                    (chkNichtAusbezahltX.Checked ? ",2" : "") +
                    (chkAusbezahltX.Checked ? ",4" : "") +
                    (chkGesperrtX.Checked ? ",7" : "") + ") ";
            }

            qryBeleg.Fill(@"
                SELECT DISTINCT
                  FAL.BaPersonID,
                  FLB.*,
                  FAL.FaFallID,
                  SFP.BgFinanzplanID,
                  PRS.Geburtsdatum,
                  PRS.AHVNummer,
                  PRS.Versichertennummer,
                  Person    = PRS.NameVorname,
                  Strasse   = PRS.WohnsitzStrasseHausNr,
                  PLZOrt    = PRS.WohnsitzPLZOrt,
                  SAR       = USR.LastName + isnull(', ' + USR.FirstName,'') +
                            isNull(' (' + USR.Phone + ')',''),
                  KasseUser = KUSR.LastName + isnull(', ' + KUSR.FirstName,'') +
                            isNull(' (' + KUSR.Phone + ')',''),
                  BetragGrid = (SELECT SUM(Betrag) FROM KbBuchungKostenart WHERE KbBuchungID = FLB.KbBuchungID),
                                SortAusbezahlt = IsNull(FLB.BarbelegDatum, '20790606'),
                  Verfalldatum = DATEADD(DAY, ISNULL({0}, 0), FLB.ValutaDatum)
                FROM dbo.FaLeistung                        FAL WITH (READUNCOMMITTED)
                    INNER JOIN dbo.vwPerson                PRS  ON PRS.BaPersonID = FAL.BaPersonID
                    INNER JOIN dbo.BgFinanzplan            SFP  WITH (READUNCOMMITTED) ON SFP.FaLeistungID = FAL.FaLeistungID
                    INNER JOIN dbo.BgFinanzplan_BaPerson   SFD  WITH (READUNCOMMITTED) ON SFD.BgFinanzplanID = SFP.BgFinanzplanID AND SFD.IstUnterstuetzt = 1
                    INNER JOIN dbo.BgBudget                BGG  WITH (READUNCOMMITTED) ON BGG.BgFinanzplanID = SFP.BgFinanzplanID
                    INNER JOIN dbo.KbBuchung               FLB  WITH (READUNCOMMITTED) ON FLB.BgBudgetID = BGG.BgBudgetID
                    INNER JOIN dbo.XUser                   USR  WITH (READUNCOMMITTED) ON USR.UserID = FAL.UserId
                    LEFT  JOIN dbo.XUser                   KUSR WITH (READUNCOMMITTED) ON KUSR.UserID = FLB.BarbelegUserID  " +
                SqlWhere + @"

                ORDER BY Person, SortAusbezahlt, BelegDatum", _tageZuVerfalldatum);

            while (qryBeleg.Count > 0 && !qryBeleg[DBO.KbBuchung.KbBuchungStatusCode].Equals(2) && qryBeleg.Next()) ;

            this.tabControlSearch.SelectedTabIndex = 0;
        }

        #endregion

        #endregion
    }
}