SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetMLTextFromTable
GO
/*
  KiSS 4.0
  --------
  DB-Object: fnGetMLTextFromTable
  Branch   : KiSS_PROD
  BuildNr  : 1
  Datum    : 15.07.2008 17:25
*/
-- =====================================================================================
-- Author:      RH (R. Hesterberg)
-- Create date: 04.01.2008
-- Description: fnGetMLTextFromTable für Mehrsprachigkeit
-- =====================================================================================
-- History:
-- 21.01.2008 : RH : Koerrektur, dass bei leer Deutsch zurückgeliefert wird
-- =====================================================================================

CREATE FUNCTION dbo.fnGetMLTextFromTable (
  @TextLanguage1 varchar(2000),
  @TID INT,
  @LanguageCode INT)
RETURNS varchar(2000)
AS
BEGIN
  DECLARE @Result varchar(2000)
  IF @LanguageCode = 1 BEGIN
    -- Bei Deutsch soll der Originaltext aus der Tabelle geliefert werden
    SET @Result = @TextLanguage1
  END ELSE BEGIN
    -- Bei anderen Sprachen soll der Text aus der Tabelle XLangText geliefert werden
    SELECT TOP 1 @Result = Text FROM XLangText
    WHERE TID = @TID AND LanguageCode = @LanguageCode
    IF @Result IS NULL OR @Result = '' SET @Result = @TextLanguage1
  END
  RETURN @Result
END
 