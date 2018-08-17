using System.Windows.Threading;
using Kiss.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.DocumentHandling;
using KiSS4.DB;
using KiSS4.Dokument.ExcelAutomation;
using KiSS4.Dokument.WordAutomation;

namespace KiSS4.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region Constructors

        public App()
        {
            InitializeComponent();

            InitializeIoCContainer();
        }

        #endregion

        #region EventHandlers

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            if (e.Exception == null)
            {
                return;
            }

            if (e.Exception is KissInfoException)
            {
                ((KissInfoException)e.Exception).ShowMessage();
            }
            else if (!(e.Exception is KissCancelException))
            {
                KissMsg.ShowError(e.Exception.Message, e.Exception);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void InitializeIoCContainer()
        {
            Container.RegisterInheritingTypes<ServiceBase>();

            Container.RegisterType<IWordControl, WordControl>(InstanceScope.PerResolve);
            Container.RegisterType<IExcelControl, ExcelControl>(InstanceScope.PerResolve);

            //test:
            //var x = Container.Resolve<BaAdresseService>();
        }

        #endregion

        #endregion
    }
}