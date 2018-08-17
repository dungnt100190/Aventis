using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Common
{
    partial class KissNavTreeUserControl
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
            this.components = new System.ComponentModel.Container();
            this.splitTreeControl = new KiSS4.Gui.KissSplitterCollapsible();
            this.panTree = new System.Windows.Forms.Panel();
            this.navTree = new KiSS4.Gui.KissTree();
            this.qryTree = new KiSS4.DB.SqlQuery(this.components);
            this.panDetail = new System.Windows.Forms.Panel();
            this.panTitel = new System.Windows.Forms.Panel();
            this.picTitle = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navTree)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTree)).BeginInit();
            this.panTitel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            // 
            // splitTreeControl
            // 
            this.splitTreeControl.AnimationDelay = 20;
            this.splitTreeControl.AnimationStep = 20;
            this.splitTreeControl.BorderStyle3D = System.Windows.Forms.Border3DStyle.Etched;
            this.splitTreeControl.ControlToHide = this.panTree;
            this.splitTreeControl.ExpandParentForm = false;
            this.splitTreeControl.Location = new System.Drawing.Point(192, 0);
            this.splitTreeControl.Name = "splitTreeControl";
            this.splitTreeControl.TabIndex = 1;
            this.splitTreeControl.TabStop = false;
            this.splitTreeControl.UseAnimations = false;
            this.splitTreeControl.VisualStyle = KiSS4.Gui.VisualStyles.Mozilla;
            // 
            // panTree
            // 
            this.panTree.Controls.Add(this.navTree);
            this.panTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.panTree.Location = new System.Drawing.Point(0, 0);
            this.panTree.Name = "panTree";
            this.panTree.Size = new System.Drawing.Size(192, 523);
            this.panTree.TabIndex = 0;
            // 
            // navTree
            // 
            this.navTree.AllowSortTree = true;
            this.navTree.Appearance.Empty.BackColor = System.Drawing.Color.Transparent;
            this.navTree.Appearance.Empty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.navTree.Appearance.Empty.Options.UseBackColor = true;
            this.navTree.Appearance.Empty.Options.UseForeColor = true;
            this.navTree.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(227)))), ((int)(((byte)(215)))));
            this.navTree.Appearance.EvenRow.ForeColor = System.Drawing.Color.Black;
            this.navTree.Appearance.EvenRow.Options.UseBackColor = true;
            this.navTree.Appearance.EvenRow.Options.UseForeColor = true;
            this.navTree.Appearance.FocusedCell.BackColor = System.Drawing.Color.Transparent;
            this.navTree.Appearance.FocusedCell.ForeColor = System.Drawing.Color.White;
            this.navTree.Appearance.FocusedCell.Options.UseBackColor = true;
            this.navTree.Appearance.FocusedCell.Options.UseForeColor = true;
            this.navTree.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.navTree.Appearance.FocusedRow.Options.UseForeColor = true;
            this.navTree.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.navTree.Appearance.FooterPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Black;
            this.navTree.Appearance.FooterPanel.Options.UseBackColor = true;
            this.navTree.Appearance.FooterPanel.Options.UseFont = true;
            this.navTree.Appearance.FooterPanel.Options.UseForeColor = true;
            this.navTree.Appearance.GroupButton.BackColor = System.Drawing.Color.Transparent;
            this.navTree.Appearance.GroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.navTree.Appearance.GroupButton.ForeColor = System.Drawing.Color.Black;
            this.navTree.Appearance.GroupButton.Options.UseBackColor = true;
            this.navTree.Appearance.GroupButton.Options.UseFont = true;
            this.navTree.Appearance.GroupButton.Options.UseForeColor = true;
            this.navTree.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(226)))), ((int)(((byte)(184)))));
            this.navTree.Appearance.GroupFooter.ForeColor = System.Drawing.Color.Black;
            this.navTree.Appearance.GroupFooter.Options.UseBackColor = true;
            this.navTree.Appearance.GroupFooter.Options.UseForeColor = true;
            this.navTree.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Tan;
            this.navTree.Appearance.HeaderPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navTree.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.navTree.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.navTree.Appearance.HeaderPanel.Options.UseFont = true;
            this.navTree.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.navTree.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.PowderBlue;
            this.navTree.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.Black;
            this.navTree.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.navTree.Appearance.HideSelectionRow.Options.UseFont = true;
            this.navTree.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.navTree.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.navTree.Appearance.HorzLine.ForeColor = System.Drawing.Color.Red;
            this.navTree.Appearance.HorzLine.Options.UseBackColor = true;
            this.navTree.Appearance.HorzLine.Options.UseForeColor = true;
            this.navTree.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(236)))), ((int)(((byte)(215)))));
            this.navTree.Appearance.OddRow.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.OddRow.ForeColor = System.Drawing.Color.Black;
            this.navTree.Appearance.OddRow.Options.UseBackColor = true;
            this.navTree.Appearance.OddRow.Options.UseFont = true;
            this.navTree.Appearance.OddRow.Options.UseForeColor = true;
            this.navTree.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.navTree.Appearance.Preview.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.Preview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.navTree.Appearance.Preview.Options.UseBackColor = true;
            this.navTree.Appearance.Preview.Options.UseFont = true;
            this.navTree.Appearance.Preview.Options.UseForeColor = true;
            this.navTree.Appearance.Row.BackColor = System.Drawing.Color.Transparent;
            this.navTree.Appearance.Row.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.navTree.Appearance.Row.ForeColor = System.Drawing.Color.Black;
            this.navTree.Appearance.Row.Options.UseBackColor = true;
            this.navTree.Appearance.Row.Options.UseFont = true;
            this.navTree.Appearance.Row.Options.UseForeColor = true;
            this.navTree.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.navTree.Appearance.SelectedRow.Options.UseForeColor = true;
            this.navTree.Appearance.TreeLine.BackColor = System.Drawing.Color.Gray;
            this.navTree.Appearance.TreeLine.Options.UseBackColor = true;
            this.navTree.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.navTree.Appearance.VertLine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(166)))), ((int)(((byte)(70)))));
            this.navTree.Appearance.VertLine.Options.UseBackColor = true;
            this.navTree.Appearance.VertLine.Options.UseForeColor = true;
            this.navTree.Appearance.VertLine.Options.UseTextOptions = true;
            this.navTree.Appearance.VertLine.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navTree.DataSource = this.qryTree;
            this.navTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navTree.ImageIndexFieldName = "IconID";
            this.navTree.Location = new System.Drawing.Point(0, 0);
            this.navTree.Name = "navTree";
            this.navTree.OptionsBehavior.AutoSelectAllInEditor = false;
            this.navTree.OptionsBehavior.CloseEditorOnLostFocus = false;
            this.navTree.OptionsBehavior.Editable = false;
            this.navTree.OptionsBehavior.KeepSelectedOnClick = false;
            this.navTree.OptionsBehavior.MoveOnEdit = false;
            this.navTree.OptionsMenu.EnableColumnMenu = false;
            this.navTree.OptionsMenu.EnableFooterMenu = false;
            this.navTree.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.navTree.OptionsView.AutoWidth = false;
            this.navTree.OptionsView.EnableAppearanceEvenRow = true;
            this.navTree.OptionsView.EnableAppearanceOddRow = true;
            this.navTree.OptionsView.ShowIndicator = false;
            this.navTree.Size = new System.Drawing.Size(192, 523);
            this.navTree.TabIndex = 0;
            // 
            // qryTree
            // 
            this.qryTree.HostControl = this;
            this.qryTree.AfterFill += new System.EventHandler(this.qryTree_AfterFill);
            // 
            // panDetail
            // 
            this.panDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetail.Location = new System.Drawing.Point(200, 29);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(600, 494);
            this.panDetail.TabIndex = 3;
            // 
            // panTitel
            // 
            this.panTitel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.panTitel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panTitel.Controls.Add(this.picTitle);
            this.panTitel.Controls.Add(this.lblTitle);
            this.panTitel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTitel.Location = new System.Drawing.Point(200, 0);
            this.panTitel.Name = "panTitel";
            this.panTitel.Size = new System.Drawing.Size(600, 29);
            this.panTitel.TabIndex = 2;
            // 
            // picTitle
            // 
            this.picTitle.Location = new System.Drawing.Point(10, 2);
            this.picTitle.Name = "picTitle";
            this.picTitle.Size = new System.Drawing.Size(24, 24);
            this.picTitle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTitle.TabIndex = 0;
            this.picTitle.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(42, 2);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(553, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Titel";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Visible = false;
            // 
            // KissNavTreeUserControl
            // 
            this.ClientSize = new System.Drawing.Size(800, 523);
            this.Controls.Add(this.panDetail);
            this.Controls.Add(this.panTitel);
            this.Controls.Add(this.splitTreeControl);
            this.Controls.Add(this.panTree);
            this.Name = "KissNavTreeUserControl";
            this.Text = "navTreeForm";
            this.panTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navTree)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qryTree)).EndInit();
            this.panTitel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>
        /// Title label.
        /// </summary>
        protected System.Windows.Forms.Label lblTitle;

        /// <summary>
        /// Navigation Tree.
        /// </summary>
        protected KiSS4.Gui.KissTree navTree;

        /// <summary>
        /// Details Panel.
        /// </summary>
        protected System.Windows.Forms.Panel panDetail;

        /// <summary>
        /// Title Panel.
        /// </summary>
        protected System.Windows.Forms.Panel panTitel;

        /// <summary>
        /// Tree Panel.
        /// </summary>
        protected System.Windows.Forms.Panel panTree;

        /// <summary>
        /// Picture Box for title.
        /// </summary>
        protected System.Windows.Forms.PictureBox picTitle;

        /// <summary>
        /// Query for tree.
        /// </summary>
        protected KiSS4.DB.SqlQuery qryTree;

        /// <summary>
        /// Tree Splitter.
        /// </summary>
        protected KiSS4.Gui.KissSplitterCollapsible splitTreeControl;
    }
}
