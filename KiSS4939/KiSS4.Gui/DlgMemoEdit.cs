using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace KiSS4.Gui
{
	/// <summary>
	/// Summary description for DlgMemoEdit.
	/// </summary>
	public class DlgMemoEdit : KiSS4.Gui.KissDialog
	{
		private KiSS4.Gui.KissButton btnSave;
		private KiSS4.Gui.KissButton btnCancel;
		private KiSS4.Gui.KissMemoEdit editMemo;
		//private System.ComponentModel.IContainer components;

		/// <summary>
		/// Initializes a new instance of the <see cref="DlgMemoEdit"/> class.
		/// </summary>
		public DlgMemoEdit()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="DlgMemoEdit"/> class.
		/// </summary>
		/// <param name="readOnly">if set to <c>true</c> [read only].</param>
		/// <param name="font">The font.</param>
		public DlgMemoEdit(bool readOnly, Font font) : this()
		{
			editMemo.Properties.ReadOnly = readOnly;
			editMemo.Font = font;
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				//if (components != null)
				//{
				//   components.Dispose();
				//}
			}
			base.Dispose(disposing);
		}

		/// <summary>
		/// Gets the memo editor.
		/// </summary>
		/// <value>The memo editor.</value>
		[Browsable(false)]
		public KissMemoEdit MemoEditor
		{
			get { return editMemo; }
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSave = new KiSS4.Gui.KissButton();
			this.btnCancel = new KiSS4.Gui.KissButton();
			this.editMemo = new KiSS4.Gui.KissMemoEdit();
			((System.ComponentModel.ISupportInitialize)(this.editMemo.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(480, 364);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 24);
			this.btnSave.TabIndex = 1;
			this.btnSave.Text = "OK";
			this.btnSave.UseVisualStyleBackColor = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(568, 364);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Abbruch";
			this.btnCancel.UseVisualStyleBackColor = false;
			// 
			// editMemo
			// 
			this.editMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.editMemo.Location = new System.Drawing.Point(8, 9);
			this.editMemo.Name = "editMemo";
			this.editMemo.Properties.AcceptsTab = true;
			this.editMemo.Properties.Appearance.BackColor = System.Drawing.Color.AliceBlue;
			this.editMemo.Properties.Appearance.BorderColor = System.Drawing.Color.Linen;
			this.editMemo.Properties.Appearance.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
			this.editMemo.Properties.Appearance.Options.UseBackColor = true;
			this.editMemo.Properties.Appearance.Options.UseBorderColor = true;
			this.editMemo.Properties.Appearance.Options.UseFont = true;
			this.editMemo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
			this.editMemo.Size = new System.Drawing.Size(640, 348);
			this.editMemo.TabIndex = 0;
			// 
			// DlgMemoEdit
			// 
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(658, 399);
			this.ControlBox = false;
			this.Controls.Add(this.editMemo);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "DlgMemoEdit";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Memo editieren";
			this.Load += new System.EventHandler(this.DlgMemoEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.editMemo.Properties)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Handles the Load event of the DlgMemoEdit control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
		private void DlgMemoEdit_Load(object sender, System.EventArgs e)
		{
			editMemo.DeselectAll();
		}
	}
}
