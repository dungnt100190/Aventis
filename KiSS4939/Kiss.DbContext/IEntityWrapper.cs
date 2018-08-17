namespace Kiss.DbContext
{
    public interface IEntityWrapper<out TEntity>
    {
        TEntity WrappedEntity { get; }
    }
}