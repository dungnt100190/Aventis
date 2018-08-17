using System.Collections.Generic;
using System.Linq;

using KiSS.Common.DA;
using KiSS.Lookup.DA;

namespace KiSS.KliBu.BL.Test.Mock
{
    internal class MockXLogRepository : RepositoryBase<XLog>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly List<XLog> _lst = new List<XLog>();

        #endregion

        #endregion

        #region Properties

        protected override IQueryable<XLog> RepositoryQuery
        {
            get { return _lst.AsQueryable(); }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override void Add(XLog item)
        {
            _lst.Add(item);
        }

        public override void Delete(XLog item)
        {
            _lst.Remove(item);
        }

        #endregion

        #endregion
    }
}