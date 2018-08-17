namespace KiSS4.Gui
{
    partial class DlgSelectTranslation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            this.components = new System.ComponentModel.Container();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.btnOk = new KiSS4.Gui.KissButton();
            this.lblSelectControl = new KiSS4.Gui.KissLabel();
            this.grdControls = new KiSS4.Gui.KissGrid();
            this.grvControls = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colControl = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControls)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvControls)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(371, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Abbrechen";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(275, 234);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(90, 24);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lblSelectControl
            // 
            this.lblSelectControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectControl.LabelStyle = KiSS4.Gui.LabelStyleType.DataView;
            this.lblSelectControl.Location = new System.Drawing.Point(12, 9);
            this.lblSelectControl.Name = "lblSelectControl";
            this.lblSelectControl.Size = new System.Drawing.Size(449, 16);
            this.lblSelectControl.TabIndex = 0;
            this.lblSelectControl.Text = "Maske zum Übersetzen auswählen:";
            // 
            // grdControls
            // 
            this.grdControls.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.grdControls.EmbeddedNavigator.Name = "";
            this.grdControls.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdControls.Location = new System.Drawing.Point(12, 31);
            this.grdControls.MainView = this.grvControls;
            this.grdControls.Name = "grdControls";
            this.grdControls.Size = new System.Drawing.Size(449, 196);
            this.grdControls.TabIndex = 1;
            this.grdControls.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvControls});
            this.grdControls.DoubleClick += new System.EventHandler(this.grdControls_DoubleClick);
            // 
            // grvControls
            // 
            this.grvControls.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvControls.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControls.Appearance.Empty.Options.UseBackColor = true;
            this.grvControls.Appearance.Empty.Options.UseFont = true;
            this.grvControls.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControls.Appearance.EvenRow.Options.UseFont = true;
            this.grvControls.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvControls.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControls.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvControls.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvControls.Appearance.FocusedCell.Options.UseFont = true;
            this.grvControls.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvControls.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvControls.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControls.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvControls.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvControls.Appearance.FocusedRow.Options.UseFont = true;
            this.grvControls.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvControls.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvControls.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvControls.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvControls.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvControls.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvControls.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvControls.Appearance.GroupRow.Options.UseFont = true;
            this.grvControls.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvControls.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvControls.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvControls.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvControls.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvControls.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvControls.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvControls.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvControls.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControls.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvControls.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvControls.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvControls.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvControls.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvControls.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvControls.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControls.Appearance.OddRow.Options.UseFont = true;
            this.grvControls.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvControls.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControls.Appearance.Row.Options.UseBackColor = true;
            this.grvControls.Appearance.Row.Options.UseFont = true;
            this.grvControls.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvControls.Appearance.SelectedRow.Options.UseFont = true;
            this.grvControls.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvControls.Appearance.VertLine.Options.UseBackColor = true;
            this.grvControls.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvControls.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colType,
            this.colControl});
            this.grvControls.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvControls.GridControl = this.grdControls;
            this.grvControls.Name = "grvControls";
            this.grvControls.OptionsBehavior.Editable = false;
            this.grvControls.OptionsCustomization.AllowFilter = false;
            this.grvControls.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvControls.OptionsNavigation.AutoFocusNewRow = true;
            this.grvControls.OptionsNavigation.UseTabKey = false;
            this.grvControls.OptionsView.ColumnAutoWidth = false;
            this.grvControls.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvControls.OptionsView.ShowGroupPanel = false;
            this.grvControls.OptionsView.ShowIndicator = false;
            // 
            // colType
            // 
            this.colType.Caption = "Typ";
            this.colType.Name = "colType";
            this.colType.Visible = true;
            this.colType.VisibleIndex = 0;
            this.colType.Width = 128;
            // 
            // colControl
            // 
            this.colControl.Caption = "Maske";
            this.colControl.Name = "colControl";
            this.colControl.Visible = true;
            this.colControl.VisibleIndex = 1;
            this.colControl.Width = 284;
            // 
            // DlgSelectTranslation
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(473, 266);
            this.Controls.Add(this.grdControls);
            this.Controls.Add(this.lblSelectControl);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Name = "DlgSelectTranslation";
            this.Text = "Maske wählen";
            ((System.ComponentModel.ISupportInitialize)(this.lblSelectControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControls)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvControls)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KissButton btnCancel;
        private KissButton btnOk;
        private KissLabel lblSelectControl;
        private KissGrid grdControls;
        private DevExpress.XtraGrid.Views.Grid.GridView grvControls;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
        private DevExpress.XtraGrid.Columns.GridColumn colControl;
    }
}