using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Media;

using Kiss.BL.Fa;
using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Kiss.Infrastructure.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Fa;

namespace Kiss.UI.ViewModel.Fa
{
    public class FaZeitachseContainerVM : ViewModelSearchListBase
    {
        #region Fields

        #region Public Static Fields

        // Using a DependencyProperty as the backing store for ZeitachseThemaAll.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZeitachseThemaAllProperty = 
            DependencyProperty.Register("ZeitachseThemaAll", typeof(ObservableCollection<XLOVCode>), typeof(FaZeitachseContainerVM));

        // Using a DependencyProperty as the backing store for ZeitachseThemaSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ZeitachseThemaSelectedProperty = 
            DependencyProperty.Register("ZeitachseThemaSelected", typeof(ObservableCollection<XLOVCode>), typeof(FaZeitachseContainerVM));

        #endregion

        #region Private Fields

        private int _anzahlMonateInVergangenheit;
        private int _anzahlMonateInZukuft;
        private int _baPersonID;
        private List<KeyValuePair<int, string>> _faZeitachseDtoTypeList;
        private IEnumerable<FaZeitachseDTO> _filteredZeitAchse;
        private FaTimelineDTO _timelineDTO;
        private DateTime _totalRangeBegin;
        private DateTime _totalRangeEnd;
        private DateTime _visibleRangeBegin;
        private DateTime _visibleRangeEnd;
        private XLovService _xLovService;
        private IEnumerable<FaZeitachseDTO> _zeitAchse;
        private FaZeitachseService _zeitachseService;
        private ObservableCollection<FaTimelineItemType> _zeitachseTypeListFilter;

        #endregion

        #endregion

        #region Properties

        public string AnsichtszeitraumText
        {
            get
            {
                return string.Format("Ansichtszeitraum: {0} - {1}", VisibleRangeBegin.ToString("d"), VisibleRangeEnd.ToString("d"));
            }
        }

        public IList<KeyValuePair<int, string>> FaZeitachseDTOTypeList
        {
            get { return _faZeitachseDtoTypeList ?? (_faZeitachseDtoTypeList = _zeitachseService.GetEreignisTypMapping(null)); }
        }

        public IEnumerable<FaZeitachseDTO> FilteredZeitAchse
        {
            get { return _filteredZeitAchse; }
            set
            {
                _filteredZeitAchse = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => FilteredZeitAchse);
            }
        }

        public override bool HasMaskRight
        {
            get
            {
                return true;
            }
        }

