-------------------------------------------------------------------------------
-- SRK-Leistungen löschen
-------------------------------------------------------------------------------
IF (OBJECT_ID('tempdb..#FaLeistungIDsToDelete') IS NULL)
BEGIN
  CREATE TABLE #FaLeistungIDsToDelete
  (
    ID INT IDENTITY(1,1) NOT NULL,
    FaLeistungID INT NOT NULL
  );
END;
GO

-------------------------------------------------------------------------------
-- TODO Insert
-------------------------------------------------------------------------------
DELETE FROM #FaLeistungIDsToDelete;

INSERT INTO #FaLeistungIDsToDelete (FaLeistungID)
  SELECT -123 UNION ALL
  SELECT -321;
GO

-- Löschen
DECLARE @DeleteStatements TABLE
(
  ID INT IDENTITY(1,1) NOT NULL,
  DeleteStatement VARCHAR(MAX)
);
DECLARE @FaLeistungID INT;
DECLARE @SQL NVARCHAR(MAX);
DECLARE @Count INT;
DECLARE @I INT;

SET @I = 1;
SELECT @Count = COUNT(1)
FROM #FaLeistungIDsToDelete;

WHILE (@I <= @Count)
BEGIN
  SELECT
    @FaLeistungID = FaLeistungID,
    @SQL = N''
  FROM #FaLeistungIDsToDelete
  WHERE ID = @I;

  INSERT INTO @DeleteStatements (DeleteStatement)
    EXEC dbo.spXGetDeleteStatements 'FaLeistung', @FaLeistungID, 0;

  DELETE FROM @DeleteStatements
  WHERE SUBSTRING(DeleteStatement, 1, 2) = '--';

  SELECT @SQL = @SQL + DeleteStatement + CHAR(13) + CHAR(10)
  FROM @DeleteStatements;

  -- Perform Delete
  INSERT INTO dbo.HistoryVersion(AppUser) VALUES (dbo.fnXGetSystemUserID());
  EXEC dbo.sp_executesql @SQL;

  SET @I = @I + 1;
END;
GO

DROP TABLE #FaLeistungIDsToDelete;
GO