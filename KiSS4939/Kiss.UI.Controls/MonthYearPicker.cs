using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    [TemplatePart(Name = ELEMENT_TEXT_BOX, Type = typeof(TextBox))]
    public class MonthYearPicker : DatePicker, IKissEdit
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty IsAuthorizedProperty;
        public static readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty IsRequiredProperty;
        public static readonly DependencyProperty MonthYearDateFormatProperty;
        public static readonly DependencyProperty SelectedMonthYearProperty;
        public static readonly DependencyProperty SpinButtonsVisibleProperty;

        public static new readonly DependencyProperty IsEnabledProperty;

        #endregion

        #region Private Constant/Read-Only Fields

        private const string ELEMENT_NEXT = "PART_Next";
        private const string ELEMENT_POPUP = "PART_Popup";
        private const string ELEMENT_PREVIOUS = "PART_Previous";
        private const string ELEMENT_TEXT_BOX = "PART_MonthYearTextBox";

        #endregion

        #endregion

        #region Constructors

        static MonthYearPicker()
        {
            IsAuthorizedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<MonthYearPicker>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(MonthYearPicker),
                    new UIPropertyMetadata(true, IsAuthorizedChanged));
            IsEnabledProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<MonthYearPicker>(x => x.IsEnabled),
                    typeof(bool),
                    typeof(MonthYearPicker),
                    new UIPropertyMetadata(true, IsEnabledChanged));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<MonthYearPicker>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(MonthYearPicker),
                    new UIPropertyMetadata(false, IsReadOnlyChanged));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<MonthYearPicker>(x => x.IsRequired),
                    typeof(bool),
                    typeof(MonthYearPicker),
                    new PropertyMetadata(false));
            MonthYearDateFormatProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<MonthYearPicker>(x => x.MonthYearDateFormat),
                    typeof(string),
                    typeof(MonthYearPicker),
                    new UIPropertyMetadata("MMM yyyy", MonthYearDateFormatChanged));
            SelectedMonthYearProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<MonthYearPicker>(x => x.SelectedMonthYear),
                    typeof(MonthYear?),
                    typeof(MonthYearPicker),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectedMonthYearChanged));
            SpinButtonsVisibleProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<MonthYearPicker>(x => x.SpinButtonsVisible),
                    typeof(bool),
                    typeof(MonthYearPicker));
        }

        public MonthYearPicker()
        {
            Loaded += MonthYearPicker_Loaded;

            var authorizedBinding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(RightHelper.MaskRightProperty),
                Mode = BindingMode.OneWay,
            };
            SetBinding(IsAuthorizedProperty, authorizedBinding);
        }

        #endregion

        #region Properties

        public bool IsAuthorized
        {
            get { return (bool)GetValue(IsAuthorizedProperty); }
            set { SetValue(IsAuthorizedProperty, value); }
        }

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
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

        // redirect to the textbox
        public new bool IsTabStop
        {
            get { return TextBox.IsTabStop; }
            set { TextBox.IsTabStop = value; }
        }

        /// <summary>
        /// This format is being used to display the selected date in the TextBox of the MonthYearPicker
        /// </summary>
        public string MonthYearDateFormat
        {
            get { return (string)GetValue(MonthYearDateFormatProperty); }
            set { SetValue(MonthYearDateFormatProperty, value); }
        }

        /// <summary>
        /// The selected MonthYear or NULL if no MonthYear is selected
        /// </summary>
        public MonthYear? SelectedMonthYear
        {
            get { return (MonthYear?)GetValue(SelectedMonthYearProperty); }
            set { SetValue(SelectedMonthYearProperty, value); }
        }

        public bool SpinButtonsVisible
        {
            get { return (bool)GetValue(SpinButtonsVisibleProperty); }
            set { SetValue(SpinButtonsVisibleProperty, value); }
        }

        private Calendar Calendar
        {
            get
            {
                var popup = Popup;

                if (popup == null || !(popup.Child is Calendar))
                {
                    return null;
                }

                return popup.Child as Calendar;
            }
        }

        private Popup Popup
        {
            get { return Template == null ? null : Template.FindName(ELEMENT_POPUP, this) as Popup; }
        }

        private TextBox TextBox
        {
            get { return Template == null ? null : Template.FindName(ELEMENT_TEXT_BOX, this) as TextBox; }
        }

        #endregion

        #region EventHandlers

        private void MonthYearPicker_Loaded(object sender, RoutedEventArgs e)
        {
            var calendar = Calendar;

            if (calendar == null)
            {
                return;
            }

            calendar.DisplayModeChanged -= calendar_DisplayModeChanged;
            calendar.DisplayModeChanged += calendar_DisplayModeChanged;

            calendar.SelectedDatesChanged -= calendar_SelectedDatesChanged;
            calendar.SelectedDatesChanged += calendar_SelectedDatesChanged;

            DisplaySelectedDate();

            TextBox.PreviewKeyDown -= TextBox_PreviewKeyDown;
            TextBox.PreviewKeyDown += TextBox_PreviewKeyDown;

            TextBox.SelectionChanged -= TextBox_SelectionChanged;
            TextBox.SelectionChanged += TextBox_SelectionChanged;

            base.IsTabStop = false;
        }

        private void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (!base.IsEnabled)
            {
                return;
            }
            if (e.Key == Key.Delete || e.Key == Key.Back)
            {
                SelectedMonthYear = null;
            }

            // set current month
            if (e.Key == Key.Space)
            {
                SelectedMonthYear = MonthYear.CurrentMonth;
            }

            // open calendar
            if (e.Key == Key.OemPeriod || e.Key == Key.F12)
            {
                IsDropDownOpen = true;
            }

            // next/previous Month
            if (e.Key == Key.Add)
            {
                SelectedMonthYear++;
            }
            else if (e.Key == Key.Subtract)
            {
                SelectedMonthYear--;
            }

            // allow tab-key to be pressed, otherwise catch keypress
            if (e.Key != Key.Tab)
            {
                e.Handled = true;
            }
        }

        private void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox.SelectionChanged -= TextBox_SelectionChanged;

            // TODO: Here we have a problem with this event - this happens so many times in Abzüge...
            TextBox.SelectAll();

            TextBox.SelectionChanged += TextBox_SelectionChanged;
        }

        private void calendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            if (e.NewMode != CalendarMode.Month)
            {
                return;
            }

            var calendar = Calendar;

            if (calendar != null)
            {
                SelectedDate = calendar.DisplayDate;
                IsDropDownOpen = false;
                TextBox.Focus();
            }
        }

        private void calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count != 1)
            {
                return;
            }

            var selectedDate = (DateTime)e.AddedItems[0];
            SelectedMonthYear = new MonthYear(selectedDate);

            // Display only month and year
            DisplaySelectedDate();
        }

        private void selectNextButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMonthYear.HasValue)
            {
                SelectedMonthYear++;
            }
        }

        private void selectPreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedMonthYear.HasValue)
            {
                SelectedMonthYear--;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            Button selectPreviousButton = null;
            Button selectNextButton = null;

            if (Template != null)
            {
                selectPreviousButton = Template.FindName(ELEMENT_PREVIOUS, this) as Button;
                selectNextButton = Template.FindName(ELEMENT_NEXT, this) as Button;
            }

            if (selectPreviousButton != null)
            {
                selectPreviousButton.Click -= selectPreviousButton_Click;
                selectPreviousButton.Click += selectPreviousButton_Click;
            }

            if (selectNextButton != null)
            {
                selectNextButton.Click -= selectNextButton_Click;
                selectNextButton.Click += selectNextButton_Click;
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnCalendarClosed(RoutedEventArgs e)
        {
            var calendar = Calendar;

            if (calendar != null)
            {
                calendar.DisplayMode = CalendarMode.Month;
            }

            base.OnCalendarClosed(e);
        }

        protected override void OnCalendarOpened(RoutedEventArgs e)
        {
            var calendar = Calendar;

            if (calendar != null)
            {
                calendar.DisplayMode = CalendarMode.Year;
            }

            base.OnCalendarOpened(e);
        }

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            // focus on the textbox
            TextBox.Focus();

            // disable tabstop
            IsTabStop = false;

            base.OnGotFocus(e);
        }

        #endregion

        #region Private Static Methods

        private static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (MonthYearPicker)d;
            instance.EnforceAuthorize();
        }

        private static new void IsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (MonthYearPicker)d;
            instance.EnforceAuthorize();
        }

        private static void IsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (MonthYearPicker)d;
            instance.EnforceAuthorize();
        }

        private static void MonthYearDateFormatChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (MonthYearPicker)d;
            instance.DisplaySelectedDate();
        }

        private static void SelectedMonthYearChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (MonthYearPicker)d;
            var newValue = (MonthYear?)e.NewValue;

            if (!newValue.HasValue)
            {
                instance.SelectedDate = null;
            }
            else
            {
                instance.SelectedDate = new DateTime(newValue.Value.Year, newValue.Value.Month, 1);
            }

            instance.DisplaySelectedDate();
        }

        #endregion

        #region Private Methods

        private void DisplaySelectedDate()
        {
            var textBox = TextBox;

            if (textBox == null)
            {
                return;
            }

            if (SelectedDate.HasValue)
            {
                textBox.Text = SelectedDate.Value.ToString(MonthYearDateFormat);
            }
            else
            {
                textBox.Text = string.Empty;
            }
        }

        private void EnforceAuthorize()
        {
            // IsAuthorized ist stärker als IsEnabled
            base.IsEnabled = IsAuthorized && IsEnabled && !IsReadOnly;
        }

        #endregion

        #endregion
    }
}