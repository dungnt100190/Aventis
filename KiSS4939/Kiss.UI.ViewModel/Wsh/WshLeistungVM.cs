using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

using Kiss.BL.Ba;
using Kiss.BL.Fa;
using Kiss.BL.KissSystem;
using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.IoC;
using Kiss.Model;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshLeistungVM : ViewModelCRUDSingleEntityBase<FaLeistung>
    {
        #region Fields

        #region Private Fields

        private ObservableCollection<XLOVCode> _abschlussGrund;
        private ObservableCollection<XLOVCode> _eroeffnungsGrund;
        private ObservableCollection<BaPerson> _klientensystem;
        private SearchForStringEventHandler _userSearchEventHandler;
        private XUserService _userService;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshLeistungVM"/> class.
        /// </summary>
        public WshLeistungVM()
            : base(Container.Resolve<WshLeistungService>())
        {
        }

        #endregion

        #region Properties

        public ObservableCollection<XLOVCode> AbschlussGrund
        {
            get { return _abschlussGrund; }
        }

        public ObservableCollection<XLOVCode> EroeffnungsGrund
        {
            get { return _eroeffnungsGrund; }
        }

        public int FaLeistungID
        {
            get;
            private set;
        }

        public ObservableCollection<BaPerson> Klientensystem
        {
            get { return _klientensystem; }
        }

        public string LeistungstraegerNameVorname
        {
            get
            {
                if (Entity != null && Entity.BaPerson != null)
                {
                    StringBuilder nameVorname = new StringBuilder();

                    nameVorname.Append(Entity.BaPerson.Name ?? "-");
                    nameVorname.Append(", ");
                    nameVorname.Append(Entity.BaPerson.Vorname ?? "-");

                    return nameVorname.ToString();
                }

                return "--";
            }
        }

        public SearchForStringEventHandler UserSearchEventHandler
        {
            get { return _userSearchEventHandler; }
            private set
            {
                _userSearchEventHandler = value;
                NotifyPropertyChanged.RaisePropertyChanged("UserSearchEventHandler");
            }
        }

        private FaLeistungService Service
        {
            get { return (FaLeistungService)ServiceCRUD; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            return new KissServiceResult(KissServiceResult.ResultType.Error, "WshLeistungVM_NoDelete", "Die Leistung darf nur über den WSH-Baum gelöscht werden");
        }

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init(int leistungId)
        {
            FaLeistungID = leistungId;

            UserSearchEventHandler = SearchUser;

            //SetUp ComboBoxes

            XLovService xlovService = Container.Resolve<XLovService>();

            _abschlussGrund = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, "AbschlussGrund", "W"));
            _abschlussGrund.Insert(0, GetEmptyXLovCodeEntry());
            NotifyPropertyChanged.RaisePropertyChanged(() => AbschlussGrund);

            _eroeffnungsGrund = new ObservableCollection<XLOVCode>(xlovService.GetLovCodeByLovName(null, "EroeffnungsGrund", "W"));
            _eroeffnungsGrund.Insert(0, GetEmptyXLovCodeEntry());
            NotifyPropertyChanged.RaisePropertyChanged(() => EroeffnungsGrund);

            BaKlientensystemService klisysService = Container.Resolve<BaKlientensystemService>();

            _klientensystem = new ObservableCollection<BaPerson>(klisysService.GetKlientensystemByFaLeistungId(null, leistungId));
            NotifyPropertyChanged.RaisePropertyChanged(() => Klientensystem);

            LoadData(null);
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            //GetData from Service and Set Entity
            Entity = Service.GetFaLeistungById(unitOfWork, FaLeistungID);
            NotifyPropertyChanged.RaisePropertyChanged(() => Entity);
            NotifyPropertyChanged.RaisePropertyChanged(() => LeistungstraegerNameVorname);
        }

        public override KissServiceResult NewData()
        {
            return new KissServiceResult(KissServiceResult.ResultType.Error, "WshLeistungVM_NoInsert", "Es darf keine neue Leistung angelegt werden");
        }

        public List<object> SearchUser(string searchString)
        {
            if (_userService == null)
            {
                _userService = Container.Resolve<XUserService>();
            }

            return new List<object>(_userService.SearchUser(null, searchString));
        }

        #endregion

        #region Private Methods

        private XLOVCode GetEmptyXLovCodeEntry()
        {
            return new XLOVCode
            {
                Code = -1,
                LOVName = string.Empty,
                Text = string.Empty
            };
        }

        #endregion

        #endregion
    }
}