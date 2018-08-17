using System;
using System.Collections.Generic;
using System.Linq;

using Kiss.DataAccess.Interfaces;
using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public class FaFallSeeder : DbSeeder<FaFall>
    {
        #region Constructors

        public FaFallSeeder(DbSeed dbSeed)
            : base(dbSeed)
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public override FaFall CreateEntity()
        {
            return CreateFaFall(null, null);
        }

        public FaFall CreateFaFall(BaPerson person, XUser user)
        {
            person = person ?? DbSeed.GetOrCreateEntity<BaPerson>();
            user = user ?? DbSeed.GetOrCreateEntity<XUser>();

            var fall = new FaFall
                           {
                               BaPerson = person,
                               XUser = user,
                               DatumVon = new DateTime(DateTime.Today.Year, 1, 1),
                           };

            DbSeed.Add(fall);
            return fall;
        }

        #endregion

        #endregion
    }
}