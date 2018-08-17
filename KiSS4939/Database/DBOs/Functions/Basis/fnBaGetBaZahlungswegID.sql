SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetBaZahlungswegID;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Basis/fnBaGetBaZahlungswegID.sql $
  $Author: Cjaeggi $
  $Modtime: 24.08.10 15:22 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get specific unique BaZahlungswegID for given parameters in time.
    @TableIDType:           The type of the id within the table BaAdresse
                            - 'BaPersonID':         Use BaPersonID for matching @TableID
                            - 'BaInstitutionID':    Use BaInstitutionID for matching @TableID
    @TableID:               The id within the table BaZahlungsweg (e.g. BaPersonID, BaInstitutionID)
    @BaZahlwegModulStdCode: Optional filter for specific type code
    @DateTime:              The datetime value to use for getting the address by DatumVon..DatumBis.
                            This value can be NULL and will be replaced by GETDATE()
  -
  RETURNS: Returns the BaZahlungswegID matching for the given parameters or NULL if no address was found
  -
  TEST:    SELECT dbo.fnBaGetBaZahlungswegID('BaPersonID', 2, 1, NULL);
           SELECT dbo.fnBaGetBaZahlungswegID('BaPersonID', 87128, NULL, NULL);
           SELECT dbo.fnBaGetBaZahlungswegID('BaPersonID', 87159, 100, NULL);
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Basis/fnBaGetBaZahlungswegID.sql $
 * 
 * 2     24.08.10 15:22 Cjaeggi
 * #4167: Fixing code
 * 
 * 1     24.08.10 15:16 Cjaeggi
 * #4167: Added new function for getting BaZahlungswegID
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetBaZahlungswegID
(
  @TableIDType VARCHAR(50),
  @TableID INT,
  @BaZahlwegModulStdCode INT,
  @DateTime DATETIME
)
RETURNS INT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- init vars
  -----------------------------------------------------------------------------
  DECLARE @BaZahlungswegID INT;
  SET @BaZahlungswegID = NULL;
  
  -----------------------------------------------------------------------------
  -- get value depending on given parameters
  -----------------------------------------------------------------------------
  IF (@TableIDType = 'BaPersonID')
  BEGIN
    -- get matching entry id for BaPerson
    SELECT @BaZahlungswegID = MAX(ZLW.BaZahlungswegID)
    FROM dbo.BaZahlungsweg ZLW WITH (READUNCOMMITTED)
    WHERE ZLW.BaPersonID = ISNULL(@TableID, -1)                      -- BaPersonID
      AND (ZLW.DatumVon IS NULL OR dbo.fnDateOf(ZLW.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
      AND (ZLW.DatumBis IS NULL OR dbo.fnDateOf(ZLW.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
      AND (@BaZahlwegModulStdCode IS NULL OR (',' + ZLW.BaZahlwegModulStdCodes + ',' LIKE ',' + CONVERT(VARCHAR(10), @BaZahlwegModulStdCode) + ','));
  END
  ELSE IF (@TableIDType = 'BaInstitutionID')
  BEGIN
    -- get matching entry id for BaInstitution
    SELECT @BaZahlungswegID = MAX(ZLW.BaZahlungswegID)
    FROM dbo.BaZahlungsweg ZLW WITH (READUNCOMMITTED)
    WHERE ZLW.BaInstitutionID = ISNULL(@TableID, -1)                 -- BaInstitutionID
      AND (ZLW.DatumVon IS NULL OR dbo.fnDateOf(ZLW.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
      AND (ZLW.DatumBis IS NULL OR dbo.fnDateOf(ZLW.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
      AND (@BaZahlwegModulStdCode IS NULL OR (',' + ZLW.BaZahlwegModulStdCodes + ',' LIKE ',' + CONVERT(VARCHAR(10), @BaZahlwegModulStdCode) + ','));
  END;
  
  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN @BaZahlungswegID;
END;
GO
