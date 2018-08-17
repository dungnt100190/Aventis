using System;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Arbeit
{
    public class FrmKaSequenzen : KiSS4.Gui.KissChildForm
    {
        private KiSS4.Gui.KissButton btnNewValue;
        private KiSS4.Gui.KissButton btnRefreshSeq;
        private DevExpress.XtraGrid.Columns.GridColumn colAktiv;
        private DevExpress.XtraGrid.Columns.GridColumn colCode;
        private DevExpress.XtraGrid.Columns.GridColumn colText;
        private System.ComponentModel.IContainer components = null;

        //private int showBaInstitutionID = 0;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;

        private KiSS4.Gui.KissGrid grdSequenzen;
        private KiSS4.Gui.KissGrid grdWerteliste;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSequenzen;
        private DevExpress.XtraGrid.Views.Grid.GridView gvWerteliste;
        private System.Windows.Forms.Label lblAnzahl;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Panel pnlFooter;
        private KiSS4.DB.SqlQuery qrySequenzen;
        private KiSS4.DB.SqlQuery qryWerteliste;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;

        public FrmKaSequenzen()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        public override object GetContextValue(string FieldName)
        {
            /*
             * 			switch (FieldName.ToUpper())
                        {
                            case "BAINSTITUTIONID":
                                if (qryPraesenz.Count > 0)
                                    return qryPraesenz["BaInstitutionID"];
                                break;

                            case "ADRESSATID":
                                if (qryPraesenz.Count > 0)
                                    return -(int)qryPraesenz["BaInstitutionID"];  //Adressat für Institution: negative ID!
                                break;
                        }

            */
            return base.GetContextValue(FieldName);
        }

        public override void OnRefreshData()
        {
            try
            {
                if (DBUtil.UserHasRight("FrmKaSequenzen", "U"))
                {
                    qrySequenzen.Post();
                    qryWerteliste.Post();
                }
            }
            catch { }

            FillData();

            //    base.OnRefreshData();
        }

        public override bool OnSaveData()
        {
            //			bool rslt = base.OnSaveData();
            bool rslt = true;

            rslt = qrySequenzen.Post() && qryWerteliste.Post();

            FillData();

            return rslt;
        }

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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.qrySequenzen = new KiSS4.DB.SqlQuery(this.components);
            this.lblAnzahl = new System.Windows.Forms.Label();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.grdSequenzen = new KiSS4.Gui.KissGrid();
            this.gvSequenzen = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.qryWerteliste = new KiSS4.DB.SqlQuery(this.components);
            this.grdWerteliste = new KiSS4.Gui.KissGrid();
            this.gvWerteliste = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAktiv = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnNewValue = new KiSS4.Gui.KissButton();
            this.btnRefreshSeq = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qrySequenzen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSequenzen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSequenzen)).BeginInit();
            this.pnlFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryWerteliste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWerteliste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWerteliste)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            //
            // qrySequenzen
            //
            this.qrySequenzen.CanUpdate = true;
            this.qrySequenzen.HostControl = this;
            this.qrySequenzen.TableName = "KaSequenzen";
            this.qrySequenzen.BeforePost += new System.EventHandler(this.qrySequenzen_BeforePost);
            this.qrySequenzen.PositionChanged += new System.EventHandler(this.qrySequenzen_PositionChanged);
            //
            // lblAnzahl
            //
            this.lblAnzahl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnzahl.AutoSize = true;
            this.lblAnzahl.Location = new System.Drawing.Point(936, 16);
            this.lblAnzahl.Name = "lblAnzahl";
            this.lblAnzahl.Size = new System.Drawing.Size(99, 13);
            this.lblAnzahl.TabIndex = 570;
            this.lblAnzahl.Text = "Anzahl Datensätze:";
            //
            // lblRowCount
            //
            this.lblRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowCount.Location = new System.Drawing.Point(1056, 16);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(14, 13);
            this.lblRowCount.TabIndex = 571;
            this.lblRowCount.Text = "0";
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlGotoFall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlGotoFall.Location = new System.Drawing.Point(416, 8);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.Size = new System.Drawing.Size(200, 24);
            this.ctlGotoFall.TabIndex = 4;
            //
            // grdSequenzen
            //
            this.grdSequenzen.DataSource = this.qrySequenzen;
            this.grdSequenzen.Dock = System.Windows.Forms.DockStyle.Top;
            this.grdSequenzen.EmbeddedNavigator.Name = "";
            this.grdSequenzen.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdSequenzen.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdSequenzen.Location = new System.Drawing.Point(0, 0);
            this.grdSequenzen.MainView = this.gvSequenzen;
            this.grdSequenzen.Name = "grdSequenzen";
            this.grdSequenzen.Size = new System.Drawing.Size(1080, 384);
            this.grdSequenzen.TabIndex = 586;
            this.grdSequenzen.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSequenzen});
            //
            // gvSequenzen
            //
            this.gvSequenzen.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvSequenzen.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvSequenzen.Appearance.Empty.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.Empty.Options.UseFont = true;
            this.gvSequenzen.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvSequenzen.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvSequenzen.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.EvenRow.Options.UseFont = true;
            this.gvSequenzen.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gvSequenzen.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvSequenzen.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvSequenzen.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.FocusedCell.Options.UseFont = true;
            this.gvSequenzen.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvSequenzen.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvSequenzen.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvSequenzen.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvSequenzen.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.FocusedRow.Options.UseFont = true;
            this.gvSequenzen.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvSequenzen.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvSequenzen.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvSequenzen.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvSequenzen.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvSequenzen.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.GroupRow.Options.UseFont = true;
            this.gvSequenzen.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvSequenzen.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvSequenzen.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvSequenzen.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvSequenzen.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvSequenzen.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvSequenzen.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvSequenzen.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvSequenzen.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvSequenzen.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvSequenzen.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvSequenzen.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gvSequenzen.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gvSequenzen.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvSequenzen.Appearance.OddRow.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.OddRow.Options.UseFont = true;
            this.gvSequenzen.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gvSequenzen.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvSequenzen.Appearance.Row.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.Row.Options.UseFont = true;
            this.gvSequenzen.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvSequenzen.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvSequenzen.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvSequenzen.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvSequenzen.Appearance.SelectedRow.Options.UseFont = true;
            this.gvSequenzen.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvSequenzen.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gvSequenzen.Appearance.VertLine.Options.UseBackColor = true;
            this.gvSequenzen.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvSequenzen.GridControl = this.grdSequenzen;
            this.gvSequenzen.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvSequenzen.Name = "gvSequenzen";
            this.gvSequenzen.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvSequenzen.OptionsCustomization.AllowFilter = false;
            this.gvSequenzen.OptionsCustomization.AllowGroup = false;
            this.gvSequenzen.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvSequenzen.OptionsNavigation.AutoFocusNewRow = true;
            this.gvSequenzen.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvSequenzen.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvSequenzen.OptionsPrint.AutoWidth = false;
            this.gvSequenzen.OptionsPrint.UsePrintStyles = true;
            this.gvSequenzen.OptionsView.ColumnAutoWidth = false;
            this.gvSequenzen.OptionsView.ShowDetailButtons = false;
            this.gvSequenzen.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvSequenzen.OptionsView.ShowGroupPanel = false;
            this.gvSequenzen.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gvSequenzen_RowCellStyle);
            //
            // pnlFooter
            //
            this.pnlFooter.Controls.Add(this.lblAnzahl);
            this.pnlFooter.Controls.Add(this.lblRowCount);
            this.pnlFooter.Controls.Add(this.ctlGotoFall);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFooter.Location = new System.Drawing.Point(0, 384);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1080, 40);
            this.pnlFooter.TabIndex = 592;
            //
            // qryWerteliste
            //
            this.qryWerteliste.CanInsert = true;
            this.qryWerteliste.CanUpdate = true;
            this.qryWerteliste.HostControl = this;
            this.qryWerteliste.TableName = "XLOVCode";
            this.qryWerteliste.BeforePost += new System.EventHandler(this.qryWerteliste_BeforePost);
            //
            // grdWerteliste
            //
            this.grdWerteliste.DataSource = this.qryWerteliste;
            this.grdWerteliste.Dock = System.Windows.Forms.DockStyle.Left;
            this.grdWerteliste.EmbeddedNavigator.Name = "";
            this.grdWerteliste.GridStyle = KiSS4.Gui.GridStyleType.Editable;
            this.grdWerteliste.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grdWerteliste.Location = new System.Drawing.Point(0, 424);
            this.grdWerteliste.MainView = this.gvWerteliste;
            this.grdWerteliste.Name = "grdWerteliste";
            this.grdWerteliste.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdWerteliste.Size = new System.Drawing.Size(480, 182);
            this.grdWerteliste.TabIndex = 593;
            this.grdWerteliste.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvWerteliste});
            //
            // gvWerteliste
            //
            this.gvWerteliste.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gvWerteliste.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvWerteliste.Appearance.Empty.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.Empty.Options.UseFont = true;
            this.gvWerteliste.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.gvWerteliste.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvWerteliste.Appearance.EvenRow.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.EvenRow.Options.UseFont = true;
            this.gvWerteliste.Appearance.FocusedCell.BackColor = System.Drawing.Color.AliceBlue;
            this.gvWerteliste.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvWerteliste.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Black;
            this.gvWerteliste.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.FocusedCell.Options.UseFont = true;
            this.gvWerteliste.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gvWerteliste.Appearance.FocusedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvWerteliste.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvWerteliste.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.gvWerteliste.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.FocusedRow.Options.UseFont = true;
            this.gvWerteliste.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gvWerteliste.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gvWerteliste.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gvWerteliste.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvWerteliste.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvWerteliste.Appearance.GroupRow.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.GroupRow.Options.UseFont = true;
            this.gvWerteliste.Appearance.GroupRow.Options.UseForeColor = true;
            this.gvWerteliste.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gvWerteliste.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gvWerteliste.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gvWerteliste.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gvWerteliste.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvWerteliste.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvWerteliste.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvWerteliste.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gvWerteliste.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gvWerteliste.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gvWerteliste.Appearance.HorzLine.BackColor = System.Drawing.Color.LightGray;
            this.gvWerteliste.Appearance.HorzLine.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.gvWerteliste.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvWerteliste.Appearance.OddRow.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.OddRow.Options.UseFont = true;
            this.gvWerteliste.Appearance.Row.BackColor = System.Drawing.Color.AliceBlue;
            this.gvWerteliste.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvWerteliste.Appearance.Row.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.Row.Options.UseFont = true;
            this.gvWerteliste.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.gvWerteliste.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gvWerteliste.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.gvWerteliste.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gvWerteliste.Appearance.SelectedRow.Options.UseFont = true;
            this.gvWerteliste.Appearance.SelectedRow.Options.UseForeColor = true;
            this.gvWerteliste.Appearance.VertLine.BackColor = System.Drawing.Color.LightGray;
            this.gvWerteliste.Appearance.VertLine.Options.UseBackColor = true;
            this.gvWerteliste.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gvWerteliste.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCode,
            this.colText,
            this.colAktiv});
            this.gvWerteliste.GridControl = this.grdWerteliste;
            this.gvWerteliste.GroupPanelText = "zu gruppierende Kolonnen in diesen Bereich ziehen";
            this.gvWerteliste.Name = "gvWerteliste";
            this.gvWerteliste.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gvWerteliste.OptionsCustomization.AllowFilter = false;
            this.gvWerteliste.OptionsCustomization.AllowGroup = false;
            this.gvWerteliste.OptionsCustomization.AllowSort = false;
            this.gvWerteliste.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvWerteliste.OptionsNavigation.AutoFocusNewRow = true;
            this.gvWerteliste.OptionsNavigation.AutoMoveRowFocus = false;
            this.gvWerteliste.OptionsNavigation.EnterMoveNextColumn = true;
            this.gvWerteliste.OptionsPrint.AutoWidth = false;
            this.gvWerteliste.OptionsPrint.UsePrintStyles = true;
            this.gvWerteliste.OptionsView.ColumnAutoWidth = false;
            this.gvWerteliste.OptionsView.ShowDetailButtons = false;
            this.gvWerteliste.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gvWerteliste.OptionsView.ShowGroupPanel = false;
            //
            // colCode
            //
            this.colCode.Caption = "Code";
            this.colCode.FieldName = "Code";
            this.colCode.Name = "colCode";
            this.colCode.Visible = true;
            this.colCode.VisibleIndex = 0;
            this.colCode.Width = 40;
            //
            // colText
            //
            this.colText.Caption = "Text";
            this.colText.FieldName = "Text";
            this.colText.Name = "colText";
            this.colText.Visible = true;
            this.colText.VisibleIndex = 1;
            this.colText.Width = 350;
            //
            // colAktiv
            //
            this.colAktiv.Caption = "Filter";
            this.colAktiv.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colAktiv.FieldName = "Filter";
            this.colAktiv.Name = "colAktiv";
            this.colAktiv.Visible = true;
            this.colAktiv.VisibleIndex = 2;
            this.colAktiv.Width = 50;
            //
            // repositoryItemCheckEdit1
            //
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            //
            // btnNewValue
            //
            this.btnNewValue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewValue.Location = new System.Drawing.Point(488, 432);
            this.btnNewValue.Name = "btnNewValue";
            this.btnNewValue.Size = new System.Drawing.Size(160, 24);
            this.btnNewValue.TabIndex = 594;
            this.btnNewValue.Text = "neuer Eintrag Werteliste";
            this.btnNewValue.UseVisualStyleBackColor = false;
            this.btnNewValue.Click += new System.EventHandler(this.btnNewValue_Click);
            //
            // btnRefreshSeq
            //
            this.btnRefreshSeq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshSeq.Location = new System.Drawing.Point(488, 464);
            this.btnRefreshSeq.Name = "btnRefreshSeq";
            this.btnRefreshSeq.Size = new System.Drawing.Size(160, 24);
            this.btnRefreshSeq.TabIndex = 595;
            this.btnRefreshSeq.Text = "Sequenzen aktualisieren";
            this.btnRefreshSeq.UseVisualStyleBackColor = false;
            this.btnRefreshSeq.Click += new System.EventHandler(this.btnRefreshSeq_Click);
            //
            // FrmKaSequenzen
            //
            this.ActiveSQLQuery = this.qrySequenzen;
            this.ClientSize = new System.Drawing.Size(1080, 606);
            this.Controls.Add(this.btnRefreshSeq);
            this.Controls.Add(this.btnNewValue);
            this.Controls.Add(this.grdWerteliste);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.grdSequenzen);
            this.Name = "FrmKaSequenzen";
            this.Text = "KA Sequenzen";
            this.Load += new System.EventHandler(this.FrmKaSequenzen_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmKaSequenzen_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.qrySequenzen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSequenzen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSequenzen)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.qryWerteliste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWerteliste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvWerteliste)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private void btnNewValue_Click(object sender, System.EventArgs e)
        {
            try
            {
                qryWerteliste.Insert();
                //XLOVID holen
                SqlQuery qry = DBUtil.OpenSQL(@"SELECT DISTINCT XLOVID FROM XLOVCode WHERE LOVName = 'KaJobSequenzen'");
                qryWerteliste["XLOVID"] = qry["XLOVID"];

                qryWerteliste["LOVName"] = "KaJobSequenzen";
                qryWerteliste["Value3"] = 1;
                qryWerteliste["Filter"] = true;
            }
            catch { }
        }

        private void btnRefreshSeq_Click(object sender, System.EventArgs e)
        {
            try
            {
                if (DBUtil.UserHasRight("FrmKaSequenzen", "U"))
                {
                    qrySequenzen.Post();
                    qryWerteliste.Post();
                }
            }
            catch { }

            FillData();
        }

        private void FillData()
        {
            this.ctlGotoFall.ResetFallIcons();

            Cursor.Current = Cursors.WaitCursor;

            SqlQuery qry = DBUtil.OpenSQL(@"
									SELECT Code, Text
									FROM XLOVCode
									WHERE LOVName = 'KaJobSequenzen'
									AND convert(bit, isnull(Value3, 0)) = convert(bit, 1)
									ORDER BY Code ASC");

            DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repItemKaPraesenzCode = this.grdSequenzen.GetLOVLookUpEdit("KaJobPraesenzCode", true);
            repItemKaPraesenzCode.PopupWidth = 20;
            repItemKaPraesenzCode.DropDownRows = 2;
            repItemKaPraesenzCode.Columns.Clear();
            repItemKaPraesenzCode.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Text", 20));
            repItemKaPraesenzCode.DisplayMember = "Text";
            repItemKaPraesenzCode.ReadOnly = !DBUtil.UserHasRight("FrmKaSequenzen", "U");

            gvSequenzen.Columns.Clear();
            DevExpress.XtraGrid.Columns.GridColumn gcKlient = new DevExpress.XtraGrid.Columns.GridColumn();
            gcKlient.Caption = "STES";
            gcKlient.Name = "colKlient";
            gcKlient.FieldName = "Klient";
            gcKlient.VisibleIndex = 1;
            gcKlient.Width = 100;

            gcKlient.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            gcKlient.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.True;
            gcKlient.OptionsColumn.AllowSize = true;
            gcKlient.OptionsColumn.AllowFocus = true;
            gcKlient.OptionsColumn.ShowInCustomizationForm = true;
            gcKlient.OptionsColumn.AllowIncrementalSearch = true;
            gcKlient.OptionsColumn.AllowMove = true;
            gcKlient.OptionsColumn.ReadOnly = true;
            gcKlient.OptionsColumn.AllowEdit = false;

            /*
			gcKlient.Options = ((DevExpress.XtraGrid.Columns.ColumnOptions)(((((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered | DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved)
				| DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped)
				| DevExpress.XtraGrid.Columns.ColumnOptions.CanResized)
				| DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted)
				| DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly)
				| DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused)
				| DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
				| DevExpress.XtraGrid.Columns.ColumnOptions.NonEditable)));
            */
            //gcKlient.StyleName = "StyleNear";
            gcKlient.AppearanceCell.Options.UseTextOptions = true;
            gcKlient.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;

            gvSequenzen.Columns.Add(gcKlient);

            string sql = "";
            foreach (System.Data.DataRow row in qry.DataTable.Rows)
            {
                if (sql != "")
                    sql += ",";

                DevExpress.XtraGrid.Columns.GridColumn gc = new DevExpress.XtraGrid.Columns.GridColumn();
                gc.Caption = row["Code"].ToString() + "   " + row["Text"].ToString();
                gc.Name = "Code" + row["Code"].ToString();
                gc.FieldName = gc.Name;
                gc.VisibleIndex = Convert.ToInt32(row["Code"]) + 1;
                gc.ColumnEdit = repItemKaPraesenzCode;
                gc.Width = 35;

                gvSequenzen.Columns.Add(gc);

                sql += string.Format(@"[Code{0}] = CONVERT(int, (SELECT PraesenzCode FROM KaSequenzen WHERE BaPersonID = PRS.BaPersonID AND SequenzCode = {0}))", row["Code"]);
            }

            string sqlAll = @"SELECT PRS.BaPersonID,
					Klient = PRS.Name + isnull(', ' + PRS.Vorname,''),
					{0}
					FROM BaPerson PRS
					WHERE	PRS.BaPersonID in (SELECT FAL.BaPersonID
												FROM   FaLeistung FAL
												WHERE  FAL.ModulID = 7
												AND	   FAL.FaProzessCode = 704
												AND    FAL.DatumBis IS NULL
                                                AND    FAL.KaEpqJob = 0) -- Nur Jobtimum!
					AND		(PRS.PersonSichtbarSDFlag = {1} or PRS.PersonSichtbarSDFlag = 1)";

            qrySequenzen.Fill(string.Format(sqlAll, sql, Session.User.IsUserKA ? 0 : 1));

            qryWerteliste.Fill(@"
				SELECT *, Filter = Convert(bit, IsNull(Value3, 0))
				FROM XLOVCode
				WHERE LOVName = 'KaJobSequenzen'
				ORDER BY CODE
			");

            lblRowCount.Text = (qrySequenzen.Count).ToString();
            grdSequenzen.Focus();
            Cursor.Current = Cursors.Default;
        }

        private void FrmKaSequenzen_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            this.ctlGotoFall.CtlGotoFall_KeyDown(sender, e);
        }

        private void FrmKaSequenzen_Load(object sender, System.EventArgs e)
        {
            FillData();
            SetEditMode();
        }

        private void gvSequenzen_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (grdWerteliste.IsFocused)
                return;

            e.Appearance.Options.Reset();
            e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default;

            if (e.Column.Name.Equals("colKlient") || !DBUtil.UserHasRight("FrmKaSequenzen", "U"))
            {
                //e.CellStyle = this.grdSequenzen.Styles["ReadOnly"];
                e.Appearance.BackColor = KaUtil.ColReadOnly;
            }
            else
            {
                //e.CellStyle = this.grdSequenzen.Styles["Normal"];
                e.Appearance.BackColor = KaUtil.ColNormal;
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            }
        }

        private void qrySequenzen_BeforePost(object sender, System.EventArgs e)
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn col in grdSequenzen.View.Columns)
            {
                if (!col.Name.Equals("colKlient"))
                    UpdateColSequenz(col.Name);
            }

            qrySequenzen.Row.AcceptChanges();
            qrySequenzen.RowModified = false;
        }

        # region "Helper"

        private void qrySequenzen_PositionChanged(object sender, System.EventArgs e)
        {
            this.ctlGotoFall.BaPersonID = qrySequenzen["BaPersonID"];
        }

        private void qryWerteliste_BeforePost(object sender, EventArgs e)
        {
            if ((bool)qryWerteliste["Filter"])
            {
                qryWerteliste["Value3"] = 1;
            }
            else
            {
                qryWerteliste["Value3"] = 0;
            }
        }

        private void SetEditMode()
        {
            qrySequenzen.CanUpdate = DBUtil.UserHasRight("FrmKaSequenzen", "U");
            qryWerteliste.CanUpdate = DBUtil.UserHasRight("FrmKaSequenzen", "U");
            qryWerteliste.CanInsert = DBUtil.UserHasRight("FrmKaSequenzen", "I");

            btnNewValue.Enabled = DBUtil.UserHasRight("FrmKaSequenzen", "I");
            btnRefreshSeq.Enabled = DBUtil.UserHasRight("FrmKaSequenzen", "UI");
        }

        private void UpdateColSequenz(string colName)
        {
            if (qrySequenzen.ColumnModified(colName))
            {
                int sequenzCode = Convert.ToInt32(colName.Remove(0, 4));
                int cnt = 0;

                try
                {
                    cnt = Convert.ToInt32(DBUtil.ExecuteScalarSQL(@"select count(*) from KaSequenzen
						where	BaPersonID = {0}
						and		SequenzCode = {1}",
                        qrySequenzen.Row["BaPersonID"],
                        sequenzCode));

                    if (cnt > 0)
                    {
                        DBUtil.ExecSQL(@"
								update KaSequenzen
								set    PraesenzCode = {0}
								where  BaPersonID = {1}
								and	   SequenzCode = {2}",
                            qrySequenzen.Row[colName],
                            qrySequenzen.Row["BaPersonID"],
                            sequenzCode);
                    }
                    else
                    {
                        DBUtil.ExecSQL(@"
								insert into KaSequenzen
								(BaPersonID, SequenzCode, PraesenzCode, SichtbarSDFlag)
								values
								({0}, {1}, {2}, {3})",
                            qrySequenzen.Row["BaPersonID"],
                            sequenzCode,
                            qrySequenzen.Row[colName],
                            KaUtil.GetSichtbarSDFlag(Convert.ToInt32(qrySequenzen["BaPersonID"])));
                    }
                }
                catch { }
            }
        }

        # endregion
    }
}