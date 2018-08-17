using System;

using Kiss.DbContext;
using Kiss.DbContext.Enums.Kes;

namespace Kiss.DataAccess.Test.Seeder
{
    public class KesVerlaufSeeder : DbSeeder<KesVerlauf>
    {
        public KesVerlaufSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override KesVerlauf CreateEntity()
        {
            var faLeistung = DbSeed.GetOrCreateEntity<FaLeistung>();
            var user = DbSeed.GetOrCreateEntity<XUser>();

            var kesVerlauf = new KesVerlauf
            {
                Datum = DateTime.Today,
                FaLeistung = faLeistung,
                KesVerlaufTypCode = (int)KesVerlaufTyp.PriMaBegleitung,
                XUser = user
            };

            DbSeed.Add(kesVerlauf);

            return kesVerlauf;
        }
    }
}