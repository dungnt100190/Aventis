using System;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class FaFallPersonSeed : DbSeeder<FaFallPerson>
    {
        public FaFallPersonSeed(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override FaFallPerson CreateEntity()
        {
            var faFallPerson = new FaFallPerson
            {
                DatumVon = new DateTime(DateTime.Today.Year, 1, 1),
            };
            DbSeed.Add(faFallPerson);
            return faFallPerson;
        }
    }
}