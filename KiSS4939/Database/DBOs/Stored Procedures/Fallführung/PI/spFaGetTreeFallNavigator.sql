SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spFaGetTreeFallNavigator;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this sp to get tree for fall-navigator depending on given parameters
    @UserID:        The id of the user who calls the sp
    @FV:            1=show only items with 'FallVerlauf'; 0=show all
    @SB:            1=show only items with 'Sozialberatung'; 0=show all
    @CM:            1=show only items with 'Case Management'; 0=show all
    @BW:            1=show only items with 'Begleitetes Wohnen'; 0=show all
    @ED:            1=show only items with 'Entlastungsdienst'; 0=show all
    @IN:            1=show only items with 'Intake'; 0=show all
    @AB:            1=show only items with 'Assistenzberatung'; 0=show all
    @WD:            1=show only items with 'Weitere Dienstleistungen'; 0=show all
    @Closed:        1=show also closed items; 0=show only open items
    @IncludeGroup:  1=show group the user is member of; 0=hide group
    @IncludeGuest:  1=show also guest-rights; 0=hide guest rights
  -
  RETURNS: One column-resultset with columnname = [Done] where > -1 = ok, < 0 = nok
  -
  TEST:    EXEC dbo.spFaGetTreeFallNavigator 2, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1
           EXEC dbo.spFaGetTreeFallNavigator 2, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1
           EXEC dbo.spFaGetTreeFallNavigator 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1
           EXEC dbo.spFaGetTreeFallNavigator 200, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1
=================================================================================================*/