        public FaTimelineDTO TimelineDTO
        {
            get
            {
                return _timelineDTO;
            }
            set
            {
                if (_timelineDTO == value)
                {
                    return;
                }

                _timelineDTO = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => TimelineDTO);

                //OnPropertyChanged("TimelineDTO");
            }
        }

        public DateTime TotalRangeBegin
        {
            get { return _totalRangeBegin; }
            set
            {
                if (_totalRangeBegin == value)
                {
                    return;
                }

                _totalRangeBegin = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => TotalRangeBegin);
            }
        }

        public DateTime TotalRangeEnd
        {
            get { return _totalRangeEnd; }
            set
            {
                if (_totalRangeEnd == value)
                {
                    return;
                }

                _totalRangeEnd = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => TotalRangeEnd);
            }
        }

        public DateTime VisibleRangeBegin
        {
            get { return _visibleRangeBegin; }
            set
            {
                if (_visibleRangeBegin == value)
                {
                    return;
                }

                _visibleRangeBegin = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VisibleRangeBegin);
                NotifyPropertyChanged.RaisePropertyChanged(() => AnsichtszeitraumText);
            }
        }

        public DateTime VisibleRangeEnd
        {
            get { return _visibleRangeEnd; }
            set
            {
                if (_visibleRangeEnd == value)
                {
                    return;
                }

                _visibleRangeEnd = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VisibleRangeEnd);
                NotifyPropertyChanged.RaisePropertyChanged(() => AnsichtszeitraumText);
            }
        }

        public IEnumerable<FaZeitachseDTO> ZeitAchse
        {
            get { return _zeitAchse; }
            set
            {
                if (_zeitAchse == value)
                {
                    return;
                }
                _zeitAchse = value;
            }
        }

        public ObservableCollection<XLOVCode> ZeitachseThemaAll
        {
            get { return (ObservableCollection<XLOVCode>)GetValue(ZeitachseThemaAllProperty); }
            set { SetValue(ZeitachseThemaAllProperty, value); }
        }

        public ObservableCollection<XLOVCode> ZeitachseThemaSelected
        {
            get { return (ObservableCollection<XLOVCode>)GetValue(ZeitachseThemaSelectedProperty); }
            set { SetValue(ZeitachseThemaSelectedProperty, value); }
        }

        public ObservableCollection<FaTimelineItemType> ZeitachseTypeListFilter
        {
            get
            {
                if (_zeitachseTypeListFilter == null)
                {
                    _zeitachseTypeListFilter = new ObservableCollection<FaTimelineItemType>();

                    XConfigService configService = Container.Resolve<XConfigService>();

                    // Types that are checked by default:
                    // 2 Besprechungen
                    // 3 Fallübergabe
                    // 10,11 Pendenzen
                    // 7 Weisungen
                    IDictionary<string, bool> typeConfiguration = configService.GetConfigValues<bool>(@"System\Fallfuehrung\Zeitachse\AngezeigteTypen");

                    //TODO: Wenn neue Typen implementiert werden hier ergänzen:
                    int[] enabledTypes = { 2, 3, 4, 7, 10, 11 };

                    foreach (var type in FaZeitachseDTOTypeList)
                    {
                        FaTimelineItemType timeLineType = new FaTimelineItemType
                        {
                            TypeID = type.Key,
                            Description = type.Value,
                            IsChecked = false,
                            IsEnabled = enabledTypes.Contains(type.Key),
                        };

                        //Default Wert für Typ. Das Mapping zum Konfigurationswert erfolgt über den Namen der Enumeration FaZeitachseDTOType
                        FaZeitachseDTOType enumT = (FaZeitachseDTOType)type.Key;
                        if (typeConfiguration.ContainsKey(enumT.ToString()))
                        {
                            timeLineType.IsChecked = typeConfiguration[enumT.ToString()];
                        }

                        _zeitachseTypeListFilter.Add(timeLineType);

                        //if a type is checked/unchecked, refresh zeitachse (display/hide filtered elements)
                        timeLineType.PropertyChanged += (sender, args) => FilterTypes();
                    }
                }
                return _zeitachseTypeListFilter;
            }
            set
            {
                _zeitachseTypeListFilter = value;
            }
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Create a new TimelineDTO with only 
        /// Period Items in the selected Categories
        /// </summary>
        public void FilterTypes()
        {
            var timelineDtos = TimelineDTO.Swimmlanes.SelectMany(sl => sl.TimelineItems).ToList();

            // Get all checked types
            var checkedTypes = (from t in ZeitachseTypeListFilter
                                where t.IsChecked
                                select t.TypeID).ToList();

            // Kategorie ist immer sichtbar
            checkedTypes.Add((int)FaZeitachseDTOType.Kategorie);

            // Get all selected Themen
            var selectedCodes = ZeitachseThemaSelected.Select(t => t.Code).ToList();

            var visibleDtos = from timelineItemDto in timelineDtos
                              where (timelineItemDto.ThemaCodes == null || !selectedCodes.Any() || selectedCodes.Intersect(timelineItemDto.ThemaCodes).Any())
                                    && checkedTypes.Contains((int)timelineItemDto.Type)
                              select timelineItemDto;

            var visibleEvents = from z in _zeitAchse.OfType<FaZeitachseEventDTO>()
                                where (z.ThemaCodes == null || !selectedCodes.Any() || selectedCodes.Intersect(z.ThemaCodes).Any())
                              && checkedTypes.Contains((int)z.Type)
                                select z;

            var visibleZeitachseDtos = (from z in _zeitAchse
                                        where checkedTypes.Contains((int)z.Type) && z.GetType() != typeof(FaZeitachseEventDTO)
                                        select z);

            FilteredZeitAchse = visibleEvents.Union(visibleZeitachseDtos);

            var hiddenDtos = timelineDtos.Except(visibleDtos);

            //var hiddenDtos = from timelineItemDto in timelineDtos
            //                 where !(selectedCodes.Intersect(timelineItemDto.ThemaCodes ?? new List<int>()).Any()
            //                          && timelineItemDto.ThemaCodes != null)
            //                          || !checkedTypes.Contains((int)timelineItemDto.Type)
            //                 select timelineItemDto;

            visibleDtos.ToList().ForEach(dto => dto.IsFilteredOut = false);
            hiddenDtos.ToList().ForEach(dto => dto.IsFilteredOut = true);
        }

        /// <summary>
        /// Initialisert das ViewModel.
        /// </summary>
        public void Init()
        {
            _zeitachseService = Container.Resolve<FaZeitachseService>();
            _xLovService = Container.Resolve<XLovService>();

            XConfigService configService = Container.Resolve<XConfigService>();

            _anzahlMonateInVergangenheit = configService.GetConfigValue<int>(@"System\Fallfuehrung\Zeitachse\ZeitachseAnzahlMonateInVergangenheit");
            _anzahlMonateInZukuft = configService.GetConfigValue<int>(@"System\Fallfuehrung\Zeitachse\ZeitachseAnzahlMonateInZukunft");

            // Set default range
            VisibleRangeBegin = DateTime.Today.AddMonths(-_anzahlMonateInVergangenheit);
            VisibleRangeEnd = DateTime.Today.AddMonths(_anzahlMonateInZukuft);

            // Determine Themen to be displayed
            var zeitachseThemaAll = new ObservableCollection<XLOVCode>(_xLovService.GetLovCodeByLovName(null, "FaThema"));
            ZeitachseThemaAll = zeitachseThemaAll;

            var defaultThemen = configService.GetConfigValueSplitted<int>(@"System\Fallfuehrung\Zeitachse\AngezeigteThemen");
            var filteredThemaList = from t in ZeitachseThemaAll
                                    where defaultThemen.Contains(t.Code)
                                    select t;
            var zeitachseThemaSelected = new ObservableCollection<XLOVCode>(filteredThemaList);
            zeitachseThemaSelected.CollectionChanged += (sender, args) => FilterTypes();

            ZeitachseThemaSelected = zeitachseThemaSelected;
        }

        public void Init(int baPersonID)
        {
            Init();

            _baPersonID = baPersonID;

            Search(null);
        }

        public override KissServiceResult Search(IUnitOfWork unitOfWork)
        {
            var result = _zeitachseService.GetZeitachse(unitOfWork, _baPersonID);
            ZeitAchse = result;
            TimelineDTO = CreateTimeline(result);
            FilterTypes();

            return KissServiceResult.Ok();
        }

        #endregion

        #region Private Methods

        private FaTimelineDTO CreateTimeline(IEnumerable<FaZeitachseDTO> zeitachseDTOs)
        {
            var timelineDTO = new FaTimelineDTO { VisibleRangeBegin = VisibleRangeBegin, VisibleRangeEnd = VisibleRangeEnd };
            var swimlaneKategorie = new FaTimelineSwimmlaneDTO { Description = "Kategorie", BackgroundBrush = Brushes.Bisque };
            var swimlaneMain = new FaTimelineSwimmlaneDTO { Description = "Hauptzeitachse", BackgroundBrush = Brushes.BlanchedAlmond };
            var swimlaneWeisungen = new FaTimelineSwimmlaneDTO { Description = "Weisungen", BackgroundBrush = Brushes.Lavender };
            var swimlanePendenzen = new FaTimelineSwimmlaneDTO { Description = "Pendenzen", BackgroundBrush = Brushes.AliceBlue };

            var minDate = DateTime.Today;
            var maxDate = DateTime.Today;

            // Colors to use for background
            var brushes = new Brush[]
            {
            /*Not used = 0*/ null,
            /*AuswertungProzess = 1*/ Brushes.AliceBlue,
            /*Besprechungen = 2*/ Brushes.Aqua,
            /*FallUebergabe = 3*/ Brushes.Azure,
            /*Korrespondenz = 4*/ Brushes.DeepSkyBlue,
            /*Not used */ null,
            /*Vertraege = 6*/ Brushes.MistyRose,
            /*Weisungen = 7*/ Brushes.Olive,
            /*Ziele = 8*/ Brushes.YellowGreen,
            /*Not used */ null,
            /*PendenzenErledigt = 10*/ Brushes.LightSeaGreen,
            /*PendenzenOffen = 11*/ Brushes.LightCoral
            };

            var kategorien = _xLovService.GetLovCodeByLovName(null, "FaKategorie");

            foreach (var dto in zeitachseDTOs)
            {
                // Decice which swimm lane to add the item to
                FaTimelineSwimmlaneDTO currentSwimmlane;

                switch (dto.Type)
                {
                    case FaZeitachseDTOType.Kategorie:
                    case FaZeitachseDTOType.Falluebergabe:
                        currentSwimmlane = swimlaneKategorie;
                        break;
                    case FaZeitachseDTOType.Weisungen:
                        currentSwimmlane = swimlaneWeisungen;
                        break;
                    case FaZeitachseDTOType.PendenzenOffen:
                    case FaZeitachseDTOType.PendenzenErledigt:
                        currentSwimmlane = swimlanePendenzen;
                        break;
                    default:
                        currentSwimmlane = swimlaneMain;
                        break;
                }

                // Decice what item to create

                var zeitachseEventDto = dto as FaZeitachseEventDTO;
                var zeitachsePeriodDto = dto as FaZeitachsePeriodDTO;

                if (zeitachseEventDto != null)
                {
                    currentSwimmlane.TimelineItems.Add(
                    new FaTimelineEventDTO
                    {
                        BackgroundBrush = brushes[zeitachseEventDto.TypeInt],
                        StartDate = zeitachseEventDto.StartDate,
                        Description = zeitachseEventDto.Title,
                        Type = zeitachseEventDto.Type,
                        JumpToPath = zeitachseEventDto.JumpToPath,
                        EventType = zeitachseEventDto.Type == FaZeitachseDTOType.Falluebergabe ? EventTypeEnum.Falluebergabe : EventTypeEnum.Document,
                        DocFormat = zeitachseEventDto.DocFormat,
                        Empfaenger = zeitachseEventDto.Empfaenger,
                        Thema = zeitachseEventDto.Thema,
                        ThemaCodes = zeitachseEventDto.ThemaCodes,
                    });
                }

                if (zeitachsePeriodDto != null)
                {
                    Brush backgroundBrush = null;
                    if (zeitachsePeriodDto.Type != FaZeitachseDTOType.Kategorie)
                    {
                        backgroundBrush = brushes[zeitachsePeriodDto.TypeInt];
                    }
                    else
                    {
                        var kategorie = kategorien.Where(k => k.Code == zeitachsePeriodDto.KategorieCode).ToList();

                        if (kategorie.Any())
                        {
                            var value1 = kategorie.First().Value1;
                            if (value1.Length == 8)
                            {
                                var red = byte.Parse(value1.Substring(2, 2), NumberStyles.HexNumber);
                                var green = byte.Parse(value1.Substring(4, 2), NumberStyles.HexNumber);
                                var blue = byte.Parse(value1.Substring(6, 2), NumberStyles.HexNumber);

                                backgroundBrush = new SolidColorBrush(Color.FromArgb(255, red, green, blue));
                                zeitachsePeriodDto.Title = kategorie.First().Text;
                            }
                        }
                    }

                    var timelinePeriod = new FaTimelinePeriodDTO
                    {
                        BackgroundBrush = backgroundBrush,
                        StartDate = zeitachsePeriodDto.StartDate,
                        EndDate = zeitachsePeriodDto.EndDate,
                        Description = zeitachsePeriodDto.Title,
                        Type = zeitachsePeriodDto.Type,
                        PendenzStatus = zeitachsePeriodDto.PendenzStatus,
                        PeriodEvents = zeitachsePeriodDto.Documents == null
                                           ? new ObservableCollection<FaTimelineEventDTO>()
                                           : new ObservableCollection<FaTimelineEventDTO>(zeitachsePeriodDto.Documents.Select(
                                               doc => new FaTimelineEventDTO
                                               {
                                                   StartDate = doc.StartDate,
                                                   Description = doc.Title,
                                                   EventType = EventTypeEnum.Document,
                                                   Type = doc.Type,
                                                   DocFormat = doc.DocFormat,
                                                   JumpToPath = doc.JumpToPath,
                                                   Empfaenger = doc.Empfaenger,
                                                   Thema = doc.Thema,
                                                   ThemaCodes = doc.ThemaCodes,
                                               })
                                             .Concat(zeitachsePeriodDto.DateLabels.Select(
                                               label => new FaTimelineEventDTO
                                               {
                                                   StartDate = label.StartDate,
                                                   Description = label.Title,
                                                   EventType = EventTypeEnum.DateLabel,
                                                   Type = label.Type,
                                                   JumpToPath = label.JumpToPath,
                                                   Empfaenger = label.Empfaenger,
                                                   Thema = label.Thema,
                                                   ThemaCodes = label.ThemaCodes,
                                               })).ToList()),
                        JumpToPath = dto.JumpToPath,
                    };

                    currentSwimmlane.TimelineItems.Add(timelinePeriod);
                }

                // update min/max time to get the whole date range of the time line
                if (dto.StartDate < minDate)
                {
                    minDate = dto.StartDate;
                }

                var endDate = zeitachsePeriodDto != null ? zeitachsePeriodDto.EndDate : dto.StartDate;
                if (endDate > maxDate)
                {
                    maxDate = endDate.Value;
                }
            }

            // update and set min/max date
            var minDateToShow = DateTime.Today.AddMonths(-_anzahlMonateInVergangenheit);
            var maxDateToShow = DateTime.Today.AddMonths(_anzahlMonateInZukuft);

            // add some days before the first and after the last item (10 days should be enough to make the items always visible)
            minDate = minDate.AddDays(-10);
            maxDate = maxDate.AddDays(10);

            TotalRangeBegin = minDate > minDateToShow ? minDateToShow : minDate;
            TotalRangeEnd = maxDate < maxDateToShow ? maxDateToShow : maxDate;

            timelineDTO.TotalRangeBegin = TotalRangeBegin;
            timelineDTO.TotalRangeEnd = TotalRangeEnd;

            // Only add swim lanes with more than one item
            if (swimlaneKategorie.TimelineItems.Count > 0)
            {
                timelineDTO.Swimmlanes.Add(swimlaneKategorie);
            }
            if (swimlaneMain.TimelineItems.Count > 0)
            {
                timelineDTO.Swimmlanes.Add(swimlaneMain);
            }

            if (swimlaneWeisungen.TimelineItems.Count > 0)
            {
                timelineDTO.Swimmlanes.Add(swimlaneWeisungen);
            }

            if (swimlanePendenzen.TimelineItems.Count > 0)
            {
                timelineDTO.Swimmlanes.Add(swimlanePendenzen);
            }

            var eventDates = new List<DateTime>();
            foreach (var swimlane in timelineDTO.Swimmlanes)
            {
                foreach (var dto in swimlane.TimelineItems)
                {
                    eventDates.Add(dto.StartDate);
                }
            }
            timelineDTO.EventDates = eventDates;

            return timelineDTO;
        }

        #endregion

        #endregion
    }
}