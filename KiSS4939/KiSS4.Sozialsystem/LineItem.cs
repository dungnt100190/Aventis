using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using KiSS4.DB;

namespace KiSS4.Sozialsystem
{
    #region Enum LineDirection

    /// <summary>
    /// Enumeration for line direction calculated by start and endpoint
    /// </summary>
    public enum LineDirection
    {
        HorizontalLeftRight,
        HorizontalRightLeft,
        VerticalTopDown,
        VerticalDownTop,
        DiagonalTopLeftBottomRight,
        DiagonalBottomRightTopLeft,
        DiagonalTopRightBottomLeft,
        DiagonalBottomLeftTopRight
    }

    #endregion

    #region Class LineItem - The transparent container with border containing the line

    /// <summary>
    /// Draw a line inside a container. The container is used to enlarge selection area arround line for focusing and tooltip.
    /// The enlarged area is only useful for horizontal and vertical lines, otherwise the area would be just a too large rectangle from 
    /// top left to bottom right of the single line.
    /// </summary>
    public class LineItem : UserControl
    {
        #region Constants

        /// <summary>
        /// The space arround line used for focusing
        /// </summary>
        public const int surroundingFocusSpace = 3;

        /// <summary>
        /// The space arround crossing point to be empty for drawing (height of bridge and minimum space to be empty arround crossing point)
        /// </summary>
        public const int crossPointSpace = 1;

        /// <summary>
        /// The additional space arround crossing point to be empty
        /// </summary>
        public const int crossPointSpaceEmptyAdd = 3;

        #endregion

        #region Fields

        /// <summary>
        /// The single line of this container
        /// </summary>
        private SingleLine singleLine = null;

        /// <summary>
        /// Set wheather the line has focus or not to change the view of the line
        /// </summary>
        private bool lineHasFocus = false;

        /// <summary>
        /// Set if this line has the real focus
        /// </summary>
        private bool focused = false;

        /// <summary>
        /// The default line width without focus on init
        /// </summary>
        private int initLineWidth = 0;

        /// <summary>
        /// Store if width and height are set from created single line and do not have to be changed anymore
        /// </summary>
        private bool setWidthAndHeight = false;

        #endregion

        #region Constructors / Dispose

        /// <summary>
        /// Create a new line with the given properties
        /// </summary>
        /// <param name="startPoint">The starting point of the line</param>
        /// <param name="endPoint">The ending point of the line</param>
        /// <param name="lineColor">The color of the line</param>
        /// <param name="lineWidth">The width of the line</param>
        /// <param name="crossPoints">The crossing points where we have to draw a bride over another line</param>
        public LineItem(Point startPoint, Point endPoint, Color lineColor, int lineWidth, List<Point> crossPoints)
        {
            // create a new single line (use null instead of crossPoints to prevent drawing crossing points)
            this.singleLine = new SingleLine(startPoint, endPoint, lineColor, lineWidth, crossPoints);
            //this.singleLine = new SingleLine(startPoint, endPoint, lineColor, lineWidth, null);

            // apply fields
            this.initLineWidth = lineWidth;

            // make transparent control selectable
            this.SetStyle(ControlStyles.Selectable, true);
            this.UpdateStyles();

            // set default behaviour
            this.TabStop = false;

            // setup
            SetupSingeLineContainer();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            // remove events
            this.SizeChanged -= new EventHandler(LineItem_SizeChanged);
            this.singleLine.GotFocus -= new EventHandler(line_GotFocus);
            this.singleLine.LostFocus -= new EventHandler(line_LostFocus);
            this.GotFocus -= new EventHandler(line_GotFocus);
            this.LostFocus -= new EventHandler(line_LostFocus);
            
            // dispose single line as well
            if (this.singleLine != null)
            {
                this.singleLine.Dispose();
            }

            // dispose base
            base.Dispose(disposing);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets a value indicating wheater the control has input focus.
        /// </summary>
        public override bool Focused
        {
            get { return this.focused; }
        }

        /// <summary>
        /// Get direction of line to draw
        /// </summary>
        public LineDirection LineDirection
        {
            get { return this.singleLine.LineDirection; }
        }

        /// <summary>
        /// Set and get wheather the line is focused and visibly marked as selected
        /// </summary>
        public bool LineHasFocus
        {
            get { return this.lineHasFocus; }
            set
            {
                // did the value change?
                if (value == this.lineHasFocus)
                {
                    return;
                }

                // apply new value
                this.lineHasFocus = value;

                // setup line width depending on focus
                if (value)
                {
                    this.singleLine.LineWidth = this.initLineWidth + 1;
                }
                else
                {
                    this.singleLine.LineWidth = this.initLineWidth;
                }

                // setup
                SetupSingeLineContainer();
            }
        }

        #endregion

        #region Transparency

        /// <summary>
        /// Overriden creating parameters to make control transparent
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT 
                return cp;
            }
        }

        /// <summary>
        /// Invalidate ex, needed to redraw parent background
        /// </summary>
        private void InvalidateEx()
        {
            Invalidate();

            // let parent redraw the background
            if (Parent == null)
            {
                return;
            }

            Parent.Invalidate(this.ClientRectangle, true);
        }

