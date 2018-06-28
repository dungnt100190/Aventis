using System.IO;

namespace Kiss4Web.Infrastructure.Kiss4Configuration
{
    public static class ConfigNodes
    {
        public static readonly ConfigNode<string> System_Adresse_Sozialhilfe_Organisation =
            new ConfigNode<string>(@"System\Adresse\Sozialhilfe\Organisation");

        public static readonly ConfigNode<int> System_Allgemein_GastrechtAnzahlMonate =
            new ConfigNode<int>(@"System\Allgemein\GastrechtAnzahlMonate");

        public static readonly ConfigNode<string> System_Basis_Gemeindenstamm_URL_BFS =
            new ConfigNode<string>(@"System\Basis\Gemeindenstamm\URL_BFS");

        public static readonly ConfigNode<string> System_Basis_Gemeindenstamm_XPath =
            new ConfigNode<string>(@"System\Basis\Gemeindenstamm\XPath");

        public static readonly ConfigNode<string> System_Basis_Landstamm_URL_BFS =
            new ConfigNode<string>(@"System\Basis\Landstamm\URL_BFS", "http://www.bfs.admin.ch/bfs/portal/de/index/infothek/nomenklaturen/blank/blank/sg/02.Document.105271.zip");

        public static readonly ConfigNode<string> System_Basis_PlzStamm_FTP_User =
            new ConfigNode<string>(@"System\Basis\PLZstamm\FTP_User");

        public static readonly ConfigNode<string> System_Basis_PlzStamm_FTP_User_Password =
            new ConfigNode<string>(@"System\Basis\PLZstamm\FTP_User_Password");

        public static readonly ConfigNode<string> System_Basis_PlzStamm_URL_FTP =
            new ConfigNode<string>(@"System\Basis\PLZstamm\URL_FTP");

        public static readonly ConfigNode<string> System_Dokumentemanagement_Temporaerpfad =
            new ConfigNode<string>(@"System\Dokumentemanagement\Temporaerpfad", Path.Combine(Path.GetTempPath(), "KiSS"));

        public static readonly ConfigNode<bool> System_Fallfuehrung_Kategorisierung_NurFallfuehrerDarfMutieren =
            new ConfigNode<bool>(@"System\Fallfuehrung\Kategorisierung\NurFallfuehrerDarfMutieren", false);

        public static readonly ConfigNode<bool> System_Fallfuehrung_LogischesLoeschen = new ConfigNode<bool>(@"System\Fallfuehrung\LogischesLoeschen");

        //public static readonly ConfigNode<XLOVCode[]> System_Fallfuehrung_Zeitachse_AngezeigteThemen =
        //    new ConfigNode<XLOVCode[]>(@"System\Fallfuehrung\Zeitachse\AngezeigteThemen");

        public static readonly ConfigNode<int> System_Fallfuehrung_Zeitachse_AnzahlMonateInVergangenheit =
            new ConfigNode<int>(@"System\Fallfuehrung\Zeitachse\ZeitachseAnzahlMonateInVergangenheit");

        public static readonly ConfigNode<int> System_Fallfuehrung_Zeitachse_AnzahlMonateInZukunft =
            new ConfigNode<int>(@"System\Fallfuehrung\Zeitachse\ZeitachseAnzahlMonateInZukunft");

        public static readonly ConfigNode<string> System_Fibu_SaldoGruppeName_Betriebskonto =
            new ConfigNode<string>(@"System\Fibu\SaldoGruppeName\Betriebskonto");

        public static readonly ConfigNode<bool> System_Fibu_Buchen_GenerateBelegNrProMandant =
            new ConfigNode<bool>(@"System\Fibu\Buchen\GenerateBelegNrProMandant");

        public static readonly ConfigNode<string> System_Fibu_SaldoGruppeName_DepotBs =
            new ConfigNode<string>(@"System\Fibu\SaldoGruppeName\DepotBs");

        public static readonly ConfigNode<string> System_Fibu_SaldoGruppeName_KassePc =
            new ConfigNode<string>(@"System\Fibu\SaldoGruppeName\KassePc");

        public static readonly ConfigNode<bool> System_Iban_Web =
            new ConfigNode<bool>(@"System\IBAN\Web");

        public static readonly ConfigNode<string> System_Iban_Web_AdditionalParameters =
            new ConfigNode<string>(@"System\IBAN\Web\AdditionalParameters", "Button1=Konvertieren");

        public static readonly ConfigNode<string> System_Iban_Web_InputElementBC =
            new ConfigNode<string>(@"System\IBAN\Web\InputElementBC", @"TextBox1");

        public static readonly ConfigNode<string> System_Iban_Web_InputElementEventValidation =
            new ConfigNode<string>(@"System\IBAN\Web\InputElementEventValidation", "__EVENTVALIDATION");

