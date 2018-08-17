/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to create new users for each member of GF SOZ.
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 3 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

{Include:Rxxxx_Use_Database}

-------------------------------------------------------------------------------
-- init vars and table
-------------------------------------------------------------------------------
DECLARE @EntriesCount INT,
        @EntriesIterator INT;

DECLARE @FirstName VARCHAR(200),
        @LastName VARCHAR(200),
        @ShortName VARCHAR(10),
        @EMail VARCHAR(100),
        @LogonName VARCHAR(200),
        @UserID INT;

DECLARE @PasswordHash VARCHAR(200),
        @PermissionGroupID INT,
        @OrgUnitID INT,
        @UserGroupID INT,
        @UserGroupName VARCHAR(100),
        @CreatorModifier VARCHAR(50);

DECLARE @TempTable TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  FirstName VARCHAR(200),
  LastName VARCHAR(200),
  ShortName VARCHAR(10),
  EMail VARCHAR(100),
  LogonName VARCHAR(200),
  IsTeamleiter BIT,
  IsStellvertreter BIT
);

-------------------------------------------------------------------------------
-- insert entries into temp table
-------------------------------------------------------------------------------
INSERT INTO @TempTable (LastName, FirstName, ShortName, LogonName, EMail, IsTeamleiter, IsStellvertreter)
          SELECT 'Abegglen', 'Thomas', 'TAB', 'rcxp', 'thomas.abegglen@diartis.ch', 0, 0
UNION ALL SELECT 'Fuchs', 'Andreas', 'ANF', 'rcxo', 'andreas.fuchs@diartis.ch', 0, 0
UNION ALL SELECT 'Loreggia', 'Lucas', 'LUL', 'rcxs', 'lucas.loreggia@diartis.ch', 0, 0
UNION ALL SELECT 'Marino', 'Rahel', 'RAH', 'rcxj', 'rahel.marino@diartis.ch', 1, 0
UNION ALL SELECT 'Mathys', 'Wolfram', 'WMA', 'e247', 'wolfram.mathys@diartis.ch', 0, 1
UNION ALL SELECT 'Minder', 'Mathias', 'MMI', 'rcxr', 'mathias.minder@diartis.ch', 0, 0
UNION ALL SELECT 'Salajan', 'Peter', 'PSL', 'rbly', 'peter.salajan@diartis.ch', 0, 0
UNION ALL SELECT 'Stucki', 'Conny', 'COS', 'rb63', 'conny.stucki@diartis.ch', 0, 0
UNION ALL SELECT 'Weber', 'Nicolas', 'NWE', 'rcxv', 'nicolas.weber@diartis.ch', 0, 0
--UNION ALL SELECT '<LastName>', '<FirstName>', 'Shortname', '<LogonName>', '<Email>', <IsTeamleiter>, <IsStellvertreter>

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- determine common values: password, permissiongroupid, orgunit, ...
-------------------------------------------------------------------------------
SELECT @PasswordHash = '4P/dakfPi6MQqGVn7Tdelw==',
       @UserGroupName = 'KiSS kann alles',
       @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()); 

--Die Gruppe mit der höchsten Zus.Leistungs-Kompetenz ermitteln
SELECT TOP 1 @PermissionGroupID = PMV.PermissionGroupID
FROM dbo.XPermissionValue PMV WITH (READUNCOMMITTED)
WHERE PMV.BgPositionsartID IS NOT NULL
GROUP BY permissiongroupid
ORDER BY SUM(CONVERT(DECIMAL, value)) DESC

-------------------------------------------------------------------------------
-- Die oberste Abteilung (ParentID IS NULL) ermitteln
-------------------------------------------------------------------------------
SELECT @OrgUnitID = ORG.OrgUnitID
FROM dbo.XOrgUnit ORG
WHERE ORG.ParentID IS NULL;

