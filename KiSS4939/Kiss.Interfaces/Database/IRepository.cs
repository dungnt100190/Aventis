using System.Data.Objects;
using System.Linq;

namespace Kiss.Interfaces.Database
{
    public interface IRepository<T> : IQueryable<T>
        where T : class
    {
        void ApplyChanges(T entity);

        IQueryable<T> GetQuery { get; }
        IObjectSet<T> ObjectSet { get; }
    }
}