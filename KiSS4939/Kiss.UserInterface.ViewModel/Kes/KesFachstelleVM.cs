using System.Collections.Generic;
using System.Threading.Tasks;

using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Kes;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Kes;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesFachstelleVM : ViewModelSearchListCRUD<KesMassnahme, KesMassnahme, int, int>
    {
        private const int TAB_INDEX_UEBERSICHT = 0;
        private const int TAB_INDEX_VERLAUF = 1;

        private KesFachstelleMassnahmeVM _kesFachstelleMassnahmeVM;
        private KesVerlaufVM _kesVerlaufVM;
        private int _selectedTabIndex;
        private string _title;

        public KesFachstelleVM()
            : base(Container.Resolve<KesMassnahmeService>())
        {
            RequiredParameters = InitParameterValue.BaPersonID | InitParameterValue.FaLeistungID | InitParameterValue.Title;

            KesFachstelleMassnahmeVM = new KesFachstelleMassnahmeVM();
            KesVerlaufVM = new KesVerlaufVM(KesVerlaufTyp.PriMaBegleitung);
        }

        public KesFachstelleMassnahmeVM KesFachstelleMassnahmeVM
        {
            get { return _kesFachstelleMassnahmeVM; }
            set { SetProperty(ref _kesFachstelleMassnahmeVM, value, () => KesFachstelleMassnahmeVM); }
        }

        public KesVerlaufVM KesVerlaufVM
        {
            get { return _kesVerlaufVM; }
            set { SetProperty(ref _kesVerlaufVM, value, () => KesVerlaufVM); }
        }

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set { SetProperty(ref _selectedTabIndex, value, () => SelectedTabIndex); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value, () => Title); }
        }

        public override bool CanDeleteData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.CanDeleteData();
            }

            return false;
        }

        public override bool CanInsertData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.CanInsertData();
            }

            return ServiceResult.Ok();
        }

        public override bool CanSaveData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.CanSaveData();
            }

            return KesFachstelleMassnahmeVM.CanSaveData();
        }

        public override bool CanUndoChanges()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.CanUndoChanges();
            }

            return KesFachstelleMassnahmeVM.CanUndoChanges();
        }

        public override IServiceResult DeleteData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.DeleteData();
            }

            return ServiceResult.Ok();
        }

        public override IServiceResult InsertData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.InsertData();
            }

            return ServiceResult.Ok();
        }

        public override void RefreshData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                KesVerlaufVM.RefreshData();
            }
            KesFachstelleMassnahmeVM.RefreshData();
        }

        public override IServiceResult SaveData()
        {
            var result = KesFachstelleMassnahmeVM.SaveData();

            if (!result.IsOk)
            {
                SelectedTabIndex = TAB_INDEX_UEBERSICHT;
                return result;
            }

            result = KesVerlaufVM.SaveData();

            if (!result.IsOk)
            {
                SelectedTabIndex = TAB_INDEX_VERLAUF;
                return result;
            }

            return base.SaveData();
        }

        protected async override Task InitAsync(InitParameters? initParameters = null)
        {
            Title = initParameters.Value.Title;

            AddViewRightInterceptor(new KesMaskenrechtInterceptor(initParameters.Value.FaLeistungID.Value));

            KesFachstelleMassnahmeVM.Init(initParameters);
            KesVerlaufVM.Init(initParameters);
        }
    }
}