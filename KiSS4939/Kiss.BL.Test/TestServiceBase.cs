using System;
using System.Linq;
using System.Threading;
using Kiss.BL.Cache;
using Kiss.BL.Test.Session;
using Kiss.Infrastructure.Constant;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Testing;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Model;
using log4net.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.BL.Test
{
    /// <summary>
    /// Base class for UnitTests. Contains the AssemblyInitilize and AssemblyCleanup methods.
    /// BIAG UnitTests definition: <seealso cref="\\chbes004.chbe01.local\Managementsystem\30_Leistungserbringung\36_Entwicklung\Checklisten u. Anleitungen\36_Richtlinien Testing_1.0.docx"/>
    /// </summary>
    public abstract class TestServiceBase
    {
        #region Fields

        #region Protected Constant/Read-Only Fields

        protected const string CREATOR = "UnitTester";

        #endregion

        #region Private Static Fields

        private static string _connectionString;
        private static bool _useDb;

        #endregion

        #endregion

        #region Properties

        /// <summary>
        /// The currently used connection string.
        /// </summary>
        internal static string ConnectionString
        {
            get { return _connectionString; }
        }

        /// <summary>
        /// Indicates whether the current test runs on a real DB.
        /// </summary>
        internal static bool UseDb
        {
            get { return _useDb; }
        }

        #endregion

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// ClassCleanup method.
        /// Closes the session in case of DB-tests
        /// </summary>
        public static void ClassCleanup()
        {
            if (_useDb)
            {
                var sessionService = Container.Resolve<ISessionService>();
                sessionService.Close();
            }
        }

        /// <summary>
        /// ClassInitialize method.
        /// Initializes the <see cref="Container"/> and open the session in case of DB-tests.
        /// The connectionString for DB-test is in the DbApp.config file defined.
        /// Choose the Database.testsettings run tests on DB.
        /// </summary>
        public static void ClassInitialize()
        {
            CacheManager.Instance.ClearCache();
            ClassInitialize(DatabaseTestUtil.CONNECTION_STRING_NAME, true);
        }

        /// <summary>
        /// ClassInitialize method.
        /// Initializes the <see cref="Container"/> and open the session in case of DB-tests.
        /// The connectionString for DB-test is in the DbApp.config file defined.
        /// Choose the Database.testsettings run tests on DB.
        /// </summary>
        public static void ClassInitialize(string connectionStringName)
        {
            ClassInitialize(connectionStringName, true);
        }

        /// <summary>
        /// ClassInitialize method.
        /// Initializes the <see cref="Container"/> and open the session in case of DB-tests.
        /// The connectionString for DB-test is in the DbApp.config file defined.
        /// Choose the Database.testsettings run tests on DB.
        /// </summary>
        public static void ClassInitialize(string connectionStringName, bool clearObjectContext)
        {
            // configure log4net
            XmlConfigurator.Configure();

            _connectionString = DatabaseTestUtil.GetConnectionString(connectionStringName);

            if (string.IsNullOrEmpty(_connectionString))
            {
                // use mock
                Console.WriteLine("Using mock implementation.");
                _useDb = false;
                Container.RegisterType<ISessionService, SessionServiceMock>();
            }
            else
            {
                // use DB
                Console.WriteLine("Using DB ({0}).", _connectionString);
                _useDb = true;
                Container.RegisterType<ISessionService, SessionService>();
            }

            var sessionService = Container.Resolve<ISessionService>();
            sessionService.Open(_connectionString, new AuthenticatedUser(), true, false);
            Thread.Sleep(100); // HACK: Has to be done because of the InitDBConnectionAsync in sessionService.Open()

            // Clear context (only for mock)
            if (clearObjectContext)
            {
                ClearObjectContext();
            }

            PopulateXLovTableMock();
        }

        public static void ClearObjectContext()
        {
            if (_useDb)
            {
                return;
            }

            var factoryMock = Container.Resolve<IUnitOfWorkFactory>() as UnitOfWorkFactoryMock;

            if (factoryMock != null)
            {
                factoryMock.ClearContext();
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Tests the creation of an entity in a service.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <typeparam name="TService">Thy type of the corresponding service.</typeparam>
        protected void ServiceCRUDCreateEntity<TEntity, TService>()
            where TEntity : class, IObjectWithChangeTracker
            where TService : class, IServiceCRUD<TEntity>, new()
        {
            IUnitOfWork unitOfWork = UnitOfWork.GetNew;

            // Initialize
            var repository = GetRepository<TEntity>(unitOfWork);
            int countInit = repository.GetQuery.Count();

            // Test
            var svc = new TService();

            TEntity testEntity1;
            TEntity testEntity2;

            var result1 = svc.NewData(out testEntity1);
            var result2 = svc.NewData(out testEntity2);

            Assert.IsTrue(result1 && result2);
            Assert.IsNotNull(testEntity1);
            Assert.IsNotNull(testEntity2);

            repository.ApplyChanges(testEntity1);
            repository.ApplyChanges(testEntity2);

            unitOfWork.SaveChanges();

            var query = repository.GetQuery;

            Assert.AreEqual(2, query.Count() - countInit);

            // Cleanup
            DeleteEntities(repository, testEntity1, testEntity2);
        }

        #endregion

        #region Private Static Methods

        private static void PopulateXLovTableMock()
        {
            var unitOfWork = UnitOfWork.GetNew;

            if (TestUtils.IsDbTest(unitOfWork))
            {
                return;
            }

            var lovType = typeof(LOVsGenerated);
            var enumTypes = lovType.GetNestedTypes();

            var repoXLov = UnitOfWork.GetRepository<XLOV>(unitOfWork);
            var repoXLovCode = UnitOfWork.GetRepository<XLOVCode>(unitOfWork);

            foreach (var enumType in enumTypes)
            {
                var lov = new XLOV
                {
                    LOVName = enumType.Name
                };

                repoXLov.ApplyChanges(lov);

                var names = enumType.GetEnumNames();
                var values = enumType.GetEnumValues();

                for (int i = 0; i < names.Length; i++)
                {
                    var lovCode = new XLOVCode
                    {
                        LOVName = enumType.Name,
                        Text = names[i],
                        Code = (int)values.GetValue(i)
                    };

                    repoXLovCode.ApplyChanges(lovCode);
                }
            }

            unitOfWork.SaveChanges();
        }

        #endregion

        #region Private Methods

        private void DeleteEntities<TEntity>(IRepository<TEntity> repository, params TEntity[] entities)
            where TEntity : class, IObjectWithChangeTracker
        {
            foreach (var entity in entities)
            {
                entity.MarkAsDeleted();

                repository.ApplyChanges(entity);
            }
        }

        private IRepository<TEntity> GetRepository<TEntity>(IUnitOfWork unitOfWork)
            where TEntity : class
        {
            IUnitOfWork uow = UnitOfWork.GetNewOrParent(unitOfWork);
            return UnitOfWork.GetRepository<TEntity>(uow);
        }

        #endregion

        #endregion
    }
}