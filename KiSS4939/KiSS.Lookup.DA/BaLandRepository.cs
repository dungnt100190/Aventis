using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS.Common.DA;

namespace KiSS.Lookup.DA
{
    public class BaLandRepository : RepositoryBase<BaLand>
    {
        #region Fields

        #region Private Fields

        private LookupContext _context;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BaLandRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork"><see cref="IUnitOfWork"/> to use for this repository</param>
        public BaLandRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            _context = unitOfWork as LookupContext;
        }

        #endregion

        #region Properties

        protected override IQueryable<BaLand> RepositoryQuery
        {
            get { return _context.BaLand; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds a <see cref="BaLand"/> to the <see cref="LookupRepository"/>.
        /// </summary>
        /// <param name="item">The country to add</param>
        public override void Add(BaLand item)
        {
            _context.AddToBaLand(item);
        }

        /// <summary>
        /// Deletes a <see cref="BaLand"/> from the <see cref="LookupRepository"/>.
        /// </summary>
        /// <param name="item">The country code to delete</param>
        public override void Delete(BaLand item)
        {
            _context.DeleteObject(item);
        }

        #endregion

        #endregion
    }
}