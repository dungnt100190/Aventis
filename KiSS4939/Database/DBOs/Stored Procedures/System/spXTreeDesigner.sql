SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXTreeDesigner;
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Builds the tree used in BusinessDesigner
    @UserID: The user's id of the user who wants to show the business designer
  -
  RETURNS: Table containing the tree used in business designer
=================================================================================================
  TEST:    EXEC dbo.spXTreeDesigner;
           EXEC dbo.spXTreeDesigner 2;
           EXEC dbo.spXTreeDesigner 2561;
=================================================================================================*/

CREATE PROCEDURE dbo.spXTreeDesigner
(
  @UserID INT = -1
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- init temporary table
  -------------------------------------------------------------------------------
  DECLARE @Tree TABLE 
   (
    ID VARCHAR(500) COLLATE DATABASE_DEFAULT NOT NULL PRIMARY KEY,
    ParentID VARCHAR(500) COLLATE DATABASE_DEFAULT NULL,
    IconID INT NULL,
    Title VARCHAR(100) NOT NULL,
    ModulID INT NULL,
    ClassName VARCHAR(255) NULL,
    SortKey INT NOT NULL IDENTITY(1, 1),
    MainSortKey INT DEFAULT (0)
  );
  
  -------------------------------------------------------------------------------
  -- init main vars
  -------------------------------------------------------------------------------
  -- declare vars
  DECLARE @IsUserAdmin BIT;
  DECLARE @IsUserBIAGAdmin BIT;
  
  -- set vars
  SET @IsUserAdmin     = ISNULL(dbo.fnIsUserAdmin(@UserID), 0);
  SET @IsUserBIAGAdmin = ISNULL(dbo.fnIsUserBIAGAdmin(@UserID), 0);
  
  -- ---------------------------------------------------------------------------------------------
  -- check if user has special rights for accessing business designer like administrator
  -- ---------------------------------------------------------------------------------------------
  IF (EXISTS(SELECT TOP 1 1
             FROM dbo.XUser_UserGroup          UUG WITH (READUNCOMMITTED)
               INNER JOIN dbo.XUserGroup_Right UGR WITH (READUNCOMMITTED) ON UGR.UserGroupID = UUG.UserGroupID
               INNER JOIN dbo.XRight           RGT WITH (READUNCOMMITTED) ON RGT.RightID = UGR.RightID
                                                                         AND RGT.RightName = 'DSGBusinessDesignerAdmin'
             WHERE UUG.UserID = @UserID))
  BEGIN
    -- user has special right assigned, so access is granted like administrator
    SET @IsUserAdmin = 1;
  END;
  
  -------------------------------------------------------------------------------
  -- check if user has rights to view business designer tree (requires admin-rights)
  -------------------------------------------------------------------------------
  IF (@IsUserAdmin = 0)
  BEGIN
    -- user has no rights, don't show any entry in tree
    SELECT *
    FROM @Tree
    WHERE 1 = 2;
    
    -- done
    RETURN;
  END;
  
  -------------------------------------------------------------------------------
  -- init ordering-vars used for MainSortKey-ordering
  -------------------------------------------------------------------------------
  -- declare vars
  DECLARE @OrderMenu INT;
  DECLARE @OrderModules INT;
  DECLARE @OrderControls INT;
  DECLARE @OrderLOVs INT;
  DECLARE @OrderSymbol INT;
  DECLARE @OrderTables INT;
  DECLARE @OrderViews INT;
  DECLARE @OrderFunctions INT;
  DECLARE @OrderProcedures INT;
  DECLARE @OrderTree INT;
  
  -- set vars
  SET @OrderMenu       = 0;
  SET @OrderModules    = 1;
  SET @OrderControls   = 2;
  SET @OrderLOVs       = 3;
  SET @OrderSymbol     = 4;
  SET @OrderTables     = 5;
  SET @OrderViews      = 6;
  SET @OrderFunctions  = 7;
  SET @OrderProcedures = 8;
  SET @OrderTree       = 9;
  
  -------------------------------------------------------------------------------
  -- add menu (all admins, rights are handled on control)
  -------------------------------------------------------------------------------
  -- menu: main-entry
  INSERT INTO @Tree (ID, IconID, Title, ClassName, MainSortKey) 
  VALUES ('MNU', 2113, 'Menu', 'CtlMenuEditor', @OrderMenu);
  
  -------------------------------------------------------------------------------
  -- add modules
  -- - admin: can view main-entry without classname and all subentries
  -- - biag-admin: can view all
  -------------------------------------------------------------------------------
  -- check rights
  IF (@IsUserBIAGAdmin = 0)
  BEGIN
    -- admin: main entry for module without classname
    INSERT INTO @Tree (ID, IconID, Title, ClassName, MainSortKey) 
    VALUES ('MOD', 2111, 'Module', NULL, @OrderModules);
  END
  ELSE
  BEGIN
    -- biag-admin: main entry for module including classname
    INSERT INTO @Tree (ID, IconID, Title, ClassName, MainSortKey) 
    VALUES ('MOD', 2111, 'Module', 'CtlModul', @OrderModules);
  END;
  
  -- sub entries
  INSERT INTO @Tree (ID, ParentID, IconID, Title, ModulID, ClassName, MainSortKey)
    SELECT ID          = 'MOD' + CONVERT(VARCHAR, MOD.ModulID), 
           ParentID    = 'MOD',
           IconID      =  CASE 
                            WHEN ModulID = -7 THEN 177  -- Common
                            WHEN ModulID = -1 THEN 99   -- Main
                            WHEN ModulID =  0 THEN 171  -- Allgemein
                            ELSE 1001 + (100 * MOD.ModulID)
                          END,
           Title       = MOD.Name, 
           ModulID     = MOD.ModulID, 
           ClassName   = NULL,
           MainSortKey = @OrderModules
    FROM dbo.XModul MOD WITH (READUNCOMMITTED)
    ORDER BY MOD.ModulID;
  
  -----------------------------------------------------------------------------
  -- add lovs (all admins, rights are handled on controls)
  -----------------------------------------------------------------------------
  -- lovs: main-entry
  INSERT INTO @Tree (ID, IconID, Title, ClassName, MainSortKey) 
  VALUES ('LOV', 206, 'Wertelisten', 'CtlLOV', @OrderLOVs);
  
  -- lovs: sub-entries
  INSERT INTO @Tree (ID, ParentID, IconID, Title, ModulID, ClassName, MainSortKey)
    SELECT ID          = 'LOV/' + XLV.LOVName, 
           ParentID    = 'LOV', 
           IconID      = 195, 
           Title       = XLV.LOVName, 
           ModulID     = ISNULL(XLV.ModulID, 0), 
           ClassName   = 'CtlLOVCode',
           MainSortKey = @OrderLOVs
    FROM dbo.XLOV          XLV WITH (READUNCOMMITTED)
      LEFT JOIN dbo.XModul MOD WITH (READUNCOMMITTED) ON MOD.ModulID = XLV.ModulID
    ORDER BY XLV.LOVName;
  
  -----------------------------------------------------------------------------
  -- add tree (all admins, rights are handled on controls)
  -----------------------------------------------------------------------------
  -- tree: main-entry
  INSERT INTO @Tree (ID, IconID, Title, ClassName, MainSortKey) 
  VALUES ('TRE', 2114, 'Tree', 'CtlTreeEditor', @OrderTree);
  
  -- tree: sub-entries
  INSERT INTO @Tree (ID, ParentID, IconID, Title, ModulID, ClassName, MainSortKey)
    SELECT ID          = TRE.ID + '/TRE', 
           ParentID    = TRE.ID, 
           IconID      = 2114, 
           Title       = 'Tree', 
           ModulID     = TRE.ModulID, 
           ClassName   = 'CtlTreeEditor',
           MainSortKey = @OrderTree
    FROM @Tree          TRE
      INNER JOIN XModul MOD WITH (READUNCOMMITTED) ON MOD.ModulID = TRE.ModulID 
                                                  AND MOD.ModulTree = 1
    WHERE TRE.ParentID = 'MOD'
    ORDER BY MOD.ModulID;
  
  -------------------------------------------------------------------------------
  -- add controls, symbol, tables, views, functions, procedures
  -- - admin: disabled
  -- - biag-admin: can view all
  -------------------------------------------------------------------------------
  -- check rights
  IF (@IsUserBIAGAdmin = 1)
  BEGIN
    -----------------------------------------------------------------------------
    -- controls
    -----------------------------------------------------------------------------
    -- controls: main-entry
    INSERT INTO @Tree (ID, IconID, Title, ClassName, MainSortKey) 
    VALUES ('MSK', 2112, 'Masken', 'CtlClass', @OrderControls);
    
    -- controls: sub-entries
    INSERT INTO @Tree (ID, ParentID, IconID, Title, ModulID, ClassName, MainSortKey)
      SELECT ID          = 'MSK/' + CLS.ClassName, 
             ParentID    = 'MSK', 
             IconID      = ISNULL(CONVERT(int, XLC.Value3), 2112), 
             Title       = CLS.ClassName, 
             ModulID     = CLS.ModulID, 
             ClassName   = 'CtlDesigner',
             MainSortKey = @OrderControls
      FROM dbo.XClass          CLS WITH (READUNCOMMITTED)
        LEFT JOIN dbo.XLOVCode XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'Class' 
                                                         AND (XLC.Code = CLS.ClassCode OR (CLS.ClassCode IS NULL AND CLS.BaseType = XLC.Value1))
      WHERE CLS.Designer = 1
      ORDER BY CLS.ClassName;
    
    -----------------------------------------------------------------------------
    -- symbol
    -----------------------------------------------------------------------------
    -- symbol: main-entry
    INSERT INTO @Tree (ID, IconID, Title, ClassName, MainSortKey) 
    VALUES ('ICO', 196, 'Symbol', 'CtlIcon', @OrderSymbol);
    
    -----------------------------------------------------------------------------
    -- tables
    -----------------------------------------------------------------------------
    -- tables: main-entry
    INSERT INTO @Tree (ID, IconID, Title, ClassName, MainSortKey) 
    VALUES ('TBL', 2121, 'Tabellen', 'CtlTableEditor', @OrderTables);
    
    -- tables: sub-entries
    INSERT INTO @Tree (ID, ParentID, IconID, Title, ModulID, ClassName, MainSortKey)
      SELECT ID          = 'TBL/' + TBL.TableName, 
             ParentID    = 'TBL', 
             IconID      = 2121, 
             Title       = TBL.TableName, 
             ModulID     = ISNULL(TBL.ModulID, 0), 
             ClassName   = 'CtlTableStructureEditor',
             MainSortKey = @OrderTables
      FROM dbo.XTable TBL WITH (READUNCOMMITTED)
      ORDER BY TBL.TableName;
  END; -- [IF (@IsUserBIAGAdmin = 1)]
  
  -----------------------------------------------------------------------------
  -- copy some entries to module-tree-part, too
  -----------------------------------------------------------------------------
  -- copy entries
  INSERT INTO @Tree (ID, ParentID, IconID, Title, ModulID, ClassName, MainSortKey)
    SELECT ID          = MOD.ID + '/' + TRE.ID, 
           ParentID    = MOD.ID + ISNULL('/' + TRE.ParentID, ''), 
           IconID      = TRE.IconID, 
           Title       = TRE.Title, 
           ModulID     = MOD.ModulID, 
           ClassName   = TRE.ClassName,
           MainSortKey = TRE.MainSortKey
    FROM @Tree TRE
      INNER JOIN @Tree MOD ON MOD.ParentID = 'MOD' 
                          AND (MOD.ModulID = TRE.ModulID OR TRE.ParentID IS NULL)
    WHERE ISNULL(TRE.ParentID, '') NOT IN ('MOD') 
      AND TRE.ID NOT IN ('MOD', 'TRE', 'MNU') 
      AND TRE.ID NOT LIKE 'MOD%/TRE' 
      AND (MOD.ModulID >= 0 OR TRE.ParentID IS NOT NULL OR EXISTS (SELECT TOP 1 1 
                                                                   FROM @Tree 
                                                                   WHERE ModulID = MOD.ModulID AND 
                                                                         ParentID = TRE.ID))
    ORDER BY MOD.SortKey, TRE.SortKey;
  
  -----------------------------------------------------------------------------
  -- add static entries if not yet existing
  -- - admin: disabled
  -- - biag-admin: add if missing
  -----------------------------------------------------------------------------
  IF (@IsUserBIAGAdmin = 1)
  BEGIN
    -- check if Common MSK does already exist
    IF (NOT EXISTS(SELECT TOP 1 1 
                   FROM @Tree 
                   WHERE ID = 'MOD-7/MSK'))
    BEGIN
      -- insert Common MSK for editing common controls, too
      INSERT INTO @Tree (ID, ParentID, IconID, Title, ModulID, ClassName, MainSortKey) 
      VALUES ('MOD-7/MSK', 'MOD-7', 2112, 'Masken', -7, 'CtlClass', @OrderControls);
    END;
    
     -- check if Main MSK does already exist
    IF (NOT EXISTS(SELECT TOP 1 1 
                   FROM @Tree 
                   WHERE ID = 'MOD-1/MSK'))
    BEGIN
      -- insert Main MSK for editing main controls, too
      INSERT INTO @Tree (ID, ParentID, IconID, Title, ModulID, ClassName, MainSortKey) 
      VALUES ('MOD-1/MSK', 'MOD-1', 2112, 'Masken', -1, 'CtlClass', @OrderControls);
    END;
  END; -- [IF (@IsUserBIAGAdmin = 1)]
  
  -----------------------------------------------------------------------------
  -- do cleanup of output-tree
  -----------------------------------------------------------------------------
  DELETE TRE 
  FROM @Tree TRE
  WHERE TRE.ParentID = 'MOD' 
    AND TRE.ModulID < 0 
    AND NOT EXISTS(SELECT TOP 1 1
                   FROM @Tree SUB
                   WHERE SUB.ParentID = TRE.ID);
  
  ------------------------------------------------------------------------------
  -- done, show content of temporary table as output
  -------------------------------------------------------------------------------
  SELECT TRE.ID,
         TRE.ParentID,
         TRE.IconID,
         TRE.Title,
         TRE.ModulID,
         TRE.ClassName,
         TRE.SortKey
  FROM @Tree TRE
  WHERE TRE.ID NOT IN ('MOD0/MSK')
  ORDER BY TRE.MainSortKey, TRE.SortKey;
END;
GO