SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject vwKreditor;
GO
/*===============================================================================================
  $Revision: 11 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE VIEW dbo.vwKreditor
AS
SELECT BaZahlungswegID                 = ZAH.BaZahlungswegID,
       ZahlungswegDatumVon             = ZAH.DatumVon,
       ZahlungswegDatumBis             = ZAH.DatumBis,
       EinzahlungsscheinCode           = ZAH.EinzahlungsscheinCode,
       BankKontoNummer                 = ZAH.BankKontoNummer,
       IBANNummer                      = ZAH.IBANNummer,
       PostKontoNummer                 = ZAH.PostKontoNummer,
       ESRTeilnehmer                   = ZAH.ESRTeilnehmer,
       BaKontoartCode                  = ZAH.BaKontoartCode,
       BaKontoart                      = KAR.Text,
       Verwendungszweck                = ZAH.Verwendungszweck,
       ZahlungswegBaFreigabeStatusCode = ZAH.BaFreigabeStatusCode,
       --
       BaBankID                   = ZAH.BaBankID,
       BankName                   = BNK.Name,
       BankZusatz                 = BNK.Zusatz,
       BankStrasse                = BNK.Strasse,
       BankPLZ                    = BNK.PLZ,
       BankOrt                    = BNK.Ort,
       BankClearingNr             = BNK.ClearingNr,
       BankPCKontoNr              = BNK.PCKontoNr,
       BankGueltigAb              = BNK.GueltigAb,
       BankLandCode               = BNK.LandCode,
       --
       BaInstitutionID            = ZAH.BaInstitutionID ,
       InstitutionName            = INS.Name,
       InstitutionTypCode         = INS.InstitutionTypCode,
       BaFreigabeStatusCode       = INS.BaFreigabeStatusCode,
       InstitutionTyp             = INS.Typ,
       InstitutionAdresse         = INS.Adresse,
       InstitutionOrtStrasse      = INS.OrtStrasse,
       InstitutionAdressZusatz    = INS.AdressZusatz,
       InstitutionStrasse         = INS.Strasse,
       InstitutionHausNr          = INS.HausNr,
       InstitutionStrasseHausNr   = INS.StrasseHausNr,
       InstitutionPostfach        = INS.Postfach,
       InstitutionPLZ             = INS.PLZ,
       InstitutionOrt             = INS.Ort,
       InstitutionPLZOrt          = INS.PLZOrt,
       InstitutionKanton          = INS.Kanton,
       InstitutionLand            = INS.Land,
       InstitutionLandCode        = INS.LandCode,
       --
       BaPersonID                 = ZAH.BaPersonID,
       PersonName                 = PRS.Name,
       PersonVorname              = PRS.Vorname,
       PersonNameVorname          = PRS.NameVorname,
       PersonAdresse              = PRS.Wohnsitz,
       PersonAdressZusatz         = PRS.WohnsitzAdressZusatz,
       PersonStrasse              = PRS.WohnsitzStrasse,
       PersonStrasseCode          = PRS.WohnsitzStrasseCode,
       PersonHausNr               = PRS.WohnsitzHausNr,
       PersonStrasseHausNr        = PRS.WohnsitzStrasseHausNr,
       PersonPostfach             = PRS.WohnsitzPostfach,
       PersonPLZ                  = PRS.WohnsitzPLZ,
       PersonOrt                  = PRS.WohnsitzOrt,
       PersonPLZOrt               = PRS.WohnsitzPLZOrt,
       PersonKanton               = PRS.WohnsitzKanton,
       PersonLand                 = PRS.WohnsitzLand,
       PersonLandCode             = PRS.WohnsitzLandCode,
       PersonAdresseDatumVon      = PRS.WohnsitzDatumVon,
       PersonAdresseDatumBis      = PRS.WohnsitzDatumBis,
       --
       Kreditor                   = ISNULL(INS.Name,PRS.NameVorname),
       ZusatzInfo                 = CASE
                                      WHEN ZAH.WMAVerwenden = 0
                                        THEN ZAH.AdresseName + CHAR(13) + CHAR(10) +
                                             ISNULL(ZAH.AdresseName2 + CHAR(13) + CHAR(10), '') +
                                             ISNULL(ZAH.AdressePostfach + CHAR(13) + CHAR(10), '') +
                                             ISNULL(ZAH.AdresseStrasse + ISNULL(' ' + ZAH.AdresseHausNr, '') + CHAR(13) + CHAR(10), '') +
                                             ZAH.AdressePLZ + ' ' + ZAH.AdresseOrt
                                      WHEN PRS.BaPersonID IS NOT NULL 
                                        THEN PRS.WohnsitzMehrzeilig
                                      ELSE INS.AdresseMehrzeilig
                                    END + CHAR(13) + CHAR(10) +
                                    '** ' + EIZ.ShortText + ' **' + CHAR(13) + CHAR(10) +
                                    ISNULL(dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer,BNK.PCKontoNr)) + ISNULL(', ' + BNK.Name,'') + CHAR(13) + CHAR(10),'') +
                                    ISNULL(ZAH.BankKontoNummer + CHAR(13) + CHAR(10), '') +
                                    ISNULL(ZAH.IBANNummer,''),
       Zahlungsweg                = EIZ.ShortText +
                                    ISNULL(', ' + dbo.fnTnToPc(ISNULL(ZAH.PostKontoNummer,BNK.PCKontoNr)),'') +
                                    ISNULL(', ' + BNK.Name, '') +
                                    ISNULL(', ' + ZAH.BankKontoNummer, '') +
                                    ISNULL(', ' + ZAH.IBANNummer,''),
       --
       BeguenstigtName				    = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseName ELSE PRS.NameVorname END,
       BeguenstigtName2			      = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseName2 ELSE PRS.WohnsitzAdressZusatz END,	
       BeguenstigtStrasse			    = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseStrasse ELSE PRS.WohnsitzStrasse END,
       BeguenstigtHausNr			    = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseHausNr ELSE PRS.WohnsitzHausNr END,
       BeguenstigtPostfach			  = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdressePostfach ELSE PRS.WohnsitzPostfach END,
       BeguenstigtOrt				      = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseOrt ELSE PRS.WohnsitzOrt END,
       BeguenstigtPLZ				      = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdressePLZ ELSE PRS.WohnsitzPLZ END,
       BeguenstigtLandCode			  = CASE WHEN ZAH.WMAVerwenden = 0 THEN ZAH.AdresseLandCode ELSE PRS.WohnsitzLandCode END,
       InstitutionIstKreditor     = INS.Kreditor
FROM dbo.BaZahlungsweg         ZAH WITH (READUNCOMMITTED)
  LEFT JOIN dbo.BaBank         BNK WITH (READUNCOMMITTED) ON BNK.BaBankID = ZAH.BaBankID
  LEFT JOIN dbo.vwInstitution2 INS WITH (READUNCOMMITTED) ON INS.BaInstitutionID = ZAH.BaInstitutionID
  LEFT JOIN dbo.vwPerson2      PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = ZAH.BaPersonID
  LEFT JOIN dbo.XLOVCode       EIZ WITH (READUNCOMMITTED) ON EIZ.LOVName = 'BgEinzahlungsschein' 
                                                         AND EIZ.Code = ZAH.EinzahlungsscheinCode
  LEFT JOIN dbo.XLOVCode       KAR WITH (READUNCOMMITTED) ON KAR.LOVName = 'BaKontoart' 
                                                         AND KAR.Code = ZAH.BaKontoartCode;
GO

-------------------------------------------------------------------------------
-- grant access
-------------------------------------------------------------------------------
SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
GRANT SELECT ON [dbo].[vwKreditor] TO [tools_access];
GO