using System.ComponentModel;

namespace KiSS4.Gui
{
    /// <summary>
    /// Baseclass for Dialogs
    /// </summary>
    public class KissDialog : KissForm
    {
        private IContainer components = null;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public KissDialog()
        {
            InitializeComponent();
        }

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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            //
            // KissDialog
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KissDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        }

        #endregion
    }
}