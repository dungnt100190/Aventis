using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common;

namespace KiSS4.Query
{
    public class CtlQueryIkFallführung : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissCheckEdit chkLaufendeBevorschussung;
        private KiSS4.Gui.KissCheckEdit chkNurLaufendeBevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlFaelle;
        private DevExpress.XtraGrid.Columns.GridColumn colAnzahlGlaeubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colArchiv;
        private DevExpress.XtraGrid.Columns.GridColumn colBemhung;
        private DevExpress.XtraGrid.Columns.GridColumn colBemuehungText;
        private DevExpress.XtraGrid.Columns.GridColumn colDatumAnpassenAb;
        private DevExpress.XtraGrid.Columns.GridColumn colElterlicheSorge;
        private DevExpress.XtraGrid.Columns.GridColumn colElterlicheSorgeBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colFaLeistungID;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGlaeubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colGlubiger;
        private DevExpress.XtraGrid.Columns.GridColumn colIkForderungID;
        private DevExpress.XtraGrid.Columns.GridColumn colIkGlaeubigerID;
        private DevExpress.XtraGrid.Columns.GridColumn colIkRechtstitelID;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassoFallName;
        private DevExpress.XtraGrid.Columns.GridColumn colInkassoTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colmonatlBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colMonatsBevorschussung;
        private DevExpress.XtraGrid.Columns.GridColumn colRckerstattungtyp;
        private DevExpress.XtraGrid.Columns.GridColumn colSAR;
        private DevExpress.XtraGrid.Columns.GridColumn colSARName;
        private DevExpress.XtraGrid.Columns.GridColumn colSchuldner;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterart;
        private DevExpress.XtraGrid.Columns.GridColumn colVerjaehrungAm;
        private KiSS4.Gui.KissCheckEdit edtAbgeschlosseneFaelle;
        private KissLookUpEdit edtAbschlussgrund;
        private KiSS4.Gui.KissCheckEdit edtArchivierteFaelle;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissCheckEdit edtExtensiveFaelle;
        private KiSS4.Gui.KissLookUpEdit edtIkRueckerstattungTyp;
        private KiSS4.Gui.KissLookUpEdit edtInkassofallStatus;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTyp;
        private KiSS4.Gui.KissLookUpEdit edtInkassoTypUnterart;
        private KiSS4.Gui.KissCheckEdit edtNurLaufendeBevorschussung;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel8;
        private KissLabel lblAbschlussgrund;
        private KiSS4.Gui.KissLabel lblAnzahlfaelle;
        private KiSS4.Gui.KissLabel lblAnzahlGlaeubiger;
        private KiSS4.Gui.KissLabel lblGlaeubiger;
        private KiSS4.Gui.KissLabel lblInkassofaelle;
        private KiSS4.Gui.KissLabel lblinkassoTyp;
        private KiSS4.Gui.KissLabel lblInkassoTypUnterart;
        private KiSS4.Gui.KissLabel lblRueckerstattungTypX;
        private KiSS4.Gui.KissLabel lblUserID;
        #endregion

        #region Constructors

