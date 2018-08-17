SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject vwPerson2
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Views/vwBaPerson2.sql $
  $Author: Mmarghitola $
  $Modtime: 7.09.10 10:30 $
  $Revision: 1 $
=================================================================================================
  Description: vwPerson2 ergibt die gleichen Ergebnisse wie vwPerson, ist aber viel
               schneller, falls zu einer Person die Adresse gefunden werden muss.
               Bei der Suche nach einer Personen mit einer bestimmten Adresse ist vwPerson schneller.
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Views/vwBaPerson2.sql $
 * 
 * 1     7.09.10 15:12 Mmarghitola
 * #6587: vwBaPerson2 und vwInstitution2 hinzugefügt
 * 
=================================================================================================*/

CREATE VIEW [dbo].[vwPerson2]
AS

  SELECT
PRS.BaPersonID,
PRS.StatusPersonCode,
PRS.Titel,
[Name] = PRS.Name,
Name_AI = PRS.Name COLLATE Latin1_General_CI_AI,
PRS.FruehererName,
Vorname = PRS.Vorname,
Vorname_AI = PRS.Vorname COLLATE Latin1_General_CI_AI,
PRS.Vorname2,
PRS.Geburtsdatum,
PRS.Sterbedatum,
PRS.AHVNummer,
PRS.Versichertennummer,
PRS.HaushaltVersicherungsNummer,
PRS.NNummer,
PRS.BFFNummer,
PRS.ZIPNr,
PRS.KantonaleReferenznummer,
PRS.GeschlechtCode,
PRS.ZivilstandCode,
PRS.ZivilstandDatum,
PRS.HeimatgemeindeCode,
PRS.HeimatgemeindeCodes,
PRS.NationalitaetCode,
PRS.ReligionCode,
PRS.AuslaenderStatusCode,
PRS.AuslaenderStatusGueltigBis,
PRS.Telefon_P,
PRS.Telefon_G,
PRS.MobilTel1,
PRS.MobilTel2,
PRS.EMail,
PRS.SprachCode,
PRS.Unterstuetzt,
PRS.Fiktiv,
PRS.Bemerkung,
PRS.EinwohnerregisterAktiv,
PRS.DeutschVerstehenCode,
PRS.WichtigerHinweisCode,
PRS.ZuzugKtPLZ,
PRS.ZuzugKtOrtCode,
PRS.ZuzugKtOrt,
PRS.ZuzugKtKanton,
PRS.ZuzugKtLandCode,
PRS.ZuzugKtDatum,
PRS.ZuzugKtSeitGeburt,
PRS.ZuzugGdePLZ,
PRS.ZuzugGdeOrtCode,
PRS.ZuzugGdeOrt,
PRS.ZuzugGdeKanton,
PRS.ZuzugGdeLandCode,
PRS.ZuzugGdeDatum,
PRS.ZuzugGdeSeitGeburt,
PRS.UntWohnsitzPLZ,
PRS.UntWohnsitzOrt,
PRS.UntWohnsitzKanton,
PRS.UntWohnsitzLandCode,
PRS.WegzugPLZ,
PRS.WegzugOrtCode,
PRS.WegzugOrt,
PRS.WegzugKanton,
PRS.WegzugLandCode,
PRS.WegzugDatum,
PRS.WohnsitzWieBaPersonID,
PRS.AufenthaltWieBaInstitutionID,
PRS.ErwerbssituationCode,
PRS.GrundTeilzeitarbeit1Code,
PRS.GrundTeilzeitarbeit2Code,
PRS.ErwerbsBrancheCode,
PRS.ErlernterBerufCode,
PRS.BerufCode,
PRS.HoechsteAusbildungCode,
PRS.AbgebrocheneAusbildungCode,
PRS.ArbeitSpezFaehigkeiten,
PRS.VerID,
PRS.KbKostenstelleID,
PRS.InCHSeit,
PRS.InCHSeitGeburt,
PRS.PUAnzahlVerlustscheine,
PRS.PUKrankenkasse,
PRS.PraemienuebernahmeVon,
PRS.PraemienuebernahmeBis,
PRS.PersonOhneLeistung,
PRS.BaPersonTS,
PRS.HCMCFluechtling,
PRS.StellensuchendCode,
PRS.ResoNr,
PRS.NEAnmeldung,
PRS.Creator,
PRS.Created,
PRS.Modifier,
PRS.Modified,

