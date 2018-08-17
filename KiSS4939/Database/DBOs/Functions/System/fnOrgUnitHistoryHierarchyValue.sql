SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnOrgUnitHistoryHierarchyValue
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnOrgUnitHistoryHierarchyValue.sql $
  $Author: Cjaeggi $
  $Modtime: 18.08.09 16:03 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a historised hierarchical value upwards from orgunit
    @OrgUnitID:  ID of OrgUnit
    @Date:       Date within history to get value from
    @FieldCode:  Type of information to get
                 - 'mndnr'           = MandantenNr
                 - 'stundenlohnlnr'  = StundenLohnlaufNr
                 - 'leistunglohnlnr' = LeistungLohnlaufNr
                 - 'kgsorgunitid'    = OrgUnitID of KGS
                 - 'hsorgunitid'     = OrgUnitID of HS
  -
  RETURNS: The first value found (upwards) from given orgunit or NULL if nothing found
  -
  TEST:    SELECT dbo.fnOrgUnitHistoryHierarchyValue(102, '2008-03-29', 'leistunglohnlnr')
           102 = Begleitetes Wohnen GL
           26  = BS Amriswil (KGS Thurgau/Schaffhausen)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnOrgUnitHistoryHierarchyValue.sql $
 * 
 * 4     18.08.09 16:03 Cjaeggi
 * #5174: Performance optimizing
 * 
 * 3     20.02.09 9:28 Cjaeggi
 * Added 'hsorgunitid' as new fieldcode
 * 
 * 2     21.01.09 7:52 Cjaeggi
 * Added 'kgsorgunitid' as new data to retrieve
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 17:29 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnOrgUnitHistoryHierarchyValue
(
  @OrgUnitID INT,
  @Date DATETIME,
  @FieldCode VARCHAR(20)
)
RETURNS INT
AS BEGIN
  -----------------------------------------------------------------------------
  -- DEBUG
  -----------------------------------------------------------------------------
  /*
  DECLARE @OrgUnitID INT
  DECLARE @Date DATETIME
  DECLARE @FieldCode VARCHAR(20)

  SET @OrgUnitID = 26
  SET @Date = '2008-03-10'
  SET @FieldCode = 'stundenlohnlnr'
  */
  
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  -- if not all values are passed, we cannot do anything
  IF (@Date IS NULL OR @OrgUnitID IS NULL OR @FieldCode IS NULL)
  BEGIN
    RETURN NULL
  END
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @ParentID INT
  DECLARE @LastParentID INT
  DECLARE @Value INT
  
  -- set vars
  SET @ParentID = @OrgUnitID
  SET @LastParentID = @ParentID
  SET @Value = NULL
  
  -----------------------------------------------------------------------------
  -- loop until value found or no more parent
  -----------------------------------------------------------------------------
  WHILE(@ParentID IS NOT NULL AND @Value IS NULL)
  BEGIN
    ---------------------------------------------------------------------------
    -- apply LastParentID for preventing endless loop if same or parent not found
    ---------------------------------------------------------------------------
    SET @LastParentID = @ParentID
    
    ---------------------------------------------------------------------------
    -- type depending history value
    ---------------------------------------------------------------------------
    IF (@FieldCode = 'mndnr')
    BEGIN
      -- get value for MandantenNr
      SELECT TOP 1
             @ParentID = ORG.ParentID,
             @Value    = ORG.Mandantennummer
      FROM dbo.Hist_XOrgUnit ORG WITH (READUNCOMMITTED)
        INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = ORG.VerID
      WHERE ORG.OrgUnitID = @ParentID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
      ORDER BY HIS.VersionDate DESC, HIS.VerID DESC
    END
    ---------------------------------------------------------------------------
    ELSE IF (@FieldCode = 'stundenlohnlnr')
    BEGIN
      -- get value for StundenLohnlaufNr
      SELECT TOP 1
             @ParentID = ORG.ParentID,
             @Value    = ORG.StundenLohnlaufNr
      FROM dbo.Hist_XOrgUnit ORG WITH (READUNCOMMITTED)
        INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = ORG.VerID
      WHERE ORG.OrgUnitID = @ParentID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
      ORDER BY HIS.VersionDate DESC, HIS.VerID DESC
    END
    ---------------------------------------------------------------------------
    ELSE IF (@FieldCode = 'leistunglohnlnr')
    BEGIN
      -- get value for LeistungLohnlaufNr
      SELECT TOP 1
             @ParentID = ORG.ParentID,
             @Value    = ORG.LeistungLohnlaufNr
      FROM dbo.Hist_XOrgUnit ORG WITH (READUNCOMMITTED)
        INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = ORG.VerID
      WHERE ORG.OrgUnitID = @ParentID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
      ORDER BY HIS.VersionDate DESC, HIS.VerID DESC
    END
    ---------------------------------------------------------------------------
    ELSE IF (@FieldCode = 'kgsorgunitid')
    BEGIN
      -- get value for KGS-OrgUnitID (OrganisationsEinheitTyp: 4=Kantonale Geschäftsstelle)
      SELECT TOP 1
             @ParentID = ORG.ParentID,
             @Value    = CASE WHEN ORG.OEItemTypCode = 4 THEN ORG.OrgUnitID   -- 4=KGS
                              ELSE NULL
                         END
      FROM dbo.Hist_XOrgUnit ORG WITH (READUNCOMMITTED)
        INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = ORG.VerID
      WHERE ORG.OrgUnitID = @ParentID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
      ORDER BY HIS.VersionDate DESC, HIS.VerID DESC
    END
    ---------------------------------------------------------------------------
    ELSE IF (@FieldCode = 'hsorgunitid')
    BEGIN
      -- get value for HS-OrgUnitID (OrganisationsEinheitTyp: 1=Hauptsitz)
      SELECT TOP 1
             @ParentID = ORG.ParentID,
             @Value    = CASE WHEN ORG.OEItemTypCode = 1 THEN ORG.OrgUnitID   -- 1=Hauptsitz
                              ELSE NULL
                         END
      FROM dbo.Hist_XOrgUnit ORG WITH (READUNCOMMITTED)
        INNER JOIN dbo.HistoryVersion HIS WITH (READUNCOMMITTED) ON HIS.VerID = ORG.VerID
      WHERE ORG.OrgUnitID = @ParentID AND DATEADD(d, 0, DATEDIFF(d, 0, HIS.VersionDate)) <= @Date
      ORDER BY HIS.VersionDate DESC, HIS.VerID DESC
    END
    ---------------------------------------------------------------------------
    ELSE
    BEGIN
      -- invalid value, return NULL
      RETURN NULL
    END
    
    ---------------------------------------------------------------------------
    -- check if parent id exists and is valid
    ---------------------------------------------------------------------------
    IF (@LastParentID = @ParentID)
    BEGIN
      -- enless loop or parent not found, return NULL due to invalid state
      RETURN NULL
    END
  END
  
  -----------------------------------------------------------------------------
  -- return found value or NULL if nothing found
  -----------------------------------------------------------------------------
  RETURN @Value
END
GO