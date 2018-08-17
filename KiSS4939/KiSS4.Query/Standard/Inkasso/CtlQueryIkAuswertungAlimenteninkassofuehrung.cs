
namespace KiSS4.Query
{
    public class CtlQueryIkAuswertungAlimenteninkassofuehrung : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colBegrndungErreichungsgradinZeitperiode;
        private DevExpress.XtraGrid.Columns.GridColumn colEinnahmenquoteperStichtag;
        private DevExpress.XtraGrid.Columns.GridColumn colErffnet;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterartAlimenteninkasso;
        private KiSS4.Gui.KissLookUpEdit edtBegruendung;
        private KiSS4.Gui.KissLookUpEdit edtEinnahmenquote;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTypUnterart;
        private KiSS4.Gui.KissLookUpEdit edtInkassofallStatus;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lbEinnahmenquote;
        private KiSS4.Gui.KissLabel lblBegruendung;
        private KiSS4.Gui.KissLabel lblInkassoTypUnterart;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblUserID;

        #endregion

        #region Constructors

        public CtlQueryIkAuswertungAlimenteninkassofuehrung()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryIkAuswertungAlimenteninkassofuehrung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.edtInkassoTypUnterart = new KiSS4.Gui.KissLookUpEdit();
            this.edtInkassofallStatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtEinnahmenquote = new KiSS4.Gui.KissLookUpEdit();
            this.edtBegruendung = new KiSS4.Gui.KissLookUpEdit();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.lblInkassoTypUnterart = new KiSS4.Gui.KissLabel();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.lbEinnahmenquote = new KiSS4.Gui.KissLabel();
            this.lblBegruendung = new KiSS4.Gui.KissLabel();
            this.lblUserID = new KiSS4.Gui.KissLabel();
            this.colBegrndungErreichungsgradinZeitperiode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinnahmenquoteperStichtag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErffnet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterartAlimenteninkasso = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinnahmenquote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinnahmenquote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBegruendung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBegruendung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInkassoTypUnterart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbEinnahmenquote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegruendung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).BeginInit();
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
            this.tpgSuchen.Controls.Add(this.lblUserID);
            this.tpgSuchen.Controls.Add(this.lblBegruendung);
            this.tpgSuchen.Controls.Add(this.lbEinnahmenquote);
            this.tpgSuchen.Controls.Add(this.lblStatus);
            this.tpgSuchen.Controls.Add(this.lblInkassoTypUnterart);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.edtBegruendung);
            this.tpgSuchen.Controls.Add(this.edtEinnahmenquote);
            this.tpgSuchen.Controls.Add(this.edtInkassofallStatus);
            this.tpgSuchen.Controls.Add(this.edtInkassoTypUnterart);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTypUnterart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassofallStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtEinnahmenquote, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtBegruendung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblInkassoTypUnterart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lbEinnahmenquote, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblBegruendung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUserID, 0);
            //
            // edtInkassoTypUnterart
            //
            this.edtInkassoTypUnterart.Location = new System.Drawing.Point(175, 58);
            this.edtInkassoTypUnterart.LOVFilter = "CODE BETWEEN 40000 AND 49000";
            this.edtInkassoTypUnterart.LOVFilterWhereAppend = true;
            this.edtInkassoTypUnterart.LOVName = "EroeffnungsGrund";
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
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtInkassoTypUnterart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtInkassoTypUnterart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassoTypUnterart.Properties.NullText = "";
            this.edtInkassoTypUnterart.Properties.ShowFooter = false;
            this.edtInkassoTypUnterart.Properties.ShowHeader = false;
            this.edtInkassoTypUnterart.Size = new System.Drawing.Size(271, 24);
            this.edtInkassoTypUnterart.TabIndex = 1;
            //
            // edtInkassofallStatus
            //
            this.edtInkassofallStatus.Location = new System.Drawing.Point(175, 88);
            this.edtInkassofallStatus.LOVName = "IkLeistungStatus";
            this.edtInkassofallStatus.Name = "edtInkassofallStatus";
            this.edtInkassofallStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtInkassofallStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtInkassofallStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassofallStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtInkassofallStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtInkassofallStatus.Properties.Appearance.Options.UseFont = true;
            this.edtInkassofallStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtInkassofallStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtInkassofallStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtInkassofallStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtInkassofallStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtInkassofallStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtInkassofallStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassofallStatus.Properties.DisplayMember = "Text";
            this.edtInkassofallStatus.Properties.NullText = "";
            this.edtInkassofallStatus.Properties.ShowFooter = false;
            this.edtInkassofallStatus.Properties.ShowHeader = false;
            this.edtInkassofallStatus.Properties.ValueMember = "Code";
            this.edtInkassofallStatus.Size = new System.Drawing.Size(271, 24);
            this.edtInkassofallStatus.TabIndex = 2;
            //
            // edtEinnahmenquote
            //
            this.edtEinnahmenquote.Location = new System.Drawing.Point(175, 118);
            this.edtEinnahmenquote.LOVName = "IkEinnahmenQuote";
            this.edtEinnahmenquote.Name = "edtEinnahmenquote";
            this.edtEinnahmenquote.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtEinnahmenquote.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtEinnahmenquote.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinnahmenquote.Properties.Appearance.Options.UseBackColor = true;
            this.edtEinnahmenquote.Properties.Appearance.Options.UseBorderColor = true;
            this.edtEinnahmenquote.Properties.Appearance.Options.UseFont = true;
            this.edtEinnahmenquote.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtEinnahmenquote.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtEinnahmenquote.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtEinnahmenquote.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtEinnahmenquote.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtEinnahmenquote.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtEinnahmenquote.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtEinnahmenquote.Properties.NullText = "";
            this.edtEinnahmenquote.Properties.ShowFooter = false;
            this.edtEinnahmenquote.Properties.ShowHeader = false;
            this.edtEinnahmenquote.Size = new System.Drawing.Size(271, 24);
            this.edtEinnahmenquote.TabIndex = 3;
            //
            // edtBegruendung
            //
            this.edtBegruendung.Location = new System.Drawing.Point(175, 148);
            this.edtBegruendung.LOVName = "IkErreichungsGrad";
            this.edtBegruendung.Name = "edtBegruendung";
            this.edtBegruendung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBegruendung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBegruendung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBegruendung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBegruendung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBegruendung.Properties.Appearance.Options.UseFont = true;
            this.edtBegruendung.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBegruendung.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBegruendung.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBegruendung.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBegruendung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBegruendung.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBegruendung.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBegruendung.Properties.NullText = "";
            this.edtBegruendung.Properties.ShowFooter = false;
            this.edtBegruendung.Properties.ShowHeader = false;
            this.edtBegruendung.Size = new System.Drawing.Size(271, 24);
            this.edtBegruendung.TabIndex = 4;
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(175, 178);
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
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.Size = new System.Drawing.Size(271, 24);
            this.edtUserID.TabIndex = 5;
            //
            // lblInkassoTypUnterart
            //
            this.lblInkassoTypUnterart.Location = new System.Drawing.Point(8, 58);
            this.lblInkassoTypUnterart.Name = "lblInkassoTypUnterart";
            this.lblInkassoTypUnterart.Size = new System.Drawing.Size(142, 24);
            this.lblInkassoTypUnterart.TabIndex = 6;
            this.lblInkassoTypUnterart.Text = "Inkasso-Typ Unterart";
            this.lblInkassoTypUnterart.UseCompatibleTextRendering = true;
            //
            // lblStatus
            //
            this.lblStatus.Location = new System.Drawing.Point(8, 88);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(142, 24);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            //
            // lbEinnahmenquote
            //
            this.lbEinnahmenquote.Location = new System.Drawing.Point(8, 118);
            this.lbEinnahmenquote.Name = "lbEinnahmenquote";
            this.lbEinnahmenquote.Size = new System.Drawing.Size(161, 24);
            this.lbEinnahmenquote.TabIndex = 8;
            this.lbEinnahmenquote.Text = "Einnahmenquote pro Stichtag";
            this.lbEinnahmenquote.UseCompatibleTextRendering = true;
            //
            // lblBegruendung
            //
            this.lblBegruendung.Location = new System.Drawing.Point(8, 148);
            this.lblBegruendung.Name = "lblBegruendung";
            this.lblBegruendung.Size = new System.Drawing.Size(161, 24);
            this.lblBegruendung.TabIndex = 9;
            this.lblBegruendung.Text = "Begründung Erreichungsgrad";
            this.lblBegruendung.UseCompatibleTextRendering = true;
            //
            // lblUserID
            //
            this.lblUserID.Location = new System.Drawing.Point(8, 178);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(142, 24);
            this.lblUserID.TabIndex = 10;
            this.lblUserID.Text = "SAR";
            this.lblUserID.UseCompatibleTextRendering = true;
            //
            // colBegrndungErreichungsgradinZeitperiode
            //
            this.colBegrndungErreichungsgradinZeitperiode.Name = "colBegrndungErreichungsgradinZeitperiode";
            //
            // colEinnahmenquoteperStichtag
            //
            this.colEinnahmenquoteperStichtag.Name = "colEinnahmenquoteperStichtag";
            //
            // colErffnet
            //
            this.colErffnet.Name = "colErffnet";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colSAR
            //
            this.colSAR.Name = "colSAR";
            //
            // colStatus
            //
            this.colStatus.Name = "colStatus";
            //
            // colUnterartAlimenteninkasso
            //
            this.colUnterartAlimenteninkasso.Name = "colUnterartAlimenteninkasso";
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
            // CtlQueryIkAuswertungAlimenteninkassofuehrung
            //
            this.Name = "CtlQueryIkAuswertungAlimenteninkassofuehrung";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinnahmenquote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEinnahmenquote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBegruendung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBegruendung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbEinnahmenquote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBegruendung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}