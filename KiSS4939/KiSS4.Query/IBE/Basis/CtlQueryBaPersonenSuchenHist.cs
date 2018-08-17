using KiSS4.DB;

namespace KiSS4.Query.IBE
{
    public class CtlQueryBaPersonenSuchenHist : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAHVNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colAuslnderStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colAuslnderStatusDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colAuslnderStatusGueltigBis;
        private DevExpress.XtraGrid.Columns.GridColumn colBFFNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colEMail;
        private DevExpress.XtraGrid.Columns.GridColumn colFT;
        private DevExpress.XtraGrid.Columns.GridColumn colFax;
        private DevExpress.XtraGrid.Columns.GridColumn colFruehererName;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colHeimatgemeinde;
        private DevExpress.XtraGrid.Columns.GridColumn colKonfession;
        private DevExpress.XtraGrid.Columns.GridColumn colMobilTel;
        private DevExpress.XtraGrid.Columns.GridColumn colNNr;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSterbedatum;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonG;
        private DevExpress.XtraGrid.Columns.GridColumn colTelefonP;
        private DevExpress.XtraGrid.Columns.GridColumn colTitel;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname2;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstand;
        private DevExpress.XtraGrid.Columns.GridColumn colZivilstandDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colnderungdurch;
        private DevExpress.XtraGrid.Columns.GridColumn colnderungsdatum1;
        private KiSS4.Gui.KissTextEdit edtAHV;
        private KiSS4.Gui.KissDateEdit edtGeburtBis;
        private KiSS4.Gui.KissDateEdit edtGeburtVon;
        private KiSS4.Gui.KissTextEdit edtNNr;
        private KiSS4.Gui.KissTextEdit edtName;
        private KiSS4.Gui.KissTextEdit edtVersNr;
        private KiSS4.Gui.KissTextEdit edtVorname;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblAHV;
        private KiSS4.Gui.KissLabel lblGeburtsdatumvon;
        private KiSS4.Gui.KissLabel lblNNr;
        private KiSS4.Gui.KissLabel lblName;
        private KiSS4.Gui.KissLabel lblVersNr;
        private KiSS4.Gui.KissLabel lblVorname;
        private Gui.KissTextEdit edtHaushaltVersNr;
        private Gui.KissLabel lblHaushaltVersNr;
        private KiSS4.Gui.KissLabel lblbis;

        #endregion

        #region Constructors

