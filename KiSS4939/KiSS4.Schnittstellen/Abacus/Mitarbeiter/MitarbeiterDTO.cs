using System;
using System.Text;

namespace KiSS4.Schnittstellen.Abacus.Mitarbeiter
{
    /// <summary>
    /// Transferobjekt mit Datenfelder aus der Abakusschnittstelle.
    /// Siehe MitarbeiterServiceAdapter.cs
    /// </summary>
    public class MitarbeiterDTO
    {
        #region Fields

        #region Private Fields

        /// <summary>
        /// _april
        /// </summary>
        private float _april;

        /// <summary>
        /// _august
        /// </summary>
        private float _august;

        /// <summary>
        /// Ausbezahlte Überstunden
        /// _amount76
        /// </summary>
        private float _ausbezahlteUeberstunden;

        /// <summary>
        /// Austrittsdatum, _dateOut
        /// </summary>
        private DateTime? _austrittsDatum;

        /// <summary>
        /// Beschäftigungsgrad
        /// _amount_3
        /// </summary>
        private float _beschaeftigungsGrad;

        /// <summary>
        /// _december
        /// </summary>
        private float _dezember;

        /// <summary>
        /// Eintrittsdatum,  _dateIn
        /// </summary>
        private DateTime _eintrittsDatum;

        /// <summary>
        /// EMail Adresse
        /// </summary>
        private string _eMail;

        /// <summary>
        /// Faxnummer
        /// _telefax
        /// </summary>
        private string _faxNr;

        /// <summary>
        /// _february
        /// </summary>
        private float _februar;

        /// <summary>
        /// Ferienanspruch pro Jahr in Stunden
        /// _amount73
        /// </summary>
        private float _ferienAnspruchAnzahlStunden;

        /// <summary>
        /// Ferienkürzung, Ferienzugabe, angegeben in Stunden
        /// _amount75
        /// </summary>
        private float _ferienKuerzungAnzahlStunden;

        /// <summary>
        /// FibuKonto, _accountA1
        /// </summary>
        private long _fibuKonto;

        /// <summary>
        /// Funktionstitel,
        ///  _functionTitle
        /// </summary>
        private int _funktion;

        /// <summary>
        /// Geburtsdatum, _birthDay
        /// </summary>
        private DateTime? _geburtsDatum;

        /// <summary>
        /// Geschäftsbereich, _division
        /// </summary>
        private int _geschaeftsbereich;

        /// <summary>
        /// Geschlecht, gibt F oder M aus
        /// _sex
        /// </summary>
        private string _geschlecht;

        /// <summary>
        /// Gibt Gültigkeitsdtum der ausbezahlten Überstunden an (ddmmyyyy)
        /// _amount77
        /// </summary>
        private DateTime? _gueltigkeitsDatumAusbezahlteUeberstunden;

        // ACHTUNG, TYP WOHL FALSCH
        /// <summary>
        /// Gibt Gültigkeitsdatum einer Beschäftigungsgradänderung an (ddmmyyyy)
        /// _amount_70
        /// </summary>
        private DateTime? _gueltigkeitsDatumBeschaeftigungsgradAenderung;

        /// <summary>
        /// Gibt Gültigkeitsdatum des Ferienanspruchs pro Jahr an (ddmmyyyy)
        /// _amount74
        /// </summary>
        private DateTime? _gueltigkeitsDatumFerienanspruchProJahr;

        /// <summary>
        /// Gibt Gültigkeitsdatum der Soll-Stunden pro Tag an (ddmmyyyy)
        /// _amount72
        /// </summary>
        private DateTime? _gueltigkeitsDatumSollStundenProTag;

        /// <summary>
        /// _january
        /// </summary>
        private float _januar;

        /// <summary>
        /// _july,
        /// </summary>
        private float _juli;

        /// <summary>
        /// _june
        /// </summary>
        private float _juni;

        /// <summary>
        /// Kostenstelle, cCenter1
        /// </summary>
        private long _kostenstelle;

        /// <summary>
        /// Kostenträger (in Abacus Sektion 2), _project1
        /// </summary>
        private long _kostentraeger;

        /// <summary>
        /// Land (Code, z.Bsp. CH, F, D, I), _country
        /// </summary>
        private string _land;

        /// <summary>
        /// Standardsprache des Mitarbeiters, gibt D, F oder I aus
        /// _languageCode
        /// </summary>
        private string _languageCodeString;

