using System;
using System.Data;
using System.Windows.Forms;
using KiSS4.Common.ZH;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Query.ZH
{
    public class CtlQueryKgLiquiditaet : KiSS4.Common.KissQueryControl
    {
        #region Fields

        private KiSS4.Gui.KissButton btnMonatsbudget;
        private DevExpress.XtraGrid.Columns.GridColumn colBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colKgBuchungID;
        private DevExpress.XtraGrid.Columns.GridColumn colKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colKreditor;
        private DevExpress.XtraGrid.Columns.GridColumn colMandant;
        private DevExpress.XtraGrid.Columns.GridColumn colPendenteBarbelege;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldovorschau;
        private DevExpress.XtraGrid.Columns.GridColumn colSozialzentrum;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTeam;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalAuszahlungen;
        private DevExpress.XtraGrid.Columns.GridColumn colTotalEinzahlungen;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private DevExpress.XtraGrid.Columns.GridColumn colValuta;
        private DevExpress.XtraGrid.Columns.GridColumn colZKBSaldoKiss;
        private KiSS4.Common.ZH.CtlOrgUnitTeamUser ctlOrgUnitTeamUser;
        private KiSS4.Gui.KissTextEdit edtBaPersonID;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissDateEdit edtErfassungDatum;
        private KiSS4.Gui.KissMemoEdit edtKreditor;
        private KissCalcEdit edtSaldovorschau;
        private KiSS4.Gui.KissLookUpEdit edtSucheAuszahlungsArt;
        private KiSS4.Gui.KissDateEdit edtSucheValutaBis;
        private DevExpress.XtraGrid.Views.Grid.GridView grvZahllauf;
        private KiSS4.Gui.KissCalcEdit kissCalcEdit1;
        private KiSS4.Gui.KissCalcEdit kissCalcEdit2;
        private KiSS4.Gui.KissCalcEdit kissCalcEdit3;
        private KiSS4.Gui.KissCalcEdit kissCalcEdit4;
        private KissCalcEdit kissCalcEdit5;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KissLabel kissLabel13;
        private KissLabel kissLabel14;
        private KissLabel kissLabel15;
        private KissLabel kissLabel16;
        private KissLabel kissLabel17;
        private KissLabel kissLabel18;
        private KissLabel kissLabel2;
        private KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel kissLabel9;
        private KiSS4.Gui.KissMemoEdit kissMemoEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit1;
        private KiSS4.Gui.KissTextEdit kissTextEdit2;
        private KiSS4.Gui.KissTextEdit kissTextEdit3;
        private KiSS4.Gui.KissLabel lblBaZahlungswegID;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblErfassungDatum;
        private KiSS4.Gui.KissLabel lblKonto;
        private KiSS4.Gui.KissLabel lblMandant;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;

        #endregion

        #region Constructors

        public CtlQueryKgLiquiditaet()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryKgLiquiditaet));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnMonatsbudget = new KiSS4.Gui.KissButton();
            this.edtSucheValutaBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheAuszahlungsArt = new KiSS4.Gui.KissLookUpEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.ctlOrgUnitTeamUser = new KiSS4.Common.ZH.CtlOrgUnitTeamUser();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.edtErfassungDatum = new KiSS4.Gui.KissDateEdit();
            this.kissCalcEdit1 = new KiSS4.Gui.KissCalcEdit();
            this.kissMemoEdit1 = new KiSS4.Gui.KissMemoEdit();
            this.kissTextEdit3 = new KiSS4.Gui.KissTextEdit();
            this.edtKreditor = new KiSS4.Gui.KissMemoEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissTextEdit();
            this.lblKonto = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.lblErfassungDatum = new KiSS4.Gui.KissLabel();
            this.lblBaZahlungswegID = new KiSS4.Gui.KissLabel();
            this.lblMandant = new KiSS4.Gui.KissLabel();
            this.kissTextEdit1 = new KiSS4.Gui.KissTextEdit();
            this.kissTextEdit2 = new KiSS4.Gui.KissTextEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.kissCalcEdit2 = new KiSS4.Gui.KissCalcEdit();
            this.kissCalcEdit3 = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.kissCalcEdit4 = new KiSS4.Gui.KissCalcEdit();
            this.colBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKgBuchungID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKreditor = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMandant = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTotalAuszahlungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSozialzentrum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colTeam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValuta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZKBSaldoKiss = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grvZahllauf = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTotalEinzahlungen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPendenteBarbelege = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSaldovorschau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.kissCalcEdit5 = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.kissLabel13 = new KiSS4.Gui.KissLabel();
            this.kissLabel14 = new KiSS4.Gui.KissLabel();
            this.edtSaldovorschau = new KiSS4.Gui.KissCalcEdit();
            this.kissLabel18 = new KiSS4.Gui.KissLabel();
            this.kissLabel17 = new KiSS4.Gui.KissLabel();
            this.kissLabel16 = new KiSS4.Gui.KissLabel();
            this.kissLabel15 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuszahlungsArt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuszahlungsArt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaZahlungswegID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahllauf)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovorschau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).BeginInit();
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
            this.grdQuery1.MainView = this.grvZahllauf;
            this.grdQuery1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdQuery1.Size = new System.Drawing.Size(901, 323);
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvZahllauf});
            // 
            // xDocument
            // 
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(164, -2497);
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
            this.ctlGotoFall.DataMember = "BaPersonID";
            this.ctlGotoFall.Location = new System.Drawing.Point(3, 329);
            // 
            // lblSuchkriterienInfo
            // 
            this.lblSuchkriterienInfo.Location = new System.Drawing.Point(304, 331);
            this.lblSuchkriterienInfo.Size = new System.Drawing.Size(474, 24);
            // 
            // searchTitle
            // 
            this.searchTitle.Size = new System.Drawing.Size(892, 24);
            // 
            // tabControlSearch
            // 
            this.tabControlSearch.Size = new System.Drawing.Size(916, 393);
            // 
            // tpgListe
            // 
            this.tpgListe.Controls.Add(this.btnMonatsbudget);
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            this.tpgListe.Size = new System.Drawing.Size(904, 355);
            this.tpgListe.Controls.SetChildIndex(this.grdQuery1, 0);
            this.tpgListe.Controls.SetChildIndex(this.lblSuchkriterienInfo, 0);
            this.tpgListe.Controls.SetChildIndex(this.ctlGotoFall, 0);
            this.tpgListe.Controls.SetChildIndex(this.xDocument, 0);
            this.tpgListe.Controls.SetChildIndex(this.btnMonatsbudget, 0);
            // 
            // tpgSuchen
            // 
            this.tpgSuchen.Controls.Add(this.ctlOrgUnitTeamUser);
            this.tpgSuchen.Controls.Add(this.kissLabel10);
            this.tpgSuchen.Controls.Add(this.kissLabel6);
            this.tpgSuchen.Controls.Add(this.edtSucheAuszahlungsArt);
            this.tpgSuchen.Controls.Add(this.edtSucheValutaBis);
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            this.tpgSuchen.Size = new System.Drawing.Size(904, 355);
            this.tpgSuchen.TabIndex = 1;
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheValutaBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheAuszahlungsArt, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel6, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel10, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.ctlOrgUnitTeamUser, 0);
            // 
            // btnMonatsbudget
            // 
            this.btnMonatsbudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonatsbudget.Location = new System.Drawing.Point(784, 329);
            this.btnMonatsbudget.Name = "btnMonatsbudget";
            this.btnMonatsbudget.Size = new System.Drawing.Size(116, 24);
            this.btnMonatsbudget.TabIndex = 11;
            this.btnMonatsbudget.Text = "> Monatsbudget";
            this.btnMonatsbudget.UseCompatibleTextRendering = true;
            this.btnMonatsbudget.UseVisualStyleBackColor = false;
            this.btnMonatsbudget.Click += new System.EventHandler(this.btnMonatsbudget_Click);
            // 
            // edtSucheValutaBis
            // 
            this.edtSucheValutaBis.EditValue = null;
            this.edtSucheValutaBis.Location = new System.Drawing.Point(123, 133);
            this.edtSucheValutaBis.Name = "edtSucheValutaBis";
            this.edtSucheValutaBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtSucheValutaBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaBis.Properties.ShowToday = false;
            this.edtSucheValutaBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheValutaBis.TabIndex = 15;
            // 
            // edtSucheAuszahlungsArt
            // 
            this.edtSucheAuszahlungsArt.Location = new System.Drawing.Point(123, 164);
            this.edtSucheAuszahlungsArt.LOVName = "KgAuszahlungsArt";
            this.edtSucheAuszahlungsArt.Name = "edtSucheAuszahlungsArt";
            this.edtSucheAuszahlungsArt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheAuszahlungsArt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheAuszahlungsArt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuszahlungsArt.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheAuszahlungsArt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheAuszahlungsArt.Properties.Appearance.Options.UseFont = true;
            this.edtSucheAuszahlungsArt.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheAuszahlungsArt.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheAuszahlungsArt.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheAuszahlungsArt.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheAuszahlungsArt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtSucheAuszahlungsArt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtSucheAuszahlungsArt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheAuszahlungsArt.Properties.NullText = "";
            this.edtSucheAuszahlungsArt.Properties.ShowFooter = false;
            this.edtSucheAuszahlungsArt.Properties.ShowHeader = false;
            this.edtSucheAuszahlungsArt.Size = new System.Drawing.Size(260, 24);
            this.edtSucheAuszahlungsArt.TabIndex = 16;
            // 
            // kissLabel6
            // 
            this.kissLabel6.Location = new System.Drawing.Point(10, 133);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(72, 24);
            this.kissLabel6.TabIndex = 17;
            this.kissLabel6.Text = "Valuta bis";
            this.kissLabel6.UseCompatibleTextRendering = true;
            // 
            // kissLabel10
            // 
            this.kissLabel10.Location = new System.Drawing.Point(10, 164);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(83, 24);
            this.kissLabel10.TabIndex = 18;
            this.kissLabel10.Text = "Auszahlungsart";
            this.kissLabel10.UseCompatibleTextRendering = true;
            // 
            // ctlOrgUnitTeamUser
            // 
            this.ctlOrgUnitTeamUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlOrgUnitTeamUser.LableWidth = 113;
            this.ctlOrgUnitTeamUser.Location = new System.Drawing.Point(10, 43);
            this.ctlOrgUnitTeamUser.Name = "ctlOrgUnitTeamUser";
            this.ctlOrgUnitTeamUser.SetUserOnNewSearch = false;
            this.ctlOrgUnitTeamUser.ShowUser = true;
            this.ctlOrgUnitTeamUser.Size = new System.Drawing.Size(373, 84);
            this.ctlOrgUnitTeamUser.TabIndex = 24;
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBuchungstext.DataMember = "Text";
            this.edtBuchungstext.DataSource = this.qryQuery;
            this.edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBuchungstext.Location = new System.Drawing.Point(151, 480);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Properties.ReadOnly = true;
            this.edtBuchungstext.Size = new System.Drawing.Size(321, 24);
            this.edtBuchungstext.TabIndex = 403;
            // 
            // edtErfassungDatum
            // 
            this.edtErfassungDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErfassungDatum.DataMember = "BuchungsDatum";
            this.edtErfassungDatum.DataSource = this.qryQuery;
            this.edtErfassungDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErfassungDatum.EditValue = null;
            this.edtErfassungDatum.Location = new System.Drawing.Point(574, 579);
            this.edtErfassungDatum.Name = "edtErfassungDatum";
            this.edtErfassungDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErfassungDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErfassungDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErfassungDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErfassungDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtErfassungDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErfassungDatum.Properties.Appearance.Options.UseFont = true;
            this.edtErfassungDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtErfassungDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErfassungDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtErfassungDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErfassungDatum.Properties.ReadOnly = true;
            this.edtErfassungDatum.Properties.ShowToday = false;
            this.edtErfassungDatum.Size = new System.Drawing.Size(100, 24);
            this.edtErfassungDatum.TabIndex = 422;
            // 
            // kissCalcEdit1
            // 
            this.kissCalcEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissCalcEdit1.DataMember = "ZKBSaldoKiss";
            this.kissCalcEdit1.DataSource = this.qryQuery;
            this.kissCalcEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCalcEdit1.Location = new System.Drawing.Point(151, 560);
            this.kissCalcEdit1.Name = "kissCalcEdit1";
            this.kissCalcEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissCalcEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissCalcEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissCalcEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissCalcEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissCalcEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissCalcEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissCalcEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissCalcEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissCalcEdit1.Properties.DisplayFormat.FormatString = "n2";
            this.kissCalcEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit1.Properties.EditFormat.FormatString = "n2";
            this.kissCalcEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit1.Properties.ReadOnly = true;
            this.kissCalcEdit1.Size = new System.Drawing.Size(100, 24);
            this.kissCalcEdit1.TabIndex = 411;
            // 
            // kissMemoEdit1
            // 
            this.kissMemoEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissMemoEdit1.DataMember = "PscdFehlermeldung";
            this.kissMemoEdit1.DataSource = this.qryQuery;
            this.kissMemoEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissMemoEdit1.Location = new System.Drawing.Point(151, 511);
            this.kissMemoEdit1.Name = "kissMemoEdit1";
            this.kissMemoEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissMemoEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissMemoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissMemoEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissMemoEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissMemoEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissMemoEdit1.Properties.ReadOnly = true;
            this.kissMemoEdit1.Size = new System.Drawing.Size(321, 43);
            this.kissMemoEdit1.TabIndex = 404;
            // 
            // kissTextEdit3
            // 
            this.kissTextEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit3.DataMember = "Zahlart";
            this.kissTextEdit3.DataSource = this.qryQuery;
            this.kissTextEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit3.Location = new System.Drawing.Point(574, 434);
            this.kissTextEdit3.Name = "kissTextEdit3";
            this.kissTextEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit3.Properties.ReadOnly = true;
            this.kissTextEdit3.Size = new System.Drawing.Size(272, 24);
            this.kissTextEdit3.TabIndex = 420;
            // 
            // edtKreditor
            // 
            this.edtKreditor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKreditor.DataMember = "Kreditor";
            this.edtKreditor.DataSource = this.qryQuery;
            this.edtKreditor.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKreditor.Location = new System.Drawing.Point(574, 457);
            this.edtKreditor.Name = "edtKreditor";
            this.edtKreditor.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKreditor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKreditor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKreditor.Properties.Appearance.Options.UseBackColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKreditor.Properties.Appearance.Options.UseFont = true;
            this.edtKreditor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKreditor.Properties.ReadOnly = true;
            this.edtKreditor.Size = new System.Drawing.Size(272, 116);
            this.edtKreditor.TabIndex = 421;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryQuery;
            this.edtBaPersonID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBaPersonID.Location = new System.Drawing.Point(402, 434);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBaPersonID.Properties.Name = "editMandantNr.Properties";
            this.edtBaPersonID.Properties.ReadOnly = true;
            this.edtBaPersonID.Size = new System.Drawing.Size(70, 24);
            this.edtBaPersonID.TabIndex = 401;
            // 
            // lblKonto
            // 
            this.lblKonto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKonto.Location = new System.Drawing.Point(8, 457);
            this.lblKonto.Name = "lblKonto";
            this.lblKonto.Size = new System.Drawing.Size(75, 24);
            this.lblKonto.TabIndex = 416;
            this.lblKonto.Text = "Konto";
            this.lblKonto.UseCompatibleTextRendering = true;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuchungstext.Location = new System.Drawing.Point(8, 480);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(75, 24);
            this.lblBuchungstext.TabIndex = 417;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // lblErfassungDatum
            // 
            this.lblErfassungDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErfassungDatum.Location = new System.Drawing.Point(486, 579);
            this.lblErfassungDatum.Name = "lblErfassungDatum";
            this.lblErfassungDatum.Size = new System.Drawing.Size(55, 24);
            this.lblErfassungDatum.TabIndex = 418;
            this.lblErfassungDatum.Text = "Buchung";
            this.lblErfassungDatum.UseCompatibleTextRendering = true;
            // 
            // lblBaZahlungswegID
            // 
            this.lblBaZahlungswegID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBaZahlungswegID.Location = new System.Drawing.Point(486, 457);
            this.lblBaZahlungswegID.Name = "lblBaZahlungswegID";
            this.lblBaZahlungswegID.Size = new System.Drawing.Size(55, 24);
            this.lblBaZahlungswegID.TabIndex = 419;
            this.lblBaZahlungswegID.Text = "Kreditor";
            this.lblBaZahlungswegID.UseCompatibleTextRendering = true;
            // 
            // lblMandant
            // 
            this.lblMandant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMandant.Location = new System.Drawing.Point(8, 434);
            this.lblMandant.Name = "lblMandant";
            this.lblMandant.Size = new System.Drawing.Size(118, 24);
            this.lblMandant.TabIndex = 420;
            this.lblMandant.Text = "Pers. m. zivilr. Massn.";
            this.lblMandant.UseCompatibleTextRendering = true;
            // 
            // kissTextEdit1
            // 
            this.kissTextEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit1.DataMember = "Konto";
            this.kissTextEdit1.DataSource = this.qryQuery;
            this.kissTextEdit1.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit1.Location = new System.Drawing.Point(151, 457);
            this.kissTextEdit1.Name = "kissTextEdit1";
            this.kissTextEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit1.Properties.ReadOnly = true;
            this.kissTextEdit1.Size = new System.Drawing.Size(321, 24);
            this.kissTextEdit1.TabIndex = 402;
            // 
            // kissTextEdit2
            // 
            this.kissTextEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissTextEdit2.DataMember = "Mandant";
            this.kissTextEdit2.DataSource = this.qryQuery;
            this.kissTextEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissTextEdit2.Location = new System.Drawing.Point(151, 434);
            this.kissTextEdit2.Name = "kissTextEdit2";
            this.kissTextEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissTextEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissTextEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissTextEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissTextEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissTextEdit2.Properties.ReadOnly = true;
            this.kissTextEdit2.Size = new System.Drawing.Size(252, 24);
            this.kissTextEdit2.TabIndex = 400;
            // 
            // kissLabel1
            // 
            this.kissLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel1.Location = new System.Drawing.Point(486, 434);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(86, 24);
            this.kissLabel1.TabIndex = 423;
            this.kissLabel1.Text = "Auszahlungsart";
            this.kissLabel1.UseCompatibleTextRendering = true;
            // 
            // kissLabel5
            // 
            this.kissLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel5.Location = new System.Drawing.Point(8, 511);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(75, 24);
            this.kissLabel5.TabIndex = 424;
            this.kissLabel5.Text = "Fehler";
            this.kissLabel5.UseCompatibleTextRendering = true;
            // 
            // kissLabel7
            // 
            this.kissLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel7.Location = new System.Drawing.Point(8, 560);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(94, 24);
            this.kissLabel7.TabIndex = 425;
            this.kissLabel7.Text = "ZKB-Saldo (KiSS)";
            this.kissLabel7.UseCompatibleTextRendering = true;
            // 
            // kissCalcEdit2
            // 
            this.kissCalcEdit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissCalcEdit2.DataMember = "TotalAuszahlungen";
            this.kissCalcEdit2.DataSource = this.qryQuery;
            this.kissCalcEdit2.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCalcEdit2.Location = new System.Drawing.Point(151, 629);
            this.kissCalcEdit2.Name = "kissCalcEdit2";
            this.kissCalcEdit2.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissCalcEdit2.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissCalcEdit2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissCalcEdit2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissCalcEdit2.Properties.Appearance.Options.UseBackColor = true;
            this.kissCalcEdit2.Properties.Appearance.Options.UseBorderColor = true;
            this.kissCalcEdit2.Properties.Appearance.Options.UseFont = true;
            this.kissCalcEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissCalcEdit2.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissCalcEdit2.Properties.DisplayFormat.FormatString = "n2";
            this.kissCalcEdit2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit2.Properties.EditFormat.FormatString = "n2";
            this.kissCalcEdit2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit2.Properties.ReadOnly = true;
            this.kissCalcEdit2.Size = new System.Drawing.Size(100, 24);
            this.kissCalcEdit2.TabIndex = 415;
            // 
            // kissCalcEdit3
            // 
            this.kissCalcEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissCalcEdit3.DataMember = "ZKBSaldoMT940";
            this.kissCalcEdit3.DataSource = this.qryQuery;
            this.kissCalcEdit3.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCalcEdit3.Location = new System.Drawing.Point(372, 583);
            this.kissCalcEdit3.Name = "kissCalcEdit3";
            this.kissCalcEdit3.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissCalcEdit3.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissCalcEdit3.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissCalcEdit3.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissCalcEdit3.Properties.Appearance.Options.UseBackColor = true;
            this.kissCalcEdit3.Properties.Appearance.Options.UseBorderColor = true;
            this.kissCalcEdit3.Properties.Appearance.Options.UseFont = true;
            this.kissCalcEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissCalcEdit3.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissCalcEdit3.Properties.DisplayFormat.FormatString = "n2";
            this.kissCalcEdit3.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit3.Properties.EditFormat.FormatString = "n2";
            this.kissCalcEdit3.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit3.Properties.ReadOnly = true;
            this.kissCalcEdit3.Size = new System.Drawing.Size(100, 24);
            this.kissCalcEdit3.TabIndex = 413;
            // 
            // kissLabel9
            // 
            this.kissLabel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel9.Location = new System.Drawing.Point(262, 583);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(109, 24);
            this.kissLabel9.TabIndex = 429;
            this.kissLabel9.Text = "ZKB-Saldo (MT940)";
            this.kissLabel9.UseCompatibleTextRendering = true;
            // 
            // kissCalcEdit4
            // 
            this.kissCalcEdit4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissCalcEdit4.DataMember = "TotalEinzahlungen";
            this.kissCalcEdit4.DataSource = this.qryQuery;
            this.kissCalcEdit4.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCalcEdit4.Location = new System.Drawing.Point(151, 583);
            this.kissCalcEdit4.Name = "kissCalcEdit4";
            this.kissCalcEdit4.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissCalcEdit4.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissCalcEdit4.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissCalcEdit4.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissCalcEdit4.Properties.Appearance.Options.UseBackColor = true;
            this.kissCalcEdit4.Properties.Appearance.Options.UseBorderColor = true;
            this.kissCalcEdit4.Properties.Appearance.Options.UseFont = true;
            this.kissCalcEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissCalcEdit4.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissCalcEdit4.Properties.DisplayFormat.FormatString = "n2";
            this.kissCalcEdit4.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit4.Properties.EditFormat.FormatString = "n2";
            this.kissCalcEdit4.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit4.Properties.ReadOnly = true;
            this.kissCalcEdit4.Size = new System.Drawing.Size(100, 24);
            this.kissCalcEdit4.TabIndex = 412;
            // 
            // colBetrag
            // 
            this.colBetrag.Caption = "Betrag";
            this.colBetrag.DisplayFormat.FormatString = "n2";
            this.colBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetrag.FieldName = "Betrag";
            this.colBetrag.Name = "colBetrag";
            this.colBetrag.OptionsColumn.AllowEdit = false;
            this.colBetrag.Visible = true;
            this.colBetrag.VisibleIndex = 4;
            this.colBetrag.Width = 73;
            // 
            // colBuchungstext
            // 
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Text";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.OptionsColumn.AllowEdit = false;
            this.colBuchungstext.OptionsColumn.FixedWidth = true;
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 3;
            this.colBuchungstext.Width = 147;
            // 
            // colKgBuchungID
            // 
            this.colKgBuchungID.AppearanceCell.Options.UseTextOptions = true;
            this.colKgBuchungID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.colKgBuchungID.Caption = "Beleg-Nr.";
            this.colKgBuchungID.FieldName = "KgBuchungID";
            this.colKgBuchungID.Name = "colKgBuchungID";
            this.colKgBuchungID.Visible = true;
            this.colKgBuchungID.VisibleIndex = 15;
            this.colKgBuchungID.Width = 64;
            // 
            // colKonto
            // 
            this.colKonto.Caption = "Konto";
            this.colKonto.FieldName = "KontoNr";
            this.colKonto.Name = "colKonto";
            this.colKonto.OptionsColumn.AllowEdit = false;
            this.colKonto.Visible = true;
            this.colKonto.VisibleIndex = 2;
            this.colKonto.Width = 48;
            // 
            // colKreditor
            // 
            this.colKreditor.Caption = "Kreditor";
            this.colKreditor.FieldName = "KreditorLinie";
            this.colKreditor.Name = "colKreditor";
            this.colKreditor.OptionsColumn.AllowEdit = false;
            this.colKreditor.OptionsColumn.FixedWidth = true;
            this.colKreditor.Visible = true;
            this.colKreditor.VisibleIndex = 6;
            this.colKreditor.Width = 138;
            // 
            // colMandant
            // 
            this.colMandant.Caption = "Pers. mit zivilr. Massnahme";
            this.colMandant.FieldName = "Mandant";
            this.colMandant.Name = "colMandant";
            this.colMandant.OptionsColumn.AllowEdit = false;
            this.colMandant.OptionsColumn.FixedWidth = true;
            this.colMandant.Visible = true;
            this.colMandant.VisibleIndex = 1;
            this.colMandant.Width = 111;
            // 
            // colTotalAuszahlungen
            // 
            this.colTotalAuszahlungen.Caption = "Total im Zahllauf";
            this.colTotalAuszahlungen.FieldName = "TotalAuszahlungen";
            this.colTotalAuszahlungen.Name = "colTotalAuszahlungen";
            this.colTotalAuszahlungen.Visible = true;
            this.colTotalAuszahlungen.VisibleIndex = 10;
            this.colTotalAuszahlungen.Width = 74;
            // 
            // colSozialzentrum
            // 
            this.colSozialzentrum.Caption = "Sozialzentrum";
            this.colSozialzentrum.FieldName = "Sozialzentrum";
            this.colSozialzentrum.Name = "colSozialzentrum";
            this.colSozialzentrum.Visible = true;
            this.colSozialzentrum.VisibleIndex = 12;
            this.colSozialzentrum.Width = 113;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Stat.";
            this.colStatus.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colStatus.FieldName = "KgBuchungStatusCode";
            this.colStatus.Name = "colStatus";
            this.colStatus.OptionsColumn.AllowEdit = false;
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 5;
            this.colStatus.Width = 35;
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // colTeam
            // 
            this.colTeam.Caption = "Team";
            this.colTeam.FieldName = "OrgUnit";
            this.colTeam.Name = "colTeam";
            this.colTeam.Visible = true;
            this.colTeam.VisibleIndex = 13;
            this.colTeam.Width = 98;
            // 
            // colUser
            // 
            this.colUser.Caption = "User";
            this.colUser.FieldName = "NameVorname";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 14;
            // 
            // colValuta
            // 
            this.colValuta.Caption = "Valuta";
            this.colValuta.FieldName = "ValutaDatum";
            this.colValuta.Name = "colValuta";
            this.colValuta.OptionsColumn.AllowEdit = false;
            this.colValuta.Visible = true;
            this.colValuta.VisibleIndex = 0;
            this.colValuta.Width = 65;
            // 
            // colZKBSaldoKiss
            // 
            this.colZKBSaldoKiss.Caption = "ZKB Saldo";
            this.colZKBSaldoKiss.FieldName = "ZKBSaldoKiss";
            this.colZKBSaldoKiss.Name = "colZKBSaldoKiss";
            this.colZKBSaldoKiss.Visible = true;
            this.colZKBSaldoKiss.VisibleIndex = 7;
            this.colZKBSaldoKiss.Width = 69;
            // 
            // grvZahllauf
            // 
            this.grvZahllauf.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvZahllauf.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.Empty.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.Empty.Options.UseFont = true;
            this.grvZahllauf.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.EvenRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahllauf.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvZahllauf.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.FocusedCell.Options.UseFont = true;
            this.grvZahllauf.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvZahllauf.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvZahllauf.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvZahllauf.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.FocusedRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvZahllauf.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahllauf.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZahllauf.Appearance.GroupFooter.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.grvZahllauf.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahllauf.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvZahllauf.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahllauf.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahllauf.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.GroupRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvZahllauf.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvZahllauf.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvZahllauf.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvZahllauf.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvZahllauf.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvZahllauf.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvZahllauf.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvZahllauf.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvZahllauf.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahllauf.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.OddRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvZahllauf.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.Row.Options.UseBackColor = true;
            this.grvZahllauf.Appearance.Row.Options.UseFont = true;
            this.grvZahllauf.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvZahllauf.Appearance.SelectedRow.Options.UseFont = true;
            this.grvZahllauf.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvZahllauf.Appearance.VertLine.Options.UseBackColor = true;
            this.grvZahllauf.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvZahllauf.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colValuta,
            this.colMandant,
            this.colKonto,
            this.colBuchungstext,
            this.colBetrag,
            this.colStatus,
            this.colKreditor,
            this.colZKBSaldoKiss,
            this.colTotalEinzahlungen,
            this.colPendenteBarbelege,
            this.colTotalAuszahlungen,
            this.colSaldovorschau,
            this.colSozialzentrum,
            this.colTeam,
            this.colUser,
            this.colKgBuchungID});
            this.grvZahllauf.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvZahllauf.GridControl = this.grdQuery1;
            this.grvZahllauf.Name = "grvZahllauf";
            this.grvZahllauf.OptionsBehavior.Editable = false;
            this.grvZahllauf.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvZahllauf.OptionsNavigation.AutoFocusNewRow = true;
            this.grvZahllauf.OptionsNavigation.UseTabKey = false;
            this.grvZahllauf.OptionsView.ColumnAutoWidth = false;
            this.grvZahllauf.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvZahllauf.OptionsView.ShowGroupPanel = false;
            this.grvZahllauf.OptionsView.ShowIndicator = false;
            // 
            // colTotalEinzahlungen
            // 
            this.colTotalEinzahlungen.Caption = "ungeklärte Zahlungseingänge";
            this.colTotalEinzahlungen.FieldName = "TotalEinzahlungen";
            this.colTotalEinzahlungen.Name = "colTotalEinzahlungen";
            this.colTotalEinzahlungen.Visible = true;
            this.colTotalEinzahlungen.VisibleIndex = 8;
            // 
            // colPendenteBarbelege
            // 
            this.colPendenteBarbelege.Caption = "Eingelöste Barbelege";
            this.colPendenteBarbelege.FieldName = "PendenteBarbelege";
            this.colPendenteBarbelege.Name = "colPendenteBarbelege";
            this.colPendenteBarbelege.Visible = true;
            this.colPendenteBarbelege.VisibleIndex = 9;
            // 
            // colSaldovorschau
            // 
            this.colSaldovorschau.Caption = "Saldovorschau";
            this.colSaldovorschau.FieldName = "Saldovorschau";
            this.colSaldovorschau.Name = "colSaldovorschau";
            this.colSaldovorschau.Visible = true;
            this.colSaldovorschau.VisibleIndex = 11;
            // 
            // kissLabel2
            // 
            this.kissLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel2.Location = new System.Drawing.Point(8, 605);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(140, 24);
            this.kissLabel2.TabIndex = 434;
            this.kissLabel2.Text = "Eingelöste Barbelege";
            this.kissLabel2.UseCompatibleTextRendering = true;
            // 
            // kissCalcEdit5
            // 
            this.kissCalcEdit5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissCalcEdit5.DataMember = "PendenteBarbelege";
            this.kissCalcEdit5.DataSource = this.qryQuery;
            this.kissCalcEdit5.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.kissCalcEdit5.Location = new System.Drawing.Point(151, 606);
            this.kissCalcEdit5.Name = "kissCalcEdit5";
            this.kissCalcEdit5.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissCalcEdit5.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.kissCalcEdit5.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissCalcEdit5.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissCalcEdit5.Properties.Appearance.Options.UseBackColor = true;
            this.kissCalcEdit5.Properties.Appearance.Options.UseBorderColor = true;
            this.kissCalcEdit5.Properties.Appearance.Options.UseFont = true;
            this.kissCalcEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.kissCalcEdit5.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissCalcEdit5.Properties.DisplayFormat.FormatString = "n2";
            this.kissCalcEdit5.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit5.Properties.EditFormat.FormatString = "n2";
            this.kissCalcEdit5.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.kissCalcEdit5.Properties.ReadOnly = true;
            this.kissCalcEdit5.Size = new System.Drawing.Size(100, 24);
            this.kissCalcEdit5.TabIndex = 414;
            // 
            // kissLabel3
            // 
            this.kissLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel3.Location = new System.Drawing.Point(8, 629);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(90, 24);
            this.kissLabel3.TabIndex = 432;
            this.kissLabel3.Text = "Total im Zahllauf";
            this.kissLabel3.UseCompatibleTextRendering = true;
            // 
            // kissLabel13
            // 
            this.kissLabel13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel13.Location = new System.Drawing.Point(8, 582);
            this.kissLabel13.Name = "kissLabel13";
            this.kissLabel13.Size = new System.Drawing.Size(140, 24);
            this.kissLabel13.TabIndex = 435;
            this.kissLabel13.Text = "ungeklärte Zahlungseing.";
            this.kissLabel13.UseCompatibleTextRendering = true;
            // 
            // kissLabel14
            // 
            this.kissLabel14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel14.Location = new System.Drawing.Point(5, 659);
            this.kissLabel14.Name = "kissLabel14";
            this.kissLabel14.Size = new System.Drawing.Size(140, 24);
            this.kissLabel14.TabIndex = 437;
            this.kissLabel14.Text = "Saldovorschau";
            this.kissLabel14.UseCompatibleTextRendering = true;
            // 
            // edtSaldovorschau
            // 
            this.edtSaldovorschau.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtSaldovorschau.DataMember = "Saldovorschau";
            this.edtSaldovorschau.DataSource = this.qryQuery;
            this.edtSaldovorschau.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtSaldovorschau.Location = new System.Drawing.Point(151, 659);
            this.edtSaldovorschau.Name = "edtSaldovorschau";
            this.edtSaldovorschau.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSaldovorschau.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtSaldovorschau.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSaldovorschau.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSaldovorschau.Properties.Appearance.Options.UseBackColor = true;
            this.edtSaldovorschau.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSaldovorschau.Properties.Appearance.Options.UseFont = true;
            this.edtSaldovorschau.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSaldovorschau.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSaldovorschau.Properties.DisplayFormat.FormatString = "n2";
            this.edtSaldovorschau.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSaldovorschau.Properties.EditFormat.FormatString = "n2";
            this.edtSaldovorschau.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtSaldovorschau.Properties.ReadOnly = true;
            this.edtSaldovorschau.Size = new System.Drawing.Size(100, 24);
            this.edtSaldovorschau.TabIndex = 416;
            // 
            // kissLabel18
            // 
            this.kissLabel18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel18.Location = new System.Drawing.Point(138, 659);
            this.kissLabel18.Name = "kissLabel18";
            this.kissLabel18.Size = new System.Drawing.Size(10, 24);
            this.kissLabel18.TabIndex = 441;
            this.kissLabel18.Text = "=";
            this.kissLabel18.UseCompatibleTextRendering = true;
            // 
            // kissLabel17
            // 
            this.kissLabel17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel17.Location = new System.Drawing.Point(138, 606);
            this.kissLabel17.Name = "kissLabel17";
            this.kissLabel17.Size = new System.Drawing.Size(10, 24);
            this.kissLabel17.TabIndex = 440;
            this.kissLabel17.Text = "-";
            this.kissLabel17.UseCompatibleTextRendering = true;
            // 
            // kissLabel16
            // 
            this.kissLabel16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel16.Location = new System.Drawing.Point(138, 629);
            this.kissLabel16.Name = "kissLabel16";
            this.kissLabel16.Size = new System.Drawing.Size(10, 24);
            this.kissLabel16.TabIndex = 439;
            this.kissLabel16.Text = "-";
            this.kissLabel16.UseCompatibleTextRendering = true;
            // 
            // kissLabel15
            // 
            this.kissLabel15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel15.Location = new System.Drawing.Point(138, 583);
            this.kissLabel15.Name = "kissLabel15";
            this.kissLabel15.Size = new System.Drawing.Size(10, 24);
            this.kissLabel15.TabIndex = 438;
            this.kissLabel15.Text = "+";
            this.kissLabel15.UseCompatibleTextRendering = true;
            // 
            // CtlQueryKgLiquiditaet
            // 
            this.Controls.Add(this.kissLabel18);
            this.Controls.Add(this.kissLabel17);
            this.Controls.Add(this.kissLabel16);
            this.Controls.Add(this.kissLabel15);
            this.Controls.Add(this.kissLabel14);
            this.Controls.Add(this.edtSaldovorschau);
            this.Controls.Add(this.kissLabel13);
            this.Controls.Add(this.kissLabel2);
            this.Controls.Add(this.kissCalcEdit5);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.kissCalcEdit4);
            this.Controls.Add(this.kissLabel9);
            this.Controls.Add(this.kissCalcEdit3);
            this.Controls.Add(this.kissCalcEdit2);
            this.Controls.Add(this.kissLabel7);
            this.Controls.Add(this.kissLabel5);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.kissTextEdit2);
            this.Controls.Add(this.kissTextEdit1);
            this.Controls.Add(this.lblMandant);
            this.Controls.Add(this.lblBaZahlungswegID);
            this.Controls.Add(this.lblErfassungDatum);
            this.Controls.Add(this.lblBuchungstext);
            this.Controls.Add(this.lblKonto);
            this.Controls.Add(this.edtBaPersonID);
            this.Controls.Add(this.edtKreditor);
            this.Controls.Add(this.kissTextEdit3);
            this.Controls.Add(this.kissMemoEdit1);
            this.Controls.Add(this.kissCalcEdit1);
            this.Controls.Add(this.edtErfassungDatum);
            this.Controls.Add(this.edtBuchungstext);
            this.Name = "CtlQueryKgLiquiditaet";
            this.Size = new System.Drawing.Size(931, 692);
            this.Load += new System.EventHandler(this.CtlQueryKgLiquiditaet_Load);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.edtBuchungstext, 0);
            this.Controls.SetChildIndex(this.edtErfassungDatum, 0);
            this.Controls.SetChildIndex(this.kissCalcEdit1, 0);
            this.Controls.SetChildIndex(this.kissMemoEdit1, 0);
            this.Controls.SetChildIndex(this.kissTextEdit3, 0);
            this.Controls.SetChildIndex(this.edtKreditor, 0);
            this.Controls.SetChildIndex(this.edtBaPersonID, 0);
            this.Controls.SetChildIndex(this.lblKonto, 0);
            this.Controls.SetChildIndex(this.lblBuchungstext, 0);
            this.Controls.SetChildIndex(this.lblErfassungDatum, 0);
            this.Controls.SetChildIndex(this.lblBaZahlungswegID, 0);
            this.Controls.SetChildIndex(this.lblMandant, 0);
            this.Controls.SetChildIndex(this.kissTextEdit1, 0);
            this.Controls.SetChildIndex(this.kissTextEdit2, 0);
            this.Controls.SetChildIndex(this.kissLabel1, 0);
            this.Controls.SetChildIndex(this.kissLabel5, 0);
            this.Controls.SetChildIndex(this.kissLabel7, 0);
            this.Controls.SetChildIndex(this.kissCalcEdit2, 0);
            this.Controls.SetChildIndex(this.kissCalcEdit3, 0);
            this.Controls.SetChildIndex(this.kissLabel9, 0);
            this.Controls.SetChildIndex(this.kissCalcEdit4, 0);
            this.Controls.SetChildIndex(this.kissLabel3, 0);
            this.Controls.SetChildIndex(this.kissCalcEdit5, 0);
            this.Controls.SetChildIndex(this.kissLabel2, 0);
            this.Controls.SetChildIndex(this.kissLabel13, 0);
            this.Controls.SetChildIndex(this.edtSaldovorschau, 0);
            this.Controls.SetChildIndex(this.kissLabel14, 0);
            this.Controls.SetChildIndex(this.kissLabel15, 0);
            this.Controls.SetChildIndex(this.kissLabel16, 0);
            this.Controls.SetChildIndex(this.kissLabel17, 0);
            this.Controls.SetChildIndex(this.kissLabel18, 0);
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgListe.PerformLayout();
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuszahlungsArt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheAuszahlungsArt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErfassungDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissMemoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKreditor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKonto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErfassungDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaZahlungswegID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMandant)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissTextEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvZahllauf)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissCalcEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSaldovorschau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel15)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Public Methods

        public override void OnSearch()
        {
            if (tabControlSearch.SelectedTab == tpgSuchen)
            {
                foreach (Control ctl in UtilsGui.AllControls(tpgSuchen))
                {
                    if (ctl is KissButtonEdit)
                    {
                        KissButtonEdit edt = (KissButtonEdit)ctl;
                        edt.CheckPendingSearchValue();
                    }

                    if (ctl is CtlOrgUnitTeamUser)
                    {
                        ((CtlOrgUnitTeamUser)ctl).CheckPendingSearchValue();
                    }
                }
            }

            // Workaround um F3 weiter zu reichen, da das FrameWork das OrgUnitTeamUser UserControl nicht kennt
            try
            {
                if (((ContainerControl)ActiveControl).ActiveControl.Equals(ctlOrgUnitTeamUser))
                    edtSucheValutaBis.Focus();
            }
            catch
            {
            }

            base.OnSearch();
        }

        #endregion

        #region Protected Methods

        protected override void NewSearch()
        {
            base.NewSearch();

            ctlOrgUnitTeamUser.NewSearch();

            DateTime d = DateTime.Today.AddDays(2); //heute + 2 Tage
            if ((int)d.DayOfWeek == 6) d = d.AddDays(2); //Samstag -> Montag
            if ((int)d.DayOfWeek == 0) d = d.AddDays(1); //Sonntag -> Montag
            edtSucheValutaBis.EditValue = d;

            edtSucheValutaBis.Focus();
        }

        #endregion

        #region Private Methods

        private void btnMonatsbudget_Click(object sender, System.EventArgs e)
        {
            if (qryQuery.Count == 0 || DBUtil.IsEmpty(qryQuery["JumpToMBPfad$"])) return;

            FormController.OpenForm("FrmFall", "Action", "JumpToNodeByFieldValue",
                        "BaPersonID", qryQuery["FallBaPersonID$"],
                        "ModulID", 5,
                        "FieldValue", qryQuery["JumpToMBPfad$"]);
        }

        private void CtlQueryKgLiquiditaet_Load(object sender, System.EventArgs e)
        {
            //Buchungsstati laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL("select * from XLOVCode where LOVName = 'KgBuchungsStatus' order by SortKey");
            foreach (DataRow R in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    R["Text"].ToString(),
                    (int)R["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(R["Value1"]))));
            }
        }

        #endregion
    }
}