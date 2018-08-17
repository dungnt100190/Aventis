
namespace Kiss.DbContext
{
    public interface IStatefulEntity
    {
        System.Data.EntityState EntityState { get; set; }
    }
}
