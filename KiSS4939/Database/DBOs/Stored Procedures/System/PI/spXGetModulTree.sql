SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXGetModulTree
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spXGetModulTree.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:11 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Build up the data to show within modul-tree (id, parentid, etc.) depending on given configurations within kiss
    @UserID:       The id of the user who wants to show the tree
    @BaPersonID:   The id of the person
    @FaFallID:     The id of the fall of the person
    @ModulID:      The modul id to use to show tree
    @LanguageCode: The language to use for labels
    @BfsMode:      0=default mode; 1=BFS-mode
  -
  RETURNS: The modultree to use
  -
  TEST:    EXEC dbo.spXGetModulTree 2, 200, 1, 2, 1, 0
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spXGetModulTree.sql $
 * 
 * 3     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 2     11.09.08 10:18 Cjaeggi
 * Anpassen der Beschreibung, Korrektur von dbo.XXX
 * 
 * 1     3.09.08 17:54 Aklopfenstein
 * 
 * 1     3.09.08 11:13 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE PROCEDURE dbo.spXGetModulTree
(
  @UserID       int,
  @BaPersonID   int,
  @FaFallID     int,
  @ModulID      int,
  @LanguageCode int = 1,
  @BfsMode      bit = 1
)
AS BEGIN
  DECLARE @UserName      varchar(200),
          @PersonName    varchar(200),
          @ModulName     varchar(100),
          @LanguageName  varchar(100)

  SELECT @UserName = LastName + IsNull(', ' + FirstName,'') FROM dbo.XUser    WITH (READUNCOMMITTED) WHERE UserID = @UserID
  SELECT @PersonName = Name + IsNull(', ' + Vorname,'')     FROM dbo.BaPerson WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID
  SELECT @ModulName = Name                                  FROM dbo.XModul   WITH (READUNCOMMITTED) WHERE ModulID = @ModulID
  SELECT @LanguageName = Text                               FROM dbo.XLOVCode WITH (READUNCOMMITTED) WHERE LOVName = 'Sprache' AND Code = @LanguageCode

  PRINT '-------------------------------------------------------------------------- '
  PRINT '-- spXGetModulTree @UserID, @BaPersonID, @FaFallID, @ModulID, @LanguageCode, @BfsMode '
  PRINT '--   @UserID       = ' + CONVERT(varchar, @UserID)       + IsNull(' (' + @UserName + ')', ' ???')
  PRINT '--   @BaPersonID   = ' + CONVERT(varchar, @BaPersonID)   + IsNull(' (' + @PersonName + ')', ' ???')
  PRINT '--   @FaFallID     = ' + IsNull(CONVERT(varchar, @FaFallID), 'NULL')
  PRINT '--   @ModulID      = ' + CONVERT(varchar, @ModulID)      + IsNull(' (' + @ModulName + ')', ' ???')
  PRINT '--   @LanguageCode = ' + CONVERT(varchar, @LanguageCode) + IsNull(' (' + @LanguageName + ')', ' ???')
  PRINT '--   @BfsMode      = ' + CONVERT(varchar, @BfsMode)
  PRINT '-------------------------------------------------------------------------- '
  PRINT ' '

  SET NOCOUNT ON

  DECLARE @Tree TABLE (ID INT IDENTITY(1, 1) NOT NULL, ModulTreeID int PRIMARY KEY)

  INSERT INTO @Tree (ModulTreeID)
    SELECT ModulTreeID
    FROM dbo.XModulTree WITH (READUNCOMMITTED) 
    WHERE ModulID = @ModulID AND ModulTreeID_Parent IS NULL
      AND Active = 1
    ORDER BY SortKey, ModulTreeID

  WHILE (@@RowCount > 0)
    INSERT INTO @Tree (ModulTreeID)
      SELECT MTR.ModulTreeID
      FROM @Tree               TRE
        INNER JOIN dbo.XModulTree  MTR WITH (READUNCOMMITTED) ON MTR.ModulID = @ModulID AND MTR.ModulTreeID_Parent = TRE.ModulTreeID
      WHERE Active = 1 AND dbo.fnUserHasRight(@UserID, MTR.ClassName) = 1
        AND NOT EXISTS (SELECT * FROM @Tree WHERE ModulTreeID = MTR.ModulTreeID)
      ORDER BY TRE.ID, MTR.SortKey, MTR.ModulTreeID


  CREATE TABLE #Tree (
    PKey            int IDENTITY (1, 1) PRIMARY KEY,
    ModulTreeID     int NOT NULL,
    ID              varchar(2000) COLLATE DATABASE_DEFAULT NOT NULL,
    ParentID        varchar(2000) COLLATE DATABASE_DEFAULT,
    IconID          int,
    Name            varchar(100) COLLATE DATABASE_DEFAULT,
    BaPersonID      int,
    FaFallID        int,
    FaLeistungID    int,
    Unique (ModulTreeID, PKey)
  )

  DECLARE @ModulTreeID         int,
          @ModulTreeID_Parent  int,
          @Name                varchar(255),
          @IconID              int,
          @ClassName           varchar(255),
          @FieldList           varchar(1000),
          @sqlPreExecute       nvarchar(4000),
          @sqlInsertTreeItem   nvarchar(4000)

  DECLARE cXModulTree CURSOR FAST_FORWARD FOR
    SELECT MTR.ModulTreeID, MTR.ModulTreeID_Parent, IsNull(LAN.Text, MTR.Name), MTR.XIconID, MTR.ClassName, MTR.sqlPreExecute,
      IsNull(XLC.Value1 + ' ', '') + IsNull(MTR.sqlInsertTreeItem, '')
    FROM dbo.XModulTree         MTR WITH (READUNCOMMITTED) 
      INNER JOIN @Tree      TRE ON TRE.ModulTreeID = MTR.ModulTreeID
      INNER JOIN dbo.XLOVCode   XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'ModulTree' AND XLC.Code = MTR.ModulTreeCode
      LEFT  JOIN dbo.XLangText  LAN WITH (READUNCOMMITTED) ON LAN.TID = MTR.NameTID AND LAN.LanguageCode = @LanguageCode
    ORDER BY TRE.ID

  OPEN cXModulTree
  WHILE (1 = 1) BEGIN
    FETCH NEXT FROM cXModulTree INTO @ModulTreeID, @ModulTreeID_Parent, @Name, @IconID, @ClassName, @sqlPreExecute, @sqlInsertTreeItem
    IF @@FETCH_STATUS < 0 BREAK

    IF @sqlPreExecute IS NOT NULL BEGIN
      SET @FieldList = NULL

      PRINT '********************************************'
      PRINT '* ' + @Name + ' (@sqlPreExecute)'
      PRINT '********************************************'
      PRINT @sqlPreExecute
      PRINT ' '

      EXECUTE sp_executesql @sqlPreExecute,
        N'@ModulTreeID int, @ModulTreeID_Parent int, @UserID int, @BaPersonID int, @FaFallID int, @ModulID int, @BfsMode bit, @DmgPersonID int, @ModulCode int',
        @ModulTreeID, @ModulTreeID_Parent, @UserID, @BaPersonID, @FaFallID, @ModulID, @BfsMode, @DmgPersonID = @BaPersonID, @ModulCode = @ModulID
    END

    IF @sqlInsertTreeItem IS NOT NULL AND RTrim(@sqlInsertTreeItem) <> '' BEGIN
      IF @FieldList IS NULL AND @sqlInsertTreeItem LIKE '%@FieldList%' BEGIN
        DECLARE @ColumnName  varchar(200)

        DECLARE cColumn CURSOR FAST_FORWARD FOR
          SELECT Name COLLATE DATABASE_DEFAULT
          FROM tempdb..syscolumns
          WHERE id = OBJECT_ID('tempdb..#Tree') AND colid > 6

        OPEN cColumn
        WHILE 1 = 1 BEGIN
          FETCH NEXT FROM cColumn INTO @ColumnName
          IF @@FETCH_STATUS < 0 BREAK

          SET @FieldList = IsNull(@FieldList, '') + ', TRE.' + @ColumnName
        END
        DEALLOCATE cColumn
      END

      IF @sqlInsertTreeItem LIKE '%@FieldList%'
        SET @sqlInsertTreeItem = REPLACE(@sqlInsertTreeItem, ', @FieldList', @FieldList)

      PRINT '********************************************'
      PRINT '* ' + @Name + ' (@sqlInsertTreeItem)'
      PRINT '********************************************'
      PRINT @sqlInsertTreeItem
      PRINT ' '

      EXECUTE sp_executesql @sqlInsertTreeItem,
        N'@ModulTreeID int, @ModulTreeID_Parent int, @UserID int, @BaPersonID int, @FaFallID int, @ModulID int, @BfsMode bit, @ClassName varchar(255), @IconID int, @Name varchar(255), @LanguageCode int, @DmgPersonID int, @ModulCode int',
        @ModulTreeID, @ModulTreeID_Parent, @UserID, @BaPersonID, @FaFallID, @ModulID, @BfsMode, @ClassName, @IconID, @Name, @LanguageCode, @DmgPersonID = @BaPersonID, @ModulCode = @ModulID
    END
  END
  CLOSE cXModulTree
  DEALLOCATE cXModulTree


  UPDATE TRE
    SET IconID = IsNull(TRE.IconID, MTR.XIconID),
        Name   = COALESCE(TRE.Name COLLATE DATABASE_DEFAULT, LAN.Text, MTR.Name)
  FROM #Tree               TRE
    INNER JOIN dbo.XModulTree  MTR WITH (READUNCOMMITTED) ON MTR.ModulTreeID IN (TRE.ModulTreeID, -TRE.ModulTreeID)
    LEFT  JOIN dbo.XLangText   LAN WITH (READUNCOMMITTED) ON LAN.TID = MTR.NameTID AND LAN.LanguageCode = @LanguageCode
  WHERE TRE.IconID IS NULL OR TRE.Name IS NULL

  SET NOCOUNT OFF

  SELECT TRE.*, DmgPersonID = TRE.BaPersonID,
    ClassName = IsNull(MTR.ClassName, CASE WHEN MTR.MaskName IS NOT NULL THEN 'CtlDynaMask' ELSE NULL END),
    MTR.MaskName,
    EditMask = CONVERT(varchar, CASE
      WHEN ARC.FaLeistungID IS NOT NULL
        AND (MTR.ClassName LIKE 'Ctl[A-Z][A-Z]Fall'
          OR MTR.ClassName LIKE 'Ctl[A-Z][A-Z]Leistung') THEN 'RI'  -- Archiviert (Ctl??Fall, Ctl??Leistung)
      WHEN ARC.FaLeistungID IS NOT NULL                  THEN 'R'   -- Archiviert
      WHEN LST.DatumBis IS NOT NULL
        AND (MTR.ClassName LIKE 'Ctl[A-Z][A-Z]Fall'
          OR MTR.ClassName LIKE 'Ctl[A-Z][A-Z]Leistung') THEN 'RIU' -- Abgeschlossen (Ctl??Fall, Ctl??Leistung)
      WHEN LST.DatumBis IS NOT NULL                      THEN 'R'   -- Abgeschlossen
      ELSE 'RIUD'
    END)
  FROM #Tree TRE
    LEFT JOIN dbo.XModulTree        MTR WITH (READUNCOMMITTED) ON MTR.ModulTreeID = TRE.ModulTreeID
    LEFT JOIN dbo.FaLeistung        LST WITH (READUNCOMMITTED) ON LST.FaLeistungID = TRE.FaLeistungID
    LEFT JOIN dbo.FaLeistungArchiv  ARC WITH (READUNCOMMITTED) ON ARC.FaLeistungID = LST.FaLeistungID AND ARC.CheckOut IS NULL
  ORDER BY TRE.PKey

  DROP TABLE #Tree
END
GO