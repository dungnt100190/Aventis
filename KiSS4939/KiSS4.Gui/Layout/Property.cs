using System;
using System.Xml;

namespace KiSS4.Gui.Layout
{
    /// <summary>
    /// Abstract class for a property.
    /// </summary>
    public abstract class Property
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Gets the name of the property.
        /// </summary>
        public readonly string Name;

        #endregion

        #region Protected Constant/Read-Only Fields

        /// <summary>
        /// Name Attribute Tag.
        /// </summary>
        protected const string NameAttrTag = "name";

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="Property"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        protected Property(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            Name = name;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Add the <see cref="Property"/> as an <see cref="XmlElement"/> to the parent node.
        /// </summary>
        /// <returns>true if added; false otherwise.</returns>
        public abstract bool AddXml(XmlElement parent);

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public abstract override string ToString();

        #endregion

        #endregion
    }
}