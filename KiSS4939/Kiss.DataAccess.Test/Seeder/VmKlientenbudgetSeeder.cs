using System;

using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;

namespace Kiss.DataAccess.Test.Seeder
{
    public class VmKlientenbudgetSeeder : DbSeeder<VmKlientenbudget>
    {
        #region Constructors

        public VmKlientenbudgetSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override VmKlientenbudget CreateEntity()
        {
            return CreateKlientenbudget();
        }

        public VmKlientenbudget CreateKlientenbudget(FaLeistung leistung = null, VmKlientenbudgetStatus status = VmKlientenbudgetStatus.InBearbeitung)
        {
            leistung = leistung ?? DbSeed.GetOrCreateEntity<FaLeistung>();
            var budget = new VmKlientenbudget
                             {
                                 FaLeistung = leistung,
                                 VmKlientenbudgetStatus = status,
                                 VmKlientenbudgetMutationsgrundCode = 1,
                                 GueltigAb = DateTime.Today,
                                 XUser = leistung.XUser,
                             };
            DbSeed.Add(budget);

            var positionsart = DbSeed.GetOrCreateEntity<VmPositionsart>();
            var position = new VmPosition
                               {
                                   VmKlientenbudget = budget,
                                   VmPositionsart = positionsart,
                                   Name = "Name VmPosition (UnitTest)",
                                   BetragMonatlich = 123
                               };
            DbSeed.Add(position);

            return budget;
        }

        #endregion

        #endregion
    }
}