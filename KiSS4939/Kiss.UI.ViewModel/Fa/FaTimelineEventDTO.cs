using Kiss.Infrastructure.Constant;

namespace Kiss.UI.ViewModel.Fa
{
    /// <summary>
    /// Model class for an event on the timeline
    /// </summary>
    public class FaTimelineEventDTO : FaTimelineItemDTO
    {
        #region Properties

        public EventTypeEnum EventType { get; set; }

        public LOVsGenerated.DocFormat? DocFormat
        {
            get;
            set;
        }

        // Besprechung   -> Kontaktpartner
        // Korrespondenz -> Adressat
        // Weisung       -> Betroffene Person
        // Pendenz       -> Empfaenger
        public string Empfaenger
        {
            get;
            set;
        }

        public string Thema
        {
            get;
            set;
        }


        #endregion
    }

    public enum EventTypeEnum
    {
        Document = 1,
        DateLabel = 2,
        Falluebergabe = 3,
    }
}