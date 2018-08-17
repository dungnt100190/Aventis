SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmBDEZLEUebersicht;
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBDEZLEUebersicht.sql $
  $Author: Lloreggia $
  $Modtime: 7.01.10 9:58 $
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for ZLE-Erfassung (only dummy for columns)
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmBDEZLEUebersicht
=================================================================================================
  $Log: /Database/KiSS4_PI_MasterDev/Views/Textmarken/vwTmBDEZLEUebersicht.sql $
 * 
 * 4     7.01.10 10:45 Lloreggia
 * Alter to Create
 * 
 * 3     23.10.08 9:31 Cjaeggi
 * Removed change again
 * 
 * 2     23.10.08 9:19 Cjaeggi
 * Changed fnBDEGetUebersicht
 * 
 * 1     3.09.08 17:53 Aklopfenstein
 * VSS FIRST
 * 
 * 1     3.09.08 9:49 Aklopfenstein
 * VSS FIRST
=================================================================================================*/

CREATE VIEW dbo.vwTmBDEZLEUebersicht
AS
SELECT FCN.UserID, 
       FCN.MonatJahrText, 
       FCN.PensumProzent, 
       FCN.SollArbeitszeitProTag, 
       FCN.GZIstArbeitszeitProMonat, 
       FCN.GZSollArbeitszeitProMonat, 
       FCN.GZMonatsSaldo, 
       FCN.GZUebertragVorjahr, 
       FCN.GZUebertragVormonate, 
       FCN.GZKorrekturen, 
       FCN.GZAusbezahlteUeberstunden, 
       FCN.GZSaldo, 
       FCN.SLIstArbeitszeitProMonat, 
       FCN.FerienUebertragVorjahr, 
       FCN.FerienAnspruchProJahr, 
       FCN.FerienBisherBezogen, 
       FCN.FerienZugabenKuerzungen, 
       FCN.FerienKorrekturen, 
       FCN.FerienSaldo
FROM dbo.fnBDEGetUebersicht(- 1, dbo.fnLastDayOf(GETDATE()), 1, 0) AS FCN
GO