SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnUserMayReadFall
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnUserMayReadFall.sql $
  $Author: Cjaeggi $
  $Modtime: 1.10.09 14:10 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: check if user has right to show FaLeistungID
    @UserID:       The UserID to check if user has rights to see FaLeistungID
    @FaLeistungID: The FaLeistungID to check rights for
  -
  RETURNS: If user has rights to see item, return will be = 1, else 0
  -
  TEST:    SELECT dbo.fnUserMayReadFall(2, 2222)
           SELECT dbo.fnUserMayReadFall(333, 2222)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Fallführung/fnUserMayReadFall.sql $
 * 
 * 4     1.10.09 14:11 Cjaeggi
 * #4394: BIAGAdmin has admin rights, use function call
 * 
 * 3     18.09.08 13:41 Cjaeggi
 * 
 * 2     18.09.08 13:32 Cjaeggi
 * Format
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 17:29 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnUserMayReadFall
(
  @UserID INT, 
  @FaLeistungID INT
)
RETURNS BIT
AS BEGIN
  -- check if user is admin
  IF (dbo.fnIsUserAdmin(@UserID) = 1)
  BEGIN
    -- user is admin and has right
    RETURN 1
  END
  
  -- user is not admin, declare vars and request leistung
  DECLARE @ModulID    	INT
  DECLARE @OwnerID      INT
  DECLARE @isUserGuest  BIT
  DECLARE @isUserMember BIT
  
  SELECT TOP 1
         @ModulID      = FAL.ModulID,
         @OwnerID      = FAL.UserID,
         @isUserGuest  = CASE WHEN FAZ.FaLeistungID IS NOT NULL THEN 1 
                              ELSE 0 
                         END,
         @isUserMember = CASE WHEN B.UserID IS NOT NULL THEN 1 
                              ELSE 0 
                         END
  FROM dbo.FaLeistung FAL WITH (READUNCOMMITTED)
    INNER JOIN dbo.XUser             USR WITH (READUNCOMMITTED) ON USR.UserID = FAL.UserID
    LEFT  JOIN dbo.FaLeistungZugriff FAZ WITH (READUNCOMMITTED) ON FAZ.FaLeistungID = FAL.FaLeistungID AND
                                                                   FAZ.UserID = @UserID
    LEFT  JOIN dbo.XOrgUnit_User     A   WITH (READUNCOMMITTED) ON A.UserID = FAL.UserID AND      -- Abteilung of Owner
                                                                   A.OrgUnitMemberCode = 2
    LEFT  JOIN dbo.XOrgUnit_User     B   WITH (READUNCOMMITTED) ON B.OrgUnitID = A.OrgUnitID AND  -- Abteilung of User
                                                                   B.UserID = @UserID
  WHERE FAL.FaLeistungID = @FaLeistungID
  
  -- check if user has rights
  IF (@OwnerID = @UserID OR @isUserGuest = 1 OR @isUserMember = 1)
  BEGIN
    -- user has right
    RETURN 1
  END
  
  -- no right
  RETURN 0
END
GO
