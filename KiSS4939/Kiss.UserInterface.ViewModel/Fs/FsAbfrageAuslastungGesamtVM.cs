using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Kiss.BusinessLogic.Fs;
using Kiss.DbContext.DTO;
using Kiss.DbContext.DTO.Fs;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.Fs
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class FsAbfrageAuslastungGesamtVM : ViewModelSearchList<FsDienstleistungAuswertungGesamtDTO, DateRangeSearchParamDTO>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FsDienstleistungAuswertungService _service;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="FsAbfrageAuslastungGesamtVM"/> class.
        /// </summary>
        public FsAbfrageAuslastungGesamtVM()
        {
            _service = Container.Resolve<FsDienstleistungAuswertungService>();

            var today = DateTime.Today;

            SearchParameters = new DateRangeSearchParamDTO
            {
                DatumVon = new DateTime(today.Year, today.Month, 1),
                DatumBis = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)),
            };
        }

        #endregion

        #region Methods

        #region Public Methods

        protected override IServiceResult<IEnumerable<FsDienstleistungAuswertungGesamtDTO>> SearchInBackground(DateRangeSearchParamDTO searchParameters,
                                                                                                         CancellationToken cancellationToken)
        {
            return _service.RunQuery(searchParameters);
        }

        #endregion

        #endregion
    }
}