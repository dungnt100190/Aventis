SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKaEafSpezifischeErmittlung;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für das Erstellen von Textmarken
  -
  RETURNS: Daten der Tabelle KaEafSpezifischeErmittlung
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKaEafSpezifischeErmittlung;
=================================================================================================*/

CREATE VIEW dbo.vwTmKaEafSpezifischeErmittlung
AS
SELECT FaLeistungID         = KESE.FaLeistungID,
       FaLeistungIDRelation = CASE
                                WHEN FAR.FaLeistungID1 = KESE.FaLeistungID THEN FAR.FaLeistungID2
                                ELSE FAR.FaLeistungID1
                              END,
       AnwTeilzeit          = KESE.AnwesendTeilzeit,
       Zielsetzungen        = KESE.Zielsetzungen,
       BemAbschluss         = KESE.ProzessBemerkungenAbschluss
FROM dbo.KaEafSpezifischeErmittlung KESE WITH (READUNCOMMITTED)
  INNER JOIN dbo.FaRelation         FAR WITH (READUNCOMMITTED) ON (FAR.FaLeistungID1 = KESE.FaLeistungID OR FAR.FaLeistungID2 = KESE.FaLeistungID)
                                                              AND FAR.FaRelationTypCode = 1;
GO
