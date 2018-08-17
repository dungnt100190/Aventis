using System.Collections.Generic;
using System.Linq;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fs;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Constant;

namespace Kiss.DataAccess.Sys
{
    public class XClassRepository : Repository<XClass>
    {
        public XClassRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// Returns all XClass-entries that represent a WPF-view
        /// </summary>
        /// <returns></returns>
        public IList<XClass> GetAllWpfViews()
        {
            return DbSet
                   .Where(cls => cls.ClassNameViewModel != null)
                   .ToList();
        }
    }
}
