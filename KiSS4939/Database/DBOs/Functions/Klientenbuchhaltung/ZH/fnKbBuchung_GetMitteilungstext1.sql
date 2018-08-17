SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnKbBuchung_GetMitteilungstext1
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Mitteilungstexte bestimmen 
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnKbBuchung_GetMitteilungstext1
(
  -- Fallnummer
  @FaFallID INT,
  -- Name der Person (bei Alim = Gläubiger)
  @PersonName VARCHAR(200)
)
RETURNS VARCHAR(35)
AS BEGIN
  RETURN LEFT('F' + CAST(@FaFallID AS VARCHAR) + ' ' + @PersonName, 35)
END
GO