using Kiss.DbContext;
using Kiss.DbContext.Enums.Kes;

namespace Kiss.DataAccess.Test.Seeder
{
    public class KesDokumentSeeder : DbSeeder<KesDokument>
    {
        public KesDokumentSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override KesDokument CreateEntity()
        {
            var kesAuftrag = DbSeed.GetOrCreateEntity<KesAuftrag>();
            var user = DbSeed.GetOrCreateEntity<XUser>();

            var kesDokument = new KesDokument
            {
                KesAuftragID = kesAuftrag.KesAuftragID,
                KesDokumentTypCode = (int)KesDokumentTyp.AuftragDokument,
                XUser = user
            };

            DbSeed.Add(kesDokument);
            return kesDokument;
        }
    }
}