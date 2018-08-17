using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class KesPraeventionSeeder : DbSeeder<KesPraevention>
    {
        public KesPraeventionSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override KesPraevention CreateEntity()
        {
            var faLeistung = DbSeed.GetOrCreateEntity<FaLeistung>();

            var kesPraevention = new KesPraevention
            {
                FaLeistung = faLeistung
            };

            DbSeed.Add(kesPraevention);

            return kesPraevention;
        }
    }
}