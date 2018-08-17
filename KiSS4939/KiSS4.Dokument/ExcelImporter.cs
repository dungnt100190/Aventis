using System;

using log4net;

using Kiss.Interfaces.DocumentHandling;

namespace KiSS4.Dokument
{
    public abstract class ExcelImporter : IDisposable
    {
        #region Fields

        #region Protected Constant/Read-Only Fields

        protected readonly ILog _log;

        #endregion

        #region Protected Fields

        protected IExcelDocument _excelDocument;

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly string _fileName;

        #endregion

        #endregion

        #region Constructors

        protected ExcelImporter(string fileName)
        {
            _log = LogManager.GetLogger(typeof(ExcelImporter));

            _fileName = fileName;
        }

        #endregion

        #region Destructor

        ~ExcelImporter()
        {
            Dispose(false);
        }

        #endregion

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing && _excelDocument != null)
            {
                _excelDocument.Dispose();
                _excelDocument = null;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool Load()
        {
            try
            {
                _excelDocument = new ExcelDocument(_fileName);

                return ProcessDocument();
            }
            catch (Exception ex)
            {
                _log.Error(ex);
                throw;
            }
        }

        #endregion

        #region Protected Methods

        protected abstract bool ProcessDocument();

        #endregion

        #endregion
    }
}