using System.Data.EntityClient;
using System.Data.SqlClient;

using KiSS.Common.DA;
using KiSS.Common.IoC;
using KiSS.Lookup.DA;

using Autofac;
using Autofac.Builder;

namespace KiSS.Lookup.BL
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>each BL requires a Bootstrapper</remarks>
    /// <exception cref="" ></exception>
    public class LookupModule : Module, IDBModule
    {
        #region Properties

        /// <summary>
        /// Flag indicating if a the default constructor of the EF ObjectContext should be used. 
        /// </summary>
        public bool DontUseExternalConnection
        {
            get; set;
        }

        #endregion

        #region Methods

        #region Protected Methods

        /// <summary>
        /// Register the Interfaces and classes for dependency injection
        /// </summary>
        protected override void Load(ContainerBuilder builder)
        {
            if (DontUseExternalConnection)
            {
                // Unit of Work -> EF object context
                builder.Register(c => new LookupContext())
                            .ContainerScoped()
                            .As<IUnitOfWork>();

            }
            else
            {
                const string entityName = "Lookup";

                builder.Register(c =>
                    new EntityConnection(ConnectionMgr.GetMetaWorkspaceForType(typeof(LookupContext)), c.Resolve<SqlConnection>()))
                    .Named(entityName);

                // Unit of Work -> EF object contect
                builder.Register(c =>
                    new LookupContext(c.Resolve<EntityConnection>(entityName)))
                            .ContainerScoped()
                            .As<IUnitOfWork>();
            }
            // Repositories
            builder.Register(c => new XLogRepository(c.Resolve<IUnitOfWork>()))
                        .FactoryScoped()
                        .As<IRepository<XLog>>();

            builder.Register(c => new BaLandRepository(c.Resolve<IUnitOfWork>()))
                        .FactoryScoped()
                        .As<IRepository<BaLand>>();

            // Services
            builder.Register(c => new LogService(
                                       c.Resolve<IContainer>()))
                        .FactoryScoped();

            builder.Register(c => new LandService(
                                     c.Resolve<IContainer>()))
                        .FactoryScoped();
        }

        #endregion

        #endregion
    }
}