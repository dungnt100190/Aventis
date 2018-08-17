using System;
using System.ComponentModel;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Enumeration;

namespace Kiss.Model.DTO.Wsh
{
    public class WshPositionAbzugDTO : DTO, IObjectWithChangeTracker
    {
        #region Fields

        #region Private Fields

        private bool _aktiv;
        private decimal _saldo;
        private WshPosition _wshPosition;

        #endregion

        #endregion

        #region Constructors

        public WshPositionAbzugDTO()
        {
        }

        public WshPositionAbzugDTO(WshPosition wshPosition)
        {
            if (wshPosition == null)
            {
                throw new ArgumentNullException("wshPosition");
            }

            WshPosition = wshPosition;
        }

        #endregion

        #region Properties

        public bool Aktiv
        {
            get { return _aktiv; }
            set
            {
                if (_aktiv == value)
                {
                    return;
                }

                _aktiv = value;

                if (WshPosition != null)
                {
                    //ChangeTracker.State = ObjectState.Modified;
                    WshPosition.Betrag = BetragAnzeige;
                }

                NotifyPropertyChanged.RaisePropertyChanged(() => Aktiv);
                NotifyPropertyChanged.RaisePropertyChanged(() => BetragAnzeige);
            }
        }

        public decimal BetragAnzeige
        {
            get
            {
                if (WshPosition == null
                    || ((WshPosition.PositionsStatus & WshPositionsstatus.Vorbereitet) > 0) && !Aktiv)
                {
                    return 0m;
                }
                return WshPosition.Betrag;
            }
        }

        public ObjectChangeTracker ChangeTracker
        {
            get { return WshPosition.ChangeTracker; }
        }

        public bool IsAktivEditable
        {
            get
            {
                return WshPosition != null && (
                    (WshPosition.PositionsStatus & WshPositionsstatus.Vorbereitet) > 0);
            }
        }

        public decimal Saldo
        {
            get { return _saldo; }
            set
            {
                if (_saldo == value)
                {
                    return;
                }

                _saldo = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => Saldo);
            }
        }

        public WshPosition WshPosition
        {
            get { return _wshPosition; }
            set
            {
                if (_wshPosition == value)
                {
                    return;
                }

                _wshPosition = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => WshPosition);

                if (_wshPosition != null)
                {
                    _wshPosition.PropertyChanged += WshPosition_PropertyChanged;
                    Aktiv = WshPosition.Betrag > 0m;
                }
                else
                {
                    Aktiv = false;
                }
            }
        }

        #endregion

        #region EventHandlers

        private void WshPosition_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == PropertyName.GetPropertyName(() => WshPosition.Betrag))
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => BetragAnzeige);
            }
        }

        #endregion
    }
}