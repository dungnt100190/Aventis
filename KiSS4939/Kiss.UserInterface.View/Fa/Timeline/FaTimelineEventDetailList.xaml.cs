using System.Collections.Generic;
using System.Windows;
using Kiss.DbContext.DTO.Fa;
using Kiss.UserInterface.ViewModel.Fa.Timeline;

namespace Kiss.UserInterface.View.Fa.Timeline
{
    /// <summary>
    /// Interaction logic for FaTimelineEventPopup.xaml
    /// </summary>
    public partial class FaTimelineEventDetailList
    {
        public FaTimelineEventDetailList()
        {
            InitializeComponent();
            grid.DataContext = this;
        }

        public object TimelineItems
        {
            get { return GetValue(TimelineItemsProperty); }
            set { SetValue(TimelineItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TimelineItems.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TimelineItemsProperty =
            DependencyProperty.Register("TimelineItems", typeof(object), typeof(FaTimelineEventDetailList), new UIPropertyMetadata(null, TimelineItemsChanged));

        private static void TimelineItemsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (FaTimelineEventDetailList)dependencyObject;
            var items = e.NewValue as IEnumerable<FaTimelineEventDTO>;
            if (items == null && e.NewValue is FaTimelineEventDTO)
            {
                items = new[] { e.NewValue as FaTimelineEventDTO };
            }
            instance.PrepareGui(items);
        }



        public double BalloonRootHorizontalOffset
        {
            get { return (double)GetValue(BalloonRootHorizontalOffsetProperty); }
            set { SetValue(BalloonRootHorizontalOffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BalloonRootHorizontalOffset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BalloonRootHorizontalOffsetProperty =
            DependencyProperty.Register("BalloonRootHorizontalOffset", typeof(double), typeof(FaTimelineEventDetailList), new UIPropertyMetadata(0.0, BalloonRootHorizontalOffsetChanged));

        private static void BalloonRootHorizontalOffsetChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            var instance = (FaTimelineEventDetailList)dependencyObject;
            var offset = (double)e.NewValue;
            instance.rootPointer.Margin = new Thickness(offset, 0, -offset, 0);
        }

        private void PrepareGui(IEnumerable<FaTimelineItemDTO> items)
        {
            var hasBesprechung = false;
            var hasKorrespondenz = false;
            var hasWeisung = false;
            var hasPendenz = false;
            var hasJumpToPath = false;
            var hasImage = false;

            if (items == null)
            {
                return;
            }
            // Ereignisse loopen, um vorhandene Typen zu bestimmen
            foreach (var timelineEvent in items)
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

                if (timelineEvent.JumpToPath != null)
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
                lblEmpfaenger.Text = "Kontaktpartner";
                colEmpfaenger.Width = GridLength.Auto;
                colThemen.Width = GridLength.Auto;
            }

            if (hasKorrespondenz)
            {
                lblEmpfaenger.Text = "Adressat";
                colEmpfaenger.Width = GridLength.Auto;
                colThemen.Width = GridLength.Auto;
            }

            if (hasBesprechung && hasKorrespondenz)
            {
                lblEmpfaenger.Text = "Adressat/Kontaktpartner";
            }

            if (hasWeisung)
            {
                lblEmpfaenger.Text = "Betroffene Person";
                colEmpfaenger.Width = GridLength.Auto;
            }

            if (hasPendenz)
            {
                lblEmpfaenger.Text = "Empfänger";
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
        }
    }
}
