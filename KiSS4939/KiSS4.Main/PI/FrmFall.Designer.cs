using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Main.PI
{
    partial class FrmFall
    {
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabFall = new KiSS4.Gui.KissTabControlEx();
            this.tpgFall = new SharpLibrary.WinControls.TabPageEx();
            this.tabFall.SuspendLayout();
            this.SuspendLayout();
            //
            // tabFall
            //
            this.tabFall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(216)))), ((int)(((byte)(174)))));
            this.tabFall.Controls.Add(this.tpgFall);
            this.tabFall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFall.FirstTabMargin = 4;
            this.tabFall.FixedWidth = 500;
            this.tabFall.Location = new System.Drawing.Point(0, 0);
            this.tabFall.Name = "tabFall";
            this.tabFall.ShowClose = false;
            this.tabFall.ShowFixedWidthTooltip = true;
            this.tabFall.ShowSelectedTextBold = true;
            this.tabFall.Size = new System.Drawing.Size(1012, 666);
            this.tabFall.TabBaseColor = System.Drawing.Color.Transparent;
            this.tabFall.TabControlStyle = KiSS4.Gui.TabControlStyleType.Buttons;
            this.tabFall.TabIndex = 8;
            this.tabFall.TabPages.AddRange(new SharpLibrary.WinControls.TabPageEx[] {
                        this.tpgFall});
            this.tabFall.TabsAreaBackColor = System.Drawing.Color.Transparent;
            this.tabFall.TabsFitting = SharpLibrary.WinControls.TabsFitting.FixedWidth;
            this.tabFall.TabsLineColor = System.Drawing.Color.Black;
            this.tabFall.TabsLocation = SharpLibrary.WinControls.TabsLocation.Top;
            this.tabFall.TabsStyle = SharpLibrary.WinControls.TabsStyle.CustomImages;
            this.tabFall.Text = "kissTabControlEx1";
            this.tabFall.VerticalMargin = 9;
            this.tabFall.MouseUpButtonStyle += new System.Windows.Forms.MouseEventHandler(this.tabFall_MouseUpButtonStyle);
            this.tabFall.TabClosed += new SharpLibrary.WinControls.TabControlExTabChangeEventHandler(this.tabFall_TabClosed);
            //
            // tpgFall
            //
            this.tpgFall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.tpgFall.ImageIndex = 0;
            this.tpgFall.Location = new System.Drawing.Point(6, 44);
            this.tpgFall.Name = "tpgFall";
            this.tpgFall.SelectedImageIndex = 1;
            this.tpgFall.Size = new System.Drawing.Size(1000, 616);
            this.tpgFall.TabIndex = 0;
            this.tpgFall.Title = "tpgFall";
            //
            // FrmFall
            //
            this.ClientSize = new System.Drawing.Size(1012, 666);
            this.Controls.Add(this.tabFall);
            this.Name = "FrmFall";
            this.Text = "Fallbearbeitung";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFall_KeyDown);
            this.tabFall.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private KiSS4.Gui.KissTabControlEx tabFall;
        private SharpLibrary.WinControls.TabPageEx tpgFall;
    }
}
