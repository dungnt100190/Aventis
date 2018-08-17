SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetVISDossierNr;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnBaGetVISDossierNr.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:54 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get the old dossier number from vis
    @BaPersonID: The id of the person
  -
  RETURNS: '' if no dossiernumber found, else ' (Area - Number)' from vis
  -
  TEST:    SELECT [dbo].[fnBaGetVISDossierNr](41)
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Functions/Basis/fnBaGetVISDossierNr.sql $
 * 
 * 2     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 1     3.09.08 17:50 Aklopfenstein
 * 
 * 1     29.08.08 15:04 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetVISDossierNr
(
  @BaPersonID INT
)
RETURNS varchar(255)
AS BEGIN
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @VisDossierNumber varchar(255)

  -----------------------------------------------------------------------------
  -- get value
  -----------------------------------------------------------------------------
  SELECT TOP 1
		 @VisDossierNumber = IsNull(visdat36Area, '') + IsNull(' - ' + visdat36FALLID, '')
  FROM dbo.FaLeistung WITH (READUNCOMMITTED)
  WHERE BaPersonID = @BaPersonID AND visdat36FALLID IS NOT NULL
  ORDER BY DatumVon DESC

  -----------------------------------------------------------------------------
  -- return value
  -----------------------------------------------------------------------------  
  RETURN IsNull(' (' + @VisDossierNumber + ')', '')
END
GO