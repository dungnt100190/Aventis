namespace KiSS4.Common
{
    partial class DlgAuswahl
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.edtFilter = new KiSS4.Gui.KissTextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(387, 337);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(285, 337);
            // 
            // lblCount
            // 
            this.lblCount.Location = new System.Drawing.Point(9, 337);
            this.lblCount.Size = new System.Drawing.Size(270, 24);
            // 
            // edtFilter
            // 
            this.edtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilter.EditValue = "";
            this.edtFilter.Location = new System.Drawing.Point(9, 338);
            this.edtFilter.Name = "edtFilter";
            this.edtFilter.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilter.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilter.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilter.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilter.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilter.Properties.Appearance.Options.UseFont = true;
            this.edtFilter.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilter.Size = new System.Drawing.Size(250, 24);
            this.edtFilter.TabIndex = 7;
            this.edtFilter.TextChanged += new System.EventHandler(this.edtFilter_TextChanged);
            // 
            // grd
            // 
            this.grd.DataSource = this.qry;
            // 
            // 
            // 
            this.grd.EmbeddedNavigator.Name = "";
            this.grd.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.grd.Size = new System.Drawing.Size(474, 322);
            // 
            // grv
            // 
            this.grv.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grv.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.Empty.Options.UseBackColor = true;
            this.grv.Appearance.Empty.Options.UseFont = true;
            this.grv.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grv.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.EvenRow.Options.UseBackColor = true;
            this.grv.Appearance.EvenRow.Options.UseFont = true;
            this.grv.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grv.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grv.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grv.Appearance.FocusedCell.Options.UseFont = true;
            this.grv.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grv.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grv.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grv.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grv.Appearance.FocusedRow.Options.UseFont = true;
            this.grv.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grv.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grv.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grv.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grv.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grv.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grv.Appearance.GroupRow.Options.UseBackColor = true;
            this.grv.Appearance.GroupRow.Options.UseFont = true;
            this.grv.Appearance.GroupRow.Options.UseForeColor = true;
            this.grv.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grv.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grv.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grv.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grv.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grv.Appearance.HeaderPanel.Options.UseFont = true;
            this.grv.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grv.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grv.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grv.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grv.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grv.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grv.Appearance.HorzLine.Options.UseBackColor = true;
            this.grv.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(222)))));
            this.grv.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.OddRow.Options.UseBackColor = true;
            this.grv.Appearance.OddRow.Options.UseFont = true;
            this.grv.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grv.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.Row.Options.UseBackColor = true;
            this.grv.Appearance.Row.Options.UseFont = true;
            this.grv.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(170)))), ((int)(((byte)(74)))));
            this.grv.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grv.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grv.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grv.Appearance.SelectedRow.Options.UseFont = true;
            this.grv.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grv.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grv.Appearance.VertLine.Options.UseBackColor = true;
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsCustomization.AllowGroup = false;
            this.grv.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grv.OptionsMenu.EnableFooterMenu = false;
            this.grv.OptionsMenu.EnableGroupPanelMenu = false;
            this.grv.OptionsNavigation.AutoFocusNewRow = true;
            this.grv.OptionsNavigation.EnterMoveNextColumn = true;
            this.grv.OptionsNavigation.UseTabKey = false;
            this.grv.OptionsPrint.AutoWidth = false;
            this.grv.OptionsPrint.UsePrintStyles = true;
            this.grv.OptionsView.ColumnAutoWidth = false;
            this.grv.OptionsView.ShowDetailButtons = false;
            this.grv.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grv.OptionsView.ShowGroupPanel = false;
            this.grv.OptionsView.ShowIndicator = false;
            // 
            // DlgAuswahl
            // 
            this.ClientSize = new System.Drawing.Size(492, 369);
            this.Controls.Add(this.edtFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "DlgAuswahl";
            this.Controls.SetChildIndex(this.edtFilter, 0);
            this.Controls.SetChildIndex(this.btnOK, 0);
            this.Controls.SetChildIndex(this.btnCancel, 0);
            this.Controls.SetChildIndex(this.lblCount, 0);
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilter.Properties)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private Gui.KissTextEdit edtFilter;

    }
}