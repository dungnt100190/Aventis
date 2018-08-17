using System;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class XOrgUnitSeeder : DbSeeder<XOrgUnit>
    {
        #region Constructors

        public XOrgUnitSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override XOrgUnit CreateEntity()
        {
            var orgUnit = new XOrgUnit
                              {
                                  ItemName = Guid.NewGuid().ToString()
                              };

            DbSeed.Add(orgUnit);

            return orgUnit;
        }

        #endregion

        #endregion
    }
}