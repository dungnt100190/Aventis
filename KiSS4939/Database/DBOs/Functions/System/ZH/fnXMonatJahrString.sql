SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnXMonatJahrString
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Bestimmt Angabe Monat im Format MM.YYYY für Buchungstexte
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION [dbo].[fnXMonatJahrString] (
  @Datum DATETIME
)
RETURNS VARCHAR(10)
AS BEGIN
  DECLARE  @Text VARCHAR(10)
  -- Monat erstellen
  SET @Text = CONVERT(VARCHAR(10), MONTH(@Datum))
  -- führende 0 erstellen
  IF LEN(@Text) = 1 SET @Text = '0' + @Text
  -- Jahr hinzufügen
  SET @Text = @Text + '.' + CONVERT(VARCHAR(4), YEAR(@Datum))
  RETURN @Text
END

GO