SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwPerson;
GO
/*===============================================================================================
  $Revision: 29 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: View for person details
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
  -
  RETURNS: Various data and combined information about persons
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwPerson;
=================================================================================================*/

CREATE VIEW dbo.vwPerson WITH SCHEMABINDING
AS
SELECT -- default fields
       PRS.BaPersonID,
       PRS.Titel,
       PRS.Name,
       PRS.FruehererName,
       PRS.Vorname,
       PRS.Vorname2,
       PRS.Geburtsdatum,
       PRS.Sterbedatum,
       PRS.AHVNummer,
       PRS.Versichertennummer,
       PRS.HaushaltVersicherungsNummer,
       PRS.NNummer,
       PRS.ZEMISNummer,
       PRS.BFFNummer,
       PRS.ErteilungVA,
       PRS.GeschlechtCode,
       PRS.KonfessionCode,
       PRS.ZivilstandCode,
       PRS.ZivilstandDatum,
       PRS.HeimatgemeindeCode,
       PRS.HeimatgemeindeCodes,
       PRS.HeimatgemeindeBaGemeindeID,
       PRS.NationalitaetCode,
       PRS.AuslaenderStatusCode,
       PRS.AuslaenderStatusGueltigBis,
       PRS.InGemeindeSeit,
       PRS.InCHSeitGeburt,
       PRS.ImKantonSeit,
       PRS.ImKantonSeitGeburt,
       PRS.Telefon_P,
       PRS.Telefon_G,
       PRS.MobilTel,
       PRS.Fax,
       PRS.EMail,
       PRS.SprachCode,
       PRS.Unterstuetzt,
       PRS.Fiktiv,
       PRS.Testperson,
       PRS.NavigatorZusatz,
       PRS.Bemerkung,
       PRS.BaPersonTS,
       PRS.VerID,
       PRS.ZuzugKtPLZ,
       PRS.ZuzugKtOrt,
       PRS.ZuzugKtKanton,
       PRS.ZuzugKtOrtCode,
       PRS.ZuzugKtLandCode,
       PRS.ZuzugKtDatum,
       PRS.ZuzugKtSeitGeburt,
       PRS.ZuzugGdePLZ,
       PRS.ZuzugGdeOrt,
       PRS.ZuzugGdeKanton,
       PRS.ZuzugGdeOrtCode,
       PRS.ZuzugGdeLandCode,
       PRS.ZuzugGdeDatum,
       PRS.ZuzugGdeSeitGeburt,
       PRS.UntWohnsitzPLZ,
       PRS.UntWohnsitzOrt,
       PRS.UntWohnsitzKanton,
       PRS.UntWohnsitzOrtCode,
       PRS.UntWohnsitzLandCode,
       PRS.WegzugPLZ,
       PRS.WegzugOrt,
       PRS.WegzugKanton,
       PRS.WegzugOrtCode,
       PRS.WegzugLandCode,
       PRS.WegzugDatum,
       PRS.KeinSerienbrief,
       PRS.Creator,
       PRS.Created,
       PRS.Modifier,
       PRS.Modified,
       
       -- combined fields   
       NameVorname   = PRS.Name + ISNULL(', ' + PRS.Vorname, ''),
       VornameName   = ISNULL(PRS.Vorname + ' ', '') + PRS.Name,
       [Alter]       = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
       [AlterMortal] = dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())),
       
       Nationalitaet = NAT.Text,
       NationalitaetFR = NAT.TextFR,
       NationalitaetIT = NAT.TextIT,
       Heimatort     = HEI.Name + ISNULL(' ' + HEI.Kanton, ''),
       --
       WohnsitzBaAdresseID     = ADR1.BaAdresseID,
       Wohnsitz                = ISNULL(ADR1.Zusatz + ', ', '') +
                                 ISNULL(ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, '') + ', ', '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR1.Postfach, ADR1.PostfachOhneNr, 1) + ', ', '') +
                                 ISNULL(ADR1.PLZ + ' ', '') + ISNULL(ADR1.Ort, ''),
       WohnsitzMehrzeilig      = ISNULL(ADR1.Zusatz + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                 ISNULL(dbo.fnBaGetPostfachText(NULL, ADR1.Postfach, ADR1.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                 ISNULL(ADR1.PLZ + ' ', '') + ISNULL(ADR1.Ort, ''),
       WohnsitzAdressZusatz    = ADR1.Zusatz,
       WohnsitzStrasse         = ADR1.Strasse,
       WohnsitzHausNr          = ADR1.HausNr,
       WohnsitzStrasseHausNr   = ADR1.Strasse + ISNULL(' ' + ADR1.HausNr, ''),
       WohnsitzPostfach        = ADR1.Postfach,
       WohnsitzPostfachOhneNr  = ADR1.PostfachOhneNr,
       WohnsitzPostfachD       = dbo.fnBaGetPostfachText(NULL, ADR1.Postfach, ADR1.PostfachOhneNr, 1),
       WohnsitzPLZ             = ADR1.PLZ,
       WohnsitzOrt             = ADR1.Ort,
       WohnsitzPLZOrt          = ISNULL(ADR1.PLZ + ' ', '') + ISNULL(ADR1.Ort, ''),
       WohnsitzKanton          = ADR1.Kanton,
       WohnsitzLand            = dbo.fnLandMLText(ADR1.BaLandID, 1),
       WohnsitzOrtschaftCode   = ADR1.OrtschaftCode,
       WohnsitzBaLandID        = ADR1.BaLandID,
       WohnsitzBemerkung       = ADR1.Bemerkung,
       WohnsitzWohnStatusCode  = ADR1.WohnStatusCode,
       WohnsitzWohnungsgroesseCode = ADR1.WohnungsgroesseCode,
       --
       AufenthaltBaAdresseID     = ADR3.BaAdresseID,
       Aufenthalt                = ISNULL(ADR3.CareOf + ', ', '') +
                                   ISNULL(ADR3.Zusatz + ', ', '') +
                                   ISNULL(ADR3.Strasse + ISNULL(' ' + ADR3.HausNr, '') + ', ', '') +
                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADR3.Postfach, ADR3.PostfachOhneNr, 1) + ', ', '') +
                                   ISNULL(ADR3.PLZ + ' ', '') + ISNULL(ADR3.Ort, ''),
       AufenthaltMehrzeilig      = ISNULL(ADR3.CareOf + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ADR3.Zusatz + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ADR3.Strasse + ISNULL(' ' + ADR3.HausNr, '') + CHAR(13) + CHAR(10), '') +
                                   ISNULL(dbo.fnBaGetPostfachText(NULL, ADR3.Postfach, ADR3.PostfachOhneNr, 1) + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ADR3.PLZ + ' ', '') + ISNULL(ADR3.Ort, ''),
       AufenthaltAdressZusatz    = ADR3.Zusatz,
       AufenthaltStrasse         = ADR3.Strasse,
       AufenthaltHausNr          = ADR3.HausNr,
       AufenthaltStrasseHausNr   = ADR3.Strasse + ISNULL(' ' + ADR3.HausNr, ''),
       AufenthaltPostfach        = ADR3.Postfach,
       AufenthaltPostfachOhneNr  = ADR3.PostfachOhneNr,
       AufenthaltPostfachD       = dbo.fnBaGetPostfachText(NULL, ADR3.Postfach, ADR3.PostfachOhneNr, 1),
       AufenthaltPLZ             = ADR3.PLZ,
       AufenthaltOrt             = ADR3.Ort,
       AufenthaltPLZOrt          = ISNULL(ADR3.PLZ + ' ', '') + ISNULL(ADR3.Ort, ''),
       AufenthaltKanton          = ADR3.Kanton,
       AufenthaltLand            = dbo.fnLandMLText(ADR3.BaLandID, 1),
       AufenthaltOrtschaftCode   = ADR3.OrtschaftCode,
       AufenthaltBaLandID        = ADR3.BaLandID,
       AufenthaltBemerkung       = ADR3.Bemerkung,
       AufenthaltWohnStatusCode  = ADR3.WohnStatusCode,
       AufenthaltWohnungsgroesseCode = ADR3.WohnungsgroesseCode,
       
       AufenthaltBaInstitutionID = ADR3.BaInstitutionID,
       AufenthaltInstitutionName = ADR3.CareOf,
       
       -- BSS special fields
       PRS.SichtbarSDFlag,
       PRS.PersonSichtbarSDFlag,
       
       -- SRK/CAR special fields
       PRS.VerstaendigungSprachCode,
       PRS.InCHseit,
       PRS.CAusweisDatum,
       Anrede = CASE
                  WHEN PRS.VerstaendigungSprachCode = 2 THEN CASE
                                                               WHEN PRS.GeschlechtCode = 1 THEN 'Herr'
                                                               WHEN PRS.GeschlechtCode = 2 THEN 'Frau'
                                                               ELSE ''
                                                             END
                  ELSE CASE
                         WHEN PRS.GeschlechtCode = 1 THEN 'Monsieur'
                         WHEN PRS.GeschlechtCode = 2 THEN 'Madame'
                         ELSE ''
                       END
                END
FROM dbo.BaPerson          PRS  WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaLand     NAT  WITH (READUNCOMMITTED) ON NAT.BaLandID = PRS.NationalitaetCode
  LEFT JOIN dbo.BaGemeinde HEI  WITH (READUNCOMMITTED) ON HEI.BaGemeindeID = PRS.HeimatgemeindeBaGemeindeID
  
  -- wohnsitz
  LEFT JOIN dbo.BaAdresse  ADR1 WITH (READUNCOMMITTED) ON ADR1.BaAdresseID = (SELECT FCN1.BaAdresseID
                                                                              FROM dbo.fnBaGetBaAdresseID_BaPerson(1, NULL) FCN1
                                                                              WHERE FCN1.BaPersonID = PRS.BaPersonID)
  
  -- aufenthalt
  LEFT JOIN dbo.BaAdresse  ADR3 WITH (READUNCOMMITTED) ON ADR3.BaAdresseID = (SELECT FCN3.BaAdresseID
                                                                              FROM dbo.fnBaGetBaAdresseID_BaPerson(3, NULL) FCN3
                                                                              WHERE FCN3.BaPersonID = PRS.BaPersonID);
GO