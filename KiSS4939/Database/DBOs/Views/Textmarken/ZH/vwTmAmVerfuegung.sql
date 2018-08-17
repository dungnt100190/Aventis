SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmAmVerfuegung
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwTmAmVerfuegung.sql $
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
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwTmAmVerfuegung.sql $
 * 
 * 3     11.12.09 13:03 Lloreggia
 * Header aktualisiert
 * 
 * 2     10.03.09 18:02 Rstahel
 * Abgleich der Views aus KISS4_MASTER_ZH
=================================================================================================*/
/*
===================================================================================================
Author:      sozheo
Create date: 19.03.2008
Description: Textmarke für Anspruchsberechnung
===================================================================================================
ZUM KONTROLLIEREN:
-----------------
select * from vwTmAmVerfuegung
===================================================================================================
History:
--------
19.03.2008 : sozheo : neu erstellt
===================================================================================================
*/

CREATE VIEW [dbo].[vwTmAmVerfuegung]
AS

SELECT
  V.AmVerfuegungID,
  V.Bezeichnung,
  V.AmVerfuegungStatusCode,
  Status = VS.Text,
  EntscheidDatum = CONVERT(varchar, V.EntscheidDatum, 104),
  Username = U.NameVornameOhneKomma,
  UserLogon = U.LogonName
FROM dbo.AmVerfuegung V WITH (READUNCOMMITTED)
  LEFT OUTER JOIN dbo.XLOVCode VS WITH (READUNCOMMITTED) ON VS.LOVName = 'AmBerechnungsStatus' AND VS.Code = V.AmVerfuegungStatusCode
  LEFT OUTER JOIN vwUser U ON U.UserID = V.UserID
