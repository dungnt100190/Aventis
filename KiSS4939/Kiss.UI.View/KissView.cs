using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Themes.Kiss;
using Kiss.Infrastructure;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UI.Controls;
using Kiss.UI.Controls.Converter;
using Kiss.UI.Controls.Helper;
using Kiss.UI.ViewModel;
using Binding = System.Windows.Data.Binding;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using UserControl = System.Windows.Controls.UserControl;

namespace Kiss.UI.View
{
    /// <summary>
    /// Base view for all KiSS WPF views
    /// </summary>
    public class KissView : UserControl, IKissDataNavigator, IViewMessaging, IKissContext
    {
        #region Fields

        #region Public Static Fields

        // Using a DependencyProperty as the backing store for ValidationResult.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValidationResultProperty =
            DependencyProperty.Register(
                "ValidationResult",
                typeof(KissServiceResult),
                typeof(KissView),
                new UIPropertyMetadata(ValidationResultChanged));

        #endregion

        #region Private Fields

        private IViewModel _viewModel;

        #endregion

        #endregion

        #region Constructors

        protected KissView()
        {
            // set background to avoid black border while loading the view
            Background = FindResource(new KissBrushKeyExtension(KissBrushKeys.KissViewBackground)) as Brush;

            Loaded += KissView_Loaded;
            Initialized += KissView_Initialized;

            KissTheme.Enable(this);
            ResourceUtil.CreateStaticResourcesForDesigner(this);
        }

        #endregion

        #region Properties

        public KissServiceResult ValidationResult
        {
            get { return (KissServiceResult)GetValue(ValidationResultProperty); }
            set { SetValue(ValidationResultProperty, value); }
        }

        /// <summary>
        /// Gets the ViewModel
        /// </summary>
        public IViewModel ViewModel
        {
            get { return _viewModel ?? (_viewModel = GetViewModel()); }
        }

        public IViewModelCRUD ViewModelCRUD
        {
            get { return ViewModel as IViewModelCRUD; }
        }

        #endregion

        #region EventHandlers

        private void DisplayQuestion_InfoMessageBox(MessageRaisedEventArgs messageArgs)
        {
            Utilities.MessageBox.ShowInfoMessageBox(messageArgs.Message);
            messageArgs.Cancel = false;
        }

        private void DisplayQuestion_KissButtonSearchBoxDialog(QuestionRaisedEventArgs questionArgs)
        {
            List<object> data = new List<object>(questionArgs.AvailableOptions);
            List<GridColumnDefinition> columns = new List<GridColumnDefinition>
            {
                new GridColumnDefinition
                {
                    Fieldname = "Caption",
                    Title = questionArgs.Message,
                }
            };

            KissButtonSearchBoxDialog dialog = new KissButtonSearchBoxDialog(data, columns);
            bool? result = dialog.ShowDialog();
            if (!(result ?? false))
            {
                questionArgs.Cancel = true;
            }
            else
            {
                questionArgs.SelectedOption = (QuestionAnswerOption)dialog.SelectedItem;
            }
        }

        private void DisplayQuestion_MessageBox(QuestionRaisedEventArgs questionArgs)
        {
            bool result = Utilities.MessageBox.ShowQuestion(questionArgs.Message);
            questionArgs.Cancel = false; //At the moment, the legacy MessageBox we're using doesn't detect Cancel (it results in 'No').
            questionArgs.SelectedOption = questionArgs.AvailableOptions.Find(qao => (bool)qao.Tag == result);
        }

        private void KissView_Initialized(object sender, System.EventArgs e)
        {
            try
            {
                if (!ViewModelBase.DesignMode)
                {
                    var viewModel = GetViewModel() as ViewModelBase; //ToDo: MaskName in Interface aufnehmen?

                    if (viewModel == null)
                    {
                        return;
                    }

                    viewModel.MaskName = GetType().FullName + ".xaml";
                }
            }
            finally { }
        }

