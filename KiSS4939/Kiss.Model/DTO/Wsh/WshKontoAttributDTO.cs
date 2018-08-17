using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kiss.Model.DTO.Wsh
{

    public class WshKontoAttributDTO : DTO, IObjectWithChangeTracker
    {

        private void UpdateChangeTracker()
        {
            if (ChangeTracker.State != ObjectState.Added && ChangeTracker.State != ObjectState.Deleted)
            {
                ChangeTracker.State = ObjectState.Modified;
            }
        }

        public int KbuKontoID { get; set; }
        public string KontoNr { get; set; }
        public string KontoName { get; set; }

        public int WshKontoAttributID { get; set; }

        private bool _istGrundbudgetAktiv;
        public bool IstGrundbudgetAktiv
        {
            get { return _istGrundbudgetAktiv; }
            set
            {
                if (_istGrundbudgetAktiv != value)
                {
                    _istGrundbudgetAktiv = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IstGrundbudgetAktiv);
                    UpdateChangeTracker();
                }
            }
        }

        private bool _istMonatsbudgetAktiv;
        public bool IstMonatsbudgetAktiv
        {
            get { return _istMonatsbudgetAktiv; }
            set
            {
                if (_istMonatsbudgetAktiv != value)
                {
                    _istMonatsbudgetAktiv = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IstMonatsbudgetAktiv);
                    UpdateChangeTracker();
                }
            }
        }

        private bool _istLeistungWsh;
        public bool IstLeistungWsh
        {
            get { return _istLeistungWsh; }
            set
            {
                if (_istLeistungWsh != value)
                {
                    _istLeistungWsh = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IstLeistungWsh);
                    UpdateChangeTracker();
                }
            }
        }

        private bool _istLeistungWshStationaer;
        public bool IstLeistungWshStationaer
        {
            get { return _istLeistungWshStationaer; }
            set
            {
                if (_istLeistungWshStationaer != value)
                {
                    _istLeistungWshStationaer = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => IstLeistungWshStationaer);
                    UpdateChangeTracker();
                }
            }
        }

        private int _sysEditModeCode_BetrifftPerson;
        public int SysEditModeCode_BetrifftPerson
        {
            get { return _sysEditModeCode_BetrifftPerson; }
            set
            {
                if (_sysEditModeCode_BetrifftPerson != value)
                {
                    _sysEditModeCode_BetrifftPerson = value;
                    NotifyPropertyChanged.RaisePropertyChanged(() => SysEditModeCode_BetrifftPerson);
                    UpdateChangeTracker();
                }
            }
        }

        private ObjectChangeTracker _changeTracker;
        public ObjectChangeTracker ChangeTracker
        {
            get
            {
                if (_changeTracker == null)
                {
                    _changeTracker = new ObjectChangeTracker();
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
                return _changeTracker;
            }
            set
            {
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging -= HandleObjectStateChanging;
                }
                _changeTracker = value;
                if (_changeTracker != null)
                {
                    _changeTracker.ObjectStateChanging += HandleObjectStateChanging;
                }
            }
        }

        private void HandleObjectStateChanging(object sender, ObjectStateChangingEventArgs e)
        {

        }
    }
}
