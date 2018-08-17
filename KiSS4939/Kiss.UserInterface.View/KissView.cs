using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using DevExpress.Xpf.Themes.Kiss;

using Kiss.BusinessLogic;
using Kiss.Infrastructure;
using Kiss.Interfaces;
using Kiss.Interfaces.ViewModel;
using Kiss.UI.Controls;
using Kiss.UI.Controls.Helper;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.Interfaces;

using Binding = System.Windows.Data.Binding;
using IViewModel = Kiss.UserInterface.ViewModel.Interfaces.IViewModel;
using IViewModelCRUD = Kiss.UserInterface.ViewModel.Interfaces.IViewModelCRUD;
using IViewModelList = Kiss.UserInterface.ViewModel.Interfaces.IViewModelList;
using IViewModelSearch = Kiss.UserInterface.ViewModel.Interfaces.IViewModelSearch;
using UserControl = System.Windows.Controls.UserControl;

namespace Kiss.UserInterface.View
{
    /// <summary>
    /// Base view for all KiSS WPF views
    /// </summary>
    public class KissView : UserControl, IViewWithViewModel
    {
        public static readonly DependencyProperty BindCommandsProperty;
        public static readonly DependencyProperty ValidationResultProperty;

        private IViewModel _viewModel;

        static KissView()
        {
            BindCommandsProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissView>(x => x.BindCommands),
                    typeof(bool),
                    typeof(KissView),
                    new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
            ValidationResultProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissView>(x => x.ValidationResult),
                    typeof(ServiceResult),
                    typeof(KissView),
                    new UIPropertyMetadata(ValidationResultChanged));

            DataContextProperty.OverrideMetadata(
                typeof(KissView), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        }

        protected KissView()
        {
            // set background to avoid black border while loading the view
            Background = FindResource(new KissBrushKeyExtension(KissBrushKeys.KissViewBackground)) as Brush;

            Loaded += KissView_Loaded;
            Unloaded += KissView_Unloaded;
            DataContextChanged += OnDataContextChanged;

            ResourceUtil.CreateStaticResourcesForDesigner(this);
            KissTheme.Enable(this);
        }

        /// <summary>
        /// Gets or sets a value whether common KiSS commands should be bound (New, Save, Delete...).
        /// </summary>
        public bool BindCommands
        {
            get { return (bool)GetValue(BindCommandsProperty); }
            set { SetValue(BindCommandsProperty, value); }
        }

        public ServiceResult ValidationResult
        {
            get { return (ServiceResult)GetValue(ValidationResultProperty); }
            set { SetValue(ValidationResultProperty, value); }
        }

        /// <summary>
        /// Gets the ViewModel
        /// </summary>
        public IViewModel ViewModel
        {
            get
            {
                return _viewModel ?? (_viewModel = GetViewModel());
            }
            set
            {
                _viewModel = value;
                DataContext = _viewModel;
                ViewModelHasChanged(_viewModel);
            }
        }

        public static void EndCurrentEdit()
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

            var focusedComplexControl = GetFocusedElement<KissComplexControl>();
            if (focusedComplexControl != null)
            {
                focusedComplexControl.EndCurrentEdit();
            }
        }

