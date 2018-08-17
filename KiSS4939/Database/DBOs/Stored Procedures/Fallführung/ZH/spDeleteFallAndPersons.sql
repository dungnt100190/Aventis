SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spDeleteFallAndPersons
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE PROCEDURE dbo.spDeleteFallAndPersons (@FaFallID int)
AS

IF OBJECT_ID('tempdb..#PersonToDelete') IS NOT NULL
  DROP table #PersonToDelete

SELECT BaPersonID
INTO   #PersonToDelete
FROM   FaFallPerson
WHERE  FaFallID = @FaFallID

DELETE FaFallPerson WHERE FaFallID = @FaFallID
DELETE FaJournal WHERE FaFallID = @FaFallID
DELETE FaInvolviertePerson WHERE FaFallID = @FaFallID
DELETE FaInvolvierteInstitution WHERE FaFallID = @FaFallID


DELETE BgPosition                WHERE BgBudgetID     in (SELECT BG.BgBudgetID
                                                          FROM   FaLeistung LEI
                                                                 INNER JOIN BgFinanzplan FP on FP.FaLeistungID = LEI.FaLeistungID
                                                                 INNER JOIN BgBudget     BG on BG.BgFinanzplanID = FP.BgFinanzplanID
                                                          WHERE LEI.FaFallID = @FaFallID)

DELETE BgBudget                  WHERE BgBudgetID     in (SELECT BG.BgBudgetID
                                                          FROM   FaLeistung LEI
                                                                 INNER JOIN BgFinanzplan FP on FP.FaLeistungID = LEI.FaLeistungID
                                                                 INNER JOIN BgBudget     BG on BG.BgFinanzplanID = FP.BgFinanzplanID
                                                          WHERE LEI.FaFallID = @FaFallID)

DELETE BgFinanzplan_BaPerson     WHERE BgFinanzplanID in (SELECT FP.BgFinanzplanID
                                                          FROM   FaLeistung LEI
                                                                 INNER JOIN BgFinanzplan FP on FP.FaLeistungID = LEI.FaLeistungID
                                                          WHERE LEI.FaFallID = @FaFallID)

DELETE BgFinanzplan              WHERE BgFinanzplanID in (SELECT FP.BgFinanzplanID
                                                          FROM   FaLeistung LEI
                                                                 INNER JOIN BgFinanzplan FP on FP.FaLeistungID = LEI.FaLeistungID
                                                          WHERE LEI.FaFallID = @FaFallID)

DELETE FaAktennotizen            WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaRessourcenkarte         WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaAbmachung               WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaDokumente               WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaTeilLeistungserbringer  WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaVoranmeldung            WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaCheckin                 WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaAssessment              WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaZielvereinbarung        WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaAbklaerung              WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)
DELETE FaDokumente               WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)

DELETE FaUnterlagenliste WHERE FaUnterlagenID in (SELECT FaUnterlagenID
                                                  FROM   FaUnterlagen UNT
                                                         INNER JOIN FaLeistung LEI on LEI.FaLeistungID = UNT.FaLeistungID
                                                  WHERE LEI.FaFallID = @FaFallID)
DELETE FaUnterlagen WHERE FaLeistungID in (SELECT FaLeistungID FROM FaLeistung WHERE FaFallID = @FaFallID)

DELETE FaLeistung WHERE FaFallID = @FaFallID
DELETE FaFall WHERE FaFallID = @FaFallID

DELETE BaAdresse             WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaVermoegen           WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaKrankenversicherung WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaArbeit              WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaErsatzeinkommen     WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaVermoegen           WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaZahlungsweg         WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaWVCode              WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaAlteFallNr          WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaWohnsituationPerson WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaPerson_Relation     WHERE BaPersonID_1 in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaPerson_Relation     WHERE BaPersonID_2 in (SELECT BaPersonID FROM #PersonToDelete)
DELETE BaPerson              WHERE BaPersonID in (SELECT BaPersonID FROM #PersonToDelete)

IF OBJECT_ID('tempdb..#PersonToDelete') IS NOT NULL
  DROP table #PersonToDelete
