using System;

namespace Kiss.Model.DTO.Wsh
{
    public class WshAuszahlvorschlagPositionDTO : DTO
    {
        #region Fields

        #region Private Fields

        private decimal _verfuegbar;

        #endregion

        #endregion

        #region Properties

        public BaPerson Betrifft
        {
            get; set;
        }

        public bool IsAusgabe
        {
            get; set;
        }

        public string Kostenart
        {
            get; set;
        }

        public DateTime? MonatBis
        {
            get; set;
        }

        public DateTime? MonatVon
        {
            get; set;
        }

        public string Text
        {
            get; set;
        }

        public decimal Verfuegbar
        {
            get { return _verfuegbar; }
            set
            {
                _verfuegbar = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Verfuegbar);
            }
        }

        public WshPosition WshPosition
        {
            get; set;
        }

        #endregion
    }
}