        public static readonly ConfigNode<string> System_Iban_Web_InputElementKontoNr =
            new ConfigNode<string>(@"System\IBAN\Web\InputElementKontoNr", "TextBox2");

        public static readonly ConfigNode<string> System_Iban_Web_InputElementViewState =
            new ConfigNode<string>(@"System\IBAN\Web\InputElementViewState", "__VIEWSTATE");

        public static readonly ConfigNode<string> System_Iban_Web_OutputXPathBC =
            new ConfigNode<string>(@"System\IBAN\Web\OutputXPathBC", @"//*[@id=""Label3""]");

        public static readonly ConfigNode<string> System_Iban_Web_OutputXPathIBAN =
            new ConfigNode<string>(@"System\IBAN\Web\OutputXPathIBAN", @"//*[@id=""Label1""]");

        public static readonly ConfigNode<string> System_Iban_Web_OutputXPathPC =
            new ConfigNode<string>(@"System\IBAN\Web\OutputXPathPC", @"//*[@id=""Label2""]");

        public static readonly ConfigNode<string> System_Iban_Web_OutputXPathStatus =
            new ConfigNode<string>(@"System\IBAN\Web\OutputXPathStatus", @"//*[@id=""Label4""]");

        public static readonly ConfigNode<string> System_Iban_Web_OutputXPathStatusText =
            new ConfigNode<string>(@"System\IBAN\Web\OutputXPathStatusText", @"//*[@id=""lblStatusText""]");

        public static readonly ConfigNode<string> System_Iban_Web_Url =
            new ConfigNode<string>(@"System\IBAN\Web\URL", "http://www.federli.ch/iban/default.aspx?lang=de");

        public static readonly ConfigNode<string> System_Iban_Web_XPathEventValidation =
            new ConfigNode<string>(@"System\IBAN\Web\XPathEventValidation", @"//*[@id=""__EVENTVALIDATION""]");

        public static readonly ConfigNode<string> System_Iban_Web_XPathViewState =
            new ConfigNode<string>(@"System\IBAN\Web\XPathViewState", @"//*[@id=""__VIEWSTATE""]");

        public static readonly ConfigNode<int> System_Kes_Abfragen_DossiernachweisGEF_PflegekinderaufsichtTagespflege =
            new ConfigNode<int>(@"System\Kes\Abfragen\DossiernachweisGEF\PflegekinderaufsichtTagespflege");

        public static readonly ConfigNode<int> System_Kes_Abfragen_DossiernachweisGEF_RegelmaessigeBeratung =
            new ConfigNode<int>(@"System\Kes\Abfragen\DossiernachweisGEF\RegelmaessigeBeratung");

        public static readonly ConfigNode<bool> System_Kes_KesMassnahme_AufgabenbereichSichtbar =
            new ConfigNode<bool>(@"System\Kes\KesMassnahme\AufgabenbereichSichtbar");

        public static readonly ConfigNode<bool> System_Kes_KesMassnahme_IndikationSichtbar =
            new ConfigNode<bool>(@"System\Kes\KesMassnahme\IndikationSichtbar");

        public static readonly ConfigNode<bool> System_Kes_KesMassnahme_IstKESB =
            new ConfigNode<bool>(@"System\Kes\KesMassnahme\IstKESB");

        public static readonly ConfigNode<bool> System_Pendenzen_KesFrist_AuftragsAbklaerungsErledigung_Aktiv =
            new ConfigNode<bool>(@"System\Pendenzen\KesFrist\AuftragsAbklaerungsErledigung\Aktiv");

        public static readonly ConfigNode<int> System_Pendenzen_KesFrist_AuftragsAbklaerungsErledigung_AnzahlTage =
            new ConfigNode<int>(@"System\Pendenzen\KesFrist\AuftragsAbklaerungsErledigung\AnzahlTage");

        public static readonly ConfigNode<bool> System_Pendenzen_KesFrist_ErledigungSD_Aktiv =
            new ConfigNode<bool>(@"System\Pendenzen\KesFrist\ErledigungSD\Aktiv");

        public static readonly ConfigNode<bool> System_Pendenzen_KesFrist_MassnahmeAuftragErledigung_Aktiv =
            new ConfigNode<bool>(@"System\Pendenzen\KesFrist\MassnahmeAuftragErledigung\Aktiv");

        public static readonly ConfigNode<bool> System_Pendenzen_KesFrist_MassnahmeAuftragVersandBericht_Aktiv =
            new ConfigNode<bool>(@"System\Pendenzen\KesFrist\MassnahmeAuftragVersandBericht\Aktiv");

