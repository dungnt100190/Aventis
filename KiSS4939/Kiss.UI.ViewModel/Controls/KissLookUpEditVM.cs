using System.Collections.Generic;
using System.Collections.ObjectModel;

using Kiss.BL.KissSystem;
using Kiss.Infrastructure.IoC;
using Kiss.Model;

namespace Kiss.UI.ViewModel.Controls
{
    class KissLookUpEditVM
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly IList<XLOVCode> _availableCodes;
        private readonly IList<XLOVCode> _codesInDB;
        private readonly XLovService _service = Container.Resolve<XLovService>();

        #endregion

        #endregion

        #region Constructors

        public KissLookUpEditVM(string lovName, string lovFilter, bool allowNull)
        {
            _codesInDB = _service.GetLovCodeByLovName(null, lovName); //KiSS.DBScheme.LOV.LOVName_Zivilstand);
            _availableCodes = GetAvailableCodes(_codesInDB, lovFilter, allowNull);
        }

        #endregion

        #region Properties

        public ReadOnlyCollection<XLOVCode> LOV
        {
            get
            {
                return new ReadOnlyCollection<XLOVCode>(_availableCodes);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private IList<XLOVCode> GetAvailableCodes(IList<XLOVCode> codesInDB, string lovFilter, bool allowNull)
        {
            IList<XLOVCode> availableCodes = new List<XLOVCode>();
            if (allowNull)
            {
                //availableCodes.Add();
            }
            return availableCodes;
        }

        #endregion

        #endregion
    }
}