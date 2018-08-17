using System;

using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test
{
    [TestClass]
    public class KissUnitOfWorkTest
    {
        [TestMethod]
        public void GetGenericRepository()
        {
            // Arrange
            using (var unitOfWork= new UnitOfWork(new KissContext()))
            {
                // Act
                // get a generic repository(Repository<TEntity>), not a derived one (like BaPersonRepository)
                // there won't be a ObjectRepository, so this is a good test case. there is no check that TEntity is in the context
                var repository = unitOfWork.Repository<BaPerson>();

                // Assert
                Assert.IsNotNull(repository);
            }
        }
    }
}
