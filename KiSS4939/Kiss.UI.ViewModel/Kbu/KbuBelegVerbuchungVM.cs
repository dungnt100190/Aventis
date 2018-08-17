using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

using Kiss.BL.Kbu;
using Kiss.BL.KissSystem;
using Kiss.Interfaces.BL;
using Container = Kiss.Interfaces.IoC.Container;
using Kiss.Model;
using Kiss.Model.DTO;
using Kiss.Model.DTO.Kbu;

namespace Kiss.UI.ViewModel.Kbu
{
    /// <summary>
    /// ViewModel um Belege zu verbuchen.
    /// </summary>
    public class KbuBelegVerbuchungVM : ViewModelCRUDListBase<KbuBeleg>
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BackgroundWorker _backGroundWorker;

        private const string DONE = "ist beendet";
        private const string RUNNING = "läuft";

        //private const string VERBUCHUNGSLAUFPROGRESS_TEXT_TEMPLATE = @"Verbuchungslauf läuft: {0} von {1} verbucht, {2} fehlerhaft.";
        //private const string VERBUCHUNGSLAUFDONE_TEXT_TEMPLATE = @"Verbuchungslauf beendet: {0} von {1} verbucht, {2} fehlerhaft.";
        private const string VERBUCHUNGSLAUF_TEXT_TEMPLATE = @"Verbuchungslauf {0}: {1} von {2} erfolgreich verbucht, {3} fehlerhaft.";

        #endregion

        #region Private Fields

        private ObservableCollection<KbuBelegLaufDTO> _belege;
        private DateTime _datumValutaSuchen = DateTime.Today;
        private DateTime _datumValutaVerbuchen = DateTime.Today.AddDays(1);
        private string _infoSearchText;
        private string _infoSelectionText;
        private bool _isVerbuchungslaufInProgress;
        private KbuBelegVerbuchungService _kbuBelegVerbuchungService;
        private bool _nurBelegeMitFehler;
        private VerarbeitungsProgressDTO _progressDTO = new VerarbeitungsProgressDTO();
        private bool _verbuchungslaufBeendet;

        /// <summary>
        /// Fortschritt in %.
        /// </summary>
        private int _verbuchungslaufProgress;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KbuBelegVerbuchungVM"/> class.
        /// </summary>
        public KbuBelegVerbuchungVM()
            : base(Container.Resolve<KbuBelegService>())
        {
            SelektionVerbuchenCommand = new BaseCommand(SelektionVerbuchen, CanExecuteSelektionVerbuchen);
            CopyErrorsToClipboardCommand = new BaseCommand(CopyErrorsToClipboard, CanExecuteCopyErrorsToClipboard);
            SelectionAllCommand = new BaseCommand(SelectionAll, CanExecuteSelectionAll);
            SelectionNoneCommand = new BaseCommand(SelectionNone, CanExecuteSelectionNone);

            //Backgroundworker
            _backGroundWorker = new BackgroundWorker();
            _backGroundWorker.WorkerReportsProgress = true;
            _backGroundWorker.DoWork += DoWork;
            _backGroundWorker.RunWorkerCompleted += VerbuchungslaufCompleted;
            _backGroundWorker.ProgressChanged += ProgressChanged;

            //NotifyPropertyChanged für Progress.
            _progressDTO.PropertyChanged += ProgressDTOPropertyChangedEventHandler;
        }

        #endregion

        #region Properties

        public ObservableCollection<KbuBelegLaufDTO> Belege
        {
            get { return _belege; }
            set
            {
                if (_belege != null)
                {
                    _belege.ToList().ForEach(x => x.PropertyChanged -= BelegDTOPropertyChangedEventHandler);
                }
                _belege = value;
                if (_belege != null)
                {
                    _belege.ToList().ForEach(x => x.PropertyChanged += BelegDTOPropertyChangedEventHandler);
                }
                NotifyPropertyChanged.RaisePropertyChanged(() => Belege);
                SetInfoSelectionText();
            }
        }

        public DateTime DatumValutaSuchen
        {
            get { return _datumValutaSuchen; }
            set
            {
                if (_datumValutaSuchen == value)
                {
                    return;
                }
                _datumValutaSuchen = value;
                GetBelege();
                SetInfoSearchText();
            }
        }

