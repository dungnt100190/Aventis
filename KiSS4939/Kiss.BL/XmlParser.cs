using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Kiss.BL
{
    public abstract class XmlParser<T>
    {
        #region Fields

        #region Protected Constant/Read-Only Fields

        protected readonly Stream _xmlStream;

        #endregion

        #endregion

        #region Constructors

        protected XmlParser(Stream xmlStream)
        {
            _xmlStream = xmlStream;
            EntityList = new List<T>();
        }

        #endregion

        #region Properties

        public List<T> EntityList
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Parse()
        {
            if (_xmlStream == null)
            {
                return;
            }

            var reader = XmlReader.Create(_xmlStream);
            var xmlDoc = XDocument.Load(reader);

            OnParse(xmlDoc);
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

        protected abstract void OnParse(XDocument document);

        #endregion

        #endregion
    }
}