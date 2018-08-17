using System;
using System.Collections.Generic;
using System.ComponentModel;

using Kiss.Infrastructure;
using Kiss.Infrastructure.Enumeration;
using Kiss.Model.DTO.Wsh;

namespace Kiss.UI.ViewModel.Wsh
{
    /// <summary>
    /// The ViewModel of the TEntity entity.
    /// </summary>
    public class WshAuszahlvorschlagPositionVM : ViewModelBase
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="WshAuszahlvorschlagVM"/> class.
        /// </summary>
        public WshAuszahlvorschlagPositionVM(WshAuszahlvorschlagPositionDTO dto,
            List<WshAuszahlvorschlagBelegVM> belege,
            List<WshAuszahlvorschlagBelegPositionDTO> belegPositionen)
        {
            DTO = dto;
            Belege = belege;
            BelegPositionen = belegPositionen;

            DTO.PropertyChanged += (o, p) => { };
            belegPositionen.ForEach(bp => bp.PropertyChanged += BelegPositionPropertyChanged);
        }

        #endregion

        #region Properties

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


        public List<WshAuszahlvorschlagBelegPositionDTO> BelegPositionen
        {
            get; private set;
        }

        public List<WshAuszahlvorschlagBelegVM> Belege
        {
            get; private set;
        }

        public WshAuszahlvorschlagPositionDTO DTO
        {
            get; private set;
        }

        public decimal Rest
        {
            get { return CalculateRest(); }
        }

        #endregion

        #region Methods

        #region Public Methods

        public void DeleteBeleg(WshAuszahlvorschlagBelegVM beleg)
        {
            //index ermitteln
            int index = Belege.IndexOf(beleg);
            BelegPositionen.RemoveAt(index);
        }

        public void InsertBelegAt(WshAuszahlvorschlagBelegVM beleg, WshAuszahlvorschlagBelegPositionDTO belegPosition, int index)
        {
            belegPosition.PropertyChanged += BelegPositionPropertyChanged;
            Belege.Insert(index, beleg);
            BelegPositionen.Insert(index, belegPosition);
        }

        #endregion

        #region Private Methods


        private void BelegPositionPropertyChanged(Object sender, PropertyChangedEventArgs e)
        {            
            NotifyPropertyChanged.RaisePropertyChanged(() => Rest);                                     
        }

        /// <summary>
        /// Berechnet den Rest, der für eine Position noch ausbezahlt werden könnte.
        /// Verfügbar + Summe aller Einnahmen - Summe aller Ausgaben.
        /// </summary>
        /// <returns></returns>
        public decimal CalculateRest()
        {
            decimal result = this.DTO.Verfuegbar;
            foreach(var belegPosition in BelegPositionen)
            {
                if (belegPosition.Beleg.Status.EnumValue == WshAuszahlvorschlagStatus.Vorschlag)
                {
                    if (belegPosition.Ausgabe.HasValue)
                    {
                        result -= belegPosition.Ausgabe.Value;
                    }
                    if (belegPosition.Einnahme.HasValue)
                    {
                        result += belegPosition.Einnahme.Value;
                    }
                }
            }
            return result;
        }

        #endregion

        #endregion
    }
}