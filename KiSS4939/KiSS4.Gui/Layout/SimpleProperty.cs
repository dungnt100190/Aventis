using System;
using System.Xml;

namespace KiSS4.Gui.Layout
{
    /// <summary>
    /// A <see cref="Property"/> consisting of a name/value pair.
    /// </summary>
    public class SimpleProperty : Property
    {
        #region Fields

        #region Public Fields

        /// <summary>
        /// Gets the value of the <see cref="SimpleProperty"/>.
        /// </summary>
        public IConvertible Value;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleProperty"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public SimpleProperty(string name)
            : base(name)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleProperty"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public SimpleProperty(string name, IConvertible value)
            : base(name)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            Value = value;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Get the property for a given element. 
        /// </summary>
        /// <param name="ele">The element.</param>
        /// <returns></returns>
        public static SimpleProperty FromXml(XmlElement ele)
        {
            if (ele == null)
            {
                throw new ArgumentNullException("ele");
            }

            // name attribute
            string name = ele.Attributes[KissControlLayout.NameAttr, KissControlLayout.NameSpaceUri].Value;

            // value attribute
            string valueStr = ele.Attributes[KissControlLayout.ValueAttr, KissControlLayout.NameSpaceUri].Value;

            // typeCode attribute
            string typeCodeStr = ele.Attributes[KissControlLayout.TypeCodeAttr, KissControlLayout.NameSpaceUri].Value;
            TypeCode typeCode = (TypeCode)Enum.Parse(typeof(TypeCode), typeCodeStr);

            IConvertible value = (IConvertible)Convert.ChangeType(valueStr, typeCode);

            return new SimpleProperty(name, value);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add the <see cref="SimpleProperty"/> as an <see cref="XmlElement"/> to the parent node.
        /// </summary>
        /// <returns>true.</returns>
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

            XmlElement ele = parent.OwnerDocument.CreateElement(KissControlLayout.Prefix, KissControlLayout.SimplePropertyEle, KissControlLayout.NameSpaceUri);

            // name attribute
            XmlAttribute nameAttr = parent.OwnerDocument.CreateAttribute(KissControlLayout.Prefix, KissControlLayout.NameAttr, KissControlLayout.NameSpaceUri);
            nameAttr.Value = Name;
            ele.Attributes.Append(nameAttr);

            // value attribute
            XmlAttribute valueAttr = parent.OwnerDocument.CreateAttribute(KissControlLayout.Prefix, KissControlLayout.ValueAttr, KissControlLayout.NameSpaceUri);
            valueAttr.Value = Convert.ToString(Value);
            ele.Attributes.Append(valueAttr);

            // typeCode attribute
            XmlAttribute typeAttr = parent.OwnerDocument.CreateAttribute(KissControlLayout.Prefix, KissControlLayout.TypeCodeAttr, KissControlLayout.NameSpaceUri);
            typeAttr.Value = Value.GetTypeCode().ToString();
            ele.Attributes.Append(typeAttr);

            parent.AppendChild(ele);
            return true;
        }

        /// <summary>
        /// Set Value to the Property of obj
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void LoadValue(object obj)
        {
            AssemblyLoader.SetPropertyValue(obj, Name, Value);
        }

        /// <summary>
        /// Get the Property-Value of obj and save to Value
        /// </summary>
        /// <param name="obj">The obj.</param>
        public void SaveValue(object obj)
        {
            Value = (IConvertible)AssemblyLoader.GetPropertyValue(obj, Name);
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Property [\"{0}\", {1}]", Name, Value);
        }

        #endregion

        #endregion
    }
}