        public CtlQueryIkFallführung()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryIkFallführung));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.lblInkassofaelle = new KiSS4.Gui.KissLabel();
            this.lblGlaeubiger = new KiSS4.Gui.KissLabel();
            this.lblAnzahlfaelle = new KiSS4.Gui.KissLabel();
            this.lblAnzahlGlaeubiger = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtInkassoTyp = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissLabel8 = new KiSS4.Gui.KissLabel();
            this.lblinkassoTyp = new KiSS4.Gui.KissLabel();
            this.lblInkassoTypUnterart = new KiSS4.Gui.KissLabel();
            this.lblUserID = new KiSS4.Gui.KissLabel();
            this.edtInkassoTypUnterart = new KiSS4.Gui.KissLookUpEdit();
            this.chkLaufendeBevorschussung = new KiSS4.Gui.KissCheckEdit();
            this.chkNurLaufendeBevorschussung = new KiSS4.Gui.KissCheckEdit();
            this.edtNurLaufendeBevorschussung = new KiSS4.Gui.KissCheckEdit();
            this.edtInkassofallStatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtExtensiveFaelle = new KiSS4.Gui.KissCheckEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtAbgeschlosseneFaelle = new KiSS4.Gui.KissCheckEdit();
            this.edtArchivierteFaelle = new KiSS4.Gui.KissCheckEdit();
            this.lblRueckerstattungTypX = new KiSS4.Gui.KissLabel();
            this.edtIkRueckerstattungTyp = new KiSS4.Gui.KissLookUpEdit();
            this.colAnzahlFaelle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnzahlGlaeubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colArchiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemhung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemuehungText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDatumAnpassenAb = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colElterlicheSorge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colElterlicheSorgeBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaLeistungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlaeubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGlubiger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkForderungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkGlaeubigerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIkRechtstitelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassoFallName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colInkassoTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmonatlBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMonatsBevorschussung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRckerstattungtyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSchuldner = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerjaehrungAm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.edtAbschlussgrund = new KiSS4.Gui.KissLookUpEdit();
            this.lblAbschlussgrund = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblInkassofaelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGlaeubiger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlfaelle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlGlaeubiger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblinkassoTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInkassoTypUnterart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLaufendeBevorschussung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurLaufendeBevorschussung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurLaufendeBevorschussung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExtensiveFaelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbgeschlosseneFaelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArchivierteFaelle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckerstattungTypX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattungTyp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattungTyp.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussgrund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussgrund.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgrund)).BeginInit();
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
            this.grvQuery1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvQuery1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            this.grdQuery1.Location = new System.Drawing.Point(3, 49);
            this.grdQuery1.Size = new System.Drawing.Size(766, 382);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(164, 476);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 437);
            // 
            // lblSuchkriterienInfo
            // 
            this.lblSuchkriterienInfo.Location = new System.Drawing.Point(306, 438);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.SelectedTabIndex = 1;
            this.tabControlSearch.Size = new System.Drawing.Size(784, 501);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.lblAnzahlGlaeubiger);
            this.tpgListe.Controls.Add(this.lblAnzahlfaelle);
            this.tpgListe.Controls.Add(this.lblGlaeubiger);
            this.tpgListe.Controls.Add(this.lblInkassofaelle);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(772, 463);
            this.tpgListe.Controls.SetChildIndex(this.lblSuchkriterienInfo, 0);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblInkassofaelle, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblGlaeubiger, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblAnzahlfaelle, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblAnzahlGlaeubiger, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtAbschlussgrund);
            this.tpgSuchen.Controls.Add(this.edtIkRueckerstattungTyp);
            this.tpgSuchen.Controls.Add(this.lblAbschlussgrund);
            this.tpgSuchen.Controls.Add(this.lblRueckerstattungTypX);
            this.tpgSuchen.Controls.Add(this.edtArchivierteFaelle);
            this.tpgSuchen.Controls.Add(this.edtAbgeschlosseneFaelle);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtExtensiveFaelle);
            this.tpgSuchen.Controls.Add(this.edtInkassofallStatus);
            this.tpgSuchen.Controls.Add(this.edtNurLaufendeBevorschussung);
            this.tpgSuchen.Controls.Add(this.chkNurLaufendeBevorschussung);
            this.tpgSuchen.Controls.Add(this.chkLaufendeBevorschussung);
            this.tpgSuchen.Controls.Add(this.edtInkassoTypUnterart);
            this.tpgSuchen.Controls.Add(this.lblUserID);
            this.tpgSuchen.Controls.Add(this.lblInkassoTypUnterart);
            this.tpgSuchen.Controls.Add(this.lblinkassoTyp);
            this.tpgSuchen.Controls.Add(this.kissLabel8);
            this.tpgSuchen.Controls.Add(this.kissLabel7);
            this.tpgSuchen.Controls.Add(this.kissLabel6);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtInkassoTyp);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(772, 463);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel5, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel6, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel7, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel8, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblinkassoTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblInkassoTypUnterart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassoTypUnterart, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkLaufendeBevorschussung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.chkNurLaufendeBevorschussung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtNurLaufendeBevorschussung, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtInkassofallStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtExtensiveFaelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAbgeschlosseneFaelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtArchivierteFaelle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblRueckerstattungTypX, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblAbschlussgrund, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtIkRueckerstattungTyp, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtAbschlussgrund, 0);
            // 
            // lblInkassofaelle
            // 
            this.lblInkassofaelle.Location = new System.Drawing.Point(212, 3);
            this.lblInkassofaelle.Name = "lblInkassofaelle";
            this.lblInkassofaelle.Size = new System.Drawing.Size(79, 24);
            this.lblInkassofaelle.TabIndex = 3;
            this.lblInkassofaelle.Text = "Inkassofälle:";
            this.lblInkassofaelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblInkassofaelle.UseCompatibleTextRendering = true;
            // 
            // lblGlaeubiger
            // 
            this.lblGlaeubiger.Location = new System.Drawing.Point(212, 22);
            this.lblGlaeubiger.Name = "lblGlaeubiger";
            this.lblGlaeubiger.Size = new System.Drawing.Size(79, 24);
            this.lblGlaeubiger.TabIndex = 4;
            this.lblGlaeubiger.Text = "Gläubiger:";
            this.lblGlaeubiger.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblGlaeubiger.UseCompatibleTextRendering = true;
            // 
            // lblAnzahlfaelle
            // 
            this.lblAnzahlfaelle.DataMember = "AnzahlFaelle$";
            this.lblAnzahlfaelle.DataSource = this.qryQuery;
            this.lblAnzahlfaelle.Location = new System.Drawing.Point(308, 3);
            this.lblAnzahlfaelle.Name = "lblAnzahlfaelle";
            this.lblAnzahlfaelle.Size = new System.Drawing.Size(100, 23);
            this.lblAnzahlfaelle.TabIndex = 5;
            this.lblAnzahlfaelle.UseCompatibleTextRendering = true;
            // 
            // lblAnzahlGlaeubiger
            // 
            this.lblAnzahlGlaeubiger.DataMember = "AnzahlGlaeubiger$";
            this.lblAnzahlGlaeubiger.DataSource = this.qryQuery;
            this.lblAnzahlGlaeubiger.Location = new System.Drawing.Point(308, 23);
            this.lblAnzahlGlaeubiger.Name = "lblAnzahlGlaeubiger";
            this.lblAnzahlGlaeubiger.Size = new System.Drawing.Size(100, 23);
            this.lblAnzahlGlaeubiger.TabIndex = 6;
            this.lblAnzahlGlaeubiger.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(251, 63);
            this.edtUserID.Name = "edtUserID";
            this.edtUserID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtUserID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtUserID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUserID.Properties.Appearance.Options.UseBackColor = true;
            this.edtUserID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtUserID.Properties.Appearance.Options.UseFont = true;
            this.edtUserID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtUserID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtUserID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(271, 24);
            this.edtUserID.TabIndex = 0;
            this.edtUserID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtUserID_UserModifiedFld);
            // 
            // edtInkassoTyp
            // 
            this.edtInkassoTyp.Location = new System.Drawing.Point(251, 93);
            this.edtInkassoTyp.LOVFilter = "Code between 401 and 499";
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
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtInkassoTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtInkassoTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtInkassoTyp.Properties.NullText = "";
            this.edtInkassoTyp.Properties.ShowFooter = false;
            this.edtInkassoTyp.Properties.ShowHeader = false;
            this.edtInkassoTyp.Size = new System.Drawing.Size(271, 24);
            this.edtInkassoTyp.TabIndex = 1;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Location = new System.Drawing.Point(32, 183);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(142, 24);
            this.kissLabel1.TabIndex = 1;
            this.kissLabel1.Text = "Status";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Location = new System.Drawing.Point(32, 273);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(142, 24);
            this.kissLabel2.TabIndex = 1;
            this.kissLabel2.Text = "inkl. abgeschlossene Fälle";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Location = new System.Drawing.Point(32, 243);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(142, 24);
            this.kissLabel3.TabIndex = 1;
            this.kissLabel3.Text = "Verjährung  von";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // kissLabel4
            // 
            this.kissLabel4.Location = new System.Drawing.Point(32, 147);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(142, 24);
            this.kissLabel4.TabIndex = 1;
            this.kissLabel4.Text = "Einnahmen vorhanden";
            this.kissLabel4.UseCompatibleTextRendering = true;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Location = new System.Drawing.Point(375, 243);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(26, 24);
            this.kissLabel5.TabIndex = 1;
            this.kissLabel5.Text = "bis";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(32, 153);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(186, 24);
            this.kissLabel6.TabIndex = 1;
            this.kissLabel6.Text = "nur laufende Bevorschussung";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Location = new System.Drawing.Point(32, 213);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(186, 24);
            this.kissLabel7.TabIndex = 1;
            this.kissLabel7.Text = "nur extensive Fälle";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // kissLabel8
            // 
            this.kissLabel8.Location = new System.Drawing.Point(32, 303);
            this.kissLabel8.Name = "kissLabel8";
            this.kissLabel8.Size = new System.Drawing.Size(142, 24);
            this.kissLabel8.TabIndex = 1;
            this.kissLabel8.Text = "inkl. archivierte Fälle";
            this.kissLabel8.UseCompatibleTextRendering = true;
            // 
            // lblinkassoTyp
            // 
            this.lblinkassoTyp.Location = new System.Drawing.Point(32, 93);
            this.lblinkassoTyp.Name = "lblinkassoTyp";
            this.lblinkassoTyp.Size = new System.Drawing.Size(142, 24);
            this.lblinkassoTyp.TabIndex = 1;
            this.lblinkassoTyp.Text = "Inkasso-Typ";
            this.lblinkassoTyp.UseCompatibleTextRendering = true;
            // 
            // lblInkassoTypUnterart
            // 
            this.lblInkassoTypUnterart.Location = new System.Drawing.Point(32, 123);
            this.lblInkassoTypUnterart.Name = "lblInkassoTypUnterart";
            this.lblInkassoTypUnterart.Size = new System.Drawing.Size(142, 24);
            this.lblInkassoTypUnterart.TabIndex = 1;
            this.lblInkassoTypUnterart.Text = "Inkasso-Typ Unterart";
            this.lblInkassoTypUnterart.UseCompatibleTextRendering = true;
            // 
            // lblUserID
            // 
            this.lblUserID.Location = new System.Drawing.Point(32, 63);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(142, 24);
            this.lblUserID.TabIndex = 1;
            this.lblUserID.Text = "SAR";
            this.lblUserID.UseCompatibleTextRendering = true;
            // 
            // edtInkassoTypUnterart
            // 
            this.edtInkassoTypUnterart.Location = new System.Drawing.Point(251, 123);
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
            this.edtInkassoTypUnterart.TabIndex = 2;
            // 
            // chkLaufendeBevorschussung
            // 
            this.chkLaufendeBevorschussung.EditValue = false;
            this.chkLaufendeBevorschussung.Location = new System.Drawing.Point(251, 153);
            this.chkLaufendeBevorschussung.Name = "chkLaufendeBevorschussung";
            this.chkLaufendeBevorschussung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkLaufendeBevorschussung.Properties.Appearance.Options.UseBackColor = true;
            this.chkLaufendeBevorschussung.Properties.Caption = "";
            this.chkLaufendeBevorschussung.Size = new System.Drawing.Size(75, 19);
            this.chkLaufendeBevorschussung.TabIndex = 3;
            // 
            // chkNurLaufendeBevorschussung
            // 
            this.chkNurLaufendeBevorschussung.EditValue = false;
            this.chkNurLaufendeBevorschussung.Location = new System.Drawing.Point(251, 152);
            this.chkNurLaufendeBevorschussung.Name = "chkNurLaufendeBevorschussung";
            this.chkNurLaufendeBevorschussung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkNurLaufendeBevorschussung.Properties.Appearance.Options.UseBackColor = true;
            this.chkNurLaufendeBevorschussung.Properties.Caption = "";
            this.chkNurLaufendeBevorschussung.Size = new System.Drawing.Size(75, 19);
            this.chkNurLaufendeBevorschussung.TabIndex = 3;
            // 
            // edtNurLaufendeBevorschussung
            // 
            this.edtNurLaufendeBevorschussung.EditValue = false;
            this.edtNurLaufendeBevorschussung.Location = new System.Drawing.Point(251, 152);
            this.edtNurLaufendeBevorschussung.Name = "edtNurLaufendeBevorschussung";
            this.edtNurLaufendeBevorschussung.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtNurLaufendeBevorschussung.Properties.Appearance.Options.UseBackColor = true;
            this.edtNurLaufendeBevorschussung.Properties.Caption = "";
            this.edtNurLaufendeBevorschussung.Size = new System.Drawing.Size(75, 19);
            this.edtNurLaufendeBevorschussung.TabIndex = 3;
            // 
            // edtInkassofallStatus
            // 
            this.edtInkassofallStatus.Location = new System.Drawing.Point(251, 183);
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
            this.edtInkassofallStatus.TabIndex = 4;
            // 
            // edtExtensiveFaelle
            // 
            this.edtExtensiveFaelle.EditValue = false;
            this.edtExtensiveFaelle.Location = new System.Drawing.Point(251, 213);
            this.edtExtensiveFaelle.Name = "edtExtensiveFaelle";
            this.edtExtensiveFaelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtExtensiveFaelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtExtensiveFaelle.Properties.Caption = "";
            this.edtExtensiveFaelle.Size = new System.Drawing.Size(75, 19);
            this.edtExtensiveFaelle.TabIndex = 5;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(251, 243);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 6;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(422, 243);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
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
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 7;
            // 
            // edtAbgeschlosseneFaelle
            // 
            this.edtAbgeschlosseneFaelle.EditValue = false;
            this.edtAbgeschlosseneFaelle.Location = new System.Drawing.Point(251, 273);
            this.edtAbgeschlosseneFaelle.Name = "edtAbgeschlosseneFaelle";
            this.edtAbgeschlosseneFaelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtAbgeschlosseneFaelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbgeschlosseneFaelle.Properties.Caption = "";
            this.edtAbgeschlosseneFaelle.Size = new System.Drawing.Size(75, 19);
            this.edtAbgeschlosseneFaelle.TabIndex = 8;
            // 
            // edtArchivierteFaelle
            // 
            this.edtArchivierteFaelle.EditValue = false;
            this.edtArchivierteFaelle.Location = new System.Drawing.Point(251, 303);
            this.edtArchivierteFaelle.Name = "edtArchivierteFaelle";
            this.edtArchivierteFaelle.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtArchivierteFaelle.Properties.Appearance.Options.UseBackColor = true;
            this.edtArchivierteFaelle.Properties.Caption = "";
            this.edtArchivierteFaelle.Size = new System.Drawing.Size(75, 19);
            this.edtArchivierteFaelle.TabIndex = 9;
            // 
            // lblRueckerstattungTypX
            // 
            this.lblRueckerstattungTypX.Location = new System.Drawing.Point(32, 337);
            this.lblRueckerstattungTypX.Name = "lblRueckerstattungTypX";
            this.lblRueckerstattungTypX.Size = new System.Drawing.Size(142, 24);
            this.lblRueckerstattungTypX.TabIndex = 10;
            this.lblRueckerstattungTypX.Text = "Rückerstattungs-Typ";
            this.lblRueckerstattungTypX.UseCompatibleTextRendering = true;
            // 
            // edtIkRueckerstattungTyp
            // 
            this.edtIkRueckerstattungTyp.Location = new System.Drawing.Point(251, 337);
            this.edtIkRueckerstattungTyp.LOVName = "IkRueckerstattungTyp";
            this.edtIkRueckerstattungTyp.Name = "edtIkRueckerstattungTyp";
            this.edtIkRueckerstattungTyp.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtIkRueckerstattungTyp.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtIkRueckerstattungTyp.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRueckerstattungTyp.Properties.Appearance.Options.UseBackColor = true;
            this.edtIkRueckerstattungTyp.Properties.Appearance.Options.UseBorderColor = true;
            this.edtIkRueckerstattungTyp.Properties.Appearance.Options.UseFont = true;
            this.edtIkRueckerstattungTyp.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtIkRueckerstattungTyp.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtIkRueckerstattungTyp.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtIkRueckerstattungTyp.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtIkRueckerstattungTyp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtIkRueckerstattungTyp.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtIkRueckerstattungTyp.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtIkRueckerstattungTyp.Properties.NullText = "";
            this.edtIkRueckerstattungTyp.Properties.ShowFooter = false;
            this.edtIkRueckerstattungTyp.Properties.ShowHeader = false;
            this.edtIkRueckerstattungTyp.Size = new System.Drawing.Size(271, 24);
            this.edtIkRueckerstattungTyp.TabIndex = 11;
            // 
            // colAnzahlFaelle
            // 
            this.colAnzahlFaelle.Name = "colAnzahlFaelle";
            // 
            // colAnzahlGlaeubiger
            // 
            this.colAnzahlGlaeubiger.Name = "colAnzahlGlaeubiger";
            // 
            // colArchiv
            // 
            this.colArchiv.Name = "colArchiv";
            // 
            // colBemhung
            // 
            this.colBemhung.Name = "colBemhung";
            // 
            // colBemuehungText
            // 
            this.colBemuehungText.Name = "colBemuehungText";
            // 
            // colDatumAnpassenAb
            // 
            this.colDatumAnpassenAb.Name = "colDatumAnpassenAb";
            // 
            // colElterlicheSorge
            // 
            this.colElterlicheSorge.Name = "colElterlicheSorge";
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
            // colGlubiger
            // 
            this.colGlubiger.Name = "colGlubiger";
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
            // colmonatlBetrag
            // 
            this.colmonatlBetrag.Name = "colmonatlBetrag";
            // 
            // colMonatsBevorschussung
            // 
            this.colMonatsBevorschussung.Name = "colMonatsBevorschussung";
            // 
            // colRckerstattungtyp
            // 
            this.colRckerstattungtyp.Name = "colRckerstattungtyp";
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
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseBorderColor = true;
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
            // edtAbschlussgrund
            // 
            this.edtAbschlussgrund.Location = new System.Drawing.Point(251, 367);
            this.edtAbschlussgrund.LOVFilter = "I";
            this.edtAbschlussgrund.LOVName = "Abschlussgrund";
            this.edtAbschlussgrund.Name = "edtAbschlussgrund";
            this.edtAbschlussgrund.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAbschlussgrund.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAbschlussgrund.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussgrund.Properties.Appearance.Options.UseBackColor = true;
            this.edtAbschlussgrund.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAbschlussgrund.Properties.Appearance.Options.UseFont = true;
            this.edtAbschlussgrund.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtAbschlussgrund.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtAbschlussgrund.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtAbschlussgrund.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtAbschlussgrund.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtAbschlussgrund.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtAbschlussgrund.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtAbschlussgrund.Properties.NullText = "";
            this.edtAbschlussgrund.Properties.ShowFooter = false;
            this.edtAbschlussgrund.Properties.ShowHeader = false;
            this.edtAbschlussgrund.Size = new System.Drawing.Size(271, 24);
            this.edtAbschlussgrund.TabIndex = 11;
            // 
            // lblAbschlussgrund
            // 
            this.lblAbschlussgrund.Location = new System.Drawing.Point(32, 367);
            this.lblAbschlussgrund.Name = "lblAbschlussgrund";
            this.lblAbschlussgrund.Size = new System.Drawing.Size(142, 24);
            this.lblAbschlussgrund.TabIndex = 10;
            this.lblAbschlussgrund.Text = "Abschlussgrund";
            this.lblAbschlussgrund.UseCompatibleTextRendering = true;
            // 
            // CtlQueryIkFallführung
            // 
            this.Name = "CtlQueryIkFallführung";
            this.Size = new System.Drawing.Size(800, 539);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblInkassofaelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGlaeubiger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlfaelle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahlGlaeubiger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblinkassoTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblUserID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassoTypUnterart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLaufendeBevorschussung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNurLaufendeBevorschussung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNurLaufendeBevorschussung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtInkassofallStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtExtensiveFaelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbgeschlosseneFaelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtArchivierteFaelle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblRueckerstattungTypX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattungTyp.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtIkRueckerstattungTyp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussgrund.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAbschlussgrund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAbschlussgrund)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Private Methods

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
    }
}