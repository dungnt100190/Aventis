using System;

namespace KiSS4.Gui.Layout
{
    /// <summary>
    /// An exception that occurred during getting or setting of a layout.
    /// </summary>
    public class LayoutException : Exception
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Gets the <see cref="LayoutError"/>s.
        /// </summary>
        public readonly LayoutErrorCollection Errors;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize with a message and a <see cref="LayoutErrorCollection"/>.
        /// </summary>
        /// <param name="errors">A non-empty <see cref="LayoutErrorCollection"/>.</param>
        public LayoutException(LayoutErrorCollection errors)
            : base(errors.ToString())
        {
            if (errors == null)
            {
                throw new ArgumentNullException("errors");
            }

            if (errors.Count == 0)
            {
                throw new ArgumentException("Cannot be empty.", "errors");
            }

            Errors = errors;
        }

        #endregion
    }
}