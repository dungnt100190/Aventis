SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spSstIKAuszugGeneriereAutomatischeAnforderungenNachXMonaten
GO
/*===============================================================================================
  $Revision: 13 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  This method requests IK-Auszüge depending on the specified AnforderungsCode
=================================================================================================*/

CREATE PROCEDURE dbo.spSstIKAuszugGeneriereAutomatischeAnforderungenNachXMonaten
(
  @MonateNachErstemFP int,
  @AuszugAnforderungCode int
)
AS 
BEGIN

DECLARE @EarliestYear int
DECLARE @MinAge int
DECLARE @MaxAge int

SELECT @EarliestYear = ValueInt
FROM dbo.XConfig
WHERE KeyPath = 'System\IKAuszuege\FruehestesAuszugsJahr'

SELECT @MinAge = ValueInt
FROM dbo.XConfig
WHERE KeyPath = 'System\IKAuszuege\MinimalAlter'

SELECT @MaxAge = ValueInt
FROM dbo.XConfig
WHERE KeyPath = 'System\IKAuszuege\MaximalAlter'

DECLARE @Today datetime
SET @Today = GETDATE()

-- Falls Anforderung > 1 (2. und 5. jährige Fallkontrolle), dann soll JahrVon abhängig vom Bewilligungsdatum sein
IF @AuszugAnforderungCode > 1 BEGIN
  SET @EarliestYear = NULL
END

INSERT INTO SstIKAuszug
(
  BaPersonID,
  SstIkAuszugAnforderungCode,
  AnforderungUserID,
  Versichertennummer,
  JahrVon,
  JahrBis,
  Creator,
  Modifier
)
  SELECT DISTINCT
    BaPersonID = PER.BaPersonID,
    SstIkAuszugAnforderungCode = @AuszugAnforderungCode,
    AnforderungUserID = dbo.fnXGetSystemUserID(),
    Versichertennummer = ISNULL(PER.Versichertennummer, ''),
    JahrVon = ISNULL(@EarliestYear, YEAR(LEI2.DatumBewilligung) - 2),	-- Entweder ab 2 Jahre vor der Bewilligung des ersten Finanzplans, oder ab 1985
    JahrBis = YEAR(@Today), -- ...bis heute		
    Creator = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID()),
    Modifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID())
  FROM BaPerson PER
    INNER JOIN BgFinanzplan_BaPerson FPP WITH (READUNCOMMITTED) ON FPP.BaPersonID = PER.BaPersonID
    INNER JOIN BgFinanzplan FIP WITH (READUNCOMMITTED) ON FIP.BgFinanzplanID = FPP.BgFinanzplanID AND FIP.BgBewilligungStatusCode IN (5,9) -- Nur Personen von bewilligten oder gesperrten Finanzplänen
    LEFT  JOIN vwSstIKAuszug IKA ON IKA.SstIKAuszugID = (SELECT TOP 1 SstIKAuszugID FROM SstIKAuszug WHERE BaPersonID = FPP.BaPersonID ORDER BY AnforderungDatum DESC) -- Hole letzten IK-Auszug für diese Person
    INNER JOIN 
      (SELECT   -- Selektiere die erste Bewilligung des ersten genemigten Finanzplan aller aktiven W-Leistungen, wobei das Bewilligungsdatum vor @MonateNachErstemFP Monaten war
         LEI.FaLeistungID,
         DatumBewilligung = BEW.Datum
       FROM FaLeistung LEI
         INNER JOIN BgFinanzplan FIP WITH (READUNCOMMITTED) ON FIP.FaLeistungID = LEI.FaLeistungID
         INNER JOIN BgBewilligung BEW WITH (READUNCOMMITTED) ON BEW.BgFinanzplanID = FIP.BgFinanzplanID
       WHERE LEI.FaProzessCode = 300 AND ISNULL(LEI.DatumBis, @Today) >= @Today	-- Aktive W-Leistung
         AND FIP.DatumVon = (SELECT TOP 1 DatumVon FROM BgFinanzplan WHERE FaLeistungID = LEI.FaLeistungID ORDER BY DatumVon)	-- Selektiere den ersten Finanzplan der aktiven W-Leistung
         AND BEW.BgBewilligungCode = 2 -- Nur genehmigte Finanzpläne
         AND BEW.Datum = (SELECT TOP 1 Datum FROM BgBewilligung WHERE BgFinanzplanID = BEW.BgFinanzplanID AND BgBewilligungCode = 2 ORDER BY Datum)	-- Selektiere nur die erste Bewilligung (nachfolgende Bewilligungen interessieren uns nicht mehr)
         AND DATEDIFF(MONTH, BEW.Datum, @Today) = @MonateNachErstemFP -- bewilligte Finanzpläne vor X Monaten  
       ) LEI2 ON LEI2.FaLeistungID = FIP.FaLeistungID  
  WHERE FPP.IstUnterstuetzt = 1	-- Nur unterstützte Personen im Finanzplan
    AND NOT EXISTS (SELECT TOP 1 1 -- Pruefung, ob bereits ein IkAuszug mit @AuszugAnforderungCode existiert und FP dazwischen nicht neu bewilligt wurde
                    FROM vwSstIKAuszug SIK2
                    WHERE SIK2.BapersonID = PER.BapersonID
                      AND SstIKAuszugAnforderungCode = @AuszugAnforderungCode
                      AND ISNULL(SIK2.AnforderungDatum, '19000101') >  LEI2.DatumBewilligung )
    AND ISNULL(IKA.SstIkAuszugStatusCode, 0) IN (0,5,6) -- Entweder gibts noch keine IK-Auszugs-Anforderung, oder die Anforderung ist bereits verarbeitet resp. deaktiviert worden
    AND dbo.fnGetAge(PER.Geburtsdatum, @Today) >= @MinAge -- Nur Personen über 20 Jahren 
    AND dbo.fnGetAge(PER.Geburtsdatum, @Today) < @MaxAge -- Nur Personen unter 65 Jahren
    AND PER.Fiktiv = 0	-- Nur effektive Personen (keine fiktiven Personen wie Berechnungspersonen etc.)
    
END
GO