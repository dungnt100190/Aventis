using System;
using KiSS4.DB;
using KiSS4.Gui;
using KiSS4.Gui.Layout;

namespace KiSS4.Common
{
	public class DlgKissUserControl : KiSS4.Gui.KissDialog
	{
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panUserControl;
		private KiSS4.Gui.KissButton btnCancel;
		private KiSS4.Gui.KissButton btnOK;
		private KiSS4.Gui.KissButton btnDelete;

		public DlgKissUserControl()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			new Belegleser(this);
		}

		public DlgKissUserControl(string title, KissUserControl userControl) : this()
		{
			this.Text = title;
			this.UserControl = userControl;
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
			this.panUserControl = new System.Windows.Forms.Panel();
			this.btnCancel = new KiSS4.Gui.KissButton();
			this.btnOK = new KiSS4.Gui.KissButton();
			this.btnDelete = new KiSS4.Gui.KissButton();
			this.SuspendLayout();
			// 
			// panUserControl
			// 
			this.panUserControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.panUserControl.Location = new System.Drawing.Point(8, 8);
			this.panUserControl.Name = "panUserControl";
			this.panUserControl.Size = new System.Drawing.Size(392, 304);
			this.panUserControl.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(304, 320);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(96, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Abbrechen";
			this.btnCancel.UseVisualStyleBackColor = false;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnOK.Location = new System.Drawing.Point(200, 320);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(96, 24);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = false;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDelete.Location = new System.Drawing.Point(8, 320);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(96, 24);
			this.btnDelete.TabIndex = 18;
			this.btnDelete.Text = "Löschen";
			this.btnDelete.UseVisualStyleBackColor = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// DlgKissUserControl
			// 
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(408, 350);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.panUserControl);
			this.Name = "DlgKissUserControl";
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnSettingLayout(KissLayoutEventArgs e)
		{
			// Don't apply Layout
			// base.OnSettingLayout(e);
		}

		#region TitleRefresh
		public class TitleRefreshEventArgs : EventArgs
		{
			public string NewValue;

			public TitleRefreshEventArgs(string newValue)
			{
				this.NewValue = newValue;
			}
		}

		public delegate void TitleRefreshEventHandler(object sender, TitleRefreshEventArgs e);

		public TitleRefreshEventHandler GetTitleRefreshEventHandler
		{
			get { return new TitleRefreshEventHandler(this.ctl_TitleRefresh); }
		}

		private void ctl_TitleRefresh(object sender, TitleRefreshEventArgs e)
		{
			this.Text = e.NewValue;
		}
		#endregion

		public KissUserControl UserControl
		{
			set
			{
				this.Width += (value.Width - this.panUserControl.Width);
				this.Height += (value.Height - this.panUserControl.Height);

				this.ActivateUserControl(value, this.panUserControl);

				this.SetButtons();
			}
			get { return this.DetailControl; }
		}


		public void SetButtons()
		{
			if (this.DetailControl.ActiveSQLQuery == null) return;
			SqlQuery qry = this.DetailControl.ActiveSQLQuery;

			if (qry.CanInsert || qry.CanUpdate || qry.CanDelete)
				this.btnCancel.Text = "Abbrechen";
			else
				this.btnCancel.Text = "OK";

			this.btnDelete.Visible = qry.CanDelete;
			this.btnOK.Visible = qry.CanInsert || qry.CanUpdate;
		}

		#region ButtonEvents
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (this.OnSaveData())
			{
				this.userCancel = false;
				this.Close();
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			if (this.DetailControl.ActiveSQLQuery != null && this.DetailControl.ActiveSQLQuery.Count > 0)
			{
				this.DetailControl.ActiveSQLQuery.Row.RejectChanges();
				this.DetailControl.ActiveSQLQuery.RowModified = false;
			}

			this.Close();
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if (this.OnDeleteData())
			{
				this.userCancel = false;
				this.Close();
			}
		}
		#endregion
	}
}

