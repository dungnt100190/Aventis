using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Kiss.BusinessLogic;
using Kiss.BusinessLogic.Vm;
using Kiss.DbContext;
using Kiss.DbContext.Enums.Vm;
using Kiss.Infrastructure;
using Kiss.Interfaces;
using Kiss.Interfaces.BL;
using Kiss.UserInterface.ViewModel.Commanding;
using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UserInterface.ViewModel.Vm
{
    public class VmKlientenbudgetKategorieVM : ViewModelSearchListCRUD<VmPosition, VmPosition, int, int>
    {
        #region Fields

        #region Private Fields

        private readonly int _faLeistungID;
        private readonly VmKategorie _vmKategorie;
        private ReadOnlyCollection<VmKlientenbudgetVM.ElFreibetrag> _elFreibetragListe;
        private bool _isReadOnly;
        private string _title;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="VmKlientenbudgetKategorieVM"/> class.
        /// </summary>
        public VmKlientenbudgetKategorieVM(VmKategorie vmKatgorie, int vmKlientenbudgetID, int faLeistungID)
            : base(Container.Resolve<VmPositionService>())
        {
            SearchParameters = vmKlientenbudgetID;
            _vmKategorie = vmKatgorie;
            _faLeistungID = faLeistungID;
            Title = _vmKategorie.ToStringLocalized();

            ImportToPositionCommand = new DelegateCommand(pos => ImportToPosition(pos as VmPosition),
                                                          pos => CanImportToPosition(pos as VmPosition));
            DeletePositionCommand = new DelegateCommand(pos => DeletePosition(pos as VmPosition),
                                                        pos => CanDeletePosition(pos as VmPosition));
            MovePositionUpCommand = new DelegateCommand(kat => MoveUp(), kat => CanMoveUp());
            MovePositionDownCommand = new DelegateCommand(kat => MoveDown(), kat => CanMoveDown());

            EntityListView.SortDescriptions.Add(new SortDescription("SortKey", ListSortDirection.Ascending));
            DefaultSelectedRow = DefaultSelectedRow.First;
        }

        #endregion

        #region Events

        public event EventHandler<EventArgs<VmPosition>> RecalculateSaldoSuggested;

        #endregion

        #region Properties

        public IDelegateCommand DeletePositionCommand { get; private set; }

        public ReadOnlyCollection<VmKlientenbudgetVM.ElFreibetrag> ElFreibetragListe
        {
            get { return _elFreibetragListe; }
            set { SetProperty(ref _elFreibetragListe, value, () => ElFreibetragListe); }
        }

        public IDelegateCommand ImportToPositionCommand { get; private set; }

        public bool IsReadOnly
        {
            get { return _isReadOnly; }
            set
            {
                if (SetProperty(ref _isReadOnly, value, () => IsReadOnly))
                {
                    RefreshCommands();
                }
            }
        }

        public bool IsVermoegen
        {
            get { return VmKategorie == VmKategorie.Vermoegen; }
        }

        public IDelegateCommand MovePositionDownCommand { get; private set; }

        public IDelegateCommand MovePositionUpCommand { get; private set; }

        public ReadOnlyCollection<VmPosition> PositionList
        {
            get { return new ReadOnlyCollection<VmPosition>(EntityList); }
        }

        public string Title
        {
            get { return _title; }
            private set { SetProperty(ref _title, value, () => Title); }
        }

        public VmKategorie VmKategorie
        {
            get { return _vmKategorie; }
        }

        private VmPositionService PositionService
        {
            get { return (VmPositionService)ServiceCRUD; }
        }

        private int VmKlientenbudgetID
        {
            get { return SearchParameters; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void ImportToPosition(VmPosition position)
        {
            var positionService = Container.Resolve<VmPositionService>();
            ValidationResult = positionService.ImportData(position, _faLeistungID);
            ValidationResult.Add(SaveData());
            RefreshCommands();
        }

        public void OnRecalculateSaldoSuggested(VmPosition modifiedPosition = null)
        {
            var handler = RecalculateSaldoSuggested;
            if (handler != null)
            {
                handler(this, new EventArgs<VmPosition>(modifiedPosition));
            }
        }

        public override IServiceResult SaveData()
        {
            // don't save position if budget is not yet inserted
            if (SelectedEntity == null || SelectedEntity.VmKlientenbudgetID == 0)
            {
                return ServiceResult.Ok();
            }

            return base.SaveData();
        }

        public void SavePendingPositionen(int vmKlientenbudgetID)
        {
            foreach (var pos in EntityList.Where(pos => pos.VmKlientenbudgetID == 0 && pos.AutoIdentityID == 0))
            {
                pos.VmKlientenbudgetID = vmKlientenbudgetID;
            }
            ValidationResult = PositionService.SaveEntities(EntityList.Where(pos => pos.AutoIdentityID == 0));
        }

        #endregion

        #region Protected Methods

        public override bool CanInsertData()
        {
            return !IsReadOnly && base.CanInsertData();
        }

        protected override VmPosition CreateAndInitNewEntity()
        {
            // Liste von Positionsarten der Kategorie holen
            var importiertePositionsarten = EntityList
                .Select(x => x.VmPositionsart.VmPositionsartID)
                .ToList();

            var vmPositionsartService = Container.Resolve<VmPositionsartService>();
            var positionsarten = vmPositionsartService.GetPositionsartenOfCategoryToInsert(VmKategorie,
                                                                                           importiertePositionsarten);
            VmPositionsart positionsart;

            if (positionsarten.Count == 0)
            {
                return null;
            }
            if (positionsarten.Count == 1)
            {
                // Es gibt nur eine Positionsart
                positionsart = positionsarten.First();
            }
            else
            {
                // den User auswählen lassen
                var options =
                    positionsarten.Select(
                        vmPositionsart => new QuestionAnswerOption(vmPositionsart, vmPositionsart.Name)).ToList();

                var answer = RaiseQuestion("Bitte wählen Sie eine Positionsart", options, false);

                if (answer == null)
                {
                    return null;
                }

                positionsart = (VmPositionsart)answer.Tag;
            }

            var newEntity = new VmPosition
                                {
                                    VmPositionsartID = positionsart.VmPositionsartID,
                                    VmPositionsart = positionsart,
                                    Name = positionsart.Name,
                                    SortKey = positionsart.SortKey,
                                    VmKlientenbudgetID = VmKlientenbudgetID
                                };

            // SortKey updaten
            VmPosition previousEntity;

            if (IstFixeVermoegenPosition(newEntity))
            {
                // Fixe Positionen anhand SortKey der Positionsart einfügen
                previousEntity = EntityList
                    .OrderBy(pos => pos.SortKey)
                    .LastOrDefault(
                        pos => pos != newEntity && pos.VmPositionsart.SortKey < newEntity.VmPositionsart.SortKey);
            }
            else
            {
                previousEntity = EntityList
                    .OrderBy(pos => pos.SortKey)
                    .LastOrDefault(pos => pos != newEntity && !IstFixeVermoegenPosition(pos));
            }

            if (previousEntity != null)
            {
                newEntity.SortKey = previousEntity.SortKey + 1;

                // SortKey nachfolgender Positionen erhöhen
                MoveDownBelow(newEntity);
            }
            OnRecalculateSaldoSuggested();
            return newEntity;
        }

        protected override void OnSelectedEntityChanged(VmPosition selectedEntity, VmPosition deselectedEntity)
        {
            base.OnSelectedEntityChanged(selectedEntity, deselectedEntity);
            RefreshCommands();
        }

        protected override void OnSelectedEntityPropertyChanged(string propertyName)
        {
            var isPositionSaldo = (propertyName == PropertyName.GetPropertyName(() => SelectedEntity.Saldo));
            var isPositionBetragMonatlich = (propertyName ==
                                             PropertyName.GetPropertyName(() => SelectedEntity.BetragMonatlich));
            var isPositionBetragJaehrlich = (propertyName ==
                                             PropertyName.GetPropertyName(() => SelectedEntity.BetragJaehrlich));

            if (isPositionSaldo || isPositionBetragMonatlich || isPositionBetragJaehrlich)
            {
                OnRecalculateSaldoSuggested(SelectedEntity);
            }
        }

        #endregion

        #region Private Static Methods

        private static bool IstFixeVermoegenPosition(VmPosition position)
        {
            if (position == null || position.VmPositionsart == null)
            {
                return false;
            }

            var type = position.VmPositionsart.VmPositionsartTyp;

            return type == VmPositionsartTyp.VermElBerechnung ||
                   type == VmPositionsartTyp.VermElFreibetrag ||
                   type == VmPositionsartTyp.VermTotal;
        }

        #endregion

        #region Private Methods

        public void SetVmPosition(IEnumerable<VmPosition> positions)
        {
            SetEntityList(positions);
        }

        private bool CanDeletePosition(VmPosition position)
        {
            // Vermögen-Total darf nicht gelöscht werden
            return position != null &&
                   base.CanDeleteData() &&
                   !position.IstImportiert &&
                   position.VmPositionsart.VmPositionsartTyp != VmPositionsartTyp.VermTotal;
        }

        private bool CanImportToPosition(VmPosition position)
        {
            if (position == null || position.VmPositionsart == null)
            {
                return false;
            }

            var positionsartTyp = position.VmPositionsart.VmPositionsartTyp;
            return positionsartTyp == VmPositionsartTyp.VermKassePc ||
                   positionsartTyp == VmPositionsartTyp.VermBetriebskonto ||
                   positionsartTyp == VmPositionsartTyp.VermDepotBs ||
                   positionsartTyp == VmPositionsartTyp.AusgKkPraemienKvg ||
                   positionsartTyp == VmPositionsartTyp.AusgKkPraemienVvg;
        }

        private bool CanMoveDown()
        {
            return SelectedEntity != null &&
                   !IsReadOnly &&
                   !IstFixeVermoegenPosition(SelectedEntity) &&
                   EntityListView.CurrentPosition + 1 < EntityListView.Count &&
                   !IstFixeVermoegenPosition((VmPosition)EntityListView.GetItemAt(EntityListView.CurrentPosition + 1));
        }

        private bool CanMoveUp()
        {
            return SelectedEntity != null &&
                   !IsReadOnly &&
                   !IstFixeVermoegenPosition(SelectedEntity) &&
                   EntityListView.CurrentPosition > 0 &&
                   !IstFixeVermoegenPosition((VmPosition)EntityListView.GetItemAt(EntityListView.CurrentPosition - 1));
        }

        private void DeletePosition(VmPosition position)
        {
            if (position == null)
            {
                return;
            }
            EntityListView.MoveCurrentTo(position);
            DeleteDataCommand.Execute(null);
            OnRecalculateSaldoSuggested();
        }

        private void MoveDown()
        {
            if (SelectedEntity == null)
            {
                return;
            }

            var next = EntityList
                       .OrderBy(x => x.SortKey)
                       .FirstOrDefault(x => x.SortKey > SelectedEntity.SortKey);

            if (next != null)
            {
                next.SortKey = SelectedEntity.SortKey;
                SelectedEntity.SortKey++;

                EntityListView.Refresh();
                RefreshCommands();
            }
            // ToDo: save both
        }

        /// <summary>
        /// Moves all positions that have a greater or equal SortKey below the specified entity.
        /// </summary>
        /// <param name="entity"></param>
        private void MoveDownBelow(VmPosition entity)
        {
            var list = EntityList
                       .Where(x => x != entity && x.SortKey >= entity.SortKey).ToList();

            foreach (var dto in list)
            {
                dto.SortKey++;
            }

            RefreshCommands();
        }

        private void MoveUp()
        {
            if (SelectedEntity == null)
            {
                return;
            }

            var prev = EntityList
                       .OrderBy(x => x.SortKey)
                       .LastOrDefault(x => x.SortKey < SelectedEntity.SortKey);

            if (prev != null)
            {
                SelectedEntity.SortKey = prev.SortKey;
                prev.SortKey++;

                EntityListView.Refresh();
                RefreshCommands();
            }
            // ToDo: save both
        }

        private void RefreshCommands()
        {
            ImportToPositionCommand.RaiseCanExecuteChanged();
            NewDataCommand.RaiseCanExecuteChanged();
            DeletePositionCommand.RaiseCanExecuteChanged();
            MovePositionUpCommand.RaiseCanExecuteChanged();
            MovePositionDownCommand.RaiseCanExecuteChanged();
        }

        #endregion

        #endregion
    }
}