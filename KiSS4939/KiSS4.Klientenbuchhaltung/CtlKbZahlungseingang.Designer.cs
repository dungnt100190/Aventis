namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlKbZahlungseingang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbZahlungseingang));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.tabDetails = new KiSS4.Gui.KissTabControlEx();
            this.tpgAusgleich = new SharpLibrary.WinControls.TabPageEx();
            this.lblAusgleichBeleg = new KiSS4.Gui.KissLabel();
            this.edtAusgleichKbBuchungID = new KiSS4.Gui.KissTextEdit();
            this.qryAusgleich = new KiSS4.DB.SqlQuery(this.components);
            this.btnAusgleichAufheben = new KiSS4.Gui.KissButton();
            this.lblAusgleichText = new KiSS4.Gui.KissLabel();
            this.lblAusgleichDebitor = new KiSS4.Gui.KissLabel();
            this.lblAusgleichRestbetrag = new KiSS4.Gui.KissLabel();
            this.btnAusgleichSpeichern = new KiSS4.Gui.KissButton();
            this.edtRestbetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtAusgleichDebitor = new KiSS4.Gui.KissTextEdit();
            this.edtAusgleichText = new KiSS4.Gui.KissTextEdit();
            this.grdAusgleich = new KiSS4.Gui.KissGrid();
            this.grvAusgleich = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBudgetMonatJahr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHaben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitor3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenstelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalbetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRestbetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgleich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAusgleichen = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colAusgleichBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.tpgZahlung = new SharpLibrary.WinControls.TabPageEx();
            this.lblZugeteiltUserID = new KiSS4.Gui.KissLabel();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.lblKontoZahlung = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.qryZahlungseingang = new KiSS4.DB.SqlQuery(this.components);
            this.edtMitteilung4 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilung3 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilung2 = new KiSS4.Gui.KissTextEdit();
            this.edtMitteilung1 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.edtZugeteiltUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtKlient = new KiSS4.Gui.KissButtonEdit();
            this.edtDebitor = new KiSS4.Gui.KissTextEdit();
            this.edtInstitution = new KiSS4.Gui.KissButtonEdit();
            this.edtKontoZahlung = new KiSS4.Gui.KissButtonEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.grdZahlungsingang = new KiSS4.Gui.KissGrid();
            this.grvZahlungseingang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDebitor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAusgeglichen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerbucht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEingangSelektiert = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.edtDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.edtBaInstitutionIDX = new KiSS4.Gui.KissButtonEdit();
            this.edtBetragVonX = new KiSS4.Gui.KissCalcEdit();
            this.edtBetragBisX = new KiSS4.Gui.KissCalcEdit();
            this.edtNurUnausgeglichenX = new KiSS4.Gui.KissCheckEdit();
            this.lblDatumVonX = new KiSS4.Gui.KissLabel();
            this.lblBetragVonX = new KiSS4.Gui.KissLabel();
            this.lblDatumBisX = new KiSS4.Gui.KissLabel();
            this.lblBetragBisX = new KiSS4.Gui.KissLabel();
            this.lblDebitorX = new KiSS4.Gui.KissLabel();
            this.lblKontoVonX = new KiSS4.Gui.KissLabel();
            this.lblKontoBisX = new KiSS4.Gui.KissLabel();
            this.edtKontoNrVonX = new KiSS4.Gui.KissButtonEdit();
            this.edtKontoNrBisX = new KiSS4.Gui.KissButtonEdit();
            this.btnSelektieren = new KiSS4.Gui.KissButton();
            this.btnVerbuchen = new KiSS4.Gui.KissButton();
            this.edtNurUnverbuchtX = new KiSS4.Gui.KissCheckEdit();
            this.colZuteilungSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            this.tabDetails.SuspendLayout();
            this.tpgAusgleich.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgleichBeleg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgleichKbBuchungID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAusgleich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgleichText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgleichDebitor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgleichRestbetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRestbetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgleichDebitor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgleichText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAusgleich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAusgleich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAusgleichen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            this.tpgZahlung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblZugeteiltUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoZahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungseingang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZugeteiltUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDebitor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoZahlung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungsingang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungseingang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitutionIDX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurUnausgeglichenX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDebitorX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoVonX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNrVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNrBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurUnverbuchtX.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(799, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlSearch.Location = new System.Drawing.Point(0, 27);
            this.tabControlSearch.Size = new System.Drawing.Size(823, 264);
            this.tabControlSearch.TabIndex = 3;
            // 
            // tpgListe
            // 
            this.tpgListe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tpgListe.Controls.Add(this.grdZahlungsingang);
            this.tpgListe.Size = new System.Drawing.Size(811, 226);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNurUnverbuchtX);
            this.tpgSuchen.Controls.Add(this.edtKontoNrBisX);
            this.tpgSuchen.Controls.Add(this.edtKontoNrVonX);
            this.tpgSuchen.Controls.Add(this.lblKontoBisX);
            this.tpgSuchen.Controls.Add(this.lblKontoVonX);
            this.tpgSuchen.Controls.Add(this.lblDebitorX);
            this.tpgSuchen.Controls.Add(this.lblBetragBisX);
            this.tpgSuchen.Controls.Add(this.lblDatumBisX);
            this.tpgSuchen.Controls.Add(this.lblBetragVonX);
            this.tpgSuchen.Controls.Add(this.lblDatumVonX);
            this.tpgSuchen.Controls.Add(this.edtNurUnausgeglichenX);
            this.tpgSuchen.Controls.Add(this.edtBetragBisX);
            this.tpgSuchen.Controls.Add(this.edtBetragVonX);
            this.tpgSuchen.Controls.Add(this.edtBaInstitutionIDX);
            this.tpgSuchen.Controls.Add(this.edtDatumBisX);
            this.tpgSuchen.Controls.Add(this.edtDatumVonX);
            this.tpgSuchen.Size = new System.Drawing.Size(811, 226);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBaInstitutionIDX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetragVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBetragBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurUnausgeglichenX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBetragVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBetragBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblDebitorX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKontoVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblKontoBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKontoNrVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtKontoNrBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurUnverbuchtX, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 24);
            this.panel1.TabIndex = 0;
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
            this.lblTitel.Size = new System.Drawing.Size(542, 22);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Zahlungseingang";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.tpgAusgleich);
            this.tabDetails.Controls.Add(this.tpgZahlung);
            this.tabDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabDetails.Location = new System.Drawing.Point(0, 300);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.SelectedTabIndex = 1;
            this.tabDetails.ShowFixedWidthTooltip = true;
            this.tabDetails.Size = new System.Drawing.Size(825, 296);
            this.tabDetails.TabIndex = 1;
            this.tabDetails.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgZahlung,
            this.tpgAusgleich});
            this.tabDetails.TabsLineColor = System.Drawing.Color.Black;
            this.tabDetails.TabsStyle = SharpLibrary.WinControls.TabsStyle.Flat;
            this.tabDetails.Text = "kissTabControlEx1";
            // 
            // tpgAusgleich
            // 
            this.tpgAusgleich.Controls.Add(this.lblAusgleichBeleg);
            this.tpgAusgleich.Controls.Add(this.edtAusgleichKbBuchungID);
            this.tpgAusgleich.Controls.Add(this.btnAusgleichAufheben);
            this.tpgAusgleich.Controls.Add(this.lblAusgleichText);
            this.tpgAusgleich.Controls.Add(this.lblAusgleichDebitor);
            this.tpgAusgleich.Controls.Add(this.lblAusgleichRestbetrag);
            this.tpgAusgleich.Controls.Add(this.btnAusgleichSpeichern);
            this.tpgAusgleich.Controls.Add(this.edtRestbetrag);
            this.tpgAusgleich.Controls.Add(this.edtAusgleichDebitor);
            this.tpgAusgleich.Controls.Add(this.edtAusgleichText);
            this.tpgAusgleich.Controls.Add(this.grdAusgleich);
            this.tpgAusgleich.Location = new System.Drawing.Point(6, 6);
            this.tpgAusgleich.Name = "tpgAusgleich";
            this.tpgAusgleich.Size = new System.Drawing.Size(813, 258);
            this.tpgAusgleich.TabIndex = 1;
            this.tpgAusgleich.Title = "Ausgleich";
            // 
            // lblAusgleichBeleg
            // 
            this.lblAusgleichBeleg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusgleichBeleg.Location = new System.Drawing.Point(427, 199);
            this.lblAusgleichBeleg.Name = "lblAusgleichBeleg";
            this.lblAusgleichBeleg.Size = new System.Drawing.Size(51, 24);
            this.lblAusgleichBeleg.TabIndex = 297;
            this.lblAusgleichBeleg.Text = "Beleg ID";
            this.lblAusgleichBeleg.UseCompatibleTextRendering = true;
            // 
            // edtAusgleichKbBuchungID
            // 
            this.edtAusgleichKbBuchungID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAusgleichKbBuchungID.DataMember = "KbBuchungID";
            this.edtAusgleichKbBuchungID.DataSource = this.qryAusgleich;
            this.edtAusgleichKbBuchungID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAusgleichKbBuchungID.Location = new System.Drawing.Point(483, 199);
            this.edtAusgleichKbBuchungID.Name = "edtAusgleichKbBuchungID";
            this.edtAusgleichKbBuchungID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAusgleichKbBuchungID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusgleichKbBuchungID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusgleichKbBuchungID.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusgleichKbBuchungID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusgleichKbBuchungID.Properties.Appearance.Options.UseFont = true;
            this.edtAusgleichKbBuchungID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAusgleichKbBuchungID.Properties.ReadOnly = true;
            this.edtAusgleichKbBuchungID.Size = new System.Drawing.Size(78, 24);
            this.edtAusgleichKbBuchungID.TabIndex = 296;
            // 
            // qryAusgleich
            // 
            this.qryAusgleich.BatchUpdate = true;
            this.qryAusgleich.CanDelete = true;
            this.qryAusgleich.CanInsert = true;
            this.qryAusgleich.CanUpdate = true;
            this.qryAusgleich.HostControl = this;
            this.qryAusgleich.SelectStatement = "--sql statement in Code\r\nselect null";
            this.qryAusgleich.PositionChanged += new System.EventHandler(this.qryAusgleich_PositionChanged);
            // 
            // btnAusgleichAufheben
            // 
            this.btnAusgleichAufheben.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAusgleichAufheben.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAusgleichAufheben.Location = new System.Drawing.Point(531, 234);
            this.btnAusgleichAufheben.Name = "btnAusgleichAufheben";
            this.btnAusgleichAufheben.Size = new System.Drawing.Size(154, 24);
            this.btnAusgleichAufheben.TabIndex = 295;
            this.btnAusgleichAufheben.Text = "Ausgleich aufheben";
            this.btnAusgleichAufheben.UseCompatibleTextRendering = true;
            this.btnAusgleichAufheben.UseVisualStyleBackColor = false;
            this.btnAusgleichAufheben.Click += new System.EventHandler(this.btnAusgleichAufheben_Click);
            // 
            // lblAusgleichText
            // 
            this.lblAusgleichText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusgleichText.Location = new System.Drawing.Point(3, 199);
            this.lblAusgleichText.Name = "lblAusgleichText";
            this.lblAusgleichText.Size = new System.Drawing.Size(40, 24);
            this.lblAusgleichText.TabIndex = 294;
            this.lblAusgleichText.Text = "Text";
            this.lblAusgleichText.UseCompatibleTextRendering = true;
            // 
            // lblAusgleichDebitor
            // 
            this.lblAusgleichDebitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusgleichDebitor.Location = new System.Drawing.Point(3, 229);
            this.lblAusgleichDebitor.Name = "lblAusgleichDebitor";
            this.lblAusgleichDebitor.Size = new System.Drawing.Size(40, 24);
            this.lblAusgleichDebitor.TabIndex = 294;
            this.lblAusgleichDebitor.Text = "Debitor";
            this.lblAusgleichDebitor.UseCompatibleTextRendering = true;
            // 
            // lblAusgleichRestbetrag
            // 
            this.lblAusgleichRestbetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAusgleichRestbetrag.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAusgleichRestbetrag.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblAusgleichRestbetrag.Location = new System.Drawing.Point(583, 205);
            this.lblAusgleichRestbetrag.Name = "lblAusgleichRestbetrag";
            this.lblAusgleichRestbetrag.Size = new System.Drawing.Size(63, 15);
            this.lblAusgleichRestbetrag.TabIndex = 292;
            this.lblAusgleichRestbetrag.Text = "Restbetrag";
            this.lblAusgleichRestbetrag.UseCompatibleTextRendering = true;
            // 
            // btnAusgleichSpeichern
            // 
            this.btnAusgleichSpeichern.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAusgleichSpeichern.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAusgleichSpeichern.Location = new System.Drawing.Point(583, 229);
            this.btnAusgleichSpeichern.Name = "btnAusgleichSpeichern";
            this.btnAusgleichSpeichern.Size = new System.Drawing.Size(154, 24);
            this.btnAusgleichSpeichern.TabIndex = 4;
            this.btnAusgleichSpeichern.Text = "Ausgleich speichern";
            this.btnAusgleichSpeichern.UseCompatibleTextRendering = true;
            this.btnAusgleichSpeichern.UseVisualStyleBackColor = false;
            this.btnAusgleichSpeichern.Click += new System.EventHandler(this.btnAusgleichSpeichern_Click);
            // 
            // edtRestbetrag
            // 
            this.edtRestbetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtRestbetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtRestbetrag.Location = new System.Drawing.Point(648, 199);
            this.edtRestbetrag.Name = "edtRestbetrag";
            this.edtRestbetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRestbetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtRestbetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRestbetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRestbetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtRestbetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRestbetrag.Properties.Appearance.Options.UseFont = true;
            this.edtRestbetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRestbetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRestbetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtRestbetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtRestbetrag.Properties.EditFormat.FormatString = "N2";
            this.edtRestbetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtRestbetrag.Properties.Mask.EditMask = "N2";
            this.edtRestbetrag.Properties.ReadOnly = true;
            this.edtRestbetrag.Size = new System.Drawing.Size(89, 24);
            this.edtRestbetrag.TabIndex = 3;
            // 
            // edtAusgleichDebitor
            // 
            this.edtAusgleichDebitor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAusgleichDebitor.DataMember = "Debitor";
            this.edtAusgleichDebitor.DataSource = this.qryAusgleich;
            this.edtAusgleichDebitor.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAusgleichDebitor.Location = new System.Drawing.Point(50, 229);
            this.edtAusgleichDebitor.Name = "edtAusgleichDebitor";
            this.edtAusgleichDebitor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAusgleichDebitor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusgleichDebitor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusgleichDebitor.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusgleichDebitor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusgleichDebitor.Properties.Appearance.Options.UseFont = true;
            this.edtAusgleichDebitor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAusgleichDebitor.Properties.ReadOnly = true;
            this.edtAusgleichDebitor.Size = new System.Drawing.Size(511, 24);
            this.edtAusgleichDebitor.TabIndex = 2;
            // 
            // edtAusgleichText
            // 
            this.edtAusgleichText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAusgleichText.DataMember = "Text";
            this.edtAusgleichText.DataSource = this.qryAusgleich;
            this.edtAusgleichText.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAusgleichText.Location = new System.Drawing.Point(50, 199);
            this.edtAusgleichText.Name = "edtAusgleichText";
            this.edtAusgleichText.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAusgleichText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAusgleichText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAusgleichText.Properties.Appearance.Options.UseBackColor = true;
            this.edtAusgleichText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAusgleichText.Properties.Appearance.Options.UseFont = true;
            this.edtAusgleichText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAusgleichText.Properties.ReadOnly = true;
            this.edtAusgleichText.Size = new System.Drawing.Size(371, 24);
            this.edtAusgleichText.TabIndex = 1;
            // 
            // grdAusgleich
            // 
            this.grdAusgleich.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAusgleich.DataSource = this.qryAusgleich;
            // 
            // 
            // 
            this.grdAusgleich.EmbeddedNavigator.Name = "";
            this.grdAusgleich.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdAusgleich.Location = new System.Drawing.Point(0, 0);
            this.grdAusgleich.MainView = this.grvAusgleich;
            this.grdAusgleich.Name = "grdAusgleich";
            this.grdAusgleich.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btnAusgleichen,
            this.repositoryItemTextEdit1});
            this.grdAusgleich.Size = new System.Drawing.Size(811, 193);
            this.grdAusgleich.TabIndex = 0;
            this.grdAusgleich.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvAusgleich});
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
            this.grvAusgleich.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAusgleich.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvAusgleich.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.FocusedCell.Options.UseFont = true;
            this.grvAusgleich.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvAusgleich.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAusgleich.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
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
            this.grvAusgleich.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAusgleich.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvAusgleich.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvAusgleich.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvAusgleich.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvAusgleich.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.OddRow.Options.UseFont = true;
            this.grvAusgleich.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAusgleich.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.Row.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.Row.Options.UseFont = true;
            this.grvAusgleich.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvAusgleich.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvAusgleich.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvAusgleich.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvAusgleich.Appearance.SelectedRow.Options.UseFont = true;
            this.grvAusgleich.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvAusgleich.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvAusgleich.Appearance.VertLine.Options.UseBackColor = true;
            this.grvAusgleich.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvAusgleich.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBudgetMonatJahr,
            this.colDatum,
            this.colHaben,
            this.colDebitor3,
            this.colKostenstelle,
            this.colText,
            this.colTotalbetrag,
            this.colRestbetrag,
            this.colAusgleich,
            this.colAusgleichBetrag});
            this.grvAusgleich.GridControl = this.grdAusgleich;
            this.grvAusgleich.Name = "grvAusgleich";
            this.grvAusgleich.OptionsCustomization.AllowFilter = false;
            this.grvAusgleich.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvAusgleich.OptionsNavigation.AutoFocusNewRow = true;
            this.grvAusgleich.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvAusgleich.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvAusgleich.OptionsView.ColumnAutoWidth = false;
            this.grvAusgleich.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvAusgleich.OptionsView.ShowGroupPanel = false;
            // 
            // colBudgetMonatJahr
            // 
            this.colBudgetMonatJahr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBudgetMonatJahr.AppearanceCell.Options.UseBackColor = true;
            this.colBudgetMonatJahr.Caption = "Budget";
            this.colBudgetMonatJahr.FieldName = "BudgetMonatJahr";
            this.colBudgetMonatJahr.Name = "colBudgetMonatJahr";
            this.colBudgetMonatJahr.OptionsColumn.AllowEdit = false;
            this.colBudgetMonatJahr.Visible = true;
            this.colBudgetMonatJahr.VisibleIndex = 0;
            // 
            // colDatum
            // 
            this.colDatum.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatum.AppearanceCell.Options.UseBackColor = true;
            this.colDatum.Caption = "Fällig am";
            this.colDatum.FieldName = "Valuta";
            this.colDatum.Name = "colDatum";
            this.colDatum.OptionsColumn.AllowEdit = false;
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 1;
            // 
            // colHaben
            // 
            this.colHaben.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colHaben.AppearanceCell.Options.UseBackColor = true;
            this.colHaben.Caption = "Haben";
            this.colHaben.FieldName = "Haben";
            this.colHaben.Name = "colHaben";
            this.colHaben.OptionsColumn.AllowEdit = false;
            this.colHaben.Visible = true;
            this.colHaben.VisibleIndex = 2;
            this.colHaben.Width = 57;
            // 
            // colDebitor3
            // 
            this.colDebitor3.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDebitor3.AppearanceCell.Options.UseBackColor = true;
            this.colDebitor3.Caption = "Debitor";
            this.colDebitor3.FieldName = "Debitor";
            this.colDebitor3.Name = "colDebitor3";
            this.colDebitor3.OptionsColumn.AllowEdit = false;
            this.colDebitor3.Visible = true;
            this.colDebitor3.VisibleIndex = 3;
            this.colDebitor3.Width = 111;
            // 
            // colKostenstelle
            // 
            this.colKostenstelle.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKostenstelle.AppearanceCell.Options.UseBackColor = true;
            this.colKostenstelle.Caption = "Kostenstelle";
            this.colKostenstelle.FieldName = "Kostenstelle";
            this.colKostenstelle.Name = "colKostenstelle";
            this.colKostenstelle.OptionsColumn.AllowEdit = false;
            this.colKostenstelle.Visible = true;
            this.colKostenstelle.VisibleIndex = 4;
            this.colKostenstelle.Width = 107;
            // 
            // colText
            // 
            this.colText.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colText.AppearanceCell.Options.UseBackColor = true;
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.OptionsColumn.AllowEdit = false;
            this.colText.Visible = true;
            this.colText.VisibleIndex = 5;
            this.colText.Width = 226;
            // 
            // colTotalbetrag
            // 
            this.colTotalbetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colTotalbetrag.AppearanceCell.Options.UseBackColor = true;
            this.colTotalbetrag.Caption = "Betrag";
            this.colTotalbetrag.DisplayFormat.FormatString = "N2";
            this.colTotalbetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalbetrag.FieldName = "Betrag";
            this.colTotalbetrag.Name = "colTotalbetrag";
            this.colTotalbetrag.OptionsColumn.AllowEdit = false;
            this.colTotalbetrag.ToolTip = "Totalbetrag";
            this.colTotalbetrag.Visible = true;
            this.colTotalbetrag.VisibleIndex = 6;
            this.colTotalbetrag.Width = 64;
            // 
            // colRestbetrag
            // 
            this.colRestbetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colRestbetrag.AppearanceCell.Options.UseBackColor = true;
            this.colRestbetrag.Caption = "Restbetrag";
            this.colRestbetrag.DisplayFormat.FormatString = "N2";
            this.colRestbetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colRestbetrag.FieldName = "RestBetrag";
            this.colRestbetrag.Name = "colRestbetrag";
            this.colRestbetrag.OptionsColumn.AllowEdit = false;
            this.colRestbetrag.Visible = true;
            this.colRestbetrag.VisibleIndex = 7;
            this.colRestbetrag.Width = 73;
            // 
            // colAusgleich
            // 
            this.colAusgleich.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAusgleich.AppearanceCell.Options.UseBackColor = true;
            this.colAusgleich.ColumnEdit = this.btnAusgleichen;
            this.colAusgleich.Name = "colAusgleich";
            this.colAusgleich.Visible = true;
            this.colAusgleich.VisibleIndex = 8;
            this.colAusgleich.Width = 23;
            // 
            // btnAusgleichen
            // 
            this.btnAusgleichen.AutoHeight = false;
            this.btnAusgleichen.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Right),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Left, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, null)});
            this.btnAusgleichen.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnAusgleichen.Name = "btnAusgleichen";
            this.btnAusgleichen.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btnAusgleichen.Click += new System.EventHandler(this.btnAusgleichen_Click);
            // 
            // colAusgleichBetrag
            // 
            this.colAusgleichBetrag.Caption = "Ausgl. Betr.";
            this.colAusgleichBetrag.ColumnEdit = this.repositoryItemTextEdit1;
            this.colAusgleichBetrag.DisplayFormat.FormatString = "N2";
            this.colAusgleichBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAusgleichBetrag.FieldName = "AusglBetrag";
            this.colAusgleichBetrag.GroupFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAusgleichBetrag.Name = "colAusgleichBetrag";
            this.colAusgleichBetrag.ToolTip = "Ausgleichsbetrag";
            this.colAusgleichBetrag.Visible = true;
            this.colAusgleichBetrag.VisibleIndex = 9;
            this.colAusgleichBetrag.Width = 83;
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
            // tpgZahlung
            // 
            this.tpgZahlung.Controls.Add(this.lblZugeteiltUserID);
            this.tpgZahlung.Controls.Add(this.kissLabel17);
            this.tpgZahlung.Controls.Add(this.lblBetrag);
            this.tpgZahlung.Controls.Add(this.kissLabel16);
            this.tpgZahlung.Controls.Add(this.kissLabel5);
            this.tpgZahlung.Controls.Add(this.lblKontoZahlung);
            this.tpgZahlung.Controls.Add(this.kissLabel3);
            this.tpgZahlung.Controls.Add(this.edtBemerkung);
            this.tpgZahlung.Controls.Add(this.edtMitteilung4);
            this.tpgZahlung.Controls.Add(this.edtMitteilung3);
            this.tpgZahlung.Controls.Add(this.edtMitteilung2);
            this.tpgZahlung.Controls.Add(this.edtMitteilung1);
            this.tpgZahlung.Controls.Add(this.kissLabel6);
            this.tpgZahlung.Controls.Add(this.edtZugeteiltUserID);
            this.tpgZahlung.Controls.Add(this.edtKlient);
            this.tpgZahlung.Controls.Add(this.edtDebitor);
            this.tpgZahlung.Controls.Add(this.edtInstitution);
            this.tpgZahlung.Controls.Add(this.edtKontoZahlung);
            this.tpgZahlung.Controls.Add(this.edtBetrag);
            this.tpgZahlung.Controls.Add(this.lblDatum);
            this.tpgZahlung.Controls.Add(this.edtDatum);
            this.tpgZahlung.Location = new System.Drawing.Point(6, 6);
            this.tpgZahlung.Name = "tpgZahlung";
            this.tpgZahlung.Size = new System.Drawing.Size(813, 258);
            this.tpgZahlung.TabIndex = 0;
            this.tpgZahlung.Title = "Zahlung";
            // 
            // lblZugeteiltUserID
            // 
            this.lblZugeteiltUserID.Location = new System.Drawing.Point(5, 187);
            this.lblZugeteiltUserID.Name = "lblZugeteiltUserID";
            this.lblZugeteiltUserID.Size = new System.Drawing.Size(79, 24);
            this.lblZugeteiltUserID.TabIndex = 318;
            this.lblZugeteiltUserID.Text = "Zuteilung SAR";
            this.lblZugeteiltUserID.UseCompatibleTextRendering = true;
            // 
            // kissLabel17
            // 
            this.kissLabel17.Location = new System.Drawing.Point(407, 128);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(69, 24);
            this.kissLabel17.TabIndex = 316;
            this.kissLabel17.Text = "Bemerkung";
            this.kissLabel17.UseCompatibleTextRendering = true;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(5, 35);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(44, 24);
            this.lblBetrag.TabIndex = 309;
            this.lblBetrag.Text = "Betrag";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // kissLabel16
            // 
            this.kissLabel16.Location = new System.Drawing.Point(5, 96);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(52, 24);
            this.kissLabel16.TabIndex = 307;
            this.kissLabel16.Text = "Institution";
            this.kissLabel16.UseCompatibleTextRendering = true;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(5, 126);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(44, 24);
            this.kissLabel5.TabIndex = 304;
            this.kissLabel5.Text = "Debitor";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // lblKontoZahlung
            // 
            this.lblKontoZahlung.Location = new System.Drawing.Point(5, 66);
            this.lblKontoZahlung.Name = "lblKontoZahlung";
            this.lblKontoZahlung.Size = new System.Drawing.Size(37, 24);
            this.lblKontoZahlung.TabIndex = 302;
            this.lblKontoZahlung.Text = "Konto";
            this.lblKontoZahlung.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(5, 157);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(37, 24);
            this.kissLabel3.TabIndex = 300;
            this.kissLabel3.Text = "Klient";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryZahlungseingang;
            this.edtBemerkung.Location = new System.Drawing.Point(407, 153);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(330, 64);
            this.edtBemerkung.TabIndex = 11;
            // 
            // qryZahlungseingang
            // 
            this.qryZahlungseingang.CanDelete = true;
            this.qryZahlungseingang.CanInsert = true;
            this.qryZahlungseingang.CanUpdate = true;
            this.qryZahlungseingang.HostControl = this;
            this.qryZahlungseingang.SelectStatement = resources.GetString("qryZahlungseingang.SelectStatement");
            this.qryZahlungseingang.TableName = "KbZahlungseingang";
            this.qryZahlungseingang.AfterFill += new System.EventHandler(this.qryZahlungseingang_AfterFill);
            this.qryZahlungseingang.AfterInsert += new System.EventHandler(this.qryZahlungseingang_AfterInsert);
            this.qryZahlungseingang.BeforePost += new System.EventHandler(this.qryZahlungseingang_BeforePost);
            this.qryZahlungseingang.AfterPost += new System.EventHandler(this.qryZahlungseingang_AfterPost);
            this.qryZahlungseingang.BeforeDeleteQuestion += new System.EventHandler(this.qryZahlungseingang_BeforeDeleteQuestion);
            this.qryZahlungseingang.PositionChanged += new System.EventHandler(this.qryZahlungseingang_PositionChanged);
            // 
            // edtMitteilung4
            // 
            this.edtMitteilung4.DataMember = "Mitteilung4";
            this.edtMitteilung4.DataSource = this.qryZahlungseingang;
            this.edtMitteilung4.Location = new System.Drawing.Point(407, 104);
            this.edtMitteilung4.Name = "edtMitteilung4";
            this.edtMitteilung4.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilung4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilung4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilung4.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilung4.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilung4.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilung4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilung4.Properties.MaxLength = 100;
            this.edtMitteilung4.Size = new System.Drawing.Size(330, 24);
            this.edtMitteilung4.TabIndex = 10;
            // 
            // edtMitteilung3
            // 
            this.edtMitteilung3.DataMember = "Mitteilung3";
            this.edtMitteilung3.DataSource = this.qryZahlungseingang;
            this.edtMitteilung3.Location = new System.Drawing.Point(407, 81);
            this.edtMitteilung3.Name = "edtMitteilung3";
            this.edtMitteilung3.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilung3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilung3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilung3.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilung3.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilung3.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilung3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilung3.Properties.MaxLength = 100;
            this.edtMitteilung3.Size = new System.Drawing.Size(330, 24);
            this.edtMitteilung3.TabIndex = 9;
            // 
            // edtMitteilung2
            // 
            this.edtMitteilung2.DataMember = "Mitteilung2";
            this.edtMitteilung2.DataSource = this.qryZahlungseingang;
            this.edtMitteilung2.Location = new System.Drawing.Point(407, 58);
            this.edtMitteilung2.Name = "edtMitteilung2";
            this.edtMitteilung2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilung2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilung2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilung2.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilung2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilung2.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilung2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilung2.Properties.MaxLength = 100;
            this.edtMitteilung2.Size = new System.Drawing.Size(330, 24);
            this.edtMitteilung2.TabIndex = 8;
            // 
            // edtMitteilung1
            // 
            this.edtMitteilung1.DataMember = "Mitteilung1";
            this.edtMitteilung1.DataSource = this.qryZahlungseingang;
            this.edtMitteilung1.Location = new System.Drawing.Point(407, 35);
            this.edtMitteilung1.Name = "edtMitteilung1";
            this.edtMitteilung1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMitteilung1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMitteilung1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMitteilung1.Properties.Appearance.Options.UseBackColor = true;
            this.edtMitteilung1.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMitteilung1.Properties.Appearance.Options.UseFont = true;
            this.edtMitteilung1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMitteilung1.Properties.MaxLength = 100;
            this.edtMitteilung1.Size = new System.Drawing.Size(330, 24);
            this.edtMitteilung1.TabIndex = 7;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(407, 5);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(69, 24);
            this.kissLabel6.TabIndex = 6;
            this.kissLabel6.Text = "Mitteilungen";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // edtZugeteiltUserID
            // 
            this.edtZugeteiltUserID.DataMember = "SAR";
            this.edtZugeteiltUserID.DataSource = this.qryZahlungseingang;
            this.edtZugeteiltUserID.Location = new System.Drawing.Point(85, 186);
            this.edtZugeteiltUserID.Name = "edtZugeteiltUserID";
            this.edtZugeteiltUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZugeteiltUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZugeteiltUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZugeteiltUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtZugeteiltUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZugeteiltUserID.Properties.Appearance.Options.UseFont = true;
            this.edtZugeteiltUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtZugeteiltUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtZugeteiltUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtZugeteiltUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtZugeteiltUserID.Size = new System.Drawing.Size(297, 24);
            this.edtZugeteiltUserID.TabIndex = 6;
            this.edtZugeteiltUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtZugeteiltUserID_UserModifiedFld);
            // 
            // edtKlient
            // 
            this.edtKlient.DataMember = "Klient";
            this.edtKlient.DataSource = this.qryZahlungseingang;
            this.edtKlient.Location = new System.Drawing.Point(85, 156);
            this.edtKlient.Name = "edtKlient";
            this.edtKlient.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKlient.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKlient.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKlient.Properties.Appearance.Options.UseBackColor = true;
            this.edtKlient.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKlient.Properties.Appearance.Options.UseFont = true;
            this.edtKlient.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKlient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKlient.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKlient.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKlient.Size = new System.Drawing.Size(297, 24);
            this.edtKlient.TabIndex = 5;
            this.edtKlient.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKlient_UserModifiedFld);
            // 
            // edtDebitor
            // 
            this.edtDebitor.DataMember = "Debitor";
            this.edtDebitor.DataSource = this.qryZahlungseingang;
            this.edtDebitor.Location = new System.Drawing.Point(85, 126);
            this.edtDebitor.Name = "edtDebitor";
            this.edtDebitor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDebitor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDebitor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDebitor.Properties.Appearance.Options.UseBackColor = true;
            this.edtDebitor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDebitor.Properties.Appearance.Options.UseFont = true;
            this.edtDebitor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDebitor.Properties.MaxLength = 200;
            this.edtDebitor.Size = new System.Drawing.Size(297, 24);
            this.edtDebitor.TabIndex = 4;
            // 
            // edtInstitution
            // 
            this.edtInstitution.DataMember = "Institution";
            this.edtInstitution.DataSource = this.qryZahlungseingang;
            this.edtInstitution.Location = new System.Drawing.Point(85, 96);
            this.edtInstitution.Name = "edtInstitution";
            this.edtInstitution.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInstitution.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInstitution.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInstitution.Properties.Appearance.Options.UseBackColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInstitution.Properties.Appearance.Options.UseFont = true;
            this.edtInstitution.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtInstitution.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtInstitution.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInstitution.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtInstitution.Size = new System.Drawing.Size(297, 24);
            this.edtInstitution.TabIndex = 3;
            this.edtInstitution.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtInstitution_UserModifiedFld);
            // 
            // edtKontoZahlung
            // 
            this.edtKontoZahlung.DataMember = "Konto";
            this.edtKontoZahlung.DataSource = this.qryZahlungseingang;
            this.edtKontoZahlung.Location = new System.Drawing.Point(85, 66);
            this.edtKontoZahlung.Name = "edtKontoZahlung";
            this.edtKontoZahlung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoZahlung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoZahlung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoZahlung.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoZahlung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoZahlung.Properties.Appearance.Options.UseFont = true;
            this.edtKontoZahlung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtKontoZahlung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtKontoZahlung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoZahlung.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKontoZahlung.Size = new System.Drawing.Size(297, 24);
            this.edtKontoZahlung.TabIndex = 2;
            this.edtKontoZahlung.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKontoZahlung_UserModifiedFld);
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryZahlungseingang;
            this.edtBetrag.Location = new System.Drawing.Point(85, 35);
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
            this.edtBetrag.Properties.Mask.EditMask = "N2";
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 1;
            // 
            // lblDatum
            // 
            this.lblDatum.Location = new System.Drawing.Point(5, 5);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(44, 24);
            this.lblDatum.TabIndex = 0;
            this.lblDatum.Text = "Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            // 
            // edtDatum
            // 
            this.edtDatum.DataMember = "Datum";
            this.edtDatum.DataSource = this.qryZahlungseingang;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(85, 5);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(100, 24);
            this.edtDatum.TabIndex = 0;
            // 
            // grdZahlungsingang
            // 
            this.grdZahlungsingang.DataSource = this.qryZahlungseingang;
            this.grdZahlungsingang.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdZahlungsingang.EmbeddedNavigator.Name = "";
            this.grdZahlungsingang.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdZahlungsingang.Location = new System.Drawing.Point(0, 0);
            this.grdZahlungsingang.MainView = this.grvZahlungseingang;
            this.grdZahlungsingang.Name = "grdZahlungsingang";
            this.grdZahlungsingang.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdZahlungsingang.Size = new System.Drawing.Size(811, 226);
            this.grdZahlungsingang.TabIndex = 0;
            this.grdZahlungsingang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZahlungseingang});
            // 
            // grvZahlungseingang
            // 
            this.grvZahlungseingang.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZahlungseingang.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.Empty.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.Empty.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvZahlungseingang.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.EvenRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZahlungseingang.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvZahlungseingang.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZahlungseingang.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
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
            this.grvZahlungseingang.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZahlungseingang.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.OddRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZahlungseingang.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.Row.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.Row.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvZahlungseingang.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahlungseingang.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvZahlungseingang.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvZahlungseingang.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZahlungseingang.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvZahlungseingang.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvZahlungseingang.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZahlungseingang.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZahlungseingang.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum2,
            this.colBetrag,
            this.colKonto,
            this.colDebitor,
            this.colKlient,
            this.colZuteilungSAR,
            this.colBelegNr,
            this.colAusgeglichen,
            this.colVerbucht,
            this.colEingangSelektiert});
            this.grvZahlungseingang.GridControl = this.grdZahlungsingang;
            this.grvZahlungseingang.Name = "grvZahlungseingang";
            this.grvZahlungseingang.OptionsCustomization.AllowFilter = false;
            this.grvZahlungseingang.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZahlungseingang.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZahlungseingang.OptionsSelection.UseIndicatorForSelection = false;
            this.grvZahlungseingang.OptionsView.ColumnAutoWidth = false;
            this.grvZahlungseingang.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZahlungseingang.OptionsView.ShowFooter = true;
            this.grvZahlungseingang.OptionsView.ShowGroupPanel = false;
            // 
            // colDatum2
            // 
            this.colDatum2.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDatum2.AppearanceCell.Options.UseBackColor = true;
            this.colDatum2.Caption = "Beleg Datum";
            this.colDatum2.FieldName = "Datum";
            this.colDatum2.Name = "colDatum2";
            this.colDatum2.OptionsColumn.AllowEdit = false;
            this.colDatum2.OptionsColumn.AllowFocus = false;
            this.colDatum2.OptionsColumn.ReadOnly = true;
            this.colDatum2.Visible = true;
            this.colDatum2.VisibleIndex = 0;
            this.colDatum2.Width = 79;
            // 
            // colBetrag
            // 
            this.colBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.OptionsColumn.AllowFocus = false;
            this.colBetrag.OptionsColumn.ReadOnly = true;
            this.colBetrag.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetrag.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 1;
            this.colBetrag.Width = 80;
            // 
            // colKonto
            // 
            this.colKonto.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKonto.AppearanceCell.Options.UseBackColor = true;
            this.colKonto.Caption = "Eingangskonto";
            this.colKonto.FieldName = "Konto";
            this.colKonto.Name = "colKonto";
            this.colKonto.OptionsColumn.AllowEdit = false;
            this.colKonto.OptionsColumn.AllowFocus = false;
            this.colKonto.OptionsColumn.ReadOnly = true;
            this.colKonto.Visible = true;
            this.colKonto.VisibleIndex = 2;
            this.colKonto.Width = 128;
            // 
            // colDebitor
            // 
            this.colDebitor.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colDebitor.AppearanceCell.Options.UseBackColor = true;
            this.colDebitor.Caption = "Debitor";
            this.colDebitor.FieldName = "Debitor";
            this.colDebitor.Name = "colDebitor";
            this.colDebitor.OptionsColumn.AllowEdit = false;
            this.colDebitor.OptionsColumn.AllowFocus = false;
            this.colDebitor.OptionsColumn.ReadOnly = true;
            this.colDebitor.Visible = true;
            this.colDebitor.VisibleIndex = 3;
            this.colDebitor.Width = 191;
            // 
            // colKlient
            // 
            this.colKlient.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colKlient.AppearanceCell.Options.UseBackColor = true;
            this.colKlient.Caption = "Klient";
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.OptionsColumn.AllowFocus = false;
            this.colKlient.OptionsColumn.ReadOnly = true;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 4;
            this.colKlient.Width = 217;
            // 
            // colBelegNr
            // 
            this.colBelegNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBelegNr.AppearanceCell.Options.UseBackColor = true;
            this.colBelegNr.Caption = "Beleg-Nr.";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.OptionsColumn.AllowEdit = false;
            this.colBelegNr.OptionsColumn.AllowFocus = false;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 6;
            // 
            // colAusgeglichen
            // 
            this.colAusgeglichen.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colAusgeglichen.AppearanceCell.Options.UseBackColor = true;
            this.colAusgeglichen.Caption = "ausg.";
            this.colAusgeglichen.FieldName = "Beglichen";
            this.colAusgeglichen.Name = "colAusgeglichen";
            this.colAusgeglichen.OptionsColumn.AllowEdit = false;
            this.colAusgeglichen.OptionsColumn.AllowFocus = false;
            this.colAusgeglichen.OptionsColumn.ReadOnly = true;
            this.colAusgeglichen.Visible = true;
            this.colAusgeglichen.VisibleIndex = 7;
            this.colAusgeglichen.Width = 41;
            // 
            // colVerbucht
            // 
            this.colVerbucht.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colVerbucht.AppearanceCell.Options.UseBackColor = true;
            this.colVerbucht.Caption = "Verb.";
            this.colVerbucht.FieldName = "AusgleichVerbucht";
            this.colVerbucht.Name = "colVerbucht";
            this.colVerbucht.OptionsColumn.AllowEdit = false;
            this.colVerbucht.OptionsColumn.AllowFocus = false;
            this.colVerbucht.OptionsColumn.ReadOnly = true;
            this.colVerbucht.Visible = true;
            this.colVerbucht.VisibleIndex = 8;
            // 
            // colEingangSelektiert
            // 
            this.colEingangSelektiert.Caption = "sel.";
            this.colEingangSelektiert.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colEingangSelektiert.FieldName = "selektiert";
            this.colEingangSelektiert.Name = "colEingangSelektiert";
            this.colEingangSelektiert.Visible = true;
            this.colEingangSelektiert.VisibleIndex = 9;
            this.colEingangSelektiert.Width = 40;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.Click += new System.EventHandler(this.repositoryItemCheckEdit1_Click);
            // 
            // edtDatumVonX
            // 
            this.edtDatumVonX.EditValue = null;
            this.edtDatumVonX.Location = new System.Drawing.Point(92, 42);
            this.edtDatumVonX.Name = "edtDatumVonX";
            this.edtDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVonX.Properties.ShowToday = false;
            this.edtDatumVonX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVonX.TabIndex = 0;
            // 
            // edtDatumBisX
            // 
            this.edtDatumBisX.EditValue = null;
            this.edtDatumBisX.Location = new System.Drawing.Point(225, 42);
            this.edtDatumBisX.Name = "edtDatumBisX";
            this.edtDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBisX.Properties.ShowToday = false;
            this.edtDatumBisX.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBisX.TabIndex = 1;
            // 
            // edtBaInstitutionIDX
            // 
            this.edtBaInstitutionIDX.Location = new System.Drawing.Point(92, 72);
            this.edtBaInstitutionIDX.Name = "edtBaInstitutionIDX";
            this.edtBaInstitutionIDX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaInstitutionIDX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaInstitutionIDX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaInstitutionIDX.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaInstitutionIDX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaInstitutionIDX.Properties.Appearance.Options.UseFont = true;
            this.edtBaInstitutionIDX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtBaInstitutionIDX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtBaInstitutionIDX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaInstitutionIDX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtBaInstitutionIDX.Size = new System.Drawing.Size(318, 24);
            this.edtBaInstitutionIDX.TabIndex = 3;
            this.edtBaInstitutionIDX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaInstitutionIDX_UserModifiedFld);
            // 
            // edtBetragVonX
            // 
            this.edtBetragVonX.Location = new System.Drawing.Point(92, 102);
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
            this.edtBetragVonX.Properties.DisplayFormat.FormatString = "N2";
            this.edtBetragVonX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragVonX.Properties.EditFormat.FormatString = "N2";
            this.edtBetragVonX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragVonX.Size = new System.Drawing.Size(100, 24);
            this.edtBetragVonX.TabIndex = 4;
            // 
            // edtBetragBisX
            // 
            this.edtBetragBisX.Location = new System.Drawing.Point(225, 102);
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
            this.edtBetragBisX.Properties.DisplayFormat.FormatString = "N2";
            this.edtBetragBisX.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragBisX.Properties.EditFormat.FormatString = "N2";
            this.edtBetragBisX.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragBisX.Size = new System.Drawing.Size(100, 24);
            this.edtBetragBisX.TabIndex = 5;
            // 
            // edtNurUnausgeglichenX
            // 
            this.edtNurUnausgeglichenX.EditValue = false;
            this.edtNurUnausgeglichenX.Location = new System.Drawing.Point(92, 187);
            this.edtNurUnausgeglichenX.Name = "edtNurUnausgeglichenX";
            this.edtNurUnausgeglichenX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurUnausgeglichenX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurUnausgeglichenX.Properties.Caption = "nur unausgeglichene Zahlungen";
            this.edtNurUnausgeglichenX.Size = new System.Drawing.Size(218, 19);
            this.edtNurUnausgeglichenX.TabIndex = 8;
            // 
            // lblDatumVonX
            // 
            this.lblDatumVonX.Location = new System.Drawing.Point(3, 42);
            this.lblDatumVonX.Name = "lblDatumVonX";
            this.lblDatumVonX.Size = new System.Drawing.Size(65, 24);
            this.lblDatumVonX.TabIndex = 296;
            this.lblDatumVonX.Text = "Datum von";
            this.lblDatumVonX.UseCompatibleTextRendering = true;
            // 
            // lblBetragVonX
            // 
            this.lblBetragVonX.Location = new System.Drawing.Point(3, 102);
            this.lblBetragVonX.Name = "lblBetragVonX";
            this.lblBetragVonX.Size = new System.Drawing.Size(65, 24);
            this.lblBetragVonX.TabIndex = 297;
            this.lblBetragVonX.Text = "Betrag von";
            this.lblBetragVonX.UseCompatibleTextRendering = true;
            // 
            // lblDatumBisX
            // 
            this.lblDatumBisX.Location = new System.Drawing.Point(198, 42);
            this.lblDatumBisX.Name = "lblDatumBisX";
            this.lblDatumBisX.Size = new System.Drawing.Size(21, 24);
            this.lblDatumBisX.TabIndex = 308;
            this.lblDatumBisX.Text = "bis";
            this.lblDatumBisX.UseCompatibleTextRendering = true;
            // 
            // lblBetragBisX
            // 
            this.lblBetragBisX.Location = new System.Drawing.Point(198, 102);
            this.lblBetragBisX.Name = "lblBetragBisX";
            this.lblBetragBisX.Size = new System.Drawing.Size(21, 24);
            this.lblBetragBisX.TabIndex = 310;
            this.lblBetragBisX.Text = "bis";
            this.lblBetragBisX.UseCompatibleTextRendering = true;
            // 
            // lblDebitorX
            // 
            this.lblDebitorX.Location = new System.Drawing.Point(3, 72);
            this.lblDebitorX.Name = "lblDebitorX";
            this.lblDebitorX.Size = new System.Drawing.Size(52, 24);
            this.lblDebitorX.TabIndex = 313;
            this.lblDebitorX.Text = "Debitor";
            this.lblDebitorX.UseCompatibleTextRendering = true;
            // 
            // lblKontoVonX
            // 
            this.lblKontoVonX.Location = new System.Drawing.Point(3, 132);
            this.lblKontoVonX.Name = "lblKontoVonX";
            this.lblKontoVonX.Size = new System.Drawing.Size(83, 24);
            this.lblKontoVonX.TabIndex = 316;
            this.lblKontoVonX.Text = "Konto-Nr. von";
            this.lblKontoVonX.UseCompatibleTextRendering = true;
            // 
            // lblKontoBisX
            // 
            this.lblKontoBisX.Location = new System.Drawing.Point(198, 132);
            this.lblKontoBisX.Name = "lblKontoBisX";
            this.lblKontoBisX.Size = new System.Drawing.Size(21, 24);
            this.lblKontoBisX.TabIndex = 317;
            this.lblKontoBisX.Text = "bis";
            this.lblKontoBisX.UseCompatibleTextRendering = true;
            // 
            // edtKontoNrVonX
            // 
            this.edtKontoNrVonX.Location = new System.Drawing.Point(92, 132);
            this.edtKontoNrVonX.Name = "edtKontoNrVonX";
            this.edtKontoNrVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoNrVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoNrVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoNrVonX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoNrVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoNrVonX.Properties.Appearance.Options.UseFont = true;
            this.edtKontoNrVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtKontoNrVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtKontoNrVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoNrVonX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKontoNrVonX.Size = new System.Drawing.Size(100, 24);
            this.edtKontoNrVonX.TabIndex = 318;
            this.edtKontoNrVonX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKontoNrVonX_UserModifiedFld);
            // 
            // edtKontoNrBisX
            // 
            this.edtKontoNrBisX.Location = new System.Drawing.Point(225, 132);
            this.edtKontoNrBisX.Name = "edtKontoNrBisX";
            this.edtKontoNrBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoNrBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoNrBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoNrBisX.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoNrBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoNrBisX.Properties.Appearance.Options.UseFont = true;
            this.edtKontoNrBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtKontoNrBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtKontoNrBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoNrBisX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtKontoNrBisX.Size = new System.Drawing.Size(100, 24);
            this.edtKontoNrBisX.TabIndex = 319;
            this.edtKontoNrBisX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKontoNrBisX_UserModifiedFld);
            // 
            // btnSelektieren
            // 
            this.btnSelektieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelektieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelektieren.Location = new System.Drawing.Point(544, 270);
            this.btnSelektieren.Name = "btnSelektieren";
            this.btnSelektieren.Size = new System.Drawing.Size(135, 24);
            this.btnSelektieren.TabIndex = 299;
            this.btnSelektieren.Text = "Alle selektieren";
            this.btnSelektieren.UseCompatibleTextRendering = true;
            this.btnSelektieren.UseVisualStyleBackColor = false;
            this.btnSelektieren.Click += new System.EventHandler(this.btnSelektieren_Click);
            // 
            // btnVerbuchen
            // 
            this.btnVerbuchen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerbuchen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerbuchen.Location = new System.Drawing.Point(685, 270);
            this.btnVerbuchen.Name = "btnVerbuchen";
            this.btnVerbuchen.Size = new System.Drawing.Size(135, 24);
            this.btnVerbuchen.TabIndex = 300;
            this.btnVerbuchen.Text = "Selektierte verbuchen";
            this.btnVerbuchen.UseCompatibleTextRendering = true;
            this.btnVerbuchen.UseVisualStyleBackColor = false;
            this.btnVerbuchen.Click += new System.EventHandler(this.btnVerbuchen_Click);
            // 
            // edtNurUnverbuchtX
            // 
            this.edtNurUnverbuchtX.EditValue = true;
            this.edtNurUnverbuchtX.Location = new System.Drawing.Point(92, 162);
            this.edtNurUnverbuchtX.Name = "edtNurUnverbuchtX";
            this.edtNurUnverbuchtX.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtNurUnverbuchtX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurUnverbuchtX.Properties.Caption = "nur unverbuchte Zahlungen";
            this.edtNurUnverbuchtX.Size = new System.Drawing.Size(218, 19);
            this.edtNurUnverbuchtX.TabIndex = 320;
            // 
            // colZuteilungSAR
            // 
            this.colZuteilungSAR.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colZuteilungSAR.AppearanceCell.Options.UseBackColor = true;
            this.colZuteilungSAR.Caption = "Zuteilung SAR";
            this.colZuteilungSAR.FieldName = "SAR";
            this.colZuteilungSAR.Name = "colZuteilungSAR";
            this.colZuteilungSAR.OptionsColumn.AllowEdit = false;
            this.colZuteilungSAR.OptionsColumn.AllowFocus = false;
            this.colZuteilungSAR.OptionsColumn.ReadOnly = true;
            this.colZuteilungSAR.Visible = true;
            this.colZuteilungSAR.VisibleIndex = 5;
            this.colZuteilungSAR.Width = 217;
            // 
            // CtlKbZahlungseingang
            // 
            this.ActiveSQLQuery = this.qryZahlungseingang;
            this.Controls.Add(this.btnVerbuchen);
            this.Controls.Add(this.btnSelektieren);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabDetails);
            this.Location = new System.Drawing.Point(0, 270);
            this.Name = "CtlKbZahlungseingang";
            this.Size = new System.Drawing.Size(825, 596);
            this.Load += new System.EventHandler(this.CtlKbZahlungseingang_Load);
            this.Controls.SetChildIndex(this.tabDetails, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.btnSelektieren, 0);
            this.Controls.SetChildIndex(this.btnVerbuchen, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            this.tabDetails.ResumeLayout(false);
            this.tpgAusgleich.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgleichBeleg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgleichKbBuchungID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAusgleich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgleichText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgleichDebitor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAusgleichRestbetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRestbetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgleichDebitor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAusgleichText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAusgleich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvAusgleich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAusgleichen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            this.tpgZahlung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblZugeteiltUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoZahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungseingang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMitteilung1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZugeteiltUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKlient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDebitor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInstitution.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoZahlung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdZahlungsingang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahlungseingang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaInstitutionIDX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurUnausgeglichenX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDebitorX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoVonX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKontoBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNrVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNrBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurUnverbuchtX.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KiSS4.Gui.KissButton btnAusgleichAufheben;
        private KiSS4.Gui.KissButton btnAusgleichSpeichern;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btnAusgleichen;
        private KiSS4.Gui.KissButton btnSelektieren;
        private KiSS4.Gui.KissButton btnVerbuchen;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgeglichen;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgleich;
        private DevExpress.XtraGrid.Columns.GridColumn colAusgleichBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBudgetMonatJahr;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum2;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitor;
        private DevExpress.XtraGrid.Columns.GridColumn colDebitor3;
        private DevExpress.XtraGrid.Columns.GridColumn colEingangSelektiert;
        private DevExpress.XtraGrid.Columns.GridColumn colHaben;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenstelle;
        private DevExpress.XtraGrid.Columns.GridColumn colRestbetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalbetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colVerbucht;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissTextEdit edtAusgleichDebitor;
        private KiSS4.Gui.KissTextEdit edtAusgleichKbBuchungID;
        private KiSS4.Gui.KissTextEdit edtAusgleichText;
        private KiSS4.Gui.KissButtonEdit edtBaInstitutionIDX;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissCalcEdit edtBetragBisX;
        private KiSS4.Gui.KissCalcEdit edtBetragVonX;
        private KiSS4.Gui.KissDateEdit edtDatum;
        private KiSS4.Gui.KissDateEdit edtDatumBisX;
        private KiSS4.Gui.KissDateEdit edtDatumVonX;
        private KiSS4.Gui.KissTextEdit edtDebitor;
        private KiSS4.Gui.KissButtonEdit edtInstitution;
        private KiSS4.Gui.KissButtonEdit edtKlient;
        private KiSS4.Gui.KissButtonEdit edtKontoNrBisX;
        private KiSS4.Gui.KissButtonEdit edtKontoNrVonX;
        private KiSS4.Gui.KissButtonEdit edtKontoZahlung;
        private KiSS4.Gui.KissTextEdit edtMitteilung1;
        private KiSS4.Gui.KissTextEdit edtMitteilung2;
        private KiSS4.Gui.KissTextEdit edtMitteilung3;
        private KiSS4.Gui.KissTextEdit edtMitteilung4;
        private KiSS4.Gui.KissCheckEdit edtNurUnausgeglichenX;
        private KiSS4.Gui.KissCheckEdit edtNurUnverbuchtX;
        private KiSS4.Gui.KissCalcEdit edtRestbetrag;
        private KiSS4.Gui.KissButtonEdit edtZugeteiltUserID;
        private KiSS4.Gui.KissGrid grdAusgleich;
        private KiSS4.Gui.KissGrid grdZahlungsingang;
        private DevExpress.XtraGrid.Views.Grid.GridView grvAusgleich;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZahlungseingang;
        private KiSS4.Gui.KissLabel kissLabel16;
        private KiSS4.Gui.KissLabel kissLabel17;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel lblAusgleichBeleg;
        private KiSS4.Gui.KissLabel lblAusgleichDebitor;
        private KiSS4.Gui.KissLabel lblAusgleichRestbetrag;
        private KiSS4.Gui.KissLabel lblAusgleichText;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBetragBisX;
        private KiSS4.Gui.KissLabel lblBetragVonX;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblDatumBisX;
        private KiSS4.Gui.KissLabel lblDatumVonX;
        private KiSS4.Gui.KissLabel lblDebitorX;
        private KiSS4.Gui.KissLabel lblKontoBisX;
        private KiSS4.Gui.KissLabel lblKontoVonX;
        private KiSS4.Gui.KissLabel lblKontoZahlung;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblZugeteiltUserID;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryAusgleich;
        private KiSS4.DB.SqlQuery qryZahlungseingang;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private KiSS4.Gui.KissTabControlEx tabDetails;
        private SharpLibrary.WinControls.TabPageEx tpgAusgleich;
        private SharpLibrary.WinControls.TabPageEx tpgZahlung;
        private DevExpress.XtraGrid.Columns.GridColumn colZuteilungSAR;
    }
}