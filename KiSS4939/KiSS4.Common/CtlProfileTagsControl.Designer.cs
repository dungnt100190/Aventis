namespace KiSS4.Common
{
    partial class CtlProfileTagsControl
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
            this.edtProfileTags = new KiSS4.Gui.KissCheckedLookupEdit();
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileTags)).BeginInit();
            this.SuspendLayout();
            // 
            // edtProfileTags
            // 
            this.edtProfileTags.Appearance.BackColor = System.Drawing.Color.AliceBlue;
            this.edtProfileTags.Appearance.Options.UseBackColor = true;
            this.edtProfileTags.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.edtProfileTags.CheckOnClick = true;
            this.edtProfileTags.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edtProfileTags.Location = new System.Drawing.Point(1, 1);
            this.edtProfileTags.MultiColumn = true;
            this.edtProfileTags.Name = "edtProfileTags";
            this.edtProfileTags.Size = new System.Drawing.Size(413, 229);
            this.edtProfileTags.TabIndex = 0;
            this.edtProfileTags.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.edtProfileTags_ItemCheck);
            // 
            // CtlProfileTagsControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            
            this.Controls.Add(this.edtProfileTags);
            this.Name = "CtlProfileTagsControl";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(415, 231);
            this.Load += new System.EventHandler(this.CtlProfileTagsControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.edtProfileTags)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Gui.KissCheckedLookupEdit edtProfileTags;
    }
}
