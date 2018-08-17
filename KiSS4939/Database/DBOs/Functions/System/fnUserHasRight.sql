SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnUserHasRight
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnUserHasRight.sql $
  $Author: Cjaeggi $
  $Modtime: 18.03.10 17:08 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Check if user has rights for given rightname and therefore can do special things
    @UserID:    The id of the user to check rights
    @RightName: The name of the right to check in table XRight or XClass
  -
  RETURNS: 1 if user has rights to given rightname, otherwise 0
  -
  TEST:    SELECT dbo.fnUserHasRight(2, 'ADZeiterfassungAdmin')
           SELECT dbo.fnUserHasRight(200, 'ADZeiterfassungAdmin')
           SELECT dbo.fnUserHasRight(333, 'ADZeiterfassungAdmin')
           --
           SELECT dbo.fnUserHasRight(333, NULL)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnUserHasRight.sql $
 * 
 * 3     18.03.10 17:09 Cjaeggi
 * Revised for coding rules
 * 
 * 2     1.10.09 14:28 Cjaeggi
 * #4394: BIAGAdmin has admin rights, use function call
 * 
 * 1     3.09.08 17:51 Aklopfenstein
=================================================================================================*/

CREATE FUNCTION dbo.fnUserHasRight
(
  @UserID INT,
  @RightName VARCHAR(100)
)
RETURNS BIT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@RightName IS NULL)
  BEGIN
    -- no rightname = user has rights
    RETURN 1;
  END;
  
  -----------------------------------------------------------------------------
  -- check if user is admin
  -----------------------------------------------------------------------------
  IF (dbo.fnIsUserAdmin(@UserID) = 1)
  BEGIN
    -- user is admin and therefore has all rights
    RETURN 1;
  END;
  
  -----------------------------------------------------------------------------
  -- check if user has rights
  -----------------------------------------------------------------------------
  IF (EXISTS(SELECT TOP 1 1
             FROM dbo.XUser_UserGroup UUG WITH (READUNCOMMITTED)
               INNER JOIN dbo.XUserGroup_Right UGR WITH (READUNCOMMITTED) ON UGR.UserGroupID = UUG.UserGroupID
               LEFT  JOIN dbo.XRight           RGT WITH (READUNCOMMITTED) ON RGT.RightID = UGR.RightID 
                                                                         AND RGT.RightName = @RightName
             WHERE UUG.UserID = @UserID 
               AND (UGR.ClassName = @RightName OR RGT.RightID IS NOT NULL)))
  BEGIN
    -- user has rights
    RETURN 1;
  END;
  
  -----------------------------------------------------------------------------
  -- if we are here, user has no rights to given rightname
  -----------------------------------------------------------------------------
  RETURN 0;
END;
GO
