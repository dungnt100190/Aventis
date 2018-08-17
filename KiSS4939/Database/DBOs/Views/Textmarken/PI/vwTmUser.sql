SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmUser;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for given user
  -
  RETURNS: Bookmark columns in german, french and italian
=================================================================================================
  TEST:    SELECT TOP 10 * FROM dbo.vwTmUser WHERE Logon NOT LIKE '%none%'
=================================================================================================*/

CREATE VIEW dbo.vwTmUser
AS
SELECT
  -- ids
  USR.UserID,
  ORG.OrgUnitID,
  
  -- other fields
  Logon         = USR.LogonName,
  Name          = USR.LastName,
  Vorname       = USR.FirstName,
  Kurzzeichen   = USR.ShortName,
  TelefonBuero  = USR.PhoneOffice,
  TelefonIntern = USR.PhoneIntern,
  TelefonPrivat = USR.PhonePrivat,
  EMail         = USR.EMail,
  
  SpracheD  = dbo.fnGetLOVMLText('Sprache', USR.LanguageCode, 1),
  SpracheF  = dbo.fnGetLOVMLText('Sprache', USR.LanguageCode, 2),
  SpracheI  = dbo.fnGetLOVMLText('Sprache', USR.LanguageCode, 3),
  
  FunktionsbezeichnungD  = dbo.fnGetLOVMLText('RoleTitle', USR.RoleTitleCode, 1),
  FunktionsbezeichnungF  = dbo.fnGetLOVMLText('RoleTitle', USR.RoleTitleCode, 2),  
  FunktionsbezeichnungI  = dbo.fnGetLOVMLText('RoleTitle', USR.RoleTitleCode, 3),
  
  QualifikationD  = dbo.fnGetLOVMLText('QualificationTitle', USR.QualificationTitleCode, 1),
  QualifikationF  = dbo.fnGetLOVMLText('QualificationTitle', USR.QualificationTitleCode, 2),  
  QualifikationI  = dbo.fnGetLOVMLText('QualificationTitle', USR.QualificationTitleCode, 3),    
  
  FrauHerrD = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, NULL),
  FrauHerrF = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, NULL),
  FrauHerrI = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, NULL),
  
  NameVorname          = dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName),
  NameVornameOhneKomma = REPLACE(dbo.fnGetLastFirstName(NULL, USR.LastName, USR.FirstName), ',', ''),
  VornameName          = REPLACE(dbo.fnGetLastFirstName(NULL, USR.FirstName, USR.LastName), ',', ''),
  
  FrauHerrVornameNameD = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, ' ' + REPLACE(dbo.fnGetLastFirstName(NULL, USR.FirstName, USR.LastName), ',', '')),
  FrauHerrVornameNameF = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, ' ' + REPLACE(dbo.fnGetLastFirstName(NULL, USR.FirstName, USR.LastName), ',', '')),
  FrauHerrVornameNameI = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, ' ' + REPLACE(dbo.fnGetLastFirstName(NULL, USR.FirstName, USR.LastName), ',', '')),
  
  GeehrteFrauHerrNameD = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 1, ' ' + USR.LastName),
  GeehrteFrauHerrNameF = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 2, ' ' + USR.LastName),
  GeehrteFrauHerrNameI = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 3, ' ' + USR.LastName),
  
  GeehrteFrauHerrVornameNameD = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 1, ' ' + REPLACE(dbo.fnGetLastFirstName(NULL, USR.FirstName, USR.LastName), ',', '')),
  GeehrteFrauHerrVornameNameF = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 2, ' ' + REPLACE(dbo.fnGetLastFirstName(NULL, USR.FirstName, USR.LastName), ',', '')),
  GeehrteFrauHerrVornameNameI = dbo.fnGetGenderMLTitle(USR.GenderCode, 'dbGeneral', 'SehrGeehrterHerr', 'SehrGeehrteFrau', NULL, 3, ' ' + REPLACE(dbo.fnGetLastFirstName(NULL, USR.FirstName, USR.LastName), ',', '')),
  
  AbteilungID        = ORG.OrgUnitID,
  AbteilungPCKonto   = ORG.PCKonto,
  AbteilungKGS       = AdresseKGS,
  AbteilungAbteilung = AdresseAbteilung,
  AbteilungStrasse   = ORG.AdresseStrasse,
  AbteilungHausNr    = ORG.AdresseHausNr,
  AbteilungPLZ       = ORG.AdressePLZ,
  AbteilungOrt       = ORG.AdresseOrt,

  AbteilungPostfachD = dbo.fnXGetPostfachTextML(ORG.Postfach, ORG.PostfachOhneNr, 1),
  AbteilungPostfachF = dbo.fnXGetPostfachTextML(ORG.Postfach, ORG.PostfachOhneNr, 2),
  AbteilungPostfachI = dbo.fnXGetPostfachTextML(ORG.Postfach, ORG.PostfachOhneNr, 3),
  
  AbteilungStrasseNr = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 1, 0, 'orgunit', 0, 0, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 0, 0),
  AbteilungPLZOrt    = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 1, 0, 'orgunit', 0, 0, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0),
  
  AbteilungAdresseEinzD = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 1, 0, 'orgunit', 0, 0, NULL, NULL, 0, 1, 1, 0, 1, 0, 0, 0, 0),
  AbteilungAdresseEinzF = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 2, 0, 'orgunit', 0, 0, NULL, NULL, 0, 1, 1, 0, 1, 0, 0, 0, 0),
  AbteilungAdresseEinzI = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 3, 0, 'orgunit', 0, 0, NULL, NULL, 0, 1, 1, 0, 1, 0, 0, 0, 0),
  
  AbteilungAdresseMehrzD = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 1, 1, 'orgunit', 0, 0, NULL, NULL, 0, 1, 1, 0, 1, 0, 0, 0, 0),
  AbteilungAdresseMehrzF = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 2, 1, 'orgunit', 0, 0, NULL, NULL, 0, 1, 1, 0, 1, 0, 0, 0, 0),
  AbteilungAdresseMehrzI = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 3, 1, 'orgunit', 0, 0, NULL, NULL, 0, 1, 1, 0, 1, 0, 0, 0, 0),
  
  AbteilungPostfachAdrMehrzD = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 1, 1, 'orgunit', 0, 0, NULL, NULL, 0, 0, 1, 1, 1, 0, 0, 0, 0),
  AbteilungPostfachAdrMehrzF = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 2, 1, 'orgunit', 0, 0, NULL, NULL, 0, 0, 1, 1, 1, 0, 0, 0, 0),
  AbteilungPostfachAdrMehrzI = dbo.fnGetFlexibleAdress(USR.UserID, NULL, 3, 1, 'orgunit', 0, 0, NULL, NULL, 0, 0, 1, 1, 1, 0, 0, 0, 0),

  AbteilungTelefon  = ORG.Telefon,
  AbteilungFax      = ORG.Fax,
  AbteilungEMail    = ORG.EMail,
  AbteilungInternet = ORG.Internet
  
FROM dbo.XUser USR WITH (READUNCOMMITTED)
  LEFT JOIN dbo.XOrgUnit ORG WITH (READUNCOMMITTED) ON ORG.OrgUnitID = CONVERT(INT, dbo.fnOrgUnitOfUser(USR.UserID, 1))  -- member only
GO