        public CtlQueryBaPersonenSuchenHist()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaPersonenSuchenHist));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblName = new KiSS4.Gui.KissLabel();
            this.lblVorname = new KiSS4.Gui.KissLabel();
            this.lblGeburtsdatumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblAHV = new KiSS4.Gui.KissLabel();
            this.lblNNr = new KiSS4.Gui.KissLabel();
            this.edtName = new KiSS4.Gui.KissTextEdit();
            this.edtVorname = new KiSS4.Gui.KissTextEdit();
            this.edtGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.edtGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.edtAHV = new KiSS4.Gui.KissTextEdit();
            this.edtNNr = new KiSS4.Gui.KissTextEdit();
            this.colAHVNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuslnderStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuslnderStatusDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAuslnderStatusGueltigBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBFFNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEMail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFruehererName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHeimatgemeinde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonfession = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMobilTel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnderungdurch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colnderungsdatum1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSterbedatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelefonP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTitel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstand = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZivilstandDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtVersNr = new KiSS4.Gui.KissTextEdit();
            this.lblVersNr = new KiSS4.Gui.KissLabel();
            this.edtHaushaltVersNr = new KiSS4.Gui.KissTextEdit();
            this.lblHaushaltVersNr = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaushaltVersNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushaltVersNr)).BeginInit();
            this.SuspendLayout();
            // 
            // qryQuery
            // 
            this.qryQuery.SelectStatement = resources.GetString("qryQuery.SelectStatement");
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
            // grdQuery1
            // 
            // 
            // 
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
            this.ctlGotoFall.Location = new System.Drawing.Point(0, 398);
            this.ctlGotoFall.Size = new System.Drawing.Size(158, 26);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtHaushaltVersNr);
            this.tpgSuchen.Controls.Add(this.lblHaushaltVersNr);
            this.tpgSuchen.Controls.Add(this.edtVersNr);
            this.tpgSuchen.Controls.Add(this.lblVersNr);
            this.tpgSuchen.Controls.Add(this.edtNNr);
            this.tpgSuchen.Controls.Add(this.edtAHV);
            this.tpgSuchen.Controls.Add(this.edtGeburtBis);
            this.tpgSuchen.Controls.Add(this.edtGeburtVon);
            this.tpgSuchen.Controls.Add(this.edtVorname);
            this.tpgSuchen.Controls.Add(this.edtName);
            this.tpgSuchen.Controls.Add(this.lblNNr);
            this.tpgSuchen.Controls.Add(this.lblAHV);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblGeburtsdatumvon);
            this.tpgSuchen.Controls.Add(this.lblVorname);
            this.tpgSuchen.Controls.Add(this.lblName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.lblName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblGeburtsdatumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAHV, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAHV, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblHaushaltVersNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtHaushaltVersNr, 0);
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(10, 40);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(130, 24);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name";
            this.lblName.UseCompatibleTextRendering = true;
            // 
            // lblVorname
            // 
            this.lblVorname.Location = new System.Drawing.Point(10, 70);
            this.lblVorname.Name = "lblVorname";
            this.lblVorname.Size = new System.Drawing.Size(130, 24);
            this.lblVorname.TabIndex = 3;
            this.lblVorname.Text = "Vorname";
            this.lblVorname.UseCompatibleTextRendering = true;
            // 
            // lblGeburtsdatumvon
            // 
            this.lblGeburtsdatumvon.Location = new System.Drawing.Point(10, 100);
            this.lblGeburtsdatumvon.Name = "lblGeburtsdatumvon";
            this.lblGeburtsdatumvon.Size = new System.Drawing.Size(130, 24);
            this.lblGeburtsdatumvon.TabIndex = 5;
            this.lblGeburtsdatumvon.Text = "Geburtsdatum von";
            this.lblGeburtsdatumvon.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(277, 100);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 7;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // lblAHV
            // 
            this.lblAHV.Location = new System.Drawing.Point(10, 130);
            this.lblAHV.Name = "lblAHV";
            this.lblAHV.Size = new System.Drawing.Size(130, 24);
            this.lblAHV.TabIndex = 9;
            this.lblAHV.Text = "AHV-Nr.";
            this.lblAHV.UseCompatibleTextRendering = true;
            // 
            // lblNNr
            // 
            this.lblNNr.Location = new System.Drawing.Point(10, 220);
            this.lblNNr.Name = "lblNNr";
            this.lblNNr.Size = new System.Drawing.Size(130, 24);
            this.lblNNr.TabIndex = 15;
            this.lblNNr.Text = "N-Nr";
            this.lblNNr.UseCompatibleTextRendering = true;
            // 
            // edtName
            // 
            this.edtName.Location = new System.Drawing.Point(157, 40);
            this.edtName.Name = "edtName";
            this.edtName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtName.Properties.Appearance.Options.UseBackColor = true;
            this.edtName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtName.Properties.Appearance.Options.UseFont = true;
            this.edtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtName.Size = new System.Drawing.Size(250, 24);
            this.edtName.TabIndex = 2;
            // 
            // edtVorname
            // 
            this.edtVorname.Location = new System.Drawing.Point(157, 70);
            this.edtVorname.Name = "edtVorname";
            this.edtVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVorname.Properties.Appearance.Options.UseFont = true;
            this.edtVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVorname.Size = new System.Drawing.Size(250, 24);
            this.edtVorname.TabIndex = 4;
            // 
            // edtGeburtVon
            // 
            this.edtGeburtVon.EditValue = "";
            this.edtGeburtVon.Location = new System.Drawing.Point(157, 100);
            this.edtGeburtVon.Name = "edtGeburtVon";
            this.edtGeburtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtVon.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtGeburtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtGeburtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtVon.Properties.ShowToday = false;
            this.edtGeburtVon.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtVon.TabIndex = 6;
            // 
            // edtGeburtBis
            // 
            this.edtGeburtBis.EditValue = "";
            this.edtGeburtBis.Location = new System.Drawing.Point(307, 100);
            this.edtGeburtBis.Name = "edtGeburtBis";
            this.edtGeburtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtGeburtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtBis.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtGeburtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtGeburtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtGeburtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtGeburtBis.Properties.ShowToday = false;
            this.edtGeburtBis.Size = new System.Drawing.Size(100, 24);
            this.edtGeburtBis.TabIndex = 8;
            // 
            // edtAHV
            // 
            this.edtAHV.Location = new System.Drawing.Point(157, 130);
            this.edtAHV.Name = "edtAHV";
            this.edtAHV.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAHV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAHV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAHV.Properties.Appearance.Options.UseBackColor = true;
            this.edtAHV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAHV.Properties.Appearance.Options.UseFont = true;
            this.edtAHV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAHV.Size = new System.Drawing.Size(250, 24);
            this.edtAHV.TabIndex = 10;
            // 
            // edtNNr
            // 
            this.edtNNr.Location = new System.Drawing.Point(157, 220);
            this.edtNNr.Name = "edtNNr";
            this.edtNNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtNNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNNr.Properties.Appearance.Options.UseFont = true;
            this.edtNNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNNr.Size = new System.Drawing.Size(250, 24);
            this.edtNNr.TabIndex = 16;
            // 
            // colAHVNummer
            // 
            this.colAHVNummer.Name = "colAHVNummer";
            // 
            // colAuslnderStatus
            // 
            this.colAuslnderStatus.Name = "colAuslnderStatus";
            // 
            // colAuslnderStatusDatum
            // 
            this.colAuslnderStatusDatum.Name = "colAuslnderStatusDatum";
            // 
            // colAuslnderStatusGueltigBis
            // 
            this.colAuslnderStatusGueltigBis.Name = "colAuslnderStatusGueltigBis";
            // 
            // colBFFNummer
            // 
            this.colBFFNummer.Name = "colBFFNummer";
            // 
            // colEMail
            // 
            this.colEMail.Name = "colEMail";
            // 
            // colFax
            // 
            this.colFax.Name = "colFax";
            // 
            // colFruehererName
            // 
            this.colFruehererName.Name = "colFruehererName";
            // 
            // colFT
            // 
            this.colFT.Name = "colFT";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGeschlecht
            // 
            this.colGeschlecht.Name = "colGeschlecht";
            // 
            // colHeimatgemeinde
            // 
            this.colHeimatgemeinde.Name = "colHeimatgemeinde";
            // 
            // colKonfession
            // 
            this.colKonfession.Name = "colKonfession";
            // 
            // colMobilTel
            // 
            this.colMobilTel.Name = "colMobilTel";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colnderungdurch
            // 
            this.colnderungdurch.Name = "colnderungdurch";
            // 
            // colnderungsdatum1
            // 
            this.colnderungsdatum1.Name = "colnderungsdatum1";
            // 
            // colNNr
            // 
            this.colNNr.Name = "colNNr";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colSterbedatum
            // 
            this.colSterbedatum.Name = "colSterbedatum";
            // 
            // colStrasse
            // 
            this.colStrasse.Name = "colStrasse";
            // 
            // colTelefonG
            // 
            this.colTelefonG.Name = "colTelefonG";
            // 
            // colTelefonP
            // 
            this.colTelefonP.Name = "colTelefonP";
            // 
            // colTitel
            // 
            this.colTitel.Name = "colTitel";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // colVorname2
            // 
            this.colVorname2.Name = "colVorname2";
            // 
            // colZivilstand
            // 
            this.colZivilstand.Name = "colZivilstand";
            // 
            // colZivilstandDatum
            // 
            this.colZivilstandDatum.Name = "colZivilstandDatum";
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
            // edtVersNr
            // 
            this.edtVersNr.Location = new System.Drawing.Point(157, 160);
            this.edtVersNr.Name = "edtVersNr";
            this.edtVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVersNr.Size = new System.Drawing.Size(250, 24);
            this.edtVersNr.TabIndex = 12;
            // 
            // lblVersNr
            // 
            this.lblVersNr.Location = new System.Drawing.Point(10, 160);
            this.lblVersNr.Name = "lblVersNr";
            this.lblVersNr.Size = new System.Drawing.Size(130, 24);
            this.lblVersNr.TabIndex = 11;
            this.lblVersNr.Text = "Versicherten Nr.";
            this.lblVersNr.UseCompatibleTextRendering = true;
            // 
            // edtHaushaltVersNr
            // 
            this.edtHaushaltVersNr.Location = new System.Drawing.Point(157, 190);
            this.edtHaushaltVersNr.Name = "edtHaushaltVersNr";
            this.edtHaushaltVersNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtHaushaltVersNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtHaushaltVersNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtHaushaltVersNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtHaushaltVersNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtHaushaltVersNr.Properties.Appearance.Options.UseFont = true;
            this.edtHaushaltVersNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtHaushaltVersNr.Size = new System.Drawing.Size(250, 24);
            this.edtHaushaltVersNr.TabIndex = 14;
            // 
            // lblHaushaltVersNr
            // 
            this.lblHaushaltVersNr.Location = new System.Drawing.Point(10, 190);
            this.lblHaushaltVersNr.Name = "lblHaushaltVersNr";
            this.lblHaushaltVersNr.Size = new System.Drawing.Size(141, 24);
            this.lblHaushaltVersNr.TabIndex = 13;
            this.lblHaushaltVersNr.Text = "Haushaltversicherung Nr.";
            this.lblHaushaltVersNr.UseCompatibleTextRendering = true;
            // 
            // CtlQueryBaPersonenSuchenHist
            // 
            this.Name = "CtlQueryBaPersonenSuchenHist";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAHV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAHV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVersNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHaushaltVersNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHaushaltVersNr)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            // replace search parameters
            object[] parameters = new object[]{Session.User.LogonName};
            this.kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion
    }
}