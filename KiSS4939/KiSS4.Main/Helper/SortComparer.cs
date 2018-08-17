using System;
using System.Collections.Generic;
using System.ComponentModel;
using KiSS4.DB;

namespace KiSS4.Main.Helper
{
    /// <summary>
    /// Generic SortComparer classes. Used to sort a list of objects by any property.
    /// </summary>
    /// <typeparam name="T">The type used for comparer</typeparam>
    internal class SortComparer<T> : IComparer<T>
    {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #region Fields

        #region Private Fields

        private ListSortDirection _direction = ListSortDirection.Ascending;
        private PropertyDescriptor _propDesc = null;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SortComparer&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="propDesc">The property descriptor of the sort property</param>
        /// <param name="direction">The direction used for sorting</param>
        public SortComparer(PropertyDescriptor propDesc, ListSortDirection direction)
        {
            // apply fields
            this._propDesc = propDesc;
            this._direction = direction;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Compare two values
        /// </summary>
        /// <param name="x">The first value of comparison</param>
        /// <param name="y">The second value of comparison</param>
        /// <returns>An integer depending on comparison result</returns>
        int IComparer<T>.Compare(T x, T y)
        {
            object xValue = _propDesc.GetValue(x);
            object yValue = _propDesc.GetValue(y);

            return CompareValues(xValue, yValue, _direction);
        }

        #endregion

        #region Private Methods

        private int CompareValues(object xValue, object yValue, ListSortDirection direction)
        {
            try
            {
                // validate
                if (xValue == null && yValue == null)
                {
                    // invalid, cannot compare
                    return 0;
                }

                // init default value
                int retValue = 0;

                // compare
                if (xValue is IComparable) // can ask the x value
                {
                    retValue = ((IComparable)xValue).CompareTo(yValue);
                }
                else if (yValue is IComparable) // can ask the y value
                {
                    retValue = ((IComparable)yValue).CompareTo(xValue);
                }
                else if (!xValue.Equals(yValue))
                {
                    //not comparable, compare string representations
                    retValue = xValue.ToString().CompareTo(yValue.ToString());
                }

                if (direction == ListSortDirection.Ascending)
                {
                    return retValue;
                }
                else
                {
                    return retValue * -1;
                }
            }
            catch (Exception ex)
            {
                // Eintrag ins Log.
                LOG.ErrorFormat("Fehler in: [{0}]. Exception: [{1}]", GetType().FullName, ex.Message);

                // Eintrag ins Log (Ansicht unter Anwendung/Newod Schnittstelle/Protokolle)
                XLog.Create(GetType().FullName, LogLevel.ERROR, ex.Message);

                // stop here on failure
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }

                // return
                return 0;
            }
        }

        #endregion

        #endregion
    }
}