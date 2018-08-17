SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmEdEinsatzEDMitarbeiter;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for Ed/BwEinsatz - ED-Mitarbeiter
  -
  RETURNS: Bookmarks for Ed/BwEinsatz - ED-Mitarbeiter (from search-criteria)
=================================================================================================
  TEST:    SELECT TOP 30 * FROM vwTmEdEinsatzEDMitarbeiter;
=================================================================================================*/

CREATE VIEW dbo.vwTmEdEinsatzEDMitarbeiter
AS
SELECT
  -- from vwTmUser
  TMU.*,
  
  -- to enable choosing the modul (eg. BW)
  EXM.XModulID,
  
  -- address
  GrunddatenAdresseZusatz = ADR.Zusatz,
  GrunddatenAdresseStrasse = ADR.Strasse,
  GrunddatenAdresseHausNr = ADR.HausNr,
  GrunddatenAdressePostfach = ADR.Postfach,
  GrunddatenAdressePLZ = ADR.PLZ,
  GrunddatenAdresseOrt = ADR.Ort,
  GrunddatenAdresseBezirk = ADR.Bezirk,
  GrunddatenAdresseKanton = ADR.Kanton,
  
  GrunddatenAdresseEinzD = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 0, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdresseEinzF = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 2, 0, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdresseEinzI = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 3, 0, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  GrunddatenAdrEinzOhneNameD = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdrEinzOhneNameF = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 2, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdrEinzOhneNameI = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 3, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  GrunddatenAdresseMehrzD = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 1, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdresseMehrzF = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 2, 1, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdresseMehrzI = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 3, 1, 'edmitarbeiter', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  GrunddatenAdrMehrzOhneNameD = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 1, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdrMehrzOhneNameF = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 2, 1, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  GrunddatenAdrMehrzOhneNameI = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 3, 1, 'edmitarbeiter', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  GrunddatenAdresseStrasseNr = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 0, 0),
  GrunddatenAdressePLZOrt    = dbo.fnGetFlexibleAdress(EDM.EdMitarbeiterID, NULL, 1, 0, 'edmitarbeiter', 0, 0, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0),
  
  -- others
  GeehrteFrauHerrD = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 1, NULL),
  GeehrteFrauHerrF = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 2, NULL),
  GeehrteFrauHerrI = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 3, NULL),
  
  GeschlechtD = dbo.fnGetLOVMLText('Geschlecht', USR.GenderCode, 1),
  GeschlechtF = dbo.fnGetLOVMLText('Geschlecht', USR.GenderCode, 2),
  GeschlechtI = dbo.fnGetLOVMLText('Geschlecht', USR.GenderCode, 3),
  
  EmailD      = dbo.fnEdGetEntlasterKontakt(EDM.UserID, 0, 1, 1),
  EmailF      = dbo.fnEdGetEntlasterKontakt(EDM.UserID, 0, 1, 2),
  EmailI      = dbo.fnEdGetEntlasterKontakt(EDM.UserID, 0, 1, 3),
  
  TelefonD    = dbo.fnEdGetEntlasterKontakt(EDM.UserID, 1, 0, 1),
  TelefonF    = dbo.fnEdGetEntlasterKontakt(EDM.UserID, 1, 0, 2),
  TelefonI    = dbo.fnEdGetEntlasterKontakt(EDM.UserID, 1, 0, 3),

  TelefonOhneTyp = (SELECT COALESCE(SUSR.PhoneOffice, SUSR.PhoneIntern, SUSR.PhonePrivat, SUSR.PhoneMobile)
                    FROM dbo.XUser SUSR WITH (READUNCOMMITTED)
                    WHERE SUSR.UserID = EDM.UserID),
  
  MobilTel    = USR.PhoneMobile,
  Fax         = USR.Fax
FROM dbo.vwTmUser                     TMU WITH (READUNCOMMITTED)
  INNER JOIN dbo.XUser                USR WITH (READUNCOMMITTED) ON USR.UserID = TMU.UserID
  LEFT  JOIN dbo.BaAdresse            ADR WITH (READUNCOMMITTED) ON ADR.UserID = USR.UserID
  LEFT  JOIN dbo.EdMitarbeiter        EDM WITH (READUNCOMMITTED) ON EDM.UserID = TMU.UserID
  INNER JOIN dbo.EdMitarbeiter_XModul EXM WITH (READUNCOMMITTED) ON EXM.EdMitarbeiterID = EDM.EdMitarbeiterID;
GO
