using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Kiss.Interfaces.UI;
using KiSS4.DB;

namespace KiSS4.Gui
{
    /// <summary>
    /// Summary description for KissTextEdit.
    /// </summary>
    public class KissCheckEdit : DevExpress.XtraEditors.CheckEdit, IKissBindableEdit, IKissEditable, IKissUserModified
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private event KeyEventHandler onEnterKey;
        private EditModeType editMode = EditModeType.Normal;
        private SqlQuery dataSource;
        private string dataMember = string.Empty;

        /// <summary>
        /// The center square color.
        /// </summary>
        public Color CenterSquareColor = Color.Transparent;

        private Bitmap CheckGlyph;
        private Bitmap Indeterminate;

        /// <summary>
        /// Initializes a new instance of the <see cref="KissCheckEdit"/> class.
        /// </summary>
        public KissCheckEdit()
        {
            this.BackColor = Color.Transparent;
            this.CheckGlyph = new Bitmap(this.GetType().Assembly.GetManifestResourceStream("KiSS4.Gui.checkbox.bmp"));
            this.Indeterminate = new Bitmap(this.GetType().Assembly.GetManifestResourceStream("KiSS4.Gui.checkbox_indeterminate.bmp"));
            Color TransparentColor = this.CheckGlyph.GetPixel(1, 1);
            this.CheckGlyph.MakeTransparent(TransparentColor);
            this.Indeterminate.MakeTransparent(TransparentColor);
        }

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int y = (this.Height / 2) - 4;
            int x = 5;
            if (this.Properties.GlyphAlignment.Equals(DevExpress.Utils.HorzAlignment.Far))
                x = this.Width - 14;
            else
                if (this.Properties.GlyphAlignment.Equals(DevExpress.Utils.HorzAlignment.Center))
                    x = (this.Width / 2) - 5;
            Rectangle CenterSquare = new Rectangle(x, y, 9, 9);
            e.Graphics.FillRectangle(new SolidBrush(this.CenterSquareColor), CenterSquare);
            switch (this.CheckState)
            {
                case CheckState.Checked:
                    e.Graphics.DrawImage(CheckGlyph, CenterSquare);
                    break;
                case CheckState.Indeterminate:
                    if (this.Properties.AllowGrayed)
                        e.Graphics.DrawImage(Indeterminate, CenterSquare);
                    else
                        e.Graphics.DrawImage(CheckGlyph, CenterSquare);
                    break;
                default:
                    //do nothing
                    break;
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
        /// Occurs when [enter key].
        /// </summary>
        public event KeyEventHandler EnterKey
        {
            add { onEnterKey += value; }
            remove { onEnterKey -= value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Loaded()
        {
            OnLoaded();
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        protected override void OnLoaded()
        {
            base.OnLoaded();
            GuiConfig.SetEditMode(this, EditMode);
        }

        /// <summary>
        /// Raises the <see cref="E:KeyDown"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) OnEnterKey(this, e);
            base.OnKeyDown(e);
        }

        /// <summary>
        /// Called when [enter key].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        protected virtual void OnEnterKey(object sender, KeyEventArgs e)
        {
            if (onEnterKey != null) onEnterKey(sender, e);
        }

        /// <summary>
        /// Raises the <see cref="E:GotFocus"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected override void OnGotFocus(System.EventArgs e)
        {
            base.OnGotFocus(e);
            SelectAll();
        }

        #region IKissUserModified

        private object saveEditValue;
        private bool userModified;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UserModified
        {
            get { return userModified || EditValue == null ? saveEditValue != null : !EditValue.Equals(saveEditValue); }
            set { if (value) userModified = true; else saveEditValue = EditValue; }
        }

        public void CancelEdit()
        {
            this.EditValue = saveEditValue;
            userModified = false;
        }

        /// <summary>
        /// Gets or sets the check edit control's edited value.
        /// </summary>
        /// <value>
        /// An <see cref="T:System.Object"/> value representing the editor's edited value.
        /// </value>
        [Browsable(true)]
        [DefaultValue(null)]
        new public object EditValue
        {
            get
            {
                if (DesignMode && dataSource != null && dataMember != "") return null;
                return base.EditValue;
            }
            set
            {
                saveEditValue = value;
                userModified = false;

                base.EditValue = value;
            }
        }
        #endregion

        /// <summary>
        /// Liest oder setzt den EditMode
        /// </summary>
        /// <value></value>
        [Browsable(true)]
        [DefaultValue(EditModeType.Normal)]
        public EditModeType EditMode
        {
            get { return editMode; }
            set { editMode = value; GuiConfig.SetEditMode(this, editMode); }
        }

        #region IKissBindableEdit

        [Browsable(true)]
        [DefaultValue(null)]
        public SqlQuery DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        [Browsable(true)]
        [DefaultValue("")]
        public string DataMember
        {
            get { return dataMember; }
            set { dataMember = value; }
        }

        string IKissBindableEdit.GetBindablePropertyName()
        {
            return "EditValue";
        }

        void IKissBindableEdit.AllowEdit(bool value)
        {
            if (editMode != EditModeType.ReadOnly)
            {
                if (value)
                    GuiConfig.SetEditMode(this, editMode);
                else
                    GuiConfig.SetEditMode(this, EditModeType.ReadOnly);
            }
        }
        #endregion

    }
}
