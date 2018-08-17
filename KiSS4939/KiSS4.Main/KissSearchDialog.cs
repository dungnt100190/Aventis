using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors.Controls;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Main
{
    /// <summary>
    /// Dialog to search and display the results of KissSearch.
    /// </summary>
    public partial class KissSearchDialog : KissDialog
    {
        /// <summary>
        /// Divers types to differ the results.
        /// </summary>
        public enum Types
        {
            Person,
            Fall,
            Leistung,
            Finanzplan,
            Budget,
            BgPosition
        }

        // The COLUMN_DESCRIPTION normally looks like this: "Name, Vorname"
        public const string COLUMN_DESCRIPTION = "Beschreibung";

        public const string COLUMN_FALL_ID = "FaFallID";

        public const string COLUMN_ID = "ID";

        public const string COLUMN_JUMP_TO_PATH = "JumpToPath";

        public const string COLUMN_LEISTUNG_ID = "FaLeistungID";

        public const string COLUMN_MODUL_ID = "ModulID";

        public const string COLUMN_PERSON_ID = "BaPersonID";

        public const string COLUMN_TYP = "Typ";

        private const string QUERY_BA_PERSON = @"
  --SQLCHECK_IGNORE--
            SELECT
              {1} = PRS.BaPersonID,
              {2} = 'P' + CONVERT(VARCHAR, PRS.BaPersonID),
              {3} = ISNULL(FAL.BaPersonID, PRS.BaPersonID),
              {4} = {9},
              {5} = PRS.Name + ISNULL(', ' + PRS.Vorname, '') + ISNULL(' (Fall: ' + PRSFALL.NameVorname + ' ' + CONVERT(VARCHAR, FAL.DatumVon, 104) + ISNULL( ' - ' + CONVERT(VARCHAR, FAL.DatumBis, 104), '') + ')', '')
                    + ISNULL(CASE WHEN {20} > cast('17530101' as datetime) THEN ', Geburtsdatum: ' + CONVERT(VARCHAR, PRS.Geburtsdatum,104)
                                  WHEN '{22}' != '' THEN ', N-Nummer: ' + PRS.NNummer
                             END, ''),
              {6} = 1,
              {7} = NULL,
              {8} = FAL.FaFallID
            FROM dbo.BaPerson      PRS WITH(READUNCOMMITTED)
              {19}
              LEFT JOIN dbo.vwPersonSimple PRSFALL WITH(READUNCOMMITTED) ON PRSFALL.BaPersonID = FAL.BaPersonID
            WHERE (
                    {0} != 0 AND PRS.BaPersonID = {0} OR
                    '{16}' != '' AND '{17}' = '' AND (PRS.Name LIKE '{16}%' OR PRS.Vorname LIKE '{16}%') OR
                    '{17}' != '' AND (PRS.Name LIKE '{16}%' AND PRS.Vorname LIKE '{17}%' OR   -- Suche nach Name Vorname
                                      PRS.Name LIKE '{17}%' AND PRS.Vorname LIKE '{16}%' OR   -- Suche nach Vorname Name
                                      PRS.Name LIKE '{16}% {17}%' OR                          -- Suche nach zwei Namen
                                      PRS.Vorname LIKE '{16}% {17}%') OR                      -- Suche nach zwei Vornamen
                    {20} > cast('17530101' as datetime) AND PRS.Geburtsdatum = {20} OR        -- Suche nach Geburtsdatum
                    '{21}' != '' AND PRS.Versichertennummer = '{21}' OR                       -- Suche nach Versichertennummer
                    '{22}' != '' AND dbo.fnRemoveCharactersByRegex(PRS.NNummer, '%[^0-9]%')  LIKE '{22}%' OR     -- Suche nach NNummer
                    '{23}' != '' AND (
                                    dbo.fnRemoveCharactersByRegex(PRS.Telefon_G, '%[^0-9]%') LIKE '{23}%' OR     -- Suche nach Telefon G
                                    dbo.fnRemoveCharactersByRegex(PRS.Telefon_P, '%[^0-9]%') LIKE '{23}%' OR     -- Suche nach Telefon P
                                    dbo.fnRemoveCharactersByRegex(PRS.MobilTel,  '%[^0-9]%') LIKE '{23}%' OR     -- Suche nach MobilTel
                                    dbo.fnRemoveCharactersByRegex(PRS.MobilTel1, '%[^0-9]%') LIKE '{23}%' OR     -- Suche nach MobilTel1
                                    dbo.fnRemoveCharactersByRegex(PRS.MobilTel2, '%[^0-9]%') LIKE '{23}%')       -- Suche nach MobilTel2
                  )
              AND (PRS.PersonSichtbarSDFlag = {18} OR PRS.PersonSichtbarSDFlag = 1)";

        private const string QUERY_BG_BUDGET = @"
            --SQLCHECK_IGNORE--
            SELECT DISTINCT
              {1} = {0},
              {2} = 'CtlWhFinanzplan' + CONVERT(VARCHAR(MAX), BDG.BgFinanzplanID) + '\BBG' + CONVERT(VARCHAR(MAX), BDG.BgBudgetID),
              {3} = PRS.BaPersonID,
              {4} = {13}, -- Typ = Budget
              {5} = PRS.NameVorname + ': Budget ' + RIGHT('0' + CONVERT(VARCHAR, BDG.Monat), 2) + ' ' + CONVERT(VARCHAR, BDG.Jahr),
              {6} = LEI.ModulID,
              {7} = LEI.FaLeistungID,
              {8} = FAL.FaFallID
            FROM dbo.BgBudget               BDG WITH(READUNCOMMITTED)
              INNER JOIN dbo.BgFinanzplan   FPL WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
              INNER JOIN dbo.FaLeistung     LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
              INNER JOIN dbo.FaFall         FAL WITH(READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID
              INNER JOIN dbo.vwPersonSimple PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
            WHERE BDG.BgBudgetID = {0}";

        private const string QUERY_BG_FINANZPLAN = @"
            --SQLCHECK_IGNORE--
            SELECT
              {1} = {0},
              {2} = 'CtlWhFinanzplan{0}',
              {3} = PRS.BaPersonID,
              {4} = {12},
              {5} = PRS.NameVorname + ': ' +
                      dbo.fnLOVMLText('WhHilfeTyp', FPL.WhHilfeTypCode, {15}) + ' ' +
                      CONVERT(VARCHAR, ISNULL(FPL.DatumVon, FPL.GeplantVon), 104) +
                      ISNULL(' - ' + CONVERT(VARCHAR, ISNULL(FPL.DatumBis, FPL.GeplantBis), 104), ''),
              {6} = LEI.ModulID,
              {7} = LEI.FaLeistungID,
              {8} = FAL.FaFallID
            FROM dbo.BgFinanzplan           FPL WITH(READUNCOMMITTED)
              INNER JOIN dbo.FaLeistung     LEI WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
              INNER JOIN dbo.FaFall         FAL WITH(READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID
              INNER JOIN dbo.vwPersonSimple PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
            WHERE FPL.BgFinanzplanID = {0}";

        private const string QUERY_BG_POSITION = @"
            --SQLCHECK_IGNORE--
            SELECT
              {1} = {0} ,
              {2} = 'CtlWhFinanzplan' + CONVERT(VARCHAR(MAX), BDG.BgFinanzplanID) + '\BBG' + CONVERT(VARCHAR(MAX), BDG.BgBudgetID),
              {3} = PRS.BaPersonID,
              {4} = {14}, -- Typ = BgPosition
              {5} = PRS.NameVorname + ': ' +
                      COALESCE(POS.Buchungstext, POA.Name, SPK.NameSpezkonto) + ISNULL(' (' + PRS1.NameVorname + ')', '') + ', ' +
                      CASE WHEN BDG.Masterbudget = 1
                      THEN 'Masterbudget'
                      ELSE RIGHT('0' + CONVERT(VARCHAR, BDG.Monat), 2) + ' ' + CONVERT(VARCHAR, BDG.Jahr)
                      END,
              {6} = LEI.ModulID,
              {7} = LEI.FaLeistungID,
              {8} = FAL.FaFallID
            FROM dbo.BgPosition             POS  WITH(READUNCOMMITTED)
              INNER JOIN dbo.BgBudget       BDG  WITH(READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
              INNER JOIN dbo.BgFinanzplan   FPL  WITH(READUNCOMMITTED) ON FPL.BgFinanzplanID = BDG.BgFinanzplanID
              INNER JOIN dbo.FaLeistung     LEI  WITH(READUNCOMMITTED) ON LEI.FaLeistungID = FPL.FaLeistungID
              INNER JOIN dbo.FaFall         FAL WITH(READUNCOMMITTED) ON FAL.FaFallID = LEI.FaFallID
              INNER JOIN dbo.vwPersonSimple PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID -- Leistungsträger
              LEFT  JOIN dbo.vwPersonSimple PRS1 WITH(READUNCOMMITTED) ON PRS1.BaPersonID = POS.BaPersonID -- betrigfft Person
              LEFT  JOIN dbo.BgSpezkonto    SPK  WITH(READUNCOMMITTED) ON SPK.BgSpezkontoID = POS.BgSpezkontoID
              LEFT  JOIN dbo.BgPositionsart POA  WITH(READUNCOMMITTED) ON POA.BgPositionsartID = COALESCE(POS.BgPositionsartID, SPK.BgPositionsartID)
            WHERE POS.BgPositionID = {0}";

        private const string QUERY_FA_FALL = @"
            --SQLCHECK_IGNORE--
            SELECT
              {1} = {0},
              {2} = NULL,
              {3} = PRS.BaPersonID,
              {4} = {10},
              {5} = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
              {6} = 2,
              {7} = NULL,
              {8} = FAL.FaFallID
            FROM dbo.FaFall           FAL WITH(READUNCOMMITTED)
              INNER JOIN dbo.BaPerson PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = FAL.BaPersonID
            WHERE FAL.FaFallID = {0}
              AND FAL.BaPersonID <> {0}
              AND (PRS.PersonSichtbarSDFlag = {18} OR PRS.PersonSichtbarSDFlag = 1)";

        private const string QUERY_FA_LEISTUNG = @"
            --SQLCHECK_IGNORE--
            SELECT
              {1} = {0},
              {2} = NULL,
              {3} = PRS.BaPersonID,
              {4} = {11},
              {5} = PRS.NameVorname + ISNULL(': ' + NULLIF(dbo.fnLOVMLText('FaProzess', LEI.FaProzessCode, {15}), ''), ''),
              {6} = LEI.ModulID,
              {7} = LEI.FaLeistungID,
              {8} = LEI.FaFallID
            FROM dbo.FaLeistung             LEI WITH(READUNCOMMITTED)
              INNER JOIN dbo.vwPersonSimple PRS WITH(READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
            WHERE FaLeistungID = {0}";

        private const string QUERY_IS_STANDARD = @"
            --SQLCHECK_IGNORE--
            SELECT CASE WHEN EXISTS(SELECT * FROM INFORMATION_SCHEMA.VIEWS WITH(READUNCOMMITTED) WHERE TABLE_NAME = 'FaFall') -- If the view exists, then its Standard
                THEN 1
                ELSE 0
            END";

        private const string SQL_ORDER_BY = " ORDER BY {4}, {5} ";

        private static readonly Regex _rxContainsOneNumber = new Regex(@"^(?=.*\d).*$", RegexOptions.Compiled);

        private static readonly Regex _rxNumbersOnly = new Regex(@"^\d+$", RegexOptions.Compiled);

        private static readonly Regex _rxVersichertenNummer = new Regex(@"^\d{3}\.\d{4}\.\d{4}\.\d{2}$", RegexOptions.Compiled);

        public KissSearchDialog(FrmMain parent)
        {
            InitializeComponent();
            MdiParent = parent;
        }

        public static HybridDictionary GetJumpToPathDictionary(DataRow row, bool addClassName)
        {
            var id = row[COLUMN_ID]; //auf das zugreifen was der Benutzer ausgewählt hat.

            if (id != null)
            {
                HybridDictionary result;

                switch (Utils.ConvertToInt(row[COLUMN_TYP]))
                {
                    case (int)Types.Person:
                        result = FormController.GetHybridDictionaryFromParameters(
                            FormController.Param.ACTION,
                            "JumpToNodeByFieldValue",
                            FormController.Param.BA_PERSON_ID,
                            row[COLUMN_PERSON_ID],
                            "FieldName",
                            "ID",
                            "FieldValue",
                            row[COLUMN_JUMP_TO_PATH],
                            FormController.Param.MODUL_ID,
                            row[COLUMN_MODUL_ID]);
                        break;

                    case (int)Types.Fall:
                        result = FormController.GetHybridDictionaryFromParameters(
                            FormController.Param.ACTION,
                            FormController.Action.SHOW_FALL,
                            FormController.Param.FA_FALL_ID,
                            row[COLUMN_FALL_ID],
                            FormController.Param.BA_PERSON_ID,
                            row[COLUMN_PERSON_ID],
                            FormController.Param.MODUL_ID,
                            row[COLUMN_MODUL_ID]);
                        break;

                    case (int)Types.Leistung:
                    case (int)Types.Finanzplan:
                    case (int)Types.Budget:
                        result = FormController.GetHybridDictionaryFromParameters(
                            FormController.Param.ACTION,
                            FormController.Action.JUMP_TO_PATH,
                            FormController.Param.FA_FALL_ID,
                            row[COLUMN_FALL_ID],
                            FormController.Param.BA_PERSON_ID,
                            row[COLUMN_PERSON_ID],
                            FormController.Param.MODUL_ID,
                            row[COLUMN_MODUL_ID],
                            FormController.Param.FA_LEISTUNG_ID,
                            row[COLUMN_LEISTUNG_ID],
                            FormController.Param.TREE_NODE_ID,
                            row[COLUMN_JUMP_TO_PATH]);
                        break;

                    case (int)Types.BgPosition:
                        result = FormController.GetHybridDictionaryFromParameters(
                            FormController.Param.ACTION,
                            FormController.Action.JUMP_TO_PATH,
                            FormController.Param.FA_FALL_ID,
                            row[COLUMN_FALL_ID],
                            FormController.Param.BA_PERSON_ID,
                            row[COLUMN_PERSON_ID],
                            FormController.Param.MODUL_ID,
                            row[COLUMN_MODUL_ID],
                            FormController.Param.FA_LEISTUNG_ID,
                            row[COLUMN_LEISTUNG_ID],
                            FormController.Param.TREE_NODE_ID,
                            row[COLUMN_JUMP_TO_PATH],
                            FormController.Param.ACTIVESQLQUERY_FIND,
                            string.Format("BgPositionID = {0}", id));
                        break;

                    default:
                        result = FormController.GetHybridDictionaryFromParameters(
                        FormController.Param.ACTION,
                        FormController.Action.SHOW_FALL,
                        FormController.Param.FA_FALL_ID,
                        row[COLUMN_FALL_ID],
                        FormController.Param.BA_PERSON_ID,
                        row[COLUMN_PERSON_ID],
                        FormController.Param.MODUL_ID,
                        row[COLUMN_MODUL_ID],
                        FormController.Param.FA_LEISTUNG_ID,
                        row[COLUMN_LEISTUNG_ID]);
                        break;
                }

                if (addClassName)
                {
                    result.Add(FormController.Param.CLASS_NAME, FormController.Forms.FALL);
                }

                return result;
            }

            return null;
        }

        public static string GetSearchQuery(string text, int? maxRows = null)
        {
            // Prevent injections
            text = text.Replace("'", "''");

            // Wildcards durch SQL-gültige Wildcards ersetzen
            text = text.Replace("*", "%");
            text = text.Replace("?", "_");

            var splitted = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var searchQuery = "";

            // lower case makes conditions simpler
            text = text.ToLower();
            var trimmed = text.Replace(" ", string.Empty);
            /* Searching for:
                * BaPerson.BaPersonID              PersonID
                * FaFall.FaFallID                  FaFallID
                * BgFinanzplan.BgFinanzplanID      FinanzplanID
                * FaLeistung.FaLeistungID          FaLeistungID
                * BgPosition.BgPositionID          BgPosition
                * BgBudget.BgBudgetID              BgBudget
                */
            int personSichtbarSdFlag = Session.User.IsUserKA ? 0 : 1;

            // if we are on Standard take the BaPersonID, if we are on ZH take the HauptpersonFuerMitglied
            string takeBaPersonID;
            if (Convert.ToBoolean(DBUtil.ExecuteScalarSQL(QUERY_IS_STANDARD)))
            {
                takeBaPersonID = "LEFT JOIN dbo.FaFall FAL WITH(READUNCOMMITTED) ON FAL.BaPersonID = PRS.BaPersonID";
            }
            else
            {
                takeBaPersonID = @"LEFT JOIN dbo.FaFallPerson FAP WITH (READUNCOMMITTED) ON FAP.BaPersonID = PRS.BaPersonID
              LEFT JOIN dbo.FaFall FAL WITH(READUNCOMMITTED) ON FAL.FaFallID = FAP.FaFallID";
            }

            var searchParameters = new object[]
            {
                0, // {0} ID Suchparameter
                COLUMN_ID, // {1}
                COLUMN_JUMP_TO_PATH, // {2}
                COLUMN_PERSON_ID, // {3}
                COLUMN_TYP, // {4}
                COLUMN_DESCRIPTION, // {5}
                COLUMN_MODUL_ID, // {6}
                COLUMN_LEISTUNG_ID, // {7}
                COLUMN_FALL_ID, // {8}
                (int)Types.Person, // {9}
                (int)Types.Fall, // {10}
                (int)Types.Leistung, // {11}
                (int)Types.Finanzplan, // {12}
                (int)Types.Budget, // {13}
                (int)Types.BgPosition, // {14}
                Session.User.LanguageCode, // {15}
                string.Empty, // {16} Name
                string.Empty, // {17} Vorname,
                personSichtbarSdFlag, // {18}
                takeBaPersonID, // {19}
                DBUtil.SqlLiteral(new DateTime(1753, 1, 1)), // {20} Geburtsdatum
                string.Empty, // {21} Versichertennummer
                string.Empty, // {22} NNummer
                string.Empty // {23} Telefonnummer
            };

            DateTime geburtsdatum;

            if (_rxNumbersOnly.IsMatch(trimmed))
            {
                searchParameters[0] = trimmed;
                var queryJoined = new List<string>
                {
                    QUERY_BA_PERSON,
                    QUERY_BG_BUDGET,
                    QUERY_BG_FINANZPLAN,
                    QUERY_BG_POSITION,
                    QUERY_FA_FALL,
                    QUERY_FA_LEISTUNG
                };
                string searchQueryCombined = string.Join(" UNION ALL ", queryJoined.ToArray()) + SQL_ORDER_BY;
                searchQuery = string.Format(searchQueryCombined, searchParameters);
            }
            // Wenn suchtext in Datum geparst werden kann -> suche nach Geburtsdatum
            else if (DateTime.TryParse(trimmed, out geburtsdatum) &&
                     geburtsdatum >= (DateTime)SqlDateTime.MinValue &&
                     geburtsdatum <= (DateTime)SqlDateTime.MaxValue)
            {
                searchParameters[20] = DBUtil.SqlLiteral(geburtsdatum);
                searchQuery = string.Format(QUERY_BA_PERSON + SQL_ORDER_BY, searchParameters);
            }
            // Wenn Regex mach mit Versichertennummer Spez, dann Suche nach Versicherten-Nr.
            else if (_rxVersichertenNummer.IsMatch(trimmed))
            {
                searchParameters[21] = trimmed;
                searchQuery = string.Format(QUERY_BA_PERSON + SQL_ORDER_BY, searchParameters);
            }
            // Wenn Präfix mit n anfängt, wird nach NNummer gesucht Die NNummer muss eine Zahl
            // dabeihaben, sonst wird nicht danach gesucht
            else if (text.StartsWith("n") && _rxContainsOneNumber.IsMatch(trimmed.Substring(1)))
            {
                searchParameters[22] = Regex.Replace(trimmed.Substring(1), "[^.0-9]", "");
                searchQuery = string.Format(QUERY_BA_PERSON + SQL_ORDER_BY, searchParameters);
            }
            // Wenn Präfix mit t anfängt, dann wird nach Telefonnummer gesucht.
            else if (text.StartsWith("t") && _rxNumbersOnly.IsMatch(trimmed.Substring(1)))
            {
                searchParameters[23] = trimmed.Substring(1);
                searchQuery = string.Format(QUERY_BA_PERSON + SQL_ORDER_BY, searchParameters);
            }
            // Wenn ein Zahlenstring mit P anfängt dann wird gleich zur PersonID gesprungen
            else if (text.StartsWith("p") && _rxNumbersOnly.IsMatch(trimmed.Substring(1)))
            {
                searchParameters[0] = trimmed.Substring(1);
                searchQuery = string.Format(QUERY_BA_PERSON + SQL_ORDER_BY, searchParameters);
            }
            // Wenn ein Zahlenstring mit FP anfängt dann wird gleich zum Finanzplan gesprungen
            else if (text.StartsWith("fp") && _rxNumbersOnly.IsMatch(trimmed.Substring(2)))
            {
                searchParameters[0] = trimmed.Substring(2);
                searchQuery = string.Format(QUERY_BG_FINANZPLAN + SQL_ORDER_BY, searchParameters);
            }
            // Wenn ein Zahlenstring mit F anfängt dann wird gleich zum Fall gesprungen
            else if (text.StartsWith("f") && _rxNumbersOnly.IsMatch(trimmed.Substring(1)))
            {
                searchParameters[0] = trimmed.Substring(1);
                searchQuery = string.Format(QUERY_FA_FALL + SQL_ORDER_BY, searchParameters);
            }
            // Wenn ein Zahlenstring mit L anfängt dann wird gleich zur Leistung gesprungen
            else if (text.StartsWith("l") && _rxNumbersOnly.IsMatch(trimmed.Substring(1)))
            {
                searchParameters[0] = trimmed.Substring(1);
                searchQuery = string.Format(QUERY_FA_LEISTUNG + SQL_ORDER_BY, searchParameters);
            }
            else if (splitted.Length == 1)
            {
                searchParameters[16] = splitted[0]; // {16}

                searchQuery = string.Format(QUERY_BA_PERSON + SQL_ORDER_BY, searchParameters);
            }
            /* Searching for multiple Strings in:
             * BaPerson.Name and BaPerson.Vorname
             */
            else if (splitted.Length > 1)
            {
                searchParameters[16] = splitted[0]; // {16}
                searchParameters[17] = splitted[1]; // {17}
                searchQuery = string.Format(QUERY_BA_PERSON + SQL_ORDER_BY, searchParameters);
            }
            if (maxRows != null)
            {
                // Only replace the first SELECT
                var posSelect = searchQuery.IndexOf("SELECT", StringComparison.InvariantCultureIgnoreCase);
                var posDistinct = searchQuery.IndexOf("DISTINCT", StringComparison.InvariantCultureIgnoreCase);
                var replaceWith = String.Format(" TOP {0}", maxRows);

                var lenSelect = 6;
                if (posDistinct == posSelect + 7)
                {
                    lenSelect = 15;
                }
                searchQuery = searchQuery.Substring(0, posSelect + lenSelect) + replaceWith +
                              searchQuery.Substring(posSelect + lenSelect + replaceWith.Length);
            }

            return searchQuery;
        }

        /// <summary>
        /// The main method to find results.
        /// </summary>
        /// <param name="text">Input text</param>
        public void SearchKissData(String text)
        {
            if (string.IsNullOrWhiteSpace(text) || !Fill(GetSearchQuery(text)))
            {
                return;
            }

            lblSuchbegriff.Text = string.Format(KissMsg.GetMLMessage(typeof(KissSearchDialog).Name, "Suchbegriff", "Suchbegriff: {0}"), text);
            Show();
            grd.Focus();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ShowMask();
        }

        private bool Fill(string searchQuery)
        {
            if (!qry.Fill(searchQuery))
            {
                // fill() failed due to unknown reason, show message and cancel
                KissMsg.ShowInfo("KissLookupDialog", "ErrorFillInSearchData", "Die Daten konnten nicht geladen werden, die Suche wird abgebrochen.");
                return false;
            }

            if (qry.Count == 0)
            {
                // no data found
                KissMsg.ShowInfo("KissLookupDialog", "KeineDatensaetze", "Keine zutreffenden Datensätze gefunden.");
                return false;
            }

            if (qry.Count == 1)
            {
                // if there is only 1 result found, open the mask directly
                ShowMask();
                return false;
            }

            // apply datasource
            grd.DataSource = qry;

            return true;
        }

        private void grd_DoubleClick(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
        }

        /// <summary>
        /// Loading the KissSearchDialog contains the showing of Row-Icons.
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">eventargs</param>
        private void KissSearchDialog_Load(object sender, EventArgs e)
        {
            repositoryItemImageComboBox1.SmallImages = KissImageList.SmallImageList;

            foreach (DataRow row in qry.DataTable.Rows)
            {
                int imageIndex = 0;

                switch ((int)row[COLUMN_TYP])
                {
                    case (int)Types.Person:
                        // Demographie
                        imageIndex = 133;
                        break;

                    case (int)Types.Fall:
                        // Fallnavigator
                        imageIndex = 181;
                        break;

                    case (int)Types.Leistung:
                        switch ((int)row[COLUMN_MODUL_ID])
                        {
                            case 2:
                                imageIndex = 1201;
                                break;

                            case 3:
                                imageIndex = 1301;
                                break;

                            case 4:
                                imageIndex = 1401;
                                break;

                            case 5:
                                imageIndex = 1501;
                                break;

                            case 6:
                                imageIndex = 1601;
                                break;

                            case 7:
                                imageIndex = 1701;
                                break;

                            case 8:
                                imageIndex = 1801;
                                break;
                        }
                        break;

                    case (int)Types.Finanzplan:
                        // Bew. Finanzplan
                        imageIndex = 1314;
                        break;

                    case (int)Types.Budget:
                        // Masterbudget
                        imageIndex = 1322;
                        break;

                    case (int)Types.BgPosition:
                        // grüne Position
                        imageIndex = 1352;
                        break;
                }

                repositoryItemImageComboBox1.Items.Add(
                    new ImageComboBoxItem("", (int)row[COLUMN_TYP], KissImageList.GetImageIndex(imageIndex)));
            }
        }

        /// <summary>
        /// If a row is selected and the btnOK is clicked, the referenced Mask will be shown (Absprung).
        /// </summary>
        private void ShowMask()
        {
            var id = qry[COLUMN_ID]; //auf das zugreifen was der Benutzer ausgewählt hat.

            if (id != null)
            {
                var itemFound = FormController.OpenForm(FormController.Forms.FALL, GetJumpToPathDictionary(qry.Row, false));

                // Aktion war nicht erfolgreich, führe ShowFall aus
                if (!itemFound)
                {
                    itemFound = FormController.OpenForm(
                        FormController.Forms.FALL,
                        FormController.Param.ACTION,
                        FormController.Action.SHOW_FALL,
                        FormController.Param.FA_FALL_ID,
                        qry[COLUMN_FALL_ID],
                        FormController.Param.BA_PERSON_ID,
                        qry[COLUMN_PERSON_ID],
                        FormController.Param.MODUL_ID,
                        qry[COLUMN_MODUL_ID],
                        FormController.Param.FA_LEISTUNG_ID,
                        qry[COLUMN_LEISTUNG_ID]);
                }

                if (itemFound)
                {
                    Close();
                }
            }
        }
    }
}