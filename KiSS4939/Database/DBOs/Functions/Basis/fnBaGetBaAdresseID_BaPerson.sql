SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGetBaAdresseID_BaPerson;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get specific unique BaAdresseID for BaInstitutionID
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @AdresseCode: The address type code within LOV BaAdressTyp
    @DateTime:    The datetime value to use for getting the address by DatumVon..DatumBis.
                  This value can be NULL and will be replaced by GETDATE()
  -
  RETURNS: Returns the BaPersonID with BaAdresseID matching for the given parameters or 
           NULL if no address was found
=================================================================================================
  TEST:    SELECT * FROM dbo.fnBaGetBaAdresseID_BaPerson(1, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGetBaAdresseID_BaPerson
(
  @AdresseCode INT,
  @DateTime DATETIME
)
RETURNS TABLE WITH SCHEMABINDING
AS 
RETURN 
  SELECT BaPersonID  = ADR.BaPersonID,
         BaAdresseID = MAX(ADR.BaAdresseID)
  FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
  WHERE (ISNULL(ADR.AdresseCode, -1) = ISNULL(@AdresseCode, -1))
    AND (ADR.DatumVon IS NULL OR dbo.fnDateOf(ADR.DatumVon) <= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
    AND (ADR.DatumBis IS NULL OR dbo.fnDateOf(ADR.DatumBis) >= dbo.fnDateOf(ISNULL(@DateTime, GETDATE())))
  GROUP BY ADR.BaPersonID;
GO