        private void KissView_Loaded(object sender, RoutedEventArgs e)
        {
            SetBinding(ValidationResultProperty, new Binding(PropertyName.GetPropertyName(() => ViewModel.ValidationResult)) { Source = ViewModel });
            SetBinding(CursorProperty, new Binding(PropertyName.GetPropertyName(() => ViewModel.IsBusy)) { Source = ViewModel, Converter = new Bool2CursorConverter() });

            var mr = ViewModel as IMessageRaiser;

            if (mr != null)
            {
                // remove any registered handlers first to prevent duplicate messages
                mr.MessageRaised -= MessageRaised;
                mr.MessageRaised += MessageRaised;
            }

            var element = Content as FrameworkElement;

            if (element != null)
            {
                element.SetBinding(RightHelper.MaskRightProperty, PropertyName.GetPropertyName(() => ViewModel.HasMaskRight));
            }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void ValidationResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissView)d;
            var value = e.NewValue as KissServiceResult;

            instance.HandleValidationResult(value);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Adds a new data entity
        /// </summary>
        /// <returns><c>True</c> on success, otherwiese <c>False</c></returns>
        public virtual bool AddData()
        {
            // save first before adding a new entity - this prevents adding multiple rows without saving
            if (ViewModelCRUD != null)
            {
                return SaveData() && ViewModelCRUD.NewData();
            }
            return true;
            //ViewModel.InsertCommand.Execute(null);
        }

        /// <summary>
        /// Deletes the current selected data entity
        /// </summary>
        /// <returns><c>True</c> on success, otherwiese <c>False</c></returns>
        public virtual bool DeleteData()
        {
            if (ViewModelCRUD != null)
            {
                return ViewModelCRUD.DeleteData(null);
            }
            return true;
            //ViewModel.DeleteCommand.Execute(null);
        }

        public string GetContextName()
        {
            var kissContext = ViewModel as IKissContext;
            return kissContext != null ? kissContext.GetContextName() : null;
        }

        public object GetContextValue(string fieldName)
        {
            var kissContext = ViewModel as IKissContext;
            return kissContext != null ? kissContext.GetContextValue(fieldName) : null;
        }

        /// <summary>
        /// Initialize the View and the ViewModel (at least used by call on "KiSS4.Common.CtlWpfMask" to initialize ViewModel)
        /// </summary>
        public virtual void InitViewAndViewModel()
        {
            // default: no action
        }

        /// <summary>
        /// Initialize the View and the ViewModel (at least used by call on "KiSS4.Common.CtlWpfMask" to initialize ViewModel)
        /// </summary>
        public virtual void InitViewAndViewModel(int entityId)
        {
            // default: no action
        }

        public virtual bool JumpToPath(HybridDictionary parameters)
        {
            if (ViewModel != null)
            {
                return ViewModel.JumpToPath(parameters);
            }

            return true;
        }

        public virtual bool KeyDownKiss(KeyEventArgs keyEvent)
        {
            // TODO: how?
            return false;
        }

        public virtual void MoveFirst()
        {
            var vmList = ViewModel as IViewModelList;

            if (vmList != null && vmList.EntityList != null)
            {
                var e = vmList.EntityList.GetEnumerator();
                e.MoveNext();
                vmList.SelectedEntity = e.Current;
            }
        }

        public virtual void MoveLast()
        {
            // TODO: how?
        }

        public virtual void MoveNext()
        {
            var vmList = ViewModel as IViewModelList;

            if (vmList != null && vmList.EntityList != null)
            {
                var e = vmList.EntityList.GetEnumerator();
                e.MoveNext();
                vmList.SelectedEntity = e.Current;
            }
        }

        public virtual void MovePrevious()
        {
            // TODO: how?
        }

        public void PrintReport()
        {
            var kissContext = ViewModel as IKissContext;
            if (kissContext != null)
            {
                kissContext.PrintReport();
            }
        }

        public virtual bool ReceiveMessage(HybridDictionary parameters)
        {
            var action = parameters["Action"] as string;
            switch (action)
            {
                case "JumpToPath":
                    return JumpToPath(parameters);

                default:
                    return false;
            }
        }

