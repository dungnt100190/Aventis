namespace KiSS4.Gesuchverwaltung.ExcelImport
{
    /// <summary>
    /// Class that contains all named ranges that are imported from the excel document.
    /// </summary>
    static class NamedRange
    {
        #region Nested Types

        public static class AbklaerendeStelle
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string BEANTRAGENDE_STELLE = "AS_Beantragende_Stelle";
            public const string BEZIRK = "AS_Bezirk";
            public const string EMAIL = "AS_Email";
            public const string HAUSNR = "AS_HausNr";
            public const string KANTON = "AS_Kanton";
            public const string KONTAKTPERSON = "AS_Kontaktperson";
            public const string ORT = "AS_Ort";
            public const string PLZ = "AS_Plz";
            public const string POSTFACH = "AS_Postfach";
            public const string POSTFACH_OHNENR = "AS_Postfach_OhneNr";
            public const string STRASSE = "AS_Strasse";
            public const string TELEFON = "AS_Telefon";
            public const string ZAHLUNGSINSTRUKTIONEN = "AS_Zahlungsinstruktionen";
            public const string ZUSATZ = "AS_Zusatz";

            #endregion

            #endregion
        }

        public static class AntragFinanzierung
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string FLB_BETRAG = "AF_FLB_Betrag";
            public const string GESUCHSGRUND = "AF_Gesuchsgrund";
            public const string ZEILE1_BETRAG = "AF_Zeile1_Betrag";
            public const string ZEILE1_BEZEICHNUNG = "AF_Zeile1_Bezeichnung";
            public const string ZEILE2_BETRAG = "AF_Zeile2_Betrag";
            public const string ZEILE2_BEZEICHNUNG = "AF_Zeile2_Bezeichnung";
            public const string ZEILE3_BETRAG = "AF_Zeile3_Betrag";
            public const string ZEILE3_BEZEICHNUNG = "AF_Zeile3_Bezeichnung";
            public const string ZEILE4_BETRAG = "AF_Zeile4_Betrag";
            public const string ZEILE4_BEZEICHNUNG = "AF_Zeile4_Bezeichnung";

            #endregion

            #endregion
        }

        public static class AntragKosten
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string ZEILE1_BETRAG = "AK_Zeile1_Betrag";
            public const string ZEILE1_BEZEICHNUNG = "AK_Zeile1_Bezeichnung";
            public const string ZEILE2_BETRAG = "AK_Zeile2_Betrag";
            public const string ZEILE2_BEZEICHNUNG = "AK_Zeile2_Bezeichnung";
            public const string ZEILE3_BETRAG = "AK_Zeile3_Betrag";
            public const string ZEILE3_BEZEICHNUNG = "AK_Zeile3_Bezeichnung";
            public const string ZEILE4_BETRAG = "AK_Zeile4_Betrag";
            public const string ZEILE4_BEZEICHNUNG = "AK_Zeile4_Bezeichnung";
            public const string ZEILE5_BETRAG = "AK_Zeile5_Betrag";
            public const string ZEILE5_BEZEICHNUNG = "AK_Zeile5_Bezeichnung";

            #endregion

            #endregion
        }

        public static class Begruendung
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string BEGRUENDUNG = "BE_Begründung";

            #endregion

            #endregion
        }

        public static class Klient
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string AUSBILDUNG = "KL_Ausbildung";
            public const string AUSLAENDER_STATUS = "KL_Aufenthaltsstatus";
            public const string BEHINDERUNGSART2 = "KL_Behinderungsart2";
            public const string ERWERBSSITUATION = "KL_Erwerbssituation";
            public const string GEBURTSDATUM = "KL_Geburtsdatum";
            public const string GESCHLECHT = "KL_Geschlecht";
            public const string HAUPTBEHINDERUNGSART = "KL_Hauptbehinderungsart";
            public const string HAUSNR = "KL_HausNr";
            public const string IN_CH_SEIT = "KL_InSchweizSeit";
            public const string IN_CH_SEIT_GEBURT = "KL_SeitGeburt";
            public const string NAME = "KL_Name";
            public const string NATIONALITAET = "KL_Nation";
            public const string ORT = "KL_Ort";
            public const string PLZ = "KL_Plz";
            public const string STRASSE = "KL_Strasse";
            public const string VERSNR = "KL_VersNr";
            public const string VORMUND_MASSNAHME = "KL_VormundMassnahme";
            public const string VORNAME = "KL_Vorname";
            public const string ZIVILSTAND = "KL_Zivilstand";
            public const string ZUSATZ = "KL_Zusatz";

            #endregion

            #endregion
        }

        public static class Personen
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string PERSON10_GEBURTSDATUM = "PE_Person10_Geburtsdatum";
            public const string PERSON10_GESCHLECHT = "PE_Person10_Geschlecht";
            public const string PERSON10_NAME = "PE_Person10_Name";
            public const string PERSON10_RELATION = "PE_Person10_Relation";
            public const string PERSON10_VORNAME = "PE_Person10_Vorname";
            public const string PERSON1_GEBURTSDATUM = "PE_Person1_Geburtsdatum";
            public const string PERSON1_GESCHLECHT = "PE_Person1_Geschlecht";
            public const string PERSON1_NAME = "PE_Person1_Name";
            public const string PERSON1_RELATION = "PE_Person1_Relation";
            public const string PERSON1_VORNAME = "PE_Person1_Vorname";
            public const string PERSON2_GEBURTSDATUM = "PE_Person2_Geburtsdatum";
            public const string PERSON2_GESCHLECHT = "PE_Person2_Geschlecht";
            public const string PERSON2_NAME = "PE_Person2_Name";
            public const string PERSON2_RELATION = "PE_Person2_Relation";
            public const string PERSON2_VORNAME = "PE_Person2_Vorname";
            public const string PERSON3_GEBURTSDATUM = "PE_Person3_Geburtsdatum";
            public const string PERSON3_GESCHLECHT = "PE_Person3_Geschlecht";
            public const string PERSON3_NAME = "PE_Person3_Name";
            public const string PERSON3_RELATION = "PE_Person3_Relation";
            public const string PERSON3_VORNAME = "PE_Person3_Vorname";
            public const string PERSON4_GEBURTSDATUM = "PE_Person4_Geburtsdatum";
            public const string PERSON4_GESCHLECHT = "PE_Person4_Geschlecht";
            public const string PERSON4_NAME = "PE_Person4_Name";
            public const string PERSON4_RELATION = "PE_Person4_Relation";
            public const string PERSON4_VORNAME = "PE_Person4_Vorname";
            public const string PERSON5_GEBURTSDATUM = "PE_Person5_Geburtsdatum";
            public const string PERSON5_GESCHLECHT = "PE_Person5_Geschlecht";
            public const string PERSON5_NAME = "PE_Person5_Name";
            public const string PERSON5_RELATION = "PE_Person5_Relation";
            public const string PERSON5_VORNAME = "PE_Person5_Vorname";
            public const string PERSON6_GEBURTSDATUM = "PE_Person6_Geburtsdatum";
            public const string PERSON6_GESCHLECHT = "PE_Person6_Geschlecht";
            public const string PERSON6_NAME = "PE_Person6_Name";
            public const string PERSON6_RELATION = "PE_Person6_Relation";
            public const string PERSON6_VORNAME = "PE_Person6_Vorname";
            public const string PERSON7_GEBURTSDATUM = "PE_Person7_Geburtsdatum";
            public const string PERSON7_GESCHLECHT = "PE_Person7_Geschlecht";
            public const string PERSON7_NAME = "PE_Person7_Name";
            public const string PERSON7_RELATION = "PE_Person7_Relation";
            public const string PERSON7_VORNAME = "PE_Person7_Vorname";
            public const string PERSON8_GEBURTSDATUM = "PE_Person8_Geburtsdatum";
            public const string PERSON8_GESCHLECHT = "PE_Person8_Geschlecht";
            public const string PERSON8_NAME = "PE_Person8_Name";
            public const string PERSON8_RELATION = "PE_Person8_Relation";
            public const string PERSON8_VORNAME = "PE_Person8_Vorname";
            public const string PERSON9_GEBURTSDATUM = "PE_Person9_Geburtsdatum";
            public const string PERSON9_GESCHLECHT = "PE_Person9_Geschlecht";
            public const string PERSON9_NAME = "PE_Person9_Name";
            public const string PERSON9_RELATION = "PE_Person9_Relation";
            public const string PERSON9_VORNAME = "PE_Person9_Vorname";

            #endregion

            #endregion
        }

        public static class Sozialversicherung
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string ARBEITSLOSENKASSE = "SV_Arbeitslosenkasse";
            public const string BERUFLICHE_MASSNAHMEN_IV = "SV_BeruflicheMassnahmenIv";
            public const string BVG_RENTE = "SV_BvgRente";
            public const string ERGAENZUNGSLEISTUNGEN = "SV_Ergaenzungsleistungen";
            public const string HILFLOSENENTSCHAEDIGUNG = "SV_Hilflosenentschaedigung";
            public const string INTENSIVPFLEGEZUSCHLAG = "SV_Intensivpflegezuschlag";
            public const string IV_GRAD = "SV_IvGrad";
            public const string IV_HILFSMITTEL = "SV_IvHilfsmittel";
            public const string IV_TAGGELD = "SV_IvTaggeld";
            public const string KRANKENTAGGELD = "SV_Krankentaggeld";
            public const string MEDIZINISCHE_MASSNAHMEN_IV = "SV_MedizinischeMassnahmenIv";
            public const string RENTENSTUFE = "SV_Rentestufe";
            public const string SOZIALHILFE = "SV_Sozialhilfe";
            public const string UVG_RENTE = "SV_UvgRente";
            public const string UVG_TAGGELD = "SV_UvgTaggeld";
            public const string WITTWEN_WITTWER_WAISEN_RENTE = "SV_WittwenWittwerWaisenrente";
            public const string ANDERE_SOZIALVERSICHERUNGSLEISTUNGEN = "SV_AndereSVLeistungen";

            #endregion

            #endregion
        }

        public class Version
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string NUMMER = "VE_ExcelTemplateVersion";

            #endregion

            #endregion
        }

        public class Zahlweg
        {
            #region Fields

            #region Public Constant/Read-Only Fields

            public const string BANKKONTONR = "ZW_BankkontoNr";
            public const string BANK_CLEARING = "ZW_Bank_Clearing";
            public const string BANK_IBAN = "ZW_Bank_IBAN";
            public const string BANK_NAME = "ZW_Bank_Name";
            public const string HAUSNR = "ZW_HausNr";
            public const string NAME_VORNAME_KONTO_INHABER = "ZW_NameVornameKontoInhaber";
            public const string ORT = "ZW_Ort";
            public const string PLZ = "ZW_Plz";
            public const string POSTKONTONR = "ZW_PostkontoNr";
            public const string REFERENZNR = "ZW_ReferenzNr";
            public const string STRASSE = "ZW_Strasse";
            public const string ZAHLUNGSINSTRUKTIONEN = "AS_Zahlungsinstruktionen";
            public const string ZAHLUNGSWEGTYP = "ZW_Zahlungswegtyp";
            public const string ZUSATZ = "ZW_Zusatz";

            #endregion

            #endregion
        }

        #endregion
    }
}