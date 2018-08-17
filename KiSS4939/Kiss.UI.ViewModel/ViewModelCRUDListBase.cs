using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Reflection;

using Kiss.Interfaces.BL;
using Kiss.Interfaces.Database;
using Kiss.Interfaces.ViewModel;
using Kiss.Model;
using Kiss.UI.ViewModel.Commanding;

namespace Kiss.UI.ViewModel
{
    public abstract class ViewModelCRUDListBase<TEntity> : ViewModelCRUDBase<TEntity>, IViewModelList, IViewModelSearch, IDataSource
        where TEntity : class, IObjectWithChangeTracker, new()
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const string PARAMETER_FIND_ENTITY = "FindEntity";

        #endregion

        #region Private Fields

        private bool _allowSelectionChanging = true;

        /// <summary>
        /// The List of the main entity which currently is edited. E.g. for a BaPersonViewModel, this would be a List of BaPerson-Entities
        /// </summary>
        private ObservableCollection<TEntity> _entityList;

        private IAsyncCommand _searchCommand;
        private bool _searchPanelMaximized;
        private KissServiceResult _searchValidationResult;

        /// <summary>
        /// The currently selected entity.
        /// </summary>
        private TEntity _selectedEntity;

        #endregion

        #endregion

        #region Constructors

        protected ViewModelCRUDListBase(IServiceCRUD<TEntity> serviceCRUD)
            : base(serviceCRUD)
        {
            SearchCommand = new AsyncDelegateCommand<object>(ExecuteSearchCommand);
            SearchCommand.Executed += (s, e) => SearchCommand.IsExecuteEnabled = SearchCommand.CanExecute(null);
        }

        #endregion

        #region Events

        public event SelectedEntityChanged<TEntity> SelectedEntityChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or Sets the AllowPositionChanging property
        /// set to false to force the DataSource to stay on the same position
        /// </summary>
        public bool AllowSelectionChanging
        {
            get { return _allowSelectionChanging; }
            set { _allowSelectionChanging = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this DataSource supports updating.
        /// </summary>
        public bool CanUpdate
        {
            get { return Maskenrecht.CanUpdate; }
            set { Maskenrecht.CanUpdate = value; }
        }

        /// <summary>
        /// Get the rowstate of the current row. If no row is attached, you get a DataRowState.Detached value.
        /// </summary>
        public DataRowState CurrentRowState
        {
            get
            {
                if (!HasRow)
                {
                    return DataRowState.Detached;
                }

                switch (SelectedEntity.ChangeTracker.State)
                {
                    case ObjectState.Added:
                        return DataRowState.Added;

                    case ObjectState.Deleted:
                        return DataRowState.Deleted;

                    case ObjectState.Modified:
                        return DataRowState.Modified;

                    case ObjectState.Unchanged:
                        return DataRowState.Unchanged;
                }

                return DataRowState.Detached;
            }
        }

        public ObservableCollection<TEntity> EntityList
        {
            get { return _entityList; }
            protected set
            {
                if (_entityList == value)
                {
                    return;
                }

                _entityList = value;

                if (_entityList != null && _entityList.Count > 0)
                {
                    SelectedEntity = _entityList[0];
                }
                else
                {
                    SelectedEntity = null;
                }

                NotifyPropertyChanged.RaisePropertyChanged(() => EntityList);
            }
        }

        public override bool HasMaskRight
        {
            get
            {
                return base.HasMaskRight ||
                       ((Maskenrecht != null && Maskenrecht.CanInsert) &&
                        (SelectedEntity != null && SelectedEntity.ChangeTracker.State == ObjectState.Added));
            }
        }

        /// <summary>
        /// Get flag if datasource has a Row instance
        /// </summary>
        public bool HasRow
        {
            get
            {
                return SelectedEntity != null;
            }
        }

        /// <summary>
        /// Returns true if the query is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return EntityList.Count < 1; }
        }

        /// <summary>
        /// Needed for the non generic interface EntityList
        /// <see cref="IViewModelList"/>
        /// </summary>
        IEnumerable IViewModelList.EntityList
        {
            get { return EntityList; }
        }

        /// <summary>
        /// Interface implementation for the non generic
        /// interface IViewModelCRUDList.
        /// <see cref="IViewModelList"/>
        /// </summary>
        object IViewModelList.SelectedEntity
        {
            get { return SelectedEntity; }
            set { SelectedEntity = (TEntity)value; }
        }

        /// <summary>
        /// Gets or sets if a new search is being prepared
        /// </summary>
        public bool ReadyForNewSearch
        {
            get { return _searchPanelMaximized; }
            set
            {
                _searchPanelMaximized = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ReadyForNewSearch);
            }
        }

