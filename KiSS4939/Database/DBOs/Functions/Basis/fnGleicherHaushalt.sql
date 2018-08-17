SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGleicherHaushalt;
GO
/*===============================================================================================
  $Archive: /KiSS4/Database/DBOs/Functions/Basis/fnGleicherHaushalt.sql $
  $Author: Cjaeggi $
  $Modtime: 19.08.10 16:17 $
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Probably obsolete for Standard
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /KiSS4/Database/DBOs/Functions/Basis/fnGleicherHaushalt.sql $
 * 
 * 7     19.08.10 16:17 Cjaeggi
 * #6109: Added new columns after changes of table, discussed with Thomas
 * B.
 * 
 * 6     20.07.10 16:49 Cjaeggi
 * #4167: Renamed column LandCode to BaLandID
 * 
 * 5     9.07.10 15:38 Cjaeggi
 * #4167: Fixed view and refactoring
 * 
 * 4     12.08.09 14:27 Ckaeser
 * #4932 Alter2Create Bereinigung DBO's
 * 
 * 3     3.08.09 10:45 Nweber
 * #4932: Functions and Stored Procedures merged
 * 
 * 1     13.09.08 17:06 Aklopfenstein
 * VSS First
=================================================================================================*/

CREATE FUNCTION dbo.fnGleicherHaushalt
(
  @FalltraegerID INT,
  @BaPersonID INT,
  @RefDate DATETIME
)
RETURNS BIT
AS
BEGIN
  -----------------------------------------------------------------------------
  -- gleiche Adressen
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM dbo.BaAdresse ADR WITH (READUNCOMMITTED)
              WHERE BaPersonID IN (@FalltraegerID, @BaPersonID) 
                AND (ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', @FalltraegerID, 1, @RefDate)  -- get both Wohnsitz addresses
                  OR ADR.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', @BaPersonID, 1, @RefDate))
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
              HAVING COUNT(1) > 1
                 AND MIN(ADR.BaPersonID) < MAX(ADR.BaPersonID)))
  BEGIN
    RETURN CONVERT(BIT, 1);  -- gleiche Adressen = gleicher Haushalt
  END;
  
  -----------------------------------------------------------------------------
  -- in aktuellem Finanzplan
  -----------------------------------------------------------------------------
  IF (EXISTS (SELECT TOP 1 1
              FROM dbo.FaLeistung                    FAL WITH (READUNCOMMITTED)
                INNER JOIN dbo.BgFinanzplan          SFP WITH (READUNCOMMITTED) ON SFP.FaLeistungID = FAL.FaLeistungID
                INNER JOIN dbo.BgFinanzplan_BaPerson SDP WITH (READUNCOMMITTED) ON SDP.BgFinanzplanID = SFP.BgFinanzplanID
              WHERE FAL.BaPersonID = @FalltraegerID
                AND @RefDate BETWEEN SFP.DatumVon AND ISNULL(SFP.DatumBis, @RefDate)
                AND SDP.BaPersonID = @BaPersonID))
  BEGIN
    RETURN CONVERT(BIT, 1);  -- in FP: immer im gleichen Haushalt
  END;
  
  IF (EXISTS (SELECT TOP 1 1
              FROM dbo.BgFinanzplan_BaPerson SDP WITH (READUNCOMMITTED)
                INNER JOIN dbo.BgFinanzplan  SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = SDP.BgFinanzplanID
              WHERE SDP.BaPersonID IN (@FalltraegerID, @BaPersonID)
                AND @RefDate BETWEEN SFP.DatumVon AND ISNULL(SFP.DatumBis, @RefDate)))
  BEGIN
    RETURN CONVERT(BIT, 0);  -- in verschiedenen FP: nicht im gleichen Haushalt
  END;
  
  -----------------------------------------------------------------------------
  -- unterstützt durch Basisdateneintrag
  -----------------------------------------------------------------------------
  IF (dbo.fnUnterstuetzt(@FalltraegerID, @BaPersonID, @RefDate) = 1)
  BEGIN
    RETURN CONVERT(BIT, 1);  -- unterstützt in Basisdaten: immer im gleichen Haushalt
  END;
  
  RETURN CONVERT(BIT, 0);    -- restliche Fälle: nicht im gleichen Haushalt
END;
GO