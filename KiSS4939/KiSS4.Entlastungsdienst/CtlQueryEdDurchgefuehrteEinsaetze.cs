
namespace KiSS4.Entlastungsdienst
{
    public class CtlQueryEdDurchgefuehrteEinsaetze : Common.KissQueryControl
    {
        #region Fields

        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private DevExpress.XtraGrid.Views.Grid.GridView grvQuery;

        #endregion

        #region Constructors

        public CtlQueryEdDurchgefuehrteEinsaetze()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlQueryEdDurchgefuehrteEinsaetze));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.grvQuery = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).BeginInit();
            this.tabControlSearch.SuspendLayout();
            this.tpgListe.SuspendLayout();
            this.tpgSuchen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            //
            // grdQuery1
            //
            this.grdQuery1.EmbeddedNavigator.Name = "";
            this.grdQuery1.MainView = this.gridView;
            this.grdQuery1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
                        this.grvQuery,
                        this.gridView});
            //
            // xDocument
            //
            this.xDocument.DataMember = null;
            this.xDocument.EditValue = null;
            this.xDocument.Location = new System.Drawing.Point(187, 398);
            this.xDocument.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.xDocument.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.xDocument.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.xDocument.Properties.Appearance.Options.UseBackColor = true;
            this.xDocument.Properties.Appearance.Options.UseBorderColor = true;
            this.xDocument.Properties.Appearance.Options.UseFont = true;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.Bisque;
            serializableAppearanceObject1.Options.UseBackColor = true;
            this.xDocument.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, false, false, DevExpress.Utils.HorzAlignment.Center, ((System.Drawing.Image)(resources.GetObject("xDocument.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "Dokument öffnen")});
            this.xDocument.Visible = false;
            //
            // ctlGotoFall
            //
            this.ctlGotoFall.DataMember = null;
            this.ctlGotoFall.Size = new System.Drawing.Size(178, 24);
            //
            // tpgListe
            //
            this.tpgListe.Location = new System.Drawing.Point(6, 6);
            //
            // tpgSuchen
            //
            this.tpgSuchen.Location = new System.Drawing.Point(6, 6);
            //
            // grvQuery
            //
            this.grvQuery.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvQuery.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.Empty.Options.UseBackColor = true;
            this.grvQuery.Appearance.Empty.Options.UseFont = true;
            this.grvQuery.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvQuery.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.EvenRow.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvQuery.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvQuery.Appearance.FocusedCell.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvQuery.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvQuery.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvQuery.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.FocusedRow.Options.UseFont = true;
            this.grvQuery.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvQuery.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvQuery.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.GroupRow.Options.UseFont = true;
            this.grvQuery.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvQuery.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvQuery.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvQuery.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvQuery.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvQuery.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvQuery.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvQuery.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvQuery.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grvQuery.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.OddRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.OddRow.Options.UseFont = true;
            this.grvQuery.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvQuery.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.Row.Options.UseBackColor = true;
            this.grvQuery.Appearance.Row.Options.UseFont = true;
            this.grvQuery.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grvQuery.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvQuery.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvQuery.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvQuery.Appearance.SelectedRow.Options.UseFont = true;
            this.grvQuery.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvQuery.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvQuery.Appearance.VertLine.Options.UseBackColor = true;
            this.grvQuery.GridControl = this.grdQuery1;
            this.grvQuery.Name = "grvQuery";
            this.grvQuery.OptionsBehavior.Editable = false;
            this.grvQuery.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvQuery.OptionsNavigation.AutoFocusNewRow = true;
            this.grvQuery.OptionsNavigation.UseTabKey = false;
            this.grvQuery.OptionsPrint.AutoWidth = false;
            this.grvQuery.OptionsPrint.ExpandAllDetails = true;
            this.grvQuery.OptionsPrint.UsePrintStyles = true;
            this.grvQuery.OptionsView.ColumnAutoWidth = false;
            this.grvQuery.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvQuery.OptionsView.ShowGroupPanel = false;
            this.grvQuery.OptionsView.ShowIndicator = false;
            //
            // gridView
            //
            this.gridView.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.Empty.Options.UseBackColor = true;
            this.gridView.Appearance.Empty.Options.UseFont = true;
            this.gridView.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.EvenRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView.Appearance.GroupRow.Options.UseFont = true;
            this.gridView.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.OddRow.Options.UseFont = true;
            this.gridView.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.Row.Options.UseBackColor = true;
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView.GridControl = this.grdQuery1;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView.OptionsNavigation.UseTabKey = false;
            this.gridView.OptionsView.ColumnAutoWidth = false;
            this.gridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.OptionsView.ShowIndicator = false;
            //
            // CtlQueryEdDurchgefuehrteEinsaetze
            //
            this.Name = "CtlQueryEdDurchgefuehrteEinsaetze";
            ((System.ComponentModel.ISupportInitialize)(this.qryQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQuery1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xDocument.Properties)).EndInit();
            this.tabControlSearch.ResumeLayout(false);
            this.tpgListe.ResumeLayout(false);
            this.tpgSuchen.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grvQuery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}