        /// <summary>
        /// Gets or Sets the RowModified property
        /// set to true to force saving data
        /// will be automatically set to false after saving data
        /// </summary>
        public bool RowModified
        {
            get
            {
                return CurrentRowState != DataRowState.Unchanged;
            }
            set
            {
                if (!HasRow)
                {
                    return;
                }

                if (value)
                {
                    SelectedEntity.ChangeTracker.State = CurrentRowState == DataRowState.Added ? ObjectState.Added : ObjectState.Modified;
                }
                else
                {
                    // TODO: shall we really do that "false" case?
                    SelectedEntity.ChangeTracker.State = ObjectState.Unchanged;
                }
            }
        }

        /// <summary>
        /// Command to start a search or prepare a new one (function toggles)
        /// </summary>
        public IAsyncCommand SearchCommand
        {
            get { return _searchCommand; }
            protected set
            {
                _searchCommand = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SearchCommand);
            }
        }

        public KissServiceResult SearchValidationResult
        {
            get { return _searchValidationResult; }
            protected set
            {
                _searchValidationResult = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => SearchValidationResult);
            }
        }

        public TEntity SelectedEntity
        {
            get { return _selectedEntity; }
            set
            {
                if (_selectedEntity == value)
                {
                    return;
                }

                if (_selectedEntity != null && value != null && IsSelectedEntityTreeModified())
                {
                    //TODO: AllowSelectionChanging muss noch auf der View eingebaut werden. SelectedEntity bleibt aber im Grid wird eine andere Zeile farbig markiert
                    //if (!AllowSelectionChanging)
                    //{
                    //    return;
                    //}

                    ValidationResult = SaveData(null);

                    if (!ValidationResult)
                    {
                        return;
                    }
                }

                ValidationResult = KissServiceResult.Ok();
                TEntity deselectedEntity = _selectedEntity;
                _selectedEntity = value;
                OnSelectedEntityChanged(_selectedEntity, deselectedEntity);

                NotifyPropertyChanged.RaisePropertyChanged(() => SelectedEntity);
                NotifyPropertyChanged.RaisePropertyChanged(() => HasMaskRight);
            }
        }

        #endregion

        #region Indexers

        /// <summary>
        /// Gets or sets the Value of the named Column of the current <see cref="SelectedEntity"/>
        /// </summary>
        public object this[string columnName]
        {
            get
            {
                var propertyInfo = GetPropertyInfoSelectedEntity(columnName);
                return propertyInfo == null ? null : propertyInfo.GetValue(SelectedEntity, null);
            }
            set
            {
                var propertyInfo = GetPropertyInfoSelectedEntity(columnName);

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(SelectedEntity, value, null);
                }
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool CanEdit()
        {
            if (Maskenrecht.CanInsert && SelectedEntity.ChangeTracker.State == ObjectState.Added)
            {
                return true;
            }

            if (Maskenrecht.CanUpdate)
            {
                return true;
            }

            return false;
        }

        public override KissServiceResult DeleteData(IUnitOfWork unitOfWork)
        {
            if (!Maskenrecht.CanDelete && SelectedEntity.ChangeTracker.State != ObjectState.Added)
            {
                // TODO: MultiLanguage
                ValidationResult = new KissServiceResult(ServiceResultType.Error, "Sie besitzen keine Berechtigung zum Löschen.");
                return ValidationResult;
            }

            return DeleteDataWithoutCheckingRights(unitOfWork);
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
                        FindEntity(findParts[0], findParts[1]);
                    }
                }
            }

            return base.JumpToPath(parameters);
        }

        public override KissServiceResult NewData()
        {
            if (EntityList == null)
            {
                ValidationResult = new KissServiceResult(ServiceResultType.Error, "ViewModelCRUDListBase_NoEntityListYet", "Programmierfehler: Einfügen nicht möglich, da noch keine Liste erzeugt wurde.");
                return ValidationResult;
            }

            if (!Maskenrecht.CanInsert)
            {
                // TODO: MultiLanguage
                ValidationResult = new KissServiceResult(ServiceResultType.Error, "Sie besitzen keine Berechtigung zum Einfügen.");
                return ValidationResult;
            }

            TEntity newEntity;
            KissServiceResult retValue = ServiceCRUD.NewData(out newEntity);

            if (retValue)
            {
                EntityList.Add(newEntity);

                SelectedEntity = newEntity;
            }

            ValidationResult = retValue;
            return retValue;
        }

        /// <summary>
        /// Save the inserted or updated row to the database (Errors are displayed)
        /// </summary>
        public bool Post()
        {
            // see SqlQuery.Post() for defaults
            return Post(true, false);
        }

        /// <summary>
        /// Save the inserted or updated row to the database (Errors are displayed)
        /// </summary>
        /// <param name="performEndEditGrids"></param>
        /// <param name="isSilentPosting"></param>
        public bool Post(bool performEndEditGrids, bool isSilentPosting)
        {
            return SaveData(null);
        }

        public override void RefreshData()
        {
            LoadData(null);
        }

        public override KissServiceResult SaveData(IUnitOfWork unitOfWork)
        {
            if (SelectedEntity == null)
            {
                return KissServiceResult.Ok();
            }

            var state = SelectedEntity.ChangeTracker.State;

            if (state == ObjectState.Deleted || state == ObjectState.Unchanged)
            {
                return KissServiceResult.Ok();
            }

            if (!Maskenrecht.CanUpdate && (state != ObjectState.Added || !Maskenrecht.CanInsert))
            {
                // TODO: MultiLanguage
                ValidationResult = new KissServiceResult(ServiceResultType.Error, "Sie besitzen keine Berechtigung zum Speichern.");
                return ValidationResult;
            }

            ValidationResult = ServiceCRUD.SaveData(unitOfWork, SelectedEntity);

            if (ValidationResult.IsOk)
            {
                CreateMemento(SelectedEntity);
            }

            return ValidationResult;
        }

        public virtual KissServiceResult Search(IUnitOfWork unitOfWork)
        {
            LoadData(null);
            return KissServiceResult.Ok();
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
        }

        /// <summary>
        /// <see cref="IViewModelCRUD"/>
        /// </summary>
        public override bool UndoDataChanges()
        {
            //The selected entity did not change.
            if (SelectedEntity == null ||
                SelectedEntity.ChangeTracker.State == ObjectState.Unchanged)
            {
                return true;
            }

            if (SelectedEntity.ChangeTracker.State == ObjectState.Added)
            {
                return DeleteDataWithoutCheckingRights(null);
            }

            var index = EntityList.IndexOf(SelectedEntity);
            var deselectedEntity = SelectedEntity;
            var mementoTmp = Memento;
            EntityList.Insert(index, mementoTmp);
            _selectedEntity = mementoTmp;
            EntityList.RemoveAt(index + 1);

            //reset the ValidationResult after the 'undo'
            ValidationResult = KissServiceResult.Ok();

            //NotifyPropertyChanged.RaisePropertyChanged(() => EntityList);
            OnSelectedEntityChanged(SelectedEntity, deselectedEntity);
            NotifyPropertyChanged.RaisePropertyChanged(() => SelectedEntity);
            CreateMemento(SelectedEntity);
            return true;
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Determines if the selected entity is in a modified state.
        /// Overwrite this method if multiple entities are involved
        /// (a child entity of the current entity).
        /// </summary>
        /// <returns></returns>
        protected virtual bool IsSelectedEntityTreeModified()
        {
            var state = _selectedEntity.ChangeTracker.State;
            return state != ObjectState.Unchanged && state != ObjectState.Deleted;
        }

        /// <summary>
        /// Another entity is selected.
        /// </summary>
        /// <param name="selectedEntity">The now selected entity</param>
        /// <param name="deselectedEntity">The previously selected entity</param>
        protected virtual void OnSelectedEntityChanged(TEntity selectedEntity, TEntity deselectedEntity)
        {
            if (deselectedEntity != null)
            {
                var pch = (INotifyPropertyChanged)deselectedEntity;
                pch.PropertyChanged -= SelectedEntityPropertyChangedEventHandler;
            }
            if (selectedEntity != null)
            {
                var pch = (INotifyPropertyChanged)selectedEntity;
                pch.PropertyChanged += SelectedEntityPropertyChangedEventHandler;
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

        #endregion

        #region Private Static Methods

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
        private static void CopyProperties(TEntity source, TEntity target)
        {
            foreach (PropertyInfo property in typeof(TEntity).GetProperties())
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

        #endregion

        #region Private Methods

        private KissServiceResult DeleteDataWithoutCheckingRights(IUnitOfWork unitOfWork)
        {
            if (SelectedEntity == null)
            {
                return new KissServiceResult(ServiceResultType.Error, "There is no currently selected Entity");
            }

            if (SelectedEntity.ChangeTracker.State != ObjectState.Added)
            {
                ValidationResult = ServiceCRUD.DeleteData(unitOfWork, SelectedEntity);
            }
            else
            {
                ValidationResult = KissServiceResult.Ok();
            }

            if (ValidationResult)
            {
                EntityList.Remove(SelectedEntity);
                SelectedEntity = null;
            }

            return ValidationResult;
        }

        private void ExecuteSearchCommand(object o)
        {
            if (ReadyForNewSearch)
            {
                // zuerst speichern - sonst wird erst beim Zuweisen des Resultats gespeichert, womit das Suchresultat veraltete Werte hat
                Dispatcher.Invoke(new Action(() => ValidationResult = SaveData(null)));

                // Suche durchführen
                SearchValidationResult = Search(null);

                if (SearchValidationResult)
                {
                    ReadyForNewSearch = false;
                }
            }
            else
            {
                // Neue Suche vorbereiten
                ReadyForNewSearch = true;
            }
        }

        private void FindEntity(string propertyName, string propertyValue)
        {
            foreach (var entity in EntityList)
            {
                if (CheckPropertyValue(entity, propertyName, propertyValue))
                {
                    SelectedEntity = entity;
                    break;
                }
            }
        }

        private PropertyInfo GetPropertyInfoSelectedEntity(string propertyName)
        {
            return !HasRow ? null : SelectedEntity.GetType().GetProperty(propertyName);
        }

        #endregion

        #endregion
    }
}