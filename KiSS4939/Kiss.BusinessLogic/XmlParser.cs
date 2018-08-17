using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Kiss.BusinessLogic
{
    public abstract class XmlParser<T>
    {
        #region Methods

        #region Public Methods

        public IEnumerable<T> Parse(Stream xmlStream)
        {
            if (xmlStream == null)
            {
                throw new ArgumentException("xmlStream");
            }

            var reader = XmlReader.Create(xmlStream);
            var xmlDoc = XDocument.Load(reader);

            return OnParse(xmlDoc);
        }

        #endregion

        #region Internal Methods

        internal bool ElementValueEquals(XElement element1, XElement element2)
        {
            return element1 != null && element2 != null && element1.Value == element2.Value;
        }

        internal DateTime? TryGetDateTime(XElement parentEl, string elementName, DateTime? defaultValue = null)
        {
            var val = TryGetString(parentEl, elementName);
            return val != null ? Convert.ToDateTime(val) : defaultValue;
        }

        internal int? TryGetInt(XElement parentEl, string elementName, int? defaultValue = null)
        {
            var val = TryGetString(parentEl, elementName);
            return val != null ? Convert.ToInt32(val) : defaultValue;
        }

        internal string TryGetString(XElement parentEl, string elementName, string defaultValue = null)
        {
            if (parentEl == null)
            {
                return defaultValue;
            }

            var foundEl = parentEl.Element(elementName);
            return foundEl != null ? foundEl.Value : defaultValue;
        }

        #endregion

        #region Protected Methods

        protected abstract IEnumerable<T> OnParse(XDocument document);

        #endregion

        #endregion
    }
}