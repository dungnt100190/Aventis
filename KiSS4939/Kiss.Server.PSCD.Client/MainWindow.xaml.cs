using System.ComponentModel;
using System.Configuration;
using System.Windows;

using Kiss.Interfaces.BL;

namespace Kiss.Server.PSCD.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BackgroundWorker _workerZahlungseingaengeAbholen;

        #endregion

        #region Private Fields

        private volatile string _dbName;
        private volatile string _endpointName;
        private volatile string _timestamp;

        #endregion

        #endregion

        #region Constructors

        public MainWindow()
        {
            InitializeComponent();

            _workerZahlungseingaengeAbholen = new BackgroundWorker();
            _workerZahlungseingaengeAbholen.DoWork += ZahlungseingaengeAbholen_DoWork;
            _workerZahlungseingaengeAbholen.RunWorkerCompleted += ZahlungseingaengeAbholen_Completed;

            UpdateGui(false);
        }

        #endregion

        #region EventHandlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Populate endpoint list
            foreach (ConnectionStringSettings item in ConfigurationManager.ConnectionStrings)
            {
                if (item.ConnectionString.StartsWith("http"))
                {
                    edtEndpoint.Items.Add(item.ConnectionString);
                }
            }

            edtEndpoint.SelectedIndex = 0;
        }

        private void ZahlungseingaengeAbholen_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            var result = (KissServiceResult)e.Result;

            if (result)
            {
                MessageBox.Show("Result ist OK. " + result);
            }
            else
            {
                MessageBox.Show(result.ToString());
            }

            UpdateGui(false);
        }

        private void ZahlungseingaengeAbholen_DoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = WebServiceProxy.SstZahlungseingaengeAbholen(_endpointName, _dbName, _timestamp);
        }

        private void btnZahlungseingaengeAbholen_Click(object sender, RoutedEventArgs e)
        {
            UpdateGui(true);
            _dbName = edtDbName.Text;
            _timestamp = edtTimestamp.Text;
            _endpointName = edtEndpoint.Text;
            _workerZahlungseingaengeAbholen.RunWorkerAsync();
        }

        #endregion

        #region Methods

        #region Private Methods

        private void UpdateGui(bool running)
        {
            grpZahlungseingaengeAbholen.IsEnabled = !running;
            pgbStatus.IsIndeterminate = running;
            pgbStatus.Visibility = running ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion

        #endregion
    }
}