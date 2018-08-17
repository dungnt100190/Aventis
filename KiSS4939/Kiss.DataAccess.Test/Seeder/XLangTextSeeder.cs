using System;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class XLangTextSeeder : DbSeeder<XLangText>
    {
        public XLangTextSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override XLangText CreateEntity()
        {
            var lov = new XLangText
            {
                LanguageCode = 1,
                Text = "XLangText seeder 1",
            };

            DbSeed.Add(lov);

            return lov;
        }
    }
}