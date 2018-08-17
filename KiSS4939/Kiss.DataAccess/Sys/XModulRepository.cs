using System.Collections.Generic;
using System.Linq;

using Kiss.DbContext;

namespace Kiss.DataAccess.Sys
{
    public class XModulRepository : Repository<XModul>
    {
        #region Constructors

        public XModulRepository(IDbContext dbContext)
            : base(dbContext)
        {
        }

        public XModulRepository()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public virtual List<XModul> GetForGotoFall(bool treeExists)
        {
            return DbSet.Where(mdl => mdl.ModulTree && !string.IsNullOrEmpty(mdl.ShortName))
                .WhereIf(treeExists, mdl => mdl.XClass.Any(cls => cls.BaseType == "KiSS4.Common.KissModulTree"))
                .ToList();
        }

        #endregion

        #endregion
    }
}