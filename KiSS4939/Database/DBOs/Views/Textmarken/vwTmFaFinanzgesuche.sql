SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmFaFinanzgesuche;
GO

/*
===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for FaFinanzgesuche

  RETURNS: -+Output used for bookmarks within word/excel.
  

=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwTmFaFinanzgesuche;
=================================================================================================
*/

CREATE VIEW dbo.vwTmFaFinanzgesuche
AS
SELECT
  FaFinanzgesucheID = DOC.FaFinanzgesucheID,
  BaPersonID = DOC.BaPersonID,
  UserID = DOC.UserID,
  Datum = DOC.Datum,
  --
  DienstleistungD = dbo.fnGetLOVMLText('FaModulDienstleistungen', DOC.DienstleistungCode, 1),
  DienstleistungF = dbo.fnGetLOVMLText('FaModulDienstleistungen', DOC.DienstleistungCode, 2),
  DienstleistungI = dbo.fnGetLOVMLText('FaModulDienstleistungen', DOC.DienstleistungCode, 3),
  --
  DokumenttypD = dbo.fnGetLOVMLText('FaGesuchDokumenttyp', DOC.DokumenttypCode, 1),
  DokumenttypF = dbo.fnGetLOVMLText('FaGesuchDokumenttyp', DOC.DokumenttypCode, 2),
  DokumenttypI = dbo.fnGetLOVMLText('FaGesuchDokumenttyp', DOC.DokumenttypCode, 3),
  --
  FondStiftung = DOC.FondStiftung,
  Beantragt = DOC.Beantragt,
  --
  StatusD = dbo.fnGetLOVMLText('FaGesuchStatus', DOC.StatusCode, 1),
  StatusF = dbo.fnGetLOVMLText('FaGesuchStatus', DOC.StatusCode, 2),
  StatusI = dbo.fnGetLOVMLText('FaGesuchStatus', DOC.StatusCode, 3),
  --
  BewilligterBetrag = DOC.BewilligterBetrag,
  Selbstbehalt = DOC.Selbstbehalt,
  AuszahlungAn = DOC.AuszahlungAn,
  Rueckforderung = DOC.Rueckforderung,
  --
  RueckzahlungsverpflichtungD = CASE WHEN DOC.Rueckzahlungsverpflichtung = 1 THEN 'Ja' ELSE 'Nein' END,
  RueckzahlungsverpflichtungF = CASE WHEN DOC.Rueckzahlungsverpflichtung = 1 THEN 'Oui' ELSE 'Non' END,
  RueckzahlungsverpflichtungI = CASE WHEN DOC.Rueckzahlungsverpflichtung = 1 THEN 'Si' ELSE 'No' END,
  --
  DatumRueckforderung = DOC.DatumRueckforderung,
  --
  ZurueckBezahltD = CASE WHEN DOC.ZurueckBezahlt = 1 THEN 'Ja' ELSE 'Nein' END,
  ZurueckBezahltF = CASE WHEN DOC.ZurueckBezahlt = 1 THEN 'Oui' ELSE 'Non' END,
  ZurueckBezahltI = CASE WHEN DOC.ZurueckBezahlt = 1 THEN 'Si' ELSE 'No' END,
  --
  Bemerkungen = DOC.Bemerkungen,
  
  -----------------------------------------------------------------------------
  -- Autor
  -----------------------------------------------------------------------------
  AutorMANameVorname           = dbo.fnGetLastFirstName(NULL, USRAU.LastName, USRAU.FirstName),
  AutorMANameVornameOhneKomma  = REPLACE(dbo.fnGetLastFirstName(NULL, USRAU.LastName, USRAU.FirstName), ',', ''),
  AutorMAVornameName           = REPLACE(dbo.fnGetLastFirstName(NULL, USRAU.FirstName, USRAU.LastName), ',', ''),

  AutorAnschriftEinzD  = dbo.fnGetFlexibleAdress(DOC.UserID, NULL, 1, 0, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0),
  AutorAnschriftEinzF  = dbo.fnGetFlexibleAdress(DOC.UserID, NULL, 2, 0, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0),
  AutorAnschriftEinzI  = dbo.fnGetFlexibleAdress(DOC.UserID, NULL, 3, 0, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0),
  
  AutorAnschriftMehrzD = dbo.fnGetFlexibleAdress(DOC.UserID, NULL, 1, 1, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0),
  AutorAnschriftMehrzF = dbo.fnGetFlexibleAdress(DOC.UserID, NULL, 2, 1, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0),
  AutorAnschriftMehrzI = dbo.fnGetFlexibleAdress(DOC.UserID, NULL, 3, 1, 'orgunit', 0, 1, 'vornach', dbo.fnGetGenderMLTitle(USRAU.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL), 0, 1, 1, 0, 1, 0, 0, 0, 0),

  AutorFax             = ORGAU.Fax,
  AutorTelefon         = USRAU.PhoneOffice,
  AutorEmail           = USRAU.EMail,

  -----------------------------------------------------------------------------
  -- Autor - Abteilung
  -----------------------------------------------------------------------------
  AutorMAAbtKGS = ORGAU.AdresseKGS,
  AutorMAAbtAbt = ORGAU.AdresseAbteilung,
  AutorMAAbtStrasseNr = ISNULL(ORGAU.AdresseStrasse + ' ', '') + ISNULL(ORGAU.AdresseHausNr, ''),
  AutorMAAbtPLZOrt = ISNULL(ORGAU.AdressePLZ + ' ', '') + ISNULL(ORGAU.AdresseOrt, ''),
  AutorMAAbtPCKonto = ORGAU.PCKonto,
  
  AutorMAAbtPostfachD = dbo.fnXGetPostfachTextML(ORGAU.Postfach, ORGAU.PostfachOhneNr, 1),
  AutorMAAbtPostfachF = dbo.fnXGetPostfachTextML(ORGAU.Postfach, ORGAU.PostfachOhneNr, 2),
  AutorMAAbtPostfachI = dbo.fnXGetPostfachTextML(ORGAU.Postfach, ORGAU.PostfachOhneNr, 3)

FROM dbo.FaFinanzgesuche DOC WITH(READUNCOMMITTED)
  -- autor
  LEFT JOIN dbo.XUser         USRAU WITH(READUNCOMMITTED) ON USRAU.UserID = DOC.UserID
  LEFT JOIN dbo.XOrgUnit      ORGAU WITH(READUNCOMMITTED) ON ORGAU.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(USRAU.UserID, 1))
GO