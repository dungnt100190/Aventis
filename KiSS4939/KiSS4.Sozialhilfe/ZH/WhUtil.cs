using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using KiSS4.Common;
using KiSS4.DB;
using KiSS4.Gui;

namespace KiSS4.Sozialhilfe.ZH
{
    public static class WhUtil
    {
        #region Fields

        #region Public Constant/Read-Only Fields

        /// <summary>
        /// Select um die Liste von Benutzer für die Bewilligungsanfrage zu holen oder alle Benutzer eines QT
        /// Parameter:
        ///     {0} @SearchUser:       NameVorname oder LogonName für die Suche von User in Dialog
        ///     {1} @UserID:           UserID der Anfragt
        ///     {2} @DetermineDefault: true um den Default-Wert zu bekommen. false um die Liste von User die angefragt werden kommen zu bekommen
        ///     {3} @UserID_LV:        UserID des Leistungsverantwortliche
        ///     {4} @GetUserInQt:      true um Liste von User in gleichem QT zu bekommen
        ///     {5} @GetUserInSz:      true um Liste von User in gleichem SZ zu bekommen
        ///
        /// Return:
        /// 1. Select: Liste von User
        /// 2. Select: Stufe des Anfragers
        /// </summary>
        public const string SELECT_USERS_FOR_BEWILLIGUNG_OR_SAME_QT_OR_SZ = @"
            /* Stufe 0: SB, Klibu oder aus andere QT
                     1: SA
                     2: SL
                     3: ZL

               Default User: SB -> SA
                             SA -> SL
                             SL -> leer
            */

            --Suchparameter initialisieren
            DECLARE @UserID INT;
            DECLARE @Stufe_Anfrager INT;
            DECLARE @DetermineDefault BIT;
            DECLARE @UserID_LV INT;
            DECLARE @GetUserInQt BIT;
            DECLARE @GetUserInSz BIT;
            DECLARE @SearchUser VARCHAR(MAX);
            DECLARE @PermissionGroupIDSachbearbeiter INT;

            SET @SearchUser = {0};
            SET @UserID = {1};
            SET @DetermineDefault = {2};
            SET @UserID_LV = {3};
            SET @GetUserInQt = {4};
            SET @GetUserInSz = {5};
            SET @PermissionGroupIDSachbearbeiter = {6};

            --Daten des Leistungsverantwortlichen ermitteln
            DECLARE @OrgUnitID_LV INT;
            DECLARE @NameVorname_LV VARCHAR(250);
            DECLARE @LogonName_LV VARCHAR(50);

            SELECT
              @OrgUnitID_LV = OUU.OrgUnitID,
              @NameVorname_LV = USR.NameVorname,
              @LogonName_LV = USR.LogonName
            FROM dbo.vwUser                 USR WITH (READUNCOMMITTED)
              INNER JOIN dbo.XOrgUnit_User  OUU WITH (READUNCOMMITTED) ON OUU.UserID = USR.UserID
                                                                      AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
            WHERE USR.UserID = @UserID_LV;

            --Ist Anfrager der LV?
            IF (@UserID = @UserID_LV)
            BEGIN
              SET @Stufe_Anfrager = 1;
            END;

            --Ist Anfrager Klibu-Mitarbeiter?
            DECLARE @MasterKlibuOrgUnitID INT;
            DECLARE @IsKlibuUser BIT;

            SET @IsKlibuUser = CONVERT(BIT, 0);

            SELECT @MasterKlibuOrgUnitID = CONVERT(INT, dbo.fnXConfig('System\KliBu\KliBuAbteilungID', GETDATE()));

            ;WITH KlibuOrgUnit AS
            (
              SELECT
                ORG.OrgUnitID,
                ORG.ParentID
              FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
              WHERE OrgUnitID = @MasterKlibuOrgUnitID

              UNION ALL

              SELECT
                ORG.OrgUnitID,
                ORG.ParentID
              FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
                INNER JOIN KlibuOrgUnit CTE ON CTE.OrgUnitID = ORG.ParentID
            )

            SELECT @Stufe_Anfrager = 0
            FROM KlibuOrgUnit              CTE
              INNER JOIN dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.OrgUnitID = CTE.OrgUnitID
            WHERE OUU.UserID = @UserID;

            --Hierarchie-Stufe des Anfragers ermitteln
            IF(@Stufe_Anfrager IS NULL)
            BEGIN
              SELECT @Stufe_Anfrager = 3
              FROM dbo.XOrgUnit         ORG_PAR WITH (READUNCOMMITTED)
                INNER JOIN dbo.XOrgUnit ORG_LV  WITH (READUNCOMMITTED) ON ORG_LV.ParentID = ORG_PAR.OrgUnitID
                                                                      AND ORG_LV.OrgUnitID = @OrgUnitID_LV
              WHERE ORG_PAR.ChiefID = @UserID
                OR ORG_PAR.StellvertreterID = @UserID  --Anfrager ist Leiter oder STV des Sozialzentrums des LV
            END;