        public virtual void RefreshData()
        {
            var vmSearch = ViewModel as IViewModelSearch;

            if (vmSearch != null)
            {
                vmSearch.Search(null);
            }
            else if (ViewModelCRUD != null)
            {
                ViewModelCRUD.LoadData(null);
            }
        }

        public virtual bool RestoreData()
        {
            // TODO: how?
            return false;
        }

        public virtual object ReturnMessage(HybridDictionary parameters)
        {
            return null;
        }

        /// <summary>
        /// Saves the current selected data entity
        /// </summary>
        /// <returns><c>True</c> on success, otherwiese <c>False</c></returns>
        public virtual bool SaveData()
        {
            //make sure, the edited value of the current element is going to be saved
            //in case the control only sets its EditValue at FocusLost event (e.g. KissDateEdit).
            var focusedElement = GetFocusedElement<BaseEdit>();

            if (focusedElement != null)
            {
                focusedElement.DoValidate();

                //make sure, the value is saved even if the focused control is an editor in a Table
                //(value has to be posted through the Table's TableView)
                var focusedTable = GetFocusedElement<GridControl>(focusedElement);
                if (focusedTable != null)
                {
                    focusedTable.View.PostEditor();
                }
            }

            if (ViewModelCRUD != null)
            {
                return ViewModelCRUD.SaveData(null);
            }

            return true;
        }

        public virtual void Search()
        {
            var vmSearch = ViewModel as IViewModelSearch;

            if (vmSearch != null)
            {
                // check state
                bool performSearch = !(Content.GetType() == typeof(KissSearchControl) &&
                                       ((KissSearchControl)Content).CurrentSearchPanelState == KissSearchControl.SearchPanelState.Collapsed);

                // do collapse/expand and execute search using command
                if (vmSearch.SearchCommand != null)
                {
                    vmSearch.SearchCommand.Execute(null);

                    // search will be executed with searchcommand
                    performSearch = false;
                }

                // searching data if required
                if (performSearch)
                {
                    vmSearch.Search(null);
                }
            }
        }

        public virtual void UndoDataChanges()
        {
            if (ViewModelCRUD != null)
            {
                ViewModelCRUD.UndoDataChanges();
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Gets the ViewModel. Searches in the Resources-dictionary using the key "viewModel" and in the DataContext.
        /// </summary>
        /// <returns></returns>
        protected virtual IViewModel GetViewModel()
        {
            if (Resources.Contains("viewModel"))
            {
                return FindResource("viewModel") as IViewModel;
            }
            // Fallback auf DataContext
            return DataContext as IViewModel;
        }

        /// <summary>
        /// Handles a service result that is returned from the validator.
        /// </summary>
        protected virtual void HandleValidationResult(KissServiceResult result)
        {
        }

        #endregion

        #region Private Methods

        private T GetFocusedElement<T>()
            where T : DependencyObject
        {
            return GetFocusedElement<T>(null);
        }

        private T GetFocusedElement<T>(DependencyObject startElement)
            where T : DependencyObject
        {
            var element = startElement ?? Keyboard.FocusedElement as DependencyObject;
            while (element != null)
            {
                if (element is T)
                {
                    return (T)element;
                }

                element = VisualTreeHelper.GetParent(element);
            }
            return null;
        }

        private void MessageRaised(object sender, MessageRaisedEventArgs messageArgs)
        {
            //Message or Question?
            QuestionRaisedEventArgs questionArgs = messageArgs as QuestionRaisedEventArgs;
            if (questionArgs != null)
            {
                //question

                //-The QuestionAnswerOption's Tag contains boolean-values:
                if (questionArgs.AvailableOptions.All(qao => qao.Tag is bool))
                {
                    // --> MessageBox
                    DisplayQuestion_MessageBox(questionArgs);
                    return;
                }

                //else:
                // --> KissButtonSearchBoxdialog
                DisplayQuestion_KissButtonSearchBoxDialog(questionArgs);
                return;
            }

            DisplayQuestion_InfoMessageBox(messageArgs);
        }

        #endregion

        #endregion
    }
}