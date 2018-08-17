using System.Windows;

using Kiss.Interfaces.BL;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for ValidationSummary.xaml
    /// </summary>
    public partial class ValidationSummary
    {
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        /// <summary>
        /// Dependency property ServiceResult.
        /// </summary>
        public static readonly DependencyProperty ServiceResultProperty =
            DependencyProperty.Register(
                "ServiceResult",
                typeof(IServiceResult),
                typeof(ValidationSummary),
                new UIPropertyMetadata(PropertyChangedCallback),
                ValidateValueCallback);

        public ValidationSummary()
        {
            ResourceUtil.CreateStaticResourcesForDesigner(this);

            InitializeComponent();
        }

        /// <summary>
        /// CLR Version of the ServiceResult property.
        /// </summary>
        public IServiceResult ServiceResult
        {
            get
            {
                return GetValue(ServiceResultProperty) as IServiceResult;
            }
            set
            {
                SetValue(ServiceResultProperty, value);
            }
        }

        /// <summary>
        /// Is called whenever the dependency property "ServiceResult" changes.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var summary = (ValidationSummary)d;
            var val = e.NewValue as IServiceResult;

            if (val != null && val.IsOk)
            {
                summary.Visibility = Visibility.Collapsed;
            }
            else
            {
                summary.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Validates the value of property "Value".
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ValidateValueCallback(object value)
        {
            return true;
        }

        private void MniCopyDetails_Click(object sender, RoutedEventArgs e)
        {
            if (ServiceResult != null)
            {
                Clipboard.SetText(ServiceResult.GetTechnicalDetails());
            }
        }
    }
}