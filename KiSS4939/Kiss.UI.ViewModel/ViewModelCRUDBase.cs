using System;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.ViewModel;
using Kiss.Utilities;

namespace Kiss.UI.ViewModel
{
    public abstract class ViewModelCRUDBase<TEntity> : ViewModelBase, IViewModelCRUD
        where TEntity : class, new()
    {
        #region Constructors

        internal ViewModelCRUDBase(IServiceCRUD<TEntity> serviceCRUD)
        {
            Memento = new TEntity();
            if (serviceCRUD == null)
            {
                throw new ArgumentNullException("serviceCRUD");
            }

            ServiceCRUD = serviceCRUD;
        }

        #endregion

        #region Properties

        public IServiceCRUD<TEntity> ServiceCRUD
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

        public abstract KissServiceResult DeleteData(IUnitOfWork unitOfWork);

        public abstract void LoadData(IUnitOfWork unitOfWork);

        public abstract KissServiceResult NewData();

        public abstract void RefreshData();

        public abstract KissServiceResult SaveData(IUnitOfWork unitOfWork);

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
    }
}