using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;
using DevExpress.XtraEditors.Repository;
using Kiss.Interfaces.UI;
using Kiss.Interfaces.ViewModel;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    #region Enumerations

    /// <summary>
    /// Zugriff auf Pendenzenverwaltung
    /// </summary>
    public enum AccessPendenzen
    {
        /// <summary>
        /// Zugriff aus der Fallführung
        /// </summary>
        Leistung,

        /// <summary>
        /// Zugriff aus der Anwendung Pendenzenverwaltung
        /// </summary>
        Verwaltung
    }

    /// <summary>
    /// Art der Buchhaltung.
    /// </summary>
    public enum BuchhaltungsTyp
    {
        /// <summary>
        /// Mandatsbuchhaltung.
        /// </summary>
        Mandatsbuchhaltung,

        /// <summary>
        /// Klientenbuchhaltung.
        /// </summary>
        Klientenbuchhaltung
    }

    /// <summary>
    /// LOV BgEinzahlungsschein
    /// </summary>
    public enum Einzahlungsschein
    {
        /// <summary>
        /// Unbekannt.
        /// </summary>
        Unbekannt,

        /// <summary>
        /// Oranger Einzahlungsschein.
        /// </summary>
        OrangerEinzahlungsschein = 1,

        /// <summary>
        /// Roter Einzahlungsschein Post.
        /// </summary>
        RoterEinzahlungsscheinPost = 2,

        /// <summary>
        /// Bankzahlung Schweiz.
        /// </summary>
        BankzahlungSchweiz = 3,

        /// <summary>
        /// Bankzahlung Ausland.
        /// </summary>
        BankzahlungAusland = 4,

        /// <summary>
        /// Roter Einzahlungsschein Bank.
        /// </summary>
        RoterEinzahlungsscheinBank = 5,

        /// <summary>
        /// Postmandat.
        /// </summary>
        Postmandat = 6
    }

    /// <summary>
    /// LOV FbZahlungsartCode
    /// </summary>
    public enum ZahlungsArt
    {
        /// <summary>
        /// Unbekannte Zahlungsart
        /// </summary>
        Unbekannt,

        /// <summary>
        /// Oranger Einzahlungsschein
        /// </summary>
        OrangerEinzahlungsschein = 1,

        /// <summary>
        /// Blau/Orange ESR über Bank (inaktiv)
        /// </summary>
        Blau_Orange_ESR_ueber_Bank = 2,

        /// <summary>
        /// Roter Einzahlungsschein Post
        /// </summary>
        RoterEinzahlungsscheinPost = 3,

        /// <summary>
        /// Bankzahlung Schweiz
        /// </summary>
        BankzahlungSchweiz = 4,

        /// <summary>
        /// Bank Überweisung (inaktiv)
        /// </summary>
        BankUeberweisung = 5,

        /// <summary>
        /// Postmandat
        /// </summary>
        Postmandat = 6,
    }

    #endregion Enumerations

    /// <summary>
    /// Class contains common used helper methods
    /// </summary>
    public class Utils
    {
        #region Fields

        #region Private Static Fields

        // The hashtable with the values for the AHV-Nr.
        private static Hashtable htAHVNr = null;

        /// <summary>
        /// Regular Expression for alphanumeric values.
        /// </summary>
        private static Regex isAlpha = new Regex(@"\A\D*\z");

        /// <summary>
        /// Regular Expression for decimal values.
        /// </summary>
        private static Regex isDecimal = new Regex(@"^(\+|-)?\d+(\.\d*)?$");

        /// <summary>
        /// Regular Expression for natural values..
        /// </summary>
        private static Regex isNatural = new Regex(@"^\d+$");

        /// <summary>
        /// Regular Expression for numeric values..
        /// </summary>
        private static Regex isNumeric = new Regex(@"^(\+|-)?\d+$");

        private static ArrayList lstAHVNrNames = null;

        #endregion Private Static Fields

        #region Private Constant/Read-Only Fields

        private const string CLASSNAME = "CommonUtils";
        private const string IBANKERNELDLL_UPDATE_DEFAULTLINK = @"http://www.six-interbank-clearing.com/dam/downloads/en/standardization/iban/tool/ibantool_windows.zip";
        private const string IBANKERNELDLL_UPDATE_LINKNAME = "IBANKernelDllUpdate";

        #endregion Private Constant/Read-Only Fields

        #endregion Fields

        #region Properties

        /// <summary>
        /// Get MainVersion information of KiSS as Major.Minor.Build
        /// </summary>
        public static string MainVersion
        {
            get
            {
                // create version information from assemblyversion
                System.Version ver = new System.Version(BIAG.AssemblyInfo.GlobalAssemblyInfo.AssemblyVersion);

                // get major.minor.build from assembly version
                return string.Format("{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build);
            }
        }

        /// <summary>
        /// Get revision information of KiSS as Major.Minor.Build.Revision
        /// </summary>
        public static string RevisionVersion
        {
            get
            {
                // create version information from assemblyversion
                System.Version ver = new System.Version(BIAG.AssemblyInfo.GlobalAssemblyInfo.AssemblyVersion);

                // get major.minor.build.revision from assembly version
                return string.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
            }
        }

        #endregion Properties

        #region EventHandlers

        /// <summary>
        /// Defaul Money Rounding for Switzerland
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <returns>Rounded Value</returns>
        public static Decimal RoundMoney_CH(Decimal value)
        {
            return Kiss.Infrastructure.Utils.Utils.RoundMoney_CH(value);
        }

        /// <summary>
        /// Money Rounding allways rounding up to the next unit
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <param name="smallestUnit">smallest unit used for rounding</param>
        /// <returns>Rounded Value</returns>
        public static Decimal RoundMoney_Up(Decimal value, Decimal smallestUnit)
        {
            return Kiss.Infrastructure.Utils.Utils.RoundMoney_Up(value, smallestUnit);
        }

        #endregion EventHandlers

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Get all controls including controls of child-controls (recursive)
        /// </summary>
        /// <param name="ParentControl">The control to get child-controls from</param>
        /// <returns>All controls found within the ParentControl</returns>
        [Obsolete("Use KiSS4.Gui.UtilsGui.AllControls instead")]
        public static ArrayList AllControls(Control ParentControl)
        {
            return Gui.UtilsGui.AllControls(ParentControl);
        }

        /// <summary>
        /// Überprüft ob das Token im AppCode enthalten ist.
        /// </summary>
        /// <param name="AppCode">The app code.</param>
        /// <param name="Token">The token.</param>
        /// <returns></returns>
        public static bool AppCodeContainsToken(object AppCode, string Token)
        {
            if (AppCode == null || Token == null)
            {
                return false;
            }

            return AppCode.ToString().ToUpper().IndexOf('[' + Token.ToUpper() + ']') != -1;
        }

        /// <summary>
        /// Assigns Pendenzen of chosen Leistungen and old receiver to a new receiver
        /// </summary>
        /// <param name="newReceiver">New receiver</param>
        /// <param name="oldReceiver">Former receiver</param>
        /// <param name="csvFaLeistungIds">CSV List of identification numbers for Leistungen. These Leistungen must belong to the same User.</param>
        /// <returns>The number of updated rows in the database</returns>
        public static int AssignPendingTasksToNewReceiver(int newReceiver, int oldReceiver, string csvFaLeistungIds)
        {
            object result = 0;

            if (newReceiver > 0 && !string.IsNullOrEmpty(csvFaLeistungIds))
            {
                result = DBUtil.ExecuteScalarSQL(string.Format(@"
                    UPDATE TSK
                        SET TSK.ReceiverID = {0}
                    FROM dbo.XTask TSK
                    WHERE TSK.TaskStatusCode IN (1, 2, 4)
                        AND TSK.ReceiverID = {1}
                        AND TSK.FaLeistungID IN ({2})
                    SELECT ISNULL(@@ROWCOUNT, 0)", newReceiver, oldReceiver, csvFaLeistungIds));
            }

            return Convert.ToInt32(result);
        }

        /// <summary>
        /// Get AHV-Nr as "aaa.yy.bbb.xxx" from values
        /// </summary>
        /// <param name="lastName">The lastname of the person</param>
        /// <param name="genderCode">The gender code of the person (1=male, 2=female)</param>
        /// <param name="birthday">The birthday of the person</param>
        /// <returns>Calculated first three values of AHV-Nr or null if something missing</returns>
        /// <remarks>See: http://www.zudila.ch/scripte/php_ahv_nr_function_anz.php</remarks>
        public static string CalcAHVNr(string lastName, int genderCode, DateTime birthday)
        {
            try
            {
                #region Validate

                // validate values
                if (DBUtil.IsEmpty(lastName) || DBUtil.IsEmpty(genderCode) || DBUtil.IsEmpty(birthday))
                {
                    // empty value(s)
                    return null;
                }
                if (genderCode < 1 || genderCode > 2)
                {
                    // invalid gender
                    return null;
                }

                #endregion Validate

                #region Init Hashtable

                // init hashtable
                if (htAHVNr == null || lstAHVNrNames == null)
                {
                    // create a new instance
                    htAHVNr = new Hashtable();

                    // add values

                    #region Values

                    htAHVNr.Add("a", 100);
                    htAHVNr.Add("abi", 101);
                    htAHVNr.Add("abl", 102);
                    htAHVNr.Add("ac", 103);
                    htAHVNr.Add("af", 104);
                    htAHVNr.Add("ag", 105);
                    htAHVNr.Add("al", 106);
                    htAHVNr.Add("ald", 107);
                    htAHVNr.Add("all", 108);
                    htAHVNr.Add("alm", 109);
                    htAHVNr.Add("am", 110);
                    htAHVNr.Add("amd", 111);
                    htAHVNr.Add("amm", 112);
                    htAHVNr.Add("amo", 113);
                    htAHVNr.Add("ams", 114);
                    htAHVNr.Add("an", 115);
                    htAHVNr.Add("ando", 116);
                    htAHVNr.Add("ane", 117);
                    htAHVNr.Add("ann", 118);
                    htAHVNr.Add("ao", 119);
                    htAHVNr.Add("ar", 120);
                    htAHVNr.Add("arno", 121);
                    htAHVNr.Add("aro", 122);
                    htAHVNr.Add("as", 123);
                    htAHVNr.Add("au", 124);
                    htAHVNr.Add("b", 125);
                    htAHVNr.Add("bach", 126);
                    htAHVNr.Add("bachm", 127);
                    htAHVNr.Add("bad", 128);
                    htAHVNr.Add("bag", 129);
                    htAHVNr.Add("bal", 130);
                    htAHVNr.Add("ball", 131);
                    htAHVNr.Add("balm", 132);
                    htAHVNr.Add("bals", 133);
                    htAHVNr.Add("bam", 134);
                    htAHVNr.Add("ban", 135);
                    htAHVNr.Add("bar", 136);
                    htAHVNr.Add("barc", 137);
                    htAHVNr.Add("barm", 138);
                    htAHVNr.Add("bart", 139);
                    htAHVNr.Add("bas", 140);
                    htAHVNr.Add("bat", 141);
                    htAHVNr.Add("bau", 142);
                    htAHVNr.Add("baue", 143);
                    htAHVNr.Add("baum", 144);
                    htAHVNr.Add("baumb", 145);
                    htAHVNr.Add("baumg", 146);
                    htAHVNr.Add("baun", 147);
                    htAHVNr.Add("bav", 148);
                    htAHVNr.Add("bay", 149);
                    htAHVNr.Add("be", 150);
                    htAHVNr.Add("bed", 151);
                    htAHVNr.Add("bef", 152);
                    htAHVNr.Add("bel", 153);
                    htAHVNr.Add("ben", 154);
                    htAHVNr.Add("ber", 155);
                    htAHVNr.Add("berg", 156);
                    htAHVNr.Add("berh", 157);
                    htAHVNr.Add("bern", 158);
                    htAHVNr.Add("berne", 159);
                    htAHVNr.Add("bero", 160);
                    htAHVNr.Add("bert", 161);
                    htAHVNr.Add("bes", 162);
                    htAHVNr.Add("beu", 163);
                    htAHVNr.Add("bf", 164);
                    htAHVNr.Add("bi", 165);
                    htAHVNr.Add("bie", 166);
                    htAHVNr.Add("bier", 167);
                    htAHVNr.Add("bif", 168);
                    htAHVNr.Add("bil", 169);
                    htAHVNr.Add("bin", 170);
                    htAHVNr.Add("bio", 171);
                    htAHVNr.Add("bis", 172);
                    htAHVNr.Add("bise", 173);
                    htAHVNr.Add("bit", 174);
                    htAHVNr.Add("bl", 175);
                    htAHVNr.Add("blas", 176);
                    htAHVNr.Add("blat", 177);
                    htAHVNr.Add("ble", 178);
                    htAHVNr.Add("blu", 179);
                    htAHVNr.Add("bo", 180);
                    htAHVNr.Add("bod", 181);
                    htAHVNr.Add("bof", 182);
                    htAHVNr.Add("boh", 183);
                    htAHVNr.Add("boi", 184);
                    htAHVNr.Add("bol", 185);
                    htAHVNr.Add("boll", 186);
                    htAHVNr.Add("bolli", 187);
                    htAHVNr.Add("bolm", 188);
                    htAHVNr.Add("bom", 189);
                    htAHVNr.Add("bon", 190);
                    htAHVNr.Add("boo", 191);
                    htAHVNr.Add("bor", 192);
                    htAHVNr.Add("borg", 193);
                    htAHVNr.Add("born", 194);
                    htAHVNr.Add("bos", 195);
                    htAHVNr.Add("boss", 196);
                    htAHVNr.Add("bossh", 197);
                    htAHVNr.Add("bot", 198);
                    htAHVNr.Add("bov", 199);
                    htAHVNr.Add("br", 200);
                    htAHVNr.Add("brag", 201);
                    htAHVNr.Add("bran", 202);
                    htAHVNr.Add("brap", 203);
                    htAHVNr.Add("brau", 204);
                    htAHVNr.Add("bre", 205);
                    htAHVNr.Add("breg", 206);
                    htAHVNr.Add("brel", 207);
                    htAHVNr.Add("bres", 208);
                    htAHVNr.Add("bri", 209);
                    htAHVNr.Add("bro", 210);
                    htAHVNr.Add("brof", 211);
                    htAHVNr.Add("bron", 212);
                    htAHVNr.Add("bronn", 213);
                    htAHVNr.Add("broo", 214);
                    htAHVNr.Add("bru", 215);
                    htAHVNr.Add("brud", 216);
                    htAHVNr.Add("brug", 217);
                    htAHVNr.Add("bruh", 218);
                    htAHVNr.Add("brul", 219);
                    htAHVNr.Add("brun", 220);
                    htAHVNr.Add("brund", 221);
                    htAHVNr.Add("brunn", 222);
                    htAHVNr.Add("bruno", 223);
                    htAHVNr.Add("bruo", 224);
                    htAHVNr.Add("bu", 225);
                    htAHVNr.Add("buch", 226);
                    htAHVNr.Add("buchi", 227);
                    htAHVNr.Add("bucho", 228);
                    htAHVNr.Add("buci", 229);
                    htAHVNr.Add("bud", 230);
                    htAHVNr.Add("buh", 231);
                    htAHVNr.Add("buhlm", 232);
                    htAHVNr.Add("buhm", 233);
                    htAHVNr.Add("bui", 234);
                    htAHVNr.Add("bur", 235);
                    htAHVNr.Add("burg", 236);
                    htAHVNr.Add("burgi", 237);
                    htAHVNr.Add("burh", 238);
                    htAHVNr.Add("burk", 239);
                    htAHVNr.Add("burkh", 240);
                    htAHVNr.Add("burki", 241);
                    htAHVNr.Add("burl", 242);
                    htAHVNr.Add("burr", 243);
                    htAHVNr.Add("burs", 244);
                    htAHVNr.Add("bus", 245);
                    htAHVNr.Add("buss", 246);
                    htAHVNr.Add("but", 247);
                    htAHVNr.Add("butt", 248);
                    htAHVNr.Add("by", 249);
                    htAHVNr.Add("c", 250);
                    htAHVNr.Add("cai", 251);
                    htAHVNr.Add("cam", 252);
                    htAHVNr.Add("can", 253);
                    htAHVNr.Add("car", 254);
                    htAHVNr.Add("cas", 255);
                    htAHVNr.Add("cast", 256);
                    htAHVNr.Add("cat", 257);
                    htAHVNr.Add("cav", 258);
                    htAHVNr.Add("ce", 259);
                    htAHVNr.Add("ch", 260);
                    htAHVNr.Add("char", 261);
                    htAHVNr.Add("che", 262);
                    htAHVNr.Add("chi", 263);
                    htAHVNr.Add("chr", 264);
                    htAHVNr.Add("ci", 265);
                    htAHVNr.Add("cl", 266);
                    htAHVNr.Add("co", 267);
                    htAHVNr.Add("com", 268);
                    htAHVNr.Add("cor", 269);
                    htAHVNr.Add("corn", 270);
                    htAHVNr.Add("cos", 271);
                    htAHVNr.Add("cr", 272);
                    htAHVNr.Add("cri", 273);
                    htAHVNr.Add("cu", 274);
                    htAHVNr.Add("d", 275);
                    htAHVNr.Add("dam", 276);
                    htAHVNr.Add("das", 277);
                    htAHVNr.Add("de", 278);
                    htAHVNr.Add("deg", 279);
                    htAHVNr.Add("del", 280);
                    htAHVNr.Add("dem", 281);
                    htAHVNr.Add("dep", 282);
                    htAHVNr.Add("des", 283);
                    htAHVNr.Add("det", 284);
                    htAHVNr.Add("di", 285);
                    htAHVNr.Add("die", 286);
                    htAHVNr.Add("dig", 287);
                    htAHVNr.Add("do", 288);
                    htAHVNr.Add("dor", 289);
                    htAHVNr.Add("dr", 290);
                    htAHVNr.Add("du", 291);
                    htAHVNr.Add("dub", 292);
                    htAHVNr.Add("duc", 293);
                    htAHVNr.Add("dud", 294);
                    htAHVNr.Add("dum", 295);
                    htAHVNr.Add("dup", 296);
                    htAHVNr.Add("dur", 297);
                    htAHVNr.Add("dus", 298);
                    htAHVNr.Add("duv", 299);
                    htAHVNr.Add("e", 300);
                    htAHVNr.Add("ebi", 301);
                    htAHVNr.Add("ec", 302);
                    htAHVNr.Add("eg", 303);
                    htAHVNr.Add("eggen", 304);
                    htAHVNr.Add("egger", 305);
                    htAHVNr.Add("eggf", 306);
                    htAHVNr.Add("egh", 307);
                    htAHVNr.Add("eh", 308);
                    htAHVNr.Add("ehre", 309);
                    htAHVNr.Add("ei", 310);
                    htAHVNr.Add("eichf", 311);
                    htAHVNr.Add("eid", 312);
                    htAHVNr.Add("ein", 313);
                    htAHVNr.Add("ek", 314);
                    htAHVNr.Add("em", 315);
                    htAHVNr.Add("en", 316);
                    htAHVNr.Add("eng", 317);
                    htAHVNr.Add("eni", 318);
                    htAHVNr.Add("eo", 319);
                    htAHVNr.Add("er", 320);
                    htAHVNr.Add("ern", 321);
                    htAHVNr.Add("es", 322);
                    htAHVNr.Add("et", 323);
                    htAHVNr.Add("eu", 324);
                    htAHVNr.Add("f", 325);
                    htAHVNr.Add("fah", 326);
                    htAHVNr.Add("fai", 327);
                    htAHVNr.Add("fan", 328);
                    htAHVNr.Add("far", 329);
                    htAHVNr.Add("fas", 330);
                    htAHVNr.Add("fass", 331);
                    htAHVNr.Add("fat", 332);
                    htAHVNr.Add("fav", 333);
                    htAHVNr.Add("faw", 334);
                    htAHVNr.Add("fe", 335);
                    htAHVNr.Add("fel", 336);
                    htAHVNr.Add("feli", 337);
                    htAHVNr.Add("fem", 338);
                    htAHVNr.Add("fet", 339);
                    htAHVNr.Add("fi", 340);
                    htAHVNr.Add("fin", 341);
                    htAHVNr.Add("fisch", 342);
                    htAHVNr.Add("fisd", 343);
                    htAHVNr.Add("fit", 344);
                    htAHVNr.Add("fl", 345);
                    htAHVNr.Add("fle", 346);
                    htAHVNr.Add("fli", 347);
                    htAHVNr.Add("flu", 348);
                    htAHVNr.Add("flud", 349);
                    htAHVNr.Add("fo", 350);
                    htAHVNr.Add("fon", 351);
                    htAHVNr.Add("for", 352);
                    htAHVNr.Add("forr", 353);
                    htAHVNr.Add("fos", 354);
                    htAHVNr.Add("fr", 355);
                    htAHVNr.Add("fran", 356);
                    htAHVNr.Add("frap", 357);
                    htAHVNr.Add("fre", 358);
                    htAHVNr.Add("frei", 359);
                    htAHVNr.Add("frek", 360);
                    htAHVNr.Add("frey", 361);
                    htAHVNr.Add("fri", 362);
                    htAHVNr.Add("frie", 363);
                    htAHVNr.Add("frif", 364);
                    htAHVNr.Add("fris", 365);
                    htAHVNr.Add("frit", 366);
                    htAHVNr.Add("fro", 367);
                    htAHVNr.Add("froi", 368);
                    htAHVNr.Add("fru", 369);
                    htAHVNr.Add("fu", 370);
                    htAHVNr.Add("fud", 371);
                    htAHVNr.Add("fui", 372);
                    htAHVNr.Add("fur", 373);
                    htAHVNr.Add("fus", 374);
                    htAHVNr.Add("g", 375);
                    htAHVNr.Add("gaf", 376);
                    htAHVNr.Add("gal", 377);
                    htAHVNr.Add("gam", 378);
                    htAHVNr.Add("gan", 379);
                    htAHVNr.Add("gap", 380);
                    htAHVNr.Add("gas", 381);
                    htAHVNr.Add("gass", 382);
                    htAHVNr.Add("gat", 383);
                    htAHVNr.Add("gav", 384);
                    htAHVNr.Add("ge", 385);
                    htAHVNr.Add("geh", 386);
                    htAHVNr.Add("gei", 387);
                    htAHVNr.Add("gel", 388);
                    htAHVNr.Add("geo", 389);
                    htAHVNr.Add("ger", 390);
                    htAHVNr.Add("gerd", 391);
                    htAHVNr.Add("ges", 392);
                    htAHVNr.Add("gf", 393);
                    htAHVNr.Add("gi", 394);
                    htAHVNr.Add("gig", 395);
                    htAHVNr.Add("gil", 396);
                    htAHVNr.Add("gim", 397);
                    htAHVNr.Add("gir", 398);
                    htAHVNr.Add("gis", 399);
                    htAHVNr.Add("gl", 400);
                    htAHVNr.Add("gle", 401);
                    htAHVNr.Add("gn", 402);
                    htAHVNr.Add("go", 403);
                    htAHVNr.Add("gom", 404);
                    htAHVNr.Add("gr", 405);
                    htAHVNr.Add("graf", 406);
                    htAHVNr.Add("grag", 407);
                    htAHVNr.Add("gre", 408);
                    htAHVNr.Add("gres", 409);
                    htAHVNr.Add("gri", 410);
                    htAHVNr.Add("grim", 411);
                    htAHVNr.Add("gro", 412);
                    htAHVNr.Add("gros", 413);
                    htAHVNr.Add("grot", 414);
                    htAHVNr.Add("gru", 415);
                    htAHVNr.Add("grup", 416);
                    htAHVNr.Add("gs", 417);
                    htAHVNr.Add("gu", 418);
                    htAHVNr.Add("gud", 419);
                    htAHVNr.Add("gug", 420);
                    htAHVNr.Add("gui", 421);
                    htAHVNr.Add("gun", 422);
                    htAHVNr.Add("gut", 423);
                    htAHVNr.Add("gw", 424);
                    htAHVNr.Add("h", 425);
                    htAHVNr.Add("hab", 426);
                    htAHVNr.Add("habi", 427);
                    htAHVNr.Add("hac", 428);
                    htAHVNr.Add("had", 429);
                    htAHVNr.Add("haf", 430);
                    htAHVNr.Add("hafl", 431);
                    htAHVNr.Add("hafn", 432);
                    htAHVNr.Add("hag", 433);
                    htAHVNr.Add("hah", 434);
                    htAHVNr.Add("hal", 435);
                    htAHVNr.Add("hall", 436);
                    htAHVNr.Add("ham", 437);
                    htAHVNr.Add("han", 438);
                    htAHVNr.Add("hann", 439);
                    htAHVNr.Add("hao", 440);
                    htAHVNr.Add("har", 441);
                    htAHVNr.Add("hart", 442);
                    htAHVNr.Add("has", 443);
                    htAHVNr.Add("hat", 444);
                    htAHVNr.Add("hau", 445);
                    htAHVNr.Add("haus", 446);
                    htAHVNr.Add("hausf", 447);
                    htAHVNr.Add("haut", 448);
                    htAHVNr.Add("hav", 449);
                    htAHVNr.Add("he", 450);
                    htAHVNr.Add("hee", 451);
                    htAHVNr.Add("heg", 452);
                    htAHVNr.Add("hei", 453);
                    htAHVNr.Add("hein", 454);
                    htAHVNr.Add("hel", 455);
                    htAHVNr.Add("helf", 456);
                    htAHVNr.Add("hell", 457);
                    htAHVNr.Add("hem", 458);
                    htAHVNr.Add("hen", 459);
                    htAHVNr.Add("heng", 460);
                    htAHVNr.Add("heno", 461);
                    htAHVNr.Add("heo", 462);
                    htAHVNr.Add("her", 463);
                    htAHVNr.Add("herm", 464);
                    htAHVNr.Add("herr", 465);
                    htAHVNr.Add("hers", 466);
                    htAHVNr.Add("herz", 467);
                    htAHVNr.Add("hes", 468);
                    htAHVNr.Add("het", 469);
                    htAHVNr.Add("hi", 470);
                    htAHVNr.Add("him", 471);
                    htAHVNr.Add("hir", 472);
                    htAHVNr.Add("hirt", 473);
                    htAHVNr.Add("his", 474);
                    htAHVNr.Add("ho", 475);
                    htAHVNr.Add("hof", 476);
                    htAHVNr.Add("hofl", 477);
                    htAHVNr.Add("hofm", 478);
                    htAHVNr.Add("hofn", 479);
                    htAHVNr.Add("hog", 480);
                    htAHVNr.Add("hol", 481);
                    htAHVNr.Add("hom", 482);
                    htAHVNr.Add("hor", 483);
                    htAHVNr.Add("hot", 484);
                    htAHVNr.Add("hu", 485);
                    htAHVNr.Add("hubf", 486);
                    htAHVNr.Add("huc", 487);
                    htAHVNr.Add("hug", 488);
                    htAHVNr.Add("hugi", 489);
                    htAHVNr.Add("huh", 490);
                    htAHVNr.Add("hun", 491);
                    htAHVNr.Add("huni", 492);
                    htAHVNr.Add("hunz", 493);
                    htAHVNr.Add("huo", 494);
                    htAHVNr.Add("hur", 495);
                    htAHVNr.Add("hurn", 496);
                    htAHVNr.Add("hus", 497);
                    htAHVNr.Add("hut", 498);
                    htAHVNr.Add("huw", 499);
                    htAHVNr.Add("i", 500);
                    htAHVNr.Add("im", 501);
                    htAHVNr.Add("in", 502);
                    htAHVNr.Add("is", 503);
                    htAHVNr.Add("it", 504);
                    htAHVNr.Add("j", 505);
                    htAHVNr.Add("jad", 506);
                    htAHVNr.Add("jah", 507);
                    htAHVNr.Add("jan", 508);
                    htAHVNr.Add("jar", 509);
                    htAHVNr.Add("je", 510);
                    htAHVNr.Add("jec", 511);
                    htAHVNr.Add("jeh", 512);
                    htAHVNr.Add("jen", 513);
                    htAHVNr.Add("jep", 514);
                    htAHVNr.Add("jo", 515);
                    htAHVNr.Add("jol", 516);
                    htAHVNr.Add("jor", 517);
                    htAHVNr.Add("jos", 518);
                    htAHVNr.Add("jot", 519);
                    htAHVNr.Add("ju", 520);
                    htAHVNr.Add("juf", 521);
                    htAHVNr.Add("jun", 522);
                    htAHVNr.Add("junk", 523);
                    htAHVNr.Add("juo", 524);
                    htAHVNr.Add("k", 525);
                    htAHVNr.Add("kah", 526);
                    htAHVNr.Add("kal", 527);
                    htAHVNr.Add("kam", 528);
                    htAHVNr.Add("kan", 529);
                    htAHVNr.Add("kar", 530);
                    htAHVNr.Add("kas", 531);
                    htAHVNr.Add("kasp", 532);
                    htAHVNr.Add("kat", 533);
                    htAHVNr.Add("kau", 534);
                    htAHVNr.Add("ke", 535);
                    htAHVNr.Add("kel", 536);
                    htAHVNr.Add("kem", 537);
                    htAHVNr.Add("kes", 538);
                    htAHVNr.Add("ket", 539);
                    htAHVNr.Add("ki", 540);
                    htAHVNr.Add("kif", 541);
                    htAHVNr.Add("kim", 542);
                    htAHVNr.Add("kir", 543);
                    htAHVNr.Add("kis", 544);
                    htAHVNr.Add("kl", 545);
                    htAHVNr.Add("kle", 546);
                    htAHVNr.Add("kli", 547);
                    htAHVNr.Add("kn", 548);
                    htAHVNr.Add("kno", 549);
                    htAHVNr.Add("ko", 550);
                    htAHVNr.Add("koc", 551);
                    htAHVNr.Add("kod", 552);
                    htAHVNr.Add("koh", 553);
                    htAHVNr.Add("kol", 554);
                    htAHVNr.Add("koll", 555);
                    htAHVNr.Add("kom", 556);
                    htAHVNr.Add("kop", 557);
                    htAHVNr.Add("kor", 558);
                    htAHVNr.Add("kot", 559);
                    htAHVNr.Add("kr", 560);
                    htAHVNr.Add("krap", 561);
                    htAHVNr.Add("kre", 562);
                    htAHVNr.Add("kri", 563);
                    htAHVNr.Add("kru", 564);
                    htAHVNr.Add("ku", 565);
                    htAHVNr.Add("kuc", 566);
                    htAHVNr.Add("kuh", 567);
                    htAHVNr.Add("kui", 568);
                    htAHVNr.Add("kun", 569);
                    htAHVNr.Add("kunz", 570);
                    htAHVNr.Add("kunzi", 571);
                    htAHVNr.Add("kuo", 572);
                    htAHVNr.Add("kur", 573);
                    htAHVNr.Add("kus", 574);
                    htAHVNr.Add("l", 575);
                    htAHVNr.Add("laf", 576);
                    htAHVNr.Add("lan", 577);
                    htAHVNr.Add("lang", 578);
                    htAHVNr.Add("lanh", 579);
                    htAHVNr.Add("lao", 580);
                    htAHVNr.Add("lat", 581);
                    htAHVNr.Add("lau", 582);
                    htAHVNr.Add("laud", 583);
                    htAHVNr.Add("lav", 584);
                    htAHVNr.Add("le", 585);
                    htAHVNr.Add("led", 586);
                    htAHVNr.Add("lee", 587);
                    htAHVNr.Add("leh", 588);
                    htAHVNr.Add("lehn", 589);
                    htAHVNr.Add("lei", 590);
                    htAHVNr.Add("leip", 591);
                    htAHVNr.Add("lek", 592);
                    htAHVNr.Add("leo", 593);
                    htAHVNr.Add("ler", 594);
                    htAHVNr.Add("leu", 595);
                    htAHVNr.Add("leue", 596);
                    htAHVNr.Add("leuf", 597);
                    htAHVNr.Add("leut", 598);
                    htAHVNr.Add("lev", 599);
                    htAHVNr.Add("li", 600);
                    htAHVNr.Add("lie", 601);
                    htAHVNr.Add("liec", 602);
                    htAHVNr.Add("lied", 603);
                    htAHVNr.Add("lif", 604);
                    htAHVNr.Add("lin", 605);
                    htAHVNr.Add("lind", 606);
                    htAHVNr.Add("line", 607);
                    htAHVNr.Add("lio", 608);
                    htAHVNr.Add("lis", 609);
                    htAHVNr.Add("lo", 610);
                    htAHVNr.Add("lof", 611);
                    htAHVNr.Add("loo", 612);
                    htAHVNr.Add("lor", 613);
                    htAHVNr.Add("lot", 614);
                    htAHVNr.Add("lu", 615);
                    htAHVNr.Add("lud", 616);
                    htAHVNr.Add("lug", 617);
                    htAHVNr.Add("lui", 618);
                    htAHVNr.Add("lus", 619);
                    htAHVNr.Add("lut", 620);
                    htAHVNr.Add("luth", 621);
                    htAHVNr.Add("luti", 622);
                    htAHVNr.Add("luu", 623);
                    htAHVNr.Add("ly", 624);
                    htAHVNr.Add("m", 625);
                    htAHVNr.Add("mad", 626);
                    htAHVNr.Add("mag", 627);
                    htAHVNr.Add("mai", 628);
                    htAHVNr.Add("mak", 629);
                    htAHVNr.Add("mar", 630);
                    htAHVNr.Add("marg", 631);
                    htAHVNr.Add("mart", 632);
                    htAHVNr.Add("martin", 633);
                    htAHVNr.Add("maru", 634);
                    htAHVNr.Add("mas", 635);
                    htAHVNr.Add("mat", 636);
                    htAHVNr.Add("matt", 637);
                    htAHVNr.Add("mau", 638);
                    htAHVNr.Add("may", 639);
                    htAHVNr.Add("me", 640);
                    htAHVNr.Add("meier", 641);
                    htAHVNr.Add("meif", 642);
                    htAHVNr.Add("mek", 643);
                    htAHVNr.Add("mer", 644);
                    htAHVNr.Add("mes", 645);
                    htAHVNr.Add("met", 646);
                    htAHVNr.Add("mey", 647);
                    htAHVNr.Add("meyer", 648);
                    htAHVNr.Add("meyf", 649);
                    htAHVNr.Add("mi", 650);
                    htAHVNr.Add("mic", 651);
                    htAHVNr.Add("mid", 652);
                    htAHVNr.Add("min", 653);
                    htAHVNr.Add("mir", 654);
                    htAHVNr.Add("mo", 655);
                    htAHVNr.Add("moi", 656);
                    htAHVNr.Add("mon", 657);
                    htAHVNr.Add("monn", 658);
                    htAHVNr.Add("mono", 659);
                    htAHVNr.Add("moo", 660);
                    htAHVNr.Add("mor", 661);
                    htAHVNr.Add("more", 662);
                    htAHVNr.Add("morg", 663);
                    htAHVNr.Add("mos", 664);
                    htAHVNr.Add("mose", 665);
                    htAHVNr.Add("mosi", 666);
                    htAHVNr.Add("mot", 667);
                    htAHVNr.Add("mu", 668);
                    htAHVNr.Add("muh", 669);
                    htAHVNr.Add("mul", 670);
                    htAHVNr.Add("mull", 671);
                    htAHVNr.Add("mum", 672);
                    htAHVNr.Add("mur", 673);
                    htAHVNr.Add("mus", 674);
                    htAHVNr.Add("n", 675);
                    htAHVNr.Add("nag", 676);
                    htAHVNr.Add("ne", 677);
                    htAHVNr.Add("neg", 678);
                    htAHVNr.Add("neu", 679);
                    htAHVNr.Add("ni", 680);
                    htAHVNr.Add("nie", 681);
                    htAHVNr.Add("niederg", 682);
                    htAHVNr.Add("nief", 683);
                    htAHVNr.Add("nif", 684);
                    htAHVNr.Add("no", 685);
                    htAHVNr.Add("not", 686);
                    htAHVNr.Add("nu", 687);
                    htAHVNr.Add("ny", 688);
                    htAHVNr.Add("nyf", 689);
                    htAHVNr.Add("o", 690);
                    htAHVNr.Add("obi", 691);
                    htAHVNr.Add("oc", 692);
                    htAHVNr.Add("od", 693);
                    htAHVNr.Add("of", 694);
                    htAHVNr.Add("ok", 695);
                    htAHVNr.Add("op", 696);
                    htAHVNr.Add("os", 697);
                    htAHVNr.Add("ot", 698);
                    htAHVNr.Add("ou", 699);
                    htAHVNr.Add("p", 700);
                    htAHVNr.Add("pag", 701);
                    htAHVNr.Add("pan", 702);
                    htAHVNr.Add("par", 703);
                    htAHVNr.Add("pat", 704);
                    htAHVNr.Add("pe", 705);
                    htAHVNr.Add("pel", 706);
                    htAHVNr.Add("per", 707);
                    htAHVNr.Add("perri", 708);
                    htAHVNr.Add("pers", 709);
                    htAHVNr.Add("pes", 710);
                    htAHVNr.Add("pet", 711);
                    htAHVNr.Add("peu", 712);
                    htAHVNr.Add("pf", 713);
                    htAHVNr.Add("pfi", 714);
                    htAHVNr.Add("ph", 715);
                    htAHVNr.Add("pi", 716);
                    htAHVNr.Add("pig", 717);
                    htAHVNr.Add("pir", 718);
                    htAHVNr.Add("pl", 719);
                    htAHVNr.Add("po", 720);
                    htAHVNr.Add("por", 721);
                    htAHVNr.Add("pr", 722);
                    htAHVNr.Add("pu", 723);
                    htAHVNr.Add("q", 724);
                    htAHVNr.Add("r", 725);
                    htAHVNr.Add("ram", 726);
                    htAHVNr.Add("ran", 727);
                    htAHVNr.Add("ras", 728);
                    htAHVNr.Add("rau", 729);
                    htAHVNr.Add("re", 730);
                    htAHVNr.Add("rec", 731);
                    htAHVNr.Add("rei", 732);
                    htAHVNr.Add("rein", 733);
                    htAHVNr.Add("rek", 734);
                    htAHVNr.Add("ren", 735);
                    htAHVNr.Add("reni", 736);
                    htAHVNr.Add("reo", 737);
                    htAHVNr.Add("rey", 738);
                    htAHVNr.Add("rh", 739);
                    htAHVNr.Add("ri", 740);
                    htAHVNr.Add("ric", 741);
                    htAHVNr.Add("rid", 742);
                    htAHVNr.Add("rie", 743);
                    htAHVNr.Add("rieg", 744);
                    htAHVNr.Add("rif", 745);
                    htAHVNr.Add("rin", 746);
                    htAHVNr.Add("rio", 747);
                    htAHVNr.Add("rit", 748);
                    htAHVNr.Add("riv", 749);
                    htAHVNr.Add("ro", 750);
                    htAHVNr.Add("roc", 751);
                    htAHVNr.Add("rod", 752);
                    htAHVNr.Add("roh", 753);
                    htAHVNr.Add("rohr", 754);
                    htAHVNr.Add("roi", 755);
                    htAHVNr.Add("rom", 756);
                    htAHVNr.Add("roo", 757);
                    htAHVNr.Add("ros", 758);
                    htAHVNr.Add("ross", 759);
                    htAHVNr.Add("rot", 760);
                    htAHVNr.Add("roth", 761);
                    htAHVNr.Add("rotha", 762);
                    htAHVNr.Add("roti", 763);
                    htAHVNr.Add("rou", 764);
                    htAHVNr.Add("ru", 765);
                    htAHVNr.Add("ruc", 766);
                    htAHVNr.Add("rud", 767);
                    htAHVNr.Add("ruf", 768);
                    htAHVNr.Add("rug", 769);
                    htAHVNr.Add("ruh", 770);
                    htAHVNr.Add("rup", 771);
                    htAHVNr.Add("rus", 772);
                    htAHVNr.Add("rut", 773);
                    htAHVNr.Add("ry", 774);
                    htAHVNr.Add("s", 775);
                    htAHVNr.Add("sal", 776);
                    htAHVNr.Add("sam", 777);
                    htAHVNr.Add("sar", 778);
                    htAHVNr.Add("sav", 779);
                    htAHVNr.Add("sb", 780);
                    htAHVNr.Add("se", 781);
                    htAHVNr.Add("sei", 782);
                    htAHVNr.Add("sen", 783);
                    htAHVNr.Add("seo", 784);
                    htAHVNr.Add("sf", 785);
                    htAHVNr.Add("si", 786);
                    htAHVNr.Add("sieg", 787);
                    htAHVNr.Add("sif", 788);
                    htAHVNr.Add("sim", 789);
                    htAHVNr.Add("sk", 790);
                    htAHVNr.Add("so", 791);
                    htAHVNr.Add("som", 792);
                    htAHVNr.Add("sp", 793);
                    htAHVNr.Add("spi", 794);
                    htAHVNr.Add("spo", 795);
                    htAHVNr.Add("sq", 796);
                    htAHVNr.Add("st", 850);
                    htAHVNr.Add("stah", 851);
                    htAHVNr.Add("stal", 852);
                    htAHVNr.Add("stan1", 853);
                    htAHVNr.Add("stau", 854);
                    htAHVNr.Add("ste", 855);
                    htAHVNr.Add("stef", 856);
                    htAHVNr.Add("stei", 857);
                    htAHVNr.Add("stein", 858);
                    htAHVNr.Add("stek", 859);
                    htAHVNr.Add("sti", 860);
                    htAHVNr.Add("sto", 861);
                    htAHVNr.Add("stod", 862);
                    htAHVNr.Add("stol", 863);
                    htAHVNr.Add("stoo", 864);
                    htAHVNr.Add("str", 865);
                    htAHVNr.Add("strau", 866);
                    htAHVNr.Add("stre", 867);
                    htAHVNr.Add("stri", 868);
                    htAHVNr.Add("stru", 869);
                    htAHVNr.Add("stu", 870);
                    htAHVNr.Add("stuc", 871);
                    htAHVNr.Add("stud", 872);
                    htAHVNr.Add("stuf", 873);
                    htAHVNr.Add("stus", 874);
                    htAHVNr.Add("su", 797);
                    htAHVNr.Add("sut", 798);
                    htAHVNr.Add("sv", 799);
                    htAHVNr.Add("s~", 800);
                    htAHVNr.Add("s~ad", 801);
                    htAHVNr.Add("s~af", 802);
                    htAHVNr.Add("s~al", 803);
                    htAHVNr.Add("s~ar", 804);
                    htAHVNr.Add("s~arb", 805);
                    htAHVNr.Add("s~arl", 806);
                    htAHVNr.Add("s~as", 807);
                    htAHVNr.Add("s~au", 808);
                    htAHVNr.Add("s~av", 809);
                    htAHVNr.Add("s~e", 810);
                    htAHVNr.Add("s~el", 811);
                    htAHVNr.Add("s~en", 812);
                    htAHVNr.Add("s~er", 813);
                    htAHVNr.Add("s~eu", 814);
                    htAHVNr.Add("s~i", 815);
                    htAHVNr.Add("s~il", 816);
                    htAHVNr.Add("s~l", 817);
                    htAHVNr.Add("s~le", 818);
                    htAHVNr.Add("s~lu", 819);
                    htAHVNr.Add("s~m", 820);
                    htAHVNr.Add("s~mid", 821);
                    htAHVNr.Add("s~mida", 822);
                    htAHVNr.Add("s~mie", 823);
                    htAHVNr.Add("s~mo", 824);
                    htAHVNr.Add("s~n", 825);
                    htAHVNr.Add("s~nei", 826);
                    htAHVNr.Add("s~nek", 827);
                    htAHVNr.Add("s~ni", 828);
                    htAHVNr.Add("s~ny", 829);
                    htAHVNr.Add("s~o", 830);
                    htAHVNr.Add("s~on", 831);
                    htAHVNr.Add("s~oo", 832);
                    htAHVNr.Add("s~or", 833);
                    htAHVNr.Add("s~r", 834);
                    htAHVNr.Add("s~u", 835);
                    htAHVNr.Add("s~ul", 836);
                    htAHVNr.Add("s~um", 837);
                    htAHVNr.Add("s~ur", 838);
                    htAHVNr.Add("s~us", 839);
                    htAHVNr.Add("s~w", 840);
                    htAHVNr.Add("s~wab", 841);
                    htAHVNr.Add("s~wac", 842);
                    htAHVNr.Add("s~war", 843);
                    htAHVNr.Add("s~warz", 844);
                    htAHVNr.Add("s~we", 845);
                    htAHVNr.Add("s~wei", 846);
                    htAHVNr.Add("s~weiz", 847);
                    htAHVNr.Add("s~wek", 848);
                    htAHVNr.Add("s~wi", 849);
                    htAHVNr.Add("t", 875);
                    htAHVNr.Add("tan", 876);
                    htAHVNr.Add("tao", 877);
                    htAHVNr.Add("te", 878);
                    htAHVNr.Add("ter", 879);
                    htAHVNr.Add("th", 880);
                    htAHVNr.Add("the", 881);
                    htAHVNr.Add("tho", 882);
                    htAHVNr.Add("thon", 883);
                    htAHVNr.Add("thr", 884);
                    htAHVNr.Add("ti", 885);
                    htAHVNr.Add("tir", 886);
                    htAHVNr.Add("to", 887);
                    htAHVNr.Add("tog", 888);
                    htAHVNr.Add("tor", 889);
                    htAHVNr.Add("tr", 890);
                    htAHVNr.Add("tre", 891);
                    htAHVNr.Add("tri", 892);
                    htAHVNr.Add("tro", 893);
                    htAHVNr.Add("tru", 894);
                    htAHVNr.Add("ts", 895);
                    htAHVNr.Add("tscha", 896);
                    htAHVNr.Add("tsche", 897);
                    htAHVNr.Add("tschu", 898);
                    htAHVNr.Add("tu", 899);
                    htAHVNr.Add("u", 900);
                    htAHVNr.Add("uf", 901);
                    htAHVNr.Add("ul", 902);
                    htAHVNr.Add("um", 903);
                    htAHVNr.Add("ur", 904);
                    htAHVNr.Add("v", 905);
                    htAHVNr.Add("val", 906);
                    htAHVNr.Add("vam", 907);
                    htAHVNr.Add("var", 908);
                    htAHVNr.Add("vau", 909);
                    htAHVNr.Add("ve", 910);
                    htAHVNr.Add("vet", 911);
                    htAHVNr.Add("vi", 912);
                    htAHVNr.Add("vil", 913);
                    htAHVNr.Add("vio", 914);
                    htAHVNr.Add("vo", 915);
                    htAHVNr.Add("vog", 916);
                    htAHVNr.Add("vogt", 917);
                    htAHVNr.Add("voh", 918);
                    htAHVNr.Add("vol", 919);
                    htAHVNr.Add("von", 920);
                    htAHVNr.Add("vong", 921);
                    htAHVNr.Add("vono", 922);
                    htAHVNr.Add("voo", 923);
                    htAHVNr.Add("vu", 924);
                    htAHVNr.Add("w", 925);
                    htAHVNr.Add("wag", 926);
                    htAHVNr.Add("wah", 927);
                    htAHVNr.Add("wal", 928);
                    htAHVNr.Add("wald", 929);
                    htAHVNr.Add("wale", 930);
                    htAHVNr.Add("wall", 931);
                    htAHVNr.Add("walt", 932);
                    htAHVNr.Add("wam", 933);
                    htAHVNr.Add("wap", 934);
                    htAHVNr.Add("was", 935);
                    htAHVNr.Add("wat", 936);
                    htAHVNr.Add("we", 937);
                    htAHVNr.Add("wec", 938);
                    htAHVNr.Add("weh", 939);
                    htAHVNr.Add("wei", 940);
                    htAHVNr.Add("weif", 941);
                    htAHVNr.Add("weis", 942);
                    htAHVNr.Add("weit", 943);
                    htAHVNr.Add("wek", 944);
                    htAHVNr.Add("wen", 945);
                    htAHVNr.Add("wer", 946);
                    htAHVNr.Add("wern", 947);
                    htAHVNr.Add("wes", 948);
                    htAHVNr.Add("weu", 949);
                    htAHVNr.Add("wi", 950);
                    htAHVNr.Add("wid", 951);
                    htAHVNr.Add("wie", 952);
                    htAHVNr.Add("wiel", 953);
                    htAHVNr.Add("wif", 954);
                    htAHVNr.Add("wil", 955);
                    htAHVNr.Add("wile", 956);
                    htAHVNr.Add("wim", 957);
                    htAHVNr.Add("wip", 958);
                    htAHVNr.Add("wir", 959);
                    htAHVNr.Add("wis", 960);
                    htAHVNr.Add("wit", 961);
                    htAHVNr.Add("witt", 962);
                    htAHVNr.Add("wo", 963);
                    htAHVNr.Add("wol", 964);
                    htAHVNr.Add("wu", 965);
                    htAHVNr.Add("wui", 966);
                    htAHVNr.Add("wun", 967);
                    htAHVNr.Add("wur", 968);
                    htAHVNr.Add("wut", 969);
                    htAHVNr.Add("wy", 970);
                    htAHVNr.Add("wym", 971);
                    htAHVNr.Add("wys", 972);
                    htAHVNr.Add("wyss", 973);
                    htAHVNr.Add("wyt", 974);
                    htAHVNr.Add("x", 975);
                    htAHVNr.Add("z", 976);
                    htAHVNr.Add("zam", 977);
                    htAHVNr.Add("zau", 978);
                    htAHVNr.Add("zb", 979);
                    htAHVNr.Add("ze", 980);
                    htAHVNr.Add("zeh", 981);
                    htAHVNr.Add("zei", 982);
                    htAHVNr.Add("zem", 983);
                    htAHVNr.Add("zf", 984);
                    htAHVNr.Add("zi", 985);
                    htAHVNr.Add("zim", 986);
                    htAHVNr.Add("zin", 987);
                    htAHVNr.Add("zk", 988);
                    htAHVNr.Add("zo", 989);
                    htAHVNr.Add("zu", 990);
                    htAHVNr.Add("zuc", 991);
                    htAHVNr.Add("zul", 992);
                    htAHVNr.Add("zum", 993);
                    htAHVNr.Add("zun", 994);
                    htAHVNr.Add("zur", 995);
                    htAHVNr.Add("zus", 996);
                    htAHVNr.Add("zw", 997);
                    htAHVNr.Add("zwe", 998);
                    htAHVNr.Add("zy", 999);

                    #endregion Values

                    // order hashtable
                    lstAHVNrNames = new ArrayList(htAHVNr.Keys);
                    lstAHVNrNames.Sort();
                }

                #endregion Init Hashtable

                #region PrepareName

                // default preparations
                lastName = lastName.ToLower();
                lastName = lastName.Replace("ä", "ae");
                lastName = lastName.Replace("ö", "oe");
                lastName = lastName.Replace("ü", "ue");
                lastName = lastName.Replace("ß", "ss");
                lastName = lastName.Replace("sch", "s~");
                lastName = lastName.Replace("à", "a");
                lastName = lastName.Replace("á", "a");
                lastName = lastName.Replace("â", "a");
                lastName = lastName.Replace("ç", "c");
                lastName = lastName.Replace("è", "e");
                lastName = lastName.Replace("é", "e");
                lastName = lastName.Replace("ñ", "n");
                lastName = lastName.Replace(" ", "");
                lastName = lastName.Replace("-", "");
                lastName = lastName.Replace("'", "");
                lastName = lastName.Trim();

                // ENHANCED RULES:
                // die Ausnahmen mit 3 Umlauten
                bool goOn = true;
                bool valueFound = false;

                if (lastName.IndexOf("aue") >= 0)
                {
                    valueFound = true;
                    goOn = false;
                }
                else { valueFound = false; }
                if (goOn)
                {
                    if (lastName.IndexOf("eue") >= 0)
                    {
                        valueFound = true;
                        goOn = false;
                    }
                    else { valueFound = false; }
                }
                if (goOn)
                {
                    if (lastName.IndexOf("iue") >= 0)
                    {
                        valueFound = true;
                        goOn = false;
                    }
                    else { valueFound = false; }
                }
                if (goOn)
                {
                    if (lastName.IndexOf("oue") >= 0)
                    {
                        valueFound = true;
                        goOn = false;
                    }
                    else { valueFound = false; }
                }
                if (goOn)
                {
                    if (lastName.IndexOf("uue") >= 0)
                    {
                        valueFound = true;
                        goOn = false;
                    }
                    else { valueFound = false; }
                }

                // Die E Regel
                if (!valueFound)
                {
                    lastName = lastName.Replace("aee", "a");
                    lastName = lastName.Replace("ae", "a");

                    lastName = lastName.Replace("iee", "i");
                    lastName = lastName.Replace("ie", "i");

                    lastName = lastName.Replace("oee", "o");
                    lastName = lastName.Replace("oe", "o");

                    lastName = lastName.Replace("uee", "u");
                    lastName = lastName.Replace("ue", "u");
                }

                #endregion PrepareName

                // create helper vars
                int ahvPart1 = -1;
                int ahvPart2 = -1;
                int ahvPart3 = -1;

                // FIRST PART:
                // get first part
                string lastKey = "";
                bool partFound = false;
                foreach (string key in lstAHVNrNames)
                {
                    // check if we have the value for the lastname
                    if (string.Compare(key, lastName) > 0)
                    {
                        partFound = true;
                        break;
                    }

                    // set last key
                    lastKey = key;
                }

                // check if we have found a value
                if (!partFound)
                {
                    // no value found
                    return null;
                }

                // apply first part
                ahvPart1 = Convert.ToInt32(htAHVNr[lastKey]);

                // SECOND PART:
                ahvPart2 = Convert.ToInt32(birthday.Year % 100);

                // THIRD PART:
                ahvPart3 = Convert.ToInt32((genderCode == 2 ? 500 : 100) + Math.Floor(((double)birthday.Month - 1.0) / 3.0) * 100 + (birthday.Month - 1) % 3 * 31 + birthday.Day);

                // validate
                if (ahvPart1 < 0 || ahvPart2 < 0 || ahvPart3 < 0)
                {
                    // invalid
                    return null;
                }

                // return finished value
                return string.Format("{0:000}.{1:00}.{2:000}.xxx", ahvPart1, ahvPart2, ahvPart3);
            }
            catch (Exception)
            {
                if (System.Diagnostics.Debugger.IsAttached)
                {
                    System.Diagnostics.Debugger.Break();
                }

                // failed
                return null;
            }
        }

        /// <summary>
        /// Checks an IBAN number
        /// </summary>
        /// <param name="IBAN">IBAN number</param>
        /// <param name="ErrorMsg">Error meessage</param>
        /// <returns>true if correct, false if incorrect</returns>
        public static bool CheckIBAN(string IBAN, out string ErrorMsg)
        {
            // Kontrolliert die Prüfsumme einer eingegebenen IBAN Nummer:
            // siehe auch http://www.tsql.de/csharp/csharp_iban_validieren_iban_testen_iban_code.php
            // Fehlermeldung:
            ErrorMsg = "";
            string ErrMsgCountry = "";

            // Leerzeichen entfernen
            string mysIBAN = IBAN.Replace(" ", "");

            // Eine IBAN hat minimal5, maximal 34 Stellen
            if (mysIBAN.Length > 34 || mysIBAN.Length < 5)
            {
                // IBAN ist zu kurz oder zu lang:
                ErrorMsg = KissMsg.GetMLMessage("Common", "IBANCheckLaengeFalsch",
                    "Die IBAN muss mindestens 5 und darf maximal 34 Zeichen haben.");
                return false;
            }
            else
            {
                string LaenderCode = mysIBAN.Substring(0, 2).ToUpper();
                string Pruefsumme = mysIBAN.Substring(2, 2).ToUpper();
                string BLZ_Konto = mysIBAN.Substring(4).ToUpper();

                if (!IsNatural(Pruefsumme))
                {
                    // Prüfsumme ist nicht numerisch
                    ErrorMsg = KissMsg.GetMLMessage(
                        "Common",
                        "IBANCheckPruefsummeNumerisch",
                        "Die Prüfsumme ist nicht numerisch, es dürfen nur Zahlen enthalten sein.");
                    return false;
                }

                if (!Utils.IsLaendercode(LaenderCode, out ErrMsgCountry))
                {
                    // Ländercode ist ungültig
                    ErrorMsg = ErrMsgCountry;
                    return false;
                }

                // Pruefsumme validieren
                string Umstellung = BLZ_Konto + LaenderCode + "00";
                string Modulus = IBANCleaner(Umstellung);
                if (98 - Modulo(Modulus, 97) != int.Parse(Pruefsumme))
                {
                    // Prüfsumme ist fehlerhaft
                    ErrorMsg = KissMsg.GetMLMessage("Common", "IBANCheckPruefsummeIstFalsch", "Die Prüfsumme '{0}' ist nicht korrekt.", Pruefsumme);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Überprüft die spezifizierte Nummer anhand der Prüfzifferberechnung
        /// Module 10, rekursiv
        /// </summary>
        /// <param name="Nummer">Die zu überprüfende Nummer.</param>
        /// <returns></returns>
        public static bool CheckMod10Nummer(string Nummer)
        {
            if (Utils.IsNatural(Nummer))
            {
                int[] array = new int[11] { 0, 9, 4, 6, 8, 2, 7, 1, 3, 5, 0 };

                if (Nummer.Length > 0)
                {
                    int length = Nummer.Length;
                    int temp = array[Convert.ToInt32(Convert.ToString(Nummer[0]))];

                    for (int i = 1; i < length - 1; i++)
                    {
                        temp = array[(Convert.ToInt32(Convert.ToString(Nummer[i])) + temp) % 10];
                    }

                    if (Convert.ToInt32(Convert.ToString(Nummer[length - 1])) == (10 - temp) % 10)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Checks a Postkonto number and converts to a Teilnehmer number
        /// </summary>
        /// <param name="Start">Postkonto number</param>
        /// <param name="ErrorMsg">Error message</param>
        /// <param name="TNNumber">Teilnehmer number (converted from Postkonto number)</param>
        /// <returns>true if correct, false if incorrect</returns>
        public static bool CheckPCKontoNumber(string Start, out string ErrorMsg, out string TNNumber)
        {
            // Kontrolliert die Prüfziffer einer eingegebenen PC-Konto-Nummer:
            TNNumber = "";
            ErrorMsg = "";
            string ErrFormat = KissMsg.GetMLMessage("Common", "PCFormatZwingend",
                "Das Format xx-yyyyyy-p ist zwingend.");
            string[] Parts = Start.Split(new Char[] { '-' });

            // allgemein kontrollieren:
            if (!(Parts.Length == 3))
            {
                ErrorMsg = KissMsg.GetMLMessage("Common", "PCFormatFalsch",
                    "PostKonto-Nummer ist falsch formatiert.") + "\r\n" + ErrFormat;
                return false;
            }

            // erster Teil kontrollieren:
            if (!(Parts[0].Length == 2))
            {
                ErrorMsg = KissMsg.GetMLMessage("Common", "PCFormatFalschTeil1",
                    "Das erste Teil muss 2 Zeichen haben.") + "\r\n" + ErrFormat;
                return false;
            }

            // zweiter Teil kontrollieren:
            if ((Parts[1].Length < 1) || (Parts[1].Length > 6))
            {
                ErrorMsg = KissMsg.GetMLMessage("Common", "PCFormatFalschTeil2",
                    "Der mittlere Teil der Nummer muss mindestens 1 und maximal 6 Zeichen haben.") + "\r\n" + ErrFormat;
                return false;
            }

            // Prüfziffer kontrollieren:
            if (!(Parts[2].Length == 1))
            {
                ErrorMsg = KissMsg.GetMLMessage("Common", "PCFormatFalschTeil3",
                    "Die Prüfziffer darf nur ein Zeichen enthalten.") + "\r\n" + ErrFormat;
                return false;
            }

            // mittlerer Teil mit Nullen ergänzen:
            while (Parts[1].Length < 6)
                Parts[1] = "0" + Parts[1];
            TNNumber = Parts[0] + Parts[1] + Parts[2];

            // Prüfziffer-Kontrolle
            if (!Utils.CheckMod10Nummer(TNNumber))
            {
                ErrorMsg = KissMsg.GetMLMessage("Common", "PCFormatFalschPruefziffer",
                    "Die Prüfziffer p oder die Nummer ist falsch.") + "\r\n" + ErrFormat;
                return false;
            }
            return true;
        }

        /// <summary>
        /// Converts a value of type object to a bool.
        /// </summary>
        /// <param name="value">object (can be null)</param>
        /// <returns>Result bool (false if empty)</returns>
        public static Boolean ConvertToBool(Object value)
        {
            return ConvertToBool(value, false);
        }

        /// <summary>
        /// Converts a value of type object to a bool.
        /// </summary>
        /// <param name="value">object (can be null)</param>
        /// <param name="defaultValue"></param>
        /// <returns>Result bool (false if empty or other type)</returns>
        public static Boolean ConvertToBool(Object value, Boolean defaultValue)
        {
            return (value is Boolean) ? (Boolean)value : defaultValue;
        }

        /// <summary>
        /// Converts a value of type object to a DateTime.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(Object value)
        {
            return ConvertToDateTime(value, DateTime.MinValue);
        }

        /// <summary>
        /// Converts a value of type object to a DateTime.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static DateTime ConvertToDateTime(Object value, DateTime defaultValue)
        {
            return (value is DateTime) ? (DateTime)value : defaultValue;
        }

        /// <summary>
        /// Converts a value of type object to a decimal.
        /// </summary>
        /// <param name="value">object (can be null)</param>
        /// <returns>Result decimal (0.0 if empty)</returns>
        public static Decimal ConvertToDecimal(Object value)
        {
            return ConvertToDecimal(value, 0.0m);
        }

        /// <summary>
        /// Converts a value of type object to a decimal.
        /// </summary>
        /// <param name="value">object (can be null)</param>
        /// <param name="defaultValue"></param>
        /// <returns>Result decimal (defaultValue if empty)</returns>
        public static Decimal ConvertToDecimal(Object value, Decimal defaultValue)
        {
            return (value is Decimal) ? (Decimal)value : defaultValue;
        }

        /// <summary>
        /// Converts a value of type object to a double.
        /// </summary>
        /// <param name="value">object (can be null)</param>
        /// <returns>Result decimal (0.0 if empty)</returns>
        public static Double ConvertToDouble(Object value)
        {
            return ConvertToDouble(value, 0.0);
        }

        /// <summary>
        /// Converts a value of type object to a double.
        /// </summary>
        /// <param name="value">object (can be null)</param>
        /// <param name="defaultValue"></param>
        /// <returns>Result decimal (defaultValue if empty)</returns>
        public static Double ConvertToDouble(Object value, Double defaultValue)
        {
            return (value is Double) ? (Double)value : defaultValue;
        }

        /// <summary>
        /// Converts a value of type object to an int.
        /// </summary>
        /// <param name="value">object (can be null)</param>
        /// <returns>Result int (0 if empty)</returns>
        public static Int32 ConvertToInt(Object value)
        {
            return ConvertToInt(value, 0);
        }

        /// <summary>
        /// Converts a value of type object to an int.
        /// </summary>
        /// <param name="value">object (can be null)</param>
        /// <param name="defaultValue">Default value used on error.</param>
        /// <returns>Result int (defaultValue if empty)</returns>
        public static Int32 ConvertToInt(Object value, Int32 defaultValue)
        {
            return (value is Int32) ? (Int32)value : defaultValue;
        }

        /// <summary>
        /// Converts a value of type object to a string.
        /// </summary>
        /// <param name="value">object (can be null)</param>
        /// <returns>The converted value. String.Empty on failure.</returns>
        public static String ConvertToString(Object value)
        {
            return ConvertToString(value, String.Empty);
        }

        /// <summary>
        /// Converts a value of type object to a string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">Default value to return on failure.</param>
        /// <returns>The converted value. defaultValue on failure.</returns>
        public static String ConvertToString(Object value, String defaultValue)
        {
            return (value is String) ? (String)value : defaultValue;
        }

        /// <summary>
        /// Convert the specified date to format used on GUI.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string date2gui(DateTime dt)
        {
            return dt.ToString("dd.MM.yyyy");
        }

        /// <summary>
        /// Convert the specified date to sortable format.
        /// </summary>
        /// <param name="dt">The dt.</param>
        /// <returns></returns>
        public static string date2sort(DateTime dt)
        {
            return dt.ToString("yyyyMMdd");
        }

        /// <summary>
        /// Remove the time part of a date time (keep only year, month and days)
        /// </summary>
        /// <param name="aDateRef"></param>
        /// <returns></returns>
        public static DateTime dropTime(DateTime aDateRef)
        {
            return aDateRef.Date; // drop time
        }

        /// <summary>
        /// Get first day of month
        /// </summary>
        /// <param name="aDateRef">The date to get first day from</param>
        /// <returns>The first day of the month from the desired date</returns>
        public static DateTime firstDayOfMonth(DateTime aDateRef)
        {
            return new DateTime(aDateRef.Year, aDateRef.Month, 1); // 1st day of month
        }

        /// <summary>
        /// Formats the PC konto nummer to DB format.
        /// </summary>
        /// <param name="kontoNummer">The konto nummer.</param>
        /// <returns></returns>
        public static string FormatPCKontoNummerToDBFormat(string kontoNummer)
        {
            return FormatPCKontoNummerToDBFormat(kontoNummer, ZahlungsArt.Unbekannt);
        }

        /// <summary>
        /// Formats the PC konto nummer to DB format.
        /// </summary>
        /// <param name="kontoNummer">The konto nummer.</param>
        /// <param name="art">The art.</param>
        /// <returns></returns>
        public static string FormatPCKontoNummerToDBFormat(string kontoNummer, ZahlungsArt art)
        {
            bool withSeparator = false;
            string kontoNummerFormatted;

            // replace *

            kontoNummer = kontoNummer.Replace("*", "");

            if (kontoNummer.Length == 0)
                return kontoNummer;

            // look if user used xx-*-x format
            Regex r = new Regex("-");
            int count = r.Matches(kontoNummer).Count;

            if (count == 0)
            {
                withSeparator = false;
            }
            else if (count == 2)
            {
                withSeparator = true;
            }
            else
            {
                throw new KissInfoException("PostKonto Nummer falsch formattiert");
            }

            if (withSeparator)
            {
                // Count Separators
                if (kontoNummer.Length > 11)
                {
                    throw new KissInfoException("Konto Nummer zu lang, max. 11 Positionen");
                }

                if (kontoNummer.Length < 6)
                {
                    throw new KissInfoException("Konto Nummer zu kurz, min. 6 Positionen");
                }

                int separatorIndex;
                int middleLength;
                string tempPart;

                // 30-
                if (kontoNummer.Length <= 6 && (art == ZahlungsArt.OrangerEinzahlungsschein || art == ZahlungsArt.Blau_Orange_ESR_ueber_Bank))
                {
                    middleLength = 1;
                }
                else
                {
                    middleLength = 5;
                }

                separatorIndex = kontoNummer.IndexOf("-");

                if (kontoNummer.Length > 10)
                {
                    kontoNummerFormatted = kontoNummer.Substring(0, separatorIndex + 1).Replace("-", "");
                }
                else
                {
                    kontoNummerFormatted = kontoNummer.Substring(0, separatorIndex + 1).Replace("-", "0");
                }

                // 111-
                separatorIndex = kontoNummer.IndexOf("-", separatorIndex);

                if (kontoNummer.Length > 9)
                {
                    tempPart = kontoNummer.Substring(3, kontoNummer.Length - separatorIndex - 3).Replace("-", "");
                }
                else
                {
                    tempPart = kontoNummer.Substring(3, kontoNummer.Length - separatorIndex - 3).Replace("-", "0");
                }

                while (tempPart.Length < middleLength)
                {
                    tempPart = "0" + tempPart;
                }

                kontoNummerFormatted += tempPart + kontoNummer.Substring(kontoNummer.Length - 1, 1);
            }
            else
            {
                if (kontoNummer.Length > 9)
                {
                    throw new KissInfoException("Konto Nummer zu lang, max. 9 Positionen ohne Trennungstrichen");
                }

                if (kontoNummer.Length < 5)
                {
                    throw new KissInfoException("Konto Nummer zu lang, min. 5 Positionen ohne Trennungstrichen");
                }

                kontoNummerFormatted = kontoNummer;
            }

            if (CheckMod10Nummer(kontoNummerFormatted))
            {
                return kontoNummerFormatted;
            }

            throw new KissInfoException(KissMsg.GetMLMessage("Utils", "WrongAccountNumber", "Konto Nummer: {0} falsch", KissMsgCode.MsgError, FormatPCKontoNummerToUserFormat(kontoNummer)));
        }

        /// <summary>
        /// Method used to format a PCKontoNummer which is stored in a numeric format on Database to a ??-*-? format.
        /// </summary>
        /// <param name="kontoNummer"></param>
        /// <returns></returns>
        public static string FormatPCKontoNummerToUserFormat(string kontoNummer)
        {
            if (Utils.IsNatural(kontoNummer) && kontoNummer.Length > 5)
            {
                // Check if KontoNummer isn't already formatted
                // look if user used xx-*-x format
                Regex r = new Regex("-");
                int count = r.Matches(kontoNummer).Count;

                if (count == 2)
                    return kontoNummer;

                string kontoNummerFormatted;
                int lastZeroSuiteIndex = 2;

                kontoNummerFormatted = kontoNummer.Substring(0, 2) + '-';

                // find lastZeroSuite Index
                while (kontoNummer[lastZeroSuiteIndex] == '0')
                    lastZeroSuiteIndex++;

                kontoNummerFormatted += kontoNummer.Substring(lastZeroSuiteIndex, kontoNummer.Length - 1 - lastZeroSuiteIndex) + '-' + kontoNummer.Substring(kontoNummer.Length - 1, 1);

                return kontoNummerFormatted;
            }
            else
                return kontoNummer;
        }

        /// <summary>
        /// Converts Teilnehmer number to Postkonto numbers
        /// </summary>
        /// <param name="TN">Teilnehmer number</param>
        /// <returns>Postkonto number</returns>
        public static string FromTnToPc(string TN)
        {
            // Bestimmt die PC-Nummer im Format xx-yyyyyy-p
            // aus einer Teilnemehernummer, Format xxyyyyyyp
            if (TN.Length != 9)
            {
                // Wenn Länge der Teilnehmernnumer nicht 9 9 ist,
                // dann wird nichts gemacht
                return TN;
            }
            else
            {
                // führende Nullen in der Mitte entfernen:
                string MidPart = TN.Substring(2, 6);
                while (MidPart.StartsWith("0"))
                    MidPart = MidPart.Substring(1, MidPart.Length - 1);

                // PC-Konto-Nummer erstellen:
                return TN.Substring(0, 2) + "-" + MidPart + "-" + TN.Substring(8, 1);
            }
        }

        /// <summary>
        /// Get Count of Pendenzen which aren't terminated yet
        /// </summary>
        /// <param name="faLeistungID">FaLeistungID</param>
        /// <returns>Count of open Pendenzen</returns>
        public static int GetAnzahlOffenePendenzen(int faLeistungID)
        {
            //taskstatuscode 3 = erledigt
            return (int)DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT COUNT(*)
                FROM dbo.XTask WITH(READUNCOMMITTED)
                WHERE FaLeistungID = {0}
                AND TaskStatusCode <> 3",
                    faLeistungID);
        }

        /// <summary>
        /// Gets the app code named value.
        /// </summary>
        /// <param name="Name">The name.</param>
        /// <param name="AppCode">The app code.</param>
        /// <returns></returns>
        public static string GetAppCodeNamedValue(string Name, string AppCode)
        {
            if (Name == null || AppCode == null)
                return null;
            int idx = AppCode.ToUpper().IndexOf("[" + Name.ToUpper() + "=");
            if (idx == -1)
                return null;

            string Value = AppCode.Substring(idx + Name.Length + 2);
            idx = Value.IndexOf("]");
            if (idx == -1)
                return null; // Syntax Fehler

            return Value.Substring(0, idx);
        }

        public static DateTime GetDateNextDayOfWeek(DateTime datumVon, DayOfWeek day)
        {
            int addDays = (int)day - (int)datumVon.DayOfWeek;
            if (addDays < 0)
            {
                addDays += 7;
            }

            return datumVon.AddDays(addDays);
        }

        /// <summary>
        /// Set header and footer for standard print out
        /// </summary>
        public static string GetDateRangeText(string dateVon, string dateBis)
        {
            string printTextVon = KissMsg.GetMLMessage("Utils", "PrintTextAb", "ab");
            string printTextBis = KissMsg.GetMLMessage("Utils", "PrintTextBis", "bis");

            if (dateVon != "" && dateBis != "")
            {
                return dateVon + " - " + dateBis;
            }
            else if (dateVon != "")
            {
                return printTextVon + " " + dateVon;
            }
            else if (dateBis != "")
            {
                return printTextBis + " " + dateBis;
            }
            return KissMsg.GetMLMessage("Utils", "PrintGanzerDatumsBereich", "ganzer Datumsbereich");
        }

        /// <summary>
        /// Gets a list of int comming from a string with comma-separeted numbers.
        /// </summary>
        /// <param name="str">string with comma-separeted numbers</param>
        /// <returns>list of int</returns>
        public static List<int> GetListOfInt(string str)
        {
            List<int> list = new List<int>();

            string[] stringItems = str.Split(',');
            if (str != "")
            {
                foreach (string item in stringItems)
                {
                    int intValue = Convert.ToInt32(item);
                    list.Add(intValue);
                }
            }
            return list;
        }

        /// <summary>
        /// Gets the next working day. Basically skips the weekend.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns></returns>
        public static DateTime GetNextWorkingDay(DateTime tag)
        {
            DateTime werktag;

            switch (tag.DayOfWeek)
            {
                case DayOfWeek.Saturday:
                    werktag = tag.AddDays(2);
                    break;

                case DayOfWeek.Sunday:
                    werktag = tag.AddDays(1);
                    break;

                default:
                    werktag = tag;
                    break;
            }

            return werktag;
        }

        /// <summary>
        /// Get the name of the org. unit type which is defined in the config value "System\Basis\OrgEinheitTypFuerInstTypen"
        /// </summary>
        /// <returns>Name of the org. unit type or empty string if no type is chosen</returns>
        public static string GetOrgUnitTypNameForInstitutionsTypen()
        {
            int orgUnitTypCode = DBUtil.GetConfigInt(@"System\Basis\OrgEinheitTypFuerInstTypen", -1);
            string typeName = string.Empty;
            typeName = DBUtil.ExecuteScalarSQL(@"
                    DECLARE @Caption VARCHAR(100);

                    SELECT @Caption = dbo.fnGetMLTextByDefault(LOC.ShortTextTID, {0}, LOC.ShortText)
                    FROM dbo.XLOVCode LOC WITH (READUNCOMMITTED)
                    WHERE LOC.LOVName = 'OrganisationsEinheitTyp'
                      AND LOC.Code = {1};

                    SELECT ISNULL(@Caption, '');", Session.User.LanguageCode, orgUnitTypCode) as string;
            return typeName;
        }

        /// <summary>
        /// Replace Charcters in IBAN with numbers.
        /// </summary>
        /// <param name="sIBAN">The s IBAN.</param>
        /// <returns></returns>
        /// TODO: Verify correctness
        public static string IBANCleaner(string sIBAN)
        {
            // Buchstaben duch Zahlen ersetzen
            for (int x = 65; x < 91; x++)
            {
                int ReplaceWith = x - 64 + 9;
                string ReplaceString = ((char)x).ToString();
                sIBAN = sIBAN.Replace(ReplaceString, ReplaceWith.ToString());
            }

            return sIBAN;
        }

        /// <summary>
        /// Fügt einen Eintrag in FaLeistungUserHist ein. Protokolliert wird der bisherige SAR, DatumVon und DatumBis.
        /// Wichtig: Die Methode muss aufgerufen werden BEVOR der neue SAR zugewiesen wird!
        /// </summary>
        /// <param name="faLeistungIDCSV">Die Leistungen (kommasepariert), für die der aktuelle SAR protokolliert werden soll.</param>
        public static void InsertFaLeistungUserHist(string faLeistungIDCSV)
        {
            string[] faleistungIDs = faLeistungIDCSV.Split(',');
            foreach (var faleistungIDString in faleistungIDs)
            {
                int faLeistungID;
                if (Int32.TryParse(faleistungIDString, out faLeistungID))
                {
                    InsertFaLeistungUserHist(faLeistungID);
                }
            }
        }

        /// <summary>
        /// Fügt einen Eintrag in FaLeistungUserHist ein. Protokolliert wird der bisherige SAR, DatumVon und DatumBis.
        /// Wichtig: Die Methode muss aufgerufen werden BEVOR der neue SAR zugewiesen wird!
        /// </summary>
        /// <param name="faLeistungID">Die Leistung, für die der aktuelle SAR protokolliert werden soll.</param>
        public static void InsertFaLeistungUserHist(int faLeistungID)
        {
            DBUtil.ExecuteScalarSQLThrowingException(@"
                INSERT INTO FaLeistungUserHist (FaLeistungID, UserID, DatumVon, DatumBis, Creator, Created, Modifier, Modified)
                SELECT LEI.FaLeistungID,
                       LEI.UserID,
                       ISNULL(DATEADD(DAY, 1, LUH.DatumBis), LEI.DatumVon),
                       DATEADD(DAY, -1, dbo.fnDateOf(GETDATE())),
                       {1},
                       GETDATE(),
                       {1},
                       GETDATE()
                FROM FaLeistung LEI
                  OUTER APPLY (SELECT TOP 1 DatumBis
                               FROM FaLeistungUserHist
                               WHERE FaLeistungID = LEI.FaLeistungID
                               ORDER BY DatumVon DESC) LUH
                WHERE LEI.FaLeistungID = {0}",
                faLeistungID,
                Session.User.CreatorModifier);
        }

        /// <summary>
        /// Determines whether [is address empty] [the specified qry].
        /// </summary>
        /// <param name="qry">The qry.</param>
        /// <param name="fields">The fields.</param>
        /// <returns>
        /// 	<c>true</c> if [is address empty] [the specified qry]; otherwise, <c>false</c>.
        /// </returns>
        public static bool isAddressEmpty(SqlQuery qry, params string[] fields)
        {
            bool empty = true;

            foreach (string s in fields)
            {
                empty = empty && DBUtil.IsEmpty(qry[s]);
            }

            return empty;
        }

        /// <summary>
        /// Determines whether the specified input is alphanumeric.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input is alpha; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAlpha(string input)
        {
            Match m = isAlpha.Match(input);
            return m.Success;
        }

        /// <summary>
        /// Determines whether the specified input is decimal.
        /// </summary>
        /// <param name="input">The input string to be parsed</param>
        /// <returns>
        /// <c>true</c> if the specified input is decimal; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDecimal(string input)
        {
            Match m = isDecimal.Match(input);
            return m.Success;
        }

        /// <summary>
        /// Validate an email adress
        /// </summary>
        /// <param name="strEmail">the email adress to check</param>
        /// <returns>true if email is valid, else false </returns>
        public static bool IsEmailAdress(string strEmail)
        {
            try
            {
                Regex objNotWholePattern =
                    new Regex("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$");
                return objNotWholePattern.IsMatch(strEmail);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Checks, if Code is a valid country code
        /// </summary>
        /// <param name="Code">country Code 82 characters)</param>
        /// <param name="ErrMsgCountry">Error message</param>
        /// <returns></returns>
        public static bool IsLaendercode(string Code, out string ErrMsgCountry)
        {
            // TODO: Diese Ländercodes müssten über die Länder stammdaten geholt werden. Evtl. kann diese Methode auch mit einer Funktion aus IBANKernel.dll ersetzt werden.

            // Test auf korrekten Ländercode nach ISO 3166-1
            // Der Code muss laut ISO 3166-1 ein 2-stelliger Ländercode aus Buchstaben sein.

            ErrMsgCountry = "";
            if (Code.Length != 2)
            {
                //ErrMsgCountry = "Der Ländercode muss aus zwei Zeichen bestehen.";
                ErrMsgCountry = KissMsg.GetMLMessage("Common", "LaenderCodeZahlFalsch",
                    "Der Ländercode muss aus zwei Zeichen bestehen.");
                return false;
            }
            else
            {
                Code = Code.ToUpper();

                // Länderstamm aus dem Internet: 238 Länder
                // 20.02.2008 : ergänzt mit RS = Serbien (jetzt 239)
                // siehe: http://de.wikipedia.org/wiki/International_Bank_Account_Number -> RS
                // oder http://www.postfinance.ch/medialib/pf/de/doc/prod/pay/ibanlist.Par.0001.File.dat/ibanlist_de.pdf
                // oder http://www.tbg5-finance.org/?ibancheck.shtml
                // oder http://www.blkb.ch/iban_laender_per_01_05_2008-4.pdf
                string[] Laendercodes = {
              "AD", "BE", "GB", "AE", "AF", "AG", "AI", "AL", "AM", "AN",
                "AO", "AQ", "AR", "AS", "AT", "AU", "AW", "AZ",
              "BA", "BB", "BD", "BF", "BG", "BH", "BI", "BJ", "BM", "BN",
                "BO", "BR", "BS", "BT", "BV", "BW", "BY", "BZ",
              "CA", "CC", "CD", "CF", "CG", "CH", "CI", "CK", "CL", "CM",
                "CN", "CO", "CR", "CU", "CV", "CX", "CY", "CZ",
              "DE", "DJ", "DK", "DM", "DO", "DZ",
              "EC", "EE", "EG", "EH", "ER", "ES", "ET",
              "FI", "FJ", "FK", "FM", "FO", "FR",
              "GA", "GD", "GE", "GF", "GH", "GI", "GL", "GM", "GN", "GP",
                "GQ", "GR", "GS", "GT", "GU", "GW", "GY",
              "HK", "HM", "HN", "HR", "HT", "HU",
              "ID", "IE", "IL", "IN", "IO", "IQ", "IR", "IS", "IT",
              "JM", "JO", "JP",
              "KE", "KG", "KH", "KI", "KM", "KN", "KP", "KR", "KW", "KY", "KZ",
              "LA", "LB", "LC", "LI", "LK", "LR", "LS", "LT", "LU", "LV", "LY",
              "MA", "MC", "MD", "MG", "MH", "MK", "ML", "MM", "MN", "MO",
                "MP", "MQ", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "MZ",
              "NA", "NC", "NE", "NF", "NG", "NI", "NL", "NO", "NP", "NR", "NU", "NZ",
              "OM",
              "PA", "PE", "PF", "PG", "PH", "PK", "PL", "PM", "PN", "PR", "PT", "PW", "PY",
              "QA",
              "RE", "RO", "RS", "RU", "RW",
              "SA", "SB", "SC", "SD", "SE", "SG", "SH", "SI", "SJ", "SK", "SL", "SM", "SN",
                "SO", "SR", "ST", "SV", "SY", "SZ",
              "TC", "TD", "TF", "TG", "TH", "TJ", "TK", "TM", "TN", "TO", "TL", "TR", "TT",
                "TV", "TW", "TZ",
              "UA", "UG", "UM", "US", "UY", "UZ",
              "VA", "VC", "VE", "VG", "VI", "VN", "VU",
              "WF", "WS",
              "YE", "YT", "YU",
              "ZA", "ZM", "ZW" };

                if (Array.IndexOf(Laendercodes, Code) == -1)
                {
                    ErrMsgCountry = KissMsg.GetMLMessage("Common", "LaenderCodeExistiertNicht", "Der Ländercode '{0}' existiert nicht.", Code);
                    return false;
                }
                else
                    return true;
            }
        }

        /// <summary>
        /// Überprüft, ob ein Modul lizenziert ist. Es wird die
        /// Tabelle XModul und die Spalte NameSpace konsultiert.
        /// </summary>
        /// <param name="moduleShortName">Der Namespace des Moduls, z.B. KiSS4.Asyl für Asyl</param>
        /// <returns>true falls das Modul lizenziert ist.</returns>
        public static bool IsModuleLicensed(string moduleShortName)
        {
            string sqlQuery = @"SELECT COUNT(*)
                                FROM dbo.XModul MDL
                                WHERE MDL.NameSpace = {0} AND MDL.Licensed  = 1";
            int count = (int)DBUtil.ExecuteScalarSQL(sqlQuery, moduleShortName);
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether the specified input is a natural number (0,1, ...)
        /// </summary>
        /// <param name="input">The string to parse for natural validation</param>
        /// <returns>True, if value is natural, false if not natural</returns>
        public static bool IsNatural(string input)
        {
            Match m = isNatural.Match(input);
            return m.Success;
        }

        /// <summary>
        /// Determines whether the specified input is numeric (..., -1, 0, 1, ...)
        /// </summary>
        /// <param name="input">The string to parse for numeric validation</param>
        /// <returns>True, if value is numeric, false if not numeric</returns>
        public static bool IsNumeric(string input)
        {
            Match m = isNumeric.Match(input);
            return m.Success;
        }

        /// <summary>
        /// Determines whether the specified country is Switzerland
        /// </summary>
        /// <param name="baLandID">The id within BaLand table (old: land code).</param>
        /// <returns>
        ///     <c>true</c> if the specified land code is schweiz; otherwise, <c>false</c>.
        /// </returns>
        public static bool isSchweiz(object baLandID)
        {
            if (DBUtil.IsEmpty(baLandID))
            {
                return true;
            }

            if (baLandID is int && (int)baLandID == Session.BaLandCodeSchweiz)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Returns last day in month for a given DateTime. Original time passed in as parameter is
        /// not changed. Returned DateTime has anything below the precision of days set to 0 (hours,
        /// minutes, etc.).
        /// </summary>
        /// <param name="aDateRef">A DateTime for which the last day in the month will be determined</param>
        /// <returns></returns>
        public static DateTime lastDayOfMonth(DateTime aDateRef)
        {
            return firstDayOfMonth(aDateRef).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Modulo Ergebnis bestimmen, für Checken der IBAN Nummer
        /// </summary>
        /// <param name="sModulus"></param>
        /// <param name="iTeiler"></param>
        /// <returns>Modulo 97 number</returns>
        public static int Modulo(string sModulus, int iTeiler)
        {
            int iStart, iEnde, iErgebnis, iRestTmp, iBuffer;
            string sRest = "", sErg = "";

            iStart = 0;
            iEnde = 0;

            while (iEnde <= sModulus.Length - 1)
            {
                iBuffer = int.Parse(sRest + sModulus.Substring(iStart, iEnde - iStart + 1));

                if (iBuffer >= iTeiler)
                {
                    iErgebnis = iBuffer / iTeiler;
                    iRestTmp = iBuffer - iErgebnis * iTeiler;
                    sRest = iRestTmp.ToString();

                    sErg = sErg + iErgebnis.ToString();

                    iStart = iEnde + 1;
                    iEnde = iStart;
                }
                else
                {
                    if (sErg != "")
                        sErg = sErg + "0";

                    iEnde = iEnde + 1;
                }
            }

            if (iStart <= sModulus.Length)
                sRest = sRest + sModulus.Substring(iStart);

            return int.Parse(sRest);
        }

        /// <summary>
        /// Convert the specified value to format used on GUI.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns></returns>
        public static string money2gui(decimal d)
        {
            if (0 == d)
                return "0.--";
            else
                return d.ToString("#,#.00");
        }

        /// <summary>
        /// Open given url as new process
        /// </summary>
        /// <param name="url">The URL to open</param>
        /// <returns><c>True</c> if opening was successfull, otherwise <c>False</c></returns>
        public static bool OpenURL(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return false;
            }

            try
            {
                // create new process
                var process = new System.Diagnostics.Process
                {
                    StartInfo =
                        {
                            UseShellExecute = true,
                            Verb = "Open",
                            FileName = url
                        }
                };

                // start process
                return process.Start();
            }
            catch (Exception ex)
            {
                // show error message
                KissMsg.ShowError(CLASSNAME, "ErrorOpenLink", "Es ist ein Fehler beim Öffnen der URL aufgetreten.", ex);
                return false;
            }
        }

        /// <summary>
        /// Money Rounding: smallesUnit e.q. 0.10 for roundings to 1 decimal
        /// </summary>
        /// <param name="value">Value to round</param>
        /// <param name="smallestUnit">smallest unit used for rounding</param>
        /// <returns>Rounded Value</returns>
        public static Decimal RoundMoney(Decimal value, Decimal smallestUnit)
        {
            return Kiss.Infrastructure.Utils.Utils.RoundMoney(value, smallestUnit);
        }

        /// <summary>
        /// Lädt die GV-Status-Icons und fügt diese dem Bild Repository des Dev-Express DataGrids hinzu.
        /// In der LovCode Tabelle muss eine Referenz zu XIcon bestehen, die Spalte wird mit iconIdColumnName definiert.
        /// </summary>
        /// <param name="repStatusImg">Bildrepository</param>
        /// <param name="lovname">Name des LOV-Codes</param>
        /// <param name="iconIdColumnName">Spaltenname der Lovcode-Tabelle, wo das Icon referenziert wird </param>
        public static void SetStatusImageRepository(RepositoryItemImageComboBox repStatusImg, string lovname, int languageCode = 1, string iconIdColumnName = "Value1")
        {
            repStatusImg.SmallImages = KissImageList.SmallImageList;
            SqlQuery qryStatus =
                DBUtil.OpenSQL(
@"
                    SELECT
                      TextML = ISNULL(TXT.Text, LOV.Text),
                      LOV.*
                    FROM dbo.XLOVCode         LOV WITH (READUNCOMMITTED)
                      LEFT JOIN dbo.XLangText TXT WITH (READUNCOMMITTED) ON TXT.TID = LOV.TextTID
                                                                        AND TXT.LanguageCode = {0}
                    WHERE LOV.LOVName = {1}
                    ORDER BY LOV.SortKey;", languageCode, lovname);
            foreach (DataRow row in qryStatus.DataTable.Rows)
            {
                int imageId = 0;
                if (!DBUtil.IsEmpty(row[iconIdColumnName]))
                {
                    imageId = Convert.ToInt32(row[iconIdColumnName]);
                }
                repStatusImg.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                                           Convert.ToString(row["TextML"]),
                                           Convert.ToInt32(row[DBO.XLOVCode.Code]),
                                           KissImageList.GetImageIndex(imageId)));
            }
        }

        /// <summary>
        /// Truncate string object to maximum length if length is too big
        /// </summary>
        /// <param name="value">The string value to truncate</param>
        /// <param name="maxLength">The maximum allowed length of the string value (amount of chars within the string value)</param>
        /// <returns>The value or truncated string value</returns>
        public static object TruncateString(object value, int maxLength)
        {
            if (DBUtil.IsEmpty(value) ||
                !(value is string) ||
                value.ToString().Length <= maxLength)
            {
                return value;
            }

            return value.ToString().Substring(0, maxLength);
        }

        /// <summary>
        /// Shows a warning if the IBANKernel.dll is expired
        /// </summary>
        /// <param name="isSessionActive"><c>True</c> if session is active, otherwise <c>False</c></param>
        public static void WarningIfIBANExpired(bool isSessionActive)
        {
            // warning if IBAN DLL is expired (only admins)
            if (!isSessionActive ||
                (!Session.User.IsUserAdmin && !Session.User.IsUserBIAGAdmin) ||
                !DBUtil.GetConfigBool(@"System\Allgemein\IBANWarnmeldung", false))
            {
                return;
            }

            var ibanExDate = Belegleser.GetIBANExpirationDate();

            if (!ibanExDate.HasValue)
            {
                return;
            }

            int dayDiff = (ibanExDate.Value - DateTime.Today).Days;

            // if we have more than seven days left, we do not show any message
            if (dayDiff > 7)
            {
                return;
            }

            // get link from database: in case of changes, we're able to fix the link without having to fast change code
            string linkUrl = Convert.ToString(DBUtil.ExecuteScalarSQL(@"
                DECLARE @HyperLink VARCHAR(8000);

                SELECT @HyperLink = HyperLink
                FROM dbo.XHyperlink WITH (READUNCOMMITTED)
                WHERE Name = {0};

                SELECT ISNULL(@HyperLink, {1});", IBANKERNELDLL_UPDATE_LINKNAME, IBANKERNELDLL_UPDATE_DEFAULTLINK));

            string messageName = string.Empty;
            string message = string.Empty;
            string messageExpireMsgSecondPart = KissMsg.GetMLMessage(CLASSNAME,
                                                                     "IBANToolExpireMsgSecondPart_v01",
                                                                     "{1}{1}Bitte laden Sie die aktuellste Version mittels nachfolgendem Link herunter und kopieren Sie{1}die im Zip-Archiv enthaltene Datei 'IBANKernel.dll' in das KiSS Update- oder Installationsverzeichnis.{1}{1}Detailierte Informationen entnehmen Sie bitte dem KiSS-Handbuch für Systemadministratoren.{1}{1}Link:{1}{0}", linkUrl, Environment.NewLine);

            // warn before expire, show different message if expired (see check above)
            if (dayDiff >= 0)
            {
                messageName = "IBANToolWillSoonExpire_v05";
                message = @"Die Datei 'IBANKernel.dll' zur Überprüfung von IBAN-Nummern läuft in {0} Tag(en) am {1} ab.";
            }
            else
            {
                messageName = "IBANToolExpired_v05";
                message = @"Die Datei 'IBANKernel.dll' zur Überprüfung von IBAN-Nummern ist vor {0} Tag(en) am {1} abgelaufen.";
                dayDiff = -dayDiff;
            }

            string msgIbanExpire = KissMsg.GetMLMessage(CLASSNAME, messageName, message, dayDiff, ibanExDate.Value.ToShortDateString());
            string[] buttonList = { KissMsg.GetMLMessage(CLASSNAME, "IBANOkButton", "&Ok"),
                                    KissMsg.GetMLMessage(CLASSNAME, "IBANLinkButton_v01", "&Link öffnen") };

            if (KissMsg.ShowButtonDlg(msgIbanExpire + messageExpireMsgSecondPart, buttonList, Messages.DlgButtonPositionModes.dpmAutomatic, 0) == 1)
            {
                // open link
                OpenURL(linkUrl);
            }
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}