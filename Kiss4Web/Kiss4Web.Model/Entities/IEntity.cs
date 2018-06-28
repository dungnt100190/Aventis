namespace Kiss4Web.Model.Entities
{
    public interface IEntity
    {
        int Id { get; }
        byte[] RowVersion { get; }
    }
}