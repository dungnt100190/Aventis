using System;
using System.Windows.Forms;

namespace KiSS4.Gui.Layout
{
    #region Delegates

    /// <summary>
    /// Delegate for handling KissLayout events.
    /// </summary>
    public delegate void KissLayoutEventHandler(object sender, KissLayoutEventArgs e);

    #endregion

    /// <summary>
    /// <see cref="EventArgs"/> used for <see cref="LayoutEventHandler"/>.
    /// </summary>
    /// <remarks>
    /// Contains the <see cref="Layout"/> property which can be used to save and retrieve layout information.
    /// If errors occur, they should be added to the <see cref="Errors"/> collection.
    /// </remarks>
    public class KissLayoutEventArgs : EventArgs
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Gets the collection of errors that occurred during getting or setting of a layout.
        /// </summary>
        public readonly LayoutErrorCollection Errors = new LayoutErrorCollection();

        /// <summary>
        /// The event's <see cref="KissControlLayout"/>.
        /// </summary>
        public readonly KissControlLayout Layout;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissLayoutEventArgs"/> class.
        /// </summary>
        /// <param name="layout">The layout.</param>
        public KissLayoutEventArgs(KissControlLayout layout)
        {
            if (layout == null)
            {
                throw new ArgumentNullException("layout");
            }

            Layout = layout;
        }

        #endregion
    }
}