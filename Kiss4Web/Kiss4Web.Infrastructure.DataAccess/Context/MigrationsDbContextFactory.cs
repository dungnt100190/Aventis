namespace Kiss4Web.Infrastructure.DataAccess.Context
{
    //public class MigrationsDbContextFactory //: IDesignTimeDbContextFactory<AventisDbContext>
    //{
    //    public AventisDbContext Create(string connectionString)
    //    {
    //        if (string.IsNullOrEmpty(connectionString))
    //        {
    //            throw new ArgumentNullException(nameof(connectionString));
    //        }
    //        //throw new Exception(connectionString);

    //        var optionsBuilder = new DbContextOptionsBuilder<AventisDbContext>();

    //        var assembly = GetType().Assembly; // Convention: Microservice has to create a derived DbContextFactory
    //        var assemblyName = assembly.GetName().Name;
    //        var schemaName = GetType().GetDbSchemaName();
    //        optionsBuilder.UseSqlServer(connectionString, b =>
    //        {
    //            b.MigrationsAssembly(assemblyName);
    //            b.MigrationsHistoryTable("__MigrationHistory", schemaName);
    //        });
    //        var infrastructureAssembly = assembly.GetReferencedAssemblies()
    //            .Where(asm => asm.Name == "Aventis.Infrastructure").Select(Assembly.Load).FirstOrDefault();
    //        //throw new Exception(assembly.GetTypesImplementing<IEntityTypeConfiguration>().Select(t => t.Name).StringJoin());

    //        //var maps = assembly.GetTypesImplementing<IEntityTypeConfiguration>().ToList();

    //        //var maps = assembly.GetInstances<IEntityTypeConfiguration>().ToList();
    //        //maps.AddRange(AdditionalMaps());
    //        var dbModelComposer = new DbModelComposer(new EntityTypeConfigurationFactory(new[] { assembly, infrastructureAssembly }, schemaName));

    //        var model = dbModelComposer.ComposeModel();
    //        optionsBuilder.UseModel(model);

    //        return new AventisDbContext(optionsBuilder.Options);
    //    }

    //    public AventisDbContext CreateDbContext(string[] args)
    //    {
    //        var builder = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile("appsettings.json");
    //        //.AddJsonFile($"appsettings.{environmentName}.json", true);

    //        var config = builder.Build();
    //        var connstr = config.GetConnectionString("DefaultConnection");

    //        if (string.IsNullOrWhiteSpace(connstr))
    //        {
    //            throw new InvalidOperationException(
    //            "Could not find a connection string named '(default)'.");
    //        }
    //        return Create(connstr);
    //    }
    //}
}