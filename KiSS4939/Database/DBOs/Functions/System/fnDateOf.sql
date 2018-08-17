SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnDateOf;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Convert datetime to date only
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @DateValue: The date to use for cutting time
  -
  RETURNS: Datetime value without any time (e.g. "<Date> 00:00:00.000")
=================================================================================================
  TEST:    SELECT dbo.fnDateOf(GETDATE());
=================================================================================================*/

CREATE FUNCTION dbo.fnDateOf
(
  @DateValue DATETIME
)
RETURNS DATETIME WITH SCHEMABINDING
AS 
BEGIN
  RETURN (CONVERT(DATETIME, CONVERT(VARCHAR, @DateValue, 112), 112));
END;
GO