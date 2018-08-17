SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIsUserBIAGAdmin
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnIsUserBIAGAdmin.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 13:40 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Check if user has biag-admin rights (XUser.IsUserBIAGAdmin)
   @UserID: The id of the user who shall be checked
  -
  RETURNS: True if user has biag-admin-rights, otherwise false
  -
  TEST:    SELECT dbo.fnIsUserBIAGAdmin(2)
           SELECT dbo.fnIsUserBIAGAdmin(222)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnIsUserBIAGAdmin.sql $
 * 
 * 2     17.03.10 13:40 Cjaeggi
 * Revised for coding rules
 * 
 * 1     31.08.09 12:45 Cjaeggi
 * #4394: Added new function for biag-admin
=================================================================================================*/

CREATE FUNCTION dbo.fnIsUserBIAGAdmin
(
  @UserID INT
)
RETURNS BIT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate userid
  -----------------------------------------------------------------------------
  SET @UserID = ISNULL(@UserID, -1);
  
  -----------------------------------------------------------------------------
  -- return value depending on current state
  -----------------------------------------------------------------------------
  IF (EXISTS(SELECT TOP 1 1 
             FROM dbo.XUser USR WITH (READUNCOMMITTED)
             WHERE USR.UserID = @UserID                   -- current user
               AND (USR.IsUserBIAGAdmin = 1)))            -- user is biag-admin
  BEGIN
    ---------------------------------------------------------------------------
    -- user is biag-admin
    ---------------------------------------------------------------------------
    RETURN 1;
  END;
  
  -----------------------------------------------------------------------------
  -- if we are here, the user is not biag-admin
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO
