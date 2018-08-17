SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmEdAuswertungsdaten;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vmTmEdAuswertungsdaten.sql $
  $Author: Cjaeggi $
  $Modtime: 20.11.09 10:25 $
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for EdAuswertungsdaten
  -
  RETURNS: Bookmarks for EdAuswertungsdaten
  -
  TEST:    SELECT TOP 30 * FROM vwTmEdAuswertungsdaten
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vmTmEdAuswertungsdaten.sql $
 * 
 * 5     20.11.09 10:26 Cjaeggi
 * #5185: Refactoring, added new column
 * 
 * 4     5.05.09 14:40 Cjaeggi
 * Fixed output for types
 * 
 * 3     4.05.09 11:03 Cjaeggi
 * #4340: Fixed amount-value to isnull(..., 0)
 * 
 * 2     11.12.08 16:48 Cjaeggi
 * BugFixed
 * 
 * 1     11.12.08 16:42 Cjaeggi
 * First version
=================================================================================================*/

CREATE VIEW dbo.vwTmEdAuswertungsdaten
AS
SELECT
  -----------------------------------------------------------------------------
  -- IDs
  -----------------------------------------------------------------------------
  EAD.EdAuswertungsdatenID,
  EAD.FaLeistungID,
  
  -----------------------------------------------------------------------------
  -- Others
  -----------------------------------------------------------------------------
  FamiliensituationD    = dbo.fnGetLOVMLText('EdFamiliensituation', EAD.FamiliensituationCode, 1),
  FamiliensituationF    = dbo.fnGetLOVMLText('EdFamiliensituation', EAD.FamiliensituationCode, 2),
  FamiliensituationI    = dbo.fnGetLOVMLText('EdFamiliensituation', EAD.FamiliensituationCode, 3),
  
  BetreuungD            = dbo.fnGetLOVMLText('EdBetreuung', EAD.BetreuungCode, 1),
  BetreuungF            = dbo.fnGetLOVMLText('EdBetreuung', EAD.BetreuungCode, 2),
  BetreuungI            = dbo.fnGetLOVMLText('EdBetreuung', EAD.BetreuungCode, 3),
  
  AnzahlGeschwister     = ISNULL(EAD.AnzahlGeschwister, 0),
  
  WohnsituationD        = dbo.fnGetLOVMLText('EdWohnsituation', EAD.WohnsituationCode, 1),
  WohnsituationF        = dbo.fnGetLOVMLText('EdWohnsituation', EAD.WohnsituationCode, 2),
  WohnsituationI        = dbo.fnGetLOVMLText('EdWohnsituation', EAD.WohnsituationCode, 3),
  
  LeistungenDritterD    = REPLACE(dbo.fnLOVMLColumnListe('EdLeistungDritter', EAD.LeistungenDritterCodes, NULL, 1), ';', ', '),
  LeistungenDritterF    = REPLACE(dbo.fnLOVMLColumnListe('EdLeistungDritter', EAD.LeistungenDritterCodes, NULL, 2), ';', ', '),
  LeistungenDritterI    = REPLACE(dbo.fnLOVMLColumnListe('EdLeistungDritter', EAD.LeistungenDritterCodes, NULL, 3), ';', ', '),
  
  Standortbestimmung    = CONVERT(VARCHAR, EAD.LetzteStandortbestimmung, 104),
  FinanzielleRessourcen = EAD.FinanzielleRessourcen,
  
  FinanzierungDurchFLBD = dbo.fnGetLOVMLText('JaNein', ISNULL(EAD.FinanzierungDurchFLB, 0), 1),
  FinanzierungDurchFLBF = dbo.fnGetLOVMLText('JaNein', ISNULL(EAD.FinanzierungDurchFLB, 0), 2),
  FinanzierungDurchFLBI = dbo.fnGetLOVMLText('JaNein', ISNULL(EAD.FinanzierungDurchFLB, 0), 3)

FROM dbo.EdAuswertungsdaten EAD WITH (READUNCOMMITTED);
GO
