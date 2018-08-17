SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetAusbezahlteUeberstunden;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetAusbezahlteUeberstunden.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:13 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get Sollstunden per specified date.
    @UserID:          The user to get data from
    @Date:            The date the soll has to be calculated to.
    @OnlyCurrentYear: Get value only for current year or sum from beginning to and with current year
  -
  RETURNS: (+/-) hours of Sollstunden for the specified date
  -
  TEST:    SELECT [dbo].[fnBDEGetAusbezahlteUeberstunden](2, '2007-9-1', 0)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetAusbezahlteUeberstunden.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:52 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetAusbezahlteUeberstunden
(
  @UserID INT,
  @Date datetime,
  @OnlyCurrentYear BIT
)
RETURNS money
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@Date IS NULL)
  BEGIN
    RETURN -1
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @AusbezahlteUeberstunden money
  DECLARE @YearOfDate INT

  SET @YearOfDate = DatePart(YEAR, @Date)

  -----------------------------------------------------------------------------
  -- get ausbezahlte Ueberstunden
  ----------------------------------------------------------------------------- 
  SELECT @AusbezahlteUeberstunden = SUM(ABU.AusbezahlteStd)
  FROM dbo.BDEAusbezahlteUeberstunden_XUser ABU WITH (READUNCOMMITTED)
  WHERE ABU.UserID = @UserID AND
        ((@OnlyCurrentYear = 1 AND ABU.Jahr = @YearOfDate) OR (@OnlyCurrentYear = 0 AND ABU.Jahr <= @YearOfDate)) AND
        ABU.DatumVon <= (CASE WHEN ABU.Jahr < @YearOfDate THEN CONVERT(datetime, '31.12.'+CONVERT(varchar, ABU.Jahr), 104) ELSE @Date END) AND
        (ABU.DatumBis IS NULL OR ABU.DatumBis >= (CASE WHEN ABU.Jahr < @YearOfDate THEN CONVERT(datetime, '31.12.'+CONVERT(varchar, ABU.Jahr), 104) ELSE @Date END))

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN IsNull(@AusbezahlteUeberstunden, 0)
END
GO