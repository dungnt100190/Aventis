SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXSetMLText
GO
-- ===================================================================================================
-- Create date: 01.10.2008
-- Description:	StoredProceure f�r �bersetzungen
-- ===================================================================================================
-- History:
-- 01.01.2008 : RH : neu
-- 07.01.2008 : RH : neu wird XMessage nicht gef�llt
-- ===================================================================================================

CREATE PROCEDURE dbo.spXSetMLText (
  @TID INT,
  @LanguageCode INT,
  @TableName varchar(200),
  @FieldName varchar(200),
  @WhereClause varchar(200),
  @Text varchar(200),
  @NewText varchar(200)
) AS
BEGIN

  IF (@TID IS NULL)
  BEGIN
    -- Haupteintrag der �bersetzung existiert noch nicht, also neu einf�gen:
    INSERT INTO XLangText (LanguageCode, Text)
    VALUES (1, @Text);
    
    SET @TID = SCOPE_IDENTITY();
    
    -- Neuer TID in Originaltabelle speichern:
    DECLARE @SQL VARCHAR(200);
    SET @SQL = 'UPDATE ' + @TableName + ' SET ' + @FieldName + 'TID = ' + CONVERT(varchar, @TID) +
      ' WHERE ' + @WhereClause;
    EXECUTE sp_sqlExec @SQL;
  END;

  IF (NOT @TID IS NULL)
  BEGIN
    IF (EXISTS(SELECT TOP 1 1
               FROM XLangText
               WHERE TID = @TID AND LanguageCode = @LanguageCode))
    BEGIN
      -- �bersetzung existiert bereits, also nur updaten
      UPDATE XLangText SET Text = @NewText
      WHERE TID = @TID AND LanguageCode = @LanguageCode;
    END
    ELSE BEGIN
      -- �bersetzung existiert noch nicht, also neu einf�gen
      SET IDENTITY_INSERT XLangText ON;
      INSERT INTO XLangText (TID, LanguageCode, Text)
      VALUES (@TID, @LanguageCode, @NewText);
      SET IDENTITY_INSERT XLangText OFF;
    END;
  END;

  SELECT @TID AS TID;

  RETURN @TID;
END;
