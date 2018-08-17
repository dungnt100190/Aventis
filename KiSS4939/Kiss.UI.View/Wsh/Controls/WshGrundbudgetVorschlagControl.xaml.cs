using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Kiss.UI.ViewModel.Wsh;


namespace Kiss.UI.View.Wsh.Controls
{
    /// <summary>
    /// Interaction logic for WshGrundbudgetVorschlagControl.xaml
    /// </summary>
    public partial class WshGrundbudgetVorschlagControl : UserControl
    {
        public WshGrundbudgetVorschlagControl()
        {
            InitializeComponent();
        }

        public void Init()
        {
            WshGrundbudgetVorschlagVM viewModel = (WshGrundbudgetVorschlagVM)DataContext;
        }

        private void OkCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            bool result = ((WshGrundbudgetVorschlagVM)DataContext).AllesSpeichern();
            if (result)
            {
                ViewHelper.CloseDialog(this, true);
            }
        }

    }
}
