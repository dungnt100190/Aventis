using System;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class XLovCodeSeeder : DbSeeder<XLOVCode>
    {
        public XLovCodeSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override XLOVCode CreateEntity()
        {
            var lov = DbSeed.GetOrCreateEntity<XLOV>();

            var lovCode = new XLOVCode
            {
                XLOVID = lov.XLOVID,
                LOVName = lov.LOVName,
                Code = 1,
                Text = "TextSeeder1",
            };

            DbSeed.Add(lovCode);

            return lovCode;
        }
    }
}