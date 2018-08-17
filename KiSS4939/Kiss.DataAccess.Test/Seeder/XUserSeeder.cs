using System;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class XUserSeeder : DbSeeder<XUser>
    {
        #region Methods

        #region Public Methods

        public XUserSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override XUser CreateEntity()
        {
            return CreateXUser();
        }

        public XUser CreateXUser(XOrgUnit orgUnit = null)
        {
            orgUnit = orgUnit ?? DbSeed.GetOrCreateEntity<XOrgUnit>();
            //var sessionService = Container.Resolve<ISessionService>();
            //var logonName = "LogonName";
            //if (sessionService.AuthenticatedUser != null)
            //{
            //    logonName = sessionService.AuthenticatedUser.LogonName;
            //}

            var user = new XUser
                           {
                               LogonName = Guid.NewGuid().ToString(),
                               LastName = "Unit",
                               FirstName = "Test"
                           };
            DbSeed.Add(user);

            var membership = new XOrgUnit_User
                                 {
                                     OrgUnitMemberCode = 2, //Member
                                     XUser = user,
                                     XOrgUnit = orgUnit
                                 };
            DbSeed.Add(membership);

            return user;
        }

        #endregion

        #endregion
    }
}