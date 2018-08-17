namespace KiSS4.Main
{
    /// <summary>
    /// Container to use for single person's modultree and detail controls, used in <see cref="FrmFall"/>.
    /// </summary>
    public partial class CtlFall 
    {
        #region Fields

        #region Private Fields

        private SharpLibrary.WinControls.ImageListEx imgModulIcons;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Panel panDetailControl;
        private System.Windows.Forms.Panel panPersonName;
        private System.Windows.Forms.Panel panTree;
        private System.Windows.Forms.PictureBox pbZoomIn;
        private System.Windows.Forms.PictureBox pbZoomOut;
        private System.Windows.Forms.PictureBox picIcon;
        private KiSS4.Gui.KissSplitterCollapsible splitterTreeControl;
        private KiSS4.Gui.KissTabControlEx tabModulTree;
        private SharpLibrary.WinControls.TabPageEx tpgTemplate;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtlFall));
            this.panTree = new System.Windows.Forms.Panel();
            this.btnZeitachse = new KiSS4.Gui.KissButton();
            this.tabModulTree = new KiSS4.Gui.KissTabControlEx();
            this.tpgTemplate = new SharpLibrary.WinControls.TabPageEx();
            this.imgModulIcons = new SharpLibrary.WinControls.ImageListEx();
            this.panDetailControl = new System.Windows.Forms.Panel();
            this.panPersonName = new System.Windows.Forms.Panel();
            this.pbZoomOut = new System.Windows.Forms.PictureBox();
            this.pbZoomIn = new System.Windows.Forms.PictureBox();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.splitterTreeControl = new KiSS4.Gui.KissSplitterCollapsible();
            this.panTree.SuspendLayout();
            this.tabModulTree.SuspendLayout();
            this.panPersonName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panTree
            // 
            this.panTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panTree.Controls.Add(this.btnZeitachse);
            this.panTree.Controls.Add(this.tabModulTree);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTree.Location = new System.Drawing.Point(0, 0);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(271, 481);
            this.panTree.TabIndex = 0;
            // 
            // btnZeitachse
            // 
            this.btnZeitachse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnZeitachse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZeitachse.Location = new System.Drawing.Point(228, 3);
            this.btnZeitachse.Name = "btnZeitachse";
            this.btnZeitachse.Size = new System.Drawing.Size(26, 24);
            this.btnZeitachse.TabIndex = 0;
            this.btnZeitachse.UseVisualStyleBackColor = false;
            this.btnZeitachse.Visible = false;
            this.btnZeitachse.Click += new System.EventHandler(this.btnZeitachse_Click);
            // 
            // tabModulTree
            // 
            this.tabModulTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tabModulTree.Controls.Add(this.tpgTemplate);
            this.tabModulTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabModulTree.FirstTabMargin = 3;
            this.tabModulTree.ImageList = this.imgModulIcons;
            this.tabModulTree.Location = new System.Drawing.Point(0, 0);
            this.tabModulTree.Name = "tabModulTree";
            this.tabModulTree.ShowFixedWidthTooltip = true;
            this.tabModulTree.ShowOnlySelectedTabText = true;
            this.tabModulTree.Size = new System.Drawing.Size(271, 481);
            this.tabModulTree.TabBaseColor = System.Drawing.Color.Transparent;
            this.tabModulTree.TabControlStyle = KiSS4.Gui.TabControlStyleType.ModulTree;
            this.tabModulTree.TabIndex = 0;
            this.tabModulTree.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
            this.tpgTemplate});
            this.tabModulTree.TabsAreaBackColor = System.Drawing.Color.Transparent;
            this.tabModulTree.TabsLineColor = System.Drawing.Color.Black;
            this.tabModulTree.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabModulTree.TabsStyle = SharpLibrary.WinControls.TabsStyle.CustomImages;
            this.tabModulTree.VerticalMargin = 5;
            this.tabModulTree.SelectedTabChanged += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabModulTree_SelectedTabChanged);
            this.tabModulTree.SelectedTabChanging += new System.ComponentModel.CancelEventHandler(this.tabModulTree_SelectedTabChanging);
            this.tabModulTree.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabModulTree_MouseUp);
            // 
            // tpgTemplate
            // 
            this.tpgTemplate.Location = new System.Drawing.Point(6, 34);
            this.tpgTemplate.Name = "tpgTemplate";
            this.tpgTemplate.Size = new System.Drawing.Size(259, 441);
            this.tpgTemplate.TabIndex = 0;
            this.tpgTemplate.Title = "B    ";
            this.tpgTemplate.Visible = false;
            // 
            // panDetailControl
            // 
            this.panDetailControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panDetailControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetailControl.ForeColor = System.Drawing.Color.Black;
            this.panDetailControl.Location = new System.Drawing.Point(279, 34);
            this.panDetailControl.Name = "panDetailControl";
            this.panDetailControl.Size = new System.Drawing.Size(577, 447);
            this.panDetailControl.TabIndex = 3;
            this.panDetailControl.Resize += new System.EventHandler(this.panDetailControl_Resize);
            // 
            // panPersonName
            // 
            this.panPersonName.BackColor = System.Drawing.Color.Wheat;
            this.panPersonName.Controls.Add(this.pbZoomOut);
            this.panPersonName.Controls.Add(this.pbZoomIn);
            this.panPersonName.Controls.Add(this.picIcon);
            this.panPersonName.Controls.Add(this.lblPersonName);
            this.panPersonName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPersonName.ForeColor = System.Drawing.Color.Black;
            this.panPersonName.Location = new System.Drawing.Point(279, 0);
            this.panPersonName.Name = "panPersonName";
            this.panPersonName.Size = new System.Drawing.Size(577, 34);
            this.panPersonName.TabIndex = 2;
            // 
            // pbZoomOut
            // 
            this.pbZoomOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbZoomOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("pbZoomOut.Image")));
            this.pbZoomOut.Location = new System.Drawing.Point(529, 8);
            this.pbZoomOut.Name = "pbZoomOut";
            this.pbZoomOut.Size = new System.Drawing.Size(18, 18);
            this.pbZoomOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbZoomOut.TabIndex = 275;
            this.pbZoomOut.TabStop = false;
            this.pbZoomOut.Click += new System.EventHandler(this.pbZoomOut_Click);
            // 
            // pbZoomIn
            // 
            this.pbZoomIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbZoomIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("pbZoomIn.Image")));
            this.pbZoomIn.Location = new System.Drawing.Point(549, 8);
            this.pbZoomIn.Name = "pbZoomIn";
            this.pbZoomIn.Size = new System.Drawing.Size(18, 18);
            this.pbZoomIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbZoomIn.TabIndex = 274;
            this.pbZoomIn.TabStop = false;
            this.pbZoomIn.Click += new System.EventHandler(this.pbZoomIn_Click);
            // 
            // picIcon
            // 
            this.picIcon.Image = ((System.Drawing.Image)(resources.GetObject("picIcon.Image")));
            this.picIcon.Location = new System.Drawing.Point(13, 4);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(27, 26);
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            // 
            // lblPersonName
            // 
            this.lblPersonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPersonName.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonName.Location = new System.Drawing.Point(49, 5);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(477, 25);
            this.lblPersonName.TabIndex = 0;
            this.lblPersonName.Text = "Person Name";
            this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonName.DoubleClick += new System.EventHandler(this.lblPersonName_DoubleClick);
            // 
            // splitterTreeControl
            // 
            this.splitterTreeControl.AnimationDelay = 20;
            this.splitterTreeControl.AnimationStep = 20;
            this.splitterTreeControl.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitterTreeControl.ControlToHide = this.panTree;
            this.splitterTreeControl.ExpandParentForm = false;
            this.splitterTreeControl.Location = new System.Drawing.Point(271, 0);
            this.splitterTreeControl.Name = "splitterTreeControl";
            this.splitterTreeControl.TabIndex = 1;
            this.splitterTreeControl.TabStop = false;
            this.splitterTreeControl.UseAnimations = false;
            this.splitterTreeControl.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // CtlFall
            // 
            this.Controls.Add(this.panDetailControl);
            this.Controls.Add(this.panPersonName);
            this.Controls.Add(this.splitterTreeControl);
            this.Controls.Add(this.panTree);
            this.Name = "CtlFall";
            this.Size = new System.Drawing.Size(856, 481);
            this.panTree.ResumeLayout(false);
            this.tabModulTree.ResumeLayout(false);
            this.panPersonName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbZoomIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        #region Dispose

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (SharpLibrary.WinControls.TabPageEx page in this.tabModulTree.TabPages)
                {
                    KiSS4.Common.KissModulTree ctl = this.GetKissModulTree(page);
                    if (ctl != null)
                    {
                        ctl.OnSaveData();
                        ctl.Dispose();
                    }
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        private Gui.KissButton btnZeitachse;
   }
}