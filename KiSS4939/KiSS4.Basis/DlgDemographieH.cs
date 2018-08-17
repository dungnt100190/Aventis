using System.Drawing;

using DevExpress.XtraGrid.Views.Base;

namespace KiSS4.Basis
{
    /// <summary>
    /// Summary description for frmDataExplorer.
    /// </summary>
    public class DlgDemographieH : KiSS4.Gui.KissDialog
    {
        #region Fields

        #region Private Fields

        private KiSS4.Gui.KissButton btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colBenutzer;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colZeit;
        private System.ComponentModel.IContainer components;
        private KiSS4.Basis.CtlDemographieH ctlDemographieH;
        private KiSS4.Gui.KissGrid grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelDetail;
        private KiSS4.DB.SqlQuery qry;
        private System.Windows.Forms.Splitter splitter1;

        #endregion

        #endregion

        #region Constructors

        public DlgDemographieH()
        {
            //
            // Required for Windows Form Designer support
            //
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
            this.qry = new KiSS4.DB.SqlQuery(this.components);
            this.grid = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZeit = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBenutzer = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panelDetail = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // qry
            //
            this.qry.HostControl = this;
            this.qry.PositionChanged += new System.EventHandler(this.qry_PositionChanged);
            //
            // grid
            //
            this.grid.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(239)), ((System.Byte)(231)));
            this.grid.CausesValidation = false;
            this.grid.DataSource = this.qry;
            this.grid.Dock = System.Windows.Forms.DockStyle.Left;
            //
            // grid.EmbeddedNavigator
            //
            this.grid.EmbeddedNavigator.Name = "";
            this.grid.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grid.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.gridView1;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(276, 500);
            this.grid.Styles.AddReplace("EvenRow", new DevExpress.Utils.ViewStyle("EvenRow", "GridView", new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.UseBackColor, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((System.Byte)(236)), ((System.Byte)(227)), ((System.Byte)(215))), System.Drawing.SystemColors.WindowText));
            this.grid.Styles.AddReplace("HideSelectionRow", new DevExpress.Utils.ViewStyleEx("HideSelectionRow", "Grid", new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0))), ((DevExpress.Utils.StyleOptions)((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                | DevExpress.Utils.StyleOptions.UseDrawFocusRect)
                | DevExpress.Utils.StyleOptions.UseImage))), System.Drawing.Color.PowderBlue, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("HeaderPanel", new DevExpress.Utils.ViewStyleEx("HeaderPanel", "Grid", new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0))), "", true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.Tan, System.Drawing.SystemColors.ControlText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("GroupPanel", new DevExpress.Utils.ViewStyleEx("GroupPanel", "Grid", "", true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.PeachPuff, System.Drawing.SystemColors.ControlText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("Empty", new DevExpress.Utils.ViewStyleEx("Empty", "Grid", System.Drawing.Color.Transparent, System.Drawing.SystemColors.Window, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("GroupRow", new DevExpress.Utils.ViewStyleEx("GroupRow", "Grid", new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0))), "", true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.PeachPuff, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("FocusedRow", new DevExpress.Utils.ViewStyleEx("FocusedRow", "Grid", new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0))), ((DevExpress.Utils.StyleOptions)((((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor)
                | DevExpress.Utils.StyleOptions.UseDrawFocusRect)
                | DevExpress.Utils.StyleOptions.UseImage))), System.Drawing.SystemColors.Highlight, System.Drawing.SystemColors.HighlightText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("StyleCenter", new DevExpress.Utils.ViewStyleEx("StyleCenter", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Center, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("FocusedCell", new DevExpress.Utils.ViewStyleEx("FocusedCell", "Grid", new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel), ((DevExpress.Utils.StyleOptions)((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor))), System.Drawing.SystemColors.Highlight, System.Drawing.Color.White, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("OddRow", new DevExpress.Utils.ViewStyle("OddRow", "GridView", new System.Drawing.Font("Microsoft Sans Serif", 8F), "", DevExpress.Utils.StyleOptions.UseBackColor, true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(239)), ((System.Byte)(222))), System.Drawing.SystemColors.WindowText));
            this.grid.Styles.AddReplace("SelectedRow", new DevExpress.Utils.ViewStyle("SelectedRow", "GridView", new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0))), "", ((DevExpress.Utils.StyleOptions)((DevExpress.Utils.StyleOptions.StyleEnabled | DevExpress.Utils.StyleOptions.UseBackColor))), true, false, false, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.Color.FromArgb(((System.Byte)(208)), ((System.Byte)(170)), ((System.Byte)(74))), System.Drawing.Color.Black));
            this.grid.Styles.AddReplace("StyleNear", new DevExpress.Utils.ViewStyleEx("StyleNear", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("StyleFar", new DevExpress.Utils.ViewStyleEx("StyleFar", null, "", DevExpress.Utils.StyleOptions.UseHorzAlignment, true, false, false, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, null, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.Styles.AddReplace("Row", new DevExpress.Utils.ViewStyleEx("Row", "Grid", new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((System.Byte)(0))), DevExpress.Utils.StyleOptions.StyleEnabled, System.Drawing.Color.BlanchedAlmond, System.Drawing.SystemColors.WindowText, System.Drawing.Color.Empty, System.Drawing.Drawing2D.LinearGradientMode.Horizontal));
            this.grid.TabIndex = 0;
            //
            // gridView1
            //
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                                                                                             this.colDatum,
                                                                                             this.colZeit,
                                                                                             this.colBenutzer});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.grid;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsCustomization.AllowGroup = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsPrint.AutoWidth = false;
            this.gridView1.OptionsPrint.UsePrintStyles = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowDetailButtons = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            //
            // colDatum
            //
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Datum";
            this.colDatum.Name = "colDatum";
            this.colDatum.VisibleIndex = 0;
            //
            // colZeit
            //
            this.colZeit.Caption = "Zeit";
            this.colZeit.FieldName = "Zeit";
            this.colZeit.Name = "colZeit";
            this.colZeit.VisibleIndex = 1;
            this.colZeit.Width = 62;
            //
            // colBenutzer
            //
            this.colBenutzer.Caption = "Benutzer/-in";
            this.colBenutzer.FieldName = "Benutzer";
            this.colBenutzer.Name = "colBenutzer";
            this.colBenutzer.VisibleIndex = 2;
            this.colBenutzer.Width = 119;
            //
            // splitter1
            //
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(231)), ((System.Byte)(219)), ((System.Byte)(173)));
            this.splitter1.Location = new System.Drawing.Point(276, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(4, 500);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            //
            // panelDetail
            //
            this.panelDetail.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(239)), ((System.Byte)(231)));
            this.panelDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDetail.ForeColor = System.Drawing.Color.Black;
            this.panelDetail.Location = new System.Drawing.Point(280, 0);
            this.panelDetail.Name = "panelDetail";
            this.panelDetail.Size = new System.Drawing.Size(678, 500);
            this.panelDetail.TabIndex = 4;
            //
            // panel1
            //
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(247)), ((System.Byte)(239)), ((System.Byte)(231)));
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(280, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(678, 34);
            this.panel1.TabIndex = 5;
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(578, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Schliessen";
            //
            // DlgDemographieH
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(958, 500);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.grid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgDemographieH";
            this.Text = "History";
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel1.ResumeLayout(false);
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

        private void qry_PositionChanged(object sender, System.EventArgs e)
        {
            ctlDemographieH.SetVersion((int)qry["BaPersonID"], (int)qry["VerID"]);
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string TitleName, Image TitleImage, int BaPersonID, int FTPersonID, bool IsFallTraeger)
        {
            ctlDemographieH = new CtlDemographieH();
            ctlDemographieH.Init(TitleName, TitleImage, FTPersonID, IsFallTraeger);

            panelDetail.Controls.Add(ctlDemographieH);
            ctlDemographieH.Location = new System.Drawing.Point(0, 0);
            ctlDemographieH.Size = this.panelDetail.Size;
            ctlDemographieH.Parent = this.panelDetail;
            ctlDemographieH.Dock = System.Windows.Forms.DockStyle.Fill;
            ctlDemographieH.Visible = true;

            qry.Fill(@"
                SELECT  DISTINCT
                        VerID    = VER.VerID,
                        Datum    = CASE WHEN VER.VersionDate <> '19000101' THEN VER.VersionDate end,
                        Zeit     = CASE WHEN VER.VersionDate <> '19000101' THEN convert(varchar, VER.VersionDate, 8) end, -- hh:mm:ss
                        Benutzer = CASE WHEN VER.VersionDate <> '19000101'
                                   THEN
                                        CASE WHEN VER.AppUser IS NULL
                                        THEN 'extern'
                                        ELSE isNull(USR.LastName + isNull(', ' + USR.FirstName,''), VER.AppUser + ' (logon)')
                                        end
                                   ELSE 'initial'
                                   end,
                        BaPersonID = {0}
                FROM
                (
                        SELECT PRS.VerID FROM Hist_BaPerson  PRS WHERE PRS.BaPersonID = {0}
                        UNION
                        SELECT ADR.VerID FROM Hist_BaAdresse ADR WHERE ADR.BaPersonID = {0}
                )						 HVR
                LEFT JOIN HistoryVersion VER ON HVR.VerID = VER.VerID
                LEFT JOIN XUser          USR ON USR.LogonName = VER.AppUser
                ORDER BY VER.VerID DESC",
                BaPersonID);

            //ctlDemographieH.SetVersion((int) qry["BaPersonID"],(int) qry["VerID"]);
        }

        #endregion

        #endregion
    }
}