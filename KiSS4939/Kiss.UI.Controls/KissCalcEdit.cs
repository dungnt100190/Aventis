using System.Windows;
using System.Windows.Data;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.EditStrategy;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

namespace Kiss.UI.Controls
{
    public class KissCalcEdit : PopupCalcEdit, IKissEdit
    {
        #region Fields

        #region Public Static Fields

        public static readonly DependencyProperty IsAuthorizedProperty;
        public static new readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty IsRequiredProperty;

        #endregion

        #endregion

        #region Constructors

        static KissCalcEdit()
        {
            IsAuthorizedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCalcEdit>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(KissCalcEdit),
                    new UIPropertyMetadata(true, IsAuthorizedChanged));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCalcEdit>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(KissCalcEdit),
                    new UIPropertyMetadata(false, IsReadOnlyChanged));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissCalcEdit>(x => x.IsRequired),
                    typeof(bool),
                    typeof(KissCalcEdit),
                    new PropertyMetadata(false));
        }

        public KissCalcEdit()
        {
            AllowDefaultButton = false;

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

        #region Protected Methods

        protected override EditStrategyBase CreateEditStrategy()
        {
            return new KissCalcEditStrategy(this);
        }

        #endregion

        #region Private Static Methods

        private static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissCalcEdit)d;
            instance.EnforceAuthorize();
        }

        private static void IsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissCalcEdit)d;
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

    public class KissCalcEditStrategy : CalcEditStrategy
    {
        #region Constructors

        public KissCalcEditStrategy(PopupCalcEdit editor)
            : base(editor)
        {
        }

        #endregion

        #region Properties

        protected override bool AllowSpin
        {
            get
            {
                //Mantis #6748 - Betragsfelder sollen nicht mit Scrollen verändert werden
                return false;
            }
        }

        #endregion
    }
}