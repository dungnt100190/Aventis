using System;
using System.Windows;

namespace Kiss.UI.Controls.Constant
{
    /// <summary>
    /// Defines layout constants and properties used for binding in views.
    /// Naming:
    /// - OuterControl=View or Control (such as a query-view or master-detail-view)
    /// - MainControl=A typical main part of the OuterControl (such as DataGrid, DetailGrid, GroupBox, etc.)
    /// - DetailControl=A detail control within a MainControl (such as TextBox, Label, etc.)
    /// </summary>
    public class LayoutConstant
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const int DETAIL_CONTROL_HEIGHT = 24;
        private const int DETAIL_CONTROL_MARGIN = 6;
        private const int DETAIL_CONTROL_MARGIN_SMALL = 3;
        private const int DETAIL_CONTROL_WIDTH_LABEL = 100;
        private const int MAIN_CONTROL_MARGIN = 10;
        private const int OUTER_CONTROL_MARGIN = 10;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets the column width used between detail controls
        /// </summary>
        public static GridLength ColumnWidthDetailControl
        {
            get { return new GridLength(DETAIL_CONTROL_MARGIN); }
        }

        /// <summary>
        /// Gets the column width used for the label column
        /// </summary>
        public static GridLength ColumnWidthDetailControlLabel
        {
            get { return new GridLength(DETAIL_CONTROL_WIDTH_LABEL); }
        }

        /// <summary>
        /// Gets the height of a default detail control (such as a label, textbox, etc.)
        /// </summary>
        public static double DefaultHeightDetailControl
        {
            get { return Convert.ToDouble(DETAIL_CONTROL_HEIGHT); }
        }

        /// <summary>
        /// Gets the width of a default detail control label
        /// </summary>
        public static double DefaultWidthDetailControlLabel
        {
            get { return Convert.ToDouble(DETAIL_CONTROL_WIDTH_LABEL); }
        }

        /// <summary>
        /// Gets the space used between detail controls
        /// </summary>
        public static int DetailControlMargin
        {
            get { return DETAIL_CONTROL_MARGIN; }
        }

        /// <summary>
        /// Gets the FontSize of a Label.
        /// </summary>
        public static double LabelFontSize
        {
            get { return 11; }
        }

        /// <summary>
        /// Gets the margin (full) used for detail controls (e.g. within groupbox as padding)
        /// </summary>
        public static Thickness MarginDetailControl
        {
            get { return new Thickness(DETAIL_CONTROL_MARGIN); }
        }

        /// <summary>
        /// Gets the margin (only bottom is set > 0) used for detail controls (e.g. space between previous control and next label)
        /// </summary>
        public static Thickness MarginDetailControlBottom
        {
            get { return new Thickness(0, 0, 0, DETAIL_CONTROL_MARGIN); }
        }

        /// <summary>
        /// Gets the margin (only left is set > 0) used for detail controls (e.g. space between previous control and next label)
        /// </summary>
        public static Thickness MarginDetailControlLeft
        {
            get { return new Thickness(DETAIL_CONTROL_MARGIN, 0, 0, 0); }
        }

        /// <summary>
        /// Gets the margin (only left is set > 0) used for detail controls (e.g. space between previous control and next label)
        /// </summary>
        public static Thickness MarginDetailControlRight
        {
            get { return new Thickness(0, 0, DETAIL_CONTROL_MARGIN, 0); }
        }

        /// <summary>
        /// Gets the margin (only left is set > 0) used for detail controls (e.g. space between previous control and next label)
        /// </summary>
        public static Thickness MarginDetailControlSmallLeft
        {
            get { return new Thickness(DETAIL_CONTROL_MARGIN_SMALL, 0, 0, 0); }
        }

        /// <summary>
        /// Gets the margin (only left is set to 0) used for detail controls
        /// </summary>
        public static Thickness MarginDetailControlTopRightBottom
        {
            get { return new Thickness(0, DETAIL_CONTROL_MARGIN, DETAIL_CONTROL_MARGIN, DETAIL_CONTROL_MARGIN); }
        }

        public static double MarginMainControl
        {
            get { return MAIN_CONTROL_MARGIN; }
        }

        /// <summary>
        /// Gets the margin (only bottom is set > 0) used between main controls
        /// </summary>
        public static Thickness MarginMainControlBottom
        {
            get { return new Thickness(0, 0, 0, MAIN_CONTROL_MARGIN); }
        }

        /// <summary>
        /// Gets the margin (only left is set > 0) used between main controls
        /// </summary>
        public static Thickness MarginMainControlLeft
        {
            get { return new Thickness(MAIN_CONTROL_MARGIN, 0, 0, 0); }
        }

        /// <summary>
        /// Gets the margin (only right is set > 0) used between main controls
        /// </summary>
        public static Thickness MarginMainControlRight
        {
            get { return new Thickness(0, 0, MAIN_CONTROL_MARGIN, 0); }
        }

        /// <summary>
        /// Gets the margin (only top is set > 0) used between main controls
        /// </summary>
        public static Thickness MarginMainControlTop
        {
            get { return new Thickness(0, MAIN_CONTROL_MARGIN, 0, 0); }
        }

        /// <summary>
        /// Gets the margin (only top and bottom is set > 0) used between main controls
        /// </summary>
        public static Thickness MarginMainControlTopBottom
        {
            get { return new Thickness(0, MAIN_CONTROL_MARGIN, 0, MAIN_CONTROL_MARGIN); }
        }

        /// <summary>
        /// Gets the margin (full) used arround view or control (something like padding of a main view)
        /// </summary>
        public static Thickness MarginOuterControl
        {
            get { return new Thickness(OUTER_CONTROL_MARGIN); }
        }

        /// <summary>
        /// Gets the row height used between detail controls
        /// </summary>
        public static GridLength RowHeightDetailControl
        {
            get { return new GridLength(DETAIL_CONTROL_MARGIN); }
        }

        /// <summary>
        /// Gets the smaller row height used between detail controls
        /// </summary>
        public static GridLength RowHeightDetailControlSmall
        {
            get { return new GridLength(DETAIL_CONTROL_MARGIN_SMALL); }
        }

        /// <summary>
        /// Gets the row height used between main controls
        /// </summary>
        public static GridLength RowHeightMainControl
        {
            get { return new GridLength(MAIN_CONTROL_MARGIN); }
        }

        #endregion
    }
}