SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXMonat;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the name of the desired month as varchar in long format
    @MonthNr: The number of the month (e.g. 1=January)
  -
  RETURNS: The name of the desired month as varchar in long format
=================================================================================================
TEST:    SELECT dbo.fnXMonat(1);
         SELECT dbo.fnXMonat(2);
         SELECT dbo.fnXMonat(12);
=================================================================================================*/

CREATE FUNCTION dbo.fnXMonat
(
  @MonthNr INT
)
RETURNS VARCHAR(50)
AS
BEGIN
  RETURN dbo.fnXMonatML(@MonthNr, 1);
END;
GO