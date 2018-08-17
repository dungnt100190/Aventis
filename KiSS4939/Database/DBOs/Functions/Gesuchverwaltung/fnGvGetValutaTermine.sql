SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGvGetValutaTermine;
GO
/*===============================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Konkateniert alle Valuta-Daten einer Auszahlungsposition.
=================================================================================================
  TEST:    SELECT dbo.fnGvGetValutaTermine(1, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnGvGetValutaTermine
(
  @GvAuszahlungPositionID INT,
  @Separator VARCHAR(5) = '  '
)
RETURNS VARCHAR(500)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- Initialize variables
  -----------------------------------------------------------------------------
  DECLARE @Result VARCHAR(500);
  SET @Result = '';
  SET @Separator = ISNULL(@Separator, '  ');  

  -----------------------------------------------------------------------------
  -- Concatenate dates
  -----------------------------------------------------------------------------
  SELECT @Result = @Result + CONVERT(VARCHAR, DAY(APV.Datum)) + '.' + CONVERT(VARCHAR, MONTH(APV.Datum)) + '.' + @Separator
  FROM dbo.GvAuszahlungPositionValuta APV WITH(READUNCOMMITTED)
  WHERE APV.GvAuszahlungPositionID = @GvAuszahlungPositionID
  ORDER BY APV.Datum ASC;

  -----------------------------------------------------------------------------
  -- Cut separator at the end
  -----------------------------------------------------------------------------
  SET @Result = SUBSTRING(@Result, 1, LEN(@Result) - LEN(@Separator));

  RETURN NULLIF(@Result, '');
END;
GO