            IF(@Stufe_Anfrager IS NULL)
            BEGIN
              SELECT @Stufe_Anfrager = 2
              FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
              WHERE ORG.OrgUnitID = @OrgUnitID_LV
                AND (ORG.ChiefID = @UserID
                  OR ORG.StellvertreterID = @UserID)  --Anfrager ist Leiter oder STV des QTs des LV
            END;

            IF(@Stufe_Anfrager IS NULL)
            BEGIN
              SELECT @Stufe_Anfrager = CASE
                                         WHEN (USR.PermissionGroupID IS NULL AND USR.GrantPermGroupID IS NULL) THEN 0  -- User hat weder Eigenkompetenz noch Fremdkompetenz, dann ist es ein SB
                                         WHEN (ISNULL(USR.PermissionGroupID, @PermissionGroupIDSachbearbeiter) = @PermissionGroupIDSachbearbeiter AND ISNULL(USR.GrantPermGroupID, @PermissionGroupIDSachbearbeiter) = @PermissionGroupIDSachbearbeiter) THEN 0  -- User ist in SB-Kompetenzgruppe
                                         ELSE 1
                                       END
              FROM dbo.XOrgUnit_User OUU WITH (READUNCOMMITTED)
                INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = OUU.UserID
              WHERE OUU.OrgUnitID = @OrgUnitID_LV
                AND OUU.OrgUnitMemberCode = 2
                AND OUU.UserID = @UserID;    --Anfrager gehört zu QT des LV
            END;

            IF(@Stufe_Anfrager IS NULL)
            BEGIN
              -- Anfrager ist SL oder Stv. SL aus QTs im gleichen SZ
              SELECT @Stufe_Anfrager = 2
              FROM dbo.XLOVCode         QT_LV   WITH (READUNCOMMITTED)
                INNER JOIN dbo.XLOVCode GRP     WITH (READUNCOMMITTED) ON GRP.LOVName = 'QuOrgUnitGroup'
                                                                      AND ','+QT_LV.Value3+',' LIKE '%,'+GRP.Value1+',%'
                INNER JOIN dbo.XLOVCode QT_STV  WITH (READUNCOMMITTED) ON QT_STV.LOVName = 'QuOrgUnitTeam'
                                                                     AND ','+QT_STV.Value3+',' LIKE '%,'+GRP.Value1+',%'
                INNER JOIN dbo.XOrgUnit ORG_STV WITH (READUNCOMMITTED) ON ORG_STV.OrgUnitID = QT_STV.Code
                INNER JOIN dbo.vwUser   USR_STV WITH (READUNCOMMITTED) ON USR_STV.UserID = ORG_STV.ChiefID
                                                                       OR USR_STV.UserID = ORG_STV.StellvertreterID
              WHERE QT_LV.LOVName = 'QuOrgUnitTeam'
                AND QT_LV.Code = @OrgUnitID_LV
                AND USR_STV.IsLocked = 0
                AND USR_STV.UserID = @UserID
            END;

            IF(@Stufe_Anfrager IS NULL)
            BEGIN
              SET @Stufe_Anfrager = 0;  --Anfrager ist offenbar ausserhalb des QTs des LV und nicht SL oder Stv. SL im gleichen SZ
            END;

