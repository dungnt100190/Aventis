namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    //public class AventisEfDbContextFactory : IDesignTimeDbContextFactory<AventisDbContext>
    //{
    //    public AventisDbContext Create(DbContextFactoryOptions options)
    //    {
    //        return Create(options.ContentRootPath, options.EnvironmentName);
    //    }

    //    private static Assembly LoadAssembly(AssemblyName assemblyName)
    //    {
    //        try
    //        {
    //            return Assembly.Load(assemblyName);
    //        }
    //        catch
    //        {
    //            // ignored
    //        }
    //        return null;
    //    }

    //    private AventisDbContext Create(string basePath, string environmentName)
    //    {
    //        var builder = new ConfigurationBuilder()
    //            .SetBasePath(basePath)
    //            .AddJsonFile("appsettings.json")
    //            .AddJsonFile($"appsettings.{environmentName}.json", true);
    //        //.AddEnvironmentVariables();

    //        var config = builder.Build();
    //        var connstr = config.GetConnectionString("DefaultConnection");

    //        if (string.IsNullOrWhiteSpace(connstr) == true)
    //        {
    //            throw new InvalidOperationException(
    //            "Could not find a connection string named '(default)'.");
    //        }
    //        else
    //        {
    //            return Create(connstr);
    //        }
    //    }

    //    private AventisDbContext Create(string connectionString)
    //    {
    //        if (string.IsNullOrEmpty(connectionString))
    //            throw new ArgumentException(
    //            $"{nameof(connectionString)} is null or empty.",
    //            nameof(connectionString));

    //        var optionsBuilder = new DbContextOptionsBuilder<AventisDbContext>();

    //        optionsBuilder.UseSqlServer(connectionString);

    //        var assemblyNames = new AventisAssemblies();
    //        var entities = assemblyNames.AssemblyNames
    //                                    .Select(LoadAssembly)
    //                                    .Where(asm => asm != null)
    //                                    .SelectMany(asm => asm.ExportedTypes)
    //                                    .Where(typ => typ.ImplementsInterface<IEntityTypeConfiguration>() &&
    //                                                  !typ.GetTypeInfo().IsInterface &&
    //                                                  !typ.GetTypeInfo().IsAbstract)
    //                                    .ToList();

    //        var entityTypesConfigurations = entities.Select(Activator.CreateInstance).OfType<IEntityTypeConfiguration>().ToList();
    //        var dbModelComposer = new DbModelComposer(entityTypesConfigurations);
    //        var model = dbModelComposer.ComposeModel();

    //        var factory = new AventisDbContextFactory(new ConnectionString(connectionString), model);
    //        return factory.CreateDbContext() as AventisDbContext;
    //    }
    //}
}