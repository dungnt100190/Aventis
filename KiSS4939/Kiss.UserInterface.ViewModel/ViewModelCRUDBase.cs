using System;
using Kiss.BusinessLogic.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.Interfaces;
using Kiss.Utilities;

namespace Kiss.UserInterface.ViewModel
{
    public abstract class ViewModelCRUDBase<TEntity, TKey> : ViewModel, IViewModelCRUD
        where TEntity : class, new()
    {
        #region Constructors

        internal ViewModelCRUDBase(IServiceCRUD<TEntity, TKey> serviceCRUD)
        {
            Memento = new TEntity();
            if (serviceCRUD == null)
            {
                throw new ArgumentNullException("serviceCRUD");
            }

            ServiceCRUD = serviceCRUD;

            DeleteDataTask = new AsyncTask(parameter => DeleteData());
            LoadDataTask = new AsyncTask(parameter => LoadData());
            NewDataTask = new AsyncTask(parameter => NewData());
            SaveDataTask = new AsyncTask(parameter => SaveData());
            UndoDataChangesTask = new AsyncTask(parameter => UndoDataChanges());
        }

        #endregion

        #region Properties

        public IServiceCRUD<TEntity, TKey> ServiceCRUD
        {
            get;
            protected set;
        }

        /// <summary>
        /// Memento for undo operation.
        /// </summary>
        protected TEntity Memento
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public abstract KissServiceResult DeleteData();

        public abstract void LoadData();

        public abstract KissServiceResult NewData();

        public abstract void RefreshData();

        public abstract KissServiceResult SaveData();

        public abstract bool UndoDataChanges();

        #endregion

        #region Protected Methods

        /// <summary>
        /// Creates a snapshot of an entity and stores it
        /// in the memeto.
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CreateMemento(TEntity entity)
        {
            Memento = ObjectCloner.Clone(entity);
        }

        #endregion

        #endregion

        public IAsyncTask DeleteDataTask { get; private set; }
        public IAsyncTask LoadDataTask { get; private set; }
        public IAsyncTask NewDataTask { get; private set; }
        public IAsyncTask SaveDataTask { get; private set; }
        public IAsyncTask UndoDataChangesTask { get; private set; }
    }
}