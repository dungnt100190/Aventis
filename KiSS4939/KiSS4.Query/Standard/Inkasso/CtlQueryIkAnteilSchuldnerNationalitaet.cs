
namespace KiSS4.Query
{
    public class CtlQueryIkAnteilSchuldnerNationalitaet : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlSchuldner;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBemuehungText;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumAnpassenAb;
        private DevExpress.XtraGrid.Columns.GridColumn colElterlicheSorgeBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlaeubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colIkForderungID;
        private DevExpress.XtraGrid.Columns.GridColumn colIkGlaeubigerID;
        private DevExpress.XtraGrid.Columns.GridColumn colIkRechtstitelID;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassoFallName;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassoTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassotypUnterart;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatsBevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSARName;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterart;
        private DevExpress.XtraGrid.Columns.GridColumn colVerjaehrungAm;
        private DevExpress.XtraGrid.Columns.GridColumn colprozentualerAnteil;
        private DevExpress.XtraGrid.Columns.GridColumn coltotalSchuldner;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTyp;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTypUnterart;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblInkassoTypUnterart;
        private KiSS4.Gui.KissLabel lblUserID;
        private KiSS4.Gui.KissLabel lblinkassoTyp;

        #endregion

        #region Constructors

        public CtlQueryIkAnteilSchuldnerNationalitaet()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryIkAnteilSchuldnerNationalitaet));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtInkassoTyp = new KiSS4.Gui.KissLookUpEdit();
            this.edtInkassoTypUnterart = new KiSS4.Gui.KissLookUpEdit();
            this.lblUserID = new KiSS4.Gui.KissLabel();
            this.lblinkassoTyp = new KiSS4.Gui.KissLabel();
            this.lblInkassoTypUnterart = new KiSS4.Gui.KissLabel();
            this.colAnzahlSchuldner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemuehungText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumAnpassenAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colElterlicheSorgeBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlaeubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkForderungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkGlaeubigerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkRechtstitelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassoFallName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassoTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassotypUnterart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatsBevorschussung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprozentualerAnteil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotalSchuldner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerjaehrungAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblinkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInkassoTypUnterart)).BeginInit();
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
            this.grvQuery1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvQuery1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery1.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery1.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
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
            this.ctlGotoFall.Visible = false;
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.lblInkassoTypUnterart);
            this.tpgSuchen.Controls.Add(this.lblinkassoTyp);
            this.tpgSuchen.Controls.Add(this.lblUserID);
            this.tpgSuchen.Controls.Add(this.edtInkassoTypUnterart);
            this.tpgSuchen.Controls.Add(this.edtInkassoTyp);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTypUnterart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblinkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblInkassoTypUnterart, 0);
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(251, 63);
            this.edtUserID.LookupSQL = "select ID = UserID, \r\nSAR = LastName + isNull(\', \' + FirstName,\'\'), \r\n[Kuerzel] =" +
                " LogonName\nfrom   XUser \r\nwhere LastName + isNull(\', \' + FirstName,\'\') like isNu" +
                "ll({0},\'\') + \'%\' \norder by SAR";
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(271, 24);
            this.edtUserID.TabIndex = 1;
            //
            // edtInkassoTyp
            //
            this.edtInkassoTyp.Location = new System.Drawing.Point(251, 93);
            this.edtInkassoTyp.LOVFilter = "Code between 400 and 499";
            this.edtInkassoTyp.LOVFilterWhereAppend = true;
            this.edtInkassoTyp.LOVName = "FaProzess";
            this.edtInkassoTyp.Name = "edtInkassoTyp";
            this.edtInkassoTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInkassoTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInkassoTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInkassoTyp.Properties.Appearance.Options.UseFont = true;
            this.edtInkassoTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtInkassoTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtInkassoTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtInkassoTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassoTyp.Properties.NullText = "";
            this.edtInkassoTyp.Properties.ShowFooter = false;
            this.edtInkassoTyp.Properties.ShowHeader = false;
            this.edtInkassoTyp.Size = new System.Drawing.Size(271, 24);
            this.edtInkassoTyp.TabIndex = 2;
            //
            // edtInkassoTypUnterart
            //
            this.edtInkassoTypUnterart.Location = new System.Drawing.Point(251, 123);
            this.edtInkassoTypUnterart.LOVFilter = "code between 40000 and 49000";
            this.edtInkassoTypUnterart.LOVFilterWhereAppend = true;
            this.edtInkassoTypUnterart.LOVName = "Eroeffnungsgrund";
            this.edtInkassoTypUnterart.Name = "edtInkassoTypUnterart";
            this.edtInkassoTypUnterart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInkassoTypUnterart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInkassoTypUnterart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTypUnterart.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassoTypUnterart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInkassoTypUnterart.Properties.Appearance.Options.UseFont = true;
            this.edtInkassoTypUnterart.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtInkassoTypUnterart.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassoTypUnterart.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtInkassoTypUnterart.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtInkassoTypUnterart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtInkassoTypUnterart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtInkassoTypUnterart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassoTypUnterart.Properties.NullText = "";
            this.edtInkassoTypUnterart.Properties.ShowFooter = false;
            this.edtInkassoTypUnterart.Properties.ShowHeader = false;
            this.edtInkassoTypUnterart.Size = new System.Drawing.Size(271, 24);
            this.edtInkassoTypUnterart.TabIndex = 3;
            //
            // lblUserID
            //
            this.lblUserID.Location = new System.Drawing.Point(32, 63);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(142, 24);
            this.lblUserID.TabIndex = 4;
            this.lblUserID.Text = "SAR";
            this.lblUserID.UseCompatibleTextRendering = true;
            //
            // lblinkassoTyp
            //
            this.lblinkassoTyp.Location = new System.Drawing.Point(32, 93);
            this.lblinkassoTyp.Name = "lblinkassoTyp";
            this.lblinkassoTyp.Size = new System.Drawing.Size(142, 24);
            this.lblinkassoTyp.TabIndex = 5;
            this.lblinkassoTyp.Text = "Inkasso-Typ";
            this.lblinkassoTyp.UseCompatibleTextRendering = true;
            //
            // lblInkassoTypUnterart
            //
            this.lblInkassoTypUnterart.Location = new System.Drawing.Point(32, 123);
            this.lblInkassoTypUnterart.Name = "lblInkassoTypUnterart";
            this.lblInkassoTypUnterart.Size = new System.Drawing.Size(142, 24);
            this.lblInkassoTypUnterart.TabIndex = 6;
            this.lblInkassoTypUnterart.Text = "Inkasso-Typ Unterart";
            this.lblInkassoTypUnterart.UseCompatibleTextRendering = true;
            //
            // colAnzahlSchuldner
            //
            this.colAnzahlSchuldner.Name = "colAnzahlSchuldner";
            //
            // colArchiv
            //
            this.colArchiv.Name = "colArchiv";
            //
            // colBemuehungText
            //
            this.colBemuehungText.Name = "colBemuehungText";
            //
            // colDatumAnpassenAb
            //
            this.colDatumAnpassenAb.Name = "colDatumAnpassenAb";
            //
            // colElterlicheSorgeBemerkung
            //
            this.colElterlicheSorgeBemerkung.Name = "colElterlicheSorgeBemerkung";
            //
            // colFaLeistungID
            //
            this.colFaLeistungID.Name = "colFaLeistungID";
            //
            // colGeburtsdatum
            //
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            //
            // colGlaeubiger
            //
            this.colGlaeubiger.Name = "colGlaeubiger";
            //
            // colIkForderungID
            //
            this.colIkForderungID.Name = "colIkForderungID";
            //
            // colIkGlaeubigerID
            //
            this.colIkGlaeubigerID.Name = "colIkGlaeubigerID";
            //
            // colIkRechtstitelID
            //
            this.colIkRechtstitelID.Name = "colIkRechtstitelID";
            //
            // colInkassoFallName
            //
            this.colInkassoFallName.Name = "colInkassoFallName";
            //
            // colInkassoTyp
            //
            this.colInkassoTyp.Name = "colInkassoTyp";
            //
            // colInkassotypUnterart
            //
            this.colInkassotypUnterart.Name = "colInkassotypUnterart";
            //
            // colMonatsBevorschussung
            //
            this.colMonatsBevorschussung.Name = "colMonatsBevorschussung";
            //
            // colNationalitt
            //
            this.colNationalitt.Name = "colNationalitt";
            //
            // colprozentualerAnteil
            //
            this.colprozentualerAnteil.Name = "colprozentualerAnteil";
            //
            // colSAR
            //
            this.colSAR.Name = "colSAR";
            //
            // colSARName
            //
            this.colSARName.Name = "colSARName";
            //
            // colSchuldner
            //
            this.colSchuldner.Name = "colSchuldner";
            //
            // colStatus
            //
            this.colStatus.Name = "colStatus";
            //
            // coltotalSchuldner
            //
            this.coltotalSchuldner.Name = "coltotalSchuldner";
            //
            // colUnterart
            //
            this.colUnterart.Name = "colUnterart";
            //
            // colVerjaehrungAm
            //
            this.colVerjaehrungAm.Name = "colVerjaehrungAm";
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
            // CtlQueryIkAnteilSchuldnerNationalitaet
            //
            this.Name = "CtlQueryIkAnteilSchuldnerNationalitaet";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblinkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Protected Methods

        protected override void RunSearch()
        {
            grvQuery1.Columns.Clear();

            base.RunSearch();
        }

        #endregion
    }
}