            ;WITH User_CTE AS
            (
              -- LV
              SELECT
                USR.UserID,
                USR.NameVorname,
                USR.LogonName,
                Stufe = 1,
                IsStv = 0,
                IsInQt = 1,
                IsInSz = 1,
                Bezeichnung = 'LV'
              FROM dbo.vwUser USR
              WHERE USR.UserID = @UserID_LV

              UNION ALL

              --Alle MAs des Quartier-Teams des LV
              SELECT
                USR.UserID,
                USR.NameVorname,
                USR.LogonName,
                Stufe = CASE USR.UserID
                          WHEN ORG.ChiefID THEN 2
                          WHEN ORG.StellvertreterID THEN 2
                          ELSE 1
                        END,
                IsStv = CASE USR.UserID
                          WHEN ORG.ChiefID THEN 0
                          WHEN ORG.StellvertreterID THEN 1
                          WHEN @UserID_LV THEN 0
                          ELSE 1
                        END,
                IsInQt = 1,
                IsInSz = 1,
                Bezeichnung = CASE USR.UserID
                                WHEN ORG.ChiefID THEN 'SL'
                                WHEN ORG.StellvertreterID THEN 'Stv. SL'
                                WHEN @UserID_LV THEN 'LV'
                                ELSE 'SA'
                              END
              FROM XOrgUnit             ORG WITH (READUNCOMMITTED)
                LEFT JOIN XOrgUnit_User OUU WITH (READUNCOMMITTED) ON OUU.OrgUnitID = ORG.OrgUnitID
                                                                  AND OUU.OrgUnitMemberCode = 2 --2: Mitglied
                INNER JOIN vwUser       USR WITH (READUNCOMMITTED) ON USR.UserID = OUU.UserID
                                                                   OR USR.UserID = ORG.ChiefID
                                                                   OR USR.UserID = ORG.StellvertreterID
              WHERE ORG.OrgUnitID = @OrgUnitID_LV
                AND ((USR.PermissionGroupID IS NOT NULL OR USR.GrantPermGroupID IS NOT NULL) -- User muss entweder Eigenkompetenz oder Fremdkompetenz haben, welche nicht die SB-Gruppe ist (dann ist es kein SB)
                     AND ISNULL(USR.PermissionGroupID, -1) <> @PermissionGroupIDSachbearbeiter
                     AND ISNULL(USR.GrantPermGroupID, -1) <> @PermissionGroupIDSachbearbeiter)
                AND USR.IsLocked = 0

              UNION ALL

              --Leitung und STV des QT des LV und deren Stellvertreter aus den anderen QTs (im gleichen Sozialzentrum)
              SELECT
                USR_STV.UserID,
                USR_STV.NameVorname,
                USR_STV.LogonName,
                Stufe = 2,
                IsStv = CASE WHEN USR_STV.UserID = ORG_STV.ChiefID
                              AND ORG_STV.OrgUnitID = @OrgUnitID_LV THEN 0
                                                                    ELSE 1
                        END,
                IsInQt = CASE WHEN ORG_STV.OrgUnitID = @OrgUnitID_LV THEN 1 ELSE 0 END ,
                IsInSz = 1,
                Bezeichnung = CASE WHEN USR_STV.UserID = ORG_STV.ChiefID THEN 'SL' ELSE 'Stv. SL' END +
                              CASE WHEN ORG_STV.OrgUnitID = @OrgUnitID_LV THEN '' ELSE ' (anderes QT)' END
              FROM dbo.XLOVCode         QT_LV   WITH (READUNCOMMITTED)
                INNER JOIN dbo.XLOVCode GRP     WITH (READUNCOMMITTED) ON GRP.LOVName = 'QuOrgUnitGroup'
                                                                      AND ','+QT_LV.Value3+',' LIKE '%,'+GRP.Value1+',%'
                INNER JOIN dbo.XLOVCode QT_STV  WITH (READUNCOMMITTED) ON QT_STV.LOVName = 'QuOrgUnitTeam'
                                                                     AND ','+QT_STV.Value3+',' LIKE '%,'+GRP.Value1+',%'
                INNER JOIN dbo.XOrgUnit ORG_STV WITH (READUNCOMMITTED) ON ORG_STV.OrgUnitID = QT_STV.Code
                INNER JOIN dbo.vwUser   USR_STV WITH (READUNCOMMITTED) ON USR_STV.UserID = ORG_STV.ChiefID
                                                                       OR USR_STV.UserID = ORG_STV.StellvertreterID
              WHERE QT_LV.LOVName = 'QuOrgUnitTeam'
                AND QT_LV.Code = @OrgUnitID_LV
                AND USR_STV.IsLocked = 0

              UNION ALL

              --Leitung und STV des Sozialzentrums
              SELECT
                USR.UserID,
                USR.NameVorname,
                USR.LogonName,
                Stufe=3,
                IsStv = CASE USR.UserID
                          WHEN ORG_PAR.ChiefID THEN 0
                          ELSE 1
                        END,
                IsInQt = 1,
                IsInSz = 1,
                Bezeichnung = CASE USR.UserID
                                WHEN ORG_PAR.ChiefID THEN 'ZL'
                                ELSE 'Stv. ZL'
                              END
              FROM dbo.XOrgUnit         ORG_PAR WITH (READUNCOMMITTED)
                INNER JOIN dbo.XOrgUnit ORG_LV  WITH (READUNCOMMITTED) ON ORG_LV.ParentID = ORG_PAR.OrgUnitID
                                                                      AND ORG_LV.OrgUnitID = @OrgUnitID_LV
                INNER JOIN dbo.vwUser   USR     WITH (READUNCOMMITTED) ON USR.UserID = ORG_PAR.ChiefID
                                                                       OR USR.UserID = ORG_PAR.StellvertreterID
              WHERE USR.IsLocked = 0
            )

