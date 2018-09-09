using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure.TestData;

namespace Kiss4Web.TestInfrastructure.TestServer
{
    public class BaPersonTestData : TestData<BaPerson>
    {
        public BaPersonTestData()
        {
            IsSameEntity = userNew => (userDb => userDb.Versichertennummer == userNew.Versichertennummer);
        }

        public readonly BaPerson Vasquez = new BaPerson
        {
            Vorname = "Mercedes",
            Name = "Vasquez",
            Versichertennummer = "756.1234.5678.97"
        };

        public const string AdminPassword = "topsecretunittestpassword";

        protected override void ResetAutoIdentity(BaPerson entity)
        {
            entity.BaPersonID = 0;
        }

        protected override bool CopyProperties(BaPerson existingEntity, BaPerson testDataEntity)
        {
            testDataEntity.BaPersonID = existingEntity.Id;
            testDataEntity.BaPersonTs = existingEntity.RowVersion;
            return false;
        }
    }
}