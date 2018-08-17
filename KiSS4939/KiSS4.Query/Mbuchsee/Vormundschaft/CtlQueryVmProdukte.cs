using System;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.MBU
{
    public class CtlQueryVmProdukte : KiSS4.Common.KissQueryControl
    {
        #region Fields

        #region Private Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAbteilung;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colFP;
        private DevExpress.XtraGrid.Columns.GridColumn colFPBPp1;
        private DevExpress.XtraGrid.Columns.GridColumn colFPBPp2;
        private DevExpress.XtraGrid.Columns.GridColumn colFPBPp3;
        private DevExpress.XtraGrid.Columns.GridColumn colFPBPpnie;
        private DevExpress.XtraGrid.Columns.GridColumn colFPFrBwe;
        private DevExpress.XtraGrid.Columns.GridColumn colFPFrBwne;
        private DevExpress.XtraGrid.Columns.GridColumn colFPFrPpe;
        private DevExpress.XtraGrid.Columns.GridColumn colFPFrPpne;
        private DevExpress.XtraGrid.Columns.GridColumn colFPGMHf;
        private DevExpress.XtraGrid.Columns.GridColumn colFPGMPp;
        private DevExpress.XtraGrid.Columns.GridColumn colFPUmp;
        private DevExpress.XtraGrid.Columns.GridColumn colG;
        private DevExpress.XtraGrid.Columns.GridColumn colGFrBze;
        private DevExpress.XtraGrid.Columns.GridColumn colGFrBzne;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlecht;
        private DevExpress.XtraGrid.Columns.GridColumn colKS;
        private DevExpress.XtraGrid.Columns.GridColumn colKSAFre;
        private DevExpress.XtraGrid.Columns.GridColumn colKSAFrne;
        private DevExpress.XtraGrid.Columns.GridColumn colKSBesch;
        private DevExpress.XtraGrid.Columns.GridColumn colKSFre;
        private DevExpress.XtraGrid.Columns.GridColumn colKSFrne;
        private DevExpress.XtraGrid.Columns.GridColumn colKSMA1;
        private DevExpress.XtraGrid.Columns.GridColumn colKSMA2;
        private DevExpress.XtraGrid.Columns.GridColumn colKSMA3;
        private DevExpress.XtraGrid.Columns.GridColumn colKSuGM;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSektion;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colpSA;
        private DevExpress.XtraGrid.Columns.GridColumn colpSABesch;
        private DevExpress.XtraGrid.Columns.GridColumn colpSAFre;
        private DevExpress.XtraGrid.Columns.GridColumn colpSAFrne;
        private DevExpress.XtraGrid.Columns.GridColumn colpSAMA1;
        private DevExpress.XtraGrid.Columns.GridColumn colpSAMA2;
        private DevExpress.XtraGrid.Columns.GridColumn colpSAMA3;
        private System.ComponentModel.IContainer components = null;
        private KiSS4.Gui.KissLookUpEdit edtProdukt;
        private KiSS4.Gui.KissDateEdit edtStichtag;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel lblProdukt;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblStichtag;

        #endregion

        #endregion

        #region Constructors

        public CtlQueryVmProdukte()
        {
            this.InitializeComponent();

            edtProdukt.LoadQuery(DBUtil.OpenSQL(@"
                SELECT Code = null, Text = ''
                UNION ALL
                SELECT Code = 'Private Mandate', Text = 'Private Mandate'
                UNION ALL
                SELECT Code = 'Vormundschaftliche Mandate', Text = 'Vormundschaftliche Mandate'
                UNION ALL
                SELECT Code = 'VM Abklärungen', Text = 'VM Abklärungen'
                UNION ALL
                SELECT Code = 'Vaterschaftsabklärung: Neu und Aberkennungsklage', Text = 'Vaterschaftsabklärung: Neu und Aberkennungsklage'
                UNION ALL
                SELECT Code = 'Kinderzuteilungsberichte', Text = 'Kinderzuteilungsberichte'
                UNION ALL
                SELECT Code = 'Kontrolle Kindsvermögen', Text = 'Kontrolle Kindsvermögen'
                UNION ALL
                SELECT Code = 'Besuchsrechtsregelungen', Text = 'Besuchsrechtsregelungen'
                UNION ALL
                SELECT Code = 'Unterhaltsverträge: Abänderungen', Text = 'Unterhaltsverträge: Abänderungen'
                UNION ALL
                SELECT Code = 'Scheidungsurteil', Text = 'Scheidungsurteil'
                UNION ALL
                SELECT Code = 'Adoptionserklärungen', Text = 'Adoptionserklärungen'
                UNION ALL
                SELECT Code = 'andere', Text = 'andere'
                UNION ALL
                SELECT Code = 'psB', Text = 'psB'
                UNION ALL
                SELECT Code = 'Erbschaft', Text = 'Erbschaft'
                ORDER BY Code
            "));
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryVmProdukte));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.components = new System.ComponentModel.Container();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblStichtag = new KiSS4.Gui.KissLabel();
            this.lblProdukt = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtStichtag = new KiSS4.Gui.KissDateEdit();
            this.edtProdukt = new KiSS4.Gui.KissLookUpEdit();
            this.colAbteilung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPBPp1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPBPp2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPBPp3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPBPpnie = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPFrBwe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPFrBwne = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPFrPpe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPFrPpne = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPGMHf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPGMPp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFPUmp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlecht = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGFrBze = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGFrBzne = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSAFre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSAFrne = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSBesch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSFre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSFrne = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSMA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSMA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSMA3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKSuGM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpSA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpSABesch = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpSAFre = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpSAFrne = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpSAMA1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpSAMA2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpSAMA3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSektion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichtag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProdukt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProdukt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProdukt.Properties)).BeginInit();
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
            this.tpgSuchen.Controls.Add(this.edtProdukt);
            this.tpgSuchen.Controls.Add(this.edtStichtag);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblProdukt);
            this.tpgSuchen.Controls.Add(this.lblStichtag);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStichtag, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblProdukt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStichtag, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtProdukt, 0);
            //
            // lblSAR
            //
            this.lblSAR.Location = new System.Drawing.Point(10, 39);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 2;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            //
            // lblStichtag
            //
            this.lblStichtag.Location = new System.Drawing.Point(10, 99);
            this.lblStichtag.Name = "lblStichtag";
            this.lblStichtag.Size = new System.Drawing.Size(130, 24);
            this.lblStichtag.TabIndex = 4;
            this.lblStichtag.Text = "Stichtag";
            this.lblStichtag.UseCompatibleTextRendering = true;
            //
            // lblProdukt
            //
            this.lblProdukt.Location = new System.Drawing.Point(10, 69);
            this.lblProdukt.Name = "lblProdukt";
            this.lblProdukt.Size = new System.Drawing.Size(130, 24);
            this.lblProdukt.TabIndex = 4;
            this.lblProdukt.Text = "Produkt";
            this.lblProdukt.UseCompatibleTextRendering = true;
            //
            // edtUserID
            //
            this.edtUserID.Location = new System.Drawing.Point(150, 39);
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
            this.edtUserID.Size = new System.Drawing.Size(220, 24);
            this.edtUserID.TabIndex = 21;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            //
            // edtStichtag
            //
            this.edtStichtag.EditValue = "";
            this.edtStichtag.Location = new System.Drawing.Point(150, 99);
            this.edtStichtag.Name = "edtStichtag";
            this.edtStichtag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtStichtag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStichtag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStichtag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStichtag.Properties.Appearance.Options.UseBackColor = true;
            this.edtStichtag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStichtag.Properties.Appearance.Options.UseFont = true;
            this.edtStichtag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtStichtag.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtStichtag.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtStichtag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStichtag.Properties.ShowToday = false;
            this.edtStichtag.Size = new System.Drawing.Size(100, 24);
            this.edtStichtag.TabIndex = 22;
            //
            // edtProdukt
            //
            this.edtProdukt.Location = new System.Drawing.Point(150, 69);
            this.edtProdukt.Name = "edtProdukt";
            this.edtProdukt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProdukt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtProdukt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtProdukt.Properties.Appearance.Options.UseBackColor = true;
            this.edtProdukt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtProdukt.Properties.Appearance.Options.UseFont = true;
            this.edtProdukt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtProdukt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtProdukt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtProdukt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtProdukt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtProdukt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtProdukt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtProdukt.Properties.NullText = "";
            this.edtProdukt.Properties.ShowFooter = false;
            this.edtProdukt.Properties.ShowHeader = false;
            this.edtProdukt.Size = new System.Drawing.Size(220, 24);
            this.edtProdukt.TabIndex = 24;
            //
            // colAbteilung
            //
            this.colAbteilung.Name = "colAbteilung";
            //
            // colAlter
            //
            this.colAlter.Name = "colAlter";
            //
            // colFP
            //
            this.colFP.Name = "colFP";
            //
            // colFPBPp1
            //
            this.colFPBPp1.Name = "colFPBPp1";
            //
            // colFPBPp2
            //
            this.colFPBPp2.Name = "colFPBPp2";
            //
            // colFPBPp3
            //
            this.colFPBPp3.Name = "colFPBPp3";
            //
            // colFPBPpnie
            //
            this.colFPBPpnie.Name = "colFPBPpnie";
            //
            // colFPFrBwe
            //
            this.colFPFrBwe.Name = "colFPFrBwe";
            //
            // colFPFrBwne
            //
            this.colFPFrBwne.Name = "colFPFrBwne";
            //
            // colFPFrPpe
            //
            this.colFPFrPpe.Name = "colFPFrPpe";
            //
            // colFPFrPpne
            //
            this.colFPFrPpne.Name = "colFPFrPpne";
            //
            // colFPGMHf
            //
            this.colFPGMHf.Name = "colFPGMHf";
            //
            // colFPGMPp
            //
            this.colFPGMPp.Name = "colFPGMPp";
            //
            // colFPUmp
            //
            this.colFPUmp.Name = "colFPUmp";
            //
            // colG
            //
            this.colG.Name = "colG";
            //
            // colGeschlecht
            //
            this.colGeschlecht.Name = "colGeschlecht";
            //
            // colGFrBze
            //
            this.colGFrBze.Name = "colGFrBze";
            //
            // colGFrBzne
            //
            this.colGFrBzne.Name = "colGFrBzne";
            //
            // colKS
            //
            this.colKS.Name = "colKS";
            //
            // colKSAFre
            //
            this.colKSAFre.Name = "colKSAFre";
            //
            // colKSAFrne
            //
            this.colKSAFrne.Name = "colKSAFrne";
            //
            // colKSBesch
            //
            this.colKSBesch.Name = "colKSBesch";
            //
            // colKSFre
            //
            this.colKSFre.Name = "colKSFre";
            //
            // colKSFrne
            //
            this.colKSFrne.Name = "colKSFrne";
            //
            // colKSMA1
            //
            this.colKSMA1.Name = "colKSMA1";
            //
            // colKSMA2
            //
            this.colKSMA2.Name = "colKSMA2";
            //
            // colKSMA3
            //
            this.colKSMA3.Name = "colKSMA3";
            //
            // colKSuGM
            //
            this.colKSuGM.Name = "colKSuGM";
            //
            // colNationalitt
            //
            this.colNationalitt.Name = "colNationalitt";
            //
            // colPerson
            //
            this.colPerson.Name = "colPerson";
            //
            // colpSA
            //
            this.colpSA.Name = "colpSA";
            //
            // colpSABesch
            //
            this.colpSABesch.Name = "colpSABesch";
            //
            // colpSAFre
            //
            this.colpSAFre.Name = "colpSAFre";
            //
            // colpSAFrne
            //
            this.colpSAFrne.Name = "colpSAFrne";
            //
            // colpSAMA1
            //
            this.colpSAMA1.Name = "colpSAMA1";
            //
            // colpSAMA2
            //
            this.colpSAMA2.Name = "colpSAMA2";
            //
            // colpSAMA3
            //
            this.colpSAMA3.Name = "colpSAMA3";
            //
            // colSAR
            //
            this.colSAR.Name = "colSAR";
            //
            // colSektion
            //
            this.colSektion.Name = "colSektion";
            //
            // colTotal
            //
            this.colTotal.Name = "colTotal";
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
            // CtlQueryVmProdukte
            //
            this.Name = "CtlQueryVmProdukte";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStichtag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblProdukt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStichtag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProdukt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProdukt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
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

        #region EventHandlers

        private void edtUserID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtUserID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(SearchString))
            {
                if (e.ButtonClicked)
                {
                    SearchString = "%";
                }
                else
                {
                    edtUserID.EditValue = null;
                    edtUserID.LookupID = null;
                    return;
                }
            }

            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.MitarbeiterSuchen(SearchString, e.ButtonClicked);

            if (!e.Cancel)
            {
                edtUserID.EditValue = dlg["Name"];
                edtUserID.LookupID = dlg["UserID"];
            }
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void RunSearch()
        {
            DBUtil.CheckNotNullField(edtStichtag, "Stichtag");
            base.RunSearch();
        }

        #endregion

        #endregion
    }
}