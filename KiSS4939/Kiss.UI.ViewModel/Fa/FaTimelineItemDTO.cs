using System;
using System.Collections.Generic;
using System.Windows.Media;

using Kiss.Model.DTO;
using Kiss.Model.DTO.Fa;

namespace Kiss.UI.ViewModel.Fa
{
    public class FaTimelineItemDTO : DTO
    {
        #region Fields

        #region Private Fields

        private bool _isFilteredOut;
        private DateTime _startDate;

        #endregion

        #endregion

        #region Properties

        public Brush BackgroundBrush
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public bool HasJumpToPath
        {
            get { return !string.IsNullOrWhiteSpace(JumpToPath); }
        }

        public bool IsFilteredOut
        {
            get { return _isFilteredOut; }
            set
            {
                if (_isFilteredOut == value)
                    return;

                _isFilteredOut = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsFilteredOut);
            }
        }

        public string JumpToPath
        {
            get;
            set;
        }

        public DateTime StartDate
        {
            get { return _startDate; }
            set { _startDate = value.Date; }
        }

        public List<int> ThemaCodes
        {
            get;
            set;
        }

        public FaZeitachseDTOType Type
        {
            get;
            set;
        }

        public int VirtualAxisFrom
        {
            get;
            set;
        }

        #endregion
    }
}