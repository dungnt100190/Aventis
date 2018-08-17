using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.DB;

namespace KiSS4.GraphLib
{
    /// <summary>
    /// Container for displaying a <see cref="Graph"/>.
    /// </summary>
    public class GraphDisplay : System.Windows.Forms.UserControl
    {
        private const float zoomInFactor = 1.25f;
        private const float zoomOutFactor = 1f / zoomInFactor;

        private bool _errorReported = false;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        private GraphDrawing drawing;
        private Graph graph;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.ContextMenu mnuPopup;
        private System.Windows.Forms.MenuItem mnuPrint;
        private System.Windows.Forms.MenuItem mnuZoomIn;
        private System.Windows.Forms.MenuItem mnuZoomOut;
        private ToolTip toolTip;
        private float zoom = 1f;

        /// <summary>
        /// Initialize.
        /// </summary>
        public GraphDisplay()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();

            this.toolTip = new ToolTip();
            this.toolTip.ShowAlways = true;

            // Multilanguage
            this.mnuPrint.Text = KissMsg.GetMLMessage("GraphDisplay", "PopupDrucken", "Drucken...");
            this.mnuZoomIn.Text = KissMsg.GetMLMessage("GraphDisplay", "PopupZoomIn", "Zoom In");
            this.mnuZoomOut.Text = KissMsg.GetMLMessage("GraphDisplay", "PopupZoomOut", "Zoom Out");
        }

