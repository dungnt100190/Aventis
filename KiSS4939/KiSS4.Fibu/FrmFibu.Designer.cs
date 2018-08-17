namespace KiSS4.Fibu
{
    partial class FrmFibu
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "FrmFibu";
            this.Text = "Mandatsbuchhaltung";
            this.Activated += new System.EventHandler(this.FrmFibu_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmFibu_Closing);
        }

        #endregion
    }
}