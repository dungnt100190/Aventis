SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spCheckOutIn
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spCheckOutIn.sql $
  $Author: Lloreggia $
  $Modtime: 6.01.10 18:16 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Stored Procedures/System/spCheckOutIn.sql $
 * 
 * 2     6.01.10 18:21 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:54 Aklopfenstein
 * 
 * 1     3.09.08 11:13 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

-- CheckOut oder CheckIn alle Masken
CREATE PROCEDURE dbo.spCheckOutIn
(
  @bitCheckOut BIT
)
AS BEGIN
  -- declare vars
  DECLARE @intUserId INT
  DECLARE @dtmDate datetime

  -- set vars
  IF(@bitCheckOut = 1)
  BEGIN
    -- userid
    SELECT TOP 1 @intUserId=UserID
    FROM dbo.XUser WITH (READUNCOMMITTED)
    WHERE LogonName = 'cjaeggi'

    -- date
    SET @dtmDate = GetDate()
END
ELSE
BEGIN
    SET @intUserId = NULL
    SET @dtmDate = NULL
END

-- uddate XClass
UPDATE dbo.XClass
SET CheckOut_UserID = @intUserId,
    CheckOut_Date = @dtmDate
END
GO