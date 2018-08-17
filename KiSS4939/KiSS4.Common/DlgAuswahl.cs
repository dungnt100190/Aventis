using System;
using System.Text.RegularExpressions;
using DevExpress.Utils;
using KiSS.DBScheme;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Common
{
    /// <summary>
    /// Values from LOV KaKursSekt + Praesenzzeiterfassung
    /// </summary>
    public enum KaKurssucheCaller
    {
        /// <summary>
        /// K - Allgemein - Bildung - Integrierte Bildung
        /// </summary>
        IntegrierteBildung = 1,

        /// <summary>
        /// Momentan nicht verwendet
        /// </summary>
        InternerKursVermittlung = 2,

        /// <summary>
        /// </summary>
        Abklaerung = 3,

        /// <summary>
        /// KA - Praesenzzeiterfassung - Suche
        /// </summary>
        Praesenzzeiterfassung = 99
    }

    /// <summary>
    /// Summary description for DlgAuswahl.
    /// </summary>
    public partial class DlgAuswahl : KissLookupDialog
    {
        private const string CLASSNAME = "DlgAuswahl";

        private const string SELECT_ADRESSAT = @"
            SELECT
                ID$ = ID,
                TypCode$ = TypCode,
                Typ = dbo.fnLOVMLText('BaAdressatTyp', TypCode, {2}),
                Name,
                Strasse,
                Ort
            FROM dbo.vwBaAdressate
            WHERE Name LIKE '%' + {0} + '%'
            AND (1 = {1} OR TypCode <> 3)
            ORDER BY Name";

        /// <summary>
        /// Wenn der User bei der Suche nach einem Adressat einen
        /// Punkt eingibt, dann werden die Adressate von der Person
        /// Berücksichtigt.
        /// </summary>
        private const string SELECT_ADRESSAT_POINT = @"
           DECLARE @BaPersonID  INT;
           SELECT @BaPersonID = LEI.BaPersonID
           FROM dbo.FaLeistung LEI
           WHERE LEI.FaLeistungID = {0};

           SELECT
               ID$      = PRS.BaPersonID,
               TypCode$ = 1,
               Typ      = dbo.fnLOVMLText('BaAdressatTyp', 1, {1}),
               Name     = PRS.NameVorname,
               Strasse  = PRS.WohnsitzStrasseHausNr,
               Ort      = PRS.WohnsitzPLZOrt
            FROM vwPerson   PRS
            WHERE
              PRS.BaPersonID IN
             (SELECT BaPersonID_1 FROM BaPerson_Relation WHERE BaPersonID_2 = @BaPersonID
              UNION ALL
              SELECT BaPersonID_2 FROM BaPerson_Relation WHERE BaPersonID_1 = @BaPersonID
              UNION ALL
              SELECT @BaPersonID)
            UNION ALL
            SELECT
              ID$      = INS.BaInstitutionID,
              TypCode$ = 2,
              Typ      = dbo.fnLOVMLText('BaAdressatTyp', 2, {1}),
              Name     = INS.Name,
              Strasse  = INS.StrasseHausNr,
              Ort      = INS.PLZOrt
            FROM vwInstitution                  INS
              INNER JOIN BaPerson_BaInstitution DPO ON DPO.BaInstitutionID = INS.BaInstitutionID
            WHERE
              DPO.BaPersonID IN
               (SELECT BaPersonID_1 FROM BaPerson_Relation WHERE BaPersonID_2 = @BaPersonID
               UNION ALL
               SELECT BaPersonID_2 FROM BaPerson_Relation WHERE BaPersonID_1 = @BaPersonID
               UNION ALL
               SELECT @BaPersonID)
               AND INS.Aktiv = 1
            ORDER BY Typ DESC, Name";

        private string _filterColumnName;

        private bool _showFilter;

        /// <summary>
        /// Initializes a new instance of the <see cref="DlgAuswahl"/> class.
        /// </summary>
        public DlgAuswahl()
        {
            InitializeComponent();
        }

        public string FilterColumnName
        {
            get { return _filterColumnName; }
            set { _filterColumnName = value; }
        }

        public bool ShowFilter
        {
            get { return _showFilter; }
            set
            {
                _showFilter = value;
                ShowFilterOrCountIfColumnNameFilled();
            }
        }

        /// <summary>
        /// Sucht nach dem Adressat. Ist entweder BaPerson oder BaInstitution.
        /// Gibt der User einen Punkt ein, dann werden BaPersonen oder BaInstutionen
        /// berücksichtigt, welche eine Beziehung mit dem Fallträger (BaPerson)
        /// haben.
        /// </summary>
        /// <param name="suchbegriff">Der Suchbegriff</param>
        /// <param name="openDialog">Ob ein Dialog geöffnet werden soll</param>
        /// <param name="faLeistungid">Die Leistungsid, kann auch 0 sein. Dann
        ///  ist aber die Suche mit einem Punkt nicht möglich.</param>
        /// <param name="priMa">Falls die privaten Mandatsträger auch in der Auswahl erscheinen sollen</param>
        /// <returns></returns>
        public bool AdressatSuchen(string suchbegriff, int faLeistungid, bool openDialog, bool priMa)
        {
            ResultRow = null;
            int showPriMa = 1;
            if (!priMa)
            {
                showPriMa = 0;
            }

            if (".".Equals(suchbegriff) && faLeistungid > 0)
            {
                qry.Fill(SELECT_ADRESSAT_POINT, faLeistungid, Session.User.LanguageCode);
            }
            else
            {
                suchbegriff = PrepareSearchString(suchbegriff);
                qry.Fill(SELECT_ADRESSAT, suchbegriff, showPriMa, Session.User.LanguageCode);
            }

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineAdressatenGefunden", "Keine zutreffende Adressate gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Typ", "Typ", 90);
            AddGridColumn("Name", "Name", 200);
            AddGridColumn("Strasse", "Strasse", 200);
            AddGridColumn("Ort", "Ort", 200);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Kasse suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool ALKasseSuchen(string suchbegriff, bool open)
        {
            return ALKasseSuchen(suchbegriff, -1, false, open);
        }

        /// <summary>
        /// Dialog: Kasse suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="baInstitutionTypId">The institution typ code.</param>
        /// <param name="nurAktive">if set to <c>true</c> [nur aktive].</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool ALKasseSuchen(string suchbegriff, int baInstitutionTypId, bool nurAktive, bool open)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace("*", "%");
            suchbegriff = suchbegriff.Replace(" ", "");
            suchbegriff = suchbegriff + ",";

            var searchVals = suchbegriff.Split(',');

            const string sql = @"
                SELECT INS.*,
                       Adresse = INS.Adresse,
                       Typen   = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', {4}, {5})
                FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
                WHERE ((REPLACE(INS.NameVorname, ' ', '') LIKE {0} OR REPLACE(INS.InstitutionNr, ' ', '') LIKE {0}) AND
                       (REPLACE(INS.NameVorname, ' ', '') LIKE {3} OR REPLACE(INS.InstitutionNr, ' ', '') LIKE {3})) AND
                      ({1} = -1 OR (',' + dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 1, ',', {4}, 1) + ',' LIKE '%,' + CONVERT(VARCHAR(20), {1}) + ',%')) AND
                      ({2} = 0 OR INS.Aktiv = 1)
                ORDER BY INS.NameVorname";

            qry.Fill(sql, searchVals[0] + "%", baInstitutionTypId, nurAktive, searchVals[1] + "%", Session.User.UserID, Session.User.LanguageCode);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineInstitutionGefunden", "Keine zutreffenden Institutionen gefunden");
                return false;
            }

            if (qry.Count == 1)
            {
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            AddGridColumn("Inst. Nr", "InstitutionNr", 80);
            AddGridColumn("Name", "Name", 180);
            AddGridColumn("Adresse", "Adresse", 200);
            AddGridColumn("Typen", "Typen", 150);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Unterstützte Person suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool AyUnterstuetztePersonSuchen(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            string sql = @"
                SELECT DISTINCT
                       PRS.BaPersonID,
                       Name    = PRS.NameVorname,
                       Strasse = PRS.WohnsitzStrasseHausNr,
                       PLZOrt  = PRS.WohnsitzPLZOrt,
                       FT      = CONVERT(BIT, CASE WHEN EXISTS(SELECT TOP 1 1
                                                               FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                                               WHERE LEI.BaPersonID = PRS.BaPersonID AND
                                                                     ModulID = 6) THEN 1
                                                   ELSE 0
                                              END)
                FROM dbo.vwPerson PRS WITH (READUNCOMMITTED)
                WHERE EXISTS(SELECT TOP 1 1
                             FROM dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED)
                               INNER JOIN dbo.BgFinanzplan SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = SPP.BgFinanzplanID
                               INNER JOIN dbo.FaLeistung   FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = SFP.FaLeistungID
                             WHERE SPP.BaPersonID = PRS.BaPersonID AND
                                   SPP.IstUnterstuetzt = 1 AND
                                   FAL.ModulID = 6) ";

            try
            {
                sql += string.Format("AND PRS.BaPersonID = {0}", Convert.ToInt32(suchbegriff));
            }
            catch
            {
                suchbegriff = PrepareSearchString(suchbegriff);

                sql += "AND PRS.Name + ISNULL(', ' + PRS.Vorname, '') LIKE " + DBUtil.SqlLiteralLike(suchbegriff + "%") + " ";
            }

            sql += "ORDER BY Name";

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineUnterstPersonGefunden", "Keine zutreffende, unterstützte Person gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("FT", "FT", 35);
            AddGridColumn("P-Nr.", "BaPersonID", 72);
            AddGridColumn("unterstützte Person", "Name", 200);
            AddGridColumn("Strasse", "Strasse", 150);
            AddGridColumn("Ort", "PLZOrt", 110);

            return DisplayDialog();
        }

        public bool BerechnungspersonenSuchen()
        {
            ResultRow = null;

            qry.Fill(@"
                SELECT BaPersonID,
                       Berechnungsperson = Name + ISNULL(', ' + Vorname, '') + ISNULL(' (' + CONVERT(VARCHAR, DATEPART(YEAR, Geburtsdatum)) + ')', '')
                FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
                WHERE IstBerechnungsperson = 1
                ORDER BY 2;");
            ResultRow = qry.Row;

            AddGridColumn("Auswahl", "Berechnungsperson", 320);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Beruf suchen
        /// </summary>
        /// <param name="berufNameGenerisch">The name of the occupation</param>
        /// <param name="genderCode">The gender code if gender specific value shall be displayed (1=m, 2=w, other=generic)</param>
        /// <returns>True if successfully selected an entry, otherwise false</returns>
        public bool BerufSuchen(string berufNameGenerisch, int genderCode)
        {
            ResultRow = null;

            // validate
            berufNameGenerisch = string.IsNullOrEmpty(berufNameGenerisch) ? "%" : PrepareSearchString(berufNameGenerisch);

            const string sql = @"
                    DECLARE @GenderCode INT
                    SET @GenderCode = {1}

                    SELECT BRF.*,
                           Text = CASE WHEN @GenderCode = 1 THEN BRF.BezeichnungM
                                       WHEN @GenderCode = 2 THEN BRF.BezeichnungW
                                       ELSE BRF.Beruf
                                  END
                    FROM dbo.BaBeruf BRF WITH (READUNCOMMITTED)
                    WHERE (@GenderCode = 1 AND BRF.BezeichnungM LIKE {0}) OR
                          (@GenderCode = 2 AND BRF.BezeichnungW LIKE {0}) OR
                          (@GenderCode NOT IN (1, 2) AND BRF.Beruf LIKE {0})
                    ORDER BY BRF.SortKey, BRF.Beruf";

            qry.Fill(sql, berufNameGenerisch + '%', genderCode);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeinBerufGefunden", "Keinen zutreffenden Beruf gefunden.");
                return false;
            }

            if (qry.Count == 1)
            {
                ResultRow = qry.Row;
                return true;
            }

            // add desired columns depending on given gender code
            switch (genderCode)
            {
                case 1:
                    // masculine
                    AddGridColumn("Beruf (m)", "BezeichnungM", 300);
                    break;

                case 2:
                    // feminie
                    AddGridColumn("Beruf (w)", "BezeichnungW", 300);
                    break;

                default:
                    // generic
                    AddGridColumn("Beruf", "Beruf", 350);
                    break;
            }

            // show dialog and return result
            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Betrieb suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool BetriebKASuchen(string suchbegriff, bool open)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace(" ", "%").Replace("*", "%").Replace("?", "_");

            const string sql = @"
                SELECT BET.*,
                       Betrieb        = BET.BetriebName,
                       BetriebStrasse = ADR.Strasse + ISNULL(' ' + ADR.HausNr, ''),
                       BetriebOrt     = ADR.PLZ + ISNULL(' ' + ADR.Ort, ''),
                       BetriebID      = BET.KaBetriebID
                FROM dbo.KaBetrieb BET WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.KaBetriebID = BET.KaBetriebID
                WHERE BET.BetriebName LIKE {0}
                ORDER BY BET.BetriebName";

            qry.Fill(sql, suchbegriff + "%");

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineBetriebeGefunden", "Keinen zutreffenden Betrieb gefunden");
                return false;
            }

            if (qry.Count == 1 && !open)
            {
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            AddGridColumn("Name", "Betrieb", 180);
            AddGridColumn("Strasse", "BetriebStrasse", 150);
            AddGridColumn("PLZ / Ort", "BetriebOrt", 150);

            return DisplayDialog();
        }

        public bool BgKostenartSuchen(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == string.Empty)
            {
                return true;
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            string sql = string.Format(@"
                SELECT KST.BgKostenartID,
                       KST.ModulID,
                       KST.Name,
                       KST.KontoNr,
                       [Weiterverrechenbar] = CASE WHEN KST.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
                       KST.Quoting,
                       KST.BgSplittingArtCode
                FROM dbo.BgKostenart KST WITH (READUNCOMMITTED)
                WHERE KST.Name LIKE {0}
                  OR  KST.KontoNr LIKE {0}",
                DBUtil.SqlLiteralLike(suchbegriff + "%"));

            qry.Fill(sql);

            if (qry.IsEmpty)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineKostenartGefunden", "Keine zutreffende Kostenart gefunden.");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Name", DBO.BgKostenart.Name, 250);
            AddGridColumn("Konto", DBO.BgKostenart.KontoNr, 100);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog BuchungsCode suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool BuchungsCodeSuchen(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace("*", "%");

            string sql = string.Format(@"
                SELECT *
                FROM dbo.viewFbBuchungCode
                WHERE Code LIKE {0} AND
                      ISNULL(UserID, {1}) = {1}
                ORDER BY Code", DBUtil.SqlLiteralLike(suchbegriff + "%"), Session.User.UserID);

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineBuchungscodesGefunden", "Keine zutreffenden Buchungscodes gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Code", "Code", 80);
            AddGridColumn("Mandant", "Mandant", 147);
            AddGridColumn("Soll", "SollKtoNr", 59);
            AddGridColumn("Haben", "HabenKtoNr", 59);
            AddGridColumn("Text", "Text", 230);
            AddGridColumn("Betrag", "Betrag", 109);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: fachbereich suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool FachbereichSuchen(string suchbegriff, bool open)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace(" ", "%");

            const string sql = @"
                SELECT XLC.*
                FROM dbo.XLOVCode XLC WITH (READUNCOMMITTED)
                WHERE XLC.Text LIKE {0} AND
                      XLC.LOVName = 'KAFachbereich'
                ORDER BY XLC.Text";

            qry.Fill(sql, suchbegriff + "%");

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineFachbereicheGefunden", "Keinen zutreffenden Fachbereich gefunden");
                return false;
            }

            if (qry.Count == 1 && !open)
            {
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            AddGridColumn("Fachbereich", "Text", 180);
            AddGridColumn("Abteilung", "Value1", 100);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Heimatort suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool HeimatortSuchen(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace("*", "%");

            qry.Fill(@"
                SELECT GDE.*,
                       Heimatort = GDE.Name + ISNULL(' ' + GDE.Kanton, ''),
                       Code      = GDE.BaGemeindeID,
                       Text      = GDE.Name,
                       Value1    = GDE.PLZ,
                       Value2    = GDE.Kanton
                FROM dbo.BaGemeinde GDE WITH (READUNCOMMITTED)
                WHERE (GDE.Name + ISNULL(' ' + GDE.Kanton, '')) LIKE {0} + '%'
                ORDER BY GDE.Name;", suchbegriff);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineHeimatorteGefunden_v01", "Es wurden keine zutreffenden Heimatorte gefunden.");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("PLZ", DBO.BaGemeinde.PLZ, 50);
            AddGridColumn("Ort", DBO.BaGemeinde.Name, 250);
            AddGridColumn("Kanton", DBO.BaGemeinde.Kanton, 80);
            AddGridColumn("BFS Code", DBO.BaGemeinde.BFSCode, 80);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Abteilung suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool InstAbeilungSuchen(string suchbegriff, bool open)
        {
            return InstAbeilungSuchen(suchbegriff, -1, false, open);
        }

        /// <summary>
        /// Dialog: Abteilung suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="baInstitutionTypId">The institution typ code.</param>
        /// <param name="nurAktive">if set to <c>true</c> [nur aktive].</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool InstAbeilungSuchen(string suchbegriff, int baInstitutionTypId, bool nurAktive, bool open)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace("*", "%");

            const string sql = @"
                SELECT OrgID      = INS.BaInstitutionID,
                       OrgName    = INS.Name,
                       Adresse    = INS.Adresse,
                       Typen      = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', {3}, {4})
                FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
                WHERE INS.NameVorname LIKE {0}
                  AND ({1} = -1 OR (',' + dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 1, ',', {3}, 1) + ',' LIKE '%,' + CONVERT(VARCHAR(20), {1}) + ',%'))
                  AND ({2} = 0 OR INS.Aktiv = 1)

                UNION ALL

                SELECT OrgID    = -ORG.OrgUnitID,
                       OrgName  = ORG.ItemName,
                       Adresse  = '',
                       Typen    =  dbo.fnGetMLTextFromName('DlgAuswahl', 'TypAbteilung', {4})
                FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                WHERE ORG.ItemName LIKE {0}
                ORDER BY OrgName;";

            qry.Fill(sql, suchbegriff + "%", baInstitutionTypId, nurAktive, Session.User.UserID, Session.User.LanguageCode);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineAbteilungGefunden", "Keine zutreffenden Institutionen/Abteilung gefunden");
                return false;
            }

            if (qry.Count == 1 && !open)
            {
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            AddGridColumn("Name", "OrgName", 180);
            AddGridColumn("Adresse", "Adresse", 200);
            AddGridColumn("Typen", "Typen", 150);

            return DisplayDialog();
        }

        /// <summary>
        /// Search institution with dialog, show active and inactive entries, all types
        /// </summary>
        /// <param name="searchValue">Search value for institution</param>
        /// <param name="openDialog">Show dialog or autoselect value if only one value found</param>
        /// <returns>True if value was found, otherwise false</returns>
        public bool InstitutionSuchen(string searchValue, bool openDialog)
        {
            return InstitutionSuchen(searchValue, -1, false, openDialog);
        }

        /// <summary>
        /// Search institution with dialog, all types
        /// </summary>
        /// <param name="searchValue">Search value for institution</param>
        /// <param name="onlyActive">Only active institutions</param>
        /// <param name="openDialog">Show dialog or autoselect value if only one value found</param>
        /// <returns>True if value was found, otherwise false</returns>
        public bool InstitutionSuchen(string searchValue, bool onlyActive, bool openDialog)
        {
            return InstitutionSuchen(searchValue, -1, onlyActive, openDialog);
        }

        /// <summary>
        /// Search institution with dialog
        /// </summary>
        /// <param name="searchValue">Search value for institution</param>
        /// <param name="onlyActive">Only active institutions</param>
        /// <param name="baInstitutionTypId">Only defined type (-1 = all types)</param>
        /// <param name="openDialog">Show dialog or autoselect value if only one value found</param>
        /// <returns>True if value was found, otherwise false</returns>
        public bool InstitutionSuchen(string searchValue, int baInstitutionTypId, bool onlyActive, bool openDialog)
        {
            ResultRow = null;

            if (searchValue == "")
            {
                return true;
            }

            searchValue = searchValue.Replace("*", "%");

            const string sql = @"
                SELECT INS.*,
                       Adresse = INS.Adresse,
                       Typen   = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', {3}, {4})
                FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
                WHERE INS.NameVorname LIKE {0} AND
                      ({1} = -1 OR (',' + dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 1, ',', {3}, 1) + ',' LIKE '%,' + CONVERT(VARCHAR(20), {1}) + ',%')) AND
                      ({2} = 0 OR INS.Aktiv = 1)
                ORDER BY INS.NameVorname, INS.Adresse;";

            qry.Fill(sql, searchValue + "%", baInstitutionTypId, onlyActive, Session.User.UserID, Session.User.LanguageCode);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineInstitutionGefunden", "Keine zutreffenden Institutionen gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Name", "NameVorname", 180);
            AddGridColumn("Adresse", "Adresse", 200);
            AddGridColumn("Typen", "Typen", 150);

            return DisplayDialog();
        }

        /// <summary>
        /// Institution suchen aus Sozialhilfe CtlBg*
        /// </summary>
        /// <param name="name">Name der Institution, welche gesucht werden soll</param>
        /// <param name="openDialog">Flag, if the dialog has to be opened</param>
        /// <returns><c>True</c> if data was found and selected, otherwise <c>False</c></returns>
        public bool InstitutionSuchenWh(string name, bool openDialog)
        {
            return InstitutionSuchenWh(name, false, null, openDialog);
        }

        /// <summary>
        /// Institution suchen aus Sozialhilfe CtlBg*
        /// </summary>
        /// <param name="name">Name der Institution, welche gesucht werden soll</param>
        /// <param name="onlyKreditoren"><c>true</c> wenn nur Institutionen mit gültigem Zahlungsweg angezeigt werden sollen</param>
        /// <param name="stichTag">Stichtag für Gültigkeitsberechnung des Zahlungsweges. Wenn <c>null</c>, wird aktuelles Datum verwendet. </param>
        /// <param name="openDialog">Flag, if the dialog has to be opened</param>
        /// <returns><c>True</c> if data was found and selected, otherwise <c>False</c></returns>
        public bool InstitutionSuchenWh(string name, bool onlyKreditoren, DateTime? stichTag, bool openDialog)
        {
            string stichTagStr = stichTag.HasValue ? DBUtil.SqlLiteral(stichTag.Value.Date) : "dbo.fnDateOf(GETDATE())";
            string additionalWhereClause = !onlyKreditoren ? string.Empty : string.Format(@"AND EXISTS (SELECT TOP 1 1 FROM BaZahlungsweg ZAH WHERE ZAH.BaInstitutionID = INS.BaInstitutionID AND {0} BETWEEN ISNULL(ZAH.DatumVon, {0}) AND ISNULL(ZAH.DatumBis, {0}))", stichTagStr);

            return SearchData(string.Format(@"
              DECLARE @SearchValue VARCHAR(255);
              DECLARE @UserID INT;
              DECLARE @LanguageCode INT;

              SET @SearchValue = {0};
              SET @UserID = {1};
              SET @LanguageCode = {2};

              SELECT ID$                 = INS.BaInstitutionID,
                     Institution         = INS.Name,
                     Adresse             = INS.Adresse,
                     Typen               = dbo.fnBaGetBaInstitutionTypen(INS.BaInstitutionID, 0, '; ', @UserID, @LanguageCode)
              FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
              WHERE INS.Name LIKE '%' + @SearchValue + '%'
                {3}
              ORDER BY INS.Name", DBUtil.SqlLiteral(name), Session.User.UserID, Session.User.LanguageCode, additionalWhereClause), name, openDialog);
        }

        /// <summary>
        /// Dialog: Person suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool KAPersonSuchen(string suchbegriff, bool open)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            string sql = @"
                SELECT DISTINCT
                       PRS.BaPersonID,
                       Name    = PRS.NameVorname,
                       Strasse = PRS.WohnsitzStrasseHausNr,
                       PLZOrt  = PRS.WohnsitzPLZOrt,
                       FAL.ModulID
                FROM dbo.vwPerson PRS
                  LEFT JOIN dbo.FaLeistung FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = PRS.BaPersonID
                WHERE FAL.ModulID = 7 ";

            try
            {
                sql += string.Format("AND PRS.BaPersonID = {0}", Convert.ToInt32(suchbegriff));
            }
            catch
            {
                suchbegriff = PrepareSearchString(suchbegriff);

                sql += string.Format(@"
                        AND PRS.NameVorname LIKE {0}
                        ORDER BY PRS.NameVorname", DBUtil.SqlLiteralLike(suchbegriff + "%"));
            }

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeinePersonenGefunden", "Keine zutreffenden Personen gefunden");
                return false;
            }

            if (qry.Count == 1 && !open)
            {
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            // add GridColumns

            AddGridColumn("Nr.", "BaPersonID", 72);
            AddGridColumn("Name", "Name", 250);
            AddGridColumn("Strasse", "Strasse", 182);
            AddGridColumn("Ort", "PLZOrt", 119);

            return DisplayDialog();
        }

        /// <summary>
        /// Zeigt den "Konto Auswaehlen"-Dialog an. Der Suchbegriff kann entweder in
        /// KontoName oder in KontoNr enthalten sein. (FbKonto)
        /// </summary>
        /// <param name="suchbegriff"></param>
        /// <param name="periodeId"></param>
        /// <param name="openDialog"></param>
        /// <returns></returns>
        public bool KbKontoSuchen(string suchbegriff, int periodeId, bool openDialog)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(suchbegriff))
            {
                return true;
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            string query = string.Format(@"
                SELECT KTO.KbKontoID,
                       KTO.KontoNr,
                       KTO.KontoName,
                       KTO.KbKontoartCodes,
                       Kontoart = dbo.fnLOVTextListe ('KbKontoart', KTO.KbKontoartCodes)
                FROM dbo.KbKonto KTO WITH (READUNCOMMITTED)
                WHERE ((0 <> {0} AND KTO.KbPeriodeID = {0}) OR (0 = {0} AND KTO.KbPeriodeID IS NULL)) AND
                      KTO.KontoNr IS NOT NULL AND
                      KTO.Kontogruppe = 0 AND
                      (KTO.KontoNr LIKE '{1}%' OR KTO.KontoName LIKE '{1}%')
                ORDER BY KTO.KontoNr", periodeId, suchbegriff);

            qry.Fill(query);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineKontenGefunden", "Keine zutreffenden Konten gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            // --- add the desired colummns to grid
            AddGridColumn("KontoNr", "KontoNr", 80, HorzAlignment.Near);
            AddGridColumn("Kontoname", "KontoName", 320);
            AddGridColumn("Kontoart", "Kontoart", 160);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Kostenstelle suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool KbKostenstelleSuchen(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            string sql = @"
                --SQLCHECK_IGNORE--
                SELECT PRS.BaPersonID,
                       Kostenstelle = dbo.fnKbGetKostenstelle(PRS.BaPersonID),
                       PRS.Geburtsdatum,
                       KOS.Aktiv
                FROM dbo.KbKostenstelle KOS WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.KbKostenstelle_BaPerson KOP WITH (READUNCOMMITTED) ON KOP.KbKostenstelleID = KOS.KbKostenstelleID
                              AND (KOP.DatumBis IS NULL OR GetDate() BETWEEN KOP.DatumBis AND KOP.DatumBis )
                  LEFT JOIN dbo.vwPerson PRS ON PRS.BaPersonID = KOP.BaPersonID
                WHERE ";

            var rx = new Regex("[*.0-9]");

            if (rx.IsMatch(suchbegriff))
            {
                suchbegriff = suchbegriff.Replace("*", "%");

                sql += string.Format(@"CONVERT(VARCHAR, PRS.BaPersonID) LIKE {0} ", DBUtil.SqlLiteralLike(suchbegriff + "%"));
            }
            else
            {
                suchbegriff = PrepareSearchString(suchbegriff);

                sql += string.Format(@"PRS.NameVorname LIKE {0} ", DBUtil.SqlLiteralLike(suchbegriff + "%"));
            }

            sql += "ORDER BY Kostenstelle";

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineKostenstelleGefunden", "Keine zutreffende Kostenstelle gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Kostenstelle", "Kostenstelle", 240);
            AddGridColumn("Geburtsdatum", "Geburtsdatum", 70);
            AddGridColumn("Aktiv", "Aktiv", 50);

            return DisplayDialog();
        }

        /// <summary>
        /// Zeigt den "Konto Auswaehlen"-Dialog an. Der Suchbegriff kann entweder in
        /// KontoName oder in KontoNr enthalten sein. (FbKonto)
        /// </summary>
        /// <param name="suchbegriff"></param>
        /// <param name="fbPeriodeId"></param>
        /// <param name="openDialog"></param>
        /// <returns></returns>
        public bool KontoSuchen(string suchbegriff, int fbPeriodeId, bool openDialog)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(suchbegriff))
            {
                KissMsg.ShowInfo(CLASSNAME, "KeinSuchbegriff", "Geben Sie bitte zuerst einen Suchbegriff ein.");
                return true;
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            var query = string.Format(@"
                --SQLCHECK_IGNORE--
                SELECT KTO.FbKontoID,
                       KTO.KontoNr,
                       KTO.KontoName,
                       KTO.KontoTypCode
                FROM dbo.FbKonto KTO WITH (READUNCOMMITTED)
                WHERE KTO.FbPeriodeID {0}
                  AND KTO.KontoNr IS NOT NULL
                  AND (KTO.KontoNr LIKE '{1}%' OR KTO.KontoName LIKE '{1}%')
                ORDER BY KTO.KontoNr;", (fbPeriodeId == 0 ? "IS NULL" : string.Format("= {0}", fbPeriodeId)), suchbegriff);

            qry.Fill(query);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineKontenGefunden", "Keine zutreffenden Konten gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("KontoNr", "KontoNr", 80, HorzAlignment.Near);
            AddGridColumn("Kontoname", "KontoName", 338);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Kurserfassung suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <param name="kurssucheCaller">the caller for the search</param>
        /// <returns></returns>
        public bool KurserfassungSuchen(string suchbegriff, bool open, KaKurssucheCaller kurssucheCaller)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace("*", "%");
            suchbegriff = suchbegriff.Replace(" ", "");

            string sql = @"
                SELECT KUE.*,
                       Kurs = KUR.Name,
                       KursNrName = ISNULL(KUE.KursNr, '') + ISNULL(', ' + KUR.Name, ''),
                       KursDetail = ISNULL(KUE.KursNr, '') + ISNULL(', ' + KUR.Name, '') + ISNULL(', ' + CONVERT(VARCHAR(15), KUE.DatumVon, 104), '') + ISNULL(' - ' + CONVERT(VARCHAR(15), KUE.DatumBis, 104), '')
                FROM dbo.KaKurserfassung KUE WITH (READUNCOMMITTED)
                  INNER JOIN dbo.KaKurs KUR WITH (READUNCOMMITTED) ON KUR.KaKursID = KUE.KursID
                WHERE (ISNULL(KUE.KursNr, '') LIKE {0} + '%' OR ISNULL(KUR.Name, '') LIKE {0} + '%')
                  AND KUE.SistiertFlag = 0";

            switch (kurssucheCaller)
            {
                case KaKurssucheCaller.IntegrierteBildung:
                case KaKurssucheCaller.InternerKursVermittlung:
                    sql += @"
                    AND KUR.SektionCode = {1}
                    AND (YEAR(KUE.DatumBis) = YEAR(GETDATE()) OR YEAR(KUE.DatumVon) = YEAR(GETDATE()))";

                    qry.Fill(sql, suchbegriff, (int)kurssucheCaller);
                    break;

                case KaKurssucheCaller.Abklaerung:
                    sql += @"
                    AND KUR.SektionCode = {1}
                    AND (YEAR(KUE.DatumBis) >= YEAR(GETDATE()) OR YEAR(KUE.DatumVon) >= YEAR(GETDATE()))";

                    qry.Fill(sql, suchbegriff, (int)kurssucheCaller);
                    break;

                case KaKurssucheCaller.Praesenzzeiterfassung:

                    qry.Fill(sql, suchbegriff);
                    break;

                default:
                    sql += @"
                    AND (YEAR(KUE.DatumBis) = YEAR(GETDATE()) OR YEAR(KUE.DatumVon) = YEAR(GETDATE()))";

                    qry.Fill(sql, suchbegriff);
                    break;
            }

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineKurseGefunden", "Keine zutreffenden Kurse gefunden");
                return false;
            }

            if (qry.Count == 1 && !open)
            {
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            AddGridColumn("Kursname", "Kurs", 180);
            AddGridColumn("Nr.", "KursNr", 40);
            AddGridColumn("von", "DatumVon", 80);
            AddGridColumn("bis", "DatumBis", 80);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Kurs suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool KursSuchen(string suchbegriff, bool open)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace(",", "%");
            suchbegriff = suchbegriff.Replace(" ", "%");

            const string sql = @"
                SELECT KUR.*,
                       KursID  = KUR.KaKursID,
                       Kurs    = KUR.Name,
                       Sektion = dbo.fnLOVText('KaKursSekt', SektionCode)
                FROM dbo.KaKurs KUR WITH (READUNCOMMITTED)
                WHERE KUR.Name LIKE {0} AND
                      KUR.ClosedFlag = 0
                ORDER BY Kurs, KUR.Nr";

            qry.Fill(sql, suchbegriff + "%");

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineKurseGefunden", "Keine zutreffenden Kurse gefunden");
                return false;
            }

            if (qry.Count == 1 && !open)
            {
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            AddGridColumn("Nr.", "Nr", 40);
            AddGridColumn("Kurs", "Kurs", 180);
            AddGridColumn("Sektion", "Sektion", 120);
            AddGridColumn("Plätze", "Plaetze", 70);
            AddGridColumn("Lektionen", "AnzLektionen", 70);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog Mandant suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="date">The date.</param>
        /// <param name="teams">The teams.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool MandantSuchenA(string suchbegriff, DateTime date, string teams, bool openDialog)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(teams))
            {
                KissMsg.ShowInfo(CLASSNAME, "KeinFibuTeamMitglied", "Sie sind bei keinem Fibu-Team Mitglied !");
                return false;
            }

            string sql = string.Format(@"
                SELECT PER.*,
                       CONVERT(VARCHAR, PER.PeriodeVon, 104) + ' - ' +  CONVERT(VARCHAR, PER.PeriodeBis, 104) PeriodeText,
                       PRS.NameVorname Mandant,
                       PRS.WohnsitzStrasseHausNr Strasse,
                       PRS.WohnsitzPLZOrt PLZOrt,
                       BEN.LogonName MTLogon,
                       ISNULL(BEN.FirstName + ' ', '') + ISNULL(BEN.LastName, '') MTName
                FROM dbo.FbPeriode PER WITH (READUNCOMMITTED)
                  INNER JOIN dbo.vwPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = PER.BaPersonID
                  LEFT  JOIN dbo.FaLeistung FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = PER.BaPersonID AND
                                                                          FAL.ModulID IN (5, 29) AND
                                                                          FAL.FaLeistungID = dbo.fnVmGetLeistungID(PER.BaPersonID)
                  LEFT JOIN dbo.XUser       BEN WITH (READUNCOMMITTED) ON BEN.UserID = FAL.UserID
                WHERE {0} BETWEEN PER.PeriodeVon AND PER.PeriodeBis AND
                      (PER.FbTeamID IS NULL OR PER.FbTeamID IN ({1})) ", DBUtil.SqlLiteral(date), teams);

            try
            {
                sql += string.Format("AND PRS.BaPersonID = {0}", Convert.ToInt32(suchbegriff));
            }
            catch
            {
                suchbegriff = PrepareSearchString(suchbegriff);

                sql += string.Format(@"
                        AND PRS.Name + ISNULL(', ' + PRS.Vorname, '') LIKE {0}
                        ORDER BY PRS.Name + ISNULL(', ' + PRS.Vorname, '')", DBUtil.SqlLiteralLike(suchbegriff + "%"));
            }

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(
                    CLASSNAME,
                    "KeineMandantenGefundenGruende",
                    "Keine zutreffenden Mandanten gefunden\r\n\r\nmögliche Gründe:\r\n- ein Mandant mit diesem Suchbegriff existiert nicht\r\n- keine passende aktive Periode gefunden\r\n- Mandant gehört zu einem anderen Fibu-Team");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            // add GridColumns

            AddGridColumn("M-Nr.", "BaPersonID", 72);
            AddGridColumn("Mandant", "Mandant", 216);
            AddGridColumn("Strasse", "Strasse", 182);
            AddGridColumn("Ort", "PLZOrt", 119);
            AddGridColumn("Mandatsträger", "MTName", 134);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog Mandant suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool MandantSuchenB(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            string sql = @"
                SELECT DISTINCT
                       PRS.BaPersonID,
                       PRS.NameVorname Mandant,
                       PRS.WohnsitzStrasseHausNr Strasse,
                       PRS.WohnsitzPLZOrt PLZOrt,
                       BEN.LogonName MTLogon,
                       ISNULL(BEN.FirstName + ' ', '') + ISNULL(BEN.LastName, '') MTName
                FROM dbo.FbPeriode PER WITH (READUNCOMMITTED)
                  INNER JOIN dbo.vwPerson   PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = PER.BaPersonID
                  LEFT  JOIN dbo.FaLeistung FAL WITH (READUNCOMMITTED) ON FAL.BaPersonID = PER.BaPersonID AND
                                                                          FAL.ModulID IN (5, 29) AND
                                                                          FAL.FaLeistungID = dbo.fnVmGetLeistungID(PER.BaPersonID)
                  LEFT JOIN dbo.XUser       BEN WITH (READUNCOMMITTED) ON BEN.UserID = FAL.UserID ";
            try
            {
                sql += string.Format("WHERE PRS.BaPersonID = {0}", Convert.ToInt32(suchbegriff));
            }
            catch
            {
                suchbegriff = PrepareSearchString(suchbegriff);

                sql += string.Format(@"
                        WHERE PRS.NameVorname LIKE {0}
                        ORDER BY PRS.NameVorname", DBUtil.SqlLiteralLike(suchbegriff + "%"));
            }

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineMandantenGefunden", "Keine zutreffenden Mandanten gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("M-Nr.", "BaPersonID", 72);
            AddGridColumn("Mandant", "Mandant", 216);
            AddGridColumn("Strasse", "Strasse", 182);
            AddGridColumn("Ort", "PLZOrt", 119);
            AddGridColumn("Mandatsträger", "MTName", 134);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Mandatsträger suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool MandatstraegerSuchen(
            string suchbegriff,
            bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            const string sql = @"
                SELECT UserID,
                       Name  = LastName + ISNULL(', ' + FirstName, ''),
                       LogonName
                FROM dbo.XUser WITH (READUNCOMMITTED)
                WHERE LastName + ISNULL(', ' + FirstName, '') LIKE {0} AND
                      isMandatsTraeger = 1
                ORDER BY Name";

            qry.Fill(sql, suchbegriff + "%");

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineMandatstraegerinGefunden", "Keine zutreffenden MandatsträgerInnen gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Name", "Name", 320);
            AddGridColumn("Kürzel", "LogonName", 90);

            return DisplayDialog();
        }

        public bool MassnahmefuehrenderSuchen(string suchbegriff, int? kesBeistandsartCode, bool openDialog)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(suchbegriff))
            {
                if (!openDialog)
                {
                    return true;
                }

                suchbegriff = "*";
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            const string sql = @"
                SELECT UserID$                  = UserID,
                       VmPriMaID$               = NULL,
                       BaInstitutionID$         = NULL,
                       Name                     = NameVorname,
                       Strasse                  = NULL,
                       Ort                      = NULL,
                       Beistandsart             = dbo.fnLOVText('KesBeistandsart', 2), --2: Berufsbeistand
                       KesBeistandsartCode$     = 2 --2: Berufsbeistand
                FROM dbo.vwUser WITH (READUNCOMMITTED)
                WHERE NameVorname LIKE {0}
                  AND isMandatsTraeger = 1
                  AND IsNull({1}, 2) = 2 --2: Berufsbeistand

                --UNION ALL
                --
                --SELECT UserID$                  = NULL,
                --       VmPriMaID$               = VPM.VmPriMaID,
                --       BaInstitutionID$         = NULL,
                --       Name                     = VPM.Name + ISNULL(', ' + VPM.Vorname, ''),
                --       Strasse                  = ISNULL(ADR.Strasse, '') + ISNULL(' ' + ADR.HausNr, ''),
                --       Ort                      = ISNULL(ADR.PLZ, '') + ISNULL(' ' + ADR.Ort, ''),
                --       Beistandsart             = dbo.fnLOVText('KesBeistandsart', 1), --1: Privatperson
                --       KesBeistandsartCode$     = 1 --1: Privatperson
                --FROM dbo.VmPriMa VPM WITH (READUNCOMMITTED)
                --  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.VmPriMaID = VPM.VmPriMaID
                --WHERE VPM.Name + ISNULL(', ' + VPM.Vorname, '') LIKE {0}
                --  AND VPM.IsActive = 1
                --  AND IsNull({1}, 1) = 1 --1: Privatperson

                UNION ALL

                SELECT UserID$                  = NULL,
                       VmPriMaID$               = NULL,
                       BaInstitutionID$         = INS.BaInstitutionID,
                       Name                     = INS.NameVorname,
                       Strasse                  = INS.StrasseHausNr,
                       Ort                      = INS.PLZOrt,
                       Beistandsart             = dbo.fnLOVText('KesBeistandsart', 3), --3: Fachbeistand
                       KesBeistandsartCode$     = 3 --3: Fachbeistand
                FROM dbo.vwInstitution INS WITH (READUNCOMMITTED)
                WHERE INS.NameVorname LIKE {0}
--                  AND INS.BaInstitutionArtCode = 2 --2: Fachperson  --Aufgrund Test-Rückmeldung und auf ausdrücklichen Wunsch von BSS auskommentiert, da die Datenqualität zZt noch nicht ausreicht. Deshalb werden jetzt vorerst mal alle Institutionen angezeigt und nicht nur Fachpersonen
                  AND IsNull({1}, 3) = 3 --3: Fachbeistand
                  AND INS.Aktiv = 1
                ORDER BY KesBeistandsartCode$, Name;";

            qry.Fill(sql, suchbegriff + "%", kesBeistandsartCode);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineMassnahmefuehrendeGefunden", "Keine zutreffenden Massnahmeführende gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            // autopopulate, autosize columns and show dialog
            return DisplayDialog(true);
        }

        /// <summary>
        /// Dialog: Mitarbeiter suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool MitarbeiterKASuchen(string suchbegriff, bool open)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace(",", "%");
            suchbegriff = suchbegriff.Replace(" ", "%");

            const string sql = @"
                SELECT UserID,
                       Name  = LastName + isNull(', ' + FirstName,''),
                       LogonName
                from dbo.XUser WITH (READUNCOMMITTED)
                WHERE LastName + ISNULL(', ' + FirstName, '') LIKE {0} AND
                      LogonName LIKE 'KA%'
                ORDER BY Name";

            qry.Fill(sql, suchbegriff + "%");

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineMitarbeiterGefunden", "Keine zutreffenden MitarbeiterInnen gefunden");
                return false;
            }

            if (qry.Count == 1 && !open)
            {
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            AddGridColumn("Name", "Name", 320);
            AddGridColumn("Kürzel", "LogonName", 90);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog zum Suchen von Mitarbeitern. Liefert [UserID, Name, LogonName]
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool MitarbeiterSuchen(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            string sql = string.Format(@"
                SELECT UserID,
                       Name = NameVorname,
                       LogonName,
                       DisplayText$ = DisplayText
                FROM dbo.vwUser WITH (READUNCOMMITTED)
                WHERE (NameVorname LIKE {0} OR LogonName LIKE {0})
                ORDER BY Name", DBUtil.SqlLiteralLike(suchbegriff + "%"));

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineMitarbeiterGefunden", "Keine zutreffenden MitarbeiterInnen gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Name", "Name", 320);
            AddGridColumn("Kürzel", "LogonName", 90);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog Mitarbeiter suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="modul">The modul.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool MitarbeiterSuchen(string suchbegriff, ModulID modul, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            string sql = string.Format(@"
                SELECT UserID,
                       Name = LastName + ISNULL(', ' + FirstName, ''),
                       LogonName
                FROM dbo.XUser WITH (READUNCOMMITTED)
                WHERE (LastName + ISNULL(', ' + FirstName, '') LIKE {0} OR LogonName LIKE {0}) AND
                      ModulID = {1}
                ORDER BY Name", DBUtil.SqlLiteralLike(suchbegriff + "%"), Convert.ToInt32(modul));

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineMitarbeiterGefunden", "Keine zutreffenden MitarbeiterInnen gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Name", "Name", 320);
            AddGridColumn("Kürzel", "LogonName", 90);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Ort suchen.
        /// </summary>
        /// <param name="ortSearchValue">Name des Ortes</param>
        /// <param name="datum">Einschränkungsdatum</param>
        /// <returns></returns>
        public bool OrtSearch(string ortSearchValue, DateTime? datum = null)
        {
            ResultRow = null;

            if (ortSearchValue == "")
            {
                return true;
            }

            ortSearchValue = ortSearchValue.Replace("*", "%");

            const string sql = @"
                SELECT PLZ.*,
                       PLZOrt = CONVERT(VARCHAR, PLZ.PLZ) + ' ' + ISNULL(dbo.fnGetMLText(PLZ.NameTID, {1}), PLZ.Name),
                       Code   = PLZ.BaPLZID,
                       Text   = ISNULL(dbo.fnGetMLText(PLZ.NameTID, {1}), PLZ.Name),
                       Value1 = PLZ.PLZ,
                       Value2 = PLZ.Kanton,
                       Value3 = ISNULL(dbo.fnGetMLText(GDE.BezirkNameTID, {1}), GDE.BezirkName),
                       GDE.BaGemeindeID
                FROM dbo.BaPLZ             PLZ WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaGemeinde GDE WITH (READUNCOMMITTED) ON GDE.BFSCode = PLZ.BFSCode
                WHERE ISNULL(dbo.fnGetMLText(PLZ.NameTID, {1}), PLZ.Name) LIKE {0}
                  AND GDE.BezirkAufhebungDatum IS NULL
                  AND ({2} IS NULL OR {2} BETWEEN ISNULL(PLZ.DatumVon, '17530101') AND ISNULL(PLZ.DatumBis, '99991231')) --Wenn ein Datum übergeben wird, soll mit BETWEEN DatumVon AND DatumBis geprüft werden
                  AND ({2} IS NOT NULL OR PLZ.DatumBis IS NULL) --Wenn kein Datum übergeben wird, nehmen wir den letzten Wert (DatumBis IS NULL)
                ORDER BY Text, PLZ.PLZ";

            qry.Fill(sql, ortSearchValue + '%', Session.User.LanguageCode, datum);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineOrteGefunden", "Keine zutreffenden Orte gefunden");
                return false;
            }

            if (qry.Count == 1)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("PLZ", "PLZ", 50);
            AddGridColumn("Ort", "Name", 250);
            AddGridColumn("Kanton", "Kanton", 80);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Search a receiver for a single task
        /// </summary>
        /// <param name="searchString">
        /// The search string.
        /// If value is empty, all entries will be shown.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <param name="ifEmptySearchAll">if set to <c>true</c> all entries will be displayed if no searchstring was entered</param>
        /// <returns><c>true</c> if one entry was selected, otherwise <c>false</c>.</returns>
        public bool PendenzEmpfaengerSuchen(string searchString, bool openDialog, bool ifEmptySearchAll)
        {
            // reset var
            ResultRow = null;

            // init searchstring
            if (string.IsNullOrEmpty(searchString))
            {
                if (ifEmptySearchAll)
                {
                    // set searching-all
                    searchString = "%";
                }
                else
                {
                    // nothing entered (reset)
                    return true;
                }
            }
            else
            {
                // prepare for sql
                searchString = PrepareSearchString(searchString);
            }

            // init sql-string
            const string sql = @"
                    SELECT Typ          = 'Benutzer',
                           [Kürzel]     = USR.LogonName,
                           Name         = USR.NameVorname,
                           Abteilung    = USR.OrgEinheitName,
                           ID$          = USR.UserID,
                           TypeCode$    = 1,
                           DisplayText$ = USR.DisplayText
                    FROM dbo.vwUser USR WITH (READUNCOMMITTED)
                    WHERE (USR.NameVorname LIKE {0} + '%'
                           OR USR.LogonName LIKE {0} + '%')
                      AND USR.IsLocked = 0  --nur nicht gesperrte

                    UNION ALL

                    SELECT Typ          = 'Gruppe',
                           [Kürzel]     = NULL,
                           Name         = FPG.Name,
                           Abteilung    = NULL,
                           ID$          = FPG.FaPendenzgruppeID,
                           TypeCode$    = 2,
                           DisplayText$ = FPG.Name
                    FROM dbo.FaPendenzgruppe FPG WITH (READUNCOMMITTED)
                    WHERE FPG.Name LIKE {0} + '%'
                      AND FPG.Name NOT LIKE 'migrierte_Grp_%'

                    ORDER BY TypeCode$ DESC, Name";

            // fill data
            qry.Fill(sql, searchString);

            // validate
            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineDatenGefundenPendenzEmpfaenger", "Es wurde kein zutreffender Empfänger gefunden.");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            // autopopulate, autosize columns and show dialog
            return DisplayDialog(true);
        }

        /// <summary>
        /// Dialog: Search a case for a single task
        /// </summary>
        /// <param name="searchString">
        /// The search string.
        /// If value is empty, all entries will be shown.
        /// If value is equal to ".", all cases of the current user will be shown.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <param name="ifEmptySearchAll">if set to <c>true</c> all entries will be displayed if no searchstring was entered</param>
        /// <returns><c>true</c> if one entry was selected, otherwise <c>false</c>.</returns>
        public bool PendenzFallSuchen(string searchString, bool openDialog, bool ifEmptySearchAll)
        {
            // reset var
            ResultRow = null;

            // init searchstring
            if (string.IsNullOrEmpty(searchString))
            {
                if (ifEmptySearchAll)
                {
                    // set searching-all
                    searchString = "%";
                }
                else
                {
                    // nothing entered (reset)
                    return true;
                }
            }
            else
            {
                // prepare for sql
                searchString = PrepareSearchString(searchString);
            }

            // init sql-string
            string sql;

            if (searchString == ".")
            {
                // show all cases of current user
                sql = @"DECLARE @SearchString VARCHAR(255)
                        DECLARE @UserID INT

                        SET @SearchString = {0}
                        SET @UserID = {1}

                        SELECT ID           = FAL.FaFallID,
                               Name         = PRS.Name,
                               Vorname      = PRS.Vorname,
                               Benutzer     = USR.DisplayText,
                               FaFallID$    = FAL.FaFallID,
                               NameVorname$ = PRS.NameVorname + ' (' + CONVERT(VARCHAR, FAL.FaFallID) + ')'
                        FROM dbo.FaFall FAL WITH (READUNCOMMITTED)
                          INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = FAL.BaPersonID
                          INNER JOIN dbo.vwUser   USR ON USR.UserID = FAL.UserID
                        WHERE FAL.UserID = @UserID
                           OR EXISTS (SELECT TOP 1 1
                                      FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                      WHERE LEI.FaFallID = FAL.FaFallID
                                        AND (LEI.UserID = @UserID OR SachbearbeiterID = @UserID))
                        ORDER BY PRS.Name, PRS.Vorname";
            }
            else
            {
                // use searchstring to search for either PRS.NameVorname or if nummeric value FAL.FaFallID
                sql = @"DECLARE @SearchString VARCHAR(255)
                        DECLARE @UserID INT

                        SET @SearchString = {0}
                        SET @UserID = {1}

                        SELECT ID           = FAL.FaFallID,
                               Name         = PRS.Name,
                               Vorname      = PRS.Vorname,
                               Benutzer     = USR.DisplayText,
                               FaFallID$    = FAL.FaFallID,
                               NameVorname$ = PRS.NameVorname + ' (' + CONVERT(VARCHAR, FAL.FaFallID) + ')'
                        FROM dbo.FaFall FAL WITH (READUNCOMMITTED)
                          INNER JOIN dbo.vwPerson PRS ON PRS.BaPersonID = FAL.BaPersonID
                          INNER JOIN dbo.vwUser   USR ON USR.UserID = FAL.UserID
                        WHERE PRS.NameVorname LIKE @SearchString + '%' OR
                              FAL.FaFallID = CASE WHEN ISNUMERIC(@SearchString) = 1 THEN CONVERT(INT, ROUND(@SearchString, 0))
                                                  ELSE -1
                                             END
                        ORDER BY PRS.Name, PRS.Vorname";
            }

            // fill data
            qry.Fill(sql, searchString, Session.User.UserID);

            // validate
            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineDatenGefundenPendenzFall", "Es wurde kein zutreffender Fall gefunden.");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            // autopopulate, autosize columns and show dialog
            return DisplayDialog(true);
        }

        /// <summary>
        /// Zeigt den "Konto Auswählen"-Dialog an. (FbKonto)
        /// Fehlermeldung wird angezeigt wenn keine Konten gefunden wurde.
        /// </summary>
        /// <param name="suchbegriff">Der Suchbegriff.</param>
        /// <param name="baPerson">Die BaPersonID.</param>
        /// <param name="datum">Definiert die Periode.</param>
        /// <param name="open">.</param>
        /// <returns></returns>
        public bool PeriodenKontoSuchen(string suchbegriff, string baPerson, DateTime datum, bool open)
        {
            return PeriodenKontoSuchen(suchbegriff, baPerson, datum, open, true);
        }

        /// <summary>
        /// Zeigt den "Konto Auswählen"-Dialog an. (FbKonto)
        /// </summary>
        /// <param name="suchbegriff">Der Suchbegriff.</param>
        /// <param name="baPerson">Die BaPersonID.</param>
        /// <param name="datum">Definiert die Periode.</param>
        /// <param name="open">.</param>
        /// <param name="showErrorMessage"></param>
        /// <returns></returns>
        public bool PeriodenKontoSuchen(string suchbegriff, string baPerson, DateTime datum, bool open, bool showErrorMessage)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(suchbegriff))
            {
                suchbegriff = "*";
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            string sql = string.Format(@"
                DECLARE @DatumOhneZeit DATETIME, @BaPersonId INT, @Suchbegriff VARCHAR(100);
                SELECT @BaPersonId = {0},
                       @DatumOhneZeit = dbo.fnDateOf({1}),
                       @Suchbegriff = '{2}';

                SELECT
                  KTO.FbKontoID,
                  KTO.KontoNr,
                  KTO.KontoName
                FROM dbo.FbKonto KTO WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.FbPeriode PER WITH (READUNCOMMITTED) ON PER.FbPeriodeID = KTO.FbPeriodeID
                  LEFT JOIN dbo.BaPerson  BAP WITH (READUNCOMMITTED) ON BAP.BaPersonID = PER.BaPersonID
                WHERE BAP.BaPersonID = @BaPersonId
                  AND dbo.fnDateOf(PER.PeriodeVon) <= @DatumOhneZeit
                  AND PER.PeriodeBis >= @DatumOhneZeit
                  AND KTO.KontoNr IS NOT NULL
                  AND (KTO.KontoNr LIKE @Suchbegriff + '%' OR KTO.KontoName LIKE @Suchbegriff + '%')
                ORDER BY KTO.KontoNr;",
                baPerson,
                DBUtil.SqlLiteral(datum),
                suchbegriff);

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                if (showErrorMessage)
                {
                    KissMsg.ShowInfo(CLASSNAME, "KeinePeriodeKontenGefunden", "Es existieren keine Konten für diesen Mandaten. Überprüfen Sie bitte die Perioden für diesen Mandanten.");
                }
                return false;
            }

            if ((qry.Count == 1) && !open)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("KontoNr", "KontoNr", 80, HorzAlignment.Near);
            AddGridColumn("Kontoname", "KontoName", 338);

            return DisplayDialog();
        }

        /// <summary>
        ///  Dialog: Person suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool PersonSuchen(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            string sql = @"
                SELECT BaPersonID = PRS.BaPersonID,
                       Name       = PRS.NameVorname,
                       Strasse    = PRS.WohnsitzStrasseHausNr,
                       PLZOrt     = PRS.WohnsitzPLZOrt
                FROM dbo.vwPerson PRS WITH (READUNCOMMITTED)";
            try
            {
                sql += string.Format("WHERE PRS.BaPersonID = {0};", Convert.ToInt32(suchbegriff));
            }
            catch
            {
                suchbegriff = PrepareSearchString(suchbegriff);

                sql += string.Format(@"
                    WHERE PRS.NameVorname LIKE {0}
                    ORDER BY Name;", DBUtil.SqlLiteralLike(suchbegriff + "%"));
            }

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeinePersonGefunden", "Keine zutreffenden Personen gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            // add GridColumns
            AddGridColumn("Nr.", "BaPersonID", 72);
            AddGridColumn("Name", "Name", 250);
            AddGridColumn("Strasse", "Strasse", 182);
            AddGridColumn("Ort", "PLZOrt", 119);

            return DisplayDialog();
        }

        /// <summary>
        ///  Dialog: Person suchen including column of KGS
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool PersonSuchenKGS(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            string sql = @"
                SELECT BaPersonID = PRS.BaPersonID,
                       Name       = PRS.NameVorname,
                       KGS        = CASE
                                      WHEN LEI.UserID IS NULL THEN NULL
                                      ELSE dbo.fnGetHistKGSOfUserOrOrgUnit(NULL, GETDATE(), ORG.OrgUnitID, 0, 1)
                                    END,
                       Strasse    = PRS.WohnsitzStrasseHausNr,
                       PLZOrt     = PRS.WohnsitzPLZOrt
                FROM dbo.vwPerson          PRS WITH (READUNCOMMITTED)
                  -- Fallfuehrung
                  LEFT JOIN dbo.FaLeistung LEI  WITH (READUNCOMMITTED) ON LEI.FaLeistungID = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 2)
                  LEFT JOIN dbo.XOrgUnit   ORG  WITH (READUNCOMMITTED) ON ORG.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(LEI.UserID, 1))";
            try
            {
                sql += string.Format("WHERE PRS.BaPersonID = {0};", Convert.ToInt32(suchbegriff));
            }
            catch
            {
                suchbegriff = PrepareSearchString(suchbegriff);

                sql += string.Format(@"
                    WHERE PRS.NameVorname LIKE {0}
                    ORDER BY Name;", DBUtil.SqlLiteralLike(suchbegriff + "%"));
            }

            // get current timeout
            int currentTimeout = qry.FillTimeOut;

            try
            {
                // enlarge timeout
                qry.FillTimeOut = 120; // 2min

                // get data
                qry.Fill(sql);
            }
            finally
            {
                // reset timeout
                qry.FillTimeOut = currentTimeout;
            }

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeinePersonGefunden", "Keine zutreffenden Personen gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            // add GridColumns
            AddGridColumn("Nr.", "BaPersonID", 75);
            AddGridColumn("Name", "Name", 250);
            AddGridColumn("KGS", "KGS", 120);
            AddGridColumn("Strasse", "Strasse", 180);
            AddGridColumn("Ort", "PLZOrt", 120);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: PLZ suchen.
        /// </summary>
        /// <param name="plzSearchValue">PLZ</param>
        /// <param name="datum">Einschränkungsdatum</param>
        /// <returns></returns>
        public bool PLZSearch(string plzSearchValue, DateTime? datum = null)
        {
            ResultRow = null;

            if (plzSearchValue == "")
            {
                return true;
            }

            plzSearchValue = plzSearchValue.Replace("*", "%");

            const string sql = @"
                SELECT PLZ.*,
                       PLZOrt = CONVERT(VARCHAR, PLZ.PLZ) + ' ' + ISNULL(dbo.fnGetMLText(PLZ.NameTID, {1}), PLZ.Name),
                       Code   = PLZ.BaPLZID,
                       Text   = ISNULL(dbo.fnGetMLText(PLZ.NameTID, {1}), PLZ.Name),
                       Value1 = PLZ.PLZ,
                       Value2 = PLZ.Kanton,
                       Value3 = ISNULL(dbo.fnGetMLText(GDE.BezirkNameTID, {1}), GDE.BezirkName),
                       GDE.BaGemeindeID
                FROM dbo.BaPLZ             PLZ WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaGemeinde GDE WITH (READUNCOMMITTED) ON GDE.BFSCode = PLZ.BFSCode
                WHERE PLZ.PLZ LIKE {0}
                  AND GDE.BezirkAufhebungDatum IS NULL
                  AND ({2} IS NULL OR {2} BETWEEN ISNULL(PLZ.DatumVon, '17530101') AND ISNULL(PLZ.DatumBis, '99991231')) --Wenn ein Datum übergeben wird, soll mit BETWEEN DatumVon AND DatumBis geprüft werden
                  AND ({2} IS NOT NULL OR PLZ.DatumBis IS NULL) --Wenn kein Datum übergeben wird, nehmen wir den letzten Wert (DatumBis IS NULL)
                ORDER BY PLZOrt";

            qry.Fill(sql, plzSearchValue + '%', Session.User.LanguageCode, datum);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeinePLZGefunden", "Keine zutreffende PLZ gefunden");
                return false;
            }

            if (qry.Count == 1)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("PLZ", "PLZ", 50);
            AddGridColumn("Ort", "Name", 250);
            AddGridColumn("Kanton", "Kanton", 80);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: prima suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        [Obsolete]
        public bool PriMaSuchen(
            string suchbegriff,
            bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace(",", "%").Replace(" ", "%");

            const string sql = @"
                SELECT VmPriMaID = VPM.VmPriMaID,
                       Name      = VPM.Name + ISNULL(', ' + VPM.Vorname, ''),
                       Strasse   = ISNULL(ADR.Strasse, '') + ISNULL(' ' + ADR.HausNr, ''),
                       Ort       = ISNULL(ADR.PLZ, '') + ISNULL(' ' + ADR.Ort, '')
                FROM dbo.VmPriMa VPM WITH (READUNCOMMITTED)
                  LEFT JOIN dbo.BaAdresse ADR WITH (READUNCOMMITTED) ON ADR.VmPriMaID = VPM.VmPriMaID
                WHERE VPM.Name + ISNULL(', ' + VPM.Vorname, '') LIKE {0} AND
                      VPM.IsActive = 1
                ORDER BY Name, Vorname";

            qry.Fill(sql, suchbegriff + "%");

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeinePrivateMandatstraegerinGefunden", "Keine zutreffenden privaten MandatsträgerInnen gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Name", "Name", 180);
            AddGridColumn("Strasse", "Strasse", 200);
            AddGridColumn("Ort", "Ort", 130);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog bank suchen.
        /// </summary>
        /// <param name="searchClearingNrOrNameParam">The search param.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool SearchBank(string searchClearingNrOrNameParam, bool openDialog)
        {
            return SearchBank(searchClearingNrOrNameParam, openDialog, false);
        }

        public bool SearchKesArtikel(string suchbegriff, int? massnahmeTyp, bool? isMassnahmegebunden, bool isDialogSelected)
        {
            suchbegriff = PrepareSearchString(suchbegriff);

            if (string.IsNullOrEmpty(suchbegriff))
            {
                suchbegriff = "%";
            }

            const string searchSql = @"
                ;WITH
                    ArtikelCTE AS
                    (
                      SELECT
                        KesArtikelID,
                        Artikel = Artikel + IsNull('.' + Absatz, '') + IsNull('.' + Ziffer, ''),
                        Gesetz,
                        Bezeichnung
                      FROM dbo.KesArtikel WITH(READUNCOMMITTED)
                      WHERE {1} IS NULL OR IsMassnahmeGebunden = {1}
                        AND {2} IS NULL OR KesMassnahmeTypCode = {2}
                    )
                  SELECT
                      KesArtikelID$ = KesArtikelID,
                      Artikel,
                      Gesetz,
                      Bezeichnung,
                      ArtikelGesetz$ = Artikel + ' ' + Gesetz,
                      ArtikelGesetzBezeichnung$ = Artikel + ' ' + Gesetz + ' ' + Bezeichnung
                FROM ArtikelCTE
                WHERE (Artikel + ' ' + Gesetz + ' ' + Bezeichnung LIKE {0} +'%'
                        OR Bezeichnung LIKE '%' + {0} + '%')
                ORDER BY Gesetz, Artikel;";

            qry.Fill(searchSql, suchbegriff, isMassnahmegebunden, massnahmeTyp);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeinGesetzArtikelGefunden", "Kein zutreffender Gesetzesartikel gefunden.");
                return false;
            }

            if (qry.Count == 1 && !isDialogSelected)
            {
                ResultRow = qry.Row;
                return true;
            }

            // autopopulate, autosize columns and show dialog
            return DisplayDialog(true);
        }

        public bool SearchKreditor(int fallId, int? spezKontoId, string searchString, bool openDialog)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(searchString) || searchString == ".")
            {
                searchString = "*";
            }

            searchString = PrepareSearchString(searchString);

            var sql = string.Format(@"
                -- Klientensystem
                SELECT ID$                = KRE.BaZahlungswegID,
                       Typ                = '{2}',
                       [Z.Weg gültig von] = KRE.ZahlungswegDatumVon,
                       [Z.Weg gültig bis] = KRE.ZahlungswegDatumBis,
                       Name               = KRE.PersonNameVorname,
                       Zahlungsweg        = KRE.Zahlungsweg,
                       ESCode$            = KRE.EinzahlungsscheinCode,
                       PostKontoNummer$   = KRE.PostKontoNummer,
                       Kreditor$          = KRE.Kreditor,
                       ZusatzInfo$        = KRE.ZusatzInfo,
                       Referenznummer$    = KRE.Referenznummer,
                       SortKey$           = 1
                FROM dbo.FaFallPerson       FAP WITH(READUNCOMMITTED)
                  INNER JOIN dbo.vwKreditor KRE WITH(READUNCOMMITTED) ON KRE.BaPersonID = FAP.BaPersonID
                WHERE FAP.FaFallID = {0}
                  AND KRE.PersonNameVorname LIKE {1}

                UNION

                -- Involvierte Institutionen
                SELECT ID$                = KRE.BaZahlungswegID,
                       Typ                = '{3}',
                       [Z.Weg gültig von] = KRE.ZahlungswegDatumVon,
                       [Z.Weg gültig bis] = KRE.ZahlungswegDatumBis,
                       Name               = KRE.InstitutionName,
                       Zahlungsweg        = KRE.Zahlungsweg,
                       ESCode$            = KRE.EinzahlungsscheinCode,
                       PostKontoNummer$   = KRE.PostKontoNummer,
                       Kreditor$          = KRE.Kreditor,
                       ZusatzInfo$        = KRE.ZusatzInfo,
                       Referenznummer$    = KRE.Referenznummer,
                       SortKey$           = 2
                FROM dbo.FaFallPerson                   FFP WITH(READUNCOMMITTED)
                  INNER JOIN dbo.BaPerson_BaInstitution PIN WITH(READUNCOMMITTED) ON PIN.BaPersonID = FFP.BaPersonID
                  INNER JOIN dbo.vwKreditor             KRE WITH(READUNCOMMITTED) ON KRE.BaInstitutionID = PIN.BaInstitutionID
                WHERE FaFallID = {0}
                  AND KRE.InstitutionName LIKE {1}",
                fallId,
                DBUtil.SqlLiteralLike(searchString + "%"),
                KissMsg.GetMLMessage(Name, "Klientensystem", "Klientensystem"),
                KissMsg.GetMLMessage(Name, "Institutionen", "Institutionen"));

            if (spezKontoId != null)
            {
                var sqlSpezKonto = string.Format(@"
                    -- Institution aus Spezialkonto
                    SELECT ID$                = KRE.BaZahlungswegID,
                           Typ                = '{2}',
                           [Z.Weg gültig von] = KRE.ZahlungswegDatumVon,
                           [Z.Weg gültig bis] = KRE.ZahlungswegDatumBis,
                           Name               = KRE.InstitutionName,
                           Zahlungsweg        = KRE.Zahlungsweg,
                           ESCode$            = KRE.EinzahlungsscheinCode,
                           PostKontoNummer$   = KRE.PostKontoNummer,
                           Kreditor$          = KRE.Kreditor,
                           ZusatzInfo$        = KRE.ZusatzInfo,
                           Referenznummer$    = KRE.Referenznummer,
                           SortKey$           = 3
                    FROM dbo.BgSpezkonto        SPZ WITH(READUNCOMMITTED)
                      INNER JOIN dbo.vwKreditor KRE WITH(READUNCOMMITTED) ON KRE.BaInstitutionID = SPZ.BaInstitutionID
                    WHERE SPZ.BgSpezkontoID = {0}
                      AND KRE.InstitutionName LIKE {1}",
                    DBUtil.SqlLiteral(spezKontoId),
                    DBUtil.SqlLiteralLike(searchString + "%"),
                    KissMsg.GetMLMessage(Name, "Spezialkonto", "Spezialkonto"));

                sql = sql + " UNION " + sqlSpezKonto;
            }

            sql += " ORDER BY SortKey$, Name, Zahlungsweg;";

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineKreditorenGefunden", "Keine zutreffenden Kreditoren gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            // autopopulate, autosize columns and show dialog
            return DisplayDialog(true);
        }

        /// <summary>
        /// Dialog: Fallträger suchen.
        /// </summary>
        /// <param name="suchbegriff">The search value (number of BaPersonID or lastname/firstname of person)</param>
        /// <param name="onlyOpen">Show only entries with open FaLeistung</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns>The <see cref="DlgAuswahl"/>to show</returns>
        public bool ShFalltraegerSuchen(string suchbegriff, bool onlyOpen, bool openDialog)
        {
            return ShFalltraegerSuchen(suchbegriff, onlyOpen, null, null, openDialog);
        }

        /// <summary>
        /// Dialog: Fallträger suchen.
        /// </summary>
        /// <param name="suchbegriff">The search value (number of BaPersonID or lastname/firstname of person)</param>
        /// <param name="onlyOpen">Show only entries with open FaLeistung</param>
        /// <param name="orgUnitId">The ID of the orgUnit of the SAR.</param>
        /// <param name="sarId">The ID of the SAR.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns>The <see cref="DlgAuswahl"/>to show</returns>
        public bool ShFalltraegerSuchen(string suchbegriff, bool onlyOpen, int? sarId, int? orgUnitId, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            string sql = string.Format(@"
                SELECT DISTINCT
                       PRS.BaPersonID,
                       Name    = PRS.NameVorname,
                       Strasse = PRS.WohnsitzStrasseHausNr,
                       PLZOrt  = PRS.WohnsitzPLZOrt,
                       SAR     = ISNULL(BEN.FirstName + ' ', '') + ISNULL(BEN.LastName, '')
                FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED)
                  INNER JOIN dbo.vwPerson PRS                        ON PRS.BaPersonID = FAL.BaPersonID
                  LEFT  JOIN dbo.XUser    BEN WITH (READUNCOMMITTED) ON BEN.UserID = FAL.UserID
                WHERE FAL.ModulID = 3
                  AND (ISNULL({0}, 0) = 0 OR FAL.DatumBis IS NULL)
                  AND (ISNULL({1}, 0) = 0 OR BEN.UserID = {1})
                  AND (ISNULL({2}, 0) = 0 OR EXISTS (SELECT TOP 1 1 FROM XOrgUnit_User OUU WHERE OUU.UserID = BEN.UserID AND OUU.OrgUnitID = {2} AND OUU.OrgUnitMemberCode = 2))  --2: Mitglied
            ", DBUtil.SqlLiteral(onlyOpen), DBUtil.SqlLiteral(sarId), DBUtil.SqlLiteral(orgUnitId));

            try
            {
                sql += string.Format("AND PRS.BaPersonID = {0}", Convert.ToInt32(suchbegriff));
            }
            catch
            {
                suchbegriff = PrepareSearchString(suchbegriff);

                sql += string.Format(@"
                        AND PRS.Name + ISNULL(', ' + PRS.Vorname, '') LIKE {0}
                        ORDER BY Name", DBUtil.SqlLiteralLike(suchbegriff + "%"));
            }

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineFalltraegerinGefunden", "Keine zutreffenden FallträgerInnen gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("P-Nr.", "BaPersonID", 72);
            AddGridColumn("FallträgerIn", "Name", 216);
            AddGridColumn("Strasse", "Strasse", 182);
            AddGridColumn("Ort", "PLZOrt", 119);
            AddGridColumn("SAR", "SAR", 134);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Unterstützte Person suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="openDialog">if set to <c>true</c> [open dialog].</param>
        /// <returns></returns>
        public bool ShUnterstuetztePersonSuchen(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            string sql = @"
                SELECT DISTINCT
                       PRS.BaPersonID,
                       Name    = PRS.NameVorname,
                       Strasse = PRS.WohnsitzStrasseHausNr,
                       PLZOrt  = PRS.WohnsitzPLZOrt,
                       FT      = CONVERT(BIT, CASE WHEN EXISTS(SELECT TOP 1 1
                                                                FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                                                WHERE LEI.BaPersonID = PRS.BaPersonID AND
                                                                      LEI.ModulID = 3) THEN 1
                                                    ELSE 0
                                               END)
                FROM dbo.vwPerson PRS
                WHERE EXISTS(SELECT TOP 1 1
                             FROM dbo.BgFinanzplan_BaPerson SPP WITH (READUNCOMMITTED)
                               INNER JOIN dbo.BgFinanzplan SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = SPP.BgFinanzplanID
                               INNER JOIN dbo.FaLeistung   FAL WITH (READUNCOMMITTED) ON FAL.FaLeistungID = SFP.FaLeistungID
                             WHERE SPP.BaPersonID = PRS.BaPersonID AND
                                   SPP.IstUnterstuetzt = 1 AND
                                   FAL.ModulID = 3) ";

            try
            {
                sql += string.Format("AND PRS.BaPersonID = {0}", Convert.ToInt32(suchbegriff));
            }
            catch
            {
                suchbegriff = PrepareSearchString(suchbegriff);

                sql += "AND PRS.Name + ISNULL(', ' + PRS.Vorname, '') LIKE " + DBUtil.SqlLiteralLike(suchbegriff + "%") + " ";
            }

            sql += "ORDER BY Name";

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineUnterstPersonGefunden", "Keine zutreffende, unterstützte Person gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("FT", "FT", 35);
            AddGridColumn("P-Nr.", "BaPersonID", 72);
            AddGridColumn("unterstützte Person", "Name", 200);
            AddGridColumn("Strasse", "Strasse", 150);
            AddGridColumn("Ort", "PLZOrt", 110);

            return DisplayDialog();
        }

        /// <summary>
        /// Sucht im Standard-Kontenplan nach Konten, die den Suchbegriff entweder
        /// im Namen oder in der Suchnummer enthalten.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <param name="kontoKlasse">The konto klasse.</param>
        /// <returns></returns>
        public bool StandardKontoSuchen(string suchbegriff, bool open, int kontoKlasse)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(suchbegriff))
            {
                return true;
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            var sql = string.Format(@"
                --SQLCHECK_IGNORE--
                SELECT KTO.FbKontoID,
                       KTO.KontoNr,
                       KTO.KontoName
                FROM dbo.FbKonto KTO WITH (READUNCOMMITTED)
                WHERE (KTO.FbPeriodeID = 0 OR KTO.FbPeriodeID IS NULL)
                  AND KTO.KontoNr IS NOT NULL
                  AND (KTO.KontoNr LIKE '{0}%' OR KTO.KontoName LIKE '{0}%')
                      {1}
                ORDER BY KTO.KontoNr;", suchbegriff, (kontoKlasse != 0 ? string.Format("AND KTO.KontoKlasseCode = {0}", DBUtil.SqlLiteral(kontoKlasse)) : ""));

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                return false;
            }

            if ((qry.Count == 1) && !open)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("KontoNr", "KontoNr", 80, HorzAlignment.Near);
            AddGridColumn("Kontoname", "KontoName", 338);

            return DisplayDialog();
        }

        /// <summary>
        /// Zeigt den Auswahldialog für BFSVariablen des angegebenen BFSFrageKatalogs an.
        /// </summary>
        /// <param name="bfsFrageKatalogJahr">Das Jahr des gesuchten BFS Fragekatalogs.</param>
        /// <param name="bfsFeldCode">Der Typ der gesuchten BFS Variable.</param>
        /// <param name="filter">Der Suchbegriff.</param>
        /// <returns></returns>
        public bool SucheBfsVariable(int bfsFrageKatalogJahr, LOV.BFSFeldCode bfsFeldCode, string filter)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(filter))
            {
                filter = string.Empty;
            }

            string sql = string.Format(@"
                SELECT
                  FRA.Variable,
                  FRA.Frage,
                  FRA.BFSKatalogVersionID
                FROM BFSFrage FRA
                WHERE FRA.BFSKatalogVersionID = (SELECT TOP 1 BFSKatalogVersionID
                                             FROM BfsKatalogVersion
                                             WHERE Jahr <= {0}
                                             ORDER BY Jahr DESC, BFSKatalogVersionID DESC)
                  AND FRA.BfsFeldCode = {1}
                  AND (FRA.Variable LIKE {2} OR FRA.Frage LIKE {2} OR FRA.Variable + ' ' + FRA.Frage LIKE {2})
                ORDER BY FRA.Variable",
                bfsFrageKatalogJahr, (int)bfsFeldCode, DBUtil.SqlLiteralLike(filter + "%"));

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineBfsVariableGefunden", "Keine zutreffende BFS Variable gefunden.");
                return false;
            }
            //else if (qry.Count == 1)
            //{
            //    this.ResultRow = qry.Row;
            //    return true;
            //}

            AddGridColumn("Variable", "Variable", 100);
            AddGridColumn("Frage", "Frage", 250);

            return DisplayDialog();
        }

        /// <summary>
        /// Zeigt den Auswahldialog für Kostenarten der angegebenen Periode an.
        /// </summary>
        /// <param name="periodeId">Die Periode.</param>
        /// <param name="filter">Suchbegriff</param>
        /// <returns></returns>
        public bool SucheKostenart(int periodeId, string filter)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(filter))
            {
                filter = string.Empty;
            }

            string sql = string.Format(@"
                SELECT KST.BgKostenartID,
                       KST.ModulID,
                       KST.Name,
                       KST.KontoNr,
                       [Weiterverrechenbar] = CASE WHEN KST.BaWVZeileCode IS NOT NULL THEN 1 ELSE 0 END,
                       KST.Quoting,
                       KST.BgSplittingArtCode,
                       [KbKontoklasse] = dbo.fnLOVText('KbKontoklasse', KTO.KbKontoklasseCode)
                FROM dbo.BgKostenart KST WITH (READUNCOMMITTED)
                  INNER JOIN dbo.KbKonto KTO WITH (READUNCOMMITTED) ON KTO.KontoNr = KST.KontoNr AND
                                                                       KTO.KbPeriodeID = {0}
                WHERE (KST.Name LIKE {1} OR KST.KontoNr LIKE {1})", periodeId, DBUtil.SqlLiteralLike(filter + "%"));

            qry.Fill(sql);

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineKostenartGefunden", "Keine zutreffende Kostenart gefunden.");
                return false;
            }
            //else if (qry.Count == 1)
            //{
            //   this.ResultRow = qry.Row;
            //   return true;
            //}

            AddGridColumn("Name", "Name", 250);
            AddGridColumn("Konto", "KontoNr", 100);
            AddGridColumn("Kontoklasse", "KbKontoklasse", 100);

            return DisplayDialog();
        }

        public override void Translate()
        {
            base.Translate();

            Text = KissMsg.GetMLMessage(CLASSNAME, "Titel", "Auswahl");
        }

        public bool WhGefKategorieSuchen(string suchbegriff, bool openDialog)
        {
            ResultRow = null;

            if (suchbegriff == string.Empty)
            {
                return true;
            }

            suchbegriff = PrepareSearchString(suchbegriff);

            string sql = string.Format(@"
                SELECT WhGefKategorieID,
                       WhGefKategorie = LOC.Text,
                       WhGefKategorieTyp = dbo.fnLOVMLText('WhGefKategorieTyp', GEF.WhGefKategorieTypCode, {1})
                FROM dbo.WhGefKategorie   GEF WITH (READUNCOMMITTED)
                  INNER JOIN dbo.XLOVCode LOC WITH (READUNCOMMITTED) ON LOC.LOVName = 'WhGefKategorie'
                                                                    AND LOC.Code = GEF.WhGefKategorieCode
                WHERE LOC.Text LIKE {0}
                  AND GEF.WhGefKategorieTypCode IN (2, 3) -- Aufwand, Ertrag
                ORDER BY LOC.Text",
                DBUtil.SqlLiteralLike(suchbegriff + "%"),
                Session.User.LanguageCode);

            qry.Fill(sql);

            if (qry.IsEmpty)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineGefKategorienGefunden", "Keine zutreffenden GEF-Kategorien gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("GEF-Kategorie", "WhGefKategorie", 320);
            AddGridColumn("Typ", "WhGefKategorieTyp", 120);

            return DisplayDialog();
        }

        /// <summary>
        /// Dialog: Zuweiser suchen.
        /// </summary>
        /// <param name="suchbegriff">The suchbegriff.</param>
        /// <param name="open">if set to <c>true</c> [open].</param>
        /// <returns></returns>
        public bool ZuweiserSuchen(string suchbegriff, bool open)
        {
            ResultRow = null;

            if (suchbegriff == "")
            {
                return true;
            }

            suchbegriff = suchbegriff.Replace(",", "%");
            suchbegriff = suchbegriff.Replace(" ", "%");

            const string sql = @"
                SELECT BeratID     = OKO.BaInstitutionKontaktID,
                       FullName    = OKO.Name + ISNULL(', ' + OKO.Vorname, ''),
                       Institution = ORG.Name,
                       Tel         = OKO.Telefon,
                       Fax         = OKO.Fax,
                       Email       = OKO.Email,
                       Name        = OKO.Name,
                       Vorname     = OKO.Vorname
                FROM dbo.BaInstitutionKontakt OKO WITH (READUNCOMMITTED)
                  INNER JOIN dbo.BaInstitution ORG ON ORG.BaInstitutionID = OKO.BaInstitutionID
                WHERE  OKO.Name + ISNULL(', ' + OKO.Vorname, '') LIKE {0}

                UNION ALL

                SELECT BeratID     = -USR.UserID,
                       FullName    = USR.LastName + ISNULL(', ' + USR.FirstName, ''),
                       Institution = 'User',
                       Tel         = USR.Phone,
                       Fax         = '',
                       Email       = USR.Email,
                       Name        = USR.LastName,
                       Vorname     = USR.FirstName
                FROM dbo.XUser USR WITH (READUNCOMMITTED)
                WHERE USR.LastName + ISNULL(', ' + USR.FirstName, '') LIKE {0}
                ORDER BY FullName";

            qry.Fill(sql, suchbegriff + "%");

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineZuweiserGefunden", "Keine zutreffenden ZuweiserInnen gefunden");
                return false;
            }

            if (qry.Count == 1 && !open)
            {
                ResultRow = qry.DataTable.Rows[0];
                return true;
            }

            AddGridColumn("Name", "FullName", 200);
            AddGridColumn("Institution", "Institution", 150);
            AddGridColumn("Telefon", "Tel", 100);

            return DisplayDialog();
        }

        private void edtFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilterColumnName) || ResultRow == null)
            {
                return;
            }

            var searchString = edtFilter.Text;

            try
            {
                qry.DataTable.DefaultView.RowFilter = FilterColumnName + " LIKE '%" + searchString + "%'";
            }
            catch (Exception ex)
            {
                KissMsg.ShowError(CLASSNAME, "FilterUngueltig", "'{0}' ist kein gültiger Filter.", null, ex, searchString);
            }
        }

        private bool SearchBank(string searchClearingNrOrNameParam, bool openDialog, bool allActivBanks)
        {
            ResultRow = null;

            if (string.IsNullOrEmpty(searchClearingNrOrNameParam) && !allActivBanks)
            {
                return true;
            }

            string sql = @"
                SELECT BaBankID,
                       Name,
                       ClearingNr,
                       Strasse,
                       Ort = ISNULL(PLZ + ' ', '') + ISNULL(Ort, ''),
                       PCKontoNr
                FROM dbo.BaBank WITH (READUNCOMMITTED)
                WHERE ClearingNrNeu IS NULL ";

            if (!allActivBanks)
            {
                if (!Utils.IsNatural(searchClearingNrOrNameParam))
                {
                    sql += " AND Name LIKE {0}";
                    searchClearingNrOrNameParam = string.Format("{0}%", searchClearingNrOrNameParam);
                }
                else
                {
                    sql += " AND ClearingNr = {0}";
                }
                qry.Fill(sql, searchClearingNrOrNameParam);
            }
            else
            {
                qry.Fill(sql);
            }

            if (qry.Count == 0)
            {
                KissMsg.ShowInfo(CLASSNAME, "KeineBankGefunden", "Keine zutreffenden Bank gefunden");
                return false;
            }

            if (qry.Count == 1 && !openDialog)
            {
                ResultRow = qry.Row;
                return true;
            }

            AddGridColumn("Name", "Name", 250);
            AddGridColumn("Clearing Nr", "ClearingNr", 150);
            AddGridColumn("Strasse", "Strasse", 350);
            AddGridColumn("Ort", "Ort", 400);
            AddGridColumn("PcKontoNr", "PCKontoNr", 150);

            return DisplayDialog();
        }

        private void ShowFilterOrCountIfColumnNameFilled()
        {
            edtFilter.Visible = _showFilter;
            lblCount.Visible = !_showFilter;
        }
    }
}