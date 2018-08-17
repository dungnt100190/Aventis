using System;
using System.ComponentModel;
using System.Data;

using Kiss.Interfaces.DocumentHandling;
using Kiss.Interfaces.UI;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Vormundschaft.ZH
{
    public class CtlKgSparhafenSaldi : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Fields

        private KissButton btnImportieren;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colBaPerson;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colFaFallID;
        private DevExpress.XtraGrid.Columns.GridColumn colImportValid;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKissKontoNr;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKontoName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKontoNr;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colNameVorname;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSaldo;
        private DevExpress.XtraGrid.Columns.GridColumn colSaldoDatum;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colSaldoKiss;
        private DevExpress.XtraGrid.Columns.GridColumn colTimeCreated;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private System.ComponentModel.IContainer components;
        private CtlGotoFall ctlGotoFallNetto;
        private KiSS4.Dokument.XDokument docSaldi;
        private KissDateEdit edtDatumSaldo;
        private KissCheckEdit edtFehlerhafte;
        private KissLookUpEdit edtKontoNr;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungBis;
        private KiSS4.Gui.KissButtonEdit edtSucheErfassungMA;
        private KiSS4.Gui.KissDateEdit edtSucheErfassungVon;
        private KiSS4.Gui.KissDateEdit edtSucheMutationBis;
        private KiSS4.Gui.KissButtonEdit edtSucheMutationMA;
        private KiSS4.Gui.KissDateEdit edtSucheMutationVon;
        private KiSS4.Gui.KissImageComboBoxEdit edtSucheStatus;
        private KiSS4.Gui.KissDateEdit edtSucheValutaBis;
        private KiSS4.Gui.KissDateEdit edtSucheValutaVon;
        private KissButtonEdit edtWhSucheKlientX;
        private KissGrid grdEinzelzahlung;
        private KissGrid grdKonten;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.Grid.GridView grvImportedFiles;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView grvKonten;
        private KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel kissLabel10;
        private KissLabel kissLabel3;
        private KiSS4.Gui.KissLabel kissLabel4;
        private KiSS4.Gui.KissLabel kissLabel5;
        private KiSS4.Gui.KissLabel kissLabel6;
        private KiSS4.Gui.KissLabel kissLabel9;
        private string kontoKategorie;
        private string kontoNr;
        private string kontoRubrik;
        private string kontoSaldo;
        private KissLabel lblAnzahl;
        private KissLabel lblBuchungenVon;
        private KissLabel lblKissKontoNr;
        private KiSS4.Gui.KissLabel lblTitel;
        private string nameVorname;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryKgKonten;
        private KiSS4.DB.SqlQuery qryKgSparhafenImport;
        private SqlQuery qryKontenNr;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;

        #endregion

        #endregion

        #region Constructors

        public CtlKgSparhafenSaldi()
        {
            this.InitializeComponent();
            qryKgSparhafenImport.Fill();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKgSparhafenSaldi));
            this.qryKgKonten = new KiSS4.DB.SqlQuery(this.components);
            this.edtSucheErfassungMA = new KiSS4.Gui.KissButtonEdit();
            this.edtSucheErfassungVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel4 = new KiSS4.Gui.KissLabel();
            this.edtSucheErfassungBis = new KiSS4.Gui.KissDateEdit();
            this.kissLabel5 = new KiSS4.Gui.KissLabel();
            this.edtSucheMutationMA = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel6 = new KiSS4.Gui.KissLabel();
            this.edtSucheMutationVon = new KiSS4.Gui.KissDateEdit();
            this.edtSucheMutationBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheValutaVon = new KiSS4.Gui.KissDateEdit();
            this.kissLabel9 = new KiSS4.Gui.KissLabel();
            this.edtSucheValutaBis = new KiSS4.Gui.KissDateEdit();
            this.edtSucheStatus = new KiSS4.Gui.KissImageComboBoxEdit();
            this.kissLabel10 = new KiSS4.Gui.KissLabel();
            this.qryKgSparhafenImport = new KiSS4.DB.SqlQuery(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdEinzelzahlung = new KiSS4.Gui.KissGrid();
            this.grvImportedFiles = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSaldoDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTimeCreated = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colImportValid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemImageComboBox2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.grdKonten = new KiSS4.Gui.KissGrid();
            this.grvKonten = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colNameVorname = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKontoNr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSaldo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colBaPerson = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colFaFallID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKissKontoNr = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colKontoName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colSaldoKiss = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.docSaldi = new KiSS4.Dokument.XDokument();
            this.edtDatumSaldo = new KiSS4.Gui.KissDateEdit();
            this.lblBuchungenVon = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtFehlerhafte = new KiSS4.Gui.KissCheckEdit();
            this.ctlGotoFallNetto = new KiSS4.Common.CtlGotoFall();
            this.btnImportieren = new KiSS4.Gui.KissButton();
            this.lblKissKontoNr = new KiSS4.Gui.KissLabel();
            this.edtWhSucheKlientX = new KiSS4.Gui.KissButtonEdit();
            this.kissLabel3 = new KiSS4.Gui.KissLabel();
            this.edtKontoNr = new KiSS4.Gui.KissLookUpEdit();
            this.qryKontenNr = new KiSS4.DB.SqlQuery(this.components);
            this.lblAnzahl = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgKonten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationMA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgSparhafenImport)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinzelzahlung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImportedFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKonten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKonten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSaldi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumSaldo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungenVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFehlerhafte.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheKlientX.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontenNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahl)).BeginInit();
            this.SuspendLayout();
            //
            // qryKgKonten
            //
            this.qryKgKonten.CanUpdate = true;
            this.qryKgKonten.DeleteQuestion = "Soll die Position gelöscht werden ?";
            this.qryKgKonten.HostControl = this;
            this.qryKgKonten.SelectStatement = resources.GetString("qryKgKonten.SelectStatement");
            this.qryKgKonten.TableName = "KgSparhafenSaldo";
            this.qryKgKonten.PositionChanged += new System.EventHandler(this.qryKgKonten_PositionChanged);
            this.qryKgKonten.AfterFill += new System.EventHandler(this.qryKgKonten_AfterFill);
            this.qryKgKonten.AfterInsert += new System.EventHandler(this.qryKgKonten_AfterInsert);
            //
            // edtSucheErfassungMA
            //
            this.edtSucheErfassungMA.Location = new System.Drawing.Point(107, 54);
            this.edtSucheErfassungMA.Name = "edtSucheErfassungMA";
            this.edtSucheErfassungMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject8.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject8.Options.UseBackColor = true;
            this.edtSucheErfassungMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject8)});
            this.edtSucheErfassungMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungMA.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungMA.TabIndex = 0;
            //
            // edtSucheErfassungVon
            //
            this.edtSucheErfassungVon.EditValue = null;
            this.edtSucheErfassungVon.Location = new System.Drawing.Point(213, 54);
            this.edtSucheErfassungVon.Name = "edtSucheErfassungVon";
            this.edtSucheErfassungVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheErfassungVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject9.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject9.Options.UseBackColor = true;
            this.edtSucheErfassungVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9)});
            this.edtSucheErfassungVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungVon.Properties.ShowToday = false;
            this.edtSucheErfassungVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungVon.TabIndex = 1;
            //
            // kissLabel4
            //
            this.kissLabel4.Location = new System.Drawing.Point(8, 54);
            this.kissLabel4.Name = "kissLabel4";
            this.kissLabel4.Size = new System.Drawing.Size(93, 24);
            this.kissLabel4.TabIndex = 1;
            this.kissLabel4.Text = "Erfassung";
            this.kissLabel4.UseCompatibleTextRendering = true;
            //
            // edtSucheErfassungBis
            //
            this.edtSucheErfassungBis.EditValue = null;
            this.edtSucheErfassungBis.Location = new System.Drawing.Point(319, 54);
            this.edtSucheErfassungBis.Name = "edtSucheErfassungBis";
            this.edtSucheErfassungBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheErfassungBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheErfassungBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheErfassungBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheErfassungBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheErfassungBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject10.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject10.Options.UseBackColor = true;
            this.edtSucheErfassungBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheErfassungBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject10)});
            this.edtSucheErfassungBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheErfassungBis.Properties.ShowToday = false;
            this.edtSucheErfassungBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheErfassungBis.TabIndex = 2;
            //
            // kissLabel5
            //
            this.kissLabel5.Location = new System.Drawing.Point(8, 84);
            this.kissLabel5.Name = "kissLabel5";
            this.kissLabel5.Size = new System.Drawing.Size(82, 24);
            this.kissLabel5.TabIndex = 2;
            this.kissLabel5.Text = "Mutation";
            this.kissLabel5.UseCompatibleTextRendering = true;
            //
            // edtSucheMutationMA
            //
            this.edtSucheMutationMA.Location = new System.Drawing.Point(107, 84);
            this.edtSucheMutationMA.Name = "edtSucheMutationMA";
            this.edtSucheMutationMA.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationMA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationMA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationMA.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationMA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationMA.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationMA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject11.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject11.Options.UseBackColor = true;
            this.edtSucheMutationMA.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject11)});
            this.edtSucheMutationMA.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationMA.Size = new System.Drawing.Size(100, 24);
            this.edtSucheMutationMA.TabIndex = 3;
            //
            // kissLabel6
            //
            this.kissLabel6.Location = new System.Drawing.Point(8, 125);
            this.kissLabel6.Name = "kissLabel6";
            this.kissLabel6.Size = new System.Drawing.Size(72, 24);
            this.kissLabel6.TabIndex = 3;
            this.kissLabel6.Text = "Valuta von";
            this.kissLabel6.UseCompatibleTextRendering = true;
            //
            // edtSucheMutationVon
            //
            this.edtSucheMutationVon.EditValue = null;
            this.edtSucheMutationVon.Location = new System.Drawing.Point(213, 84);
            this.edtSucheMutationVon.Name = "edtSucheMutationVon";
            this.edtSucheMutationVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheMutationVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject12.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject12.Options.UseBackColor = true;
            this.edtSucheMutationVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheMutationVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject12)});
            this.edtSucheMutationVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationVon.Properties.ShowToday = false;
            this.edtSucheMutationVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheMutationVon.TabIndex = 4;
            //
            // edtSucheMutationBis
            //
            this.edtSucheMutationBis.EditValue = null;
            this.edtSucheMutationBis.Location = new System.Drawing.Point(319, 84);
            this.edtSucheMutationBis.Name = "edtSucheMutationBis";
            this.edtSucheMutationBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheMutationBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMutationBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMutationBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMutationBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMutationBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMutationBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMutationBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject13.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject13.Options.UseBackColor = true;
            this.edtSucheMutationBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheMutationBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13)});
            this.edtSucheMutationBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheMutationBis.Properties.ShowToday = false;
            this.edtSucheMutationBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheMutationBis.TabIndex = 5;
            //
            // edtSucheValutaVon
            //
            this.edtSucheValutaVon.EditValue = null;
            this.edtSucheValutaVon.Location = new System.Drawing.Point(107, 125);
            this.edtSucheValutaVon.Name = "edtSucheValutaVon";
            this.edtSucheValutaVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaVon.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject14.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject14.Options.UseBackColor = true;
            this.edtSucheValutaVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject14)});
            this.edtSucheValutaVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaVon.Properties.ShowToday = false;
            this.edtSucheValutaVon.Size = new System.Drawing.Size(100, 24);
            this.edtSucheValutaVon.TabIndex = 6;
            //
            // kissLabel9
            //
            this.kissLabel9.Location = new System.Drawing.Point(224, 125);
            this.kissLabel9.Name = "kissLabel9";
            this.kissLabel9.Size = new System.Drawing.Size(27, 24);
            this.kissLabel9.TabIndex = 6;
            this.kissLabel9.Text = "bis";
            this.kissLabel9.UseCompatibleTextRendering = true;
            //
            // edtSucheValutaBis
            //
            this.edtSucheValutaBis.EditValue = null;
            this.edtSucheValutaBis.Location = new System.Drawing.Point(263, 125);
            this.edtSucheValutaBis.Name = "edtSucheValutaBis";
            this.edtSucheValutaBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtSucheValutaBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheValutaBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheValutaBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheValutaBis.Properties.Appearance.Options.UseFont = true;
            this.edtSucheValutaBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject15.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject15.Options.UseBackColor = true;
            this.edtSucheValutaBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtSucheValutaBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject15)});
            this.edtSucheValutaBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheValutaBis.Properties.ShowToday = false;
            this.edtSucheValutaBis.Size = new System.Drawing.Size(100, 24);
            this.edtSucheValutaBis.TabIndex = 7;
            //
            // edtSucheStatus
            //
            this.edtSucheStatus.Location = new System.Drawing.Point(107, 154);
            this.edtSucheStatus.Name = "edtSucheStatus";
            this.edtSucheStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheStatus.Properties.Appearance.Options.UseFont = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtSucheStatus.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtSucheStatus.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtSucheStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edtSucheStatus.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtSucheStatus.Size = new System.Drawing.Size(256, 24);
            this.edtSucheStatus.TabIndex = 8;
            //
            // kissLabel10
            //
            this.kissLabel10.Location = new System.Drawing.Point(8, 155);
            this.kissLabel10.Name = "kissLabel10";
            this.kissLabel10.Size = new System.Drawing.Size(72, 24);
            this.kissLabel10.TabIndex = 9;
            this.kissLabel10.Text = "Status";
            this.kissLabel10.UseCompatibleTextRendering = true;
            //
            // qryKgSparhafenImport
            //
            this.qryKgSparhafenImport.CanDelete = true;
            this.qryKgSparhafenImport.CanInsert = true;
            this.qryKgSparhafenImport.CanUpdate = true;
            this.qryKgSparhafenImport.DeleteQuestion = "Wollen Sie wirklich diesen Eintrag und alle dazuhörigen importierten Daten lösche" +
                "n?";
            this.qryKgSparhafenImport.HostControl = this;
            this.qryKgSparhafenImport.SelectStatement = "SELECT\r\n  [KgSparhafenSaldoImportID],\r\n  [UserID],\r\n  [DatumSaldo],\r\n  [DatumImpo" +
                "rt],\r\n  [ImportErfolgreich],\r\n  [DocumentID],\r\n  [KgSparhafenSaldoImportTS]\r\nFRO" +
                "M KgSparHafenSaldoImport IMP";
            this.qryKgSparhafenImport.TableName = "KgSparHafenSaldoImport ";
            this.qryKgSparhafenImport.PositionChanged += new System.EventHandler(this.qryKgSparhafenImport_PositionChanged);
            this.qryKgSparhafenImport.AfterInsert += new System.EventHandler(this.qryKgSparhafenImport_AfterInsert);
            //
            // panel1
            //
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(820, 24);
            this.panel1.TabIndex = 12;
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(5, 5);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(25, 5);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(542, 15);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Sparhafen Saldi Import";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // grdEinzelzahlung
            //
            this.grdEinzelzahlung.DataSource = this.qryKgSparhafenImport;
            this.grdEinzelzahlung.EmbeddedNavigator.Name = "";
            this.grdEinzelzahlung.Location = new System.Drawing.Point(3, 27);
            this.grdEinzelzahlung.MainView = this.grvImportedFiles;
            this.grdEinzelzahlung.Name = "grdEinzelzahlung";
            this.grdEinzelzahlung.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox2,
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit1});
            this.grdEinzelzahlung.Size = new System.Drawing.Size(800, 171);
            this.grdEinzelzahlung.TabIndex = 13;
            this.grdEinzelzahlung.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvImportedFiles});
            //
            // grvImportedFiles
            //
            this.grvImportedFiles.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvImportedFiles.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.Empty.Options.UseBackColor = true;
            this.grvImportedFiles.Appearance.Empty.Options.UseFont = true;
            this.grvImportedFiles.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.EvenRow.Options.UseFont = true;
            this.grvImportedFiles.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvImportedFiles.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvImportedFiles.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvImportedFiles.Appearance.FocusedCell.Options.UseFont = true;
            this.grvImportedFiles.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvImportedFiles.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvImportedFiles.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvImportedFiles.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvImportedFiles.Appearance.FocusedRow.Options.UseFont = true;
            this.grvImportedFiles.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvImportedFiles.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvImportedFiles.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvImportedFiles.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvImportedFiles.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvImportedFiles.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvImportedFiles.Appearance.GroupRow.Options.UseFont = true;
            this.grvImportedFiles.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvImportedFiles.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvImportedFiles.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvImportedFiles.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvImportedFiles.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvImportedFiles.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvImportedFiles.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvImportedFiles.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvImportedFiles.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvImportedFiles.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvImportedFiles.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvImportedFiles.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvImportedFiles.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvImportedFiles.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.OddRow.Options.UseFont = true;
            this.grvImportedFiles.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvImportedFiles.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.Row.Options.UseBackColor = true;
            this.grvImportedFiles.Appearance.Row.Options.UseFont = true;
            this.grvImportedFiles.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvImportedFiles.Appearance.SelectedRow.Options.UseFont = true;
            this.grvImportedFiles.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvImportedFiles.Appearance.VertLine.Options.UseBackColor = true;
            this.grvImportedFiles.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvImportedFiles.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSaldoDatum,
            this.colTimeCreated,
            this.colUser,
            this.colImportValid});
            this.grvImportedFiles.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvImportedFiles.GridControl = this.grdEinzelzahlung;
            this.grvImportedFiles.Name = "grvImportedFiles";
            this.grvImportedFiles.OptionsBehavior.Editable = false;
            this.grvImportedFiles.OptionsCustomization.AllowFilter = false;
            this.grvImportedFiles.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvImportedFiles.OptionsNavigation.AutoFocusNewRow = true;
            this.grvImportedFiles.OptionsNavigation.UseTabKey = false;
            this.grvImportedFiles.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvImportedFiles.OptionsView.ColumnAutoWidth = false;
            this.grvImportedFiles.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvImportedFiles.OptionsView.ShowGroupPanel = false;
            this.grvImportedFiles.OptionsView.ShowIndicator = false;
            //
            // colSaldoDatum
            //
            this.colSaldoDatum.Caption = "Datum Saldo";
            this.colSaldoDatum.FieldName = "DatumSaldo";
            this.colSaldoDatum.Name = "colSaldoDatum";
            this.colSaldoDatum.OptionsColumn.AllowEdit = false;
            this.colSaldoDatum.Visible = true;
            this.colSaldoDatum.VisibleIndex = 0;
            this.colSaldoDatum.Width = 116;
            //
            // colTimeCreated
            //
            this.colTimeCreated.Caption = "Import-Datum";
            this.colTimeCreated.FieldName = "DatumImport";
            this.colTimeCreated.Name = "colTimeCreated";
            this.colTimeCreated.OptionsColumn.AllowEdit = false;
            this.colTimeCreated.Visible = true;
            this.colTimeCreated.VisibleIndex = 1;
            this.colTimeCreated.Width = 127;
            //
            // colUser
            //
            this.colUser.Caption = "Importiert von";
            this.colUser.FieldName = "User";
            this.colUser.Name = "colUser";
            this.colUser.OptionsColumn.AllowEdit = false;
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 2;
            this.colUser.Width = 249;
            //
            // colImportValid
            //
            this.colImportValid.Caption = "Import erfolgreich";
            this.colImportValid.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colImportValid.FieldName = "ImportErfolgreich";
            this.colImportValid.Name = "colImportValid";
            this.colImportValid.Visible = true;
            this.colImportValid.VisibleIndex = 3;
            this.colImportValid.Width = 113;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.ReadOnly = true;
            //
            // repositoryItemImageComboBox2
            //
            this.repositoryItemImageComboBox2.AutoHeight = false;
            this.repositoryItemImageComboBox2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox2.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox2.Name = "repositoryItemImageComboBox2";
            //
            // repositoryItemTextEdit1
            //
            this.repositoryItemTextEdit1.AllowFocused = false;
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.ReadOnly = true;
            //
            // grdKonten
            //
            this.grdKonten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdKonten.DataSource = this.qryKgKonten;
            this.grdKonten.EmbeddedNavigator.Name = "";
            this.grdKonten.Location = new System.Drawing.Point(5, 259);
            this.grdKonten.MainView = this.grvKonten;
            this.grdKonten.Name = "grdKonten";
            this.grdKonten.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemTextEdit2});
            this.grdKonten.Size = new System.Drawing.Size(800, 293);
            this.grdKonten.TabIndex = 14;
            this.grdKonten.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvKonten});
            //
            // grvKonten
            //
            this.grvKonten.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvKonten.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.Empty.Options.UseBackColor = true;
            this.grvKonten.Appearance.Empty.Options.UseFont = true;
            this.grvKonten.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.EvenRow.Options.UseFont = true;
            this.grvKonten.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKonten.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvKonten.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvKonten.Appearance.FocusedCell.Options.UseFont = true;
            this.grvKonten.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvKonten.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvKonten.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvKonten.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvKonten.Appearance.FocusedRow.Options.UseFont = true;
            this.grvKonten.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvKonten.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKonten.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvKonten.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvKonten.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKonten.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvKonten.Appearance.GroupRow.Options.UseFont = true;
            this.grvKonten.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvKonten.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvKonten.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvKonten.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvKonten.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvKonten.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvKonten.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvKonten.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvKonten.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvKonten.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvKonten.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvKonten.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvKonten.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvKonten.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.OddRow.Options.UseFont = true;
            this.grvKonten.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvKonten.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.Row.Options.UseBackColor = true;
            this.grvKonten.Appearance.Row.Options.UseFont = true;
            this.grvKonten.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvKonten.Appearance.SelectedRow.Options.UseFont = true;
            this.grvKonten.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvKonten.Appearance.VertLine.Options.UseBackColor = true;
            this.grvKonten.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand2});
            this.grvKonten.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvKonten.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colNameVorname,
            this.colKontoNr,
            this.colSaldo,
            this.colBaPerson,
            this.colFaFallID,
            this.colKontoName,
            this.colSaldoKiss,
            this.colKissKontoNr});
            this.grvKonten.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvKonten.GridControl = this.grdKonten;
            this.grvKonten.Name = "grvKonten";
            this.grvKonten.OptionsBehavior.Editable = false;
            this.grvKonten.OptionsCustomization.AllowFilter = false;
            this.grvKonten.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvKonten.OptionsNavigation.AutoFocusNewRow = true;
            this.grvKonten.OptionsNavigation.UseTabKey = false;
            this.grvKonten.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.grvKonten.OptionsView.ColumnAutoWidth = false;
            this.grvKonten.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvKonten.OptionsView.ShowGroupPanel = false;
            this.grvKonten.OptionsView.ShowIndicator = false;
            //
            // gridBand1
            //
            this.gridBand1.Caption = "Importierte Daten";
            this.gridBand1.Columns.Add(this.colNameVorname);
            this.gridBand1.Columns.Add(this.colKontoNr);
            this.gridBand1.Columns.Add(this.colSaldo);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.Width = 387;
            //
            // colNameVorname
            //
            this.colNameVorname.Caption = "Name";
            this.colNameVorname.FieldName = "NameVorname";
            this.colNameVorname.Name = "colNameVorname";
            this.colNameVorname.OptionsColumn.AllowEdit = false;
            this.colNameVorname.Visible = true;
            this.colNameVorname.Width = 136;
            //
            // colKontoNr
            //
            this.colKontoNr.Caption = "Konto-Nr.";
            this.colKontoNr.FieldName = "KontoNr";
            this.colKontoNr.Name = "colKontoNr";
            this.colKontoNr.OptionsColumn.AllowEdit = false;
            this.colKontoNr.Visible = true;
            this.colKontoNr.Width = 149;
            //
            // colSaldo
            //
            this.colSaldo.Caption = "Saldo";
            this.colSaldo.DisplayFormat.FormatString = "n2";
            this.colSaldo.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSaldo.FieldName = "Saldo";
            this.colSaldo.Name = "colSaldo";
            this.colSaldo.OptionsColumn.AllowEdit = false;
            this.colSaldo.Visible = true;
            this.colSaldo.Width = 102;
            //
            // gridBand2
            //
            this.gridBand2.Caption = "Kiss-Daten";
            this.gridBand2.Columns.Add(this.colBaPerson);
            this.gridBand2.Columns.Add(this.colFaFallID);
            this.gridBand2.Columns.Add(this.colKissKontoNr);
            this.gridBand2.Columns.Add(this.colKontoName);
            this.gridBand2.Columns.Add(this.colSaldoKiss);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.Width = 324;
            //
            // colBaPerson
            //
            this.colBaPerson.Caption = "Klientenname";
            this.colBaPerson.FieldName = "KissNameVorname";
            this.colBaPerson.Name = "colBaPerson";
            this.colBaPerson.Visible = true;
            this.colBaPerson.Width = 159;
            //
            // colFaFallID
            //
            this.colFaFallID.Caption = "Fall-Nr.";
            this.colFaFallID.FieldName = "FaFallID";
            this.colFaFallID.Name = "colFaFallID";
            this.colFaFallID.Visible = true;
            this.colFaFallID.Width = 90;
            //
            // colKissKontoNr
            //
            this.colKissKontoNr.Caption = "Konto-Nr.";
            this.colKissKontoNr.FieldName = "KissKontoNr";
            this.colKissKontoNr.Name = "colKissKontoNr";
            this.colKissKontoNr.Visible = true;
            //
            // colKontoName
            //
            this.colKontoName.Caption = "Konto-Name";
            this.colKontoName.FieldName = "KissKontoName";
            this.colKontoName.Name = "colKontoName";
            this.colKontoName.Width = 97;
            //
            // colSaldoKiss
            //
            this.colSaldoKiss.Caption = "Kiss-Saldo";
            this.colSaldoKiss.FieldName = "KissSaldo";
            this.colSaldoKiss.Name = "colSaldoKiss";
            //
            // repositoryItemImageComboBox1
            //
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            //
            // repositoryItemCheckEdit2
            //
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            //
            // repositoryItemTextEdit2
            //
            this.repositoryItemTextEdit2.AllowFocused = false;
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            this.repositoryItemTextEdit2.ReadOnly = true;
            //
            // docSaldi
            //
            this.docSaldi.AllowDrop = true;
            this.docSaldi.CanCreateDocument = false;
            this.docSaldi.CanDeleteDocument = false;
            this.docSaldi.Context = null;
            this.docSaldi.DataMember = "DocumentID";
            this.docSaldi.DataSource = this.qryKgSparhafenImport;
            this.docSaldi.Location = new System.Drawing.Point(550, 215);
            this.docSaldi.Name = "docSaldi";
            this.docSaldi.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.docSaldi.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.docSaldi.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.docSaldi.Properties.Appearance.Options.UseBackColor = true;
            this.docSaldi.Properties.Appearance.Options.UseBorderColor = true;
            this.docSaldi.Properties.Appearance.Options.UseFont = true;
            this.docSaldi.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject7.Options.UseBackColor = true;
            this.docSaldi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSaldi.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4, "Dokument öffnen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSaldi.Properties.Buttons1"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, "Dokument löschen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSaldi.Properties.Buttons2"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6, "Neues Dokument erstellen"),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("docSaldi.Properties.Buttons3"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject7, "Dokument importieren")});
            this.docSaldi.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.docSaldi.Properties.ReadOnly = true;
            this.docSaldi.Size = new System.Drawing.Size(114, 24);
            this.docSaldi.TabIndex = 15;
            this.docSaldi.DocumentImported += new System.EventHandler(this.docSaldi_DocumentImported);
            this.docSaldi.DocumentImporting += new System.ComponentModel.CancelEventHandler(this.docSaldi_DocumentImporting);
            //
            // edtDatumSaldo
            //
            this.edtDatumSaldo.DataMember = "DatumSaldo";
            this.edtDatumSaldo.DataSource = this.qryKgSparhafenImport;
            this.edtDatumSaldo.EditValue = null;
            this.edtDatumSaldo.Location = new System.Drawing.Point(315, 215);
            this.edtDatumSaldo.Name = "edtDatumSaldo";
            this.edtDatumSaldo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumSaldo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumSaldo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumSaldo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumSaldo.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumSaldo.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumSaldo.Properties.Appearance.Options.UseFont = true;
            this.edtDatumSaldo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtDatumSaldo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumSaldo.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtDatumSaldo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumSaldo.Properties.ShowToday = false;
            this.edtDatumSaldo.Size = new System.Drawing.Size(90, 24);
            this.edtDatumSaldo.TabIndex = 16;
            //
            // lblBuchungenVon
            //
            this.lblBuchungenVon.Location = new System.Drawing.Point(233, 215);
            this.lblBuchungenVon.Name = "lblBuchungenVon";
            this.lblBuchungenVon.Size = new System.Drawing.Size(76, 24);
            this.lblBuchungenVon.TabIndex = 17;
            this.lblBuchungenVon.Text = "Saldo-Datum:";
            this.lblBuchungenVon.UseCompatibleTextRendering = true;
            //
            // kissLabel1
            //
            this.kissLabel1.Location = new System.Drawing.Point(425, 215);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(119, 24);
            this.kissLabel1.TabIndex = 18;
            this.kissLabel1.Text = "Zu importierende Datei:";
            this.kissLabel1.UseCompatibleTextRendering = true;
            //
            // edtFehlerhafte
            //
            this.edtFehlerhafte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFehlerhafte.EditValue = true;
            this.edtFehlerhafte.Location = new System.Drawing.Point(3, 563);
            this.edtFehlerhafte.Name = "edtFehlerhafte";
            this.edtFehlerhafte.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.edtFehlerhafte.Properties.Appearance.Options.UseBackColor = true;
            this.edtFehlerhafte.Properties.Caption = "nur nicht zugeordnete Einträge anzeigen";
            this.edtFehlerhafte.Size = new System.Drawing.Size(226, 19);
            this.edtFehlerhafte.TabIndex = 20;
            this.edtFehlerhafte.CheckedChanged += new System.EventHandler(this.edtFehlerhafte_CheckedChanged);
            //
            // ctlGotoFallNetto
            //
            this.ctlGotoFallNetto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFallNetto.BaPersonID = ((object)(resources.GetObject("ctlGotoFallNetto.BaPersonID")));
            this.ctlGotoFallNetto.DataMember = "FallBaPersonID";
            this.ctlGotoFallNetto.DataSource = this.qryKgKonten;
            this.ctlGotoFallNetto.Location = new System.Drawing.Point(3, 597);
            this.ctlGotoFallNetto.Name = "ctlGotoFallNetto";
            this.ctlGotoFallNetto.Size = new System.Drawing.Size(110, 27);
            this.ctlGotoFallNetto.TabIndex = 114;
            //
            // btnImportieren
            //
            this.btnImportieren.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportieren.Location = new System.Drawing.Point(707, 215);
            this.btnImportieren.Name = "btnImportieren";
            this.btnImportieren.Size = new System.Drawing.Size(96, 24);
            this.btnImportieren.TabIndex = 115;
            this.btnImportieren.Text = "Importieren...";
            this.btnImportieren.UseVisualStyleBackColor = false;
            this.btnImportieren.Click += new System.EventHandler(this.btnZuordnen_Click);
            //
            // lblKissKontoNr
            //
            this.lblKissKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKissKontoNr.Location = new System.Drawing.Point(615, 558);
            this.lblKissKontoNr.Name = "lblKissKontoNr";
            this.lblKissKontoNr.Size = new System.Drawing.Size(75, 24);
            this.lblKissKontoNr.TabIndex = 117;
            this.lblKissKontoNr.Text = "Kiss-Konto-Nr";
            this.lblKissKontoNr.UseCompatibleTextRendering = true;
            //
            // edtWhSucheKlientX
            //
            this.edtWhSucheKlientX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtWhSucheKlientX.DataMember = "BaPersonID";
            this.edtWhSucheKlientX.DataSource = this.qryKgKonten;
            this.edtWhSucheKlientX.Location = new System.Drawing.Point(332, 558);
            this.edtWhSucheKlientX.LookupSQL = resources.GetString("edtWhSucheKlientX.LookupSQL");
            this.edtWhSucheKlientX.Name = "edtWhSucheKlientX";
            this.edtWhSucheKlientX.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtWhSucheKlientX.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtWhSucheKlientX.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtWhSucheKlientX.Properties.Appearance.Options.UseBackColor = true;
            this.edtWhSucheKlientX.Properties.Appearance.Options.UseBorderColor = true;
            this.edtWhSucheKlientX.Properties.Appearance.Options.UseFont = true;
            this.edtWhSucheKlientX.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtWhSucheKlientX.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtWhSucheKlientX.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtWhSucheKlientX.Properties.Name = "kissButtonEdit1.Properties";
            this.edtWhSucheKlientX.Size = new System.Drawing.Size(260, 24);
            this.edtWhSucheKlientX.TabIndex = 355;
            this.edtWhSucheKlientX.Validated += new System.EventHandler(this.edtWhSucheKlientX_Validated);
            //
            // kissLabel3
            //
            this.kissLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel3.Location = new System.Drawing.Point(279, 558);
            this.kissLabel3.Name = "kissLabel3";
            this.kissLabel3.Size = new System.Drawing.Size(47, 24);
            this.kissLabel3.TabIndex = 356;
            this.kissLabel3.Text = "Klient:";
            this.kissLabel3.UseCompatibleTextRendering = true;
            //
            // edtKontoNr
            //
            this.edtKontoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontoNr.DataMember = "KissKontoNr";
            this.edtKontoNr.DataSource = this.qryKgKonten;
            this.edtKontoNr.Location = new System.Drawing.Point(696, 559);
            this.edtKontoNr.Name = "edtKontoNr";
            this.edtKontoNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontoNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontoNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontoNr.Properties.Appearance.Options.UseFont = true;
            this.edtKontoNr.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKontoNr.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontoNr.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKontoNr.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKontoNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKontoNr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKontoNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKontoNr.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KontoNr")});
            this.edtKontoNr.Properties.DataSource = this.qryKontenNr;
            this.edtKontoNr.Properties.DisplayMember = "KontoNr";
            this.edtKontoNr.Properties.NullText = "";
            this.edtKontoNr.Properties.ShowFooter = false;
            this.edtKontoNr.Properties.ShowHeader = false;
            this.edtKontoNr.Properties.ValueMember = "KontoNr";
            this.edtKontoNr.Size = new System.Drawing.Size(107, 24);
            this.edtKontoNr.TabIndex = 357;
            //
            // qryKontenNr
            //
            this.qryKontenNr.DeleteQuestion = "Soll die Position gelöscht werden ?";
            this.qryKontenNr.HostControl = this;
            this.qryKontenNr.SelectStatement = resources.GetString("qryKontenNr.SelectStatement");
            this.qryKontenNr.TableName = "KgSparhafenSaldo";
            //
            // lblAnzahl
            //
            this.lblAnzahl.Location = new System.Drawing.Point(3, 232);
            this.lblAnzahl.Name = "lblAnzahl";
            this.lblAnzahl.Size = new System.Drawing.Size(167, 24);
            this.lblAnzahl.TabIndex = 358;
            this.lblAnzahl.Text = "Anzahl: ";
            this.lblAnzahl.UseCompatibleTextRendering = true;
            //
            // CtlKgSparhafenSaldi
            //
            this.ActiveSQLQuery = this.qryKgSparhafenImport;
            this.Controls.Add(this.lblAnzahl);
            this.Controls.Add(this.edtKontoNr);
            this.Controls.Add(this.kissLabel3);
            this.Controls.Add(this.edtWhSucheKlientX);
            this.Controls.Add(this.lblKissKontoNr);
            this.Controls.Add(this.btnImportieren);
            this.Controls.Add(this.ctlGotoFallNetto);
            this.Controls.Add(this.edtFehlerhafte);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.lblBuchungenVon);
            this.Controls.Add(this.edtDatumSaldo);
            this.Controls.Add(this.docSaldi);
            this.Controls.Add(this.grdKonten);
            this.Controls.Add(this.grdEinzelzahlung);
            this.Controls.Add(this.panel1);
            this.Name = "CtlKgSparhafenSaldi";
            this.Size = new System.Drawing.Size(820, 631);
            this.Load += new System.EventHandler(this.CtlKgSparhafenSaldi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qryKgKonten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheErfassungBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationMA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMutationBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheValutaBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKgSparhafenImport)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEinzelzahlung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvImportedFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdKonten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvKonten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docSaldi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumSaldo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungenVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFehlerhafte.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKissKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWhSucheKlientX.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontoNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryKontenNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnzahl)).EndInit();
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

        #region EventHandlers

        private void CtlKgSparhafenSaldi_Load(object sender, System.EventArgs e)
        {
            OnSearch();
        }

        private void btnZuordnen_Click(object sender, EventArgs e)
        {
            if (DBUtil.IsEmpty(edtDatumSaldo.EditValue))
            {
                KissMsg.ShowInfo("Das Saldo-Datum muss vor dem importieren ausgefüllt werden!");
            }
            else if (DBUtil.IsEmpty(docSaldi.DocumentID))
            {
                KissMsg.ShowInfo("Das Dokument muss vor dem importieren ausgewählt werden!");
            }
            else
            {
                DlgProgressLog.Show("Excel-Daten Importieren", excelImport, null, Session.MainForm);
            }
        }

        private void docSaldi_DocumentImported(object sender, EventArgs e)
        {
            SetEditMode();
        }

        private void docSaldi_DocumentImporting(object sender, CancelEventArgs e)
        {
            if (DBUtil.IsEmpty(edtDatumSaldo.EditValue))
            {
                KissMsg.ShowInfo("Bitte füllen Sie zuerst das Saldo-Datum aus.");
                e.Cancel = true;
            }
        }

        private void edtFehlerhafte_CheckedChanged(object sender, EventArgs e)
        {
            setRowFilter();
            setLabelAnzahl();
        }

        private void edtWhSucheKlientX_Validated(object sender, EventArgs e)
        {
            qryKgKonten.Refresh();
            setEditMode();
        }

        private void qryKgKonten_AfterFill(object sender, EventArgs e)
        {
            if ((bool)edtFehlerhafte.EditValue)
            {
                qryKgKonten.DataTable.DefaultView.RowFilter = "BaPersonID IS NULL OR KissKontoNr IS NULL";
            }
            else
            {
                qryKgKonten.DataTable.DefaultView.RowFilter = string.Empty;
            }
            setLabelAnzahl();
        }

        private void qryKgKonten_AfterInsert(object sender, EventArgs e)
        {
            qryKgKonten["NameVorname"] = this.nameVorname;
            qryKgKonten["KontoNr"] = this.kontoNr;
            qryKgKonten["Rubrik"] = this.kontoRubrik;
            qryKgKonten["Kategorie"] = this.kontoKategorie;
            qryKgKonten["Saldo"] = this.kontoSaldo;
            qryKgKonten["manuelleZuordnung"] = 0;
            qryKgKonten["KgSparhafenSaldoImportID"] = qryKgSparhafenImport["KgSparhafenSaldoImportID"];
        }

        private void qryKgKonten_PositionChanged(object sender, EventArgs e)
        {
            if (qryKgKonten.RowModified)
            {
                qryKgKonten.Post();
            }
            setEditMode();
        }

        private void qryKgSparhafenImport_AfterInsert(object sender, EventArgs e)
        {
            qryKgSparhafenImport["ImportErfolgreich"] = false;
            qryKgSparhafenImport["UserID"] = Session.User.UserID;
        }

        private void qryKgSparhafenImport_PositionChanged(object sender, EventArgs e)
        {
            SetEditMode();
        }

        #endregion

        #region Methods

        #region Public Methods

        public override bool OnAddData()
        {
            qryKgSparhafenImport.Insert();
            return true;
        }

        public override bool OnDeleteData()
        {
            return qryKgSparhafenImport.Delete();
        }

        public override bool OnSaveData()
        {
            try
            {
                object kontoNr = edtKontoNr.EditValue;
                if (qryKgKonten.Count > 0)
                {
                    object sparhafenSaldoID = qryKgKonten["KgSparhafenSaldoID"];
                    qryKgKonten["KissKontoNr"] = kontoNr; // Durch das Setzen der Konto-Nr wird evt. der Eintrag weggefiltert.
                    // Workaround für folgendes Problem: Falls der Eintrag während dem Speichern weggefiltert wird funktioniert der Speichervorgang nicht
                    if (!qryKgKonten.DataTable.DefaultView.RowFilter.Equals(string.Empty))
                    {
                        qryKgKonten.DataTable.DefaultView.RowFilter = qryKgKonten.DataTable.DefaultView.RowFilter + string.Format(" OR KgSparhafenSaldoID = {0}", sparhafenSaldoID);
                    }
                }
                bool success = qryKgKonten.Post();
                return qryKgSparhafenImport.Post() && success; // Reihenfolge wichtig, so werden immer beide Post-Aufrufe durchgeführt
            }
            finally
            {
                // Rowfilter zurücksetzen
                setRowFilter();
            }
        }

        #endregion

        #region Private Methods

        private void SetEditMode()
        {
            qryKgKonten.Fill(qryKgSparhafenImport["KgSparhafenSaldoImportID"]);
            bool notYetImported = !DBUtil.IsEmpty(qryKgSparhafenImport["ImportErfolgreich"]) && !(bool)qryKgSparhafenImport["ImportErfolgreich"] &&
                qryKgKonten.Count == 0;
            docSaldi.CanImportDocument = notYetImported;
            docSaldi.EditMode = notYetImported ? EditModeType.Normal : EditModeType.ReadOnly;
            btnImportieren.Enabled = notYetImported;
            edtDatumSaldo.EditMode = notYetImported ? EditModeType.Normal : EditModeType.ReadOnly;
        }

        private void excelImport()
        {
            if (docSaldi.DokFormatCode != DokFormat.Excel)
            {
                qryKgSparhafenImport["ImportErfolgreich"] = false;
                qryKgSparhafenImport.Post();
                throw new Exception("Ungültiges Format (nur Excel-Dateien erlaubt).");
            }
            try
            {
                qryKgSparhafenImport["DatumImport"] = DateTime.Now;
                docSaldi.OpenDoc();
                DlgProgressLog.ShowTopMost();
                if (docSaldi.IsDocumentOpen)
                {
                    DataSet data = docSaldi.ExportExcelToDataSet();

                    DlgProgressLog.ShowTopMost();
                    qryKgKonten.CanInsert = true;
                    grdKonten.DataSource = null;
                    int currentRow = 1;
                    DlgProgressLog.AddLine(string.Empty);
                    Session.MainForm.BringToFront();
                    DlgProgressLog.ShowTopMost();
                    foreach (System.Data.DataRow row in data.Tables[0].Rows)// TODO: Test if there is a table, test if the right columns are there
                    {
                        DlgProgressLog.UpdateLastLine(KissMsg.GetMLMessage("CtlKgSparhafenSaldi", "EintragVerarbeitung", "Verarbeite Eintrag {0} von {1}", currentRow, data.Tables[0].Rows.Count));
                        nameVorname = row["ADR_NAME_VORNAME"].ToString();
                        kontoNr = row["KTO_KONTONR"].ToString();
                        kontoSaldo = row["KTO_KONTOSALDO"].ToString();
                        kontoRubrik = row["KTO_RUBRIK"].ToString();
                        kontoKategorie = row["KTO_KATEGORIE"].ToString();
                        qryKgKonten.Insert();
                        qryKgKonten.RowModified = true;
                        qryKgKonten.Post();
                        currentRow += 1;
                    }
                    qryKgKonten.CanInsert = false;
                    // Zuordnung der eindeutigen Fälle zu Kiss-Klienten
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage("CtlKgSparhafenSaldi", "Zuordnung", "Ordne importierte Einträge den Kiss-Klienten zu..."));
                    DBUtil.ExecSQLThrowingException(@"EXEC spKgSparhafenSaldo {0}",
                        qryKgSparhafenImport["KgSparhafenSaldoImportID"]);
                    qryKgSparhafenImport["ImportErfolgreich"] = true;
                    grdKonten.DataSource = qryKgKonten;
                    int zugeordnetAlles = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT COUNT(KgSparhafenSaldoID)
                        FROM KgSparhafenSaldo
                        WHERE KgSparhafenSaldoImportID = {0} AND BaPersonID IS NOT NULL AND KissKontoNr IS NOT NULL", qryKgSparhafenImport["KgSparhafenSaldoImportID"]);
                    int zugeordnetPerson = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT COUNT(KgSparhafenSaldoID)
                        FROM KgSparhafenSaldo
                        WHERE KgSparhafenSaldoImportID = {0} AND BaPersonID IS NOT NULL AND KissKontoNr IS NULL", qryKgSparhafenImport["KgSparhafenSaldoImportID"]);
                    int zugeordnetNichts = (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                        SELECT COUNT(KgSparhafenSaldoID)
                        FROM KgSparhafenSaldo
                        WHERE KgSparhafenSaldoImportID = {0} AND BaPersonID IS NULL AND KissKontoNr IS NULL", qryKgSparhafenImport["KgSparhafenSaldoImportID"]);
                    DlgProgressLog.AddLine(string.Format("Es wurden {0} Einträge vollständig zugeordnet", zugeordnetAlles));
                    DlgProgressLog.AddLine(string.Format("Bei {0} Einträgen war nur die Zuordnung der richtigen Person möglich ", zugeordnetPerson));
                    DlgProgressLog.AddLine(string.Format("bei {0} Einträgen konnte weder die Person noch das Konto zugeordnet werden.", zugeordnetNichts));
                }
            }
            catch (Exception ex)
            {
                DlgProgressLog.AddError(ex.Message);
                grdKonten.DataSource = qryKgKonten;
                qryKgKonten.Fill(qryKgSparhafenImport["KgSparhafenSaldoImportID"]);
            }
            finally
            {
                DlgProgressLog.EndProgress();
            }
            qryKgKonten.Refresh();
        }

        private void setEditMode()
        {
            if (qryKgKonten.Count > 0)
            {
                qryKontenNr.Fill(qryKgKonten["BaPersonID"]);
            }
            else
            {
                qryKontenNr.Fill(-1);
            }
            edtKontoNr.EditMode = qryKgKonten.Count == 0 || DBUtil.IsEmpty(qryKgKonten["BaPersonID"]) ? EditModeType.ReadOnly : EditModeType.Normal;
            edtKontoNr.Properties.DropDownRows = qryKgKonten.Count + 1;
        }

        private void setLabelAnzahl()
        {
            lblAnzahl.Text = "Anzahl: " + qryKgKonten.Count.ToString();
        }

        private void setRowFilter()
        {
            string rowFilter = "";
            if (edtFehlerhafte.Checked)
            {
                rowFilter = "BaPersonID IS NULL OR KissKontoNr IS NULL";
            }
            qryKgKonten.DataTable.DefaultView.RowFilter = rowFilter;
        }

        #endregion

        #endregion
    }
}