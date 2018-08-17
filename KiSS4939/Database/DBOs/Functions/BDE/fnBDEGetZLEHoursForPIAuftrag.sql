SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetZLEHoursForPIAuftrag;
GO

-------------------------------------------------------------------------------
-- setup properties because of indexed view usage
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER ON;
GO

/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get hours in table BDELeistung for given person, PI-Auftrag and date-span
   @BaPersonID:                       The client BaPersonID to use for filtering
   @BDELeistungsartAuswPIAuftragCode: The code for the specific module (LOV='BDELeistungsartAuswPIAuftrag') where
                                      14=IEBI, ...
   @ZeitraumVon:                      The start date for date-span
   @ZeitraumBis:                      The end date for date-span
  -
  RETURNS: Amount of hours for given parameters, if no hours 0.0, if error -1.0
=================================================================================================
  TEST:    SELECT dbo.fnBDEGetZLEHoursForPIAuftrag(2, 14, '2009-01-01', '2009-02-01');
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetZLEHoursForPIAuftrag
(
  @BaPersonID INT,
  @BDELeistungsartAuswPIAuftragCode INT,
  @ZeitraumVon DATETIME,
  @ZeitraumBis DATETIME
)
RETURNS MONEY
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@BaPersonID IS NULL OR @BDELeistungsartAuswPIAuftragCode IS NULL OR @ZeitraumVon IS NULL OR @ZeitraumBis IS NULL)
  BEGIN
    -- invalid data
    RETURN -1.0;
  END;
  
  -----------------------------------------------------------------------------
  -- init var
  -----------------------------------------------------------------------------
  DECLARE @Hours MONEY;
  
  -----------------------------------------------------------------------------
  -- get hours
  -----------------------------------------------------------------------------
  SELECT @Hours = SUM(ISNULL(LEI.Dauer, 0.0))
  FROM dbo.BDELeistung             LEI WITH (READUNCOMMITTED)
    INNER JOIN dbo.BDELeistungsart BLA WITH (READUNCOMMITTED) ON BLA.BDELeistungsartID = LEI.BDELeistungsartID
                                                             AND BLA.AuswPIAuftragCode = @BDELeistungsartAuswPIAuftragCode   -- filter by PI-Auftrag-Code
  WHERE LEI.BaPersonID = @BaPersonID
    AND LEI.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis;
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@Hours, 0.0);
END;
GO