        public DateTime DatumValutaVerbuchen
        {
            get { return _datumValutaVerbuchen; }
            set
            {
                _datumValutaVerbuchen = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => DatumValutaVerbuchen);
            }
        }

        public string InfoSearchText
        {
            get { return _infoSearchText; }

            set
            {
                _infoSearchText = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => InfoSearchText);
            }
        }

        public string InfoSelectionText
        {
            get { return _infoSelectionText; }

            set
            {
                _infoSelectionText = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => InfoSelectionText);
            }
        }

        public bool IsVerbuchungslaufInProgress
        {
            get { return _isVerbuchungslaufInProgress; }
            set
            {
                _isVerbuchungslaufInProgress = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => IsVerbuchungslaufInProgress);

            }
        }

        public bool NurBelegeMitFehler
        {
            get { return _nurBelegeMitFehler; }
            set
            {
                if (_nurBelegeMitFehler == value)
                {
                    return;
                }
                _nurBelegeMitFehler = value;
                GetBelege();
            }
        }

        /// <summary>
        /// Fortschritt des Verbuchungslaufs in Prozent.
        /// </summary>
        public int VerbuchungslaufProgress
        {
            get { return _verbuchungslaufProgress; }
            set
            {
                _verbuchungslaufProgress = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => VerbuchungslaufProgress);
            }
        }

        public string VerbuchungslaufProgressText
        {
            get
            {
                if (!IsVerbuchungslaufInProgress && !_verbuchungslaufBeendet)
                {
                    return string.Empty;
                }
                //"Verbuchungslauf {0}: {1} von {2} erfolgreich transferiert, {3} fehlerhaft."
                string state = _verbuchungslaufBeendet ? DONE : RUNNING;
                return string.Format(VERBUCHUNGSLAUF_TEXT_TEMPLATE, state,
                                                                    _progressDTO.NumHandled - _progressDTO.NumErrors,
                                                                    _progressDTO.NumTotal,
                                                                    _progressDTO.NumErrors);
            }
        }

        #endregion

        #region Commands

        public ICommand CopyErrorsToClipboardCommand
        {
            get;
            private set;
        }

        public ICommand SelectionAllCommand
        {
            get;
            private set;
        }

        public ICommand SelectionNoneCommand
        {
            get;
            private set;
        }

        public ICommand SelektionVerbuchenCommand
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public bool CanExecuteCopyErrorsToClipboard(object obj)
        {
            if (_belege == null)
            {
                return false;
            }
            return false;
        }

        public bool CanExecuteSelectionAll(object obj)
        {
            if (_belege != null && IsVerbuchungslaufInProgress == false && _belege.Count > 0)
            {
                return true;
            }

            return false;
        }

        public bool CanExecuteSelectionNone(object obj)
        {
            if (_belege == null || IsVerbuchungslaufInProgress)
            {
                return false;
            }

            return _belege.Count > 0;
        }

        public bool CanExecuteSelektionVerbuchen(object obj)
        {
            if (_belege == null || IsVerbuchungslaufInProgress)
            {
                return false;
            }

            return _belege.Count(x => x.Selected) > 0;
        }

        public void CopyErrorsToClipboard(object obj)
        {
            /*
            var belege = obj as KbuBelegVerbuchungVM;
            if (belege == null)
            {
                return;
            }

             * */
            /*
            Clipboard.Clear();
            StringBuilder sb = new StringBuilder();
            foreach (EntityWrapper<KbuBelegLaufDTO> bel in _belege)
            {
                if (!string.IsNullOrEmpty(bel.Entity.ErrorMessage))
                {
                    sb.AppendFormat("KbuBelegID: {0};", bel.Entity.KbuBelegId);
                    sb.AppendFormat("Name: {0};", "[Name Klient]");
                    sb.AppendFormat("Betrag: {0};", bel.Entity.Betrag);
                    sb.AppendFormat("Text: {0};", bel.Entity.Text);
                    //sb.AppendFormat("User: {0};", (bel.Entity.XUser == null) ? "[kein User]" : bel.Entity.XUser.LastNameFirstName);
                    sb.AppendFormat("Fehler: {0};", bel.Entity.ErrorMessage);
                    sb.AppendLine();
                }
            }
            Clipboard.SetText(sb.ToString());
             */
        }

        public void Init()
        {
            _kbuBelegVerbuchungService = Container.Resolve<KbuBelegVerbuchungService>();
            GetBelege();
            SetInfoSearchText();
        }

        /// <summary>
        /// Gets the data from service.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use (can be null)</param>
        public override void LoadData(IUnitOfWork unitOfWork)
        {
            GetBelege();
        }

        public void SelectionAll(object obj)
        {
            foreach (KbuBelegLaufDTO beleg in _belege)
            {
                beleg.Selected = true;
            }
        }

        public void SelectionNone(object obj)
        {
            foreach (KbuBelegLaufDTO beleg in _belege)
            {
                beleg.Selected = false;
            }
        }

        /// <summary>
        /// Startet den Verbuchungslauf asynchron.
        /// </summary>
        /// <param name="obj"></param>
        public void SelektionVerbuchen(object obj)
        {
            IsVerbuchungslaufInProgress = true;
            _backGroundWorker.RunWorkerAsync();
        }

        #endregion

        #region Private Methods

        private void BelegDTOPropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e)
        {
            SetInfoSelectionText();
        }

        /// <summary>
        /// ACHTUNG, KEINE UI UPDATES IN DIESER METHODE!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            ValidationResult = KissServiceResult.Ok();
            _verbuchungslaufBeendet = false;
            _progressDTO.NumHandled = 0;

            var dataToSave = _belege.Where(x => x.Selected).Select(x => x.KbuBelegID).ToList();
            KissServiceResult result = _kbuBelegVerbuchungService.BelegeVerbuchen(null, dataToSave, DatumValutaVerbuchen, ref _progressDTO);
            ValidationResult = result;
        }

        private void GetBelege()
        {
            List<KbuBelegLaufDTO> belege = _kbuBelegVerbuchungService.GetFreigegebeneBelege(null, DatumValutaSuchen, NurBelegeMitFehler);
            Belege = new ObservableCollection<KbuBelegLaufDTO>(belege);
        }

        /// <summary>
        /// Überträgt den Status in die Progressbar und macht ein Update auf den Statustext.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            VerbuchungslaufProgress = e.ProgressPercentage;
            SetInfoSelectionText();
            NotifyPropertyChanged.RaisePropertyChanged(() => VerbuchungslaufProgressText);
        }

        /// <summary>
        /// Progress DTO hat sich geändert.
        /// In dieser Methode dürfen keine UI-Updates gemacht werden, 
        /// da diese Methode in einem anderen Thread aufgerufen wird.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressDTOPropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "NumHandled")
            {
                if (IsVerbuchungslaufInProgress)
                {
                    int percentage = _progressDTO.Percentage;
                    _backGroundWorker.ReportProgress(percentage);
                }
            }
        }

        private void SetInfoSearchText()
        {
            InfoSearchText = string.Format(
                "Noch nicht verbuchte Vorbelege mit geplantem Valutadatum kleiner oder gleich {0} :",
                DatumValutaSuchen.ToString("dd.MM.yyyy")
                );
        }

        private void SetInfoSelectionText()
        {
            decimal anzahl = _belege.Where(x => x.Selected).Count();
            decimal summe = _belege.Where(x => x.Selected).Sum(y => y.Betrag);

            //Selection-Info zeigen, wenn Verbuchungslauf nicht läuft.
            if (!IsVerbuchungslaufInProgress)
            {

                InfoSelectionText = (anzahl == 0)
                                        ? "keine selektierte Belege, Totalbetrag der Selektion 0.00"
                                        : string.Format(
                                            "{0} {1}, Totalbetrag der Selektion {2}.",
                                            anzahl,
                                            (anzahl == 1) ? "selektierter Beleg" : "selektierte Belege",
                                            summe.ToString("#.00")
                                              );
            }

            //Während dem Verbuchungslauf zeigen wir diesen Text nicht.
            else
            {
                InfoSelectionText = "";
            }
        }

        /// <summary>
        /// Transfer ist beendet.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VerbuchungslaufCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsVerbuchungslaufInProgress = false;
            _verbuchungslaufBeendet = true;
            //_progressDTO.NumHandled = 0;
            VerbuchungslaufProgress = 0;
            GetBelege();
            NotifyPropertyChanged.RaisePropertyChanged(() => VerbuchungslaufProgressText);
        }

        #endregion

        #endregion
    }
}