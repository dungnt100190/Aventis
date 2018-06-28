namespace Kiss4Web.Infrastructure.DataAccess.Entities.Configuration
{
    public abstract class EntityMap<TEntity> : EntityTypeConfiguration<TEntity>
        where TEntity : GuidEntity
    {
        protected EntityMap(string schemaName = null)
        {
            ToTable(typeof(TEntity).Name, schemaName ?? typeof(TEntity).GetDbSchemaName());

            HasKey(ent => ent.Id);

            // GUID must be client-generated
            Property(ent => ent.Id)
                .ValueGeneratedNever();

            Property(ent => ent.RowVersion)
                .IsConcurrencyToken();
        }
    }
}