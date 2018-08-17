using System.Collections.Generic;

using Kiss.DbContext;

namespace Kiss.DataAccess.Test.Seeder
{
    public abstract class DbSeeder<T>
        where T : IPocoEntity
    {
        public DbSeed DbSeed{get;private set;}

        protected DbSeeder(DbSeed dbSeed)
        {
            DbSeed = dbSeed;
        }

        public List<T> CreateMultiple(int nbrOfPersons)
        {
            var list = new List<T>(nbrOfPersons);
            for (var i = 0; i < nbrOfPersons; i++)
            {
                list.Add(CreateEntity());
            }
            return list;
        }

        public abstract T CreateEntity();

    }
}