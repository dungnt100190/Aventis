using System;
using System.Collections.Generic;
using System.Globalization;

namespace KiSS4.Schnittstellen.Newod.DTO
{
    public class PersonBasisDaten
    {
        #region Properties

        /// <summary>
        /// Get/Set AHVNummer
        /// </summary>
        public string AHVNummer
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Alter
        /// </summary>
        public int? Alter
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Anrede
        /// </summary>
        public string AnredeText
        {
            get; set;
        }

        /// <summary>
        /// Get/Set AuslaenderStatusCode
        /// </summary>
        public int? AuslaenderStatusCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set AuslaenderStatusGueltigBis
        /// </summary>
        public DateTime? AuslaenderStatusGueltigBis
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ErteilungVA
        /// </summary>
        public DateTime? ErteilungVA
        {
            get; set;
        }

        /// <summary>
        /// Get/Set FaxPrivat
        /// </summary>
        public string FaxPrivat
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Name
        /// </summary>
        public string FruehererName
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Geburtsdatum
        /// </summary>
        public DateTime? Geburtsdatum
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Geschlecht
        /// </summary>
        public int? GeschlechtCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set HeimatgemeindeBaGemeindeID
        /// </summary>
        public int? HeimatgemeindeBaGemeindeID
        {
            get; set;
        }

        /// <summary>
        /// Get/Set HeimatgemeindeBaGemeindeIds
        /// </summary>
        public List<int> HeimatgemeindeBaGemeindeIds
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ID
        /// </summary>
        public string ID
        {
            get; set;
        }

        /// <summary>
        /// Get/Set FT (ist Fallträger)
        /// </summary>
        public bool IsFT
        {
            get; set;
        }

        /// <summary>
        /// Get/Set KonfessionCode
        /// </summary>
        public int? KonfessionCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Name
        /// </summary>
        public string Name
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Nationalitaet
        /// </summary>
        public string Nationalitaet
        {
            get; set;
        }

        /// <summary>
        /// Get/Set NationalitaetCode
        /// </summary>
        public int? NationalitaetCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set SpracheCode
        /// </summary>
        public int? SpracheCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Geburtsdatum
        /// </summary>
        public DateTime? Sterbedatum
        {
            get; set;
        }

        /// <summary>
        /// Get/Set TelefonGeschaeft
        /// </summary>
        public string TelefonGeschaeft
        {
            get; set;
        }

        /// <summary>
        /// Get/Set TelefonPrivat
        /// </summary>
        public string TelefonPrivat
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Versichertennummer
        /// </summary>
        public ulong? Versichertennummer
        {
            get; set;
        }

        /// <summary>
        /// Get/Set Vorname
        /// </summary>
        public string Vorname
        {
            get; set;
        }

        /// <summary>
        /// Get/Set WegzugDatum
        /// </summary>
        public DateTime? WegzugDatum
        {
            get; set;
        }

        /// <summary>
        /// Get/Set WegzugKanton
        /// </summary>
        public string WegzugKanton
        {
            get; set;
        }

        /// <summary>
        /// Get/Set WegzugLand
        /// </summary>
        public string WegzugLand
        {
            get; set;
        }

        /// <summary>
        /// Get/Set WegzugLandCode
        /// </summary>
        public int? WegzugLandCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set WegzugOrt
        /// </summary>
        public string WegzugOrt
        {
            get; set;
        }

        /// <summary>
        /// Get/Set WegzugOrtCode
        /// </summary>
        public int? WegzugOrtCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set WegzugPlz
        /// </summary>
        public string WegzugPlz
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZemisNummer
        /// </summary>
        public string ZemisNummer
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZivilstandCode
        /// </summary>
        public int? ZivilstandCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZivilstandDatum
        /// </summary>
        public DateTime? ZivilstandDatum
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZuzugDatum
        /// </summary>
        public DateTime? ZuzugDatum
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZuzugKanton
        /// </summary>
        public string ZuzugKanton
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZuzugLand
        /// </summary>
        public string ZuzugLand
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZuzugLandCode
        /// </summary>
        public int? ZuzugLandCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZuzugOrt
        /// </summary>
        public string ZuzugOrt
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZuzugOrtCode
        /// </summary>
        public int? ZuzugOrtCode
        {
            get; set;
        }

        /// <summary>
        /// Get/Set ZuzugPlz
        /// </summary>
        public string ZuzugPlz
        {
            get; set;
        }

        #endregion

        #region Methods

        #region Public Methods

        public override string ToString()
        {
            string returnMessage = String.Format(@"
                        GetPerson Result:
                        Anrede: {0}
                        FruehererName: {1}
                        Vorname: {2}
                        Name: {3}
                        Versichertennummer: {4}
                        Sterbedatum: {5}
                        Konfession-Code: {6}",
             AnredeText, FruehererName, Vorname, Name,
             Versichertennummer.ToString(), Sterbedatum.ToString(),
             KonfessionCode);
            return returnMessage;
        }

        #endregion

        #endregion
    }
}