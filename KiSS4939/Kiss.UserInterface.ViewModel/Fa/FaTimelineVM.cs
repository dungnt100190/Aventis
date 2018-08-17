using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Windows.Media;

using Kiss.BusinessLogic.System;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;
using Kiss.Infrastructure.IoC;

namespace Kiss.UserInterface.ViewModel.Fa
{
    /// <summary>
    /// Model clas for the timeline control
    /// </summary>
    public class FaTimelineVM
    {
        #region Constructors

        private readonly IDictionary<Swimlane, Brush> _brushes = new Dictionary<Swimlane, Brush>
                                                                     {
                                                                         {Swimlane.Kategorie, Brushes.Bisque},
                                                                         {Swimlane.Main, Brushes.BlanchedAlmond},
                                                                         {Swimlane.Weisungen, Brushes.Lavender},
                                                                         {Swimlane.Pendenzen, Brushes.AliceBlue},
                                                                     };

        // ToDo: Multilanguage
        private readonly IDictionary<Swimlane, string> _descriptions = new Dictionary<Swimlane, string>
                                                                           {
                                                                               {Swimlane.Kategorie, "Kategorie"},
                                                                               {Swimlane.Main, "Hauptzeitachse"},
                                                                               {Swimlane.Weisungen, "Weisungen"},
                                                                               {Swimlane.Pendenzen, "Pendenzen"},
                                                                           };

        public FaTimelineVM(IEnumerable<FaZeitachseDTO> zeitachseItems, TimePeriod visibleRange, TimePeriod totalRange)
        {
            var swimlanes = new Dictionary<Swimlane, List<FaTimelineItemDTO>>
                                {
                                    {Swimlane.Kategorie, new List<FaTimelineItemDTO>()},
                                    {Swimlane.Main, new List<FaTimelineItemDTO>()},
                                    {Swimlane.Weisungen, new List<FaTimelineItemDTO>()},
                                    {Swimlane.Pendenzen,new List<FaTimelineItemDTO>()}
                                };

            // Colors to use for background
            var brushes = new Dictionary<FaZeitachseDTOType, Brush>
                              {
                                  {FaZeitachseDTOType.AuswertungProzess, Brushes.AliceBlue},
                                  {FaZeitachseDTOType.Besprechungen, Brushes.Aqua},
                                  {FaZeitachseDTOType.Falluebergabe, Brushes.Azure},
                                  {FaZeitachseDTOType.Korrespondenz, Brushes.DeepSkyBlue},
                                  {FaZeitachseDTOType.Vertraege, Brushes.MistyRose},
                                  {FaZeitachseDTOType.Weisungen, Brushes.Olive},
                                  {FaZeitachseDTOType.Ziele, Brushes.YellowGreen},
                                  {FaZeitachseDTOType.PendenzenErledigt, Brushes.LightSeaGreen},
                                  {FaZeitachseDTOType.PendenzenOffen, Brushes.LightCoral}
                              };

            var xLovService = Container.Resolve<XLovService>();
            var kategorien = xLovService.GetLovCodesByLovName("FaKategorie"); // ToDo: magic string

            // ToDo: mit Linq vereinfachen
            foreach (var swimlaneGroup in zeitachseItems
                                          .GroupBy(itm => MapTimelineTypeToSwimlaneType(itm.Type), itm => itm))
            {
                var currentSwimmlane = swimlanes[swimlaneGroup.Key];
                foreach (var dto in swimlaneGroup)
                {

                    // Decice what item to create
                    var zeitachseEventDto = dto as FaZeitachseEventDTO;
                    var zeitachsePeriodDto = dto as FaZeitachsePeriodDTO;

                    if (zeitachseEventDto != null)
                    {
                        currentSwimmlane.Add(new FaTimelineEventDTO
                                                 {
                                                     BackgroundBrush = brushes[zeitachseEventDto.Type],
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
                            backgroundBrush = brushes[zeitachsePeriodDto.Type];
                        }
                        else
                        {
                            var kategorie = kategorien.FirstOrDefault(k => k.Code == zeitachsePeriodDto.KategorieCode);

                            if (kategorie != null)
                            {
                                var value1 = kategorie.Value1;
                                if (value1.Length == 8)
                                {
                                    var red = byte.Parse(value1.Substring(2, 2), NumberStyles.HexNumber);
                                    var green = byte.Parse(value1.Substring(4, 2), NumberStyles.HexNumber);
                                    var blue = byte.Parse(value1.Substring(6, 2), NumberStyles.HexNumber);

                                    backgroundBrush = new SolidColorBrush(Color.FromArgb(byte.MaxValue, red, green, blue));
                                    zeitachsePeriodDto.Title = kategorie.Text;
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
                                               ? new FaTimelineEventDTO[] { }
                                               : zeitachsePeriodDto.Documents.Select(
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
                                                                })).ToArray(),
                            JumpToPath = dto.JumpToPath,
                        };

                        currentSwimmlane.Add(timelinePeriod);
                    }
                }
            }

            // Only add swimlanes that contain items
            Swimlanes = new ObservableCollection<FaTimelineSwimlaneVM>(swimlanes
                                                                       .Where(swl => swl.Value.Any())
                                                                       .Select(swl => CreateSwimlane(visibleRange, totalRange, swl)));
        }

        private FaTimelineSwimlaneVM CreateSwimlane(TimePeriod visibleRange, TimePeriod totalRange, KeyValuePair<Swimlane, List<FaTimelineItemDTO>> swl)
        {
            var swimlane = new FaTimelineSwimlaneVM(swl.Value)
                               {
                                   BackgroundBrush = _brushes[swl.Key],
                                   Description = _descriptions[swl.Key],
                                   ShortDescription = _descriptions[swl.Key].Substring(0, 3).ToUpper(),
                                   VisibleRange = visibleRange,
                                   TotalRange = totalRange
                               };
            return swimlane;
        }

        private static Swimlane MapTimelineTypeToSwimlaneType(FaZeitachseDTOType type)
        {
            switch (type)
            {
                case FaZeitachseDTOType.Kategorie:
                case FaZeitachseDTOType.Falluebergabe:
                    return Swimlane.Kategorie;

                case FaZeitachseDTOType.Weisungen:
                    return Swimlane.Weisungen;

                case FaZeitachseDTOType.PendenzenOffen:
                case FaZeitachseDTOType.PendenzenErledigt:
                    return Swimlane.Pendenzen;

                default:
                    return Swimlane.Main;
            }
        }

        #endregion

        #region Properties

        public ObservableCollection<FaTimelineSwimlaneVM> Swimlanes { get; set; }

        private TimePeriod _visibleRange;
        public TimePeriod VisibleRange
        {
            get { return _visibleRange; }
            set
            {
                _visibleRange = value;
                if (Swimlanes != null)
                {
                    foreach (var swimlane in Swimlanes)
                    {
                        swimlane.VisibleRange = value;
                    }
                }
            }
        }

        public IEnumerable<int> VisibleThemen
        {
            set
            {
                foreach (var swimlane in Swimlanes)
                {
                    swimlane.VisibleThemen = value;
                }
            }
        }

        public IEnumerable<FaZeitachseDTOType> VisibleItemTypes
        {
            set
            {
                foreach (var swimlane in Swimlanes)
                {
                    swimlane.VisibleItemTypes = value;
                }
            }
        }

        #endregion
    }
}