using System;
using System.Drawing;

using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Common.Report;

namespace KiSS4.Arbeit
{
    /// <summary>
    /// Summary description for CtlKaPraesenzAllgemein.
    /// </summary>
    public class CtlKaPraesenzAllgemein : KissUserControl
    {
        #region Fields

        #region Private Fields

        private int BaPersonID = 0;
        private int FaLeistungID = 0;
        private KiSS4.Gui.KissButton btnPraesenzzeit;
        private KiSS4.Gui.KissButton btnPrint;
        private DevExpress.XtraGrid.Columns.GridColumn colBemerkung;
        private DevExpress.XtraGrid.Columns.GridColumn colDatum;
        private DevExpress.XtraGrid.Columns.GridColumn colVN;
        private System.ComponentModel.IContainer components;
        private KiSS4.Gui.KissGrid grdPraesenzBem;
        private DevExpress.XtraGrid.Views.Grid.GridView gvPraesenzBem;
        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.PictureBox picTitle;
        private KiSS4.DB.SqlQuery qryPraesenz;
        private KiSS4.DB.SqlQuery qryPraesenzBem;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;

        #endregion

        #endregion

        #region Constructors

        public CtlKaPraesenzAllgemein()
        {
            // This call is required by the Windows.Forms Form Designer.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlKaPraesenzAllgemein));
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitel = new System.Windows.Forms.Label();
            this.btnPraesenzzeit = new KiSS4.Gui.KissButton();
            this.qryPraesenz = new KiSS4.DB.SqlQuery(this.components);
            this.grdPraesenzBem = new KiSS4.Gui.KissGrid();
            this.qryPraesenzBem = new KiSS4.DB.SqlQuery(this.components);
            this.gvPraesenzBem = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDatum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBemerkung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnPrint = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraesenz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPraesenzBem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraesenzBem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPraesenzBem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // picTitle
            // 
            this.picTitle.Image = ((System.Drawing.Image)(resources.GetObject("picTitle.Image")));
            this.picTitle.Location = new System.Drawing.Point(10, 9);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(25, 20);
            this.picTitle.TabIndex = 16;
            this.picTitle.TabStop = false;
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.lblTitel.ForeColor = System.Drawing.Color.Black;
            this.lblTitel.Location = new System.Drawing.Point(35, 10);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(31, 15);
            this.lblTitel.TabIndex = 17;
            this.lblTitel.Text = "Titel";
            // 
            // btnPraesenzzeit
            // 
            this.btnPraesenzzeit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPraesenzzeit.Location = new System.Drawing.Point(5, 50);
            this.btnPraesenzzeit.Name = "btnPraesenzzeit";
            this.btnPraesenzzeit.Size = new System.Drawing.Size(150, 24);
            this.btnPraesenzzeit.TabIndex = 18;
            this.btnPraesenzzeit.Text = "Präsenzzeit erfassen";
            this.btnPraesenzzeit.UseVisualStyleBackColor = false;
            this.btnPraesenzzeit.Click += new System.EventHandler(this.btnPraesenzzeit_Click);
            // 
            // qryPraesenz
            // 
            this.qryPraesenz.CanDelete = true;
            this.qryPraesenz.CanInsert = true;
            this.qryPraesenz.CanUpdate = true;
            this.qryPraesenz.HostControl = this;
            this.qryPraesenz.IsIdentityInsert = false;
            this.qryPraesenz.TableName = "KaAllgemein";
            // 
            // grdPraesenzBem
            // 
            this.grdPraesenzBem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPraesenzBem.DataSource = this.qryPraesenzBem;
            // 
            // 
            // 
            this.grdPraesenzBem.EmbeddedNavigator.Name = "";
            this.grdPraesenzBem.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdPraesenzBem.Location = new System.Drawing.Point(6, 83);
            this.grdPraesenzBem.MainView = this.gvPraesenzBem;
            this.grdPraesenzBem.Name = "grdPraesenzBem";
            this.grdPraesenzBem.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemMemoEdit1});
            this.grdPraesenzBem.Size = new System.Drawing.Size(633, 309);
            this.grdPraesenzBem.TabIndex = 612;
            this.grdPraesenzBem.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvPraesenzBem});
            // 
            // qryPraesenzBem
            // 
            this.qryPraesenzBem.HostControl = this;
            this.qryPraesenzBem.IsIdentityInsert = false;
            this.qryPraesenzBem.TableName = "KaArbeitsrapport";
            // 
            // gvPraesenzBem
            // 
            this.gvPraesenzBem.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvPraesenzBem.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenzBem.Appearance.Empty.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.Empty.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenzBem.Appearance.EvenRow.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvPraesenzBem.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenzBem.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gvPraesenzBem.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.FocusedCell.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvPraesenzBem.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gvPraesenzBem.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenzBem.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gvPraesenzBem.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.FocusedRow.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvPraesenzBem.Appearance.GroupFooter.BackColor = System.Drawing.Color.PeachPuff;
            this.gvPraesenzBem.Appearance.GroupFooter.BorderColor = System.Drawing.Color.BlanchedAlmond;
            this.gvPraesenzBem.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.GroupFooter.Options.UseBorderColor = true;
            this.gvPraesenzBem.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvPraesenzBem.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvPraesenzBem.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvPraesenzBem.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvPraesenzBem.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.GroupRow.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvPraesenzBem.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvPraesenzBem.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvPraesenzBem.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvPraesenzBem.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvPraesenzBem.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gvPraesenzBem.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenzBem.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvPraesenzBem.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvPraesenzBem.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gvPraesenzBem.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenzBem.Appearance.OddRow.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gvPraesenzBem.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenzBem.Appearance.Row.Options.UseBackColor = true;
            this.gvPraesenzBem.Appearance.Row.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvPraesenzBem.Appearance.SelectedRow.Options.UseFont = true;
            this.gvPraesenzBem.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gvPraesenzBem.Appearance.VertLine.Options.UseBackColor = true;
            this.gvPraesenzBem.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvPraesenzBem.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDatum,
            this.colVN,
            this.colBemerkung});
            this.gvPraesenzBem.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gvPraesenzBem.GridControl = this.grdPraesenzBem;
            this.gvPraesenzBem.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvPraesenzBem.Name = "gvPraesenzBem";
            this.gvPraesenzBem.OptionsBehavior.Editable = false;
            this.gvPraesenzBem.OptionsCustomization.AllowFilter = false;
            this.gvPraesenzBem.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvPraesenzBem.OptionsNavigation.AutoFocusNewRow = true;
            this.gvPraesenzBem.OptionsNavigation.UseTabKey = false;
            this.gvPraesenzBem.OptionsView.ColumnAutoWidth = false;
            this.gvPraesenzBem.OptionsView.RowAutoHeight = true;
            this.gvPraesenzBem.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvPraesenzBem.OptionsView.ShowGroupPanel = false;
            this.gvPraesenzBem.OptionsView.ShowIndicator = false;
            // 
            // colDatum
            // 
            this.colDatum.Caption = "Datum";
            this.colDatum.FieldName = "Dat";
            this.colDatum.Name = "colDatum";
            this.colDatum.Visible = true;
            this.colDatum.VisibleIndex = 0;
            // 
            // colVN
            // 
            this.colVN.AppearanceCell.Options.UseTextOptions = true;
            this.colVN.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colVN.Caption = "VN";
            this.colVN.FieldName = "VN";
            this.colVN.Name = "colVN";
            this.colVN.Visible = true;
            this.colVN.VisibleIndex = 1;
            this.colVN.Width = 30;
            // 
            // colBemerkung
            // 
            this.colBemerkung.Caption = "Bemerkung";
            this.colBemerkung.ColumnEdit = this.repositoryItemMemoEdit1;
            this.colBemerkung.FieldName = "Bem";
            this.colBemerkung.Name = "colBemerkung";
            this.colBemerkung.Visible = true;
            this.colBemerkung.VisibleIndex = 2;
            this.colBemerkung.Width = 500;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.ReadOnly = true;
            this.repositoryItemMemoEdit1.WordWrap = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // btnPrint
            // 
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(160, 50);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(149, 24);
            this.btnPrint.TabIndex = 613;
            this.btnPrint.Text = "Präsenzzeit drucken";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // CtlKaPraesenzAllgemein
            // 
            this.ActiveSQLQuery = this.qryPraesenz;
            this.AutoScroll = true;
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grdPraesenzBem);
            this.Controls.Add(this.btnPraesenzzeit);
            this.Controls.Add(this.picTitle);
            this.Controls.Add(this.lblTitel);
            this.Name = "CtlKaPraesenzAllgemein";
            this.Size = new System.Drawing.Size(646, 404);
            this.Load += new System.EventHandler(this.CtlKaPraesenzAllgemein_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraesenz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPraesenzBem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryPraesenzBem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvPraesenzBem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Dispose

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if(components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #endregion

        #region EventHandlers

        private void CtlKaPraesenzAllgemein_Load(object sender, System.EventArgs e)
        {
            qryPraesenzBem.Fill(@"
                SELECT Dat = Convert(DateTime, Datum, 104), VN = 'V', Bem = AM_Bemerkung
                FROM KaArbeitsrapport
                WHERE AM_Bemerkung is not null
                AND BaPersonID = {0}
                AND Datum >= (SELECT MIN(datumvon)
                             FROM	FaLeistung
                             WHERE	BaPersonID = {0}
                             AND	ModulID = 7
                             AND	FaProzessCode BETWEEN 701 AND 720
                             AND	DatumBis IS NULL)
                AND (SichtbarSDFlag = {1} or SichtbarSDFlag = 1)

                UNION ALL

                SELECT Dat = Convert(DateTime, Datum, 104), VN = 'N', Bem = PM_Bemerkung
                FROM KaArbeitsrapport
                WHERE PM_Bemerkung is not null
                AND BaPersonID = {0}
                AND Datum >= (SELECT MIN(datumvon)
                             FROM	FaLeistung
                             WHERE	BaPersonID = {0}
                             AND	ModulID = 7
                             AND	FaProzessCode BETWEEN 701 AND 720
                             AND	DatumBis IS NULL)
                AND (SichtbarSDFlag = {1} or SichtbarSDFlag = 1)

                ORDER BY Dat DESC, VN DESC",
                this.BaPersonID, KaUtil.GetSichtbarSDFlag(this.BaPersonID));

            // Insert row in KaAllgemein if there is no entry.
            if (!PraesenzExists() && DBUtil.UserHasRight("CtlKaPraesenzAllgemein"))
            {
                DBUtil.ExecSQL(@"INSERT INTO KaAllgemein (FaLeistungID, SichtbarSDFlag) VALUES ({0}, {1})", this.FaLeistungID, KaUtil.IsVisibleSD(this.BaPersonID));
            }

            qryPraesenz.Fill(@"
                SELECT KAA.*
                FROM   KaAllgemein KAA
                WHERE  KAA.FaLeistungID = {0}
                AND	   (SichtbarSDFlag = {1} or SichtbarSDFlag = 1)",
                this.FaLeistungID, KaUtil.GetSichtbarSDFlag(this.BaPersonID));

            btnPraesenzzeit.Enabled = (DBUtil.UserHasRight("CtlKaPraesenzAllgemein", "UI"));
            btnPrint.Enabled = (DBUtil.UserHasRight("CtlKaPraesenzAllgemein", "UI"));

            if (KaUtil.GetSichtbarSDFlag(this.BaPersonID) == 1)
            {
                btnPraesenzzeit.Enabled = false;
                btnPrint.Enabled = false;
            }
        }

        private void btnPraesenzzeit_Click(object sender, System.EventArgs e)
        {
            ((KissMainForm)Session.MainForm).OpenChildForm(typeof(Arbeit.FrmKaPraesenzzeit));
            FrmKaPraesenzzeit frmPraesenz = (FrmKaPraesenzzeit)((KissMainForm)Session.MainForm).GetChildForm(typeof(Arbeit.FrmKaPraesenzzeit));
            frmPraesenz.SetKlientX(this.BaPersonID);
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            NamedPrm[] prms = new NamedPrm[1];
            prms[0] = new NamedPrm("BaPersonID", this.BaPersonID);
            RepUtil.ExecuteReport("KAPraesenzzeitUebersicht", KissReportDestination.Viewer, prms);
        }

        #endregion

        #region Methods

        #region Public Methods

        public override object GetContextValue(string FieldName)
        {
            switch (FieldName.ToUpper())
            {
                case "BAPERSONID":
                    return this.BaPersonID;

                case "FALEISTUNGID":
                    return this.FaLeistungID;

            }

            return base.GetContextValue(FieldName);
        }

        public void Init(string TitleName, Image TitleImage, int BaPersonID, int FaLeistungID)
        {
            this.lblTitel.Text = TitleName;
            this.picTitle.Image = TitleImage;
            this.BaPersonID = BaPersonID;
            this.FaLeistungID = FaLeistungID;
        }

        #endregion

        #region Private Methods

        private bool PraesenzExists()
        {
            bool rslt = false;

            rslt =	Convert.ToInt32(
                DBUtil.ExecuteScalarSQL(@"select count(*) from KaAllgemein where FaLeistungID = {0}",
                this.FaLeistungID)
                ) > 0;

            return rslt;
        }

        #endregion

        #endregion
    }
}