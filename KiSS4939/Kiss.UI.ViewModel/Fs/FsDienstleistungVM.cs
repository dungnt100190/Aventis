using System;

using Kiss.BL.Fs;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;
using Kiss.BL.KissSystem;

namespace Kiss.UI.ViewModel.Fs
{
    public class FsDienstleistungVM : ViewModelCRUDListBase<FsDienstleistung>
    {
        #region Constructors

        public FsDienstleistungVM()
            : base(Container.Resolve<FsDienstleistungService>())
        {
            SelectedEntityChanged += CurrentSelectedEntityChanged;
        }

        #endregion

        #region Properties

        public int StandardAufwandMinuten
        {
            get
            {
                if (SelectedEntity == null)
                {
                    return 0;
                }

                return (int)Decimal.Round((SelectedEntity.StandardAufwand - StandardAufwandStunden) * 60);
            }

            set
            {
                SelectedEntity.StandardAufwand = Convert.ToDecimal(StandardAufwandStunden) + Convert.ToDecimal(value) / 60;
                NotifyPropertyChanged.RaisePropertyChanged(() => StandardAufwandMinuten);
            }
        }

        public int StandardAufwandStunden
        {
            get
            {
                if (SelectedEntity == null)
                {
                    return 0;
                }

                return (int)Decimal.Truncate(SelectedEntity.StandardAufwand);
            }

            set
            {
                SelectedEntity.StandardAufwand = Convert.ToDecimal(value) + Convert.ToDecimal(StandardAufwandMinuten) / 60;
                NotifyPropertyChanged.RaisePropertyChanged(() => StandardAufwandStunden);
            }
        }

        private FsDienstleistungService Service
        {
            get { return (FsDienstleistungService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void Init(string className)
        {
            LoadData(null);
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetData(null);
        }

        #endregion

        #region Protected Methods

        protected void CurrentSelectedEntityChanged(FsDienstleistung selectedEntity, FsDienstleistung deselectedEntity)
        {
            NotifyPropertyChanged.RaisePropertyChanged(() => StandardAufwandMinuten);
            NotifyPropertyChanged.RaisePropertyChanged(() => StandardAufwandStunden);
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.StandardAufwand))
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => StandardAufwandMinuten);
                NotifyPropertyChanged.RaisePropertyChanged(() => StandardAufwandStunden);
            }
        }

        #endregion

        #endregion
    }
}