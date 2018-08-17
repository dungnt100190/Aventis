using System;
using System.Drawing;
using KiSS.DBScheme;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Basis
{
    /// <summary>
    /// Summary description for CtlHaushalt.
    /// </summary>
    public class CtlBaHaushalt : KissUserControl
    {
        #region Fields

        #region Private Fields

        private const string CLASS_NAME = "CtlBaHaushalt";

        private int _baPersonID;
        private KissModulTree _modulTree;
        private KissCheckEdit chkMieteAbgetreten;
        private DevExpress.XtraGrid.Columns.GridColumn colAlter;
        private DevExpress.XtraGrid.Columns.GridColumn colBeziehung;
        private DevExpress.XtraGrid.Columns.GridColumn colGeschlechtCode;
        private DevExpress.XtraGrid.Columns.GridColumn colImGleichenHaushalt;
        private DevExpress.XtraGrid.Columns.GridColumn colKlient;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colUnterstuetzt;
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit editRelationFemale;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit editRelationGeneric;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit editRelationMale;
        private KiSS4.Gui.KissButtonEdit editVermieter;
        private KiSS4.Gui.KissLabel edtAlter;
        private KiSS4.Gui.KissLabel edtAufenthaltsort;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissDateEdit edtDatumBis;
        private KiSS4.Gui.KissDateEdit edtDatumVon;
        private KiSS4.Gui.KissLabel edtFalltraeger;
        private KiSS4.Gui.KissLabel edtGeburtstag;
        private KiSS4.Gui.KissLabel edtGeschlecht;
        private KiSS4.Gui.KissLabel edtHeimatort;
        private KiSS4.Gui.KissCalcEdit edtKostenanteilUE;
        private KiSS4.Gui.KissCalcEdit edtMietdepot;
        private KiSS4.Gui.KissCalcEdit edtMietkosten;
        private KissCalcEdit edtMietzinsgarantie;
        private KiSS4.Gui.KissLabel edtNationalitaet;
        private KiSS4.Gui.KissCalcEdit edtNebenkosten;
        private KiSS4.Gui.KissLabel edtPerson;
        private KiSS4.Gui.KissLabel edtWohnsitz;
        private KiSS4.Gui.KissLabel edtZivilstand;
        private KiSS4.Gui.KissGrid grdRelation;
        private DevExpress.XtraGrid.Views.Grid.GridView grvRelation;
        private KissDateEdit kissDateEdit1;
        private KissLabel kissLabel1;
        private KiSS4.Gui.KissLabel lblAlter;
        private KiSS4.Gui.KissLabel lblAufenthaltsort;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblBezugspersonen;
        private KiSS4.Gui.KissLabel lblDatumBis;
        private KiSS4.Gui.KissLabel lblDatumVon;
        private KissLabel lblDepotBis;
        private KiSS4.Gui.KissLabel lblGeburtstag;
        private KiSS4.Gui.KissLabel lblGeschlecht;
        private KiSS4.Gui.KissLabel lblHeimatort;
        private KiSS4.Gui.KissLabel lblKostenanteilUE;
        private KiSS4.Gui.KissLabel lblKostenanteilUECHF;
        private KiSS4.Gui.KissLabel lblMietdepot;
        private KiSS4.Gui.KissLabel lblMietdepotCHF;
        private KissLabel lblMieteAbgetreten;
        private KiSS4.Gui.KissLabel lblMietkosten;
        private KiSS4.Gui.KissLabel lblMietkostenCHF;
        private KiSS4.Gui.KissLabel lblMietvertrag;
        private KissLabel lblMietzinsgarantie;
        private KiSS4.Gui.KissLabel lblNationalitaet;
        private KiSS4.Gui.KissLabel lblNebenkosten;
        private KiSS4.Gui.KissLabel lblNebenkostenCHF;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblVermieter;
        private KiSS4.Gui.KissLabel lblWohnsitz;
        private KiSS4.Gui.KissLabel lblZivilstand;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryFalltraeger;
        private KiSS4.DB.SqlQuery qryMietvertrag;
        private KiSS4.DB.SqlQuery qryRelation;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        #endregion

        #endregion

        #region Constructors

        public CtlBaHaushalt()
        {
            // Required for Windows Form Designer support
            InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlBaHaushalt));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            this.qryFalltraeger = new KiSS4.DB.SqlQuery();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.grdRelation = new KiSS4.Gui.KissGrid();
            this.qryRelation = new KiSS4.DB.SqlQuery();
            this.grvRelation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBeziehung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAlter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnterstuetzt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colImGleichenHaushalt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGeschlechtCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.editRelationGeneric = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.editRelationMale = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.editRelationFemale = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.editVermieter = new KiSS4.Gui.KissButtonEdit();
            this.qryMietvertrag = new KiSS4.DB.SqlQuery();
            this.lblVermieter = new KiSS4.Gui.KissLabel();
            this.lblMietkostenCHF = new KiSS4.Gui.KissLabel();
            this.edtMietkosten = new KiSS4.Gui.KissCalcEdit();
            this.lblMietkosten = new KiSS4.Gui.KissLabel();
            this.lblNebenkostenCHF = new KiSS4.Gui.KissLabel();
            this.edtNebenkosten = new KiSS4.Gui.KissCalcEdit();
            this.lblNebenkosten = new KiSS4.Gui.KissLabel();
            this.lblKostenanteilUECHF = new KiSS4.Gui.KissLabel();
            this.edtKostenanteilUE = new KiSS4.Gui.KissCalcEdit();
            this.lblKostenanteilUE = new KiSS4.Gui.KissLabel();
            this.edtDatumVon = new KiSS4.Gui.KissDateEdit();
            this.edtDatumBis = new KiSS4.Gui.KissDateEdit();
            this.lblMietdepotCHF = new KiSS4.Gui.KissLabel();
            this.edtMietdepot = new KiSS4.Gui.KissCalcEdit();
            this.lblMietdepot = new KiSS4.Gui.KissLabel();
            this.lblDatumVon = new KiSS4.Gui.KissLabel();
            this.lblDatumBis = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.lblMietvertrag = new KiSS4.Gui.KissLabel();
            this.lblBezugspersonen = new KiSS4.Gui.KissLabel();
            this.lblWohnsitz = new KiSS4.Gui.KissLabel();
            this.lblHeimatort = new KiSS4.Gui.KissLabel();
            this.lblAufenthaltsort = new KiSS4.Gui.KissLabel();
            this.lblNationalitaet = new KiSS4.Gui.KissLabel();
            this.lblAlter = new KiSS4.Gui.KissLabel();
            this.lblGeburtstag = new KiSS4.Gui.KissLabel();
            this.lblGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtWohnsitz = new KiSS4.Gui.KissLabel();
            this.edtAufenthaltsort = new KiSS4.Gui.KissLabel();
            this.edtHeimatort = new KiSS4.Gui.KissLabel();
            this.edtNationalitaet = new KiSS4.Gui.KissLabel();
            this.edtAlter = new KiSS4.Gui.KissLabel();
            this.edtGeburtstag = new KiSS4.Gui.KissLabel();
            this.edtGeschlecht = new KiSS4.Gui.KissLabel();
            this.edtZivilstand = new KiSS4.Gui.KissLabel();
            this.lblZivilstand = new KiSS4.Gui.KissLabel();
            this.edtPerson = new KiSS4.Gui.KissLabel();
            this.edtFalltraeger = new KiSS4.Gui.KissLabel();
            this.kissDateEdit1 = new KiSS4.Gui.KissDateEdit();
            this.lblDepotBis = new KiSS4.Gui.KissLabel();
            this.chkMieteAbgetreten = new KiSS4.Gui.KissCheckEdit();
            this.lblMieteAbgetreten = new KiSS4.Gui.KissLabel();
            this.kissLabel1 = new KiSS4.Gui.KissLabel();
            this.edtMietzinsgarantie = new KiSS4.Gui.KissCalcEdit();
            this.lblMietzinsgarantie = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryFalltraeger)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRelation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRelationGeneric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRelationMale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRelationFemale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVermieter.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMietvertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermieter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietkostenCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMietkosten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNebenkostenCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNebenkosten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNebenkosten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenanteilUECHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenanteilUE.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenanteilUE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietdepotCHF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMietdepot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietdepot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietvertrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezugspersonen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltsort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtstag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltsort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFalltraeger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDepotBis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMieteAbgetreten.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMieteAbgetreten)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMietzinsgarantie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietzinsgarantie)).BeginInit();
            this.SuspendLayout();
            //
            // qryFalltraeger
            //
            this.qryFalltraeger.HostControl = this;
            this.qryFalltraeger.SelectStatement = resources.GetString("qryFalltraeger.SelectStatement");
            this.qryFalltraeger.TableName = "BaPerson";
            //
            // panel1
            //
            this.panel1.Controls.Add(this.picTitel);
            this.panel1.Controls.Add(this.lblTitel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 30);
            this.panel1.TabIndex = 333;
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(5, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 293;
            this.picTitel.TabStop = false;
            //
            // lblTitel
            //
            this.lblTitel.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblTitel.Location = new System.Drawing.Point(25, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(648, 16);
            this.lblTitel.TabIndex = 292;
            this.lblTitel.Text = "Klientensystem";
            //
            // grdRelation
            //
            this.grdRelation.DataSource = this.qryRelation;
            //
            //
            //
            this.grdRelation.EmbeddedNavigator.Name = "";
            this.grdRelation.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdRelation.Location = new System.Drawing.Point(5, 195);
            this.grdRelation.MainView = this.grvRelation;
            this.grdRelation.Name = "grdRelation";
            this.grdRelation.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.editRelationGeneric,
            this.editRelationMale,
            this.editRelationFemale});
            this.grdRelation.Size = new System.Drawing.Size(700, 172);
            this.grdRelation.TabIndex = 334;
            this.grdRelation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvRelation});
            //
            // qryRelation
            //
            this.qryRelation.CanUpdate = true;
            this.qryRelation.HostControl = this;
            this.qryRelation.SelectStatement = resources.GetString("qryRelation.SelectStatement");
            this.qryRelation.TableName = "BaPerson_Relation";
            this.qryRelation.BeforePost += new System.EventHandler(this.qryRelation_BeforePost);
            //
            // grvRelation
            //
            this.grvRelation.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvRelation.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.Empty.Options.UseBackColor = true;
            this.grvRelation.Appearance.Empty.Options.UseFont = true;
            this.grvRelation.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvRelation.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvRelation.Appearance.EvenRow.Options.UseFont = true;
            this.grvRelation.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.grvRelation.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.grvRelation.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvRelation.Appearance.FocusedCell.Options.UseFont = true;
            this.grvRelation.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvRelation.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvRelation.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.grvRelation.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvRelation.Appearance.FocusedRow.Options.UseFont = true;
            this.grvRelation.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvRelation.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRelation.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvRelation.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvRelation.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRelation.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRelation.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvRelation.Appearance.GroupRow.Options.UseFont = true;
            this.grvRelation.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvRelation.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvRelation.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvRelation.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvRelation.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvRelation.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvRelation.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvRelation.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvRelation.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvRelation.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvRelation.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvRelation.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvRelation.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.grvRelation.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvRelation.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvRelation.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.OddRow.Options.UseBackColor = true;
            this.grvRelation.Appearance.OddRow.Options.UseFont = true;
            this.grvRelation.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.grvRelation.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.Row.Options.UseBackColor = true;
            this.grvRelation.Appearance.Row.Options.UseFont = true;
            this.grvRelation.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvRelation.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvRelation.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvRelation.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvRelation.Appearance.SelectedRow.Options.UseFont = true;
            this.grvRelation.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvRelation.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.grvRelation.Appearance.VertLine.Options.UseBackColor = true;
            this.grvRelation.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvRelation.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colBeziehung,
            this.colAlter,
            this.colUnterstuetzt,
            this.colImGleichenHaushalt,
            this.colKlient,
            this.colGeschlechtCode});
            this.grvRelation.GridControl = this.grdRelation;
            this.grvRelation.Name = "grvRelation";
            this.grvRelation.OptionsCustomization.AllowFilter = false;
            this.grvRelation.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvRelation.OptionsNavigation.AutoFocusNewRow = true;
            this.grvRelation.OptionsView.ColumnAutoWidth = false;
            this.grvRelation.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvRelation.OptionsView.ShowGroupPanel = false;
            this.grvRelation.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEdit);
            //
            // colName
            //
            this.colName.Caption = "Name";
            this.colName.FieldName = "Person";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 203;
            //
            // colBeziehung
            //
            this.colBeziehung.Caption = "Beziehung";
            this.colBeziehung.FieldName = "RelationID";
            this.colBeziehung.Name = "colBeziehung";
            this.colBeziehung.Visible = true;
            this.colBeziehung.VisibleIndex = 1;
            this.colBeziehung.Width = 188;
            //
            // colAlter
            //
            this.colAlter.AppearanceCell.Options.UseTextOptions = true;
            this.colAlter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colAlter.Caption = "Alter";
            this.colAlter.FieldName = "Age";
            this.colAlter.Name = "colAlter";
            this.colAlter.OptionsColumn.AllowEdit = false;
            this.colAlter.OptionsColumn.ReadOnly = true;
            this.colAlter.Visible = true;
            this.colAlter.VisibleIndex = 2;
            this.colAlter.Width = 46;
            //
            // colUnterstuetzt
            //
            this.colUnterstuetzt.Caption = "Unterstützt";
            this.colUnterstuetzt.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colUnterstuetzt.FieldName = "Unterstuetzt";
            this.colUnterstuetzt.Name = "colUnterstuetzt";
            this.colUnterstuetzt.Visible = true;
            this.colUnterstuetzt.VisibleIndex = 3;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
            this.repositoryItemCheckEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repositoryItemCheckEdit1_EditValueChanging);
            //
            // colImGleichenHaushalt
            //
            this.colImGleichenHaushalt.Caption = "gl. Haushalt";
            this.colImGleichenHaushalt.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colImGleichenHaushalt.FieldName = "GlHaushalt";
            this.colImGleichenHaushalt.Name = "colImGleichenHaushalt";
            this.colImGleichenHaushalt.Visible = true;
            this.colImGleichenHaushalt.VisibleIndex = 4;
            this.colImGleichenHaushalt.Width = 76;
            //
            // colKlient
            //
            this.colKlient.Caption = "KlientIn";
            this.colKlient.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colKlient.FieldName = "Klient";
            this.colKlient.Name = "colKlient";
            this.colKlient.OptionsColumn.AllowEdit = false;
            this.colKlient.OptionsColumn.ReadOnly = true;
            this.colKlient.Visible = true;
            this.colKlient.VisibleIndex = 5;
            this.colKlient.Width = 72;
            //
            // colGeschlechtCode
            //
            this.colGeschlechtCode.Caption = "gridColumn1";
            this.colGeschlechtCode.FieldName = "GeschlechtCode";
            this.colGeschlechtCode.Name = "colGeschlechtCode";
            //
            // editRelationGeneric
            //
            this.editRelationGeneric.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editRelationGeneric.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editRelationGeneric.AppearanceDropDown.Options.UseBackColor = true;
            this.editRelationGeneric.AppearanceDropDown.Options.UseFont = true;
            this.editRelationGeneric.AutoHeight = false;
            this.editRelationGeneric.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.editRelationGeneric.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.editRelationGeneric.DisplayMember = "Text";
            this.editRelationGeneric.Name = "editRelationGeneric";
            this.editRelationGeneric.NullText = "";
            this.editRelationGeneric.ShowFooter = false;
            this.editRelationGeneric.ShowHeader = false;
            this.editRelationGeneric.ValueMember = "Code";
            //
            // editRelationMale
            //
            this.editRelationMale.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editRelationMale.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editRelationMale.AppearanceDropDown.Options.UseBackColor = true;
            this.editRelationMale.AppearanceDropDown.Options.UseFont = true;
            this.editRelationMale.AutoHeight = false;
            this.editRelationMale.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.editRelationMale.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.editRelationMale.DisplayMember = "Text";
            this.editRelationMale.Name = "editRelationMale";
            this.editRelationMale.NullText = "";
            this.editRelationMale.ShowFooter = false;
            this.editRelationMale.ShowHeader = false;
            this.editRelationMale.ValueMember = "Code";
            //
            // editRelationFemale
            //
            this.editRelationFemale.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.editRelationFemale.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.editRelationFemale.AppearanceDropDown.Options.UseBackColor = true;
            this.editRelationFemale.AppearanceDropDown.Options.UseFont = true;
            this.editRelationFemale.AutoHeight = false;
            this.editRelationFemale.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.editRelationFemale.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.editRelationFemale.DisplayMember = "Text";
            this.editRelationFemale.Name = "editRelationFemale";
            this.editRelationFemale.NullText = "";
            this.editRelationFemale.ShowFooter = false;
            this.editRelationFemale.ShowHeader = false;
            this.editRelationFemale.ValueMember = "Code";
            //
            // editVermieter
            //
            this.editVermieter.DataMember = "Vermieter";
            this.editVermieter.DataSource = this.qryMietvertrag;
            this.editVermieter.Location = new System.Drawing.Point(75, 413);
            this.editVermieter.Name = "editVermieter";
            this.editVermieter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.editVermieter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.editVermieter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.editVermieter.Properties.Appearance.Options.UseBackColor = true;
            this.editVermieter.Properties.Appearance.Options.UseBorderColor = true;
            this.editVermieter.Properties.Appearance.Options.UseFont = true;
            this.editVermieter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.editVermieter.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.editVermieter.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.editVermieter.SearchStringWhitelist = new string[] {
        ".",
        "*",
        "%"};
            this.editVermieter.Size = new System.Drawing.Size(395, 24);
            this.editVermieter.TabIndex = 447;
            this.editVermieter.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.editVermieter_UserModifiedFld);
            //
            // qryMietvertrag
            //
            this.qryMietvertrag.CanUpdate = true;
            this.qryMietvertrag.HostControl = this;
            this.qryMietvertrag.SelectStatement = resources.GetString("qryMietvertrag.SelectStatement");
            this.qryMietvertrag.TableName = "BaMietvertrag";
            this.qryMietvertrag.AfterInsert += new System.EventHandler(this.qryMietvertrag_AfterInsert);
            //
            // lblVermieter
            //
            this.lblVermieter.ForeColor = System.Drawing.Color.Black;
            this.lblVermieter.Location = new System.Drawing.Point(5, 413);
            this.lblVermieter.Name = "lblVermieter";
            this.lblVermieter.Size = new System.Drawing.Size(64, 24);
            this.lblVermieter.TabIndex = 448;
            this.lblVermieter.Text = "Vermieter";
            //
            // lblMietkostenCHF
            //
            this.lblMietkostenCHF.ForeColor = System.Drawing.Color.Black;
            this.lblMietkostenCHF.Location = new System.Drawing.Point(681, 383);
            this.lblMietkostenCHF.Name = "lblMietkostenCHF";
            this.lblMietkostenCHF.Size = new System.Drawing.Size(30, 24);
            this.lblMietkostenCHF.TabIndex = 492;
            this.lblMietkostenCHF.Text = "CHF";
            //
            // edtMietkosten
            //
            this.edtMietkosten.DataMember = "Mietkosten";
            this.edtMietkosten.DataSource = this.qryMietvertrag;
            this.edtMietkosten.Location = new System.Drawing.Point(586, 383);
            this.edtMietkosten.Name = "edtMietkosten";
            this.edtMietkosten.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMietkosten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMietkosten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMietkosten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMietkosten.Properties.Appearance.Options.UseBackColor = true;
            this.edtMietkosten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMietkosten.Properties.Appearance.Options.UseFont = true;
            this.edtMietkosten.Properties.Appearance.Options.UseTextOptions = true;
            this.edtMietkosten.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtMietkosten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMietkosten.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMietkosten.Properties.DisplayFormat.FormatString = "N2";
            this.edtMietkosten.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMietkosten.Properties.EditFormat.FormatString = "N2";
            this.edtMietkosten.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMietkosten.Size = new System.Drawing.Size(90, 24);
            this.edtMietkosten.TabIndex = 490;
            //
            // lblMietkosten
            //
            this.lblMietkosten.ForeColor = System.Drawing.Color.Black;
            this.lblMietkosten.Location = new System.Drawing.Point(486, 383);
            this.lblMietkosten.Name = "lblMietkosten";
            this.lblMietkosten.Size = new System.Drawing.Size(102, 24);
            this.lblMietkosten.TabIndex = 491;
            this.lblMietkosten.Text = "Mietkosten netto";
            //
            // lblNebenkostenCHF
            //
            this.lblNebenkostenCHF.ForeColor = System.Drawing.Color.Black;
            this.lblNebenkostenCHF.Location = new System.Drawing.Point(681, 408);
            this.lblNebenkostenCHF.Name = "lblNebenkostenCHF";
            this.lblNebenkostenCHF.Size = new System.Drawing.Size(30, 24);
            this.lblNebenkostenCHF.TabIndex = 495;
            this.lblNebenkostenCHF.Text = "CHF";
            //
            // edtNebenkosten
            //
            this.edtNebenkosten.DataMember = "Nebenkosten";
            this.edtNebenkosten.DataSource = this.qryMietvertrag;
            this.edtNebenkosten.Location = new System.Drawing.Point(586, 408);
            this.edtNebenkosten.Name = "edtNebenkosten";
            this.edtNebenkosten.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtNebenkosten.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtNebenkosten.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtNebenkosten.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtNebenkosten.Properties.Appearance.Options.UseBackColor = true;
            this.edtNebenkosten.Properties.Appearance.Options.UseBorderColor = true;
            this.edtNebenkosten.Properties.Appearance.Options.UseFont = true;
            this.edtNebenkosten.Properties.Appearance.Options.UseTextOptions = true;
            this.edtNebenkosten.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtNebenkosten.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtNebenkosten.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtNebenkosten.Properties.DisplayFormat.FormatString = "N2";
            this.edtNebenkosten.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNebenkosten.Properties.EditFormat.FormatString = "N2";
            this.edtNebenkosten.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtNebenkosten.Size = new System.Drawing.Size(90, 24);
            this.edtNebenkosten.TabIndex = 493;
            //
            // lblNebenkosten
            //
            this.lblNebenkosten.ForeColor = System.Drawing.Color.Black;
            this.lblNebenkosten.Location = new System.Drawing.Point(486, 408);
            this.lblNebenkosten.Name = "lblNebenkosten";
            this.lblNebenkosten.Size = new System.Drawing.Size(102, 24);
            this.lblNebenkosten.TabIndex = 494;
            this.lblNebenkosten.Text = "Nebenkosten";
            //
            // lblKostenanteilUECHF
            //
            this.lblKostenanteilUECHF.ForeColor = System.Drawing.Color.Black;
            this.lblKostenanteilUECHF.Location = new System.Drawing.Point(681, 433);
            this.lblKostenanteilUECHF.Name = "lblKostenanteilUECHF";
            this.lblKostenanteilUECHF.Size = new System.Drawing.Size(30, 24);
            this.lblKostenanteilUECHF.TabIndex = 498;
            this.lblKostenanteilUECHF.Text = "CHF";
            //
            // edtKostenanteilUE
            //
            this.edtKostenanteilUE.DataMember = "KostenanteilUE";
            this.edtKostenanteilUE.DataSource = this.qryMietvertrag;
            this.edtKostenanteilUE.Location = new System.Drawing.Point(586, 433);
            this.edtKostenanteilUE.Name = "edtKostenanteilUE";
            this.edtKostenanteilUE.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtKostenanteilUE.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKostenanteilUE.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenanteilUE.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenanteilUE.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenanteilUE.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenanteilUE.Properties.Appearance.Options.UseFont = true;
            this.edtKostenanteilUE.Properties.Appearance.Options.UseTextOptions = true;
            this.edtKostenanteilUE.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtKostenanteilUE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKostenanteilUE.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenanteilUE.Properties.DisplayFormat.FormatString = "N2";
            this.edtKostenanteilUE.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKostenanteilUE.Properties.EditFormat.FormatString = "N2";
            this.edtKostenanteilUE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtKostenanteilUE.Size = new System.Drawing.Size(90, 24);
            this.edtKostenanteilUE.TabIndex = 496;
            //
            // lblKostenanteilUE
            //
            this.lblKostenanteilUE.ForeColor = System.Drawing.Color.Black;
            this.lblKostenanteilUE.Location = new System.Drawing.Point(486, 433);
            this.lblKostenanteilUE.Name = "lblKostenanteilUE";
            this.lblKostenanteilUE.Size = new System.Drawing.Size(102, 24);
            this.lblKostenanteilUE.TabIndex = 497;
            this.lblKostenanteilUE.Text = "Kostenanteil UE";
            //
            // edtDatumVon
            //
            this.edtDatumVon.DataMember = "DatumVon";
            this.edtDatumVon.DataSource = this.qryMietvertrag;
            this.edtDatumVon.EditValue = null;
            this.edtDatumVon.Location = new System.Drawing.Point(586, 537);
            this.edtDatumVon.Name = "edtDatumVon";
            this.edtDatumVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumVon.Properties.Appearance.Options.UseFont = true;
            this.edtDatumVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtDatumVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtDatumVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumVon.Properties.ShowToday = false;
            this.edtDatumVon.Size = new System.Drawing.Size(90, 24);
            this.edtDatumVon.TabIndex = 499;
            //
            // edtDatumBis
            //
            this.edtDatumBis.DataMember = "DatumBis";
            this.edtDatumBis.DataSource = this.qryMietvertrag;
            this.edtDatumBis.EditValue = null;
            this.edtDatumBis.Location = new System.Drawing.Point(586, 563);
            this.edtDatumBis.Name = "edtDatumBis";
            this.edtDatumBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDatumBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtDatumBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDatumBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDatumBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDatumBis.Properties.Appearance.Options.UseFont = true;
            this.edtDatumBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtDatumBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtDatumBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtDatumBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDatumBis.Properties.ShowToday = false;
            this.edtDatumBis.Size = new System.Drawing.Size(90, 24);
            this.edtDatumBis.TabIndex = 500;
            //
            // lblMietdepotCHF
            //
            this.lblMietdepotCHF.ForeColor = System.Drawing.Color.Black;
            this.lblMietdepotCHF.Location = new System.Drawing.Point(681, 459);
            this.lblMietdepotCHF.Name = "lblMietdepotCHF";
            this.lblMietdepotCHF.Size = new System.Drawing.Size(30, 24);
            this.lblMietdepotCHF.TabIndex = 503;
            this.lblMietdepotCHF.Text = "CHF";
            //
            // edtMietdepot
            //
            this.edtMietdepot.DataMember = "Mietdepot";
            this.edtMietdepot.DataSource = this.qryMietvertrag;
            this.edtMietdepot.Location = new System.Drawing.Point(586, 459);
            this.edtMietdepot.Name = "edtMietdepot";
            this.edtMietdepot.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMietdepot.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMietdepot.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMietdepot.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMietdepot.Properties.Appearance.Options.UseBackColor = true;
            this.edtMietdepot.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMietdepot.Properties.Appearance.Options.UseFont = true;
            this.edtMietdepot.Properties.Appearance.Options.UseTextOptions = true;
            this.edtMietdepot.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtMietdepot.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMietdepot.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMietdepot.Properties.DisplayFormat.FormatString = "N2";
            this.edtMietdepot.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMietdepot.Properties.EditFormat.FormatString = "N2";
            this.edtMietdepot.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMietdepot.Size = new System.Drawing.Size(90, 24);
            this.edtMietdepot.TabIndex = 501;
            //
            // lblMietdepot
            //
            this.lblMietdepot.ForeColor = System.Drawing.Color.Black;
            this.lblMietdepot.Location = new System.Drawing.Point(486, 459);
            this.lblMietdepot.Name = "lblMietdepot";
            this.lblMietdepot.Size = new System.Drawing.Size(102, 24);
            this.lblMietdepot.TabIndex = 502;
            this.lblMietdepot.Text = "Mietdepot";
            //
            // lblDatumVon
            //
            this.lblDatumVon.ForeColor = System.Drawing.Color.Black;
            this.lblDatumVon.Location = new System.Drawing.Point(486, 537);
            this.lblDatumVon.Name = "lblDatumVon";
            this.lblDatumVon.Size = new System.Drawing.Size(102, 24);
            this.lblDatumVon.TabIndex = 504;
            this.lblDatumVon.Text = "Miete ab";
            //
            // lblDatumBis
            //
            this.lblDatumBis.ForeColor = System.Drawing.Color.Black;
            this.lblDatumBis.Location = new System.Drawing.Point(486, 563);
            this.lblDatumBis.Name = "lblDatumBis";
            this.lblDatumBis.Size = new System.Drawing.Size(102, 24);
            this.lblDatumBis.TabIndex = 505;
            this.lblDatumBis.Text = "bis";
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryMietvertrag;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkung.Location = new System.Drawing.Point(75, 448);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(395, 154);
            this.edtBemerkung.TabIndex = 506;
            //
            // lblBemerkung
            //
            this.lblBemerkung.ForeColor = System.Drawing.Color.Black;
            this.lblBemerkung.Location = new System.Drawing.Point(5, 448);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(70, 24);
            this.lblBemerkung.TabIndex = 507;
            this.lblBemerkung.Text = "Bemerkung";
            //
            // lblMietvertrag
            //
            this.lblMietvertrag.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblMietvertrag.Location = new System.Drawing.Point(5, 388);
            this.lblMietvertrag.Name = "lblMietvertrag";
            this.lblMietvertrag.Size = new System.Drawing.Size(206, 16);
            this.lblMietvertrag.TabIndex = 508;
            this.lblMietvertrag.Text = "Mietvertrag";
            //
            // lblBezugspersonen
            //
            this.lblBezugspersonen.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblBezugspersonen.Location = new System.Drawing.Point(5, 175);
            this.lblBezugspersonen.Name = "lblBezugspersonen";
            this.lblBezugspersonen.Size = new System.Drawing.Size(135, 16);
            this.lblBezugspersonen.TabIndex = 509;
            this.lblBezugspersonen.Text = "Bezugspersonen";
            //
            // lblWohnsitz
            //
            this.lblWohnsitz.ForeColor = System.Drawing.Color.Black;
            this.lblWohnsitz.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblWohnsitz.Location = new System.Drawing.Point(5, 65);
            this.lblWohnsitz.Name = "lblWohnsitz";
            this.lblWohnsitz.Size = new System.Drawing.Size(90, 16);
            this.lblWohnsitz.TabIndex = 511;
            this.lblWohnsitz.Text = "Wohnsitz (zivilr.)";
            //
            // lblHeimatort
            //
            this.lblHeimatort.ForeColor = System.Drawing.Color.Black;
            this.lblHeimatort.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblHeimatort.Location = new System.Drawing.Point(5, 125);
            this.lblHeimatort.Name = "lblHeimatort";
            this.lblHeimatort.Size = new System.Drawing.Size(89, 16);
            this.lblHeimatort.TabIndex = 513;
            this.lblHeimatort.Text = "Heimatort";
            //
            // lblAufenthaltsort
            //
            this.lblAufenthaltsort.ForeColor = System.Drawing.Color.Black;
            this.lblAufenthaltsort.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAufenthaltsort.Location = new System.Drawing.Point(5, 85);
            this.lblAufenthaltsort.Name = "lblAufenthaltsort";
            this.lblAufenthaltsort.Size = new System.Drawing.Size(89, 16);
            this.lblAufenthaltsort.TabIndex = 514;
            this.lblAufenthaltsort.Text = "Aufenthaltsort";
            //
            // lblNationalitaet
            //
            this.lblNationalitaet.ForeColor = System.Drawing.Color.Black;
            this.lblNationalitaet.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblNationalitaet.Location = new System.Drawing.Point(5, 145);
            this.lblNationalitaet.Name = "lblNationalitaet";
            this.lblNationalitaet.Size = new System.Drawing.Size(89, 16);
            this.lblNationalitaet.TabIndex = 515;
            this.lblNationalitaet.Text = "Nationalität";
            //
            // lblAlter
            //
            this.lblAlter.ForeColor = System.Drawing.Color.Black;
            this.lblAlter.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblAlter.Location = new System.Drawing.Point(489, 65);
            this.lblAlter.Name = "lblAlter";
            this.lblAlter.Size = new System.Drawing.Size(70, 16);
            this.lblAlter.TabIndex = 516;
            this.lblAlter.Text = "Alter";
            //
            // lblGeburtstag
            //
            this.lblGeburtstag.ForeColor = System.Drawing.Color.Black;
            this.lblGeburtstag.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblGeburtstag.Location = new System.Drawing.Point(489, 85);
            this.lblGeburtstag.Name = "lblGeburtstag";
            this.lblGeburtstag.Size = new System.Drawing.Size(70, 16);
            this.lblGeburtstag.TabIndex = 517;
            this.lblGeburtstag.Text = "Geburtstag";
            //
            // lblGeschlecht
            //
            this.lblGeschlecht.ForeColor = System.Drawing.Color.Black;
            this.lblGeschlecht.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblGeschlecht.Location = new System.Drawing.Point(489, 105);
            this.lblGeschlecht.Name = "lblGeschlecht";
            this.lblGeschlecht.Size = new System.Drawing.Size(70, 16);
            this.lblGeschlecht.TabIndex = 518;
            this.lblGeschlecht.Text = "Geschlecht";
            //
            // edtWohnsitz
            //
            this.edtWohnsitz.DataMember = "Wohnsitz";
            this.edtWohnsitz.DataSource = this.qryFalltraeger;
            this.edtWohnsitz.ForeColor = System.Drawing.Color.Black;
            this.edtWohnsitz.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtWohnsitz.Location = new System.Drawing.Point(100, 65);
            this.edtWohnsitz.Name = "edtWohnsitz";
            this.edtWohnsitz.Size = new System.Drawing.Size(375, 16);
            this.edtWohnsitz.TabIndex = 519;
            //
            // edtAufenthaltsort
            //
            this.edtAufenthaltsort.DataMember = "Aufenthaltsort";
            this.edtAufenthaltsort.DataSource = this.qryFalltraeger;
            this.edtAufenthaltsort.ForeColor = System.Drawing.Color.Black;
            this.edtAufenthaltsort.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtAufenthaltsort.Location = new System.Drawing.Point(100, 85);
            this.edtAufenthaltsort.Name = "edtAufenthaltsort";
            this.edtAufenthaltsort.Size = new System.Drawing.Size(375, 35);
            this.edtAufenthaltsort.TabIndex = 520;
            //
            // edtHeimatort
            //
            this.edtHeimatort.DataMember = "Heimatort";
            this.edtHeimatort.DataSource = this.qryFalltraeger;
            this.edtHeimatort.ForeColor = System.Drawing.Color.Black;
            this.edtHeimatort.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtHeimatort.Location = new System.Drawing.Point(100, 125);
            this.edtHeimatort.Name = "edtHeimatort";
            this.edtHeimatort.Size = new System.Drawing.Size(375, 16);
            this.edtHeimatort.TabIndex = 521;
            //
            // edtNationalitaet
            //
            this.edtNationalitaet.DataMember = "Nationalitaet";
            this.edtNationalitaet.DataSource = this.qryFalltraeger;
            this.edtNationalitaet.ForeColor = System.Drawing.Color.Black;
            this.edtNationalitaet.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtNationalitaet.Location = new System.Drawing.Point(100, 145);
            this.edtNationalitaet.Name = "edtNationalitaet";
            this.edtNationalitaet.Size = new System.Drawing.Size(375, 16);
            this.edtNationalitaet.TabIndex = 522;
            //
            // edtAlter
            //
            this.edtAlter.DataMember = "Alter";
            this.edtAlter.DataSource = this.qryFalltraeger;
            this.edtAlter.ForeColor = System.Drawing.Color.Black;
            this.edtAlter.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtAlter.Location = new System.Drawing.Point(564, 65);
            this.edtAlter.Name = "edtAlter";
            this.edtAlter.Size = new System.Drawing.Size(106, 16);
            this.edtAlter.TabIndex = 523;
            //
            // edtGeburtstag
            //
            this.edtGeburtstag.DataMember = "Geburtstag";
            this.edtGeburtstag.DataSource = this.qryFalltraeger;
            this.edtGeburtstag.ForeColor = System.Drawing.Color.Black;
            this.edtGeburtstag.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtGeburtstag.Location = new System.Drawing.Point(564, 85);
            this.edtGeburtstag.Name = "edtGeburtstag";
            this.edtGeburtstag.Size = new System.Drawing.Size(106, 16);
            this.edtGeburtstag.TabIndex = 524;
            //
            // edtGeschlecht
            //
            this.edtGeschlecht.DataMember = "Geschlecht";
            this.edtGeschlecht.DataSource = this.qryFalltraeger;
            this.edtGeschlecht.ForeColor = System.Drawing.Color.Black;
            this.edtGeschlecht.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtGeschlecht.Location = new System.Drawing.Point(564, 105);
            this.edtGeschlecht.Name = "edtGeschlecht";
            this.edtGeschlecht.Size = new System.Drawing.Size(106, 16);
            this.edtGeschlecht.TabIndex = 525;
            //
            // edtZivilstand
            //
            this.edtZivilstand.DataMember = "Zivilstand";
            this.edtZivilstand.DataSource = this.qryFalltraeger;
            this.edtZivilstand.ForeColor = System.Drawing.Color.Black;
            this.edtZivilstand.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtZivilstand.Location = new System.Drawing.Point(564, 125);
            this.edtZivilstand.Name = "edtZivilstand";
            this.edtZivilstand.Size = new System.Drawing.Size(106, 16);
            this.edtZivilstand.TabIndex = 527;
            //
            // lblZivilstand
            //
            this.lblZivilstand.ForeColor = System.Drawing.Color.Black;
            this.lblZivilstand.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.lblZivilstand.Location = new System.Drawing.Point(489, 125);
            this.lblZivilstand.Name = "lblZivilstand";
            this.lblZivilstand.Size = new System.Drawing.Size(70, 16);
            this.lblZivilstand.TabIndex = 526;
            this.lblZivilstand.Text = "Zivilstand";
            //
            // edtPerson
            //
            this.edtPerson.DataMember = "Person";
            this.edtPerson.DataSource = this.qryFalltraeger;
            this.edtPerson.ForeColor = System.Drawing.Color.Black;
            this.edtPerson.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.edtPerson.Location = new System.Drawing.Point(100, 45);
            this.edtPerson.Name = "edtPerson";
            this.edtPerson.Size = new System.Drawing.Size(375, 16);
            this.edtPerson.TabIndex = 529;
            //
            // edtFalltraeger
            //
            this.edtFalltraeger.DataMember = "Falltraeger";
            this.edtFalltraeger.DataSource = this.qryFalltraeger;
            this.edtFalltraeger.ForeColor = System.Drawing.Color.Black;
            this.edtFalltraeger.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
            this.edtFalltraeger.Location = new System.Drawing.Point(5, 45);
            this.edtFalltraeger.Name = "edtFalltraeger";
            this.edtFalltraeger.Size = new System.Drawing.Size(90, 16);
            this.edtFalltraeger.TabIndex = 528;
            //
            // kissDateEdit1
            //
            this.kissDateEdit1.DataMember = "GarantieBis";
            this.kissDateEdit1.DataSource = this.qryMietvertrag;
            this.kissDateEdit1.EditValue = null;
            this.kissDateEdit1.Location = new System.Drawing.Point(586, 511);
            this.kissDateEdit1.Name = "kissDateEdit1";
            this.kissDateEdit1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.kissDateEdit1.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.kissDateEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.kissDateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissDateEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseBorderColor = true;
            this.kissDateEdit1.Properties.Appearance.Options.UseFont = true;
            this.kissDateEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.kissDateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("kissDateEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.kissDateEdit1.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.kissDateEdit1.Properties.ShowToday = false;
            this.kissDateEdit1.Size = new System.Drawing.Size(90, 24);
            this.kissDateEdit1.TabIndex = 537;
            //
            // lblDepotBis
            //
            this.lblDepotBis.Location = new System.Drawing.Point(486, 511);
            this.lblDepotBis.Name = "lblDepotBis";
            this.lblDepotBis.Size = new System.Drawing.Size(102, 24);
            this.lblDepotBis.TabIndex = 536;
            this.lblDepotBis.Text = "Garantie gültig bis";
            this.lblDepotBis.UseCompatibleTextRendering = true;
            //
            // chkMieteAbgetreten
            //
            this.chkMieteAbgetreten.DataMember = "MieteAbgetreten";
            this.chkMieteAbgetreten.DataSource = this.qryMietvertrag;
            this.chkMieteAbgetreten.Location = new System.Drawing.Point(586, 593);
            this.chkMieteAbgetreten.Name = "chkMieteAbgetreten";
            this.chkMieteAbgetreten.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.chkMieteAbgetreten.Properties.Appearance.Options.UseBackColor = true;
            this.chkMieteAbgetreten.Properties.Caption = "";
            this.chkMieteAbgetreten.Size = new System.Drawing.Size(75, 19);
            this.chkMieteAbgetreten.TabIndex = 535;
            //
            // lblMieteAbgetreten
            //
            this.lblMieteAbgetreten.Location = new System.Drawing.Point(486, 590);
            this.lblMieteAbgetreten.Name = "lblMieteAbgetreten";
            this.lblMieteAbgetreten.Size = new System.Drawing.Size(102, 24);
            this.lblMieteAbgetreten.TabIndex = 534;
            this.lblMieteAbgetreten.Text = "Miete abgetreten";
            this.lblMieteAbgetreten.UseCompatibleTextRendering = true;
            //
            // kissLabel1
            //
            this.kissLabel1.ForeColor = System.Drawing.Color.Black;
            this.kissLabel1.Location = new System.Drawing.Point(681, 485);
            this.kissLabel1.Name = "kissLabel1";
            this.kissLabel1.Size = new System.Drawing.Size(30, 24);
            this.kissLabel1.TabIndex = 540;
            this.kissLabel1.Text = "CHF";
            //
            // edtMietzinsgarantie
            //
            this.edtMietzinsgarantie.DataMember = "Mietzinsgarantie";
            this.edtMietzinsgarantie.DataSource = this.qryMietvertrag;
            this.edtMietzinsgarantie.Location = new System.Drawing.Point(586, 485);
            this.edtMietzinsgarantie.Name = "edtMietzinsgarantie";
            this.edtMietzinsgarantie.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtMietzinsgarantie.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtMietzinsgarantie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMietzinsgarantie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMietzinsgarantie.Properties.Appearance.Options.UseBackColor = true;
            this.edtMietzinsgarantie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMietzinsgarantie.Properties.Appearance.Options.UseFont = true;
            this.edtMietzinsgarantie.Properties.Appearance.Options.UseTextOptions = true;
            this.edtMietzinsgarantie.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.edtMietzinsgarantie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMietzinsgarantie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtMietzinsgarantie.Properties.DisplayFormat.FormatString = "N2";
            this.edtMietzinsgarantie.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMietzinsgarantie.Properties.EditFormat.FormatString = "N2";
            this.edtMietzinsgarantie.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtMietzinsgarantie.Size = new System.Drawing.Size(90, 24);
            this.edtMietzinsgarantie.TabIndex = 538;
            //
            // lblMietzinsgarantie
            //
            this.lblMietzinsgarantie.ForeColor = System.Drawing.Color.Black;
            this.lblMietzinsgarantie.Location = new System.Drawing.Point(486, 485);
            this.lblMietzinsgarantie.Name = "lblMietzinsgarantie";
            this.lblMietzinsgarantie.Size = new System.Drawing.Size(102, 24);
            this.lblMietzinsgarantie.TabIndex = 539;
            this.lblMietzinsgarantie.Text = "Mietzinsgarantie";
            //
            // CtlBaHaushalt
            //
            this.Controls.Add(this.edtDatumBis);
            this.Controls.Add(this.edtDatumVon);
            this.Controls.Add(this.kissLabel1);
            this.Controls.Add(this.edtMietzinsgarantie);
            this.Controls.Add(this.lblMietzinsgarantie);
            this.Controls.Add(this.kissDateEdit1);
            this.Controls.Add(this.lblDepotBis);
            this.Controls.Add(this.chkMieteAbgetreten);
            this.Controls.Add(this.lblMieteAbgetreten);
            this.Controls.Add(this.edtPerson);
            this.Controls.Add(this.edtFalltraeger);
            this.Controls.Add(this.edtZivilstand);
            this.Controls.Add(this.lblZivilstand);
            this.Controls.Add(this.edtGeschlecht);
            this.Controls.Add(this.edtGeburtstag);
            this.Controls.Add(this.edtAlter);
            this.Controls.Add(this.edtNationalitaet);
            this.Controls.Add(this.edtHeimatort);
            this.Controls.Add(this.edtAufenthaltsort);
            this.Controls.Add(this.edtWohnsitz);
            this.Controls.Add(this.lblGeschlecht);
            this.Controls.Add(this.lblGeburtstag);
            this.Controls.Add(this.lblAlter);
            this.Controls.Add(this.lblNationalitaet);
            this.Controls.Add(this.lblAufenthaltsort);
            this.Controls.Add(this.lblHeimatort);
            this.Controls.Add(this.lblWohnsitz);
            this.Controls.Add(this.lblBezugspersonen);
            this.Controls.Add(this.lblMietvertrag);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.lblDatumBis);
            this.Controls.Add(this.lblDatumVon);
            this.Controls.Add(this.lblMietdepotCHF);
            this.Controls.Add(this.edtMietdepot);
            this.Controls.Add(this.lblMietdepot);
            this.Controls.Add(this.lblKostenanteilUECHF);
            this.Controls.Add(this.edtKostenanteilUE);
            this.Controls.Add(this.lblKostenanteilUE);
            this.Controls.Add(this.lblNebenkostenCHF);
            this.Controls.Add(this.edtNebenkosten);
            this.Controls.Add(this.lblNebenkosten);
            this.Controls.Add(this.lblMietkostenCHF);
            this.Controls.Add(this.edtMietkosten);
            this.Controls.Add(this.lblMietkosten);
            this.Controls.Add(this.editVermieter);
            this.Controls.Add(this.lblVermieter);
            this.Controls.Add(this.grdRelation);
            this.Controls.Add(this.panel1);
            this.Name = "CtlBaHaushalt";
            this.Size = new System.Drawing.Size(719, 622);
            ((System.ComponentModel.ISupportInitialize)(this.qryFalltraeger)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvRelation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRelationGeneric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRelationMale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editRelationFemale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editVermieter.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMietvertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVermieter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietkostenCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMietkosten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNebenkostenCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNebenkosten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNebenkosten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenanteilUECHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenanteilUE.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenanteilUE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDatumBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietdepotCHF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMietdepot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietdepot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumVon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDatumBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietvertrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBezugspersonen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblWohnsitz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAufenthaltsort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtstag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtWohnsitz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAufenthaltsort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtHeimatort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtNationalitaet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAlter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtstag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeschlecht)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZivilstand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFalltraeger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDepotBis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkMieteAbgetreten.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMieteAbgetreten)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMietzinsgarantie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMietzinsgarantie)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void editVermieter_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            DlgAuswahl dlg = new DlgAuswahl();
            e.Cancel = !dlg.InstitutionSuchen(editVermieter.Text, 10, true, e.ButtonClicked); //nur Vermieter

            if (!e.Cancel)
            {
                qryMietvertrag[DBO.BaMietvertrag.BaInstitutionID] = dlg[DBO.BaInstitution.BaInstitutionID];
                qryMietvertrag[editVermieter.DataMember] = dlg[DBO.vwInstitution.NameVorname];
            }
        }

        private void gridView1_CustomRowCellEdit(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "RelationID")
            {
                object GeschlechtCode = grdRelation.View.GetRowCellValue(e.RowHandle, grdRelation.View.Columns["GeschlechtCode"]);

                if (GeschlechtCode is int && (int)GeschlechtCode == 1)
                {
                    e.RepositoryItem = editRelationMale;
                }
                else if (GeschlechtCode is int && (int)GeschlechtCode == 2)
                {
                    e.RepositoryItem = editRelationFemale;
                }
                else
                {
                    e.RepositoryItem = editRelationGeneric;
                }
            }
        }

        private void qryMietvertrag_AfterInsert(object sender, EventArgs e)
        {
            qryMietvertrag[DBO.BaMietvertrag.BaPersonID] = _baPersonID;
        }

        private void qryRelation_BeforePost(object sender, System.EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryRelation["RelationID"]))
            {
                int RelationID = Convert.ToInt32(qryRelation["RelationID"]);
                qryRelation[DBO.BaPerson_Relation.BaRelationID] = RelationID % 100;

                if (RelationID >= 1000)
                {
                    qryRelation[DBO.BaPerson_Relation.BaPersonID_1] = _baPersonID;
                    qryRelation[DBO.BaPerson_Relation.BaPersonID_2] = qryRelation["PersonID"];
                }
                else
                {
                    qryRelation[DBO.BaPerson_Relation.BaPersonID_1] = qryRelation["PersonID"];
                    qryRelation[DBO.BaPerson_Relation.BaPersonID_2] = _baPersonID;
                }
            }

            // handle GleicherHaushalt flag
            bool valid = false;

            try
            {
                valid = BaUtils.HandleGleicherHaushaltFlagSet(qryRelation.ColumnModified("GlHaushalt"),
                                                              Convert.ToBoolean(qryRelation["GlHaushalt"]),
                                                              Convert.ToInt32(qryRelation["PersonID"]),
                                                              Convert.ToString(qryRelation["Person"]),
                                                              Convert.ToInt32(qryFalltraeger["WohnsitzAdresseID"]),
                                                              Convert.ToString(qryFalltraeger["Wohnsitz"]));
            }
            finally
            {
                if (!valid)
                {
                    // we need to reset flag
                    qryRelation["GlHaushalt"] = false;
                }
            }
        }

        private void repositoryItemCheckEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (grvRelation.FocusedColumn.FieldName == "Unterstuetzt")
            {
                qryRelation.Post();

                DBUtil.NewHistoryVersion();

                DBUtil.ExecSQL(@"
                    UPDATE BaPerson
                    SET Unterstuetzt = {0}, Modifier = {1}, Modified = GetDate()
                    WHERE BaPersonID = {2}", qryRelation["Unterstuetzt"], DBUtil.GetDBRowCreatorModifier(), qryRelation["PersonID"]);

                //refresh Tree
                _modulTree.Refresh();
            }
        }

        private void repositoryItemCheckEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (InFP())
            {
                bool gleicheAdresse = Convert.ToBoolean(DBUtil.ExecuteScalarSQL(@"
                    SELECT dbo.fnGleicheAdresse({0}, {1});", _baPersonID, qryRelation["PersonID"]));

                if (!gleicheAdresse)
                {
                    e.Cancel = false;
                    return;
                }

                KissMsg.ShowInfo(CLASS_NAME, "CheckboxAbhaengig", "Diese Checkbox ist abhängig von einem aktuellen Finanzplan und kann nicht manuell verändert werden!");
                e.Cancel = true;
                return;
            }

            if (grvRelation.FocusedColumn.FieldName == "GlHaushalt")
            {
                // check if valid address
                if (DBUtil.IsEmpty(qryFalltraeger["WohnsitzAdresseID"]) || Convert.ToInt32(qryFalltraeger["WohnsitzAdresseID"]) < 1)
                {
                    KissMsg.ShowInfo(CLASS_NAME,
                                     "InvalidAddressOfSourcePerson_01",
                                     "Die Person '{0}' hat keine gültige Wohnsitzadresse. Eine Koppelung der Adressen ist somit nicht möglich.",
                                     qryFalltraeger["Person"]);

                    e.Cancel = true;
                    return;
                }

                // check if two clients
                if (!((bool)qryRelation["GlHaushalt"]) && ((bool)qryRelation["Klient"]))
                {
                    KissMsg.ShowInfo(CLASS_NAME, "KopplungAdresseNichtMoeglich", "Die Adressen von zwei Klienten können nicht gekoppelt werden!");
                    e.Cancel = true;
                    return;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string TitleName, Image TitleImage, int BaPersonID, KissModulTree ModuleTree, bool IsFallTraeger)
        {
            _baPersonID = BaPersonID;
            picTitel.Image = TitleImage;
            _modulTree = ModuleTree;

            //Beziehung Lookup generic
            editRelationGeneric.DataSource = DBUtil.OpenSQL(@"
                select Code = BaRelationID, Text = NameGenerisch1 from BaRelation
                union all
                select Code = BaRelationID + 1000, Text = NameGenerisch2 from BaRelation
                where NameGenerisch1 <> NameGenerisch2
                order by 2");

            //Beziehung Lookup male
            editRelationMale.DataSource = DBUtil.OpenSQL(@"
                select Code = BaRelationID + 100, Text = NameMaennlich1 from BaRelation
                union all
                select Code = BaRelationID + 1000 + 100, Text = NameMaennlich2 from BaRelation
                where NameMaennlich1 <> NameMaennlich2
                order by 2");

            //Beziehung Lookup female
            editRelationFemale.DataSource = DBUtil.OpenSQL(@"
                select Code = BaRelationID + 200, Text = NameWeiblich1 from BaRelation
                union all
                select Code = BaRelationID + 1000 + 200, Text = NameWeiblich2 from BaRelation
                where NameWeiblich1 <> NameWeiblich2
                order by 2");

            //Falltraeger
            qryFalltraeger.Fill(new object[] { BaPersonID, Session.User.LanguageCode });

            //Bezugspersonen
            qryRelation.Fill(BaPersonID);

            //Mietvertrag
            qryMietvertrag.Fill(BaPersonID);
            InsertEmptyMietvertrag();

            // setup rights
            SetupRights();
        }

        public override bool OnSaveData()
        {
            // save data on both queries
            bool success = qryRelation.Post() && qryMietvertrag.Post();

            // insert empty entry after post as it will be removed in post if no data was entered
            InsertEmptyMietvertrag();

            // return value
            return success;
        }

        public override void OnUndoDataChanges()
        {
            // undo changes on both queries
            qryRelation.Cancel();
            qryMietvertrag.Cancel();
        }

        #endregion

        #region Private Methods

        private bool InFP()
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT 1
                FROM dbo.FaFall                        FAL
                  INNER JOIN dbo.FaLeistung            LST ON LST.FaFallID = FAL.FaFallID
                  INNER JOIN dbo.BgFinanzplan          SFP ON SFP.FaLeistungID = LST.FaLeistungID
                  INNER JOIN dbo.BgFinanzplan_BaPerson SDP ON SDP.BgFinanzplanID = SFP.BgFinanzplanID
                WHERE FAL.BaPersonID = {0}
                  AND GETDATE() BETWEEN SFP.DatumVon AND SFP.DatumBis
                  AND SDP.BaPersonID = {1}", _baPersonID, qryRelation["PersonID"]);

            return (qry.Count > 0);
        }

        private void InsertEmptyMietvertrag()
        {
            if (qryMietvertrag.CanUpdate && qryMietvertrag.Count == 0)
            {
                qryMietvertrag.Insert(qryMietvertrag.TableName);
            }
        }

        private void SetupRights()
        {
            // setup grid depending on current rights
            grdRelation.GridStyle = qryRelation.CanUpdate ? GridStyleType.Editable : GridStyleType.ReadOnly;
        }

        #endregion

        #endregion
    }
}