        /// <summary>
        /// Lohntyp, gibt M, S, Q , P, J aus, gebräuchlich M(onatslohn) und S(tundenlohn)
        /// _type
        /// </summary>
        private string _lohnTyp;

        /// <summary>
        /// _march
        /// </summary>
        private float _maerz;

        /// <summary>
        /// _may
        /// </summary>
        private float _mai;

        /// <summary>
        /// Mitarbeiternummer, _employeeNumber
        /// </summary>
        private long _mitarbeiterNummer;

        /// <summary>
        /// Nachname
        /// </summary>
        private string _name;

        /// <summary>
        /// _november
        /// </summary>
        private float _november;

        /// <summary>
        /// _october
        /// </summary>
        private float _oktober;

        /// <summary>
        /// Ort, _city
        /// </summary>
        private string _ort;

        /// <summary>
        /// PLZ, _postalCode
        /// </summary>
        private string _plz;

        /// <summary>
        /// Arbeitsort, gibt PLZ aus (relevant für Sollarbeitszeit), _national1
        /// </summary>
        private long _plzArbeitsort;

        /// <summary>
        /// PLZ des Arbeitsortes, für welchen die Sollarbeitszeit gilt
        /// _workArea
        /// </summary>
        private int _plzArbeitsortSollarbeitszeit;

        /// <summary>
        /// Postfach und dessen Nummer
        /// _postfachUndNr
        /// </summary>
        private string _postfachUndNr;

        /// <summary>
        /// Qualifikation, also Funktionsbezeichnung inklusive Titel (nur Nummer, Text dazu in LOHN_LTC, LOHN_LTC.GROUP=32, Verknüpfung über LOHN_LEN.NR, Text in LOHN_LTC.TEXT
        /// _qualificationTitle
        /// </summary>
        private int _qualifikation;

        /// <summary>
        /// _september
        /// </summary>
        private float _september;

        /// <summary>
        /// Soll-Stunden pro Tag
        /// _amount71
        /// </summary>
        private float _sollStundenProTag;

        /// <summary>
        /// Zeitachse Personaldaten, Jahr
        /// _timeAxisYear
        /// </summary>
        private int _stichJahr;

        /// <summary>
        /// Zeitachse Personaldaten, Monat
        /// _timeAxisMonth
        /// </summary>
        private int _stichMonat;

        /// <summary>
        ///  Strasse und Nummer, _strasseHausNr
        /// </summary>
        private string _strasseUndNummer;

        /// <summary>
        /// Zusatz zu Adresse, _zusatz
        /// </summary>
        private string _strasseZusatz;

        /// <summary>
        /// Stundenansatz 1 (für Stundenlöhner)
        /// _amount_11
        /// </summary>
        private float _stundenAnsatz1;

        /// <summary>
        /// Stundenansatz 11 (für Stundenlöhner)
        /// _amount_51
        /// </summary>
        private float _stundenAnsatz11;

        /// <summary>
        /// Stundenansatz 12 (für Stundenlöhner)
        /// _amount_52
        /// </summary>
        private float _stundenAnsatz12;

        /// <summary>
        /// Stundenansatz 13 (für Stundenlöhner)
        /// _amount_53
        /// </summary>
        private float _stundenAnsatz13;

        /// <summary>
        /// Stundenansatz 14 (für Stundenlöhner)
        /// _amount_54
        /// </summary>
        private float _stundenAnsatz14;

        /// <summary>
        /// Stundenansatz 15 (für Stundenlöhner)
        /// _amount_55
        /// </summary>
        private float _stundenAnsatz15;

        /// <summary>
        /// Stundenansatz 16 (für Stundenlöhner)
        /// _amount_56
        /// </summary>
        private float _stundenAnsatz16;

        /// <summary>
        /// Stundenansatz 2 (für Stundenlöhner)
        /// _amount_12
        /// </summary>
        private float _stundenAnsatz2;

        /// <summary>
        /// Stundenansatz 3 (für Stundenlöhner)
        /// _amount_13
        /// </summary>
        private float _stundenAnsatz3;

        /// <summary>
        /// Stundenansatz 4 (für Stundenlöhner)
        /// _amount_17
        /// </summary>
        private float _stundenAnsatz4;

        /// <summary>
        /// Telefonnummer geschäftlich, _phone2
        /// </summary>
        private string _telefonNrGesch;

