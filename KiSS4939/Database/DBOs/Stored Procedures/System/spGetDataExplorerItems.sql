SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spGetDataExplorerItems;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spGetDataExplorerItems
(
  @LanguageCode INT
)
AS
BEGIN
  -- -------------------------------------------------------------------------------------
  -- Retrieve all subentries of FrmDataExplorer-Class in XMenuItem
  -- (special due to parent/child dependencies)
  -- -------------------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -- declare readonly vars
  DECLARE @iconIDFolder INT;
  DECLARE @iconIDItem INT;
  
  -- setup readonly vars
  SET @iconIDFolder = 166;
  SET @iconIDItem = 210;
  
  -- setup temp table
  CREATE TABLE #tmpMenuItemTree
  (
    TreeId INT IDENTITY PRIMARY KEY,
    ParentTreeId INT,
    lvl INT,
    Path VARCHAR(2000),
    TreeMenuItemID_Path VARCHAR(2000),
    MenuItemID INT NOT NULL,
    Caption VARCHAR(255),
    MenuTID INT,
    IconID INT,
    SortKey INT,
    ClassName VARCHAR(255)
  );
  
  -- declare vars
  DECLARE @rowcount INT;
  DECLARE @lvl INT;
  DECLARE @delcount INT;
  
  -- setup vars
  SET @lvl = 0;
  
  -- Here we insert the top levels that will be used to extract all sub leves from.
  INSERT INTO #tmpMenuItemTree (lvl, MenuItemID, Caption, MenuTID, IconID, SortKey, ClassName)
    SELECT @lvl, MNU.MenuItemID, MNU.Caption, MNU.MenuTID, MNU.ImageIndex, MNU.SortKey, MNU.ClassName
    FROM dbo.XMenuItem MNU WITH (READUNCOMMITTED) 
    WHERE MNU.Visible = 1 
      AND MNU.ParentMenuItemID IN (SELECT MenuItemID
                                   FROM dbo.XMenuItem WITH (READUNCOMMITTED) 
                                   WHERE ClassName = 'FrmDataExplorer')
  
  -- get numbers of rows affected by the initial insert
  SET @rowcount = @@ROWCOUNT;
  
  -- update the first level's Path and TreeMenuItemID_Path. TreeMenuItemID_Path will be used to prevent the recursion from
  -- going into an endless loop if for example si_the_geek is defined as both parent and child to mendhak.
  UPDATE #tmpMenuItemTree
  SET Path                = STR(TreeId, 10, 0) + '.',
      TreeMenuItemID_Path = CAST(MenuItemID AS VARCHAR(10)) + '\';
  
  WHILE (@rowcount > 0)
  BEGIN
    -- Increase level by one.
    SET @lvl = @lvl + 1;
    
    -- This line inserts all records from the XMenuItem table that has the previous level's
    -- TreeMenuItemID as ParentMenuItemID. In other words, it inserts all parent's children from the previous
    -- execution of the loop.
    INSERT INTO #tmpMenuItemTree (lvl, ParentTreeId, MenuItemID, Caption, MenuTID, IconID, SortKey, ClassName)
      SELECT @lvl, TMP.TreeId, MNU.MenuItemID, MNU.Caption, MNU.MenuTID, MNU.ImageIndex, MNU.SortKey, MNU.ClassName
      FROM dbo.XMenuItem            MNU WITH (READUNCOMMITTED)
        INNER JOIN #tmpMenuItemTree TMP ON MNU.ParentMenuItemID = TMP.MenuItemID 
                                       AND TMP.lvl = @lvl - 1
      WHERE MNU.Visible = 1;
    
    -- Get number of rows affected by the previous insert. If no records were affected by the last
    -- statement, then we know that we have reached the bottom of the hierarcy.
    SET @rowcount = @@ROWCOUNT;
    
    -- The following SQL updates the newly inserted records' Path with the
    -- the new TreeId + previous levels TreeId. The path is used later to sort
    -- the result in a treeview look-a-like way. We also update TreeMenuItemID_Path
    -- with the TreeMenuItemID and previous level's TreeMenuItemID_Path. The TreeMenuItemID_Path
    -- is used to detect endless loops and therefore we only update TreeMenuItemID_Path
    -- where parent TreeMenuItemID_Path does not contain current TreeMenuItemID. This is
    -- perhaps a little bit difficult to understand the first time you read the code.
    UPDATE TMP1
    SET TMP1.Path                = TMP2.Path + STR(TMP1.TreeId, 10, 0) + '.',
        TMP1.TreeMenuItemID_Path = TMP2.TreeMenuItemID_Path + CAST(TMP1.MenuItemID AS varchar(10)) + '\'
    FROM #tmpMenuItemTree         TMP1
      INNER JOIN #tmpMenuItemTree TMP2 ON TMP1.ParentTreeId = TMP2.TreeId
    WHERE TMP1.lvl = @lvl 
      AND TMP2.TreeMenuItemID_Path NOT LIKE '%' + CAST(TMP1.MenuItemID AS VARCHAR(10)) + '\%';
    
    -- This statement deletes andy records where TreeMenuItemID_Path is NULL. In other
    -- words: We delete records that will cause an endless loop.
    DELETE TMP
    FROM #tmpMenuItemTree TMP
    WHERE TMP.TreeMenuItemID_Path IS NULL;
    
    -- We then get the number of records deleted...
    SET @delcount = @@ROWCOUNT;

    -- ... and substract this number from the records appended. If @rowcount=0
    -- then the WHILE loop will exit.
    SET @rowcount = @rowcount - @delcount;
  END;
  
  -- Update icons (also used in later processing within this storeprocedure)
  UPDATE #tmpMenuItemTree
  SET IconID = CASE (SELECT COUNT(1)
                     FROM #tmpMenuItemTree TMP
                     WHERE TMP.ParentTreeId = #tmpMenuItemTree.TreeId)
                   WHEN 0 THEN @iconIDItem  -- No chilren --> is item
                   ELSE @iconIDFolder       -- Has children --> is folder
                 END;

  -- Remove entries with empty classname and without children 
  DELETE TMP
  FROM #tmpMenuItemTree TMP
  WHERE TMP.ClassName IS NULL 
    AND TMP.IconID = @iconIDItem;
  
  -- Update Caption of all items with ML
  UPDATE TMP
  SET Caption = ISNULL(dbo.fnGetMLText(MenuTID, @LanguageCode), Caption)
  FROM #tmpMenuItemTree TMP;
  
  -- Now we can choose to display the results in what way we want to. Path can, as we said before,
  -- be used to sort the result in a treeview way.
  SELECT TreeId, 
         ParentTreeId, 
         MenuItemID, 
         Caption, 
         MenuTID, 
         IconID, 
         SortKey, 
         ClassName
  FROM #tmpMenuItemTree
  ORDER BY ParentTreeId, SortKey, MenuItemID;
  
  -- -------------------------------------------------------------------------------------
  -- Final stuff
  -- -------------------------------------------------------------------------------------
  SET NOCOUNT OFF;
END;
GO