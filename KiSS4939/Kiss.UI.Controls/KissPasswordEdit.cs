using System.Windows;
using System.Windows.Data;

using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

using DevExpress.Xpf.Editors;

namespace Kiss.UI.Controls
{
    public class KissPasswordEdit : PasswordBoxEdit, IKissEdit
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty IsAuthorizedProperty;
        public static readonly DependencyProperty IsRequiredProperty;

        public static new readonly DependencyProperty IsReadOnlyProperty;

        #endregion

        #endregion

        #region Constructors

        static KissPasswordEdit()
        {
            IsAuthorizedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPasswordEdit>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(KissPasswordEdit),
                    new UIPropertyMetadata(true, IsAuthorizedChanged));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPasswordEdit>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(KissPasswordEdit),
                    new UIPropertyMetadata(false, IsReadOnlyChanged));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissPasswordEdit>(x => x.IsRequired),
                    typeof(bool),
                    typeof(KissPasswordEdit),
                    new PropertyMetadata(false));

            DefaultStyleKeyProperty.OverrideMetadata(typeof(KissPasswordEdit), new FrameworkPropertyMetadata(typeof(PasswordBoxEdit)));
        }

        public KissPasswordEdit()
        {
            IsAuthorized = true;
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

        public new bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        public static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissPasswordEdit)d;
            instance.EnforceAuthorize();
        }

        public static void IsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissPasswordEdit)d;
            instance.EnforceAuthorize();
        }

        #endregion

        #region Private Methods

        private void EnforceAuthorize()
        {
            // IsAuthorized ist stärker als IsReadOnly
            base.IsReadOnly = !IsAuthorized || IsReadOnly;
        }

        #endregion

        #endregion
    }
}