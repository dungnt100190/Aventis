SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnOrgUnitOfUserHistoryPerDate;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnOrgUnitOfUserHistoryPerDate.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:12 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get historised member orgunit for user and date
    @UserID:      The user to get data from
    @Date:        The date within the history to use 
  -
  RETURNS: The orgunit-id where the user was member on specified date, or -1 if invalid
  -
  TEST:    SELECT [dbo].[fnOrgUnitOfUserHistoryPerDate](2, '2008-03-10')
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnOrgUnitOfUserHistoryPerDate.sql $
 * 
 * 2     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 17:29 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnOrgUnitOfUserHistoryPerDate
(
  @UserID INT,
  @Date datetime
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- debug
  -----------------------------------------------------------------------------
  /*
  DECLARE @UserID INT
  DECLARE @Date DATETIME
  SET @UserID = 2
  SET @Date = '2008-02-25'
  */

  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not all values are passed, we cannot do anything
  IF (@Date IS NULL OR @UserID IS NULL)
  BEGIN
    RETURN -1
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @HistMemberOrgUnitID INT

  ---------------------------------------------------------------------------
  -- get hist-value from orgunit_user
  --   latest value is also in history, so we only have to check this table
  ---------------------------------------------------------------------------
  SELECT TOP 1 @HistMemberOrgUnitID = OUU.OrgUnitID
  FROM dbo.Hist_XOrgUnit_User OUU WITH (READUNCOMMITTED)
    INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = OUU.VerID
  WHERE OUU.UserID = @UserID AND -- only for user
        OUU.OrgUnitMemberCode = 2 AND -- member only
        DateAdd(d, 0, DateDiff(d, 0, HIS.VersionDate)) <= @Date
  ORDER BY HIS.VersionDate DESC, HIS.VerID DESC

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN IsNull(@HistMemberOrgUnitID, -1)
END
GO