using System;
using System.Linq.Expressions;
using Kiss.DataAccess.Interfaces;
using Kiss.Infrastructure.IoC;
using Moq;

namespace Kiss.BusinessLogic.Test
{
    /// <summary>
    /// Unittestclass for XConfigService
    /// </summary>
    public class UnitOfWorkMock
    {
        private readonly Mock<IKissUnitOfWork> _uowMock;

        public UnitOfWorkMock()
        {
            _uowMock = SetupUnitOfWorkMock();
        }

        public IKissUnitOfWork GetUnitOfWork()
        {
            return _uowMock.Object;
        }

        public void RegisterRepository<TEntity>(Expression<Func<IKissUnitOfWork, IRepository<TEntity>>> expression, IRepository<TEntity> repository)
            where TEntity : class
        {
            _uowMock.Setup(expression)
                   .Returns(repository);
            _uowMock.Setup(uow => uow.Repository<TEntity>())
                   .Returns(repository);
            _uowMock.Setup(uow => uow.Repository(typeof(TEntity)))
                   .Returns(repository as IRepository);
        }

        private static Mock<IKissUnitOfWork> SetupUnitOfWorkMock()
        {
            var uowMock = new Mock<IKissUnitOfWork>();

            var factoryMock = new Mock<IUnitOfWorkFactory>();
            factoryMock.Setup(moq => moq.Create())
                       .Returns(uowMock.Object);

            Container.RegisterInstance(factoryMock.Object);

            return uowMock;
        }
    }
}