using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kiss.BusinessLogic.Fa;
using Kiss.BusinessLogic.System;
using Kiss.BusinessLogic.System.NodeEnumeration;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;
using Kiss.Infrastructure.Selectable;
using Kiss.Interfaces.ViewModel;


namespace Kiss.UserInterface.ViewModel.Fa
{
    public class FaZeitachseContainerVM : ViewModelSearchList<FaZeitachseDTO, FaZeitachseContainerVM>
    {
        #region Fields

        #region Private Fields

        private List<KeyValuePair<FaZeitachseDTOType, string>> _faZeitachseDtoTypeList;
        private FaTimelineVM _timelineVM;
        private FaZeitachseService _zeitachseService;
        private const double DayMargin = 20;

        #endregion

        #endregion

        public FaZeitachseContainerVM()
        {
            HasBackgroundSearch = false;
        }

        #region Properties

        public IList<KeyValuePair<FaZeitachseDTOType, string>> FaZeitachseDTOTypeList
        {
            get { return _faZeitachseDtoTypeList ?? (_faZeitachseDtoTypeList = _zeitachseService.GetEreignisTypMapping()); }
        }

        public override bool HasMaskRight
        {
            get { return true; }
        }

        public override FaZeitachseContainerVM LastAppliedSearchParameters
        {
            get { return this; }
        }

        public FaTimelineVM TimelineVM
        {
            get { return _timelineVM; }
            set
            {
                SetProperty(ref _timelineVM, value, () => TimelineVM);
            }
        }

        private TimePeriod _totalRange;
        public TimePeriod TotalRange
        {
            get { return _totalRange; }
            set
            {
                if (SetProperty(ref _totalRange, value, () => TotalRange) && TimelineVM != null)
                {
                    foreach (var swimlane in TimelineVM.Swimlanes)
                    {
                        swimlane.TotalRange = TotalRange;
                    }
                }
            }
        }

        private TimePeriod _visibleRange;
        [SearchFieldAttribute("Ansichtszeitraum")] // ToDo: Multilanguage
        public TimePeriod VisibleRange
        {
            get { return _visibleRange; }
            set
            {
                SetProperty(ref _visibleRange, value, () => VisibleRange);
                if (TimelineVM != null)
                {
                    TimelineVM.VisibleRange = VisibleRange;
                }
            }
        }

        private SelectableList<XLOVCode> _themenFilter;
        public SelectableList<XLOVCode> ThemenFilter
        {
            get { return _themenFilter; }
            private set { SetProperty(ref _themenFilter, value, () => ThemenFilter); }
        }

        private SelectableList<FaZeitachseDTOType> _typeListFilter;
        public SelectableList<FaZeitachseDTOType> TypeListFilter
        {
            get { return _typeListFilter; }
            private set { SetProperty(ref _typeListFilter, value, () => TypeListFilter); }
        }

        private IEnumerable<DateTime> _eventDates;
        public IEnumerable<DateTime> EventDates
        {
            get { return _eventDates; }
            private set { SetProperty(ref _eventDates, value, () => EventDates); }
        }

        #endregion

        #region Methods

        #region Public Methods

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            if (!initParameters.HasValue || !initParameters.Value.BaPersonID.HasValue)
            {
                throw new ArgumentException("initParameters.BaPersonID");
            }
            var baPersonID = initParameters.Value.BaPersonID.Value;

            _zeitachseService = Container.Resolve<FaZeitachseService>();
            var searchTask = TaskEx.Run(() => _zeitachseService.GetZeitachse(baPersonID));

            var configService = Container.Resolve<XConfigService>();

            // Determine Themen to be displayed
            ThemenFilter = InitThemenFilter();
            TypeListFilter = InitZeitachseTypeListFilter();

            EntityListView.Filter = Filter;

            var allTimelineItemsEnumerable = await searchTask;
            var allTimelineItems = allTimelineItemsEnumerable == null ? new FaZeitachseDTO[] { } : allTimelineItemsEnumerable.ToArray();
            SetEntityList(allTimelineItems);
            EnableAvailableThemen(ThemenFilter, allTimelineItems
                                                .Where(itm => itm is FaZeitachseEventDTO && ((FaZeitachseEventDTO)itm).ThemaCodes != null)
                                                .SelectMany(itm => ((FaZeitachseEventDTO)itm).ThemaCodes)
                                                .ToList());
            EnableAvailableTypes(TypeListFilter, allTimelineItems
                                                 .Select(itm => itm.Type)
                                                 .ToList());

            var endDate = EntityList
                         .Select(itm => itm is FaZeitachsePeriodDTO ? ((FaZeitachsePeriodDTO)itm).EndDate ?? DateTime.Today : itm.StartDate)
                         .Max();