--PRS.*,

    NameVorname    = PRS.Name + IsNull(', ' + PRS.Vorname, ''),
    VornameName    = IsNull(PRS.Vorname + ' ', '') + PRS.Name,
    NameVorname_AI = PRS.Name + IsNull(', ' + PRS.Vorname, '')  COLLATE Latin1_General_CI_AI,
    VornameName_AI = IsNull(PRS.Vorname + ' ', '') + PRS.Name COLLATE Latin1_General_CI_AI,
    [Alter]        = CONVERT(int, (DateDiff(dd, PRS.Geburtsdatum, GetDate()) + .5) / 365.25),
    AlterMortal    = dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(),PRS.Sterbedatum),

    Nationalitaet  = NAT.Text,
    Heimatort      = HEI.Name + IsNull(' ' + HEI.Kanton, ''),

    WohnsitzBaAdresseID     = ADR1.BaAdresseID,
    Wohnsitz                = IsNull(ADR1.AdressZusatz + ', ', '') +
                              IsNull(ADR1.Postfach + ', ', '') +
                              IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr, '') + ', ', '') +
                              IsNull(ADR1.PLZ + ' ', '') + IsNull(ADR1.Ort, ''),
    WohnsitzMehrzeilig      = IsNull(ADR1.AdressZusatz + char(13) + char(10), '') +
                              IsNull(ADR1.Postfach + char(13) + char(10), '') +
                              IsNull(ADR1.Strasse + IsNull(' ' + ADR1.HausNr, '') + char(13) + char(10), '') +
                              IsNull(ADR1.PLZ + ' ', '') + IsNull(ADR1.Ort, ''),
    WohnsitzAdressZusatz    = ADR1.AdressZusatz,
    WohnsitzStrasse         = ADR1.Strasse,
    WohnsitzStrasseCode     = ADR1.StrasseCode,
    WohnsitzHausNr          = ADR1.HausNr,
    WohnsitzStrasseHausNr   = ADR1.Strasse + IsNull(' ' + ADR1.HausNr, ''),
    WohnsitzPostfach        = ADR1.Postfach,
    WohnsitzPLZ             = ADR1.PLZ,
    WohnsitzOrt             = ADR1.Ort,
    WohnsitzPLZOrt          = IsNull(ADR1.PLZ + ' ', '') + IsNull(ADR1.Ort, ''),
    WohnsitzKanton          = ADR1.Kanton,
    WohnsitzLand            = LAN1.Text,
    WohnsitzOrtschaftCode   = ADR1.OrtschaftCode,
    WohnsitzLandCode        = LAN1.BaLandID,
    WohnsitzBemerkung       = ADR1.Bemerkung,
    WohnsitzDatumVon        = ADR1.DatumVon,
    WohnsitzDatumBis        = ADR1.DatumBis,

    AufenthaltBaAdresseID   = ADR3.BaAdresseID,
    Aufenthalt              = IsNull(INS3.Name + ', ', '') +
                              IsNull(ADR3.AdressZusatz + ', ', '') +
                              IsNull(ADR3.Postfach + ', ', '') +
                              IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr, '') + ', ', '') +
                              IsNull(ADR3.PLZ + ' ', '') + IsNull(ADR3.Ort, ''),
    AufenthaltMehrzeilig    = IsNull(INS3.Name + char(13) + char(10), '') +
                              IsNull(ADR3.AdressZusatz + char(13) + char(10), '') +
                              IsNull(ADR3.Postfach + char(13) + char(10), '') +
                              IsNull(ADR3.Strasse + IsNull(' ' + ADR3.HausNr, '') + char(13) + char(10), '') +
                              IsNull(ADR3.PLZ + ' ', '') + IsNull(ADR3.Ort, ''),
    AufenthaltAdressZusatz  = ADR3.AdressZusatz,
    AufenthaltStrasse       = ADR3.Strasse,
    AufenthaltHausNr        = ADR3.HausNr,
    AufenthaltStrasseHausNr = ADR3.Strasse + IsNull(' ' + ADR3.HausNr, ''),
    AufenthaltPostfach      = ADR3.Postfach,
    AufenthaltPLZ           = ADR3.PLZ,
    AufenthaltOrt           = ADR3.Ort,
    AufenthaltPLZOrt        = IsNull(ADR3.PLZ + ' ', '') + IsNull(ADR3.Ort, ''),
    AufenthaltKanton        = ADR3.Kanton,
    AufenthaltLand          = LAN3.Text,
    AufenthaltOrtschaftCode = ADR3.OrtschaftCode,
    AufenthaltLandCode      = LAN3.BaLandID,
    AufenthaltBemerkung     = ADR3.Bemerkung,

    AufenthaltBaInstitutionID = ADR3.BaInstitutionID,
    AufenthaltInstitutionName = INS3.Name,
    DisplayText               = PRS.Name + IsNull(', ' + PRS.Vorname, '') + ' (' +
                                IsNull(CONVERT(varchar,dbo.fnGetAgeMortal(PRS.Geburtsdatum, GetDate(),PRS.Sterbedatum)),'-') + ',' +
                                IsNull(GES.ShortText,'?') + ')',
    GeschlechtKurz            = GES.ShortText

  FROM dbo.BaPerson               PRS WITH(READUNCOMMITTED)
    LEFT OUTER JOIN dbo.BaLand					NAT  WITH(READUNCOMMITTED) ON NAT.BaLandID = PRS.NationalitaetCode
    LEFT  OUTER JOIN dbo.BaGemeinde     HEI  WITH(READUNCOMMITTED) ON HEI.BaGemeindeID = PRS.HeimatgemeindeCode

    OUTER APPLY
    (
      SELECT TOP 1 BaLandID,
    BaAdresseID,
    AdressZusatz = Zusatz,
    Postfach,
    Strasse, HausNr,
    PLZ, Ort, StrasseCode, Kanton, Bemerkung, DatumVon, DatumBis, OrtschaftCode
      FROM dbo.BaAdresse ADR_I1
      WHERE ADR_I1.BaPersonID = PRS.BaPersonID AND ADR_I1.AdresseCode = 1 AND
        GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
      ORDER BY BaAdresseID DESC
    ) ADR1
    LEFT  OUTER JOIN dbo.BaLand					LAN1 WITH(READUNCOMMITTED) ON LAN1.BaLandID = ADR1.BaLandID

    OUTER APPLY
    (
      SELECT TOP 1 BaLandID,
    BaAdresseID,
    AdressZusatz = Zusatz,
    Postfach,
    Strasse, HausNr,
    PLZ, Ort, BaInstitutionID, Kanton, Bemerkung, OrtschaftCode
      FROM dbo.BaAdresse ADR_I2
      WHERE ADR_I2.BaPersonID = PRS.BaPersonID AND ADR_I2.AdresseCode = 3 AND
        GetDate() BETWEEN IsNull(DatumVon, GetDate()) AND IsNull(DatumBis, GetDate())
      ORDER BY BaAdresseID DESC
    ) ADR3
    LEFT  OUTER JOIN dbo.BaLand					LAN3 WITH(READUNCOMMITTED) ON LAN3.BaLandID = ADR3.BaLandID
    LEFT  OUTER JOIN dbo.XLOVCode       GES WITH(READUNCOMMITTED)  ON GES.LOVName = 'BaGeschlecht' AND GES.Code = PRS.GeschlechtCode
    LEFT  OUTER JOIN dbo.BaInstitution  INS3 WITH(READUNCOMMITTED) ON INS3.BaInstitutionID = ADR3.BaInstitutionID

