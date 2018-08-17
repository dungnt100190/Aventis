using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using Kiss.Infrastructure;
using Kiss.Interfaces.DocumentHandling;
using Kiss.Interfaces.UI;
using KiSS4.DB;
using KiSS4.Dokument.ExcelAutomation;
using KiSS4.Gui;

namespace KiSS4.Dokument
{
    /// <summary>
    /// Summary description for XDokument.
    /// </summary>
    public class XDokument : KissButtonEdit, IKissBindableEdit, INotifyPropertyChanged
    {
        #region Fields

        #region Private Static Fields

        /// <summary>
        /// The Log4Net logger.
        /// </summary>
        private static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly EditorButton _btnDeleteDoc;
        private readonly EditorButton _btnImportDoc;
        private readonly EditorButton _btnNewDoc;
        private readonly EditorButton _btnOpenDoc;
        private readonly XDokumentLogik _dokumentLogik = new XDokumentLogik();

        #endregion

        #region Private Fields

        private bool _allowEdit = true;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XDokument"/> class.
        /// </summary>
        public XDokument()
        {
            _logger.Debug("XDokument()");

            _btnNewDoc = new EditorButton();
            _btnOpenDoc = new EditorButton();
            _btnImportDoc = new EditorButton();
            _btnDeleteDoc = new EditorButton();

            _dokumentLogik.DokFormatCodeChanged += _dokumentLogik_DokFormatCodeChanged;
            _dokumentLogik.EditModeChanged += _dokumentLogik_EditModeChanged;

            _dokumentLogik.DocumentCreated += _dokumentLogik_DocumentCreated;
            _dokumentLogik.DocumentCreating += _dokumentLogik_DocumentCreating;
            _dokumentLogik.DocumentDeleted += _dokumentLogik_DocumentDeleted;
            _dokumentLogik.DocumentDeleting += _dokumentLogik_DocumentDeleting;
            _dokumentLogik.DocumentIDChanged += _dokumentLogik_DocumentIDChanged;
            _dokumentLogik.DocumentImported += _dokumentLogik_DocumentImported;
            _dokumentLogik.DocumentImporting += _dokumentLogik_DocumentImporting;
            _dokumentLogik.DocumentOpening += _dokumentLogik_DocumentOpening;
            _dokumentLogik.DocumentSaved += _dokumentLogik_DocumentSaved;
            _dokumentLogik.RefreshGui += _dokumentLogik_RefreshGui;

            EditMode = EditModeType.Normal;
            DokFormatCode = DokFormat.Unbekannt;
            DokTypCode = DokTyp.Dokument;

            AllowDrop = true;
            DragOver += XDokument_DragOver;
            DragDrop += XDokument_DragDrop;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs when [document created].
        /// </summary>
        public event EventHandler DocumentCreated;

        /// <summary>
        /// Occurs when [document creating].
        /// </summary>
        public event CancelEventHandler DocumentCreating;

        /// <summary>
        /// Occurs when document was successfully deleted
        /// </summary>
        public event EventHandler DocumentDeleted;

        /// <summary>
        /// Occurs when [document deleting].
        /// </summary>
        public event CancelEventHandler DocumentDeleting;

        /// <summary>
        /// Occurs when [document ID changed].
        /// </summary>
        public event EventHandler DocumentIDChanged;

        /// <summary>
        /// Occurs when [document imported].
        /// </summary>
        public event EventHandler DocumentImported;

        /// <summary>
        /// Occurs when [document importing].
        /// </summary>
        public event CancelEventHandler DocumentImporting;

        /// <summary>
        /// Occurs when [document opening].
        /// </summary>
        public event CancelEventHandler DocumentOpening;

        /// <summary>
        /// Occurs when [document saved].
        /// </summary>
        public event EventHandler DocumentSaved;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        public static Bitmap BmpAcrobatDoc
        {
            get { return new Bitmap(typeof(XDokument), "Images.AcrobatDoc.bmp"); }
        }

        public static Bitmap BmpDeleteDoc
        {
            get { return new Bitmap(typeof(XDokument), "Images.DeleteDoc.bmp"); }
        }

        public static Bitmap BmpExcelDoc
        {
            get { return new Bitmap(typeof(XDokument), "Images.ExcelDoc.bmp"); }
        }

        public static Bitmap BmpImportDoc
        {
            get { return new Bitmap(typeof(XDokument), "Images.ImportDoc.bmp"); }
        }

        public static Bitmap BmpNewDoc
        {
            get { return new Bitmap(typeof(XDokument), "Images.NewDoc.bmp"); }
        }

        public static Bitmap BmpOfficeDoc
        {
            get { return new Bitmap(typeof(XDokument), "Images.OfficeDoc.bmp"); }
        }

        public static Bitmap BmpOpenDoc
        {
            get { return new Bitmap(typeof(XDokument), "Images.OpenDoc.bmp"); }
        }

        public static Bitmap BmpWordDoc
        {
            get { return new Bitmap(typeof(XDokument), "Images.WordDoc.bmp"); }
        }

        /// <summary>
        /// Allow Drag & Drop
        /// </summary>
        /// <remarks>Overriden property to annotate another DefaultValue.</remarks>
        [DefaultValue(true)]
        public override bool AllowDrop
        {
            get
            {
                return base.AllowDrop;
            }
            set
            {
                base.AllowDrop = value;
            }
        }

        /// <summary>
        /// Allow create new document
        /// </summary>
        [DefaultValue(true)]
        public bool CanCreateDocument
        {
            get { return _dokumentLogik.CanCreateDocument; }
            set
            {
                _dokumentLogik.CanCreateDocument = value;
                _dokumentLogik.RefreshDisplay();
            }
        }

        /// <summary>
        /// Allow delete document
        /// </summary>
        [DefaultValue(true)]
        public bool CanDeleteDocument
        {
            get { return _dokumentLogik.CanDeleteDocument; }
            set
            {
                _dokumentLogik.CanDeleteDocument = value;
                _dokumentLogik.RefreshDisplay();
            }
        }

        /// <summary>
        /// Allow import document
        /// </summary>
        [DefaultValue(true)]
        public bool CanImportDocument
        {
            get { return _dokumentLogik.CanImportDocument; }
            set
            {
                _dokumentLogik.CanImportDocument = value;
                _dokumentLogik.RefreshDisplay();
            }
        }

        /// <summary>
        /// The document can be updated.
        /// </summary>
        public bool CanUpdate
        {
            get
            {
                return _dokumentLogik.CanUpdate;
            }
        }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        /// <value>The context.</value>
        [Browsable(true)]
        [DefaultValue("")]
        [TypeConverter(typeof(Designer.DocumentContextConverter))]
        public string Context
        {
            get { return _dokumentLogik.Context; }
            set { _dokumentLogik.Context = value; }
        }

        [Browsable(true)]
        [DefaultValue("")]
        public override string DataMember
        {
            get { return base.DataMember; }
            set
            {
                base.DataMember = value;
                _dokumentLogik.DataMember = value;
                if (DesignMode)
                {
                    OnEditValueChanged();
                }
            }
        }

        [Browsable(true)]
        [DefaultValue(null)]
        public override SqlQuery DataSource
        {
            get { return base.DataSource; }
            set
            {
                base.DataSource = value;
                _dokumentLogik.DataSource = value;
            }
        }

        /// <summary>
        /// Gets the creation date of the document
        /// </summary>
        public object DateCreation
        {
            get
            {
                return _dokumentLogik.DateCreation;
            }
        }

        /// <summary>
        /// Gets the date of the last save
        /// </summary>
        public object DateLastSave
        {
            get
            {
                return _dokumentLogik.DateLastSave;
            }
        }

        /// <summary>
        /// Name of the template which was used to create the document
        /// </summary>
        /// <value>Name of the template</value>
        [Browsable(true)]
        [DefaultValue("")]
        public string DocTemplateName
        {
            get { return _dokumentLogik.DocTemplateName; }
        }

        /// <summary>
        /// Gets or sets the document ID.
        /// </summary>
        /// <value>The document ID.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object DocumentID
        {
            get
            {
                return _dokumentLogik.DocumentID;
            }
            set
            {
                _dokumentLogik.DocumentID = value;
            }
        }

        /// <summary>
        /// Gets or sets the dok format code.
        /// </summary>
        /// <value>The dok format code.</value>
        [Browsable(true)]
        [DefaultValue(DokFormat.Unbekannt)]
        public DokFormat DokFormatCode
        {
            get
            {
                return _dokumentLogik.DokFormatCode;
            }
            set
            {
                _dokumentLogik.DokFormatCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the document type code.
        /// </summary>
        /// <value>The dok typ code.</value>
        [Browsable(true)]
        [DefaultValue(DokTyp.Dokument)]
        public DokTyp DokTypCode
        {
            get { return _dokumentLogik.DokTypCode; }
            set
            {
                _dokumentLogik.DokTypCode = value;
            }
        }

        /// <summary>
        /// Gets or sets the edit mode.
        /// </summary>
        /// <value>The edit mode.</value>
        public override EditModeType EditMode
        {
            get
            {
                return base.EditMode;
            }
            set
            {
                base.EditMode = value;
                _dokumentLogik.EditMode = value;
            }
        }

        /// <summary>
        /// Missing datarow in XDocument to given ID in master row.
        /// </summary>
        /// <value><c>true</c> if the document could not be found on the database; otherwise, <c>false</c>.</value>
        public bool HasDBConflict
        {
            get
            {
                return _dokumentLogik.HasDBConflict;
            }
        }

        /// <summary>
        /// Gets a value indicating whether [in use].
        /// </summary>
        /// <value><c>true</c> if [in use]; otherwise, <c>false</c>.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool InUse
        {
            get { return _dokumentLogik.InUse; }
        }

        /// <summary>
        /// Get if document is locket by current user or other user at the moment
        /// </summary>
        public bool IsDocumentLocked
        {
            get
            {
                return _dokumentLogik.IsDocumentLocked;
            }
        }

        /// <summary>
        /// Returns true if a document is open.
        /// Warning: Check the correct functionality under your circumstances before you use this function.
        /// The design around documents is a bit odd in Kiss...
        /// </summary>
        public bool IsDocumentOpen
        {
            get
            {
                return _dokumentLogik.IsDocumentOpen;
            }
        }

        /// <summary>
        /// Sets the row.
        /// </summary>
        /// <value>The row.</value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataRow Row
        {
            set
            {
                _dokumentLogik.Row = value;
            }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets or sets the <see cref="System.Object"/> with the specified column name.
        /// </summary>
        /// <value></value>
        public object this[string columnName]
        {
            get
            {
                return _dokumentLogik[columnName];
            }
            set
            {
                _dokumentLogik[columnName] = value;
            }
        }

        #endregion

        #region EventHandlers

        private void _dokumentLogik_DocumentCreated(object sender, EventArgs e)
        {
            OnDocumentCreated();
        }

        private void _dokumentLogik_DocumentCreating(object sender, CancelEventArgs e)
        {
            bool cancel = e.Cancel;
            OnDocumentCreating(ref cancel);
            e.Cancel = cancel;
        }

        private void _dokumentLogik_DocumentDeleted(object sender, EventArgs e)
        {
            OnDocumentDeleted();
        }

        private void _dokumentLogik_DocumentDeleting(object sender, CancelEventArgs e)
        {
            bool cancel = e.Cancel;
            OnDocumentDeleting(ref cancel);
            e.Cancel = cancel;
        }

        private void _dokumentLogik_DocumentIDChanged(object sender, EventArgs e)
        {
            OnDocumentIDChanged();
        }

        private void _dokumentLogik_DocumentImported(object sender, EventArgs e)
        {
            OnDocumentImported();
        }

        private void _dokumentLogik_DocumentImporting(object sender, CancelEventArgs e)
        {
            bool cancel = e.Cancel;
            OnDocumentImporting(ref cancel);
            e.Cancel = cancel;
        }

        private void _dokumentLogik_DocumentOpening(object sender, CancelEventArgs e)
        {
            bool cancel = e.Cancel;
            OnDocumentOpening(ref cancel);
            e.Cancel = cancel;
        }

        private void _dokumentLogik_DocumentSaved(object sender, EventArgs e)
        {
            OnDocumentSaved();
        }

        private void _dokumentLogik_DokFormatCodeChanged(object sender, EventArgs e)
        {
            switch (DokFormatCode)
            {
                case DokFormat.Unbekannt:
                    _btnOpenDoc.Image = BmpOpenDoc;
                    break;

                case DokFormat.Word:
                    _btnOpenDoc.Image = BmpWordDoc;
                    break;

                case DokFormat.Excel:
                    _btnOpenDoc.Image = BmpExcelDoc;
                    break;

                case DokFormat.PDF:
                    _btnOpenDoc.Image = BmpAcrobatDoc;
                    break;
            }
        }

        private void _dokumentLogik_EditModeChanged(object sender, EventArgs e)
        {
            base.EditMode = _dokumentLogik.EditMode;

            ApplyButtons();
        }

        /// <summary>
        /// Refreshes the display.
        /// </summary>
        private void _dokumentLogik_RefreshGui(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<object, EventArgs>(_dokumentLogik_RefreshGui), sender, e);
                return;
            }

            // setting visible states of buttons
            if (_btnNewDoc != null)
                _btnNewDoc.Visible = _dokumentLogik.ButtonNewVisible;
            if (_btnImportDoc != null)
                _btnImportDoc.Visible = _dokumentLogik.ButtonImportVisible;
            if (_btnOpenDoc != null)
                _btnOpenDoc.Visible = _dokumentLogik.ButtonOpenVisible;
            if (_btnDeleteDoc != null)
                _btnDeleteDoc.Visible = _dokumentLogik.ButtonDeleteVisible;

            Text = _dokumentLogik.Text;

            // setting the background color
            if (EditMode == EditModeType.ReadOnly || IsDocumentLocked || !_allowEdit)
            {
                BackColor = GuiConfig.EditColorReadOnly;
            }
            else if (EditMode == EditModeType.BfsMust)
            {
                BackColor = GuiConfig.EditColorBfsMust;
            }
            else if (EditMode == EditModeType.Required)
            {
                BackColor = GuiConfig.EditColorRequired;
            }
            else
            {
                BackColor = GuiConfig.EditColorNormal;
            }

            if (_btnNewDoc != null)
                _btnNewDoc.ToolTip = _dokumentLogik.ButtonNewToolTip;
            if (_btnOpenDoc != null)
                _btnOpenDoc.ToolTip = _dokumentLogik.ButtonOpenToolTip;
            if (_btnImportDoc != null)
                _btnImportDoc.ToolTip = _dokumentLogik.ButtonImportToolTip;
            if (_btnDeleteDoc != null)
                _btnDeleteDoc.ToolTip = _dokumentLogik.ButtonDeleteToolTip;

            ToolTip = _dokumentLogik.GeneralToolTip;
            FirePropertyChanged("DocTemplateName");
        }

        /// <summary>
        /// Handles the DragDrop event of the XDokument control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
        private void XDokument_DragDrop(object sender, DragEventArgs e)
        {
            Focus();
            _dokumentLogik.PerformDropData(GetDataObject(e));
            OnDocumentImported();
        }

        /// <summary>
        /// Handles the DragOver event of the XDokument control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DragEventArgs"/> instance containing the event data.</param>
        private void XDokument_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = _dokumentLogik.CanDragAndDropData(GetDataObject(e)) ? DragDropEffects.Copy : DragDropEffects.None;
        }

        #endregion

        #region Methods

        #region Public Methods

        public void AllowEdit(bool value)
        {
            if (EditMode != EditModeType.ReadOnly)
            {
                _allowEdit = value;
                _dokumentLogik.AllowEdit(value);

                if (value)
                {
                    GuiConfig.SetEditMode(this, _editMode);
                }
                else
                {
                    GuiConfig.SetEditMode(this, EditModeType.ReadOnly);
                }

                ApplyButtons();
            }
        }

        /// <summary>
        /// Deletes the doc.
        /// </summary>
        public void DeleteDoc()
        {
            _dokumentLogik.DeleteDoc();
        }

        /// <summary>
        /// Deletes the document with the DocumentID or DataSource[DataMember] if the DocumentID is null
        /// </summary>
        public void DeleteDocByID()
        {
            var documentId = DocumentID;
            if (DBUtil.IsEmpty(documentId) && DataSource != null && DataMember != null)
            {
                documentId = DataSource[DataMember];
            }

            if (DBUtil.IsEmpty(documentId))
            {
                return;
            }

            DBUtil.ExecSQLThrowingException(@"DELETE FROM dbo.XDocument WHERE DocumentID = {0};", documentId);
        }

        /// <summary>
        /// Exportiert das referenzierte Dokument in ein DataSet
        /// </summary>
        /// <returns>Das exportierte DataSet</returns>
        public DataSet ExportExcelToDataSet()
        {
            return _dokumentLogik.ExportExcelToDataSet();
        }

        /// <summary>
        /// Gets the name of the bindable property.
        /// </summary>
        /// <returns></returns>
        string IKissBindableEdit.GetBindablePropertyName()
        {
            return "DocumentID";
        }

        /// <summary>
        /// Gets the empty word template.
        /// </summary>
        /// <returns></returns>
        public Byte[] GetEmptyWordTemplate()
        {
            return _dokumentLogik.GetEmptyWordTemplate();
        }

        /// <summary>
        /// Get an new template from KiSS application subfolder
        /// </summary>
        /// <returns>The zipped bytes of the new template</returns>
        public AvailableTemplate GetNewTemplate()
        {
            return _dokumentLogik.GetNewTemplate();
        }

        /// <summary>
        /// Imports the doc.
        /// </summary>
        public void ImportDoc()
        {
            _dokumentLogik.ImportDoc();
        }

        /// <summary>
        /// Imports the file with the given filename.
        /// </summary>
        /// <param name="fileName">The filename of the file to import.</param>
        public bool ImportFile(string fileName)
        {
            return _dokumentLogik.CreateHandlerAndImport(fileName);
        }

        /// <summary>
        /// Creates a new document.
        /// </summary>
        public void NewDoc()
        {
            // Context setzen (falls noch nicht passiert, z.B. CtlDynaMask)
            SetKissContextOnLogik();

            _dokumentLogik.NewDoc();
        }

        /// <summary>
        /// Opens the document.
        /// </summary>
        public void OpenDoc()
        {
            _dokumentLogik.OpenDoc();
        }

        /// <summary>
        /// Prints the document to the default printer.
        /// </summary>
        /// <returns>the <see cref="Task"/> that wait for destroy watcher and delete file and unlock</returns>
        /// <exception cref="KissErrorException">if filetype is unknown.</exception>
        public Task PrintDoc()
        {
            return _dokumentLogik.PrintDoc();
        }

        /// <summary>
        /// Prints the document to the specified printer.
        /// </summary>
        /// <param name="printerName">The printer where the document should be printed.</param>
        /// <returns>the <see cref="Task"/> that wait for destroy watcher and delete file and unlock</returns>
        /// <exception cref="KissErrorException">if filetype is unknown.</exception>
        public Task PrintDoc(string printerName)
        {
            return _dokumentLogik.PrintDoc(printerName);
        }

        /// <summary>
        /// Refreshes the display.
        /// </summary>
        public void RefreshDisplay()
        {
            _dokumentLogik.RefreshDisplay();
        }

        /// <summary>
        /// Saves the current document
        /// </summary>
        public void SaveExcelDoc()
        {
            _dokumentLogik.SaveExcelDoc();
        }

        /// <summary>
        /// Saves a template to the local folder before deleting it.
        /// </summary>
        public void SaveTemplateToLocalDirectory()
        {
            _dokumentLogik.SaveTemplateToLocalDirectory();
        }

        public void SetExcelNumberFromatOnColumns(string columns, string numberFormat)
        {
            _dokumentLogik.SetExcelNumberFormatOnColumns(columns, numberFormat);
        }

        /// <summary>
        /// Sets the Orientation of the current Excel-Worksheet
        /// </summary>
        /// <param name="orientation"></param>
        public void SetExcelOrientation(ExcelControl.Orientation orientation)
        {
            _dokumentLogik.SetExcelOrientation(orientation);
        }

        public void SetExcelPageNumberInPageFooter()
        {
            _dokumentLogik.SetExcelPageNumberInPageFooter();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Called when [click button].
        /// </summary>
        /// <param name="buttonInfo">The button info.</param>
        protected override void OnClickButton(EditorButtonObjectInfoArgs buttonInfo)
        {
            if (EditMode == EditModeType.ReadOnly && buttonInfo.Button != _btnOpenDoc)
            {
                return;
            }

            if (DataSource != null && DataSource.Count == 0)
            {
                return;
            }

            // locking is not working with DataSource.BatchUpdate
            if (DataSource != null && DataSource.BatchUpdate && !_dokumentLogik.IsEditModeReadOnly)
            {
                // coding error, do not translate
                KissMsg.ShowInfo("Programmfehler: BatchUpdate und Dokumente (XDocument.OnClickButton).");
                return;
            }

            base.OnClickButton(buttonInfo);

            if (buttonInfo.Button == _btnNewDoc)
            {
                _logger.Debug("btnNewDoc clicked, call method");
                NewDoc();
            }

            if (buttonInfo.Button == _btnOpenDoc)
            {
                _logger.Debug("btnOpenDoc clicked, call method");
                OpenDoc();
            }

            if (buttonInfo.Button == _btnImportDoc)
            {
                _logger.Debug("btnImportDoc clicked, call method");
                ImportDoc();
            }

            if (buttonInfo.Button == _btnDeleteDoc)
            {
                _logger.Debug("btnDeleteDoc clicked, call method");
                DeleteDoc();
            }

            // logging
            _logger.Debug("done, do refresh now");

            // refresh view to ensure proper display
            _dokumentLogik.RefreshDisplay();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // create/open document with F12
            EditorButton button = null;

            if (e.Modifiers == Keys.None && e.KeyCode == Keys.F12)
            {
                if (_btnNewDoc.Visible)
                {
                    button = _btnNewDoc;
                }
                else if (_btnOpenDoc.Visible)
                {
                    button = _btnOpenDoc;
                }
            }
            else if (Session.IsKiss5Mode && !e.Modifiers.HasFlag(Keys.Shift) && !e.Modifiers.HasFlag(Keys.Alt))
            {
                if (e.Modifiers.HasFlag(Keys.Control))
                {
                    switch (e.KeyCode)
                    {
                        case Keys.I:
                            button = _btnImportDoc;
                            break;

                        case Keys.N:
                            button = _btnNewDoc;
                            break;

                        case Keys.O:
                            button = _btnOpenDoc;
                            break;

                        case Keys.V:
                            // Paste document
                            var dataObject = new DragDropDataObject(Clipboard.GetDataObject());
                            if (_dokumentLogik.CanDragAndDropData(dataObject))
                            {
                                _dokumentLogik.PerformDropData(dataObject);
                                e.Handled = true;
                            }
                            break;
                    }
                }
                // CTRL+L funktioniert aus irgendeinem Grund nicht, deshalb einfach Delete
                else if (e.KeyCode == Keys.Delete)
                {
                    button = _btnDeleteDoc;
                }
            }

            if (button != null && button.Visible)
            {
                OnClickButton(new EditorButtonObjectInfoArgs(button, new AppearanceObject()));
            }

            base.OnKeyDown(e);
        }

        /// <summary>
        /// Called when [loaded].
        /// </summary>
        protected override void OnLoaded()
        {
            _logger.Debug("OnLoaded()");

            _btnNewDoc.Kind = ButtonPredefines.Glyph;
            _btnNewDoc.Image = BmpNewDoc;
            _btnNewDoc.Style.BackColor = GuiConfig.EditButtonColor;

            _btnOpenDoc.Kind = ButtonPredefines.Glyph;
            _btnOpenDoc.Image = BmpOpenDoc;
            _btnOpenDoc.Style.BackColor = GuiConfig.EditButtonColor;

            _btnImportDoc.Kind = ButtonPredefines.Glyph;
            _btnImportDoc.Image = BmpImportDoc;
            _btnImportDoc.Style.BackColor = GuiConfig.EditButtonColor;

            _btnDeleteDoc.Kind = ButtonPredefines.Glyph;
            _btnDeleteDoc.Image = BmpDeleteDoc;
            _btnDeleteDoc.Style.BackColor = GuiConfig.EditButtonColor;

            ApplyButtons();

            base.OnLoaded();

            // Context setzen
            SetKissContextOnLogik();

            _dokumentLogik.RefreshDisplay();
        }

        #endregion

        #region Private Static Methods

        private static DragDropDataObject GetDataObject(DragEventArgs e)
        {
            return new DragDropDataObject(e.Data);
        }

        #endregion

        #region Private Methods

        private void ApplyButtons()
        {
            Properties.Buttons.Clear();

            if (EditMode == EditModeType.ReadOnly || !_allowEdit)
            {
                Properties.Buttons.AddRange(
                    new[]
                    {
                        _btnOpenDoc
                    });
            }
            else
            {
                Properties.Buttons.AddRange(
                    new[]
                    {
                        _btnOpenDoc,
                        _btnDeleteDoc,
                        _btnNewDoc,
                        _btnImportDoc
                    });
            }

            _dokumentLogik.RefreshDisplay();
        }

        private void FirePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                PropertyChanged(this, args);
            }
        }

