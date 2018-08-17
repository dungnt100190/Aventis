SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spAdTranslationFields
GO
-- ===================================================================================================
-- Create date: 21.12.2007
-- Description:	StoredProceure für Übersetzungen von Tabellen
-- Tests      : EXEC dbo.spAdTranslationFields 1
-- ===================================================================================================
-- History:
-- 21.12.2007 : RH : neu
-- ===================================================================================================

CREATE PROCEDURE dbo.spAdTranslationFields (@Sprache INT) AS
BEGIN
  DECLARE
    @IconID INT,
    @IconID_Level0 INT,
    @IconID_Level1 INT,
    @TABLE varchar(50)
  DECLARE @Fields TABLE (
    ID varchar(200),
    ParentID varchar(200),
    Name varchar(200),
    TableName varchar(200),
    FieldName varchar(200),
    FieldNamePK varchar(200),
    IconID INT
  )
  -- ===========
  -- Modul Basis
  -- ===========
  SET @IconID_Level0 = 2513
  INSERT INTO @Fields (ID, ParentID, Name, IconID)
  VALUES ('BA', NULL, 'Basis', @IconID_Level0)

  -- BaGemeinde
  -- ----------
  SET @IconID_Level1 = 2513
  INSERT INTO @Fields (ID, ParentID, Name, TableName, IconID)
  VALUES ('BaGemeinde', 'BA', 'Gemeinden', 'BaGemeinde', @IconID_Level1)

  -- BaGemeinde.Name
  SELECT @IconID = CASE WHEN (
    SELECT COUNT(*) FROM BaGemeinde PA
    LEFT OUTER JOIN XLangText LT ON LT.TID = PA.NameTID AND LanguageCode = @Sprache
    WHERE LT.Text IS NULL OR LT.Text = ''
  ) > 0 THEN 2512 ELSE 2513 END
  IF @IconID = 2512 SET @IconID_Level0 = 2512
  IF @IconID = 2512 SET @IconID_Level1 = 2512
  INSERT INTO @Fields (ID, ParentID, Name, TableName, FieldName, FieldNamePK, IconID)
  VALUES ('BaGemeinde.Name', 'BaGemeinde', 'Name', 'BaGemeinde', 'Name', 'BaGemeindeID', @IconID)

  -- BaGemeinde.BezirkName
  SELECT @IconID = CASE WHEN (
    SELECT COUNT(*) FROM BaGemeinde PA
    LEFT OUTER JOIN XLangText LT ON LT.TID = PA.BezirkNameTID AND LanguageCode = @Sprache
    WHERE LT.Text IS NULL OR LT.Text = ''
  ) > 0 THEN 2512 ELSE 2513 END
  IF @IconID = 2512 SET @IconID_Level0 = 2512
  IF @IconID = 2512 SET @IconID_Level1 = 2512
  INSERT INTO @Fields (ID, ParentID, Name, TableName, FieldName, FieldNamePK, IconID)
  VALUES ('BaGemeinde.BezirkName', 'BaGemeinde', 'Bezirkname', 'BaGemeinde', 'BezirkName', 'BaGemeindeID', @IconID)



  -- =================
  -- Modul Sozialhilfe
  -- =================
  SET @IconID_Level0 = 2513
  INSERT INTO @Fields (ID, ParentID, Name, IconID)
  VALUES ('SH', NULL, 'Sozialhilfe', @IconID_Level0)

  -- BgPositionsart
  -- --------------
  SET @IconID_Level1 = 2513
  INSERT INTO @Fields (ID, ParentID, Name, TableName, IconID)
  VALUES ('BgPositionsart', 'SH', 'Budget Positionsarten', 'BgPositionsart', @IconID_Level1)

  -- BgPositionsart.Name
  SELECT @IconID = CASE WHEN (
    SELECT COUNT(*) FROM BgPositionsart PA
    LEFT OUTER JOIN XLangText LT ON LT.TID = PA.NameTID AND LanguageCode = @Sprache
    WHERE LT.Text IS NULL OR LT.Text = ''
  ) > 0 THEN 2512 ELSE 2513 END
  IF @IconID = 2512 SET @IconID_Level0 = 2512
  IF @IconID = 2512 SET @IconID_Level1 = 2512
  INSERT INTO @Fields (ID, ParentID, Name, TableName, FieldName, FieldNamePK, IconID)
  VALUES ('BgPositionsart.Name', 'BgPositionsart', 'Name', 'BgPositionsart', 'Name', 'BgPositionsartID', @IconID)

/*
  -- BgPositionsart.Bemerkung
  SELECT @IconID = CASE WHEN (
    SELECT COUNT(*) FROM BgPositionsart PA
    LEFT OUTER JOIN XLangText LT ON LT.TID = PA.BemerkungTID AND LanguageCode = @Sprache
    WHERE LT.Text IS NULL OR LT.Text = ''
  ) > 0 THEN 2512 ELSE 2513 END
  IF @IconID = 2512 SET @IconID_Level0 = 2512
  IF @IconID = 2512 SET @IconID_Level1 = 2512
  INSERT INTO @Fields (ID, ParentID, Name, TableName, FieldName, FieldNamePK, IconID)
  VALUES ('BgPositionsart.Bemerkung', 'BgPositionsart', 'Bemerkung', 'BgPositionsart', 'Bemerkung', 'BgPositionsartID', @IconID)
*/

  UPDATE @Fields SET IconID = @IconID_Level1 WHERE ID = 'BgPositionsart'
  UPDATE @Fields SET IconID = @IconID_Level0 WHERE ID = 'SH'


  -- Alles zurückgeben
  SELECT * FROM @Fields

END
 

GO
