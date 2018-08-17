namespace KiSS4.Inkasso
{
    partial class CtlIkMonatszahlenVerrechnung
    {
        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumBis;
        private DevExpress.XtraGrid.Columns.GridColumn colGrundforderung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumVon;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatlicherBetrag;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissDateEdit edtAnnulliertAm;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissCalcEdit edtBetragProMonat;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissCalcEdit edtGrundforderung;
        private KiSS4.Gui.KissCalcEdit edtLetzterMonat;
        private KiSS4.Gui.KissDateEdit edtVereinbarungVom;
        private KiSS4.Gui.KissGrid grdVerrechnung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVerrechnung;
        private KiSS4.Gui.KissLabel lblVerrerechnungsArtRueckforderung;
        private KiSS4.Gui.KissLabel lblAnnullieren;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBemerkungen;
        private KiSS4.Gui.KissLabel lblBetragProMonat;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KiSS4.Gui.KissLabel lblGrundforderung;
        private KiSS4.Gui.KissLabel lblGueltigBis;
        private KiSS4.Gui.KissLabel lblLetzterMonat;
        private KiSS4.Gui.KissLabel lblVereinbarung;
        private KiSS4.Gui.KissMemoEdit memBemerkungen;
        private KiSS4.DB.SqlQuery qryPerson;
        private KiSS4.DB.SqlQuery qryVerrechnung;   // was public -> why?

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlIkMonatszahlenVerrechnung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grdVerrechnung = new KiSS4.Gui.KissGrid();
            this.qryVerrechnung = new KiSS4.DB.SqlQuery(this.components);
            this.grvVerrechnung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrundforderung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatlicherBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnnulliertAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIstErledigt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldoVerrechnunsKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtVereinbarungVom = new KiSS4.Gui.KissDateEdit();
            this.edtGrundforderung = new KiSS4.Gui.KissCalcEdit();
            this.edtBetragProMonat = new KiSS4.Gui.KissCalcEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.memBemerkungen = new KiSS4.Gui.KissMemoEdit();
            this.edtLetzterMonat = new KiSS4.Gui.KissCalcEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblGrundforderung = new KiSS4.Gui.KissLabel();
            this.lblBetragProMonat = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblGueltigBis = new KiSS4.Gui.KissLabel();
            this.lblBemerkungen = new KiSS4.Gui.KissLabel();
            this.lblVereinbarung = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblLetzterMonat = new KiSS4.Gui.KissLabel();
            this.edtAnnulliertAm = new KiSS4.Gui.KissDateEdit();
            this.lblAnnullieren = new KiSS4.Gui.KissLabel();
            this.lblVerrerechnungsArtRueckforderung = new KiSS4.Gui.KissLabel();
            this.qryPerson = new KiSS4.DB.SqlQuery(this.components);
            this.panDetails = new System.Windows.Forms.Panel();
            this.lblAnzahlMonate = new KiSS4.Gui.KissLabel();
            this.edtAnzahlMonate = new KiSS4.Gui.KissCalcEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVerrechnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerrechnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerrechnung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVereinbarungVom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundforderung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragProMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLetzterMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundforderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragProMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbarung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzterMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnnulliertAm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnnullieren)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrerechnungsArtRueckforderung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).BeginInit();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlMonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlMonate.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdVerrechnung
            // 
            this.grdVerrechnung.DataSource = this.qryVerrechnung;
            this.grdVerrechnung.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdVerrechnung.EmbeddedNavigator.Name = "";
            this.grdVerrechnung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVerrechnung.Location = new System.Drawing.Point(0, 0);
            this.grdVerrechnung.MainView = this.grvVerrechnung;
            this.grdVerrechnung.Name = "grdVerrechnung";
            this.grdVerrechnung.Size = new System.Drawing.Size(661, 231);
            this.grdVerrechnung.TabIndex = 0;
            this.grdVerrechnung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVerrechnung});
            // 
            // qryVerrechnung
            // 
            this.qryVerrechnung.CanDelete = true;
            this.qryVerrechnung.CanInsert = true;
            this.qryVerrechnung.CanUpdate = true;
            this.qryVerrechnung.HostControl = this;
            this.qryVerrechnung.TableName = "IkVerrechnungskonto";
            this.qryVerrechnung.AfterFill += new System.EventHandler(this.qryVerrechnung_AfterFill);
            this.qryVerrechnung.AfterInsert += new System.EventHandler(this.qryVerrechnung_AfterInsert);
            this.qryVerrechnung.BeforePost += new System.EventHandler(this.qryVerrechnung_BeforePost);
            this.qryVerrechnung.AfterPost += new System.EventHandler(this.qryVerrechnung_AfterPost);
            this.qryVerrechnung.PostCompleted += new System.EventHandler(this.qryVerrechnung_PostCompleted);
            this.qryVerrechnung.PositionChanging += new System.EventHandler(this.qryVerrechnung_PositionChanging);
            this.qryVerrechnung.PositionChanged += new System.EventHandler(this.qryVerrechnung_PositionChanged);
            // 
            // grvVerrechnung
            // 
            this.grvVerrechnung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVerrechnung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerrechnung.Appearance.Empty.Options.UseBackColor = true;
            this.grvVerrechnung.Appearance.Empty.Options.UseFont = true;
            this.grvVerrechnung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerrechnung.Appearance.EvenRow.Options.UseFont = true;
            this.grvVerrechnung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerrechnung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerrechnung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVerrechnung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVerrechnung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVerrechnung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVerrechnung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVerrechnung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerrechnung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVerrechnung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVerrechnung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVerrechnung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVerrechnung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerrechnung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVerrechnung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVerrechnung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerrechnung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerrechnung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVerrechnung.Appearance.GroupRow.Options.UseFont = true;
            this.grvVerrechnung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVerrechnung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVerrechnung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVerrechnung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVerrechnung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVerrechnung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVerrechnung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVerrechnung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVerrechnung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerrechnung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVerrechnung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVerrechnung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVerrechnung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVerrechnung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerrechnung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVerrechnung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerrechnung.Appearance.OddRow.Options.UseFont = true;
            this.grvVerrechnung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVerrechnung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerrechnung.Appearance.Row.Options.UseBackColor = true;
            this.grvVerrechnung.Appearance.Row.Options.UseFont = true;
            this.grvVerrechnung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVerrechnung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVerrechnung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVerrechnung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVerrechnung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVerrechnung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPerson,
            this.colGrundforderung,
            this.colDatumVon,
            this.colDatumBis,
            this.colMonatlicherBetrag,
            this.colAnnulliertAm,
            this.colIstErledigt,
            this.colSaldoVerrechnunsKonto});
            this.grvVerrechnung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVerrechnung.GridControl = this.grdVerrechnung;
            this.grvVerrechnung.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvVerrechnung.Name = "grvVerrechnung";
            this.grvVerrechnung.OptionsBehavior.Editable = false;
            this.grvVerrechnung.OptionsCustomization.AllowFilter = false;
            this.grvVerrechnung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVerrechnung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVerrechnung.OptionsNavigation.UseTabKey = false;
            this.grvVerrechnung.OptionsView.ColumnAutoWidth = false;
            this.grvVerrechnung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVerrechnung.OptionsView.ShowGroupPanel = false;
            this.grvVerrechnung.OptionsView.ShowIndicator = false;
            this.grvVerrechnung.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvVerrechnung_CustomDrawCell);
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Person, Gläubiger";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 0;
            this.colPerson.Width = 160;
            // 
            // colGrundforderung
            // 
            this.colGrundforderung.Caption = "Grundford.";
            this.colGrundforderung.DisplayFormat.FormatString = "N2";
            this.colGrundforderung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colGrundforderung.Name = "colGrundforderung";
            this.colGrundforderung.Visible = true;
            this.colGrundforderung.VisibleIndex = 1;
            this.colGrundforderung.Width = 85;
            // 
            // colDatumVon
            // 
            this.colDatumVon.Caption = "Dauer von";
            this.colDatumVon.DisplayFormat.FormatString = "MM.yyyy";
            this.colDatumVon.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatumVon.Name = "colDatumVon";
            this.colDatumVon.Visible = true;
            this.colDatumVon.VisibleIndex = 2;
            // 
            // colDatumBis
            // 
            this.colDatumBis.Caption = "Dauer bis";
            this.colDatumBis.DisplayFormat.FormatString = "MM.yyyy";
            this.colDatumBis.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colDatumBis.Name = "colDatumBis";
            this.colDatumBis.Visible = true;
            this.colDatumBis.VisibleIndex = 3;
            // 
            // colMonatlicherBetrag
            // 
            this.colMonatlicherBetrag.Caption = "Monatl. Betrag";
            this.colMonatlicherBetrag.DisplayFormat.FormatString = "N2";
            this.colMonatlicherBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colMonatlicherBetrag.Name = "colMonatlicherBetrag";
            this.colMonatlicherBetrag.Visible = true;
            this.colMonatlicherBetrag.VisibleIndex = 4;
            this.colMonatlicherBetrag.Width = 95;
            // 
            // colAnnulliertAm
            // 
            this.colAnnulliertAm.Caption = "Annullation";
            this.colAnnulliertAm.DisplayFormat.FormatString = "MM.yyyy";
            this.colAnnulliertAm.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colAnnulliertAm.Name = "colAnnulliertAm";
            this.colAnnulliertAm.Visible = true;
            this.colAnnulliertAm.VisibleIndex = 5;
            // 
            // colIstErledigt
            // 
            this.colIstErledigt.Caption = "Erl.";
            this.colIstErledigt.Name = "colIstErledigt";
            this.colIstErledigt.Visible = true;
            this.colIstErledigt.VisibleIndex = 6;
            this.colIstErledigt.Width = 30;
            // 
            // colSaldoVerrechnunsKonto
            // 
            this.colSaldoVerrechnunsKonto.Caption = "Saldo";
            this.colSaldoVerrechnunsKonto.Name = "colSaldoVerrechnunsKonto";
            this.colSaldoVerrechnunsKonto.Visible = true;
            this.colSaldoVerrechnunsKonto.VisibleIndex = 7;
            this.colSaldoVerrechnunsKonto.Width = 85;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryVerrechnung;
            this.edtBaPersonID.Location = new System.Drawing.Point(146, 9);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 20, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBaPersonID.Properties.DisplayMember = "Text";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(506, 24);
            this.edtBaPersonID.TabIndex = 1;
            // 
            // edtVereinbarungVom
            // 
            this.edtVereinbarungVom.DataMember = "VereinbarungVom";
            this.edtVereinbarungVom.DataSource = this.qryVerrechnung;
            this.edtVereinbarungVom.EditValue = null;
            this.edtVereinbarungVom.Location = new System.Drawing.Point(146, 39);
            this.edtVereinbarungVom.Name = "edtVereinbarungVom";
            this.edtVereinbarungVom.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVereinbarungVom.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVereinbarungVom.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVereinbarungVom.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVereinbarungVom.Properties.Appearance.Options.UseBackColor = true;
            this.edtVereinbarungVom.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVereinbarungVom.Properties.Appearance.Options.UseFont = true;
            this.edtVereinbarungVom.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtVereinbarungVom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVereinbarungVom.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtVereinbarungVom.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVereinbarungVom.Properties.ShowToday = false;
            this.edtVereinbarungVom.Size = new System.Drawing.Size(100, 24);
            this.edtVereinbarungVom.TabIndex = 3;
            // 
            // edtGrundforderung
            // 
            this.edtGrundforderung.DataMember = "Grundforderung";
            this.edtGrundforderung.DataSource = this.qryVerrechnung;
            this.edtGrundforderung.Location = new System.Drawing.Point(146, 69);
            this.edtGrundforderung.Name = "edtGrundforderung";
            this.edtGrundforderung.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGrundforderung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGrundforderung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundforderung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundforderung.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundforderung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundforderung.Properties.Appearance.Options.UseFont = true;
            this.edtGrundforderung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundforderung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGrundforderung.Properties.DisplayFormat.FormatString = "n2";
            this.edtGrundforderung.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGrundforderung.Properties.EditFormat.FormatString = "n2";
            this.edtGrundforderung.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtGrundforderung.Properties.Mask.EditMask = "N2";
            this.edtGrundforderung.Properties.Precision = 2;
            this.edtGrundforderung.Size = new System.Drawing.Size(100, 24);
            this.edtGrundforderung.TabIndex = 5;
            this.edtGrundforderung.EditValueChanged += new System.EventHandler(this.edtGrundforderung_EditValueChanged);
            // 
            // edtBetragProMonat
            // 
            this.edtBetragProMonat.DataMember = "BetragProMonat";
            this.edtBetragProMonat.DataSource = this.qryVerrechnung;
            this.edtBetragProMonat.Location = new System.Drawing.Point(146, 99);
            this.edtBetragProMonat.Name = "edtBetragProMonat";
            this.edtBetragProMonat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetragProMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetragProMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetragProMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetragProMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetragProMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetragProMonat.Properties.Appearance.Options.UseFont = true;
            this.edtBetragProMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetragProMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetragProMonat.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetragProMonat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragProMonat.Properties.EditFormat.FormatString = "n2";
            this.edtBetragProMonat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetragProMonat.Properties.Mask.EditMask = "N2";
            this.edtBetragProMonat.Properties.Precision = 2;
            this.edtBetragProMonat.Size = new System.Drawing.Size(100, 24);
            this.edtBetragProMonat.TabIndex = 7;
            this.edtBetragProMonat.EditValueChanged += new System.EventHandler(this.edtBetragProMonat_EditValueChanged);
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryVerrechnung;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(347, 69);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtDatumVon.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumVon.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtDatumVon.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumVon.Properties.Mask.EditMask = "MM.yyyy";
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(90, 24);
            this.edtDatumVon.TabIndex = 10;
            this.edtDatumVon.EditValueChanged += new System.EventHandler(this.edtDatumVon_EditValueChanged);
            // 
            // memBemerkungen
            // 
            this.memBemerkungen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.memBemerkungen.DataMember = "Bemerkung";
            this.memBemerkungen.DataSource = this.qryVerrechnung;
            this.memBemerkungen.Location = new System.Drawing.Point(146, 129);
            this.memBemerkungen.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.memBemerkungen.Name = "memBemerkungen";
            this.memBemerkungen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.memBemerkungen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.memBemerkungen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.memBemerkungen.Properties.Appearance.Options.UseBackColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseBorderColor = true;
            this.memBemerkungen.Properties.Appearance.Options.UseFont = true;
            this.memBemerkungen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.memBemerkungen.Size = new System.Drawing.Size(506, 69);
            this.memBemerkungen.TabIndex = 18;
            // 
            // edtLetzterMonat
            // 
            this.edtLetzterMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtLetzterMonat.DataMember = "LetzterMonat";
            this.edtLetzterMonat.DataSource = this.qryVerrechnung;
            this.edtLetzterMonat.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtLetzterMonat.Location = new System.Drawing.Point(562, 99);
            this.edtLetzterMonat.Name = "edtLetzterMonat";
            this.edtLetzterMonat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtLetzterMonat.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtLetzterMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLetzterMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLetzterMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtLetzterMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLetzterMonat.Properties.Appearance.Options.UseFont = true;
            this.edtLetzterMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLetzterMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtLetzterMonat.Properties.DisplayFormat.FormatString = "n2";
            this.edtLetzterMonat.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtLetzterMonat.Properties.EditFormat.FormatString = "n2";
            this.edtLetzterMonat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtLetzterMonat.Properties.Mask.EditMask = "n2";
            this.edtLetzterMonat.Properties.Precision = 2;
            this.edtLetzterMonat.Properties.ReadOnly = true;
            this.edtLetzterMonat.Size = new System.Drawing.Size(90, 24);
            this.edtLetzterMonat.TabIndex = 16;
            this.edtLetzterMonat.TabStop = false;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryVerrechnung;
            this.edtDatumBis.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(347, 99);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtDatumBis.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumBis.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtDatumBis.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtDatumBis.Properties.Mask.EditMask = "MM.yyyy";
            this.edtDatumBis.Properties.ReadOnly = true;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(90, 24);
            this.edtDatumBis.TabIndex = 12;
            this.edtDatumBis.TabStop = false;
            // 
            // lblGrundforderung
            // 
            this.lblGrundforderung.Location = new System.Drawing.Point(9, 69);
            this.lblGrundforderung.Name = "lblGrundforderung";
            this.lblGrundforderung.Size = new System.Drawing.Size(131, 24);
            this.lblGrundforderung.TabIndex = 4;
            this.lblGrundforderung.Text = "Grundforderung Betrag";
            this.lblGrundforderung.UseCompatibleTextRendering = true;
            // 
            // lblBetragProMonat
            // 
            this.lblBetragProMonat.Location = new System.Drawing.Point(9, 99);
            this.lblBetragProMonat.Name = "lblBetragProMonat";
            this.lblBetragProMonat.Size = new System.Drawing.Size(131, 24);
            this.lblBetragProMonat.TabIndex = 6;
            this.lblBetragProMonat.Text = "Monatlicher Betrag";
            this.lblBetragProMonat.UseCompatibleTextRendering = true;
            // 
            // lblDatumVon
            // 
            this.lblDatumVon.Location = new System.Drawing.Point(278, 69);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(63, 24);
            this.lblDatumVon.TabIndex = 9;
            this.lblDatumVon.Text = "Dauer von";
            this.lblDatumVon.UseCompatibleTextRendering = true;
            // 
            // lblGueltigBis
            // 
            this.lblGueltigBis.Location = new System.Drawing.Point(278, 99);
            this.lblGueltigBis.Name = "lblGueltigBis";
            this.lblGueltigBis.Size = new System.Drawing.Size(63, 24);
            this.lblGueltigBis.TabIndex = 11;
            this.lblGueltigBis.Text = "Dauer  bis";
            this.lblGueltigBis.UseCompatibleTextRendering = true;
            // 
            // lblBemerkungen
            // 
            this.lblBemerkungen.Location = new System.Drawing.Point(9, 129);
            this.lblBemerkungen.Name = "lblBemerkungen";
            this.lblBemerkungen.Size = new System.Drawing.Size(131, 24);
            this.lblBemerkungen.TabIndex = 17;
            this.lblBemerkungen.Text = "Bemerkung, Info";
            this.lblBemerkungen.UseCompatibleTextRendering = true;
            // 
            // lblVereinbarung
            // 
            this.lblVereinbarung.Location = new System.Drawing.Point(9, 39);
            this.lblVereinbarung.Name = "lblVereinbarung";
            this.lblVereinbarung.Size = new System.Drawing.Size(131, 24);
            this.lblVereinbarung.TabIndex = 2;
            this.lblVereinbarung.Text = "Vereinbarung vom";
            this.lblVereinbarung.UseCompatibleTextRendering = true;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(9, 9);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(112, 24);
            this.lblBaPersonID.TabIndex = 0;
            this.lblBaPersonID.Text = "Person, Gläubiger";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // lblLetzterMonat
            // 
            this.lblLetzterMonat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLetzterMonat.Location = new System.Drawing.Point(471, 99);
            this.lblLetzterMonat.Name = "lblLetzterMonat";
            this.lblLetzterMonat.Size = new System.Drawing.Size(85, 24);
            this.lblLetzterMonat.TabIndex = 15;
            this.lblLetzterMonat.Text = "Letzter Monat";
            this.lblLetzterMonat.UseCompatibleTextRendering = true;
            // 
            // edtAnnulliertAm
            // 
            this.edtAnnulliertAm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAnnulliertAm.DataMember = "AnnulliertAm";
            this.edtAnnulliertAm.DataSource = this.qryVerrechnung;
            this.edtAnnulliertAm.EditValue = null;
            this.edtAnnulliertAm.Location = new System.Drawing.Point(562, 204);
            this.edtAnnulliertAm.Margin = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.edtAnnulliertAm.Name = "edtAnnulliertAm";
            this.edtAnnulliertAm.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnnulliertAm.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnnulliertAm.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnnulliertAm.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnnulliertAm.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnnulliertAm.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnnulliertAm.Properties.Appearance.Options.UseFont = true;
            this.edtAnnulliertAm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAnnulliertAm.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtAnnulliertAm.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAnnulliertAm.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnnulliertAm.Properties.DisplayFormat.FormatString = "MM.yyyy";
            this.edtAnnulliertAm.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtAnnulliertAm.Properties.EditFormat.FormatString = "MM.yyyy";
            this.edtAnnulliertAm.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.edtAnnulliertAm.Properties.Mask.EditMask = "MM.yyyy";
            this.edtAnnulliertAm.Properties.ShowToday = false;
            this.edtAnnulliertAm.Size = new System.Drawing.Size(90, 24);
            this.edtAnnulliertAm.TabIndex = 20;
            this.edtAnnulliertAm.TabStop = false;
            // 
            // lblAnnullieren
            // 
            this.lblAnnullieren.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnnullieren.Location = new System.Drawing.Point(471, 204);
            this.lblAnnullieren.Name = "lblAnnullieren";
            this.lblAnnullieren.Size = new System.Drawing.Size(85, 24);
            this.lblAnnullieren.TabIndex = 19;
            this.lblAnnullieren.Text = "<Annullieren>";
            this.lblAnnullieren.UseCompatibleTextRendering = true;
            // 
            // lblVerrerechnungsArtRueckforderung
            // 
            this.lblVerrerechnungsArtRueckforderung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVerrerechnungsArtRueckforderung.Location = new System.Drawing.Point(278, 39);
            this.lblVerrerechnungsArtRueckforderung.Name = "lblVerrerechnungsArtRueckforderung";
            this.lblVerrerechnungsArtRueckforderung.Size = new System.Drawing.Size(374, 24);
            this.lblVerrerechnungsArtRueckforderung.TabIndex = 8;
            this.lblVerrerechnungsArtRueckforderung.Text = "Verrechnungsart: Rückforderung von Gläubiger";
            this.lblVerrerechnungsArtRueckforderung.UseCompatibleTextRendering = true;
            // 
            // qryPerson
            // 
            this.qryPerson.HostControl = this;
            // 
            // panDetails
            // 
            this.panDetails.Controls.Add(this.lblAnzahlMonate);
            this.panDetails.Controls.Add(this.edtAnzahlMonate);
            this.panDetails.Controls.Add(this.lblBaPersonID);
            this.panDetails.Controls.Add(this.lblVerrerechnungsArtRueckforderung);
            this.panDetails.Controls.Add(this.edtBaPersonID);
            this.panDetails.Controls.Add(this.lblAnnullieren);
            this.panDetails.Controls.Add(this.edtVereinbarungVom);
            this.panDetails.Controls.Add(this.edtAnnulliertAm);
            this.panDetails.Controls.Add(this.edtGrundforderung);
            this.panDetails.Controls.Add(this.edtBetragProMonat);
            this.panDetails.Controls.Add(this.edtDatumVon);
            this.panDetails.Controls.Add(this.memBemerkungen);
            this.panDetails.Controls.Add(this.lblLetzterMonat);
            this.panDetails.Controls.Add(this.edtLetzterMonat);
            this.panDetails.Controls.Add(this.lblVereinbarung);
            this.panDetails.Controls.Add(this.edtDatumBis);
            this.panDetails.Controls.Add(this.lblBemerkungen);
            this.panDetails.Controls.Add(this.lblGrundforderung);
            this.panDetails.Controls.Add(this.lblGueltigBis);
            this.panDetails.Controls.Add(this.lblBetragProMonat);
            this.panDetails.Controls.Add(this.lblDatumVon);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 231);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(661, 237);
            this.panDetails.TabIndex = 1;
            // 
            // lblAnzahlMonate
            // 
            this.lblAnzahlMonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzahlMonate.Location = new System.Drawing.Point(471, 69);
            this.lblAnzahlMonate.Name = "lblAnzahlMonate";
            this.lblAnzahlMonate.Size = new System.Drawing.Size(85, 24);
            this.lblAnzahlMonate.TabIndex = 13;
            this.lblAnzahlMonate.Text = "Anzahl Monate";
            this.lblAnzahlMonate.UseCompatibleTextRendering = true;
            // 
            // edtAnzahlMonate
            // 
            this.edtAnzahlMonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edtAnzahlMonate.DataMember = "AnzahlMonate";
            this.edtAnzahlMonate.DataSource = this.qryVerrechnung;
            this.edtAnzahlMonate.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtAnzahlMonate.Location = new System.Drawing.Point(562, 69);
            this.edtAnzahlMonate.Name = "edtAnzahlMonate";
            this.edtAnzahlMonate.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtAnzahlMonate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAnzahlMonate.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnzahlMonate.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnzahlMonate.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnzahlMonate.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnzahlMonate.Properties.Appearance.Options.UseFont = true;
            this.edtAnzahlMonate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnzahlMonate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAnzahlMonate.Properties.DisplayFormat.FormatString = "n0";
            this.edtAnzahlMonate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlMonate.Properties.EditFormat.FormatString = "n0";
            this.edtAnzahlMonate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtAnzahlMonate.Properties.Mask.EditMask = "n0";
            this.edtAnzahlMonate.Properties.Precision = 2;
            this.edtAnzahlMonate.Properties.ReadOnly = true;
            this.edtAnzahlMonate.Size = new System.Drawing.Size(90, 24);
            this.edtAnzahlMonate.TabIndex = 14;
            this.edtAnzahlMonate.TabStop = false;
            // 
            // CtlIkMonatszahlenVerrechnung
            // 
            this.ActiveSQLQuery = this.qryVerrechnung;
            this.Controls.Add(this.grdVerrechnung);
            this.Controls.Add(this.panDetails);
            this.Name = "CtlIkMonatszahlenVerrechnung";
            this.Size = new System.Drawing.Size(661, 468);
            this.VisibleChanged += new System.EventHandler(this.CtlIkMonatszahlenVerrechnung_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.grdVerrechnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryVerrechnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVerrechnung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVereinbarungVom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundforderung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetragProMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memBemerkungen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLetzterMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundforderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragProMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGueltigBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkungen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVereinbarung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLetzterMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnnulliertAm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnnullieren)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerrerechnungsArtRueckforderung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPerson)).EndInit();
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlMonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnzahlMonate.Properties)).EndInit();
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

        private System.Windows.Forms.Panel panDetails;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoVerrechnunsKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colAnnulliertAm;
        private DevExpress.XtraGrid.Columns.GridColumn colIstErledigt;
        private Gui.KissLabel lblAnzahlMonate;
        private Gui.KissCalcEdit edtAnzahlMonate;
    }
}
