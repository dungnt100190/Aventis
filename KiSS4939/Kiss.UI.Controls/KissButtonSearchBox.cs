using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    [TemplatePart(Name = PART_TXT_SEARCH, Type = typeof(KissTextEdit))]
    [TemplatePart(Name = PART_BTN_DELETE, Type = typeof(KissButton))]
    [TemplatePart(Name = PART_BTN_SEARCH, Type = typeof(KissButton))]
    [TemplatePart(Name = PART_BTN_SEARCH_FILTERED, Type = typeof(KissButton))]
    public class KissButtonSearchBox : KissComplexControl, IKissEdit
    {
        public static readonly DependencyProperty DisplayMemberPathProperty;
        public static readonly DependencyProperty IsAuthorizedProperty;
        public static readonly DependencyProperty IsButtonDeleteVisibleProperty;
        public static readonly DependencyProperty IsButtonPointVisibleProperty;
        public static readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty IsRequiredProperty;
        public static readonly DependencyProperty MinimalCharCountProperty;
        public static readonly DependencyProperty SearchColumnPathProperty;
        public static readonly DependencyProperty SearchMethodProperty;
        public static readonly DependencyProperty SearchParamProperty;
        public static readonly DependencyProperty SearchResultConverterProperty;
        public static readonly DependencyProperty SelectedItemProperty;
        public static readonly RoutedEvent ValueChangedEvent;
        public static readonly DependencyProperty ValueProperty;
        private const string PART_BTN_DELETE = "PART_BtnDelete";
        private const string PART_BTN_SEARCH = "PART_BtnSearch";
        private const string PART_BTN_SEARCH_FILTERED = "PART_BtnSearchFiltered";
        private const string PART_TXT_SEARCH = "PART_TxtSearch";
        private IList<object> _availableEntities;
        private KissButton _btnDelete;
        private KissButton _btnSearch;
        private KissButton _btnSearchFiltered;
        private bool _isInitialized;
        private KissTextEdit _txtSearch;

        static KissButtonSearchBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(KissButtonSearchBox), new FrameworkPropertyMetadata(typeof(KissButtonSearchBox)));

            DisplayMemberPathProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.DisplayMemberPath),
                    typeof(string),
                    typeof(KissButtonSearchBox),
                    new PropertyMetadata(DisplayMemberPathChanged));
            IsAuthorizedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(KissButtonSearchBox),
                    new UIPropertyMetadata(true, PropertyChanged_SetEditMode));
            IsButtonDeleteVisibleProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.IsButtonDeleteVisible),
                    typeof(bool),
                    typeof(KissButtonSearchBox),
                    new UIPropertyMetadata(false, PropertyChanged_SetEditMode));
            IsButtonPointVisibleProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.IsButtonPointVisible),
                    typeof(bool),
                    typeof(KissButtonSearchBox),
                    new UIPropertyMetadata(false, PropertyChanged_SetEditMode));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(KissButtonSearchBox),
                    new UIPropertyMetadata(false, PropertyChanged_SetEditMode));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.IsRequired),
                    typeof(bool),
                    typeof(KissButtonSearchBox),
                    new PropertyMetadata(false));
            MinimalCharCountProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.MinimalCharCount),
                    typeof(int),
                    typeof(KissButtonSearchBox));
            SearchColumnPathProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.SearchColumnPath),
                    typeof(List<GridColumnDefinition>),
                    typeof(KissButtonSearchBox));
            SearchMethodProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.SearchMethod),
                    typeof(SearchForStringEventHandler),
                    typeof(KissButtonSearchBox),
                    new UIPropertyMetadata(null));
            SearchParamProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.SearchParam),
                    typeof(string),
                    typeof(KissButtonSearchBox),
                    new UIPropertyMetadata(null));
            SearchResultConverterProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.SearchResultConverter),
                    typeof(SearchResultConverter),
                    typeof(KissButtonSearchBox),
                    new UIPropertyMetadata(null));
            SelectedItemProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.SelectedItem),
                    typeof(object),
                    typeof(KissButtonSearchBox),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

            // RoutedEvent for value changed.
            // RoutingStrategy: Bubble
            ValueChangedEvent =
                EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(KissButtonSearchBox));
            ValueProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissButtonSearchBox>(x => x.Value),
                    typeof(string),
                    typeof(KissButtonSearchBox),
                    new UIPropertyMetadata(ValuePropertyChangedCallback),
                    ValidateValueCallback);
        }

        public KissButtonSearchBox()
        {
            ResourceUtil.CreateStaticResourcesForDesigner(this);

            SearchColumnPath = new List<GridColumnDefinition>();
            Focusable = true;
            IsTabStop = true;

            var authorizedBinding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(RightHelper.MaskRightProperty),
                Mode = BindingMode.OneWay,
            };
            SetBinding(IsAuthorizedProperty, authorizedBinding);
        }

        /// <summary>
        /// This event is triggered when the value changed.
        /// RoutingStrategy: Bubble.
        /// </summary>
        public event RoutedEventHandler ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }

        /// <summary>
        /// Gets or sets a path to a value on the source object to serve as the visual representation of the object
        /// </summary>
        public string DisplayMemberPath
        {
            get { return (string)GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        public bool IsAuthorized
        {
            get { return (bool)GetValue(IsAuthorizedProperty); }
            set { SetValue(IsAuthorizedProperty, value); }
        }

        /// <summary>
        /// Gets or sets the visibility of the delete button
        /// </summary>
        public bool IsButtonDeleteVisible
        {
            get { return (bool)GetValue(IsButtonDeleteVisibleProperty); }
            set { SetValue(IsButtonDeleteVisibleProperty, value); }
        }

        /// <summary>
        /// Gets or sets the visibility of the special filter button
        /// </summary>
        public bool IsButtonPointVisible
        {
            get { return (bool)GetValue(IsButtonPointVisibleProperty); }
            set { SetValue(IsButtonPointVisibleProperty, value); }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the control is readonly.
        /// </summary>
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

        /// <summary>
        /// Gets or sets a path to the count of characters in the textbox needed for search
        /// </summary>
        public int MinimalCharCount
        {
            get { return (int)GetValue(MinimalCharCountProperty); }
            set { SetValue(MinimalCharCountProperty, value); }
        }

        /// <summary>
        /// Gets or sets a path to a value on the source object to serve as the visual representation of the object
        /// </summary>
        public List<GridColumnDefinition> SearchColumnPath
        {
            get { return (List<GridColumnDefinition>)GetValue(SearchColumnPathProperty); }
            set { SetValue(SearchColumnPathProperty, value); }
        }

        public SearchForStringEventHandler SearchMethod
        {
            get { return (SearchForStringEventHandler)GetValue(SearchMethodProperty); }
            set { SetValue(SearchMethodProperty, value); }
        }

        public object SearchParam
        {
            get { return (GetValue(SearchParamProperty)); }
            set { SetValue(SearchParamProperty, value); }
        }

        public SearchResultConverter SearchResultConverter
        {
            get { return (SearchResultConverter)GetValue(SearchResultConverterProperty); }
            set { SetValue(SearchResultConverterProperty, value); }
        }

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set
            {
                if (SelectedItem != null && SelectedItem.Equals(value))
                {
                    ResetDisplayValue();
                }

                SetValue(SelectedItemProperty, value);
            }
        }

        public string Value
        {
            get { return GetValue(ValueProperty) as string; }
            set { SetValue(ValueProperty, value); }
        }

        public static void PropertyChanged_SetEditMode(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissButtonSearchBox)d;
            instance.SetEditMode();
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            _txtSearch = EnforceInstance<KissTextEdit>(PART_TXT_SEARCH);
            _btnDelete = EnforceInstance<KissButton>(PART_BTN_DELETE);
            _btnSearch = EnforceInstance<KissButton>(PART_BTN_SEARCH);
            _btnSearchFiltered = EnforceInstance<KissButton>(PART_BTN_SEARCH_FILTERED);

            _txtSearch.LostFocus += txtSearch_LostFocus;
            _txtSearch.PreviewKeyDown += txtSearch_PreviewKeyDown;
            _txtSearch.TextChanged += txtSearch_TextChanged;

            BindingOperations.ClearBinding(_txtSearch, KissTextEdit.IsAuthorizedProperty);
            var binding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(IsAuthorizedProperty),
                Mode = BindingMode.OneWay
            };
            SetBinding(KissTextEdit.IsAuthorizedProperty, binding);

            _btnDelete.Click += _btnDelete_Click;
            _btnSearch.Click += _btnSearch_Click;
            _btnSearchFiltered.Click += _btnSearchFiltered_Click;

            _isInitialized = true;

            UpdateDisplayMemberBinding();
            SetEditMode();
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            base.OnGotFocus(e);
            _txtSearch.Focus();
        }

        /// <summary>
        /// Called whenever the value of property "ValueProperty" changed.
        /// </summary>
        protected virtual void OnValueChanged()
        {
            var args = new RoutedEventArgs { RoutedEvent = ValueChangedEvent };
            RaiseEvent(args);
        }

        private static void DisplayMemberPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissButtonSearchBox)d;

            if (!instance._isInitialized)
            {
                return;
            }

            instance.UpdateDisplayMemberBinding();
        }

        /// <summary>
        /// Validates the value of property "Value".
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool ValidateValueCallback(object value)
        {
            return true;
        }

        /// <summary>
        /// Is called whenever the dependency property "ValueProperty" changes.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void ValuePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var kissButtonSearchBox = (KissButtonSearchBox)d;
            kissButtonSearchBox.OnValueChanged();
        }

        /// <summary>
        /// Click event of button for delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (IsEnabled && _btnDelete.IsEnabled)
            {
                SelectedItem = null;
            }
        }

        /// <summary>
        /// Click event of button for normal search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnSearch_Click(object sender, RoutedEventArgs e)
        {
            if (_txtSearch.Text == string.Empty)
            {
                DoSearch("*");
            }
            else
            {
                DoSearch(_txtSearch.Text);
            }
        }

        /// <summary>
        /// Click event of button for special search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void _btnSearchFiltered_Click(object sender, RoutedEventArgs e)
        {
            DoSearch(".");
        }

        private object ConvertSearchResult(object availableEntity)
        {
            if (SearchResultConverter == null)
            {
                return availableEntity;
            }

            return SearchResultConverter(availableEntity);
        }

        /// <summary>
        /// Executes the search for entered text
        /// </summary>
        /// <param name="searchText"></param>
        private bool DoSearch(string searchText)
        {
            if (SearchMethod == null)
            {
                // SearchMethod is not defined, so do nothing
                Utilities.MessageBox.ShowInfoMessageBox(Properties.Resources.SearchMethodIsNull);
                return false;
            }

            if (string.IsNullOrEmpty(searchText))
            {
                //serach-text is empty, clear the selected item
                SelectedItem = null;
                return true;
            }

            if (searchText.Length < MinimalCharCount && searchText != "." && searchText != "*" && searchText != "%")
            {
                Utilities.MessageBox.ShowInfoMessageBox(string.Format(Properties.Resources.SuchbegriffZuKurz, MinimalCharCount));
                return false;
            }

            searchText = searchText.Replace('?', '*');
            searchText = searchText.Replace('%', '*');
            _availableEntities = SearchMethod(searchText, SearchParam);

            if (_availableEntities.Count == 0)
            {
                Utilities.MessageBox.ShowInfoMessageBox(Properties.Resources.KeineDatenGefunden);
                return false;
            }

            if (_availableEntities.Count == 1)
            {
                SelectedItem = ConvertSearchResult(_availableEntities[0]);
                return true;
            }

            var dlg = new KissButtonSearchBoxDialog(_availableEntities, SearchColumnPath);

            var result = dlg.ShowDialog();
            if (result.HasValue && result.Value)
            {
                SelectedItem = ConvertSearchResult(dlg.SelectedItem);
                dlg.Close();
                return true;
            }

            ResetDisplayValue();
            dlg.Close();
            return false;
        }

        private bool DoSearchFromKeyEvent()
        {
            var doSearch = (SelectedItem == null);
            if (!doSearch)
            {
                var displayValue = GetDisplayValue();
                doSearch = displayValue == null || _txtSearch.Text != displayValue.ToString();
            }

            if (doSearch)
            {
                return DoSearch(_txtSearch.Text);
            }

            return false;
        }

        private object GetDisplayValue()
        {
            if (SelectedItem != null)
            {
                var propertyPath = DisplayMemberPath ?? "";
                return PropertyValue.GetPropertyValue(SelectedItem, propertyPath);
            }

            return null;
        }

        private void ResetDisplayValue()
        {
            if (_txtSearch == null)
            {
                return;
            }

            var expression = _txtSearch.GetBindingExpression(TextBox.TextProperty);
            if (expression != null)
            {
                expression.UpdateTarget();
            }
            else
            {
                _txtSearch.Text = string.Empty;
            }
        }

        private bool SearchIfValueChanged()
        {
            // Only search if the value has changed
            object dVal = GetDisplayValue();
            var dStr = dVal != null ? dVal.ToString() : string.Empty;
            if (_txtSearch.Text != dStr)
            {
                return !DoSearchFromKeyEvent();
            }

            return false;
        }

        private void SetEditMode()
        {
            if (!_isInitialized)
            {
                return;
            }

            // IsAuthorized ist stärker als IsReadOnly
            var isReadOnly = !IsAuthorized || IsReadOnly;
            _btnSearch.Visibility = isReadOnly ? Visibility.Collapsed : Visibility.Visible;
            _btnDelete.Visibility = isReadOnly || !IsButtonDeleteVisible ? Visibility.Collapsed : Visibility.Visible;
            _btnSearchFiltered.Visibility = isReadOnly || !IsButtonPointVisible ? Visibility.Collapsed : Visibility.Visible;
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            SearchIfValueChanged();
        }

        private void txtSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                ResetDisplayValue();
                e.Handled = true;
            }
            else if (e.Key == Key.Tab)
            {
                e.Handled = SearchIfValueChanged();
            }
            else if (e.Key == Key.Down || e.Key == Key.Enter)
            {
                if (SearchIfValueChanged())
                {
                    return;
                }

                var tr = new TraversalRequest(FocusNavigationDirection.Next);
                MoveFocus(tr);
            }
            else if (e.Key == Key.Up)
            {
                if (SearchIfValueChanged())
                {
                    return;
                }

                var tr = new TraversalRequest(FocusNavigationDirection.Previous);
                MoveFocus(tr);
            }
        }

        /// <summary>
        /// Event TextChanged used for enabling or disabling the search buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            _btnSearch.IsEnabled = IsEnabled && (_txtSearch.Text.Length >= MinimalCharCount || _txtSearch.Text == "." || _txtSearch.Text == "*" || _txtSearch.Text == "?");
            _btnSearchFiltered.IsEnabled = IsEnabled;
        }

        private void UpdateDisplayMemberBinding()
        {
            var textBinding = new Binding
            {
                Path = new PropertyPath(DisplayMemberPath),
                Mode = BindingMode.OneWay,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            _txtSearch.SetBinding(TextBox.TextProperty, textBinding);
        }
    }
}