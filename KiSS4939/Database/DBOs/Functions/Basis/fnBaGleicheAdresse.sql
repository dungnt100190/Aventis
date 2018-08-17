SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBaGleicheAdresse;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Basis/fnBaGleicheAdresse.sql $
  $Author: Cjaeggi $
  $Modtime: 19.08.10 16:56 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Compare two addresses and determine if they are the same consider the defined columns
    @BaPersonID_1: The BaPersonID of the first person to use to get address
    @BaPersonID_2: The BaPersonID of the second person to use to get address 
    @AdresseCode:  The address type code used to compare address of same type
    @RefDate:      The reference date to use to get address within a given time
  -
  RETURNS: Bit value where means: 1=same address; 0=different address/invalid conditions
  -
  TEST:    SELECT dbo.fnBaGleicheAdresse(440, 441, 1, NULL);
           --
           SELECT dbo.fnBaGleicheAdresse(2, 2, 1, NULL);
           --
           SELECT dbo.fnBaGleicheAdresse(NULL, NULL, 1, NULL);
           SELECT dbo.fnBaGleicheAdresse(2, 2, 5, NULL);
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Basis/fnBaGleicheAdresse.sql $
 * 
 * 2     19.08.10 16:57 Cjaeggi
 * #4167: Fixed wrong naming
 * 
 * 1     19.08.10 16:49 Cjaeggi
 * #4167: Added new function fnBaGleicheAdresse for PI
=================================================================================================*/

CREATE FUNCTION dbo.fnBaGleicheAdresse
(
  @BaPersonID_1 INT,
  @BaPersonID_2 INT,
  @AdresseCode INT,
  @RefDate DATETIME
)
RETURNS BIT
AS
BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (@BaPersonID_1 IS NULL OR @BaPersonID_2 IS NULL OR @AdresseCode NOT IN (1, 2, 3))
  BEGIN
    -- invalid parameters > not same address
    RETURN CONVERT(BIT, 0);
  END;
  
  -----------------------------------------------------------------------------
  -- fix if same person
  -----------------------------------------------------------------------------
  IF (@BaPersonID_1 = @BaPersonID_2)
  BEGIN
    -- same person > same address
    RETURN CONVERT(BIT, 1);
  END;
  
  -----------------------------------------------------------------------------
  -- get and compare both addresses
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
              WHERE ADR.BaPersonID IN (@BaPersonID_1, @BaPersonID_2) 
                AND ADR.BaAdresseID IN (dbo.fnBaGetBaAdresseID('BaPersonID', @BaPersonID_1, @AdresseCode, @RefDate),  -- get both addresses of the same type
                                        dbo.fnBaGetBaAdresseID('BaPersonID', @BaPersonID_2, @AdresseCode, @RefDate))
              GROUP BY ADR.BaLandID, 
                       ADR.AdresseCode,
                       ADR.Zusatz, 
                       ADR.Strasse, 
                       ADR.HausNr, 
                       ADR.Postfach, 
                       ADR.PostfachOhneNr, 
                       ADR.PLZ, 
                       ADR.Ort, 
                       ADR.OrtschaftCode, 
                       ADR.Kanton, 
                       ADR.Bezirk
              HAVING COUNT(1) > 1))
  BEGIN
    RETURN CONVERT(BIT, 1);  -- same address (means: same houshold, too)
  END;
  
  -----------------------------------------------------------------------------
  -- not same address/household
  -----------------------------------------------------------------------------
  RETURN CONVERT(BIT, 0);
END;
GO