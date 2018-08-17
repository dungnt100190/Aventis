using System;

namespace KiSS4.Gesuchverwaltung.ExcelImport.DTO
{
    public class BaPersonDTO
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        public const int BA_RELATION_ID_KLIENT = -1;

        #endregion

        #endregion

        #region Properties

        public int? AusbildungCode
        {
            get;
            set;
        }

        public int? AuslaenderStatusCode
        {
            get;
            set;
        }

        public BaAdresseDTO BaAdresseDTO
        {
            get;
            set;
        }

        public int? BaPersonId
        {
            get;
            set;
        }

        public int BaRelationId
        {
            get;
            set;
        }

        public int? Behinderungsart2Code
        {
            get;
            set;
        }

        public int? ErwerbssituationCode
        {
            get;
            set;
        }

        public DateTime? Geburtsdatum
        {
            get;
            set;
        }

        public int GeschlechtCode
        {
            get;
            set;
        }

        public int? HauptbehinderungsartCode
        {
            get;
            set;
        }

        public DateTime? InChSeit
        {
            get;
            set;
        }

        public bool InChSeitGeburt
        {
            get;
            set;
        }

        public bool IsKlient
        {
            get
            {
                return BaRelationId == BA_RELATION_ID_KLIENT;
            }
        }

        public string Name
        {
            get;
            set;
        }

        public int? NationalitaetCode
        {
            get;
            set;
        }

        public BaPersonSozialversicherungDTO SozialversicherungDTO
        {
            get;
            set;
        }

        public string Versichertennummer
        {
            get;
            set;
        }

        public int? VormundMassnahmenCode
        {
            get;
            set;
        }

        public string Vorname
        {
            get;
            set;
        }

        public int? ZivilstandCode
        {
            get;
            set;
        }

        #endregion
    }
}