using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

using Kiss.BL.Kbu;
using Kiss.BL.Wsh;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces;
using Kiss.Interfaces.ViewModel;

using Container = Kiss.Interfaces.IoC.Container;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;
using System.Text;
using Kiss.BL.KissSystem;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshAuszahlvorschlagVM : ViewModelBase
    {
        #region Fields

        #region Private Constant/Read-Only Fields

        private readonly WshAuszahlvorschlagService _auszahlvorschlagService;

        #endregion

        #region Private Fields

        private ObservableCollection<WshAuszahlvorschlagPositionVM> _auszahlvorschlagPositionen;
        private bool _dritteAnzeigen;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshAuszahlvorschlagVM"/> class.
        /// </summary>
        public WshAuszahlvorschlagVM()
        {
            _auszahlvorschlagService = Container.Resolve<WshAuszahlvorschlagService>();
        }

        #endregion

        #region Properties

        public ObservableCollection<WshAuszahlvorschlagBelegVM> AuszahlvorschlagBelege
        {
            get;
            private set;
        }

        public ObservableCollection<WshAuszahlvorschlagPositionVM> AuszahlvorschlagPositionen
        {
            get { return _auszahlvorschlagPositionen; }
            private set
            {
                _auszahlvorschlagPositionen = value;
                _auszahlvorschlagPositionen.ToList().ForEach(x => x.PropertyChanged += PositionPropertyChanged);
            }
        }

        private bool _inklFreigegebene;
        public bool InklFreigegebene
        {
            get { return _inklFreigegebene; }
            set
            {
                if (_inklFreigegebene == value)
                {
                    return;
                }

                _inklFreigegebene = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => InklFreigegebene);

                //auf alle AuszahlvorschlagBelege propagieren, damit der Zustand des Häkchens Belege ein- oder ausblenden kann
                AuszahlvorschlagBelege.ToList().ForEach(x => x.InklFreigegebene = _inklFreigegebene);
                AuszahlvorschlagPositionen.ToList().ForEach(x => x.InklFreigegebene = _inklFreigegebene);
            }
        }

        public bool DritteAnzeigen
        {
            get { return _dritteAnzeigen; }
            set
            {
                if (_dritteAnzeigen == value)
                {
                    return;
                }

                _dritteAnzeigen = value;

                NotifyPropertyChanged.RaisePropertyChanged(() => DritteAnzeigen);

                //auf alle AuszahlvorschlagBelege propagieren, damit der Zustand des Häkchens Belege ein- oder ausblenden kann
                AuszahlvorschlagBelege.ToList().ForEach(x => x.DritteAnzeigen = _dritteAnzeigen);
            }
        }

        public decimal TotalRest
        {
            get { return CalculateTotalRest(); }
        }

        #endregion

        #region Commands

        public ICommand BelegFreigebenCommand
        {
            get;
            private set;
        }

        public ICommand DeleteBelegCommand
        {
            get;
            private set;
        }

        public ICommand SplitBelegCommand
        {
            get;
            private set;
        }

        #endregion

        #region Methods

        #region Public Methods

        /// <summary>
        /// Erstellt Buchungen für alle Belege in "Vorbereitung".
        /// </summary>        
        public bool AlleBelegeFreigeben()
        {
            if (!CheckVerfuegbareBetraege())
            {
                OnMessageRaised(new MessageRaisedEventArgs("Die Belege können erst freigegeben werden, wenn bei allen Positionen der verfügbare Betrag nicht überschritten wird."));
                return false;
            }

            var belegService = Container.Resolve<KbuBelegService>();

            List<WshAuszahlvorschlagBelegDTO> belege = new List<WshAuszahlvorschlagBelegDTO>();
            foreach (WshAuszahlvorschlagBelegVM belegVM in AuszahlvorschlagBelege)
            {
                if (belegVM.DTO.Status.EnumValue == WshAuszahlvorschlagStatus.Vorschlag)
                {
                    belege.Add(belegVM.DTO);
                }
            }

            var serviceResult = belegService.CreateBelege(null, belege);

            if (serviceResult.IsOk)
            {
                return true;
            }

            if (serviceResult.IsWarning && !serviceResult.IsError)
            {
                RaiseMessage("Es sind Warnungen vorhanden. Geben sie diese zuerst einzeln frei:", serviceResult);
            }
            else
            {
                RaiseMessage("Freigeben ist nicht möglich:", serviceResult);
            }
            return false;
        }

        /// <summary>
        /// Einzelner Beleg wird freigegeben.
        /// </summary>
        /// <param name="obj"></param>
        public void BelegFreigeben(object obj)
        {
            var auszahlvorschlagBeleg = obj as WshAuszahlvorschlagBelegVM;

            if (auszahlvorschlagBeleg == null)
            {
                return;
            }

            if (!CheckVerfuegbareBetraege(auszahlvorschlagBeleg))
            {
                RaiseMessage("Der Beleg kann erst freigegeben werden, wenn bei allen Positionen der verfügbare Betrag nicht überschritten wird.");
                return;
            }                                 
                        


            var belegService = Container.Resolve<KbuBelegService>();
            KbuBeleg beleg;
            var serviceResult = belegService.CreateBeleg(null, auszahlvorschlagBeleg.DTO, false, out beleg);
            if (serviceResult.IsOk && !serviceResult.IsWarning)
            {
                auszahlvorschlagBeleg.DTO.Status = WshAuszahlvorschlagStatus.Freigegeben;
                VerfuegbarKorrigieren(auszahlvorschlagBeleg);
            }
            else if (serviceResult.IsWarning && !serviceResult.IsError)
            {
                StringBuilder questionBuilder = new StringBuilder();
                questionBuilder.AppendLine(MessageRaisedEventArgs.ConvertToString(
                    "Beim Erstellen des Belegs sind folgende Problem aufgetreten:", serviceResult));
                questionBuilder.AppendLine("Möchten Sie den Beleg trotzdem freigeben?");
                var answer = RaiseQuestion(questionBuilder.ToString(), new List<QuestionAnswerOption> { new QuestionAnswerOption(true, "Ja"), new QuestionAnswerOption(false, "Nein") }, false);
                
                if (answer != null && (bool)answer.Tag)
                {
                    var sr2 = belegService.CreateBeleg(null, auszahlvorschlagBeleg.DTO, true, out beleg);
                    if (sr2.IsOk)
                    {
                        auszahlvorschlagBeleg.DTO.Status = WshAuszahlvorschlagStatus.Freigegeben;
                        VerfuegbarKorrigieren(auszahlvorschlagBeleg);
                    }
                    else
                    {
                        RaiseMessage("Freigeben ist nicht möglich:", sr2);
                    }
                }
            }
            else
            {
                RaiseMessage("Freigeben ist nicht möglich:", serviceResult);
            }
        }


        /// <summary>
        /// Nach dem freigeben müssen die verfügbaren Beträge angepasst werden.
        /// </summary>
        /// <param name="auszahlvorschlagBeleg"></param>
        private void VerfuegbarKorrigieren(WshAuszahlvorschlagBelegVM auszahlvorschlagBeleg)
        {

            foreach (var x in auszahlvorschlagBeleg.BelegPositionen)
            {
                if (x.Ausgabe != null || x.Einnahme != null)
                {
                    var pos = AuszahlvorschlagPositionen.Where(y => y.DTO.WshPosition.WshPositionID == x.WshPosition.WshPositionID).SingleOrDefault();
                    if (pos != null)
                    {
                        if (x.Ausgabe != null)
                        {
                            pos.DTO.Verfuegbar -= x.Ausgabe.Value;
                           
                        }

                        if (x.Einnahme != null)
                        {
                            pos.DTO.Verfuegbar += x.Einnahme.Value;
                          
                        }
                        
                    }
                }
            }        
        }


        public bool CanExecuteBelegFreigeben(object obj)
        {
            if (!Maskenrecht.CanUpdate)
            {
                return false;
            }

            var auszahlvorschlagBeleg = obj as WshAuszahlvorschlagBelegVM;
            if (auszahlvorschlagBeleg == null)
            {
                return false;
            }

            //nur Belege mit Status: Vorschlag können freigegeben werden
            return auszahlvorschlagBeleg.DTO.Status == WshAuszahlvorschlagStatus.Vorschlag;
        }

        public bool CanExecuteAlleBelegeFreigeben(object obj)
        {
            if (!Maskenrecht.CanUpdate)
            {
                return false;
            }

            return true;
        }

        public bool CanExecuteDeleteBeleg(object obj)
        {
            if (!Maskenrecht.CanDelete)
            {
                return false;
            }

            var auszahlvorschlagBeleg = obj as WshAuszahlvorschlagBelegVM;
            if (auszahlvorschlagBeleg == null)
            {
                return false;
            }

            //nur Belege mit Status: Freigegeben können gelöscht werden
            return auszahlvorschlagBeleg.DTO.Status == WshAuszahlvorschlagStatus.Freigegeben;
        }

        public bool CanExecuteSplitBeleg(object obj)
        {
            return false;

            // TODO
            /*
            if (!Maskenrecht.CanUpdate)
            {
                return false;
            }

            var auszahlvorschlagBeleg = obj as WshAuszahlvorschlagBelegVM;
            if (auszahlvorschlagBeleg == null)
            {
                return false;
            }

            //nur Belege mit Status: Vorschlag können gesplittet werden
            return auszahlvorschlagBeleg.DTO.Status == WshAuszahlvorschlagStatus.Vorschlag;
             * */
        }

        public void DeleteBeleg(object obj)
        {
            var auszahlvorschlagBeleg = obj as WshAuszahlvorschlagBelegVM;
            if (auszahlvorschlagBeleg == null)
            {
                return;
            }

            //BelegPositionen aus AuszahlvorschlagBelegeVM entfernen
            AuszahlvorschlagPositionen.ToList().ForEach(p => p.DeleteBeleg(auszahlvorschlagBeleg));
            AuszahlvorschlagBelege.Remove(auszahlvorschlagBeleg);
        }

        public void Init(int leistungId)
        {
            //positionen + belege holen vom Service
            List<WshAuszahlvorschlagPositionDTO> offenePositionen;
            List<WshAuszahlvorschlagBelegDTO> belege;
            var result = _auszahlvorschlagService.GetAuszahlvorschlagPositionUndBeleg(null, leistungId, null, true, out offenePositionen, out belege);

            Dictionary<WshPosition, List<WshAuszahlvorschlagBelegPositionDTO>> position2BelegPosition =
                new Dictionary<WshPosition, List<WshAuszahlvorschlagBelegPositionDTO>>();

            //Beleg-VMs abfüllen
            List<WshAuszahlvorschlagBelegVM> belegVMs = new List<WshAuszahlvorschlagBelegVM>(belege.Count);
            belege.ForEach(
                b =>
                {
                    List<WshAuszahlvorschlagBelegPositionDTO> list;
                    b.BelegPositionen.ToList().ForEach(
                        bp =>
                        {
                            if (!position2BelegPosition.TryGetValue(bp.WshPosition, out list))
                            {
                                list = new List<WshAuszahlvorschlagBelegPositionDTO>();
                                position2BelegPosition.Add(bp.WshPosition, list);
                            }

                            list.Add(bp);
                        });

                    var belegVM = new WshAuszahlvorschlagBelegVM(b, leistungId, b.BelegPositionen.ToList());

                    belegVMs.Add(belegVM);
                });

            //Position-VMs abfüllen
            List<WshAuszahlvorschlagPositionVM> positionVMs = new List<WshAuszahlvorschlagPositionVM>(offenePositionen.Count);
            offenePositionen.ForEach(
                p =>
                {
                    List<WshAuszahlvorschlagBelegPositionDTO> belegPositionen;
                    if (position2BelegPosition.TryGetValue(p.WshPosition, out belegPositionen))
                    {
                        var positionVM = new WshAuszahlvorschlagPositionVM(p, belegVMs, belegPositionen);
                        positionVMs.Add(positionVM);
                    }
                });

            AuszahlvorschlagPositionen = new ObservableCollection<WshAuszahlvorschlagPositionVM>(positionVMs);
            AuszahlvorschlagBelege = new ObservableCollection<WshAuszahlvorschlagBelegVM>(belegVMs);
        }

        public void SplitBeleg(object obj)
        {
            var auszahlvorschlagBeleg = obj as WshAuszahlvorschlagBelegVM;
            if (auszahlvorschlagBeleg == null)
            {
                return;
            }

            int index = AuszahlvorschlagBelege.IndexOf(auszahlvorschlagBeleg);

            WshAuszahlvorschlagBelegDTO dtoCopy = new WshAuszahlvorschlagBelegDTO
            {
                Status = auszahlvorschlagBeleg.DTO.Status,
                Valuta = auszahlvorschlagBeleg.DTO.Valuta,
                Kreditor = auszahlvorschlagBeleg.DTO.Kreditor,
                //TODO: BelegPositionen = ...
            };

            //TODO:
            //WshAuszahlvorschlagBelegVM belegCopy = new WshAuszahlvorschlagBelegVM(dtoCopy, auszahlvorschlagBeleg.FaLeistungID, /* test */new List<WshAuszahlvorschlagBelegPositionDTO>(0));
            //AuszahlvorschlagBelege.Insert(index, belegCopy);

            //BelegPositionen zu AuszahlvorschlagBelegeVM entfernen
            //AuszahlvorschlagPositionen.ToList().ForEach(p => p.InsertBelegAt(auszahlvorschlagBeleg, /*TODO: BelegPositionen */, index));
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Berechnet den Restbetrag
        /// </summary>
        /// <returns></returns>
        private decimal CalculateTotalRest()
        {
            decimal result = 0;
            foreach (var pos in AuszahlvorschlagPositionen)
            {               
                result += pos.Rest;
            }
            return result;
        }

        private bool CheckVerfuegbareBetraege(WshAuszahlvorschlagBelegVM beleg)
        {
            foreach(var x in beleg.BelegPositionen)
            {
                if(x.Ausgabe != null || x.Einnahme != null)
                {
                   var pos =   AuszahlvorschlagPositionen.Where(y => y.DTO.WshPosition.WshPositionID == x.WshPosition.WshPositionID).SingleOrDefault();
                   if(pos != null && pos.DTO.IsAusgabe && pos.Rest < 0)
                   {
                       return false;
                   }
                }
            }
            return true;
        }

        /// <summary>
        /// Überprüft, ob es eine Position gibt, wo der überschriebene Betrag grösser ist
        /// als der verfügbare Betrag. 
        /// </summary>
        /// <returns></returns>
        private bool CheckVerfuegbareBetraege()
        {
            foreach (var belegVM in AuszahlvorschlagBelege)
            {
                if (belegVM.DTO.Status.EnumValue ==  WshAuszahlvorschlagStatus.Vorschlag &&!CheckVerfuegbareBetraege(belegVM))
                {
                    return false;
                }
            }
            return true;
        }

        private void PositionPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Rest") //Too lazy for safe typing.
            {
                NotifyPropertyChanged.RaisePropertyChanged(() => TotalRest);
            }
        }

        #endregion

        #endregion
    }
}