SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmKesVerlauf;
GO
/*===============================================================================================
  $Revision: 2$
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Textmarken: KES > Fachstelle Prima > PRIMA-Begleitung
  -
  RETURNS: Alle Textmarken: KES > Fachstelle Prima > PRIMA-Begleitung
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmKesVerlauf;
=================================================================================================*/

CREATE VIEW dbo.vwTmKesVerlauf
AS
SELECT
  VRL.KesVerlaufID,

  VRL.Datum,

  KontaktartDE = dbo.fnLOVMLText('KesKontaktart', VRL.KesKontaktartCode, 1),
  KontaktartFR = dbo.fnLOVMLText('KesKontaktart', VRL.KesKontaktartCode, 2),
  KontaktartIT = dbo.fnLOVMLText('KesKontaktart', VRL.KesKontaktartCode, 3),

  DienstleistungD = dbo.fnLOVMLText('KesDienstleistung', VRL.KesDienstleistungCode, 1),
  DienstleistungF = dbo.fnLOVMLText('KesDienstleistung', VRL.KesDienstleistungCode, 2),
  DienstleistungI = dbo.fnLOVMLText('KesDienstleistung', VRL.KesDienstleistungCode, 3),

  VRL.Stichwort,

  --Verfasser via Standard-Textmarke: vwTmUser, existiert aber nur für "Aktuell eingeloggter Benutzer", deshalb integriert in diese View
  VerfasserFrauHerr = USR.FrauHerr,
  VerfasserFrauHerrn = USR.FrauHerrn,
  VerfasserNameVorname = USR.NameVorname,
  VerfasserNameVornameOhneKomma = USR.NameVornameOhneKomma,
  VerfasserVornameName = USR.VornameName,
  VerfasserAbteilungEMail = USR.AbteilungEMail,
  VerfasserAbteilungFax = USR.AbteilungFax,
  VerfasserAbteilungName = USR.AbteilungName,
  VerfasserAbteilungTelefon = USR.AbteilungTelefon,
  VerfasserNachname = USR.Nachname,
  VerfasserVorname = USR.Vorname,
  VerfasserKuerzel = USR.Kuerzel,
  VerfasserTelephon = USR.Telephon,
  VerfasserEMail = USR.EMail,

  --Adressat via Standard-Textmarken: Adressat...

  DauerD = dbo.fnLOVMLText('FaDauer', VRL.FaDauerCode, 1),
  DauerF = dbo.fnLOVMLText('FaDauer', VRL.FaDauerCode, 2),
  DauerI = dbo.fnLOVMLText('FaDauer', VRL.FaDauerCode, 3),

  VRL.Inhalt
FROM dbo.KesVerlauf VRL WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwTmUser USR WITH (READUNCOMMITTED) ON USR.UserID = VRL.UserID
;
GO
