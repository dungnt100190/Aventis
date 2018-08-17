SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID;
GO
/*===============================================================================================
  $Revision: 10 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get specific unique BaAdresseID for given parameters in time.
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @TableIDType: The type of the id within the table BaAdresse
                  - 'BaPersonID':         Use BaPersonID for matching @TableID
                  - 'BaInstitutionID':    Use BaInstitutionID for matching @TableID
                  - 'KaBetriebID':        Use KaBetriebID for matching @TableID
                  - 'KaBetriebKontaktID': Use KaBetriebKontaktID for matching @TableID
    @TableID:     The id within the table BaAdresse (e.g. BaPersonID, BaInstitutionID)
    @AdresseCode: The address type code within LOV BaAdressTyp, can be NULL (only important for BaPerson)
    @DateTime:    The datetime value to use for getting the address by DatumVon..DatumBis.
                  This value can be NULL and will be replaced by GETDATE()
  -
  RETURNS: Returns the BaAdresseID matching for the given parameters or NULL if no address was found
=================================================================================================
  TEST:    SELECT dbo.fnBaGetBaAdresseID('BaPersonID', 2, 1, NULL);
           SELECT dbo.fnBaGetBaAdresseID('BaInstitutionID', 2, NULL, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetBaAdresseID
(
  @TableIDType VARCHAR(50),
  @TableID INT,
  @AdresseCode INT,
  @DateTime DATETIME
)
RETURNS INT WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- get value depending on given parameters
  -----------------------------------------------------------------------------
  IF (@TableIDType = 'BaPersonID')
  BEGIN
    -- get matching address id for BaPerson
    RETURN (SELECT BaAdresseID = FCN.BaAdresseID
            FROM dbo.fnBaGetBaAdresseID_BaPerson(@AdresseCode, @DateTime) FCN
            WHERE FCN.BaPersonID = ISNULL(@TableID, -1));
  END
  ELSE IF (@TableIDType = 'BaInstitutionID')
  BEGIN
    -- get matching address id for BaInstitution
    RETURN (SELECT BaAdresseID = FCN.BaAdresseID
            FROM dbo.fnBaGetBaAdresseID_BaInstitution(@AdresseCode, @DateTime) FCN
            WHERE FCN.BaInstitutionID = ISNULL(@TableID, -1));
  END
  ELSE IF (@TableIDType = 'KaBetriebID')
  BEGIN
    -- get matching address id for KaBetrieb
    RETURN (SELECT BaAdresseID = MAX(ADR.BaAdresseID)
            FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
            WHERE ADR.KaBetriebID = ISNULL(@TableID, -1)                     -- KaBetriebID
              ---- AND (ISNULL(ADR.AdresseCode, -1) = ISNULL(@AdresseCode, -1))
              AND (ADR.DatumVon IS NULL OR dbo.fnDateOf(ADR.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
              AND (ADR.DatumBis IS NULL OR dbo.fnDateOf(ADR.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE()))));
  END
  ELSE IF (@TableIDType = 'KaBetriebKontaktID')
  BEGIN
    -- get matching address id for KaBetriebKontakt
    RETURN (SELECT BaAdresseID = MAX(ADR.BaAdresseID)
            FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
            WHERE ADR.KaBetriebKontaktID = ISNULL(@TableID, -1)              -- KaBetriebKontaktID
              ---- AND (ISNULL(ADR.AdresseCode, -1) = ISNULL(@AdresseCode, -1))
              AND (ADR.DatumVon IS NULL OR dbo.fnDateOf(ADR.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
              AND (ADR.DatumBis IS NULL OR dbo.fnDateOf(ADR.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE()))));
  END;
  
  -----------------------------------------------------------------------------
  -- this case should never occure
  -----------------------------------------------------------------------------
  RETURN NULL;
END;
GO