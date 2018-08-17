using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Kiss.BusinessLogic.Fa;

using Kiss.BusinessLogic.Fa;

using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesLeistungVM : ViewModelCRUD<FaLeistung, int>
    {
        private const string GEMEINDE_SOZIALDIENST = "GemeindeSozialdienst";
        private const string KES_ABSCHLUSSGRUND = "KesAbschlussgrund";
        private const string KES_EROEFFNUNGSSGRUND = "EroeffnungsGrund";

        private int _baPersonId;
        private int _faLeistungId;
        private bool _isLeistungArchiviert;
        private IList<XLOVCode> _kesAbschlussgrund;
        private IList<XLOVCode> _kesEroeffnungsgrund;
        private bool _leistungAktiv;
        private XUser _selectedUser;
        private string _titleName;
        private IList<XLOVCode> _zustaendigeGemeinde;

        public KesLeistungVM()
            : base(Container.Resolve<KesLeistungService>())
        {
            RequiredParameters = InitParameterValue.BaPersonID | InitParameterValue.FaLeistungID | InitParameterValue.Title;
        }

        public int BaPersonId
        {
            get { return _baPersonId; }
            private set
            {
                SetProperty(ref _baPersonId, value, () => BaPersonId);
            }
        }

        public bool ButtonAbschliessenAktiv
        {
            get
            {
                return !LeistungAktiv;
            }
        }

        public bool ButtonAbschliessenEnabled
        {
            get
            {
                return !IsLeistungArchiviert;
            }
        }

        public int FaLeistungId
        {
            get { return _faLeistungId; }
            private set { SetProperty(ref _faLeistungId, value, () => FaLeistungId); }
        }

        public bool IsLeistungArchiviert
        {
            get { return _isLeistungArchiviert; }
            private set
            {
                SetProperty(ref _isLeistungArchiviert, value, () => IsLeistungArchiviert);
            }
        }

        public IList<XLOVCode> KesAbschlussgrund
        {
            get { return _kesAbschlussgrund; }
            private set { SetProperty(ref _kesAbschlussgrund, value, () => KesAbschlussgrund); }
        }

        public IList<XLOVCode> KesEroeffnungsgrund
        {
            get { return _kesEroeffnungsgrund; }
            private set { SetProperty(ref _kesEroeffnungsgrund, value, () => KesEroeffnungsgrund); }
        }

        public bool LeistungAktiv
        {
            get { return _leistungAktiv; }
            private set
            {
                SetProperty(ref _leistungAktiv, value, () => LeistungAktiv);
                NotifyPropertyChanged.RaisePropertyChanged(() => ButtonAbschliessenAktiv);
            }
        }

        public XUser SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                if (SetProperty(ref _selectedUser, value, () => SelectedUser))
                {
                    if (_selectedUser != null && Entity != null && Entity.UserID != _selectedUser.UserID)
                    {
                        Entity.UserID = _selectedUser.UserID;
                    }
                }
            }
        }

        public string TitleName
        {
            get { return _titleName; }
            private set
            {
                SetProperty(ref _titleName, value, () => TitleName);
            }
        }

        public IList<XLOVCode> ZustaendigeGemeinde
        {
            get { return _zustaendigeGemeinde; }
            private set { SetProperty(ref _zustaendigeGemeinde, value, () => ZustaendigeGemeinde); }
        }

        private KesLeistungService Service
        {
            get { return (KesLeistungService)ServiceCRUD; }
        }

        public override bool BeforeCloseView()
        {
            if (Maskenrecht.CanUpdate &&
                !ValidateUnChangedData().IsOk)
            {
                return false;
            }
            return base.BeforeCloseView();
        }

        public IServiceResult LeistungWiedereroeffnen()
        {
            Entity.DatumBis = null;
            Entity.AbschlussGrundCode = null;
            return SaveData();
        }

        public override IServiceResult SaveData()
        {
            var entityState = SelectedEntityStateObserver.EntityState;

            var result = base.SaveData();

            if (result.IsOk && entityState != EntityState.Unchanged)
            {
                RefreshFallNavigator();
            }

            return result;
        }

        public override IServiceResult ValidateBeforeSave()
        {
            IServiceResult result = new ServiceResult(ServiceResultType.Ok);

            if (Entity.DatumBis != null)
            {
                result = Service.AbschlussPruefung(Entity);
            }

            return result;
        }

        protected override bool CanDeleteData()
        {
            return false;
        }

        protected override bool CanInsertData()
        {
            return false;
        }

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            FaLeistungId = initParameters.Value.FaLeistungID.Value;
            BaPersonId = initParameters.Value.BaPersonID.Value;
            TitleName = initParameters.Value.Title;

            var xlovService = Container.Resolve<XLovService>();
            KesAbschlussgrund = xlovService.GetLovCodesByLovName(KES_ABSCHLUSSGRUND, true, true);
            KesEroeffnungsgrund = xlovService.GetLovCodesByLovName(KES_EROEFFNUNGSSGRUND, true, true, "M");
            var gemeindeLookup = xlovService.GetLovCodesByLovName(GEMEINDE_SOZIALDIENST, false, true);
            ZustaendigeGemeinde = gemeindeLookup.Where(loc => loc.Value3 == null || ("," + loc.Value3 + ",").Contains(",M,")).ToList();

            Entity = Service.GetEntityById(FaLeistungId);
            UpdateLeistungAktiv();
            var userService = Container.Resolve<XUserService>();
            SelectedUser = userService.GetEntityById(Entity.UserID);

            if (ZustaendigeGemeinde != null && ZustaendigeGemeinde.Count == 1
                && Entity.GemeindeCode == null)
            {
                //wenn nur eine Gemeinde zur Auswahl steht, dann gleich auswählen
                Entity.GemeindeCode = ZustaendigeGemeinde.First().Code;
            }

            var faLeistungArchivService = Container.Resolve<FaLeistungArchivService>();
            IsLeistungArchiviert = faLeistungArchivService.IsLeistungArchiviert(Entity.FaLeistungID);
        }

        protected override bool IsSelectedEntityTreeModified()
        {
            if (!Entity.GemeindeCode.HasValue)
            {
                return true;
            }

            return base.IsSelectedEntityTreeModified();
        }

        private void RefreshFallNavigator()
        {
            UpdateLeistungAktiv();

            var formController = Container.Resolve<IKissFormController>();
            formController.SendMessage("FrmFallNavigator", "Action", "RefreshTree");
            formController.SendMessage("FrmFall", "Action", "RefreshTree");
        }

        private void UpdateLeistungAktiv()
        {
            LeistungAktiv = (Entity.DatumBis == null);
        }
    }
}