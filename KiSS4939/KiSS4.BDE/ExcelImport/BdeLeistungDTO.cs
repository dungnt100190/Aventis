using System;

namespace KiSS4.BDE.ExcelImport
{
    public class BdeLeistungDTO
    {
        #region Constructors

        public BdeLeistungDTO(int mitarbeiterNr, DateTime monat, int standardKostentraeger, decimal anzahl, int ansatz)
        {
            MitarbeiterNr = mitarbeiterNr;
            Datum = monat;
            StandardKostentraeger = standardKostentraeger;
            Dauer = anzahl;
            Ansatz = ansatz;
        }

        #endregion

        #region Properties

        public int Ansatz
        {
            get;
            set;
        }

        public int BdeLeistungsartId
        {
            get;
            set;
        }

        public DateTime Datum
        {
            get;
            set;
        }

        public decimal Dauer
        {
            get;
            set;
        }

        public int LohnartCode
        {
            get;
            set;
        }

        public int MitarbeiterNr
        {
            get;
            set;
        }

        public int StandardKostentraeger
        {
            get;
            set;
        }

        public int UserId
        {
            get;
            set;
        }

        #endregion
    }
}