-------------------------------------------------------------------------------
-- Benutzergruppe ermitteln oder ggf. erstellen
-------------------------------------------------------------------------------
SELECT @UserGroupID = UserGroupID FROM dbo.XUserGroup WHERE UserGroupName = @UserGroupName;

IF(@UserGroupID IS NULL)
BEGIN
    INSERT INTO [dbo].[XUserGroup]([UserGroupName],[OnlyAdminVisible],[Description],[Creator],[Created],[Modifier],[Modified])
    VALUES(@UserGroupName, 0 /*OnlyAdminVisible*/, 'Enthält alle Masken- und Spezialrechte', @CreatorModifier, GETDATE(), @CreatorModifier, GETDATE());

    SET @UserGroupID = SCOPE_IDENTITY();
END;

-------------------------------------------------------------------------------
-- Sicherstellen dass alle Rechte darin enthalten sind
-------------------------------------------------------------------------------
INSERT INTO XUserGroup_Right (UserGroupID, RightID, XClassID, ClassName, QueryName, MaskName, MayInsert, MayUpdate, MayDelete)
SELECT TMP.UserGroupID, TMP.RightID, TMP.XClassID, TMP.ClassName, TMP.QueryName, TMP.MaskName, TMP.MayInsert, TMP.MayUpdate, TMP.MayDelete
FROM (--XRight
      SELECT UserGroupID = @UserGroupID,
             RightID = RGT.RightID,
             XClassID = RGT.XClassID,
             ClassName = RGT.ClassName,
             QueryName = NULL,
             MaskName = NULL,
             MayInsert = 1,
             MayUpdate = 1,
             MayDelete = 1
      FROM XRight RGT
      UNION ALL
      --XClass
      SELECT UserGroupID = @UserGroupID,
             RightID = NULL,
             XClassID = CLS.XClassID,
             ClassName = CLS.ClassName,
             QueryName = NULL,
             MaskName = NULL,
             MayInsert = 1,
             MayUpdate = 1,
             MayDelete = 1
      FROM XClass CLS
      UNION ALL
      --XQuery
      SELECT UserGroupID = @UserGroupID,
             RightID = NULL,
             XClassID = NULL,
             ClassName = NULL,
             QueryName = QRY.QueryName,
             MaskName = NULL,
             MayInsert = 1,
             MayUpdate = 1,
             MayDelete = 1
      FROM XQuery QRY
      WHERE QRY.ParentReportName IS NULL
      UNION ALL
      --DynaMask
      SELECT UserGroupID = @UserGroupID,
             RightID = NULL,
             XClassID = NULL,
             ClassName = NULL,
             QueryName = NULL,
             MaskName = MSK.MaskName,
             MayInsert = 1,
             MayUpdate = 1,
             MayDelete = 1
      FROM DynaMask MSK
) TMP
WHERE NOT EXISTS (SELECT TOP 1 1 
                  FROM XUserGroup_Right UGR
                  WHERE UGR.UserGroupID = TMP.UserGroupID
                    AND ISNULL(UGR.RightID, -1) = ISNULL(TMP.RightID, -1)
                    AND ISNULL(UGR.XClassID, -1) = ISNULL(TMP.XClassID, -1)
                    AND ISNULL(UGR.QueryName, '') = ISNULL(TMP.QueryName, '')
                    AND ISNULL(UGR.MaskName, -1) = ISNULL(TMP.MaskName, -1))

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT  @FirstName = TMP.FirstName, 
          @LastName  = TMP.LastName, 
          @ShortName = TMP.ShortName, 
          @LogonName = TMP.LogonName, 
          @EMail     = TMP.Email
  FROM @TempTable TMP
  WHERE TMP.ID = @EntriesIterator;
  
  -----------------------------------------------------------------------------
  -- Create user if it doesn't exist yet
  -----------------------------------------------------------------------------
  IF(NOT EXISTS(SELECT TOP 1 1 FROM dbo.XUser WHERE LogonName = @LogonName))
  BEGIN
    INSERT INTO dbo.HistoryVersion(AppUser)
    VALUES  (@CreatorModifier);
    
    INSERT INTO [dbo].[XUser]([FirstName],[LastName],[ShortName],[EMail],[LogonName],[PasswordHash],[IsUserAdmin],[PermissionGroupID],[GrantPermGroupID],[Creator],[Created],[Modifier],[Modified])
    VALUES(@FirstName, @LastName, @ShortName, @EMail, @LogonName, @PasswordHash, 0 /*IsUserAdmin*/, @PermissionGroupID, @PermissionGroupID, @CreatorModifier, GETDATE(), @CreatorModifier, GETDATE());

    SET @UserID = SCOPE_IDENTITY();

    --Benutzer zu Abteilung hinzufügen
    INSERT INTO [dbo].[XOrgUnit_User]([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete])
    VALUES  (@OrgUnitID, 
             @UserID, 
             2 /*2: Mitglied */,
             1, /* MayInsert */
             1, /* MayUpdate */
             1 /* MayDelete */
             )

    --Benutzer zu Benutzergruppe hinzufügen
    INSERT INTO [dbo].[XUser_UserGroup]([UserID], [UserGroupID])
    VALUES  (@UserID, 
             @UserGroupID
             )

    PRINT('XUser mit LogonName: ' + @LogonName + ' erstellt.');
  END
  ELSE
  BEGIN
    PRINT('XUser mit LogonName: ' + @LogonName + ' existiert bereits.');
  END
  -----------------------------------------------------------------------------

  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

