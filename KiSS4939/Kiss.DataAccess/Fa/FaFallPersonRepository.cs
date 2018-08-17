using System.Collections.Generic;
using System.Data;
using System.Linq;

using Kiss.DbContext;

namespace Kiss.DataAccess.Fa
{
    public class FaFallPersonRepository : Repository<FaFallPerson>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly bool _faFallPersonIsViewInDb;

        #endregion

        #endregion

        #region Constructors

        public FaFallPersonRepository(IDbContext dbContext)
            : base(dbContext)
        {
            _faFallPersonIsViewInDb = false; // HACK: sollte via feature-konfiguration bestimmt werden
        }

        public FaFallPersonRepository()
        {
        }

        #endregion

        #region Methods

        #region Public Methods

        public virtual List<FaFallPerson> GetByPersonId(int baPersonId)
        {
            return DbSet
                   .Where(fal => fal.BaPersonID == baPersonId)
                   .ToList();
        }

        public override EntityState InsertOrUpdateEntity(FaFallPerson entity)
        {
            if (_faFallPersonIsViewInDb)
            {
                // nop, view gets data from baperson, so insert is an invalid operation
                return EntityState.Unchanged;
            }
            return base.InsertOrUpdateEntity(entity);
        }

        public override FaFallPerson Remove(FaFallPerson entityToDelete)
        {
            if (_faFallPersonIsViewInDb)
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