SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXGetBookmark;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Used to collect all bookmarks for word-/excel-addin (KissTextmarkenAddIn.dot/.xla)
  -
  RETURNS: All defined bookmarks found in database
  -
  TEST:    EXEC dbo.spXGetBookmark
           EXEC dbo.spXGetBookmark 2
=================================================================================================
=================================================================================================*/

CREATE PROCEDURE dbo.spXGetBookmark
(
  @LanguageCode INT = 1
)
AS BEGIN
  -------------------------------------------------------------------------------
  -- do not count rows
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -------------------------------------------------------------------------------
  -- init temporary table
  -------------------------------------------------------------------------------
  DECLARE @Bookmark TABLE 
  (
    Category      VARCHAR(100) NOT NULL,
    BookmarkName  VARCHAR(100) NOT NULL,
    DisplayName   VARCHAR(100) NOT NULL
  );
  
  -------------------------------------------------------------------------------
  -- insert data into temporary table
  -------------------------------------------------------------------------------
  -- custom bookmarks
  INSERT INTO @Bookmark (Category, BookmarkName, DisplayName)
    SELECT
      Category     = dbo.fnGetMLTextByDefault(XBM.CategoryTID, @LanguageCode, XBM.Category),
      BookmarkName = LEFT(XBM.BookmarkName, 40),
      DisplayName  = dbo.fnGetMLTextByDefault(XBM.BookmarkNameTID, @LanguageCode, LEFT(XBM.BookmarkName, 40))
    FROM dbo.XBookmark     XBM WITH (READUNCOMMITTED)
      LEFT JOIN dbo.XModul MOD WITH (READUNCOMMITTED) ON MOD.ModulID = XBM.ModulID
    WHERE (XBM.AlwaysVisible = 1 OR MOD.ModulID IS NULL OR MOD.System = 1 OR MOD.Licensed = 1) -- filter: use only system and licensed modules
      AND XBM.TableName IS NULL;
  
  -- default bookmarks using function
  INSERT INTO @Bookmark (Category, BookmarkName, DisplayName)
    SELECT
      Category     = GSB.Category,
      BookmarkName = LEFT(GSB.BookmarkName, 40),
      DisplayName  = GSB.DisplayName + ISNULL(' (' + GSB.ColumnDisplayText + ')', '')
    FROM dbo.fnGetStandardBookmarks(@LanguageCode) GSB;
  
  -- dynamask-bookmarks (only if supported)
  IF (OBJECT_ID('DynaField') IS NOT NULL AND OBJECT_ID('DynaMask') IS NOT NULL)
  BEGIN
    INSERT INTO @Bookmark (Category, BookmarkName, DisplayName)
      SELECT DISTINCT
        Category     = dbo.fnXDbObjectMLMsg('spXGetBookmark', 'EigeneTextmarken', @LanguageCode) + ISNULL(' - ' + MOD.Name, ''),
        BookmarkName = LEFT(FLD.FieldName, 40) + ' (' + FLT.Text + ')',
        DisplayName  = LEFT(FLD.FieldName, 40) + ' (' + FLT.Text + ')'
      FROM dbo.DynaMask          MSK WITH (READUNCOMMITTED)
        INNER JOIN dbo.DynaField FLD WITH (READUNCOMMITTED) ON FLD.MaskName = MSK.MaskName
        LEFT  JOIN dbo.XModul    MOD WITH (READUNCOMMITTED) ON MOD.ModulID = MSK.ModulID
        LEFT  JOIN dbo.XLOVCode  FLT WITH (READUNCOMMITTED) ON FLT.LOVName = 'EigenesFeld' 
                                                           AND FLT.Code = FLD.FieldCode
      WHERE (MOD.ModulID IS NULL OR MOD.System = 1 OR MOD.Licensed = 1) -- filter: use only system and licensed modules
        AND FLD.FieldCode NOT IN (1,12,13) 
        AND LEN(FLD.FieldName) > 1;
  END;
  
  -------------------------------------------------------------------------------
  -- output
  -------------------------------------------------------------------------------
  SELECT Category,
         BookmarkName,
         DisplayName
  FROM @Bookmark 
  ORDER BY Category, DisplayName;
END;
GO
---------------------------------------------------------------------------------
-- required grant call for bookmarks db-user
---------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
GRANT EXECUTE ON [dbo].[spXGetBookmark] TO [KiSS_BookmarksOnly];
GO