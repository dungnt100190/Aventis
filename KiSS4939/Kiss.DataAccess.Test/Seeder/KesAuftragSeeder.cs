using System;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class KesAuftragSeeder : DbSeeder<KesAuftrag>
    {
        public KesAuftragSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override KesAuftrag CreateEntity()
        {
            var faLeistung = DbSeed.GetOrCreateEntity<FaLeistung>();

            var kesAuftrag = new KesAuftrag
            {
                FaLeistung = faLeistung,
                DatumAuftrag = DateTime.Now
            };

            DbSeed.Add(kesAuftrag);

            return kesAuftrag;
        }
    }
}