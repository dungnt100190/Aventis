using System;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Schnittstellen.Abacus
{
    public class CtlAbaLogView : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        private String UserFullName = "";
        private DevExpress.XtraGrid.Columns.GridColumn colExceptionMsg;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colLogDate;
        private DevExpress.XtraGrid.Columns.GridColumn colParameterIn;
        private DevExpress.XtraGrid.Columns.GridColumn colParameterOut;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colSchnittstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtBenutzer;
        private KiSS4.Gui.KissDateEdit edtDatum;
        private KiSS4.Gui.KissTextEdit edtSchnittstelle;
        private KiSS4.Gui.KissCalcEdit edtSucheAbaLogID;
        private KiSS4.Gui.KissTextEdit edtSucheAusgabe;
        private KiSS4.Gui.KissTextEdit edtSucheBemerkungen;
        private KiSS4.Gui.KissButtonEdit edtSucheBenutzer;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissTextEdit edtSucheEingabe;
        private KiSS4.Gui.KissTextEdit edtSucheFehlerbericht;
        private KiSS4.Gui.KissLookUpEdit edtSucheSchnittstelle;
        private KiSS4.Gui.KissGrid grdAbaLog;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAbaLog;
        private KiSS4.Gui.KissLabel lblAusgabe;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBenutzer;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblEingabe;
        private KiSS4.Gui.KissLabel lblFehlerbericht;
        private KiSS4.Gui.KissLabel lblSchnittstelle;
        private KiSS4.Gui.KissLabel lblSucheAbaLogID;
        private KiSS4.Gui.KissLabel lblSucheAusgabe;
        private KiSS4.Gui.KissLabel lblSucheBemerkungen;
        private KiSS4.Gui.KissLabel lblSucheBenutzer;
        private KiSS4.Gui.KissLabel lblSucheDatum;
        private KiSS4.Gui.KissLabel lblSucheDatumBis;
        private KiSS4.Gui.KissLabel lblSucheEingabe;
        private KiSS4.Gui.KissLabel lblSucheFehlerbericht;
        private KiSS4.Gui.KissLabel lblSucheSchnittstelle;
        private KiSS4.Gui.KissMemoEdit memAusgabe;
        private KiSS4.Gui.KissMemoEdit memBemerkungen;
        private KiSS4.Gui.KissMemoEdit memEingabe;
        private KiSS4.Gui.KissMemoEdit memFehlerbericht;
        private KiSS4.DB.SqlQuery qryXAbaLog;

        #endregion

        #region Constructors

        public CtlAbaLogView()
        {
            this.InitializeComponent();

            // request userfullname
            this.UserFullName = DBUtil.ExecuteScalarSQL(@"SELECT dbo.fnGetLastFirstName({0}, NULL, NULL)", Session.User.UserID) as String;
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlAbaLogView));
            this.grdAbaLog = new KiSS4.Gui.KissGrid();
            this.lblSucheAbaLogID = new KiSS4.Gui.KissLabel();
            this.edtSucheAbaLogID = new KiSS4.Gui.KissCalcEdit();
            this.lblSucheSchnittstelle = new KiSS4.Gui.KissLabel();
            this.edtSucheSchnittstelle = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheDatum = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheDatumBis = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheBenutzer = new KiSS4.Gui.KissLabel();
            this.edtSucheBenutzer = new KiSS4.Gui.KissButtonEdit();
            this.lblSucheFehlerbericht = new KiSS4.Gui.KissLabel();
            this.edtSucheFehlerbericht = new KiSS4.Gui.KissTextEdit();
            this.lblSucheBemerkungen = new KiSS4.Gui.KissLabel();
            this.edtSucheBemerkungen = new KiSS4.Gui.KissTextEdit();
            this.lblSucheEingabe = new KiSS4.Gui.KissLabel();
            this.edtSucheEingabe = new KiSS4.Gui.KissTextEdit();
            this.lblSucheAusgabe = new KiSS4.Gui.KissLabel();
            this.edtSucheAusgabe = new KiSS4.Gui.KissTextEdit();
            this.lblSchnittstelle = new KiSS4.Gui.KissLabel();
            this.edtSchnittstelle = new KiSS4.Gui.KissTextEdit();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.lblBenutzer = new KiSS4.Gui.KissLabel();
            this.edtBenutzer = new KiSS4.Gui.KissTextEdit();
            this.lblEingabe = new KiSS4.Gui.KissLabel();
            this.memEingabe = new KiSS4.Gui.KissMemoEdit();
            this.lblAusgabe = new KiSS4.Gui.KissLabel();
            this.memAusgabe = new KiSS4.Gui.KissMemoEdit();
            this.lblFehlerbericht = new KiSS4.Gui.KissLabel();
            this.memFehlerbericht = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.memBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.colExceptionMsg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLogDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParameterIn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colParameterOut = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchnittstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvAbaLog = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.qryXAbaLog = new KiSS4.DB.SqlQuery(this.components);
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAbaLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbaLogID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbaLogID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSchnittstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSchnittstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSchnittstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBenutzer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFehlerbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFehlerbericht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheEingabe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEingabe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAusgabe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAusgabe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchnittstelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchnittstelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBenutzer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBenutzer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingabe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memEingabe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgabe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAusgabe.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFehlerbericht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFehlerbericht.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbaLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXAbaLog)).BeginInit();
            this.SuspendLayout();
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(794, 309);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdAbaLog);
            this.tpgListe.Size = new System.Drawing.Size(782, 271);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheAusgabe);
            this.tpgSuchen.Controls.Add(this.lblSucheAusgabe);
            this.tpgSuchen.Controls.Add(this.edtSucheEingabe);
            this.tpgSuchen.Controls.Add(this.lblSucheEingabe);
            this.tpgSuchen.Controls.Add(this.edtSucheBemerkungen);
            this.tpgSuchen.Controls.Add(this.lblSucheBemerkungen);
            this.tpgSuchen.Controls.Add(this.edtSucheFehlerbericht);
            this.tpgSuchen.Controls.Add(this.lblSucheFehlerbericht);
            this.tpgSuchen.Controls.Add(this.edtSucheBenutzer);
            this.tpgSuchen.Controls.Add(this.lblSucheBenutzer);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.lblSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheDatum);
            this.tpgSuchen.Controls.Add(this.edtSucheSchnittstelle);
            this.tpgSuchen.Controls.Add(this.lblSucheSchnittstelle);
            this.tpgSuchen.Controls.Add(this.edtSucheAbaLogID);
            this.tpgSuchen.Controls.Add(this.lblSucheAbaLogID);
            this.tpgSuchen.Size = new System.Drawing.Size(782, 271);
            this.tpgSuchen.TabIndex = 0;
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAbaLogID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAbaLogID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheSchnittstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheSchnittstelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatum, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBenutzer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBenutzer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheFehlerbericht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheFehlerbericht, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBemerkungen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheEingabe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheEingabe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAusgabe, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAusgabe, 0);
            //
            // grdAbaLog
            //
            this.grdAbaLog.DataSource = this.qryXAbaLog;
            this.grdAbaLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdAbaLog.EmbeddedNavigator.Name = "";
            this.grdAbaLog.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAbaLog.Location = new System.Drawing.Point(0, 0);
            this.grdAbaLog.MainView = this.grvAbaLog;
            this.grdAbaLog.Name = "grdAbaLog";
            this.grdAbaLog.Size = new System.Drawing.Size(782, 271);
            this.grdAbaLog.TabIndex = 0;
            this.grdAbaLog.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvAbaLog});
            //
            // lblSucheAbaLogID
            //
            this.lblSucheAbaLogID.Location = new System.Drawing.Point(31, 40);
            this.lblSucheAbaLogID.Name = "lblSucheAbaLogID";
            this.lblSucheAbaLogID.Size = new System.Drawing.Size(100, 23);
            this.lblSucheAbaLogID.TabIndex = 1;
            this.lblSucheAbaLogID.Text = "Log-ID";
            this.lblSucheAbaLogID.UseCompatibleTextRendering = true;
            //
            // edtSucheAbaLogID
            //
            this.edtSucheAbaLogID.Location = new System.Drawing.Point(137, 40);
            this.edtSucheAbaLogID.Name = "edtSucheAbaLogID";
            this.edtSucheAbaLogID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheAbaLogID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAbaLogID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAbaLogID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbaLogID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAbaLogID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAbaLogID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAbaLogID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAbaLogID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheAbaLogID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAbaLogID.Size = new System.Drawing.Size(100, 24);
            this.edtSucheAbaLogID.TabIndex = 2;
            //
            // lblSucheSchnittstelle
            //
            this.lblSucheSchnittstelle.Location = new System.Drawing.Point(31, 70);
            this.lblSucheSchnittstelle.Name = "lblSucheSchnittstelle";
            this.lblSucheSchnittstelle.Size = new System.Drawing.Size(100, 23);
            this.lblSucheSchnittstelle.TabIndex = 3;
            this.lblSucheSchnittstelle.Text = "Schnittstelle";
            this.lblSucheSchnittstelle.UseCompatibleTextRendering = true;
            //
            // edtSucheSchnittstelle
            //
            this.edtSucheSchnittstelle.Location = new System.Drawing.Point(137, 70);
            this.edtSucheSchnittstelle.LOVName = "AbaSchnittstellenCode";
            this.edtSucheSchnittstelle.Name = "edtSucheSchnittstelle";
            this.edtSucheSchnittstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheSchnittstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheSchnittstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheSchnittstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheSchnittstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheSchnittstelle.Properties.Appearance.Options.UseFont = true;
            this.edtSucheSchnittstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheSchnittstelle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheSchnittstelle.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheSchnittstelle.Properties.NullText = "";
            this.edtSucheSchnittstelle.Properties.ShowFooter = false;
            this.edtSucheSchnittstelle.Properties.ShowHeader = false;
            this.edtSucheSchnittstelle.Size = new System.Drawing.Size(241, 24);
            this.edtSucheSchnittstelle.TabIndex = 4;
            //
            // lblSucheDatum
            //
            this.lblSucheDatum.Location = new System.Drawing.Point(31, 100);
            this.lblSucheDatum.Name = "lblSucheDatum";
            this.lblSucheDatum.Size = new System.Drawing.Size(100, 23);
            this.lblSucheDatum.TabIndex = 5;
            this.lblSucheDatum.Text = "Datum";
            this.lblSucheDatum.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumVon
            //
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(137, 100);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumVon.TabIndex = 6;
            //
            // lblSucheDatumBis
            //
            this.lblSucheDatumBis.Location = new System.Drawing.Point(243, 100);
            this.lblSucheDatumBis.Name = "lblSucheDatumBis";
            this.lblSucheDatumBis.Size = new System.Drawing.Size(29, 24);
            this.lblSucheDatumBis.TabIndex = 7;
            this.lblSucheDatumBis.Text = "bis";
            this.lblSucheDatumBis.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumBis
            //
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(278, 100);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheDatumBis.TabIndex = 8;
            //
            // lblSucheBenutzer
            //
            this.lblSucheBenutzer.Location = new System.Drawing.Point(31, 130);
            this.lblSucheBenutzer.Name = "lblSucheBenutzer";
            this.lblSucheBenutzer.Size = new System.Drawing.Size(100, 23);
            this.lblSucheBenutzer.TabIndex = 9;
            this.lblSucheBenutzer.Text = "Benutzer";
            this.lblSucheBenutzer.UseCompatibleTextRendering = true;
            //
            // edtSucheBenutzer
            //
            this.edtSucheBenutzer.EditValue = "";
            this.edtSucheBenutzer.Location = new System.Drawing.Point(137, 130);
            this.edtSucheBenutzer.Name = "edtSucheBenutzer";
            this.edtSucheBenutzer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBenutzer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBenutzer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBenutzer.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBenutzer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBenutzer.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBenutzer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBenutzer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtSucheBenutzer.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBenutzer.Size = new System.Drawing.Size(241, 24);
            this.edtSucheBenutzer.TabIndex = 10;
            this.edtSucheBenutzer.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheBenutzer_UserModifiedFld);
            //
            // lblSucheFehlerbericht
            //
            this.lblSucheFehlerbericht.Location = new System.Drawing.Point(31, 160);
            this.lblSucheFehlerbericht.Name = "lblSucheFehlerbericht";
            this.lblSucheFehlerbericht.Size = new System.Drawing.Size(100, 23);
            this.lblSucheFehlerbericht.TabIndex = 11;
            this.lblSucheFehlerbericht.Text = "Fehlerbericht";
            this.lblSucheFehlerbericht.UseCompatibleTextRendering = true;
            //
            // edtSucheFehlerbericht
            //
            this.edtSucheFehlerbericht.Location = new System.Drawing.Point(137, 160);
            this.edtSucheFehlerbericht.Name = "edtSucheFehlerbericht";
            this.edtSucheFehlerbericht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheFehlerbericht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheFehlerbericht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheFehlerbericht.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheFehlerbericht.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheFehlerbericht.Properties.Appearance.Options.UseFont = true;
            this.edtSucheFehlerbericht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheFehlerbericht.Size = new System.Drawing.Size(241, 24);
            this.edtSucheFehlerbericht.TabIndex = 12;
            //
            // lblSucheBemerkungen
            //
            this.lblSucheBemerkungen.Location = new System.Drawing.Point(31, 190);
            this.lblSucheBemerkungen.Name = "lblSucheBemerkungen";
            this.lblSucheBemerkungen.Size = new System.Drawing.Size(100, 23);
            this.lblSucheBemerkungen.TabIndex = 13;
            this.lblSucheBemerkungen.Text = "Bemerkungen";
            this.lblSucheBemerkungen.UseCompatibleTextRendering = true;
            //
            // edtSucheBemerkungen
            //
            this.edtSucheBemerkungen.Location = new System.Drawing.Point(137, 190);
            this.edtSucheBemerkungen.Name = "edtSucheBemerkungen";
            this.edtSucheBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBemerkungen.Size = new System.Drawing.Size(241, 24);
            this.edtSucheBemerkungen.TabIndex = 14;
            //
            // lblSucheEingabe
            //
            this.lblSucheEingabe.Location = new System.Drawing.Point(423, 70);
            this.lblSucheEingabe.Name = "lblSucheEingabe";
            this.lblSucheEingabe.Size = new System.Drawing.Size(82, 24);
            this.lblSucheEingabe.TabIndex = 15;
            this.lblSucheEingabe.Text = "Eingabe";
            this.lblSucheEingabe.UseCompatibleTextRendering = true;
            //
            // edtSucheEingabe
            //
            this.edtSucheEingabe.Location = new System.Drawing.Point(511, 70);
            this.edtSucheEingabe.Name = "edtSucheEingabe";
            this.edtSucheEingabe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheEingabe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheEingabe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheEingabe.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheEingabe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheEingabe.Properties.Appearance.Options.UseFont = true;
            this.edtSucheEingabe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheEingabe.Size = new System.Drawing.Size(241, 24);
            this.edtSucheEingabe.TabIndex = 16;
            //
            // lblSucheAusgabe
            //
            this.lblSucheAusgabe.Location = new System.Drawing.Point(423, 100);
            this.lblSucheAusgabe.Name = "lblSucheAusgabe";
            this.lblSucheAusgabe.Size = new System.Drawing.Size(82, 24);
            this.lblSucheAusgabe.TabIndex = 17;
            this.lblSucheAusgabe.Text = "Ausgabe";
            this.lblSucheAusgabe.UseCompatibleTextRendering = true;
            //
            // edtSucheAusgabe
            //
            this.edtSucheAusgabe.Location = new System.Drawing.Point(511, 100);
            this.edtSucheAusgabe.Name = "edtSucheAusgabe";
            this.edtSucheAusgabe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAusgabe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAusgabe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAusgabe.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAusgabe.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAusgabe.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAusgabe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheAusgabe.Size = new System.Drawing.Size(241, 24);
            this.edtSucheAusgabe.TabIndex = 18;
            //
            // lblSchnittstelle
            //
            this.lblSchnittstelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSchnittstelle.Location = new System.Drawing.Point(8, 318);
            this.lblSchnittstelle.Name = "lblSchnittstelle";
            this.lblSchnittstelle.Size = new System.Drawing.Size(100, 23);
            this.lblSchnittstelle.TabIndex = 1;
            this.lblSchnittstelle.Text = "Schnittstelle";
            this.lblSchnittstelle.UseCompatibleTextRendering = true;
            //
            // edtSchnittstelle
            //
            this.edtSchnittstelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSchnittstelle.DataMember = "Schnittstelle";
            this.edtSchnittstelle.DataSource = this.qryXAbaLog;
            this.edtSchnittstelle.Location = new System.Drawing.Point(114, 318);
            this.edtSchnittstelle.Name = "edtSchnittstelle";
            this.edtSchnittstelle.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSchnittstelle.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSchnittstelle.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSchnittstelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtSchnittstelle.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSchnittstelle.Properties.Appearance.Options.UseFont = true;
            this.edtSchnittstelle.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSchnittstelle.Size = new System.Drawing.Size(181, 24);
            this.edtSchnittstelle.TabIndex = 2;
            //
            // lblDatum
            //
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(8, 348);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(100, 23);
            this.lblDatum.TabIndex = 3;
            this.lblDatum.Text = "Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            //
            // edtDatum
            //
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.DataMember = "LogDate";
            this.edtDatum.DataSource = this.qryXAbaLog;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(114, 348);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.DisplayFormat.FormatString = "G";
            this.edtDatum.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatum.Properties.EditFormat.FormatString = "G";
            this.edtDatum.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatum.Properties.Mask.EditMask = "G";
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(143, 24);
            this.edtDatum.TabIndex = 4;
            //
            // lblBenutzer
            //
            this.lblBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBenutzer.Location = new System.Drawing.Point(8, 379);
            this.lblBenutzer.Name = "lblBenutzer";
            this.lblBenutzer.Size = new System.Drawing.Size(100, 23);
            this.lblBenutzer.TabIndex = 5;
            this.lblBenutzer.Text = "Benutzer";
            this.lblBenutzer.UseCompatibleTextRendering = true;
            //
            // edtBenutzer
            //
            this.edtBenutzer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBenutzer.DataMember = "User";
            this.edtBenutzer.DataSource = this.qryXAbaLog;
            this.edtBenutzer.Location = new System.Drawing.Point(114, 378);
            this.edtBenutzer.Name = "edtBenutzer";
            this.edtBenutzer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBenutzer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBenutzer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBenutzer.Properties.Appearance.Options.UseBackColor = true;
            this.edtBenutzer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBenutzer.Properties.Appearance.Options.UseFont = true;
            this.edtBenutzer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBenutzer.Size = new System.Drawing.Size(181, 24);
            this.edtBenutzer.TabIndex = 6;
            //
            // lblEingabe
            //
            this.lblEingabe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblEingabe.Location = new System.Drawing.Point(321, 318);
            this.lblEingabe.Name = "lblEingabe";
            this.lblEingabe.Size = new System.Drawing.Size(73, 24);
            this.lblEingabe.TabIndex = 7;
            this.lblEingabe.Text = "Eingabe";
            this.lblEingabe.UseCompatibleTextRendering = true;
            //
            // memEingabe
            //
            this.memEingabe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memEingabe.DataMember = "ParameterIn";
            this.memEingabe.DataSource = this.qryXAbaLog;
            this.memEingabe.Location = new System.Drawing.Point(400, 318);
            this.memEingabe.Name = "memEingabe";
            this.memEingabe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memEingabe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memEingabe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memEingabe.Properties.Appearance.Options.UseBackColor = true;
            this.memEingabe.Properties.Appearance.Options.UseBorderColor = true;
            this.memEingabe.Properties.Appearance.Options.UseFont = true;
            this.memEingabe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memEingabe.Size = new System.Drawing.Size(395, 38);
            this.memEingabe.TabIndex = 8;
            //
            // lblAusgabe
            //
            this.lblAusgabe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusgabe.Location = new System.Drawing.Point(321, 364);
            this.lblAusgabe.Name = "lblAusgabe";
            this.lblAusgabe.Size = new System.Drawing.Size(73, 24);
            this.lblAusgabe.TabIndex = 9;
            this.lblAusgabe.Text = "Ausgabe";
            this.lblAusgabe.UseCompatibleTextRendering = true;
            //
            // memAusgabe
            //
            this.memAusgabe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memAusgabe.DataMember = "ParameterOut";
            this.memAusgabe.DataSource = this.qryXAbaLog;
            this.memAusgabe.Location = new System.Drawing.Point(400, 364);
            this.memAusgabe.Name = "memAusgabe";
            this.memAusgabe.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memAusgabe.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memAusgabe.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memAusgabe.Properties.Appearance.Options.UseBackColor = true;
            this.memAusgabe.Properties.Appearance.Options.UseBorderColor = true;
            this.memAusgabe.Properties.Appearance.Options.UseFont = true;
            this.memAusgabe.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memAusgabe.Size = new System.Drawing.Size(395, 38);
            this.memAusgabe.TabIndex = 10;
            //
            // lblFehlerbericht
            //
            this.lblFehlerbericht.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFehlerbericht.Location = new System.Drawing.Point(8, 408);
            this.lblFehlerbericht.Name = "lblFehlerbericht";
            this.lblFehlerbericht.Size = new System.Drawing.Size(100, 23);
            this.lblFehlerbericht.TabIndex = 11;
            this.lblFehlerbericht.Text = "Fehlerbericht";
            this.lblFehlerbericht.UseCompatibleTextRendering = true;
            //
            // memFehlerbericht
            //
            this.memFehlerbericht.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memFehlerbericht.DataMember = "ExceptionMsg";
            this.memFehlerbericht.DataSource = this.qryXAbaLog;
            this.memFehlerbericht.Location = new System.Drawing.Point(114, 408);
            this.memFehlerbericht.Name = "memFehlerbericht";
            this.memFehlerbericht.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memFehlerbericht.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memFehlerbericht.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memFehlerbericht.Properties.Appearance.Options.UseBackColor = true;
            this.memFehlerbericht.Properties.Appearance.Options.UseBorderColor = true;
            this.memFehlerbericht.Properties.Appearance.Options.UseFont = true;
            this.memFehlerbericht.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memFehlerbericht.Size = new System.Drawing.Size(681, 54);
            this.memFehlerbericht.TabIndex = 12;
            //
            // lblBemerkungen
            //
            this.lblBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkungen.Location = new System.Drawing.Point(8, 468);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(100, 23);
            this.lblBemerkungen.TabIndex = 13;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            //
            // memBemerkungen
            //
            this.memBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memBemerkungen.DataMember = "Remark";
            this.memBemerkungen.DataSource = this.qryXAbaLog;
            this.memBemerkungen.Location = new System.Drawing.Point(114, 468);
            this.memBemerkungen.Name = "memBemerkungen";
            this.memBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungen.Size = new System.Drawing.Size(681, 24);
            this.memBemerkungen.TabIndex = 14;
            //
            // colExceptionMsg
            //
            this.colExceptionMsg.Caption = "Fehlerbericht";
            this.colExceptionMsg.FieldName = "ExceptionMsg";
            this.colExceptionMsg.Name = "colExceptionMsg";
            this.colExceptionMsg.Visible = true;
            this.colExceptionMsg.VisibleIndex = 6;
            this.colExceptionMsg.Width = 150;
            //
            // colID
            //
            this.colID.Caption = "ID";
            this.colID.FieldName = "AbaLogID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 70;
            //
            // colLogDate
            //
            this.colLogDate.Caption = "Datum";
            this.colLogDate.FieldName = "LogDate";
            this.colLogDate.Name = "colLogDate";
            this.colLogDate.Visible = true;
            this.colLogDate.VisibleIndex = 2;
            this.colLogDate.Width = 80;
            //
            // colParameterIn
            //
            this.colParameterIn.Caption = "Eingabe";
            this.colParameterIn.FieldName = "ParameterIn";
            this.colParameterIn.Name = "colParameterIn";
            this.colParameterIn.Visible = true;
            this.colParameterIn.VisibleIndex = 4;
            this.colParameterIn.Width = 150;
            //
            // colParameterOut
            //
            this.colParameterOut.Caption = "Ausgabe";
            this.colParameterOut.FieldName = "ParameterOut";
            this.colParameterOut.Name = "colParameterOut";
            this.colParameterOut.Visible = true;
            this.colParameterOut.VisibleIndex = 5;
            this.colParameterOut.Width = 150;
            //
            // colRemark
            //
            this.colRemark.Caption = "Bemerkungen";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 7;
            this.colRemark.Width = 150;
            //
            // colSchnittstelle
            //
            this.colSchnittstelle.Caption = "Schnittstelle";
            this.colSchnittstelle.FieldName = "Schnittstelle";
            this.colSchnittstelle.Name = "colSchnittstelle";
            this.colSchnittstelle.Visible = true;
            this.colSchnittstelle.VisibleIndex = 1;
            this.colSchnittstelle.Width = 150;
            //
            // colUser
            //
            this.colUser.Caption = "User";
            this.colUser.FieldName = "User";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 3;
            this.colUser.Width = 150;
            //
            // grvAbaLog
            //
            this.grvAbaLog.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAbaLog.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbaLog.Appearance.Empty.Options.UseBackColor = true;
            this.grvAbaLog.Appearance.Empty.Options.UseFont = true;
            this.grvAbaLog.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbaLog.Appearance.EvenRow.Options.UseFont = true;
            this.grvAbaLog.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbaLog.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbaLog.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAbaLog.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAbaLog.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAbaLog.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAbaLog.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAbaLog.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbaLog.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAbaLog.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAbaLog.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAbaLog.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAbaLog.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbaLog.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAbaLog.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAbaLog.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAbaLog.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbaLog.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAbaLog.Appearance.GroupRow.Options.UseFont = true;
            this.grvAbaLog.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAbaLog.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAbaLog.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAbaLog.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAbaLog.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAbaLog.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAbaLog.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAbaLog.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAbaLog.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbaLog.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAbaLog.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAbaLog.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAbaLog.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAbaLog.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbaLog.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAbaLog.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbaLog.Appearance.OddRow.Options.UseFont = true;
            this.grvAbaLog.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAbaLog.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbaLog.Appearance.Row.Options.UseBackColor = true;
            this.grvAbaLog.Appearance.Row.Options.UseFont = true;
            this.grvAbaLog.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAbaLog.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAbaLog.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAbaLog.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAbaLog.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAbaLog.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                        this.colID,
                        this.colSchnittstelle,
                        this.colLogDate,
                        this.colUser,
                        this.colParameterIn,
                        this.colParameterOut,
                        this.colExceptionMsg,
                        this.colRemark});
            this.grvAbaLog.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAbaLog.GridControl = this.grdAbaLog;
            this.grvAbaLog.Name = "grvAbaLog";
            this.grvAbaLog.OptionsBehavior.Editable = false;
            this.grvAbaLog.OptionsCustomization.AllowFilter = false;
            this.grvAbaLog.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAbaLog.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAbaLog.OptionsNavigation.UseTabKey = false;
            this.grvAbaLog.OptionsView.ColumnAutoWidth = false;
            this.grvAbaLog.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAbaLog.OptionsView.ShowGroupPanel = false;
            this.grvAbaLog.OptionsView.ShowIndicator = false;
            //
            // qryXAbaLog
            //
            this.qryXAbaLog.FillTimeOut = 300;
            this.qryXAbaLog.HostControl = this;
            this.qryXAbaLog.SelectStatement = resources.GetString("qryXAbaLog.SelectStatement");
            this.qryXAbaLog.TableName = "XAbaLog";
            this.qryXAbaLog.AfterFill += new System.EventHandler(this.qryXAbaLog_AfterFill);
            //
            // CtlAbaLogView
            //
            this.ActiveSQLQuery = this.qryXAbaLog;
            this.Controls.Add(this.memBemerkungen);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.memFehlerbericht);
            this.Controls.Add(this.lblFehlerbericht);
            this.Controls.Add(this.memAusgabe);
            this.Controls.Add(this.lblAusgabe);
            this.Controls.Add(this.memEingabe);
            this.Controls.Add(this.lblEingabe);
            this.Controls.Add(this.edtBenutzer);
            this.Controls.Add(this.lblBenutzer);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.edtSchnittstelle);
            this.Controls.Add(this.lblSchnittstelle);
            this.Name = "CtlAbaLogView";
            this.Load += new System.EventHandler(this.CtlAbaLogView_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblSchnittstelle, 0);
            this.Controls.SetChildIndex(this.edtSchnittstelle, 0);
            this.Controls.SetChildIndex(this.lblDatum, 0);
            this.Controls.SetChildIndex(this.edtDatum, 0);
            this.Controls.SetChildIndex(this.lblBenutzer, 0);
            this.Controls.SetChildIndex(this.edtBenutzer, 0);
            this.Controls.SetChildIndex(this.lblEingabe, 0);
            this.Controls.SetChildIndex(this.memEingabe, 0);
            this.Controls.SetChildIndex(this.lblAusgabe, 0);
            this.Controls.SetChildIndex(this.memAusgabe, 0);
            this.Controls.SetChildIndex(this.lblFehlerbericht, 0);
            this.Controls.SetChildIndex(this.memFehlerbericht, 0);
            this.Controls.SetChildIndex(this.lblBemerkungen, 0);
            this.Controls.SetChildIndex(this.memBemerkungen, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAbaLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbaLogID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbaLogID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheSchnittstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSchnittstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheSchnittstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBenutzer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheFehlerbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheFehlerbericht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheEingabe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheEingabe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAusgabe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAusgabe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSchnittstelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSchnittstelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBenutzer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBenutzer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEingabe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memEingabe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgabe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memAusgabe.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFehlerbericht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memFehlerbericht.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAbaLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryXAbaLog)).EndInit();
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
            // refresh search fields
            base.NewSearch();

            // only admin can enter id
            edtSucheAbaLogID.EditMode = Session.User.IsUserAdmin ? EditModeType.Normal : EditModeType.ReadOnly;

            // only admin can select user
            edtSucheBenutzer.EditMode = Session.User.IsUserAdmin ? EditModeType.Normal : EditModeType.ReadOnly;
            edtSucheBenutzer.EditValue = Session.User.IsUserAdmin ? DBNull.Value : (Object)this.UserFullName;
            edtSucheBenutzer.LookupID = Session.User.IsUserAdmin ? DBNull.Value : (Object)Session.User.UserID;

            // default values (search only from current date)
            edtSucheDatumVon.EditValue = DateTime.Today.Date;

            // set focus
            edtSucheSchnittstelle.Focus();
        }

        protected override void RunSearch()
        {
            // userid
            Object userID = DBNull.Value;

            if (!DBUtil.IsEmpty(edtSucheBenutzer.LookupID))
            {
                userID = edtSucheBenutzer.LookupID;
            }

            // replace search parameters
            Object[] parameters = new Object[] { Session.User.LanguageCode, userID };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlAbaLogView_Load(object sender, System.EventArgs e)
        {
            // start a new search (default behaviour) and switch to tabListe
            this.NewSearch();

            // run search (disabled)
            //this.tabControlSearch.SelectedTabIndex = 0;
        }

        private Boolean DialogUser(Object sender, UserModifiedFldEventArgs e)
        {
            try
            {
                // check if data can be altered
                if (edtSucheBenutzer.EditMode == EditModeType.ReadOnly)
                {
                    // do nothing
                    return true;
                }

                // prepare search string
                String searchString = "";

                // check if we have a value to parse
                if (!DBUtil.IsEmpty(edtSucheBenutzer.EditValue))
                {
                    // prepare for database search
                    searchString = edtSucheBenutzer.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%").Replace("'", "''");
                }

                // validate search string
                if (DBUtil.IsEmpty(searchString))
                {
                    if (e.ButtonClicked)
                    {
                        // if no data entered and the button is clicked, show dialog with all data
                        searchString = "%";
                    }
                    else
                    {
                        edtSucheBenutzer.EditValue = DBNull.Value;
                        edtSucheBenutzer.LookupID = DBNull.Value;
                        return true;
                    }
                }

                // Mitarbeiter_Suchen()
                KissLookupDialog dlg = new KissLookupDialog();

                e.Cancel = !dlg.SearchData(String.Format(@"
                    SELECT USR.*
                    FROM dbo.fnDlgMitarbeiterSuchenKGS({0}) USR
                    WHERE USR.Name LIKE '{1}%'", Session.User.UserID, searchString), searchString, e.ButtonClicked, null, null, null);

                if (!e.Cancel)
                {
                    // apply new value
                    edtSucheBenutzer.EditValue = dlg["Name"];
                    edtSucheBenutzer.LookupID = dlg["UserID$"];

                    // success
                    return true;
                }
                else
                {
                    // canceled or error
                    return false;
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlAbaLogView", "ErrorIKissUserModified", "Fehler bei der Verarbeitung.", ex);
                return false;
            }
        }

        private void edtSucheBenutzer_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            e.Cancel = !this.DialogUser(sender, e);
        }

        private void qryXAbaLog_AfterFill(object sender, System.EventArgs e)
        {
            // select last row
            qryXAbaLog.Last();
        }

        #endregion
    }
}