            --OUTPUT
            SELECT
              UserID$   = UserID,
              Name      = NameVorname,
              LogonName = LogonName,
              Stufe$    = MIN(Stufe),
              IsStv$    = MIN(IsStv),
              IsInQt$   = MAX(IsInQt),
              IsInSz$   = MAX(IsInSz),
              Bezeichnung = dbo.ConcDistinctOrder(Bezeichnung)
            FROM User_CTE
            WHERE
              -- Default-User für die Anfrage
              ((@GetUserInSz = 0
                AND @GetUserInQt = 0
                AND @DetermineDefault = 1
                AND Stufe = @Stufe_Anfrager + 1
                AND @Stufe_Anfrager < 2) -- kein default Wert für SL

              -- User für die Anfrage auflisten
              OR (@GetUserInSz = 0
                AND @GetUserInQt = 0
                AND @DetermineDefault = 0
                AND (Stufe > @Stufe_Anfrager
                  OR Stufe >= @Stufe_Anfrager AND Stufe = 2) -- SL können auf der selbe Stufe anfragen
                AND (NameVorname LIKE @SearchUser + '%' OR LogonName LIKE @SearchUser + '%'))

              -- User in gleichem QT auflisten
              OR (@GetUserInSz = 0
                AND @GetUserInQt = 1
                AND IsInQt = 1)

              -- User in gleichem SZ auflisten
              OR (@GetUserInSz = 1
                AND IsInSz = 1))
            GROUP BY UserID, NameVorname, LogonName
            ORDER BY
              CASE WHEN MIN(Stufe) = 3 THEN 1 ELSE 0 END, -- ZL ganz am schluss anzeigen
              IsInSz$ DESC,
              IsInQt$ DESC,
              IsStv$,
              Stufe$,
              Name;

            SELECT Stufe_Anfrager = @Stufe_Anfrager;";

        #endregion Public Constant/Read-Only Fields

        #region Private Constant/Read-Only Fields

        private const string QRY_SEARCH_EMPFAENGER = @"
            -- Auswahl für Feld Empfänger in der Abfrage Bewilligung
            -- Alle nicht gesperrten User eines Sozialzentrums
            -- ab Rolle Sozialarbeiter, d.h. mit Kompetenzstufe grösser als 0.
            -- (Sachbearbeiter (werden nicht angezeigt), Sozialarbeiter, Stellenleiter/Stv, Zentrumsleiter/Stv)
            --Suchparameter initialisieren
            DECLARE @UserID INT;

            SET @UserID = {1};

            -- Sozialzentrum ermitteln
            DECLARE @OrgUnitIDSozialzentrum INT;
            SELECT @OrgUnitIDSozialzentrum = dbo.fnSozialzentrumVomUser(@UserID);

            -- Alle Unter-Organisationseinheiten ermitteln
            -- Stufen sind noch zu debugging Zwecken enthalten.
            ;WITH OrgUnit_CTE AS
            (
              SELECT ORG.OrgUnitID, ORG.ParentID, ORG.ItemName, Stufe = 1
              FROM dbo.XOrgUnit ORG WITH(READUNCOMMITTED)
              WHERE ORG.OrgUnitID = @OrgUnitIDSozialzentrum

              UNION ALL

              SELECT ORG.OrgUnitID, ORG.ParentID, ORG.ItemName, Stufe = Stufe + 1
              FROM dbo.XOrgUnit         ORG WITH(READUNCOMMITTED)
                INNER JOIN OrgUnit_CTE  X ON X.OrgUnitID = ORG.ParentID
                INNER JOIN dbo.XLOVCode QT_STV WITH(READUNCOMMITTED) ON QT_STV.LOVName = 'QuOrgUnitTeam'
                                                                    AND QT_STV.Code = ORG.OrgUnitID
            )

            SELECT DISTINCT
              UserID$   = USR.UserID,
              Name      = USR.NameVorname,
              LogonName = USR.LogonName
            FROM OrgUnit_CTE ORG
              INNER JOIN dbo.XOrgUnit_User OUU WITH(READUNCOMMITTED) ON OUU.OrgUnitID = ORG.OrgUnitID
                                                                    AND OUU.OrgUnitMemberCode = 2
              INNER JOIN dbo.vwUser        USR WITH(READUNCOMMITTED) ON USR.UserID = OUU.UserID
            WHERE (dbo.fnKompetenzstufe(USR.UserID) > 0)
              AND (USR.IsLocked = 0) -- Gesperrte User werden nicht angezeigt.
              AND (NameVorname LIKE {0} OR LogonName LIKE {0})
            ORDER BY Name;";

        #endregion Private Constant/Read-Only Fields

        #endregion Fields

        #region Methods

        #region Public Static Methods

