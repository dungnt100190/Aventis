using System.Threading.Tasks;
using Kiss4Web.Infrastructure.DataAccess.Context;
using Kiss4Web.Infrastructure.Mediator;
using Kiss4Web.Model.Entities;

namespace Kiss4Web.Infrastructure.Crud
{
    public class SaveCommandHandler<TEntity> : TypedMessageHandler<SaveCommand<TEntity>>
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> _repository;

        public SaveCommandHandler(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public override Task Handle(SaveCommand<TEntity> command)
        {
            return _repository.InsertOrUpdateEntity(command.Entity);
        }
    }
}