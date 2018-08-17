using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace KiSS4.Gui
{
	/// <summary>
	/// Form waiting for a file to delete.
	/// </summary>
	public class DlgFileDelete : KiSS4.Gui.KissDialog
	{
		private const int defPollingInterval = 1000; // 1 second

		private FileInfo fi;
		private int pi = defPollingInterval;
		private KiSS4.Gui.KissButton btnYes;
		private KiSS4.Gui.KissButton btnNo;
		private KiSS4.Gui.KissLabel lblMsg;
		private KiSS4.Gui.KissLabel lblQuestion;
		private System.Windows.Forms.Timer timer1;
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Initializes a new instance of the <see cref="DlgFileDelete"/> class.
		/// </summary>
		public DlgFileDelete()
		{
			//
			// Required for Windows Form Designer support
			//
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

		/// <summary>
		/// Gets or sets the file info.
		/// </summary>
		/// <value>The file info.</value>
		[Browsable(false)]
		public FileInfo FileInfo
		{
			get { return this.fi; }
			set { this.fi = value; }
		}

		/// <summary>
		/// Gets or sets the polling interval in milliseconds
		/// </summary>
		[DefaultValue(defPollingInterval)]
		public int PollingInterval
		{
			get { return this.pi; }
			set { this.pi = value; }
		}

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Form.Load"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (this.fi != null) this.fi.Refresh();
			if (this.fi == null || !this.fi.Exists)
			{
				this.Close();
				return;
			}

			this.lblMsg.Text = string.Format(this.lblMsg.Text, this.fi.FullName);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblMsg = new KiSS4.Gui.KissLabel();
			this.btnYes = new KiSS4.Gui.KissButton();
			this.btnNo = new KiSS4.Gui.KissButton();
			this.lblQuestion = new KiSS4.Gui.KissLabel();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.lblMsg)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lblQuestion)).BeginInit();
			this.SuspendLayout();
			// 
			// lblMsg
			// 
			this.lblMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
				| System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblMsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMsg.LabelStyle = KiSS4.Gui.LabelStyleType.Custom;
			this.lblMsg.Location = new System.Drawing.Point(8, 8);
			this.lblMsg.Name = "lblMsg";
			this.lblMsg.Size = new System.Drawing.Size(296, 56);
			this.lblMsg.TabIndex = 0;
			this.lblMsg.Text = "Die temporäre Datei {0} wurde erstellt und zur Bearbeitung geöffnet.";
			// 
			// btnYes
			// 
			this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnYes.Location = new System.Drawing.Point(168, 104);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(64, 24);
			this.btnYes.TabIndex = 1;
			this.btnYes.Text = "Ja";
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// btnNo
			// 
			this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNo.Location = new System.Drawing.Point(240, 104);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(64, 24);
			this.btnNo.TabIndex = 2;
			this.btnNo.Text = "Nein";
			// 
			// lblQuestion
			// 
			this.lblQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblQuestion.LabelStyle = KiSS4.Gui.LabelStyleType.DataViewLabel;
			this.lblQuestion.Location = new System.Drawing.Point(8, 72);
			this.lblQuestion.Name = "lblQuestion";
			this.lblQuestion.Size = new System.Drawing.Size(296, 16);
			this.lblQuestion.TabIndex = 3;
			this.lblQuestion.Text = "Soll die Datei gelöscht werden?";
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// DlgFileDelete
			// 
			this.AcceptButton = this.btnYes;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnNo;
			this.ClientSize = new System.Drawing.Size(314, 136);
			this.ControlBox = false;
			this.Controls.Add(this.lblQuestion);
			this.Controls.Add(this.btnNo);
			this.Controls.Add(this.btnYes);
			this.Controls.Add(this.lblMsg);
			this.Name = "DlgFileDelete";
			this.ShowInTaskbar = false;
			this.Text = "Datei löschen?";
			((System.ComponentModel.ISupportInitialize)(this.lblMsg)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lblQuestion)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Handles the Click event of the btnYes control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void btnYes_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.fi.Delete();
				this.timer1.Enabled = false;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch
			{
				this.lblMsg.Text = string.Format("Die Datei {0} konnte nicht gelöscht werden.", this.fi.FullName);
				this.lblQuestion.Text = "Soll weiterhin versucht werden, die Datei zu löschen?";

				// arm the timer
				this.timer1.Interval = this.pi;
				this.timer1.Enabled = true;
			}
		}

		/// <summary>
		/// Handles the Tick event of the timer1 control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void timer1_Tick(object sender, System.EventArgs e)
		{
			this.btnYes_Click(this, EventArgs.Empty);
		}
	}
}