        /// <summary>
        /// Prüft das GültigBis-Datum einer Masterbudgetposition.
        /// Das Datum darf nicht früher sein als das letzte Monatsbudget (grau, grün oder rot), welches diese FP Position enthält
        /// </summary>
        public static void CheckIfGueltigBisIsValidWithMonatsbudget(int? bgPositionIdMasterbudget, DateTime gueltigBis)
        {
            // das Datum darf nicht früher sein als das letzte Monatsbudget (grau, grün oder rot), welches diese FP Position enthält
            var hatMonatsbudget = DBUtil.ExecuteScalarSQLThrowingException(@"
                        IF(EXISTS(SELECT TOP 1 1
                                  FROM dbo.BgPosition POS WITH (READUNCOMMITTED)
                                    INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
                                  WHERE BgPositionID_CopyOf = {0}
                                    AND dbo.fnLastDayOf(dbo.fnDateSerial(BDG.Jahr, BDG.Monat, 1)) > {1}))
                        BEGIN
                          SELECT CONVERT(BIT, 1);
                        END
                        ELSE
                        BEGIN
                          SELECT CONVERT(BIT, 0);
                        END;",
                bgPositionIdMasterbudget,
                gueltigBis) as bool? ?? false;
            if (hatMonatsbudget)
            {
                throw new KissInfoException("'Gültig bis' darf nicht früher sein als das letzte Monatsbudget (grau, grün oder rot), welches diese FP Position enthält.");
            }
        }

        public static void CheckIfInsertVerrechnungspositionIsAllowed(int kategorie, int budgetStatusCode, int? bgPositionsartID)
        {
            // ZL und nicht graues Budget mit Auto-Verrechnung
            if (kategorie == 100 && budgetStatusCode != 1 && IsPositionsartWithAutoVerrechnung(bgPositionsartID))
            {
                throw new KissInfoException(
                    KissMsg.GetMLMessage(
                        typeof(WhUtil).Name,
                        "ZlMitAutoVerrechnungspositionNurInGraueBudget",
                        "Zusätzliche Leistungen mit automatischen Verrechnungspositionen können nur in grauen Budgets erfasst werden."));
            }
        }

