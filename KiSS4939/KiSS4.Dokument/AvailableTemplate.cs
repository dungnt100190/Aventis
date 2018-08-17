using System;
using System.IO;

using Kiss.Interfaces.DocumentHandling;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Class for available templates
    /// </summary>
    public class AvailableTemplate
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        /// <summary>
        /// Store the fileending of the template
        /// </summary>
        private readonly String _docTemplateFileExtension = String.Empty;

        /// <summary>
        /// Store the name of the template
        /// </summary>
        private readonly String _docTemplateName = String.Empty;

        /// <summary>
        /// Store the path to the template
        /// </summary>
        private readonly String _docTemplatePath = String.Empty;

        #endregion

        #region Private Fields

        /// <summary>
        /// Store the compressed data of the file (this will be set out of this class here)
        /// </summary>
        private Byte[] _compressedData;

        /// <summary>
        /// Store the format of the template
        /// </summary>
        private DokFormat _docFormat = DokFormat.Unbekannt;

        /// <summary>
        /// Store the format of the template for databinding in grid
        /// </summary>
        private String _docFormatBinding = String.Empty;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor, used to create a new instance of <see cref="AvailableTemplate"/>
        /// </summary>
        /// <param name="docTemplateName">The name of the template</param>
        /// <param name="docTemplatePath">The path of the template</param>
        /// <param name="docTemplateFileEnding">The fileending of the template, also used to determine the doc-format (including the dot)</param>
        /// <param name="compressedData">The compressed data of the template</param>
        public AvailableTemplate(String docTemplateName, String docTemplatePath, String docTemplateFileEnding, Byte[] compressedData)
        {
            // apply fields without validating
            _docTemplateName = docTemplateName;
            _docTemplatePath = docTemplatePath;
            _docTemplateFileExtension = docTemplateFileEnding;
            _compressedData = compressedData;

            // set document type
            SetTemplateDocFormat(_docTemplateFileExtension);
        }

        /// <summary>
        /// Constructor, used to create a new instance of <see cref="AvailableTemplate"/>
        /// </summary>
        /// <param name="fileInfo">The file information of the assembly to read information from</param>
        public AvailableTemplate(FileInfo fileInfo)
        {
            // validate
            if (fileInfo == null || String.IsNullOrEmpty(fileInfo.FullName))
            {
                // error, do not continue
                throw new ArgumentNullException("fileInfo", "Invalid file information, cannot load template data.");
            }

            // apply fields
            _docTemplateName = fileInfo.Name;
            _docTemplatePath = fileInfo.FullName;
            _docTemplateFileExtension = fileInfo.Extension;
            _compressedData = null;                 // leave empty

            // set document type
            SetTemplateDocFormat(_docTemplateFileExtension);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get the compressed data of the file
        /// </summary>
        public Byte[] CompressedData
        {
            get { return _compressedData; }
        }

        /// <summary>
        /// Get the document format
        /// </summary>
        public DokFormat DocFormat
        {
            get { return _docFormat; }
        }

        /// <summary>
        /// Get the document format for databinding
        /// </summary>
        public String DocFormatBinding
        {
            get { return _docFormatBinding; }
        }

        /// <summary>
        /// Get the fileending of the document including the dot (e.g. ".xlt" or ".dot")
        /// </summary>
        public String DocTemplateFileExtension
        {
            get { return _docTemplateFileExtension; }
        }

        /// <summary>
        /// Get the name of the file
        /// </summary>
        public String DocTemplateName
        {
            get { return _docTemplateName; }
        }

        /// <summary>
        /// Get the path of the template
        /// </summary>
        public String DocTemplatePath
        {
            get { return _docTemplatePath; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Load and apply compressed filebinary data from given file
        /// </summary>
        public void LoadAndApplyFileBinary()
        {
            // check if any file is given
            if (String.IsNullOrEmpty(DocTemplatePath))
            {
                throw new NullReferenceException("No filepath to the template-file given, cannot create file-binary.");
            }

            // get fileinfo
            new FileInfo(DocTemplatePath);

            // compress data and remove file again
            _compressedData = Zip.CompressData(DocTemplatePath);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Set the document format depending on given fileending
        /// </summary>
        /// <param name="fileEnding">The fileending of the template</param>
        private void SetTemplateDocFormat(String fileEnding)
        {
            // replace the "." if any given
            if (!String.IsNullOrEmpty(fileEnding))
            {
                // remove the "." to have same conditions in every case
                fileEnding = fileEnding.Replace(".", "");
            }

            // set the format depending on fileending
            switch (fileEnding)
            {
                case "doc":
                case "docx":
                case "docm":
                case "dot":
                case "dotx":
                case "dotm":
                    _docFormat = DokFormat.Word;
                    _docFormatBinding = "word";
                    break;

                case "xls":
                case "xlsx":
                case "xlsm":
                case "xlt":
                case "xltx":
                case "xltm":
                    _docFormat = DokFormat.Excel;
                    _docFormatBinding = "excel";
                    break;

                default:
                    _docFormat = DokFormat.Unbekannt;
                    _docFormatBinding = "other";
                    break;
            }
        }

        #endregion

        #endregion
    }
}