using System;

namespace KiSS.DBScheme
{
    public static partial class LOV
    {
        #region Enumerations

        /// <summary>
        /// Abschlussgrund eines Abzahlungskonto (BgSpezialkonto)
        /// </summary>
        public enum AbzahlungskontoAbschlussgrund
        {
            KontoWirdNichtAusgeglichen = 1,
            UebergabeAnInkasso = 2
        }

        public enum BFSFeldCode
        {
            Text = 2,
            Zahl = 4,
            Datum = 5,
            CheckBox = 7,
            Auswahl = 8
        }

        public enum BgGruppeCode
        {
            /// <summary>
            ///Erwerbseinkommen: 3101
            /// </summary>
            Erwerbseinkommen = 3101,

            /// <summary>
            ///Alimentenguthaben: 3102
            /// </summary>
            Alimentenguthaben = 3102,

            /// <summary>
            ///Einkommen aus Versicherungsleistungen: 3103
            /// </summary>
            Einkommen_aus_Versicherungsleistungen = 3103,

            /// <summary>
            ///Vermögen und Vermögensverbrauch: 3104
            /// </summary>
            Vermoegen_und_Vermoegensverbrauch = 3104,

            /// <summary>
            ///Med. Grundversorgung:    3202
            /// </summary>
            Med_Grundversorgung = 3202,

            /// <summary>
            ///Wohnkosten: 3206
            /// </summary>
            Wohnkosten = 3206,

            /// <summary>
            ///Situationsbedingte Leistungen: 3901
            /// </summary>
            Situationsbedingte_Leistungen = 3901,

            /// <summary>
            ///Krankheits- und behinderunsbedingte Leistungen: 3902
            /// </summary>
            Krankheits_und_behinderunsbedingte_Leistungen = 3902,

            /// <summary>
            ///Leistungen für Therapie- und Entzugsmassnahmen: 3903
            /// </summary>
            Leistungen_fuer_Therapie_und_Entzugsmassnahmen = 3903,

            /// <summary>
            ///Wiedereingliederung: 3904
            Wiedereingliederung = 3904,

            /// <summary>
            ///AHV Beiträge: 3905
            /// </summary>
            AHV_Beitraege = 3905,

            /// <summary>
            ///EFB Erwerbsaufnahme: 39100
            /// </summary>
            EFB_Erwerbsaufnahme = 39100,
            /// <summary>
            ///EFB: 39120
            EFB = 39120,
            /// <summary>
            ///IZU Alleinerziehend: 39210
            /// </summary>
            IZU_Alleinerziehend = 39210
        }

        public enum BgKategorieCode
        {
            /// <summary>
            /// Einnahmen:    1
            /// </summary>
            Einnahmen = 1,
            /// <summary>
            /// Ausgaben:     2
            /// </summary>
            Ausgaben = 2,
            /// <summary>
            /// Abzahlung:    3
            /// </summary>
            Abzahlung = 3,
            /// <summary>
            /// Kürzungen:    4
            /// </summary>
            Kuerzungen = 4,
            /// <summary>
            /// Vermögen:     5
            /// </summary>
            Vermoegen = 5,
            /// <summary>
            /// Vorabzüge:    6
            /// </summary>
            Vorabzuege = 6,
            /// <summary>
            /// Zusätzliche Leistungen: 100
            /// </summary>
            Zusaetzliche_Leistungen = 100,
            /// <summary>
            /// Einzelzahlungen: 101
            /// </summary>
            Einzelzahlungen = 101
        }

        public enum BgPositionsArt
        {
            /// <summary>
            /// Miete - gem. Richtlinie: 62
            /// </summary>
            Miete_Gem_Richtlinie = 62,

            /// <summary>
            ///Vermögensverbrauch: 31050
            /// </summary>
            Vermoegensverbrauch = 31050,

            /// <summary>
            ///KVG Krankenkassenprämien: 32020
            /// </summary>
            KVG_Krankenkassenpraemien = 32020,
            /// <summary>
            ///VVG: 32021
            /// </summary>
            VVG = 32021,
            /// <summary>
            ///VVG Prämie - SIL: 32022
            /// </summary>
            VVG_Praemie_SIL = 32022,
            /// <summary>
            ///KVG - GBL: 32023
            /// </summary>
            KVG_GBL = 32023,
            /// <summary>
            /// KVG - Uebernahme durch SD: 32024
            /// </summary>
            KVG_Uebernahme_durch_SD = 32024,

            /// <summary>
            ///Eff. Erwerbsunkosten : 32030
            /// </summary>
            Eff_Erwerbsunkosten = 32030,

            /// <summary>
            /// Allg. Erwerbsunkosten:   32031
            /// </summary>
            Allg_Erwerbsunkosten = 32031,

            /// <summary>
            ///KVG - Erwachsene (Region 1)
            /// </summary>
            KVG_Erwachsene_Region_1 = 32121,
            /// <summary>
            ///KVG - Erwachsene (Region 2)
            /// </summary>
            KVG_Erwachsene_Region_2 = 32122,
            /// <summary>
            ///KVG - Erwachsene (Region 3)
            /// </summary>
            KVG_Erwachsene_Region_3 = 32123,
            /// <summary>
            ///KVG - Junge Erwachsene (Region 1)
            /// </summary>
            KVG_Junge_Erwachsene_Region_1 = 32124,
            /// <summary>
            ///KVG - Junge Erwachsene (Region 2)
            /// </summary>
            KVG_Junge_Erwachsene_Region_2 = 32125,
            /// <summary>
            ///KVG - Junge Erwachsene (Region 3)
            /// </summary>
            KVG_Junge_Erwachsene_Region_3 = 32126,
            /// <summary>
            ///KVG - Kinder (Region 1)
            /// </summary>
            KVG_Kinder_Region_1 = 32127,
            /// <summary>
            ///KVG - Kinder (Region 2)
            /// </summary>
            KVG_Kinder_Region_2 = 32128,
            /// <summary>
            ///KVG - Kinder (Region 3)
            /// </summary>
            KVG_Kinder_Region_3 = 32129,

            /// <summary>
            ///KVG - EL (nur bei ZOL)
            /// </summary>
            KVG_EL = 32130
        }

        public enum KaAnweisung
        {
            Zuweisung = 1,
            Anweisung = 2,
            Verlaengerung = 3,
            EinsatzOhneAnweisung = 4,
        }

        public enum WhHilfeTypCode
        {
            Ueberbrueckungshilfe = 1,
            Regulaerer_Finanzplan = 2,
            Admin_Fallfuehrung = 3
        }

        #endregion

        #region Fields

        #region Public Constant/Read-Only Fields

        public const string LOVName_Konfession = "Konfession";
        public const string LOVName_Zivilstand = "Zivilstand";

        #endregion

        #endregion
    }
}