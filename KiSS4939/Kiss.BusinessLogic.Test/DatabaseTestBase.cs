using System.Diagnostics;

using Kiss.DataAccess;
using Kiss.DataAccess.Interfaces;
using Kiss.Infrastructure.IoC;

using Entity = System.Data.Entity;

namespace Kiss.BusinessLogic.Test
{
    public abstract class DatabaseTestBase
    {
        protected DatabaseTestBase()
        {
            var factory = new KissUnitOfWorkFactory("KissContext");
            Container.RegisterInstance<IUnitOfWorkFactory>(factory);

            using (var uow = (KissUnitOfWork)factory.Create())
            {
                var context = (Entity.DbContext)uow.Context;
                Debug.WriteLine("Connection string: " + context.Database.Connection.ConnectionString);
            }
        }
    }
}