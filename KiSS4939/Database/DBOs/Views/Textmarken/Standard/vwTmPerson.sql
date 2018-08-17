SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwTmPerson;
GO
/*===============================================================================================
  $Revision: 28 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View für Textmarke KLIENT
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwTmPerson WITH (READUNCOMMITTED);
=================================================================================================*/

CREATE VIEW dbo.vwTmPerson
AS
SELECT BaPersonID           = PRS.BaPersonID,
       PersonenNr           = PRS.BaPersonID,
       Anrede               = PRS.Titel,
       [Name]               = PRS.Name,
       [FrühererName]       = PRS.FruehererName,
       Vorname              = PRS.Vorname,
       VornameName          = ISNULL(PRS.Vorname + ' ','') + PRS.[Name],
       Vorname2             = PRS.Vorname2,
       NameVorname          = PRS.[Name] + ISNULL(', '+PRS.Vorname,''),
       NameVornameOhneKomma = PRS.[Name] + ISNULL(' '+PRS.Vorname,''),
	   [NameGB]               = UPPER(RTRIM(PRS.Name)),
       NameGBVorname          = UPPER(RTRIM(PRS.Name)) + ISNULL(', '+PRS.Vorname,''),
       NameGBVornameOhneKomma = UPPER(RTRIM(PRS.Name)) + ISNULL(' '+PRS.Vorname,''),
       Nationalitaet        = CASE 
                                WHEN dbo.fnLandMLText(PRS.NationalitaetCode, NULL) IS NULL 
                                 AND GDE.Name IS NOT NULL  THEN 'Schweiz' -- Nationalität leer + Heimatort erfasst => 'Schweiz'
                                ELSE dbo.fnLandMLText(PRS.NationalitaetCode, NULL)
                              END,
       GeschlechtCode       = PRS.GeschlechtCode,
       Geschlecht           = dbo.fnLOVText('Geschlecht', PRS.GeschlechtCode),

       Geburtsdatum                 = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
       GeburtsdatumAmerikanisch     = CONVERT(VARCHAR, PRS.Geburtsdatum, 111),
       GestorbenAm                  = CONVERT(VARCHAR, PRS.Sterbedatum, 104),
       AHVNummer                    = PRS.AHVNummer,
       Versichertennummer           = PRS.Versichertennummer,
       VersichertennummerSonstAHVNr = ISNULL(PRS.Versichertennummer, PRS.AHVNummer),

       BemerkungOhneFmt       = PRS.Bemerkung,  --ohne RTF-Formatierung
       BemerkungMitFmt        = PRS.Bemerkung,  --mit RTF-Formatierung

       NNummer                = PRS.NNummer,
       BFFNummer              = PRS.BFFNummer,
       HaushaltVersicherungsNummer = PRS.HaushaltVersicherungsNummer,
       
       Konfession             = dbo.fnLOVText('Konfession', PRS.KonfessionCode),
       Heimatort              = GDE.Name + ISNULL(' ' + GDE.Kanton, ''),
       HeimatortNationalitaet = CASE WHEN GDE.Name IS NOT NULL THEN GDE.Name + ISNULL(' ' + GDE.Kanton, '') ELSE dbo.fnLandMLText(PRS.NationalitaetCode, NULL) END,
       HeimatortNationalitaetD = CASE WHEN GDE.Name IS NOT NULL THEN GDE.Name + ISNULL(' ' + GDE.Kanton, '') ELSE dbo.fnLandMLText(PRS.NationalitaetCode, 1) END,
       HeimatortNationalitaetF = CASE WHEN GDE.Name IS NOT NULL THEN GDE.Name + ISNULL(' ' + GDE.Kanton, '') ELSE dbo.fnLandMLText(PRS.NationalitaetCode, 2) END,
       HeimatortNationalitaetI = CASE WHEN GDE.Name IS NOT NULL THEN GDE.Name + ISNULL(' ' + GDE.Kanton, '') ELSE dbo.fnLandMLText(PRS.NationalitaetCode, 3) END,
       PLZHeimatort           = ISNULL(CONVERT(VARCHAR, GDE.PLZ) + ' ','') + GDE.Name,
       
       Sprache                = dbo.fnLOVText('BaMuttersprache', PRS.SprachCode),
       SpracheVertsaendigung  = dbo.fnLOVText('BaVerstaendigungsSprache', PRS.VerstaendigungSprachCode),
       
       Permis                 = dbo.fnLOVText('Aufenthaltsstatus', PRS.AuslaenderStatusCode),
       PermisBis              = CONVERT(VARCHAR, PRS.AuslaenderStatusGueltigBis, 104),
       PermisSeit             = CONVERT(VARCHAR, PRS.ErteilungVA, 104) ,
       
       AufenthaltGueltigBis   = CONVERT(VARCHAR,PRS.AuslaenderStatusGueltigBis,104),
       -- TODO: (IBE)BaPerson.inCHseit vs. (BSS)BaPerson.AuslaenderStatusDatum
       InCHseit               = CONVERT(VARCHAR, PRS.inCHseit, 104),
       EndeZustaendigkeit     = CONVERT(VARCHAR, PRS.CAusweisDatum, 104),
       
       TelefonP               = PRS.Telefon_P,
       TelefonG               = PRS.Telefon_G,
       TelefonMobil           = PRS.MobilTel,
       EMail                  = PRS.EMail,
       Fax                    = PRS.Fax,
       Navigatorzusatz        = PRS.Navigatorzusatz,
       
       WegzugDatum            = PRS.WegzugDatum,
       WegzugOrt              = PRS.WegzugOrt,
       WegzugPLZ              = PRS.WegzugPLZ,
       
       Zivilstand             = dbo.fnLOVText('Zivilstand', PRS.ZivilstandCode),
       ZivilstandD =dbo.fnGetLOVMLText('Zivilstand',PRS.ZivilstandCode,1), 
       ZivilstandF =dbo.fnGetLOVMLText('Zivilstand',PRS.ZivilstandCode,2), 
       ZivilstandI =dbo.fnGetLOVMLText('Zivilstand',PRS.ZivilstandCode,3), 
       ZivilstandSeit         = CONVERT(VARCHAR,PRS.ZivilstandDatum ,104),
       ZuzugDatum             = PRS.ZuzugGdeDatum,
       ZuzugOrt               = PRS.ZuzugGdeOrt,
       ZuzugPLZ               = PRS.ZuzugGdePLZ,
       ZEMISNummer            = PRS.ZEMISNummer,
       
       ------------------------------------------------------------------------
       -- Texte
       ------------------------------------------------------------------------
       ErSie                = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'er'
                                WHEN 2 THEN 'sie'
                                ELSE 'er / sie'
                              END,
       ErSieGross           = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Er'
                                WHEN 2 THEN 'Sie'
                                ELSE 'Er / Sie'
                              END,
       HerrFrau             = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herr'
                                WHEN 2 THEN 'Frau'
                                ELSE ''
                              END,
       HerrFrauName         = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herr '
                                WHEN 2 THEN 'Frau '
                                ELSE ' '
                              END + PRS.Name,
       GeehrterHerrFrau     = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Sehr geehrter Herr'
                                WHEN 2 THEN 'Sehr geehrte Frau'
                                ELSE 'Sehr geehrte/-r Frau/Herr'
                              END,
       GeehrterHerrFrauName = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Sehr geehrter Herr '
                                WHEN 2 THEN 'Sehr geehrte Frau '
                                ELSE 'Sehr geehrte/-r Frau/Herr '
                              END + PRS.Name,
       HerrnFrau            = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herrn'
                                WHEN 2 THEN 'Frau'
                                ELSE ''
                              END,
       HerrnFrauName        = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herrn '
                                WHEN 2 THEN 'Frau '
                                ELSE ' '
                              END + PRS.Name,
       FrauHerrVornameName  = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Herr '
                                WHEN 2 THEN 'Frau '
                                ELSE ''
                              END + ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
       IhmIhr               = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'ihm'
                                WHEN 2 THEN 'ihr'
                                ELSE 'ihm / ihr'
                              END,
       LieberLiebe          = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Lieber'
                                WHEN 2 THEN 'Liebe'
                                ELSE 'Lieber / Liebe'
                              END,
       SeinIhr              = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'sein'
                                WHEN 2 THEN 'ihr'
                                ELSE 'sein / ihr'
                              END,
       SeineIhre            = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'seine'
                                WHEN 2 THEN 'ihre'
                                ELSE 'seine / ihre'
                              END,
       SeinerIhrer          = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'seiner'
                                WHEN 2 THEN 'ihrer'
                                ELSE 'seiner / ihrer'
                              END,
       -- TODO: Auf IBE war es 'Der Projektteilnehmer / Die Projektteilnehmerin'
       ProjektteilnehmerIn  = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Stellensuchender'
                                WHEN 2 THEN 'Stellensuchende'
                                ELSE 'Stellensuchender / Stellensuchende'
                              END,
       TeilnehmerIn         = CASE PRS.GeschlechtCode
                                WHEN 1 THEN 'Der Teilnehmer'
                                WHEN 2 THEN 'Die Teilnehmerin'
                                ELSE 'Der Teilnehmer / Die Teilnehmerin'
                              END,
       
       ------------------------------------------------------------------------
       -- BaAdresse: Aufenthalt
       ------------------------------------------------------------------------
       AufenthaltsortAdresseEinzeilig     = PRS.Vorname + ' ' + PRS.Name + ', ' +
                                            ISNULL(ADRA.Zusatz + ', ','') +
                                            ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,'') + ', ','') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltsortAdresseEinzOhneName  = ISNULL(ADRA.Zusatz + ', ','') +
                                            ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,'') + ', ','') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltsortAdresseMehrzeilig    = PRS.Vorname + ' ' + PRS.Name + CHAR(13) + CHAR(10) +
                                            ISNULL(ADRA.Zusatz + CHAR(13) + CHAR(10),'') +
                                            ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,'') + CHAR(13) + CHAR(10),'') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltsortAdresseMehrzOhneName = ISNULL(ADRA.Zusatz + CHAR(13) + CHAR(10),'') +
                                            ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,'') + CHAR(13) + CHAR(10),'') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltsortStrasseNr            = ADRA.Strasse + ISNULL(' ' + ADRA.HausNr,''),
       AufenthaltsortPLZOrt               = ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, ''),
       AufenthaltWohnortAdrEinzeilig      = PRS.Vorname + ' ' + PRS.Name + ', ' +
                                            CASE
                                              WHEN ADRA.BaAdresseID IS NULL
                                                THEN ISNULL(ADRW.Zusatz + ', ', '') +
                                                     ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                                     ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.Zusatz + ', ', '') +
                                                   ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '') + ', ', '') +
                                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + ', ', '') +
                                                   ISNULL(ADRA.PLZ + ' ', '') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnortAdrEinzOhneName   = CASE 
                                              WHEN ADRA.BaAdresseID IS NULL
                                                THEN ISNULL(ADRW.Zusatz + ', ', '') +
                                                     ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                                     ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.Zusatz + ', ', '') +
                                                   ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '') + ', ', '') +
                                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + ', ', '') +
                                                   ISNULL(ADRA.PLZ + ' ', '') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnortAdrMehrzeilig     = PRS.Vorname + ' ' + PRS.Name + CHAR(13) + CHAR(10) +
                                            CASE
                                              WHEN ADRA.BaAdresseID IS NULL
                                                THEN ISNULL(ADRW.Zusatz + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.Zusatz + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(ADRA.PLZ + ' ', '') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnortAdrMehrzOhneName  = CASE
                                              WHEN ADRA.BaAdresseID IS NULL
                                                THEN ISNULL(ADRW.Zusatz + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                                     ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.Zusatz + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                                   ISNULL(ADRA.PLZ + ' ', '') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnsitzStrasseNr        = CASE
                                              WHEN ADRA.BaAdresseID IS NULL THEN ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '')
                                              ELSE ADRA.Strasse + ISNULL(' ' + ADRA.HausNr, '')
                                            END,
       AufenthaltWohnsitzPLZOrt           = CASE
                                              WHEN ADRA.BaAdresseID IS NULL THEN ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, '')
                                              ELSE ISNULL(ADRA.PLZ + ' ','') + ISNULL(ADRA.Ort, '')
                                            END,
       AufenthaltWohnsitzPLZ              = CASE
                                              WHEN ADRA.BaAdresseID IS NULL THEN ADRW.PLZ
                                              ELSE ADRA.PLZ
                                            END,
       AufenthaltWohnsitzOrt              = CASE
                                              WHEN ADRA.BaAdresseID IS NULL THEN ADRW.Ort
                                              ELSE ADRA.Ort
                                            END,
       AufenthaltPostfachD                = dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 1),
       AufenthaltPostfachF                = dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 2),
       AufenthaltPostfachI                = dbo.fnBaGetPostfachText(NULL, ADRA.Postfach, ADRA.PostfachOhneNr, 3),

       AufenthaltInstitutionName          = ADRA.CareOf,

       ------------------------------------------------------------------------
       -- BaAdresse: Wohnsitz
       ------------------------------------------------------------------------
       WohnsitzAdresseEinzeilig           = PRS.Vorname + ' ' + PRS.Name + ', ' +
                                            ISNULL(ADRW.Zusatz + ', ', '') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, ''),
	   WohnsitzAdresseEinzeiligGB         = PRS.Vorname + ' ' + UPPER(RTRIM(PRS.Name)) + ', ' +
                                            ISNULL(ADRW.Zusatz + ', ', '') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, ''),
       WohnsitzAdresseEinzOhneName        = ISNULL(ADRW.Zusatz + ', ','') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + ', ', '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + ', ', '') +
                                            ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, ''),
       WohnsitzAdresseMehrzeilig          = PRS.Vorname + ' ' + PRS.Name + CHAR(13) + CHAR(10) +
                                            ISNULL(ADRW.Zusatz + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, ''),
       WohnsitzAdresseMehrzOhneName       = ISNULL(ADRW.Zusatz + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRW.Strasse + ISNULL(' ' + ADRW.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                            ISNULL(dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                            ISNULL(ADRW.PLZ + ' ', '') + ISNULL(ADRW.Ort, ''),
       WohnsitzStrasseNr                  = ADRW.Strasse + ISNULL(' ' + ADRW.HausNr,''),
       WohnsitzPLZOrt                     = ISNULL(ADRW.PLZ + ' ','') + ISNULL(ADRW.Ort, ''),
       WohnsitzOrt                        = ADRW.Ort,
       WohnsitzPLZ                        = ADRW.PLZ,
       WohnsitzPostfachD                  = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 1),
       WohnsitzPostfachF                  = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 2),
       WohnsitzPostfachI                  = dbo.fnBaGetPostfachText(NULL, ADRW.Postfach, ADRW.PostfachOhneNr, 3),
       
       ------------------------------------------------------------------------
       -- BaWohnsituation
       ------------------------------------------------------------------------
       Wohnsituation   = dbo.fnLOVText('Wohnstatus', ADRW.WohnStatusCode),
       Wohnungsgroesse = dbo.fnLOVText('Wohnungsgroesse', ADRW.WohnungsgroesseCode),
       
       ------------------------------------------------------------------------
       -- BaArbeitAusbildung
       ------------------------------------------------------------------------
       ArbeitslosSeit   = CONVERT(VARCHAR, ARB.StempelDatum, 104),
       AusgesteuertSeit = CONVERT(VARCHAR, ARB.AusgesteuertDatum, 104),
       Beruf            = CASE PRS.GeschlechtCode
                            WHEN 1 THEN BERB.BezeichnungM
                            WHEN 2 THEN BERB.BezeichnungW
                            ELSE BERB.Beruf
                          END,
       ErlernterBeruf   = CASE PRS.GeschlechtCode
                            WHEN 1 THEN BERE.BezeichnungM
                            WHEN 2 THEN BERE.BezeichnungW
                            ELSE BERE.Beruf
                          END,
       Schulbildung     = dbo.fnLOVText('Ausbildungstyp', ARB.HoechsteAusbildungCode),
       
       ------------------------------------------------------------------------
       -- Vermieter
       ------------------------------------------------------------------------
       VermieterName                 = INSM.[Name],
       VermieterAdresseEinzOhneName  = ISNULL(ADRM.Zusatz + ', ', '') +
                                       ISNULL(ADRM.Strasse + ISNULL(' ' + ADRM.HausNr, '') + ', ', '') +
                                       ISNULL(ADRM.PLZ + ' ', '') + ISNULL(ADRM.Ort, ''),
       VermieterAdresseMehrzOhneName = ISNULL(ADRM.Zusatz + CHAR(13) + CHAR(10), '') +
                                       ISNULL(ADRM.Strasse + ISNULL(' ' + ADRM.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                       ISNULL(ADRM.PLZ + ' ', '') + ISNULL(ADRM.Ort, ''),
       VermieterAdresseStrasseNr     = ADRM.Strasse + ISNULL(' ' + ADRM.HausNr,''),
       VermieterAdressePLZOrt        = ISNULL(ADRM.PLZ + ' ','') + ISNULL(ADRM.Ort, ''),
       VermieterAdressePLZ           = ADRM.PLZ,
       VermieterAdresseOrt           = ADRM.Ort,

       ------------------------------------------------------------------------
       -- KVG
       ------------------------------------------------------------------------
       KVGName                = INSK.[Name],
       KVGMitgliedNr          = GES.KVGMitgliedNr,
       KVGAdresseEinzOhneName = ISNULL(ADRK.Zusatz + ', ', '') +
                                ISNULL(ADRK.Strasse + ISNULL(' ' + ADRK.HausNr, '') + ', ', '') +
                                ISNULL(ADRK.PLZ + ' ', '') + ISNULL(ADRK.Ort, ''),
       
       ------------------------------------------------------------------------
       -- VVG
       ------------------------------------------------------------------------
       VVGName                = INSV.[Name],
       VVGMitgliedNr          = GES.VVGMitgliedNr,
       VVGAdresseEinzOhneName = ISNULL(ADRV.Zusatz + ', ', '') +
                                ISNULL(ADRV.Strasse + ISNULL(' ' + ADRV.HausNr, '') + ', ', '') +
                                ISNULL(ADRV.PLZ + ' ', '') + ISNULL(ADRV.Ort, ''),
       
       ------------------------------------------------------------------------
       -- Ehepartner
       ------------------------------------------------------------------------
       EhepartnerNachname           = PRSE.Name,
       EhepartnerVorname            = PRSE.Vorname,
       EhepartnerVorname2           = PRSE.Vorname2,
       EhepartnerNachnameVorname    = PRSE.NAME + ISNULL(' ' + PRSE.Vorname,''),
       EhepartnerNNummer            = PRSE.NNummer,
       EhepartnerBFFNummer          = PRSE.BFFNummer,
       --EhepartnerAufenthaltsstatusCode = PRSE.NNummer,
       -- TODO: (IBE)BaPerson.inCHseit vs. (BSS)BaPerson.AuslaenderStatusDatum
       EhepartnerInCHseit           = CONVERT(VARCHAR, PRSE.inCHseit, 104),
       EhepartnerNationalitaet        = CASE 
                                          WHEN dbo.fnLandMLText(PRSE.NationalitaetCode, NULL) IS NULL 
                                            AND PRSE.HeimatgemeindeBaGemeindeID IS NOT NULL  THEN 'Schweiz' -- Nationalität leer + Heimatort erfasst => 'Schweiz'
                                          ELSE dbo.fnLandMLText(PRSE.NationalitaetCode, NULL)
                                        END,
       EhepartnerZivilstand         = dbo.fnLOVText('Zivilstand', PRSE.ZivilstandCode),       
       EhepartnerBeruf              = CASE PRSE.GeschlechtCode
                                        WHEN 1 THEN BERBE.BezeichnungM
                                        WHEN 2 THEN BERBE.BezeichnungW
                                        ELSE BERBE.Beruf
                                      END,
       EhepartnerEndeZustaendigkeit = CONVERT(VARCHAR, PRSE.CAusweisDatum, 104),
       EhepartnerErteilungVA        = CONVERT(VARCHAR, PRSE.ErteilungVA, 104),
       EhepartnerGeschlecht         = dbo.fnLOVText('Geschlecht', PRSE.GeschlechtCode),
       EhepartnerPermis             = dbo.fnLOVText('Aufenthaltsstatus', PRSE.AuslaenderStatusCode),
       EhepartnerPersonenNummer     = PRSE.BaPersonID,
       EhepartnerGebDatum           = CONVERT(VARCHAR, PRSE.Geburtsdatum, 104),
       EhepartnerAHVNummer          = PRSE.AHVNummer,
       EhepartnerVersichertennummer = PRSE.Versichertennummer,
       EhepartnerAnrede             = PRSE.Titel,
       EhepartnerPLZOrt             = ISNULL(ADRE.PLZ + ' ', '') + ISNULL(ADRE.Ort, ''),
       EhepartnerStrasseNr          = ADRE.Strasse + ISNULL(' ' + ADRE.HausNr, ''),
       EhepartnerStrassePLZOrt      = ISNULL(ADRE.Strasse + ISNULL(' ' + ADRE.HausNr, '') + ', ', '') + ISNULL(ADRE.PLZ + ' ', '') + ISNULL(ADRE.Ort, ''),
       
       ------------------------------------------------------------------------
       -- Kostenstelle
       ------------------------------------------------------------------------
       Kostenstelle = dbo.fnKbGetKostenstelle(PRS.BaPersonID)
FROM dbo.BaPerson                  PRS  WITH (READUNCOMMITTED)
  -- Wohnsitz
  LEFT JOIN dbo.BaAdresse          ADRW WITH (READUNCOMMITTED) ON ADRW.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 1, NULL)

  -- Aufenthalt
  LEFT JOIN dbo.BaAdresse          ADRA WITH (READUNCOMMITTED) ON ADRA.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRS.BaPersonID, 3, NULL)
  
  -- others
  LEFT JOIN dbo.BaArbeitAusbildung ARB  WITH (READUNCOMMITTED) ON ARB.BaPersonID = PRS.BaPersonID
  LEFT JOIN dbo.BaBeruf            BERB WITH (READUNCOMMITTED) ON BERB.BaBerufID = ARB.BerufCode
  LEFT JOIN dbo.BaBeruf            BERE WITH (READUNCOMMITTED) ON BERE.BaBerufID = ARB.ErlernterBerufCode
  LEFT JOIN dbo.BaGemeinde         GDE  WITH (READUNCOMMITTED) ON GDE.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
  LEFT JOIN dbo.BaGesundheit       GES  WITH (READUNCOMMITTED) ON GES.BaPersonID = PRS.BaPersonID
                                                              AND GES.Jahr = (SELECT TOP 1 Jahr 
                                                                              FROM dbo.BaGesundheit WITH (READUNCOMMITTED) 
                                                                              WHERE BaPersonID = PRS.BaPersonID 
                                                                              ORDER BY Jahr DESC)
  LEFT JOIN dbo.BaInstitution      INSK WITH (READUNCOMMITTED) ON GES.KVGOrganisationID = INSK.BaInstitutionID
  LEFT JOIN dbo.BaAdresse          ADRK WITH (READUNCOMMITTED) ON ADRK.BaInstitutionID = INSK.BaInstitutionID
  LEFT JOIN dbo.BaInstitution      INSV WITH (READUNCOMMITTED) ON GES.VVGOrganisationID  = INSV.BaInstitutionID
  LEFT JOIN dbo.BaAdresse          ADRV WITH (READUNCOMMITTED) ON ADRV.BaInstitutionID = INSV.BaInstitutionID
  
  -- Miete
  LEFT JOIN dbo.BaMietvertrag      MIE  WITH (READUNCOMMITTED) ON MIE.BaPersonID = PRS.BaPersonID
  LEFT JOIN dbo.BaInstitution      INSM WITH (READUNCOMMITTED) ON INSM.BaInstitutionID = MIE.BaInstitutionID
  LEFT JOIN dbo.BaAdresse          ADRM WITH (READUNCOMMITTED) ON ADRM.BaAdresseID = dbo.fnBaGetBaAdresseID('BaInstitutionID', INSM.BaInstitutionID, NULL, NULL)
  
  -- Ehepartner
  LEFT JOIN dbo.BaPerson           PRSE WITH (READUNCOMMITTED) ON PRSE.BaPersonID = (SELECT TOP 1 
                                                                                            CASE
                                                                                              WHEN R.BaPersonID_2 = PRS.BaPersonID THEN R.BaPersonID_1
                                                                                              ELSE R.BaPersonID_2
                                                                                            END
                                                                                     FROM dbo.BaPerson_Relation R
                                                                                     WHERE (R.BaPersonID_1 = PRS.BaPersonID OR R.BaPersonID_2 = PRS.BaPersonID)
                                                                                       AND R.BaRelationID IN (13, 14, 15) -- Ehepaar, rechtliche Partnerschaft, Konkubinatspaar
                                                                                       AND dbo.fnDateOf(GETDATE()) BETWEEN ISNULL(R.DatumVon, dbo.fnDateOf(GETDATE())) AND ISNULL(R.DatumBis, dbo.fnDateOf(GETDATE()))
                                                                                    ORDER BY R.BaRelationID ASC, R.DatumVon DESC)
  LEFT JOIN dbo.BaAdresse          ADRE WITH (READUNCOMMITTED) ON ADRE.BaAdresseID = dbo.fnBaGetBaAdresseID('BaPersonID', PRSE.BaPersonID, 1, NULL)  -- wohnsitz
  LEFT JOIN dbo.BaArbeitAusbildung ARBE WITH (READUNCOMMITTED) ON ARBE.BaPersonID = PRSE.BaPersonID
  LEFT JOIN dbo.BaBeruf            BERBE WITH (READUNCOMMITTED) ON BERBE.BaBerufID = ARBE.BerufCode;

GO
