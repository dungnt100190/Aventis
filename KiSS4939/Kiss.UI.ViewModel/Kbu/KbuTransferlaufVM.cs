using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;

using Kiss.BL.Kbu;
using Kiss.BL.KbuTransferlaufWebService;
using Kiss.Interfaces.BL;
using Container = Kiss.Interfaces.IoC.Container;
using Kiss.Model.DTO.Kbu;
using Kiss.Infrastructure.Constant;
using Kiss.BL.KissSystem;

namespace Kiss.UI.ViewModel.Kbu
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class KbuTransferlaufVM : ViewModelBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly BackgroundWorker _backgroundWorkerUpdateProgress;
        private readonly KbuTransferlaufService _transferlaufService = Container.Resolve<KbuTransferlaufService>();

        private const string NUM_SELECTED_BELEGE_TEXT_TEMPLATE = @"{0} selektierte Belege, Summe {1:0.00}";
        private const string TRANSFERPROGRESS_TEXT_TEMPLATE = @"Lauf {0} {1}: {2} von {3} erfolgreich transferiert, {4} fehlerhaft.";
        //private const string TRANSFERPROGRESS_TEXT_TEMPLATE = @"Lauf {0} beendet: {1} von {2} transferiert, davon {3} fehlerhaft.";

        #endregion

        #region Private Fields

        private ObservableCollection<KbuBelegLaufDTO> _belege;
        private bool _isTransferInProgress;
        //private int _transferId;
        private string _transferProgressText;
        private KissServiceResult _validationResult;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="KbuTransferlaufVM"/> class.
        /// </summary>
        public KbuTransferlaufVM()
        {
            //Background worker
            _backgroundWorkerUpdateProgress = new BackgroundWorker();
            _backgroundWorkerUpdateProgress.WorkerReportsProgress = true;
            _backgroundWorkerUpdateProgress.WorkerSupportsCancellation = true;
            _backgroundWorkerUpdateProgress.DoWork += UpdateProgress;
            _backgroundWorkerUpdateProgress.RunWorkerCompleted += TransferCompleted;
            _backgroundWorkerUpdateProgress.ProgressChanged += ProgressChanged;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Liste mit den transferierbaren Belegen.
        /// </summary>
        public ObservableCollection<KbuBelegLaufDTO> Belege
        {
            get { return _belege; }
            set
            {
                if (_belege != null)
                {
                    _belege.ToList().ForEach(x => x.PropertyChanged -= PropertyChangedEventHandler);
                }
                _belege = value;
                if (_belege != null)
                {
                    _belege.ToList().ForEach(x => x.PropertyChanged += PropertyChangedEventHandler);
                }
                NotifyPropertyChanged.RaisePropertyChanged(() => Belege);
                NotifyPropertyChanged.RaisePropertyChanged(() => NumSelektierteBelegeText);
            }
        }

        /// <summary>
        /// Text, der sich auf dem Button zum Starten und Stoppen
        /// des Transferlaufs befindet.
        /// </summary>
        public string ButtonText
        {
            get
            {
                if (IsTransferInProgress)
                {
                    return "Transfer abbrechen";
                }
                return "Transferieren";
            }
        }

        /// <summary>
        /// Der Transferlauf ist am werkeln.
        /// </summary>
        public bool IsTransferlaufDisplayable
        {
            get
            {
                return TransferlaufState != null;
            }
        }

        /// <summary>
        /// Der Transferlauf ist am werkeln.
        /// </summary>
        public bool IsTransferInProgress
        {
            get
            {
                return _isTransferInProgress;
            }
            set
            {
                if (_isTransferInProgress == value)
                {
                    return;
                }

                _isTransferInProgress = value;
                if (!value && _backgroundWorkerUpdateProgress != null && _backgroundWorkerUpdateProgress.IsBusy)
                {
                    _backgroundWorkerUpdateProgress.CancelAsync();
                }
                NotifyPropertyChanged.RaisePropertyChanged(() => IsTransferInProgress);
                NotifyPropertyChanged.RaisePropertyChanged(() => ButtonText);
            }
        }

        /// <summary>
        /// Anzahl selektierte Belege.
        /// </summary>
        public int NumSelektierteBelege
        {
            get
            {
                if (Belege == null)
                {
                    return 0;
                }
                return Belege.Where(x => x.Selected).Count();
            }
        }

        public string NumSelektierteBelegeText
        {
            get { return string.Format(NUM_SELECTED_BELEGE_TEXT_TEMPLATE, NumSelektierteBelege, Summe); }
        }

        /// <summary>
        /// Summe der Beträge von den Belegen.
        /// </summary>
        public decimal Summe
        {
            get
            {
                if (Belege == null)
                    return 0;
                return Belege.Where(x => x.Selected).Sum(x => x.Betrag);
            }
        }

        /// <summary>
        /// Text für die Fortschrittsanzeige.
        /// </summary>
        public string TransferProgressText
        {
            get
            {
                return _transferProgressText;
            }
            set
            {
                _transferProgressText = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => TransferProgressText);

            }
        }

        /// <summary>
        /// Gets the validation result of the SearchDTO
        /// </summary>
        public KissServiceResult ValidationResult
        {
            get
            {
                return _validationResult;
            }
            protected set
            {
                _validationResult = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => ValidationResult);
            }
        }

        private KbuTransferlaufStateDTO _transferlaufState;
        public KbuTransferlaufStateDTO TransferlaufState
        {
            get
            {
                return _transferlaufState;
            }
            private set
            {
                _transferlaufState = value;
                NotifyPropertyChanged.RaisePropertyChanged(() => TransferlaufState);
                NotifyPropertyChanged.RaisePropertyChanged(() => IsTransferlaufDisplayable);
                if (_transferlaufState != null)
                {
                    TransferProgressText = string.Format(TRANSFERPROGRESS_TEXT_TEMPLATE, _transferlaufState.KbuTransferlaufID,
                                                                                         TranslateTransferlaufStatusToText(_transferlaufState),
                                                                                         _transferlaufState.BelegCountTransferiert,
                                                                                         _transferlaufState.BelegCountTotal,
                                                                                         _transferlaufState.BelegCountFehlerhaft);
                }
                else
                {
                    TransferProgressText = null;
                }
            }
        }

        private string TranslateTransferlaufStatusToText(KbuTransferlaufStateDTO _transferlaufState)
        {
            if (_transferlaufState==null)
            {
                return string.Empty;
            }

            switch (_transferlaufState.KbuTransferlaufStatusCode)
            {
                case (int)LOVsGenerated.KbuTransferlaufStatus.Created:
                    return "ist erstellt";
                case (int)LOVsGenerated.KbuTransferlaufStatus.Running:
                    return "läuft";
                case (int)LOVsGenerated.KbuTransferlaufStatus.Cancelled:
                    return "wurde abgebrochen";
                case (int)LOVsGenerated.KbuTransferlaufStatus.Done:
                    return "ist beendet";
                default:
                    return string.Empty;
            }
        }

        #endregion

        #region Commands

        public ICommand DeselectAllCommand
        {
            get;
            set;
        }

        public ICommand SelectAllCommand
        {
            get;
            set;
        }

        public ICommand TransferierenAbbrechenCommand
        {
            get;
            set;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Initializes the ViewModel.
        /// </summary>
        public void Init()
        {
            //TransferierenCommand.
            TransferierenAbbrechenCommand = new BaseCommand(x => TransferStartenOderAbbrechen(), x => true);

            //Alle selektieren command.
            SelectAllCommand = new BaseCommand(x => SelectAll(), x => !IsTransferInProgress);

            //Alle deselektieren command
            DeselectAllCommand = new BaseCommand(x => DeselectAll(), x => !IsTransferInProgress);

            _backgroundWorkerUpdateProgress.RunWorkerAsync();
            ValidationResult = KissServiceResult.Ok();
            Search(null);
        }

        /// <summary>
        /// Gets the data from service.
        /// </summary>
        /// <param name="unitOfWork">The unit of work to use (can be null)</param>
        public void Search(IUnitOfWork unitOfWork)
        {
            var transferlaufService = Container.Resolve<KbuTransferlaufService>();
            var belege = transferlaufService.GetTransferierbareBelege(null, false);
            Belege = new ObservableCollection<KbuBelegLaufDTO>(belege);
        }

        /// <summary>
        /// Wenn der Transfer am laufen ist, dann wird er abgebrochen.
        /// Wenn der Tranfer nicht am laufen ist, dann wird er gestartet.
        /// </summary>
        public void TransferStartenOderAbbrechen()
        {
            if (IsTransferInProgress)
            {
                TransferAbbrechen();
            }
            else
            {
                TransferStarten();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Deselektiert alle Belege.
        /// </summary>
        private void DeselectAll()
        {
            Belege.ToList().ForEach(x => x.Selected = false);
        }

        /// <summary>
        /// Überträgt den Status in die Progressbar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progress = (KbuTransferlaufStateDTO)e.UserState;
            TransferlaufState = progress;
        }

        private void PropertyChangedEventHandler(Object sender, PropertyChangedEventArgs e)
        {
            NotifyPropertyChanged.RaisePropertyChanged(() => NumSelektierteBelege);
            NotifyPropertyChanged.RaisePropertyChanged(() => NumSelektierteBelegeText);
        }

        /// <summary>
        /// Selektiert alle Belege.
        /// </summary>
        private void SelectAll()
        {
            Belege.ToList().ForEach(x => x.Selected = true);
        }

        /// <summary>
        /// Stoppt den Transfer ans PSCD.
        /// </summary>
        private void TransferAbbrechen()
        {
            if (TransferlaufState != null)
            {
                ValidationResult = _transferlaufService.CancelTransferlauf(null, TransferlaufState.KbuTransferlaufID);
            }
        }

        /// <summary>
        /// Transfer ist beendet.        
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransferCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsTransferInProgress = false;
            Search(null);
        }

        /// <summary>
        /// Startet den Transfer der Belege ans PSCD.
        /// </summary>
        private void TransferStarten()
        {
            var belegListe = Belege.Where(x => x.Selected).Select(x => x.KbuBelegID).ToList();
            if (belegListe.Count == 0)
            {
                ValidationResult = new KissServiceResult(KissServiceResult.ResultType.Error, "KbuTransferlaufVM_NoKbuBelegSelected", "Es sind keine Belege selektiert");
                return;
            }

            int? kbuTransferlaufID;
            ValidationResult = _transferlaufService.CreateAndStartTransferlauf(null, belegListe, out kbuTransferlaufID);
            if (ValidationResult.IsOk && kbuTransferlaufID.HasValue)
            {
                IsTransferInProgress = true;
                if (!_backgroundWorkerUpdateProgress.IsBusy)
                {
                    _backgroundWorkerUpdateProgress.RunWorkerAsync(kbuTransferlaufID.Value);
                }
            }
        }

        /// <summary>
        /// Update der Statusanzeige während des Transfers zum PSCD.
        /// ACHTUNG, KEINE UI UPDATES IN DIESER METHODE!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateProgress(object sender, DoWorkEventArgs e)
        {
            var service = Container.Resolve<KbuTransferlaufService>();
            var worker = (BackgroundWorker)sender;
            var transferID = (int?)e.Argument;

            while (!worker.CancellationPending)
            {
                Thread.Sleep(1000);
                var progress = service.GetVerarbeitungsProgress(null);
                if (!transferID.HasValue)
                {
                    // Beim Maskenstart (transferID == null) brechen wir die Serverbeobachtung ab, wenn kein Transferlauf läuft
                    if (progress == null || progress.DoneTime.HasValue)
                    {
                        return;
                    }
                    // sonst beobachten wir den
                    transferID = progress.KbuTransferlaufID;
                }

                if (progress == null)
                {
                    // noch kein Status erhalten, warten
                    continue;
                }
                worker.ReportProgress(progress.PercentProgress, progress);
                if (progress.DoneTime.HasValue)
                {
                    e.Result = progress;
                    return;
                }
            }
            e.Cancel = true;
        }

        #endregion

        #endregion
    }
}