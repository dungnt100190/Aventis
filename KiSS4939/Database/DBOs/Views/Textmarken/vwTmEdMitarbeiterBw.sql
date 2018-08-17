SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmEdMitarbeiterBw;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmEdMitarbeiterBw.sql $
  $Author: Cjaeggi $
  $Modtime: 8.12.09 14:06 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View used for bookmarks specific for BW coworkers stored in EdMitarbeiter table
  -
  RETURNS: Specific data of coworker, depending of module assignement to BW
  -
  TEST:    SELECT TOP 10 * FROM vwTmEdMitarbeiterBw
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmEdMitarbeiterBw.sql $
 * 
 * 1     8.12.09 14:14 Cjaeggi
 * #5185: Updated views for bookmarks, fix after db-movement
=================================================================================================*/

CREATE VIEW dbo.vwTmEdMitarbeiterBw
AS
SELECT
  -----------------------------------------------------------------------------
  -- specific data for BW
  -----------------------------------------------------------------------------
  EDMitarbeiterID = EDM.EDMitarbeiterID,
  UserID          = EDM.UserID,
  XModulID        = EMM.XModulID,
  
  -- Typ BW
  GrunddatenTypBegleitetesWohnenD = REPLACE(dbo.fnLOVMLColumnListe('BwTyp', EMM.ModulTypCodes, NULL, 1), ';', ', '),
  GrunddatenTypBegleitetesWohnenF = REPLACE(dbo.fnLOVMLColumnListe('BwTyp', EMM.ModulTypCodes, NULL, 2), ';', ', '),
  GrunddatenTypBegleitetesWohnenI = REPLACE(dbo.fnLOVMLColumnListe('BwTyp', EMM.ModulTypCodes, NULL, 3), ';', ', '),
  
  -- Aktiv
  Aktiv                           = ISNULL(EMM.IstAktiv, 0),
  AktivJaNeinD                    = dbo.fnGetYesNoMLText(ISNULL(EMM.IstAktiv, 0), 1, 0),
  AktivJaNeinF                    = dbo.fnGetYesNoMLText(ISNULL(EMM.IstAktiv, 0), 2, 0),
  AktivJaNeinI                    = dbo.fnGetYesNoMLText(ISNULL(EMM.IstAktiv, 0), 3, 0),
  
  -- BW Ma
  IstBWMaJaNeinD                    = dbo.fnGetYesNoMLText(ISNULL(EDM.IstBWMa, 0), 1, 0),
  IstBWMaJaNeinF                    = dbo.fnGetYesNoMLText(ISNULL(EDM.IstBWMa, 0), 2, 0),
  IstBWMaJaNeinI                    = dbo.fnGetYesNoMLText(ISNULL(EDM.IstBWMa, 0), 3, 0)

FROM dbo.vwTmEdMitarbeiter           EDM WITH (READUNCOMMITTED)
  LEFT JOIN dbo.EdMitarbeiter_XModul EMM WITH (READUNCOMMITTED) ON EMM.EdMitarbeiterID = EDM.EdMitarbeiterID
                                                               AND EMM.XModulID = 5; -- BW
GO
