using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.DesignerHost
{
	/// <summary>
	/// Implements the KiSS4 Text Editor.
	/// </summary>
	public class TextEditorControl 
		: 
		ICSharpCode.TextEditor.TextEditorControl, 
		IKissBindableEdit
	{
		private EditModeType editMode = EditModeType.Normal;

		/// <summary>
		/// Initializes a new instance of the <see cref="TextEditorControl"/> class.
		/// </summary>
		public TextEditorControl() : base()
		{
			InitializeComponent();

			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, false);
			SetStyle(ControlStyles.ResizeRedraw, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			HighlightingManager.Manager.AddSyntaxModeFileProvider(new SyntaxModeFileProvider());
			Document.HighlightingStrategy = HighlightingManager.Manager.FindHighlighter("CS");

			this.ActiveTextAreaControl.TextArea.KeyDown += new System.Windows.Forms.KeyEventHandler(TextArea_KeyDown);
			this.ActiveTextAreaControl.TextArea.KeyUp += new System.Windows.Forms.KeyEventHandler(TextArea_KeyUp);
			this.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
		}

		#region Events
		private bool KeyDown_CtrlC = false;
		private bool KeyDown_CtrlX = false;
		private bool KeyDown_CtrlV = false;

		void TextArea_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
            //log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            //logger.Debug("e.KeyCode: " + e.KeyCode.ToString());

			if (e.KeyCode == Keys.F12)
			{
				OpenEditorDialog();
				e.Handled = true;
			}
			else if (UtilsGui.IsControlModifier(e) && (e.KeyCode == Keys.C || (Document.ReadOnly && e.KeyCode == Keys.X)))
			{
				KeyDown_CtrlC = true;
			}
			else if (UtilsGui.IsControlModifier(e) && e.KeyCode == Keys.X)
			{
				KeyDown_CtrlX = true;
			}
			else if (UtilsGui.IsControlModifier(e) && e.KeyCode == Keys.V)
			{
				KeyDown_CtrlV = true;
			}
		}

		void TextArea_KeyUp(object sender, KeyEventArgs e)
		{
			TextAreaClipboardHandler clipboardHandler = ActiveTextAreaControl.TextArea.ClipboardHandler;

			if (UtilsGui.IsControlModifier(e) && (e.KeyCode == Keys.C || (Document.ReadOnly && e.KeyCode == Keys.X)))
			{
				if (KeyDown_CtrlC || this.Parent is DlgTextEditorControl)
				{
					KeyDown_CtrlC = false;
				}

				clipboardHandler.Copy(this, EventArgs.Empty);
				e.Handled = true;
			}
			else if (UtilsGui.IsControlModifier(e) && e.KeyCode == Keys.X)
			{
                if (KeyDown_CtrlX && !e.Handled )
				{
					KeyDown_CtrlX = false;
                    if (!(this.Parent is DlgTextEditorControl || Document.ReadOnly))
                    {
                        clipboardHandler.Cut(this, EventArgs.Empty);
                    }
				}
				e.Handled = true;
			}
			else if (UtilsGui.IsControlModifier(e) && e.KeyCode == Keys.V)
			{
                if (KeyDown_CtrlV && !e.Handled)
				{
					KeyDown_CtrlV = false;
                    if (!(this.Parent is DlgTextEditorControl || Document.ReadOnly))
                    {
                        clipboardHandler.Paste(this, EventArgs.Empty);
                    }
				}
                e.Handled = true;
			}
		}

		void Document_DocumentChanged(object sender, DocumentEventArgs e)
		{
			OnTextChanged(EventArgs.Empty);
		}
		#endregion

		/// <summary>
		/// Handles Text changed events.
		/// </summary>
		public new event System.EventHandler TextChanged;

		/// <summary>
		/// Raises the <see cref="E:System.Windows.Forms.Control.TextChanged"></see> event.
		/// </summary>
		/// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected new void OnTextChanged(EventArgs e)
		{
			if (TextChanged != null)
				TextChanged(this, e);
		}

		/// <summary>
		/// Gets or sets the text.
		/// </summary>
		/// <value>The text.</value>
		public override string Text
		{
			get
			{
				return base.Text;
			}
			set
			{
				base.Text = value;
				Document.UndoStack.ClearAll();
				Refresh();
			}
		}

		/// <summary>
		/// Opens the editor dialog.
		/// </summary>
		public void OpenEditorDialog()
		{
			if (this.Parent is DlgTextEditorControl) return;

			DlgTextEditorControl dlg = new DlgTextEditorControl();
			dlg.TextEditorControl.Text = Text;
			dlg.TextEditorControl.Document.ReadOnly = Document.ReadOnly;

			dlg.RestoreLayout();
			if (dlg.ShowDialog() == DialogResult.OK && !Document.ReadOnly)
				Text = dlg.TextEditorControl.Text;
		}

		/// <summary>
		/// Gets or sets the document.
		/// </summary>
		/// <value>The document.</value>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new IDocument Document
		{
			get { return base.Document; }
			set { base.Document = value; }
		}

		/// <summary>
		/// Gets or sets the edit mode.
		/// </summary>
		/// <value>The edit mode.</value>
		[Browsable(true)]
		[DefaultValue(EditModeType.Normal)]
		public EditModeType EditMode
		{
			get { return editMode; }
			set
			{
				editMode = value;

				Document.ReadOnly = editMode == EditModeType.ReadOnly;
			}
		}

		#region IKissBindableEdit Members
		private SqlQuery dataSource = null;
		private string dataMember = string.Empty;

		/// <summary>
		/// Binding SqlQuery
		/// </summary>
		/// <value></value>
		/// <include file="..\KiSS4.DB\KiSS4.DB.XML" path="doc/members/member[@name=&quot;P:KiSS4.DB.IKissBindableEdit.DataSource&quot;]/*"/>
		[Browsable(true)]
		[DefaultValue(null)]
		public SqlQuery DataSource
		{
			get { return dataSource; }
			set { dataSource = value; }
		}

		/// <summary>
		/// Binding DataMember.
		/// </summary>
		/// <value></value>
		/// <include file="..\KiSS4.DB\KiSS4.DB.XML" path="doc/members/member[@name=&quot;P:KiSS4.DB.IKissBindableEdit.DataMember&quot;]/*"/>
		[Browsable(true)]
		[DefaultValue("")]
		public string DataMember
		{
			get { return dataMember; }
			set { dataMember = value; }
		}

		/// <summary>
		/// Gets the name of the bindable property.
		/// </summary>
		/// <returns></returns>
		string IKissBindableEdit.GetBindablePropertyName()
		{
			return "Text";
		}

		/// <summary>
		/// Gets a value indicating whether editing is allowed.
		/// </summary>
		/// <param name="value"></param>
		void IKissBindableEdit.AllowEdit(bool value)
		{
			if (editMode != EditModeType.ReadOnly)
			{
				Document.ReadOnly = !value;
			}
		}

		#endregion

		/// <summary>
		/// Initializes the component.
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// TextEditorControl
			// 
			this.IsIconBarVisible = false;
			this.Name = "TextEditorControl";
			this.ResumeLayout(false);

		}

		#region Paint Border
		[DllImport("user32.dll")]
		private static extern IntPtr GetWindowDC(IntPtr hwnd);
		[DllImport("user32.dll")]
		private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		
		private int borderWidth = 1;

		[DefaultValue(1)]
		public int BorderWidth
		{
			get { return borderWidth; }
			set { borderWidth = value; }
		}


		private Color borderColor = Color.FromArgb(223, 159, 96);

		public Color BorderColor
		{
			get { return borderColor; }
			set { borderColor = value; }
		}

		bool ShouldSerializeBorderColor()
		{
			return borderColor != Color.FromArgb(223, 159, 96);
		}


		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);

			if (this.BorderStyle == BorderStyle.FixedSingle)
			{
				IntPtr hDC = GetWindowDC(this.Handle);
				Graphics g = Graphics.FromHdc(hDC);

				ControlPaint.DrawBorder(g,
					new Rectangle(0, 0, this.Width, this.Height),
					borderColor, borderWidth, ButtonBorderStyle.Solid,
					borderColor, borderWidth, ButtonBorderStyle.Solid,
					borderColor, borderWidth, ButtonBorderStyle.Solid,
					borderColor, borderWidth, ButtonBorderStyle.Solid);
				g.Dispose();
				ReleaseDC(Handle, hDC);
			}
		}
		#endregion
	}
}
