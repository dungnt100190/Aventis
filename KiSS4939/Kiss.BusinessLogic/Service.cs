using System;
using Kiss.DataAccess.Interfaces;
using Kiss.Infrastructure.IoC;

namespace Kiss.BusinessLogic
{
    public class Service
    {
        protected IUnitOfWork CreateNewUnitOfWork()
        {
            try
            {
                var factory = Container.Resolve<IUnitOfWorkFactory>();
                return factory.Create();
            }
            catch (Exception ex)
            {
                throw new SystemException("Es ist keine UnitOfWorkFactory registriert", ex);
            }
        }

        protected T CreateNewUnitOfWork<T>()
            where T : class
        {
            return CreateNewUnitOfWork() as T;
        }
    }
}