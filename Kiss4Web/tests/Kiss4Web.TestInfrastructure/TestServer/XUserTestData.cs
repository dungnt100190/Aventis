using Kiss4Web.Model;
using Kiss4Web.TestInfrastructure.TestData;

namespace Kiss4Web.TestInfrastructure.TestServer
{
    public class XUserTestData : TestData<XUser>
    {
        public XUserTestData()
        {
            IsSameEntity = userNew => (userDb => userDb.LogonName == userNew.LogonName);
        }

        public readonly XUser Administrator = new XUser
        {
            FirstName = "Jaques",
            LastName = "Burgmeier",
            PasswordHash = "8YQQYCmL9A6bGNbxJkAxS6q/IIQoJx+3OoEP4FJ/7bc=", // topsecretunittestpassword
            GenderCode = 1,
            LogonName = "jburgmeier",
            ShortName = "buj",
            IsUserAdmin = true
        };

        public readonly XUser Sozialarbeiter = new XUser
        {
            FirstName = "Heida",
            LastName = "Fux",
            PasswordHash = "8YQQYCmL9A6bGNbxJkAxS6q/IIQoJx+3OoEP4FJ/7bc=", // topsecretunittestpassword
            GenderCode = 2,
            LogonName = "hfux",
            ShortName = "fuh"
        };

        public const string AdminPassword = "topsecretunittestpassword";
        public const string SozialarbeiterPassword = "topsecretunittestpassword";

        protected override void ResetAutoIdentity(XUser entity)
        {
            entity.UserID = 0;
        }

        protected override bool CopyProperties(XUser existingEntity, XUser testDataEntity)
        {
            testDataEntity.UserID = existingEntity.Id;
            return false;
        }
    }
}