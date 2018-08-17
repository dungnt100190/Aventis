using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    public class CtlQueryBaBerufMassnahmeIBE : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissTextEdit edtAHVMindestbeitr;
        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissTextEdit edtBerufMassnahmen;
        private KiSS4.Gui.KissDateEdit edtDauerBis;
        private KiSS4.Gui.KissDateEdit edtDauerVon;
        private KiSS4.Gui.KissLookUpEdit edtEinrichtungPauschale;
        private KiSS4.Gui.KissTextEdit edtNNr;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissTextEdit edtZemisNr;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblAHVMindestbeitr;
        private KiSS4.Gui.KissLabel lblBerufMassnahmen;
        private KiSS4.Gui.KissLabel lblDauerVon;
        private KiSS4.Gui.KissLabel lblEinrichtungPauschale;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblNNr;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblZemisNr;
        private KiSS4.Gui.KissLabel lblbis;

        #endregion

        #region Constructors

        public CtlQueryBaBerufMassnahmeIBE()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaBerufMassnahmeIBE));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtNNr = new KiSS4.Gui.KissTextEdit();
            this.edtZemisNr = new KiSS4.Gui.KissTextEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.edtEinrichtungPauschale = new KiSS4.Gui.KissLookUpEdit();
            this.edtBerufMassnahmen = new KiSS4.Gui.KissTextEdit();
            this.edtAHVMindestbeitr = new KiSS4.Gui.KissTextEdit();
            this.edtDauerVon = new KiSS4.Gui.KissDateEdit();
            this.edtDauerBis = new KiSS4.Gui.KissDateEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblNNr = new KiSS4.Gui.KissLabel();
            this.lblZemisNr = new KiSS4.Gui.KissLabel();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.lblEinrichtungPauschale = new KiSS4.Gui.KissLabel();
            this.lblBerufMassnahmen = new KiSS4.Gui.KissLabel();
            this.lblAHVMindestbeitr = new KiSS4.Gui.KissLabel();
            this.lblDauerVon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZemisNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinrichtungPauschale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinrichtungPauschale.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufMassnahmen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVMindestbeitr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauerVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauerBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZemisNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinrichtungPauschale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerufMassnahmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVMindestbeitr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauerVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            this.SuspendLayout();
            //
            // qryQuery
            //
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.gridView1});
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = "BaPersonID$";
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblDauerVon);
            this.tpgSuchen.Controls.Add(this.lblAHVMindestbeitr);
            this.tpgSuchen.Controls.Add(this.lblBerufMassnahmen);
            this.tpgSuchen.Controls.Add(this.lblEinrichtungPauschale);
            this.tpgSuchen.Controls.Add(this.lblKlient);
            this.tpgSuchen.Controls.Add(this.lblZemisNr);
            this.tpgSuchen.Controls.Add(this.lblNNr);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtDauerBis);
            this.tpgSuchen.Controls.Add(this.edtDauerVon);
            this.tpgSuchen.Controls.Add(this.edtAHVMindestbeitr);
            this.tpgSuchen.Controls.Add(this.edtBerufMassnahmen);
            this.tpgSuchen.Controls.Add(this.edtEinrichtungPauschale);
            this.tpgSuchen.Controls.Add(this.edtBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtZemisNr);
            this.tpgSuchen.Controls.Add(this.edtNNr);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtZemisNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinrichtungPauschale, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBerufMassnahmen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAHVMindestbeitr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDauerVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDauerBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZemisNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKlient, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEinrichtungPauschale, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBerufMassnahmen, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAHVMindestbeitr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDauerVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            //
            // edtNNr
            //
            this.edtNNr.Location = new System.Drawing.Point(161, 48);
            this.edtNNr.Name = "edtNNr";
            this.edtNNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtNNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNNr.Properties.Appearance.Options.UseFont = true;
            this.edtNNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNNr.Size = new System.Drawing.Size(111, 24);
            this.edtNNr.TabIndex = 1;
            //
            // edtZemisNr
            //
            this.edtZemisNr.Location = new System.Drawing.Point(161, 79);
            this.edtZemisNr.Name = "edtZemisNr";
            this.edtZemisNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZemisNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZemisNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZemisNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtZemisNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZemisNr.Properties.Appearance.Options.UseFont = true;
            this.edtZemisNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZemisNr.Size = new System.Drawing.Size(111, 24);
            this.edtZemisNr.TabIndex = 2;
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.Location = new System.Drawing.Point(161, 109);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(250, 24);
            this.edtBaPersonID.TabIndex = 3;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            //
            // edtEinrichtungPauschale
            //
            this.edtEinrichtungPauschale.Location = new System.Drawing.Point(161, 139);
            this.edtEinrichtungPauschale.LOVName = "Einrichtungspauschale";
            this.edtEinrichtungPauschale.Name = "edtEinrichtungPauschale";
            this.edtEinrichtungPauschale.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinrichtungPauschale.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinrichtungPauschale.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinrichtungPauschale.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinrichtungPauschale.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinrichtungPauschale.Properties.Appearance.Options.UseFont = true;
            this.edtEinrichtungPauschale.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinrichtungPauschale.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinrichtungPauschale.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinrichtungPauschale.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinrichtungPauschale.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtEinrichtungPauschale.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtEinrichtungPauschale.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinrichtungPauschale.Properties.NullText = "";
            this.edtEinrichtungPauschale.Properties.ShowFooter = false;
            this.edtEinrichtungPauschale.Properties.ShowHeader = false;
            this.edtEinrichtungPauschale.Size = new System.Drawing.Size(250, 24);
            this.edtEinrichtungPauschale.TabIndex = 4;
            //
            // edtBerufMassnahmen
            //
            this.edtBerufMassnahmen.Location = new System.Drawing.Point(161, 169);
            this.edtBerufMassnahmen.Name = "edtBerufMassnahmen";
            this.edtBerufMassnahmen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBerufMassnahmen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBerufMassnahmen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBerufMassnahmen.Properties.Appearance.Options.UseBackColor = true;
            this.edtBerufMassnahmen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBerufMassnahmen.Properties.Appearance.Options.UseFont = true;
            this.edtBerufMassnahmen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBerufMassnahmen.Size = new System.Drawing.Size(111, 24);
            this.edtBerufMassnahmen.TabIndex = 5;
            //
            // edtAHVMindestbeitr
            //
            this.edtAHVMindestbeitr.Location = new System.Drawing.Point(161, 199);
            this.edtAHVMindestbeitr.Name = "edtAHVMindestbeitr";
            this.edtAHVMindestbeitr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHVMindestbeitr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHVMindestbeitr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHVMindestbeitr.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHVMindestbeitr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHVMindestbeitr.Properties.Appearance.Options.UseFont = true;
            this.edtAHVMindestbeitr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHVMindestbeitr.Size = new System.Drawing.Size(111, 24);
            this.edtAHVMindestbeitr.TabIndex = 6;
            //
            // edtDauerVon
            //
            this.edtDauerVon.EditValue = "";
            this.edtDauerVon.Location = new System.Drawing.Point(161, 228);
            this.edtDauerVon.Name = "edtDauerVon";
            this.edtDauerVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDauerVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDauerVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDauerVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDauerVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDauerVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDauerVon.Properties.Appearance.Options.UseFont = true;
            this.edtDauerVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDauerVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDauerVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDauerVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDauerVon.Properties.ShowToday = false;
            this.edtDauerVon.Size = new System.Drawing.Size(100, 24);
            this.edtDauerVon.TabIndex = 7;
            //
            // edtDauerBis
            //
            this.edtDauerBis.EditValue = "";
            this.edtDauerBis.Location = new System.Drawing.Point(311, 228);
            this.edtDauerBis.Name = "edtDauerBis";
            this.edtDauerBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDauerBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDauerBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDauerBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDauerBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDauerBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDauerBis.Properties.Appearance.Options.UseFont = true;
            this.edtDauerBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDauerBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDauerBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDauerBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDauerBis.Properties.ShowToday = false;
            this.edtDauerBis.Size = new System.Drawing.Size(100, 24);
            this.edtDauerBis.TabIndex = 8;
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(161, 258);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(250, 24);
            this.edtUserID.TabIndex = 9;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            //
            // lblNNr
            //
            this.lblNNr.Location = new System.Drawing.Point(21, 48);
            this.lblNNr.Name = "lblNNr";
            this.lblNNr.Size = new System.Drawing.Size(130, 24);
            this.lblNNr.TabIndex = 10;
            this.lblNNr.Text = "N-Nr";
            this.lblNNr.UseCompatibleTextRendering = true;
            //
            // lblZemisNr
            //
            this.lblZemisNr.Location = new System.Drawing.Point(21, 79);
            this.lblZemisNr.Name = "lblZemisNr";
            this.lblZemisNr.Size = new System.Drawing.Size(130, 24);
            this.lblZemisNr.TabIndex = 11;
            this.lblZemisNr.Text = "Zemis-Nr";
            this.lblZemisNr.UseCompatibleTextRendering = true;
            //
            // lblKlient
            //
            this.lblKlient.Location = new System.Drawing.Point(21, 109);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(130, 24);
            this.lblKlient.TabIndex = 12;
            this.lblKlient.Text = "Klient";
            this.lblKlient.UseCompatibleTextRendering = true;
            //
            // lblEinrichtungPauschale
            //
            this.lblEinrichtungPauschale.Location = new System.Drawing.Point(21, 139);
            this.lblEinrichtungPauschale.Name = "lblEinrichtungPauschale";
            this.lblEinrichtungPauschale.Size = new System.Drawing.Size(130, 24);
            this.lblEinrichtungPauschale.TabIndex = 13;
            this.lblEinrichtungPauschale.Text = "Einrichtungspauschale";
            this.lblEinrichtungPauschale.UseCompatibleTextRendering = true;
            //
            // lblBerufMassnahmen
            //
            this.lblBerufMassnahmen.Location = new System.Drawing.Point(21, 169);
            this.lblBerufMassnahmen.Name = "lblBerufMassnahmen";
            this.lblBerufMassnahmen.Size = new System.Drawing.Size(130, 24);
            this.lblBerufMassnahmen.TabIndex = 14;
            this.lblBerufMassnahmen.Text = "beruf. Massnahmen";
            this.lblBerufMassnahmen.UseCompatibleTextRendering = true;
            //
            // lblAHVMindestbeitr
            //
            this.lblAHVMindestbeitr.Location = new System.Drawing.Point(21, 199);
            this.lblAHVMindestbeitr.Name = "lblAHVMindestbeitr";
            this.lblAHVMindestbeitr.Size = new System.Drawing.Size(130, 24);
            this.lblAHVMindestbeitr.TabIndex = 15;
            this.lblAHVMindestbeitr.Text = "AHV-Mindestbeiträge";
            this.lblAHVMindestbeitr.UseCompatibleTextRendering = true;
            //
            // lblDauerVon
            //
            this.lblDauerVon.Location = new System.Drawing.Point(21, 228);
            this.lblDauerVon.Name = "lblDauerVon";
            this.lblDauerVon.Size = new System.Drawing.Size(130, 24);
            this.lblDauerVon.TabIndex = 16;
            this.lblDauerVon.Text = "Dauer von";
            this.lblDauerVon.UseCompatibleTextRendering = true;
            //
            // lblbis
            //
            this.lblbis.Location = new System.Drawing.Point(271, 228);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(34, 24);
            this.lblbis.TabIndex = 17;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(21, 258);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 18;
            this.lblSAR.Text = "zuständiger SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
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
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grdQuery1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            this.grvQuery1.GridControl = this.grdQuery1;
            this.grvQuery1.Name = "grvQuery1";
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
            // CtlQueryBaBerufMassnahmeIBE
            //
            this.Name = "CtlQueryBaBerufMassnahmeIBE";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZemisNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinrichtungPauschale.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinrichtungPauschale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBerufMassnahmen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHVMindestbeitr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauerVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDauerBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZemisNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEinrichtungPauschale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBerufMassnahmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHVMindestbeitr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDauerVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Private Methods

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtBaPersonID.EditValue = null;
                    edtBaPersonID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtBaPersonID.EditValue = dlg["Name"];
                edtBaPersonID.LookupID = dlg["BaPersonID"];
            }
        }

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion
    }
}