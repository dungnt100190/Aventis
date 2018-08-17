using System;
using System.Windows.Forms;

namespace KiSS4.Gui.Layout
{
    /// <summary>
    /// An error that occurred when getting or setting a property
    /// </summary>
    public class LayoutError
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// The control.
        /// </summary>
        public readonly Control Control;

        /// <summary>
        /// The thrown exception.
        /// </summary>
        public readonly Exception Exception;

        /// <summary>
        /// The property.
        /// </summary>
        public readonly Property Property;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutError"/> class.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="property">The property.</param>
        /// <param name="exception">The exception.</param>
        public LayoutError(Control control, Property property, Exception exception)
            : this(property, exception)
        {
            Control = control;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LayoutError"/> class.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <param name="exception">The exception.</param>
        public LayoutError(Property property, Exception exception)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }

            if (exception == null)
            {
                throw new ArgumentNullException("exception");
            }

            Property = property;
            Exception = exception;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            string controlName = Control == null ? string.Empty : Control.Name;

            return string.Format("{0} {1}:\t{2}", controlName, Property, Exception.Message);
        }

        #endregion

        #endregion
    }
}