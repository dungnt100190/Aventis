using System;
using System.Collections.Generic;

namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class Person
    {
        #region Fields

        #region Private Fields

        private PersonAdressDaten _addressdaten;
        private PersonBasisDaten _basisdaten;

        #endregion

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public Person()
            : this(new PersonBasisDaten(), new PersonAdressDaten())
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="basisdaten"></param>
        /// <param name="addressdaten"></param>
        public Person(PersonBasisDaten basisdaten, PersonAdressDaten addressdaten)
        {
            _basisdaten = basisdaten;
            _addressdaten = addressdaten;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get AHVNummer
        /// </summary>
        public string AHVNummer
        {
            get { return _basisdaten.AHVNummer; }
            set { _basisdaten.AHVNummer = value; }
        }

        /// <summary>
        /// Get AdressDaten
        /// </summary>
        public PersonAdressDaten AdressDaten
        {
            get { return _addressdaten; }
            set { _addressdaten = value; }
        }

        /// <summary>
        /// Get Alter
        /// </summary>
        public int? Alter
        {
            get { return _basisdaten.Alter; }
            set { _basisdaten.Alter = value; }
        }

        /// <summary>
        /// Get Anrede
        /// </summary>
        public string AnredeText
        {
            get { return _basisdaten.AnredeText; }
            set { _basisdaten.AnredeText = value; }
        }

        /// <summary>
        /// Get AuslaenderStatusCode
        /// </summary>
        public int? AuslaenderStatusCode
        {
            get { return _basisdaten.AuslaenderStatusCode; }
            set { _basisdaten.AuslaenderStatusCode = value; }
        }

        /// <summary>
        /// Get AuslaenderStatusGueltigBis
        /// </summary>
        public DateTime? AuslaenderStatusGueltigBis
        {
            get { return _basisdaten.AuslaenderStatusGueltigBis; }
            set { _basisdaten.AuslaenderStatusGueltigBis = value; }
        }

        /// <summary>
        /// Get Basisdaten
        /// </summary>
        public PersonBasisDaten Basisdaten
        {
            get { return _basisdaten; }
            set { _basisdaten = value; }
        }

        /// <summary>
        /// Get DatumBis
        /// </summary>
        public DateTime? DatumBis
        {
            get { return _addressdaten.DatumBis; }
            set { _addressdaten.DatumBis = value; }
        }

        /// <summary>
        /// Get DatumVon
        /// </summary>
        public DateTime? DatumVon
        {
            get { return _addressdaten.DatumVon; }
            set { _addressdaten.DatumVon = value; }
        }

        /// <summary>
        /// Get ErteilungVA
        /// </summary>
        public DateTime? ErteilungVA
        {
            get { return _basisdaten.ErteilungVA; }
            set { _basisdaten.ErteilungVA = value; }
        }

        /// <summary>
        /// Get FruehererName
        /// </summary>
        public string FruehererName
        {
            get { return _basisdaten.FruehererName; }
            set { _basisdaten.FruehererName = value; }
        }

        /// <summary>
        /// Get/Set Geburtsdatum
        /// </summary>
        public DateTime? Geburtsdatum
        {
            get { return _basisdaten.Geburtsdatum; }
            set { _basisdaten.Geburtsdatum = value; }
        }

        /// <summary>
        /// Get Geschlecht (KiSS Wert)
        /// </summary>
        public int? GeschlechtCode
        {
            get { return _basisdaten.GeschlechtCode; }
            set { _basisdaten.GeschlechtCode = value; }
        }

        /// <summary>
        /// Get HausNr
        /// </summary>
        public string HausNr
        {
            get { return _addressdaten.HausNr; }
            set { _addressdaten.HausNr = value; }
        }

        /// <summary>
        /// Get HeimatgemeindeBaGemeindeID
        /// </summary>
        public int? HeimatgemeindeBaGemeindeID
        {
            get { return _basisdaten.HeimatgemeindeBaGemeindeID; }
            set { _basisdaten.HeimatgemeindeBaGemeindeID = value; }
        }

        /// <summary>
        /// Get HeimatgemeindeBaGemeindeID
        /// </summary>
        public List<int> HeimatgemeindeBaGemeindeIds
        {
            get { return _basisdaten.HeimatgemeindeBaGemeindeIds; }
            set { _basisdaten.HeimatgemeindeBaGemeindeIds = value; }
        }

        /// <summary>
        /// Gets Id
        /// </summary>
        public string ID
        {
            get { return _basisdaten.ID; }
        }

        /// <summary>
        /// Get isFT (ist Fallträger)
        /// </summary>
        public bool IsFT
        {
            get { return _basisdaten.IsFT; }
            set { _basisdaten.IsFT = value; }
        }

        /// <summary>
        /// Get/Set Kanton
        /// </summary>
        public string Kanton
        {
            get { return _addressdaten.Kanton; }
            set { _addressdaten.Kanton = value; }
        }

        /// <summary>
        /// Get Land (Newod Wert)
        /// </summary>
        public string Land
        {
            get { return _addressdaten.Land; }
            set { _addressdaten.Land = value; }
        }

        /// <summary>
        /// Get LandCode (KiSSWert)
        /// </summary>
        public int? LandId
        {
            get { return _addressdaten.LandId; }
            set { _addressdaten.LandId = value; }
        }

        /// <summary>
        /// Get Name
        /// </summary>
        public string Name
        {
            get { return _basisdaten.Name; }
            set { _basisdaten.Name = value; }
        }

        /// <summary>
        /// Get NationalitaetCode (KiSSWert)
        /// </summary>
        public int? NationalitaetCode
        {
            get { return _basisdaten.NationalitaetCode; }
            set { _basisdaten.NationalitaetCode = value; }
        }

        /// <summary>
        /// Get Ort
        /// </summary>
        public string Ort
        {
            get { return _addressdaten.Ort; }
            set { _addressdaten.Ort = value; }
        }

        /// <summary>
        /// Get Plz
        /// </summary>
        public string Plz
        {
            get { return _addressdaten.Plz; }
            set { _addressdaten.Plz = value; }
        }

        /// <summary>
        /// Get/Set Postfach
        /// </summary>
        public string Postfach
        {
            get { return _addressdaten.Postfach; }
            set { _addressdaten.Postfach = value; }
        }

        /// <summary>
        /// Get SpracheCode
        /// </summary>
        public int? SpracheCode
        {
            get { return _basisdaten.SpracheCode; }
            set { _basisdaten.SpracheCode = value; }
        }

        /// <summary>
        /// Get/Set Geburtsdatum
        /// </summary>
        public DateTime? Sterbedatum
        {
            get { return _basisdaten.Sterbedatum; }
            set { _basisdaten.Sterbedatum = value; }
        }

        /// <summary>
        /// Get Strasse
        /// </summary>
        public string Strasse
        {
            get { return _addressdaten.Strasse; }
            set { _addressdaten.Strasse = value; }
        }

        /// <summary>
        /// Get TelefonPrivat
        /// </summary>
        public string TelefonPrivat
        {
            get { return _basisdaten.TelefonPrivat; }
            set { _basisdaten.TelefonPrivat = value; }
        }

        /// <summary>
        /// Versichertennummer
        /// </summary>
        public ulong? Versichertennummer
        {
            get { return _basisdaten.Versichertennummer; }
            set { _basisdaten.Versichertennummer = value; }
        }

        /// <summary>
        /// Get Vorname
        /// </summary>
        public string Vorname
        {
            get { return _basisdaten.Vorname; }
            set { _basisdaten.Vorname = value; }
        }

        /// <summary>
        /// Get WegzugDatum
        /// </summary>
        public DateTime? WegzugDatum
        {
            get { return _basisdaten.WegzugDatum; }
            set { _basisdaten.WegzugDatum = value; }
        }

        /// <summary>
        /// Get WegzugKanton
        /// </summary>
        public string WegzugKanton
        {
            get { return _basisdaten.WegzugKanton; }
            set { _basisdaten.WegzugKanton = value; }
        }

        /// <summary>
        /// Get WegzugLandCode
        /// </summary>
        public int? WegzugLandCode
        {
            get { return _basisdaten.WegzugLandCode; }
            set { _basisdaten.WegzugLandCode = value; }
        }

        /// <summary>
        /// Get WegzugOrt
        /// </summary>
        public string WegzugOrt
        {
            get { return _basisdaten.WegzugOrt; }
            set { _basisdaten.WegzugOrt = value; }
        }

        /// <summary>
        /// Get WegzugOrtCode
        /// </summary>
        public int? WegzugOrtCode
        {
            get { return _basisdaten.WegzugOrtCode; }
            set { _basisdaten.WegzugOrtCode = value; }
        }

        /// <summary>
        /// Get WegzugPlz
        /// </summary>
        public string WegzugPlz
        {
            get { return _basisdaten.WegzugPlz; }
            set { _basisdaten.WegzugPlz = value; }
        }

        /// <summary>
        /// Get ZemisNummer
        /// </summary>
        public string ZemisNummer
        {
            get { return _basisdaten.ZemisNummer; }
            set { _basisdaten.ZemisNummer = value; }
        }

        /// <summary>
        /// Get Zivilstand
        /// </summary>
        public int? ZivilstandCode
        {
            get { return _basisdaten.ZivilstandCode; }
            set { _basisdaten.ZivilstandCode = value; }
        }

        /// <summary>
        /// Get ZivilstandDatum
        /// </summary>
        public DateTime? ZivilstandDatum
        {
            get { return _basisdaten.ZivilstandDatum; }
            set { _basisdaten.ZivilstandDatum = value; }
        }

        /// <summary>
        /// Get/Set Zusatz
        /// </summary>
        public string Zusatz
        {
            get { return _addressdaten.Zusatz; }
            set { _addressdaten.Zusatz = value; }
        }

        /// <summary>
        /// Get ZuzugDatum
        /// </summary>
        public DateTime? ZuzugDatum
        {
            get { return _basisdaten.ZuzugDatum; }
            set { _basisdaten.ZuzugDatum = value; }
        }

        /// <summary>
        /// Get ZuzugKanton
        /// </summary>
        public string ZuzugKanton
        {
            get { return _basisdaten.ZuzugKanton; }
            set { _basisdaten.ZuzugKanton = value; }
        }

        /// <summary>
        /// Get ZuzugLandCode
        /// </summary>
        public int? ZuzugLandCode
        {
            get { return _basisdaten.ZuzugLandCode; }
            set { _basisdaten.ZuzugLandCode = value; }
        }

        /// <summary>
        /// Get ZuzugOrt
        /// </summary>
        public string ZuzugOrt
        {
            get { return _basisdaten.ZuzugOrt; }
            set { _basisdaten.ZuzugOrt = value; }
        }

        /// <summary>
        /// Get ZuzugOrtCode
        /// </summary>
        public int? ZuzugOrtCode
        {
            get { return _basisdaten.ZuzugOrtCode; }
            set { _basisdaten.ZuzugOrtCode = value; }
        }

        /// <summary>
        /// Get ZuzugPlz
        /// </summary>
        public string ZuzugPlz
        {
            get { return _basisdaten.ZuzugPlz; }
            set { _basisdaten.ZuzugPlz = value; }
        }

        #endregion
    }
}