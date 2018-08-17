using System;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class XLovSeeder : DbSeeder<XLOV>
    {
        public XLovSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override XLOV CreateEntity()
        {
            var lov = new XLOV
            {
                LOVName = "LovSeeder",
            };

            DbSeed.Add(lov);

            return lov;
        }
    }
}