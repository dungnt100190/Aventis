SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetZLEHoursForModule;
GO

-------------------------------------------------------------------------------
-- setup properties because of indexed view usage
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER ON;
GO

/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get hours in table BDELeistung for given person, Module and date-span
   @BaPersonID:             The client BaPersonID to use for filtering
   @AuswDienstleistungCode: The code for the specific module (LOV='BDELeistungsartAuswDienstleistung') where
                            0=SB, 1=CM, 2=BW, 3=ED, ...
   @ZeitraumVon:            The start date for date-span
   @ZeitraumBis:            The end date for date-span
  -
  RETURNS: Amount of hours for given parameters, if no hours 0.0, if error -1.0
=================================================================================================
  TEST:    SELECT dbo.fnBDEGetZLEHoursForModule(2, 0, '2009-01-01', '2009-02-01');
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetZLEHoursForModule
(
  @BaPersonID INT,
  @AuswDienstleistungCode INT,
  @ZeitraumVon DATETIME,
  @ZeitraumBis DATETIME
)
RETURNS MONEY
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@BaPersonID IS NULL OR @AuswDienstleistungCode IS NULL OR @ZeitraumVon IS NULL OR @ZeitraumBis IS NULL)
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
  SELECT @Hours = SUM(ISNULL(VIW.DauerSUM, 0.0))
  FROM dbo.vwIxBDELeistung_BDELeistungsart_AuswDLCode VIW WITH (NOEXPAND)
  WHERE VIW.BaPersonID = @BaPersonID 
    AND VIW.Datum BETWEEN @ZeitraumVon AND @ZeitraumBis
    AND VIW.AuswDienstleistungCode = @AuswDienstleistungCode; -- filter by module
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN ISNULL(@Hours, 0.0);
END;
GO