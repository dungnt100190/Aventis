using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Kiss.BL.Fs;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;
using Kiss.BL.KissSystem;

namespace Kiss.UI.ViewModel.Fs
{
    public class FsDienstleistungspaketVM : ViewModelCRUDListBase<FsDienstleistungspaket>
    {
        #region Fields

        #region Private Fields

        //Memento für zugewiesene Dienstleistungen (undo Funktion).
        private List<FsDienstleistung> _mementoAssignedDienstleistungen;

        #endregion

        #endregion

        #region Constructors

        public FsDienstleistungspaketVM()
            : base(Container.Resolve<FsDienstleistungspaketService>())
        {
            AssignedDienstleistungen = new ObservableCollection<FsDienstleistung>();
            SelectedEntityChanged += FsDienstleistungspaketVM_SelectedEntityChanged;
            AssignedDienstleistungen.CollectionChanged += assignedDienstleistungen_CollectionChanged;
        }

        #endregion

        #region Properties

        public ObservableCollection<FsDienstleistung> AssignedDienstleistungen
        {
            get;
            private set;
        }

        public List<FsDienstleistung> AvailableDienstleistungen
        {
            get { return Container.Resolve<FsDienstleistungService>().GetData(null).ToList(); }
        }

        private FsDienstleistungspaketService Service
        {
            get { return (FsDienstleistungspaketService)ServiceCRUD; }
        }

        #endregion

        #region EventHandlers

        void FsDienstleistungspaketVM_SelectedEntityChanged(FsDienstleistungspaket selectedEntity, FsDienstleistungspaket deselectedEntity)
        {
            if (selectedEntity != null)
            {
                AssignedDienstleistungen.CollectionChanged -= assignedDienstleistungen_CollectionChanged;
                AssignedDienstleistungen.Clear();

                GetAssignedDienstleistungen(selectedEntity)
                    .ForEach(dl => AssignedDienstleistungen.Add(dl));

                AssignedDienstleistungen.CollectionChanged += assignedDienstleistungen_CollectionChanged;
            }
        }

        void assignedDienstleistungen_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (SelectedEntity != null)
            {
                if (SelectedEntity.ChangeTracker.State == ObjectState.Unchanged)
                {
                    SelectedEntity.ChangeTracker.State = ObjectState.Modified;
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Returns the assigned <see cref="FsDienstleistung"/> entities of the current selected DLP entity
        /// </summary>
        /// <returns>Assigned <see cref="FsDienstleistung"/> entities of the current selected DLP or null</returns>
        public List<FsDienstleistung> GetAssignedDienstleistungen(FsDienstleistungspaket dlp)
        {
            return dlp == null ? null : Service.GetAssignedDienstleistungen(null, dlp.FsDienstleistungspaketID);
        }

        public void Init()
        {
            LoadData(null);
        }

        public override void LoadData(IUnitOfWork unitOfWork)
        {
            EntityList = Service.GetData(null);
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            KissServiceResult result = base.SaveData(unitOfWork);

            if (SelectedEntity != null)
            {
                result += Service.SaveAssignedDienstleistungen(unitOfWork, SelectedEntity, AssignedDienstleistungen.ToList());
            }
            return result;
        }

        /// <summary>
        /// Undoes all changes back to the last save or
        /// show operation.        
        /// </summary>
        /// <returns></returns>
        public override bool UndoDataChanges()
        {
            base.UndoDataChanges();
            AssignedDienstleistungen.Clear();
            _mementoAssignedDienstleistungen.ForEach(x => AssignedDienstleistungen.Add(x));
            return true;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates a snapshot for the undo functionality.
        /// </summary>
        /// <param name="entity"></param>
        protected override void CreateMemento(FsDienstleistungspaket entity)
        {
            base.CreateMemento(entity);
            _mementoAssignedDienstleistungen = new List<FsDienstleistung>();
            AssignedDienstleistungen.ToList().ForEach(x => _mementoAssignedDienstleistungen.Add(x));
        }

        #endregion

        #endregion
    }
}