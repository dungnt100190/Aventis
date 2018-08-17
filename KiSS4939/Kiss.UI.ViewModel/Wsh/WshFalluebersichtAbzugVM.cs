using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

using Kiss.BL.Fa;
using Kiss.BL.KissSystem;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Constant;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Interfaces.UI;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshFalluebersichtAbzugVM : ViewModelCRUDListBase<WshFalluebersichtAbzugDTO>
    {
        #region Fields

        #region Private Fields

        private ObservableCollection<XLOVCode> _abschlussAktion;
        private int _faFallId;
        private ICommand _goToGrundbudgetCommand;
        private bool _isAbgeschlosseneIncluded;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshFalluebersichtAbzugVM"/> class.
        /// </summary>
        public WshFalluebersichtAbzugVM()
            : base(Container.Resolve<WshFalluebersichtAbzugDTOService>())
        {
        }

        #endregion

        #region Properties

        public ObservableCollection<XLOVCode> AbschlussAktion
        {
            get { return _abschlussAktion; }
            set
            {
                if (_abschlussAktion != value)
                {
                    _abschlussAktion = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => AbschlussAktion);
                }
            }
        }

        public bool IsAbgeschlosseneIncluded
        {
            get { return _isAbgeschlosseneIncluded; }
            set
            {
                if (_isAbgeschlosseneIncluded != value)
                {
                    _isAbgeschlosseneIncluded = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsAbgeschlosseneIncluded);
                    LoadData(null);
                }
            }
        }

        private WshFalluebersichtAbzugDTOService Service
        {
            get { return (WshFalluebersichtAbzugDTOService)ServiceCRUD; }
        }

        #endregion

        #region Commands

        public ICommand GoToGrundbudgetCommand
        {
            get
            {
                if (_goToGrundbudgetCommand == null)
                {
                    _goToGrundbudgetCommand = new BaseCommand(GoToGrundbudget, (o)=>SelectedEntity != null);
                }

                return _goToGrundbudgetCommand;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init(int faLeistungId)
        {
            var faLeistungService = Container.Resolve<FaLeistungService>();
            var faLeistung = faLeistungService.GetFaLeistungById(null, faLeistungId);
            _faFallId = faLeistung.FaFallID;

            var xlovService = Container.Resolve<XLovService>();

            //AbschlussGrund
            var enumWshAbzugAbschlussAktionName = typeof(LOVsGenerated.WshAbzugAbschlussAktion).Name;
            AbschlussAktion = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, enumWshAbzugAbschlussAktionName));

            LoadData(null);
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = new ObservableCollection<WshFalluebersichtAbzugDTO>(Service.GetFalluebersichtAbzug(unitOfWork, _faFallId, IsAbgeschlosseneIncluded));
        }

        #endregion

        #region Private Methods

        private void GoToGrundbudget(object dialog)
        {
            var controller = Container.Resolve<IKissFormController>();
            string pfadTreeNode = String.Format(@"Kiss.UI.View.Wsh.WshLeistungView.xaml{0}/Kiss.UI.View.Wsh.WshGrundBudgetView.xaml", SelectedEntity.FaLeistungID);

            controller.OpenForm("FrmFall", "Action", "JumpToPath",
                        "BaPersonID", SelectedEntity.FallBaPersonID,
                        "ModulID", 103,
                        "TreeNodeID", pfadTreeNode,
                        "WshAbzugID", SelectedEntity.WshAbzugID);
        }

        #endregion

        #endregion

        #region Other

        /*
        /// <summary>
        /// Gets the data from service.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use (can be null)</param>
        public override void Search(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetData(unitOfWork);
        }
        */

        #endregion
    }
}