CREATE PROCEDURE dbo.spFaGetTreeFallNavigator
(
  @UserID       INT = -1,
  @FV           BIT = 1,
  @SB           BIT = 1,
  @CM           BIT = 0,
  @BW           BIT = 0,
  @ED           BIT = 0,
  @IN           BIT = 0,
  @AB           BIT = 0,
  @WD           BIT = 0,
  @Closed       BIT = 0,
  @IncludeGroup BIT = 0,
  @IncludeGuest BIT = 0
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- do not count rows
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -- logging
  PRINT ('start call: ' + CONVERT(VARCHAR, GETDATE(), 113));
  
  -------------------------------------------------------------------------------
  -- init temporary tables
  -------------------------------------------------------------------------------
  -- store users who are within tree
  DECLARE @Users TABLE 
  (
     UserID INT NOT NULL PRIMARY KEY
  )
  
  -- store persons who are within tree (due to performance, use #table)
  CREATE TABLE #Persons
  (
    ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
    BaPersonID INT, 
    UserID INT,
    GuestOnOrgUnit BIT NOT NULL DEFAULT (0),
    GuestOnLeistung BIT NOT NULL DEFAULT (0)
  )
  
  -- store final tree output (due to performance, use #table)
  CREATE TABLE #tmpTree
  (
    [ID] VARCHAR(20) NOT NULL PRIMARY KEY,
    [ParentID] VARCHAR(20),
    [Type] VARCHAR(6),
    [Name] VARCHAR(100),
    [BaPersonID] INT,
    [UserID] INT,
    [OrgUnitID] INT,
    [P] INT,
    [FV_FaLeistungID] INT,
    [FV] INT,
    [SB_FaLeistungID] INT,
    [SB] INT,
    [CM_FaLeistungID] INT,
    [CM] INT,
    [BW_FaLeistungID] INT,
    [BW] INT,
    [ED_FaLeistungID] INT,
    [ED] INT,
    [IN_FaLeistungID] INT,
    [IN] INT,
    [AB_FaLeistungID] INT,
    [AB] INT,
    [WD_FaLeistungID] INT,
    [WD] INT,
    [Wohnort] VARCHAR(50),
    [PrsAlter] VARCHAR(10),
    [IconID] INT
  )
  
  -------------------------------------------------------------------------------
  -- setup constant values
  -------------------------------------------------------------------------------
  -- iconoffsets for modul-status
  DECLARE @OffDisabled INT  
  DECLARE @OffActive INT
  DECLARE @OffClosed INT
  
  -- icons for owner/guestright
  DECLARE @IconIDOwnerLeistung INT
  DECLARE @IconIDGuestOrgUnit INT
  DECLARE @IconIDGuestLeistung INT
  
  -- set values
  SET @OffDisabled = 0
  SET @OffActive = 1
  SET @OffClosed = 2
  
  SET @IconIDOwnerLeistung = 102
  SET @IconIDGuestOrgUnit = 103
  SET @IconIDGuestLeistung = 104
  
  -- logging
  PRINT ('done init: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- User
  -------------------------------------------------------------------------------
  -- add current user to table
  INSERT INTO @Users 
  VALUES (@UserID)
  
  -- add additional users (OrgUnit, guest rights)
  IF (@IncludeGroup = 1 OR @IncludeGuest = 1) 
  BEGIN
    INSERT INTO @Users
      SELECT DISTINCT 
             UserID = OUB.UserID
      FROM dbo.XOrgUnit_User OUA WITH (READUNCOMMITTED)
        INNER JOIN dbo.XOrgUnit_User OUB WITH (READUNCOMMITTED) ON OUB.OrgUnitID = OUA.OrgUnitID AND
                                                                   OUB.UserID <> @UserID AND
                                                                   OUB.OrgUnitMemberCode = 2
      WHERE OUA.UserID = @UserID AND
            ((@IncludeGroup = 1 AND OUA.OrgUnitMemberCode IN (1, 2)) OR
             (@IncludeGuest = 1 AND OUA.OrgUnitMemberCode IN (3)))
  END
  
  -- logging
  PRINT ('added user(s) to @User: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- entries from BaPerson/FaLeistung
  -------------------------------------------------------------------------------
  -- add all connected persons (filtered with @Closed) (zeige auch Personen, welche auf User abgeschlossen sind und auf anderer User offene Leistungen haben)
  INSERT INTO #Persons
    SELECT DISTINCT 
           BaPersonID      = LEI.BaPersonID, 
           UserID          = LEI.UserID,
           GuestOnOrgUnit  = CASE WHEN LEI.UserID = @UserID THEN 0      -- owner of FaLeistungID
                                  ELSE 1                                -- guest on XOrgUnit
                             END,
           GuestOnLeistung = 0
    FROM dbo.FaLeistung LEI WITH(READUNCOMMITTED)
      INNER JOIN @Users USR ON USR.UserID = LEI.UserID
    WHERE (LEI.DatumBis IS NULL) OR
          (@Closed = 1 AND LEI.DatumBis IS NOT NULL) OR
          (@Closed = 0 AND LEI.BaPersonID IN (SELECT TOP 1 SUB.BaPersonID 
                                              FROM dbo.FaLeistung SUB WITH (READUNCOMMITTED)
                                              WHERE SUB.BaPersonID = LEI.BaPersonID AND
                                                    SUB.DatumBis IS NULL))
  
  -- logging
  PRINT ('added persons to #Person: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -- create indexes for better performance
  CREATE INDEX IX_Persons_BaPersonID on #Persons (BaPersonID)
  CREATE INDEX IX_Persons_UserID on #Persons (UserID)
  CREATE INDEX IX_Persons_BaPersonIDUserID on #Persons (BaPersonID, UserID)
  CREATE INDEX IX_Persons_BaPersonIDUserIDGuest on #Persons (BaPersonID, UserID, GuestOnOrgUnit, GuestOnLeistung)
  
  -- logging
  PRINT ('created indexes on #Person: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -- add all persons where user has guest rights (filtered with @Closed), depending on flag @IncludeGuest
  IF (@IncludeGuest = 1)
  BEGIN
    -- do include guest rights
    INSERT INTO #Persons
      -- insert to real assigned user (same statement as above)
      SELECT DISTINCT 
             BaPersonID      = LEI.BaPersonID, 
             UserID          = LEI.UserID, 
             GuestOnOrgUnit  = 0,
             GuestOnLeistung = 1                                      -- guest on FaLeistungID
      FROM dbo.FaLeistungZugriff LEZ WITH (READUNCOMMITTED)
        INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = LEZ.FaLeistungID
      WHERE LEZ.UserID = @UserID AND
            NOT EXISTS (SELECT TOP 1 1                                -- not yet existing for same BaPersonID and UserID
                        FROM #Persons PRS
                        WHERE PRS.BaPersonID = LEI.BaPersonID AND 
                              PRS.UserID = LEI.UserID) AND
            ((LEI.DatumBis IS NULL) OR
             (@Closed = 1 AND LEI.DatumBis IS NOT NULL))
    
    -- if a user has guestright on Leistung, insert entry to current user, too
    INSERT INTO #Persons
      SELECT DISTINCT
             BaPersonID      = PRS.BaPersonID,
             UserID          = @UserID,                               -- apply to current user
             GuestOnOrgUnit  = PRS.GuestOnOrgUnit,
             GuestOnLeistung = PRS.GuestOnLeistung
      FROM #Persons PRS
      WHERE PRS.GuestOnLeistung = 1 AND                               -- those we just inserted above
            NOT EXISTS (SELECT TOP 1 1                                -- not yet existing for same BaPersonID and UserID
                        FROM #Persons SUB
                        WHERE SUB.BaPersonID = PRS.BaPersonID AND 
                              SUB.UserID = @UserID)
    
    -- if a user has guestright on Leistung, insert entry to current user 
    --   where item e.g. was added to owner-user with GuestOnLeistung=0 above
    --   >> add it here to current user, otherwise it would be available only at owner-user node
    INSERT INTO #Persons
      SELECT DISTINCT
             BaPersonID      = LEI.BaPersonID,
             UserID          = @UserID,                               -- apply to current user
             GuestOnOrgUnit  = 0,
             GuestOnLeistung = 1                                      -- guest on FaLeistungID
      FROM dbo.FaLeistungZugriff LEZ WITH (READUNCOMMITTED)
        INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = LEZ.FaLeistungID
      WHERE LEZ.UserID = @UserID AND
            NOT EXISTS (SELECT TOP 1 1                                -- not yet existing for same BaPersonID and current @UserID
                        FROM #Persons PRS
                        WHERE PRS.BaPersonID = LEI.BaPersonID AND 
                              PRS.UserID = @UserID) AND
            ((LEI.DatumBis IS NULL) OR
             (@Closed = 1 AND LEI.DatumBis IS NOT NULL))
    
    -- if a user where we have guestright on Leistung does not yet exist in list, we will add it now
    INSERT INTO @Users
      SELECT DISTINCT                   -- only one entry per user
             PRS.UserID
      FROM #Persons PRS
      WHERE PRS.GuestOnLeistung = 1 AND -- those we just inserted above
            PRS.UserID <> @UserID AND   -- those with different userid
            NOT EXISTS (SELECT TOP 1 1  -- those who are not in list yet
                        FROM @Users USR
                        WHERE USR.UserID = PRS.UserID)
    
    -- logging
    PRINT ('added guestrights to tables: ' + CONVERT(VARCHAR, GETDATE(), 113))
  END
  
  -- delete all users without any case (except current @UserID)
  DELETE USR
  FROM @Users USR
  WHERE USR.UserID <> @UserID  AND
        NOT EXISTS (SELECT TOP 1 1 
                    FROM #Persons PRS 
                    WHERE PRS.UserID = USR.UserID)
  
  -- logging
  PRINT ('removed all users without open case: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- add collected persons into temporary table, with case-information
  -------------------------------------------------------------------------------
  INSERT INTO #tmpTree (ID, ParentID, Type, Name, BaPersonID, UserID, OrgUnitID, P, FV_FaLeistungID, SB_FaLeistungID,
                        CM_FaLeistungID, BW_FaLeistungID, ED_FaLeistungID, IN_FaLeistungID, AB_FaLeistungID, WD_FaLeistungID, Wohnort, PrsAlter, IconID)
    SELECT [ID]              = 'P' + CONVERT(VARCHAR, PRS.BaPersonID) + '_' + CONVERT(VARCHAR, PRS.UserID),
           [ParentID]        = 'E' + CONVERT(VARCHAR, PRS.UserID),
           [Type]            = 'P',
           [Name]            = dbo.fnGetLastFirstName(NULL, BAP.Name, BAP.Vorname),
           [BaPersonID]      = PRS.BaPersonID,
           [UserID]          = PRS.UserID,
           [OrgUnitID]       = NULL,
           [P]               = 1101,
           [FV_FaLeistungID] = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 2),
           [SB_FaLeistungID] = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 3),
           [CM_FaLeistungID] = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 4),
           [BW_FaLeistungID] = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 5),
           [ED_FaLeistungID] = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 6),
           [IN_FaLeistungID] = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 7),
           [AB_FaLeistungID] = dbo.fnFaGetLastFaLeistungID(PRS.BaPersonID, 8),
           [WD_FaLeistungID] = dbo.fnFaGetLastFaLeistungID(PRS.BAPersonID, 31),
           [Wohnort]         = ADRW.Ort,
           [PrsAlter]        = dbo.fnGetAge(BAP.Geburtsdatum, ISNULL(BAP.Sterbedatum, GETDATE())),
           [IconID]          = CASE WHEN PRS.GuestOnOrgUnit = 1 THEN @IconIDGuestOrgUnit   -- guest on XOrgUnit
                                    WHEN PRS.GuestOnLeistung = 1 THEN @IconIDGuestLeistung -- guest on FaLeistungID
                                    ELSE @IconIDOwnerLeistung                              -- owner of FaLeistungID
                               END
    FROM #Persons PRS
      INNER JOIN dbo.BaPerson  BAP  WITH (READUNCOMMITTED) ON BAP.BaPersonID = PRS.BaPersonID
      LEFT  JOIN dbo.BaAdresse ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL);
  
  -- logging
  PRINT ('added collected persons to #tmpTree: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -- create indexes for better performance
  CREATE INDEX IX_TmpTree_ParentID on #tmpTree (ParentID)
  CREATE INDEX IX_TmpTree_IDParentID on #tmpTree (ID, ParentID)
  CREATE INDEX IX_TmpTree_TypeBaPersonID on #tmpTree (Type, BaPersonID)
  CREATE INDEX IX_TmpTree_TypeID on #tmpTree (Type, ID)
  CREATE INDEX IX_TmpTree_TypeParentID on #tmpTree (Type, ParentID)
  CREATE INDEX IX_TmpTree_TypeIconIDBaPersonIDUserID on #tmpTree (Type, IconID, BaPersonID, UserID)
  
  -- logging
  PRINT ('created indexes on #tmpTree: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- filter only open items where current user is responsible (only @Closed = 0)
  -------------------------------------------------------------------------------
  IF (@Closed = 0)
  BEGIN
    -- remove person if not any open FaLeistung exists for current person, user and module (FV,SB,CM,BW,ED,IN,AB)
    DELETE TRE
    FROM #tmpTree TRE
    WHERE TRE.Type = 'P' AND  -- remove only any persons
          TRE.IconID NOT IN (@IconIDGuestOrgUnit, @IconIDGuestLeistung) AND -- only those where we do not have guestright (show always all with guestright)
          NOT EXISTS(SELECT TOP 1 1
                     FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                     WHERE LEI.BaPersonID = TRE.BaPersonID AND     -- only current person
                           LEI.UserID = TRE.UserID AND             -- only current user
                           LEI.ModulID IN (2, 3, 4, 5, 6, 7, 8) AND   -- only FV,SB,CM,BW,ED,IN,AB items
                           LEI.DatumBis IS NULL)                   -- item hast to be open
    
    -- logging
    PRINT ('removed closed persons from #tmpTree: ' + CONVERT(VARCHAR, GETDATE(), 113))
  END
  
  -------------------------------------------------------------------------------
  -- fill icons depending on state of item in FaLeistung
  -------------------------------------------------------------------------------
  UPDATE TRE
  SET [FV] = 1200 + ISNULL((SELECT CASE WHEN LEI.DatumBis IS NULL THEN @OffActive ELSE @OffClosed END
                            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                            WHERE LEI.FaLeistungID = TRE.FV_FaLeistungID), @OffDisabled),
      
      [SB] = 1300 + ISNULL((SELECT CASE WHEN LEI.DatumBis IS NULL THEN @OffActive ELSE @OffClosed END
                            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                            WHERE LEI.FaLeistungID = TRE.SB_FaLeistungID), @OffDisabled),
      
      [CM] = 1400 + ISNULL((SELECT CASE WHEN LEI.DatumBis IS NULL THEN @OffActive ELSE @OffClosed END
                            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                            WHERE LEI.FaLeistungID = TRE.CM_FaLeistungID), @OffDisabled),
      
      [BW] = 1500 + ISNULL((SELECT CASE WHEN LEI.DatumBis IS NULL THEN @OffActive ELSE @OffClosed END
                            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                            WHERE LEI.FaLeistungID = TRE.BW_FaLeistungID), @OffDisabled),
      
      [ED] = 1600 + ISNULL((SELECT CASE WHEN LEI.DatumBis IS NULL THEN @OffActive ELSE @OffClosed END
                            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                            WHERE LEI.FaLeistungID = TRE.ED_FaLeistungID), @OffDisabled),
      
      [IN] = 1700 + ISNULL((SELECT CASE WHEN LEI.DatumBis IS NULL THEN @OffActive ELSE @OffClosed END
                            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                            WHERE LEI.FaLeistungID = TRE.IN_FaLeistungID), @OffDisabled),
      
      [AB] = 1800 + ISNULL((SELECT CASE WHEN LEI.DatumBis IS NULL THEN @OffActive ELSE @OffClosed END
                            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                            WHERE LEI.FaLeistungID = TRE.AB_FaLeistungID), @OffDisabled),
                            
      [WD] = 4100 + ISNULL((SELECT CASE WHEN LEI.DatumBis IS NULL THEN @OffActive ELSE @OffClosed END
                            FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                            WHERE LEI.FaLeistungID = TRE.WD_FaLeistungID), @OffDisabled)
  FROM #tmpTree TRE
  WHERE TRE.Type = 'P'
  
  -------------------------------------------------------------------------------
  -- filter depending on flags (FV, SB, CM, BW, ED, IN, AB, WD)
  -------------------------------------------------------------------------------
  IF (@FV = 1 OR @SB = 1 OR @CM = 1 OR @BW = 1 OR @ED = 1 OR @IN = 1 OR @AB = 1 OR @WD = 1)
  BEGIN
    -- foreach flag, delete these items where no active entry is available (using iconid of each item)
    IF (@FV = 1) DELETE FROM #tmpTree WHERE [FV] % 100 = 0 AND Type = 'P'
    IF (@SB = 1) DELETE FROM #tmpTree WHERE [SB] % 100 = 0 AND Type = 'P'
    IF (@CM = 1) DELETE FROM #tmpTree WHERE [CM] % 100 = 0 AND Type = 'P'
    IF (@BW = 1) DELETE FROM #tmpTree WHERE [BW] % 100 = 0 AND Type = 'P'
    IF (@ED = 1) DELETE FROM #tmpTree WHERE [ED] % 100 = 0 AND Type = 'P'
    IF (@IN = 1) DELETE FROM #tmpTree WHERE [IN] % 100 = 0 AND Type = 'P'
    IF (@AB = 1) DELETE FROM #tmpTree WHERE [AB] % 100 = 0 AND Type = 'P'
    IF (@WD = 1) DELETE FROM #tmpTree WHERE [WD] % 100 = 0 AND Type = 'P'
  
    -- delete all users without open case (except current @UserID)
    DELETE USR
    FROM @Users USR
    WHERE USR.UserID <> @UserID  AND
          NOT EXISTS (SELECT TOP 1 1 
                      FROM #tmpTree TRE 
                      WHERE TRE.Type = 'P' AND       -- only persons
                            TRE.UserID = USR.UserID)
    
    -- logging
    PRINT ('done filtering #tmpTree: ' + CONVERT(VARCHAR, GETDATE(), 113))
  END
  
  -------------------------------------------------------------------------------
  -- build up orgunit structure (employees and orgunits)
  -------------------------------------------------------------------------------
  -- delete all users without open case (except current @UserID)
  DELETE USR
  FROM @Users USR
  WHERE USR.UserID <> @UserID AND
        NOT EXISTS (SELECT TOP 1 1 
                    FROM #tmpTree TRE 
                    WHERE TRE.Type = 'P' AND       -- search only in persons
                          TRE.UserID = USR.UserID)
  
  -- logging
  PRINT ('removed all users without open case: ' + CONVERT(VARCHAR, GETDATE(), 113))
   
  -- add employees to tree
  INSERT INTO #tmpTree (ID, ParentID, Type, Name, UserID, OrgUnitID, IconID)
    SELECT [ID]        = 'E' + CONVERT(VARCHAR, USR.UserID),
           [ParentID]  = 'O' + CONVERT(VARCHAR, dbo.fnOrgUnitOfUser(USR.UserID, 1)),
           [Type]      = 'E',
           [Name]      = USR.LastName + ISNULL(', ' + USR.FirstName,''),
           [UserID]    = USR.UserID,
           [OrgUnitID] = CONVERT(INT, dbo.fnOrgUnitOfUser(USR.UserID, 1)),
           [IconID]    = 101
    FROM @Users TMP
      INNER JOIN dbo.XUser USR WITH (READUNCOMMITTED) ON USR.UserID = TMP.UserID
  
  -- logging
  PRINT ('added employees to tree: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -- add orgunit structure to tree
  IF (@IncludeGroup = 1 OR @IncludeGuest = 1)
  BEGIN
    DECLARE @FirstRun bit
    SET @FirstRun = 1
    
    -- loop as long as any data can be retrieved (not all parents found)
    WHILE (@FirstRun = 1 OR @@ROWCOUNT > 0) 
    BEGIN
      -- no more first run
      SET @FirstRun = 0
      
      -- insert all parents of items
      INSERT INTO #tmpTree (ID, ParentID, Type, Name, OrgUnitID, IconID)
        SELECT DISTINCT
               [ID]        = 'O' + CONVERT(VARCHAR, ORG.OrgUnitID),
               [ParentID]  = 'O' + CONVERT(VARCHAR, ORG.ParentID),
               [Type]      = 'O',
               [Name]      = ORG.ItemName,
               [OrgUnitID] = ORG.ParentID,
               [IconID]    = 100
        FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
          INNER JOIN #tmpTree TRE1 ON TRE1.Type <> 'P' AND 
                                      TRE1.ParentID = 'O' + CONVERT(VARCHAR, ORG.OrgUnitID)
          LEFT  JOIN #tmpTree TRE2 ON TRE2.Type = 'O' AND 
                                      TRE2.ID = 'O' + CONVERT(VARCHAR, ORG.OrgUnitID)
        WHERE TRE1.ParentID LIKE 'O%' AND 
              TRE2.ID IS NULL
    END -- [WHILE]
    
    -- logging
    PRINT ('added parent items to tree: ' + CONVERT(VARCHAR, GETDATE(), 113))
  END -- [IF]
  
  -------------------------------------------------------------------------------
  -- calc amount of persons
  -------------------------------------------------------------------------------
  -- amount of persons
  DECLARE @PersonCount INT
  SET @PersonCount = (SELECT COUNT(DISTINCT TRE.BaPersonID) 
                      FROM #tmpTree TRE 
                      WHERE TRE.Type = 'P') -- only persons
  
  -- logging
  PRINT ('counted items: ' + CONVERT(VARCHAR, GETDATE(), 113))
  
  -------------------------------------------------------------------------------
  -- show output
  -------------------------------------------------------------------------------
  SELECT TRE.*,
         PersonCount = @PersonCount
  FROM #tmpTree TRE
  ORDER BY CASE TRE.Type WHEN 'O' THEN 1
                         WHEN 'E' THEN 2
                         WHEN 'P' THEN 3
                         ELSE 4
           END, 
           TRE.Name,
           TRE.BaPersonID,
           TRE.UserID
  
  -------------------------------------------------------------------------------
  -- cleanup
  -------------------------------------------------------------------------------
  -- do remove temp tables
  DROP TABLE #tmpTree
  DROP TABLE #Persons
  
  -- logging
  PRINT ('done: ' + CONVERT(VARCHAR, GETDATE(), 113))
END
GO