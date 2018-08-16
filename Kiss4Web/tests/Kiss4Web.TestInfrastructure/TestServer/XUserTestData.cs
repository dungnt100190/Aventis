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

        public readonly XUser NewAdmin = new XUser
        {
            FirstName = "Support",
            LastName = "New",
            PasswordHash = "kR9Y+JkxEwo=", // 123456
            GenderCode = 1,
            LogonName = "new_admin",
            ShortName = "ns",
            IsUserAdmin = true
        };

        public readonly XUser DiagAdmin = new XUser
        {
            FirstName = "Support",
            LastName = "Diartis",
            PasswordHash = "kR9Y+JkxEwo=", // 123456
            GenderCode = 1,
            LogonName = "diag_admin",
            ShortName = "ds",
            IsUserAdmin = true
        };

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

        public const string NewAdminPassword = "123456";
        public const string AdminPassword = "topsecretunittestpassword";
        public const string DiagAdminPassword = "123456";
        public const string SozialarbeiterPassword = "topsecretunittestpassword";

        protected override void ResetAutoIdentity(XUser entity)
        {
            entity.UserId = 0;
        }

        protected override bool CopyProperties(XUser existingEntity, XUser testDataEntity)
        {
            testDataEntity.UserId = existingEntity.Id;
            return false;
        }
    }
}