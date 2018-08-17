using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;
using Kiss.BusinessLogic.Interfaces;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.Interfaces;
using Kiss.UserInterface.ViewModel.Properties;
using Kiss.Utilities;

namespace Kiss.UserInterface.ViewModel
{
    public abstract class ViewModelSearchListCRUD<TEntityList, TEntityService, TSearchParams, TKey> : ViewModelSearchList<TEntityList, TSearchParams>, IViewModelCRUD, IDataSource
        where TEntityList : class, INotifyPropertyChanged, IAutoIdentityEntity<int>
        where TEntityService : class, IPocoEntity, IAutoIdentityEntity<int>, new()
    {
        public const string NAME = "ViewModelSearchListCRUD";
        public const string PARAMETER_FIND_ENTITY = "FindEntity";
        public const string PARAMETER_SELECTED_TAB_INDEX = "SelectedTabIndex";
        private readonly Dictionary<string, List<string>> _entityPropertyMap;
        private bool _inclDeleted;

        protected ViewModelSearchListCRUD(IServiceCRUD<TEntityService, TKey> serviceCRUD)
        {
            if (Debugger.IsAttached)
            {
                if (!typeof(TEntityList).IsDefined(typeof(DataContractAttribute), true))
                {
                    Debugger.Break();
                    throw new NotImplementedException("the DataContract attribute is not defined on type TEntityList. The Memento can't be used for the serialization.");
                }
            }

            ServiceCRUD = serviceCRUD;
            RefreshAfterSave = false;
            RefreshAfterSetInclDeleted = true;

            DeleteDataCommand = new DelegateCommand(parameter => DeleteData(), parameter => CanDeleteData());
            NewDataCommand = new DelegateCommand(parameter => InsertData(), parameter => CanInsertData());
            SaveDataCommand = new DelegateCommand(parameter => ValidationResult = SaveData(), parameter => CanSaveData());
            UndoDataChangesCommand = new DelegateCommand(parameter => UndoDataChanges(), parameter => CanUndoChanges());

            _entityPropertyMap = new Dictionary<string, List<string>>();

            ConfirmDeleteQuestion = ServiceCRUD.ConfirmDeleteQuestion();

            var configService = Kiss.Infrastructure.IoC.Container.Resolve<XConfigService>();
            IsLogischesLoeschen = configService.GetConfigValue(ConfigNodes.System_Fallfuehrung_LogischesLoeschen);
        }

        public event SelectedEntityChanged<TEntityList> SelectedEntityChanged;

        public IDelegateCommand DeleteDataCommand { get; private set; }

        // ToDo: in Basisklasse auslagerbar?
        public override bool HasMaskRight
        {
            get
            {
                return base.HasMaskRight ||
                       ((Maskenrecht.CanInsert) &&
                        (SelectedEntityStateObserver != null && SelectedEntityStateObserver.EntityState == EntityState.Added)); // HACK: EntityState ist in HasMaskRight unlogisch
            }
        }

        /// <summary>
        /// Get flag if datasource has a Row instance
        /// </summary>
        public bool HasRow
        {
            get { return EntityListView.CurrentItem != null; }
        }

        public virtual bool InclDeleted
        {
            get { return _inclDeleted; }
            set
            {
                SetProperty(ref _inclDeleted, value, () => InclDeleted);
                NotifyPropertyChanged.RaisePropertyChanged(() => InclDeleted);

                if (RefreshAfterSetInclDeleted)
                {
                    RefreshData();
                }
            }
        }

        /// <summary>
        /// Property, ob logisch gelöscht werden soll.
        /// Siehe: System\Fallfuehrung\LogischesLoeschen
        /// </summary>
        public bool IsLogischesLoeschen { get; private set; }

        public IDelegateCommand NewDataCommand { get; private set; }
        public bool RefreshAfterSetInclDeleted { get; set; }
        public IDelegateCommand SaveDataCommand { get; private set; }

        public IDelegateCommand UndoDataChangesCommand { get; private set; }

        protected string ConfirmDeleteQuestion { get; set; }

        /// <summary>
        /// Memento for undo operation.
        /// </summary>
        protected TEntityList Memento { get; private set; }

        protected bool RefreshAfterSave { get; set; }

        protected IServiceCRUD<TEntityService, TKey> ServiceCRUD { get; set; }

        /// <summary>
        /// Executes Tasks before the view can be closed.
        /// Calls the <see cref="SaveData"/> methode
        /// </summary>
        /// <returns><c>false</c> if the data cound not be saved</returns>
        public override bool BeforeCloseView()
        {
            ValidationResult = SaveData();
            if (!ValidationResult.IsOk)
            {
                return false;
            }

            return base.BeforeCloseView();
        }

        public virtual bool CanDeleteData()
        {
            return Maskenrecht.CanDelete ||
                   SelectedEntityStateObserver != null && SelectedEntityStateObserver.EntityState == EntityState.Added;
        }

        public virtual bool CanInsertData()
        {
            return Maskenrecht.CanInsert;
        }

        public virtual bool CanSaveData()
        {
            return EntityListView.CurrentItem != null;
        }

        public virtual bool CanUndoChanges()
        {
            return SelectedEntityStateObserver != null && SelectedEntityStateObserver.EntityState != EntityState.Unchanged;
        }

        public virtual IServiceResult DeleteData()
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
                EntityList.Add(newEntity);
                EntityListView.MoveCurrentTo(newEntity);
            }

