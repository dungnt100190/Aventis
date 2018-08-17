SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetDBRowCreatorModifier
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/System/fnGetDBRowCreatorModifier.sql $
  $Author: Cjaeggi $
  $Modtime: 17.03.10 13:15 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get the tablerow-creator value for given userid as
           "LastName, FirstName (UserID)"
    @UserID: The id of the user to get creator-information
  -
  RETURNS: The creator information for new tablerow or "Nobody (-1)" in case of invalid userid passed
  -
  TEST:    SELECT dbo.fnGetDBRowCreatorModifier(2)
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/System/fnGetDBRowCreatorModifier.sql $
 * 
 * 4     17.03.10 13:15 Cjaeggi
 * Revised for coding rules, modified to fit changes from reto
 * 
 * 3     7.08.09 13:10 Cjaeggi
 * Renamed function to fnGetDBRowCreatorModifier
 * 
 * 2     7.08.09 13:05 Cjaeggi
 * Changed to fit new rules
 * 
 * 1     30.01.09 10:37 Cjaeggi
 * New function
=================================================================================================*/

CREATE FUNCTION dbo.fnGetDBRowCreatorModifier
(
  @UserID INT
)
RETURNS VARCHAR(255)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (ISNULL(@UserID, -1) < 1)
  BEGIN
    -- invalid value > return nobody text
    RETURN 'Nobody (-1)';
  END;
  
  -----------------------------------------------------------------------------
  -- return proper value for creator or modifier as defined
  -----------------------------------------------------------------------------
  RETURN dbo.fnGetLastFirstName(@UserID, NULL, NULL) + ' (' + CONVERT(VARCHAR, @UserID) + ')';
END;
