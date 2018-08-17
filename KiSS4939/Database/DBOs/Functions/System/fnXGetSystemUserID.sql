SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnXGetSystemUserID;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnXGetSystemUserID.sql $
  $Author: Cjaeggi $
  $Modtime: 14.05.10 10:21 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Get the XUser.UserID for the biag system admin user.
  -
  RETURNS: The id of the biag system admin user or NULL if the user was not found.
  -
  TEST:    SELECT dbo.fnXGetSystemUserID();
=================================================================================================
  WARNING: This object is shared in Visual SourceSafe, beware of changes!
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnXGetSystemUserID.sql $
 * 
 * 3     14.05.10 10:23 Cjaeggi
 * Updated sys-admin user to fix display name
 * 
 * 2     13.05.10 16:16 Rstahel
 * System-User so umbenannt, dass DisplayText einen kurzen und klaren
 * Namen wiedergibt.
 * 
 * 1     3.05.10 10:14 Cjaeggi
 * Create new system user and function
=================================================================================================*/

CREATE FUNCTION dbo.fnXGetSystemUserID
()
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @UserID INT;
  SET @UserID = NULL;
  
  -----------------------------------------------------------------------------
  -- get the userid
  -----------------------------------------------------------------------------
  SELECT @UserID = USR.UserID
  FROM dbo.XUser USR WITH (READUNCOMMITTED)
  WHERE USR.LogonName = 'kiss_sys';     -- static logonname
  
  -----------------------------------------------------------------------------
  -- done, return id (NULL means error for calling script)
  -----------------------------------------------------------------------------
  RETURN @UserID;
END;
GO
