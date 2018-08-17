using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Kiss.BL.Wsh;
using Kiss.Infrastructure;
using Kiss.Infrastructure.Enumeration;
using Kiss.Interfaces.IoC;
using Kiss.Model;
using Kiss.Model.DTO.Wsh;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// 
    /// </summary>
    public class WshAuszahlvorschlagBelegVM : ViewModelBase
    {
        #region Fields

        #region Public Static Fields

        public static RoutedCommand BelegFreigebenCommand = new RoutedCommand();
        public static RoutedCommand DeleteBelegCommand = new RoutedCommand();
        public static RoutedCommand SplitBelegCommand = new RoutedCommand();
        public static RoutedCommand AlleBelegeFreigebenCommand = new RoutedCommand();

        #endregion

        #region Private Constant/Read-Only Fields

        private readonly WshHaushaltPersonService _haushaltService;

        #endregion

        #region Private Fields

        private bool _dritteAnzeigen;
        private bool? _kreditorIstNichtDrittPerson;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshAuszahlvorschlagVM"/> class.
        /// </summary>
        public WshAuszahlvorschlagBelegVM(WshAuszahlvorschlagBelegDTO dto,
            int faLeistungID,
            List<WshAuszahlvorschlagBelegPositionDTO> belegPositionen)
        {
            DTO = dto;
            FaLeistungID = faLeistungID;
            BelegPositionen = new List<WshAuszahlvorschlagBelegPositionDTO>(belegPositionen);

            _haushaltService = Container.Resolve<WshHaushaltPersonService>();
            DTO.PropertyChanged += (o, p) =>
            {
                if (p.PropertyName == PropertyName.GetPropertyName(() => dto.Status))
                {
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsEditable);
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsFreigegeben);
                    NotifyPropertyChanged.RaisePropertyChanged(() => IsNotFreigegeben);
                }
                else if (p.PropertyName == PropertyName.GetPropertyName(() => dto.Valuta))
                {
                    _kreditorIstNichtDrittPerson = null;
                }
                else if (p.PropertyName == PropertyName.GetPropertyName(() => dto.Kreditor))
                {
                    _kreditorIstNichtDrittPerson = null;
                }
            };
        }



        #endregion

        #region Properties

        public List<WshAuszahlvorschlagBelegPositionDTO> BelegPositionen
        {
            get;
            private set;
        }

        public double ColumnWidth
        {
            get { return 80; }
        }

        public WshAuszahlvorschlagBelegDTO DTO
        {
            get;
            private set;
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
            }
        }

        public int FaLeistungID
        {
            get;
            set;
        }

        public bool IsEditable
        {
            get { return DTO.IsVorschlag; }
        }

        public bool IsFreigegeben
        {
            get { return DTO.IsFreigegeben; }
        }

        public bool IsNotFreigegeben
        {
            get { return !DTO.IsFreigegeben; }
        }

        public bool KreditorIstNichtDrittPerson
        {
            get
            {
                if (_kreditorIstNichtDrittPerson.HasValue)
                {
                    return _kreditorIstNichtDrittPerson.Value;
                }

                DateTime stichtag = DTO.Valuta;

                if (DTO.Kreditor == null)
                {
                    return true;
                }

                BaZahlungsweg zahlungsweg = null;

                if (DTO.Kreditor.BaZahlungsweg != null)
                {
                    zahlungsweg = DTO.Kreditor.BaZahlungsweg;
                }

                if (zahlungsweg == null || !zahlungsweg.BaPersonID.HasValue)
                {
                    return false;
                }

                var baPersonID = zahlungsweg.BaPersonID;
                var haushaltPersonen = _haushaltService.GetHaushaltPersonen(null, FaLeistungID, stichtag);
                _kreditorIstNichtDrittPerson = haushaltPersonen.Any(p => p.Unterstuetzt && p.BaPersonID == baPersonID);

                return _kreditorIstNichtDrittPerson.Value;
            }
        }

        /// <summary>
        /// Definiert die Breite der Beleg-Spalten. 
        /// Ausgabe + Einnahme Spalte: 180
        /// nur Ausgabe Spalte: 90
        /// </summary>
        public double Width
        {
            get
            {
                if (DTO.HatEinnahmePositionen)
                {
                    return 2 * ColumnWidth;
                }

                return ColumnWidth + 1;
            }
        }

        #endregion
    }
}