            TotalRange = new TimePeriod(EntityList.Min(itm => itm.StartDate).AddDays(-DayMargin), endDate.AddDays(DayMargin));

            // Set default range
            var anzahlMonateInVergangenheit = configService.GetConfigValue(ConfigNodes.System_Fallfuehrung_Zeitachse_AnzahlMonateInVergangenheit);
            var anzahlMonateInZukuft = configService.GetConfigValue(ConfigNodes.System_Fallfuehrung_Zeitachse_AnzahlMonateInZukunft);
            var visibleRange = new TimePeriod(DateTime.Today.AddMonths(-anzahlMonateInVergangenheit).AddDays(-DayMargin),
                                              DateTime.Today.AddMonths(anzahlMonateInZukuft).AddDays(DayMargin));

            // Adjust the visible range to total range (the period where there is data)
            if (visibleRange.From < TotalRange.From ||
                visibleRange.To > TotalRange.To)
            {
                if (visibleRange.TimeSpan > TotalRange.TimeSpan)
                {
                    visibleRange = TotalRange;
                }
                else if (visibleRange.To > TotalRange.To)
                {
                    visibleRange = new TimePeriod(TotalRange.To - visibleRange.TimeSpan, TotalRange.To);
                }
                else if (visibleRange.From < TotalRange.From)
                {
                    visibleRange = new TimePeriod(TotalRange.From, TotalRange.From + visibleRange.TimeSpan);
                }
            }
            VisibleRange = visibleRange;

            TimelineVM = new FaTimelineVM(EntityList, VisibleRange, TotalRange);
            foreach (var swimlane in TimelineVM.Swimlanes)
            {
                swimlane.RequestVisibleRangeMove += swimlane_RequestVisibleRangeMove;
            }
            FilterTypes();
            FilterThemen();
        }

        void swimlane_RequestVisibleRangeMove(object sender, Kiss.Interfaces.EventArgs<TimePeriod> e)
        {
            MoveVisibleRangeTo(e.Parameter);
        }

        private static void EnableAvailableTypes(IEnumerable<SelectableItem<FaZeitachseDTOType>> typeFilter, ICollection<FaZeitachseDTOType> toList)
        {
            foreach (var type in typeFilter)
            {
                type.IsEnabled = toList.Contains(type.Item);
            }
        }

        private static void EnableAvailableThemen(IEnumerable<SelectableItem<XLOVCode>> themenFilter, ICollection<int> toList)
        {
            foreach (var thema in themenFilter)
            {
                thema.IsEnabled = toList.Contains(thema.Item.Code);
            }
        }

        private SelectableList<XLOVCode> InitThemenFilter()
        {
            var configService = Container.Resolve<XConfigService>();
            var defaultThemen = configService.GetConfigValue(ConfigNodes.System_Fallfuehrung_Zeitachse_AngezeigteThemen);
            var lovService = Container.Resolve<XLovService>();
            var list = new SelectableList<XLOVCode>(lovService
                                                    .GetLovCodesByLovName("FaThema") //ToDo: magic string ersetzen
                                                    .Select(lov => new SelectableItem<XLOVCode>
                                                                       (
                                                                           lov,
                                                                           defaultThemen != null && defaultThemen.Any(def => def.LOVName == lov.LOVName &&
                                                                                                                             def.Code == lov.Code),
                                                                           false
                                                                       )));
            list.SelectionChanged += (sender, e) => FilterThemen();
            return list;
        }

        private SelectableList<FaZeitachseDTOType> InitZeitachseTypeListFilter()
        {
            var configService = Container.Resolve<XConfigService>();
            var zeitachseTypeListFilter = new SelectableList<FaZeitachseDTOType>(Enum.GetValues(typeof(FaZeitachseDTOType)).Cast<FaZeitachseDTOType>());

            // Types that are checked by default:
            // 2 Besprechungen
            // 3 Fallübergabe
            // 10,11 Pendenzen
            // 7 Weisungen
            // ToDo: enum in XConfig statt einzelne configNodes
            var defaultSelectedTypes = configService
                                       .GetConfigValues<bool>(@"System\Fallfuehrung\Zeitachse\AngezeigteTypen")
                                       .Where(cfg => cfg.Value)
                                       .Select(cfg => (FaZeitachseDTOType)Enum.Parse(typeof(FaZeitachseDTOType), cfg.Key.Split('\\').Last()))
                                       .ToList();

            foreach (var type in zeitachseTypeListFilter)
            {
                type.IsSelected = defaultSelectedTypes.Contains(type.Item);
            }

            //TODO: Wenn neue Typen implementiert werden hier ergänzen:
            //int[] enabledTypes = { 2, 3, 4, 7, 10, 11 };
            //var enabledTypes = new[]
            //                   {
            //                       FaZeitachseDTOType.Besprechungen,
            //                       FaZeitachseDTOType.Falluebergabe,
            //                       FaZeitachseDTOType.Korrespondenz,
            //                       FaZeitachseDTOType.Weisungen,
            //                       FaZeitachseDTOType.PendenzenErledigt,
            //                       FaZeitachseDTOType.PendenzenOffen
            //                   };

            //var availableTypes = _zeitachseService.GetEreignisTypMapping();
            //zeitachseTypeListFilter.Add(FaZeitachseDTOType.Kategorie, true, false);

            //foreach (var type in availableTypes)
            //{
            //    var typeEnum = type.Key;
            //    zeitachseTypeListFilter.Add(new SelectableItem<FaZeitachseDTOType>(typeEnum, defaultSelectedTypes.Contains(typeEnum)));
            //}

            //if a type is checked/unchecked, refresh timeline (display/hide filtered elements)
            zeitachseTypeListFilter.SelectionChanged += (sender, args) => FilterTypes();
            return zeitachseTypeListFilter;
        }

        /// <summary>
        /// Overriden: only toggle expanded/collapsed of search panel
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override async Task Search(System.Threading.CancellationToken cancellationToken)
        {
            SearchParametersVisible = !SearchParametersVisible;
        }

        private void FilterTypes()
        {
            TimelineVM.VisibleItemTypes = TypeListFilter
                                          .SelectedItems;
            EntityListView.Refresh();
            EventDates = EntityListView.Cast<FaZeitachseDTO>().Select(itm => itm.StartDate);
        }

        private void FilterThemen()
        {
            TimelineVM.VisibleThemen = ThemenFilter
                                       .SelectedItems
                                       .Select(tma => tma.Code);

            EntityListView.Refresh();
            EventDates = EntityListView.Cast<FaZeitachseDTO>().Select(itm => itm.StartDate);
        }

        private bool Filter(object row)
        {
            var entity = row as FaZeitachseDTO;
            var entityEvent = row as FaZeitachseEventDTO;
            return entity != null && TypeListFilter
                                     .SelectedItems
                                     .Contains(entity.Type)
               && (entityEvent == null || entityEvent.ThemaCodes == null || ThemenFilter
                                                                            .SelectedItems
                                                                            .Select(typ => typ.Code)
                                                                            .Intersect(entityEvent.ThemaCodes)
                                                                            .Any());

        }

        private TimePeriod? _currentAnimationTarget;
        public async void MoveVisibleRangeTo(TimePeriod newVisibleRange)//ToDo: make private
        {
            // Storyboard/Animation doesn't fit that well: there is no Animation for TimePeriod and DateTime, and VisibleRange has to be a DP (thus VM has to be DO)
            // so: do it yourself - but with Tasks

            const long animationDurationInTicks = 150 * TimeSpan.TicksPerMillisecond;

            // easiest option: exit if there is already an animation running
            if (_currentAnimationTarget != null)
            {
                return;
            }
            try
            {
                _currentAnimationTarget = newVisibleRange;
                var startPosition = VisibleRange;
                var startTime = DateTime.Now;
                long elapsedTicks = 0;
                do
                {
                    var ticks = elapsedTicks;
                    // don't update too often; if change is done in less than 10ms, wait
                    await TaskEx.WhenAll(TaskEx.Run(() => VisibleRange = CalculateIntermediatePosition(startPosition, newVisibleRange, ticks, animationDurationInTicks)),
                                         TaskEx.Delay(15));
                    elapsedTicks = (DateTime.Now - startTime).Ticks;
                }
                while (elapsedTicks < animationDurationInTicks);
            }
            finally
            {
                _currentAnimationTarget = null;
                VisibleRange = newVisibleRange; // set it exactly
            }
        }

        private static TimePeriod CalculateIntermediatePosition(TimePeriod startPosition, TimePeriod endPosition, long elapsedTicks, long animationDurationInTicks)
        {
            var progress = Math.Min(1.0, (double)elapsedTicks / animationDurationInTicks);
            return new TimePeriod(new DateTime((long)(startPosition.From.Ticks + (endPosition.From.Ticks - startPosition.From.Ticks) * progress)),
                                  new DateTime((long)(startPosition.To.Ticks + (endPosition.To.Ticks - startPosition.To.Ticks) * progress)));
        }

        #endregion

        #endregion
    }
}