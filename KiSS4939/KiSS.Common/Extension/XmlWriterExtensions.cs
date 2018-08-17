using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace KiSS.Common.IO
{
    /// <summary>
    /// Extension methodes for the <see cref="XmlWriter"/> class
    /// </summary>
    public static class XmlWriterExtensions
    {
        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Writes an element with a DateTime value into the <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="writer"><see cref="XmlWriter"/> to extend</param>
        /// <param name="name">Name of the element</param>
        /// <param name="value">DateTime value of the element</param>
        public static void WriteElement(this XmlWriter writer, string name, DateTime value)
        {
            writer.WriteElement(name, value, "");
        }

        /// <summary>
        /// Writes an element with a DateTime value into the <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="writer"><see cref="XmlWriter"/> to extend</param>
        /// <param name="name">Name of the element</param>
        /// <param name="value">DateTime value of the element</param>
        /// <param name="format">The format to write the DateTime value</param>
        public static void WriteElement(this XmlWriter writer, string name, DateTime value, string format)
        {
            writer.WriteElementString(name, value.ToString(format));
        }

        /// <summary>
        /// Writes an element with a decimal value into the <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="writer"><see cref="XmlWriter"/> to extend</param>
        /// <param name="name">Name of the element</param>
        /// <param name="value">Decimal value of the element</param>
        public static void WriteElement(this XmlWriter writer, string name, decimal value)
        {
            writer.WriteElement(name, value, "");
        }

        /// <summary>
        /// Writes an element with a decimal value into the <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="writer"><see cref="XmlWriter"/> to extend</param>
        /// <param name="name">Name of the element</param>
        /// <param name="value">Decimal value of the element</param>
        /// <param name="format">The format to write the decimal value</param>
        public static void WriteElement(this XmlWriter writer, string name, decimal value, string format)
        {
            writer.WriteElementString(name, value.ToString(format));
        }

        /// <summary>
        /// Writes an element with an int value into the <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="writer"><see cref="XmlWriter"/> to extend</param>
        /// <param name="name">Name of the element</param>
        /// <param name="value">Int value of the element</param>
        public static void WriteElement(this XmlWriter writer, string name, int value)
        {
            writer.WriteElementString(name, value.ToString());
        }

        /// <summary>
        /// Writes an element with an int value into the <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="writer"><see cref="XmlWriter"/> to extend</param>
        /// <param name="name">Name of the element</param>
        /// <param name="value">Nullable Int value of the element</param>
        public static void WriteElement(this XmlWriter writer, string name, int? value)
        {
            writer.WriteElementString(name, value.ToString());
        }

        /// <summary>
        /// Writes an element with a string value into the <see cref="XmlWriter"/>
        /// </summary>
        /// <param name="writer"><see cref="XmlWriter"/> to extend</param>
        /// <param name="name">Name of the element</param>
        /// <param name="value">string value of the element</param>
        public static void WriteElement(this XmlWriter writer, string name, string value)
        {
            writer.WriteElementString(name, value);
        }

        #endregion

        #endregion
    }
}