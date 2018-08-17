SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaEafSozioberuflicheBilanz;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für das Erstellen von Textmarken
  -
  RETURNS: Daten der TabelleKaEafSozioberuflicheBilanz
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKaEafSozioberuflicheBilanz;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaEafSozioberuflicheBilanz
AS
SELECT FaLeistungID         = KESB.FaLeistungID,
       FaLeistungIDRelation = CASE
                                WHEN FAR.FaLeistungID1 = KESB.FaLeistungID THEN FAR.FaLeistungID2
                                ELSE FAR.FaLeistungID1
                              END,
       AnwTeilzeit          = KESB.AnwesendTeilzeit,
       Schwerpunkte         = KESB.Schwerpunkte,
       BemAbschluss         = KESB.ProzessBemerkungenAbschluss,
       ZielRav              = KESB.AufnahmeZielsetzungenRAV,
       Ergebnisse           = ISNULL(KESB.AufnahmeErgebnisseInterview + CHAR(10) + CHAR(13), '') + 
                              ISNULL(KESB.AufnahmeErgebnisseBewerbung + CHAR(10) + CHAR(13), '') + 
                              ISNULL(KESB.AufnahmeErgebnisseAssessment + CHAR(10) + CHAR(13), '') + 
                              ISNULL(KESB.AufnahmeErgebnisseWerkstatt, '')
FROM dbo.KaEafSozioberuflicheBilanz KESB WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaRelation         FAR WITH (READUNCOMMITTED) ON (FAR.FaLeistungID1 = KESB.FaLeistungID OR FAR.FaLeistungID2 = KESB.FaLeistungID)
                                                              AND FAR.FaRelationTypCode = 1;
GO
