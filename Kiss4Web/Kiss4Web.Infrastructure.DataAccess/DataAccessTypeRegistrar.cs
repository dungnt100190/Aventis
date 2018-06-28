using System.Data.SqlClient;
using System.Linq;
using FluentValidation;
using Kiss4Web.Infrastructure.DataAccess.Audit;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.DataAccess.Entities.Configuration;
using Kiss4Web.Infrastructure.DataAccess.Model;
using Kiss4Web.Infrastructure.Modularity;
using Microsoft.EntityFrameworkCore.Design;
using SimpleInjector;

namespace Kiss4Web.Infrastructure.DataAccess
{
    public class DataAccessTypeRegistrar : ITypeRegistrator
    {
        public void RegisterTypes(Container container, ILicensedAssemblies assemblies)
        {
            container.Register<IDbContext>(container.GetInstance<Kiss4DbContext>);
            container.Register<ISaveableDbSetContainer>(container.GetInstance<Kiss4DbContext>);
            container.Register<IDbSetContainer>(container.GetInstance<Kiss4DbContext>);
            container.Register(() => container.GetInstance<Kiss4DbContext>().Database);
            container.Register(() => container.GetInstance<IDesignTimeDbContextFactory<Kiss4DbContext>>().CreateDbContext(new string[] { }));

            container.Register(() => new SqlConnection(container.GetInstance<ConnectionString>()));

            //container.AddRegistration(typeof(IBulkInsertContext), registration);
            //container.AddRegistration(typeof(IDirectSqlCommandContext), registration);
            container.Register(typeof(IRepository<>), typeof(Repository<>));

            container.RegisterSingleton(() => new EntityTypeConfigurationFactory(assemblies.Assemblies, null));
            //container.RegisterSingleton(() => container.GetInstance<IDbModelComposer>().ComposeModel());
            //container.RegisterSingleton<IDbModelComposer, DbModelComposer>();
            container.RegisterSingleton<IDbModelVerifier, DbModelVerifier>();
            //container.RegisterSingleton<IShadowTableMapper, ShadowTableMapper>();

            container.RegisterConditional(typeof(IQueryable<>), typeof(Queryable<>), c => !c.Handled);
            //container.RegisterConditional(typeof(IQueryable<>), typeof(DbSet<>), c => !c.Handled);

            container.RegisterSingleton<IDesignTimeDbContextFactory<Kiss4DbContext>, Kiss4DbContextFactory>();
            container.RegisterSingleton<IDbContextFactory, Kiss4DbContextFactory>();

            var dbAuditors = assemblies.Assemblies.GetTypesImplementing<IDbChangeAuditor>();
            container.RegisterCollection<IDbChangeAuditor>(dbAuditors);

            container.Register(typeof(IValidator<>), assemblies.Assemblies);
        }
    }
}