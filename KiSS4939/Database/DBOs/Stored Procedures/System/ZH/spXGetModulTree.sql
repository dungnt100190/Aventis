SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXGetModulTree
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
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
  DECLARE @Username      varchar(200),
          @PersonName    varchar(200),
          @ModulName     varchar(100),
          @LanguageName  varchar(100)

  SELECT @Username = LastName + IsNull(', ' + FirstName, '') FROM dbo.XUser    WITH (READUNCOMMITTED) WHERE UserID = @UserID
  SELECT @PersonName = Name + IsNull(', ' + Vorname, '')     FROM dbo.BaPerson WITH (READUNCOMMITTED) WHERE BaPersonID = @BaPersonID
  SELECT @ModulName = Name                                   FROM dbo.XModul   WITH (READUNCOMMITTED) WHERE ModulID = @ModulID
  SELECT @LanguageName = Text                                FROM dbo.XLOVCode WITH (READUNCOMMITTED) WHERE LOVName = 'Sprache' AND Code = @LanguageCode

  PRINT '-------------------------------------------------------------------------- '
  PRINT '-- spXGetModulTree @UserID, @BaPersonID, @FaFallID, @ModulID, @LanguageCode, @BfsMode '
  PRINT '--   @UserID       = ' + CONVERT(varchar, @UserID)       + IsNull(' (' + @Username + ')', ' ???')
  PRINT '--   @BaPersonID   = ' + CONVERT(varchar, @BaPersonID)   + IsNull(' (' + @PersonName + ')', ' ???')
  PRINT '--   @FaFallID     = ' + IsNull(CONVERT(varchar, @FaFallID), 'NULL')
  PRINT '--   @ModulID      = ' + CONVERT(varchar, @ModulID)      + IsNull(' (' + @ModulName + ')', ' ???')
  PRINT '--   @LanguageCode = ' + CONVERT(varchar, @LanguageCode) + IsNull(' (' + @LanguageName + ')', ' ???')
  PRINT '--   @BfsMode      = ' + CONVERT(varchar, @BfsMode)
  PRINT '-------------------------------------------------------------------------- '
  PRINT ' '

  SET NOCOUNT ON

  DECLARE @Tree TABLE (
    ID           INT IDENTITY(1, 1) NOT NULL,
    ModulTreeID  int PRIMARY KEY,
    UserHasRight bit NOT NULL
  )

  INSERT INTO @Tree (ModulTreeID, UserHasRight)
    SELECT ModulTreeID, dbo.fnUserHasRight(@UserID, MTR.ClassName)
    FROM dbo.XModulTree  MTR WITH (READUNCOMMITTED)
    WHERE MTR.ModulID = @ModulID AND MTR.ModulTreeID_Parent IS NULL
      AND MTR.Active = 1
    ORDER BY MTR.SortKey, MTR.ModulTreeID

  WHILE (@@RowCount > 0) BEGIN
    INSERT INTO @Tree (ModulTreeID, UserHasRight)
      SELECT MTR.ModulTreeID, CASE WHEN TRE.UserHasRight = 1 THEN dbo.fnUserHasRight(@UserID, MTR.ClassName) ELSE 0 END
      FROM @Tree               TRE
        INNER JOIN dbo.XModulTree  MTR WITH (READUNCOMMITTED) ON MTR.ModulID = @ModulID AND MTR.ModulTreeID_Parent = TRE.ModulTreeID
      WHERE MTR.Active = 1 AND NOT EXISTS (SELECT * FROM @Tree WHERE ModulTreeID = MTR.ModulTreeID)
      ORDER BY TRE.ID, MTR.SortKey, MTR.ModulTreeID
  END


  CREATE TABLE #Tree (
    PKey            int IDENTITY (1, 1) PRIMARY KEY,
    ModulTreeID     int NOT NULL,
    ID              varchar(2000) COLLATE DATABASE_DEFAULT NOT NULL,
    ParentID        varchar(2000) COLLATE DATABASE_DEFAULT,
    IconID          int,
    Name            varchar(500) COLLATE DATABASE_DEFAULT,
    BaPersonID      int,
    FaFallID        int,
    FaLeistungID    int,
    EditMask        varchar(4)
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
      CASE WHEN TRE.UserHasRight = 1 THEN IsNull(XLC.Value1 + ' ', '') + IsNull(MTR.sqlInsertTreeItem, '') ELSE NULL END
    FROM dbo.XModulTree         MTR WITH (READUNCOMMITTED)
      INNER JOIN @Tree      TRE ON TRE.ModulTreeID = MTR.ModulTreeID
      INNER JOIN dbo.XLOVCode   XLC WITH (READUNCOMMITTED) ON XLC.LOVName = 'ModulTree' AND XLC.Code = MTR.ModulTreeCode
      LEFT  JOIN dbo.XLangText  LAN WITH (READUNCOMMITTED) ON LAN.TID = MTR.NameTID AND LAN.LanguageCode = @LanguageCode
    WHERE TRE.UserHasRight = 1 OR MTR.sqlPreExecute IS NOT NULL
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

  -- EditMask
  DECLARE @FaLeistungID  int

  DECLARE cFaLeistung CURSOR FAST_FORWARD FOR
    SELECT DISTINCT FaLeistungID FROM #Tree

  OPEN cFaLeistung
  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cFaLeistung INTO @FaLeistungID
    IF @@FETCH_STATUS < 0 BREAK

    UPDATE TRE
      SET EditMask = 'R'
        + CASE WHEN ACL.Closed = 0 AND ACL.MayInsert = 1 THEN 'I' ELSE '' END
        + CASE WHEN ACL.Closed = 0 AND ACL.MayUpdate = 1 THEN 'U' ELSE '' END
        + CASE WHEN ACL.Closed = 0 AND ACL.MayDelete = 1 THEN 'D' ELSE '' END
    FROM #Tree                                  TRE,
      dbo.fnUserAccess(@UserID, @FaLeistungID)  ACL
    WHERE TRE.FaLeistungID = @FaLeistungID AND TRE.EditMask IS NULL
  END
  CLOSE cFaLeistung
  DEALLOCATE cFaLeistung

  UPDATE #Tree SET EditMask = 'RIUD' WHERE EditMask IS NULL


  SET NOCOUNT OFF

  SELECT TRE.*, DmgPersonID = TRE.BaPersonID,
    ClassName = IsNull(MTR.ClassName, CASE WHEN MTR.MaskName IS NOT NULL THEN 'CtlDynaMask' ELSE NULL END),
    MTR.MaskName
  FROM #Tree                     TRE
    LEFT  JOIN dbo.XModulTree        MTR WITH (READUNCOMMITTED) ON MTR.ModulTreeID = TRE.ModulTreeID
  ORDER BY TRE.PKey

  DROP TABLE #Tree
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