            ValidationResult = ServiceResult.Ok();
            return ServiceResult.Ok();
        }

        public override bool JumpToPath(HybridDictionary parameters)
        {
            if (parameters.Contains(PARAMETER_FIND_ENTITY))
            {
                var findStr = parameters[PARAMETER_FIND_ENTITY] as string;

                if (findStr != null)
                {
                    var findParts = findStr.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                    if (findParts.Length == 2)
                    {
                        // ToDo: await initTask
                        //CompletelyBusyTasks.Await();
                        FindEntity(findParts[0], findParts[1]);
                    }
                }
            }

            return base.JumpToPath(parameters);
        }

        public virtual IServiceResult SaveData()
        {
            if (SelectedEntity == null || SelectedEntityStateObserver == null)
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

            ValidationResult = ServiceCRUD.SaveEntity(ConvertListEntityToServiceEntity(SelectedEntity));

            if (ValidationResult.IsOk)
            {
                SelectedEntityStateObserver.SetUnchanged();
                CreateMemento(SelectedEntity);
                if (RefreshAfterSave)
                {
                    RefreshData();
                }
            }

            return ValidationResult;
        }

        /// <summary>
        /// Handler for INotifyPropertyChanged event of the selected entity.
        /// Control is transfered to virtual method OnSelectedEntityPropertyChanged.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SelectedEntityPropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e)
        {
            string propertyName = e.PropertyName;

            OnSelectedEntityPropertyChanged(propertyName);

            List<string> vmProperties;
            if (_entityPropertyMap != null && _entityPropertyMap.TryGetValue(propertyName, out vmProperties))
            {
                vmProperties.ForEach(NotifyPropertyChanged.RaisePropertyChanged);
            }
        }

        /// <summary>
        /// <see cref="IViewModelCRUD"/>
        /// </summary>
        public virtual bool UndoDataChanges()
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

            var index = EntityList.IndexOf(SelectedEntity);
            if (Memento != null)
            {
                var mementoTmp = Memento;
                EntityList[index] = mementoTmp;
            }

            //reset the ValidationResult after the 'undo'
            ValidationResult = ServiceResult.Ok();

            return true;
        }

        /// <summary>
        /// Determines if the selected entity is in a modified state.
        /// Overwrite this method if multiple entities are involved
        /// (a child entity of the current entity).
        /// </summary>
        /// <returns></returns>
        protected internal virtual bool IsSelectedEntityTreeModified()
        {
            if (SelectedEntityStateObserver == null)
            {
                return false;
            }

            var state = SelectedEntityStateObserver.EntityState;
            return state != EntityState.Unchanged && state != EntityState.Deleted;
        }

        protected static void SetAuditProperties(TEntityList newEntity)
        {
            var auditableEntity = newEntity as IAuditableEntity;
            if (auditableEntity == null && newEntity is IEntityWrapper<TEntityService>)
            {
                auditableEntity = ((IEntityWrapper<TEntityService>)newEntity).WrappedEntity as IAuditableEntity;
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

        protected void AddEntityPropertyMapping<T1, T2>(Expression<Func<T1>> entityProperty, Expression<Func<T2>> viewModelProperty)
        {
            var entityPropertyName = PropertyName.GetPropertyName(entityProperty);
            var viewModelPropertyName = PropertyName.GetPropertyName(viewModelProperty);
            AddEntityPropertyMapping(entityPropertyName, viewModelPropertyName);
        }

        protected void AddEntityPropertyMapping(string entityProperty, string viewModelProperty)
        {
            List<string> derivedProperties;
            if (!_entityPropertyMap.TryGetValue(entityProperty, out derivedProperties))
            {
                derivedProperties = new List<string>();
                _entityPropertyMap.Add(entityProperty, derivedProperties);
            }

            if (!derivedProperties.Contains(viewModelProperty))
            {
                derivedProperties.Add(viewModelProperty);
            }
        }

        protected virtual TEntityService ConvertListEntityToServiceEntity(TEntityList entityList)
        {
            if (entityList == null)
            {
                return null;
            }

            var sameType = entityList as TEntityService;
            if (sameType != null)
            {
                return sameType;
            }

            var wrapper = entityList as IEntityWrapper<TEntityService>;
            if (wrapper != null)
            {
                return wrapper.WrappedEntity;
            }

            throw new Exception(string.Format("Entity of type {0} can not be converted to type {1}", typeof(TEntityList), typeof(TEntityService)));
        }

        protected virtual TEntityList ConvertServiceEntityToListEntity(TEntityService entityService)
        {
            if (entityService == null)
            {
                return null;
            }

            var sameType = entityService as TEntityList;
            if (sameType != null)
            {
                return sameType;
            }

            // constructor with single parameter of type TEntityService
            var constructor = typeof(TEntityList).GetConstructor(new[] { typeof(TEntityService) });
            if (constructor != null)
            {
                return (TEntityList)constructor.Invoke(new object[] { entityService });
            }

            throw new Exception(string.Format("Entity of type {0} can not be converted to type {1}", typeof(TEntityService), typeof(TEntityList)));
        }

        protected virtual TEntityList CreateAndInitNewEntity()
        {
            var newEntity = ConvertServiceEntityToListEntity(new TEntityService());
            InitNewEntity(newEntity);
            return newEntity;
        }

        /// <summary>
        /// Creates a snapshot of an entity and stores it
        /// in the memeto.
        /// </summary>
        /// <param name="entity"></param>
        protected virtual void CreateMemento(TEntityList entity)
        {
            Memento = ObjectCloner.Clone(entity);
        }

        protected virtual void InitNewEntity(TEntityList entity)
        {
        }

        protected override bool IsSelectionChangeAllowed()
        {
            var allowFromBase = base.IsSelectionChangeAllowed();
            if (!allowFromBase)
            {
                return false;
            }

            var deselectedEntity = EntityListView.CurrentItem as TEntityList;
            if (deselectedEntity != null)
            {
                ValidationResult = SaveData();
            }

            return ValidationResult.IsOk;
        }

        /// <summary>
        /// Another entity is selected.
        /// </summary>
        /// <param name="selectedEntity">The now selected entity.</param>
        /// <param name="deselectedEntity">The previously selected entity.</param>
        protected override void OnSelectedEntityChanged(TEntityList selectedEntity, TEntityList deselectedEntity)
        {
            if (deselectedEntity != null)
            {
                deselectedEntity.PropertyChanged -= SelectedEntityPropertyChangedEventHandler;
            }

            if (selectedEntity != null)
            {
                selectedEntity.PropertyChanged += SelectedEntityPropertyChangedEventHandler;
            }

            CreateMemento(selectedEntity);
            if (SelectedEntityChanged != null)
            {
                SelectedEntityChanged(selectedEntity, deselectedEntity);
            }
        }

        /// <summary>
        /// This method is called when a property of the selected entity
        /// changed. Entities implement the INotifyPropertyChanged interface.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnSelectedEntityPropertyChanged(string propertyName)
        {
            //Base classes will overwrite this method.
        }

        /// <summary>
        /// Überprüft, ob der Wert des mit <paramref name="propertyName"/> angegebenen Propertys mit <paramref name="propertyValue"/> übereinstimmt.
        /// <paramref name="propertyName"/> kann auch ein Pfad zu einem Property sein (z.B. "Property1.Property2").
        /// </summary>
        /// <param name="obj">Das zu überprüfende Objekt.</param>
        /// <param name="propertyName">Der Name des Propertys auf dem Objekt.</param>
        /// <param name="propertyValue">Der zu überprüfende Wert.</param>
        /// <returns></returns>
        private static bool CheckPropertyValue(object obj, string propertyName, string propertyValue)
        {
            if (obj == null)
            {
                return false;
            }

            var dotIndex = propertyName.IndexOf('.');
            string currentPropertyName = propertyName;

            if (dotIndex > 0)
            {
                currentPropertyName = propertyName.Substring(0, dotIndex);
            }

            object currentValue;

            try
            {
                var currentProperty = obj.GetType().GetProperty(currentPropertyName);
                currentValue = currentProperty.GetValue(obj, null);
            }
            catch
            {
                currentValue = null;
            }

            if (dotIndex > 0)
            {
                // Recursion to allow property names like "FaLeistung.FaLeistungID"
                return CheckPropertyValue(currentValue, propertyName.Substring(dotIndex + 1, propertyName.Length - dotIndex - 1), propertyValue);
            }

            if (currentValue != null)
            {
                return currentValue.ToString() == propertyValue;
            }

            return false;
        }

        /// <summary>
        /// Copies the values of properties of entity source
        /// to entity target. This method is very simple and needs
        /// imporving.
        /// </summary>
        /// <param name="source">The soruce object. No properties will be changed.</param>
        /// <param name="target">The target objct. Property-values form the source will be transfered to this target.</param>
        private static void CopyProperties(TEntityList source, TEntityList target)
        {
            foreach (PropertyInfo property in typeof(TEntityList).GetProperties())
            {
                if (!property.CanRead || !property.CanWrite)
                {
                    continue;
                }

                try
                {
                    object value = property.GetValue(source, null);
                    property.SetValue(target, value, null);
                }
                catch (TargetInvocationException)
                {
                }
                catch (InvalidOperationException)
                {
                }
            }
        }

        private IServiceResult DeleteDataWithoutCheckingRights()
        {
            if (SelectedEntity == null || SelectedEntityStateObserver == null)
            {
                return new ServiceResult(ServiceResultType.Error, "There is no currently selected Entity");
            }

            ILogischesLoeschenEntity logischesLoeschenEntity = null;
            if (IsLogischesLoeschen)
            {
                logischesLoeschenEntity = SelectedEntity as ILogischesLoeschenEntity;
            }

            if (logischesLoeschenEntity != null)
            {
                //Entität wird nur logisch gelöscht (.IsDeleted = true)
                logischesLoeschenEntity.IsDeleted = true;
                SelectedEntityStateObserver.SetModified();
                ValidationResult = SaveData();
                if (!InclDeleted)
                {
                    EntityList.Remove(SelectedEntity);
                }
            }
            else
            {
                //Entität kann normal gelöscht werden
                if (SelectedEntityStateObserver.EntityState != EntityState.Added)
                {
                    ValidationResult = ServiceCRUD.DeleteEntity(ConvertListEntityToServiceEntity(SelectedEntity));
                }
                else
                {
                    ValidationResult = ServiceResult.Ok();
                }

                SelectedEntityStateObserver.SetDeleted();
                if (ValidationResult.IsOk())
                {
                    EntityList.Remove(SelectedEntity);
                }
            }
            return ValidationResult;
        }

        private void FindEntity(string propertyName, string propertyValue)
        {
            var foundEntity = EntityList.FirstOrDefault(entity => CheckPropertyValue(entity, propertyName, propertyValue));
            if (foundEntity != null)
            {
                EntityListView.MoveCurrentTo(foundEntity);
            }

            //foreach (var entity in EntityList)
            //{
            //    if (CheckPropertyValue(entity, propertyName, propertyValue))
            //    {
            //        SelectedEntity = entity;
            //        break;
            //    }
            //}
        }

        private PropertyInfo GetPropertyInfoSelectedEntity(string propertyName)
        {
            return !HasRow ? null : EntityListView.CurrentItem.GetType().GetProperty(propertyName);
        }

        #region IDataSource

        bool IDataSource.CanUpdate
        {
            get { return Maskenrecht.CanUpdate; }
            set { Maskenrecht.CanUpdate = value; }
        }

        DataRowState IDataSource.CurrentRowState
        {
            get
            {
                if (!HasRow)
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

        bool IDataSource.IsEmpty
        {
            get { return EntityList.Count == 0; }
        }

        bool IDataSource.RowModified
        {
            get { return ((IDataSource)this).CurrentRowState != DataRowState.Unchanged; }
            set
            {
                if (!HasRow || SelectedEntityStateObserver == null)
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
            get
            {
                if (SelectedEntity == null)
                {
                    return null;
                }

                return PropertyValue.GetPropertyValue(SelectedEntity, columnName);
            }
            set
            {
                if (SelectedEntity == null)
                {
                    return;
                }

                if (value == DBNull.Value)
                {
                    PropertyValue.SetPropertyValue(SelectedEntity, columnName, null);
                }
                else
                {
                    PropertyValue.SetPropertyValue(SelectedEntity, columnName, value);
                }
            }
        }

        bool IDataSource.Post()
        {
            // see SqlQuery.Post() for defaults
            return ((IDataSource)this).Post(true, false);
        }

        bool IDataSource.Post(bool performEndEditGrids, bool isSilentPosting)
        {
            return SaveData().IsOk;
        }

        #endregion
    }
}