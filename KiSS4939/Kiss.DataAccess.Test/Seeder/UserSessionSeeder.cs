using System;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class UserSessionSeeder : DbSeeder<UserSession>
    {
        #region Methods

        #region Public Methods

        public UserSessionSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override UserSession CreateEntity()
        {
            var xUser = DbSeed.GetOrCreateEntity<XUser>();
            var datetime = new DateTime(2013, 2, 2, 2, 2, 2, 2);
            var userSession = new UserSession
            {
                XUser = xUser,
                LogonName = xUser.LogonName,
                LoginDatum = datetime,
                LogoutDatum = null,
                UserName = xUser.LastNameFirstName,
                UserDomainName = "diartislocal.local",
                MachineName = "PC-11-041",
                ClientVersion = "4.5.44.510",
                WindowsVersion = "Microsoft Windows NT 6.1.7601 Service Pack 1",
                DotNetVersion = "4.0.30319.586",
                AufloesungBreite = 1176,
                AufloesungHoehe = 1936,
                OfficeVersionWord = "14.0.6129.5000",
                OfficeVersionExcel = "14.0.6126.5003",
                OfficeVersionOutlook = "14.0.6131.5000",
                CultureInfo = "de-CH"
            };
            DbSeed.Add(userSession);
            return userSession;
        }

        #endregion

        #endregion
    }
}