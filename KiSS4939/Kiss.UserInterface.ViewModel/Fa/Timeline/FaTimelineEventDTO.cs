using Kiss.DbContext.Enums.Sys;

namespace Kiss.UserInterface.ViewModel.Fa.Timeline
{
    /// <summary>
    /// Model class for an event on the timeline
    /// </summary>
    public class FaTimelineEventDTO : FaTimelineItemDTO
    {
        #region Properties

        public EventTypeEnum EventType { get; set; }

        public DocumentFormat? DocFormat { get; set; }

        // Besprechung   -> Kontaktpartner
        // Korrespondenz -> Adressat
        // Weisung       -> Betroffene Person
        // Pendenz       -> Empfaenger
        public string Empfaenger { get; set; }

        #endregion
    }

    public enum EventTypeEnum
    {
        Document = 1,
        DateLabel = 2,
        Falluebergabe = 3,
    }
}