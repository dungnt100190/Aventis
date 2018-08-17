using System.Collections.Generic;
using System.Linq;
using Kiss.DbContext;

namespace Kiss.DataAccess.Fs
{
    public class FsDienstleistungspaketRepository : Repository<FsDienstleistungspaket>
    {
        public FsDienstleistungspaketRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public IList<DlpSum> GetDlpSum()
        {
            return DbSet
                   .Select(dlp => new DlpSum
                                      {
                                          FsDienstleistungspaketID = dlp.FsDienstleistungspaketID,
                                          Name = dlp.Name,
                                          Laufzeit = dlp.MaximaleLaufzeit,
                                          Sum = dlp.FsDienstleistung_FsDienstleistungspaket.Any() ?
                                                   dlp.FsDienstleistung_FsDienstleistungspaket.Sum(map => map.FsDienstleistung.StandardAufwand) :
                                                   decimal.Zero
                                      }).ToList();
        }
    }

    public class DlpSum
    {
        #region Properties

        public int FsDienstleistungspaketID { get; set; }

        public decimal? Laufzeit { get; set; }

        public string Name { get; set; }

        public decimal Sum { get; set; }

        #endregion
    }

}
