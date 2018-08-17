namespace KiSS4.Klientenbuchhaltung
{
    public partial class CtlKbTransfer
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnBezahlt;
        private KiSS4.Gui.KissButton btnFehlerhaft;
        private KiSS4.Gui.KissButton btnUebermittelteAuswaehlen;
        private KiSS4.Gui.KissButton btnUebermittelteEntfernen;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungAufwandPeriode;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungAusgleichBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungAusgleichPeriode;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungAuswahl;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungBegünstigter;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungBelegNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungBezahltAm;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungKontoNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungValuta;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungZahlungsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalBezahlt;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalFehlerhaft;
        private DevExpress.XtraGrid.Columns.GridColumn colTransfer;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferErsteller;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferFaelligkeitDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferKontoNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferTotalBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colTransferZugang;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissTextEdit editBelegNrX;
        private KiSS4.Gui.KissCalcEdit editBetragX;
        private KiSS4.Gui.KissLookUpEdit editEZugangX;
        private KiSS4.Gui.KissLookUpEdit editStatusX;
        private KiSS4.Gui.KissCalcEdit editTotalBetragBisX;
        private KiSS4.Gui.KissCalcEdit editTotalBetragVonX;
        private KiSS4.Gui.KissDateEdit editTransferDatumBisX;
        private KiSS4.Gui.KissDateEdit editTransferDatumVonX;
        private KiSS4.Gui.KissCalcEdit edtAnzahl;
        private KiSS4.Gui.KissDateEdit edtBelegdatum;
        private KiSS4.Gui.KissButtonEdit edtErfasserX;
        private KiSS4.Gui.KissCheckEdit edtNurPendenteX;
        private KiSS4.Gui.KissCalcEdit edtTotal;
        private KiSS4.Gui.KissGrid grdKbBuchung;
        private KiSS4.Gui.KissGrid grdKbZahlungslauf;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbZahlungslauf;
        private KiSS4.Gui.KissSearchTitel kissSearchTitel1;
        private KiSS4.Gui.KissLabel lblAnzahlBelege;
        private KiSS4.Gui.KissLabel lblBelegNrX;
        private KiSS4.Gui.KissLabel lblBelegdatum;
        private KiSS4.Gui.KissLabel lblBetragX;
        private KiSS4.Gui.KissLabel lblBetragstotal;
        private KiSS4.Gui.KissLabel lblBuchungX;
        private KiSS4.Gui.KissLabel lblBuchungen;
        private KiSS4.Gui.KissLabel lblCHF;
        private KiSS4.Gui.KissLabel lblDatei;
        private KiSS4.Gui.KissLabel lblEZugangX;
        private KiSS4.Gui.KissLabel lblErfasserX;
        private KiSS4.Gui.KissLabel lblFilePath;
        private KiSS4.Gui.KissLabel lblID;
        private KiSS4.Gui.KissLabel lblKbZahlungslaufID;
        private KiSS4.Gui.KissLabel lblStatusX;
        private KiSS4.Gui.KissLabel lblTotalBetragBisX;
        private KiSS4.Gui.KissLabel lblTotalBetragX;
        private KiSS4.Gui.KissLabel lblTransferDatumX;
        private KiSS4.Gui.KissLabel lblTransferDatumXBis;
        private KiSS4.Gui.KissLabel lblZahlungsauftragX;
        private KiSS4.Gui.KissLabel lblZahlungsläufe;
        private System.Windows.Forms.Panel panel3;
        private KiSS4.DB.SqlQuery qryAktivKonto;
        private KiSS4.DB.SqlQuery qryBuchung;
        private KiSS4.DB.SqlQuery qryZahlungskonto;
        private KiSS4.DB.SqlQuery qryZahlungslauf;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbTransfer));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblID = new KiSS4.Gui.KissLabel();
            this.lblKbZahlungslaufID = new KiSS4.Gui.KissLabel();
            this.qryZahlungslauf = new KiSS4.DB.SqlQuery();
            this.edtTotal = new KiSS4.Gui.KissCalcEdit();
            this.lblCHF = new KiSS4.Gui.KissLabel();
            this.lblBetragstotal = new KiSS4.Gui.KissLabel();
            this.lblAnzahlBelege = new KiSS4.Gui.KissLabel();
            this.edtAnzahl = new KiSS4.Gui.KissCalcEdit();
            this.lblBelegdatum = new KiSS4.Gui.KissLabel();
            this.edtBelegdatum = new KiSS4.Gui.KissDateEdit();
            this.lblFilePath = new KiSS4.Gui.KissLabel();
            this.lblDatei = new KiSS4.Gui.KissLabel();
            this.lblBuchungen = new KiSS4.Gui.KissLabel();
            this.lblZahlungsläufe = new KiSS4.Gui.KissLabel();
            this.btnFehlerhaft = new KiSS4.Gui.KissButton();
            this.btnBezahlt = new KiSS4.Gui.KissButton();
            this.btnUebermittelteEntfernen = new KiSS4.Gui.KissButton();
            this.btnUebermittelteAuswaehlen = new KiSS4.Gui.KissButton();
            this.grdKbBuchung = new KiSS4.Gui.KissGrid();
            this.qryBuchung = new KiSS4.DB.SqlQuery();
            this.grvKbBuchung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBuchungKontoNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungBelegNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungAufwandPeriode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungBegünstigter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungZahlungsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBuchungBezahltAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungAusgleichBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungAusgleichPeriode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungAuswahl = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grdKbZahlungslauf = new KiSS4.Gui.KissGrid();
            this.grvKbZahlungslauf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTransferZugang = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransfer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferErsteller = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferFaelligkeitDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferTotalBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferKontoNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTransferStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalFehlerhaft = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalBezahlt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.editEZugangX = new KiSS4.Gui.KissLookUpEdit();
            this.editTransferDatumVonX = new KiSS4.Gui.KissDateEdit();
            this.editTransferDatumBisX = new KiSS4.Gui.KissDateEdit();
            this.editBelegNrX = new KiSS4.Gui.KissTextEdit();
            this.editBetragX = new KiSS4.Gui.KissCalcEdit();
            this.editStatusX = new KiSS4.Gui.KissLookUpEdit();
            this.lblZahlungsauftragX = new KiSS4.Gui.KissLabel();
            this.lblTotalBetragX = new KiSS4.Gui.KissLabel();
            this.lblTransferDatumX = new KiSS4.Gui.KissLabel();
            this.lblBuchungX = new KiSS4.Gui.KissLabel();
            this.lblTransferDatumXBis = new KiSS4.Gui.KissLabel();
            this.lblTotalBetragBisX = new KiSS4.Gui.KissLabel();
            this.lblEZugangX = new KiSS4.Gui.KissLabel();
            this.lblBetragX = new KiSS4.Gui.KissLabel();
            this.lblStatusX = new KiSS4.Gui.KissLabel();
            this.lblBelegNrX = new KiSS4.Gui.KissLabel();
            this.lblErfasserX = new KiSS4.Gui.KissLabel();
            this.kissSearchTitel1 = new KiSS4.Gui.KissSearchTitel();
            this.editTotalBetragBisX = new KiSS4.Gui.KissCalcEdit();
            this.editTotalBetragVonX = new KiSS4.Gui.KissCalcEdit();
            this.edtErfasserX = new KiSS4.Gui.KissButtonEdit();
            this.edtNurPendenteX = new KiSS4.Gui.KissCheckEdit();
            this.qryAktivKonto = new KiSS4.DB.SqlQuery();
            this.qryZahlungskonto = new KiSS4.DB.SqlQuery();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbZahlungslaufID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungslauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragstotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlBelege)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilePath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatei)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsläufe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbZahlungslauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbZahlungslauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editEZugangX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editEZugangX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTransferDatumVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTransferDatumBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBelegNrX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBetragX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsauftragX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalBetragX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferDatumX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferDatumXBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalBetragBisX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEZugangX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNrX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasserX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTotalBetragBisX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTotalBetragVonX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfasserX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurPendenteX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAktivKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungskonto)).BeginInit();
            this.SuspendLayout();
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(806, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(830, 545);
            this.tabControlSearch.TabIndex = 18;
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.panel3);
            this.tpgListe.Size = new System.Drawing.Size(818, 507);
            this.tpgListe.Title = "Liste";
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNurPendenteX);
            this.tpgSuchen.Controls.Add(this.edtErfasserX);
            this.tpgSuchen.Controls.Add(this.editTotalBetragVonX);
            this.tpgSuchen.Controls.Add(this.editTotalBetragBisX);
            this.tpgSuchen.Controls.Add(this.kissSearchTitel1);
            this.tpgSuchen.Controls.Add(this.lblErfasserX);
            this.tpgSuchen.Controls.Add(this.lblBelegNrX);
            this.tpgSuchen.Controls.Add(this.lblStatusX);
            this.tpgSuchen.Controls.Add(this.lblBetragX);
            this.tpgSuchen.Controls.Add(this.lblEZugangX);
            this.tpgSuchen.Controls.Add(this.lblTotalBetragBisX);
            this.tpgSuchen.Controls.Add(this.lblTransferDatumXBis);
            this.tpgSuchen.Controls.Add(this.lblBuchungX);
            this.tpgSuchen.Controls.Add(this.lblTransferDatumX);
            this.tpgSuchen.Controls.Add(this.lblTotalBetragX);
            this.tpgSuchen.Controls.Add(this.lblZahlungsauftragX);
            this.tpgSuchen.Controls.Add(this.editStatusX);
            this.tpgSuchen.Controls.Add(this.editBetragX);
            this.tpgSuchen.Controls.Add(this.editBelegNrX);
            this.tpgSuchen.Controls.Add(this.editTransferDatumBisX);
            this.tpgSuchen.Controls.Add(this.editTransferDatumVonX);
            this.tpgSuchen.Controls.Add(this.editEZugangX);
            this.tpgSuchen.Size = new System.Drawing.Size(818, 507);
            this.tpgSuchen.Title = "Suchen";
            this.tpgSuchen.Controls.SetChildIndex(this.editEZugangX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.editTransferDatumVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.editTransferDatumBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.editBelegNrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.editBetragX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.editStatusX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZahlungsauftragX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTotalBetragX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTransferDatumX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBuchungX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTransferDatumXBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblTotalBetragBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblEZugangX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBetragX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatusX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBelegNrX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblErfasserX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissSearchTitel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.editTotalBetragBisX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.editTotalBetragVonX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtErfasserX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurPendenteX, 0);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblID);
            this.panel3.Controls.Add(this.lblKbZahlungslaufID);
            this.panel3.Controls.Add(this.edtTotal);
            this.panel3.Controls.Add(this.lblCHF);
            this.panel3.Controls.Add(this.lblBetragstotal);
            this.panel3.Controls.Add(this.lblAnzahlBelege);
            this.panel3.Controls.Add(this.edtAnzahl);
            this.panel3.Controls.Add(this.lblBelegdatum);
            this.panel3.Controls.Add(this.edtBelegdatum);
            this.panel3.Controls.Add(this.lblFilePath);
            this.panel3.Controls.Add(this.lblDatei);
            this.panel3.Controls.Add(this.lblBuchungen);
            this.panel3.Controls.Add(this.lblZahlungsläufe);
            this.panel3.Controls.Add(this.btnFehlerhaft);
            this.panel3.Controls.Add(this.btnBezahlt);
            this.panel3.Controls.Add(this.btnUebermittelteEntfernen);
            this.panel3.Controls.Add(this.btnUebermittelteAuswaehlen);
            this.panel3.Controls.Add(this.grdKbBuchung);
            this.panel3.Controls.Add(this.grdKbZahlungslauf);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(818, 507);
            this.panel3.TabIndex = 21;
            // 
            // lblID
            // 
            this.lblID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblID.Location = new System.Drawing.Point(642, 0);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(91, 24);
            this.lblID.TabIndex = 302;
            this.lblID.Text = "Zahlungslauf-ID:";
            this.lblID.UseCompatibleTextRendering = true;
            // 
            // lblKbZahlungslaufID
            // 
            this.lblKbZahlungslaufID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKbZahlungslaufID.DataMember = "KbZahlungslaufID";
            this.lblKbZahlungslaufID.DataSource = this.qryZahlungslauf;
            this.lblKbZahlungslaufID.Location = new System.Drawing.Point(733, 0);
            this.lblKbZahlungslaufID.Name = "lblKbZahlungslaufID";
            this.lblKbZahlungslaufID.Size = new System.Drawing.Size(78, 24);
            this.lblKbZahlungslaufID.TabIndex = 301;
            this.lblKbZahlungslaufID.UseCompatibleTextRendering = true;
            // 
            // qryZahlungslauf
            // 
            this.qryZahlungslauf.HostControl = this;
            this.qryZahlungslauf.IsIdentityInsert = false;
            this.qryZahlungslauf.SelectStatement = resources.GetString("qryZahlungslauf.SelectStatement");
            this.qryZahlungslauf.TableName = "KbZahlungslauf";
            this.qryZahlungslauf.PositionChanged += new System.EventHandler(this.qryZahlungslauf_PositionChanged);
            // 
            // edtTotal
            // 
            this.edtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtTotal.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotal.Location = new System.Drawing.Point(671, 216);
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
            this.edtTotal.TabIndex = 300;
            // 
            // lblCHF
            // 
            this.lblCHF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCHF.Location = new System.Drawing.Point(776, 216);
            this.lblCHF.Name = "lblCHF";
            this.lblCHF.Size = new System.Drawing.Size(28, 24);
            this.lblCHF.TabIndex = 299;
            this.lblCHF.Text = "CHF";
            this.lblCHF.UseCompatibleTextRendering = true;
            // 
            // lblBetragstotal
            // 
            this.lblBetragstotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBetragstotal.Location = new System.Drawing.Point(598, 216);
            this.lblBetragstotal.Name = "lblBetragstotal";
            this.lblBetragstotal.Size = new System.Drawing.Size(68, 24);
            this.lblBetragstotal.TabIndex = 298;
            this.lblBetragstotal.Text = "Betragstotal";
            this.lblBetragstotal.UseCompatibleTextRendering = true;
            // 
            // lblAnzahlBelege
            // 
            this.lblAnzahlBelege.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzahlBelege.Location = new System.Drawing.Point(438, 216);
            this.lblAnzahlBelege.Name = "lblAnzahlBelege";
            this.lblAnzahlBelege.Size = new System.Drawing.Size(75, 24);
            this.lblAnzahlBelege.TabIndex = 297;
            this.lblAnzahlBelege.Text = "Anzahl Belege";
            this.lblAnzahlBelege.UseCompatibleTextRendering = true;
            // 
            // edtAnzahl
            // 
            this.edtAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAnzahl.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahl.Location = new System.Drawing.Point(519, 216);
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
            this.edtAnzahl.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahl.Properties.ReadOnly = true;
            this.edtAnzahl.Size = new System.Drawing.Size(73, 24);
            this.edtAnzahl.TabIndex = 296;
            // 
            // lblBelegdatum
            // 
            this.lblBelegdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegdatum.Location = new System.Drawing.Point(384, 479);
            this.lblBelegdatum.Name = "lblBelegdatum";
            this.lblBelegdatum.Size = new System.Drawing.Size(71, 24);
            this.lblBelegdatum.TabIndex = 31;
            this.lblBelegdatum.Text = "Bezahlt am";
            this.lblBelegdatum.UseCompatibleTextRendering = true;
            // 
            // edtBelegdatum
            // 
            this.edtBelegdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBelegdatum.EditValue = null;
            this.edtBelegdatum.Location = new System.Drawing.Point(461, 479);
            this.edtBelegdatum.Name = "edtBelegdatum";
            this.edtBelegdatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBelegdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegdatum.Properties.Appearance.Options.UseFont = true;
            this.edtBelegdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtBelegdatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBelegdatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtBelegdatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegdatum.Properties.ShowToday = false;
            this.edtBelegdatum.Size = new System.Drawing.Size(100, 24);
            this.edtBelegdatum.TabIndex = 30;
            // 
            // lblFilePath
            // 
            this.lblFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilePath.DataMember = "FilePath";
            this.lblFilePath.DataSource = this.qryZahlungslauf;
            this.lblFilePath.Location = new System.Drawing.Point(171, 200);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(333, 24);
            this.lblFilePath.TabIndex = 29;
            this.lblFilePath.UseCompatibleTextRendering = true;
            // 
            // lblDatei
            // 
            this.lblDatei.Location = new System.Drawing.Point(125, 200);
            this.lblDatei.Name = "lblDatei";
            this.lblDatei.Size = new System.Drawing.Size(46, 24);
            this.lblDatei.TabIndex = 28;
            this.lblDatei.Text = "Datei";
            this.lblDatei.UseCompatibleTextRendering = true;
            // 
            // lblBuchungen
            // 
            this.lblBuchungen.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblBuchungen.Location = new System.Drawing.Point(15, 224);
            this.lblBuchungen.Name = "lblBuchungen";
            this.lblBuchungen.Size = new System.Drawing.Size(84, 16);
            this.lblBuchungen.TabIndex = 27;
            this.lblBuchungen.Text = "Buchungen";
            this.lblBuchungen.UseCompatibleTextRendering = true;
            // 
            // lblZahlungsläufe
            // 
            this.lblZahlungsläufe.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblZahlungsläufe.Location = new System.Drawing.Point(5, 4);
            this.lblZahlungsläufe.Name = "lblZahlungsläufe";
            this.lblZahlungsläufe.Size = new System.Drawing.Size(219, 16);
            this.lblZahlungsläufe.TabIndex = 26;
            this.lblZahlungsläufe.Text = "Übermittelte Zahlungsläufe";
            this.lblZahlungsläufe.UseCompatibleTextRendering = true;
            // 
            // btnFehlerhaft
            // 
            this.btnFehlerhaft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFehlerhaft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFehlerhaft.Location = new System.Drawing.Point(700, 479);
            this.btnFehlerhaft.Name = "btnFehlerhaft";
            this.btnFehlerhaft.Size = new System.Drawing.Size(110, 24);
            this.btnFehlerhaft.TabIndex = 5;
            this.btnFehlerhaft.Text = "Fehlerhaft";
            this.btnFehlerhaft.UseCompatibleTextRendering = true;
            this.btnFehlerhaft.UseVisualStyleBackColor = false;
            this.btnFehlerhaft.Click += new System.EventHandler(this.btnFehlerhaft_Click);
            // 
            // btnBezahlt
            // 
            this.btnBezahlt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBezahlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBezahlt.Location = new System.Drawing.Point(567, 479);
            this.btnBezahlt.Name = "btnBezahlt";
            this.btnBezahlt.Size = new System.Drawing.Size(110, 24);
            this.btnBezahlt.TabIndex = 4;
            this.btnBezahlt.Text = "Bezahlt";
            this.btnBezahlt.UseCompatibleTextRendering = true;
            this.btnBezahlt.UseVisualStyleBackColor = false;
            this.btnBezahlt.Click += new System.EventHandler(this.btnBezahlt_Click);
            // 
            // btnUebermittelteEntfernen
            // 
            this.btnUebermittelteEntfernen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUebermittelteEntfernen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebermittelteEntfernen.Location = new System.Drawing.Point(171, 479);
            this.btnUebermittelteEntfernen.Name = "btnUebermittelteEntfernen";
            this.btnUebermittelteEntfernen.Size = new System.Drawing.Size(160, 24);
            this.btnUebermittelteEntfernen.TabIndex = 3;
            this.btnUebermittelteEntfernen.Text = "Übermittelte entfernen";
            this.btnUebermittelteEntfernen.UseCompatibleTextRendering = true;
            this.btnUebermittelteEntfernen.UseVisualStyleBackColor = false;
            this.btnUebermittelteEntfernen.Click += new System.EventHandler(this.btnUebermittelteEntfernen_Click);
            // 
            // btnUebermittelteAuswaehlen
            // 
            this.btnUebermittelteAuswaehlen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUebermittelteAuswaehlen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUebermittelteAuswaehlen.Location = new System.Drawing.Point(5, 479);
            this.btnUebermittelteAuswaehlen.Name = "btnUebermittelteAuswaehlen";
            this.btnUebermittelteAuswaehlen.Size = new System.Drawing.Size(160, 24);
            this.btnUebermittelteAuswaehlen.TabIndex = 2;
            this.btnUebermittelteAuswaehlen.Text = "Übermittelte auswählen";
            this.btnUebermittelteAuswaehlen.UseCompatibleTextRendering = true;
            this.btnUebermittelteAuswaehlen.UseVisualStyleBackColor = false;
            this.btnUebermittelteAuswaehlen.Click += new System.EventHandler(this.btnUebermittelteAuswaehlen_Click);
            // 
            // grdKbBuchung
            // 
            this.grdKbBuchung.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKbBuchung.DataSource = this.qryBuchung;
            // 
            // 
            // 
            this.grdKbBuchung.EmbeddedNavigator.Name = "";
            this.grdKbBuchung.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdKbBuchung.Location = new System.Drawing.Point(5, 248);
            this.grdKbBuchung.MainView = this.grvKbBuchung;
            this.grdKbBuchung.Name = "grdKbBuchung";
            this.grdKbBuchung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdKbBuchung.Size = new System.Drawing.Size(806, 222);
            this.grdKbBuchung.TabIndex = 1;
            this.grdKbBuchung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBuchung});
            this.grdKbBuchung.Click += new System.EventHandler(this.grdZahllauf_Click);
            // 
            // qryBuchung
            // 
            this.qryBuchung.BatchUpdate = true;
            this.qryBuchung.CanUpdate = true;
            this.qryBuchung.HostControl = this;
            this.qryBuchung.IsIdentityInsert = false;
            this.qryBuchung.SelectStatement = resources.GetString("qryBuchung.SelectStatement");
            this.qryBuchung.TableName = "KbBuchung";
            this.qryBuchung.PositionChanged += new System.EventHandler(this.qryBuchung_PositionChanged);
            // 
            // grvKbBuchung
            // 
            this.grvKbBuchung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbBuchung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.Empty.Options.UseFont = true;
            this.grvKbBuchung.Appearance.EvenRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvKbBuchung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBuchung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchung.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchung.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvKbBuchung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvKbBuchung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvKbBuchung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvKbBuchung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvKbBuchung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvKbBuchung.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvKbBuchung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbBuchung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBuchungKontoNummer,
            this.colBuchungValuta,
            this.colBuchungBetrag,
            this.colBuchungBelegNummer,
            this.colBuchungAufwandPeriode,
            this.colBuchungBegünstigter,
            this.colBuchungZahlungsgrund,
            this.colBuchungStatus,
            this.colBuchungBezahltAm,
            this.colBuchungAusgleichBelegNr,
            this.colBuchungAusgleichPeriode,
            this.colBuchungAuswahl});
            this.grvKbBuchung.GridControl = this.grdKbBuchung;
            this.grvKbBuchung.Name = "grvKbBuchung";
            this.grvKbBuchung.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchung.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvKbBuchung.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.grvKbBuchung.OptionsSelection.EnableAppearanceHideSelection = false;
            this.grvKbBuchung.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbBuchung.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchung.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvKbBuchung_CustomDrawCell);
            this.grvKbBuchung.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grvKbBuchung_ShowingEditor);
            this.grvKbBuchung.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvKbBuchung_CellValueChanging);
            // 
            // colBuchungKontoNummer
            // 
            this.colBuchungKontoNummer.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungKontoNummer.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungKontoNummer.Caption = "Kontonummer";
            this.colBuchungKontoNummer.FieldName = "KontoNr";
            this.colBuchungKontoNummer.Name = "colBuchungKontoNummer";
            this.colBuchungKontoNummer.OptionsColumn.AllowEdit = false;
            this.colBuchungKontoNummer.OptionsColumn.AllowFocus = false;
            this.colBuchungKontoNummer.Visible = true;
            this.colBuchungKontoNummer.VisibleIndex = 0;
            this.colBuchungKontoNummer.Width = 120;
            // 
            // colBuchungValuta
            // 
            this.colBuchungValuta.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungValuta.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungValuta.Caption = "Valuta";
            this.colBuchungValuta.FieldName = "ValutaDatum";
            this.colBuchungValuta.Name = "colBuchungValuta";
            this.colBuchungValuta.OptionsColumn.AllowEdit = false;
            this.colBuchungValuta.OptionsColumn.AllowFocus = false;
            this.colBuchungValuta.Visible = true;
            this.colBuchungValuta.VisibleIndex = 1;
            this.colBuchungValuta.Width = 81;
            // 
            // colBuchungBetrag
            // 
            this.colBuchungBetrag.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungBetrag.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungBetrag.Caption = "Betrag";
            this.colBuchungBetrag.DisplayFormat.FormatString = "N2";
            this.colBuchungBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBuchungBetrag.FieldName = "Betrag";
            this.colBuchungBetrag.Name = "colBuchungBetrag";
            this.colBuchungBetrag.OptionsColumn.AllowEdit = false;
            this.colBuchungBetrag.OptionsColumn.AllowFocus = false;
            this.colBuchungBetrag.Visible = true;
            this.colBuchungBetrag.VisibleIndex = 2;
            // 
            // colBuchungBelegNummer
            // 
            this.colBuchungBelegNummer.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungBelegNummer.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungBelegNummer.Caption = "Beleg-Nr.";
            this.colBuchungBelegNummer.FieldName = "BelegNr";
            this.colBuchungBelegNummer.Name = "colBuchungBelegNummer";
            this.colBuchungBelegNummer.OptionsColumn.AllowEdit = false;
            this.colBuchungBelegNummer.OptionsColumn.AllowFocus = false;
            this.colBuchungBelegNummer.Visible = true;
            this.colBuchungBelegNummer.VisibleIndex = 3;
            this.colBuchungBelegNummer.Width = 73;
            // 
            // colBuchungAufwandPeriode
            // 
            this.colBuchungAufwandPeriode.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungAufwandPeriode.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungAufwandPeriode.Caption = "Aufwand Periode";
            this.colBuchungAufwandPeriode.FieldName = "AufwandPeriode";
            this.colBuchungAufwandPeriode.Name = "colBuchungAufwandPeriode";
            this.colBuchungAufwandPeriode.OptionsColumn.AllowEdit = false;
            this.colBuchungAufwandPeriode.OptionsColumn.AllowFocus = false;
            this.colBuchungAufwandPeriode.Visible = true;
            this.colBuchungAufwandPeriode.VisibleIndex = 4;
            this.colBuchungAufwandPeriode.Width = 115;
            // 
            // colBuchungBegünstigter
            // 
            this.colBuchungBegünstigter.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungBegünstigter.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungBegünstigter.Caption = "Beguenstigter";
            this.colBuchungBegünstigter.FieldName = "Beguenstigter";
            this.colBuchungBegünstigter.Name = "colBuchungBegünstigter";
            this.colBuchungBegünstigter.OptionsColumn.AllowEdit = false;
            this.colBuchungBegünstigter.OptionsColumn.AllowFocus = false;
            this.colBuchungBegünstigter.Visible = true;
            this.colBuchungBegünstigter.VisibleIndex = 5;
            this.colBuchungBegünstigter.Width = 163;
            // 
            // colBuchungZahlungsgrund
            // 
            this.colBuchungZahlungsgrund.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungZahlungsgrund.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungZahlungsgrund.Caption = "Zahlungsgrund";
            this.colBuchungZahlungsgrund.FieldName = "Zahlungsgrund";
            this.colBuchungZahlungsgrund.Name = "colBuchungZahlungsgrund";
            this.colBuchungZahlungsgrund.OptionsColumn.AllowEdit = false;
            this.colBuchungZahlungsgrund.OptionsColumn.AllowFocus = false;
            this.colBuchungZahlungsgrund.Visible = true;
            this.colBuchungZahlungsgrund.VisibleIndex = 6;
            this.colBuchungZahlungsgrund.Width = 175;
            // 
            // colBuchungStatus
            // 
            this.colBuchungStatus.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungStatus.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungStatus.Caption = "Status";
            this.colBuchungStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colBuchungStatus.FieldName = "KbTransferStatusCode";
            this.colBuchungStatus.Name = "colBuchungStatus";
            this.colBuchungStatus.OptionsColumn.AllowEdit = false;
            this.colBuchungStatus.OptionsColumn.AllowFocus = false;
            this.colBuchungStatus.Visible = true;
            this.colBuchungStatus.VisibleIndex = 7;
            this.colBuchungStatus.Width = 85;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colBuchungBezahltAm
            // 
            this.colBuchungBezahltAm.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungBezahltAm.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungBezahltAm.Caption = "Bezahlt am";
            this.colBuchungBezahltAm.FieldName = "BezahltAm";
            this.colBuchungBezahltAm.Name = "colBuchungBezahltAm";
            this.colBuchungBezahltAm.OptionsColumn.AllowEdit = false;
            this.colBuchungBezahltAm.OptionsColumn.AllowFocus = false;
            this.colBuchungBezahltAm.Visible = true;
            this.colBuchungBezahltAm.VisibleIndex = 8;
            // 
            // colBuchungAusgleichBelegNr
            // 
            this.colBuchungAusgleichBelegNr.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungAusgleichBelegNr.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungAusgleichBelegNr.Caption = "Ausgleich Beleg-Nr.";
            this.colBuchungAusgleichBelegNr.FieldName = "AusgleichBelegNr";
            this.colBuchungAusgleichBelegNr.Name = "colBuchungAusgleichBelegNr";
            this.colBuchungAusgleichBelegNr.OptionsColumn.AllowEdit = false;
            this.colBuchungAusgleichBelegNr.OptionsColumn.AllowFocus = false;
            this.colBuchungAusgleichBelegNr.Visible = true;
            this.colBuchungAusgleichBelegNr.VisibleIndex = 9;
            // 
            // colBuchungAusgleichPeriode
            // 
            this.colBuchungAusgleichPeriode.AppearanceCell.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.colBuchungAusgleichPeriode.AppearanceCell.Options.UseBackColor = true;
            this.colBuchungAusgleichPeriode.Caption = "Ausgleich Periode";
            this.colBuchungAusgleichPeriode.FieldName = "AusgleichPeriode";
            this.colBuchungAusgleichPeriode.Name = "colBuchungAusgleichPeriode";
            this.colBuchungAusgleichPeriode.OptionsColumn.AllowEdit = false;
            this.colBuchungAusgleichPeriode.OptionsColumn.AllowFocus = false;
            this.colBuchungAusgleichPeriode.Visible = true;
            this.colBuchungAusgleichPeriode.VisibleIndex = 10;
            this.colBuchungAusgleichPeriode.Width = 115;
            // 
            // colBuchungAuswahl
            // 
            this.colBuchungAuswahl.Caption = "ausg.";
            this.colBuchungAuswahl.FieldName = "Auswaehlen";
            this.colBuchungAuswahl.Name = "colBuchungAuswahl";
            this.colBuchungAuswahl.Visible = true;
            this.colBuchungAuswahl.VisibleIndex = 11;
            // 
            // grdKbZahlungslauf
            // 
            this.grdKbZahlungslauf.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKbZahlungslauf.DataSource = this.qryZahlungslauf;
            // 
            // 
            // 
            this.grdKbZahlungslauf.EmbeddedNavigator.Name = "";
            this.grdKbZahlungslauf.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKbZahlungslauf.Location = new System.Drawing.Point(5, 24);
            this.grdKbZahlungslauf.MainView = this.grvKbZahlungslauf;
            this.grdKbZahlungslauf.Name = "grdKbZahlungslauf";
            this.grdKbZahlungslauf.Size = new System.Drawing.Size(806, 176);
            this.grdKbZahlungslauf.TabIndex = 0;
            this.grdKbZahlungslauf.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbZahlungslauf});
            // 
            // grvKbZahlungslauf
            // 
            this.grvKbZahlungslauf.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbZahlungslauf.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbZahlungslauf.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.Empty.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbZahlungslauf.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbZahlungslauf.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbZahlungslauf.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbZahlungslauf.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbZahlungslauf.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbZahlungslauf.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbZahlungslauf.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbZahlungslauf.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbZahlungslauf.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbZahlungslauf.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbZahlungslauf.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvKbZahlungslauf.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbZahlungslauf.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbZahlungslauf.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbZahlungslauf.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbZahlungslauf.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbZahlungslauf.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbZahlungslauf.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbZahlungslauf.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbZahlungslauf.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbZahlungslauf.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbZahlungslauf.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbZahlungslauf.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbZahlungslauf.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbZahlungslauf.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbZahlungslauf.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbZahlungslauf.Appearance.OddRow.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbZahlungslauf.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbZahlungslauf.Appearance.Row.Options.UseBackColor = true;
            this.grvKbZahlungslauf.Appearance.Row.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbZahlungslauf.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbZahlungslauf.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbZahlungslauf.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbZahlungslauf.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbZahlungslauf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTransferZugang,
            this.colTransfer,
            this.colTransferErsteller,
            this.colTransferFaelligkeitDatum,
            this.colTransferTotalBetrag,
            this.colTransferKontoNummer,
            this.colTransferStatus,
            this.colTotalFehlerhaft,
            this.colTotalBezahlt});
            this.grvKbZahlungslauf.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbZahlungslauf.GridControl = this.grdKbZahlungslauf;
            this.grvKbZahlungslauf.Name = "grvKbZahlungslauf";
            this.grvKbZahlungslauf.OptionsBehavior.Editable = false;
            this.grvKbZahlungslauf.OptionsCustomization.AllowFilter = false;
            this.grvKbZahlungslauf.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbZahlungslauf.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbZahlungslauf.OptionsNavigation.UseTabKey = false;
            this.grvKbZahlungslauf.OptionsView.ColumnAutoWidth = false;
            this.grvKbZahlungslauf.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbZahlungslauf.OptionsView.ShowGroupPanel = false;
            this.grvKbZahlungslauf.OptionsView.ShowIndicator = false;
            // 
            // colTransferZugang
            // 
            this.colTransferZugang.Caption = "E-Zugang Name";
            this.colTransferZugang.FieldName = "Name";
            this.colTransferZugang.Name = "colTransferZugang";
            this.colTransferZugang.Visible = true;
            this.colTransferZugang.VisibleIndex = 0;
            this.colTransferZugang.Width = 153;
            // 
            // colTransfer
            // 
            this.colTransfer.Caption = "Transfer";
            this.colTransfer.FieldName = "Transferdatum";
            this.colTransfer.Name = "colTransfer";
            this.colTransfer.Visible = true;
            this.colTransfer.VisibleIndex = 1;
            // 
            // colTransferErsteller
            // 
            this.colTransferErsteller.Caption = "Ersteller";
            this.colTransferErsteller.FieldName = "Ersteller";
            this.colTransferErsteller.Name = "colTransferErsteller";
            this.colTransferErsteller.Visible = true;
            this.colTransferErsteller.VisibleIndex = 2;
            this.colTransferErsteller.Width = 87;
            // 
            // colTransferFaelligkeitDatum
            // 
            this.colTransferFaelligkeitDatum.Caption = "Fälligkeit";
            this.colTransferFaelligkeitDatum.FieldName = "FaelligkeitDatum";
            this.colTransferFaelligkeitDatum.Name = "colTransferFaelligkeitDatum";
            this.colTransferFaelligkeitDatum.Visible = true;
            this.colTransferFaelligkeitDatum.VisibleIndex = 3;
            // 
            // colTransferTotalBetrag
            // 
            this.colTransferTotalBetrag.Caption = "Total Zahlungslauf";
            this.colTransferTotalBetrag.DisplayFormat.FormatString = "N2";
            this.colTransferTotalBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTransferTotalBetrag.FieldName = "TotalBetrag";
            this.colTransferTotalBetrag.Name = "colTransferTotalBetrag";
            this.colTransferTotalBetrag.Visible = true;
            this.colTransferTotalBetrag.VisibleIndex = 5;
            this.colTransferTotalBetrag.Width = 101;
            // 
            // colTransferKontoNummer
            // 
            this.colTransferKontoNummer.Caption = "Konto Nr";
            this.colTransferKontoNummer.FieldName = "KontoNr";
            this.colTransferKontoNummer.Name = "colTransferKontoNummer";
            this.colTransferKontoNummer.Visible = true;
            this.colTransferKontoNummer.VisibleIndex = 4;
            this.colTransferKontoNummer.Width = 124;
            // 
            // colTransferStatus
            // 
            this.colTransferStatus.Caption = "Status";
            this.colTransferStatus.FieldName = "JournalStatus";
            this.colTransferStatus.Name = "colTransferStatus";
            this.colTransferStatus.Visible = true;
            this.colTransferStatus.VisibleIndex = 8;
            this.colTransferStatus.Width = 189;
            // 
            // colTotalFehlerhaft
            // 
            this.colTotalFehlerhaft.Caption = "Total Fehlerhaft";
            this.colTotalFehlerhaft.DisplayFormat.FormatString = "N2";
            this.colTotalFehlerhaft.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalFehlerhaft.FieldName = "TotalFehlerhaft";
            this.colTotalFehlerhaft.Name = "colTotalFehlerhaft";
            this.colTotalFehlerhaft.Visible = true;
            this.colTotalFehlerhaft.VisibleIndex = 6;
            this.colTotalFehlerhaft.Width = 110;
            // 
            // colTotalBezahlt
            // 
            this.colTotalBezahlt.Caption = "Total Bezahlt";
            this.colTotalBezahlt.DisplayFormat.FormatString = "N2";
            this.colTotalBezahlt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalBezahlt.FieldName = "TotalBezahlt";
            this.colTotalBezahlt.Name = "colTotalBezahlt";
            this.colTotalBezahlt.Visible = true;
            this.colTotalBezahlt.VisibleIndex = 7;
            this.colTotalBezahlt.Width = 92;
            // 
            // editEZugangX
            // 
            this.editEZugangX.Location = new System.Drawing.Point(100, 70);
            this.editEZugangX.Name = "editEZugangX";
            this.editEZugangX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editEZugangX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editEZugangX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editEZugangX.Properties.Appearance.Options.UseBackColor = true;
            this.editEZugangX.Properties.Appearance.Options.UseBorderColor = true;
            this.editEZugangX.Properties.Appearance.Options.UseFont = true;
            this.editEZugangX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editEZugangX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editEZugangX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editEZugangX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editEZugangX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.editEZugangX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.editEZugangX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editEZugangX.Properties.NullText = "";
            this.editEZugangX.Properties.ShowFooter = false;
            this.editEZugangX.Properties.ShowHeader = false;
            this.editEZugangX.Size = new System.Drawing.Size(267, 24);
            this.editEZugangX.TabIndex = 0;
            // 
            // editTransferDatumVonX
            // 
            this.editTransferDatumVonX.EditValue = null;
            this.editTransferDatumVonX.Location = new System.Drawing.Point(100, 100);
            this.editTransferDatumVonX.Name = "editTransferDatumVonX";
            this.editTransferDatumVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editTransferDatumVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTransferDatumVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTransferDatumVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTransferDatumVonX.Properties.Appearance.Options.UseBackColor = true;
            this.editTransferDatumVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.editTransferDatumVonX.Properties.Appearance.Options.UseFont = true;
            this.editTransferDatumVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.editTransferDatumVonX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editTransferDatumVonX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.editTransferDatumVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editTransferDatumVonX.Properties.ShowToday = false;
            this.editTransferDatumVonX.Size = new System.Drawing.Size(106, 24);
            this.editTransferDatumVonX.TabIndex = 1;
            // 
            // editTransferDatumBisX
            // 
            this.editTransferDatumBisX.EditValue = null;
            this.editTransferDatumBisX.Location = new System.Drawing.Point(261, 100);
            this.editTransferDatumBisX.Name = "editTransferDatumBisX";
            this.editTransferDatumBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editTransferDatumBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTransferDatumBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTransferDatumBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTransferDatumBisX.Properties.Appearance.Options.UseBackColor = true;
            this.editTransferDatumBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.editTransferDatumBisX.Properties.Appearance.Options.UseFont = true;
            this.editTransferDatumBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.editTransferDatumBisX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("editTransferDatumBisX.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.editTransferDatumBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editTransferDatumBisX.Properties.ShowToday = false;
            this.editTransferDatumBisX.Size = new System.Drawing.Size(106, 24);
            this.editTransferDatumBisX.TabIndex = 2;
            // 
            // editBelegNrX
            // 
            this.editBelegNrX.Location = new System.Drawing.Point(100, 256);
            this.editBelegNrX.Name = "editBelegNrX";
            this.editBelegNrX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBelegNrX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBelegNrX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBelegNrX.Properties.Appearance.Options.UseBackColor = true;
            this.editBelegNrX.Properties.Appearance.Options.UseBorderColor = true;
            this.editBelegNrX.Properties.Appearance.Options.UseFont = true;
            this.editBelegNrX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editBelegNrX.Size = new System.Drawing.Size(267, 24);
            this.editBelegNrX.TabIndex = 6;
            // 
            // editBetragX
            // 
            this.editBetragX.Location = new System.Drawing.Point(100, 286);
            this.editBetragX.Name = "editBetragX";
            this.editBetragX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editBetragX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editBetragX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editBetragX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editBetragX.Properties.Appearance.Options.UseBackColor = true;
            this.editBetragX.Properties.Appearance.Options.UseBorderColor = true;
            this.editBetragX.Properties.Appearance.Options.UseFont = true;
            this.editBetragX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editBetragX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editBetragX.Size = new System.Drawing.Size(267, 24);
            this.editBetragX.TabIndex = 8;
            // 
            // editStatusX
            // 
            this.editStatusX.Location = new System.Drawing.Point(100, 316);
            this.editStatusX.LOVName = "KbBuchungsStatus";
            this.editStatusX.Name = "editStatusX";
            this.editStatusX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editStatusX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editStatusX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editStatusX.Properties.Appearance.Options.UseBackColor = true;
            this.editStatusX.Properties.Appearance.Options.UseBorderColor = true;
            this.editStatusX.Properties.Appearance.Options.UseFont = true;
            this.editStatusX.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editStatusX.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editStatusX.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.editStatusX.Properties.AppearanceDropDown.Options.UseFont = true;
            this.editStatusX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.editStatusX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.editStatusX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editStatusX.Properties.NullText = "";
            this.editStatusX.Properties.ShowFooter = false;
            this.editStatusX.Properties.ShowHeader = false;
            this.editStatusX.Size = new System.Drawing.Size(267, 24);
            this.editStatusX.TabIndex = 9;
            // 
            // lblZahlungsauftragX
            // 
            this.lblZahlungsauftragX.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblZahlungsauftragX.Location = new System.Drawing.Point(10, 40);
            this.lblZahlungsauftragX.Name = "lblZahlungsauftragX";
            this.lblZahlungsauftragX.Size = new System.Drawing.Size(121, 16);
            this.lblZahlungsauftragX.TabIndex = 335;
            this.lblZahlungsauftragX.Text = "Zahlungsauftrag";
            this.lblZahlungsauftragX.UseCompatibleTextRendering = true;
            // 
            // lblTotalBetragX
            // 
            this.lblTotalBetragX.Location = new System.Drawing.Point(10, 130);
            this.lblTotalBetragX.Name = "lblTotalBetragX";
            this.lblTotalBetragX.Size = new System.Drawing.Size(78, 24);
            this.lblTotalBetragX.TabIndex = 351;
            this.lblTotalBetragX.Text = "Totalbetrag";
            this.lblTotalBetragX.UseCompatibleTextRendering = true;
            // 
            // lblTransferDatumX
            // 
            this.lblTransferDatumX.Location = new System.Drawing.Point(10, 100);
            this.lblTransferDatumX.Name = "lblTransferDatumX";
            this.lblTransferDatumX.Size = new System.Drawing.Size(78, 24);
            this.lblTransferDatumX.TabIndex = 351;
            this.lblTransferDatumX.Text = "Transferdatum";
            this.lblTransferDatumX.UseCompatibleTextRendering = true;
            // 
            // lblBuchungX
            // 
            this.lblBuchungX.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblBuchungX.Location = new System.Drawing.Point(10, 226);
            this.lblBuchungX.Name = "lblBuchungX";
            this.lblBuchungX.Size = new System.Drawing.Size(100, 16);
            this.lblBuchungX.TabIndex = 358;
            this.lblBuchungX.Text = "Buchung";
            this.lblBuchungX.UseCompatibleTextRendering = true;
            // 
            // lblTransferDatumXBis
            // 
            this.lblTransferDatumXBis.Location = new System.Drawing.Point(229, 100);
            this.lblTransferDatumXBis.Name = "lblTransferDatumXBis";
            this.lblTransferDatumXBis.Size = new System.Drawing.Size(7, 24);
            this.lblTransferDatumXBis.TabIndex = 366;
            this.lblTransferDatumXBis.Text = "-";
            this.lblTransferDatumXBis.UseCompatibleTextRendering = true;
            // 
            // lblTotalBetragBisX
            // 
            this.lblTotalBetragBisX.Location = new System.Drawing.Point(229, 133);
            this.lblTotalBetragBisX.Name = "lblTotalBetragBisX";
            this.lblTotalBetragBisX.Size = new System.Drawing.Size(7, 24);
            this.lblTotalBetragBisX.TabIndex = 366;
            this.lblTotalBetragBisX.Text = "-";
            this.lblTotalBetragBisX.UseCompatibleTextRendering = true;
            // 
            // lblEZugangX
            // 
            this.lblEZugangX.Location = new System.Drawing.Point(10, 70);
            this.lblEZugangX.Name = "lblEZugangX";
            this.lblEZugangX.Size = new System.Drawing.Size(60, 24);
            this.lblEZugangX.TabIndex = 372;
            this.lblEZugangX.Text = "E-Zugang";
            this.lblEZugangX.UseCompatibleTextRendering = true;
            // 
            // lblBetragX
            // 
            this.lblBetragX.Location = new System.Drawing.Point(10, 286);
            this.lblBetragX.Name = "lblBetragX";
            this.lblBetragX.Size = new System.Drawing.Size(60, 24);
            this.lblBetragX.TabIndex = 376;
            this.lblBetragX.Text = "Betrag";
            this.lblBetragX.UseCompatibleTextRendering = true;
            // 
            // lblStatusX
            // 
            this.lblStatusX.Location = new System.Drawing.Point(10, 316);
            this.lblStatusX.Name = "lblStatusX";
            this.lblStatusX.Size = new System.Drawing.Size(60, 24);
            this.lblStatusX.TabIndex = 378;
            this.lblStatusX.Text = "Status";
            this.lblStatusX.UseCompatibleTextRendering = true;
            // 
            // lblBelegNrX
            // 
            this.lblBelegNrX.Location = new System.Drawing.Point(10, 256);
            this.lblBelegNrX.Name = "lblBelegNrX";
            this.lblBelegNrX.Size = new System.Drawing.Size(70, 24);
            this.lblBelegNrX.TabIndex = 380;
            this.lblBelegNrX.Text = "BelegNr";
            this.lblBelegNrX.UseCompatibleTextRendering = true;
            // 
            // lblErfasserX
            // 
            this.lblErfasserX.Location = new System.Drawing.Point(10, 160);
            this.lblErfasserX.Name = "lblErfasserX";
            this.lblErfasserX.Size = new System.Drawing.Size(60, 24);
            this.lblErfasserX.TabIndex = 386;
            this.lblErfasserX.Text = "Erfasser";
            this.lblErfasserX.UseCompatibleTextRendering = true;
            // 
            // kissSearchTitel1
            // 
            this.kissSearchTitel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissSearchTitel1.Location = new System.Drawing.Point(16, 3);
            this.kissSearchTitel1.Name = "kissSearchTitel1";
            this.kissSearchTitel1.Size = new System.Drawing.Size(200, 24);
            this.kissSearchTitel1.TabIndex = 388;
            // 
            // editTotalBetragBisX
            // 
            this.editTotalBetragBisX.Location = new System.Drawing.Point(261, 130);
            this.editTotalBetragBisX.Name = "editTotalBetragBisX";
            this.editTotalBetragBisX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editTotalBetragBisX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTotalBetragBisX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTotalBetragBisX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTotalBetragBisX.Properties.Appearance.Options.UseBackColor = true;
            this.editTotalBetragBisX.Properties.Appearance.Options.UseBorderColor = true;
            this.editTotalBetragBisX.Properties.Appearance.Options.UseFont = true;
            this.editTotalBetragBisX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editTotalBetragBisX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editTotalBetragBisX.Size = new System.Drawing.Size(106, 24);
            this.editTotalBetragBisX.TabIndex = 389;
            // 
            // editTotalBetragVonX
            // 
            this.editTotalBetragVonX.Location = new System.Drawing.Point(100, 130);
            this.editTotalBetragVonX.Name = "editTotalBetragVonX";
            this.editTotalBetragVonX.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.editTotalBetragVonX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editTotalBetragVonX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editTotalBetragVonX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editTotalBetragVonX.Properties.Appearance.Options.UseBackColor = true;
            this.editTotalBetragVonX.Properties.Appearance.Options.UseBorderColor = true;
            this.editTotalBetragVonX.Properties.Appearance.Options.UseFont = true;
            this.editTotalBetragVonX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.editTotalBetragVonX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editTotalBetragVonX.Size = new System.Drawing.Size(106, 24);
            this.editTotalBetragVonX.TabIndex = 389;
            // 
            // edtErfasserX
            // 
            this.edtErfasserX.Location = new System.Drawing.Point(100, 160);
            this.edtErfasserX.Name = "edtErfasserX";
            this.edtErfasserX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErfasserX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfasserX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfasserX.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfasserX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfasserX.Properties.Appearance.Options.UseFont = true;
            this.edtErfasserX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtErfasserX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtErfasserX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfasserX.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtErfasserX.Size = new System.Drawing.Size(267, 24);
            this.edtErfasserX.TabIndex = 390;
            this.edtErfasserX.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtErfasserX_UserModifiedFld);
            // 
            // edtNurPendenteX
            // 
            this.edtNurPendenteX.EditValue = true;
            this.edtNurPendenteX.Location = new System.Drawing.Point(100, 198);
            this.edtNurPendenteX.Name = "edtNurPendenteX";
            this.edtNurPendenteX.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurPendenteX.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurPendenteX.Properties.Caption = "nur Pendente";
            this.edtNurPendenteX.Size = new System.Drawing.Size(158, 19);
            this.edtNurPendenteX.TabIndex = 391;
            // 
            // qryAktivKonto
            // 
            this.qryAktivKonto.HostControl = this;
            this.qryAktivKonto.IsIdentityInsert = false;
            this.qryAktivKonto.SelectStatement = "SELECT\r\n   KTO.KbKontoId,\r\n   KTO.KbKontoartCodes,\r\n   KTO.KontoNr\r\nFROM dbo.KbKo" +
    "nto KTO\r\nWHERE KTO.KbPeriodeID = {0}\r\n AND KTO.KbZahlungskontoID = {1}";
            // 
            // qryZahlungskonto
            // 
            this.qryZahlungskonto.CanUpdate = true;
            this.qryZahlungskonto.HostControl = this;
            this.qryZahlungskonto.IsIdentityInsert = false;
            this.qryZahlungskonto.SelectStatement = resources.GetString("qryZahlungskonto.SelectStatement");
            // 
            // CtlKbTransfer
            // 
            this.ActiveSQLQuery = this.qryZahlungslauf;
            this.AutoScroll = true;
            this.AutoScrollMinSize = new System.Drawing.Size(830, 545);
            this.Name = "CtlKbTransfer";
            this.Size = new System.Drawing.Size(830, 545);
            this.Load += new System.EventHandler(this.CtlKbTransfer_Load);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKbZahlungslaufID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungslauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragstotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlBelege)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilePath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatei)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsläufe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbZahlungslauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbZahlungslauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editEZugangX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editEZugangX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTransferDatumVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTransferDatumBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBelegNrX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBetragX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editStatusX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZahlungsauftragX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalBetragX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferDatumX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTransferDatumXBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalBetragBisX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblEZugangX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatusX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegNrX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfasserX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTotalBetragBisX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editTotalBetragVonX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfasserX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurPendenteX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryAktivKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryZahlungskonto)).EndInit();
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
    }
}