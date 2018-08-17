using System;
using System.Collections;

namespace KiSS4.Gui.Layout
{
    /// <summary>
    /// Collection of <see cref="LayoutError"/> objects.
    /// </summary>
    public class LayoutErrorCollection : ICollection
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly ArrayList _items = new ArrayList();

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.ICollection"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>The number of elements contained in the <see cref="T:System.Collections.ICollection"></see>.</returns>
        public int Count
        {
            get { return _items.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"></see> is synchronized (thread safe).
        /// </summary>
        /// <value></value>
        /// <returns>true if access to the <see cref="T:System.Collections.ICollection"></see> is synchronized (thread safe); otherwise, false.</returns>
        public bool IsSynchronized
        {
            get { return false; }
        }

        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"></see>.
        /// </summary>
        /// <value></value>
        /// <returns>An object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"></see>.</returns>
        public object SyncRoot
        {
            get { return this; }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets the <see cref="KiSS4.Gui.Layout.LayoutError"/> at the specified index.
        /// </summary>
        /// <value></value>
        public LayoutError this[int index]
        {
            get { return (LayoutError)_items[index]; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void Add(LayoutError value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            _items.Add(value);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.ICollection"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.ICollection"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
        /// <param name="index">The zero-based index in array at which copying begins.</param>
        /// <exception cref="T:System.ArgumentNullException">array is null. </exception>
        /// <exception cref="T:System.ArgumentException">The type of the source <see cref="T:System.Collections.ICollection"></see> cannot be cast automatically to the type of the destination array. </exception>
        /// <exception cref="T:System.ArgumentOutOfRangeException">index is less than zero. </exception>
        /// <exception cref="T:System.ArgumentException">array is multidimensional.-or- index is equal to or greater than the length of array.-or- The number of elements in the source <see cref="T:System.Collections.ICollection"></see> is greater than the available space from index to the end of the destination array. </exception>
        public void CopyTo(Array array, int index)
        {
            _items.CopyTo(array, index);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        /// <summary>
        /// string containing errors, separated by \r\n.
        /// </summary>
        public override string ToString()
        {
            string[] errors = new string[_items.Count];

            for (int i = 0; i < _items.Count; i++)
            {
                errors[i] = "- " + _items[i];
            }

            string ret = string.Join(Environment.NewLine, errors);
            return ret;
        }

        #endregion

        #endregion
    }
}