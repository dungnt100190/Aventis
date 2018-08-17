using System;
using System.Xml;

namespace KiSS4.Gui.Layout
{
    /// <summary>
    /// A <see cref="Property"/> consisting of other <see cref="Property"/> objects.
    /// </summary>
    public class ComplexProperty : Property
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Gets a <see cref="PropertyCollection"/> containing the inner <see cref="Property"/> objects of this <see cref="ComplexProperty"/>.
        /// </summary>
        public readonly PropertyCollection Properties = new PropertyCollection();

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplexProperty"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public ComplexProperty(string name)
            : base(name)
        {
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ele">The ele.</param>
        /// <returns></returns>
        public static ComplexProperty FromXml(XmlElement ele)
        {
            if (ele == null) throw new ArgumentNullException("ele");

            // name attribute
            string name = ele.Attributes[KissControlLayout.NameAttr, KissControlLayout.NameSpaceUri].Value;

            ComplexProperty ret = new ComplexProperty(name);

            // properties
            PropertyCollection.FromXml(ele, ret.Properties);

            return ret;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add the property as an <see cref="XmlElement"/> to the parent node. Recurse to inner properties.
        /// </summary>
        /// <returns>true if at least one inner property was added; false otherwise.</returns>
        public override bool AddXml(XmlElement parent)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }

            if (parent.OwnerDocument == null)
            {
                return false;
            }

            XmlElement ele = parent.OwnerDocument.CreateElement(KissControlLayout.Prefix, KissControlLayout.ComplexPropertyEle, KissControlLayout.NameSpaceUri);

            // name attribute
            XmlAttribute nameAttr = parent.OwnerDocument.CreateAttribute(KissControlLayout.Prefix, KissControlLayout.NameAttr, KissControlLayout.NameSpaceUri);
            nameAttr.Value = Name;
            ele.Attributes.Append(nameAttr);

            // properties
            bool ret = Properties.AddXml(ele);

            if (ret)
            {
                parent.AppendChild(ele);
            }

            return ret;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Property [\"{0}\"]", Name);
        }

        #endregion

        #endregion
    }
}