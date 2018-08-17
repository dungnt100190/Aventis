SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXSetTableColumnText;
GO
/*===============================================================================================
  $Revision: 1$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY:  Fügt einen Datensatz in XTableColumn ein, falls keiner existiert und setzt die
            DisplayTextTID-Spalte mit der TID des lokalisierten Texts
  -
  RETURNS: 1, Falls ein Fehler aufgetreten ist, sonst 0
=================================================================================================
  TEST:    EXEC dbo.spXSetTableColumnText 'BaPerson', 'Vorname', 'Prénom', 2, 1, 1;
=================================================================================================*/

CREATE PROCEDURE dbo.spXSetTableColumnText
(
  @TableName VARCHAR(255),
  @ColumnName VARCHAR(255),
  @DisplayText VARCHAR(255),
  @LanguageCode INT = 1,
  @FieldCode INT = NULL,
  @ModulID INT = NULL
)
AS 
BEGIN
  SET NOCOUNT ON;

  IF (OBJECT_ID(@TableName) IS NULL)
  BEGIN
    PRINT ('DBO ' + @TableName + ' does not exist!');
    RETURN 1;
  END;

  IF (NOT EXISTS (SELECT TOP 1 1
                  FROM dbo.XTable WITH (READUNCOMMITTED)
                  WHERE TableName = @TableName))
  BEGIN
    INSERT INTO dbo.XTable (TableName, ModulID)
    VALUES (@TableName, @ModulID);
  END;

  DECLARE @TID INT;

  IF (NOT EXISTS (SELECT TOP 1 1
                  FROM dbo.XTableColumn WITH (READUNCOMMITTED)
                  WHERE TableName = @TableName
                    AND ColumnName = @ColumnName))
  BEGIN
    INSERT INTO dbo.XTableColumn (TableName, ColumnName, FieldCode)
    VALUES (@TableName, @ColumnName, @FieldCode);
  END
  ELSE BEGIN
    SELECT @TID = DisplayTextTID
    FROM dbo.XTableColumn WITH (READUNCOMMITTED)
    WHERE TableName = @TableName
      AND ColumnName = @ColumnName;
  END;

  DECLARE @WhereClause VARCHAR(255);
  SET @WhereClause = 'TableName = ''' + @TableName + ''' AND ColumnName = ''' + @ColumnName + '''';

  IF (@TID IS NULL)
  BEGIN
    EXEC @TID = dbo.spXSetMLText
      @TID = NULL,
      @LanguageCode = 1,
      @TableName = 'XTableColumn',
      @FieldName = 'DisplayText',
      @WhereClause = @WhereClause,
      @Text = @ColumnName,
      @NewText = @ColumnName;
  END;

  EXEC dbo.spXSetMLText
    @TID = @TID,
    @LanguageCode = @LanguageCode,
    @TableName = 'XTableColumn',
    @FieldName = 'DisplayText',
    @WhereClause = @WhereClause,
    @Text = @DisplayText,
    @NewText = @DisplayText;

  RETURN 0;
END;
GO
