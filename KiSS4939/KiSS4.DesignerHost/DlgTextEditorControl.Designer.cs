namespace KiSS4.DesignerHost
{
	partial class DlgTextEditorControl
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlgTextEditorControl));
			ICSharpCode.TextEditor.Document.DefaultTextEditorProperties defaultTextEditorProperties1 = new ICSharpCode.TextEditor.Document.DefaultTextEditorProperties();
			this.btnCancel = new KiSS4.Gui.KissButton();
			this.btnSave = new KiSS4.Gui.KissButton();
			this.textEditorControl = new KiSS4.DesignerHost.TextEditorControl();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCancel.Location = new System.Drawing.Point(568, 365);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Abbruch";
			this.btnCancel.UseVisualStyleBackColor = false;
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Location = new System.Drawing.Point(480, 365);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(80, 24);
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "OK";
			this.btnSave.UseVisualStyleBackColor = false;
			// 
			// textEditorControl
			// 
			this.textEditorControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.textEditorControl.DataMember = "csCode";
			this.textEditorControl.Encoding = ((System.Text.Encoding)(resources.GetObject("textEditorControl.Encoding")));
			this.textEditorControl.IsIconBarVisible = false;
			this.textEditorControl.Location = new System.Drawing.Point(12, 12);
			this.textEditorControl.Name = "textEditorControl";
			this.textEditorControl.ShowEOLMarkers = true;
			this.textEditorControl.ShowSpaces = true;
			this.textEditorControl.ShowTabs = true;
			this.textEditorControl.Size = new System.Drawing.Size(636, 347);
			this.textEditorControl.TabIndex = 20;
			defaultTextEditorProperties1.AllowCaretBeyondEOL = false;
			defaultTextEditorProperties1.AutoInsertCurlyBracket = true;
			defaultTextEditorProperties1.BracketMatchingStyle = ICSharpCode.TextEditor.Document.BracketMatchingStyle.After;
			defaultTextEditorProperties1.ConvertTabsToSpaces = false;
			defaultTextEditorProperties1.CreateBackupCopy = false;
			defaultTextEditorProperties1.DocumentSelectionMode = ICSharpCode.TextEditor.Document.DocumentSelectionMode.Normal;
			defaultTextEditorProperties1.EnableFolding = true;
			defaultTextEditorProperties1.Encoding = ((System.Text.Encoding)(resources.GetObject("defaultTextEditorProperties1.Encoding")));
			defaultTextEditorProperties1.Font = new System.Drawing.Font("Courier New", 10F);
			defaultTextEditorProperties1.HideMouseCursor = false;
			defaultTextEditorProperties1.IndentStyle = ICSharpCode.TextEditor.Document.IndentStyle.Smart;
			defaultTextEditorProperties1.IsIconBarVisible = false;
			defaultTextEditorProperties1.LineTerminator = "\r\n";
			defaultTextEditorProperties1.LineViewerStyle = ICSharpCode.TextEditor.Document.LineViewerStyle.None;
			defaultTextEditorProperties1.MouseWheelScrollDown = true;
			defaultTextEditorProperties1.MouseWheelTextZoom = true;
			defaultTextEditorProperties1.ShowEOLMarker = true;
			defaultTextEditorProperties1.ShowHorizontalRuler = false;
			defaultTextEditorProperties1.ShowInvalidLines = true;
			defaultTextEditorProperties1.ShowLineNumbers = true;
			defaultTextEditorProperties1.ShowMatchingBracket = true;
			defaultTextEditorProperties1.ShowSpaces = true;
			defaultTextEditorProperties1.ShowTabs = true;
			defaultTextEditorProperties1.ShowVerticalRuler = false;
			defaultTextEditorProperties1.TabIndent = 4;
			defaultTextEditorProperties1.UseAntiAliasedFont = false;
			defaultTextEditorProperties1.UseCustomLine = false;
			defaultTextEditorProperties1.VerticalRulerRow = 80;
			this.textEditorControl.TextEditorProperties = defaultTextEditorProperties1;
			// 
			// DlgTextEditorControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(660, 401);
			this.ControlBox = false;
			this.Controls.Add(this.textEditorControl);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.Name = "DlgTextEditorControl";
			this.ShowInTaskbar = false;
			this.Text = "Code editieren";
			this.ResumeLayout(false);

		}

		#endregion

		private KiSS4.Gui.KissButton btnCancel;
		private KiSS4.Gui.KissButton btnSave;
		private TextEditorControl textEditorControl;
	}
}