        /// <summary>
        /// Called when [document created].
        /// </summary>
        private void OnDocumentCreated()
        {
            if (DocumentCreated != null)
            {
                DocumentCreated(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [document creating].
        /// </summary>
        private void OnDocumentCreating(ref bool cancel)
        {
            if (DocumentCreating != null)
            {
                var args = new CancelEventArgs(cancel);
                DocumentCreating(this, args);
                cancel = args.Cancel;
            }
        }

        /// <summary>
        /// Called when [document deleted].
        /// </summary>
        private void OnDocumentDeleted()
        {
            if (DocumentDeleted != null)
            {
                DocumentDeleted(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [document deleting].
        /// </summary>
        private void OnDocumentDeleting(ref bool cancel)
        {
            if (DocumentDeleting != null)
            {
                var args = new CancelEventArgs(cancel);
                DocumentDeleting(this, args);
                cancel = args.Cancel;
            }
        }

        /// <summary>
        /// Called when [document id changed].
        /// </summary>
        private void OnDocumentIDChanged()
        {
            if (DocumentIDChanged != null)
            {
                DocumentIDChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [document imported].
        /// </summary>
        private void OnDocumentImported()
        {
            if (DocumentImported != null)
            {
                DocumentImported(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Called when [document importing].
        /// </summary>
        private void OnDocumentImporting(ref bool cancel)
        {
            if (DocumentImporting != null)
            {
                var args = new CancelEventArgs(cancel);
                DocumentImporting(this, args);
                cancel = args.Cancel;
            }
        }

        /// <summary>
        /// Called when [document opening].
        /// </summary>
        private void OnDocumentOpening(ref bool cancel)
        {
            if (DocumentOpening != null)
            {
                var args = new CancelEventArgs(cancel);
                DocumentOpening(this, args);
                cancel = args.Cancel;
            }
        }

        /// <summary>
        /// Called when [document saved].
        /// </summary>
        private void OnDocumentSaved()
        {
            if (DocumentSaved != null)
            {
                DocumentSaved(this, EventArgs.Empty);
            }
        }

        private void SetKissContextOnLogik()
        {
            if (_dokumentLogik.KissContext != null)
            {
                return;
            }

            _dokumentLogik.KissContext = KissForm.GetParent_IKissContext(this);
        }

        #endregion

        #endregion
    }
}