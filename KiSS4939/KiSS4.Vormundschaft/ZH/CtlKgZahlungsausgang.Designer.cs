namespace KiSS4.Vormundschaft.ZH
{
    partial class CtlKgZahlungsausgang
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKgZahlungsausgang));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.edtDokumentHidden = new KiSS4.Dokument.XDokument();
            this.edtAnzahl = new KiSS4.Gui.KissCalcEdit();
            this.edtTotal = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.kissLabel19 = new KiSS4.Gui.KissLabel();
            this.kissLabel20 = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.qryDocument = new KiSS4.DB.SqlQuery(this.components);
            this.grdAusgleich = new KiSS4.Gui.KissGrid();
            this.qryKgBuchung = new KiSS4.DB.SqlQuery(this.components);
            this.qryZahlungsausgang = new KiSS4.DB.SqlQuery(this.components);
            this.grvAusgleich = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchungsDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSollKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumente = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgleich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.btnZugeordneteDoks = new KiSS4.Gui.KissButton();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.grdZahlungseingang = new KiSS4.Gui.KissGrid();
            this.grvZahlungseingang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMitteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgeglichen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGVC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.edtBaPersonIDX = new KiSS4.Gui.KissButtonEdit();
            this.edtBetragVonX = new KiSS4.Gui.KissCalcEdit();
            this.edtBetragBisX = new KiSS4.Gui.KissCalcEdit();
            this.edtMitteilungX = new KiSS4.Gui.KissTextEdit();
            this.edtNurAusgeglichenX = new KiSS4.Gui.KissCheckEdit();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.kissLabel11 = new KiSS4.Gui.KissLabel();
            this.kissLabel12 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.tabPageEx1 = new SharpLibrary.WinControls.TabPageEx();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.edtBuchungstext = new KiSS4.Gui.KissComboBox();
            this.btnSave = new KiSS4.Gui.KissButton();
            this.lblBuchungsDatum = new KiSS4.Gui.KissLabel();
            this.edtBuchungsdatum = new KiSS4.Gui.KissDateEdit();
            this.lblBuchungstext2 = new KiSS4.Gui.KissLabel();
            this.lblKonto2 = new KiSS4.Gui.KissLabel();
            this.edtKonto = new KiSS4.Gui.KissButtonEdit();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.btnEintragAusgleichen = new KiSS4.Gui.KissButton();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.kissTextEdit5 = new KiSS4.Gui.KissTextEdit();
            this.grbAusgaben = new KiSS4.Gui.KissGroupBox();
            this.grdBetragsgleicheAusgaben = new KiSS4.Gui.KissGrid();
            this.qryKontoVorschau = new KiSS4.DB.SqlQuery(this.components);
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchungsdatum2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoll = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldo2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPosStatus2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox3 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtGVC = new KiSS4.Gui.KissTextEdit();
            this.rbtnLebend = new KiSS4.Gui.KissRadioGroup(this.components);
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissMemoEdit1 = new KiSS4.Gui.KissMemoEdit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentHidden.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAusgleich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungsausgang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAusgleich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungseingang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungseingang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAusgeglichenX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungsDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonto.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).BeginInit();
            this.grbAusgaben.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdBetragsgleicheAusgaben)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoVorschau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGVC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnLebend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnLebend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(804, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 33);
            this.tabControlSearch.Size = new System.Drawing.Size(828, 639);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.kissLabel6);
            this.tpgListe.Controls.Add(this.kissMemoEdit1);
            this.tpgListe.Controls.Add(this.grbAusgaben);
            this.tpgListe.Controls.Add(this.ctlGotoFall);
            this.tpgListe.Controls.Add(this.kissLabel8);
            this.tpgListe.Controls.Add(this.kissTextEdit5);
            this.tpgListe.Controls.Add(this.btnEintragAusgleichen);
            this.tpgListe.Controls.Add(this.groupBox1);
            this.tpgListe.Controls.Add(this.grdZahlungseingang);
            this.tpgListe.Size = new System.Drawing.Size(816, 601);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.rbtnLebend);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtGVC);
            this.tpgSuchen.Controls.Add(this.kissLabel9);
            this.tpgSuchen.Controls.Add(this.kissLabel15);
            this.tpgSuchen.Controls.Add(this.kissLabel14);
            this.tpgSuchen.Controls.Add(this.kissLabel12);
            this.tpgSuchen.Controls.Add(this.kissLabel11);
            this.tpgSuchen.Controls.Add(this.kissLabel10);
            this.tpgSuchen.Controls.Add(this.edtNurAusgeglichenX);
            this.tpgSuchen.Controls.Add(this.edtMitteilungX);
            this.tpgSuchen.Controls.Add(this.edtBetragBisX);
            this.tpgSuchen.Controls.Add(this.edtBetragVonX);
            this.tpgSuchen.Controls.Add(this.edtBaPersonIDX);
            this.tpgSuchen.Controls.Add(this.edtDatumBisX);
            this.tpgSuchen.Controls.Add(this.edtDatumVonX);
            this.tpgSuchen.Size = new System.Drawing.Size(816, 601);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaPersonIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetragVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetragBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtMitteilungX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurAusgeglichenX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel10, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel11, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel12, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel14, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel15, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel9, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGVC, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.rbtnLebend, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.edtDokumentHidden);
            this.panel1.Controls.Add(this.edtAnzahl);
            this.panel1.Controls.Add(this.edtTotal);
            this.panel1.Controls.Add(this.kissLabel16);
            this.panel1.Controls.Add(this.kissLabel19);
            this.panel1.Controls.Add(this.kissLabel20);
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 33);
            this.panel1.TabIndex = 1;
            // 
            // edtDokumentHidden
            // 
            this.edtDokumentHidden.CanCreateDocument = false;
            this.edtDokumentHidden.CanDeleteDocument = false;
            this.edtDokumentHidden.CanImportDocument = false;
            this.edtDokumentHidden.Context = null;
            this.edtDokumentHidden.DataMember = null;
            this.edtDokumentHidden.EditValue = "";
            this.edtDokumentHidden.Location = new System.Drawing.Point(215, 5);
            this.edtDokumentHidden.Name = "edtDokumentHidden";
            this.edtDokumentHidden.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokumentHidden.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumentHidden.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumentHidden.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumentHidden.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumentHidden.Properties.Appearance.Options.UseFont = true;
            this.edtDokumentHidden.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDokumentHidden.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokumentHidden.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument importieren")});
            this.edtDokumentHidden.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumentHidden.Properties.ReadOnly = true;
            this.edtDokumentHidden.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokumentHidden.Size = new System.Drawing.Size(156, 24);
            this.edtDokumentHidden.TabIndex = 319;
            this.edtDokumentHidden.Visible = false;
            // 
            // edtAnzahl
            // 
            this.edtAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAnzahl.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahl.Location = new System.Drawing.Point(538, 3);
            this.edtAnzahl.Name = "edtAnzahl";
            this.edtAnzahl.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahl.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnzahl.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahl.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahl.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahl.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahl.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahl.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahl.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahl.Properties.DisplayFormat.FormatString = "n0";
            this.edtAnzahl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahl.Properties.ReadOnly = true;
            this.edtAnzahl.Size = new System.Drawing.Size(73, 24);
            this.edtAnzahl.TabIndex = 298;
            // 
            // edtTotal
            // 
            this.edtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotal.Location = new System.Drawing.Point(690, 3);
            this.edtTotal.Name = "edtTotal";
            this.edtTotal.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotal.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTotal.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotal.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotal.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotal.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotal.Properties.Appearance.Options.UseFont = true;
            this.edtTotal.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotal.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotal.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotal.Properties.ReadOnly = true;
            this.edtTotal.Size = new System.Drawing.Size(100, 24);
            this.edtTotal.TabIndex = 299;
            // 
            // kissLabel16
            // 
            this.kissLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel16.Location = new System.Drawing.Point(795, 3);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(28, 24);
            this.kissLabel16.TabIndex = 299;
            this.kissLabel16.Text = "CHF";
            this.kissLabel16.UseCompatibleTextRendering = true;
            // 
            // kissLabel19
            // 
            this.kissLabel19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel19.Location = new System.Drawing.Point(617, 3);
            this.kissLabel19.Name = "kissLabel19";
            this.kissLabel19.Size = new System.Drawing.Size(68, 24);
            this.kissLabel19.TabIndex = 298;
            this.kissLabel19.Text = "Betragstotal";
            this.kissLabel19.UseCompatibleTextRendering = true;
            // 
            // kissLabel20
            // 
            this.kissLabel20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel20.Location = new System.Drawing.Point(457, 3);
            this.kissLabel20.Name = "kissLabel20";
            this.kissLabel20.Size = new System.Drawing.Size(75, 24);
            this.kissLabel20.TabIndex = 297;
            this.kissLabel20.Text = "Anzahl Belege";
            this.kissLabel20.UseCompatibleTextRendering = true;
            // 
            // picTitel
            // 
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(289, 22);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Zahlungsausgang";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // qryDocument
            // 
            this.qryDocument.FillTimeOut = 60;
            this.qryDocument.SelectStatement = resources.GetString("qryDocument.SelectStatement");
            // 
            // grdAusgleich
            // 
            this.grdAusgleich.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAusgleich.DataSource = this.qryKgBuchung;
            // 
            // 
            // 
            this.grdAusgleich.EmbeddedNavigator.Name = "";
            this.grdAusgleich.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdAusgleich.Location = new System.Drawing.Point(6, 20);
            this.grdAusgleich.MainView = this.grvAusgleich;
            this.grdAusgleich.Name = "grdAusgleich";
            this.grdAusgleich.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1,
            this.repositoryItemTextEdit1});
            this.grdAusgleich.Size = new System.Drawing.Size(495, 118);
            this.grdAusgleich.TabIndex = 9;
            this.grdAusgleich.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAusgleich});
            // 
            // qryKgBuchung
            // 
            this.qryKgBuchung.CanDelete = true;
            this.qryKgBuchung.CanInsert = true;
            this.qryKgBuchung.CanUpdate = true;
            this.qryKgBuchung.HostControl = this;
            this.qryKgBuchung.MasterQuery = this.qryZahlungsausgang;
            this.qryKgBuchung.SelectStatement = resources.GetString("qryKgBuchung.SelectStatement");
            this.qryKgBuchung.TableName = "KgBuchung";
            this.qryKgBuchung.AfterInsert += new System.EventHandler(this.qryKgBuchung_AfterInsert);
            this.qryKgBuchung.BeforePost += new System.EventHandler(this.qryKgBuchung_BeforePost);
            this.qryKgBuchung.PositionChanged += new System.EventHandler(this.qryKgBuchung_PositionChanged);
            this.qryKgBuchung.PostCompleted += new System.EventHandler(this.qryKgBuchung_PostCompleted);
            // 
            // qryZahlungsausgang
            // 
            this.qryZahlungsausgang.CanUpdate = true;
            this.qryZahlungsausgang.HostControl = this;
            this.qryZahlungsausgang.SelectStatement = resources.GetString("qryZahlungsausgang.SelectStatement");
            this.qryZahlungsausgang.TableName = "KgZahlungseingang";
            this.qryZahlungsausgang.AfterFill += new System.EventHandler(this.qryZahlungsausgang_AfterFill);
            this.qryZahlungsausgang.AfterPost += new System.EventHandler(this.qryZahlungseingang_AfterPost);
            this.qryZahlungsausgang.BeforePost += new System.EventHandler(this.qryZahlungseingang_BeforePost);
            this.qryZahlungsausgang.PositionChanged += new System.EventHandler(this.qryZahlungsausgang_PositionChanged);
            // 
            // grvAusgleich
            // 
            this.grvAusgleich.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvAusgleich.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.Empty.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.Empty.Options.UseFont = true;
            this.grvAusgleich.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvAusgleich.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.EvenRow.Options.UseFont = true;
            this.grvAusgleich.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAusgleich.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvAusgleich.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAusgleich.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAusgleich.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvAusgleich.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvAusgleich.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.FocusedRow.Options.UseFont = true;
            this.grvAusgleich.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvAusgleich.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAusgleich.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvAusgleich.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAusgleich.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAusgleich.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.GroupRow.Options.UseFont = true;
            this.grvAusgleich.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvAusgleich.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvAusgleich.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvAusgleich.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvAusgleich.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvAusgleich.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvAusgleich.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvAusgleich.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAusgleich.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAusgleich.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAusgleich.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvAusgleich.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.OddRow.Options.UseFont = true;
            this.grvAusgleich.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvAusgleich.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.Row.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.Row.Options.UseFont = true;
            this.grvAusgleich.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAusgleich.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvAusgleich.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAusgleich.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvAusgleich.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvAusgleich.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAusgleich.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAusgleich.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchungsDatum,
            this.colSollKonto,
            this.colBuchungstext,
            this.colBetrag,
            this.colDokumente,
            this.colAusgleich});
            this.grvAusgleich.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvAusgleich.GridControl = this.grdAusgleich;
            this.grvAusgleich.Name = "grvAusgleich";
            this.grvAusgleich.OptionsBehavior.Editable = false;
            this.grvAusgleich.OptionsCustomization.AllowFilter = false;
            this.grvAusgleich.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAusgleich.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAusgleich.OptionsNavigation.UseTabKey = false;
            this.grvAusgleich.OptionsView.ColumnAutoWidth = false;
            this.grvAusgleich.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAusgleich.OptionsView.ShowGroupPanel = false;
            this.grvAusgleich.OptionsView.ShowIndicator = false;
            this.grvAusgleich.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grvAusgleich_MouseUp);
            // 
            // colBuchungsDatum
            // 
            this.colBuchungsDatum.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungsDatum.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungsDatum.Caption = "Buchungsdatum";
            this.colBuchungsDatum.FieldName = "BuchungsDatum";
            this.colBuchungsDatum.Name = "colBuchungsDatum";
            this.colBuchungsDatum.OptionsColumn.AllowEdit = false;
            this.colBuchungsDatum.Visible = true;
            this.colBuchungsDatum.VisibleIndex = 0;
            this.colBuchungsDatum.Width = 102;
            // 
            // colSollKonto
            // 
            this.colSollKonto.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colSollKonto.AppearanceCell.Options.UseBackColor = true;
            this.colSollKonto.Caption = "Soll-Konto";
            this.colSollKonto.FieldName = "SollKtoNr";
            this.colSollKonto.Name = "colSollKonto";
            this.colSollKonto.OptionsColumn.AllowEdit = false;
            this.colSollKonto.Visible = true;
            this.colSollKonto.VisibleIndex = 1;
            this.colSollKonto.Width = 68;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungstext.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Text";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.AllowEdit = false;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 2;
            this.colBuchungstext.Width = 245;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "N2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.SummaryItem.DisplayFormat = "n2";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.ToolTip = "Totalbetrag";
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 3;
            this.colBetrag.Width = 95;
            // 
            // colDokumente
            // 
            this.colDokumente.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDokumente.AppearanceCell.Options.UseBackColor = true;
            this.colDokumente.Caption = "Dok.";
            this.colDokumente.DisplayFormat.FormatString = "#";
            this.colDokumente.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDokumente.FieldName = "AnzahlDokumente";
            this.colDokumente.Name = "colDokumente";
            this.colDokumente.OptionsColumn.AllowEdit = false;
            this.colDokumente.Visible = true;
            this.colDokumente.VisibleIndex = 4;
            this.colDokumente.Width = 36;
            // 
            // colAusgleich
            // 
            this.colAusgleich.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAusgleich.AppearanceCell.Options.UseBackColor = true;
            this.colAusgleich.ColumnEdit = this.repositoryItemButtonEdit1;
            this.colAusgleich.Name = "colAusgleich";
            this.colAusgleich.Width = 23;
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Left, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.repositoryItemButtonEdit1.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            this.repositoryItemButtonEdit1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.DisplayFormat.FormatString = "N2";
            this.repositoryItemTextEdit1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.EditFormat.FormatString = "N2";
            this.repositoryItemTextEdit1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // btnZugeordneteDoks
            // 
            this.btnZugeordneteDoks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZugeordneteDoks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZugeordneteDoks.Location = new System.Drawing.Point(392, 144);
            this.btnZugeordneteDoks.Name = "btnZugeordneteDoks";
            this.btnZugeordneteDoks.Size = new System.Drawing.Size(107, 24);
            this.btnZugeordneteDoks.TabIndex = 6;
            this.btnZugeordneteDoks.Text = "Dokumente ...";
            this.btnZugeordneteDoks.UseCompatibleTextRendering = true;
            this.btnZugeordneteDoks.UseVisualStyleBackColor = false;
            this.btnZugeordneteDoks.Click += new System.EventHandler(this.btnZugeordneteDoks_Click);
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryKgBuchung;
            this.edtBetrag.Location = new System.Drawing.Point(100, 233);
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
            this.edtBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 4;
            this.edtBetrag.EditValueChanged += new System.EventHandler(this.edtBetrag_EditValueChanged);
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(8, 233);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(44, 24);
            this.lblBetrag.TabIndex = 1;
            this.lblBetrag.Text = "Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(206, 233);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(44, 24);
            this.kissLabel7.TabIndex = 284;
            this.kissLabel7.Text = "CHF";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // grdZahlungseingang
            // 
            this.grdZahlungseingang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdZahlungseingang.DataSource = this.qryZahlungsausgang;
            // 
            // 
            // 
            this.grdZahlungseingang.EmbeddedNavigator.Name = "";
            this.grdZahlungseingang.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdZahlungseingang.Location = new System.Drawing.Point(0, 0);
            this.grdZahlungseingang.MainView = this.grvZahlungseingang;
            this.grdZahlungseingang.Name = "grdZahlungseingang";
            this.grdZahlungseingang.Size = new System.Drawing.Size(816, 142);
            this.grdZahlungseingang.TabIndex = 0;
            this.grdZahlungseingang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZahlungseingang});
            // 
            // grvZahlungseingang
            // 
            this.grvZahlungseingang.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZahlungseingang.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.Empty.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.Empty.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.EvenRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungseingang.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZahlungseingang.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahlungseingang.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZahlungseingang.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungseingang.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahlungseingang.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungseingang.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungseingang.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.GroupRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZahlungseingang.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZahlungseingang.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahlungseingang.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZahlungseingang.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungseingang.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.OddRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZahlungseingang.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.Row.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.Row.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahlungseingang.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZahlungseingang.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZahlungseingang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum2,
            this.colMandant,
            this.colKonto,
            this.colMitteilung,
            this.colBetrag2,
            this.colAusgeglichen,
            this.colGVC});
            this.grvZahlungseingang.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZahlungseingang.GridControl = this.grdZahlungseingang;
            this.grvZahlungseingang.Name = "grvZahlungseingang";
            this.grvZahlungseingang.OptionsBehavior.Editable = false;
            this.grvZahlungseingang.OptionsCustomization.AllowFilter = false;
            this.grvZahlungseingang.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZahlungseingang.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZahlungseingang.OptionsNavigation.UseTabKey = false;
            this.grvZahlungseingang.OptionsView.ColumnAutoWidth = false;
            this.grvZahlungseingang.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZahlungseingang.OptionsView.ShowGroupPanel = false;
            this.grvZahlungseingang.OptionsView.ShowIndicator = false;
            // 
            // colDatum2
            // 
            this.colDatum2.Caption = "Datum";
            this.colDatum2.FieldName = "Datum";
            this.colDatum2.Name = "colDatum2";
            this.colDatum2.Visible = true;
            this.colDatum2.VisibleIndex = 0;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Person m. zivilr. Massn.";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 2;
            this.colMandant.Width = 176;
            // 
            // colKonto
            // 
            this.colKonto.Caption = "Eingangskonto";
            this.colKonto.FieldName = "PscdKontoKlient";
            this.colKonto.Name = "colKonto";
            this.colKonto.Visible = true;
            this.colKonto.VisibleIndex = 3;
            this.colKonto.Width = 96;
            // 
            // colMitteilung
            // 
            this.colMitteilung.Caption = "Mitteilung";
            this.colMitteilung.FieldName = "Mitteilung";
            this.colMitteilung.Name = "colMitteilung";
            this.colMitteilung.Visible = true;
            this.colMitteilung.VisibleIndex = 6;
            this.colMitteilung.Width = 458;
            // 
            // colBetrag2
            // 
            this.colBetrag2.Caption = "Betrag";
            this.colBetrag2.DisplayFormat.FormatString = "N2";
            this.colBetrag2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag2.FieldName = "Betrag";
            this.colBetrag2.Name = "colBetrag2";
            this.colBetrag2.Visible = true;
            this.colBetrag2.VisibleIndex = 4;
            this.colBetrag2.Width = 82;
            // 
            // colAusgeglichen
            // 
            this.colAusgeglichen.Caption = "ausg.";
            this.colAusgeglichen.FieldName = "Ausgeglichen";
            this.colAusgeglichen.Name = "colAusgeglichen";
            this.colAusgeglichen.Visible = true;
            this.colAusgeglichen.VisibleIndex = 1;
            this.colAusgeglichen.Width = 41;
            // 
            // colGVC
            // 
            this.colGVC.Caption = "GVC";
            this.colGVC.FieldName = "GVC_Code";
            this.colGVC.Name = "colGVC";
            this.colGVC.Visible = true;
            this.colGVC.VisibleIndex = 5;
            this.colGVC.Width = 163;
            // 
            // edtDatumVonX
            // 
            this.edtDatumVonX.EditValue = null;
            this.edtDatumVonX.Location = new System.Drawing.Point(147, 42);
            this.edtDatumVonX.Name = "edtDatumVonX";
            this.edtDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonX.Properties.ShowToday = false;
            this.edtDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVonX.TabIndex = 0;
            // 
            // edtDatumBisX
            // 
            this.edtDatumBisX.EditValue = null;
            this.edtDatumBisX.Location = new System.Drawing.Point(280, 42);
            this.edtDatumBisX.Name = "edtDatumBisX";
            this.edtDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisX.Properties.ShowToday = false;
            this.edtDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBisX.TabIndex = 1;
            // 
            // edtBaPersonIDX
            // 
            this.edtBaPersonIDX.Location = new System.Drawing.Point(147, 72);
            this.edtBaPersonIDX.Name = "edtBaPersonIDX";
            this.edtBaPersonIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonIDX.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtBaPersonIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtBaPersonIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonIDX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaPersonIDX.Size = new System.Drawing.Size(318, 24);
            this.edtBaPersonIDX.TabIndex = 2;
            this.edtBaPersonIDX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonIDX_UserModifiedFld);
            // 
            // edtBetragVonX
            // 
            this.edtBetragVonX.Location = new System.Drawing.Point(147, 102);
            this.edtBetragVonX.Name = "edtBetragVonX";
            this.edtBetragVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragVonX.Properties.Appearance.Options.UseFont = true;
            this.edtBetragVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragVonX.Size = new System.Drawing.Size(100, 24);
            this.edtBetragVonX.TabIndex = 4;
            // 
            // edtBetragBisX
            // 
            this.edtBetragBisX.Location = new System.Drawing.Point(280, 102);
            this.edtBetragBisX.Name = "edtBetragBisX";
            this.edtBetragBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragBisX.Properties.Appearance.Options.UseFont = true;
            this.edtBetragBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragBisX.Size = new System.Drawing.Size(100, 24);
            this.edtBetragBisX.TabIndex = 5;
            // 
            // edtMitteilungX
            // 
            this.edtMitteilungX.Location = new System.Drawing.Point(147, 132);
            this.edtMitteilungX.Name = "edtMitteilungX";
            this.edtMitteilungX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilungX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilungX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilungX.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilungX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilungX.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilungX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilungX.Size = new System.Drawing.Size(318, 24);
            this.edtMitteilungX.TabIndex = 6;
            // 
            // edtNurAusgeglichenX
            // 
            this.edtNurAusgeglichenX.EditValue = true;
            this.edtNurAusgeglichenX.Location = new System.Drawing.Point(147, 196);
            this.edtNurAusgeglichenX.Name = "edtNurAusgeglichenX";
            this.edtNurAusgeglichenX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurAusgeglichenX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurAusgeglichenX.Properties.Caption = "nur unausgeglichene Zahlungen";
            this.edtNurAusgeglichenX.Size = new System.Drawing.Size(218, 19);
            this.edtNurAusgeglichenX.TabIndex = 7;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(3, 42);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(65, 24);
            this.kissLabel10.TabIndex = 296;
            this.kissLabel10.Text = "Datum von";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // kissLabel11
            // 
            this.kissLabel11.Location = new System.Drawing.Point(3, 102);
            this.kissLabel11.Name = "kissLabel11";
            this.kissLabel11.Size = new System.Drawing.Size(65, 24);
            this.kissLabel11.TabIndex = 297;
            this.kissLabel11.Text = "Betrag von";
            this.kissLabel11.UseCompatibleTextRendering = true;
            // 
            // kissLabel12
            // 
            this.kissLabel12.Location = new System.Drawing.Point(3, 72);
            this.kissLabel12.Name = "kissLabel12";
            this.kissLabel12.Size = new System.Drawing.Size(138, 24);
            this.kissLabel12.TabIndex = 298;
            this.kissLabel12.Text = "Person m. zivilr. Massn.";
            this.kissLabel12.UseCompatibleTextRendering = true;
            // 
            // kissLabel14
            // 
            this.kissLabel14.Location = new System.Drawing.Point(253, 42);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(21, 24);
            this.kissLabel14.TabIndex = 308;
            this.kissLabel14.Text = "bis";
            this.kissLabel14.UseCompatibleTextRendering = true;
            // 
            // kissLabel15
            // 
            this.kissLabel15.Location = new System.Drawing.Point(253, 102);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(21, 24);
            this.kissLabel15.TabIndex = 310;
            this.kissLabel15.Text = "bis";
            this.kissLabel15.UseCompatibleTextRendering = true;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Location = new System.Drawing.Point(3, 132);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(65, 24);
            this.kissLabel9.TabIndex = 315;
            this.kissLabel9.Text = "Mitteilung";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // tabPageEx1
            // 
            this.tabPageEx1.Location = new System.Drawing.Point(0, 0);
            this.tabPageEx1.Name = "tabPageEx1";
            this.tabPageEx1.Size = new System.Drawing.Size(150, 150);
            this.tabPageEx1.TabIndex = 0;
            this.tabPageEx1.Title = "tabPageEx1";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.edtBuchungstext);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.lblBuchungsDatum);
            this.groupBox1.Controls.Add(this.edtBuchungsdatum);
            this.groupBox1.Controls.Add(this.lblBuchungstext2);
            this.groupBox1.Controls.Add(this.lblKonto2);
            this.groupBox1.Controls.Add(this.edtKonto);
            this.groupBox1.Controls.Add(this.grdAusgleich);
            this.groupBox1.Controls.Add(this.btnZugeordneteDoks);
            this.groupBox1.Controls.Add(this.edtBetrag);
            this.groupBox1.Controls.Add(this.lblBetrag);
            this.groupBox1.Controls.Add(this.kissLabel7);
            this.groupBox1.Location = new System.Drawing.Point(3, 185);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(507, 275);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buchungen";
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.DataMember = "Text";
            this.edtBuchungstext.DataSource = this.qryKgBuchung;
            this.edtBuchungstext.Location = new System.Drawing.Point(100, 203);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBuchungstext.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBuchungstext.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(317, 24);
            this.edtBuchungstext.TabIndex = 3;
            this.edtBuchungstext.EditValueChanged += new System.EventHandler(this.edtBuchungstext_EditValueChanged);
            this.edtBuchungstext.TextChanged += new System.EventHandler(this.edtBuchungstext_TextChanged);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(417, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(82, 24);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseCompatibleTextRendering = true;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblBuchungsDatum
            // 
            this.lblBuchungsDatum.Location = new System.Drawing.Point(8, 144);
            this.lblBuchungsDatum.Name = "lblBuchungsDatum";
            this.lblBuchungsDatum.Size = new System.Drawing.Size(55, 24);
            this.lblBuchungsDatum.TabIndex = 309;
            this.lblBuchungsDatum.Text = "Buchung";
            this.lblBuchungsDatum.UseCompatibleTextRendering = true;
            // 
            // edtBuchungsdatum
            // 
            this.edtBuchungsdatum.DataMember = "BuchungsDatum";
            this.edtBuchungsdatum.DataSource = this.qryKgBuchung;
            this.edtBuchungsdatum.EditValue = null;
            this.edtBuchungsdatum.Location = new System.Drawing.Point(100, 144);
            this.edtBuchungsdatum.Name = "edtBuchungsdatum";
            this.edtBuchungsdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBuchungsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtBuchungsdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBuchungsdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtBuchungsdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBuchungsdatum.Properties.ShowToday = false;
            this.edtBuchungsdatum.Size = new System.Drawing.Size(100, 24);
            this.edtBuchungsdatum.TabIndex = 1;
            this.edtBuchungsdatum.EditValueChanged += new System.EventHandler(this.edtBuchungsdatum_EditValueChanged);
            // 
            // lblBuchungstext2
            // 
            this.lblBuchungstext2.Location = new System.Drawing.Point(8, 203);
            this.lblBuchungstext2.Name = "lblBuchungstext2";
            this.lblBuchungstext2.Size = new System.Drawing.Size(86, 24);
            this.lblBuchungstext2.TabIndex = 307;
            this.lblBuchungstext2.Text = "Buchungstext";
            this.lblBuchungstext2.UseCompatibleTextRendering = true;
            // 
            // lblKonto2
            // 
            this.lblKonto2.Location = new System.Drawing.Point(8, 173);
            this.lblKonto2.Name = "lblKonto2";
            this.lblKonto2.Size = new System.Drawing.Size(86, 24);
            this.lblKonto2.TabIndex = 305;
            this.lblKonto2.Text = "Konto";
            this.lblKonto2.UseCompatibleTextRendering = true;
            // 
            // edtKonto
            // 
            this.edtKonto.DataMember = "Konto";
            this.edtKonto.DataSource = this.qryKgBuchung;
            this.edtKonto.Location = new System.Drawing.Point(100, 173);
            this.edtKonto.Name = "edtKonto";
            this.edtKonto.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKonto.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKonto.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKonto.Properties.Appearance.Options.UseBackColor = true;
            this.edtKonto.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKonto.Properties.Appearance.Options.UseFont = true;
            this.edtKonto.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtKonto.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtKonto.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKonto.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKonto.Size = new System.Drawing.Size(317, 24);
            this.edtKonto.TabIndex = 2;
            this.edtKonto.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKonto_UserModifiedFld);
            this.edtKonto.EditValueChanged += new System.EventHandler(this.edtKonto_EditValueChanged);
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlGotoFall.DataMember = "FallBaPersonID";
            this.ctlGotoFall.DataSource = this.qryZahlungsausgang;
            this.ctlGotoFall.Location = new System.Drawing.Point(451, 155);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(97, 24);
            this.ctlGotoFall.TabIndex = 8;
            // 
            // btnEintragAusgleichen
            // 
            this.btnEintragAusgleichen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEintragAusgleichen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEintragAusgleichen.Location = new System.Drawing.Point(571, 155);
            this.btnEintragAusgleichen.Name = "btnEintragAusgleichen";
            this.btnEintragAusgleichen.Size = new System.Drawing.Size(242, 24);
            this.btnEintragAusgleichen.TabIndex = 1;
            this.btnEintragAusgleichen.Text = "Eintrag als nicht ausgeglichen markieren";
            this.btnEintragAusgleichen.UseCompatibleTextRendering = true;
            this.btnEintragAusgleichen.UseVisualStyleBackColor = false;
            this.btnEintragAusgleichen.Click += new System.EventHandler(this.btnEintragAusgleichen_Click);
            // 
            // kissLabel8
            // 
            this.kissLabel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel8.Location = new System.Drawing.Point(-1, 155);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(67, 24);
            this.kissLabel8.TabIndex = 306;
            this.kissLabel8.Text = "Eingangs-Nr.";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit5
            // 
            this.kissTextEdit5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit5.DataMember = "KgZahlungseingangID";
            this.kissTextEdit5.DataSource = this.qryZahlungsausgang;
            this.kissTextEdit5.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit5.Location = new System.Drawing.Point(72, 155);
            this.kissTextEdit5.Name = "kissTextEdit5";
            this.kissTextEdit5.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit5.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit5.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit5.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit5.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit5.Properties.ReadOnly = true;
            this.kissTextEdit5.Size = new System.Drawing.Size(78, 24);
            this.kissTextEdit5.TabIndex = 305;
            // 
            // grbAusgaben
            // 
            this.grbAusgaben.Controls.Add(this.grdBetragsgleicheAusgaben);
            this.grbAusgaben.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grbAusgaben.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grbAusgaben.Location = new System.Drawing.Point(0, 459);
            this.grbAusgaben.Name = "grbAusgaben";
            this.grbAusgaben.Size = new System.Drawing.Size(816, 142);
            this.grbAusgaben.TabIndex = 412;
            this.grbAusgaben.TabStop = false;
            this.grbAusgaben.Text = "Ausgaben der Person m. zivilr. Massn.";
            this.grbAusgaben.UseCompatibleTextRendering = true;
            // 
            // grdBetragsgleicheAusgaben
            // 
            this.grdBetragsgleicheAusgaben.DataSource = this.qryKontoVorschau;
            this.grdBetragsgleicheAusgaben.Dock = System.Windows.Forms.DockStyle.Bottom;
            // 
            // 
            // 
            this.grdBetragsgleicheAusgaben.EmbeddedNavigator.Name = "";
            this.grdBetragsgleicheAusgaben.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBetragsgleicheAusgaben.Location = new System.Drawing.Point(3, 23);
            this.grdBetragsgleicheAusgaben.MainView = this.gridView4;
            this.grdBetragsgleicheAusgaben.Name = "grdBetragsgleicheAusgaben";
            this.grdBetragsgleicheAusgaben.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox3});
            this.grdBetragsgleicheAusgaben.Size = new System.Drawing.Size(810, 116);
            this.grdBetragsgleicheAusgaben.TabIndex = 0;
            this.grdBetragsgleicheAusgaben.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // qryKontoVorschau
            // 
            this.qryKontoVorschau.HostControl = this;
            this.qryKontoVorschau.SelectStatement = resources.GetString("qryKontoVorschau.SelectStatement");
            // 
            // gridView4
            // 
            this.gridView4.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView4.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.Empty.Options.UseBackColor = true;
            this.gridView4.Appearance.Empty.Options.UseFont = true;
            this.gridView4.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.EvenRow.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView4.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView4.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView4.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView4.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView4.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView4.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView4.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView4.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView4.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView4.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView4.Appearance.GroupRow.Options.UseFont = true;
            this.gridView4.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView4.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView4.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView4.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView4.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView4.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView4.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView4.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView4.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView4.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.OddRow.Options.UseFont = true;
            this.gridView4.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView4.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.Row.Options.UseBackColor = true;
            this.gridView4.Appearance.Row.Options.UseFont = true;
            this.gridView4.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView4.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView4.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView4.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchungsdatum2,
            this.colBuchungstext2,
            this.colSoll,
            this.gridColumn1,
            this.colSaldo2,
            this.colKreditor2,
            this.colPosStatus2});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView4.GridControl = this.grdBetragsgleicheAusgaben;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsBehavior.Editable = false;
            this.gridView4.OptionsCustomization.AllowFilter = false;
            this.gridView4.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView4.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView4.OptionsNavigation.UseTabKey = false;
            this.gridView4.OptionsView.ColumnAutoWidth = false;
            this.gridView4.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            this.gridView4.OptionsView.ShowIndicator = false;
            // 
            // colBuchungsdatum2
            // 
            this.colBuchungsdatum2.Caption = "Buchung";
            this.colBuchungsdatum2.FieldName = "BuchungsDatum";
            this.colBuchungsdatum2.Name = "colBuchungsdatum2";
            this.colBuchungsdatum2.Visible = true;
            this.colBuchungsdatum2.VisibleIndex = 0;
            // 
            // colBuchungstext2
            // 
            this.colBuchungstext2.Caption = "Buchungstext";
            this.colBuchungstext2.FieldName = "Buchungstext";
            this.colBuchungstext2.Name = "colBuchungstext2";
            this.colBuchungstext2.Visible = true;
            this.colBuchungstext2.VisibleIndex = 1;
            this.colBuchungstext2.Width = 297;
            // 
            // colSoll
            // 
            this.colSoll.Caption = "Soll";
            this.colSoll.DisplayFormat.FormatString = "n2";
            this.colSoll.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSoll.FieldName = "BetragSoll";
            this.colSoll.Name = "colSoll";
            this.colSoll.Visible = true;
            this.colSoll.VisibleIndex = 2;
            this.colSoll.Width = 80;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Haben";
            this.gridColumn1.DisplayFormat.FormatString = "n2";
            this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn1.FieldName = "BetragHaben";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 3;
            this.gridColumn1.Width = 80;
            // 
            // colSaldo2
            // 
            this.colSaldo2.Caption = "Saldo";
            this.colSaldo2.DisplayFormat.FormatString = "n2";
            this.colSaldo2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo2.FieldName = "Saldo";
            this.colSaldo2.Name = "colSaldo2";
            this.colSaldo2.Width = 80;
            // 
            // colKreditor2
            // 
            this.colKreditor2.Caption = "Kreditor";
            this.colKreditor2.FieldName = "Kreditor";
            this.colKreditor2.Name = "colKreditor2";
            this.colKreditor2.Visible = true;
            this.colKreditor2.VisibleIndex = 4;
            this.colKreditor2.Width = 279;
            // 
            // colPosStatus2
            // 
            this.colPosStatus2.Caption = "Stat.";
            this.colPosStatus2.ColumnEdit = this.repositoryItemImageComboBox3;
            this.colPosStatus2.FieldName = "Status";
            this.colPosStatus2.Name = "colPosStatus2";
            this.colPosStatus2.Width = 35;
            // 
            // repositoryItemImageComboBox3
            // 
            this.repositoryItemImageComboBox3.AutoHeight = false;
            this.repositoryItemImageComboBox3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox3.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox3.Name = "repositoryItemImageComboBox3";
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(3, 162);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(65, 24);
            this.kissLabel1.TabIndex = 318;
            this.kissLabel1.Text = "GVC";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // edtGVC
            // 
            this.edtGVC.Location = new System.Drawing.Point(147, 162);
            this.edtGVC.Name = "edtGVC";
            this.edtGVC.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGVC.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGVC.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGVC.Properties.Appearance.Options.UseBackColor = true;
            this.edtGVC.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGVC.Properties.Appearance.Options.UseFont = true;
            this.edtGVC.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGVC.Size = new System.Drawing.Size(318, 24);
            this.edtGVC.TabIndex = 317;
            // 
            // rbtnLebend
            // 
            this.rbtnLebend.EditValue = 0;
            this.rbtnLebend.Location = new System.Drawing.Point(147, 221);
            this.rbtnLebend.LookupSQL = null;
            this.rbtnLebend.LOVFilter = null;
            this.rbtnLebend.LOVName = null;
            this.rbtnLebend.Name = "rbtnLebend";
            this.rbtnLebend.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.rbtnLebend.Properties.Appearance.Options.UseBackColor = true;
            this.rbtnLebend.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.Transparent;
            this.rbtnLebend.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.rbtnLebend.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.rbtnLebend.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Nur Lebende"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Nur Todesfälle")});
            this.rbtnLebend.Size = new System.Drawing.Size(162, 49);
            this.rbtnLebend.TabIndex = 319;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kissLabel6.Location = new System.Drawing.Point(516, 195);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(172, 24);
            this.kissLabel6.TabIndex = 414;
            this.kissLabel6.Text = "Mitteilungen (MT940)";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissMemoEdit1
            // 
            this.kissMemoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.kissMemoEdit1.DataMember = "Mitteilung";
            this.kissMemoEdit1.DataSource = this.qryZahlungsausgang;
            this.kissMemoEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissMemoEdit1.Location = new System.Drawing.Point(516, 222);
            this.kissMemoEdit1.Name = "kissMemoEdit1";
            this.kissMemoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissMemoEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMemoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMemoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissMemoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissMemoEdit1.Properties.ReadOnly = true;
            this.kissMemoEdit1.Size = new System.Drawing.Size(300, 238);
            this.kissMemoEdit1.TabIndex = 413;
            // 
            // CtlKgZahlungsausgang
            // 
            this.ActiveSQLQuery = this.qryZahlungsausgang;
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(0, 270);
            this.Name = "CtlKgZahlungsausgang";
            this.Size = new System.Drawing.Size(828, 672);
            this.Load += new System.EventHandler(this.CtlKgZahlungsausgang_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumentHidden.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryDocument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAusgleich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungsausgang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAusgleich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungseingang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungseingang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilungX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurAusgeglichenX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungsDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKonto.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit5.Properties)).EndInit();
            this.grbAusgaben.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdBetragsgleicheAusgaben)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontoVorschau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGVC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnLebend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbtnLebend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.Columns.GridColumn colAusgeglichen;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgleich;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag2;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungsDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum2;
        private DevExpress.XtraGrid.Columns.GridColumn colMitteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colSollKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumente;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCalcEdit edtAnzahl;
        private KiSS4.Gui.KissButtonEdit edtBaPersonIDX;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissCalcEdit edtBetragBisX;
        private KiSS4.Gui.KissCalcEdit edtBetragVonX;
        private KiSS4.Gui.KissDateEdit edtDatumBisX;
        private KiSS4.Gui.KissDateEdit edtDatumVonX;
        private KiSS4.Gui.KissTextEdit edtMitteilungX;
        private KiSS4.Gui.KissCheckEdit edtNurAusgeglichenX;
        private KiSS4.Gui.KissCalcEdit edtTotal;
        private KiSS4.Gui.KissGrid grdAusgleich;
        private KiSS4.Gui.KissGrid grdZahlungseingang;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAusgleich;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZahlungseingang;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KiSS4.Gui.KissLabel kissLabel11;
        private KiSS4.Gui.KissLabel kissLabel12;
        private KiSS4.Gui.KissLabel kissLabel14;
        private KiSS4.Gui.KissLabel kissLabel15;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel19;
        private KiSS4.Gui.KissLabel kissLabel20;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblTitel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryZahlungsausgang;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private SharpLibrary.WinControls.TabPageEx tabPageEx1;
        private KiSS4.Gui.KissButton btnZugeordneteDoks;
        private System.Windows.Forms.GroupBox groupBox1;
        private KiSS4.Gui.KissLabel lblBuchungsDatum;
        private KiSS4.Gui.KissDateEdit edtBuchungsdatum;
        private KiSS4.Gui.KissLabel lblBuchungstext2;
        private KiSS4.Gui.KissLabel lblKonto2;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KiSS4.Gui.KissTextEdit kissTextEdit5;
        private KiSS4.Gui.KissButton btnEintragAusgleichen;
        protected KiSS4.Common.CtlGotoFall ctlGotoFall;
        private KiSS4.Gui.KissGroupBox grbAusgaben;
        private KiSS4.Gui.KissGrid grdBetragsgleicheAusgaben;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungsdatum2;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext2;
        private DevExpress.XtraGrid.Columns.GridColumn colSoll;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldo2;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor2;
        private DevExpress.XtraGrid.Columns.GridColumn colPosStatus2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox3;
        private KiSS4.DB.SqlQuery qryKgBuchung;
        private KiSS4.DB.SqlQuery qryKontoVorschau;
        private DevExpress.XtraGrid.Columns.GridColumn colGVC;
        private KiSS4.DB.SqlQuery qryDocument;
        private Dokument.XDokument edtDokumentHidden;
        private KiSS4.Gui.KissButton btnSave;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissTextEdit edtGVC;
        private KiSS4.Gui.KissRadioGroup rbtnLebend;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissMemoEdit kissMemoEdit1;
        private KiSS4.Gui.KissButtonEdit edtKonto;
        private Gui.KissComboBox edtBuchungstext;
    }
}
