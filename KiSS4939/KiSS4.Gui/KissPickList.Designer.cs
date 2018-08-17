namespace KiSS4.Gui
{
    partial class KissPickList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lpnLayoutRoot = new System.Windows.Forms.TableLayoutPanel();
            this.panPickerButton = new System.Windows.Forms.Panel();
            this.btnSelectAll = new KiSS4.Gui.KissButton();
            this.btnSelect = new KiSS4.Gui.KissButton();
            this.btnUnselect = new KiSS4.Gui.KissButton();
            this.btnUnselectAll = new KiSS4.Gui.KissButton();
            this.panSource = new System.Windows.Forms.Panel();
            this.grdSource = new KiSS4.Gui.KissGrid();
            this.grvSource = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panFilterSource = new System.Windows.Forms.Panel();
            this.lblFilterSource = new KiSS4.Gui.KissLabel();
            this.edtFilterSource = new KiSS4.Gui.KissTextEdit();
            this.panTarget = new System.Windows.Forms.Panel();
            this.grdTarget = new KiSS4.Gui.KissGrid();
            this.grvTarget = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panFilterTarget = new System.Windows.Forms.Panel();
            this.lblFilterTarget = new KiSS4.Gui.KissLabel();
            this.edtFilterTarget = new KiSS4.Gui.KissTextEdit();
            this.lpnLayoutRoot.SuspendLayout();
            this.panPickerButton.SuspendLayout();
            this.panSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).BeginInit();
            this.panFilterSource.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterSource.Properties)).BeginInit();
            this.panTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTarget)).BeginInit();
            this.panFilterTarget.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterTarget)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterTarget.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lpnLayoutRoot
            // 
            this.lpnLayoutRoot.ColumnCount = 3;
            this.lpnLayoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lpnLayoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.lpnLayoutRoot.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.lpnLayoutRoot.Controls.Add(this.panPickerButton, 1, 0);
            this.lpnLayoutRoot.Controls.Add(this.panSource, 0, 0);
            this.lpnLayoutRoot.Controls.Add(this.panTarget, 2, 0);
            this.lpnLayoutRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lpnLayoutRoot.Location = new System.Drawing.Point(0, 0);
            this.lpnLayoutRoot.Name = "lpnLayoutRoot";
            this.lpnLayoutRoot.RowCount = 1;
            this.lpnLayoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.lpnLayoutRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.lpnLayoutRoot.Size = new System.Drawing.Size(728, 268);
            this.lpnLayoutRoot.TabIndex = 1;
            // 
            // panPickerButton
            // 
            this.panPickerButton.Controls.Add(this.btnSelectAll);
            this.panPickerButton.Controls.Add(this.btnSelect);
            this.panPickerButton.Controls.Add(this.btnUnselect);
            this.panPickerButton.Controls.Add(this.btnUnselectAll);
            this.panPickerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panPickerButton.Location = new System.Drawing.Point(335, 0);
            this.panPickerButton.Margin = new System.Windows.Forms.Padding(0);
            this.panPickerButton.Name = "panPickerButton";
            this.panPickerButton.Size = new System.Drawing.Size(58, 268);
            this.panPickerButton.TabIndex = 2;
            this.panPickerButton.TabStop = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Enabled = false;
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.IconID = 14;
            this.btnSelectAll.Location = new System.Drawing.Point(16, 90);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(28, 24);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.UseCompatibleTextRendering = true;
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Visible = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Enabled = false;
            this.btnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelect.IconID = 13;
            this.btnSelect.Location = new System.Drawing.Point(16, 30);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(10, 30, 10, 3);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(28, 24);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.UseCompatibleTextRendering = true;
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnUnselect
            // 
            this.btnUnselect.Enabled = false;
            this.btnUnselect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnselect.IconID = 11;
            this.btnUnselect.Location = new System.Drawing.Point(16, 60);
            this.btnUnselect.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnUnselect.Name = "btnUnselect";
            this.btnUnselect.Size = new System.Drawing.Size(28, 24);
            this.btnUnselect.TabIndex = 1;
            this.btnUnselect.UseCompatibleTextRendering = true;
            this.btnUnselect.UseVisualStyleBackColor = false;
            this.btnUnselect.Click += new System.EventHandler(this.btnUnselect_Click);
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Enabled = false;
            this.btnUnselectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnselectAll.IconID = 12;
            this.btnUnselectAll.Location = new System.Drawing.Point(16, 120);
            this.btnUnselectAll.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(28, 24);
            this.btnUnselectAll.TabIndex = 2;
            this.btnUnselectAll.UseCompatibleTextRendering = true;
            this.btnUnselectAll.UseVisualStyleBackColor = false;
            this.btnUnselectAll.Visible = false;
            this.btnUnselectAll.Click += new System.EventHandler(this.btnUnselectAll_Click);
            // 
            // panSource
            // 
            this.panSource.Controls.Add(this.grdSource);
            this.panSource.Controls.Add(this.panFilterSource);
            this.panSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panSource.Location = new System.Drawing.Point(3, 3);
            this.panSource.Name = "panSource";
            this.panSource.Size = new System.Drawing.Size(329, 262);
            this.panSource.TabIndex = 1;
            this.panSource.TabStop = true;
            // 
            // grdSource
            // 
            this.grdSource.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdSource.EmbeddedNavigator.Name = "";
            this.grdSource.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdSource.Location = new System.Drawing.Point(0, 0);
            this.grdSource.MainView = this.grvSource;
            this.grdSource.Margin = new System.Windows.Forms.Padding(4);
            this.grdSource.Name = "grdSource";
            this.grdSource.Size = new System.Drawing.Size(329, 228);
            this.grdSource.TabIndex = 0;
            this.grdSource.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSource});
            this.grdSource.Load += new System.EventHandler(this.grdSource_Load);
            this.grdSource.DoubleClick += new System.EventHandler(this.btnSelect_Click);
            // 
            // grvSource
            // 
            this.grvSource.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvSource.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSource.Appearance.Empty.Options.UseBackColor = true;
            this.grvSource.Appearance.Empty.Options.UseFont = true;
            this.grvSource.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSource.Appearance.EvenRow.Options.UseFont = true;
            this.grvSource.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSource.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSource.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvSource.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvSource.Appearance.FocusedCell.Options.UseFont = true;
            this.grvSource.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvSource.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvSource.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSource.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvSource.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvSource.Appearance.FocusedRow.Options.UseFont = true;
            this.grvSource.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvSource.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSource.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvSource.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvSource.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSource.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSource.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvSource.Appearance.GroupRow.Options.UseFont = true;
            this.grvSource.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvSource.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvSource.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvSource.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvSource.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSource.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvSource.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvSource.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvSource.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSource.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvSource.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvSource.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvSource.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvSource.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvSource.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvSource.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSource.Appearance.OddRow.Options.UseFont = true;
            this.grvSource.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvSource.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSource.Appearance.Row.Options.UseBackColor = true;
            this.grvSource.Appearance.Row.Options.UseFont = true;
            this.grvSource.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvSource.Appearance.SelectedRow.Options.UseFont = true;
            this.grvSource.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvSource.Appearance.VertLine.Options.UseBackColor = true;
            this.grvSource.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvSource.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvSource.GridControl = this.grdSource;
            this.grvSource.Name = "grvSource";
            this.grvSource.OptionsBehavior.Editable = false;
            this.grvSource.OptionsCustomization.AllowFilter = false;
            this.grvSource.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvSource.OptionsNavigation.AutoFocusNewRow = true;
            this.grvSource.OptionsNavigation.UseTabKey = false;
            this.grvSource.OptionsSelection.MultiSelect = true;
            this.grvSource.OptionsView.ColumnAutoWidth = false;
            this.grvSource.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvSource.OptionsView.ShowGroupPanel = false;
            this.grvSource.OptionsView.ShowIndicator = false;
            // 
            // panFilterSource
            // 
            this.panFilterSource.Controls.Add(this.lblFilterSource);
            this.panFilterSource.Controls.Add(this.edtFilterSource);
            this.panFilterSource.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panFilterSource.Location = new System.Drawing.Point(0, 228);
            this.panFilterSource.Name = "panFilterSource";
            this.panFilterSource.Size = new System.Drawing.Size(329, 34);
            this.panFilterSource.TabIndex = 1;
            // 
            // lblFilterSource
            // 
            this.lblFilterSource.Location = new System.Drawing.Point(3, 8);
            this.lblFilterSource.Name = "lblFilterSource";
            this.lblFilterSource.Size = new System.Drawing.Size(54, 24);
            this.lblFilterSource.TabIndex = 0;
            this.lblFilterSource.Text = "Filter";
            this.lblFilterSource.UseCompatibleTextRendering = true;
            // 
            // edtFilterSource
            // 
            this.edtFilterSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilterSource.Location = new System.Drawing.Point(60, 8);
            this.edtFilterSource.Name = "edtFilterSource";
            this.edtFilterSource.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterSource.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterSource.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterSource.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterSource.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterSource.Properties.Appearance.Options.UseFont = true;
            this.edtFilterSource.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterSource.Size = new System.Drawing.Size(269, 24);
            this.edtFilterSource.TabIndex = 1;
            this.edtFilterSource.EditValueChanged += new System.EventHandler(this.edtFilterSource_EditValueChanged);
            // 
            // panTarget
            // 
            this.panTarget.Controls.Add(this.grdTarget);
            this.panTarget.Controls.Add(this.panFilterTarget);
            this.panTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panTarget.Location = new System.Drawing.Point(396, 3);
            this.panTarget.Name = "panTarget";
            this.panTarget.Size = new System.Drawing.Size(329, 262);
            this.panTarget.TabIndex = 4;
            // 
            // grdTarget
            // 
            this.grdTarget.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.grdTarget.EmbeddedNavigator.Name = "";
            this.grdTarget.GridStyle = KiSS4.Gui.GridStyleType.ReadOnly;
            this.grdTarget.Location = new System.Drawing.Point(0, 0);
            this.grdTarget.MainView = this.grvTarget;
            this.grdTarget.Margin = new System.Windows.Forms.Padding(4);
            this.grdTarget.Name = "grdTarget";
            this.grdTarget.Size = new System.Drawing.Size(329, 228);
            this.grdTarget.TabIndex = 3;
            this.grdTarget.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTarget});
            this.grdTarget.Load += new System.EventHandler(this.grdTarget_Load);
            this.grdTarget.DoubleClick += new System.EventHandler(this.btnUnselect_Click);
            // 
            // grvTarget
            // 
            this.grvTarget.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.grvTarget.Appearance.Empty.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTarget.Appearance.Empty.Options.UseBackColor = true;
            this.grvTarget.Appearance.Empty.Options.UseFont = true;
            this.grvTarget.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.grvTarget.Appearance.EvenRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTarget.Appearance.EvenRow.Options.UseBackColor = true;
            this.grvTarget.Appearance.EvenRow.Options.UseFont = true;
            this.grvTarget.Appearance.FocusedCell.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvTarget.Appearance.FocusedCell.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTarget.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.grvTarget.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvTarget.Appearance.FocusedCell.Options.UseFont = true;
            this.grvTarget.Appearance.FocusedCell.Options.UseForeColor = true;
            this.grvTarget.Appearance.FocusedRow.BackColor = System.Drawing.SystemColors.Highlight;
            this.grvTarget.Appearance.FocusedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTarget.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.grvTarget.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvTarget.Appearance.FocusedRow.Options.UseFont = true;
            this.grvTarget.Appearance.FocusedRow.Options.UseForeColor = true;
            this.grvTarget.Appearance.GroupPanel.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTarget.Appearance.GroupPanel.Options.UseBackColor = true;
            this.grvTarget.Appearance.GroupRow.BackColor = System.Drawing.Color.PeachPuff;
            this.grvTarget.Appearance.GroupRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvTarget.Appearance.GroupRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTarget.Appearance.GroupRow.Options.UseBackColor = true;
            this.grvTarget.Appearance.GroupRow.Options.UseFont = true;
            this.grvTarget.Appearance.GroupRow.Options.UseForeColor = true;
            this.grvTarget.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.grvTarget.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.Tan;
            this.grvTarget.Appearance.HeaderPanel.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.grvTarget.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvTarget.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvTarget.Appearance.HeaderPanel.Options.UseFont = true;
            this.grvTarget.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.grvTarget.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTarget.Appearance.HideSelectionRow.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grvTarget.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvTarget.Appearance.HideSelectionRow.Options.UseFont = true;
            this.grvTarget.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.grvTarget.Appearance.HorzLine.BackColor = System.Drawing.Color.Silver;
            this.grvTarget.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvTarget.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTarget.Appearance.OddRow.Options.UseFont = true;
            this.grvTarget.Appearance.Row.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grvTarget.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTarget.Appearance.Row.Options.UseBackColor = true;
            this.grvTarget.Appearance.Row.Options.UseFont = true;
            this.grvTarget.Appearance.SelectedRow.BackColor = System.Drawing.Color.AliceBlue;
            this.grvTarget.Appearance.SelectedRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.grvTarget.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Black;
            this.grvTarget.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvTarget.Appearance.SelectedRow.Options.UseFont = true;
            this.grvTarget.Appearance.SelectedRow.Options.UseForeColor = true;
            this.grvTarget.Appearance.VertLine.BackColor = System.Drawing.Color.Silver;
            this.grvTarget.Appearance.VertLine.Options.UseBackColor = true;
            this.grvTarget.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.grvTarget.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            this.grvTarget.GridControl = this.grdTarget;
            this.grvTarget.Name = "grvTarget";
            this.grvTarget.OptionsBehavior.Editable = false;
            this.grvTarget.OptionsCustomization.AllowFilter = false;
            this.grvTarget.OptionsFilter.UseNewCustomFilterDialog = true;
            this.grvTarget.OptionsNavigation.AutoFocusNewRow = true;
            this.grvTarget.OptionsNavigation.UseTabKey = false;
            this.grvTarget.OptionsView.ColumnAutoWidth = false;
            this.grvTarget.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvTarget.OptionsView.ShowGroupPanel = false;
            this.grvTarget.OptionsView.ShowIndicator = false;
            // 
            // panFilterTarget
            // 
            this.panFilterTarget.Controls.Add(this.lblFilterTarget);
            this.panFilterTarget.Controls.Add(this.edtFilterTarget);
            this.panFilterTarget.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panFilterTarget.Location = new System.Drawing.Point(0, 228);
            this.panFilterTarget.Name = "panFilterTarget";
            this.panFilterTarget.Size = new System.Drawing.Size(329, 34);
            this.panFilterTarget.TabIndex = 4;
            this.panFilterTarget.Visible = false;
            // 
            // lblFilterTarget
            // 
            this.lblFilterTarget.Location = new System.Drawing.Point(3, 8);
            this.lblFilterTarget.Name = "lblFilterTarget";
            this.lblFilterTarget.Size = new System.Drawing.Size(54, 24);
            this.lblFilterTarget.TabIndex = 0;
            this.lblFilterTarget.Text = "Filter";
            this.lblFilterTarget.UseCompatibleTextRendering = true;
            // 
            // edtFilterTarget
            // 
            this.edtFilterTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.edtFilterTarget.Location = new System.Drawing.Point(60, 8);
            this.edtFilterTarget.Name = "edtFilterTarget";
            this.edtFilterTarget.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtFilterTarget.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
            this.edtFilterTarget.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtFilterTarget.Properties.Appearance.Options.UseBackColor = true;
            this.edtFilterTarget.Properties.Appearance.Options.UseBorderColor = true;
            this.edtFilterTarget.Properties.Appearance.Options.UseFont = true;
            this.edtFilterTarget.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.edtFilterTarget.Size = new System.Drawing.Size(269, 24);
            this.edtFilterTarget.TabIndex = 1;
            this.edtFilterTarget.EditValueChanged += new System.EventHandler(this.edtFilterTarget_EditValueChanged);
            // 
            // KissPickList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lpnLayoutRoot);
            this.Name = "KissPickList";
            this.Size = new System.Drawing.Size(728, 268);
            this.lpnLayoutRoot.ResumeLayout(false);
            this.panPickerButton.ResumeLayout(false);
            this.panSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSource)).EndInit();
            this.panFilterSource.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterSource.Properties)).EndInit();
            this.panTarget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTarget)).EndInit();
            this.panFilterTarget.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lblFilterTarget)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtFilterTarget.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

 
      
        private System.Windows.Forms.TableLayoutPanel lpnLayoutRoot;
        private System.Windows.Forms.Panel panSource;
        private KissGrid grdSource;
        private DevExpress.XtraGrid.Views.Grid.GridView grvSource;
        private System.Windows.Forms.Panel panFilterSource;
        private KissLabel lblFilterSource;
        private KissTextEdit edtFilterSource;
        private KissGrid grdTarget;
        private DevExpress.XtraGrid.Views.Grid.GridView grvTarget;
        private System.Windows.Forms.Panel panPickerButton;
        private KissButton btnSelect;
        private KissButton btnUnselect;
        private KissButton btnUnselectAll;
        private System.Windows.Forms.Panel panTarget;
        private System.Windows.Forms.Panel panFilterTarget;
        private KissLabel lblFilterTarget;
        private KissTextEdit edtFilterTarget;
        private KissButton btnSelectAll;
    }
}