        public static readonly ConfigNode<int> System_Pendenzen_KesFrist_MassnahmeAuftragVersandBericht_AnzahlTage =
            new ConfigNode<int>(@"System\Pendenzen\KesFrist\MassnahmeAuftragVersandBericht\AnzahlTage");

        public static readonly ConfigNode<bool> System_Pendenzen_KesFrist_MassnahmePeriode_Aktiv =
            new ConfigNode<bool>(@"System\Pendenzen\KesFrist\MassnahmePeriode\Aktiv");

        public static readonly ConfigNode<bool> System_Pendenzen_KesFrist_MassnahmeVersandBericht_Aktiv =
            new ConfigNode<bool>(@"System\Pendenzen\KesFrist\MassnahmeVersandBericht\Aktiv");

        public static readonly ConfigNode<int> System_Pendenzen_KesFrist_MassnahmeVersandBericht_AnzahlTage =
            new ConfigNode<int>(@"System\Pendenzen\KesFrist\MassnahmeVersandBericht\AnzahlTage");

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_AdresseHistWebserviceUrl =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\AdresseHistWebserviceURL");

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_AnfrageWebserviceUrl =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\AnfrageWebserviceURL");

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_DeRegistWebserviceUrl =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\DeRegistWebserviceURL");

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_EinwohnerregisterWebservicesPassword =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesPassword");

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_EinwohnerregisterWebservicesProxy =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesProxy");

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_EinwohnerregisterWebservicesUsername =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\EinwohnerregisterWebservicesUsername");

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_KissWebserviceProxy =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\KissWebserviceProxy");

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_KissWebserviceUrl =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\KissWebserviceURL");

        public static readonly ConfigNode<bool> System_Schnittstellen_Einwohnerregister_KissWebserviceValidateCertificate =
            new ConfigNode<bool>(@"System\Schnittstellen\Einwohnerregister\KissWebserviceValidateCertificate", false);

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_RegistWebserviceUrl =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\RegistWebserviceURL");

        public static readonly ConfigNode<string> System_Schnittstellen_Einwohnerregister_SucheWebserviceUrl =
            new ConfigNode<string>(@"System\Schnittstellen\Einwohnerregister\SucheWebserviceURL");

        public static readonly ConfigNode<bool> System_Schnittstellen_Omega_DeleteEventFiles =
            new ConfigNode<bool>(@"System\Schnittstellen\Omega\DeleteEventFiles");

        public static readonly ConfigNode<string> System_Schnittstellen_Omega_FtpPassword =
            new ConfigNode<string>(@"System\Schnittstellen\Omega\FtpPassword");

        public static readonly ConfigNode<string> System_Schnittstellen_Omega_FtpUrl =
            new ConfigNode<string>(@"System\Schnittstellen\Omega\FtpUrl");

        public static readonly ConfigNode<string> System_Schnittstellen_Omega_FtpUser =
            new ConfigNode<string>(@"System\Schnittstellen\Omega\FtpUser");

        public static readonly ConfigNode<decimal> System_Vormundschaft_Klientenbudget_ElFreibetragAlleinstehend =
            new ConfigNode<decimal>(@"System\Vormundschaft\Klientenbudget\ElFreibetragAlleinstehend");

        public static readonly ConfigNode<decimal> System_Vormundschaft_Klientenbudget_ElFreibetragEhepaar =
            new ConfigNode<decimal>(@"System\Vormundschaft\Klientenbudget\ElFreibetragEhepaar");

        public static readonly ConfigNode<decimal> System_Vormundschaft_Klientenbudget_ElFreibetragWaisenKinderMitRentenanspruch =
            new ConfigNode<decimal>(@"System\Vormundschaft\Klientenbudget\ElFreibetragWaisenKinderMitRentenanspruch");

        public static readonly ConfigNode<int> System_Vormundschaft_Klientenbudget_HeimVermoegensverzehrAHV =
            new ConfigNode<int>(@"System\Vormundschaft\Klientenbudget\HeimVermoegensverzehrAHV");

        public static readonly ConfigNode<int> System_Vormundschaft_Klientenbudget_HeimVermoegensverzehrIV =
            new ConfigNode<int>(@"System\Vormundschaft\Klientenbudget\HeimVermoegensverzehrIV");

        public static readonly ConfigNode<int> System_Vormundschaft_Klientenbudget_MieteVermoegensverzehrAHV =
            new ConfigNode<int>(@"System\Vormundschaft\Klientenbudget\MieteVermoegensverzehrAHV");

        public static readonly ConfigNode<int> System_Vormundschaft_Klientenbudget_MieteVermoegensverzehrIV =
            new ConfigNode<int>(@"System\Vormundschaft\Klientenbudget\MieteVermoegensverzehrIV");
    }
}