        public static void DeleteVerrechnungsposition(int originalBgPositionId)
        {
            DBUtil.ExecuteScalarSQLThrowingException(@"
                DELETE POS
                FROM dbo.BgPosition POS
                WHERE POS.BgPositionID_Parent = {0}
                  AND POS.BgKategorieCode = 3;", originalBgPositionId);
        }

        public static bool FinanzplanPositionAufheben(UserControl control, SqlQuery qryPosition)
        {
            // Prüfen ob diese FP-Position bereits in einem Monatsbudget verwendet wird.
            var hatMonatsbudget = DBUtil.ExecuteScalarSQLThrowingException(@"
                IF(EXISTS(SELECT TOP 1 1
                          FROM dbo.BgPosition POS WITH (READUNCOMMITTED)
                          INNER JOIN dbo.BgBudget BDG WITH (READUNCOMMITTED) ON BDG.BgBudgetID = POS.BgBudgetID
                          WHERE BgPositionID_CopyOf = {0}))
                BEGIN
                    SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                    SELECT CONVERT(BIT, 0);
                END;",
                qryPosition["BgPositionID"]) as bool? ?? false;
            if (hatMonatsbudget)
            {
                KissMsg.ShowInfo("Für diese Finanzplan-Position gibt es bereits graue/grüne/rote Monatsbudgets.");
                return true;
            }

            var dlg = new DlgWhPositionVisieren((int)qryPosition["BgPositionID"], BewilligungAktionZH.Aufheben, null);
            dlg.ShowDialog(control);
            if (dlg.UserCancel)
            {
                return true;
            }

            Session.BeginTransaction();
            try
            {
                // Position aufheben
                dlg.InsertBewilligungsHistory();
                qryPosition["BgBewilligungStatusCode"] = (int)BgBewilligungStatus.InVorbereitung;
                qryPosition["BewilligtVon"] = null;
                qryPosition["BewilligtBis"] = null;
                qryPosition["BewilligtBetrag"] = null;

                qryPosition.Post();

                Session.Commit();
            }
            catch (Exception ex)
            {
                Session.Rollback();
                KissMsg.ShowInfo(ex.Message);
            }

            return false;
        }

        public static int GetSachbearbeiterGruppeID()
        {
            return DBUtil.GetConfigInt(@"System\WH\Kompetenzgruppe_Sachbearbeiter", -1);
        }

        public static SqlQuery GetSqlQueryUsersForBewilligung(string searchUser, int? userId, bool determineDefault, int userIdFall, bool getUserInQt, bool getUserInSz)
        {
            var sachbearbeiterGruppeId = GetSachbearbeiterGruppeID();
            return DBUtil.OpenSQL(SELECT_USERS_FOR_BEWILLIGUNG_OR_SAME_QT_OR_SZ, searchUser, userId, determineDefault, userIdFall, getUserInQt, getUserInSz, sachbearbeiterGruppeId);
        }

        public static bool HasVerrechnungsPosition(int? originalBgPositionId)
        {
            if (!originalBgPositionId.HasValue)
            {
                return false;
            }

            return DBUtil.ExecuteScalarSQLThrowingException(@"
                IF (EXISTS(-- Verrechnungspositionen von Detailposten
                           SELECT TOP 1 1
                           FROM dbo.BgPosition POS
                             INNER JOIN dbo.BgPosition POSV ON POSV.BgPositionID_Parent = POS.BgPositionID
                                                           AND POSV.BgKategorieCode = 3
                           WHERE POS.BgPositionID_Parent = {0}
                           UNION
                           -- Verrechnungsposition
                           SELECT TOP 1 1
                           FROM dbo.BgPosition POS
                           WHERE POS.BgPositionID_Parent = {0}
                             AND POS.BgKategorieCode = 3))
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END;",
                originalBgPositionId.Value) as bool? ?? false;
        }

        public static void InsertOrUpdateVerrechnungsposition(int originalBgPositionId)
        {
            var qryPosition = DBUtil.OpenSQL(@"
                SELECT
                    POS.BgPositionID,
                    POS.BgBudgetID,
                    POS.BgPositionID_Parent,
                    POS.BaPersonID,
                    POS.BgPositionsartID,
                    POS.BgSpezkontoID,
                    POS.BgKategorieCode,
                    POS.DatumVon,
                    POS.DatumBis,
                    POS.VerwPeriodeVon,
                    POS.VerwPeriodeBis,
                    POS.Betrag,
                    POS.Reduktion,
                    POS.Buchungstext,
                    POS.BgBewilligungStatusCode,
                    POS.ErstelltUserID,
                    POS.ErstelltDatum,
                    POS.MutiertUserID,
                    POS.MutiertDatum
                FROM dbo.BgPosition POS WITH(READUNCOMMITTED)
                WHERE POS.BgPositionID = {0};",
                originalBgPositionId);

            InsertOrUpdateVerrechnungsposition(qryPosition.Row);
        }

        public static void InsertOrUpdateVerrechnungsposition(SqlQuery qryBgPosition)
        {
            InsertOrUpdateVerrechnungsposition(qryBgPosition.Row);
        }

        public static void InsertOrUpdateVerrechnungsposition(DataRow row)
        {
            var originalBgPositionId = (int)row["BgPositionID"];

            if (!IsPositionsartWithAutoVerrechnung(row["BgPositionsartID"] as int?))
            {
                DeleteVerrechnungsposition(originalBgPositionId);
                return;
            }

            var verrechnungsposition = DBUtil.OpenSQL(@"
                SELECT
                    POS.BgPositionID,
                    POS.BgBudgetID,
                    POS.BgPositionID_Parent,
                    POS.BaPersonID,
                    POS.BgPositionsartID,
                    POS.BgKategorieCode,
                    POS.DatumVon,
                    POS.DatumBis,
                    POS.VerwPeriodeVon,
                    POS.VerwPeriodeBis,
                    POS.Betrag,
                    POS.Buchungstext,
                    POS.BgBewilligungStatusCode,
                    POS.ErstelltUserID,
                    POS.ErstelltDatum,
                    POS.MutiertUserID,
                    POS.MutiertDatum
                FROM dbo.BgPosition POS WITH(READUNCOMMITTED)
                WHERE POS.BgPositionID_Parent = {0}
                  AND POS.BgKategorieCode = 3;",
                originalBgPositionId);

            verrechnungsposition.CanInsert = true;
            verrechnungsposition.CanUpdate = true;

            if (verrechnungsposition.IsEmpty)
            {
                verrechnungsposition.Insert("BgPosition");
            }

            // Daten kopieren
            verrechnungsposition["BgBudgetID"] = row["BgBudgetID"];
            verrechnungsposition["BgPositionID_Parent"] = originalBgPositionId;
            verrechnungsposition["BaPersonID"] = row["BaPersonID"];
            verrechnungsposition["BgKategorieCode"] = 3; // Verrechnung
            verrechnungsposition["DatumVon"] = row["DatumVon"];
            verrechnungsposition["DatumBis"] = row["DatumBis"];
            verrechnungsposition["VerwPeriodeVon"] = row["VerwPeriodeVon"];
            verrechnungsposition["VerwPeriodeBis"] = row["VerwPeriodeBis"];
            verrechnungsposition["Betrag"] = (decimal)row["Betrag"] - Utils.ConvertToDecimal(row["Reduktion"], 0m);
            verrechnungsposition["Buchungstext"] = row["Buchungstext"];
            verrechnungsposition["BgBewilligungStatusCode"] = row["BgBewilligungStatusCode"];
            verrechnungsposition["MutiertUserID"] = Session.User.UserID;
            verrechnungsposition["MutiertDatum"] = DateTime.Now;

            if (DBUtil.IsEmpty(verrechnungsposition["ErstelltUserID"]))
            {
                verrechnungsposition["ErstelltUserID"] = Session.User.UserID;
                verrechnungsposition["ErstelltDatum"] = DateTime.Now;
            }

            verrechnungsposition.Post("BgPosition");
        }

        public static bool InsertPositionVerlaufEintrag(int bgPositionID, int userID, string name, int bgBewilligungCode)
        {
            SqlQuery qryBgBewilligung = DBUtil.OpenSQL(@"
                SELECT BgBewilligungID,
                       BgPositionID,
                       UserID,
                       ClassName,
                       Datum,
                       BgBewilligungCode
                FROM BgBewilligung
                WHERE 0 = 1 --wir wollen keine Rows erhalten beim ersten Fill()");

            qryBgBewilligung.Fill();
            qryBgBewilligung.Insert("BgBewilligung");

            qryBgBewilligung["BgPositionID"] = bgPositionID;
            qryBgBewilligung["UserID"] = userID;
            qryBgBewilligung["ClassName"] = name;
            qryBgBewilligung["Datum"] = DateTime.Now;
            qryBgBewilligung["BgBewilligungCode"] = bgBewilligungCode;
            return qryBgBewilligung.Post();
        }

        /// <summary>
        /// Prüft ob zwei Benutzer in gleicher Abteilung sind.
        /// </summary>
        /// <param name="userId1">UserID des ersten Benutzer</param>
        /// <param name="userId2">UserID des zweiten Benutzer</param>
        /// <returns></returns>
        public static bool IsMemberOfGleicheAbteilung(int userId1, int userId2)
        {
            // beide Benutzer sind in der selbe Abteilung
            var qryUserInSameOrgUnit = DBUtil.OpenSQL(@"
                SELECT UserInSameOrgUnit = 1
                FROM dbo.XOrgUnit_User WITH (READUNCOMMITTED)
                WHERE UserID IN ({0}, {1})
                  AND OrgUnitMemberCode = 2 --2: Mitglied
                GROUP BY OrgUnitID
                HAVING COUNT(1) > 1;",
                userId1,
                userId2);

            if (!qryUserInSameOrgUnit.IsEmpty)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Prüft ob zwei Benutzer im gleichen QT sind.
        /// </summary>
        /// <param name="userId1">UserID des ersten Benutzer</param>
        /// <param name="userId2">UserID des zweiten Benutzer</param>
        /// <param name="userIdFall">UserID des Falles um den Baum zu erstellen</param>
        /// <returns></returns>
        public static bool IsMemberOfGleichesQt(int userId1, int userId2, int userIdFall)
        {
            if (IsMemberOfGleicheAbteilung(userId1, userId2))
            {
                return true;
            }

            // beide Benutzer sind im selben QT (inkl. SL und ZL) als den Fallverantwortliche
            var qryUser = GetSqlQueryUsersForBewilligung(null, null, false, userIdFall, true, false);

            if (qryUser.Find(string.Format("UserID$ = {0}", userId1)) && qryUser.Find(string.Format("UserID$ = {0}", userId2)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Prüft ob zwei Benutzer im gleichen Sozialzentrum sind.
        /// </summary>
        /// <param name="userId1">UserID des ersten Benutzer</param>
        /// <param name="userId2">UserID des zweiten Benutzer</param>
        /// <param name="userIdFall">UserID des Falles um den Baum zu erstellen</param>
        /// <returns></returns>
        public static bool IsMemberOfGleichesSz(int userId1, int userId2, int userIdFall)
        {
            if (IsMemberOfGleicheAbteilung(userId1, userId2))
            {
                return true;
            }

            // beide Benutzer sind im selben SZ als den Fallverantwortliche
            var qryUser = GetSqlQueryUsersForBewilligung(null, null, false, userIdFall, false, true);

            if (qryUser.Find(string.Format("UserID$ = {0}", userId1)) && qryUser.Find(string.Format("UserID$ = {0}", userId2)))
            {
                return true;
            }

            return false;
        }

        public static bool IsPositionsartWithAutoVerrechnung(int? bgPositionsartId)
        {
            if (!bgPositionsartId.HasValue)
            {
                return false;
            }

            var originalBgPositionsartIdString = DBUtil.GetConfigString(@"System\Sozialhilfe\AutoVerrechnung\VVGPositionsartIDs", "");

            var originalBgPositionsartIds = originalBgPositionsartIdString
                .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            return originalBgPositionsartIds.Contains(bgPositionsartId.Value);
        }

        public static bool IsSachbearbeiter()
        {
            return IsSachbearbeiter(Session.User.UserID);
        }

        public static bool IsSachbearbeiter(int userID)
        {
            var permissionGroupIdSachbearbeiter = GetSachbearbeiterGruppeID();

            var isSachbearbeiter = DBUtil.ExecuteScalarSQLThrowingException(@"
                SELECT
                    CASE
                      WHEN (PermissionGroupID IS NULL AND GrantPermGroupID IS NULL) THEN CONVERT(BIT, 1)
                      WHEN (ISNULL(PermissionGroupID, {1}) = {1} AND ISNULL(GrantPermGroupID, {1}) = {1}) THEN CONVERT(BIT, 1)
                      ELSE CONVERT(BIT, 0)
                    END
                FROM dbo.XUser USR WITH (READUNCOMMITTED)
                WHERE UserID = {0};", userID, permissionGroupIdSachbearbeiter) as bool? ?? false;

            return isSachbearbeiter;
        }

        public static void SearchEmpfaenger(KissButtonEdit edtEmpfaenger, UserModifiedFldEventArgs e)
        {
            string searchString;

            if (edtEmpfaenger.EditValue != null)
            {
                searchString = edtEmpfaenger.EditValue.ToString();
            }
            else
            {
                searchString = String.Empty;
            }

            var buttonClicked = e.ButtonClicked;

            if (DBUtil.IsEmpty(searchString))
            {
                if (buttonClicked)
                {
                    searchString = "%";
                }
                else
                {
                    //Benutzer hat keinen User ausgewählt, select default
                    SetEmpfaengerDefault(edtEmpfaenger);
                    return;
                }
            }

            if (searchString == ".")
            {
                searchString = "%";
            }

            //Suche nach User mit searchString durchführen
            using (var dlg = new KissLookupDialog())
            {
                bool cancel =
                    !dlg.SearchData(QRY_SEARCH_EMPFAENGER,
                        KissLookupDialog.PrepareSearchString(searchString + "%"),
                        buttonClicked,
                        Session.User.UserID);

                if (!cancel)
                {
                    edtEmpfaenger.EditValue = dlg["Name"];
                    edtEmpfaenger.LookupID = dlg["UserID$"];
                }
                else
                {
                    //Benutzer hat keinen User ausgewählt, select  default
                    SetEmpfaengerDefault(edtEmpfaenger);
                }
            }
        }

        public static void SetEmpfaengerDefault(KissButtonEdit edtEmpfaenger)
        {
            if (!IsSachbearbeiter())
            {
                edtEmpfaenger.EditValue = Session.User.LastFirstName;
                edtEmpfaenger.LookupID = Session.User.UserID;
            }
            else
            {
                edtEmpfaenger.LookupID = null;
                edtEmpfaenger.EditValue = null;
            }
        }

        #endregion Public Static Methods

        #endregion Methods

        public static bool HasNichtbewilligteZusaetzlicheLeistungenMitAutoverrechnung(int bgBudgetId)
        {
            return DBUtil.ExecuteScalarSQLThrowingException(@"
                DECLARE @POAsMitAutoVerrechnung TABLE (BgPositionsartID INT);
                DECLARE @POAsMitAutoVerrechnungString VARCHAR(MAX);

                SET @POAsMitAutoVerrechnungString = dbo.fnXConfigVarchar('System\Sozialhilfe\AutoVerrechnung\VVGPositionsartIDs', GETDATE());

                INSERT INTO @POAsMitAutoVerrechnung (BgPositionsartID)
                SELECT CONVERT(INT, Value)
                FROM dbo.fnSplit(@POAsMitAutoVerrechnungString, ',');

                IF (EXISTS(SELECT TOP 1 1
                           FROM dbo.BgPosition POS
                             INNER JOIN @POAsMitAutoVerrechnung POAS ON POAS.BgPositionsartID = POS.BgPositionsartID
                           WHERE POS.BgBudgetID = {0}
                             AND POS.BgKategorieCode = 100 --nur ZL
                             AND POS.BgBewilligungStatusCode IN (1, 2, 3))) --1: In Vorbereitung (grau), 2: Bewilligung abgelehnt, 3: Bewilligung angefragt
                BEGIN
                  SELECT CONVERT(BIT, 1);
                END
                ELSE
                BEGIN
                  SELECT CONVERT(BIT, 0);
                END;",
                bgBudgetId) as bool? ?? false;
        }
    }
}