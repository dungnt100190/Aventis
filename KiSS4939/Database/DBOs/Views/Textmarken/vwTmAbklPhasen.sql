SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAbklPhasen
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  TEST: SELECT TOP 10 * FROM vwTmAbklPhasen
=================================================================================================*/

CREATE VIEW dbo.vwTmAbklPhasen
AS

WITH AbklaerungCte
AS
(
  SELECT IsIntake                       = 1,
         KaAbklaerungIntakeID           = KAI.KaAbklaerungIntakeID,
         KaAbklaerungVertieftID         = NULL,
         AsdFragen                      = KAI.AsdFragen,
         Gespraechstermin               = KAI.Gespraechstermin,
         KaAbklaerungGrundDossCode      = KAI.KaAbklaerungGrundDossCode,
         KaAbklaerungIntegrBeurCode     = KAI.KaAbklaerungIntegrBeurCode,
         DatumIntegration               = KAI.DatumIntegration,
         ModulCode                      = KAI.KaAbklaerungPhaseIntakeCode,
         Datum                          = KAI.Datum,
         Bemerkung                      = KAI.Bemerkung,
         KaKurserfassungID              = NULL,
         KaAbklaerungProbeeinsatzInCode = NULL,
         EinsatzVon                     = NULL,
         EinsatzBis                     = NULL         
  FROM dbo.KaAbklaerungIntake KAI WITH (READUNCOMMITTED) 
  
  UNION ALL
  
  SELECT IsIntake                       = 0,
         KaAbklaerungIntakeID           = NULL,
         KaAbklaerungVertieftID         = KAV.KaAbklaerungVertieftID,
         AsdFragen                      = NULL,
         Gespraechstermin               = NULL,
         KaAbklaerungGrundDossCode      = KAV.KaAbklaerungGrundDossCode,
         KaAbklaerungIntegrBeurCode     = KAV.KaAbklaerungIntegrBeurCode,
         DatumIntegration               = KAV.DatumIntegration,
         ModulCode                      = KAV.KaAbklaerungPhaseVertiefteAbklaerungenCode,
         Datum                          = KAV.Datum,
         Bemerkung                      = KAV.Bemerkung,
         KaKurserfassungID              = KAV.KaKurserfassungID,
         KaAbklaerungProbeeinsatzInCode = KAV.KaAbklaerungProbeeinsatzInCode,
         EinsatzVon                     = KAV.EinsatzVon,
         EinsatzBis                     = KAV.EinsatzBis
  FROM dbo.KaAbklaerungVertieft KAV WITH (READUNCOMMITTED) 
)

SELECT
  KaAKPhasenID          = ISNULL(CTE.KaAbklaerungIntakeID, CTE.KaAbklaerungVertieftID),
  IstIntake             = IsIntake,
  Fragestellungen       = CTE.AsdFragen,
  GrundDossier          = dbo.fnLOVText('KaAbklärungGrundDoss', CTE.KaAbklaerungGrundDossCode),
  IntegBeurteilung      = dbo.fnLOVText('KaAbklaerungIntegrBeur', CTE.KaAbklaerungIntegrBeurCode),
  DatumIntegBeurteilung = CTE.DatumIntegration,
  KursDatumBis          = ISNULL(CONVERT(VARCHAR(15), KUE.DatumBis, 104), ''),
  KursDatumVon          = ISNULL(CONVERT(VARCHAR(15), KUE.DatumVon, 104), ''),
  Phase                 = CASE WHEN CTE.IsIntake = 1 THEN dbo.fnLOVText('KaAbklaerungPhaseIntake', CTE.ModulCode)
                                                     ELSE dbo.fnLOVText('KaAbklaerungPhaseVertiefteAbklaerungen', CTE.ModulCode) 
                          END,
  PhaseDatum            = ISNULL(CONVERT(VARCHAR, CTE.Datum, 104), ' '),
  Rueckfragen           = CTE.Bemerkung,
  Kursnummer            = KUE.KursNr,
  EinsatzIn             = dbo.fnLOVText('KaAbklPhasenEinsatzin', CTE.KaAbklaerungProbeeinsatzInCode),
  EinsatzVon            = CTE.EinsatzVon,
  EinsatzBis            = CTE.EinsatzBis,
  Gespraechtstermin     = CTE.Gespraechstermin
FROM AbklaerungCte              CTE
  LEFT JOIN dbo.KaKurserfassung KUE WITH (READUNCOMMITTED) ON KUE.KaKurserfassungID = CTE.KaKurserfassungID
  LEFT JOIN dbo.KaKurs          KUR WITH (READUNCOMMITTED) ON KUR.KaKursID = KUE.KursID

GO