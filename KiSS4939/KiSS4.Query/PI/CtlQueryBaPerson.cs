using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.PI
{
    public class CtlQueryBaPerson : Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissCheckEdit chkSucheKL;
        private KissCheckEdit chkSucheNurSerienbrief;
        private KiSS4.Gui.KissDateEdit datSucheGeburtBis;
        private KiSS4.Gui.KissDateEdit datSucheGeburtVon;
        private KissIntEdit edtSucheBaPersonID;
        private KiSS4.Gui.KissTextEdit edtSucheName;
        private KissLookUpEdit edtSucheNationalitaet;
        private KiSS4.Gui.KissTextEdit edtSucheOrt;
        private KiSS4.Gui.KissTextEdit edtSuchePLZ;
        private KiSS4.Gui.KissTextEdit edtSucheStrasse;
        private KissTextEdit edtSucheTelefon;
        private KissTextEdit edtSucheVersNummer;
        private KiSS4.Gui.KissTextEdit edtSucheVorname;
        private KissLabel lblSucheBaPersonID;
        private KiSS4.Gui.KissLabel lblSucheGeburt;
        private KiSS4.Gui.KissLabel lblSucheGeburtBis;
        private KiSS4.Gui.KissLabel lblSucheName;
        private KissLabel lblSucheNationalitaet;
        private KiSS4.Gui.KissLabel lblSuchePLZOrt;
        private KiSS4.Gui.KissLabel lblSucheStrasse;
        private KissLabel lblSucheTelefon;
        private KissLabel lblSucheVersNummer;
        private KiSS4.Gui.KissLabel lblSucheVorname;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryBaPerson()
        {
            InitializeComponent();

            // apply lov-filter
            Common.PI.BaUtils.ApplyLOVBaLand(edtSucheNationalitaet);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryBaPerson));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblSucheName = new KiSS4.Gui.KissLabel();
            this.edtSucheName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVorname = new KiSS4.Gui.KissLabel();
            this.edtSucheVorname = new KiSS4.Gui.KissTextEdit();
            this.lblSucheGeburt = new KiSS4.Gui.KissLabel();
            this.datSucheGeburtVon = new KiSS4.Gui.KissDateEdit();
            this.lblSucheGeburtBis = new KiSS4.Gui.KissLabel();
            this.datSucheGeburtBis = new KiSS4.Gui.KissDateEdit();
            this.lblSucheStrasse = new KiSS4.Gui.KissLabel();
            this.edtSucheStrasse = new KiSS4.Gui.KissTextEdit();
            this.lblSuchePLZOrt = new KiSS4.Gui.KissLabel();
            this.edtSuchePLZ = new KiSS4.Gui.KissTextEdit();
            this.edtSucheOrt = new KiSS4.Gui.KissTextEdit();
            this.chkSucheKL = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheVersNummer = new KiSS4.Gui.KissTextEdit();
            this.lblSucheVersNummer = new KiSS4.Gui.KissLabel();
            this.chkSucheNurSerienbrief = new KiSS4.Gui.KissCheckEdit();
            this.edtSucheTelefon = new KiSS4.Gui.KissTextEdit();
            this.lblSucheTelefon = new KiSS4.Gui.KissLabel();
            this.lblSucheBaPersonID = new KiSS4.Gui.KissLabel();
            this.edtSucheBaPersonID = new KiSS4.Gui.KissIntEdit();
            this.edtSucheNationalitaet = new KiSS4.Gui.KissLookUpEdit();
            this.lblSucheNationalitaet = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSucheGeburtVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSucheGeburtBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePLZ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheKL.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersNummer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersNummer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurSerienbrief.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTelefon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTelefon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNationalitaet)).BeginInit();
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
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(183, 397);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Size = new System.Drawing.Size(10, 24);
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.ShowToolTipsOnIcons = true;
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
            this.tpgSuchen.Controls.Add(this.edtSucheNationalitaet);
            this.tpgSuchen.Controls.Add(this.lblSucheNationalitaet);
            this.tpgSuchen.Controls.Add(this.edtSucheBaPersonID);
            this.tpgSuchen.Controls.Add(this.lblSucheBaPersonID);
            this.tpgSuchen.Controls.Add(this.edtSucheTelefon);
            this.tpgSuchen.Controls.Add(this.lblSucheTelefon);
            this.tpgSuchen.Controls.Add(this.chkSucheNurSerienbrief);
            this.tpgSuchen.Controls.Add(this.chkSucheKL);
            this.tpgSuchen.Controls.Add(this.edtSucheOrt);
            this.tpgSuchen.Controls.Add(this.edtSuchePLZ);
            this.tpgSuchen.Controls.Add(this.lblSuchePLZOrt);
            this.tpgSuchen.Controls.Add(this.edtSucheStrasse);
            this.tpgSuchen.Controls.Add(this.lblSucheStrasse);
            this.tpgSuchen.Controls.Add(this.edtSucheVersNummer);
            this.tpgSuchen.Controls.Add(this.lblSucheVersNummer);
            this.tpgSuchen.Controls.Add(this.datSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburtBis);
            this.tpgSuchen.Controls.Add(this.datSucheGeburtVon);
            this.tpgSuchen.Controls.Add(this.lblSucheGeburt);
            this.tpgSuchen.Controls.Add(this.edtSucheVorname);
            this.tpgSuchen.Controls.Add(this.lblSucheVorname);
            this.tpgSuchen.Controls.Add(this.edtSucheName);
            this.tpgSuchen.Controls.Add(this.lblSucheName);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVorname, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.datSucheGeburtVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.datSucheGeburtBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheVersNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheVersNummer, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheStrasse, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSuchePLZOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSuchePLZ, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheOrt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheKL, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkSucheNurSerienbrief, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheTelefon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheTelefon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheNationalitaet, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheNationalitaet, 0);
            // 
            // lblSucheName
            // 
            this.lblSucheName.Location = new System.Drawing.Point(31, 40);
            this.lblSucheName.Name = "lblSucheName";
            this.lblSucheName.Size = new System.Drawing.Size(100, 23);
            this.lblSucheName.TabIndex = 1;
            this.lblSucheName.Text = "Name";
            this.lblSucheName.UseCompatibleTextRendering = true;
            // 
            // edtSucheName
            // 
            this.edtSucheName.Location = new System.Drawing.Point(137, 40);
            this.edtSucheName.Name = "edtSucheName";
            this.edtSucheName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheName.Size = new System.Drawing.Size(236, 24);
            this.edtSucheName.TabIndex = 2;
            // 
            // lblSucheVorname
            // 
            this.lblSucheVorname.Location = new System.Drawing.Point(31, 70);
            this.lblSucheVorname.Name = "lblSucheVorname";
            this.lblSucheVorname.Size = new System.Drawing.Size(100, 23);
            this.lblSucheVorname.TabIndex = 3;
            this.lblSucheVorname.Text = "Vorname";
            this.lblSucheVorname.UseCompatibleTextRendering = true;
            // 
            // edtSucheVorname
            // 
            this.edtSucheVorname.Location = new System.Drawing.Point(137, 70);
            this.edtSucheVorname.Name = "edtSucheVorname";
            this.edtSucheVorname.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVorname.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVorname.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVorname.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVorname.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVorname.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVorname.Size = new System.Drawing.Size(236, 24);
            this.edtSucheVorname.TabIndex = 4;
            // 
            // lblSucheGeburt
            // 
            this.lblSucheGeburt.Location = new System.Drawing.Point(31, 190);
            this.lblSucheGeburt.Name = "lblSucheGeburt";
            this.lblSucheGeburt.Size = new System.Drawing.Size(100, 23);
            this.lblSucheGeburt.TabIndex = 12;
            this.lblSucheGeburt.Text = "Geburtsdatum";
            this.lblSucheGeburt.UseCompatibleTextRendering = true;
            // 
            // datSucheGeburtVon
            // 
            this.datSucheGeburtVon.EditValue = null;
            this.datSucheGeburtVon.Location = new System.Drawing.Point(137, 190);
            this.datSucheGeburtVon.Name = "datSucheGeburtVon";
            this.datSucheGeburtVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datSucheGeburtVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datSucheGeburtVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datSucheGeburtVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datSucheGeburtVon.Properties.Appearance.Options.UseBackColor = true;
            this.datSucheGeburtVon.Properties.Appearance.Options.UseBorderColor = true;
            this.datSucheGeburtVon.Properties.Appearance.Options.UseFont = true;
            this.datSucheGeburtVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.datSucheGeburtVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datSucheGeburtVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.datSucheGeburtVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datSucheGeburtVon.Properties.ShowToday = false;
            this.datSucheGeburtVon.Size = new System.Drawing.Size(100, 24);
            this.datSucheGeburtVon.TabIndex = 13;
            // 
            // lblSucheGeburtBis
            // 
            this.lblSucheGeburtBis.Location = new System.Drawing.Point(243, 190);
            this.lblSucheGeburtBis.Name = "lblSucheGeburtBis";
            this.lblSucheGeburtBis.Size = new System.Drawing.Size(24, 24);
            this.lblSucheGeburtBis.TabIndex = 14;
            this.lblSucheGeburtBis.Text = "bis";
            this.lblSucheGeburtBis.UseCompatibleTextRendering = true;
            // 
            // datSucheGeburtBis
            // 
            this.datSucheGeburtBis.EditValue = null;
            this.datSucheGeburtBis.Location = new System.Drawing.Point(273, 190);
            this.datSucheGeburtBis.Name = "datSucheGeburtBis";
            this.datSucheGeburtBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.datSucheGeburtBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.datSucheGeburtBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.datSucheGeburtBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.datSucheGeburtBis.Properties.Appearance.Options.UseBackColor = true;
            this.datSucheGeburtBis.Properties.Appearance.Options.UseBorderColor = true;
            this.datSucheGeburtBis.Properties.Appearance.Options.UseFont = true;
            this.datSucheGeburtBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.datSucheGeburtBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("datSucheGeburtBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.datSucheGeburtBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.datSucheGeburtBis.Properties.ShowToday = false;
            this.datSucheGeburtBis.Size = new System.Drawing.Size(100, 24);
            this.datSucheGeburtBis.TabIndex = 15;
            // 
            // lblSucheStrasse
            // 
            this.lblSucheStrasse.Location = new System.Drawing.Point(31, 100);
            this.lblSucheStrasse.Name = "lblSucheStrasse";
            this.lblSucheStrasse.Size = new System.Drawing.Size(100, 23);
            this.lblSucheStrasse.TabIndex = 5;
            this.lblSucheStrasse.Text = "Strasse";
            this.lblSucheStrasse.UseCompatibleTextRendering = true;
            // 
            // edtSucheStrasse
            // 
            this.edtSucheStrasse.Location = new System.Drawing.Point(137, 100);
            this.edtSucheStrasse.Name = "edtSucheStrasse";
            this.edtSucheStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStrasse.Size = new System.Drawing.Size(236, 24);
            this.edtSucheStrasse.TabIndex = 6;
            // 
            // lblSuchePLZOrt
            // 
            this.lblSuchePLZOrt.Location = new System.Drawing.Point(31, 130);
            this.lblSuchePLZOrt.Name = "lblSuchePLZOrt";
            this.lblSuchePLZOrt.Size = new System.Drawing.Size(100, 23);
            this.lblSuchePLZOrt.TabIndex = 7;
            this.lblSuchePLZOrt.Text = "PLZ / Ort";
            this.lblSuchePLZOrt.UseCompatibleTextRendering = true;
            // 
            // edtSuchePLZ
            // 
            this.edtSuchePLZ.Location = new System.Drawing.Point(137, 130);
            this.edtSuchePLZ.Name = "edtSuchePLZ";
            this.edtSuchePLZ.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSuchePLZ.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSuchePLZ.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSuchePLZ.Properties.Appearance.Options.UseBackColor = true;
            this.edtSuchePLZ.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSuchePLZ.Properties.Appearance.Options.UseFont = true;
            this.edtSuchePLZ.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSuchePLZ.Size = new System.Drawing.Size(57, 24);
            this.edtSuchePLZ.TabIndex = 8;
            // 
            // edtSucheOrt
            // 
            this.edtSucheOrt.Location = new System.Drawing.Point(193, 130);
            this.edtSucheOrt.Name = "edtSucheOrt";
            this.edtSucheOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheOrt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheOrt.Size = new System.Drawing.Size(180, 24);
            this.edtSucheOrt.TabIndex = 9;
            // 
            // chkSucheKL
            // 
            this.chkSucheKL.EditValue = false;
            this.chkSucheKL.Location = new System.Drawing.Point(511, 129);
            this.chkSucheKL.Name = "chkSucheKL";
            this.chkSucheKL.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheKL.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheKL.Properties.Caption = "Nur Klienten/innen";
            this.chkSucheKL.Size = new System.Drawing.Size(236, 19);
            this.chkSucheKL.TabIndex = 24;
            // 
            // edtSucheVersNummer
            // 
            this.edtSucheVersNummer.Location = new System.Drawing.Point(511, 99);
            this.edtSucheVersNummer.Name = "edtSucheVersNummer";
            this.edtSucheVersNummer.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheVersNummer.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheVersNummer.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheVersNummer.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheVersNummer.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheVersNummer.Properties.Appearance.Options.UseFont = true;
            this.edtSucheVersNummer.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheVersNummer.Size = new System.Drawing.Size(236, 24);
            this.edtSucheVersNummer.TabIndex = 23;
            // 
            // lblSucheVersNummer
            // 
            this.lblSucheVersNummer.Location = new System.Drawing.Point(405, 99);
            this.lblSucheVersNummer.Name = "lblSucheVersNummer";
            this.lblSucheVersNummer.Size = new System.Drawing.Size(100, 24);
            this.lblSucheVersNummer.TabIndex = 22;
            this.lblSucheVersNummer.Text = "Vers.-Nr.";
            this.lblSucheVersNummer.UseCompatibleTextRendering = true;
            // 
            // chkSucheNurSerienbrief
            // 
            this.chkSucheNurSerienbrief.EditValue = false;
            this.chkSucheNurSerienbrief.Location = new System.Drawing.Point(511, 154);
            this.chkSucheNurSerienbrief.Name = "chkSucheNurSerienbrief";
            this.chkSucheNurSerienbrief.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.chkSucheNurSerienbrief.Properties.Appearance.Options.UseBackColor = true;
            this.chkSucheNurSerienbrief.Properties.Caption = "Nur Personen mit Serienbrief";
            this.chkSucheNurSerienbrief.Properties.Name = "editFTX.Properties";
            this.chkSucheNurSerienbrief.Size = new System.Drawing.Size(236, 19);
            this.chkSucheNurSerienbrief.TabIndex = 25;
            // 
            // edtSucheTelefon
            // 
            this.edtSucheTelefon.Location = new System.Drawing.Point(137, 160);
            this.edtSucheTelefon.Name = "edtSucheTelefon";
            this.edtSucheTelefon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheTelefon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheTelefon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheTelefon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheTelefon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheTelefon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheTelefon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheTelefon.Properties.Name = "editStrasseX.Properties";
            this.edtSucheTelefon.Size = new System.Drawing.Size(236, 24);
            this.edtSucheTelefon.TabIndex = 11;
            // 
            // lblSucheTelefon
            // 
            this.lblSucheTelefon.Location = new System.Drawing.Point(31, 160);
            this.lblSucheTelefon.Name = "lblSucheTelefon";
            this.lblSucheTelefon.Size = new System.Drawing.Size(100, 24);
            this.lblSucheTelefon.TabIndex = 10;
            this.lblSucheTelefon.Text = "Telefon";
            this.lblSucheTelefon.UseCompatibleTextRendering = true;
            // 
            // lblSucheBaPersonID
            // 
            this.lblSucheBaPersonID.Location = new System.Drawing.Point(405, 40);
            this.lblSucheBaPersonID.Name = "lblSucheBaPersonID";
            this.lblSucheBaPersonID.Size = new System.Drawing.Size(100, 24);
            this.lblSucheBaPersonID.TabIndex = 16;
            this.lblSucheBaPersonID.Text = "Personen-ID";
            this.lblSucheBaPersonID.UseCompatibleTextRendering = true;
            // 
            // edtSucheBaPersonID
            // 
            this.edtSucheBaPersonID.Location = new System.Drawing.Point(511, 40);
            this.edtSucheBaPersonID.Name = "edtSucheBaPersonID";
            this.edtSucheBaPersonID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBaPersonID.Properties.DisplayFormat.FormatString = "################################";
            this.edtSucheBaPersonID.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBaPersonID.Properties.EditFormat.FormatString = "################################";
            this.edtSucheBaPersonID.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSucheBaPersonID.Properties.Mask.EditMask = "################################";
            this.edtSucheBaPersonID.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBaPersonID.TabIndex = 17;
            // 
            // edtSucheNationalitaet
            // 
            this.edtSucheNationalitaet.Location = new System.Drawing.Point(511, 69);
            this.edtSucheNationalitaet.Name = "edtSucheNationalitaet";
            this.edtSucheNationalitaet.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheNationalitaet.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheNationalitaet.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNationalitaet.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheNationalitaet.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheNationalitaet.Properties.Appearance.Options.UseFont = true;
            this.edtSucheNationalitaet.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheNationalitaet.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheNationalitaet.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheNationalitaet.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheNationalitaet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtSucheNationalitaet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtSucheNationalitaet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheNationalitaet.Properties.Name = "editNationalitaetX.Properties";
            this.edtSucheNationalitaet.Properties.NullText = "";
            this.edtSucheNationalitaet.Properties.ShowFooter = false;
            this.edtSucheNationalitaet.Properties.ShowHeader = false;
            this.edtSucheNationalitaet.Size = new System.Drawing.Size(236, 24);
            this.edtSucheNationalitaet.TabIndex = 19;
            // 
            // lblSucheNationalitaet
            // 
            this.lblSucheNationalitaet.Location = new System.Drawing.Point(405, 69);
            this.lblSucheNationalitaet.Name = "lblSucheNationalitaet";
            this.lblSucheNationalitaet.Size = new System.Drawing.Size(100, 24);
            this.lblSucheNationalitaet.TabIndex = 18;
            this.lblSucheNationalitaet.Text = "Nationalität";
            this.lblSucheNationalitaet.UseCompatibleTextRendering = true;
            // 
            // CtlQueryBaPerson
            // 
            this.Name = "CtlQueryBaPerson";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVorname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVorname.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSucheGeburtVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheGeburtBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datSucheGeburtBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuchePLZOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSuchePLZ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheKL.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheVersNummer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheVersNummer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSucheNurSerienbrief.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheTelefon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheTelefon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheNationalitaet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void RunSearch()
        {
            // replace search parameters
            var parameters = new object[] { Session.User.UserID, Session.User.LanguageCode };
            kissSearch.SelectParameters = parameters;

            // let base do stuff
            base.RunSearch();
        }

        #endregion

        #endregion
    }
}