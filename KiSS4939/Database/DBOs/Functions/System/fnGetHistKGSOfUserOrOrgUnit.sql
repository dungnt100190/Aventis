SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetHistKGSOfUserOrOrgUnit;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetHistKGSOfUserOrOrgUnit.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:09 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get historised users's member-orgunit KGS-value for specified date
   @UserID:                 The user to get data from (hist orgunit, hist number from hist orgunit)
   @Date:                   The date within the history to use 
   @OrgUnitID:              The orgunit to get value from
   @ReturnID:               1=The XOrgUnit.OrgUnitID will be return, otherwise the XOrgUnit.ItemName
   @ShowNonKGSButHSOrgUnit: 1=also HS (Hauptsitz) will be displayed, as it would be a KGS; 
                            0=only KGS will be handled (default setting and behaviour)
  -
  RETURNS: The default value to specified date, or NULL if invalid or not found
  INFO:    If we have a userid, we get orgunit from userid and a given orgunitid will not be handled
           If we have no userid but an orgunit, we get value from orgunit and userid will not be handled
  -
  TEST:    SELECT [dbo].[fnGetHistKGSOfUserOrOrgUnit](1419, '2008-03-08', NULL, 1, 0)
           1419 = Ohnemus Peter, Member in BS Amriswil (KGS Thurgau/Schaffhausen)
           -
           SELECT [dbo].[fnGetHistKGSOfUserOrOrgUnit](142, GETDATE(), NULL, 0, 0)
           SELECT [dbo].[fnGetHistKGSOfUserOrOrgUnit](142, GETDATE(), NULL, 0, 1)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetHistKGSOfUserOrOrgUnit.sql $
 * 
 * 4     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 3     20.02.09 9:41 Cjaeggi
 * Added more tests
 * 
 * 2     20.02.09 9:38 Cjaeggi
 * Added new parameter for HS
 * 
 * 1     21.01.09 10:02 Cjaeggi
 * First version
=================================================================================================*/

CREATE FUNCTION dbo.fnGetHistKGSOfUserOrOrgUnit
(
  @UserID INT,
  @Date DATETIME,
  @OrgUnitID INT,
  @ReturnID BIT,
  @ShowNonKGSButHSOrgUnit BIT
)
RETURNS VARCHAR(100)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not all values are passed, we cannot do anything
  IF (@Date IS NULL OR (@UserID IS NULL AND @OrgUnitID IS NULL))
  BEGIN
    RETURN NULL
  END
  
  -- set bits
  SET @ReturnID = ISNULL(@ReturnID, 0)
  SET @ShowNonKGSButHSOrgUnit = ISNULL(@ShowNonKGSButHSOrgUnit, 0)
  
   -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @HistMemberOrgUnitID INT
  DECLARE @HistKGSOrgUnitID INT
  DECLARE @ReturnValue VARCHAR(100)
  
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
      RETURN NULL
    END
  END
  
  -----------------------------------------------------------------------------
  -- get OrgUnitID or ItemName depending on mode
  -----------------------------------------------------------------------------
  -- get value from function
  SET @HistKGSOrgUnitID = dbo.fnOrgUnitHistoryHierarchyValue(@HistMemberOrgUnitID, @Date, 'kgsorgunitid')
  
  -- check if we also have to handle HS (only if KGS is empty)
  IF (ISNULL(@HistKGSOrgUnitID, -1) < 1 AND @ShowNonKGSButHSOrgUnit = 1)
  BEGIN
    -- current KGS is empty, check if HS can be found
    SET @HistKGSOrgUnitID = dbo.fnOrgUnitHistoryHierarchyValue(@HistMemberOrgUnitID, @Date, 'hsorgunitid')
  END
  
  -- check mode (id or name)
  IF (@ReturnID = 1)
  BEGIN
    -- get XOrgUnit.OrgUnitID from history value of KGS by date
    SET @ReturnValue = CONVERT(VARCHAR, @HistKGSOrgUnitID)
  END
  ELSE
  BEGIN
    -- get XOrgUnit.ItemName from history value of KGS by date
    SELECT @ReturnValue = ORG.ItemName
    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
    WHERE ORG.OrgUnitID = ISNULL(@HistKGSOrgUnitID, -1)
  END
  
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN @ReturnValue
END
GO