        /// <summary>
        /// Event OnPaintBackground, do not paint any background
        /// </summary>
        /// <param name="pevent">The paint event arguments</param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //do not allow the background to be painted
        }

        #endregion

        #region Anchoring

        /// <summary>
        /// The default anchor style: Top, Left
        /// </summary>
        public static AnchorStyles anchorTopLeft = AnchorStyles.Top | AnchorStyles.Left;

        /// <summary>
        /// The anchor style: Top, Left, Right
        /// </summary>
        public static AnchorStyles anchorTopLeftRight = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

        /// <summary>
        /// The anchor style: Top, Left, Bottom
        /// </summary>
        public static AnchorStyles anchorTopLeftBottom = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom;

        /// <summary>
        /// Event SizeChanged, used to modify line if neccessary
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void LineItem_SizeChanged(object sender, EventArgs e)
        {
            // do nothing if anchor is top left
            if (this.Anchor == anchorTopLeft)
            {
                return;
            }

            // depending on anchor and line direction, we move either starting or ending point
            if (this.Anchor == anchorTopLeftRight)
            {
                if (this.singleLine.LineDirection == LineDirection.HorizontalLeftRight)
                {
                    // new ending point X-value
                    this.singleLine.NewEndingPointX(this.Left + this.Width - surroundingFocusSpace);
                }
                else if (this.singleLine.LineDirection == LineDirection.HorizontalRightLeft)
                {
                    // new starting point X-value
                    this.singleLine.NewStartingPointX(this.Left + this.Width - surroundingFocusSpace);
                }
            }
            else if (this.Anchor == anchorTopLeftBottom)
            {
                if (this.singleLine.LineDirection == LineDirection.VerticalTopDown)
                {
                    // new ending point Y-value
                    this.singleLine.NewEndingPointY(this.Top + this.Height - surroundingFocusSpace);
                }
                else if (this.singleLine.LineDirection == LineDirection.HorizontalRightLeft)
                {
                    // new starting point Y-value
                    this.singleLine.NewStartingPointY(this.Top + this.Height - surroundingFocusSpace);
                }
            }
        }

        #endregion

        #region Focus event handling

        /// <summary>
        /// The event when the line item got focus
        /// </summary>
        public event EventHandler LineGotFocus;

        /// <summary>
        /// The event when the line item lost focus
        /// </summary>
        public event EventHandler LineLostFocus;

        /// <summary>
        /// Handle LineGotFocus event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        protected virtual void OnLineGotFocus(object sender, EventArgs e)
        {
            if (LineGotFocus != null)
            {
                LineGotFocus(this, e);
            }
        }

        /// <summary>
        /// Handle LineLostFocus event
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        protected virtual void OnLineLostFocus(object sender, EventArgs e)
        {
            if (LineLostFocus != null)
            {
                LineLostFocus(this, e);
            }
        }

        /// <summary>
        /// GotFocus event on line, used to send event LineGotFocus
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void line_GotFocus(object sender, EventArgs e)
        {
            this.focused = true;
            this.OnLineGotFocus(sender, e);
        }

        /// <summary>
        /// LostFocus event on line, used to send event LineLostFocus
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void line_LostFocus(object sender, EventArgs e)
        {
            this.focused = false;
            this.OnLineLostFocus(sender, e);
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Setup positions depending on single line
        /// </summary>
        private void SetupSingeLineContainer()
        {
            #region Setup Top and Left (Crosspoints)

            // left
            if (this.singleLine.StartPoint.X <= this.singleLine.EndPoint.X)
            {
                this.Left = this.singleLine.StartPoint.X - surroundingFocusSpace;
            }
            else
            {
                this.Left = this.singleLine.EndPoint.X - surroundingFocusSpace;
            }

            // top
            if (this.singleLine.StartPoint.Y <= this.singleLine.EndPoint.Y)
            {
                this.Top = this.singleLine.StartPoint.Y - surroundingFocusSpace;
            }
            else
            {
                this.Top = this.singleLine.EndPoint.Y - surroundingFocusSpace;
            }

            // adjust top and left depending on line direction and containing crosspoints
            if (this.singleLine.HasCrossPoints())
            {
                switch (this.singleLine.LineDirection)
                {
                    case LineDirection.HorizontalLeftRight:
                    case LineDirection.HorizontalRightLeft:
                        // move to top due to adjusted y of single line down
                        this.Top = this.Top - this.singleLine.CrossPointDelta();
                        break;
                }
            } 

            #endregion

            #region Setup Width and Height (Anchoring)

		    // setup width and height for surrounding focus space 
            // (due to special anchors, we can allow only the first time autosize to single line)
            if (this.setWidthAndHeight)
            {
                switch (this.singleLine.LineDirection)
                {
                    case LineDirection.HorizontalLeftRight:
                    case LineDirection.HorizontalRightLeft:
                        // allow change of height for horizontal lines
                        this.Height = surroundingFocusSpace + this.singleLine.Height + surroundingFocusSpace;
                        break;

                    case LineDirection.VerticalTopDown:
                    case LineDirection.VerticalDownTop:
                        // allow change of width for vertical lines
                        this.Width = surroundingFocusSpace + this.singleLine.Width + surroundingFocusSpace;
                        break;
                }
            }
            else
            {
                // do this only once
                this.setWidthAndHeight = true;

                // allow fit to single line only the first time
                this.Width = surroundingFocusSpace + this.singleLine.Width + surroundingFocusSpace;
                this.Height = surroundingFocusSpace + this.singleLine.Height + surroundingFocusSpace;
            } 
	        #endregion

            #region Add single line to control, register events

            // add the control to container and show it
            if (!this.Controls.Contains(this.singleLine))
            {
                this.Controls.Add(this.singleLine);
                this.singleLine.BringToFront();

                // attach resized event to recalculate line if not default anchor
                this.SizeChanged += new EventHandler(LineItem_SizeChanged);

                // attach focus event to set focus to relation
                this.GotFocus += new EventHandler(line_GotFocus);
                this.LostFocus += new EventHandler(line_LostFocus);
                this.singleLine.GotFocus += new EventHandler(line_GotFocus);
                this.singleLine.LostFocus += new EventHandler(line_LostFocus);
            } 

            #endregion
        }

        #endregion
    } 

    #endregion

    #region Class SingleLine - The transparent control of the line

    /// <summary>
    /// Single line class, used to draw a transparent line without any border arround line
    /// Allowes to draw a line in any direction, support for crossing points only for vertical and horizontal lines
    /// </summary>
    public class SingleLine : UserControl
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Set if pixel error was already corrected in SetupLine()
        /// </summary>
        private bool correctedPixelError = false;

        /// <summary>
        /// The starting point on init of the line
        /// </summary>
        private Point initStartPoint;

        /// <summary>
        /// The starting point of the line
        /// </summary>
        private Point startPoint;

        /// <summary>
        /// The ending point on init of the line
        /// </summary>
        private Point initEndPoint;

        /// <summary>
        /// The ending point of the line
        /// </summary>
        private Point endPoint;

        /// <summary>
        /// The path to store graphics
        /// </summary>
        private GraphicsPath linePath = new GraphicsPath();

        /// <summary>
        /// The line color
        /// </summary>
        private Color lineColor = Color.Black;

        /// <summary>
        /// The line width or thickness
        /// </summary>
        private int lineWidth = 1;

        /// <summary>
        /// The line direction calculated from start- and endpoint
        /// </summary>
        private LineDirection lineDirection = LineDirection.HorizontalLeftRight;

        /// <summary>
        /// The crossing points (intersection) with other lines
        /// </summary>
        private List<Point> crossPoints;

        /// <summary>
        /// True if crossing points are sorted and corrected (only once), otherwise false
        /// </summary>
        private bool preparedCrossingPoints = false;

        #endregion

        #region Constructor / Dispose

        /// <summary>
        /// Create a new line with the given properties
        /// </summary>
        /// <param name="startPoint">The starting point of the line</param>
        /// <param name="endPoint">The ending point of the line</param>
        /// <param name="lineColor">The color of the line</param>
        /// <param name="lineWidth">The width of the line</param>
        /// <param name="crossPoints">The crossing points where we have to draw a bride over another line</param>
        public SingleLine(Point startPoint, Point endPoint, Color lineColor, int lineWidth, List<Point> crossPoints)
        {
            // validate
            if (lineWidth < 1 || lineWidth > 10)
            {
                throw new ArgumentOutOfRangeException("lineWidth", "The value must be between 1 and 10");
            }

            // define init points
            this.initStartPoint = startPoint;
            this.initEndPoint = endPoint;

            // setup fields
            this.startPoint = startPoint;
            this.endPoint = endPoint;
            this.lineColor = lineColor;
            this.lineWidth = lineWidth;
            this.crossPoints = new List<Point>(crossPoints);

            // setup default behaviour
            components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.TabStop = false;

            // setup backcolor: due to linepath and region, we can use this whole control as the line without drawing a line
            this.BackColor = lineColor;

            // setup transparency
            this.SetStyle(ControlStyles.DoubleBuffer |
                 ControlStyles.AllPaintingInWmPaint |
                 ControlStyles.ResizeRedraw |
                 ControlStyles.UserPaint |
                 ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();

            // draw line
            SetupLine();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">True if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                // something went wrong
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }
            }
        }

        #endregion

        #region Transparency

        /// <summary>
        /// Invalidate ex, need to redraw parent background
        /// </summary>
        private void InvalidateEx()
        {
            Invalidate();

            // let parent redraw the background
            if (Parent == null)
            {
                return;
            }

            Rectangle rc = new Rectangle(this.Location, this.Size);
            Parent.Invalidate(rc, true);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get direction of line to draw
        /// </summary>
        public LineDirection LineDirection
        {
            get { return this.lineDirection; }
        }

        /// <summary>
        /// Get the calculated starting point of the line
        /// </summary>
        public Point StartPoint
        {
            get { return this.startPoint; }
        }

        /// <summary>
        /// Get the calculated ending point of the line
        /// </summary>
        public Point EndPoint
        {
            get { return this.endPoint; }
        }

        /// <summary>
        /// Set and get the width of the line
        /// </summary>
        public int LineWidth
        {
            get { return this.lineWidth; }
            set
            {
                // did the value change?
                if (value == this.lineWidth)
                {
                    return;
                }

                // apply new value
                this.lineWidth = value;

                // reset flag to do correction of pixel error (depending on line width)
                this.correctedPixelError = false;

                // refresh
                SetupLine();
            }
        }

        #endregion

        #region Override Events: OnPaint, OnResize

        /// <summary>
        /// Event OnPaint, used to paint the line
        /// </summary>
        /// <param name="p">The paint event arguments</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            // validate first
            if (this.linePath == null || this.linePath.PointCount < 1)
            {
                return;
            }

            this.Region = new Region(this.linePath);
            base.OnPaint(e);
        }

        /// <summary>
        /// Event OnResize, need to setup new region
        /// </summary>
        /// <param name="e">The event arguments</param>
        protected override void OnResize(EventArgs e)
        {
            // validate first
            if (this.linePath == null || this.linePath.PointCount < 1)
            {
                return;
            }
            
            this.Region = new Region(this.linePath);
            this.Refresh();
            base.OnResize(e);
        }

        #endregion

        #region Setup and calculate line

        /// <summary>
        /// Setup and calculate line properties
        /// </summary>
        private void SetupLine()
        {
            #region Setup line direction

            // vars
            bool leftToRight = true;
            bool topToDown = true;
            bool isHorizontal = false;
            bool isVertical = false;

            // left to right
            if (this.startPoint.X > this.endPoint.X)
            {
                leftToRight = false;
            }

            // top to down
            if (this.startPoint.Y > this.endPoint.Y)
            {
                topToDown = false;
            }

            // horizontal, vertical or diagonal
            if (this.startPoint.Y == this.endPoint.Y)
            {
                // horizontal
                isHorizontal = true;
            }
            else if (this.startPoint.X == this.endPoint.X)
            {
                // vertical
                isVertical = true;
            }

            // adjust properties
            if (isHorizontal)
            {
                if (leftToRight)
                {
                    this.lineDirection = LineDirection.HorizontalLeftRight;
                }
                else
                {
                    this.lineDirection = LineDirection.HorizontalRightLeft;
                }
            }
            else if (isVertical)
            {
                if (topToDown)
                {
                    this.lineDirection = LineDirection.VerticalTopDown;
                }
                else
                {
                    this.lineDirection = LineDirection.VerticalDownTop;
                }
            }
            else
            {
                // diagonal line
                if (leftToRight)
                {
                    if (topToDown)
                    {
                        this.lineDirection = LineDirection.DiagonalTopLeftBottomRight;
                    }
                    else
                    {
                        this.lineDirection = LineDirection.DiagonalBottomLeftTopRight;
                    }
                }
                else
                {
                    if (topToDown)
                    {
                        this.lineDirection = LineDirection.DiagonalTopRightBottomLeft;
                    }
                    else
                    {
                        this.lineDirection = LineDirection.DiagonalBottomRightTopLeft;
                    }
                }
            }

            #endregion

            #region Setup Top, Left, Width and Height of control

            // left and top fixed to surrounding focus space
            this.Left = LineItem.surroundingFocusSpace;
            this.Top = LineItem.surroundingFocusSpace;

            // left and width
            if (leftToRight)
            {
                //this.Left = this.startPoint.X;
                this.Width = this.endPoint.X - this.startPoint.X;
            }
            else
            {
                //this.Left = this.endPoint.X;
                this.Width = this.startPoint.X - this.endPoint.X;
            }

            // top and height
            if (topToDown)
            {
                //this.Top = this.startPoint.Y;
                this.Height = this.endPoint.Y - this.startPoint.Y;
            }
            else
            {
                //this.Top = this.endPoint.Y;
                this.Height = this.startPoint.Y - this.endPoint.Y;
            }

            // adjust values
            if (isHorizontal)
            {
                // horizontal line (fit height to thickness)
                this.Height = Math.Max(this.Height, this.lineWidth);
            }
            else if (isVertical)
            {
                // vertical line (fit width to thickness)
                this.Width = Math.Max(this.Width, this.lineWidth);
            }

            #endregion

            #region Correct CrossPoints

            // sort and correct crossing points
            PrepareCrosspoints(this.lineDirection);

            #endregion

            #region Add line to line path

            // create new linepath from current defined points
            this.linePath = new GraphicsPath();
            Point[] polygon = null;
            int deltaXDiagonal = 0;

            // depending on line direction            
            switch (this.lineDirection)
            {
                case LineDirection.HorizontalLeftRight:
                case LineDirection.HorizontalRightLeft:
                    // calculate line path for horizontal lines including crosspoint handling
                    this.linePath = GetHorizontalOrVerticalLinePath(this.lineDirection, new Point(0, 0), new Point(this.Width, 0), this.lineWidth);

                    // adjust height depending on crosspoints
                    if (this.HasCrossPoints())
                    {
                        this.Height = this.Height + this.CrossPointDelta();
                    }
                    break;

                case LineDirection.VerticalTopDown:
                case LineDirection.VerticalDownTop:
                    // calculate line path for vertical lines including crosspoint handling
                    this.linePath = GetHorizontalOrVerticalLinePath(this.lineDirection, new Point(0, 0), new Point(0, this.Height), this.lineWidth);

                    // adjust width depending on crosspoints
                    if (this.HasCrossPoints())
                    {
                        this.Width = this.Width + this.CrossPointDelta();
                    }
                    break;

                case LineDirection.DiagonalTopLeftBottomRight:
                case LineDirection.DiagonalBottomRightTopLeft:
                    // diagonal line (case 1): (linewidth + 1 due to visibility of line)
                    deltaXDiagonal = (int)Math.Round(Math.Sqrt((double)((this.LineWidth + 1) * (this.LineWidth + 1)) / 2.0), MidpointRounding.AwayFromZero);
                    polygon = new Point[6];
                    polygon[0] = new Point(0, 0);
                    polygon[1] = new Point(deltaXDiagonal, 0);
                    polygon[2] = new Point(this.Width, this.Height - deltaXDiagonal);
                    polygon[3] = new Point(this.Width, this.Height);
                    polygon[4] = new Point(this.Width - deltaXDiagonal, this.Height);
                    polygon[5] = new Point(0, deltaXDiagonal);

                    // add polygon
                    this.linePath.AddPolygon(polygon);
                    break;

                case LineDirection.DiagonalTopRightBottomLeft:
                case LineDirection.DiagonalBottomLeftTopRight:
                    // diagonal line (case 2): (linewidth + 1 due to visibility of line)
                    deltaXDiagonal = (int)Math.Round(Math.Sqrt((double)((this.LineWidth + 1) * (this.LineWidth + 1)) / 2.0), MidpointRounding.AwayFromZero);
                    polygon = new Point[6];
                    polygon[0] = new Point(this.Width - deltaXDiagonal, 0);
                    polygon[1] = new Point(this.Width, 0);
                    polygon[2] = new Point(this.Width, deltaXDiagonal);
                    polygon[3] = new Point(deltaXDiagonal, this.Height);
                    polygon[4] = new Point(0, this.Height);
                    polygon[5] = new Point(0, this.Height - deltaXDiagonal);

                    // add polygon
                    this.linePath.AddPolygon(polygon);
                    break;
            }

            // prepare line path
            this.linePath.CloseAllFigures();

            #endregion

            #region Corrections

            // setup minsize
            this.Width = Math.Max(this.Width, 1);
            this.Height = Math.Max(this.Height, 1);

            #endregion

            #region First Paint

            // check if we need to correct one pixel: ->^ or <-V will be an missing pixel in bottom right corner otherwise
            if (!this.correctedPixelError && lineDirection == LineDirection.HorizontalLeftRight)
            {
                // correct endpoint of line
                this.endPoint = new Point(this.initEndPoint.X + this.lineWidth, this.initEndPoint.Y);
                this.correctedPixelError = true;

                // restart setup
                this.SetupLine();
            }
            else if (!this.correctedPixelError && lineDirection == LineDirection.HorizontalRightLeft)
            {
                // correct startpoint of line
                this.startPoint = new Point(this.initStartPoint.X + this.lineWidth, this.initStartPoint.Y);
                this.correctedPixelError = true;

                // restart setup
                this.SetupLine();
            }
            else
            {
                // no more need to correct pixel error
                this.correctedPixelError = true;

                // first paint
                Graphics graphics = this.CreateGraphics();
                this.OnPaint(new PaintEventArgs(graphics, new Rectangle(this.Location, this.Size)));
                graphics.Dispose();
            }

            #endregion
        }

        /// <summary>
        /// Draw a horizontal or vertical line handling the crossing points of other lines
        /// </summary>
        /// <param name="lineDirection">The line direction of the line to draw</param>
        /// <param name="from">The starting point for the line (e.g. 0/0)</param>
        /// <param name="to">The ending point for the line (e.g. width/height)</param>
        /// <param name="lineWidth">The width of the line to draw</param>
        /// <returns>The graphics path with containing the line including handling for crosspoints</returns>
        private GraphicsPath GetHorizontalOrVerticalLinePath(LineDirection lineDirection, Point from, Point to, int lineWidth)
        {
            // create new graphics path
            GraphicsPath path = new GraphicsPath();

            if (!this.HasCrossPoints())
            {
                #region Simple Line

                // we just have one line, no crossing points
                Point[] polygon = GetPolygonOfTwoPoints(lineDirection, from, to, lineWidth, false);

                // validate polygon
                if (polygon != null && polygon.Length > 0)
                {
                    path.AddPolygon(polygon);
                } 

                #endregion
            }
            else
            {
                #region Loop Crosspoints

                // define space to have blank left and right / top and bottom of crossing point
                int crossPointSurroundSpace = LineItem.crossPointSpace + LineItem.crossPointSpaceEmptyAdd;

                // loop crosspoints
                for (int i = 0; i <= crossPoints.Count; i++)
                {
                    // define polygon
                    Point[] polygon = null;
                    Point firstPoint = new Point();
                    Point lastPoint = new Point();

                    if (i == 0)
                    {
                        #region Start point to first crossing point

                        firstPoint = new Point(from.X, from.Y);

                        // depending on line direction, we have to calculate lastpoint
                        switch (lineDirection)
                        {
                            case LineDirection.HorizontalLeftRight:
                            case LineDirection.HorizontalRightLeft:
                                // horizontal line, calculate x
                                lastPoint = new Point(crossPoints[i].X - crossPointSurroundSpace, crossPoints[i].Y);
                                break;

                            case LineDirection.VerticalTopDown:
                            case LineDirection.VerticalDownTop:
                                // horizontal line, calculate y
                                lastPoint = new Point(crossPoints[i].X, crossPoints[i].Y - crossPointSurroundSpace);
                                break;
                        } 

                        #endregion
                    }
                    else if (i == crossPoints.Count)
                    {
                        #region Last crossing point to end point

                        lastPoint = new Point(to.X, to.Y);

                        // depending on line direction, we have to calculate firstpoint
                        switch (lineDirection)
                        {
                            case LineDirection.HorizontalLeftRight:
                            case LineDirection.HorizontalRightLeft:
                                // horizontal line, calculate x
                                firstPoint = new Point(crossPoints[i - 1].X + crossPointSurroundSpace, crossPoints[i - 1].Y);
                                break;

                            case LineDirection.VerticalTopDown:
                            case LineDirection.VerticalDownTop:
                                // horizontal line, calculate y
                                firstPoint = new Point(crossPoints[i - 1].X, crossPoints[i - 1].Y + crossPointSurroundSpace);
                                break;
                        } 

                        #endregion
                    }
                    else
                    {
                        #region Previous crossing point to current crossing point

                        // depending on line direction, we have to calculate firstpoint and lastpoint
                        switch (lineDirection)
                        {
                            case LineDirection.HorizontalLeftRight:
                            case LineDirection.HorizontalRightLeft:
                                // horizontal line, calculate x
                                firstPoint = new Point(crossPoints[i - 1].X + crossPointSurroundSpace, crossPoints[i - 1].Y);
                                lastPoint = new Point(crossPoints[i].X - crossPointSurroundSpace, crossPoints[i].Y);
                                break;

                            case LineDirection.VerticalTopDown:
                            case LineDirection.VerticalDownTop:
                                // horizontal line, calculate y
                                firstPoint = new Point(crossPoints[i - 1].X, crossPoints[i - 1].Y + crossPointSurroundSpace);
                                lastPoint = new Point(crossPoints[i].X, crossPoints[i].Y - crossPointSurroundSpace);
                                break;
                        } 

                        #endregion
                    }

                    #region Add line to path

                    // get polygon for the defined points
                    polygon = GetPolygonOfTwoPoints(lineDirection, firstPoint, lastPoint, lineWidth, true);

                    // validate and add polygon
                    if (polygon != null && polygon.Length > 0)
                    {
                        path.AddPolygon(polygon);
                    } 

                    #endregion

                    #region Add bridge for crossing point to path

                    // check if we need to add a bridge
                    if( i < crossPoints.Count )
                    {
                        // try to get bridge for crossing point
                        GraphicsPath bridge = GetBridgeForCrossPoint(lineDirection, crossPoints[i], lineWidth);

                        // validate
                        if (bridge != null && bridge.PointCount > 0)
                        {
                            // add bridge to path
                            path.AddPath(bridge, true);
                        }
                    }

                    #endregion
                } //[for each crossing point]

                #endregion
            }

            // return new path containing all polygons and bridges arround crossing point
            return path;
        }

        /// <summary>
        /// Get the points for a polygon which is at least a part of the whole line
        /// </summary>
        /// <param name="lineDirection">The line direction of the line to draw</param>
        /// <param name="from">The starting point for the part of the line</param>
        /// <param name="to">The ending point for the part of the line</param>
        /// <param name="lineWidth">The width of the line to draw</param>
        /// <param name="hasCrosspoints">True if calculating with crosspoints, otherwise false</param>
        /// <returns>The points needed to draw the polygon</returns>
        private Point[] GetPolygonOfTwoPoints(LineDirection lineDirection, Point from, Point to, int lineWidth, bool hasCrosspoints)
        {  
            // setup new polygon with four points
            Point[] polygon = new Point[4];

            // create polygon depending on line direction and line width
            switch (lineDirection)
            {
                case LineDirection.HorizontalLeftRight:
                case LineDirection.HorizontalRightLeft:
                    // correct y-value of from and to if crosspoints (move line a little more down within this SingleLine and adjust height in SetupLine)
                    if (hasCrosspoints)
                    {
                        from = new Point(from.X, from.Y + this.CrossPointDelta());
                        to = new Point(to.X, to.Y + this.CrossPointDelta());
                    }

                    // we draw a horizontal line
                    polygon[0] = new Point(from.X, from.Y);
                    polygon[1] = new Point(to.X, to.Y);
                    polygon[2] = new Point(to.X, to.Y + lineWidth);
                    polygon[3] = new Point(from.X, from.Y + lineWidth);
                    break;

                case LineDirection.VerticalTopDown:
                case LineDirection.VerticalDownTop:
                    // we draw a vertical line
                    polygon[0] = new Point(from.X, from.Y);
                    polygon[1] = new Point(from.X + lineWidth, from.Y);
                    polygon[2] = new Point(to.X + lineWidth, to.Y);
                    polygon[3] = new Point(to.X, to.Y);
                    break;

                default:
                    // no valid polygon
                    return null;
            }

            // if we are here, we have a valid polygon
            return polygon;
        }

        /// <summary>
        /// Get the points for a bridge over a crossing point
        /// </summary>
        /// <param name="lineDirection">The line direction of the line to draw</param>
        /// <param name="crossPoint">The crosspoint to handle</param>
        /// <param name="lineWidth">The width of the line to draw</param>
        /// <returns>The graphics path containing the bridge over the cross point</returns>
        private GraphicsPath GetBridgeForCrossPoint(LineDirection lineDirection, Point crossPoint, int lineWidth)
        {
            // calculate delta from current crosspoint
            int deltaOuter = this.CrossPointDelta() + LineItem.crossPointSpaceEmptyAdd;
            int deltaInner = LineItem.crossPointSpace + LineItem.crossPointSpaceEmptyAdd;
            
            // get path for arcs
            GraphicsPath path = new GraphicsPath();

            // create polygon depending on line direction and line width
            switch (lineDirection)
            {
                case LineDirection.HorizontalLeftRight:
                case LineDirection.HorizontalRightLeft:
                    #region Bridge like this: |¨|

                    // create polygon for the current crossing point 
                    // (attention: the top and left of the crossing point are not the same as the line itself has by within single line)
                    Point[] polygonUp = GetPolygonOfTwoPoints(LineDirection.VerticalDownTop,
                        new Point(crossPoint.X - deltaOuter, crossPoint.Y + LineItem.crossPointSpace + lineWidth),
                        new Point(crossPoint.X - deltaOuter, crossPoint.Y),
                        lineWidth, false);

                    Point[] polygonHorizontal = GetPolygonOfTwoPoints(LineDirection.HorizontalLeftRight,
                        new Point(crossPoint.X - deltaInner, crossPoint.Y),
                        new Point(crossPoint.X + deltaInner, crossPoint.Y),
                        lineWidth, false);

                    Point[] polygonDown = GetPolygonOfTwoPoints(LineDirection.VerticalTopDown,
                        new Point(crossPoint.X + deltaInner, crossPoint.Y),
                        new Point(crossPoint.X + deltaInner, crossPoint.Y + LineItem.crossPointSpace + lineWidth),
                        lineWidth, false);

                    // validate and add polygons
                    if (polygonUp != null && polygonHorizontal != null && polygonDown != null && 
                        polygonUp.Length > 0 && polygonHorizontal.Length > 0 && polygonDown.Length > 0)
                    {
                        path.AddPolygon(polygonUp);
                        path.AddPolygon(polygonHorizontal);
                        path.AddPolygon(polygonDown);
                    }

                    path.CloseFigure();
                    break; 

                    #endregion

                case LineDirection.VerticalTopDown:
                case LineDirection.VerticalDownTop:
                    #region Bridge like this: ]

                    // create polygon for the current crossing point 
                    // (attention: the top and left of the crossing point are not the same as the line itself has by within single line)
                    Point[] polygonLeftRight = GetPolygonOfTwoPoints(LineDirection.HorizontalLeftRight,
                        new Point(crossPoint.X + lineWidth, crossPoint.Y - deltaOuter),
                        new Point(crossPoint.X + lineWidth + LineItem.crossPointSpace + lineWidth, crossPoint.Y - deltaOuter),
                        lineWidth, false);

                    Point[] polygonTopDown = GetPolygonOfTwoPoints(LineDirection.VerticalTopDown,
                        new Point(crossPoint.X + lineWidth + LineItem.crossPointSpace, crossPoint.Y - deltaInner),
                        new Point(crossPoint.X + lineWidth + LineItem.crossPointSpace, crossPoint.Y + deltaInner),
                        lineWidth, false);

                    Point[] polygonRightLeft = GetPolygonOfTwoPoints(LineDirection.HorizontalRightLeft,
                        new Point(crossPoint.X + lineWidth + LineItem.crossPointSpace + lineWidth, crossPoint.Y + deltaInner),
                        new Point(crossPoint.X + lineWidth, crossPoint.Y + deltaInner),                        
                        lineWidth, false); // need to take deltaInner due to correction of line direction

                    // validate and add polygons
                    if (polygonLeftRight != null && polygonTopDown != null && polygonRightLeft != null &&
                        polygonLeftRight.Length > 0 && polygonTopDown.Length > 0 && polygonRightLeft.Length > 0)
                    {
                        path.AddPolygon(polygonLeftRight);
                        path.AddPolygon(polygonTopDown);
                        path.AddPolygon(polygonRightLeft);
                    }

                    path.CloseFigure();
                    break;

                    #endregion

                default:
                    // no valid polygon
                    return null;
            }

            // if we are here, we have a valid path
            return path;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Set a new X-value of the starting point
        /// </summary>
        /// <param name="newX">The new X-value to set (valid only >= 0)</param>
        public void NewStartingPointX(int newX)
        {
            // depending on line direction, we remove correction of pixel error
            if (this.lineDirection == LineDirection.HorizontalLeftRight || this.lineDirection == LineDirection.HorizontalRightLeft)
            {
                newX = newX - this.lineWidth;
            }
            
            // setup new starting point
            this.initStartPoint = new Point(Math.Max(newX, 0), this.initStartPoint.Y);
            NewStartingOrEndingPoint(true);
        }

        /// <summary>
        /// Set a new Y-value of the starting point
        /// </summary>
        /// <param name="newX">The new Y-value to set (valid only >= 0)</param>
        public void NewStartingPointY(int newY)
        {
            // setup new starting point
            this.initStartPoint = new Point(this.initStartPoint.X, Math.Max(newY, 0));
            NewStartingOrEndingPoint(true);
        }

        /// <summary>
        /// Set a new X-value of the ending point
        /// </summary>
        /// <param name="newX">The new X-value to set (valid only >= 0)</param>
        public void NewEndingPointX(int newX)
        {
            // depending on line direction, we remove correction of pixel error
            if (this.lineDirection == LineDirection.HorizontalLeftRight || this.lineDirection == LineDirection.HorizontalRightLeft)
            {
                newX = newX - this.lineWidth;
            }
            
            // setup new ending point
            this.initEndPoint = new Point(Math.Max(newX, 0), this.initEndPoint.Y);
            NewStartingOrEndingPoint(false);
        }

        /// <summary>
        /// Set a new Y-value of the ending point
        /// </summary>
        /// <param name="newX">The new Y-value to set (valid only >= 0)</param>
        public void NewEndingPointY(int newY)
        {
            // setup new ending point
            this.initEndPoint = new Point(this.initEndPoint.X, Math.Max(newY, 0));
            NewStartingOrEndingPoint(false);
        }

        /// <summary>
        /// Helper method for refreshing line after setting a new starting or ending point
        /// </summary>
        /// <param name="newStartingPoint">True if starting point was changed, false if ending point was changed</param>
        private void NewStartingOrEndingPoint(bool newStartingPoint)
        {
            // apply value
            if (newStartingPoint)
            {
                this.startPoint = this.initStartPoint;
            }
            else
            {
                this.endPoint = this.initEndPoint;
            }
            
            // reset flag to do correction of pixel error (due to changed ending point)
            this.correctedPixelError = false;

            // refresh
            SetupLine();
        }

        /// <summary>
        /// Get if single line contains crossing points
        /// </summary>
        /// <returns>True if single line contains cross points, otherwise false</returns>
        public bool HasCrossPoints()
        {
            return this.crossPoints != null && this.crossPoints.Count > 0;
        }

        /// <summary>
        /// Get the delta if single line contains crossing points, used for adjustments of position of single line and for calculations
        /// </summary>
        /// <returns>The delta to use for adjustments if line contains crossing points</returns>
        public int CrossPointDelta()
        {
            return LineItem.crossPointSpace + lineWidth;
        }

        /// <summary>
        /// Sort and prepare crossing points depending on line direction
        /// Hint: We assume valid crossing points
        /// </summary>
        /// <param name="lineDirection">The line direction to use for the line</param>
        private void PrepareCrosspoints(LineDirection lineDirection)
        {
            // check if crossing points are already sorted and corrected
            if (this.preparedCrossingPoints)
            {
                return;
            }

            // check if we have any crossing points to handle
            if(crossPoints == null || crossPoints.Count < 1)
            {
                this.preparedCrossingPoints = true;
                return;
            }
            
            // validate line direction, we only support horizontal and vertical lines
            switch(lineDirection)
            {
                case LineDirection.HorizontalLeftRight:
                case LineDirection.HorizontalRightLeft:
                    // sort crosspoints from x_min to x_max
                    crossPoints.Sort(
                        delegate(Point pt1, Point pt2)
                        {
                            return Comparer<int>.Default.Compare(pt1.X, pt2.X);
                        });
                    break;

                case LineDirection.VerticalTopDown:
                case LineDirection.VerticalDownTop:
                    // sort crosspoints from y_min to y_max
                    crossPoints.Sort(
                        delegate(Point pt1, Point pt2)
                        {
                            return Comparer<int>.Default.Compare(pt1.Y, pt2.Y);
                        });
                    break;

                default:
                    // do nothing if other line direction
                    return;
            }
      
            // calculate deltas for correcting crossing points to new coordinates 0/0
            int deltaX = 0;
            int deltaY = 0;

            switch (lineDirection)
            {
                case LineDirection.HorizontalLeftRight:
                case LineDirection.VerticalTopDown:
                    deltaX = this.initStartPoint.X;
                    deltaY = this.initStartPoint.Y;
                    break;

                case LineDirection.HorizontalRightLeft:
                case LineDirection.VerticalDownTop:
                    deltaX = this.initEndPoint.X;
                    deltaY = this.initEndPoint.Y;
                    break;
            }

            // remove similar crossing points and do correcting of coordinates to base 0/0
            for (int i = 0; i < crossPoints.Count; i++)
            {
                // remove similar crosspoints
                if (i < crossPoints.Count - 1 && crossPoints[i] == crossPoints[i + 1])
                {
                    // the next crossing point is the same as current --> remove item
                    crossPoints.Remove(crossPoints[i]);

                    // correct i to have the same value again
                    i--;
                }
                else
                {
                    // move point
                    crossPoints[i] = new Point(crossPoints[i].X - deltaX, crossPoints[i].Y - deltaY);
                }
            }

            // did the preparations
            this.preparedCrossingPoints = true;
        }

        #endregion
    } 

    #endregion
}