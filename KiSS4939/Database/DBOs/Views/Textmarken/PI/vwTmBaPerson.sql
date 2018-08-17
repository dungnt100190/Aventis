SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmBaPerson;
GO
/*===============================================================================================
  $Revision: 26 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this view to get textmarken for BaPerson
  -
  RETURNS: All bookmarks for client within BaPerson
=================================================================================================
  TEST:    SELECT TOP 30 * FROM dbo.vwTmBaPerson WHERE BaPersonID = 74660;
           SELECT TOP 30 * FROM dbo.vwTmBaPerson WHERE BaPersonID = 87159;
           SELECT TOP 30 * FROM dbo.vwTmBaPerson WHERE BaPersonID = 77771; -- affentranger gil
=================================================================================================*/

CREATE VIEW dbo.vwTmBaPerson
AS
SELECT
  -----------------------------------------------------------------------------
  -- IDs
  -----------------------------------------------------------------------------
  PRS.BaPersonID,
  PersonenNr = PRS.BaPersonID,

  -----------------------------------------------------------------------------
  -- Titel, Name, Anschrift
  -----------------------------------------------------------------------------
  PRS.Titel,
  PRS.Name,
  PRS.Vorname,
  PRS.FruehererName,
  NameVorname          = dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname),
  NameVornameOhneKomma = REPLACE(dbo.fnGetLastFirstName(NULL, PRS.Name, PRS.Vorname), ',', ''),
  VornameName          = REPLACE(dbo.fnGetLastFirstName(NULL, PRS.Vorname, PRS.Name), ',', ''),
  
  FrauHerrVornameNameD = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 1, 'famherrfrau', ' ', PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede) + ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
  FrauHerrVornameNameF = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 2, 'famherrfrau', ' ', PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede) + ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
  FrauHerrVornameNameI = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 3, 'famherrfrau', ' ', PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede) + ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
  
  -- INFO: fnBaGetAnredeAnschrift with value <geehrte> will return <Sehr geehrte Frau>, <Sehr geehrter Herr>, <Sehr geehrte Familie> 
  -- --> better would be to rename GeehrteFrauHerr... to GeehrteFrauHerrFam... (as done with GeehrteFrauHerrFamD/F/I)
  
  GeehrteFrauHerrFamD = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 1, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
  GeehrteFrauHerrFamF = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 2, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
  GeehrteFrauHerrFamI = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 3, 'geehrte', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
  
  GeehrteFrauHerrNameD = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 1, 'geehrte', ' ', PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede) + PRS.Name,
  GeehrteFrauHerrNameF = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 2, 'geehrte', ' ', PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede) + PRS.Name,
  GeehrteFrauHerrNameI = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 3, 'geehrte', ' ', PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede) + PRS.Name,
  
  GeehrteFrauHerrVornameNameD = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 1, 'geehrte', ' ', PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede) + ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
  GeehrteFrauHerrVornameNameF = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 2, 'geehrte', ' ', PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede) + ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
  GeehrteFrauHerrVornameNameI = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 3, 'geehrte', ' ', PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede) + ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
  
  FrauHerrD = dbo.fnGetGenderMLTitle(PRS.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 1, ''),
  FrauHerrF = dbo.fnGetGenderMLTitle(PRS.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 2, ''),
  FrauHerrI = dbo.fnGetGenderMLTitle(PRS.GeschlechtCode, 'dbGeneral', 'Herr', 'Frau', NULL, 3, ''),
  
  FrauHerrFamD = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 1, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
  FrauHerrFamF = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 2, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
  FrauHerrFamI = dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 3, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede),
  
  -----------------------------------------------------------------------------
  -- Person
  -----------------------------------------------------------------------------
  Geburtsdatum       = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
  GeburtsdatumDDMMYY = CONVERT(VARCHAR, PRS.Geburtsdatum, 4),
  Sterbedatum        = CONVERT(VARCHAR, PRS.Sterbedatum, 104),
  PRS.AHVNummer,
  PRS.VersichertenNummer,
  
  -- without text
  AHVNummerBedingt          = COALESCE(PRS.AHVNummer, PRS.VersichertenNummer),
  VersichertenNrBedingt     = COALESCE(PRS.VersichertenNummer, PRS.AHVNummer),
  
  -- with text
  AHVNummerBedingtD         = COALESCE(dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 1)  + ' ' + PRS.AHVNummer, 
                                       dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 1) + ' ' + PRS.VersichertenNummer),
  AHVNummerBedingtF         = COALESCE(dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 2)  + ' ' + PRS.AHVNummer, 
                                       dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 2) + ' ' + PRS.VersichertenNummer),
  AHVNummerBedingtI         = COALESCE(dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 3)  + ' ' + PRS.AHVNummer, 
                                       dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 3) + ' ' + PRS.VersichertenNummer),
  
  VersichertenNrBedingtD    = COALESCE(dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 1) + ' ' + PRS.VersichertenNummer, 
                                       dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 1)  + ' ' + PRS.AHVNummer),
  VersichertenNrBedingtF    = COALESCE(dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 2) + ' ' + PRS.VersichertenNummer, 
                                       dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 2)  + ' ' + PRS.AHVNummer),
  VersichertenNrBedingtI    = COALESCE(dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 3) + ' ' + PRS.VersichertenNummer, 
                                       dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 3)  + ' ' + PRS.AHVNummer),
  
  -- both together
  VersNrAHVNrBedingtD       = CASE WHEN PRS.VersichertenNummer IS NULL     AND PRS.AHVNummer IS NULL     THEN ''                                                                                            -- none
                                   WHEN PRS.VersichertenNummer IS NOT NULL AND PRS.AHVNummer IS NULL     THEN dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 1) + ' ' + PRS.VersichertenNummer              -- only VersNr
                                   WHEN PRS.VersichertenNummer IS NULL     AND PRS.AHVNummer IS NOT NULL THEN dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 1) + ' ' + PRS.AHVNummer                        -- only AHVNr
                                   ELSE dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 1) + ' ' + PRS.VersichertenNummer + ', ' + dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 1)  + ' ' + PRS.AHVNummer   -- both
                              END,
  VersNrAHVNrBedingtF       = CASE WHEN PRS.VersichertenNummer IS NULL     AND PRS.AHVNummer IS NULL     THEN ''                                                                                            -- none
                                   WHEN PRS.VersichertenNummer IS NOT NULL AND PRS.AHVNummer IS NULL     THEN dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 2) + ' ' + PRS.VersichertenNummer              -- only VersNr
                                   WHEN PRS.VersichertenNummer IS NULL     AND PRS.AHVNummer IS NOT NULL THEN dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 2) + ' ' + PRS.AHVNummer                        -- only AHVNr
                                   ELSE dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 2) + ' ' + PRS.VersichertenNummer + ', ' + dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 2)  + ' ' + PRS.AHVNummer   -- both
                              END,
  VersNrAHVNrBedingtI       = CASE WHEN PRS.VersichertenNummer IS NULL     AND PRS.AHVNummer IS NULL     THEN ''                                                                                            -- none
                                   WHEN PRS.VersichertenNummer IS NOT NULL AND PRS.AHVNummer IS NULL     THEN dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 3) + ' ' + PRS.VersichertenNummer              -- only VersNr
                                   WHEN PRS.VersichertenNummer IS NULL     AND PRS.AHVNummer IS NOT NULL THEN dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 3) + ' ' + PRS.AHVNummer                        -- only AHVNr
                                   ELSE dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'VersNr', 3) + ' ' + PRS.VersichertenNummer + ', ' + dbo.fnXDbObjectMLMsg('vwTmBaPerson', 'AHVNr', 3)  + ' ' + PRS.AHVNummer   -- both
                              END,
  
  GeschlechtD = dbo.fnGetLOVMLText('Geschlecht', PRS.GeschlechtCode, 1),
  GeschlechtF = dbo.fnGetLOVMLText('Geschlecht', PRS.GeschlechtCode, 2),
  GeschlechtI = dbo.fnGetLOVMLText('Geschlecht', PRS.GeschlechtCode, 3),
  
  ZivilstandD = dbo.fnGetLOVMLText('Zivilstand', PRS.ZivilstandCode, 1),
  ZivilstandF = dbo.fnGetLOVMLText('Zivilstand', PRS.ZivilstandCode, 2),
  ZivilstandI = dbo.fnGetLOVMLText('Zivilstand', PRS.ZivilstandCode, 3),
  
  NationalitaetD = dbo.fnGetCountryName(PRS.NationalitaetCode, 1, 0),
  NationalitaetF = dbo.fnGetCountryName(PRS.NationalitaetCode, 2, 0),
  NationalitaetI = dbo.fnGetCountryName(PRS.NationalitaetCode, 3, 0),
  
  PLZHeimatort            = GDE.PLZ,
  PLZOrtHeimatort         = dbo.fnGetAdressText(PRS.BaPersonID, 0, 3),
  Heimatort               = dbo.fnGetMLTextByDefault(GDE.NameTID, 1, GDE.Name),  -- because of current usage, we leave this one (=HeimatortD)
  HeimatortD              = dbo.fnGetMLTextByDefault(GDE.NameTID, 1, GDE.Name),
  HeimatortF              = dbo.fnGetMLTextByDefault(GDE.NameTID, 2, GDE.Name),
  HeimatortI              = dbo.fnGetMLTextByDefault(GDE.NameTID, 3, GDE.Name),
  HeimatortNationalitaetD = dbo.fnGetCountryName(147, 1, 0), -- always Switzerland because of Heimatort
  HeimatortNationalitaetF = dbo.fnGetCountryName(147, 2, 0), -- always Switzerland because of Heimatort
  HeimatortNationalitaetI = dbo.fnGetCountryName(147, 3, 0), -- always Switzerland because of Heimatort
  
  HauptbehinderungsartD = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, 1),
  HauptbehinderungsartF = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, 2),
  HauptbehinderungsartI = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.HauptBehinderungsartCode, 3),
  
  Behinderungsart2D = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.Behinderungsart2Code, 1),
  Behinderungsart2F = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.Behinderungsart2Code, 2),
  Behinderungsart2I = dbo.fnGetLOVMLText('BaBehinderungsart', PRS.Behinderungsart2Code, 3),
  
  BSVBehinderungsartD = dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, 1),
  BSVBehinderungsartF = dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, 2),
  BSVBehinderungsartI = dbo.fnGetLOVMLText('BaBSVBehinderungsart', PRS.BSVBehinderungsartCode, 3),
  
  MehrfachbehinderungD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.Mehrfachbehinderung, 0), 1),
  MehrfachbehinderungF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.Mehrfachbehinderung, 0), 2),
  MehrfachbehinderungI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.Mehrfachbehinderung, 0), 3),
  
  SpracheD = dbo.fnGetLOVMLText('BaSprache', PRS.SprachCode, 1),
  SpracheF = dbo.fnGetLOVMLText('BaSprache', PRS.SprachCode, 2),
  SpracheI = dbo.fnGetLOVMLText('BaSprache', PRS.SprachCode, 3),
  
  KorrespondenzSpracheD = dbo.fnGetLOVMLText('BaKorrespondenzSprache', PRS.KorrespondenzSpracheCode, 1),
  KorrespondenzSpracheF = dbo.fnGetLOVMLText('BaKorrespondenzSprache', PRS.KorrespondenzSpracheCode, 2),
  KorrespondenzSpracheI = dbo.fnGetLOVMLText('BaKorrespondenzSprache', PRS.KorrespondenzSpracheCode, 3),
  
  InCHSeit        = CONVERT(varchar, PRS.InCHSeit, 104),
  InCHSeitGeburtD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.InCHSeitGeburt, 0), 1),
  InCHSeitGeburtF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.InCHSeitGeburt, 0), 2),
  InCHSeitGeburtI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.InCHSeitGeburt, 0), 3),
  
  AufenthaltsstatusD = dbo.fnGetLOVMLText('BaAuslaenderAufenthaltStatus', PRS.AuslaenderStatusCode, 1),
  AufenthaltsstatusF = dbo.fnGetLOVMLText('BaAuslaenderAufenthaltStatus', PRS.AuslaenderStatusCode, 2),
  AufenthaltsstatusI = dbo.fnGetLOVMLText('BaAuslaenderAufenthaltStatus', PRS.AuslaenderStatusCode, 3),
  
  ErwerbssituationD = dbo.fnGetLOVMLText('BaErwerbssituation', PRS.ErwerbssituationCode, 1),
  ErwerbssituationF = dbo.fnGetLOVMLText('BaErwerbssituation', PRS.ErwerbssituationCode, 2),
  ErwerbssituationI = dbo.fnGetLOVMLText('BaErwerbssituation', PRS.ErwerbssituationCode, 3),
  
  AusbildungD = dbo.fnGetLOVMLText('BaAusbildungCode', PRS.AusbildungCode, 1),
  AusbildungF = dbo.fnGetLOVMLText('BaAusbildungCode', PRS.AusbildungCode, 2),
  AusbildungI = dbo.fnGetLOVMLText('BaAusbildungCode', PRS.AusbildungCode, 3),
  
  VormundschMassnahmeD = dbo.fnGetLOVMLText('BaVormundMassnahmen', PRS.VormundMassnahmenCode, 1),
  VormundschMassnahmeF = dbo.fnGetLOVMLText('BaVormundMassnahmen', PRS.VormundMassnahmenCode, 2),
  VormundschMassnahmeI = dbo.fnGetLOVMLText('BaVormundMassnahmen', PRS.VormundMassnahmenCode, 3),
  
  VormMassnahmeDurchPID = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.VormundPI, 0), 1),
  VormMassnahmeDurchPIF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.VormundPI, 0), 2),
  VormMassnahmeDurchPII = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.VormundPI, 0), 3),
  
  IVBerechtigungStatusD = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, NULL, 0), 1),
  IVBerechtigungStatusF = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, NULL, 0), 2),
  IVBerechtigungStatusI = dbo.fnGetLOVMLText('BaIVBerechtigung', dbo.fnBaGetIVBerechtigungStatus(PRS.BaPersonID, NULL, 0), 3),
  
  PRS.WichtigerHinweis,
  BemerkungenPersonalienNORTF = PRS.Bemerkung,
  
  -----------------------------------------------------------------------------
  -- bookmarks for family relations (see #4796)
  -----------------------------------------------------------------------------
  ElternTeil1EhePartnerIn = dbo.fnBaGetFamilienmitgliederData(PRS.BaPersonID, 'elternteil1', 1),
  ElternTeil2             = dbo.fnBaGetFamilienmitgliederData(PRS.BaPersonID, 'elternteil2', 1),
  GeschwisterKind1        = dbo.fnBaGetFamilienmitgliederData(PRS.BaPersonID, 'kind1', 1),
  GeschwisterKind2        = dbo.fnBaGetFamilienmitgliederData(PRS.BaPersonID, 'kind2', 1),
  GeschwisterKind3        = dbo.fnBaGetFamilienmitgliederData(PRS.BaPersonID, 'kind3', 1),
  GeschwisterKind4        = dbo.fnBaGetFamilienmitgliederData(PRS.BaPersonID, 'kind4', 1),
  GeschwisterKind5        = dbo.fnBaGetFamilienmitgliederData(PRS.BaPersonID, 'kind5', 1),
  GeschwisterKind6        = dbo.fnBaGetFamilienmitgliederData(PRS.BaPersonID, 'kind6', 1),

  -----------------------------------------------------------------------------
  -- etc.
  -----------------------------------------------------------------------------
  TelefonP = Telefon_P,
  TelefonG = Telefon_G,
  TelefonM = MobilTel,
  
  PRS.Fax,
  PRS.EMail,
  
  KontofuehrungD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.KontoFuehrung, 0), 1),
  KontofuehrungF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.KontoFuehrung, 0), 2),
  KontofuehrungI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.KontoFuehrung, 0), 3),
  
  PRS.DebitorNr,
  PRS.KlientenkontoNr,
  -----------------------------------------------------------------------------
  -- Bank/Post
  -----------------------------------------------------------------------------
  BankPostName          = BNK.Name,
  BankPostESTypD        = dbo.fnGetLOVMLText('BgEinzahlungsschein', ZLW.EinzahlungsscheinCode, 1),
  BankPostESTypF        = dbo.fnGetLOVMLText('BgEinzahlungsschein', ZLW.EinzahlungsscheinCode, 2),
  BankPostESTypI        = dbo.fnGetLOVMLText('BgEinzahlungsschein', ZLW.EinzahlungsscheinCode, 3),
  BankPostIBANNr        = ZLW.IBANNummer,
  --
  BankPostKontoNr        = COALESCE(ZLW.BankKontoNummer, dbo.fnTnToPc(ZLW.PostKontoNummer)),
  BankPostPCKontoNr      = dbo.fnTnToPc(COALESCE(BNK.PCKontoNr, ZLW.PostKontoNummer)),
  BankPostPostKontoNr    = dbo.fnTnToPc(ZLW.PostKontoNummer),
  BankPostBankKontoNr    = ZLW.BankKontoNummer,
  BankPostBankPCKontoNr  = dbo.fnTnToPc(BNK.PCKontoNr),
  BankPostBankClearingNr = BNK.ClearingNr,
  --
  BankPostAdresseEinzD  = CASE
                            WHEN ZLW.BaBankID IS NULL 
                              THEN dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 1, 0, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                            ELSE dbo.fnGetFlexibleAdress(ZLW.BaBankID, NULL, 1, 0, 'babank', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                          END,
  BankPostAdresseEinzF  = CASE
                            WHEN ZLW.BaBankID IS NULL 
                              THEN dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 2, 0, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                            ELSE dbo.fnGetFlexibleAdress(ZLW.BaBankID, NULL, 2, 0, 'babank', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                          END,
  BankPostAdresseEinzI  = CASE
                            WHEN ZLW.BaBankID IS NULL 
                              THEN dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 3, 0, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                            ELSE dbo.fnGetFlexibleAdress(ZLW.BaBankID, NULL, 3, 0, 'babank', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                          END,
  --
  BankPostAdresseMehrzD = CASE
                            WHEN ZLW.BaBankID IS NULL 
                              THEN dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 1, 1, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                            ELSE dbo.fnGetFlexibleAdress(ZLW.BaBankID, NULL, 1, 1, 'babank', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                          END,
  BankPostAdresseMehrzF = CASE
                            WHEN ZLW.BaBankID IS NULL 
                              THEN dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 2, 1, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                            ELSE dbo.fnGetFlexibleAdress(ZLW.BaBankID, NULL, 2, 1, 'babank', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                          END,
  BankPostAdresseMehrzI = CASE
                            WHEN ZLW.BaBankID IS NULL 
                              THEN dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 3, 1, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                            ELSE dbo.fnGetFlexibleAdress(ZLW.BaBankID, NULL, 3, 1, 'babank', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)
                          END,
  --
  BankPostZahlungFuerEinzD = dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 1, 0, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  BankPostZahlungFuerEinzF = dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 2, 0, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  BankPostZahlungFuerEinzI = dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 3, 0, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  --
  BankPostZahlungFuerMehrzD = dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 1, 1, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  BankPostZahlungFuerMehrzF = dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 2, 1, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  BankPostZahlungFuerMehrzI = dbo.fnGetFlexibleAdress(ZLW.BaZahlungswegID, NULL, 3, 1, 'bazahlungsweg', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  -----------------------------------------------------------------------------
  -- Wohnung
  -----------------------------------------------------------------------------
  WohnstatusCodeD = dbo.fnGetLOVMLText('BaWohnstatus', PRS.WohnstatusCode, 1),
  WohnstatusCodeF = dbo.fnGetLOVMLText('BaWohnstatus', PRS.WohnstatusCode, 2),
  WohnstatusCodeI = dbo.fnGetLOVMLText('BaWohnstatus', PRS.WohnstatusCode, 3),
  
  MietdepotPID = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.MietdepotPI, 0), 1),
  MietdepotPIF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.MietdepotPI, 0), 2),
  MietdepotPII = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.MietdepotPI, 0), 3),
  
  EigenerMietvertragD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.EigenerMietvertrag, 0), 1),
  EigenerMietvertragF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.EigenerMietvertrag, 0), 2),
  EigenerMietvertragI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.EigenerMietvertrag, 0), 3),
  
  -----------------------------------------------------------------------------
  -- Sozialversicherung
  -----------------------------------------------------------------------------
  -- HELB
  HELBKeinAntragD     = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.HELBKeinAntrag, 0), 1),
  HELBKeinAntragF     = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.HELBKeinAntrag, 0), 2),
  HELBKeinAntragI     = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.HELBKeinAntrag, 0), 3),
  
  HELBAnmeldung       = CONVERT(VARCHAR, PRS.HELBAnmeldung, 104),
  HELBEntscheidDat    = CONVERT(VARCHAR, PRS.HELBEntscheid, 104),

  HELBEntscheidD      = dbo.fnGetLOVMLText('BaHELBEntscheid', PRS.HELBEntscheidCode, 1),
  HELBEntscheidF      = dbo.fnGetLOVMLText('BaHELBEntscheid', PRS.HELBEntscheidCode, 2),
  HELBEntscheidI      = dbo.fnGetLOVMLText('BaHELBEntscheid', PRS.HELBEntscheidCode, 3),
  
  HELBEntscheidAbWann = PRS.HELBAb,

  SvRentenstufeD = dbo.fnGetLOVMLText('BaRentenstufe', PRS.RentenstufeCode, 1),
  SvRentenstufeF = dbo.fnGetLOVMLText('BaRentenstufe', PRS.RentenstufeCode, 2),
  SvRentenstufeI = dbo.fnGetLOVMLText('BaRentenstufe', PRS.RentenstufeCode, 3),
  
  SvIvGrad = PRS.IVGrad,
  
  SvHilfslosenEntschaedigungD = dbo.fnGetLOVMLText('BaHilfslosenEntschaedigung', PRS.HilfslosenEntschaedigungCode, 1),
  SvHilfslosenEntschaedigungF = dbo.fnGetLOVMLText('BaHilfslosenEntschaedigung', PRS.HilfslosenEntschaedigungCode, 2),
  SvHilfslosenEntschaedigungI = dbo.fnGetLOVMLText('BaHilfslosenEntschaedigung', PRS.HilfslosenEntschaedigungCode, 3),
  
  SvIntensivPflegeZuschlagD = dbo.fnGetLOVMLText('BaIntensivpflegeZuschlag', PRS.IntensivPflegeZuschlagCode, 1),
  SvIntensivPflegeZuschlagF = dbo.fnGetLOVMLText('BaIntensivpflegeZuschlag', PRS.IntensivPflegeZuschlagCode, 2),
  SvIntensivPflegeZuschlagI = dbo.fnGetLOVMLText('BaIntensivpflegeZuschlag', PRS.IntensivPflegeZuschlagCode, 3),
  
  SvIVTaggeldD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.IVTaggeld, 0), 1),
  SvIVTaggeldF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.IVTaggeld, 0), 2),
  SvIVTaggeldI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.IVTaggeld, 0), 3),
  
  SvBeruflicheMassnahmeIVD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.BeruflicheMassnahmeIV, 0), 1),
  SvBeruflicheMassnahmeIVF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.BeruflicheMassnahmeIV, 0), 2),
  SvBeruflicheMassnahmeIVI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.BeruflicheMassnahmeIV, 0), 3),
  
  SvMedizinischeMassnahmeIVD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.MedizinischeMassnahmeIV, 0), 1),
  SvMedizinischeMassnahmeIVF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.MedizinischeMassnahmeIV, 0), 2),
  SvMedizinischeMassnahmeIVI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.MedizinischeMassnahmeIV, 0), 3),
  
  SvIVHilfsmittelD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.IVHilfsmittel, 0), 1),
  SvIVHilfsmittelF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.IVHilfsmittel, 0), 2),
  SvIVHilfsmittelI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.IVHilfsmittel, 0), 3),
  
  SvErgaenzungsLeistungenD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.ErgaenzungsLeistungen, 0), 1),
  SvErgaenzungsLeistungenF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.ErgaenzungsLeistungen, 0), 2),
  SvErgaenzungsLeistungenI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.ErgaenzungsLeistungen, 0), 3),
  
  SvBVGRenteD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.BVGRente, 0), 1),
  SvBVGRenteF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.BVGRente, 0), 2),
  SvBVGRenteI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.BVGRente, 0), 3),
  
  SvUVGRenteD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.UVGRente, 0), 1),
  SvUVGRenteF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.UVGRente, 0), 2),
  SvUVGRenteI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.UVGRente, 0), 3),
  
  SvUVGTaggeldD =  dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.UVGTaggeld, 0), 1),
  SvUVGTaggeldF =  dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.UVGTaggeld, 0), 2),
  SvUVGTaggeldI =  dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.UVGTaggeld, 0), 3),
  
  SvSozialhilfeD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.Sozialhilfe, 0), 1),
  SvSozialhilfeF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.Sozialhilfe, 0), 2),
  SvSozialhilfeI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.Sozialhilfe, 0), 3),
  
  SvALKD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.ALK, 0), 1),
  SvALKF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.ALK, 0), 2),
  SvALKI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.ALK, 0), 3),
  
  SvKTGD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.KTG, 0), 1),
  SvKTGF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.KTG, 0), 2),
  SvKTGI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.KTG, 0), 3),
  
  SvWittwenWittwerWaisenrenteD = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.WittwenWittwerWaisenrente, 0), 1),
  SvWittwenWittwerWaisenrenteF = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.WittwenWittwerWaisenrente, 0), 2),
  SvWittwenWittwerWaisenrenteI = dbo.fnGetLOVMLText('JaNein', ISNULL(PRS.WittwenWittwerWaisenrente, 0), 3),
  
  SvAndereSVLeistungen = PRS.AndereSVLeistungen,
  SvBemerkungen = PRS.BemerkungenSV,
  
  -----------------------------------------------------------------------------
  -- Wohnsitz
  -----------------------------------------------------------------------------
  WohnsitzZusatz    = ADRW.Zusatz,
  WohnsitzStrasse   = ADRW.Strasse,
  WohnsitzHausNr    = ADRW.HausNr,
  WohnsitzPostfachD = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1),
  WohnsitzPostfachF = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 2),
  WohnsitzPostfachI = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 3),
  WohnsitzPLZ       = ADRW.PLZ,
  WohnsitzOrt       = ADRW.Ort,
  WohnsitzKanton    = ADRW.Kanton,
  WohnsitzBezirk    = ADRW.Bezirk,
  
  WohnsitzLandD = dbo.fnGetCountryName(ADRW.BaLandID, 1, 0),
  WohnsitzLandF = dbo.fnGetCountryName(ADRW.BaLandID, 2, 0),
  WohnsitzLandI = dbo.fnGetCountryName(ADRW.BaLandID, 3, 0),
  
  WohnsitzAdresseEinzD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'wohnsitz', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseEinzF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 0, 'wohnsitz', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseEinzI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 0, 'wohnsitz', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  WohnsitzAdresseEinzOhneKommaD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 2, 'wohnsitz', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseEinzOhneKommaF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 2, 'wohnsitz', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseEinzOhneKommaI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 2, 'wohnsitz', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  WohnsitzAdresseEinzOhneNameD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseEinzOhneNameF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 0, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseEinzOhneNameI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 0, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  WohnsitzAdresseEinzOhneNameOhneKommaD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 2, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseEinzOhneNameOhneKommaF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 2, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseEinzOhneNameOhneKommaI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 2, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  WohnsitzAdresseMehrzD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'wohnsitz', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseMehrzF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'wohnsitz', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseMehrzI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'wohnsitz', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  WohnsitzAdresseMehrzOhneNameD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseMehrzOhneNameF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  WohnsitzAdresseMehrzOhneNameI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'wohnsitz', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  WohnsitzStrasseNr = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'wohnsitz', 0, 0, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 0, 0),
  WohnsitzPLZOrt    = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'wohnsitz', 0, 0, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0),
  
  -----------------------------------------------------------------------------
  -- Aufenthalt
  -----------------------------------------------------------------------------
  AufenthaltName      = ADRA.CareOf,
  AufenthaltZusatz    = ADRA.Zusatz,
  AufenthaltStrasse   = ADRA.Strasse,
  AufenthaltHausNr    = ADRA.HausNr,
  AufenthaltPostfachD = dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1),
  AufenthaltPostfachF = dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 2),
  AufenthaltPostfachI = dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 3),
  AufenthaltPLZ       = ADRA.PLZ,
  AufenthaltOrt       = ADRA.Ort,
  AufenthaltKanton    = ADRA.Kanton,
  AufenthaltBezirk    = ADRA.Bezirk,
  
  AufenthaltLandD = dbo.fnLandMLText(ADRA.BaLandID, 1),
  AufenthaltLandF = dbo.fnLandMLText(ADRA.BaLandID, 2),
  AufenthaltLandI = dbo.fnLandMLText(ADRA.BaLandID, 3),
  
  AufenthaltAdresseEinzD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'aufenthalt', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AufenthaltAdresseEinzF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 0, 'aufenthalt', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AufenthaltAdresseEinzI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 0, 'aufenthalt', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  AufenthaltAdresseEinzOhneNameD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'aufenthalt', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AufenthaltAdresseEinzOhneNameF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 0, 'aufenthalt', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AufenthaltAdresseEinzOhneNameI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 0, 'aufenthalt', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  AufenthaltAdresseMehrzD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'aufenthalt', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AufenthaltAdresseMehrzF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'aufenthalt', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AufenthaltAdresseMehrzI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'aufenthalt', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  AufenthaltAdresseMehrzOhneNameD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'aufenthalt', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AufenthaltAdresseMehrzOhneNameF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'aufenthalt', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AufenthaltAdresseMehrzOhneNameI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'aufenthalt', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  AufenthaltStrasseNr = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'aufenthalt', 0, 0, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 0, 0),
  AufenthaltPLZOrt    = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'aufenthalt', 0, 0, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0),
  
  -----------------------------------------------------------------------------
  -- Post
  -----------------------------------------------------------------------------
  PostName        = ADRP.CareOf,
  PostZusatz      = ADRP.Zusatz,
  PostZuhandenVon = ADRP.ZuhandenVon,
  PostStrasse     = ADRP.Strasse,
  PostHausNr      = ADRP.HausNr,
  PostPostfachD   = dbo.fnBaGetPostfachText(NULL, ADRP.Postfach, ADRP.PostfachOhneNr, 1),
  PostPostfachF   = dbo.fnBaGetPostfachText(NULL, ADRP.Postfach, ADRP.PostfachOhneNr, 2),
  PostPostfachI   = dbo.fnBaGetPostfachText(NULL, ADRP.Postfach, ADRP.PostfachOhneNr, 3),
  PostPLZ         = ADRP.PLZ,
  PostOrt         = ADRP.Ort,
  PostKanton      = ADRP.Kanton,
  PostBezirk      = ADRP.Bezirk,
  
  PostLandD = dbo.fnLandMLText(ADRP.BaLandID, 1),
  PostLandF = dbo.fnLandMLText(ADRP.BaLandID, 2),
  PostLandI = dbo.fnLandMLText(ADRP.BaLandID, 3),
  
  PostAdresseEinzD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'post', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  PostAdresseEinzF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 0, 'post', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  PostAdresseEinzI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 0, 'post', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  PostAdresseEinzOhneNameD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'post', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  PostAdresseEinzOhneNameF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 0, 'post', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  PostAdresseEinzOhneNameI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 0, 'post', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  PostAdresseMehrzD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'post', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  PostAdresseMehrzF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'post', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  PostAdresseMehrzI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'post', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  PostAdresseMehrzOhneNameD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'post', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  PostAdresseMehrzOhneNameF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'post', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  PostAdresseMehrzOhneNameI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'post', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  PostStrasseNr = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'post', 0, 0, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 0, 0),
  PostPLZOrt    = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'post', 0, 0, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0),
  
  -----------------------------------------------------------------------------
  -- Anschrift
  -----------------------------------------------------------------------------
  AnschriftAdresseEinzD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'anschrift', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AnschriftAdresseEinzF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 0, 'anschrift', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AnschriftAdresseEinzI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 0, 'anschrift', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  AnschriftAdresseEinzOhneNameD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'anschrift', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AnschriftAdresseEinzOhneNameF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 0, 'anschrift', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AnschriftAdresseEinzOhneNameI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 0, 'anschrift', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  -- included Frau/Herr
  AnschriftAdresseMehrzD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'anschrift', 1, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 1, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AnschriftAdresseMehrzF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'anschrift', 1, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 2, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AnschriftAdresseMehrzI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'anschrift', 1, 1, 'vornach', dbo.fnBaGetAnredeAnschriftBaPerson(NULL, NULL, PRS.Geburtsdatum, PRS.Sterbedatum, PRS.GeschlechtCode, 3, 'famherrfrau', NULL, PRS.ManuelleAnrede, PRS.Anrede, PRS.Briefanrede), 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  AnschriftAdresseMehrzOhneNameD = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'anschrift', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AnschriftAdresseMehrzOhneNameF = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'anschrift', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  AnschriftAdresseMehrzOhneNameI = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'anschrift', 0, 0, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  AnschriftStrasseNr = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'anschrift', 0, 0, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 0, 0),
  AnschriftPLZOrt    = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 0, 'anschrift', 0, 0, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 0, 0),
  
  -----------------------------------------------------------------------------
  -- Rechnungsadressen
  -----------------------------------------------------------------------------
  RechnAdrED1D = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'raed1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  RechnAdrED1F = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'raed1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  RechnAdrED1I = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'raed1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  RechnAdrED2D = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'raed2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  RechnAdrED2F = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'raed2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  RechnAdrED2I = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'raed2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  RechnAdrBW1D = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'rabw1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  RechnAdrBW1F = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'rabw1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  RechnAdrBW1I = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'rabw1', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  
  RechnAdrBW2D = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 1, 1, 'rabw2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  RechnAdrBW2F = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 2, 1, 'rabw2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1),
  RechnAdrBW2I = dbo.fnGetFlexibleAdress(PRS.BaPersonID, NULL, 3, 1, 'rabw2', 0, 1, NULL, NULL, 1, 1, 1, 1, 1, 0, 0, 1, 1)

FROM dbo.BaPerson             PRS  WITH(READUNCOMMITTED)
  -- heimatort
  LEFT JOIN dbo.BaGemeinde    GDE  WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
  
    -- wohnsitz
  LEFT JOIN dbo.BaAdresse     ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)
  
  -- aufenthalt
  LEFT JOIN dbo.BaAdresse     ADRA WITH (READUNCOMMITTED) ON ADRA.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 2, NULL)

  -- post
  LEFT JOIN dbo.BaAdresse     ADRP WITH (READUNCOMMITTED) ON ADRP.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 3, NULL)
  
  -- zahlungsweg (get valid and marked Zahlungsweg)
  LEFT JOIN dbo.BaZahlungsweg ZLW  WITH (READUNCOMMITTED) ON ZLW.BaZahlungswegID = dbo.fnBaGetBaZahlungswegID('BaPersonID', PRS.BaPersonID, 100, NULL)
  LEFT JOIN dbo.BaBank        BNK  WITH (READUNCOMMITTED) ON BNK.BaBankID = ZLW.BaBankID;
GO