        /// <summary>
        /// Mobile Nummer (Feld bereits in der alten Schnittstelle enthalten)
        /// _telex
        /// </summary>
        private string _telefonNrMobil;

        /// <summary>
        /// Telefonnummer privat, _phone1
        /// </summary>
        private string _telefonNrPrivat;

        /// <summary>
        /// Total des entsprechenden Jahres (Summe januar, februar ...)
        /// _yearTotal
        /// </summary>
        private float _totalJahr;

        /// <summary>
        /// Vorname, _firstName
        /// </summary>
        private string _vorName;

        #endregion

        #endregion

        #region Properties

        public float April
        {
            get { return _april; }
            set { _april = value; }
        }

        public float August
        {
            get { return _august; }
            set { _august = value; }
        }

        public float AusbezahlteUeberstunden
        {
            get { return _ausbezahlteUeberstunden; }
            set { _ausbezahlteUeberstunden = value; }
        }

        public System.DateTime? AustrittsDatum
        {
            get { return _austrittsDatum; }
            set { _austrittsDatum = value; }
        }

        public float BeschaeftigungsGrad
        {
            get { return _beschaeftigungsGrad; }
            set { _beschaeftigungsGrad = value; }
        }

        public float Dezember
        {
            get { return _dezember; }
            set { _dezember = value; }
        }

        public System.DateTime EintrittsDatum
        {
            get { return _eintrittsDatum; }
            set { _eintrittsDatum = value; }
        }

        public string EMail
        {
            get { return _eMail; }
            set { _eMail = value; }
        }

        public string FaxNr
        {
            get { return _faxNr; }
            set { _faxNr = value; }
        }

        public float Februar
        {
            get { return _februar; }
            set { _februar = value; }
        }

        public float FerienAnspruchAnzahlStunden
        {
            get { return _ferienAnspruchAnzahlStunden; }
            set { _ferienAnspruchAnzahlStunden = value; }
        }

        public float FerienKuerzungAnzahlStunden
        {
            get { return _ferienKuerzungAnzahlStunden; }
            set { _ferienKuerzungAnzahlStunden = value; }
        }

        public long FibuKonto
        {
            get { return _fibuKonto; }
            set { _fibuKonto = value; }
        }

        public int Funktion
        {
            get { return _funktion; }
            set { _funktion = value; }
        }

        public System.DateTime? GeburtsDatum
        {
            get { return _geburtsDatum; }
            set { _geburtsDatum = value; }
        }

        public int Geschaeftsbereich
        {
            get { return _geschaeftsbereich; }
            set { _geschaeftsbereich = value; }
        }

        public string Geschlecht
        {
            get { return _geschlecht; }
            set { _geschlecht = value; }
        }

        public DateTime? GueltigkeitsDatumAusbezahlteUeberstunden
        {
            get { return _gueltigkeitsDatumAusbezahlteUeberstunden; }
            set { _gueltigkeitsDatumAusbezahlteUeberstunden = value; }
        }

        public DateTime? GueltigkeitsDatumBeschaeftigungsgradAenderung
        {
            get { return _gueltigkeitsDatumBeschaeftigungsgradAenderung; }
            set { _gueltigkeitsDatumBeschaeftigungsgradAenderung = value; }
        }

        public DateTime? GueltigkeitsDatumFerienanspruchProJahr
        {
            get { return _gueltigkeitsDatumFerienanspruchProJahr; }
            set { _gueltigkeitsDatumFerienanspruchProJahr = value; }
        }

        public DateTime? GueltigkeitsDatumSollStundenProTag
        {
            get { return _gueltigkeitsDatumSollStundenProTag; }
            set { _gueltigkeitsDatumSollStundenProTag = value; }
        }

        public float Januar
        {
            get { return _januar; }
            set { _januar = value; }
        }

        public float Juli
        {
            get { return _juli; }
            set { _juli = value; }
        }

        public float Juni
        {
            get { return _juni; }
            set { _juni = value; }
        }

        public long Kostenstelle
        {
            get { return _kostenstelle; }
            set { _kostenstelle = value; }
        }

        public long Kostentraeger
        {
            get { return _kostentraeger; }
            set { _kostentraeger = value; }
        }

        public string Land
        {
            get { return _land; }
            set { _land = value; }
        }

        public string LanguageCodeString
        {
            get { return _languageCodeString; }
            set { _languageCodeString = value; }
        }

