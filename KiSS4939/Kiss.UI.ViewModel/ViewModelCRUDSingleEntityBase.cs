using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Kiss.Interfaces.BL;
using Kiss.Model;

namespace Kiss.UI.ViewModel
{
    public abstract class ViewModelCRUDSingleEntityBase<TEntity> : ViewModelCRUDBase<TEntity>
        where TEntity : class, IObjectWithChangeTracker, new()
    {
        #region Fields

        #region Private Fields

        private TEntity _entity;

        #endregion

        #endregion

        #region Constructors

        protected ViewModelCRUDSingleEntityBase(IServiceCRUD<TEntity> serviceCRUD)
            : base(serviceCRUD)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// The main entity which currently is edited. E.g. for a BaPersonViewModel, this would be a BaPerson-Entity
        /// </summary>
        public TEntity Entity
        {
            get { return _entity; }
            protected set
            {
                if (_entity == value)
                {
                    return;
                }
                _entity = value;
                CreateMemento(_entity);
                NotifyPropertyChanged.RaisePropertyChanged(() => Entity);
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            var result = ServiceCRUD.DeleteData(unitOfWork, Entity);
            ValidationResult = result;
            return result;
        }

        public override KissServiceResult NewData()
        {
            TEntity newData;

            KissServiceResult retValue = ServiceCRUD.NewData(out newData);

            if (retValue)
            {
                Entity = newData;
            }
            ValidationResult = retValue;
            return retValue;
        }

        public override void RefreshData()
        {
            // Default is NoOp => The specific ViewModel may override and implement this method
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            ValidationResult = ServiceCRUD.SaveData(unitOfWork, Entity);
            if (ValidationResult.IsOk)
            {
                CreateMemento(Entity);
            }
            return ValidationResult;
        }

        /// <summary>
        /// See interface IViewModelCRUD.
        /// </summary>
        public override bool UndoDataChanges()
        {
            if (Memento != null)
            {
                Entity = Memento;
                ValidationResult = KissServiceResult.Ok();
                return true;
            }
            return false;
        }

        #endregion

        #endregion
    }
}