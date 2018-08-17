SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnOrgUnitHierarchyValue;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnOrgUnitHierarchyValue.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:11 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a hierarchical value upwards from orgunit
    @OrgUnitID:  ID of OrgUnit
    @FieldCode:  Type of information to get
                 ('sakto'=SammelkontoNr, 'mndnr'=MandantenNr, 'stundenlohnlnr'=StundenLohnlaufNr, 
                 'leistunglohnlnr'=LeistungLohnlaufNr)
  -
  RETURNS: The first value found (upwards) from given orgunit or NULL if nothing found
  -
  TEST:    SELECT [dbo].[fnOrgUnitHierarchyValue](26, 'stundenlohnlnr')
           102 = Begleitetes Wohnen GL
           26  = BS Amriswil (KGS Thurgau/Schaffhausen)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnOrgUnitHierarchyValue.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     19.01.09 15:16 Cjaeggi
 * Changed tabs to spaces
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 17:29 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnOrgUnitHierarchyValue
(
  @OrgUnitID INT,
  @FieldCode varchar(20)
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @ParentID INT
  DECLARE @Value INT

  -- set vars
  SET @ParentID = @OrgUnitID
  SET @Value = NULL

  -----------------------------------------------------------------------------
  -- loop until value found or no more parent
  -----------------------------------------------------------------------------
  WHILE(@ParentID IS NOT NULL AND @Value IS NULL)
  BEGIN
    ---------------------------------------------------------------------------
    -- check if parent id exists
    ---------------------------------------------------------------------------
    IF (NOT EXISTS(SELECT TOP 1 1 FROM dbo.XOrgUnit WITH (READUNCOMMITTED) WHERE OrgUnitID = @ParentID))
    BEGIN
      -- OrgUnit not found, return NULL due to invalid value
      RETURN NULL
    END
    
    ---------------------------------------------------------------------------
    -- type depending
    ---------------------------------------------------------------------------
    IF (@FieldCode = 'sakto')
    BEGIN
      -- get value for SammelkontoNr
      SELECT @ParentID = ORG.ParentID,
             @Value = ORG.Sammelkonto
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.OrgUnitID = @ParentID
    END
    ELSE IF (@FieldCode = 'mndnr')
    BEGIN
      -- get value for MandantenNr
      SELECT @ParentID = ORG.ParentID,
             @Value = ORG.Mandantennummer
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.OrgUnitID = @ParentID
    END
    ELSE IF (@FieldCode = 'stundenlohnlnr')
    BEGIN
      -- get value for StundenLohnlaufNr
      SELECT @ParentID = ORG.ParentID,
             @Value = ORG.StundenLohnlaufNr
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.OrgUnitID = @ParentID
    END
    ELSE IF (@FieldCode = 'leistunglohnlnr')
    BEGIN
      -- get value for LeistungLohnlaufNr
      SELECT @ParentID = ORG.ParentID,
             @Value = ORG.LeistungLohnlaufNr
      FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
      WHERE ORG.OrgUnitID = @ParentID
    END
    ELSE
    BEGIN
      -- invalid value, return NULL
      RETURN NULL
    END
    
  END -- [while]
  
  -----------------------------------------------------------------------------
  -- return found value or NULL if nothing found
  -----------------------------------------------------------------------------
  RETURN (@Value)
END
GO