SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetOEOrgUnitListZLE;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetOEOrgUnitListZLE.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:22 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Is used to get all orgunit that are connected to users within the ZLE
           only within user's member KGS (MandantenNummer) as used in ZLE-Zeiterfassung
    @UserID:     The user to get data from
    @AllowNull:  Set if an empty entry is possible
    @TextMode:   Set output for [Text]-column
                 ('OrgUnit' (default), 'OrgUnitKS', 'Kostenstelle')
    @SortField:  Sort data by this field primary
                 ('Code', 'Text' (default), 'Kostenstelle')
  -
  RETURNS: Table containing all data found in LOV style
  -
  TEST:    SELECT * FROM [dbo].[fnBDEGetOEOrgUnitListZLE](3, 0, 'Kostenstelle', 'Kostenstelle')
           SELECT * FROM [dbo].[fnBDEGetOEOrgUnitListZLE](3, 0, 'Kostenstelle', 'Text')
           SELECT * FROM [dbo].[fnBDEGetOEOrgUnitListZLE](3, 0, 'OrgUnitKS', 'Text')
           SELECT * FROM [dbo].[fnBDEGetOEOrgUnitListZLE](3, 1, 'OrgUnitKS', 'Code')
           SELECT * FROM [dbo].[fnBDEGetOEOrgUnitListZLE](3, 1, 'OrgUnitKS', 'Kostenstelle')
           SELECT * FROM [dbo].[fnBDEGetOEOrgUnitListZLE](3, 1, NULL, NULL)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/BDE/fnBDEGetOEOrgUnitListZLE.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     20.01.09 15:37 Cjaeggi
 * Modified text to function call
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetOEOrgUnitListZLE
(
  @UserID  INT,
  @AllowNull BIT,
  @TextMode VARCHAR(50),
  @SortField VARCHAR(50)
)
RETURNS @Result TABLE
(
  [Code] INT,
  [Text] VARCHAR(255),
  [Kostenstelle$] INT
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate vars
  -----------------------------------------------------------------------------
  IF (ISNULL(@UserID, -1) < 1)
  BEGIN
    -- invalid parameters, do not continue
    RETURN
  END
  
  -- setup flags
  SET @AllowNull = ISNULL(@AllowNull, 0)
  
  -----------------------------------------------------------------------------
  -- create temporary table to fill orgunits
  -----------------------------------------------------------------------------
  DECLARE @tmpOrgUnits TABLE
  (
    [Id$] INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    [Code] INT,
    [Text] VARCHAR(255),
    [Kostenstelle$] INT
  )
  
  -----------------------------------------------------------------------------
  -- get orgunits that are within the users member MandantenNr and
  -- the user has access to
  -----------------------------------------------------------------------------
  INSERT INTO @tmpOrgUnits
    -- orgunits
    SELECT DISTINCT
           [Code] = ORG.OrgUnitID,
           [Text] = CASE WHEN @TextMode = 'OrgUnitKS'    THEN ORG.ItemName + ISNULL(' ('+CONVERT(VARCHAR(50), ORG.Kostenstelle)+')',  '')
                         WHEN @TextMode = 'Kostenstelle' THEN dbo.fnCombineKSTOrgUnitItemName(ORG.Kostenstelle, ORG.ItemName)
                         ELSE ORG.ItemName
                    END,
           [Kostenstelle$] = ORG.Kostenstelle
    FROM dbo.XOrgUnit_User OUU WITH(READUNCOMMITTED)
      INNER JOIN dbo.XOrgUnit ORG WITH(READUNCOMMITTED) ON ORG.OrgUnitID = OUU.OrgUnitID
    WHERE OUU.UserID = @UserID -- only member/guest/leitung
  
  -----------------------------------------------------------------------------
  -- write out result to output (sorted)
  -----------------------------------------------------------------------------
  -- empty entry
  INSERT INTO @Result
    -- empty entry for admins
    SELECT [Code]          = NULL,
           [Text]          = '',
           [Kostenstelle$] = -1
    WHERE 1 = @AllowNull
    
  -- sorted as defined
  IF (@SortField = 'Code')
  BEGIN
    INSERT INTO @Result
      SELECT [Code], [Text], [Kostenstelle$]
      FROM @tmpOrgUnits
      ORDER BY [Code], [Text]
  END
  ELSE IF (@SortField = 'Kostenstelle')
  BEGIN
    INSERT INTO @Result
      SELECT [Code], [Text], [Kostenstelle$]
      FROM @tmpOrgUnits
      ORDER BY [Kostenstelle$], [Text], [Code]
  END
  ELSE
  BEGIN
    INSERT INTO @Result
      SELECT [Code], [Text], [Kostenstelle$]
      FROM @tmpOrgUnits
      ORDER BY [Text], [Code]
  END
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO