using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using Kiss.BusinessLogic.Fa;
using Kiss.BusinessLogic.Sys;
using Kiss.BusinessLogic.Sys.NodeEnumeration;
using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Selectable;
using Kiss.Infrastructure.Utils;
using Kiss.Interfaces;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using Kiss.UserInterface.ViewModel.Commanding;

using Container = Kiss.Infrastructure.IoC.Container;

namespace Kiss.UserInterface.ViewModel.Fa.Timeline
{
    public class FaTimelineVM : ViewModelSearchList<FaZeitachseDTO, TimelineDrawParameters>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private const double DayMargin = 30;

        #endregion

        #region Private Fields

        private double _drawAreaWidth;
        private TimelineDrawParameters _drawParameters;
        private IEnumerable<DateTime> _eventDates;
        private IDictionary<FaZeitachseDTOType, string> _faZeitachseDtoTypeLookup;

        //private List<KeyValuePair<FaZeitachseDTOType, string>> _faZeitachseDtoTypeList;
        private ObservableCollection<FaTimelineSwimlaneVM> _swimlanes;

        private SelectableList<XLOVCode> _themenFilter;
        private TimePeriod _totalRange;
        private SelectableList<FaZeitachseDTOType> _typeListFilter;
        private TimePeriod _visibleRange;
        private DateTime _visibleRangeAnimationTarget;
        private FaZeitachseService _zeitachseService;

        #endregion

        #endregion

        #region Constructors

        public FaTimelineVM()
        {
            RequiredParameters = InitParameterValue.BaPersonID;
            JumpToPathCommand = new BaseCommand(JumpToPath);
            HasBackgroundSearch = false;
        }

        #endregion

        #region Properties

        public double DrawAreaWidth
        {
            get { return _drawAreaWidth; }
            set
            {
                if (Math.Abs(_drawAreaWidth - value) < double.Epsilon)
                {
                    return;
                }

                _drawAreaWidth = value;
                PropagateParametersToSwimlanes();
            }
        }

        public TimelineDrawParameters DrawParameters
        {
            get { return _drawParameters; }
            set { SetProperty(ref _drawParameters, value, () => DrawParameters); }
        }

        public IEnumerable<DateTime> EventDates
        {
            get { return _eventDates; }
            private set { SetProperty(ref _eventDates, value, () => EventDates); }
        }

        public IDictionary<FaZeitachseDTOType, string> FaZeitachseDTOTypeLookup
        {
            get { return _faZeitachseDtoTypeLookup ?? (_faZeitachseDtoTypeLookup = EnumExtensions.GetLookupDirectory<FaZeitachseDTOType>()); }
        }

        //public IList<KeyValuePair<FaZeitachseDTOType, string>> FaZeitachseDTOTypeList
        //{
        //    get { return _faZeitachseDtoTypeList ?? (_faZeitachseDtoTypeList = _zeitachseService.GetEreignisTypMapping()); }
        //}

        public override bool HasMaskRight
        {
            get { return true; }
        }

        public ObservableCollection<FaTimelineSwimlaneVM> Swimlanes
        {
            get { return _swimlanes; }
            private set { SetProperty(ref _swimlanes, value, () => Swimlanes); }
        }

        public SelectableList<XLOVCode> ThemenFilter
        {
            get { return _themenFilter; }
            private set { SetProperty(ref _themenFilter, value, () => ThemenFilter); }
        }

        public TimePeriod TotalRange
        {
            get { return _totalRange; }
            set
            {
                if (SetProperty(ref _totalRange, value, () => TotalRange))
                {
                    PropagateParametersToSwimlanes();
                }
            }
        }

        public SelectableList<FaZeitachseDTOType> TypeListFilter
        {
            get { return _typeListFilter; }
            private set { SetProperty(ref _typeListFilter, value, () => TypeListFilter); }
        }

        public TimePeriod VisibleRange
        {
            get { return _visibleRange; }
            set
            {
                var newValue = value.CropByTryPreserveTimeSpan(TotalRange);
                if (SetProperty(ref _visibleRange, newValue, () => VisibleRange))
                {
                    PropagateParametersToSwimlanes();
                }
            }
        }

        public DateTime VisibleRangeAnimationTarget
        {
            get { return _visibleRangeAnimationTarget; }
            private set { SetProperty(ref _visibleRangeAnimationTarget, value, () => VisibleRangeAnimationTarget); }
        }

        #endregion

        #region Commands

        public ICommand JumpToPathCommand
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Overriden: only toggle expanded/collapsed of search panel
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task Search(System.Threading.CancellationToken cancellationToken)
        {
            SearchParametersVisible = !SearchParametersVisible;
            return Task.FromResult<object>(null);
        }

        #endregion

        #region Protected Methods

        protected override async Task InitAsync(InitParameters? initParameters = null)
        {
            var baPersonID = initParameters.Value.BaPersonID.Value;

            _zeitachseService = Container.Resolve<FaZeitachseService>();
            var searchTask = Task.Run(() => _zeitachseService.GetZeitachse(baPersonID));

            var configService = Container.Resolve<XConfigService>();

            // Determine Themen to be displayed
            ThemenFilter = InitThemenFilter();
            TypeListFilter = InitZeitachseTypeListFilter();

            EntityListView.Filter = Filter;

            var allTimelineItemsEnumerable = await searchTask;
            var allTimelineItems = allTimelineItemsEnumerable == null ? new FaZeitachseDTO[] { } : allTimelineItemsEnumerable.ToArray();
            SetEntityList(allTimelineItems);
            EntityListView.SortDescriptions.Add(new SortDescription("StartDate", ListSortDirection.Ascending));
            EnableAvailableThemen(ThemenFilter, allTimelineItems
                                                .Where(itm => itm is FaZeitachseEventDTO && ((FaZeitachseEventDTO)itm).ThemaCodes != null)
                                                .SelectMany(itm => ((FaZeitachseEventDTO)itm).ThemaCodes)
                                                .ToList());
            EnableAvailableTypes(TypeListFilter, allTimelineItems
                                                 .Select(itm => itm.Type)
                                                 .ToList());

            // Set default range
            var anzahlMonateInVergangenheit = configService.GetConfigValue(ConfigNodes.System_Fallfuehrung_Zeitachse_AnzahlMonateInVergangenheit);
            var anzahlMonateInZukuft = configService.GetConfigValue(ConfigNodes.System_Fallfuehrung_Zeitachse_AnzahlMonateInZukunft);

            var visibleRange = new TimePeriod(DateTime.Today.AddMonths(-anzahlMonateInVergangenheit).AddDays(-DayMargin),
                              DateTime.Today.AddMonths(anzahlMonateInZukuft).AddDays(DayMargin));

            var endDates = EntityList
                          .Select(itm => itm is FaZeitachsePeriodDTO ? ((FaZeitachsePeriodDTO)itm).EndDate ?? DateTime.Today : itm.StartDate)
                          .ToList();

            var startDate = EntityList.Any() ? EntityList.Min(itm => itm.StartDate) : visibleRange.From;
            var endDate = endDates.Any() ? endDates.Max() : visibleRange.To;
            TotalRange = new TimePeriod(startDate.AddDays(-DayMargin), endDate.AddDays(DayMargin));

            VisibleRange = visibleRange;
            FilterByTypesAndThemen();

            var factory = Container.Resolve<FaTimelineSwimlanesFactory>();
            Swimlanes = factory.CreateSwimlanes(EntityList);
            foreach (var swimlane in Swimlanes)
            {
                swimlane.RequestMoveToCenter += SwimlaneOnRequestMoveToCenter;
            }
            PropagateParametersToSwimlanes();
        }

        #endregion

        #region Private Static Methods

        private static void EnableAvailableThemen(IEnumerable<SelectableItem<XLOVCode>> allThemen, ICollection<XLOVCode> usedThemen)
        {
            foreach (var thema in allThemen)
            {
                thema.IsEnabled = usedThemen.Contains(thema.Item);
            }
        }

        private static void EnableAvailableTypes(IEnumerable<SelectableItem<FaZeitachseDTOType>> allTypes, ICollection<FaZeitachseDTOType> usedTypes)
        {
            foreach (var type in allTypes)
            {
                type.IsEnabled = usedTypes.Contains(type.Item) && type.Item != FaZeitachseDTOType.Kategorie;
            }
        }

        #endregion

        #region Private Methods

        private bool Filter(object row)
        {
            var entity = row as FaZeitachseDTO;
            var entityEvent = row as FaZeitachseEventDTO;
            return entity != null && TypeListFilter
                                     .SelectedItems
                                     .Contains(entity.Type)
               && (entityEvent == null ||
                   entityEvent.ThemaCodes == null ||
                   entityEvent.ThemaCodes.Length == 0 ||
                   ThemenFilter.SelectedItems
                               .Intersect(entityEvent.ThemaCodes)
                               .Any());
        }

        private void FilterByTypesAndThemen()
        {
            EntityListView.Refresh();
            EventDates = EntityListView.Cast<FaZeitachseDTO>().Select(itm => itm.StartDate);
            PropagateParametersToSwimlanes();
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
            list.SelectionChanged += (sender, e) => FilterByTypesAndThemen();
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
                type.IsSelected = defaultSelectedTypes.Contains(type.Item) || type.Item == FaZeitachseDTOType.Kategorie;
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
            zeitachseTypeListFilter.SelectionChanged += (sender, args) => FilterByTypesAndThemen();
            return zeitachseTypeListFilter;
        }

        private void JumpToPath(object parameter)
        {
            var path = parameter as string;
            if (path == null)
            {
                return;
            }
            var formController = Container.Resolve<IKissFormController>();
            string className;
            var parameters = formController.ConvertToParameterArray(path, out className);
            formController.OpenForm(className, parameters);
        }

        private void PropagateParametersToSwimlanes()
        {
            var parameters = new TimelineDrawParameters
                                              {
                                                  TotalRange = TotalRange,
                                                  VisibleRange = VisibleRange,
                                                  DayWidth =
                                                      Math.Max(0.0,
                                                               ScaleHelper.CalculateDayWidth(_drawAreaWidth,
                                                                                             VisibleRange)),
                                                  VisibleItemTypes = TypeListFilter.SelectedItems.ToArray(),
                                                  VisibleThemenCodes = ThemenFilter.SelectedItems.ToArray()
                                              };
            if (Swimlanes != null)
            {
                foreach (var swimlane in Swimlanes)
                {
                    swimlane.DrawParameters = parameters;
                }
            }
            DrawParameters = parameters;
        }

        private void SwimlaneOnRequestMoveToCenter(object sender, EventArgs<DateTime> e)
        {
            VisibleRangeAnimationTarget = e.Parameter;
        }

        #endregion

        #endregion
    }
}