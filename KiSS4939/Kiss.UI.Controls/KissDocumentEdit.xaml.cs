using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Xpf.Themes.Kiss;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.DocumentHandling;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;
using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaktionslogik für KissDocumentEdit.xaml
    /// </summary>
    public partial class KissDocumentEdit : IKissEdit
    {
        public static readonly DependencyProperty BackColorProperty;
        public static readonly DependencyProperty CanCreateProperty;
        public static readonly DependencyProperty CanDeleteProperty;
        public static readonly DependencyProperty CanImportProperty;
        public static readonly DependencyProperty CanOpenProperty;
        public static readonly DependencyProperty ContextProperty;
        public static readonly DependencyProperty DataMemberDateLastSaveProperty;
        public static readonly DependencyProperty InfoTextProperty;
        public static readonly DependencyProperty IsAuthorizedProperty;
        public static readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty IsRequiredProperty;
        public static readonly DependencyProperty ToolTipDeleteProperty;
        public static readonly DependencyProperty ToolTipImportProperty;
        public static readonly DependencyProperty ToolTipNewProperty;
        public static readonly DependencyProperty ToolTipOpenProperty;
        public static readonly DependencyProperty TypeImageProperty;
        public static readonly DependencyProperty XDocumentIdProperty;
        public readonly IXDocumentLogic DocumentLogic;
        private readonly bool _isKiss5Mode;

        static KissDocumentEdit()
        {
            CanCreateProperty = DependencyProperty.Register(
                PropertyName.GetPropertyName<KissDocumentEdit>(x => x.CanCreate),
                typeof(bool),
                typeof(KissDocumentEdit),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, CanCreatePropertyChangedCallback));
            CanDeleteProperty = DependencyProperty.Register(
                PropertyName.GetPropertyName<KissDocumentEdit>(x => x.CanDelete),
                typeof(bool),
                typeof(KissDocumentEdit),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, CanDeletePropertyChangedCallback));
            CanImportProperty = DependencyProperty.Register(
                PropertyName.GetPropertyName<KissDocumentEdit>(x => x.CanImport),
                typeof(bool),
                typeof(KissDocumentEdit),
                new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, CanImportPropertyChangedCallback));
            CanOpenProperty = DependencyProperty.Register(
                PropertyName.GetPropertyName<KissDocumentEdit>(x => x.CanOpen),
                typeof(bool),
                typeof(KissDocumentEdit));
            ContextProperty = DependencyProperty.Register(
                PropertyName.GetPropertyName<KissDocumentEdit>(x => x.Context),
                typeof(string),
                typeof(KissDocumentEdit),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, ContextPropertyChangedCallback));

            IsReadOnlyProperty = DependencyProperty.Register(
                PropertyName.GetPropertyName<KissDocumentEdit>(x => x.IsReadOnly),
                typeof(bool),
                typeof(KissDocumentEdit),
                new FrameworkPropertyMetadata(false, IsReadOnlyChanged));
            IsAuthorizedProperty = DependencyProperty.Register(
                PropertyName.GetPropertyName<KissDocumentEdit>(x => x.IsAuthorized),
                typeof(bool),
                typeof(KissDocumentEdit),
                new FrameworkPropertyMetadata(false, IsAuthorizedChanged));
            IsRequiredProperty = DependencyProperty.Register(
                PropertyName.GetPropertyName<KissDocumentEdit>(x => x.IsRequired),
                typeof(bool),
                typeof(KissDocumentEdit),
                new FrameworkPropertyMetadata(false, IsRequiredChanged));

            ToolTipNewProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissDocumentEdit>(x => x.ToolTipNew), typeof(string), typeof(KissDocumentEdit));
            ToolTipOpenProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissDocumentEdit>(x => x.ToolTipOpen), typeof(string), typeof(KissDocumentEdit));
            ToolTipImportProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissDocumentEdit>(x => x.ToolTipImport), typeof(string), typeof(KissDocumentEdit));
            ToolTipDeleteProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissDocumentEdit>(x => x.ToolTipDelete), typeof(string), typeof(KissDocumentEdit));

            InfoTextProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissDocumentEdit>(x => x.InfoText), typeof(string), typeof(KissDocumentEdit));
            TypeImageProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissDocumentEdit>(x => x.TypeImage), typeof(ImageSource), typeof(KissDocumentEdit));
            XDocumentIdProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissDocumentEdit>(x => x.XDocumentId), typeof(int?), typeof(KissDocumentEdit), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, XDocumentId_Changed));

            DataMemberDateLastSaveProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissDocumentEdit>(x => x.DataMemberDateLastSave), typeof(string), typeof(KissDocumentEdit), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, DataMemberDateLastSavePropertyChangedCallback));

            BackColorProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissDocumentEdit>(x => x.BackColor), typeof(SolidColorBrush), typeof(KissDocumentEdit));
        }

        public KissDocumentEdit()
        {
            DataContextChanged += KissDocumentEdit_DataContextChanged;

            ResourceUtil.CreateStaticResourcesForDesigner(this);
            InitializeComponent();

            if (DesignMode)
            {
                DocumentLogic = new DummyDocumentLogic();
            }
            else
            {
                DocumentLogic = Container.Resolve<IXDocumentLogic>();
            }

            // Attach required events for proper working of control
            DocumentLogic.DokFormatCodeChanged += DocumentLogic_DokFormatCodeChanged;
            DocumentLogic.EditModeChanged += DocumentLogic_EditModeChanged;

            //DocumentLogic.DocumentCreated += DocumentLogic_DocumentCreated;
            //DocumentLogic.DocumentCreating += DocumentLogic_DocumentCreating;
            DocumentLogic.DocumentDeleted += DocumentLogic_DocumentDeleted;
            //DocumentLogic.DocumentDeleting += DocumentLogic_DocumentDeleting;
            DocumentLogic.DocumentIDChanged += DocumentLogic_DocumentIDChanged;
            //DocumentLogic.DocumentImported += DocumentLogic_DocumentImported;
            //DocumentLogic.DocumentImporting += DocumentLogic_DocumentImporting;
            //DocumentLogic.DocumentOpening += DocumentLogic_DocumentOpening;
            //DocumentLogic.DocumentSaved += DocumentLogic_DocumentSaved;
            DocumentLogic.RefreshGui += DocumentLogic_RefreshGui;

            // First init of control
            DocumentLogic.SetEditModeNormal();
            DocumentLogic.DokFormatCode = DokFormat.Unbekannt;
            DocumentLogic.DokTypCode = DokTyp.Dokument;

            // Register Drag'n'Drop
            AllowDrop = true;

            PreviewDragEnter += KissDocumentEdit_DragEventHandler;
            PreviewDragOver += KissDocumentEdit_DragEventHandler;
            PreviewDragLeave += KissDocumentEdit_DragEventHandler;
            TextBox.PreviewDragEnter += KissDocumentEdit_DragEventHandler;
            TextBox.PreviewDragOver += KissDocumentEdit_DragEventHandler;
            TextBox.PreviewDragLeave += KissDocumentEdit_DragEventHandler;

            Drop += KissDocumentEdit_Drop;

            var authorizedBinding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(RightHelper.MaskRightProperty),
                Mode = BindingMode.OneWay,
            };
            SetBinding(IsAuthorizedProperty, authorizedBinding);

            SetTypeImage();

            if (!DesignMode)
            {
                var sessionService = Container.Resolve<ISessionService>();
                _isKiss5Mode = sessionService.IsKiss5Mode;
            }
        }

        public static bool DesignMode
        {
            get { return DesignerProperties.GetIsInDesignMode(new DependencyObject()); }
        }

        public SolidColorBrush BackColor
        {
            get { return GetValue(BackColorProperty) as SolidColorBrush; }
            set { SetValue(BackColorProperty, value); }
        }

        /// <summary>
        /// Allow create new document
        /// </summary>
        [DefaultValue(true)]
        public bool CanCreate
        {
            get { return (bool)GetValue(CanCreateProperty); }
            set { SetValue(CanCreateProperty, value); }
        }

        /// <summary>
        /// Allow delete document
        /// </summary>
        [DefaultValue(true)]
        public bool CanDelete
        {
            get { return (bool)GetValue(CanDeleteProperty); }
            set { SetValue(CanDeleteProperty, value); }
        }

        /// <summary>
        /// Allow import document
        /// </summary>
        [DefaultValue(true)]
        public bool CanImport
        {
            get { return (bool)GetValue(CanImportProperty); }
            set { SetValue(CanImportProperty, value); }
        }

        public bool CanOpen
        {
            get { return (bool)GetValue(CanOpenProperty); }
            set { SetValue(CanOpenProperty, value); }
        }

        /// <summary>
        /// Gets or sets the context to determine which Templates to display.
        /// </summary>
        /// <value>The context.</value>
        [Browsable(true),
        DefaultValue("")]
        public string Context
        {
            get { return DocumentLogic.Context; }
            set { DocumentLogic.Context = value; }
        }

        public string DataMemberDateLastSave
        {
            get { return (string)GetValue(DataMemberDateLastSaveProperty); }
            set { SetValue(DataMemberDateLastSaveProperty, value); }
        }

        public string InfoText
        {
            get { return GetValue(InfoTextProperty) as string; }
            set { SetValue(InfoTextProperty, value); }
        }

        public bool IsAuthorized
        {
            get { return (bool)GetValue(IsAuthorizedProperty); }
            set { SetValue(IsAuthorizedProperty, value); }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        public string ToolTipDelete
        {
            get { return GetValue(ToolTipDeleteProperty) as string; }
            set { SetValue(ToolTipDeleteProperty, value); }
        }

        public string ToolTipImport
        {
            get { return GetValue(ToolTipImportProperty) as string; }
            set { SetValue(ToolTipImportProperty, value); }
        }

        public string ToolTipNew
        {
            get { return GetValue(ToolTipNewProperty) as string; }
            set { SetValue(ToolTipNewProperty, value); }
        }

        public string ToolTipOpen
        {
            get { return GetValue(ToolTipOpenProperty) as string; }
            set { SetValue(ToolTipOpenProperty, value); }
        }

        public ImageSource TypeImage
        {
            get { return GetValue(TypeImageProperty) as ImageSource; }
            set { SetValue(TypeImageProperty, value); }
        }

        public int? XDocumentId
        {
            get { return GetValue(XDocumentIdProperty) as int?; }
            set { SetValue(XDocumentIdProperty, value); }
        }

        public static IKissContext GetParentIKissContextByDataContext(FrameworkElement fe)
        {
            if (fe == null || fe.DataContext == null)
            {
                return null;
            }

            if (fe.DataContext is IKissContext)
            {
                return (IKissContext)fe.DataContext;
            }

            var parent = VisualTreeHelper.GetParent(fe) as FrameworkElement;
            return GetParentIKissContextByDataContext(parent);
        }

        public static IKissContext GetParentIKissContextByDependencyObject(DependencyObject ctl)
        {
            var parent = VisualTreeHelper.GetParent(ctl);

            if (parent == null)
            {
                return null;
            }

            if (parent is IKissContext)
            {
                return (IKissContext)parent;
            }

            return GetParentIKissContextByDependencyObject(parent);
        }

        /// <summary>
        /// Deletes the doc.
        /// </summary>
        public void DeleteDoc()
        {
            DocumentLogic.DeleteDoc();
        }

        /// <summary>
        /// Imports the doc.
        /// </summary>
        public void ImportDoc()
        {
            DocumentLogic.ImportDoc();
        }

        /// <summary>
        /// Imports the file with the given filename.
        /// </summary>
        /// <param name="fileName">The filename of the file to import.</param>
        public bool ImportFile(string fileName)
        {
            return DocumentLogic.CreateHandlerAndImport(fileName);
        }

        /// <summary>
        /// Creates a new document.
        /// </summary>
        public void NewDoc()
        {
            DocumentLogic.NewDoc();
        }

        /// <summary>
        /// Opens the document.
        /// </summary>
        public void OpenDoc()
        {
            DocumentLogic.OpenDoc();
        }

        /// <summary>
        /// Saves the current document
        /// </summary>
        public void SaveExcelDoc()
        {
            DocumentLogic.SaveExcelDoc();
        }

        public void SetExcelNumberFromatOnColumns(string columns, string numberFormat)
        {
            DocumentLogic.SetExcelNumberFormatOnColumns(columns, numberFormat);
        }

        public void SetExcelPageNumberInPageFooter()
        {
            DocumentLogic.SetExcelPageNumberInPageFooter();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            // create/open document with F12
            KissButton button = null;
            if (!KeyboardUtil.IsModifierKeyPressed() && e.Key == Key.F12)
            {
                if (DocumentLogic.ButtonNewVisible)
                {
                    button = btnNew;
                }
                else if (DocumentLogic.ButtonOpenVisible)
                {
                    button = btnOpen;
                }
            }
            else if (_isKiss5Mode && !KeyboardUtil.IsAnyShiftKeyPressed() && !KeyboardUtil.IsAnyAltKeyPressed())
            {
                if (KeyboardUtil.IsAnyControlKeyPressed())
                {
                    if (e.Key == Key.I)
                    {
                        button = btnImport;
                    }
                    else if (e.Key == Key.N)
                    {
                        button = btnNew;
                    }
                    else if (e.Key == Key.O)
                    {
                        button = btnOpen;
                    }
                    else if (e.Key == Key.V)
                    {
                        // Paste document
                        var dataObject = new DragDropDataObject(Clipboard.GetDataObject());
                        if (DocumentLogic.CanDragAndDropData(dataObject))
                        {
                            DocumentLogic.PerformDropData(dataObject);
                            e.Handled = true;
                        }
                    }
                }
                else if (e.Key == Key.Delete)
                {
                    button = btnDelete;
                }
            }

            if (button != null && button.Visibility == Visibility.Visible)
            {
                ButtonClicked(button);
                e.Handled = true;
            }

            base.OnPreviewKeyDown(e);
        }

        private static void CanCreatePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var documentEdit = (KissDocumentEdit)dependencyObject;
            documentEdit.DocumentLogic.CanCreateDocument = (bool)e.NewValue;
        }

        private static void CanDeletePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var documentEdit = (KissDocumentEdit)dependencyObject;
            documentEdit.DocumentLogic.CanDeleteDocument = (bool)e.NewValue;
        }

        private static void CanImportPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var documentEdit = (KissDocumentEdit)dependencyObject;
            documentEdit.DocumentLogic.CanImportDocument = (bool)e.NewValue;
        }

        private static void ContextPropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var documentEdit = (KissDocumentEdit)dependencyObject;
            documentEdit.DocumentLogic.Context = (string)e.NewValue;
        }

        private static void DataMemberDateLastSavePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var documentEdit = (KissDocumentEdit)dependencyObject;
            documentEdit.DocumentLogic.DataMemberDateLastSave = (string)e.NewValue;
        }

        private static DragDropDataObject GetDataObject(DragEventArgs e)
        {
            return new DragDropDataObject(e.Data);
        }

        private static IDataSource GetDataSourceByDataContext(FrameworkElement fe)
        {
            if (fe == null)
            {
                return null;
            }

            if (fe.DataContext == null)
            {
                return null;
            }

            if (fe.DataContext is IDataSource)
            {
                return (IDataSource)fe.DataContext;
            }

            var parent = VisualTreeHelper.GetParent(fe) as FrameworkElement;
            return GetDataSourceByDataContext(parent);
        }

        private static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissDocumentEdit)d;
            instance.UpdateEditMode();
        }

        private static void IsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissDocumentEdit)d;
            instance.UpdateEditMode();
        }

        private static void IsRequiredChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissDocumentEdit)d;
            instance.UpdateEditMode();
        }

        private static void SetDocumentIdToLogic(KissDocumentEdit edit, int? id)
        {
            if (id.HasValue && id.Value < 1)
            {
                id = null;
            }

            edit.DocumentLogic.DocumentID = id;
        }

        private static void XDocumentId_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var edit = (KissDocumentEdit)d;
            var id = e.NewValue as int?;

            SetDocumentIdToLogic(edit, id);
        }

        private void ApplyButtons()
        {
            DocumentLogic.RefreshDisplay();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked(btnDelete);
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked(btnImport);
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked(btnNew);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            ButtonClicked(btnOpen);
        }

        /// <summary>
        /// Called when [click button].
        /// </summary>
        /// <param name="button">The button info.</param>
        private void ButtonClicked(KissButton button)
        {
            if (DocumentLogic.IsEditModeReadOnly && button != btnOpen)
            {
                return;
            }

            if (button == btnNew)
            {
                NewDoc();
            }

            if (button == btnOpen)
            {
                OpenDoc();
            }

            if (button == btnImport)
            {
                ImportDoc();
            }

            if (button == btnDelete)
            {
                DeleteDoc();
            }

            // refresh view to ensure proper display
            DocumentLogic.RefreshDisplay();
        }

        private void DocumentLogic_DocumentDeleted(object sender, EventArgs e)
        {
            // reset typeimage after delete
            SetTypeImage();
        }

        private void DocumentLogic_DocumentIDChanged(object sender, EventArgs e)
        {
            // DocumentID has changed in the IXDocumentLogic, update the DependencyProperty
            XDocumentId = DocumentLogic.DocumentID as int?;
            SetTypeImage();
        }

        private void DocumentLogic_DokFormatCodeChanged(object sender, EventArgs e)
        {
            SetTypeImage();
        }

        private void DocumentLogic_EditModeChanged(object sender, EventArgs e)
        {
            ApplyButtons();
        }

        private void DocumentLogic_RefreshGui(object sender, EventArgs e)
        {
            btnNew.Visibility = DocumentLogic.ButtonNewVisible ? Visibility.Visible : Visibility.Collapsed;
            btnImport.Visibility = DocumentLogic.ButtonImportVisible ? Visibility.Visible : Visibility.Collapsed;
            btnOpen.Visibility = DocumentLogic.ButtonOpenVisible ? Visibility.Visible : Visibility.Collapsed;
            btnDelete.Visibility = DocumentLogic.ButtonDeleteVisible ? Visibility.Visible : Visibility.Collapsed;

            ToolTipNew = DocumentLogic.ButtonNewToolTip;
            ToolTipOpen = DocumentLogic.ButtonOpenToolTip;
            ToolTipImport = DocumentLogic.ButtonImportToolTip;
            ToolTipDelete = DocumentLogic.ButtonDeleteToolTip;

            InfoText = DocumentLogic.Text;

            if (DocumentLogic.IsEditModeReadOnly || DocumentLogic.IsDocumentLocked)
            {
                BackColor = FindResource(new KissBrushKeyExtension(KissBrushKeys.EditControlBackgroundReadOnly)) as SolidColorBrush;
            }
            else if (DocumentLogic.IsEditModeRequired)
            {
                BackColor = FindResource(new KissBrushKeyExtension(KissBrushKeys.EditControlBackgroundRequired)) as SolidColorBrush;
            }
            else
            {
                BackColor = FindResource(new KissBrushKeyExtension(KissBrushKeys.EditControlBackgroundNormal)) as SolidColorBrush;
            }
        }

        private string GetDataMemberByBinding()
        {
            var expression = GetBindingExpression(XDocumentIdProperty);

            if (expression == null)
            {
                return null;
            }

            return expression.ParentBinding.Path.Path;
        }

        private void KissDocumentEdit_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            DocumentLogic.KissContext = GetParentIKissContextByDependencyObject(this) ?? GetParentIKissContextByDataContext(this);
            DocumentLogic.DataSource = GetDataSourceByDataContext(this);
        }

        private void KissDocumentEdit_DragEventHandler(object sender, DragEventArgs e)
        {
            e.Effects = DocumentLogic.CanDragAndDropData(GetDataObject(e)) ? DragDropEffects.Copy : DragDropEffects.None;
            e.Handled = true;
        }

        private void KissDocumentEdit_Drop(object sender, DragEventArgs e)
        {
            if (DocumentLogic.CanDragAndDropData(GetDataObject(e)))
            {
                Focus();
                DocumentLogic.PerformDropData(GetDataObject(e));
            }
        }

        private void SetTypeImage()
        {
            if (!XDocumentId.HasValue)
            {
                TypeImage = new BitmapImage(new Uri("/Kiss.Infrastructure;component/Images/Kiss_System_Document_Open.png", UriKind.Relative));
                return;
            }

            switch (DocumentLogic.DokFormatCode)
            {
                case DokFormat.Unbekannt:
                    TypeImage = new BitmapImage(new Uri("/Kiss.Infrastructure;component/Images/Kiss_System_Document_Open.png", UriKind.Relative));
                    break;

                case DokFormat.Word:
                    TypeImage = new BitmapImage(new Uri("/Kiss.Infrastructure;component/Images/Kiss_System_Document_Word.png", UriKind.Relative));
                    break;

                case DokFormat.Excel:
                    TypeImage = new BitmapImage(new Uri("/Kiss.Infrastructure;component/Images/Kiss_System_Document_Excel.png", UriKind.Relative));
                    break;

                case DokFormat.PDF:
                    TypeImage = new BitmapImage(new Uri("/Kiss.Infrastructure;component/Images/Kiss_System_Document_Pdf.png", UriKind.Relative));
                    break;
            }
        }

        private void UpdateEditMode()
        {
            var editMode = EditModeType.Normal;
            if (IsRequired)
            {
                editMode = EditModeType.Required;
            }
            if (!IsAuthorized || IsReadOnly)
            {
                editMode = EditModeType.ReadOnly;
            }
            DocumentLogic.EditMode = editMode;
        }

        private void UserControl_GotFocus(object sender, RoutedEventArgs e)
        {
            Bd.RenderFocused = true;
            Bd.Focus();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ApplyButtons();

            // set KissContext (class used to get single bookmarks; 1. prio = by visualtree (settable by implementing IKissContext in view), 2. prio = by datacontext)
            DocumentLogic.KissContext = GetParentIKissContextByDependencyObject(this) ?? GetParentIKissContextByDataContext(this);

            // set DataSource and DataMember to logic to enable editing documents
            DocumentLogic.DataSource = GetDataSourceByDataContext(this);
            DocumentLogic.DataMember = GetDataMemberByBinding();
        }

        private void UserControl_LostFocus(object sender, RoutedEventArgs e)
        {
            Bd.RenderFocused = false;
        }

        private void UserControl_MouseEnter(object sender, MouseEventArgs e)
        {
            Bd.RenderMouseOver = true;
        }

        private void UserControl_MouseLeave(object sender, MouseEventArgs e)
        {
            Bd.RenderMouseOver = false;
        }

        /*
        /// <summary>
        /// Sets the Orientation of the current Excel-Worksheet
        /// </summary>
        /// <param name="orientation"></param>
        public void SetExcelOrientation(ExcelControl.Orientation orientation)
        {
            DocumentLogic.SetExcelOrientation(orientation);
        }
        */

        /// <summary>
        /// Dummy implementation of IXDocumentLogic. Used in DesignMode.
        /// </summary>
        private class DummyDocumentLogic : IXDocumentLogic
        {
            public event EventHandler DocumentCreated;

            public event CancelEventHandler DocumentCreating;

            public event EventHandler DocumentDeleted;

            public event CancelEventHandler DocumentDeleting;

            public event EventHandler DocumentIDChanged;

            public event EventHandler DocumentImported;

            public event CancelEventHandler DocumentImporting;

            public event CancelEventHandler DocumentOpening;

            public event EventHandler DocumentSaved;

            public event EventHandler DokFormatCodeChanged;

            public event EventHandler EditModeChanged;

            public event EventHandler RefreshGui;

            public string ButtonDeleteToolTip
            {
                get { return String.Empty; }
            }

            public bool ButtonDeleteVisible
            {
                get { return true; }
            }

            public string ButtonImportToolTip
            {
                get { return String.Empty; }
            }

            public bool ButtonImportVisible
            {
                get { return true; }
            }

            public string ButtonNewToolTip
            {
                get { return String.Empty; }
            }

            public bool ButtonNewVisible
            {
                get { return true; }
            }

            public string ButtonOpenToolTip
            {
                get { return String.Empty; }
            }

            public bool ButtonOpenVisible
            {
                get { return true; }
            }

            public bool CanCreateDocument
            {
                get
                {
                    return true;
                }
                set
                {
                }
            }

            public bool CanDeleteDocument
            {
                get
                {
                    return true;
                }
                set
                {
                }
            }

            public bool CanImportDocument
            {
                get
                {
                    return true;
                }
                set
                {
                }
            }

            public bool CanUpdate
            {
                get { return true; }
            }

            public string Context
            {
                get
                {
                    return String.Empty;
                }
                set
                {
                }
            }

            public string DataMember
            {
                get
                {
                    return String.Empty;
                }
                set
                {
                }
            }

            public string DataMemberDateLastSave
            {
                get { return null; }
                set
                { }
            }

            public IDataSource DataSource
            {
                get
                {
                    return null;
                }
                set
                {
                }
            }

            public object DocumentID
            {
                get
                {
                    return null;
                }
                set
                {
                }
            }

            public DokFormat DokFormatCode
            {
                get
                {
                    return DokFormat.Unbekannt;
                }
                set
                {
                }
            }

            public DokTyp DokTypCode
            {
                get
                {
                    return DokTyp.Dokument;
                }
                set
                {
                }
            }

            public EditModeType EditMode
            {
                get { return EditModeType.Normal; }
                set { }
            }

            public bool IsDocumentLocked
            {
                get { return false; }
            }

            public bool IsEditModeReadOnly
            {
                get { return false; }
            }

            public bool IsEditModeRequired
            {
                get { return false; }
            }

            public IKissContext KissContext
            {
                get
                {
                    return null;
                }
                set
                {
                }
            }

            public string Text
            {
                get { return String.Empty; }
            }

            public bool CanDragAndDropData(IDragDropDataObject argsData)
            {
                return false;
            }

            public bool CreateHandlerAndImport(string theFile)
            {
                return false;
            }

            public void DeleteDoc()
            {
            }

            public void ImportDoc()
            {
            }

            public void NewDoc()
            {
            }

            public void OpenDoc()
            {
            }

            public bool PerformDropData(IDragDropDataObject argsData)
            {
                return false;
            }

            public void RefreshDisplay()
            {
                OnRefreshGui();
            }

            public void SaveExcelDoc()
            {
            }

            public void SetEditModeNormal()
            {
            }

            public void SetExcelNumberFormatOnColumns(string columns, string numberFormat)
            {
            }

            public void SetExcelPageNumberInPageFooter()
            {
            }

            /// <summary>
            /// Called when the Control should refresh itself.
            /// </summary>
            private void OnRefreshGui()
            {
                if (RefreshGui != null)
                {
                    RefreshGui(this, EventArgs.Empty);
                }
            }
        }
    }
}