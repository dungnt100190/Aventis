SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnIsUserAdmin
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnIsUserAdmin.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 13:38 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Check if user has admin rights (XUser.IsUserAdmin or XUser.IsUserBIAGAdmin)
   @UserID: The id of the user who shall be checked
  -
  RETURNS: True if user has admin-rights, otherwise false
  -
  TEST:    SELECT dbo.fnIsUserAdmin(2)
           SELECT dbo.fnIsUserAdmin(222)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnIsUserAdmin.sql $
 * 
 * 2     17.03.10 13:38 Cjaeggi
 * Revised for coding rules
 * 
 * 1     31.08.09 12:43 Cjaeggi
 * Added new function
=================================================================================================*/

CREATE FUNCTION dbo.fnIsUserAdmin
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
             WHERE USR.UserID = @UserID                                 -- current user
               AND (USR.IsUserAdmin = 1 OR USR.IsUserBIAGAdmin = 1)))   -- user is admin if normal-admin or biag-admin
  BEGIN
    ---------------------------------------------------------------------------
    -- user is admin
    ---------------------------------------------------------------------------
    RETURN 1;
  END;
  
  -----------------------------------------------------------------------------
  -- if we are here, the user is not admin
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO
