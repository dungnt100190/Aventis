SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetPensumPercent;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetPensumPercent.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:23 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get Pensum as percent value (0-100) for user and date
    @UserID: The user to get data from
    @Date:   The date the Pensum has to be calculated to.
  -
  RETURNS: Pensum percents as 0-100 value
  -
  TEST:    SELECT [dbo].[fnBDEGetPensumPercent](2, '2007-9-1')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetPensumPercent.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetPensumPercent
(
  @UserID INT,
  @Date datetime
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@Date IS NULL)
  BEGIN
    RETURN 0;
  END;

  -- Austrittsdatum berücksichtigen
  DECLARE @Austrittsdatum DATETIME;

  SELECT @Austrittsdatum = dbo.fnLastDayOf(Austrittsdatum)
  FROM dbo.XUser WITH(READUNCOMMITTED)
  WHERE UserID = @UserID;

  IF (@Austrittsdatum IS NOT NULL AND @Austrittsdatum < @Date)
  BEGIN
    RETURN 0;
  END;

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @PensumPercent INT;

  -----------------------------------------------------------------------------
  -- get Sollstunden
  ----------------------------------------------------------------------------- 
  SELECT @PensumPercent = SUM(PEN.PensumProzent)
  FROM dbo.BDEPensum_XUser PEN WITH (READUNCOMMITTED)
  WHERE PEN.UserID = @UserID
    AND PEN.DatumVon <= @Date
    AND (PEN.DatumBis IS NULL OR PEN.DatumBis >= @Date);

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN ISNULL(@PensumPercent, 0);
END
GO