        public static void ValidationResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissView)d;
            var value = e.NewValue as ServiceResult;

            instance.HandleValidationResult(value);
        }

        // Obsolete, ToDo: remove when not needed anymore
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
        protected virtual void HandleValidationResult(ServiceResult result)
        {
            // nop
        }

        protected virtual void ViewModelHasChanged(IViewModel viewModel)
        {
            RegisterViewModelMessageRaised();
        }

        private static ICommand GetCommandByName(object dataContext, string commandToExecuteName)
        {
            if (dataContext != null && commandToExecuteName != null)
            {
                var propertyInfo = dataContext.GetType().GetProperty(commandToExecuteName);
                if (propertyInfo != null)
                {
                    return propertyInfo.GetValue(dataContext, null) as ICommand;
                }
            }

            return null;
        }

        private static T GetFocusedElement<T>()
                    where T : DependencyObject
        {
            return GetFocusedElement<T>(null);
        }

        private static T GetFocusedElement<T>(DependencyObject startElement)
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

        /// <summary>
        /// Since CommandBindings are not DependencyObjects, they cannot be bound in XAML to Commands in the ViewModel
        /// So we have to do this programmatically
        /// </summary>
        private void BindCommandsToCommandBindings()
        {
            foreach (var realBinding in CommandBindings.OfType<CommandBindingToCommand>())
            {
                if (realBinding.CommandToExecuteName != null)
                {
                    realBinding.CommandToExecute = GetCommandByName(DataContext, realBinding.CommandToExecuteName);
                }
            }
        }

        private void DisplayQuestion_InfoMessageBox(MessageRaisedEventArgs messageArgs)
        {
            Utilities.MessageBox.ShowInfoMessageBox(messageArgs.Message);
            messageArgs.Cancel = false;
        }

        private void DisplayQuestion_KissButtonSearchBoxDialog(QuestionRaisedEventArgs questionArgs)
        {
            var data = new List<object>(questionArgs.AvailableOptions);
            var columns = new List<GridColumnDefinition>
            {
                new GridColumnDefinition
                {
                    Fieldname = "Caption",
                    Title = questionArgs.Message,
                }
            };

            var dialog = new KissButtonSearchBoxDialog(data, columns);
            var result = dialog.ShowDialog();
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
            var result = Utilities.MessageBox.ShowQuestion(questionArgs.Message);
            questionArgs.Cancel = false; //At the moment, the legacy MessageBox we're using doesn't detect Cancel (it results in 'No').
            questionArgs.SelectedOption = questionArgs.AvailableOptions.Find(qao => (bool)qao.Tag == result);
        }

        private void KissView_Loaded(object sender, RoutedEventArgs e)
        {
            // init viewmodel
            var vm = ViewModel;

            // bind validationresult
            SetBinding(ValidationResultProperty, new Binding(PropertyName.GetPropertyName(() => ViewModel.ValidationResult)) { Source = ViewModel });

            // prepare messaging
            RegisterViewModelMessageRaised();

            // bind maskright
            var element = Content as FrameworkElement;
            if (element != null)
            {
                element.SetBinding(RightHelper.MaskRightProperty, PropertyName.GetPropertyName(() => ViewModel.HasMaskRight));
            }

            // bind commands
            if (BindCommands)
            {
                var searchVM = vm as IViewModelSearch;
                if (searchVM != null)
                {
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.Search, searchVM.SearchTask.StartCommand));
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.CancelSearch, searchVM.SearchTask.CancelCommand));
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.Refresh, searchVM.RefreshCommand));
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.Refresh, searchVM.ResetCommand));
                }

                var crudVM = vm as IViewModelCRUD;
                if (crudVM != null)
                {
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.CreateNewItem, crudVM.NewDataCommand));

                    var saveCommand = new MultiDelegateCommand();
                    saveCommand.RegisterCommand(new DelegateCommand(parameter => EndCurrentEdit()));
                    saveCommand.RegisterCommand(crudVM.SaveDataCommand);
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.SaveItem, saveCommand));
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.Refresh, crudVM.RefreshCommand));
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.DeleteItem, crudVM.DeleteDataCommand));
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.UndoChangesOnItem, crudVM.UndoDataChangesCommand));
                }

                var listVM = vm as IViewModelList;
                if (listVM != null)
                {
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.GoToFirstItem, listVM.GoToFirstItem));
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.GoToPreviousItem, listVM.GoToPreviousItem));
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.GoToNextItem, listVM.GoToNextItem));
                    CommandBindings.Add(new CommandBindingToCommand(KissCommands.GoToLastItem, listVM.GoToLastItem));
                }
            }
        }

        private void KissView_Unloaded(object sender, RoutedEventArgs e)
        {
            // init viewmodel
            var vm = ViewModel;

            // prepare messaging
            var mr = vm as IMessageRaiser;
            if (mr != null)
            {
                // remove any registered handlers first to prevent duplicate messages
                mr.MessageRaised -= MessageRaised;
            }
        }

        private void MessageRaised(object sender, MessageRaisedEventArgs messageArgs)
        {
            //Message or Question?
            var questionArgs = messageArgs as QuestionRaisedEventArgs;
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

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var viewModel = e.NewValue as IViewModel;

            if (viewModel != null && viewModel != _viewModel)
            {
                ViewModel = viewModel;
            }

            BindCommandsToCommandBindings();
        }

        private void RegisterViewModelMessageRaised()
        {
            var mr = ViewModel as IMessageRaiser;
            if (mr != null)
            {
                // remove any registered handlers first to prevent duplicate messages
                mr.MessageRaised -= MessageRaised;
                mr.MessageRaised += MessageRaised;
            }
        }
    }
}