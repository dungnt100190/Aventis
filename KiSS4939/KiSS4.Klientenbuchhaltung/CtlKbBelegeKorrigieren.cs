using System;
using System.Data;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Klientenbuchhaltung
{
    public class CtlKbBelegeKorrigieren : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// Der aktuelle Mandant.
        /// </summary>
        private int _kbMandantID;

        /// <summary>
        /// Die Periode auf die sich alles bezieht.
        /// </summary>
        private int _kbPeriodeID;

        private KiSS4.Gui.KissButton btnAusführen;
        private KiSS4.Gui.KissButton btnSprungMonatsbudget;
        private DevExpress.XtraGrid.Columns.GridColumn colBaPersonID;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colBelegNr;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragKorrektur;
        private DevExpress.XtraGrid.Columns.GridColumn colBetragOriginal;
        private DevExpress.XtraGrid.Columns.GridColumn colBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colKbBuchungStatusCode;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private DevExpress.XtraGrid.Columns.GridColumn colValutaDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeVon;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissButtonEdit edtBaPersonID;
        private KiSS4.Gui.KissDateEdit edtBelegDatum;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissCalcEdit edtBgBudgetID;
        private KiSS4.Gui.KissButtonEdit edtBgKostenartID;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissButtonEdit edtSucheBaPersonID;
        private KiSS4.Gui.KissDateEdit edtSucheBelegDatumBis;
        private KiSS4.Gui.KissDateEdit edtSucheBelegDatumVon;
        private KiSS4.Gui.KissTextEdit edtSucheBelegNr;
        private KiSS4.Gui.KissButtonEdit edtSucheBgKostenartID;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeVon;
        private KiSS4.Gui.KissGrid grdKbBuchungKostenart;
        private KiSS4.Gui.KissGrid grdKbBuchungSuche;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchungKostenart;
        private DevExpress.XtraGrid.Views.Grid.GridView grvKbBuchungSuche;
        private KiSS4.Gui.KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel2;
        private KiSS4.Gui.KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel lblBelegDatum;
        private KiSS4.Gui.KissLabel lblBetragKorr;
        private KiSS4.Gui.KissLabel lblBgBudgetID;
        private KiSS4.Gui.KissLabel lblBuchungstextKorr;
        private KiSS4.Gui.KissLabel lblKlient;
        private KiSS4.Gui.KissLabel lblKorrektur;
        private KiSS4.Gui.KissLabel lblLAKorr;
        private KiSS4.Gui.KissLabel lblOriginal;
        private KiSS4.Gui.KissLabel lblVerwPerBisKorr;
        private KiSS4.Gui.KissLabel lblVerwPerVonKorr;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private KiSS4.DB.SqlQuery qryKbBuchungKostenart;
        private KiSS4.DB.SqlQuery qryKbBuchungSuche;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;

        #endregion

        #endregion

        #region Constructors

        public CtlKbBelegeKorrigieren()
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKbBelegeKorrigieren));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOriginal = new KiSS4.Gui.KissLabel();
            this.grdKbBuchungSuche = new KiSS4.Gui.KissGrid();
            this.qryKbBuchungSuche = new KiSS4.DB.SqlQuery(this.components);
            this.grvKbBuchungSuche = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKbBuchungStatusCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colBelegNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBelegDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colValutaDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragOriginal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.edtSucheBelegDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheBelegDatumBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtSucheBelegNr = new KiSS4.Gui.KissTextEdit();
            this.kissLabel2 = new KiSS4.Gui.KissLabel();
            this.edtSucheBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtSucheBgKostenartID = new KiSS4.Gui.KissButtonEdit();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblVerwPerBisKorr = new KiSS4.Gui.KissLabel();
            this.lblVerwPerVonKorr = new KiSS4.Gui.KissLabel();
            this.lblBetragKorr = new KiSS4.Gui.KissLabel();
            this.edtBgBudgetID = new KiSS4.Gui.KissCalcEdit();
            this.qryKbBuchungKostenart = new KiSS4.DB.SqlQuery(this.components);
            this.lblBgBudgetID = new KiSS4.Gui.KissLabel();
            this.lblBuchungstextKorr = new KiSS4.Gui.KissLabel();
            this.btnAusführen = new KiSS4.Gui.KissButton();
            this.lblLAKorr = new KiSS4.Gui.KissLabel();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.lblKlient = new KiSS4.Gui.KissLabel();
            this.edtVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.lblBelegDatum = new KiSS4.Gui.KissLabel();
            this.edtBgKostenartID = new KiSS4.Gui.KissButtonEdit();
            this.grdKbBuchungKostenart = new KiSS4.Gui.KissGrid();
            this.grvKbBuchungKostenart = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaPersonID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBetragKorrektur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtBaPersonID = new KiSS4.Gui.KissButtonEdit();
            this.lblKorrektur = new KiSS4.Gui.KissLabel();
            this.edtBelegDatum = new KiSS4.Gui.KissDateEdit();
            this.btnSprungMonatsbudget = new KiSS4.Gui.KissButton();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblOriginal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchungSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungSuche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBgKostenartID.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerBisKorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerVonKorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragKorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBudgetID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchungKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgBudgetID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstextKorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLAKorr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrektur)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatum.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(794, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 23);
            this.tabControlSearch.Size = new System.Drawing.Size(818, 239);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdKbBuchungSuche);
            this.tpgListe.Size = new System.Drawing.Size(806, 201);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.edtSucheBgKostenartID);
            this.tpgSuchen.Controls.Add(this.kissLabel1);
            this.tpgSuchen.Controls.Add(this.edtSucheBaPersonID);
            this.tpgSuchen.Controls.Add(this.kissLabel2);
            this.tpgSuchen.Controls.Add(this.edtSucheBelegNr);
            this.tpgSuchen.Controls.Add(this.kissLabel3);
            this.tpgSuchen.Controls.Add(this.edtSucheBelegDatumBis);
            this.tpgSuchen.Controls.Add(this.edtSucheBelegDatumVon);
            this.tpgSuchen.Controls.Add(this.kissLabel4);
            this.tpgSuchen.Controls.Add(this.kissLabel5);
            this.tpgSuchen.Size = new System.Drawing.Size(806, 201);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel5, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel4, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBelegDatumVon, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBelegDatumBis, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel3, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBelegNr, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel2, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBaPersonID, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.kissLabel1, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheBgKostenartID, 0);
            //
            // panel2
            //
            this.panel2.Controls.Add(this.lblOriginal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(818, 23);
            this.panel2.TabIndex = 0;
            //
            // lblOriginal
            //
            this.lblOriginal.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblOriginal.Location = new System.Drawing.Point(3, 3);
            this.lblOriginal.Name = "lblOriginal";
            this.lblOriginal.Size = new System.Drawing.Size(165, 16);
            this.lblOriginal.TabIndex = 33;
            this.lblOriginal.Text = "Originalbuchung";
            this.lblOriginal.UseCompatibleTextRendering = true;
            //
            // grdKbBuchungSuche
            //
            this.grdKbBuchungSuche.DataSource = this.qryKbBuchungSuche;
            this.grdKbBuchungSuche.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdKbBuchungSuche.EmbeddedNavigator.Name = "";
            this.grdKbBuchungSuche.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKbBuchungSuche.Location = new System.Drawing.Point(0, 0);
            this.grdKbBuchungSuche.MainView = this.grvKbBuchungSuche;
            this.grdKbBuchungSuche.Name = "grdKbBuchungSuche";
            this.grdKbBuchungSuche.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.grdKbBuchungSuche.Size = new System.Drawing.Size(806, 201);
            this.grdKbBuchungSuche.TabIndex = 0;
            this.grdKbBuchungSuche.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBuchungSuche});
            //
            // qryKbBuchungSuche
            //
            this.qryKbBuchungSuche.HostControl = this;
            this.qryKbBuchungSuche.SelectStatement = resources.GetString("qryKbBuchungSuche.SelectStatement");
            this.qryKbBuchungSuche.TableName = "KbBuchung";
            this.qryKbBuchungSuche.AfterFill += new System.EventHandler(this.qryKbBuchungSuche_AfterFill);
            this.qryKbBuchungSuche.PositionChanged += new System.EventHandler(this.qryKbBuchungSuche_PositionChanged);
            //
            // grvKbBuchungSuche
            //
            this.grvKbBuchungSuche.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbBuchungSuche.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungSuche.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchungSuche.Appearance.Empty.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungSuche.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungSuche.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungSuche.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungSuche.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchungSuche.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchungSuche.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungSuche.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungSuche.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungSuche.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbBuchungSuche.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbBuchungSuche.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungSuche.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchungSuche.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungSuche.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungSuche.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungSuche.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchungSuche.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchungSuche.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchungSuche.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchungSuche.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungSuche.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchungSuche.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchungSuche.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchungSuche.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungSuche.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungSuche.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchungSuche.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchungSuche.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungSuche.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbBuchungSuche.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungSuche.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungSuche.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungSuche.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchungSuche.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungSuche.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchungSuche.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungSuche.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbBuchungSuche.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchungSuche.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKbBuchungStatusCode,
            this.colBelegNr,
            this.colBelegDatum,
            this.colValutaDatum,
            this.colBetragOriginal,
            this.colText});
            this.grvKbBuchungSuche.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbBuchungSuche.GridControl = this.grdKbBuchungSuche;
            this.grvKbBuchungSuche.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.grvKbBuchungSuche.Name = "grvKbBuchungSuche";
            this.grvKbBuchungSuche.OptionsBehavior.Editable = false;
            this.grvKbBuchungSuche.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchungSuche.OptionsFilter.AllowFilterEditor = false;
            this.grvKbBuchungSuche.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchungSuche.OptionsMenu.EnableColumnMenu = false;
            this.grvKbBuchungSuche.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchungSuche.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchungSuche.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchungSuche.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbBuchungSuche.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchungSuche.OptionsView.ShowIndicator = false;
            //
            // colKbBuchungStatusCode
            //
            this.colKbBuchungStatusCode.Caption = "Status";
            this.colKbBuchungStatusCode.ColumnEdit = this.repositoryItemImageComboBox1;
            this.colKbBuchungStatusCode.FieldName = "KbBuchungStatusCode";
            this.colKbBuchungStatusCode.Name = "colKbBuchungStatusCode";
            this.colKbBuchungStatusCode.Visible = true;
            this.colKbBuchungStatusCode.VisibleIndex = 5;
            this.colKbBuchungStatusCode.Width = 47;
            //
            // repositoryItemImageComboBox1
            //
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            //
            // colBelegNr
            //
            this.colBelegNr.Caption = "BelegNr";
            this.colBelegNr.FieldName = "BelegNr";
            this.colBelegNr.Name = "colBelegNr";
            this.colBelegNr.UnboundType = DevExpress.Data.UnboundColumnType.Object;
            this.colBelegNr.Visible = true;
            this.colBelegNr.VisibleIndex = 1;
            this.colBelegNr.Width = 89;
            //
            // colBelegDatum
            //
            this.colBelegDatum.Caption = "Belegdatum";
            this.colBelegDatum.FieldName = "BelegDatum";
            this.colBelegDatum.Name = "colBelegDatum";
            this.colBelegDatum.Visible = true;
            this.colBelegDatum.VisibleIndex = 0;
            this.colBelegDatum.Width = 87;
            //
            // colValutaDatum
            //
            this.colValutaDatum.Caption = "Valuta";
            this.colValutaDatum.FieldName = "ValutaDatum";
            this.colValutaDatum.Name = "colValutaDatum";
            this.colValutaDatum.Visible = true;
            this.colValutaDatum.VisibleIndex = 4;
            this.colValutaDatum.Width = 76;
            //
            // colBetragOriginal
            //
            this.colBetragOriginal.Caption = "Betrag";
            this.colBetragOriginal.DisplayFormat.FormatString = "n2";
            this.colBetragOriginal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragOriginal.FieldName = "Betrag";
            this.colBetragOriginal.Name = "colBetragOriginal";
            this.colBetragOriginal.Visible = true;
            this.colBetragOriginal.VisibleIndex = 3;
            //
            // colText
            //
            this.colText.Caption = "Buchungstext";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 2;
            this.colText.Width = 158;
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(4, 33);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(100, 23);
            this.kissLabel5.TabIndex = 13;
            this.kissLabel5.Text = "Datum von";
            this.kissLabel5.UseCompatibleTextRendering = true;
            //
            // kissLabel4
            //
            this.kissLabel4.Location = new System.Drawing.Point(263, 33);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(28, 24);
            this.kissLabel4.TabIndex = 14;
            this.kissLabel4.Text = "bis";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // edtSucheBelegDatumVon
            //
            this.edtSucheBelegDatumVon.EditValue = null;
            this.edtSucheBelegDatumVon.Location = new System.Drawing.Point(142, 33);
            this.edtSucheBelegDatumVon.Name = "edtSucheBelegDatumVon";
            this.edtSucheBelegDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBelegDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBelegDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBelegDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBelegDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBelegDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBelegDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBelegDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheBelegDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheBelegDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheBelegDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBelegDatumVon.Properties.ShowToday = false;
            this.edtSucheBelegDatumVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBelegDatumVon.TabIndex = 15;
            //
            // edtSucheBelegDatumBis
            //
            this.edtSucheBelegDatumBis.EditValue = null;
            this.edtSucheBelegDatumBis.Location = new System.Drawing.Point(304, 32);
            this.edtSucheBelegDatumBis.Name = "edtSucheBelegDatumBis";
            this.edtSucheBelegDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheBelegDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBelegDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBelegDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBelegDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBelegDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBelegDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBelegDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheBelegDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheBelegDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheBelegDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBelegDatumBis.Properties.ShowToday = false;
            this.edtSucheBelegDatumBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBelegDatumBis.TabIndex = 16;
            //
            // kissLabel3
            //
            this.kissLabel3.Location = new System.Drawing.Point(4, 64);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(100, 23);
            this.kissLabel3.TabIndex = 17;
            this.kissLabel3.Text = "Beleg-Nr.";
            this.kissLabel3.UseCompatibleTextRendering = true;
            //
            // edtSucheBelegNr
            //
            this.edtSucheBelegNr.Location = new System.Drawing.Point(142, 63);
            this.edtSucheBelegNr.Name = "edtSucheBelegNr";
            this.edtSucheBelegNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBelegNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBelegNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBelegNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBelegNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBelegNr.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBelegNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheBelegNr.Size = new System.Drawing.Size(100, 24);
            this.edtSucheBelegNr.TabIndex = 18;
            //
            // kissLabel2
            //
            this.kissLabel2.Location = new System.Drawing.Point(4, 99);
            this.kissLabel2.Name = "kissLabel2";
            this.kissLabel2.Size = new System.Drawing.Size(100, 23);
            this.kissLabel2.TabIndex = 19;
            this.kissLabel2.Text = "Klient/in";
            this.kissLabel2.UseCompatibleTextRendering = true;
            //
            // edtSucheBaPersonID
            //
            this.edtSucheBaPersonID.Location = new System.Drawing.Point(142, 93);
            this.edtSucheBaPersonID.Name = "edtSucheBaPersonID";
            this.edtSucheBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.edtSucheBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7)});
            this.edtSucheBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBaPersonID.Size = new System.Drawing.Size(262, 24);
            this.edtSucheBaPersonID.TabIndex = 20;
            this.edtSucheBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheBaPersonID_UserModifiedFld);
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(5, 130);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(100, 23);
            this.kissLabel1.TabIndex = 21;
            this.kissLabel1.Text = "Kostenart";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // edtSucheBgKostenartID
            //
            this.edtSucheBgKostenartID.Location = new System.Drawing.Point(142, 123);
            this.edtSucheBgKostenartID.LookupSQL = "SELECT\r\n  ID$  = BgKostenartID,\r\n  Text = IsNull(KontoNr + \' \', \'\') + Name\r\nFROM " +
                "BgKostenart   BKA\r\nWHERE IsNull(KontoNr + \' \', \'\') + Name LIKE \'%\' + {0} + \'%\'\r\n" +
                "----";
            this.edtSucheBgKostenartID.Name = "edtSucheBgKostenartID";
            this.edtSucheBgKostenartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheBgKostenartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheBgKostenartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheBgKostenartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheBgKostenartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheBgKostenartID.Properties.Appearance.Options.UseFont = true;
            this.edtSucheBgKostenartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtSucheBgKostenartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtSucheBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheBgKostenartID.Size = new System.Drawing.Size(262, 24);
            this.edtSucheBgKostenartID.TabIndex = 22;
            this.edtSucheBgKostenartID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtSucheBgKostenartID_UserModifiedFld);
            //
            // panel1
            //
            this.panel1.Controls.Add(this.lblVerwPerBisKorr);
            this.panel1.Controls.Add(this.lblVerwPerVonKorr);
            this.panel1.Controls.Add(this.lblBetragKorr);
            this.panel1.Controls.Add(this.edtBgBudgetID);
            this.panel1.Controls.Add(this.lblBgBudgetID);
            this.panel1.Controls.Add(this.lblBuchungstextKorr);
            this.panel1.Controls.Add(this.btnAusführen);
            this.panel1.Controls.Add(this.lblLAKorr);
            this.panel1.Controls.Add(this.edtBetrag);
            this.panel1.Controls.Add(this.edtVerwPeriodeBis);
            this.panel1.Controls.Add(this.lblKlient);
            this.panel1.Controls.Add(this.edtVerwPeriodeVon);
            this.panel1.Controls.Add(this.edtBuchungstext);
            this.panel1.Controls.Add(this.lblBelegDatum);
            this.panel1.Controls.Add(this.edtBgKostenartID);
            this.panel1.Controls.Add(this.grdKbBuchungKostenart);
            this.panel1.Controls.Add(this.edtBaPersonID);
            this.panel1.Controls.Add(this.lblKorrektur);
            this.panel1.Controls.Add(this.edtBelegDatum);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 262);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(818, 319);
            this.panel1.TabIndex = 2;
            //
            // lblVerwPerBisKorr
            //
            this.lblVerwPerBisKorr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerwPerBisKorr.Location = new System.Drawing.Point(634, 224);
            this.lblVerwPerBisKorr.Name = "lblVerwPerBisKorr";
            this.lblVerwPerBisKorr.Size = new System.Drawing.Size(18, 24);
            this.lblVerwPerBisKorr.TabIndex = 19;
            this.lblVerwPerBisKorr.Text = "bis";
            this.lblVerwPerBisKorr.UseCompatibleTextRendering = true;
            //
            // lblVerwPerVonKorr
            //
            this.lblVerwPerVonKorr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVerwPerVonKorr.Location = new System.Drawing.Point(391, 224);
            this.lblVerwPerVonKorr.Name = "lblVerwPerVonKorr";
            this.lblVerwPerVonKorr.Size = new System.Drawing.Size(137, 24);
            this.lblVerwPerVonKorr.TabIndex = 17;
            this.lblVerwPerVonKorr.Text = "Verwendungsperiode von";
            this.lblVerwPerVonKorr.UseCompatibleTextRendering = true;
            //
            // lblBetragKorr
            //
            this.lblBetragKorr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBetragKorr.Location = new System.Drawing.Point(391, 254);
            this.lblBetragKorr.Name = "lblBetragKorr";
            this.lblBetragKorr.Size = new System.Drawing.Size(100, 23);
            this.lblBetragKorr.TabIndex = 15;
            this.lblBetragKorr.Text = "Betrag";
            this.lblBetragKorr.UseCompatibleTextRendering = true;
            //
            // edtBgBudgetID
            //
            this.edtBgBudgetID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgBudgetID.DataMember = "BgBudgetID";
            this.edtBgBudgetID.DataSource = this.qryKbBuchungKostenart;
            this.edtBgBudgetID.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgBudgetID.Location = new System.Drawing.Point(528, 284);
            this.edtBgBudgetID.Name = "edtBgBudgetID";
            this.edtBgBudgetID.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBgBudgetID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgBudgetID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgBudgetID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgBudgetID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgBudgetID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgBudgetID.Properties.Appearance.Options.UseFont = true;
            this.edtBgBudgetID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgBudgetID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgBudgetID.Properties.ReadOnly = true;
            this.edtBgBudgetID.Size = new System.Drawing.Size(100, 24);
            this.edtBgBudgetID.TabIndex = 14;
            //
            // qryKbBuchungKostenart
            //
            this.qryKbBuchungKostenart.BatchUpdate = true;
            this.qryKbBuchungKostenart.CanDelete = true;
            this.qryKbBuchungKostenart.CanInsert = true;
            this.qryKbBuchungKostenart.CanUpdate = true;
            this.qryKbBuchungKostenart.HostControl = this;
            this.qryKbBuchungKostenart.SelectStatement = resources.GetString("qryKbBuchungKostenart.SelectStatement");
            this.qryKbBuchungKostenart.TableName = "KbBuchungKostenart";
            //
            // lblBgBudgetID
            //
            this.lblBgBudgetID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBgBudgetID.Location = new System.Drawing.Point(391, 285);
            this.lblBgBudgetID.Name = "lblBgBudgetID";
            this.lblBgBudgetID.Size = new System.Drawing.Size(100, 23);
            this.lblBgBudgetID.TabIndex = 13;
            this.lblBgBudgetID.Text = "Budget";
            this.lblBgBudgetID.UseCompatibleTextRendering = true;
            //
            // lblBuchungstextKorr
            //
            this.lblBuchungstextKorr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBuchungstextKorr.Location = new System.Drawing.Point(391, 194);
            this.lblBuchungstextKorr.Name = "lblBuchungstextKorr";
            this.lblBuchungstextKorr.Size = new System.Drawing.Size(100, 23);
            this.lblBuchungstextKorr.TabIndex = 11;
            this.lblBuchungstextKorr.Text = "Buchungstext";
            this.lblBuchungstextKorr.UseCompatibleTextRendering = true;
            //
            // btnAusführen
            //
            this.btnAusführen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAusführen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAusführen.Location = new System.Drawing.Point(658, 284);
            this.btnAusführen.Name = "btnAusführen";
            this.btnAusführen.Size = new System.Drawing.Size(100, 24);
            this.btnAusführen.TabIndex = 7;
            this.btnAusführen.Text = "Ausführen";
            this.btnAusführen.UseCompatibleTextRendering = true;
            this.btnAusführen.UseVisualStyleBackColor = false;
            this.btnAusführen.Click += new System.EventHandler(this.btnAusführen_Click);
            //
            // lblLAKorr
            //
            this.lblLAKorr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLAKorr.Location = new System.Drawing.Point(8, 254);
            this.lblLAKorr.Name = "lblLAKorr";
            this.lblLAKorr.Size = new System.Drawing.Size(99, 24);
            this.lblLAKorr.TabIndex = 6;
            this.lblLAKorr.Text = "Kostenart";
            this.lblLAKorr.UseCompatibleTextRendering = true;
            //
            // edtBetrag
            //
            this.edtBetrag.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryKbBuchungKostenart;
            this.edtBetrag.Location = new System.Drawing.Point(528, 254);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "N2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "N2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(100, 24);
            this.edtBetrag.TabIndex = 6;
            //
            // edtVerwPeriodeBis
            //
            this.edtVerwPeriodeBis.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtVerwPeriodeBis.DataSource = this.qryKbBuchungKostenart;
            this.edtVerwPeriodeBis.EditValue = null;
            this.edtVerwPeriodeBis.Location = new System.Drawing.Point(658, 224);
            this.edtVerwPeriodeBis.Name = "edtVerwPeriodeBis";
            this.edtVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeBis.Properties.ShowToday = false;
            this.edtVerwPeriodeBis.Size = new System.Drawing.Size(100, 24);
            this.edtVerwPeriodeBis.TabIndex = 5;
            //
            // lblKlient
            //
            this.lblKlient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKlient.Location = new System.Drawing.Point(8, 224);
            this.lblKlient.Name = "lblKlient";
            this.lblKlient.Size = new System.Drawing.Size(100, 23);
            this.lblKlient.TabIndex = 4;
            this.lblKlient.Text = "Klient/in";
            this.lblKlient.UseCompatibleTextRendering = true;
            //
            // edtVerwPeriodeVon
            //
            this.edtVerwPeriodeVon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtVerwPeriodeVon.DataSource = this.qryKbBuchungKostenart;
            this.edtVerwPeriodeVon.EditValue = null;
            this.edtVerwPeriodeVon.Location = new System.Drawing.Point(528, 224);
            this.edtVerwPeriodeVon.Name = "edtVerwPeriodeVon";
            this.edtVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeVon.Properties.ShowToday = false;
            this.edtVerwPeriodeVon.Size = new System.Drawing.Size(100, 24);
            this.edtVerwPeriodeVon.TabIndex = 4;
            //
            // edtBuchungstext
            //
            this.edtBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryKbBuchungKostenart;
            this.edtBuchungstext.Location = new System.Drawing.Point(528, 194);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(230, 24);
            this.edtBuchungstext.TabIndex = 3;
            //
            // lblBelegDatum
            //
            this.lblBelegDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBelegDatum.Location = new System.Drawing.Point(8, 194);
            this.lblBelegDatum.Name = "lblBelegDatum";
            this.lblBelegDatum.Size = new System.Drawing.Size(100, 23);
            this.lblBelegDatum.TabIndex = 2;
            this.lblBelegDatum.Text = "Belegdatum";
            this.lblBelegDatum.UseCompatibleTextRendering = true;
            //
            // edtBgKostenartID
            //
            this.edtBgKostenartID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBgKostenartID.DataMember = "BgKostenart";
            this.edtBgKostenartID.DataSource = this.qryKbBuchungKostenart;
            this.edtBgKostenartID.Location = new System.Drawing.Point(114, 254);
            this.edtBgKostenartID.Name = "edtBgKostenartID";
            this.edtBgKostenartID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBgKostenartID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgKostenartID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgKostenartID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgKostenartID.Properties.Appearance.Options.UseFont = true;
            this.edtBgKostenartID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBgKostenartID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBgKostenartID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgKostenartID.Size = new System.Drawing.Size(262, 24);
            this.edtBgKostenartID.TabIndex = 2;
            this.edtBgKostenartID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBgKostenartID_UserModifiedFld);
            //
            // grdKbBuchungKostenart
            //
            this.grdKbBuchungKostenart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdKbBuchungKostenart.DataSource = this.qryKbBuchungKostenart;
            //
            //
            //
            this.grdKbBuchungKostenart.EmbeddedNavigator.Name = "";
            this.grdKbBuchungKostenart.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdKbBuchungKostenart.Location = new System.Drawing.Point(3, 31);
            this.grdKbBuchungKostenart.MainView = this.grvKbBuchungKostenart;
            this.grdKbBuchungKostenart.Name = "grdKbBuchungKostenart";
            this.grdKbBuchungKostenart.Size = new System.Drawing.Size(812, 157);
            this.grdKbBuchungKostenart.TabIndex = 1;
            this.grdKbBuchungKostenart.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKbBuchungKostenart});
            //
            // grvKbBuchungKostenart
            //
            this.grvKbBuchungKostenart.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKbBuchungKostenart.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.Empty.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.Empty.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.EvenRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenart.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenart.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKbBuchungKostenart.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKbBuchungKostenart.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungKostenart.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.OddRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKbBuchungKostenart.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.Row.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.Appearance.Row.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKbBuchungKostenart.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKbBuchungKostenart.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKbBuchungKostenart.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKbBuchungKostenart.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKbBuchungKostenart.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKlient,
            this.colBaPersonID,
            this.colKostenart,
            this.colBuchungstext,
            this.colBetragKorrektur,
            this.colVerwPeriodeVon,
            this.colVerwPeriodeBis});
            this.grvKbBuchungKostenart.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKbBuchungKostenart.GridControl = this.grdKbBuchungKostenart;
            this.grvKbBuchungKostenart.Name = "grvKbBuchungKostenart";
            this.grvKbBuchungKostenart.OptionsBehavior.Editable = false;
            this.grvKbBuchungKostenart.OptionsCustomization.AllowFilter = false;
            this.grvKbBuchungKostenart.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKbBuchungKostenart.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKbBuchungKostenart.OptionsNavigation.UseTabKey = false;
            this.grvKbBuchungKostenart.OptionsView.ColumnAutoWidth = false;
            this.grvKbBuchungKostenart.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKbBuchungKostenart.OptionsView.ShowFooter = true;
            this.grvKbBuchungKostenart.OptionsView.ShowGroupPanel = false;
            this.grvKbBuchungKostenart.OptionsView.ShowIndicator = false;
            //
            // colKlient
            //
            this.colKlient.Caption = "Klient/in";
            this.colKlient.FieldName = "NameVorname";
            this.colKlient.Name = "colKlient";
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 0;
            this.colKlient.Width = 181;
            //
            // colBaPersonID
            //
            this.colBaPersonID.Caption = "Pers. Nr";
            this.colBaPersonID.FieldName = "BaPersonID";
            this.colBaPersonID.Name = "colBaPersonID";
            this.colBaPersonID.Visible = true;
            this.colBaPersonID.VisibleIndex = 1;
            this.colBaPersonID.Width = 60;
            //
            // colKostenart
            //
            this.colKostenart.Caption = "KoA";
            this.colKostenart.FieldName = "KontoNr";
            this.colKostenart.Name = "colKostenart";
            this.colKostenart.Visible = true;
            this.colKostenart.VisibleIndex = 2;
            this.colKostenart.Width = 48;
            //
            // colBuchungstext
            //
            this.colBuchungstext.Caption = "Buchungstext";
            this.colBuchungstext.FieldName = "Buchungstext";
            this.colBuchungstext.Name = "colBuchungstext";
            this.colBuchungstext.Visible = true;
            this.colBuchungstext.VisibleIndex = 3;
            this.colBuchungstext.Width = 196;
            //
            // colBetragKorrektur
            //
            this.colBetragKorrektur.Caption = "Betrag";
            this.colBetragKorrektur.DisplayFormat.FormatString = "n2";
            this.colBetragKorrektur.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBetragKorrektur.FieldName = "Betrag";
            this.colBetragKorrektur.Name = "colBetragKorrektur";
            this.colBetragKorrektur.SummaryItem.DisplayFormat = "{0:n2}";
            this.colBetragKorrektur.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum;
            this.colBetragKorrektur.Visible = true;
            this.colBetragKorrektur.VisibleIndex = 4;
            this.colBetragKorrektur.Width = 91;
            //
            // colVerwPeriodeVon
            //
            this.colVerwPeriodeVon.Caption = "Verw.periode von";
            this.colVerwPeriodeVon.FieldName = "VerwPeriodeVon";
            this.colVerwPeriodeVon.Name = "colVerwPeriodeVon";
            this.colVerwPeriodeVon.Visible = true;
            this.colVerwPeriodeVon.VisibleIndex = 5;
            this.colVerwPeriodeVon.Width = 110;
            //
            // colVerwPeriodeBis
            //
            this.colVerwPeriodeBis.Caption = "Verw.periode bis";
            this.colVerwPeriodeBis.FieldName = "VerwPeriodeBis";
            this.colVerwPeriodeBis.Name = "colVerwPeriodeBis";
            this.colVerwPeriodeBis.Visible = true;
            this.colVerwPeriodeBis.VisibleIndex = 6;
            this.colVerwPeriodeBis.Width = 110;
            //
            // edtBaPersonID
            //
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBaPersonID.DataMember = "NameVorname";
            this.edtBaPersonID.DataSource = this.qryKbBuchungKostenart;
            this.edtBaPersonID.Location = new System.Drawing.Point(114, 224);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Size = new System.Drawing.Size(262, 24);
            this.edtBaPersonID.TabIndex = 1;
            this.edtBaPersonID.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtBaPersonID_UserModifiedFld);
            //
            // lblKorrektur
            //
            this.lblKorrektur.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblKorrektur.Location = new System.Drawing.Point(3, 9);
            this.lblKorrektur.Name = "lblKorrektur";
            this.lblKorrektur.Size = new System.Drawing.Size(200, 19);
            this.lblKorrektur.TabIndex = 0;
            this.lblKorrektur.Text = "Korrektur / Neubuchung";
            this.lblKorrektur.UseCompatibleTextRendering = true;
            //
            // edtBelegDatum
            //
            this.edtBelegDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBelegDatum.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBelegDatum.EditValue = null;
            this.edtBelegDatum.Location = new System.Drawing.Point(114, 194);
            this.edtBelegDatum.Name = "edtBelegDatum";
            this.edtBelegDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBelegDatum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBelegDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBelegDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBelegDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtBelegDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBelegDatum.Properties.Appearance.Options.UseFont = true;
            this.edtBelegDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtBelegDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtBelegDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtBelegDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBelegDatum.Properties.ReadOnly = true;
            this.edtBelegDatum.Properties.ShowToday = false;
            this.edtBelegDatum.Size = new System.Drawing.Size(100, 24);
            this.edtBelegDatum.TabIndex = 0;
            //
            // btnSprungMonatsbudget
            //
            this.btnSprungMonatsbudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSprungMonatsbudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSprungMonatsbudget.Location = new System.Drawing.Point(693, 268);
            this.btnSprungMonatsbudget.Name = "btnSprungMonatsbudget";
            this.btnSprungMonatsbudget.Size = new System.Drawing.Size(119, 24);
            this.btnSprungMonatsbudget.TabIndex = 8;
            this.btnSprungMonatsbudget.Text = "> Monatsbudget";
            this.btnSprungMonatsbudget.UseCompatibleTextRendering = true;
            this.btnSprungMonatsbudget.UseVisualStyleBackColor = false;
            this.btnSprungMonatsbudget.Click += new System.EventHandler(this.btnSprungMonatsbudget_Click);
            //
            // CtlKbBelegeKorrigieren
            //
            this.ActiveSQLQuery = this.qryKbBuchungSuche;
            this.Controls.Add(this.btnSprungMonatsbudget);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "CtlKbBelegeKorrigieren";
            this.Size = new System.Drawing.Size(818, 581);
            this.Load += new System.EventHandler(this.CtlKbBelegeKorrigieren_Load);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnSprungMonatsbudget, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblOriginal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchungSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungSuche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBelegNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheBgKostenartID.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerBisKorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPerVonKorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetragKorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgBudgetID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKbBuchungKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgBudgetID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstextKorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLAKorr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKlient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBelegDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgKostenartID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKbBuchungKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKbBuchungKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKorrektur)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBelegDatum.Properties)).EndInit();
            this.ResumeLayout(false);
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

        #region Properties

        private bool Neubuchung
        {
            get { return qryKbBuchungSuche.Count > 0 && (int)qryKbBuchungSuche["KbBuchungStatusCode"] == 6; }
        }

        #endregion

        #region EventHandlers

        private void CtlKbBelegeKorrigieren_Load(object sender, System.EventArgs e)
        {
            //Buchungsstati laden
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStati = DBUtil.OpenSQL(@"SELECT Code, Text, Value1
                                                 FROM dbo.XLOVCode
                                                 WHERE LOVName = 'KbBuchungsStatus'
                                                 ORDER BY SortKey");
            foreach (DataRow row in qryStati.DataTable.Rows)
            {
                repositoryItemImageComboBox1.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(),
                    (int)row["Code"],
                    KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            tabControlSearch.SelectTab(tpgSuchen);

            try
            {
                _kbPeriodeID = Convert.ToInt32(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbPeriodeID"));
                _kbMandantID = Convert.ToInt32(FormController.GetMessage("FrmKbKlientenbuchhaltung", false, "Action", "KbMandantID"));
            }
            catch (Exception ex)
            {
                // show error
                KissMsg.ShowError(
                    Name,
                    "ErrorInClassLoad_GetPeriode",
                    "Es ist ein Fehler beim Laden der Maske aufgetreten. Die Geschäftsperiode konnte nicht gefunden werden.", ex);
            }

            kissSearch.SelectParameters = new object[] { _kbPeriodeID };

            qryKbBuchungKostenart.Fill(DBNull.Value);
        }

        private void btnAusführen_Click(object sender, System.EventArgs e)
        {
            if (qryKbBuchungSuche.Count == 0) return;

            if (DBUtil.IsEmpty(edtBelegDatum.EditValue))
            {
                KissMsg.ShowInfo("CtlKbBelegeKorrigieren", "KeinBelegdatum", "Das Feld Belegdatum darf nicht leer sein.");
                return;
            }

            // muss eine Periode für das Belegdatum vorhanden
            SqlQuery qryKbPeriode = DBUtil.OpenSQL(@"
                    SELECT KbPeriodeID = dbo.fnKbGetPeriodeID(KbMandantID, NULL, YEAR({1}), MONTH({1}), 0)
                    FROM KbPeriode
                    WHERE KbPeriodeID = {0}"
                , qryKbBuchungSuche["KbPeriodeID"], edtBelegDatum.EditValue);
            if (qryKbPeriode.IsEmpty || qryKbPeriode["KbPeriodeID"] == DBNull.Value)
            {
                KissMsg.ShowInfo("CtlKbBelegeKorrigieren", "KeinePeriode", "Es hat keine korrespondierende Periode für das gewählte Belegdatum.");
                return;
            }

            qryKbBuchungKostenart.DataTable.AcceptChanges();

            decimal betrag = 0;

            foreach (DataRow row in qryKbBuchungKostenart.DataTable.Rows)
            {
                betrag += (decimal)row["Betrag"];
            }

            if (Neubuchung)
            {
                if ((decimal)qryKbBuchungSuche["Betrag"] != betrag)
                {
                    KissMsg.ShowInfo("CtlKbBelegeKorrigieren", "SummeFalsch", "Summe der Teilbeträge entspricht nicht dem Gesamtbetrag");
                    return;
                }

                if (DBUtil.IsEmpty(edtBelegDatum.EditValue))
                {
                    KissMsg.ShowInfo("CtlKbBelegeKorrigieren", "BelegDatumLeer", "Belegdatum muss ausgefüllt sein.");
                    return;
                }
            }

            // Fortschrittsanzeige
            DlgProgressLog.Show("Beleg stornieren", 700, 500, new ProgressEventHandler(ProgressStart), new ProgressEventHandler(ProgressEnd), Session.MainForm);
        }

        private void btnSprungMonatsbudget_Click(object sender, System.EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryKbBuchungSuche["BgBudgetID"]))
            {
                SqlQuery qry = DBUtil.OpenSQL(@"
                    SELECT FAL.BaPersonID,
                           FLE.ModulID,
                           TreeNodeID = 'CtlWhFinanzplan' + CONVERT(varchar, BFP.BgFinanzplanID) + '\BBG' + CONVERT(varchar, BBG.BgBudgetID)
                    FROM dbo.BgBudget              BBG WITH(READUNCOMMITTED)
                      INNER JOIN dbo.BgFinanzplan  BFP WITH(READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
                      INNER JOIN dbo.FaLeistung    FLE WITH(READUNCOMMITTED) ON FLE.FaLeistungID = BFP.FaLeistungID
                      INNER JOIN dbo.FaFall        FAL WITH(READUNCOMMITTED) ON FAL.FaFallID = FLE.FaFallID
                    WHERE BBG.BgBudgetID = {0}", qryKbBuchungSuche["BgBudgetID"]);

                if (qry.Count == 1)
                {
                    FormController.OpenForm("FrmFall", "Action", "JumpToPath",
                                            "BaPersonID", qry["BaPersonID"],
                                            "ModulID", qry["ModulID"],
                                            "TreeNodeID", qry["TreeNodeID"]);
                }
            }
        }

        private void edtBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            KissLookupDialog dlg = new KissLookupDialog();
            if (e.ButtonClicked || !DBUtil.IsEmpty(SearchString))
            {
                if (DBUtil.IsEmpty(SearchString))
                    SearchString = "%";

                if (SearchString == ".")
                {
                    e.Cancel = !dlg.SearchData(@"
                        SELECT
                          ID = PRS.BaPersonID,
                          PRS.Name,
                          PRS.Vorname,
                          BaPersonID$       = PRS.BaPersonID,
                          NameVorname$      = PRS.NameVorname,
                          KbKostenstelleID$ = KST.KbKostenstelleID
                        FROM BgBudget                       BBG
                          INNER JOIN BgFinanzplan_BaPerson  BFP ON BFP.BgFinanzplanID = BBG.BgFinanzplanID AND IstUnterstuetzt = 1
                          INNER JOIN vwPerson               PRS ON PRS.BaPersonID = BFP.BaPersonID
                          INNER JOIN KbKostenstelle_BaPerson KST ON KST.BaPersonID = PRS.BaPersonID
                                                        AND (KST.DatumBis IS NULL OR GetDate() BETWEEN KST.DatumVon AND KST.DatumBis)
                        WHERE BBG.BgBudgetID = {1}
                        ORDER BY PRS.Name, PRS.Vorname
                        ", SearchString, e.ButtonClicked, qryKbBuchungSuche["BgBudgetID"]);
                }
                else
                {
                    e.Cancel = !dlg.SearchData(@"
                        SELECT
                          ID = PRS.BaPersonID,
                          PRS.Name,
                          PRS.Vorname,
                          BaPersonID$       = PRS.BaPersonID,
                          NameVorname$      = PRS.NameVorname,
                          KbKostenstelleID$ = KST.KbKostenstelleID
                        FROM vwPerson                PRS
                          INNER JOIN KbKostenstelle_BaPerson KST ON KST.BaPersonID = PRS.BaPersonID
                                                        AND (KST.DatumBis IS NULL OR GetDate() BETWEEN KST.DatumVon AND KST.DatumBis)
                        WHERE PRS.NameVorname LIKE '%' + {0} + '%'
                        ORDER BY PRS.Name, PRS.Vorname
                        ", SearchString, e.ButtonClicked);
                }
                if (e.Cancel) return;
            }
            else
            {
                return;
            }

            qryKbBuchungKostenart["BaPersonID"] = dlg["BaPersonID$"];
            qryKbBuchungKostenart["NameVorname"] = dlg["NameVorname$"];
            qryKbBuchungKostenart["KbKostenstelleID"] = dlg["KbKostenstelleID$"];
        }

        private void edtBgKostenartID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();

            e.Cancel = !dlg.SucheKostenart((int)qryKbBuchungSuche["KbPeriodeID"], edtBgKostenartID.Text);

            if (!e.Cancel)
            {
                qryKbBuchungKostenart["BgKostenartID"] = dlg["BgKostenartID"];
                qryKbBuchungKostenart["KontoNr"] = dlg["KontoNr"];
                qryKbBuchungKostenart["BgKostenart"] = (string)dlg["KontoNr"] + ' ' + (string)dlg["Name"];
                qryKbBuchungKostenart["Weiterverrechenbar"] = dlg["Weiterverrechenbar"];
                qryKbBuchungKostenart["Quoting"] = dlg["Quoting"];
                qryKbBuchungKostenart["BgSplittingArtCode"] = dlg["BgSplittingArtCode"];
            }
        }

        private void edtSucheBaPersonID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtSucheBaPersonID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            DlgAuswahl dlg = new DlgAuswahl();
            if (e.ButtonClicked || !DBUtil.IsEmpty(SearchString))
            {
                if (DBUtil.IsEmpty(SearchString))
                    SearchString = "%";

                e.Cancel = !dlg.PersonSuchen(SearchString, e.ButtonClicked);
            }

            edtSucheBaPersonID.EditValue = dlg["Name"];
            edtSucheBaPersonID.LookupID = dlg["BaPersonID"];
        }

        private void edtSucheBgKostenartID_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string SearchString = edtSucheBgKostenartID.Text.Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            KissLookupDialog dlg = new KissLookupDialog();
            if (e.ButtonClicked || !DBUtil.IsEmpty(SearchString))
            {
                if (DBUtil.IsEmpty(SearchString))
                    SearchString = "%";

                e.Cancel = !dlg.SearchData(@"
                    SELECT KontoNr, Name,
                      BgKostenartID$ = BgKostenartID,
                      KontoNrName$ = KontoNr + ' ' + Name
                    FROM BgKostenart
                    WHERE ModulID = 3 AND (KontoNr LIKE '%' + {0} + '%' OR Name LIKE '%' + {0} + '%')
                    ORDER BY KontoNr, Name
                    ", SearchString, e.ButtonClicked);
            }

            edtSucheBgKostenartID.EditValue = dlg["KontoNrName$"];
            edtSucheBgKostenartID.LookupID = dlg["BgKostenartID$"];
        }

        private void qryKbBuchungSuche_AfterFill(object sender, System.EventArgs e)
        {
            if (qryKbBuchungSuche.Count == 0)
            {
                qryKbBuchungSuche_PositionChanged(sender, e);
            }
        }

        private void qryKbBuchungSuche_PositionChanged(object sender, System.EventArgs e)
        {
            edtBelegDatum.EditMode = qryKbBuchungSuche.Count > 0 ? EditModeType.Required : EditModeType.ReadOnly;
            btnSprungMonatsbudget.Enabled = qryKbBuchungSuche.Count > 0 && !DBUtil.IsEmpty(qryKbBuchungSuche["BgBudgetID"]);

            edtBelegDatum.EditValue = null;

            btnAusführen.Enabled = qryKbBuchungSuche.Count > 0;

            grdKbBuchungKostenart.DataSource = null;
            if (btnAusführen.Enabled && Neubuchung)
            {
                btnAusführen.Text = "Umbuchen";

                qryKbBuchungKostenart.CanInsert = true;
                qryKbBuchungKostenart.CanUpdate = true;
                qryKbBuchungKostenart.CanDelete = true;
                qryKbBuchungKostenart.Fill(qryKbBuchungSuche["KbBuchungID"]);
                qryKbBuchungKostenart.ApplyUserRights();
            }
            else if (btnAusführen.Enabled)
            {
                btnAusführen.Text = "Stornieren";

                qryKbBuchungKostenart.CanInsert = false;
                qryKbBuchungKostenart.CanUpdate = false;
                qryKbBuchungKostenart.CanDelete = false;
                qryKbBuchungKostenart.Fill(qryKbBuchungSuche["KbBuchungID"]);
            }
            grdKbBuchungKostenart.DataSource = qryKbBuchungKostenart;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            return qryKbBuchungKostenart.Insert() != null;
        }

        public override bool OnDeleteData()
        {
            return qryKbBuchungKostenart.Delete();
        }

        #endregion

        #region Private Methods

        private int GetBelegNr(int kbPeriodeID, out int kbBelegKreisId)
        {
            int belegNr = (int)DBUtil.ExecuteScalarSQLThrowingException("EXECUTE spKbGetBelegNr {0}, 8, NULL, 0", kbPeriodeID);

            // get the ID of the KbBelegKreis
            kbBelegKreisId = Convert.ToInt32(KliBuUtil.GetKbBelegKreisId(kbPeriodeID, 8));

            return belegNr;
        }

        private void ProgressEnd()
        {
        }

        private void ProgressStart()
        {
            Cursor = Cursors.WaitCursor;
            ApplicationFacade.DoEvents();

            DlgProgressLog.AddLine("Start der Umbuchung");
            ApplicationFacade.DoEvents();

            Session.BeginTransaction();
            try
            {
                SqlQuery qryKbPeriode = DBUtil.OpenSQL(@"
                    SELECT KbPeriodeID = dbo.fnKbGetPeriodeID(KbMandantID, NULL, YEAR({1}), MONTH({1}), 0)
                    FROM KbPeriode
                    WHERE KbPeriodeID = {0}",
                    qryKbBuchungSuche["KbPeriodeID"], edtBelegDatum.EditValue);

                SqlQuery qryBuchung = DBUtil.OpenSQL(@"SELECT * FROM dbo.KbBuchung WHERE 1 = 0");
                SqlQuery qryBuchungKostenart = DBUtil.OpenSQL(@"SELECT
                                                                  KOA.KbBuchungKostenartID,
                                                                  -- KOA.FlBelegKostenartID, //TODO OBSOLETE SPALTE!
                                                                  KOA.KbKostenstelleID,
                                                                  KOA.NrmKontoCode,
                                                                  KOA.Betrag,
                                                                  KOA.KbBuchungID,
                                                                  KOA.KontoNr,
                                                                  KOA.BgKostenartID,
                                                                  KOA.Buchungstext,
                                                                  KOA.BgPositionID,
                                                                  KOA.BaPersonID,
                                                                  KOA.PositionImBeleg,
                                                                  KOA.KbForderungArtCode,
                                                                  KOA.VerwPeriodeVon,
                                                                  KOA.VerwPeriodeBis,
                                                                  [BgSplittingArtCode]=IsNull(KOA.BgSplittingArtCode, BKO.BgSplittingArtCode),
                                                                  KOA.Weiterverrechenbar,  --KOA.Weiterverrechenbar ist ein NOT NULL Feld
                                                                  [Quoting]=IsNull(KOA.Quoting, BKO.Quoting)
                                                                FROM dbo.KbBuchungKostenart KOA
                                                                LEFT JOIN dbo.BgKostenart BKO ON BKO.BgKostenartID = KOA.BgKostenartID
                                                                WHERE 1 = 0");

                // Minusbuchung erstellen
                DlgProgressLog.AddLine("Minusbuchung erzeugen...");
                int kbBelegKreisId;
                int belegNr = GetBelegNr((int)qryKbPeriode["KbPeriodeID"], out kbBelegKreisId);
                DlgProgressLog.AddLine(string.Format("Belegnummer: {0}", belegNr));

                DBUtil.ExecuteScalarSQLThrowingException(@"
                    DECLARE @FixColumnValues  varchar(2000)

                    -- KbBuchungBrutto
                    SELECT Pk = KbBuchungID, Parent = CONVERT(int, NULL), KeyNew = CONVERT(int, NULL)
                    INTO #KbBuchung
                    FROM KbBuchung
                    WHERE KbBuchungID = {0}

                    SET @FixColumnValues =
                              'KbPeriodeID = ' + CONVERT(varchar, {1}) +
                              ', Betrag = -Betrag' +
                              ', BelegNr = ' + CONVERT(varchar, {3}) +
                              ', BelegDatm = CONVERT(datetime, ''' + CONVERT(varchar, {4}, 104) + ''', 104)' +
                              ', KbBelegKreisID = ' + CONVERT(VARCHAR, {5}) +
                              ', KbBuchungStatusCode = 8 /* storniert */' +
                              ', ErstelltUserID = ' + CONVERT(varchar, {2}) +
                              ', ErstelltDatum = GetDate()' +
                              ', StorniertKbBuchungID = ' + CONVERT(varchar, {0})
                    EXECUTE spXParentChildCopy  '#KbBuchung', 'KbBuchung',
                      'KbBuchungID', NULL,
                      'KbPeriodeID, Betrag, BelegNr, BelegDatum, KbBelegKreisID, KbBuchungStatusCode, ErstelltUserID, ErstelltDatum, StorniertKbBuchungID', @FixColumnValues,
                      'TransferDatum, BarbelegDatum, FibuFehlermeldung, MutiertUserID, MutiertDatum'

                    DECLARE @StornoKbBuchungID int

                    SELECT @StornoKbBuchungID = KeyNew
                    FROM #KbBuchung

                    INSERT KbBuchungKostenart (KbKostenstelleID, Betrag, KbBuchungID, KontoNr, BgKostenartID, Buchungstext, BaPersonID, PositionImBeleg, KbForderungArtCode, VerwPeriodeVon, VerwPeriodeBis)
                      SELECT KbKostenstelleID, -Betrag, KbBuchungID = @StornoKbBuchungID, KontoNr, BgKostenartID, Buchungstext, BaPersonID, PositionImBeleg, KbForderungArtCode, VerwPeriodeVon, VerwPeriodeBis
                      FROM KbBuchungKostenart
                      WHERE KbBuchungID = {0}

                    UPDATE KbBuchung
                      SET  KbBuchungStatusCode = 8 /*storniert*/
                    WHERE  KbBuchungID = {0}

                    SELECT @StornoKbBuchungID"
                    , qryKbBuchungSuche["KbBuchungID"]
                    , qryKbPeriode["KbPeriodeID"]
                    , Session.User.UserID
                    , belegNr
                    , edtBelegDatum.EditValue
                    , kbBelegKreisId);

                DlgProgressLog.AddLine("Minusbuchung erfolgreich erzeugt");

                if (Neubuchung)
                {
                    DlgProgressLog.AddLine("Neubuchungen erzeugen...");

                    int positionImBeleg = 1;
                    foreach (DataRow row in qryKbBuchungKostenart.DataTable.Select("1 = 1", "BgBudgetID"))
                    {
                        if (qryBuchung.Count == 0)
                        {
                            belegNr = GetBelegNr((int)qryKbPeriode["KbPeriodeID"], out kbBelegKreisId);
                            DlgProgressLog.AddLine(string.Format("Belegnummer: {0}", belegNr));

                            qryBuchung.Insert("KbBuchung");
                            foreach (DataColumn col in qryBuchung.DataTable.Columns)
                            {
                                if (qryKbBuchungSuche.DataTable.Columns.Contains(col.ColumnName))
                                {
                                    qryBuchung[col.ColumnName] = qryKbBuchungSuche[col.ColumnName];
                                }
                            }

                            qryBuchung["KbPeriodeID"] = qryKbPeriode["KbPeriodeID"];
                            qryBuchung["KbBuchungTypCode"] = 5;
                            qryBuchung["NeubuchungVonKbBuchungID"] = qryKbBuchungSuche["KbBuchungID"];

                            qryBuchung["BelegNr"] = belegNr;
                            qryBuchung["KbBelegKreisID"] = kbBelegKreisId;

                            qryBuchung["ErstelltUserID"] = Session.User.UserID;
                            qryBuchung["ErstelltDatum"] = DateTime.Now;
                            qryBuchung["MutiertUserID"] = null;
                            qryBuchung["MutiertDatum"] = null;
                            qryBuchung["BelegDatum"] = edtBelegDatum.EditValue;

                            qryBuchung["Betrag"] = (decimal)0;

                            positionImBeleg = 1;
                        }

                        qryBuchung["Betrag"] = (decimal)qryBuchung["Betrag"] + (decimal)row["Betrag"];
                        qryBuchung.Post("KbBuchung");

                        qryBuchungKostenart.Insert("KbBuchungKostenart");
                        foreach (DataColumn col in qryBuchungKostenart.DataTable.Columns)
                        {
                            if (qryKbBuchungKostenart.DataTable.Columns.Contains(col.ColumnName))
                            {
                                qryBuchungKostenart[col.ColumnName] = row[col.ColumnName];
                            }
                        }

                        qryBuchungKostenart["KbBuchungID"] = qryBuchung["KbBuchungID"];
                        qryBuchungKostenart["PositionImBeleg"] = positionImBeleg++;
                        qryBuchungKostenart.Post("KbBuchungKostenart");
                    }

                    qryKbBuchungSuche["KbBuchungID"] = qryBuchung["KbBuchungID"];
                    qryKbBuchungSuche.DataSet.AcceptChanges();
                    qryKbBuchungSuche.RowModified = false;

                    DlgProgressLog.AddLine("Neubuchungen erfolgreich erzeugt");
                }
                DlgProgressLog.AddLine("Umbuchung abgeschlossen");

                Session.Commit();
                // hier darf kein Code stehen!
            }
            catch (Exception ex)
            {
                // catch über alle Typen von Exceptions muss immer vorhanden sein!
                // hier darf kein Code stehen!
                // Reihenfolge darf hier nicht vertauscht werden!
                Session.Rollback();
                DlgProgressLog.AddError(string.Format("Neubuchungen erzeugen fehlgeschlagen: {0}", ex));
                return;
            }
            finally
            {
                // Die Daten im Grid neu laden
                DlgProgressLog.AddLine("Die Daten werden neu geladen...");
                qryKbBuchungSuche.Refresh();
                DlgProgressLog.AddLine("Ende der Umbuchung");
                DlgProgressLog.EndProgress();
                DlgProgressLog.ShowTopMost();
                Cursor = Cursors.Default;
            }
        }

        #endregion

        #endregion
    }
}