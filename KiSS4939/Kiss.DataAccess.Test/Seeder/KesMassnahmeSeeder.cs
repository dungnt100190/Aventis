using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class KesMassnahmeSeeder : DbSeeder<KesMassnahme>
    {
        public KesMassnahmeSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override KesMassnahme CreateEntity()
        {
            var faLeistung = DbSeed.GetOrCreateEntity<FaLeistung>();

            var kesMassnahme = new KesMassnahme
            {
                FaLeistung = faLeistung,
                IsKS = false
            };

            DbSeed.Add(kesMassnahme);

            return kesMassnahme;
        }
    }
}