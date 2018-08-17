SET NOCOUNT ON
GO

DECLARE @UserIDs NVARCHAR(MAX);
DECLARE @CountUserToDelete INT;
DECLARE @CountUserInKiSS INT;

-------------------------------------------------------------------------------
-- SRK-Benutzer löschen
-------------------------------------------------------------------------------
;WITH cte (XUserID) AS
(
  SELECT 22 UNION ALL
  SELECT 50 UNION ALL
  SELECT 6 UNION ALL
  SELECT 17 UNION ALL
  SELECT 18 UNION ALL
  SELECT 80 UNION ALL
  SELECT 19 UNION ALL
  SELECT 26 UNION ALL
  SELECT 49 UNION ALL
  SELECT 75 UNION ALL
  SELECT 55 UNION ALL
  SELECT 3 UNION ALL
  SELECT 56 UNION ALL
  SELECT 66 UNION ALL
  SELECT 67 UNION ALL
  SELECT 68 UNION ALL
  SELECT 70 UNION ALL
  SELECT 25 UNION ALL
  SELECT 21 UNION ALL
  SELECT 23 UNION ALL
  SELECT 48 UNION ALL
  SELECT 24 UNION ALL
  SELECT 4 UNION ALL
  SELECT 20 UNION ALL
  SELECT 27 
)

SELECT @UserIDs = STUFF((SELECT DISTINCT
                           ',' + CONVERT(VARCHAR, USR.UserID)
                         FROM cte
                           INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = CTE.XUserID
                         ORDER BY ',' + CONVERT(VARCHAR, USR.UserID)
                         FOR XML PATH('')),
                         1, 
                         1, 
                         ''),
       @CountUserToDelete = (SELECT COUNT(DISTINCT XUserID)
                               FROM Cte),
       @CountUserInKiSS = (SELECT COUNT(DISTINCT USR.UserID)
                             FROM Cte
                               INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = CTE.XUserID);

SELECT UserIDs           = @UserIDs, 
       CountUserToDelete = @CountUserToDelete,
       CountUserInKiSS   = @CountUserInKiSS;
  
PRINT ('Info: Anzahl zu löschende Benutzer: ' + CONVERT(VARCHAR(MAX), @CountUserToDelete));
PRINT ('Info: Anzahl Benutzer die im KiSS vorhanden sind: ' + CONVERT(VARCHAR(MAX), @CountUserInKiSS));


-------------------------------------------------------------------------------
-- Dummy-Benutzer einfügen
-------------------------------------------------------------------------------
DECLARE @Dummy_LastName VARCHAR(100);
DECLARE @Dummy_LogonName VARCHAR(100);
DECLARE @Dummy_XUserID INT;

SET @Dummy_LastName = 'Dummy SRK';
SET @Dummy_LogonName = 'usersrk_old';

IF (NOT EXISTS(SELECT TOP 1 1
               FROM dbo.XUser WITH (READUNCOMMITTED)
               WHERE LastName = @Dummy_LastName
                 AND LogonName = @Dummy_LogonName))
BEGIN
  INSERT INTO dbo.HistoryVersion(AppUser)
    VALUES ('Datenbereinigung');
  INSERT INTO dbo.XUser (LastName, LogonName, IsLocked, Creator, Modifier)
    VALUES (@Dummy_LastName, @Dummy_LogonName, 1, 'Datenbereinigung', 'Datenbereinigung');
  PRINT ('Info: User "' + @Dummy_LastName + ' (' + @Dummy_LogonName + ') " mit ID ' + CONVERT(VARCHAR(MAX), SCOPE_IDENTITY()) + ' wurde erstellt');
END
ELSE
BEGIN
  PRINT ('Info: User "' + @Dummy_LastName + ' (' + @Dummy_LogonName + ') " ist bereits im KiSS vorhanden');
END;

SELECT @Dummy_XUserID = UserID
FROM dbo.XUser WITH (READUNCOMMITTED)
WHERE LastName = @Dummy_LastName
  AND LogonName = @Dummy_LogonName;

