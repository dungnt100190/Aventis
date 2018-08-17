using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Kiss.Infrastructure;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Administration
{
    /// <summary>
    /// Summary description for CtlMessage.
    /// </summary>
    public class CtlMessage : KiSS4.Common.KissSearchUserControl
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private string _germanColumnName = "Deutsch"; // store column name for translated "Deutsch"-column. Used for auto-translation.
        private KissButton btnAutoTranslate;
        private DevExpress.XtraGrid.Columns.GridColumn colMaskName;
        private DevExpress.XtraGrid.Columns.GridColumn colMessageName;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissTextEdit edtMaskName;
        private KiSS4.Gui.KissMemoEditML edtMemoML;
        private KiSS4.Gui.KissTextEdit edtMessageName;
        private KissTextEdit edtSucheMaskName;
        private KissTextEdit edtSucheMessageName;
        private KissTextEdit edtSucheText;
        private KiSS4.Gui.KissGrid grdMessage;
        private DevExpress.XtraGrid.Views.Grid.GridView grvMessage;
        private KiSS4.Gui.KissLabel lblMaskName;
        private KiSS4.Gui.KissLabel lblMessageName;
        private KissLabel lblRowCount;
        private KissLabel lblSucheMaskName;
        private KissLabel lblSucheMessageName;
        private KissLabel lblSucheText;
        private KiSS4.Gui.KissLabel lblText;
        private Panel panDetails;
        private KiSS4.DB.SqlQuery qryMessage;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlMessage"/> class.
        /// </summary>
        public CtlMessage()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            // setup rights
            SetupRights();

            // init kissSearch without msgCode
            kissSearch.SelectParameters = new object[] { null };

            // init gui
            ResetCounterLabel();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CtlMessage"/> class, with given message code
        /// </summary>
        /// <param name="msgCode">The message code to show values from</param>
        public CtlMessage(KissMsgCode msgCode)
            : this()
        {
            // init kissSearch with given msgCode
            kissSearch.SelectParameters = new object[] { Convert.ToInt32(msgCode) };
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
            this.grdMessage = new KiSS4.Gui.KissGrid();
            this.qryMessage = new KiSS4.DB.SqlQuery(this.components);
            this.grvMessage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMaskName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMessageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.lblMaskName = new KiSS4.Gui.KissLabel();
            this.lblMessageName = new KiSS4.Gui.KissLabel();
            this.edtMessageName = new KiSS4.Gui.KissTextEdit();
            this.edtMaskName = new KiSS4.Gui.KissTextEdit();
            this.lblText = new KiSS4.Gui.KissLabel();
            this.edtMemoML = new KiSS4.Gui.KissMemoEditML();
            this.btnAutoTranslate = new KiSS4.Gui.KissButton();
            this.lblSucheMaskName = new KiSS4.Gui.KissLabel();
            this.lblSucheMessageName = new KiSS4.Gui.KissLabel();
            this.edtSucheMessageName = new KiSS4.Gui.KissTextEdit();
            this.edtSucheMaskName = new KiSS4.Gui.KissTextEdit();
            this.lblSucheText = new KiSS4.Gui.KissLabel();
            this.edtSucheText = new KiSS4.Gui.KissTextEdit();
            this.panDetails = new System.Windows.Forms.Panel();
            this.lblRowCount = new KiSS4.Gui.KissLabel();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaskName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessageName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMessageName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMaskName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMessageName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMessageName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMaskName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheText.Properties)).BeginInit();
            this.panDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).BeginInit();
            this.SuspendLayout();
            //
            // searchTitle
            //
            this.searchTitle.Size = new System.Drawing.Size(776, 24);
            //
            // tabControlSearch
            //
            this.tabControlSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControlSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSearch.Location = new System.Drawing.Point(0, 0);
            this.tabControlSearch.Size = new System.Drawing.Size(800, 294);
            //
            // tpgListe
            //
            this.tpgListe.Controls.Add(this.grdMessage);
            this.tpgListe.Size = new System.Drawing.Size(788, 256);
            this.tpgListe.Title = "Liste";
            //
            // tpgSuchen
            //
            this.tpgSuchen.Controls.Add(this.lblSucheText);
            this.tpgSuchen.Controls.Add(this.edtSucheText);
            this.tpgSuchen.Controls.Add(this.lblSucheMaskName);
            this.tpgSuchen.Controls.Add(this.lblSucheMessageName);
            this.tpgSuchen.Controls.Add(this.edtSucheMessageName);
            this.tpgSuchen.Controls.Add(this.edtSucheMaskName);
            this.tpgSuchen.Size = new System.Drawing.Size(788, 256);
            this.tpgSuchen.Title = "Suche";
            this.tpgSuchen.Controls.SetChildIndex(this.searchTitle, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMaskName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheMessageName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMessageName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheMaskName, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.edtSucheText, 0);
            this.tpgSuchen.Controls.SetChildIndex(this.lblSucheText, 0);
            //
            // grdMessage
            //
            this.grdMessage.DataSource = this.qryMessage;
            this.grdMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMessage.EmbeddedNavigator.Name = "";
            this.grdMessage.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdMessage.Location = new System.Drawing.Point(0, 0);
            this.grdMessage.MainView = this.grvMessage;
            this.grdMessage.Name = "grdMessage";
            this.grdMessage.Size = new System.Drawing.Size(788, 256);
            this.grdMessage.TabIndex = 0;
            this.grdMessage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvMessage});
            //
            // qryMessage
            //
            this.qryMessage.CanDelete = true;
            this.qryMessage.CanUpdate = true;
            this.qryMessage.HostControl = this;
            this.qryMessage.TableName = "XMessage";
            this.qryMessage.AfterFill += new System.EventHandler(this.qryMessage_AfterFill);
            //
            // grvMessage
            //
            this.grvMessage.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvMessage.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.Empty.Options.UseBackColor = true;
            this.grvMessage.Appearance.Empty.Options.UseFont = true;
            this.grvMessage.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvMessage.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.EvenRow.Options.UseFont = true;
            this.grvMessage.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMessage.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvMessage.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvMessage.Appearance.FocusedCell.Options.UseFont = true;
            this.grvMessage.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvMessage.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvMessage.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvMessage.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.FocusedRow.Options.UseFont = true;
            this.grvMessage.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMessage.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvMessage.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvMessage.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMessage.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMessage.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.GroupRow.Options.UseFont = true;
            this.grvMessage.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvMessage.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvMessage.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvMessage.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvMessage.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvMessage.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvMessage.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvMessage.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvMessage.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvMessage.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvMessage.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvMessage.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.OddRow.Options.UseFont = true;
            this.grvMessage.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvMessage.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.Row.Options.UseBackColor = true;
            this.grvMessage.Appearance.Row.Options.UseFont = true;
            this.grvMessage.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvMessage.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvMessage.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvMessage.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvMessage.Appearance.SelectedRow.Options.UseFont = true;
            this.grvMessage.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvMessage.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvMessage.Appearance.VertLine.Options.UseBackColor = true;
            this.grvMessage.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvMessage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMaskName,
            this.colMessageName});
            this.grvMessage.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvMessage.GridControl = this.grdMessage;
            this.grvMessage.Name = "grvMessage";
            this.grvMessage.OptionsBehavior.Editable = false;
            this.grvMessage.OptionsCustomization.AllowFilter = false;
            this.grvMessage.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvMessage.OptionsNavigation.AutoFocusNewRow = true;
            this.grvMessage.OptionsNavigation.UseTabKey = false;
            this.grvMessage.OptionsView.ColumnAutoWidth = false;
            this.grvMessage.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvMessage.OptionsView.ShowGroupPanel = false;
            this.grvMessage.OptionsView.ShowIndicator = false;
            this.grvMessage.BeforeLeaveRow += new DevExpress.XtraGrid.Views.Base.RowAllowEventHandler(this.grvMessage_BeforeLeaveRow);
            //
            // colMaskName
            //
            this.colMaskName.Caption = "Masken Name";
            this.colMaskName.FieldName = "MaskName";
            this.colMaskName.Name = "colMaskName";
            this.colMaskName.Visible = true;
            this.colMaskName.VisibleIndex = 0;
            this.colMaskName.Width = 160;
            //
            // colMessageName
            //
            this.colMessageName.Caption = "Meldungs Name";
            this.colMessageName.FieldName = "MessageName";
            this.colMessageName.Name = "colMessageName";
            this.colMessageName.Visible = true;
            this.colMessageName.VisibleIndex = 1;
            this.colMessageName.Width = 160;
            //
            // lblMaskName
            //
            this.lblMaskName.Location = new System.Drawing.Point(9, 9);
            this.lblMaskName.Name = "lblMaskName";
            this.lblMaskName.Size = new System.Drawing.Size(106, 24);
            this.lblMaskName.TabIndex = 0;
            this.lblMaskName.Text = "Masken Name";
            //
            // lblMessageName
            //
            this.lblMessageName.Location = new System.Drawing.Point(9, 39);
            this.lblMessageName.Name = "lblMessageName";
            this.lblMessageName.Size = new System.Drawing.Size(106, 24);
            this.lblMessageName.TabIndex = 2;
            this.lblMessageName.Text = "Meldungs Name";
            //
            // edtMessageName
            //
            this.edtMessageName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMessageName.DataMember = "MessageName";
            this.edtMessageName.DataSource = this.qryMessage;
            this.edtMessageName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMessageName.Location = new System.Drawing.Point(121, 39);
            this.edtMessageName.Name = "edtMessageName";
            this.edtMessageName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMessageName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMessageName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMessageName.Properties.Appearance.Options.UseBackColor = true;
            this.edtMessageName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMessageName.Properties.Appearance.Options.UseFont = true;
            this.edtMessageName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMessageName.Properties.ReadOnly = true;
            this.edtMessageName.Size = new System.Drawing.Size(670, 24);
            this.edtMessageName.TabIndex = 3;
            //
            // edtMaskName
            //
            this.edtMaskName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMaskName.DataMember = "MaskName";
            this.edtMaskName.DataSource = this.qryMessage;
            this.edtMaskName.EditMode = Kiss.Interfaces.UI.EditModeType.ReadOnly;
            this.edtMaskName.Location = new System.Drawing.Point(121, 9);
            this.edtMaskName.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.edtMaskName.Name = "edtMaskName";
            this.edtMaskName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMaskName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtMaskName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtMaskName.Properties.Appearance.Options.UseBackColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtMaskName.Properties.Appearance.Options.UseFont = true;
            this.edtMaskName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtMaskName.Properties.ReadOnly = true;
            this.edtMaskName.Size = new System.Drawing.Size(670, 24);
            this.edtMaskName.TabIndex = 1;
            //
            // lblText
            //
            this.lblText.Location = new System.Drawing.Point(9, 69);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(106, 24);
            this.lblText.TabIndex = 4;
            this.lblText.Text = "Deutscher Text";
            //
            // edtMemoML
            //
            this.edtMemoML.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtMemoML.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.edtMemoML.DataMemberDefaultText = "Deutsch";
            this.edtMemoML.DataMemberTID = "MessageTID";
            this.edtMemoML.DataSource = this.qryMessage;
            this.edtMemoML.Location = new System.Drawing.Point(121, 69);
            this.edtMemoML.Name = "edtMemoML";
            this.edtMemoML.ShowOnlyDefaultLanguage = true;
            this.edtMemoML.Size = new System.Drawing.Size(670, 99);
            this.edtMemoML.TabIndex = 5;
            this.edtMemoML.WriteLocked = false;
            this.edtMemoML.DataHasChanged += new System.EventHandler(this.edtMemoML_DataHasChanged);
            //
            // btnAutoTranslate
            //
            this.btnAutoTranslate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutoTranslate.Location = new System.Drawing.Point(121, 174);
            this.btnAutoTranslate.Name = "btnAutoTranslate";
            this.btnAutoTranslate.Size = new System.Drawing.Size(112, 24);
            this.btnAutoTranslate.TabIndex = 6;
            this.btnAutoTranslate.Text = "Autoübersetzung";
            this.btnAutoTranslate.UseVisualStyleBackColor = false;
            this.btnAutoTranslate.Click += new System.EventHandler(this.btnAutoTranslate_Click);
            //
            // lblSucheMaskName
            //
            this.lblSucheMaskName.Location = new System.Drawing.Point(30, 40);
            this.lblSucheMaskName.Name = "lblSucheMaskName";
            this.lblSucheMaskName.Size = new System.Drawing.Size(106, 24);
            this.lblSucheMaskName.TabIndex = 1;
            this.lblSucheMaskName.Text = "Masken Name";
            //
            // lblSucheMessageName
            //
            this.lblSucheMessageName.Location = new System.Drawing.Point(30, 70);
            this.lblSucheMessageName.Name = "lblSucheMessageName";
            this.lblSucheMessageName.Size = new System.Drawing.Size(106, 24);
            this.lblSucheMessageName.TabIndex = 3;
            this.lblSucheMessageName.Text = "Meldungs Name";
            //
            // edtSucheMessageName
            //
            this.edtSucheMessageName.Location = new System.Drawing.Point(142, 70);
            this.edtSucheMessageName.Name = "edtSucheMessageName";
            this.edtSucheMessageName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMessageName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMessageName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMessageName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMessageName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMessageName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMessageName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheMessageName.Size = new System.Drawing.Size(463, 24);
            this.edtSucheMessageName.TabIndex = 4;
            //
            // edtSucheMaskName
            //
            this.edtSucheMaskName.Location = new System.Drawing.Point(142, 40);
            this.edtSucheMaskName.Name = "edtSucheMaskName";
            this.edtSucheMaskName.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheMaskName.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheMaskName.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheMaskName.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheMaskName.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheMaskName.Properties.Appearance.Options.UseFont = true;
            this.edtSucheMaskName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheMaskName.Size = new System.Drawing.Size(463, 24);
            this.edtSucheMaskName.TabIndex = 2;
            //
            // lblSucheText
            //
            this.lblSucheText.Location = new System.Drawing.Point(30, 100);
            this.lblSucheText.Name = "lblSucheText";
            this.lblSucheText.Size = new System.Drawing.Size(106, 24);
            this.lblSucheText.TabIndex = 5;
            this.lblSucheText.Text = "Text";
            //
            // edtSucheText
            //
            this.edtSucheText.Location = new System.Drawing.Point(142, 100);
            this.edtSucheText.Name = "edtSucheText";
            this.edtSucheText.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtSucheText.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtSucheText.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtSucheText.Properties.Appearance.Options.UseBackColor = true;
            this.edtSucheText.Properties.Appearance.Options.UseBorderColor = true;
            this.edtSucheText.Properties.Appearance.Options.UseFont = true;
            this.edtSucheText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtSucheText.Size = new System.Drawing.Size(463, 24);
            this.edtSucheText.TabIndex = 6;
            //
            // panDetails
            //
            this.panDetails.Controls.Add(this.edtMemoML);
            this.panDetails.Controls.Add(this.lblMaskName);
            this.panDetails.Controls.Add(this.btnAutoTranslate);
            this.panDetails.Controls.Add(this.lblMessageName);
            this.panDetails.Controls.Add(this.lblText);
            this.panDetails.Controls.Add(this.edtMessageName);
            this.panDetails.Controls.Add(this.edtMaskName);
            this.panDetails.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panDetails.Location = new System.Drawing.Point(0, 294);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(800, 206);
            this.panDetails.TabIndex = 2;
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
            this.lblRowCount.Location = new System.Drawing.Point(623, 270);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(168, 20);
            this.lblRowCount.TabIndex = 1;
            this.lblRowCount.Text = "Anzahl Datensäzte: <count>";
            this.lblRowCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            //
            // CtlMessage
            //
            this.ActiveSQLQuery = this.qryMessage;
            this.Controls.Add(this.lblRowCount);
            this.Controls.Add(this.panDetails);
            this.Name = "CtlMessage";
            this.Load += new System.EventHandler(this.CtlMessage_Load);
            this.Controls.SetChildIndex(this.panDetails, 0);
            this.Controls.SetChildIndex(this.tabControlSearch, 0);
            this.Controls.SetChildIndex(this.lblRowCount, 0);
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaskName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMessageName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMessageName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtMaskName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMaskName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheMessageName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMessageName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheMaskName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSucheText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtSucheText.Properties)).EndInit();
            this.panDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblRowCount)).EndInit();
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

        private void CtlMessage_Load(object sender, System.EventArgs e)
        {
            try
            {
                // set waiting cursor
                Cursor.Current = Cursors.WaitCursor;

                // init language query
                SqlQuery qryLanguages = DBUtil.GetLOVQuery("Sprache", false);

                // init vars
                StringBuilder sbColumns = new StringBuilder();
                StringBuilder sbJoins = new StringBuilder();

                // loop all languages and create columns
                foreach (DataRow row in qryLanguages.DataTable.Rows)
                {
                    // create dynamic sql code
                    sbColumns.AppendFormat(",\r\n\t\t\t\t  [{1}] = L{0}.Text", row["Code"], row["Text"]);
                    sbJoins.AppendFormat("\r\n\t\t\t\t  LEFT JOIN dbo.XLangText  L{0} WITH (READUNCOMMITTED) ON L{0}.TID = MSG.MessageTID AND L{0}.LanguageCode = {0}", row["Code"]);

                    // column found in messages, create new column
                    DevExpress.XtraGrid.Columns.GridColumn newCol = new DevExpress.XtraGrid.Columns.GridColumn();
                    newCol.FieldName = Convert.ToString(row["Text"]);
                    newCol.Caption = Convert.ToString(row["Text"]);
                    newCol.Width = 300;
                    newCol.VisibleIndex = grvMessage.Columns.Count;

                    // add column to view
                    grvMessage.Columns.Add(newCol);

                    // check if need to apply translated column-name ("Deutsch"-column)
                    if (!DBUtil.IsEmpty(row["Code"]) && Convert.ToInt32(row["Code"]) == 1)
                    {
                        // current column is "Deutsch"-column, apply name of column for auto-translation
                        if (!DBUtil.IsEmpty(row["Text"]))
                        {
                            // apply value
                            _germanColumnName = Convert.ToString(row["Text"]);
                            edtMemoML.DataMemberDefaultText = _germanColumnName;
                        }
                    }
                }

                // create select statement with dynamic rows depending on languages
                kissSearch.SelectStatement = @"
                    --SQLCHECK_IGNORE--
                    SELECT MSG.*" + sbColumns.ToString() + @"
                    FROM dbo.XMessage MSG WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.XLangText  TXT WITH (READUNCOMMITTED) ON TXT.TID = MSG.MessageTID AND
                                                                             TXT.LanguageCode = 1" + sbJoins.ToString() + @"
                    WHERE MSG.MessageCode = {0}
                    ---  AND MSG.MaskName    LIKE {edtSucheMaskName} + '%'
                    ---  AND MSG.MessageName LIKE '%' + {edtSucheMessageName} + '%'
                    ---  AND TXT.Text        LIKE '%' + {edtSucheText} + '%'
                    ORDER BY MSG.MaskName, MSG.MessageName";

                // load data
                qryMessage.Fill(kissSearch.SelectStatement, kissSearch.SelectParameters);
            }
            catch (Exception ex)
            {
                // show message
                KissMsg.ShowError("CtlMessage", "ErrorOnLoadOccured", "Es ist ein Fehler beim Laden der Daten aufgetreten.", ex);
            }
            finally
            {
                // reset cursor
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnAutoTranslate_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataRow row in qryMessage.DataTable.Rows)
                {
                    if (row[this._germanColumnName] is string)
                    {
                        string translation = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                            --SQLCHECK_IGNORE--
                            --exact matches only
                            SET IDENTITY_INSERT XLangText ON

                            INSERT INTO dbo.XLangText (TID, LanguageCode, Text)
                                SELECT {0},
                                       TXT2.LanguageCode,
                                       MIN(TXT2.Text)
                                FROM dbo.XLangText TXT1
                                  LEFT JOIN dbo.XLangText TXT2 ON TXT2.TID = TXT1.TID
                                WHERE TXT1.Text LIKE {1} AND
                                      TXT1.LanguageCode = 1 AND
                                      NOT EXISTS(SELECT TOP 1 1
                                                 FROM dbo.XLangText
                                                 WHERE TID = {0} AND
                                                       LanguageCode = TXT2.LanguageCode)
                                GROUP BY TXT2.LanguageCode
                                ORDER BY DIFFERENCE(MAX(TXT1.Text), {1}) DESC

                            SET IDENTITY_INSERT XLangText OFF", row["MessageTID"], row[this._germanColumnName]));
                    }
                }
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("CtlMessage", "ErrorAutoTranslate", "Es ist ein Fehler beim Übersetzten aufgetreten.", ex);
            }

            // post data and refresh content
            if (qryMessage.Post())
            {
                this.RefreshQuery();
            }
        }

        /// <summary>
        /// Event: DataHasChanged on edtMemoML, occures when any data in memofield or dialog has been changed
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void edtMemoML_DataHasChanged(object sender, EventArgs e)
        {
            // refresh data
            this.RefreshQuery();
        }

        private void grvMessage_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
        {
            // save pending changes
            this.OnSaveData();
        }

        private void qryMessage_AfterFill(object sender, EventArgs e)
        {
            // set amount of entries found
            lblRowCount.Text = KissMsg.GetMLMessage("CtlMessage", "LabelRowCount", "Anzahl Datensätze: {0}", qryMessage.Count);
        }

        #endregion

        #region Methods

        #region Protected Methods

        protected override void NewSearch()
        {
            // let base do stuff
            base.NewSearch();

            // set focus
            edtSucheMaskName.Focus();

            // reset row-count label
            ResetCounterLabel();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Refresh the data in query and try to reposition
        /// </summary>
        private void RefreshQuery()
        {
            // refresh data
            qryMessage.Refresh();
        }

        private void ResetCounterLabel()
        {
            // remove current text
            lblRowCount.Text = "";

            // do it
            ApplicationFacade.DoEvents();
        }

        private void SetupRights()
        {
            // logging
            LOG.Debug("enter");

            // init vars
            bool isAdmin = Session.User.IsUserAdmin;

            bool canReadData = false;
            bool canUserInsert = false;
            bool canUserUpdate = false;
            bool canUserDelete = false;

            // set values
            Session.GetUserRight(this.Name, out canReadData, out canUserInsert, out canUserUpdate, out canUserDelete);

            if (!canReadData)
            {
                // no rights to view this control
                throw new Exception("No rights to view details of this control.");
            }

            // logging
            LOG.DebugFormat("isAdmin='{0}', canReadData='{1}', canUserInsert='{2}', canUserUpdate='{3}', canUserDelete='{4}'", isAdmin, canReadData, canUserInsert, canUserUpdate, canUserDelete);

            // init query
            qryMessage.CanInsert = false;   // insert is not allowed
            qryMessage.CanUpdate = isAdmin || canUserUpdate;
            qryMessage.CanDelete = isAdmin || canUserDelete;

            // enable bound fields
            qryMessage.EnableBoundFields();

            // logging
            LOG.DebugFormat("qryMessage.CanInsert='{0}', qryMessage.CanUpdate='{1}', qryMessage.CanDelete='{2}'", qryMessage.CanInsert, qryMessage.CanUpdate, qryMessage.CanDelete);
            LOG.Debug("done");
        }

        #endregion

        #endregion
    }
}