using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.DTO;
using Kiss.Infrastructure;
using Kiss.Interfaces.UI;
using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UI.Controls
{
    /// <summary>
    /// Interaction logic for KissGotoFall.xaml
    /// </summary>
    public partial class KissGotoFall
    {
        public static readonly DependencyProperty BaPersonIdProperty;
        public static readonly DependencyProperty FaFallIdProperty;
        public static readonly DependencyProperty IsPiProperty;
        public static readonly DependencyProperty TreeExistsProperty;

        private XIconService _service;

        static KissGotoFall()
        {
            BaPersonIdProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissGotoFall>(x => x.BaPersonID), typeof(int?), typeof(KissGotoFall), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PropertyChanged));
            FaFallIdProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissGotoFall>(x => x.FaFallID), typeof(int?), typeof(KissGotoFall), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PropertyChanged));
            IsPiProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissGotoFall>(x => x.IsPi), typeof(bool), typeof(KissGotoFall), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PropertyChanged));
            TreeExistsProperty = DependencyProperty.Register(PropertyName.GetPropertyName<KissGotoFall>(x => x.TreeExists), typeof(bool), typeof(KissGotoFall), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PropertyChanged));
        }

        public KissGotoFall()
        {
            InitializeComponent();
        }

        public static bool DesignMode
        {
            get { return DesignerProperties.GetIsInDesignMode(new DependencyObject()); }
        }

        public int? BaPersonID
        {
            private get { return (int?)GetValue(BaPersonIdProperty); }
            set { SetValue(BaPersonIdProperty, value); }
        }

        public int? FaFallID
        {
            private get { return (int?)GetValue(FaFallIdProperty); }
            set { SetValue(FaFallIdProperty, value); }
        }

        public bool IsPi
        {
            private get { return (bool)GetValue(IsPiProperty); }
            set { SetValue(IsPiProperty, value); }
        }

        public List<ModulIconDTO> ModulIcons { get; private set; }

        public bool TreeExists
        {
            private get { return (bool)GetValue(TreeExistsProperty); }
            set { SetValue(TreeExistsProperty, value); }
        }

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((KissGotoFall)d).SetModulIcons();
        }

        private void Image_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var modul = ((System.Windows.Controls.Image)sender).DataContext as ModulIconDTO;
            ShowFall(modul);
        }

        private void kissGotoFall_Loaded(object sender, RoutedEventArgs e)
        {
            if (!DesignMode)
            {
                SetModulIcons();
            }
        }

        private void SetModulIcons()
        {
            if (!BaPersonID.HasValue || BaPersonID == 0)
            {
                return;
            }

            _service = Container.Resolve<XIconService>();
            ModulIcons = _service.GetModulIcons(BaPersonID.Value, FaFallID, TreeExists, IsPi);
            itemsControl.ItemsSource = ModulIcons;
        }

        private void ShowFall(ModulIconDTO modul)
        {
            if (!BaPersonID.HasValue || BaPersonID == 0)
            {
                return;
            }

            if (modul.Status == DbContext.Enums.Sys.XIconStatus.Leer)
            {
                return;
            }

            var formController = Container.Resolve<IKissFormController>();

            formController.OpenForm(
                "FrmFall",
                "Action",
                "ShowFall",
                "BaPersonID",
                BaPersonID,
                "FaFallID",
                FaFallID,
                "ModulID",
                modul.ModulID);
        }
    }
}