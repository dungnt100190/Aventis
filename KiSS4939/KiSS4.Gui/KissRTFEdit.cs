using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissMemoEdit.
    /// </summary>
    public class KissRTFEdit : System.Windows.Forms.RichTextBox, IKissBindableEdit, IKissEditable
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int EM_GETLINECOUNT = 0xBA;
        private const int EM_LINEINDEX = 0xBB;
        private const long SB_THUMBPOSITION = 4;
        private const long SB_THUMBTRACK = 5;
        private const int WM_VSCROLL = 277;

        #endregion

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components;

        private string dataMember = String.Empty;
        private SqlQuery dataSource;
        private EditModeType editMode = EditModeType.Normal;
        private ContextMenuStrip mnuEdit;
        private ToolStripMenuItem mnuEditCopy;
        private ToolStripMenuItem mnuEditCut;
        private ToolStripMenuItem mnuEditDelete;
        private ToolStripMenuItem mnuEditPaste;
        private ToolStripMenuItem mnuEditRedo;
        private ToolStripMenuItem mnuEditSelectAll;
        private ToolStripSeparator mnuEditSeparator01;
        private ToolStripSeparator mnuEditSeparator02;
        private ToolStripMenuItem mnuEditUndo;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissRTFEdit"/> class.
        /// </summary>
        public KissRTFEdit()
        {
            // init
            InitializeComponent();

            // setup menu captions as multilanguage
            this.mnuEditUndo.Text = KissMsg.GetMLMessage("KissRTFEdit", "MnuEditUndo", "&Rückgängig");
            this.mnuEditRedo.Text = KissMsg.GetMLMessage("KissRTFEdit", "MnuEditRedo", "&Wiederherstellen");
            this.mnuEditCut.Text = KissMsg.GetMLMessage("KissRTFEdit", "MnuEditCut", "&Ausschneiden");
            this.mnuEditCopy.Text = KissMsg.GetMLMessage("KissRTFEdit", "MnuEditCopy", "&Kopieren");
            this.mnuEditPaste.Text = KissMsg.GetMLMessage("KissRTFEdit", "MnuEditPaste", "&Einfügen");
            this.mnuEditDelete.Text = KissMsg.GetMLMessage("KissRTFEdit", "MnuEditDelete", "&Löschen");
            this.mnuEditSelectAll.Text = KissMsg.GetMLMessage("KissRTFEdit", "MnuEditSelectAll", "A&lles auswählen");

            EditMode = EditModeType.Normal;
            this.Font = new Font(GuiConfig.RTFDefaultFontName,
                                 GuiConfig.RTFDefaultFontSize,
                                 GuiConfig.RTFDefaultFontStyle,
                                 GuiConfig.RTFDefaultFontGraphicUnit);
        }

        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KissRTFEdit));
            this.mnuEdit = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuEditUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSeparator01 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSeparator02 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit.SuspendLayout();
            this.SuspendLayout();
            //
            // mnuEdit
            //
            this.mnuEdit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditUndo,
            this.mnuEditRedo,
            this.mnuEditSeparator01,
            this.mnuEditCut,
            this.mnuEditCopy,
            this.mnuEditPaste,
            this.mnuEditDelete,
            this.mnuEditSeparator02,
            this.mnuEditSelectAll});
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(179, 170);
            //
            // mnuEditUndo
            //
            this.mnuEditUndo.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditUndo.Image")));
            this.mnuEditUndo.Name = "mnuEditUndo";
            this.mnuEditUndo.Size = new System.Drawing.Size(178, 22);
            this.mnuEditUndo.Text = "&Rückgängig";
            this.mnuEditUndo.Click += new System.EventHandler(this.mnuEditUndo_Click);
            //
            // mnuEditSeparator01
            //
            this.mnuEditSeparator01.Name = "mnuEditSeparator01";
            this.mnuEditSeparator01.Size = new System.Drawing.Size(175, 6);
            //
            // mnuEditCut
            //
            this.mnuEditCut.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditCut.Image")));
            this.mnuEditCut.Name = "mnuEditCut";
            this.mnuEditCut.Size = new System.Drawing.Size(178, 22);
            this.mnuEditCut.Text = "&Ausschneiden";
            this.mnuEditCut.Click += new System.EventHandler(this.mnuEditCut_Click);
            //
            // mnuEditCopy
            //
            this.mnuEditCopy.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditCopy.Image")));
            this.mnuEditCopy.Name = "mnuEditCopy";
            this.mnuEditCopy.Size = new System.Drawing.Size(178, 22);
            this.mnuEditCopy.Text = "&Kopieren";
            this.mnuEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
            //
            // mnuEditPaste
            //
            this.mnuEditPaste.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditPaste.Image")));
            this.mnuEditPaste.Name = "mnuEditPaste";
            this.mnuEditPaste.Size = new System.Drawing.Size(178, 22);
            this.mnuEditPaste.Text = "&Einfügen";
            this.mnuEditPaste.Click += new System.EventHandler(this.mnuEditPaste_Click);
            //
            // mnuEditDelete
            //
            this.mnuEditDelete.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditDelete.Image")));
            this.mnuEditDelete.Name = "mnuEditDelete";
            this.mnuEditDelete.Size = new System.Drawing.Size(178, 22);
            this.mnuEditDelete.Text = "&Löschen";
            this.mnuEditDelete.Click += new System.EventHandler(this.mnuEditDelete_Click);
            //
            // mnuEditSeparator02
            //
            this.mnuEditSeparator02.Name = "mnuEditSeparator02";
            this.mnuEditSeparator02.Size = new System.Drawing.Size(175, 6);
            //
            // mnuEditSelectAll
            //
            this.mnuEditSelectAll.Name = "mnuEditSelectAll";
            this.mnuEditSelectAll.Size = new System.Drawing.Size(178, 22);
            this.mnuEditSelectAll.Text = "A&lles auswählen";
            this.mnuEditSelectAll.Click += new System.EventHandler(this.mnuEditSelectAll_Click);
            //
            // mnuEditRedo
            //
            this.mnuEditRedo.Image = ((System.Drawing.Image)(resources.GetObject("mnuEditRedo.Image")));
            this.mnuEditRedo.Name = "mnuEditRedo";
            this.mnuEditRedo.Size = new System.Drawing.Size(178, 22);
            this.mnuEditRedo.Text = "&Wiederherstellen";
            this.mnuEditRedo.Click += new System.EventHandler(this.mnuEditRedo_Click);
            //
            // KissRTFEdit
            //
            this.ContextMenuStrip = this.mnuEdit;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.KissRTFEdit_MouseUp);
            this.mnuEdit.ResumeLayout(false);
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
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [edit value changed].
        /// </summary>
        public event System.EventHandler EditValueChanged;

        /// <summary>
        /// Occurs when [enter key].
        /// </summary>
        public event KeyEventHandler EnterKey
        {
            add { onEnterKey += value; }
            remove { onEnterKey -= value; }
        }

        private event KeyEventHandler onEnterKey;

        #endregion

        #region Properties

        [Browsable(true)]
        [DefaultValue("")]
        public string DataMember
        {
            get { return dataMember; }
            set { dataMember = value; }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        /// <summary>
        /// Liest oder setzt den EditMode
        /// </summary>
        /// <value></value>
        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        public EditModeType EditMode
        {
            get { return editMode; }
            set
            {
                editMode = value;
                if (editMode == EditModeType.ReadOnly)
                {
                    this.ReadOnly = true;
                    this.BackColor = GuiConfig.PanelColor;
                }
                else
                {
                    this.ReadOnly = false;
                    this.BackColor = Color.White;
                }
            }
        }

        /// <summary>
        /// Gets or sets the edit value.
        /// </summary>
        /// <value>The edit value.</value>
        [Browsable(false)]
        [DefaultValue(null)]
        public object EditValue
        {
            get
            {
                if (DesignMode && dataSource != null && dataMember != "")
                {
                    return null;
                }

                if (base.Rtf == null || (base.Text == "" && base.Rtf.Length < 200))
                {
                    return DBNull.Value;
                }
                else
                {
                    return base.Rtf;
                }
            }
            set
            {
                try
                {
                    //only assign the value if it is different from the current value
                    string valueString = (value == null || value == DBNull.Value) ? null : value.ToString().Trim();
                    string rtfString = (base.Rtf == null) ? null : base.Rtf.Trim();
                    if (rtfString != valueString)
                    {
                        base.Rtf = (value == null || value == DBNull.Value) ? null : value.ToString();
                    }
                }
                catch (Exception ex)
                {
                    base.Text = (value == null || value == DBNull.Value) ? "" : value.ToString();
                    if (DBUtil.IsEmpty(value))
                    {
                        _logger.Warn("Empty", ex);
                    }
                    else
                    {
                        _logger.Warn(value.ToString(), ex);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the enter key event.
        /// </summary>
        /// <value>The enter key event.</value>
        public KeyEventHandler EnterKeyEvent
        {
            get { return onEnterKey; }
        }

        /// <summary>
        /// Gets or sets the current text in the rich text box.
        /// </summary>
        /// <value></value>
        /// <returns>The text displayed in the control.</returns>
        [Browsable(true)]
        [DefaultValue("")]
        public override string Text
        {
            get
            {
                if (DesignMode && dataSource != null && dataMember != "")
                {
                    return string.Empty;
                }

                return base.Text;
            }
            set { base.Text = value; }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// The MouseUp event on KissRTFEdit, used to popup the context-menu
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The <see cref="MouseEventArgs"/> of the event</param>
        private void KissRTFEdit_MouseUp(object sender, MouseEventArgs e)
        {
            // example from: http://forums.msdn.microsoft.com/en-US/vbgeneral/thread/327847d0-ac59-4596-b2f7-a88c1dc8fc61/

            // show contextmenu on rightclick
            if (e.Button == MouseButtons.Right)
            {
                // setup menu-enabled/disabled
                this.mnuEditUndo.Enabled = this.CanUndo;
                this.mnuEditRedo.Enabled = this.CanRedo;
                this.mnuEditCut.Enabled = this.SelectedText.Length > 0;
                this.mnuEditCopy.Enabled = this.SelectedText.Length > 0;
                this.mnuEditPaste.Enabled = Clipboard.ContainsText();
                this.mnuEditDelete.Enabled = this.SelectedText.Length > 0;
                this.mnuEditSelectAll.Enabled = this.Text.Length > 0;
            }
        }

        /// <summary>
        /// Handle the menu item copy, copy selected text to clipboard
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void mnuEditCopy_Click(object sender, EventArgs e)
        {
            this.Copy();
        }

        /// <summary>
        /// Handle the menu item cut, cut selected text to clipboard
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void mnuEditCut_Click(object sender, EventArgs e)
        {
            this.Cut();
        }

        /// <summary>
        /// Handle the menu item delete, delete selected text
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void mnuEditDelete_Click(object sender, EventArgs e)
        {
            this.SelectedText = "";
        }

        /// <summary>
        /// Handle the menu item paste, paste given text from clipboard to cursor position
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void mnuEditPaste_Click(object sender, EventArgs e)
        {
            this.Paste();
        }

        /// <summary>
        /// Handle the menu item redo, redo last undone action
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void mnuEditRedo_Click(object sender, EventArgs e)
        {
            this.Redo();
        }

        /// <summary>
        /// Handle the menu item select all, select all text within textbox
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void mnuEditSelectAll_Click(object sender, EventArgs e)
        {
            this.SelectionStart = 0;
            this.SelectionLength = this.Text.Length;
        }

        /// <summary>
        /// Handle the menu item undo, undo last action
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void mnuEditUndo_Click(object sender, EventArgs e)
        {
            this.Undo();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Get total amount of lines displayed in textbox
        /// </summary>
        /// <returns>Total amount of lines starting with 1 or -1 on exception</returns>
        public int GetLineCount()
        {
            try
            {
                Message m = Message.Create(this.Handle, EM_GETLINECOUNT, new IntPtr(0), new IntPtr(0));
                base.WndProc(ref m);
                return m.Result.ToInt32();
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);
                return -1;
            }
        }

        /// <summary>
        /// Jump to specific line number
        /// </summary>
        /// <param name="lineNumber">The line number to jump to (counting from 1)</param>
        public void GotoLine(int lineNumber)
        {
            try
            {
                // validate first
                if (lineNumber > this.GetLineCount())
                {
                    lineNumber = this.GetLineCount();
                }

                // subtract one
                lineNumber--;

                if (lineNumber < 0)
                {
                    lineNumber = 0;
                }

                // jump to line
                Message m = Message.Create(this.Handle, EM_LINEINDEX, new IntPtr(lineNumber), new IntPtr(0));
                base.WndProc(ref m);
                this.SelectionStart = m.Result.ToInt32();
                this.SelectionLength = 0;
                this.Focus();
                this.ScrollToCaret();
            }
            catch (Exception ex)
            {
                // stop here if debugger is available
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }

                // show error message
                KissMsg.ShowError("KissRTFEdit", "ErrorGotoLine", "Das Springen zu der gewünschten Zeile ist fehlgeschlagen.", ex);
                _logger.Warn(ex);
            }
        }

        /// <summary>
        /// Gets a value indicating whether editing is allowed.
        /// </summary>
        /// <param name="value"></param>
        void IKissBindableEdit.AllowEdit(bool value)
        {
            if (editMode != EditModeType.ReadOnly)
            {
                if (value)
                {
                    this.ReadOnly = false;
                    this.BackColor = Color.White;
                }
                else
                {
                    this.ReadOnly = true;
                    this.BackColor = GuiConfig.EditColorReadOnly;
                }
            }
        }

        /// <summary>
        /// Gets the name of the bindable property.
        /// </summary>
        /// <returns></returns>
        string IKissBindableEdit.GetBindablePropertyName()
        {
            return "EditValue";
        }

        /// <summary>
        /// Opens the editor dialog.
        /// </summary>
        public void OpenEditorDialog()
        {
            if (this.Parent is DlgRTFEdit)
            {
                return;
            }

            DlgRTFEdit dlg = new DlgRTFEdit(ReadOnly);
            dlg.RTFEditor.EditValue = EditValue;

            // BugFix: #6282 - prevent applying EditValue if control is ReadOnly to prevent changing empty rtf formatting
            if (dlg.ShowDialog() == DialogResult.OK && !ReadOnly)
            {
                EditValue = dlg.RTFEditor.EditValue;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.DoubleClick"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnDoubleClick(System.EventArgs e)
        {
            OpenEditorDialog();
        }

        /// <summary>
        /// Called when [enter key].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected virtual void OnEnterKey(object sender, KeyEventArgs e)
        {
            if (onEnterKey != null)
            {
                onEnterKey(sender, e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyDown"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyEventArgs"></see> that contains the event data.</param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            // with F12, we open the editor-dialog
            if (e.KeyCode == Keys.F12)
            {
                OpenEditorDialog();
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Return)
            {
                OnEnterKey(this, e);
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:TextChanged"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);

            if (EditValueChanged != null)
            {
                EditValueChanged(this, e);
            }
        }

        /// <summary>
        /// Overrides the windows messages handler.
        /// </summary>
        /// <param name="m">The message</param>
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == WM_VSCROLL && (short)m.WParam == SB_THUMBTRACK)
            {
                // handle vscroll event even when scrolling with scrollbar
                base.OnVScroll(EventArgs.Empty);
            }

            base.WndProc(ref m);
        }

        #endregion

        #endregion
    }
}