using System;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class KesMassnahmeBerichtSeeder : DbSeeder<KesMassnahmeBericht>
    {
        public KesMassnahmeBerichtSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override KesMassnahmeBericht CreateEntity()
        {
            var kesMassnahme = DbSeed.GetOrCreateEntity<KesMassnahme>();

            var kesMassnahmeBericht = new KesMassnahmeBericht
            {
                KesMassnahme = kesMassnahme,
                DatumVon = DateTime.Today,
                DatumBis = DateTime.Today.AddDays(1)
            };

            DbSeed.Add(kesMassnahmeBericht);
            return kesMassnahmeBericht;
        }
    }
}