using System;
using KiSS4.DB;

namespace KiSS4.Query
{
    public class CtlQueryAyUebersichtKlientinnen : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colandAuf;
        private DevExpress.XtraGrid.Columns.GridColumn colAufenthCH;
        private DevExpress.XtraGrid.Columns.GridColumn colAustrittAK;
        private DevExpress.XtraGrid.Columns.GridColumn colAustrittsgrund;
        private DevExpress.XtraGrid.Columns.GridColumn colBFFNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colEinreisedatum;
        private DevExpress.XtraGrid.Columns.GridColumn colEintrittAK;
        private DevExpress.XtraGrid.Columns.GridColumn colF;
        private DevExpress.XtraGrid.Columns.GridColumn colF7;
        private DevExpress.XtraGrid.Columns.GridColumn colFalltrger;
        private DevExpress.XtraGrid.Columns.GridColumn colGeburtsdatum;
        private DevExpress.XtraGrid.Columns.GridColumn colGrsseHaushalt;
        private DevExpress.XtraGrid.Columns.GridColumn colGrsseUE;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenanteilUE;
        private DevExpress.XtraGrid.Columns.GridColumn colm;
        private DevExpress.XtraGrid.Columns.GridColumn colMiete;
        private DevExpress.XtraGrid.Columns.GridColumn colmnnlich;
        private DevExpress.XtraGrid.Columns.GridColumn colN;
        private DevExpress.XtraGrid.Columns.GridColumn colNationalitt;
        private DevExpress.XtraGrid.Columns.GridColumn colNebenkosten;
        private DevExpress.XtraGrid.Columns.GridColumn colNNummer;
        private DevExpress.XtraGrid.Columns.GridColumn colOrt;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonen;
        private DevExpress.XtraGrid.Columns.GridColumn colRW;
        private DevExpress.XtraGrid.Columns.GridColumn colSARName;
        private DevExpress.XtraGrid.Columns.GridColumn colStrasse;
        private DevExpress.XtraGrid.Columns.GridColumn colTotal;
        private DevExpress.XtraGrid.Columns.GridColumn colw;
        private DevExpress.XtraGrid.Columns.GridColumn colweiblich;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlGotoFall ctlGotoFallStelleBI;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissCheckEdit edtFT;
        private KiSS4.Gui.KissLookUpEdit edtStatus;
        private KiSS4.Gui.KissButtonEdit edtUserID;
        private KiSS4.Gui.KissGrid grdDetails;
        private DevExpress.XtraGrid.Views.Grid.GridView grvDetails;
        private KiSS4.Gui.KissLabel lblbis;
        private KiSS4.Gui.KissLabel lblSAR;
        private KiSS4.Gui.KissLabel lblStatus;
        private KiSS4.Gui.KissLabel lblZeitraumvon;
        private KiSS4.DB.SqlQuery qryListe2;
        private SharpLibrary.WinControls.TabPageEx tpgListe2;

        #endregion

        #region Constructors

