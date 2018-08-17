SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwTmFaAktennotizen
GO

/*===============================================================================================
  $Archive: $
  $Author: $
  $Modtime: $
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Textmarken für alle Felder der Tabelle FaAktennotizen.
  -
  RETURNS: <Beschreibung des zurückgegebenen Results>
  -
  TEST:    SELECT TOP 10 * FROM dbo.vwTmFaAktennotizen;
=================================================================================================
  $Log: $
=================================================================================================*/

CREATE VIEW [dbo].[vwTmFaAktennotizen]
AS
SELECT
  A.FaAktennotizID,
  A.FaLeistungID,
  ID = CONVERT(varchar(20), A.FaAktennotizID),
  Datum = CONVERT(varchar(10), A.Datum, 104),
  Dauer = LovDa.Text,
  A.Zeit,
  Kontaktart = LovKa.Text,
  GespraechsStatus = LovGS.Text,
  Gespraechstyp = LovGT.Text,
  Kontaktpartner = A.Kontaktpartner,
  AlimentenstelleTyp = LovAS.Text,
  Stichwort = A.Stichwort,
  InhaltMitFmt = A.InhaltRTF,
  InhaltOhneFmt = A.InhaltRTF,
  Themen = dbo.fnLOVTextListe('FaThema', A.FaThemaCodes),
  Vertraulich = CASE WHEN A.Vertraulich = 1 THEN 'Ja' ELSE 'Nein' END,
  BesprechungThema1 = CASE WHEN A.BesprechungThema1 = 1 THEN 'Ja' ELSE 'Nein' END,
  BesprechungThema2 = CASE WHEN A.BesprechungThema2 = 1 THEN 'Ja' ELSE 'Nein' END,
  BesprechungThema3 = CASE WHEN A.BesprechungThema3 = 1 THEN 'Ja' ELSE 'Nein' END,
  BesprechungThema4 = CASE WHEN A.BesprechungThema4 = 1 THEN 'Ja' ELSE 'Nein' END,
  A.BesprechungThemaText1,
  A.BesprechungThemaText2,
  A.BesprechungThemaText3,
  A.BesprechungThemaText4,
  A.BesprechungZiel1,
  A.BesprechungZiel2,
  A.BesprechungZiel3,
  A.BesprechungZiel4,
  BesprechungZielGrad1 = CONVERT(varchar(20), A.BesprechungZielGrad1),
  BesprechungZielGrad2 = CONVERT(varchar(20), A.BesprechungZielGrad2),
  BesprechungZielGrad3 = CONVERT(varchar(20), A.BesprechungZielGrad3),
  BesprechungZielGrad4 = CONVERT(varchar(20), A.BesprechungZielGrad4),
  A.Pendenz1,
  A.Pendenz2,
  A.Pendenz3,
  A.Pendenz4,
  PendenzErledigt1 = CASE WHEN A.PendenzErledigt1 = 1 THEN 'Ja' ELSE 'Nein' END,
  PendenzErledigt2 = CASE WHEN A.PendenzErledigt2 = 1 THEN 'Ja' ELSE 'Nein' END,
  PendenzErledigt3 = CASE WHEN A.PendenzErledigt3 = 1 THEN 'Ja' ELSE 'Nein' END,
  PendenzErledigt4 = CASE WHEN A.PendenzErledigt4 = 1 THEN 'Ja' ELSE 'Nein' END,
  -- User
  UserLogin = U.Login,
  UserNachname = U.Nachname,
  UserVorname = U.Vorname,
  UserKuerzel = U.Kuerzel,
  UserNameVorname = U.NameVorname,
  UserNameVornameOhneKomma = U.NameVornameOhneKomma,
  UserVornameName = U.VornameName
FROM dbo.FaAktennotizen A WITH (READUNCOMMITTED)
LEFT JOIN dbo.vwTmUser U ON U.BenutzerNr = A.UserID
LEFT JOIN dbo.XLOVCode LovDa WITH (READUNCOMMITTED) ON LovDa.LOVName = 'FaDauer' AND LovDa.Code = A.FaDauerCode
LEFT JOIN dbo.XLOVCode LovKa WITH (READUNCOMMITTED) ON LovKa.LOVName = 'FaKontaktart' AND LovKa.Code = A.FaKontaktartCode
LEFT JOIN dbo.XLOVCode LovGS WITH (READUNCOMMITTED) ON LovGS.LOVName = 'FaGespraechsStatus' AND LovGS.Code = A.FaGespraechsStatusCode
LEFT JOIN dbo.XLOVCode LovGT WITH (READUNCOMMITTED) ON LovGT.LOVName = 'FaThema' AND LovGT.Code = A.FaGespraechstypCode
LEFT JOIN dbo.XLOVCode LovAS WITH (READUNCOMMITTED) ON LovAS.LOVName = 'AlimentenstelleTyp' AND LovAS.Code = A.AlimentenstelleTypCode
;
GO

 