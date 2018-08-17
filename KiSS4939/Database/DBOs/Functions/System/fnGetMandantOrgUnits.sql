SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetMandantOrgUnits;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetMandantOrgUnits.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:09 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Is used to get all orgunits within one MandantenNummer
    @MandantenNr:  The MandantenNummer to use
  -
  RETURNS: Table containing all orgunits
  -
  TEST:    SELECT * FROM [dbo].[fnGetMandantOrgUnits](181)
           201 = (KGS Thurgau/Schaffhausen)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnGetMandantOrgUnits.sql $
 * 
 * 3     7.01.10 10:46 Lloreggia
 * Alter to Create
 * 
 * 2     17.09.08 12:51 Cjaeggi
 * EXISTS TOP 1 eingebaut
 * 
 * 1     3.09.08 17:51 Aklopfenstein
 * 
 * 1     29.08.08 16:41 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnGetMandantOrgUnits
(
  @MandantenNr INT
)
RETURNS @Result TABLE
(
  OrgUnitID INT,
  ItemName varchar(100)
)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate first
  -----------------------------------------------------------------------------
  IF (@MandantenNr IS NULL OR NOT EXISTS(SELECT TOP 1 1 FROM XOrgUnit WHERE Mandantennummer = @MandantenNr))
  BEGIN
    -- invalid mandantennummer, cannot proceed
    RETURN
  END

  -----------------------------------------------------------------------------
  -- fill data
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT ORG.OrgUnitID,
           ORG.ItemName
    FROM dbo.XOrgUnit ORG WITH (READUNCOMMITTED)
    WHERE dbo.fnOrgUnitHierarchyValue(ORG.OrgUnitID, 'mndnr') = @MandantenNr
    ORDER BY ItemName

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO