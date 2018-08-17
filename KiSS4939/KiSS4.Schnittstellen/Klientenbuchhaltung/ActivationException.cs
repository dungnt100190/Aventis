using System;

namespace KiSS4.Schnittstellen.Klientenbuchhaltung
{
    public class ActivationException : Exception
    {
        #region Constructors

        public ActivationException(Exception innerException) : base("Activation failed.", innerException)
        {
            if (innerException == null) throw new ArgumentNullException("innerException");
        }

        #endregion
    }
}