using System.Data.EntityClient;
using System.Data.SqlClient;

using KiSS.Common.DA;
using KiSS.Common.IoC;
using KiSS.KliBu.DA;

using Autofac;
using Autofac.Builder;

namespace KiSS.KliBu.BL
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>each BL requires a Bootstrapper</remarks>
    public class KliBuModule : Module, IDBModule
    {
        #region Properties

        /// <summary>
        /// Flag indicating if a the default constructor of the EF ObjectContext should be used. 
        /// </summary>
        public bool DontUseExternalConnection
        {
            get;
            set;
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
                builder.Register(c => new KliBuContext())
                            .ContainerScoped()
                            .As<IUnitOfWork>();
            }
            else
            {
                const string entityName = "KliBu";

                builder
                    .Register(c =>
                        new EntityConnection(ConnectionMgr.GetMetaWorkspaceForType(typeof(KliBuContext)), c.Resolve<SqlConnection>()))
                    .Named(entityName);

                // Unit of Work -> EF object contect
                builder.Register(c => new KliBuContext(c.Resolve<EntityConnection>(entityName)))
                            .ContainerScoped()
                            .As<IUnitOfWork>();
            }

            // Repositories
            builder.Register(c => new BankRepository(c.Resolve<IUnitOfWork>()))
                        .FactoryScoped()
                        .As<IRepository<BaBank>>();

            // Services
            builder.Register(c => new BankenService(c.Resolve<IContainer>()))
                        .FactoryScoped();

            builder.Register(c => new BankenabgleichService(c.Resolve<IContainer>()))
                        .FactoryScoped();
        }

        #endregion

        #endregion
    }
}