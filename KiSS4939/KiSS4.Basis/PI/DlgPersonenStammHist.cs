using System;
using System.Drawing;
using KiSS4.DB;

namespace KiSS4.Basis.PI
{
    public class DlgPersonenStammHist : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Fields

        private int _baPersonID = -1;
        private string _caption = "";
        private Image _icon = null;
        private bool _isLoading = true;
        private KiSS4.Gui.KissButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUser;
        private System.ComponentModel.IContainer components;
        private CtlBaStammdaten ctlBaStammdaten = null;
        private KiSS4.Gui.KissGrid grdHistory;
        private DevExpress.XtraGrid.Views.Grid.GridView grvHistory;
        private System.Windows.Forms.Panel panBottom;
        private System.Windows.Forms.Panel panDetailControl;
        private System.Windows.Forms.Panel panGrid;
        private KiSS4.DB.SqlQuery qryHistBaPerson;
        private KiSS4.Gui.KissSplitterCollapsible splitter;

        #endregion

        #endregion

        #region Constructors

        public DlgPersonenStammHist(Image icon, string caption, int baPersonID)
        {
            // validate
            if (baPersonID < 1)
            {
                throw new Exception("Invalid parameter received, cannot proceed.");
            }

            // apply fields
            this._icon = icon;
            this._caption = caption;
            this._baPersonID = baPersonID;

            // init
            this.InitializeComponent();
        }

