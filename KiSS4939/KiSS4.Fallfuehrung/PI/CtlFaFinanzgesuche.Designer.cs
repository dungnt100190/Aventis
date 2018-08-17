namespace KiSS4.Fallfuehrung.PI
{
    partial class CtlFaFinanzgesuche
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFaFinanzgesuche));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.chkKontoFuehrung = new KiSS4.Gui.KissCheckEdit();
            this.qryBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.lblKlientenkontoNr = new KiSS4.Gui.KissLabel();
            this.grdFinanzen = new KiSS4.Gui.KissGrid();
            this.qryFaFinanzgesuche = new KiSS4.DB.SqlQuery(this.components);
            this.grvFinanzen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAutor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStichwort = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDokumenttyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFondStiftung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeantragt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBewiligterBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRueckzahlungsVerpflichtung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repCheckEditRueckzVerpfl = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colBemerkungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblDatum = new KiSS4.Gui.KissLabel();
            this.edtDatum = new KiSS4.Gui.KissDateEdit();
            this.lblDienstleistung = new KiSS4.Gui.KissLabel();
            this.edtDienstleistung = new KiSS4.Gui.KissLookUpEdit();
            this.lblAutor_V01 = new KiSS4.Gui.KissLabel();
            this.edtAutor = new KiSS4.Gui.KissButtonEdit();
            this.lblDokumenttyp = new KiSS4.Gui.KissLabel();
            this.edtDokumenttyp = new KiSS4.Gui.KissLookUpEdit();
            this.lblFondStiftung = new KiSS4.Gui.KissLabel();
            this.edtFondStiftung = new KiSS4.Gui.KissTextEdit();
            this.lblDokument = new KiSS4.Gui.KissLabel();
            this.edtDokument = new KiSS4.Dokument.XDokument();
            this.lblBeantragterBetrag = new KiSS4.Gui.KissLabel();
            this.edtBeantragterBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblBewilligterBetrag = new KiSS4.Gui.KissLabel();
            this.edtBewilligterBetrag = new KiSS4.Gui.KissCalcEdit();
            this.lblSelbstbehalt = new KiSS4.Gui.KissLabel();
            this.edtSelbstbehalt = new KiSS4.Gui.KissCalcEdit();
            this.lblRueckforderung = new KiSS4.Gui.KissLabel();
            this.edtRueckforderung = new KiSS4.Gui.KissCalcEdit();
            this.chkRueckzahlungsverpflichtung = new KiSS4.Gui.KissCheckEdit();
            this.lblDatumRueckforderung = new KiSS4.Gui.KissLabel();
            this.edtDatumRueckforderung = new KiSS4.Gui.KissDateEdit();
            this.chkZurueckBezahlt = new KiSS4.Gui.KissCheckEdit();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.memBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.lblStichwort_V01 = new KiSS4.Gui.KissLabel();
            this.edtStichwort = new KiSS4.Gui.KissTextEdit();
            this.edtInformation = new KiSS4.Gui.KissMemoEdit();
            this.qryGvDokumenteInformation = new KiSS4.DB.SqlQuery(this.components);
            this.lblInformation = new KiSS4.Gui.KissLabel();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontoFuehrung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientenkontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFinanzen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaFinanzgesuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFinanzen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditRueckzVerpfl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor_V01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumenttyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumenttyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumenttyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFondStiftung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFondStiftung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeantragterBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeantragterBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligterBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligterBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelbstbehalt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelbstbehalt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckforderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckforderung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRueckzahlungsverpflichtung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumRueckforderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumRueckforderung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZurueckBezahlt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort_V01)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInformation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvDokumenteInformation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInformation)).BeginInit();
            this.SuspendLayout();
            // 
            // panTitel
            // 
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(1014, 30);
            this.panTitel.TabIndex = 28;
            // 
            // picTitel
            // 
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(972, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Dokumente Gesuchverwaltung";
            this.lblTitel.UseCompatibleTextRendering = true;
            // 
            // chkKontoFuehrung
            // 
            this.chkKontoFuehrung.DataMember = "KontoFuehrung";
            this.chkKontoFuehrung.DataSource = this.qryBaPerson;
            this.chkKontoFuehrung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkKontoFuehrung.Location = new System.Drawing.Point(13, 37);
            this.chkKontoFuehrung.Name = "chkKontoFuehrung";
            this.chkKontoFuehrung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkKontoFuehrung.Properties.Appearance.Options.UseBackColor = true;
            this.chkKontoFuehrung.Properties.Caption = "Hat Kontoführung";
            this.chkKontoFuehrung.Properties.ReadOnly = true;
            this.chkKontoFuehrung.Size = new System.Drawing.Size(141, 19);
            this.chkKontoFuehrung.TabIndex = 29;
            this.chkKontoFuehrung.TabStop = false;
            // 
            // qryBaPerson
            // 
            this.qryBaPerson.CanUpdate = true;
            this.qryBaPerson.HostControl = this;
            this.qryBaPerson.IsIdentityInsert = false;
            this.qryBaPerson.TableName = "BaPerson";
            // 
            // lblKlientenkontoNr
            // 
            this.lblKlientenkontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKlientenkontoNr.Location = new System.Drawing.Point(160, 33);
            this.lblKlientenkontoNr.Name = "lblKlientenkontoNr";
            this.lblKlientenkontoNr.Size = new System.Drawing.Size(315, 24);
            this.lblKlientenkontoNr.TabIndex = 30;
            this.lblKlientenkontoNr.Text = "Klientenkonto-Nr.: 30\'000\'000";
            this.lblKlientenkontoNr.UseCompatibleTextRendering = true;
            // 
            // grdFinanzen
            // 
            this.grdFinanzen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFinanzen.DataSource = this.qryFaFinanzgesuche;
            // 
            // 
            // 
            this.grdFinanzen.EmbeddedNavigator.Name = "";
            this.grdFinanzen.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdFinanzen.Location = new System.Drawing.Point(3, 63);
            this.grdFinanzen.MainView = this.grvFinanzen;
            this.grdFinanzen.Name = "grdFinanzen";
            this.grdFinanzen.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repCheckEditRueckzVerpfl});
            this.grdFinanzen.SelectLastPosition = true;
            this.grdFinanzen.Size = new System.Drawing.Size(1008, 249);
            this.grdFinanzen.TabIndex = 31;
            this.grdFinanzen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFinanzen});
            // 
            // qryFaFinanzgesuche
            // 
            this.qryFaFinanzgesuche.CanDelete = true;
            this.qryFaFinanzgesuche.CanInsert = true;
            this.qryFaFinanzgesuche.CanUpdate = true;
            this.qryFaFinanzgesuche.HostControl = this;
            this.qryFaFinanzgesuche.IsIdentityInsert = false;
            this.qryFaFinanzgesuche.TableName = "FaFinanzgesuche";
            this.qryFaFinanzgesuche.AfterInsert += new System.EventHandler(this.qryFaFinanzgesuche_AfterInsert);
            this.qryFaFinanzgesuche.AfterPost += new System.EventHandler(this.qryFaFinanzgesuche_AfterPost);
            this.qryFaFinanzgesuche.BeforePost += new System.EventHandler(this.qryFaFinanzgesuche_BeforePost);
            this.qryFaFinanzgesuche.PositionChanged += new System.EventHandler(this.qryFaFinanzgesuche_PositionChanged);
            // 
            // grvFinanzen
            // 
            this.grvFinanzen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvFinanzen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzen.Appearance.Empty.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.Empty.Options.UseFont = true;
            this.grvFinanzen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzen.Appearance.EvenRow.Options.UseFont = true;
            this.grvFinanzen.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFinanzen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvFinanzen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.FocusedCell.Options.UseFont = true;
            this.grvFinanzen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvFinanzen.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvFinanzen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvFinanzen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.FocusedRow.Options.UseFont = true;
            this.grvFinanzen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvFinanzen.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFinanzen.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFinanzen.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvFinanzen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFinanzen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvFinanzen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFinanzen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFinanzen.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.GroupRow.Options.UseFont = true;
            this.grvFinanzen.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvFinanzen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvFinanzen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvFinanzen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvFinanzen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFinanzen.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvFinanzen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvFinanzen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvFinanzen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvFinanzen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvFinanzen.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvFinanzen.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzen.Appearance.OddRow.Options.UseFont = true;
            this.grvFinanzen.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvFinanzen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzen.Appearance.Row.Options.UseBackColor = true;
            this.grvFinanzen.Appearance.Row.Options.UseFont = true;
            this.grvFinanzen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvFinanzen.Appearance.SelectedRow.Options.UseFont = true;
            this.grvFinanzen.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvFinanzen.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFinanzen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvFinanzen.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colAutor,
            this.colStichwort,
            this.colDokumenttyp,
            this.colFondStiftung,
            this.colBeantragt,
            this.colStatus,
            this.colBewiligterBetrag,
            this.colRueckzahlungsVerpflichtung,
            this.colBemerkungen});
            this.grvFinanzen.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvFinanzen.GridControl = this.grdFinanzen;
            this.grvFinanzen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvFinanzen.Name = "grvFinanzen";
            this.grvFinanzen.OptionsBehavior.Editable = false;
            this.grvFinanzen.OptionsCustomization.AllowFilter = false;
            this.grvFinanzen.OptionsFilter.AllowFilterEditor = false;
            this.grvFinanzen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvFinanzen.OptionsNavigation.AutoFocusNewRow = true;
            this.grvFinanzen.OptionsNavigation.UseTabKey = false;
            this.grvFinanzen.OptionsView.ColumnAutoWidth = false;
            this.grvFinanzen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFinanzen.OptionsView.ShowGroupPanel = false;
            this.grvFinanzen.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            this.colDatum.Width = 80;
            // 
            // colAutor
            // 
            this.colAutor.Caption = "Autor";
            this.colAutor.FieldName = "Autor";
            this.colAutor.Name = "colAutor";
            this.colAutor.Visible = true;
            this.colAutor.VisibleIndex = 1;
            this.colAutor.Width = 130;
            // 
            // colStichwort
            // 
            this.colStichwort.Caption = "Stichwort";
            this.colStichwort.FieldName = "Stichwort";
            this.colStichwort.Name = "colStichwort";
            this.colStichwort.Visible = true;
            this.colStichwort.VisibleIndex = 2;
            this.colStichwort.Width = 130;
            // 
            // colDokumenttyp
            // 
            this.colDokumenttyp.Caption = "Dokumenttyp";
            this.colDokumenttyp.FieldName = "Dokumenttyp";
            this.colDokumenttyp.Name = "colDokumenttyp";
            this.colDokumenttyp.Visible = true;
            this.colDokumenttyp.VisibleIndex = 3;
            this.colDokumenttyp.Width = 130;
            // 
            // colFondStiftung
            // 
            this.colFondStiftung.Caption = "Fond / Stiftung";
            this.colFondStiftung.FieldName = "FondStiftung";
            this.colFondStiftung.Name = "colFondStiftung";
            this.colFondStiftung.Visible = true;
            this.colFondStiftung.VisibleIndex = 4;
            this.colFondStiftung.Width = 130;
            // 
            // colBeantragt
            // 
            this.colBeantragt.Caption = "Beantragt";
            this.colBeantragt.DisplayFormat.FormatString = "F2";
            this.colBeantragt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBeantragt.FieldName = "BeantragtSFr";
            this.colBeantragt.Name = "colBeantragt";
            this.colBeantragt.Visible = true;
            this.colBeantragt.VisibleIndex = 5;
            this.colBeantragt.Width = 90;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Status";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 6;
            this.colStatus.Width = 130;
            // 
            // colBewiligterBetrag
            // 
            this.colBewiligterBetrag.Caption = "Bew. Betrag";
            this.colBewiligterBetrag.FieldName = "BewilligtSFr";
            this.colBewiligterBetrag.Name = "colBewiligterBetrag";
            this.colBewiligterBetrag.Visible = true;
            this.colBewiligterBetrag.VisibleIndex = 7;
            this.colBewiligterBetrag.Width = 90;
            // 
            // colRueckzahlungsVerpflichtung
            // 
            this.colRueckzahlungsVerpflichtung.Caption = "Rückz.";
            this.colRueckzahlungsVerpflichtung.ColumnEdit = this.repCheckEditRueckzVerpfl;
            this.colRueckzahlungsVerpflichtung.FieldName = "Rueckzahlungsverpflichtung";
            this.colRueckzahlungsVerpflichtung.Name = "colRueckzahlungsVerpflichtung";
            this.colRueckzahlungsVerpflichtung.Visible = true;
            this.colRueckzahlungsVerpflichtung.VisibleIndex = 8;
            this.colRueckzahlungsVerpflichtung.Width = 48;
            // 
            // repCheckEditRueckzVerpfl
            // 
            this.repCheckEditRueckzVerpfl.AutoHeight = false;
            this.repCheckEditRueckzVerpfl.Name = "repCheckEditRueckzVerpfl";
            // 
            // colBemerkungen
            // 
            this.colBemerkungen.Caption = "Bemerkungen";
            this.colBemerkungen.FieldName = "Bemerkungen";
            this.colBemerkungen.Name = "colBemerkungen";
            this.colBemerkungen.Visible = true;
            this.colBemerkungen.VisibleIndex = 9;
            this.colBemerkungen.Width = 130;
            // 
            // lblDatum
            // 
            this.lblDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatum.Location = new System.Drawing.Point(13, 318);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(67, 24);
            this.lblDatum.TabIndex = 0;
            this.lblDatum.Text = "Datum";
            this.lblDatum.UseCompatibleTextRendering = true;
            // 
            // edtDatum
            // 
            this.edtDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatum.DataMember = "Datum";
            this.edtDatum.DataSource = this.qryFaFinanzgesuche;
            this.edtDatum.EditValue = null;
            this.edtDatum.Location = new System.Drawing.Point(110, 318);
            this.edtDatum.Name = "edtDatum";
            this.edtDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatum.Properties.Appearance.Options.UseFont = true;
            this.edtDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatum.Properties.ShowToday = false;
            this.edtDatum.Size = new System.Drawing.Size(117, 24);
            this.edtDatum.TabIndex = 1;
            // 
            // lblDienstleistung
            // 
            this.lblDienstleistung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDienstleistung.Location = new System.Drawing.Point(367, 318);
            this.lblDienstleistung.Name = "lblDienstleistung";
            this.lblDienstleistung.Size = new System.Drawing.Size(108, 24);
            this.lblDienstleistung.TabIndex = 8;
            this.lblDienstleistung.Text = "Dienstleistung";
            this.lblDienstleistung.UseCompatibleTextRendering = true;
            // 
            // edtDienstleistung
            // 
            this.edtDienstleistung.AllowNull = false;
            this.edtDienstleistung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDienstleistung.DataMember = "DienstleistungCode";
            this.edtDienstleistung.DataSource = this.qryFaFinanzgesuche;
            this.edtDienstleistung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDienstleistung.Location = new System.Drawing.Point(481, 318);
            this.edtDienstleistung.LOVName = "FaModulDienstleistungen";
            this.edtDienstleistung.Name = "edtDienstleistung";
            this.edtDienstleistung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDienstleistung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDienstleistung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDienstleistung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDienstleistung.Properties.Appearance.Options.UseFont = true;
            this.edtDienstleistung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDienstleistung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDienstleistung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDienstleistung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtDienstleistung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtDienstleistung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDienstleistung.Properties.NullText = "";
            this.edtDienstleistung.Properties.ReadOnly = true;
            this.edtDienstleistung.Properties.ShowFooter = false;
            this.edtDienstleistung.Properties.ShowHeader = false;
            this.edtDienstleistung.Size = new System.Drawing.Size(200, 24);
            this.edtDienstleistung.TabIndex = 9;
            // 
            // lblAutor_V01
            // 
            this.lblAutor_V01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAutor_V01.Location = new System.Drawing.Point(13, 348);
            this.lblAutor_V01.Name = "lblAutor_V01";
            this.lblAutor_V01.Size = new System.Drawing.Size(67, 24);
            this.lblAutor_V01.TabIndex = 2;
            this.lblAutor_V01.Text = "Autor";
            this.lblAutor_V01.UseCompatibleTextRendering = true;
            // 
            // edtAutor
            // 
            this.edtAutor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAutor.DataMember = "Autor";
            this.edtAutor.DataSource = this.qryFaFinanzgesuche;
            this.edtAutor.Location = new System.Drawing.Point(110, 348);
            this.edtAutor.Name = "edtAutor";
            this.edtAutor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAutor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAutor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAutor.Properties.Appearance.Options.UseBackColor = true;
            this.edtAutor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAutor.Properties.Appearance.Options.UseFont = true;
            this.edtAutor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtAutor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtAutor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAutor.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtAutor.Size = new System.Drawing.Size(200, 24);
            this.edtAutor.TabIndex = 3;
            this.edtAutor.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtAutor_UserModifiedFld);
            this.edtAutor.EditValueChanged += new System.EventHandler(this.edtAutor_EditValueChanged);
            // 
            // lblDokumenttyp
            // 
            this.lblDokumenttyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokumenttyp.Location = new System.Drawing.Point(367, 348);
            this.lblDokumenttyp.Name = "lblDokumenttyp";
            this.lblDokumenttyp.Size = new System.Drawing.Size(108, 24);
            this.lblDokumenttyp.TabIndex = 10;
            this.lblDokumenttyp.Text = "Dokumenttyp";
            this.lblDokumenttyp.UseCompatibleTextRendering = true;
            // 
            // edtDokumenttyp
            // 
            this.edtDokumenttyp.AllowNull = false;
            this.edtDokumenttyp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokumenttyp.DataMember = "DokumenttypCode";
            this.edtDokumenttyp.DataSource = this.qryFaFinanzgesuche;
            this.edtDokumenttyp.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDokumenttyp.Location = new System.Drawing.Point(481, 348);
            this.edtDokumenttyp.LOVName = "FaGesuchDokumenttyp";
            this.edtDokumenttyp.Name = "edtDokumenttyp";
            this.edtDokumenttyp.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDokumenttyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokumenttyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumenttyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokumenttyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokumenttyp.Properties.Appearance.Options.UseFont = true;
            this.edtDokumenttyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtDokumenttyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokumenttyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtDokumenttyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtDokumenttyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtDokumenttyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtDokumenttyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokumenttyp.Properties.NullText = "";
            this.edtDokumenttyp.Properties.ReadOnly = true;
            this.edtDokumenttyp.Properties.ShowFooter = false;
            this.edtDokumenttyp.Properties.ShowHeader = false;
            this.edtDokumenttyp.Size = new System.Drawing.Size(200, 24);
            this.edtDokumenttyp.TabIndex = 11;
            // 
            // lblFondStiftung
            // 
            this.lblFondStiftung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFondStiftung.Location = new System.Drawing.Point(367, 378);
            this.lblFondStiftung.Name = "lblFondStiftung";
            this.lblFondStiftung.Size = new System.Drawing.Size(108, 24);
            this.lblFondStiftung.TabIndex = 12;
            this.lblFondStiftung.Text = "Fond / Stiftung";
            this.lblFondStiftung.UseCompatibleTextRendering = true;
            // 
            // edtFondStiftung
            // 
            this.edtFondStiftung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFondStiftung.DataMember = "FondStiftung";
            this.edtFondStiftung.DataSource = this.qryFaFinanzgesuche;
            this.edtFondStiftung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtFondStiftung.Location = new System.Drawing.Point(481, 378);
            this.edtFondStiftung.Name = "edtFondStiftung";
            this.edtFondStiftung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFondStiftung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFondStiftung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFondStiftung.Properties.Appearance.Options.UseBackColor = true;
            this.edtFondStiftung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFondStiftung.Properties.Appearance.Options.UseFont = true;
            this.edtFondStiftung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFondStiftung.Properties.ReadOnly = true;
            this.edtFondStiftung.Size = new System.Drawing.Size(200, 24);
            this.edtFondStiftung.TabIndex = 13;
            // 
            // lblDokument
            // 
            this.lblDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDokument.Location = new System.Drawing.Point(13, 408);
            this.lblDokument.Name = "lblDokument";
            this.lblDokument.Size = new System.Drawing.Size(70, 24);
            this.lblDokument.TabIndex = 6;
            this.lblDokument.Text = "Dokument";
            this.lblDokument.UseCompatibleTextRendering = true;
            // 
            // edtDokument
            // 
            this.edtDokument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDokument.Context = "FA_Finanzgesuche_Dokumente";
            this.edtDokument.DataMember = "DokumentDocID";
            this.edtDokument.DataSource = this.qryFaFinanzgesuche;
            this.edtDokument.Location = new System.Drawing.Point(110, 408);
            this.edtDokument.Name = "edtDokument";
            this.edtDokument.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDokument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDokument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDokument.Properties.Appearance.Options.UseBackColor = true;
            this.edtDokument.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDokument.Properties.Appearance.Options.UseFont = true;
            this.edtDokument.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtDokument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDokument.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument importieren")});
            this.edtDokument.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDokument.Properties.ReadOnly = true;
            this.edtDokument.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtDokument.Size = new System.Drawing.Size(117, 24);
            this.edtDokument.TabIndex = 7;
            // 
            // lblBeantragterBetrag
            // 
            this.lblBeantragterBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBeantragterBetrag.Location = new System.Drawing.Point(747, 318);
            this.lblBeantragterBetrag.Name = "lblBeantragterBetrag";
            this.lblBeantragterBetrag.Size = new System.Drawing.Size(123, 24);
            this.lblBeantragterBetrag.TabIndex = 16;
            this.lblBeantragterBetrag.Text = "Beantragter Betrag";
            this.lblBeantragterBetrag.UseCompatibleTextRendering = true;
            // 
            // edtBeantragterBetrag
            // 
            this.edtBeantragterBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBeantragterBetrag.DataMember = "Beantragt";
            this.edtBeantragterBetrag.DataSource = this.qryFaFinanzgesuche;
            this.edtBeantragterBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBeantragterBetrag.Location = new System.Drawing.Point(876, 318);
            this.edtBeantragterBetrag.Name = "edtBeantragterBetrag";
            this.edtBeantragterBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBeantragterBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBeantragterBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBeantragterBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBeantragterBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBeantragterBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBeantragterBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBeantragterBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBeantragterBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBeantragterBetrag.Properties.DisplayFormat.FormatString = "C";
            this.edtBeantragterBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtBeantragterBetrag.Properties.EditFormat.FormatString = "C";
            this.edtBeantragterBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtBeantragterBetrag.Properties.Mask.EditMask = "C";
            this.edtBeantragterBetrag.Properties.Precision = 2;
            this.edtBeantragterBetrag.Properties.ReadOnly = true;
            this.edtBeantragterBetrag.Size = new System.Drawing.Size(117, 24);
            this.edtBeantragterBetrag.TabIndex = 17;
            // 
            // lblBewilligterBetrag
            // 
            this.lblBewilligterBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBewilligterBetrag.Location = new System.Drawing.Point(747, 348);
            this.lblBewilligterBetrag.Name = "lblBewilligterBetrag";
            this.lblBewilligterBetrag.Size = new System.Drawing.Size(123, 24);
            this.lblBewilligterBetrag.TabIndex = 18;
            this.lblBewilligterBetrag.Text = "Bewilligter Betrag";
            this.lblBewilligterBetrag.UseCompatibleTextRendering = true;
            // 
            // edtBewilligterBetrag
            // 
            this.edtBewilligterBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBewilligterBetrag.DataMember = "BewilligterBetrag";
            this.edtBewilligterBetrag.DataSource = this.qryFaFinanzgesuche;
            this.edtBewilligterBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBewilligterBetrag.Location = new System.Drawing.Point(876, 348);
            this.edtBewilligterBetrag.Name = "edtBewilligterBetrag";
            this.edtBewilligterBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBewilligterBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBewilligterBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBewilligterBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBewilligterBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBewilligterBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBewilligterBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBewilligterBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBewilligterBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBewilligterBetrag.Properties.DisplayFormat.FormatString = "C";
            this.edtBewilligterBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtBewilligterBetrag.Properties.EditFormat.FormatString = "C";
            this.edtBewilligterBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtBewilligterBetrag.Properties.Mask.EditMask = "C";
            this.edtBewilligterBetrag.Properties.Precision = 2;
            this.edtBewilligterBetrag.Properties.ReadOnly = true;
            this.edtBewilligterBetrag.Size = new System.Drawing.Size(116, 24);
            this.edtBewilligterBetrag.TabIndex = 19;
            // 
            // lblSelbstbehalt
            // 
            this.lblSelbstbehalt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSelbstbehalt.Location = new System.Drawing.Point(747, 378);
            this.lblSelbstbehalt.Name = "lblSelbstbehalt";
            this.lblSelbstbehalt.Size = new System.Drawing.Size(123, 24);
            this.lblSelbstbehalt.TabIndex = 20;
            this.lblSelbstbehalt.Text = "Selbstbehalt";
            this.lblSelbstbehalt.UseCompatibleTextRendering = true;
            // 
            // edtSelbstbehalt
            // 
            this.edtSelbstbehalt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSelbstbehalt.DataMember = "Selbstbehalt";
            this.edtSelbstbehalt.DataSource = this.qryFaFinanzgesuche;
            this.edtSelbstbehalt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSelbstbehalt.Location = new System.Drawing.Point(876, 378);
            this.edtSelbstbehalt.Name = "edtSelbstbehalt";
            this.edtSelbstbehalt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSelbstbehalt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSelbstbehalt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSelbstbehalt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSelbstbehalt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSelbstbehalt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSelbstbehalt.Properties.Appearance.Options.UseFont = true;
            this.edtSelbstbehalt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSelbstbehalt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSelbstbehalt.Properties.DisplayFormat.FormatString = "C";
            this.edtSelbstbehalt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSelbstbehalt.Properties.EditFormat.FormatString = "C";
            this.edtSelbstbehalt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtSelbstbehalt.Properties.Mask.EditMask = "C";
            this.edtSelbstbehalt.Properties.Precision = 2;
            this.edtSelbstbehalt.Properties.ReadOnly = true;
            this.edtSelbstbehalt.Size = new System.Drawing.Size(116, 24);
            this.edtSelbstbehalt.TabIndex = 21;
            // 
            // lblRueckforderung
            // 
            this.lblRueckforderung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRueckforderung.Location = new System.Drawing.Point(747, 408);
            this.lblRueckforderung.Name = "lblRueckforderung";
            this.lblRueckforderung.Size = new System.Drawing.Size(123, 24);
            this.lblRueckforderung.TabIndex = 22;
            this.lblRueckforderung.Text = "Rückforderung";
            this.lblRueckforderung.UseCompatibleTextRendering = true;
            // 
            // edtRueckforderung
            // 
            this.edtRueckforderung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtRueckforderung.DataMember = "Rueckforderung";
            this.edtRueckforderung.DataSource = this.qryFaFinanzgesuche;
            this.edtRueckforderung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtRueckforderung.Location = new System.Drawing.Point(876, 408);
            this.edtRueckforderung.Name = "edtRueckforderung";
            this.edtRueckforderung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtRueckforderung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtRueckforderung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtRueckforderung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtRueckforderung.Properties.Appearance.Options.UseBackColor = true;
            this.edtRueckforderung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtRueckforderung.Properties.Appearance.Options.UseFont = true;
            this.edtRueckforderung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtRueckforderung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtRueckforderung.Properties.DisplayFormat.FormatString = "C";
            this.edtRueckforderung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtRueckforderung.Properties.EditFormat.FormatString = "C";
            this.edtRueckforderung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.edtRueckforderung.Properties.Mask.EditMask = "C";
            this.edtRueckforderung.Properties.Precision = 2;
            this.edtRueckforderung.Properties.ReadOnly = true;
            this.edtRueckforderung.Size = new System.Drawing.Size(116, 24);
            this.edtRueckforderung.TabIndex = 23;
            // 
            // chkRueckzahlungsverpflichtung
            // 
            this.chkRueckzahlungsverpflichtung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkRueckzahlungsverpflichtung.DataMember = "Rueckzahlungsverpflichtung";
            this.chkRueckzahlungsverpflichtung.DataSource = this.qryFaFinanzgesuche;
            this.chkRueckzahlungsverpflichtung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkRueckzahlungsverpflichtung.Location = new System.Drawing.Point(481, 413);
            this.chkRueckzahlungsverpflichtung.Name = "chkRueckzahlungsverpflichtung";
            this.chkRueckzahlungsverpflichtung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkRueckzahlungsverpflichtung.Properties.Appearance.Options.UseBackColor = true;
            this.chkRueckzahlungsverpflichtung.Properties.Caption = "Rückzahlungsverpflichtung";
            this.chkRueckzahlungsverpflichtung.Properties.ReadOnly = true;
            this.chkRueckzahlungsverpflichtung.Size = new System.Drawing.Size(170, 19);
            this.chkRueckzahlungsverpflichtung.TabIndex = 14;
            // 
            // lblDatumRueckforderung
            // 
            this.lblDatumRueckforderung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDatumRueckforderung.Location = new System.Drawing.Point(747, 438);
            this.lblDatumRueckforderung.Name = "lblDatumRueckforderung";
            this.lblDatumRueckforderung.Size = new System.Drawing.Size(123, 24);
            this.lblDatumRueckforderung.TabIndex = 24;
            this.lblDatumRueckforderung.Text = "Fälligkeitsdatum";
            this.lblDatumRueckforderung.UseCompatibleTextRendering = true;
            // 
            // edtDatumRueckforderung
            // 
            this.edtDatumRueckforderung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtDatumRueckforderung.DataMember = "DatumRueckforderung";
            this.edtDatumRueckforderung.DataSource = this.qryFaFinanzgesuche;
            this.edtDatumRueckforderung.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumRueckforderung.EditValue = null;
            this.edtDatumRueckforderung.Location = new System.Drawing.Point(876, 438);
            this.edtDatumRueckforderung.Name = "edtDatumRueckforderung";
            this.edtDatumRueckforderung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumRueckforderung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumRueckforderung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumRueckforderung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumRueckforderung.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumRueckforderung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumRueckforderung.Properties.Appearance.Options.UseFont = true;
            this.edtDatumRueckforderung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumRueckforderung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumRueckforderung.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumRueckforderung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumRueckforderung.Properties.ReadOnly = true;
            this.edtDatumRueckforderung.Properties.ShowToday = false;
            this.edtDatumRueckforderung.Size = new System.Drawing.Size(116, 24);
            this.edtDatumRueckforderung.TabIndex = 25;
            // 
            // chkZurueckBezahlt
            // 
            this.chkZurueckBezahlt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkZurueckBezahlt.DataMember = "ZurueckBezahlt";
            this.chkZurueckBezahlt.DataSource = this.qryFaFinanzgesuche;
            this.chkZurueckBezahlt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.chkZurueckBezahlt.Location = new System.Drawing.Point(481, 442);
            this.chkZurueckBezahlt.Name = "chkZurueckBezahlt";
            this.chkZurueckBezahlt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkZurueckBezahlt.Properties.Appearance.Options.UseBackColor = true;
            this.chkZurueckBezahlt.Properties.Caption = "Zurückbezahlt";
            this.chkZurueckBezahlt.Properties.ReadOnly = true;
            this.chkZurueckBezahlt.Size = new System.Drawing.Size(170, 19);
            this.chkZurueckBezahlt.TabIndex = 15;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkungen.Location = new System.Drawing.Point(13, 470);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(91, 24);
            this.lblBemerkungen.TabIndex = 26;
            this.lblBemerkungen.Text = "Bemerkungen";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // memBemerkungen
            // 
            this.memBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.memBemerkungen.DataMember = "Bemerkungen";
            this.memBemerkungen.DataSource = this.qryFaFinanzgesuche;
            this.memBemerkungen.Location = new System.Drawing.Point(110, 470);
            this.memBemerkungen.Name = "memBemerkungen";
            this.memBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungen.Size = new System.Drawing.Size(901, 101);
            this.memBemerkungen.TabIndex = 27;
            // 
            // lblStichwort_V01
            // 
            this.lblStichwort_V01.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichwort_V01.Location = new System.Drawing.Point(13, 378);
            this.lblStichwort_V01.Name = "lblStichwort_V01";
            this.lblStichwort_V01.Size = new System.Drawing.Size(67, 24);
            this.lblStichwort_V01.TabIndex = 4;
            this.lblStichwort_V01.Text = "Stichwort(e)";
            this.lblStichwort_V01.UseCompatibleTextRendering = true;
            // 
            // edtStichwort
            // 
            this.edtStichwort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStichwort.DataMember = "Stichwort";
            this.edtStichwort.DataSource = this.qryFaFinanzgesuche;
            this.edtStichwort.Location = new System.Drawing.Point(110, 378);
            this.edtStichwort.Name = "edtStichwort";
            this.edtStichwort.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichwort.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichwort.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichwort.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichwort.Properties.Appearance.Options.UseFont = true;
            this.edtStichwort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichwort.Size = new System.Drawing.Size(200, 24);
            this.edtStichwort.TabIndex = 5;
            // 
            // edtInformation
            // 
            this.edtInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtInformation.DataMember = "Information";
            this.edtInformation.DataSource = this.qryGvDokumenteInformation;
            this.edtInformation.Location = new System.Drawing.Point(481, 3);
            this.edtInformation.Name = "edtInformation";
            this.edtInformation.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInformation.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInformation.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInformation.Properties.Appearance.Options.UseBackColor = true;
            this.edtInformation.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInformation.Properties.Appearance.Options.UseFont = true;
            this.edtInformation.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtInformation.Size = new System.Drawing.Size(530, 54);
            this.edtInformation.TabIndex = 32;
            // 
            // qryGvDokumenteInformation
            // 
            this.qryGvDokumenteInformation.CanDelete = true;
            this.qryGvDokumenteInformation.CanInsert = true;
            this.qryGvDokumenteInformation.CanUpdate = true;
            this.qryGvDokumenteInformation.HostControl = this;
            this.qryGvDokumenteInformation.IsIdentityInsert = false;
            this.qryGvDokumenteInformation.TableName = "GvDokumenteInformation";
            this.qryGvDokumenteInformation.AfterInsert += new System.EventHandler(this.qryGvDokumenteInformation_AfterInsert);
            // 
            // lblInformation
            // 
            this.lblInformation.Location = new System.Drawing.Point(400, 3);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(75, 24);
            this.lblInformation.TabIndex = 33;
            this.lblInformation.Text = "Information";
            // 
            // CtlFaFinanzgesuche
            // 
            this.ActiveSQLQuery = this.qryFaFinanzgesuche;
            this.Controls.Add(this.edtInformation);
            this.Controls.Add(this.lblStichwort_V01);
            this.Controls.Add(this.memBemerkungen);
            this.Controls.Add(this.lblBemerkungen);
            this.Controls.Add(this.chkZurueckBezahlt);
            this.Controls.Add(this.edtDatumRueckforderung);
            this.Controls.Add(this.lblDatumRueckforderung);
            this.Controls.Add(this.chkRueckzahlungsverpflichtung);
            this.Controls.Add(this.edtRueckforderung);
            this.Controls.Add(this.lblRueckforderung);
            this.Controls.Add(this.edtSelbstbehalt);
            this.Controls.Add(this.lblSelbstbehalt);
            this.Controls.Add(this.edtBewilligterBetrag);
            this.Controls.Add(this.lblBewilligterBetrag);
            this.Controls.Add(this.edtBeantragterBetrag);
            this.Controls.Add(this.lblBeantragterBetrag);
            this.Controls.Add(this.edtDokument);
            this.Controls.Add(this.lblDokument);
            this.Controls.Add(this.edtStichwort);
            this.Controls.Add(this.edtFondStiftung);
            this.Controls.Add(this.lblFondStiftung);
            this.Controls.Add(this.edtDokumenttyp);
            this.Controls.Add(this.lblDokumenttyp);
            this.Controls.Add(this.edtAutor);
            this.Controls.Add(this.lblAutor_V01);
            this.Controls.Add(this.edtDienstleistung);
            this.Controls.Add(this.lblDienstleistung);
            this.Controls.Add(this.edtDatum);
            this.Controls.Add(this.lblDatum);
            this.Controls.Add(this.grdFinanzen);
            this.Controls.Add(this.lblKlientenkontoNr);
            this.Controls.Add(this.chkKontoFuehrung);
            this.Controls.Add(this.lblInformation);
            this.Controls.Add(this.panTitel);
            this.Name = "CtlFaFinanzgesuche";
            this.Size = new System.Drawing.Size(1014, 574);
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkKontoFuehrung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlientenkontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFinanzen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaFinanzgesuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFinanzen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckEditRueckzVerpfl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDienstleistung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAutor_V01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAutor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokumenttyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumenttyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokumenttyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFondStiftung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFondStiftung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDokument)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDokument.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBeantragterBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBeantragterBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBewilligterBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBewilligterBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelbstbehalt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSelbstbehalt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckforderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtRueckforderung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRueckzahlungsverpflichtung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumRueckforderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumRueckforderung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkZurueckBezahlt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichwort_V01)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichwort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInformation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryGvDokumenteInformation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInformation)).EndInit();
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

        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissCheckEdit chkKontoFuehrung;
        private KiSS4.Gui.KissCheckEdit chkRueckzahlungsverpflichtung;
        private KiSS4.Gui.KissCheckEdit chkZurueckBezahlt;
        private DevExpress.XtraGrid.Columns.GridColumn colAutor;
        private DevExpress.XtraGrid.Columns.GridColumn colBeantragt;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkungen;
        private DevExpress.XtraGrid.Columns.GridColumn colBewiligterBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colDokumenttyp;
        private DevExpress.XtraGrid.Columns.GridColumn colFondStiftung;
        private DevExpress.XtraGrid.Columns.GridColumn colRueckzahlungsVerpflichtung;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private KiSS4.Gui.KissButtonEdit edtAutor;
        private KiSS4.Gui.KissCalcEdit edtBeantragterBetrag;
        private KiSS4.Gui.KissCalcEdit edtBewilligterBetrag;
        private KiSS4.Gui.KissDateEdit edtDatum;
        private KiSS4.Gui.KissDateEdit edtDatumRueckforderung;
        private KiSS4.Gui.KissLookUpEdit edtDienstleistung;
        private KiSS4.Dokument.XDokument edtDokument;
        private KiSS4.Gui.KissLookUpEdit edtDokumenttyp;
        private KiSS4.Gui.KissTextEdit edtFondStiftung;
        private KiSS4.Gui.KissCalcEdit edtRueckforderung;
        private KiSS4.Gui.KissCalcEdit edtSelbstbehalt;
        private KiSS4.Gui.KissGrid grdFinanzen;
        private DevExpress.XtraGrid.Views.Grid.GridView grvFinanzen;
        private KiSS4.Gui.KissLabel lblAutor_V01;
        private KiSS4.Gui.KissLabel lblBeantragterBetrag;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBewilligterBetrag;
        private KiSS4.Gui.KissLabel lblDatum;
        private KiSS4.Gui.KissLabel lblDatumRueckforderung;
        private KiSS4.Gui.KissLabel lblKlientenkontoNr;
        private KiSS4.Gui.KissLabel lblDienstleistung;
        private KiSS4.Gui.KissLabel lblDokument;
        private KiSS4.Gui.KissLabel lblDokumenttyp;
        private KiSS4.Gui.KissLabel lblFondStiftung;
        private KiSS4.Gui.KissLabel lblRueckforderung;
        private KiSS4.Gui.KissLabel lblSelbstbehalt;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissMemoEdit memBemerkungen;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryBaPerson;
        private KiSS4.DB.SqlQuery qryFaFinanzgesuche;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckEditRueckzVerpfl;
        private Gui.KissLabel lblStichwort_V01;
        private Gui.KissTextEdit edtStichwort;
        private DevExpress.XtraGrid.Columns.GridColumn colStichwort;
        private Gui.KissMemoEdit edtInformation;
        private Gui.KissLabel lblInformation;
        private DB.SqlQuery qryGvDokumenteInformation;
    }
}
