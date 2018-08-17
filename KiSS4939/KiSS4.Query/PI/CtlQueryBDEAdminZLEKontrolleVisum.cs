using System;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.PI
{
    public class CtlQueryBDEAdminZLEKontrolleVisum : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnGotoBDEErfassung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colFreigabe;
        private DevExpress.XtraGrid.Columns.GridColumn colMitarbeiterin;
        private DevExpress.XtraGrid.Columns.GridColumn colOrganisationseinheit;
        private DevExpress.XtraGrid.Columns.GridColumn colVisum;
        private KiSS4.Gui.KissLookUpEdit edtSucheAbteilung;
        private KiSS4.Gui.KissDateEdit edtSucheDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheDatumVon;
        private KiSS4.Gui.KissLookUpEdit edtSucheMitarbeiter;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblSucheAbteilung;
        private KiSS4.Gui.KissLabel lblSucheMitarbeiter;
        private KiSS4.Gui.KissLabel lblSucheMonat;

        #endregion

        #region Constructors

        public CtlQueryBDEAdminZLEKontrolleVisum()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBDEAdminZLEKontrolleVisum));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnGotoBDEErfassung = new KiSS4.Gui.KissButton();
            this.lblSucheMonat = new KiSS4.Gui.KissLabel();
            this.edtSucheDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheAbteilung = new KiSS4.Gui.KissLabel();
            this.edtSucheAbteilung = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheMitarbeiter = new KiSS4.Gui.KissLabel();
            this.edtSucheMitarbeiter = new KiSS4.Gui.KissLookUpEdit();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFreigabe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitarbeiterin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrganisationseinheit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVisum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).BeginInit();
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
            this.grdQuery1.Location = new System.Drawing.Point(3, 3);
            this.grdQuery1.MainView = this.gridView1;
            this.grdQuery1.Size = new System.Drawing.Size(766, 389);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.gridView1});
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(185, 398);
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
            this.ctlGotoFall.Size = new System.Drawing.Size(176, 24);
            this.ctlGotoFall.Visible = false;
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.btnGotoBDEErfassung);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnGotoBDEErfassung, 0);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.lblSucheMitarbeiter);
            this.tpgSuchen.Controls.Add(this.edtSucheAbteilung);
            this.tpgSuchen.Controls.Add(this.lblSucheAbteilung);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheDatumVon);
            this.tpgSuchen.Controls.Add(this.lblSucheMonat);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMonat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheAbteilung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAbteilung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMitarbeiter, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMitarbeiter, 0);
            //
            // btnGotoBDEErfassung
            //
            this.btnGotoBDEErfassung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGotoBDEErfassung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGotoBDEErfassung.Location = new System.Drawing.Point(604, 398);
            this.btnGotoBDEErfassung.Name = "btnGotoBDEErfassung";
            this.btnGotoBDEErfassung.Size = new System.Drawing.Size(165, 24);
            this.btnGotoBDEErfassung.TabIndex = 3;
            this.btnGotoBDEErfassung.Text = "Leistungserfassung";
            this.btnGotoBDEErfassung.UseCompatibleTextRendering = true;
            this.btnGotoBDEErfassung.UseVisualStyleBackColor = false;
            this.btnGotoBDEErfassung.Click += new System.EventHandler(this.btnGotoBDEErfassung_Click);
            //
            // lblSucheMonat
            //
            this.lblSucheMonat.Location = new System.Drawing.Point(31, 40);
            this.lblSucheMonat.Name = "lblSucheMonat";
            this.lblSucheMonat.Size = new System.Drawing.Size(100, 23);
            this.lblSucheMonat.TabIndex = 0;
            this.lblSucheMonat.Text = "Monat";
            this.lblSucheMonat.UseCompatibleTextRendering = true;
            //
            // edtSucheDatumVon
            //
            this.edtSucheDatumVon.EditValue = null;
            this.edtSucheDatumVon.Location = new System.Drawing.Point(159, 40);
            this.edtSucheDatumVon.Name = "edtSucheDatumVon";
            this.edtSucheDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.edtSucheDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumVon.Properties.DisplayFormat.FormatString = "y";
            this.edtSucheDatumVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSucheDatumVon.Properties.EditFormat.FormatString = "y";
            this.edtSucheDatumVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtSucheDatumVon.Properties.Mask.EditMask = "y";
            this.edtSucheDatumVon.Properties.ShowToday = false;
            this.edtSucheDatumVon.Size = new System.Drawing.Size(238, 24);
            this.edtSucheDatumVon.TabIndex = 1;
            //
            // edtSucheDatumBis
            //
            this.edtSucheDatumBis.EditValue = null;
            this.edtSucheDatumBis.Location = new System.Drawing.Point(403, 40);
            this.edtSucheDatumBis.Name = "edtSucheDatumBis";
            this.edtSucheDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheDatumBis.Properties.ShowToday = false;
            this.edtSucheDatumBis.Size = new System.Drawing.Size(119, 24);
            this.edtSucheDatumBis.TabIndex = 2;
            this.edtSucheDatumBis.Visible = false;
            //
            // lblSucheAbteilung
            //
            this.lblSucheAbteilung.Location = new System.Drawing.Point(31, 70);
            this.lblSucheAbteilung.Name = "lblSucheAbteilung";
            this.lblSucheAbteilung.Size = new System.Drawing.Size(122, 24);
            this.lblSucheAbteilung.TabIndex = 3;
            this.lblSucheAbteilung.Text = "Organisationseinheit";
            this.lblSucheAbteilung.UseCompatibleTextRendering = true;
            //
            // edtSucheAbteilung
            //
            this.edtSucheAbteilung.Location = new System.Drawing.Point(159, 70);
            this.edtSucheAbteilung.Name = "edtSucheAbteilung";
            this.edtSucheAbteilung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAbteilung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAbteilung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAbteilung.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAbteilung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheAbteilung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAbteilung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheAbteilung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheAbteilung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtSucheAbteilung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtSucheAbteilung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAbteilung.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheAbteilung.Properties.DisplayMember = "Text";
            this.edtSucheAbteilung.Properties.NullText = "";
            this.edtSucheAbteilung.Properties.ShowFooter = false;
            this.edtSucheAbteilung.Properties.ShowHeader = false;
            this.edtSucheAbteilung.Properties.ValueMember = "Code";
            this.edtSucheAbteilung.Size = new System.Drawing.Size(238, 24);
            this.edtSucheAbteilung.TabIndex = 4;
            //
            // lblSucheMitarbeiter
            //
            this.lblSucheMitarbeiter.Location = new System.Drawing.Point(31, 100);
            this.lblSucheMitarbeiter.Name = "lblSucheMitarbeiter";
            this.lblSucheMitarbeiter.Size = new System.Drawing.Size(100, 23);
            this.lblSucheMitarbeiter.TabIndex = 5;
            this.lblSucheMitarbeiter.Text = "Mitarbeiter/in";
            this.lblSucheMitarbeiter.UseCompatibleTextRendering = true;
            //
            // edtSucheMitarbeiter
            //
            this.edtSucheMitarbeiter.Location = new System.Drawing.Point(159, 100);
            this.edtSucheMitarbeiter.Name = "edtSucheMitarbeiter";
            this.edtSucheMitarbeiter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMitarbeiter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMitarbeiter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMitarbeiter.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheMitarbeiter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheMitarbeiter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheMitarbeiter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMitarbeiter.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
                        new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 5, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtSucheMitarbeiter.Properties.DisplayMember = "Text";
            this.edtSucheMitarbeiter.Properties.NullText = "";
            this.edtSucheMitarbeiter.Properties.ShowFooter = false;
            this.edtSucheMitarbeiter.Properties.ShowHeader = false;
            this.edtSucheMitarbeiter.Properties.ValueMember = "Code";
            this.edtSucheMitarbeiter.Size = new System.Drawing.Size(238, 24);
            this.edtSucheMitarbeiter.TabIndex = 6;
            //
            // colDatum
            //
            this.colDatum.Name = "colDatum";
            //
            // colFreigabe
            //
            this.colFreigabe.Name = "colFreigabe";
            //
            // colMitarbeiterin
            //
            this.colMitarbeiterin.Name = "colMitarbeiterin";
            //
            // colOrganisationseinheit
            //
            this.colOrganisationseinheit.Name = "colOrganisationseinheit";
            //
            // colVisum
            //
            this.colVisum.Name = "colVisum";
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
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
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
            // CtlQueryBDEAdminZLEKontrolleVisum
            //
            this.Name = "CtlQueryBDEAdminZLEKontrolleVisum";
            this.Load += new System.EventHandler(this.CtlQueryBDEAdminZLEKontrolleVisum_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAbteilung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMitarbeiter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // setup default values
            edtSucheDatumVon.EditValue = this.GetFirstDayOfMonth(DateTime.Today, true);
            edtSucheDatumBis.EditValue = this.GetLastDayOfMonth(DateTime.Today, true);

            // set focus
            edtSucheDatumVon.Focus();
        }

        protected override void RunSearch()
        {
            // move focus to apply datetime
            edtSucheMitarbeiter.Focus();

            // validate
            if (DBUtil.IsEmpty(edtSucheDatumVon.EditValue))
            {
                // no month entered, cannot continue
                KissMsg.ShowInfo("CtlQueryBDEAdminZLEKontrolleVisum", "MissingDateFromTo", "Das Feld 'Monat' verlangt eine Eingabe.");

                // set focus
                edtSucheDatumVon.Focus();

                // do not continue
                throw new KissCancelException("Missing value for date, cannot continue with query.");
            }
            else
            {
                // calculate dates for proper searching of month
                edtSucheDatumVon.EditValue = this.GetFirstDayOfMonth(Convert.ToDateTime(edtSucheDatumVon.EditValue), false);
                edtSucheDatumBis.EditValue = this.GetLastDayOfMonth(Convert.ToDateTime(edtSucheDatumVon.EditValue), false);
            }

            // replace search parameters
            object[] parameters = new object[] { Session.User.UserID, edtSucheDatumVon.EditValue, edtSucheDatumBis.EditValue };
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void CtlQueryBDEAdminZLEKontrolleVisum_Load(object sender, System.EventArgs e)
        {
            // fill dropdowns data
            SqlQuery qryOrgUnits = DBUtil.OpenSQL(@"SELECT * FROM dbo.fnBDEGetOEOrgUnitList({0}, 1, 1)", Session.User.UserID);
            SqlQuery qryUsers = DBUtil.OpenSQL(@"SELECT * FROM dbo.fnBDEGetOEUserList({0}, 1)", Session.User.UserID);

            // setup edtSucheAbteilung
            this.edtSucheAbteilung.Properties.DropDownRows = Math.Min(qryOrgUnits.Count, 7);
            this.edtSucheAbteilung.Properties.DataSource = qryOrgUnits;

            // setup edtAngezeigterMitarbeiter
            this.edtSucheMitarbeiter.Properties.DropDownRows = Math.Min(qryUsers.Count, 7);
            this.edtSucheMitarbeiter.Properties.DataSource = qryUsers;
        }

        private DateTime GetFirstDayOfMonth(DateTime date, bool takeLastMonth)
        {
            // validate
            if (date == null || takeLastMonth)
            {
                // get current date and subtract one month
                date = DateTime.Today.AddMonths(-1);
            }

            // return first day of month
            return new DateTime(date.Year, date.Month, 1);
        }


        private DateTime GetLastDayOfMonth(DateTime date, bool takeLastMonth)
        {
            // validate
            if (date == null || takeLastMonth)
            {
                // get current date and subtract one month
                date = DateTime.Today.AddMonths(-1);
            }

            // get first day of month
            date = new DateTime(date.Year, date.Month, 1);

            // add one month
            date = date.AddMonths(1);

            // return first day of next month - 1 day = last day of current month
            return date.AddDays(-1);
        }

        private void btnGotoBDEErfassung_Click(object sender, System.EventArgs e)
        {
            // validate
            if (qryQuery.Count < 1 || DBUtil.IsEmpty(qryQuery["UserID$"]))
            {
                // invalid data, do nothing
                return;
            }

            // jump to form with given user
            FormController.OpenForm("FrmBDEZeiterfassung", "Action", "SelectUser",
                        "UserID", Convert.ToInt32(qryQuery["UserID$"]));
        }

        #endregion
    }
}