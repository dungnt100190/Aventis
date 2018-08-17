SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXRowMerge;
GO

-------------------------------------------------------------------------------
-- setup required properties
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER ON;
GO

/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: 
    @TableName:       The initial table to use as start for merging
    @RowID:           The id within the initial table to keep
    @RowID_Delete:    The id within the initial table to merge data and finally delete
    @DeleteRow:       Flag if id in initial table shall be deleted
    @DebugOn:         Flag if debug information shall be written to output
    @RowIDColumnName: The optional name of the column to handle, used for special handling
                      - if @TableName = "BaPerson", the param will be set to "BaPersonID" if not given
                        by call of sp
  -
  RETURNS: nothing
  -
  EXCEPTION: An error will be shown in table is BaPerson and the id to delete has corresponding entries 
             in table KbWVEinzelposten.
=================================================================================================
  TEST:    EXECUTE dbo.spXRowMerge 'BaPerson', 64997, 64998
           EXECUTE dbo.spXRowMerge 'BaPerson', 64999, 65000, 1, 1
           EXECUTE dbo.spXRowMerge 'BaPerson', 65001, 65002, 1, 1
=================================================================================================*/

CREATE PROCEDURE dbo.spXRowMerge
(
  @TableName VARCHAR(1000),
  @RowID INT,
  @RowID_Delete INT,
  @DeleteRow BIT = 1,
  @DebugOn BIT = 0,
  @RowIDColumnName VARCHAR(255) = NULL
)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- start call
  -----------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@TableName, '') = '')
  BEGIN
    -- invalid call
    RETURN;
  END;
  
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @PKeyName VARCHAR(1000);
  DECLARE @FaLeistung INT;
  DECLARE @FaLeistungDel INT;
  DECLARE @RowCount INT;
  
  IF (ISNULL(@RowIDColumnName, '') = '' AND @TableName = 'BaPerson')
  BEGIN
    SET @RowIDColumnName = 'BaPersonID';
  END;
  
  -- debug
  IF (@DebugOn = 1)
  BEGIN
    PRINT ('Info: @RowIDColumnName = "' + ISNULL(@RowIDColumnName, 'NULL') + '"');
  END;
  
  -----------------------------------------------------------------------------
  -- #3441: Merging KA Allgemein if both persons have a KA-Allgemein 
  --        entry in FaLeistung
  -----------------------------------------------------------------------------
  IF (@TableName = 'BaPerson'
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.FaLeistung
                  WHERE ModulID = 7
                    AND FaProzessCode = 700
                    AND BaPersonID = @RowID) 
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.FaLeistung
                  WHERE ModulID = 7
                    AND FaProzessCode = 700
                    AND BaPersonID = @RowID_Delete))
  BEGIN
    -- handle this case in a separate sp
    EXEC dbo.spKaAllgemein_RowMerge @BaPersonID_Keep   = @RowID,
                                    @BaPersonID_Delete = @RowID_Delete,
                                    @DebugOn           = @DebugOn;
  END;
  
  -----------------------------------------------------------------------------
  -- #5813: fix bug with entries in BaWVCode
  -----------------------------------------------------------------------------
  IF (@TableName = 'BaPerson'
      AND EXISTS (SELECT TOP 1 1 
                  FROM dbo.BaWVCode 
                  WHERE BaPersonID = @RowID)
      AND EXISTS (SELECT TOP 1 1 
                  FROM dbo.BaWVCode 
                  WHERE BaPersonID = @RowID_Delete))
  BEGIN
    -- check if any entry in KbWVEinzelposten exists
    IF (EXISTS(SELECT TOP 1 1
               FROM dbo.KbWVEinzelposten WVE
                 INNER JOIN dbo.BaWVCode WVC ON WVC.BaWVCodeID = WVE.BaWVCodeID
                                            AND WVC.BaPersonID = @RowID_Delete))
    BEGIN
      -- if any entry in KbWVEinzelposten exists, the person to delete cannot be droped
      -- do not continue
      RAISERROR ('The person to delete (id=''%d'') has corresponding entries in table ''KbWVEinzelposten'' and therefore cannot be merged.', 18, 1, @RowID_Delete);
      RETURN;
    END;
    
    -- if no entry in KbWVEinzelposten exists, we remove all entries in BaWVCode for the person to delete
    DELETE WVC
    FROM dbo.BaWVCode WVC
    WHERE WVC.BaPersonID = @RowID_Delete;
  END;
  
  -----------------------------------------------------------------------------
  -- #5813: fix bug with duplicate entries in KbKostenstelle_BaPerson
  -----------------------------------------------------------------------------
  IF (@TableName = 'BaPerson'
      AND EXISTS (SELECT TOP 1 1 
                  FROM dbo.KbKostenstelle_BaPerson 
                  WHERE BaPersonID = @RowID) 
      AND EXISTS (SELECT TOP 1 1 
                  FROM dbo.KbKostenstelle_BaPerson 
                  WHERE BaPersonID = @RowID_Delete))
  BEGIN
    -- init vars
    DECLARE @KbKostenstelleID_Keep INT;
    DECLARE @KbKostenstelleID_Delete INT;
    DECLARE @KbKostenstelle_BaPerson_Delete INT;
    
    -- get ids
    SELECT @KbKostenstelleID_Keep = KbKostenstelleID
    FROM dbo.KbKostenstelle_BaPerson 
    WHERE BaPersonID = @RowID;
    
    SELECT @KbKostenstelleID_Delete        = KbKostenstelleID,
           @KbKostenstelle_BaPerson_Delete = KbKostenstelleBaPersonID
    FROM dbo.KbKostenstelle_BaPerson 
    WHERE BaPersonID = @RowID_Delete;
    
    -- debug
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('keep KbKostenstelleID=' + CONVERT(VARCHAR(50), @KbKostenstelleID_Keep));
      PRINT ('delete KbKostenstelleID=' + CONVERT(VARCHAR(50), @KbKostenstelleID_Delete));
      PRINT ('delete KbKostenstelle_BaPersonID=' + CONVERT(VARCHAR(50), @KbKostenstelle_BaPerson_Delete));
    END;
    
    -- recursive call for KbKostenstelle
    EXEC dbo.spXRowMerge 'KbKostenstelle', @KbKostenstelleID_Keep, @KbKostenstelleID_Delete, @DeleteRow, @DebugOn;
    
    -- remove obsolete entry in KbKostenstelle_BaPerson
    DELETE KSP
    FROM dbo.KbKostenstelle_BaPerson KSP
    WHERE KSP.KbKostenstelleBaPersonID = @KbKostenstelle_BaPerson_Delete;
  END;
  
  -----------------------------------------------------------------------------
  -- #3441: fix merging persons and delete rows of the person to delete where
  --        we just can have one definition
  -----------------------------------------------------------------------------
  IF (@TableName = 'BaPerson')
  BEGIN
    ---------------------------------------------------------------------------
    -- BaPerson_BaInstitution: delete duplicates to ensure no UK failure
    ---------------------------------------------------------------------------
    DELETE PIN_D
    FROM dbo.BaPerson_BaInstitution PIN_D
    WHERE PIN_D.BaPersonID = @RowID_Delete
      AND EXISTS (SELECT TOP 1 1
                  FROM dbo.BaPerson_BaInstitution PIN_K
                  WHERE PIN_K.BaPersonID = @RowID
                    AND PIN_K.BaInstitutionID = PIN_D.BaInstitutionID
                    AND ISNULL(PIN_K.BaInstitutionKontaktID, -1) = ISNULL(PIN_D.BaInstitutionKontaktID, -1)
                    AND ISNULL(PIN_K.BaInstitutionTypID, -1) = ISNULL(PIN_D.BaInstitutionTypID, -1));
    
    SET @RowCount = @@ROWCOUNT;
    
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: Deleted "' + CONVERT(VARCHAR(50), @RowCount) + '" rows in "BaPerson_BaInstitution" for BaPersonID_Delete');
    END;
    
    ---------------------------------------------------------------------------
    -- BaPerson_Relation: delete duplicates to ensure no CK failure
    ---------------------------------------------------------------------------
    DELETE PRE_D
    FROM dbo.BaPerson_Relation PRE_D
    WHERE (PRE_D.BaPersonID_1 = @RowID_Delete OR PRE_D.BaPersonID_2 = @RowID_Delete)
      AND EXISTS (-- get duplicate entries after merging
                  SELECT TOP 1 1
                  FROM dbo.BaPerson_Relation PRE_K
                  WHERE PRE_K.BaPerson_RelationID <> PRE_D.BaPerson_RelationID
                    AND ((PRE_K.BaPersonID_1 = CASE PRE_D.BaPersonID_2 WHEN @RowID_Delete THEN @RowID ELSE PRE_D.BaPersonID_2 END 
                      AND PRE_K.BaPersonID_2 = CASE PRE_D.BaPersonID_1 WHEN @RowID_Delete THEN @RowID ELSE PRE_D.BaPersonID_1 END)                     
                      
                      OR (PRE_K.BaPersonID_1 = CASE PRE_D.BaPersonID_1 WHEN @RowID_Delete THEN @RowID ELSE PRE_D.BaPersonID_1 END 
                      AND PRE_K.BaPersonID_2 = CASE PRE_D.BaPersonID_2 WHEN @RowID_Delete THEN @RowID ELSE PRE_D.BaPersonID_2 END)
                      
                      OR (PRE_K.BaPersonID_1 = CASE PRE_D.BaPersonID_1 WHEN @RowID_Delete THEN @RowID ELSE PRE_D.BaPersonID_1 END 
                      AND PRE_K.BaPersonID_2 = CASE PRE_D.BaPersonID_1 WHEN @RowID_Delete THEN @RowID ELSE PRE_D.BaPersonID_1 END) 
                      
                      OR (PRE_K.BaPersonID_1 = CASE PRE_D.BaPersonID_2 WHEN @RowID_Delete THEN @RowID ELSE PRE_D.BaPersonID_2 END 
                      AND PRE_K.BaPersonID_2 = CASE PRE_D.BaPersonID_2 WHEN @RowID_Delete THEN @RowID ELSE PRE_D.BaPersonID_2 END))
                  
                  UNION ALL
                  
                  -- get relationship to each other which would be invalid after merging
                  SELECT TOP 1 1
                  FROM dbo.BaPerson_Relation PRE_K
                  WHERE (PRE_K.BaPersonID_1 = @RowID AND PRE_K.BaPersonID_2 = @RowID_Delete)
                     OR (PRE_K.BaPersonID_2 = @RowID AND PRE_K.BaPersonID_1 = @RowID_Delete));
    
    SET @RowCount = @@ROWCOUNT;
    
    IF (@DebugOn = 1)
    BEGIN
      PRINT ('Info: Deleted "' + CONVERT(VARCHAR(50), @RowCount) + '" rows in "BaPerson_Relation" for BaPersonID_Delete');
    END;
  END;
  
  -- ==========================================================================
  -- AutoMerge
  -- ==========================================================================
  
  -----------------------------------------------------------------------------
  -- find primary key for given table
  -----------------------------------------------------------------------------
  SELECT @PKeyName = MIN(COL.Name)
  FROM sysobjects           TBL
    INNER JOIN syscolumns   COL ON COL.id = TBL.id
    INNER JOIN sysindexkeys IDK ON IDK.id = TBL.id 
                               AND IDK.colid = COL.colid
    INNER JOIN sysindexes   IDX ON IDX.id = TBL.id 
                               AND IDK.indid = IDX.indid 
                               AND IDX.status & 2050 = 2050
  WHERE TBL.type = 'U'
    AND TBL.Name = @TableName
  GROUP BY TBL.Name
  HAVING COUNT(1) = 1;
  
  -----------------------------------------------------------------------------
  -- update foreign key for given primary key
  -----------------------------------------------------------------------------
  IF (@PKeyName IS NOT NULL)
  BEGIN
    ---------------------------------------------------------------------------
    -- init vars
    ---------------------------------------------------------------------------
    DECLARE @fTableName VARCHAR(400);
    DECLARE @fColumnName VARCHAR(400);
    DECLARE @SQL VARCHAR(MAX);
    
    ---------------------------------------------------------------------------
    -- setup cursor: update foreign keys
    ---------------------------------------------------------------------------
    DECLARE cur_SQLText CURSOR FOR
      SELECT TableName   = FTBL.name,
             fColumnName = FCOL.name,
             SQL = 'UPDATE [' + OBJECT_SCHEMA_NAME(FTBL.id) + '].[' + FTBL.name + '] ' + 
                   'SET [' + FCOL.name + '] = ' + CONVERT(VARCHAR, @RowID) + ' ' + 
                   'WHERE [' + FCOL.name + '] = ' + CONVERT(VARCHAR, @RowID_Delete)
      FROM sysforeignkeys     FKS
        INNER JOIN sysobjects FKSN ON FKSN.id = FKS.constid
        
        INNER JOIN sysobjects RTBL ON RTBL.id = FKS.rkeyid
        INNER JOIN syscolumns RCOL ON RCOL.id = RTBL.id 
                                  AND RCOL.colid = FKS.rkey
        
        INNER JOIN sysobjects FTBL ON FTBL.id = FKS.fkeyid
        INNER JOIN syscolumns FCOL ON FCOL.id = FTBL.id 
                                  AND FCOL.colid = FKS.fkey
      WHERE RTBL.name = @TableName 
        AND RCOL.name = @PKeyName;
    
    ---------------------------------------------------------------------------
    -- iterate through cursor: update foreign keys
    ---------------------------------------------------------------------------
    OPEN cur_SQLText
    
    FETCH FROM cur_SQLText 
    INTO @fTableName, @fColumnName, @SQL
    
    WHILE (@@FETCH_STATUS = 0)
    BEGIN
      -------------------------------------------------------------------------
      -- init vars
      -------------------------------------------------------------------------
      DECLARE @IndexName VARCHAR(500);
      DECLARE @DeletePart VARCHAR(1000);
      DECLARE @WherePart VARCHAR(1000);
      DECLARE @PrevIndexName VARCHAR(500);
      DECLARE @Uniquesql VARCHAR(4000)
      
      -------------------------------------------------------------------------
      -- setup cursor: delete duplicates
      -------------------------------------------------------------------------
      DECLARE cur_UniqueIndex CURSOR FOR
        SELECT IndexName  = IDX.name,
               DeletePart = 'DELETE TBL1
                             FROM [' + OBJECT_SCHEMA_NAME(TBL.id) + '].[' + TBL.name + ']  TBL1, [' + TBL.name + ']  TBL2 
                             WHERE TBL1.[' + COL2.name + '] = ' + CONVERT(VARCHAR, @RowID_Delete) +
                            '  AND TBL2.[' + COL2.name + '] = ' + CONVERT(VARCHAR, @RowID),
               WherePart  = CASE 
                              WHEN COL.name != @fColumnName THEN ' AND TBL1.[' + COL.name + '] = TBL2.[' + COL.name + ']'
                              ELSE '' 
                            END
        FROM sysobjects           TBL
          INNER JOIN syscolumns   COL  ON TBL.id = COL.id

          INNER JOIN sysindexes   IDX  ON IDX.id = TBL.id 
                                      AND IDX.Status & 2 = 2
          
          INNER JOIN sysindexkeys IDK  ON IDK.id = TBL.id 
                                      AND IDK.indid  = IDX.indid 
                                      AND IDK.colid = COL.colid
          
          INNER JOIN sysindexkeys IDK2 ON IDK2.id = TBL.id 
                                      AND IDK2.indid  = IDX.indid
          
          INNER JOIN syscolumns   COL2 ON TBL.id = COL2.id 
                                      AND IDK2.colid = COL2.colid
        WHERE TBL.name = @fTableName 
          AND COL2.name = @fColumnName
        ORDER BY 1;
      
      -------------------------------------------------------------------------
      -- iterate through cursor: delete duplicate
      -------------------------------------------------------------------------
      OPEN cur_UniqueIndex;
      
      FETCH FROM cur_UniqueIndex 
      INTO @IndexName, @DeletePart, @WherePart;
      
      SET @PrevIndexName = @IndexName;
      SET @Uniquesql = @DeletePart;
      
      WHILE (@@FETCH_STATUS = 0)
      BEGIN
        IF (@PrevIndexName != @IndexName)
        BEGIN
          IF (@DebugOn = 1)
          BEGIN
            PRINT @Uniquesql;
          END;
          
          -- do it!
          EXECUTE (@Uniquesql);
          
          SET @PrevIndexName = @IndexName;
          SET @Uniquesql = @DeletePart;
        END;
        
        SET @Uniquesql = @Uniquesql + @WherePart;
        
        FETCH FROM cur_UniqueIndex 
        INTO @IndexName, @DeletePart, @WherePart;
      END;
      
      -------------------------------------------------------------------------
      -- clean up cursor
      -------------------------------------------------------------------------
      CLOSE cur_UniqueIndex;
      DEALLOCATE cur_UniqueIndex;
      
      -------------------------------------------------------------------------
      -- update index sql
      -------------------------------------------------------------------------
      IF (@IndexName IS NOT NULL)
      BEGIN
        SET @SQL = ISNULL(@Uniquesql + CHAR(13), '') + @SQL;
        SET @IndexName = NULL;
      END;
      
      -------------------------------------------------------------------------
      -- special handling for DynaValue.GridRowID
      -------------------------------------------------------------------------
      IF (@RowIDColumnName IN ('BaPersonID', 'FaLeistungID') AND 
          @fTableName = 'DynaValue' AND 
          @fColumnName = 'FaLeistungID')
      BEGIN
        IF (@DebugOn = 1)
        BEGIN
          PRINT ('Info: <SpecialHandlingDynaValue>');
          PRINT ('Info: @RowIDColumnName = "' + @RowIDColumnName + '", @RowID = "' + CONVERT(VARCHAR(50), @RowID) + '", @RowID_Delete = "' + CONVERT(VARCHAR(50), @RowID_Delete) + '"');
        END;
        
        -----------------------------------------------------------------------
        -- we need to change GridRowID to prevent duplicate entries 
        --   after merging with other data
        -----------------------------------------------------------------------
        -- init vars
        DECLARE @TmpLeiDyvDymMapping TABLE
        (
          FaLeistungID INT NOT NULL,
          MaskName VARCHAR(100) NOT NULL,
          MaxGridRowID INT NOT NULL
        );
        
        -----------------------------------------------------------------------
        -- fill temp table
        -----------------------------------------------------------------------
        IF (@RowIDColumnName = 'BaPersonID')
        BEGIN
          ---------------------------------------------------------------------
          -- the given @RowID is a BaPersonID
          ---------------------------------------------------------------------
          INSERT INTO @TmpLeiDyvDymMapping (FaLeistungID, MaskName, MaxGridRowID)
            SELECT DYV.FaLeistungID, DYF.MaskName, MAX(DYV.GridRowID)
            FROM dbo.DynaValue          DYV WITH (READUNCOMMITTED)
              INNER JOIN dbo.DynaField  DYF WITH (READUNCOMMITTED) ON DYF.DynaFieldID = DYV.DynaFieldID
              INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = DYV.FaLeistungID
                                                                  AND LEI.BaPersonID = @RowID  -- the BaPersonID to keep
            GROUP BY DYV.FaLeistungID, DYF.MaskName;
        END
        ELSE IF (@RowIDColumnName = 'FaLeistungID')
        BEGIN
          ---------------------------------------------------------------------
          -- the given @RowID is a FaLeistungID
          ---------------------------------------------------------------------
          INSERT INTO @TmpLeiDyvDymMapping (FaLeistungID, MaskName, MaxGridRowID)
            SELECT FaLeistungID, MaskName, MAX(GridRowID)
            FROM dbo.DynaValue          DYV WITH (READUNCOMMITTED)
              INNER JOIN dbo.DynaField  DYF WITH (READUNCOMMITTED) ON DYF.DynaFieldID = DYV.DynaFieldID
            WHERE DYV.FaLeistungID = @RowID   -- the FaLeistungID to keep
            GROUP BY FaLeistungID, MaskName;
        END;
        
        -----------------------------------------------------------------------
        -- check first and then update the DynaValue.GridRowID to 
        --   MaxGridRowID + GridRowID of the rows to migrate to other FaLeistungID
        -----------------------------------------------------------------------
        IF (EXISTS (SELECT TOP 1 1
                    FROM @TmpLeiDyvDymMapping))
        BEGIN
          /*
          -- TODO: We need more filter criteria and cannot auto-match FaLeistungID source vs. target as it is done for FaLeistungID
          IF (@RowIDColumnName = 'BaPersonID')
          BEGIN
            -------------------------------------------------------------------
            -- update DynaValue.GridRowID (the given @RowID_Delete is a BaPersonID)
            -------------------------------------------------------------------
            UPDATE DYV
            SET DYV.GridRowID = ISNULL(TMP.MaxGridRowID, 0) + DYV.GridRowID
            FROM dbo.DynaValue          DYV
              INNER JOIN dbo.DynaField  DYF WITH (READUNCOMMITTED) ON DYF.DynaFieldID = DYV.DynaFieldID
              INNER JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = DYV.FaLeistungID
                                                                  AND LEI.BaPersonID = @RowID_Delete  -- the BaPersonID to delete
              --
              LEFT JOIN @TmpLeiDyvDymMapping TMP                   ON TMP.FaLeistungID = DYV.FaLeistungID  -- << this won't find any rows and therefore has no effect
                                                                  AND TMP.MaskName = DYF.MaskName;
            
            SET @RowCount = @@ROWCOUNT;
            
            -- debug
            IF (@DebugOn = 1)
            BEGIN
              PRINT ('Info: Updated "' + CONVERT(VARCHAR(50), @RowCount) + '" rows in DynaValue of BaPersonID = "' + CONVERT(VARCHAR(50), @RowID_Delete) + '"');
            END;
          END
          ELSE 
          */
          IF (@RowIDColumnName = 'FaLeistungID')
          BEGIN
            -------------------------------------------------------------------
            -- update DynaValue.GridRowID (the given @RowID_Delete is a FaLeistungID)
            -------------------------------------------------------------------
            UPDATE DYV
            SET DYV.GridRowID = ISNULL(TMP.MaxGridRowID, 0) + DYV.GridRowID
            FROM dbo.DynaValue          DYV
              INNER JOIN dbo.DynaField  DYF WITH (READUNCOMMITTED) ON DYF.DynaFieldID = DYV.DynaFieldID
              --
              LEFT JOIN @TmpLeiDyvDymMapping TMP                   ON TMP.FaLeistungID = @RowID   -- the FaLeistungID to keep
                                                                  AND TMP.MaskName = DYF.MaskName
            WHERE DYV.FaLeistungID = @RowID_Delete;                                                   -- the FaLeistungID to delete
            
            SET @RowCount = @@ROWCOUNT;
            
            -- debug
            IF (@DebugOn = 1)
            BEGIN
              PRINT ('Info: Updated "' + CONVERT(VARCHAR(50), @RowCount) + '" rows in DynaValue of FaLeistungID = "' + CONVERT(VARCHAR(50), @RowID_Delete) + '"');
            END;
          END;
        END
        ELSE
        BEGIN
          -- debug
          IF (@DebugOn = 1)
          BEGIN
            PRINT ('Info: Temp table @TmpLeiDyvDymMapping is empty');
          END;
        END;
        -----------------------------------------------------------------------
        
        IF (@DebugOn = 1)
        BEGIN
          PRINT ('Info: </SpecialHandlingDynaValue>');
        END;
      END;
      
      -------------------------------------------------------------------------
      -- move data from to-delete-FK to to-keep-FK
      -------------------------------------------------------------------------
      IF (@DebugOn = 1)
      BEGIN
        PRINT @SQL;
      END;
      
      -- do it
      EXECUTE(@SQL);
      
      FETCH FROM cur_SQLText 
      INTO @fTableName, @fColumnName, @SQL;
    END;

    ---------------------------------------------------------------------------
    -- clean up cursor
    ---------------------------------------------------------------------------
    CLOSE cur_SQLText;
    DEALLOCATE cur_SQLText;
    
    ---------------------------------------------------------------------------
    -- update FaFallID with new BaPersonID
    ---------------------------------------------------------------------------
    IF (@TableName = 'BaPerson' 
        AND EXISTS (SELECT TOP 1 1 
                    FROM sysobjects 
                    WHERE name = 'FaFall' 
                      AND xtype = 'V'))
    BEGIN
      UPDATE LEI
      SET LEI.FaFallID = @RowID
      FROM dbo.FaLeistung LEI
      WHERE LEI.FaFallID = @RowID_Delete;
      
      IF (EXISTS (SELECT TOP 1 1 
                  FROM dbo.FaLeistung 
                  WHERE FaLeistungID = @FaLeistungDel 
                    AND FaProzessCode = 700))
      BEGIN
        DELETE LEI
        FROM dbo.FaLeistung LEI
        WHERE LEI.FaLeistungID = @FaLeistungDel;
      END;
    END;
    
    ---------------------------------------------------------------------------
    -- delete row
    ---------------------------------------------------------------------------
    IF (@DeleteRow = 1)
    BEGIN
      DECLARE @SchemaName VARCHAR(50);
      SELECT @SchemaName = OBJECT_SCHEMA_NAME(object_id)
      FROM sys.tables T
      WHERE name = @TableName;

      SET @SQL = 'DELETE FROM [' + @SchemaName + '].[' + @TableName + '] WHERE [' + @PKeyName + '] = ' + CONVERT(VARCHAR, @RowID_Delete);
      
      IF (@DebugOn = 1)
      BEGIN
        PRINT @SQL;
      END;
      
      -- do it
      EXECUTE (@SQL);
    END;
  END; -- [IF (@PKeyName IS NOT NULL)]
END;
GO