        public DlgPersonenStammHist()
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
            this.panBottom = new System.Windows.Forms.Panel();
            this.btnClose = new KiSS4.Gui.KissButton();
            this.panGrid = new System.Windows.Forms.Panel();
            this.grdHistory = new KiSS4.Gui.KissGrid();
            this.qryHistBaPerson = new KiSS4.DB.SqlQuery(this.components);
            this.grvHistory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUser = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitter = new KiSS4.Gui.KissSplitterCollapsible();
            this.panDetailControl = new System.Windows.Forms.Panel();
            this.panBottom.SuspendLayout();
            this.panGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHistBaPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).BeginInit();
            this.SuspendLayout();
            //
            // panBottom
            //
            this.panBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panBottom.Controls.Add(this.btnClose);
            this.panBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panBottom.Location = new System.Drawing.Point(0, 596);
            this.panBottom.Name = "panBottom";
            this.panBottom.Size = new System.Drawing.Size(988, 40);
            this.panBottom.TabIndex = 0;
            //
            // btnClose
            //
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(858, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(120, 24);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "&Schliessen";
            this.btnClose.UseCompatibleTextRendering = true;
            this.btnClose.UseVisualStyleBackColor = false;
            //
            // panGrid
            //
            this.panGrid.Controls.Add(this.grdHistory);
            this.panGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.panGrid.Location = new System.Drawing.Point(0, 0);
            this.panGrid.Name = "panGrid";
            this.panGrid.Size = new System.Drawing.Size(241, 596);
            this.panGrid.TabIndex = 1;
            //
            // grdHistory
            //
            this.grdHistory.DataSource = this.qryHistBaPerson;
            this.grdHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            //
            //
            //
            this.grdHistory.EmbeddedNavigator.Name = "";
            this.grdHistory.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdHistory.Location = new System.Drawing.Point(0, 0);
            this.grdHistory.MainView = this.grvHistory;
            this.grdHistory.Name = "grdHistory";
            this.grdHistory.Size = new System.Drawing.Size(241, 596);
            this.grdHistory.TabIndex = 0;
            this.grdHistory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvHistory});
            //
            // qryHistBaPerson
            //
            this.qryHistBaPerson.HostControl = this;
            this.qryHistBaPerson.TableName = "Hist_BaPerson";
            this.qryHistBaPerson.PositionChanged += new System.EventHandler(this.qryHistBaPerson_PositionChanged);
            //
            // grvHistory
            //
            this.grvHistory.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvHistory.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.Empty.Options.UseBackColor = true;
            this.grvHistory.Appearance.Empty.Options.UseFont = true;
            this.grvHistory.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.EvenRow.Options.UseFont = true;
            this.grvHistory.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHistory.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvHistory.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvHistory.Appearance.FocusedCell.Options.UseFont = true;
            this.grvHistory.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvHistory.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvHistory.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvHistory.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvHistory.Appearance.FocusedRow.Options.UseFont = true;
            this.grvHistory.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvHistory.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHistory.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvHistory.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvHistory.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHistory.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHistory.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvHistory.Appearance.GroupRow.Options.UseFont = true;
            this.grvHistory.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvHistory.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvHistory.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvHistory.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvHistory.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvHistory.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvHistory.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvHistory.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvHistory.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvHistory.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvHistory.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvHistory.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvHistory.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvHistory.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvHistory.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.OddRow.Options.UseFont = true;
            this.grvHistory.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvHistory.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.Row.Options.UseBackColor = true;
            this.grvHistory.Appearance.Row.Options.UseFont = true;
            this.grvHistory.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvHistory.Appearance.SelectedRow.Options.UseFont = true;
            this.grvHistory.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvHistory.Appearance.VertLine.Options.UseBackColor = true;
            this.grvHistory.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvHistory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDate,
            this.colUser});
            this.grvHistory.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvHistory.GridControl = this.grdHistory;
            this.grvHistory.Name = "grvHistory";
            this.grvHistory.OptionsBehavior.Editable = false;
            this.grvHistory.OptionsCustomization.AllowFilter = false;
            this.grvHistory.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvHistory.OptionsNavigation.AutoFocusNewRow = true;
            this.grvHistory.OptionsNavigation.UseTabKey = false;
            this.grvHistory.OptionsView.ColumnAutoWidth = false;
            this.grvHistory.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvHistory.OptionsView.ShowGroupPanel = false;
            this.grvHistory.OptionsView.ShowIndicator = false;
            //
            // colDate
            //
            this.colDate.Caption = "Datum";
            this.colDate.FieldName = "VersionDate";
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 0;
            this.colDate.Width = 80;
            //
            // colUser
            //
            this.colUser.Caption = "MA";
            this.colUser.FieldName = "Mitarbeiter";
            this.colUser.Name = "colUser";
            this.colUser.Visible = true;
            this.colUser.VisibleIndex = 1;
            this.colUser.Width = 130;
            //
            // splitter
            //
            this.splitter.AnimationDelay = 20;
            this.splitter.AnimationStep = 20;
            this.splitter.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitter.ControlToHide = this.panGrid;
            this.splitter.ExpandParentForm = false;
            this.splitter.Location = new System.Drawing.Point(241, 0);
            this.splitter.Name = "splitter";
            this.splitter.TabIndex = 2;
            this.splitter.TabStop = false;
            this.splitter.UseAnimations = false;
            this.splitter.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            //
            // panDetailControl
            //
            this.panDetailControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetailControl.Location = new System.Drawing.Point(249, 0);
            this.panDetailControl.Name = "panDetailControl";
            this.panDetailControl.Size = new System.Drawing.Size(739, 596);
            this.panDetailControl.TabIndex = 3;
            //
            // DlgPersonenStammHist
            //
            this.ActiveSQLQuery = this.qryHistBaPerson;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(988, 636);
            this.Controls.Add(this.panDetailControl);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.panGrid);
            this.Controls.Add(this.panBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgPersonenStammHist";
            this.Text = "Verlauf - {0}";
            this.Load += new System.EventHandler(this.DlgPersonenStammHist_Load);
            this.Shown += new System.EventHandler(this.DlgPersonenStammHist_Shown);
            this.panBottom.ResumeLayout(false);
            this.panGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryHistBaPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvHistory)).EndInit();
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

        private void DlgPersonenStammHist_Load(object sender, System.EventArgs e)
        {
            // fill data
            qryHistBaPerson.Fill(@"
                SELECT HIS.*,
                       VER.VersionDate,
                       Mitarbeiter = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName)
                FROM Hist_BaPerson HIS
                  LEFT JOIN dbo.HistoryVersion VER WITH (READUNCOMMITTED) ON VER.VerID = HIS.VerID
                  LEFT JOIN dbo.XUser          USR WITH (READUNCOMMITTED) ON USR.LogonName = VER.AppUser
                WHERE HIS.BaPersonID = {0}
                ORDER BY VER.VersionDate ASC", this._baPersonID);
        }

        private void DlgPersonenStammHist_Shown(object sender, EventArgs e)
        {
            // show last entry
            qryHistBaPerson.Last();

            // setup flags
            this._isLoading = false;

            // show entry found
            this.qryHistBaPerson_PositionChanged(this, EventArgs.Empty);
        }

        private void qryHistBaPerson_PositionChanged(object sender, System.EventArgs e)
        {
            try
            {
                // check if loading
                if (this._isLoading)
                {
                    return;
                }

                // create new control
                if (ctlBaStammdaten == null)
                {
                    // create new instance
                    ctlBaStammdaten = new CtlBaStammdaten();

                    // add to panel and show full dock
                    ctlBaStammdaten.Dock = System.Windows.Forms.DockStyle.Fill;
                    panDetailControl.Controls.Add(ctlBaStammdaten);
                    ctlBaStammdaten.BringToFront();
                }

                // init data Init(string titleName, Image titleImage, int baPersonID, int mainBaPersonID, bool showTitlePanel, bool useHistory, int verID)
                ctlBaStammdaten.Init(this._caption, this._icon, this._baPersonID, this._baPersonID, true, true, Convert.ToInt32(qryHistBaPerson["VerID"]));
            }
            catch (Exception ex)
            {
                KissMsg.ShowError("DlgPersonenStammHist", "ErrorShowingControl", "Fehler beim Anzeigen der Versionsdaten.", ex);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Translate()
        {
            // apply translation
            base.Translate();

            // apply proper title
            this.Text = KissMsg.GetMLMessage("DlgPersonenStammHist", "WindowTitle", "Verlauf - {0}", this._caption);
        }

        #endregion

        #endregion
    }
}