INSERT INTO dbo.HistoryVersion(AppUser)
VALUES  (@CreatorModifier);

--Sicherstellen, dass Abteilung nicht von einem inaktiven Benutzer geleitet wird
UPDATE ORG SET ORG.ChiefID = USR.UserID
FROM XOrgUnit ORG
  INNER JOIN XOrgUnit_User OUU ON OUU.OrgUnitID = ORG.OrgUnitID
  INNER JOIN XUser USR ON USR.UserID = OUU.UserID
  INNER JOIN @TempTable TMP ON TMP.LogonName = USR.LogonName
WHERE ORG.OrgUnitID = @OrgUnitID
  AND TMP.IsTeamleiter = 1;

--Sicherstellen, dass Abteilung nicht einen inaktiven Stellvertreter hat
UPDATE ORG SET ORG.RepresentativeID = USR.UserID
FROM XOrgUnit ORG
  INNER JOIN XOrgUnit_User OUU ON OUU.OrgUnitID = ORG.OrgUnitID
  INNER JOIN XUser USR ON USR.UserID = OUU.UserID
  INNER JOIN @TempTable TMP ON TMP.LogonName = USR.LogonName
WHERE ORG.OrgUnitID = @OrgUnitID
  AND TMP.IsStellvertreter = 1;

--Sicherstellen, dass Benutzer diag_admin Mitglied in gleicher Abteilung ist
--a) Bisherige Mitgliedschaft + allfällige Gastmitgliedschaft in Abteilung löschen
DELETE OUU 
FROM XOrgUnit_User OUU 
  INNER JOIN XUser USR ON USR.UserID = OUU.UserID
WHERE USR.LogonName = 'diag_admin'
  AND (OUU.OrgUnitMemberCode = 2 --2: Mitglied
       OR OUU.OrgUnitID = @OrgUnitID);

INSERT INTO [dbo].[XOrgUnit_User](OrgUnitID, UserID, OrgUnitMemberCode, MayInsert, MayUpdate, MayDelete)
SELECT @OrgUnitID, USR.UserID, 2 /*OrgUnitMemberCode*/, 1 /*MayInsert*/, 1 /*MayUpdate*/, 1 /*MayDelete*/
FROM XUser USR
WHERE USR.LogonName = 'diag_admin';

SET NOCOUNT OFF;
GO