        public CtlQueryAyUebersichtKlientinnen()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryAyUebersichtKlientinnen));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tpgListe2 = new SharpLibrary.WinControls.TabPageEx();
            this.ctlGotoFallStelleBI = new KiSS4.Common.CtlGotoFall();
            this.grdDetails = new KiSS4.Gui.KissGrid();
            this.qryListe2 = new KiSS4.DB.SqlQuery(this.components);
            this.grvDetails = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblSAR = new KiSS4.Gui.KissLabel();
            this.lblZeitraumvon = new KiSS4.Gui.KissLabel();
            this.lblbis = new KiSS4.Gui.KissLabel();
            this.lblStatus = new KiSS4.Gui.KissLabel();
            this.edtUserID = new KiSS4.Gui.KissButtonEdit();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.edtStatus = new KiSS4.Gui.KissLookUpEdit();
            this.edtFT = new KiSS4.Gui.KissCheckEdit();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colandAuf = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAufenthCH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustrittAK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAustrittsgrund = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBFFNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEinreisedatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEintrittAK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colF7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFalltrger = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeburtsdatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrsseHaushalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGrsseUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenanteilUE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiete = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmnnlich = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNationalitt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNebenkosten = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNNummer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSARName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStrasse = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colw = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colweiblich = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.tpgListe2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).BeginInit();
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
            this.xDocument.Visible = false;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.DataMember = "BaPersonID$";
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Controls.Add(this.tpgListe2);
            this.tabControlSearch.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgListe2});
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgListe2, 0);
            this.tabControlSearch.Controls.SetChildIndex(this.tpgSuchen, 0);
            // 
            // tpgListe
            // 
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.edtFT);
            this.tpgSuchen.Controls.Add(this.edtStatus);
            this.tpgSuchen.Controls.Add(this.edtDatumBis);
            this.tpgSuchen.Controls.Add(this.edtDatumVon);
            this.tpgSuchen.Controls.Add(this.edtUserID);
            this.tpgSuchen.Controls.Add(this.lblStatus);
            this.tpgSuchen.Controls.Add(this.lblbis);
            this.tpgSuchen.Controls.Add(this.lblZeitraumvon);
            this.tpgSuchen.Controls.Add(this.lblSAR);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.TabIndex = 2;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSAR, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblZeitraumvon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblbis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtUserID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtStatus, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtFT, 0);
            // 
            // tpgListe2
            // 
            this.tpgListe2.Controls.Add(this.ctlGotoFallStelleBI);
            this.tpgListe2.Controls.Add(this.grdDetails);
            this.tpgListe2.Location = new System.Drawing.Point(6, 6);
            this.tpgListe2.Name = "tpgListe2";
            this.tpgListe2.Size = new System.Drawing.Size(772, 424);
            this.tpgListe2.TabIndex = 1;
            this.tpgListe2.Title = "Liste 2";
            // 
            // ctlGotoFallStelleBI
            // 
            this.ctlGotoFallStelleBI.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallStelleBI.Location = new System.Drawing.Point(3, 398);
            this.ctlGotoFallStelleBI.Name = "ctlGotoFallStelleBI";
            this.ctlGotoFallStelleBI.Size = new System.Drawing.Size(154, 24);
            this.ctlGotoFallStelleBI.TabIndex = 7;
            this.ctlGotoFallStelleBI.Visible = false;
            // 
            // grdDetails
            // 
            this.grdDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDetails.DataSource = this.qryListe2;
            // 
            // 
            // 
            this.grdDetails.EmbeddedNavigator.Name = "";
            this.grdDetails.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdDetails.Location = new System.Drawing.Point(3, 2);
            this.grdDetails.MainView = this.grvDetails;
            this.grdDetails.Name = "grdDetails";
            this.grdDetails.Size = new System.Drawing.Size(766, 392);
            this.grdDetails.TabIndex = 6;
            this.grdDetails.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvDetails});
            // 
            // qryListe2
            // 
            this.qryListe2.FillTimeOut = 300;
            this.qryListe2.HostControl = this;
            this.qryListe2.IsIdentityInsert = false;
            this.qryListe2.SelectStatement = resources.GetString("qryListe2.SelectStatement");
            // 
            // grvDetails
            // 
            this.grvDetails.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvDetails.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.Empty.Options.UseBackColor = true;
            this.grvDetails.Appearance.Empty.Options.UseFont = true;
            this.grvDetails.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.EvenRow.Options.UseFont = true;
            this.grvDetails.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDetails.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvDetails.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvDetails.Appearance.FocusedCell.Options.UseFont = true;
            this.grvDetails.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvDetails.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvDetails.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvDetails.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvDetails.Appearance.FocusedRow.Options.UseFont = true;
            this.grvDetails.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvDetails.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDetails.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDetails.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvDetails.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvDetails.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDetails.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvDetails.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvDetails.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDetails.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDetails.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvDetails.Appearance.GroupRow.Options.UseFont = true;
            this.grvDetails.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvDetails.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvDetails.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvDetails.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvDetails.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvDetails.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvDetails.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvDetails.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvDetails.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvDetails.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvDetails.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvDetails.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvDetails.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvDetails.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvDetails.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.OddRow.Options.UseFont = true;
            this.grvDetails.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvDetails.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.Row.Options.UseBackColor = true;
            this.grvDetails.Appearance.Row.Options.UseFont = true;
            this.grvDetails.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvDetails.Appearance.SelectedRow.Options.UseFont = true;
            this.grvDetails.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvDetails.Appearance.VertLine.Options.UseBackColor = true;
            this.grvDetails.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvDetails.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvDetails.GridControl = this.grdDetails;
            this.grvDetails.Name = "grvDetails";
            this.grvDetails.OptionsBehavior.Editable = false;
            this.grvDetails.OptionsCustomization.AllowFilter = false;
            this.grvDetails.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvDetails.OptionsNavigation.AutoFocusNewRow = true;
            this.grvDetails.OptionsNavigation.UseTabKey = false;
            this.grvDetails.OptionsView.ColumnAutoWidth = false;
            this.grvDetails.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvDetails.OptionsView.ShowGroupPanel = false;
            this.grvDetails.OptionsView.ShowIndicator = false;
            // 
            // lblSAR
            // 
            this.lblSAR.Location = new System.Drawing.Point(10, 40);
            this.lblSAR.Name = "lblSAR";
            this.lblSAR.Size = new System.Drawing.Size(130, 24);
            this.lblSAR.TabIndex = 1;
            this.lblSAR.Text = "SAR";
            this.lblSAR.UseCompatibleTextRendering = true;
            // 
            // lblZeitraumvon
            // 
            this.lblZeitraumvon.Location = new System.Drawing.Point(10, 70);
            this.lblZeitraumvon.Name = "lblZeitraumvon";
            this.lblZeitraumvon.Size = new System.Drawing.Size(130, 24);
            this.lblZeitraumvon.TabIndex = 2;
            this.lblZeitraumvon.Text = "Zeitraum von";
            this.lblZeitraumvon.UseCompatibleTextRendering = true;
            // 
            // lblbis
            // 
            this.lblbis.Location = new System.Drawing.Point(270, 70);
            this.lblbis.Name = "lblbis";
            this.lblbis.Size = new System.Drawing.Size(130, 24);
            this.lblbis.TabIndex = 3;
            this.lblbis.Text = "bis";
            this.lblbis.UseCompatibleTextRendering = true;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(10, 100);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(130, 24);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseCompatibleTextRendering = true;
            // 
            // edtUserID
            // 
            this.edtUserID.Location = new System.Drawing.Point(150, 40);
            this.edtUserID.LookupSQL = resources.GetString("edtUserID.LookupSQL");
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
            this.edtUserID.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.edtUserID.Size = new System.Drawing.Size(250, 24);
            this.edtUserID.TabIndex = 21;
            // 
            // edtDatumVon
            // 
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(150, 70);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtDatumVon.TabIndex = 22;
            // 
            // edtDatumBis
            // 
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(300, 70);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtDatumBis.TabIndex = 23;
            // 
            // edtStatus
            // 
            this.edtStatus.Location = new System.Drawing.Point(150, 100);
            this.edtStatus.Name = "edtStatus";
            this.edtStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStatus.Properties.Appearance.Options.UseFont = true;
            this.edtStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtStatus.Properties.NullText = "";
            this.edtStatus.Properties.ShowFooter = false;
            this.edtStatus.Properties.ShowHeader = false;
            this.edtStatus.Size = new System.Drawing.Size(250, 24);
            this.edtStatus.TabIndex = 24;
            // 
            // edtFT
            // 
            this.edtFT.EditValue = true;
            this.edtFT.Location = new System.Drawing.Point(150, 130);
            this.edtFT.Name = "edtFT";
            this.edtFT.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtFT.Properties.Appearance.Options.UseBackColor = true;
            this.edtFT.Properties.Caption = "nur Falltraeger";
            this.edtFT.Size = new System.Drawing.Size(200, 19);
            this.edtFT.TabIndex = 25;
            // 
            // colAlter
            // 
            this.colAlter.Name = "colAlter";
            // 
            // colandAuf
            // 
            this.colandAuf.Name = "colandAuf";
            // 
            // colAufenthCH
            // 
            this.colAufenthCH.Name = "colAufenthCH";
            // 
            // colAustrittAK
            // 
            this.colAustrittAK.Name = "colAustrittAK";
            // 
            // colAustrittsgrund
            // 
            this.colAustrittsgrund.Name = "colAustrittsgrund";
            // 
            // colBFFNummer
            // 
            this.colBFFNummer.Name = "colBFFNummer";
            // 
            // colEinreisedatum
            // 
            this.colEinreisedatum.Name = "colEinreisedatum";
            // 
            // colEintrittAK
            // 
            this.colEintrittAK.Name = "colEintrittAK";
            // 
            // colF
            // 
            this.colF.Name = "colF";
            // 
            // colF7
            // 
            this.colF7.Name = "colF7";
            // 
            // colFalltrger
            // 
            this.colFalltrger.Name = "colFalltrger";
            // 
            // colGeburtsdatum
            // 
            this.colGeburtsdatum.Name = "colGeburtsdatum";
            // 
            // colGrsseHaushalt
            // 
            this.colGrsseHaushalt.Name = "colGrsseHaushalt";
            // 
            // colGrsseUE
            // 
            this.colGrsseUE.Name = "colGrsseUE";
            // 
            // colKostenanteilUE
            // 
            this.colKostenanteilUE.Name = "colKostenanteilUE";
            // 
            // colm
            // 
            this.colm.Name = "colm";
            // 
            // colMiete
            // 
            this.colMiete.Name = "colMiete";
            // 
            // colmnnlich
            // 
            this.colmnnlich.Name = "colmnnlich";
            // 
            // colN
            // 
            this.colN.Name = "colN";
            // 
            // colNationalitt
            // 
            this.colNationalitt.Name = "colNationalitt";
            // 
            // colNebenkosten
            // 
            this.colNebenkosten.Name = "colNebenkosten";
            // 
            // colNNummer
            // 
            this.colNNummer.Name = "colNNummer";
            // 
            // colOrt
            // 
            this.colOrt.Name = "colOrt";
            // 
            // colPerson
            // 
            this.colPerson.Name = "colPerson";
            // 
            // colPersonen
            // 
            this.colPersonen.Name = "colPersonen";
            // 
            // colRW
            // 
            this.colRW.Name = "colRW";
            // 
            // colSARName
            // 
            this.colSARName.Name = "colSARName";
            // 
            // colStrasse
            // 
            this.colStrasse.Name = "colStrasse";
            // 
            // colTotal
            // 
            this.colTotal.Name = "colTotal";
            // 
            // colw
            // 
            this.colw.Name = "colw";
            // 
            // colweiblich
            // 
            this.colweiblich.Name = "colweiblich";
            // 
            // CtlQueryAyUebersichtKlientinnen
            // 
            this.Name = "CtlQueryAyUebersichtKlientinnen";
            this.Load += new System.EventHandler(this.CtlQueryAyUebersichtKlientinnen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            this.tpgListe2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryListe2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSAR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZeitraumvon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblbis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtUserID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFT.Properties)).EndInit();
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

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            edtStatus.EditValue = 1;
            edtFT.Checked = true;

            edtUserID.EditValue = null;
            edtUserID.LookupID = null;
            edtDatumVon.EditValue = null;
            edtDatumBis.EditValue = null;
        }

        #endregion

        #region Private Methods

        private void CtlQueryAyUebersichtKlientinnen_Load(object sender, System.EventArgs e)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"select Code = 1, Text = 'aktiv'
             union all
             select Code = 2, Text = 'geschlossen'");
            System.Data.DataRow NewRow = qry.DataTable.NewRow();
            NewRow["Text"] = "";
            qry.DataTable.Rows.InsertAt(NewRow, 0);
            NewRow.AcceptChanges();
            edtStatus.Properties.Columns.Clear();
            edtStatus.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[]
                                                       {
                                                          new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "", 75, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Default)
                                                       });
            edtStatus.Properties.ShowFooter = false;
            edtStatus.Properties.ShowHeader = false;
            edtStatus.Properties.DisplayMember = "Text";
            edtStatus.Properties.ValueMember = "Code";
            edtStatus.Properties.DropDownRows = Math.Min(qry.Count, 7);
            edtStatus.Properties.DataSource = qry;

            edtStatus.EditValue = 1;
        }

        #endregion
    }
}