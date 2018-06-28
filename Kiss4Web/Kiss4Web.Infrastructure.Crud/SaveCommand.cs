using Kiss4Web.Infrastructure.Mediator;

namespace Kiss4Web.Infrastructure.Crud
{
    public class SaveCommand<TEntity> : Message
    {
        public TEntity Entity { get; set; }
    }
}