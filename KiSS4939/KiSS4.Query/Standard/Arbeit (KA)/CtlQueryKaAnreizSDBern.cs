using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    public class CtlQueryKaAnreizSDBern : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAHVNr;
        private DevExpress.XtraGrid.Columns.GridColumn colAdresse;
        private DevExpress.XtraGrid.Columns.GridColumn colAnsatz;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlTageimProjekt;
        private DevExpress.XtraGrid.Columns.GridColumn colAustritt;
        private DevExpress.XtraGrid.Columns.GridColumn colBankname;
        private DevExpress.XtraGrid.Columns.GridColumn colBeschftigungsgrad;
        private DevExpress.XtraGrid.Columns.GridColumn colEintrittsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colKontonummer;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colNiveau;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPLZ;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalbetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colVorname;
        private DevExpress.XtraGrid.Columns.GridColumn colZustndigerSozialdienst;
        private KiSS4.Gui.KissLookUpEdit edtMonat;
        private KiSS4.Gui.KissButtonEdit edtNameSTESID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblMonat;
        private KiSS4.Gui.KissLabel lblNameSTES;

        #endregion

        #region Constructors

        public CtlQueryKaAnreizSDBern()
        {
            this.InitializeComponent();

            edtMonat.LoadQuery(DBUtil.OpenSQL(@"
                    select  Code = 1, Text = 'Jan' union all
                    select  2, 'Feb' union all
                    select  3, 'März' union all
                    select  4, 'Apr' union all
                    select  5, 'Mai' union all
                    select  6, 'Juni' union all
                    select  7, 'Juli' union all
                    select  8, 'Aug' union all
                    select  9, 'Sep' union all
                    select 10, 'Okt' union all
                    select 11, 'Nov' union all
                    select 12, 'Dez'"));
            edtMonat.EditValue = System.DateTime.Today.Month;
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKaAnreizSDBern));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblMonat = new KiSS4.Gui.KissLabel();
            this.edtMonat = new KiSS4.Gui.KissLookUpEdit();
            this.lblNameSTES = new KiSS4.Gui.KissLabel();
            this.edtNameSTESID = new KiSS4.Gui.KissButtonEdit();
            this.colAdresse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAHVNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnsatz = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlTageimProjekt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustritt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBankname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeschftigungsgrad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEintrittsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKontonummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNiveau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPLZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalbetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVorname = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZustndigerSozialdienst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSTES)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSTESID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtNameSTESID);
            this.tpgSuchen.Controls.Add(this.lblNameSTES);
            this.tpgSuchen.Controls.Add(this.edtMonat);
            this.tpgSuchen.Controls.Add(this.lblMonat);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblMonat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtMonat, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblNameSTES, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNameSTESID, 0);
            // 
            // lblMonat
            // 
            this.lblMonat.Location = new System.Drawing.Point(7, 45);
            this.lblMonat.Name = "lblMonat";
            this.lblMonat.Size = new System.Drawing.Size(96, 24);
            this.lblMonat.TabIndex = 1;
            this.lblMonat.Text = "Monat";
            this.lblMonat.UseCompatibleTextRendering = true;
            // 
            // edtMonat
            // 
            this.edtMonat.Location = new System.Drawing.Point(109, 45);
            this.edtMonat.Name = "edtMonat";
            this.edtMonat.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMonat.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMonat.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMonat.Properties.Appearance.Options.UseBackColor = true;
            this.edtMonat.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMonat.Properties.Appearance.Options.UseFont = true;
            this.edtMonat.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtMonat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtMonat.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtMonat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtMonat.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtMonat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtMonat.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMonat.Properties.NullText = "";
            this.edtMonat.Properties.ShowFooter = false;
            this.edtMonat.Properties.ShowHeader = false;
            this.edtMonat.Size = new System.Drawing.Size(63, 24);
            this.edtMonat.TabIndex = 2;
            // 
            // lblNameSTES
            // 
            this.lblNameSTES.Location = new System.Drawing.Point(7, 75);
            this.lblNameSTES.Name = "lblNameSTES";
            this.lblNameSTES.Size = new System.Drawing.Size(96, 24);
            this.lblNameSTES.TabIndex = 3;
            this.lblNameSTES.Text = "Name STES";
            this.lblNameSTES.UseCompatibleTextRendering = true;
            // 
            // edtNameSTESID
            // 
            this.edtNameSTESID.Location = new System.Drawing.Point(109, 75);
            this.edtNameSTESID.Name = "edtNameSTESID";
            this.edtNameSTESID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNameSTESID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNameSTESID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNameSTESID.Properties.Appearance.Options.UseBackColor = true;
            this.edtNameSTESID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNameSTESID.Properties.Appearance.Options.UseFont = true;
            this.edtNameSTESID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtNameSTESID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtNameSTESID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNameSTESID.Size = new System.Drawing.Size(250, 24);
            this.edtNameSTESID.TabIndex = 4;
            this.edtNameSTESID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtNameSTESID_UserModifiedFld);
            // 
            // colAdresse
            // 
            this.colAdresse.Name = "colAdresse";
            // 
            // colAHVNr
            // 
            this.colAHVNr.Name = "colAHVNr";
            // 
            // colAnsatz
            // 
            this.colAnsatz.Name = "colAnsatz";
            // 
            // colAnzahlTageimProjekt
            // 
            this.colAnzahlTageimProjekt.Name = "colAnzahlTageimProjekt";
            // 
            // colAustritt
            // 
            this.colAustritt.Name = "colAustritt";
            // 
            // colBankname
            // 
            this.colBankname.Name = "colBankname";
            // 
            // colBeschftigungsgrad
            // 
            this.colBeschftigungsgrad.Name = "colBeschftigungsgrad";
            // 
            // colEintrittsdatum
            // 
            this.colEintrittsdatum.Name = "colEintrittsdatum";
            // 
            // colKontonummer
            // 
            this.colKontonummer.Name = "colKontonummer";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            // 
            // colNiveau
            // 
            this.colNiveau.Name = "colNiveau";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPLZ
            // 
            this.colPLZ.Name = "colPLZ";
            // 
            // colSAR
            // 
            this.colSAR.Name = "colSAR";
            // 
            // colTotalbetrag
            // 
            this.colTotalbetrag.Name = "colTotalbetrag";
            // 
            // colVorname
            // 
            this.colVorname.Name = "colVorname";
            // 
            // colZustndigerSozialdienst
            // 
            this.colZustndigerSozialdienst.Name = "colZustndigerSozialdienst";
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
            // CtlQueryKaAnreizSDBern
            // 
            this.Name = "CtlQueryKaAnreizSDBern";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMonat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNameSTES)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNameSTESID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtMonat.EditValue = System.DateTime.Today.Month;
            edtNameSTESID.EditValue = null;
            edtNameSTESID.LookupID = null;
        }

        protected override void RunSearch()
        {
            if (DBUtil.IsEmpty(edtMonat.EditValue))
            {
                edtMonat.EditValue = System.DateTime.Today.Month;
            }

            base.RunSearch();
        }

        #endregion

        #region Private Methods

        private void edtNameSTESID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtNameSTESID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtNameSTESID.EditValue = null;
                    edtNameSTESID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.PersonSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtNameSTESID.EditValue = dlg["Name"];
                edtNameSTESID.LookupID = dlg["BaPersonID"];
            }
        }

        #endregion
    }
}