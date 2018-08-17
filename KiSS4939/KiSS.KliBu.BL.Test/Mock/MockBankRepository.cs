using System.Collections.Generic;
using System.Linq;

using KiSS.Common.DA;
using KiSS.KliBu.DA;

namespace KiSS.KliBu.BL.Test.Mock
{
    /// <summary>
    /// Class to mock the bank repository
    /// </summary>
    internal class MockBankRepository : RepositoryBase<BaBank>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<BaBank> _lst = new List<BaBank>();

        #endregion

        #endregion

        #region Properties

        protected override IQueryable<BaBank> RepositoryQuery
        {
            get { return _lst.AsQueryable(); }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Adds a bank to the list
        /// </summary>
        /// <param name="item"></param>
        public override void Add(BaBank item)
        {
            _lst.Add(item);
        }

        public override void Delete(BaBank item)
        {
            _lst.Remove(item);
        }

        #endregion

        #endregion
    }
}