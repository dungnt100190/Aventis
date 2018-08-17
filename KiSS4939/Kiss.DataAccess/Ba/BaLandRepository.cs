using System;
using System.Collections.Generic;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Ba
{
    public class BaLandRepository : Repository<BaLand>
    {
        public BaLandRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        private IQueryable<BaLand> DbSetValid
        {
            get { return DbSet.Where(x => x.DatumVon <= DateTime.Now && (x.DatumBis ?? DateTime.MaxValue) >= DateTime.Now); }
        }

        public int? GetBaLandIdByIso2Code(string iso2Code)
        {
            var baLandId = DbSetValid.Where(land => land.Iso2Code == iso2Code).Select(x => x.BaLandID).FirstOrDefault();
            return baLandId == 0 ? (int?)null : baLandId;
        }

        public BaLand GetByBfsCode(int bfsCode)
        {
            return DbSetValid.FirstOrDefault(land => land.BFSCode == bfsCode);
        }

        public IDictionary<int, string> GetLookupSapCodeToBaLandID()
        {
            return DbSet
                   .Where(land => land.SAPCode != null)
                   .ToDictionary(land => land.BaLandID,
                                 land => land.SAPCode);
        }
    }
}