using System;
using System.Data;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

using KiSS.DBScheme;

namespace KiSS4.Sozialhilfe
{
    /// <summary>
    /// Dialog, used for CRUD further cost categories of main position
    /// </summary>
    public class DlgWhWeitereKOA : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Fields

        private int _bgPositionID;
        private int _bgPositionIDBewilligen = -1;
        private bool _dataModified = false;
        private int _newBgKategorieCode = 0;
        object _oldBgSpezkontoID = null; // store the old editvalue of edtBgSpezkonto
        private bool _readOnly = true;
        private decimal _totalbetrag;
        private KiSS4.Gui.KissButton btnAbbrechen;
        private KiSS4.Gui.KissButton btnEinzelzahlung;
        private KiSS4.Gui.KissButton btnOk;
        private KissButton btnPositionBewilligung;
        private KiSS4.Gui.KissButton btnZusatzleistung;
        private DevExpress.XtraGrid.Columns.GridColumn colPositionID;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBetrag;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailBuchungstext;
        private DevExpress.XtraGrid.Columns.GridColumn colDetailKostenart;
        private DevExpress.XtraGrid.Columns.GridColumn colKat;
        private DevExpress.XtraGrid.Columns.GridColumn colPerson;
        private DevExpress.XtraGrid.Columns.GridColumn colSpezKonto;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colTyp;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeBis;
        private DevExpress.XtraGrid.Columns.GridColumn colVerwPeriodeVon;
        private System.ComponentModel.IContainer components;
        private KiSS4.Common.CtlErfassungMutation ctlErfassungMutation;
        private KiSS4.Gui.KissLookUpEdit edtBaPersonID;
        private KiSS4.Gui.KissCalcEdit edtBetrag;
        private KiSS4.Gui.KissLookUpEdit edtBgSpezkontoID;
        private KiSS4.Gui.KissLookUpEdit edtBgSplittingCode;
        private KiSS4.Gui.KissTextEdit edtBuchungstext;
        private KiSS4.Gui.KissCalcEdit edtDifferenz;
        private KiSS4.Gui.KissLookUpEdit edtKategorie;
        private KiSS4.Gui.KissButtonEdit edtKostenart;
        private KiSS4.Gui.KissCalcEdit edtTotalbetragAlt;
        private KiSS4.Gui.KissCalcEdit edtTotalbetragNeu;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeBis;
        private KiSS4.Gui.KissDateEdit edtVerwPeriodeVon;
        private KiSS4.Gui.KissGrid grdBgPosition;
        private KissGroupBox grpBerechnung;
        private DevExpress.XtraGrid.Views.Grid.GridView grvBgPosition;
        private KiSS4.Gui.KissLabel lblBaPersonID;
        private KiSS4.Gui.KissLabel lblBetrag;
        private KiSS4.Gui.KissLabel lblBgSpezkontoID;
        private KiSS4.Gui.KissLabel lblBgSplittingCode;
        private KiSS4.Gui.KissLabel lblBuchungstext;
        private KiSS4.Gui.KissLabel lblDifferenz;
        private KiSS4.Gui.KissLabel lblKategorie;
        private KiSS4.Gui.KissLabel lblKostenart;
        private KiSS4.Gui.KissLabel lblTotalAlt;
        private KiSS4.Gui.KissLabel lblTotalNeu;
        private KiSS4.Gui.KissLabel lblVerwPeriode;
        private KiSS4.Gui.KissLabel lblVerwPeriodeStrich;
        private Panel panBorder;
        private Panel panDetails;
        private Panel panNewItems;
        private KiSS4.DB.SqlQuery qryBgBudget;
        private KiSS4.DB.SqlQuery qryBgPosition;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repStatusImg;
        private System.Windows.Forms.ToolTip ttpControls;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgWhWeitereKOA"/> class.
        /// </summary>
        /// <param name="bgPositionID">The id of the entry in BgPosition (main entry)</param>
        /// <param name="totalBetrag">The total amount to use</param>
        public DlgWhWeitereKOA(int bgPositionID, decimal totalBetrag)
            : this()
        {
            // apply fields
            _bgPositionID = bgPositionID;
            _totalbetrag = totalBetrag;

            // setup controls
            edtTotalbetragAlt.EditValue = totalBetrag;

            colKat.ColumnEdit = grdBgPosition.GetLOVLookUpEdit(DBUtil.OpenSQL(@"
                SELECT Code,
                       Text = SUBSTRING(Text, 1, 1)
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'BgKategorie';"));

            SqlQuery qry = DBUtil.OpenSQL(@"
                SELECT Code = FPP.BaPersonID,
                       Text = PRS.NameVorname
                FROM dbo.BgPosition                    BPO
                  INNER JOIN dbo.BgBudget              BDG ON BDG.BgBudgetID = BPO.BgBudgetID
                  INNER JOIN dbo.BgFinanzPlan_BaPerson FPP ON FPP.BgFinanzplanID = BDG.BgFinanzplanID
                  INNER JOIN dbo.vwPerson              PRS ON PRS.BaPersonID = FPP.BaPersoNID
                WHERE BPO.BgPositionID = {0}
                  AND IstUnterstuetzt = 1
                ORDER BY PRS.NameVorname;", this._bgPositionID);

            edtBaPersonID.LoadQuery(qry);
            colPerson.ColumnEdit = grdBgPosition.GetLOVLookUpEdit(qry);

            edtBgSplittingCode.LoadQuery(DBUtil.OpenSQL(@"
                SELECT *
                FROM dbo.XLOVCode WITH (READUNCOMMITTED)
                WHERE LOVName = 'BgSplittingart';"), "Code", "ShortText");

            qryBgBudget.Fill(bgPositionID);
            qryBgPosition.Fill(bgPositionID);
            UpdateSum();

            if (qryBgPosition.Count > 0)
            {
                int status = ShUtil.GetCode(qryBgPosition["Status"]);
                _readOnly = !(status <= 1 || status == 12 || status == 14 || status == 15);
            }

            qryBgPosition.CanInsert = !_readOnly;
            qryBgPosition.CanUpdate = !_readOnly;
            qryBgPosition.CanDelete = !_readOnly;

            qryBgPosition.EnableBoundFields(!_readOnly);
            SetEditMode();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgWhWeitereKOA"/> class.
        /// </summary>
        private DlgWhWeitereKOA()
        {
            // init control
            this.InitializeComponent();

            // setup status column
            repStatusImg.SmallImages = KissImageList.SmallImageList;

            SqlQuery qryStatus = DBUtil.OpenSQL(@"
                SELECT Code   = LOC.Code,
                       Text   = dbo.fnLOVMLText(LOC.LOVName, LOC.Code, {0}),
                       Value1 = LOC.Value1
                FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
                WHERE LOC.LOVName = 'KbBuchungsStatus'
                ORDER BY SortKey", Session.User.LanguageCode);

            foreach (DataRow row in qryStatus.DataTable.Rows)
            {
                repStatusImg.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                    row["Text"].ToString(), Convert.ToInt32(row["Code"]), KissImageList.GetImageIndex(Convert.ToInt32(row["Value1"]))));
            }

            colStatus.ColumnEdit = repStatusImg;

            // setup controls for multilanguage handling
            SetupControlsML();
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgWhWeitereKOA));
            this.grdBgPosition = new KiSS4.Gui.KissGrid();
            this.qryBgPosition = new KiSS4.DB.SqlQuery(this.components);
            this.grvBgPosition = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPositionID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailKostenart = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBuchungstext = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPerson = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDetailBetrag = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeVon = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSpezKonto = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVerwPeriodeBis = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repStatusImg = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.colTyp = new DevExpress.XtraGrid.Columns.GridColumn();
            this.edtKostenart = new KiSS4.Gui.KissButtonEdit();
            this.edtBuchungstext = new KiSS4.Gui.KissTextEdit();
            this.edtBetrag = new KiSS4.Gui.KissCalcEdit();
            this.edtBaPersonID = new KiSS4.Gui.KissLookUpEdit();
            this.edtBgSpezkontoID = new KiSS4.Gui.KissLookUpEdit();
            this.edtVerwPeriodeVon = new KiSS4.Gui.KissDateEdit();
            this.btnOk = new KiSS4.Gui.KissButton();
            this.edtVerwPeriodeBis = new KiSS4.Gui.KissDateEdit();
            this.btnAbbrechen = new KiSS4.Gui.KissButton();
            this.lblVerwPeriodeStrich = new KiSS4.Gui.KissLabel();
            this.lblBetrag = new KiSS4.Gui.KissLabel();
            this.lblKostenart = new KiSS4.Gui.KissLabel();
            this.lblBuchungstext = new KiSS4.Gui.KissLabel();
            this.edtDifferenz = new KiSS4.Gui.KissCalcEdit();
            this.lblDifferenz = new KiSS4.Gui.KissLabel();
            this.edtTotalbetragAlt = new KiSS4.Gui.KissCalcEdit();
            this.lblTotalAlt = new KiSS4.Gui.KissLabel();
            this.lblBaPersonID = new KiSS4.Gui.KissLabel();
            this.lblVerwPeriode = new KiSS4.Gui.KissLabel();
            this.lblBgSplittingCode = new KiSS4.Gui.KissLabel();
            this.edtBgSplittingCode = new KiSS4.Gui.KissLookUpEdit();
            this.lblBgSpezkontoID = new KiSS4.Gui.KissLabel();
            this.lblKategorie = new KiSS4.Gui.KissLabel();
            this.edtKategorie = new KiSS4.Gui.KissLookUpEdit();
            this.btnEinzelzahlung = new KiSS4.Gui.KissButton();
            this.btnZusatzleistung = new KiSS4.Gui.KissButton();
            this.ctlErfassungMutation = new KiSS4.Common.CtlErfassungMutation();
            this.edtTotalbetragNeu = new KiSS4.Gui.KissCalcEdit();
            this.lblTotalNeu = new KiSS4.Gui.KissLabel();
            this.qryBgBudget = new KiSS4.DB.SqlQuery(this.components);
            this.panDetails = new System.Windows.Forms.Panel();
            this.btnPositionBewilligung = new KiSS4.Gui.KissButton();
            this.grpBerechnung = new KiSS4.Gui.KissGroupBox();
            this.panNewItems = new System.Windows.Forms.Panel();
            this.panBorder = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDifferenz.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDifferenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalbetragAlt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalAlt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalbetragNeu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalNeu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).BeginInit();
            this.panDetails.SuspendLayout();
            this.grpBerechnung.SuspendLayout();
            this.panNewItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdBgPosition
            // 
            this.grdBgPosition.DataSource = this.qryBgPosition;
            this.grdBgPosition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBgPosition.EmbeddedNavigator.Name = "";
            this.grdBgPosition.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdBgPosition.Location = new System.Drawing.Point(0, 0);
            this.grdBgPosition.MainView = this.grvBgPosition;
            this.grdBgPosition.Name = "grdBgPosition";
            this.grdBgPosition.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repStatusImg});
            this.grdBgPosition.Size = new System.Drawing.Size(892, 153);
            this.grdBgPosition.TabIndex = 0;
            this.grdBgPosition.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvBgPosition});
            // 
            // qryBgPosition
            // 
            this.qryBgPosition.CanUpdate = true;
            this.qryBgPosition.HostControl = this;
            this.qryBgPosition.SelectStatement = resources.GetString("qryBgPosition.SelectStatement");
            this.qryBgPosition.TableName = "BgPosition";
            this.qryBgPosition.BeforePost += new System.EventHandler(this.qryBgPosition_BeforePost);
            this.qryBgPosition.PositionChanged += new System.EventHandler(this.qryBgPosition_PositionChanged);
            this.qryBgPosition.AfterInsert += new System.EventHandler(this.qryBgPosition_AfterInsert);
            this.qryBgPosition.BeforeInsert += new System.EventHandler(this.qryBgPosition_BeforeInsert);
            this.qryBgPosition.BeforeDeleteQuestion += new System.EventHandler(this.qryBgPosition_BeforeDeleteQuestion);
            this.qryBgPosition.ColumnChanged += new System.Data.DataColumnChangeEventHandler(this.qryBgPosition_ColumnChanged);
            this.qryBgPosition.AfterDelete += new System.EventHandler(this.qryBgPosition_AfterDelete);
            // 
            // grvBgPosition
            // 
            this.grvBgPosition.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvBgPosition.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Empty.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Empty.Options.UseFont = true;
            this.grvBgPosition.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.EvenRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvBgPosition.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvBgPosition.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvBgPosition.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvBgPosition.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvBgPosition.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvBgPosition.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.OddRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvBgPosition.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.Row.Options.UseBackColor = true;
            this.grvBgPosition.Appearance.Row.Options.UseFont = true;
            this.grvBgPosition.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvBgPosition.Appearance.SelectedRow.Options.UseFont = true;
            this.grvBgPosition.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvBgPosition.Appearance.VertLine.Options.UseBackColor = true;
            this.grvBgPosition.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvBgPosition.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPositionID,
            this.colKat,
            this.colDetailKostenart,
            this.colDetailBuchungstext,
            this.colPerson,
            this.colDetailBetrag,
            this.colVerwPeriodeVon,
            this.colSpezKonto,
            this.colVerwPeriodeBis,
            this.colStatus,
            this.colTyp});
            this.grvBgPosition.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvBgPosition.GridControl = this.grdBgPosition;
            this.grvBgPosition.Name = "grvBgPosition";
            this.grvBgPosition.OptionsBehavior.Editable = false;
            this.grvBgPosition.OptionsCustomization.AllowFilter = false;
            this.grvBgPosition.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvBgPosition.OptionsNavigation.AutoFocusNewRow = true;
            this.grvBgPosition.OptionsNavigation.UseTabKey = false;
            this.grvBgPosition.OptionsView.ColumnAutoWidth = false;
            this.grvBgPosition.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvBgPosition.OptionsView.ShowGroupPanel = false;
            this.grvBgPosition.OptionsView.ShowIndicator = false;
            // 
            // colPositionID
            // 
            this.colPositionID.Caption = "Position-ID";
            this.colPositionID.FieldName = "BgPositionID";
            this.colPositionID.Name = "colPositionID";
            this.colPositionID.Visible = true;
            this.colPositionID.VisibleIndex = 0;
            // 
            // colKat
            // 
            this.colKat.AppearanceCell.Options.UseTextOptions = true;
            this.colKat.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKat.Caption = "Kat.";
            this.colKat.FieldName = "BgKategorieCode";
            this.colKat.Name = "colKat";
            this.colKat.Visible = true;
            this.colKat.VisibleIndex = 1;
            this.colKat.Width = 35;
            // 
            // colDetailKostenart
            // 
            this.colDetailKostenart.Caption = "KoA";
            this.colDetailKostenart.FieldName = "KOA";
            this.colDetailKostenart.Name = "colDetailKostenart";
            this.colDetailKostenart.Visible = true;
            this.colDetailKostenart.VisibleIndex = 2;
            this.colDetailKostenart.Width = 45;
            // 
            // colDetailBuchungstext
            // 
            this.colDetailBuchungstext.Caption = "Buchungstext";
            this.colDetailBuchungstext.FieldName = "Buchungstext";
            this.colDetailBuchungstext.Name = "colDetailBuchungstext";
            this.colDetailBuchungstext.Visible = true;
            this.colDetailBuchungstext.VisibleIndex = 3;
            this.colDetailBuchungstext.Width = 200;
            // 
            // colPerson
            // 
            this.colPerson.Caption = "Person";
            this.colPerson.FieldName = "BaPersonID";
            this.colPerson.Name = "colPerson";
            this.colPerson.Visible = true;
            this.colPerson.VisibleIndex = 5;
            this.colPerson.Width = 120;
            // 
            // colDetailBetrag
            // 
            this.colDetailBetrag.Caption = "Betrag";
            this.colDetailBetrag.DisplayFormat.FormatString = "N2";
            this.colDetailBetrag.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDetailBetrag.FieldName = "Betrag";
            this.colDetailBetrag.Name = "colDetailBetrag";
            this.colDetailBetrag.Visible = true;
            this.colDetailBetrag.VisibleIndex = 4;
            // 
            // colVerwPeriodeVon
            // 
            this.colVerwPeriodeVon.Caption = "Verw. von";
            this.colVerwPeriodeVon.FieldName = "VerwPeriodeVon";
            this.colVerwPeriodeVon.Name = "colVerwPeriodeVon";
            this.colVerwPeriodeVon.Visible = true;
            this.colVerwPeriodeVon.VisibleIndex = 7;
            this.colVerwPeriodeVon.Width = 70;
            // 
            // colSpezKonto
            // 
            this.colSpezKonto.Caption = "Spezialkonto";
            this.colSpezKonto.FieldName = "SpezKonto";
            this.colSpezKonto.Name = "colSpezKonto";
            this.colSpezKonto.Visible = true;
            this.colSpezKonto.VisibleIndex = 6;
            this.colSpezKonto.Width = 100;
            // 
            // colVerwPeriodeBis
            // 
            this.colVerwPeriodeBis.Caption = "Verw. bis";
            this.colVerwPeriodeBis.FieldName = "VerwPeriodeBis";
            this.colVerwPeriodeBis.Name = "colVerwPeriodeBis";
            this.colVerwPeriodeBis.Visible = true;
            this.colVerwPeriodeBis.VisibleIndex = 8;
            this.colVerwPeriodeBis.Width = 70;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "Stat.";
            this.colStatus.ColumnEdit = this.repStatusImg;
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 9;
            this.colStatus.Width = 40;
            // 
            // repStatusImg
            // 
            this.repStatusImg.AutoHeight = false;
            this.repStatusImg.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStatusImg.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.repStatusImg.Name = "repStatusImg";
            // 
            // colTyp
            // 
            this.colTyp.AppearanceCell.Options.UseTextOptions = true;
            this.colTyp.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTyp.AppearanceHeader.Options.UseTextOptions = true;
            this.colTyp.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTyp.Caption = "*";
            this.colTyp.FieldName = "Typ";
            this.colTyp.Name = "colTyp";
            this.colTyp.Visible = true;
            this.colTyp.VisibleIndex = 10;
            this.colTyp.Width = 20;
            // 
            // edtKostenart
            // 
            this.edtKostenart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKostenart.DataMember = "Kostenart";
            this.edtKostenart.DataSource = this.qryBgPosition;
            this.edtKostenart.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtKostenart.Location = new System.Drawing.Point(153, 39);
            this.edtKostenart.Name = "edtKostenart";
            this.edtKostenart.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtKostenart.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKostenart.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKostenart.Properties.Appearance.Options.UseBackColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKostenart.Properties.Appearance.Options.UseFont = true;
            this.edtKostenart.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.edtKostenart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1)});
            this.edtKostenart.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKostenart.Size = new System.Drawing.Size(444, 24);
            this.edtKostenart.TabIndex = 4;
            this.edtKostenart.UserModifiedFld += new KiSS4.Gui.UserModifiedFldEventHandler(this.edtKostenart_UserModifiedFld);
            // 
            // edtBuchungstext
            // 
            this.edtBuchungstext.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBuchungstext.DataMember = "Buchungstext";
            this.edtBuchungstext.DataSource = this.qryBgPosition;
            this.edtBuchungstext.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBuchungstext.Location = new System.Drawing.Point(153, 61);
            this.edtBuchungstext.Name = "edtBuchungstext";
            this.edtBuchungstext.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBuchungstext.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBuchungstext.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBuchungstext.Properties.Appearance.Options.UseBackColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBuchungstext.Properties.Appearance.Options.UseFont = true;
            this.edtBuchungstext.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBuchungstext.Size = new System.Drawing.Size(444, 24);
            this.edtBuchungstext.TabIndex = 6;
            // 
            // edtBetrag
            // 
            this.edtBetrag.DataMember = "Betrag";
            this.edtBetrag.DataSource = this.qryBgPosition;
            this.edtBetrag.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBetrag.Location = new System.Drawing.Point(153, 91);
            this.edtBetrag.Name = "edtBetrag";
            this.edtBetrag.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtBetrag.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBetrag.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBetrag.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBetrag.Properties.Appearance.Options.UseBackColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBetrag.Properties.Appearance.Options.UseFont = true;
            this.edtBetrag.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBetrag.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBetrag.Properties.DisplayFormat.FormatString = "n2";
            this.edtBetrag.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Properties.EditFormat.FormatString = "n2";
            this.edtBetrag.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtBetrag.Size = new System.Drawing.Size(102, 24);
            this.edtBetrag.TabIndex = 8;
            // 
            // edtBaPersonID
            // 
            this.edtBaPersonID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBaPersonID.DataMember = "BaPersonID";
            this.edtBaPersonID.DataSource = this.qryBgPosition;
            this.edtBaPersonID.Location = new System.Drawing.Point(153, 121);
            this.edtBaPersonID.Name = "edtBaPersonID";
            this.edtBaPersonID.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtBaPersonID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBaPersonID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBaPersonID.Properties.Appearance.Options.UseFont = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBaPersonID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBaPersonID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject2.Options.UseBackColor = true;
            this.edtBaPersonID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2)});
            this.edtBaPersonID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBaPersonID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("NameVorname")});
            this.edtBaPersonID.Properties.DisplayMember = "NameVorname";
            this.edtBaPersonID.Properties.NullText = "";
            this.edtBaPersonID.Properties.ShowFooter = false;
            this.edtBaPersonID.Properties.ShowHeader = false;
            this.edtBaPersonID.Properties.ValueMember = "BaPersonID";
            this.edtBaPersonID.Size = new System.Drawing.Size(444, 24);
            this.edtBaPersonID.TabIndex = 11;
            // 
            // edtBgSpezkontoID
            // 
            this.edtBgSpezkontoID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtBgSpezkontoID.DataMember = "BgSpezkontoID";
            this.edtBgSpezkontoID.DataSource = this.qryBgPosition;
            this.edtBgSpezkontoID.EditMode = Kiss.Interfaces.UI.EditModeType.Required;
            this.edtBgSpezkontoID.Location = new System.Drawing.Point(153, 151);
            this.edtBgSpezkontoID.Name = "edtBgSpezkontoID";
            this.edtBgSpezkontoID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(200)))));
            this.edtBgSpezkontoID.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSpezkontoID.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSpezkontoID.Properties.Appearance.Options.UseFont = true;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSpezkontoID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject3.Options.UseBackColor = true;
            this.edtBgSpezkontoID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject3)});
            this.edtBgSpezkontoID.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSpezkontoID.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Typ", "Typ", 100),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOA_S", "KoA S", 50),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KOA_H", "KoA H", 50),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", "Text", 300),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Saldo", "Saldo", 50, DevExpress.Utils.FormatType.Numeric, "n2", true, DevExpress.Utils.HorzAlignment.Default, DevExpress.Data.ColumnSortOrder.None)});
            this.edtBgSpezkontoID.Properties.DisplayMember = "Text";
            this.edtBgSpezkontoID.Properties.NullText = "";
            this.edtBgSpezkontoID.Properties.PopupWidth = 600;
            this.edtBgSpezkontoID.Properties.ShowFooter = false;
            this.edtBgSpezkontoID.Properties.ShowHeader = false;
            this.edtBgSpezkontoID.Properties.ValueMember = "Code";
            this.edtBgSpezkontoID.Size = new System.Drawing.Size(444, 24);
            this.edtBgSpezkontoID.TabIndex = 13;
            this.edtBgSpezkontoID.EditValueChanged += new System.EventHandler(this.edtBgSpezkontoID_EditValueChanged);
            this.edtBgSpezkontoID.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.edtBgSpezkontoID_EditValueChanging);
            // 
            // edtVerwPeriodeVon
            // 
            this.edtVerwPeriodeVon.DataMember = "VerwPeriodeVon";
            this.edtVerwPeriodeVon.DataSource = this.qryBgPosition;
            this.edtVerwPeriodeVon.EditValue = null;
            this.edtVerwPeriodeVon.Location = new System.Drawing.Point(153, 181);
            this.edtVerwPeriodeVon.Name = "edtVerwPeriodeVon";
            this.edtVerwPeriodeVon.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeVon.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeVon.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeVon.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeVon.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeVon.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject5.Options.UseBackColor = true;
            this.edtVerwPeriodeVon.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeVon.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5)});
            this.edtVerwPeriodeVon.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeVon.Properties.ShowToday = false;
            this.edtVerwPeriodeVon.Size = new System.Drawing.Size(100, 24);
            this.edtVerwPeriodeVon.TabIndex = 15;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(695, 181);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 24);
            this.btnOk.TabIndex = 22;
            this.btnOk.Text = "OK";
            this.btnOk.UseCompatibleTextRendering = true;
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // edtVerwPeriodeBis
            // 
            this.edtVerwPeriodeBis.DataMember = "VerwPeriodeBis";
            this.edtVerwPeriodeBis.DataSource = this.qryBgPosition;
            this.edtVerwPeriodeBis.EditValue = null;
            this.edtVerwPeriodeBis.Location = new System.Drawing.Point(272, 181);
            this.edtVerwPeriodeBis.Name = "edtVerwPeriodeBis";
            this.edtVerwPeriodeBis.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtVerwPeriodeBis.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtVerwPeriodeBis.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtVerwPeriodeBis.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseBorderColor = true;
            this.edtVerwPeriodeBis.Properties.Appearance.Options.UseFont = true;
            this.edtVerwPeriodeBis.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject6.Options.UseBackColor = true;
            this.edtVerwPeriodeBis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", 8, true, true, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("edtVerwPeriodeBis.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject6)});
            this.edtVerwPeriodeBis.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtVerwPeriodeBis.Properties.ShowToday = false;
            this.edtVerwPeriodeBis.Size = new System.Drawing.Size(102, 24);
            this.edtVerwPeriodeBis.TabIndex = 17;
            // 
            // btnAbbrechen
            // 
            this.btnAbbrechen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbbrechen.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAbbrechen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbbrechen.Location = new System.Drawing.Point(791, 181);
            this.btnAbbrechen.Margin = new System.Windows.Forms.Padding(3, 3, 9, 9);
            this.btnAbbrechen.Name = "btnAbbrechen";
            this.btnAbbrechen.Size = new System.Drawing.Size(90, 24);
            this.btnAbbrechen.TabIndex = 23;
            this.btnAbbrechen.Text = "Abbrechen";
            this.btnAbbrechen.UseCompatibleTextRendering = true;
            this.btnAbbrechen.UseVisualStyleBackColor = true;
            this.btnAbbrechen.Click += new System.EventHandler(this.btnAbbrechen_Click);
            // 
            // lblVerwPeriodeStrich
            // 
            this.lblVerwPeriodeStrich.Location = new System.Drawing.Point(259, 181);
            this.lblVerwPeriodeStrich.Name = "lblVerwPeriodeStrich";
            this.lblVerwPeriodeStrich.Size = new System.Drawing.Size(7, 24);
            this.lblVerwPeriodeStrich.TabIndex = 16;
            this.lblVerwPeriodeStrich.Text = "-";
            this.lblVerwPeriodeStrich.UseCompatibleTextRendering = true;
            // 
            // lblBetrag
            // 
            this.lblBetrag.Location = new System.Drawing.Point(44, 91);
            this.lblBetrag.Name = "lblBetrag";
            this.lblBetrag.Size = new System.Drawing.Size(103, 24);
            this.lblBetrag.TabIndex = 7;
            this.lblBetrag.Text = "Betrag CHF";
            this.lblBetrag.UseCompatibleTextRendering = true;
            // 
            // lblKostenart
            // 
            this.lblKostenart.Location = new System.Drawing.Point(44, 39);
            this.lblKostenart.Name = "lblKostenart";
            this.lblKostenart.Size = new System.Drawing.Size(103, 24);
            this.lblKostenart.TabIndex = 3;
            this.lblKostenart.Text = "KoA/Positionsart";
            this.lblKostenart.UseCompatibleTextRendering = true;
            // 
            // lblBuchungstext
            // 
            this.lblBuchungstext.Location = new System.Drawing.Point(44, 61);
            this.lblBuchungstext.Name = "lblBuchungstext";
            this.lblBuchungstext.Size = new System.Drawing.Size(103, 24);
            this.lblBuchungstext.TabIndex = 5;
            this.lblBuchungstext.Text = "Buchungstext";
            this.lblBuchungstext.UseCompatibleTextRendering = true;
            // 
            // edtDifferenz
            // 
            this.edtDifferenz.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtDifferenz.Location = new System.Drawing.Point(87, 73);
            this.edtDifferenz.Name = "edtDifferenz";
            this.edtDifferenz.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtDifferenz.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtDifferenz.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtDifferenz.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtDifferenz.Properties.Appearance.Options.UseBackColor = true;
            this.edtDifferenz.Properties.Appearance.Options.UseBorderColor = true;
            this.edtDifferenz.Properties.Appearance.Options.UseFont = true;
            this.edtDifferenz.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtDifferenz.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtDifferenz.Properties.DisplayFormat.FormatString = "n2";
            this.edtDifferenz.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDifferenz.Properties.EditFormat.FormatString = "n2";
            this.edtDifferenz.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtDifferenz.Properties.Mask.EditMask = "N2";
            this.edtDifferenz.Properties.ReadOnly = true;
            this.edtDifferenz.Size = new System.Drawing.Size(89, 24);
            this.edtDifferenz.TabIndex = 5;
            // 
            // lblDifferenz
            // 
            this.lblDifferenz.Location = new System.Drawing.Point(9, 73);
            this.lblDifferenz.Name = "lblDifferenz";
            this.lblDifferenz.Size = new System.Drawing.Size(72, 24);
            this.lblDifferenz.TabIndex = 4;
            this.lblDifferenz.Text = "Differenz";
            this.lblDifferenz.UseCompatibleTextRendering = true;
            // 
            // edtTotalbetragAlt
            // 
            this.edtTotalbetragAlt.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotalbetragAlt.Location = new System.Drawing.Point(87, 20);
            this.edtTotalbetragAlt.Name = "edtTotalbetragAlt";
            this.edtTotalbetragAlt.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotalbetragAlt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTotalbetragAlt.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotalbetragAlt.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotalbetragAlt.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotalbetragAlt.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotalbetragAlt.Properties.Appearance.Options.UseFont = true;
            this.edtTotalbetragAlt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotalbetragAlt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotalbetragAlt.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotalbetragAlt.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalbetragAlt.Properties.EditFormat.FormatString = "n2";
            this.edtTotalbetragAlt.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalbetragAlt.Properties.Mask.EditMask = "N2";
            this.edtTotalbetragAlt.Properties.ReadOnly = true;
            this.edtTotalbetragAlt.Size = new System.Drawing.Size(89, 24);
            this.edtTotalbetragAlt.TabIndex = 1;
            // 
            // lblTotalAlt
            // 
            this.lblTotalAlt.Location = new System.Drawing.Point(9, 20);
            this.lblTotalAlt.Name = "lblTotalAlt";
            this.lblTotalAlt.Size = new System.Drawing.Size(72, 24);
            this.lblTotalAlt.TabIndex = 0;
            this.lblTotalAlt.Text = "Total alt";
            this.lblTotalAlt.UseCompatibleTextRendering = true;
            // 
            // lblBaPersonID
            // 
            this.lblBaPersonID.Location = new System.Drawing.Point(44, 121);
            this.lblBaPersonID.Name = "lblBaPersonID";
            this.lblBaPersonID.Size = new System.Drawing.Size(103, 24);
            this.lblBaPersonID.TabIndex = 10;
            this.lblBaPersonID.Text = "Betrifft Person";
            this.lblBaPersonID.UseCompatibleTextRendering = true;
            // 
            // lblVerwPeriode
            // 
            this.lblVerwPeriode.Location = new System.Drawing.Point(44, 181);
            this.lblVerwPeriode.Name = "lblVerwPeriode";
            this.lblVerwPeriode.Size = new System.Drawing.Size(103, 24);
            this.lblVerwPeriode.TabIndex = 14;
            this.lblVerwPeriode.Text = "Verwendungsp.";
            this.lblVerwPeriode.UseCompatibleTextRendering = true;
            // 
            // lblBgSplittingCode
            // 
            this.lblBgSplittingCode.Location = new System.Drawing.Point(390, 181);
            this.lblBgSplittingCode.Name = "lblBgSplittingCode";
            this.lblBgSplittingCode.Size = new System.Drawing.Size(40, 24);
            this.lblBgSplittingCode.TabIndex = 18;
            this.lblBgSplittingCode.Text = "Split.";
            this.lblBgSplittingCode.UseCompatibleTextRendering = true;
            // 
            // edtBgSplittingCode
            // 
            this.edtBgSplittingCode.AllowNull = false;
            this.edtBgSplittingCode.DataMember = "BgSplittingartCode";
            this.edtBgSplittingCode.DataSource = this.qryBgPosition;
            this.edtBgSplittingCode.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtBgSplittingCode.Location = new System.Drawing.Point(436, 181);
            this.edtBgSplittingCode.Name = "edtBgSplittingCode";
            this.edtBgSplittingCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtBgSplittingCode.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtBgSplittingCode.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSplittingCode.Properties.Appearance.Options.UseBackColor = true;
            this.edtBgSplittingCode.Properties.Appearance.Options.UseBorderColor = true;
            this.edtBgSplittingCode.Properties.Appearance.Options.UseFont = true;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtBgSplittingCode.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtBgSplittingCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtBgSplittingCode.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtBgSplittingCode.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text")});
            this.edtBgSplittingCode.Properties.DisplayMember = "Text";
            this.edtBgSplittingCode.Properties.NullText = "";
            this.edtBgSplittingCode.Properties.ReadOnly = true;
            this.edtBgSplittingCode.Properties.ShowFooter = false;
            this.edtBgSplittingCode.Properties.ShowHeader = false;
            this.edtBgSplittingCode.Properties.ValueMember = "Code";
            this.edtBgSplittingCode.Size = new System.Drawing.Size(22, 24);
            this.edtBgSplittingCode.TabIndex = 19;
            this.edtBgSplittingCode.TabStop = false;
            // 
            // lblBgSpezkontoID
            // 
            this.lblBgSpezkontoID.Location = new System.Drawing.Point(44, 151);
            this.lblBgSpezkontoID.Name = "lblBgSpezkontoID";
            this.lblBgSpezkontoID.Size = new System.Drawing.Size(103, 24);
            this.lblBgSpezkontoID.TabIndex = 12;
            this.lblBgSpezkontoID.Text = "Spezialkonto";
            this.lblBgSpezkontoID.UseCompatibleTextRendering = true;
            // 
            // lblKategorie
            // 
            this.lblKategorie.Location = new System.Drawing.Point(44, 9);
            this.lblKategorie.Name = "lblKategorie";
            this.lblKategorie.Size = new System.Drawing.Size(103, 24);
            this.lblKategorie.TabIndex = 1;
            this.lblKategorie.Text = "Kategorie";
            this.lblKategorie.UseCompatibleTextRendering = true;
            // 
            // edtKategorie
            // 
            this.edtKategorie.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtKategorie.DataMember = "BgKategorieCode";
            this.edtKategorie.DataSource = this.qryBgPosition;
            this.edtKategorie.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtKategorie.Location = new System.Drawing.Point(153, 9);
            this.edtKategorie.LOVName = "BgKategorie";
            this.edtKategorie.Name = "edtKategorie";
            this.edtKategorie.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtKategorie.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtKategorie.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtKategorie.Properties.Appearance.Options.UseBackColor = true;
            this.edtKategorie.Properties.Appearance.Options.UseBorderColor = true;
            this.edtKategorie.Properties.Appearance.Options.UseFont = true;
            this.edtKategorie.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.edtKategorie.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.edtKategorie.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.edtKategorie.Properties.AppearanceDropDown.Options.UseFont = true;
            this.edtKategorie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.edtKategorie.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, DevExpress.Utils.HorzAlignment.Center, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject4)});
            this.edtKategorie.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtKategorie.Properties.NullText = "";
            this.edtKategorie.Properties.ReadOnly = true;
            this.edtKategorie.Properties.ShowFooter = false;
            this.edtKategorie.Properties.ShowHeader = false;
            this.edtKategorie.Size = new System.Drawing.Size(444, 24);
            this.edtKategorie.TabIndex = 2;
            // 
            // btnEinzelzahlung
            // 
            this.btnEinzelzahlung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEinzelzahlung.IconID = 1386;
            this.btnEinzelzahlung.Location = new System.Drawing.Point(5, 9);
            this.btnEinzelzahlung.Name = "btnEinzelzahlung";
            this.btnEinzelzahlung.Size = new System.Drawing.Size(24, 24);
            this.btnEinzelzahlung.TabIndex = 0;
            this.btnEinzelzahlung.UseCompatibleTextRendering = true;
            this.btnEinzelzahlung.UseVisualStyleBackColor = false;
            this.btnEinzelzahlung.Click += new System.EventHandler(this.btnEinzelzahlung_Click);
            // 
            // btnZusatzleistung
            // 
            this.btnZusatzleistung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZusatzleistung.IconID = 1388;
            this.btnZusatzleistung.Location = new System.Drawing.Point(5, 39);
            this.btnZusatzleistung.Name = "btnZusatzleistung";
            this.btnZusatzleistung.Size = new System.Drawing.Size(24, 24);
            this.btnZusatzleistung.TabIndex = 1;
            this.btnZusatzleistung.UseCompatibleTextRendering = true;
            this.btnZusatzleistung.UseVisualStyleBackColor = false;
            this.btnZusatzleistung.Click += new System.EventHandler(this.btnZusatzleistung_Click);
            // 
            // ctlErfassungMutation
            // 
            this.ctlErfassungMutation.ActiveSQLQuery = this.qryBgPosition;
            this.ctlErfassungMutation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlErfassungMutation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlErfassungMutation.Location = new System.Drawing.Point(627, 129);
            this.ctlErfassungMutation.Name = "ctlErfassungMutation";
            this.ctlErfassungMutation.Size = new System.Drawing.Size(254, 38);
            this.ctlErfassungMutation.TabIndex = 21;
            // 
            // edtTotalbetragNeu
            // 
            this.edtTotalbetragNeu.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtTotalbetragNeu.Location = new System.Drawing.Point(87, 43);
            this.edtTotalbetragNeu.Name = "edtTotalbetragNeu";
            this.edtTotalbetragNeu.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.edtTotalbetragNeu.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtTotalbetragNeu.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtTotalbetragNeu.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtTotalbetragNeu.Properties.Appearance.Options.UseBackColor = true;
            this.edtTotalbetragNeu.Properties.Appearance.Options.UseBorderColor = true;
            this.edtTotalbetragNeu.Properties.Appearance.Options.UseFont = true;
            this.edtTotalbetragNeu.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtTotalbetragNeu.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.edtTotalbetragNeu.Properties.DisplayFormat.FormatString = "n2";
            this.edtTotalbetragNeu.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalbetragNeu.Properties.EditFormat.FormatString = "n2";
            this.edtTotalbetragNeu.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.edtTotalbetragNeu.Properties.Mask.EditMask = "N2";
            this.edtTotalbetragNeu.Properties.ReadOnly = true;
            this.edtTotalbetragNeu.Size = new System.Drawing.Size(89, 24);
            this.edtTotalbetragNeu.TabIndex = 3;
            // 
            // lblTotalNeu
            // 
            this.lblTotalNeu.Location = new System.Drawing.Point(9, 43);
            this.lblTotalNeu.Name = "lblTotalNeu";
            this.lblTotalNeu.Size = new System.Drawing.Size(72, 24);
            this.lblTotalNeu.TabIndex = 2;
            this.lblTotalNeu.Text = "Total neu";
            this.lblTotalNeu.UseCompatibleTextRendering = true;
            // 
            // qryBgBudget
            // 
            this.qryBgBudget.HostControl = this;
            this.qryBgBudget.SelectStatement = resources.GetString("qryBgBudget.SelectStatement");
            this.qryBgBudget.TableName = "BgBudget";
            // 
            // panDetails
            // 
            this.panDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDetails.Controls.Add(this.btnPositionBewilligung);
            this.panDetails.Controls.Add(this.grpBerechnung);
            this.panDetails.Controls.Add(this.panNewItems);
            this.panDetails.Controls.Add(this.lblKategorie);
            this.panDetails.Controls.Add(this.edtKostenart);
            this.panDetails.Controls.Add(this.edtBuchungstext);
            this.panDetails.Controls.Add(this.ctlErfassungMutation);
            this.panDetails.Controls.Add(this.edtBetrag);
            this.panDetails.Controls.Add(this.edtBaPersonID);
            this.panDetails.Controls.Add(this.edtBgSpezkontoID);
            this.panDetails.Controls.Add(this.edtKategorie);
            this.panDetails.Controls.Add(this.edtVerwPeriodeVon);
            this.panDetails.Controls.Add(this.btnOk);
            this.panDetails.Controls.Add(this.lblBgSpezkontoID);
            this.panDetails.Controls.Add(this.edtVerwPeriodeBis);
            this.panDetails.Controls.Add(this.edtBgSplittingCode);
            this.panDetails.Controls.Add(this.btnAbbrechen);
            this.panDetails.Controls.Add(this.lblBgSplittingCode);
            this.panDetails.Controls.Add(this.lblVerwPeriodeStrich);
            this.panDetails.Controls.Add(this.lblVerwPeriode);
            this.panDetails.Controls.Add(this.lblBetrag);
            this.panDetails.Controls.Add(this.lblBaPersonID);
            this.panDetails.Controls.Add(this.lblKostenart);
            this.panDetails.Controls.Add(this.lblBuchungstext);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 153);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(892, 218);
            this.panDetails.TabIndex = 1;
            // 
            // btnPositionBewilligung
            // 
            this.btnPositionBewilligung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPositionBewilligung.Image = ((System.Drawing.Image)(resources.GetObject("btnPositionBewilligung.Image")));
            this.btnPositionBewilligung.Location = new System.Drawing.Point(261, 91);
            this.btnPositionBewilligung.Name = "btnPositionBewilligung";
            this.btnPositionBewilligung.Size = new System.Drawing.Size(24, 24);
            this.btnPositionBewilligung.TabIndex = 9;
            this.btnPositionBewilligung.UseCompatibleTextRendering = true;
            this.btnPositionBewilligung.UseVisualStyleBackColor = false;
            this.btnPositionBewilligung.Click += new System.EventHandler(this.btnPositionBewilligung_Click);
            // 
            // grpBerechnung
            // 
            this.grpBerechnung.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBerechnung.Controls.Add(this.lblTotalAlt);
            this.grpBerechnung.Controls.Add(this.lblDifferenz);
            this.grpBerechnung.Controls.Add(this.edtDifferenz);
            this.grpBerechnung.Controls.Add(this.lblTotalNeu);
            this.grpBerechnung.Controls.Add(this.edtTotalbetragAlt);
            this.grpBerechnung.Controls.Add(this.edtTotalbetragNeu);
            this.grpBerechnung.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grpBerechnung.Location = new System.Drawing.Point(627, 9);
            this.grpBerechnung.Name = "grpBerechnung";
            this.grpBerechnung.Size = new System.Drawing.Size(254, 106);
            this.grpBerechnung.TabIndex = 20;
            this.grpBerechnung.TabStop = false;
            this.grpBerechnung.Text = "Validierung Betrag";
            // 
            // panNewItems
            // 
            this.panNewItems.Controls.Add(this.panBorder);
            this.panNewItems.Controls.Add(this.btnEinzelzahlung);
            this.panNewItems.Controls.Add(this.btnZusatzleistung);
            this.panNewItems.Dock = System.Windows.Forms.DockStyle.Left;
            this.panNewItems.Location = new System.Drawing.Point(0, 0);
            this.panNewItems.Name = "panNewItems";
            this.panNewItems.Size = new System.Drawing.Size(35, 216);
            this.panNewItems.TabIndex = 0;
            // 
            // panBorder
            // 
            this.panBorder.BackColor = System.Drawing.Color.Black;
            this.panBorder.Dock = System.Windows.Forms.DockStyle.Right;
            this.panBorder.Location = new System.Drawing.Point(34, 0);
            this.panBorder.Name = "panBorder";
            this.panBorder.Size = new System.Drawing.Size(1, 216);
            this.panBorder.TabIndex = 3;
            // 
            // DlgWhWeitereKOA
            // 
            this.ActiveSQLQuery = this.qryBgPosition;
            this.CancelButton = this.btnAbbrechen;
            this.ClientSize = new System.Drawing.Size(892, 371);
            this.Controls.Add(this.grdBgPosition);
            this.Controls.Add(this.panDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgWhWeitereKOA";
            this.Text = "Weitere KoA";
            ((System.ComponentModel.ISupportInitialize)(this.grdBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvBgPosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStatusImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKostenart.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBuchungstext.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBetrag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSpezkontoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeVon.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtVerwPeriodeBis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriodeStrich)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBetrag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKostenart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBuchungstext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtDifferenz.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDifferenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalbetragAlt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalAlt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBaPersonID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblVerwPeriode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtBgSplittingCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblBgSpezkontoID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtKategorie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtTotalbetragNeu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTotalNeu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryBgBudget)).EndInit();
            this.panDetails.ResumeLayout(false);
            this.grpBerechnung.ResumeLayout(false);
            this.panNewItems.ResumeLayout(false);
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

        /// <summary>
        /// Get if user used granting of positions. In this case the data could be changed without pressing the ok-button.
        /// </summary>
        public bool UsedGranting
        {
            private set;
            get;
        }

        #endregion

        #region EventHandlers

        private void btnAbbrechen_Click(object sender, System.EventArgs e)
        {
            this.userCancel = true;
        }

        private void btnEinzelzahlung_Click(object sender, System.EventArgs e)
        {
            NeuePosition(Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen));
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            #region Validation and Preparation

            // save all changes first
            if (!qryBgPosition.Post())
            {
                return;
            }

            // validate modification
            if (!_dataModified)
            {
                if (UsedGranting)
                {
                    // no data changes made but used granting
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    // really no changes made
                    this.userCancel = true;
                    this.DialogResult = DialogResult.Cancel;
                }

                // done
                return;
            }

            // update amount information
            UpdateSum();

            if (Convert.ToDecimal(edtDifferenz.EditValue) != 0m)
            {
                if (!KissMsg.ShowQuestion(this.Name,
                                          "ConfirmSaveModifiedTotal",
                                          "Das neue Total ist nicht gleich dem alten Total. Soll trotzdem gespeichert werden?"))
                {
                    return;
                }
            }

            #endregion

            //Speichern aller Position en bloc
            //- Detailpositionen neu anlegen
            //- Auszahlinfo für Detailposition kopieren von der Hauptposition

            // store list of modified rows with newBgPositionID
            System.Collections.Generic.List<int> rowsModified = new System.Collections.Generic.List<int>();

            // start new transaction
            Session.BeginTransaction();

            BewilligungAktion? selectedBewilligungAktion = null;
            bool dialogShown = false;
            try
            {
                // Detailposten löschen, inkl. Auszahlinfo (warning: cascading delete!)
                DBUtil.ExecSQLThrowingException(@"
                    DELETE FROM dbo.BgPosition
                    WHERE BgPositionID_Parent = {0};", _bgPositionID);

                object newBgPositionID;

                // loop all rows
                foreach (DataRow row in qryBgPosition.DataTable.Rows)
                {
                    // check state of row
                    if (row.RowState == DataRowState.Deleted)
                    {
                        // go on with next row
                        continue;
                    }

                    // check if detail position
                    if (!DBUtil.IsEmpty(row[DBO.BgPosition.BgPositionID_Parent]))
                    {
                        // Detailposition als Kopie der Hauptposition anlegen, inkl. Auszahlinfo
                        // Auszahltermin immer "Valuta"
                        SqlQuery qry = DBUtil.OpenSQL(@"
                            DECLARE @BgPositionID INT;
                            DECLARE @BgAuszahlungPersonID INT;
                            DECLARE @NewBgPositionID INT;
                            DECLARE @WhereClause VARCHAR(200);

                            SET @BgPositionID = {0};

                            -- BgPosition
                            SET @WhereClause = 'BgPositionID = ' + CONVERT(VARCHAR, @BgPositionID)
                            EXEC dbo.spDuplicateRows 'BgPosition', @WhereClause, 'BgPositionID_Parent', @BgPositionID;
                            SET @NewBgPositionID = @@IDENTITY;

                            -- BgAuszahlungPerson
                            SET @WhereClause = 'BgPositionID = ' + CONVERT(VARCHAR, @BgPositionID);
                            EXEC dbo.spDuplicateRows 'BgAuszahlungPerson', @WhereClause, 'BgPositionID', @NewBgPositionID;

                            -- BgAuszahlungPersonTermin
                            SELECT @WhereClause = 'BgAuszahlungPersonID = ' + CONVERT(VARCHAR, BgAuszahlungPersonID)
                            FROM dbo.BgAuszahlungPerson
                            WHERE BgPositionID = @BgPositionID;

                            EXEC dbo.spDuplicateRows 'BgAuszahlungPersonTermin', @WhereClause, 'BgAuszahlungPersonID', @@IDENTITY;

                            -- done, select id
                            SELECT NewBgPositionID = @NewBgPositionID;", _bgPositionID);

                        newBgPositionID = qry["NewBgPositionID"];
                    }
                    else
                    {
                        newBgPositionID = _bgPositionID;
                    }

                    // Position updaten mit erfassten Daten
                    DBUtil.ExecSQLThrowingException(@"
                        UPDATE dbo.BgPosition
                        SET BgKategorieCode         = {0},
                            BgPositionsartID        = {1},
                            Buchungstext            = {2},
                            BaPersonID              = {3},
                            Betrag                  = {4},
                            BgSpezkontoID           = {5},
                            VerwPeriodeVon          = {6},
                            VerwPeriodeBis          = {7},
                            ErstelltUserID          = {8},
                            ErstelltDatum           = {9},
                            MutiertUserID           = {10},
                            MutiertDatum            = {11},
                            BgBewilligungStatusCode = CASE
                                                        WHEN {0} = 101 THEN {12}            -- EZ: update granting on EZ as defined by current code
                                                        WHEN ISNULL({13}, 0) = 0 THEN {12}  -- ZL: update granting on ZL when row was not modified by current code
                                                        ELSE 1                              -- ZL: modified row: apply state as angefragt > handled later with matching permission-logging in c# code
                                                      END
                        WHERE BgPositionID = {14};", row["BgKategorieCode"],
                                                     row["BgPositionsartID"],
                                                     row["Buchungstext"],
                                                     row["BaPersonID"],
                                                     row["Betrag"],
                                                     row["BgSpezkontoID"],
                                                     row["VerwPeriodeVon"],
                                                     row["VerwPeriodeBis"],
                                                     row["ErstelltUserID"],
                                                     row["ErstelltDatum"],
                                                     row["MutiertUserID"],
                                                     row["MutiertDatum"],
                                                     row["BgBewilligungStatusCode"],
                                                     row["RowModified"],
                                                     newBgPositionID);

                    // check if need to insert new entry in history of BgBewilligung (for new entries only > empty BgPositionID)
                    if (DBUtil.IsEmpty(row[DBO.BgPosition.BgPositionID]) &&
                        ((BgBewilligungStatus)Convert.ToInt32(row[DBO.BgPosition.BgBewilligungStatusCode])) == BgBewilligungStatus.Erteilt)
                    {
                        // new entry: create log-entry into Bewilligungs-History: Bewilligt
                        CtlWhAuszahlungen.InsertGrantingHistory(Convert.ToInt32(newBgPositionID),
                                                                BgBewilligungStatus.InVorbereitung,
                                                                BgBewilligungStatus.Erteilt);
                    }

                    // add to modified-list if modified
                    if (newBgPositionID != null && !DBUtil.IsEmpty(row["RowModified"]) && Convert.ToBoolean(row["RowModified"]))
                    {
                        // add
                        rowsModified.Add(Convert.ToInt32(newBgPositionID));
                    }

                } // [foreach row]

                #region Permission Handling

                // refresh query data
                qryBgPosition.Refresh();
                qryBgPosition.First();

                // loop query by position
                while (true)
                {
                    // check if current datarow was previously modified
                    if (rowsModified.Contains(Convert.ToInt32(qryBgPosition[DBO.BgPosition.BgPositionID])))
                    {
                        // permission handling for ZL
                        CtlWhAuszahlungen.ValidateAndHandleZLPermission(ref qryBgPosition, ref qryBgBudget, false, true, true);

                        BgBewilligungStatus bewilligungStatus = (BgBewilligungStatus)qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode];
                        if (ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgKategorieCode]) == Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen) &&
                            bewilligungStatus == BgBewilligungStatus.InVorbereitung)
                        {
                            _bgPositionIDBewilligen = ShUtil.GetCode(qryBgPosition[DBO.BgPosition.BgPositionID]);
                            if (!dialogShown)
                            {
                                // #5478 (comment#26841): For the user's convenience, we automatically display DlgBewilligung if a permission is
                                // required. We then apply the same action for all positions in question without displaying the same dialog over and over
                                if (GetUserPermissionZL())
                                {
                                    //if the user has the necessary rights, don't display the dialog, simply apply 'Bewilligen'
                                    ApplyAction(BewilligungAktion.Bewilligen, false);

                                    // set flag
                                    UsedGranting = true;
                                }
                                else
                                {
                                    //ask the user
                                    DlgBewilligung dlg = new DlgBewilligung(BewilligungTyp.Einzelzahlung, _bgPositionIDBewilligen, bewilligungStatus, GetUserPermissionZL);
                                    dlg.ShowDialog(this);

                                    dialogShown = true;

                                    if (!dlg.UserCancel)
                                    {
                                        selectedBewilligungAktion = dlg.Aktion;
                                        ApplyAction(dlg, false);

                                        // set flag
                                        UsedGranting = true;
                                    }
                                }
                            }
                            else if(selectedBewilligungAktion.HasValue)
                            {
                                ApplyAction(selectedBewilligungAktion.Value, false);

                                // set flag
                                UsedGranting = true;
                            }
                        }

                        // do update permisson-log-code if permission was reset to gray (kind of a hack to have proper working method call above)
                        DBUtil.ExecuteScalarSQLThrowingException(@"
                            UPDATE BEW
                            SET BEW.BgBewilligungCode = 4,    -- aufgehoben
                                BEW.Zurueckgewiesen = 0
                            FROM dbo.BgBewilligung BEW
                            WHERE BEW.BgPositionID = {0}
                              AND BEW.UserID = {1}
                              AND BEW.BgBewilligungCode = 3; -- abgelehnt", qryBgPosition[DBO.BgPosition.BgPositionID], Session.User.UserID);
                    }

                    // go to next position
                    if (!qryBgPosition.Next())
                    {
                        // stop while
                        break;
                    }
                }

                #endregion

                // commit changes
                Session.Commit();
            }
            catch (Exception ex)
            {
                // undo changes
                Session.Rollback();

                // show message and cancel
                KissMsg.ShowError(this.Name,
                                  "ErrorSavingPositionChanges",
                                  "Es ist ein Fehler beim Speichern der Positionen aufgetreten:\r\n\r\n" + ex.Message,
                                  ex);
                return;
            }

            // successfully done
            this.userCancel = false;
            this.DialogResult = DialogResult.OK;
        }

        private void btnPositionBewilligung_Click(object sender, EventArgs e)
        {
            EnableBtnBewilligen();

            // validate first
            if (!CanGrantPosition())
            {
                // button cannot be used
                EnableBtnBewilligen();
                return;
            }

            if (!qryBgPosition.Post() || !btnPositionBewilligung.Enabled)
            {
                return;
            }

            try
            {
                _bgPositionIDBewilligen = Convert.ToInt32(qryBgPosition[DBO.BgPosition.BgPositionID]);
                BgBewilligungStatus bewilligungStatus = (BgBewilligungStatus)qryBgPosition[DBO.BgPosition.BgBewilligungStatusCode];

                if (bewilligungStatus == BgBewilligungStatus.InVorbereitung && GetUserPermissionZL())
                {
                    CtlWhAuszahlungen.InsertGrantingHistory(_bgPositionIDBewilligen, BgBewilligungStatus.InVorbereitung, BgBewilligungStatus.Erteilt);
                    ApplyAction(BewilligungAktion.Bewilligen, true);

                    // set flag
                    UsedGranting = true;
                }
                else
                {
                    DlgBewilligung dlg = new DlgBewilligung(BewilligungTyp.Einzelzahlung, _bgPositionIDBewilligen, bewilligungStatus, GetUserPermissionZL);
                    dlg.ShowDialog(this);

                    if (!dlg.UserCancel)
                    {
                        ApplyAction(dlg, true);

                        // set flag
                        UsedGranting = true;
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(this.Name, "ErrorGrantingPosition", "Es ist ein Fehler beim Bewilligen der Position aufgetreten.", ex);
            }
            finally
            {
                // handle button Bewilligen
                EnableBtnBewilligen();
            }
        }

        private void btnZusatzleistung_Click(object sender, System.EventArgs e)
        {
            NeuePosition(Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen));
        }

        private void edtBgSpezkontoID_EditValueChanged(object sender, System.EventArgs e)
        {
            if (qryBgPosition.IsFilling)
            {
                return;
            }

            if (!edtBgSpezkontoID.Focused)
            {
                return;
            }

            qryBgPosition["BgSpezKontoID"] = edtBgSpezkontoID.EditValue;
            SetSpezialkonto();
            SetEditMode();
        }

        private void edtBgSpezkontoID_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            // apply old value
            _oldBgSpezkontoID = e.OldValue;
        }

        private void edtKostenart_UserModifiedFld(object sender, KiSS4.Gui.UserModifiedFldEventArgs e)
        {
            string searchString = edtKostenart.EditValue.ToString().Replace("*", "%").Replace("?", "_").Replace(" ", "%");

            if (DBUtil.IsEmpty(searchString))
            {
                if (e.ButtonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    qryBgPosition["BgPositionsArtID"] = DBNull.Value;
                    qryBgPosition["Kostenart"] = DBNull.Value;
                    return;
                }
            }

            // Gültigkeit
            int jahr = DBUtil.IsEmpty(qryBgBudget["Jahr"]) ? DateTime.Now.Year : (int)qryBgBudget["Jahr"];
            int monat = DBUtil.IsEmpty(qryBgBudget["Monat"]) ? DateTime.Now.Month : (int)qryBgBudget["Monat"];

            DateTime gueltigVon = new DateTime(jahr, monat, 1);
            DateTime gueltigBis = new DateTime(jahr, monat, 1).AddMonths(1).AddDays(-1);    // Ende des Monats ist ein Tag vor dem Anfang des nächsten Monats

            KissLookupDialog dlg = new KissLookupDialog();
            string sql = string.Format(@"SELECT KOA                 = BKA.KontoNr,
                                  Positionsart        = BPA.Name,
                                  Gruppe              = GRP.Text,
                                  BgPositionsartID$   = BPA.BgPositionsartID,
                                  BgKostenartID$      = BPA.BgKostenartID,
                                  ProPerson$          = BPA.ProPerson,
                                  ProUE$              = BPA.ProUE,
                                  KOAPositionsart$    = BKA.KontoNr + ' '+ BPA.Name,
                                  Name$               = BPA.Name,
                                  BgSplittingArtCode$ = BKA.BgSplittingArtCode,
                                  sqlRichtlinie$      = BPA.sqlRichtlinie,
                                  GruppeFilter$       = CONVERT(VARCHAR(50), GRP.Value3)
                           FROM dbo.WhPositionsart      BPA
                             INNER JOIN dbo.BgKostenart BKA ON BKA.BgKostenartID = BPA.BgKostenartID
                             LEFT  JOIN dbo.XLOVCode    GRP ON GRP.LOVName = 'BgGruppe'
                                                           AND GRP.Code = BPA.BgGruppeCode
                           WHERE BgKategorieCode = {0}
                              AND (BPA.Name LIKE '%' + {1} + '%' OR BKA.KontoNr LIKE {1} + '%')
                              AND ISNULL(BPA.DatumVon, '19000101') <= {2} AND ISNULL(BPA.DatumBis, '99991231') >= {3}
                            ORDER BY KOA, Positionsart;", qryBgPosition[DBO.BgPosition.BgKategorieCode], "{0}", "{1}", "{2}");

            e.Cancel = !dlg.SearchData(sql, searchString, e.ButtonClicked, gueltigVon, gueltigBis, null);

            if (!e.Cancel)
            {
                qryBgPosition["BgPositionsArtID"] = dlg["BgPositionsartID$"];
                qryBgPosition["KOA"] = dlg["KOA"];
                qryBgPosition["Kostenart"] = dlg["KOAPositionsart$"];
                qryBgPosition["Buchungstext"] = dlg["Name$"];
                qryBgPosition["BgSplittingArtCode"] = dlg["BgSplittingArtCode$"];
                qryBgPosition["ProPerson"] = dlg["ProPerson$"];
                qryBgPosition["ProUE"] = dlg["ProUE$"];

                bool proPerson = Convert.ToBoolean(qryBgPosition["ProPerson"]);
                bool proUE = Convert.ToBoolean(qryBgPosition["ProUE"]);

                if (proUE && !proPerson)
                {
                    qryBgPosition["BaPersonID"] = null;
                }

                SetVerwendungsPeriode();
                SetEditMode();
            }
        }

        private void qryBgPosition_AfterDelete(object sender, System.EventArgs e)
        {
            UpdateSum();
        }

        private void qryBgPosition_AfterInsert(object sender, System.EventArgs e)
        {
            qryBgPosition[DBO.BgPosition.BgKategorieCode] = _newBgKategorieCode;    // set kategorie
            qryBgPosition[DBO.BgPosition.BgPositionID_Parent] = _bgPositionID;      // set parentid (used to validate permission)
            qryBgPosition["Status"] = 1; // grau
            qryBgPosition["ProPerson"] = false;
            qryBgPosition["ProUE"] = true;
            qryBgPosition["Typ"] = "+";

            _newBgKategorieCode = 0;
            SetEditMode();
            ctlErfassungMutation.ShowInfo();

            if (Convert.ToInt32(qryBgPosition["BgKategorieCode"]) == Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen))
            {
                edtKostenart.Focus();
            }
            else
            {
                LoadSpezialkonto(null, qryBgPosition["BaPersonID"]);
                edtBetrag.Focus();
            }

            // update enabled states of controls
            UpdateControlsAndStates();
        }

        private void qryBgPosition_BeforeDeleteQuestion(object sender, System.EventArgs e)
        {
            // check if main position
            if (IsMainPosition())
            {
                throw new KissInfoException(KissMsg.GetMLMessage(this.Name,
                                                                 "CannotDeleteMainPosition",
                                                                 "Die Hauptposition kann nicht gelöscht werden!"));
            }

            // check if deleting is possible
            CtlWhAuszahlungen.CheckCanDeletePosition(ref qryBgPosition);

            // confirm
            if (KissMsg.ShowQuestion(this.Name, "ConfirmDeletePosition", "Soll die aktuelle Position gelöscht werden?"))
            {
                // delete entry
                qryBgPosition.Row.Delete();
                qryBgPosition.RowModified = false;

                // set flag
                _dataModified = true;

                // recalculate sum
                UpdateSum();
            }

            // cancel any further processing
            throw new KissCancelException();
        }

        private void qryBgPosition_BeforeInsert(object sender, System.EventArgs e)
        {
            if (_newBgKategorieCode != 0)
            {
                return;
            }

            _newBgKategorieCode = CtlWhAuszahlungen.DlgInsertNewKoA();
        }

        private void qryBgPosition_BeforePost(object sender, System.EventArgs e)
        {
            // Mantis 2838 DBUtil.CheckNotNullField(qryBgPosition, "BgPositionsartID", lblKostenart.Text, edtKostenart);
            DBUtil.CheckNotNullField(edtKostenart, lblKostenart.Text);  //Mantis 2838
            DBUtil.CheckNotNullField(edtBuchungstext, lblBuchungstext.Text);
            DBUtil.CheckNotNullField(edtBetrag, lblBetrag.Text);

            // validate amount
            CtlWhAuszahlungen.ValidateBetrag(ref qryBgPosition, ref edtBetrag, "Betrag");

            // validate Betrifft Person
            CtlWhAuszahlungen.ValidateBetrifftPerson(ref qryBgPosition, ref edtBaPersonID);

            // validate budget
            CtlWhAuszahlungen.ValidateBudget(ref qryBgBudget);

            // validate and handle VerwPeriode
            CtlWhAuszahlungen.ValidateAndHandleVerwPeriode(ref qryBgPosition, ref edtVerwPeriodeVon, ref edtVerwPeriodeBis);

            // validate and handle EZ
            CtlWhAuszahlungen.ValidateAndHandleEinzelzahlung(ref qryBgPosition,
                                                             ref edtBgSpezkontoID,
                                                             ref lblBgSpezkontoID,
                                                             ref edtBetrag,
                                                             ShUtil.GetCode(qryBgBudget["FaLeistungID"]));

            // permission handling ZL >> will possibly create entries in BgBewilligung table (only modify status, do not log entries)
            CtlWhAuszahlungen.ValidateAndHandleZLPermission(ref qryBgPosition, ref qryBgBudget, false, false, false);

            // set freigegeben if all others are freigegeben
            // TODO: cannot be handled with current mode, what to do?
            /*
            bool setFreigegeben = true;

            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                // TODO: only if freigegeben??
                // check if not added row and having state different than freigegeben
                if (row.RowState != DataRowState.Added && Convert.ToInt32(row["Status"]) != 2)
                {
                    // set flag and stop
                    setFreigegeben = false;
                    break;
                }
            }

            if (setFreigegeben)
            {
                // set status on position to freigegeben
                qryBgPosition["Status"] = 2; // freigegeben
            }
            */

            // set further fields and flags
            ctlErfassungMutation.SetFields();
            UpdateSum();

            try
            {
                // modified
                _dataModified = true;
                qryBgPosition["RowModified"] = true;    // store flag because of status handling when clicking btnOk

                // do "Post" (only in memory)
                qryBgPosition.RowModified = false;
                qryBgPosition.Row.AcceptChanges();
            }
            finally
            {
                // update enabled states of controls
                UpdateControlsAndStates();
            }
        }

        private void qryBgPosition_ColumnChanged(object sender, System.Data.DataColumnChangeEventArgs e)
        {
            if (qryBgPosition.IsFilling)
            {
                return;
            }

            if (e.Column.ColumnName == "Betrag")
            {
                UpdateSum();
            }
        }

        private void qryBgPosition_PositionChanged(object sender, System.EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(qryBgPosition["BgKategorieCode"]) == Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen))
                {
                    LoadSpezialkonto(null, qryBgPosition["BaPersonID"]);
                }

                ctlErfassungMutation.ShowInfo();
            }
            finally
            {
                // update enabled states of controls
                UpdateControlsAndStates();
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Refresh data
        /// </summary>
        public override void OnRefreshData()
        {
            // try saving first
            if (!qryBgPosition.Post())
            {
                return;
            }

            // confirm if modified changes
            if (_dataModified)
            {
                // confirm refresh >> loosing data
                if (!KissMsg.ShowQuestion(this.Name,
                                          "ConfirmRefreshLoosingChanges",
                                          "Wenn die Daten jetzt aktualisiert werden, gehen die laufenden Veränderungen verloren.\r\nWollen Sie die Daten wirklich aktualisieren?", false))
                {
                    // cancel refresh
                    return;
                }
            }

            // refresh both queries
            qryBgPosition.Refresh();
            qryBgBudget.Refresh();

            // reset flag
            _dataModified = false;
        }

        /// <summary>
        /// Translates the components of the instance
        /// </summary>
        public override void Translate()
        {
            // first, let base do stuff
            base.Translate();

            // setup controls for multilanguage handling
            SetupControlsML();
        }

        #endregion

        #region Private Methods

        private void ApplyAction(BewilligungAktion aktion, bool withTransaction)
        {
            ApplyAction(null, aktion, withTransaction);
        }

        private void ApplyAction(DlgBewilligung dlg, bool withTransaction)
        {
            ApplyAction(dlg, dlg.Aktion, withTransaction);
        }

        private void ApplyAction(DlgBewilligung dlg, BewilligungAktion aktion, bool withTransaction)
        {
            if(withTransaction)
                Session.BeginTransaction();

            try
            {
                if (dlg != null && !dlg.ActiveSQLQuery.Post())
                {
                    throw new KissCancelException();
                }

                // Statusupdate auf BgPosition inkl Detailpositionen
                ShUtil.SetBewilligungStatusFromPosition(_bgPositionIDBewilligen,
                                                        DlgBewilligung.GetNextBewilligungStatus(aktion) as BgBewilligungStatus?,
                                                        false);

                this.qryBgPosition.Refresh();

                if(withTransaction)
                    Session.Commit();
            }
            catch (Exception ex)
            {
                // rollback changes
                if(withTransaction)
                    Session.Rollback();

                // show error message
                KissMsg.ShowError(this.Name, "ErrorPositionBewilligen", "Es ist ein Fehler beim Bewilligen der Position(en) aufgetreten.", ex);

                // refresh
                qryBgPosition_PositionChanged(null, null);
                qryBgPosition.RefreshDisplay();
            }
        }

        /// <summary>
        /// Check if position can be granted by button "Bewilligen"
        /// </summary>
        /// <returns><c>True</c> if position can be granted, otherwise <c>False</c></returns>
        private bool CanGrantPosition()
        {
            // validate count and query state
            if (/*_dataModified ||                                                        // can not grant modified unsafed data > save by btnOk_Click*/
                qryBgPosition.IsEmpty ||
                qryBgPosition.Row.RowState == DataRowState.Added ||
                DBUtil.IsEmpty(qryBgPosition[colPositionID.FieldName]))
            {
                // no data
                return false;
            }

            // get some values
            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            int status = ShUtil.GetCode(qryBgPosition["Status"]);

            // check if grant is possible
            if (kategorie != Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen) ||     // only ZL can be granted
                (status != 1 && status != 12 && status != 14 && status != 15))        // only some positions can be granted (vorbereitet, angefragt, bewilligt, zurueckgewiesen)
            {
                return false;
            }

            // if we are here, the position can be granted
            return true;
        }

        /// <summary>
        /// Enable or disable button bewilligen depending on current states
        /// </summary>
        private void EnableBtnBewilligen()
        {
            btnPositionBewilligung.Enabled = CanGrantPosition();
        }

        private object GetFieldFromSpezkonto(object bgSpezkontoID, string fieldName)
        {
            return CtlWhAuszahlungen.GetFieldFromSpezkonto(ref edtBgSpezkontoID, bgSpezkontoID, fieldName);
        }

        private bool GetUserPermissionZL()
        {
            return CtlWhAuszahlungen.ValidateAndHandleZLPermission(ref qryBgPosition, ref qryBgBudget, true, false, false);
        }

        /// <summary>
        /// Check if current position is the main position
        /// </summary>
        /// <returns><c>True</c> if current selected position is the main position, otherwise <c>False</c></returns>
        private bool IsMainPosition()
        {
            // if parent-positionid is empty, this entry is the main position
            return DBUtil.IsEmpty(qryBgPosition[DBO.BgPosition.BgPositionID_Parent]);
        }

        private void LoadSpezialkonto(object bgKostenartID, object baPersonID)
        {
            CtlWhAuszahlungen.LoadSpezialkonto(ref edtBgSpezkontoID, ref qryBgPosition, ref qryBgBudget, bgKostenartID, baPersonID);
        }

        private void NeuePosition(int BgKategorieCode)
        {
            if (!qryBgPosition.Post() || !qryBgPosition.CanInsert)
            {
                return;
            }

            _newBgKategorieCode = BgKategorieCode;
            qryBgPosition.Insert();
        }

        private void SetEditMode()
        {
            if (_readOnly)
            {
                return;
            }

            int kategorie = ShUtil.GetCode(qryBgPosition["BgKategorieCode"]);
            int bgSplittingArtCode = ShUtil.GetCode(qryBgPosition["BgSplittingArtCode"]);

            //Verwendungsperiode + Splitting
            switch (bgSplittingArtCode)
            {
                case 1: //Taggenau
                case 2: //monat
                    edtVerwPeriodeVon.EditMode = EditModeType.Normal;
                    edtVerwPeriodeBis.EditMode = EditModeType.Normal;
                    break;

                case 4: //Entscheid
                    edtVerwPeriodeVon.EditMode = EditModeType.Normal;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;

                default:
                    edtVerwPeriodeVon.EditMode = EditModeType.ReadOnly;
                    edtVerwPeriodeBis.EditMode = EditModeType.ReadOnly;
                    break;
            }

            edtBgSpezkontoID.EditMode = (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen)) ? EditModeType.Required : EditModeType.ReadOnly;
            edtKostenart.EditMode = (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Zusaetzliche_Leistungen)) ? EditModeType.Required : EditModeType.ReadOnly;

            if (!DBUtil.IsEmpty(qryBgPosition["ProPerson"]) && !DBUtil.IsEmpty(qryBgPosition["ProUE"]))
            {
                bool proPerson = Convert.ToBoolean(qryBgPosition["ProPerson"]);
                bool proUE = Convert.ToBoolean(qryBgPosition["ProUE"]);

                edtBaPersonID.EditMode = (proPerson || !proUE) ? EditModeType.Normal : EditModeType.ReadOnly;
            }
            else
            {
                edtBaPersonID.EditMode = EditModeType.ReadOnly;
            }
        }

        private void SetSpezialkonto()
        {
            object bgSpezKontoID = qryBgPosition["BgSpezKontoID"];
            object baPersonID;
            int kategorie = Convert.ToInt32(qryBgPosition["BgKategorieCode"]);

            if (kategorie == Convert.ToInt32(LOV.BgKategorieCode.Einzelzahlungen))
            {
                baPersonID = GetFieldFromSpezkonto(bgSpezKontoID, "BaPersonID");

                qryBgPosition["BgPositionsartID"] = GetFieldFromSpezkonto(bgSpezKontoID, "BgPositionsartID");
                qryBgPosition["Kostenart"] = GetFieldFromSpezkonto(bgSpezKontoID, "KOAPositionsart");
                qryBgPosition["BgSplittingArtCode"] = GetFieldFromSpezkonto(bgSpezKontoID, "BgSplittingArtCode");
                qryBgPosition["ProPerson"] = GetFieldFromSpezkonto(bgSpezKontoID, "ProPerson");
                qryBgPosition["ProUE"] = GetFieldFromSpezkonto(bgSpezKontoID, "ProUE");

                // set Buchungstext
                qryBgPosition["Buchungstext"] = CtlWhAuszahlungen.GetSpezKontoBuchungstext(Convert.ToString(qryBgPosition["Buchungstext"]),
                                                                                           Convert.ToString(GetFieldFromSpezkonto(_oldBgSpezkontoID, "Text")),
                                                                                           Convert.ToString(GetFieldFromSpezkonto(bgSpezKontoID, "Text")));

                // go on...
                SetVerwendungsPeriode();

                if (!DBUtil.IsEmpty(baPersonID))
                {
                    qryBgPosition["BaPersonID"] = baPersonID;
                }
            }

            qryBgPosition.RefreshDisplay();
        }

        private void SetVerwendungsPeriode()
        {
            CtlWhAuszahlungen.SetVerwendungsPeriode(ref qryBgPosition, ref qryBgBudget);
        }

        /// <summary>
        /// Setup controls for multilanguage handling
        /// </summary>
        private void SetupControlsML()
        {
            // setup buttons texts (no text allowed)
            btnEinzelzahlung.Text = "";
            btnZusatzleistung.Text = "";
            btnPositionBewilligung.Text = "";

            // Tooltips setzen
            ttpControls = new System.Windows.Forms.ToolTip();
            ttpControls.SetToolTip(btnEinzelzahlung, KissMsg.GetMLMessage(this.Name, "TtpNeueEZ", "Neue Einzelzahlung"));
            ttpControls.SetToolTip(btnZusatzleistung, KissMsg.GetMLMessage(this.Name, "TtpNeueZL", "Neue zusätzliche Leistung"));
            ttpControls.SetToolTip(btnPositionBewilligung, KissMsg.GetMLMessage(this.Name, "TtpBewilligungBgPos", "Bewilligung der Budgetposition"));
        }

        private void UpdateControlsAndStates()
        {
            // setup edit mode
            SetEditMode();

            // handle button Bewilligen
            EnableBtnBewilligen();
        }

        private void UpdateSum()
        {
            decimal summe = decimal.Zero;

            foreach (DataRow row in qryBgPosition.DataTable.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    decimal? einzelBetrag = row["Betrag"] as decimal?;

                    if (einzelBetrag.HasValue)
                    {
                        if (einzelBetrag.Value < 0m)
                        {
                            row["Betrag"] = 0m;
                            einzelBetrag = 0m;
                        }

                        summe += einzelBetrag.Value;
                    }
                }
            }

            edtTotalbetragNeu.EditValue = summe;
            edtDifferenz.EditValue = _totalbetrag - summe;

            if (_totalbetrag == summe)
            {
                // correct = green
                edtDifferenz.BackColor = GuiConfig.AmountDifferenceCorrect;
            }
            else
            {
                // incorrect = red
                edtDifferenz.BackColor = GuiConfig.AmountDifferenceIncorrect;
            }
        }

        #endregion

        #endregion
    }
}