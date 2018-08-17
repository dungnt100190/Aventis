using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Vormundschaft
{
    partial class DlgVmErbeTransfer
    {
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

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.qryVmErbe = new KiSS4.DB.SqlQuery(this.components);
            this.btnTransfer = new KiSS4.Gui.KissButton();
            this.Grid1 = new KiSS4.Gui.KissGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDienst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colErben = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // qryVmErbe
            // 
            this.qryVmErbe.CanDelete = true;
            this.qryVmErbe.CanInsert = true;
            this.qryVmErbe.CanUpdate = true;
            this.qryVmErbe.HostControl = this;
            this.qryVmErbe.TableName = "VmErbe";
            // 
            // btnTransfer
            // 
            this.btnTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Location = new System.Drawing.Point(526, 380);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(93, 24);
            this.btnTransfer.TabIndex = 1;
            this.btnTransfer.Text = "übernehmen";
            this.btnTransfer.UseVisualStyleBackColor = false;
            this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
            // 
            // Grid1
            // 
            this.Grid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid1.DataSource = this.qryVmErbe;
            this.Grid1.EmbeddedNavigator.Name = "";
            this.Grid1.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.Grid1.Location = new System.Drawing.Point(7, 8);
            this.Grid1.MainView = this.gridView1;
            this.Grid1.Name = "Grid1";
            this.Grid1.Size = new System.Drawing.Size(830, 365);
            this.Grid1.TabIndex = 0;
            this.Grid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDienst,
            this.colNr,
            this.colErben});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.gridView1.GridControl = this.Grid1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gridView1.OptionsNavigation.AutoFocusNewRow = true;
            this.gridView1.OptionsNavigation.UseTabKey = false;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // colDienst
            // 
            this.colDienst.Caption = "Dienst";
            this.colDienst.FieldName = "Dienst";
            this.colDienst.Name = "colDienst";
            this.colDienst.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colDienst.Visible = true;
            this.colDienst.VisibleIndex = 0;
            this.colDienst.Width = 123;
            // 
            // colNr
            // 
            this.colNr.Caption = "Nr";
            this.colNr.FieldName = "Nr";
            this.colNr.Name = "colNr";
            this.colNr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colNr.Visible = true;
            this.colNr.VisibleIndex = 1;
            this.colNr.Width = 90;
            // 
            // colErben
            // 
            this.colErben.Caption = "Erben";
            this.colErben.FieldName = "Text";
            this.colErben.Name = "colErben";
            this.colErben.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.colErben.Visible = true;
            this.colErben.VisibleIndex = 2;
            this.colErben.Width = 596;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(744, 380);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Location = new System.Drawing.Point(630, 380);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(103, 24);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "alle auswählen";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // DlgVmErbeTransfer
            // 
            this.AcceptButton = this.btnTransfer;
            this.ActiveSQLQuery = this.qryVmErbe;
            
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(846, 412);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Grid1);
            this.Controls.Add(this.btnTransfer);
            this.Name = "DlgVmErbeTransfer";
            this.Text = "Erben übernehmen";
            ((System.ComponentModel.ISupportInitialize)(this.qryVmErbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.ComponentModel.IContainer components;

        private KiSS4.DB.SqlQuery qryVmErbe;

        private KiSS4.Gui.KissGrid Grid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colErben;
        private DevExpress.XtraGrid.Columns.GridColumn colDienst;
        private DevExpress.XtraGrid.Columns.GridColumn colNr;

        private KiSS4.Gui.KissButton btnTransfer;
        private KiSS4.Gui.KissButton btnCancel;
        private KiSS4.Gui.KissButton btnSelectAll;
    }
}
