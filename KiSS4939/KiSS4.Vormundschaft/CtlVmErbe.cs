using System;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Vormundschaft
{
    /// <summary>
    /// Summary description for CtlVmErbe.
    /// </summary>
    public class CtlVmErbe : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int _faLeistungId = 0;
        private object _vmErbschaftsdienstId = null;
        private object _vmSiegelungId = null;
        private object _vmTestamentId = null;
        private KiSS4.Gui.KissButton btnAutoNr;
        private KiSS4.Gui.KissButton btnDown;
        private KiSS4.Gui.KissButton btnErbenTransfer;
        private KiSS4.Gui.KissButton btnLeft;
        private KiSS4.Gui.KissButton btnRight;
        private KiSS4.Gui.KissButton btnUp;
        private DevExpress.XtraGrid.Columns.GridColumn colErbAnteil;
        private DevExpress.XtraGrid.Columns.GridColumn colErbCodierung;
        private DevExpress.XtraGrid.Columns.GridColumn colTestamentEroeffnungNr;
        private DevExpress.XtraGrid.Columns.GridColumn colTestamentEroeffnungStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTestamentEroeffnungVersandart;
        private DevExpress.XtraGrid.Columns.GridColumn colTestamentEroeffnungVersandDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtAnrede;
        private KiSS4.Gui.KissRTFEdit edtBemerkung;
        private KiSS4.Gui.KissCalcEdit edtErbanteilDividend;
        private KiSS4.Gui.KissCalcEdit edtErbanteilDivisor;
        private KiSS4.Gui.KissTextEdit edtErbCodierung;
        private KiSS4.Gui.KissMemoEdit edtErgaenzung;
        private KiSS4.Gui.KissTextEdit edtFamilienNamen;
        private KiSS4.Gui.KissTextEdit edtGeburtsdatum;
        private KiSS4.Gui.KissMemoEdit edtKontaktAdresse;
        private KiSS4.Gui.KissTextEdit edtLand;
        private KiSS4.Gui.KissTextEdit edtOrt;
        private KiSS4.Gui.KissTextEdit edtStrasse;
        private KiSS4.Gui.KissCalcEdit edtTestamentEroeffnungNr;
        private KiSS4.Gui.KissTextEdit edtTestamentEroeffnungStatus;
        private KiSS4.Gui.KissTextEdit edtTestamentEroeffnungVersandart;
        private KiSS4.Gui.KissDateEdit edtTestamentEroeffnungVersandDatum;
        private KiSS4.Gui.KissTextEdit edtTitel;
        private KiSS4.Gui.KissTextEdit edtTitel2;
        private KiSS4.Gui.KissTextEdit edtVornamen;
        private KiSS4.Gui.KissTextEdit edtZusatz;
        private KiSS4.Gui.KissGrid grdVmErbe;
        private DevExpress.XtraGrid.Views.Grid.GridView grvVmErbe;
        private KiSS4.Gui.KissLabel kissLabel56;
        private KiSS4.Gui.KissLabel kissLabel7;
        private KiSS4.Gui.KissLabel lblAnrede;
        private KiSS4.Gui.KissLabel lblBemerkung;
        private KiSS4.Gui.KissLabel lblErbanteil;
        private KiSS4.Gui.KissLabel lblErbcode;
        private KiSS4.Gui.KissLabel lblErgaenzung;
        private KiSS4.Gui.KissLabel lblFamilienNamen;
        private KiSS4.Gui.KissLabel lblGeburtsdatum;
        private KiSS4.Gui.KissLabel lblLand;
        private KiSS4.Gui.KissLabel lblOrt;
        private KiSS4.Gui.KissLabel lblSlash;
        private KiSS4.Gui.KissLabel lblStrasse;
        private KiSS4.Gui.KissLabel lblTestamentEroeffnungNr;
        private KiSS4.Gui.KissLabel lblTestamentEroeffnungStatus;
        private KiSS4.Gui.KissLabel lblTestamentEroeffnungVersandart;
        private KiSS4.Gui.KissLabel lblTestamentEroeffnungVersandDatum;
        private System.Windows.Forms.Label lblTitel;
        private KiSS4.Gui.KissLabel lblTitel2;
        private KiSS4.Gui.KissLabel lblVornamen;
        private KiSS4.Gui.KissLabel lblZusatz;
        private System.Windows.Forms.PictureBox picTitel;
        private KiSS4.DB.SqlQuery qryVmErbe;

        #endregion

        #endregion

        #region Constructors

        public CtlVmErbe()
        {
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
            this.components = new System.ComponentModel.Container();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlVmErbe));
            this.qryVmErbe = new KiSS4.DB.SqlQuery(this.components);
            this.lblTitel = new System.Windows.Forms.Label();
            this.picTitel = new System.Windows.Forms.PictureBox();
            this.btnUp = new KiSS4.Gui.KissButton();
            this.btnDown = new KiSS4.Gui.KissButton();
            this.btnErbenTransfer = new KiSS4.Gui.KissButton();
            this.grdVmErbe = new KiSS4.Gui.KissGrid();
            this.grvVmErbe = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTestamentEroeffnungStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTestamentEroeffnungNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErbCodierung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTestamentEroeffnungVersandDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTestamentEroeffnungVersandart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErbAnteil = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnRight = new KiSS4.Gui.KissButton();
            this.btnLeft = new KiSS4.Gui.KissButton();
            this.edtErgaenzung = new KiSS4.Gui.KissMemoEdit();
            this.lblErgaenzung = new KiSS4.Gui.KissLabel();
            this.edtBemerkung = new KiSS4.Gui.KissRTFEdit();
            this.lblBemerkung = new KiSS4.Gui.KissLabel();
            this.edtErbanteilDivisor = new KiSS4.Gui.KissCalcEdit();
            this.edtErbanteilDividend = new KiSS4.Gui.KissCalcEdit();
            this.lblSlash = new KiSS4.Gui.KissLabel();
            this.lblErbanteil = new KiSS4.Gui.KissLabel();
            this.edtErbCodierung = new KiSS4.Gui.KissTextEdit();
            this.lblErbcode = new KiSS4.Gui.KissLabel();
            this.edtGeburtsdatum = new KiSS4.Gui.KissTextEdit();
            this.lblGeburtsdatum = new KiSS4.Gui.KissLabel();
            this.edtKontaktAdresse = new KiSS4.Gui.KissMemoEdit();
            this.kissLabel56 = new KiSS4.Gui.KissLabel();
            this.edtLand = new KiSS4.Gui.KissTextEdit();
            this.edtStrasse = new KiSS4.Gui.KissTextEdit();
            this.edtOrt = new KiSS4.Gui.KissTextEdit();
            this.lblLand = new KiSS4.Gui.KissLabel();
            this.lblStrasse = new KiSS4.Gui.KissLabel();
            this.lblOrt = new KiSS4.Gui.KissLabel();
            this.edtAnrede = new KiSS4.Gui.KissTextEdit();
            this.edtFamilienNamen = new KiSS4.Gui.KissTextEdit();
            this.edtVornamen = new KiSS4.Gui.KissTextEdit();
            this.lblAnrede = new KiSS4.Gui.KissLabel();
            this.lblFamilienNamen = new KiSS4.Gui.KissLabel();
            this.lblVornamen = new KiSS4.Gui.KissLabel();
            this.edtTitel2 = new KiSS4.Gui.KissTextEdit();
            this.edtTestamentEroeffnungStatus = new KiSS4.Gui.KissTextEdit();
            this.edtTestamentEroeffnungVersandart = new KiSS4.Gui.KissTextEdit();
            this.edtTestamentEroeffnungVersandDatum = new KiSS4.Gui.KissDateEdit();
            this.edtTestamentEroeffnungNr = new KiSS4.Gui.KissCalcEdit();
            this.lblTestamentEroeffnungStatus = new KiSS4.Gui.KissLabel();
            this.lblTestamentEroeffnungNr = new KiSS4.Gui.KissLabel();
            this.lblTestamentEroeffnungVersandDatum = new KiSS4.Gui.KissLabel();
            this.lblTestamentEroeffnungVersandart = new KiSS4.Gui.KissLabel();
            this.btnAutoNr = new KiSS4.Gui.KissButton();
            this.edtZusatz = new KiSS4.Gui.KissTextEdit();
            this.lblZusatz = new KiSS4.Gui.KissLabel();
            this.edtTitel = new KiSS4.Gui.KissTextEdit();
            this.kissLabel7 = new KiSS4.Gui.KissLabel();
            this.lblTitel2 = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmErbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmErbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErgaenzung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErgaenzung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbanteilDivisor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbanteilDividend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSlash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErbanteil)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbCodierung.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErbcode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktAdresse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel56)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLand.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnrede.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFamilienNamen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornamen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnrede)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFamilienNamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornamen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentEroeffnungStatus.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentEroeffnungVersandart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentEroeffnungVersandDatum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentEroeffnungNr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentEroeffnungStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentEroeffnungNr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentEroeffnungVersandDatum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentEroeffnungVersandart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel2)).BeginInit();
            this.SuspendLayout();
            //
            // qryVmErbe
            //
            this.qryVmErbe.CanDelete = true;
            this.qryVmErbe.CanInsert = true;
            this.qryVmErbe.CanUpdate = true;
            this.qryVmErbe.HostControl = this;
            this.qryVmErbe.TableName = "VmErbe";
            this.qryVmErbe.BeforePost += new System.EventHandler(this.qryVmErbe_BeforePost);
            this.qryVmErbe.PositionChanged += new System.EventHandler(this.qryVmErbe_PositionChanged);
            this.qryVmErbe.AfterPost += new System.EventHandler(this.qryVmErbe_AfterPost);
            //
            // lblTitel
            //
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 13;
            this.lblTitel.Text = "Titel";
            //
            // picTitel
            //
            this.picTitel.Image = ((System.Drawing.Image)(resources.GetObject("picTitel.Image")));
            this.picTitel.Location = new System.Drawing.Point(10, 9);
            this.picTitel.Name = "picTitel";
            this.picTitel.Size = new System.Drawing.Size(25, 20);
            this.picTitel.TabIndex = 12;
            this.picTitel.TabStop = false;
            //
            // btnUp
            //
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.IconID = 16;
            this.btnUp.Location = new System.Drawing.Point(525, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(28, 24);
            this.btnUp.TabIndex = 3;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            //
            // btnDown
            //
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.IconID = 17;
            this.btnDown.Location = new System.Drawing.Point(559, 4);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(28, 24);
            this.btnDown.TabIndex = 4;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            //
            // btnErbenTransfer
            //
            this.btnErbenTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnErbenTransfer.Location = new System.Drawing.Point(606, 4);
            this.btnErbenTransfer.Name = "btnErbenTransfer";
            this.btnErbenTransfer.Size = new System.Drawing.Size(127, 24);
            this.btnErbenTransfer.TabIndex = 5;
            this.btnErbenTransfer.Text = "Erben übernehmen";
            this.btnErbenTransfer.UseVisualStyleBackColor = false;
            this.btnErbenTransfer.Click += new System.EventHandler(this.btnErbenTransfer_Click);
            //
            // grdVmErbe
            //
            this.grdVmErbe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdVmErbe.DataSource = this.qryVmErbe;
            this.grdVmErbe.EmbeddedNavigator.Name = "";
            this.grdVmErbe.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdVmErbe.Location = new System.Drawing.Point(7, 33);
            this.grdVmErbe.MainView = this.grvVmErbe;
            this.grdVmErbe.Name = "grdVmErbe";
            this.grdVmErbe.Size = new System.Drawing.Size(727, 202);
            this.grdVmErbe.TabIndex = 0;
            this.grdVmErbe.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvVmErbe});
            //
            // grvVmErbe
            //
            this.grvVmErbe.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvVmErbe.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmErbe.Appearance.Empty.Options.UseBackColor = true;
            this.grvVmErbe.Appearance.Empty.Options.UseFont = true;
            this.grvVmErbe.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmErbe.Appearance.EvenRow.Options.UseFont = true;
            this.grvVmErbe.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmErbe.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmErbe.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvVmErbe.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvVmErbe.Appearance.FocusedCell.Options.UseFont = true;
            this.grvVmErbe.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvVmErbe.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvVmErbe.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmErbe.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvVmErbe.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvVmErbe.Appearance.FocusedRow.Options.UseFont = true;
            this.grvVmErbe.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvVmErbe.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmErbe.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvVmErbe.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvVmErbe.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmErbe.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmErbe.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvVmErbe.Appearance.GroupRow.Options.UseFont = true;
            this.grvVmErbe.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvVmErbe.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvVmErbe.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvVmErbe.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvVmErbe.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvVmErbe.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvVmErbe.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvVmErbe.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvVmErbe.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmErbe.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvVmErbe.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvVmErbe.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvVmErbe.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvVmErbe.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmErbe.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvVmErbe.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmErbe.Appearance.OddRow.Options.UseFont = true;
            this.grvVmErbe.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvVmErbe.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmErbe.Appearance.Row.Options.UseBackColor = true;
            this.grvVmErbe.Appearance.Row.Options.UseFont = true;
            this.grvVmErbe.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvVmErbe.Appearance.SelectedRow.Options.UseFont = true;
            this.grvVmErbe.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvVmErbe.Appearance.VertLine.Options.UseBackColor = true;
            this.grvVmErbe.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvVmErbe.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTestamentEroeffnungStatus,
            this.colTestamentEroeffnungNr,
            this.colErbCodierung,
            this.colText,
            this.colTestamentEroeffnungVersandDatum,
            this.colTestamentEroeffnungVersandart,
            this.colErbAnteil});
            this.grvVmErbe.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvVmErbe.GridControl = this.grdVmErbe;
            this.grvVmErbe.Name = "grvVmErbe";
            this.grvVmErbe.OptionsBehavior.Editable = false;
            this.grvVmErbe.OptionsCustomization.AllowFilter = false;
            this.grvVmErbe.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvVmErbe.OptionsNavigation.AutoFocusNewRow = true;
            this.grvVmErbe.OptionsNavigation.UseTabKey = false;
            this.grvVmErbe.OptionsView.ColumnAutoWidth = false;
            this.grvVmErbe.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvVmErbe.OptionsView.ShowGroupPanel = false;
            this.grvVmErbe.OptionsView.ShowIndicator = false;
            //
            // colTestamentEroeffnungStatus
            //
            this.colTestamentEroeffnungStatus.Caption = "Status";
            this.colTestamentEroeffnungStatus.FieldName = "TestamentEroeffnungStatus";
            this.colTestamentEroeffnungStatus.Name = "colTestamentEroeffnungStatus";
            this.colTestamentEroeffnungStatus.Visible = true;
            this.colTestamentEroeffnungStatus.VisibleIndex = 0;
            this.colTestamentEroeffnungStatus.Width = 63;
            //
            // colTestamentEroeffnungNr
            //
            this.colTestamentEroeffnungNr.AppearanceCell.Options.UseTextOptions = true;
            this.colTestamentEroeffnungNr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTestamentEroeffnungNr.Caption = "Nr";
            this.colTestamentEroeffnungNr.FieldName = "TestamentEroeffnungNr";
            this.colTestamentEroeffnungNr.Name = "colTestamentEroeffnungNr";
            this.colTestamentEroeffnungNr.Visible = true;
            this.colTestamentEroeffnungNr.VisibleIndex = 1;
            this.colTestamentEroeffnungNr.Width = 42;
            //
            // colErbCodierung
            //
            this.colErbCodierung.Caption = "Erbcode";
            this.colErbCodierung.FieldName = "ErbCodierung";
            this.colErbCodierung.Name = "colErbCodierung";
            this.colErbCodierung.Visible = true;
            this.colErbCodierung.VisibleIndex = 2;
            this.colErbCodierung.Width = 83;
            //
            // colText
            //
            this.colText.Caption = "Erben";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 3;
            this.colText.Width = 250;
            //
            // colTestamentEroeffnungVersandDatum
            //
            this.colTestamentEroeffnungVersandDatum.Caption = "Vers.Datum";
            this.colTestamentEroeffnungVersandDatum.FieldName = "TestamentEroeffnungVersandDatum";
            this.colTestamentEroeffnungVersandDatum.Name = "colTestamentEroeffnungVersandDatum";
            this.colTestamentEroeffnungVersandDatum.Visible = true;
            this.colTestamentEroeffnungVersandDatum.VisibleIndex = 4;
            //
            // colTestamentEroeffnungVersandart
            //
            this.colTestamentEroeffnungVersandart.Caption = "Vers.Art";
            this.colTestamentEroeffnungVersandart.FieldName = "TestamentEroeffnungVersandart";
            this.colTestamentEroeffnungVersandart.Name = "colTestamentEroeffnungVersandart";
            this.colTestamentEroeffnungVersandart.Visible = true;
            this.colTestamentEroeffnungVersandart.VisibleIndex = 5;
            this.colTestamentEroeffnungVersandart.Width = 60;
            //
            // colErbAnteil
            //
            this.colErbAnteil.Caption = "Erbanteil";
            this.colErbAnteil.FieldName = "ErbAnteil";
            this.colErbAnteil.Name = "colErbAnteil";
            this.colErbAnteil.Visible = true;
            this.colErbAnteil.VisibleIndex = 6;
            //
            // btnRight
            //
            this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRight.IconID = 13;
            this.btnRight.Location = new System.Drawing.Point(476, 4);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(28, 24);
            this.btnRight.TabIndex = 2;
            this.btnRight.UseVisualStyleBackColor = false;
            this.btnRight.Visible = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            //
            // btnLeft
            //
            this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeft.IconID = 11;
            this.btnLeft.Location = new System.Drawing.Point(442, 4);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(28, 24);
            this.btnLeft.TabIndex = 1;
            this.btnLeft.UseVisualStyleBackColor = false;
            this.btnLeft.Visible = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            //
            // edtErgaenzung
            //
            this.edtErgaenzung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErgaenzung.DataMember = "Ergaenzung";
            this.edtErgaenzung.DataSource = this.qryVmErbe;
            this.edtErgaenzung.Location = new System.Drawing.Point(100, 503);
            this.edtErgaenzung.Name = "edtErgaenzung";
            this.edtErgaenzung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErgaenzung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErgaenzung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErgaenzung.Properties.Appearance.Options.UseBackColor = true;
            this.edtErgaenzung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErgaenzung.Properties.Appearance.Options.UseFont = true;
            this.edtErgaenzung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErgaenzung.Size = new System.Drawing.Size(344, 84);
            this.edtErgaenzung.TabIndex = 16;
            //
            // lblErgaenzung
            //
            this.lblErgaenzung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErgaenzung.Location = new System.Drawing.Point(4, 503);
            this.lblErgaenzung.Name = "lblErgaenzung";
            this.lblErgaenzung.Size = new System.Drawing.Size(75, 24);
            this.lblErgaenzung.TabIndex = 216;
            this.lblErgaenzung.Text = "Ergänzung";
            //
            // edtBemerkung
            //
            this.edtBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtBemerkung.BackColor = System.Drawing.Color.White;
            this.edtBemerkung.DataMember = "Bemerkung";
            this.edtBemerkung.DataSource = this.qryVmErbe;
            this.edtBemerkung.Font = new System.Drawing.Font("Arial", 10F);
            this.edtBemerkung.Location = new System.Drawing.Point(463, 503);
            this.edtBemerkung.Name = "edtBemerkung";
            this.edtBemerkung.Size = new System.Drawing.Size(270, 84);
            this.edtBemerkung.TabIndex = 25;
            //
            // lblBemerkung
            //
            this.lblBemerkung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBemerkung.Location = new System.Drawing.Point(463, 479);
            this.lblBemerkung.Name = "lblBemerkung";
            this.lblBemerkung.Size = new System.Drawing.Size(76, 24);
            this.lblBemerkung.TabIndex = 215;
            this.lblBemerkung.Text = "Bemerkungen";
            //
            // edtErbanteilDivisor
            //
            this.edtErbanteilDivisor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErbanteilDivisor.DataMember = "ErbanteilDivisor";
            this.edtErbanteilDivisor.DataSource = this.qryVmErbe;
            this.edtErbanteilDivisor.Location = new System.Drawing.Point(627, 441);
            this.edtErbanteilDivisor.Name = "edtErbanteilDivisor";
            this.edtErbanteilDivisor.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErbanteilDivisor.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErbanteilDivisor.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErbanteilDivisor.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErbanteilDivisor.Properties.Appearance.Options.UseBackColor = true;
            this.edtErbanteilDivisor.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErbanteilDivisor.Properties.Appearance.Options.UseFont = true;
            this.edtErbanteilDivisor.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErbanteilDivisor.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErbanteilDivisor.Size = new System.Drawing.Size(50, 24);
            this.edtErbanteilDivisor.TabIndex = 20;
            this.edtErbanteilDivisor.Visible = false;
            //
            // edtErbanteilDividend
            //
            this.edtErbanteilDividend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErbanteilDividend.DataMember = "ErbanteilDividend";
            this.edtErbanteilDividend.DataSource = this.qryVmErbe;
            this.edtErbanteilDividend.Location = new System.Drawing.Point(567, 441);
            this.edtErbanteilDividend.Name = "edtErbanteilDividend";
            this.edtErbanteilDividend.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtErbanteilDividend.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErbanteilDividend.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErbanteilDividend.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErbanteilDividend.Properties.Appearance.Options.UseBackColor = true;
            this.edtErbanteilDividend.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErbanteilDividend.Properties.Appearance.Options.UseFont = true;
            this.edtErbanteilDividend.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErbanteilDividend.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtErbanteilDividend.Size = new System.Drawing.Size(50, 24);
            this.edtErbanteilDividend.TabIndex = 19;
            this.edtErbanteilDividend.Visible = false;
            //
            // lblSlash
            //
            this.lblSlash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSlash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSlash.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblSlash.Location = new System.Drawing.Point(617, 441);
            this.lblSlash.Name = "lblSlash";
            this.lblSlash.Size = new System.Drawing.Size(11, 24);
            this.lblSlash.TabIndex = 214;
            this.lblSlash.Text = "/";
            this.lblSlash.Visible = false;
            //
            // lblErbanteil
            //
            this.lblErbanteil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErbanteil.Location = new System.Drawing.Point(567, 419);
            this.lblErbanteil.Name = "lblErbanteil";
            this.lblErbanteil.Size = new System.Drawing.Size(44, 24);
            this.lblErbanteil.TabIndex = 213;
            this.lblErbanteil.Text = "Erbanteil";
            this.lblErbanteil.Visible = false;
            //
            // edtErbCodierung
            //
            this.edtErbCodierung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtErbCodierung.DataMember = "ErbCodierung";
            this.edtErbCodierung.DataSource = this.qryVmErbe;
            this.edtErbCodierung.Location = new System.Drawing.Point(463, 441);
            this.edtErbCodierung.Name = "edtErbCodierung";
            this.edtErbCodierung.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtErbCodierung.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtErbCodierung.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtErbCodierung.Properties.Appearance.Options.UseBackColor = true;
            this.edtErbCodierung.Properties.Appearance.Options.UseBorderColor = true;
            this.edtErbCodierung.Properties.Appearance.Options.UseFont = true;
            this.edtErbCodierung.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtErbCodierung.Size = new System.Drawing.Size(88, 24);
            this.edtErbCodierung.TabIndex = 18;
            this.edtErbCodierung.Visible = false;
            //
            // lblErbcode
            //
            this.lblErbcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblErbcode.Location = new System.Drawing.Point(463, 419);
            this.lblErbcode.Name = "lblErbcode";
            this.lblErbcode.Size = new System.Drawing.Size(44, 24);
            this.lblErbcode.TabIndex = 212;
            this.lblErbcode.Text = "Erbcode";
            this.lblErbcode.Visible = false;
            //
            // edtGeburtsdatum
            //
            this.edtGeburtsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtGeburtsdatum.DataMember = "Geburtsdatum";
            this.edtGeburtsdatum.DataSource = this.qryVmErbe;
            this.edtGeburtsdatum.Location = new System.Drawing.Point(100, 471);
            this.edtGeburtsdatum.Name = "edtGeburtsdatum";
            this.edtGeburtsdatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtGeburtsdatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtGeburtsdatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtGeburtsdatum.Properties.Appearance.Options.UseFont = true;
            this.edtGeburtsdatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtGeburtsdatum.Size = new System.Drawing.Size(146, 24);
            this.edtGeburtsdatum.TabIndex = 15;
            //
            // lblGeburtsdatum
            //
            this.lblGeburtsdatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGeburtsdatum.Location = new System.Drawing.Point(4, 471);
            this.lblGeburtsdatum.Name = "lblGeburtsdatum";
            this.lblGeburtsdatum.Size = new System.Drawing.Size(75, 24);
            this.lblGeburtsdatum.TabIndex = 211;
            this.lblGeburtsdatum.Text = "Geburtsdatum";
            //
            // edtKontaktAdresse
            //
            this.edtKontaktAdresse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtKontaktAdresse.DataMember = "KontaktAdresse";
            this.edtKontaktAdresse.DataSource = this.qryVmErbe;
            this.edtKontaktAdresse.Location = new System.Drawing.Point(463, 323);
            this.edtKontaktAdresse.Name = "edtKontaktAdresse";
            this.edtKontaktAdresse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtKontaktAdresse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKontaktAdresse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKontaktAdresse.Properties.Appearance.Options.UseBackColor = true;
            this.edtKontaktAdresse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKontaktAdresse.Properties.Appearance.Options.UseFont = true;
            this.edtKontaktAdresse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtKontaktAdresse.Size = new System.Drawing.Size(270, 96);
            this.edtKontaktAdresse.TabIndex = 17;
            //
            // kissLabel56
            //
            this.kissLabel56.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel56.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.kissLabel56.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.kissLabel56.Location = new System.Drawing.Point(463, 303);
            this.kissLabel56.Name = "kissLabel56";
            this.kissLabel56.Size = new System.Drawing.Size(92, 16);
            this.kissLabel56.TabIndex = 210;
            this.kissLabel56.Text = "Zustelladresse";
            //
            // edtLand
            //
            this.edtLand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtLand.DataMember = "Land";
            this.edtLand.DataSource = this.qryVmErbe;
            this.edtLand.Location = new System.Drawing.Point(100, 441);
            this.edtLand.Name = "edtLand";
            this.edtLand.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtLand.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtLand.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtLand.Properties.Appearance.Options.UseBackColor = true;
            this.edtLand.Properties.Appearance.Options.UseBorderColor = true;
            this.edtLand.Properties.Appearance.Options.UseFont = true;
            this.edtLand.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtLand.Size = new System.Drawing.Size(344, 24);
            this.edtLand.TabIndex = 14;
            //
            // edtStrasse
            //
            this.edtStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtStrasse.DataMember = "Strasse";
            this.edtStrasse.DataSource = this.qryVmErbe;
            this.edtStrasse.Location = new System.Drawing.Point(100, 395);
            this.edtStrasse.Name = "edtStrasse";
            this.edtStrasse.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtStrasse.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtStrasse.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtStrasse.Properties.Appearance.Options.UseBackColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseBorderColor = true;
            this.edtStrasse.Properties.Appearance.Options.UseFont = true;
            this.edtStrasse.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtStrasse.Size = new System.Drawing.Size(344, 24);
            this.edtStrasse.TabIndex = 12;
            //
            // edtOrt
            //
            this.edtOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtOrt.DataMember = "Ort";
            this.edtOrt.DataSource = this.qryVmErbe;
            this.edtOrt.Location = new System.Drawing.Point(100, 418);
            this.edtOrt.Name = "edtOrt";
            this.edtOrt.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtOrt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtOrt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtOrt.Properties.Appearance.Options.UseBackColor = true;
            this.edtOrt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtOrt.Properties.Appearance.Options.UseFont = true;
            this.edtOrt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtOrt.Size = new System.Drawing.Size(344, 24);
            this.edtOrt.TabIndex = 13;
            //
            // lblLand
            //
            this.lblLand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLand.Location = new System.Drawing.Point(4, 441);
            this.lblLand.Name = "lblLand";
            this.lblLand.Size = new System.Drawing.Size(44, 24);
            this.lblLand.TabIndex = 209;
            this.lblLand.Text = "Land";
            //
            // lblStrasse
            //
            this.lblStrasse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStrasse.Location = new System.Drawing.Point(4, 395);
            this.lblStrasse.Name = "lblStrasse";
            this.lblStrasse.Size = new System.Drawing.Size(44, 24);
            this.lblStrasse.TabIndex = 208;
            this.lblStrasse.Text = "Strasse";
            //
            // lblOrt
            //
            this.lblOrt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOrt.Location = new System.Drawing.Point(4, 418);
            this.lblOrt.Name = "lblOrt";
            this.lblOrt.Size = new System.Drawing.Size(44, 24);
            this.lblOrt.TabIndex = 207;
            this.lblOrt.Text = "Ort";
            //
            // edtAnrede
            //
            this.edtAnrede.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtAnrede.DataMember = "Anrede";
            this.edtAnrede.DataSource = this.qryVmErbe;
            this.edtAnrede.Location = new System.Drawing.Point(100, 296);
            this.edtAnrede.Name = "edtAnrede";
            this.edtAnrede.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtAnrede.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtAnrede.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtAnrede.Properties.Appearance.Options.UseBackColor = true;
            this.edtAnrede.Properties.Appearance.Options.UseBorderColor = true;
            this.edtAnrede.Properties.Appearance.Options.UseFont = true;
            this.edtAnrede.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtAnrede.Size = new System.Drawing.Size(344, 24);
            this.edtAnrede.TabIndex = 8;
            //
            // edtFamilienNamen
            //
            this.edtFamilienNamen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtFamilienNamen.DataMember = "FamilienNamen";
            this.edtFamilienNamen.DataSource = this.qryVmErbe;
            this.edtFamilienNamen.Location = new System.Drawing.Point(100, 319);
            this.edtFamilienNamen.Name = "edtFamilienNamen";
            this.edtFamilienNamen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFamilienNamen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFamilienNamen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFamilienNamen.Properties.Appearance.Options.UseBackColor = true;
            this.edtFamilienNamen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFamilienNamen.Properties.Appearance.Options.UseFont = true;
            this.edtFamilienNamen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFamilienNamen.Size = new System.Drawing.Size(344, 24);
            this.edtFamilienNamen.TabIndex = 9;
            //
            // edtVornamen
            //
            this.edtVornamen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtVornamen.DataMember = "Vornamen";
            this.edtVornamen.DataSource = this.qryVmErbe;
            this.edtVornamen.Location = new System.Drawing.Point(100, 342);
            this.edtVornamen.Name = "edtVornamen";
            this.edtVornamen.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVornamen.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVornamen.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVornamen.Properties.Appearance.Options.UseBackColor = true;
            this.edtVornamen.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVornamen.Properties.Appearance.Options.UseFont = true;
            this.edtVornamen.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtVornamen.Size = new System.Drawing.Size(344, 24);
            this.edtVornamen.TabIndex = 10;
            //
            // lblAnrede
            //
            this.lblAnrede.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAnrede.Location = new System.Drawing.Point(4, 296);
            this.lblAnrede.Name = "lblAnrede";
            this.lblAnrede.Size = new System.Drawing.Size(44, 24);
            this.lblAnrede.TabIndex = 206;
            this.lblAnrede.Text = "Anrede";
            //
            // lblFamilienNamen
            //
            this.lblFamilienNamen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFamilienNamen.Location = new System.Drawing.Point(4, 319);
            this.lblFamilienNamen.Name = "lblFamilienNamen";
            this.lblFamilienNamen.Size = new System.Drawing.Size(90, 24);
            this.lblFamilienNamen.TabIndex = 205;
            this.lblFamilienNamen.Text = "Familienname(n)";
            //
            // lblVornamen
            //
            this.lblVornamen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVornamen.Location = new System.Drawing.Point(4, 342);
            this.lblVornamen.Name = "lblVornamen";
            this.lblVornamen.Size = new System.Drawing.Size(68, 24);
            this.lblVornamen.TabIndex = 204;
            this.lblVornamen.Text = "Vorname(n)";
            //
            // edtTitel2
            //
            this.edtTitel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTitel2.DataMember = "Titel2";
            this.edtTitel2.DataSource = this.qryVmErbe;
            this.edtTitel2.Location = new System.Drawing.Point(100, 266);
            this.edtTitel2.Name = "edtTitel2";
            this.edtTitel2.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTitel2.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTitel2.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTitel2.Properties.Appearance.Options.UseBackColor = true;
            this.edtTitel2.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTitel2.Properties.Appearance.Options.UseFont = true;
            this.edtTitel2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTitel2.Size = new System.Drawing.Size(634, 24);
            this.edtTitel2.TabIndex = 7;
            //
            // edtTestamentEroeffnungStatus
            //
            this.edtTestamentEroeffnungStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTestamentEroeffnungStatus.DataMember = "TestamentEroeffnungStatus";
            this.edtTestamentEroeffnungStatus.DataSource = this.qryVmErbe;
            this.edtTestamentEroeffnungStatus.Location = new System.Drawing.Point(797, 426);
            this.edtTestamentEroeffnungStatus.Name = "edtTestamentEroeffnungStatus";
            this.edtTestamentEroeffnungStatus.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTestamentEroeffnungStatus.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTestamentEroeffnungStatus.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTestamentEroeffnungStatus.Properties.Appearance.Options.UseBackColor = true;
            this.edtTestamentEroeffnungStatus.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTestamentEroeffnungStatus.Properties.Appearance.Options.UseFont = true;
            this.edtTestamentEroeffnungStatus.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTestamentEroeffnungStatus.Size = new System.Drawing.Size(69, 24);
            this.edtTestamentEroeffnungStatus.TabIndex = 21;
            this.edtTestamentEroeffnungStatus.Visible = false;
            //
            // edtTestamentEroeffnungVersandart
            //
            this.edtTestamentEroeffnungVersandart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTestamentEroeffnungVersandart.DataMember = "TestamentEroeffnungVersandart";
            this.edtTestamentEroeffnungVersandart.DataSource = this.qryVmErbe;
            this.edtTestamentEroeffnungVersandart.Location = new System.Drawing.Point(935, 456);
            this.edtTestamentEroeffnungVersandart.Name = "edtTestamentEroeffnungVersandart";
            this.edtTestamentEroeffnungVersandart.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTestamentEroeffnungVersandart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTestamentEroeffnungVersandart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTestamentEroeffnungVersandart.Properties.Appearance.Options.UseBackColor = true;
            this.edtTestamentEroeffnungVersandart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTestamentEroeffnungVersandart.Properties.Appearance.Options.UseFont = true;
            this.edtTestamentEroeffnungVersandart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTestamentEroeffnungVersandart.Size = new System.Drawing.Size(55, 24);
            this.edtTestamentEroeffnungVersandart.TabIndex = 24;
            this.edtTestamentEroeffnungVersandart.Visible = false;
            //
            // edtTestamentEroeffnungVersandDatum
            //
            this.edtTestamentEroeffnungVersandDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTestamentEroeffnungVersandDatum.DataMember = "TestamentEroeffnungVersandDatum";
            this.edtTestamentEroeffnungVersandDatum.DataSource = this.qryVmErbe;
            this.edtTestamentEroeffnungVersandDatum.EditValue = null;
            this.edtTestamentEroeffnungVersandDatum.Location = new System.Drawing.Point(935, 426);
            this.edtTestamentEroeffnungVersandDatum.Name = "edtTestamentEroeffnungVersandDatum";
            this.edtTestamentEroeffnungVersandDatum.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTestamentEroeffnungVersandDatum.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTestamentEroeffnungVersandDatum.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTestamentEroeffnungVersandDatum.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTestamentEroeffnungVersandDatum.Properties.Appearance.Options.UseBackColor = true;
            this.edtTestamentEroeffnungVersandDatum.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTestamentEroeffnungVersandDatum.Properties.Appearance.Options.UseFont = true;
            this.edtTestamentEroeffnungVersandDatum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtTestamentEroeffnungVersandDatum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtTestamentEroeffnungVersandDatum.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtTestamentEroeffnungVersandDatum.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTestamentEroeffnungVersandDatum.Properties.ShowToday = false;
            this.edtTestamentEroeffnungVersandDatum.Size = new System.Drawing.Size(90, 24);
            this.edtTestamentEroeffnungVersandDatum.TabIndex = 23;
            this.edtTestamentEroeffnungVersandDatum.Visible = false;
            //
            // edtTestamentEroeffnungNr
            //
            this.edtTestamentEroeffnungNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTestamentEroeffnungNr.DataMember = "TestamentEroeffnungNr";
            this.edtTestamentEroeffnungNr.DataSource = this.qryVmErbe;
            this.edtTestamentEroeffnungNr.Location = new System.Drawing.Point(797, 456);
            this.edtTestamentEroeffnungNr.Name = "edtTestamentEroeffnungNr";
            this.edtTestamentEroeffnungNr.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTestamentEroeffnungNr.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTestamentEroeffnungNr.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTestamentEroeffnungNr.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTestamentEroeffnungNr.Properties.Appearance.Options.UseBackColor = true;
            this.edtTestamentEroeffnungNr.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTestamentEroeffnungNr.Properties.Appearance.Options.UseFont = true;
            this.edtTestamentEroeffnungNr.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTestamentEroeffnungNr.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTestamentEroeffnungNr.Size = new System.Drawing.Size(41, 24);
            this.edtTestamentEroeffnungNr.TabIndex = 22;
            this.edtTestamentEroeffnungNr.Visible = false;
            //
            // lblTestamentEroeffnungStatus
            //
            this.lblTestamentEroeffnungStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTestamentEroeffnungStatus.Location = new System.Drawing.Point(755, 426);
            this.lblTestamentEroeffnungStatus.Name = "lblTestamentEroeffnungStatus";
            this.lblTestamentEroeffnungStatus.Size = new System.Drawing.Size(34, 24);
            this.lblTestamentEroeffnungStatus.TabIndex = 224;
            this.lblTestamentEroeffnungStatus.Text = "Status";
            this.lblTestamentEroeffnungStatus.Visible = false;
            //
            // lblTestamentEroeffnungNr
            //
            this.lblTestamentEroeffnungNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTestamentEroeffnungNr.Location = new System.Drawing.Point(755, 456);
            this.lblTestamentEroeffnungNr.Name = "lblTestamentEroeffnungNr";
            this.lblTestamentEroeffnungNr.Size = new System.Drawing.Size(35, 24);
            this.lblTestamentEroeffnungNr.TabIndex = 225;
            this.lblTestamentEroeffnungNr.Text = "Nr";
            this.lblTestamentEroeffnungNr.Visible = false;
            //
            // lblTestamentEroeffnungVersandDatum
            //
            this.lblTestamentEroeffnungVersandDatum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTestamentEroeffnungVersandDatum.Location = new System.Drawing.Point(872, 426);
            this.lblTestamentEroeffnungVersandDatum.Name = "lblTestamentEroeffnungVersandDatum";
            this.lblTestamentEroeffnungVersandDatum.Size = new System.Drawing.Size(61, 24);
            this.lblTestamentEroeffnungVersandDatum.TabIndex = 226;
            this.lblTestamentEroeffnungVersandDatum.Text = "Vers.Datum";
            this.lblTestamentEroeffnungVersandDatum.Visible = false;
            //
            // lblTestamentEroeffnungVersandart
            //
            this.lblTestamentEroeffnungVersandart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTestamentEroeffnungVersandart.Location = new System.Drawing.Point(872, 456);
            this.lblTestamentEroeffnungVersandart.Name = "lblTestamentEroeffnungVersandart";
            this.lblTestamentEroeffnungVersandart.Size = new System.Drawing.Size(60, 24);
            this.lblTestamentEroeffnungVersandart.TabIndex = 227;
            this.lblTestamentEroeffnungVersandart.Text = "Vesandart";
            this.lblTestamentEroeffnungVersandart.Visible = false;
            //
            // btnAutoNr
            //
            this.btnAutoNr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAutoNr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoNr.Image = ((System.Drawing.Image)(resources.GetObject("btnAutoNr.Image")));
            this.btnAutoNr.Location = new System.Drawing.Point(843, 456);
            this.btnAutoNr.Name = "btnAutoNr";
            this.btnAutoNr.Size = new System.Drawing.Size(23, 24);
            this.btnAutoNr.TabIndex = 21;
            this.btnAutoNr.UseVisualStyleBackColor = false;
            this.btnAutoNr.Visible = false;
            this.btnAutoNr.Click += new System.EventHandler(this.btnAutoNr_Click);
            //
            // edtZusatz
            //
            this.edtZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtZusatz.DataMember = "Zusatz";
            this.edtZusatz.DataSource = this.qryVmErbe;
            this.edtZusatz.Location = new System.Drawing.Point(100, 365);
            this.edtZusatz.Name = "edtZusatz";
            this.edtZusatz.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtZusatz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtZusatz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtZusatz.Properties.Appearance.Options.UseBackColor = true;
            this.edtZusatz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtZusatz.Properties.Appearance.Options.UseFont = true;
            this.edtZusatz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtZusatz.Size = new System.Drawing.Size(344, 24);
            this.edtZusatz.TabIndex = 11;
            //
            // lblZusatz
            //
            this.lblZusatz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblZusatz.Location = new System.Drawing.Point(4, 366);
            this.lblZusatz.Name = "lblZusatz";
            this.lblZusatz.Size = new System.Drawing.Size(68, 24);
            this.lblZusatz.TabIndex = 229;
            this.lblZusatz.Text = "Zusatz/Titel";
            //
            // edtTitel
            //
            this.edtTitel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edtTitel.DataMember = "Titel";
            this.edtTitel.DataSource = this.qryVmErbe;
            this.edtTitel.Location = new System.Drawing.Point(100, 243);
            this.edtTitel.Name = "edtTitel";
            this.edtTitel.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtTitel.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTitel.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTitel.Properties.Appearance.Options.UseBackColor = true;
            this.edtTitel.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTitel.Properties.Appearance.Options.UseFont = true;
            this.edtTitel.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTitel.Size = new System.Drawing.Size(634, 24);
            this.edtTitel.TabIndex = 6;
            //
            // kissLabel7
            //
            this.kissLabel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.kissLabel7.Location = new System.Drawing.Point(5, 243);
            this.kissLabel7.Name = "kissLabel7";
            this.kissLabel7.Size = new System.Drawing.Size(27, 24);
            this.kissLabel7.TabIndex = 231;
            this.kissLabel7.Text = "Text";
            //
            // lblTitel2
            //
            this.lblTitel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTitel2.Location = new System.Drawing.Point(5, 266);
            this.lblTitel2.Name = "lblTitel2";
            this.lblTitel2.Size = new System.Drawing.Size(106, 24);
            this.lblTitel2.TabIndex = 233;
            this.lblTitel2.Text = "Verwantschaftsg.";
            //
            // CtlVmErbe
            //
            this.ActiveSQLQuery = this.qryVmErbe;

            this.Controls.Add(this.edtTitel2);
            this.Controls.Add(this.lblTitel2);
            this.Controls.Add(this.edtTitel);
            this.Controls.Add(this.kissLabel7);
            this.Controls.Add(this.edtZusatz);
            this.Controls.Add(this.lblZusatz);
            this.Controls.Add(this.btnAutoNr);
            this.Controls.Add(this.lblTestamentEroeffnungVersandart);
            this.Controls.Add(this.lblTestamentEroeffnungVersandDatum);
            this.Controls.Add(this.lblTestamentEroeffnungNr);
            this.Controls.Add(this.lblTestamentEroeffnungStatus);
            this.Controls.Add(this.edtTestamentEroeffnungNr);
            this.Controls.Add(this.edtTestamentEroeffnungVersandDatum);
            this.Controls.Add(this.edtTestamentEroeffnungVersandart);
            this.Controls.Add(this.edtTestamentEroeffnungStatus);
            this.Controls.Add(this.edtErgaenzung);
            this.Controls.Add(this.lblErgaenzung);
            this.Controls.Add(this.edtBemerkung);
            this.Controls.Add(this.lblBemerkung);
            this.Controls.Add(this.edtErbanteilDivisor);
            this.Controls.Add(this.edtErbanteilDividend);
            this.Controls.Add(this.lblSlash);
            this.Controls.Add(this.lblErbanteil);
            this.Controls.Add(this.edtErbCodierung);
            this.Controls.Add(this.lblErbcode);
            this.Controls.Add(this.edtGeburtsdatum);
            this.Controls.Add(this.lblGeburtsdatum);
            this.Controls.Add(this.edtKontaktAdresse);
            this.Controls.Add(this.kissLabel56);
            this.Controls.Add(this.edtLand);
            this.Controls.Add(this.edtStrasse);
            this.Controls.Add(this.edtOrt);
            this.Controls.Add(this.lblLand);
            this.Controls.Add(this.lblStrasse);
            this.Controls.Add(this.lblOrt);
            this.Controls.Add(this.edtAnrede);
            this.Controls.Add(this.edtFamilienNamen);
            this.Controls.Add(this.edtVornamen);
            this.Controls.Add(this.lblAnrede);
            this.Controls.Add(this.lblFamilienNamen);
            this.Controls.Add(this.lblVornamen);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.grdVmErbe);
            this.Controls.Add(this.btnErbenTransfer);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.picTitel);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlVmErbe";
            this.Size = new System.Drawing.Size(1037, 594);
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdVmErbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvVmErbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErgaenzung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErgaenzung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBemerkung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbanteilDivisor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbanteilDividend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSlash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErbanteil)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtErbCodierung.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblErbcode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtGeburtsdatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblGeburtsdatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKontaktAdresse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel56)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtLand.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStrasse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtOrt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblStrasse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtAnrede.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFamilienNamen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVornamen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblAnrede)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblFamilienNamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVornamen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentEroeffnungStatus.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentEroeffnungVersandart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentEroeffnungVersandDatum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTestamentEroeffnungNr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentEroeffnungStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentEroeffnungNr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentEroeffnungVersandDatum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTestamentEroeffnungVersandart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtZusatz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblZusatz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTitel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kissLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTitel2)).EndInit();
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
                if (components != null)
                {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #endregion

        #region EventHandlers

        private void btnAutoNr_Click(object sender, System.EventArgs e)
        {
            if (!qryVmErbe.Post())
            {
                return;
            }

            if (KissMsg.ShowQuestion(this.Name, "EintraegNummerieren", "Sollen alle Einträge neu durchnummeriert werden ?"))
            {
                ApplicationFacade.DoEvents();
                int nr = 1;

                if (!qryVmErbe.First())
                {
                    return;
                }

                while (nr == 1 || qryVmErbe.Next())
                {
                    qryVmErbe["TestamentEroeffnungNr"] = nr;
                    qryVmErbe.Post();
                    nr++;
                }
            }

            qryVmErbe.First();
        }

        private void btnDown_Click(object sender, System.EventArgs e)
        {
            if (qryVmErbe.Count == 0 || !qryVmErbe.Post())
            {
                return;
            }

            // NachPosition bestimmen
            object nachPosition = DBUtil.ExecuteScalarSQL(@"
                SELECT MIN(Position)
                FROM dbo.VmErbe
                WHERE (VmSiegelungID = {0} OR VmTestamentID = {1} OR VmErbschaftsdienstID = {2})
                  AND Position > {3};", _vmSiegelungId, _vmTestamentId, _vmErbschaftsdienstId, qryVmErbe["Position"]);

            if (DBUtil.IsEmpty(nachPosition))
            {
                return;
            }

            // tauschen mit Nachposition
            DBUtil.ExecSQL(@"
                UPDATE dbo.VmErbe
                SET Position = {0}
                WHERE (VmSiegelungID = {1} OR VmTestamentID = {2} OR VmErbschaftsdienstID = {3})
                  AND Position = {4};", qryVmErbe["Position"], _vmSiegelungId, _vmTestamentId, _vmErbschaftsdienstId, nachPosition);

            qryVmErbe["Position"] = nachPosition;
            qryVmErbe.Post();
            qryVmErbe.Refresh();
        }

        private void btnErbenTransfer_Click(object sender, System.EventArgs e)
        {
            DlgVmErbeTransfer dlg = new DlgVmErbeTransfer();
            dlg.Init(_faLeistungId, _vmSiegelungId, _vmTestamentId, _vmErbschaftsdienstId);

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                qryVmErbe.Refresh();
            }
        }

        private void btnLeft_Click(object sender, System.EventArgs e)
        {
            if (qryVmErbe.Count == 0 || (int)qryVmErbe["Level"] == 0 || !qryVmErbe.Post())
            {
                return;
            }

            qryVmErbe["Level"] = (int)qryVmErbe["Level"] - 1;
            qryVmErbe.Post();
            qryVmErbe.Refresh();
        }

        private void btnRight_Click(object sender, System.EventArgs e)
        {
            if (qryVmErbe.Count == 0 || (int)qryVmErbe["Level"] >= 12 || !qryVmErbe.Post())
            {
                return;
            }

            qryVmErbe["Level"] = Convert.ToInt32(qryVmErbe["Level"]) + 1;
            qryVmErbe.Post();
            qryVmErbe.Refresh();
        }

        private void btnUp_Click(object sender, System.EventArgs e)
        {
            if (qryVmErbe.Count == 0 || Convert.ToInt32(qryVmErbe["Position"]) == 1 || !qryVmErbe.Post())
            {
                return;
            }

            // VorPosition bestimmen
            object vorPosition = DBUtil.ExecuteScalarSQL(@"
                SELECT MAX(Position)
                FROM dbo.VmErbe
                WHERE (VmSiegelungID = {0} OR VmTestamentID = {1} OR VmErbschaftsdienstID = {2})
                  AND Position < {3};", _vmSiegelungId, _vmTestamentId, _vmErbschaftsdienstId, qryVmErbe["Position"]);

            if (DBUtil.IsEmpty(vorPosition))
            {
                return;
            }

            // tauschen mit Vorposition
            DBUtil.ExecSQL(@"
                UPDATE dbo.VmErbe
                SET Position = {0}
                WHERE (VmSiegelungID = {1} OR VmTestamentID = {2} OR VmErbschaftsdienstID = {3})
                  AND Position = {4};", qryVmErbe["Position"], _vmSiegelungId, _vmTestamentId, _vmErbschaftsdienstId, vorPosition);

            qryVmErbe["Position"] = vorPosition;
            qryVmErbe.Post();
            qryVmErbe.Refresh();
        }

        private void qryVmErbe_AfterPost(object sender, System.EventArgs e)
        {
            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Text = SPACE(Level * 8) +
                              CASE
                                WHEN Titel IS NOT NULL OR Titel2 IS NOT NULL
                                  THEN ISNULL(Titel + ' ', '') + ISNULL(Titel2, '')
                                ELSE ISNULL(Anrede + ' ', '') +
                                     ISNULL(FamilienNamen + ' ', '') +
                                     ISNULL(Vornamen, '') +
                                     ISNULL(', ' + Zusatz, '')  +
                                     ISNULL(', ' + Geburtsdatum, '') +
                                     ISNULL(', ' + Strasse, '') +
                                     ISNULL(', ' + Ort, '') +
                                     ISNULL(', ' + Land, '') +
                                     ISNULL(', ' + Ergaenzung, '')
                              END,
                       ErbAnteil = CASE
                                     WHEN ErbAnteilDividend IS NOT NULL AND ErbAnteilDivisor IS NOT NULL
                                       THEN CONVERT(VARCHAR, ErbAnteilDividend) + '/' + CONVERT(VARCHAR, ErbAnteilDivisor)
                                     ELSE ''
                                   END
                FROM dbo.VmErbe ERB
                WHERE (VmSiegelungID = {0} OR VmTestamentID = {1} OR VmErbschaftsdienstID = {2})
                  AND Position = {3};", _vmSiegelungId, _vmTestamentId, _vmErbschaftsdienstId, qryVmErbe["Position"]);

            qryVmErbe.Row["Text"] = qry["Text"];  //qryVmErbe["Text"] würde Spaces normalisieren
            qryVmErbe["ErbAnteil"] = qry["ErbAnteil"];
        }

        private void qryVmErbe_BeforePost(object sender, System.EventArgs e)
        {
            if (DBUtil.IsEmpty(qryVmErbe["Titel"]) && DBUtil.IsEmpty(qryVmErbe["Titel2"]))
            {
                DBUtil.CheckNotNullField(edtFamilienNamen, lblFamilienNamen.Text);
            }

            qryVmErbe["VmSiegelungID"] = _vmSiegelungId;
            qryVmErbe["VmTestamentID"] = _vmTestamentId;
            qryVmErbe["VmErbschaftsdienstID"] = _vmErbschaftsdienstId;
        }

        private void qryVmErbe_PositionChanged(object sender, EventArgs e)
        {
            if (!DBUtil.IsEmpty(qryVmErbe["VmErbeID"]))
            {
                qryVmErbe.EnableBoundFields((int)qryVmErbe["VmErbeID"] != -1);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(
            string titleName,
            Image titleImage,
            int faLeistungID,
            object vmSiegelungID,
            object vmTestamentID,
            object vmErbschaftsdienstID)
        {
            lblTitel.Text = titleName;
            picTitel.Image = titleImage;

            _faLeistungId = faLeistungID;
            _vmSiegelungId = vmSiegelungID;
            _vmTestamentId = vmTestamentID;
            _vmErbschaftsdienstId = vmErbschaftsdienstID;

            int offset = lblTestamentEroeffnungStatus.Left - lblErbcode.Left;

            if (!DBUtil.IsEmpty(vmErbschaftsdienstID))
            {
                lblErbcode.Visible = true;
                lblErbanteil.Visible = true;
                lblSlash.Visible = true;
                edtErbCodierung.Visible = true;
                edtErbanteilDividend.Visible = true;
                edtErbanteilDivisor.Visible = true;

                colTestamentEroeffnungStatus.Visible = false;
                colTestamentEroeffnungNr.Visible = false;
                colTestamentEroeffnungVersandDatum.Visible = false;
                colTestamentEroeffnungVersandart.Visible = false;
                colText.Width = 545;
            }
            else if (!DBUtil.IsEmpty(vmTestamentID))
            {
                lblTestamentEroeffnungStatus.Visible = true;
                lblTestamentEroeffnungNr.Visible = true;
                lblTestamentEroeffnungVersandDatum.Visible = true;
                lblTestamentEroeffnungVersandart.Visible = true;
                edtTestamentEroeffnungStatus.Visible = true;
                edtTestamentEroeffnungNr.Visible = true;
                edtTestamentEroeffnungVersandDatum.Visible = true;
                edtTestamentEroeffnungVersandart.Visible = true;
                btnAutoNr.Visible = true;

                lblTestamentEroeffnungStatus.Left -= offset;
                lblTestamentEroeffnungNr.Left -= offset;
                lblTestamentEroeffnungVersandDatum.Left -= offset;
                lblTestamentEroeffnungVersandart.Left -= offset;
                edtTestamentEroeffnungStatus.Left -= offset;
                edtTestamentEroeffnungNr.Left -= offset;
                edtTestamentEroeffnungVersandDatum.Left -= offset;
                edtTestamentEroeffnungVersandart.Left -= offset;
                btnAutoNr.Left -= offset;

                colErbCodierung.Visible = false;
                colErbAnteil.Visible = false;
                colText.Width = 475;
            }
            else if (!DBUtil.IsEmpty(vmSiegelungID))
            {
                lblTestamentEroeffnungStatus.Visible = true;
                edtTestamentEroeffnungStatus.Visible = true;
                lblTestamentEroeffnungStatus.Top = edtErbCodierung.Top;
                edtTestamentEroeffnungStatus.Top = edtErbCodierung.Top;
                lblTestamentEroeffnungStatus.Left -= offset;
                edtTestamentEroeffnungStatus.Left -= offset;

                colErbCodierung.Visible = false;
                colErbAnteil.Visible = false;
                colTestamentEroeffnungNr.Visible = false;
                colTestamentEroeffnungVersandDatum.Visible = false;
                colTestamentEroeffnungVersandart.Visible = false;
                colText.Width = 635;
                //editKontaktAdresse.Height += 45;
                btnLeft.Visible = true;
                btnRight.Visible = true;
            }
            else
            {
                // no ids given, disable all
                btnLeft.Visible = false;
                btnRight.Visible = false;
                btnErbenTransfer.Visible = false;

                qryVmErbe.CanInsert = false;
                qryVmErbe.CanUpdate = false;
                qryVmErbe.CanDelete = false;
                qryVmErbe.EnableBoundFields();
                return;
            }

            // TODO: why no rights handling?
            qryVmErbe.CanInsert = true;
            qryVmErbe.CanUpdate = true;
            qryVmErbe.CanDelete = true;

            btnErbenTransfer.Visible = DBUtil.IsEmpty(vmSiegelungID);

            qryVmErbe.Fill(@"
                SELECT ERB.*,
                       --
                       Text = SPACE(Level * 8) +
                              CASE
                                WHEN Titel IS NOT NULL OR Titel2 IS NOT NULL
                                  THEN ISNULL(Titel + ' ', '') + ISNULL(Titel2, '')
                                ELSE ISNULL(Anrede + ' ', '') +
                                     ISNULL(FamilienNamen + ' ', '') +
                                     ISNULL(Vornamen, '') +
                                     ISNULL(', ' + Zusatz, '')  +
                                     ISNULL(', ' + Geburtsdatum, '') +
                                     ISNULL(', ' + Strasse, '') +
                                     ISNULL(', ' + Ort, '') +
                                     ISNULL(', ' + Land, '') +
                                     ISNULL(', ' + Ergaenzung, '')
                              END,
                       ErbAnteil = CASE
                                     WHEN ErbAnteilDividend IS NOT NULL AND ErbAnteilDivisor IS NOT NULL
                                       THEN CONVERT(VARCHAR, ErbAnteilDividend) + '/' + CONVERT(VARCHAR, ErbAnteilDivisor)
                                     ELSE ''
                                   END
                FROM dbo.VmErbe ERB
                WHERE (VmSiegelungID = {0} OR VmTestamentID = {1} OR VmErbschaftsdienstID = {2})
                ORDER BY Position;", vmSiegelungID, vmTestamentID, vmErbschaftsdienstID);
        }

        public override bool OnAddData()
        {
            if (!qryVmErbe.Post())
            {
                return false;
            }

            // validate first
            if (DBUtil.IsEmpty(_vmSiegelungId) && DBUtil.IsEmpty(_vmTestamentId) && DBUtil.IsEmpty(_vmErbschaftsdienstId))
            {
                // no id to assign with, cannot insert a new entry
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "InvalidReferenceIDs_v01",
                                                                 "Es kann kein neuer Datensatz erstellt werden.\r\n\r\nMindestens eine der IDs (Siegelung, Testament, Erbschaftsdienst) muss gegeben sein."));
            }

            int neuePosition = 1;

            if (qryVmErbe.Count > 0)
            {
                neuePosition = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"
                    SELECT ISNULL(MAX(Position) + 1, 1)
                    FROM dbo.VmErbe
                    WHERE (VmSiegelungID = {0} OR VmTestamentID = {1} OR VmErbschaftsdienstID = {2});",
                        _vmSiegelungId,
                        _vmTestamentId,
                        _vmErbschaftsdienstId));
            }

            SqlQuery qry = DBUtil.OpenSQL(@"
                INSERT dbo.VmErbe (VmSiegelungID, VmTestamentID, VmErbschaftsdienstID, Position, Level, FamilienNamen)
                VALUES ({0}, {1}, {2}, {3}, {4}, {5});

                SELECT VmErbeID = SCOPE_IDENTITY();",
                    _vmSiegelungId,
                    _vmTestamentId,
                    _vmErbschaftsdienstId,
                    neuePosition,
                    0,
                    KissMsg.GetMLMessage(this.Name, "NewVmErbeIDNewPerson", "Neue Person"));

            qryVmErbe.Refresh();
            qryVmErbe.Last();
            edtAnrede.Focus();

            return true;
        }

        #endregion

        #endregion
    }
}