        public string LohnTyp
        {
            get { return _lohnTyp; }
            set { _lohnTyp = value; }
        }

        public float Maerz
        {
            get { return _maerz; }
            set { _maerz = value; }
        }

        public float Mai
        {
            get { return _mai; }
            set { _mai = value; }
        }

        public long MitarbeiterNummer
        {
            get { return _mitarbeiterNummer; }
            set { _mitarbeiterNummer = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public float November
        {
            get { return _november; }
            set { _november = value; }
        }

        public float Oktober
        {
            get { return _oktober; }
            set { _oktober = value; }
        }

        public string Ort
        {
            get { return _ort; }
            set { _ort = value; }
        }

        public string Plz
        {
            get { return _plz; }
            set { _plz = value; }
        }

        public long PlzArbeitsort
        {
            get { return _plzArbeitsort; }
            set { _plzArbeitsort = value; }
        }

        public int PlzArbeitsortSollarbeitszeit
        {
            get { return _plzArbeitsortSollarbeitszeit; }
            set { _plzArbeitsortSollarbeitszeit = value; }
        }

        public string PostfachUndNr
        {
            get { return _postfachUndNr; }
            set { _postfachUndNr = value; }
        }

        public int Qualifikation
        {
            get { return _qualifikation; }
            set { _qualifikation = value; }
        }

        public float September
        {
            get { return _september; }
            set { _september = value; }
        }

        public float SollStundenProTag
        {
            get { return _sollStundenProTag; }
            set { _sollStundenProTag = value; }
        }

        public int StichJahr
        {
            get { return _stichJahr; }
            set { _stichJahr = value; }
        }

        public int StichMonat
        {
            get { return _stichMonat; }
            set { _stichMonat = value; }
        }

        public string StrasseUndNummer
        {
            get { return _strasseUndNummer; }
            set { _strasseUndNummer = value; }
        }

        public string StrasseZusatz
        {
            get { return _strasseZusatz; }
            set { _strasseZusatz = value; }
        }

        public float StundenAnsatz1
        {
            get { return _stundenAnsatz1; }
            set { _stundenAnsatz1 = value; }
        }

        public float StundenAnsatz11
        {
            get { return _stundenAnsatz11; }
            set { _stundenAnsatz11 = value; }
        }

        public float StundenAnsatz12
        {
            get { return _stundenAnsatz12; }
            set { _stundenAnsatz12 = value; }
        }

        public float StundenAnsatz13
        {
            get { return _stundenAnsatz13; }
            set { _stundenAnsatz13 = value; }
        }

        public float StundenAnsatz14
        {
            get { return _stundenAnsatz14; }
            set { _stundenAnsatz14 = value; }
        }

        public float StundenAnsatz15
        {
            get { return _stundenAnsatz15; }
            set { _stundenAnsatz15 = value; }
        }

        public float StundenAnsatz16
        {
            get { return _stundenAnsatz16; }
            set { _stundenAnsatz16 = value; }
        }

        public float StundenAnsatz2
        {
            get { return _stundenAnsatz2; }
            set { _stundenAnsatz2 = value; }
        }

        public float StundenAnsatz3
        {
            get { return _stundenAnsatz3; }
            set { _stundenAnsatz3 = value; }
        }

        public float StundenAnsatz4
        {
            get { return _stundenAnsatz4; }
            set { _stundenAnsatz4 = value; }
        }

        public string TelefonNrGesch
        {
            get { return _telefonNrGesch; }
            set { _telefonNrGesch = value; }
        }

        public string TelefonNrMobil
        {
            get { return _telefonNrMobil; }
            set { _telefonNrMobil = value; }
        }

        public string TelefonNrPrivat
        {
            get { return _telefonNrPrivat; }
            set { _telefonNrPrivat = value; }
        }

        public float TotalJahr
        {
            get { return _totalJahr; }
            set { _totalJahr = value; }
        }

        public string VorName
        {
            get { return _vorName; }
            set { _vorName = value; }
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string ToString()
        {
            var sb = new StringBuilder();
            var properties = GetType().GetProperties();
            foreach (var property in properties)
            {
                object val = property.GetValue(this, null);
                sb.Append(property.Name);
                sb.Append(": ");
                sb.Append(val);
                sb.Append(" ");
            }

            return sb.ToString();
        }

        #endregion

        #endregion
    }
}