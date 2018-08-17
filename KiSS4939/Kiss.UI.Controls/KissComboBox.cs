using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using DevExpress.Xpf.Editors;
using Kiss.BL.KissSystem;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.Model;
using Kiss.UI.Controls.Helper;

using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UI.Controls
{
    public class KissComboBox : ComboBoxEdit, IKissEdit
    {
        public static readonly DependencyProperty IsAuthorizedProperty;
        public new static readonly DependencyProperty IsReadOnlyProperty;
        public static readonly DependencyProperty IsRequiredProperty;

        private ICollectionView _collectionView;

        static KissComboBox()
        {
            IsAuthorizedProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissComboBox>(x => x.IsAuthorized),
                    typeof(bool),
                    typeof(KissComboBox),
                    new UIPropertyMetadata(true, IsAuthorizedChanged));
            IsReadOnlyProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissComboBox>(x => x.IsReadOnly),
                    typeof(bool),
                    typeof(KissComboBox),
                    new UIPropertyMetadata(false, IsReadOnlyChanged));
            IsRequiredProperty =
                DependencyProperty.Register(
                    PropertyName.GetPropertyName<KissComboBox>(x => x.IsRequired),
                    typeof(bool),
                    typeof(KissComboBox),
                    new PropertyMetadata(false));

            //Binding-Mode: TwoWay, UpdateSourceTrigger: PropertyChanged
            var defaultMetadata = EditValueProperty.DefaultMetadata;
            var metadata = new FrameworkPropertyMetadata
            {
                CoerceValueCallback = defaultMetadata.CoerceValueCallback,
                PropertyChangedCallback = defaultMetadata.PropertyChangedCallback,
                DefaultValue = defaultMetadata.DefaultValue,
                DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                BindsTwoWayByDefault = true
            };
            EditValueProperty.OverrideMetadata(typeof(KissComboBox), metadata);

            DisplayMemberProperty.OverrideMetadata(typeof(KissComboBox), new FrameworkPropertyMetadata("Text"));
            ValueMemberProperty.OverrideMetadata(typeof(KissComboBox), new FrameworkPropertyMetadata("Code"));
        }

        public KissComboBox()
        {
            AllowNullInput = true;
            NullValue = 0;
            //Settings necessary for autofiltering inside of the Items-List
            AutoComplete = true;
            ValidateOnTextInput = true;

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

            //9382-001: SpinOnMouseWheel allowed ?
            var configService = Container.Resolve<XConfigService>();
            var sessionService = Container.Resolve<ISessionService>();
            AllowSpinOnMouseWheel = !sessionService.IsKiss5Mode && configService.GetConfigValue<bool>(@"System\GUI\InFeldernScrollen");

            AddHandler(MouseLeftButtonDownEvent, new MouseButtonEventHandler(KissComboBox_MouseLeftButtonDown), true);

            AddHandler(EditValueChangedEvent, new EditValueChangedEventHandler(KissComboBox_EditValueChanged), true);
        }

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

        public static void IsAuthorizedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissComboBox)d;
            instance.EnforceAuthorize();
        }

        public static void IsReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (KissComboBox)d;
            instance.EnforceAuthorize();
        }

        protected override ButtonInfoBase CreateNullValueButtonInfo()
        {
            var defaultButton = base.CreateNullValueButtonInfo() as ButtonInfo;
            if (defaultButton != null)
            {
                defaultButton.GlyphKind = GlyphKind.DropDown;
                defaultButton.ContentTemplate = (DataTemplate)FindResource("DropDownButtonTemplate");
            }

            return defaultButton;
        }

        protected override void ItemsSourceChanged(object itemsSource)
        {
            base.ItemsSourceChanged(itemsSource);

            var enumerable = itemsSource as IEnumerable;

            if (enumerable == null)
            {
                return;
            }

            //wrap the passed ItemsSource and assign the wrapper instead of the original ItemsSource
            var collectionView = enumerable as ICollectionView;
            if (collectionView == null)
            {
                collectionView = CollectionViewSource.GetDefaultView(itemsSource);

                foreach (var xLovCode in enumerable.OfType<XLOVCode>())
                {
                    xLovCode.PropertyChanged += (o, e) =>
                    {
                        if (e.PropertyName == PropertyName.GetPropertyName<XLOVCode>(x => x.IsActive))
                        {
                            ApplyIsActiveFilter();
                        }
                    };
                }

                _collectionView = collectionView;
                SetCurrentValue(ItemsSourceProperty, _collectionView);
            }
        }

        protected override void OnInitialized(EventArgs e)
        {
            // HACK: DevExpress beachtet Defaultwerte der Dependencyproperties nicht
            OnDisplayMemberChanged(DisplayMember);
            OnValueMemberChanged(ValueMember);
            base.OnInitialized(e);
        }

        private static void KissComboBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var comboBoxEdit = sender as ComboBoxEdit;
            if (comboBoxEdit != null)
            {
                comboBoxEdit.IsPopupOpen = true;
                (sender as TextEdit).SelectAll();
            }
        }

        private void ApplyIsActiveFilter()
        {
            if (_collectionView != null)
            {
                _collectionView.Filter = item =>
                                         {
                                             var xLovCode = item as XLOVCode;
                                             if (xLovCode == null)
                                             {
                                                 return true;
                                             }

                                             //only display active elements or the Null-element or the one representing the current EditValue
                                             return xLovCode.IsActive || xLovCode.Code == -1 || xLovCode.Code == (EditValue as int? ?? -1);
                                         };
            }
        }

        private void EnforceAuthorize()
        {
            // IsAuthorized ist stärker als IsEnabled
            base.IsReadOnly = !IsAuthorized || IsReadOnly;
        }

        private void KissComboBox_EditValueChanged(object sender, EditValueChangedEventArgs e)
        {
            ApplyIsActiveFilter();
        }
    }
}