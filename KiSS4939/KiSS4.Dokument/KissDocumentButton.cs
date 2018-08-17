using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Kiss.Infrastructure;
using Kiss.Infrastructure.IO;
using Kiss.Interfaces.DocumentHandling;
using Kiss.Interfaces.UI;

using KiSS4.DB;
using KiSS4.Dokument.ExcelAutomation;
using KiSS4.Dokument.WordAutomation;
using KiSS4.Gui;
using KiSS4.Messages;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Create documents in word format.
    /// </summary>
    [ToolboxBitmap(typeof(XDokument), "Images.OfficeDoc.bmp")]
    public class KissDocumentButton : KissButton
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Fields

        private int _dlgDocumentID;
        private DokFormat _dlgDokFormat;
        private bool _dlgShowBookmarkErrors;
        private DlgNewDocument.DocumentAccessModes _documentAccessMode = DlgNewDocument.DocumentAccessModes.All;
        private BmExcelDocument _excelDoc;
        private WordDoc _wordDoc;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KissDocumentButton"/> class.
        /// </summary>
        public KissDocumentButton()
        {
            InitializeComponent();

            UpdateIcon();

            ImageAlign = ContentAlignment.MiddleRight;
            TextAlign = ContentAlignment.MiddleLeft;
        }

        #endregion

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.SuspendLayout();
            //
            // KissDocumentButton
            //
            this.Click += new System.EventHandler(this.btn_Click);
            this.ParentChanged += new EventHandler(KissDocumentButton_ParentChanged);
            this.ResumeLayout(false);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        [Browsable(true),
        DefaultValue(""),
        TypeConverter(typeof(Designer.DocumentContextConverter))]
        public string Context
        {
            get;
            set;
        }

        /// <summary>
        /// The document access mode to use for icon and template-document-filter.
        /// </summary>
        [Bindable(true)]
        [DefaultValue("KiSS4.Dokument.DlgNewDocument.DocumentAccessModes.All")]
        [Description("The document access mode to use for icon and template-document-filter.")]
        public DlgNewDocument.DocumentAccessModes DocumentFormat
        {
            get { return _documentAccessMode; }
            set
            {
                // apply value
                _documentAccessMode = value;

                // refresh control
                UpdateIcon();
            }
        }

        #endregion

        #region EventHandlers

        /// <summary>
        /// Handles the Click event of the btn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btn_Click(object sender, EventArgs e)
        {
            _logger.Debug("btn_Click()");

            // --- allfällige ungesicherte Daten noch sichern
            var frm = FindForm() as KissForm;
            if (frm != null && !frm.OnSaveData())
            {
                return;
            }

            if (frm == null)
            {
                // in KiSS 5 haben wir keine Form, deshalb wird hier der oberste DataNavigator geholt
                var dataNavigator = GetTopmostDataNavigator(this);
                if (dataNavigator != null && !dataNavigator.SaveData())
                {
                    return;
                }
            }

            // open dialog to select desired template document (including filter defined by control)
            DlgNewDocument dlg = new DlgNewDocument(_documentAccessMode);

            if (!dlg.NewDocument(this, Context))
            {
                _logger.Debug("User cancelled document creation.");
                return;
            }

            _dlgDocumentID = Convert.ToInt32(dlg["DocTemplateID"]);
            _dlgDokFormat = (DokFormat)dlg["DocFormatCode"];

            _dlgShowBookmarkErrors = dlg.ShowBookmarkErrors;
            dlg.Dispose();

            ApplicationFacade.DoEvents();
            Cursor.Current = Cursors.WaitCursor;

            if (_dlgDokFormat.Equals(DokFormat.Word))
            {
                DlgProgressLog.Show(
                    KissMsg.GetMLMessage(
                        "KissDocumentButton",
                        "NeuesDokErstellen",
                        "Fortschritt: Neues Word-Dokument erstellen"),
                    500, 300,
                    WordProgressStart,
                    WordProgressClose,
                    Session.MainForm);
            }
            else if (_dlgDokFormat.Equals(DokFormat.Excel))
            {
                DlgProgressLog.Show(
                       KissMsg.GetMLMessage(
                           "KissDocumentButton",
                           "NeuesExcelErstellen",
                           "Fortschritt: Neues Excel-Dokument erstellen"),
                       500, 300,
                       ExcelProgressStart,
                       ExcelProgressClose,
                       Session.MainForm);
            }
        }

        private void KissDocumentButton_ParentChanged(object sender, EventArgs e)
        {
            // refresh display of image
            UpdateIcon();
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Indicates whether embedded images should be serialized.
        /// </summary>
        /// <returns></returns>
        public Boolean ShouldSerializeImage()
        {
            return false;
        }

        #endregion

        #region Private Methods

        private static IKissDataNavigator GetTopmostDataNavigator(Control control)
        {
            IKissDataNavigator dataNavigator = null;

            while (control != null)
            {
                var controlAsNavigator = control as IKissDataNavigator;
                if (controlAsNavigator != null)
                {
                    dataNavigator = controlAsNavigator;
                }
                control = control.Parent;
            }
            return dataNavigator;
        }

        /// <summary>
        /// Closes the document.
        /// </summary>
        private void CloseExcelDocument()
        {
            if (_excelDoc != null)
            {
                _excelDoc.CloseDocument();
            }
        }

        /// <summary>
        /// Closes the document.
        /// </summary>
        private void CloseWordDocument()
        {
            if (_wordDoc != null)
            {
                _wordDoc.CloseDocument();
            }
        }

        private void ExcelProgressClose()
        {
            DlgProgressLog.AddLine(KissMsg.GetMLMessage("KissDocumentButton", "ExcelProgressClose_v01", "Excel-Vorlage schliessen"));
        }

        private void ExcelProgressStart()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DlgProgressLog.ShowTopMost();

                DlgProgressLog.AddLine(KissMsg.GetMLMessage("KissDocumentButton", "ExcelProgressStart_v01",
                    "Excel-Vorlage laden"));

                // create handler
                // get file info based on dlgDocumentID
                XDocFileHandler template = XDocFileHandler.CreateFileHandler(DokTyp.Dokument, _dlgDocumentID, ".xls", true);
                template.DBToFile(false, false, false);
                template.FileInfo.Attributes &= ~FileAttributes.ReadOnly;

                // --- Create new Excel doc, get bookmarks filled according to given context
                DlgProgressLog.AddLine(KissMsg.GetMLMessage("KissDocumentButton", "ExcelDokumentErzeugen",
                    "Excel-Dokument erzeugen"));

                // --- Create new Excel doc, get bookmarks filled according to given context
                DlgProgressLog.AddLine(KissMsg.GetMLMessage("KissDocumentButton", "OpenFileName",
                    "Datei: {0}", KissMsgCode.Text, template.FileInfo));

                _excelDoc = new BmExcelDocument(template.FileInfo);
                _excelDoc.FillBookmarks(KissForm.GetParent_IKissContext(this));

                // in order to delete the file after watching / printing
                template.WatchFile(false, true);

                // save template
                DlgProgressLog.AddLine(KissMsg.GetMLMessage("KissDocumentButton", "VorlageSpeichern",
                    "Ausgefüllte Vorlage speichern"));
                _excelDoc.Save();

                // check success
                if (!_dlgShowBookmarkErrors || !DlgProgressLog.HasErrors)
                {
                    // --- Close Progress dialog and display the new doc
                    DlgProgressLog.CloseDialog();
                    // excelDoc.MakeWordVisible();
                }
                else
                {
                    // --- Keep Progress dialog open and display the new doc after the user quits the dialog
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage("KissDocumentButton", "ExcelErledigtMitFehler",
                        "Erledigt (Es sind Fehler aufgetreten)"));
                    DlgProgressLog.EndProgress();
                    DlgProgressLog.ShowTopMost();
                }
            }
            catch (CancelledByUserException ex)
            {
                _logger.Warn(ex);

                CloseExcelDocument();

                DlgProgressLog.CloseDialog();
            }
            catch (ZipException ex)
            {
                _logger.Warn(ex);
                CloseExcelDocument();
                DlgProgressLog.CloseDialog();
                KissMsg.ShowInfo(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);

                CloseExcelDocument();

                DlgProgressLog.CloseDialog();
                KissMsg.ShowError("KissDocumentButton", "ExcelFehlerDokumentErzeugen",
                    "Fehler beim Erzeugen des neuen Excel-Dokuments\r\n\r\n",
                    ex.Message,
                    ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Update the icon after changing <see cref="DocumentFormat"/>.
        /// </summary>
        private void UpdateIcon()
        {
            // init bitmap
            Bitmap bmp;

            // depending on current access mode, we set another bitmap
            switch (_documentAccessMode)
            {
                case DlgNewDocument.DocumentAccessModes.All:
                    bmp = XDokument.BmpOfficeDoc;
                    break;

                case DlgNewDocument.DocumentAccessModes.Word:
                    bmp = XDokument.BmpWordDoc;
                    break;

                case DlgNewDocument.DocumentAccessModes.Excel:
                    bmp = XDokument.BmpExcelDoc;
                    break;

                default:
                    throw new NotImplementedException("The applied document access mode is not implemented yet and therefore cannot be used.");
            }

            // make color transparent
            bmp.MakeTransparent(Color.Magenta);

            // apply bitmap to image property
            Image = bmp;
        }

        /// <summary>
        /// Close the process.
        /// </summary>
        private void WordProgressClose()
        {
            if (_wordDoc != null)
            {
                _wordDoc.MakeWordVisible();
            }
        }

        /// <summary>
        /// Start.
        /// </summary>
        private void WordProgressStart()
        {
            _logger.Debug("Start Document Creation.");

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DlgProgressLog.ShowTopMost();

                // --- Save Template (.dot) as Document (.doc) to local drive
                DlgProgressLog.AddLine(KissMsg.GetMLMessage("KissDocumentButton", "VorlageLaden", "Word-Vorlage laden"));

                // create handler
                XDocFileHandler template = XDocFileHandler.CreateFileHandler(DokTyp.Dokument, _dlgDocumentID, ".doc", true);
                template.DBToFile(false, false, false);
                template.FileInfo.Attributes &= ~FileAttributes.ReadOnly;

                // --- Create new Word doc, get bookmarks filled according to given context
                DlgProgressLog.AddLine(
                    KissMsg.GetMLMessage(
                        "KissDocumentButton",
                        "DokumentErzeugen",
                        "Word-Dokument erzeugen"));

                _wordDoc = new WordDoc(template.FileInfo, KissForm.GetParent_IKissContext(this));

                // in order to delete the file after watching / printing
                template.WatchFile(false, true);

                if (!_dlgShowBookmarkErrors || !DlgProgressLog.HasErrors)
                {
                    // --- Close Progress dialog and display the new doc
                    DlgProgressLog.CloseDialog();
                    _wordDoc.MakeWordVisible();
                }
                else
                {
                    // --- Keep Progress dialog open and display the new doc after the user quits the dialog
                    DlgProgressLog.AddLine(KissMsg.GetMLMessage("KissDocumentButton", "ErledigtMitFehler", "Erledigt (Es sind Fehler aufgetreten)"));
                    DlgProgressLog.EndProgress();
                    DlgProgressLog.ShowTopMost();
                }
            }
            catch (CancelledByUserException ex)
            {
                _logger.Warn(ex);

                CloseWordDocument();

                DlgProgressLog.CloseDialog();
            }
            catch (ZipException ex)
            {
                _logger.Warn(ex);
                CloseWordDocument();
                DlgProgressLog.CloseDialog();
                KissMsg.ShowInfo(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.Warn(ex);

                CloseWordDocument();

                DlgProgressLog.CloseDialog();
                KissMsg.ShowError(
                    "KissDocumentButton",
                    "FehlerDokumentErzeugen",
                    "Fehler beim Erzeugen des neuen Word-Dokuments\r\n\r\n",
                    ex.Message,
                    ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        #endregion

        #endregion
    }
}