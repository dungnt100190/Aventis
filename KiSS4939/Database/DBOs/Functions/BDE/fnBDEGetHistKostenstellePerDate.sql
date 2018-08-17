SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetHistKostenstellePerDate;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetHistKostenstellePerDate.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:18 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get historised default Kostenstelle for user and date
           Info: - If we have a userid, we get orgunit from userid and a given orgunitid will not be handled
                 - If we have no userid but an orgunit, we get kst from orgunit and userid will not be handled
    @UserID:      The user to get data from
    @Date:        The date within the history to use 
    @OrgUnitID:   The orgunit to get value from  
  -
  RETURNS: The default value to specified date, or -1 if invalid
  -
  TEST:    SELECT [dbo].[fnBDEGetHistKostenstellePerDate](2, '2008-01-28', NULL)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetHistKostenstellePerDate.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     18.09.08 12:07 Cjaeggi
 * Test-Statement, CaseFix
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetHistKostenstellePerDate
(
  @UserID INT,
  @Date DATETIME,
  @OrgUnitID INT
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not all values are passed, we cannot do anything
  IF (@Date IS NULL OR (@UserID IS NULL AND @OrgUnitID IS NULL))
  BEGIN
    RETURN -1
  END

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @Kostenstelle INT
  DECLARE @HistMemberOrgUnitID INT

  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  IF (@UserID IS NULL)
  BEGIN
    -- we have an orgunit, so we only get value from orgunit
    SET @HistMemberOrgUnitID = @OrgUnitID
  END
  ELSE
  BEGIN
    ---------------------------------------------------------------------------
    -- we have a userid, so get orgunit from hist-member-orgunit
    ---------------------------------------------------------------------------
    SET @HistMemberOrgUnitID = dbo.fnOrgUnitOfUserHistoryPerDate(@UserID, @Date)

    ---------------------------------------------------------------------------
    -- if we have no value for orgunit, we cannot get kst
    ---------------------------------------------------------------------------
    IF (@HistMemberOrgUnitID IS NULL)
    BEGIN
      -- return invalid value
      RETURN -1
    END
  END

  -----------------------------------------------------------------------------
  -- get value from history orgunit
  ----------------------------------------------------------------------------- 
  SELECT TOP 1 @Kostenstelle = ORG.Kostenstelle
  FROM dbo.Hist_XOrgUnit ORG WITH (READUNCOMMITTED)
    INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = ORG.VerID
  WHERE ORG.OrgUnitID = @HistMemberOrgUnitID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
  ORDER BY HIS.VersionDate DESC, HIS.VerID DESC

  -----------------------------------------------------------------------------
  -- check and return value
  ----------------------------------------------------------------------------- 
  RETURN ISNULL(@Kostenstelle, -1)
END
GO