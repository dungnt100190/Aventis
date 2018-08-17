namespace KiSS4.Gui
{
    partial class KissProgressIndicator
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Timer timerAnimation;

        #endregion

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timerAnimation = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            //
            // timerAnimation
            //
            this.timerAnimation.Tick += new System.EventHandler(this.timerAnimation_Tick);
            //
            // ProgressIndicator
            //
            this.Size = new System.Drawing.Size(32, 32);
            this.Text = "";
            this.TabStop = false;
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion
    }
}