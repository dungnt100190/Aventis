using System.Windows;

namespace Kiss.Spielwiese
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        #region EventHandlers

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            InitContainer();
        }

        #endregion

        #region Methods

        #region Private Methods

        private void InitContainer()
        {
            /*
            var sessionEntry = new IoCEntry
            {
                LookupTypeNamespace = "Kiss.Interfaces.BL",
                LookupTypeName = "ISessionService",
                LookupTypeAssemblyName = "Kiss.Interfaces",
                ConcreteTypeNamespace = "Kiss.BL",
                ConcreteTypeName = "SessionService",
                ConcreteTypeAssemblyName = "Kiss.BL",
            };

            Container.RegisterEntry(sessionEntry);

            // use mock
            Container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactoryMock>();
            Container.RegisterType(typeof(IRepository<>), typeof(RepositoryMock<>));

            // We tell the concrete factory what EF model we want to use
            UnitOfWorkFactoryMock.SetObjectContext(() => new ObjectContextMock());
            */
        }

        #endregion

        #endregion
    }
}