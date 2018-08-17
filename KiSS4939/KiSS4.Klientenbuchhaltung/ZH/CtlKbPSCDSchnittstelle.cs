#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#endregion

using System.Windows.Forms;

using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Klientenbuchhaltung.ZH
{
    public class CtlKbPSCDSchnittstelle : KissNavBarUserControl
    {
        #region Fields

        // Gleiche Maske CtlIkSollstellung f�r A und W Sollstellungen
        private KissNavBarItem itmSollStellgA = new KissNavBarItem("A Sollstellung", 191, typeof(CtlIkSollstellung), new object[] { ModulID.I });

        private KissNavBarItem itmSollStellgW = new KissNavBarItem("W Sollstellung", 191, typeof(CtlIkSollstellung), new object[] { ModulID.S });

        // Gleiche Maske f�r WV-Test- und -Echtlauf
        private KissNavBarItem itmWVLaufEcht = new KissNavBarItem("WV Echtlauf", 191, typeof(CtlKbWVTestlauf), new object[] { false });

        private KissNavBarItem itmWVLaufTest = new KissNavBarItem("WV Testlauf", 191, typeof(CtlKbWVTestlauf), new object[] { true });

        // Gleiche Maske CtlIkZahllauf f�r A und W Zahlungsl�ufe
        private KissNavBarItem itmZLaufA = new KissNavBarItem("Zahlungslauf A", 191, typeof(CtlIkZahllauf), new object[] { ModulID.I });

        private KissNavBarItem itmZLaufWIK = new KissNavBarItem("Zahlungslauf WIK", 191, typeof(CtlIkZahllauf), new object[] { ModulID.S });

        #endregion

        #region Constructors

        public CtlKbPSCDSchnittstelle()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).BeginInit();
            this.panTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).BeginInit();
            this.SuspendLayout();
            //
            // navBar
            //
            this.navBar.Appearance.Background.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.navBar.Appearance.Background.Options.UseBackColor = true;
            this.navBar.Appearance.GroupBackground.BackColor = System.Drawing.Color.Lavender;
            this.navBar.Appearance.GroupBackground.Options.UseBackColor = true;
            this.navBar.Appearance.GroupHeaderActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderActive.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderActive.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderActive.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseFont = true;
            this.navBar.Appearance.GroupHeaderHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.GroupHeaderHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.navBar.Appearance.GroupHeaderPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.navBar.Appearance.GroupHeaderPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemDisabled.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemDisabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemHotTracked.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemHotTracked.Options.UseFont = true;
            this.navBar.Appearance.ItemHotTracked.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemHotTracked.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemHotTracked.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Appearance.ItemPressed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Underline);
            this.navBar.Appearance.ItemPressed.Options.UseFont = true;
            this.navBar.Appearance.ItemPressed.Options.UseTextOptions = true;
            this.navBar.Appearance.ItemPressed.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.navBar.Appearance.ItemPressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.navBar.Size = new System.Drawing.Size(178, 694);
            //
            // splitterNavControl
            //
            this.splitterNavControl.Location = new System.Drawing.Point(178, 0);
            this.splitterNavControl.Size = new System.Drawing.Size(3, 694);
            //
            // panTitle
            //
            this.panTitle.Location = new System.Drawing.Point(181, 0);
            this.panTitle.Size = new System.Drawing.Size(773, 31);
            //
            // picTitle
            //
            this.picTitle.Size = new System.Drawing.Size(24, 26);
            //
            // lblTitle
            //
            this.lblTitle.Size = new System.Drawing.Size(524, 27);
            //
            // panDetail
            //
            this.panDetail.Location = new System.Drawing.Point(181, 31);
            this.panDetail.Size = new System.Drawing.Size(773, 663);
            //
            // FrmKbPSCDSchnittstelle
            //
            this.ClientSize = new System.Drawing.Size(954, 694);
            this.Name = "CtlKbPSCDSchnittstelle";
            this.Text = "PSCD Schnittstelle";
            this.AutoScaleMode = AutoScaleMode.Inherit;

            this.Load += new System.EventHandler(this.FrmKbPSCDSchnittstelle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.navBar)).EndInit();
            this.panTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picTitle)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        #region Private Methods

        private void FrmKbPSCDSchnittstelle_Load(object sender, System.EventArgs e)
        {
            // Letzte Bearbeitung
            // 26.06.2008 : sozheo : Neu
            // ------------------------------------------------------------------------

            itmSollStellgA.Enabled = DBUtil.UserHasRight("CtlIkSollstellung_A");
            itmSollStellgW.Enabled = DBUtil.UserHasRight("CtlIkSollstellung_W");

            itmWVLaufEcht.Enabled = DBUtil.UserHasRight("CtlKbWVTestlauf");
            itmWVLaufTest.Enabled = DBUtil.UserHasRight("CtlKbWVTestlauf");

            itmZLaufA.Enabled = DBUtil.UserHasRight("CtlIkZahllauf_A");
            itmZLaufWIK.Enabled = DBUtil.UserHasRight("CtlIkZahllauf_WIK");
        }

        #endregion
    }
}