using System;
using System.Windows.Media;

using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the WshPosition entity.
    /// </summary>
    public class WshAbzugBudgetPositionVM : ViewModelCRUDListBase<WshPositionAbzugDTO>
    {
        #region Fields

        #region Private Fields

        private WshAbzugDTO _abzugDTO;
        private bool _isSaldoVisible;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshAbzugBudgetPositionVM"/> class.
        /// </summary>
        public WshAbzugBudgetPositionVM()
            : base(Container.Resolve<WshPositionAbzugDTOService>())
        {
        }

        #endregion

        #region Properties

        public bool IsSaldoVisible
        {
            get { return _isSaldoVisible; }
            private set
            {
                if (_isSaldoVisible == value)
                {
                    return;
                }

                _isSaldoVisible = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsSaldoVisible);
            }
        }

        private WshPositionAbzugDTOService Service
        {
            get { return (WshPositionAbzugDTOService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods


       
        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            KissServiceResult result = KissServiceResult.Ok();

            if(EntityList == null)
            {
                return result;
            }

            //Über alle geänderten Monats-Positionen iterieren und speichern.
            //Auch wenn nur eine Position durch den User geändert worden ist,
            //kann der Betrag einer anderen Position auch verändert worden sein.
            //Grund dafür ist der Saldo (sollte nicht kleiner als 0 sein).            
            foreach (WshPositionAbzugDTO abzugPosition in EntityList)
            {
                if(abzugPosition.ChangeTracker.State == ObjectState.Modified)
                {
                    result += Service.SaveData(null, abzugPosition);
                }
            }

            return result;
        }

        public ImageSource GetPositionsStatusImage(int rowIndex)
        {
            try
            {
                var position = EntityList[rowIndex];

                var imageService = Container.Resolve<WshPositionsStatusImageService>();
                return imageService.GetPositionsStatusImage(position.WshPosition, true);
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// NotSupportedException
        /// </summary>
        /// <param name="unitOfWork"></param>
        public override void LoadData(IUnitOfWork unitOfWork)
        {
            throw new NotSupportedException();
        }

        public void LoadData(WshAbzugDTO wshAbzugDto, bool refresh = false)
        {
            _abzugDTO = wshAbzugDto;
            if (wshAbzugDto == null)
            {
                EntityList = null;
                return;
            }

            IsSaldoVisible = !wshAbzugDto.WshAbzug.MonatlichWiederholend;

            if (wshAbzugDto.WshPosition == null || wshAbzugDto.WshPosition.Count == 0 || refresh)
            {
                wshAbzugDto.WshPosition = Service.GetByWshGrundbudgetPositionId(
                    null,
                    wshAbzugDto.WshAbzug.WshGrundbudgetPositionID,
                    wshAbzugDto.WshAbzug.WshGrundbudgetPosition.BetragTotal);
            }

            SelectedEntity = null;
            EntityList = wshAbzugDto.WshPosition;
        }

        #endregion

        #region Protected Methods

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            if (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.Aktiv))
            {
                Service.UpdateBetrag(_abzugDTO, EntityList, SelectedEntity);
            }
        }

        #endregion

        #endregion
    }
}