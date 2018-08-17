namespace KiSS4.Main.PI
{
    partial class CtlFall
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panTree = new System.Windows.Forms.Panel();
            this.ctlGotoFall = new KiSS4.Common.CtlGotoFall();
            this.tabModulTree = new KiSS4.Gui.KissTabControlEx();
            this.tpgTemplate = new SharpLibrary.WinControls.TabPageEx();
            this.imgModulIcons = new SharpLibrary.WinControls.ImageListEx();
            this.splitterTreeControl = new KiSS4.Gui.KissSplitterCollapsible();
            this.panPersonName = new System.Windows.Forms.Panel();
            this.picIcon = new System.Windows.Forms.PictureBox();
            this.lblPersonName = new System.Windows.Forms.Label();
            this.panDetailControl = new System.Windows.Forms.Panel();
            this.panTree.SuspendLayout();
            this.tabModulTree.SuspendLayout();
            this.panPersonName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panTree
            // 
            this.panTree.Controls.Add(this.ctlGotoFall);
            this.panTree.Controls.Add(this.tabModulTree);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTree.Location = new System.Drawing.Point(0, 0);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(288, 496);
            this.panTree.TabIndex = 0;
            // 
            // ctlGotoFall
            // 
            this.ctlGotoFall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ctlGotoFall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.ctlGotoFall.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ctlGotoFall.DisplayModules = "3,4,5,6,7,8,31";
            this.ctlGotoFall.Location = new System.Drawing.Point(140, 6);
            this.ctlGotoFall.Name = "ctlGotoFall";
            this.ctlGotoFall.ShowToolTipsOnIcons = true;
            this.ctlGotoFall.Size = new System.Drawing.Size(142, 20);
            this.ctlGotoFall.TabIndex = 1;
            // 
            // tabModulTree
            // 
            this.tabModulTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabModulTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tabModulTree.Controls.Add(this.tpgTemplate);
            this.tabModulTree.FirstTabMargin = 3;
            this.tabModulTree.ImageList = this.imgModulIcons;
            this.tabModulTree.Location = new System.Drawing.Point(0, 3);
            this.tabModulTree.Name = "tabModulTree";
            this.tabModulTree.ShowFixedWidthTooltip = true;
            this.tabModulTree.ShowOnlySelectedTabText = true;
            this.tabModulTree.Size = new System.Drawing.Size(288, 493);
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
            this.tpgTemplate.Size = new System.Drawing.Size(276, 453);
            this.tpgTemplate.TabIndex = 0;
            this.tpgTemplate.Title = "B    ";
            this.tpgTemplate.Visible = false;
            // 
            // splitterTreeControl
            // 
            this.splitterTreeControl.AnimationDelay = 20;
            this.splitterTreeControl.AnimationStep = 20;
            this.splitterTreeControl.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitterTreeControl.ControlToHide = this.panTree;
            this.splitterTreeControl.ExpandParentForm = false;
            this.splitterTreeControl.Location = new System.Drawing.Point(288, 0);
            this.splitterTreeControl.Name = "splitterTreeControl";
            this.splitterTreeControl.TabIndex = 1;
            this.splitterTreeControl.TabStop = false;
            this.splitterTreeControl.UseAnimations = false;
            this.splitterTreeControl.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // panPersonName
            // 
            this.panPersonName.BackColor = System.Drawing.Color.Wheat;
            this.panPersonName.Controls.Add(this.picIcon);
            this.panPersonName.Controls.Add(this.lblPersonName);
            this.panPersonName.Dock = System.Windows.Forms.DockStyle.Top;
            this.panPersonName.Location = new System.Drawing.Point(296, 0);
            this.panPersonName.Name = "panPersonName";
            this.panPersonName.Size = new System.Drawing.Size(527, 34);
            this.panPersonName.TabIndex = 2;
            // 
            // picIcon
            // 
            this.picIcon.Location = new System.Drawing.Point(13, 4);
            this.picIcon.Name = "picIcon";
            this.picIcon.Size = new System.Drawing.Size(24, 24);
            this.picIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picIcon.TabIndex = 1;
            this.picIcon.TabStop = false;
            // 
            // lblPersonName
            // 
            this.lblPersonName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold);
            this.lblPersonName.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblPersonName.Location = new System.Drawing.Point(49, 5);
            this.lblPersonName.Name = "lblPersonName";
            this.lblPersonName.Size = new System.Drawing.Size(424, 25);
            this.lblPersonName.TabIndex = 0;
            this.lblPersonName.Text = "Person Name";
            this.lblPersonName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPersonName.UseCompatibleTextRendering = true;
            this.lblPersonName.DoubleClick += new System.EventHandler(this.lblPersonName_DoubleClick);
            // 
            // panDetailControl
            // 
            this.panDetailControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetailControl.Location = new System.Drawing.Point(296, 34);
            this.panDetailControl.Name = "panDetailControl";
            this.panDetailControl.Size = new System.Drawing.Size(527, 462);
            this.panDetailControl.TabIndex = 3;
            this.panDetailControl.Resize += new System.EventHandler(this.panDetailControl_Resize);
            // 
            // CtlFall
            // 
            this.Controls.Add(this.panDetailControl);
            this.Controls.Add(this.panPersonName);
            this.Controls.Add(this.splitterTreeControl);
            this.Controls.Add(this.panTree);
            this.Name = "CtlFall";
            this.Size = new System.Drawing.Size(823, 496);
            this.panTree.ResumeLayout(false);
            this.tabModulTree.ResumeLayout(false);
            this.panPersonName.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.IContainer components = null;
        private KiSS4.Common.CtlGotoFall ctlGotoFall;
        private SharpLibrary.WinControls.ImageListEx imgModulIcons;
        private System.Windows.Forms.Label lblPersonName;
        private System.Windows.Forms.Panel panDetailControl;
        private System.Windows.Forms.Panel panPersonName;
        private System.Windows.Forms.Panel panTree;
        private System.Windows.Forms.PictureBox picIcon;
        private KiSS4.Gui.KissSplitterCollapsible splitterTreeControl;
        private KiSS4.Gui.KissTabControlEx tabModulTree;
        private SharpLibrary.WinControls.TabPageEx tpgTemplate;
    }
}