PRINT ('Info: Dummy_XUserID: ' + CONVERT(VARCHAR(MAX), @Dummy_XUserID));

-------------------------------------------------------------------------------
-- Löschen
-------------------------------------------------------------------------------
DECLARE @ExecSql NVARCHAR(MAX);
-- FaLeistung löschen
-- wurde mittels "EXEC dbo.spXGetDeleteStatements 'XUser', '<0>', 0, '<1>';" erstellt
-- Reihenfolge wegen Contraint-Fehler wurde manuell angepasst
PRINT ('Info: XUser löschen');
SET @ExecSql = N'
INSERT INTO dbo.HistoryVersion (AppUser) VALUES (''kiss_sys'');
UPDATE T SET UserID = <1> FROM BaAdresse T WHERE UserID IN (<0>)
UPDATE T SET UserID = <1> FROM BFSDossier T WHERE UserID IN (<0>)
UPDATE T SET UserID = <1> FROM BgBewilligung T WHERE UserID IN (<0>)
UPDATE T SET UserID_An = <1> FROM BgBewilligung T WHERE UserID_An IN (<0>)
UPDATE T SET UserID_Zustaendig = <1> FROM BgBewilligung T WHERE UserID_Zustaendig IN (<0>)
UPDATE T SET ErstelltUserID = <1> FROM BgPosition T WHERE ErstelltUserID IN (<0>)
UPDATE T SET MutiertUserID = <1> FROM BgPosition T WHERE MutiertUserID IN (<0>)
UPDATE T SET UserID = <1> FROM FaAktennotizen T WHERE UserID IN (<0>)
UPDATE T SET UserID = <1> FROM FaDokumentAblage T WHERE UserID IN (<0>)
UPDATE T SET UserID_Absender = <1> FROM FaDokumente T WHERE UserID_Absender IN (<0>)
UPDATE T SET UserID_EkVisumUser = <1> FROM FaDokumente T WHERE UserID_EkVisumUser IN (<0>)
UPDATE T SET UserID_VisiertDurch = <1> FROM FaDokumente T WHERE UserID_VisiertDurch IN (<0>)
UPDATE T SET UserID_VisumBeantragtBei = <1> FROM FaDokumente T WHERE UserID_VisumBeantragtBei IN (<0>)
UPDATE T SET UserID_VisumBeantragtDurch = <1> FROM FaDokumente T WHERE UserID_VisumBeantragtDurch IN (<0>)
UPDATE T SET SachbearbeiterID = <1> FROM FaLeistung T WHERE SachbearbeiterID IN (<0>)
UPDATE T SET UserID = <1> FROM FaLeistung T WHERE UserID IN (<0>)
UPDATE T SET CheckInUserID = <1> FROM FaLeistungArchiv T WHERE CheckInUserID IN (<0>)
UPDATE T SET CheckOutUserID = <1> FROM FaLeistungArchiv T WHERE CheckOutUserID IN (<0>)
UPDATE T SET UserID = <1> FROM FaLeistungBewertung T WHERE UserID IN (<0>)
UPDATE T SET UserID = <1> FROM FaLeistungUserHist T WHERE UserID IN (<0>)
UPDATE T SET UserID = <1> FROM FaLeistungZugriff T WHERE UserID IN (<0>)
UPDATE T SET UserID = <1> FROM FaPendenzgruppe_User T WHERE UserID IN (<0>)
UPDATE T SET UserID = <1> FROM FaPhase T WHERE UserID IN (<0>)
UPDATE T SET UserID_Creator = <1> FROM FaWeisung T WHERE UserID_Creator IN (<0>)
UPDATE T SET UserID_VerantwortlichRD = <1> FROM FaWeisung T WHERE UserID_VerantwortlichRD IN (<0>)
UPDATE T SET UserID_VerantwortlichSAR = <1> FROM FaWeisung T WHERE UserID_VerantwortlichSAR IN (<0>)
UPDATE T SET UserID = <1> FROM IkAbklaerung T WHERE UserID IN (<0>)
UPDATE T SET BarbelegUserID = <1> FROM KbBuchung T WHERE BarbelegUserID IN (<0>)
UPDATE T SET ErstelltUserID = <1> FROM KbBuchung T WHERE ErstelltUserID IN (<0>)
UPDATE T SET MutiertUserID = <1> FROM KbBuchung T WHERE MutiertUserID IN (<0>)
UPDATE T SET UserID = <1> FROM KbWVLauf T WHERE UserID IN (<0>)
UPDATE T SET ErstelltUserID = <1> FROM KbZahlungseingang T WHERE ErstelltUserID IN (<0>)
UPDATE T SET MutiertUserID = <1> FROM KbZahlungseingang T WHERE MutiertUserID IN (<0>)
UPDATE T SET ZugeteiltUserID = <1> FROM KbZahlungseingang T WHERE ZugeteiltUserID IN (<0>)
UPDATE T SET UserID = <1> FROM KbZahlungslauf T WHERE UserID IN (<0>)
UPDATE T SET CheckOut_UserID = <1> FROM XDocTemplate T WHERE CheckOut_UserID IN (<0>)
UPDATE T SET ChiefID = <1> FROM XOrgUnit T WHERE ChiefID IN (<0>)
UPDATE T SET RechtsdienstUserID = <1> FROM XOrgUnit T WHERE RechtsdienstUserID IN (<0>)
UPDATE T SET RepresentativeID = <1> FROM XOrgUnit T WHERE RepresentativeID IN (<0>)
UPDATE T SET UserID = <1> FROM XOrgUnit_User T WHERE UserID IN (<0>)
UPDATE T SET UserID = <1> FROM XSearchControlTemplate T WHERE UserID IN (<0>)
UPDATE T SET UserID_Erledigt = <1> FROM XTask T WHERE UserID_Erledigt IN (<0>)
UPDATE T SET UserID_InBearbeitung = <1> FROM XTask T WHERE UserID_InBearbeitung IN (<0>)
UPDATE T SET ChiefID = <1> FROM XUser T WHERE ChiefID IN (<0>)
UPDATE T SET PrimaryUserID = <1> FROM XUser T WHERE PrimaryUserID IN (<0>)
UPDATE T SET SachbearbeiterID = <1> FROM XUser T WHERE SachbearbeiterID IN (<0>)
UPDATE T SET UserID = <1> FROM XUser_XDocTemplate T WHERE UserID IN (<0>)
UPDATE T SET UserID = <1> FROM XUserStundenansatz T WHERE UserID IN (<0>)
DELETE T FROM KbPeriode_User T WHERE UserID IN (<0>)
DELETE T FROM XUser_Archive T WHERE UserID IN (<0>)
DELETE T FROM XUser_UserGroup T WHERE UserID IN (<0>)
DELETE T FROM XUser T WHERE UserID IN (<0>)
PRINT (''Info: '' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + '' Benutzer wurden gelöscht.'');
';
SET @ExecSql = REPLACE(@ExecSql , '<0>', CONVERT(NVARCHAR(MAX), @UserIDs))
SET @ExecSql = REPLACE(@ExecSql , '<1>', CONVERT(NVARCHAR(MAX), @Dummy_XUserID))
EXEC dbo.sp_executesql @ExecSql;

-- prüfen ob alle Benutzer gelöscht wurden
SET @ExecSql = N'
  SELECT NotDeletedUser = ''nicht gelöschte Benutzer'', *
  FROM dbo.XUser
  WHERE UserID IN (<0>);

  PRINT (''Info: '' + CONVERT(VARCHAR(MAX), @@ROWCOUNT) + '' Benutzer konnten nicht gelöscht werden.'');
';
SET @ExecSql = REPLACE(@ExecSql , '<0>', CONVERT(NVARCHAR(MAX), @UserIDs))
EXEC dbo.sp_executesql @ExecSql;
GO

SET NOCOUNT OFF
GO
