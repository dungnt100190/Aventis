using Kiss.Infrastructure;

namespace Kiss.Model.DTO.Wsh
{
    public class WshAbzugDetailDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private decimal? _gblAbzugProzent;
        private decimal? _gblAktuell;
        private WshAbzugDetail _wshAbzugDetail;

        #endregion

        #endregion

        #region Constructors

        public WshAbzugDetailDTO()
        {
        }

        public WshAbzugDetailDTO(WshAbzugDetail detail)
        {
            WshAbzugDetail = detail;
        }

        #endregion

        #region Properties

        public ObjectChangeTracker ChangeTracker
        {
            get { return WshAbzugDetail.ChangeTracker; }
        }

        public decimal? GblAbzugProzent
        {
            get { return _gblAbzugProzent; }
            set
            {
                if (_gblAbzugProzent == value)
                {
                    return;
                }

                _gblAbzugProzent = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => GblAbzugProzent);
            }
        }

        public decimal? GblAktuell
        {
            get { return _gblAktuell; }
            set
            {
                if (_gblAktuell == value)
                {
                    return;
                }

                _gblAktuell = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => GblAktuell);
            }
        }

        public WshAbzugDetail WshAbzugDetail
        {
            get { return _wshAbzugDetail; }
            set
            {
                if (_wshAbzugDetail == value)
                {
                    return;
                }

                _wshAbzugDetail = value;

                WshAbzugDetail.PropertyChanged += WshAbzugDetail_PropertyChanged;

                NotifyPropertyChanged.RaisePropertyChanged(() => WshAbzugDetail);
            }
        }

        #endregion

        #region EventHandlers

        void WshAbzugDetail_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // TODO AddPropertyMapping from EntityBase to PropertyMapping
            NotifyPropertyChanged.RaisePropertyChanged(PropertyName.GetPropertyName(() => WshAbzugDetail) + "." + e.PropertyName);
        }

        #endregion
    }
}