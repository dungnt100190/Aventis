SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXMonatJahr;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Gets the month and year as 'mmmm yyyy' from given datetime in german
    @Date:         The date to use for getting month and year
  -
  RETURNS: The month and year as 'mmmm yyyy' from given datetime in german
=================================================================================================
  TEST:    SELECT dbo.fnXMonatJahr(GETDATE());
=================================================================================================*/

CREATE FUNCTION dbo.fnXMonatJahr
(
  @Date DATETIME
)
RETURNS VARCHAR(50)
AS
BEGIN
  RETURN dbo.fnXMonatML(DATEPART(mm, @Date), 1) + ' ' + CONVERT(VARCHAR, DATEPART(YYYY, @Date));
END;
GO