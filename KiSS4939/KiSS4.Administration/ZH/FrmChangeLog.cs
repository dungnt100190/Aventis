#region Header

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.832
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#endregion

using KiSS4.Gui;

namespace KiSS4.Administration.ZH
{
    public class FrmChangeLog : KiSS4.Gui.KissChildForm
    {
        #region Constructors

        public FrmChangeLog()
        {
            this.InitializeComponent();

            // show detail control
            CtlChangeLog ctl = new CtlChangeLog();
            ctl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActivateUserControl(ctl, this, true);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // FrmChangeLog
            //
            this.ClientSize = new System.Drawing.Size(920, 571);
            this.Name = "FrmChangeLog";
            this.Text = "ChangeLog KiSS4 Z�rich";
            this.ResumeLayout(false);
        }

        #endregion

        #region Public Methods

        public override bool OnAddData()
        {
            try
            {
                if (DetailControl != null)
                    return ((IKissDataNavigator)DetailControl).AddData();
                else
                    return base.OnAddData();
            }
            catch { return false; }
        }

        public override bool OnDeleteData()
        {
            try
            {
                if (DetailControl != null)
                    return ((IKissDataNavigator)DetailControl).DeleteData();
                else
                    return base.OnDeleteData();
            }
            catch { return false; }
        }

        public override void OnMoveFirst()
        {
            try
            {
                if (DetailControl != null)
                    ((IKissDataNavigator)DetailControl).MoveFirst();
                else
                    base.OnMoveFirst ();
            }
            catch {}
        }

        public override void OnMoveLast()
        {
            try
            {
                if (DetailControl != null)
                    ((IKissDataNavigator)DetailControl).MoveLast();
                else
                    base.OnMoveLast();
            }
            catch {}
        }

        public override void OnMoveNext()
        {
            try
            {
                if (DetailControl != null)
                    ((IKissDataNavigator)DetailControl).MoveNext();
                else
                    base.OnMoveNext ();
            }
            catch {}
        }

        public override void OnMovePrevious()
        {
            try
            {
                if (DetailControl != null)
                    ((IKissDataNavigator)DetailControl).MovePrevious();
                else
                    base.OnMovePrevious ();
            }
            catch {}
        }

        public override void OnRefreshData()
        {
            try
            {
                if (DetailControl != null)
                    ((IKissDataNavigator)DetailControl).RefreshData();
                else
                    base.OnRefreshData ();
            }
            catch {}
        }

        public override bool OnSaveData()
        {
            try
            {
                if (DetailControl != null)
                    return ((IKissDataNavigator)DetailControl).SaveData();
                else
                    return base.OnSaveData();
            }
            catch { return false; }
        }

        public override void OnSearch()
        {
            try
            {
                if (DetailControl != null)
                    ((IKissDataNavigator)DetailControl).Search();
                else
                    base.OnSearch();
            }
            catch {}
        }

        #endregion
    }
}