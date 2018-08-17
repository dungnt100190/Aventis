using System;

namespace KiSS4.Schnittstellen.Abacus.KlientenStammdaten
{
    public static class Constants
    {
        #region Columns as used in dbo.spABAGetKlientenstammdatenData

        #region General

        /// <summary>
        /// Non-databound flag to set do export yes/no
        /// </summary>
        public static String colDoExport = "DoExport";

        /// <summary>
        /// XOrgUnit.Mandantennummer of responsible users' member XOrgUnitID (hierary-value)
        /// </summary>
        public static String colMandantenNummer = "Mandantennummer";

        #endregion

        #region XUser

        /// <summary>
        /// XUser.FirstName of responsible user
        /// </summary>
        public static String colFirstName = "FirstName";

        /// <summary>
        /// XUser.LastName of responsible user
        /// </summary>
        public static String colLastName = "LastName";

        /// <summary>
        /// XUser.MitarbeiterNr of responsible user
        /// </summary>
        public static String colMitarbeiterNr = "MitarbeiterNr";

        /// <summary>
        /// XUser.LastName + XUser.FirstName + XUser.LogonName of responsible user
        /// </summary>
        public static String colSachbearbeiter = "Sachbearbeiter";

        /// <summary>
        /// XUser.UserID of responsible user
        /// </summary>
        public static String colUserID = "UserID";

        #endregion

        #region XOrgUnit

        /// <summary>
        /// XOrgUnit.ItemName of responsible users' member XOrgUnitID
        /// </summary>
        public static String colItemName = "ItemName";

        /// <summary>
        /// XOrgUnit.Kostenstelle of responsible users' member XOrgUnitID
        /// </summary>
        public static String colKostenstelle = "Kostenstelle";

        #endregion

        #region BaPerson

        /// <summary>
        /// BaPerson.BaPersonID
        /// </summary>
        public static String colBaPersonID = "BaPersonID";

        /// <summary>
        /// BaPerson.DebitorUpdate
        /// </summary>
        public static String colDebitorUpdate = "DebitorUpdate";

        /// <summary>
        /// BaPerson.KlientenkontoNr
        /// </summary>
        public static String colKlientenkontoNr = "KlientenkontoNr";

        /// <summary>
        /// BaPerson.KontoFuehrung
        /// </summary>
        public static String colKontoFuehrung = "KontoFuehrung";

        /// <summary>
        /// BaPerson.Name
        /// </summary>
        public static String colName = "Name";

        /// <summary>
        /// BaPerson.WohnsitzPLZ + BaPerson.WohnsitzOrt
        /// </summary>
        public static String colPlzOrt = "PlzOrt";

        /// <summary>
        /// 'Postfach ' + BaPerson.WohnsitzPostfach (if set)
        /// </summary>
        public static String colPostfach = "Postfach";

        /// <summary>
        /// BaPerson.SprachCode as 'D' (default), 'F', 'I', 'E'
        /// </summary>
        public static String colSpracheChar = "SpracheChar";

        /// <summary>
        /// BaPerson.WohnsitzStrasse + BaPerson.WohnsitzHausNr
        /// </summary>
        public static String colStrasseHausNr = "StrasseHausNr";

        /// <summary>
        /// BaPerson.Vorname
        /// </summary>
        public static String colVorname = "Vorname";

        /// <summary>
        /// BaPerson.WohnsitzHausNr
        /// </summary>
        public static String colWohnsitzHausNr = "WohnsitzHausNr";

        /// <summary>
        /// ISO2 from LOV 'BaLand' of BaPerson.WohnsitzLandCode
        /// </summary>
        public static String colWohnsitzLandCodeISO2 = "WohnsitzLandCodeISO2";

        /// <summary>
        /// BaPerson.WohnsitzOrt
        /// </summary>
        public static String colWohnsitzOrt = "WohnsitzOrt";

        /// <summary>
        /// BaPerson.WohnsitzPLZ
        /// </summary>
        public static String colWohnsitzPLZ = "WohnsitzPLZ";

        /// <summary>
        /// BaPerson.WohnsitzStrasse
        /// </summary>
        public static String colWohnsitzStrasse = "WohnsitzStrasse";

        /// <summary>
        /// BaPerson.WohnsitzZusatz
        /// </summary>
        public static String colWohnsitzZusatz = "WohnsitzZusatz";

        #endregion

        #region Additional

        /// <summary>
        /// Status used to set export-result items for dropdown (non-databound)
        /// </summary>
        public static String colStatusExportResult = "StatusExportResult";

        /// <summary>
        /// Flag if BaPerson.KlientenkontoNr is null or not (0=new, 1=update)
        /// </summary>
        public static String colStatusInsUpd = "StatusInsUpd";

        /// <summary>
        /// Static value to set Waehrung for Abacus-Konto
        /// </summary>
        public static String colWaehrung = "Waehrung";

        #endregion

        #endregion

        #region KiSS-Configuration strings

        public static String KissConfig_CompareAccount = @"System\Schnittstellen\Alpi\Klientenstammdaten\CompareAccount";

        public static String KissConfig_CompareAddress = @"System\Schnittstellen\Alpi\Klientenstammdaten\CompareAddress";

        // define constant paths
        public static String KissConfig_DebugFlag = @"System\Schnittstellen\Alpi\Klientenstammdaten\Debug";

        public static String KissConfig_WebServiceSleepTime = @"System\Schnittstellen\Alpi\Klientenstammdaten\WebserviceSleepTime";
        public static String KissConfig_WebServiceUri = @"System\Schnittstellen\Alpi\Klientenstammdaten\WebserviceURI";
        public static String KissConfig_WebServiceUriAddress = @"System\Schnittstellen\Alpi\Klientenstammdaten\WebserviceURI_Address";
        public static String KissConfig_WebServiceUriFibuClassification = @"System\Schnittstellen\Alpi\Klientenstammdaten\WebserviceURI_FibuClassification";

        #endregion
    }
}