using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

using Kiss.BusinessLogic;
using Kiss.DbContext;
using Kiss.Infrastructure;
using Kiss.UserInterface.ViewModel.Commanding;
using Kiss.UserInterface.ViewModel.Interfaces;

namespace Kiss.UserInterface.ViewModel
{
    public abstract class ViewModelList<TEntity> : ViewModel, IViewModelList
        where TEntity : class
    {
        private readonly ObservableCollection<TEntity> _entityList;
        private readonly CollectionView _entityListView;

        private TEntity _lastSelectedEntity;

        protected ViewModelList()
        {
            AllowSelectionChanging = true;
            DefaultSelectedRow = DefaultSelectedRow.Last;

            _entityList = new ObservableCollection<TEntity>();
            _entityListView = new ListCollectionView(_entityList);
            _entityListView.CurrentChanging += EntityListViewCurrentChanging;
            _entityListView.CurrentChanged += EntityListViewCurrentChanged;

            GoToNextItem = new DelegateCommand(MoveNext, CanMoveNext);
            GoToPreviousItem = new DelegateCommand(MovePrevious, CanMovePrevious);
            GoToFirstItem = new DelegateCommand(MoveFirst);
            GoToLastItem = new DelegateCommand(MoveLast);
        }

        /// <summary>
        /// Gets or Sets the AllowPositionChanging property
        /// set to false to force the DataSource to stay on the same position
        /// </summary>
        public bool AllowSelectionChanging { get; set; }

        public DefaultSelectedRow DefaultSelectedRow
        {
            get;
            set;
        }

        public CollectionView EntityListView
        {
            get { return _entityListView; }
        }

        public IDelegateCommand GoToFirstItem { get; private set; }

        public IDelegateCommand GoToLastItem { get; private set; }

        public IDelegateCommand GoToNextItem { get; private set; }

        public IDelegateCommand GoToPreviousItem { get; private set; }

        public TEntity SelectedEntity
        {
            get { return _entityListView.CurrentItem as TEntity; }
        }

        protected IList<TEntity> EntityList
        {
            get { return _entityList; }
        }

        protected EntityStateObserver SelectedEntityStateObserver
        {
            get;
            private set;
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

        protected virtual bool IsSelectionChangeAllowed()
        {
            // always allow change from null to an entity
            return AllowSelectionChanging || EntityListView.CurrentItem == null;
        }

        protected virtual void OnSelectedEntityChanged(TEntity selectedEntity, TEntity deselectedEntity)
        {
            // nop
        }

        protected virtual void SelectDefaultRow()
        {
        }

        protected void SetEntityList(IEnumerable<TEntity> newList)
        {
            var previouslySelectedItem = _entityListView.CurrentItem as IAutoIdentityEntity<int>;
            //using (_entityListView.DeferRefresh())
            {
                _entityList.Clear();
                if (newList != null)
                {
                    foreach (var entity in newList)
                    {
                        _entityList.Add(entity);
                    }
                }

                if (previouslySelectedItem != null)
                {
                    var newSelectedItem = _entityList
                                          .OfType<IAutoIdentityEntity<int>>()
                                          .FirstOrDefault(ent => ent.AutoIdentityID == previouslySelectedItem.AutoIdentityID);
                    if (newSelectedItem != null)
                    {
                        EntityListView.MoveCurrentTo(newSelectedItem);
                    }
                }
                else
                {
                    switch (DefaultSelectedRow)
                    {
                        case DefaultSelectedRow.Last:
                            MoveLast(null);
                            break;

                        case DefaultSelectedRow.Custom:
                            SelectDefaultRow();
                            break;

                        default:
                            MoveFirst(null);
                            break;
                    }
                }
            }
        }

        private bool CanMoveNext(object parameter)
        {
            return EntityListView.CurrentPosition + 1 < EntityListView.Count;
        }

        private bool CanMovePrevious(object parameter)
        {
            return EntityListView.CurrentPosition > 0;
        }

        private void EntityListViewCurrentChanged(object sender, EventArgs e)
        {
            ValidationResult = ServiceResult.Ok();
            var newSelectedEntity = EntityListView.CurrentItem as TEntity;

            var entityAsNotifyPropertyChanged = newSelectedEntity as INotifyPropertyChanged;
            SelectedEntityStateObserver = entityAsNotifyPropertyChanged == null ? null : new EntityStateObserver(entityAsNotifyPropertyChanged);

            NotifyPropertyChanged.RaisePropertyChanged(() => SelectedEntity);
            NotifyPropertyChanged.RaisePropertyChanged(() => HasMaskRight);

            OnSelectedEntityChanged(newSelectedEntity, _lastSelectedEntity);
            _lastSelectedEntity = newSelectedEntity;

            if (SelectedEntityStateObserver != null)
            {
                SelectedEntityStateObserver.SetUnchangedIfModified();
            }
        }

        private void EntityListViewCurrentChanging(object sender, CurrentChangingEventArgs e)
        {
            if (e.IsCancelable)
            {
                e.Cancel = !IsSelectionChangeAllowed();
            }
        }

        private void MoveFirst(object parameter)
        {
            EntityListView.MoveCurrentToFirst();
        }

        private void MoveLast(object parameter)
        {
            EntityListView.MoveCurrentToLast();
        }

        private void MoveNext(object parameter)
        {
            if (EntityListView.CurrentPosition + 1 < EntityListView.Count)
            {
                EntityListView.MoveCurrentToNext();
            }
        }

        private void MovePrevious(object parameter)
        {
            EntityListView.MoveCurrentToPrevious();
        }
    }
}