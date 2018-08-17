SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwKreditor;
GO
/*===============================================================================================
  $Revision: 15 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    SELECT TOP 100 * FROM dbo.vwKreditor;
=================================================================================================*/

CREATE VIEW dbo.vwKreditor WITH SCHEMABINDING
AS
WITH BaZahlungsweg_CTE
AS
(
    SELECT ZAH.BaZahlungswegID,
           ZAH.DatumVon,
           ZAH.DatumBis,
           ZAH.EinzahlungsscheinCode,
           ZAH.BankKontoNummer,
           ZAH.IBANNummer,
           ZAH.PostKontoNummer,
           ZAH.ReferenzNummer,
           ZAH.BaBankID,
           ZAH.BaInstitutionID,
           ZAH.BaPersonID,
           ZAH.AdresseName,
           ZAH.AdresseName2,
           ZAH.AdressePostfach,
           ZAH.AdresseStrasse,
           ZAH.AdresseHausNr,
           ZAH.AdressePLZ,
           ZAH.AdresseOrt
    FROM dbo.BaZahlungsweg ZAH
    WHERE (ZAH.BaInstitutionID IS NOT NULL OR ZAH.BaPersonID IS NOT NULL) -- cka: Kreditor muss Person oder Institution haben!
)
SELECT BaZahlungswegID           = ZAH.BaZahlungswegID,
       ZahlungswegDatumVon       = ZAH.DatumVon,
       ZahlungswegDatumBis       = ZAH.DatumBis,
       EinzahlungsscheinCode     = ZAH.EinzahlungsscheinCode,
       BankKontoNummer           = ZAH.BankKontoNummer,
       IBANNummer                = ZAH.IBANNummer,
       PostKontoNummer           = ZAH.PostKontoNummer,
       ReferenzNummer            = ZAH.ReferenzNummer,
       BaBankID                  = ZAH.BaBankID,
       BankName                  = BNK.Name,
       BankZusatz                = BNK.Zusatz,
       BankStrasse               = BNK.Strasse,
       BankPLZ                   = BNK.PLZ,
       BankOrt                   = BNK.Ort,
       BankClearingNr            = BNK.ClearingNr,
       BankPCKontoNr             = BNK.PCKontoNr,
       BankGueltigAb             = BNK.GueltigAb,
       BankLandCode              = BNK.LandCode,
       BaInstitutionID           = ZAH.BaInstitutionID,
       InstitutionName           = INS.[Name],
       BaFreigabeStatusCode      = INS.BaFreigabeStatusCode,
       InstitutionAdresse        = INS.Adresse,
       InstitutionOrtStrasse     = INS.OrtStrasse,
       InstitutionAdressZusatz   = INS.AdressZusatz,
       InstitutionStrasse        = INS.Strasse,
       InstitutionHausNr         = INS.HausNr,
       InstitutionStrasseHausNr  = INS.StrasseHausNr,
       InstitutionPostfach       = INS.Postfach,
       InstitutionPLZ            = INS.PLZ,
       InstitutionOrt            = INS.Ort,
       InstitutionPLZOrt         = INS.PLZOrt,
       InstitutionKanton         = INS.Kanton,
       InstitutionLand           = INS.Land,
       InstitutionBaLandID       = INS.BaLandID,
       BaPersonID                = ZAH.BaPersonID,
       PersonName                = PRS.Name,
       PersonVorname             = PRS.Vorname,
       PersonNameVorname         = PRS.NameVorname,
       PersonAdresse             = PRS.Wohnsitz,
       PersonAdressZusatz        = PRS.WohnsitzAdressZusatz,
       PersonStrasse             = PRS.WohnsitzStrasse,
       PersonHausNr              = PRS.WohnsitzHausNr,
       PersonStrasseHausNr       = PRS.WohnsitzStrasseHausNr,
       PersonPostfach            = PRS.WohnsitzPostfach,
       PersonPLZ                 = PRS.WohnsitzPLZ,
       PersonOrt                 = PRS.WohnsitzOrt,
       PersonPLZOrt              = PRS.WohnsitzPLZOrt,
       PersonKanton              = PRS.WohnsitzKanton,
       PersonLand                = PRS.WohnsitzLand,
       PersonBaLandID            = PRS.WohnsitzBaLandID,
       Kreditor                  = COALESCE(ZAH.AdresseName, INS.[Name], PRS.NameVorname),
       KreditorMehrZeilig        = CASE
                                     WHEN ZAH.AdresseName IS NOT NULL 
                                      AND ZAH.AdressePLZ IS NOT NULL 
                                      AND ZAH.AdresseOrt IS NOT NULL 
                                      THEN ZAH.AdresseName + CHAR(13) + CHAR(10) +
                                           ISNULL(ZAH.AdresseName2 + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdressePostfach + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + CHAR(13) + CHAR(10), '') +
                                           ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                     WHEN PRS.BaPersonID IS NOT NULL THEN PRS.NameVorname + CHAR(13) + CHAR(10) + PRS.WohnsitzMehrzeilig
                                     ELSE INS.[Name] + CHAR(13) + CHAR(10) + INS.AdresseMehrzeilig
                                   END,
       KreditorEinzeilig         = CASE
                                     WHEN ZAH.AdresseName IS NOT NULL
                                      AND ZAH.AdressePLZ IS NOT NULL
                                      AND ZAH.AdresseOrt IS NOT NULL
                                      THEN ZAH.AdresseName + ', ' +
                                           ISNULL(ZAH.AdresseName2 + ', ', '') +
                                           ISNULL(ZAH.AdressePostfach + ', ', '') +
                                           ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + ', ', '') +
                                           ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                     WHEN PRS.BaPersonID IS NOT NULL THEN PRS.VornameName + ', ' + PRS.Wohnsitz
                                     ELSE INS.[Name] + ', ' + INS.Adresse
                                   END,
       Zahlungsweg               = EIZ.ShortText +
                                   ISNULL(', ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)),'') +
                                   ISNULL(', ' + BNK.Name, '') +
                                   ISNULL(', ' + ZAH.BankKontoNummer, '') +
                                   ISNULL(', ' + ZAH.IBANNummer,''),
       ZahlungswegMehrZeilig     = EIZ.ShortText +
                                   ISNULL(CHAR(13) + CHAR(10) + 'IBAN:     ' + ZAH.IBANNummer,'') +
                                   ISNULL(CHAR(13) + CHAR(10) + 'Konto:    ' + ZAH.BankKontoNummer, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + BNK.Name, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + BNK.Strasse, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + ISNULL(BNK.PLZ + ' ', '') + BNK.Ort, '') +
                                   ISNULL(CHAR(13) + CHAR(10) + 'PC-Konto: ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)), ''),
       PCKontoNr                 = dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer, BNK.PCKontoNr)),
       ZusatzInfo                = CASE
                                     WHEN ZAH.AdresseName IS NOT NULL 
                                      AND ZAH.AdressePLZ IS NOT NULL 
                                      AND ZAH.AdresseOrt IS NOT NULL
                                      THEN ZAH.AdresseName + CHAR(13) + CHAR(10) +
                                           ISNULL(ZAH.AdresseName2 + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdressePostfach + CHAR(13) + CHAR(10), '') +
                                           ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + CHAR(13) + CHAR(10), '') +
                                           ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                     WHEN PRS.BaPersonID IS NOT NULL THEN PRS.WohnsitzMehrzeilig
                                     ELSE INS.AdresseMehrzeilig
                                   END + CHAR(13) + CHAR(10) +
                                   '** ' + EIZ.ShortText + ' **' + CHAR(13) + CHAR(10) +
                                   ISNULL(dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer,BNK.PCKontoNr)) + ISNULL(', ' + BNK.Name,'') + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ZAH.BankKontoNummer + CHAR(13) + CHAR(10), '') +
                                   ISNULL(ZAH.IBANNummer, ''),
       IsActive                  = CONVERT(BIT, CASE 
                                                  WHEN GETDATE() BETWEEN ISNULL(ZAH.DatumVon, GETDATE()) AND ISNULL(ZAH.DatumBis, GETDATE()) THEN 1 
                                                  ELSE 0 
                                                END),
       BeguenstigtName           = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseName
                                          WHEN ZAH.BaPersonID IS NOT NULL THEN PRS.NameVorname
                                          ELSE INS.[Name]
                                        END, 35),
       BeguenstigtName2          = LEFT(CASE
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseName2 
                                        END, 35),
       BeguenstigtStrasse        = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseStrasse
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzStrasse
                                          ELSE INS.Strasse
                                        END, 35),
       BeguenstigtHausNr         = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseHausNr
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzHausNr
                                          ELSE INS.HausNr
                                        END, 35),
       BeguenstigtStrasseHausNr  = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '')
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzStrasseHausNr
                                          ELSE INS.StrasseHausNr
                                        END, 35),
       BeguenstigtPLZ            = LEFT(CASE 
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdressePLZ
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzPLZ
                                          ELSE INS.PLZ
                                        END, 10),
       BeguenstigtOrt            = LEFT(CASE
                                          WHEN ZAH.AdresseName IS NOT NULL THEN ZAH.AdresseOrt
                                          WHEN ZAH.BaPersonID  IS NOT NULL THEN PRS.WohnsitzOrt
                                          ELSE INS.Ort
                                        END, 25)
FROM BaZahlungsweg_CTE        ZAH WITH (READUNCOMMITTED)
  LEFT JOIN dbo.vwInstitution INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = ZAH.BaInstitutionID
  LEFT JOIN dbo.vwPerson      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ZAH.BaPersonID
  LEFT JOIN dbo.XLOVCode      EIZ WITH (READUNCOMMITTED) ON EIZ.LOVName = 'BgEinzahlungsschein' 
                                                        AND EIZ.Code = ZAH.EinzahlungsscheinCode
  LEFT JOIN dbo.BaBank        BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = ZAH.BaBankID;
GO
