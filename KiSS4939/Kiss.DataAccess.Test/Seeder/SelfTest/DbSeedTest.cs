using System;
using System.Linq;
using Kiss.DbContext;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kiss.DataAccess.Test.Seeder.SelfTest
{
    [TestClass]
    public class DbSeedTest
    {
        [TestMethod]
        public void SeedUser()
        {
            // Arrange
            int insertedUserID;
            int insertedOrgUnitID;
            using (var seed = new DbSeed(() => new KissUnitOfWork()))
            {
                // Act
                var user = new XUserSeeder(seed).CreateEntity();
                seed.CreateSeed();
                insertedUserID = user.UserID;
                insertedOrgUnitID = user.XOrgUnit_User.First().OrgUnitID;

                // Assert
                using (var context = new KissUnitOfWork())
                {
                    var userShouldBeInserted = context.XUser.GetById(insertedUserID);
                    var orgUnitShouldBeInserted = context.XOrgUnit.GetById(insertedOrgUnitID);
                    Assert.IsNotNull(userShouldBeInserted);
                    Assert.IsNotNull(orgUnitShouldBeInserted);
                }
            }

            // Assert
            using (var context = new KissUnitOfWork())
            {
                var userShouldBeDeleted = context.XUser.GetById(insertedUserID);
                var orgUnitShouldBeDeleted = context.XOrgUnit.GetById(insertedOrgUnitID);
                Assert.IsNull(userShouldBeDeleted);
                Assert.IsNull(orgUnitShouldBeDeleted);
            }

        }
    }
}
