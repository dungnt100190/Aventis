using System;
using System.Collections;
using System.Xml;

namespace KiSS4.Gui.Layout
{
    /// <summary>
    /// An <see cref="ICollection"/> of <see cref="KissControlLayout"/> objects.
    /// </summary>
    public class ControlLayoutCollection : ICollection
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// The hashtable.
        /// </summary>
        private readonly Hashtable _hash = new Hashtable();

        /// <summary>
        /// Items in this collection.
        /// </summary>
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
        /// Gets the <see cref="KiSS4.Gui.Layout.KissControlLayout"/> at the specified index.
        /// </summary>
        /// <value></value>
        public KissControlLayout this[int index]
        {
            get { return (KissControlLayout)_items[index]; }
        }

        /// <summary>
        /// Gets the <see cref="KissControlLayout"/> with the specified name.
        /// </summary>
        /// <exception cref="ArgumentException">No ControlLayout with this name exists in the collection.</exception>
        public KissControlLayout this[string name]
        {
            get
            {
                if (name == null)
                {
                    throw new ArgumentNullException("name");
                }

                KissControlLayout ret = (KissControlLayout)_hash[name];

                if (ret == null)
                {
                    throw new ArgumentException("No ControlLayout with this name exists in the collection.");
                }
                return ret;
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="controlLayouts">The control layouts.</param>
        public static void FromXml(XmlElement parent, ControlLayoutCollection controlLayouts)
        {
            foreach (XmlNode nd in parent.ChildNodes)
            {
                if (nd is XmlElement)
                {
                    XmlElement ele = (XmlElement)nd;

                    if (ele.NamespaceURI == KissControlLayout.NameSpaceUri && ele.LocalName == KissControlLayout.ControlLayoutEle)
                    {
                        controlLayouts.Add(KissControlLayout.FromXml(ele));
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add a <see cref="KissControlLayout"/> to the collection.
        /// </summary>
        /// <exception cref="ArgumentNullException">cl is a null reference.</exception>
        /// <exception cref="ArgumentException">An element with the same name already exists in the collection.</exception>
        public void Add(KissControlLayout cl)
        {
            if (cl == null)
            {
                throw new ArgumentNullException("cl");
            }

            _hash.Add(cl.Name, cl); // this will throw an exception if already there
            _items.Add(cl);
        }

        /// <summary>
        /// Add the items of the collection as <see cref="XmlElement"/>s to the parent node.
        /// </summary>
        /// <returns>true if at least one <see cref="KissControlLayout"/> was added; false otherwise.</returns>
        public bool AddXml(XmlElement parent)
        {
            bool ret = false;

            foreach (KissControlLayout cl in _items)
            {
                ret |= cl.AddXml(parent);
            }

            return ret;
        }

        /// <summary>
        /// returns true if the specified ControlLayout Name already exists in the collection.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool ContainsKey(string name)
        {
            return _hash.ContainsKey(name);
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

        #endregion

        #endregion
    }
}