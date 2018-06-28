using Kiss4Web.Infrastructure.DataAccess.Entities.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Kiss4Web.Infrastructure.DataAccess.Model
{
    public class DbModelComposer : IDbModelComposer
    {
        private readonly EntityTypeConfigurationFactory _entityTypeConfigurationFactory;

        public DbModelComposer(EntityTypeConfigurationFactory entityTypeConfigurationFactory)
        {
            _entityTypeConfigurationFactory = entityTypeConfigurationFactory;
        }

        public IModel ComposeModel(ModelBuilder modelBuilder = null, bool onlyModelVerification = false)
        {
            modelBuilder = modelBuilder ?? new ModelBuilder(SqlServerConventionSetBuilder.Build());
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // Für .NET DateTime wird SQL datetime2(7) verwendet
            //modelBuilder.Properties<DateTime>()
            //    .Where(pi => !IsValidPeriodProperty(pi))
            //    .Configure(pca => pca.HasColumnType(SqlDbType.DateTime2.ToString()).HasPrecision(7));

            //modelBuilder.Properties<DateTime>()
            //    .Where(IsValidPeriodProperty)
            //    .Configure(pca => pca.HasColumnType("date"));

            var moduleModelBuilders = _entityTypeConfigurationFactory.CreateEntityTypeConfigurations();
            foreach (var builder in moduleModelBuilders)
            {
                builder.BuildModel(modelBuilder);
            }

            //// Reportentities sind von DB-Entities abgeleitet und würde deshalb in die DB generiert werden
            //var reportEntities = modelBuilder.Types().Where(typ => typeof(IReportEntity).IsAssignableFrom(typ));
            //reportEntities.Configure(typ => typ.Ignore());

            return modelBuilder.Model;
        }

        //private bool IsValidPeriodProperty(PropertyInfo pi)
        //{
        //    return pi.Name == nameof(IValidPeriodEntity.ValidFrom) ||
        //           pi.Name == nameof(IValidPeriodEntity.ValidTill);
        //}
    }
}