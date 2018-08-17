namespace KiSS4.Gui
{
    partial class KissLookupDialog
    {
        #region Dispose

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
            this.btnOK = new KiSS4.Gui.KissButton();
            this.btnCancel = new KiSS4.Gui.KissButton();
            this.grd = new KiSS4.Gui.KissGrid();
            this.grv = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblCount = new KiSS4.Gui.KissLabel();
            ((System.ComponentModel.ISupportInitialize)(this.qry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).BeginInit();
            this.SuspendLayout();
            //
            // qry
            //
            this.qry.HostControl = this;
            this.qry.AfterFill += new System.EventHandler(this.qry_AfterFill);
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(287, 338);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            //
            // btnCancel
            //
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(389, 338);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 2, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Abbruch";
            this.btnCancel.UseVisualStyleBackColor = false;
            //
            // grd
            //
            this.grd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            //
            //
            //
            this.grd.EmbeddedNavigator.Name = "";
            this.grd.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grd.ImeMode = System.Windows.Forms.ImeMode.On;
            this.grd.Location = new System.Drawing.Point(9, 9);
            this.grd.MainView = this.grv;
            this.grd.Margin = new System.Windows.Forms.Padding(3, 3, 1, 3);
            this.grd.Name = "grd";
            this.grd.Size = new System.Drawing.Size(476, 323);
            this.grd.TabIndex = 0;
            this.grd.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grv});
            this.grd.DoubleClick += new System.EventHandler(this.grd_DoubleClick);
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
            this.grv.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grv.GridControl = this.grd;
            this.grv.Name = "grv";
            this.grv.OptionsBehavior.Editable = false;
            this.grv.OptionsCustomization.AllowFilter = false;
            this.grv.OptionsCustomization.AllowGroup = false;
            this.grv.OptionsFilter.UseNewCustomFilterDialog = true;
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
            // lblCount
            //
            this.lblCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCount.Location = new System.Drawing.Point(9, 338);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(272, 24);
            this.lblCount.TabIndex = 1;
            this.lblCount.Text = "Anzahl Datensätze: {0}";
            //
            // KissLookupDialog
            //
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(494, 371);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.grd);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "KissLookupDialog";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Auswahl";
            ((System.ComponentModel.ISupportInitialize)(this.qry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCount)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.IContainer components;
        protected KissButton btnCancel;
        protected KissButton btnOK;
        protected KissGrid grd;
        protected DevExpress.XtraGrid.Views.Grid.GridView grv;
        protected KissLabel lblCount;
        protected KiSS4.DB.SqlQuery qry;
    }
}
