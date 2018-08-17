using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

using Kiss.BusinessLogic.Interfaces;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.Properties;
using Kiss.Utilities;

using IViewModelCRUD = Kiss.UserInterface.ViewModel.Interfaces.IViewModelCRUD;

namespace Kiss.UserInterface.ViewModel
{
    public class ViewModelCRUD<TEntity, TKey> : ViewModel, IViewModelCRUD, IDataSource
        where TEntity : class, IPocoEntity, IAutoIdentityEntity<int>, new()
    {
        private TEntity _entity;

        public ViewModelCRUD()
        {
        }

        protected ViewModelCRUD(IServiceCRUD<TEntity, TKey> serviceCRUD)
        {
            ServiceCRUD = serviceCRUD;

            Memento = new TEntity();

            DeleteDataCommand = new DelegateCommand(parameter => DeleteData(), parameter => CanDeleteData());
            NewDataCommand = new DelegateCommand(parameter => InsertData(), parameter => CanInsertData());
            SaveDataCommand = new DelegateCommand(parameter => SaveData(), parameter => CanSaveData());
            UndoDataChangesCommand = new DelegateCommand(parameter => UndoDataChanges(), parameter => CanUndoChanges());
            RefreshCommand = new DelegateCommand(x => RefreshData());
            ConfirmDeleteQuestion = ServiceCRUD.ConfirmDeleteQuestion();
        }

        public IDelegateCommand DeleteDataCommand { get; private set; }

        public TEntity Entity
        {
            get { return _entity; }
            protected set
            {
                if (SetProperty(ref _entity, value, () => Entity))
                {
                    SelectedEntityStateObserver = new EntityStateObserver(Entity);
                    CreateMemento(Entity);
                }
            }
        }

        public IDelegateCommand NewDataCommand { get; private set; }

        public IDelegateCommand RefreshCommand { get; private set; }

        public IDelegateCommand SaveDataCommand { get; private set; }

        public IDelegateCommand UndoDataChangesCommand { get; private set; }

        protected string ConfirmDeleteQuestion { get; set; }

        protected TEntity Memento { get; private set; }

        protected EntityStateObserver SelectedEntityStateObserver
        {
            get;
            private set;
        }

        protected IServiceCRUD<TEntity, TKey> ServiceCRUD { get; set; }

        /// <summary>
        /// Executes Tasks before the view can be closed.
        /// Calls the <see cref="SaveData"/> methode
        /// </summary>
        /// <returns><c>false</c> if the data cound not be saved</returns>
        public override bool BeforeCloseView()
        {
            if (!SaveData().IsOk)
            {
                return false;
            }

            return base.BeforeCloseView();
        }

        public IServiceResult DeleteData()
        {
            if (!Maskenrecht.CanDelete && SelectedEntityStateObserver.EntityState != EntityState.Added)
            {
                ValidationResult = new ServiceResult(ServiceResultType.Error, Resources.NoRightToRemove);
                return ValidationResult;
            }

            if (ConfirmDeleteQuestion != null)
            {
                var options = new List<QuestionAnswerOption> { new QuestionAnswerOption(true, Resources.QuestionTextYes), new QuestionAnswerOption(false, Resources.QuestionTextNo) };
                var answer = RaiseQuestion(ConfirmDeleteQuestion, options, false);
                if (answer == null || !(bool)answer.Tag)
                {
                    return ServiceResult.Ok();
                }
            }

            return DeleteDataWithoutCheckingRights();
        }

        public virtual IServiceResult InsertData()
        {
            if (!Maskenrecht.CanInsert)
            {
                ValidationResult = new ServiceResult(ServiceResultType.Error, Resources.NoRightToAdd);
                return ValidationResult;
            }

            var newEntity = CreateAndInitNewEntity();
            if (newEntity != null)
            {
                SetAuditProperties(newEntity);
                Entity = newEntity;
            }

            ValidationResult = ServiceResult.Ok();
            return ServiceResult.Ok();
        }

        public virtual void RefreshData()
        {
            Init(_initParameters);
        }

        public virtual IServiceResult ValidateUnChangedData()
        {
            if (Entity == null || SelectedEntityStateObserver == null)
            {
                return ServiceResult.Ok();
            }
            ValidationResult = ServiceCRUD.ValidateUnChangedEntities(Entity);
            return ValidationResult;
        }


        public virtual IServiceResult SaveData()
        {
            if (Entity == null || SelectedEntityStateObserver == null)
            {
                return ServiceResult.Ok();
            }

            if (!IsSelectedEntityTreeModified())
            {
                return ServiceResult.Ok();
            }

            var state = SelectedEntityStateObserver.EntityState;

            if (!Maskenrecht.CanUpdate && (state != EntityState.Added || !Maskenrecht.CanInsert))
            {
                ValidationResult = new ServiceResult(ServiceResultType.Error, Resources.NoRightToSave);
                return ValidationResult;
            }

            ValidationResult = ValidateBeforeSave();

            if (ValidationResult.IsOk)
            {
                ValidationResult = ServiceCRUD.SaveEntity(Entity);
            }

            if (ValidationResult.IsOk)
            {
                SelectedEntityStateObserver.SetUnchanged();
                CreateMemento(Entity);
            }

            return ValidationResult;
        }

        /// <summary>
        /// <see cref="IViewModelCRUD"/>
        /// </summary>
        public bool UndoDataChanges()
        {
            //The selected entity did not change.
            if (SelectedEntityStateObserver == null ||
                SelectedEntityStateObserver.EntityState == EntityState.Unchanged)
            {
                return true;
            }

            if (SelectedEntityStateObserver.EntityState == EntityState.Added)
            {
                return DeleteDataWithoutCheckingRights().IsOk();
            }

            var mementoTmp = Memento;
            Entity = mementoTmp;

            //reset the ValidationResult after the 'undo'
            ValidationResult = ServiceResult.Ok();

            return true;
        }

        public virtual IServiceResult ValidateBeforeSave()
        {
            return ServiceResult.Ok();
        }

        protected static void SetAuditProperties(TEntity newEntity)
        {
            var auditableEntity = newEntity as IAuditableEntity;
            if (auditableEntity == null && newEntity is IEntityWrapper<TEntity>)
            {
                auditableEntity = ((IEntityWrapper<TEntity>)newEntity).WrappedEntity as IAuditableEntity;
            }
            if (auditableEntity != null)
            {
                var userText = Infrastructure.IoC.Container.Resolve<ISessionService>().AuthenticatedUser.CreatorModifier;
                auditableEntity.Created = DateTime.Now;
                auditableEntity.Creator = userText;

                // ToDo: konsistent mit unitofwork.savechanges()
                //if (newEntity.AutoIdentityID > 0)
                {
                    auditableEntity.Modified = auditableEntity.Created;
                    auditableEntity.Modifier = auditableEntity.Creator;
                }
            }
        }

        protected virtual bool CanDeleteData()
        {
            return Maskenrecht.CanDelete ||
                   SelectedEntityStateObserver != null && SelectedEntityStateObserver.EntityState == EntityState.Added;
        }

        protected virtual bool CanInsertData()
        {
            return Maskenrecht.CanInsert;
        }

        protected virtual bool CanSaveData()
        {
            return Entity != null;
        }

        protected virtual bool CanUndoChanges()
        {
            return SelectedEntityStateObserver != null && SelectedEntityStateObserver.EntityState != EntityState.Unchanged;
        }

        protected virtual TEntity CreateAndInitNewEntity()
        {
            var newEntity = new TEntity();
            InitNewEntity(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Creates a snapshot of an entity and stores it
        /// in the memeto.
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CreateMemento(TEntity entity)
        {
            Memento = ObjectCloner.Clone(entity);
        }

        /// <summary>
        /// Gets called at the end of <see cref="Init"/> (after <see cref="InitAsync"/> and <see cref="UpdateMaskenRecht"/>).
        /// Additionally sets the current entity state to unchanged.
        /// </summary>
        protected override void InitCompleted()
        {
            base.InitCompleted();

            if (SelectedEntityStateObserver != null)
            {
                SelectedEntityStateObserver.SetUnchangedIfModified();
            }
        }

        protected virtual void InitNewEntity(TEntity entity)
        {
        }

        /// <summary>
        /// Determines if the selected entity is in a modified state.
        /// Overwrite this method if multiple entities are involved
        /// (a child entity of the current entity).
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsSelectedEntityTreeModified()
        {
            if (SelectedEntityStateObserver == null)
            {
                return false;
            }

            var state = SelectedEntityStateObserver.EntityState;
            return state != EntityState.Unchanged && state != EntityState.Deleted;
        }

        private IServiceResult DeleteDataWithoutCheckingRights()
        {
            if (SelectedEntityStateObserver == null)
            {
                return new ServiceResult(ServiceResultType.Error, "There is no currently selected Entity");
            }

            if (SelectedEntityStateObserver.EntityState != EntityState.Added)
            {
                ValidationResult = ServiceCRUD.DeleteEntity(Entity);
            }
            else
            {
                ValidationResult = ServiceResult.Ok();
            }

            SelectedEntityStateObserver.SetDeleted();

            return ValidationResult;
        }

        #region IDataSource

        bool IDataSource.AllowSelectionChanging { get; set; }

        bool IDataSource.CanUpdate
        {
            get { return Maskenrecht.CanUpdate; }
            set { Maskenrecht.CanUpdate = value; }
        }

        DataRowState IDataSource.CurrentRowState
        {
            get
            {
                if (!((IDataSource)this).HasRow)
                {
                    return DataRowState.Detached;
                }

                switch (SelectedEntityStateObserver.EntityState)
                {
                    case EntityState.Detached:
                        return DataRowState.Detached;
                    case EntityState.Unchanged:
                        return DataRowState.Unchanged;
                    case EntityState.Added:
                        return DataRowState.Added;
                    case EntityState.Deleted:
                        return DataRowState.Deleted;
                    case EntityState.Modified:
                        return DataRowState.Modified;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        bool IDataSource.HasRow
        {
            get { return Entity != null; }
        }

        bool IDataSource.IsEmpty
        {
            get { return Entity == null; }
        }

        bool IDataSource.RowModified
        {
            get { return ((IDataSource)this).CurrentRowState != DataRowState.Unchanged; }
            set
            {
                if (!((IDataSource)this).HasRow || SelectedEntityStateObserver == null)
                {
                    return;
                }

                if (value)
                {
                    if (((IDataSource)this).CurrentRowState == DataRowState.Added)
                    {
                        SelectedEntityStateObserver.SetAdded();
                    }
                    else
                    {
                        SelectedEntityStateObserver.SetModified();
                    }
                }
                else
                {
                    SelectedEntityStateObserver.SetUnchanged();
                }
            }
        }

        object IDataSource.this[string columnName]
        {
            get { return PropertyValue.GetPropertyValue(Entity, columnName); }
            set
            {
                if (value == DBNull.Value)
                {
                    PropertyValue.SetPropertyValue(Entity, columnName, null);
                }
                else
                {
                    PropertyValue.SetPropertyValue(Entity, columnName, value);
                }
            }
        }

        bool IDataSource.Post()
        {
            return ((IDataSource)this).Post(true, false);
        }

        bool IDataSource.Post(bool performEndEditGrids, bool isSilentPosting)
        {
            return SaveData().IsOk;
        }

        #endregion
    }
}