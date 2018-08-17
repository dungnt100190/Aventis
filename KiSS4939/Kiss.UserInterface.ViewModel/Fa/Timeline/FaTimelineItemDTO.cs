using System;
using System.Windows.Media;

using Kiss.DbContext;
using Kiss.DbContext.DTO.Fa;
using Kiss.Infrastructure;

namespace Kiss.UserInterface.ViewModel.Fa.Timeline
{
    public class FaTimelineItemDTO : Bindable
    {
        #region Fields

        #region Private Fields

        private DateTime _startDate;

        #endregion

        #endregion

        #region Properties

        public Brush BackgroundBrush { get; set; }

        public string Description { get; set; }

        public string ShortText { get; set; }

        public bool IsVisible { get; set; }

        public bool HasJumpToPath
        {
            get { return !string.IsNullOrWhiteSpace(JumpToPath); }
        }

        public string JumpToPath { get; set; }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value.Date; }
        }

        public XLOVCode[] ThemaCodes { get; set; }

        public FaZeitachseDTOType Type { get; set; }

        #endregion
    }
}