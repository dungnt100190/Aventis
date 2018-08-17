using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Kes;
using Kiss.BusinessLogic.Sys;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesMassnahmeBerichtVM : ViewModelSearchListCRUD<KesMassnahmeBericht, KesMassnahmeBericht, int, int>
    {
        private int _baPersonId;

        //private bool _inclDeleted;
        private KesMassnahme _kesMassnahme;

        private IList<XLOVCode> _kesMassnahmeBerichtsartList;

        public KesMassnahmeBerichtVM()
            : base(Container.Resolve<KesMassnahmeBerichtService>())
        {
            RequiredParameters = InitParameterValue.CustomData;
            RefreshAfterSetInclDeleted = false;
        }

        //public bool InclDeleted
        //{
        //    get { return _inclDeleted; }
        //    set
        //    {
        //        SetProperty(ref _inclDeleted, value, () => InclDeleted);
        //        NotifyPropertyChanged.RaisePropertyChanged(() => InclDeleted);
        //    }
        //}

        public IList<XLOVCode> KesMassnahmeBerichtsartList
        {
            get { return _kesMassnahmeBerichtsartList; }
            set { SetProperty(ref _kesMassnahmeBerichtsartList, value, () => KesMassnahmeBerichtsartList); }
        }

        private KesMassnahmeBerichtService Service
        {
            get { return (KesMassnahmeBerichtService)ServiceCRUD; }
        }

        public override object GetContextValue(string fieldName)
        {
            switch (fieldName.ToUpper())
            {
                case "BAPERSONID":
                    return _baPersonId;

                case "KESMASSNAHMEID":
                    return SelectedEntity.KesMassnahmeID;

                case "KESMASSNAHMEBERICHTID":
                    return SelectedEntity.KesMassnahmeBerichtID;

                default:
                    return base.GetContextValue(fieldName);
            }
        }

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            var dictionary = initParameters.Value.CustomData;

            object kesMassnahme;
            object inclDeleted;
            if (!dictionary.TryGetValue(KesMassnahmeVM.KEY_KES_MASSNAHME, out kesMassnahme) || !dictionary.TryGetValue(KesMassnahmeVM.KEY_INCL_DELETED, out inclDeleted))
            {
                return;
            }

            _kesMassnahme = kesMassnahme as KesMassnahme;
            if (_kesMassnahme == null)
            {
                return;
            }

            InclDeleted = inclDeleted as bool? ?? false;

            _baPersonId = initParameters.Value.BaPersonID.Value;

            AddViewRightInterceptor(new KesMaskenrechtInterceptor(_kesMassnahme.FaLeistungID));

            var lovService = Container.Resolve<XLovService>();
            KesMassnahmeBerichtsartList = lovService.GetLovCodesByLovName("KesMassnahmeBerichtsart", true, true);

            SearchParameters = _kesMassnahme.KesMassnahmeID;
            SearchTask.StartCommand.Execute();
        }

        protected override void InitNewEntity(KesMassnahmeBericht entity)
        {
            base.InitNewEntity(entity);
            entity.KesMassnahme = _kesMassnahme;
            entity.KesMassnahmeBerichtsartCode = 1;
            var maxDatumBis = EntityList.Max(ber => ber.DatumBis);
            if (maxDatumBis.HasValue)
            {
                entity.DatumVon = maxDatumBis.Value.AddDays(1);
                entity.DatumBis = maxDatumBis.Value.AddYears(2);
            }
        }

        protected override IServiceResult<IEnumerable<KesMassnahmeBericht>> SearchInBackground(int kesMassnahmeId, CancellationToken cancellationToken)
        {
            return new ServiceResult<IEnumerable<KesMassnahmeBericht>>(Service.GetByKesMassnahmeId(kesMassnahmeId, InclDeleted));
        }
    }
}