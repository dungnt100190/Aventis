using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;

namespace Kiss.DataAccess.Test.Seeder
{
    public class VmPositionsartSeeder : DbSeeder<VmPositionsart>
    {
        #region Constructors

        public VmPositionsartSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override VmPositionsart CreateEntity()
        {
            return CreateVmPositionsart(VmKategorie.Einnahmen, VmPositionsartTyp.EinnIvRente);
        }

        public VmPositionsart CreateVmPositionsart(VmKategorie kategorie, VmPositionsartTyp typ)
        {
            var positionsart = new VmPositionsart
            {
                Name = "TemplateTest",
                VmKategorie = kategorie,
                VmPositionsartTyp = typ,
                IstTemplate = true
            };
            DbSeed.Add(positionsart);

            return positionsart;
        }

        #endregion

        #endregion
    }
}