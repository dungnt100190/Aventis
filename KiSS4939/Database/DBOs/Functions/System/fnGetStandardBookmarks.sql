SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetStandardBookmarks
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get bookmarks used with table or view definition
    @LanguageCode: The language code used for multilanguage bookmarks
  -
  RETURNS: The bookmarks defined by table or view definition
  -
  TEST:    SELECT * FROM dbo.fnGetStandardBookmarks(1)
           SELECT * FROM dbo.fnGetStandardBookmarks(2)
           SELECT * FROM dbo.fnGetStandardBookmarks(3)
=================================================================================================*/

CREATE FUNCTION [dbo].[fnGetStandardBookmarks]
(
  @LanguageCode INT
)
RETURNS @Result TABLE 
(
  BookmarkName VARCHAR(200) COLLATE DATABASE_DEFAULT,
  DisplayName VARCHAR(200) COLLATE DATABASE_DEFAULT,
  Category VARCHAR(200) COLLATE DATABASE_DEFAULT,
  BookmarkCode INT,
  TableColumn VARCHAR(100) COLLATE DATABASE_DEFAULT,
  SQL VARCHAR(MAX) COLLATE DATABASE_DEFAULT,
  ReplaceCode VARCHAR(500) COLLATE DATABASE_DEFAULT,
  ColumnDisplayText VARCHAR(50) COLLATE DATABASE_DEFAULT
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- insert data into result table
  -----------------------------------------------------------------------------
  INSERT INTO @Result (BookmarkName, DisplayName, Category, BookmarkCode, TableColumn, SQL, ReplaceCode, ColumnDisplayText)
    SELECT BookmarkName      = BMO.BookmarkName + ISNULL(COL.ColumnName, SCL.Name),
           DisplayName       = dbo.fnGetMLTextByDefault(BMO.BookmarkNameTID, @LanguageCode, BMO.BookmarkName) +
                               COALESCE(dbo.fnGetMLTextByDefault(COL.DisplayTextTID, @LanguageCode, COL.DisplayText), COL.ColumnName, SCL.Name),
           Category          = dbo.fnGetMLTextByDefault(BMO.CategoryTID, @LanguageCode, BMO.Category),
           BookmarkCode      = BMO.BookmarkCode,
           TableColumn       = BMO.TableName,
           SQL               = BMO.SQL,
           ReplaceCode       = CASE
                                 WHEN COL.LOVName IS NULL THEN ISNULL(COL.ColumnName, SCL.Name)
                                 ELSE 'dbo.fnLOVMLText(''' + COL.LOVName + ''', ' + COL.ColumnName + ', ' + CONVERT(VARCHAR, @LanguageCode) + ')'
                               END,
           ColumnDisplayText = COALESCE(COL.DisplayText, COL.ColumnName, SCL.Name)
    FROM dbo.XBookmark           BMO WITH (READUNCOMMITTED)
      LEFT JOIN dbo.XModul       MOD WITH (READUNCOMMITTED) ON MOD.ModulID = BMO.ModulID
      LEFT JOIN sys.columns      SCL                        ON SCL.object_id = OBJECT_ID(BMO.TableName)
      LEFT JOIN dbo.XTableColumn COL WITH (READUNCOMMITTED) ON COL.TableName = BMO.TableName
                                                           AND COL.ColumnName = SCL.Name
    WHERE (BMO.AlwaysVisible = 1 OR MOD.ModulID IS NULL OR MOD.System = 1 OR MOD.Licensed = 1) -- filter: use only system and licensed modules
      AND SCL.object_id IS NOT NULL;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END

GO
