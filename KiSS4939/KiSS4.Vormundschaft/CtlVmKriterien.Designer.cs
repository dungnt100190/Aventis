
namespace KiSS4.Vormundschaft
{
    partial class CtlVmKriterien
    {
        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmKriterien));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryVmBewertung = new KiSS4.DB.SqlQuery(this.components);
            this.edtKriterienD = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtKriterienC = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtKriterienB = new KiSS4.Gui.KissCheckedLookupEdit();
            this.edtKriterienA = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblKriterienD = new KiSS4.Gui.KissLabel();
            this.lblKriterienC = new KiSS4.Gui.KissLabel();
            this.lblKriterienB = new KiSS4.Gui.KissLabel();
            this.lblKriterienA = new KiSS4.Gui.KissLabel();
            this.lblVmMandatstypCode = new KiSS4.Gui.KissLabel();
            this.edtVmMandatstypCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblStichtag = new KiSS4.Gui.KissLabel();
            this.grdVmBewertung = new KiSS4.Gui.KissGrid();
            this.grvVmBewertung = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStichtag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVmMandatstypCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVmMandatstypBewilligtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVmKriterienListe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissDocumentButton1 = new KiSS4.Dokument.KissDocumentButton();
            this.edtVmMandatstypBewilligtCode = new KiSS4.Gui.KissLookUpEdit();
            this.btnBewilligung = new KiSS4.Gui.KissButton();
            this.edtStichtag = new KiSS4.Gui.KissTextEdit();
            this.lblVmMandatstypBewilligtCode = new KiSS4.Gui.KissLabel();
            this.btnAdmin = new KiSS4.Gui.KissButton();
            this.edtBemerkung = new KiSS4.Gui.KissMemoEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtKriterienE = new KiSS4.Gui.KissCheckedLookupEdit();
            this.lblKriterienE = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmBewertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmMandatstypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmMandatstypCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmMandatstypCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichtag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmBewertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmBewertung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmMandatstypBewilligtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmMandatstypBewilligtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmMandatstypBewilligtCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienE)).BeginInit();
            this.SuspendLayout();
            // 
            // qryVmBewertung
            // 
            this.qryVmBewertung.CanDelete = true;
            this.qryVmBewertung.CanUpdate = true;
            this.qryVmBewertung.HostControl = this;
            this.qryVmBewertung.TableName = "VmBewertung";
            this.qryVmBewertung.AfterFill += new System.EventHandler(this.qryVmBewertung_AfterFill);
            this.qryVmBewertung.BeforePost += new System.EventHandler(this.qryVmBewertung_BeforePost);
            this.qryVmBewertung.AfterPost += new System.EventHandler(this.qryVmBewertung_AfterPost);
            this.qryVmBewertung.PositionChanged += new System.EventHandler(this.qryVmBewertung_PositionChanged);
            // 
            // edtKriterienD
            // 
            this.edtKriterienD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKriterienD.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtKriterienD.Appearance.Options.UseBackColor = true;
            this.edtKriterienD.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtKriterienD.CheckOnClick = true;
            this.edtKriterienD.Location = new System.Drawing.Point(332, 448);
            this.edtKriterienD.LOVFilter = "4";
            this.edtKriterienD.LOVName = "VmKriterien";
            this.edtKriterienD.Name = "edtKriterienD";
            this.edtKriterienD.Size = new System.Drawing.Size(316, 168);
            this.edtKriterienD.TabIndex = 10;
            this.edtKriterienD.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.edtKriterien_ItemCheck);
            // 
            // edtKriterienC
            // 
            this.edtKriterienC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKriterienC.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtKriterienC.Appearance.Options.UseBackColor = true;
            this.edtKriterienC.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtKriterienC.CheckOnClick = true;
            this.edtKriterienC.Location = new System.Drawing.Point(2, 448);
            this.edtKriterienC.LOVFilter = "3";
            this.edtKriterienC.LOVName = "VmKriterien";
            this.edtKriterienC.Name = "edtKriterienC";
            this.edtKriterienC.Size = new System.Drawing.Size(316, 169);
            this.edtKriterienC.TabIndex = 9;
            this.edtKriterienC.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.edtKriterien_ItemCheck);
            // 
            // edtKriterienB
            // 
            this.edtKriterienB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKriterienB.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtKriterienB.Appearance.Options.UseBackColor = true;
            this.edtKriterienB.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtKriterienB.CheckOnClick = true;
            this.edtKriterienB.Location = new System.Drawing.Point(332, 258);
            this.edtKriterienB.LOVFilter = "2";
            this.edtKriterienB.LOVName = "VmKriterien";
            this.edtKriterienB.Name = "edtKriterienB";
            this.edtKriterienB.Size = new System.Drawing.Size(316, 169);
            this.edtKriterienB.TabIndex = 8;
            this.edtKriterienB.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.edtKriterien_ItemCheck);
            // 
            // edtKriterienA
            // 
            this.edtKriterienA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKriterienA.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtKriterienA.Appearance.Options.UseBackColor = true;
            this.edtKriterienA.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtKriterienA.CheckOnClick = true;
            this.edtKriterienA.Location = new System.Drawing.Point(2, 258);
            this.edtKriterienA.LOVFilter = "1";
            this.edtKriterienA.LOVName = "VmKriterien";
            this.edtKriterienA.Name = "edtKriterienA";
            this.edtKriterienA.Size = new System.Drawing.Size(316, 169);
            this.edtKriterienA.TabIndex = 7;
            this.edtKriterienA.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.edtKriterien_ItemCheck);
            // 
            // lblKriterienD
            // 
            this.lblKriterienD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKriterienD.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblKriterienD.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKriterienD.Location = new System.Drawing.Point(332, 428);
            this.lblKriterienD.Name = "lblKriterienD";
            this.lblKriterienD.Size = new System.Drawing.Size(100, 16);
            this.lblKriterienD.TabIndex = 700;
            this.lblKriterienD.Text = "Kriterien Typ D";
            // 
            // lblKriterienC
            // 
            this.lblKriterienC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKriterienC.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblKriterienC.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKriterienC.Location = new System.Drawing.Point(2, 428);
            this.lblKriterienC.Name = "lblKriterienC";
            this.lblKriterienC.Size = new System.Drawing.Size(100, 16);
            this.lblKriterienC.TabIndex = 699;
            this.lblKriterienC.Text = "Kriterien Typ C";
            // 
            // lblKriterienB
            // 
            this.lblKriterienB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKriterienB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblKriterienB.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblKriterienB.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKriterienB.Location = new System.Drawing.Point(332, 238);
            this.lblKriterienB.Name = "lblKriterienB";
            this.lblKriterienB.Size = new System.Drawing.Size(100, 16);
            this.lblKriterienB.TabIndex = 696;
            this.lblKriterienB.Text = "Kriterien Typ B";
            // 
            // lblKriterienA
            // 
            this.lblKriterienA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKriterienA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.lblKriterienA.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblKriterienA.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKriterienA.Location = new System.Drawing.Point(2, 238);
            this.lblKriterienA.Name = "lblKriterienA";
            this.lblKriterienA.Size = new System.Drawing.Size(100, 16);
            this.lblKriterienA.TabIndex = 695;
            this.lblKriterienA.Text = "Kriterien Typ A";
            // 
            // lblVmMandatstypCode
            // 
            this.lblVmMandatstypCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVmMandatstypCode.Location = new System.Drawing.Point(133, 117);
            this.lblVmMandatstypCode.Name = "lblVmMandatstypCode";
            this.lblVmMandatstypCode.Size = new System.Drawing.Size(79, 24);
            this.lblVmMandatstypCode.TabIndex = 691;
            this.lblVmMandatstypCode.Text = "Bewertung MT";
            // 
            // edtVmMandatstypCode
            // 
            this.edtVmMandatstypCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVmMandatstypCode.DataMember = "VmMandatstypCode";
            this.edtVmMandatstypCode.DataSource = this.qryVmBewertung;
            this.edtVmMandatstypCode.Location = new System.Drawing.Point(212, 117);
            this.edtVmMandatstypCode.LOVName = "VmMandatstyp";
            this.edtVmMandatstypCode.Name = "edtVmMandatstypCode";
            this.edtVmMandatstypCode.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVmMandatstypCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmMandatstypCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmMandatstypCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmMandatstypCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmMandatstypCode.Properties.Appearance.Options.UseFont = true;
            this.edtVmMandatstypCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVmMandatstypCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmMandatstypCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVmMandatstypCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVmMandatstypCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtVmMandatstypCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtVmMandatstypCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmMandatstypCode.Properties.NullText = "";
            this.edtVmMandatstypCode.Properties.ShowFooter = false;
            this.edtVmMandatstypCode.Properties.ShowHeader = false;
            this.edtVmMandatstypCode.Size = new System.Drawing.Size(76, 24);
            this.edtVmMandatstypCode.TabIndex = 2;
            // 
            // lblStichtag
            // 
            this.lblStichtag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStichtag.Location = new System.Drawing.Point(3, 117);
            this.lblStichtag.Name = "lblStichtag";
            this.lblStichtag.Size = new System.Drawing.Size(44, 24);
            this.lblStichtag.TabIndex = 702;
            this.lblStichtag.Text = "Stichtag";
            // 
            // grdVmBewertung
            // 
            this.grdVmBewertung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVmBewertung.DataSource = this.qryVmBewertung;
            // 
            // 
            // 
            this.grdVmBewertung.EmbeddedNavigator.Name = "";
            this.grdVmBewertung.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVmBewertung.Location = new System.Drawing.Point(6, 9);
            this.grdVmBewertung.MainView = this.grvVmBewertung;
            this.grdVmBewertung.Name = "grdVmBewertung";
            this.grdVmBewertung.Size = new System.Drawing.Size(645, 102);
            this.grdVmBewertung.TabIndex = 0;
            this.grdVmBewertung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVmBewertung});
            // 
            // grvVmBewertung
            // 
            this.grvVmBewertung.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVmBewertung.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBewertung.Appearance.Empty.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.Empty.Options.UseFont = true;
            this.grvVmBewertung.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvVmBewertung.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBewertung.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.EvenRow.Options.UseFont = true;
            this.grvVmBewertung.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmBewertung.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBewertung.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVmBewertung.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVmBewertung.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVmBewertung.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmBewertung.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBewertung.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVmBewertung.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVmBewertung.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVmBewertung.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmBewertung.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmBewertung.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmBewertung.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmBewertung.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.GroupRow.Options.UseFont = true;
            this.grvVmBewertung.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVmBewertung.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVmBewertung.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVmBewertung.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmBewertung.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVmBewertung.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVmBewertung.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVmBewertung.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBewertung.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmBewertung.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVmBewertung.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVmBewertung.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmBewertung.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvVmBewertung.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBewertung.Appearance.OddRow.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.OddRow.Options.UseFont = true;
            this.grvVmBewertung.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmBewertung.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBewertung.Appearance.Row.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.Row.Options.UseFont = true;
            this.grvVmBewertung.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvVmBewertung.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmBewertung.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvVmBewertung.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvVmBewertung.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVmBewertung.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvVmBewertung.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmBewertung.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVmBewertung.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVmBewertung.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStichtag,
            this.colVmMandatstypCode,
            this.colVmMandatstypBewilligtCode,
            this.colVmKriterienListe,
            this.colSAR});
            this.grvVmBewertung.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVmBewertung.GridControl = this.grdVmBewertung;
            this.grvVmBewertung.Name = "grvVmBewertung";
            this.grvVmBewertung.OptionsBehavior.Editable = false;
            this.grvVmBewertung.OptionsCustomization.AllowFilter = false;
            this.grvVmBewertung.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVmBewertung.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVmBewertung.OptionsNavigation.UseTabKey = false;
            this.grvVmBewertung.OptionsView.ColumnAutoWidth = false;
            this.grvVmBewertung.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVmBewertung.OptionsView.ShowGroupPanel = false;
            this.grvVmBewertung.OptionsView.ShowIndicator = false;
            // 
            // colStichtag
            // 
            this.colStichtag.Caption = "Stichtag";
            this.colStichtag.FieldName = "Stichtag";
            this.colStichtag.Name = "colStichtag";
            this.colStichtag.Visible = true;
            this.colStichtag.VisibleIndex = 0;
            this.colStichtag.Width = 79;
            // 
            // colVmMandatstypCode
            // 
            this.colVmMandatstypCode.Caption = "Bewert. MT";
            this.colVmMandatstypCode.FieldName = "VmMandatstypCode";
            this.colVmMandatstypCode.Name = "colVmMandatstypCode";
            this.colVmMandatstypCode.Visible = true;
            this.colVmMandatstypCode.VisibleIndex = 1;
            // 
            // colVmMandatstypBewilligtCode
            // 
            this.colVmMandatstypBewilligtCode.Caption = "bewilligt";
            this.colVmMandatstypBewilligtCode.FieldName = "VmMandatstypBewilligtCode";
            this.colVmMandatstypBewilligtCode.Name = "colVmMandatstypBewilligtCode";
            this.colVmMandatstypBewilligtCode.Visible = true;
            this.colVmMandatstypBewilligtCode.VisibleIndex = 2;
            // 
            // colVmKriterienListe
            // 
            this.colVmKriterienListe.Caption = "Kriterien";
            this.colVmKriterienListe.FieldName = "VmKriterienListe";
            this.colVmKriterienListe.Name = "colVmKriterienListe";
            this.colVmKriterienListe.Visible = true;
            this.colVmKriterienListe.VisibleIndex = 3;
            this.colVmKriterienListe.Width = 193;
            // 
            // colSAR
            // 
            this.colSAR.Caption = "SAR";
            this.colSAR.FieldName = "SAR";
            this.colSAR.Name = "colSAR";
            this.colSAR.OptionsColumn.AllowEdit = false;
            this.colSAR.OptionsColumn.ReadOnly = true;
            this.colSAR.Visible = true;
            this.colSAR.VisibleIndex = 4;
            this.colSAR.Width = 205;
            // 
            // kissDocumentButton1
            // 
            this.kissDocumentButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissDocumentButton1.Context = "VmFallgewichtungDok";
            this.kissDocumentButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kissDocumentButton1.Image = ((System.Drawing.Image)(resources.GetObject("xWordBericht1.Image")));
            this.kissDocumentButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.kissDocumentButton1.Location = new System.Drawing.Point(536, 117);
            this.kissDocumentButton1.Name = "kissDocumentButton1";
            this.kissDocumentButton1.Size = new System.Drawing.Size(115, 24);
            this.kissDocumentButton1.TabIndex = 5;
            this.kissDocumentButton1.Text = "Dokumentation";
            this.kissDocumentButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kissDocumentButton1.UseVisualStyleBackColor = false;
            // 
            // edtVmMandatstypBewilligtCode
            // 
            this.edtVmMandatstypBewilligtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVmMandatstypBewilligtCode.DataMember = "VmMandatstypBewilligtCode";
            this.edtVmMandatstypBewilligtCode.DataSource = this.qryVmBewertung;
            this.edtVmMandatstypBewilligtCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtVmMandatstypBewilligtCode.Location = new System.Drawing.Point(396, 117);
            this.edtVmMandatstypBewilligtCode.LOVName = "VmMandatstyp";
            this.edtVmMandatstypBewilligtCode.Name = "edtVmMandatstypBewilligtCode";
            this.edtVmMandatstypBewilligtCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtVmMandatstypBewilligtCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVmMandatstypBewilligtCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmMandatstypBewilligtCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtVmMandatstypBewilligtCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVmMandatstypBewilligtCode.Properties.Appearance.Options.UseFont = true;
            this.edtVmMandatstypBewilligtCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtVmMandatstypBewilligtCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtVmMandatstypBewilligtCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtVmMandatstypBewilligtCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtVmMandatstypBewilligtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtVmMandatstypBewilligtCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtVmMandatstypBewilligtCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVmMandatstypBewilligtCode.Properties.NullText = "";
            this.edtVmMandatstypBewilligtCode.Properties.ReadOnly = true;
            this.edtVmMandatstypBewilligtCode.Properties.ShowFooter = false;
            this.edtVmMandatstypBewilligtCode.Properties.ShowHeader = false;
            this.edtVmMandatstypBewilligtCode.Size = new System.Drawing.Size(76, 24);
            this.edtVmMandatstypBewilligtCode.TabIndex = 4;
            // 
            // btnBewilligung
            // 
            this.btnBewilligung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBewilligung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBewilligung.IconID = 13;
            this.btnBewilligung.Location = new System.Drawing.Point(305, 117);
            this.btnBewilligung.Name = "btnBewilligung";
            this.btnBewilligung.Size = new System.Drawing.Size(28, 24);
            this.btnBewilligung.TabIndex = 3;
            this.btnBewilligung.UseVisualStyleBackColor = false;
            this.btnBewilligung.Click += new System.EventHandler(this.btnBewilligung_Click);
            // 
            // edtStichtag
            // 
            this.edtStichtag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStichtag.DataMember = "Stichtag";
            this.edtStichtag.DataSource = this.qryVmBewertung;
            this.edtStichtag.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtStichtag.Location = new System.Drawing.Point(49, 117);
            this.edtStichtag.Name = "edtStichtag";
            this.edtStichtag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtStichtag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichtag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichtag.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichtag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichtag.Properties.Appearance.Options.UseFont = true;
            this.edtStichtag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStichtag.Properties.ReadOnly = true;
            this.edtStichtag.Size = new System.Drawing.Size(74, 24);
            this.edtStichtag.TabIndex = 1;
            // 
            // lblVmMandatstypBewilligtCode
            // 
            this.lblVmMandatstypBewilligtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVmMandatstypBewilligtCode.Location = new System.Drawing.Point(343, 117);
            this.lblVmMandatstypBewilligtCode.Name = "lblVmMandatstypBewilligtCode";
            this.lblVmMandatstypBewilligtCode.Size = new System.Drawing.Size(47, 24);
            this.lblVmMandatstypBewilligtCode.TabIndex = 708;
            this.lblVmMandatstypBewilligtCode.Text = "bewilligt";
            // 
            // btnAdmin
            // 
            this.btnAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.Location = new System.Drawing.Point(589, 596);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(60, 24);
            this.btnAdmin.TabIndex = 709;
            this.btnAdmin.Text = "Admin";
            this.btnAdmin.UseVisualStyleBackColor = false;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // edtBemerkung
            // 
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmBewertung;
            this.edtBemerkung.Location = new System.Drawing.Point(5, 166);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBemerkung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBemerkung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBemerkung.Properties.Appearance.Options.UseBackColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBemerkung.Properties.Appearance.Options.UseFont = true;
            this.edtBemerkung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBemerkung.Size = new System.Drawing.Size(646, 69);
            this.edtBemerkung.TabIndex = 6;
            // 
            // lblBemerkung
            // 
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblBemerkung.Location = new System.Drawing.Point(3, 148);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(170, 16);
            this.lblBemerkung.TabIndex = 711;
            this.lblBemerkung.Text = "Bemerkung / Begründung";
            // 
            // edtKriterienE
            // 
            this.edtKriterienE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKriterienE.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(240)))), ((int)(((byte)(230)))));
            this.edtKriterienE.Appearance.Options.UseBackColor = true;
            this.edtKriterienE.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtKriterienE.CheckOnClick = true;
            this.edtKriterienE.Location = new System.Drawing.Point(2, 596);
            this.edtKriterienE.LOVFilter = "3";
            this.edtKriterienE.LOVName = "VmKriterien";
            this.edtKriterienE.Name = "edtKriterienE";
            this.edtKriterienE.Size = new System.Drawing.Size(316, 169);
            this.edtKriterienE.TabIndex = 710;
            this.edtKriterienE.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.edtKriterien_ItemCheck);
            // 
            // lblKriterienE
            // 
            this.lblKriterienE.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKriterienE.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblKriterienE.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblKriterienE.Location = new System.Drawing.Point(2, 576);
            this.lblKriterienE.Name = "lblKriterienE";
            this.lblKriterienE.Size = new System.Drawing.Size(100, 16);
            this.lblKriterienE.TabIndex = 711;
            this.lblKriterienE.Text = "Kriterien Typ E";
            // 
            // CtlVmKriterien
            // 
            this.ActiveSQLQuery = this.qryVmBewertung;
            
            this.Controls.Add(this.lblKriterienE);
            this.Controls.Add(this.edtKriterienE);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.lblVmMandatstypBewilligtCode);
            this.Controls.Add(this.edtStichtag);
            this.Controls.Add(this.btnBewilligung);
            this.Controls.Add(this.edtVmMandatstypBewilligtCode);
            this.Controls.Add(this.kissDocumentButton1);
            this.Controls.Add(this.grdVmBewertung);
            this.Controls.Add(this.lblStichtag);
            this.Controls.Add(this.edtKriterienD);
            this.Controls.Add(this.edtKriterienC);
            this.Controls.Add(this.edtKriterienB);
            this.Controls.Add(this.edtKriterienA);
            this.Controls.Add(this.lblKriterienD);
            this.Controls.Add(this.lblKriterienC);
            this.Controls.Add(this.lblKriterienB);
            this.Controls.Add(this.lblKriterienA);
            this.Controls.Add(this.lblVmMandatstypCode);
            this.Controls.Add(this.edtVmMandatstypCode);
            this.Name = "CtlVmKriterien";
            this.Size = new System.Drawing.Size(654, 627);
            this.Load += new System.EventHandler(this.CtlVmKriterien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmBewertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmMandatstypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmMandatstypCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmMandatstypCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichtag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmBewertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmBewertung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmMandatstypBewilligtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVmMandatstypBewilligtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVmMandatstypBewilligtCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBemerkung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKriterienE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKriterienE)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components;
        private KiSS4.DB.SqlQuery qryVmBewertung;

        private KiSS4.Gui.KissCheckedLookupEdit edtKriterienE;
        private KiSS4.Gui.KissCheckedLookupEdit edtKriterienD;
        private KiSS4.Gui.KissCheckedLookupEdit edtKriterienC;
        private KiSS4.Gui.KissCheckedLookupEdit edtKriterienB;
        private KiSS4.Gui.KissCheckedLookupEdit edtKriterienA;
        private KiSS4.Gui.KissLabel lblKriterienE;
        private KiSS4.Gui.KissLabel lblKriterienD;
        private KiSS4.Gui.KissLabel lblKriterienC;
        private KiSS4.Gui.KissLabel lblKriterienB;
        private KiSS4.Gui.KissLabel lblKriterienA;
        private KiSS4.Gui.KissLabel lblVmMandatstypCode;
        private KiSS4.Gui.KissLookUpEdit edtVmMandatstypCode;
        private KiSS4.Gui.KissLabel lblStichtag;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVmBewertung;
        private DevExpress.XtraGrid.Columns.GridColumn colVmKriterienListe;

        private KiSS4.Gui.KissGrid grdVmBewertung;
        private KiSS4.Dokument.KissDocumentButton kissDocumentButton1;
        private KiSS4.Gui.KissLookUpEdit edtVmMandatstypBewilligtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colVmMandatstypCode;
        private DevExpress.XtraGrid.Columns.GridColumn colVmMandatstypBewilligtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colStichtag;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private KiSS4.Gui.KissButton btnBewilligung;
        private KiSS4.Gui.KissTextEdit edtStichtag;
        private KiSS4.Gui.KissLabel lblVmMandatstypBewilligtCode;
        private KiSS4.Gui.KissButton btnAdmin;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissMemoEdit edtBemerkung;
    }
}
