using System.Threading.Tasks;

using Kiss.BusinessLogic.Kes;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Kes;
using Kiss.Infrastructure.IoC;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;

namespace Kiss.UserInterface.ViewModel.Kes
{
    public class KesPflegekinderaufsichtVM : ViewModelSearchListCRUD<KesPflegekinderaufsicht, KesPflegekinderaufsicht, int, int>
    {
        private const int TAB_INDEX_ERFASSEN = 0;
        private const int TAB_INDEX_VERLAUF = 1;
        private KesPflegekinderaufsichtErfassenVM _kesPflegekinderaufsichtErfassenVM;
        private KesVerlaufVM _kesVerlaufVM;
        private int _selectedTabIndex;
        private string _title;

        public KesPflegekinderaufsichtVM()
            : base(Container.Resolve<KesPflegekinderaufsichtService>())
        {
            RequiredParameters = InitParameterValue.BaPersonID | InitParameterValue.FaLeistungID | InitParameterValue.Title;

            KesPflegekinderaufsichtErfassenVM = new KesPflegekinderaufsichtErfassenVM();
            KesVerlaufVM = new KesVerlaufVM(KesVerlaufTyp.Pflegekinderaufsicht);
        }

        public KesPflegekinderaufsichtErfassenVM KesPflegekinderaufsichtErfassenVM
        {
            get { return _kesPflegekinderaufsichtErfassenVM; }
            set { SetProperty(ref _kesPflegekinderaufsichtErfassenVM, value, () => KesPflegekinderaufsichtErfassenVM); }
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

            return KesPflegekinderaufsichtErfassenVM.CanDeleteData();
        }

        public override bool CanInsertData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.CanInsertData();
            }

            return KesPflegekinderaufsichtErfassenVM.CanInsertData();
        }

        public override bool CanSaveData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.CanSaveData();
            }

            return KesPflegekinderaufsichtErfassenVM.CanSaveData();
        }

        public override bool CanUndoChanges()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.CanUndoChanges();
            }

            return KesPflegekinderaufsichtErfassenVM.CanUndoChanges();
        }

        public override IServiceResult DeleteData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.DeleteData();
            }

            return KesPflegekinderaufsichtErfassenVM.DeleteData();
        }

        public override IServiceResult InsertData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                return KesVerlaufVM.InsertData();
            }

            return KesPflegekinderaufsichtErfassenVM.InsertData();
        }

        public override void RefreshData()
        {
            if (SelectedTabIndex == TAB_INDEX_VERLAUF)
            {
                KesVerlaufVM.RefreshData();
            }

            KesPflegekinderaufsichtErfassenVM.RefreshData();
        }

        public override IServiceResult SaveData()
        {
            var result = KesPflegekinderaufsichtErfassenVM.SaveData();

            if (!result.IsOk)
            {
                SelectedTabIndex = TAB_INDEX_ERFASSEN;
                return result;
            }

            result = KesVerlaufVM.SaveData();

            if (!result.IsOk)
            {
                SelectedTabIndex = TAB_INDEX_VERLAUF;
                return result;
            }

            return result;
        }

        protected async override Task InitAsync(InitParameters? initParameters = null)
        {
            Title = initParameters.Value.Title;

            AddViewRightInterceptor(new KesMaskenrechtInterceptor(initParameters.Value.FaLeistungID.Value));

            KesPflegekinderaufsichtErfassenVM.Init(initParameters);
            KesVerlaufVM.Init(initParameters);
        }
    }
}