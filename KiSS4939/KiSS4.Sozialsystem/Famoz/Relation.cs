using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialsystem.Famoz
{
    #region Enumerations

    /// <summary>
    /// The type of the relation
    /// </summary>
    public enum RelationType
    {
        /// <summary>
        /// Client to client relation
        /// </summary>
        Client_Client,

        /// <summary>
        /// Involved person to client relation
        /// </summary>
        InvolvedPerson_Client,

        /// <summary>
        /// Involved organisation to client relation
        /// </summary>
        InvolvedOrganisation_Client,

        /// <summary>
        /// Service provider to client relation
        /// </summary>
        ServiceProvider_Client
    }

    #endregion

    /// <summary>
    /// A relation between two BaseItems
    /// </summary>
    public class Relation : IDisposable
    {
        #region Fields

        #region Private Static Fields

        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The space between the base item and the label to the top or bottom of the base item
        /// </summary>
        private const int cItemLabelSpace = 2;

        /// <summary>
        /// The horizontal width of the label
        /// </summary>
        private const int cLabelWidth = 14;

        /// <summary>
        /// The space between the label and the line to the left of the line
        /// </summary>
        private const int cLeftLineLabelSpace = 2;

        /// <summary>
        /// The space between the label and the next potential horizontal line on top or bottom of the label
        /// </summary>
        private const int cTopBottomLineLabelSpace = 3;

        #endregion

        #region Private Fields

        /// <summary>
        /// The target control to draw the lines on (the same where the coordinates are calculated for)
        /// </summary>
        private Control ctlTarget;

        /// <summary>
        /// The list containing all line parts of the whole relation
        /// </summary>
        private List<SSGraphLineItem> graphLineItems;

        /// <summary>
        /// The label for the first relation text
        /// </summary>
        private KissVerticalLabel lblRelationFrom;

        /// <summary>
        /// The label for the second relation text
        /// </summary>
        private KissVerticalLabel lblRelationTo;

        /// <summary>
        /// The color of the lines to draw (setup once)
        /// </summary>
        private Color lineColor;

        /// <summary>
        /// The list containing all line items that belong to this relation
        /// </summary>
        private List<LineItem> lineItems;

        /// <summary>
        /// The tickness of the lines to draw (setup once)
        /// </summary>
        private int lineWidth;

        /// <summary>
        /// The tooltip to use for the labels of the relation
        /// </summary>
        private ToolTip ttpRelationLabels = new ToolTip();

        /// <summary>
        /// The tooltip to use for the line items of the relation
        /// </summary>
        private ToolTip ttpRelationLines = new ToolTip();

        /// <summary>
        /// The relation type of the relation
        /// </summary>
        private RelationType type;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor of a new relation between two BaseItems
        /// </summary>
        /// <param name="ctlTarget">The target control to draw the lines on (the same where the coordinates are calculated for)</param>
        /// <param name="type">The type of the relation <see>ReferenceType</see></param>
        /// <param name="graphLineItems">A list of all lines used to draw this specific relation</param>
        public Relation(Control ctlTarget, RelationType type, List<SSGraphLineItem> graphLineItems)
        {
            // validate
            if (ctlTarget == null)
            {
                throw new ArgumentNullException("ctlTarget", "The target control to paint the lines on must be valid.");
            }

            // apply fields
            this.ctlTarget = ctlTarget;
            this.type = type;
            this.graphLineItems = graphLineItems;

            // depending on type, setup color and thickness
            switch (this.type)
            {
                case RelationType.Client_Client:
                    this.lineColor = Color.Black;
                    this.lineWidth = 1;
                    break;

                case RelationType.InvolvedPerson_Client:
                    this.lineColor = Color.Blue;
                    this.lineWidth = 1;
                    break;

                case RelationType.InvolvedOrganisation_Client:
                    this.lineColor = Color.ForestGreen;
                    this.lineWidth = 1;
                    break;

                case RelationType.ServiceProvider_Client:
                    this.lineColor = Color.Red;
                    this.lineWidth = 1;
                    break;
            }

            // setup relation labels
            this.lblRelationFrom = new KissVerticalLabel();
            this.lblRelationFrom.BackColor = Color.White;
            this.lblRelationFrom.DrawDirection = DrawDirection.TopDown;
            this.lblRelationFrom.AutoEllipsis = true;
            this.lblRelationFrom.Width = cLabelWidth;
            this.lblRelationFrom.Height = SozialsystemBuilder.cstLabelHeight - cItemLabelSpace - cTopBottomLineLabelSpace - 8;
            this.lblRelationFrom.TabStop = false;

            this.lblRelationTo = new KissVerticalLabel();
            this.lblRelationTo.BackColor = Color.White;
            this.lblRelationTo.DrawDirection = DrawDirection.TopDown;
            this.lblRelationTo.AutoEllipsis = true;
            this.lblRelationTo.Width = cLabelWidth;
            this.lblRelationTo.Height = this.lblRelationFrom.Height;    // take same height for both labels, otherwise you have to change code above
            this.lblRelationTo.TabStop = false;

            // setup tooltips
            this.ttpRelationLines.ToolTipTitle = KissMsg.GetMLMessage("SozialsystemRelation", "ToolTipRelationLinesTitle", "Beziehung");
            this.ttpRelationLabels.ToolTipTitle = KissMsg.GetMLMessage("SozialsystemRelation", "ToolTipRelationLabelsTitle", "Beziehung");

            // draw the lines
            this.DrawLines();
        }

        #endregion

        #region Dispose

        /// <summary>
        /// Dispose all line items for cleanup
        /// </summary>
        public void Dispose()
        {
            // dispose all line items
            if (lineItems != null && lineItems.Count > 0)
            {
                try
                {
                    // remove focus
                    SetupForFocus(false);

                    // loop lines
                    foreach (LineItem lineItem in lineItems)
                    {
                        lineItem.Dispose();
                    }

                    // clear list
                    lineItems.Clear();
                }
                catch (Exception ex)
                {
                    // create new entry in XLog table
                    XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                    // something went wrong
                    if (System.Diagnostics.Debugger.IsAttached)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }

            // destroy list
            lineItems = null;
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Event GotFocus for any line of the relation
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void lineItem_GotFocus(object sender, EventArgs e)
        {
            SetupForFocus(true);
        }

        /// <summary>
        /// Event LostFocus for any line of the relation
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void lineItem_LostFocus(object sender, EventArgs e)
        {
            SetupForFocus(false);
        }

        /// <summary>
        /// Event GotFocus for the vertical labels of the relation
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void relationLabel_GotFocus(object sender, EventArgs e)
        {
            SetupForFocus(true);
        }

        /// <summary>
        /// Event LostFocus for the vertical labels of the relation
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void relationLabel_LostFocus(object sender, EventArgs e)
        {
            SetupForFocus(false);
        }

        #endregion

        #region Methods

        #region Private Methods

        /// <summary>
        /// Draw the list of lines
        /// </summary>
        /// <returns></returns>
        private void DrawLines()
        {
            try
            {
                // clean up line items
                this.Dispose();
                this.lineItems = new List<LineItem>();

                // validate first
                if (this.graphLineItems == null || this.graphLineItems.Count < 1)
                {
                    // do nothing more
                    return;
                }

                #region Debug only
                /*
                // remove existing items and add debug items to list
                this.graphLineItems.Clear();

                // we need 10 lines to validate each case of line position change (horizontal and vertical only)
                SSGraphLineItem line01 = new SSGraphLineItem();     // >>
                line01.IsStartPoint = true;
                line01.From = new Point(100, 100);
                line01.To = new Point(220, 100);
                line01.CrossPoints = new List<Point>();
                line01.CrossPoints.Add(new Point(line01.From.X + 20, line01.From.Y));

                SSGraphLineItem line02 = new SSGraphLineItem();     // V
                line02.From = line01.To;
                line02.To = new Point(220, 200);
                line02.CrossPoints = new List<Point>();
                line02.CrossPoints.Add(new Point(line02.From.X, line02.From.Y + 20));

                SSGraphLineItem line03 = new SSGraphLineItem();     // <<
                line03.From = line02.To;
                line03.To = new Point(50, 200);
                line03.CrossPoints = new List<Point>();
                line03.CrossPoints.Add(new Point(line03.From.X - 20, line03.From.Y));

                SSGraphLineItem line04 = new SSGraphLineItem();     // ^
                line04.From = line03.To;
                line04.To = new Point(50, 50);
                line04.CrossPoints = new List<Point>();
                line04.CrossPoints.Add(new Point(line04.From.X, line04.From.Y - 20));

                SSGraphLineItem line05 = new SSGraphLineItem();     // >>
                line05.From = line04.To;
                line05.To = new Point(200, 50);
                line05.CrossPoints = new List<Point>();
                line05.CrossPoints.Add(new Point(line05.From.X + 20, line05.From.Y));

                SSGraphLineItem line06 = new SSGraphLineItem();     // ^
                line06.From = line05.To;
                line06.To = new Point(200, 20);
                line06.CrossPoints = new List<Point>();
                line06.CrossPoints.Add(new Point(line06.From.X, line06.From.Y - 10));

                SSGraphLineItem line07 = new SSGraphLineItem();     // <<
                line07.From = line06.To;
                line07.To = new Point(20, 20);
                line07.CrossPoints = new List<Point>();
                line07.CrossPoints.Add(new Point(line07.From.X - 20, line07.From.Y));

                SSGraphLineItem line08 = new SSGraphLineItem();     // V
                line08.From = line07.To;
                line08.To = new Point(20, 80);
                line08.CrossPoints = new List<Point>();
                line08.CrossPoints.Add(new Point(line08.From.X, line08.From.Y + 20));

                SSGraphLineItem line09 = new SSGraphLineItem();     // >>
                line09.From = line08.To;
                line09.To = new Point(80, 80);
                line09.CrossPoints = new List<Point>();
                line09.CrossPoints.Add(new Point(line09.From.X + 20, line09.From.Y));

                SSGraphLineItem line10 = new SSGraphLineItem();     // ^
                line10.From = line09.To;
                line10.To = new Point(80, 60);
                line10.CrossPoints = new List<Point>();
                line10.CrossPoints.Add(new Point(line10.From.X, line10.From.Y - 10));

                // add lines to list
                this.graphLineItems.Add(line01);
                this.graphLineItems.Add(line02);
                this.graphLineItems.Add(line03);
                this.graphLineItems.Add(line04);
                this.graphLineItems.Add(line05);
                this.graphLineItems.Add(line06);
                this.graphLineItems.Add(line07);
                this.graphLineItems.Add(line08);
                this.graphLineItems.Add(line09);
                this.graphLineItems.Add(line10);

                // clear container for proper view
                this.ctlTarget.Controls.Clear();

                // init vars for line color debugger
                int i = 0;
                */
                #endregion

                // loop through parts of the lines and draw the line
                foreach (SSGraphLineItem line in this.graphLineItems)
                {
                    #region Create new LineItem

                    #region Debug only
                    /*
                    i++;
                    this.lineColor = i % 2 == 0 ? Color.Red : Color.Blue;

                    if (i % 2 == 0)
                    {
                        //continue;
                    }
                    */
                    #endregion

                    // check if from and to is the same
                    if (line.From == line.To)
                    {
                        continue;
                    }

                    // create a new line item
                    LineItem lineItem = new LineItem(line.From, line.To, this.lineColor, this.lineWidth, line.CrossPoints);

                    // add line item to local collection
                    this.lineItems.Add(lineItem);

                    // add line item to target control
                    this.ctlTarget.Controls.Add(lineItem);
                    lineItem.BringToFront();
                    lineItem.Anchor = line.Anchor;

                    // register events
                    lineItem.LineGotFocus += new EventHandler(lineItem_GotFocus);
                    lineItem.LineLostFocus += new EventHandler(lineItem_LostFocus);

                    #endregion

                    #region Create Labels

                    // check if line is starting point or ending point with valid text
                    if ((line.IsStartPoint && !DBUtil.IsEmpty(line.DockingTextFrom)) || (line.IsEndPoint && !DBUtil.IsEmpty(line.DockingTextTo)))
                    {
                        // setup label
                        int labelLeft = line.From.X + cLeftLineLabelSpace;          // left for startpoint and endpoint  labels (same for both)
                        int labelTopStart = 0;                                      // the top of the startpoint label
                        int labelTopEnd = 0;                                        // the top of the endpoint label
                        ContentAlignment alignStart = ContentAlignment.BottomLeft;  // the alignment for the startpoint label
                        ContentAlignment alignEnd = ContentAlignment.BottomLeft;    // the alignment for the startpoint label

                        // apply top depending on line direction (only vertical lines are supported)
                        switch (lineItem.LineDirection)
                        {
                            case LineDirection.VerticalTopDown:
                            case LineDirection.VerticalDownTop:
                                // startpoint
                                if (line.IsStartPoint)
                                {
                                    switch (lineItem.LineDirection)   // docking to box
                                    {
                                        case LineDirection.VerticalDownTop:     // docking top
                                            labelTopStart = line.From.Y - cItemLabelSpace - this.lblRelationFrom.Height;
                                            alignStart = ContentAlignment.BottomRight;
                                            break;
                                        case LineDirection.VerticalTopDown:     // docking bottom
                                            labelTopStart = line.From.Y + cItemLabelSpace;
                                            break;
                                    }
                                }

                                // endpoint (can have both on same line)
                                if (line.IsEndPoint)
                                {
                                    switch (lineItem.LineDirection)
                                    {
                                        case LineDirection.VerticalTopDown:     // docking top
                                            labelTopEnd = line.To.Y - cItemLabelSpace - this.lblRelationTo.Height;
                                            alignEnd = ContentAlignment.BottomRight;
                                            break;
                                        case LineDirection.VerticalDownTop:     // docking bottom
                                            labelTopEnd = line.To.Y + cItemLabelSpace;
                                            break;
                                    }
                                }
                                break;
                        }

                        // startpoint label
                        if (line.IsStartPoint)
                        {
                            this.lblRelationFrom.Text = line.DockingTextFrom;
                            this.lblRelationFrom.Left = labelLeft;
                            this.lblRelationFrom.Top = labelTopStart;
                            this.lblRelationFrom.TextAlign = alignStart;
                            this.ttpRelationLabels.SetToolTip(this.lblRelationFrom, this.lblRelationFrom.Text);

                            // add label to target control
                            this.ctlTarget.Controls.Add(this.lblRelationFrom);
                            this.lblRelationFrom.BringToFront();

                            // add event
                            this.lblRelationFrom.GotFocus += new EventHandler(relationLabel_GotFocus);
                            this.lblRelationFrom.LostFocus += new EventHandler(relationLabel_LostFocus);
                        }

                        // endpoint label
                        if (line.IsEndPoint)
                        {
                            this.lblRelationTo.Text = line.DockingTextTo;
                            this.lblRelationTo.Left = labelLeft;
                            this.lblRelationTo.Top = labelTopEnd;
                            this.lblRelationTo.TextAlign = alignEnd;
                            this.ttpRelationLabels.SetToolTip(this.lblRelationTo, this.lblRelationTo.Text);

                            // add label to target control
                            this.ctlTarget.Controls.Add(this.lblRelationTo);
                            this.lblRelationTo.BringToFront();

                            // add event
                            this.lblRelationTo.GotFocus += new EventHandler(relationLabel_GotFocus);
                            this.lblRelationTo.LostFocus += new EventHandler(relationLabel_LostFocus);
                        }
                    }

                    #endregion
                }

                #region Add Tooltips

                // add tooltip to each line item depending on values we have
                if (!DBUtil.IsEmpty(this.lblRelationFrom.Text) && !DBUtil.IsEmpty(this.lblRelationTo.Text))
                {
                    // add tooltip to each line
                    if (lineItems != null && lineItems.Count > 0)
                    {
                        // setup tooltip text
                        string toolTipText = string.Format("{0} - {1}", this.lblRelationFrom.Text, this.lblRelationTo.Text);

                        // add tooltip to each line of relation
                        foreach (LineItem lineItem in lineItems)
                        {
                            ttpRelationLines.SetToolTip(lineItem, toolTipText);
                        }
                    }
                }

                #endregion
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

                // throw exception further on due to unknown state
                throw ex;
            }
        }

        /// <summary>
        /// Setup focus property on lines of current relation
        /// </summary>
        /// <param name="hasFocus">True if one line has focus, otherwise false</param>
        private void SetupForFocus(bool hasFocus)
        {
            // check if lost focus and a new item got focus, prevent refocusing
            if (!hasFocus)
            {
                if (this.lblRelationFrom.Focused || this.lblRelationTo.Focused)
                {
                    return;
                }
            }

            // setup all line items
            if (lineItems != null && lineItems.Count > 0)
            {
                foreach (LineItem lineItem in lineItems)
                {
                    lineItem.LineHasFocus = hasFocus;
                }
            }

            // setup labels
            if (this.lblRelationFrom.Visible)
            {
                if (hasFocus)
                {
                    this.lblRelationFrom.Font = new Font(this.lblRelationFrom.Font, FontStyle.Bold);
                    this.lblRelationFrom.BringToFront();
                }
                else
                {
                    this.lblRelationFrom.Font = new Font(this.lblRelationFrom.Font, FontStyle.Regular);
                }
            }
            if (this.lblRelationTo.Visible)
            {
                if (hasFocus)
                {
                    this.lblRelationTo.Font = new Font(this.lblRelationTo.Font, FontStyle.Bold);
                    this.lblRelationTo.BringToFront();
                }
                else
                {
                    this.lblRelationTo.Font = new Font(this.lblRelationTo.Font, FontStyle.Regular);
                }
            }
        }

        #endregion

        #endregion
    }
}