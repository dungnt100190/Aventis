using System.Collections.Generic;
using System.Data;
using System.Linq;

using Kiss.DbContext;

namespace Kiss.DataAccess.Fa
{
    public class FaFallRepository : Repository<FaFall>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly bool _faFallIsViewInDb;

        #endregion

        #endregion

        #region Constructors

        public FaFallRepository(IDbContext dbContext)
            : base(dbContext)
        {
            // TODO HACK: sollte via feature-konfiguration bestimmt werden (ZH=false, Std=true)
            _faFallIsViewInDb = true;
        }

        public FaFallRepository()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public virtual List<FaFall> GetByPersonId(int baPersonId)
        {
            return DbSet
                   .Where(fal => fal.BaPersonID == baPersonId)
                   .ToList();
        }

        public override EntityState InsertOrUpdateEntity(FaFall entity)
        {
            if (_faFallIsViewInDb)
            {
                // nop, view gets data from baperson, so insert is an invalid operation
                return EntityState.Unchanged;
            }
            return base.InsertOrUpdateEntity(entity);
        }

        public override FaFall Remove(FaFall entityToDelete)
        {
            if (_faFallIsViewInDb)
            {
                // nop, view gets data from baperson, so insert is an invalid operation
                return entityToDelete;
            }
            return base.Remove(entityToDelete);
        }

        #endregion

        #endregion
    }
}