SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnBDEGetSollProTag;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetSollProTag.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:23 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get Sollstunden per specified date.
    @UserID:  The user to get data from
    @Date:    The date the soll has to be calculated to.
  -
  RETURNS: Hours of Sollstunden for the specified date
  -
  TEST:    SELECT [dbo].[fnBDEGetSollProTag](2, '2007-9-1')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetSollProTag.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetSollProTag
(
  @UserID INT,
  @Date datetime
)
RETURNS MONEY
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not date is passed, invalid value
  IF (@Date IS NULL)
  BEGIN
    RETURN -1;
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
  DECLARE @Sollstunden MONEY;

  -----------------------------------------------------------------------------
  -- get Sollstunden
  ----------------------------------------------------------------------------- 
  SELECT @Sollstunden = SUM(SOL.SollStundenProTag)
  FROM dbo.BDESollProTag_XUser SOL WITH (READUNCOMMITTED)
  WHERE SOL.UserID = @UserID
    AND SOL.DatumVon <= @Date
    AND (SOL.DatumBis IS NULL OR SOL.DatumBis >= @Date);

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN ISNULL(@Sollstunden, -1);
END
GO