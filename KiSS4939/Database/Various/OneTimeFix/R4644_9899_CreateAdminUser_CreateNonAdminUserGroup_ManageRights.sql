/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to create a new Usergroup, migrate all user into that group,
  update rights and to create a new user with administrator rights
=================================================================================================*/

-------------------------------------------------------------------------------------------------
-- info
-------------------------------------------------------------------------------------------------
PRINT ('---- Script version: $Revision: 1 $ ----');
PRINT ('Info: Using database "' + DB_NAME() + '"');
GO

BEGIN TRAN

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
          SELECT 'Administrator', 'Administrator', 'ADM', 'administrator', 'martin.tschumi@worb.ch', 0, 0

--UNION ALL SELECT '<LastName>', '<FirstName>', 'Shortname', '<LogonName>', '<Email>', <IsTeamleiter>, <IsStellvertreter>

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

-------------------------------------------------------------------------------
-- determine common values: password, permissiongroupid, orgunit, ...
-------------------------------------------------------------------------------
SELECT @PasswordHash = '4P/dakfPi6MQqGVn7Tdelw==', --Ki$$2013
       @UserGroupName = 'Admin-Gruppe',
       @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()); 
       
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
    VALUES(@UserGroupName, 0 /*OnlyAdminVisible*/, 'Mitarbeiter mit Admin-Rechten', @CreatorModifier, GETDATE(), @CreatorModifier, GETDATE());

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
                    AND ISNULL(UGR.QueryName, '') = ISNULL(TMP.QueryName, -1)
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
    VALUES(@FirstName, @LastName, @ShortName, @EMail, @LogonName, @PasswordHash, 1 /*IsUserAdmin*/, NULL, NULL, @CreatorModifier, GETDATE(), @CreatorModifier, GETDATE());

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


-----------------------------------------------------------------------------
--2. Benutzergruppe erstellen
-----------------------------------------------------------------------------
SET @UserGroupName = 'Mitarbeiter ohne Admin-Rechte';
DECLARE @UserGroupID_NonAdmin INT;

-------------------------------------------------------------------------------
-- Benutzergruppe ermitteln oder ggf. erstellen
-------------------------------------------------------------------------------
SELECT @UserGroupID_NonAdmin = UserGroupID FROM dbo.XUserGroup WHERE UserGroupName = @UserGroupName;

IF(@UserGroupID_NonAdmin IS NULL)
BEGIN
    INSERT INTO [dbo].[XUserGroup]([UserGroupName],[OnlyAdminVisible],[Description],[Creator],[Created],[Modifier],[Modified])
    VALUES(@UserGroupName, 0 /*OnlyAdminVisible*/, 'Mitarbeiter ohne Admin-Rechte', @CreatorModifier, GETDATE(), @CreatorModifier, GETDATE());

    SET @UserGroupID_NonAdmin = SCOPE_IDENTITY();
END;

-- Rechte löschen
DELETE FROM XUserGroup_Right 
WHERE UserGroupID = @UserGroupID_NonAdmin

INSERT INTO dbo.XUserGroup_Right
        (UserGroupID,
         RightID,
         XClassID,
         ClassName,
         QueryName,
         MaskName,
         MayInsert,
         MayUpdate,
         MayDelete)
SELECT  @UserGroupID_NonAdmin, 
         GRR.RightID ,
         GRR.XClassID ,
         GRR.ClassName ,
         GRR.QueryName ,
         GRR.MaskName ,
         GRR.MayInsert ,
         GRR.MayUpdate ,
         GRR.MayDelete 
FROM dbo.XUserGroup_Right GRR
WHERE UserGroupID = @UserGroupID
  AND (ClassName IS NULL OR ClassName NOT IN (
                          'CtlAdBgKostenartWhGefKategorie',
                          'CtlAdInstitutionsTypen',
                          'CtlBgColors',
                          'CtlBgPositionsart',
                          'CtlFallZugriff',
                          'CtlHyperlink',
                          'CtlHyperlinkContext',
                          'CtlIkLandesindex',
                          'CtlKbZahlungslaufValuta',
                          'CtlKostenart',
                          'CtlMessage',
                          'CtlOrgUnit',
                          'CtlPendenzBenutzerGruppen',
                          'CtlPendenzVorlagentexte',
                          'CtlPermissionGroup',
                          'CtlReportDefinition',
                          'CtlStdZahlungsmodi',
                          'CtlUser',
                          'CtlUserGroup',
                          'FrmConfig',
                          'FrmDataEditor',
                          'FrmDesigner',
                          'FrmDynaMask',
                          'FrmLinkManagement',
                          'FrmModulConfig',
                          'FrmMultilanguage',
                          'FrmPendenzenAdmin',
                          'FrmQueryManagement',
                          'FrmUserManagement',
                          'Kiss.UI.View.Ba.BaGemeindeView.xaml',
                          'Kiss.UI.View.Ba.BaLandView.xaml',
                          'Kiss.UI.View.Ba.BaPlzView.xaml',
                          'CtlFallZugriff',
                          'CtlOrgUnit',
                          'CtlPermissionGroup',
                          'CtlUser',
                          'CtlUserGroup',
                          'FrmConfig',
                          'FrmDataEditor',
                          'FrmDynaMask',
                          'FrmQueryManagement',
                          'FrmUserManagement',
                          'FrmDesigner'
                                          )
        )
        

-----------------------------------------------------------------------------
--Alle bisherigen Benutzer in neue Benutzergruppe verschieben
-----------------------------------------------------------------------------
INSERT INTO dbo.XUser_UserGroup (UserID, UserGroupID)
SELECT UserID, @UserGroupID_NonAdmin
FROM XUser
WHERE UserID <> @UserID --Admin nicht mitkopieren

DELETE FROM dbo.XUser_UserGroup
WHERE UserGroupID NOT IN (@UserGroupID_NonAdmin, @UserGroupID)

-----------------------------------------------------------------------------
-- Alle bisherigen dbo.XUserGroup_Right-Rechte löschen
-----------------------------------------------------------------------------
DELETE 
FROM dbo.XUserGroup_Right
WHERE UserGroupID NOT IN (@UserGroupID, @UserGroupID_NonAdmin)

-----------------------------------------------------------------------------
-- Alle bisherigen Benutzergruppen löschen
-----------------------------------------------------------------------------
DELETE 
FROM dbo.XUserGroup
WHERE UserGroupID NOT IN (@UserGroupID, @UserGroupID_NonAdmin)

--ADMIN entfernen
UPDATE XUser
SET IsUserAdmin = 0
WHERE UserID <> @UserID
AND IsUserBIAGAdmin = 0

SET NOCOUNT OFF;
GO


--Commit