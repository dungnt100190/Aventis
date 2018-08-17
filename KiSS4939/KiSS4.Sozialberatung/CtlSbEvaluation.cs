using Kiss.Infrastructure;
using KiSS4.Common.PI;
using KiSS4.DB;
using KiSS4.Gui;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace KiSS4.Sozialberatung
{
    /// <summary>
    /// Control, used for evaluation of Sozial Beratung
    /// </summary>
    public class CtlSbEvaluation : KiSS4.Gui.KissUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly string _handlungszielText = "";
        private readonly string _massnahmeText = "";
        private readonly string _rahmenzielText = "";

        #endregion

        #region Private Fields

        private bool _doNotCheckEvaluation = false; // flag if BeforePost shall check evaluation
        private int _faLeistungID = -1;
        private KiSS4.Gui.KissButton btnCollapseAll;
        private KiSS4.Gui.KissButton btnDeleteEval;
        private KiSS4.Gui.KissButton btnExpandAll;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeBegruendung;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeBisWann;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeDatum;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeDatumEvaluation;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeElement;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeErledigt;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeEvaluation;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeIndikatoren;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeKommentar;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeLebensbereich;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeWer;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTreeZielMassnahme;
        private System.ComponentModel.IContainer components;
        private KiSS4.Dokument.KissDocumentButton docEvaluation;
        private KiSS4.Gui.KissDateEdit edtErstellungZV;
        private KiSS4.Gui.KissTextEdit edtGrundsatzziel;
        private KiSS4.Gui.KissTextEdit edtZustaendigerSA;
        private KiSS4.Gui.KissLabel lblErstellungZV;
        private KiSS4.Gui.KissLabel lblGrundsatzziel;
        private KiSS4.Gui.KissLabel lblTitel;
        private KiSS4.Gui.KissLabel lblZustaendigerSA;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.Panel panTitel;
        private System.Windows.Forms.Panel panTopInfo;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qrySbSbSub;
        private KiSS4.DB.SqlQuery qrySbSozialberatungMain;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repCheckErledigt;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repDatumEvaluation;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repTextBecauseOfNoDateColumnEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repTextBegruendung;
        private KiSS4.Gui.KissTree treUebersicht;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlSbEvaluation"/> class.
        /// </summary>
        public CtlSbEvaluation()
        {
            this.InitializeComponent();

            // logging
            _logger.Debug("enter");

            // request strings
            _rahmenzielText = KissMsg.GetMLMessage(this.Name, "RahmenzielText", "Rahmenziel");
            _handlungszielText = KissMsg.GetMLMessage(this.Name, "HandlungszielText", "Handlungsziel");
            _massnahmeText = KissMsg.GetMLMessage(this.Name, "MassnahmeText", "Massnahme");

            // make tree editable
            this.treUebersicht.OptionsBehavior.Editable = true;

            // setup column
            KissGrid grd = new KissGrid();

            colTreeEvaluation.ColumnEdit = grd.GetLOVLookUpEdit("FaErreichungsgrad", true);
            colTreeEvaluation.ColumnEdit.Appearance.BackColor = Color.AliceBlue;
            colTreeEvaluation.ColumnEdit.Appearance.ForeColor = Color.Black;
            colTreeEvaluation.ColumnEdit.Appearance.Options.UseForeColor = true;
            colTreeEvaluation.ColumnEdit.AppearanceFocused.ForeColor = Color.Black;
            colTreeEvaluation.ColumnEdit.AppearanceFocused.Options.UseForeColor = true;

            // init with default values
            this.Init(null, null, -1, false);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlSbEvaluation));
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
            this.qrySbSbSub = new KiSS4.DB.SqlQuery(this.components);
            this.qrySbSozialberatungMain = new KiSS4.DB.SqlQuery(this.components);
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
            ((System.ComponentModel.ISupportInitialize)(this.qrySbSbSub)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySbSozialberatungMain)).BeginInit();
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
            this.lblTitel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitel.LabelStyle = KiSS4.Gui.LabelStyleType.TitleLabel;
            this.lblTitel.Location = new System.Drawing.Point(35, 7);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(680, 16);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Evaluation Sozialberatung";
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
            this.edtZustaendigerSA.DataSource = this.qrySbSozialberatungMain;
            this.edtZustaendigerSA.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtZustaendigerSA.Location = new System.Drawing.Point(124, 9);
            this.edtZustaendigerSA.Name = "edtZustaendigerSA";
            this.edtZustaendigerSA.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
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
            this.edtErstellungZV.DataSource = this.qrySbSozialberatungMain;
            this.edtErstellungZV.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtErstellungZV.EditValue = null;
            this.edtErstellungZV.Location = new System.Drawing.Point(124, 39);
            this.edtErstellungZV.Name = "edtErstellungZV";
            this.edtErstellungZV.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErstellungZV.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtErstellungZV.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErstellungZV.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErstellungZV.Properties.Appearance.Options.UseBackColor = true;
            this.edtErstellungZV.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErstellungZV.Properties.Appearance.Options.UseFont = true;
            this.edtErstellungZV.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtErstellungZV.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
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
            this.edtGrundsatzziel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtGrundsatzziel.DataMember = "Grundsatzziel";
            this.edtGrundsatzziel.DataSource = this.qrySbSozialberatungMain;
            this.edtGrundsatzziel.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtGrundsatzziel.Location = new System.Drawing.Point(124, 69);
            this.edtGrundsatzziel.Name = "edtGrundsatzziel";
            this.edtGrundsatzziel.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
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
            this.docEvaluation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.docEvaluation.Context = "SB_Evaluation_Evaluation";
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
            this.treUebersicht.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.treUebersicht.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.treUebersicht.Appearance.EvenRow.Options.UseBackColor = true;
            this.treUebersicht.Appearance.EvenRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.treUebersicht.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treUebersicht.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treUebersicht.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.treUebersicht.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treUebersicht.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
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
            this.treUebersicht.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
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
            this.treUebersicht.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treUebersicht.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.treUebersicht.Appearance.HorzLine.Options.UseBackColor = true;
            this.treUebersicht.Appearance.HorzLine.Options.UseForeColor = true;
            this.treUebersicht.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
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
            this.treUebersicht.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.treUebersicht.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.treUebersicht.Appearance.VertLine.Options.UseBackColor = true;
            this.treUebersicht.Appearance.VertLine.Options.UseForeColor = true;
            this.treUebersicht.Appearance.VertLine.Options.UseTextOptions = true;
            this.treUebersicht.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.treUebersicht.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
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
            this.treUebersicht.DataSource = this.qrySbSbSub;
            this.treUebersicht.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treUebersicht.ImageIndexFieldName = "IconID";
            this.treUebersicht.KeyFieldName = "SbSozialberatungID";
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
            this.treUebersicht.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treUebersicht_CustomDrawNodeCell);
            this.treUebersicht.BeforeFocusNode += new DevExpress.XtraTreeList.BeforeFocusNodeEventHandler(this.treUebersicht_BeforeFocusNode);
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
            this.btnExpandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExpandAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpandAll.IconID = 70;
            this.btnExpandAll.Location = new System.Drawing.Point(659, 6);
            this.btnExpandAll.Name = "btnExpandAll";
            this.btnExpandAll.Size = new System.Drawing.Size(24, 24);
            this.btnExpandAll.TabIndex = 0;
            this.btnExpandAll.UseCompatibleTextRendering = true;
            this.btnExpandAll.UseVisualStyleBackColor = false;
            this.btnExpandAll.Click += new System.EventHandler(this.btnExpandAll_Click);
            //
            // btnCollapseAll
            //
            this.btnCollapseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollapseAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollapseAll.IconID = 71;
            this.btnCollapseAll.Location = new System.Drawing.Point(689, 6);
            this.btnCollapseAll.Margin = new System.Windows.Forms.Padding(3, 6, 9, 3);
            this.btnCollapseAll.Name = "btnCollapseAll";
            this.btnCollapseAll.Size = new System.Drawing.Size(24, 24);
            this.btnCollapseAll.TabIndex = 1;
            this.btnCollapseAll.UseCompatibleTextRendering = true;
            this.btnCollapseAll.UseVisualStyleBackColor = false;
            this.btnCollapseAll.Click += new System.EventHandler(this.btnCollapseAll_Click);
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
            this.btnDeleteEval.Click += new System.EventHandler(this.btnDeleteEval_Click);
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
            // qrySbSbSub
            //
            this.qrySbSbSub.HostControl = this;
            this.qrySbSbSub.TableName = "SbSozialberatung";
            this.qrySbSbSub.BeforePost += new System.EventHandler(this.qrySbSbSub_BeforePost);
            //
            // qrySbSozialberatungMain
            //
            this.qrySbSozialberatungMain.HostControl = this;
            this.qrySbSozialberatungMain.TableName = "SbSozialberatung";
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
            this.repDatumEvaluation.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
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
            // CtlSbEvaluation
            //
            this.ActiveSQLQuery = this.qrySbSozialberatungMain;
            this.AutoRefresh = false;
            this.Controls.Add(this.treUebersicht);
            this.Controls.Add(this.panTopInfo);
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.panBottom);
            this.Name = "CtlSbEvaluation";
            this.Size = new System.Drawing.Size(722, 596);
            this.Load += new System.EventHandler(this.CtlSbEvaluation_Load);
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
            ((System.ComponentModel.ISupportInitialize)(this.qrySbSbSub)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrySbSozialberatungMain)).EndInit();
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

        private void btnCollapseAll_Click(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            this.treUebersicht.CollapseAll();
            this.treUebersicht.Focus();

            // logging
            _logger.Debug("done");
        }

        private void btnDeleteEval_Click(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // check if button can be used
            if (!qrySbSbSub.CanUpdate)
            {
                // logging
                _logger.Debug("updating is not allowed");

                // disable button
                btnDeleteEval.Enabled = false;

                // cancel
                return;
            }

            // confirm first
            if (!KissMsg.ShowQuestion(this.Name, "ConfirmDeleteEval", "Soll die Evaluation für den aktuellen Eintrag wirklich gelöscht werden?", false))
            {
                // logging
                _logger.Debug("cancel by user");

                // canceled by user
                return;
            }

            // reset columns
            qrySbSbSub["EvaluationCode"] = DBNull.Value;
            qrySbSbSub["EvaluationDatum"] = DBNull.Value;
            qrySbSbSub["EvaluationBegruendung"] = DBNull.Value;
            qrySbSbSub["Erledigt"] = 0;

            try
            {
                // set flag
                _doNotCheckEvaluation = true;

                // save changes (without checking evaluation)
                qrySbSbSub.Post();
            }
            finally
            {
                // reset flag
                _doNotCheckEvaluation = false;
            }

            // logging
            _logger.Debug("done");
        }

        private void btnExpandAll_Click(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            this.ExpandAllEntries();

            // logging
            _logger.Debug("done");
        }

        private void CtlSbEvaluation_Load(object sender, System.EventArgs e)
        {
            // attach events to column-edits
            colTreeDatumEvaluation.ColumnEdit.EditValueChanged += new System.EventHandler(repositoryItem_EditValueChanged);
            colTreeEvaluation.ColumnEdit.EditValueChanged += new System.EventHandler(repositoryItem_EditValueChanged);
            colTreeErledigt.ColumnEdit.EditValueChanged += new System.EventHandler(repositoryItem_EditValueChanged);
            colTreeBegruendung.ColumnEdit.EditValueChanged += new System.EventHandler(repositoryItem_EditValueChanged);
        }

        private void qrySbSbSub_BeforePost(object sender, System.EventArgs e)
        {
            // logging
            _logger.Debug("enter");

            // END EDIT:
            this.EndEditColumnEdit();

            // do it (required to apply change visible)
            ApplicationFacade.DoEvents();

            // check if need to handle evaluation
            if (this._doNotCheckEvaluation)
            {
                // logging
                _logger.Debug("do not check evaluation, allow post");

                // done
                return;
            }

            // get if column is Massnahme
            bool istMassnahme = Convert.ToBoolean(qrySbSbSub["IstMassnahme"]);

            // MUST FIELDS:
            // EvaluationDatum
            if (DBUtil.IsEmpty(qrySbSbSub[colTreeDatumEvaluation.FieldName]))
            {
                // show message
                KissMsg.ShowInfo(this.Name, "EvaluationDatumIsEmpty", "Das Feld 'Datum Evaluation' muss ausgefüllt werden.");

                // focus
                treUebersicht.FocusedColumn = colTreeDatumEvaluation;

                // cancel
                throw new KissCancelException();
            }

            // Evaluation if not Massnahme
            if (!istMassnahme && DBUtil.IsEmpty(qrySbSbSub[colTreeEvaluation.FieldName]))
            {
                // show message
                KissMsg.ShowInfo(this.Name, "EvaluationEvalIsEmpty", "Das Feld 'Evaluation' muss bei einem Rahmenziel oder Handlungsziel ausgefüllt werden.");

                // focus
                treUebersicht.FocusedColumn = colTreeEvaluation;

                // cancel
                throw new KissCancelException();
            }

            // Erledigt if Massnahme
            if (istMassnahme && (DBUtil.IsEmpty(qrySbSbSub[colTreeErledigt.FieldName]) || !Convert.ToBoolean(qrySbSbSub[colTreeErledigt.FieldName])))
            {
                // show message
                KissMsg.ShowInfo(this.Name, "EvaluationErledigtIsEmpty", "Das Feld 'Erledigt' muss bei einer Massnahme ausgefüllt werden.");

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
            qrySbSbSub.RowModified = true;

            // logging
            _logger.Debug("done");
        }

        private void treUebersicht_BeforeFocusNode(Object sender, DevExpress.XtraTreeList.BeforeFocusNodeEventArgs e)
        {
            // logging
            _logger.Debug("enter");
            _logger.DebugFormat("e.OldNode='{0}', e.Node='{1}', treUebersicht.FocusedNode='{2}'", e.OldNode, e.Node, treUebersicht.FocusedNode);

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
            e.CanFocus = qrySbSbSub.Post();

            // logging
            _logger.Debug("done");
        }

        private void treUebersicht_CustomDrawNodeCell(Object sender, DevExpress.XtraTreeList.CustomDrawNodeCellEventArgs e)
        {
            // check which column
            if (e.Column.FieldName == colTreeDatumEvaluation.FieldName ||
                e.Column.FieldName == colTreeBegruendung.FieldName)
            {
                // DatumEvaluation or Begruendung column, can only be edited if not locked, setup cell
                e.Column.OptionsColumn.AllowEdit = qrySbSbSub.CanUpdate;
                e.Appearance.BackColor = !qrySbSbSub.CanUpdate ? Color.Transparent : e.Column.AppearanceCell.BackColor;
            }
            else if (e.Column.FieldName == colTreeEvaluation.FieldName)
            {
                // Evaluation column, can only be edited if not Massnahme
                bool istMassnahme = Convert.ToBoolean(e.Node.GetValue("IstMassnahme"));

                // setup cell
                e.Column.OptionsColumn.AllowEdit = !istMassnahme && qrySbSbSub.CanUpdate;
                e.Appearance.BackColor = istMassnahme || !qrySbSbSub.CanUpdate ? Color.Transparent : e.Column.AppearanceCell.BackColor;
                e.Handled = istMassnahme;
            }
            else if (e.Column.FieldName == colTreeErledigt.FieldName)
            {
                // Erledigt column, can only be edited if Massnahme
                bool istMassnahme = Convert.ToBoolean(e.Node.GetValue("IstMassnahme"));

                // setup column
                e.Column.OptionsColumn.AllowEdit = istMassnahme && qrySbSbSub.CanUpdate;
                e.Appearance.BackColor = istMassnahme && qrySbSbSub.CanUpdate ? e.Column.AppearanceCell.BackColor : Color.Transparent;
                e.Handled = !istMassnahme;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string fieldName)
        {
            // logging
            _logger.Debug("call");

            switch (fieldName.ToUpper())
            {
                case "SBSOZIALBERATUNGID":
                    // validate first
                    if (qrySbSozialberatungMain.IsEmpty)
                    {
                        return -1;
                    }

                    return qrySbSozialberatungMain["SbSozialberatungID"];

                case "FALEISTUNGID":
                    return _faLeistungID;

                case "BAPERSONID":
                    // validate first
                    return qrySbSozialberatungMain.IsEmpty ? FaUtils.GetBaPersonIDFromFaLeistungID(_faLeistungID) : qrySbSozialberatungMain["BaPersonID"];
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
                qrySbSozialberatungMain.CanUpdate = false;
                qrySbSbSub.CanUpdate = false;
                qrySbSozialberatungMain.EnableBoundFields(qrySbSozialberatungMain.CanUpdate);
                qrySbSbSub.EnableBoundFields(qrySbSbSub.CanUpdate);

                // disable button
                btnDeleteEval.Enabled = false;

                // cancel
                return;
            }

            // allow changes
            qrySbSozialberatungMain.CanUpdate = !isLeistungClosed;
            qrySbSbSub.CanUpdate = !isLeistungClosed;

            // apply values
            _faLeistungID = faLeistungID;
            picTitel.Image = titleImage;

            // fill data
            qrySbSozialberatungMain.Fill(@"
                SELECT -- all SB columns
                       SB.*,
                       -- additional columns
                       ZustaendigSA = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL),
                       BaPersonID   = LEI.BaPersonID
                FROM dbo.SbSozialberatung SB WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = SB.FaLeistungID
                WHERE SB.FaLeistungID = {0} AND
                      SB.IstHaupteintrag = 1;", faLeistungID);

            // fill data
            qrySbSbSub.Fill(@"
                SELECT -- all SB columns
                       SB.*,
                       -- additional columns
                       Element       = CASE WHEN SB.IstRahmenziel = 1 AND SB.IstHandlungsziel = 0 AND SB.IstMassnahme = 0 THEN {1}
                                            WHEN SB.IstRahmenziel = 0 AND SB.IstHandlungsziel = 1 AND SB.IstMassnahme = 0 THEN {2}
                                            WHEN SB.IstRahmenziel = 0 AND SB.IstHandlungsziel = 0 AND SB.IstMassnahme = 1 THEN {3}
                                            ELSE '????'
                                       END,
                       Lebensbereich = dbo.fnGetLOVMLText('FaLebensbereich', SB.LebensbereichCode, {4})
                FROM dbo.SbSozialberatung SB WITH (READUNCOMMITTED)
                WHERE SB.FaLeistungID = {0} AND
                      SB.IstHaupteintrag = 0 AND
                      (SB.IstRahmenziel = 1 OR SB.IstHandlungsziel = 1 OR SB.IstMassnahme = 1)
                ORDER BY SB.Datum;", _faLeistungID, _rahmenzielText, _handlungszielText, _massnahmeText, Session.User.LanguageCode);

            // expand all entries
            ExpandAllEntries();

            // select last entry
            qrySbSbSub.Last();

            // check if any data found
            if (qrySbSozialberatungMain.Count < 1 || DBUtil.IsEmpty(qrySbSozialberatungMain["ErstellungZV"]))
            {
                // no data yet, cannot continue
                qrySbSozialberatungMain.CanUpdate = false;
                qrySbSbSub.CanUpdate = false;
            }

            // update states of fields
            qrySbSozialberatungMain.EnableBoundFields(qrySbSozialberatungMain.CanUpdate);
            qrySbSbSub.EnableBoundFields(qrySbSbSub.CanUpdate);

            // handle button
            btnDeleteEval.Enabled = qrySbSbSub.CanUpdate;

            // logging
            _logger.Debug("done");
        }

        public override void OnMoveFirst()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qrySbSbSub.First();

            // logging
            _logger.Debug("done");
        }

        public override void OnMoveLast()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qrySbSbSub.Last();

            // logging
            _logger.Debug("done");
        }

        public override void OnMoveNext()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qrySbSbSub.Next();

            // logging
            _logger.Debug("done");
        }

        public override void OnMovePrevious()
        {
            // logging
            _logger.Debug("enter");

            // tab depending data
            qrySbSbSub.Previous();

            // logging
            _logger.Debug("done");
        }

        public override void OnRefreshData()
        {
            // logging
            _logger.Debug("enter");

            // global data
            this.ActiveSQLQuery.Refresh();

            // tab depending data
            qrySbSbSub.Refresh();

            // expand all entries
            this.ExpandAllEntries();

            // logging
            _logger.Debug("done");
        }

        public override bool OnSaveData()
        {
            // logging
            _logger.Debug("enter");

            // global data
            if (!this.ActiveSQLQuery.Post())
            {
                throw new KissCancelException();
            }

            // end current edit
            this.EndEditColumnEdit();

            // save pending changes on sub-query
            bool successfullyPosted = qrySbSbSub.Post();

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
            this.ActiveSQLQuery.Cancel();

            // tab depending data
            qrySbSbSub.Cancel();

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
            DevExpress.XtraTreeList.Columns.TreeListColumn colFocused = treUebersicht.FocusedColumn;
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