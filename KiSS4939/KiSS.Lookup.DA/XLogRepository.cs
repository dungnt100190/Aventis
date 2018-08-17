using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using KiSS.Common.DA;

namespace KiSS.Lookup.DA
{
    /// <summary>
    /// Class to manage the XLog table
    /// </summary>
    public class XLogRepository : RepositoryBase<XLog>
    {
        #region Fields

        #region Private Fields

        private LookupContext _context;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="XLogRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork"><see cref="IUnitOfWork"/> to use for this repository</param>
        public XLogRepository(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            _context = unitOfWork as LookupContext;
        }

        #endregion

        #region Properties

        protected override IQueryable<XLog> RepositoryQuery
        {
            get { return _context.XLog; }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds a <see cref="XLog"/> to the <see cref="LookupRepository"/>.
        /// </summary>
        /// <param name="item">The log add</param>
        public override void Add(XLog item)
        {
            _context.AddToXLog(item);
        }

        /// <summary>
        /// Deletes a <see cref="XLog"/> from the <see cref="LookupRepository"/>.
        /// </summary>
        /// <param name="item">The log to delete</param>
        public override void Delete(XLog item)
        {
            _context.DeleteObject(item);
        }

        #endregion

        #endregion
    }
}