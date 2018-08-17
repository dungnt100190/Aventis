using System;
using System.Windows;
using System.Windows.Data;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for DateRange.xaml
    /// </summary>
    public partial class DateRange : IKissEdit
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty DateFromProperty;
        public static readonly DependencyProperty DateToProperty;
        public static readonly DependencyProperty IsAuthorizedProperty;
        public static readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty IsRequiredProperty;

        #endregion

        #endregion

        #region Constructors

        static DateRange()
        {
            DateFromProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<DateRange>(x => x.DateFrom),
                    typeof(DateTime?),
                    typeof(DateRange),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, DateFromChanged));
            DateToProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<DateRange>(x => x.DateTo),
                    typeof(DateTime?),
                    typeof(DateRange),
                    new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, DateToChanged));
            IsAuthorizedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<DateRange>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(DateRange),
                    new UIPropertyMetadata(true));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<DateRange>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(DateRange),
                    new UIPropertyMetadata(false));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<DateRange>(x => x.IsRequired),
                    typeof(bool),
                    typeof(DateRange),
                    new PropertyMetadata(false));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateRange"/> class.
        /// </summary>
        public DateRange()
        {
            InitializeComponent();

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

        /// <summary>
        /// Gets and sets the from-date of the date range
        /// </summary>
        public DateTime? DateFrom
        {
            get { return GetValue(DateFromProperty) as DateTime?; }
            set { SetValue(DateFromProperty, value); }
        }

        /// <summary>
        /// Gets and sets the to-date of the date range
        /// </summary>
        public DateTime? DateTo
        {
            get { return GetValue(DateToProperty) as DateTime?; }
            set { SetValue(DateToProperty, value); }
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

        private static DateTime FirstDayOfMonth
        {
            get { return new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); }
        }

        private static DateTime FirstDayOfYear
        {
            get { return new DateTime(DateTime.Today.Year, 1, 1); }
        }

        private static DateTime LastDayOfMonth
        {
            get { return GetLastDayOfMonth(DateTime.Today); }
        }

        private static DateTime LastDayOfYear
        {
            get { return new DateTime(DateTime.Today.Year, 12, 31); }
        }

        #endregion

        #region EventHandlers

        private void mnuCurrentMonth_Click(object sender, RoutedEventArgs e)
        {
            DateFrom = FirstDayOfMonth;
            DateTo = LastDayOfMonth;
        }

        private void mnuCurrentYear_Click(object sender, RoutedEventArgs e)
        {
            DateFrom = FirstDayOfYear;
            DateTo = LastDayOfYear;
        }

        private void mnuFirstDayOfMonth_Click(object sender, RoutedEventArgs e)
        {
var firstDayOfMonth = FirstDayOfMonth;
            DateFrom = firstDayOfMonth;
            DateTo = firstDayOfMonth;
        }

        private void mnuLastMonth_Click(object sender, RoutedEventArgs e)
        {
            var lastMonthFirstDay = FirstDayOfMonth.AddMonths(-1);
            DateFrom = lastMonthFirstDay;
            DateTo = GetLastDayOfMonth(lastMonthFirstDay);
        }

        private void mnuNextMonth_Click(object sender, RoutedEventArgs e)
        {
            var nextMonthFirstDay = FirstDayOfMonth.AddMonths(1);
            DateFrom = nextMonthFirstDay;
            DateTo = GetLastDayOfMonth(nextMonthFirstDay);
        }

        private void mnuToday_Click(object sender, RoutedEventArgs e)
        {
            var today = DateTime.Now.Date;
            DateFrom = today;
            DateTo = today;
        }

        private void mnuTomorrow_Click(object sender, RoutedEventArgs e)
        {
            var tomorrow = DateTime.Now.Date.AddDays(1);
            DateFrom = tomorrow;
            DateTo = tomorrow;
        }

        private void panPopUp_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (!Enabled() || IsReadOnly || !IsAuthorized)
            {
                return;
            }

            PopUpMenu.PlacementTarget = this;
            PopUpMenu.IsOpen = true;
        }

        #endregion

        #region Methods

        #region Private Static Methods

        private static void DateFromChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (DateRange)d;
            var newValue = e.NewValue as DateTime?;
        }

        private static void DateToChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (DateRange)d;
            var newValue = e.NewValue as DateTime?;
        }

        private static DateTime GetLastDayOfMonth(DateTime anyDayInMonth)
        {
            return new DateTime(anyDayInMonth.Year, anyDayInMonth.Month, DateTime.DaysInMonth(anyDayInMonth.Year, anyDayInMonth.Month));
        }

        #endregion

        #region Private Methods

        private bool Enabled()
        {
            return (edtDateFrom.IsEnabled && edtDateTo.IsEnabled);
        }

        #endregion

        #endregion
    }
}