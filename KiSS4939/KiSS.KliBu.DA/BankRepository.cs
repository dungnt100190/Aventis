using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using KiSS.Common.DA;

namespace KiSS.KliBu.DA
{
    /// <summary>
    /// Class to manage a bank repository
    /// </summary>
    public class BankRepository : RepositoryBase<BaBank>
    {
        #region Fields

        #region Private Fields

        private KliBuContext _context;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="BankRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork"><see cref="IUnitOfWork"/> to use for this repository</param>
        public BankRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            _context = unitOfWork as KliBuContext;
        }

        #endregion

        #region Properties

        protected override IQueryable<BaBank> RepositoryQuery
        {
            get { return _context.BaBank; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds a <see cref="BaBank"/> to the <see cref="BankRepository"/>.
        /// </summary>
        /// <param name="item">The bank to add</param>
        public override void Add(BaBank item)
        {
            _context.AddToBaBank(item);
        }

        /// <summary>
        /// Deletes a <see cref="BaBank"/> from the <see cref="LookupRepository"/>.
        /// </summary>
        /// <param name="item">The bank to delete</param>
        public override void Delete(BaBank item)
        {
            _context.DeleteObject(item);
        }

        #endregion

        #endregion
    }
}