using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Kiss.DbContext;
using Kiss.DbContext.DTO.Fs;
using Kiss.Infrastructure;

namespace Kiss.DataAccess.Kes
{
    public class KesBehoerdeRepository : Repository<KesBehoerde>
    {
        /// <summary>
        /// Only for testing purpose
        /// </summary>
        public KesBehoerdeRepository()
        {
        }

        public KesBehoerdeRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public List<KesBehoerde> FindBehoerdeBySearchParams(string searchString, string kanton = "", bool isActive = true)
        {
            return DbSet.Where(x => x.IsActive.Equals(isActive))
                        .Where(x => x.Kanton == kanton || string.IsNullOrEmpty(kanton))
                        .Where(x => x.KESBID.ToUpper().StartsWith(searchString) ||
                               x.Kanton.ToUpper().StartsWith(searchString) ||
                               x.KESBName.ToUpper().Contains(searchString.Replace("*", "")) ||
                               searchString == "*" || string.IsNullOrEmpty(searchString)
                               )
                        .ToList();
        }
    }
}