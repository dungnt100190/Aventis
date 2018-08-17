using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KiSS4.Sozialsystem
{
    #region Enum LinearGradientMode

    /// <summary>
    /// Enumeration for GradientMode used in CtlBaseItem
    /// </summary>
    public enum LinearGradientMode
    {
        Horizontal = 0,
        Vertical = 1,
        ForwardDiagonal = 2,
        BackwardDiagonal = 3,
        None = 4
    }

    #endregion

    #region Enum BoxColors

    /// <summary>
    /// Enumeration for GradientMode used in CtlBaseItem
    /// </summary>
    public enum  BoxColors
    {
        Client_Normal,
        Client_Focused,
        InvPerson_Normal,
        InvPerson_Focused,
        InvOrg_Normal,
        InvOrg_Focused,
        ServProv_Normal,
        ServProv_Focused
    }

    #endregion


    #region Enum CornerCurveMode

    /// <summary>
    /// Enumeration for CornerCurveMode used in CtlBaseItem, defines multiple styles for corner-curves
    /// </summary>
    [FlagsAttribute()]
    public enum CornerCurveMode
    {
        None = 0,
        TopLeft = 1,
        TopRight = 2,
        TopLeft_TopRight = 3,
        BottomLeft = 4,
        TopLeft_BottomLeft = 5,
        TopRight_BottomLeft = 6,
        TopLeft_TopRight_BottomLeft = 7,
        BottomRight = 8,
        BottomRight_TopLeft = 9,
        BottomRight_TopRight = 10,
        BottomRight_TopLeft_TopRight = 11,
        BottomRight_BottomLeft = 12,
        BottomRight_TopLeft_BottomLeft = 13,
        BottomRight_TopRight_BottomLeft = 14,
        All = 15
    }

    #endregion    

    
    /// <summary>
    /// Graphic base panel for single item in Sozialsystem
    /// </summary>
    [System.Drawing.ToolboxBitmapAttribute(typeof(System.Windows.Forms.Panel))]
    public class CtlBaseItem : System.Windows.Forms.UserControl
    {
        #region Fields

        /// <summary>
        /// Property: The primary background color used to display text and graphics in the control.
        /// </summary>
        private System.Drawing.Color backColor1 = System.Drawing.Color.LightBlue;

        /// <summary>
        /// Property: The secondary background color used to paint the control, used for gradient.
        /// </summary>
        private System.Drawing.Color backColor2 = System.Drawing.Color.MediumAquamarine;

        /// <summary>
        /// Property: The gradient mode used to paint the control, setup BackColor2 different to BackColor to have a gradient.
        /// </summary>
        private LinearGradientMode gradientMode = LinearGradientMode.Vertical;

        /// <summary>
        /// Property: The border style used to paint the control.
        /// </summary>
        private System.Windows.Forms.BorderStyle borderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        /// <summary>
        /// Property: The border color used to paint the control.
        /// </summary>
        private System.Drawing.Color borderColor = System.Drawing.Color.Black;

        /// <summary>
        /// Property: The width of the border used to paint the control.
        /// </summary>
        private int borderWidth = 1;

        /// <summary>
        /// Property: The radius of the curve used to paint the corners of the control.
        /// </summary>
        private int curvature = 0;

        /// <summary>
        /// Property: The style of the curves to be drawn on the control.
        /// </summary>
        private CornerCurveMode curveMode = CornerCurveMode.All;

        /// <summary>
        /// Property: Do mark item on focus
        /// </summary>
        private bool focusElement = false;

        #endregion

        #region Constructor / Setup / Init

        /// <summary>
        /// Constructor for class
        /// </summary>
        public CtlBaseItem()
        {
            // init components
            InitializeComponent();
            
            // setup more
            this.SetDefaultControlStyles();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CtlBaseItem
            // 
            this.Name = "CtlBaseItem";
            this.BackColor = System.Drawing.Color.Transparent;
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TabStop = true;
            this.Load += new System.EventHandler(this.CtlBaseItem_Load);
            this.Click += new EventHandler(CtlBaseItem_Click);
            this.GotFocus += new EventHandler(CtlBaseItem_GotFocus);
            this.LostFocus += new EventHandler(CtlBaseItem_LostFocus);
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Setup default styles to the panel
        /// </summary>
        private void SetDefaultControlStyles()
        {
            // styles
            this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, false);
            this.SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);
            this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);

            // values
            this.BaseBackColor = System.Drawing.Color.Transparent;
        }

        #endregion

        #region Properties

        /// <summary>
        /// The background color of the base user control.
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(typeof(System.Drawing.Color), "Transparent")]
        [System.ComponentModel.CategoryAttribute("Appearance")]
        [System.ComponentModel.DescriptionAttribute("The background color of the base user control.")]
        public System.Drawing.Color BaseBackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The primary background color used to display text and graphics in the control.
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(typeof(System.Drawing.Color), "Window")] 
        [System.ComponentModel.CategoryAttribute("Appearance")] 
        [System.ComponentModel.DescriptionAttribute("The primary background color used to display text and graphics in the control.")]
        public new System.Drawing.Color BackColor
        {
            get { return this.backColor1; }
            set
            {
                this.backColor1 = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The secondary background color used to paint the control, used for gradient.
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(typeof(System.Drawing.Color), "Window")] 
        [System.ComponentModel.CategoryAttribute("Appearance")]
        [System.ComponentModel.DescriptionAttribute("The secondary background color used to paint the control, used for gradient.")]
        public System.Drawing.Color BackColor2
        {
            get { return this.backColor2; }
            set
            {
                this.backColor2 = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The gradient mode used to paint the control, setup BackColor2 different to BackColor to have a gradient.
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(typeof(LinearGradientMode), "None")] 
        [System.ComponentModel.CategoryAttribute("Appearance")]
        [System.ComponentModel.DescriptionAttribute("The gradient mode used to paint the control, setup BackColor2 different to BackColor to have a gradient.")]
        public LinearGradientMode GradientMode
        {
            get { return this.gradientMode; }
            set
            {
                this.gradientMode = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The border style used to paint the control.
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(typeof(System.Windows.Forms.BorderStyle), "None")] 
        [System.ComponentModel.CategoryAttribute("Appearance")] 
        [System.ComponentModel.DescriptionAttribute("The border style used to paint the control.")]
        public new System.Windows.Forms.BorderStyle BorderStyle
        {
            get { return this.borderStyle; }
            set
            {
                this.borderStyle = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The border color used to paint the control.
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(typeof(System.Drawing.Color), "WindowFrame")] 
        [System.ComponentModel.CategoryAttribute("Appearance")] 
        [System.ComponentModel.DescriptionAttribute("The border color used to paint the control.")]
        public System.Drawing.Color BorderColor
        {
            get { return this.borderColor; }
            set
            {
                this.borderColor = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The width of the border used to paint the control.
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(typeof(int), "1")] 
        [System.ComponentModel.CategoryAttribute("Appearance")] 
        [System.ComponentModel.DescriptionAttribute("The width of the border used to paint the control.")]
        public int BorderWidth
        {
            get { return this.borderWidth; }
            set
            {
                this.borderWidth = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The radius of the curve used to paint the corners of the control.
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(typeof(int), "0")] 
        [System.ComponentModel.CategoryAttribute("Appearance")] 
        [System.ComponentModel.DescriptionAttribute("The radius of the curve used to paint the corners of the control.")]
        public int Curvature
        {
            get { return this.curvature; }
            set
            {
                this.curvature = value;

                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// The style of the curves to be drawn on the control.
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(typeof(CornerCurveMode), "All")] 
        [System.ComponentModel.CategoryAttribute("Appearance")] 
        [System.ComponentModel.DescriptionAttribute("The style of the curves to be drawn on the control.")]
        public CornerCurveMode CurveMode
        {
            get { return this.curveMode; }
            set
            {
                this.curveMode = value;
                
                if (this.DesignMode)
                {
                    this.Invalidate();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [System.ComponentModel.DefaultValueAttribute(false)]
        [System.ComponentModel.CategoryAttribute("Appearance")]
        [System.ComponentModel.DescriptionAttribute("The style of the curves to be drawn on the control.")]
        public bool FocusElement
        {
            get { return this.focusElement; }
            set
            {
                // check if item has focus now
                if (this.Focused)
                {
                    // did we alter the flag?
                    if (this.focusElement && !value)
                    {
                        // remove graphical change and click event
                        this.ApplyFocusElement(false);
                        this.AddRemoveClickEventOnControls(false);
                    }
                    else if (!this.focusElement && value)
                    {
                        // apply graphical change and click event
                        this.ApplyFocusElement(true);
                        this.AddRemoveClickEventOnControls(true);
                    }
                }
                
                // apply value
                this.focusElement = value;                
            }
        }

        /// <summary>
        /// Get adjusted curve depending on settings
        /// </summary>
        private int AdjustedCurve
        {
            get
            {
                int curve = 0;
                if (!(this.curveMode == CornerCurveMode.None))
                {
                    if (this.curvature > (this.ClientRectangle.Width / 2))
                    {
                        curve = DoubleToInt(this.ClientRectangle.Width / 2);
                    }
                    else
                    {
                        curve = this.curvature;
                    }

                    if (curve > (this.ClientRectangle.Height / 2))
                    {
                        curve = DoubleToInt(this.ClientRectangle.Height / 2);
                    }
                }
                return curve;
            }
        }

        #endregion

        #region Events and EventHandler

        /// <summary>
        /// Occures when control got focus
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Description("Occures when control got focus")]
        public event EventHandler ItemGotFocus;

        /// <summary>
        /// Occures whe control lost focus
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [Description("Occures when control lost focus")]
        public event EventHandler ItemLostFocus;

        /// <summary>
        /// The event when control was loaded
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlBaseItem_Load(object sender, EventArgs e)
        {
            // check if need to add event handler
            if (this.FocusElement)
            {
                // register click event on all controls
                this.AddRemoveClickEventOnControls(true);
            }
        }

        /// <summary>
        /// The event when control was clicked, needed to set focus
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlBaseItem_Click(object sender, EventArgs e)
        {
            // if control does not have focus, set focus now
            if (!this.Focused)
            {
                // set focus
                this.Select();
            }
        }

        /// <summary>
        /// The event when control got focus, needed to fire other event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlBaseItem_GotFocus(object sender, EventArgs e)
        {
            // check if need to do something with control
            if (this.focusElement)
            {
                this.ApplyFocusElement(true);
            }
            
            // fire event
            if (this.ItemGotFocus != null)
            {
                // fire event
                this.ItemGotFocus(sender, e);
            }
        }

        /// <summary>
        /// The event when control lost focus, needed to fire other event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void CtlBaseItem_LostFocus(object sender, EventArgs e)
        {
            // check if need to do something with control
            if (this.focusElement)
            {
                this.ApplyFocusElement(false);
            }
            
            // fire event
            if (this.ItemLostFocus != null)
            {
                // fire event
                this.ItemLostFocus(sender, e);
            }
        }

        #endregion

        #region Graphics and Painting

        /// <summary>
        /// Event OnPaintBackground for custom drawing background
        /// </summary>
        /// <param name="pevent">The PaintEvent arguments</param>
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);

            pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            System.Drawing.Drawing2D.GraphicsPath graphPath;
            graphPath = this.GetPath();

            //	Create Gradient Brush (Cannot be width or height 0)
            System.Drawing.Drawing2D.LinearGradientBrush filler;
            System.Drawing.Rectangle rect = this.ClientRectangle;

            if (this.ClientRectangle.Width == 0)
            {
                rect.Width += 1;
            }

            if (this.ClientRectangle.Height == 0)
            {
                rect.Height += 1;
            }

            if (this.gradientMode == LinearGradientMode.None)
            {
                filler = new System.Drawing.Drawing2D.LinearGradientBrush(rect, this.backColor1, this.backColor1, System.Drawing.Drawing2D.LinearGradientMode.Vertical);
            }
            else
            {
                filler = new System.Drawing.Drawing2D.LinearGradientBrush(rect, this.backColor1, this.backColor2, ((System.Drawing.Drawing2D.LinearGradientMode)this.gradientMode));
            }

            pevent.Graphics.FillPath(filler, graphPath);
            filler.Dispose();

            if (this.borderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
            {
                System.Drawing.Pen borderPen = new System.Drawing.Pen(this.borderColor, this.borderWidth);
                pevent.Graphics.DrawPath(borderPen, graphPath);
                borderPen.Dispose();
            }
            else if (this.borderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
            {
                DrawBorder3D(pevent.Graphics, this.ClientRectangle);
            }
            else if (this.borderStyle == System.Windows.Forms.BorderStyle.None)
            {
                // nothing to do
            }

            filler.Dispose();
            graphPath.Dispose();
        }

        /// <summary>
        /// Get the GraphicsPath arround panel depending on current settings
        /// </summary>
        /// <returns>The GraphicsPath arround panel</returns>
        protected System.Drawing.Drawing2D.GraphicsPath GetPath()
        {
            System.Drawing.Drawing2D.GraphicsPath graphPath = new System.Drawing.Drawing2D.GraphicsPath();
            if (this.borderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
            {
                graphPath.AddRectangle(this.ClientRectangle);
            }
            else
            {
                try
                {
                    int curve = 0;
                    int offset = 0;
                    System.Drawing.Rectangle rect = this.ClientRectangle;

                    if (this.borderStyle == System.Windows.Forms.BorderStyle.FixedSingle)
                    {
                        if (this.borderWidth > 1)
                        {
                            offset = DoubleToInt(this.BorderWidth / 2);
                        }
                        curve = this.AdjustedCurve;
                    }
                    else if (this.borderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
                    {
                        // nothing to do
                    }
                    else if (this.borderStyle == System.Windows.Forms.BorderStyle.None)
                    {
                        curve = this.AdjustedCurve;
                    }

                    if (curve == 0)
                    {
                        graphPath.AddRectangle(System.Drawing.Rectangle.Inflate(rect, -offset, -offset));
                    }
                    else
                    {
                        int rectWidth = rect.Width - 1 - offset;
                        int rectHeight = rect.Height - 1 - offset;
                        int curveWidth = 1;

                        if ((this.curveMode & CornerCurveMode.TopRight) != 0)
                        {
                            curveWidth = (curve * 2);
                        }
                        else
                        {
                            curveWidth = 1;
                        }

                        graphPath.AddArc(rectWidth - curveWidth, offset, curveWidth, curveWidth, 270, 90);
                        if ((this.curveMode & CornerCurveMode.BottomRight) != 0)
                        {
                            curveWidth = (curve * 2);
                        }
                        else
                        {
                            curveWidth = 1;
                        }

                        graphPath.AddArc(rectWidth - curveWidth, rectHeight - curveWidth, curveWidth, curveWidth, 0, 90);
                        if ((this.curveMode & CornerCurveMode.BottomLeft) != 0)
                        {
                            curveWidth = (curve * 2);
                        }
                        else
                        {
                            curveWidth = 1;
                        }

                        graphPath.AddArc(offset, rectHeight - curveWidth, curveWidth, curveWidth, 90, 90);
                        if ((this.curveMode & CornerCurveMode.TopLeft) != 0)
                        {
                            curveWidth = (curve * 2);
                        }
                        else
                        {
                            curveWidth = 1;
                        }

                        graphPath.AddArc(offset, offset, curveWidth, curveWidth, 180, 90);
                        graphPath.CloseFigure();
                    }
                }
                catch (System.Exception)
                {
                    graphPath.AddRectangle(this.ClientRectangle);
                }
            }

            return graphPath;
        }

        /// <summary>
        /// Draw a 3d border arround rectangle
        /// </summary>
        /// <param name="graphics">The instance of the graphic object</param>
        /// <param name="rectangle">The rectangle to surround with a border</param>
        public static void DrawBorder3D(System.Drawing.Graphics graphics, System.Drawing.Rectangle rectangle)
        {
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            graphics.DrawLine(System.Drawing.SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.Width - 1, rectangle.Y);
            graphics.DrawLine(System.Drawing.SystemPens.ControlDark, rectangle.X, rectangle.Y, rectangle.X, rectangle.Height - 1);
            graphics.DrawLine(System.Drawing.SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.Width - 1, rectangle.Y + 1);
            graphics.DrawLine(System.Drawing.SystemPens.ControlDarkDark, rectangle.X + 1, rectangle.Y + 1, rectangle.X + 1, rectangle.Height - 1);
            graphics.DrawLine(System.Drawing.SystemPens.ControlLight, rectangle.X + 1, rectangle.Height - 2, rectangle.Width - 2, rectangle.Height - 2);
            graphics.DrawLine(System.Drawing.SystemPens.ControlLight, rectangle.Width - 2, rectangle.Y + 1, rectangle.Width - 2, rectangle.Height - 2);
            graphics.DrawLine(System.Drawing.SystemPens.ControlLightLight, rectangle.X, rectangle.Height - 1, rectangle.Width - 1, rectangle.Height - 1);
            graphics.DrawLine(System.Drawing.SystemPens.ControlLightLight, rectangle.Width - 1, rectangle.Y, rectangle.Width - 1, rectangle.Height - 1);
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Convert value in double to int value
        /// </summary>
        /// <param name="value">The value to convert to int</param>
        /// <returns>Converted integer value from double</returns>
        public static int DoubleToInt(double value)
        {
            return System.Decimal.ToInt32(System.Decimal.Floor(System.Decimal.Parse((value).ToString())));
        }

        /// <summary>
        /// Add Click event for focus to all controls and subcontrols in order to get focus when control was clicked
        /// </summary>
        /// <param name="doClickEvent">True if event has to be added, false if event has to be removed</param>
        private void AddRemoveClickEventOnControls(bool doClickEvent)
        {
            // remove event first if add new handler
            if (doClickEvent)
            {
                AddRemoveClickEventOnControls(false);
            }
            
            // loop through all controls and add or remove click event
            foreach (Control ctl in Gui.UtilsGui.AllControls(this))
            {
                if (ctl != null)
                {
                    if (doClickEvent)
                    {
                        // add click event handler
                        ctl.Click += new EventHandler(CtlBaseItem_Click);
                    }
                    else
                    {
                        // remove click event handler
                        ctl.Click -= new EventHandler(CtlBaseItem_Click);
                    }
                }
            }
        }

        /// <summary>
        /// Apply graphical change when item has focus and remove change when item lost focus
        /// </summary>
        /// <param name="hasFocus">True if need to apply change, false if need to remove change</param>
        private void ApplyFocusElement(bool hasFocus)
        {
            // check what to do with element
            if (hasFocus)
            {
                this.BorderWidth++;
            }
            else
            {
                this.BorderWidth--;
            }

            // repaint
            this.Invalidate();
        }

        /// <summary>
        /// Center icon vertically on item
        /// </summary>
        /// <param name="item">The item to use</param>
        /// <param name="pic">The picture box to center</param>
        public void CenterIcon(CtlBaseItem item, PictureBox pic)
        {
            // validate first
            if (item == null || pic == null)
            {
                return;
            }

            // center picturebox
            pic.Top = (int)Math.Floor((double)(item.Height - pic.Width) / 2.0);
        }

        /// <summary>
        /// Hide label if no content to show and resize item
        /// </summary>
        /// <param name="item">The item to use</param>
        /// <param name="minItemHeight">The minimum height for the item</param>
        /// <param name="label">The label to process</param>
        /// <param name="controlsBelow">The controls below the label, to move upwards</param>
        public void HideLabel(CtlBaseItem item, int minItemHeight, Label label, params object[] controlsBelow)
        {
            // validate first
            if (item == null || label == null || !DB.DBUtil.IsEmpty(label.Text))
            {
                return;
            }

            // hide label and resize item
            label.Visible = false;
            item.Height = item.Height - label.Height - label.Margin.Top - label.Margin.Bottom;

            // check min height
            if (item.Height < minItemHeight)
            {
                item.Height = minItemHeight;
            }

            // move other controls below upwards
            if (controlsBelow != null && controlsBelow.Length > 0)
            {
                foreach(object ctl in controlsBelow )
                {
                    if (ctl is Control)
                    {
                        ((Control)ctl).Top = ((Control)ctl).Top - label.Height - label.Margin.Top;
                    }
                }
            }
        }

        public void ShowBoldBorder(bool ShowBold)
        {
            // Ist vorläufig nur für Klienten programmiert
            if (this == null) return;
            if (ShowBold && this.BorderWidth == 1)
            {
                this.BorderWidth++;
                this.BackColor2 = this.GetColor(BoxColors.Client_Focused);
                this.Invalidate();
            }
            else if ((!ShowBold) && this.BorderWidth == 2)
            {
                this.BorderWidth--;
                this.BackColor2 = this.GetColor(BoxColors.Client_Normal);
                this.Invalidate();
            }
        }

        public Color GetColor(BoxColors bclr)
        {
            switch (bclr)
            {
                case BoxColors.Client_Normal:
                    return Color.FromArgb(255, 185, 185);
                case BoxColors.Client_Focused:
                    return Color.FromArgb(255, 105, 105);

                case BoxColors.InvPerson_Normal:
                    return Color.FromArgb(185, 185, 255);
                case BoxColors.InvPerson_Focused:
                    return Color.FromArgb(105, 105, 255);

                case BoxColors.InvOrg_Normal:
                    return Color.FromArgb(185, 255, 185);
                case BoxColors.InvOrg_Focused:
                    return Color.FromArgb(105, 255, 105);

                case BoxColors.ServProv_Normal:
                    return Color.FromArgb(255, 255, 185);
                case BoxColors.ServProv_Focused:
                    return Color.FromArgb(255, 255, 105);
            }
            return Color.FromArgb(255, 255, 255);

        }


        #endregion
    }
}
