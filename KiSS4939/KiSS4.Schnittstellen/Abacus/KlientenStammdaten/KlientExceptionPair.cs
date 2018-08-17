using System;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public class KlientExceptionPair
    {
        #region Fields

        private Exception exceptionOfExport;
        private Klient klientWithExportError;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of KlientExportPair
        /// </summary>
        /// <param name="klientWithError">The <see cref="Klient"/> where an exception occured</param>
        /// <param name="ex">The exception that occured while exporting this <see cref="Klient"/></param>
        public KlientExceptionPair(Klient klientWithError, Exception ex)
        {
            this.klientWithExportError = klientWithError;
            this.exceptionOfExport = ex;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// The exception that occured while exporting this <see cref="Klient"/>
        /// </summary>
        public Exception ExceptionOfExport
        {
            get { return exceptionOfExport; }
        }

        /// <summary>
        /// The <see cref="Klient"/> where an exception occured
        /// </summary>
        public Klient KlientWithExportError
        {
            get { return klientWithExportError; }
        }

        #endregion
    }
}