using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    /// <summary>
    /// Exception, welche im Zusammenhang mit einem Webserviceaufruf
    /// entstehen kann.
    /// 
    /// </summary>
    public class MitarbeiterServiceAdapterException : Exception
    {
        #region Constructors

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">Fehlermeldung</param>
        public MitarbeiterServiceAdapterException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="innerException">Innere Excepiton</param>
        public MitarbeiterServiceAdapterException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }

        #endregion
    }
}