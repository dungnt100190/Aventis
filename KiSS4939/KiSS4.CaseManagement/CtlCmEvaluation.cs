using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Columns;
using Kiss.Infrastructure;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Dokument;
using KiSS4.Gui;
using log4net;

namespace KiSS4.CaseManagement
{
    /// <summary>
    /// Control, used for evaluation of Case Management
    /// </summary>
    public class CtlCmEvaluation : KissUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly string _handlungszielText = "";
        private readonly string _massnahmeText = "";
        private readonly string _rahmenzielText = "";

        #endregion

        #region Private Fields

        private bool _doNotCheckEvaluation; // flag if BeforePost shall check evaluation
        private int _faLeistungID = -1;
        private KissButton btnCollapseAll;
        private KissButton btnDeleteEval;
        private KissButton btnExpandAll;
        private TreeListColumn colTreeBegruendung;
        private TreeListColumn colTreeBisWann;
        private TreeListColumn colTreeDatum;
        private TreeListColumn colTreeDatumEvaluation;
        private TreeListColumn colTreeElement;
        private TreeListColumn colTreeErledigt;
        private TreeListColumn colTreeEvaluation;
        private TreeListColumn colTreeIndikatoren;
        private TreeListColumn colTreeKommentar;
        private TreeListColumn colTreeLebensbereich;
        private TreeListColumn colTreeWer;
        private TreeListColumn colTreeZielMassnahme;
        private IContainer components;
        private KissDocumentButton docEvaluation;
        private KissDateEdit edtErstellungZV;
        private KissTextEdit edtGrundsatzziel;
        private KissTextEdit edtZustaendigerSA;
        private KissLabel lblErstellungZV;
        private KissLabel lblGrundsatzziel;
        private KissLabel lblTitel;
        private KissLabel lblZustaendigerSA;
        private Panel panBottom;
        private Panel panTitel;
        private Panel panTopInfo;
        private PictureBox picTitel;
        private SqlQuery qryFaCaseManagementMain;
        private SqlQuery qryFaCmSub;
        private RepositoryItemCheckEdit repCheckErledigt;
        private RepositoryItemDateEdit repDatumEvaluation;
        private RepositoryItemTextEdit repTextBecauseOfNoDateColumnEdit;
        private RepositoryItemTextEdit repTextBegruendung;
        private KissTree treUebersicht;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlCmEvaluation"/> class.
        /// </summary>
        public CtlCmEvaluation()
        {
            InitializeComponent();

            // logging
            _logger.Debug("enter");

            // request strings
            _rahmenzielText = KissMsg.GetMLMessage(Name, "RahmenzielText", "Rahmenziel");
            _handlungszielText = KissMsg.GetMLMessage(Name, "HandlungszielText", "Handlungsziel");
            _massnahmeText = KissMsg.GetMLMessage(Name, "MassnahmeText", "Massnahme");

            // make tree editable
            treUebersicht.OptionsBehavior.Editable = true;

            // setup column
            var grd = new KissGrid();

            colTreeEvaluation.ColumnEdit = grd.GetLOVLookUpEdit("FaErreichungsgrad", true);
            colTreeEvaluation.ColumnEdit.Appearance.BackColor = Color.AliceBlue;
            colTreeEvaluation.ColumnEdit.Appearance.ForeColor = Color.Black;
            colTreeEvaluation.ColumnEdit.Appearance.Options.UseForeColor = true;
            colTreeEvaluation.ColumnEdit.AppearanceFocused.ForeColor = Color.Black;
            colTreeEvaluation.ColumnEdit.AppearanceFocused.Options.UseForeColor = true;

            // init with default values
            Init(null, null, -1, false);

            // logging
            _logger.Debug("done");
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlCmEvaluation));
            this.panTitel = new System.Windows.Forms.Panel();
            this.lblTitel = new KiSS4.Gui.KissLabel();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.panTopInfo = new System.Windows.Forms.Panel();
            this.lblZustaendigerSA = new KiSS4.Gui.KissLabel();
            this.edtZustaendigerSA = new KiSS4.Gui.KissTextEdit();
            this.lblErstellungZV = new KiSS4.Gui.KissLabel();
            this.edtErstellungZV = new KiSS4.Gui.KissDateEdit();
            this.lblGrundsatzziel = new KiSS4.Gui.KissLabel();
            this.edtGrundsatzziel = new KiSS4.Gui.KissTextEdit();
            this.docEvaluation = new KiSS4.Dokument.KissDocumentButton();
            this.treUebersicht = new KiSS4.Gui.KissTree();
            this.panBottom = new System.Windows.Forms.Panel();
            this.btnExpandAll = new KiSS4.Gui.KissButton();
            this.btnCollapseAll = new KiSS4.Gui.KissButton();
            this.btnDeleteEval = new KiSS4.Gui.KissButton();
            this.colTreeBegruendung = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeBisWann = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeDatum = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeDatumEvaluation = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeElement = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeErledigt = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeEvaluation = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeIndikatoren = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeKommentar = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeLebensbereich = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeWer = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTreeZielMassnahme = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.qryFaCaseManagementMain = new KiSS4.DB.SqlQuery(this.components);
            this.qryFaCmSub = new KiSS4.DB.SqlQuery(this.components);
            this.repCheckErledigt = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repDatumEvaluation = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repTextBecauseOfNoDateColumnEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repTextBegruendung = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            this.panTopInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigerSA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigerSA.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstellungZV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstellungZV.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundsatzziel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundsatzziel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treUebersicht)).BeginInit();
            this.panBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaCaseManagementMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaCmSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckErledigt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDatumEvaluation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextBecauseOfNoDateColumnEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextBegruendung)).BeginInit();
            this.SuspendLayout();
            //
            // panTitel
            //
            this.panTitel.Controls.Add(this.picTitel);
            this.panTitel.Controls.Add(this.lblTitel);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(0, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(722, 30);
            this.panTitel.TabIndex = 0;
            //
            // lblTitel
            //
            this.lblTitel.Anchor = ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                      | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(680, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Evaluation Case Management";
            this.lblTitel.UseCompatibleTextRendering = true;
            //
            // picTitel
            //
            this.picTitel.Location = new System.Drawing.Point(10, 7);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(16, 16);
            this.picTitel.TabIndex = 1;
            this.picTitel.TabStop = false;
            //
            // panTopInfo
            //
            this.panTopInfo.Controls.Add(this.docEvaluation);
            this.panTopInfo.Controls.Add(this.edtGrundsatzziel);
            this.panTopInfo.Controls.Add(this.lblGrundsatzziel);
            this.panTopInfo.Controls.Add(this.edtErstellungZV);
            this.panTopInfo.Controls.Add(this.lblErstellungZV);
            this.panTopInfo.Controls.Add(this.edtZustaendigerSA);
            this.panTopInfo.Controls.Add(this.lblZustaendigerSA);
            this.panTopInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopInfo.Location = new System.Drawing.Point(0, 30);
            this.panTopInfo.Name = "panTopInfo";
            this.panTopInfo.Size = new System.Drawing.Size(722, 111);
            this.panTopInfo.TabIndex = 1;
            //
            // lblZustaendigerSA
            //
            this.lblZustaendigerSA.Location = new System.Drawing.Point(9, 9);
            this.lblZustaendigerSA.Name = "lblZustaendigerSA";
            this.lblZustaendigerSA.Size = new System.Drawing.Size(109, 24);
            this.lblZustaendigerSA.TabIndex = 0;
            this.lblZustaendigerSA.Text = "Zuständiger SA";
            this.lblZustaendigerSA.UseCompatibleTextRendering = true;
            //
            // edtZustaendigerSA
            //
            this.edtZustaendigerSA.DataMember = "ZustaendigSA";
            this.edtZustaendigerSA.DataSource = this.qryFaCaseManagementMain;
            this.edtZustaendigerSA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZustaendigerSA.Location = new System.Drawing.Point(124, 9);
            this.edtZustaendigerSA.Name = "edtZustaendigerSA";
            this.edtZustaendigerSA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((((247)))), ((((239)))), ((((231)))));
            this.edtZustaendigerSA.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZustaendigerSA.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZustaendigerSA.Properties.Appearance.Options.UseBackColor = true;
            this.edtZustaendigerSA.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZustaendigerSA.Properties.Appearance.Options.UseFont = true;
            this.edtZustaendigerSA.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZustaendigerSA.Properties.ReadOnly = true;
            this.edtZustaendigerSA.Size = new System.Drawing.Size(285, 24);
            this.edtZustaendigerSA.TabIndex = 1;
            this.edtZustaendigerSA.TabStop = false;
            //
            // lblErstellungZV
            //
            this.lblErstellungZV.Location = new System.Drawing.Point(9, 39);
            this.lblErstellungZV.Name = "lblErstellungZV";
            this.lblErstellungZV.Size = new System.Drawing.Size(109, 24);
            this.lblErstellungZV.TabIndex = 2;
            this.lblErstellungZV.Text = "Erstellung ZV";
            this.lblErstellungZV.UseCompatibleTextRendering = true;
            //
            // edtErstellungZV
            //
            this.edtErstellungZV.DataMember = "ErstellungZV";
            this.edtErstellungZV.DataSource = this.qryFaCaseManagementMain;
            this.edtErstellungZV.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErstellungZV.EditValue = null;
            this.edtErstellungZV.Location = new System.Drawing.Point(124, 39);
            this.edtErstellungZV.Name = "edtErstellungZV";
            this.edtErstellungZV.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErstellungZV.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((((247)))), ((((239)))), ((((231)))));
            this.edtErstellungZV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstellungZV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstellungZV.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstellungZV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstellungZV.Properties.Appearance.Options.UseFont = true;
            this.edtErstellungZV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtErstellungZV.Properties.Buttons.AddRange(new[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtErstellungZV.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtErstellungZV.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErstellungZV.Properties.ReadOnly = true;
            this.edtErstellungZV.Properties.ShowToday = false;
            this.edtErstellungZV.Size = new System.Drawing.Size(100, 24);
            this.edtErstellungZV.TabIndex = 3;
            this.edtErstellungZV.TabStop = false;
            //
            // lblGrundsatzziel
            //
            this.lblGrundsatzziel.Location = new System.Drawing.Point(9, 69);
            this.lblGrundsatzziel.Name = "lblGrundsatzziel";
            this.lblGrundsatzziel.Size = new System.Drawing.Size(109, 24);
            this.lblGrundsatzziel.TabIndex = 4;
            this.lblGrundsatzziel.Text = "Grundsatzziel";
            this.lblGrundsatzziel.UseCompatibleTextRendering = true;
            //
            // edtGrundsatzziel
            //
            this.edtGrundsatzziel.Anchor = ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                                              | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundsatzziel.DataMember = "Grundsatzziel";
            this.edtGrundsatzziel.DataSource = this.qryFaCaseManagementMain;
            this.edtGrundsatzziel.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrundsatzziel.Location = new System.Drawing.Point(124, 69);
            this.edtGrundsatzziel.Name = "edtGrundsatzziel";
            this.edtGrundsatzziel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((((247)))), ((((239)))), ((((231)))));
            this.edtGrundsatzziel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGrundsatzziel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGrundsatzziel.Properties.Appearance.Options.UseBackColor = true;
            this.edtGrundsatzziel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGrundsatzziel.Properties.Appearance.Options.UseFont = true;
            this.edtGrundsatzziel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGrundsatzziel.Properties.ReadOnly = true;
            this.edtGrundsatzziel.Size = new System.Drawing.Size(589, 24);
            this.edtGrundsatzziel.TabIndex = 5;
            this.edtGrundsatzziel.TabStop = false;
            //
            // docEvaluation
            //
            this.docEvaluation.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.docEvaluation.Context = "CM_Evaluation_Evaluation";
            this.docEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.docEvaluation.Image = ((System.Drawing.Image)(resources.GetObject("docEvaluation.Image")));
            this.docEvaluation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.docEvaluation.Location = new System.Drawing.Point(606, 9);
            this.docEvaluation.Name = "docEvaluation";
            this.docEvaluation.Size = new System.Drawing.Size(107, 24);
            this.docEvaluation.TabIndex = 6;
            this.docEvaluation.Text = "Evalua&tion";
            this.docEvaluation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.docEvaluation.UseCompatibleTextRendering = true;
            this.docEvaluation.UseVisualStyleBackColor = false;
            //
            // treUebersicht
            //
            this.treUebersicht.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.treUebersicht.Appearance.Empty.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.Empty.Options.UseBackColor = true;
            this.treUebersicht.Appearance.Empty.Options.UseForeColor = true;
            this.treUebersicht.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((((242)))), ((((236)))), ((((215)))));
            this.treUebersicht.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.EvenRow.Options.UseBackColor = true;
            this.treUebersicht.Appearance.EvenRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treUebersicht.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treUebersicht.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treUebersicht.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((((230)))), ((((216)))), ((((174)))));
            this.treUebersicht.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.FooterPanel.Options.UseBackColor = true;
            this.treUebersicht.Appearance.FooterPanel.Options.UseFont = true;
            this.treUebersicht.Appearance.FooterPanel.Options.UseForeColor = true;
            this.treUebersicht.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.treUebersicht.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.treUebersicht.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.GroupButton.Options.UseBackColor = true;
            this.treUebersicht.Appearance.GroupButton.Options.UseFont = true;
            this.treUebersicht.Appearance.GroupButton.Options.UseForeColor = true;
            this.treUebersicht.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((((240)))), ((((226)))), ((((184)))));
            this.treUebersicht.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.GroupFooter.Options.UseBackColor = true;
            this.treUebersicht.Appearance.GroupFooter.Options.UseForeColor = true;
            this.treUebersicht.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.treUebersicht.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.treUebersicht.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.treUebersicht.Appearance.HeaderPanel.Options.UseFont = true;
            this.treUebersicht.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.treUebersicht.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.treUebersicht.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.treUebersicht.Appearance.HideSelectionRow.Options.UseFont = true;
            this.treUebersicht.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((((230)))), ((((216)))), ((((174)))));
            this.treUebersicht.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treUebersicht.Appearance.HorzLine.Options.UseBackColor = true;
            this.treUebersicht.Appearance.HorzLine.Options.UseForeColor = true;
            this.treUebersicht.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((((236)))), ((((227)))), ((((215)))));
            this.treUebersicht.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.OddRow.Options.UseBackColor = true;
            this.treUebersicht.Appearance.OddRow.Options.UseFont = true;
            this.treUebersicht.Appearance.OddRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.Preview.BackColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.Preview.ForeColor = System.Drawing.Color.Maroon;
            this.treUebersicht.Appearance.Preview.Options.UseBackColor = true;
            this.treUebersicht.Appearance.Preview.Options.UseFont = true;
            this.treUebersicht.Appearance.Preview.Options.UseForeColor = true;
            this.treUebersicht.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.treUebersicht.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.treUebersicht.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.Row.Options.UseBackColor = true;
            this.treUebersicht.Appearance.Row.Options.UseFont = true;
            this.treUebersicht.Appearance.Row.Options.UseForeColor = true;
            this.treUebersicht.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.treUebersicht.Appearance.TreeLine.ForeColor = System.Drawing.Color.Gray;
            this.treUebersicht.Appearance.TreeLine.Options.UseBackColor = true;
            this.treUebersicht.Appearance.TreeLine.Options.UseForeColor = true;
            this.treUebersicht.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((((230)))), ((((216)))), ((((174)))));
            this.treUebersicht.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((((198)))), ((((166)))), ((((70)))));
            this.treUebersicht.Appearance.VertLine.Options.UseBackColor = true;
            this.treUebersicht.Appearance.VertLine.Options.UseForeColor = true;
            this.treUebersicht.Appearance.VertLine.Options.UseTextOptions = true;
            this.treUebersicht.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treUebersicht.Columns.AddRange(new[] {
                this.colTreeElement,
                this.colTreeDatum,
                this.colTreeZielMassnahme,
                this.colTreeDatumEvaluation,
                this.colTreeEvaluation,
                this.colTreeErledigt,
                this.colTreeBegruendung,
                this.colTreeLebensbereich,
                this.colTreeIndikatoren,
                this.colTreeBisWann,
                this.colTreeWer,
                this.colTreeKommentar});
            this.treUebersicht.DataSource = this.qryFaCmSub;
            this.treUebersicht.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treUebersicht.ImageIndexFieldName = "IconID";
            this.treUebersicht.KeyFieldName = "FaCaseManagementID";
            this.treUebersicht.Location = new System.Drawing.Point(0, 141);
            this.treUebersicht.Name = "treUebersicht";
            this.treUebersicht.OptionsBehavior.AutoSelectAllInEditor = false;
            this.treUebersicht.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.treUebersicht.OptionsBehavior.Editable = false;
            this.treUebersicht.OptionsBehavior.KeepSelectedOnClick = false;
            this.treUebersicht.OptionsBehavior.MoveOnEdit = false;
            this.treUebersicht.OptionsBehavior.PopulateServiceColumns = true;
            this.treUebersicht.OptionsMenu.EnableColumnMenu = false;
            this.treUebersicht.OptionsMenu.EnableFooterMenu = false;
            this.treUebersicht.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treUebersicht.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treUebersicht.OptionsView.AutoWidth = false;
            this.treUebersicht.OptionsView.EnableAppearanceEvenRow = true;
            this.treUebersicht.OptionsView.EnableAppearanceOddRow = true;
            this.treUebersicht.OptionsView.ShowIndicator = false;
            this.treUebersicht.ParentFieldName = "ElterID";
            this.treUebersicht.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repCheckErledigt,
                this.repTextBegruendung,
                this.repDatumEvaluation,
                this.repTextBecauseOfNoDateColumnEdit});
            this.treUebersicht.Size = new System.Drawing.Size(722, 419);
            this.treUebersicht.TabIndex = 2;
            this.treUebersicht.CustomDrawNodeCell += this.treUebersicht_CustomDrawNodeCell;
            this.treUebersicht.BeforeFocusNode += this.treUebersicht_BeforeFocusNode;
            //
            // panBottom
            //
            this.panBottom.Controls.Add(this.btnDeleteEval);
            this.panBottom.Controls.Add(this.btnCollapseAll);
            this.panBottom.Controls.Add(this.btnExpandAll);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 560);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(722, 36);
            this.panBottom.TabIndex = 3;
            //
            // btnExpandAll
            //
            this.btnExpandAll.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandAll.IconID = 70;
            this.btnExpandAll.Location = new System.Drawing.Point(659, 6);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(24, 24);
            this.btnExpandAll.TabIndex = 0;
            this.btnExpandAll.UseCompatibleTextRendering = true;
            this.btnExpandAll.UseVisualStyleBackColor = false;
            this.btnExpandAll.Click += this.btnExpandAll_Click;
            //
            // btnCollapseAll
            //
            this.btnCollapseAll.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapseAll.IconID = 71;
            this.btnCollapseAll.Location = new System.Drawing.Point(689, 6);
            this.btnCollapseAll.Margin = new System.Windows.Forms.Padding(3, 6, 9, 3);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(24, 24);
            this.btnCollapseAll.TabIndex = 1;
            this.btnCollapseAll.UseCompatibleTextRendering = true;
            this.btnCollapseAll.UseVisualStyleBackColor = false;
            this.btnCollapseAll.Click += this.btnCollapseAll_Click;
            //
            // btnDeleteEval
            //
            this.btnDeleteEval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteEval.Location = new System.Drawing.Point(9, 6);
            this.btnDeleteEval.Name = "btnDeleteEval";
            this.btnDeleteEval.Size = new System.Drawing.Size(129, 24);
            this.btnDeleteEval.TabIndex = 2;
            this.btnDeleteEval.Text = "Evaluation &löschen";
            this.btnDeleteEval.UseCompatibleTextRendering = true;
            this.btnDeleteEval.UseVisualStyleBackColor = false;
            this.btnDeleteEval.Click += this.btnDeleteEval_Click;
            //
            // colTreeBegruendung
            //
            this.colTreeBegruendung.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.colTreeBegruendung.AppearanceCell.Options.UseBackColor = true;
            this.colTreeBegruendung.Caption = "Begründung";
            this.colTreeBegruendung.ColumnEdit = this.repTextBegruendung;
            this.colTreeBegruendung.FieldName = "EvaluationBegruendung";
            this.colTreeBegruendung.Name = "colTreeBegruendung";
            this.colTreeBegruendung.OptionsColumn.AllowSort = false;
            this.colTreeBegruendung.VisibleIndex = 6;
            this.colTreeBegruendung.Width = 250;
            //
            // colTreeBisWann
            //
            this.colTreeBisWann.Caption = "Bis wann";
            this.colTreeBisWann.FieldName = "BisWann";
            this.colTreeBisWann.Name = "colTreeBisWann";
            this.colTreeBisWann.OptionsColumn.AllowEdit = false;
            this.colTreeBisWann.OptionsColumn.AllowSort = false;
            this.colTreeBisWann.OptionsColumn.ReadOnly = true;
            this.colTreeBisWann.VisibleIndex = 9;
            this.colTreeBisWann.Width = 70;
            //
            // colTreeDatum
            //
            this.colTreeDatum.Caption = "Datum";
            this.colTreeDatum.ColumnEdit = this.repTextBecauseOfNoDateColumnEdit;
            this.colTreeDatum.FieldName = "Datum";
            this.colTreeDatum.Name = "colTreeDatum";
            this.colTreeDatum.OptionsColumn.AllowEdit = false;
            this.colTreeDatum.OptionsColumn.AllowSort = false;
            this.colTreeDatum.OptionsColumn.ReadOnly = true;
            this.colTreeDatum.VisibleIndex = 1;
            this.colTreeDatum.Width = 70;
            //
            // colTreeDatumEvaluation
            //
            this.colTreeDatumEvaluation.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.colTreeDatumEvaluation.AppearanceCell.Options.UseBackColor = true;
            this.colTreeDatumEvaluation.Caption = "Datum Eval.";
            this.colTreeDatumEvaluation.ColumnEdit = this.repDatumEvaluation;
            this.colTreeDatumEvaluation.FieldName = "EvaluationDatum";
            this.colTreeDatumEvaluation.Name = "colTreeDatumEvaluation";
            this.colTreeDatumEvaluation.OptionsColumn.AllowSort = false;
            this.colTreeDatumEvaluation.VisibleIndex = 3;
            this.colTreeDatumEvaluation.Width = 85;
            //
            // colTreeElement
            //
            this.colTreeElement.Caption = "Element";
            this.colTreeElement.FieldName = "Element";
            this.colTreeElement.MinWidth = 64;
            this.colTreeElement.Name = "colTreeElement";
            this.colTreeElement.OptionsColumn.AllowEdit = false;
            this.colTreeElement.OptionsColumn.AllowSort = false;
            this.colTreeElement.OptionsColumn.ReadOnly = true;
            this.colTreeElement.VisibleIndex = 0;
            this.colTreeElement.Width = 135;
            //
            // colTreeErledigt
            //
            this.colTreeErledigt.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.colTreeErledigt.AppearanceCell.ForeColor = System.Drawing.SystemColors.ControlText;
            this.colTreeErledigt.AppearanceCell.Options.UseBackColor = true;
            this.colTreeErledigt.AppearanceCell.Options.UseForeColor = true;
            this.colTreeErledigt.Caption = "Erl.";
            this.colTreeErledigt.ColumnEdit = this.repCheckErledigt;
            this.colTreeErledigt.FieldName = "Erledigt";
            this.colTreeErledigt.Name = "colTreeErledigt";
            this.colTreeErledigt.OptionsColumn.AllowSort = false;
            this.colTreeErledigt.VisibleIndex = 5;
            this.colTreeErledigt.Width = 35;
            //
            // colTreeEvaluation
            //
            this.colTreeEvaluation.AppearanceCell.BackColor = System.Drawing.Color.AliceBlue;
            this.colTreeEvaluation.AppearanceCell.ForeColor = System.Drawing.Color.Black;
            this.colTreeEvaluation.AppearanceCell.Options.UseBackColor = true;
            this.colTreeEvaluation.AppearanceCell.Options.UseForeColor = true;
            this.colTreeEvaluation.Caption = "Evaluation";
            this.colTreeEvaluation.FieldName = "EvaluationCode";
            this.colTreeEvaluation.Name = "colTreeEvaluation";
            this.colTreeEvaluation.OptionsColumn.AllowSort = false;
            this.colTreeEvaluation.VisibleIndex = 4;
            this.colTreeEvaluation.Width = 100;
            //
            // colTreeIndikatoren
            //
            this.colTreeIndikatoren.Caption = "Indikatoren";
            this.colTreeIndikatoren.FieldName = "Indikatoren";
            this.colTreeIndikatoren.Name = "colTreeIndikatoren";
            this.colTreeIndikatoren.OptionsColumn.AllowEdit = false;
            this.colTreeIndikatoren.OptionsColumn.AllowSort = false;
            this.colTreeIndikatoren.OptionsColumn.ReadOnly = true;
            this.colTreeIndikatoren.VisibleIndex = 8;
            this.colTreeIndikatoren.Width = 100;
            //
            // colTreeKommentar
            //
            this.colTreeKommentar.Caption = "Kommentar";
            this.colTreeKommentar.FieldName = "Kommentar";
            this.colTreeKommentar.Name = "colTreeKommentar";
            this.colTreeKommentar.OptionsColumn.AllowEdit = false;
            this.colTreeKommentar.OptionsColumn.AllowSort = false;
            this.colTreeKommentar.OptionsColumn.ReadOnly = true;
            this.colTreeKommentar.VisibleIndex = 11;
            this.colTreeKommentar.Width = 130;
            //
            // colTreeLebensbereich
            //
            this.colTreeLebensbereich.Caption = "Lebensbereich";
            this.colTreeLebensbereich.FieldName = "Lebensbereich";
            this.colTreeLebensbereich.Name = "colTreeLebensbereich";
            this.colTreeLebensbereich.OptionsColumn.AllowEdit = false;
            this.colTreeLebensbereich.OptionsColumn.AllowSort = false;
            this.colTreeLebensbereich.OptionsColumn.ReadOnly = true;
            this.colTreeLebensbereich.VisibleIndex = 7;
            this.colTreeLebensbereich.Width = 130;
            //
            // colTreeWer
            //
            this.colTreeWer.Caption = "Wer";
            this.colTreeWer.FieldName = "Wer";
            this.colTreeWer.Name = "colTreeWer";
            this.colTreeWer.OptionsColumn.AllowEdit = false;
            this.colTreeWer.OptionsColumn.AllowSort = false;
            this.colTreeWer.OptionsColumn.ReadOnly = true;
            this.colTreeWer.VisibleIndex = 10;
            this.colTreeWer.Width = 90;
            //
            // colTreeZielMassnahme
            //
            this.colTreeZielMassnahme.Caption = "Ziel/Massnahme";
            this.colTreeZielMassnahme.FieldName = "Text";
            this.colTreeZielMassnahme.Name = "colTreeZielMassnahme";
            this.colTreeZielMassnahme.OptionsColumn.AllowEdit = false;
            this.colTreeZielMassnahme.OptionsColumn.AllowSort = false;
            this.colTreeZielMassnahme.OptionsColumn.ReadOnly = true;
            this.colTreeZielMassnahme.VisibleIndex = 2;
            this.colTreeZielMassnahme.Width = 110;
            //
            // qryFaCaseManagementMain
            //
            this.qryFaCaseManagementMain.HostControl = this;
            this.qryFaCaseManagementMain.TableName = "FaCaseManagement";
            //
            // qryFaCmSub
            //
            this.qryFaCmSub.HostControl = this;
            this.qryFaCmSub.TableName = "FaCaseManagement";
            this.qryFaCmSub.BeforePost += this.qryFaCmSub_BeforePost;
            //
            // repCheckErledigt
            //
            this.repCheckErledigt.AllowFocused = false;
            this.repCheckErledigt.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.repCheckErledigt.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repCheckErledigt.Appearance.Options.UseBackColor = true;
            this.repCheckErledigt.Appearance.Options.UseForeColor = true;
            this.repCheckErledigt.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue;
            this.repCheckErledigt.AppearanceFocused.Options.UseBackColor = true;
            this.repCheckErledigt.AutoHeight = false;
            this.repCheckErledigt.Name = "repCheckErledigt";
            //
            // repDatumEvaluation
            //
            this.repDatumEvaluation.AllowFocused = false;
            this.repDatumEvaluation.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.repDatumEvaluation.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repDatumEvaluation.Appearance.Options.UseBackColor = true;
            this.repDatumEvaluation.Appearance.Options.UseForeColor = true;
            this.repDatumEvaluation.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue;
            this.repDatumEvaluation.AppearanceFocused.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repDatumEvaluation.AppearanceFocused.Options.UseBackColor = true;
            this.repDatumEvaluation.AppearanceFocused.Options.UseForeColor = true;
            this.repDatumEvaluation.AutoHeight = false;
            this.repDatumEvaluation.Buttons.AddRange(new[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDatumEvaluation.Name = "repDatumEvaluation";
            //
            // repTextBecauseOfNoDateColumnEdit
            //
            this.repTextBecauseOfNoDateColumnEdit.AllowFocused = false;
            this.repTextBecauseOfNoDateColumnEdit.AutoHeight = false;
            this.repTextBecauseOfNoDateColumnEdit.DisplayFormat.FormatString = "d";
            this.repTextBecauseOfNoDateColumnEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repTextBecauseOfNoDateColumnEdit.EditFormat.FormatString = "d";
            this.repTextBecauseOfNoDateColumnEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repTextBecauseOfNoDateColumnEdit.Name = "repTextBecauseOfNoDateColumnEdit";
            this.repTextBecauseOfNoDateColumnEdit.ReadOnly = true;
            //
            // repTextBegruendung
            //
            this.repTextBegruendung.AllowFocused = false;
            this.repTextBegruendung.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.repTextBegruendung.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repTextBegruendung.Appearance.Options.UseBackColor = true;
            this.repTextBegruendung.Appearance.Options.UseForeColor = true;
            this.repTextBegruendung.AppearanceFocused.BackColor = System.Drawing.Color.AliceBlue;
            this.repTextBegruendung.AppearanceFocused.ForeColor = System.Drawing.SystemColors.ControlText;
            this.repTextBegruendung.AppearanceFocused.Options.UseBackColor = true;
            this.repTextBegruendung.AppearanceFocused.Options.UseForeColor = true;
            this.repTextBegruendung.AutoHeight = false;
            this.repTextBegruendung.DisplayFormat.FormatString = "d";
            this.repTextBegruendung.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repTextBegruendung.EditFormat.FormatString = "d";
            this.repTextBegruendung.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.repTextBegruendung.Name = "repTextBegruendung";
            //
            // CtlCmEvaluation
            //
            this.ActiveSQLQuery = this.qryFaCaseManagementMain;
            this.AutoRefresh = false;
            this.Controls.Add(this.treUebersicht);
            this.Controls.Add(this.panTopInfo);
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.panBottom);
            this.Name = "CtlCmEvaluation";
            this.Size = new System.Drawing.Size(722, 596);
            this.Load += this.CtlCmEvaluation_Load;
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            this.panTopInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblZustaendigerSA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZustaendigerSA.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErstellungZV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErstellungZV.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGrundsatzziel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGrundsatzziel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treUebersicht)).EndInit();
            this.panBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.qryFaCaseManagementMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryFaCmSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repCheckErledigt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDatumEvaluation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextBecauseOfNoDateColumnEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repTextBegruendung)).EndInit();
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

        private void CtlCmEvaluation_Load(object sender, EventArgs e)
        {
            // attach events to column-edits
            colTreeDatumEvaluation.ColumnEdit.EditValueChanged += repositoryItem_EditValueChanged;
            colTreeEvaluation.ColumnEdit.EditValueChanged += repositoryItem_EditValueChanged;
            colTreeErledigt.ColumnEdit.EditValueChanged += repositoryItem_EditValueChanged;
            colTreeBegruendung.ColumnEdit.EditValueChanged += repositoryItem_EditValueChanged;
        }

        private void btnCollapseAll_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            treUebersicht.CollapseAll();
            treUebersicht.Focus();

            // logging
            _logger.Debug("done");
        }

        private void btnDeleteEval_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // check if button can be used
            if (!qryFaCmSub.CanUpdate)
            {
                // logging
                _logger.Debug("upd. not allowed");

                // disable button
                btnDeleteEval.Enabled = false;

                // cancel
                return;
            }

            // confirm first
            if (!KissMsg.ShowQuestion(Name, "ConfirmDeleteEval", "Soll die Evaluation für den aktuellen Eintrag wirklich gelöscht werden?", false))
            {
                // logging
                _logger.Debug("cancel by user");

                // canceled by user
                return;
            }

            // reset columns
            qryFaCmSub["EvaluationCode"] = DBNull.Value;
            qryFaCmSub["EvaluationDatum"] = DBNull.Value;
            qryFaCmSub["EvaluationBegruendung"] = DBNull.Value;
            qryFaCmSub["Erledigt"] = 0;

            try
            {
                // set flag
                _doNotCheckEvaluation = true;

                // save changes (without checking evaluation)
                qryFaCmSub.Post();
            }
            finally
            {
                // reset flag
                _doNotCheckEvaluation = false;
            }

            // logging
            _logger.Debug("done");
        }

        private void btnExpandAll_Click(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            ExpandAllEntries();

            // logging
            _logger.Debug("done");
        }

        private void qryFaCmSub_BeforePost(object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // END EDIT:
            EndEditColumnEdit();

            // do it (required to apply change visible)
            ApplicationFacade.DoEvents();

            // check if need to handle evaluation
            if (_doNotCheckEvaluation)
            {
                // logging
                _logger.Debug("do not check evaluation, allow post");

                // done
                return;
            }

            // get if column is Massnahme
            bool istMassnahme = Convert.ToBoolean(qryFaCmSub["IstMassnahme"]);

            // MUST FIELDS:
            // EvaluationDatum
            if (DBUtil.IsEmpty(qryFaCmSub[colTreeDatumEvaluation.FieldName]))
            {
                // show message
                KissMsg.ShowInfo(Name, "EvaluationDatumIsEmpty", "Das Feld 'Datum Evaluation' muss ausgefüllt werden.");

                // focus
                treUebersicht.FocusedColumn = colTreeDatumEvaluation;

                // cancel
                throw new KissCancelException();
            }

            // Evaluation if not Massnahme
            if (!istMassnahme && DBUtil.IsEmpty(qryFaCmSub[colTreeEvaluation.FieldName]))
            {
                // show message
                KissMsg.ShowInfo(Name, "EvaluationEvalIsEmpty", "Das Feld 'Evaluation' muss bei einem Rahmenziel oder Handlungsziel ausgefüllt werden.");

                // focus
                treUebersicht.FocusedColumn = colTreeEvaluation;

                // cancel
                throw new KissCancelException();
            }

            // Erledigt if Massnahme
            if (istMassnahme && (DBUtil.IsEmpty(qryFaCmSub[colTreeErledigt.FieldName]) || !Convert.ToBoolean(qryFaCmSub[colTreeErledigt.FieldName])))
            {
                // show message
                KissMsg.ShowInfo(Name, "EvaluationErledigtIsEmpty", "Das Feld 'Erledigt' muss bei einer Massnahme ausgefüllt werden.");

                // focus
                treUebersicht.FocusedColumn = colTreeErledigt;

                // cancel
                throw new KissCancelException();
            }

            // logging
            _logger.Debug("done");
        }

        private void repositoryItem_EditValueChanged(Object sender, EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // set columns as changed in order to do save if user presses F2
            qryFaCmSub.RowModified = true;

            // logging
            _logger.Debug("done");
        }

        private void treUebersicht_BeforeFocusNode(Object sender, BeforeFocusNodeEventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.Debug(String.Format("e.OldNode='{0}', e.Node='{1}', treUebersicht.FocusedNode='{2}'", e.OldNode, e.Node, treUebersicht.FocusedNode));

            // check if we have a focused node
            if (e.OldNode == null)
            {
                // if no node was focused, we do not need to post
                // logging
                _logger.Debug("e.OldNode=null, cancel");

                // cancel
                return;
            }

            // check if we focus same node as before
            if (e.OldNode == e.Node)
            {
                // logging
                _logger.Debug("e.OldNode=e.Node, cancel");

                // cancel
                return;
            }

            // save changes before switching to next node and do not switch if post failes
            e.CanFocus = qryFaCmSub.Post();

            // logging
            _logger.Debug("done");
        }

        private void treUebersicht_CustomDrawNodeCell(Object sender, CustomDrawNodeCellEventArgs e)
        {
            // check which column
            if (e.Column.FieldName == colTreeDatumEvaluation.FieldName ||
                e.Column.FieldName == colTreeBegruendung.FieldName)
            {
                // DatumEvaluation or Begruendung column, can only be edited if not locked, setup cell
                e.Column.OptionsColumn.AllowEdit = qryFaCmSub.CanUpdate;
                e.Appearance.BackColor = !qryFaCmSub.CanUpdate ? Color.Transparent : e.Column.AppearanceCell.BackColor;
            }
            else if (e.Column.FieldName == colTreeEvaluation.FieldName)
            {
                // Evaluation column, can only be edited if not Massnahme
                bool istMassnahme = Convert.ToBoolean(e.Node.GetValue("IstMassnahme"));

                // setup cell
                e.Column.OptionsColumn.AllowEdit = !istMassnahme && qryFaCmSub.CanUpdate;
                e.Appearance.BackColor = istMassnahme || !qryFaCmSub.CanUpdate ? Color.Transparent : e.Column.AppearanceCell.BackColor;
                e.Handled = istMassnahme;
            }
            else if (e.Column.FieldName == colTreeErledigt.FieldName)
            {
                // Erledigt column, can only be edited if Massnahme
                var istMassnahme = Convert.ToBoolean(e.Node.GetValue("IstMassnahme"));

                // setup column
                e.Column.OptionsColumn.AllowEdit = istMassnahme && qryFaCmSub.CanUpdate;
                e.Appearance.BackColor = istMassnahme && qryFaCmSub.CanUpdate ? e.Column.AppearanceCell.BackColor : Color.Transparent;
                e.Handled = !istMassnahme;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override Object GetContextValue(string fieldName)
        {
            // logging
            _logger.Debug("call");

            switch (fieldName.ToUpper())
            {
                case "FACASEMANAGEMENTID":
                    // validate first
                    if (qryFaCaseManagementMain.IsEmpty)
                    {
                        return -1;
                    }

                    return qryFaCaseManagementMain["FaCaseManagementID"];

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "BAPERSONID":
                    // validate first
                    return qryFaCaseManagementMain.IsEmpty ? FaUtils.GetBaPersonIDFromFaLeistungID(_faLeistungID) : qryFaCaseManagementMain["BaPersonID"];
            }

            return base.GetContextValue(fieldName);
        }

        public void Init(string titleName, Image titleImage, int faLeistungID, bool isLeistungClosed)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("faLeistungID={0}, isLeistungClosed={1}", faLeistungID, isLeistungClosed);

            // reset flags
            _doNotCheckEvaluation = false;

            // validate
            if (faLeistungID < 1)
            {
                // logging
                _logger.Debug("no valid FaLeistungID, cancel");

                // do not continue
                qryFaCaseManagementMain.CanUpdate = false;
                qryFaCmSub.CanUpdate = false;
                qryFaCaseManagementMain.EnableBoundFields(qryFaCaseManagementMain.CanUpdate);
                qryFaCmSub.EnableBoundFields(qryFaCmSub.CanUpdate);

                // disable button
                btnDeleteEval.Enabled = false;

                // cancel
                return;
            }

            // allow changes
            qryFaCaseManagementMain.CanUpdate = !isLeistungClosed;
            qryFaCmSub.CanUpdate = !isLeistungClosed;

            // apply values
            _faLeistungID = faLeistungID;
            picTitel.Image = titleImage;

            // fill data
            qryFaCaseManagementMain.Fill(@"
                SELECT -- all CM columns
                       CM.*,
                       -- additional columns
                       ZustaendigSA = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
                       BaPersonID   = LEI.BaPersonID
                FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = CM.FaLeistungID
                WHERE CM.FaLeistungID = {0} AND
                      CM.IstHaupteintrag = 1;", faLeistungID);

            // fill data
            qryFaCmSub.Fill(@"
                SELECT -- all CM columns
                       CM.*,
                       -- additional columns
                       Element       = CASE WHEN CM.IstRahmenziel = 1 AND CM.IstHandlungsziel = 0 AND CM.IstMassnahme = 0 THEN {1}
                                            WHEN CM.IstRahmenziel = 0 AND CM.IstHandlungsziel = 1 AND CM.IstMassnahme = 0 THEN {2}
                                            WHEN CM.IstRahmenziel = 0 AND CM.IstHandlungsziel = 0 AND CM.IstMassnahme = 1 THEN {3}
                                            ELSE '????'
                                       END,
                       Lebensbereich = dbo.fnGetLOVMLText('FaLebensbereich', CM.LebensbereichCode, {4})
                FROM dbo.FaCaseManagement CM WITH (READUNCOMMITTED)
                WHERE CM.FaLeistungID = {0} AND
                      CM.IstHaupteintrag = 0 AND
                      (CM.IstRahmenziel = 1 OR CM.IstHandlungsziel = 1 OR CM.IstMassnahme = 1)
                ORDER BY CM.Datum;", _faLeistungID, _rahmenzielText, _handlungszielText, _massnahmeText, Session.User.LanguageCode);

            // expand all entries
            ExpandAllEntries();

            // select last entry
            qryFaCmSub.Last();

            // check if any data found
            if (qryFaCaseManagementMain.Count < 1 || DBUtil.IsEmpty(qryFaCaseManagementMain["ErstellungZV"]))
            {
                // no data yet, cannot continue
                qryFaCaseManagementMain.CanUpdate = false;
                qryFaCmSub.CanUpdate = false;
            }

            // update states of fields
            qryFaCaseManagementMain.EnableBoundFields(qryFaCaseManagementMain.CanUpdate);
            qryFaCmSub.EnableBoundFields(qryFaCmSub.CanUpdate);

            // handle button
            btnDeleteEval.Enabled = qryFaCmSub.CanUpdate;

            // logging
            _logger.Debug("done");
        }

        public override void OnMoveFirst()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qryFaCmSub.First();

            // logging
            _logger.Debug("done");
        }

        public override void OnMoveLast()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qryFaCmSub.Last();

            // logging
            _logger.Debug("done");
        }

        public override void OnMoveNext()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qryFaCmSub.Next();

            // logging
            _logger.Debug("done");
        }

        public override void OnMovePrevious()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qryFaCmSub.Previous();

            // logging
            _logger.Debug("done");
        }

        public override void OnRefreshData()
        {
            // logging
            _logger.Debug("enter");

            // global data
            ActiveSQLQuery.Refresh();

            // tab depending data
            qryFaCmSub.Refresh();

            // expand all entries
            ExpandAllEntries();

            // logging
            _logger.Debug("done");
        }

        public override bool OnSaveData()
        {
            // logging
            _logger.Debug("enter");

            // global data
            if (!ActiveSQLQuery.Post())
            {
                throw new KissCancelException();
            }

            // end current edit
            EndEditColumnEdit();

            // save pending changes on sub-query
            bool successfullyPosted = qryFaCmSub.Post();

            // logging
            _logger.DebugFormat("successfullyPosted='{0}'", successfullyPosted);
            _logger.Debug("done");

            // done
            return successfullyPosted;
        }

        public override void OnUndoDataChanges()
        {
            // logging
            _logger.Debug("enter");

            // global data
            ActiveSQLQuery.Cancel();

            // tab depending data
            qryFaCmSub.Cancel();

            // logging
            _logger.Debug("done");
        }

        #endregion

        #region Private Methods

        private void EndEditColumnEdit()
        {
            // logging
            _logger.Debug("enter");

            // HACK: end column edit by switching focus to another column and back again
            TreeListColumn colFocused = treUebersicht.FocusedColumn;
            treUebersicht.FocusedColumn = colTreeZielMassnahme;
            treUebersicht.FocusedColumn = colFocused;

            // logging
            _logger.Debug("done");
        }

        private void ExpandAllEntries()
        {
            // logging
            _logger.Debug("enter");

            treUebersicht.ExpandAll();
            treUebersicht.Focus();

            // logging
            _logger.Debug("done");
        }

        #endregion

        #endregion
    }
}