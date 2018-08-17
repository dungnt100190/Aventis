using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

using Kiss.Model.DTO.Fa;
using Kiss.UI.ViewModel.Fa;

namespace Kiss.UI.View.Fa.Controls
{
    /// <summary>
    /// Represents one timeline axis on the TimelineControl (swim lane)
    /// </summary>
    public partial class FaTimelineSwimmlane : INotifyPropertyChanged
    {
        #region Fields

        #region Public Static Fields

        // Dependency Property for Axis
        public static readonly DependencyProperty SwimmlaneProperty = DependencyProperty.Register("Swimmlane", typeof(FaTimelineSwimmlaneDTO), typeof(FaTimelineSwimmlane), new PropertyMetadata(null, OnSwimmlanePropertyChanged));

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes the control and hooks up events
        /// </summary>
        public FaTimelineSwimmlane()
        {
            InitializeComponent();
        }

        #endregion

        #region Events

        /// <summary>
        /// Event handler for PropertyChanged events
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        // .NET Property wrapper for Swimmlane property
        public FaTimelineSwimmlaneDTO Swimmlane
        {
            get { return (FaTimelineSwimmlaneDTO)GetValue(SwimmlaneProperty); }
            set { SetValue(SwimmlaneProperty, value); }
        }

        #endregion

        #region Methods

        #region Public Methods

        public double CalculateCanvasHeight()
        {
            var periodDtos = Swimmlane.TimelineItems.OfType<FaTimelinePeriodDTO>().ToList();
            int numberOfVirtualAxis;

            if (periodDtos.Count > 0)
            {
                numberOfVirtualAxis = periodDtos.Max(p => p.VirtualAxisTo) + 1;
            }
            else
            {
                numberOfVirtualAxis = 1;
            }

            return numberOfVirtualAxis * Swimmlane.TimelineUtility.VirtualaxisHeight + 30;
        }

        // Draws events in the Swimlane
        public void DrawEvents()
        {
            if (Swimmlane != null)
            {
                if (Swimmlane.TimelineUtility != null)
                {
                    ClearEvents();

                    var timelineEvents =
                        Swimmlane.TimelineItems.OfType<FaTimelineEventDTO>().OrderByDescending(te => te.StartDate);
                    var timelinePeriods =
                        Swimmlane.TimelineItems.OfType<FaTimelinePeriodDTO>().OrderByDescending(tp => tp.StartDate);

                    if (timelineEvents.Count() != 0)
                    {
                        foreach (var te in timelineEvents)
                        {
                            te.VirtualAxisFrom = te.EventType == EventTypeEnum.Falluebergabe ? 1 : 0;
                        }
                    }

                    Swimmlane.TimelineUtility.CreateBatchList(Swimmlane.BatchList, timelineEvents);
                    foreach (var batch in Swimmlane.BatchList)
                    {
                        var timelineItem = CreateTimelineEvent(batch);

                        // Add element to canvas
                        CanvasEvents.Children.Add(timelineItem);
                        CanvasEvents.UpdateLayout();

                        // Position the batch to the start date of the first element
                        var startDate = batch.Events.Min(te => te.StartDate);
                        var x = Swimmlane.TimelineUtility.DateToX(startDate);
                        Canvas.SetLeft(timelineItem, x - (timelineItem.ActualWidth / 2));

                        // Events are always on top of periods
                        Canvas.SetZIndex(timelineItem, 100);
                    }

                    bool isFirst = true;

                    foreach (var tp in timelinePeriods.OrderBy(x => x.StartDate))
                    {
                        var timelineItem = CreateTimelinePeriod(tp);

                        if (!isFirst)
                        {
                            while (Swimmlane.TimelineUtility.IsOverlapping(Swimmlane, tp))
                            {
                                tp.VirtualAxisFrom++;
                            }
                        }

                        isFirst = false;

                        var x = Swimmlane.TimelineUtility.DateToX(tp.StartDate);

                        Canvas.SetLeft(timelineItem, x);

                        // Add it to the canvas
                        CanvasEvents.Children.Add(timelineItem);

                        Canvas.SetTop(timelineItem, tp.VirtualAxisFrom * Swimmlane.TimelineUtility.VirtualaxisHeight);

                        // Periods are always underneath events
                        Canvas.SetZIndex(timelineItem, 0);
                    }
                }
            }
            CanvasEvents.Height = CalculateCanvasHeight();
            DrawTodayLine(CanvasEvents.Height);
        }

        #endregion

        #region Protected Methods

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Private Static Methods

        /// <summary>
        ///  Called when the swimmlane is bound to the control
        ///  Calls OnModelPropertyChanged on the actual object
        /// </summary>
        /// <param name="dependencyObject">Swimmlane that raised the event</param>
        /// <param name="e">Event parameters</param>
        private static void OnSwimmlanePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject != null)
            {
                var timeline = (FaTimelineSwimmlane)dependencyObject;
                timeline.OnPropertyChanged("Swimmlane");
                timeline.OnSwimmlanePropertyChanged(e);
            }
        }

        #endregion

        #region Private Methods

        private void ClearEvents()
        {
            CanvasEvents.Children.Clear();
        }

        private UserControl CreateTimelineEvent(FaTimelineEventBatchDTO eventBatch)
        {
            // Create a new TimelineItem
            var timelineItem = new FaTimelineEvent(eventBatch);
            return timelineItem;
        }

        private UserControl CreateTimelinePeriod(FaTimelinePeriodDTO timelinePeriod)
        {
            Swimmlane.TimelineUtility.CreateBatchList(timelinePeriod.BatchList, timelinePeriod.PeriodEvents);
            var allDates = new List<DateTime?>();
            allDates.Add(DateTime.Today);
            foreach (var faTimelineEventBatchDto in timelinePeriod.BatchList)
            {
                allDates.AddRange(faTimelineEventBatchDto.Events.Select(e => new DateTime?(e.StartDate)));
            }
            var latestDate = allDates.Max() ?? DateTime.Today;
            latestDate = timelinePeriod.EndDate == null ? latestDate.AddDays(1) : latestDate;  //Einen Tag länger zeichnen, wenn die Periode nicht abgeschlossen ist (Blur-Effekt)
            var endDate = timelinePeriod.EndDate ?? latestDate.Date;
            var width = Swimmlane.TimelineUtility.DateToWidth(timelinePeriod.StartDate, endDate.AddDays(1).AddSeconds(-1));

            var timelineItem = new FaTimelinePeriod(timelinePeriod, Swimmlane.TimelineUtility);
            timelineItem.Width = Math.Max(width, 10);

            if (timelinePeriod.Type == FaZeitachseDTOType.Kategorie)
            {
                timelineItem.OuterBorder.CornerRadius = new CornerRadius(0);
            }

            return timelineItem;
        }

        private void DrawTodayLine(double totalSwimmlaneHeight)
        {
            // Place today line
            var xToday = Swimmlane.TimelineUtility.DateToX(DateTime.Today);
            var lineToday = new Line { X1 = xToday, X2 = xToday, Y1 = -15, Y2 = totalSwimmlaneHeight, Stroke = Brushes.Red, Opacity = 0.2 };
            Canvas.SetZIndex(lineToday, -500);
            CanvasEvents.Children.Add(lineToday);
        }

        /// <summary>
        /// Called when the swimmlane changes
        /// </summary>
        /// <param name="e">Event parameters with new values</param>
        private void OnSwimmlanePropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            Swimmlane = (FaTimelineSwimmlaneDTO)e.NewValue;
        }

        #endregion

        #endregion
    }
}