using System;
using System.Windows.Forms;
using System.Xml;

namespace KiSS4.Gui.Layout
{
    /// <summary>
    /// Contains <see cref="Property"/> and other <see cref="KissControlLayout"/> objects.
    /// </summary>
    public class KissControlLayout
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Complex Property Element.
        /// </summary>
        public const string ComplexPropertyEle = "ComplexProperty";

        /// <summary>
        /// Control Layout Element.
        /// </summary>
        public const string ControlLayoutEle = "Control";

        /// <summary>
        /// Name Attribute.
        /// </summary>
        public const string NameAttr = "name";

        /// <summary>
        /// The namespace URI.
        /// </summary>
        public const string NameSpaceUri = "urn:diartis.ch/KiSS4:ControlLayout";

        /// <summary>
        /// The prefix.
        /// </summary>
        public const string Prefix = "cl";

        /// <summary>
        /// Simple Property Element.
        /// </summary>
        public const string SimplePropertyEle = "SimpleProperty";

        /// <summary>
        /// Type Code Attribute.
        /// </summary>
        public const string TypeCodeAttr = "typeCode";

        /// <summary>
        /// Value Attribute.
        /// </summary>
        public const string ValueAttr = "value";

        /// <summary>
        /// Gets a <see cref="ControlLayoutCollection"/> containing the <see cref="KissControlLayout"/> objects for this <see cref="KissControlLayout"/>.
        /// </summary>
        public readonly ControlLayoutCollection ControlLayouts = new ControlLayoutCollection();

        /// <summary>
        /// Gets the name of the <see cref="KissControlLayout"/>.
        /// </summary>
        public readonly string Name;

        /// <summary>
        /// Gets a <see cref="PropertyCollection"/> containing the properties of the <see cref="KissControlLayout"/>.
        /// </summary>
        public readonly PropertyCollection Properties = new PropertyCollection();

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissControlLayout"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public KissControlLayout(string name)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            Name = name;
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Get the KissControlLayout for the given XMLElement.
        /// </summary>
        /// <param name="ele">The ele.</param>
        /// <returns></returns>
        public static KissControlLayout FromXml(XmlElement ele)
        {
            // name attribute
            var attribute = ele.Attributes[NameAttr, NameSpaceUri];

            if (attribute == null)
            {
                return null;
            }

            string name = attribute.Value;

            KissControlLayout ret = new KissControlLayout(name);

            // properties
            PropertyCollection.FromXml(ele, ret.Properties);

            // control layouts
            ControlLayoutCollection.FromXml(ele, ret.ControlLayouts);

            return ret;
        }

        /// <summary>
        /// Reads the simple property.
        /// </summary>
        /// <param name="e">The <see cref="KiSS4.Gui.Layout.KissLayoutEventArgs"/> instance containing the event data.</param>
        /// <param name="ctl">The Control</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static SimpleProperty ReadSimpleProperty(KissLayoutEventArgs e, Control ctl, string propertyName)
        {
            return ReadSimpleProperty(e, ctl.Name, ctl, propertyName);
        }

        /// <summary>
        /// Reads the simple property.
        /// </summary>
        /// <param name="e">The <see cref="KiSS4.Gui.Layout.KissLayoutEventArgs"/> instance containing the event data.</param>
        /// <param name="name">The Name of the Object</param>
        /// <param name="obj">The Object</param>
        /// <param name="propertyName">Name of the Property.</param>
        /// <returns></returns>
        public static SimpleProperty ReadSimpleProperty(KissLayoutEventArgs e, string name, object obj, string propertyName)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName");
            }

            KissControlLayout ctlLayout;

            try
            {
                ctlLayout = e.Layout.ControlLayouts[name];
            }
            catch
            {
                return null;
            }

            SimpleProperty property = (SimpleProperty)ctlLayout.Properties[propertyName];

            try
            {
                property.LoadValue(obj);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(obj as Control, property, ex));
            }

            return property;
        }

        /// <summary>
        /// Saves the simple property.
        /// </summary>
        /// <param name="e">The <see cref="KiSS4.Gui.Layout.KissLayoutEventArgs"/> instance containing the event data.</param>
        /// <param name="ctl">The Control</param>
        /// <param name="propertyName">Name of the Property.</param>
        /// <returns></returns>
        public static KissControlLayout SaveSimpleProperty(KissLayoutEventArgs e, Control ctl, string propertyName)
        {
            return SaveSimpleProperty(e, ctl.Name, ctl, propertyName);
        }

        /// <summary>
        /// Saves the simple property.
        /// </summary>
        /// <param name="e">The <see cref="KiSS4.Gui.Layout.KissLayoutEventArgs"/> instance containing the event data.</param>
        /// <param name="name">The Name of the Object</param>
        /// <param name="obj">The Object</param>
        /// <param name="propertyName">Name of the Property.</param>
        /// <returns></returns>
        public static KissControlLayout SaveSimpleProperty(KissLayoutEventArgs e, string name, object obj, string propertyName)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }
            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName");
            }

            KissControlLayout ctlLayout;

            if (e.Layout.ControlLayouts.ContainsKey(name))
            {
                ctlLayout = e.Layout.ControlLayouts[name];
            }
            else
            {
                ctlLayout = new KissControlLayout(name);
            }

            SimpleProperty property = new SimpleProperty(propertyName);

            try
            {
                property.SaveValue(obj);
                ctlLayout.Properties.Add(property);
            }
            catch (Exception ex)
            {
                e.Errors.Add(new LayoutError(obj as Control, property, ex));
            }

            e.Layout.ControlLayouts.Add(ctlLayout);
            return ctlLayout;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Add the <see cref="KissControlLayout"/> as an <see cref="XmlElement"/> to the parent node.
        /// </summary>
        /// <returns>true if at least one property was added; false otherwise.</returns>
        public bool AddXml(XmlNode parent)
        {
            XmlDocument doc;

            if (parent is XmlDocument)
            {
                doc = (XmlDocument)parent;
            }
            else
            {
                doc = parent.OwnerDocument;
            }

            if (doc == null)
            {
                return false;
            }

            XmlElement ele = doc.CreateElement(Prefix, ControlLayoutEle, NameSpaceUri);

            // name attribute
            XmlAttribute nameAttr = doc.CreateAttribute(Prefix, NameAttr, NameSpaceUri);
            nameAttr.Value = Name;
            ele.Attributes.Append(nameAttr);

            bool ret = false;

            // Properties
            ret |= Properties.AddXml(ele);

            // Controls
            ret |= ControlLayouts.AddXml(ele);

            if (ret)
            {
                parent.AppendChild(ele);
            }

            return ret;
        }

        /// <summary>
        /// Create an <see cref="XmlDocument"/> from this <see cref="KissControlLayout"/>.
        /// </summary>
        /// <returns>A valid <see cref="XmlDocument"/> or a null reference if no properties were added.</returns>
        public XmlDocument ToXml()
        {
            XmlDocument ret = new XmlDocument();

            // xml declaration
            ret.AppendChild(ret.CreateXmlDeclaration("1.0", "utf-8", null));

            // this
            if (!AddXml(ret))
            {
                ret = null;
            }

            return ret;
        }

        #endregion

        #endregion
    }
}