using System.Windows;
using System.Windows.Threading;

namespace Kiss.Update
{
    public partial class MainWindow
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly string _updateDestination;
        private readonly string _mainFileName;
        private readonly string _updateSource;

        #endregion

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
            ViewModel.MessageRaised += ViewModel_MessageRaised;
        }

        public MainWindow(string updateSource, string updateDestination, string mainFileName)
            : this()
        {
            _updateSource = updateSource;
            _updateDestination = updateDestination;
            _mainFileName = mainFileName;
        }

        #endregion

        #region Properties

        private MainViewModel ViewModel
        {
            get { return (MainViewModel)DataContext; }
        }

        #endregion

        #region EventHandlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.CancelAsync();
        }

        private void ViewModel_MessageRaised(object sender, MessageEventArgs e)
        {
            Dispatcher.Invoke(() => e.Result = MessageBox.Show(this, e.Message, e.Title, e.Buttons));
        }

        private void ViewModel_ProcessCompleted(object sender, ProcessCompletedEventArgs e)
        {
            ViewModel.ProcessCompleted -= ViewModel_ProcessCompleted;

            if (e.Error != null)
            {
                MessageBox.Show(this, e.Error.Message, "Error");
            }

            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.ProcessCompleted += ViewModel_ProcessCompleted;
            ViewModel.RunAsync(_updateSource, _updateDestination, _mainFileName);
        }

        #endregion
    }
}