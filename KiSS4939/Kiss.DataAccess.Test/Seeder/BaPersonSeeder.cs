
using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class BaPersonSeeder : DbSeeder<BaPerson>
    {
        #region Methods

        #region Public Methods

        public BaPersonSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        public override BaPerson CreateEntity()
        {
            var person = new BaPerson
                             {
                                 Name = "Unit Test Nachname",
                                 Vorname = "Unit Test Vorname"
                             };
            DbSeed.Add(person);
            return person;
        }

        #endregion

        #endregion
    }
}