using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Kiss.BL.Fs;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model.DTO;
using Kiss.Model.DTO.Fs;

namespace Kiss.UI.ViewModel.Fs
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class FsAbfrageAuslastungGesamtVM : ViewModelSearchListBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly FsDienstleistungAuswertungService _service;

        #endregion

        #region Private Fields

        private ObservableCollection<FsDienstleistungAuswertungGesamtDTO> _searchResult;

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

            SearchDTO = new DateRangeSearchParamDTO
            {
                DatumVon = new DateTime(today.Year, today.Month, 1),
                DatumBis = new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month)),
            };
        }

        #endregion

        #region Properties

        public DateRangeSearchParamDTO SearchDTO
        {
            get;
            private set;
        }

        public ObservableCollection<FsDienstleistungAuswertungGesamtDTO> SearchResult
        {
            get
            {
                return _searchResult;
            }

            set
            {
                _searchResult = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SearchResult);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KissServiceResult Search(IUnitOfWork unitOfWork)
        {
            IList<FsDienstleistungAuswertungGesamtDTO> list;
            var result = _service.RunQuery(SearchDTO, out list);
            SearchResult = new ObservableCollection<FsDienstleistungAuswertungGesamtDTO>(list);
            return result;
        }

        #endregion

        #endregion
    }
}