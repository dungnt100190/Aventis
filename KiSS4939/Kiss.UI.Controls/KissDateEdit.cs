using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Editors.Themes;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.UI.Controls.Helper;

using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UI.Controls
{
    public class KissDateEdit : DateEdit, IKissEdit
    {
        public static readonly DependencyProperty IsAuthorizedProperty;
        public new static readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty IsRequiredProperty;

        private bool _isInEnforceAuthorize;

        static KissDateEdit()
        {
            IsAuthorizedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissDateEdit>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(KissDateEdit),
                    new UIPropertyMetadata(true, IsAuthorizedChanged));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissDateEdit>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(KissDateEdit),
                    new UIPropertyMetadata(false, IsReadOnlyChanged));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissDateEdit>(x => x.IsRequired),
                    typeof(bool),
                    typeof(KissDateEdit),
                    new PropertyMetadata(false));

            var defaultMetadata = EditValueProperty.DefaultMetadata;
            var metadata = new FrameworkPropertyMetadata
            {
                CoerceValueCallback = defaultMetadata.CoerceValueCallback,
                PropertyChangedCallback = defaultMetadata.PropertyChangedCallback,
                DefaultValue = defaultMetadata.DefaultValue,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                BindsTwoWayByDefault = true
            };
            EditValueProperty.OverrideMetadata(typeof(KissDateEdit), metadata);
        }

        public KissDateEdit()
        {
            var glyphTemplate = (DataTemplate)FindResource("CalendarButtonTemplate");
            Resources.Add(new ButtonsThemeKeyExtension { ResourceKey = ButtonsThemeKeys.DropDownGlyph, ThemeName = "Kiss" }, glyphTemplate);

            DependencyPropertyDescriptor.FromProperty(BaseEdit.IsReadOnlyProperty, typeof(BaseEdit)).AddValueChanged(this, BaseIsReadOnlyChanged);

            if (DesignerProperties.GetIsInDesignMode(this))
            {
                return;
            }

            var authorizedBinding = new Binding
            {
                RelativeSource = RelativeSource.Self,
                Path = new PropertyPath(RightHelper.MaskRightProperty),
                Mode = BindingMode.OneWay,
            };
            SetBinding(IsAuthorizedProperty, authorizedBinding);

            // 9382-001: SpinOnMouseWheel allowed ?
            var configService = Container.Resolve<XConfigService>();
            var sessionService = Container.Resolve<ISessionService>();
            AllowSpinOnMouseWheel = !sessionService.IsKiss5Mode && configService.GetConfigValue<bool>(@"System\GUI\InFeldernScrollen");
        }

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

        protected override EditStrategyBase CreateEditStrategy()
        {
            return new KissDateEditStrategy(this);
        }

        protected override void OnLostKeyboardFocus(KeyboardFocusChangedEventArgs e)
        {
            base.OnLostKeyboardFocus(e);
            //make sure, the binding is updated with the currently edited value
            DoValidate();
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            if (base.IsReadOnly)
            {
                base.OnPreviewKeyDown(e);
                return;
            }

            // Taste        Normal      Shift         Control
            // ---------------------------------------------------
            // +            + 1 Tag     + 1 Monat     + 1 Jahr
            // -            - 1 Tag     - 1 Monat     - 1 Jahr
            // space        heute       Jahresende    Jahresanfang

            // to prevent ArgumentOutOfRangeException
            if (e.Key == Key.Subtract && DateTime == DateTime.MinValue)
            {
                DateTime = DateTime.Today;
            }

            if (!KeyboardUtil.IsModifierKeyPressed())
            {
                switch (e.Key)
                {
                    case Key.Add:
                        DateTime = DateTime.AddDays(1);
                        e.Handled = true;
                        break;

                    case Key.Subtract:
                        DateTime = DateTime.AddDays(-1);
                        e.Handled = true;
                        break;

                    case Key.Space:
                        DateTime = DateTime.Today;
                        e.Handled = true;
                        break;
                }
            }
            else if (KeyboardUtil.IsAnyShiftKeyPressed())
            {
                switch (e.Key)
                {
                    case Key.Add:
                        DateTime = DateTime.AddMonths(1);
                        e.Handled = true;
                        break;

                    case Key.Subtract:
                        DateTime = DateTime.AddMonths(-1);
                        e.Handled = true;
                        break;

                    case Key.Space:
                        DateTime = new DateTime(DateTime.Today.Year, 12, 31);
                        e.Handled = true;
                        break;
                }
            }
            else if (KeyboardUtil.IsAnyControlKeyPressed())
            {
                switch (e.Key)
                {
                    case Key.Add:
                        DateTime = DateTime.AddYears(1);
                        e.Handled = true;
                        break;

                    case Key.Subtract:
                        DateTime = DateTime.AddYears(-1);
                        e.Handled = true;
                        break;

                    case Key.Space:
                        DateTime = new DateTime(DateTime.Today.Year, 1, 1);
                        e.Handled = true;
                        break;
                }
            }

            //open/close popup with F12
            if (!KeyboardUtil.IsModifierKeyPressed() && e.Key == Key.F12)
            {
                if (IsPopupOpen)
                {
                    ClosePopup();
                }
                else
                {
                    ShowPopup();
                }

                e.Handled = true;
            }

            base.OnPreviewKeyDown(e);
        }

        private static void BaseIsReadOnlyChanged(object sender, EventArgs e)
        {
            var instance = (KissDateEdit)sender;

            if (!instance._isInEnforceAuthorize)
            {
                instance.IsReadOnly = ((BaseEdit)sender).IsReadOnly;
            }
        }

        private static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissDateEdit)d;
            instance.EnforceAuthorize();
        }

        private static void IsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissDateEdit)d;
            instance.EnforceAuthorize();
        }

        private void EnforceAuthorize()
        {
            _isInEnforceAuthorize = true;
            // IsAuthorized ist stärker als IsReadOnly
            base.IsReadOnly = !IsAuthorized || IsReadOnly;
            _isInEnforceAuthorize = false;
        }
    }

    public class KissDateEditStrategy : DateEditStrategy
    {
        public KissDateEditStrategy(DateEdit editor)
            : base(editor)
        {
        }
    }
}