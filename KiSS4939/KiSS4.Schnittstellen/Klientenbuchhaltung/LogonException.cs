using System;

namespace KiSS4.Schnittstellen.Klientenbuchhaltung
{
    public class LogonException : Exception
    {
        #region Constructors

        public LogonException(Exception innerException)
            : base(innerException.Message, innerException)
        {
            if (innerException == null) throw new ArgumentNullException("innerException");
        }

        #endregion
    }
}