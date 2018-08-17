SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spCreateInsertForTableCopy;
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
  TEST:    EXECUTE dbo.spCreateInsertForTableCopy 'BaPerson', 'Hist_BaPerson', 1;
           EXECUTE dbo.spCreateInsertForTableCopy 'BaPersonX', 'Hist_BaPerson', 1;
           EXECUTE dbo.spCreateInsertForTableCopy 'BaPerson', 'Hist_BaPersonX', 1;
=================================================================================================*/

CREATE PROCEDURE dbo.spCreateInsertForTableCopy
(
  @SourceTable VARCHAR(100),
  @DestTable VARCHAR(100),
  @identity_insert BIT
)
AS
BEGIN
  IF (OBJECT_ID(@SourceTable) IS NULL)
  BEGIN
    PRINT ('Error: SourceTable "' + @SourceTable + '" does not exist!');
    RETURN;
  END;
  
  IF (OBJECT_ID(@DestTable) IS NULL)
  BEGIN
    PRINT ('Error: DestTable "' + @DestTable + '" does not exist!');
    RETURN;
  END;
  
  DECLARE @Sql VARCHAR(2000);
  DECLARE @ColList VARCHAR(1000);
  DECLARE @ColName VARCHAR(100);
  
  DECLARE cColumn CURSOR STATIC FOR 
    SELECT C1.Name
    FROM syscolumns         C1
      INNER JOIN sysobjects T1 ON T1.Id = C1.Id
    WHERE T1.Name = @SourceTable 
      AND EXISTS (SELECT TOP 1 1 
                  FROM syscolumns C2
                    INNER JOIN sysobjects T2 ON T2.Id = C2.Id
                  WHERE T2.Name = @DestTable 
                    AND C2.Name = C1.Name)
    ORDER BY C1.ColID;

  SET @ColList = '';
  
  OPEN cColumn
  FETCH NEXT 
  FROM cColumn 
  INTO @ColName
  
  WHILE (@@FETCH_STATUS = 0)
  BEGIN
    IF (@ColList <> '')
    BEGIN 
      SET @ColList = @ColList + ',' + CHAR(13) + CHAR(10) + '  ';
    END;
    
    SET @ColList = @ColList + @ColName;
    
    FETCH NEXT 
    FROM cColumn 
    INTO @ColName;
  END;
    
  CLOSE cColumn;
  DEALLOCATE cColumn;

  IF (@identity_insert = 1)
  BEGIN
    SET @Sql = 'SET IDENTITY_INSERT ' + @DestTable + ' ON' + CHAR(13) + CHAR(10);
  END
  ELSE
  BEGIN
    SET @Sql = '';
  END;

  SET @Sql = @Sql + 
             'INSERT INTO dbo.' + @DestTable + ' (' + @ColList + ') ' + CHAR(13) + CHAR(10) +
             '  SELECT ' + @ColList + CHAR(13) + CHAR(10) +
             '  FROM ' + @SourceTable + CHAR(13) + CHAR(10);

  IF (@identity_insert = 1)
  BEGIN
    SET @Sql = @Sql + 'SET IDENTITY_INSERT ' + @DestTable + ' OFF' + CHAR(13) + CHAR(10);
  END;
  
  SELECT @Sql;
END;
GO
