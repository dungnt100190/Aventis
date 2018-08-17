SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmEdMitarbeiterEd;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmEdMitarbeiterEd.sql $
  $Author: Cjaeggi $
  $Modtime: 8.12.09 14:05 $
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View used for bookmarks specific for ED coworkers stored in EdMitarbeiter table
  -
  RETURNS: Specific data of coworker, depending of module assignement to ED
  -
  TEST:    SELECT TOP 10 * FROM vwTmEdMitarbeiterEd
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmEdMitarbeiterEd.sql $
 * 
 * 1     8.12.09 14:14 Cjaeggi
 * #5185: Updated views for bookmarks, fix after db-movement
=================================================================================================*/

CREATE VIEW dbo.vwTmEdMitarbeiterEd
AS
SELECT
  -----------------------------------------------------------------------------
  -- specific data for ED
  -----------------------------------------------------------------------------
  EDMitarbeiterID = EDM.EDMitarbeiterID,
  UserID          = EDM.UserID,
  XModulID        = EMM.XModulID,
  
  -- Typ ED
  GrunddatenTypEntlastungsdienstD = REPLACE(dbo.fnLOVMLColumnListe('EDTyp', EMM.ModulTypCodes, NULL, 1), ';', ', '),
  GrunddatenTypEntlastungsdienstF = REPLACE(dbo.fnLOVMLColumnListe('EDTyp', EMM.ModulTypCodes, NULL, 2), ';', ', '),
  GrunddatenTypEntlastungsdienstI = REPLACE(dbo.fnLOVMLColumnListe('EDTyp', EMM.ModulTypCodes, NULL, 3), ';', ', '),
  
  -- Aktiv
  Aktiv                           = ISNULL(EMM.IstAktiv, 0),
  AktivJaNeinD                    = dbo.fnGetYesNoMLText(ISNULL(EMM.IstAktiv, 0), 1, 0),
  AktivJaNeinF                    = dbo.fnGetYesNoMLText(ISNULL(EMM.IstAktiv, 0), 2, 0),
  AktivJaNeinI                    = dbo.fnGetYesNoMLText(ISNULL(EMM.IstAktiv, 0), 3, 0),
  
  -- ED Ma
  IstEDMaJaNeinD                    = dbo.fnGetYesNoMLText(ISNULL(EDM.IstEDMa, 0), 1, 0),
  IstEDMaJaNeinF                    = dbo.fnGetYesNoMLText(ISNULL(EDM.IstEDMa, 0), 2, 0),
  IstEDMaJaNeinI                    = dbo.fnGetYesNoMLText(ISNULL(EDM.IstEDMa, 0), 3, 0)

FROM dbo.vwTmEdMitarbeiter           EDM WITH (READUNCOMMITTED)
  LEFT JOIN dbo.EdMitarbeiter_XModul EMM WITH (READUNCOMMITTED) ON EMM.EdMitarbeiterID = EDM.EdMitarbeiterID
                                                               AND EMM.XModulID = 6; -- ED
GO
