using System;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query
{
    public class CtlQueryKaBelegMotivation : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colDavonAusweisF;
        private DevExpress.XtraGrid.Columns.GridColumn colDavonSozialdienstBern;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalderaktuelleSTES;
        private System.ComponentModel.IContainer components;
        private Common.CtlGotoFall ctlGotoFallRohdaten;
        private KiSS4.Gui.KissLookUpEdit edtAuswZuweiser;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissButtonEdit edtFachbereichID;
        private KiSS4.Gui.KissLookUpEdit edtNiveauCode;
        private KissGrid grdRohdaten;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRohdaten;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.Gui.KissLabel lblDatumvon;
        private KiSS4.Gui.KissLabel lblFachbereich;
        private KiSS4.Gui.KissLabel lblNiveau;
        private KiSS4.Gui.KissLabel lblZuweiser;
        private SqlQuery qryRohdaten;
        private SharpLibrary.WinControls.TabPageEx tpgRohdaten;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryKaBelegMotivation()
        {
            this.InitializeComponent();

            edtDatumVon.EditValue = DBUtil.ExecuteScalarSQL(@"select convert(varchar, dateadd(dd, (datepart(dw, GetDate()) * -1) + 2, GetDate()), 104)").ToString();
            edtDatumBis.EditValue = DBUtil.ExecuteScalarSQL(@"select convert(varchar, dateadd(dd, (datepart(dw, GetDate()) * -1) + 6, GetDate()), 104)").ToString();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaBelegMotivation));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblDatumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblNiveau = new KiSS4.Gui.KissLabel();
            this.lblZuweiser = new KiSS4.Gui.KissLabel();
            this.lblFachbereich = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtFachbereichID = new KiSS4.Gui.KissButtonEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtNiveauCode = new KiSS4.Gui.KissLookUpEdit();
            this.edtAuswZuweiser = new KiSS4.Gui.KissLookUpEdit();
            this.colColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDavonAusweisF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDavonSozialdienstBern = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalderaktuelleSTES = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tpgRohdaten = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallRohdaten = new KiSS4.Common.CtlGotoFall();
            this.qryRohdaten = new KiSS4.DB.SqlQuery(this.components);
            this.grdRohdaten = new KiSS4.Gui.KissGrid();
            this.grvRohdaten = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNiveau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFachbereichID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZuweiser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZuweiser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tpgRohdaten.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryRohdaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten)).BeginInit();
            this.SuspendLayout();
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
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Visible = false;
            //
            // tabControlSearch
            //
            this.tabControlSearch.Controls.Add(this.tpgRohdaten);
            this.tabControlSearch.SelectedTabIndex = 2;
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
                this.tpgRohdaten});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgRohdaten, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtAuswZuweiser);
            this.tpgSuchen.Controls.Add(this.edtNiveauCode);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtFachbereichID);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.lblFachbereich);
            this.tpgSuchen.Controls.Add(this.lblZuweiser);
            this.tpgSuchen.Controls.Add(this.lblNiveau);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblDatumvon);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNiveau, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZuweiser, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblFachbereich, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFachbereichID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNiveauCode, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAuswZuweiser, 0);
            //
            // lblDatumvon
            //
            this.lblDatumvon.Location = new System.Drawing.Point(10, 40);
            this.lblDatumvon.Name = "lblDatumvon";
            this.lblDatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblDatumvon.TabIndex = 1;
            this.lblDatumvon.Text = "Datum von";
            this.lblDatumvon.UseCompatibleTextRendering = true;
            //
            // lblbis
            //
            this.lblbis.Location = new System.Drawing.Point(270, 40);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 2;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            //
            // lblNiveau
            //
            this.lblNiveau.Location = new System.Drawing.Point(10, 70);
            this.lblNiveau.Name = "lblNiveau";
            this.lblNiveau.Size = new System.Drawing.Size(130, 24);
            this.lblNiveau.TabIndex = 3;
            this.lblNiveau.Text = "Niveau";
            this.lblNiveau.UseCompatibleTextRendering = true;
            //
            // lblZuweiser
            //
            this.lblZuweiser.Location = new System.Drawing.Point(10, 100);
            this.lblZuweiser.Name = "lblZuweiser";
            this.lblZuweiser.Size = new System.Drawing.Size(130, 24);
            this.lblZuweiser.TabIndex = 4;
            this.lblZuweiser.Text = "Zuweiser";
            this.lblZuweiser.UseCompatibleTextRendering = true;
            //
            // lblFachbereich
            //
            this.lblFachbereich.Location = new System.Drawing.Point(10, 130);
            this.lblFachbereich.Name = "lblFachbereich";
            this.lblFachbereich.Size = new System.Drawing.Size(130, 24);
            this.lblFachbereich.TabIndex = 5;
            this.lblFachbereich.Text = "Fachbereich";
            this.lblFachbereich.UseCompatibleTextRendering = true;
            //
            // edtDatumVon
            //
            this.edtDatumVon.EditValue = "";
            this.edtDatumVon.Location = new System.Drawing.Point(150, 40);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 21;
            //
            // edtFachbereichID
            //
            this.edtFachbereichID.Location = new System.Drawing.Point(150, 130);
            this.edtFachbereichID.LookupSQL = "select ID = Code, Fachbereich = Text, Abteilung = Value1\nfrom   XLOVCode XLC \t\t\t\t" +
                                              "\t\nwhere  XLC.Text like {0} + \'%\'\nand    XLC.LOVName = \'KAFachbereich\'\t\t\t\t\norder " +
                                              "by XLC.Text";
            this.edtFachbereichID.Name = "edtFachbereichID";
            this.edtFachbereichID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFachbereichID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFachbereichID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFachbereichID.Properties.Appearance.Options.UseBackColor = true;
            this.edtFachbereichID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFachbereichID.Properties.Appearance.Options.UseFont = true;
            this.edtFachbereichID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtFachbereichID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtFachbereichID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtFachbereichID.Size = new System.Drawing.Size(250, 24);
            this.edtFachbereichID.TabIndex = 21;
            this.edtFachbereichID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtFachbereichID_UserModifiedFld);
            //
            // edtDatumBis
            //
            this.edtDatumBis.EditValue = "";
            this.edtDatumBis.Location = new System.Drawing.Point(300, 40);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 22;
            //
            // edtNiveauCode
            //
            this.edtNiveauCode.Location = new System.Drawing.Point(150, 70);
            this.edtNiveauCode.LOVName = "KaQjNiveau";
            this.edtNiveauCode.Name = "edtNiveauCode";
            this.edtNiveauCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNiveauCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNiveauCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNiveauCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtNiveauCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNiveauCode.Properties.Appearance.Options.UseFont = true;
            this.edtNiveauCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtNiveauCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtNiveauCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtNiveauCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtNiveauCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtNiveauCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtNiveauCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNiveauCode.Properties.NullText = "";
            this.edtNiveauCode.Properties.ShowFooter = false;
            this.edtNiveauCode.Properties.ShowHeader = false;
            this.edtNiveauCode.Size = new System.Drawing.Size(250, 24);
            this.edtNiveauCode.TabIndex = 23;
            //
            // edtAuswZuweiser
            //
            this.edtAuswZuweiser.Location = new System.Drawing.Point(150, 100);
            this.edtAuswZuweiser.LOVName = "KaAuswahlZuweiser";
            this.edtAuswZuweiser.Name = "edtAuswZuweiser";
            this.edtAuswZuweiser.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAuswZuweiser.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAuswZuweiser.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswZuweiser.Properties.Appearance.Options.UseBackColor = true;
            this.edtAuswZuweiser.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAuswZuweiser.Properties.Appearance.Options.UseFont = true;
            this.edtAuswZuweiser.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAuswZuweiser.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAuswZuweiser.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAuswZuweiser.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAuswZuweiser.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtAuswZuweiser.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtAuswZuweiser.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAuswZuweiser.Properties.NullText = "";
            this.edtAuswZuweiser.Properties.ShowFooter = false;
            this.edtAuswZuweiser.Properties.ShowHeader = false;
            this.edtAuswZuweiser.Size = new System.Drawing.Size(250, 24);
            this.edtAuswZuweiser.TabIndex = 24;
            //
            // colColumn1
            //
            this.colColumn1.Name = "colColumn1";
            //
            // colDavonAusweisF
            //
            this.colDavonAusweisF.Name = "colDavonAusweisF";
            //
            // colDavonSozialdienstBern
            //
            this.colDavonSozialdienstBern.Name = "colDavonSozialdienstBern";
            //
            // colTotalderaktuelleSTES
            //
            this.colTotalderaktuelleSTES.Name = "colTotalderaktuelleSTES";
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
            // tpgRohdaten
            //
            this.tpgRohdaten.Controls.Add(this.ctlGotoFallRohdaten);
            this.tpgRohdaten.Controls.Add(this.grdRohdaten);
            this.tpgRohdaten.Location = new System.Drawing.Point(6, 6);
            this.tpgRohdaten.Name = "tpgRohdaten";
            this.tpgRohdaten.Size = new System.Drawing.Size(772, 424);
            this.tpgRohdaten.TabIndex = 1;
            this.tpgRohdaten.Title = "Rohdaten";
            //
            // ctlGotoFallRohdaten
            //
            this.ctlGotoFallRohdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallRohdaten.DataMember = "BaPersonID$";
            this.ctlGotoFallRohdaten.DataSource = this.qryRohdaten;
            this.ctlGotoFallRohdaten.Location = new System.Drawing.Point(3, 398);
            this.ctlGotoFallRohdaten.Name = "ctlGotoFallRohdaten";
            this.ctlGotoFallRohdaten.Size = new System.Drawing.Size(177, 25);
            this.ctlGotoFallRohdaten.TabIndex = 1;
            //
            // qryRohdaten
            //
            this.qryRohdaten.HostControl = this;
            //
            // grdRohdaten
            //
            this.grdRohdaten.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                                                             | System.Windows.Forms.AnchorStyles.Left)
                                                                            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRohdaten.ColumnFilterActivated = true;
            this.grdRohdaten.DataSource = this.qryRohdaten;
            //
            //
            //
            this.grdRohdaten.EmbeddedNavigator.Name = "";
            this.grdRohdaten.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdRohdaten.Location = new System.Drawing.Point(3, 3);
            this.grdRohdaten.MainView = this.grvRohdaten;
            this.grdRohdaten.Name = "grdRohdaten";
            this.grdRohdaten.Size = new System.Drawing.Size(766, 389);
            this.grdRohdaten.TabIndex = 0;
            this.grdRohdaten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                this.grvRohdaten});
            //
            // grvRohdaten
            //
            this.grvRohdaten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRohdaten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.Empty.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.Empty.Options.UseFont = true;
            this.grvRohdaten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.EvenRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRohdaten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvRohdaten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvRohdaten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRohdaten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.GroupRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRohdaten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRohdaten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRohdaten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRohdaten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRohdaten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvRohdaten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRohdaten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRohdaten.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.OddRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvRohdaten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.Row.Options.UseBackColor = true;
            this.grvRohdaten.Appearance.Row.Options.UseFont = true;
            this.grvRohdaten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRohdaten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRohdaten.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvRohdaten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRohdaten.BestFitMaxRowCount = 1000;
            this.grvRohdaten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRohdaten.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvRohdaten.GridControl = this.grdRohdaten;
            this.grvRohdaten.Name = "grvRohdaten";
            this.grvRohdaten.OptionsBehavior.Editable = false;
            this.grvRohdaten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRohdaten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRohdaten.OptionsNavigation.UseTabKey = false;
            this.grvRohdaten.OptionsView.ColumnAutoWidth = false;
            this.grvRohdaten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRohdaten.OptionsView.ShowGroupPanel = false;
            this.grvRohdaten.OptionsView.ShowIndicator = false;
            //
            // CtlQueryKaBelegMotivation
            //
            this.Name = "CtlQueryKaBelegMotivation";
            this.Load += new System.EventHandler(this.CtlQueryKaBelegMotivation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNiveau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFachbereich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFachbereichID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNiveauCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZuweiser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAuswZuweiser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tpgRohdaten.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryRohdaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRohdaten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRohdaten)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region EventHandlers

        private void CtlQueryKaBelegMotivation_Load(object sender, EventArgs e)
        {
            qryQuery.SelectStatement = GetListeQueryStatement();
            qryRohdaten.SelectStatement = GetRohdatenQueryStatement();
        }

        private void edtFachbereichID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtFachbereichID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtFachbereichID.EditValue = null;
                    edtFachbereichID.LookupID = null;
                    return;
                }
            }

            KissLookupDialog dlg = new KissLookupDialog();
            e.Cancel = !dlg.SearchData(@"
                SELECT ID = Code, Fachbereich = Text, Abteilung = Value1
                FROM   XLOVCode XLC
                WHERE  XLC.Text like '%' + {0} + '%'
                AND    XLC.LOVName = 'KAFachbereich'
                ORDER BY XLC.Text",
                SearchString,
                e.ButtonClicked, null, null, null);

            if (!e.Cancel)
            {
                edtFachbereichID.EditValue = dlg[1];
                edtFachbereichID.LookupID = dlg[0];
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtDatumVon.EditValue = DBUtil.ExecuteScalarSQL(@"select convert(varchar, dateadd(dd, (datepart(dw, GetDate()) * -1) + 2, GetDate()), 104)").ToString();
            edtDatumBis.EditValue = DBUtil.ExecuteScalarSQL(@"select convert(varchar, dateadd(dd, (datepart(dw, GetDate()) * -1) + 6, GetDate()), 104)").ToString();
            edtAuswZuweiser.EditValue = null;
            edtFachbereichID.EditValue = null;
            edtFachbereichID.LookupID = null;
            edtNiveauCode.EditValue = null;
        }

        #endregion

        #region Private Methods

        private string GetListeQueryStatement()
        {
            string statement = @"
                DECLARE @SucheDatumVon DATETIME, @SucheDatumBis DATETIME, @NiveauCode INT, @FachbereichID INT;

                SELECT @SucheDatumVon = dbo.fnDateOf(dateadd(dd, (datepart(dw, GetDate()) * -1) + 2, GetDate()));
                --- SET @SucheDatumVon = {edtDatumVon}

                SELECT @SucheDatumBis = dbo.fnDateOf(dateadd(dd, (datepart(dw, GetDate()) * -1) + 6, GetDate()));
                --- SET @SucheDatumBis = {edtDatumBis};
                SET @NiveauCode = NULL;
                --- SET @NiveauCode = {edtNiveauCode};
                SET @FachbereichID = NULL;
                --- SET @FachbereichID = {edtFachbereichID.LookupID};

                IF OBJECT_ID('TempDB.dbo.#Temp') IS NOT NULL
                BEGIN
                  DROP TABLE #Temp;
                END;

                --Einsatz Temp Table
                SELECT
                  LEI.FaLeistungID,
                  ZuweiserID            = EIN.ZuweiserID,
                  KaZuteilFachbereichID = (SELECT TOP 1 SUB1.KaZuteilFachbereichID FROM dbo.KaZuteilFachbereich SUB1
                                           WHERE SUB1.BaPersonID = LEI.BaPersonID
                                            AND (@NiveauCode IS NULL OR SUB1.NiveauCode = @NiveauCode)
                                            AND (@FachbereichID IS NULL OR SUB1.FachbereichID = @FachbereichID)
                                            AND (SUB1.ZuteilungBis IS NULL OR dbo.fnDateOf(SUB1.ZuteilungBis) >= @SucheDatumVon)
                                            AND dbo.fnDateOf(SUB1.ZuteilungVon) <= @SucheDatumBis
                                            AND (SUB1.ZuteilungBis IS NULL OR LEI.DatumBis IS NULL OR dbo.fnDateOf(SUB1.ZuteilungBis) <= dbo.fnDateOf(LEI.DatumBis))
                                            AND dbo.fnDateOf(SUB1.ZuteilungVon) >= dbo.fnDateOf(LEI.DatumVon)
                                           ORDER BY SUB1.ZuteilungVon DESC)
                INTO #Temp
                FROM dbo.FaLeistung LEI
                  CROSS APPLY (SELECT TOP 1 SUB.ZuweiserID FROM dbo.KaEinsatz SUB OUTER APPLY dbo.fnKaGetAustrittDatumCode(SUB.FaLeistungID, SUB.KaEinsatzID) AUS
                               WHERE SUB.AnweisungCode <> 1 --Alle AUSSER Zuweisung
                                 AND (dbo.fnDateOf(AUS.AustrittDatum) >= @SucheDatumVon OR (AUS.AustrittDatum IS NULL AND dbo.fnDateOf(SUB.DatumBis) >= @SucheDatumVon))
                                 AND dbo.fnDateOf(SUB.DatumVon) <= @SucheDatumBis
                                 AND SUB.FaLeistungID = LEI.FaLeistungID
                                  ORDER BY SUB.DatumBis DESC) EIN
                WHERE LEI.ModulID = 7 -- Modul KA
                  AND LEI.FaProzessCode = 703 -- Phase QJ
                  AND ZuweiserID IS NOT NULL;

                DECLARE @Temp TABLE(
                  Fachbereich VARCHAR(255),
                  BaPersonID INT,
                  AuslStatusF INT,
                  ZuweiserSD INT
                )

                --CTE
                ;WITH SDOrgUnits(OrgUnitID, ItemName)
                AS
                (
                  SELECT ORG.OrgUnitID, ORG.ItemName
                    FROM XOrgUnit ORG
                    WHERE ORG.ItemName LIKE 'Sozialdienst'
                  UNION ALL
                  SELECT ORG.OrgUnitID, ORG.ItemName
                    FROM XOrgUnit ORG
                    INNER JOIN SDOrgUnits SDO on SDO.OrgUnitID = ORG.ParentID
                )
                INSERT INTO @Temp
                SELECT
                  Fachbereich = dbo.fnLOVMLText('KaFachbereich', KZF.FachbereichID, 1),
                  BaPersonID$ = PRS.BaPersonID,
                  AuslStatusF$ = CASE WHEN PRS.AuslaenderStatusCode IN (15,16) THEN 1 ELSE NULL END,
                  ZuweiserSD$ = (SELECT 1 FROM dbo.XOrgUnit SUB
                                  INNER JOIN SDOrgUnits SUB1 ON SUB1.OrgUnitID = SUB.OrgUnitID
                                  WHERE SUB.OrgUnitID = ORG.OrgUnitID)
                FROM #Temp TMP
                  INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TMP.FaLeistungID
                  INNER JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.KaZuteilFachbereichID = TMP.KaZuteilFachbereichID
                  INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                  LEFT JOIN dbo.BaInstitutionKontakt OKO WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = TMP.ZuweiserID
                  LEFT JOIN dbo.BaInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = OKO.BaInstitutionID
                  LEFT JOIN dbo.XOrgUnit_User ORU WITH (READUNCOMMITTED) ON ORU.UserID = -TMP.ZuweiserID AND ORU.OrgUnitMemberCode IN (1,2)
                  LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = ORU.OrgUnitID
                WHERE TMP.ZuweiserID IS NOT NULL
                ---  AND ((1 = {edtAuswZuweiser} AND INS.Name LIKE 'RAV%') OR (2 = {edtAuswZuweiser} AND (INS.Name IS NULL OR INS.Name NOT LIKE 'RAV%')))
                ;

                SELECT
                  Fachbereich,
                  [Total STES] = COUNT(BaPersonID),
                  [SD Bern] = COUNT(ZuweiserSD),
                  [Total Status F] = COUNT(AuslStatusF)
                FROM @Temp
                GROUP BY Fachbereich;

                IF OBJECT_ID('TempDB.dbo.#Temp') IS NOT NULL
                BEGIN
                  DROP TABLE #Temp;
                END;";

            return statement;
        }

        private string GetRohdatenQueryStatement()
        {
            string statement = @"
                DECLARE @SucheDatumVon DATETIME, @SucheDatumBis DATETIME, @NiveauCode INT, @FachbereichID INT;

                SELECT @SucheDatumVon = dbo.fnDateOf(dateadd(dd, (datepart(dw, GetDate()) * -1) + 2, GetDate()));
                --- SET @SucheDatumVon = {edtDatumVon}

                SELECT @SucheDatumBis = dbo.fnDateOf(dateadd(dd, (datepart(dw, GetDate()) * -1) + 6, GetDate()));
                --- SET @SucheDatumBis = {edtDatumBis};
                SET @NiveauCode = NULL;
                --- SET @NiveauCode = {edtNiveauCode};
                SET @FachbereichID = NULL;
                --- SET @FachbereichID = {edtFachbereichID.LookupID};

                IF OBJECT_ID('TempDB.dbo.#Temp') IS NOT NULL
                BEGIN
                  DROP TABLE #Temp;
                END;

                --Einsatz Temp Table
                SELECT
                  LEI.FaLeistungID,
                  ZuweiserID            =  EIN.ZuweiserID,
                  KaZuteilFachbereichID = (SELECT TOP 1 SUB1.KaZuteilFachbereichID FROM dbo.KaZuteilFachbereich SUB1
                                           WHERE SUB1.BaPersonID = LEI.BaPersonID
                                            AND (@NiveauCode IS NULL OR SUB1.NiveauCode = @NiveauCode)
                                            AND (@FachbereichID IS NULL OR SUB1.FachbereichID = @FachbereichID)
                                            AND (SUB1.ZuteilungBis IS NULL OR dbo.fnDateOf(SUB1.ZuteilungBis) >= @SucheDatumVon)
                                            AND dbo.fnDateOf(SUB1.ZuteilungVon) <= @SucheDatumBis
                                            AND (SUB1.ZuteilungBis IS NULL OR LEI.DatumBis IS NULL OR dbo.fnDateOf(SUB1.ZuteilungBis) <= dbo.fnDateOf(LEI.DatumBis))
                                            AND dbo.fnDateOf(SUB1.ZuteilungVon) >= dbo.fnDateOf(LEI.DatumVon)
                                           ORDER BY SUB1.ZuteilungVon DESC),
                 EIN.BeschGrad
                INTO #Temp
                FROM dbo.FaLeistung LEI
                  CROSS APPLY (SELECT TOP 1 SUB.ZuweiserID, SUB.BeschGrad FROM dbo.KaEinsatz SUB OUTER APPLY dbo.fnKaGetAustrittDatumCode(SUB.FaLeistungID, SUB.KaEinsatzID) AUS
                                  WHERE SUB.AnweisungCode <> 1 --Alle AUSSER Zuweisung
                                    AND SUB.FaLeistungID = LEI.FaLeistungID
                                    AND (dbo.fnDateOf(AUS.AustrittDatum) >= @SucheDatumVon OR (AUS.AustrittDatum IS NULL AND dbo.fnDateOf(SUB.DatumBis) >= @SucheDatumVon))
                                    AND dbo.fnDateOf(SUB.DatumVon) <= @SucheDatumBis
                                      ORDER BY SUB.DatumBis DESC) EIN
                WHERE LEI.ModulID = 7 -- Modul KA
                  AND LEI.FaProzessCode = 703 -- Phase QJ;

                SELECT
                  BaPersonID$ = PRS.BaPersonID,
                  Fachbereich = dbo.fnLOVMLText('KaFachbereich', KZF.FachbereichID, 1),
                  Name = PRS.Name,
                  Vorname = PRS.Vorname,
                  Beschäftigungsgrad = TMP.BeschGrad,
                  Region = ADR.Value3,
                  Niveau = dbo.fnLOVMLText('KaQjNiveau', KZF.NiveauCode, 1),
                  Zuweiser = ISNULL(ORG.ItemName, INS.Name) + ISNULL(' (' + OKO.Name + ISNULL(', ' + OKO.Vorname ,'') + ')', '' ) + ISNULL(' (' +USR.NameVorname + ')',''),
                  Nationalität = NAT.Text,
                  [Ausl.-Status] = dbo.fnLOVMLText('Aufenthaltsstatus', PRS.AuslaenderStatusCode, 1),
                  Vorbildung = dbo.fnLOVText('KaAusbildungVorbildung',Convert(VARCHAR, KAA.KaAusbildungVorbildungCode))
                FROM #Temp TMP
                  INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = TMP.FaLeistungID
                  INNER JOIN dbo.KaZuteilFachbereich KZF WITH (READUNCOMMITTED) ON KZF.KaZuteilFachbereichID = TMP.KaZuteilFachbereichID
                  INNER JOIN dbo.BaPerson PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
                  OUTER APPLY (SELECT TOP 1 PLZ.Value3
                                 FROM dbo.BaAdresse ADRTEMP WITH (READUNCOMMITTED)
                                 LEFT JOIN dbo.XLOVCode PLZ  WITH (READUNCOMMITTED) ON ADRTEMP.PLZ = PLZ.ShortText
                                WHERE ADRTEMP.BaPersonID = PRS.BaPersonID AND AdresseCode = 1 /*Wohn-/Meldeadresse*/ ) ADR
                  LEFT JOIN dbo.BaLand NAT WITH (READUNCOMMITTED) ON NAT.BaLandID = PRS.NationalitaetCode
                  LEFT JOIN dbo.KaAusbildung KAA WITH (READUNCOMMITTED) ON KAA.FaLeistungID = (SELECT TOP 1 FaLeistungID /* neueste KA-Allgemein-Leistung ermitteln*/
                                                                                                 FROM Faleistung
                                                                                                WHERE BaPersonID = PRS.BaPersonID
                                                                                                  AND FaProzessCode = 700
                                                                                                ORDER BY DatumVon DESC)
                  LEFT JOIN dbo.BaInstitutionKontakt OKO WITH (READUNCOMMITTED) ON OKO.BaInstitutionKontaktID = TMP.ZuweiserID
                  LEFT JOIN dbo.BaInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = OKO.BaInstitutionID
                  LEFT JOIN dbo.XOrgUnit_User ORU WITH (READUNCOMMITTED) ON ORU.UserID = -TMP.ZuweiserID AND ORU.OrgUnitMemberCode IN (1,2)
                  LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = ORU.OrgUnitID
                  LEFT JOIN dbo.vwUserSimple USR WITH (READUNCOMMITTED) ON USR.UserID = ORU.UserID
                WHERE TMP.ZuweiserID IS NOT NULL
                ---  AND ((1 = {edtAuswZuweiser} AND INS.Name LIKE 'RAV%') OR (2 = {edtAuswZuweiser} AND (INS.Name IS NULL OR INS.Name NOT LIKE 'RAV%')))
                ORDER BY PRS.BaPersonID;

                IF OBJECT_ID('TempDB.dbo.#Temp') IS NOT NULL
                BEGIN
                  DROP TABLE #Temp;
                END;";

            return statement;
        }

        #endregion

        #endregion
    }
}