        /// <summary>
        /// Gets or sets the <see cref="Graph"/> to display.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        public Graph Graph
        {
            get { return this.graph; }
            set
            {
                // clear
                this.graph = null;
                this.drawing = null;
                this.AutoScrollMinSize = new Size();
                this.mouseItem = null;
                this.mnuPrint.Enabled = false;

                if (value != null)
                {
                    this.graph = value;
                    this.mnuPrint.Enabled = true;
                }

                this.Invalidate();
            }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        [Browsable(false)]
        [DefaultValue(null)]
        public DisplayItem SelectedItem
        {
            get { return this.drawing == null ? null : this.drawing.SelectedItem; }
            set
            {
                if (this.drawing != null)
                {
                    this.drawing.SelectedItem = value;
                }
            }
        }

        /// <summary>
        /// Gets the <see cref="DisplayItem"/> that was created for the specified <see cref="GraphItem"/>.
        /// </summary>
        public DisplayItem GetDisplayOf(GraphItem gi)
        {
            if (this.drawing != null)
                return this.drawing.GetDisplayOf(gi);
            else
                return null;
        }

        /// <summary>
        /// Zooms the drawing to the specified factor (absolute).
        /// </summary>
        public void Zoom(float zoomFactor)
        {
            if (this.drawing != null)
                this.drawing.Zoom(zoomFactor);
        }

        /// <summary>
        /// Zooms the drawing to the specified factor (relative).
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">zoomFactor is non-positive.</exception>
        public void ZoomBy(float zoomFactor)
        {
            if (zoomFactor <= 0) throw new ArgumentOutOfRangeException("zoomFactor", "must be positive");

            if (this.drawing != null)
            {
                Size minSize = this.drawing.MinSize;
                Size maxSize = this.drawing.MaxSize;
                Size size = this.drawing.Size;

                if (zoomFactor < 1 && (size.Width > minSize.Width || size.Height > minSize.Height) ||
                    zoomFactor > 1 && (size.Width < maxSize.Width || size.Height < maxSize.Height))
                    this.zoom *= zoomFactor;
                this.drawing.Zoom(this.zoom);
            }
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuPopup = new System.Windows.Forms.ContextMenu();
            this.mnuPrint = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.mnuZoomIn = new System.Windows.Forms.MenuItem();
            this.mnuZoomOut = new System.Windows.Forms.MenuItem();
            //
            // mnuPopup
            //
            this.mnuPopup.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                                     this.mnuPrint,
                                                                                     this.menuItem3,
                                                                                     this.mnuZoomIn,
                                                                                     this.mnuZoomOut});
            //
            // mnuPrint
            //
            this.mnuPrint.Enabled = false;
            this.mnuPrint.Index = 0;
            this.mnuPrint.Click += new System.EventHandler(this.mnuPrint_Click);
            //
            // menuItem3
            //
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "-";
            //
            // mnuZoomIn
            //
            this.mnuZoomIn.Index = 2;
            this.mnuZoomIn.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.mnuZoomIn.Click += new System.EventHandler(this.mnuZoomIn_Click);
            //
            // mnuZoomOut
            //
            this.mnuZoomOut.Index = 3;
            this.mnuZoomOut.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftZ;
            this.mnuZoomOut.Click += new System.EventHandler(this.mnuZoomOut_Click);
            //
            // GraphDisplay
            //
            this.Name = "GraphDisplay";
            this.Size = new System.Drawing.Size(150, 90);
            this.DoubleClick += new System.EventHandler(this.GraphDisplay_DoubleClick);
        }

        #endregion

        /// <summary>
        /// Paint the drawing.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);

                if (this.graph == null) return;
                if (this.drawing == null)
                {
                    this.drawing = new GraphDrawing(this, this.Graph, e.Graphics, false);
                    this.drawing.DrawingSizeChanged += new EventHandler(drawing_DrawingSizeChanged);
                    this.AutoScrollMinSize = this.drawing.Size;
                }

                this.Recalc();
                if (this.drawing != null)
                    this.drawing.Paint(e);
            }
            catch (InvalidOperationException ioe)
            {
                // zeige Fehlermeldung nur an, wenn das Control den Focus hat und nur das erste Mal. Sonst wird die Fehlermeldung auch bei jedem Fenster-Wechsel angezeigt
                if (!_errorReported && this.Focused)
                {
                    _errorReported = true;
                    KissMsg.ShowError("GraphDisplay", "Datenfehler", "Das Sozialsystem kann aufgrund eines Datenfehlers nicht dargestellt werden.", ioe);
                }
            }
        }

        /// <summary>
        /// Relocate the drawing based on the current scroll bar positions.
        /// </summary>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Recalc();
        }

        private void drawing_DrawingSizeChanged(object sender, EventArgs e)
        {
            this.AutoScrollMinSize = this.drawing.Size;
            this.Invalidate();
        }

        private void mnuPrint_Click(object sender, System.EventArgs e)
        {
            if (this.Graph == null) return;
            this.OnPrint(EventArgs.Empty);
        }

        private void mnuZoomIn_Click(object sender, System.EventArgs e)
        {
            this.ZoomBy(zoomInFactor);
        }

        private void mnuZoomOut_Click(object sender, System.EventArgs e)
        {
            this.ZoomBy(zoomOutFactor);
        }

        private void Recalc()
        {
            if (this.drawing != null)
            {
                this.drawing.Location = this.AutoScrollPosition;
                if (this.mouseInThis)
                    this.mouseItem = this.drawing.HitTest(this.mousePos);

                string ttt = null;
                if (this.mouseItem != null)
                    ttt = this.mouseItem.ToolTipText(this.mousePos);
                if (ttt != this.toolTip.GetToolTip(this))
                    this.toolTip.SetToolTip(this, ttt);
            }
        }

        #region Key handling

        /// <summary>
        /// Make left, right, up and down make input keys in order to scroll with these keys.
        /// </summary>
        protected override bool IsInputKey(Keys keyData)
        {
            // make arrow keys to be input key
            switch (keyData)
            {
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        /// <summary>
        /// Handles the following keys: left, right, up, down, ctrl+z, shift+ctrl+z. Otherwise forwards the key to the selected item.
        /// </summary>
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.Handled) return;

            const int smallScroll = 5;

            int scrollH = 0;
            int scrollV = 0;

            switch (e.KeyCode)
            {
                case Keys.Left:
                    scrollH = e.Control ? -this.ClientSize.Width : -smallScroll;
                    e.Handled = true;
                    break;

                case Keys.Right:
                    scrollH = e.Control ? +this.ClientSize.Width : +smallScroll;
                    e.Handled = true;
                    break;

                case Keys.Up:
                    scrollV = e.Control ? -this.ClientSize.Height : -smallScroll;
                    e.Handled = true;
                    break;

                case Keys.Down:
                    scrollV = e.Control ? +this.ClientSize.Height : +smallScroll;
                    e.Handled = true;
                    break;

                case Keys.Z:
                    if (e.Modifiers == Keys.Control)
                    {
                        this.ZoomBy(zoomInFactor);
                        e.Handled = true;
                    }
                    else if (e.Modifiers == (Keys.Control | Keys.Shift))
                    {
                        e.Handled = true;
                        this.ZoomBy(zoomOutFactor);
                    }
                    break;
            }

            if (scrollH != 0 || scrollV != 0)
            {
                Point p = this.AutoScrollPosition;
                p.X = -p.X + scrollH;
                p.Y = -p.Y + scrollV;
                this.AutoScrollPosition = p;
            }

            if (!e.Handled && this.SelectedItem != null)
                this.SelectedItem.OnKeyDown(e);
        }

        #endregion

        #region Mouse handling

        private bool mouseInThis;
        private DisplayItem mouseItem;
        private Point mousePos;

        /// <summary>
        /// Select the item under cursor (left button), or show popup (right button).
        /// </summary>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
                this.SelectedItem = this.mouseItem;
            else if (e.Button == MouseButtons.Right)
                this.mnuPopup.Show(this, new Point(e.X, e.Y));
        }

        /// <summary>
        /// Used internally.
        /// </summary>
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.mouseInThis = true;
        }

        /// <summary>
        /// Used internally.
        /// </summary>
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.mouseInThis = false;
            this.mouseItem = null;
        }

        /// <summary>
        /// Used internally.
        /// </summary>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            this.mousePos = new Point(e.X, e.Y);
            this.Recalc();
        }

        /// <summary>
        /// Zooms the drawing in and out.
        /// </summary>
        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);

            if (e.Delta > 0)
                this.ZoomBy(zoomInFactor);
            else if (e.Delta < 0)
                this.ZoomBy(zoomOutFactor);
        }

        /// <summary>
        /// Select the item under cursor (left button), or show popup (right button).
        /// </summary>
        private void GraphDisplay_DoubleClick(object sender, System.EventArgs e)
        {
            if (this.mouseItem == null) return;
            //raise DoubleClick event on DisplyItem
            this.mouseItem.OnDoubleClick(EventArgs.Empty);
        }

        #endregion

        #region Print event

        /// <summary>
        /// Occurs when the print command is selected via popup menu.
        /// </summary>
        public event EventHandler Print;

        /// <summary>
        /// Raises the <see cref="Print"/> event.
        /// </summary>
        /// <remarks>Inheritors should call the base method in order to raise the event.</remarks>
        protected virtual void OnPrint(EventArgs e)
        {
            if (this.Print != null)
                this.Print(this, e);
        }

        #endregion
    }
}