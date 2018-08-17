using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace KiSS4.Main.Helper
{
    /// <summary>
    /// Class for sorting available assemblies.
    /// Source: http://www.tech-archive.net/Archive/DotNet/microsoft.public.dotnet.languages.csharp/2008-03/msg02808.html
    /// </summary>
    internal class SortableBindingList<T> : BindingList<T>, IRaiseItemChangedEvents
    {
        #region Fields

        #region Private Fields

        private ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private PropertyDescriptor _sortProperty = null;
        private bool _sorted = false;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Return the value retained locally. Tells if the list is sorted or not.
        /// </summary>
        protected override bool IsSortedCore
        {
            get { return this._sorted; }
        }

        /// <summary>
        /// Return the value retained locally. Tells which direction the list is sorted.
        /// </summary>
        protected override ListSortDirection SortDirectionCore
        {
            get { return this._sortDirection; }
        }

        /// <summary>
        /// Return the value retained locally. Tells which property the list is sorted on.
        /// </summary>
        protected override PropertyDescriptor SortPropertyCore
        {
            get { return _sortProperty; }
        }

        /// <summary>
        /// Override the value and set it to true so sorting will work on the list.
        /// </summary>
        protected override Boolean SupportsSearchingCore
        {
            get { return true; }
        }

        /// <summary>
        /// Override the value and set it to true so sorting will work on the list.
        /// </summary>
        protected override bool SupportsSortingCore
        {
            get { return true; }
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Sets the properties when called by the base class in response to the ApplySort call.
        /// Delegates to a helper method (ApplySortInternal) to do most of the work of the sorting.
        /// </summary>
        /// <param name="prop">The property descriptor used for sorting</param>
        /// <param name="direction">The direction used for sorting</param>
        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            // apply fields
            this._sortDirection = direction;
            this._sortProperty = prop;

            // init comparer
            SortComparer<T> comparer = new SortComparer<T>(prop, direction);

            // do sort on property
            this.ApplySortInternal(comparer);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Helper class to do the actual sorting work.
        /// </summary>
        /// <param name="comparer">The <see cref="SortComparer&lt;T&gt;"/> used for sorting values</param>
        private void ApplySortInternal(SortComparer<T> comparer)
        {
            // this causes the items in the collection maintained by the base class to be sorted according to the criteria provided to the SortComparer class.
            List<T> listRef = this.Items as List<T>;

            // check if valid list is available
            if (listRef == null)
            {
                return;
            }

            // let List<T> do the actual sorting based on your comparer
            listRef.Sort(comparer);
            this._sorted = true;

            // fire an event through a call to the base class OnListChanged method indicating that the list has been changed.
            // Use 'reset' because it's likely that most members have been moved around.
            this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        #endregion

        #endregion
    }
}