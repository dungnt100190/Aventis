#region Header

/*

    Windows Forms Collapsible Splitter Control for .Net
    (c)Copyright 2002-2003 NJF (furty74@yahoo.com). All rights reserved.

    URL: http://www.codeproject.com/cs/miscctrl/collapsiblesplitter.asp

    This control is free for use in both commercial and freeware applications, however you are not allowed
    to include this control as part of a control library, or any other form that would allow you to profit
    directly from the control's primary functionality. If you would like to include this control as part of a
    commercial control library, please contact me via http://www.codeshack.net

    The origin of the control must not be mis-represented, and any applications that utilize the control must have
    contain the following Copyright notice in the About screen or Help documentation:
    (c) Copyright 2003-2004 CodeShack (www.codeshack.net)

    The name of the author must not be used in a way that could be construed as an endorsement of your product or application.
    Finally, if you enhance this free control, you are requested to send the updated source code to me so that I can consider
    your improvements for public redistribution. In this case you agree to transfer all rights for your additions or changes
    to me so that I can re-release the control using this license.
*/

#endregion

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KiSS4.Gui
{
    #region Enumerations

    /// <summary>
    /// Enumeration to specify the current animation state of the control.
    /// </summary>
    public enum SplitterState
    {
        /// <summary>
        /// Collapsed.
        /// </summary>
        Collapsed = 0,

        /// <summary>
        /// Expanding.
        /// </summary>
        Expanding,

        /// <summary>
        /// Expanded.
        /// </summary>
        Expanded,

        /// <summary>
        /// Collapsing.
        /// </summary>
        Collapsing
    }

    /// <summary>
    /// Enumeration to sepcify the visual style to be applied to the CollapsibleSplitter control
    /// </summary>
    public enum VisualStyles
    {
        /// <summary>
        /// Mozilla style.
        /// </summary>
        Mozilla = 0,

        /// <summary>
        /// Windows XP style.
        /// </summary>
        XP,

        /// <summary>
        /// Windows 95/98 Style.
        /// </summary>
        Win9x,

        /// <summary>
        /// Double dots.
        /// </summary>
        DoubleDots,

        /// <summary>
        /// Lines.
        /// </summary>
        Lines
    }

    #endregion

    /// <summary>
    /// A custom collapsible splitter that can resize, hide and show associated form controls
    /// </summary>
    [ToolboxBitmap(typeof(KissSplitterCollapsible))]
    [DesignerAttribute(typeof(KissSplitterCollapsibleDesigner))]
    public class KissSplitterCollapsible : KissSplitter
    {
        #region Fields

        #region Private Fields

        private int animationDelay = 20;
        private int animationStep = 20;

        // animation controls
        private System.Windows.Forms.Timer animationTimer;

        private System.Windows.Forms.Border3DStyle borderStyle = System.Windows.Forms.Border3DStyle.Etched;
        private int controlHeight;
        private System.Windows.Forms.Control controlToHide;
        private int controlWidth;
        private SplitterState currentState;
        private bool expandParentForm;

        // declare and define some base properties
        private bool hot;

        private System.Drawing.Color hotColor = System.Drawing.Color.Bisque; //CalculateColor(SystemColors.Highlight, SystemColors.Window, 70);
        private System.Drawing.Color hotColorBg = System.Drawing.Color.FromArgb(((System.Byte)(250)), ((System.Byte)(248)), ((System.Byte)(239)));

        private System.Windows.Forms.Form parentForm;
        private int parentFormHeight;
        private int parentFormWidth;
        private System.Drawing.Rectangle rr;
        private bool useAnimations;
        private VisualStyles visualStyle = VisualStyles.Mozilla;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissSplitterCollapsible"/> class.
        /// </summary>
        public KissSplitterCollapsible()
        {
            if (GuiConfig.Theme != GuiConfig.KissTheme.None)
            {
                hotColor = GuiConfig.colBack04;
                hotColorBg = GuiConfig.colBack02;
            }

            // Register mouse events
            this.Click += new System.EventHandler(OnClick);
            this.Resize += new System.EventHandler(OnResize);
            this.MouseLeave += new System.EventHandler(OnMouseLeave);
            this.MouseMove += new MouseEventHandler(OnMouseMove);

            // Setup the animation timer control
            this.animationTimer = new System.Windows.Forms.Timer();
            this.animationTimer.Interval = animationDelay;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimerTick);
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            // Unregister mouse events
            this.Click -= new System.EventHandler(OnClick);
            this.Resize -= new System.EventHandler(OnResize);
            this.MouseLeave -= new System.EventHandler(OnMouseLeave);
            this.MouseMove -= new MouseEventHandler(OnMouseMove);

            base.Dispose(disposing);
        }

        #endregion

        #region Events

        /// <summary>
        /// The event that is raised when the splitter was collapsed
        /// </summary>
        public event EventHandler SplitterCollapsed;

        /// <summary>
        /// The event that is raised when the splitter was expanded
        /// </summary>
        public event EventHandler SplitterExpanded;

        #endregion

        #region Properties

        /// <summary>
        /// The delay in millisenconds between animation steps
        /// </summary>
        [Bindable(true),
        Category("Collapsing Options"),
        DefaultValue("20"),
        Description("The delay in millisenconds between animation steps")]
        public int AnimationDelay
        {
            get { return this.animationDelay; }
            set { this.animationDelay = value; }
        }

        /// <summary>
        /// The amount of pixels moved in each animation step
        /// </summary>
        [Bindable(true),
        Category("Collapsing Options"),
        DefaultValue("20"),
        Description("The amount of pixels moved in each animation step")]
        public int AnimationStep
        {
            get { return this.animationStep; }
            set { this.animationStep = value; }
        }

        /// <summary>
        /// An optional border style to paint on the control. Set to Flat for no border
        /// </summary>
        [Bindable(true),
        Category("Collapsing Options"),
        DefaultValue("System.Windows.Forms.Border3DStyle.Etched"),
        Description("An optional border style to paint on the control. Set to Flat for no border")]
        public System.Windows.Forms.Border3DStyle BorderStyle3D
        {
            get { return this.borderStyle; }
            set
            {
                this.borderStyle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// The System.Windows.Forms.Control that the splitter will collapse
        /// </summary>
        [Bindable(true),
        Category("Collapsing Options"),
        DefaultValue(""),
        Description("The System.Windows.Forms.Control that the splitter will collapse")]
        public System.Windows.Forms.Control ControlToHide
        {
            get { return this.controlToHide; }
            set { this.controlToHide = value; }
        }

        /// <summary>
        /// When true the entire parent form will be expanded and collapsed, otherwise just the contol to expand will be changed
        /// </summary>
        [Bindable(true),
        Category("Collapsing Options"),
        DefaultValue("False"),
        Description("When true the entire parent form will be expanded and collapsed, otherwise just the contol to expand will be changed")]
        public bool ExpandParentForm
        {
            get { return this.expandParentForm; }
            set { this.expandParentForm = value; }
        }

        /// <summary>
        /// The initial state of the Splitter. Set to True if the control to hide is not visible by default
        /// </summary>
        [Bindable(true),
        Category("Collapsing Options"),
        DefaultValue("False"),
        Description("The initial state of the Splitter. Set to True if the control to hide is not visible by default")]
        public bool IsCollapsed
        {
            get
            {
                if (this.controlToHide != null)
                    return !this.controlToHide.Visible;
                else
                    return true;
            }
        }

        /// <summary>
        /// Determines if the collapse and expanding actions will be animated
        /// </summary>
        [Bindable(true),
        Category("Collapsing Options"),
        DefaultValue("True"),
        Description("Determines if the collapse and expanding actions will be animated")]
        public bool UseAnimations
        {
            get { return this.useAnimations; }
            set { this.useAnimations = value; }
        }

        /// <summary>
        /// The visual style that will be painted on the control
        /// </summary>
        [Bindable(true),
        Category("Collapsing Options"),
        DefaultValue("VisualStyles.Mozilla"),
        Description("The visual style that will be painted on the control")]
        public VisualStyles VisualStyle
        {
            get { return this.visualStyle; }
            set
            {
                this.visualStyle = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// Get and set current splitter state
        /// </summary>
        private SplitterState CurrentState
        {
            get { return currentState; }
            set
            {
                // apply value
                currentState = value;

                // raise events (if assigned)
                if (currentState == SplitterState.Collapsed && SplitterCollapsed != null)
                {
                    // fire event for collapsed splitter
                    SplitterCollapsed(this, EventArgs.Empty);
                }
                else if (currentState == SplitterState.Expanded && SplitterExpanded != null)
                {
                    // fire event for expanded splitter
                    SplitterExpanded(this, EventArgs.Empty);
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Toggles the splitter state.
        /// </summary>
        public void ToggleState()
        {
            this.ToggleSplitter();
        }

        /// <summary>
        /// Expands the splitter if not already expanded.
        /// </summary>
        public void Expand()
        {
            if (currentState == SplitterState.Expanded || currentState == SplitterState.Expanding)
            {
                return;
            }
            else
            {
                this.ToggleSplitter();
            }
        }

        /// <summary>
        /// Collapses the splitter if not already collapsed.
        /// </summary>
        public void Collapse()
        {
            if (currentState == SplitterState.Collapsed || currentState == SplitterState.Collapsing)
            {
                return;
            }
            else
            {
                this.ToggleSplitter();
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// The DoubleClick event, used to reset the splitter position to inital value
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected override void OnDoubleClick(System.EventArgs e)
        {
            // handle doubleclick only if not collapsed
            if (!this.IsCollapsed)
            {
                // not collapsed, do the resetting
                base.OnDoubleClick(e);
            }
            else
            {
                // collapsed, just uncollapse on doubleclicking
                ToggleSplitter();
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.EnabledChanged"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnEnabledChanged(System.EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.Invalidate();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.HandleCreated"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.parentForm = this.FindForm();

            // set the current state
            if (this.controlToHide != null)
            {
                if (this.controlToHide.Visible)
                {
                    CurrentState = SplitterState.Expanded;
                }
                else
                {
                    CurrentState = SplitterState.Collapsed;
                }
            }
        }

        /// <summary>
        /// The MouseDown event, used to collapse or move splitter
        /// </summary>
        /// <param name="e">The event arguements</param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // if the hider control isn't hot, let the base resize action occur
            if (this.controlToHide != null)
            {
                if (!this.hot && this.controlToHide.Visible)
                {
                    base.OnMouseDown(e);
                }
            }
        }

        /// <summary>
        /// The MouseUp event, used to reset splitter
        /// </summary>
        /// <param name="e">The event arguements</param>
        protected override void OnMouseUp(System.Windows.Forms.MouseEventArgs e)
        {
            if (this.IsCollapsed)
            {
                if (e.Button == MouseButtons.Right)
                {
                    // on rightclick, uncollapse the splitter and reset position
                    ToggleSplitter();
                    base.OnMouseUp(e);
                }
                else
                {
                    // do nothing (simulate simple left click)
                    base.OnMouseUp(new MouseEventArgs(MouseButtons.Left, e.Clicks, e.X, e.Y, e.Delta));
                }
            }
            else
            {
                base.OnMouseUp(e);
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"></see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"></see> that contains the event data.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // create a Graphics object
            Graphics g = e.Graphics;

            // calc new hotcolor depending on background
            //hotColor = CalculateColor( hotColorBg, this.BackColor, 90 );

            // find the rectangle for the splitter and paint it
            Rectangle r = this.ClientRectangle;
            g.FillRectangle(new SolidBrush(this.BackColor), r);

            #region Vertical Splitter

            // Check the docking style and create the control rectangle accordingly
            if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
            {
                // create a new rectangle in the vertical center of the splitter for our collapse control button
                rr = new Rectangle(r.X, (int)r.Y + ((r.Height - 115) / 2), 8, 115);

                // force the width to 8px so that everything always draws correctly
                this.Width = 8;

                // draw the background color for our control image
                if (hot)
                {
                    g.FillRectangle(new SolidBrush(hotColor), new Rectangle(rr.X + 1, rr.Y, 6, 115));
                }
                else
                {
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(rr.X + 1, rr.Y, 6, 115));
                }

                // draw the top & bottom lines for our control image
                g.DrawLine(new Pen(SystemColors.ControlDark, 1), rr.X + 1, rr.Y, rr.X + rr.Width - 2, rr.Y);
                g.DrawLine(new Pen(SystemColors.ControlDark, 1), rr.X + 1, rr.Y + rr.Height, rr.X + rr.Width - 2, rr.Y + rr.Height);

                if (this.Enabled)
                {
                    // draw the arrows for our control image
                    // the ArrowPointArray is a point array that defines an arrow shaped polygon
                    g.FillPolygon(new SolidBrush(SystemColors.ControlDarkDark), ArrowPointArray(rr.X + 2, rr.Y + 3));
                    g.FillPolygon(new SolidBrush(SystemColors.ControlDarkDark), ArrowPointArray(rr.X + 2, rr.Y + rr.Height - 9));
                }

                // draw the dots for our control image using a loop
                int x = rr.X + 3;
                int y = rr.Y + 14;

                // Visual Styles
                switch (visualStyle)
                {
                    case VisualStyles.Mozilla:

                        for (int i = 0; i < 30; i++)
                        {
                            // light dot
                            g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y + (i * 3), x + 1, y + 1 + (i * 3));
                            // dark dot
                            g.DrawLine(new Pen(SystemColors.ControlDarkDark), x + 1, y + 1 + (i * 3), x + 2, y + 2 + (i * 3));
                            // overdraw the background color as we actually drew 2px diagonal lines, not just dots
                            if (hot)
                            {
                                g.DrawLine(new Pen(hotColor), x + 2, y + 1 + (i * 3), x + 2, y + 2 + (i * 3));
                            }
                            else
                            {
                                g.DrawLine(new Pen(this.BackColor), x + 2, y + 1 + (i * 3), x + 2, y + 2 + (i * 3));
                            }
                        }
                        break;

                    case VisualStyles.DoubleDots:
                        for (int i = 0; i < 30; i++)
                        {
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x, y + 1 + (i * 3), 1, 1);
                            // dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDark), x - 1, y + (i * 3), 1, 1);
                            i++;
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 2, y + 1 + (i * 3), 1, 1);
                            // dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDark), x + 1, y + (i * 3), 1, 1);
                        }
                        break;

                    case VisualStyles.Win9x:

                        g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x + 2, y);
                        g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x, y + 90);
                        g.DrawLine(new Pen(SystemColors.ControlDark), x + 2, y, x + 2, y + 90);
                        g.DrawLine(new Pen(SystemColors.ControlDark), x, y + 90, x + 2, y + 90);
                        break;

                    case VisualStyles.XP:

                        for (int i = 0; i < 18; i++)
                        {
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLight), x, y + (i * 5), 2, 2);
                            // light light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 1, y + 1 + (i * 5), 1, 1);
                            // dark dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDarkDark), x, y + (i * 5), 1, 1);
                            // dark fill
                            g.DrawLine(new Pen(SystemColors.ControlDark), x, y + (i * 5), x, y + (i * 5) + 1);
                            g.DrawLine(new Pen(SystemColors.ControlDark), x, y + (i * 5), x + 1, y + (i * 5));
                        }
                        break;

                    case VisualStyles.Lines:

                        for (int i = 0; i < 44; i++)
                        {
                            g.DrawLine(new Pen(SystemColors.ControlDark), x, y + (i * 2), x + 2, y + (i * 2));
                        }

                        break;
                }

                if (this.borderStyle != System.Windows.Forms.Border3DStyle.Flat)
                {
                    // Paint the control border
                    ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this.borderStyle, Border3DSide.Left);
                    ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this.borderStyle, Border3DSide.Right);
                }
            }

            #endregion

            #region Horizontal Splitter

            else if (this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom)
            {
                // create a new rectangle in the horizontal center of the splitter for our collapse control button
                rr = new Rectangle((int)r.X + ((r.Width - 115) / 2), r.Y, 115, 8);
                // force the height to 8px
                this.Height = 8;

                // draw the background color for our control image
                if (hot)
                {
                    g.FillRectangle(new SolidBrush(hotColor), new Rectangle(rr.X, rr.Y + 1, 115, 6));
                }
                else
                {
                    g.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(rr.X, rr.Y + 1, 115, 6));
                }

                // draw the left & right lines for our control image
                g.DrawLine(new Pen(SystemColors.ControlDark, 1), rr.X, rr.Y + 1, rr.X, rr.Y + rr.Height - 2);
                g.DrawLine(new Pen(SystemColors.ControlDark, 1), rr.X + rr.Width, rr.Y + 1, rr.X + rr.Width, rr.Y + rr.Height - 2);

                if (this.Enabled)
                {
                    // draw the arrows for our control image
                    // the ArrowPointArray is a point array that defines an arrow shaped polygon
                    g.FillPolygon(new SolidBrush(SystemColors.ControlDarkDark), ArrowPointArray(rr.X + 3, rr.Y + 2));
                    g.FillPolygon(new SolidBrush(SystemColors.ControlDarkDark), ArrowPointArray(rr.X + rr.Width - 9, rr.Y + 2));
                }

                // draw the dots for our control image using a loop
                int x = rr.X + 14;
                int y = rr.Y + 3;

                // Visual Styles
                switch (visualStyle)
                {
                    case VisualStyles.Mozilla:

                        for (int i = 0; i < 30; i++)
                        {
                            // light dot
                            g.DrawLine(new Pen(SystemColors.ControlLightLight), x + (i * 3), y, x + 1 + (i * 3), y + 1);
                            // dark dot
                            g.DrawLine(new Pen(SystemColors.ControlDarkDark), x + 1 + (i * 3), y + 1, x + 2 + (i * 3), y + 2);
                            // overdraw the background color as we actually drew 2px diagonal lines, not just dots
                            if (hot)
                            {
                                g.DrawLine(new Pen(hotColor), x + 1 + (i * 3), y + 2, x + 2 + (i * 3), y + 2);
                            }
                            else
                            {
                                g.DrawLine(new Pen(this.BackColor), x + 1 + (i * 3), y + 2, x + 2 + (i * 3), y + 2);
                            }
                        }
                        break;

                    case VisualStyles.DoubleDots:

                        for (int i = 0; i < 30; i++)
                        {
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 1 + (i * 3), y, 1, 1);
                            // dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDark), x + (i * 3), y - 1, 1, 1);
                            i++;
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 1 + (i * 3), y + 2, 1, 1);
                            // dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDark), x + (i * 3), y + 1, 1, 1);
                        }
                        break;

                    case VisualStyles.Win9x:

                        g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x, y + 2);
                        g.DrawLine(new Pen(SystemColors.ControlLightLight), x, y, x + 88, y);
                        g.DrawLine(new Pen(SystemColors.ControlDark), x, y + 2, x + 88, y + 2);
                        g.DrawLine(new Pen(SystemColors.ControlDark), x + 88, y, x + 88, y + 2);
                        break;

                    case VisualStyles.XP:

                        for (int i = 0; i < 18; i++)
                        {
                            // light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLight), x + (i * 5), y, 2, 2);
                            // light light dot
                            g.DrawRectangle(new Pen(SystemColors.ControlLightLight), x + 1 + (i * 5), y + 1, 1, 1);
                            // dark dark dot
                            g.DrawRectangle(new Pen(SystemColors.ControlDarkDark), x + (i * 5), y, 1, 1);
                            // dark fill
                            g.DrawLine(new Pen(SystemColors.ControlDark), x + (i * 5), y, x + (i * 5) + 1, y);
                            g.DrawLine(new Pen(SystemColors.ControlDark), x + (i * 5), y, x + (i * 5), y + 1);
                        }
                        break;

                    case VisualStyles.Lines:

                        for (int i = 0; i < 44; i++)
                        {
                            g.DrawLine(new Pen(SystemColors.ControlDark), x + (i * 2), y, x + (i * 2), y + 2);
                        }

                        break;
                }

                if (this.borderStyle != System.Windows.Forms.Border3DStyle.Flat)
                {
                    // Paint the control border
                    ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this.borderStyle, Border3DSide.Top);
                    ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, this.borderStyle, Border3DSide.Bottom);
                }
            }

            #endregion

            else
            {
                throw new Exception("The Collapsible splitter control cannot have the Filled or None dockstyle property");
            }

            // dispose the Graphics object
            g.Dispose();
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        /// Calculates the color.
        /// </summary>
        /// <param name="front">The front.</param>
        /// <param name="back">The back.</param>
        /// <param name="alpha">The alpha.</param>
        /// <returns></returns>
        /// <remarks>This method was borrowed from the RichUI Control library by Sajith M</remarks>
        private static Color CalculateColor(Color front, Color back, int alpha)
        {
            // solid color obtained as a result of alpha-blending
            Color frontColor = Color.FromArgb(255, front);
            Color backColor = Color.FromArgb(255, back);

            float frontRed = frontColor.R;
            float frontGreen = frontColor.G;
            float frontBlue = frontColor.B;
            float backRed = backColor.R;
            float backGreen = backColor.G;
            float backBlue = backColor.B;

            float fRed = frontRed * alpha / 255 + backRed * ((float)(255 - alpha) / 255);
            byte newRed = (byte)fRed;
            float fGreen = frontGreen * alpha / 255 + backGreen * ((float)(255 - alpha) / 255);
            byte newGreen = (byte)fGreen;
            float fBlue = frontBlue * alpha / 255 + backBlue * ((float)(255 - alpha) / 255);
            byte newBlue = (byte)fBlue;

            return Color.FromArgb(255, newRed, newGreen, newBlue);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// This creates a point array to draw a arrow-like polygon.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        private Point[] ArrowPointArray(int x, int y)
        {
            Point[] point = new Point[3];

            if (controlToHide != null)
            {
                // decide which direction the arrow will point
                if (
                    (this.Dock == DockStyle.Right && controlToHide.Visible)
                    || (this.Dock == DockStyle.Left && !controlToHide.Visible)
                    )
                {
                    // right arrow
                    point[0] = new Point(x, y);
                    point[1] = new Point(x + 3, y + 3);
                    point[2] = new Point(x, y + 6);
                }
                else if (
                    (this.Dock == DockStyle.Right && !controlToHide.Visible)
                    || (this.Dock == DockStyle.Left && controlToHide.Visible)
                    )
                {
                    // left arrow
                    point[0] = new Point(x + 3, y);
                    point[1] = new Point(x, y + 3);
                    point[2] = new Point(x + 3, y + 6);
                }

                    // Up/Down arrows added in v1.2
                else if (
                    (this.Dock == DockStyle.Top && controlToHide.Visible)
                    || (this.Dock == DockStyle.Bottom && !controlToHide.Visible)
                    )
                {
                    // up arrow
                    point[0] = new Point(x + 3, y);
                    point[1] = new Point(x + 6, y + 4);
                    point[2] = new Point(x, y + 4);
                }
                else if (
                    (this.Dock == DockStyle.Top && !controlToHide.Visible)
                    || (this.Dock == DockStyle.Bottom && controlToHide.Visible)
                    )
                {
                    // down arrow
                    point[0] = new Point(x, y);
                    point[1] = new Point(x + 6, y);
                    point[2] = new Point(x + 3, y + 3);
                }
            }

            return point;
        }

        /// <summary>
        /// Called when [click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnClick(object sender, System.EventArgs e)
        {
            if (controlToHide != null && hot &&
                CurrentState != SplitterState.Collapsing &&
                CurrentState != SplitterState.Expanding)
            {
                ToggleSplitter();
            }
        }

        /// <summary>
        /// Called when [mouse leave].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnMouseLeave(object sender, System.EventArgs e)
        {
            // ensure that the hot state is removed
            this.hot = false;
            this.Invalidate();
        }

        /// <summary>
        /// Called when [mouse move].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        private void OnMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            // check to see if the mouse cursor position is within the bounds of our control
            if (e.X >= rr.X && e.X <= rr.X + rr.Width && e.Y >= rr.Y && e.Y <= rr.Y + rr.Height)
            {
                if (!this.hot)
                {
                    this.hot = true;
                    this.Cursor = Cursors.Hand;
                    this.Invalidate();
                }
            }
            else
            {
                if (this.hot)
                {
                    this.hot = false;
                    this.Invalidate();
                    ;
                }

                this.Cursor = Cursors.Default;

                if (controlToHide != null)
                {
                    if (!controlToHide.Visible)
                        this.Cursor = Cursors.Default;
                    else // to support Horizontal Splitters
                    {
                        if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        {
                            this.Cursor = Cursors.VSplit;
                        }
                        else
                        {
                            this.Cursor = Cursors.HSplit;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called when [resize].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnResize(object sender, System.EventArgs e)
        {
            this.Invalidate();
        }

        /// <summary>
        /// Toggles the splitter.
        /// </summary>
        private void ToggleSplitter()
        {
            // if an animation is currently in progress for this control, drop out
            if (CurrentState == SplitterState.Collapsing || CurrentState == SplitterState.Expanding || controlToHide == null)
            {
                return;
            }

            controlWidth = controlToHide.Width;
            controlHeight = controlToHide.Height;

            if (controlToHide.Visible)
            {
                if (useAnimations)
                {
                    CurrentState = SplitterState.Collapsing;

                    if (parentForm != null)
                    {
                        if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        {
                            parentFormWidth = parentForm.Width - controlWidth;
                        }
                        else
                        {
                            parentFormHeight = parentForm.Height - controlHeight;
                        }
                    }

                    this.animationTimer.Enabled = true;
                }
                else
                {
                    // no animations, so just toggle the visible state
                    CurrentState = SplitterState.Collapsed;
                    controlToHide.Visible = false;

                    if (expandParentForm && parentForm != null)
                    {
                        if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        {
                            parentForm.Width -= controlToHide.Width;
                        }
                        else
                        {
                            parentForm.Height -= controlToHide.Height;
                        }
                    }
                }
            }
            else
            {
                // control to hide is collapsed
                if (useAnimations)
                {
                    CurrentState = SplitterState.Expanding;

                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                    {
                        if (parentForm != null)
                        {
                            parentFormWidth = parentForm.Width + controlWidth;
                        }

                        controlToHide.Width = 0;
                    }
                    else
                    {
                        if (parentForm != null)
                        {
                            parentFormHeight = parentForm.Height + controlHeight;
                        }

                        controlToHide.Height = 0;
                    }

                    controlToHide.Visible = true;
                    this.animationTimer.Enabled = true;
                }
                else
                {
                    // no animations, so just toggle the visible state
                    CurrentState = SplitterState.Expanded;
                    controlToHide.Visible = true;

                    if (expandParentForm && parentForm != null)
                    {
                        if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                        {
                            parentForm.Width += controlToHide.Width;
                        }
                        else
                        {
                            parentForm.Height += controlToHide.Height;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Animations the timer tick.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void animationTimerTick(object sender, System.EventArgs e)
        {
            switch (CurrentState)
            {
                case SplitterState.Collapsing:
                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                    {
                        // vertical splitter
                        if (controlToHide.Width > animationStep)
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Width -= animationStep;
                            }
                            controlToHide.Width -= animationStep;
                        }
                        else
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Width = parentFormWidth;
                            }
                            controlToHide.Visible = false;
                            animationTimer.Enabled = false;
                            controlToHide.Width = controlWidth;
                            CurrentState = SplitterState.Collapsed;
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        // horizontal splitter
                        if (controlToHide.Height > animationStep)
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized && parentForm != null)
                            {
                                parentForm.Height -= animationStep;
                            }

                            controlToHide.Height -= animationStep;
                        }
                        else
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized && parentForm != null)
                            {
                                parentForm.Height = parentFormHeight;
                            }

                            controlToHide.Visible = false;
                            animationTimer.Enabled = false;
                            controlToHide.Height = controlHeight;
                            CurrentState = SplitterState.Collapsed;
                            this.Invalidate();
                        }
                    }
                    break;

                case SplitterState.Expanding:
                    if (this.Dock == DockStyle.Left || this.Dock == DockStyle.Right)
                    {
                        // vertical splitter
                        if (controlToHide.Width < (controlWidth - animationStep))
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Width += animationStep;
                            }
                            controlToHide.Width += animationStep;
                        }
                        else
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized
                                && parentForm != null)
                            {
                                parentForm.Width = parentFormWidth;
                            }
                            controlToHide.Width = controlWidth;
                            controlToHide.Visible = true;
                            animationTimer.Enabled = false;
                            CurrentState = SplitterState.Expanded;
                            this.Invalidate();
                        }
                    }
                    else
                    {
                        // horizontal splitter
                        if (controlToHide.Height < (controlHeight - animationStep))
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized && parentForm != null)
                            {
                                parentForm.Height += animationStep;
                            }

                            controlToHide.Height += animationStep;
                        }
                        else
                        {
                            if (expandParentForm && parentForm.WindowState != FormWindowState.Maximized && parentForm != null)
                            {
                                parentForm.Height = parentFormHeight;
                            }

                            controlToHide.Height = controlHeight;
                            controlToHide.Visible = true;
                            animationTimer.Enabled = false;
                            CurrentState = SplitterState.Expanded;
                            this.Invalidate();
                        }
                    }
                    break;
            }
        }

        #endregion

        #endregion
    }

    /// <summary>
    /// A simple designer class for the KissSplitterCollapsible control to remove
    /// unwanted properties at design time.
    /// </summary>
    public class KissSplitterCollapsibleDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissSplitterCollapsibleDesigner"/> class.
        /// </summary>
        public KissSplitterCollapsibleDesigner()
        {
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Adjusts the set of properties the component exposes through a <see cref="T:System.ComponentModel.TypeDescriptor"></see>.
        /// </summary>
        /// <param name="properties">An <see cref="T:System.Collections.IDictionary"></see> containing the properties for the class of the component.</param>
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            properties.Remove("IsCollapsed");
            properties.Remove("BorderStyle");
            properties.Remove("Size");
        }

        #endregion

        #endregion
    }
}