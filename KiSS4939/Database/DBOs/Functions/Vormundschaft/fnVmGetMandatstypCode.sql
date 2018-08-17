SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnVmGetMandatstypCode;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @ProduktID: .
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT dbo.fnVmGetMandatstypCode(1);
=================================================================================================*/

CREATE FUNCTION dbo.fnVmGetMandatstypCode
(
  @ProduktID INT
)
RETURNS INT
AS 
BEGIN
  DECLARE @MandatstypCode INT;
  
  -- Get the CODE from the LOV 'VmMandatstyp'
  SELECT TOP 1 
         @MandatstypCode = Code
  FROM dbo.XLOVCode WITH (READUNCOMMITTED)
  WHERE LOVName = 'VmMandatstyp'
    AND ',' + Value3 + ',' LIKE ',%' +
      CONVERT(VARCHAR, (SELECT CASE @ProduktID
                                 WHEN 1 THEN 3
                                 WHEN 2 THEN 2
                                 WHEN 3 THEN 3
                                 WHEN 4 THEN 4
                                 WHEN 5 THEN 5
                                 WHEN 6 THEN 5
                                 WHEN 7 THEN 4
                                 WHEN 8 THEN 6
                                 WHEN 9 THEN 6
                                 WHEN 10 THEN 4
                                 WHEN 11 THEN 2
                                 WHEN 12 THEN 2
                               END)) + '%,';
  
  RETURN @MandatstypCode;
END;
GO