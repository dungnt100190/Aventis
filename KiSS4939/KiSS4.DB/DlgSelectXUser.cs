using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Messages
{
    /// <summary>
    /// Summary description for DlgQuestion.
    /// </summary>
    public class DlgSelectXUser : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button btnOK;
        private ComboBox edtUser;
        private Label label1;
        private TextBox txtInfo;

        private DlgSelectXUser()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            // Multilanguage handling
            //this.Text = KissMsg.GetMLMessage("DlgInfo", "FormText", Session.GetCultureText("DlgInfo_FormText", this.Text));
            //this.btnOK.Text = KissMsg.GetMLMessage("DlgInfo", "BtnOKText", Session.GetCultureText("DlgInfo_BtnOKText", this.btnOK.Text));
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="qryUsers">The SQL query.</param>
        /// <returns></returns>
        public static int? GetUser(SqlQuery qryUsers)
        {
            DlgSelectXUser dlg = new DlgSelectXUser();

            dlg.FillUsers(qryUsers);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                return dlg.GetSelectedUser();
            }

            return null;
        }

        private void FillUsers(SqlQuery qryUsers)
        {
            edtUser.DataSource = qryUsers.DataTable;

            //foreach (DataRow row in qryUsers.DataTable)
            //{
            //   edtUser.Items.Add(
            //}
        }

        private int? GetSelectedUser()
        {
            return edtUser.SelectedValue as int?;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgSelectXUser));
            this.btnOK = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.edtUser = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // btnOK
            //
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.BackColor = System.Drawing.Color.Bisque;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(506, 113);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = false;
            //
            // txtInfo
            //
            this.txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                            | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(231)))));
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.txtInfo.Location = new System.Drawing.Point(15, 12);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(566, 33);
            this.txtInfo.TabIndex = 8;
            this.txtInfo.TabStop = false;
            //
            // edtUser
            //
            this.edtUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                            | System.Windows.Forms.AnchorStyles.Right)));
            this.edtUser.DisplayMember = "DisplayName";
            this.edtUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.edtUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.edtUser.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.edtUser.FormattingEnabled = true;
            this.edtUser.Location = new System.Drawing.Point(86, 51);
            this.edtUser.Name = "edtUser";
            this.edtUser.Size = new System.Drawing.Size(495, 24);
            this.edtUser.TabIndex = 9;
            this.edtUser.ValueMember = "UserID";
            //
            // label1
            //
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.Location = new System.Drawing.Point(12, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Benutzer:";
            //
            // DlgSelectXUser
            //
            this.AcceptButton = this.btnOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(593, 155);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.edtUser);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(420, 180);
            this.Name = "DlgSelectXUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Benutzer auswählen";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}