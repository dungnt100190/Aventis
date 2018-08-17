SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAmAnspruchsberechnung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAmAnspruchsberechnung.sql $
  $Author: Lloreggia $
  $Modtime: 11.12.09 12:56 $
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAmAnspruchsberechnung.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:03 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/

/*
===================================================================================================
Author:      sozheo
Create date: 15.11.2007
Description: Textmarke für Anspruchsberechnung
===================================================================================================
ZUM KONTROLLIEREN:
-----------------
select * from vwTmAmAnspruchsberechnung
===================================================================================================
History:
--------
15.11.2007 : sozheo : neu erstellt
25.03.2008 : sozheo : Korrekturen für Verfügung
===================================================================================================
*/

CREATE VIEW [dbo].[vwTmAmAnspruchsberechnung]
AS
SELECT
  B.AmAnspruchsberechnungID,
  B.Bezeichnung,
  BerechnungDatumAb = CONVERT(varchar, B.BerechnungDatumAb, 104),
  BerechnungsTyp = bt.Text,
  BerechnungsStatus = bs.Text,
  Einkommensvariante = ev.Text,
  EntscheidDatum = CONVERT(varchar, V.EntscheidDatum, 104),
  Username = us.LastName + IsNull(us.FirstName, ''),
  UserLogon = us.LogonName
FROM dbo.AmAnspruchsberechnung B WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.AmVerfuegung V WITH (READUNCOMMITTED) ON V.AmVerfuegungID = B.AmVerfuegungID
  LEFT OUTER JOIN dbo.XLOVCode bt WITH (READUNCOMMITTED) ON bt.LOVName = 'AmBerechnungTyp' AND bt.Code = B.AmBerechnungTypCode
  LEFT OUTER JOIN dbo.XLOVCode bs WITH (READUNCOMMITTED) ON bs.LOVName = 'AmBerechnungsStatus' AND bs.Code = V.AmVerfuegungStatusCode
  LEFT OUTER JOIN dbo.XLOVCode ev WITH (READUNCOMMITTED) ON ev.LOVName = 'AmEinkommensvariante' AND ev.Code = B.AmEinkommensvarianteCode
  LEFT OUTER JOIN dbo.XUser us WITH (READUNCOMMITTED) ON us.UserID = B.UserID
