using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

using Kiss.Model.DTO.Fa;
using Kiss.UI.ViewModel.Fa;

namespace Kiss.UI.View.Fa.Controls
{
    /// <summary>
    /// Represents an event on a timeline axis (swim lane)
    /// </summary>
    public partial class FaTimelineEvent
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly DispatcherTimer _doubleClickTimer;
        private readonly FaTimelineEventBatchDTO _eventBatch;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initialize the object
        /// </summary>
        /// <param name="eventBatch">List of event data to draw</param>
        public FaTimelineEvent(FaTimelineEventBatchDTO eventBatch)
        {
            InitializeComponent();
            _eventBatch = eventBatch;
            DataContext = _eventBatch;
            SwitchImages();

            //Solange wir EnableImages() manuell aufrufen müssen wir einen PropertyChanged Eventhandler registrieren
            _eventBatch.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "VisibleEvents")
                {
                    SwitchImages();
                }
            };

            _doubleClickTimer = new DispatcherTimer(DispatcherPriority.Background)
            {
                Interval = ViewHelper.GetDoubleClickTimeSpan()
            };
            _doubleClickTimer.Tick += DoubleClickTimer_Tick;
        }

        #endregion

        #region EventHandlers

        private void ButtonTimeLineImage_Click(object sender, RoutedEventArgs e)
        {
            if (_eventBatch.VisibleEvents.Count == 1 && _eventBatch.VisibleEvents[0].HasJumpToPath)
            {
                // Timer für Unterscheidung Single/Doppelklick starten
                _doubleClickTimer.Start();
            }
            else
            {
                OpenPopup();
            }
        }

        private void ButtonTimeLineImage_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Doppelklick: Direkter Absprung
            _doubleClickTimer.Stop();

            if (_eventBatch.VisibleEvents.Count == 1 && _eventBatch.VisibleEvents[0].HasJumpToPath)
            {
                FaTimelineUtility.ExecuteJumpToPath(_eventBatch.VisibleEvents[0].JumpToPath);
            }
        }

        private void DoubleClickTimer_Tick(object sender, EventArgs e)
        {
            // Singleklick: Popup öffnen
            _doubleClickTimer.Stop();

            OpenPopup();
        }

        private void btnJumpToPath_Click(object sender, RoutedEventArgs e)
        {
            var dto = ((Button)sender).DataContext as FaTimelineEventDTO;

            if (dto != null && dto.HasJumpToPath)
            {
                FaTimelineUtility.ExecuteJumpToPath(dto.JumpToPath);
                Balloon.IsOpen = false;
            }
        }

        private void onZahl_Loaded(object sender, RoutedEventArgs e)
        {
            if (_eventBatch.VisibleEvents.Count().ToString().Length == 1)
            {
                ((TextBlock)sender).Margin = new Thickness(5, 3, 0, 0);
            }
            else if (_eventBatch.VisibleEvents.Count().ToString().Length == 2)
            {
                ((TextBlock)sender).Margin = new Thickness(3, 3, 0, 0);
            }
            else
            {
                ((TextBlock)sender).Margin = new Thickness(1, 3, 0, 0);
            }
        }

        #endregion

        #region Methods

        #region Private Methods

        private void OpenPopup()
        {
            bool hasBesprechung = false;
            bool hasKorrespondenz = false;
            bool hasWeisung = false;
            bool hasPendenz = false;
            bool hasJumpToPath = false;
            bool hasImage = false;

            // Ereignisse loopen, um vorhandene Typen zu bestimmen
            foreach (var timelineEvent in _eventBatch.VisibleEvents)
            {
                switch (timelineEvent.Type)
                {
                    case FaZeitachseDTOType.Besprechungen:
                        hasBesprechung = true;
                        hasImage = true;
                        break;

                    case FaZeitachseDTOType.Korrespondenz:
                        hasKorrespondenz = true;
                        hasImage = true;
                        break;

                    case FaZeitachseDTOType.Weisungen:
                        hasWeisung = true;
                        break;

                    case FaZeitachseDTOType.PendenzenErledigt:
                    case FaZeitachseDTOType.PendenzenOffen:
                        hasPendenz = true;
                        break;
                }

                if (timelineEvent.HasJumpToPath)
                {
                    hasJumpToPath = true;
                }
            }

            //Spalten zunaechst disablen, je nach Typ enablen:
            colEmpfaenger.Width = new GridLength(0);
            colStatus.Width = new GridLength(0);
            colThemen.Width = new GridLength(0);
            colLink.Width = new GridLength(0);
            colImage.Width = new GridLength(0);

            if (hasBesprechung)
            {
                lblEmpfaenger.Content = "Kontaktpartner";
                colEmpfaenger.Width = GridLength.Auto;
                colThemen.Width = GridLength.Auto;
            }

            if (hasKorrespondenz)
            {
                lblEmpfaenger.Content = "Adressat";
                colEmpfaenger.Width = GridLength.Auto;
                colThemen.Width = GridLength.Auto;
            }

            if (hasBesprechung && hasKorrespondenz)
            {
                lblEmpfaenger.Content = "Adressat/Kontaktpartner";
            }

            if (hasWeisung)
            {
                lblEmpfaenger.Content = "Betroffene Person";
                colEmpfaenger.Width = GridLength.Auto;
            }

            if (hasPendenz)
            {
                lblEmpfaenger.Content = "Empfänger";
                colEmpfaenger.Width = GridLength.Auto;
                colStatus.Width = GridLength.Auto;
            }

            if (hasJumpToPath)
            {
                colLink.Width = GridLength.Auto;
            }

            if (hasImage)
            {
                colImage.Width = GridLength.Auto;
            }

            Balloon.IsOpen = true;
        }

        private void SwitchImages()
        {
            var count = _eventBatch.VisibleEvents.Count();
            if (count == 0)
            {
                ButtonTimeLineImage.Visibility = Visibility.Hidden;
            }
            else if (count > 1)
            {
                ButtonTimeLineImage.Visibility = Visibility.Visible;
                GridEllipse.Visibility = Visibility.Visible;
            }
            else if (count == 1) // nur ein Dokument
            {
                ButtonTimeLineImage.Visibility = Visibility.Visible;
                GridEllipse.Visibility = Visibility.Hidden;
            }
        }

        #endregion

        #endregion
    }
}